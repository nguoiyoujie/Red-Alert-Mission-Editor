using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RA_Mission_Editor.Util
{
	public static class StreamExts
	{
		public static Stream CreateWithoutOwningStream(Stream stream, long offset, int count)
		{
			//var nestedOffset = offset + GetOverallNestedOffset(stream, out var parentStream);

			// Special case FileStream - instead of creating an in-memory copy,
			// just reference the portion of the on-disk file that we need to save memory.
			// We use GetType instead of 'is' here since we can't handle any derived classes of FileStream.
			//if (parentStream.GetType() == typeof(FileStream))
			//{
			//	var path = ((FileStream)parentStream).Name;
			//	return new SegmentStream(File.OpenRead(path), nestedOffset, count);
			//}

			// For all other streams, create a copy in memory.
			// This uses more memory but is the only way in general to ensure the returned streams won't clash.
			stream.Seek(offset, SeekOrigin.Begin);
			return new MemoryStream(stream.ReadBytes(count));
		}

		public static byte[] ReadBytes(this Stream s, int count)
		{
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), "Non-negative number required.");
			var buffer = new byte[count];
			s.ReadBytes(buffer, 0, count);
			return buffer;
		}

		public static void ReadBytes(this Stream s, byte[] buffer, int offset, int count)
		{
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), "Non-negative number required.");
			while (count > 0)
			{
				int bytesRead;
				if ((bytesRead = s.Read(buffer, offset, count)) == 0)
					throw new EndOfStreamException();
				offset += bytesRead;
				count -= bytesRead;
			}
		}

		public static int Peek(this Stream s)
		{
			var b = s.ReadByte();
			if (b == -1)
				return -1;
			s.Seek(-1, SeekOrigin.Current);
			return (byte)b;
		}

		public static byte ReadUInt8(this Stream s)
		{
			var b = s.ReadByte();
			if (b == -1)
				throw new EndOfStreamException();
			return (byte)b;
		}

		public static ushort ReadUInt16(this Stream s)
		{
			return (ushort)(s.ReadUInt8() | s.ReadUInt8() << 8);
		}

		public static short ReadInt16(this Stream s)
		{
			return (short)(s.ReadUInt8() | s.ReadUInt8() << 8);
		}

		public static uint ReadUInt32(this Stream s)
		{
			return (uint)(s.ReadUInt8() | s.ReadUInt8() << 8 | s.ReadUInt8() << 16 | s.ReadUInt8() << 24);
		}

		public static int ReadInt32(this Stream s)
		{
			return s.ReadUInt8() | s.ReadUInt8() << 8 | s.ReadUInt8() << 16 | s.ReadUInt8() << 24;
		}

		public static void Write(this Stream s, int value)
		{
			s.WriteArray(BitConverter.GetBytes(value));
		}

		public static float ReadFloat(this Stream s)
		{
			return BitConverter.ToSingle(s.ReadBytes(4), 0);
		}

		public static double ReadDouble(this Stream s)
		{
			return BitConverter.ToDouble(s.ReadBytes(8), 0);
		}

		public static string ReadASCII(this Stream s, int length)
		{
			return new string(Encoding.ASCII.GetChars(s.ReadBytes(length)));
		}

		public static string ReadASCIIZ(this Stream s)
		{
			var bytes = new List<byte>();
			byte b;
			while ((b = s.ReadUInt8()) != 0)
				bytes.Add(b);
			return new string(Encoding.ASCII.GetChars(bytes.ToArray()));
		}

		public static string ReadAllText(this Stream s)
		{
			using (s)
			using (var sr = new StreamReader(s))
				return sr.ReadToEnd();
		}

		public static byte[] ReadAllBytes(this Stream s)
		{
			using (s)
			{
				if (s.CanSeek)
					return s.ReadBytes((int)(s.Length - s.Position));

				var bytes = new List<byte>();
				var buffer = new byte[1024];
				int count;
				while ((count = s.Read(buffer, 0, buffer.Length)) > 0)
					bytes.AddRange(buffer.Take(count));
				return bytes.ToArray();
			}
		}

		// Note: renamed from Write() to avoid being aliased by
		// System.IO.Stream.Write(System.ReadOnlySpan) (which is not implemented in Mono)
		public static void WriteArray(this Stream s, byte[] data)
		{
			s.Write(data, 0, data.Length);
		}

		public static IEnumerable<string> ReadAllLines(this Stream s)
		{
			string line;
			using (var sr = new StreamReader(s))
				while ((line = sr.ReadLine()) != null)
					yield return line;
		}

		// The string is assumed to be length-prefixed, as written by WriteString()
		public static string ReadString(this Stream s, Encoding encoding, int maxLength)
		{
			var length = s.ReadInt32();
			if (length > maxLength)
				throw new InvalidOperationException($"The length of the string ({length}) is longer than the maximum allowed ({maxLength}).");

			return encoding.GetString(s.ReadBytes(length));
		}

		// Writes a length-prefixed string using the specified encoding and returns
		// the number of bytes written.
		public static int WriteString(this Stream s, Encoding encoding, string text)
		{
			byte[] bytes;

			if (!string.IsNullOrEmpty(text))
				bytes = encoding.GetBytes(text);
			else
				bytes = new byte[0];

			s.Write(bytes.Length);
			s.WriteArray(bytes);

			return 4 + bytes.Length;
		}
	}
}

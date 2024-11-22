using RA_Mission_Editor.FileFormats.Encodings;
using RA_Mission_Editor.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RA_Mission_Editor.FileFormats
{
  public class MixFile : VirtualFile, IArchive
  {
		[Flags]
		enum MixFileFlags : uint
		{
			Checksum = 0x10000,
			Encrypted = 0x20000,
		}

		public class MixEntry
		{
			public readonly uint Hash;
			public readonly uint Offset;
			public readonly uint Length;

			public MixEntry(uint hash, uint offset, uint length)
			{
				Hash = hash;
				Offset = offset;
				Length = length;
			}

			public void Write(BinaryWriter w)
			{
				w.Write(Hash);
				w.Write(Offset);
				w.Write(Length);
			}

			public override string ToString()
			{
				string filename;
				if (Names.TryGetValue(Hash, out filename))
					return string.Format("{0} - offset 0x{1:x8} - length 0x{2:x8}", filename, Offset, Length);
				else
					return string.Format("0x{0:x8} - offset 0x{1:x8} - length 0x{2:x8}", Hash, Offset, Length);
			}

			public static uint HashFilename(string filename)
			{

				filename = filename.ToUpperInvariant();
				if (filename.Length % 4 != 0)
					filename = filename.PadRight(filename.Length + (4 - filename.Length % 4), '\0');

				var result = 0u;
				var data = Encoding.ASCII.GetBytes(filename);
				var i = 0;
				while (i < data.Length)
				{
					var next = (uint)(data[i++] | data[i++] << 8 | data[i++] << 16 | data[i++] << 24);
					result = ((result << 1) | (result >> 31)) + next;
				}

				return result;
			}

			static Dictionary<uint, string> Names = new Dictionary<uint, string>();

			public static void AddStandardName(string s)
			{
				uint hash = HashFilename(s);
				Names[hash] = s;
			}

			public const int Size = 12;
		}


		public Dictionary<uint, MixEntry> Index;
		public List<string> FileNames = new List<string>();
		bool isRmix, isEncrypted;
		long dataStart;
		const long headerStart = 84;
		public int UnidentifiedFiles { get { return Index.Count - FileNames.Count; } }

		public MixFile(Stream baseStream, string filename = "", bool isBuffered = false) : this(baseStream, filename, 0, baseStream.Length, isBuffered)
		{
			ReadFilenameDB();
		}

		public MixFile(Stream baseStream, string filename, int baseOffset, long fileSize, bool isBuffered = false, bool parseHeader = true)
			: base(baseStream, filename, baseOffset, fileSize, isBuffered)
		{
			if (parseHeader)
				ParseHeader();
			ReadFilenameDB();
		}

		public bool ContainsFile(string filename)
		{
			return Index.ContainsKey(MixEntry.HashFilename(filename));
		}

		public VirtualFile OpenFile(string filename, FileFormat f = FileFormat.None, BufferingMode m = BufferingMode.Default)
		{
			MixEntry e;
			if (!Index.TryGetValue(MixEntry.HashFilename(filename), out e))
				return null;
			else
				return FormatHelper.OpenAsFormat(BaseStream, filename, (int)(BaseOffset + dataStart + e.Offset), (int)e.Length, f, m);
		}

		public VirtualFile OpenFile(uint mixEntry, string filename = "", FileFormat f = FileFormat.None, BufferingMode m = BufferingMode.Default)
		{
			var e = Index[mixEntry];
			return FormatHelper.OpenAsFormat(BaseStream, filename, (int)(BaseOffset + dataStart + e.Offset), (int)e.Length, f, m);
		}

		private void ParseHeader()
		{
			Position = 0;
			BinaryReader reader = new BinaryReader(this);
			uint signature = reader.ReadUInt32();

			isRmix = 0 == (signature & ~(uint)(MixFileFlags.Checksum | MixFileFlags.Encrypted));

			if (isRmix)
			{
				isEncrypted = (signature & (uint)MixFileFlags.Encrypted) != 0;
				if (isEncrypted)
				{
					Index = ParseRaHeader(this, out dataStart).ToDictionary(x => x.Hash);
					return;
				}
			}
			else
				Seek(0, SeekOrigin.Begin);

			isEncrypted = false;
			Index = ParseTdHeader(this, out dataStart).ToDictionary(x => x.Hash);
		}

		private static List<MixEntry> ParseRaHeader(VirtualFile s, out long dataStart)
		{
			//BinaryReader reader = new BinaryReader(s);
			byte[] keyblock = s.Read(80);
			byte[] blowfishKey = new BlowfishKeyProvider().DecryptKey(keyblock);
			uint[] h = ReadUints(s, 2);

			var fish = new Blowfish(blowfishKey);
			MemoryStream ms = Decrypt(h, fish);
			var reader2 = new BinaryReader(ms);

			ushort numFiles = reader2.ReadUInt16();
			reader2.ReadUInt32(); /*datasize*/

			s.Position = headerStart;

			int byteCount = 6 + numFiles * MixEntry.Size;
			h = ReadUints(s, (byteCount + 3) / 4);

			ms = Decrypt(h, fish);

			dataStart = headerStart + byteCount + ((~byteCount + 1) & 7);

			return ParseTdHeader(new VirtualFile(ms), out _);
		}

		private static List<MixEntry> ParseTdHeader(VirtualFile s, out long dataStart)
		{
			var items = new List<MixEntry>();
			var reader = new BinaryReader(s);
			ushort numFiles = reader.ReadUInt16();
			reader.ReadUInt32(); /*datasize*/

			for (int i = 0; i < numFiles; i++)
				items.Add(new MixEntry(reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32()));

			dataStart = s.Position;
			return items;
		}

		private static MemoryStream Decrypt(uint[] h, Blowfish fish)
		{
			uint[] decrypted = fish.Decrypt(h);

			var ms = new MemoryStream();
			var writer = new BinaryWriter(ms);
			foreach (uint t in decrypted)
				writer.Write(t);
			writer.Flush();

			ms.Position = 0;
			return ms;
		}

		private static uint[] ReadUints(VirtualFile r, int count)
		{
			var ret = new uint[count];
			for (int i = 0; i < ret.Length; i++)
				ret[i] = r.ReadUInt32();

			return ret;
		}

		public Stream GetContent(MixEntry entry)
		{
			return StreamExts.CreateWithoutOwningStream(BaseStream, dataStart + entry.Offset, (int)entry.Length);
		}

		private void ReadFilenameDB()
		{
			// Try and find a local mix database
			uint dbName = MixEntry.HashFilename("local mix database.dat");
			if (Index.TryGetValue(dbName, out MixEntry dbEntry))
      {
				using (Stream content = GetContent(dbEntry))
				{
					try
					{
						XccLocalDatabase db = new XccLocalDatabase(content, true);
						foreach (string filename in db.Entries)
						{
							// verify if the filename actually belongs to an entry
							if (ContainsFile(filename))
							{
								FileNames.Add(filename);
								MixEntry.AddStandardName(filename);
							}
						}
					}
					catch (Exception e)
          {
						Console.WriteLine("Failed to read xcc local database: " + e.Message + "\n" + e.StackTrace);
          }
				}
			}

			if (UnidentifiedFiles > 0)
			{
				// Use the global mix database, if one exists
				if (Globals.XCCGlobalDatabase != null)
				{
					foreach (string filename in Globals.XCCGlobalDatabase.Entries)
					{
						// verify if the filename actually belongs to an entry
						if (ContainsFile(filename))
						{
							FileNames.Add(filename);
							MixEntry.AddStandardName(filename);
						}
					}
				}
			}
		}

    public override string ToString()
    {
      return FileName;
    }
  }
}

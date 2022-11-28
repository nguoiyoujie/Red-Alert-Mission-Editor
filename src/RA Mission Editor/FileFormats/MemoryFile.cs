using System.IO;

namespace RA_Mission_Editor.FileFormats
{
	/// <summary>Virtual file from a memory buffer.</summary>
	public class MemoryFile : VirtualFile {

		public MemoryFile(byte[] buffer, bool isBuffered = true) :
			base(new MemoryStream(buffer), "MemoryFile", 0, buffer.Length, isBuffered) { }
	}
}
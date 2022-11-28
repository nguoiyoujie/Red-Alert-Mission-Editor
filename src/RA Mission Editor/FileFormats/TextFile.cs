using System.IO;
using System.Text;
namespace RA_Mission_Editor.FileFormats
{
	public abstract class TextFile
	{
		protected virtual string ReadLine(Stream s)
		{
			// works for ascii only!
			var builder = new StringBuilder(80);
			while (s.CanRead)
			{
				char c = (char)s.ReadByte();
				if (c == '\n')
					break;
				else if (c != '\r')
					builder.Append(c);
			}
			return builder.ToString();
		}
	}
}

namespace RA_Mission_Editor.FileFormats
{
  public interface IArchive
    {
        bool ContainsFile(string filename);
        VirtualFile OpenFile(string filename, FileFormat format, BufferingMode m = BufferingMode.Default);

        void Close();
    }
}

using System.Collections.Generic;

namespace RA_Mission_Editor.Entities
{
  public class CopyInfo : ILocatable
  {
    // internal class to store copy information

    public int Cell { get; set; } // Cell ID of the top-left corner

    public readonly List<int> Offsets = new List<int>();
  }
}

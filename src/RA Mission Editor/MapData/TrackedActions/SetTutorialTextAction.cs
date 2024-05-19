namespace RA_Mission_Editor.MapData.TrackedActions
{
  public class SetTutorialTextAction : ITrackedAction
  {
    public Map Map;
    public string Description { get; set; }
    public int Index;
    public string OldText;
    public string NewText;

    public SetTutorialTextAction(Map map, int index, string oldText, string newText)
    {
      Map = map;
      Index = index;
      OldText = oldText;
      NewText = newText;
      Description = "Set Tutorial Text #" + Index;
    }

    public void Do()
    {
      if (NewText != null)
      {
        Map.TutorialSection.Messages[Index] = NewText;
      }
      else
      { 
        Map.TutorialSection.Messages.Remove(Index);
      }
      Map.Dirty = true;
    }

    public void Undo()
    {
      if (OldText != null)
      {
        Map.TutorialSection.Messages[Index] = OldText;
      }
      else
      {
        Map.TutorialSection.Messages.Remove(Index);
      }
      Map.Dirty = true;
    }
  }
}
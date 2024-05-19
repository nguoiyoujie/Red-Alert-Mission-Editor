namespace RA_Mission_Editor.MapData.TrackedActions
{
  public interface ITrackedAction
  {
    string Description { get; }

    void Do();

    void Undo();

  }

  public interface ITrackedSnapshotAction : ITrackedAction
  {
    void SnapshotOld();

    void SnapshotNew();
  }
}
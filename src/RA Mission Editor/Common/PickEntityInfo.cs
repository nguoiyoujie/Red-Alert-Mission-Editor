using RA_Mission_Editor.Entities;

namespace RA_Mission_Editor.Common
{
  public class PickEntityInfo
  {
    public IEntity Entity;
    public int X;
    public int Y;

    public PickEntityInfo() { }

    public PickEntityInfo(IEntity entity, int x, int y)
    {
      Entity = entity;
      X = x;
      Y = y;
    }
  }
}

using System;

namespace RA_Mission_Editor.Common
{
  [Flags]
  public enum PlaceEntityMode 
  {
    NONE = 0,
    SELECT = 1 << 0,
    PLACE = 1 << 1,
    DRAG = 1 << 2,
    PAINTING = 1 << 3,
    DELETE = 1 << 4,

    NO_DRAW = SELECT | DRAG | DELETE
  }
}

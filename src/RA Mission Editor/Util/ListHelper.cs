using System;
using System.Collections.Generic;
using System.Linq;

namespace RA_Mission_Editor.Util
{
  public static class ListHelper
  {
    public static List<int> FindAllIndex<T>(this IEnumerable<T> values, Predicate<T> condition)
    {
      return values.Select((b, i) => condition(b) ? i : -1).Where(i => i != -1).ToList();
    }
  }
}

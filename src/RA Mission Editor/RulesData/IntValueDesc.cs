using System;

namespace RA_Mission_Editor.RulesData
{
  public readonly struct IntValueDesc : IEquatable<IntValueDesc>
  {
    public readonly int Value;
    public readonly Func<string> DescriptionGetter;

    public IntValueDesc(int value, Func<string> descriptionGetter)
    {
      Value = value;
      DescriptionGetter = descriptionGetter;
    }

    public bool Equals(IntValueDesc other)
    {
      return Value.Equals(other.Value);
    }

    public override bool Equals(object obj)
    {
      return obj is IntValueDesc iv ? Equals(iv) : false;
    }

    public override int GetHashCode()
    {
      return -1937169414 + Value.GetHashCode();
    }

    public override string ToString()
    {
      string desc = DescriptionGetter?.Invoke() ?? null; 
      if (string.IsNullOrWhiteSpace(desc))
      {
        return Value.ToString();
      }
      else
      {
        return Value + ": " + desc;
      }
    }
  }
}

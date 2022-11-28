using System;
using System.Collections.Generic;

namespace RA_Mission_Editor.Util
{
  public static class StringExts
  {
    public static IEnumerable<string> SplitByLength(this string str, int maxLength)
    {
      for (int index = 0; index < str.Length; index += maxLength)
      {
        yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
      }
    }

    public static IEnumerable<string> SplitByCharWithinLength(this string input, char[] delimiter, int length)
    {
      if (input.Length < length)
      {
        yield return input;
      }
      else
      {
        string remain = input;
        while (remain.Length > length)
        {
          string check = remain.Substring(0, length);
          int splitIndex = -1;
          foreach (char c in delimiter)
          {
            int i = check.LastIndexOf(c);
            if (i > splitIndex)
            {
              splitIndex = i;
            }
          }
          if (splitIndex <= 1) // don't split just one character
          {
            // march forward
            splitIndex = length;
            while (splitIndex < remain.Length)
            {
              bool match = false;
              foreach (char c in delimiter)
              {
                if (remain[splitIndex] == c)
                  match = true;
              }
              if (match) break;
              splitIndex++;
            }
          }

          if (splitIndex >= remain.Length)
          {
            // this is the last segment, break
            break;
          }
          else
          {
            yield return remain.Substring(0, splitIndex);
            remain = remain.Substring(splitIndex + 1);
          }
        }
        yield return remain;
      }
    }

  }
}

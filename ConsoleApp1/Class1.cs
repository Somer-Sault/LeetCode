using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  class ClassA
  {
    public ClassB B { get; set; }
  }

  class ClassB
  {
    public ClassA A { get; set; }

    public int StrStr(string haystack, string needle)
    {
      if (string.IsNullOrEmpty(needle))
        return 0;

      if (needle.Length > haystack.Length)
        return -1;

      for (int h = 0; h < haystack.Length; h++)
      {
        if (haystack[h] == needle[0] && (h + needle.Length) <= haystack.Length)
        {
          int startIdx = h;
          int nextOccur = 0;
          for (int n = 1; n < needle.Length && (h + n) < haystack.Length; n++)
          {
            if (haystack[h + n] == needle[0] && nextOccur == 0)
              nextOccur = h + n;
            if (haystack[h + n] != needle[n])
            {
              h = nextOccur > 0 ? (nextOccur - 1) : n;
              break;
            }
          }

          if (startIdx == h && nextOccur == 0)
            return startIdx;

        }
      }

      return -1;
    }

    public int TrapRainWater(int[] height)
    {
      if (height.Length == 0) return 0;

      int i = 0;
      int total = 0;

      // Skip zeros
      for (; i < height.Length - 1; i++)
        if (height[i] != 0)
          break;

      // No holes for capturing water
      if (i >= height.Length - 1) return 0;

      int level = height[i];
      int idx = i;
      i++;

      for (; i < height.Length; i++)
      {
        int maxCurLevel = 0;
        int maxCurLevelIdx = -1;
        int curLevelVal = 0;
        while (height[i] < level)
        {
          if (maxCurLevel < height[i])
          {
            maxCurLevel = height[i];
            maxCurLevelIdx = i;
          }

          curLevelVal += level - height[i];

          if (i >= height.Length - 1)
            break;

          i++;
        }

        if (level > height[i])
        {
          // Start with another lower level from the same place
          if (maxCurLevelIdx > 0)
          {
            level = height[maxCurLevelIdx];
            i = idx;
          }
        }
        else
        {
          level = height[i];
          total += curLevelVal;
          idx = i;
        }

      }

      return total;

    }

  }



}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class _58LenOflastWord
  {
    public int LengthOfLastWord(string s)
    {
      //char[] arr = s.ToCharArray();
      int prevSpaceIdx = 0;
      //int currSpaceidx = 0;
      int longestStartIdx = 0;
      int longestEndIdx = 0;
      bool containsSpaces = false;
      for (int i = 0; i < s.Length; i++)
      {
        if (s[i] == ' ')
        {
          if (i - prevSpaceIdx - 1 > longestEndIdx - longestStartIdx)
          {
            longestEndIdx = i - 1;
            longestStartIdx = prevSpaceIdx - 1;
          }
          i++;

          for (; i < s.Length; i++)
          {
            if (s[i] != ' ')
            {
              prevSpaceIdx = i;
              break;
            }
          }


          //containsSpaces = true;
        }
      }

      // Get last non space character
      int lastNonSpace = -1;
      for (int g = s.Length; g > 0; g --)
      {
        if (s[g - 1] != ' ')
        {
          lastNonSpace = g;
          break;
        }
      }


      // last word
      if (lastNonSpace >  0 && (lastNonSpace - prevSpaceIdx > longestEndIdx - longestStartIdx) )
      {
        longestEndIdx = lastNonSpace;
        longestStartIdx = prevSpaceIdx;
      }

      return longestEndIdx - longestStartIdx;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  /*
   * Given a positive integer, return its corresponding column title as appear in an Excel sheet.
    For example:
    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 
   */
  public class ExcelSheetColumnTitle_168
  {
    public string ConvertToTitle(int n)
    {
      var stack = new Stack<char>(); // 2^8 < 26^2 => MaxIntValue = 2^31 < 26^8 => 8 chars max in stack!
      while (n > 0)
      {
        n--; // indexing (1 + 'A' --> 'B'), not forget to subtract 1
        int mod = n % 26;
        n = n / 26;
        stack.Push((char)(mod + 'A'));
      }
      return new string(stack.ToArray());
      // we dont want to use stringbuilder.insert as it O(n) operation
    }
  }
}

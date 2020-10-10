using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class HammingDistance_461
  {
    public static int HammingDistance(int x, int y)
    {
      int dist = 0;
      int xor = x ^ y;
      for (int i = 0; i < 32; i++)
      {
        if ((xor & (1 << i)) != 0)
          dist++;
      }
      return dist;
      // Solution 2
      // Convert.ToString(x ^ y, 2).Count(x => x == '1');
    }
  }


}

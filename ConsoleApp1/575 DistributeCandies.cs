using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  class _575_DistributeCandies
  {
    public int DistributeCandies(int[] candies)
    {
      var hs = new HashSet<int>(candies);
      int sisterCandiesNum = candies.Length / 2;
      return Math.Min(sisterCandiesNum, hs.Count);
    }
  }
}

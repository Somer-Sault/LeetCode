using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class SubSets_78
  {
    public IList<IList<int>> Subsets(int[] nums)
    {
      List<IList<int>> rc = new List<IList<int>>();
      if (nums == null || nums.Length == 0) return rc;

      int n = nums.Length;

      // Take into consideration leading zeroes (1_000 --> 1_111)
      for (int i = (int)Math.Pow(2, n); i < (int)Math.Pow(2, n + 1); ++i)
      {
        // generate bitmask, from 0..00 to 1..11
        string bitmask = Convert.ToString(i, 2).Substring(1);

        // append subset corresponding to that bitmask
        var curr = new List<int>();
        for (int j = 0; j < n; ++j)
          if (bitmask[j] == '1') curr.Add(nums[j]);

        rc.Add(curr);
      }


      /* Variant 2
      rc.Add(new List<int>());

      for (int i = 0; i < nums.Length; i++)
      {
        var addition = new List<IList<int>>(rc);
        foreach (var seq in addition)
        {
          var seqNew = new List<int>(seq);
          seqNew.Add(nums[i]);
          rc.Add(seqNew);
        }
      }
      */

      return rc;
    }
  }
}

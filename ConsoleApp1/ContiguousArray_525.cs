using System.Collections.Generic;

namespace ConsoleApp1
{
  class ContiguousArray_525
  {
    // O(N) - Space compl (dictionary)
    // O(N) - runtime (go through array once)
    public int FindMaxLength(int[] nums)
    {
      // Map contains 2-len array to store 1st and last idx
      var diffMap = new Dictionary<int/*diff*/, int[] /*indx*/>();
      int difference = 0;

      // Initial element (to start from)
      diffMap.Add(0, new int[2] { 0, 0 });

      for (int i = 0; i < nums.Length; i++)
      {
        if (nums[i] == 0)
          difference++;
        else
          difference--;

        if (diffMap.ContainsKey(difference))
          diffMap[difference][1] = i + 1;
        else
          diffMap[difference] = new int[2] { i + 1, i + 1 };

      }

      int maxLen = 0;
      foreach (int[] arr in diffMap.Values)
      {
        if (arr[1] == arr[0]) continue;

        int temp = arr[1] - arr[0];
        if (temp > maxLen)
          maxLen = temp;
      }

      return maxLen;
    }
  }
}

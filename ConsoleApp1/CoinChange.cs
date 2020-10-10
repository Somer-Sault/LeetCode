using System;
namespace ConsoleApp1
{
  /// <summary>
  /// https://leetcode.com/problems/coin-change/solution/
  /// DynProg: recursion +memo
  /// F(S) = F(S - some of Ci) + 1;
  /// Need just define Ci which gives minimun
  /// </summary>
  public class CoinChange
  {
    public static bool canGetExactChange(int targetMoney, int[] denominations)
    {
      // TODO check iputs
      for (int i = 0; i < denominations.Length; i++)
        if (targetMoney % denominations[i] == 0)
          return true;

      if (targetMoney < 1) return false;
      return GetMinCoinsToChange(denominations, targetMoney, new int[targetMoney]) > 0;
    }

    private static int GetMinCoinsToChange(int[] coins, int rem, int[] count)
    {
      if (rem < 0) return -1;
      if (rem == 0) return 0;
      if (count[rem - 1] != 0) return count[rem - 1];
      int min = Int32.MaxValue;
      foreach (int coin in coins)
      {
        int res = GetMinCoinsToChange(coins, rem - coin, count);
        if (res >= 0 && res < min)
          min = 1 + res;
      }
      count[rem - 1] = (min == Int32.MaxValue) ? -1 : min;
      return count[rem - 1];
    }
  }
}

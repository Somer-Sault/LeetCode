using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  static class SellBuy_121
  {
    public static int MaxProfit(int[] prices)
    {
      int profit = 0;
      int sell = Int32.MinValue;
      int buy = Int32.MaxValue;
      int max = 0;

      for (int i = 0; i < prices.Length; i++)
      {
        if (prices[i] < buy)
        {
          // New attractive price to buy
          if (profit > max)
            max = profit;

          sell = Int32.MinValue;
          buy = prices[i];

          if (profit > (sell - buy))
            profit = sell - buy;
        }
        else if (prices[i] > sell)
        {
          sell = prices[i];
          if (profit < (sell - buy))
            profit = sell - buy;
        }
      }


      return max > profit ? max : profit;
    }
  }
}


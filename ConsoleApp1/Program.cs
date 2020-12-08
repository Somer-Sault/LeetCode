using ConsoleApp1.LinkedList;
using System;
using System.Collections.Generic;
using static ConsoleApp1.ReverseLinkList;
using ConsoleApp1.Akvelon;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      int[][] matrix = //new int[][]
      {
        new int[] {1,1,1},
        new int[] {1,0,1},
        new int[] {1,1,1}
      };
      SetMatrixZeroes_73.SetZeroes(matrix);

      string ssss = "#2#1#3";
      string[] split = ssss.Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
      TreeNode root = new TreeNode(Int32.Parse(split[0]));


      int dist = HammingDistance_461.HammingDistance(1, 4);
      //CoinChange.CoinChange2(new[] { 186, 419, 83, 408 }, 6249);
      Console.WriteLine(CoinChange.canGetExactChange(6249, new[] { 186, 419, 83, 408 }));
      return;

      var inpOrg = new List<string>()
      {
        "B2,E5,F6", "A1,B2,C3,D4", "D4,G7,I9", "G7,H8"
      };

      OrganizationHierarchy.Print(inpOrg);
      return;
        
      var head = new ListNode(1);
      var ln2 = new ListNode(3);
      var ln0 = new ListNode(0);
      var ln4 = new ListNode(2);

      head.next = ln2;
      ln2.next = ln0;
      ln0.next = ln4;
      //ln4.next = ln2;

      bool isPalindrome = new _234_PalindromeLinkedList().IsPalindrome(head);
      var cycelStartNode = new LinkedListCyclePosition().DetectCycle(head);

      //new SubSets_78().Subsets(new int[] { 1, 2, 3 });
      //var ln9 = new ListNode(9);
      //var ln1 = new ListNode(1);
      //ln1.next = ln9;
      //var ln5 = new ListNode(5);
      //ln5.next = ln1;
      //var head = new ListNode(4);
      //head.next = ln5;
      //PrintLinkList(head);
     // new _237_deleteLinkListNodecs().DeleteNode(ln5);
      PrintLinkList(head);

      //int cccc = new ClassB().TrapRainWater(new[] { 4, 9, 4, 5, 3, 2});
      //int cccc = new ClassB().TrapRainWater(new[] { 4, 2, 3 });
      //int cccc = new ClassB().TrapRainWater(new[] { 2, 0, 2 });
      int cccc = new ClassB().TrapRainWater(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
      //int cccc=  new ClassB().StrStr("mississippi", "pi");
      return;
      Console.WriteLine(SellBuy_121.MaxProfit(new[] { 1, 2 }));
      //Console.WriteLine(new _58LenOflastWord().LengthOfLastWord("azx vx"));
      return;
      //var tn = new TreeNode(10);
      //tn.left = new TreeNode(5);
      //tn.right = new TreeNode(15);
      //tn.right.left  = new TreeNode(6);
      //tn.right.right = new TreeNode(20);

      var tn = new TreeNode(3);
      tn.left = new TreeNode(1);
      tn.left.left = new TreeNode(0);
      tn.left.right = new TreeNode(2);
      tn.left.right.right = new TreeNode(3);
      tn.right = new TreeNode(5);
      tn.right.left = new TreeNode(4);
      tn.right.right = new TreeNode(6); 
      bool isValid = new Solution98().IsValidBST(tn);
      return;


      //var l1 = new ListNode(1);
      //var l2 = new ListNode(2);
      //var l3 = new ListNode(3);
      //var l4 = new ListNode(4);
      //var l5 = new ListNode(5);
      //l1.next = l2;
      //l2.next = l3;
      //l3.next = l4;
      //l4.next = l5;
      //l5.next = null;


      //var rll = new ReverseLinkList();
      //PrintLinkList(rll.ReverseList(l1));
      //Console.ReadKey();
      //return;

      ClassA a = new ClassA();
      ClassB b = new ClassB();

      a.B = b;
      b.A = a;

      //Solution s = new Solution();
      //var xx = s.Generate(10);
      //foreach (IList<int> row in xx)
      //  Console.WriteLine(string.Join(',', row));
      
    }

    static void PrintLinkList(ListNode head)
    {
      Console.WriteLine();
      while (head != null)
      {
        Console.Write(head.val + "->");
        head = head.next;
      }
    }


  }

  public class Solution
  {
    public IList<IList<int>> Generate(int numRows)
    {
      if (numRows == 0)
        return new[] { Array.Empty<int>() };

      var res = new IList<int>[numRows];
      res[0] = new int[] { 1 };
      if (numRows == 1)
        return res;

      res[1] = new int[] { 1, 1 };
      if (numRows == 2)
        return res;

      for (int i = 2; i < numRows; i++)
      {
        int[] cur = new int[i + 1];
        cur[0] = 1;
        cur[i] = 1;
        for (int m = 1; m < i; m++)
        {
          cur[m] = res[i - 1][m - 1] + res[i - 1][m];
        }

        res[i] = cur;

      }
      return res;

    }
  }
}

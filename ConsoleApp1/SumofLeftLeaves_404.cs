using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class SumofLeftLeaves_404
  {
    public int SumOfLeftLeaves(TreeNode root)
    {
      if (root == null) return 0;

      int sum = 0;
      // Should be left without children (looking for LEAVEs not Nodes)
      if (root.left != null && root.left.left == null && root.left.right == null)
        sum += root.left.val;

      return sum + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
    }
  }
}

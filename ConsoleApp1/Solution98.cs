using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class Solution98
  {


    public bool IsValidBST(TreeNode root)
    {
      if (root == null)
        return true;

      if (root.left?.val >= root.val)
        return false;
      if (root.right?.val <= root.val)
        return false;

      return Traverse(root.left, root, true) && Traverse(root.right, root, false);
    }


    private bool Traverse(TreeNode node, TreeNode nodeRoot, bool toLeft)
    {
      if (node == null)
        return true;

      if (node.left != null && node.left.val >= node.val)
        return false;
      if (node.right != null && node.right.val <= node.val)
        return false;

      if (nodeRoot != null)
      {
        if (toLeft)
        {
          if (node.val < nodeRoot.val &&
              node.right != null &&
              nodeRoot.val <= node.right.val)
            return false;
        }
        else
        {
          if (node.val > nodeRoot.val &&
              node.left != null &&
              nodeRoot.val >= node.left.val)
            return false;
        }
      }


      return Traverse(node.left, node, true) && Traverse(node.right, node, false);
    }
  }
}

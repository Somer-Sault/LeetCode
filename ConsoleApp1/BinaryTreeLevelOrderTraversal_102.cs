using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
  class BinaryTreeLevelOrderTraversal_102
  {
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      // check inputs
      if (root == null)
        return new List<IList<int>>();

      // Space: O(N)
      // Runtime: O(N)

      var map = new Dictionary<int/*lvl*/, IList<int> /*values*/>();
      var queue = new Queue<TreeNodeEx>();
      queue.Enqueue(new TreeNodeEx(root, 0));
      int level = 0;
      // [3,9,20,null,null,15,7]
      // q: 3,17 3,15
      // m: (0, {3}) (1, {9,20}) 3, {15,7 }
      // l: 3
      while (queue.Count > 0)
      {
        TreeNodeEx node = queue.Dequeue();
        if (node == null) continue;

        if (!map.ContainsKey(node.lvl))
          map[node.lvl] = new List<int> { node.val };
        else
          map[node.lvl].Add(node.val);

        if (node.left != null)
          queue.Enqueue(new TreeNodeEx(node.left, node.lvl + 1));
        if (node.right != null)
          queue.Enqueue(new TreeNodeEx(node.right, node.lvl + 1));
      }

      return map.Values.ToList();
    }
  }

  public class TreeNodeEx : TreeNode
  {
    public int lvl;
    public TreeNodeEx(TreeNode curr, int lvl = 0)
      : base(curr.val, curr.left, curr.right)
    {
      this.lvl = lvl;
    }

  }
}

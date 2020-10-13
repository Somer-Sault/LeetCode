using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
  class BinaryTreeLevelOrderTraversal_102
  {
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      // Variant 1
      // Space: O(1)
      // Runtime: O(N)
      var result = new List<IList<int>>();
      if (root == null)
        return result;
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      while (queue.Count > 0)
      {
        //Now, we're going via all nodes of a single level of size levelSize
        int levelSize = queue.Count;
        var levelList = new List<int>(levelSize);
        for (int i = 0; i < levelSize; i++)
        {
          var node = queue.Dequeue();
          if (node == null) continue;
          levelList.Add(node.val);

          if (node.left != null)
            queue.Enqueue(node.left);
          if (node.right != null)
            queue.Enqueue(node.right);
        }
        result.Add(levelList);
      }

      return result;

      // Variant 2
      // Space: O(N)
      // Runtime: O(N)
      //if (root == null)
      //  return new List<IList<int>>();
      //var map = new Dictionary<int/*lvl*/, IList<int> /*values*/>();
      //var queue = new Queue<TreeNodeEx>();
      //queue.Enqueue(new TreeNodeEx(root, 0));
      //int level = 0;
      //while (queue.Count > 0)
      //{
      //  TreeNodeEx node = queue.Dequeue();
      //  if (node == null) continue;

      //  if (!map.ContainsKey(node.lvl))
      //    map[node.lvl] = new List<int> { node.val };
      //  else
      //    map[node.lvl].Add(node.val);

      //  if (node.left != null)
      //    queue.Enqueue(new TreeNodeEx(node.left, node.lvl + 1));
      //  if (node.right != null)
      //    queue.Enqueue(new TreeNodeEx(node.right, node.lvl + 1));
      //}

      //return map.Values.ToList();
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

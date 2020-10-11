using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
  public class AverageLevelsBinaryTree_637
  {
    private Dictionary<int, List<int>> _levelsMap = new Dictionary<int, List<int>>();
    public IList<double> AverageOfLevels(TreeNode root)
    {
      AvgHelper(root, 0);
      return _levelsMap.Values.Select(x => x.Average()).ToList();
    }

    private void AvgHelper(TreeNode node, int level)
    {
      if (node == null) return;

      if (_levelsMap.ContainsKey(level))
        // Recal avg - mb overflow!
        _levelsMap[level].Add(node.val);
      else
        _levelsMap[level] = new List<int> { node.val };

      AvgHelper(node.left, level + 1);
      AvgHelper(node.right, level + 1);
    }
  }
}

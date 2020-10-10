using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class FlattenNestedListIterator_341
  {
    public class NestedIterator
    {
      private List<int> resultList = new List<int>();

      public NestedIterator(IList<NestedInteger> nestedList)
      {
        // First build the result list
        BuildList(nestedList);
      }

      private void BuildList(IList<NestedInteger> nestedList)
      {
        foreach (NestedInteger item in nestedList)
        {
          if (item.IsInteger())
            resultList.Add(item.GetInteger());
          else
            BuildList(item.GetList());
        }
      }

      // Work on iteration part 
      private int _pointer = 0;
      public bool HasNext()
      {
        return _pointer < resultList.Count;
      }

      public int Next()
      {
        _pointer++;
        return resultList[_pointer - 1];
      }
    }

    public interface NestedInteger
    {
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      IList<NestedInteger> GetList();
    }
  }
}

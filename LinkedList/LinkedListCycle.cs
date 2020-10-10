using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{
  /// <summary>
  /// 
  /// </summary>
  ///
  class LinkedListCycle
  {
    public bool HasCycle(ListNode head)
    {
      if (head == null || head.next == null)
        return false;
      var cur1 = head;
      var cur2 = head;

      while (cur1?.next != null && cur2?.next?.next != null)
      {
        cur1 = cur1.next;
        cur2 = cur2.next.next;
        if (cur1 == cur2)
          return true;
      }
      return false;
    }
  }
}

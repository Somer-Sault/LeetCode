using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{
  /// <summary>
  /// 19 Medium
  /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
  /// </summary>
  class RemoveNthNodeFromEnd
  {
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
      ListNode dummy = new ListNode(0);
      dummy.next = head;
      ListNode a = dummy;
      ListNode b = dummy;

      // Advances first pointer so that the gap between first and second is n nodes apart
      for (int i = 1; i <= n + 1; i++)
        a = a.next;

      int cnt = 0;
      while (a != null)
      {
        a = a.next;
        b = b.next;
      }
      b.next = b.next.next;
      return dummy.next;
    }

  }
}

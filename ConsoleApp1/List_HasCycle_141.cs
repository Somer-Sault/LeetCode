using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  /// https://leetcode.com/problems/linked-list-cycle/
  class List_HasCycle_141
  {
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
    public bool HasCycle(ListNode head)
    {
      if (head == null)
        return false;
      var cur1 = head;
      var cur2 = head;

      while (cur1?.next != null && cur2?.next?.next != null)
      {
        //if (cur2.next.next == null)
        //return false;

        cur1 = cur1.next;
        cur2 = cur2.next.next;
        if (cur1 == cur2)
          return true;
      }
      return false;

    }
  }
}

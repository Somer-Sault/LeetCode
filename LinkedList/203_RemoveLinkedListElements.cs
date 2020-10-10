using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{
  /// <summary>
  /// 203 Easy
  /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
  /// Remove all elements from a linked list of integers that have value val.
  /// </summary>
  
  //Example:
  //Input:  1->2->6->3->4->5->6, val = 6
  //Output: 1->2->3->4->5
  class RemoveLinkedListElements
  {
    public ListNode RemoveElements(ListNode head, int val)
    {
      if (head == null)
        return null;

      ListNode cur = head;
      ListNode prev = null;
      while (cur != null)
      {
        if (cur.val == val)
        {
          if (prev != null)
            prev.next = cur.next;
          else // move list head
            head = cur.next;

          cur = cur.next;
          continue;
        }

        prev = cur;
        cur = cur.next;
      }

      return head;
    }
  }
}

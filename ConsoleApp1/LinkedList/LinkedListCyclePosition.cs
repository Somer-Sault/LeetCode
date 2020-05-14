using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{/*
  Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
  To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the linked list where tail connects to. If pos is -1, then there is no cycle in the linked list.
  Note: Do not modify the linked list.

  Example 1:

  Input: head = [3,2,0,-4], pos = 1
  Output: tail connects to node index 1
  Explanation: There is a cycle in the linked list, where tail connects to the second node.
  */
  public class LinkedListCyclePosition
  {
    public ListNode DetectCycle(ListNode head)
    {
      if (head == null || head.next == null)
        return null;
      var cur1 = head;
      var cur2 = head;

      bool hasCycle = false;
      // Find meet postion (number of steps of slow pointer)
      while (cur1?.next != null && cur2?.next?.next != null)
      {
        cur1 = cur1.next;
        cur2 = cur2.next.next;
        if (cur1 == cur2)
        {
          hasCycle = true;
          break;
        }
      }

      if (hasCycle == false)
        return null;

      
      cur1 = head;

      // cur1 go from start
      // cur2 keep moving from the meet point to the end of the cycle with 1-step at time
      // Having the same pace it should takes equal number of step for cur1 and cur2 to meet again inthe begin of the cycle
      while (cur2 != cur1)
      {
        if (cur1 == null || cur2 == null)
          return null;

        cur2 = cur2.next;
        cur1 = cur1.next;
      } 

      return cur2;
    }
  }
}

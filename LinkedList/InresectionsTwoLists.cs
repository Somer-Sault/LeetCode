using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{
  /*
   * 160 .Write a program to find the node at which the intersection of two singly linked lists begins.
For example, the following two linked lists:begin to intersect at node c1.
    */
  class InresectionsTwoLists
  {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
      if (headA == null || headB == null) return null;

      // Fwd A and B from the heads
      var a = headA;
      var b = headB;

      //if a & b have different len, then we will stop the loop after second iteration
      while (a != b)
      {
        //for the end of first iteration, we just reset the pointer to the head of another linkedlist
        a = a == null ? headB : a.next;
        b = b == null ? headA : b.next;
      }

      return a;
    }
  }
}

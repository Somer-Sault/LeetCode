using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  class ReverseLinkList
  {
    /**     * Definition for singly-linked list.*/

    public ListNode ReverseList(ListNode head)
    {
      ListNode prev = null;
      ListNode cur = head;
      //while (curr != null)
      //{
      //  ListNode nextTemp = curr.next;
      //  curr.next = prev;
      //  prev = curr;
      //  curr = nextTemp;
      //}
      //return prev;
      while (cur.next != null)
      {
        ListNode tmp = cur.next;
        cur.next = prev;
        prev = cur;
        cur = tmp;

      }

      cur.next = prev;

      return cur;

    }
  }
}

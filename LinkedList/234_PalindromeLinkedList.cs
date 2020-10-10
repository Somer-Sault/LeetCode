using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{
  /*
   * Given a singly linked list, determine if it is a palindrome.
    Example 1:
    Input: 1->2
    Output: false

    Example 2:
    Input: 1->2->2->1
    Output: true
   * 
   */

  /*
   This can be solved by reversing the 2nd half and compare the two halves. Let's start with an example [1, 1, 2, 1].

  In the beginning, set two pointers fast and slow starting at the head.

  1 -> 1 -> 2 -> 1 -> null 
  sf
  (1) Move: fast pointer goes to the end, and slow goes to the middle.

  1 -> 1 -> 2 -> 1 -> null 
          s          f
  (2) Reverse: the right half is reversed, and slow pointer becomes the 2nd head.

  1 -> 1    null <- 2 <- 1           
  h                      s
  (3) Compare: run the two pointers head and slow together and compare.

  1 -> 1    null <- 2 <- 1             
      h            s* 
   * */

  /// <summary> 
  /// 234. Palindrome Linked List
  /// https://leetcode.com/problems/palindrome-linked-list/
  /// </summary>
  class _234_PalindromeLinkedList
  {
    public bool IsPalindrome(ListNode head)
    {
      if (head == null || head.next == null)
        return true;

      ListNode fast = head, slow = head;
      // 1. Move
      while (fast != null && fast.next != null)
      {
        fast = fast.next.next;
        slow = slow.next;
      }
      if (fast != null)
      { // odd nodes: let right half smaller
        slow = slow.next;
      }
      // 2.Reverse
      slow = ReverseList(slow);
      fast = head;

      // 3.Compare
      while (slow != null)
      {
        if (fast.val != slow.val)
        {
          return false;
        }
        fast = fast.next;
        slow = slow.next;
      }
      return true;
    }

    private ListNode ReverseList(ListNode head)
    {
      ListNode prev = null;
      while (head != null)
      {
        ListNode next = head.next;
        head.next = prev;
        prev = head;
        head = next;
      }
      return prev;
    }
  }
}

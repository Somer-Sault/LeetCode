using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LinkedList
{
  /**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
  public class MyLinkedList
  {
    private void Log()
    {
      if (head == null) return;

      var cur = head;

      do
      {
        Console.Write(cur.val + "->");
        cur = cur.next;
      } while (cur != null);
      Console.WriteLine();
    }

    private ListNode head = null;
    /** Initialize your data structure here. */
    public MyLinkedList()
    {
    }

    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    // O(n)
    public int Get(int index)
    {
      var cur = head;
      for (int i = 0; i < index; i++)
      {
        if (cur == null)
          return -1;

        cur = cur.next;
      }

      int rc = cur == null ? -1 : cur.val;
      Console.WriteLine($"Get {rc} at index {index}");
      Log();
      return rc;
    }

    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val)
    {
      if (head == null)
      {
        head = new ListNode(val);
        Console.WriteLine("AddAtHead");
        Log();
        return;
      }


      var tmp = new ListNode(head.val, head.next);
      var newHead = new ListNode(val, tmp);
      head = newHead;

      Console.WriteLine("AddAtHead");
      Log();
    }

    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val)
    {
      if (head == null)
      {
        head = new ListNode(val);
        Console.WriteLine("AddAtTail");
        Log();
        return;
      }

      var cur = head;
      while (cur.next != null)
        cur = cur.next;

      cur.next = new ListNode(val);

      Console.WriteLine("AddAtTail");
      Log();
    }

    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val)
    {
      if (index == 0)
        AddAtHead(val);

      var cur = head;
      for (int i = 1; i <= index - 1; i++)
      {
        if (cur == null)
          return;

        cur = cur.next;
      }
      // Got previous node to the one being deleted 
      var inserted = new ListNode(val, cur.next);
      cur.next = inserted;

      Console.WriteLine("AddAtIndex");
      Log();
    }

    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index)
    {
      if (index < 0) return;
      if (index == 0)
      {
        head = head?.next;
        Console.WriteLine("DeleteAtIndex " + index);
        Log();
        return;
      }

      var cur = head;
      ListNode prev = null;
      for (int i = 0; i < index; i++)
      {
        prev = cur;
        cur = cur?.next;
        if (cur == null)
          break;
      }

      if (prev == null)
        return;

      // Got previous node to the one being deleted
      prev.next = cur?.next;
      Console.WriteLine("DeleteAtIndex " + index);
      Log();
    }
  }

  /**
   * Your MyLinkedList object will be instantiated and called as such:
   * MyLinkedList obj = new MyLinkedList();
   * int param_1 = obj.Get(index);
   * obj.AddAtHead(val);
   * obj.AddAtTail(val);
   * obj.AddAtIndex(index,val);
   * obj.DeleteAtIndex(index);
   */
}

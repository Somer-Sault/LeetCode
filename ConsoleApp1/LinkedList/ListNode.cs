using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
    public ListNode(int x, ListNode nextNode = null) { val = x;  next = nextNode; }

    public override string ToString() => $"Value: {val}, next {next?.val}";
  }
}

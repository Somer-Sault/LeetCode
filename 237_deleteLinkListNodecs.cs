using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  class _237_deleteLinkListNodecs
  {
    public void DeleteNode(ListNode node)
    {
      node.val = node.next.val;
      node.next = node.next.next;
    }

  }
}

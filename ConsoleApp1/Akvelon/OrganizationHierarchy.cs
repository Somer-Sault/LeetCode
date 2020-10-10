using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Coding inerview on Akvelon 26 may 6-9pm
namespace ConsoleApp1.Akvelon
{
  /*
   We have an organization and need to print an org chart in the terminal.
The input is a list of strings. Each string is a management / direct report relationship.
For example: "A1,B2,C3,D4"
Explanation: A1 is the manager of B2, C3, D4, where A1, B2, C3, D4 are unique employee IDs separated by a comma.
Input: ["B2,E5,F6", "A1,B2,C3,D4", "D4,G7,I9", "G7,H8"]
Output:
A1
    B2
        E5
        F6
    C3
    D4
        G7
            H8
        I9
*/

  public class OrganizationHierarchy
  {
    private static Dictionary<string/*leader*/,string> _data;
    private static char _delimeter =  ',';
    public static void Print(List<string> data)
    {
      if (data == null) 
        return;

      _data = data.ToDictionary(x => x.Split(new[] { _delimeter }, StringSplitOptions.RemoveEmptyEntries)[0], y => y);

      string rootVal = GetRoot();
      if (string.IsNullOrEmpty(rootVal))
        return; 

      string rootSequence = data.FirstOrDefault(x => x.StartsWith(rootVal, StringComparison.InvariantCultureIgnoreCase));
      // Build Tree from the root
      TreeNodeEx root = new TreeNodeEx(rootVal);
      BuildTree(root, rootSequence);
      // Visualize nodes
      root.Visualize();
    }


    /// <param name="parent"></param>
    /// <param name="sequence">First one is the parent:  "D4,G7,I9"</param>
    private static void BuildTree(TreeNodeEx parent, string sequence)
    {
      if (parent == null || string.IsNullOrEmpty(sequence))
        return;

      var splited = sequence.Split(new[] { _delimeter }, StringSplitOptions.RemoveEmptyEntries);
      if (splited.Length <= 1)
        return;

      // Skip parent at the start
      parent.Children.AddRange(splited.Skip(1).Select(ch => new TreeNodeEx(ch, parent)));

      foreach (var child in parent.Children)
      {
        if (!_data.ContainsKey(child.Val))
          continue;

        BuildTree(child, _data[child.Val]);
      }
    }

    /// <summary> Find root - it should appear only once.Return its value </summary>
    private static string GetRoot()
    {
      var empMap = new Dictionary<string, int>();
      foreach(string empId in string.Join(_delimeter, _data.Values).Split(_delimeter))
      {
        if (!empMap.ContainsKey(empId))
        {
          empMap.Add(empId, 1);
          continue;
        }

        empMap[empId]++;
      }
      string root = empMap.Where(x => x.Value == 1)
        .Select( x => x.Key)
        .Intersect(_data.Keys.Select(d => d.Split(_delimeter)[0]), StringComparer.InvariantCultureIgnoreCase)
        .FirstOrDefault();

      return root;
    }
  }

  public class TreeNodeEx
  {
    public string Val { get; }
    public TreeNodeEx Parent { get; set; }
    public List<TreeNodeEx> Children { get; set; }
    public TreeNodeEx(string x, TreeNodeEx parent = null) 
    { 
      Val = x;
      Children = new List<TreeNodeEx>();
      Parent = parent;
    }

    public void Visualize() 
    {
      // Make indentation
      var current = this;
      Console.WriteLine();
      while (current.Parent != null)
      {
        Console.Write(" ");
        current = current.Parent;
      }
      Console.Write(Val);

      if (Children == null)
        return;
      Children.ForEach(n => n.Visualize());
    }

    public override string ToString() => Val;
  }
}

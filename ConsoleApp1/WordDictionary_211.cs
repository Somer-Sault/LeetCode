using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
  /*
  Design a data structure that supports adding new words and finding if a string matches any previously added string.
  Implement the WordDictionary class:

  WordDictionary() Initializes the object.
  void addWord(word) Adds word to the data structure, it can be matched later.
  bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise.word may contain dots '.' where dots can be matched with any letter.

  Example:

  Input
  ["WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search"]
  [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
  Output
  [null, null, null, null, false, true, true, true]

  Explanation
  WordDictionary wordDictionary = new WordDictionary();
    wordDictionary.addWord("bad");
  wordDictionary.addWord("dad");
  wordDictionary.addWord("mad");
  wordDictionary.search("pad"); // return False
  wordDictionary.search("bad"); // return True
  wordDictionary.search(".ad"); // return True
  wordDictionary.search("b.."); // return True
 */

  public class WordDictionary
  {
    // Dyummy root node
    private TrieNode _root = new TrieNode();
    /** Initialize your data structure here. */
    public WordDictionary() {}

    /** Adds a word into the data structure. */
    public void AddWord(string word)
    {
      var node = _root;
      for (int i = 0; i < word.Length; i++)
      {
        if (node.children[word[i] - 'a'] == null)
          node.children[word[i] - 'a'] = new TrieNode();

        node = node.children[word[i] - 'a'];
      }
      // Important property
      node.IsWord = true;
    }

    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) => SearchFromNode(_root, word);

    private bool SearchFromNode(TrieNode startNode, string word)
    {
      if (string.IsNullOrEmpty(word) || startNode == null)
        return false;

      for (int i = 0; i < word.Length; i++)
      {
        if (word[i] == '.')
        {
          if (i == word.Length - 1)
            return startNode.children.Any(x => x != null && x.IsWord);
          // Get all nodes at the level
          return startNode.children.Any(n => SearchFromNode(n, word.Substring(i + 1)));
        }

        var next = startNode.children[word[i] - 'a'];
        if (next != null)
        {
          if (i == word.Length - 1)
            return next.IsWord;

          startNode = next;
        }
        else
          return false;
      }
      return false;
    }


    class TrieNode
    {
      // Englidh lowercase chars only (can use Dictionary in other case)
      public TrieNode[] children = new TrieNode[26];
      // Is complete word?
      public bool IsWord;
      public TrieNode() { }
    }
  }

  /**
   * Your WordDictionary object will be instantiated and called as such:
   * WordDictionary obj = new WordDictionary();
   * obj.AddWord(word);
   * bool param_2 = obj.Search(word);
   */
}

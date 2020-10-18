namespace ConsoleApp1
{
  /*
   *  Implement Trie (Prefix Tree)
   Example:
    Trie trie = new Trie();

    trie.insert("apple");
    trie.search("apple");   // returns true
    trie.search("app");     // returns false
    trie.startsWith("app"); // returns true
    trie.insert("app");   
    trie.search("app");     // returns true
    Note:
    You may assume that all inputs are consist of lowercase letters a-z.
    All inputs are guaranteed to be non-empty strings.* 
   */
  public class Trie
  {
    TrieNode root = new TrieNode();
    /** Initialize your data structure here. */
    public Trie() { }

    /** Inserts a word into the trie. O(m)-rt, O(m)-space,, m - length of the word*/
    public void Insert(string word)
    {
      TrieNode node = root;
      for (int i = 0; i < word.Length; i++)
      {
        // Insert
        if (node.children[word[i] - 'a'] == null)
          node.children[word[i] - 'a'] = new TrieNode();
        // Recurse  
        node = node.children[word[i] - 'a'];
      }
      // All done - a whole word has been inserted
      node.isCompleteWord = true;
    }


    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
      TrieNode node = searchPrefix(word);
      return node != null && node.isCompleteWord;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix)
    {
      TrieNode node = searchPrefix(prefix);
      return node != null;
    }

    // search a prefix or whole key in trie and
    // returns the node where search ends
    private TrieNode searchPrefix(string word)
    {
      TrieNode node = root;
      for (int i = 0; i < word.Length; i++)
      {
        if (node.children[word[i] - 'a'] == null)
          return null;

        node = node.children[word[i] - 'a'];
      }
      return node;
    }


    public class TrieNode
    {
      public bool isCompleteWord;
      // Valid only lowecase latin chars a...z
      public TrieNode[] children = new TrieNode[26];
      public TrieNode() {}
    }
  }
}

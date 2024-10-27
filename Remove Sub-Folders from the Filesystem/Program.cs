
using System.Net.WebSockets;

namespace RemoveSubFoldersFromTheFilesystem
{
  class Trie
  {
    public bool isWord { get; set; } = false;
    public Dictionary<string, Trie> children { get; set; } = [];
    public string Add(string path)
    {
      string[] chars = path.Substring(1).Split("/");
      Trie current = this;
      foreach (var c in chars)
      {
        if (current.isWord) break;
        if (!current.children.ContainsKey(c))
          current.children.Add(c, new Trie());
        current = current.children[c];
      }
      current.isWord = true;
      return path;
    }

    public bool Search(string path)
    {
      string[] chars = path.Substring(1).Split("/");
      Trie current = this;
      System.Console.WriteLine();
      for (var i = 0; i < chars.Length; i++)
      {
        if (!current.children.ContainsKey(chars[i])) return false;
        Trie selectedChild = current.children[chars[i]];
        System.Console.WriteLine(selectedChild.isWord);
        if (selectedChild.isWord && i != chars.Length - 1) return false;
        current = selectedChild;
      }
      return current.isWord;
    }
  }

  class Program
  {
    public static IList<string> RemoveSubfolders(string[] folder)
    {
      var root = new Trie();
      foreach (var f in folder)
      {
        root.Add(f);
      }
      return folder.Where(item => root.Search(item)).ToList();
    }
    static void Main(string[] args)
    {

      System.Console.WriteLine();
      var result = RemoveSubfolders(["/a/b/c", "/a/b",]);
      foreach (var r in result)
      {
        Console.WriteLine(r.Aggregate("", (acc, item) => acc + " " + item));
      }
    }
  }
}


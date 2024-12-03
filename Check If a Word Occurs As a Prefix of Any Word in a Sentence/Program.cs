// See https://aka.ms/new-console-template for more information

namespace Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence;
public class Solution
{
  public static int IsPrefixOfWord(string sentence, string searchWord)
  {
    var arr = sentence.Split(" ");
    for (var i = 0; i < arr.Length; i++)
    {
      var tempReslut = true;
      if (arr[i].Length < searchWord.Length) continue;
      for (var j = 0; j < searchWord.Length; j++)
      {
        if (arr[i][j] != searchWord[j])
        {
          tempReslut = false;
          break;
        }
      }
      if (tempReslut)
        return i + 1;
    }
    return -1;
  }

  public static void Main(string[] args)
  {

  }
}
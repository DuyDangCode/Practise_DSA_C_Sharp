using System.Text;

public class Program
{
  public static string AddSpaces(string s, int[] spaces)
  {
    var sb = new StringBuilder();
    var currentSpaces = 0;
    for (var i = 0; i < s.Length; i++)
    {
      if (currentSpaces < spaces.Length && i == spaces[currentSpaces])
      {
        sb.Append(' ');
        currentSpaces++;
      }
      sb.Append(s[i]);
    }
    return sb.ToString();
  }
  public static void Main(string[] args)
  {
    Console.WriteLine(AddSpaces("LeetcodeHelpsMeLearn", [8, 13, 15]));



  }
}

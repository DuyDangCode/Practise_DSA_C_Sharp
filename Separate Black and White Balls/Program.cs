
namespace Separate_Black_and_White_Balls
{

  public class Solution
  {
    public long MinimumSteps(string s)
    {
      var result = 0L;
      List<char> chars = new(s.ToCharArray());
      int index0 = GetIndexOfLatestZero(chars, chars.Count - 1);
      for (var i = index0 - 1; i >= 0; --i)
      {
        if (chars[i] == '1' && i < index0)
        {
          result += index0 - i;
          chars[i] = '0';
          index0 = GetIndexOfLatestZero(chars, index0 - 1);
        }
      }
      return result;
    }

    public static int GetIndexOfLatestZero(List<char> chars, int start)
    {
      for (var i = start; i >= 0; --i)
      {
        if (chars[i] == '0') { return i; }
      }
      return -1;
    }
    public static void Main(string[] args)
    {

      var s = new Solution();
      var input = "0111";
      long result = s.MinimumSteps(input);
      System.Console.WriteLine(result);


    }
  }
}
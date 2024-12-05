public class Program
{
  public static bool CanChange(string start, string target)
  {
    var index = 0;
    for (var i = 0; i < target.Length; i++)
    {
      if (target[i] == '_')
        continue;
      for (; index < start.Length; index++)
        if (start[index] != '_') break;
      if (index == start.Length) return false;
      if (target[i] != start[index]) return false;
      if (target[i] == 'L' && index < i) return false;
      if (target[i] == 'R' && index > i) return false;
      index++;
    }
    for (; index < start.Length; index++)
      if (start[index] != '_') return false;
    return true;
  }
  public static void Main(string[] args)
  {
    Console.WriteLine(CanChange("_L__R__R_", "L______RR"));
    Console.WriteLine(CanChange("R_L_", "__LR"));
    Console.WriteLine(CanChange("_R", "R_"));


  }
}

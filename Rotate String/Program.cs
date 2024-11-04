namespace Rotate_String
{
    internal class Program
    {
        public static bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length) return false;
            var doubleS = s + s;
            return doubleS.Contains(goal);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(RotateString("abcde", "cdeab"));
        }
    }
}

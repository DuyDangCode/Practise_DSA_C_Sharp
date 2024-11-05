namespace Minimum_Number_of_Changes_to_Make_Binary_String_Beautiful
{
    internal class Program
    {
        public static int MinChanges(string s)
        {
            var count = 0;
            for (var i = 0; i < s.Length - 1; i = i + 2)
                if (s[i] != s[i + 1]) count++;
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

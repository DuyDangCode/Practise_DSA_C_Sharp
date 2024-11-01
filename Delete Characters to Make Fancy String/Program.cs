using System.Text;

namespace Delete_Characters_to_Make_Fancy_String
{
    internal class Program
    {
        public static string MakeFancyString(string s)
        {
            var len = s.Length;
            var temp = new int[len];
            var prevChar = s[0];
            temp[0] = 1;
            var sb = new StringBuilder();
            sb.Append(s[0]);
            for (var i = 1; i < len; i++)
            {
                if (prevChar == s[i])
                    temp[i] = temp[i - 1] + 1;
                else
                    temp[i] = 1;


                if (temp[i] < 3)
                    sb.Append(s[i]);

                prevChar = s[i];
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MakeFancyString("aab"));
        }
    }
}

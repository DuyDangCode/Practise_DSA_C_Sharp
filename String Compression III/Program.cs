using System.Text;

namespace String_Compression_III
{
    internal class Program
    {
        public static string CompressedString(string word)
        {
            var chars = word.ToCharArray();
            var count = 0;
            var prevChar = chars[0];
            var sb = new StringBuilder();
            foreach (var c in chars)
            {
                if (c != prevChar || count == 9)
                {
                    sb.Append(count);
                    sb.Append(prevChar);
                    count = 1;
                }
                else if (c == prevChar)
                {
                    count++;
                }
                prevChar = c;
            }
            sb.Append(count);
            sb.Append(prevChar);
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CompressedString("abcde"));
            Console.WriteLine(CompressedString("aaaaaaaaaaaaaabb"));
        }
    }
}

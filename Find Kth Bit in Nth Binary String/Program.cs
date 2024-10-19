using System.Text;

namespace Find_Kth_Bit_in_Nth_Binary_String
{
    internal class Program
    {
        public static char FindKthBit(int n, int k)
        {
            Dictionary<int, string> cache = new();
            cache.Add(1, "0");
            return GenBitnaryString(n, cache)[k - 1];
        }

        public static string GenBitnaryString(int n, Dictionary<int, string> cache)
        {
            if (cache.ContainsKey(n)) return cache[n];
            if (n == 1) { cache.Add(n, "0"); return cache[n]; }

            string s = GenBitnaryString(n - 1, cache);
            StringBuilder sb = new();
            sb.Append(s);
            sb.Append('1');
            char[] l = s.Reverse().ToArray();
            for (var i = 0; i < l.Length; i++)
            {
                if (l[i] == '1')
                    sb.Append('0');
                else sb.Append('1');
            }
            cache.Add(n, sb.ToString());
            return cache[n];
        }

        static void Main(string[] args)
        {
            Console.WriteLine(FindKthBit(5, 1));
            //Console.WriteLine(FindKthBit(4, 11));
        }
    }
}

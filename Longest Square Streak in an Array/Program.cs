namespace Longest_Square_Streak_in_an_Array
{
    internal class Program
    {
        public static int LongestSquareStreak(int[] arr)
        {
            var result = -1;
            Array.Sort(arr);

            var set = new HashSet<int>(arr);


            for (var i = 0; i < arr.Length; i++)
            {
                long current = arr[i];
                if (!set.Contains(arr[i])) continue;
                var tempResult = 0;

                while (true)
                {
                    long next = current * current;
                    if (next > int.MaxValue || !set.Remove((int)next)) break;
                    tempResult++;
                    current = (int)next;

                }
                if (tempResult * result != 0) result = Math.Max(result, tempResult + 1);
            }

            return result;
        }

        class Item
        {

            public int Value { get; set; }
            public int Index { get; set; }

        }

        static void Main(string[] args)
        {
            Console.WriteLine(LongestSquareStreak([4, 3, 6, 16, 8, 2]));
            Console.WriteLine(LongestSquareStreak([2, 3, 5, 6, 7]));
        }
    }
}

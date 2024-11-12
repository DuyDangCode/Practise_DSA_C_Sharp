namespace Most_Beautiful_Item_for_Each_Query
{
    internal class Program
    {
        public static int[] MaximumBeauty(int[][] items, int[] queries)
        {
            var result = new int[queries.Length];
            items = items.OrderBy(x => x[0]).ToArray();

            var max = 0;

            for (var i = 0; i < items.Length; i++)
            {
                max = Math.Max(max, items[i][1]);
                items[i][1] = max;
            }

            for (var i = 0; i < queries.Length; i++)
            {
                result[i] = FindMax(items, queries[i]);
            }

            return result;
        }

        public static int FindMax(int[][] arr, int n)
        {
            var l = 0;
            var r = arr.Length - 1;
            var max = 0;
            while (l <= r)
            {
                var m = (r + l) / 2;
                if (arr[m][0] > n)
                {
                    r = m - 1;
                }
                else
                {
                    max = Math.Max(max, arr[m][1]);
                    l = m + 1;
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            var result = MaximumBeauty([[1, 2], [3, 2], [2, 4], [5, 6], [3, 5]], [1, 2, 3, 4, 5, 6]);
            for (var i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}

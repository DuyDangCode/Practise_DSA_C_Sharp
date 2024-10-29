namespace Maximum_Number_of_Moves_in_a_Grid
{
    internal class Program
    {
        public static int MaxMoves(int[][] grid)
        {
            var c = grid[0].Length;
            var r = grid.Length;
            var dp = new int[r, c];

            for (var i = c - 2; i >= 0; i--)
            {
                for (var j = 0; j < r; j++)
                {
                    var temp = grid[j][i];

                    int p1 = 0, p2 = 0, p3 = 0;

                    if (j - 1 >= 0)
                        if (temp < grid[j - 1][i + 1])
                            p1 = dp[j - 1, i + 1] + 1;

                    if (j + 1 < r)
                        if (temp < grid[j + 1][i + 1])
                            p2 = dp[j + 1, i + 1] + 1;

                    if (temp < grid[j][i + 1])
                        p3 = dp[j, i + 1] + 1;

                    dp[j, i] = Math.Max(p1, Math.Max(p2, p3));
                    //Console.WriteLine(dp[j, i]);
                }
            }
            int result = 0;
            for (var i = 0; i < r; i++)
                result = Math.Max(result, dp[i, 0]);
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MaxMoves([[2, 4, 3, 5], [5, 4, 9, 3], [3, 4, 2, 11], [10, 9, 13, 15]]));
            Console.WriteLine(MaxMoves([[3, 2, 4], [2, 1, 9], [1, 1, 7]]));
        }
    }
}

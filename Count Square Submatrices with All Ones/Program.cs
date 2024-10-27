namespace Count_Square_Submatrices_with_All_Ones
{
    internal class Program
    {
        public static int CountSquares(int[][] matrix)
        {
            var result = 0;
            var set = new HashSet<(int, int)>();

            if (matrix.Length == 0 || matrix[0].Length == 0) return result;

            var index = 1;

            while (index <= Math.Min(matrix[0].Length, matrix.Length))
            {
                for (var i = 0; i <= matrix.Length - index; i++)
                {
                    for (var j = 0; j <= matrix[0].Length - index; j++)
                    {
                        if (set.Contains((i, j))) continue;
                        var tempResult = true;
                        for (var k = 0; k < index; k++)
                        {
                            for (var kk = 0; kk < index; kk++)
                            {
                                if (matrix[i + k][j + kk] == 0) { tempResult = false; break; }
                            }
                        }
                        if (tempResult) result++;
                        else
                        {
                            set.Add((i, j));
                        }
                    }
                }
                index++;
            }

            return result;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(CountSquares([[1, 1, 0, 0, 1], [1, 0, 1, 1, 1], [1, 1, 1, 1, 1], [1, 0, 1, 0, 1], [0, 0, 1, 0, 1]]));
        }
    }
}
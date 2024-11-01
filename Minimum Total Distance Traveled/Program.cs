namespace Minimum_Total_Distance_Traveled
{
    public class Program
    {
        public static long MinimumTotalDistance(IList<int> robot, int[][] factory)
        {
            robot = [.. robot.OrderBy(x => x)];
            factory = [.. factory.OrderBy(x => x[0])];

            var factoryPositions = new List<int>();

            foreach (var f in factory)
                for (var i = 0; i < f[1]; i++)
                    factoryPositions.Add(f[0]);

            int robotCount = robot.Count;
            int factoryCount = factoryPositions.Count;
            var memo = new long[robotCount, factoryCount];

            return CalculateMinDistance(0, 0, robot, factoryPositions, memo);
        }

        public static long CalculateMinDistance(int robotId, int factoryId, IList<int> robot, List<int> factoryPosition, long[,] memo)
        {
            if (robotId == robot.Count) return 0;
            if (factoryId == factoryPosition.Count) return (long)1e12;
            if (memo[robotId, factoryId] != 0) return memo[robotId, factoryId];
            long assign = Math.Abs(robot[robotId] - factoryPosition[factoryId]) + CalculateMinDistance(
               robotId + 1,
               factoryId + 1,
               robot,
               factoryPosition,
               memo
           );
            long skip = CalculateMinDistance(
                robotId,
                factoryId + 1,
                robot,
                factoryPosition,
                memo
            );

            memo[robotId, factoryId] = Math.Min(assign, skip);
            return memo[robotId, factoryId];
        }

        private static void Main(string[] args)
        {
        }
    }
}
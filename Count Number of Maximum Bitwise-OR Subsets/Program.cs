namespace Count_Number_of_Maximum_Bitwise_OR_Subsets
{
    public class Program
    {
        public static int CountMaxOrSubsets(int[] nums)
        {
            var maxBitwiseOr = nums.Aggregate((a, b) => a | b);
            List<List<int>> allSubarray = GetAllSubArrays(nums);
            int maxSubsetsWithMaxBitwiseOr = allSubarray.Aggregate<List<int>, int, int>(
                0,
                (acc, item) => item.Aggregate((a, b) => a | b) == maxBitwiseOr ? ++acc : acc,
                acc => acc);
            return maxSubsetsWithMaxBitwiseOr;
        }

        static List<List<int>> GetAllSubArrays(int[] array)
        {
            List<List<int>> result = new List<List<int>>();
            int totalSubsets = 1 << array.Length;
            for (int i = 1; i < totalSubsets; i++)
            {
                List<int> subArray = new();
                for (int j = 0; j < array.Length; j++)
                {
                    if ((i & (1 << j)) != 0) subArray.Add(array[j]);

                }
                result.Add(subArray);
            }
            return result;
        }



        static void Main(string[] args)
        {
            Console.WriteLine(CountMaxOrSubsets(new int[] { 3, 2, 1, 5 }));
        }
    }
}

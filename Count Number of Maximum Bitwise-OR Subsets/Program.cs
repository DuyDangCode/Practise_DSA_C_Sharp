namespace Count_Number_of_Maximum_Bitwise_OR_Subsets
{
    public class Program
    {
        public static int CountMaxOrSubsets(int[] nums)
        {
            var maxBitwiseOr = nums.Aggregate((a, b) => a | b);
            var result = 0;
            int totalSubsets = 1 << nums.Length;

            for (int i = 1; i < totalSubsets; i++)
            {
                int currentBitwiseOr = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        currentBitwiseOr |= nums[j];
                        if (currentBitwiseOr == maxBitwiseOr)
                        {
                            result++; break;
                        }
                    };
                }
            }
            return result;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(CountMaxOrSubsets(new int[] { 3, 2, 1, 5 }));
        }
    }
}

namespace Count_the_Number_of_Fair_Pairs
{
    internal class Program
    {
        public static long CountFairPairs(int[] nums, int lower, int upper)
        {

            nums = nums.OrderBy(item => item).ToArray();
            long result = 0L;

            for (var i = 0; i < nums.Length; i++)
            {
                var l = BinarySearch(nums, i + 1, nums.Length - 1, lower - nums[i]);
                var r = BinarySearch(nums, i + 1, nums.Length - 1, upper - nums[i] + 1);
                result += 1 * (r - l);
            }
            return result;
        }
        public static int BinarySearch(int[] nums, int l, int r, int target)
        {
            while (l <= r)
            {
                var m = (l + r) / 2;

                if (nums[m] >= target)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l;
        }



        static void Main(string[] args)
        {
            Console.WriteLine(CountFairPairs([0, 1, 7, 4, 4, 5], 3, 6));
        }
    }
}

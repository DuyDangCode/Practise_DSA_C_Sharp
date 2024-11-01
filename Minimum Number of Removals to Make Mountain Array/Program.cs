namespace Minimum_Number_of_Removals_to_Make_Mountain_Array
{
    internal class Program
    {

        public static int MinimumMountainRemovals(int[] nums)
        {

            var len = nums.Length;
            var l1 = new int[len];
            var l2 = new int[len];

            for (var i = 0; i < len; i++)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        l1[i] = Math.Max(l1[i], l1[j] + 1);
                    }
                }
            }
            for (var i = len - 1; i >= 0; i--)
            {
                for (var j = i + 1; j < len; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        l2[i] = Math.Max(l2[i], l2[j] + 1);
                    }
                }
            }

            var result = int.MaxValue;
            for (var i = 0; i < len; i++)
            {
                if (l1[i] > 0 && l2[i] > 0)
                {
                    result = Math.Min(result, len - l1[i] - l2[i] - 1);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(MinimumMountainRemovals([1, 2, 3, 4, 4, 3, 2, 1]));
            Console.WriteLine(MinimumMountainRemovals([4, 3, 2, 1, 1, 2, 3, 1]));

        }
    }
}

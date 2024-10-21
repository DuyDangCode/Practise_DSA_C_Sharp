namespace Contains_Duplicate_II
{
    internal class Program
    {
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            for (var i = 0; i < nums.Length - 1; i++)
                for (var j = i + 1; j < i + k + 1 && j < nums.Length; j++)
                    if (nums[i] == nums[j]) return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ContainsNearbyDuplicate([1, 2, 3, 4, 5, 6, 7, 8, 9, 9], 3));
        }
    }
}

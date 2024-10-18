namespace _268._Missing_Number
{
    internal class Program
    {
        public static int MissingNumber(int[] nums)
        {
            var expectedSum = 0;
            var actualSum = 0;
            var value = 1;

            for (var i = 0; i < nums.Length; i++)
            {
                expectedSum += value;
                actualSum += nums[i];
                value++;
            }

            return expectedSum - actualSum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MissingNumber([3, 0, 1]));
        }
    }
}

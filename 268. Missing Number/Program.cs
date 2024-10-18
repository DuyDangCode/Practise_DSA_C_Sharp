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

        public static int MissingNumber2(int[] nums)
        {
            return Enumerable.Range(0, nums.Length).Aggregate(0, (acc, currentItem) => acc ^ (currentItem + 1) ^ nums[currentItem], acc => acc);
        }


        static void Main(string[] args)
        {
            Console.WriteLine(MissingNumber2([3, 0, 1]));
            Console.WriteLine(MissingNumber2([1, 0]));
        }
    }
}

namespace Maximum_Swap
{
    internal class Program
    {
        public static int MaximumSwap(int num)
        {
            int len = num.ToString().Length;
            int result = num;
            List<int> nums = new(len * 2);

            PriorityQueue<int, int> pq = new(new IntMaxCompare());

            while (num > 0)
            {
                var value = num % 10;
                nums.Insert(0, value);
                pq.Enqueue(value, value);
                num /= 10;
            }

            var i = 0;
            while (pq.Count > 0)
            {
                var value = pq.Dequeue();
                if (nums[i] != value && nums[i] < value)
                {
                    int index = nums.LastIndexOf(value);

                    int temp = nums[i];
                    nums[i] = nums[index];
                    nums[index] = temp;

                    break;
                }

                i++;
            }

            string numsString = string.Concat(nums);

            try
            {
                result = int.Parse(numsString);
            }
            catch (Exception e) { }

            return result;
        }

        public class IntMaxCompare : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x > y) return -1;
                if (y > x) return 1;
                return 0;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine(MaximumSwap(222221));

        }
    }
}

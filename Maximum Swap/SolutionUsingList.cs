namespace Maximum_Swap
{
    internal class SolutionUsingList
    {
        public static int MaximumSwap(int num)
        {
            int len = num.ToString().Length;
            int result = num;
            List<int> nums = new(len * 2);
            List<int> nums2 = new(len * 2);


            while (num > 0)
            {
                var value = num % 10;
                nums.Insert(0, value);
                nums2.Add(value);
                num /= 10;
            }

            var i = 0;
            nums2.Sort((a, b) => b.CompareTo(a));

            while (i < len)
            {
                var value = nums2[i];
                if (nums[i] != value)
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
    }
}

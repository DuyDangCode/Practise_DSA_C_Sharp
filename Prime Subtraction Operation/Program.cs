namespace Prime_Subtraction_Operation
{
    internal class Program
    {

        public static bool PrimeSubOperation(int[] nums)
        {
            HashSet<int> primeNumbers = new HashSet<int>
            {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47,
            53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107,
            109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167,
            173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
            233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283,
            293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359,
            367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431,
            433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491,
            499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571,
            577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641,
            643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709,
            719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787,
            797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859,
            863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
            947, 953, 967, 971, 977, 983, 991, 997
            };

            nums[0] = nums[0] - LargestPrime(nums[0], primeNumbers);
            Console.WriteLine(nums[0]);
            for (var i = 1; i < nums.Length; i++)
            {
                var temp = false;
                if (nums[i] > nums[i - 1]) temp = true;
                var prime = nums[i];
                while (prime > 1 && nums[i] - prime <= nums[i - 1])
                {
                    prime = LargestPrime(prime, primeNumbers);
                }
                if (temp && prime < 2) continue;
                if (prime < 2) return false;
                nums[i] = nums[i] - prime;

            }
            return true;
        }
        public static int LargestPrime(int n, HashSet<int> primes)
        {
            while (n > 1)
            {
                n--;
                if (primes.Contains(n)) return n;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PrimeSubOperation([8, 19, 3, 4, 9]));
        }
    }
}

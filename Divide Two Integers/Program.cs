namespace Divide_Two_Integers
{
    internal class Program
    {
        public static int Divide(int dividend, int divisor)
        {

            if (divisor == 1) return dividend;
            if (divisor == -1)
            {
                if (dividend == int.MinValue) return int.MaxValue;
                return -dividend;
            }
            long dividendLong = dividend;
            long divisorLong = divisor;

            bool isPositive = (dividendLong > 0 && divisorLong > 0) || (dividendLong < 0 && divisorLong < 0);

            if (dividendLong < 0) dividendLong = -dividendLong;
            if (divisorLong < 0) divisorLong = -divisorLong;

            if (divisorLong > dividendLong) return 0;
            if (dividendLong < divisorLong + divisorLong) return isPositive ? 1 : -1;


            long result = 0;
            while (dividendLong >= divisorLong)
            {
                long temp = divisorLong;
                long mutiple = 1;


                while (dividendLong >= temp + temp)
                {
                    temp += temp;
                    mutiple += mutiple;
                }
                dividendLong -= temp;
                result += mutiple;
            }

            if (!isPositive) result = -result;
            if (result > int.MaxValue) return int.MaxValue;
            if (result < int.MinValue) return int.MinValue;
            return (int)result;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Divide(10, 3));
        }
    }
}

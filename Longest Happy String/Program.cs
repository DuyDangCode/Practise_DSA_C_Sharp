using System.Text;

internal class Program
{
    public static string LongestDiverseString(int a, int b, int c)
    {

        int max = Math.Max(a, Math.Max(b, c));
        StringBuilder sb = new();

        if (max == a)
        {

            var r = a - b - c;
            if (r >= 0)
            {
                while (b > 0)
                {
                    sb.Append('a');
                    sb.Append('b');
                    b--;
                }
                while (c > 0)
                {
                    sb.Append('a');
                    sb.Append('c');
                    c--;
                }
                for (var i = 0; i < sb.Length && r > 0; i++)
                {

                    if (sb[i] == 'a')
                    {
                        sb.Insert(i + 1, 'a');
                        i++;
                        r--;
                    }
                }
                if (r > 0)
                {
                    if (r >= 2)
                    {
                        sb.Append("aa");
                    }
                    else
                    {
                        sb.Append("a");
                    }
                }
            }
            else
            {

                r = a - Math.Max(b, c);
                while (true)
                {
                    if (b <= 0 && c <= 0)
                    {
                        break;
                    }
                    sb.Append('a');

                    if (b > 0)
                    {
                        sb.Append('b');
                        b--;
                    }

                    if (c > 0)
                    {
                        sb.Append('c');
                        c--;
                    }
                }

                for (var i = 0; i < sb.Length && r > 0; i++)
                {
                    if (sb[i] == 'a')
                    {
                        sb.Insert(i + 1, 'a');
                        i++;
                        r--;
                    }
                }
                if (r > 0)
                {
                    if (r >= 2)
                    {
                        sb.Append("aa");
                    }
                    else
                    {
                        sb.Append("a");
                    }
                }
            }

        }
        else if (max == b)
        {

            var r = b - a - c;
            if (r >= 0)
            {
                while (a > 0)
                {
                    sb.Append('b');
                    sb.Append('a');
                    a--;
                }
                while (c > 0)
                {
                    sb.Append('b');
                    sb.Append('c');
                    c--;
                }
                for (var i = 0; i < sb.Length && r > 0; i++)
                {
                    if (sb[i] == 'b')
                    {
                        sb.Insert(i + 1, 'b');
                        i++;
                        r--;
                    }
                }
                if (r > 0)
                {
                    if (r >= 2)
                    {
                        sb.Append("bb");
                    }
                    else
                    {
                        sb.Append("b");
                    }
                }
            }
            else
            {

                r = b - Math.Max(a, c);
                while (true)
                {
                    if (a <= 0 && c <= 0)
                    {
                        break;
                    }
                    sb.Append('b');

                    if (a > 0)
                    {
                        sb.Append('a');
                        a--;
                    }

                    if (c > 0)
                    {
                        sb.Append('c');
                        c--;
                    }
                }

                for (var i = 0; i < sb.Length && r > 0; i++)
                {
                    if (sb[i] == 'b')
                    {
                        sb.Insert(i + 1, 'b');
                        i++;
                        r--;
                    }
                }
                if (r > 0)
                {
                    if (r >= 2)
                    {
                        sb.Append("bb");
                    }
                    else
                    {
                        sb.Append("b");
                    }
                }
            }

        }
        else if (max == c)
        {

            var r = c - a - b;
            if (r >= 0)
            {
                while (a > 0)
                {
                    sb.Append('c');
                    sb.Append('a');
                    a--;
                }
                while (b > 0)
                {
                    sb.Append('c');
                    sb.Append('b');
                    b--;
                }
                for (var i = 0; i < sb.Length && r > 0; i++)
                {
                    if (sb[i] == 'c')
                    {
                        sb.Insert(i + 1, 'c');
                        i++;
                        r--;
                    }
                }
                if (r > 0)
                {
                    if (r >= 2)
                    {
                        sb.Append("cc");
                    }
                    else
                    {
                        sb.Append("c");
                    }
                }
            }
            else
            {

                r = c - Math.Max(a, b);
                while (true)
                {
                    if (a <= 0 && b <= 0)
                    {
                        break;
                    }
                    sb.Append('c');

                    if (a > 0)
                    {
                        sb.Append('a');
                        a--;
                    }

                    if (b > 0)
                    {
                        sb.Append('b');
                        b--;
                    }
                }

                for (var i = 0; i < sb.Length && r > 0; i++)
                {
                    if (sb[i] == 'c')
                    {
                        sb.Insert(i + 1, 'c');
                        i++;
                        r--;
                    }
                }
                if (r > 0)
                {
                    if (r >= 2)
                    {
                        sb.Append("cc");
                    }
                    else
                    {
                        sb.Append("c");
                    }
                }
            }

        }



        return sb.ToString();
    }
    public static void Main(string[] args)
    {
        //Console.WriteLine(LongestDiverseString(15, 2, 2));
        Console.WriteLine(LongestDiverseString(9, 5, 5));
        Console.WriteLine(LongestDiverseString(5, 9, 5));
        Console.WriteLine(LongestDiverseString(5, 5, 9));
    }
}
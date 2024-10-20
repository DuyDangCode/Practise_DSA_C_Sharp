namespace Parsing_A_Boolean_Expression
{
    internal class Program
    {
        public static bool ParseBoolExpr(string expression)
        {

            Stack<char> chars = new();
            for (var i = 0; i < expression.Length; i++)
            {
                if (expression[i] != ')')
                    chars.Push(expression[i]);
                else
                {
                    List<char> temp = new();
                    while (true)
                    {
                        char c = chars.Pop();
                        if (c == '(') break;
                        if (c != ',')
                            temp.Add(c);
                    }
                    var tempResult = false;
                    switch (chars.Pop())
                    {
                        case '|':
                            tempResult = HandleOr(temp);
                            break;
                        case '&':
                            tempResult = HandleAnd(temp);
                            break;
                        case '!':
                            tempResult = HandleNot(temp);
                            break;
                    }
                    if (tempResult) chars.Push('t');
                    else chars.Push('f');
                }
            }

            return chars.Pop() == 't';
        }

        public static bool HandleAnd(List<char> chars)
        {
            return chars.All(c => c == 't');
        }

        public static bool HandleOr(List<char> chars)
        {
            return chars.Any(c => c == 't');
        }

        public static bool HandleNot(List<char> chars) => chars.Last() != 't';

        static void Main(string[] args)
        {
            ParseBoolExpr("|(&(t,f,t),!(t))");
        }
    }
}

namespace Parsing_A_Boolean_Expression
{
    internal class Program
    {
        public static bool ParseBoolExpr(string expression)
        {

            Stack<char> chars = new();
            Stack<char> operators = new();
            for (var i = 0; i < expression.Length; i++)
            {
                if (expression[i] != ')')
                {
                    if (expression[i] == '|' || expression[i] == '&' || expression[i] == '!')
                        operators.Push(expression[i]);
                    else if (expression[i] != ',')
                    {
                        chars.Push(expression[i]);
                    }
                }
                else
                {
                    char lastOperator = operators.Pop();
                    var temp = chars.Pop() == 't';
                    if (lastOperator == '!') temp = !temp;
                    while (true)
                    {
                        char c = chars.Pop();
                        if (c == '(') break;
                        switch (lastOperator)
                        {
                            case '|':
                                temp |= c == 't';
                                break;
                            case '&':
                                temp &= c == 't';
                                break;
                        }
                    }

                    if (temp) chars.Push('t');
                    else chars.Push('f');
                }
            }
            return chars.Pop() == 't';
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ParseBoolExpr("&(t,t,t)"));
        }
    }
}

namespace Circular_Sentence
{
    internal class Program
    {
        public static bool IsCircularSentence(string sentence)
        {
            string[] words = sentence.Split(' ');
            for (var i = 0; i < words.Length - 1; i++)
            {
                if (words[i][words[i].Length - 1] != words[i + 1][0])
                    return false;

            }

            if (words[0][0] != words[words.Length - 1][words[words.Length - 1].Length - 1])
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

using System.Text;

namespace Split_a_String_Into_the_Max_Number_of_Unique_Substrings
{
    internal class Program
    {
        public static int MaxUniqueSplit(string s)
        {
            List<string>[] substrings = new List<string>[s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                List<string> l = new();
                l.Add(s[i].ToString());
                StringBuilder sb = new();
                sb.Append(s[i]);
                for (var j = i + 1; j < s.Length; j++)
                {
                    sb.Append(s[j]);
                    l.Add(sb.ToString());
                }
                substrings[i] = l;
            }
            HashSet<string> chosenSubstrings = new();
            var index = 0;
            var length = s.Length;
            List<HashSet<string>> allPossibleSolution = new();
            ChooseSubstrings(substrings, chosenSubstrings, index, length, allPossibleSolution);
            return allPossibleSolution.Max(item => item.Count);
        }

        public static bool ChooseSubstrings(List<string>[] allSubstrings, HashSet<string> chosenSubstrings, int index, int length, List<HashSet<string>> allPosibelSolution)
        {
            if (index == length)
            {
                var lengthString = chosenSubstrings.Aggregate(0, (acc, item) => acc + item.Length);
                if (lengthString == length)
                {
                    allPosibelSolution.Add(new HashSet<string>(chosenSubstrings));
                    return true;
                }
                return false;
            }
            else
            {
                for (var i = 0; i < allSubstrings[index].Count; i++)
                {
                    if (chosenSubstrings.Contains(allSubstrings[index][i]))
                    {
                        continue;
                    }
                    chosenSubstrings.Add(allSubstrings[index][i]);
                    ChooseSubstrings(allSubstrings, chosenSubstrings, index + allSubstrings[index][i].Length, length, allPosibelSolution);
                    chosenSubstrings.Remove(allSubstrings[index][i]);
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            //www z f v e d w fv h s ww
            Console.WriteLine(MaxUniqueSplit("ababccc"));
            Console.WriteLine(MaxUniqueSplit("aba"));
            Console.WriteLine(MaxUniqueSplit("aa"));
            Console.WriteLine(MaxUniqueSplit("wwwzfvedwfvhsww"));
        }
    }
}

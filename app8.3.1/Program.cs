using System;

namespace app8._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            Console.WriteLine(LevenshteinDistance(s1,s2));
        }

        public static int LevenshteinDistance(string first, string second)
        {
            var opt = new int[first.Length + 1, second.Length + 1];
            for (var i = 0; i <= first.Length; ++i) opt[i, 0] = i;
            for (var i = 0; i <= second.Length; ++i) opt[0, i] = i;
            for (var i = 1; i <= first.Length; ++i)
                for (var j = 1; j <= second.Length; ++j)
                {
                    if (first[i - 1] == second[j - 1])
                        opt[i, j] = opt[i - 1, j - 1];
                    else
                        opt[i, j] = MinOfThree(opt[i - 1, j], opt[i - 1, j - 1], opt[i, j - 1]) + 1;
                }
            return opt[first.Length, second.Length];
        }

        public static int MinOfThree(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace app3._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var l = int.Parse(input[1]);

            var codes = new Dictionary<char, string>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(new string[]{": "}, StringSplitOptions.None);
                codes.Add(input[0][0], input[1]);
            }
            var code = Console.ReadLine();

            Console.WriteLine(GetTextByCode(code, codes));
        }

        public static string GetTextByCode(string code, Dictionary<char, string> codes)
        {
            var value = "";
            var result = "";
            for (int i = 0; i < code.Length; i++)
            {
                value += code[i];
                if (codes.ContainsValue(value))
                {
                    result += codes.FirstOrDefault(t => t.Value == value).Key;
                    value = "";
                }
            }

            return result;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace app8._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var array = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

            var result = NISequence(array);
            Console.WriteLine(result.Count);
            for (int i = result.Count - 1; i > -1; i--)
            {
                Console.Write("{0} ", result[i]);
            }
        }

        public static List<int> NISequence(int[] array)
        {
            var t = new int[array.Length];
            var r = new int[array.Length];
            var len = -1;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = -1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    t[i] = i;
                    len++;
                    continue;
                }

                if (array[i] > array[t[0]])
                {

                }

            }
        }
    }
}


using System;
using System.Linq;

namespace app8._2._1
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

            Console.WriteLine(GetSequenceQty(array));
        }

        private static int GetSequenceQty(int[] array)
        {
            var path = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                path[i] = 1;

                for (int j = 0; j < i; j++)
                {
                    if (array[i]%array[j] == 0 && path[j] + 1 > path[i])
                        path[i] = path[j] + 1;
                }
            }

            return path.Max();
        }
    }
}

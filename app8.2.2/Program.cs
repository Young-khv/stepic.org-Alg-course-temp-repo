
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
            var result = new List<int>() {array[0]};

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > result[0])
                {
                    result[0] = array[i];
                }
                else if (array[i] <= result[result.Count - 1])
                {
                    result.Add(array[i]);
                }
                else
                {

                }
            }

            return result;
        }
    }
}

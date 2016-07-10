
using System;
using System.Collections;
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
                }
                else if (array[i] <= array[t[len]])
                {
                    r[len + 1] = i;
                    t[i] = len++;
                }
                else if (array[i] > array[t[0]])
                {
                    t[0] = i;
                }
                else
                {
                    SetItemToRightPosition(array, i, r, t, len);
                }

            }
            return null;
        }

        public static void SetItemToRightPosition(int[]array, int index, int[] r, int[] t, int len)
        {
            var idx = GetIndex(array, r, array[index]);
        }

        public static int GetIndex(int[] array,int[]idxs, int item)
        {
            var l = 1;
            var r = array.Length - 1;
            while (l + 1 != r)
            {
                int i = (l + r) / 2;
                if (array[idxs[i]] < item)
                {
                    r = i;
                }
                else
                {
                    l = i;
                }
            }
            if (array[idxs[l]] == item && array[idxs[r]] < item)
                return r + 1;

            return -1;
        }
    }
}

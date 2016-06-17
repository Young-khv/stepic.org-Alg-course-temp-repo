using System;
using System.Linq;

namespace app5._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split()
                                            .Select(int.Parse)
                                            .ToArray();
            long count = 0;
            var result = MergeSort(array, 0, array.Length - 1, ref count);
            Console.Write(count);
        }

        public static int[] MergeSort(int[] a, int l, int r, ref long count)
        {
            if (l < r)
            {
                int m = (l + r)/2;
                return Merge(MergeSort(a, l, m, ref count), MergeSort(a, m + 1, r, ref count), ref count);
            }
            return new []{a[l]};
        }

        public static int[] Merge(int[] a, int[]b, ref long count)
        {
            var result = new int[a.Length + b.Length];
            int i = 0,j = 0;

            for (int k = 0; k < a.Length + b.Length;k++)
            {
                if (i < a.Length && (j == b.Length || a[i] <= b[j]))
                {
                    result[k] = a[i++];
                    continue;
                }
                if (j < b.Length && (i == a.Length || a[i] > b[j]))
                {
                    result[k] = b[j++];
                    count += a.Length - i;
                }
            }

            return result;
        }
    }
}

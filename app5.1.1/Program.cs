
using System;
using System.Linq;

namespace app5._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine();
            input1 = input1.Substring(input1.IndexOf(" "));
            var array = input1.Split()
                                    .Where(t => t != "")
                                    .Select(t => int.Parse(t))
                                    .ToArray();

            var input2 = Console.ReadLine();
            input2 = input2.Substring(input2.IndexOf(" "));
            var items = input2.Split()
                                    .Where(t => t != "")
                                    .Select(t => int.Parse(t))
                                    .ToArray();
            foreach (var item in items)
            {
                var result = BinarySearch(array, item);
                if (result != -1) result++;
                Console.Write("{0} ", result);
            }
        }

        public static int BinarySearch(int[] array, int item)
        {
            int l = 0, r = array.Length - 1, m = 0;

            while (l <= r)
            {
                m = (l + r)/2;
                if (array[m] == item) return m;
                if (array[m] > item) r = m - 1;
                else l = m + 1;
            }
            return -1;
        }
    }
}

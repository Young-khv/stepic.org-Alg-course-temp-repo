using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app8._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split()
                                          .Select(int.Parse)
                                          .ToArray();
            var w = input[0];
            var n = input[1];

            var items = Console.ReadLine().Split()
                                          .Select(int.Parse);

            var itemsList = new List<int>() {0};
            itemsList.AddRange(items);
            Console.WriteLine(Knapsack(w, itemsList));

        }

        public static int Knapsack(int W, List<int> items)
        {
            var D = new int[W + 1, items.Count+1];
            for (int i = 0; i <= W; i++) D[i, 0] = 0;
            for (int i = 0; i <= items.Count; i++) D[0, i] = 0;

            for (int i=1;i<items.Count;i++)
                for (int w = 1; w <= W; w++)
                {
                    D[w, i] = D[w, i - 1];
                    if (items[i] <= w)
                    {
                        D[w, i] = Math.Max(D[w, i], D[w - items[i],i-1] + items[i]);
                    }
                }

            return D[W, items.Count-1];
        }
    }
}

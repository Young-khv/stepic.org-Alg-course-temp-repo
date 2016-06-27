using System;
using System.Linq;

namespace app5._8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var input = Console.ReadLine().Split()
                                                .Select(int.Parse)
                                                .ToList();
           var result = input
                            .Distinct()
                            .Select(t => new
                            {
                                item = t, count = input.Count(x => x == t)
                            })
                            .OrderBy(t => t.item)
                            .ToList();
            foreach (var r in result)
            {
                for (int i = 0; i < r.count; i++)
                {
                    Console.Write("{0} ", r.item);
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace app5._5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var linesCount = input[0];
            var pointCount = input[1];
            var points = new List<Item>();
            for (int i = 0; i < linesCount; i++)
            {
                var lInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                points.Add(new Item { X = lInfo[0], State = PointState.Start});
                points.Add(new Item { X = lInfo[1], State = PointState.End });
            }

            var pArray = Console.ReadLine().Split()
                                                    .Select(t => new Item {X = int.Parse(t), State = PointState.Working})
                                                    .ToArray();
            points.AddRange(pArray);
            var result = new Dictionary<int, int>();
            int count = 0; 
            
            foreach (var p in points.OrderBy(t => t.X).ThenBy(t => t.State))
            {
                if (p.State == PointState.Start)
                    count++;

                if(p.State == PointState.Working)
                    if(!result.ContainsKey(p.X))
                        result.Add(p.X, count);

                if (p.State == PointState.End)
                    count--;
            }

            foreach (var p in pArray)
            {
                Console.Write("{0} ", result[p.X]);
            }
        }

        public enum PointState
        {
            Start,
            Working,
            End
        }

        public class Item
        {
            public int X { get; set; }

            public PointState State { get; set; }
        }
    }
}

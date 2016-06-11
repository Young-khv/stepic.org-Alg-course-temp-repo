using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var nodesList = input
                            .ToCharArray()
                            .Distinct()
                            .Select(t => new Node()
                            {
                                Letter = t,
                                Frequency = input.Count(x => x == t),
                                IsLetter = true
                            })
                            .OrderBy(t => t.Frequency)
                            .ToList();

            var nodes = new Queue<Node>(nodesList);
            
            var count = nodes.Count;
            for (int i = 0;i< count - 1; i++)
            {
                var left = nodes.Min();
                nodes.Dequeue();
                var right = nodes.Min();
                nodes.Dequeue();

                nodes.Enqueue(new Node()
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right,
                    IsLetter = false
                });
            }
        }

        public class PQueue<T> where T : IComparable
        {

            private PQueue(List<T> list)
            {

            }
        }

        public class PQueueItem<T> where T : IComparable
        {
            public PQueue<T> Parent { get; set; }
            public PQueue<T> Child { get; set; }
            public T Item { get; set; }
        }

        public class Node : IComparable
        {
            public Node Left { get; set; }
            public Node Right { get; set; }

            public char Letter { get; set; }
            public int Frequency { get; set; }

            public bool IsLetter { get; set; }
            public bool IfLeaf => Left == null & Right == null;
            public int CompareTo(object obj)
            {
                var node = (Node) obj;
                return IsLetter.CompareTo(node.IsLetter);
            }
        }
    }
}

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
            var nodes = input
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

            //TODO: puch isNotLetter nodes into right everytime
            var count = nodes.Count;
            for (int i = 0;i< count - 1; i++)
            {
                var left = nodes.Min();
                nodes.Remove(left);
                var right = nodes.Min();
                nodes.Remove(right);

                nodes.Add(new Node()
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right,
                    IsLetter = false
                });
            }
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
                var comp = Frequency.CompareTo(node.Frequency);
                if (comp == 0)
                {
                    return IsLetter.CompareTo(node.IsLetter);
                }
                else
                {
                    return comp;
                }
            }
        }
    }
}

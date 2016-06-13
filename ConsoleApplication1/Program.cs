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

            var nodes = new PQueue<Node>(nodesList);

            var count = nodes.Count;
            for (int i = 0; i < count - 1; i++)
            {
                var left = nodes.Dequeue();
                var right = nodes.Dequeue();
               
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
            private PQueueItem<T> _startItem;
            private int _count = 0;
            public int Count
            {
                get { return _count; }
            }

            public PQueue()
            {
            }

            public PQueue(List<T> list)
            {
                _startItem = new PQueueItem<T>() {Item = list.First(), Parent = null};
                var currentItem = _startItem;
                _count++;
                for (int i = 1; i < list.Count; i++)
                {
                    currentItem.Child = new PQueueItem<T>() { Item = list[i], Parent = currentItem};
                    currentItem = currentItem.Child;
                    _count++;
                }
            }

            public void Enqueue(T item)
            {
                _count++;
                var stepItem = _startItem;
                var newItem = new PQueueItem<T>() {Item = item};
                if (_startItem == null)
                {
                    _startItem = newItem;
                    return;
                }

                while (stepItem.Child != null)
                {
                    if (item.CompareTo(stepItem.Item) <=0)
                    {
                        if (stepItem.Parent == null) // first element
                        {
                            newItem.Child = stepItem;
                            newItem.Parent = null; 
                            _startItem = newItem;
                            stepItem.Parent = newItem;
                        }
                        else // midle element
                        {
                            newItem.Child = stepItem;
                            newItem.Parent = stepItem.Parent;
                            stepItem.Parent.Child = newItem;
                            stepItem.Parent = newItem;
                        }
                        return;
                    }
                    stepItem = stepItem.Child;
                }

                //last element
                newItem.Parent = stepItem;
                stepItem.Child = newItem;
            }

            public T Dequeue()
            {
                if (_startItem != null)
                {
                    _count--;
                    var result = _startItem.Item;
                    _startItem = _startItem.Child;
                    _startItem.Parent = null;
                    return result;
                }
                return default(T);
            }

            public List<T> ToList()
            {
                var result = new List<T>();
                var stepItem = _startItem;
                result.Add(stepItem.Item);
                while (stepItem.Child != null)
                {
                    result.Add(stepItem.Child.Item);
                    stepItem = stepItem.Child;
                }

                return result;
            }
        }

        public class PQueueItem<T> where T : IComparable
        {
            public PQueueItem<T> Parent { get; set; }
            public PQueueItem<T> Child { get; set; }
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
                return Frequency.CompareTo(node.Frequency);
            }
        }
    }
}

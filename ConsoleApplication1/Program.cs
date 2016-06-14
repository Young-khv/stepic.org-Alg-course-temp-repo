using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input != null)
            {
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
                var codes = new Dictionary<char, string>();
            
                if (nodesList.Count == 1)
                {
                    codes.Add(nodesList.First().Letter, "0");
                }
                else
                {

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

                    var tree = nodes.Dequeue();
                    codes = GetDictionaryFromTree(tree);
                }
               
                var n = codes.Count;
                var output = GetOutput(codes, input);

                Console.WriteLine(n + " " + output.Length);
                foreach (var c in codes)
                {
                    Console.WriteLine($"{c.Key}: {c.Value}");
                }
                Console.WriteLine(output);
            }
        }

        public static string GetOutput(Dictionary<char, string> codes, string input)
        {
            var sb = new StringBuilder();
            foreach (var c in input.ToCharArray())
            {
                sb.Append(codes[c]);
            }

            return sb.ToString();
        }

        public static Dictionary<char, string> GetDictionaryFromTree(Node tree)
        {
            var stack = new Stack<NodeInfo>();
            var result = new Dictionary<char, string>();
            stack.Push(new NodeInfo(tree) {Code = new List<bool>()});
            while (stack.Count != 0)
            {
                var item = stack.Pop();
                if (!item.Node.IfLeaf)
                {
                    stack.Push(new NodeInfo(item.Node.Right) {Code = new List<bool>(item.Code) {true}});

                    stack.Push(new NodeInfo(item.Node.Left) {Code = new List<bool>(item.Code) {false}});
                }
                else
                {
                    var codeString = item.Code.Aggregate("", (current, c) => current + Convert.ToInt32(c).ToString());
                    result.Add(item.Node.Letter,codeString);
                }
            }

            return result;
        }

        public class PQueue<T> where T : IComparable
        {
            private PQueueItem<T> _startItem;
            private int _count = 0;
            public int Count => _count;

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
                var temp = _startItem;
                var newItem = new PQueueItem<T>() {Item = item};
                if (_startItem == null)
                {
                    _startItem = newItem;
                    return;
                }

                while (stepItem != null)
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
                    temp = stepItem;
                    stepItem = stepItem.Child;
                }

                //last element
                newItem.Parent = temp;
                temp.Child = newItem;
            }

            public T Dequeue()
            {
                if (_startItem != null)
                {
                    _count--;
                    var result = _startItem.Item;
                    _startItem = _startItem.Child;
                    if (_startItem != null) _startItem.Parent = null;
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

        public class NodeInfo
        {
            public Node Node { get; set; }
            public List<bool> Code { get; set; }

            public NodeInfo(Node node)
            {
                Node = node;
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
                return Frequency.CompareTo(node.Frequency);
            }
        }
    }
}

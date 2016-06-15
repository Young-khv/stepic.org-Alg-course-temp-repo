
using System;
using System.Collections;
using System.Collections.Generic;

namespace app3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mh = new MaxHeap();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if(input[0] == 'I')
                    mh.Add(int.Parse(input.Split()[1]));
                else
                    Console.WriteLine(mh.ExtractMax());
            }
        }

        public class MaxHeap : IEnumerable
        {
            private List<int> _items;
            private int _index;
            public int Count => _items.Count - 1;

            private enum ChildrenState
            {
                HasBoth,
                HasLeft,
                None
            }

            public MaxHeap(int n = 4)
            {
                _items = new List<int>(n);
                _items.Add(int.MinValue); // stub item for working with indexes started from 1
                _index = 1;
            }

            public void Add(int item)
            {
                _items.Add(item);
                _index++;
                HeapifyUp(_index-1);
            }

            public void Remove(int index)
            {
                _items[index] = Int32.MaxValue;
                HeapifyUp(index);
                ExtractMax();
            }

            public int ExtractMax()
            {
                var result = _items[1];
                _items[1] = _items[_index - 1];
                _index--;
                _items.RemoveAt(_index);
                HeapifyDown(1);
                
                return result;
            }

            private void HeapifyUp(int index)
            {
                var parentIndex = index/2;
                if(parentIndex < 1)
                    return;

                if (_items[parentIndex] < _items[index])
                {
                    SwitchItems(parentIndex, index);
                    HeapifyUp(parentIndex);
                }
            }

            private void HeapifyDown(int index)
            {
                var childrenInfo = GetChildrenInfo(index);
                switch (childrenInfo)
                {
                        case ChildrenState.None: return;
                        case ChildrenState.HasLeft:
                            if(_items[index] < _items[index*2])
                                SwitchItems(index, index*2);
                                HeapifyDown(index*2);
                        break;
                    
                        case ChildrenState.HasBoth:
                            var left = _items[index*2];
                            var right = _items[index*2 + 1];
                            if (_items[index] >= left & _items[index] >= right)
                                return;
                            else
                            {
                                if (right > left)
                                {
                                    SwitchItems(index, index * 2 +1);
                                    HeapifyDown(index * 2 +1);
                                }
                                else
                                {
                                    SwitchItems(index, index * 2);
                                    HeapifyDown(index * 2);
                                }
                            }
                        break;
                }
            }

            private ChildrenState GetChildrenInfo(int index)
            {
                if(index * 2 +1 <=Count)
                    return ChildrenState.HasBoth;
                
                if(index * 2 == Count)
                    return ChildrenState.HasLeft;

                return ChildrenState.None;
            }

            private void SwitchItems(int index1, int index2)
            {
                var temp = _items[index1];
                _items[index1] = _items[index2];
                _items[index2] = temp;
            }

            public int GetMin()
            {
                if (Count > 0)
                    return _items[0];

                return default(int);
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator) ((IEnumerable<int>)_items).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}

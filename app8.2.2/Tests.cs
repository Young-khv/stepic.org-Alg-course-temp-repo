using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace app8._2._2
{
    public class Tests
    {
        [Fact]
        public void SomeTest()
        {
            var array = new[] {7, 6, 1, 6, 4, 1, 2, 4, 10, 1 };
            var result = NISequence(array);
            Assert.Equal(result.Count, 6);
        }

        public static List<int> NISequence(int[] array)
        {
            var t = new int[array.Length];
            var r = new int[array.Length];
            var len = -1;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = -1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    t[i] = i;
                    len++;
                }
                else if (array[i] <= array[t[len]])
                {
                    r[i] = t[len++];
                    t[len] = i;
                }
                else if (array[i] > array[t[0]])
                {
                    t[0] = i;
                }
                else
                {
                    SetItemToRightPosition(array, i, r, t, len);
                }

            }

            var result = new List<int>();
            var startIdx = -1;
            var item = array[t[len]];
            
            for (int i = r.Length - 1; i >=0; i--)
            {
                if (array[i] == item)
                {
                    startIdx = i;
                    break;
                }
            }

            if (startIdx == -1)
            {
                result.Add(0);
                return result;
            }

            while (startIdx != -1)
            {
                result.Add(startIdx);
                startIdx = r[startIdx];
            }

            return result;
        }

        public static void SetItemToRightPosition(int[] array, int index, int[] r, int[] t, int len)
        {
            var idx = GetIndex(array, t, array[index], len);
            if (idx == -1)
            {
                var message = new StringBuilder();
                message.Append($"Can't find valuable index for item: {array[index]} in array: {array[t[0]]}");
                for (int i = 1; i < t.Length; i++)
                {
                    if (t[i] == 0) break;
                    message.Append($", {array[t[i]]}");
                }

                throw new Exception(message.ToString());
            }

            t[idx] = index;
            r[index] = t[idx - 1];

        }

        public static int GetIndex(int[] array, int[] idxs, int item, int len)
        {
            if (len + 1 == 2)
                return len;

            var l = 0;
            var r = len;
            while (l + 1 != r)
            {
                int i = (l + r) / 2;
                if (array[idxs[i]] < item)
                {
                    r = i;
                }
                else
                {
                    l = i;
                }
            }
            if (array[idxs[l]] >= item && array[idxs[r]] < item)
                return r;

            return -1;
        }
    }
}

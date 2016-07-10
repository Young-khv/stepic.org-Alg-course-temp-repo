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
            var array = new int[] {7, 6, 6, 6, 6, 6, 5, 5, 5, 4, 4, 3, 2, 1};
            Assert.Equal(7, GetIndex(array,6));
        }

        public int GetIndex(int[] array, int item)
        {
            var l = 1;
            var r = array.Length - 1;
            while (l+1 != r)
            {
                int i = (l + r)/2;
                if (array[i] < item)
                {
                    r = i;
                }
                else
                {
                    l = i;
                }
            }
            if (array[l] == item && array[r] < item)
                return r+1;

            return -1;
        }
    }
}

using Common;
using System;
using System.Collections.Generic;

namespace QuickSort
{
    /// <summary> 
    /// 快速排序是一种有效比较较多的高效排序。它包含了“分而治之”以及“哨兵”的思想。
    /// 原理：从数列中挑选一个数作为“哨兵”，使比它小的放在它的左侧，比它大的放在它的右侧。将要排序是数列递归地分割到
    /// 最小数列，每次都让分割出的数列符合“哨兵”的规则，自然就将数列变得有序。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var arrayForBeingSort = ArrayGenerator.GetRandomNumberList(100, 0, 1000);

            Console.WriteLine($"Before Sort:{string.Join(",", arrayForBeingSort)}");

            Sort(arrayForBeingSort, 0, arrayForBeingSort.Count - 1);

            Console.WriteLine($"After Sort:{string.Join(",", arrayForBeingSort)}");

            Console.ReadKey();
        }

        /// <summary>
        /// 排序方法
        /// </summary>
        /// <param name="data">数组</param>
        /// <param name="low">低位索引</param>
        /// <param name="high">高位索引</param>
        public static void Sort(IList<int> data, int low, int high)
        {
            if (low >= high) return;
            int temp = data[(low + high) / 2];
            int i = low - 1, j = high + 1;
            while (true)
            {
                while (data[++i] < temp) ;
                while (data[--j] > temp) ;
                if (i >= j) break;
                data.Swap(i, j);
            }
            Sort(data, j + 1, high);
            Sort(data, low, i - 1);
        }
    }
}

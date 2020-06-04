using Common;
using System;

/// <summary>
/// 插入排序（Insertion Sort）的算法描述是一种简单直观的排序算法。
/// 它的工作原理是通过构建有序序列，对于未排序数据，在已排序序列中从后向前扫描，找到相应位置并插入。
/// 插入排序在实现上，通常采用in-place排序（即只需用到O(1)的额外空间的排序），
/// 因而在从后向前扫描过程中，需要反复把已排序元素逐步向后挪位，为最新元素提供插入空间。
/// </summary>
namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayForBeingSort = ArrayGenerator.GetRandomNumberList(100, 0, 1000);

            Console.WriteLine($"Before Sort:{string.Join(",", arrayForBeingSort)}");

            Sort(arrayForBeingSort.ToArray());

            Console.WriteLine($"After Sort:{string.Join(",", arrayForBeingSort)}");

            Console.ReadKey();
        }

        private static void Sort(int[] list)
        {
            int min = list[0];
            int temp = 0;
            for (int i = 1; i < list.Length; i++)
            {
                var current = list[i];

                if (current < min)
                {
                    temp = current;
                    current = min;
                    min = temp;
                }
            }
        }
    }
}

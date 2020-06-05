using System;
using System.Linq;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Lambda基础用法
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25

            int[] numbers1 = { 2, 3, 4, 5 };
            var squaredNumbers = numbers1.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            // Output:
            // 4 9 16 25
            #endregion

            #region lambda 表达式和元组
            Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
            var numbers2 = (2, 3, 4);
            var doubledNumbers = doubleThem(numbers2);
            Console.WriteLine($"The set {numbers2} doubled: {doubledNumbers}");
            // Output:
            // The set (2, 3, 4) doubled: (4, 6, 8)

            Func<(int n1, int n2, int n3), (int, int, int)> doubleThem2 = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
            var numbers3 = (2, 3, 4);
            var doubledNumbers2 = doubleThem(numbers3);
            Console.WriteLine($"The set {numbers3} doubled: {doubledNumbers2}");
            #endregion

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyword_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample1.Demonstration();

            Console.ReadKey();
        }
    }

    class Sample1
    {
        internal static void Demonstration()
        {
            List<int> numbers = Enumerable.Range(1, 100).OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            Operation operation = new Operation();
            var data = operation.FindMinMax(numbers);
            Console.WriteLine($"{data.Minimum} is min and {data.Maximum} is max from {String.Join(",", numbers)}");
        }

        class Operation
        {
            internal (int Minimum, int Maximum) FindMinMax(List<int> list)
            {
                int maximum = int.MinValue, minimum = int.MaxValue;
                list.ForEach(n =>
                {
                    minimum = n < minimum ? n : minimum;
                    maximum = n > maximum ? n : maximum;
                });
                return (minimum, maximum);
            }
        }
    }
}

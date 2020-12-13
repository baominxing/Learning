using System;
using System.Threading;

namespace ILProjects
{
    class Program
    {

        static void Main(string[] args)
        {
            var p = "hello" + "world";

            Console.WriteLine(p);

            var p1 = "helloworld";

            Console.WriteLine(p1);

            var str1 = "hello";
            var str2 = "world";

            var p2 = str1 + str2;

            Console.WriteLine(p2);

            int i = 1, j = 2, k = 3;
            string l = "4";

            Console.WriteLine(i + j + k + l);

            string l2 = "4";

            Console.WriteLine(l2 + i + j + k);

            for (int m = 0; m < 10; m++)
            {
                var person = new Person();

                Thread.Sleep(500);

                Console.WriteLine(person.r);
                Console.WriteLine(Person.r2);
            }



            Console.ReadKey();
        }
    }

    class Person
    {
        public const int c = 1;

        public readonly int r = 2;

        public static readonly int r2 = 2;

        public Person()
        {
            r = new Random().Next(1, 1000);
        }

        static Person()
        {
            r2 = new Random().Next(1, 1000);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ILProjects
{
    class Program
    {

        static void Main(string[] args)
        {
            //Sample1.Demonstration();

            Sample2.Demonstration();

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        public static void Demonstration()
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

            Run(ref i, out j);

            var rs = i & j;

            Task.Run(() => { Run2(); });
        }

        public static void Run(ref int p, out int p1)
        {
            p = 1;
            p1 = 1;
        }

        public async static void Run2()
        {
            Console.WriteLine("I am in Run2");

            await Task.Delay(1000);

            Console.WriteLine("I delayed 1000ms");
        }
    }

    public class Sample2
    {
        public static void Demonstration()
        {
            var foo = new Foo();
            new Thread(()=> Foo.TrySomething("1")).Start();
            new Thread(() => Foo.TrySomething("1")).Start();
        }

        class Foo
        {
            private int count = 0;
            public static void TrySomething(string p)
            {
                //count++;

                int localcount = 0;

                localcount++;

                Console.WriteLine(localcount);

                var thread = Thread.CurrentThread;
            }
        }
    }

    class Person
    {
        public const int c = 1;

        public readonly int r = 2;

        public static readonly int r2 = 2;

        public string x { get; set; }

        public decimal y { get; set; }

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

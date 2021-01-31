using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Semaphore
{
    class Program
    {
        static Semaphore _semaphore = new Semaphore(10, 50);
        static int count = 0;
        //[ThreadStatic]
        static int count2 = 0;
        static unsafe void Main(string[] args)
        {
            var awaiter = Task.Delay(1000).GetAwaiter();

            int k = 0;

            var i2 = (IntPtr)(void*)(&k);

            Thread.Yield();

            Thread.SpinWait(0);

            awaiter.OnCompleted(() => { Console.WriteLine("awaiter is completed"); });

            awaiter.GetResult();

            var awaiter2 = Task.Delay(1000).ConfigureAwait(false).GetAwaiter();

            awaiter2.OnCompleted(() => { Console.WriteLine("awaiter is completed"); });

            awaiter2.GetResult();

            Console.WriteLine("现在有100个人在排队上厕所");

            for (int i = 0; i < 100; i++)
            {
                Person person = new Person() { Id = i, Name = $"P{i.ToString().PadLeft(4, '0')}" };

                Task.Run(() =>
                {
                    Console.WriteLine($"{person.Name}进入排队区域:{Thread.CurrentThread.ManagedThreadId}");

                    count2++;

                    Thread.Sleep(1000);

                    Console.WriteLine($"排队区域有{count2}个人");

                    _semaphore.WaitOne();

                    Console.WriteLine($"{person.Name}开始上厕所");

                    count++;

                    Thread.Sleep(1000);

                    Console.WriteLine($"当前厕所有{count}个人");

                    Console.WriteLine($"{person.Name}上完厕所了");

                    _semaphore.Release();

                    Console.WriteLine($"{person.Name}走出厕所了");

                    count--;
                });
            }

            Console.ReadKey();
        }
    }

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

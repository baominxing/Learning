using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_AwaitAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var awaitableObj = new MyAwaitableClass();

            await awaitableObj;

            Console.WriteLine($"Main{Thread.CurrentThread.ManagedThreadId}");

            var name = GetName();

            Console.WriteLine($"主线程执行完毕{Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"name{Thread.CurrentThread.ManagedThreadId}{await name}:{Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();
        }

        private static async Task<string> GetName()
        {
            Console.WriteLine($"进入GetName准备获取name{Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(10000);

            ExecutionContext.SuppressFlow();

            Console.WriteLine($"返回name{Thread.CurrentThread.ManagedThreadId}");

            return "fred";
        }
    }

    public class MyAwaitableClass
    {
        public MyAwaiter GetAwaiter()
        {
            return new MyAwaiter();
        }
    }

    public class MyAwaiter : INotifyCompletion
    {
        public bool IsCompleted
        {
            get { return true; }
        }

        public void OnCompleted(Action continuation)
        {
        }

        public void GetResult()
        {
            Console.WriteLine("111");
        }
    }
}

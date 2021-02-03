using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_AsyncLocal
{
    class Program
    {
        static AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>(_ =>
        {
            Console.WriteLine($"I am in thread {Thread.CurrentThread.ManagedThreadId} I am changed {_.PreviousValue} => {_.CurrentValue} 是否由上下文切换而改变了值{_.ThreadContextChanged}");
        });

        static ThreadLocal<string> _threadLocalString = new ThreadLocal<string>();

        static async Task AsyncMethodA()
        {
            ExecutionContext.SuppressFlow();
            // Start multiple async method calls, with different AsyncLocal values.
            // We also set ThreadLocal values, to demonstrate how the two mechanisms differ.
            //Console.WriteLine($"{DateTime.Now}" + "Entering AsyncMethodA.{0}", Thread.CurrentThread.ManagedThreadId);

            _asyncLocalString.Value = "Value 1";
            _threadLocalString.Value = "Value 1";
            var t1 = AsyncMethodB("Value 1");

            //_asyncLocalString.Value = "Value 2";
            //_threadLocalString.Value = "Value 2";

            var t2 = AsyncMethodB("Value 2");
            // Await both calls

            Console.WriteLine($"{DateTime.Now}" + "=================================================");

            await t1;

            Console.WriteLine($"{DateTime.Now}" + "After t1.{0}", Thread.CurrentThread.ManagedThreadId);

            await t2;

            Console.WriteLine($"{DateTime.Now}" + "After t2.{0}", Thread.CurrentThread.ManagedThreadId);
        }

        static async Task AsyncMethodB(string expectedValue)
        {
            //Console.WriteLine($"{DateTime.Now}" + "Entering AsyncMethodB.{0}", Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine($"{DateTime.Now}" + "Expected '{0}', AsyncLocal value is '{1}', ThreadLocal value is '{2}' {3}", expectedValue, _asyncLocalString.Value, _threadLocalString.Value, Thread.CurrentThread.ManagedThreadId);


            if (expectedValue == "Value 1")
            {
                await Task.Delay(1000);
            }
            else
            {
                await Task.Delay(2000);
            }
            //Console.WriteLine($"{DateTime.Now}" + "Exiting AsyncMethodB.{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine($"{DateTime.Now}" + "Expected '{0}', got '{1}', ThreadLocal value is '{2}'{3}", expectedValue, _asyncLocalString.Value, _threadLocalString.Value, Thread.CurrentThread.ManagedThreadId);
        }

        static async Task Main(string[] args)
        {
            await AsyncMethodA();

            Console.ReadKey();
        }
    }
}

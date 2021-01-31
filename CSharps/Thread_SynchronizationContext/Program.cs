using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_SynchronizationContext
{
    class Program
    {
        static void Main(string[] args)
        {
            SynchronizationContext synchronizationContext = new SynchronizationContext();

            synchronizationContext.Post(async (state) =>
            {
                Console.WriteLine($"synchronizationContext{Thread.CurrentThread.ManagedThreadId}");

                await Task.Delay(10000);

                Console.WriteLine($"synchronizationContext{Thread.CurrentThread.ManagedThreadId}");

            }, new { });

            Console.WriteLine($"Main{Thread.CurrentThread.ManagedThreadId}");


            SemaphoreSlim _semaphore = new SemaphoreSlim(4);

            _semaphore.WaitAsync().ContinueWith((state) => { Console.WriteLine($"SemaphoreSlim{Thread.CurrentThread.ManagedThreadId}"); });

            SynchronizationContext.SetSynchronizationContext(synchronizationContext);

            var cesp = new ConcurrentExclusiveSchedulerPair();
            var cesp2 = new ConcurrentExclusiveSchedulerPair();

            Console.WriteLine(cesp.GetHashCode());
            Console.WriteLine(cesp2.GetHashCode());
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(cesp.GetHashCode());
                Console.WriteLine(cesp2.GetHashCode());
                Console.WriteLine(TaskScheduler.Current.GetHashCode());
                Console.WriteLine(TaskScheduler.Current == cesp.ExclusiveScheduler);
            }, default, TaskCreationOptions.None, cesp2.ExclusiveScheduler)
            .Wait();

            ThreadLocal<Demo> d = new ThreadLocal<Demo>();

            Console.ReadKey();
        }
    }

    public class Demo
    {

    }
}

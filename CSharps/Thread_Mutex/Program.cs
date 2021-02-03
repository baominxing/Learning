using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Mutex
{
    class Program
    {
        // Create a new Mutex. The creating thread does not own the mutex.
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 2;

        static void Main(string[] args)
        {
            try
            {
                //此示例演示如何使用本地 Mutex 对象同步对受保护资源的访问。 由于每个调用线程都将被阻止，直到它获取互斥体的所有权，因此它必须调用 ReleaseMutex 方法以释放互斥体的所有权。
                Sample1.Demonstration();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public class Sample1
        {
            public static void Demonstration()
            {
                // Create the threads that will use the protected resource.
                for (int i = 0; i < numThreads; i++)
                {
                    Thread newThread = new Thread(new ThreadStart(ThreadProc));
                    newThread.Name = String.Format("Thread{0}", i + 1);
                    newThread.Start();

                    Thread.Sleep(2000);
                }
            }
            private static void ThreadProc()
            {
                for (int i = 0; i < numIterations; i++)
                {
                    UseResource();
                }
            }

            // This method represents a resource that must be synchronized
            // so that only one thread at a time can enter.
            private static void UseResource()
            {
                // Wait until it is safe to enter.
                Console.WriteLine("{0} is requesting the mutex",
                                  Thread.CurrentThread.Name);

                //WaitHandle.WaitAll(new WaitHandle[] { mut });
                //WaitHandle.WaitAny(new WaitHandle[] { mut });

                mut.WaitOne();

                Console.WriteLine("{0} has entered the protected area",
                                  Thread.CurrentThread.Name);

                // Place code to access non-reentrant resources here.

                // Simulate some work.
                Thread.Sleep(3000);

                Console.WriteLine("{0} is leaving the protected area",
                    Thread.CurrentThread.Name);

                // Release the Mutex.
                mut.ReleaseMutex();
                Console.WriteLine("{0} has released the mutex",
                    Thread.CurrentThread.Name);
            }
        }
    }
}

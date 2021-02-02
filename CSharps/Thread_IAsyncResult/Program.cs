using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_IAsyncResult
{
    public class AsyncDemo
    {
        //供后台线程执行的方法
        public string TestMethod()
        {
            Console.WriteLine("测试方法开始执行.");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("TestMethod在做一些事情！！！");

                Thread.Sleep(1000);
            }

            return String.Format("测试方法执行的时间");
        }
    }
    public delegate string AsyncMethodCaller();

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主程序开始--------------------");
            int threadId;
            AsyncDemo ad = new AsyncDemo();
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            //caller(3000, out threadId);

            IAsyncResult result = caller.BeginInvoke(_ => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("我完成了{0}", Thread.CurrentThread.ManagedThreadId);

                    Thread.Sleep(1000);
                }

            }, null);

            Thread.Sleep(0);

            Console.WriteLine("主线程线程 {0} 正在运行.", Thread.CurrentThread.ManagedThreadId);

            //会阻塞线程，直到后台线程执行完毕之后，才会往下执行
            result.AsyncWaitHandle.WaitOne();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("主程序在做一些事情！！！");

                Thread.Sleep(1000);
            }

            //获取异步执行的结果
            //string returnValue = caller.EndInvoke(result);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("主程序在做一些事情！！！{0}", Thread.CurrentThread.ManagedThreadId);

                Thread.Sleep(1000);
            }

            //释放资源
            result.AsyncWaitHandle.Close();
            Console.WriteLine("主程序结束--------------------");
            Console.Read();
        }
    }
}

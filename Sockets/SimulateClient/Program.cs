using System;

namespace MDCDataService
{
    public class AsynchronousClient
    {
        public static void Main(String[] args)
        {
            IProcess process = new ActiveProcess();
            process.Run();
            Console.Read();
        }
    }
}
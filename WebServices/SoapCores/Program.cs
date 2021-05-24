using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace SoapCores
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                 .UseKestrel(x => x.AllowSynchronousIO = true)
                 .UseUrls("http://*:5050")
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseStartup<Startup>()
                 .Build();

            host.Run();
        }
    }
}

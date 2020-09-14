using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=192.168.3.180;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True";

            using (var context = new MyDbContext(connectionString))
            {
                var si = context.StateInfos.ToList();

                foreach (var item in si)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                }
            }

            Console.ReadKey();
        }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        public IDbSet<StateInfos> StateInfos { get; set; }
    }
}

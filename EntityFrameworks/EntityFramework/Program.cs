using System.Data.Entity;
using System.Linq.Expressions;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True";

            using (var context = new MyDbContext(connectionString))
            {
                //var si = context.StateInfos.ToList();
                var expression = Expression.Constant(context.StateInfos);
            }
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

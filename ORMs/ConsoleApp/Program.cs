using Dapper;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //比较ADO.NET,Dapper,EF,IQToolkit查询100w+数据的效率比较
            Sample1.Demonstration();

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        static string connectionString = "Data Source=192.168.3.180;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
            var st = DateTime.Now;
            var executeSql = "SELECT * FROM dbo.States";
            var sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            #region Dapper

            for (int i = 0; i < 5; i++)
            {
                st = DateTime.Now;

                var list=sqlConnection.Query<dynamic>(executeSql);

                list = null;

                Console.WriteLine($"Dapper第{i + 1}查询耗时{(DateTime.Now - st).TotalMilliseconds}ms");

                st = DateTime.Now;
            }
            #endregion

            #region ADO.NET
            for (int i = 0; i < 5; i++)
            {
                st = DateTime.Now;

                var sqlCommand = new System.Data.SqlClient.SqlCommand(executeSql, sqlConnection);
                var sqlDa = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
                var SqlDt = new System.Data.DataTable();

                sqlDa.Fill(SqlDt);

                SqlDt.Clear();

                Console.WriteLine($"ADO.NET第{i + 1}查询耗时{(DateTime.Now - st).TotalMilliseconds}ms");

                st = DateTime.Now;
            }
            #endregion

            #region EF
            var context = new MyDbContext(connectionString);

            for (int i = 0; i < 5; i++)
            {
                st = DateTime.Now;

                var si = context.States.AsNoTracking().ToList();

                Console.WriteLine($"EF第{i + 1}查询耗时{(DateTime.Now - st).TotalMilliseconds}ms");

                st = DateTime.Now;
            }
            #endregion
        }

        public class MyDbContext : DbContext
        {
            public MyDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
            {

            }

            public IDbSet<EntityFramework.StateInfos> StateInfos { get; set; }

            public IDbSet<EntityFramework.States> States { get; set; }
        }
    }
}

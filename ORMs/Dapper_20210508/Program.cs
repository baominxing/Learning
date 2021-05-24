using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_20210508
{
    /// <summary>
    /// 该项目用于测试施洛特dmp查询分表功能测试
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=192.168.1.22;Initial Catalog=Schlote;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";

            var partNo = "19100802550101TD01995RXXX";

            using (var conn = new SqlConnection(connectionString))
            {
                var archiveTable = conn.Query<string>($"EXEC [dbo].[sp_GetArchiveTargetTableByPartNo] @PartNo = N'{partNo}'").FirstOrDefault();

                Console.WriteLine(archiveTable);
            }

            Console.WriteLine("输入任何停止");

            Console.ReadKey();
        }
    }
}

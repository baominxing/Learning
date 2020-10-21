using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dappers_20201019
{
    /// <summary>
    /// 该项目用于测试施洛特现场查询语句超时问题
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationSettings.AppSettings["connectionString"];

            Console.WriteLine("验证数据库连接");

            if (!TryConnectionString(connectionString))
            {
                Console.WriteLine("数据库连接不正确");
            }

            Task.Run(() => { TrySelect(connectionString); });

            Console.WriteLine("输入任何停止");

            Console.ReadKey();
        }

        private static void TrySelect(string connectionString)
        {
            int i = 0;

            while (true)
            {
                Thread.Sleep(10000);

                Console.WriteLine($"查询次数{i++}");

                try
                {
                    try
                    {
                        //运行查询语句
                        var executeSql = @"SELECT TOP 1 * FROM TraceFlowRecords WHERE UPPER(FlowCode) IN ('OP05','OP10','OP20','OP30','OP40','OP50','OP60','OP70','OP80','OP90') ORDER BY EntryTime DESC";

                        using (var conn = new SqlConnection(connectionString))
                        {
                            var query = conn.Query<dynamic>(executeSql);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"发生错误，请查看日志");

                        //记录错误信息
                        WriteToText(ex.ToString());
                        //如果发生错误，则记录错误信息，并记录当时数据库的一些状态
                        QueryDeadLock(connectionString);

                        QueryBlock(connectionString);
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }

        }

        private static void QueryBlock(string connectionString)
        {
            WriteToText("查询阻塞情况");

            //运行查询语句
            var executeSql = @"
SELECT wt.blocking_session_id AS BlockingSessesionId,
       sp.program_name AS ProgramName,
       COALESCE(sp.loginame, sp.nt_username) AS HostName,
       ec1.client_net_address AS ClientIpAddress,
       db.name AS DatabaseName,
       wt.wait_type AS WaitType,
       ec1.connect_time AS BlockingStartTime,
       wt.wait_duration_ms / 1000 AS WaitDuration,
       ec1.session_id AS BlockedSessionId,
       h1.text AS BlockedSQLText,
       h2.text AS BlockingSQLText
FROM sys.dm_tran_locks AS tl
    INNER JOIN sys.databases db
        ON db.database_id = tl.resource_database_id
    INNER JOIN sys.dm_os_waiting_tasks AS wt
        ON tl.lock_owner_address = wt.resource_address
    INNER JOIN sys.dm_exec_connections ec1
        ON ec1.session_id = tl.request_session_id
    INNER JOIN sys.dm_exec_connections ec2
        ON ec2.session_id = wt.blocking_session_id
    LEFT OUTER JOIN master.dbo.sysprocesses sp
        ON sp.spid = wt.blocking_session_id
    CROSS APPLY sys.dm_exec_sql_text(ec1.most_recent_sql_handle) AS h1
    CROSS APPLY sys.dm_exec_sql_text(ec2.most_recent_sql_handle) AS h2
";

            using (var conn = new SqlConnection(connectionString))
            {
                var query = conn.Query<dynamic>(executeSql);

                WriteToText(JsonConvert.SerializeObject(query));
            }
        }

        private static void QueryDeadLock(string connectionString)
        {
            WriteToText("查询死锁情况");

            //运行查询语句
            var executeSql = @"
SELECT request_session_id spid,
       OBJECT_NAME(resource_associated_entity_id) tableName
FROM sys.dm_tran_locks
WHERE resource_type = 'OBJECT';
";

            using (var conn = new SqlConnection(connectionString))
            {
                var query = conn.Query<dynamic>(executeSql);

                WriteToText(JsonConvert.SerializeObject(query));
            }
        }

        private static void WriteToText(string v)
        {
            var writeToFileName = $"{DateTime.Now.ToString("yyyyMMdd")}.txt";

            if (!File.Exists(writeToFileName))
            {
                using (File.Create(writeToFileName))
                {

                }
            }

            File.AppendAllText(writeToFileName, $"{DateTime.Now} - {v}");
        }

        private static bool TryConnectionString(string connectionString)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return false;
            }
        }
    }
}

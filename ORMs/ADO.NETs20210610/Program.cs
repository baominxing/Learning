using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NETs20210610
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var maxId = 0;

                var executeSql = $@"
SELECT TOP {1000}
       0 AS Id,
       [Id] AS FEDataId,
       [Datetime],
       [PLDateTime],
       [Name],
       [State],
       [LH],
       [FE1],
       [FE2],
       [FE3],
       [FE4],
       GETDATE() AS [CreationTime],
       0 AS [CreatorUserId]
FROM FEData
WHERE ID > {maxId};
";

                var dt = new DataTable();

                dt.Columns.Add("Id", typeof(long));
                dt.Columns.Add("FEDataId", typeof(long));
                dt.Columns.Add("Datetime", typeof(DateTime));
                dt.Columns.Add("PLDateTime", typeof(DateTime));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("State", typeof(string));
                dt.Columns.Add("LH", typeof(string));
                dt.Columns.Add("FE1", typeof(int));
                dt.Columns.Add("FE2", typeof(int));
                dt.Columns.Add("FE3", typeof(int));
                dt.Columns.Add("FE4", typeof(int));
                dt.Columns.Add("CreationTime", typeof(DateTime));
                dt.Columns.Add("CreatorUserId", typeof(int));

                using (var conn = new SqlConnection("Data Source=192.168.10.85;Initial Catalog=GXZKData;user id=sa;password=123456`;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;"))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    var dc = new SqlCommand(executeSql, conn);

                    var da = new SqlDataAdapter(dc);

                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        Console.WriteLine($"SyncFEDataAsync MaxId:{maxId} 没有需要同步的记录");

                        return;
                    }

                    var tableName = ((TableAttribute)typeof(FEData).GetCustomAttributes(false)[0]).Name;

                    await Task.Run(() => { this.SqlBulkCopy(tableName, dt); });

                    Logger.Info($"SyncFEDataAsync MaxId:{maxId} Count:{dt.Rows.Count}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"SyncFEDataAsync Error:{ex.Message}");
            }
        }

        private void SqlBulkCopy(string destinationTableName, DataTable dt)
        {
            using (var conn = new SqlConnection(AppSettings.Database.ConnectionString))
            {
                conn.Open();
                SqlBulkCopy sbc = new SqlBulkCopy(conn);
                sbc.BulkCopyTimeout = 60;
                sbc.DestinationTableName = destinationTableName;
                sbc.BatchSize = 1000;
                sbc.WriteToServer(dt);
            }
        }
    }
}

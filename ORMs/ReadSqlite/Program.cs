using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            //数据库连接
            //using (var m_dbConnection = new SQLiteConnection(@"Data Source=E:\workspace\projects\上海九士\documents\FriedSPC.SL3;Version=3;"))
            //{
            //    m_dbConnection.Open();

            //    var sql = "select * from 测量数据_程序ID_1";
            //    var command = new SQLiteCommand(sql, m_dbConnection);
            //    var reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Console.WriteLine("Name: " + reader["零件ID"] + "\tScore: " + reader["合格"]);
            //    }

            //    Console.ReadLine();
            //}

            #region 远程读取sqlite3数据库
            try
            {
                var sharedDirectoryManager = new SharedDirectoryManager();

                if (sharedDirectoryManager.ImpersonateValidUser("fred.bao", "192.168.1.21", "123qwe"))
                {
                    using (var conn = new SQLiteConnection(@"Data Source='//product.team/SPC质检数据/豪爵铃木/箱体06线-平面度检测和SPC检测台/FriedSPC.SL3';Version=3;"))
                    {
                        conn.Open();

                        var list = new List<dynamic>();

                        var executeSql = string.Empty;

                        #region 一单元SPC检验-上箱体
                        executeSql = @"
SELECT 孔径UA01 AS HALB_CCU51_28_001,
       孔径UA02 AS HALB_CCU51_28_002,
       孔径UA03 AS HALB_CCU51_28_003,
       孔径UA04 AS HALB_CCU51_28_004,
       孔径UA05 AS HALB_CCU51_28_005,
       孔径UA06 AS HALB_CCU51_28_006,
       孔径UA07 AS HALB_CCU51_28_007,
       用户名称 AS user
  FROM 测量数据_程序ID_7
 WHERE 零件ID = @PartNo
 ORDER BY 日期 DESC
 LIMIT 1
";
                        var parameters = new { PartNo = 1 };

                        var result = conn.Query<dynamic>(executeSql, parameters);

                        foreach (var item in result)
                        {
                            list.Add(new { name = "HALB_CCU51_28_001", value = item.HALB_CCU51_28_001 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_002", value = item.HALB_CCU51_28_002 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_003", value = item.HALB_CCU51_28_003 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_004", value = item.HALB_CCU51_28_004 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_005", value = item.HALB_CCU51_28_005 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_006", value = item.HALB_CCU51_28_006 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_007", value = item.HALB_CCU51_28_007 ?? string.Empty });
                            list.Add(new { name = "user", value = item.user ?? string.Empty });
                        }
                        #endregion

                        #region 一单元SPC检验-下箱体
                        executeSql = @"
SELECT 孔径LA01 AS HALB_CCL51_28_001,
       孔径LA02 AS HALB_CCL51_28_002,
       孔径LA03 AS HALB_CCL51_28_003,
       用户名称 AS user
  FROM 测量数据_程序ID_8
 WHERE 零件ID = @PartNo
 ORDER BY 日期 DESC
 LIMIT 1
";
                        parameters = new { PartNo = 1 };

                        result = conn.Query<dynamic>(executeSql, parameters);

                        foreach (var item in result)
                        {
                            list.Add(new { name = "HALB_CCL51_28_001", value = item.HALB_CCL51_28_001 ?? string.Empty });
                            list.Add(new { name = "HALB_CCL51_28_002", value = item.HALB_CCL51_28_002 ?? string.Empty });
                            list.Add(new { name = "HALB_CCL51_28_003", value = item.HALB_CCL51_28_003 ?? string.Empty });
                            list.Add(new { name = "user", value = item.user ?? string.Empty });
                        }
                        #endregion

                        #region 二单元SPC检验-上箱体
                        executeSql = @"
SELECT 孔径UB20 AS HALB_CCU51_28_008,
       孔径UB21 AS HALB_CCU51_28_009,
       [孔径UB10-1] AS HALB_CCU51_28_010,
       [孔径UB10-2] AS HALB_CCU51_28_011,
       [孔径UB10-3] AS HALB_CCU51_28_012,
       用户名称 AS user
  FROM 测量数据_程序ID_9
 WHERE 零件ID = @PartNo
 ORDER BY 日期 DESC
 LIMIT 1
";

                        parameters = new { PartNo = 1 };

                        result = conn.Query<dynamic>(executeSql, parameters);

                        foreach (var item in result)
                        {
                            list.Add(new { name = "HALB_CCU51_28_008", value = item.HALB_CCU51_28_008 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_009", value = item.HALB_CCU51_28_009 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_010", value = item.HALB_CCU51_28_010 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_011", value = item.HALB_CCU51_28_011 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_012", value = item.HALB_CCU51_28_012 ?? string.Empty });
                            list.Add(new { name = "user", value = item.user ?? string.Empty });
                        }
                        #endregion

                        #region 三单元SPC检验
                        executeSql = @"
SELECT [孔径05-磁] HALB_CC51_28_001,
       [小孔径05-离] HALB_CC51_28_002,
       [大孔径05-离] HALB_CC51_28_003,
       孔径06 HALB_CC51_28_004,
       孔径07 HALB_CC51_28_005,
       [孔径08-磁] HALB_CC51_28_006,
       [孔径08-离] HALB_CC51_28_007,
       孔径09 HALB_CC51_28_008,
       孔径010 HALB_CC51_28_009,
       [大孔径LC12-磁] HALB_CC51_28_010,
       [小孔径LC12-磁] HALB_CC51_28_011,
       [孔径LC12-离] HALB_CC51_28_012,
       孔径UC20 HALB_CC51_28_013,
       孔径UC21 HALB_CC51_28_014,
       孔径UC22 HALB_CC51_28_015,
       孔径UC23 HALB_CC51_28_016,
       孔径LC35 HALB_CC51_28_017,
       孔径LC36 HALB_CC51_28_018,
       用户名称 AS user
  FROM 测量数据_程序ID_10
 WHERE 零件ID = @PartNo
 ORDER BY 日期 DESC
 LIMIT 1;
";
                        parameters = new { PartNo = 1 };

                        result = conn.Query<dynamic>(executeSql, parameters);

                        foreach (var item in result)
                        {
                            list.Add(new { name = "HALB_CC51_28_001", value = item.HALB_CC51_28_001 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_002", value = item.HALB_CC51_28_002 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_003", value = item.HALB_CC51_28_003 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_004", value = item.HALB_CC51_28_004 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_005", value = item.HALB_CC51_28_005 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_006", value = item.HALB_CC51_28_006 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_007", value = item.HALB_CC51_28_007 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_008", value = item.HALB_CC51_28_008 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_009", value = item.HALB_CC51_28_009 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_010", value = item.HALB_CC51_28_010 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_011", value = item.HALB_CC51_28_011 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_012", value = item.HALB_CC51_28_012 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_013", value = item.HALB_CC51_28_013 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_014", value = item.HALB_CC51_28_014 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_015", value = item.HALB_CC51_28_015 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_016", value = item.HALB_CC51_28_016 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_017", value = item.HALB_CC51_28_017 ?? string.Empty });
                            list.Add(new { name = "HALB_CC51_28_018", value = item.HALB_CC51_28_018 ?? string.Empty });
                            list.Add(new { name = "user", value = item.user ?? string.Empty });
                        }
                        #endregion

                        #region 平面度检测-上箱体
                        executeSql = @"
SELECT 合格 HALB_CCU51_28_117,
       平面度 HALB_CCU51_28_118,
       用户名称 AS user
 FROM 测量数据_程序ID_1
 WHERE 零件ID = @PartNo
 ORDER BY 日期 DESC
 LIMIT 1;
";
                        parameters = new { PartNo = 1 };

                        result = conn.Query<dynamic>(executeSql, parameters);

                        foreach (var item in result)
                        {
                            list.Add(new { name = "HALB_CCU51_28_117", value = item.HALB_CCU51_28_117 ?? string.Empty });
                            list.Add(new { name = "HALB_CCU51_28_118", value = item.HALB_CCU51_28_118 ?? string.Empty });
                            list.Add(new { name = "user", value = item.user ?? string.Empty });
                        }
                        #endregion

                        #region 平面度检测-下箱体
                        executeSql = @"
SELECT 合格 HALB_CCL51_28_098,
       平面度 HALB_CCL51_28_099,
       用户名称 AS user
 FROM 测量数据_程序ID_2
 WHERE 零件ID = @PartNo
 ORDER BY 日期 DESC
 LIMIT 1;
";
                        parameters = new { PartNo = 1 };

                        result = conn.Query<dynamic>(executeSql, parameters);

                        foreach (var item in result)
                        {
                            list.Add(new { name = "HALB_CCL51_28_098", value = item.HALB_CCL51_28_098 ?? string.Empty });
                            list.Add(new { name = "HALB_CCL51_28_099", value = item.HALB_CCL51_28_099 ?? string.Empty });
                            list.Add(new { name = "user", value = item.user ?? string.Empty });
                        }
                        #endregion

                        Console.ReadLine();
                    }
                }
                else
                {
                    throw new Exception("登录远程服务器失败");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            Console.ReadKey();
        }
    }
}

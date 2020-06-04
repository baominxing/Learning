using Dapper;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using UnitOfWorkStudy_1.Entities;
using UnitOfWorkStudy_1.Repositories;

namespace UnitOfWorkStudy_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True";

            DbConnectionFactory.Instance.Init(connectionString);

            #region Dapper Repository
            Console.WriteLine("Dapper查询500000条记录");

            using (var conn = DbConnectionFactory.Instance.GetConnection())
            {
                var executesql = @"
SELECT TOP 500000 *
  FROM [FSJC_Online].[dbo].[States]

";
                var st = DateTime.Now;
                var list = conn.Query<States>(executesql).ToList();
                var expression = Expression.Constant(list);
                var et = DateTime.Now;

                Console.WriteLine((et - st).TotalMilliseconds);
            }

            using (var conn = DbConnectionFactory.Instance.GetConnection())
            {
                var executesql = @"
SELECT TOP 500000 [Id]
      ,[MachineId]
      ,[MachineCode]
      ,[Code]
      ,[Name]
      ,[StartTime]
      ,[EndTime]
      ,[Duration]
      ,[Memo]
      ,[UserId]
      ,[UserShiftDetailId]
      ,[MachinesShiftDetailId]
      ,[OrderId]
      ,[ProcessId]
      ,[PartNo]
      ,[DateKey]
      ,[ProgramName]
      ,[ShiftDetail_SolutionName]
      ,[ShiftDetail_StaffShiftName]
      ,[ShiftDetail_MachineShiftName]
      ,[ShiftDetail_ShiftDay]
      ,[ProductId]
      ,[IsShiftSplit]
      ,[LastModificationTime]
      ,[CreationTime]
      ,[MongoCreationTime]
  FROM [FSJC_Online].[dbo].[States]

";
                var st = DateTime.Now;
                var list = conn.Query<States>(executesql).ToList();
                var et = DateTime.Now;

                Console.WriteLine((et - st).TotalMilliseconds);
            }
            #endregion


            Console.Read();
        }
    }
}

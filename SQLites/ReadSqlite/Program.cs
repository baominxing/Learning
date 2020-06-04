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
            using (var m_dbConnection = new SQLiteConnection(@"Data Source=E:\workspace\projects\上海九士\documents\FriedSPC.SL3;Version=3;"))
            {
                m_dbConnection.Open();

                var sql = "select * from 测量数据_程序ID_1";
                var command = new SQLiteCommand(sql, m_dbConnection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name: " + reader["零件ID"] + "\tScore: " + reader["合格"]);
                }

                Console.ReadLine();
            }

        }
    }
}

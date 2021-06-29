using Microsoft.Data.Sqlite;
using System;

namespace SQLiteCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var m_dbConnection = new SqliteConnection(@"Data Source=E:\workspace\projects\广州惠挺和项目\codes\dmp-handler-core\DMP\Data.db"))
            {
                m_dbConnection.Open();

                var sql = "select * from Configs";
                var command = new SqliteCommand(sql, m_dbConnection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name: " + reader["Key"] + "\tScore: " + reader["Value"]);
                }

                Console.ReadLine();
            }
        }
    }
}

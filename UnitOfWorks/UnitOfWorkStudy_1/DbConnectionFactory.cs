using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UnitOfWorkStudy_1
{
    public class DbConnectionFactory
    {

        private static readonly DbConnectionFactory instance = new DbConnectionFactory();

        private SqlConnectionStringBuilder builder { get; set; }

        public static DbConnectionFactory Instance { get { return instance; } }

        public DbConnectionFactory()
        {
        }

        public void Init(string connectionString)
        {
            builder = new SqlConnectionStringBuilder(connectionString);
        }

        public IDbConnection GetConnection()
        {
            var dbConnection = new SqlConnection(builder.ConnectionString);

            dbConnection.Open();

            return dbConnection;
        }
    }
}

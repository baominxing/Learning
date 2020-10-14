using Dapper;
using DapperExtensions;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ADO.NETs
{
    class Program
    {
        static void Main(string[] args)
        {
            //ADO.NET事务
            //1）使用MySqlConnection类的BeginTransaction()方法返回一个MySqlTransaction类型的对象；
            //2）使用MySqlCommand类对象的Transaction属性将要参与事务处理的每条命令关联到上一不返回的MySqlTransaction类型的对象上；
            //3）如果事务可以成功完成，使用MySqlTransaction对象的Commit()方法提交事务处理结果；
            //4）如果事务处理中发生错误，就调用MySqlTransaction对象的Rollback()方法，撤销每一个修改。
            //ADO.NET事务的缺点;
            //ADO.NET事务只能处理关联到一个连接上的本地事务，不支持跨多个连接的事务。（为了克服这一缺点，下一节将介绍基于System.Transaction命名空间的分布式事务）。
            //Sample1.Demonstration();

            //ADO.NET 嵌套事务探索1，此种方式并不形成嵌套事务，而是两个相互独立的事务
            //Sample2.Demonstration();

            //ADO.NET 嵌套事务探索2,很奇快的是 BeginTransaction();里的查询能查到第一个事务里的Insert(conn);插入数据，但是里面插入的数据并没有提到到数据库;
            //当写入transaction.Complete();后，都可以提交
            //Sample3.Demonstration();

            //ADO.NET 嵌套事务探索3
            //Sample4.Demonstration();


            //基于ADO.NET的工作单元模式
            Sample5.Demonstration();

            Console.ReadKey();
        }
    }

    public class Sample1
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        Select(conn, transaction);

                        Console.WriteLine("==================================================");

                        Update(conn, transaction);

                        Select(conn, transaction);

                        Console.WriteLine("==================================================");

                        Insert(conn, transaction);

                        Select(conn, transaction);

                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }
        }

        public static void Select(SqlConnection conn, SqlTransaction transaction)
        {
            var sql = $"select * from StateInfos";

            var result = conn.Query<dynamic>(sql, null, transaction);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Update(SqlConnection conn, SqlTransaction transaction)
        {
            var sql = $"update StateInfos Set Type = 1";

            conn.Execute(sql, null, transaction);
        }

        public static void Insert(SqlConnection conn, SqlTransaction transaction)
        {
            var entity = new StateInfos()
            {
                Hexcode = "1",
                Code = "1",
                DisplayName = "1",
                IsPlaned = false,
                IsStatic = false,
                OriginalCode = 1,
                Type = 1,
            };

            conn.Insert(entity, transaction);
        }
    }

    public class Sample2
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        Select(conn, transaction);

                        Console.WriteLine("==================================================");

                        Update(conn, transaction);

                        Select(conn, transaction);

                        Console.WriteLine("==================================================");

                        Insert(conn, transaction);

                        Select(conn, transaction);

                        Console.WriteLine("==================================================");

                        BeginTransaction();

                        //transaction.Commit();

                        transaction.Rollback();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }
        }

        public static void BeginTransaction()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    Insert(conn, transaction);

                    Select(conn, transaction);

                    transaction.Commit();
                }
            }
        }

        public static void Select(SqlConnection conn, SqlTransaction transaction)
        {
            var sql = $"select * from StateInfos";

            var result = conn.Query<dynamic>(sql, null, transaction);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Update(SqlConnection conn, SqlTransaction transaction)
        {
            var sql = $"update StateInfos Set Type = 1";

            conn.Execute(sql, null, transaction);
        }

        public static void Insert(SqlConnection conn, SqlTransaction transaction)
        {
            var entity = new StateInfos()
            {
                Hexcode = "1",
                Code = "1",
                DisplayName = "1",
                IsPlaned = false,
                IsStatic = false,
                OriginalCode = 1,
                Type = 1,
            };

            conn.Insert(entity, transaction);
        }
    }

    public class Sample3
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                {
                    Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);

                    try
                    {
                        Select(conn);

                        Insert(conn);

                        Select(conn);

                        BeginTransaction();

                        transaction.Complete();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }
        }

        public static void BeginTransaction(SqlConnection conn = null)
        {
            //Insert(conn);

            //Select(conn);

            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);

                    Insert(conn);

                    Select(conn);

                    //transaction.Commit();
                }
            }
        }

        public static void Select(SqlConnection conn)
        {
            var sql = $"select * from StateInfos";

            var result = conn.Query<dynamic>(sql);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==================================================");
        }

        public static void Update(SqlConnection conn)
        {
            var sql = $"update StateInfos Set Type = 1";

            conn.Execute(sql);
        }

        public static void Insert(SqlConnection conn)
        {
            var entity = new StateInfos()
            {
                Hexcode = "1",
                Code = "1",
                DisplayName = "1",
                IsPlaned = false,
                IsStatic = false,
                OriginalCode = 1,
                Type = 1,
            };

            conn.Insert(entity);
        }
    }

    public class Sample4
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
            //sqlconnection 写在外面，里面申请的事务当完成后会自动提交，不需要调用Complete()
            //using (var conn = new SqlConnection(connectionString))
            //{
            //    using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            //    {

            //        conn.Open();


            //        //Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);

            //        try
            //        {
            //            BeginTransaction(conn);

            //            Insert(conn);

            //            Select(conn);

            //            //transaction.Complete();

            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //        }
            //    }

            //}
            // sqlconnection 写在外面，里面申请的事务当完成后不会自动提交，需要调用Complete()
            using (var transaction = new TransactionScope(TransactionScopeOption.Required))
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);

                    try
                    {
                        BeginTransaction();

                        Insert(conn);

                        Select(conn);

                        transaction.Complete();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }
        }

        public static void BeginTransaction(SqlConnection conn = null)
        {
            //Insert(conn);

            //Select(conn);

            using (conn = new SqlConnection(connectionString))
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required))
                {
                    Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);
                    conn.Open();

                    Insert(conn);

                    Select(conn);

                    transaction.Complete();

                    //transaction.Dispose();
                }
            }

            //Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);

            //Insert(conn);

            //Select(conn);

            //transaction.Complete();
        }

        public static void Select(SqlConnection conn)
        {
            var sql = $"select * from StateInfos";

            var result = conn.Query<dynamic>(sql);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==================================================");
        }

        public static void Update(SqlConnection conn)
        {
            var sql = $"update StateInfos Set Type = 1";

            conn.Execute(sql);
        }

        public static void Insert(SqlConnection conn)
        {
            //将执行的sql
            String sql = @"
INSERT INTO [dbo].[StateInfos]
           ([Hexcode]
           ,[DisplayName]
           ,[Code]
           ,[OriginalCode]
           ,[IsPlaned]
           ,[Type]
           ,[IsStatic])
     VALUES
           (1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)
";
            //创建命令对象，指定要执行sql语句与连接对象conn
            SqlCommand cmd = new SqlCommand(sql, conn);
            //执行,返回影响行数
            int rows = cmd.ExecuteNonQuery();
        }
    }

    public class Sample5
    {
        static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
        public static void Demonstration()
        {
        }

        class SQLEntity
        {
            private string m_SQL = null;
            public string SQL
            {
                get { return m_SQL; }
            }

            private IDataParameter[] m_Parameters = null;
            public IDataParameter[] Parameters
            {
                get { return m_Parameters; }
            }

            public SQLEntity(string sql, params IDataParameter[] parameters)
            {
                this.m_SQL = sql;
                this.m_Parameters = parameters;
            }
        }

        class SQLUnitOfWork
        {
            private IDbConnection m_connection = null;
            private List<dynamic> m_operations = new List<dynamic>();

            public SQLUnitOfWork(IDbConnection connection)
            {
                this.m_connection = connection;
            }

            public void RegisterAdd(string sql, params IDataParameter[] parameters)
            {
                this.m_operations.Add(new SQLEntity(sql, parameters));
            }

            public void RegisterSave(string sql, params IDataParameter[] parameters)
            {
                this.m_operations.Add(new SQLEntity(sql, parameters));
            }

            public void RegisterRemove(string sql, params IDataParameter[] parameters)
            {
                this.m_operations.Add(new SQLEntity(sql, parameters));
            }

            public void Commit()
            {
                using (IDbTransaction trans = this.m_connection.BeginTransaction())
                {
                    try
                    {
                        using (IDbCommand cmd = this.m_connection.CreateCommand())
                        {
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.Text;
                            this.ExecuteQueryBy(cmd);
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }

            private void ExecuteQueryBy(IDbCommand cmd)
            {
                foreach (var entity in this.m_operations)
                {
                    cmd.CommandText = entity.SQL;
                    cmd.Parameters.Clear();
                    foreach (var parameter in entity.Parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.ExecuteNonQuery();
                }
                this.m_operations.Clear();
            }
        }

        class SchoolRepository
        {
            private SQLUnitOfWork m_uow = null;

            public SchoolRepository(SQLUnitOfWork uow)
            {
                this.m_uow = uow;
            }

            public void Add(School school)
            {
                this.m_uow.RegisterAdd("insert school values(@id, @name)", new IDbDataParameter[]{
            new SqlParameter("@id", school.Id),
            new SqlParameter("@name", school.Name)
        });
            }

            public void Save(School school)
            {
                this.m_uow.RegisterSave("update school set name = @name where id = @id", new IDbDataParameter[]{
            new SqlParameter("@id", school.Id),
            new SqlParameter("@name", school.Name)
        });
            }

            public void Remove(School school)
            {
                this.m_uow.RegisterRemove("delete from school where id = @id", new IDbDataParameter[]{
            new SqlParameter("id", school.Id)
        });
            }
        }

        class StudentRepository
        {
            //代码类似，因此省略
        }

        public class School
        {
            public SqlDbType Name { get; internal set; }
            public SqlDbType Id { get; internal set; }
        }
    }
}

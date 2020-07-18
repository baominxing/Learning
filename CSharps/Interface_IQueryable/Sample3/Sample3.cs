using Sample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Interface_IQueryable
{
    #region Sample3

    public class Sample3
    {
        private static string connectionString = "Data Source=.;Initial Catalog=BTLMaster;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True";

        internal static void Demonstration()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var si = new Query<StateInfos>(new DbQueryProvider(connection));

                var code = "Free";

                var query = si.Select(c => new { Code = c.Code, DisplayName = c.DisplayName, Hexcode = c.Hexcode }).Where(c => c.Code == code);

                Console.WriteLine("Query:\n{0}\n", query);

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

    #endregion Sample3
}
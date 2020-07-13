using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace ReadExcelAbove2007
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"BVV000732480032.xlsx";

            try
            {
                var td = ExcelFileHelper.ReadExcelToCSVFormat(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }

    public class ExcelFileHelper
    {
        protected static OleDbConnection conn = new OleDbConnection();
        protected static OleDbCommand comm = new OleDbCommand();

        public ExcelFileHelper()
        {
            //init
        }

        //根据excle的路径把第一个sheel中的内容放入datatable
        public static DataTable ReadExcelToTable(string path)//excel存放的路径
        {
            //连接字符串
            string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; // Office 07及以上版本 不能出现多余的空格 而且分号注意
            //string connstring = "Provider = Microsoft.JET.OLEDB.4.0; Data Source = " + path + "; Extended Properties = 'Excel 8.0;HDR=NO;IMEX=1'; "; //Office 07以下版本 
            using (OleDbConnection conn = new OleDbConnection(connstring))
            {
                conn.Open();
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
                string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
                                                                                   //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串

                OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                DataSet set = new DataSet();
                ada.Fill(set);
                return set.Tables[0];
            }

        }

        public static string[] ReadExcelToCSVFormat(string path)
        {
            var stringLines = new List<string>();
            var lineBuilder = new StringBuilder();
            var td = ExcelFileHelper.ReadExcelToTable(path);

            var columnCount = td.Columns.Count;

            for (int i = 0; i < td.Rows.Count; i++)
            {
                lineBuilder.Clear();

                for (int j = 1; j <= td.Columns.Count; j++)
                {
                    lineBuilder.Append($"{td.Rows[i][$"F{j}"].ToString()},");
                }

                stringLines.Add(lineBuilder.ToString());
            }

            return stringLines.ToArray();
        }
    }
}

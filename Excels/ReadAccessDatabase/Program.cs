using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ReadAccessDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取accedb文件
            Sample1.Demonstration();


            //读取mdb文件
            //Sample2.Demonstration();
        }
    }

    internal class Sample2
    {
        public static void Demonstration()
        {
            SharedDirectoryManager sharedDirectoryManager = new SharedDirectoryManager();

            if (sharedDirectoryManager.ImpersonateValidUser("fred.bao", "192.168.1.21", "123qwe"))
            {
                string executeSql = "select Top 1 [最大力] from Tension order by Num DESC";

                DataTable dTable = ReadAllDataWithACE(executeSql, @"\\192.168.1.21\tr\SmartTestReport.mdb");

                var zuidali = dTable.Rows[0][0].ToString();
            }
            else
            {
                Console.WriteLine("登录服务器失败");
            }
        }

        // 读取mdb指定表的全部数据 
        public static DataTable ReadAllDataWithACE(string executeSql, string mdbPath)
        {
            try
            {
                var dt = new DataTable();

                var connectionSql = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={mdbPath};Persist Security Info=False;";

                using (var connection = new OleDbConnection(connectionSql))
                {
                    connection.Open();

                    var command = new OleDbCommand(executeSql, connection);

                    var da = new OleDbDataAdapter(command);

                    da.Fill(dt);

                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class Sample1
    {
        public static void Demonstration()
        {
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = SmartTestReport.mdb;Persist Security Info=False;OLE DB Services=-4;";
            string strSQL = $"select top 1 [最大力] from Tension Where [批号] = '123' and [编号] = '321' order by Num DESC";
            // create Objects of ADOConnection and ADOCommand  
            OleDbConnection myConn = new OleDbConnection(strDSN);
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
            myConn.Open();
            var dt = new DataTable();
            myCmd.Fill(dt);

            var zuidali= dt.Rows[0][0]?.ToString();
        }
    }

    public class SharedDirectoryManager
    {
        // logon types
        private const int Logon32_Logon_Interactive = 2;
        private const int Logon32_Logon_Network = 3;
        private const int Logon32_Logon_New_Credentials = 9;

        // logon providers
        private const int Logon32_Provider_Default = 0;
        private const int Logon32_Provider_Winnt50 = 3;
        private const int Logon32_Provider_Winnt40 = 2;
        private const int Logon32_Provider_Winnt35 = 1;

        private WindowsImpersonationContext impersonationContext;

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int LogonUser(string lpszUserName, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool CloseHandle(IntPtr handle);

        public bool ImpersonateValidUser(string userName, string domain, string password)
        {
            var token = IntPtr.Zero;
            var tokenDuplicate = IntPtr.Zero;

            if (RevertToSelf())
            {
                // 这里使用LOGON32_LOGON_NEW_CREDENTIALS来访问远程资源。
                // 如果要（通过模拟用户获得权限）实现服务器程序，访问本地授权数据库可
                // 以用LOGON32_LOGON_INTERACTIVE
                if (LogonUser(userName, domain, password, Logon32_Logon_New_Credentials, Logon32_Provider_Default, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        var tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        this.impersonationContext = tempWindowsIdentity.Impersonate();
                        if (this.impersonationContext != null)
                        {
                            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }

            if (token != IntPtr.Zero)
                CloseHandle(token);

            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);

            return false;
        }

        public void UndoImpersonation()
        {
            this.impersonationContext.Undo();
        }
    }
}

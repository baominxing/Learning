using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"10.77.179.30/WIMI/12345678");

                SharedDirectoryManager sharedDirectoryManager = new SharedDirectoryManager();

                if (sharedDirectoryManager.ImpersonateValidUser("WIMI", "10.77.179.30", "12345678"))
                {
                    //读取报告，路径为 D:/DailyReport/DailyReport_你们给的号码1（物料编码）_你们给的号码2（工件序列号）
                    var reportFilePath = Console.ReadLine();

                    if (!File.Exists(reportFilePath))
                    {
                        Console.WriteLine($"读取报告{reportFilePath}失败");

                        sharedDirectoryManager.UndoImpersonation();
                    }
                    else
                    {
                        Console.WriteLine($"读取报告{reportFilePath}成功");

                        sharedDirectoryManager.UndoImpersonation();
                    }
                }
                else
                {
                    Console.WriteLine($"尝试登录服务器10.77.179.30失败，登录账户/密码为：WIMI/12345678");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            Console.ReadKey();
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

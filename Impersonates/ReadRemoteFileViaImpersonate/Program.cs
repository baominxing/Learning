using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ReadRemoteFileViaImpersonate
{
    /// <summary>
    /// 演示用模拟登录账号的方式读取远程文件
    /// </summary>
    class Program
    {
        static readonly string username = ConfigurationManager.AppSettings["username"];
        static readonly string password = ConfigurationManager.AppSettings["password"];
        static readonly string domain = ConfigurationManager.AppSettings["domain"];
        static readonly string directory = ConfigurationManager.AppSettings["directory"];
        static readonly string filename = ConfigurationManager.AppSettings["filename"];

        static void Main(string[] args)
        {
            SharedDirectoryManager sharedDirectoryManager = new SharedDirectoryManager();

            if (sharedDirectoryManager.ImpersonateValidUser(username, domain, password))
            {
                //遍历目录下的所有文件
                foreach (var file in Directory.GetFiles(Path.Combine(directory, DateTime.Now.ToString("yyyyMMdd"))))
                {
                    Console.WriteLine(file);
                }

                var filepath = Path.Combine(directory, DateTime.Now.ToString("yyyyMMdd"), filename);

                if (!File.Exists(filepath))
                {
                    Console.WriteLine($"读取报告{filepath}不存在服务器");
                }
                else
                {
                    Console.WriteLine($"读取报告{filepath}");
                }

                sharedDirectoryManager.UndoImpersonation();
            }
            else
            {
                Console.WriteLine($"尝试登录服务器失{username},{domain},{password}");
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

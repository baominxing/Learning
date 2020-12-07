using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
            //远程读取excel文件
            //Demonstration();

            //远程读取txt文件
            Demonstration2();

            Console.ReadKey();
        }

        public static void Demonstration()
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
        }

        public static void Demonstration2()
        {
            SharedDirectoryManager sharedDirectoryManager = new SharedDirectoryManager();

            if (sharedDirectoryManager.ImpersonateValidUser(username, domain, password))
            {
                var filepath = Path.Combine(directory, filename);
                var line = string.Empty;
                var lines = new List<string>();

                if (!File.Exists(filepath))
                {
                    Console.WriteLine($"读取报告{filepath}不存在服务器");
                }
                else
                {
                    Console.WriteLine($"读取报告{filepath}");

                    using (var fs = new StreamReader(filepath))
                    {
                        while ((line = fs.ReadLine()) != null)
                        {
                            //Console.WriteLine(line);

                            //筛选需要的行
                            if (line.Contains("识别编号") || line.Contains("步骤") || line.Contains("纵向尺寸"))
                            {
                                lines.Add(line);
                            }
                        }
                    }

                    #region 步骤 1处理逻辑
                    var lastStep1Index = lines.LastIndexOf("步骤 1");

                    if (lastStep1Index == -1)
                    {
                        Console.WriteLine("未能找到步骤 1的记录");

                        return;
                    }

                    var lastStep1Code = lines[lastStep1Index - 1];
                    var lastStep1Value = lines[lastStep1Index + 1];

                    Console.WriteLine(lastStep1Code + ":" + (lastStep1Index - 1));
                    Console.WriteLine(lines[lastStep1Index] + ":" + lastStep1Index);
                    Console.WriteLine(lastStep1Value + ":" + (lastStep1Index + 1));

                    var value = lastStep1Value.Trim().Split(' ').ToList().LastOrDefault();
                    #endregion

                    #region 步骤 2处理逻辑
                    var lastStep2Index = lines.LastIndexOf("步骤 2");

                    if (lastStep2Index == -1)
                    {
                        Console.WriteLine("未能找到步骤 2的记录");

                        return;
                    }

                    var lastStep2Code = lines[lastStep2Index - 1];
                    var lastStep2Value = lines[lastStep2Index + 1];

                    Console.WriteLine(lastStep2Code + ":" + (lastStep2Index - 1));
                    Console.WriteLine(lines[lastStep2Index] + ":" + lastStep2Index);
                    Console.WriteLine(lastStep2Value + ":" + (lastStep2Index + 1));


                    //验证步骤2是步骤1的后续

                    if (lastStep1Index != (lastStep2Index - 3) && lastStep1Code == lastStep2Code)
                    {
                        Console.WriteLine("步骤 2与步骤 1顺序不匹配");

                        return;
                    }
                    #endregion

                }

                sharedDirectoryManager.UndoImpersonation();
            }
            else
            {
                Console.WriteLine($"尝试登录服务器失{username},{domain},{password}");
            }
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

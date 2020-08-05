using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ImportExtensionDllProject
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                var a = File.ReadAllText("a.txt");
                var b = File.ReadAllText("b.txt");
                var c = File.ReadAllText("c.txt");
                var d = File.ReadAllText("d.txt");
                var e = File.ReadAllText("e.txt");

                for (int i = 0; i < 1000; i++)
                {

                    Console.WriteLine($"a == b ? {ConfirmFinger(a, b)}");
                    Console.WriteLine($"a == c ? {ConfirmFinger(a, c)}");
                    Console.WriteLine($"a == d ? {ConfirmFinger(a, d)}");
                    Console.WriteLine($"a == e ? {ConfirmFinger(a, e)}");
                    Console.WriteLine($"a == c ? {ConfirmFinger(a, c)}");
                    Console.WriteLine($"a == d ? {ConfirmFinger(a, d)}");
                    Console.WriteLine($"a == e ? {ConfirmFinger(a, e)}");
                    Console.WriteLine($"a == c ? {ConfirmFinger(a, c)}");
                    Console.WriteLine($"a == d ? {ConfirmFinger(a, d)}");
                    Console.WriteLine($"a == e ? {ConfirmFinger(a, e)}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        [DllImport("ARTH_DLL.dll")]//指纹模板比对
        public static extern int Match2Fp(byte[] Src, byte[] Dst);

        [DllImport("ARTH_DLL.dll")]//生成指纹模板
        public static extern int GenChar(byte[] Idata, byte[] Odata);

        [DllImport("ARITH_LIB.dll")]//关闭设备 
        public static extern int UserMatch(byte[] Src, byte[] Dst, byte SecuLevel, int[] MatchScore);

        public static bool ConfirmFinger(string srcBaseStr, string destBaseString)
        {
            try
            {
                int ret = 0;

                byte[] src = new byte[1024 * 1024];//= Convert.FromBase64String(srcBaseStr);
                byte[] dest = new byte[1024 * 1024]; ;//= Convert.FromBase64String(destBaseString);

                var srcs = Convert.FromBase64String(srcBaseStr);
                Buffer.BlockCopy(srcs, 0, src, 0, srcs.Length);


                var srcs2 = Convert.FromBase64String(destBaseString);
                Buffer.BlockCopy(srcs2, 0, dest, 0, srcs2.Length);

                byte[] aa = new byte[1024];
                byte[] bb = new byte[1024];

                var length = GenChar(src, aa);
                var length2 = GenChar(dest, bb);

                ret = Match2Fp(aa, bb);

                return ret >= 50;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ConfirmFinger2(string srcBaseStr, string destBaseString)
        {
            try
            {
                int ret = 0;

                byte[] src = Convert.FromBase64String(srcBaseStr);
                byte[] dest = Convert.FromBase64String(destBaseString);

                byte[] aa = new byte[1024 * 1024];
                byte[] bb = new byte[1024 * 1024];

                GenChar(src, aa);
                GenChar(dest, bb);

                ret = Match2Fp(aa, bb);

                return ret >= 50;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

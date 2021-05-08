using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windbg_ThreadStatic
{
    class Program
    {
        [ThreadStatic]
        public static int i = 0;

        static void Main(string[] args)
        {
            i = 10;   // 12 line

            var num = i;

            Console.ReadLine();
        }
    }
}

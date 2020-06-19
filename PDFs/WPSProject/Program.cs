using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string Extension = ".xls";//扩展名 ".aspx"
            switch (Extension)
            {
                case ".xls":
                    Extension = "KET.Application";
                    break;
                case ".xlsx":
                    Extension = "KET.Application";
                    break;
                case ".ppt":
                    Extension = "KWPP.Application";
                    break;
                case ".pptx":
                    Extension = "KWPP.Application";
                    break;
                default:
                    Extension = "KWps.Application";
                    break;
            }
            Type type = Type.GetTypeFromProgID(Extension);

            if (type == null)
            {
                Console.WriteLine("Type.GetTypeFromProgID(Extension) == NULL");

                type = Type.GetTypeFromProgID("wps.Application");

                if (type == null)
                {
                    Console.WriteLine("Type.GetTypeFromProgID(wps.Application) == NULL");
                }
            }
            else
            {
                Console.WriteLine(type.Name);
            }
            
            var wps = Activator.CreateInstance(type);

            if (wps == null)
            {
                Console.WriteLine("wps == NULL");
            }
            else
            {
                Console.WriteLine(wps.GetType().Name);
            }

            Console.ReadKey();
        }
    }
}

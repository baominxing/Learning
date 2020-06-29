using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LINQToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            Sample1.Demonstration();
            #endregion

            Console.ReadKey();
        }
    }

    internal class Sample1
    {
        internal static void Demonstration()
        {
            var xmlstring = File.ReadAllText("20200628.txt");
            var root = XElement.Parse(xmlstring);
            var mesxmlstring = root.Value.Replace("message:", string.Empty);
            var mesxml = XElement.Parse(mesxmlstring);

            var tables = mesxml.Descendants("Table1");

            foreach (var item in tables)
            {
                var elements = item.Elements();

                foreach (var e in elements)
                {
                    Console.WriteLine($"{e.Name}:{e.Value}");
                }

                Console.WriteLine("======================================================");
            }
        }
    }
}

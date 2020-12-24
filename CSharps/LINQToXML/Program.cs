using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LINQToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            //Sample1.Demonstration();
            #endregion

            #region Sample2 演示xml序列化成对象
            //Sample2.Demonstration();
            #endregion

            #region Sample3 演示xml序列化成对象
            Sample3.Demonstration();
            #endregion

            Console.ReadKey();
        }
    }

    public class Sample1
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

    public class Sample2
    {
        public static void Demonstration()
        {
            var xmlstring = File.ReadAllText("20200628.txt");
            var root = XElement.Parse(xmlstring);
            var mesxmlstring = root.Value.Replace("message:", string.Empty);
            var mesxml = XElement.Parse(mesxmlstring);

            var tables = mesxml.Descendants("Table1");

            foreach (var item in tables)
            {
                using (StringReader sr = new StringReader(item.ToString()))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Table1));
                    Table1 obj = (Table1)serializer.Deserialize(sr);
                }

                Console.WriteLine("======================================================");
            }
        }

        public class Table1
        {
            //MES序列号
            public string ART_SERIEN_NR { get; set; }

            //项点编号
            public string QM_NR { get; set; }

            //项点版本
            public string QM_VERSIONS_NR { get; set; }

            //项点名称
            public string QM_BEZEICHNUNG { get; set; }

            //项点行号
            public string QM_POSITIONS_NR { get; set; }

            //项点反馈编号
            public string QQRM_NR { get; set; }

            //项点反馈状态
            public string QQRM_STATUS { get; set; }

            //项点类型
            public string POSITIONS_TYP { get; set; }

            //标准值
            public string SOLLMASS { get; set; }

            //测量值
            public string MESSWERT { get; set; }

            //工单行号
            public string RUECKMELDE_POSITIONS_NR_QFQM { get; set; }

            //质检反馈状态
            public string QUALITAETS_STATUS { get; set; }

            //上公差
            public string OBERES_ABMASS { get; set; }

            //下公差
            public string UNTERES_ABMASS { get; set; }

            //自检信息采集标记
            public string CSR_EIGEN_PRUEF_DATEN_PFLICHT { get; set; }

            //检查标准
            public string BESCHREIBUNG { get; set; }

            //自检状态
            public string SELFCHECK_STATUS { get; set; }

            //自检反馈人员编号
            public string RUECKMELDUNG_DURCH { get; set; }

            //互检状态
            public string PEERCHECK_STATUS { get; set; }

            //互检反馈人
            public string GEPRUEFT_DURCH { get; set; }

            //专检状态
            public string SPECHECK_STATUS { get; set; }

            //专检反馈人
            public string GEPRUEFT_2_DURCH { get; set; }

            //生产编号
            public string CSR_PRODUCTION_NO { get; set; }

            //自检日期
            public string RUECKMELDUNG_AM { get; set; }

            //自检人员编号清单
            public string SELFCHECKWORKS { get; set; }

            //互检日期
            public string GEPRUFT_DATUM { get; set; }

            //互检人员编号清单
            public string RECHECKWORKS { get; set; }
        }
    }

    public class Sample3
    {
        public static void Demonstration()
        {
            var templateXml = GetSoapRequestXmlTemplate("设备过程参数收集");

            Console.WriteLine(templateXml);

            var sendMessage = new SoapXmlCompiler()
                      .AddKey("site", "")
                      .AddKey("operation", "")
                      //.AddKey("operationRevision", string.Empty)
                      .AddKey("resource", "")
                      .AddKey("dcGroup", "")
                      //.AddKey("dcGroupRevision", string.Empty)
                      .AddKey("user", "")
                      .AddKey("dataList", "")
                      .CompileString(templateXml);

            Console.WriteLine(sendMessage);

            templateXml = GetSoapRequestXmlTemplate("产品进站收数");

            Console.WriteLine(templateXml);

            sendMessage = new SoapXmlCompiler()
                      .AddKey("site", "")
                      .AddKey("operation", "")
                      //.AddKey("operationRevision", string.Empty)
                      .AddKey("resource", "")
                      .AddKey("dcGroup", "")
                      //.AddKey("dcGroupRevision", string.Empty)
                      .AddKey("user", "")
                      .AddKey("dataList", "")
                      .CompileString(templateXml);

            Console.WriteLine(sendMessage);
        }

        static string GetSoapRequestXmlTemplate(string interfaceName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LINQToXML.SoapRequestXmlTemplates.xml");

            var doc = new XmlDocument();

            doc.Load(stream);

            var cdata = doc.SelectNodes("/templates/template");

            var e = XElement.Parse(doc.OuterXml).Descendants("template").Where(s => s.FirstAttribute.Value == interfaceName).FirstOrDefault();

            var templateXml = e?.Value ?? string.Empty;

            if (string.IsNullOrEmpty(templateXml))
            {
                throw new Exception($"{interfaceName}接口没有维护模板");
            }

            return templateXml;
        }
    }
}

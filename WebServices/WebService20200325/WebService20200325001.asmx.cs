using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace WebService20200325
{
    /// <summary>
    /// WebService20200325001 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService20200325001 : System.Web.Services.WebService
    {
        //[XmlNamespaceDeclarations]
        //public XmlSerializerNamespaces xmlns
        //{
        //    get
        //    {
        //        XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
        //        xsn.Add("me", "http://mynamespace/");
        //        return xsn;
        //    }
        //    set { /* needed for xml serialization */ }
        //}

        //public WebService20200325001()
        //{
        //    xmlns = new XmlSerializerNamespaces();
        //    xmlns.Add("MyNS", "myNS.tempuri.org");
        //}
        [SoapDocumentMethod("http://tempuri.org/GlobalSearchService", RequestNamespace = "http://tempuri.org.com/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [WebMethod(Description = "Obtains the User Name")]
        public string HelloWorld(HelloWordDto helloWordDto)
        {
            return helloWordDto?.Name ?? string.Empty;
        }
    }

    [Serializable]
    public class HelloWordDto
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns;
        public HelloWordDto()
        {
            xmlns = new XmlSerializerNamespaces();
            xmlns.Add("MyNS", "myNS.tempuri.org");
            xmlns.Add("common", "common.tempuri.org");
        }

        public string Name { get; set; }
    }
}

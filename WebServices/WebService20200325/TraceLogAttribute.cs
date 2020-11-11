using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;

namespace WebService20200325
{
    // Define a SOAP Extension that traces the SOAP request and SOAP
    // response for the XML Web service method the SOAP extension is
    // applied to.
    public class TraceExtension : SoapExtension
    {
        //log4net的stringtomacthfilter的前缀，用于与其他日志区分
        string WebServiceLogPrefix = "WS";
        Stream oldChainStream;
        Stream newChainStream;
        string filename;

        // Save the Stream representing the SOAP request or SOAP response into
        // a local memory buffer.
        public override Stream ChainStream(Stream stream)
        {
            oldChainStream = stream;
            newChainStream = new MemoryStream();

            return newChainStream;
        }

        // When the SOAP extension is accessed for the first time, the XML Web
        // service method it is applied to is accessed to store the file
        // name passed in, using the corresponding SoapExtensionAttribute.	
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return Assembly.GetExecutingAssembly().CodeBase;
        }

        // The SOAP extension was configured to run using a configuration file
        // instead of an attribute applied to a specific XML Web service
        // method.
        public override object GetInitializer(Type WebServiceType)
        {
            // Return a file name to log the trace information to, based on the
            // type.
            return Path.Combine(Assembly.GetExecutingAssembly().CodeBase, "TraceLog.txt");
        }

        // Receive the file name stored by GetInitializer and store it in a
        // member variable for this specific instance.
        public override void Initialize(object initializer)
        {
            filename = (string)initializer;
        }

        //  If the SoapMessageStage is such that the SoapRequest or
        //  SoapResponse is still in the SOAP format to be sent or received,
        //  save it out to a file.
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    WriteOutput(message);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    WriteInput(message);
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
            }
        }

        public void WriteOutput(SoapMessage message)
        {
            var soapString = (message is SoapServerMessage) ? "SoapResponse" : "SoapRequest";

            WSLogger($"-----{soapString} at {DateTime.Now}");
            WSLogger(newChainStream);

            //需要将返回信息重新Copy给ChainStream
            newChainStream.Position = 0;
            newChainStream.CopyTo(oldChainStream);
        }

        public void WriteInput(SoapMessage message)
        {
            //将saop请求流copy到newChainStream对象
            oldChainStream.CopyTo(newChainStream);
            var soapString = (message is SoapServerMessage) ? "SoapRequest" : "SoapResponse";
            WSLogger($"-----{soapString} at {DateTime.Now}");
            WSLogger(oldChainStream);
            //重置newChainStream,让saop请求正常往下流转
            newChainStream.Position = 0;
        }

        private void WSLogger(Stream messageStream)
        {
            if (messageStream != null)
            {
                messageStream.Position = 0;
                TextReader reader = new StreamReader(messageStream, Encoding.UTF8);
                WSLogger(reader.ReadToEnd());
            }
        }

        private void WSLogger(string message)
        {
            var dy = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            if (!Directory.Exists(dy))
            {
                Directory.CreateDirectory(dy);
            }

            File.AppendAllText(Path.Combine(dy, $"{DateTime.Now.ToString("yyyyMMdd")}.txt"), $"{WebServiceLogPrefix} {message}" + Environment.NewLine);
        }
    }

    /// <summary>
    /// Create a SoapExtensionAttribute for the SOAP Extension that can be applied to an XML Web service method
    /// 记录请求和返回结果的Saop的日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class LoggedAttribute : SoapExtensionAttribute
    {

        private string filename = "D:\\log.txt";
        private int priority;

        public override Type ExtensionType
        {
            get { return typeof(TraceExtension); }
        }

        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
    }
}
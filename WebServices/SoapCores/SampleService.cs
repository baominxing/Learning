using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoapCores
{
    public class SampleService : ISampleService
    {

        public string Ping(string s)
        {
            Console.WriteLine("Exec ping method");
            return s;
        }

        public ComplexModelResponse PingComplexModel(ComplexModelInput inputModel)
        {
            return new ComplexModelResponse
            {
                FloatProperty = float.MaxValue / 2,
                StringProperty = inputModel.StringProperty,
                ListProperty = inputModel.ListProperty,
                DateTimeOffsetProperty = inputModel.DateTimeOffsetProperty,
                TestEnum = inputModel.TestEnum
            };
        }

        public void VoidMethod(out string s)
        {
            s = "Value from server";
        }

        public Task<int> AsyncMethod()
        {
            return Task.Run(() => 42);
        }

        public int? NullableMethod(bool? arg)
        {
            return arg == null ? 0 : 1;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
    }
}

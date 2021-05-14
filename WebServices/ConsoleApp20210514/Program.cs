using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20210514
{
    /// <summary>
    /// 用于测试调用asp.net core soap服务
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {

            // Create random inputs
            Random numGen = new Random();
            double x = numGen.NextDouble() * 20;
            double y = numGen.NextDouble() * 20;

            var serviceAddress = $"http://localhost:8048/CalculatorService.svc";

            var client = new CalculatorServiceClient(new BasicHttpBinding(), new EndpointAddress(serviceAddress));

            var result = client.Get_DEVICE_SPINDLE();
        }
    }
    class CalculatorServiceClient : ClientBase<IWebServiceAppService>
    {
        public CalculatorServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

        public double Get_DEVICE_SPINDLE() =>  Channel.Get_DEVICE_SPINDLE();
    }

    [ServiceContract]
    public interface IWebServiceAppService
    {
        [OperationContract]
        double Get_DEVICE_SPINDLE();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

            var serviceAddress = $"http://localhost:8048/WimiWebService.asmx";

            var client = new CalculatorServiceClient(new BasicHttpBinding(), new EndpointAddress(serviceAddress));

            var result = client.StartOperateValidation(new StartOperateValidationDto() { Amount = 0, MachineCode = "1" });
        }
    }
    class CalculatorServiceClient : ClientBase<IWebServiceAppService>
    {
        public CalculatorServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

        public StartOperateValidationResult StartOperateValidation(StartOperateValidationDto input) => Channel.StartOperateValidation(input);
    }


    [ServiceContract(Namespace = "http://tempuri.org/")]
    public interface IWebServiceAppService
    {
        [OperationContract]
        ListDeviceSpindleResult ListDeviceSpindle();

        [OperationContract]
        ListDeviceToolAlarmResult ListDeviceToolAlarm();

        [OperationContract]
        ListDeviceToolLifeResult ListDeviceToolLife();

#if DEBUG

        [OperationContract]
        StartOperateValidationResult StartOperateValidation(StartOperateValidationDto input);
#endif
    }

    public class WebBaseResult
    {
        public string RESULT { get; set; } = "1";

        public string MSG { get; set; } = "";
    }

    public class ListDeviceSpindleResult : WebBaseResult
    {
        public List<DeviceSpindle> DeviceSpindleList { get; set; }
    }

    public class DeviceSpindle
    {
        public string MC_DEVICE_CODE { get; set; }

        public string MC_TOOL_CODE { get; set; }

        public float MC_SPINDLE_LOAD_VALUE { get; set; }

        public DateTime MC_SPINDLE_LOAD_DATE { get; set; }

        public string RecordMessage { get; set; }

    }

    public class ListDeviceToolLifeResult : WebBaseResult
    {
        public List<DeviceToolLife> DeviceToolLifeList { get; set; }
    }

    public class DeviceToolLife
    {
        public string MC_DEVICE_CODE { get; set; }

        public string MC_TOOL_CODE { get; set; }

        public float MC_TOOL_LIFE { get; set; }

        public DateTime MC_SEND_DATA_DATE { get; set; }

        public string RecordMessage { get; set; }

    }

    public class ListDeviceToolAlarmResult : WebBaseResult
    {
        public List<DeviceToolAlarm> DeviceToolAlarmList { get; set; }
    }

    public class DeviceToolAlarm
    {
        public string MC_DEVICE_CODE { get; set; }

        public string MC_ALARM_CODE { get; set; }

        public string MC_ALARM_DESC { get; set; }

        public DateTime MC_ALARM_DATE { get; set; }

        public string MC_ALARM_VALUE { get; set; } = "1";
    }

    [DataContract]
    public class StartOperateValidationDto
    {
        /// <summary>
        /// 产品料号
        /// </summary>
        [DataMember]
        public string ProductCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int Amount { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        [DataMember]
        public string MachineCode { get; set; }
    }

    public class StartOperateValidationResult : WebBaseResult
    {
        public bool IsMissing { get; set; }

        public List<string> MissingCutterNoList { get; set; } = new List<string>();
    }
}

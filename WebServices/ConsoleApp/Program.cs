using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //MiddleDetectResultService();

                ROBOService();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }

        private static void ROBOService()
        {
            //var obj = new { serviceid = "020004", PageSize = 10, PageIndex = 1, FeedbackNo = string.Empty };
            var obj = new { serviceid = "020004", DateBegin = "2019-05-01", DateEnd = "2019-05-01" };
            var objstring = JsonConvert.SerializeObject(obj);

            var resultstring = (dynamic)WSHelper.InvokeWebService(
                "http://112.124.116.112:8888/SFZCWMS/services/wsService",
                "doService",
                new object[] { objstring });

            var warehouseList = JsonConvert.DeserializeObject<dynamic>(resultstring);
        }

        private static void MiddleDetectResultService()
        {
            var partNoList = new List<string>
            {
                "RHKR190751009012691936720",
                "RHKR190741012512691936720",
                "RHKR000000000002147483647",
                "RHKR191121008312691936720",
                "RHKR191091030112691936720",
            };

            var partStatusList = (dynamic)WSHelper.InvokeWebService(
                "http://localhost:8008/MiddleDetectResultService.asmx",
                "ListPartStatus",
                new object[] { partNoList.ToArray() });

            if (partStatusList.CommunicationStatus.ToString() == "Success")
            {

                foreach (var item in partStatusList.PartDtos)
                {
                    Console.WriteLine($"PartNo:{item.PartNo},Status:{item.PartStatus}");
                }

            }
            else
            {
                Console.WriteLine(partStatusList.Message);
            }
        }
    }

    public class WebServiceResult
    {
        public string ErrCode { get; set; }

        public string ErrMsg { get; set; }
    }

    public class WarehouseDto : WebServiceResult
    {
        public List<VehicleWheelInfo> List { get; set; } = new List<VehicleWheelInfo>();
    }

    public class VehicleWheelInfo
    {
        public string Location { get; set; }

        public string LocationStatus { get; set; }

        public string SerialNo { get; set; }

        public string ItemNo { get; set; }

        public string FeedbackNo { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public string DrawNo { get; set; }

        public string MaterTexture { get; set; }

        public string ProjectNo { get; set; }

        public string VenderNo { get; set; }

        public string DelStOrMainNo { get; set; }

        public string State { get; set; }

        public string QualityState { get; set; }

        public string HoleSize { get; set; }

        public string WheelDiameterValue { get; set; }

        public string Size1 { get; set; }

        public string Size2 { get; set; }

        public string Size3 { get; set; }

        public string StaticBalanceValue { get; set; }

        public string MakeDate { get; set; }

        public string SameDuration { get; set; }

        public string AssembleSameStatus { get; set; }

        public string PressSameStatus { get; set; }

        public string TechnicalNotice { get; set; }

        public string Remark { get; set; }
    }
}

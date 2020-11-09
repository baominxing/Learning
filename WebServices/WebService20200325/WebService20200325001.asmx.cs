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
        //[Logged]
        [WebMethod]
        public string HelloWorld(List<Order> OrderInfo)
        {
            return OrderInfo?.Count.ToString() ?? string.Empty;
        }
    }

    [Serializable()]
    public partial class Order
    {
        public Order() { }

        public Operation[] OpInfo;

        #region Model
        private long iD;

        public long ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string feedbackNo;

        public string FeedbackNo
        {
            get { return feedbackNo; }
            set { feedbackNo = value; }
        }
        private string drawNo;

        public string DrawNo
        {
            get { return drawNo; }
            set { drawNo = value; }
        }
        private string stockLocation;

        public string StockLocation
        {
            get { return stockLocation; }
            set { stockLocation = value; }
        }
        private string itemSerialNumberMandatory;

        public string ItemSerialNumberMandatory
        {
            get { return itemSerialNumberMandatory; }
            set { itemSerialNumberMandatory = value; }
        }
        private string serNoTyp;

        public string SerNoTyp
        {
            get { return serNoTyp; }
            set { serNoTyp = value; }
        }
        private string orderType;

        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }
        private string orderQuantity;

        public string OrderQuantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }
        private string serialNo;

        public string OpQuantity { get; set; }

        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
        private string releaseCode;

        public string ReleaseCode
        {
            get { return releaseCode; }
            set { releaseCode = value; }
        }
        private string releaseDate;

        public string ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }
        private string mESRoutingID;

        public string MESRoutingID
        {
            get { return mESRoutingID; }
            set { mESRoutingID = value; }
        }
        private string wBS;

        public string WBS
        {
            get { return wBS; }
            set { wBS = value; }
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private string orderOrigin;

        public string OrderOrigin
        {
            get { return orderOrigin; }
            set { orderOrigin = value; }
        }
        private string projectElement;

        public string ProjectElement
        {
            get { return projectElement; }
            set { projectElement = value; }
        }
        private string lsStartDate;

        public string LsStartDate
        {
            get { return lsStartDate; }
            set { lsStartDate = value; }
        }
        private string lsEndDate;

        public string LsEndDate
        {
            get { return lsEndDate; }
            set { lsEndDate = value; }
        }
        private string trainNo;

        public string TrainNo
        {
            get { return trainNo; }
            set { trainNo = value; }
        }
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string carriageType;

        public string CarriageType
        {
            get { return carriageType; }
            set { carriageType = value; }
        }
        private string projectNo;

        public string ProjectNo
        {
            get { return projectNo; }
            set { projectNo = value; }
        }
        private string noticeNo;

        public string NoticeNo
        {
            get { return noticeNo; }
            set { noticeNo = value; }
        }
        private string bomExplosion;

        public string BomExplosion
        {
            get { return bomExplosion; }
            set { bomExplosion = value; }
        }
        private string carriageNo;

        public string CarriageNo
        {
            get { return carriageNo; }
            set { carriageNo = value; }
        }
        private string mesBomId;

        public string MesBomId
        {
            get { return mesBomId; }
            set { mesBomId = value; }
        }
        private string sapItemNo;

        public string SapItemNo
        {
            get { return sapItemNo; }
            set { sapItemNo = value; }
        }
        private string sapItemDesc;

        public string SapItemDesc
        {
            get { return sapItemDesc; }
            set { sapItemDesc = value; }
        }
        private string rework;

        public string Rework
        {
            get { return rework; }
            set { rework = value; }
        }
        private string wbsProjectNo;

        public string WbsProjectNo
        {
            get { return wbsProjectNo; }
            set { wbsProjectNo = value; }
        }
        private string engChange;

        public string EngChange
        {
            get { return engChange; }
            set { engChange = value; }
        }
        private string engChangeDesc;

        public string EngChangeDesc
        {
            get { return engChangeDesc; }
            set { engChangeDesc = value; }
        }

        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        private string itemNo;

        public string ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }
        private DateTime? receive_time;

        public DateTime? Receive_time
        {
            get { return receive_time; }
            set { receive_time = value; }
        }
        #endregion Model

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Services;
using WebService20200325;

namespace WIMI.BTL.Web.WebServices
{
    /// <summary>
    /// WebService20200325001 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WimiWebService : WebService
    {
        [Logged]
        [WebMethod]
        public LincomWebBaseResult SendProductionPlan(List<Order> OrderInfo)
        {
            if (OrderInfo == null)
            {
                return new LincomWebBaseResult { message = "-1", messagecode = "收到对象内容为空" };
            }

            return new LincomWebBaseResult();
        }
    }

    #region B4_Order结构

    [Serializable]
    public partial class Order
    {
        public Order() { }

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
    #endregion

    #region WIMI_Order结构
    /// <summary>
    /// 下发的工单的实体（35）
    /// </summary>
    //[Serializable]
    //public class Order
    //{
    //    public List<Operation> OpInfo { get; set; } = new List<Operation>();

    //    public List<BOMLine> BOMInfo { get; set; } = new List<BOMLine>();


    //    public List<SerialNoData> SerialNoInfo = new List<SerialNoData>();

    //    public long ID { get; set; }

    //    //工单编号

    //    public string FeedbackNo { get; set; }

    //    //图DIN号

    //    public string DrawNo { get; set; }

    //    //仓库代号

    //    public string StockLocation { get; set; }

    //    //序列号标记 0-false 1-true

    //    public string ItemSerialNumberMandatory { get; set; }

    //    //序列号类型

    //    public string SerNoTyp { get; set; }

    //    //订单类型

    //    public string OrderType { get; set; }

    //    //订单数量
    //    public string OrderQuantity { get; set; }

    //    //生产序列号

    //    public string SerialNo { get; set; }

    //    //生产序列号
    //    //
    //    //public string SerialNo { get; set; }

    //    //释放标识MATERIAL_RELEASED - 1;  Not_RELEASED - 0;RELEASED - 2

    //    public string ReleaseCode { get; set; }

    //    //释放日期

    //    public string ReleaseDate { get; set; }

    //    //MES工艺路径ID

    //    public string MESRoutingID { get; set; }

    //    //WBS元素

    //    public string WBS { get; set; }

    //    //产品名称

    //    public string ProductName { get; set; }

    //    //订单来源NOT_SPECIFIED - 0;  GENERAL_ASSEMBLY - 1;  BODY - 2;   BOGIE - 3 

    //    public string OrderOrigin { get; set; }

    //    //产品信息

    //    public string ProjectElement { get; set; }

    //    public string LsStartDate { get; set; }

    //    public string LsEndDate { get; set; }

    //    //列号

    //    public string TrainNo { get; set; }

    //    //项目名称

    //    public string ProjectName { get; set; }

    //    //辆类型

    //    public string CarriageType { get; set; }

    //    //项目号

    //    public string ProjectNo { get; set; }

    //    //通知号

    //    public string NoticeNo { get; set; }

    //    //BOM展开号

    //    public string BomExplosion { get; set; }

    //    //辆号

    //    public string CarriageNo { get; set; }

    //    //MES BOM ID

    //    public string MesBomId { get; set; }

    //    //SAP物料号(顶层物料号)

    //    public string SapItemNo { get; set; }

    //    //SapItemNo的物料描述

    //    public string SapItemDesc { get; set; }

    //    //返工

    //    public string Rework { get; set; }

    //    //WBS项目号

    //    public string WbsProjectNo { get; set; }

    //    //工程变更通知

    //    public string EngChange { get; set; }

    //    //工程变更通知描述

    //    public string EngChangeDesc { get; set; }

    //    public string ItemName { get; set; }

    //    public string ItemNo { get; set; }

    //    public DateTime Receive_time { get; set; }
    //}

    //public class SerialNoData
    //{
    //    public string SerialNo { get; set; }
    //}

    ///// <summary>
    ///// 工序（操作36）
    ///// </summary>
    //public class Operation
    //{
    //    //所属工单号

    //    public string FeedbackNo { get; set; }

    //    //MES工序号

    //    public string OpNo { get; set; }

    //    //工序描述

    //    public string OpDesc { get; set; }

    //    //工作中心

    //    public string WorkCenterNo { get; set; }

    //    //反馈状态ACTIVATED - 1;CANCELED - 8;COMPLETED - 9;ENTERED - 0;INTERRUPTED - 7;PARTIAL_READY - 3;RE_WORK - 6;STARTED - 2

    //    public string FeedbackStatus { get; set; }

    //    //MES定额工时

    //    public string MesWTQuota { get; set; }

    //    //工序类型

    //    public string OpeationType { get; set; }

    //    //专检工序

    //    public string QualityGateOp { get; set; }

    //    //强制检查

    //    public string MandatoryCheck { get; set; }

    //    //交检工序

    //    public string HandoverOp { get; set; }

    //    //班组

    //    public string SapWc { get; set; }

    //    //班组名称

    //    public string SapWcName { get; set; }

    //    //厂线路线

    //    public string FactoryRoutine { get; set; }

    //    //标准文本码

    //    public string StandardKeyText { get; set; }

    //    //工程变更通知

    //    public string EngChange { get; set; }

    //    //工程变更通知描述

    //    public string EngChangeDesc { get; set; }

    //    //工作物等级

    //    public string OpRank { get; set; }

    //    //PDM版本

    //    public string PdmVersion { get; set; }

    //    //人员标配数量

    //    public string RequiredPerson { get; set; }

    //    //产线

    //    public string ProductionLine { get; set; }

    //    //产线描述

    //    public string ProdLineDesc { get; set; }

    //    //生产编号

    //    public string ProductionNo { get; set; }

    //    //返修
    //    public string Repair { get; set; }

    //    //返修工单号

    //    public string RepairNo { get; set; }

    //    //四方工位编号

    //    public string MesWc { get; set; }

    //    //四方工位名称

    //    public string MesWcName { get; set; }

    //    //存在停止点

    //    public string StoppointExisting { get; set; }

    //    //LS工序开始时间

    //    public string LsStartDate { get; set; }

    //    //Ls工序结束时间

    //    public string LsEndDate { get; set; }

    //    //台位

    //    public string WorkPlace { get; set; }
    //}

    ///// <summary>
    ///// 物料信息(25)
    ///// </summary>
    //public class BOMLine
    //{
    //    //所属工单号

    //    public string FeedbackNo { get; set; }

    //    //行号

    //    public string LineNo { get; set; }

    //    //部件物料号

    //    public string Component { get; set; }

    //    //(部件)装配位置标记

    //    public string BuiltinLocationMandatory { get; set; }

    //    //(部件)批(炉)号标记

    //    public string BatchOrFunaceNoMandatory { get; set; }

    //    //标准/制造商

    //    public string NormOrMan { get; set; }

    //    //供货标准/制造商代码

    //    public string DelStOrMainNo { get; set; }

    //    //组件数量

    //    public string CompQty { get; set; }

    //    //供料来源

    //    public string PrvFrm { get; set; }

    //    //供料对象

    //    public string ProvdedMatTo { get; set; }

    //    //关联工序

    //    public string ReferenceOp { get; set; }

    //    //BOM单位

    //    public string BomUnit { get; set; }

    //    //供货公司

    //    public string SupplPlant { get; set; }

    //    //序列号标记

    //    public string SerNoMandatory { get; set; }

    //    //序列号类型，主料/辅料 1/2

    //    public string SerNoTyp { get; set; }

    //    //安装位置

    //    public string DesChCode { get; set; }

    //    //供料来源号

    //    public string PrvFrmNo { get; set; }

    //    //供料对象号

    //    public string ProvdedMatToNo { get; set; }

    //    //工程变更通知

    //    public string EngChange { get; set; }

    //    //工程变更通知描述

    //    public string EngChangeDesc { get; set; }

    //    //PDM版本

    //    public string PdmVersion { get; set; }

    //    //批次号标记

    //    public string MandatoryBatch { get; set; }

    //    //供应商设置

    //    public string DefineSupplier { get; set; }
    //}
    #endregion

    public class LincomWebBaseResult
    {
        public string messagecode { get; set; } = "1";

        public string message { get; set; } = "接口调用成功";
    }
}

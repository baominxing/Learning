


//------------------------------------------------------------------------------
// 生成时间 2020-06-04 13:49:15 by fred.bao
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesGeneratorTemplate.Models
{
  
    public partial class __MigrationHistory
    {
        /// <summary>
        /// 
        /// </summary>      
        public string MigrationId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ContextKey {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte[] Model {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductVersion {get;set;}
 
    }
  
    public partial class AggregatedCounter
    {
 
    }
  
    public partial class AlarmInfos
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Message {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Reason {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
 
    }
  
    public partial class Alarms
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Message {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Duration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? UserShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? MachinesShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? OrderId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? DateKey {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_SolutionName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_StaffShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_MachineShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ShiftDetail_ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
 
    }
  
    public partial class AnomalyReports
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AnomalyStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AnomalySource {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LincomID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProjectName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Factory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Caa_Area {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Shift {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkspaceNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkspaceName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ExceptionClassification {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClassDetailed {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Department {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CarType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CarNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Theme {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Description {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Mato_Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Mato_Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Submitter {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime SubmitTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PhoneNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Reason {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Measures {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? CloseTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClosePeople {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string HostResponsiblePerson {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string HostResponsiblePersonPhoneNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AnomalyUpdateResult {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AnomalyUpdateMessage {get;set;}
 
    }
  
    public partial class Anomalys
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Station {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AnomalyTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Content {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class AnomalyTypes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Summary {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int LincomID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string exceptionClassification {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string classDetailed {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string department {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LincomTraceID {get;set;}
 
    }
  
    public partial class AppBinaryObjects
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte[] Bytes {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
 
    }
  
    public partial class Attachments
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid StorageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OriginalName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StorageName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StoragePath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long Size {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Extension {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreateDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class AuditLogs
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ServiceName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MethodName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameters {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ExecutionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ExecutionDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClientIpAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClientName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BrowserInfo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Exception {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? ImpersonatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ImpersonatorTenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CustomData {get;set;}
 
    }
  
    public partial class BackgroundJobs
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string JobType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string JobArgs {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public short TryCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime NextTryTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastTryTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsAbandoned {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Priority {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class BOMLines
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LineNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Component {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BuiltinLocationMandatory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BatchOrFunaceNoMandatory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NormOrMan {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DelStOrMainNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CompQty {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PrvFrm {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProvdedMatTo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReferenceOp {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BomUnit {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SupplPlant {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerNoMandatory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerNoTyp {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DesChCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PrvFrmNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProvdedMatToNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PdmVersion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MandatoryBatch {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DefineSupplier {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? Receive_time {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string description1 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string description2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int VenderQty {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Route {get;set;}
 
    }
  
    public partial class BrakeDiscTraceRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? BalanceTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int BalanceStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? BoltTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int BoltQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int BoltScrapQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double BoltScrapRate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BalanceValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StandardValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? BalanceValueTime {get;set;}
 
    }
  
    public partial class Calendars
    {
        /// <summary>
        /// 
        /// </summary>      
        public int DateKey {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime Date {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Day {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DaySuffix {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Weekday {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WeekDayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsWeekend {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsWorkday {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsHoliday {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string HolidayText {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte DOWInMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public short DayOfYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte WeekOfMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte WeekOfYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte ISOWeekOfYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Month {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MonthName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Quarter {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QuarterName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Year {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MMYYYY {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string YYYYMM {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string YYYYWeek {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string YYYYISOWeek {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MonthYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime FirstDayOfMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LastDayOfMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime FirstDayOfQuarter {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LastDayOfQuarter {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime FirstDayOfYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LastDayOfYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime FirstDayOfNextMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime FirstDayOfNextYear {get;set;}
 
    }
  
    public partial class Capacities
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Yield {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal AccumulateCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal OriginalCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Rate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long Duration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsValid {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? UserShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? MachinesShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? OrderId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? DateKey {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_SolutionName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_StaffShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_MachineShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ShiftDetail_ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsLineOutput {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Tag {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool? Qualified {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? PlanId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PlanName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? PlanAmount {get;set;}
 
    }
  
    public partial class Counter
    {
 
    }
  
    public partial class CraftCards
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ParentId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductElementId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementVersion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CraftCardStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessSequence {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StepworkCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StepworkName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int StepworkSequence {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OperateCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OperateName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateSequence {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CraftCardCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ReleaseTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
 
    }
  
    public partial class CraftFrockSpots
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TeamGroupName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime SpotDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Workstation {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Artisan {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EffectiveDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SpotUserName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DayCheck {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class CraftProcesses
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CraftId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcessCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcessName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessOrder {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsLastProcess {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CraftProcessType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WriteValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double BeatCoefficient {get;set;}
 
    }
  
    public partial class Crafts
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ParentId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementVersion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DrawNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
 
    }
  
    public partial class CutterLoadAndUnloadRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CutterNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterModelId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? CutterTValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperationType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter1 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter3 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter4 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter5 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter6 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter7 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter8 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter9 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter10 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CountingMethod {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OriginalLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int UsedLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RestLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? OperatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? OperatorTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class CutterModels
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CutterNoPrefix {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CountingMethod {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OriginalLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WarningLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter1 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter3 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter4 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter5 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter6 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter7 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter8 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter9 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter10 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class CutterParameters
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class CutterStates
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CutterNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CountingMethod {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterModelId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? CutterTValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterUsedStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterLifeStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RestLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int UsedLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WarningLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter1 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter3 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter4 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter5 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter6 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter7 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter8 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter9 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Parameter10 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OriginalLife {get;set;}
 
    }
  
    public partial class CutterTypes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? PId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CutterNoPrefix {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsCutterNoPrefixCanEdit {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DailyStatesSummaries
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal OfflineDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal FreeDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal TotalDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LastModifyTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? MachinesShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal DebugDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal RunDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal StopDuration {get;set;}
 
    }
  
    public partial class DataDictionaries
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DataDictionaryName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DataDictionaryValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DefectivePartReasons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ReasonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PartId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DefectiveParts
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ParentId {get;set;}
 
    }
  
    public partial class DefectiveReasons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DetectItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DetectItemCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DetectItemName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal NormalValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal NormalValueMax {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal NormalValueMin {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DeviceGroupPermissions
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsGranted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? RoleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Discriminator {get;set;}
 
    }
  
    public partial class DeviceGroups
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ParentId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpGroupId {get;set;}
 
    }
  
    public partial class DeviceGroupYieldMachines
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DiscBrakeTightenDatas
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ModelNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Step {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Process {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BoltNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TorqueSet {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AngleSet {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TorqueAct {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AngleAct {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TorqueData {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AngleData {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OperatorID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? Time {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BatchNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkPointName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TorqueMax {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TorqueMin {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AngleMax {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AngleMin {get;set;}
 
    }
  
    public partial class DmpMachines
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DmpId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Dmps
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ServiceCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WebPort {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string IpAdress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Documents
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ExternalID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DocumentName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DocumentType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DocumentVersion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DocumentDesc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NotificationNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReleaseDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class DriverConfigs
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
 
    }
  
    public partial class Editions
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class EnvironmentMonitorAttachments
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int EnvironmentMonitorId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Path {get;set;}
 
    }
  
    public partial class EnvironmentMonitorDetails
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int EnvironmentMonitorId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Project {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SubProject {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Standard {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Way {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime Time {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DayOfValues {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double MaxValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double MinValue {get;set;}
 
    }
  
    public partial class EnvironmentMonitors
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Number {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Group {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Station {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime DateOfMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Summary {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ErrorLogs
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? Number {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? Serverity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? State {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Line {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Message {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime OccurDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string InParams {get;set;}
 
    }
  
    public partial class Features
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? EditionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Discriminator {get;set;}
 
    }
  
    public partial class FrockToolHistorys
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FrockToolState {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long FrockToolId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int EffectiveTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RelevanceMachine {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RelevanceMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Operation {get;set;}
 
    }
  
    public partial class FrockToolImages
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid ImageGuid {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte[] Bytes {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
 
    }
  
    public partial class FrockTools
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FrockToolTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int EffectiveTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RelevanceMachine {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? BorrowDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ReturnDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FrockToolState {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RelevanceMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid StorageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid? ImageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int IsReportedType {get;set;}
 
    }
  
    public partial class FrockToolStateInfos
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Hexcode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? OriginalCode {get;set;}
 
    }
  
    public partial class FrockToolTypes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class GroupProductPlanOfDay
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DayTargetCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime Date {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Hash
    {
 
    }
  
    public partial class HmiSubmitImages
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid ImageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FilePath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OriginalFileName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long FileLength {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FilExtension {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
 
    }
  
    public partial class HmiSubmitMaterialItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaterialItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string InputValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MaterialItemSerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsVerify {get;set;}
 
    }
  
    public partial class HmiSubmitOperateCommons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CommonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string InputValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
 
    }
  
    public partial class HmiSubmitOperateContents
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
 
    }
  
    public partial class HmiSubmitOperateTools
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ToolId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string InputValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
 
    }
  
    public partial class HmiSubmitStandardItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int StandardItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double InputValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
 
    }
  
    public partial class HmiSubmitUnstandardItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int UnstandardItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string InputValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUserIdList {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoggedUsernameList {get;set;}
 
    }
  
    public partial class InfoLogDetails
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid InfoLogId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Step {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Message {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? AffectedRowCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StratTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Duration {get;set;}
 
    }
  
    public partial class InfoLogs
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? Duration {get;set;}
 
    }
  
    public partial class IPStatistics
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string IPAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SubnetMask {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DefaultGateWay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ItemNoAndMaterialNo
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MaterialCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartTypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MOD {get;set;}
 
    }
  
    public partial class Job
    {
 
    }
  
    public partial class JobLevelPersons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int JobLevelId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PersonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class JobLevels
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class JobParameter
    {
 
    }
  
    public partial class JobQueue
    {
 
    }
  
    public partial class Languages
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Icon {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class LanguageTexts
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LanguageName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Source {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Key {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class List
    {
 
    }
  
    public partial class MachineDefectiveRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Count {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveReasonsId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
 
    }
  
    public partial class MachineDeviceGroups
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DeviceGroupCode {get;set;}
 
    }
  
    public partial class MachineDrivers
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Driver {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool Enable {get;set;}
 
    }
  
    public partial class MachineGatherParams
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DisplayStyle {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SortSeq {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Hexcode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Unit {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double Min {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double Max {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsShowForVisual {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsShowForStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DataType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid? MachineVariableId {get;set;}
 
    }
  
    public partial class MachineOrderUtilizationThresholds
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long OrderId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BlankMaterialCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementVersion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OrderQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LsStartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LsEndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double OrderDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessBeat {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double BeatCoefficient {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double Beat {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineShiftQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal MachineShiftDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double ShiftSolutionCoefficient {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachinePlans
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PlanId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PlanName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartDateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndDateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PlanAmount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsValid {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineProcesses
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ChangeProductUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineProductPlanOfDay
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DayTargetCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime Date {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifiedCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Machines
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Desc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsActive {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SortSeq {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid? ImageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string UId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Password {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Location {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string IPAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ActualEndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ActualStartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ServerUsername {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ServerPassword {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ServerDomain {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AssetCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AssetName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Amount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RunState {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Level {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Tips {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LincomMachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsRealMachinePageShow {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaxAllowedStopHour {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaxAllowedFreeHour {get;set;}
 
    }
  
    public partial class MachineShiftChangeLogs
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Seq {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineShiftEffectiveInterval
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachinesShiftDetails
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineStandardTimes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double MaxValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double StandardValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double MinValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineTeamGroups
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineTypes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Desc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MachineVariables
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Description {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DeviceAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Access {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DataLength {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double ValueFactor {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DefaultValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DataType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Methodparam {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Index {get;set;}
 
    }
  
    public partial class MagneticInspectionInfos
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StandardValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string InputValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
 
    }
  
    public partial class MaintainOrders
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MaintainPlanCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ScheduledDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? MaintainDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Cost {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaintainUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MaintainPlans
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int IntervalDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PersonInChargeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class MaterialBills
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductElementId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Number {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DrawingNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Count {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Summary {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsVerify {get;set;}
 
    }
  
    public partial class MaterialItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaterialBillId {get;set;}
 
    }
  
    public partial class MaterialMaintenances
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Number {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Lot {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Count {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ProductionDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime InvalidDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime BeginDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SPEC {get;set;}
 
    }
  
    public partial class Notices
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Content {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsActive {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RootDeviceGroupCode {get;set;}
 
    }
  
    public partial class NotificationRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int NotificationType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MessageType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MessageContent {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long NoticedUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
 
    }
  
    public partial class NotificationRuleDetails
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int NotificationRuleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TriggerCondition {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsEnabled {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NoticeUserIds {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftId {get;set;}
 
    }
  
    public partial class NotificationRules
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MessageType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TriggerType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DeviceGroupIds {get;set;}
 
    }
  
    public partial class Notifications
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NotificationName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Data {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DataTypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityTypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityTypeAssemblyQualifiedName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Severity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string UserIds {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ExcludedUserIds {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TenantIds {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class NotificationSubscriptions
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NotificationName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityTypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityTypeAssemblyQualifiedName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class NotificationTypes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ParentId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class OnlineAndOfflineLogs
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime OnlineDateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? OfflineDateTime {get;set;}
 
    }
  
    public partial class OperateCommons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CommonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class OperateContents
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid OperateImageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OperateImageName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OperateText {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OperateImageExtension {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyRequirement {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyGrade {get;set;}
 
    }
  
    public partial class OperateTools
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long ToolId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Operations
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OpNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OpDesc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkCenterNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MesWTQuota {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OpeationType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualityGateOp {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MandatoryCheck {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string HandoverOp {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SapWc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SapWcName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FactoryRoutine {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StandardKeyText {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OpRank {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PdmVersion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RequiredPerson {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductionLine {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProdLineDesc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductionNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Repair {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RepairNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MesWc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MesWcName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StoppointExisting {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LsStartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LsEndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkPlace {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StepXml {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DeleteFlag {get;set;}
 
    }
  
    public partial class Orders
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DrawNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StockLocation {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemSerialNumberMandatory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerNoTyp {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OrderType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OrderQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReleaseCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReleaseDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MESRoutingID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WBS {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OrderOrigin {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProjectElement {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LsStartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime LsEndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TrainNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProjectName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CarriageType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProjectNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NoticeNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BomExplosion {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CarriageNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MesBomId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SapItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SapItemDesc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Rework {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WbsProjectNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EngChange {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EngChangeDesc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? Receive_time {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ActualStartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ActualEndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OrderStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OrderFromType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OrderCategory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CompletedQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Component {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductionLine {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SFCStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FCSStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SNQty {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OpQty {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int BOMLineQty {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DocumentQty {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OnlineQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RealQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ThresholdValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AppliedQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TotalQuantity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ProductElementArriveTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int IsReportedType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double BeatCoefficient {get;set;}
 
    }
  
    public partial class OrderSpotInspectionLists
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long OrderId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OrderSpotInspectionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class OrderSpotInspections
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OrderSpotInspectionCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OrderSpotInspectionName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OrderSpotInspectionMemo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class OrganizationUnits
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? ParentId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ParameterForStaticUnbalances
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StaticUnbalanceValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StaticUnbalancePlace {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long TraceFlowRecordId {get;set;}
 
    }
  
    public partial class PartDefects
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectivePartId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveReasonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveMachineId {get;set;}
 
    }
  
    public partial class PartsOnlineRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsComplete {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Component {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MOD {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PartQualifyStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PartFlowStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsRework {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SpecimenId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SpecimenBatchNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SpecimenIndex {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsSpecimen {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SpecimenResult {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Component2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int InspectionStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CodeContent {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ApplyForOutboundID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OutboundWheelQRCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ChangedWheelQRCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? MakeDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifyInspectionStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? QualifyInspectionUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? QualifyInspectionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifyValidationStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyWheelReportPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyBrakeDiscReportPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyDenoiseReportPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyDampRingReportPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualifyWheelSpecimenReportPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PartInspectStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ReCheck {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? QualifyValidationUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? QualifyValidationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsLockingTag {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LockingTagCreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LockingTagLoginUserStaffId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsUploadToESB {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? UplaodToESBCreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftBatchNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsUploadToESB2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? UplaodToESBCreationTime2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int IsReportedType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int InspectionReportType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ValidationReportType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsPurchasedPart {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifyInspectionStatus2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? QualifyInspectionUserId2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? QualifyInspectionTime2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifyValidationStatus2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? QualifyValidationUserId2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? QualifyValidationTime2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PartInspectStatus2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ReCheck2 {get;set;}
 
    }
  
    public partial class PassRate
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double QualifiedCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class PerformancePersonnelOnDevice
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime OnlineDate {get;set;}
 
    }
  
    public partial class Permissions
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsGranted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? RoleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Discriminator {get;set;}
 
    }
  
    public partial class Plans
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartDateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndDateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PlanAmount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OutputAmount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal CompletionRate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class PlanTargets
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ProcessPlan_Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftTargetAmount {get;set;}
 
    }
  
    public partial class PPMRelation
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal StandardCostTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Process
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal StandardCostTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WriteValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LincomProcessCode {get;set;}
 
    }
  
    public partial class ProcessMachines
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ProcessPlans
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PlanName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PlanCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PlanAmount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsTimeRangeSelect {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? PlanStartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? PlanEndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? RealStartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? RealEndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsAutoFinishCurrentPlan {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsAutoStartNextPlan {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TargetType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TargetAmount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int YieldSummaryType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int YieldCounterMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessAmount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? PauseTime {get;set;}
 
    }
  
    public partial class ProductElements
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductElementName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DrawNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string VehicleType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FileNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StaticBalanceStandardValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsInspect {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsVerify {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double SameDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string State {get;set;}
 
    }
  
    public partial class ProductGroups
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ProductionPlans
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OrderCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PutVolume {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AimVolume {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Unit {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClientName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CraftId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductionPlanState {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ActualStartDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ActualEndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifiedCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
 
    }
  
    public partial class ProductionProcesses
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FlowState {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Location {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FlowTag {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? RequestStartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? RequestEndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? MachineStartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? MachineEndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DMPDescription {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ResultParameter {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ReadReportStatus {get;set;}
 
    }
  
    public partial class Products
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Spec {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Desc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string IsHalfFinished {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MaterialNo {get;set;}
 
    }
  
    public partial class ProductTypeMapRelationOnCL
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Number {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductType {get;set;}
 
    }
  
    public partial class QesUploadRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SendMessage {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReceiveMessage {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BackupPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class QualifyTemplateTeamGourps
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifyTemplateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class QualityTemplates
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MaterialNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProductName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SureTableName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FileNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FigureNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Version {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Company {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Factory {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
 
    }
  
    public partial class ReasonFeedbackRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int StateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StateCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? EndUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Duration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class RepairRequests
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime RequestDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RequestUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RequestMemo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? RepairDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? RepairUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsShutdown {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Cost {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RepairMemo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ReportAttachments
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid StorageId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string OriginalName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StorageName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StoragePath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long Size {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Extension {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreateDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ReportType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long TraceFlowRecordId {get;set;}
 
    }
  
    public partial class ReportForCMMs
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Component {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReportReadPath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ReportStorePath {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Temperature {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Humidity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Description {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StandardValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MaxValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MinValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DeviationValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DeviationValuePercent {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long TraceFlowRecordId {get;set;}
 
    }
  
    public partial class Roles
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsStatic {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDefault {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Schema
    {
 
    }
  
    public partial class Server
    {
 
    }
  
    public partial class Set
    {
 
    }
  
    public partial class Settings
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ShiftHistories
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ShiftSolutionItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Duration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsNextDay {get;set;}
 
    }
  
    public partial class ShiftSolutions
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double ShiftSolutionCoefficient {get;set;}
 
    }
  
    public partial class ShiftTargetYileds
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TargetYiled {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class ShortcutMenus
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Menu_DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Menu_Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Menu_Icon {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Menu_Url {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
 
    }
  
    public partial class SNs
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SNStatus {get;set;}
 
    }
  
    public partial class Specimens
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool Enabled {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class StandardItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double MaxValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double StandardValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double MinValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Unit {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class StandardTime
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal StandardCostTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CycleRate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal MachineLoadTimeRange {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal MachineWorkTimeRange {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal MachineDownTimeRange {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessBeat {get;set;}
 
    }
  
    public partial class State
    {
 
    }
  
    public partial class StateInfos
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Hexcode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? OriginalCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsPlaned {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsStatic {get;set;}
 
    }
  
    public partial class States
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Duration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Memo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? UserShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? MachinesShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? OrderId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? DateKey {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_SolutionName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_StaffShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDetail_MachineShiftName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? ShiftDetail_ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsShiftSplit {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
 
    }
  
    public partial class SyncDataFlags
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcessName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LastSyncTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int LastSyncCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TotalCount {get;set;}
 
    }
  
    public partial class TeamGroupPersons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long PersonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class TeamGroups
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Desc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long MonitorId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TeamGroupNo {get;set;}
 
    }
  
    public partial class TeamInfo
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TeamGroupName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TeamStaffCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class TenantNotifications
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string NotificationName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Data {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DataTypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityTypeName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityTypeAssemblyQualifiedName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EntityId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Severity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Tenants
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? EditionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsActive {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TenancyName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ConnectionString {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? Tenant_Id {get;set;}
 
    }
  
    public partial class ThirdpartyApis
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Url {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class TraceCatalogs
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime OnlineTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? OfflineTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool? Qualified {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool? IsReworkPart {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineShiftDetailId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PlanId {get;set;}
 
    }
  
    public partial class TraceFlowRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FlowCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FlowDisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TraceFlowSettingId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Station {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EntryTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LeftTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int State {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Tag {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ExtensionData {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
 
    }
  
    public partial class TraceFlowSettings
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DisplayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? PreFlowId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? NextFlowId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FlowType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int StationType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TriggerEndFlowStyle {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool WriteIntoPlcViaFlow {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool WriteIntoPlcViaFlowData {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? QualityMakerFlowId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool NeedHandlerRelateData {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SourceOfPartNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ExtensionData {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class TraceRelatedMachines
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TraceFlowSettingId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkingStationCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkingStationDisplayName {get;set;}
 
    }
  
    public partial class UnstandardItems
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OperateId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class UserAccounts
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? UserLinkId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string UserName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EmailAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastLoginTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class UserClaims
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClaimType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClaimValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class UserInfos
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Sex {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PlantCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? Birthday {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Position {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TrainContent {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? CertificateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CertificateCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CertificateProcess {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Transfer {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TrainTime {get;set;}
 
    }
  
    public partial class UserLoginAttempts
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TenancyName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string UserNameOrEmailAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClientIpAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ClientName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BrowserInfo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public byte Result {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
 
    }
  
    public partial class UserLogins
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LoginProvider {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProviderKey {get;set;}
 
    }
  
    public partial class UserNotifications
    {
        /// <summary>
        /// 
        /// </summary>      
        public Guid Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid TenantNotificationId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int State {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
 
    }
  
    public partial class UserOrganizationUnits
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long OrganizationUnitId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class UserProcess
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcessCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcessName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcessIds {get;set;}
 
    }
  
    public partial class UserRoles
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RoleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class Users
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid? ProfilePictureId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WeChatId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool ShouldChangePasswordOnNextLogin {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AuthenticationSource {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Surname {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Password {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsEmailConfirmed {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EmailConfirmationCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PasswordResetCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LockoutEndDateUtc {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AccessFailedCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsLockoutEnabled {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PhoneNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsPhoneNumberConfirmed {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SecurityStamp {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsTwoFactorEnabled {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsActive {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string UserName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TenantId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string EmailAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastLoginTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StaffId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WorkerAttribute {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Sex {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PlantCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? Birthday {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Position {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TrainTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TrainContent {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? CertificateTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CertificateCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CertificateProcess {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Transfer {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int BrakeDiscAuthority {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EntryDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CommitteePosition {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime OnJobBeginDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? OnJobEndDate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string IGMetall {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string HazardIdentifyTeam {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QCTeam {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string StationHeader {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Summary {get;set;}
 
    }
  
    public partial class VenderLines
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FeedbackNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string LineNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Vender {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string VenderName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class WarehouseComingOrOutings
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string WarehouseID {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SerialNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ItemNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string BillNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? State {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string SameDuration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string AssembleSameStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PressSameStatus {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string TechnicalNotice {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ActionType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ActionSource {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string VenderNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string DelStOrMainNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string QualityState {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double? HoleSize {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double? WheelDiameterValue {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double? Size1 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double? Size2 {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public double? StaticBalanceValue {get;set;}
 
    }
  
    public partial class WeChatNotifications
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int NotificationTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsActive {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class WorkOrderDefectiveRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveReasonsId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Count {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WorkOrderTaskId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class WorkOrders
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProcessId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ProductionPlanId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PutVolume {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int AimVolume {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifiedCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OutputCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int State {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal CompletionRate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsLastProcessOrder {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class WorkOrderTasks
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WorkOrderId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long UserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int QualifiedCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DefectiveCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int OutputCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class WorkTypePersons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int WorkTypeId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PersonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
  
    public partial class WorkTypes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Code {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsDeleted {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? DeleterUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? DeletionTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime? LastModificationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? LastModifierUserId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime CreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long? CreatorUserId {get;set;}
 
    }
}
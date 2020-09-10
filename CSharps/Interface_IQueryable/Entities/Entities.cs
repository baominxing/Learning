

//------------------------------------------------------------------------------
// 生成时间 2020-08-23 11:10:51 by fred.bao
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface_IQueryable
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
        /// <summary>
        /// 
        /// </summary>      
        public string MongoCreationTime {get;set;}
 
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
  
    public partial class CalibratorCodes
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CartonRuleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Key {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
 
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
        /// <summary>
        /// 
        /// </summary>      
        public string MongoCreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpId {get;set;}
 
    }
  
    public partial class CartonRecords
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CartonNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CartonId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartNo {get;set;}
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
  
    public partial class CartonRuleDetails
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CartonRuleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int SequenceNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Length {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ExpansionKey {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Value {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int StartIndex {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int EndIndex {get;set;}
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
  
    public partial class CartonRules
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
        public bool IsActive {get;set;}
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
  
    public partial class Cartons
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CartonNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DeviceGroupId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaxPackingCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int RealPackingCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int PrintLabelCount {get;set;}
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
  
    public partial class CartonSerialNumbers
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
        public int Status {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int DateKey {get;set;}
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
  
    public partial class CartonSettings
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
        public int MaxPackingCount {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsPrint {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PrinterName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool AutoCartonNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CartonRuleId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsGoodOnly {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsAutoPrint {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool ForbidHopSequence {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool ForbidRepeatPacking {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsUnpackingRedo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsUnpackingAfterPrint {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsFinalTest {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool HasToFlow {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FlowIds {get;set;}
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
  
    public partial class Counter
    {
 
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
 
    }
  
    public partial class CustomFields
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
        public int DisplayType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsRequired {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int MaxLength {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string HtmlTemplate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Remark {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string RenderHtml {get;set;}
 
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
        /// <summary>
        /// 
        /// </summary>      
        public int Rate {get;set;}
 
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
  
    public partial class FlexibleCraftProcedureCutterMaps
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
        public int CraftProcesseId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProcedureNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CutterId {get;set;}
 
    }
  
    public partial class FlexibleCraftProcesseMaps
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
        public int CraftProcesseId {get;set;}
 
    }
  
    public partial class FlexibleCraftProcesses
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
        public int Sequence {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int TongId {get;set;}
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
  
    public partial class FlexibleCrafts
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
        public string Name {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Version {get;set;}
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
  
    public partial class FmsCutterExtends
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int FmsCutterId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CustomFieldId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string FieldValue {get;set;}
 
    }
  
    public partial class FmsCutters
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? MachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CutterNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CutterCase {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Length {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal Diameter {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string CompensateNo {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal LengthCompensate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal DiameterCompensate {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal OriginalLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal CurrentLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public decimal WarningLife {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int UseType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int CountType {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int State {get;set;}
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
        public string CutterStockNo {get;set;}
 
    }
  
    public partial class FmsCutterSettings
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
        public int Seq {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int Type {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public bool IsShow {get;set;}
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
  
    public partial class Job
    {
 
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
        /// <summary>
        /// 
        /// </summary>      
        public bool IsShowForParam {get;set;}
 
    }
  
    public partial class MachineNetConfigs
    {
        /// <summary>
        /// 
        /// </summary>      
        public int Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string MachineCode {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpMachineId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string IpAddress {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int? TcpPort {get;set;}
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
        public string DrawingNumber {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string PartType {get;set;}
 
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
  
    public partial class ShiftCalendars
    {
        /// <summary>
        /// 
        /// </summary>      
        public long Id {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftSolutionId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftItemId {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftItemSeq {get;set;}
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
        public DateTime StartTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime EndTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public long Duration {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public DateTime ShiftDay {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftDayName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftWeek {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftWeekName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftMonth {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftMonthName {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public int ShiftYear {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ShiftYearName {get;set;}
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
        /// <summary>
        /// 
        /// </summary>      
        public string MongoCreationTime {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public Guid DmpId {get;set;}
 
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
  
    public partial class Tongs
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
        public int Capacity {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramA {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramB {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramC {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramD {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramE {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string ProgramF {get;set;}
        /// <summary>
        /// 
        /// </summary>      
        public string Note {get;set;}
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
        /// <summary>
        /// 
        /// </summary>      
        public int FlowSeq {get;set;}
 
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
}


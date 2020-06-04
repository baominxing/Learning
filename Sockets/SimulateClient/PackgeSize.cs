namespace MDCDataService
{
    /// <summary>
    /// 在协议中已确定长的的包的Size
    /// </summary>
    public class PackgeSize
    {
        public const int CommandSize = 8;
        //连接确认Size
        public const int EnsurePackageSize = 32;
        //登录包Size
        public const int LoginPackageSize = 16;
        //设备自举包Size
        public const int MacBootstrapPackageSize = 40;
        //枚举数据项Size
        public const int EnumDataPackageSize = 104;
        //请求推送包Size
        public const int RequestPushPackageSize = 16;
        //返回结果Size
        public const int ErrorPackageSize = 16;
    }
}

namespace MDCSingleDLL.Protocol
{
    public enum ErrorLevel
    {
        /// <summary>
        /// 会话内错误，只需要记录到库里
        /// </summary>
        Level1,
        /// <summary>
        /// 程序错误，需要记录到库里，可以考虑发送邮件
        /// </summary>
        Level2
    }

    public static class MessageType
    {
        public static string Send = "[发  送] ";
        public static string Receive = "[接  收] ";
        public static string KeepAlive = "[心跳包] ";
        public static string Login = "[登  陆] ";
        public static string RequireDataItem = "[请求项] ";
        public static string ResponseDataItem = "[接收项] ";
        public static string Error = "[错  误] ";
        public static string OffLine = "[断  线] ";
        public static string OverTime = "[超  时] ";
        public static string Info = "[信  息] ";
    }

    public enum DataType
    {
        String,
        Double,
        Int32,
        Bit,
        Bool,
        ByteArray
    }
}

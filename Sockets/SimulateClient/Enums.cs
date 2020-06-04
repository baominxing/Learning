namespace MDCDataService
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
}

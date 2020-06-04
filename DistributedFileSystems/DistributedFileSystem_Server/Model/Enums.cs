using System.ComponentModel;

namespace FileCenter.Model
{
    /// <summary>
    /// 文件压缩状态
    /// </summary>
    public enum EnumFileCompressStatus
    {
        /// <summary>
        /// 未压缩
        /// </summary>
        Uncompressed = 0,

        /// <summary>
        /// 压缩中
        /// </summary>
        Compressing = 1,

        /// <summary>
        /// 已压缩
        /// </summary>
        Compressed = 2,

        /// <summary>
        /// 解压中
        /// </summary>
        Depressing = 3,

        /// <summary>
        /// 已解压
        /// </summary>
        Depressed = 4
    }

    /// <summary>
    /// 操作结果
    /// </summary>
    public enum EnumOperateResult
    {
        Success = 1,
        Failure = 2
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum EnumOperateType
    {
        /// <summary>
        /// 文件归档
        /// </summary>
        FileArchive = 1,

        /// <summary>
        /// 图片压缩
        /// </summary>
        ImageCompress = 2
    }

    /// <summary>
    /// 归档日期类型
    /// </summary>
    public enum EnumArchivePeriod
    {
        [Description("不需要归档")]
        Never = 0,

        /// <summary>
        /// 一个月按30天算
        /// </summary>
        [Description("按月归档")]
        Month = 30,

        /// <summary>
        /// 一个季度按90天算
        /// </summary>
        [Description("按季度归档")]
        Quarter = 90,
    }
}
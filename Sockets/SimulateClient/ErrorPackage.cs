using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MDCDataService
{
    /// <summary>
    /// 错误包结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ErrorPackage
    {
        ///// <summary>
        ///// 2字节，请求标识，该字段由发起端给出回复时需要使用值填充
        ///// </summary>
        //public ushort PID;
        ///// <summary>
        ///// 2字节，命令标识取常值 0x5549
        ///// </summary>
        //public ushort CID;
        ///// <summary>
        ///// 1字节，用户标识硬件设备中置的ID
        ///// </summary>
        //public sbyte UID;
        ///// <summary>
        ///// 1字节 整数 ，表示是否出错 ，[1=ACK,0=ERR]
        ///// </summary>
        //public sbyte ST;
        ///// <summary>
        ///// 2字节，协议版本号 1000
        ///// </summary>
        //public ushort VER;
        /// <summary>
        /// 4字节，错误码参考表
        /// </summary>
        public uint ERR;
        /// <summary>
        /// ：4字节，保留取常值 0x000000000
        /// </summary>
        public uint RV;
    };
    /// <summary>
    /// 错误包结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ErrorPackage2
    {
        /// <summary>
        /// 2字节，请求标识，该字段由发起端给出回复时需要使用值填充
        /// </summary>
        public ushort PID;
        /// <summary>
        /// 2字节，命令标识取常值 0x5549
        /// </summary>
        public ushort CID;
        /// <summary>
        /// 1字节，用户标识硬件设备中置的ID
        /// </summary>
        public sbyte UID;
        /// <summary>
        /// 1字节 整数 ，表示是否出错 ，[1=ACK,0=ERR]
        /// </summary>
        public sbyte ST;
        /// <summary>
        /// 2字节，协议版本号 1000
        /// </summary>
        public ushort VER;
        /// <summary>
        /// 4字节，错误码参考表
        /// </summary>
        public uint ERR;
        /// <summary>
        /// ：4字节，保留取常值 0x000000000
        /// </summary>
        public uint RV;
    };
}

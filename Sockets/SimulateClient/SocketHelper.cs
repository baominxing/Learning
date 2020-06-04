using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MDCDataService
{
    public class SocketHelper
    {
        #region 结构体和Byte数组转换
        public static byte[] StructToBytes(object structObj)
        {
            int size = Marshal.SizeOf(structObj);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structObj, buffer, false);
                byte[] bytes = new byte[size];
                Marshal.Copy(buffer, bytes, 0, size);
                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static T BytesToStruct<T>(byte[] bytes) where T : struct
        {
            T str = new T();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(bytes, 0, ptr, size);

            str = (T)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }
        #endregion

        #region 字节序转换
        private static bool _isBigEndian;
        private static bool _isEndianChecked = false;
        private static bool IsBigEndian()
        {
            if (!_isEndianChecked)
            {
                _isEndianChecked = true;
                int nCheck = 0x01aa;
                _isBigEndian = (nCheck & 0xff) == 0x01;
            }
            return _isBigEndian;
        }
        public static uint HostToNetwork(uint i)
        {
            if (IsBigEndian())
                return i;
            return (i & 0xff) << 24 |
                   (i & 0xff00) << 8 |
                           (i >> 8) & 0xff00 |
                   (i >> 24) & 0xff;
        }

        public static uint NetworkToHost(uint i)
        {
            return HostToNetwork(i);
        }

        public static ushort HostToNetwork(ushort i)
        {
            if (IsBigEndian())
                return i;
            return (ushort)((((i & 0xff) << 8) | ((i & 0xff00) >> 8)) & 0x0000FFFF);
        }

        public static ushort NetworkToHost(ushort i)
        {
            return HostToNetwork(i);
        }

        public static int HostToNetwork(int i)
        {
            return (int)NetworkToHost((uint)i);
        }

        public static int NetworkToHost(int i)
        {
            return HostToNetwork(i);
        }

        public static short HostToNetwork(short i)
        {
            return (short)NetworkToHost((ushort)i);
        }

        public static short NetworkToHost(short i)
        {
            return HostToNetwork(i);
        }
        #endregion
    }
}

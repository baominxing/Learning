using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDCParseDataItem
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            cob_Type.Items.Add(new ComboBoxItem() { Text = "字符串", Value = "0" });
            cob_Type.Items.Add(new ComboBoxItem() { Text = "双精度浮", Value = "1" });
            cob_Type.Items.Add(new ComboBoxItem() { Text = "32位整数", Value = "2" });
            cob_Type.Items.Add(new ComboBoxItem() { Text = "字节", Value = "3" });
            cob_Type.Items.Add(new ComboBoxItem() { Text = "布尔值", Value = "4" });
            cob_Type.Items.Add(new ComboBoxItem() { Text = "字节块", Value = "5" });
            cob_Type.DisplayMember = "Text";
            cob_Type.ValueMember = "Value";
        }

        private void btn_Parse_Click(object sender, EventArgs e)
        {
            try
            {

                var id = this.cb_IsAlarmText.Checked ? (ushort)2 : (ushort)0;
                var type = Convert.ToByte(((ComboBoxItem)this.cob_Type.SelectedItem).Value);
                var value = GetByteArraysFromInputString(this.richTextBox1.Text);
                var item = new DataItem() { Id = id, Type = type, Value = value };
                this.richTextBox2.Text = GetValueByType(item).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private byte[] GetByteArraysFromInputString(string originalValue)
        {
            var bytesString = originalValue.Split(',');
            var bytes = new List<byte>();
            foreach (var s in bytesString)
            {
                bytes.Add(Convert.ToByte(s));
            }

            return bytes.ToArray();
        }

        private static object GetValueByType(DataItem item)
        {
            object result = null;
            switch (item.Type & 0x0F)
            {
                case 0:
                    if (item.Id == 2)
                    {
                        var tempBytes = new List<byte>();
                        foreach (var t in item.Value)
                        {
                            if (t == 0)
                            {
                                break;
                            }
                            tempBytes.Add(t);
                        }
                        result = Encoding.GetEncoding("GB2312").GetString(tempBytes.ToArray()).Trim('\0').Trim();
                    }
                    else
                    {
                        var tempBytes = new List<byte>();
                        foreach (var t in item.Value)
                        {
                            if (t == 0)
                            {
                                break;
                            }
                            tempBytes.Add(t);
                        }
                        result = Encoding.ASCII.GetString(tempBytes.ToArray()).Trim('\0').Trim();
                    }
                    break;
                case 1:
                    if (item.Value.Length < 8)
                    {
                        throw new Exception("尝试转换为double数据失败，长的为" + item.Value.Length);
                    }
                    result = BitConverter.ToDouble(item.Value, 0);
                    break;
                case 2:
                    result = NetworkToHost(BitConverter.ToInt32(item.Value, 0));
                    break;
                case 3:
                    result = item.Value[0];
                    break;
                case 4:
                    result = item.Value[0];
                    break;
                case 5:
                    result = item.Value;
                    break;
                default:
                    result = BitConverter.ToString(item.Value);
                    break;
            }
            return result;
        }

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

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }

    #region 数据项持久化对象
    public class DataItem
    {
        public ushort Id { get; set; }
        public byte Type { get; set; }
        public byte[] Value { get; set; }
    }
    #endregion
}

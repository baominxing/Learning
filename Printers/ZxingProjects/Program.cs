using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Datamatrix;
using ZXing.QrCode;

namespace ZxingProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //演示用Zxing生成二维码
            Sample1.Demonstration();

            //演示用Zxing生成二维码
            //Sample2.Demonstration();
        }
    }

    public class Sample1
    {
        public static void Demonstration()
        {
            // 箱码信息的base64位字符串
            string base64Carton = string.Empty;

            //获取设定的二维码的尺寸信息(默认18)
            int QRCodeHeight = 70;
            int QRCodeWidth = 70;

            // 1.设置二维码规格
            DatamatrixEncodingOptions encodeOption = new DatamatrixEncodingOptions
            {
                Height = QRCodeHeight, // 必须指定高度、宽度
                Width = QRCodeWidth,
                PureBarcode = true,
                Margin = 1,
        };

            // 2.生成二维码图片并保存
            BarcodeWriter wr = new BarcodeWriter
            {
                Options = encodeOption,
                Format = BarcodeFormat.QR_CODE //二维码类型
            };

            var content = "111111111-20C1601";
            using (Bitmap img = wr.Write(content))
            {

                img.Save($"{DateTime.Now.ToString("yyyyMMddHHmmss")}.png", ImageFormat.Png);
            }
        }
    }

    public class Sample2
    {
        public static void Demonstration()
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = 70;
            options.Height = 70;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            using (Bitmap img = writer.Write("111111111-20C1601"))
            {
                img.Save($"{DateTime.Now.ToString("yyyyMMddHHmmss")}.png", ImageFormat.Png);
            }
        }
    }
}

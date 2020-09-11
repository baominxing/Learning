using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //图片二值化处理
                Sample1.Demonstration();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.ReadKey();
        }
    }

    class Sample1
    {
        public static readonly int Sensibility = 1;

        internal static void Demonstration()
        {
            var imagePath = "tapd_42228403_base64_1599741515_62.png";
            Bitmap image = new Bitmap(imagePath);

            #region 简单暴利
            int w = image.Width;
            int h = image.Height;
            Color c;
            Color white = Color.White;
            int r, g, b;
            for (int y = 0; y < h; ++y)
            {
                for (int x = 0; x < w; ++x)
                {
                    c = image.GetPixel(x, y);
                    r = c.R;
                    g = c.G;
                    b = c.B;
                    if (r + g + b >= 32)//将图片像素的rgb偏离黑色0超过32的值设置为白色
                    {
                        image.SetPixel(x, y, white);
                    }
                }
            }
            #endregion


            image.Save("tapd_42228403_base64_1599741515_62_GrayImg.png");
        }

        #region 不安全方法
        public static unsafe Bitmap Img2Gray(Bitmap curBitmap)
        {
            int width = curBitmap.Width;
            int height = curBitmap.Height;
            Bitmap back = new Bitmap(width, height);
            byte temp;
            Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
            //这种速度最快
            BitmapData bmpData = curBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);//24位rgb显示一个像素，即一个像素点3个字节，每个字节是BGR分量。Format32bppRgb是用4个字节表示一个像素
            byte* ptr = (byte*)(bmpData.Scan0);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    //ptr[2]为r值，ptr[1]为g值，ptr[0]为b值
                    temp = (byte)(0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0]);
                    back.SetPixel(i, j, Color.FromArgb(temp, temp, temp));
                    ptr += 3; //Format24bppRgb格式每个像素占3字节
                }
                ptr += bmpData.Stride - bmpData.Width * 3;//每行读取到最后“有用”数据时，跳过未使用空间XX
            }
            curBitmap.UnlockBits(bmpData);
            return back;
        }

        public static int GetIndex(int location, int length)
        {
            return location * Sensibility / length;
        }

        public static Bitmap Gray2Binaryzation(Bitmap GrayImg)
        {
            int width = GrayImg.Width;
            int height = GrayImg.Height;
            Bitmap back = new Bitmap(width, height);

            //灰度矩阵初始化
            Int64[,] GrayScale = new Int64[Sensibility, Sensibility];
            for (int i = 0; i < Sensibility; i++)
            {
                for (int j = 0; j < Sensibility; j++)
                {
                    GrayScale[i, j] = 0;
                }
            }

            //计算灰度矩阵阈值，17/20为阈值调整，取0.85时效果最好；
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    GrayScale[GetIndex(i, width), GetIndex(j, height)] += GrayImg.GetPixel(i, j).R;
                }
            }
            for (int i = 0; i < Sensibility; i++)
            {
                for (int j = 0; j < Sensibility; j++)
                {
                    GrayScale[i, j] = GrayScale[i, j] / width * Sensibility / height * Sensibility * 17 / 20;
                }
            }

            //二值化赋值,大于灰度矩阵阈值的描黑，否则描白。
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (GrayImg.GetPixel(i, j).R >= GrayScale[GetIndex(i, width), GetIndex(j, height)])
                        back.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    else
                        back.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
            return back;
        }
        #endregion

        #region 安全方法
        private static Bitmap ImageToBitmap(byte[] data)
        {
            var bitmap = new Bitmap(256, 288, PixelFormat.Format32bppArgb);
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bitmap.Width * bitmap.Height * 4;
            byte[] rgbValues = new byte[bytes];
            int x = 0, y = 0;
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                byte c, a;
                int idx = x + y * bitmap.Width;
                if (idx < data.Length)
                {
                    c = data[idx];
                    x++;
                    if (x >= bitmap.Width)
                    {
                        x = 0;
                        y++;
                    }
                    if (c == 255)
                        a = 0;
                    else
                        a = 255;
                }
                else
                {
                    c = 255;
                    a = 255;
                }

                rgbValues[i] = c;
                rgbValues[i + 1] = c;
                rgbValues[i + 2] = c;
                rgbValues[i + 3] = a;
            }
            Marshal.Copy(rgbValues, 0, ptr, bytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        #endregion

    }
}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FileCenter
{
    public class CompressManager
    {
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="imageData">图片内容</param>
        /// <param name="flag">质量 0-100</param>
        /// <param name="size">压缩的最大长度</param>
        /// <returns></returns>
        public byte[] CompressImage(byte[] imageData, int flag = 80, int size = 500, bool isFirst = true)
        {
            try
            {
                if (!isFirst && imageData.Length < 1024 * size)
                {
                    return imageData;
                }
                using (MemoryStream msImage = new MemoryStream(imageData))
                {
                    Image iSource = Image.FromStream(msImage);
                    ImageFormat tFormat = iSource.RawFormat;

                    Bitmap ob = new Bitmap(iSource.Width, iSource.Height);
                    Graphics g = Graphics.FromImage(ob);

                    g.Clear(Color.WhiteSmoke);
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(iSource, new Rectangle(0, 0, iSource.Width, iSource.Height), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

                    g.Dispose();

                    //以下代码为保存图片时，设置压缩质量
                    EncoderParameters ep = new EncoderParameters();
                    long[] qy = new long[1];
                    qy[0] = flag;//设置压缩的比例1-100
                    EncoderParameter eParam = new EncoderParameter(Encoder.Quality, qy);
                    ep.Param[0] = eParam;

                    try
                    {
                        ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                        ImageCodecInfo jpegICIinfo = null;
                        for (int x = 0; x < arrayICI.Length; x++)
                        {
                            if (arrayICI[x].FormatDescription.Equals("JPEG"))
                            {
                                jpegICIinfo = arrayICI[x];
                                break;
                            }
                        }
                        byte[] bytes = null;
                        if (jpegICIinfo != null)
                        {
                            using (var msResult = new MemoryStream())
                            {
                                ob.Save(msResult, jpegICIinfo, ep);
                                bytes = new byte[msResult.Length];
                                msResult.Seek(0, SeekOrigin.Begin);
                                msResult.Read(bytes, 0, bytes.Length);
                            }

                            //if (bytes.Length > 1024 * size)
                            //{
                            //    flag = flag - 10;
                            //    bytes = CompressImage(bytes, flag, size, false);
                            //}
                        }
                        else
                        {
                            using (var msResult = new MemoryStream())
                            {
                                ob.Save(msResult, tFormat);
                                bytes = new byte[msResult.Length];
                                msResult.Read(bytes, 0, bytes.Length);
                            }
                        }

                        return bytes;
                    }
                    catch
                    {
                        return null;
                    }
                    finally
                    {
                        iSource.Dispose();
                        ob.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCompareProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new SimilarPhoto(@"E:\workspace\projects\青岛四方焊接线\documents\反馈文件\指纹相关\指纹1.jpg").GetHash();
            var b = new SimilarPhoto(@"E:\workspace\projects\青岛四方焊接线\documents\反馈文件\指纹相关\指纹4.jpg").GetHash();

            var r = SimilarPhoto.CalcSimilarDegree(a, b);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    class SimilarPhoto
    {
        Image SourceImg;

        public SimilarPhoto(string filePath)
        {
            SourceImg = Image.FromFile(filePath);
        }

        public SimilarPhoto(Stream stream)
        {
            SourceImg = Image.FromStream(stream);
        }

        public String GetHash()
        {
            Image image = ReduceSize();
            Byte[] grayValues = ReduceColor(image);
            Byte average = CalcAverage(grayValues);
            String reslut = ComputeBits(grayValues, average);
            return reslut;
        }

        //        Step 1 : Reduce size to 16*16
        private Image ReduceSize(int width = 256, int height = 288)
        {
            Image image = SourceImg.GetThumbnailImage(width, height, () => { return false; }, IntPtr.Zero);
            return image;
        }

        //        Step 2 : Reduce Color
        private Byte[] ReduceColor(Image image)
        {
            Bitmap bitMap = new Bitmap(image);
            Byte[] grayValues = new Byte[image.Width * image.Height];

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = bitMap.GetPixel(x, y);
                    byte grayValue = (byte)((color.R * 30 + color.G * 59 + color.B * 11) / 100);
                    grayValues[x * image.Width + y] = grayValue;
                }
            }
            return grayValues;
        }

        //        Step 3 : Average the colors
        private Byte CalcAverage(byte[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += (int)values[i];
            }

            return Convert.ToByte(sum / values.Length);
        }

        //        Step 4 : Compute the bits
        private String ComputeBits(byte[] values, byte averageValue)
        {
            char[] result = new char[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < averageValue)
                    result[i] = '0';
                else
                    result[i] = '1';
            }

            return new String(result);
        }

        //        Compare hash
        public static Int32 CalcSimilarDegree(string a, string b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException();
            }

            int count = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                    count++;
            }

            return count;
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace ExcelToPdf
{
    class Program
    {
        public static HttpListener listener = new HttpListener();
        public static string startUpPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);//E:\demo\csharps\Tool_ExcelToPdf\App
        public static string excelPath = $@"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\excels\68572b36-3f14-4261-9454-6de9a6e1d0bd.xlsx";
        public static string pdfDirectory = $@"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\pdfs";

        static void Main(string[] args)
        {
            ConvertExcelToPdf();

            Console.WriteLine("转换完成.");

            //StartWebServer();

            Console.ReadKey();
        }

        private static void StartWebServer()
        {
            var port = "8080";
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add($"http://127.0.0.1:{port}/");
            httpListener.Start();
            httpListener.BeginGetContext(new AsyncCallback(GetContext), httpListener);  //开始异步接收request请求

            Console.WriteLine("监听端口:" + port);
        }

        private static void GetContext(IAsyncResult ar)
        {
            HttpListener httpListener = ar.AsyncState as HttpListener;
            HttpListenerContext context = httpListener.EndGetContext(ar);  //接收到的请求context（一个环境封装体）

            httpListener.BeginGetContext(new AsyncCallback(GetContext), httpListener);  //开始 第二次 异步接收request请求

            HttpListenerRequest request = context.Request;  //接收的request数据
            HttpListenerResponse response = context.Response;  //用来向客户端发送回复

            response.ContentType = "html";
            response.ContentEncoding = Encoding.UTF8;

            using (var output = response.OutputStream)  //发送回复
            using (var htmlStream = File.OpenRead($@"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\pdfviewer\web\viewer.html"))
            {
                htmlStream.CopyTo(output);
            }
        }

        private static void ConvertExcelToPdf()
        {
            var extension = Path.GetExtension(excelPath).ToLower();
            var pdfPath = Path.Combine(pdfDirectory, $"{Path.GetFileName(excelPath)}.pdf");

            if (File.Exists(pdfPath)) { File.Delete(pdfPath); }

            Aspose.Cells.Workbook excel = new Aspose.Cells.Workbook(excelPath);
            //excel.Worksheets[0].PageSetup.PaperSize = Aspose.Cells.PaperSizeType.PaperA2;
            excel.Worksheets[0].PageSetup.PaperSize = Aspose.Cells.PaperSizeType.PaperA2;

            Aspose.Cells.PdfSaveOptions saveOptions = new Aspose.Cells.PdfSaveOptions(Aspose.Cells.SaveFormat.Pdf);
            saveOptions.AllColumnsInOnePagePerSheet = true;
            //saveOptions.OnePagePerSheet = true;
            //saveOptions.PdfCompression = Aspose.Cells.Rendering.PdfCompressionCore.Flate;
            //saveOptions.PrintingPageType = Aspose.Cells.PrintingPageType.Default;
            excel.Save(pdfPath, saveOptions);
        }
    }
}

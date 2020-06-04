using FileCenter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileCenter
{
    /// <summary>
    /// Download 的摘要说明
    /// </summary>
    public class Download : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            DownloadFile(context);
            context.Response.End();
        }

        private void DownloadFile(HttpContext context)
        {
            var fileId = context.Request.QueryString["fileId"];
            if (string.IsNullOrWhiteSpace(fileId))
            {
                context.Response.StatusCode = 404;
                return;
            }
            var projectName = context.Request.QueryString["projectName"];
            if (string.IsNullOrWhiteSpace(projectName))
            {
                projectName = context.Request.QueryString["project"];
            }
            if (string.IsNullOrWhiteSpace(projectName))
            {
                context.Response.StatusCode = 404;
                return;
            }
            string key = GetKey(projectName);
            if (string.IsNullOrWhiteSpace(key))
            {
                context.Response.StatusCode = 404;
                return;
            }
            try
            {
                fileId = AESHelper.AESDecrypt(fileId, key);
            }
            catch
            {
                context.Response.StatusCode = 404;
                return;
            }
            int id = 0;
            if (!int.TryParse(fileId, out id))
            {
                context.Response.StatusCode = 404;
                return;
            }

            //通过文件ID获取出文件
            using (var _dbContext = new FileCenterDbContext())
            {
                var file = _dbContext.SystemFiles.FirstOrDefault(m => m.Id == id && m.ProjectName == projectName);

                this.DepressFile(new List<int>(file.Id));

                var fileName = file.FileName;

                if (!string.IsNullOrWhiteSpace(context.Request.QueryString["rename"]))
                {
                    fileName = Guid.NewGuid().ToString("N");
                }

                if (string.IsNullOrWhiteSpace(file.FilePath))
                {
                    ResponseFile(context, fileName, file.FileData);
                }
                else
                {
                    ResponseFile(context, fileName, file.FilePath);
                }
            }
        }

        private static string GetKey(string projectName)
        {
            string key = null;
            switch (projectName.ToLower())
            {
                case "em":
                    key = "FKCIT@EM2018";
                    break;
                case "ican":
                    key = "FKCIT@ICAN2018";
                    break;
                case "ts":
                    key = "FKCIT@TS2018";
                    break;
                case "ps":
                    key = "FKCIT@PS2018";
                    break;
            }

            return key;
        }

        private void ResponseFile(HttpContext context, string fileName, byte[] fileData)
        {
            if (fileData == null || fileData.Length == 0)
            {
                context.Response.StatusCode = 404;
                return;
            }
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Length", fileData.Length.ToString());
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Uri.EscapeDataString(fileName));
            context.Response.OutputStream.Write(fileData, 0, fileData.Length);
            context.Response.Flush();
        }

        private void ResponseFile(HttpContext context, string fileName, string filePath)
        {
            var physicalPath = context.Server.MapPath(filePath);

            if (!File.Exists(physicalPath))
            {
                context.Response.StatusCode = 404;
                return;
            }

            using (var fs = File.OpenRead(physicalPath))
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("Content-Length", fs.Length.ToString());
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Uri.EscapeDataString(fileName));
                var toRead = fs.Length;
                byte[] buffer = new byte[409600];
                while (toRead > 0 && context.Response.IsClientConnected)
                {
                    int readed = fs.Read(buffer, 0, 409600);
                    context.Response.OutputStream.Write(buffer, 0, readed);
                    context.Response.Flush();
                    toRead = toRead - readed;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 解压文件(By Id)
        /// </summary>
        private void DepressFile(List<int> ids)
        {
            using (var _dbContext = new FileCenterDbContext())
            {
                var list = _dbContext.SystemFiles.Where(s => ids.Contains(s.Id)).ToList();

                foreach (var item in list)
                {
                    var fullPath = $"{AppConfig.FileUploadRootDirectory.Replace("\\", "/")}/{item.FilePath}";

                    if (!File.Exists(fullPath))
                    {
                        ZipFileManager.DepressFile(Path.Combine(AppConfig.FileArchiveRootDirectory, item.ArchiveFileName), item.FileLongName, fullPath);

                        item.FileCompressStatus = EnumFileCompressStatus.Uncompressed;
                        item.ArchiveFileName = string.Empty;
                        item.DecompressDateTime = DateTime.Now;
                    }
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
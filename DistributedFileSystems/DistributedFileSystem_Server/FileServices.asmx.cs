using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Services;
using System.Configuration;
using FileCenter.Model;
using FileCenter.Common;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace FileCenter
{
    /// <summary>
    /// FileServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class FileServices : WebService
    {
        MemoryCacheManager cacheManager = new MemoryCacheManager();
        RSAManager rsaManager = new RSAManager();

        public FileServices()
        {
        }

        #region EM4

        /// <summary>
        /// 上传WebService所在服务器上的文件的方法
        /// </summary>
        /// <param name="FileData">文件二进制流</param>
        /// <param name="FileName">原始文件名</param>
        /// <param name="FileExtension">后缀名</param>
        /// <param name="ProjectNo">项目名称固定值 TS </param>
        /// <param name="SaveType">保存类型 1：Folder，2：DB</param>
        /// <returns>文件路径</returns>
        [WebMethod]
        public FileResult UpLoadFileSwitch(byte[] FileData, string FileName, string FileExtension, string ProjectNo, string SaveType, int IsPdf)
        {
            if (!string.IsNullOrEmpty(FileExtension))
            {
                FileExtension = Path.GetExtension(FileName);
            }

            var Result = UpLoadFile(FileData, FileName, FileExtension, ProjectNo, SaveType);

            if (IsPdf == 0) // 图片不需要再转成pdf文件
            {
                return Result;
            }
            else
            {
                #region 转成PDF文件
                var file = Newtonsoft.Json.JsonConvert.DeserializeObject<SystemFiles>(Result.Result);
                string savePath = file.FilePath;
                string fileName = file.FileName;
                var pdfPath = AttachmentFile2PDF(ref savePath, ref fileName, Path.Combine(AppConfig.FileUploadRootDirectory, savePath));

                var systemFiles = new SystemFiles()
                {
                    FileId = Guid.NewGuid(),
                    FileData = null,
                    FilePath = pdfPath,
                    FileExtension = ".pdf",
                    FileName = FileName + ".pdf",
                    FileLongName = pdfPath,
                    FileSize = FileData.Length,
                    ProjectName = ProjectNo,
                    CreateDate = DateTime.Now
                };

                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    dbContext.SystemFiles.Add(systemFiles);
                    dbContext.SaveChanges();
                }

                file.PdfFileId = systemFiles.FileId;

                var result1 = new FileResult();
                result1.Status = "1";
                result1.Message = "SUCCESS";
                result1.Result = Newtonsoft.Json.JsonConvert.SerializeObject(file);
                return result1;
                #endregion
            }
        }

        [WebMethod]
        public FileResult UploadFileSwitch(byte[] FileData, string FileName, string FileExtension, string ProjectNo, string SaveType, int IsPdf)
        {
            if (!string.IsNullOrEmpty(FileExtension))
            {
                FileExtension = Path.GetExtension(FileName);
            }

            var Result = UpLoadFile(FileData, FileName, FileExtension, ProjectNo, SaveType);

            if (IsPdf == 0) // 图片不需要再转成pdf文件
            {
                return Result;
            }
            else
            {
                #region 转成PDF文件
                var file = Newtonsoft.Json.JsonConvert.DeserializeObject<SystemFiles>(Result.Result);
                string savePath = file.FilePath;
                string fileName = file.FileName;
                var pdfPath = AttachmentFile2PDF(ref savePath, ref fileName, Path.Combine(AppConfig.FileUploadRootDirectory, savePath));

                var systemFiles = new SystemFiles()
                {
                    FileId = Guid.NewGuid(),
                    FileData = null,
                    FilePath = pdfPath,
                    FileExtension = ".pdf",
                    FileName = FileName + ".pdf",
                    FileLongName = pdfPath,
                    FileSize = FileData.Length,
                    ProjectName = ProjectNo,
                    CreateDate = DateTime.Now
                };

                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    dbContext.SystemFiles.Add(systemFiles);
                    dbContext.SaveChanges();
                }

                file.PdfFileId = systemFiles.FileId;

                var result1 = new FileResult();
                result1.Status = "1";
                result1.Message = "SUCCESS";
                result1.Result = Newtonsoft.Json.JsonConvert.SerializeObject(file);
                return result1;
                #endregion
            }
        }

        /// <summary>
        ///下载WebService所在服务器上的文件的方法 
        /// </summary>
        /// <param name="FileId">文件ID</param>
        /// <param name="IsConvertStream">是否要将文件转成流</param>
        /// <returns></returns>
        [WebMethod]
        public FileResult DownFileByFileId(string FileId)
        {
            FileResult Result = new FileResult();

            try
            {
                //_dbContext.SystemFiles.FirstOrDefault(s => s.FileId.ToString() == FileId);

                // 改用SQL查询，提升查询效率
                var executeSql = $@"
SELECT Id,
       FileName,
       FileLongName,
       FileExtension,
       FileSize,
       FilePath,
       ProjectName,
       FileId
FROM dbo.SystemFiles
WHERE FileId = '{FileId}'
";
                SystemFiles systemFiles = null;

                using (var conn = new SqlConnection(AppConfig.FileDbConnectionString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    systemFiles = conn.Query<SystemFiles>(executeSql).FirstOrDefault();
                    var filePath = this.GetFilePath(systemFiles);
                    systemFiles.FileData = File.ReadAllBytes(filePath);
                }

                Result.Status = "1";
                Result.Message = "SUCCESS";
                Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);
                return Result;
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        [WebMethod]
        public FileResult DownloadSingleFileByFileId(string FileId)
        {
            FileResult Result = new FileResult();

            try
            {
                //_dbContext.SystemFiles.FirstOrDefault(s => s.FileId.ToString() == FileId);

                // 改用SQL查询，提升查询效率
                var executeSql = $@"
SELECT Id,
       FileName,
       FileLongName,
       FileExtension,
       FileSize,
       FilePath,
       ProjectName,
       FileId
FROM dbo.SystemFiles
WHERE FileId = '{FileId}'
";
                SystemFiles systemFiles = null;

                using (var conn = new SqlConnection(AppConfig.FileDbConnectionString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    systemFiles = conn.Query<SystemFiles>(executeSql).FirstOrDefault();
                    var filePath = this.GetFilePath(systemFiles);
                    systemFiles.FileData = File.ReadAllBytes(filePath);
                }

                Result.Status = "1";
                Result.Message = "SUCCESS";
                Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);
                return Result;
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        /// <summary>
        /// 批量下载文件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [WebMethod]
        public FileResult DownMoreFileByFileId(List<string> ids)
        {
            FileResult Result = new FileResult();
            List<SystemFiles> list;
            try
            {
                var fileIdString = $"'{string.Join(",", ids)}'";

                // 改用SQL查询，提升查询效率
                var executeSql = $@"
SELECT Id,
       FileName,
       FileLongName,
       FileExtension,
       FileSize,
       FilePath,
       ProjectName,
       FileId
FROM dbo.SystemFiles AS t1
    JOIN
    (SELECT F1 FROM dbo.Get_StrArrayStrOfTable({fileIdString}, ',') ) AS t2
        ON t1.FileId = t2.F1;
";
                using (var conn = new SqlConnection(AppConfig.FileDbConnectionString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    list = conn.Query<SystemFiles>(executeSql).ToList();

                    foreach (var item in list)
                    {
                        var filePath = this.GetFilePath(item);

                        byte[] fileData = File.ReadAllBytes(filePath);

                        item.FileData = fileData;
                    }
                }

                Result.Status = "1";
                Result.Message = "SUCCESS";
                Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return Result;
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        [WebMethod]
        public FileResult DownloadMultiFileByFileId(List<string> ids)
        {
            FileResult Result = new FileResult();
            List<SystemFilesView> list;
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    list = (from file in dbContext.SystemFiles
                            where file.IsDelete == null && ids.Any(s => s == file.FileId.ToString())
                            select new SystemFilesView
                            {
                                Id = file.Id,
                                FileName = file.FileName,
                                FileLongName = file.FileLongName,
                                FileExtension = file.FileExtension,
                                FileSize = file.FileSize,
                                FileId = file.FileId,
                                FilePath = file.FilePath,
                                ProjectName = file.ProjectName
                            }).ToList();

                    foreach (var item in list)
                    {
                        var filePath = this.GetFilePath(item);

                        byte[] fileData = File.ReadAllBytes(filePath);

                        item.FileData = fileData;
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                    return Result;
                }

            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        /// <summary>
        /// 同步删除文件，物理删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [WebMethod]
        public FileResult DeleteMoreFile(List<string> ids)
        {
            FileResult Result = new FileResult();

            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    var deleteFileList = (from file in dbContext.SystemFiles
                                          where file.IsDelete == null && ids.Any(s => s == file.FileId.ToString())
                                          select new SystemFilesView
                                          {
                                              Id = file.Id,
                                              FileName = file.FileName,
                                              FileLongName = file.FileLongName,
                                              FileExtension = file.FileExtension,
                                              FileSize = file.FileSize,
                                              FileId = file.FileId,
                                              FilePath = file.FilePath,
                                              ProjectName = file.ProjectName
                                          }).ToList();

                    if (deleteFileList.Any())
                    {
                        foreach (var item in deleteFileList)
                        {
                            item.IsDelete = 1;

                            var filepath = Server.MapPath(".") + "/" + item.FilePath;

                            if (File.Exists(filepath))
                            {
                                try
                                {
                                    File.Delete(filepath);
                                }
                                catch
                                {
                                }
                            }
                            dbContext.SaveChanges();
                        }
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    return Result;
                }
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }
        #endregion

        #region PS
        /// <summary>
        /// 上传WebService所在服务器上的文件的方法
        /// </summary>
        /// <param name="FileData">文件二进制流</param>
        /// <param name="FileName">原始文件名</param>
        /// <param name="FileExtension">后缀名</param>
        /// <param name="ProjectNo">项目名称固定值 TS </param>
        /// <param name="SaveType">保存类型 1：Folder，2：DB</param>
        /// <returns>文件路径</returns>
        [WebMethod]
        public FileResult UpLoadFile(byte[] FileData, string FileName, string FileExtension, string ProjectNo, string SaveType)
        {
            var Result = new FileResult();

            try
            {
                SystemFiles systemFiles = new SystemFiles();

                var FolderName = ConfigurationManager.AppSettings[ProjectNo];

                if (FolderName == null)
                {
                    FolderName = ProjectNo;
                }

                string day = DateTime.Now.ToString("yyyyMMdd");
                string folder = FolderName + "/" + day;
                string filePath = AppConfig.FileUploadRootDirectory + "/" + folder;   //Server.MapPath(folder);

                if (Directory.Exists(filePath) == false)// 如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                string longName = Guid.NewGuid().ToString();
                string SaveFileName = longName + FileExtension; // 保存文件名称

                using (FileStream fs = File.Create(filePath + "/" + SaveFileName))
                {
                    fs.Write(FileData, 0, FileData.Length);
                }

                string smallPicPath = longName + "_100.100" + FileExtension;

                systemFiles = new SystemFiles()
                {
                    FileId = Guid.NewGuid(),
                    FileData = null,
                    FilePath = folder + "/" + SaveFileName,
                    FileExtension = FileExtension,
                    FileName = FileName,
                    FileLongName = SaveFileName,
                    FileSize = FileData.Length,
                    ProjectName = ProjectNo,
                    CreateDate = DateTime.Now,
                    FileCompressStatus = EnumFileCompressStatus.Uncompressed
                };


                if (AppConfig.ImageExtension.Contains(FileExtension.ToLower()))// 如果是图片，自动增加缩略图转换
                {
                    var coverName = Guid.NewGuid().ToString() + FileExtension; // 保存文件名称;
                    var cover = GetThumbnail(ProjectNo, folder, SaveFileName, coverName);
                    if (cover.FileId.HasValue)
                    {
                        systemFiles.CoverSavePath = cover.FilePath;
                        systemFiles.CoverFileId = cover.FileId;
                    }
                }

                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    dbContext.SystemFiles.Add(systemFiles);
                    dbContext.SaveChanges();
                }

                // systemFiles.FileData = FileData;// 将二进制流返回

                Result.Status = "1";
                Result.Message = "SUCCESS";
                Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);

                return Result;
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                return Result;
            }
        }

        [WebMethod]
        public FileResult UploadFile(byte[] FileData, string FileName, string FileExtension, string ProjectNo, string SaveType)
        {
            var Result = new FileResult();

            try
            {
                SystemFiles systemFiles = new SystemFiles();

                var FolderName = ConfigurationManager.AppSettings[ProjectNo];

                if (FolderName == null)
                {
                    FolderName = ProjectNo;
                }

                string day = DateTime.Now.ToString("yyyyMMdd");
                string folder = FolderName + "/" + day;
                string filePath = Server.MapPath(folder);

                if (Directory.Exists(filePath) == false)// 如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                string longName = Guid.NewGuid().ToString();
                string SaveFileName = longName + FileExtension; // 保存文件名称

                using (FileStream fs = File.Create(filePath + "/" + SaveFileName))
                {
                    fs.Write(FileData, 0, FileData.Length);
                }

                string smallPicPath = longName + "_100.100" + FileExtension;

                systemFiles = new SystemFiles()
                {
                    FileId = Guid.NewGuid(),
                    FileData = null,
                    FilePath = folder + "/" + SaveFileName,
                    FileExtension = FileExtension,
                    FileName = FileName,
                    FileLongName = SaveFileName,
                    FileSize = FileData.Length,
                    ProjectName = ProjectNo,
                    CreateDate = DateTime.Now,
                    FileCompressStatus = EnumFileCompressStatus.Uncompressed
                };

                if (AppConfig.ImageExtension.Contains(FileExtension.ToLower()))// 如果是图片，自动增加缩略图转换
                {
                    var coverName = Guid.NewGuid().ToString() + FileExtension; // 保存文件名称;
                    var cover = GetThumbnail(ProjectNo, folder, SaveFileName, coverName);
                    if (cover.FileId.HasValue)
                    {
                        systemFiles.CoverSavePath = cover.FilePath;
                        systemFiles.CoverFileId = cover.FileId;
                    }
                }

                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    dbContext.SystemFiles.Add(systemFiles);
                    dbContext.SaveChanges();
                }

                //systemFiles.FileData = FileData;// 将二进制流返回

                Result.Status = "1";
                Result.Message = "SUCCESS";
                Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);

                return Result;
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                return Result;
            }
        }

        /// <summary>
        /// 下载WebService所在服务器上的文件的方法 
        /// </summary>
        /// <param name="FileId">文件ID</param>
        /// <param name="IsConvertStream">是否要将文件转成流</param>
        /// <returns></returns>
        [WebMethod]
        public FileResult DownFile(string FileId, bool IsConvertStream = false)
        {
            FileResult Result = new FileResult();
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    SystemFiles systemFiles = null;
                    int Id = 0;
                    int.TryParse(FileId, out Id);
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == Id);

                    var filePath = this.GetFilePath(systemFiles);

                    if (IsConvertStream)
                    {
                        systemFiles.FileData = File.ReadAllBytes(filePath);
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);
                    return Result;
                }
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        [WebMethod]
        public FileResult DownloadSingleFileById(string FileId, bool IsConvertStream = false)
        {
            FileResult Result = new FileResult();
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    SystemFiles systemFiles = null;
                    int Id = 0;
                    int.TryParse(FileId, out Id);
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == Id);

                    var filePath = this.GetFilePath(systemFiles);

                    if (IsConvertStream)
                    {
                        systemFiles.FileData = File.ReadAllBytes(filePath);
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);
                    return Result;
                }
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        /// <summary>
        /// 批量下载文件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [WebMethod]
        public FileResult DownMoreFile(List<int> ids)
        {
            FileResult Result = new FileResult();
            List<SystemFilesView> list;
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    list = (from file in dbContext.SystemFiles
                            where file.IsDelete == null && ids.Any(s => s == file.Id)
                            select new SystemFilesView
                            {
                                Id = file.Id,
                                FileName = file.FileName,
                                FileLongName = file.FileLongName,
                                FileExtension = file.FileExtension,
                                FileSize = file.FileSize,
                                FileId = file.FileId,
                                FilePath = file.FilePath,
                                ProjectName = file.ProjectName
                            }).ToList();

                    foreach (var item in list)
                    {
                        var filePath = this.GetFilePath(item);

                        byte[] fileData = File.ReadAllBytes(filePath);

                        item.FileData = fileData;
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                    return Result;
                }

            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        [WebMethod]
        public FileResult DownloadMultiFileById(List<int> ids)
        {
            FileResult Result = new FileResult();
            List<SystemFilesView> list;
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    list = (from file in dbContext.SystemFiles
                            where file.IsDelete == null && ids.Any(s => s == file.Id)
                            select new SystemFilesView
                            {
                                Id = file.Id,
                                FileName = file.FileName,
                                FileLongName = file.FileLongName,
                                FileExtension = file.FileExtension,
                                FileSize = file.FileSize,
                                FileId = file.FileId,
                                FilePath = file.FilePath,
                                ProjectName = file.ProjectName
                            }).ToList();

                    foreach (var item in list)
                    {
                        var filePath = this.GetFilePath(item);

                        byte[] fileData = File.ReadAllBytes(filePath);

                        item.FileData = fileData;
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                    return Result;
                }

            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="FileId"></param>
        /// <returns></returns>
        public FileResult DeleteFile(string FileId)
        {
            FileResult Result = new FileResult();
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    SystemFiles systemFiles = null;
                    int Id = 0;
                    int.TryParse(FileId, out Id);
                    systemFiles = dbContext.SystemFiles.Find(Id);

                    if (systemFiles != null)
                    {
                        systemFiles.IsDelete = 1;

                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);
                    return Result;
                }
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                Result.Result = null;
                return Result;
            }
        }
        #endregion

        #region 公共
        /// <summary>
        ///下载WebService所在服务器上的文件的方法 (生成临时文件)
        /// </summary>
        /// <param name="FileId">文件ID</param>
        /// <returns></returns>
        public string DownFileByScratch(string FileId)
        {
            using (FileCenterDbContext dbContext = new FileCenterDbContext())
            {
                int Id = 0;
                int.TryParse(FileId, out Id);
                var systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == Id);
                if (systemFiles != null)
                {
                    if (systemFiles.FilePath.Length == 0 && systemFiles.FileData.Length > 0)
                    {
                        var FolderName = ConfigurationManager.AppSettings["ScratchFile"];
                        string filePath = Server.MapPath(FolderName);
                        if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        string SaveFileName = Guid.NewGuid().ToString() + systemFiles.FileExtension; // 保存文件名称
                        FileStream fs = File.Create(filePath + "/" + SaveFileName);
                        byte[] Data = systemFiles.FileData;
                        fs.Write(Data, 0, Data.Length);
                        fs.Close();
                        systemFiles.FilePath = FolderName + "/" + SaveFileName;
                    }
                    return Newtonsoft.Json.JsonConvert.SerializeObject(systemFiles);
                }
                else
                {
                    return "";
                }
            }
        }

        /// 生成缩略图
        /// </summary>
        /// <param name="localImagePath">图片地址</param>
        /// <param name="thumbnailImagePath">缩略图地址</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="p"></param>
        public static bool GetThumbnail(string localImagePath, string thumbnailImagePath, int width, int height)
        {
            Image serverImage = Image.FromFile(localImagePath);
            //画板大小
            int towidth = width;
            int toheight = height;
            //缩略图矩形框的像素点
            int x = 0;
            int y = 0;
            int ow = serverImage.Width;
            int oh = serverImage.Height;

            if (ow > oh)
            {
                toheight = serverImage.Height * width / serverImage.Width;
            }
            else
            {
                towidth = serverImage.Width * height / serverImage.Height;
            }
            //新建一个bmp图片
            System.Drawing.Image bm = new System.Drawing.Bitmap(width, height);
            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.White);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(serverImage, new System.Drawing.Rectangle((width - towidth) / 2, (height - toheight) / 2, towidth, toheight),
                0, 0, ow, oh,
                System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                bm.Save(thumbnailImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
            finally
            {
                serverImage.Dispose();
                bm.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 上传附件转换成PDF
        /// </summary>
        /// <param name="fileFullPath">文件完整路径</param>
        /// <returns>转换后PDF的URL</returns>
        protected static string AttachmentFile2PDF(ref string savePath, ref string fileName, string fileFullPath)
        {
            string ret = string.Empty;
            try
            {
                string fileExt = Path.GetExtension(fileFullPath).ToLower();
                string filePath = Path.GetFullPath(fileFullPath);
                string pdfFile = fileFullPath + ".pdf";
                string pdfPath = fileFullPath.Replace(@"\", @"/") + ".pdf";
                if (!File.Exists(pdfFile))
                {
                    switch (fileExt)
                    {
                        case ".doc":
                        case ".docx":
                        case ".rtf":
                            Aspose.Words.Document doc = new Aspose.Words.Document(fileFullPath);
                            doc.Save(pdfFile, Aspose.Words.SaveFormat.Pdf);
                            ret = savePath + ".pdf";
                            fileName = fileName + ".pdf";
                            break;
                        case ".xls":
                        case ".xlsx":
                            Aspose.Cells.Workbook excel = new Aspose.Cells.Workbook(fileFullPath);
                            excel.Settings.MemorySetting = Aspose.Cells.MemorySetting.MemoryPreference;
                            excel.Settings.AutoCompressPictures = true;
                            excel.Settings.EnableMacros = false;
                            Aspose.Cells.PdfSaveOptions saveOptions = new Aspose.Cells.PdfSaveOptions(Aspose.Cells.SaveFormat.Pdf);
                            saveOptions.OnePagePerSheet = true;
                            saveOptions.PdfCompression = Aspose.Cells.Rendering.PdfCompressionCore.Flate;
                            saveOptions.PrintingPageType = Aspose.Cells.PrintingPageType.IgnoreBlank;
                            excel.Save(pdfFile, saveOptions);
                            ret = savePath + ".pdf";
                            fileName = fileName + ".pdf";
                            break;
                        case ".ppt":
                        case ".pptx":
                            Aspose.Slides.Presentation ppt = new Aspose.Slides.Presentation(fileFullPath);
                            ppt.Save(pdfFile, Aspose.Slides.Export.SaveFormat.Pdf);
                            ret = savePath + ".pdf";
                            fileName = fileName + ".pdf";
                            break;
                        case ".png":
                        case ".jpg":
                            try
                            {
                                Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
                                Aspose.Pdf.Generator.Section sec = pdf.Sections.Add();
                                Aspose.Pdf.Generator.Image image = new Aspose.Pdf.Generator.Image(sec);
                                sec.Paragraphs.Add(image);
                                image.ImageInfo.File = fileFullPath;
                                //image.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Jpeg;
                                pdf.Save(pdfFile);
                            }
                            catch (Exception ex)
                            {
                                if (File.Exists(pdfFile))
                                {
                                    File.Delete(pdfFile);
                                }
                                throw ex;
                            }

                            ret = savePath + ".pdf";
                            fileName = fileName + ".pdf";
                            break;
                        case ".pdf":

                        case ".rar":
                        case ".zip":
                        case ".7z":
                            pdfPath = pdfPath.Substring(0, pdfPath.Length - 4);
                            ret = savePath;
                            break;
                    }
                }
                return ret;


            }
            catch (Exception ex)
            {
                ret = string.Empty;
                return ret;
            }
        }

        /// <summary>
        /// 通过上传的json参数，返回对于的文件的token值
        /// </summary>
        /// <param name="jsonParameter"></param>
        /// <returns></returns>
        [WebMethod]
        public FileResult GetFileTokenList(string jsonParameter)
        {
            LogHelper.Info($"GetFileTokenList Start At:{DateTime.Now}");
            var Result = new FileResult();
            var fileTokenList = new List<FileToken>();
            var systemFiles = new SystemFiles();
            try
            {
                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    var passedParamList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FileToken>>(jsonParameter);

                    foreach (var item in passedParamList)
                    {
                        // 解密获取真正的FileId
                        item.FileId = rsaManager.RSADecrypt(File.ReadAllText(AppConfig.PrivateKeyFilePath), item.FileId);
                        item.Token = this.GenerateToken(item);
                        item.Url = $"{AppConfig.FileCenterDomain}/file/GetFile?token={HttpUtility.UrlEncode(item.Token)}";

                        int Id = 0;
                        if (int.TryParse(item.FileId, out Id))
                        {
                            // 传入的id是int类型，说明是Id字段
                            systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == Id);
                        }
                        else
                        {
                            // 传入的id不是int类型，说明是FileId字段
                            systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.FileId == new Guid(item.FileId));
                        }

                        item.FileName = systemFiles.FileName;

                        cacheManager.Set(item.Token, item.FileId);
                    }

                    Result.Status = "1";
                    Result.Message = "SUCCESS";
                    Result.Result = Newtonsoft.Json.JsonConvert.SerializeObject(passedParamList);
                    return Result;
                }
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                return Result;
            }
            finally
            {
                LogHelper.Info($"GetFileTokenList End At:{DateTime.Now}");
            }

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectNo"></param>
        /// <param name="localImagePath"></param>
        /// <param name="thumbnailImagePath"></param>
        /// <returns></returns>
        private SystemFiles GetThumbnail(string projectNo, string folder, string localImagePath, string thumbnailImagePath)
        {
            try
            {
                var systemFiles = new SystemFiles();
                var OldPath = this.GetFilePath(new SystemFiles() { FilePath = folder + "/" + localImagePath }); //Server.MapPath(folder) + "/" + localImagePath;
                var covertPath = Path.Combine(AppConfig.FileUploadRootDirectory, folder, thumbnailImagePath); // Server.MapPath(folder) + "/" + thumbnailImagePath;
                var success = GetThumbnail(OldPath, covertPath, 180, 140);

                if (success)
                {
                    var path = folder + "/" + thumbnailImagePath;

                    systemFiles = new SystemFiles()
                    {
                        FileId = Guid.NewGuid(),
                        FileData = null,
                        FilePath = path,
                        FileExtension = Path.GetExtension(path),
                        FileName = Path.GetFileName(path),
                        FileLongName = Path.GetFileName(path),
                        FileSize = 0,
                        ProjectName = projectNo,
                        CreateDate = DateTime.Now
                    };

                    using (FileCenterDbContext dbContext = new FileCenterDbContext())
                    {
                        dbContext.SystemFiles.Add(systemFiles);
                        dbContext.SaveChanges();
                    }
                }

                return systemFiles;
            }
            catch (Exception ex)
            {
                return new SystemFiles();
            }
        }

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="imageData">图片内容</param>
        /// <param name="flag">质量 0-100</param>
        /// <param name="size">压缩的最大长度</param>
        /// <returns></returns>
        private byte[] CompressImage(byte[] imageData, int flag = 80, int size = 500, bool isFirst = true)
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

                        if (bytes.Length > 1024 * size)
                        {
                            flag = flag - 10;
                            bytes = CompressImage(bytes, flag, size, false);
                        }
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

        private string GenerateToken(FileToken fileToken)
        {
            var token = rsaManager.RSAEncrypt(File.ReadAllText(AppConfig.PublicKeyFilePath), $"{fileToken.Username + fileToken.Password + fileToken.FileId }");

            return token;
        }

        private string GetFilePath(SystemFiles file)
        {
            var filePath = string.Empty;

            if (file.FileCompressStatus == Model.EnumFileCompressStatus.Compressed)
            {
                // 如果文件已经被归档，需要先将文件解压到初始根目录

                DepressFile(new List<int>() { file.Id });
            }

            // 1.在存放上传文件目录中找
            filePath = Path.Combine(AppConfig.FileUploadRootDirectory, file.FilePath);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            // 2.在存放图片处理的目录中找
            filePath = Path.Combine(AppConfig.FileCompressRootDirectory, file.FilePath);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            throw new Exception($"{file.FileLongName}在服务器上找不到");
        }

        private string GetFilePath(SystemFilesView systemFiles)
        {
            var filePath = string.Empty;

            // 1.在存放上传文件目录中找
            filePath = Path.Combine(AppConfig.FileUploadRootDirectory, systemFiles.FilePath);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            // 2.在存放图片处理的目录中找
            filePath = Path.Combine(AppConfig.FileCompressRootDirectory, systemFiles.FilePath);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            throw new Exception($"{systemFiles.FileLongName}在服务器上找不到");
        }

        /// <summary> 
        /// 为图片生成缩略图
        /// </summary> 
        /// <param name="phyPath">原图片的路径</param> 
        /// <param name="width">缩略图宽</param> 
        /// <param name="height">缩略图高</param> 
        /// <returns></returns> 
        private Image GetHvtThumbnail(System.Drawing.Image image, int width, int height)
        {
            Bitmap m_hovertreeBmp = new Bitmap(width, height);
            //从Bitmap创建一个System.Drawing.Graphics 
            Graphics m_HvtGr = Graphics.FromImage(m_hovertreeBmp);
            //设置 
            m_HvtGr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //下面这个也设成高质量 
            m_HvtGr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //下面这个设成High 
            m_HvtGr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //把原始图像绘制成上面所设置宽高的缩小图 
            Rectangle rectDestination = new Rectangle(0, 0, width, height);
            int m_width, m_height;
            if (image.Width * height > image.Height * width)
            {
                m_height = image.Height;
                m_width = (image.Height * width) / height;
            }
            else
            {
                m_width = image.Width;
                m_height = (image.Width * height) / width;
            }
            m_HvtGr.DrawImage(image, rectDestination, 0, 0, m_width, m_height, GraphicsUnit.Pixel);
            return m_hovertreeBmp;
        }

        private byte[] ConvertStreamToByteBuffer(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            byte[] fileBytes = br.ReadBytes((int)stream.Length);
            return fileBytes;
        }

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
                        item.TobeArchiveDateTime = DateTime.Now.AddDays((int)EnumArchivePeriod.Quarter);
                    }
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
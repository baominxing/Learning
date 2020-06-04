using Dapper;
using FileCenter.Common;
using FileCenter.Model;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace FileCenter.Controller
{

    public class FileController : BaseApiController
    {
        private readonly MemoryCacheManager cacheManager = new MemoryCacheManager();
        private readonly RSAManager rsaManager = new RSAManager();
        private static object syncObject = new object();


        /// <summary>
        /// 普通单个文件下载Token
        /// </summary>
        /// <param name="fileTokeList"></param>
        /// <returns></returns>
        [HttpPost]
        public FileResult GetFileTokenList(List<FileToken> fileTokeList)
        {
            var Result = new FileResult();
            var systemFiles = new SystemFiles();
            try
            {
                if (fileTokeList == null || !fileTokeList.Any())
                {
                    throw new Exception("参数集合为空");
                }

                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    foreach (var item in fileTokeList)
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
                    Result.Result = JsonConvert.SerializeObject(fileTokeList);
                    return Result;
                }
            }
            catch (Exception er)
            {
                Result.Status = "0";
                Result.Message = er.Message;
                return Result;
            }
        }

        /// <summary>
        /// 打包下载文件集合下载Token
        /// </summary>
        /// <param name="jsonParameter"></param>
        /// <returns></returns>
        [HttpPost]
        public FileResult GetZipFileToken(List<FileToken> fileTokeList)
        {
            var Result = new FileResult();
            var systemFiles = new SystemFiles();
            try
            {
                if (fileTokeList == null || !fileTokeList.Any())
                {
                    throw new Exception("参数集合为空");
                }

                var token = this.GenerateToken(fileTokeList[0]);

                cacheManager.Set(token, string.Join(",", fileTokeList.Select(s => s.FileId)));

                var tokenObj = new FileToken() { Url = $"{AppConfig.FileCenterDomain}/file/GetZipFile?token={HttpUtility.UrlEncode(token)}" };

                Result.Status = "1";
                Result.Message = "SUCCESS";
                Result.Result = JsonConvert.SerializeObject(tokenObj);

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
        /// 根据token获取请求文件
        /// </summary>
        /// <param name="token"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFile(string token, string type = "")
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                SystemFiles systemFiles = null;

                //根据token获取存储的fileId
                var fileId = this.cacheManager.Get<string>(token);

                if (string.IsNullOrEmpty(fileId))
                {
                    throw new Exception("Token已无效，请进入业务系统下载文件。");
                }

                int Id = 0;
                if (int.TryParse(fileId, out Id))
                {
                    // 传入的id是int类型，说明是Id字段
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == Id);
                }
                else
                {
                    // 传入的id不是int类型，说明是FileId字段
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.FileId == new Guid(fileId));
                }

                var filePath = this.GetFilePath(systemFiles);

                LogHelper.Info($"FileName:{HttpUtility.UrlEncode(systemFiles.FileName, Encoding.UTF8)}");

                var browser = String.Empty;
                if (HttpContext.Current.Request.UserAgent != null)
                {
                    browser = HttpContext.Current.Request.UserAgent.ToUpper();
                }

                var fileName = browser.Contains("FIREFOX") ? HttpUtility.UrlEncode(systemFiles.FileName, Encoding.UTF8) : HttpUtility.UrlEncode(Path.GetFileName(systemFiles.FileName), Encoding.UTF8);

                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                FileStream fileStream = File.OpenRead(filePath);
                httpResponseMessage.Content = new StreamContent(fileStream);
                httpResponseMessage.Content.Headers.Add("FileName", fileName);
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };

                // 是否只允许下载一次
                if (AppConfig.AllowDownloadOnce)
                {
                    // 移除token
                    this.cacheManager.Remove(token);
                }

                return ResponseMessage(httpResponseMessage);
            }
            catch (Exception ex)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                httpResponseMessage.Content = new StringContent(ex.Message);

                return ResponseMessage(httpResponseMessage);
            }
        }

        /// <summary>
        /// 根据fileid下载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFile(string id)
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                SystemFiles systemFiles = null;


                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("参数不正确！");
                }
                var fileId = id;
                int Id = 0;
                if (int.TryParse(fileId, out Id))
                {
                    // 传入的id是int类型，说明是Id字段
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == Id);
                }
                else
                {
                    // 传入的id不是int类型，说明是FileId字段
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.FileId == new Guid(fileId));
                }

                var filePath = this.GetFilePath(systemFiles);

                LogHelper.Info($"FileName:{systemFiles.FileName}");

                var browser = String.Empty;
                if (HttpContext.Current.Request.UserAgent != null)
                {
                    browser = HttpContext.Current.Request.UserAgent.ToUpper();
                }

                var fileName = browser.Contains("FIREFOX") ? HttpUtility.UrlEncode(systemFiles.FileName, Encoding.UTF8) : HttpUtility.UrlEncode(Path.GetFileName(systemFiles.FileName), Encoding.UTF8);

                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                FileStream fileStream = File.OpenRead(filePath);
                httpResponseMessage.Content = new StreamContent(fileStream);
                httpResponseMessage.Content.Headers.Add("FileName", fileName);
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };


                return ResponseMessage(httpResponseMessage);
            }
            catch (Exception ex)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                httpResponseMessage.Content = new StringContent(ex.Message);

                return ResponseMessage(httpResponseMessage);
            }
        }

        [HttpGet]
        public IHttpActionResult GetZipFile(string token)
        {
            //根据token获取存储的fileId
            var fileIdListString = this.cacheManager.Get<string>(token);

            if (string.IsNullOrEmpty(fileIdListString))
            {
                throw new Exception("Token已无效，请进入业务系统下载文件。");
            }

            var fileIdList = fileIdListString.Split(',');

            HttpResponseMessage httpResponseMessage = null;
            List<SystemFiles> systemFileList;

            try
            {
                var fileIdString = $"'{string.Join(",", fileIdList)}'";

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

                    systemFileList = conn.Query<SystemFiles>(executeSql).ToList();
                }



                var resultIndex = 0;
                var resultFileName = "";
                //Encoding gbk = Encoding.GetEncoding("gbk");
                //ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = gbk.CodePage;
                using (var ms = new MemoryStream())
                {
                    var names = new List<string>();
                    using (ZipOutputStream outPutStream = new ZipOutputStream(ms))
                    {
                        outPutStream.SetLevel(6);
                        Crc32 crc = new Crc32();
                        foreach (var systemFile in systemFileList)
                        {
                            var file = new FileInfo(GetFilePath(systemFile));

                            if (string.IsNullOrEmpty(resultFileName))
                            {
                                resultFileName = Path.GetFileNameWithoutExtension(systemFile.FileName);
                            }
                            crc.Reset();
                            resultIndex++;
                            var fileName = systemFile.FileName;
                            if (names.Contains(fileName))
                            {
                                var index = 0;
                                while (names.Contains(fileName))
                                {
                                    index++;
                                    fileName = Path.GetFileNameWithoutExtension(systemFile.FileName) + "(" + index + ")" + Path.GetExtension(systemFile.FileName);
                                }
                            }

                            FileStream stream = file.OpenRead();
                            Byte[] buffer = new Byte[stream.Length];
                            //从流中读取字节块并将该数据写入给定缓冲区buffer中
                            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));

                            var ent = new ZipEntry(fileName);
                            ent.IsUnicodeText = true;
                            ent.DateTime = DateTime.Now;
                            ent.Size = file.Length;
                            outPutStream.PutNextEntry(ent);
                            crc.Update(buffer, 0, (int)file.Length);
                            outPutStream.Write(buffer, 0, (int)file.Length);
                            ent.Crc = crc.Value;
                            ent = null;
                            stream.Close();
                        }
                        crc = null;
                        outPutStream.Finish();
                        ms.Seek(0, SeekOrigin.Begin);
                        var bytes = new byte[ms.Length];
                        ms.Read(bytes, 0, bytes.Length);
                        if (resultIndex > 1)
                        {
                            resultFileName += "等" + resultIndex + "个文件.zip";
                        }
                        else
                        {
                            resultFileName += ".zip";
                        }

                        MemoryStream retStream = new MemoryStream(bytes);

                        var browser = String.Empty;
                        if (HttpContext.Current.Request.UserAgent != null)
                        {
                            browser = HttpContext.Current.Request.UserAgent.ToUpper();
                        }

                        httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                        httpResponseMessage.Content = new StreamContent(retStream);
                        httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = Uri.EscapeDataString(resultFileName)
                        };

                        //retStream.Close();
                        outPutStream.Close();
                        ms.Close();

                        // 是否只允许下载一次
                        if (AppConfig.AllowDownloadOnce)
                        {
                            // 移除token
                            this.cacheManager.Remove(token);
                        }

                        return ResponseMessage(httpResponseMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                httpResponseMessage.Content = new StringContent(ex.Message);

                return ResponseMessage(httpResponseMessage);
            }
            finally
            {
                //删除文件
                var folder = new DirectoryInfo(AppConfig.ZipFolder);

                foreach (var file in folder.GetFiles())
                {
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
            }
        }

        /// <summary>
        /// 上传普通文件
        /// </summary>
        /// <param name="token"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UploadFile([FromUri]SystemFilesView model)
        {
            var result = new FileResult();
            try
            {
                SystemFiles systemFiles = new SystemFiles();

                var FolderName = ConfigurationManager.AppSettings[model.ProjectName];

                if (FolderName == null)
                {
                    FolderName = model.ProjectName;
                }

                var day = DateTime.Now.ToString("yyyyMMdd");
                var folder = FolderName + "/" + day;
                var filePath = AppConfig.FileUploadRootDirectory + "/" + folder;
                var dataLength = 0L;

                if (Directory.Exists(filePath) == false)// 如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(filePath);
                }
                string longName = Guid.NewGuid().ToString();
                string SaveFileName = longName + model.FileExtension; // 保存文件名称

                using (var destinationStream = File.Create(filePath + "/" + SaveFileName))
                using (var sourceStream = Request.Content.ReadAsStreamAsync().Result)
                {
                    // TODO:添加一个BufferStream缓冲，减少I/O压力   
                    sourceStream.CopyTo(destinationStream);

                    dataLength = sourceStream.Length;
                }

                var tobeArchiveDateTime = (model.ArchivePeriod == EnumArchivePeriod.Never || IsImage(model)) ? DateTime.MaxValue : DateTime.Now.AddDays((int)model.ArchivePeriod);

                systemFiles = new SystemFiles()
                {
                    FileId = Guid.NewGuid(),
                    FileData = null,
                    FilePath = folder + "/" + SaveFileName,
                    FileExtension = model.FileExtension,
                    FileName = model.FileName,
                    FileLongName = SaveFileName,
                    FileSize = (int)dataLength,
                    ProjectName = model.ProjectName,
                    CreateDate = DateTime.Now,
                    FileCompressStatus = EnumFileCompressStatus.Uncompressed,
                    TobeArchiveDateTime = tobeArchiveDateTime
                };

                using (FileCenterDbContext dbContext = new FileCenterDbContext())
                {
                    dbContext.SystemFiles.Add(systemFiles);
                    dbContext.SaveChanges();
                }

                result.Status = AppConfig.ReturnResult.Status_Success;
                result.Message = AppConfig.ReturnResult.Message_Success;
                result.Result = JsonConvert.SerializeObject(systemFiles);

                return Json(result);
            }
            catch (Exception ex)
            {
                result.Status = AppConfig.ReturnResult.Status_Failure;
                result.Message = ex.Message;

                return Json(result);
            }
        }

        /// <summary>
        /// 上传大文件接口
        /// </summary>
        /// <param name="token"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UploadBigFile([FromUri]PartialFileModel partialFileModel)
        {
            try
            {
                lock (syncObject)
                {
                    var file = new FileInfo($"{AppConfig.BigFileTempStorage}\\{partialFileModel.FileId}_{partialFileModel.PartialId}");

                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    using (File.Create(file.FullName))
                    {

                    }

                    using (var sourceStream = Request.Content.ReadAsStreamAsync().Result)
                    using (var stream = file.OpenWrite())
                    {
                        sourceStream.CopyTo(stream);
                    }

                    dbContext.PartialFileModels.Add(partialFileModel);

                    dbContext.SaveChanges();

                    if (!IsAllBlocksUploaded(partialFileModel))
                    {
                        partialFileModel.IsMerged = false;
                    }
                    else
                    {
                        this.Merge(partialFileModel);
                        partialFileModel.IsMerged = true;
                    }
                }
                partialFileModel.IsSuccess = true;
                partialFileModel.FileData = null;

                return Json(partialFileModel);
            }
            catch (Exception ex)
            {
                partialFileModel.IsSuccess = false;
                partialFileModel.FileData = null;
                partialFileModel.Message = ex.ToString();
                return Json(partialFileModel);
            }
        }

        /// <summary>
        /// 下载大文件，分包下载
        /// </summary>
        /// <param name="partialFileModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DownloadBigFile(PartialFileModel partialFileModel)
        {
            HttpResponseMessage httpResponseMessage = null;

            try
            {
                SystemFiles systemFiles = null;

                if (partialFileModel.Id != 0)
                {
                    // 传入的id是int类型，说明是Id字段
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.Id == partialFileModel.Id);
                }
                else if (partialFileModel.FileId.HasValue && partialFileModel.FileId != Guid.Empty)
                {
                    // 传入的id不是int类型，说明是FileId字段
                    systemFiles = dbContext.SystemFiles.FirstOrDefault(s => s.FileId == partialFileModel.FileId);
                }
                else
                {
                    throw new Exception("传入文件Id无效");
                }

                var filePath = this.GetFilePath(systemFiles);

                LogHelper.Info($"FileName:{systemFiles.FileName}");

                var browser = String.Empty;

                if (HttpContext.Current.Request.UserAgent != null)
                {
                    browser = HttpContext.Current.Request.UserAgent.ToUpper();
                }

                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                FileStream fileStream = File.OpenRead(filePath);
                httpResponseMessage.Content = new StreamContent(fileStream);
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = browser.Contains("FIREFOX") ? systemFiles.FileName : HttpUtility.UrlEncode(Path.GetFileName(systemFiles.FileName))
                };

                return ResponseMessage(httpResponseMessage);
            }
            catch (Exception ex)
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                httpResponseMessage.Content = new StringContent(ex.Message);

                return ResponseMessage(httpResponseMessage);
            }
        }

        /// <summary>
        /// 是否所有的文件块都已经上传到服务器
        /// </summary>
        /// <returns></returns>
        public bool IsAllBlocksUploaded(PartialFileModel partialFileModel)
        {
            if (dbContext.PartialFileModels.Count(s => s.FileId == partialFileModel.FileId) == partialFileModel.PartialCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 合并文件
        /// </summary>
        private void Merge(PartialFileModel partialFileModel)
        {
            var mergeFileBytes = new List<byte>();
            var partialFileList = new List<FileInfo>();

            // 取得分片文件内容，拼接成初始文件
            for (int i = 0; i < partialFileModel.PartialCount; i++)
            {
                var file = new FileInfo($"{AppConfig.BigFileTempStorage}\\{partialFileModel.FileId}_{i}");

                using (var tf = file.OpenRead())
                {
                    var blockBytes = new byte[tf.Length];

                    tf.Read(blockBytes, 0, blockBytes.Length);

                    mergeFileBytes.AddRange(blockBytes);
                }

                partialFileList.Add(file);
            }

            // 保存初始上传大文件
            SystemFiles systemFiles = new SystemFiles();

            var FolderName = ConfigurationManager.AppSettings[partialFileModel.ProjectName];

            if (FolderName == null)
            {
                FolderName = partialFileModel.ProjectName;
            }

            string day = DateTime.Now.ToString("yyyyMMdd");
            string folder = FolderName + "/" + day;
            string filePath = $"{AppConfig.FileUploadRootDirectory}/{folder}";

            if (Directory.Exists(filePath) == false)// 如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(filePath);
            }
            string longName = Guid.NewGuid().ToString();
            string SaveFileName = longName + partialFileModel.FileExtension; // 保存文件名称

            using (FileStream fs = File.Create(filePath + "/" + SaveFileName))
            {
                fs.Write(mergeFileBytes.ToArray(), 0, mergeFileBytes.Count);
            }

            systemFiles = new SystemFiles()
            {
                FileId = partialFileModel.FileId,
                FileData = null,
                FilePath = folder + "/" + SaveFileName,
                FileExtension = partialFileModel.FileExtension,
                FileName = partialFileModel.FileName,
                FileLongName = SaveFileName,
                FileSize = mergeFileBytes.Count,
                ProjectName = partialFileModel.ProjectName,
                CreateDate = DateTime.Now,
                FileCompressStatus = EnumFileCompressStatus.Uncompressed,
                TobeArchiveDateTime = DateTime.Now.AddDays((int)EnumArchivePeriod.Quarter)
            };

            dbContext.SystemFiles.Add(systemFiles);

            dbContext.SaveChanges();

            partialFileModel.Id = systemFiles.Id;

            // 删除上传的分片小文件
            foreach (var file in partialFileList)
            {
                if (file.Exists)
                {
                    file.Delete();
                }
            }
        }

        private string GenerateToken(FileToken fileToken)
        {
            var token = rsaManager.RSAEncrypt(File.ReadAllText(AppConfig.PublicKeyFilePath), $"{fileToken.Username + fileToken.Password + fileToken.FileId }");

            return token;
        }

        private bool IsImage(SystemFilesView model)
        {
            return AppConfig.ImageExtension.Contains(model.FileExtension.ToLower());
        }
    }
}

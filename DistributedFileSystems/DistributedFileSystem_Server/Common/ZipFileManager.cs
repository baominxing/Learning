using FileCenter.Common;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileCenter
{
    public class ZipFileManager
    {

        #region 压缩
        public static void CompressFileList(List<FileInfo> fileInfoList, string destinationArchiveFileName)
        {
            using (var zipfs = File.OpenWrite(destinationArchiveFileName))
            using (var zipos = new ZipOutputStream(zipfs))
            {
                zipos.SetLevel(8);

                foreach (var fileInfo in fileInfoList)
                {
                    using (FileStream fs = fileInfo.OpenRead())
                    {
                        var buffer = new byte[4 * 1024];

                        var entry = new ZipEntry(fileInfo.Name)
                        {
                            DateTime = DateTime.Now
                        };

                        zipos.PutNextEntry(entry);

                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            zipos.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                    LogHelper.Info($"Archived File : {fileInfo.Name}");
                }

                zipos.CloseEntry();
            }
        }
        #endregion

        #region 解压
        public static void DepressFile(string destinationArchiveFileName, string sourceFileName, string targetFileName)
        {
            if (!File.Exists(destinationArchiveFileName))
            {
                throw new FileNotFoundException($"ZipFile {destinationArchiveFileName} is not found.");
            }

            using (var zipfs = File.OpenRead(destinationArchiveFileName))
            using (var zipis = new ZipInputStream(zipfs))
            {
                ZipEntry theEntry;
                while ((theEntry = zipis.GetNextEntry()) != null)
                {
                    if (theEntry.Name != string.Empty && theEntry.Name == sourceFileName)
                    {
                        using (FileStream streamWriter = File.Create(targetFileName))
                        {


                            int size = 4096;
                            byte[] data = new byte[4 * 1024];
                            while (true)
                            {
                                size = zipis.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else break;
                            }

                            LogHelper.Info($"Depressd File : {sourceFileName}");

                            break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}

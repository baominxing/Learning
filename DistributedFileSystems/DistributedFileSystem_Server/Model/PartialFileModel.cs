using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileCenter.Model
{
    /// <summary>
    /// 分片上传文件类型
    /// </summary>
    [Table("PartialFileModels")]
    public class PartialFileModel
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(200)]
        public string FileExtension { get; set; }

        [MaxLength(200)]
        public string FilePath { get; set; }

        [MaxLength(200)]
        public string ProjectName { get; set; }

        [Index]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [Index]
        public Guid? FileId { get; set; }

        /// <summary>
        /// 分片数量
        /// </summary>
        public int PartialCount { get; set; }

        /// <summary>
        /// 分片索引Id
        /// </summary>
        public int PartialId { get; set; }

        /// <summary>
        /// 上传大文件是否已经合并
        /// </summary>
        public bool IsMerged { get; set; }

        [NotMapped]
        public byte[] FileData { get; set; }

        [NotMapped]
        public string Message { get; internal set; }

        [NotMapped]
        public bool IsSuccess { get; set; }

        [NotMapped]
        public EnumArchivePeriod ArchivePeriod { get; set; }
    }
}
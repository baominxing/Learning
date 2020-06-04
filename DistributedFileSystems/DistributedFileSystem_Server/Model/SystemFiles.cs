using FileCenter.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileCenter
{
    [Table("SystemFiles")]
    public class SystemFiles
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(200)]
        public string FileLongName { get; set; }

        [MaxLength(200)]
        public string FileExtension { get; set; }

        public int? FileSize { get; set; }

        public byte[] FileData { get; set; }

        [MaxLength(200)]
        public string FilePath { get; set; }

        public string ProjectName { get; set; }

        public int? IsDelete { get; set; }

        [Index]
        public DateTime? CreateDate { get; set; }

        [Index]
        public Guid? FileId { get; set; }

        public EnumFileCompressStatus? FileCompressStatus { get; set; }

        [MaxLength(500)]
        public string ArchiveFileName { get; set; }

        public DateTime? ArchiveDateTime { get; set; }

        public DateTime? DecompressDateTime { get; set; }

        public DateTime? TobeArchiveDateTime { get; set; }

        [NotMapped]
        public Guid? PdfFileId { get; set; }

        [NotMapped]
        public string CoverSavePath { get; set; }

        [NotMapped]
        public Guid? CoverFileId { get; set; }
    }

    public class SystemFilesView
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileLongName { get; set; }

        public string FileExtension { get; set; }

        public int? FileSize { get; set; }

        public byte[] FileData { get; set; }

        public string FilePath { get; set; }

        public string ProjectName { get; set; }

        public int? IsDelete { get; set; }

        public DateTime? CreateDate { get; set; }

        public Guid? FileId { get; set; }

        public EnumArchivePeriod ArchivePeriod { get; set; } = EnumArchivePeriod.Quarter;
    }
}

ALTER TABLE [dbo].[SystemFiles] ADD [FileCompressStatus] INT NULL;
ALTER TABLE [dbo].[SystemFiles] ADD [ArchiveFileName] NVARCHAR(500) NULL;
ALTER TABLE [dbo].[SystemFiles] ADD [ArchiveDateTime] DATETIME NULL;
ALTER TABLE [dbo].[SystemFiles] ADD [DecompressDateTime] DATETIME NOT NULL;
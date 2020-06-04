--2019-01-11 创建
USE [FileCenter]
GO

/****** Object:  Table [dbo].[SystemFiles]    Script Date: 2019/1/10 11:25:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--创建上传记录表
--CREATE TABLE [dbo].[SystemFiles](
--	[Id] [INT] IDENTITY(1,1) NOT NULL,
--	[FileName] [NVARCHAR](200) NULL,
--	[FileLongName] [NVARCHAR](200) NULL,
--	[FileExtension] [NVARCHAR](200) NULL,
--	[FileSize] [INT] NULL,
--	[FileData] [VARBINARY](MAX) NULL,
--	[FilePath] [NVARCHAR](200) NULL,
--	[ProjectName] [NVARCHAR](MAX) NULL,
--	[IsDelete] [INT] NULL,
--	[CreateDate] [DATETIME] NULL,
--	[FileId] [UNIQUEIDENTIFIER] NULL,
--	[FileCompressStatus] [INT] NULL,
--	[ArchiveFileName] [NVARCHAR](500) NULL,
--	[ArchiveDateTime] [DATETIME] NULL,
--	[DecompressDateTime] [DATETIME] NULL,
-- CONSTRAINT [PK_dbo.SystemFiles] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO

--ALTER TABLE [dbo].[SystemFiles] ADD  DEFAULT ((0)) FOR [FileCompressStatus]
--GO

----创建归档操作表
--CREATE TABLE [dbo].[Operates](
--	[Id] [INT] IDENTITY(1,1) NOT NULL,
--	[OperateType] [INT] NOT NULL,
--	[CreationTime] [DATETIME] NOT NULL,
--	[StartDate] [DATETIME] NOT NULL,
--	[EndDate] [DATETIME] NOT NULL,
--	[OperateResult] [INT] NOT NULL,
-- CONSTRAINT [PK_dbo.Operates] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO


----创建大文件上传表
--CREATE TABLE [dbo].[PartialFileModels](
--	[Id] [INT] IDENTITY(1,1) NOT NULL,
--	[FileName] [NVARCHAR](200) NULL,
--	[FileExtension] [NVARCHAR](200) NULL,
--	[FilePath] [NVARCHAR](200) NULL,
--	[ProjectName] [NVARCHAR](200) NULL,
--	[CreateDate] [DATETIME] NULL,
--	[FileId] [UNIQUEIDENTIFIER] NULL,
--	[PartialCount] [INT] NOT NULL,
--	[PartialId] [INT] NOT NULL,
--	[IsMerged] [BIT] NOT NULL,
-- CONSTRAINT [PK_dbo.PartialFileModels] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO

----创建方法
--CREATE FUNCTION [dbo].[Get_StrArrayStrOfTable]
--(
--    @SourceSql VARCHAR(MAX),
--    @StrSeprate VARCHAR(10)
--)
--RETURNS @temp TABLE
--(
--    F1 VARCHAR(100)
--)
--AS
--BEGIN
--    DECLARE @i INT;
--    SET @SourceSql = RTRIM(LTRIM(@SourceSql));
--    SET @i = CHARINDEX(@StrSeprate, @SourceSql);
--    WHILE @i >= 1
--    BEGIN
--        INSERT @temp
--        VALUES
--        (LEFT(@SourceSql, @i - 1));
--        SET @SourceSql = SUBSTRING(@SourceSql, @i + 1, LEN(@SourceSql) - @i);
--        SET @i = CHARINDEX(@StrSeprate, @SourceSql);
--    END;

--    IF @SourceSql <> ''
--        INSERT @temp
--        VALUES
--        (@SourceSql);

--    RETURN;
--END;
--GO

--20190222新增TobeArchiveDateTime字段
--ALTER TABLE dbo.SystemFiles ADD TobeArchiveDateTime DATETIME NULL 
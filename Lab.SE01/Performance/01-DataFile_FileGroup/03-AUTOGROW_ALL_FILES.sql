--------------------------------------------------------------------
/*
SQL Server کارگاه افزایش سرعت بانک های اطلاعاتی در 
Site:        http://www.NikAmooz.com
Email:       Info@NikAmooz.com
Instagram:   https://instagram.com/nikamooz/
Telegram:	 https://telegram.me/nikamooz
Created By:  Masoud Taheri 
*/
--------------------------------------------------------------------
USE MASTER
GO
--بررسی جهت وجود بانک اطلاعاتی و حذف آن
IF DB_ID('DB_2019')>0
BEGIN
	ALTER DATABASE DB_2019 SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE  DB_2019 
END
GO
--ایجاد بانک اطلاعاتی
CREATE DATABASE DB_2019
 ON  PRIMARY
	( NAME = N'DB_2019_1', FILENAME = N'C:\Dump\DB_2019_1.mdf' , SIZE = 10MB , FILEGROWTH = 5MB ),
	( NAME = N'DB_2019_2', FILENAME = N'C:\Dump\DB_2019_2.ndf' , SIZE = 10MB , FILEGROWTH = 5MB ),
	( NAME = N'DB_2019_3', FILENAME = N'C:\Dump\DB_2019_3.ndf' , SIZE = 10MB , FILEGROWTH = 5MB)
 LOG ON
	( NAME = N'DB_2019_log', FILENAME = N'C:\Dump\DB_2019_log.ldf' , SIZE = 100MB , FILEGROWTH = 100MB)
GO 
--تنظیم نحوه رشد دیتا فایل ها
ALTER DATABASE DB_2019 MODIFY FILEGROUP [PRIMARY] AUTOGROW_ALL_FILES
GO
USE DB_2019
GO
--بررسی تعداد دیتا فایل ها + ظرفیت آنها
SELECT
    DB_NAME() AS [db_name],
    mf.name AS logical_name,
    fg.name as [filegroup_name],
	CAST((mf.Size /128.0) AS DECIMAL(10,2)) AS [SizeMB],
    fg.is_autogrow_all_files
FROM sys.database_files AS mf
JOIN sys.filegroups AS fg
    ON mf.data_space_id = fg.data_space_id
GO
--پاک کردن جدول و ایجاد آن
DROP TABLE IF EXISTS dbo.test_2019
GO
CREATE TABLE dbo.test_2019
(
    id INT IDENTITY,
    col1 CHAR(8000) DEFAULT 'T'
)
GO
--درج دیتا تستی
INSERT INTO dbo.test_2019 DEFAULT VALUES;
GO 3500
GO
--بررسی تعداد دیتا فایل ها + ظرفیت آنها
SELECT
    DB_NAME() AS [db_name],
    mf.name AS logical_name,
    fg.name as [filegroup_name],
	CAST((mf.Size /128.0) AS DECIMAL(10,2)) AS [SizeMB],
    fg.is_autogrow_all_files
FROM sys.database_files AS mf
JOIN sys.filegroups AS fg
    ON mf.data_space_id = fg.data_space_id
GO
--بررسی ظرفیت پرشده دیتا فایل ها
SELECT
    name AS logical_name,
    size / 128 AS size_mb,
    CAST(FILEPROPERTY(name, 'SpaceUsed') * 100. / size AS DECIMAL(5, 2)) AS [%_free]
FROM sys.database_files
WHERE type_desc = 'ROWS'
GO
--درج دیتا در جدول
INSERT INTO dbo.test_2019 DEFAULT VALUES;
GO 100
GO
--بررسی تعداد دیتا فایل ها + ظرفیت آنها
SELECT
    DB_NAME() AS [db_name],
    mf.name AS logical_name,
    fg.name as [filegroup_name],
	CAST((mf.Size /128.0) AS DECIMAL(10,2)) AS [SizeMB],
    fg.is_autogrow_all_files
FROM sys.database_files AS mf
JOIN sys.filegroups AS fg
    ON mf.data_space_id = fg.data_space_id
GO
--بررسی ظرفیت پرشده دیتا فایل ها
SELECT
    name AS logical_name,
    size / 128 AS size_mb,
    CAST(FILEPROPERTY(name, 'SpaceUsed') * 100. / size AS DECIMAL(5, 2)) AS [%_free]
FROM sys.database_files
WHERE type_desc = 'ROWS'
GO

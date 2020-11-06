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
IF DB_ID('NikAmoozDB')>0
BEGIN
	ALTER DATABASE NikAmoozDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE NikAmoozDB
END
GO
--ایجاد یک بانک اطلاعاتی ساده
CREATE DATABASE NikAmoozDB
GO
USE NikAmoozDB
GO
--مشاهده فایل های بانک اطلاعاتی 
SP_HELPFILE
GO
SELECT FILE_ID,name,size,max_size,growth FROM sys.database_files
GO
--------------------------------------------------------------------
USE master
GO
IF DB_ID('NikAmoozDB')>0
BEGIN
	ALTER DATABASE NikAmoozDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE NikAmoozDB
END
GO
--ایجاد بانک اطلاعاتی موجود در اسلاید
CREATE DATABASE NikAmoozDB 
	ON  PRIMARY
	(
		NAME=NikAmoozDB_Primary,FILENAME='D:\Database\NikAmoozDB_Primary.mdf',SIZE=100MB
	),
	FILEGROUP FG_Data
	(
		NAME=Data1,FILENAME='D:\Database\Data1.ndf',SIZE=1GB,FILEGROWTH=1GB
	),
	FILEGROUP FG_BLOB
	(
		NAME=Data_Blob1,FILENAME='D:\Database\Data_Blob1.ndf',SIZE=1GB,FILEGROWTH=1GB
	),
	(
		NAME=Data_Blob2,FILENAME='D:\Database\Data_Blob2.ndf',SIZE=1GB,FILEGROWTH=1GB
	)
	LOG ON
	(
		NAME=NikAmoozDB_Log,FILENAME='D:\Database\NikAmoozDB_Log.LDF',SIZE=1GB,FILEGROWTH=512MB
	)
GO
--در نظر می گیریمUniform Extent حالا بانک را 
--این مدل به طور پیش فرض در نسخه 2016 مورد استفاده قرار می گیرد
--1118
ALTER DATABASE NikAmoozDB SET MIXED_PAGE_ALLOCATION OFF;
GO
--تنظیم نحوه رشد دیتا فایل ها
--1117
ALTER DATABASE NikAmoozDB MODIFY FILEGROUP FG_BLOB AUTOGROW_ALL_FILES
GO
--بررسی ارسال جدول به فایل گروه
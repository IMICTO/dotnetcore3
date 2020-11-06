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
--بررسی جهت وجود بانک اطلاعاتی
IF DB_ID('Clinic_Old')>0
BEGIN
	ALTER DATABASE Clinic_Old SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE Clinic_Old
END
GO
--بررسی جهت وجود بانک اطلاعاتی
IF DB_ID('Clinic_New')>0
BEGIN
	ALTER DATABASE Clinic_New SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE Clinic_New
END
GO
--بازیابی بانک اطلاعاتی
RESTORE DATABASE Clinic_Old FROM DISK='D:\Dump\ClinicPooya.bak' 
WITH
	MOVE 'ClinicPooya' TO 'D:\dump\ClinicPooya_Old.mdf',
	MOVE 'ClinicPooya_log' TO 'D:\dump\ClinicPooya_log_Old.ldf',
	STATS=1,REPLACE
GO
--بازیابی بانک اطلاعاتی
RESTORE DATABASE Clinic_New FROM DISK='D:\Dump\ClinicPooya.bak' 
WITH
	MOVE 'ClinicPooya' TO 'D:\dump\ClinicPooya_New.mdf',
	MOVE 'ClinicPooya_log' TO 'D:\dump\ClinicPooya_log_New.ldf',
	STATS=1,REPLACE
GO
--------------------------------------------------------------------
--Master Detail مشاهده جدول 
USE Clinic_Old
GO
--بررسی ساختار جدول
SP_HELP tbGhabzPaziresh
GO
SP_HELP tbGhabzService
GO
--بررسی ایندکس های جدول
SP_HELPINDEX tbGhabzPaziresh
GO
SP_HELPINDEX tbGhabzService
GO
--استخراج گزارش بر اساس تاریخ مراجعه
--Show Execution Plan  & Show IO 
SET STATISTICS IO ON
GO
SELECT * FROM Clinic_Old..tbGhabzPaziresh
	INNER JOIN Clinic_Old..tbGhabzService
	ON tbGhabzPaziresh.IDGhabz=tbGhabzService.IDGhabz
WHERE tbGhabzPaziresh.DateMorajeh BETWEEN '1394/01/01' AND '1394/01/31'
GO
--------------------------------------------------------------------
--تغییر ایندکس کلاستر جداول
/*
1- Change Primary Key (Non Clustered) ** Wizard & Generate Script
2- Create Unique Clustered Index
*/
USE Clinic_New
GO
--مشاهده ایندکس های جدول
SP_HELPINDEX tbGhabzPaziresh
GO
--مشاهده ایندکس های جدول
SP_HELPINDEX tbGhabzService
GO
--------------------------------------------------------------------
--****tbGhabzPaziresh****
--Primary Key = IDGhabz (NonClustered/AsClustered=False)
--Unique Clustered Index =DateMorajeh,IDGhabz
--Show Actual Plan
CREATE UNIQUE CLUSTERED INDEX IX_Clustered_tbGhabzPaziresh ON tbGhabzPaziresh(DateMorajeh,IDGhabz)
GO
--****tbGhabzService****
--Primary Key = IDGhabzService (NonClustered/AsClustered=False)
--Unique Clustered Index =IDGhabz,IDGhabzService
--Show Actual Plan
CREATE UNIQUE CLUSTERED INDEX IX_Clustered_tbGhabzService ON tbGhabzService(IDGhabz,IDGhabzService)
GO
/*
--مرتب سازی در ایندکس های مرکب بر اساس سمت چپ ترین به سمت راست ترین ستون است
*/

SET STATISTICS IO ON 
GO
--مقایسه حالت قدیم
SELECT * FROM Clinic_Old..tbGhabzPaziresh
	INNER JOIN Clinic_Old..tbGhabzService
	ON tbGhabzPaziresh.IDGhabz=tbGhabzService.IDGhabz
WHERE tbGhabzPaziresh.DateMorajeh BETWEEN '1394/01/01' AND '1394/01/31'
GO

--مقایسه حالت جدید
SELECT * FROM Clinic_New..tbGhabzPaziresh
	INNER JOIN Clinic_New..tbGhabzService
	ON tbGhabzPaziresh.IDGhabz=tbGhabzService.IDGhabz
WHERE tbGhabzPaziresh.DateMorajeh BETWEEN '1394/01/01' AND '1394/01/31'
GO
--بررسی حجم ایندکس
SELECT 
	S.index_id,S.index_type_desc,S.alloc_unit_type_desc,
	S.index_depth,S.index_level,S.page_count ,S.record_count
	FROM 
		sys.dm_db_index_physical_stats
			(DB_ID('Clinic_Old'),OBJECT_ID('tbGhabzService'),NULL,NULL,'DETAILED') S
	WHERE  index_level=0
GO
SELECT 
	S.index_id,S.index_type_desc,S.alloc_unit_type_desc,
	S.index_depth,S.index_level,S.page_count ,S.record_count
	FROM 
		sys.dm_db_index_physical_stats
			(DB_ID('Clinic_New'),OBJECT_ID('tbGhabzService'),NULL,NULL,'DETAILED') S
	WHERE  index_level=0
GO

--FactInternetSalesبررسی ایندکس های 
USE AdventureWorksDW2017
GO
--حواستان به کلید اصلی باشد
GO
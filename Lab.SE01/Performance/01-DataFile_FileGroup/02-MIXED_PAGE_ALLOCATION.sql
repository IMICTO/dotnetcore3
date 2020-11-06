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
GO
USE DB_2019
GO
--ها در دیتابیسPage بودن  Miexed Page Allocation بررسی 
--هاExtent بود Uniform Extent اگر مقدار برابر با صفر باشد این موضوع برابر است با 
SELECT
    name, is_mixed_page_allocation_on
FROM sys.databases
GO
CREATE TABLE dbo.test_2019
(
    id INT IDENTITY,
    col1 CHAR(8000) DEFAULT 'T'
)
GO
--در نظر می گیریمMixed Extent حالا بانک را 
ALTER DATABASE [DB_2019] SET MIXED_PAGE_ALLOCATION ON;
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
--چند بار انجام شود
INSERT INTO dbo.test_2019 DEFAULT VALUES;
GO
SELECT
    OBJECT_NAME(object_id) AS table_name,
    index_id,
    [partition_id],
    extent_page_id,
    allocated_page_page_id,
    page_type_desc as page_type 
FROM sys.dm_db_database_page_allocations(DB_ID(), OBJECT_ID('dbo.test_2019'),0, NULL, 'DETAILED')
GO
--در نظر می گیریمUniform Extent حالا بانک را 
--این مدل به طور پیش فرض در نسخه 2016 مورد استفاده قرار می گیرد
ALTER DATABASE [DB_2019] SET MIXED_PAGE_ALLOCATION OFF;
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
--چند بار اجرا به ستون آخر توجه شود
INSERT INTO dbo.test_2019 DEFAULT VALUES;
GO
SELECT
    OBJECT_NAME(object_id) AS table_name,
    index_id,
    [partition_id],
    extent_page_id,
    allocated_page_page_id,
    page_type_desc as page_type
FROM sys.dm_db_database_page_allocations(DB_ID(), OBJECT_ID('dbo.test_2019'), 0, NULL, 'DETAILED')
GO

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
USE master
GO
IF DB_ID('ClinicDW1')>0
BEGIN
	ALTER DATABASE ClinicDW1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE ClinicDW1
END
GO
--ایجاد بانک اطلاعاتی موجود در اسلاید
CREATE DATABASE ClinicDW1 
	ON  PRIMARY
	(
		NAME=ClinicDW1_Primary,FILENAME='D:\Database\ClinicDW1_Primary.mdf',SIZE=100MB
	),
	FILEGROUP FG_Dimension
	(
		NAME=Data_Dimension1,FILENAME='D:\Database\Data_Dimension1.ndf',SIZE=1GB,FILEGROWTH=1GB
	),
	(
		NAME=Data_Dimension2,FILENAME='D:\Database\Data_Dimension2.ndf',SIZE=1GB,FILEGROWTH=1GB
	),
	FILEGROUP FG_Fact
	(
		NAME=Data_Fact1,FILENAME='D:\Database\Data_Fact1.ndf',SIZE=1GB,FILEGROWTH=1GB
	),
	(
		NAME=Data_Fact2,FILENAME='D:\Database\Data_Fact2.ndf',SIZE=1GB,FILEGROWTH=1GB
	)
	LOG ON
	(
		NAME=ClinicDW1_Log,FILENAME='D:\Database\ClinicDW1_Log.LDF'--,SIZE=1GB,FILEGROWTH=512MB
	)
GO
USE ClinicDW1
GO
--هاVLF مشاهده
DBCC LOGINFO
GO
--مشاهده محتوای لاگ رکوردها
SELECT * FROM SYS.fn_dblog(NULL,NULL)
GO
-------------------------------------------------------------------
--Check Recovery Model
SELECT 
	database_id,name,recovery_model_desc 
FROM SYS.databases
WHERE name='ClinicDW1'
GO
SELECT 
	name ,
	recovery_model_desc ,
	log_reuse_wait_desc
FROM	sys.databases
WHERE	name = 'Test01'
GO
/*
1. Don’t create multiple log files : As transactions will be logged into log file sequential manner it would not help for data stripping across multiple files
2. Keep the transaction log file on the separate drive
3. choose the recovery model and correct log backup strategy
4. RAID 1 + 0 is high recommended for transaction log
5. AUTO SHRINK should be always off on the database
6. Pre-allocate the space to transaction log file, it will improve the performance. Don’t depend on the auto growth option.
7. Always set the values of Initial size, max size and growth property of the transaction log file
8. Always set auto growth value, don’t set in percentage
9. Transaction Log file internal fragmentation can also lead the performance and database recovery issue. 
	Database should not have an excessive number of Virtual Log Files (VLFs) inside the Transaction Log. 
	Having a large number of small VLFs can slow down the recovery process that a database goes
	through on startup or after restoring a backup.
	Make sure transaction log initial size and log growth 
	defined well to avoid internal fragmentation
10. External fragmentation can be removed by using disk defragmentation utility
11. In case of Transaction log full, please use below query to check the cause of the log full and take the decision accordingly.
*/

CREATE DATABASE ClinicDW1 
GO
USE ClinicDW1
GO
DBCC LOGINFO
GO
CREATE TABLE T1
(
	C1 INT 
)

INSERT INTO T1 VALUES (1)

GO
CHECKPOINT
GO
SELECT * FROM fn_dblog(NULL,NULL)
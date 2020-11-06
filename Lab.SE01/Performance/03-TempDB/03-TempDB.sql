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
ALTER DATABASE tempdb MODIFY FILE (NAME=tempdev,SIZE=512MB,FILEGROWTH=100MB)
ALTER DATABASE tempdb ADD FILE (NAME=tempdev2,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev2.ndf') 
ALTER DATABASE tempdb ADD FILE (NAME=tempdev3,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev3.ndf')
ALTER DATABASE tempdb ADD FILE (NAME=tempdev4,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev4.ndf')
ALTER DATABASE tempdb ADD FILE (NAME=tempdev5,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev5.ndf') 
ALTER DATABASE tempdb ADD FILE (NAME=tempdev6,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev6.ndf')
ALTER DATABASE tempdb ADD FILE (NAME=tempdev7,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev7.ndf')
ALTER DATABASE tempdb ADD FILE (NAME=tempdev8,SIZE=512MB,FILEGROWTH=100MB,FILENAME='E:\Database\tempdev8.ndf')
GO
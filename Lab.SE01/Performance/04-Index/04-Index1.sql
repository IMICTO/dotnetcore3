--------------------------------------------------------------------
/*
SQL Server 2019 در Business Intelligence دوره 
Site:        http://www.NikAmooz.com
Email:       Info@NikAmooz.com
Instagram:   https://instagram.com/nikamooz/
Telegram:	 https://telegram.me/nikamooz
Created By:  Masoud Taheri 
*/
--------------------------------------------------------------------

USE ClinicDW
go
SP_HELP DimDoctor
GO
SP_HELPINDEX DimDoctor
GO
SELECT * FROM DimDoctor
GO
CREATE INDEX IX_DoctorPK ON DimDoctor(DoctorPK)
GO
SELECT DoctorPK,DoctorKey FROM DimDoctor 
	ORDER BY DoctorPK
go
SELECT * FROM DimDoctor WITH (INDEX(IX_DoctorPK))
	WHERE DoctorPK=5

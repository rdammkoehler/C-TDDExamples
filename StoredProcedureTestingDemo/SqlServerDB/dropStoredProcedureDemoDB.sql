EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'StoredProcedureDemoDB'
USE [master]
/****** Object:  Database [StoredProcedureDemoDB]    Script Date: 04/07/2009 15:36:34 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'StoredProcedureDemoDB')
begin
	alter database [StoredProcedureDemoDB] set SINGLE_USER with ROLLBACK IMMEDIATE
	alter database [StoredProcedureDemoDB] set SINGLE_USER
	DROP DATABASE [StoredProcedureDemoDB]
end
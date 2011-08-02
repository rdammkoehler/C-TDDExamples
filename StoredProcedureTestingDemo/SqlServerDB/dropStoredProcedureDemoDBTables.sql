USE [StoredProcedureDemoDB]
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_AccountType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_AccountType]
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_UserOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_UserOwner]
USE [StoredProcedureDemoDB]
/****** Object:  Table [dbo].[Account]    Script Date: 04/07/2009 15:33:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
DROP TABLE [dbo].[Account]
USE [StoredProcedureDemoDB]
/****** Object:  Table [dbo].[User]    Script Date: 04/07/2009 15:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
USE [StoredProcedureDemoDB]
/****** Object:  Table [dbo].[AccountType]    Script Date: 04/07/2009 15:34:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND type in (N'U'))
DROP TABLE [dbo].[AccountType]
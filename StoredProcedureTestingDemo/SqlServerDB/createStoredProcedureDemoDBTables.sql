/****** Object:  ForeignKey [FK_Account_AccountType]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_AccountType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_AccountType]
/****** Object:  ForeignKey [FK_Account_UserOwner]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_UserOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_UserOwner]
/****** Object:  Table [dbo].[Account]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
DROP TABLE [dbo].[Account]
/****** Object:  Table [dbo].[AccountType]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND type in (N'U'))
DROP TABLE [dbo].[AccountType]
/****** Object:  Table [dbo].[User]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
/****** Object:  Default [DF_Account_accountId]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Account_accountId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
Begin
ALTER TABLE [dbo].[Account] DROP CONSTRAINT [DF_Account_accountId]

End
/****** Object:  Default [DF_AccountType_accTypeId]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_AccountType_accTypeId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountType]'))
Begin
ALTER TABLE [dbo].[AccountType] DROP CONSTRAINT [DF_AccountType_accTypeId]

End
/****** Object:  Default [DF_User_userId]    Script Date: 04/07/2009 15:18:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_User_userId]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
Begin
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_userId]

End
/****** Object:  Table [dbo].[User]    Script Date: 04/07/2009 15:18:25 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[userId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[userName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[firstName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lastName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
/****** Object:  Table [dbo].[AccountType]    Script Date: 04/07/2009 15:18:25 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccountType](
	[accTypeId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[typeName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[accTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
/****** Object:  Table [dbo].[Account]    Script Date: 04/07/2009 15:18:25 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Account](
	[accountId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[accountNum] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[accountType] [uniqueidentifier] NOT NULL,
	[userId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
/****** Object:  Default [DF_Account_accountId]    Script Date: 04/07/2009 15:18:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Account_accountId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
Begin
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_accountId]  DEFAULT (newid()) FOR [accountId]

End
/****** Object:  Default [DF_AccountType_accTypeId]    Script Date: 04/07/2009 15:18:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_AccountType_accTypeId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AccountType]'))
Begin
ALTER TABLE [dbo].[AccountType] ADD  CONSTRAINT [DF_AccountType_accTypeId]  DEFAULT (newid()) FOR [accTypeId]

End
/****** Object:  Default [DF_User_userId]    Script Date: 04/07/2009 15:18:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_User_userId]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
Begin
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_userId]  DEFAULT (newid()) FOR [userId]

End
/****** Object:  ForeignKey [FK_Account_AccountType]    Script Date: 04/07/2009 15:18:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_AccountType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([accountType])
REFERENCES [dbo].[AccountType] ([accTypeId])
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
/****** Object:  ForeignKey [FK_Account_UserOwner]    Script Date: 04/07/2009 15:18:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Account_UserOwner]') AND parent_object_id = OBJECT_ID(N'[dbo].[Account]'))
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_UserOwner] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId])
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_UserOwner]

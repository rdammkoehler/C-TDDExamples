USE [StoredProcedureDemoDB]
/****** Object:  StoredProcedure [dbo].[procUserNameAccountNumByType]    Script Date: 04/07/2009 15:27:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procUserNameAccountNumByType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[procUserNameAccountNumByType]


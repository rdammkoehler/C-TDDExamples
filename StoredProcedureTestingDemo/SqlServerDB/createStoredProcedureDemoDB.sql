USE [master]
/****** Object:  Database [StoredProcedureDemoDB]    Script Date: 04/07/2009 14:56:59 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'StoredProcedureDemoDB')
DROP DATABASE [StoredProcedureDemoDB]

USE [master]
/****** Object:  Database [StoredProcedureDemoDB]    Script Date: 04/07/2009 14:52:56 ******/
CREATE DATABASE [StoredProcedureDemoDB] ON  PRIMARY 
( NAME = N'StoredProcedureDemoDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\StoredProcedureDemoDB.mdf' , SIZE = 2240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StoredProcedureDemoDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\StoredProcedureDemoDB_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
EXEC dbo.sp_dbcmptlevel @dbname=N'StoredProcedureDemoDB', @new_cmptlevel=90
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoredProcedureDemoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
ALTER DATABASE [StoredProcedureDemoDB] SET ANSI_NULL_DEFAULT OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET ANSI_NULLS OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET ANSI_PADDING OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET ANSI_WARNINGS OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET ARITHABORT OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET AUTO_CLOSE ON 
ALTER DATABASE [StoredProcedureDemoDB] SET AUTO_CREATE_STATISTICS ON 
ALTER DATABASE [StoredProcedureDemoDB] SET AUTO_SHRINK OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET AUTO_UPDATE_STATISTICS ON 
ALTER DATABASE [StoredProcedureDemoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET CURSOR_DEFAULT  GLOBAL 
ALTER DATABASE [StoredProcedureDemoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET NUMERIC_ROUNDABORT OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET QUOTED_IDENTIFIER OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET RECURSIVE_TRIGGERS OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET  ENABLE_BROKER 
ALTER DATABASE [StoredProcedureDemoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET TRUSTWORTHY OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
ALTER DATABASE [StoredProcedureDemoDB] SET PARAMETERIZATION SIMPLE 
ALTER DATABASE [StoredProcedureDemoDB] SET  READ_WRITE 
ALTER DATABASE [StoredProcedureDemoDB] SET RECOVERY SIMPLE 
ALTER DATABASE [StoredProcedureDemoDB] SET  MULTI_USER 
ALTER DATABASE [StoredProcedureDemoDB] SET PAGE_VERIFY CHECKSUM  
ALTER DATABASE [StoredProcedureDemoDB] SET DB_CHAINING OFF 
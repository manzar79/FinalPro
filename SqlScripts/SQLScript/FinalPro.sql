USE [master]
GO

/****** Object:  Database [FinalProjectDB]    Script Date: 8/4/2014 3:40:02 PM ******/
CREATE DATABASE [FinalProjectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinalProjectDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FinalProjectDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FinalProjectDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FinalProjectDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [FinalProjectDB] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinalProjectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [FinalProjectDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [FinalProjectDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [FinalProjectDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [FinalProjectDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [FinalProjectDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [FinalProjectDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [FinalProjectDB] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [FinalProjectDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [FinalProjectDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [FinalProjectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [FinalProjectDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [FinalProjectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [FinalProjectDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [FinalProjectDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [FinalProjectDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [FinalProjectDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [FinalProjectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [FinalProjectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [FinalProjectDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [FinalProjectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [FinalProjectDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [FinalProjectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [FinalProjectDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [FinalProjectDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [FinalProjectDB] SET  MULTI_USER 
GO

ALTER DATABASE [FinalProjectDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [FinalProjectDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [FinalProjectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [FinalProjectDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [FinalProjectDB] SET  READ_WRITE 
GO


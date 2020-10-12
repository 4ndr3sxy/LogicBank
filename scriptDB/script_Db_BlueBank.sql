USE [master]
GO
/****** Object:  Database [db_blue_bank]    Script Date: 10/12/2020 12:02:42 PM ******/
CREATE DATABASE [db_blue_bank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_blue_bank', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLXY\MSSQL\DATA\db_blue_bank.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_blue_bank_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLXY\MSSQL\DATA\db_blue_bank_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_blue_bank] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_blue_bank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_blue_bank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_blue_bank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_blue_bank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_blue_bank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_blue_bank] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_blue_bank] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_blue_bank] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_blue_bank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_blue_bank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_blue_bank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_blue_bank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_blue_bank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_blue_bank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_blue_bank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_blue_bank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_blue_bank] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_blue_bank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_blue_bank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_blue_bank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_blue_bank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_blue_bank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_blue_bank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_blue_bank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_blue_bank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_blue_bank] SET  MULTI_USER 
GO
ALTER DATABASE [db_blue_bank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_blue_bank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_blue_bank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_blue_bank] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_blue_bank]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 10/12/2020 12:02:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [varchar](128) NOT NULL,
	[balance] [int] NOT NULL,
	[fk_user_id] [varchar](128) NOT NULL,
	[date_created] [date] NULL,
	[date_updated] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 10/12/2020 12:02:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [varchar](128) NOT NULL,
	[name] [varchar](64) NOT NULL,
	[last_name] [varchar](64) NULL,
	[addres] [varchar](128) NOT NULL,
	[phone] [varchar](64) NOT NULL,
	[city] [varchar](128) NOT NULL,
	[country] [varchar](64) NOT NULL,
	[user_login] [varchar](32) NOT NULL,
	[password_login] [varchar](64) NOT NULL,
	[date_created] [date] NULL,
	[date_updated] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD FOREIGN KEY([fk_user_id])
REFERENCES [dbo].[users] ([id])
GO
USE [master]
GO
ALTER DATABASE [db_blue_bank] SET  READ_WRITE 
GO

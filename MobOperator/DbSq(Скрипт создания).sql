USE [master]
GO
/****** Object:  Database [MobileOperator]    Script Date: 27.12.2020 15:14:03 ******/
CREATE DATABASE [MobileOperator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MobileOperator', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MobileOperator.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MobileOperator_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MobileOperator_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MobileOperator] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MobileOperator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MobileOperator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MobileOperator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MobileOperator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MobileOperator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MobileOperator] SET ARITHABORT OFF 
GO
ALTER DATABASE [MobileOperator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MobileOperator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MobileOperator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MobileOperator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MobileOperator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MobileOperator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MobileOperator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MobileOperator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MobileOperator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MobileOperator] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MobileOperator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MobileOperator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MobileOperator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MobileOperator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MobileOperator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MobileOperator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MobileOperator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MobileOperator] SET RECOVERY FULL 
GO
ALTER DATABASE [MobileOperator] SET  MULTI_USER 
GO
ALTER DATABASE [MobileOperator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MobileOperator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MobileOperator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MobileOperator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MobileOperator] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MobileOperator', N'ON'
GO
ALTER DATABASE [MobileOperator] SET QUERY_STORE = OFF
GO
USE [MobileOperator]
GO
/****** Object:  Table [dbo].[AddBalance]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddBalance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NULL,
	[SumForAdd] [int] NULL,
	[phoneNumberForAddBalance] [nvarchar](50) NULL,
	[numberBankCard] [nvarchar](50) NULL,
	[nameBankCard] [nvarchar](50) NULL,
	[dateBankCard] [date] NULL,
	[CVVBankCard] [int] NULL,
	[dateAddBalance] [date] NULL,
 CONSTRAINT [PK_AddBalance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Call]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Call](
	[dateCall] [date] NULL,
	[timeTalk] [int] NULL,
	[numberWasCall] [nvarchar](50) NULL,
	[callType] [int] NULL,
	[costCall] [decimal](18, 0) NULL,
	[incomingCall] [bit] NULL,
	[idClient] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Call] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phoneNumber] [varchar](50) NULL,
	[dateConnect] [date] NULL,
	[balance] [decimal](18, 0) NULL,
	[isPhysCl] [bit] NULL,
	[password] [nchar](10) NULL,
	[freeMin] [int] NULL,
	[freeSms] [int] NULL,
	[freeGB] [real] NULL,
	[name] [nchar](10) NULL,
	[surName] [nchar](10) NULL,
	[dateOfBirth] [date] NULL,
	[numberPassport] [nchar](10) NULL,
	[nameOrganization] [nvarchar](50) NULL,
	[legalAdress] [nvarchar](50) NULL,
	[ITN] [nchar](10) NULL,
	[startDate] [date] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConnectService]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConnectService](
	[idConnectServ] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NULL,
	[idExtraService] [int] NULL,
	[dateConnectBegin] [date] NULL,
	[dateConnectEnd] [date] NULL,
 CONSTRAINT [PK_ConnectService] PRIMARY KEY CLUSTERED 
(
	[idConnectServ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConnectTariff]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConnectTariff](
	[idConnectTariff] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NULL,
	[idTariffPlan] [int] NOT NULL,
	[dateConnectTariffBegin] [date] NULL,
	[dateConnectTariffEnd] [date] NULL,
 CONSTRAINT [PK_ConnectTariff] PRIMARY KEY CLUSTERED 
(
	[idConnectTariff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtraService]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraService](
	[name] [nvarchar](50) NULL,
	[subscFee] [decimal](18, 0) NULL,
	[description] [ntext] NULL,
	[CanConnectThisSer] [bit] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ExtraService] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sms]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NULL,
	[dateSms] [date] NULL,
	[recipientSms] [nvarchar](50) NULL,
	[textSms] [text] NULL,
	[costSMS] [decimal](18, 0) NULL,
	[incomingSms] [bit] NULL,
 CONSTRAINT [PK_Sms] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TariffPlan]    Script Date: 27.12.2020 15:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TariffPlan](
	[name] [nvarchar](50) NULL,
	[costOneMinCallCity] [decimal](18, 0) NULL,
	[costOneMinCallOutCity] [decimal](18, 0) NULL,
	[CostOneMinCallInternation] [decimal](18, 0) NULL,
	[intGB] [real] NULL,
	[SMS] [int] NULL,
	[isPhysTar] [bit] NULL,
	[costChangeTar] [decimal](18, 0) NULL,
	[CanConnectThisTar] [bit] NULL,
	[subcriptionFee] [int] NULL,
	[freeMinuteForMonth] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[costSms] [decimal](18, 0) NULL,
 CONSTRAINT [PK_TariffPlan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AddBalance]  WITH CHECK ADD  CONSTRAINT [FK_AddBalance_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[AddBalance] CHECK CONSTRAINT [FK_AddBalance_Client]
GO
ALTER TABLE [dbo].[Call]  WITH CHECK ADD  CONSTRAINT [FK_Call_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Call] CHECK CONSTRAINT [FK_Call_Client]
GO
ALTER TABLE [dbo].[ConnectService]  WITH CHECK ADD  CONSTRAINT [FK_ConnectService_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[ConnectService] CHECK CONSTRAINT [FK_ConnectService_Client]
GO
ALTER TABLE [dbo].[ConnectService]  WITH CHECK ADD  CONSTRAINT [FK_ConnectService_ExtraService] FOREIGN KEY([idExtraService])
REFERENCES [dbo].[ExtraService] ([id])
GO
ALTER TABLE [dbo].[ConnectService] CHECK CONSTRAINT [FK_ConnectService_ExtraService]
GO
ALTER TABLE [dbo].[ConnectTariff]  WITH CHECK ADD  CONSTRAINT [FK_ConnectTariff_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[ConnectTariff] CHECK CONSTRAINT [FK_ConnectTariff_Client]
GO
ALTER TABLE [dbo].[ConnectTariff]  WITH CHECK ADD  CONSTRAINT [FK_ConnectTariff_TariffPlan] FOREIGN KEY([idTariffPlan])
REFERENCES [dbo].[TariffPlan] ([id])
GO
ALTER TABLE [dbo].[ConnectTariff] CHECK CONSTRAINT [FK_ConnectTariff_TariffPlan]
GO
ALTER TABLE [dbo].[Sms]  WITH CHECK ADD  CONSTRAINT [FK_Sms_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Sms] CHECK CONSTRAINT [FK_Sms_Client]
GO
USE [master]
GO
ALTER DATABASE [MobileOperator] SET  READ_WRITE 
GO

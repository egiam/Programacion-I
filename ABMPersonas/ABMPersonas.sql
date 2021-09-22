/*
USE [master]
GO
drop database TUPPI
/****** Object:  Database [TUPPI]    Script Date: 3/6/2021 09:17:23 ******/
CREATE DATABASE [TUPPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TUPPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TUPPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TUPPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TUPPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TUPPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TUPPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TUPPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TUPPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TUPPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TUPPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TUPPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [TUPPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TUPPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TUPPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TUPPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TUPPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TUPPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TUPPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TUPPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TUPPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TUPPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TUPPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TUPPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TUPPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TUPPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TUPPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TUPPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TUPPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TUPPI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TUPPI] SET  MULTI_USER 
GO
ALTER DATABASE [TUPPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TUPPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TUPPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TUPPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TUPPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TUPPI] SET QUERY_STORE = OFF
GO*/
USE [TUPPI]
GO
/****** Object:  Table [dbo].[estado_civil]    Script Date: 3/6/2021 09:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado_civil](
	[id_estado_civil] [numeric](2, 0) NOT NULL,
	[n_estado_civil] [varchar](30) NULL,
 CONSTRAINT [PK_estado_civil] PRIMARY KEY CLUSTERED 
(
	[id_estado_civil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personas]    Script Date: 3/6/2021 09:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[apellido] [varchar](30) NULL,
	[nombres] [varchar](30) NULL,
	[tipo_documento] [numeric](2, 0) NULL,
	[documento] [numeric](8, 0) NOT NULL,
	[estado_civil] [numeric](2, 0) NULL,
	[sexo] [numeric](1, 0) NULL,
	[fallecio] [bit] NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 3/6/2021 09:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[id_tipo_documento] [numeric](2, 0) NOT NULL,
	[n_tipo_documento] [varchar](30) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (CAST(1 AS Numeric(2, 0)), N'Soltero')
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (CAST(2 AS Numeric(2, 0)), N'Casado')
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (CAST(3 AS Numeric(2, 0)), N'Viudo')
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (CAST(4 AS Numeric(2, 0)), N'Separado')
GO
INSERT [dbo].[personas] ([apellido], [nombres], [tipo_documento], [documento], [estado_civil], [sexo], [fallecio]) VALUES (N'Perez', N'Juan', CAST(1 AS Numeric(2, 0)), CAST(123456 AS Numeric(8, 0)), CAST(1 AS Numeric(2, 0)), CAST(2 AS Numeric(1, 0)), 1)
GO
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (CAST(1 AS Numeric(2, 0)), N'DNI')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (CAST(2 AS Numeric(2, 0)), N'LE')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (CAST(3 AS Numeric(2, 0)), N'LC')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (CAST(4 AS Numeric(2, 0)), N'Cedula')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (CAST(5 AS Numeric(2, 0)), N'Pasaporte')
GO
USE [master]
GO
ALTER DATABASE [TUPPI] SET  READ_WRITE 
GO

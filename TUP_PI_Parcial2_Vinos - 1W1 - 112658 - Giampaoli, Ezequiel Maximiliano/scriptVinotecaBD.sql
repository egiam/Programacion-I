
--1W1 - 112658 - Giampaoli, Ezequiel Maximiliano

create database Vinoteca

USE [Vinoteca]
GO
/****** Object:  Table [dbo].[Bodegas]    Script Date: 18/6/2021 22:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
set dateformat dmy
go
CREATE TABLE [dbo].[Bodegas](
	[idBodega] [int] NOT NULL,
	[nombreBodega] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Bodegas] PRIMARY KEY CLUSTERED 
(
	[idBodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vinos]    Script Date: 18/6/2021 22:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vinos](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[bodega] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Vinos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bodegas] ([idBodega], [nombreBodega]) VALUES (1, N'Navarro Correas')
INSERT [dbo].[Bodegas] ([idBodega], [nombreBodega]) VALUES (2, N'Norton')
INSERT [dbo].[Bodegas] ([idBodega], [nombreBodega]) VALUES (3, N'Vistalva')
INSERT [dbo].[Bodegas] ([idBodega], [nombreBodega]) VALUES (4, N'Zuccardi')
INSERT [dbo].[Bodegas] ([idBodega], [nombreBodega]) VALUES (5, N'Salentein')
GO
INSERT [dbo].[Vinos] ([codigo], [nombre], [bodega], [precio]) VALUES (1, N'Tardío', 2, 750)
INSERT [dbo].[Vinos] ([codigo], [nombre], [bodega], [precio]) VALUES (2, N'Alegoría', 1, 1200)
INSERT [dbo].[Vinos] ([codigo], [nombre], [bodega], [precio]) VALUES (3, N'Tomero', 3, 900)
GO

create database JJOO
go
USE [JJOO]
GO
/****** Object:  Table [dbo].[Competidores]    Script Date: 26/7/2021 20:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competidores](
	[numero] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[disciplina] [int] NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Competidores] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disciplinas]    Script Date: 26/7/2021 20:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disciplinas](
	[idDisciplina] [int] NOT NULL,
	[nombreDisciplina] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Disciplinas] PRIMARY KEY CLUSTERED 
(
	[idDisciplina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Competidores] ([numero], [nombre], [disciplina], [sexo], [fechaNacimiento]) VALUES (1, N'Juan', 1, N'M', CAST(N'2000-10-10' AS Date))
INSERT [dbo].[Competidores] ([numero], [nombre], [disciplina], [sexo], [fechaNacimiento]) VALUES (2, N'Ana', 3, N'F', CAST(N'2001-10-01' AS Date))
GO
INSERT [dbo].[Disciplinas] ([idDisciplina], [nombreDisciplina]) VALUES (1, N'Natación')
INSERT [dbo].[Disciplinas] ([idDisciplina], [nombreDisciplina]) VALUES (2, N'Esgrima')
INSERT [dbo].[Disciplinas] ([idDisciplina], [nombreDisciplina]) VALUES (3, N'Atletismo')
INSERT [dbo].[Disciplinas] ([idDisciplina], [nombreDisciplina]) VALUES (4, N'Boxeo')
INSERT [dbo].[Disciplinas] ([idDisciplina], [nombreDisciplina]) VALUES (5, N'Tenis')
GO

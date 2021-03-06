USE [Joyeria]
GO
/****** Object:  Table [dbo].[Joyas]    Script Date: 18/6/2021 19:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Joyas](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipo] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Joyas] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos]    Script Date: 18/6/2021 19:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos](
	[idTipo] [int] NOT NULL,
	[nombreTipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Joyas] ([codigo], [nombre], [tipo], [precio]) VALUES (1, N'Cruz del equilibrio', 2, 5000)
INSERT [dbo].[Joyas] ([codigo], [nombre], [tipo], [precio]) VALUES (2, N'Arbol de la vida', 3, 3000)
INSERT [dbo].[Joyas] ([codigo], [nombre], [tipo], [precio]) VALUES (3, N'Rolo', 6, 7000)
GO
INSERT [dbo].[Tipos] ([idTipo], [nombreTipo]) VALUES (1, N'Aro')
INSERT [dbo].[Tipos] ([idTipo], [nombreTipo]) VALUES (2, N'Medalla')
INSERT [dbo].[Tipos] ([idTipo], [nombreTipo]) VALUES (3, N'Dije')
INSERT [dbo].[Tipos] ([idTipo], [nombreTipo]) VALUES (4, N'Anillo')
INSERT [dbo].[Tipos] ([idTipo], [nombreTipo]) VALUES (5, N'Cadena')
INSERT [dbo].[Tipos] ([idTipo], [nombreTipo]) VALUES (6, N'Pulsera')
GO

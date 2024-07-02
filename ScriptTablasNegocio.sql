SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NEGTipoDocumento](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[nombre] [varchar](255) NOT NULL,
	[orden] [int] NOT NULL,
	[activo] [bit] NOT NULL
	)

CREATE TABLE [dbo].[NEGOficina](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[nombre] [varchar](255) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[activo] [bit] NOT NULL
	)

CREATE TABLE [dbo].[NEGEmpleado](
	[id] [int] IDENTITY(1,1) PRIMARY KEY,
	[nombre] [varchar](255) NOT NULL,
	[apellido] [varchar](255) NOT NULL,
	[idtipodocumento] int,
	[numerodocumento] decimal,
	[tipoempleado] [varchar](50) NOT NULL,
	[idoficina] int,
	[activo] [bit] NOT NULL
	)
USE [master]
GO
/****** Object:  Database [APIStore]    Script Date: 29-07-2020 17:50:49 ******/
CREATE DATABASE [APIStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APIStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\APIStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'APIStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\APIStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [APIStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APIStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APIStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [APIStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [APIStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [APIStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [APIStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [APIStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [APIStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [APIStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [APIStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [APIStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [APIStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [APIStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [APIStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [APIStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [APIStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [APIStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [APIStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [APIStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [APIStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [APIStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [APIStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [APIStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [APIStore] SET RECOVERY FULL 
GO
ALTER DATABASE [APIStore] SET  MULTI_USER 
GO
ALTER DATABASE [APIStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [APIStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [APIStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [APIStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [APIStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'APIStore', N'ON'
GO
ALTER DATABASE [APIStore] SET QUERY_STORE = OFF
GO
USE [APIStore]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[id_region] [int] NOT NULL,
	[nombre_ciudad] [varchar](50) NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Despachos_Electronico]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Despachos_Electronico](
	[id_despacho] [int] IDENTITY(1,1) NOT NULL,
	[estado] [bit] NOT NULL,
	[id_factura] [int] NOT NULL,
	[fecha_despacho] [datetime] NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Despachos_Electronico] PRIMARY KEY CLUSTERED 
(
	[id_despacho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Ventas]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Ventas](
	[id_detalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NOT NULL,
	[id_venta] [int] NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Detalle_Ventas] PRIMARY KEY CLUSTERED 
(
	[id_detalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[id_direccion] [int] IDENTITY(1,1) NOT NULL,
	[id_ciudad] [int] NOT NULL,
	[calle] [varchar](100) NOT NULL,
	[numero] [int] NOT NULL,
	[detalle_direccion] [varchar](100) NULL,
	[suspencion] [bit] NULL,
	[fecha_sspencion] [datetime] NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[id_direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_venta] [int] NOT NULL,
	[fecha_facturacion] [date] NOT NULL,
	[id_direccion] [int] NOT NULL,
	[iva_actual] [int] NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imagenes]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imagenes](
	[id_imagen] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NOT NULL,
	[url] [varchar](5000) NOT NULL,
 CONSTRAINT [PK_Imagenes] PRIMARY KEY CLUSTERED 
(
	[id_imagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lenguaje_Backend]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lenguaje_Backend](
	[id_lenguaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[description] [varchar](40) NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Lenguaje_Backend] PRIMARY KEY CLUSTERED 
(
	[id_lenguaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[id_pais] [int] IDENTITY(1,1) NOT NULL,
	[nombre_pais] [varchar](50) NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](40) NOT NULL,
	[id_lenguaje] [int] NOT NULL,
	[id_licencia] [int] NOT NULL,
	[stock] [int] NOT NULL,
	[fecha_creacion] [date] NOT NULL,
	[precio] [int] NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regiones]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regiones](
	[id_region] [int] IDENTITY(1,1) NOT NULL,
	[nombre_region] [varchar](50) NOT NULL,
	[id_pais] [int] NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Regiones] PRIMARY KEY CLUSTERED 
(
	[id_region] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Licencias]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Licencias](
	[id_licencia] [int] IDENTITY(1,1) NOT NULL,
	[nombre_licencia] [varchar](50) NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
 CONSTRAINT [PK_Tipo_Licencias] PRIMARY KEY CLUSTERED 
(
	[id_licencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](80) NOT NULL,
	[apellido_usuario] [varchar](80) NOT NULL,
	[rut_usuario] [varchar](10) NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_susencion] [datetime] NULL,
	[correo] [varchar](100) NULL,
	[password] [varchar](100) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 29-07-2020 17:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha_venta] [date] NOT NULL,
	[suspencion] [bit] NULL,
	[fecha_suspencion] [datetime] NULL,
	[monto_total] [int] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ciudades]  WITH CHECK ADD  CONSTRAINT [FK_Ciudades_Regiones] FOREIGN KEY([id_region])
REFERENCES [dbo].[Regiones] ([id_region])
GO
ALTER TABLE [dbo].[Ciudades] CHECK CONSTRAINT [FK_Ciudades_Regiones]
GO
ALTER TABLE [dbo].[Despachos_Electronico]  WITH CHECK ADD  CONSTRAINT [FK_Despachos_Electronico_Factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[Factura] ([id_factura])
GO
ALTER TABLE [dbo].[Despachos_Electronico] CHECK CONSTRAINT [FK_Despachos_Electronico_Factura]
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ventas_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Detalle_Ventas] CHECK CONSTRAINT [FK_Detalle_Ventas_Productos]
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ventas_Ventas] FOREIGN KEY([id_venta])
REFERENCES [dbo].[Ventas] ([id_venta])
GO
ALTER TABLE [dbo].[Detalle_Ventas] CHECK CONSTRAINT [FK_Detalle_Ventas_Ventas]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Ciudades] FOREIGN KEY([id_ciudad])
REFERENCES [dbo].[Ciudades] ([id_ciudad])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Ciudades]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Direccion] FOREIGN KEY([id_direccion])
REFERENCES [dbo].[Direccion] ([id_direccion])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Direccion]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Ventas] FOREIGN KEY([id_venta])
REFERENCES [dbo].[Ventas] ([id_venta])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Ventas]
GO
ALTER TABLE [dbo].[Imagenes]  WITH CHECK ADD  CONSTRAINT [FK_Imagenes_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Imagenes] CHECK CONSTRAINT [FK_Imagenes_Productos]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Lenguaje_Backend] FOREIGN KEY([id_lenguaje])
REFERENCES [dbo].[Lenguaje_Backend] ([id_lenguaje])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Lenguaje_Backend]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Tipo_Licencias] FOREIGN KEY([id_licencia])
REFERENCES [dbo].[Tipo_Licencias] ([id_licencia])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Tipo_Licencias]
GO
ALTER TABLE [dbo].[Regiones]  WITH CHECK ADD  CONSTRAINT [FK_Regiones_Paises] FOREIGN KEY([id_pais])
REFERENCES [dbo].[Paises] ([id_pais])
GO
ALTER TABLE [dbo].[Regiones] CHECK CONSTRAINT [FK_Regiones_Paises]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [APIStore] SET  READ_WRITE 
GO

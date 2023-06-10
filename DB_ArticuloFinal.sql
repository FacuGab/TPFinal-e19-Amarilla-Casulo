use master
go
create database CATALOGO_DB
go
use CATALOGO_DB
go
USE [CATALOGO_DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MARCAS](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Descripcion] [varchar](50) NULL,
		CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED ([Id] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [CATALOGO_DB]
GO

/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 08/09/2019 10:32:14 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [CATALOGO_DB]
GO

/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 08/09/2019 10:32:24 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] [money] NULL,
	Estado [bit]NOT NULL,
	Stock [int]NOT NULL
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE IMAGENES(
	Id[int] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_IMAGENES] PRIMARY KEY,
	IdArticulo[int] NULL,
	IdMarca[int]NULL,
	IdCategoria[int]NULL,
	UrlImagen[varchar](1000)NOT NULL
)

GO
CREATE TABLE USUARIO(
	Id[int] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_USUARIO] PRIMARY KEY,
	Nombre[varchar](30)NOT NULL,
	Apellido[varchar](30) NOT NULL,
	Dni[int] NOT NULL,
	Mail[varchar](50) NOT NULL,
	Clave[varchar](30) NOT NULL,
	Direccion[varchar](100) NOT NULL,
	Nivel[varchar](1)NOT NULL,
	UrlImagen[varchar](1000) NULL
)
GO

CREATE TABLE PEDIDOS(
	IdPedido[int] IDENTITY(1,1) NOT NULL CONSTRAINT [PK_PEDIDOS] PRIMARY KEY,
	idUsuario[int]NOT NULL,
	IdArticulo[int] NOT NULL,
	Fecha[Date] NOT NULL,
	Estado[varchar](1) NOT NULL,
	DireccionEntrega[varchar](100) NOT NULL,
	Descuento[int] NULL
)

SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[PEDIDO_ARTICULO](
    [IdPedido] [int] NOT NULL,
    [IdArticulo] [int] NOT NULL,
    [Cantidad] [int] NOT NULL,
    CONSTRAINT [PK_PEDIDO_ARTICULO] PRIMARY KEY CLUSTERED ([IdPedido] ASC, [IdArticulo] ASC),
    CONSTRAINT [FK_PEDIDO_ARTICULO_PEDIDOS] FOREIGN KEY([IdPedido])
    REFERENCES [dbo].[PEDIDOS] ([Id]),
    CONSTRAINT [FK_PEDIDO_ARTICULO_ARTICULOS] FOREIGN KEY([IdArticulo])
    REFERENCES [dbo].[ARTICULOS] ([Id])
)
GO

insert into MARCAS values ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Celulares'),('Televisores'), ('Media'), ('Audio')
insert into ARTICULOS values ('S01', 'Galaxy S10', 'Una canoa cara', 1, 1, 'https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542', 69.999),
('M03', 'Moto G Play 7ma Gen', 'Ya siete de estos?', 1, 5, 'https://www.motorola.cl/arquivos/moto-g7-play-img-product.png?v=636862863804700000', 15699),
('S99', 'Play 4', 'Ya no se cuantas versiones hay', 3, 3, 'https://www.euronics.cz/image/product/800x800/532620.jpg', 35000),
('S56', 'Bravia 55', 'Alta tele', 3, 2, 'https://intercompras.com/product_thumb_keepratio_2.php?img=images/product/SONY_KDL-55W950A.jpg&w=650&h=450', 49500),
('A23', 'Apple TV', 'lindo loro', 2, 3, 'https://cnnespanol2.files.wordpress.com/2015/12/gadgets-mc3a1s-populares-apple-tv-2015-18.jpg?quality=100&strip=info&w=460&h=260&crop=1', 7850)

-- Querys post creacion de BD:

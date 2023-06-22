use master
go
create database CATALOGO_E19
go
use CATALOGO_E19
go
USE [CATALOGO_E19]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE MARCAS (
	Id INT not null PRIMARY KEY,
	Descripcion varchar(50) not null,
	UrlImagen VARCHAR(1000)NOT NULL
)

GO

CREATE TABLE CATEGORIAS (
	Id INT not null PRIMARY KEY,
	Descripcion varchar(50) not null,
	UrlImagen VARCHAR(1000)NOT NULL
)

GO

CREATE TABLE ARTICULOS(
	Id INT PRIMARY KEY NOT NULL,
	Nombre VARCHAR(50) NULL,
	Descripcion VARCHAR(150) NULL,
	IdMarca INT NULL,
	IdCategoria INT NULL,
	ImagenUrl VARCHAR(1000) NULL,
	Precio DECIMAL NULL,
	Estado BIT NOT NULL,
	Stock INT NOT NULL
)

GO

CREATE TABLE IMAGENES(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdArticulo INT NULL,
	UrlImagen VARCHAR(1000)NOT NULL,
)

GO

CREATE TABLE PEDIDOS(
	IdPedido INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdUsuarios INT NOT NULL,
	IdArticulos INT NOT NULL,
	Cantidad INT NOT NULL,
	Fecha DATE NOT NULL,
	Estado VARCHAR(20) NOT NULL,
	DireccionEntrega VARCHAR(100) NOT NULL,
	Descuento DECIMAL NULL,
	PrecioTotal DECIMAL NOT NULL
)
INSERT INTO PEDIDOS VALUES(3, 15,10, '2023-06-02', 'OK', 'luis 123', 0, 30000);

GO

CREATE TABLE USUARIOS(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(30) NOT NULL,
	Apellido VARCHAR(30) NOT NULL,
	DNI INT NOT NULL,
	Mail VARCHAR(30) NOT NULL,
	Clave VARCHAR(30) NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	Nivel CHAR NOT NULL, -- 0 admin 1 empleado 2 cliente �?
	UrlImagen VARCHAR (MAX) NOT NULL
)

GO

CREATE TABLE PEDIDO_ARTICULO(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdPedido INT NOT NULL FOREIGN KEY REFERENCES PEDIDOS (IdPedido),
	IdArticulo INT NOT NULL FOREIGN KEY REFERENCES ARTICULOS (Id),
	Cantidad INT NOT NULL
)

--POST IMPLEMENTACION
SELECT Id,Descripcion, UrlImagen FROM Categorias
select * from CATEGORIAS
SELECT Id,Nombre,Descripcion,IdMarca,IdCategoria,Precio,Estado,Stock,ImagenUrl FROM ARTICULOS WHERE Id = 1

--consulta listar pedido
SELECT P.IdPedido as 'ID_Pedido',U.Id as 'ID_usuario',A.Id as 'ID_Articulo', U.Nombre + ' '+ U.Apellido as 'Usuario', A.Nombre as 'Nombre_Articulo', P.Cantidad as 'Cantidad_Solicitada', P.Fecha as 'Fecha', P.Estado as 'Estado', P.DireccionEntrega as 'Dirección', P.Descuento as 'Descuento', P.PrecioTotal as 'Precio_Total_Unidad'
FROM PEDIDOS P
JOIN USUARIOS U ON P.IdUsuarios = U.Id
JOIN ARTICULOS A ON P.IdArticulos = A.Id

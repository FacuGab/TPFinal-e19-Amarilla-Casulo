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

GO

create TABLE USUARIOS(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(30) NOT NULL,
	Apellido VARCHAR(30) NOT NULL,
	DNI INT NOT NULL,
	Mail VARCHAR(30) NOT NULL,
	Clave VARCHAR(30) NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	Nivel CHAR NOT NULL, -- 0 admin 1 empleado 2 cliente �?
	UrlImagen VARCHAR (MAX) NOT NULL,
	Activo BIT NOT NULL DEFAULT 1
)
select * from USUARIOS
GO
CREATE TABLE PEDIDO_ARTICULO(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdPedido INT NOT NULL FOREIGN KEY REFERENCES PEDIDOS (IdPedido),
	IdArticulo INT NOT NULL FOREIGN KEY REFERENCES ARTICULOS (Id),
	Cantidad INT NOT NULL
)
-- Stored Procedure
GO
CREATE PROCEDURE sp_CrearPedido 
@IdUsuario int,
@IdArticulo int,
@Cantidad int,
@Fecha date,
@Estado varchar(20),
@DireccionEntrega varchar(20),
@Descuento decimal,
@PrecioTotal decimal
AS
BEGIN
	INSERT INTO PEDIDOS (IdUsuarios, IdArticulos, Cantidad, Fecha, Estado, DireccionEntrega, Descuento, PrecioTotal)
	OUTPUT inserted.IdPedido
	VALUES (@IdUsuario, @IdArticulo, @Cantidad, @Fecha, @Estado, @DireccionEntrega, @Descuento, @PrecioTotal)
END
GO
-- SP LISTAR ARTICULOS PEDIDOS
CREATE PROCEDURE sp_ListarPedido_Articulos
(@id INT) AS 
BEGIN
SELECT P.IdArticulo, 
	   P.Cantidad, 
	   A.Nombre, 
	   A.Descripcion, 
	   M.Descripcion as 'Marca', 
	   C.Descripcion as 'Categoria', 
	   A.ImagenUrl, 
	   A.Estado, 
	   A.Stock,
	   A.Precio
FROM PEDIDO_ARTICULO P INNER JOIN ARTICULOS A ON P.IdArticulo = A.Id
INNER JOIN MARCAS M on M.Id = A.IdMarca 
INNER JOIN CATEGORIAS C on C.Id = A.IdCategoria
WHERE IdPedido = @id
END

-- SP LISTAR PEDIDOS
CREATE PROCEDURE sp_ListarPedidos
AS BEGIN
SELECT  P.IdPedido as 'ID_Pedido',
		U.Id as 'ID_usuario', 
		U.Nombre+' '+U.Apellido as 'Usuario',
		P.Cantidad as 'Cantidad_Articulos', 
		P.Fecha as 'Fecha',
		P.Estado as 'Estado', 
		P.DireccionEntrega as 'Direccion', 
		P.Descuento as 'Descuento', 
		P.PrecioTotal as 'Precio_Total_Articulo'
FROM PEDIDOS P INNER JOIN USUARIOS U ON P.IdUsuarios = U.Id
END
--
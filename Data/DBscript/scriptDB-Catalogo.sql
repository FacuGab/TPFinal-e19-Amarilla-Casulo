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
	Id INT IDENTITY(1,1) not null PRIMARY KEY,
	Descripcion varchar(50) not null
)

GO

CREATE TABLE CATEGORIAS (
	Id INT IDENTITY(1,1) not null PRIMARY KEY,
	Descripcion varchar(50) not null
)

GO

CREATE TABLE ARTICULOS(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Codigo VARCHAR(50) NULL,
	Nombre VARCHAR(50) NULL,
	Descripcion VARCHAR(150) NULL,
	IdMarca INT NULL,
	IdCategoria INT NULL,
	Precio DECIMAL NULL,
	Estado BIT NOT NULL,
	Stock INT NOT NULL
)

GO

CREATE TABLE IMAGENES(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdArticulo INT NULL,
	IdMarca INT NULL,
	IdCategoria INT NULL,
	UrlImagen VARCHAR(1000)NOT NULL,
	Descripcion VARCHAR(MAX) NULL
)

GO

-- Cuidado, vamos a tener que exigir registrar a los usuarios para que la bd funcione, ya que los pedidos exigen un Id de usuario no nulo.
CREATE TABLE USUARIOS(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(30) NOT NULL,
	Apellido VARCHAR(30) NOT NULL,
	DNI INT NOT NULL,
	Mail VARCHAR(30) NOT NULL,
	Clave VARCHAR(30) NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	Nivel CHAR NOT NULL, -- 'a' admin 'e' empleado 'c' cliente? ver si utilizar el nivel empleado o no.
	UrlImagen VARCHAR (MAX) NOT NULL
)

GO

CREATE TABLE PEDIDOS(
	IdPedido INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdUsuarios INT NOT NULL,
	Fecha DATE NOT NULL,
	Estado VARCHAR(1) NOT NULL,
	DireccionEntrega VARCHAR(100) NOT NULL,
	Descuento INT NULL
)

GO

CREATE TABLE ARTICULOS_X_PEDIDO(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdArticulo INT NOT NULL,
	Cantidad INT NOT NULL
	CONSTRAINT FK_PEDIDO FOREIGN KEY REFERENCES PEDIDOS (IdPedido)
)

-- #### CAMBIOS POST CREACION DB #### --

-- Sentencias utilez para modificar tablas:
--DROP TABLE PEDIDO_ARTICULO
--ALTER TABLE IMAGENES ADD  Descripcion VARCHAR(MAX) NULL
--ALTER TABLE nombre_tabla DROP CONSTRAINT nombre_clave_primaria
--ALTER TABLE nombre_tabla ADD CONSTRAINT nombre_clave_primaria PRIMARY KEY (nombre_campo)
--ALTER TABLE nombre_tabla DROP FOREIGN KEY nombre_clave_foranea
--ALTER TABLE nombre_tabla ADD CONSTRAINT nombre_clave_foranea FOREIGN KEY (nombre_campo) REFERENCES otra_tabla (otro_campo)
--ALTER TABLE nombre_tabla DROP INDEX nombre_clave_unica;
--ALTER TABLE nombre_tabla ADD CONSTRAINT nombre_clave_unica UNIQUE (nombre_campo);
--ALTER TABLE nombre_tabla DROP CONSTRAINT nombre_restriccion_check;
--ALTER TABLE nombre_tabla ADD CONSTRAINT nombre_restriccion_check CHECK (nombre_campo > 0);
--ALTER TABLE nombre_tabla DROP CONSTRAINT nombre_restriccion_default;
--ALTER TABLE nombre_tabla ADD CONSTRAINT nombre_restriccion_default DEFAULT GETDATE() FOR nombre_campo;

-- si falla intentar usar normalizado lo de arriba, usemos esta tabla y utilizar aunq no sea eficiente)
/*CREATE TABLE PEDIDOS_FIX( 
	IdPedido INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdUsuarios INT NOT NULL,
	IdArticulos INT NOT NULL,
	Fecha DATE NOT NULL,
	Estado VARCHAR(1) NOT NULL,
	DireccionEntrega VARCHAR(100) NOT NULL,
	Descuento INT NULL
)*/

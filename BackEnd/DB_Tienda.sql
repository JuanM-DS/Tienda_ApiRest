create database Tienda
use Tienda

create table Categorias(
IdCategoria int identity primary key not null,
Nombre varchar(50),
Descripcion varchar(200)
)

create table Productos(
	IdProducto int identity primary key not null,
	Nombre varchar(50),
	Precio money,
	Unidades int,
	IdCategoria int,
	Constraint FK_IdCategoria Foreign Key (IdCategoria) References Categorias(IdCategoria)
)
select * from Productos
/*Procedimientos Almacenados: */
create procedure sp_ListarProductos as select * from Productos
--
create procedure sp_Listarcategorias as select * from Categorias
--
create procedure sp_AggProductos
(@Nombre int, @Precio money, @Unidades int, @IdCategoria int)
as
insert into Productos (Nombre, Precio, Unidades, IdCategoria)
Values(@Nombre, @Precio, @Unidades, @IdCategoria)
--
Create procedure sp_AggCategoria(@Nombre varchar(50), @Descripcion varchar(50))
as
insert into Categorias(Nombre,Descripcion)
values(@Nombre, @Descripcion)
--
create procedure sp_BuscarProducto (@Id int)
as
select * from Productos where IdProducto = @Id
--
create procedure sp_BuscarCategoria (@Id int)
as
select * from Categorias where IdCategoria = @Id
--
CREATE PROCEDURE sp_ActualizarProducto
    @IdProducto int,
    @Nombre varchar(50),
    @Precio money,
    @Unidades int,
    @IdCategoria int
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre,
        Precio = @Precio,
        Unidades = @Unidades,
        IdCategoria = @IdCategoria
    WHERE IdProducto = @IdProducto;
END;
--
CREATE PROCEDURE sp_EliminarProducto
    @IdProducto int
AS
BEGIN
    DELETE FROM Productos
    WHERE IdProducto = @IdProducto;
END;
--
CREATE PROCEDURE sp_ActualizarCategoria
    @IdCategoria int,
    @Nombre varchar(50),
    @Descripcion varchar(200)
AS
BEGIN
    UPDATE Categorias
    SET Nombre = @Nombre,
        Descripcion = @Descripcion
    WHERE IdCategoria = @IdCategoria;
END;
--
CREATE PROCEDURE sp_EliminarCategoria
    @IdCategoria int
AS
BEGIN
    DELETE FROM Categorias
    WHERE IdCategoria = @IdCategoria;
END;

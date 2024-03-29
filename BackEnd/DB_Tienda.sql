create database Tienda
use Tienda


INSERT INTO Categorias(Nombre, Descripcion)
VALUES
('Frutas y Verduras', 'Productos frescos y saludables, como manzanas, pl�tanos, tomates y lechugas.'),
('Carnes y Aves', 'Una amplia selecci�n de carnes de res, pollo, cerdo y pescado, perfectas para cualquier receta.'),
('Productos l�cteos', 'Productos l�cteos frescos, como leche, queso, mantequilla y yogur, para una dieta equilibrada.'),
('Productos de limpieza', 'Art�culos esenciales para mantener tu hogar limpio y ordenado, incluyendo detergentes, desinfectantes y escobas.'),
('Bebidas', 'Una variedad de bebidas refrescantes y energizantes, desde agua embotellada hasta refrescos y jugos naturales.');





select * from Categorias


/*DDL*/
create table Categorias(
IdCategoria int identity primary key not null,
Nombre varchar(50),
Descripcion varchar(200)
)
drop table Productos
create table Productos(
	IdProducto int identity primary key not null,
	Nombre varchar(50),
	Precio decimal(6,2),
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
(@Nombre varchar(50), @Precio decimal(6,2), @Unidades int, @IdCategoria int)
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

exec sp_BuscarProducto 2
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

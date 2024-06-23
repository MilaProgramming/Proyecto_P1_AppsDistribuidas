create database ProyectoDB;

use ProyectoDB;

create table Autor(
	aut_id int NOT NULL IDENTITY(1,1)PRIMARY KEY,
	aut_nombre varchar(100)
);

create table Editorial(
	edi_id int NOT NULL identity(1,1)PRIMARY KEY,
	edi_nombre varchar(100)
);

create table Categoria(
	cat_id int NOT NULL identity(1,1)PRIMARY KEY,
	cat_nombre varchar(100)
);

create table Libro(
	lib_id int NOT NULL identity(1,1)PRIMARY KEY,
	lib_nombre varchar(100),
	lib_disponible bit,
	cat_id int foreign key references Categoria(cat_id),
	edi_id int foreign key references Editorial(edi_id),
	aut_id int foreign key references Autor(aut_id)
);

create table Usuario(
	usu_cedula int NOT NULL PRIMARY KEY,
	usu_nombre varchar(50),
	usu_apellido varchar(50),
	usu_usuario varchar(50),
	usu_contrasenia varchar(50)
);

create table Prestamo_Libro(
	pre_id int NOT NULL identity(1,1)PRIMARY KEY,
	pre_fecha_inicio date,
	pre_fecha_final date,
	lib_id int foreign key references Libro(lib_id),
	usu_cedula int foreign key references Usuario(usu_cedula)
);
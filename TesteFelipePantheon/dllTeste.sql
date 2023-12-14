create database DesafioFelipe


-- create table associados
create table Associados(
  Id			 integer unique identity not null,
  Nome			 varchar(200) not null,
  Cpf			 varchar(11) not null unique,
  DataNascimento datetime not null,
  primary key(id)
)
go


-- create table empresas
create table Empresas(
 Id			integer unique identity not null,
 Nome		varchar(200)			not null,
 Cnpj		varchar(14)				not null unique,
 primary key(id)
)
go

-- create muitos para muitos
create table Associados_Emp(
	Id			 integer unique identity not null,
	Id_associado integer				 not null,
	Id_empresa   integer				 not null
	primary key(id, Id_associado, Id_empresa),
	foreign key (Id_associado) references Associados(id),
	foreign key (Id_empresa) references Empresas(id),

)
go
-- create SPA excluir associados
CREATE Procedure SpaExcluirAssociados 
(
@Id int
)
AS
BEGIN
	Delete from Associados_Emp where Id_associado = @Id
END
BEGIN
	Delete from Associados where Id = @Id
END

go

-- create spa excluir empresas
CREATE Procedure SpaExcluirEmpresa 
(
@Id int
)
AS
BEGIN
	Delete from Associados_Emp where Id_Empresa = @Id
END
BEGIN
	Delete from Empresas where Id = @Id
END

go




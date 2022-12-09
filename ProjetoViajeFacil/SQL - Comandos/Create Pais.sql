Create table pais(
id_pais Bigint identity(1,1) not null,
nome varchar(100) not null,
constraint PK_Pais primary key (id_pais)
)
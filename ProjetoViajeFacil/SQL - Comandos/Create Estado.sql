Create Table estado(
id_estado bigint identity(1,1) not null,
nome varchar(100) not null,
uf varchar(2) not null,
id_regiao bigint not null,
codigouf bigint null,	
constraint PK_Estado primary key (id_estado),
constraint FK_Estado_Regiao Foreign key (id_regiao) references regiao(id_regiao)
)


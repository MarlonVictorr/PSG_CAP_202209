Create Table cidade(
id_cidade bigint identity(1,1) not null,
nome varchar(100) not null,
codigo_ibge7 bigint not null,
uf varchar(2) not null,
id_estado bigint not null,
constraint PK_Cidade primary key (id_cidade),
constraint FK_Cidade_Estado foreign key (id_estado) references estado(id_estado)
)
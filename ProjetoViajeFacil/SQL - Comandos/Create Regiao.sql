Create table regiao(
id_regiao bigint identity(1,1) not null,
nome varchar(100) not null,
id_pais bigint not null,
Constraint PK_Regiao primary key (id_regiao),
Constraint FK_Regiao_Pais Foreign key (id_pais) references pais(id_pais)
)
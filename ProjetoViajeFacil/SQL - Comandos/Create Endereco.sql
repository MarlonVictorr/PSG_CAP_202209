Create Table endereco(
id_endereco bigint identity(1,1) not null,
rua varchar(100) not null,
numero int not null,
complemento varchar(255) null,
bairro varchar(100) not null,
cep varchar(9) not null,
id_cidade bigint not null,
Constraint PK_Endereco primary key (id_endereco),
Constraint FK_Endereco_Cidade foreign key (id_cidade) references cidade(id_cidade)
)
Create Table instituicao(
id_instituicao bigint identity(1,1) not null,
nome varchar(100) not null,
telefone varchar(20) not null,
id_endereco bigint not null,
Constraint PK_Instituicao primary key (id_instituicao),
Constraint FK_Instituicao_Endereco foreign key (id_endereco) references endereco(id_endereco)
)


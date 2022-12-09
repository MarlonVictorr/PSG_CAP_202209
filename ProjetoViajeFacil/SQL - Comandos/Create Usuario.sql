Create Table usuario(
id_usuario bigint identity(1,1) not null,
nome varchar(100) not null,
email varchar(50) not null,
cpf varchar(50) not null,
telefone varchar(20) not null,
[login] varchar(50) not null,
senha varchar(255) not null,
id_endereco bigint not null,
id_tipo_usuario bigint not null,
id_instituicao bigint not null,
constraint PK_Usuario primary key (id_usuario),
constraint FK_Usuario_Endereco foreign key (id_endereco) references endereco(id_endereco),
constraint FK_Usuario_Tipo_Usuario foreign key (id_tipo_usuario) references tipo_usuario(id_tipo_usuario),
constraint FK_Usuario_Instituicao foreign key (id_instituicao) references instituicao(id_instituicao)

)
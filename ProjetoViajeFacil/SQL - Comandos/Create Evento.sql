Create table evento(
id_evento bigint identity(1,1) not null,
titulo varchar(255) not null,
descricao varchar(255) not null,
data_ida date not null,
data_volta date not null,
id_instituicao bigint not null,
id_endereco bigint not null,
id_rota_ida bigint not null,
id_rota_volta bigint not null,
id_usuario_responsavel bigint not null,
constraint PK_Evento primary key (id_evento),
constraint FK_Evento_Instituicao foreign key (id_instituicao) references instituicao(id_instituicao),
constraint FK_Evento_Endereco foreign key (id_endereco) references endereco(id_endereco),
constraint FK_Evento_rota_ida foreign key (id_rota_ida) references rota(id_rota),
constraint FK_Evento_rota_volta foreign key (id_rota_volta) references rota(id_rota),
constraint FK_Evento_Usuario foreign key (id_usuario_responsavel) references usuario(id_usuario)

)
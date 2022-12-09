Create table participante_evento(
id_participante bigint identity(1,1) not null,
pagamento int not null,
sugestao varchar(255) not null,
avaliacao int null,
id_evento bigint not null,
id_usuario bigint not null,
constraint PK_Participante_Evento primary key (id_participante),
constraint FK_Participante_Evento_Evento foreign key(id_evento) references evento(id_evento),
constraint FK_Participante_Evento_Usuario foreign key(id_usuario) references usuario(id_usuario)

)
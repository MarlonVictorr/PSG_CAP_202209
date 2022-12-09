Create Table ponto_parada(
id_ponto_parada bigint identity(1,1) not null,
descricao varchar(255) not null,
latitude varchar(50) not null,
longitude varchar(50) not null,
id_rota bigint not null,
Constraint PK_Ponto_Parada primary key(id_ponto_parada),
Constraint FK_Ponto_Parada_Rota foreign key (id_rota) references rota(id_rota)
)
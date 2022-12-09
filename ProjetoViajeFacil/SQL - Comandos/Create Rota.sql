Create table rota(
id_rota bigint identity(1,1) not null,
ponto_inicial varchar(255) not null,
ponto_final varchar(255) not null,
Constraint PK_Rota primary key (id_rota)
)
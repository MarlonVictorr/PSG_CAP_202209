Create Table tipo_usuario (
id_tipo_usuario bigint identity(1,1) not null,
descricao varchar(50) not null,
Constraint PK_Tipo_Usuario primary key (id_tipo_usuario)
)
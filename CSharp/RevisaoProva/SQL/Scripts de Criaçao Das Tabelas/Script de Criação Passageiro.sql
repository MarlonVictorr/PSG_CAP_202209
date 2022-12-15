Create table Passageiro(
	CodigoPassageiro int identity(1,1) not null,
	Nome varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Telefone varchar(50) NOT NULL,
	Usuario varchar(50) NOT NULL,
	Senha varchar(50) NOT NULL,
	DataNascimento datetime NOT NULL,
	Documento varchar(50) not null,
	NumeroCartao varchar(50) not null,
	Constraint PK_Passageiro primary key (CodigoPassageiro)	
)




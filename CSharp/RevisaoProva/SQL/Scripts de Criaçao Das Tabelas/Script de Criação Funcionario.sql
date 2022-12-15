Create table Funcionario(
	CodigoFuncionario int identity(1,1) not null,
	Nome varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Telefone varchar(50) NOT NULL,
	Usuario varchar(50) NOT NULL,
	Senha varchar(50) NOT NULL,
	DataNascimento datetime NOT NULL,
	Matricula varchar(100) not null,
	ContaCorrente varchar(50) not null,
	Constraint PK_Funcionario primary key (CodigoFuncionario)
)



CREATE TABLE Cliente(
	Codigo INT NOT NULL IDENTITY(1,1),
	Nome VARCHAR(MAX) NOT NULL,
	RazaoSocial VARCHAR(MAX) NULL,
	NomeFantasia VARCHAR(MAX)NULL,
	Documento VARCHAR(14) NOT NULL,
	Telefone VARCHAR(11) NOT NULL,
	Email VARCHAR(MAX) NOT NULL,
	TipoPessoa CHAR(1) NOT NULL DEFAULT 'F',
	Endereco VARCHAR(MAX) NULL,
	Ativo BIT NOT NULL DEFAULT 1,
	DataInclusao DATETIME NOT NULL DEFAULT GETDATE(),
	DataAlteracao DATETIME NULL,
	DataExclusao DATETIME NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY(Codigo)
	)


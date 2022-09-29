--Desafio14

CREATE PROCEDURE SP_Desafio014
AS
BEGIN
	DECLARE @NOMES TABLE(
	NOME VARCHAR(MAX) NOT NULL
	)

	INSERT INTO @NOMES VALUES 
	('Luiz'),
	('Thiago'),
	('Bruno'),
	('Rafael'),
	('Marlon'),
	('Renato'),
	('Jéssica'),
	('Ronie'),
	('Gérson')

	SELECT * FROM @NOMES
END
GO

EXEC dbo.SP_Desafio014 
GO

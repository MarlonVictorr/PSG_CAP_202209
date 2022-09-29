--Desafio 020 
DECLARE @Nome VARCHAR(MAX)
SET @Nome = 'Marlon Victor'
BEGIN
	PRINT 'Olá meu nome é: ' + TRIM(@Nome)
	PRINT 'NOME MAIÚSCULO: ' + TRIM(UPPER(@Nome))
	PRINT 'nome minúsculo: ' + TRIM(LOWER(@Nome))
	PRINT 'Quantidade De Letras do Nome: ' + CONVERT(VARCHAR,(LEN(REPLACE(@Nome,' ',''))))
	PRINT 'Quantidade De Letras do Primeiro Nome: ' + CONVERT(VARCHAR, (LEN(SUBSTRING(@Nome, 1, CHARINDEX(' ', @Nome)))))
END
GO

CREATE PROCEDURE SP_Desafio020
@Nome VARCHAR(MAX)
AS
BEGIN
	PRINT 'Olá meu nome é: ' + TRIM(@Nome)
	PRINT 'NOME MAIÚSCULO: ' + TRIM(UPPER(@Nome))
	PRINT 'nome minúsculo: ' + TRIM(LOWER(@Nome))
	PRINT 'Quantidade De Letras do Nome: ' + CONVERT(VARCHAR,(LEN(REPLACE(@Nome,' ',''))))
	PRINT 'Quantidade De Letras do Primeiro Nome: ' + CONVERT(VARCHAR, (LEN(SUBSTRING(@Nome, 1, CHARINDEX(' ', @Nome)))))
END
GO

EXEC SP_Desafio020 'Marlon Victor'
GO

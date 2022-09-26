--Desafio 011

Declare @Salario Numeric(10,2)
SET @Salario = 1200
BEGIN
	Declare @NovoSalario Numeric (10,2)
	SET  @NovoSalario = @Salario *0.15
	BEGIN
	PRINT 'Seu Novo Salario é:' + ' ' + convert(Varchar(max), (@Salario + @NovoSalario))
	END

END

Create Procedure SP_Desafio011
@Salario Numeric(10,2)
AS
BEGIN
	Declare @NovoSalario Numeric (10,2)
	SET  @NovoSalario = @Salario *0.15
	BEGIN
	PRINT 'Seu Novo Salario é:' + ' ' + convert(Varchar(max), (@Salario + @NovoSalario))
	END
END 

EXEC  dbo.SP_Desafio011 1200





--CREATE PROCEDURE SP_Desafio_014
--AS
--BEGIN
--	DECLARE @NOMES TABLE(
--	NOME VARCHAR(MAX) NOT NULL
--	)

--	INSERT INTO @NOMES VALUES 
--	('Luiz'),
--	('Thiago'),
--	('Bruno'),
--	('Rafael'),
--	('Marlon'),
--	('Renato'),
--	('Jéssica'),
--	('Ronie'),
--	('Gérson')

--	SELECT * FROM @NOMES
--END
--GO



--EXEC dbo.SP_Desafio_014
--GO

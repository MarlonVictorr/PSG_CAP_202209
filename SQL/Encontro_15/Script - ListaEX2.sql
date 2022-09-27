use CAP_PSG_202209

--Desafio 011
--Declare @Salario Numeric(10,2)
--SET @Salario = 1200
--BEGIN
--	Declare @NovoSalario Numeric (10,2)
--	SET  @NovoSalario = @Salario *0.15
--	BEGIN
--	PRINT 'Seu Novo Salario é:' + ' ' + convert(Varchar(max), (@Salario + @NovoSalario))
--	END

--END

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

EXEC  dbo.SP_Desafio011 2400

--Desafio12
--Declare @TemperaturaCelsius FLOAT
--set @TemperaturaCelsius = 20
--Begin 
--	PRINT 'Sua Temperatura em Fahrenheit é:' + ' ' + convert(Varchar(max), (@TemperaturaCelsius *9 /5 + 32))
--End 

Create Procedure SP_Desafio012
@TemperaturaCelsius float
AS
Begin 
	PRINT 'Sua Temperatura em Fahrenheit é:' + ' ' + convert(Varchar(max), (@TemperaturaCelsius *9 /5 + 32))
END

exec dbo.SP_Desafio012 15

--Desafio13 
--DECLARE @Km NUMERIC(10, 2) 
--SET @Km = 10
--DECLARE @Dias NUMERIC(10, 2)
--SET @Dias = 30
--DECLARE @ValorAluguel NUMERIC(10, 2)
--SET @ValorAluguel= (@Km * 0.15 + @Dias * 60)

--PRINT 'Preço final Do Aluguel' + ' ' +  convert(Varchar(max),(@ValorAluguel))
--GO

Create Procedure SP_Desafio13
@Km NUMERIC(10, 2),
@Dias NUMERIC(10, 2)
AS
BEGIN 
	DECLARE @ValorAluguel NUMERIC(10, 2)
	SET @ValorAluguel= (@Km * 0.15 + @Dias * 60)
	BEGIN
	PRINT 'Preço final Do Aluguel' + ' ' +  convert(Varchar(max),(@ValorAluguel))
	END
END

exec SP_Desafio13 30,60

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

--Desafio15
--DECLARE @Nomes TABLE(
--    Nome VARCHAR(MAX) NOT NULL
--)

--INSERT INTO @Nomes VALUES
--    ('Gustavo'),
--    ('Bruno'),
--    ('Riedo'),
--    ('Ricardo'),
--    ('Luiz'),
--    ('Otavio'),
--    ('Elias'),
--    ('Lucas'),
--    ('Bernardo'),
--    ('Arthur'),
--    ('Breno')

--SELECT * FROM @Nomes ORDER BY Nome
--GO

CREATE PROCEDURE SP_Desafio015
AS
BEGIN
    DECLARE @Nomes TABLE(
    Nome VARCHAR(MAX) NOT NULL
)

    INSERT INTO @Nomes VALUES 
     ('Gustavo'),
    ('Bruno'),
    ('Riedo'),
    ('Ricardo'),
    ('Luiz'),
    ('Otavio'),
    ('Elias'),
    ('Lucas'),
    ('Bernardo'),
    ('Arthur'),
    ('Breno')

    SELECT * FROM @Nomes
    ORDER BY Nome
END
GO

EXEC dbo.SP_Desafio015 
GO

--Desafio16


--DECLARE @Nomes Table(
--Codigo INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--Nome VARCHAR(MAX) NOT NULL
--)

   
--INSERT INTO @Nomes VALUES
--    ('Gustavo'),
--    ('Bruno'),
--    ('Riedo'),
--    ('Ricardo'),
--    ('Luiz'),
--    ('Otavio'),
--    ('Elias'),
--    ('Lucas'),
--    ('Bernardo'),
--    ('Arthur'),
--    ('Breno')

--	Begin
--		Declare @Sorteio INT	
--		Select  @Sorteio = COUNT(*) FROM @Nomes
--		Declare @Codigo int 
--		set @Codigo = FLOOR(RAND()*(@Sorteio+1))
--		while @Codigo = 0
--		BEGIN
--			SET @Codigo = FLOOR(RAND() * (@Sorteio + 1))
--		END
--			SELECT Nome FROM @Nomes WHERE Codigo = @Codigo
--	END


Create Procedure SP_Desafio16
AS
BEGIN
DECLARE @Nomes Table(
Codigo INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
Nome VARCHAR(MAX) NOT NULL
)
INSERT INTO @Nomes VALUES
    ('Gustavo'),
    ('Bruno'),
    ('Riedo'),
    ('Ricardo'),
    ('Luiz'),
    ('Otavio'),
    ('Elias'),
    ('Lucas'),
    ('Bernardo'),
    ('Arthur'),
    ('Breno')

	Begin
		Declare @Sorteio INT	
		Select  @Sorteio = COUNT(*) FROM @Nomes
		Declare @Codigo int 
		set @Codigo = FLOOR(RAND()*(@Sorteio+1))
		while @Codigo = 0
		BEGIN
			SET @Codigo = FLOOR(RAND() * (@Sorteio + 1))
		END
			SELECT Nome FROM @Nomes WHERE Codigo = @Codigo
	END
END

EXEC dbo.SP_Desafio16


--Desafio19
--DECLARE @Numero INT
--SET @Numero = 10
--BEGIN
--    IF 
--    (@Numero % 2 = 0)
--    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é par.')
--    ELSE 
--    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é impar.')
--END
--GO

CREATE PROCEDURE SP_Desafio019
@Numero INT
AS 
BEGIN
    IF 
    (@Numero % 2 = 0)
    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é par.')
    ELSE 
    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é impar.')
END
GO

EXEC SP_Desafio019 10

	




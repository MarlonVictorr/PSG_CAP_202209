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

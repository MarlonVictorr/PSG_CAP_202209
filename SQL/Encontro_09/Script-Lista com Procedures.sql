--Exercicio 1
DECLARE @Nome varchar(max) 
set @Nome = 'Marlon'

print ' Bem Vindo '+ @nome

GO
--CREATE PROCEDURE SP_Exercicio1
--@Nome VARCHAR(MAX)
--AS
--	print ' Bem Vindo '+ @nome
--GO

--EXEC SP_Exercicio1 Marlon

--Exercicio 2 
DECLARE @Dia INT
DECLARE @Mes INT
DECLARE @Ano INT

SET @Dia = '10';
SET @Mes = '5';
SET @Ano = '2002';

PRINT('Data informada: ' +CONVERT(VARCHAR,@Dia) +'-' +CONVERT(VARCHAR,@Mes) +'-' +CONVERT(VARCHAR,@Ano))
GO	

--Create Procedure SP_Exercicio2
--@Dia int, 
--@Mes int,
--@Ano int

--AS
--	PRINT('Data informada: ' +CONVERT(VARCHAR,@Dia) +'-' +CONVERT(VARCHAR,@Mes) +'-' +CONVERT(VARCHAR,@Ano))
--GO	

--EXEC SP_Exercicio2 17,2,2002


--Exercicio 3 
DECLARE @RESULTADO VARCHAR(MAX)
DECLARE @Valor1 INT
DECLARE @Valor2 INT

SET @Valor1 = 5
SET @Valor2 = 12
SET @RESULTADO = 'A SOMA DOS VALORES E'
PRINT 'A SOMA DOS VALORES E' + ' ' + convert(Varchar(MAX), @Valor1 + @Valor2)

GO

--CREATE PROCEDURE SP_Exercicio3
--@Valor1 INT, 
--@Valor2 INT

--AS
--	PRINT 'A SOMA DOS VALORES E' + ' ' + convert(Varchar(MAX), @Valor1 + @Valor2)

--GO

--EXEC SP_Exercicio3 16,20


--Exercicio 4 
DECLARE @VALOR INT

SET @VALOR = 20

PRINT(@VALOR * 2)
PRINT(@VALOR * 3)
PRINT SQRT(@VALOR)
GO

--CREATE PROCEDURE SP_Exercicio4
--@Valor INT
--AS
--	PRINT(@VALOR * 2)
--	PRINT(@VALOR * 3)
--	PRINT SQRT(@VALOR)
--GO

--EXEC SP_Exercicio4 5
	

--Exercicio 5
DECLARE @Nota1 NUMERIC(10,7)
DECLARE @Nota2 NUMERIC(10,7) 
SET @Nota1 = 5.25331
SET @Nota2 = 4.25109
PRINT((@NOTA1 +@NOTA2)/2)

--CREATE PROCEDURE SP_Exercicio5
--@Nota1 FLOAT,
--@Nota2 FLOAT
--AS
--	PRINT((@NOTA1 +@NOTA2)/2)
	
--GO

--EXEC SP_Exercicio5 8,9

--Exercicio 6 
DECLARE @Metro DECIMAL(10,2)
SET @Metro = 3


PRINT 'Metro' + ' ' + CONVERT(VARCHAR(MAX), @Metro) 
PRINT 'Centimetros' + ' ' + CONVERT(VARCHAR(MAX), @Metro * 100)
PRINT 'Milimetros' + ' ' + CONVERT(Varchar(MAX), @Metro *1000)
GO

--Create Procedure SP_Exercicio6
--@Metro DECIMAL(10,2)
--AS
--	PRINT 'Metro' + ' ' + CONVERT(VARCHAR(MAX), @Metro) 
--	PRINT 'Centimetros' + ' ' + CONVERT(VARCHAR(MAX), @Metro * 100)
--	PRINT 'Milimetros' + ' ' + CONVERT(Varchar(MAX), @Metro *1000)

--EXEC SP_Exercicio6 7

--Exercicio 7

--Create Procedure SP_Exercicio7
--@Tabuada int
--AS
--	Print @Tabuada * 1
--	Print @Tabuada * 2
--	Print @Tabuada * 3
--	Print @Tabuada * 4
--	Print @Tabuada * 5
--	Print @Tabuada * 6
--	Print @Tabuada * 7
--	Print @Tabuada * 8
--	Print @Tabuada * 9
--	Print @Tabuada * 10

EXEC SP_Exercicio7 8

--Exercicio 8 
DECLARE @Valor FLOAT
SET @Valor = 20


PRINT 'Você tem tantos dolares' 
PRINT @Valor/5.00

--CREATE PROCEDURE SP_Exercicio8
--@Valor FLOAT
--AS
--Begin
--	PRINT 'Você tem tantos dolares' 
--	PRINT @Valor/5.00

--END

--EXEC SP_Exercicio8 20


--Exercicio 9
DECLARE @Largura FLOAT 
DECLARE @Altura FLOAT
SET @Largura = 5
SET @Altura = 5
PRINT 'Quantidade de Litros de Tinta '+ ' ' + CONVERT(VARCHAR(MAX),@Largura * @Altura / 2) 

--CREATE PROCEDURE SP_Exercicio9
--@Largura FLOAT,
--@Altura FLOAT
--AS
--PRINT 'Quantidade de Litros de Tinta ' + ' ' + CONVERT(VARCHAR(MAX),@Largura * @Altura / 2) 


--EXEC SP_Exercicio9 5,5

--Exercicio 10
DECLARE @Produto INT
DECLARE @Desconto INT
SET @Produto = 57.99
SET @Desconto = 5.00
PRINT @Produto - @Produto * @Desconto / 100 

--CREATE PROCEDURE SP_Exercicio10
--@Produto FLOAT
--AS
--BEGIN
--    DECLARE @Desconto FLOAT
--    SET @Desconto = 5.00 
--    PRINT @Produto - @Produto * @Desconto / 100 
--END

--EXEC SP_Exercicio10 20


--Desafio 22
--DECLARE @Ano Int 
--set @Ano = 1953


--Select *,YEAR(DataNascimento) AS Nascimento from Funcionario where YEAR(DataNascimento) = @Ano  

CREATE PROCEDURE SP_Desafio22
@Ano Int 
AS 

BEGIN 
	Select *,YEAR(DataNascimento) AS Nascimento from Funcionario where YEAR(DataNascimento) = @Ano  
END 

EXEC SP_Desafio22 '1952'

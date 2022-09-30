--Desafio 21

--Declare @Sigla Char(3)
--SET @Sigla = 'Mar' 

--BEGIN
--	Select * from Funcionario where Nome Like @Sigla + '%' ORDER BY Nome,Sobrenome
--END

Create Procedure SP_Desafio21
@Sigla Char(3)
AS

BEGIN
	Select * from Funcionario where Nome Like @Sigla + '%' ORDER BY Nome,Sobrenome
END

EXEC SP_Desafio21 'Mar'

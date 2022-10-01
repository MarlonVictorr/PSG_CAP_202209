-Desafio 25

--Declare @Sigla Char(3)
--SET @Sigla = 'SAN' 

--BEGIN
--	Select * from Funcionario where Sobrenome Like '%' + @Sigla + '%' ORDER BY Nome,Sobrenome
--END

Create Procedure SP_Desafio25
@Sigla Char(3)
AS

BEGIN
	Select * from Funcionario where Sobrenome Like '%'+ @Sigla + '%' ORDER BY Nome,Sobrenome
END

EXEC SP_Desafio25'FAC'

--Desafio 23
--Declare @Sexualidade CHAR(1)
--SET @Sexualidade = 'M' 

--Begin
--	Select *,Sexo from Funcionario where Sexo = @Sexualidade
--End 

Create Procedure SP_Desafio23
@Sexualidade CHAR(1)
AS
BEGIN
	Select * from Funcionario where Sexo = @Sexualidade
END 

EXEC SP_Desafio23 'M'

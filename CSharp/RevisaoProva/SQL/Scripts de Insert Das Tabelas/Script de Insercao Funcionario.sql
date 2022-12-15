insert into ExameCAPDB.DBO.Funcionario(Nome,Email,Telefone,Usuario,Senha,DataNascimento,Matricula,ContaCorrente)
SELECT [NOME]
      ,[EMAIL]
      ,[TELEFONE]
      ,[USUARIO]
      ,[SENHA]
      ,[DATANASCIMENTO]
      ,[MATRICULA]
      ,[CONTACORRENTE]
  FROM [dbo].[RAW_Insert_Funcionario]

GO

insert into ExameCAPDB.DBO.Passageiro (Nome,Email,Telefone,Usuario,Senha,DataNascimento,Documento,NumeroCartao)

SELECT [Nome]
      ,[email]
      ,[telefone]
      ,[usuario]
      ,[senha]
      ,[datanascimento]
      ,[documento]
      ,[numerocartao]
  FROM [dbo].[RAW_Insert_Passageiro]

GO
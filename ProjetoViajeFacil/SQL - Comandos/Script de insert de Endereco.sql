insert into ViajeFacilDB.DBO.endereco (rua,numero,complemento,bairro,cep,id_cidade)
SELECT [nome]
      ,[numero]
      ,[complemento]
      ,[bairro]
      ,[cep]
      ,[id_cidade]
  FROM [dbo].[insertendereco]

GO



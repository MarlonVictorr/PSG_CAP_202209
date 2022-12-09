insert into ViajeFacilDB.DBO.instituicao (nome,telefone,id_endereco)
SELECT  [nome]
      ,[telefone]
      ,[id_endereco]
  FROM [ViajeFacilDB].[dbo].[insert_instituicao]
  GO
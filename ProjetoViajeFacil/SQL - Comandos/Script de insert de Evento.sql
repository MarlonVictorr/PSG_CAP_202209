insert into ViajeFacilDB.DBO.evento (titulo,descricao,data_ida,data_volta,id_instituicao,id_endereco,id_rota_ida,id_rota_volta,id_usuario_responsavel)
SELECT [titulo]
      ,[descricao]
      ,[data_ida]
      ,[data_volta]
      ,[id_instituicao]
      ,[id_endereco]
      ,[id_rota_ida]
      ,[id_rota_volta]
      ,[id_usuario_responsavel]
  FROM [dbo].[RAW_insert_evento]

GO

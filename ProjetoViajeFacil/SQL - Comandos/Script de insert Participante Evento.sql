insert into ViajeFacilDB.DBO.participante_evento (pagamento,sugestao,avaliacao,id_evento,id_usuario)
SELECT [pagamento]
      ,[sugestao]
      ,[avaliacao]
      ,[id_evento]
      ,[id_usuario]
  FROM [dbo].[RAW_insert_participante_evento]

GO



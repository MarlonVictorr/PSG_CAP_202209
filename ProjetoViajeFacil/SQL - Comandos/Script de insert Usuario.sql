Insert Into ViajeFacilDB.DBO.usuario (nome,email,cpf,telefone,[login],senha,id_endereco,id_tipo_usuario,id_instituicao)
SELECT [nome]
      ,[email]
      ,[cpf]
      ,[telefone]
      ,[login]
      ,[senha]
      ,[id_endereco]
      ,[id_tipo_usuario]
      ,[id_instituicao]
  FROM [dbo].[RAW_Insert_Usuario]

GO

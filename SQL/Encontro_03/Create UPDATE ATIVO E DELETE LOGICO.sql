UPDATE Cliente
SET Ativo = 0, DataAlteracao = GETDATE()
WHERE Codigo = 7
GO

INSERT INTO Cliente(Nome,Documento,Telefone,Email,Endereco)
VALUES
('Barrabás','456','987654','barrabas@teste.com','Rua x,n.11')
GO

UPDATE Cliente
SET Ativo = 0, DataAlteracao = GETDATE(), DataExclusao = GETDATE()
WHERE Codigo = 10
GO

UPDATE Cliente
SET Ativo = 1, DataAlteracao = GETDATE(), DataExclusao = NULL 
WHERE Codigo = 10
GO

Create table Departamento(
	DepartamentoId INT NOT NULL IDENTITY(1,1),
	Descricao Varchar(MAX) NOT NULL,
	DataInsert DATETIME NULL DEFAULT GETDATE(),
	CONSTRAINT PK_Depatamento PRIMARY KEY(DepartamentoId)
)
GO

--SET IDENTITY_INSERT  Departamento ON
--GO

--INSERT INTO Departamento (DepartamentoId, Descricao)
--SELECT deptoid,nome FROM RAW_Departamentos

--SET IDENTITY_INSERT  Departamento OFF

--GO

SELECT *FROM Departamento
GO

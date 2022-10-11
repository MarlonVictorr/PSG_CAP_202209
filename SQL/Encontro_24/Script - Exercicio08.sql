
--DECLARE @Id_Municipio INT
--SET @Id_Municipio = 1100015

--DECLARE @Ano INT
--SET @Ano = 2013

--SELECT * FROM VIEW VW_Aquicultura
--WHERE IdMunicipio = @Id_Municipio AND Ano = @Ano AND Producao IS NOT NULL
--GO

CREATE PROCEDURE SP_EX08
@Id_Municipio INT, @Ano INT
AS
BEGIN
	SELECT * FROM VW_Aquicultura
	WHERE IdMunicipio = @Id_Municipio AND Ano = @Ano AND Producao IS NOT NULL
END
GO

EXEC SP_EX08 1100015, 2013
GO


select * from Raw_Aquicultura_Brasil_Municipios

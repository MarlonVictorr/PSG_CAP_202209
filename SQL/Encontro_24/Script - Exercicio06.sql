--DECLARE @Municipio INT
--SET @Municipio = 1100015

--DECLARE @Ano INT
--SET @Ano = 2013

--SELECT * FROM RAW_Aquicultura_Brasil_Municipios
--WHERE Id_Municipio = @Municipio AND Ano = @Ano


CREATE PROCEDURE SP_EX06
@Municipio INT, @Ano INT
AS
BEGIN
	SELECT * FROM RAW_Aquicultura_Brasil_Municipios
	WHERE Id_Municipio = @Municipio AND Ano = @Ano
END
GO

EXEC SP_EX06 1100015, 2013
GO

select * from Raw_Aquicultura_Brasil_Municipios


--DECLARE @Id_Tipo_Aquicultura INT
--SET @Id_Tipo_Aquicultura = 20

--DECLARE @Id_Municipio INT
--SET @Id_Municipio = 1100015

--DECLARE @Ano INT
--SET @Ano = 2013

--SELECT Aquicultura.IdAquicultura, 
--	   Aquicultura.Ano, 
--	   Aquicultura.IdMunicipio, 
--	   tipo.IdTipoAquicultura,
--	   Tipo.DescricaoTipoAquicultura, 
--	   Aquicultura.Producao, 
--	   Aquicultura.ValorProducao, 
--	   Aquicultura.ProporcaoValorProducao,
--	   Aquicultura.Moeda

--FROM Aquicultura 
--INNER JOIN TipoAquicultura AS Tipo ON Aquicultura.IdTipoAquicultura = Tipo.IdTipoAquicultura
--WHERE Tipo.IdTipoAquicultura = @Id_Tipo_Aquicultura AND IdMunicipio = @Id_Municipio AND Aquicultura.Producao IS NOT NULL AND Aquicultura.ValorProducao IS NOT NULL
--GO

CREATE PROCEDURE SP_EX10
@Id_Tipo_Aquicultura INT, @Id_Municipio INT, @Ano INT
AS
BEGIN
	SELECT Aquicultura.IdAquicultura, 
	   Aquicultura.Ano, 
	   Aquicultura.IdMunicipio, 
	   tipo.IdTipoAquicultura,
	   Tipo.DescricaoTipoAquicultura, 
	   Aquicultura.Producao, 
	   Aquicultura.ValorProducao, 
	   Aquicultura.ProporcaoValorProducao,
	   Aquicultura.Moeda

	FROM Aquicultura 
	INNER JOIN TipoAquicultura AS Tipo ON Aquicultura.IdTipoAquicultura = Tipo.IdTipoAquicultura
	WHERE tipo.IdTipoAquicultura = @Id_Tipo_Aquicultura AND IdMunicipio = @Id_Municipio AND Aquicultura.Producao IS NOT NULL AND Aquicultura.ValorProducao IS NOT NULL
END
GO

EXEC SP_EX10 20, 1100015, 2013
GO

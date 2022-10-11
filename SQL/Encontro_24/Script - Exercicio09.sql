
--DECLARE  @Id_Tipo_Aquicultura INT
--SET  @Id_Tipo_Aquicultura = 20

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
--WHERE tipo.IdTipoAquicultura = @Id_Tipo_Aquicultura AND Id_Municipio = @Id_Municipio AND Ano = @Ano AND Aquicultura.Producao IS NOT NULL
--GO


CREATE PROCEDURE SP_EX09
@Id_Tipo_Aquicultura INT, @Id_Municipio INT, @Ano INT
AS
BEGIN
	SELECT Aquicultura.Id_Aquicultura, 
		   Aquicultura.Ano, 
		   Aquicultura.Id_Municipio, 
		   tipo.Id_Tipo_Aquicultura,
		   Tipo.Descricao_Tipo_Aquicultura, 
		   Aquicultura.Producao, 
		   Aquicultura.Valor_Producao, 
		   Aquicultura.Proporcao_Valor_Producao,
		   Aquicultura.Moeda

	FROM Aquicultura 
	INNER JOIN TipoAquicultura AS Tipo ON Aquicultura.IdTipoAquicultura = Tipo.IdTipoAquicultura
	WHERE tipo.IdTipoAquicultura = @Id_Tipo_Aquicultura AND Id_Municipio = @Id_Municipio AND Ano = @Ano AND Aquicultura.Producao IS NOT NULL

END
GO


EXEC  SP_EX09 20, 1100015, 2013
GO

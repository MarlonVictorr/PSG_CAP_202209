
--DECLARE @Id_Tipo_Aquicultura INT
--SET @IdTipo = 9

--DECLARE @Id_Municipio INT
--SET @IdMunicipio = 1100015

--DECLARE @Ano INT
--SET @Ano = 2013

--SELECT Aquicultura.Id_Aquicultura, 
--	   Aquicultura.Ano, 
--	   Aquicultura.Id_Municipio, 
--	   tipo.Id_Tipo_Aquicultura,
--	   Tipo.Descricao_Tipo_Aquicultura, 
--	   Aquicultura.Producao, 
--	   Aquicultura.Valor_Producao, 
--	   Aquicultura.Proporcao_Valor_Producao,
--	   Aquicultura.Moeda

--FROM Aquicultura 
--INNER JOIN TipoAquicultura AS Tipo ON Aquicultura.IdTipoAquicultura = Tipo.IdTipoAquicultura
--WHERE tipo.IdTipoAquicultura = @Id_Tipo_Aquicultura AND Id_Municipio = @Id_Municipio AND Ano = @Ano
--GO

--PROCEDURE 
CREATE PROCEDURE SP_EX07
@IdTipo INT, @IdMunicipio INT, @Ano INT
AS
BEGIN
	SELECT Aquicultura.IdAquicultura, 
	   Aquicultura.Ano, 
	   Aquicultura.IdMunicipio, 
	   Tipo.DescricaoTipoAquicultura, 
	   Aquicultura.Producao, 
	   Aquicultura.ValorProducao, 
	   Aquicultura.ProporcaoValorProducao,
	   Aquicultura.Moeda
	FROM Aquicultura 
	INNER JOIN TipoAquicultura AS Tipo ON Aquicultura.IdTipoAquicultura = Tipo.IdTipoAquicultura
	WHERE tipo.IdTipoAquicultura = @Id_Tipo_Aquicultura AND Id_Municipio = @Id_Municipio AND Ano = @Ano
END
GO

--EXECUÇÃO
EXEC SP_EX07 9, 1100015, 2013
GO

select * from Raw_Aquicultura_Brasil_Municipios

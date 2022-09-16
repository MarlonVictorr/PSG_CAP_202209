DECLARE @IBGE7 INT
SET @IBGE7 = 2400109
SELECT CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, SiglaUF, DescricaoUF
FROM VW_Municipios_IBGE 
WHERE (CodigoIBGE7 = @IBGE7)
GO

CREATE PROCEDURE SP_Pesquisar_Municipios_Por_IBGE7
@CodigoIBGE7 INT 
AS
BEGIN 
	SELECT CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, SiglaUF, DescricaoUF
	FROM VW_Municipios_IBGE AS GO 
	WHERE (CodigoIBGE7 = @CodigoIBGE7)
END 
GO

EXEC dbo.SP_Pesquisar_Municipios_Por_IBGE7 2400109

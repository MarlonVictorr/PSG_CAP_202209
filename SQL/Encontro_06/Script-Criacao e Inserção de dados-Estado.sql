CREATE TABLE Estado(
	CodigoUF INT NOT NULL PRIMARY KEY,
	SiglaUF CHAR(2) NOT NULL,
	DescricaoUF VARCHAR(255) NULL
)

INSERT INTO Estado(CodigoUF,SiglaUF)
	SELECT CodigoUF, DescricaoUF
	FROM RAW_Municipio_Previa_01
	GROUP BY CodigoUF, DescricaoUF
	ORDER BY CodigoUF
GO

SELECT *FROM Estado
GO

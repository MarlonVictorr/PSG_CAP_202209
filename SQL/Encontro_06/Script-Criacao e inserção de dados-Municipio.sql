CREATE TABLE MUNICIPIO(
	CodigoMunicipio INT NOT NULL,
	NomeMunicipio VARCHAR(MAX) NOT NULL,
	CodigoIBGE6 INT NOT NULL,
	CodigoIBGE7 INT NOT NULL,
	CEP INT NOT NULL,
	CodigoUF INT NOT NULL,
	SiglaUF CHAR(2) NOT NULL,
	Regiao VARCHAR(255) NOT NULL,
	Populacao INT NOT NULL,
	Porte VARCHAR(255) NULL,
	DataInclusao DATETIME NULL DEFAULT GETDATE(),
	CONSTRAINT PK_MUNICIPIO PRIMARY KEY (CodigoMunicipio),
	CONSTRAINT FK_MUNICIPIO_Estado FOREIGN KEY (CodigoUF) REFERENCES Estado (CodigoUF)
)

INSERT INTO Municipio ( CodigoMunicipio, NomeMunicipio, CodigoIBGE6, CodigoIBGE7, CEP, CodigoUF, SiglaUF, Regiao, Populacao, Porte)
	SELECT        RAW_Municipios_Complementar_IBGE_UTF8.MunicipioID, RAW_Municipios_Complementar_IBGE_UTF8.Nome, RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.IBGE, 
                         RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.IBGE7, [RAW_Cidades_IBGE6 - UTF8].CEP, RAW_Municipios_Complementar_IBGE_UTF8.UFID, [RAW_Cidades_IBGE6 - UTF8].UF, 
                         RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.Região, RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.População_2010, RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.Porte
FROM            RAW_Municipios_Complementar_IBGE_UTF8 INNER JOIN
                         RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8 ON RAW_Municipios_Complementar_IBGE_UTF8.CodigoIBGE = RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.IBGE7 INNER JOIN
                         [RAW_Cidades_IBGE6 - UTF8] ON RAW_Lista_de_Municipios_com_IBGE_Brasil_UTF8.IBGE = [RAW_Cidades_IBGE6 - UTF8].IBGE

SELECT *FROM Municipio

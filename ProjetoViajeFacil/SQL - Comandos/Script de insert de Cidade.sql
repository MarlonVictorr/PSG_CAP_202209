insert into ViajeFacilDB.DBO.cidade (nome,codigo_ibge7,uf,id_estado)
SELECT        Academia.Geral.Municipio.NomeMunicipio, Academia.Geral.Municipio.CodigoIBGE7, Academia.Geral.Municipio.SiglaUF, estado.id_estado
FROM            Academia.Geral.Municipio INNER JOIN
                         estado ON Academia.Geral.Municipio.SiglaUF = estado.uf
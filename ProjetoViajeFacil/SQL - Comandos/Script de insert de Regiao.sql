use ViajeFacilDB
GO


insert into [ViajeFacilDB].[DBO].regiao(nome,id_pais)
select Regiao, 30
from Academia.Geral.Municipio
group by regiao

GO

--delete from regiao
--go

--dbcc checkident('regiao',reseed,0)
--go
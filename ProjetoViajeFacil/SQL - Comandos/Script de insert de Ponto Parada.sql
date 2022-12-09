insert into ViajeFacilDB.DBO.ponto_parada (descricao,latitude,longitude,id_rota)
Values
('Camapuã','19° 31 38 Sul','54° 2 32 Oeste',1),
('Catas Altas','20° 4 26 Sul','43° 23 55 Oeste',2),
('Angra dos Reis','23° 0 36 Sul','44° 19 6 Oeste',3),
('Pedra Azul','16° 0 43 Sul','41° 17 19 Oeste',4),
('Cambará do Sul','29° 02 5 Sul','50° 08 4 Oeste',5)
GO

--delete from ponto_parada
--go

--dbcc checkident('ponto_parada',reseed,0)
--go
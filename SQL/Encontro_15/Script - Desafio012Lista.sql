--Desafio12
--Declare @TemperaturaCelsius FLOAT
--set @TemperaturaCelsius = 20
--Begin 
--	PRINT 'Sua Temperatura em Fahrenheit é:' + ' ' + convert(Varchar(max), (@TemperaturaCelsius *9 /5 + 32))
--End 

Create Procedure SP_Desafio012
@TemperaturaCelsius float
AS
Begin 
	PRINT 'Sua Temperatura em Fahrenheit é:' + ' ' + convert(Varchar(max), (@TemperaturaCelsius *9 /5 + 32))
END

exec dbo.SP_Desafio012 15

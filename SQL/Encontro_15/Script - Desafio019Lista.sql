--Desafio19
--DECLARE @Numero INT
--SET @Numero = 10
--BEGIN
--    IF 
--    (@Numero % 2 = 0)
--    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é par.')
--    ELSE 
--    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é impar.')
--END
--GO

CREATE PROCEDURE SP_Desafio019
@Numero INT
AS 
BEGIN
    IF 
    (@Numero % 2 = 0)
    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é par.')
    ELSE 
    PRINT 'O número ' + CONVERT(VARCHAR,@Numero) + CONVERT(VARCHAR(max), ' é impar.')
END
GO

EXEC SP_Desafio019 10

	

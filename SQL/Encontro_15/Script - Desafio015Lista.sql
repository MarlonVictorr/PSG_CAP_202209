--Desafio15
--DECLARE @Nomes TABLE(
--    Nome VARCHAR(MAX) NOT NULL
--)

--INSERT INTO @Nomes VALUES
--    ('Gustavo'),
--    ('Bruno'),
--    ('Riedo'),
--    ('Ricardo'),
--    ('Luiz'),
--    ('Otavio'),
--    ('Elias'),
--    ('Lucas'),
--    ('Bernardo'),
--    ('Arthur'),
--    ('Breno')

--SELECT * FROM @Nomes ORDER BY Nome
--GO

CREATE PROCEDURE SP_Desafio015
AS
BEGIN
    DECLARE @Nomes TABLE(
    Nome VARCHAR(MAX) NOT NULL
)

    INSERT INTO @Nomes VALUES 
     ('Gustavo'),
    ('Bruno'),
    ('Riedo'),
    ('Ricardo'),
    ('Luiz'),
    ('Otavio'),
    ('Elias'),
    ('Lucas'),
    ('Bernardo'),
    ('Arthur'),
    ('Breno')

    SELECT * FROM @Nomes
    ORDER BY Nome
END
GO

EXEC dbo.SP_Desafio015 
GO

--Desafio16


--DECLARE @Nomes Table(
--Codigo INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
--Nome VARCHAR(MAX) NOT NULL
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

--	Begin
--		Declare @Sorteio INT	
--		Select  @Sorteio = COUNT(*) FROM @Nomes
--		Declare @Codigo int 
--		set @Codigo = FLOOR(RAND()*(@Sorteio+1))
--		while @Codigo = 0
--		BEGIN
--			SET @Codigo = FLOOR(RAND() * (@Sorteio + 1))
--		END
--			SELECT Nome FROM @Nomes WHERE Codigo = @Codigo
--	END


Create Procedure SP_Desafio16
AS
BEGIN
DECLARE @Nomes Table(
Codigo INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
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

	Begin
		Declare @Sorteio INT	
		Select  @Sorteio = COUNT(*) FROM @Nomes
		Declare @Codigo int 
		set @Codigo = FLOOR(RAND()*(@Sorteio+1))
		while @Codigo = 0
		BEGIN
			SET @Codigo = FLOOR(RAND() * (@Sorteio + 1))
		END
			SELECT Nome FROM @Nomes WHERE Codigo = @Codigo
	END
END

EXEC dbo.SP_Desafio16

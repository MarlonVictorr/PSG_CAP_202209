DECLARE @Parcelamento TABLE(
    ParcelaId BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FuncionarioId BIGINT NOT NULL,
    Nome VARCHAR(MAX) NOT NULL,
    Sobrenome VARCHAR(MAX) NOT NULL,
    Valor DECIMAL   NULL,
    NumeroParcela DECIMAL  NULL,
    Parcela DECIMAL NULL
)

	Declare @contador int 
	set @contador = 0


DECLARE @FuncId BIGINT
DECLARE CursorParce CURSOR
    FOR SELECT FuncionarioId FROM Funcionario WHERE Sexo = 'F' AND Sobrenome LIKE 'MID%'
OPEN CursorParce
FETCH NEXT FROM CursorParce INTO @FuncId

	DECLARE @Valor DECIMAL
	SET @Valor = 1000 

	Declare @NumeroParcela DECIMAL
	SET @NumeroParcela = FLOOR(rand() * (10 - 1 + 1 )) +1;

	Declare @Parcela decimal
	set @Parcela = @Valor / @NumeroParcela



WHILE (@@FETCH_STATUS = 0)
BEGIN 
	select @contador = COUNT(*) from @Parcelamento
	set @FuncId = FLOOR(RAND() * (@contador +1))
	set @FuncId = @FuncId + 1
	while(@FuncId = 0)
	BEGIN
		set @FuncId = FLOOR(RAND() * (@contador +1))
		set @FuncId = @FuncId + 1
	END

	if((select COUNT(*) from @Parcelamento) = 0)
	begin
		INSERT INTO @Parcelamento(FuncionarioId, Nome, Sobrenome, Valor, NumeroParcela, Parcela ) 
		SELECT FuncionarioId, Nome, Sobrenome, '700', '10', '70' FROM Funcionario
		set @contador = @contador + 1
	end
	else 
	BEGIN
		IF ((SELECT COUNT(*) FROM @Parcelamento WHERE ParcelaId = @FuncId) = 0)
			BEGIN
				INSERT INTO @Parcelamento(FuncionarioId, Nome)
					SELECT FuncionarioId, Nome FROM @Parcelamento WHERE ParcelaId = @FuncId
				SET @Contador = @Contador + 1
			END
	END

	SELECT @contador = COUNT(*) FROM @Parcelamento
	SET @FuncId = FLOOR(RAND() * (@contador + 1))
	WHILE (@contador = 0)
	BEGIN
		SET @FuncId = FLOOR(RAND() * (@contador + 1))
	END

	WHILE (NOT EXISTS(SELECT * FROM @Parcelamento WHERE ParcelaId = @FuncId))
	BEGIN
		SET @FuncId = FLOOR(RAND() * (@contador + 1))
	END

	FETCH NEXT FROM CursorParce INTO @FuncId
END
CLOSE CursorParce
DEALLOCATE CursorParce
select *from @Parcelamento where ParcelaId = @FuncId
GO

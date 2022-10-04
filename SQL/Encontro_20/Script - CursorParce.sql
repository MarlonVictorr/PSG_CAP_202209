CREATE TABLE Parcelamento(
    ParcelaId BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FuncionarioId BIGINT NOT NULL,
    Sobrenome VARCHAR(MAX) NOT NULL,
	Sexo CHAR(1) NOT NULL,
    Valor NUMERIC(10,2) NOT  NULL,
    Parcela DECIMAL NOT NULL
)

DECLARE @FuncId BIGINT
DECLARE CursorParce CURSOR
    FOR SELECT FuncionarioId FROM Funcionario WHERE Sexo = 'F' AND Sobrenome LIKE 'MID%'

OPEN CursorParce
FETCH NEXT FROM CursorParce INTO @FuncId

DECLARE @Valor NUMERIC(10,2)
SET @Valor = 1000

Declare @Parcini INT
SET @Parcini = 10

DECLARE @ValorParcela NUMERIC(10,2)
	

WHILE (@@FETCH_STATUS = 0)
BEGIN 
	Declare @NumeroParcela DECIMAL
	SET @NumeroParcela = FLOOR(rand() * (10 + 1)) 
	
	SET @Parcini = 1 

	WHILE(@Parcini < @NumeroParcela)
	BEGIN
		Set @ValorParcela = @Valor * @Parcini
		
    INSERT INTO Parcelamento(FuncionarioId,Sobrenome,Sexo, Valor, Parcela) 
		SELECT FuncionarioId, Sobrenome,Sexo,@ValorParcela,@Parcini 
		FROM Funcionario
		WHERE (FuncionarioId = @FuncId)

	SET @Parcini = @Parcini + 1
	END
	FETCH NEXT FROM CursorParce INTO @FuncId
END
CLOSE CursorParce
DEALLOCATE CursorParce
Select * from Parcelamento
GO


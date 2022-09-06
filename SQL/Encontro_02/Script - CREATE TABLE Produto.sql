Create Table Produto(
    Codigo INT NOT NULL IDENTITY(1,1),
    CodigoSubCategoria INT NOT NULL,
    CodigoCategoria INT NOT NULL,
    Descricao VARCHAR(MAX)NOT NULL,
    DataInsert DATETIME NOT NULL,
    CONSTRAINT PK_Produto PRIMARY KEY (Codigo),
    CONSTRAINT FK_PRODUTO_SubCategoria FOREIGN KEY (CodigoSubCategoria) REFERENCES SubCategoria (Codigo)
)
GO

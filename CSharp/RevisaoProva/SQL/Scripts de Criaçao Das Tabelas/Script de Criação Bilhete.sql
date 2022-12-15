Create table Bilhete(
	CodigoBilhete int identity(1,1) not null,
	NumeroBilhete int not null,
	Assento char(4) not null,
	Constraint PK_Bilhete primary key (CodigoBilhete)
)



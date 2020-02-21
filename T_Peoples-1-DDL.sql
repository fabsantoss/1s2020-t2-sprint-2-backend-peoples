CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE Funcionarios (
	IdFuncionario	INT PRIMARY KEY IDENTITY,
	Nome		    VARCHAR (255) NOT NULL ,
	Sobrenome		VARCHAR (255) NOT NULL 
);

DROP DATABASE T_Peoples;

Use Biblioteca_Tarde
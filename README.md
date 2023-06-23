# tutorial-crud

Download SQL Server Management Studio (SSMS)

(localdb)\mssqllocaldb

CREATE DATABASE Teste

CREATE TABLE Clientes (
ClienteId INT IDENTITY (1,1) NOT NULL,
Nome VARCHAR (100),
DataNascimento Date,
Cpf VARCHAR (15),
Ativo bit, 
CONSTRAINT PK_Clientes_ClienteId PRIMARY KEY CLUSTERED (ClienteId)
)

DROP TABLE CLIENTES;
      
IF OBJECT_ID ('Clientes', 'U') IS NOT NULL

SELECT * FROM Clientes

INSERT INTO Clientes (Nome, DataNascimento, Ativo)
VALUES ('Pedro Souza', '06/02/1995', 1 )

UPDATE Clientes SET 
CPF = '12134408669',  
DataNascimento = '1995-02-06',
NOME = 'Pedro',
Ativo = 0
WHERE ClienteId = 1

SELECT * FROM Clientes
WHERE Ativo = 1

DELETE FROM Clientes
--WHERE ClienteId = 1

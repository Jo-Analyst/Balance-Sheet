CREATE DATABASE dbCRAS

use dbCRAS

CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] VARCHAR(200) NULL, 
    [CPF] VARCHAR(14) NULL, 
    [RG] VARCHAR(14) NULL, 
    [address] VARCHAR(200) NULL,
    [number_address] VARCHAR(MAX),
    [phone] VARCHAR(20) NULL, 
    [income] DECIMAL(18, 2) NULL, -- renda
    [help] DECIMAL(18, 2) NULL, --  auxílio
    [number_of_members] INT NULL -- Número de membros
)

CREATE TABLE [dbo].[Benefits_Received]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [description] VARCHAR(MAX) NULL, 
    [date_benefits] Date NULL,
    [person_id] INT NOT NULL,
    FOREIGN KEY ([person_id]) REFERENCES [dbo].[persons](id) ON DELETE CASCADE
)

SELECT persons.name, persons.CPF, persons.RG, persons.address, persons.phone, persons.income, persons.help, persons.number_of_members, Benefits_Received.description, Benefits_Received.date_benefits FROM Persons INNER JOIN Benefits_Received ON Benefits_Received.person_id = Persons.id

select * from 
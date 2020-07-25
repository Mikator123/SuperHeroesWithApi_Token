CREATE TABLE [dbo].[SuperHeroes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL UNIQUE, 
    [Strenght] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Stamina] INT NOT NULL, 
    [Charism] INT NOT NULL,

)

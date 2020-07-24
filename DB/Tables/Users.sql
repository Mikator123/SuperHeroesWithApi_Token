CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LastName] NCHAR(50) NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [Login] NCHAR(320) NOT NULL UNIQUE, 
    [Password] BINARY(64) NOT NULL
)

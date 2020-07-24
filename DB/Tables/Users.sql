CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY NOT NULL, 
    [LastName] NCHAR(50) NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [Login] NCHAR(320) NOT NULL UNIQUE, 
    [Password] BINARY(64) NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
)

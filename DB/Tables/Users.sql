CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [Login] VARCHAR(320) NOT NULL UNIQUE, 
    [Password] BINARY(64) NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
)

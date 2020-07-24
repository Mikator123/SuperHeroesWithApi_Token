CREATE PROCEDURE [dbo].[CreateUser]
	@lastname nvarchar(50),
	@firstname nvarchar(50),
	@login nvarchar(320),
	@password nvarchar(50)
AS
BEGIN
	INSERT INTO Users VALUES (@lastname, @firstname, @login, HASHBYTES('SHA2_512', (dbo.PreSalt()+@password+dbo.PostSalt())))
END

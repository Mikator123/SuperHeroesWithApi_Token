CREATE PROCEDURE [dbo].[CreateUser]
	@lastname varchar(50),
	@firstname varchar(50),
	@login varchar(320),
	@password varchar(50)
AS
BEGIN
	INSERT INTO Users VALUES (@lastname, @firstname, @login, HASHBYTES('SHA2_512', (dbo.PreSalt()+@password+dbo.PostSalt())))
END

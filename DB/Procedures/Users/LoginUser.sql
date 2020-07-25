CREATE PROCEDURE [dbo].[LoginUser]
	@login varchar(320),
	@password varchar(50)
AS
BEGIN
	SELECT * FROM Users WHERE Login = @login AND Password = HASHBYTES('SHA2_512', (dbo.PreSalt()+@password+dbo.PostSalt()))
END

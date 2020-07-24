CREATE PROCEDURE [dbo].[LoginUser]
	@login nvarchar(320),
	@password nvarchar(50)
AS
BEGIN
	SELECT * FROM Users WHERE Login = @login AND Password = HASHBYTES('SHA2_512', (dbo.PreSalt()+@password+dbo.PostSalt()))
END

CREATE PROCEDURE [dbo].[DeleteSuperHero]
	@id int
AS
BEGIN
	DELETE FROM SuperHeroes WHERE Id = @id
END

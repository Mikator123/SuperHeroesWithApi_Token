CREATE PROCEDURE [dbo].[UpdateSuperHero]
	@id int,
	@name nvarchar(50),
	@strenght int,
	@intelligence int,
	@stamina int,
	@charism int
AS
BEGIN
	UPDATE SuperHeroes SET Name = @name, Strenght = @strenght, Intelligence= @intelligence, Stamina = @stamina, Charism = @charism WHERE Id = @id
END

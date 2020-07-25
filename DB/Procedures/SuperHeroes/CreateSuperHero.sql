CREATE PROCEDURE [dbo].[CreateSuperHero]
	@name varchar(50),
	@strenght int,
	@intelligence int,
	@stamina int,
	@charism int

AS
BEGIN
	INSERT INTO SuperHeroes VALUES (@name, @strenght, @intelligence, @stamina, @charism)
END
RETURN 0

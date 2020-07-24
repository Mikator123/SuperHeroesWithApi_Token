
INSERT INTO SuperHeroes (Name, Strenght, Intelligence, Stamina, Charism) VALUES
('SuperWoman', 19 , 15 , 18 , 19),
('SuperMan', 19,15 ,18,19);

INSERT INTO Users (LastName, FirstName, Login, Password) VALUES
('Tournay', 'Michael' , 'mikatournay@gmail.com' , HASHBYTES('SHA2_512', (dbo.PreSalt()+'test123'+dbo.PostSalt())));



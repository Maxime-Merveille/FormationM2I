USE ma_base_de_donnee;

TRUNCATE TABLE Users;
TRUNCATE TABLE Command;

INSERT INTO Users(Nom, Prenom, Telephone)
VALUE("Maxime", "Merveille", "0659371964"),
("Truc", "Muche", "069875641");

UPDATE Users
SET Telephone = "0661400602"
WHERE Id = 1;

DELETE FROM Users
WHERE Id = 2;

ALTER TABLE Users
ADD Age INT;

UPDATE Users
SET Age = 24
WHERE Id = 1;

SELECT * FROM Users;
DROP DATABASE IF EXISTS ma_bdd;
CREATE DATABASE IF NOT EXISTS ma_bdd;
USE ma_bdd;

CREATE TABLE Film(
id INT PRIMARY KEY AUTO_INCREMENT,
titre VARCHAR(20) NOT NULL,
annee_sortie INT NOT NULL);

CREATE TABLE Acteurs(
id INT PRIMARY KEY AUTO_INCREMENT,
nom VARCHAR(20) NOT NULL,
film_id INT,
FOREIGN KEY (film_id)
REFERENCES Film(id) );

INSERT INTO Film(titre, annee_sortie)
VALUES ('Film A', 2010),
('Film B', 2015),
('Film C', 2020);


INSERT INTO Acteurs(nom, film_id)
VALUES ('Acteur 1', 1),
('Acteur 2', 1),
('Acteur 3', 2),
('Acteur 4', 2),
('Acteur 5', 3);


SELECT * FROM Film
LEFT JOIN Acteurs ON Acteurs.film_id = Film.id;
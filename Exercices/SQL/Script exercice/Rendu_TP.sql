DROP DATABASE IF EXISTS TableTopTreasures;
CREATE DATABASE IF NOT EXISTS TableTopTreasures;

USE TableTopTreasures;

DROP TABLES Clients;
CREATE TABLE Clients(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(20) NOT NULL,
    prenom VARCHAR(20) NOT NULL,
    adresse_mail VARCHAR(40) NOT NULL,
    adresse_livraison VARCHAR(40),
    telephone VARCHAR(20)
);

CREATE TABLE Categorie(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(20) NOT NULL
);
DROP TABLES Jeux;
CREATE TABLE Jeux(
	id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    descriptions VARCHAR(100),
    prix INT NOT NULL, 
    id_categorie INT NOT NULL,
    FOREIGN KEY (id_categorie) REFERENCES Categorie(id)
);

DROP TABLES Commande;
CREATE TABLE Commande(
	id INT PRIMARY KEY AUTO_INCREMENT,
    id_client INT NOT NULL,
    date_de_commande DATE NOT NULL,
    adresse_livraison VARCHAR(50),
    statu VARCHAR(20),
    FOREIGN KEY (id_client) REFERENCES Clients(id)
);

#  =================== ETAPE 2 

INSERT INTO Categorie(nom)
VALUES ('Stratégie'),
('Familial'),
('Aventure');


INSERT INTO Jeux (nom, descriptions, prix, id_categorie)
VALUES ('Catan', 'Jeu de stratégie et de développement de colonies', 30, 1),
('Dixit', 'Jeu d''association d''images', 25, 2),
('Les Aventuriers', 'Jeu de plateau d''aventure', 40, 3),
('Carcassonne', 'Jeu de placement de tuiles', 28, 1),
('Codenames', 'Jeu de mots et d''indices', 20, 2),
('Pandemic', 'Jeu de coopération pour sauver le monde', 35, 3),
('7 Wonders', 'Jeu de cartes et de civilisations', 29, 1),
('Splendor', 'Jeu de développement économique', 27, 2),
('Horreur à Arkham', 'Jeu d''enquête et d''horreur', 45, 3),
('Risk', 'Jeu de conquête mondiale', 22, 1),
('Citadelles', 'Jeu de rôles et de bluff', 23, 2),
('Terraforming Mars', 'Jeu de stratégie de colonisation de Mars', 55, 3),
('Small World', 'Jeu de civilisations fantastiques', 32, 1),
('7 Wonders Duel', 'Jeu de cartes pour 2 joueurs', 26, 2),
('Horreur à l''Outreterre', 'Jeu d''aventure horrifique', 38, 3);

INSERT INTO Clients(nom, prenom, adresse_mail, adresse_livraison, telephone)
VALUES ('Dubois', 'Marie', 'marie.dubois@example.com', '123 Rue de la Libération, Ville', '+1234567890'),
('Lefebvre', 'Thomas', 'thomas.lefebvre@example.com', '456 Avenue des Roses, Ville', '+9876543210'),
('Martinez', 'Léa', 'lea.martinez@example.com', '789 Boulevard de la Paix, Ville', '+2345678901'),
('Dupuis', 'Antoine', 'antoine.dupuis@example.com', '567 Avenue de la Liberté, Ville', '+3456789012'),
('Morin', 'Camille', 'camille.morin@example.com', '890 Rue de l''Avenir, Ville', '+4567890123'),
('Girard', 'Lucas', 'lucas.girard@example.com', '234 Avenue des Champs, Ville', '+5678901234'),
('Petit', 'Emma', 'emma.petit@example.com', '123 Rue des Étoiles, Ville', '+6789012345'),
('Sanchez', 'Gabriel', 'gabriel.sanchez@example.com', '345 Boulevard du Bonheur, Ville', '+7890123456'),
('Rossi', 'Clara', 'clara.rossi@example.com', '678 Avenue de la Joie, Ville', '+8901234567'),
('Lemoine', 'Hugo', 'hugo.lemoine@example.com', '456 Rue de la Nature, Ville', '+9012345678'),
('Moreau', 'Eva', 'eva.moreau@example.com', '789 Avenue de la Créativité, Ville', '+1234567890'),
('Fournier', 'Noah', 'noah.fournier@example.com', '234 Rue de la Découverte, Ville', '+2345678901'),
('Leroy', 'Léa', 'lea.leroy@example.com', '567 Avenue de l''Imagination, Ville', '+3456789012'),
('Robin', 'Lucas', 'lucas.robin@example.com', '890 Rue de la Création, Ville', '+4567890123'),
('Marchand', 'Anna', 'anna.marchand@example.com', '123 Boulevard de l''Innovation, Ville', '+5678901234');


INSERT INTO Commande(id_client, date_de_commande, adresse_livraison, statu)
VALUES (1, "2026-01-01", "3 rue des potiers", "Livré"),
(2, "2026-05-05", "3 rue des potiers", "En Cours"),
(3, "2025-12-12", "3 rue des potiers", "Annulé");

UPDATE Jeux
SET prix = 35
WHERE id = 3;

DELETE FROM Jeux 
WHERE id = 2;

#  =================== ETAPE 3

SELECT DISTINCT nom FROM Categorie
GROUP BY nom;

SELECT nom FROM Categorie
WHERE nom LIKE 'A%' OR nom LIKE 'S%';

SELECT id, nom FROM Categorie
WHERE id BETWEEN 2 AND 5;

SELECT COUNT(DISTINCT nom) FROM Categorie;

SELECT nom, LENGTH(nom) FROM Categorie
ORDER BY LENGTH(nom) DESC
LIMIT 1;

SELECT Categorie.nom, COUNT(Jeux.id) FROM Categorie
INNER JOIN Jeux ON Categorie.id = Jeux.id_categorie
GROUP BY Categorie.nom;

SELECT nom FROM Categorie
ORDER BY nom DESC;	


SELECT DISTINCT nom FROM Jeux;

SELECT nom, prix FROM Jeux
WHERE prix BETWEEN 25 AND 40;

SELECT nom FROM Jeux 
WHERE id_categorie = 3;

SELECT nom, descriptions FROM Jeux 
WHERE descriptions LIKE '%aventure%';

SELECT nom, prix FROM Jeux
WHERE prix = MIN(prix);

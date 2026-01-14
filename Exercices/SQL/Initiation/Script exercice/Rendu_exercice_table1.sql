DROP DATABASE IF EXISTS ma_bdd;
CREATE DATABASE IF NOT EXISTS ma_bdd;
USE ma_bdd;

CREATE TABLE Livres(
	id_livre INT PRIMARY KEY AUTO_INCREMENT,
	titre VARCHAR(50),
    auteur VARCHAR(30),
    annee_publication INT,
    genre VARCHAR(10),
    exemplaire_disponible INT
    );
    
CREATE TABLE Membres(
	id_membre INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(20),
    prenom VARCHAR(20),
    date_naissance DATE,
    adresse VARCHAR(20),
    email VARCHAR(20),
	telephone VARCHAR(20),
    id_livre INT,
    FOREIGN KEY (id_livre) REFERENCES Livres(id_livre)
);
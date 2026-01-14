DROP DATABASE IF EXISTS ma_bdd;
CREATE DATABASE IF NOT EXISTS ma_bdd;
USE ma_bdd;

CREATE TABLE Utilisateurs(
	id_utilisateur INT PRIMARY KEY AUTO_INCREMENT,
    nom_utilisateur VARCHAR(20),
    email VARCHAR(20),
    date_inscription DATE,
    pays VARCHAR(20)
);


CREATE TABLE Chansons(
	id_chanson INT PRIMARY KEY AUTO_INCREMENT,
    titre VARCHAR(20),
    artiste VARCHAR(20),
    album VARCHAR(20),
    duree int,
    genre VARCHAR(20),
    annee_sortie INT
);

CREATE TABLE Playlist(
	id_playlist INT PRIMARY KEY AUTO_INCREMENT,
    nom_playlist VARCHAR(20),
    id_utilisateur INT,
    date_creation DATE,
    FOREIGN KEY (id_utilisateur) REFERENCES Utilisateurs(id_utilisateur)
);
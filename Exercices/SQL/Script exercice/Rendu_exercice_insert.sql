DROP DATABASE IF EXISTS ma_bdd;
CREATE DATABASE IF NOT EXISTS ma_bdd;
USE ma_bdd;

CREATE TABLE Students(
student_id INT PRIMARY KEY AUTO_INCREMENT,
first_name VARCHAR(20),
last_name VARCHAR(20),
date_of_birth DATE,
email VARCHAR(50)
);

CREATE TABLE Courses(
course_id INT PRIMARY KEY AUTO_INCREMENT,
course_name VARCHAR(20),
instructor VARCHAR(40),
start_date DATE,
end_date DATE
);

INSERT INTO Students(first_name, last_name, date_of_birth, email)
VALUES ('Maxime', 'Merveille', '2001-12-07', 'maximemerveille59@gmail.com'),
('truc', 'Muche','2002-05-05', 'trucMuche@gmail.com'),
('tita', 'totu','1999-09-19', 'titatotu@gmail.com');

INSERT INTO Courses(course_name, instructor, start_date, end_date)
VALUES ('Informatique', 'Monsieur Merveille', '2026-09-07', '2027-06-12'),
('Physique', 'Monsieur Muche','2026-09-01', '2027-06-22');
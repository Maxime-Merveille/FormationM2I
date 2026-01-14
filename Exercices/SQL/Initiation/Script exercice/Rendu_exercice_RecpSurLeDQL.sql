USE test_bdd;
### PARTIE 1

SELECT first_name, last_name, job FROM users
WHERE birth_location = 'New York';

SELECT * FROM users
WHERE salary > 2500
AND job IN ('Developer','Engineer');

SELECT first_name, last_name FROM users
WHERE job = 'Designer'
AND salary BETWEEN 1500 AND 3000;

### PARTIE 2

SELECT AVG(salary) FROM users;

SELECT birth_location, COUNT(id) FROM users
WHERE age < 30
GROUP BY birth_location;

SELECT birth_location, COUNT(id) FROM users
WHERE salary > (
	SELECT AVG(salary) 
    FROM users)
GROUP BY birth_location;

### PARTIE 3

SELECT first_name, last_name, age, job FROM users
WHERE last_name = 'Smith'
AND (job = 'Developer' OR job = 'Engineer');

SELECT * FROM users
WHERE job IN ('Teacher','Designer','Doctor')
AND age > 30;

SELECT * FROM users
WHERE job IN ('Engineer', 'Developer')
AND salary > 2000
AND (first_name LIKE 'J%' OR first_name LIKE 'S%');

### PARTIE 4

SELECT first_name, last_name, job FROM users
WHERE job LIKE '%Engineer%'
ORDER BY last_name ASC;

SELECT * FROM users
WHERE birth_date > '1990-01-01'
AND last_name LIKE '%son'
ORDER BY age ASC;

### PARTIE 5

SELECT DISTINCT job, COUNT(id) FROM users
WHERE salary > 2500
GROUP BY job;

SELECT birth_location, COUNT(id) FROM users
GROUP BY birth_location
HAVING AVG(age) < 35;

SELECT SUM(salary) FROM users
WHERE birth_location = 'London'
AND job IN ('Developer', 'Designer', 'Engineer');

### PARTIE 6

SELECT first_name, last_name, job, salary FROM users u
WHERE salary > (
    SELECT AVG(u2.salary)
    FROM users u2
    WHERE u2.job = u.job
);

SELECT first_name, last_name, job
FROM users
WHERE job = (
    SELECT job
    FROM users
    WHERE first_name = 'Alice' AND last_name = 'Smith'
)
AND NOT (first_name = 'Alice' AND last_name = 'Smith');






CREATE TABLE the_oscar_award(
    year_film INTEGER NOT NULL,
    year_ceremony INTEGER NOT NULL,
    ceremony INTEGER NOT NULL,
    category VARCHAR(137) NOT NULL,
    name VARCHAR(280) NOT NULL,
    film VARCHAR(82),
    winner VARCHAR(5) NOT NULL
);
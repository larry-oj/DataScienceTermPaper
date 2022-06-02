CREATE TABLE movies_IMDB(
    id INTEGER NOT NULL PRIMARY KEY,
    movie_name VARCHAR(54) NOT NULL,
    genre VARCHAR(41) NOT NULL,
    year INTEGER NOT NULL,
    timeMin INTEGER NOT NULL,
    imdb NUMERIC(3, 1) NOT NULL,
    metascore VARCHAR(17) NOT NULL,
    votes INTEGER NOT NULL,
    us_grossMillions VARCHAR(17) NOT NULL
);
CREATE TABLE imdb_top_1000(
    Poster_Link VARCHAR(161) NOT NULL,
    Series_Title VARCHAR(68) NOT NULL,
    Released_Year VARCHAR(4) NOT NULL,
    Certificate VARCHAR(8),
    Runtime VARCHAR(7) NOT NULL,
    Genre VARCHAR(29) NOT NULL,
    IMDB_Rating NUMERIC(3, 1) NOT NULL,
    Overview VARCHAR(313) NOT NULL,
    Meta_score INTEGER,
    Director VARCHAR(32) NOT NULL,
    Star1 VARCHAR(25) NOT NULL,
    Star2 VARCHAR(25) NOT NULL,
    Star3 VARCHAR(27) NOT NULL,
    Star4 VARCHAR(27) NOT NULL,
    No_of_Votes INTEGER NOT NULL,
    Gross VARCHAR(11)
);
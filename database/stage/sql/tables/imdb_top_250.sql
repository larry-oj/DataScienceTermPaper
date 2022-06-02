CREATE TABLE imdb_top_250(
    Rating_Id INTEGER NOT NULL,
    IMDByear INTEGER NOT NULL,
    IMDBlink VARCHAR(18) NOT NULL,
    Title VARCHAR(68) NOT NULL,
    Date INTEGER NOT NULL,
    RunTime INTEGER NOT NULL,
    Genre VARCHAR(28) NOT NULL,
    Rating NUMERIC(3, 1) NOT NULL,
    Score NUMERIC(5, 1),
    Votes INTEGER NOT NULL,
    Gross NUMERIC(6, 2),
    Director VARCHAR(187) NOT NULL,
    Cast1 VARCHAR(26) NOT NULL,
    Cast2 VARCHAR(32) NOT NULL,
    Cast3 VARCHAR(29),
    Cast4 VARCHAR(29)
);
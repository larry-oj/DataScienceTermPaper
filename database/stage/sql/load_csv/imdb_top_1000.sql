LOAD DATA INFILE '/home/pi/Temp/imdb_top_1000.csv' 
INTO TABLE imdb_top_1000 
FIELDS TERMINATED BY ',' 
OPTIONALLY ENCLOSED BY '\"'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS;
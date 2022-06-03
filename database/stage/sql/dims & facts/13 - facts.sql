CREATE TABLE `facts` (
    `id` int NOT NULL,
    `genre_group_id` int NOT NULL,
    `oscar_group_id` int NOT NULL,
    `time_dim` int NOT NULL,
    `director_id` int NOT NULL,
    `actor_group_id` int NOT NULL,
    `film_id` int NOT NULL,
    `rating` double NULL,
    `score` int NULL,
    `gross` int NULL,
    `runtime` int NULL,
    `votes` int NULL,
    PRIMARY KEY (`id`),
    KEY `FK_108` (`genre_group_id`),
    CONSTRAINT `FK_106` FOREIGN KEY `FK_108` (`genre_group_id`) REFERENCES `genre_group_dim` (`id`),
    KEY `FK_111` (`film_id`),
    CONSTRAINT `FK_109` FOREIGN KEY `FK_111` (`film_id`) REFERENCES `film_dim` (`id`),
    KEY `FK_124` (`actor_group_id`),
    CONSTRAINT `FK_122` FOREIGN KEY `FK_124` (`actor_group_id`) REFERENCES `actor_group_dim` (`id`),
    KEY `FK_127` (`director_id`),
    CONSTRAINT `FK_125` FOREIGN KEY `FK_127` (`director_id`) REFERENCES `person_dim` (`id`),
    KEY `FK_134` (`time_dim`),
    CONSTRAINT `FK_132` FOREIGN KEY `FK_134` (`time_dim`) REFERENCES `time_dim` (`id`),
    KEY `FK_177` (`oscar_group_id`),
    CONSTRAINT `FK_175` FOREIGN KEY `FK_177` (`oscar_group_id`) REFERENCES `oscar_group_dim` (`id`)
);
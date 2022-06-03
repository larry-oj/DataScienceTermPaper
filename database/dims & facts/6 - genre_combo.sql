CREATE TABLE `genre_combo` (
    `genre_group_id` int NOT NULL,
    `genre_id` int NOT NULL,
    KEY `FK_105` (`genre_id`),
    CONSTRAINT `FK_103` FOREIGN KEY `FK_105` (`genre_id`) REFERENCES `genre_dim` (`id`),
    KEY `FK_98` (`genre_group_id`),
    CONSTRAINT `FK_96` FOREIGN KEY `FK_98` (`genre_group_id`) REFERENCES `genre_group_dim` (`id`)
);
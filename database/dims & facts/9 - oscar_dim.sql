CREATE TABLE `osacar_dim` (
    `id` int NOT NULL,
    `category_id` int NOT NULL,
    `winner` boolean NOT NULL,
    PRIMARY KEY (`id`),
    KEY `FK_162` (`category_id`),
    CONSTRAINT `FK_160` FOREIGN KEY `FK_162` (`category_id`) REFERENCES `category_dim` (`id`)
);
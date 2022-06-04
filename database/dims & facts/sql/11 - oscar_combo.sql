CREATE TABLE `oscar_combo` (
    `id` int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `osacr_group_id` int NOT NULL,
    `oscar_dim_id` int NOT NULL,
    KEY `FK_171` (`osacr_group_id`),
    CONSTRAINT `FK_169` FOREIGN KEY `FK_171` (`osacr_group_id`) REFERENCES `oscar_group_dim` (`id`),
    KEY `FK_174` (`oscar_dim_id`),
    CONSTRAINT `FK_172` FOREIGN KEY `FK_174` (`oscar_dim_id`) REFERENCES `osacar_dim` (`id`)
);
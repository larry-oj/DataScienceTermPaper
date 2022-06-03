CREATE TABLE `actor_combo` (
    `actor_group_id` int NOT NULL,
    `person_id` int NOT NULL,
    KEY `FK_118` (`actor_group_id`),
    CONSTRAINT `FK_116` FOREIGN KEY `FK_118` (`actor_group_id`) REFERENCES `actor_group_dim` (`id`),
    KEY `FK_137` (`person_id`),
    CONSTRAINT `FK_135` FOREIGN KEY `FK_137` (`person_id`) REFERENCES `person_dim` (`id`)
);
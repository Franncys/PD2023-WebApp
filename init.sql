CREATE DATABASE NarutoDB;
USE NarutoDB;

CREATE TABLE VoiceActor (
	id INT(10)AUTO_INCREMENT PRIMARY KEY,
    actor_name varchar(200),
    language_version varchar(20)
);

#ALTER TABLE VoiceActor CHANGE id id INT(10)AUTO_INCREMENT PRIMARY KEY;

CREATE TABLE Jutsu (
	id INT(10)AUTO_INCREMENT PRIMARY KEY,
    jutsu_name varchar(200)    
);

#ALTER TABLE Jutsu CHANGE id id INT(10)AUTO_INCREMENT PRIMARY KEY;

CREATE TABLE Team (
	id INT(10)AUTO_INCREMENT PRIMARY KEY,
    team_name varchar(200)    
);

#ALTER TABLE Team CHANGE id id INT(10)AUTO_INCREMENT PRIMARY KEY;

CREATE TABLE Clan (
	id INT(10)AUTO_INCREMENT PRIMARY KEY,
    clan_name varchar(200)    
);

#ALTER TABLE Clan CHANGE id id INT(10)AUTO_INCREMENT PRIMARY KEY;

CREATE TABLE Characters (
	id int(10) NOT NULL PRIMARY KEY,
    char_name varchar(200),
    image_url varchar(200),
    debut JSON,
    personal_detail JSON
);

CREATE TABLE Character_VoiceActor (
	id_character int(10) NOT NULL,
    id_actor int(10) NOT NULL,
    FOREIGN KEY (id_character) REFERENCES Characters(id),
    FOREIGN KEY (id_actor) REFERENCES VoiceActor(id)
);

#ALTER TABLE Character_VoiceActor CHANGE id_actor id_actor INT(10)AUTO_INCREMENT PRIMARY KEY;

CREATE TABLE Character_Jutsu (
	id_character int(10) NOT NULL,
    id_jutsu int(10) NOT NULL,
    FOREIGN KEY (id_character) REFERENCES Characters(id),
    FOREIGN KEY (id_jutsu) REFERENCES Jutsu(id)
);

CREATE TABLE Character_Team (
	id_character int(10) NOT NULL,
    id_team int(10) NOT NULL,
    FOREIGN KEY (id_character) REFERENCES Characters(id),
    FOREIGN KEY (id_team) REFERENCES Team(id)
);

CREATE TABLE Character_Clan (
	id_character int(10) NOT NULL,
    id_clan int(10) NOT NULL,
    FOREIGN KEY (id_character) REFERENCES Characters(id),
    FOREIGN KEY (id_clan) REFERENCES Clan(id)
);

INSERT INTO Characters(id, char_name, image_url, debut, personal_detail)
Values(
	17, 
	'Ada', 
    NULL, 
    '{"manga": "Boruto Chapter #56", "appearsIn": "Manga"}', 
    '{"sex": "Female", "age": {"Boruto Manga": "16"}, "kekkeiGenkai": "Senrigan", "affiliation": ["Kara", "Konohagakure"], "titles": ["\\u30a8\\u30a4\\u30c0Eida"]}');

SELECT * FROM Characters;
SELECT * FROM Jutsu;
SELECT * FROM Character_VoiceActor;
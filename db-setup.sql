USE gardenboxer;

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     keeps INT DEFAULT 0,
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT 
-- k.*,
-- vk.id as vaultKeepId
-- FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;

-- CREATE TABLE beds (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     userId VARCHAR(255) NOT NULL,
--     img VARCHAR(255),
--     datePlanted DATE,
--     dateFertilized DATE,
--     width INT,
--     height INT,
--     INDEX userId (userId),
--     PRIMARY KEY (id),
--     bedX INT NOT NULL,
--     bedY INT NOT NULL,
--     gardenId INT NOT NULL,
--     UNIQUE(bedX, bedY, gardenId),

    -- FOREIGN KEY (gardenId)
    -- REFERENCES gardens(id)
    -- ON DELETE CASCADE
-- );

-- CREATE TABLE gardens (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   description VARCHAR(255),
--   backGround VARCHAR(255),
--   width int NOT NULL,
--   height int NOT NULL,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE bedtemplates (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   width INT,
--   height INT,
--   img VARCHAR(255).
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE groups (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE bedgroups (
--   id int NOT NULL AUTO_INCREMENT,
--   userId VARCHAR(255) NOT NULL,
--   bedId int NOT NULL,
--   groupId int NOT NULL,
--   gardenId int NOT NULL,
--   PRIMARY KEY (id),

--   FOREIGN KEY (gardenId)
--     REFERENCES gardens(id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (bedId)
--     REFERENCES beds(id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (groupId)
--     REFERENCES groups(id)
--     ON DELETE CASCADE,

--   UNIQUE(bedId, groupId),
--   UNIQUE(bedId, gardenId)
-- )

-- USE THIS LINE FOR GET KEEPS BY VAULTID
-- g.id as groupId


-- SELECT 
-- b.*,
-- FROM bedgroups bg
-- INNER JOIN beds b ON b.id = bg.bedId 
-- WHERE (bg.userId = @userId AND bg.bedId = @id)


-- INNER JOIN groups g ON g.id = bg.groupId
-- WHERE (bg.groupId = @id AND bg.userId = @userId)
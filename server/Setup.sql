CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  name VARCHAR(255) NOT NULL COMMENT 'vault name',
  description VARCHAR (255) NOT NULL COMMENT 'vault description',
  img VARCHAR (255) NOT NULL COMMENT 'keep imgurl',
  isPrivate BOOLEAN NOT NULL COMMENT 'is vault private',
  creatorId VARCHAR (255) NOT NULL COMMENT 'FK: profiles',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR (255) NOT NULL COMMENT 'keep name',
  description VARCHAR (255) NOT NULL COMMENT 'keep description',
  img VARCHAR (255) NOT NULL COMMENT 'keep imgurl',
  views INT NOT NULL,
  shares INT COMMENT 'stretch goal',
  keeps INT NOT NULL,
  creatorId VARCHAR (255) NOT NULL COMMENT 'FK: profiles',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vault_keeps(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR (255) NOT NULL COMMENT 'FK: profiles',
  vaultId INT NOT NULL COMMENT 'FK: vault',
  keepId INT NOT NULL COMMENT 'FK: key',
  FOREIGN KEY (creatorId) REFERENCES profiles(id) ON DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
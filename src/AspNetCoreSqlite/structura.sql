CREATE TABLE Users (
	Id INTEGER PRIMARY KEY,
	Created TIMESTAMP default CURRENT_TIMESTAMP,

	Name varchar(255),
	Email varchar(255) NOT NULL UNIQUE,
	Password varchar(255) NOT NULL,
  
	Token varchar(255) NULL UNIQUE,
  
	VkId varchar(255) NULL UNIQUE,
	VkToken varchar(255),
	VkExpires datetime,
	FbId varchar(255) NULL UNIQUE,
	FbToken varchar(255),
	FbExpires datetime
);

CREATE UNIQUE INDEX Email ON Users (
    Email
);

insert into Users (Name, Email, Password) values ('Andrey', '96467840@mail.ru', '');

CREATE TABLE Sites (
	Id INTEGER PRIMARY KEY,
	Created TIMESTAMP default CURRENT_TIMESTAMP,

	Name varchar(255)
);
CREATE TABLE Users (
	Id INTEGER PRIMARY KEY,
	Created TIMESTAMP default CURRENT_TIMESTAMP,

	Name varchar(255),
	Email varchar(255) NOT NULL UNIQUE,
	Password varchar(255) NOT NULL,
  
	Token varchar(255) NULL UNIQUE,
  
	vkId varchar(255) NULL UNIQUE,
	vkToken varchar(255),
	vkExpires datetime,
	fbId varchar(255) NULL UNIQUE,
	fbToken varchar(255),
	fbExpires datetime
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
DROP Table IF EXISTS Users;
CREATE TABLE Users (
	Id INTEGER PRIMARY KEY,
	Created TIMESTAMP default CURRENT_TIMESTAMP,

	Name varchar(255),
	Email varchar(255) NOT NULL UNIQUE,
	Password varchar(255) NOT NULL,
  
	Token varchar(255) UNIQUE,
  
	vkId varchar(255) UNIQUE,
	vkToken varchar(255),
	vkExpires datetime,
	fbId varchar(255) UNIQUE,
	fbToken varchar(255),
	fbExpires datetime
);

CREATE UNIQUE INDEX Email ON Users (
    Email
);

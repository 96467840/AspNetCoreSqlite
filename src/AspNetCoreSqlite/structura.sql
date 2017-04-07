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

	IsDefault tinyint default 0,
	IsVisible tinyint default 0,
	
	Name varchar(255),
	URL varchar(512),
	Description text,
	Layout varchar(128),

	Contacts text,
	ContactsShort text,

	YandexMetrika varchar(128),
	GoogleanAlytics varchar(128),

	Share42 tinyint DEFAULT 0,
	IsDeleted tinyint NOT NULL DEFAULT 0,
	VkAppId varchar(255) DEFAULT NULL,
	VkAppSecret varchar(255) DEFAULT NULL,
	FbAppId varchar(255) DEFAULT NULL,
	FbAppSecret varchar(255) DEFAULT NULL,
	FbNamespace varchar(255) DEFAULT NULL,
	RecaptchaSiteKey varchar(255) DEFAULT NULL,
	RecaptchaSecretKey varchar(255) DEFAULT NULL,
	Template varchar(50) DEFAULT NULL,
--	OrderPageId INTEGER DEFAULT NULL,
--	E404PageId INTEGER DEFAULT NULL,
	ExternalId varchar(100) DEFAULT NULL,
	Favicon varchar(255) DEFAULT NULL
);

CREATE TABLE UserSites(
	UserId INTEGER NOT NULL,
	SiteId INTEGER NOT NULL,
	
	Rights text,
	PRIMARY KEY(UserId,SiteId),
	FOREIGN KEY(SiteId) REFERENCES Sites(Id) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY(UserId) REFERENCES Users(Id) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Menus (
  Id INTEGER PRIMARY KEY,
  Created TIMESTAMP default CURRENT_TIMESTAMP,
  SiteId INTEGER NOT NULL,
  ParentId INTEGER NULL DEFAULT NULL,
  Page varchar(255) NOT NULL DEFAULT '',
  MenuName varchar(255) NOT NULL DEFAULT '',
  Name varchar(255) NOT NULL DEFAULT '',
  Priority SMALLINT NOT NULL DEFAULT 0,
  IsBlocked tinyint NOT NULL DEFAULT 0,
  ShowSubmenu tinyint DEFAULT 0,
  ShowInTop tinyint DEFAULT 1,
  ShowInBottom tinyint DEFAULT 0,
  ShowInMenu tinyint DEFAULT 1,
  Content text,
  SeoTitle varchar(255) DEFAULT '',
  SeoKeywords varchar(1024) DEFAULT '',
  SeoDescription varchar(1024) DEFAULT '',
  URL varchar(255) NOT NULL DEFAULT '',
  Layout varchar(128) DEFAULT NULL,
--  ArticlesId INTEGER DEFAULT NULL,
  InWWW tinyint DEFAULT 1,
  InVk tinyint DEFAULT 1,
  InFb tinyint DEFAULT 1,
  ShowNews tinyint DEFAULT 0,
  ShowLeftMenu tinyint DEFAULT 1,
  Lang varchar(17) DEFAULT NULL,
--  GalleryId INTEGER DEFAULT NULL,
--  FaqsId INTEGER DEFAULT NULL,
--  FormId INTEGER DEFAULT NULL,
  CSS text,
  BodyCSS text,
  ImageLogo varchar(255) DEFAULT NULL,
  ImageLogoRight varchar(255) DEFAULT NULL,
  Search text,
  Description varchar(1024) NOT NULL DEFAULT '',
  IsSeparatedFaqs tinyint DEFAULT 0,
  ExternalId varchar(100) DEFAULT NULL,
  ImageOnMain varchar(255) DEFAULT NULL,
  IsShowOnMain tinyint DEFAULT 0,
  ShortContent text,
  
  FOREIGN KEY(SiteId) REFERENCES Sites(Id) ON UPDATE CASCADE ON DELETE CASCADE,
  FOREIGN KEY(ParentId) REFERENCES Menus(Id) ON UPDATE CASCADE ON DELETE CASCADE
);

alter table Sites Add OrderPageId INTEGER REFERENCES Menus(Id) ON UPDATE CASCADE ON DELETE SET NULL;
alter table Sites Add E404PageId  INTEGER REFERENCES Menus(Id) ON UPDATE CASCADE ON DELETE SET NULL;


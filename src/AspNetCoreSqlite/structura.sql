CREATE TABLE Users (
	Id INTEGER PRIMARY KEY,
	Created TIMESTAMP default CURRENT_TIMESTAMP,

	Name varchar(255),
	Email varchar(255) NOT NULL,
	Password varchar(255) NOT NULL,
  
	Token varchar(255) NULL,
  
	VkId varchar(255) NULL,
	VkToken varchar(255),
	VkExpires datetime,
	FbId varchar(255) NULL,
	FbToken varchar(255),
	FbExpires datetime
);

CREATE UNIQUE INDEX Users_Email ON Users ( Email );
CREATE UNIQUE INDEX Users_VkId ON Users (VkId);
CREATE UNIQUE INDEX Users_FbId ON Users (FbId);
CREATE UNIQUE INDEX UsersToken ON Users ( Token );

-- insert into Users (Name, Email, Password) values ('Andrey', '96467840@mail.ru', '');

CREATE TABLE Sites (
	Id INTEGER PRIMARY KEY,
	Created TIMESTAMP default CURRENT_TIMESTAMP,

	IsDefault tinyint NOT NULL default 0,
	IsVisible tinyint NOT NULL default 0,
	
	Name varchar(255),
	Hosts text,
	Description text,
	Layout varchar(128),

	Contacts text,
	ContactsShort text,

	YandexMetrika varchar(128),
	GoogleanAlytics varchar(128),

	Share42 tinyint NOT NULL DEFAULT 0,
	IsDeleted tinyint NOT NULL DEFAULT 0,
	VkAppId varchar(255) DEFAULT NULL,
	VkAppSecret varchar(255) DEFAULT NULL,
	FbAppId varchar(255) DEFAULT NULL,
	FbAppSecret varchar(255) DEFAULT NULL,
	FbNamespace varchar(255) DEFAULT NULL,
	RecaptchaSiteKey varchar(255) DEFAULT NULL,
	RecaptchaSecretKey varchar(255) DEFAULT NULL,
	Template varchar(50) DEFAULT NULL,
	OrderPageId INTEGER DEFAULT NULL,
	E404PageId INTEGER DEFAULT NULL,
	ExternalId varchar(100) DEFAULT NULL,
	Favicon varchar(255) DEFAULT NULL
);
-- CREATE INDEX Sites_IsDefault ON Sites ( IsDefault );
-- CREATE INDEX Sites_Host ON Sites ( Host );
CREATE INDEX Sites_VkAppId ON Sites ( VkAppId );
CREATE INDEX Sites_FbAppId ON Sites ( FbAppId );
CREATE INDEX Sites_ExternalId ON Sites ( ExternalId );

CREATE TABLE UserSites(
	UserId INTEGER NOT NULL,
	SiteId INTEGER NOT NULL,
	IsAdmin tinyint NOT NULL default 0,
	Rights text,
	PRIMARY KEY(UserId, SiteId),
	FOREIGN KEY(SiteId) REFERENCES Sites(Id) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY(UserId) REFERENCES Users(Id) ON UPDATE CASCADE ON DELETE CASCADE
);
CREATE INDEX UserSites_IsAdmin ON UserSites ( IsAdmin );

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
  ShowSubmenu tinyint NOT NULL DEFAULT 0,
  ShowInTop tinyint NOT NULL DEFAULT 1,
  ShowInBottom tinyint NOT NULL DEFAULT 0,
  ShowInMenu tinyint NOT NULL DEFAULT 1,
  Content text,
  SeoTitle varchar(255) DEFAULT '',
  SeoKeywords varchar(1024) DEFAULT '',
  SeoDescription varchar(1024) DEFAULT '',
  URL varchar(512) NOT NULL DEFAULT '',
  Layout varchar(128) DEFAULT NULL,
--  ArticlesId INTEGER DEFAULT NULL,
  InWWW tinyint NOT NULL DEFAULT 1,
  InVk tinyint NOT NULL DEFAULT 1,
  InFb tinyint NOT NULL DEFAULT 1,
  ShowNews tinyint NOT NULL DEFAULT 0,
  ShowLeftMenu tinyint NOT NULL DEFAULT 1,
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
  IsSeparatedFaqs tinyint NOT NULL DEFAULT 0,
  ExternalId varchar(100) DEFAULT NULL,
  ImageOnMain varchar(255) DEFAULT NULL,
  IsShowOnMain tinyint NOT NULL DEFAULT 0,
  ShortContent text,
  
--  FOREIGN KEY(SiteId) REFERENCES Sites(Id) ON UPDATE CASCADE ON DELETE CASCADE,
  FOREIGN KEY(ParentId) REFERENCES Menus(Id) ON UPDATE CASCADE ON DELETE SET NULL
);

-- мы не будем связывать таблицы  Sites и Users с другими таблицами так как поместим их в отдельную БД
-- alter table Sites Add OrderPageId INTEGER REFERENCES Menus(Id) ON UPDATE CASCADE ON DELETE SET NULL;
-- alter table Sites Add E404PageId  INTEGER REFERENCES Menus(Id) ON UPDATE CASCADE ON DELETE SET NULL;

CREATE INDEX Menus_SiteId ON Menus ( SiteId );
CREATE INDEX Menus_ParentId ON Menus ( ParentId );
CREATE INDEX Menus_Page ON Menus ( Page );
CREATE INDEX Menus_Priority ON Menus ( Priority );
CREATE INDEX Menus_IsBlocked ON Menus ( IsBlocked );
CREATE INDEX Menus_ExternalId ON Menus ( ExternalId );
CREATE INDEX Menus_IsShowOnMain ON Menus ( IsShowOnMain );
-- CREATE INDEX Menus_??? ON Menus ( ??? );

CREATE TABLE News (
  ID INTEGER PRIMARY KEY,

  SiteId integer NOT NULL,

  Name varchar(512) NOT NULL default '',
  Description varchar(1024) NOT NULL default '',
  Content text,
  Date datetime,

  IsBlocked tinyint NOT NULL DEFAULT 0,
  InWWW tinyint NOT NULL DEFAULT 1,
  InVk tinyint NOT NULL DEFAULT 1,
  InFb tinyint NOT NULL DEFAULT 1,

  Page varchar(255) NOT NULL DEFAULT '',
  Image varchar(255) NOT NULL DEFAULT '',
--  GalleryId INTEGER DEFAULT NULL,
  Search text,
  SeoTitle varchar(255) DEFAULT '',
  SeoKeywords varchar(1024) DEFAULT '',
  SeoDescription varchar(1024) DEFAULT '',
  ExternalId varchar(100) DEFAULT NULL
);

-- CREATE INDEX News_ ON News ( );
CREATE INDEX News_SiteId ON News ( SiteId );
CREATE INDEX News_Page ON News ( Page );
CREATE INDEX News_Date ON News ( Date );
CREATE INDEX News_IsBlocked ON News ( IsBlocked );
CREATE INDEX News_ExternalId ON News ( ExternalId );

/*CREATE DATABASE SocialMedia;
use SocialMedia;*/
CREATE TABLE Users(
	id int IDENTITY(1,1) PRIMARY KEY,
	name varchar(50) NOT NULL,
	email varchar(50) UNIQUE,
	password VARCHAR(50) NOT NULL,
	gender varchar(20) NOT NULL,
	location varchar(20) NOT NULL,
	role varchar(20) DEFAULT 'member',
	dob DATETIME NOT NULL,
	bio VARCHAR(100) NULL,
	image VARCHAR(30) NULL
);
CREATE TABLE Posts (
	id int IDENTITY(1,1) PRIMARY KEY,
	user_id int NOT NULL FOREIGN KEY REFERENCES Users(id),
	post_at DATETIME NOT NULL,
	text_post VARCHAR(500) NOT NULL,
	options VARCHAR(20) NOT NULL,
	edited_at DATETIME NULL,
);
CREATE TABLE Librarys(
	id int IDENTITY(1,1) PRIMARY KEY,
	user_id int NOT NULL FOREIGN KEY REFERENCES Users(id),
	post_id int NULL FOREIGN KEY REFERENCES Posts(id),
	image varchar(30),
	date DATETIME NOT NULL
);


CREATE TABLE Reactions (
	id int IDENTITY(1,1) PRIMARY KEY,
	user_id int NOT NULL FOREIGN KEY REFERENCES Users(id),
	post_id int NOT NULL FOREIGN KEY REFERENCES Posts(id),
	type_reaction int NOT NULL
);
CREATE TABLE Comments (
	id int IDENTITY(1,1) PRIMARY KEY,
	user_id int NOT NULL FOREIGN KEY REFERENCES Users(id),
	post_id int NOT NULL FOREIGN KEY REFERENCES Posts(id),
	post_cmt DATETIME NOT NULL,
	comment VARCHAR(100) NOT NULL,
)

--Create database adonettask
--use adonettask
CREATE TABLE Users
(
	id int identity primary key,
	Name nvarchar(60),
	Surname nvarchar(60),
	Password nvarchar(256) not null
);
Alter table users
add UserName nvarchar(60) not null unique
drop table Users
CREATE TABLE Blogs
(
	id int identity primary key,
	Title nvarchar(30),
	Description nvarchar(250),
	UserId int REFERENCES Users(id) not null
);

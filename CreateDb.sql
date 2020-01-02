--Use master
--DROP DATABASE CompanyDB
--GO

Create Database CompanyDB
Go

Use CompanyDB
Go

CREATE TABLE Users
(
	userID int primary key identity (1,1) NOT NULL,
	firstName NVARCHAR(50) NOT NULL,
	lastName NVARCHAR(50) NOT NULL,
	dateOfBirth DATE NOT NULL,
	username NVARCHAR(50) NOT NULL,
	passwd NVARCHAR(50) NOT NULL,
	role_id INT NOT NULL,
	isDeleted BIT NOT NULL
)
Insert into Users(firstName,lastName,dateOfBirth,username,passwd,role_id,isDeleted) values ('Adam','Wojdyla','1999-07-07','Adelionek','Adam1234',1,0)
Insert into Users(firstName,lastName,dateOfBirth,username,passwd,role_id,isDeleted) values ('Jace','Wojdyla','1964-02-07','jacolek64','Adam1234',1,0)
Insert into Users(firstName,lastName,dateOfBirth,username,passwd,role_id,isDeleted) values ('Marek','Kowalski','1998-01-07','marcus','Adam1234',2,0)
Insert into Users(firstName,lastName,dateOfBirth,username,passwd,role_id,isDeleted) values ('Kuba','Michalski','1997-05-12','kuba420','Adam1234',2,0)
Insert into Users(firstName,lastName,dateOfBirth,username,passwd,role_id,isDeleted) values ('Jacek','Milnicki','1999-11-17','jacol22','Adam1234',2,0)
Insert into Users(firstName,lastName,dateOfBirth,username,passwd,role_id,isDeleted) values ('Wojtek','Rajecki','1999-10-27','wojtek99','Adam1234',2,0)


CREATE TABLE Companies
(
	companyID int primary key identity (1,1) NOT NULL,
	companyName NVARCHAR(50) NOT NULL,
	NIP NVARCHAR(10) NOT NULL,
	trade_id INT NOT NULL,
	companyAddress NVARCHAR(100) NOT NULL,
	city NVARCHAR(50) NOT NULL,
	isDeleted BIT NOT NULL,
	userID INT FOREIGN KEY REFERENCES Users(userID)
)

Insert into Companies values ('PolBud','7821345526',1,'Graniczna 22','Poznan',0,1)
Insert into Companies values ('MediaRobot','7812456654',1,'Wroclawska 5','Warszawa',0,1)
Insert into Companies values ('EuroTrans','7812412354',1,'Moliera 10','Poznan',0,3) 
Insert into Companies values ('PolTraw','7422456654',1,'Warszawska 10','Gliwice',0,4) 

 

CREATE TABLE Note
(
	noteID int primary key identity (1,1) NOT NULL,
	noteName NVARCHAR(200) NOT NULL,
	isDeleted BIT NOT NULL,
	companyID INT FOREIGN KEY REFERENCES Companies(companyID),
	userID INT FOREIGN KEY REFERENCES Users(userID)
)
Insert into Note values ('Notatka1',0,1,1)


Create Table ContactPerson
(
	contactPersonID int primary key identity (1,1) NOT NULL,
	firstName NVARCHAR(50) NOT NULL,
	lastName NVARCHAR(50) NOT NULL,
	phone NVARCHAR(10) NOT NULL,
	email NVARCHAR(50) NOT NULL,
	position NVARCHAR(50) NOT NULL,
	companyID INT FOREIGN KEY REFERENCES Companies(companyID),
	userID INT FOREIGN KEY REFERENCES Users(userID),
	isDeleted BIT NOT NULL
)

Insert into ContactPerson values ('Adam','Wojdyla','513070891','adam@mail.com','CEO',1,1,0)


CREATE TABLE Roles
(
	roleID int primary key identity (1,1) NOT NULL,
	roleName NVARCHAR(50) NOT NULL
)
insert into Roles values ('Administrator')
insert into Roles values ('User')

CREATE TABLE Trade
(
	tradeID int primary key identity (1,1) NOT NULL,
	tradeName NVARCHAR(50) NOT NULL
)
insert into Trade values ('Construction')
insert into Trade values ('Car')

SELECT * FROM Companies
SELECT * FROM Users
SELECT * FROM ContactPerson
SELECT * FROM Note
SELECT * FROM Roles
SELECT * FROM Trade

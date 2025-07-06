CREATE DATABASE ContactsDB;

go

USE ContactsDB;

go

EXEC sp_changedbowner sa

go

CREATE TABLE Contacts(
	ContactId int IDENTITY(1,1) ,
	ContactName NVARCHAR(50) ,
	ContactLastName NVARCHAR(50) ,
	ContactPhone NVARCHAR(12) ,
	ContactEmail NVARCHAR (100) NULL
	);

go

INSERT INTO Contacts(ContactName , ContactLastName , ContactPhone , ContactEmail)
	VALUES ('Amin' , 'Ghasemi', '09102303756' , 'aminghasemi@yahoo.com'),
	       ('mohammad' , 'mohammady' ,'09120443416' ,'mohammad@gmail.com'),
		   ('Mel' , 'Moradi', '09301542318' , 'Rebecca@gmail.com')

go

SELECT * FROM Contacts;


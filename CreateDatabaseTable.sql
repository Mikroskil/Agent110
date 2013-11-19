CREATE DATABASE Laboratorium
ON (NAME = Laboratorium_dat, FILENAME = 'D:\kuliah\SEM V\PKTI\Agent110', SIZE= 10, MAXSIZE = Unlimited, FILEGROWTH = 5)
LOG ON (NAME = Laboratorium_log, FILENAME = 'D:\kuliah\SEM V\PKTI\Agent110', SIZE= 8, MAXSIZE = 50, FILEGROWTH = 1)

USE Laboratorium;
Create Table Admin
(
	ID Varchar (5),
	Nama Varchar (30),
	Pass Varchar (10)	
)

USE Laboratorium;
Create Table Client
(
	Nim Varchar (9),
	Pass Varchar (10)	
)

USE Laboratorium;
Create Table MonitorClient
(
	NoPC Varchar (5),
	Tanggal Varchar (30),
		
)
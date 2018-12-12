# H1Projekt

create database BKbase

use BKbase

create table kunde
(
ID int identity (1,1) primary key,
Fornavn varchar (25) not null,
Efternavn varchar (25) not null,
Adresse varchar (30) not null,
Email varchar (50),
Oprettelsesdato datetime default (getdate())
)

create table bil
(
ID int identity primary key,
Oprettelsesdato datetime default getdate(),
Maerke varchar (30) not null,
Model varchar (25) not null,
Aargang int not null,
Registreringsnummer varchar (7) not null,
Kilometer int not null,
BraendstoftypeID int,
KundeID int foreign key (KundeID) references kunde (ID)
)

create table Braendstoftype
(
ID int identity primary key,
Type varchar (15) 
)

insert into Braendstoftype values 
('Benzin'),
('El'),
('Diesel'),
('Hybrid')

create table Vaerkstedsbesoeg
(
ID int identity primary key,
Aftaletidspunkt datetime not null,
BilID int not null foreign key (BilID) references Bil(ID),
Pris decimal not null,
)

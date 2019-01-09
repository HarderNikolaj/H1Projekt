use master
go 
drop database BKbase 
go

create database BKbase 
go

use BKbase 
go

create table kunde ( ID int identity (1,1) primary key, Fornavn varchar (25) not null, Efternavn varchar (25) not null, Adresse varchar (30) not null, Email varchar (50), Oprettelsesdato datetime default (getdate()) )

create table bil ( ID int identity primary key, Oprettelsesdato datetime default getdate(), Maerke varchar (30) not null, Model varchar (25) not null, Aargang int not null, Registreringsnummer varchar (7) not null, Kilometer int not null, BraendstoftypeID int, KundeID int foreign key (KundeID) references kunde (ID) on delete cascade)

create table Vaerkstedsbesoeg ( ID int identity primary key, Aftaletidspunkt datetime not null, BilID int not null foreign key (BilID) references Bil(ID) on delete cascade, Pris decimal not null, )

insert into kunde (fornavn, efternavn, adresse, email) values ('Gorm d.','Gamle','Vikingevej 22','gorm@mail.dk'),('Harald','Blaatand','Hovedgaden 3','harald@bluetooth.com'), ('Leif','den Lykkelige','Telefgrafvej 9','ll@mail.com')

insert into bil (maerke, model, aargang, registreringsnummer, kilometer, BraendstoftypeID, kundeid) values ('Skoda','City GO',2005,'jp12345',25000,1,1), ('Skoda','Octavia',2010,'ko23654',100000,1,2), ('Fiat','Panda',2008,'ja22551',30000,1,3), ('Fiat','Panda',2010,'ja22552',80000,1,3)
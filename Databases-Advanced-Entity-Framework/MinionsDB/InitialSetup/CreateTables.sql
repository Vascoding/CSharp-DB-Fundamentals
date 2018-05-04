use MinionsDB

create table Countries(
Id int primary key,
Name varchar(50))

create table Towns(
Id int primary key,
Name varchar(50),
CountryId int,
constraint fk_CountryId foreign key (CountryId) references Countries(Id))

create table Minions(
Id int primary key,
Name varchar(50),
Age int,
TownId int,
constraint fk_TownId foreign key (TownId) references Towns(Id))

create table Villains(
Id int primary key,
Name varchar(50),
Evilnessfactor varchar(15) check (Evilnessfactor in ('good', 'bad', 'evil', 'super evil')))

create table MinionsVillains(
MinionId int,
VillainId int,
constraint pk_Minions_Villains_ids primary key (MinionId, VillainId),
constraint fk_MinionsId foreign key (MinionId) references Minions (Id),
constraint fk_VillainId foreign key (VillainId) references Villains (Id))
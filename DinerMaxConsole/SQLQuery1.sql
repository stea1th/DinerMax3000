--drop table test;
drop table Menu_MenuItem;
drop table Menu;
drop table MenuItem;
drop sequence global_seq;


create sequence global_seq
    start with 1
    increment by 1;

create table MenuItem (
Id int primary key identity(1, 1),
Name varchar(100) not null default '',
Description text not null default '',
Price float not null default 0
);

create table Menu (
Id int primary key identity(1, 1),
Name varchar(50) not null default '',
MenuType varchar(50) not null default '',
Disclaimer varchar(200) not null default '',
HospitalDirections varchar(200) not null default ''
);

create table Menu_MenuItem (
Id int primary key identity(1, 1),
MenuId int foreign key references Menu(Id),
MenuItemId int foreign key references MenuItem(Id)
);

insert into Menu (Name, MenuType, Disclaimer, HospitalDirections) values 
('Summer menu', 'food', '', 'Hauptstr 5 .Herr Schmidt fragen');

insert into MenuItem (Name, Description, Price) values
('Schnitzel', 'Mit Kartoffelsalat', 10.95),
('Wiener', 'Mit Pommes', 4.59);

insert into Menu_MenuItem (MenuId, MenuItemId) values
(1, 1),
(1, 2);

select * from MenuItem mi 
join Menu_MenuItem mmi on mi.Id = mmi.MenuItemId 
join Menu m on mmi.MenuId = m.Id 
where m.Id = 1

select * from MenuItem mi 
where mi.Price = (select MAX(mix.Price) from MenuItem mix)





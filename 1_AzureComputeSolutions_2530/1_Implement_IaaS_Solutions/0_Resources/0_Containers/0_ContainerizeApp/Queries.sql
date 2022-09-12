CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY (1, 1),
    ProductName VARCHAR (50) NOT NULL,
    Quantity INT NULL
);

insert into Products (ProductName, Quantity)
values ('Car', 50)

insert into Products (ProductName, Quantity)
values ('Tira', 51)

insert into Products (ProductName, Quantity)
values ('Pushi', 23)

select * from Products
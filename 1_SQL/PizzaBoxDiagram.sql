use master;
go

--create
create database PizzaBox;
go

-- create schema [Account];
-- go

use PizzaBox;
go

create schema [Order];
go
create table [Order].[Order]
(
    OrderId int not null identity(1,2)  --primary key
    ,UserId int not null                -- foreign key references Account.User.UserId
    ,StoreId int not null               -- foreign key
    ,TotalCost decimal(3,2) not null    -- checked constraint
    ,OrderDate datetime2(7)             -- computed, checked constraint
    ,Active bit not null                -- default
    -- ,constraint PK_Order_OrderId primary key (OrderId)
    -- ,constraint FK_Order_UserId foreign key (UserId) references Account.User(UserId)
)
create table [Order].[OrderPizza]
(
    OrderPizzaId int not null identity(1,2)
    ,OrderId int not null 
    ,PizzaId int not null 
)
create table [Order].[Pizza]
(
    PizzaId int not null identity(1,2)  --primary
    -- 3nf for toppings, cheese bc they can both exist without the other, plus toppings are many, which means something between them
    ,SizeId int not null               --foreign
    ,CrustId int not null              --foreign
    ,SauceId int not null 
    ,CheeseId int not null 
    ,Price decimal(3,2) not null
    ,ToppingsId varchar 
    ,Active bit not null
)
CREATE table [Order].[Toppings] (
  ToppingsId int identity(1,1)
  ,Toppings nvarchar(255)
  --'sausage', 'bellpeppers', 'ham', 'pepperoni', 'pineapple'
)
CREATE table [Order].[Size] (
  SizeId int not null identity(1,2)
  ,price int 
  ,Size nvarchar(255) not null
)
CREATE table [Order].[Sauce] (
  SauceId int not null identity(1,1)
  ,Sauce nvarchar(255) not null
  --'tomato', 'bbq', 'buffalo', 'pesto', 'alfredo'
)
CREATE table [Order].[Crust] (
  [CrustId] int not null identity(1,1)
  ,[Crust] nvarchar(255) not null
  --'thin', 'regular', 'pan'
)
CREATE table [Order].[Cheese] (
  [CheeseId] int not null identity(1,1)
  ,[Cheese] nvarchar(255) not null
  --'thin', 'regular', 'pan'
)
go

create schema [User];
go
CREATE table [User].[User] (
  UserId int not null identity(1, 2)
  ,FirstName nvarchar(255) not null
  ,LastName nvarchar(255) not null
  ,UTId int not null
  ,AddressId int not null 
  ,AccountId int not null
  ,created_at datetime DEFAULT (GETDATE()) not null
)
CREATE table [User].[UserType] (
  UTId int not null identity(1, 1)
  ,[Type] nvarchar(255) not null
)
go

CREATE table [User].[Account] (
  AccountId int not null identity(1,2)
  ,username nvarchar(255) not null
  ,[password] nvarchar(255) not null
)
go



create schema [Address];
go 
CREATE table [Address].[Address] (
  AddressId int not null identity(1, 1)
  ,Street nvarchar(255) not null
  ,Zipcode int not null 
  ,City nvarchar(255) not null 
  ,[state] nvarchar(255) not null
  ,AddressTypeId int not null
)


CREATE table [Address].[AddressType] (
  AddressTypeId int not null identity(1, 1)
  ,[Type] nvarchar(255) not null
)
go

create schema [Store];
go
CREATE table [Store].[Store] (
  StoreId int not null identity(1, 2)
  ,TotalSales decimal not null
  ,AddressId int not null
)
go






alter table [Order].[Order]
    add constraint PK_Order_OrderId primary key (OrderId);
alter table [Order].[OrderPizza]
    add constraint PK_Order_OrderPizzaId primary key (OrderPizzaId);
alter table [Order].[Pizza]
    add constraint PK_Order_PizzaId primary key (PizzaId);
alter table [Order].[Toppings]
    add constraint PK_Order_ToppingsId primary key (ToppingsId);
alter table [Order].[Size]
    add constraint PK_Order_SizeId primary key (SizeId);
alter table [Order].[Sauce]
    add constraint PK_Order_SauceId primary key (SauceId);
alter table [Order].[Crust]
    add constraint PK_Order_CrustId primary key (CrustId);
alter table [User].[User]
    add constraint PK_User_UserId primary key (UserId);
alter table [User].[UserType]
    add constraint PK_User_UTId primary key (UTId);
alter table [User].[Account]
    add constraint PK_User_AccountId primary key (AccountId);
alter table [Address].[Address]
    add constraint PK_Address_AddressId primary key (AddressId);
alter table [Address].[AddressType]
    add constraint PK_Address_AddressTypeId primary key (AddressTypeId);
alter table [Store].[Store]
    add constraint PK_Store_StoreId primary key (StoreId)
alter table [Order].[Cheese]
    add constraint PK_Order_CheeseId primary key (CheeseId);


alter table [Order].[OrderPizza]
    add constraint FK_OrderPizza_OrderId foreign key (OrderId) references [Order].[Order](OrderId);
alter table [Order].[OrderPizza]
    add constraint FK_OrderPizza_PizzaId foreign key (PizzaId) references [Order].[Pizza](PizzaId);
alter table [Order].[Order]
    add constraint FK_Order_UserId foreign key (UserId) references [User].[User](UserId);
alter table [Order].[Order]
    add constraint FK_Order_StoreId foreign key (StoreId) references [Store].[Store](StoreId);
alter table [Order].[Pizza]
    add constraint FK_Order_SizeId foreign key (SizeId) references [Order].[Size](SizeId);
alter table [Order].[Pizza]
    add constraint FK_Order_CrustId foreign key (CrustId) references [Order].[Crust](CrustId);
alter table [Order].[Pizza]
    add constraint FK_Order_SauceId foreign key (SauceId) references [Order].[Sauce](SauceId);
alter table [Order].[Pizza]
    add constraint FK_Order_CheeseId foreign key (CheeseId) references [Order].[Cheese](CheeseId);
alter table [Order].[Pizza]
    add constraint FK_Order_ToppingsId foreign key (ToppingsId) references [Order].[Toppings](ToppingsId);

alter table [User].[User]
    add constraint FK_User_UTId foreign key (UTId) references [User].[UserType](UTId);
alter table [User].[User]
    add constraint FK_User_AddressId foreign key (AddressId) references [Address].[Address](AddressId);
alter table [User].[User]
    add constraint FK_User_AccountId foreign key (AccountId) references [User].[Account](AccountId);

alter table [Address].[Address]
    add constraint FK_Address_AddressTypeId foreign key (AddressTypeId) references [Address].[AddressType](AddressTypeId);
alter table [Store].[Store]
    add constraint FK_Store_AddressId foreign key (AddressId) references [Address].[Address](AddressId);







insert into [User].UserType(Type)
values('customer'),('employee');
go

insert into [Address].AddressType(Type)
values('store'),('residential');
go

insert into [Address].Address(Street, Zipcode, City, [state], AddressTypeId)
values('1234 Mitchell Ave', 55057, 'Arlington', 'TX', 2);
go

select * from [Address].[AddressType]
go

select * from [User].[User]
go

select * from [User].[Account]
go

select * from [Order].[Crust]
go

insert into [User].[Account](username, [password])
values ('jimmy', 'password');
go

DELETE FROM [PizzaBox].[User].[User]    
    WHERE FirstName='Jimmy';
    go  






--stored procedure
create procedure sp_InsertUser(@first nvarchar(50), @last nvarchar(50), @utid int, @addressid int, @accountid int)
as 
begin
    begin TRANSACTION
        begin try 
            insert into [User].[UserType](FirstName, LastName, UTId, AddressId, AccountId)


            insert into [PizzaBox].[User].[User](FirstName, LastName, UTId, AddressId, AccountId)
            values (
            @first 
            ,@last 
            ,UTId (select UTId from [User].[UserType]
            where Type='customer')
            ,(select AddressId from [Address].[Address]
            where AddressId=count(*))
            ,(select AccountId from [User].[Account]
            where AccountId=count(*))
            );
go


--populate Pizza properties.
insert into [PizzaBox].[Order].[Sauce](Sauce)
values ('Alfredo'), ('Tomato'), ('Pesto');

insert into [PizzaBox].[Order].[Size](Size)
values ('Small'), ('Medium'), ('Large');

insert into [PizzaBox].[Order].[Crust](Crust)
values ('Thin'), ('Regular'), ('Pan');

insert into [PizzaBox].[Order].[Cheese](Cheese)
values ('Regular');
go
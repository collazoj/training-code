use master;
go

--create
create database PizzaBox;
go

use PizzaBox;
go

create schema [Order];
go

create schema Account;
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
    ,SizeId int not null                --foreign
    ,CrustId int not null               --foreign
    ,Price decimal(2,2) not null
    ,Active bit not null
)

--alter
alter table[Order].[Order]    
    add constraint PK_Order_OrderId primary key (OrderId);
alter table[Order].[OrderPizza]    
    add constraint PK_OrderPizza_OrderPizzaId primary key (OrderPizzaId);
alter table[Order].[Pizza]    
    add constraint PK_Pizza_PizzaId primary key (PizzaId);

alter table[Order].[OrderPizza]
    add constraint FK_OrderPizza_OrderId foreign key (OrderId) references [Order].[order](OrderId);
alter table[Order].[OrderPizza]
    add constraint FK_OrderPizza_PizzaId foreign key (PizzaId) references [Order].[Pizza](PizzaId);

alter table[Order].[Order]
    add constraint DF_Order_Active default (1) for Active;

alter table[Order].[Pizza]
    add constraint DF_Pizza_Active default (1) for Active;
alter table[Order].[Order]
    add constraint CK_Order_TotalCost check (TotalCost < 500);
alter table[Order].[Order]
    add constraint CK_Order_OrderDate check (OrderDate > '2019-11-11'); --if you put in anything before this day, it will reject bc that doesn't make sense

alter table[Order].[Order]
    drop constraint CK_Order_OrderDate;

alter table [Order].[Order]
    add TipAmount decimal(2,2) null;

-- alter table [Order].[Order]
--     drop column TipAmount;

-- drop: delete all records and the structure of those records
drop table [Order].[OrderPizza];

-- truncate
truncate table [Order].[OrderPizza];


use AdventureWorks2017;
go

create database AdventureWorks;
go

-- view
create view vw_Person with schemabinding
as 
select firstname, lastname
from Person.Person;
go

select * from vw_Person;
go


-- function
create function fn_Person(@first nvarchar(50))
returns table -- gives the return type
as 
return -- returns the thing
select firstname, lastname
from Person.Person
where FirstName = @first;
go

create function fn_FullName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50))
returns nvarchar(200)
as 
begin
    --return @first + ' ' + @middle + ' ' + @last
    return @first + coalesce(' '+@middle, '', null, null) + ' ' + @last -- checks first in the list that is not null
    -- return @first + isnull(isnull(isnull(' '+@middle, ''), null), null) + ' ' + @last 
end;
go

select dbo.fn_FullName(firstname, null, lastname) from fn_Person('joshua');
go


--stored procedure
create procedure sp_InsertName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50)) --if there is data that is null, I am inserting blank rather than null.
as
begin
    begin TRANSACTION
        begin try
            declare @mname nvarchar(50) = @middle

            if(@middle is null)
            begin
                set @mname = ''
            end

            CHECKPOINT          -- saves at this point, but not ACID. DBAs are not big fans of this

            insert into Person.Person(FirstName, LastName, MiddleName)
            values (@first, @last, @mname);     --read uncommitted. If read at this point, you may read these names

            commit TRANSACTION
        end try

    begin catch
        
        print error_message()   
        print error_severity()  --user/database generate. level within state
        print error_state()     --internal or external error
        print error_number()  
        rollback TRANSACTION      
    end catch
end;

execute sp_InsertName 'fred', null, 'belotte';  --used to customize transactions
GO

-- trigger
create trigger tr_InsertName    --if event happens to be INSERT, change to...
on Person.Person 
instead of INSERT
as 
UPDATE pp
set firstname = inserted.firstname
select FirstName
from Person.Person as pp
where pp.BusinessEntityID = inserted.BusinessEntityID;  --inserted table is clone. if committed, record is flipped

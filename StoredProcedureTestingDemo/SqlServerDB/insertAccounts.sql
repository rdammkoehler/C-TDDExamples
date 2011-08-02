declare @checking uniqueidentifier;
set @checking = (select acctypeId from AccountType where typeName='Checking')

declare @savings uniqueidentifier;
set @savings = (select acctypeId from AccountType where typeName='Savings')

declare @justin uniqueidentifier;
set @justin = (select userId from [User] where userName='justin')

declare @sara uniqueidentifier;
set @sara = (select userId from [User] where userName = 'sara')

insert into Account (accountNum, accountType, userId) values ('1234', @checking, @justin)
insert into Account (accountNum, accountType, userId) values ('5678', @savings, @justin)
insert into Account (accountNum, accountType, userId) values ('9012', @checking, @sara)
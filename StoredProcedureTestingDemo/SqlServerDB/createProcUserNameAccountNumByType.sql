create procedure procUserNameAccountNumByType( @accountType varchar(50) ) as
set nocount on
set implicit_transactions off

declare @UserNameAccountNum table (
	userName varchar(50),
	accountNum varchar(50)
)

insert into @UserNameAccountNum (userName, accountNum) 
	(select u.userName, a.accountNum from [User] u, Account a, AccountType t where
		a.accountType=t.accTypeId and
		u.userId=a.userId and
		t.typeName=@accountType)
		
select userName, accountNum from @UserNameAccountNum order by userName
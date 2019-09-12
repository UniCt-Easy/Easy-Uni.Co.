if not exists(select * from finlookup)
Begin
	insert into finlookup(oldidfin, newidfin,ct,cu,lt,lu)
	select O.idfin, N.idfin,getdate(),'script',getdate(),'script'
	from fin O
	join fin N
		on O.codefin = N.codefin
		and (O.flag & 1) = (N.flag & 1)
		and O.ayear +1 = N.ayear	
End
GO
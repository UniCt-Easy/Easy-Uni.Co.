declare @r  cursor 

set @r = cursor for select kpay from payment order by kpay

declare @k int

open @r  
fetch next from @r into @k
while @@fetch_status = 0
begin
    print @k
	exec compute_payment_bank  @k
	fetch next from @r into @k
end

close @r
deallocate @r
	
go

declare @r  cursor 

set @r = cursor for select kpro from proceeds order by kpro

declare @k int

open @r  
fetch next from @r into @k
while @@fetch_status = 0
begin
    print @k
	exec compute_proceeds_bank  @k
	fetch next from @r into @k
end

close @r
deallocate @r

go
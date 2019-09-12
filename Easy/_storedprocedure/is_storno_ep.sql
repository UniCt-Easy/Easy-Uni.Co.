if exists (select * from dbo.sysobjects where id = object_id(N'[is_storno_ep ]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [is_storno_ep ]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'



CREATE   procedure is_storno_ep  (
@yvar smallint,
@nvar int,
@res int out
) as
BEGIN
	set @res=0
	if (select count(*) from accountvardetail where yvar=@yvar and nvar=@nvar)=0 return
	
	if (select sum(amount) from  accountvardetail where yvar=@yvar and nvar=@nvar)<>0 return

	if (select count(distinct idupb) from accountvardetail where yvar=@yvar and nvar=@nvar)<>1 return

	if (select count(*)  from accountvardetail 
			join account on account.idacc= accountvardetail.idacc
			where  yvar=@yvar and nvar=@nvar and account.flagaccountusage & 320 <>0) <>0
	begin
		--se c'è qualche costo o immobilizzazione, devono esserlo tutte
		if (select count(*)  from accountvardetail 
				join account on account.idacc= accountvardetail.idacc
				where yvar=@yvar and nvar=@nvar and account.flagaccountusage & 320 =0) <>0 begin
				return
		end
		set @res=1
		return
	end
	--altrimenti devono essere tutti dello stesso tipo
	if (select count(distinct account.flagaccountusage)  from accountvardetail 
			join account on account.idacc= accountvardetail.idacc
			where yvar=@yvar and nvar=@nvar  
			) >1 begin
		return
	end

	set @res=1 
				
END	
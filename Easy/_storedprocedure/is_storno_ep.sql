
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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

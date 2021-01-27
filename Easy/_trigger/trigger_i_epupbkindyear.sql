
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_epupbkindyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_epupbkindyear]
GO

CREATE TRIGGER [trigger_i_epupbkindyear] ON [epupbkindyear] FOR INSERT
AS BEGIN
	
	DECLARE @idepupbkind int
 	DECLARE @ayear int
	declare @idacc_cost varchar(38)
	declare @idacc_revenue varchar(38)
	declare @idacc_deferredcost varchar(38)
	declare @idacc_accruals varchar(38)
	declare @idacc_reserve varchar(38)
	SELECT 
	@idepupbkind = idepupbkind, 
	@idacc_cost = idacc_cost, 
	@idacc_revenue = idacc_revenue, 
	@idacc_deferredcost = idacc_deferredcost,
	@idacc_accruals = idacc_accruals,
	@idacc_reserve = idacc_reserve,
	@ayear = ayear
	FROM inserted

	if not exists (select * from account where ayear =@ayear+1) return
	if exists (select * from epupbkindyear where ayear =@ayear+1 and idepupbkind=@idepupbkind) return

	declare @new_idacc_cost varchar(38)
	declare @new_idacc_revenue varchar(38)
	declare @new_idacc_deferredcost varchar(38)
	declare @new_idacc_accruals varchar(38)
	declare @new_idacc_reserve varchar(38)

	

	select @new_idacc_cost = newidacc from accountlookup where oldidacc = @idacc_cost
	select @new_idacc_revenue = newidacc from accountlookup where oldidacc = @idacc_revenue
	select @new_idacc_deferredcost = newidacc from accountlookup where oldidacc = @idacc_deferredcost
	select @new_idacc_accruals = newidacc from accountlookup where oldidacc = @idacc_accruals
	select @new_idacc_reserve = newidacc from accountlookup where oldidacc = @idacc_reserve

 	insert into epupbkindyear (ayear,idepupbkind,idacc_cost,idacc_revenue,idacc_deferredcost,idacc_accruals,idacc_reserve,
								ct,cu,lt,lu) 
					values ( @ayear+1,@idepupbkind,@new_idacc_cost,@new_idacc_revenue,@new_idacc_deferredcost,
									@new_idacc_accruals,@new_idacc_reserve,
									getdate(),'trigger',getdate(),'trigger')

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


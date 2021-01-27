
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_upbyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_upbyear]
GO

CREATE TRIGGER [trigger_i_upbyear] ON [upbyear] FOR INSERT
AS BEGIN
	
	DECLARE @idupb varchar(36)
 	DECLARE @ayear int
	declare @revenueprevision decimal(19,2)
	declare @costprevision decimal(19,2)

	SELECT 
	@idupb = idupb, 
	@ayear = ayear, 
	@revenueprevision = revenueprevision, 
	@costprevision = costprevision
	FROM inserted

	if not exists (select * from account where ayear =@ayear+1) return
	if exists (select * from upbyear where ayear =@ayear+1 and idupb=@idupb) return


 	insert into upbyear (ayear,idupb,revenueprevision,costprevision,
								ct,cu,lt,lu) 
					values ( @ayear+1,@idupb,@revenueprevision,@costprevision,									
									getdate(),'trigger',getdate(),'trigger')

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


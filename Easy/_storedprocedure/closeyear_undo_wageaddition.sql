
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


--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_wageaddition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_wageaddition]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  procedure closeyear_undo_wageaddition(@esercizio int) as
begin
	DECLARE @nextayear int
	SET @nextayear = @esercizio + 1

	declare @eserccontratto int
	declare @numcontratto int
	declare @curscontratto cursor
	set @curscontratto = cursor for select ycon, ncon from wageaddition where ycon<=@esercizio 
		and  exists (select * from wageadditionyear where wageaddition.ycon=wageadditionyear.ycon 
		and wageaddition.ncon=wageadditionyear.ncon and ayear=@nextayear)
	open @curscontratto
	fetch next from @curscontratto into @eserccontratto, @numcontratto
	while @@fetch_status = 0 
		BEGIN
		PRINT @eserccontratto
		PRINT @numcontratto
	 		DELETE FROM wageadditionyear WHERE ayear = @nextayear AND ycon = @eserccontratto  AND ncon= @numcontratto 

		fetch next from @curscontratto into @eserccontratto, @numcontratto
	end
 		END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


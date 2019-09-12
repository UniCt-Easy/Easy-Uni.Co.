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



/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_updatearrears]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_updatearrears]
GO


CREATE  PROCEDURE [trg_updatearrears]
(
	@movkind char(1),
	@idmov int,
	@ayear int,
	@nphase tinyint,
	@oldidfin int,
	@idupb varchar(36),
	@amount decimal(19,2)
)
AS BEGIN

DECLARE @newidfin int
DECLARE @newarrear decimal(19,2)
DECLARE @oldarrear decimal(19,2)
DECLARE @lastphase tinyint
DECLARE @newayear int
SELECT @newayear = @ayear + 1

IF @movkind = 'I'
BEGIN
	SELECT @oldarrear = amount 	FROM incomeyear WHERE idinc = @idmov AND ayear = @newayear

	if @oldarrear is not null
	begin
		set @newarrear=@oldarrear+@amount 
		if (@newarrear<>0) 
		begin 
			update incomeyear set amount=@newarrear, lu = 'trg_updatearrears', lt = GETDATE() 
					 where  idinc = @idmov AND ayear = @newayear
		end
		else 
		begin
			 if EXISTS 		(SELECT incomeyear.idinc
								FROM incomeyear
								JOIN income
									ON income.idinc = incomeyear.idinc AND incomeyear.ayear = @newayear
								WHERE income.parentidinc = @idmov)	
				update incomeyear set amount=0, lu = 'trg_updatearrears', lt = GETDATE() 
							where  idinc = @idmov AND ayear = @newayear
			
				delete from incomeyear where idinc = @idmov AND ayear = @newayear
		end
		
	end
	else
	begin
		SELECT @newidfin = newidfin FROM finlookup 	WHERE oldidfin = @oldidfin

		INSERT INTO incomeyear	(idinc,ayear,idfin,idupb,amount,	cu,ct,lu,lt)
				VALUES(@idmov,@newayear,@newidfin,@idupb,@amount,
						'trg_updatearrears',GETDATE(),'trg_updatearrears',GETDATE())
	END

end
else
BEGIN
	SELECT @oldarrear = amount 	FROM expenseyear WHERE idexp = @idmov AND ayear = @newayear

	if @oldarrear is not null
	begin
		set @newarrear=@oldarrear+@amount 
		if (@newarrear<>0) 
		begin 
			update expenseyear set amount=@newarrear, lu = 'trg_updatearrears', lt = GETDATE() 
					 where  idexp = @idmov AND ayear = @newayear
		end
		else 
		begin
		 if EXISTS 		(SELECT expenseyear.idexp
								FROM expenseyear
								JOIN expense
									ON expense.idexp = expenseyear.idexp AND expenseyear.ayear = @newayear
								WHERE expense.parentidexp = @idmov)	
			update expenseyear set amount=0, lu = 'trg_updatearrears', lt = GETDATE() 
						where  idexp = @idmov AND ayear = @newayear
		else
			delete from expenseyear where idexp = @idmov AND ayear = @newayear
		end
		
	end
	else
	begin
		SELECT @newidfin = newidfin FROM finlookup 	WHERE oldidfin = @oldidfin

		INSERT INTO expenseyear	(idexp,ayear,idfin,idupb,amount,	cu,ct,lu,lt)
				VALUES(@idmov,@newayear,@newidfin,@idupb,@amount,
						'trg_updatearrears',GETDATE(),'trg_updatearrears',GETDATE())
	END

end
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


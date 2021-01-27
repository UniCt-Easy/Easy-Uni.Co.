
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_treasurercashtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_treasurercashtotal]
GO

CREATE  PROCEDURE [trg_upd_treasurercashtotal]
(
	@ayear int,
	@idtreasurer int,
	@movkind char(1),
	@oldamount decimal(19,2),
	@newamount decimal(19,2)
)
AS BEGIN

DECLARE @diff decimal(19,2)

IF (( ISNULL(@newamount,0) <> ISNULL(@oldamount,0)) OR
	   (@newamount IS NOT NULL AND @oldamount IS NULL)
	   OR (@newamount IS NULL AND @oldamount IS NOT NULL))
	BEGIN
		IF (@movkind = 'I')
			SELECT @diff = - ISNULL(@oldamount,0) + ISNULL(@newamount,0)
		ELSE
			SELECT @diff = ISNULL(@oldamount,0) - ISNULL(@newamount,0)
		
		IF EXISTS(select * from treasurercashtotal WHERE idtreasurer = @idtreasurer AND ayear = @ayear)
			BEGIN
				UPDATE treasurercashtotal SET currentfloatfund = ISNULL(currentfloatfund,0) + @diff
				WHERE idtreasurer = @idtreasurer AND ayear = @ayear
			END
		ELSE
			BEGIN
				INSERT INTO treasurercashtotal	(idtreasurer, ayear, currentfloatfund)	VALUES (@idtreasurer, @ayear, @diff)
			END
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

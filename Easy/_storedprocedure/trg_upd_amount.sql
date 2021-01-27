
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_amount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_amount]
GO

CREATE   PROCEDURE [trg_upd_amount]
(
	@ayear int,
	@movkind char(1),
	@paridmov int,
	@idmov int,
	@newamount decimal(19,2),
	@oldamount decimal(19,2)
)
AS BEGIN
IF (@newamount <> -@oldamount) OR
(@newamount IS NOT NULL AND @oldamount IS NULL) OR
(@newamount IS NULL AND @oldamount IS NOT NULL)
BEGIN
	IF @movkind = 'I'
	BEGIN
		UPDATE incometotal SET
			curramount = ISNULL(curramount,0) + @oldamount + @newamount,
			available = ISNULL(available,0) + @oldamount + @newamount
		WHERE idinc = @idmov
			AND ayear = @ayear

		IF (@paridmov IS NOT NULL)
		BEGIN
			UPDATE incometotal SET
			available = ISNULL(available, 0) - @oldamount - @newamount
			WHERE idinc = @paridmov
			AND ayear = @ayear
		END
	END
	ELSE
	BEGIN
		DECLARE @maxexpensephase tinyint
		SELECT @maxexpensephase = MAX(nphase) FROM expensephase

		DECLARE @nphase tinyint
		SELECT @nphase = nphase FROM expense WHERE idexp = @idmov

		IF (@nphase = @maxexpensephase)
		BEGIN
			EXEC trg_upd_curr_floatfund
			@ayear,
			'E',
			@idmov,
			@oldamount,
			@newamount
		END

		UPDATE expensetotal SET
			curramount = ISNULL(curramount,0) + @oldamount + @newamount,
			available = ISNULL(available,0) + @oldamount + @newamount
		WHERE idexp = @idmov
			AND ayear = @ayear

		IF (@paridmov IS NOT NULL)
		BEGIN
			UPDATE expensetotal SET
			available = ISNULL(available, 0) - @oldamount - @newamount
			WHERE idexp = @paridmov
			AND ayear = @ayear
		END
	END
END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_del_epaccamount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_del_epaccamount]
GO


CREATE  PROCEDURE [trg_del_epaccamount]
(
	@ayear int,
	@idmov int,
	@paridmov int,
	@amount decimal(19,2),
	@amount2 decimal(19,2),
	@amount3 decimal(19,2),
	@amount4 decimal(19,2),
	@amount5 decimal(19,2)

)
AS BEGIN
	IF (@paridmov IS NOT NULL)
	BEGIN
		UPDATE epacctotal SET
		available = ISNULL(available,0) - isnull(@amount,0),
		available2 = ISNULL(available2,0) - isnull(@amount2,0),
		available3 = ISNULL(available3,0) - isnull(@amount3,0),
		available4 = ISNULL(available4,0) - isnull(@amount4,0),
		available5 = ISNULL(available5,0) - isnull(@amount5,0)

		WHERE idepacc = @paridmov
		AND ayear = @ayear
	END

	DELETE FROM epacctotal
	WHERE idepacc = @idmov
	AND ayear = @ayear


END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





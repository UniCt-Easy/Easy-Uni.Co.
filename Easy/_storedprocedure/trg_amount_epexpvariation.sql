
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_amount_epexpvariation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_amount_epexpvariation]
GO

--setuser 'amm'
CREATE  PROCEDURE [trg_amount_epexpvariation]
(
	@ayear int,
	@idmov int,
	@parentidmovement int,
	@diffnewold decimal(19,2),
	@diffnewold2 decimal(19,2),
	@diffnewold3 decimal(19,2),
	@diffnewold4 decimal(19,2),
	@diffnewold5 decimal(19,2)
)
AS BEGIN


	UPDATE epexptotal SET
	curramount = ISNULL(curramount,0) + isnull(@diffnewold,0),
	available = ISNULL(available,0) + isnull(@diffnewold,0),

	curramount2 = ISNULL(curramount2,0) + isnull(@diffnewold2,0),
	available2 = ISNULL(available2,0) +isnull(@diffnewold2,0),

	curramount3 = ISNULL(curramount3,0) + isnull(@diffnewold3,0),
	available3 = ISNULL(available3,0) + isnull(@diffnewold3,0),

	curramount4 = ISNULL(curramount4,0) + isnull(@diffnewold4,0),
	available4 = ISNULL(available4,0) + isnull(@diffnewold4,0),

	curramount5 = ISNULL(curramount5,0) + isnull(@diffnewold5,0),
	available5 = ISNULL(available5,0) + isnull(@diffnewold5,0)
	WHERE idepexp = @idmov AND ayear = @ayear
	
	IF @parentidmovement IS NOT NULL
	BEGIN
		UPDATE epexptotal SET
				available = ISNULL(available,0) - @diffnewold,
				available2 = ISNULL(available2,0) - @diffnewold2,
				available3 = ISNULL(available3,0) - @diffnewold3,
				available4 = ISNULL(available4,0) - @diffnewold4,
				available5 = ISNULL(available5,0) - @diffnewold5
		WHERE idepexp = @parentidmovement AND ayear = @ayear
	END

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


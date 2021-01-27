
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trg_yearbalance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_yearbalance]
GO




SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        PROCEDURE [trg_yearbalance]
(
	@residualkind char(1),
	@ybalance int OUTPUT
)
AS BEGIN

	if (@residualkind = 'I') 
		SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=4)
	ELSE
		SELECT @ybalance = max(ayear) FROM accountingyear WHERE ((flag&0x0F)>=5) 
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_epexpyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_epexpyear]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

-- setuser 'amm'
-- rebuild_epexptotal 2016
-- rebuild_epexpyear 2016
CREATE    PROCEDURE [rebuild_epexpyear]
(
	@ayear int
)
AS BEGIN
SET NOCOUNT	 ON
DECLARE @idepexp int
DECLARE exp_crs INSENSITIVE CURSOR FOR
SELECT epexpyear.idepexp from epexpyear
WHERE epexpyear.ayear = @ayear	
ORDER BY epexpyear.idepexp
FOR READ ONLY

OPEN exp_crs
FETCH NEXT FROM exp_crs INTO @idepexp

WHILE (@@FETCH_STATUS = 0)
BEGIN
	exec trg_evaluatearrearsepexp @idepexp, @ayear
	

	FETCH NEXT FROM exp_crs INTO @idepexp
END
DEALLOCATE exp_crs
 
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

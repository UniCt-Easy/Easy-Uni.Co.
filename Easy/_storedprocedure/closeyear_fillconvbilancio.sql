
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillconvbilancio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillconvbilancio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE closeyear_fillconvbilancio
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidfin int, newidfin int)
	
INSERT #lookup
SELECT oldfin.idfin, finlookup.newidfin 
FROM fin oldfin
LEFT OUTER JOIN finlookup 
	ON oldfin.idfin = finlookup.oldidfin
WHERE oldfin.ayear = @ayear
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)

SELECT * FROM #lookup
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillplaccountlookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillplaccountlookup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE closeyear_fillplaccountlookup
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidplaccount varchar(31), newidplaccount varchar(31))
	
INSERT #lookup
SELECT oldplaccount.idplaccount, placcountlookup.newidplaccount
FROM placcount oldplaccount
LEFT OUTER JOIN placcountlookup 
	ON oldplaccount.idplaccount = placcountlookup.oldidplaccount
WHERE oldplaccount.ayear = @ayear

DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
UPDATE #lookup
SET newidplaccount =
	SUBSTRING(@nextayearstr, 3, 2)
	+ SUBSTRING(oldidplaccount, 3, 29)
WHERE newidplaccount IS NULL

SELECT * FROM #lookup

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


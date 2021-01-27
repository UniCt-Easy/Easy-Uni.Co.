
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillpatrimonylookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillpatrimonylookup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE closeyear_fillpatrimonylookup
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidpatrimony varchar(31), newidpatrimony varchar(31))
	
INSERT #lookup
SELECT oldpatrimony.idpatrimony, patrimonylookup.newidpatrimony 
FROM patrimony oldpatrimony
LEFT OUTER JOIN patrimonylookup 
	ON oldpatrimony.idpatrimony = patrimonylookup.oldidpatrimony
WHERE oldpatrimony.ayear = @ayear
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
UPDATE #lookup
SET newidpatrimony =
	SUBSTRING(@nextayearstr, 3, 2)
	+ SUBSTRING(oldidpatrimony, 3, 29)
WHERE newidpatrimony IS NULL
SELECT * FROM #lookup
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


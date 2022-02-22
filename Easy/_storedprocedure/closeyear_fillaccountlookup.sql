
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fillaccountlookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fillaccountlookup]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE closeyear_fillaccountlookup
(
	@ayear int
)
AS BEGIN
CREATE TABLE #lookup (oldidacc varchar(38), newidacc varchar(38))
	
INSERT #lookup
SELECT oldacc.idacc, accountlookup.newidacc 
FROM account oldacc
LEFT OUTER JOIN accountlookup 
	ON oldacc.idacc = accountlookup.oldidacc
WHERE oldacc.ayear = @ayear
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
UPDATE #lookup
SET newidacc =
	SUBSTRING(@nextayearstr, 3, 2)
	+ SUBSTRING(oldidacc, 3, 36)
WHERE newidacc IS NULL
SELECT * FROM #lookup
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_placcountcopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_placcountcopy]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




--sp_help placcount

CREATE       PROCEDURE [closeyear_placcountcopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #log (messaggio varchar(255))
DECLARE @nextayear int
SET @nextayear = @ayear + 1
	
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)


	
IF NOT EXISTS (SELECT * FROM placcountlevel WHERE ayear = @nextayear)
BEGIN
	INSERT INTO placcountlevel
		(
			ayear, nlevel, description,
			cu, ct, lu, lt
		)
		SELECT
			@nextayear, nlevel, description,
			cu, GETDATE(), lu, GETDATE()
		FROM placcountlevel
		WHERE ayear = @ayear
	
		INSERT INTO #log
		VALUES('Trasferiti livelli conto economico annuale per esercizio ' + @nextayearstr)
END
IF NOT EXISTS (SELECT * FROM placcount WHERE ayear = @nextayear)
BEGIN
	INSERT INTO placcount
		(
			idplaccount,
			ayear, codeplaccount,placcpart,
			nlevel, paridplaccount, printingorder,rtf,txt, title, 
			active,
			cu, ct, lu, lt
		)
		SELECT
		SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(idplaccount, 3, 29),
		@nextayear, codeplaccount,placcpart, nlevel,
		SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(paridplaccount, 3, 29),
		printingorder,rtf,txt, title, active,
		cu, GETDATE(), lu, GETDATE()
		FROM placcount
		WHERE ayear = @ayear

		INSERT INTO #log
		VALUES('Trasferite voci del conto economico annuale per esercizio ' + @nextayearstr)
END
	
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_check_yearcreate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_check_yearcreate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [closeyear_check_yearcreate]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #errorlog (errordescr varchar(255))
DECLARE @nextayear int
SET @nextayear = @ayear + 1
	
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)
	
IF EXISTS (SELECT * FROM accountingyear WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errorlog VALUES('Esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS (SELECT * FROM config WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errorlog VALUES('Configurazione generale per esercizio ' + @nextayearstr + ' esistente.')
END

IF EXISTS (SELECT * FROM trasmissionmanager WHERE ayear = @nextayear)
BEGIN
	INSERT INTO #errorlog VALUES('Responsabile della trasmissione per esercizio ' + @nextayearstr + ' esistenti.')
END

SELECT * FROM #errorlog
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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

if exists (select * from dbo.sysobjects where id = object_id(N'[doupdate_reversale_incasso]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [doupdate_reversale_incasso]
GO

CREATE PROCEDURE [doupdate_reversale_incasso]
(
	@ayear int,
	@printkind char(1),
	@startnpro int,
	@stopnpro int,
	@printdate datetime,
	@idtreasurer INT
)
AS BEGIN
CREATE TABLE #printingdoc (npro int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (npro) 
	SELECT npro FROM proceeds 
	WHERE (ypro=@ayear) AND (printdate IS NULL) AND idtreasurer = @idtreasurer
END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (npro) 
	SELECT npro FROM proceeds 
	WHERE (ypro=@ayear) AND (npro BETWEEN @startnpro AND @stopnpro)AND idtreasurer = @idtreasurer
END
UPDATE proceeds
SET printdate =	@printdate
WHERE ypro = @ayear
	AND npro IN (SELECT npro FROM #printingdoc)
	AND idtreasurer = @idtreasurer
	AND printdate IS NULL
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


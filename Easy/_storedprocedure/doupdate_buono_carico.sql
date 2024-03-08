
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

if exists (select * from dbo.sysobjects where id = object_id(N'[doupdate_buono_carico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [doupdate_buono_carico]
GO

CREATE  PROCEDURE [doupdate_buono_carico]
(
	@ayear int,
	@printkind char(1),
	@idassetloadkind int,
	@startnassetload int,
	@stopnassetload int,
	@printdate datetime
)
AS BEGIN
CREATE TABLE #printingdoc (num int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num)
	SELECT nassetload FROM assetload
	WHERE yassetload = @ayear
		AND printdate IS NULL
		AND idassetloadkind = @idassetloadkind
END
	
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT nassetload FROM assetload
	WHERE yassetload = @ayear
		AND nassetload BETWEEN @startnassetload AND @stopnassetload
		AND idassetloadkind = @idassetloadkind
END
UPDATE assetload 
SET printdate = @printdate
WHERE yassetload = @ayear 
	AND nassetload IN (SELECT num FROM #printingdoc)
	AND idassetloadkind = @idassetloadkind
	AND printdate IS NULL
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


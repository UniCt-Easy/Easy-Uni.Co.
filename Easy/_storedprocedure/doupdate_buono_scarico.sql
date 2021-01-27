
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[doupdate_buono_scarico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [doupdate_buono_scarico]
GO


CREATE PROCEDURE [doupdate_buono_scarico]
(
	@ayear int,
	@printkind char(1),
	@idassetunloadkind int,
	@startassetunload int,
	@stopassetunload int,
	@printdate datetime
)
AS BEGIN
CREATE TABLE #printingdoc (idassetunload int, num int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num,idassetunload)
	SELECT nassetunload,idassetunload FROM assetunload
	WHERE yassetunload = @ayear
		AND printdate IS NULL
		AND idassetunloadkind = @idassetunloadkind
END
	
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num,idassetunload) 
	SELECT nassetunload,idassetunload FROM assetunload
	WHERE yassetunload = @ayear
		AND nassetunload BETWEEN @startassetunload AND @stopassetunload
		AND idassetunloadkind = @idassetunloadkind
END
UPDATE assetunload 
SET printdate = @printdate
WHERE yassetunload = @ayear 
	AND nassetunload IN (SELECT num FROM #printingdoc)
	AND idassetunloadkind = @idassetunloadkind
	AND printdate IS NULL

UPDATE asset set flag = flag & 0xFB 
		where idassetunload in (SELECT idassetunload FROM #printingdoc)

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


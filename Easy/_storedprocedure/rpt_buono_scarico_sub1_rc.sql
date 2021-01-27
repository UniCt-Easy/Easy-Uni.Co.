
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_scarico_sub1_rc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_scarico_sub1_rc]
GO

CREATE                      PROCEDURE [rpt_buono_scarico_sub1_rc]
@ayear int,
@idassetunloadkind int,
@nassetunload int
AS
BEGIN
SELECT
	assetunload.idassetunloadkind,
	assetunload.yassetunload,
	assetunload.nassetunload,
	assetunloadincome.idinc,
	income.ymov,
	proceeds.npro,
	proceeds.printdate	
FROM assetunloadincome
JOIN assetunload
	ON assetunload.idassetunload = assetunloadincome.idassetunload
JOIN income 
	ON assetunloadincome.idinc = income.idinc
JOIN incomelast
	ON income.idinc = incomelast.idinc
JOIN proceeds
	ON incomelast.kpro = proceeds.kpro
WHERE assetunload.idassetunloadkind = @idassetunloadkind
	AND assetunload.yassetunload = @ayear
	AND assetunload.nassetunload = @nassetunload
ORDER BY income.ymov, proceeds.printdate, proceeds.npro
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

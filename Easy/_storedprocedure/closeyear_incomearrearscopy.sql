/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_incomearrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_incomearrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--  setuser 'amm'
--  closeyear_incomearrearscopy 2016
-- rebuild_incometotal

CREATE    PROCEDURE [closeyear_incomearrearscopy]
(
	@ayear int
)
AS BEGIN
	
DECLARE @idinc 		int
DECLARE @idfin 		int
DECLARE @idupb 		varchar(36)
DECLARE @nlevel 	tinyint
DECLARE @nphase 	tinyint
DECLARE @curramount 	decimal(19,2)
DECLARE @available 	decimal(19,2)
DECLARE @proceeded 	decimal(19,2)
DECLARE @newidfin 	int	
DECLARE @nextayear 	int

SET 	@nextayear = @ayear + 1
DECLARE @nextayearstr 	varchar(4)
SET 	@nextayearstr = CONVERT(varchar(4),@nextayear)

DECLARE @maxincomephase int
SELECT  @maxincomephase = MAX(nphase) FROM incomephase


if (@maxincomephase>2) begin
print @maxincomephase
insert into incomeyear (idinc, ayear, idfin, idupb, amount,  cu, ct, lu, lt)
select E.idinc,@nextayear, FL.newidfin,EY.idupb,
 ET.curramount- isnull((SELECT SUM(curramount)
		FROM incometotal
		JOIN incomelast			ON     incomelast.idinc = incometotal.idinc
		JOIN   incomelink			ON     incomelink.idchild = incomelast.idinc
		WHERE  incometotal.ayear = @ayear		AND incomelink.idparent = E.idinc and nlevel = E.nphase ),0),
			'ArrearsCopy', GETDATE(), 'ArrearsCopy', GETDATE()
 FROM incometotal	ET
 JOIN income E	 	ON E.idinc = ET.idinc
 join incomeyear EY ON EY.idinc = ET.idinc and EY.ayear= ET.ayear
 join finlookup FL on FL.oldidfin= EY.idfin
 left outer join incomeyear ey2 on ey2.idinc=ET.idinc and ey2.ayear=@nextayear
WHERE ET.ayear = @ayear	AND E.nphase < @maxincomephase-1  AND EY2.idinc is null
	and ET.curramount > isnull((SELECT SUM(curramount)
		FROM incometotal
		JOIN incomelast			ON     incomelast.idinc = incometotal.idinc
		JOIN   incomelink			ON     incomelink.idchild = incomelast.idinc
		WHERE  incometotal.ayear = @ayear		AND incomelink.idparent = E.idinc and nlevel = E.nphase ),0)
end


if (@maxincomephase>1) begin
insert into incomeyear (idinc, ayear, idfin, idupb, amount,  cu, ct, lu, lt)
select E.idinc,@nextayear, FL.newidfin,EY.idupb,
	ET.available, 'ArrearsCopy', GETDATE(), 'ArrearsCopy', GETDATE()
 FROM incometotal	ET
 JOIN income E	 	ON E.idinc = ET.idinc
 join incomeyear EY ON EY.idinc = ET.idinc and EY.ayear= ET.ayear
 join finlookup FL on FL.oldidfin= EY.idfin
 left outer join incomeyear ey2 on ey2.idinc=ET.idinc and ey2.ayear=@nextayear
WHERE ET.ayear = @ayear	AND E.nphase = @maxincomephase-1  AND EY2.idinc is null
	and ET.available>0
end


UPDATE incometotal
   SET partitioned = curramount
	WHERE (flag&1)<>0 and partitioned=0 
		and ayear= @nextayear


		
EXEC rebuild_incometotal @nextayear

EXEC rebuild_upbincometotal @nextayear

EXEC rebuild_treasurercashtotal @nextayear

EXEC closeyear_epaccarrearscopy @ayear

CREATE TABLE #info (msg varchar(800))
INSERT INTO #info VALUES('I residui attivi sono stati trasferiti all'' esercizio ' + @nextayearstr)

-- azzero i bit da 0 a 3 e imposto il valore 4 nell'esercizio corrente. 
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x04 WHERE ayear = @ayear
	
	
SELECT * FROM #info
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
	
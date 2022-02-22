
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_check_incomearrearscopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_check_incomearrearscopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE     PROCEDURE [closeyear_check_incomearrearscopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #errors (errordescr varchar(800))
	
DECLARE @minusablelevel tinyint
SELECT  @minusablelevel = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND flag&2 <> 0
DECLARE @proceedsphase tinyint
SELECT  @proceedsphase = MAX(nphase) FROM incomephase


INSERT INTO #errors
SELECT 'ATTRIBUZIONE ENTRATA(INCOMEYEAR) senza corrispondente voce di bilancio nell''anno successivo ' 
+ F.codefin 
FROM incomeyear EY
join fin F ON EY.idfin=F.idfin
WHERE NOT EXISTS(SELECT * FROM finlookup FL WHERE FL.oldidfin=EY.idfin)
AND EY.ayear = @ayear

INSERT INTO #errors
SELECT 'ATTRIBUZIONE ENTRATA(INCOMEYEAR) corrispondente a voce di bilancio articolata nell''anno successivo ' 
+ F.codefin 
FROM incomeyear EY
join fin F ON EY.idfin=F.idfin
WHERE EXISTS (SELECT * 
		FROM finlookup FL JOIN finlink FLI 
		ON FLI.idparent   = FL.newidfin AND FLI.idparent <> FLI.idchild 
		WHERE FL.oldidfin = EY.idfin)
AND EY.ayear = @ayear

INSERT INTO #errors
SELECT 'ATTRIBUZIONE ENTRATA (INCOMEYEAR) senza MOVIMENTO ENTRATA (INCOME) (incoerenza nel db, contattare il settore assistenza) ' 
	+ CONVERT(varchar(20), incomeyear.idinc) 
FROM incomeyear 
WHERE NOT EXISTS(SELECT * FROM income E1 WHERE E1.idinc=incomeyear.idinc)

INSERT INTO #errors
SELECT 'TOTALIZZATORE ENTRATA (INCOMETOTAL) senza MOVIMENTO ENTRATA (INCOME) (incoerenza nel db, contattare il settore assistenza) ' 
	+ CONVERT(varchar(20), incometotal.idinc) 
FROM incometotal 
WHERE NOT EXISTS(SELECT * FROM income E1 WHERE E1.idinc=incometotal.idinc)


INSERT INTO #errors
SELECT incomephase.description + '(INCOME) senza ATTRIBUZIONE (INCOMEYEAR) (incoerenza nel db, contattare il settore assistenza) ' 
	+ CONVERT(varchar(4), income.ymov) 
	+ ' num. ' 
	+ CONVERT(varchar(6), income.nmov)
FROM income left outer join incomephase on income.nphase=incomephase.nphase
WHERE NOT EXISTS( SELECT * from incomeyear E1 where E1.idinc=income.idinc)

INSERT INTO #errors
SELECT incomephase.description
	+ '(INCOME) senza TOTALIZZATORE  (INCOMETOTAL)(incoerenza nel db, contattare il settore assistenza: bisogna fare il REBUILD) ' 
	+ CONVERT(varchar(4), income.ymov)
	+ ' num. ' 
	+ CONVERT(varchar(6), income.nmov)
FROM income left outer join incomephase on income.nphase=incomephase.nphase
WHERE NOT EXISTS( SELECT * from incometotal E1 where E1.idinc=income.idinc)


INSERT INTO #errors
SELECT incomephase.description
	+ ' con disponibile NEGATIVO ' + CONVERT(varchar(4), income.ymov) 
	+ ' num. ' 
	+ CONVERT(varchar(6), income.nmov)
FROM income left outer join incomephase on income.nphase=incomephase.nphase
JOIN incometotal
	ON incometotal.idinc = income.idinc
WHERE incometotal.available < 0
	AND incometotal.ayear = @ayear

INSERT INTO #errors
SELECT incomephase.description
	+ ' con importo corrente NEGATIVO ' + CONVERT(varchar(4), income.ymov) 
	+ ' num. ' 
	+ CONVERT(varchar(6), income.nmov)
FROM income left outer join incomephase on income.nphase=incomephase.nphase
JOIN incometotal
	ON incometotal.idinc = income.idinc
WHERE incometotal.curramount<0
	AND incometotal.ayear = @ayear

DECLARE @phasedescription varchar(50)
SELECT @phasedescription = description FROM incomephase WHERE nphase = @proceedsphase

IF (upper(user) <> 'AMMINISTRAZIONE')
BEGIN
	INSERT INTO #errors
	SELECT 
	@phasedescription + ' senza reversale eserc. ' + CONVERT(varchar(4), income.ymov) + 
	' num. ' + CONVERT(varchar(6), income.nmov)
	FROM income
	JOIN incomelast
	ON income.idinc = incomelast.idinc 
	JOIN incometotal
		ON incometotal.idinc = income.idinc
	WHERE income.nphase = @proceedsphase
		AND incometotal.ayear = @ayear
		AND incometotal.curramount > 0
		AND incomelast.kpro IS NULL

	INSERT INTO #errors
	SELECT 
	'Reversale senza distinta di trasmissione eserc. ' + CONVERT(varchar(4), ypro) + 
	' num. ' + CONVERT(varchar(6), npro)
	FROM proceeds
	WHERE kproceedstransmission IS NULL
		AND ypro = @ayear
		AND EXISTS(SELECT * FROM incomelast WHERE kpro = proceeds.kpro)
			AND proceeds.annulmentdate IS NULL
END

INSERT INTO #errors
SELECT 
f1.description + ' num. ' + CONVERT(varchar(20),e1.nmov) + ' è attribuito a una voce di bilancio non operativa o articolata'
FROM income e1
JOIN incomeyear i1
	ON e1.idinc = i1.idinc
JOIN incometotal i2
	ON i1.idinc = i2.idinc
JOIN fin b1
	ON i1.idfin = b1.idfin
JOIN incomephase f1
	ON e1.nphase = f1.nphase
WHERE i1.ayear = @ayear
 AND (SELECT COUNT(finlast.idfin) 
	 FROM finlast 
	WHERE finlast.idfin = b1.idfin
	  AND b1.nlevel >= @minusablelevel
	  AND finlast.idfin is not null) = 0
SELECT * FROM #errors
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




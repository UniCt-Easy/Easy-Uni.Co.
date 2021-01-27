
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_fondopsp_registro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_fondopsp_registro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE                                PROCEDURE [rpt_fondopsp_registro]
	@ayear	smallint,
	@idpettycash	int,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@start	smalldatetime,
	@stop	smalldatetime

AS BEGIN

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') 
BEGIN
	SET @idupb=@idupb+'%' 
END

CREATE TABLE #pettycashreg
(
	noperation int,
	operation varchar(20),
	adate datetime,
	operationdescription varchar(200),
	idfin int,
	codefin varchar(50),	
	idupb varchar(36),
	codeupb varchar(50),	
	incomeamount decimal(19,2),	
	expenseamount decimal(19,2),
	doc varchar(50),
	docdate datetime,
	idexp int ,
	detail varchar(2000),
	nrestore int,
	yrestore int,
	kind char,
	idexpIx int,
	payment varchar(2000) ,
	idman int
)
IF (DATEPART(yy, @start) <> @ayear OR DATEPART(mm, @start) <> 1	OR DATEPART(dd, @start) <> 1)
BEGIN
INSERT INTO #pettycashreg
(
	noperation,
	operation,
	adate,
	incomeamount,
	expenseamount
)

SELECT
	NULL,
	'Tot. prec.',
	DATEADD(dd, -1, @start),
	ISNULL(
		(SELECT ISNULL(SUM(amount),0)
		FROM pettycashoperation
		WHERE yoperation = @ayear
			AND pettycashoperation.idpettycash = @idpettycash
			AND (flag& 1)<>0 -- Apertura
			AND adate < @start)
	, 0.0) 
	+ 
	ISNULL(
		(SELECT ISNULL(SUM(amount),0)
		FROM pettycashoperation
		WHERE yoperation = @ayear
			AND pettycashoperation.idpettycash = @idpettycash
			AND (flag& 2)<>0 --Reintegro
			AND adate < @start)
	, 0),
	ISNULL(
		(SELECT  ISNULL(SUM(amount) ,0)
		FROM pettycashoperation
		WHERE yoperation = @ayear
			AND pettycashoperation.idpettycash = @idpettycash
			AND (flag& 4)<>0 -- Chiusura
			AND adate < @start)
	, 0) + 
	ISNULL(
		(SELECT ISNULL(SUM(amount),0)
		FROM pettycashoperation
		WHERE yoperation = @ayear
			AND pettycashoperation.idpettycash = @idpettycash
			AND (flag& 8)<>0 --Spesa
			AND adate < @start)
	, 0)
FROM pettycash
WHERE pettycash.idpettycash = @idpettycash
END

INSERT INTO #pettycashreg
(
	noperation,
	operation,
	adate,
	operationdescription,
	codefin,idfin,
	codeupb,idupb,
	incomeamount,
	expenseamount,
	doc,
	docdate,
	idexp,
	nrestore,
	yrestore,
	kind,
	idexpIx,
	idman
)

SELECT
	pettycashoperation.noperation,
	case 
		WHEN (pettycashoperation.flag& 1)<>0  THEN 'Apertura'
		WHEN (pettycashoperation.flag& 4)<>0  THEN 'Chiusura'
		WHEN (pettycashoperation.flag& 2)<>0  THEN 'Reintegro'
		WHEN (pettycashoperation.flag& 8)<>0  THEN 'Spesa'
	END,
	pettycashoperation.adate,
	pettycashoperation.description,
	fin.codefin,fin.idfin,
	upb.codeupb,upb.idupb,
	case 
		WHEN (pettycashoperation.flag& 1)<>0 THEN pettycashoperation.amount
		WHEN (pettycashoperation.flag& 4)<>0 THEN null
		WHEN (pettycashoperation.flag& 2)<>0 THEN pettycashoperation.amount
		WHEN (pettycashoperation.flag& 8)<>0 THEN null
	END,
	case 
		WHEN (pettycashoperation.flag& 1)<>0 THEN null
		WHEN (pettycashoperation.flag& 4)<>0 THEN pettycashoperation.amount
		WHEN (pettycashoperation.flag& 2)<>0 THEN null
		WHEN (pettycashoperation.flag& 8)<>0 THEN pettycashoperation.amount
	END,
	pettycashoperation.doc,
	pettycashoperation.docdate,
	pettycashoperation.idexp,
	pettycashoperation.nrestore,
	pettycashoperation.yrestore,
CASE
		WHEN (pettycashoperation.flag& 1)<>0  THEN 'A'
		WHEN (pettycashoperation.flag& 4)<>0  THEN 'C'
		WHEN (pettycashoperation.flag& 2)<>0  THEN 'R'
		WHEN (pettycashoperation.flag& 8)<>0  THEN 'S'
end ,
	expense.idexp,
	pettycashoperation.idman
FROM pettycashoperation
LEFT OUTER JOIN fin
	ON pettycashoperation.idfin = fin.idfin
LEFT OUTER JOIN upb
	ON pettycashoperation.idupb = upb.idupb
LEFT OUTER JOIN expense
	ON expense.idexp = pettycashoperation.idexp
LEFT OUTER JOIN expenseyear
	ON expense.idexp = expenseyear.idexp
	AND expenseyear.ayear = @ayear
WHERE pettycashoperation.yoperation = @ayear
	AND pettycashoperation.idpettycash = @idpettycash
	AND ((pettycashoperation.flag& 8)<>0 AND (upb.idupb like @idupb)
		OR (pettycashoperation.flag& 8)<>0 AND (expenseyear.idupb like @idupb)
		OR (pettycashoperation.flag& 8) = 0)
	AND pettycashoperation.adate between @start and @stop

-- Aggiornamento della voce di bilancio nel caso di operazione associata ad un movimento di spesa
UPDATE #pettycashreg
SET codefin = fin.codefin,
    codeupb = upb.codeupb,
	idexpIx = expenseyear.idexp,
	idupb = expenseyear.idupb
FROM fin
JOIN expenseyear
	ON fin.idfin = expenseyear.idfin
JOIN upb
	ON upb.idupb = expenseyear.idupb
WHERE expenseyear.idexp = #pettycashreg.idexp
	AND expenseyear.ayear = @ayear

-- Aggiornamento della voce di bilancio alle operazioni di Apertura e Chiusura interrogando le tabelle pettycashexpense e pettycashincome
UPDATE #pettycashreg
SET codefin = fin.codefin,
    codeupb = upb.codeupb,
	idupb = expenseyear.idupb
FROM pettycashexpense
JOIN expenseyear
	ON pettycashexpense.idexp = expenseyear.idexp
JOIN fin
	ON fin.idfin = expenseyear.idfin
JOIN upb
	ON upb.idupb = expenseyear.idupb
WHERE  expenseyear.ayear = @ayear
	and pettycashexpense.yoperation = @ayear 
	and pettycashexpense.noperation = #pettycashreg.noperation  
	and pettycashexpense.idpettycash=@idpettycash 
	and #pettycashreg.kind='A'

UPDATE #pettycashreg
SET codefin = fin.codefin,
    codeupb = upb.codeupb,
	idupb = incomeyear.idupb
FROM pettycashincome
JOIN incomeyear
	ON pettycashincome.idinc = incomeyear.idinc
JOIN fin
	ON fin.idfin = incomeyear.idfin
JOIN upb
	ON upb.idupb = incomeyear.idupb
WHERE  incomeyear.ayear = @ayear
	and pettycashincome.yoperation = @ayear 
	and pettycashincome.noperation = #pettycashreg.noperation  
	and pettycashincome.idpettycash=@idpettycash 
	and #pettycashreg.kind='C'


DECLARE @noperation int
DECLARE @nrestore int 
DECLARE @yrestore int
DECLARE @detail varchar(2000)


UPDATE #pettycashreg
SET detail =' (Op. nn. '
WHERE operation ='Reintegro' 

-- Elenca tutte le operazioni collegate al Reintegro
DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT noperation,nrestore,yrestore FROM #pettycashreg
	WHERE  nrestore is not null and yrestore is not null and operation!='Reintegro'
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @noperation, @nrestore, @yrestore
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#pettycashreg set
	  detail = substring(isnull(detail,'') + isnull(convert(varchar(10),@noperation),'') + ', ',1,2000)
	 WHERE noperation=@nrestore 
		FETCH NEXT FROM cursore 
		INTO @noperation, @nrestore, @yrestore
	END
CLOSE cursore
DEALLOCATE cursore

UPDATE #pettycashreg SET detail =substring(detail,1,len(detail)-1) + ')'
					WHERE operation ='Reintegro' 

-- Elenca i numeri di mandato collegati al Reintegro/Apertura
/*UPDATE #pettycashreg SET detail = isnull(detail,'')+ ' mand. n.'
					WHERE operation='Reintegro' or operation='Apertura'*/
/*
UPDATE #pettycashreg SET payment = ' n° '
					WHERE operation='Reintegro' or operation='Apertura'
*/
DECLARE @npay int
DECLARE @ypay int
DECLARE @nph tinyint
SET @nph= (SELECT MAX(nphase) FROM expensephase)

DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT  #pettycashreg.noperation, payment.npay, expense.ymov, datepart(yy,#pettycashreg.adate) 
	FROM  #pettycashreg 
	JOIN pettycashexpense 
		ON #pettycashreg.noperation=pettycashexpense.noperation 
		AND datepart(yy,#pettycashreg.adate)=pettycashexpense.yoperation 
	JOIN expense 
		ON pettycashexpense.idexp=expense.idexp
	LEFT OUTER JOIN 
		expenselast
		ON expense.idexp = expenselast.idexp
	left outer join payment 
		on payment.kpay = expenselast.kpay
	WHERE 	expense.nphase=@nph  and pettycashexpense.idpettycash=@idpettycash 
		and #pettycashreg.operation in('Reintegro','Apertura')
	
	OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @noperation, @npay, @ypay, @yrestore
	
	WHILE (@@fetch_status=0) BEGIN
		UPDATE 	#pettycashreg set
		payment = substring( isnull(payment,' n° ') + isnull(convert(varchar(10),@npay),'') + ' ',1,2000)
		WHERE #pettycashreg.operation in('Reintegro','Apertura')
			and noperation=@noperation  and @npay is not null
		FETCH NEXT FROM cursore 
		INTO @noperation, @npay, @ypay, @yrestore
	END
CLOSE cursore
DEALLOCATE cursore

UPDATE #pettycashreg SET
	detail=  (SELECT ' (Reintegro n. ' + convert(varchar(10),nrestore) + ')' FROM pettycashoperation
	WHERE #pettycashreg.noperation=pettycashoperation.noperation and pettycashoperation.yoperation=@ayear and idpettycash=@idpettycash )
WHERE operation='Spesa' 

-- Valorizza il numero del mandato sulle singole operazioni di spesa
DECLARE @nphase INT
SELECT  @nphase = expenseregphase FROM uniconfig
-- al fine di valorizzare il numero di mandato delle operazioni di spesa, serve valorizzare l'idexp dell'impegno
UPDATE #pettycashreg 
SET  #pettycashreg.idexpIx	= e.idexp
FROM #pettycashreg po
	JOIN pettycashexpense pce
		ON  po.yrestore = pce.yoperation
		AND po.nrestore = pce.noperation
		AND @idpettycash = pce.idpettycash
	JOIN expense e
		ON  e.idexp = pce.idexp
		AND e.nphase = @nphase
    JOIN expenseyear EY
        ON EY.idexp = E.idexp
WHERE operation='Spesa' 
        AND EY.idfin = po.idfin AND EY.idupb = po.idupb 
		AND isnull(po.idman,0) = isnull(E.idman,0) -->>  va considerato anche il responsabile
        AND EY.ayear = @ayear
        AND po.nrestore IS NOT NULL


DECLARE @idexpIx int
DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT distinct payment.npay, #pettycashreg.idexpIx, #pettycashreg.noperation  
	FROM  #pettycashreg  
	JOIN  pettycashexpense pce 
		ON #pettycashreg.yrestore = pce.yoperation
		AND #pettycashreg.nrestore = pce.noperation     
	JOIN expense  
		ON expense.idexp = pce.idexp
	JOIN expenselast
		ON expenselast.idexp = expense.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN expenselink 
		ON expenselast.idexp = expenselink.idchild 
		AND expenselink.idparent = #pettycashreg.idexpIx 
	WHERE  pce.idpettycash = @idpettycash 
	
	OPEN cursore
	FETCH NEXT FROM cursore INTO @npay, @idexpIx,@noperation
	
 	
	WHILE (@@fetch_status=0) 
	BEGIN
		UPDATE #pettycashreg SET payment = isnull(payment,'') + ' n° '+isnull(convert(varchar(10),@npay),'') + '; '
		WHERE #pettycashreg.idexpIx = @idexpIx and #pettycashreg.noperation  = @noperation 
	FETCH NEXT FROM cursore INTO @npay, @idexpIx, @noperation
	END
CLOSE cursore
DEALLOCATE cursore

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #pettycashreg SET  
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #pettycashreg	
				WHERE idupb = @idupboriginal)
		WHERE idupb IS NOT NULL--> sul reintegro non deve avere effetto
	
IF (@showupb <>'S') and (@idupboriginal = '%') 
			UPDATE #pettycashreg SET  
			idupb = null,
			codeupb = null
SELECT
	noperation,
	@idpettycash as idpettycash,
	(SELECT description FROM pettycash
		WHERE idpettycash = @idpettycash) 
	AS description,
	operation,
	adate,
	operationdescription,
	codefin,
	codeupb,
	incomeamount,
	expenseamount,
	doc,
	docdate,
	isnull(detail,'') as detail,
	nrestore,
	yrestore,
	case 
		when (ISNULL(payment,'') <> '') then ( 'Mand. ' + payment )
		else ''
	end
		as payment, 
	idexpIx
FROM #pettycashreg 
WHERE (idupb like @idupb OR idupb is null)
ORDER BY idpettycash, adate, noperation


 -- exec rpt_fondopsp_registro 2015, 2, 'S','%', 'S',{ts '2010-01-01 00:00:00'}, {ts '2015-12-31 00:00:00'}


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

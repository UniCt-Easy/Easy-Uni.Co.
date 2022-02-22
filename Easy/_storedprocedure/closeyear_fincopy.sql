
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_fincopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_fincopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- setuser'amministrazione'
-- setuser'amm'
-- closeyear_fincopy 2020
CREATE     PROCEDURE [closeyear_fincopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #info (mydata varchar(800))
DECLARE @nextayear int
SET @nextayear = @ayear + 1
	
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4),@nextayear)
	
DECLARE @minlevop smallint
SELECT  @minlevop = max(nlevel) from  finlevel where ayear =@nextayear
SET @minlevop=isnull(@minlevop,0)


CREATE TABLE #accountlookup (oldidacc varchar(38), newidacc varchar(38))
INSERT #accountlookup
EXECUTE closeyear_fillaccountlookup @ayear

INSERT INTO accountlookup
(
	newidacc,
	oldidacc,
	cu, ct, lu, lt
)
SELECT
	newidacc,
	oldidacc,
	'fincopy', getdate(), 'fincopy', getdate()
FROM    #accountlookup
WHERE   NOT EXISTS (SELECT * FROM accountlookup AL1 
			WHERE AL1.oldidacc = #accountlookup.oldidacc
                        AND   AL1.newidacc = #accountlookup.newidacc)

IF NOT EXISTS (SELECT * FROM finlevel WHERE ayear = @nextayear AND nlevel > @minlevop)
BEGIN
	INSERT INTO finlevel
		(
		ayear, nlevel, description,
		flag,
		cu, ct, lu, lt
		)
	SELECT
		@nextayear, nlevel, description,
		flag,
		cu, GETDATE(), lu, GETDATE()
	FROM finlevel
	WHERE ayear = @ayear
	AND nlevel > @minlevop
	
	INSERT INTO #info
	VALUES('I livelli bilancio per l''esercizio ' + @nextayearstr+ ' sono stati copiati.')
END

-- trasferisco la tabella finlookup
DECLARE @maxidfin int
SET 	@maxidfin = (SELECT MAX(idfin) FROM fin)

CREATE TABLE #tempfin
(
	idfin    	int IDENTITY(1,1),
	paridfin 	int ,
	previdfin	int ,
	prevparidfin	int 	 
)

CREATE TABLE #finlookup
(
	newidfin    	int ,
	oldidfin 	int ,
	cu		varchar(64), 
	ct		datetime, 
	lu		varchar(64), 
	lt 		datetime
)

--trasferimento degli articoli e delle voci di bilancio successive
IF NOT EXISTS (SELECT * FROM fin WHERE ayear = @nextayear AND nlevel > @minlevop)
BEGIN
	INSERT INTO #tempfin
	(
		previdfin,
		prevparidfin 	
	)
	SELECT 
		idfin,
		paridfin
	FROM fin
	WHERE ayear = @ayear
	AND nlevel > @minlevop		
	
	--inserisco in #finlookup le righe preesistenti relative al 2009
	--fino al livello consolidato
	INSERT INTO #finlookup
	(
		newidfin,
		oldidfin,
		cu, ct, lu, lt
	)
	SELECT
		newidfin,
		oldidfin,
		finlookup.cu, finlookup.ct, finlookup.lu, finlookup.lt
	FROM    finlookup
	JOIN    fin ON finlookup.oldidfin = fin.idfin
	WHERE	fin.ayear = @ayear
	AND     fin.nlevel = @minlevop
	
	--inserisco in #finlookup le righe che dovranno essere inserite relative al 2009
	--a partire dal livello consolidato e successivi
	INSERT INTO #finlookup
	(
		newidfin,
		oldidfin,
		cu, ct, lu, lt
	)
	SELECT
		@maxidfin + idfin,
		previdfin,
		'finCopy', GETDATE(), 'finCopy', GETDATE() 
	FROM    #tempfin
	
	INSERT INTO fin
	(
		idfin,		paridfin,		nlevel, 		printingorder, title, 	ayear,codefin,	flag, 
		cu, ct, lu, lt
	)
	SELECT
		FL1.newidfin,		FL2.newidfin,	nlevel, printingorder, title, 	@nextayear, codefin,flag, 
		fin.cu, GETDATE(), fin.lu, GETDATE()
	FROM fin
	JOIN #finlookup FL1 		ON   fin.idfin = FL1.oldidfin 
	LEFT OUTER JOIN #finlookup FL2		ON   fin.paridfin = FL2.oldidfin 
	WHERE ayear = @ayear	AND nlevel > @minlevop
	order by nlevel 
	
	INSERT INTO finlast
	(
		idfin,idman, expiration,cupcode,idacc,
		cu, ct, lu, lt
	)
	SELECT 
		FL1.newidfin,
		idman,
		expiration,cupcode,accountlookup.newidacc,
		fin.cu, GETDATE(), fin.lu, GETDATE() 
	FROM finlast
	JOIN fin				ON finlast.idfin = fin.idfin
	JOIN #finlookup FL1 	ON   finlast.idfin = FL1.oldidfin 	
	LEFT OUTER JOIN accountlookup ON finlast.idacc = accountlookup.oldidacc
	WHERE ayear = @ayear
		--and not exists(select * from finlast where idfin=FL1.newidfin)
		AND nlevel > @minlevop

	update finlast set
		idman= fl_old.idman,
		idacc = accountlookup.newidacc,
		expiration = fl_old.expiration
	from finlast 
		JOIN fin on fin.idfin=finlast.idfin
		JOIN #finlookup FL1 	ON   finlast.idfin = FL1.newidfin 	
		join finlast fl_old on fl_old.idfin=FL1.oldidfin
		left outer JOIN accountlookup ON fl_old.idacc = accountlookup.oldidacc
		WHERE fin.ayear = @ayear
		AND nlevel = @minlevop
	
	INSERT INTO finlookup
	(
		newidfin,
		oldidfin,
		cu, ct, lu, lt
	)
	SELECT
		newidfin,
		oldidfin,
		cu, ct, lu, lt
	FROM    #finlookup
	WHERE   NOT EXISTS (SELECT * FROM finlookup F 
			    WHERE F.oldidfin = #finlookup.oldidfin
                            AND   F.newidfin = #finlookup.newidfin)

	-- Non devo inserire finlink, lo fa già il trigger

	INSERT INTO #info
	VALUES('Le voci di bilancio per l''esercizio ' + @nextayearstr+' sono state copiate')
END

	
IF NOT EXISTS (SELECT * FROM finsorting WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @nextayear))
BEGIN
	INSERT INTO finsorting  
	(
		idsor,
		idfin,
		quota,
		cu, ct, lu, lt
	)
	SELECT DISTINCT
	finsorting.idsor,
	FL1.newidfin, 
	finsorting.quota,
	finsorting.cu, GETDATE(), finsorting.lu, GETDATE()
	FROM finsorting
	JOIN fin
	ON fin.idfin = finsorting.idfin
	JOIN finlookup FL1
		ON finsorting.idfin = FL1.oldidfin
	WHERE fin.ayear = @ayear

	INSERT INTO #info
	VALUES('Le classificazioni del bilancio per l''esercizio ' + @nextayearstr+' sono state copiate.')
END
	
IF NOT EXISTS (SELECT * FROM sortingprev WHERE ayear = @nextayear)
BEGIN
	INSERT INTO sortingprev
	(
		idsor, ayear,
		incomeprevision, expenseprevision,
		cu, ct, lu, lt
	)
	SELECT
	idsor, @nextayear,
	NULL, NULL,
	cu, GETDATE(), lu, GETDATE()
	FROM sortingprev
	WHERE ayear = @ayear
	
	INSERT INTO #info
	VALUES('Le previsioni delle classificazioni movimenti per l''esercizio ' + @nextayearstr+' sono state copiate.')
END

IF ( NOT exists(SELECT * FROM treasurerstart WHERE ayear = @nextayear)
	AND (SELECT COUNT(*) FROM treasurerstart WHERE ayear = @ayear)>0 )
BEGIN
	INSERT INTO treasurerstart(ayear,idtreasurer,amount,ct,cu,lt,lu) 
	SELECT 
		@nextayear,
		treasurerstart.idtreasurer,
		treasurercashtotal.currentfloatfund,
		getdate(),
		'CHIUSURA',
		getdate(),
		'CHIUSURA'
	FROM treasurerstart
	JOIN treasurercashtotal
		ON treasurerstart.ayear = treasurercashtotal.ayear
		AND treasurerstart.idtreasurer = treasurercashtotal.idtreasurer
	WHERE treasurerstart.ayear = @ayear		
	
		
	INSERT INTO #info
	VALUES('Il Saldo iniziale di Cassa per l''esercizio ' + @nextayearstr+' è stato copiato.')
			
END



IF ( NOT exists(SELECT * FROM underwritingyear WHERE ayear = @nextayear)
	AND (SELECT COUNT(*) FROM underwritingyear WHERE ayear = @ayear)>0 )
BEGIN
	INSERT INTO underwritingyear(idunderwriting,ayear,ct,cu,lt,lu) 
	SELECT 
		underwritingyear.idunderwriting,
		@nextayear,
		getdate(),
		'CHIUSURA',
		getdate(),
		'CHIUSURA'
	FROM underwritingyear
	JOIN underwriting
		ON underwriting.idunderwriting = underwritingyear.idunderwriting
		AND isnull(underwriting.active,'N') = 'S'
	WHERE underwritingyear.ayear = @ayear		
	
		
	INSERT INTO #info
	VALUES('I Finanziamenti per l''esercizio ' + @nextayearstr+' sono stati copiati.')
			
END

IF ( NOT exists(SELECT * FROM upbyear WHERE ayear = @nextayear)
	AND (SELECT COUNT(*) FROM upbyear WHERE ayear = @ayear)>0 )
Begin
	insert into upbyear(idupb,ayear,revenueprevision, costprevision,locked, lt,lu,ct,cu)
	select
		upbyear.idupb,
		@nextayear,
		upbyear.revenueprevision,
		upbyear.costprevision,
		upbyear.locked,
		getdate(), 'CHIUSURA', getdate(), 'CHIUSURA'
	FROM upbyear
	JOIN upb
		ON upb.idupb = upbyear.idupb
	WHERE upbyear.ayear = @ayear		
			AND isnull(upb.active,'N') = 'S'

End

--azzero i bit da 0 a 3 e poi imposto il valore 2 su questi flag
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x02 WHERE ayear = @ayear

SELECT * FROM #info
	
EXEC rebuild_currentfloatfund @nextayear

exec rebuild_treasurercashtotal @nextayear
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


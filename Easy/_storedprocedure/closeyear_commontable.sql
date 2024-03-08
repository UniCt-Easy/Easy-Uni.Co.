
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_commontable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_commontable]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amministrazione'
CREATE  PROCEDURE closeyear_commontable
(
	@ayear int
)
AS BEGIN
/* Versione 1.0.1 del 09/10/2007 ultima modifica: MARIA */

CREATE TABLE #info (msg varchar(800))
DECLARE @nextayear int
SET @nextayear = @ayear + 1

DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)

-- La SP viene eseguita solo se in DBDEPARTMENT c'é una sola riga o se in caso di più righe l'utente corrente è l'amministrazione
IF ((SELECT COUNT(*) FROM dbdepartment) > 1 AND (UPPER(USER) <> 'AMMINISTRAZIONE')) RETURN

-- Traferimento di MAINACCOUNTINGYEAR
IF NOT EXISTS (SELECT * FROM mainaccountingyear WHERE ayear = @nextayear)
BEGIN
	INSERT INTO mainaccountingyear (ayear, completed, ct, cu, lt, lu)
	VALUES (@nextayear, 'N', GETDATE(), 'SA', GETDATE(), '''SA''')
		
	INSERT INTO #info VALUES('L'' esercizio ' + @nextayearstr+' è stato creato.')
END


IF NOT EXISTS (SELECT * FROM commonconfig WHERE ayear = @nextayear)
BEGIN
	INSERT INTO commonconfig (ayear, unifiedfinlevel, flagsepivapay,lt, lu) values(@nextayear, 2,'N', getdate(), 'trigger')
		
	if exists(select * from commonconfig where ayear =@ayear) 
		update commonconfig set unifiedfinlevel = (select unifiedfinlevel from commonconfig where ayear =@ayear)
			where ayear=@nextayear
			
		update commonconfig set flagsepivapay = (select flagsepivapay from commonconfig where ayear =@ayear)
			where ayear=@nextayear

END


DECLARE @minlevop tinyint
SELECT  @minlevop = unifiedfinlevel from commonconfig where ayear =@nextayear

IF NOT EXISTS (SELECT * FROM finlevel WHERE ayear = @nextayear AND nlevel <= @minlevop)
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
	AND nlevel <= @minlevop
	
	INSERT INTO #info
	VALUES('I livelli bilancio per l''esercizio ' + @nextayearstr+ ' sono stati copiati.')
END

-- trasferisco la tabella finlookup
DECLARE @maxidfin int
SET 	@maxidfin = (SELECT max(idfin) FROM fin)

CREATE TABLE #tempfin
(
	idfin    	int IDENTITY(1,1),
	paridfin 	int ,
	previdfin	int ,
	prevparidfin	int 	 
)

CREATE TABLE #tempfinlookup
(
	newidfin    	int ,
	oldidfin 	int ,
	cu		varchar(64), 
	ct		datetime, 
	lu		varchar(64), 
	lt 		datetime
)


-- Esegue il trasferimento dell'E/P, anticipato perchè finlast ora contiene un riferimento a idacc
EXECUTE closeyear_epcopy @ayear

-- Esegue il riempimento di accountlookup

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
	'commontable', getdate(), 'commontable', getdate()
FROM    #accountlookup
WHERE   NOT EXISTS (SELECT * FROM accountlookup AL1 
			WHERE AL1.oldidacc = #accountlookup.oldidacc
                        AND   AL1.newidacc = #accountlookup.newidacc)
	
IF NOT EXISTS (SELECT * FROM fin WHERE ayear = @nextayear AND nlevel <= @minlevop)
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
	AND nlevel <= @minlevop		
	
	INSERT INTO #tempfinlookup
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
		idfin,
		paridfin,
		nlevel, 
		--idman, 
		printingorder, title, 
		--expiration,
		ayear, codefin,
		flag, 
		cu, ct, lu, lt
	)
	SELECT
		FL1.newidfin,
		FL2.newidfin,
		nlevel, 
		--idman, 
		printingorder, title, 
		--expiration,
		@nextayear, codefin,
		flag,
		fin.cu, GETDATE(), fin.lu, GETDATE()
	FROM fin
	JOIN #tempfinlookup FL1
		ON   fin.idfin = FL1.oldidfin 
	LEFT OUTER JOIN #tempfinlookup FL2
		ON   fin.paridfin = FL2.oldidfin 
	WHERE ayear = @ayear
	AND nlevel <= @minlevop
	order by nlevel 
	
	INSERT INTO finlast
	(
		idfin,
		idman, 
		expiration, cupcode,idacc,
		cu, ct, lu, lt
	)
	SELECT 
		FL1.newidfin,
		idman, --non viene replicato
		expiration, cupcode,accountlookup.newidacc,
		finlast.cu, GETDATE(), finlast.lu, GETDATE() 
	FROM finlast
	JOIN fin
		ON finlast.idfin = fin.idfin
	JOIN #tempfinlookup FL1
		ON   finlast.idfin = FL1.oldidfin
	JOIN accountlookup ON finlast.idacc = accountlookup.oldidacc
	WHERE ayear = @ayear
	AND nlevel <= @minlevop
	
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
	FROM    #tempfinlookup
	
	-- Non devo scrivere in finlink lo fa già il trigger
END

UPDATE mainaccountingyear SET completed = 'S' WHERE ayear = @ayear

SELECT * FROM #info
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

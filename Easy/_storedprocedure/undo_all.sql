
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

if exists (select * from dbo.sysobjects where id = object_id(N'[undo_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [undo_all]
GO

CREATE PROCEDURE undo_all
(
	@ayear int
)
AS BEGIN
-- Il parametro indica l'esercizio nel quale avverranno le cancellazioni
-- Ad esempio se specifico 2030 vuol dire che sto cancellando i dati dell'esercizio 2030
-- Nel caso esistano residui di entrata e/o spesa nell'anno la procedura non farà assolutamente nulla


IF (SELECT COUNT(*) FROM incometotal WHERE ayear = @ayear AND (flag & 1 <> 0)) > 0
OR (SELECT COUNT(*) FROM expensetotal WHERE ayear = @ayear AND (flag & 1 <> 0)) > 0
BEGIN
	PRINT 'Esistono dei residui di entrata e/o di spesa. Procedura interrotta'
	RETURN
END

-- Tabelle che referenziano fin:

-- FINYEAR
PRINT 'Cancellazione di FINYEAR...'
DELETE FROM finyear WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)

-- FINSORTING
PRINT 'Cancellazione di FINSORTING...'
DELETE FROM finsorting WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)

-- UPBTOTAL
PRINT 'Cancellazione di UPBTOTAL...'
DELETE FROM upbexpensetotal WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)

-- UPBEXPENSETOTAL
PRINT 'Cancellazione di UPBEXPENSETOTAL...'
DELETE FROM upbtotal WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)

-- UPBUNDERWRITINGTOTAL
PRINT 'Cancellazione di UPBEXPENSETOTAL...'
DELETE FROM upbunderwritingtotal WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)

-- UPBINCOMETOTAL
PRINT 'Cancellazione di UPBINCOMETOTAL...'
DELETE FROM upbincometotal WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)

-- PARTINCOMESETUP
PRINT 'Cancellazione di PARTINCOMESETUP...'
DELETE FROM partincomesetup WHERE idfinincome IN (SELECT idfin FROM fin WHERE ayear = @ayear)
DELETE FROM partincomesetup WHERE idfinexpense IN (SELECT idfin FROM fin WHERE ayear = @ayear)



-- Cancellazione totale del bilancio solo se in DBDEPARTMENT c'é una sola riga 
-- o se in caso di più righe l'utente corrente è l'amministrazione
IF ( 
    ((SELECT COUNT(*) FROM dbdepartment) > 1 AND UPPER(USER) = 'AMMINISTRAZIONE')  OR
    ((SELECT COUNT(*) FROM dbdepartment) = 1)
   )  
BEGIN
	
	-- Cancellazione delle tabelle
	-- FINLINK
	PRINT 'Cancellazione di FINLINK...'
	DELETE FROM finlink WHERE idchild IN (SELECT idfin FROM fin WHERE ayear = @ayear)
	
	-- FINLAST
	PRINT 'Cancellazione di FINLAST...'
	DELETE FROM finlast WHERE idfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)
	
	-- FINLOOKUP
	PRINT 'Cancellazione di FINLOOKUP...'
	DELETE FROM finlookup WHERE newidfin IN (SELECT idfin FROM fin WHERE ayear = @ayear)
	DELETE FROM finlookup WHERE oldidfin IN (SELECT idfin FROM fin WHERE ayear = @ayear -1)
	
	-- FINLEVEL
	PRINT 'Cancellazione di FINLEVEL...'
	DELETE FROM finlevel WHERE ayear = @ayear
	
	-- FIN
	PRINT 'Cancellazione di FIN...'
	DELETE FROM fin WHERE ayear = @ayear
END
ELSE
BEGIN
	DECLARE @unifiedlevel  tinyint 
	SELECT  @unifiedlevel = unifiedfinlevel from commonconfig where ayear =@ayear
	
	PRINT 'Cancellazione di FINLINK...'
	DELETE FROM finlink WHERE idchild IN 
	(SELECT idfin FROM fin WHERE ayear = @ayear AND nlevel > @unifiedlevel)
	
	-- FINLAST
	PRINT 'Cancellazione di FINLAST...'
	DELETE FROM finlast WHERE idfin IN 
	(SELECT idfin FROM fin WHERE ayear = @ayear AND nlevel > @unifiedlevel)
	
	-- FINLOOKUP
	PRINT 'Cancellazione di FINLOOKUP...'
	DELETE FROM finlookup WHERE newidfin IN 
	(SELECT idfin FROM fin WHERE ayear = @ayear AND nlevel > @unifiedlevel)
	
	-- FINLEVEL
	PRINT 'Cancellazione di FINLEVEL...'
	DELETE FROM finlevel WHERE ayear = @ayear AND nlevel > @unifiedlevel
		
	-- FIN
	PRINT 'Cancellazione di FIN...'
	DELETE FROM fin WHERE ayear = @ayear AND nlevel > @unifiedlevel
	
END

-- FINVARDETAIL
PRINT 'Cancellazione di FINVARDETAIL...'
DELETE FROM finvardetail WHERE yvar = @ayear

-- FINVAR
PRINT 'Cancellazione di FINVAR...'
DELETE FROM finvar WHERE yvar = @ayear

-- PREVFINDETAIL
PRINT 'Cancellazione di PREVFINDETAIL...'
DELETE FROM prevfindetail WHERE ayear = (@ayear - 1)

-- PREVFIN
PRINT 'Cancellazione di PREVFIN...'
DELETE FROM prevfin WHERE ayear = (@ayear - 1)

-- PATRIMONYLEVEL
PRINT 'Cancellazione di PATRIMONYLEVEL...'
DELETE FROM patrimonylevel WHERE ayear = @ayear

-- PATRIMONYLOOKUP
PRINT 'Cancellazione di PATRIMONYLOOKUP...'
DELETE FROM patrimonylookup WHERE newidpatrimony IN (SELECT idpatrimony FROM patrimony WHERE ayear = @ayear)
DELETE FROM patrimonylookup WHERE oldidpatrimony IN (SELECT idpatrimony FROM patrimony WHERE ayear = @ayear)

-- PATRIMONY
PRINT 'Cancellazione di PATRIMONY...'
DELETE FROM patrimony WHERE ayear = @ayear

-- PLACCOUNTLEVEL
PRINT 'Cancellazione di PLACCOUNTLEVEL...'
DELETE FROM placcountlevel WHERE ayear = @ayear

-- PLACCOUNTLOOKUP
PRINT 'Cancellazione di PLACCOUNTLOOKUP...'
DELETE FROM placcountlookup WHERE newidplaccount IN (SELECT idplaccount FROM placcount WHERE ayear = @ayear)
DELETE FROM placcountlookup WHERE oldidplaccount IN (SELECT idplaccount FROM placcount WHERE ayear = @ayear)

-- PLACCOUNT
PRINT 'Cancellazione di PLACCOUNT...'
DELETE FROM placcount WHERE ayear = @ayear

-- ACCOUNTLEVEL
PRINT 'Cancellazione di ACCOUNTLEVEL...'
DELETE FROM accountlevel WHERE ayear = @ayear

-- ACCOUNTLOOKUP
PRINT 'Cancellazione di ACCOUNTLOOKUP...'
DELETE FROM accountlookup WHERE newidacc IN (SELECT idacc FROM account WHERE ayear = @ayear)
DELETE FROM accountlookup WHERE oldidacc IN (SELECT idacc FROM account WHERE ayear = @ayear)

-- ACCOUNTSORTING
PRINT 'Cancellazione di ACCOUNTSORTING...'
DELETE FROM accountsorting WHERE idacc IN (SELECT idacc FROM account WHERE ayear = @ayear)

-- ACCOUNT
PRINT 'Cancellazione di ACCOUNT...'
DELETE FROM account WHERE ayear = @ayear

-- SORTINGPREV
PRINT 'Cancellazione di SORTINGPREV...'
DELETE FROM sortingprev WHERE ayear = @ayear

-- TAXSETUP
PRINT 'Cancellazione di TAXSETUP...'
DELETE FROM taxsetup WHERE ayear = @ayear

-- AUTOINCOMESORTING
PRINT 'Cancellazione di AUTOINCOMESORTING...'
DELETE FROM autoincomesorting WHERE ayear = @ayear

-- AUTOEXPENSESORTING
PRINT 'Cancellazione di AUTOEXPENSESORTING...'
DELETE FROM autoexpensesorting WHERE ayear = @ayear

-- SORTINGINCOMEFILTER
PRINT 'Cancellazione di SORTINGINCOMEFILTER...'
DELETE FROM sortingincomefilter WHERE ayear = @ayear

-- SORTINGEXPENSEFILTER
PRINT 'Cancellazione di SORTINGEXPENSEFILTER...'
DELETE FROM sortingexpensefilter WHERE ayear = @ayear

-- TAXSORTINGSETUP
PRINT 'Cancellazione di TAXSORTINGSETUP...'
DELETE FROM taxsortingsetup WHERE ayear = @ayear

-- TAXPAYMENTPARTSETUP
PRINT 'Cancellazione di TAXPAYMENTPARTSETUP...'
DELETE FROM taxpaymentpartsetup WHERE ayear = @ayear

-- TRASMISSIONMANAGER
PRINT 'Cancellazione di TRASMISSIONMANAGER...'
DELETE FROM trasmissionmanager WHERE ayear = @ayear

-- CLAWBACKSETUP
PRINT 'Cancellazione di CLAWBACKSETUP...'
DELETE FROM clawbacksetup WHERE ayear = @ayear

-- ACCMOTIVEDETAIL
PRINT 'Cancellazione di ACCMOTIVEDETAIL...'
DELETE FROM accmotivedetail WHERE ayear = @ayear

-- FINMOTIVEDETAIL
PRINT 'Cancellazione di FINMOTIVEDETAIL...'
DELETE FROM finmotivedetail WHERE ayear = @ayear

-- INVOICEKINDYEAR
PRINT 'Cancellazione di INVOICEKINDYEAR...'
DELETE FROM invoicekindyear WHERE ayear = @ayear

--FLOWCHART
PRINT 'Cancellazione di FLOWCHART...'
DECLARE @ayearstr varchar(4)
SET @ayearstr = CONVERT(varchar(4),@ayear)

DELETE FROM flowchart 	   WHERE ayear = @ayear
DELETE FROM flowchartlevel WHERE ayear = @ayear
DELETE FROM flowchartuser  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'

DELETE FROM flowchartexportmodule WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartfin  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%' 
DELETE FROM flowchartmanager WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%' 
DELETE FROM flowchartmodulegroup WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartrestrictedfunction WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartsorting WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartupb  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'

DELETE FROM flowchartmandatekind  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartestimatekind  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartinvoicekind  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartpettycash  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'

DELETE FROM flowchartauthmodel  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'
DELETE FROM flowchartauthagency  WHERE idflowchart like SUBSTRING(@ayearstr, 3, 2) + '%'


-- CONFIG
PRINT 'Cancellazione di CONFIG...'
DELETE FROM config WHERE ayear = @ayear


IF ( 
    ((SELECT COUNT(*) FROM dbdepartment) > 1 AND UPPER(USER) = 'AMMINISTRAZIONE')  OR
    ((SELECT COUNT(*) FROM dbdepartment) = 1)
   ) 
BEGIN
	-- MAINACCOUNTINGYEAR
	DELETE FROM mainaccountingyear WHERE ayear = @ayear
	UPDATE mainaccountingyear SET completed = 'N' WHERE ayear = (@ayear - 1)
END

-- ACCOUNTINGYEAR
DELETE FROM accountingyear WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag&0x0 WHERE ayear = @ayear -1

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



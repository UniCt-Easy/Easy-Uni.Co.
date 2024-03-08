
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


--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_finsetupcopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_finsetupcopy]
GO
 --setuser 'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON  
GO
--[closeyear_undo_finsetupcopy] 2021
--[closeyear_finsetupcopy] 2021
--setuser 'amministrazione'
CREATE PROCEDURE [closeyear_finsetupcopy]
(
	@ayear int
)
AS BEGIN
 
 
DECLARE @OLDcodesorkind_siopespese varchar(20)
DECLARE @OLDcodesorkind_siopeentrate varchar(20)


SELECT  @OLDcodesorkind_siopespese  =  
CASE  
	WHEN  (@ayear<= 2006) THEN  'SIOPE'
	WHEN  (@ayear BETWEEN 2007 AND 2017) THEN  '07U_SIOPE'
END

SELECT  @OLDcodesorkind_siopeentrate  =  
CASE  
	WHEN  (@ayear<= 2006) THEN  'SIOPE'
	WHEN  (@ayear BETWEEN 2007 AND 2017) THEN  '07E_SIOPE'
END
declare @idsorkind_SIOPE_U_18 int
declare @idsorkind_SIOPE_E_18 int

select	@idsorkind_SIOPE_U_18 = idsorkind from sortingkind where codesorkind='SIOPE_U_18'
select	@idsorkind_SIOPE_E_18 = idsorkind from sortingkind where codesorkind='SIOPE_E_18'


CREATE TABLE #log (message varchar(255))

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
	'finsetupcopy', getdate(), 'finsetupcopy', getdate()
FROM    #accountlookup
WHERE   NOT EXISTS (SELECT * FROM accountlookup AL1 
			WHERE AL1.oldidacc = #accountlookup.oldidacc
                        AND   AL1.newidacc = #accountlookup.newidacc)

--setuser 'amm'
-- exec [closeyear_finsetupcopy] 
-- Esegue il trasferimento della configurazione dell'E/P

EXECUTE closeyear_epsetupcopy @ayear

CREATE TABLE #finlookup (oldidfin int, newidfin int)
	
INSERT #finlookup
EXECUTE closeyear_fillconvbilancio @ayear

DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)


DECLARE @startayearstr varchar(4)
SET @startayearstr = CONVERT(varchar(4),@ayear)


UPDATE 	config SET idinpscenter = COLD.idinpscenter
	FROM config
	JOIN config COLD
	ON config.ayear = (COLD.ayear + 1)
	WHERE COLD.ayear = @ayear
	AND config.ayear =  @nextayear

INSERT INTO #log
	VALUES('La configurazione dell''avanzo cassa e amministrazione ' + @nextayearstr+' è stata copiata.')

UPDATE config
SET
	electronictrasmission = oldconfig.electronictrasmission,
	flagbank_grouping = oldconfig.flagbank_grouping,
	motiveprefix = oldconfig.motiveprefix, 
	motiveseparator = oldconfig.motiveseparator, 
	motivelen = oldconfig.motivelen,
	appname = oldconfig.appname, 
	electronicimport = oldconfig.electronicimport, 
	importappname = oldconfig.importappname,
	idpaymethodabi = oldconfig.idpaymethodabi,
	idpaymethodnoabi = oldconfig.idpaymethodnoabi
FROM config, config oldconfig
WHERE config.ayear = @nextayear
AND oldconfig.ayear = @ayear

INSERT INTO #log
	VALUES('La configurazione per la trasm.elettronica dell''esercizio ' + @nextayearstr+' è stata copiata.')

-- CUD activitycode
UPDATE config
SET
	cudactivitycode = oldconfig.cudactivitycode,
        flagfruitful = oldconfig.flagfruitful,
        finvarofficial_default = oldconfig.finvarofficial_default
FROM config, config oldconfig
WHERE config.ayear = @nextayear
AND oldconfig.ayear = @ayear

INSERT INTO #log VALUES('Trasferito il Codice Attività  per il CUD, Flag Fruttifero, Flag variazioni per esercizio ' + @nextayearstr)

--invoicesetup
UPDATE  config
SET
	agencycode 		= COLD.agencycode,
	deferredexpensephase 	= COLD.deferredexpensephase, 
	deferredincomephase  	= COLD.deferredincomephase, 
	flagpayment 		= COLD.flagpayment, 
	flagrefund 		= COLD.flagrefund, 
	idfinivapayment 	= finivapayment.newidfin, 
	idfinivarefund 		= finivarefund.newidfin,
	idivapayperiodicity 	= COLD.idivapayperiodicity,
	minpayment 		= COLD.minpayment,
	minrefund  		= COLD.minrefund,
	paymentagency 		= COLD.paymentagency,
	refundagency 		= COLD.refundagency,
	flagivapaybyrow		= COLD.flagivapaybyrow,
	mainflagpayment = COLD.mainflagpayment,
	mainflagrefund = COLD.mainflagrefund,
	mainidfinivapayment = MAINfinivapayment.newidfin,
	mainidfinivarefund = MAINfinivarefund.newidfin,
	mainidfinivapayment12 = MAINfinivapayment12.newidfin,
	mainidfinivarefund12 = MAINfinivarefund12.newidfin,
	mainminpayment = COLD.mainminpayment,
	mainminrefund = COLD.mainminrefund,
	mainpaymentagency = COLD.mainpaymentagency,
	mainrefundagency = COLD.mainrefundagency,
	flagpayment12 = COLD.flagpayment12,
	flagrefund12 = COLD.flagrefund12,
	idfinivapayment12 = finivapayment12.newidfin,
	idfinivarefund12 = finivarefund12.newidfin,
	minpayment12 = COLD.minpayment12,
	minrefund12 = COLD.minrefund12,
	paymentagency12 = COLD.paymentagency12,
	refundagency12 = COLD.refundagency12,
	mainflagpayment12 = COLD.mainflagpayment12,
	mainflagrefund12 = COLD.mainflagrefund12,
	mainminpayment12 = COLD.mainminpayment12,
	mainminrefund12 = COLD.mainminrefund12,
	mainpaymentagency12 = COLD.mainpaymentagency12,
	mainrefundagency12 = COLD.mainrefundagency12,
	idfinincome_gross_csa = FININCOME_GROSS_CSA.newidfin,
	idsiopeincome_csa =  case when @ayear <> 2017 then COLD.idsiopeincome_csa  else null end,
	idfin_store = FIN_STORE.newidfin,
	paymentagencysplit= COLD.paymentagencysplit,
	flagpaymentsplit= COLD.flagpaymentsplit,
	idfinivapaymentsplit = FIN_SPLITPAYMENT.newidfin,
	idsor_siopeiva12exp = COLD.idsor_siopeiva12exp,
	idsor_siopeiva12inc = COLD.idsor_siopeiva12inc,
	idsor_siopeivaexp = COLD.idsor_siopeivaexp,
	idsor_siopeivainc = COLD.idsor_siopeivainc,
	idsor_siopeivasplitexp = COLD.idsor_siopeivasplitexp,
	flagsplitpayment = COLD.flagsplitpayment
	FROM config
JOIN config COLD
	ON config.ayear = (COLD.ayear + 1)
LEFT OUTER JOIN #finlookup finivapayment
	ON finivapayment.oldidfin = COLD.idfinivapayment
LEFT OUTER JOIN #finlookup finivarefund
	ON finivarefund.oldidfin = COLD.idfinivarefund

LEFT OUTER JOIN #finlookup MAINfinivapayment
	ON MAINfinivapayment.oldidfin = COLD.mainidfinivapayment
LEFT OUTER JOIN #finlookup MAINfinivarefund
	ON MAINfinivarefund.oldidfin = COLD.mainidfinivarefund

LEFT OUTER JOIN #finlookup finivapayment12
	ON finivapayment12.oldidfin = COLD.idfinivapayment12
LEFT OUTER JOIN #finlookup finivarefund12
	ON finivarefund12.oldidfin = COLD.idfinivarefund12

LEFT OUTER JOIN #finlookup MAINfinivapayment12
	ON MAINfinivapayment12.oldidfin = COLD.mainidfinivapayment12
LEFT OUTER JOIN #finlookup MAINfinivarefund12
	ON MAINfinivarefund12.oldidfin = COLD.mainidfinivarefund12
LEFT OUTER JOIN #finlookup FININCOME_GROSS_CSA
	ON FININCOME_GROSS_CSA.oldidfin = COLD.idfinincome_gross_csa
LEFT OUTER JOIN #finlookup FIN_STORE
	ON FIN_STORE.oldidfin = COLD.idfin_store
LEFT OUTER JOIN #finlookup FIN_SPLITPAYMENT
	ON FIN_SPLITPAYMENT.oldidfin = COLD.idfinivapaymentsplit
	
WHERE COLD.ayear = @ayear
AND config.ayear =  @nextayear

INSERT INTO #log VALUES('Trasferita configurazione IVA per esercizio ' + @nextayearstr)

--itinerationsetup
UPDATE config
SET
	idclawback 		= COLD.idclawback,
	idfinexpense 		= finexpense.newidfin,
	idaccmotive_admincar 	= COLD.idaccmotive_admincar,
	idaccmotive_owncar 	= COLD.idaccmotive_owncar,
	idaccmotive_foot  	= COLD.idaccmotive_foot,
	foreignhours   	  	= COLD.foreignhours,
	itineration_directauth = COLD.itineration_directauth
FROM config
JOIN config COLD
	ON config.ayear = (COLD.ayear + 1)
LEFT OUTER JOIN #finlookup finexpense
	ON finexpense.oldidfin = COLD.idfinexpense
WHERE COLD.ayear = @ayear
AND config.ayear = @nextayear

INSERT INTO #log
	VALUES('Trasferita configurazione Missioni per esercizio ' + @nextayearstr)

IF NOT EXISTS (SELECT * FROM pettycashsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO pettycashsetup
	(
		idpettycash, ayear,
		registrymanager,
		idfinincome, idfinexpense,
		amount, autoclassify, flag, idacc,
		idsor_siopeexp,idsor_siopeinc,
		cu, ct, lu, lt
	)
	SELECT
		idpettycash, @nextayear,
		registrymanager,
		finincome.newidfin, finexpense.newidfin,
		amount, autoclassify, flag, accountlookup.newidacc,
		idsor_siopeexp,idsor_siopeinc,
		'CLOSEYEAR', GETDATE(), 'CLOSEYEAR', GETDATE()
	FROM pettycashsetup
	LEFT OUTER JOIN #finlookup finincome
		ON finincome.oldidfin = pettycashsetup.idfinincome
	LEFT OUTER JOIN #finlookup finexpense
		ON finexpense.oldidfin = pettycashsetup.idfinexpense
	LEFT OUTER JOIN accountlookup
		ON accountlookup.oldidacc = pettycashsetup.idacc
	WHERE ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferita configurazione Fondo Economale per esercizio ' + @nextayearstr)
END
 
 IF NOT EXISTS (SELECT * FROM finmotivedetail WHERE ayear = @nextayear)
  BEGIN
 
	INSERT INTO finmotivedetail
	(
		ayear, idfin, idfinmotive,
		cu, ct, lu, lt
	)
	SELECT
		@nextayear, #finlookup.newidfin, idfinmotive,
		 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR', GETDATE()
	FROM finmotivedetail
		join #finlookup on finmotivedetail.idfin=#finlookup.oldidfin
	WHERE ayear = @ayear
	
	INSERT INTO #log VALUES('Trasferita associazione causali - bilancio per esercizio ' + @nextayearstr)
  END
  
  
IF NOT EXISTS (SELECT * FROM taxsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO taxsetup
	(
		taxcode, ayear,
		flag, paymentagency,
		idfinexpensecontra, idfinincomecontra,
		idfinexpenseemploy, idfinincomeemploy,
		flagadminfinance, idfinadmintax,
		idexpirationkind, expiringday, taxpaykind,
		cu, ct, lu, lt
	)
	SELECT
		taxcode, @nextayear,
		flag, paymentagency,
		paymentfin.newidfin, applicationfin.newidfin,
		expenseemploy.newidfin, incomeemploy.newidfin,
		flagadminfinance, adminfin.newidfin,
		idexpirationkind, expiringday, taxpaykind,
		'CLOSEYEAR', GETDATE(), 'CLOSEYEAR', GETDATE()
	FROM taxsetup
	LEFT OUTER JOIN #finlookup paymentfin
		ON paymentfin.oldidfin = taxsetup.idfinexpensecontra
	LEFT OUTER JOIN #finlookup applicationfin
		ON applicationfin.oldidfin = taxsetup.idfinincomecontra
	LEFT OUTER JOIN #finlookup adminfin
		ON adminfin.oldidfin = taxsetup.idfinadmintax
	LEFT OUTER JOIN #finlookup expenseemploy
		ON expenseemploy.oldidfin = taxsetup.idfinexpenseemploy
	LEFT OUTER JOIN #finlookup incomeemploy
		ON incomeemploy.oldidfin = taxsetup.idfinincomeemploy
	WHERE ayear = @ayear

	INSERT INTO #log
	VALUES('Trasferita configurazione automatismi ritenute per esercizio ' + @nextayearstr)
END
	
IF NOT EXISTS (SELECT * FROM taxregionsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO taxregionsetup
	(
		autoid,
		ayear,
		idplace,
		kind,
		regionalagency,
		taxcode,
		ct, cu, lt, lu
	)
	SELECT 
		autoid,
		@nextayear,
		idplace,
		kind,
		regionalagency,
		taxcode,
		GETDATE(), 'CLOSEYEAR', GETDATE(), 'CLOSEYEAR'
	FROM taxregionsetup
	WHERE ayear = @ayear

	INSERT INTO #log
	VALUES('Trasferita configurazione automatismi ritenute ripartizione regionale per esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM autoincomesorting WHERE autoincomesorting.ayear = @nextayear)
BEGIN
	INSERT INTO autoincomesorting
	(
		ayear, idautosort,
		defaultn1, defaultn2, defaultn3, defaultn4, defaultn5,
		defaults1, defaults2, defaults3, defaults4, defaults5,
		defaultv1, defaultv2, defaultv3, defaultv4, defaultv5,
		denominator, numerator, flagnodate,
		idupb, idfin, idman,
		idsorkind, idsor,
		idsorkindreg, idsorreg,
		ct, cu, lt, lu
	)
	SELECT 
		@nextayear, A.idautosort,
		A.defaultn1, A.defaultn2, A.defaultn3, A.defaultn4, A.defaultn5,
		A.defaults1, A.defaults2, A.defaults3, A.defaults4, A.defaults5,
		A.defaultv1, A.defaultv2, A.defaultv3, A.defaultv4, A.defaultv5,
		A.denominator, A.numerator, A.flagnodate,
		A.idupb, #finlookup.newidfin, A.idman,
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate)) then @idsorkind_SIOPE_E_18 else  A.idsorkind end ,
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate)) then null else A.idsor end ,
		A.idsorkindreg, A.idsorreg,
		GETDATE(), 'CLOSEYEAR', GETDATE(), '''CLOSEYEAR'''
	FROM autoincomesorting A
	JOIN sortingkind
		ON sortingkind.idsorkind = A.idsorkind
	LEFT OUTER JOIN #finlookup
		ON A.idfin = #finlookup.oldidfin
	WHERE (A.ayear = @ayear)
		AND (#finlookup.newidfin IS NOT NULL OR  A.idfin IS NULL) 
	INSERT INTO #log
	VALUES('Trasferita configurazione automatismi per la classificazione dei mov. di entrata ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM autoexpensesorting where autoexpensesorting.ayear = @nextayear)

BEGIN
	INSERT INTO autoexpensesorting
	(
		ayear, idautosort,
		defaultn1, defaultn2, defaultn3, defaultn4, defaultn5,
		defaults1, defaults2, defaults3, defaults4, defaults5,
		defaultv1, defaultv2, defaultv3, defaultv4, defaultv5,
		denominator, numerator, flagnodate,
		idupb, idfin, idman,
		idsorkind, idsor,
		idsorkindreg, idsorreg,
		ct, cu, lt, lu
	)
	SELECT 
		@nextayear, A.idautosort,
		A.defaultn1, A.defaultn2, A.defaultn3, A.defaultn4, A.defaultn5,
		A.defaults1, A.defaults2, A.defaults3, A.defaults4, A.defaults5,
		A.defaultv1, A.defaultv2, A.defaultv3, A.defaultv4, A.defaultv5,
		A.denominator, A.numerator, A.flagnodate,
		A.idupb, #finlookup.newidfin, A.idman,
		case when (@nextayear >= 2018 and sortingkind.codesorkind = @OLDcodesorkind_siopespese) then @idsorkind_SIOPE_U_18 else  A.idsorkind end ,
		case when (@nextayear >= 2018 and sortingkind.codesorkind = @OLDcodesorkind_siopespese) then null else A.idsor end ,
		A.idsorkindreg, 
		A.idsorreg,
		GETDATE(), 'CLOSEYEAR', GETDATE(), '''CLOSEYEAR'''
	FROM autoexpensesorting A
	JOIN sortingkind
		ON sortingkind.idsorkind = A.idsorkind
	LEFT OUTER JOIN #finlookup
		ON A.idfin = #finlookup.oldidfin
	WHERE (A.ayear = @ayear)
		AND (#finlookup.newidfin IS NOT NULL OR  A.idfin IS NULL) 
	INSERT INTO #log
	VALUES('Trasferita configurazione automatismi per la classificazione dei mov. di spesa ' + @nextayearstr)
END

IF NOT EXISTS(SELECT * FROM sortingincomefilter  WHERE sortingincomefilter.ayear = @nextayear)
BEGIN
	INSERT INTO sortingincomefilter
	(
		ayear, idautosort,
		idupb, idfin, idman,
		idsorkind, idsor,
		idsorkindreg, idsorreg,
		jointolessspecifics,
		ct, cu, lt, lu
	)
	SELECT 
		@nextayear, A.idautosort,
		A.idupb, #finlookup.newidfin, A.idman,
		A.idsorkind ,
		A.idsor ,
		A.idsorkindreg, A.idsorreg,
		A.jointolessspecifics,
		GETDATE(), 'CLOSEYEAR', GETDATE(), '''CLOSEYEAR'''
	FROM sortingincomefilter A
	JOIN sortingkind
		ON sortingkind.idsorkind = A.idsorkind
	LEFT OUTER JOIN #finlookup
		ON A.idfin = #finlookup.oldidfin
	WHERE (A.ayear = @ayear)
	-- questa condizione è necessaria perchè A.idsorkind e	A.idsor sono not null
	and (@nextayear >= 2018 and A.idsorkind = @idsorkind_SIOPE_E_18 
		OR
		@nextayear < 2018 and sortingkind.codesorkind = @OLDcodesorkind_siopeentrate
		)
	INSERT INTO #log
	VALUES('Trasferita configurazione filtri per la classificazione dei mov. di entrata ' + @nextayearstr)
END

IF NOT EXISTS(SELECT * FROM sortingexpensefilter WHERE sortingexpensefilter.ayear = @nextayear)
BEGIN
	INSERT INTO sortingexpensefilter
	(
		ayear, idautosort,
		idupb, idfin, idman,
		idsorkind, idsor,
		idsorkindreg, idsorreg,
		jointolessspecifics,
		ct, cu, lt, lu
	)
	SELECT 
		@nextayear, A.idautosort,
		A.idupb, #finlookup.newidfin, A.idman,
		A.idsorkind,
		A.idsor,
		A.idsorkindreg, A.idsorreg,
		A.jointolessspecifics,
		GETDATE(), 'CLOSEYEAR', GETDATE(), '''CLOSEYEAR'''
	FROM sortingexpensefilter A
	JOIN sortingkind
		ON sortingkind.idsorkind = A.idsorkind
	LEFT OUTER JOIN #finlookup
		ON A.idfin = #finlookup.oldidfin
	WHERE (A.ayear = @ayear)
	-- questa condizione è necessaria perchè A.idsorkind e	A.idsor sono not null
	and (@nextayear >= 2018 and A.idsorkind = @idsorkind_SIOPE_U_18 
		OR
		@nextayear < 2018 and sortingkind.codesorkind = @OLDcodesorkind_siopespese
		)

	INSERT INTO #log
	VALUES('Trasferita configurazione filtri per la classificazione dei mov. di spesa ' + @nextayearstr)
END


IF NOT EXISTS(SELECT * FROM autoclawbacksorting	 
			   WHERE autoclawbacksorting.ayear = @nextayear)
BEGIN
	INSERT INTO autoclawbacksorting
	(
		ayear,idautosort,idclawback,
		idsor,idsorkind,
		ct, cu, lt, lu
	)
	SELECT
		@nextayear, A.idautosort,
		A.idclawback,A.idsor,
		A.idsorkind,
		GETDATE(), 'CLOSEYEAR', GETDATE(), '''CLOSEYEAR'''
	FROM autoclawbacksorting A
	WHERE A.ayear = @ayear

	INSERT INTO #log
	VALUES('Trasferita configurazione classificazione dei recuperi ' + @nextayearstr)
END

IF NOT EXISTS(SELECT * FROM taxsortingsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO taxsortingsetup
	(
		ayear, idautotaxsor,
		flaginherit,
		idser, taxcode, 
		idsorkind,
		idsor_adminpay, idsor_adminproc,
		idsor_employproc, idsor_taxpay,
		ct, cu, lt, lu
	)
	SELECT
		@nextayear, A.idautotaxsor,
		A.flaginherit,
		A.idser, 
		A.taxcode, 
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate, @OLDcodesorkind_siopespese)) then null else  A.idsorkind end ,
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate, @OLDcodesorkind_siopespese)) then null else  A.idsor_adminpay end , 
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate, @OLDcodesorkind_siopespese)) then null else  A.idsor_adminproc end ,
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate, @OLDcodesorkind_siopespese)) then null else  A.idsor_employproc end , 
		case when (@nextayear >= 2018 and sortingkind.codesorkind IN (@OLDcodesorkind_siopeentrate, @OLDcodesorkind_siopespese)) then null else  A.idsor_taxpay end ,
		GETDATE(), 'CLOSEYEAR', GETDATE(), '''CLOSEYEAR'''
	FROM taxsortingsetup A
	JOIN sortingkind
		ON sortingkind.idsorkind = A.idsorkind
	WHERE (A.ayear = @ayear)

	
	INSERT INTO #log
	VALUES('Trasferita configurazione classificazione delle ritenute ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM taxpaymentpartsetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO taxpaymentpartsetup
	(
		taxcode, ayear,
		idreg, percentage,
		cu, ct, lu, lt
	)
	SELECT
		taxcode, @nextayear,
		idreg, percentage,
		'CLOSEYEAR', GETDATE(), 'CLOSEYEAR', GETDATE()
	FROM taxpaymentpartsetup
	WHERE ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferita configurazione automatismi ritenute percentuale esercizio ' + @nextayearstr)
END
	
IF NOT EXISTS (SELECT * FROM clawbacksetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO clawbacksetup
	(
		idclawback, ayear, clawbackfinance, idaccmotive,
		cu, ct, lu, lt
	)
	SELECT
		idclawback, @nextayear, clawbackfin.newidfin, idaccmotive,
		'CLOSEYEAR', GETDATE(), 'CLOSEYEAR', GETDATE()
	FROM clawbacksetup
	LEFT OUTER JOIN #finlookup clawbackfin
		ON clawbackfin.oldidfin = clawbacksetup.clawbackfinance
	WHERE ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferita configurazione automatismi recuperi per esercizio ' + @nextayearstr)
END
		
IF NOT EXISTS
	(SELECT * FROM partincomesetup WHERE idfinincome IN 
		(SELECT idfin FROM fin WHERE ayear = @nextayear)
	)
	AND NOT EXISTS
		(SELECT * FROM partincomesetup WHERE idfinexpense IN 
			(SELECT idfin FROM fin WHERE ayear = @nextayear)
		)
BEGIN
	INSERT INTO partincomesetup
	(
		idfinincome, idfinexpense, percentage,
		cu, ct, lu, lt
	)
	SELECT
		finincome.newidfin, finexpense.newidfin, percentage,
		'CLOSEYEAR', GETDATE(), 'CLOSEYEAR', GETDATE()
	FROM partincomesetup
	JOIN fin fi
		ON fi.idfin = partincomesetup.idfinincome
	JOIN fin fe
		ON fe.idfin = partincomesetup.idfinexpense
	LEFT OUTER JOIN #finlookup finincome
		ON finincome.oldidfin = partincomesetup.idfinincome
	LEFT OUTER JOIN #finlookup finexpense
		ON finexpense.oldidfin = partincomesetup.idfinexpense
	WHERE fi.ayear = @ayear AND fe.ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferite ripartizioni assegnazioni entrate per esercizio ' + @nextayearstr)
END
		

if not exists(SELECT * from finsorting FS join fin F on FS.idfin=F.idfin where F.ayear=@nextayear)
BEGIN
   INSERT into finsorting (ct,cu,lt,lu,quota,idfin,idsor)
	SELECT getdate(),'CLOSEYEAR',getdate(),'CLOSEYEAR',FS.quota,FL.newidfin,FS.idsor
	from finsorting FS 
	join fin F on FS.idfin=F.idfin
	JOIN sorting S ON FS.idsor = S.idsor
	JOIN sortingkind SK  ON SK.idsorkind = S.idsorkind
	JOIN #finlookup FL ON FS.idfin = FL.oldidfin
	WHERE F.ayear=@ayear 
		AND (@ayear <> 2017 OR (SK.codesorkind NOT IN (@OLDcodesorkind_siopeentrate,@OLDcodesorkind_siopespese)))
		AND (SELECT COUNT(*) from finsorting FF 
			JOIN #finlookup FFL ON FF.idfin = FFL.oldidfin
					where FF.idsor=FS.idsor and FL.newidfin=FFL.newidfin)=1
	INSERT INTO #log
	VALUES('Trasferite le classificazioni del bilancio per esercizio ' + @nextayearstr)

 
END

IF NOT EXISTS (SELECT * FROM accountsorting WHERE idacc IN 
	(SELECT idacc FROM account WHERE ayear = @nextayear))
BEGIN
		INSERT INTO accountsorting
		(
			idsor,
			idacc,
			quota,
			cu, ct, lu, lt
		)
		SELECT
		accountsorting.idsor,
		accountlookup.newidacc,
		quota,
		'CLOSEYEAR', GETDATE(), 'CLOSEYEAR', GETDATE()
		FROM accountsorting
		JOIN sorting S ON accountsorting.idsor = S.idsor
		JOIN sortingkind SK  ON SK.idsorkind = S.idsorkind
		join accountlookup on accountsorting.idacc=accountlookup.oldidacc
		WHERE SUBSTRING(idacc, 1,2) = SUBSTRING(CONVERT(char(4), @ayear), 3, 2)
		AND (@ayear <> 2017 OR (SK.codesorkind NOT IN (@OLDcodesorkind_siopeentrate,@OLDcodesorkind_siopespese)))
		
	
		INSERT INTO #log
		VALUES('Trasferite classificazioni voci del piano dei conti annuale per esercizio ' + @nextayearstr)
END

IF ((SELECT COUNT(*) FROM dbdepartment) = 1 OR (UPPER(USER) = 'AMMINISTRAZIONE')) 
BEGIN

  --IF NOT EXISTS (SELECT * FROM accmotivedetail WHERE ayear = @nextayear)
  --BEGIN
	INSERT INTO accmotivedetail
	(
		ayear, idacc, idaccmotive,
		cu, ct, lu, lt
	)
	SELECT
		@nextayear, AL.newidacc, A1.idaccmotive,
		 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR', GETDATE()
	FROM accmotivedetail A1
		join accountlookup AL on A1.idacc=AL.oldidacc		
	WHERE A1.ayear = @ayear and not exists(select * from accmotivedetail A2 where A2.idaccmotive=A1.idaccmotive and A2.ayear=@nextayear)
	
	INSERT INTO #log VALUES('Trasferita associazione causali - conti per esercizio ' + @nextayearstr)
  --END

END

  IF NOT EXISTS (SELECT * FROM epupbkindyear WHERE ayear = @nextayear)
  BEGIN
	INSERT INTO epupbkindyear
	(
		ayear, idepupbkind, idacc_cost,idacc_revenue,idacc_deferredcost,idacc_accruals,idacc_reserve,
		idaccmotive_cost,idaccmotive_revenue,idaccmotive_deferredcost,idaccmotive_accruals,idaccmotive_reserve,
		cu, ct, lu, lt,adjustmentkind
	)
	SELECT
		@nextayear, idepupbkind, acc_cost.newidacc,  acc_revenue.newidacc,  acc_deferredcost.newidacc,  acc_accruals.newidacc,  acc_reserve.newidacc, 
		idaccmotive_cost,idaccmotive_revenue,idaccmotive_deferredcost,idaccmotive_accruals,idaccmotive_reserve,
		 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR', GETDATE(), epupbkindyear.adjustmentkind
	FROM epupbkindyear
		left outer join accountlookup acc_cost on epupbkindyear.idacc_cost=acc_cost.oldidacc
		left outer join accountlookup acc_revenue on epupbkindyear.idacc_revenue=acc_revenue.oldidacc
		left outer join accountlookup acc_deferredcost on epupbkindyear.idacc_deferredcost=acc_deferredcost.oldidacc
		left outer join accountlookup acc_accruals on epupbkindyear.idacc_accruals=acc_accruals.oldidacc
		left outer join accountlookup acc_reserve on epupbkindyear.idacc_reserve=acc_reserve.oldidacc
	WHERE ayear = @ayear
	
	INSERT INTO #log VALUES('Trasferita configurazione tipi upb in economico patrimoniale' + @nextayearstr)
  END

  
IF NOT EXISTS (SELECT * FROM flowchartfin WHERE idflowchart like SUBSTRING(@nextayearstr, 3, 2) + '%')
BEGIN
	INSERT INTO flowchartfin
		(
			idflowchart,
			idfin,
			ct,cu,lt,lu
		)
	SELECT DISTINCT
		SUBSTRING(@nextayearstr, 3, 2) + SUBSTRING(idflowchart, 3, 32),
		FL.newidfin,
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM flowchartfin
		JOIN fin F on flowchartfin.idfin=F.idfin
		JOIN #finlookup FL ON flowchartfin.idfin = FL.oldidfin
		WHERE F.ayear=@ayear 
		AND idflowchart like SUBSTRING(@startayearstr, 3, 2) + '%'
	INSERT INTO #log
	VALUES('Trasferita configurazione sicurezza Bilancio nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contractkindyear WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contractkindyear
		(
			idcsa_contractkind,
			ayear,
			idupb,
			idacc_main,
			idfin_main,
			idsor_siope_main,
			ct,cu,lt,lu
		)
	SELECT
		csa_contractkindyear.idcsa_contractkind,
		@nextayear,
		csa_contractkindyear.idupb,
		AL.newidacc,
		FL.newidfin,
		case when @ayear <> 2017 then csa_contractkindyear.idsor_siope_main else null end,
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractkindyear
		JOIN csa_contractkind 
		  ON csa_contractkind.idcsa_contractkind = csa_contractkindyear.idcsa_contractkind
		LEFT OUTER JOIN #finlookup FL 
	          ON csa_contractkindyear.idfin_main = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL
		  ON AL.oldidacc = csa_contractkindyear.idacc_main
		WHERE csa_contractkindyear.ayear = @ayear
		AND   ISNULL(csa_contractkind.flagkeepalive,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferiti tipi contratti CSA nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contractkinddata WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contractkinddata
		(
			idcsa_contractkind,
			idcsa_contractkinddata,
			vocecsa,
			ayear,
			idacc,
			idfin,idupb,idsor_siope,
			ct,cu,lt,lu
		)
	SELECT
		csa_contractkinddata.idcsa_contractkind,
		csa_contractkinddata.idcsa_contractkinddata,
		vocecsa,
		@nextayear,
		AL.newidacc,
		FL.newidfin, csa_contractkinddata.idupb,
		case when @ayear <> 2017 then csa_contractkinddata.idsor_siope  else null end,
		GETDATE(),  'CLOSEYEAR' , GETDATE(),  'CLOSEYEAR'
		FROM csa_contractkinddata
		JOIN csa_contractkind 
		  ON csa_contractkind.idcsa_contractkind = csa_contractkinddata.idcsa_contractkind
		LEFT OUTER JOIN #finlookup FL 
	          ON csa_contractkinddata.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL
		  ON AL.oldidacc = csa_contractkinddata.idacc
		WHERE csa_contractkinddata.ayear = @ayear
		AND   ISNULL(csa_contractkind.flagkeepalive,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferite Attribuzioni tipi Contratti alle Voci CSA nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contractkindrules WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contractkindrules
		(
			idcsa_contractkind,
			idcsa_rule,
			capitoloCSA,
			ruoloCSA,
			ayear,
			ct,cu,lt,lu
		)
	SELECT
		csa_contractkindrules.idcsa_contractkind,
		csa_contractkindrules.idcsa_rule,
		capitoloCSA,
		ruoloCSA,
		@nextayear,
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractkindrules
		JOIN csa_contractkind 
		  ON csa_contractkind.idcsa_contractkind = csa_contractkindrules.idcsa_contractkind
		WHERE csa_contractkindrules.ayear = @ayear
		AND   ISNULL(csa_contractkind.flagkeepalive,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferite Regole di individuazione dei tipi di Contratti CSA nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_incomesetup WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_incomesetup
		(
			idcsa_incomesetup,
			idupb,
			idfin_income,
			idacc_debit,
			idfin_expense,
			idacc_expense,
			idfin_incomeclawback,
			idacc_internalcredit,
			vocecsa,
			idacc_agency_credit,
			idacc_revenue,
			ayear,
			idfin_cost,
			idacc_cost,
			idsor_siope_cost,
			vocecsaunified,
			ct,cu,lt,lu,
			flagdirectcsaclawback,idsor_siope_income,idsor_siope_expense,idsor_siope_incomeclawback
		)
	SELECT
			idcsa_incomesetup,
			idupb,
			FL_income.newidfin,
			AL_debit.newidacc,
			FL_expense.newidfin,
			AL_expense.newidacc,
			FL_incomeclawback.newidfin,
			AL_internalcredit.newidacc,
			vocecsa,
			AL_agency_credit.newidacc,
			AL_revenue.newidacc,
			@nextayear,
			FL_cost.newidfin ,
			AL_cost.newidacc ,
			case when @ayear <> 2017 then idsor_siope_cost  else null end,
			vocecsaunified,
			GETDATE(),  'CLOSEYEAR' , GETDATE(),  'CLOSEYEAR',
			flagdirectcsaclawback,
			case when @ayear <> 2017 then idsor_siope_income  else null end,
			case when @ayear <> 2017 then idsor_siope_expense  else null end,
			case when @ayear <> 2017 then idsor_siope_incomeclawback  else null end
		FROM csa_incomesetup
		LEFT OUTER JOIN #finlookup FL_income 		  ON csa_incomesetup.idfin_income = FL_income.oldidfin
		LEFT OUTER JOIN #finlookup FL_expense		  ON csa_incomesetup.idfin_expense = FL_expense.oldidfin
		LEFT OUTER JOIN #finlookup FL_incomeclawback   ON csa_incomesetup.idfin_incomeclawback  = FL_incomeclawback.oldidfin
		LEFT OUTER JOIN #finlookup FL_cost			  ON csa_incomesetup.idfin_cost = FL_cost.oldidfin
		LEFT OUTER JOIN accountlookup AL_debit		  ON AL_debit.oldidacc = csa_incomesetup.idacc_debit
		LEFT OUTER JOIN accountlookup AL_expense	  ON AL_expense.oldidacc = csa_incomesetup.idacc_expense
		LEFT OUTER JOIN accountlookup AL_internalcredit	  ON AL_internalcredit.oldidacc = csa_incomesetup.idacc_internalcredit
		LEFT OUTER JOIN accountlookup AL_agency_credit	  ON AL_agency_credit.oldidacc = csa_incomesetup.idacc_agency_credit
		LEFT OUTER JOIN accountlookup AL_revenue	  ON AL_revenue.oldidacc = csa_incomesetup.idacc_revenue
		LEFT OUTER JOIN accountlookup AL_cost		  ON AL_cost.oldidacc = csa_incomesetup.idacc_cost
		WHERE csa_incomesetup.ayear = @ayear
	INSERT INTO #log
	VALUES('Trasferita Configurazione Entrate CSA nel nuovo esercizio ' + @nextayearstr)
END
	
IF NOT EXISTS (SELECT * FROM csa_contract WHERE ayear = @nextayear)
BEGIN
		
	INSERT INTO csa_contract
		(
			idcsa_contract,
			ayear,
			ycontract,
			ncontract,
			idcsa_contractkind,
			description,
			title,
			flagkeepalive,
			idupb,
			idacc_main,
			idexp_main,idepexp_main,
			idfin_main,
			flagrecreate,
			active,
			idsor_siope_main,
			ct,cu,lt,lu
		)
	SELECT
			csa_contract.idcsa_contract,
			@nextayear,
			csa_contract.ycontract,
			csa_contract.ncontract,
			(
				SELECT TOP 1 CK2.idcsa_contractkind 
				FROM csa_contractkind CK1
				JOIN csa_contractkindyear CKY1
					ON CKY1.idcsa_contractkind = CK1.idcsa_contractkind 
				JOIN csa_contractkind CK2 
					ON ISNULL(CK2.flagcr,'C') = 'R'
					AND ISNULL(CK2.flagkeepalive,'N') = 'S'
					AND CK2.contractkindcode = CK1.contractkindcode
				JOIN csa_contractkindyear CKY2
					ON CKY2.idcsa_contractkind = CK2.idcsa_contractkind 
					AND CKY2.ayear = @ayear
				WHERE ISNULL(CK1.flagcr,'C') = 'C'
				AND CK1.idcsa_contractkind = csa_contract.idcsa_contractkind 
			),
			csa_contract.description,
			csa_contract.title,
			csa_contract.flagkeepalive,
			csa_contract.idupb,
			AL.newidacc,
			idexp_main,idepexp_main,
			FL.newidfin,
			csa_contract.flagrecreate,
			'S',  --active
			case when @ayear <> 2017 then csa_contract.idsor_siope_main  else null end,
			GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
			FROM csa_contract
			JOIN csa_contractkind 
				ON csa_contractkind.idcsa_contractkind = csa_contract.idcsa_contractkind
			LEFT OUTER JOIN #finlookup FL 
				ON csa_contract.idfin_main = FL.oldidfin
			LEFT OUTER JOIN accountlookup AL
				ON AL.oldidacc = csa_contract.idacc_main
		WHERE csa_contract.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(csa_contractkind.flagcr,'C') = 'C'
		AND ISNULL(csa_contract.active,'N') = 'S'
		AND EXISTS (
				SELECT TOP 1 CK2.idcsa_contractkind 
				FROM csa_contractkind CK1
				JOIN csa_contractkindyear CKY1
					ON CKY1.idcsa_contractkind = CK1.idcsa_contractkind 
				JOIN csa_contractkind CK2 
					ON ISNULL(CK2.flagcr,'C') = 'R'
					AND ISNULL(CK2.flagkeepalive,'N') = 'S'
					AND CK2.contractkindcode = CK1.contractkindcode
				JOIN csa_contractkindyear CKY2
					ON CKY2.idcsa_contractkind = CK2.idcsa_contractkind 
					AND CKY2.ayear = @ayear
				WHERE ISNULL(CK1.flagcr,'C') = 'C'
				AND CK1.idcsa_contractkind = csa_contract.idcsa_contractkind 
			)
	INSERT INTO #log
	VALUES('Trasferiti Contratti CSA di competenza nel nuovo esercizio ' + @nextayearstr)
	
	INSERT INTO csa_contract
		(
			idcsa_contract,	ayear,	ycontract,ncontract,idcsa_contractkind,	description,
			title,	flagkeepalive,idupb,idsor_siope_main ,idacc_main,idexp_main,	idfin_main,
			idepexp_main,
			flagrecreate,	active,		ct,cu,lt,lu
		)
	SELECT
			csa_contract.idcsa_contract,
			@nextayear,	csa_contract.ycontract,	csa_contract.ncontract,	csa_contract.idcsa_contractkind,
			csa_contract.description,csa_contract.title,csa_contract.flagkeepalive,
			csa_contract.idupb,	
			case when @ayear <> 2017 then csa_contract.idsor_siope_main  else null end,
			AL.newidacc,	idexp_main, --EY.idexp,
			FL.newidfin, idepexp_main,
			csa_contract.flagrecreate,	'S', --active
			GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
			FROM csa_contract
			JOIN csa_contractkind 
				ON csa_contractkind.idcsa_contractkind = csa_contract.idcsa_contractkind
			LEFT OUTER JOIN #finlookup FL 
				ON csa_contract.idfin_main = FL.oldidfin
			LEFT OUTER JOIN accountlookup AL
				ON AL.oldidacc = csa_contract.idacc_main
			--left outer join expenseyear EY 
			--	on EY.idexp = csa_contract.idexp_main and ey.ayear=@nextayear

			WHERE csa_contract.ayear = @ayear
			AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
			AND ISNULL(csa_contractkind.flagcr,'C') = 'R'
			AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferiti Contratti CSA residui nel nuovo esercizio ' + @nextayearstr)

END


IF NOT EXISTS (SELECT * FROM csa_contractregistry WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contractregistry
		(
			idcsa_contract,	idcsa_registry,	extmatricula,	idreg,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		csa_contractregistry.idcsa_contract,csa_contractregistry.idcsa_registry,	extmatricula,	idreg,
		@nextayear,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractregistry
		JOIN csa_contract 
		  ON csa_contract.idcsa_contract = csa_contractregistry.idcsa_contract
		 AND csa_contract.ayear = @ayear
		WHERE csa_contractregistry.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferite Matricole Contratti CSA nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contractexpense WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contractexpense
		(
			idcsa_contract,	ndetail,	quota,	idexp,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		csa_contractexpense.idcsa_contract,csa_contractexpense.ndetail,
		csa_contractexpense.quota,csa_contractexpense.idexp,
		@nextayear,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractexpense
		JOIN csa_contract 
		  ON csa_contract.idcsa_contract = csa_contractexpense.idcsa_contract
		 AND csa_contract.ayear = @ayear
		WHERE csa_contractexpense.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferiti collegamenti a mov.spesa CSA  nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contractepexp WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contractepexp
		(
			idcsa_contract,	ndetail,	quota,	idepexp,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		csa_contractepexp.idcsa_contract,csa_contractepexp.ndetail,
		csa_contractepexp.quota,csa_contractepexp.idepexp,
		@nextayear,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractepexp
		JOIN csa_contract 		  ON csa_contract.idcsa_contract = csa_contractepexp.idcsa_contract
										AND csa_contract.ayear = @ayear
		WHERE csa_contractepexp.ayear = @ayear
				AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
				AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferiti collegamenti a imp.budget CSA  nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contract_partition WHERE ayear = @nextayear)
BEGIN
	INSERT INTO csa_contract_partition
		(
			idcsa_contract,	ndetail,	quota,	ayear,
			idacc,idfin,idupb,idsor_siope,idepexp, idexp, ct,cu,lt,lu
		)
	SELECT
		csa_contract_partition.idcsa_contract,csa_contract_partition.ndetail, csa_contract_partition.quota,	@nextayear,
		AL.newidacc,FL.newidfin,csa_contract_partition.idupb,
		csa_contract_partition.idsor_siope,csa_contract_partition.idepexp,csa_contract_partition.idexp,
		GETDATE(), 'CLOSEYEAR_1', GETDATE(),  'CLOSEYEAR_1'
		FROM csa_contract_partition
		JOIN csa_contract 		  
				ON csa_contract.idcsa_contract = csa_contract_partition.idcsa_contract
				AND csa_contract.ayear = @ayear
		LEFT OUTER JOIN #finlookup FL 
				ON csa_contract_partition.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL
				ON AL.oldidacc = csa_contract_partition.idacc 
		WHERE csa_contract_partition.ayear = @ayear
				AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
				AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferita ripartizione regole specifiche CSA  nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contracttax_partition WHERE ayear = @nextayear)
BEGIN
INSERT INTO csa_contracttax_partition
		(
			idcsa_contract,	idcsa_contracttax,	ndetail,quota,idepexp,	ayear,
			idfin, idupb,idacc,idexp,idsor_siope,
			ct,cu,lt,lu
		)
	SELECT
		csa_contract.idcsa_contract,
		csa_contracttax_partition.idcsa_contracttax,
		csa_contracttax_partition.ndetail,csa_contracttax_partition.quota,
		csa_contracttax_partition.idepexp,
		@nextayear,
		FL.newidfin, csa_contracttax_partition.idupb,
		AL.newidacc, csa_contracttax_partition.idexp,
		csa_contracttax_partition.idsor_siope, 
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contracttax_partition
		JOIN csa_contract		 ON csa_contract.idcsa_contract = csa_contracttax_partition.idcsa_contract
									AND csa_contract.ayear = @ayear
		LEFT OUTER JOIN #finlookup FL 
				ON csa_contracttax_partition.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL
				ON AL.oldidacc = csa_contracttax_partition.idacc 
		WHERE csa_contracttax_partition.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferite Ripartizioni Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)
END

IF NOT EXISTS (SELECT * FROM csa_contracttax WHERE ayear = @nextayear)
BEGIN
print 'a'
	INSERT INTO csa_contracttax
		(
			idcsa_contract,			idcsa_contracttax,			vocecsa,
			idfin,	idexp,idepexp,	idacc,	idupb,	idsor_siope,	ayear,
			ct,cu,lt,lu
		)
	SELECT
			csa_contracttax.idcsa_contract,
			csa_contracttax.idcsa_contracttax,
			csa_contracttax.vocecsa,
			FL.newidfin,
			csa_contracttax.idexp, --EY.idexp,
			csa_contracttax.idepexp,
			AL.newidacc,
			csa_contracttax.idupb,
			case when @ayear <> 2017 then csa_contracttax.idsor_siope  else null end,
			@nextayear,
			GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contracttax
		JOIN csa_contract 
		  ON csa_contract.idcsa_contract = csa_contracttax.idcsa_contract
		  AND csa_contract.ayear = @ayear
		LEFT OUTER JOIN #finlookup FL 		  ON csa_contracttax.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL	  ON AL.oldidacc = csa_contracttax.idacc
		--left outer join expenseyear EY 
		--	on EY.idexp = csa_contracttax.idexp and ey.ayear=@nextayear
		WHERE csa_contracttax.ayear = @ayear
		AND ISNULL(csa_contract.flagkeepalive,'N') = 'S'
		AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Trasferite Config. Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)
END

	CREATE TABLE #temptaxmotiveyear
	(
		idtaxmotiveyear    	int IDENTITY(1,1),
		taxcode	int,
		idser	int,
		idaccmotive_debit	varchar(36),
		idaccmotive_cost	varchar(36),
		idaccmotive_pay	varchar(36),
		ayear	int
	)
	insert into #temptaxmotiveyear(
		ayear,
		taxcode,
		idser,
		idaccmotive_debit,	idaccmotive_cost,	idaccmotive_pay
	)
	select 
		@nextayear,
		taxcode,
		idser,
		idaccmotive_debit,	idaccmotive_cost,	idaccmotive_pay
	from taxmotiveyear
	where  ayear = @ayear
	and not exists(select * from taxmotiveyear t2 where t2.ayear=@nextayear and t2.taxcode=taxmotiveyear.taxcode)

	DECLARE @maxidtaxmotiveyear int
	SET 	@maxidtaxmotiveyear = (SELECT MAX(idtaxmotiveyear) FROM taxmotiveyear)

	insert into taxmotiveyear(
		idtaxmotiveyear, 
		ayear,
		taxcode,
		idser,
		idaccmotive_debit,	idaccmotive_cost,	idaccmotive_pay,
		cu, ct, lu, lt
		)
	select 
		idtaxmotiveyear + @maxidtaxmotiveyear,
		ayear,
		taxcode,
		idser,
		idaccmotive_debit,	idaccmotive_cost,	idaccmotive_pay,
		'finsetupcopy', GETDATE(), 'finsetupcopy', GETDATE() 
	from #temptaxmotiveyear

	INSERT INTO #log
	VALUES('Trasferite Associazione delle causali costo/debito alla prestazione nel nuovo esercizio ' + @nextayearstr)


-- in alcuni casi il contratto deve essere ricreato ex novo  (ovvero come contratto di competenza) nel nuovo esercizio
-- e devono essere ricreate le tabelle figlie csa_contracttax e csa_contractregistry

DECLARE @maxidcsa_contract int
DECLARE @maxncontract int
SET 	@maxidcsa_contract = (SELECT MAX(idcsa_contract) FROM csa_contract)
SET 	@maxncontract = (SELECT MAX(ncontract) FROM csa_contract WHERE ayear = @nextayear)
set @maxidcsa_contract  = isnull(@maxidcsa_contract,0)
set @maxncontract = isnull(@maxncontract,0)

CREATE TABLE #csa_contract
(
	oldidcsa_contract	int,
	newidcsa_contract	int identity(1,1),
	oldncontract		int,
	idcsa_contractkind  int
)

INSERT INTO #csa_contract
	(
		oldidcsa_contract,
		oldncontract
	)
 SELECT
		csa_contract.idcsa_contract,
		csa_contract.ncontract
 FROM csa_contract
 JOIN csa_contractkind	   ON csa_contractkind.idcsa_contractkind = csa_contract.idcsa_contractkind
 WHERE csa_contract.ayear = @ayear
 AND ISNULL(csa_contract.flagrecreate,'N') = 'S'
 AND ISNULL(csa_contractkind.flagcr,'C') = 'C'
 AND ISNULL(csa_contractkind.flagkeepalive,'N') = 'S'
 AND ISNULL(csa_contract.active,'N') = 'S'	

IF ((SELECT COUNT(*) FROM #csa_contract) > 0) 
BEGIN
INSERT INTO csa_contract
		(
			idcsa_contract,		ayear,	ycontract,	ncontract,
			idcsa_contractkind,	description,title,	flagkeepalive,
			idupb,idsor_siope_main,	idacc_main,	idexp_main,		idfin_main,
			idepexp_main,
			flagrecreate,	active,
			ct,cu,lt,lu
		)
		
	SELECT
			@maxidcsa_contract + #csa_contract.newidcsa_contract,
			@nextayear,	@nextayear,	@maxncontract + #csa_contract.newidcsa_contract,
			csa_contract.idcsa_contractkind,csa_contract.description,
			csa_contract.title,		csa_contract.flagkeepalive,		csa_contract.idupb,
			case when @ayear <> 2017 then csa_contract.idsor_siope_main  else null end,
			AL.newidacc,	csa_contract.idexp_main, --EY.idexp,
			FL.newidfin, idepexp_main,
			csa_contract.flagrecreate,
			'S', --active
			GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contract
			JOIN #csa_contract			ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
			LEFT OUTER JOIN #finlookup FL 		ON csa_contract.idfin_main = FL.oldidfin
			LEFT OUTER JOIN accountlookup AL	ON AL.oldidacc = csa_contract.idacc_main
		--left outer join expenseyear EY 
		--	on EY.idexp = csa_contract.idexp_main and ey.ayear=@nextayear
		WHERE csa_contract.ayear = @ayear
				AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreati Contratti CSA di competenza nel nuovo esercizio ' + @nextayearstr)
		select * from #csa_contract

	INSERT INTO csa_contractexpense
		(
			idcsa_contract,		ndetail,	quota,	idexp,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contractexpense.ndetail,
		csa_contractexpense.quota,csa_contractexpense.idexp,
		@nextayear,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractexpense
		JOIN csa_contract 		  ON csa_contract.idcsa_contract = csa_contractexpense.idcsa_contract
									AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		WHERE csa_contractexpense.ayear = @ayear
			AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreati collegamenti a mov.spesa CSA  nel nuovo esercizio' + @nextayearstr)
		SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contractepexp.ndetail,
		csa_contractepexp.quota,csa_contractepexp.idepexp,
		@nextayear,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractepexp 
		JOIN csa_contract 		  ON csa_contract.idcsa_contract = csa_contractepexp.idcsa_contract
									AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		WHERE csa_contractepexp.ayear = @ayear
			AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreati collegamenti a impegni budget CSA  nel nuovo esercizio' + @nextayearstr)
	
	INSERT INTO csa_contractepexp 
		(
			idcsa_contract,		ndetail,	quota,	idepexp,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contractepexp.ndetail,
		csa_contractepexp.quota,csa_contractepexp.idepexp,
		@nextayear,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractepexp 
		JOIN csa_contract 		  ON csa_contract.idcsa_contract = csa_contractepexp.idcsa_contract
									AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		WHERE csa_contractepexp.ayear = @ayear
			AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreati collegamenti a impegni budget CSA  nel nuovo esercizio' + @nextayearstr)
 
	INSERT INTO csa_contract_partition
		(
			idcsa_contract,	ndetail,	quota,	ayear,
			idacc,idfin,idupb,idsor_siope,idepexp, idexp, ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,csa_contract_partition.ndetail, csa_contract_partition.quota,	@nextayear,
		AL.newidacc,FL.newidfin,csa_contract_partition.idupb,
		csa_contract_partition.idsor_siope,csa_contract_partition.idepexp,csa_contract_partition.idexp,
		GETDATE(), 'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contract_partition
		JOIN csa_contract 		  
				ON csa_contract.idcsa_contract = csa_contract_partition.idcsa_contract
				AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		LEFT OUTER JOIN #finlookup FL 
				ON csa_contract_partition.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL
				ON AL.oldidacc = csa_contract_partition.idacc 
		WHERE csa_contract_partition.ayear = @ayear
				AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
 	VALUES('Ricreati ripartizioni contratti  CSA  nel nuovo esercizio' + @nextayearstr)



	INSERT INTO csa_contractregistry
		(
			idcsa_contract,	idcsa_registry,	extmatricula,idreg,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contractregistry.idcsa_registry,
		extmatricula,
		idreg,
		@nextayear,
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contractregistry
		JOIN csa_contract 
		  ON csa_contract.idcsa_contract = csa_contractregistry.idcsa_contract
		 AND csa_contract.ayear = @ayear
		JOIN #csa_contract 
				ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		WHERE csa_contractregistry.ayear = @ayear
			AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreate Matricole Contratti CSA nel nuovo esercizio ' + @nextayearstr)

	INSERT INTO csa_contracttaxexpense
		(
			idcsa_contract,	idcsa_contracttax,	ndetail,quota,idexp,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contracttaxexpense.idcsa_contracttax,
		csa_contracttaxexpense.ndetail,csa_contracttaxexpense.quota,
		csa_contracttaxexpense.idexp,
		@nextayear,
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contracttaxexpense
		JOIN csa_contract		 ON csa_contract.idcsa_contract = csa_contracttaxexpense.idcsa_contract
									AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		WHERE csa_contracttaxexpense.ayear = @ayear 	AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreati collegamenti a mov.spesa contratti CSA ricreati nel nuovo esercizio ' + @nextayearstr)

	INSERT INTO csa_contracttaxepexp
		(
			idcsa_contract,	idcsa_contracttax,	ndetail,quota,idepexp,	ayear,
			ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contracttaxepexp.idcsa_contracttax,
		csa_contracttaxepexp.ndetail,csa_contracttaxepexp.quota,
		csa_contracttaxepexp.idepexp,
		@nextayear,
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contracttaxepexp
		JOIN csa_contract		 ON csa_contract.idcsa_contract = csa_contracttaxepexp.idcsa_contract
									AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		WHERE csa_contracttaxepexp.ayear = @ayear	AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreati collegamenti a imp.budget contratti CSA ricreati nel nuovo esercizio ' + @nextayearstr)

	INSERT INTO csa_contracttax_partition
		(
			idcsa_contract,	idcsa_contracttax,	ndetail,quota,idepexp,	ayear,
			idfin, idupb, idacc, idexp, idsor_siope,
			ct,cu,lt,lu
		)
	SELECT
		@maxidcsa_contract + #csa_contract.newidcsa_contract,
		csa_contracttax_partition.idcsa_contracttax,
		csa_contracttax_partition.ndetail,csa_contracttax_partition.quota,
		csa_contracttax_partition.idepexp,
		@nextayear,
		FL.newidfin, csa_contracttax_partition.idupb,
		AL.newidacc, csa_contracttax_partition.idexp,
		csa_contracttax_partition.idsor_siope, 
		GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contracttax_partition
		JOIN csa_contract		 ON csa_contract.idcsa_contract = csa_contracttax_partition.idcsa_contract
									AND csa_contract.ayear = @ayear
		JOIN #csa_contract 		ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
		LEFT OUTER JOIN #finlookup FL 
				ON csa_contracttax_partition.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL
				ON AL.oldidacc = csa_contracttax_partition.idacc 
		WHERE csa_contracttax_partition.ayear = @ayear	AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreate ripartizioni contributi CSA nel nuovo esercizio ' + @nextayearstr)


INSERT INTO csa_contracttax
		(
			idcsa_contract,	idcsa_contracttax,vocecsa,	idfin,idexp,idepexp,
			idacc,idupb,idsor_siope,
			ayear,
			ct,cu,lt,lu
		)
	SELECT
			@maxidcsa_contract + #csa_contract.newidcsa_contract,
			csa_contracttax.idcsa_contracttax,
			csa_contracttax.vocecsa,
			FL.newidfin,
			csa_contracttax.idexp, --EY.idexp,
			csa_contracttax.idepexp,
			AL.newidacc,
			csa_contracttax.idupb, case when @ayear <> 2017 then csa_contracttax.idsor_siope  else null end,
			@nextayear,
			GETDATE(),  'CLOSEYEAR', GETDATE(),  'CLOSEYEAR'
		FROM csa_contracttax
		JOIN csa_contract			  ON csa_contract.idcsa_contract = csa_contracttax.idcsa_contract
		JOIN #csa_contract			  ON csa_contract.idcsa_contract = #csa_contract.oldidcsa_contract
										AND csa_contract.ayear = @ayear
		LEFT OUTER JOIN #finlookup FL 	  ON csa_contracttax.idfin = FL.oldidfin
		LEFT OUTER JOIN accountlookup AL  ON AL.oldidacc = csa_contracttax.idacc
		--left outer join expenseyear EY 
		--	on EY.idexp = csa_contracttax.idexp and ey.ayear=@nextayear
		WHERE csa_contracttax.ayear = @ayear
		AND ISNULL(csa_contract.active,'N') = 'S'
	INSERT INTO #log
	VALUES('Ricreate Config. Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)


END


--azzero i bit da 0 a 3 e poi imposto il valore 3 su questi flag
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x03 WHERE ayear = @ayear

SELECT * FROM #log
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



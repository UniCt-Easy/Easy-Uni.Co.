
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_undo_finsetupcopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_undo_finsetupcopy]
GO
--setuser 'amm'
--setuser 'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON  
GO
-- select * from csa_contract_partition where ayear = 2019
 --[closeyear_undo_finsetupcopy]2018
CREATE PROCEDURE [closeyear_undo_finsetupcopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #log (message varchar(255))

DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)

UPDATE 	config SET 
		idacc_accruedcost	= null,
		idacc_accruedrevenue	= null,
		idacc_bankpaydoc = null,
		idacc_bankprodoc = null,
		idacc_customer	    	= null,
		idacc_deferredcost	= null,
		idacc_deferredcredit	=null,
		idacc_deferreddebit	= null,
		idacc_deferredrevenue	= null,
		idacc_economic_result = null,
		idacc_invoicetoemit = null,
		idacc_invoicetoreceive = null,
		idacc_ivapayment	= null,
		idacc_ivapayment12		= null,
		idacc_ivapaymentsplit		= null,
		idacc_ivarefund		= null,
		idacc_ivarefund12		= null,
		idacc_mainivapayment = null,
		idacc_mainivapayment_internal = null,
		idacc_mainivapayment_internal12 =null,
		idacc_mainivapayment12	= null,
		idacc_mainivarefund =  null,
		idacc_mainivarefund_internal = null,
		idacc_mainivarefund_internal12 =null,
		idacc_mainivarefund12	=  null,
		idacc_patrimony		= null,
		idacc_pl		= null,
		idacc_previous_economic_result = null,
		idacc_revenue_gross_csa = null,
		idacc_supplier		= null,
		idacc_unabatable = null,
		idacc_unabatable_refund = null,
		idacc_unabatable_split = null,
		flagepexp		= null,
		mainidacc_unabatable =null,
		mainidacc_unabatable_refund = null
		WHERE ayear =  @nextayear

		-- ANNULLAMENTO TRASFERIMENTO epsetupcopy
		DELETE FROM invoicekindyear  WHERE ayear =  @nextayear
		DELETE FROM epupbkindyear WHERE ayear =  @nextayear
		
INSERT INTO #log
VALUES('Trasferita configurazione fatture per esercizio ' + @nextayearstr)

-- ANNULLAMENTO TRASFERIMENTO FINSETUPCOPY

UPDATE 	config SET idinpscenter = NULL
	FROM config
	JOIN config COLD
	ON config.ayear = (COLD.ayear + 1)
	WHERE COLD.ayear = @ayear
	AND config.ayear =  @nextayear

INSERT INTO #log
	VALUES('La configurazione dell''avanzo cassa e amministrazione ' + @nextayearstr+' è stata annullata.')

UPDATE config
SET
	electronictrasmission = null,
	flagbank_grouping = null,
	motiveprefix = null, 
	motiveseparator = null, 
	motivelen = null,
	appname = null, 
	electronicimport = null, 
	importappname = null,
	idpaymethodabi = null,
	idpaymethodnoabi = null
FROM config, config oldconfig
WHERE config.ayear = @nextayear
AND oldconfig.ayear = @ayear

INSERT INTO #log
	VALUES('La configurazione per la trasm.elettronica dell''esercizio ' + @nextayearstr+' è stata annullata.')

 --CUD activitycode
UPDATE config
SET
	cudactivitycode = null,
        flagfruitful = null,
        finvarofficial_default =null
FROM config, config oldconfig
WHERE config.ayear = @nextayear
AND oldconfig.ayear = @ayear

INSERT INTO #log VALUES('Annullato il Trasferimento il Codice Attività  per il CUD, Flag Fruttifero, Flag variazioni per esercizio ' + @nextayearstr)


UPDATE  config
SET
	agencycode 		= null,
	deferredexpensephase 	= null, 
	deferredincomephase  	= null, 
	flagpayment 		= null, 
	flagrefund 		= null, 
	idfinivapayment 	= null, 
	idfinivarefund 		= null,
	idivapayperiodicity 	= null,
	minpayment 		= null,
	minrefund  		= null,
	paymentagency 		= null,
	refundagency 		= null,
	flagivapaybyrow		= null,
	mainflagpayment = null,
	mainflagrefund = null,
	mainidfinivapayment = null,
	mainidfinivarefund = null ,
	mainidfinivapayment12 = null,
	mainidfinivarefund12 = null,
	mainminpayment = null,
	mainminrefund = null,
	mainpaymentagency = null,
	mainrefundagency = null,
	flagpayment12 = null,
	flagrefund12 = null,
	idfinivapayment12 = null,
	idfinivarefund12 = null,
	minpayment12 = null,
	minrefund12 = null,
	paymentagency12 = null,
	refundagency12 = null,
	mainflagpayment12 = null,
	mainflagrefund12 = null,
	mainminpayment12 = null,
	mainminrefund12 = null,
	mainpaymentagency12 = null,
	mainrefundagency12 =null,
	idfinincome_gross_csa = null,
	idsiopeincome_csa = null,
	idfin_store = null,
	flagsplitpayment= null,
	paymentagencysplit= null,
	flagpaymentsplit=null,
	idfinivapaymentsplit = null
	FROM config
WHERE   config.ayear =  @nextayear

INSERT INTO #log VALUES('Annullata   configurazione IVA per esercizio ' + @nextayearstr)

--itinerationsetup
UPDATE config
SET
	idclawback 		=null,
	idfinexpense 		= null,
	idaccmotive_admincar = null,
	idaccmotive_owncar 	= null,
	idaccmotive_foot  	= null,
	foreignhours   	  	= null,
	itineration_directauth =null
WHERE  config.ayear = @nextayear

INSERT INTO #log
	VALUES('Annullata configurazione Missioni per esercizio ' + @nextayearstr)

DELETE FROM pettycashsetup WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Trasferita configurazione Fondo Economale per esercizio ' + @nextayearstr)

DELETE FROM finmotivedetail WHERE ayear = @nextayear
INSERT INTO #log VALUES('Annullata associazione causali - bilancio per esercizio ' + @nextayearstr)

DELETE FROM taxsetup WHERE ayear = @nextayear
	INSERT INTO #log
	VALUES('Annullata configurazione automatismi ritenute per esercizio ' + @nextayearstr)

DELETE FROM taxregionsetup WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione automatismi ritenute ripartizione regionale per esercizio ' + @nextayearstr)

DELETE FROM autoincomesorting WHERE ayear = @nextayear
INSERT INTO #log
	VALUES('Annullata configurazione automatismi per la classificazione dei mov. di entrata ' + @nextayearstr)

DELETE FROM autoexpensesorting WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione automatismi per la classificazione dei mov. di spesa ' + @nextayearstr)

DELETE FROM sortingincomefilter WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione filtri per la classificazione dei mov. di entrata ' + @nextayearstr)

DELETE FROM sortingexpensefilter WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione filtri per la classificazione dei mov. di spesa ' + @nextayearstr)

DELETE FROM autoclawbacksorting WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione classificazione dei recuperi ' + @nextayearstr)

DELETE FROM taxsortingsetup WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione classificazione delle ritenute ' + @nextayearstr)

DELETE FROM taxpaymentpartsetup WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione automatismi ritenute percentuale esercizio ' + @nextayearstr)

DELETE FROM clawbacksetup WHERE ayear = @nextayear
INSERT INTO #log
VALUES('Annullata configurazione automatismi recuperi per esercizio ' + @nextayearstr)

DELETE FROM partincomesetup 
WHERE idfinincome IN 
		(SELECT idfin FROM fin WHERE ayear = @nextayear)
OR idfinexpense IN 
		(SELECT idfin FROM fin WHERE ayear = @nextayear)	 
INSERT INTO #log
VALUES('Annullate ripartizioni assegnazioni entrate per esercizio ' + @nextayearstr)

DELETE from finsorting WHERE idfin IN (SELECT idfin FROM fin where ayear=@nextayear)
INSERT INTO #log
VALUES('Annullate le classificazioni del bilancio per esercizio ' + @nextayearstr)

DELETE from accountsorting WHERE idacc IN (SELECT idacc FROM account where ayear=@nextayear)
INSERT INTO #log
VALUES('Annullate le classificazioni del piano dei conti per esercizio ' + @nextayearstr)

DELETE FROM accmotivedetail WHERE ayear = @nextayear
INSERT INTO #log VALUES('Annullata associazione causali - conti per esercizio ' + @nextayearstr)

 DELETE FROM epupbkindyear WHERE ayear = @nextayear
 INSERT INTO #log VALUES('Annullata configurazione tipi upb in economico patrimoniale' + @nextayearstr)


 DELETE FROM flowchartfin WHERE idflowchart like SUBSTRING(@nextayearstr, 3, 2) + '%'
 INSERT INTO #log VALUES('Annullata configurazione sicurezza Bilancio nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contractkindyear WHERE ayear = @nextayear
 INSERT INTO #log  VALUES('Trasferiti tipi contratti CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contractkinddata WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate Attribuzioni tipi Contratti alle Voci CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contractkindrules WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate Regole di individuazione dei tipi di Contratti CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_incomesetup WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullata Configurazione Entrate CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE  FROM csa_contract WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullati Contratti CSA di competenza nel nuovo esercizio ' + @nextayearstr)

  DELETE FROM csa_contract_partition WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate Ripartizioni Contratti CSA nel nuovo esercizio ' + @nextayearstr)


 DELETE FROM csa_contractregistry WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate Matricole Contratti CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contractexpense WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullati collegamenti a mov.spesa CSA  nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contractepexp WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate collegamenti a movimenti di budget Config. Contratti CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contracttax WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate Config. Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contracttaxexpense WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate collegamenti a movimenti di spesa Config. Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)

  DELETE FROM csa_contracttaxepexp WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate collegamenti a movimenti di budget Config. Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)

 DELETE FROM csa_contracttax_partition WHERE ayear = @nextayear
 INSERT INTO #log
 VALUES('Annullate Ripartizioni Contributi Contratti CSA nel nuovo esercizio ' + @nextayearstr)


--azzero i bit da 0 a 3 e poi imposto il valore 2 su questi flag
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x02 WHERE ayear = @ayear
 


SELECT * FROM #log
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


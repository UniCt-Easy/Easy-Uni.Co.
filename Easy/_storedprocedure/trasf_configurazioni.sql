
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasf_configurazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasf_configurazioni]
GO


CREATE   PROCEDURE [trasf_configurazioni]

AS BEGIN
--CICLO SULLE TABELLE DI CONFIGURAZIONE
--CREAZIONE DELLE RIGHE CORRISPONDENTI AI VARI ESERCIZI

CREATE TABLE #esercizi
(
	ayear smallint
)

/*
assetsetup
bankdispositionsetup
casualcontractsetup
entrysetup
expensesetup
finsetup
incomesetup
invoicesetup
itinerationsetup
parasubcontractsetup
profservicesetup
wageadditionsetup*/


INSERT INTO #esercizi([ayear])
(
select  ayear from assetsetup union 
select  ayear from bankdispositionsetup union 
select  ayear from casualcontractsetup union 
select  ayear from entrysetup union 
select  ayear from expensesetup union 
select  ayear from finsetup union 
select  ayear from incomesetup union 
select  ayear from invoicesetup union 
select  ayear from itinerationsetup union 
select  ayear from parasubcontractsetup union 
select  ayear from profservicesetup union 
select  ayear from wageadditionsetup)

--select * from  #esercizi
DELETE FROM config
INSERT INTO config
	(
	      ayear, ct, cu, lt, lu
	)
SELECT ayear, GETDATE(), 'ASSISTENZA', GETDATE(), 'ASSISTENZA'
FROM   #esercizi


UPDATE 	config
SET     asset_flagnumbering  = assetsetup.flagnumbering ,  
	asset_flagrestart    = assetsetup.flagrestart, 
	asset_numerationkind = assetsetup.numerationkind, 
	linktoinvoice = assetsetup.linktoinvoice 
FROM    assetsetup WHERE config.ayear = assetsetup.ayear

UPDATE config 
SET    assetload_flag=assetload_flag+2 
WHERE  (SELECT flagregistry from assetsetup A where A.ayear=config.ayear)='S'

UPDATE config 
SET    assetload_flag=assetload_flag+2 
WHERE  (SELECT flagmotive from assetsetup A where A.ayear=config.ayear)='S'


UPDATE  config
SET     appname  		= bankdispositionsetup.appname,
	electronictrasmission  	= bankdispositionsetup.electronictrasmission, 
	motivelen 		= bankdispositionsetup.motivelen,
	motiveprefix 		= bankdispositionsetup.motiveprefix,
	motiveseparator 	= bankdispositionsetup.motiveseparator, 
	payments_groupingkind 	= bankdispositionsetup.paymentsgroupingkind, 
	proceeds_groupingkind 	= bankdispositionsetup.proceedsgroupingkind, 
	importappname  		= bankdispositionsetup.importappname,
	electronicimport	= bankdispositionsetup.electronicimport	 
FROM    bankdispositionsetup WHERE config.ayear = bankdispositionsetup.ayear


UPDATE config
SET    casualcontract_flagnumbering 	= casualcontractsetup.flagnumbering, 
       casualcontract_flagrestart 	= casualcontractsetup.flagrestart
FROM   casualcontractsetup WHERE config.ayear = casualcontractsetup.ayear

UPDATE 	config
SET    	idacc_customer   	= entrysetup.idacc_customer,
       	idacc_deferredcredit	= entrysetup.idacc_deferredcredit,
	idacc_deferreddebit	= entrysetup.idacc_deferreddebit,
	idacc_ivapayment	= entrysetup.idacc_ivapayment,
	idacc_ivarefund		= entrysetup.idacc_ivarefund,
	idacc_supplier		= entrysetup.idacc_supplier,
	idacc_accruedrevenue	= entrysetup.idacc_accruedrevenue,
	idacc_accruedcost	= entrysetup.idacc_accruedcost,
	idacc_deferredcost	= entrysetup.idacc_deferredcost,
	idacc_deferredrevenue	= entrysetup.idacc_deferredrevenue,
	flagepexp		= entrysetup.flagepexp,
	idacc_pl		= entrysetup.idacc_pl,
	idacc_patrimony		= entrysetup.idacc_patrimony
	FROM   entrysetup WHERE config.ayear = entrysetup.ayear

UPDATE 	config
SET    	admintaxkind 		 = expensesetup.admintaxkind, 
	clawbackkind 		 = expensesetup.clawbackkind, 
	employtaxkind 		 = expensesetup.employtaxkind, 
	expensephase 		 = expensesetup.expensephase, 
	expense_expiringdays 	 = expensesetup.expiringadvancedays,
	flagadmintax 		 = expensesetup.flagadmintax, 
	flagarrearsadmintax 	 = expensesetup.flagarrearsadmintax, 
	flagautopayment 	 = expensesetup.flagautopayment, 
	payment_flagautoprintdate = expensesetup.flagautoprintdate, 
	flagclawback 		 = expensesetup.flagclawback, 
	flagtax 		 = expensesetup.flagtax, 
	flagtaxcompetency 	 = expensesetup.flagtaxcompetency, 
	idsortingkind1 		 = expensesetup.idsortingkind1,
	idsortingkind2 		 = expensesetup.idsortingkind2,
	idsortingkind3 		 = expensesetup.idsortingkind3,
	mandate_numerationkind 	 = expensesetup.numerationkind , 
	payment_finlevel 	 = expensesetup.paymentfinlevel, 
	idregauto 		 = expensesetup.idregauto
FROM    expensesetup WHERE config.ayear = expensesetup.ayear




UPDATE config 
SET    payment_flag=payment_flag+2 
WHERE  (SELECT flagcommseparatemanager from expensesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    payment_flag=payment_flag+2 
WHERE  (SELECT flagfinance from expensesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    payment_flag=payment_flag+2 
WHERE  (SELECT flagregistry from expensesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    payment_flag=payment_flag+2 
WHERE  (SELECT flagseparatearrears from expensesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    payment_flag=payment_flag+2 
WHERE  (SELECT flagseparatemanager from expensesetup E where E.ayear=config.ayear)='S'

UPDATE  config
SET     appropriationphasecode 	= finsetup.appropriationphasecode,
	assessmentphasecode 	= finsetup.assessmentphasecode	,
	boxpartitiontitle 	= finsetup.boxpartitiontitle	,
	cashvaliditykind 	= finsetup.cashvaliditykind	, 
	currpartitiontitle 	= finsetup.currpartitiontitle	,
	previsionkind		= finsetup.previsionkind	, 
	prevpartitiontitle 	= finsetup.prevpartitiontitle	,
	secprevisionkind 	= finsetup.secprevisionkind	, 
	flagcredit 		= finsetup.flagcredit		, 
	flagproceeds 		= finsetup.flagproceeds	
FROM    finsetup WHERE config.ayear = finsetup.ayear



UPDATE config
SET    idfinincomesurplus = fin.idfin
FROM   fin WHERE config.ayear = fin.ayear
AND    fin.flagincomesurplus = 'S'

UPDATE config
SET    idfinexpensesurplus = fin.idfin
FROM   fin WHERE config.ayear = fin.ayear
AND    fin.flagexpensesurplus = 'S'

UPDATE  config
SET     incomephase 			= incomesetup.incomephase, 
	income_expiringdays 		= incomesetup.expiringadvancedays,
	proceeds_flagautoprintdate 	= incomesetup.flagautoprintdate, 
	flagautoproceeds 		= incomesetup.flagautoproceeds, 
	flagfruitful 			= incomesetup.flagfruitful, 
	proceeds_finlevel 		= incomesetup.proceedsfinlevel, 
	estimate_numerationkind 	= incomesetup.numerationkind  
FROM    incomesetup WHERE config.ayear  = incomesetup.ayear

UPDATE config 
SET    proceeds_flag=proceeds_flag+2 
WHERE  (SELECT flagcommseparatemanager from incomesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    proceeds_flag=proceeds_flag+2 
WHERE  (SELECT flagfinance from incomesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    proceeds_flag=proceeds_flag+2 
WHERE  (SELECT flagregistry from incomesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    proceeds_flag=proceeds_flag+2 
WHERE  (SELECT flagseparatearrears from incomesetup E where E.ayear=config.ayear)='S'

UPDATE config 
SET    proceeds_flag=proceeds_flag+2 
WHERE  (SELECT flagseparatemanager from incomesetup E where E.ayear=config.ayear)='S'


UPDATE  config
SET     agencycode 		= invoicesetup.agencycode,
	deferredexpensephase 	= invoicesetup.deferredexpensephase, 
	deferredincomephase  	= invoicesetup.deferredincomephase, 
	flagpayment 		= invoicesetup.flagpayment, 
	flagrefund 		= invoicesetup.flagrefund, 
	idfinivapayment 	= invoicesetup.idfinivapayment, 
	idfinivarefund 		= invoicesetup.idfinivarefund,
	idivapayperiodicity 	= invoicesetup.idivapayperiodicity,
	minpayment 		= invoicesetup.minpayment,
	minrefund  		= invoicesetup.minrefund,
	invoice_numerationkind 	= invoicesetup.numerationkind, 
	paymentagency 		= invoicesetup.paymentagency,
	refundagency 		= invoicesetup.refundagency
FROM    invoicesetup WHERE config.ayear = invoicesetup.ayear

UPDATE  config
SET     idclawback 		= itinerationsetup.idclawback,
	idfinexpense 		= itinerationsetup.idfinexpense,
	idaccmotive_admincar 	= itinerationsetup.idaccmotive_admincar,
	idaccmotive_owncar 	= itinerationsetup.idaccmotive_owncar,
	idaccmotive_foot  	= itinerationsetup.idaccmotive_foot,
	foreignhours   	  	= itinerationsetup.foreignhours
FROM    itinerationsetup WHERE config.ayear = itinerationsetup.ayear

UPDATE config
SET    parasubcontract_numerationkind = parasubcontractsetup.numerationkind
FROM   parasubcontractsetup WHERE config.ayear = parasubcontractsetup.ayear

UPDATE config
SET    profservice_flagnumbering = profservicesetup.flagnumbering,
       profservice_flagrestart = profservicesetup.flagrestart	
FROM   profservicesetup WHERE config.ayear = profservicesetup.ayear

UPDATE config
SET    wageaddition_flagnumbering = wageadditionsetup.flagnumbering,
       wageaddition_flagrestart   = wageadditionsetup.flagrestart	
FROM   wageadditionsetup WHERE config.ayear = wageadditionsetup.ayear



--select * from config
DROP TABLE #esercizi
END

--exec trasf_configurazioni

--select * from profservicesetup

--delete from config where ayear = 2008


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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_epsetupcopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_epsetupcopy]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE PROCEDURE [closeyear_epsetupcopy]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #log (message varchar(255))
 
-- closeyear_epsetupcopy 2018
--setuser 'amministrazione'
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
	'epsetupcopy', getdate(), 'epsetupcopy', getdate()
FROM    #accountlookup
WHERE   NOT EXISTS (SELECT * FROM accountlookup AL1 
			WHERE AL1.oldidacc = #accountlookup.oldidacc
                        AND   AL1.newidacc = #accountlookup.newidacc)
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)

IF EXISTS (SELECT * FROM config WHERE ayear = @nextayear)
BEGIN
	UPDATE 	config SET 
		idacc_accruedcost	= ACCC.newidacc,
		idacc_accruedrevenue	= ACCR.newidacc,
		idacc_bankpaydoc = presentazione_documenti_pagamento.newidacc,
		idacc_bankprodoc = presentazione_documenti_incasso.newidacc,
		idacc_customer	    	= CUST.newidacc,
		idacc_deferredcost	= DEFEC.newidacc,
		idacc_deferredcredit	= DEF_C.newidacc,
		idacc_deferreddebit	= DEF_D.newidacc,
		idacc_deferredrevenue	= DEFER.newidacc,
		idacc_economic_result = risultato_economico.newidacc,
		idacc_invoicetoemit = fatt_emettere.newidacc,
		idacc_invoicetoreceive = fatt_ricevere.newidacc,
		idacc_ivapayment	= IVA_P.newidacc,
		idacc_ivapayment12		= IVA_P12.newidacc,
		idacc_ivapaymentsplit		= IVA_PSPLIT.newidacc,
		idacc_ivarefund		= IVA_R.newidacc,
		idacc_ivarefund12		= IVA_R12.newidacc,
		idacc_mainivapayment = MAINIVA_P.newidacc,
		idacc_mainivapayment_internal = MAINIVA_P_INT.newidacc,
		idacc_mainivapayment_internal12 = MAINIVA_P_INT12.newidacc,
		idacc_mainivapayment12	= MAINIVA_P12.newidacc,
		idacc_mainivarefund =  MAINIVA_R.newidacc,
		idacc_mainivarefund_internal = MAINIVA_R_INT.newidacc,
		idacc_mainivarefund_internal12 = MAINIVA_R_INT12.newidacc,
		idacc_mainivarefund12	=  MAINIVA_R12.newidacc,
		idacc_patrimony		= PAT.newidacc,
		idacc_pl		= PL.newidacc,
		idacc_previous_economic_result = risultato_economico_precedente.newidacc,
		idacc_revenue_gross_csa = REVENUE_GROSS_CSA.newidacc,
		idacc_supplier		= SUPP.newidacc,
		idacc_unabatable = IND_C.newidacc,
		idacc_unabatable_refund = IND_R.newidacc,
		idacc_unabatable_split = IND_SPLIT.newidacc,
		idaccmotive_grantdeferredcost = oldconfig.idaccmotive_grantdeferredcost,
		idaccmotive_grantrevenue = oldconfig.idaccmotive_grantrevenue,
		idaccmotive_assetrevenue = oldconfig.idaccmotive_assetrevenue,
		idaccmotive_prorata_cost = oldconfig.idaccmotive_prorata_cost,
		idaccmotive_prorata_revenue = oldconfig.idaccmotive_prorata_revenue,
		flagepexp		= oldconfig.flagepexp,
		mainidacc_unabatable = MAININD_C.newidacc,
		mainidacc_unabatable_refund = MAININD_R.newidacc,
		idaccmotive_forwarder = oldconfig.idaccmotive_forwarder,
		idivakind_forwarder = oldconfig.idivakind_forwarder
	FROM  config, config oldconfig
	LEFT OUTER JOIN accountlookup CUST 		ON CUST.oldidacc = oldconfig.idacc_customer
	LEFT OUTER JOIN accountlookup DEF_C		ON DEF_C.oldidacc = oldconfig.idacc_deferredcredit
	LEFT OUTER JOIN accountlookup DEF_D		ON DEF_D.oldidacc = oldconfig.idacc_deferreddebit
	LEFT OUTER JOIN accountlookup IVA_P		ON IVA_P.oldidacc = oldconfig.idacc_ivapayment
	LEFT OUTER JOIN accountlookup IVA_R		ON IVA_R.oldidacc = oldconfig.idacc_ivarefund
	LEFT OUTER JOIN accountlookup SUPP			ON SUPP.oldidacc = oldconfig.idacc_supplier
	LEFT OUTER JOIN accountlookup ACCR			ON ACCR.oldidacc = oldconfig.idacc_accruedrevenue
	LEFT OUTER JOIN accountlookup ACCC			ON ACCC.oldidacc = oldconfig.idacc_accruedcost
	LEFT OUTER JOIN accountlookup DEFEC		ON DEFEC.oldidacc = oldconfig.idacc_deferredcost
	LEFT OUTER JOIN accountlookup DEFER		ON DEFER.oldidacc = oldconfig.idacc_deferredrevenue
	LEFT OUTER JOIN accountlookup PL			ON PL.oldidacc = oldconfig.idacc_pl
	LEFT OUTER JOIN accountlookup PAT			ON PAT.oldidacc = oldconfig.idacc_patrimony
	LEFT OUTER JOIN accountlookup IND_C		ON IND_C.oldidacc = oldconfig.idacc_unabatable	
	LEFT OUTER JOIN accountlookup IND_R		ON IND_R.oldidacc = oldconfig.idacc_unabatable_refund 
	LEFT OUTER JOIN accountlookup IND_SPLIT		ON IND_SPLIT.oldidacc = oldconfig.idacc_unabatable_split 	
	LEFT OUTER JOIN accountlookup MAININD_C	ON MAININD_C.oldidacc = oldconfig.mainidacc_unabatable 
	LEFT OUTER JOIN accountlookup MAININD_R	ON MAININD_R.oldidacc = oldconfig.mainidacc_unabatable_refund 
	LEFT OUTER JOIN accountlookup MAINIVA_P	ON MAINIVA_P.oldidacc = oldconfig.idacc_mainivapayment
	LEFT OUTER JOIN accountlookup MAINIVA_P_INT 	ON MAINIVA_P_INT.oldidacc = oldconfig.idacc_mainivapayment_internal 
	LEFT OUTER JOIN accountlookup MAINIVA_R		ON MAINIVA_R.oldidacc = oldconfig.idacc_mainivarefund 
	LEFT OUTER JOIN accountlookup MAINIVA_R_INT	ON MAINIVA_R_INT.oldidacc = oldconfig.idacc_mainivarefund_internal
	LEFT OUTER JOIN accountlookup IVA_PSPLIT		ON IVA_PSPLIT.oldidacc = oldconfig.idacc_ivapaymentsplit
	LEFT OUTER JOIN accountlookup IVA_P12			ON IVA_P12.oldidacc = oldconfig.idacc_ivapayment12
	LEFT OUTER JOIN accountlookup IVA_R12			ON IVA_R12.oldidacc = oldconfig.idacc_ivarefund12
	LEFT OUTER JOIN accountlookup MAINIVA_P12		ON MAINIVA_P12.oldidacc = oldconfig.idacc_mainivapayment12
	LEFT OUTER JOIN accountlookup MAINIVA_P_INT12	ON MAINIVA_P_INT12.oldidacc = oldconfig.idacc_mainivapayment_internal12 
	LEFT OUTER JOIN accountlookup MAINIVA_R12		ON MAINIVA_R12.oldidacc = oldconfig.idacc_mainivarefund12 
	LEFT OUTER JOIN accountlookup MAINIVA_R_INT12	ON MAINIVA_R_INT12.oldidacc = oldconfig.idacc_mainivarefund_internal12
	LEFT OUTER JOIN accountlookup REVENUE_GROSS_CSA	ON REVENUE_GROSS_CSA.oldidacc = oldconfig.idacc_revenue_gross_csa
	LEFT OUTER JOIN accountlookup fatt_ricevere		ON fatt_ricevere.oldidacc = oldconfig.idacc_invoicetoreceive
	LEFT OUTER JOIN accountlookup fatt_emettere		ON fatt_emettere.oldidacc = oldconfig.idacc_invoicetoemit
	LEFT OUTER JOIN accountlookup risultato_economico	ON risultato_economico.oldidacc = oldconfig.idacc_economic_result
	LEFT OUTER JOIN accountlookup risultato_economico_precedente	ON risultato_economico_precedente.oldidacc = oldconfig.idacc_previous_economic_result
	LEFT OUTER JOIN accountlookup presentazione_documenti_pagamento	ON presentazione_documenti_pagamento.oldidacc = oldconfig.idacc_bankpaydoc
	LEFT OUTER JOIN accountlookup presentazione_documenti_incasso		ON presentazione_documenti_incasso.oldidacc = oldconfig.idacc_bankprodoc
	WHERE 	config.ayear = @nextayear
	AND	oldconfig.ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferita configurazione E/P per esercizio ' + @nextayearstr)
END


INSERT INTO accountsorting
(
	idsor,
	idacc,
	quota,
	ct, cu, lt, lu
)
SELECT
	ACCS.idsor,
	ACCL.newidacc,
	ACCS.quota,
	GETDATE(),ACCS.cu,GETDATE(),ACCS.lu 
FROM accountsorting ACCS 
JOIN sorting S ON ACCS.idsor = S.idsor
JOIN sortingkind SK ON SK.idsorkind = S.idsorkind
JOIN accountlookup ACCL
	ON ACCL.oldidacc = ACCS.idacc
JOIN account ACC 
	ON ACCL.oldidacc = ACC.idacc 
WHERE (SK.flag&4 <>0) -- classificazione piano dei conti
AND ACC.ayear = @ayear
AND NOT EXISTS /*non esistono voci del piano dei conti già classificate in nuovo esercizio*/
	(SELECT * FROM accountsorting ACCS1
	 JOIN sorting S1 ON ACCS1.idsor = S1.idsor
	 JOIN sortingkind SK1 ON SK1.idsorkind = S1.idsorkind
	 JOIN account ACC1 ON ACCS1.idacc = ACC1.idacc
	 JOIN accountlookup ACCLK ON ACCS1.idacc = ACCLK.newidacc
	 WHERE ACC1.ayear = @nextayear
	 AND (SK1.flag&4 <>0) ) -- classificazione piano dei conti

INSERT INTO #log
VALUES('Trasferita classificazione del piano dei conti per esercizio ' + @nextayearstr)

INSERT INTO invoicekindyear
(
	ayear, idinvkind,
	idacc,
	idacc_deferred,
	idacc_discount,
	idacc_unabatable,
	idacc_deferred_intra,
	idacc_intra,
	idacc_unabatable_intra,
	idacc_deferred_split,
	idacc_split,
	idacc_unabatable_split,
	cu, ct, lu, lt
)
SELECT
	@nextayear, idinvkind,
	ACC.newidacc,
	DEF.newidacc,
	DIS.newidacc,
	UNA.newidacc,
	DEFINTRA.newidacc,
	ACCINTRA.newidacc,
	UNAINTRA.newidacc,
	DEFSPLIT.newidacc,
	ACCSPLIT.newidacc,
	UNASPLIT.newidacc,
	invoicekindyear.cu, GETDATE(), invoicekindyear.lu, GETDATE()
FROM invoicekindyear
LEFT OUTER JOIN accountlookup ACC
	ON ACC.oldidacc = invoicekindyear.idacc
LEFT OUTER JOIN accountlookup DEF
	ON DEF.oldidacc = invoicekindyear.idacc_deferred
LEFT OUTER JOIN accountlookup DIS
	ON DIS.oldidacc = invoicekindyear.idacc_discount
LEFT OUTER JOIN accountlookup UNA
	ON UNA.oldidacc = invoicekindyear.idacc_unabatable
LEFT OUTER JOIN accountlookup ACCINTRA
	ON ACCINTRA.oldidacc = invoicekindyear.idacc_intra
LEFT OUTER JOIN accountlookup DEFINTRA
	ON DEFINTRA.oldidacc = invoicekindyear.idacc_deferred_intra
LEFT OUTER JOIN accountlookup UNAINTRA
	ON UNAINTRA.oldidacc = invoicekindyear.idacc_unabatable_intra
LEFT OUTER JOIN accountlookup ACCSPLIT
	ON ACCSPLIT.oldidacc = invoicekindyear.idacc_split
LEFT OUTER JOIN accountlookup DEFSPLIT
	ON DEFSPLIT.oldidacc = invoicekindyear.idacc_deferred_split
LEFT OUTER JOIN accountlookup UNASPLIT
	ON UNASPLIT.oldidacc = invoicekindyear.idacc_unabatable_split

WHERE ayear = @ayear
AND NOT EXISTS
	(SELECT * FROM invoicekindyear I
	WHERE I.idinvkind = invoicekindyear.idinvkind
		AND I.ayear = @nextayear)



INSERT INTO epupbkindyear
(
	ayear, idepupbkind,adjustmentkind,
	idacc_cost,
	idacc_revenue,
	idacc_deferredcost,
	idacc_accruals,
	idacc_reserve,
	idaccmotive_cost,
	idaccmotive_revenue,
	idaccmotive_deferredcost,
	idaccmotive_accruals,
	idaccmotive_reserve,
	cu, ct, lu, lt
)
SELECT
	@nextayear, idepupbkind,adjustmentkind,
	COST.newidacc,
	REVENUE.newidacc,
	DEFERRED.newidacc,
	ACCRUALS.newidacc,
	RESERVE.newidacc,
	idaccmotive_cost,
	idaccmotive_revenue,
	idaccmotive_deferredcost,
	idaccmotive_accruals,
	idaccmotive_reserve,
	epupbkindyear.cu, GETDATE(), epupbkindyear.lu, GETDATE()
FROM epupbkindyear
LEFT OUTER JOIN accountlookup COST
	ON COST.oldidacc = epupbkindyear.idacc_cost
LEFT OUTER JOIN accountlookup REVENUE
	ON REVENUE.oldidacc = epupbkindyear.idacc_revenue
LEFT OUTER JOIN accountlookup DEFERRED
	ON DEFERRED.oldidacc = epupbkindyear.idacc_deferredcost
LEFT OUTER JOIN accountlookup ACCRUALS
	ON ACCRUALS.oldidacc = epupbkindyear.idacc_accruals
LEFT OUTER JOIN accountlookup RESERVE
	ON RESERVE.oldidacc = epupbkindyear.idacc_reserve

WHERE ayear = @ayear
AND NOT EXISTS
	(SELECT * FROM epupbkindyear I
	WHERE I.idepupbkind = epupbkindyear.idepupbkind
		AND I.ayear = @nextayear)




INSERT INTO #log
VALUES('Trasferita configurazione fatture per esercizio ' + @nextayearstr)

SELECT * FROM #log
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

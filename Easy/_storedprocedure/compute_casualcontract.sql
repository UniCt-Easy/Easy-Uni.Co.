
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



--compute_casualcontract 2009,2009,154
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_casualcontract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_casualcontract]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--compute_casualcontract 2010,2010,259
--select * from casualcontract order by ycon desc, ncon desc
CREATE PROCEDURE [compute_casualcontract]
(
	@ayear int, 
	@ycon  int,
	@ncon  int
)
AS 
BEGIN


--#allpayed imponibili lordi e netti delle ritenute PREVIDENZIALI di QUESTA prestazione, anno per anno
CREATE TABLE #allpayed
( ayear int,
  idexp int,
  taxablegross decimal(19,2),
  taxablenet decimal(19,2),
  taxablenumerator decimal(19,6),
  taxabledenominator decimal(19,6)
)

DECLARE @feegross decimal(19,2)
set     @feegross = (SELECT ISNULL(feegross,0) 
			    FROM casualcontract 
			   WHERE casualcontract.ycon = @ycon
	   		     AND casualcontract.ncon = @ncon)

	INSERT INTO #allpayed
	(ayear,idexp, taxablegross, taxablenet,
	 taxablenumerator,taxabledenominator)
	(SELECT  E.ymov,ETO.idexp, EY.amount, ETO.taxablenet, 
	 ISNULL(ETO.taxablenumerator,100), ISNULL(ETO.taxabledenominator,100)
	 FROM expensetaxofficial ETO
	 JOIN expenselast EL
		ON EL.idexp = ETO.idexp
	 JOIN expense E
		ON E.idexp = EL.idexp
	 JOIN  expenseyear EY
		ON EY.idexp = EL.idexp
		AND EY.ayear = @ayear
	 JOIN expenselink ELI
		ON  ELI.idchild = EL.idexp
		AND ELI.nlevel = 
			( SELECT expensephase 
		     	  FROM config WHERE ayear = @ayear) 
	 JOIN expensecasualcontract EC 
		ON EC.idexp  = ELI.idparent 
	 JOIN casualcontract C 
		ON C.ycon = EC.ycon
		AND C.ncon = EC.ncon 
	 JOIN dbo.tax T
		ON T.taxcode = ETO.taxcode
	 JOIN dbo.service S
		ON S.idser = EL.idser
	 WHERE E.ymov 	= @ayear
	 AND T.taxkind  = 3 -- previdenziale
	 AND S.module   = 'OCCASIONALE'
	 AND ETO.stop IS NULL 
	 AND C.ycon =@ycon AND C.ncon = @ncon
	)
/*
if (select count(*) from #allpayed)=0 
BEGIN
	DROP TABLE #allpayed
	SELECT 
	0 	AS payed_lastyear, 	--(pagato nell'ultimo anno)
	0 		AS payed_total, 	--(totale pagato)
	0	AS payed_prevyears, 
	0 	AS F_refund_lastyear,   --(spese fiscali pagate nell'ultimo anno)
	0 	AS P_refund_lastyear, 	--(spese previdenziali pagate nell'ultimo anno)
	0 	AS F_refund_total,	--(spese fiscali complessive pagate)
	0 	AS P_refund_total,	--(spese previdenziali complessive pagate)
	0 	AS F_refund_residual,	--(residuo spese fiscali da pagare)
	0 	AS P_refund_residual,	--(residuo spese previdenziali da pagare)
	0  AS exemptionquota_applied --(quota esente applicata)
	return
END
*/
IF EXISTS (SELECT * 
	   FROM pettycashoperationcasualcontract 
	   WHERE pettycashoperationcasualcontract.ycon = @ycon
	   AND pettycashoperationcasualcontract.ncon = @ncon )
BEGIN
	UPDATE #allpayed set taxablegross = @feegross

END


--spese pagate anno per anno di QUESTO contratto
CREATE TABLE #annualpayedrefund
 (
	ayear int,
	totalpayed_F decimal(19,2),
	totalpayed_P decimal(19,2),
	totalrefund_F decimal(19,2),
	totalrefund_P decimal(19,2),
	refundtoconsider_F decimal(19,2),
	refundtoconsider_P decimal(19,2),
	payedrefund_F decimal(19,2),
	payedrefund_P decimal(19,2),
	totaldeduction_P decimal(19,2),
	exemptionquota_applied decimal(19,2)
 )

-- il riempimento della tabella temporanea delle spese pagate avviene anno per anno
-- a partire dall'anno di esistenza del contratto fino all'anno presente
-- prendendo in considerazione le righe presenti in casualcontractyear fino all'anno attuale

INSERT INTO #annualpayedrefund
(ayear, totalpayed_F,totalpayed_P,totalrefund_F,totalrefund_P, 
	refundtoconsider_F,refundtoconsider_P, 
	payedrefund_F,payedrefund_P,totaldeduction_P,exemptionquota_applied)
SELECT  C.ayear, 0, 0, 0,0, 0,0,0,0,0,0
  FROM  casualcontractyear C 
 WHERE  C.ycon = @ycon
   AND  C.ncon   = @ncon
		--and C.ayear <= @ayear
	
--imposta il totale pagato di ogni anno (della PRESTAZIONE), anche se non contiene INPS
UPDATE #annualpayedrefund
	SET totalpayed_F = (SELECT ISNULL(SUM(EY.amount),0)
	 	FROM expenselast EL
		 JOIN expense E 	
			ON E.idexp = EL.idexp
		 JOIN  expenseyear EY	
			ON EY.idexp = EL.idexp
			AND EY.ayear = #annualpayedrefund.ayear
		 JOIN expenselink ELI
			ON  ELI.idchild = EL.idexp
			AND ELI.nlevel = 
				( SELECT expensephase 
			     	  FROM config WHERE ayear = @ayear) 
		 JOIN expensecasualcontract EC 
			ON EC.idexp  = ELI.idparent 
		 WHERE 
		   EC.ycon =@ycon AND EC.ncon = @ncon
	)

if ((SELECT COUNT(*) 
			from 	casualcontract C 
			 JOIN service S		ON S.idser = C.idser
			 JOIN servicetax ST 	ON S.idser= ST.idser		
		 	 JOIN tax T		ON T.taxcode = ST.taxcode
		
			WHERE  C.ycon = @ycon
			AND C.ncon = @ncon 
			AND T.taxkind  = 3 -- previdenziale
			AND S.module   = 'OCCASIONALE'
		)>0 )
BEGIN
 --somma i movimenti
 UPDATE #annualpayedrefund
	SET totalpayed_P = ISNULL( (SELECT SUM(EY.amount)
	 	FROM expenselast EL
		 JOIN expense E 	
			ON E.idexp = EL.idexp
		 JOIN  expenseyear EY	
			ON EY.idexp = EL.idexp
			AND EY.ayear = #annualpayedrefund.ayear
		 JOIN expenselink ELI
			ON  ELI.idchild = EL.idexp
			AND ELI.nlevel = 
				( SELECT expensephase 
			     	  FROM config WHERE ayear = @ayear) 
		 JOIN expensecasualcontract EC 
			ON EC.idexp  = ELI.idparent 
		 WHERE 
		   EC.ycon =@ycon AND EC.ncon = @ncon		
	),0)
--somma le variazioni non rit/contr
 UPDATE #annualpayedrefund
	SET totalpayed_P = totalpayed_P + ISNULL (  (SELECT SUM(EV.amount)
		from expensevar EV
	 	join expenselast EL on EV.idexp=EL.idexp
		 JOIN expense E 	
			ON E.idexp = EL.idexp
		 JOIN  expenseyear EY	
			ON EY.idexp = EL.idexp
			AND EY.ayear = #annualpayedrefund.ayear
		 JOIN expenselink ELI
			ON  ELI.idchild = EL.idexp
			AND ELI.nlevel = 
				( SELECT expensephase 
			     	  FROM config WHERE ayear = @ayear) 
		 JOIN expensecasualcontract EC 
			ON EC.idexp  = ELI.idparent 
		 WHERE 
		   EC.ycon =@ycon AND EC.ncon = @ncon		
		   AND isnull(EV.autokind,0)<>4
	),0)



END




IF EXISTS (SELECT * 
	   FROM pettycashoperationcasualcontract 
	   WHERE pettycashoperationcasualcontract.ycon = @ycon
	   AND pettycashoperationcasualcontract.ncon = @ncon )
BEGIN
	UPDATE #annualpayedrefund
	SET    totalpayed_F = @feegross
	WHERE  ISNULL(totalpayed_F,0)<>0  --dovrebbe essere una sola riga

	UPDATE #annualpayedrefund
	SET    totalpayed_P = @feegross
	WHERE  ISNULL(totalpayed_P,0)<>0  --dovrebbe essere una sola riga

END


-- determino il tipo di deducibilità delle spese inserite per il contratto
-- calcolo in base all'imponibile previdenziale, il totale delle spese deducibili
-- dall'imponibile, per il presente contratto

--select * from #annualpayedrefund
-- anno per anno valorizzo l'importo totale delle spese dedicibili per quell'anno
-- prendendo le righe di casualcontractyear aventi year <= anno 

UPDATE #annualpayedrefund
SET    totalrefund_F
	= (SELECT ISNULL(SUM(amount),0) 
	     FROM casualcontractrefund
	     JOIN casualrefund
	       ON casualcontractrefund.idlinkedrefund =casualrefund.idlinkedrefund 
	    WHERE casualcontractrefund.ycon = @ycon
	      AND casualcontractrefund.ncon = @ncon
	      AND casualrefund.deduction = 'F'  
	      AND isnull(casualcontractrefund.ayear,0) <= #annualpayedrefund.ayear
	   )

UPDATE #annualpayedrefund
SET    totalrefund_P
	= (SELECT ISNULL(SUM(amount),0) 
	     FROM casualcontractrefund
	     JOIN casualrefund
	       ON casualcontractrefund.idlinkedrefund =casualrefund.idlinkedrefund 
	    WHERE casualcontractrefund.ycon = @ycon
	      AND casualcontractrefund.ncon = @ncon
	      AND casualrefund.deduction = 'P'  
	      AND isnull(casualcontractrefund.ayear,0) <= #annualpayedrefund.ayear
	   )

-- determino il valore delle spese da considerare per ogni anno refundtoconsider
-- differenza tra spese totali di ogni anno - somma (spese pagate anni precedenti),

DECLARE @existingayear int

SET 	@existingayear = @ycon -- anno di creazione del contratto 
UPDATE  #annualpayedrefund
SET     payedrefund_F = 0,  payedrefund_P = 0
WHERE   ayear = @ycon

DECLARE @cursore cursor
SET @cursore = CURSOR FOR
SELECT  ayear  FROM #annualpayedrefund  where ayear <= @ayear order by ayear


OPEN @cursore
FETCH NEXT FROM @cursore INTO @existingayear
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--sottrae alle spese da condsiderare per  un anno quelle effettuate negli anni precedenti
	UPDATE #annualpayedrefund  SET refundtoconsider_F = ISNULL(totalrefund_F,0) 
			 - ISNULL((SELECT SUM(payedrefund_F)  FROM #annualpayedrefund T WHERE T.ayear < #annualpayedrefund.ayear),0)
	WHERE  #annualpayedrefund.ayear = @existingayear

	UPDATE #annualpayedrefund SET  refundtoconsider_P = ISNULL(totalrefund_P,0) 
			- ISNULL((SELECT SUM(payedrefund_P)  FROM #annualpayedrefund T WHERE T.ayear < #annualpayedrefund.ayear),0)
	WHERE  #annualpayedrefund.ayear = @existingayear
			
	--se il totale pagato di quest'anno è minore delle spese allora considera il totale pagato altrimenti le spese
	--ossia considera il minimo tra importo pagato e spese da dedurre
	UPDATE #annualpayedrefund
	SET    payedrefund_F = CASE 
				WHEN ISNULL(totalpayed_F,0) < ISNULL(refundtoconsider_F,0) 
					THEN ISNULL(totalpayed_F,0)
					ELSE ISNULL(refundtoconsider_F,0) 
			     END  
	WHERE  #annualpayedrefund.ayear = @existingayear
	
	UPDATE #annualpayedrefund
	SET    payedrefund_P = CASE
				WHEN ISNULL(totalpayed_P,0) < ISNULL(payedrefund_F,0) THEN 0
				WHEN ISNULL(totalpayed_P,0) - ISNULL(payedrefund_F,0)  < ISNULL(refundtoconsider_P,0) 
					THEN ISNULL(totalpayed_P,0) - ISNULL(payedrefund_F,0)
				ELSE ISNULL(refundtoconsider_P,0) 
		 END  
	WHERE  #annualpayedrefund.ayear = @existingayear



	FETCH NEXT FROM @cursore INTO @existingayear
END
--select * from #annualpayedrefund

UPDATE #annualpayedrefund  set totaldeduction_P=
	(SELECT 
		ISNULL(SUM (T.alldeduction),0)
		FROM
		(	SELECT (MAX(taxablegross)  - 
			SUM (ISNULL(taxablenet,0) /(taxablenumerator/taxabledenominator))) 
			AS alldeduction
			FROM #allpayed WHERE #allpayed.ayear=#annualpayedrefund.ayear
			GROUP BY idexp
		) as T)
	WHERE 
		(SELECT COUNT(*) 
			from 	casualcontract C 
			 JOIN service S		ON S.idser = C.idser
			 JOIN servicetax ST 	ON S.idser= ST.idser		
		 	 JOIN tax T		ON T.taxcode = ST.taxcode
		
			WHERE  C.ycon = @ycon
			AND C.ncon = @ncon 
			AND T.taxkind  = 3 -- previdenziale
			AND S.module   = 'OCCASIONALE'
		)>0




--select * from #annualpayedrefund
-- quota esente = totale deduzioni - spese applicate se totale deduzioni > spese applicate altrimenti 0
UPDATE #annualpayedrefund set exemptionquota_applied= 
		CASE WHEN ISNULL(totaldeduction_P,0) > ( ISNULL(payedrefund_F,0)+ISNULL(payedrefund_P,0))
			THEN ISNULL(totaldeduction_P,0) - ( ISNULL(payedrefund_F,0)+ISNULL(payedrefund_P,0))			
			ELSE 0
		END

--select * from #annualpayedrefund


--select @totaldeduction
--select * from #annualpayedrefund

DECLARE @totalrefund 			decimal(19,2)
DECLARE @payed_lastyear_F 		decimal(19,2)
DECLARE @payed_lastyear_P 		decimal(19,2)
DECLARE @payed_prevyears 		decimal(19,2)
DECLARE @payed_total_F 			decimal(19,2)
DECLARE @payed_total_P 			decimal(19,2)
DECLARE @F_refund_lastyear 		decimal(19,2)
DECLARE @P_refund_lastyear 		decimal(19,2)
DECLARE @F_refund_total 		decimal(19,2)
DECLARE @P_refund_total 		decimal(19,2)
DECLARE @F_refund_residual		decimal(19,2)
DECLARE @P_refund_residual		decimal(19,2)
DECLARE @exemptionquotaapplied 		decimal(19,2)

SET     @totalrefund 	= (SELECT ISNULL(payedrefund_F,0) +  ISNULL(payedrefund_P,0)
			  FROM #annualpayedrefund 
		         WHERE ayear = @ayear)

SET     @payed_lastyear_F = (SELECT ISNULL(totalpayed_F,0) 
			  FROM #annualpayedrefund 
		         WHERE ayear = @ayear)
SET     @payed_lastyear_P = (SELECT ISNULL(totalpayed_P,0) 
			  FROM #annualpayedrefund 
		         WHERE ayear = @ayear)


SET     @payed_prevyears = ISNULL((SELECT SUM(totalpayed_F) 
			  FROM #annualpayedrefund 
		         WHERE ayear < @ayear),0)



SET     @payed_total_F 	= (SELECT ISNULL(SUM(totalpayed_F),0)
			  FROM #annualpayedrefund)

SET     @F_refund_lastyear = (SELECT ISNULL(payedrefund_F,0) 
			      FROM #annualpayedrefund 
		             WHERE ayear = @ayear)

SET     @P_refund_lastyear = (SELECT ISNULL(payedrefund_P,0) 
			      FROM #annualpayedrefund 
		             WHERE ayear = @ayear)

SET     @F_refund_total = (SELECT ISNULL(SUM(payedrefund_F),0) 
			      FROM #annualpayedrefund)

SET     @P_refund_total = (SELECT ISNULL(SUM(payedrefund_P),0) 
			      FROM #annualpayedrefund)

SET     @F_refund_residual = (SELECT ISNULL(refundtoconsider_F,0)  - ISNULL(payedrefund_F,0) 
			      FROM #annualpayedrefund 
		             WHERE ayear = @ayear)

SET     @P_refund_residual = (SELECT  ISNULL(refundtoconsider_P,0) - ISNULL(payedrefund_P,0) 
			      FROM #annualpayedrefund 
		             WHERE ayear = @ayear)

SET   @exemptionquotaapplied= (SELECT ISNULL(exemptionquota_applied,0) FROM #annualpayedrefund   WHERE ayear = @ayear)

DROP TABLE #annualpayedrefund
DROP TABLE #allpayed

SELECT 
	isnull(@payed_lastyear_F,0) 			AS payed_lastyear_F, 	--(pagato nell'ultimo anno fiscale)
	isnull(@payed_lastyear_P,0) 			AS payed_lastyear_P, 	--(pagato nell'ultimo anno fiscale)
	@payed_total_F 						AS payed_total_F, 	--(totale pagato su imponibile fiscale)
	isnull(@payed_total_P,0)			AS payed_total_P, 	--(totale pagato su imponibile previdenziale)
	isnull(@payed_prevyears,0)			AS payed_prevyears, --fiscale
	@F_refund_lastyear 			AS F_refund_lastyear,   --(spese fiscali pagate nell'ultimo anno)
	@P_refund_lastyear 			AS P_refund_lastyear, 	--(spese previdenziali pagate nell'ultimo anno)
	@F_refund_total 			AS F_refund_total,	--(spese fiscali complessive pagate)
	@P_refund_total 			AS P_refund_total,	--(spese previdenziali complessive pagate)
	@F_refund_residual 			AS F_refund_residual,	--(residuo spese fiscali da pagare)
	@P_refund_residual 			AS P_refund_residual,	--(residuo spese previdenziali da pagare)
	isnull(@exemptionquotaapplied,0)		AS exemptionquota_applied --(quota esente applicata)

END



GO

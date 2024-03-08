
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_percipienti_h_16]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_percipienti_h_16]
GO
 
--exec [exp_certificazioneunica_percipienti_h_16]  NULL 
CREATE PROCEDURE [exp_certificazioneunica_percipienti_h_16]
(
	@cf varchar(20)
 )
 -- estraggo l'elenco dei percipienti, autonomi, che hanno eseguito prestazioni mappate con il Record H
 -- dal 2016 aggiungo anche i percipienti (creditori pignoratizi) che hanno beneficiato di somme in virtù di pignoramenti 
 -- effettuati verso i loro debitori 
 
AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2016

	declare @annoredditi int
	set @annoredditi = 2015

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #percipienti_record_H_2015
	(
		idreg int,
		progrCom int identity(1,1)
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #percipienti_record_H_2015
		(
			idreg
		)
	SELECT DISTINCT
		expense.idreg
	FROM expense
	join expenselast on expense.idexp = expenselast.idexp
	join payment 
		on payment.kpay = expenselast.kpay
	join paymenttransmission
		on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	JOIN service on service.idser=expenselast.idser
	JOIN registry ON expense.idreg = registry.idreg
	WHERE 	registry.idregistryclass <> '10' and registry.idregistryclass <> '24'
		AND year(paymenttransmission.transmissiondate)=@annoredditi
		AND service.rec770kind = 'H'
		AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp)
		+ ISNULL(
			(SELECT SUM(amount) FROM expensevar
			WHERE expensevar.idexp = expense.idexp
			-- AND expensevar.yvar <= @annoredditi  superfluo poiché expense di ultima fase
			AND ISNULL(autokind,0) <> 4)
		,0)) > 0
		AND (select count(*) from expensetaxofficial 
		      where expensetaxofficial.idexp=expense.idexp
		      AND   expensetaxofficial.stop IS NULL) > 0
	--------------------------------------------------------------------------------
	----- da rimuovere non appena sarà corretto l'errore dal software sogei --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
	UNION
	
	SELECT
		DISTINCT T.idreg
FROM
	(SELECT
		SUM(ISNULL(E.taxablenet,0)) AS taxablenet,
		SUM(ISNULL(E.employtax,0)) AS employtax,
		SUM(ISNULL(E.admintax,0)) AS admintax,
		E.idexp as idexp,
		expense.idreg AS idreg,
		W.idreg_distrained AS idreg_distrained ,
		E.description as taxdescription,
		expense.description as expensedescription,
		expenselast.idser,
		expenselast.kpay
	FROM expensetaxofficialview AS E
	JOIN expense  				ON expense.idexp = E.idexp
	JOIN expenselast			ON expenselast.idexp = expense.idexp 
	JOIN service				ON service.idser = expenselast.idser
	JOIN wageaddition W			ON W.idser =  service.idser
	JOIN expensewageaddition EW	ON EW.ycon = W.ycon
								AND EW.ncon = W.ncon
	JOIN expenselink EL			ON EL.idparent = EW.idexp 
						AND EL.idchild =  E.idexp
	WHERE expense.ymov = @annoredditi  
		AND E.stop IS NULL
	GROUP BY expense.idreg,E.idexp,expenselast.idser,W.idreg_distrained,
		E.description ,expense.description,
        expenselast.kpay
                ) AS T
JOIN expensetotal		ON T.idexp = expensetotal.idexp  
JOIN expenseyear		ON T.idexp = expenseyear.idexp
JOIN service			ON T.idser = service.idser  
JOIN payment			ON T.kpay = payment.kpay  
JOIN paymenttransmission		ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
	JOIN registry R				ON R.idreg = T.idreg 
	JOIN registry R_DISTR		ON R_DISTR.idreg = T.idreg_distrained
WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and ISNULL(service.servicecode770,service.codeser) = '11_PIGNORA'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
--------------------------------------------------------------------------------
----- da rimuovere non appena sarà corretto l'errore dal software sogei --------
--------------------------------------------------------------------------------
		AND (R.cf IS NOT NULL) 
		AND (R.cf = @cf OR @cf IS NULL)
GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay, paymenttransmission.transmissiondate,	
	isnull(R.cf,R.p_iva),isnull(R_DISTR.cf,R_DISTR.p_iva), ISNULL(service.servicecode770,service.codeser)	
	
UNION
SELECT
		DISTINCT T.idreg
FROM
	(SELECT
		E.idexp as idexp,
		E.idreg as idreg,
		W.idreg_distrained as idreg_distrained,
		expenselast.idser as idser,
		expenselast.kpay as kpay
	FROM expense  E				
	JOIN expenselast			ON expenselast.idexp = E.idexp 
	JOIN service				ON service.idser = expenselast.idser
	JOIN wageaddition W			ON W.idser =  service.idser
	JOIN expensewageaddition EW		ON EW.ycon = W.ycon
									AND EW.ncon = W.ncon
	JOIN expenselink EL		ON EL.idparent = EW.idexp 
							AND EL.idchild =  E.idexp
	WHERE E.ymov = @annoredditi  
	GROUP BY E.idreg,E.idexp,expenselast.idser,W.idreg_distrained,
                expenselast.kpay) AS T
JOIN expensetotal		ON T.idexp = expensetotal.idexp  
JOIN expenseyear		ON T.idexp = expenseyear.idexp
JOIN service			ON T.idser = service.idser  
JOIN payment			ON T.kpay = payment.kpay  
JOIN paymenttransmission	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
JOIN registry R			ON R.idreg = T.idreg 
	JOIN registry R_DISTR		ON R_DISTR.idreg = T.idreg_distrained
--------------------------------------------------------------------------------
----- da rimuovere non appena sarà corretto l'errore dal software sogei --------
--------------------------------------------------------------------------------
		AND (R.cf IS NOT NULL) 
		AND (R.cf = @cf OR @cf IS NULL)
WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and ISNULL(service.servicecode770,service.codeser) = '11_PIGNORA_ESE'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay,paymenttransmission.transmissiondate,
	isnull(R.cf,R.p_iva),	isnull(R_DISTR.cf,R_DISTR.p_iva), ISNULL(service.servicecode770,service.codeser)		

	SELECT * FROM	#percipienti_record_H_2015
 
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 

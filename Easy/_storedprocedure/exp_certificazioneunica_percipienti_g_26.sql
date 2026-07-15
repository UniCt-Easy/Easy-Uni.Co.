/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_percipienti_g_26]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_percipienti_g_26]
GO
--setuser'amministrazione'
 
--exec exp_certificazioneunica_percipienti_g_26  NULL
CREATE PROCEDURE [exp_certificazioneunica_percipienti_g_26]
(
	@cf varchar(20)
)
 -- estraggo l'elenco dei percipienti, parasubordinati, che hanno eseguito prestazioni mappate con il Record G
 /* UNICAMPANIA 2025-2026 
 --- anagrafiche che hanno svolto sia  contratti cococo che missioni P E M
	77196
	107015
	113911
	143709
	147172
 */
AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2026

	declare @annoredditi int
	set @annoredditi = 2025


	CREATE TABLE #idreg_compensi_record_G_2025
	(
		idreg int,
		parasubcontract char(1),
		itineration char(1)
 
	)

	CREATE TABLE #percipienti_record_G_2025
	(
		idreg int,
		parasubcontract char(1),
		itineration char(1),
		progrCom int identity(1,1)
	)

	-----------------------------------------------------------------------------
    --- Estrazione dati relativi ai percipienti collabortori parasubordinati ----
    -----------------------------------------------------------------------------
    
	INSERT INTO #idreg_compensi_record_G_2025
		(
			idreg,
			parasubcontract,
			itineration
		)
		
	SELECT co.idreg, 'S',null        
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		JOIN registry ON registry.idreg = co.idreg
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND service.rec770kind='G'
		AND ce.disbursementdate is not null
	--------------------------------------------------------------------------------
	----- da rimuovere non appena sar corretto l'errore dal software SOGEI --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
	 GROUP BY co.idreg
	UNION   ALL 
	SELECT it.idreg, null, 'S'         
	FROM itineration it 
		JOIN service ON service.idser = it.idser
		JOIN registry ON registry.idreg = it.idreg
	WHERE  
		 EXISTS (SELECT * from  expenseitineration
					join expenselink ON expenselink.idparent = expenseitineration.idexp
					join expenselast ON expenselast.idexp = expenselink.idchild--expense.idexp
					join expensetaxofficial ON  expenselast.idexp = expensetaxofficial.idexp /*alla missione sono state applicate le ritenute fiscali*/
					join tax ON  tax.taxcode = expensetaxofficial.taxcode  
					join payment ON payment.kpay=expenselast.kpay
					WHERE expenseitineration.iditineration = it.iditineration 
					and payment.kpaymenttransmission is not null
					AND payment.ypay = @annoredditi
					AND tax.taxkind = 1 and isnull(tax.geoappliance,'N') = 'N')
		AND service.rec770kind='G'  
		AND service.flagcsausability = 0 --- per escludere le prestazioni estratte dal Record 8000
	--------------------------------------------------------------------------------
	----- da rimuovere non appena sar corretto l'errore dal software SOGEI --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
		AND (ISNULL(it.flagexcludefromcertificate,'N') = 'N')
 GROUP BY it.idreg

 INSERT INTO #percipienti_record_G_2025
 SELECT
    idreg,
    MAX(parasubcontract) AS parasubcontract,
    MAX(itineration)     AS itineration 
FROM #idreg_compensi_record_G_2025
GROUP BY idreg;

SELECT * FROM	#percipienti_record_G_2025 order by idreg, parasubcontract, itineration
 
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
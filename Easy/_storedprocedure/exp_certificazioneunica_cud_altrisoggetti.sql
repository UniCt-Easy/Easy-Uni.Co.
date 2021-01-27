
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_cud_altrisoggetti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_certificazioneunica_cud_altrisoggetti
GO
 --exec exp_certificazioneunica_cud_altrisoggetti 2016, null
CREATE PROCEDURE exp_certificazioneunica_cud_altrisoggetti 
 -- estraggo l'elenco dei percipienti, autonomi, o assimilati ai dipendenti, che hanno eseguito prestazioni mappate con il record 8000
 (
	@annodichiarazione int,
	@cf varchar(16) = null  -- per vederli tutti
 )
 AS BEGIN
	declare @annoredditi int
set @annoredditi = @annodichiarazione -1 
 --DECLARE @cf varchar(16)
 --declare @annodichiarazione int
 --set @annodichiarazione = 2016

 --set @cf = null -- per vederli tutti
 
 CREATE TABLE #contratti (idcon int, ycon int, ncon int, registry varchar(200))
INSERT INTO  #contratti (idcon, ycon, ncon, registry)
 SELECT DISTINCT co.idcon  , co.ycon, co.ncon  , registry.title     
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
	----- da rimuovere non appena sarà corretto l'errore dal software SOGEI --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND (registry.cf = @cf OR @cf IS NULL)
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
		 
		 
	SELECT  
		#contratti.idcon as '#Id Contr.',
		#contratti.ycon as 'Eserc. contratto', #contratti.ncon as 'N. contratto', #contratti.registry as 'Percipiente',
		exhibitedcud.cfotherdeputy as 'cf_altro_sostituto',
		exhibitedcud.taxablegross as 'reddito_conguagliato',
		exhibitedcud.irpefapplied as 'ritenute_irpef',
		exhibitedcud.regionaltaxapplied as 'addizionale_regionale_irpef',
		exhibitedcud.citytax_account as 'addizionale_comunale_irpef_acconto',
		exhibitedcud.citytaxapplied as 'addizionale_comunale_irpef_saldo'
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi 
			AND NOT EXISTS 
			(SELECT * FROM license 
			  WHERE  ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy )
			  
DROP TABLE #contratti 

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

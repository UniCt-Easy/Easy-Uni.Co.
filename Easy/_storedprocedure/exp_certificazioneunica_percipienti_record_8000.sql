
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_percipienti_record_8000]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_percipienti_record_8000]
GO
 
--[exp_certificazioneunica_percipienti_record_8000] 2015,'H'
CREATE PROCEDURE [exp_certificazioneunica_percipienti_record_8000]
 -- estraggo l'elenco dei percipienti, autonomi, o assimilati ai dipendenti, che hanno eseguito prestazioni mappate con il record 8000
 (
	@annodichiarazione int,
	@tiporecord char(1)
 )
 
AS BEGIN
	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1

 
	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	IF (@tiporecord = 'H') 
	BEGIN
	CREATE TABLE #percipienti_record_H 
	(
		idexp int,
		idreg int,
		idser int,
		description varchar(200),
		ymov  int,
		nmov  int
	)
	
	INSERT INTO #percipienti_record_H
	(
		idexp,
		idreg,
		idser,
		ymov,
		nmov,
		description
	)
	SELECT
		expense.idexp,--1
		expense.idreg,--2
		expenselast.idser,--3
		expense.ymov,
		expense.nmov,
		expense.description
	FROM expense
	join expenselast on expense.idexp = expenselast.idexp
	join payment 
		ON payment.kpay = expenselast.kpay
	join paymenttransmission
		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
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
		AND  ISNULL(service.flagcsausability,0) <> 0 
	
		SELECT 
		registry.idreg as 'idreg',
		registry.title as 'Percipiente',
		registry.cf as 'Codice Fiscale',
		registry.p_iva as 'Partita IVA',
		convert(varchar(4),#percipienti_record_H.ymov) + '/' +  convert(varchar(10),#percipienti_record_H.nmov) as 'Pagamento', 
		#percipienti_record_H.description as 'Descrizione',
		service.idser as 'idser',
		isnull(service.servicecode770,service.codeser)  as 'Codice Prestazione',
		service.description  as 'Prestazione',
		service.rec770kind as 'Record CU'
		FROM #percipienti_record_H 
		JOIN registry 
			ON #percipienti_record_H.idreg = registry.idreg
		JOIN service 
			ON #percipienti_record_H.idser = service.idser
		ORDER BY registry.title , #percipienti_record_H.ymov,#percipienti_record_H.nmov
	END
	ELSE
	BEGIN 
	CREATE TABLE #percipienti_record_G 
	(
		idreg int,
		idser int,
		ycon  int,
		ncon  int
	)

	-----------------------------------------------------------------------------
    --- Estrazione dati relativi ai percipienti collaboratori parasubordinati ----
    -----------------------------------------------------------------------------
    
	INSERT INTO #percipienti_record_G
		(
			idreg,
			idser,
			ycon,
			ncon
		)
		
		SELECT DISTINCT 
			co.idreg,         
			co.idser,
			co.ycon, 
			co.ncon 
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		JOIN registry ON registry.idreg = co.idreg
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		-- contratti che non sono a loro volta cud di altri
		--AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND service.rec770kind='G'
	--------------------------------------------------------------------------------
	----- da rimuovere non appena sarà corretto l'errore dal software SOGEI --------
	--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		AND  ISNULL(service.flagcsausability,0) <> 0 
	--SELECT * FROM	#percipienti_record_G
	
	SELECT 
	registry.idreg as 'idreg',
	registry.title as 'Percipiente',
	registry.cf as 'Codice Fiscale',
	registry.p_iva as 'Partita IVA',
	convert(varchar(4),#percipienti_record_G.ycon) + '/' +  convert(varchar(10),#percipienti_record_G.ncon) as 'Contratto Parasubordinato', 
	service.idser as 'idser',
	isnull(service.servicecode770, service.codeser)  as 'Codice Prestazione',
	service.description  as 'Prestazione',
	service.rec770kind as 'Record CU'
	FROM #percipienti_record_G 
	JOIN registry 
		ON #percipienti_record_G.idreg = registry.idreg
	JOIN service 
		ON #percipienti_record_G.idser = service.idser
	ORDER BY registry.title, #percipienti_record_G.ycon, #percipienti_record_G.ncon
	END
	

	

 
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

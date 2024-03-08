
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


--setuser 'amm'inistrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_autonomi_senza_cf]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_autonomi_senza_cf]
GO
 
--exec [exp_certificazioneunica_autonomi_senza_cf]   2015
CREATE PROCEDURE [exp_certificazioneunica_autonomi_senza_cf]
(
	@annodichiarazione int
)
-- estraggo l'elenco dei percipienti, autonomi, che hanno eseguito prestazioni mappate con il Record H
 
AS BEGIN
	--declare @annodichiarazione int
	--set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1 

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #prestazioni_trasmesse
	(
		idexp int,
		idreg int,
		idser int,
		motive770 varchar(10)
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #prestazioni_trasmesse
		(
			idexp, 
			idreg, 
			idser
		)
	SELECT
		expense.idexp,--1
		expense.idreg,--2
		expenselast.idser--3
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
		and (select count(*) from expensetaxofficial 
		      where expensetaxofficial.idexp=expense.idexp
		      AND   expensetaxofficial.stop IS NULL) > 0
		AND (registry.cf IS NULL) 
	
	update #prestazioni_trasmesse set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #prestazioni_trasmesse.idser
		AND motive770service.ayear = @annoredditi-1
		
	SELECT 
		registry.idreg		as '#Cod. Anagrafica',
		registry.title		as 'Percipiente',
		registry.cf			as 'Codice Fiscale',
		registry.p_iva		as 'Partita IVA',
		registry.foreigncf	as 'Codice Fiscale Estero',
		--expenseview.idexp	as '#idexp',
		expenseview.phase  + ' ' +convert(varchar(4),expenseview.ymov) + + '/' + convert(varchar(10),expenseview.nmov ) as 'Contabilizzazione',
		expenseview.description  as 'Descrizione',
		convert(varchar(4),expenseview.ypay) + + '/' + convert(varchar(10),expenseview.npay ) as 'Mandato',
		--service.idser		as '#idser',
		isnull(service.servicecode770, service.codeser)	+ '	' + service.description  	as 'Codice Prestazione',
		motive770.idmot		as 'Codice Causale',
		motive770.description as ' Descr. Causale'
	FROM #prestazioni_trasmesse
	JOIN expenseview  
		ON #prestazioni_trasmesse.idexp = expenseview.idexp
	JOIN registry 
		ON #prestazioni_trasmesse.idreg = registry.idreg
	JOIN service 
		ON #prestazioni_trasmesse.idser = service.idser
	LEFT OUTER JOIN motive770service
		ON motive770service.idser = service.idser
		AND   motive770service.ayear = @annoredditi
	LEFT OUTER JOIN motive770 
		ON motive770.idmot = motive770service.idmot
		AND motive770.ayear = @annoredditi
	ORDER BY registry.idreg
	
DROP TABLE #prestazioni_trasmesse
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

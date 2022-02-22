
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_percipienti_h_15]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_percipienti_h_15]
GO
 
--exec [exp_certificazioneunica_percipienti_h_15]  NULL 
CREATE PROCEDURE [exp_certificazioneunica_percipienti_h_15]
(
	@cf varchar(20)
 )
 -- estraggo l'elenco dei percipienti, autonomi, che hanno eseguito prestazioni mappate con il Record H
 
AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = 2014

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #percipienti_record_H_2014
	(
		idreg int,
		progrCom int identity(1,1)
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #percipienti_record_H_2014
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
	SELECT * FROM	#percipienti_record_H_2014
 
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

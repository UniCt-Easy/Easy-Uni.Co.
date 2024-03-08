
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_16_d_h]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_16_d_h]
GO

--exec exp_certificazioneunica_16_d_h  
CREATE PROCEDURE [exp_certificazioneunica_16_d_h]
 -- estraggo l'elenco dei percipienti, autonomi, che hanno eseguito prestazioni mappate con il Record H
 
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


	CREATE TABLE #prestazioni_trasmesse_2015
	(
		idexp int,
		idreg int,
		idser int,
		motive770 varchar(10)
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #prestazioni_trasmesse_2015
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
 

	update #prestazioni_trasmesse_2015 set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #prestazioni_trasmesse_2015.idser
		AND motive770service.ayear = @annoredditi-1
		

SELECT 
expenseview.idexp as 'idexp',
expenseview.phase  + ' ' +convert(varchar(4),expenseview.ymov) + + '/' + convert(varchar(10),expenseview.nmov ),
registry.idreg as 'idreg',
registry.title as 'Percipiente',
registry.cf as 'Codice Fiscale',
registry.p_iva as 'Codice Fiscale',
service.idser as 'idser',
isnull(service.servicecode770, service.codeser)  as 'Codice Prestazione',
service.description  as 'Prestazione',
motive770.idmot as 'Codice Causale',
motive770.description as ' Descr. Causale'
 FROM #prestazioni_trasmesse_2015
JOIN expenseview  
	ON #prestazioni_trasmesse_2015.idexp = expenseview.idexp
JOIN registry 
	ON #prestazioni_trasmesse_2015.idreg = registry.idreg
JOIN service 
	ON #prestazioni_trasmesse_2015.idser = service.idser
LEFT OUTER JOIN motive770service
	ON motive770service.idser = service.idser
	AND   motive770service.ayear = @annoredditi
LEFT OUTER JOIN motive770 
	ON motive770.idmot = motive770service.idmot
	AND motive770.ayear = @annoredditi
ORDER BY registry.idreg

CREATE TABLE #recD_H 
(
	progr int,
	quadro varchar(6),
	riga int,
	colonna varchar(3),
	stringa varchar(100),
	decimale decimal(19,2),
	intero int,
	data datetime
)
 
DECLARE registry_crs CURSOR FOR 
SELECT DISTINCT  isnull(cf,p_iva), #prestazioni_trasmesse_2015.idreg, title FROM #prestazioni_trasmesse_2015
		join registry on registry.idreg = #prestazioni_trasmesse_2015.idreg
		order by title
OPEN registry_crs

DECLARE @idreg int
DECLARE @progrCom int
DECLARE @title varchar(150)
DECLARE @au1cf varchar(16)

SET @progrCom = 1
FETCH NEXT FROM registry_crs into @au1cf, @idreg, @title
 	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	SELECT @au1cf,@idreg,@title
		--INSERT INTO #recD_H
		--EXEC [exp_certificazioneunica_d_16]  @idreg, @progrCom
		
		INSERT INTO #recD_H
		EXEC [exp_certificazioneunica_h_16]  @idreg, @progrCom
		
		SET @progrCom = @progrCom + 1
		FETCH NEXT FROM registry_crs into @au1cf, @idreg, @title
	END
	CLOSE registry_crs
	DEALLOCATE registry_crs
	SELECT * FROM #recD_H
DROP TABLE #prestazioni_trasmesse_2015
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

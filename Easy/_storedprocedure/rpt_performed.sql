
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE rpt_performed
	@ydoc		int,
	@kind		char(1),		--D/C
	@performed	char(1),		--S/N
	@start      smalldatetime,
  	@stop       smalldatetime 
AS
/* Versione 1.0.3 del 09/11/2016 ultima modifica: Alessandro */
--setuser 'amm'
--rpt_performed 2015,'D','N','01-01-2015','31-12-2015'
--rpt_performed 2013,'C','N','01-01-2013','31-12-2013'
BEGIN
CREATE TABLE #performed
(
	yban int,
	nban int,
	ydoc int, 	
	ndoc int,	
	stamphandling varchar(50),
	registry varchar(100),
	codefin	varchar(50),
	fin varchar(150),
	manager varchar(150),
	ytransmission int, 	
	ntransmission int,	
	transmissiondate smalldatetime,	
	adate smalldatetime,	
	printdate smalldatetime, 	
	annulmentdate smalldatetime,	
	transactiondate smalldatetime, 
	banktransaction decimal(19,2),
	totaldoc decimal(19,2),
	performeddoc decimal(19,2),
	total decimal(19,2),
	performed decimal(19,2),
	communicated decimal(19,2),
	communicatedperformed decimal(19,2),
	communicatednotperformed decimal(19,2),
	notcommunicated decimal(19,2),
	k int,
	idm int
)

IF UPPER(@kind) = 'D'
BEGIN
	INSERT INTO #performed
	(
		yban,
		nban,
		ydoc,	
		ndoc,
		stamphandling,
		registry,
		codefin,
		fin,
		manager,
		ytransmission,
		ntransmission,
		transmissiondate,
		adate,
		printdate,
		annulmentdate,
		transactiondate,
		banktransaction,
		totaldoc,performeddoc,
		total,		performed,
		communicated,
		communicatedperformed,
		k, idm
	) 
	SELECT
		banktransaction.yban,
		banktransaction.nban,
		paymentview.ypay,
		paymentview.npay,
		paymentview.stamphandling ,
		paymentview.registry , 
		paymentview.codefin,
		paymentview.finance,
		paymentview.manager,
		paymentview.ypaymenttransmission, 
		paymentview.npaymenttransmission,
		paymentview.transmissiondate,
		paymentview.adate,
		paymentview.printdate, 
		paymentview.annulmentdate,
		banktransaction.transactiondate,
		banktransaction.amount,

		--total per documento, questo valore totalizza il MANDATO 
		paymentview.total,

		--esitato per documento nel periodo. in alternativa si potrebbe prendere paymentview.performed
		ISNULL((SELECT SUM(P.amount)
				FROM banktransaction P
				WHERE P.transactiondate BETWEEN @start AND @stop	AND P.kpay = payment_bank.kpay),
				 0),

		-- Totale payment_bank  , da pulire per ottenere il totale fattura
		payment_bank.amount,

		-- Performed: l'eseguito è per definizione il banktransaction
		banktransaction.amount AS performed,
	
		-- Communicated
		case when paymentview.kpaymenttransmission is not null then payment_bank.amount else 0 end ,

		-- Communicated performed
		case when paymentview.kpaymenttransmission is not null then banktransaction.amount else 0 end ,

		payment_bank.kpay,payment_bank.idpay

		FROM paymentview 
			LEFT OUTER JOIN payment_bank ON payment_bank.kpay = paymentview.kpay
			LEFT OUTER JOIN banktransaction ON banktransaction.kpay = paymentview.kpay AND banktransaction.idpay = payment_bank.idpay
				AND banktransaction.transactiondate BETWEEN @start AND @stop
		WHERE paymentview.ypay = @ydoc AND (UPPER(@performed)='S' or transmissiondate BETWEEN @start AND @stop)
		ORDER BY paymentview.ypay,paymentview.npay, banktransaction.idpay
END
ELSE
BEGIN
	INSERT INTO #performed
	(
		yban,
		nban,
		ydoc,	
		ndoc,
		stamphandling,
		registry,
		codefin,
		fin,
		manager,
		ytransmission,
		ntransmission,
		transmissiondate,
		adate,
		printdate,
		annulmentdate,
		transactiondate,
		banktransaction,
		totaldoc,performeddoc,
		total,		performed,
		communicated,
		communicatedperformed,
		k, idm
	)
	SELECT
		banktransaction.yban,
		banktransaction.nban,
		proceedsview.ypro,
		proceedsview.npro,
		proceedsview.stamphandling ,
		proceedsview.registry , 
		proceedsview.codefin,
		proceedsview.finance,
		proceedsview.manager,
		proceedsview.yproceedstransmission, 
		proceedsview.nproceedstransmission,
		proceedsview.transmissiondate,
		proceedsview.adate,
		proceedsview.printdate, 
		proceedsview.annulmentdate,
		banktransaction.transactiondate,
		banktransaction.amount,
	

		--total per documento
		proceedsview.total,

		--esitato per documento
		ISNULL((SELECT SUM(P.amount)
				FROM banktransaction P
				WHERE P.transactiondate BETWEEN @start AND @stop AND P.kpro = proceedsview.kpro),
			 0),

		-- Total
		proceeds_bank.amount AS total,

		-- Performed
		banktransaction.amount AS performed,
	
		-- Communicated
		case when proceedsview.kproceedstransmission is not null then proceeds_bank.amount else 0 end ,

		-- Communicated performed
		case when proceedsview.kproceedstransmission is not null then banktransaction.amount else 0 end ,		

		proceeds_bank.kpro,proceeds_bank.idpro

		FROM proceedsview 
			LEFT OUTER JOIN proceeds_bank ON proceeds_bank.kpro = proceedsview.kpro
			LEFT OUTER JOIN banktransaction ON banktransaction.kpro = proceedsview.kpro AND banktransaction.idpro = proceeds_bank.idpro
				AND banktransaction.transactiondate BETWEEN @start AND @stop
		WHERE proceedsview.ypro = @ydoc AND (UPPER(@performed)='S' or transmissiondate BETWEEN @start AND @stop)
		ORDER BY proceedsview.ypro,proceedsview.npro, banktransaction.idpro
END

--non trasmesso PER DOCUMENTO
update #performed set notcommunicated = isnull(totaldoc,0)-isnull(performeddoc,0)

--rende total e comunicated sommabili dal report ove occorra
update #performed set total = 0,communicated=0
	where exists (select * from #performed P where P.idm = #performed.idm and P.k=#performed.k and #performed.yban=P.yban and #performed.nban<P.nban) 
			and yban is not null


--somma performed e total per documento, il report ne considera solo uno per gruppo
update #performed set total = ( select sum(total)  from #performed P where P.ydoc=#performed.ydoc and P.ndoc=#performed.ndoc)
update #performed set performed = ( select sum(performed)  from #performed P where P.ydoc=#performed.ydoc and P.ndoc=#performed.ndoc)
update #performed set communicatedperformed = ( select sum(communicatedperformed)  from #performed P where P.ydoc=#performed.ydoc and P.ndoc=#performed.ndoc)
update #performed set communicatednotperformed = isnull(total,0)-isnull(communicatedperformed,0)

--rende notcommunicated sommabile dal report ove occorra
update #performed set notcommunicated=0
	where exists (select * from #performed P where  P.k=#performed.k and #performed.yban=P.yban and #performed.nban<P.nban) 
			and yban is not null


if (UPPER(@performed)='S')
BEGIN
	SELECT 
		yban, nban,
		ydoc,	
		ndoc,
		stamphandling,
		registry,
		codefin,
		fin,
		manager,
		ytransmission,
		ntransmission,
		transmissiondate,
		adate,
		printdate,
		annulmentdate,
		transactiondate,
		ISNULL(banktransaction,0)									'banktransaction',
		ISNULL(total,0)												'total',
		ISNULL(performed,0)											'performed',
		ISNULL(total,0) - ISNULL(performed,0)						'notperformed',
		ISNULL(communicatedperformed,0)								'communicatedperformed',
		ISNULL(communicatednotperformed,0)							'communicatednotperformed',
		notcommunicated												'notcommunicated'
	FROM #performed
	WHERE ISNULL(totaldoc,0) = ISNULL(performeddoc,0) 
	AND ISNULL(totaldoc,0) <> 0  -- non visualizzo i documenti vuoti o azzerati
END
ELSE 
BEGIN
--Partially Performed
	SELECT 
		yban, 
		nban,
		ydoc,	
		ndoc,
		stamphandling,
		registry,
		codefin,
		fin,
		manager,
		ytransmission,
		ntransmission,
		transmissiondate,
		adate,
		printdate,
		annulmentdate,
		transactiondate,	
		ISNULL(banktransaction,0)									'banktransaction',
		ISNULL(total,0)												'total',
		ISNULL(performed,0)											'performed',
		ISNULL(total,0) - ISNULL(performed,0)						'notperformed',
		ISNULL(communicatedperformed,0)								'communicatedperformed',
		ISNULL(communicatednotperformed,0)							'communicatednotperformed',
		notcommunicated												'notcommunicated'
	FROM #performed
	WHERE ISNULL(totaldoc,0) <> ISNULL(performeddoc,0)
	AND ISNULL(totaldoc,0) <> 0 -- non visualizzo i documenti vuoti o azzerati
END

END
GO

SET QUOTED_IDENTIFIER OFF 
GO

SET ANSI_NULLS ON 
GO


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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_not_transmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_not_transmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_payment_not_transmitted 2009,'27-11-2009','T'

CREATE PROCEDURE [exp_payment_not_transmitted]
(
	@ayear int,	  	-- esercizio
	@printdate datetime,    -- filtro sulla data di stampa ufficiale
	@kind  char(1),         -- T: tutti, R:a regolarizzazione, N:non a regolarizzazione
	@annulled char(1)	-- T: tutti, S:annullati, N: non annullati
)
AS BEGIN
	CREATE TABLE #payment
	(
	phase varchar(50),
	idexp int,
	idreg int,
	registry varchar(100),
	ymov int,
	nmov int,
	doc varchar(35),
	docdate smalldatetime,
	description varchar(150),
	finance varchar(150),
	upb varchar(150),
	curramount decimal(19,2),
	taxamount decimal(19,2),
	netamount decimal(19,2),
	ypay int,
	npay int,
	flagarrear char(1),
	adate smalldatetime,
	printdate smalldatetime,
	transmissiondate smalldatetime,
	annulmentdate	smalldatetime
	)


	INSERT INTO #payment
	(phase,idexp,idreg,registry,ymov,nmov,doc,docdate, 
	description,finance,upb,curramount,ypay,npay,
	flagarrear,adate,printdate,transmissiondate, annulmentdate)
	SELECT 
	EL.phase,EL.idexp, EL.idreg,EL.registry, EL.ymov, EL.nmov,
	EL.doc, EL.docdate, EL.description,EL.finance, EL.upb, EL.curramount,
	EL.ypay,EL.npay, EL.flagarrear,P.adate,P.printdate,PT.transmissiondate,P.annulmentdate
	FROM expenselastview EL
	JOIN payment P
		ON P.kpay = EL.kpay
	LEFT OUTER JOIN paymenttransmission PT
		ON PT.kpaymenttransmission = P.kpaymenttransmission
	WHERE EL.ypay = @ayear 
	AND P.printdate <= @printdate AND
	(
		(EL.nbill IS NULL AND @kind = 'N') OR
		(EL.nbill IS NOT NULL AND @kind = 'R') OR
		(@kind = 'T')
	)
	AND
	(
		((EL.curramount > 0) AND @annulled = 'N') OR
		((EL.curramount = 0) AND @annulled = 'S') OR
		(@annulled = 'T')
	)
	AND ISNULL(PT.transmissiondate,'2079-01-01')>@printdate
	ORDER BY EL.ymov, EL.nmov,EL.ypay,EL.npay

	CREATE TABLE #retensions
	(
		ypro int,
		npro int,
		idexp int,
		idreg int,
		idinc int,
		curramount decimal(19,2)
	)
	
	insert into #retensions
	(idexp,idinc,ypro,npro,idreg,curramount)
	SELECT 
	p.idexp,e.idinc,di.ypro,di.npro,
	c.idreg,ie.curramount
	FROM #payment p
	JOIN income e
		ON e.idpayment = p.idexp
	JOIN incomelast il
		ON il.idinc = e.idinc
	JOIN incometotal ie
		ON e.idinc = ie.idinc
	JOIN proceeds di
		ON di.kpro = il.kpro
	JOIN registry c
		ON e.idreg = c.idreg
	WHERE  (
		(e.autokind = 6)  
		OR (e.autokind = 14) --'GENER' automatismo generico
		OR (e.autokind = 4 AND e.idreg = p.idreg)
	)
	AND ie.ayear = @ayear
	
	-- Calcolo dell'importo delle trattenute
	UPDATE #payment
	SET taxamount = 
	ISNULL(
		(SELECT SUM(curramount)
		FROM #retensions
		WHERE #retensions.idexp = #payment.idexp)
	,0)

	-- Calcolo del netto
	UPDATE #payment 
	SET netamount = ISNULL(curramount,0) - ISNULL(taxamount,0)

	SELECT 
		phase as 'Fase',
		ymov as 'Eserc. Mov.' ,
		nmov as 'Num. Mov',
		registry as 'Anagrafica',
		description as 'Descrizione',
		finance as 'Bilancio',
		upb as 'UPB',
		curramount as 'Importo Corrente',
		netamount as 'Netto a Pagare',
		flagarrear as 'Compet.',
		ypay as 'Eserc. Mandato',
		npay as 'Num. Mandato',
		adate as 'Emissione',
		printdate as 'Stampa Uff.',
		transmissiondate as 'Trasmissione',
		annulmentdate	as 'Annullamento'
	FROM #payment
	ORDER BY ymov, nmov,ypay, npay

END

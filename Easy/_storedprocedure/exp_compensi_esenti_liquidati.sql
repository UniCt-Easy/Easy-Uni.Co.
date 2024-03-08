
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_compensi_esenti_liquidati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_compensi_esenti_liquidati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 
-- EXEC [exp_compensi_esenti_liquidati] 2016,NULL, NULL
CREATE PROCEDURE [exp_compensi_esenti_liquidati]
	@ayear int,				  -- esercizio trasmissione 
	@idreg int,			      -- percipiente
	@module  varchar(15)	  -- modulo (occasionale, professionale, missioni ecc.)
AS BEGIN

CREATE TABLE #service
(
	idser int, 
	servicecode770 varchar(20),
	module varchar(15),
	description varchar(150),
	itinerationvisible char(1)
)
INSERT INTO #service (idser, servicecode770, description, module,itinerationvisible)
SELECT service.idser, isnull(service.servicecode770, service.codeser), 
service.description,  
CASE 
	 WHEN service.module IS NOT NULL THEN service.module
	 WHEN (service.module IS NULL AND ISNULL(service.itinerationvisible,'N') = 'S') THEN 'MISSIONE'
	 ELSE NULL
END,
service.itinerationvisible
FROM service
WHERE
 NOT EXISTS (SELECT * FROM servicetaxview
			   WHERE		 servicetaxview.idser = service.idser)
AND (UPPER(ISNULL(module,'')) = @module  OR @module IS NULL OR (@module = 'MISSIONE' AND ISNULL(service.itinerationvisible,'N') = 'S'))
AND servicecode770 <> '11_PIGNORA_ESE'

--SELECT * FROM #service		
CREATE TABLE #payroll
(
	idcon int, 
	idexp int,
	idpayroll int,
	idreg int,
	transmissiondate datetime,
	amount decimal(19,2)
)

CREATE TABLE #contratti
(
	idser int, 
	idreg int,
	idexp int,
	module varchar(15),
	idcon  int,
	iditineration int,
	ycon int,
	ncon int,
	transmissiondate datetime,
	pettycashdate datetime,
	amount decimal(19,2),  -- importo totale pagato
	pettycashamount decimal(19,2) , -- importo totale pagato con il fondo economale
	idpettycash int,
	yoperation int,
	noperation int
)

--1) COCOCO --  

INSERT INTO #contratti
	(idser, 
	idreg,
	module,
	idcon)
SELECT  
	parasubcontract.idser, 
	parasubcontract.idreg,
	#service.module,
	parasubcontract.idcon
FROM parasubcontract 
JOIN #service 
	ON parasubcontract.idser = #service.idser
WHERE 
EXISTS (SELECT payroll.idpayroll from payroll 
		join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
		join expenselink ON expenselink.idparent = expensepayroll.idexp
		join expenselast on expenselast.idexp = expenselink.idchild
		join payment on payment.kpay=expenselast.kpay
		where payroll.idcon = parasubcontract.idcon and payment.kpaymenttransmission is not null
AND payroll.fiscalyear = @ayear)
AND (parasubcontract.idreg = @idreg OR @idreg IS NULL)

--SELECT * FROM #contratti

INSERT INTO #payroll
(
	idcon, 
	idpayroll,
	idreg,
	idexp,
	transmissiondate,
	amount
)
SELECT 
	payroll.idcon, 
	payroll.idpayroll,
	#contratti.idreg,
	expenseyear.idexp,
	paymenttransmission.transmissiondate,
	expenseyear.amount
FROM payroll 
		JOIN #contratti     ON payroll.idcon        = #contratti.idcon 
		JOIN expensepayroll ON payroll.idpayroll	= expensepayroll.idpayroll
		JOIN expenselink    ON expenselink.idparent = expensepayroll.idexp
		JOIN expenselast    ON expenselast.idexp	= expenselink.idchild
		JOIN expenseyear    ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
		JOIN payment        ON payment.kpay         = expenselast.kpay
		JOIN paymenttransmission  ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
WHERE  paymenttransmission.ypaymenttransmission = @ayear 
 AND   payroll.fiscalyear = @ayear
 
--SELECT * FROM #contratti
--select * from #payroll

--2) DIPENDENTE
INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	transmissiondate,
	amount
	)
SELECT  
	wageaddition.idser, 
	wageaddition.idreg,
	expenseyear.idexp,
	#service.module,
	wageaddition.ycon,
	wageaddition.ncon,
	paymenttransmission.transmissiondate,
	expenseyear.amount
FROM wageaddition 
JOIN #service 
	 ON wageaddition.idser = #service.idser
JOIN expensewageaddition 
	 ON expensewageaddition.ycon = wageaddition.ycon
	 AND expensewageaddition.ncon = wageaddition.ncon
JOIN expenselink 
	ON expenselink.idparent = expensewageaddition.idexp
JOIN expenselast 
	ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear 
	ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment     
	ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  
	ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND (wageaddition.idreg = @idreg OR @idreg IS NULL)

--SELECT * FROM #contratti
--sp_help paymenttransmission
--3) MISSIONE

INSERT INTO #contratti
	(
	idser, 
	idreg,
	idexp,
	module,
	iditineration,
	ycon,
	ncon,
	transmissiondate,
	amount
	)
SELECT  
	itineration.idser, 
	itineration.idreg,
	expenseyear.idexp,
	#service.module,
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	paymenttransmission.transmissiondate,
	expenseyear.amount
FROM itineration 
JOIN #service 
	 ON itineration.idser = #service.idser
JOIN expenseitineration
	 ON expenseitineration.iditineration = itineration.iditineration
JOIN expenselink 
	 ON expenselink.idparent = expenseitineration.idexp
JOIN expenselast 
	 ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear 
	 ON expenselast.idexp    = expenseyear.idexp 
	AND expenseyear.ayear   = @ayear
JOIN payment     
	 ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  
	 ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND (itineration.idreg = @idreg OR @idreg IS NULL)

INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	pettycashdate,
	pettycashamount,
	idpettycash,
	yoperation,
	noperation  
	)
SELECT  
itin.idser, 
	itin.idreg,
	null,
	#service.module,
	itin.yitineration,
	itin.nitineration,
	p.adate,
	p.amount,
	p.idpettycash,
	p.yoperation,
	p.noperation 
FROM pettycashoperationitineration mov
JOIN itineration itin 
	ON  itin.iditineration = mov.iditineration
    JOIN #service 
	 ON itin.idser = #service.idser
	JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
	LEFT OUTER JOIN pettycashoperation rest
		ON rest.idpettycash = p.idpettycash
		AND rest.yoperation = p.yrestore
		AND rest.noperation = p.nrestore
WHERE p.yoperation = @ayear



--SELECT * FROM #contratti
--4) OCCASIONALE

INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	transmissiondate,
	amount
	)
SELECT  
	casualcontract.idser, 
	casualcontract.idreg,
	expenseyear.idexp,
	#service.module,
	casualcontract.ycon,
	casualcontract.ncon,
	paymenttransmission.transmissiondate,
	expenseyear.amount
FROM casualcontract 
JOIN #service 
	 ON casualcontract.idser = #service.idser
JOIN expensecasualcontract
	 ON expensecasualcontract.ycon = casualcontract.ycon
	 AND expensecasualcontract.ncon = casualcontract.ncon
JOIN expenselink 
	 ON expenselink.idparent = expensecasualcontract.idexp
JOIN expenselast 
	 ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear 
	 ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment     
	 ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  
	 ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND (casualcontract.idreg = @idreg OR @idreg IS NULL)

INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	pettycashdate,
	pettycashamount,
	idpettycash,
	yoperation,
	noperation  
	)
SELECT  
cas.idser, 
	cas.idreg,
	null,
	#service.module,
	cas.ycon,
	cas.ncon,
	p.adate,
	p.amount,
	p.idpettycash,
	p.yoperation,
	p.noperation 
FROM pettycashoperationcasualcontract mov
JOIN casualcontract cas 
	ON  cas.ycon = mov.ycon
    AND  cas.ncon = mov.ncon
    JOIN #service 
	 ON cas.idser = #service.idser
	JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
	LEFT OUTER JOIN pettycashoperation rest
		ON rest.idpettycash = p.idpettycash
		AND rest.yoperation = p.yrestore
		AND rest.noperation = p.nrestore
WHERE p.yoperation = @ayear
--SELECT * FROM #contratti
--5) PROFESSIONALE

-- pettycashoperationprofservice
-- pettycashoperationcasualcontract
-- pettycashoperationitineration


--SELECT SUM(p.amount)
--				FROM pettycashoperationprofservice mov
--				JOIN pettycashoperation p
--					ON mov.idpettycash = p.idpettycash
--					AND mov.yoperation = p.yoperation
--					AND mov.noperation = p.noperation
--				WHERE mov.ycon = profservice.ycon
--					AND mov.ncon = profservice.ncon


INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	transmissiondate,
	amount
	)
SELECT  
	profservice.idser, 
	profservice.idreg,
	expenseyear.idexp,
	#service.module,
	profservice.ycon,
	profservice.ncon,
	paymenttransmission.transmissiondate,
	expenseyear.amount
FROM profservice 
JOIN #service 
	 ON profservice.idser = #service.idser
--JOIN expenseprofservice
--	 ON expenseprofservice.ycon = profservice.ycon
--	 AND expenseprofservice.ncon = profservice.ncon
--JOIN expenselink 
--	ON expenselink.idparent = expenseprofservice.idexp
--JOIN expenselast 
--	ON expenselast.idexp    = expenselink.idchild
join expenseinvoice					
	on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
JOIN expenselast 
	ON expenselast.idexp    = expenseinvoice.idexp
JOIN expenseyear 
	ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment     
	ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  
	ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND (profservice.idreg = @idreg OR @idreg IS NULL)
 
 INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	pettycashdate,
	pettycashamount,
	idpettycash,
	yoperation,
	noperation  
	)
SELECT  
prof.idser, 
	prof.idreg,
	null,
	#service.module,
	prof.ycon,
	prof.ncon,
	p.adate,
	p.amount,
	p.idpettycash,
	p.yoperation,
	p.noperation 
FROM pettycashoperationprofservice mov
JOIN profservice prof 
	ON  prof.ycon = mov.ycon
    AND  prof.ncon = mov.ncon
    JOIN #service 
	 ON prof.idser = #service.idser
	JOIN pettycashoperation p
		ON mov.idpettycash = p.idpettycash
		AND mov.yoperation = p.yoperation
		AND mov.noperation = p.noperation
	LEFT OUTER JOIN pettycashoperation rest
		ON rest.idpettycash = p.idpettycash
		AND rest.yoperation = p.yrestore
		AND rest.noperation = p.nrestore
WHERE p.yoperation = @ayear

--SELECT * FROM #contratti
SELECT #service.servicecode770 as 'Cod. Prest.',#service.description as 'Prestazione', 
'Cedolino' as 'Compenso',
registry.title as 'Percipiente', registry.cf as 'CF', 
registry.p_iva as 'P. IVA',registry.birthdate as 'Data Nascita',
expenseview.phase as 'Fase',
expenseview.ymov as 'Eserc.', expenseview.nmov as 'N. Mov', 
expenseview.description as 'Descrizione',
#payroll.amount as 'Importo pagato',#payroll.transmissiondate as 'Data Trasm.'
FROM #payroll
JOIN #contratti
	 ON #contratti.idcon = #payroll.idcon
	 AND isnull(#contratti.module,'') = 'COCOCO'
JOIN registry ON #contratti.idreg = registry.idreg
JOIN #service ON  #contratti.idser = #service.idser
JOIN expenseview ON #payroll.idexp = expenseview.idexp
UNION
SELECT 
#service.servicecode770 as 'Cod. Prest.',#service.description as 'Prestazione', 
CASE  #contratti.module
	  WHEN 'MISSIONE'  THEN 'Miss. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'OCCASIONALE' THEN  'Contr. occas. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'PROFESSIONALE' THEN 'Contr. prof. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
      WHEN 'DIPENDENTE' THEN 'Retrib. aggiuntive ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
       ELSE null
END as 'Compenso',
registry.title as 'Percipiente', registry.cf as 'CF', 
registry.p_iva as 'P. IVA',registry.birthdate as 'Data Nascita',
expenseview.phase as 'Fase',
expenseview.ymov as 'Eserc.', expenseview.nmov as 'N. Mov', 
expenseview.description as 'Descrizione',
#contratti.amount as 'Importo pagato', #contratti.transmissiondate as 'Data Trasm.'
FROM #contratti
JOIN registry ON #contratti.idreg = registry.idreg
JOIN #service ON  #contratti.idser = #service.idser
JOIN expenseview ON #contratti.idexp = expenseview.idexp
WHERE   isnull(#contratti.module,'')<> 'COCOCO'
UNION
 SELECT 
 #service.servicecode770 as 'Cod. Prest.',#service.description as 'Prestazione',  
 CASE  #contratti.module
	  WHEN 'MISSIONE'  THEN 'Miss. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'OCCASIONALE' THEN  'Contr. occas. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'PROFESSIONALE' THEN 'Contr. prof. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  ELSE null
END as 'Compenso',
registry.title as 'Percipiente', registry.cf as 'CF', 
registry.p_iva  as 'P. IVA',registry.birthdate as 'Data Nascita',
'Contabilizzato con fondo Economale ' + pettycash.description as 'Fase',
#contratti.yoperation   as 'Eserc.', #contratti.noperation  as 'N. Mov', 
pettycashoperation.description as 'Descrizione',
#contratti.pettycashamount as 'Importo pagato', #contratti.pettycashdate as 'Data Trasm.'
FROM #contratti
JOIN registry ON #contratti.idreg = registry.idreg
JOIN #service ON  #contratti.idser = #service.idser
JOIN pettycashoperation ON #contratti.idpettycash = pettycashoperation.idpettycash
	 AND  #contratti.yoperation = pettycashoperation.yoperation
	 AND  #contratti.noperation = pettycashoperation.noperation
JOIN pettycash ON #contratti.idpettycash = pettycash.idpettycash
WHERE isnull(#contratti.module,'') <> 'COCOCO'
order BY registry.title, expenseview.ymov,expenseview.nmov
 
--SELECT * FROM			  

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


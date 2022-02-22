
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_compensi_dalia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_compensi_dalia]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
-- EXEC [exp_compensi_dalia] 2015,{ts '2015-01-01 01:02:03'},  {ts '2015-12-31 01:02:03'} , NULL, NULL, 'TUTTI'
CREATE PROCEDURE [exp_compensi_dalia]
	@ayear int,				  -- esercizio trasmissione 
	@start datetime,		  -- data inizio
    @stop datetime,	          -- data fine
	@idreg int,			      -- percipiente
	@module  varchar(15),	  -- modulo (occasionale, professionale, missioni ecc.)
	@kind varchar(20)	      -- tipo visualizzazione (-- 'TUTTI', 'ASSOCIATI', 'NONASSOC', 'NONAPPLIC')
AS BEGIN
 
DECLARE @idsortingdalia int
SELECT  @idsortingdalia = idsorkind FROM sortingkind WHERE codesorkind = 'VOCISPESA'

declare @idsorkind01 int
declare @sortingkind01 varchar(50)
select  @idsorkind01  = idsorkind01 from uniconfig
select  @sortingkind01  = description  from sortingkind where idsorkind = @idsorkind01

CREATE TABLE #service
(
	idser int, 
	codeser varchar(20),
	module varchar(15),
	description varchar(150),
	itinerationvisible char(1),
	flagdalia char(1)  -- abilita trasmissione a Dalia
)
INSERT INTO #service (idser, codeser, description, module,itinerationvisible,flagdalia)
SELECT service.idser, service.codeser, service.description,  
CASE 
	 WHEN service.module IS NOT NULL THEN service.module
	 WHEN (service.module IS NULL AND ISNULL(service.itinerationvisible,'N') = 'S') THEN 'MISSIONE'
	 ELSE NULL
END,
service.itinerationvisible,
service.flagdalia
FROM service
WHERE (UPPER(ISNULL(module,'')) = @module  OR @module IS NULL OR (@module = 'MISSIONE' AND ISNULL(service.itinerationvisible,'N') = 'S'))
AND codeser  NOT IN ('11_PIGNORA_ESE', '11_PIGNORA') 

--SELECT * FROM #service		
CREATE TABLE #payroll
(
	idcon int, 
	idexp int,
	idpayroll int,
	idreg int,
	npayroll int,
	transmissiondate datetime,
	amount decimal(19,2)
)

CREATE TABLE #contratti
(
	idser int, 	idreg int,	idexp int,
	module varchar(15),
	idcon  int,	iditineration int,	ycon int,	ncon int,
	transmissiondate datetime,	pettycashdate datetime,
	amount decimal(19,2),  -- importo totale pagato
	pettycashamount decimal(19,2) , -- importo totale pagato con il fondo economale
	idpettycash int,	yoperation int,	noperation int,
	classdalia varchar(20),	sortcode_01 varchar(20),
	codedip varchar(20),	codefunz varchar(20)
)

--1) COCOCO --  

INSERT INTO #contratti
	(idser, 	idreg,	module,	idcon,	ycon,	ncon,	classdalia,	sortcode_01,	codedip,codefunz)
SELECT  
	parasubcontract.idser, 	parasubcontract.idreg,
	#service.module,
	parasubcontract.idcon,	parasubcontract.ycon,	parasubcontract.ncon,
	SOR.sortcode,	S01.sortcode,	
	dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM parasubcontract 
JOIN #service								ON parasubcontract.idser = #service.idser
LEFT OUTER JOIN parasubcontractsorting PS	ON PS.idcon = parasubcontract.idcon
LEFT OUTER JOIN sorting SOR					ON PS.idsor = SOR.idsor   AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01					ON parasubcontract.idsor01 = S01.idsor
left outer join dalia_dipartimento on parasubcontract.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on parasubcontract.iddalia_funzionale=dalia_funzionale.iddalia_funzionale

WHERE 
EXISTS (SELECT payroll.idpayroll from payroll 
		join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
		join expenselink ON expenselink.idparent = expensepayroll.idexp
		join expenselast on expenselast.idexp = expenselink.idchild
		join payment on payment.kpay=expenselast.kpay
		where payroll.idcon = parasubcontract.idcon and payment.kpaymenttransmission is not null
AND payroll.fiscalyear = @ayear)
AND (parasubcontract.idreg = @idreg OR @idreg IS NULL)

 --sp_help sorting

--SELECT * FROM #contratti

INSERT INTO #payroll
(
	idcon, 
	idpayroll,
	npayroll,
	idreg,
	idexp,
	transmissiondate,
	amount 
)
SELECT 
	payroll.idcon, 
	payroll.idpayroll,
	payroll.npayroll,
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
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
 AND   payroll.fiscalyear = @ayear
 
--SELECT * FROM #contratti
--select * from #payroll

--2) DIPENDENTE
INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	transmissiondate,	amount,	classdalia,	sortcode_01,codedip,codefunz)
SELECT  
	wageaddition.idser, 	wageaddition.idreg,	expenseyear.idexp,
	#service.module,
	wageaddition.ycon,	wageaddition.ncon,
	paymenttransmission.transmissiondate,	expenseyear.amount,
	SOR.sortcode,	S01.sortcode,	dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM wageaddition 
JOIN #service			 ON wageaddition.idser = #service.idser
JOIN expensewageaddition  ON expensewageaddition.ycon = wageaddition.ycon AND expensewageaddition.ncon = wageaddition.ncon
JOIN expenselink			ON expenselink.idparent = expensewageaddition.idexp
JOIN expenselast			ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear			ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment				ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission	ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
LEFT OUTER JOIN wageadditionsorting WGS	ON WGS.ycon = wageaddition.ycon	AND WGS.ncon = wageaddition.ncon
LEFT OUTER JOIN sorting SOR	ON WGS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01	ON wageaddition.idsor01 = S01.idsor
left outer join dalia_dipartimento on wageaddition.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on wageaddition.iddalia_funzionale=dalia_funzionale.iddalia_funzionale

WHERE paymenttransmission.ypaymenttransmission = @ayear
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
AND (wageaddition.idreg = @idreg OR @idreg IS NULL)

--SELECT * FROM #contratti
--sp_help paymenttransmission
--3) MISSIONE

INSERT INTO #contratti	(
	idser, 	idreg,	idexp,	module,	iditineration,	ycon,	ncon,	transmissiondate,	amount,	classdalia,	sortcode_01,codedip,codefunz)
SELECT  
	itineration.idser,	itineration.idreg,	expenseyear.idexp,	#service.module,	itineration.iditineration,	itineration.yitineration,
	itineration.nitineration,	paymenttransmission.transmissiondate,	expenseyear.amount,	SOR.sortcode,	S01.sortcode,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM itineration 
JOIN #service				ON itineration.idser = #service.idser
JOIN expenseitineration		 ON expenseitineration.iditineration = itineration.iditineration
JOIN expenselink			 ON expenselink.idparent = expenseitineration.idexp
JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear			 ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear   = @ayear
JOIN payment				 ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  	 ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
LEFT OUTER JOIN itinerationsorting ITS	 ON ITS.iditineration = itineration.iditineration
LEFT OUTER JOIN sorting SOR	ON ITS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01	ON itineration.idsor01 = S01.idsor
left outer join dalia_dipartimento on itineration.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on itineration.iddalia_funzionale=dalia_funzionale.iddalia_funzionale

WHERE paymenttransmission.ypaymenttransmission = @ayear
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
AND (itineration.idreg = @idreg OR @idreg IS NULL)

INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	pettycashdate,	pettycashamount,	idpettycash,	yoperation,	noperation ,
	classdalia,	sortcode_01,codedip,codefunz)
SELECT  
itin.idser, 	itin.idreg,	null,	#service.module,	itin.yitineration,	itin.nitineration,	p.adate,	p.amount,	p.idpettycash,	p.yoperation,	p.noperation,
	SOR.sortcode ,	S01.sortcode, dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM pettycashoperationitineration mov
JOIN itineration itin 	ON  itin.iditineration = mov.iditineration
JOIN #service			 ON itin.idser = #service.idser
JOIN pettycashoperation p	ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation	AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest		ON rest.idpettycash = p.idpettycash	AND rest.yoperation = p.yrestore	AND rest.noperation = p.nrestore
LEFT OUTER JOIN itinerationsorting ITS		 ON ITS.iditineration = itin.iditineration
LEFT OUTER JOIN sorting SOR					ON ITS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01					ON itin.idsor01 = S01.idsor
left outer join dalia_dipartimento on itin.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on itin.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
WHERE p.yoperation = @ayear AND p.adate BETWEEN @start AND @stop 



--SELECT * FROM #contratti
--4) OCCASIONALE

INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	transmissiondate,	amount,	classdalia,	sortcode_01,codedip,codefunz)
SELECT  
	casualcontract.idser, 	casualcontract.idreg,	expenseyear.idexp,	#service.module,	casualcontract.ycon,casualcontract.ncon,
	paymenttransmission.transmissiondate,	expenseyear.amount,	SOR.sortcode,	S01.sortcode,dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM casualcontract 
JOIN #service				 ON casualcontract.idser = #service.idser
JOIN expensecasualcontract	 ON expensecasualcontract.ycon = casualcontract.ycon AND expensecasualcontract.ncon = casualcontract.ncon
JOIN expenselink			 ON expenselink.idparent = expensecasualcontract.idexp
JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear			 ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment				 ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  	 ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
LEFT OUTER JOIN casualcontractsorting CCS	ON CCS.ycon = casualcontract.ycon	AND CCS.ncon = casualcontract.ncon
LEFT OUTER JOIN sorting SOR	ON CCS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01	ON casualcontract.idsor01 = S01.idsor
left outer join dalia_dipartimento on casualcontract.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on casualcontract.iddalia_funzionale=dalia_funzionale.iddalia_funzionale

WHERE paymenttransmission.ypaymenttransmission = @ayear
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
AND (casualcontract.idreg = @idreg OR @idreg IS NULL)

INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	pettycashdate,	pettycashamount,	idpettycash,	yoperation,	noperation,	classdalia,	sortcode_01,
			codedip,codefunz)
SELECT  
cas.idser, 	cas.idreg,	null,	#service.module,	cas.ycon,	cas.ncon,	p.adate,
	p.amount,	p.idpettycash,	p.yoperation,	p.noperation ,	SOR.sortcode,	S01.sortcode,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM pettycashoperationcasualcontract mov
JOIN casualcontract cas 	ON  cas.ycon = mov.ycon    AND  cas.ncon = mov.ncon    
JOIN #service				 ON cas.idser = #service.idser
JOIN pettycashoperation p	ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation	AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest		ON rest.idpettycash = p.idpettycash		AND rest.yoperation = p.yrestore	AND rest.noperation = p.nrestore
LEFT OUTER JOIN casualcontractsorting CCS	ON CCS.ycon = cas.ycon	AND CCS.ncon = cas.ncon
LEFT OUTER JOIN sorting SOR	ON CCS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01	ON cas.idsor01 = S01.idsor
left outer join dalia_dipartimento on cas.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on cas.iddalia_funzionale=dalia_funzionale.iddalia_funzionale

WHERE p.yoperation = @ayear and p.adate   BETWEEN @start AND @stop 
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
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	transmissiondate,	amount,	classdalia,	sortcode_01,codedip,codefunz)
SELECT  
	profservice.idser, 	profservice.idreg,	expenseyear.idexp,	#service.module,	profservice.ycon,	profservice.ncon,	paymenttransmission.transmissiondate,
	expenseyear.amount,	SOR.sortcode,	S01.sortcode,dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM profservice 
JOIN #service 	 ON profservice.idser = #service.idser
--JOIN expenseprofservice	 ON expenseprofservice.ycon = profservice.ycon	 AND expenseprofservice.ncon = profservice.ncon
--JOIN expenselink 	ON expenselink.idparent = expenseprofservice.idexp
-- JOIN expenselast 	ON expenselast.idexp    = expenselink.idchild
join expenseinvoice		on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
JOIN expenselast		ON expenselast.idexp    = expenseinvoice.idexp
JOIN expenseyear		ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment			ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission		ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
LEFT OUTER JOIN profservicesorting PSS		ON PSS.ycon = profservice.ycon	AND PSS.ncon = profservice.ncon
LEFT OUTER JOIN sorting SOR		ON PSS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01		ON profservice.idsor01 = S01.idsor
left outer join dalia_dipartimento on profservice.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on profservice.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
AND (profservice.idreg = @idreg OR @idreg IS NULL)
 
 INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	pettycashdate,	pettycashamount,	idpettycash,	yoperation,	noperation  ,	classdalia,
	sortcode_01,codedip,codefunz)
SELECT  
prof.idser, 	prof.idreg,	null,	#service.module,	prof.ycon,	prof.ncon,	p.adate,	p.amount,	p.idpettycash,	p.yoperation,	p.noperation ,
	SOR.sortcode,	S01.sortcode,dalia_dipartimento.codedip,dalia_funzionale.codefunz
FROM pettycashoperationprofservice mov
JOIN profservice prof 	ON  prof.ycon = mov.ycon    AND  prof.ncon = mov.ncon
JOIN #service 	 ON prof.idser = #service.idser
JOIN pettycashoperation p		ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation	AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest		ON rest.idpettycash = p.idpettycash		AND rest.yoperation = p.yrestore	AND rest.noperation = p.nrestore
LEFT OUTER JOIN profservicesorting PSS	ON PSS.ycon = prof.ycon	AND PSS.ncon = prof.ncon
LEFT OUTER JOIN sorting SOR		ON PSS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN sorting S01		ON prof.idsor01 = S01.idsor
left outer join dalia_dipartimento on prof.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on prof.iddalia_funzionale=dalia_funzionale.iddalia_funzionale

WHERE p.yoperation = @ayear and p.adate BETWEEN @start AND @stop 

--SELECT * FROM #contratti
    ---- tipo visualizzazione (-- 'TUTTI', 'ASSOCIATI', 'NONASSOC', 'NONAPPLIC')

 

SELECT sortcode_01 as 'Dip. Afferenza',
#service.codeser as 'Cod. Prest.',#service.description as 'Prestazione', 
'Cedolino n°'  + CONVERT(varchar(4), #payroll.npayroll) + ' del Contratto Es.' + CONVERT(varchar(4), #contratti.ycon)  + '/' + CONVERT(varchar(10), #contratti.ncon)  as 'Compenso',
CASE 
	WHEN flagdalia  = 'N' AND classdalia IS NOT NULL   THEN 'Non applicabile ma valorizzato (Errore)'
	WHEN flagdalia  = 'N' AND classdalia IS NULL   THEN 'Non applicabile e non valorizzato sui compensi'
	WHEN flagdalia  = 'S' AND classdalia IS NOT NULL THEN 'Valorizzato'
	WHEN flagdalia  = 'S' AND classdalia IS NULL THEN 'Non Valorizzato (Errore)'
END as 'Trasmissione DALIA',
classdalia as 'Voce Spesa DALIA',
registry.title as 'Percipiente', ISNULL(registry.cf,registry.p_iva)   as 'CF/P. IVA', 
expenseview.phase as 'Fase',
CONVERT(varchar(4),expenseview.ymov)  + '/'+ CONVERT(varchar(4),expenseview.nmov) as 'Eserc./n°', 
expenseview.description as 'Descrizione',
#payroll.amount as 'Importo pagato',#payroll.transmissiondate as 'Data Trasm.',

FROM #payroll
JOIN #contratti
	 ON #contratti.idcon = #payroll.idcon
	 AND isnull(#contratti.module,'') = 'COCOCO'
JOIN registry ON #contratti.idreg = registry.idreg
JOIN #service ON  #contratti.idser = #service.idser
JOIN expenseview ON #payroll.idexp = expenseview.idexp
WHERE ( ISNULL(@kind,'TUTTI') = 'TUTTI' OR
		( ISNULL(@kind,'TUTTI') = 'NONAPPLIC'  AND flagdalia  = 'N'  )  OR
		( ISNULL(@kind,'TUTTI') = 'ASSOCIATI'  AND flagdalia  = 'S' AND classdalia IS NOT NULL) OR
		( ISNULL(@kind,'TUTTI') = 'NONASSOC'  AND flagdalia  = 'S' AND classdalia IS NULL) 
		)
UNION
SELECT  sortcode_01 as 'Dip. Afferenza',
#service.codeser as 'Cod. Prest.',#service.description as 'Prestazione', 
CASE  #contratti.module
	  WHEN 'MISSIONE'  THEN 'Miss. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'OCCASIONALE' THEN  'Contr. occas. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'PROFESSIONALE' THEN 'Contr. prof. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
      WHEN 'DIPENDENTE' THEN 'Retrib. aggiuntive ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
       ELSE null
END as 'Compenso',
CASE 
	WHEN flagdalia  = 'N' AND classdalia IS NOT NULL   THEN 'Non applicabile ma valorizzato (Errore)'
	WHEN flagdalia  = 'N' AND classdalia IS NULL   THEN 'Non applicabile e non valorizzato sui compensi'
	WHEN flagdalia  = 'S' AND classdalia IS NOT NULL THEN 'Valorizzato'
	WHEN flagdalia  = 'S' AND classdalia IS NULL THEN 'Non Valorizzato (Errore)'
END as 'Trasmissione DALIA',
classdalia as 'Voce Spesa DALIA',
registry.title as 'Percipiente', ISNULL(registry.cf,registry.p_iva)   as 'CF/P. IVA', 
expenseview.phase as 'Fase',
CONVERT(varchar(4),expenseview.ymov)  + '/'+ CONVERT(varchar(4),expenseview.nmov)  as 'Eserc./n°', 
expenseview.description as 'Descrizione',
#contratti.amount as 'Importo pagato', #contratti.transmissiondate as 'Data Trasm.'
FROM #contratti
JOIN registry ON #contratti.idreg = registry.idreg
JOIN #service ON  #contratti.idser = #service.idser
JOIN expenseview ON #contratti.idexp = expenseview.idexp
WHERE   isnull(#contratti.module,'')<> 'COCOCO'
AND ( ISNULL(@kind,'TUTTI') = 'TUTTI' OR
		( ISNULL(@kind,'TUTTI') = 'NONAPPLIC'  AND flagdalia  = 'N'  )  OR
		( ISNULL(@kind,'TUTTI') = 'ASSOCIATI'  AND flagdalia  = 'S' AND classdalia IS NOT NULL) OR
		( ISNULL(@kind,'TUTTI') = 'NONASSOC'  AND flagdalia  = 'S' AND classdalia IS NULL) 
		)
UNION
 SELECT  sortcode_01 as 'Dip. Afferenza',
 #service.codeser as 'Cod. Prest.',#service.description as 'Prestazione',  
 CASE  #contratti.module
	  WHEN 'MISSIONE'  THEN 'Miss. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'OCCASIONALE' THEN  'Contr. occas. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  WHEN 'PROFESSIONALE' THEN 'Contr. prof. ' + CONVERT(varchar(4), ycon)  + '/' + CONVERT(varchar(10), ncon) 
	  ELSE null
END as 'Compenso',
CASE 
	WHEN flagdalia  = 'N' AND classdalia IS NOT NULL   THEN 'Non applicabile ma valorizzato (Errore)'
	WHEN flagdalia  = 'N' AND classdalia IS NULL   THEN 'Non applicabile e non valorizzato sui compensi'
	WHEN flagdalia  = 'S' AND classdalia IS NOT NULL THEN 'Valorizzato'
	WHEN flagdalia  = 'S' AND classdalia IS NULL THEN 'Non Valorizzato (Errore)'
END as 'Trasmissione DALIA',
classdalia as 'Voce Spesa DALIA',
registry.title as 'Percipiente', ISNULL(registry.cf,registry.p_iva)   as 'CF/P. IVA', 
'Contabilizzato con fondo Economale ' + pettycash.description as 'Fase',
CONVERT(varchar(4),#contratti.yoperation)  + '/'+ CONVERT(varchar(4),#contratti.noperation)  as 'Eserc./n° Op.', 

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
AND ( ISNULL(@kind,'TUTTI') = 'TUTTI' OR
		( ISNULL(@kind,'TUTTI') = 'NONAPPLIC'  AND flagdalia  = 'N'  )  OR
		( ISNULL(@kind,'TUTTI') = 'ASSOCIATI'  AND flagdalia  = 'S' AND classdalia IS NOT NULL) OR
		( ISNULL(@kind,'TUTTI') = 'NONASSOC'  AND flagdalia  = 'S' AND classdalia IS NULL) 
		)
order BY registry.title
 
--SELECT * FROM			  

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



 

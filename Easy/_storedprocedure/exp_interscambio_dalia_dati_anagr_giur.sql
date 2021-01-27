
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_dalia_dati_anagr_giur]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_interscambio_dalia_dati_anagr_giur
GO
 
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE exp_interscambio_dalia_dati_anagr_giur
(
    @ayear int,		  -- esercizio di riferimento
    @start datetime,  -- data inizio
    @stop datetime	  -- data fine
)
 
AS

-- Esportazione di dati anagrafici giuridici dei dipendenti su piattaforma Dalia

--Le anagrafiche interessate da questa procedura dovranno rispettare congiuntamente le seguenti condizioni:
--1)    L’anagrafica di Easy sarà stata associata a una prestazione mappata per l'estrazione Dalia
--2)    La prestazione sarà stata liquidata nel periodo di riferimento
/*
Il tipo di campo può essere:
•numerico: i dati devono essere allineati a destra, riempiendo di zeri le cifre non significative; relativamente ai campi contenenti importi, deve essere fornito il segno nel primo carattere a sinistra del campo; 
•alfanumerico: i dati devono essere allineati a sinistra, con riempimento a spazi dei caratteri non significativi; relativamente al campo "codice fiscale del dipendente", lungo 16 caratteri, se il codice fiscale è di 11 cifre va allineato a sinistra e vanno riempiti a spazi i rimanenti 5 caratteri.
I valori di inizializzazione dei campi sono:
•zero, per i campi numerici;
•spazio, per i campi alfanumerici.
*/

/*
setuser 'amm'
setuser 'amministrazione'
exec exp_interscambio_dalia_dati_anagr_giur 2019, {ts '2019-01-01 00:00:00'},  {ts '2019-12-31 00:00:00'} 
*/
BEGIN
   
CREATE TABLE #error (message varchar(400))
   
CREATE TABLE #Anagrafiche
(
    idreg int,
	idexp int,
    cf varchar(16),
    matricola varchar(40),
	idser int,
	codeser varchar(20),
	module varchar(15),
	iddaliarecruitmentmotive int,
	codedip varchar(20),
	codefunz varchar(20),
	iddaliaposition int,
	codedaliaposition_contract varchar(10),
	legalstatusstart datetime 

)

DECLARE @codeclassvocispesa varchar(20)
SET @codeclassvocispesa = 'VOCISPESA'  
 

DECLARE @idsortingdalia int
SELECT  @idsortingdalia = idsorkind FROM sortingkind WHERE codesorkind = @codeclassvocispesa

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
SELECT service.idser, service.codeser, 
service.description,  
CASE 
	 WHEN service.module IS NOT NULL THEN service.module
	 WHEN (service.module IS NULL AND ISNULL(service.itinerationvisible,'N') = 'S') THEN 'MISSIONE'
	 ELSE NULL
END,
service.itinerationvisible,service.flagdalia
FROM service
WHERE ((service.module = 'MISSIONE' AND ISNULL(service.itinerationvisible,'N') = 'S')
OR    (service.module <> 'MISSIONE'))
AND codeser  NOT IN ('11_PIGNORA_ESE', '11_PIGNORA') 

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
    SELECT * FROM #error
    RETURN
END

 

CREATE TABLE #contratti
(
	idser int, 	idreg int,	idexp int,	module varchar(15),
	idcon  int,	iditineration int,	ycon int,	ncon int,
	transmissiondate datetime,	pettycashdate datetime,
	amount decimal(19,2),  -- importo totale pagato
	pettycashamount decimal(19,2) , -- importo totale pagato con il fondo economale
	idpettycash int,	yoperation int,	noperation int,
	classdalia varchar(20),	codedaliaposition_contract varchar(10) ,	iddaliarecruitmentmotive int,
	codedip varchar(20),	codefunz varchar(20),
	legalstatusstart datetime -- aggiungiamo la data inizio del ruolo utilizzato
)

--1) COCOCO --  

INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	idcon,	ycon,	ncon,	classdalia,	amount, 	codedaliaposition_contract,	transmissiondate,	iddaliarecruitmentmotive
			,codedip, codefunz, legalstatusstart )
SELECT   DISTINCT
	parasubcontract.idser, 	parasubcontract.idreg,	expenselast.idexp,	#service.module,	parasubcontract.idcon,	parasubcontract.ycon,	parasubcontract.ncon,
	SOR.sortcode,	expenseyear.amount,	dalia_position.codedaliaposition,	paymenttransmission.transmissiondate,	parasubcontract.iddaliarecruitmentmotive,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM  payroll 
JOIN parasubcontract on payroll.idcon = parasubcontract.idcon
JOIN #service 	ON parasubcontract.idser = #service.idser
JOIN parasubcontractsorting PS	ON PS.idcon = parasubcontract.idcon
JOIN sorting SOR	ON PS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
JOIN expensepayroll ON payroll.idpayroll	= expensepayroll.idpayroll
		JOIN expenselink    ON expenselink.idparent = expensepayroll.idexp
		JOIN expenselast    ON expenselast.idexp	= expenselink.idchild
		JOIN expenseyear    ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
		JOIN payment        ON payment.kpay         = expenselast.kpay
		JOIN paymenttransmission  ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
left outer join dalia_dipartimento on parasubcontract.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on parasubcontract.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN dalia_position	ON	parasubcontract.iddaliaposition = dalia_position.iddaliaposition
LEFT OUTER JOIN registrylegalstatus RLS ON parasubcontract.idreg = RLS.idreg AND (RLS.start <= parasubcontract.start) AND (RLS.stop IS NULL OR RLS.stop >= parasubcontract.stop)   

WHERE  paymenttransmission.ypaymenttransmission = @ayear 
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
AND    payroll.fiscalyear = @ayear

 
 
--SELECT * FROM #contratti
--select * from #payroll

--2) DIPENDENTE
INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	transmissiondate,	amount,	classdalia,	codedaliaposition_contract,	iddaliarecruitmentmotive,codedip,codefunz, legalstatusstart)
SELECT  
	wageaddition.idser, 	wageaddition.idreg,	expenseyear.idexp,	#service.module,	wageaddition.ycon,	wageaddition.ncon,
	paymenttransmission.transmissiondate,	expenseyear.amount,	SOR.sortcode,
	dalia_position.codedaliaposition,	wageaddition.iddaliarecruitmentmotive,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM wageaddition 
JOIN #service				ON wageaddition.idser = #service.idser
JOIN expensewageaddition	 ON expensewageaddition.ycon = wageaddition.ycon	 AND expensewageaddition.ncon = wageaddition.ncon
JOIN expenselink			ON expenselink.idparent = expensewageaddition.idexp
JOIN expenselast			ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear			ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment				ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  	ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
JOIN wageadditionsorting WGS	ON WGS.ycon = wageaddition.ycon	AND WGS.ncon = wageaddition.ncon
JOIN sorting SOR			ON WGS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	wageaddition.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on wageaddition.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on wageaddition.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON wageaddition.idreg = RLS.idreg AND (RLS.start <= wageaddition.start) AND (RLS.stop IS NULL OR RLS.stop >= wageaddition.stop)   
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND   paymenttransmission.transmissiondate BETWEEN @start AND @stop 

--SELECT * FROM #contratti
--sp_help paymenttransmission
--3) MISSIONE

INSERT INTO #contratti
	(	idser, 	idreg,	idexp,	module,	iditineration,	ycon,	ncon,	transmissiondate,	amount,	classdalia,	codedaliaposition_contract,	iddaliarecruitmentmotive,
			codedip,codefunz, legalstatusstart)
SELECT  
	itineration.idser,	itineration.idreg,	expenseyear.idexp,	#service.module,	itineration.iditineration,	itineration.yitineration,	itineration.nitineration,
	paymenttransmission.transmissiondate,	expenseyear.amount,	SOR.sortcode,
	dalia_position.codedaliaposition,	itineration.iddaliarecruitmentmotive,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM itineration 
JOIN #service				 ON itineration.idser = #service.idser
JOIN expenseitineration		 ON expenseitineration.iditineration = itineration.iditineration
JOIN expenselink			 ON expenselink.idparent = expenseitineration.idexp
JOIN expenselast			 ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear			 ON expenselast.idexp    = expenseyear.idexp 	AND expenseyear.ayear   = @ayear
JOIN payment				 ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission	 ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
JOIN itinerationsorting ITS	 ON ITS.iditineration = itineration.iditineration
JOIN sorting SOR			ON ITS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	itineration.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on itineration.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on itineration.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON itineration.idreg = RLS.idreg AND (RLS.start <= itineration.start) AND (RLS.stop IS NULL OR RLS.stop >= itineration.stop)   
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND paymenttransmission.transmissiondate BETWEEN @start AND @stop 

INSERT INTO #contratti
	(idser, 	idreg,	idexp,	module,	ycon,	ncon,	pettycashdate,	pettycashamount,	idpettycash,	yoperation,	noperation,	classdalia,
	codedaliaposition_contract,	iddaliarecruitmentmotive,codedip,codefunz, legalstatusstart)
SELECT  
itin.idser, itin.idreg,	null,	#service.module,	itin.yitineration,	itin.nitineration,	p.adate,	p.amount,	p.idpettycash,
	p.yoperation,	p.noperation,	SOR.sortcode,	dalia_position.codedaliaposition,	itin.iddaliarecruitmentmotive,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz,RLS.start
FROM pettycashoperationitineration mov
JOIN itineration itin		ON  itin.iditineration = mov.iditineration
JOIN #service 	 ON itin.idser = #service.idser
JOIN pettycashoperation p		ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest		ON rest.idpettycash = p.idpettycash		AND rest.yoperation = p.yrestore		AND rest.noperation = p.nrestore
JOIN itinerationsorting ITS		 ON ITS.iditineration = itin.iditineration
JOIN sorting SOR				ON ITS.idsor = SOR.idsor	AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	itin.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on itin.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on itin.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON itin.idreg = RLS.idreg AND (RLS.start <= p.adate) AND (RLS.stop IS NULL OR RLS.stop >= p.adate)   
WHERE p.yoperation = @ayear



--SELECT * FROM #contratti
--4) OCCASIONALE

INSERT INTO #contratti
	(idser, idreg,idexp,module,ycon,ncon,transmissiondate,amount,classdalia,codedaliaposition_contract,iddaliarecruitmentmotive,codedip,codefunz, legalstatusstart)
SELECT  
	casualcontract.idser, casualcontract.idreg,expenseyear.idexp,#service.module,casualcontract.ycon,casualcontract.ncon,paymenttransmission.transmissiondate,
	expenseyear.amount,SOR.sortcode,dalia_position.codedaliaposition,casualcontract.iddaliarecruitmentmotive,dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM casualcontract 
JOIN #service			 ON casualcontract.idser = #service.idser
JOIN expensecasualcontract		 ON expensecasualcontract.ycon = casualcontract.ycon	 AND expensecasualcontract.ncon = casualcontract.ncon
JOIN expenselink				 ON expenselink.idparent = expensecasualcontract.idexp
JOIN expenselast				 ON expenselast.idexp    = expenselink.idchild
JOIN expenseyear				 ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment					 ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission		 ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
JOIN casualcontractsorting CCS	ON CCS.ycon = casualcontract.ycon	AND CCS.ncon = casualcontract.ncon
JOIN sorting SOR				ON CCS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	casualcontract.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on casualcontract.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on casualcontract.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON casualcontract.idreg = RLS.idreg AND (RLS.start <= casualcontract.start) AND (RLS.stop IS NULL OR RLS.stop >= casualcontract.stop)   
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND paymenttransmission.transmissiondate BETWEEN @start AND @stop 

INSERT INTO #contratti
	(idser,	idreg,idexp,module,ycon,ncon,pettycashdate,pettycashamount,idpettycash,yoperation,noperation,classdalia,
	codedaliaposition_contract,iddaliarecruitmentmotive,codedip,codefunz, legalstatusstart)
SELECT  
	cas.idser,cas.idreg,null,#service.module,cas.ycon,cas.ncon,p.adate,p.amount,p.idpettycash,p.yoperation,p.noperation,
	SOR.sortcode,dalia_position.codedaliaposition,cas.iddaliarecruitmentmotive,dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM pettycashoperationcasualcontract mov
JOIN casualcontract cas ON  cas.ycon = mov.ycon   AND  cas.ncon = mov.ncon
JOIN #service  ON cas.idser = #service.idser
JOIN pettycashoperation p	ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation	AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest		ON rest.idpettycash = p.idpettycash	AND rest.yoperation = p.yrestore		AND rest.noperation = p.nrestore
JOIN casualcontractsorting CCS	ON CCS.ycon = cas.ycon	AND CCS.ncon = cas.ncon
JOIN sorting SOR				ON CCS.idsor = SOR.idsor    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	cas.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on cas.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on cas.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON cas.idreg = RLS.idreg AND (RLS.start <= p.adate) AND (RLS.stop IS NULL OR RLS.stop >= p.adate)   
WHERE p.yoperation = @ayear


INSERT INTO #contratti
	(idser,	idreg,idexp,module,ycon,ncon,transmissiondate,amount,classdalia,
	codedaliaposition_contract,iddaliarecruitmentmotive,codedip,codefunz, legalstatusstart)
SELECT  
	profservice.idser, profservice.idreg,expenseyear.idexp,#service.module,profservice.ycon,profservice.ncon,paymenttransmission.transmissiondate,expenseyear.amount,
	SOR.sortcode,dalia_position.codedaliaposition,profservice.iddaliarecruitmentmotive,
	dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM profservice 
JOIN #service	 ON profservice.idser = #service.idser
--JOIN expenseprofservice	 ON expenseprofservice.ycon = profservice.ycon	 AND expenseprofservice.ncon = profservice.ncon
--JOIN expenselink 	ON expenselink.idparent = expenseprofservice.idexp
join expenseinvoice		on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
JOIN expenselast		ON expenselast.idexp    = expenseinvoice.idexp --expenselink.idchild
JOIN expenseyear		ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment			ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission  	ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
JOIN profservicesorting PSS	ON PSS.ycon = profservice.ycon AND PSS.ncon = profservice.ncon
JOIN sorting SOR		ON PSS.idsor = SOR.idsor   AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position		ON	profservice.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on profservice.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on profservice.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON profservice.idreg = RLS.idreg AND (RLS.start <= profservice.start) AND (RLS.stop IS NULL OR RLS.stop >= profservice.stop)   
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND paymenttransmission.transmissiondate BETWEEN @start AND @stop 
 
 INSERT INTO #contratti
	(idser,	idreg,idexp,module,ycon,ncon,pettycashdate,pettycashamount,idpettycash,yoperation,noperation,
	classdalia,codedaliaposition_contract,iddaliarecruitmentmotive,codedip,codefunz, legalstatusstart)
SELECT  
prof.idser,	prof.idreg,null,#service.module,prof.ycon,prof.ncon,p.adate,p.amount,
	p.idpettycash,p.yoperation,p.noperation ,
	SOR.sortcode,dalia_position.codedaliaposition,prof.iddaliarecruitmentmotive,dalia_dipartimento.codedip,dalia_funzionale.codefunz, RLS.start
FROM pettycashoperationprofservice mov
JOIN profservice prof ON  prof.ycon = mov.ycon   AND  prof.ncon = mov.ncon
JOIN #service ON prof.idser = #service.idser
JOIN pettycashoperation p ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest ON rest.idpettycash = p.idpettycash AND rest.yoperation = p.yrestore AND rest.noperation = p.nrestore
JOIN profservicesorting PSS ON PSS.ycon = prof.ycon	AND PSS.ncon = prof.ncon
JOIN sorting SOR ON PSS.idsor = SOR.idsor   AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	prof.iddaliaposition = dalia_position.iddaliaposition
left outer join dalia_dipartimento on prof.iddalia_dipartimento=dalia_dipartimento.iddalia_dipartimento
left outer join dalia_funzionale on prof.iddalia_funzionale=dalia_funzionale.iddalia_funzionale
LEFT OUTER JOIN registrylegalstatus RLS ON prof.idreg = RLS.idreg AND (RLS.start <= p.adate) AND (RLS.stop IS NULL OR RLS.stop >= p.adate)   
WHERE p.yoperation = @ayear

-- Prendo i pagamenti  di prestazioni DALIA inviati in banca nel periodo considerato
INSERT INTO #Anagrafiche 
(   
    idreg,	idexp,    cf,    matricola,	idser,	codeser,	module ,
	iddaliarecruitmentmotive,codedip,codefunz, --iddaliaposition
	codedaliaposition_contract,
	legalstatusstart 
)
SELECT DISTINCT
	#contratti.idreg,	#contratti.idexp,	registry.cf,	registry.extmatricula,	service.idser,	service.codeser,	service.module,
	#contratti.iddaliarecruitmentmotive,#contratti.codedip,#contratti.codefunz, --iddaliaposition 
	#contratti.codedaliaposition_contract,
	#contratti.legalstatusstart 
FROM #contratti
JOIN service ON service.idser=#contratti.idser
JOIN registry ON #contratti.idreg = registry.idreg
WHERE (registry.cf IS NOT NULL) 


-- 1. Controllo se ci sono Anagrafiche da inserire
IF NOT EXISTS((SELECT * FROM #Anagrafiche))
BEGIN
    INSERT INTO #error (message)
    SELECT 'Non ci sono dati da trasmettere nel periodo indicato'
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
    SELECT * FROM #error
    RETURN
END

----------------------------------------------
------------  LETTURA DEGLI INDIRIZZI --------
----------------------------------------------

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM' -- DOMICILIO FISCALE

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF' -- RESIDENZA

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

--DECLARE @dateindi datetime
--SET @dateindi = @datagenerazione -- data generazione del flusso, data validità dell'indirizzo considerato


CREATE TABLE #address
(
    idaddresskind int,
    codeaddress varchar(20),
    idreg int,
    address varchar(100),
    location varchar(116),
    cap varchar(15),
    province varchar(2),
    idcity int,
    idnation int,
    nation varchar(65),
    start datetime,
    stop datetime,
	rif_address char(1)
)

INSERT INTO #address
(
    idaddresskind,
    codeaddress,
    idreg,
    address,
    location,
    cap,
    province,
    idcity,
    idnation,
    nation,
    start,
    stop
)
SELECT
    idaddresskind,
    codeaddress,
    idreg,
    registryaddress.address,
    ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
    registryaddress.cap,
    geo_country.province,
    registryaddress.idcity,
    CASE
        WHEN flagforeign = 'N' THEN 1
        ELSE geo_nation.idnation
    END,
    CASE
        WHEN flagforeign = 'N' THEN 'ITALIA'
        ELSE geo_nation.title
    END,
    registryaddress.start,
    registryaddress.stop
FROM registryaddress
LEFT OUTER JOIN geo_city      ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country   ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation    ON geo_nation.idnation = registryaddress.idnation
JOIN  address				    ON address.idaddress = registryaddress.idaddresskind
WHERE
registryaddress.active <>'N'
    AND registryaddress.start =
    (SELECT MAX(cdi.start)
    FROM registryaddress cdi
    WHERE cdi.idaddresskind = registryaddress.idaddresskind
        AND cdi.active <>'N'
        AND ((cdi.start IS NULL) OR (cdi.start <= @start))
        --AND ((cdi.stop IS NULL) OR (cdi.stop >= @stop) 	)  non controllare altrimenti rischia di dare problemi (task 9373)
        AND cdi.idreg = registryaddress.idreg)
        AND idreg IN (SELECT DISTINCT idreg FROM #Anagrafiche)
   
 
DELETE #address
WHERE #address.idaddresskind NOT IN (@nostand, @stand)
    AND EXISTS(
        SELECT * FROM #address r2
        WHERE #address.idreg = r2.idreg
            AND (r2.idaddresskind = @stand
            OR r2.idaddresskind = @nostand)
    )

UPDATE #address SET rif_address = 'S' 
WHERE  #address.nation = 'ITALIA'
AND    #address.idaddresskind = @nostand


UPDATE #address SET rif_address = 'S' 
WHERE  #address.nation = 'ITALIA'
AND    #address.idaddresskind NOT IN (@nostand, @stand)
AND NOT  EXISTS(
        SELECT * FROM #address r2
        WHERE #address.idreg = r2.idreg AND
        r2.rif_address = 'S'
    )
	  
--select * from #address

UPDATE #address SET rif_address = 'S' 
WHERE  #address.nation = 'ITALIA'
AND    #address.idaddresskind = @nostand
 AND   EXISTS(
        SELECT * FROM #address r2
        WHERE #address.idreg = r2.idreg
            AND (r2.idaddresskind = @stand
            OR r2.idaddresskind = @nostand)
    )


-- 2. Ogni anagrafica deve avere almeno un indirizzo associato
IF EXISTS(
    (SELECT * FROM #Anagrafiche WHERE idreg NOT IN
        (SELECT DISTINCT idreg FROM #address ind)))
BEGIN
    INSERT INTO #error (message)
    (SELECT 'L''anagrafica ' + registry.title +
    + ' non ha un indirizzo valido associato '
    FROM #Anagrafiche
    join registry ON #Anagrafiche.idreg = registry.idreg
    WHERE #Anagrafiche.idreg NOT IN
        (SELECT idreg FROM #address ind)
    )
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
    SELECT * FROM #error
    RETURN
END

DECLARE @2cf varchar(16)
	DECLARE @p_iva varchar(11)
	DECLARE @agencyname varchar(60) -- 60 è limite imposto per la compilazione del 770
	DECLARE @phonenumber varchar(20)
	DECLARE @fax varchar(20)
	DECLARE @email varchar(100)
	DECLARE @location varchar(40)
	DECLARE @country varchar(2)
	DECLARE @address varchar(35)
	DECLARE @cap varchar(5)
	SELECT
		@2cf = license.cf,
		@p_iva = license.p_iva,
		@agencyname = SUBSTRING(license.agencyname, 1, 60),
		@phonenumber = license.phonenumber,
		@fax = license.fax,
		@email = license.email,
		@location = SUBSTRING(isnull(geo_city.title, license.location), 1, 40),
		@country = license.country,
		@address = SUBSTRING(license.address1, 1, 30),
		@cap = license.cap
		FROM license
		left outer join geo_city on geo_city.idcity = license.idcity

	declare @codicecomuneente varchar(16)
	select  @codicecomuneente=value from geo_city_agency where idagency=1 and idcity in (select idcity from license) and idcode=1

	DECLARE @manager_cf varchar(16)
	DECLARE @manager_surname varchar(24)
	DECLARE @manager_forename varchar(20)
	DECLARE @manager_gender char(1)
	DECLARE @manager_b_date datetime
	DECLARE @manager_b_city varchar(65)
	DECLARE @manager_b_country varchar(2)
	DECLARE @manager_r_cap varchar(5)
	DECLARE @manager_r_address_e varchar(35)
	DECLARE	@manager_r_code_e varchar(3)
	DECLARE @manager_r_nation_e varchar(24)
	DECLARE @manager_r_location_e varchar(24)

	DECLARE @manager_phonenumber varchar(20)
	DECLARE @manager_annotations varchar(50)
	DECLARE @idtrasmissiondocument varchar(20)

	SET @idtrasmissiondocument = 'dalia'
	SELECT
		@manager_cf = cf,
		@manager_surname = SUBSTRING(surname,1,24),
		@manager_forename = SUBSTRING(forename,1,20),
		@manager_b_city = city,
		@manager_b_date = birthdate,
		@manager_gender = gender,
		@manager_b_country = province,
		@manager_phonenumber = phonenumber,
		@manager_annotations = annotations
	FROM trasmissionmanagerview
	WHERE idtrasmissiondocument = @idtrasmissiondocument AND ayear = @ayear


-- Record 1
-- 180029030568UNIVERSITA' DEGLI STUDI DELLA TUSCIA                        Via Santa Maria in Gradi n. 4 01100M082VT                                                                                A                                                                                                          
CREATE TABLE #RecordTesta(
	 TIPOREC		char(1),	    -- PIC X      Indicatore del tipo record. Valori ammessi: ‘1’ = record di testa.
	 CODENTEFONTE	varchar(11),    -- PIC X(11)  Codice fiscale dell'ente fonte (ente preposto all'invio dei dati).
	 DENOMENTE      varchar(60),    -- PIC X(60)  Denominazione dell'ente fonte.
	 INDIRIZZO      varchar(30),	-- PICX(30)   Indirizzo dell'ente fonte
	 CAP			varchar(05),	-- PIC X(05)  C.A.P. dell'ente fonte
	 CODCITTA 		varchar(4),		-- X(04).	  PIC  Codice catastale del comune dell'ente fonte.
	 PROVENTE		varchar(02),	-- PIC X(02)  Sigla della provincia dell'ente fonte.
	 PREFTELEFONO   varchar(5),     -- PIC X(05)  Numero del prefisso telefonico dell'ente fonte.
	 NUMTELEFONO	varchar(10),	-- PIC X(10)  Numero di telefono dell'ente fonte.
	 PREFFAX        varchar(5),	    -- PIC X(05)  Numero del prefisso del fax dell'ente fonte.
	 NUMFAX 		varchar(10),	-- PIC X(10)  Numero di fax dell'ente fonte.
	 PERSONARIF		varchar(30),    -- PIC X(30)  Persona responsabile dei dati inviati. 
	 DESCRQUA		varchar(20),    -- PIC X(20)  Descrizione della qualifica della persona di riferimento.
	 TIPOCODIFICA	 char(1),       -- PIC X.     Indicatore del tipo di codifica utilizzato per la predisposizione del supporto magnetico.
									--			  Valori ammessi: ‘E’ = codifica EBCDIC; ‘A’ = codifica ASCII
	 FILLER			 varchar(106)   -- PIC X(106)
)

INSERT INTO #RecordTesta(
	 TIPOREC		 , 
	 CODENTEFONTE    ,
	 DENOMENTE       ,
	 INDIRIZZO       ,
	 CAP			 ,
	 CODCITTA 	     ,
	 PROVENTE		 ,
	 PREFTELEFONO    ,
	 NUMTELEFONO	 ,
	 PREFFAX         ,
	 NUMFAX 		 ,
	 PERSONARIF	     ,
	 DESCRQUA        ,
	 TIPOCODIFICA	 ,
	 FILLER			 
)
SELECT
	1,					--TIPOREC		 , 
	SUBSTRING(ISNULL(@2cf,@p_iva),1,11) ,--CODENTEFONTE   ,
	@agencyname,		--DENOMENTE      ,
	@address,			--INDIRIZZO      ,
	@cap,				--CAP			 ,
	SUBSTRING(@codicecomuneente,1,4),	--CODCITTA 	     ,
	@country,   		--PROVENTE		 ,
	null,		    	--PREFTELEFONO   ,
	SUBSTRING(@phonenumber,1,10),		--NUMTELEFONO	 ,
	null,				--PREFFAX        ,
	SUBSTRING(@fax,1,10),				--NUMFAX 		 ,
	null,				--PERSONARIF	 ,
	null,				--DESCRQUA       ,
	'A',				--TIPOCODIFICA	 ,
	null				--FILLER			 

 
-- TRACCIATO DEL "RECORD DI ISTITUZIONE/ENTE/SEZIONE"
-- Esempio record:
-- 2800290305680000000000UNIVERSITA' DEGLI STUDI DELLA TUSCIA                        Via Santa Maria in Gradi n. 4 01100M082VT                              201510201510G                                                                                                                                      
CREATE TABLE #Record2( -- "RECORD DI ISTITUZIONE/ENTE/SEZIONE"
 TIPOREC			char(1),     -- PIC X.		Indicatore del tipo record. Valori ammessi: ‘2’ = record di istituzione/ente/sezione;
 CODISTITENTE		varchar(11), -- PIC X(11)   Codice fiscale dell'istituzione/ente cui si riferiscono i dati inviati.
 CODUNIORG          int,		 -- PIC 9(10)	Codice che individua la Struttura Organizzativa all'interno dell'istituzione/ente. 
								 -- Se i dati di dettaglio riportati nella successiva sezione sono noti solo a livello 
								 -- di istituzione/ente, tale campo non deve essere valorizzato.
 DENOMENTE          varchar(60), -- Denominazione della Struttura Organizzativa, se valorizzata, altrimenti Denominazione dell’istituzione/ente. 
 INDIRIZZO			varchar(30), -- Indirizzo della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 CAP				varchar(5),  -- C.A.P. della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 CODCITTÀ 			varchar(4),	 -- Codice catastale del comune della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 PROVENTE			varchar(2),	 -- Sigla della provincia della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 PREFTELEFONO		varchar(5),	 -- Numero del prefisso telefonico della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 NUMTELEFONO		varchar(10), -- Numero di telefono della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente..
 PREFFAX 			varchar(5),	 -- Numero del prefisso del fax della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 NUMFAX 			varchar(10), -- Numero di fax della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
 INIPERRIF 		    datetime,	 -- Data di inizio del periodo cui si riferiscono i dati (formato: AAAAMM).
 FINPERRIF		    datetime,	 -- PIC 9(06).Data di fine del periodo cui si riferiscono i dati (formato: AAAAMM).
 SEZIONE			char(1),     -- PIC X.Sezione cui si riferiscono i dati. Valori ammessi: ‘G’ = anagrafico-giuridica;
 FILLER				varchar(134) -- PIC X(134).
   )
 
----SELECT * FROM #address
INSERT INTO #Record2
(
 TIPOREC			,     
 CODISTITENTE		,  
 CODUNIORG          ,  
 DENOMENTE          ,  
 INDIRIZZO			,  
 CAP				,  
 CODCITTÀ 			, 
 PROVENTE			,  
 PREFTELEFONO		,  
 NUMTELEFONO		,  
 PREFFAX 		    ,	
 NUMFAX 			, 
 INIPERRIF 	        ,  
 FINPERRIF			,  
 SEZIONE		    ,   
 FILLER				 
)  
SELECT 
	'2',				--TIPOREC			,     
	SUBSTRING(ISNULL(@2cf,@p_iva),1,11),--CODISTITENTE		,  
	0,					--CODUNIORG         ,  
	@agencyname,		--DENOMENTE         ,  
	@address,			--INDIRIZZO			,  
	@cap,				--CAP				,
	SUBSTRING(@codicecomuneente,1,4),	--CODCITTA 			,
	@country,   		--PROVENTE			,
	null,		    	--PREFTELEFONO		,
	SUBSTRING(@phonenumber,1,10),		--NUMTELEFONO		,
	null,				--PREFFAX			,
	SUBSTRING(@fax,1,10),				--NUMFAX 			,
	@start,				--INIPERRIF 	    ,  
	@stop,				--FINPERRIF			,  
	'G',				--SEZIONE		    ,   
	null				--FILLER				 
 
 --3G800290305680000000000201510201510GVEFRC84B60F499E08000AR240GEVI                          FEDERICA                      F19840220    00     80029030568            VT    000 2015010120150101201501011313    00000000000000    000000000000000000 0000000000000000001                                    N 

CREATE TABLE #Record3
(
	TIPOREC			char(1),   -- PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	SEZIONE			char(1),   -- PIC X.Il valore ammesso è ‘G’ (anagrafico-giuridica).
	CODISTITENTE    varchar(11), -- PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODUNIORG		int, -- 9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	INIPERRIF		datetime, --9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	FINPERRIF		datetime, --9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODFISCDIP		varchar(16),--X(16).Codice fiscale del dipendente.
	CODCOMP  		varchar(2), --X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	CODSCOMP  		varchar(2), -- X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CODRUOLO		char(1), --PIC X. 
	CODPROFILO		varchar(03), -- PIC X(03).
	CODPOSECON		varchar(2),--  PIC X(02).
	COGNOME			varchar(30), --PIC X(30). Cognome del dipendente.
	NOME			varchar(30), --PIC X(30). Nome del dipendente.
	SESSO			char(1),	-- PIC X.  Sesso del dipendente. Valori ammessi: M = maschio; F = femmina.
	DATANASC		datetime,	-- PIC	9(8).Data di nascita del dipendente. AAAAMMGG.
	CATSP			varchar(2),	-- PIC X(02). Codice dell''eventuale categoria speciale di appartenenza del dipendente.
	STATOCIV		varchar(2),	-- PIC X(02). Codice stato civile.
	NUMFAM			varchar(2), -- PIC 9(02).Numero di persone che costituiscono il nucleo familiare (escluso il dipendente).
	CLASCONC		varchar(4), -- PIC X(04). Classe di concorso (solo per il personale della scuola).
	INDIN           char(1),	-- PIC X.Indicatore dello stato di servizio del dipendente presso l'istituzione/ente.
									 --spazio = appartenente all’ente di organico; 
									 --‘C’ = comandato da altri enti;
									 --‘F’ = fuori ruolo da altri enti;
									 --‘D’ = distaccato da altri enti;
									 --‘S’ = supplente.
	CODENTEAPP		varchar(11), -- PIC X(11).Codice fiscale dell'ente di appartenenza del dipendente.
								 -- Coincide con l’istituzione/ente, 
								 -- ad esclusione dei dipendenti comandati da altri enti - ovvero, per cui IND-IN è diverso da spazio.
	INDOUT			char(1),     -- PIC X.Indicatore dell’eventuale assegnazione del dipendente presso un ente diverso da quello di appartenenza.
								 --spazio = in servizio presso l’ente;
								 -- ‘C’ = comandato presso altri enti;
								 -- ‘F’ = fuori ruolo presso altri enti;
								 -- ‘D’ = distaccato presso altri enti.
	CODENTECOM		varchar(11), -- PIC X(11).--Codice fiscale dell'ente presso cui il dipendente è comandato, fuori ruolo o distaccato.
								 -- Da valorizzare solo se IND-OUT è diverso da spazio.
	PROVSERV  		varchar(2),  -- X(02). Sigla della provincia di servizio del dipendente.
	NAZSERVEST		varchar(4),  -- PIC X(04).Codice catastale della nazione della sede di servizio all'estero.
	GGSERVEST		int,		 -- PIC 9(03). Numero giorni di servizio prestati all'estero nel periodo di riferimento.
	ESTERO			char(1),	 -- PIC X. Indicatore dell’eventuale servizio alla data di fine periodo.
								 -- 0 = in servizio in Italia alla data di fine periodo
								 -- 1 = in servizio all’estero alla data di fine periodo.
	DATAASS			datetime,	 -- PIC 9(08).Data di assunzione del dipendente nella Pubblica Amministrazione. Formato: AAAAMMGG.
	DATAIMMENTE		datetime,	 -- PIC 9(08). Data giuridica di immissione del dipendente nell'ente o amministrazione in cui è in organico. AAAAMMGG.
	DATAIMMQUA		datetime,    -- PIC 9(08). Data dell'ultima variazione di classe, scatto o qualifica COD-QUA
								 --(ad esclusione dei casi di modifica del regime di impegno e del passaggio da
								 --"Ricercatore non confermato" a "Ricercatore non confermato dopo un anno").
								 --(Sostituisce: Data dell'ultima variazione di inquadramento, classe, scatto o qualifica). Formato: AAAAMMGG.
	CAUIMM  		varchar(2),	 -- X(02).Codice causale di immissione nell’ente.
	CAUIMMQUALIFICA varchar(2),  -- PIC X(02).Codice causale di immissione nella qualifica.
	CODCOMPQUAPREC  varchar(2),  -- PIC X(02).Codice del comparto relativo al ruolo, profilo, posizione economica precedenti. 
	CODSCOMPQUAPREC varchar(2),  -- PIC X(02).Codice del contratto relativo al ruolo, profilo, posizione economica precedenti. 
	CODRUOLOPREC    char(1),	 -- PIC X.Codice del ruolo precedente del dipendente. 
	CODPROFILOPREC  varchar(3),  -- PIC X(03).Codice del profilo precedente del dipendente. 
	CODPOSECONPREC  varchar(2),  -- PIC X(02). Codice posizione economica precedente del dipendente.
	DATACESS		datetime,	 -- PIC 9(08).Data giuridica di cessazione dal servizio. Formato: AAAAMMGG. Solo per i dipendenti cessati.
	CAUCESS         varchar(2),	 -- PIC X(02).Codice causale di cessazione dal servizio. Obbligatorio: Solo per i dipendenti cessati.
	IMMPARTTIME		char(1),	 -- PIC X. Indica se il dipendente è stato immesso nell’Ente direttamente in part-time o 	meno.
								 -- Valori ammessi: 1 = immesso direttamente in part-time; 0 = non immesso in part-time.
	--Tabella contenente i dati relativi ai periodi di part-time. La tabella contiene al massimo 2 elementi. 
	--Nel caso di più periodi di part-time, devono essere comunicati gli ultimi 2 periodi. Ogni elemento è costituito dai sottocampi che seguono. 

	--	TAB-PART-TIME OCCURS 2
	TABPARTTIMETIPO  char(1),   -- PIC X.  Tipo di part-time  
							    -- Valori ammessi: O = part-time orizzontale; V = part-time verticale. 
								-- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TABPARTTIMEDECORRENZA datetime, -- PIC 9(08). Data di inizio periodo di part-time Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TABPARTTIMESCADENZA   datetime, -- PIC 9(08).Data di fine periodo di part-time. Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TABPARTTIMEPERCENTUALE int,	   -- PIC 9(02). Percentuale di part-time nel periodo indicato.
									   --Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TIPORAPPORTO			  char(1), -- PIC X. Tipo di rapporto di lavoro del dipendente.
									   -- Valori ammessi: 0 = tempo indeterminato;
									   -- 1 = rapporto a termine.
									   -- Nel caso di ulteriore dettaglio sul rapporto a termine sono previsti i valori:
									   -- 2 = formazione lavoro
									   -- 3 = lavoro interinale
									   -- 4 = lavori socialmente utili
									   -- 5 = telelavoro
	FILLER1					  varchar(20), -- PIC X(20).
	FACOLTA					  varchar(5),  -- PIC X(5).Facolta' del dipendente. Cfr. ELENCO CODICI. 

	DIPIST					  varchar(5),  -- PIC X(5).Dipartimento, Istituto, Centro Comune o Struttura di Raccordo del dipendente. 
										   -- Se il dipendente non e' attribuibile a Dipartimento o Istituto, assegnare un codice dalla tabella ALTRE STRUTTURE. 
										   -- Cfr. ELENCO CODICI. 
	FACSUPPL				  varchar(5),  -- PIC X(5).Facolta' di supplenza. Cfr. ELENCO CODICI. 
	AREAFUNZ				  char(1),     -- PIC X(1).Area funzionale del dipendente (solo per il personale Tecnico / Amministrativo). 
										   -- Cfr. ELENCO CODICI. 
	ATTASSISTENZIALI		  char(1),	   -- PIC X(1).Indica se il dipendente viene impegnato in Attività di tipo Assistenziali convenzionate.
										   -- Valori ammessi: 
										   -- A = Presta Attività di tipo Assistenziale convenzionata;
										   -- N = NON presta Attività di tipo Assistenziale convenzionata.  
	FILLER2					  char(1) 	   -- PIC X(1).
)

INSERT INTO #Record3
(
	TIPOREC			,   -- PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	SEZIONE			,   -- PIC X.Il valore ammesso è ‘G’ (anagrafico-giuridica).
	CODISTITENTE    ,   -- PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODUNIORG		,   -- 9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	INIPERRIF		,   -- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	FINPERRIF		,   -- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODFISCDIP		,   -- X(16).Codice fiscale del dipendente.
	CODCOMP  		,   -- X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	CODSCOMP  		,   -- X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CODRUOLO		,	-- PIC X. 
	CODPROFILO		,	-- PIC X(03).
	CODPOSECON		,   -- PIC X(02).
	COGNOME			,   -- PIC X(30). Cognome del dipendente.
	NOME			,   -- PIC X(30). Nome del dipendente.
	SESSO			,	-- PIC X.  Sesso del dipendente. Valori ammessi: M = maschio; F = femmina.
	DATANASC		,	-- PIC 9(8).Data di nascita del dipendente. AAAAMMGG.
	CATSP			,	-- PIC X(02). Codice dell''eventuale categoria speciale di appartenenza del dipendente.
	STATOCIV		,	-- PIC X(02). Codice stato civile.
	NUMFAM			,   -- PIC 9(02).Numero di persone che costituiscono il nucleo familiare (escluso il dipendente).
	CLASCONC		,   -- PIC X(04). Classe di concorso (solo per il personale della scuola).
	INDIN           ,	-- PIC X.Indicatore dello stato di servizio del dipendente presso l'istituzione/ente.
									 --spazio = appartenente all’ente di organico; 
									 --‘C’ = comandato da altri enti;
									 --‘F’ = fuori ruolo da altri enti;
									 --‘D’ = distaccato da altri enti;
									 --‘S’ = supplente.
	CODENTEAPP		, -- PIC X(11).Codice fiscale dell'ente di appartenenza del dipendente.
								 -- Coincide con l’istituzione/ente, 
								 -- ad esclusione dei dipendenti comandati da altri enti - ovvero, per cui IND-IN è diverso da spazio.
	INDOUT			,            -- PIC X.Indicatore dell’eventuale assegnazione del dipendente presso un ente diverso da quello di appartenenza.
								 -- spazio = in servizio presso l’ente;
								 -- ‘C’ = comandato presso altri enti;
								 -- ‘F’ = fuori ruolo presso altri enti;
								 -- ‘D’ = distaccato presso altri enti.
	CODENTECOM		,  -- PIC X(11).--Codice fiscale dell'ente presso cui il dipendente è comandato, fuori ruolo o distaccato.
					   -- Da valorizzare solo se IND-OUT è diverso da spazio.
	PROVSERV  		,  -- X(02). Sigla della provincia di servizio del dipendente.
	NAZSERVEST		,  -- PIC X(04).Codice catastale della nazione della sede di servizio all'estero.
	GGSERVEST		,  -- PIC 9(03). Numero giorni di servizio prestati all'estero nel periodo di riferimento.
	ESTERO			,  -- PIC X. Indicatore dell’eventuale servizio alla data di fine periodo.
								 -- 0 = in servizio in Italia alla data di fine periodo
								 -- 1 = in servizio all’estero alla data di fine periodo.
	DATAASS			,  -- PIC 9(08).Data di assunzione del dipendente nella Pubblica Amministrazione. Formato: AAAAMMGG.
	DATAIMMENTE		,  -- PIC 9(08). Data giuridica di immissione del dipendente nell'ente o amministrazione in cui è in organico. AAAAMMGG.
	DATAIMMQUA		,  -- PIC 9(08). Data dell'ultima variazione di classe, scatto o qualifica COD-QUA
								 --(ad esclusione dei casi di modifica del regime di impegno e del passaggio da
								 --"Ricercatore non confermato" a "Ricercatore non confermato dopo un anno").
								 --(Sostituisce: Data dell'ultima variazione di inquadramento, classe, scatto o qualifica). Formato: AAAAMMGG.
	CAUIMM  		 ,	-- X(02).Codice causale di immissione nell’ente.
	CAUIMMQUALIFICA  ,  -- PIC X(02).Codice causale di immissione nella qualifica.
	CODCOMPQUAPREC   ,  -- PIC X(02).Codice del comparto relativo al ruolo, profilo, posizione economica precedenti. 
	CODSCOMPQUAPREC  ,  -- PIC X(02).Codice del contratto relativo al ruolo, profilo, posizione economica precedenti. 
	CODRUOLOPREC     ,	-- PIC X.Codice del ruolo precedente del dipendente. 
	CODPROFILOPREC   ,  -- PIC X(03).Codice del profilo precedente del dipendente. 
	CODPOSECONPREC   ,  -- PIC X(02). Codice posizione economica precedente del dipendente.
	DATACESS		 ,	-- PIC 9(08).Data giuridica di cessazione dal servizio. Formato: AAAAMMGG. Solo per i dipendenti cessati.
	CAUCESS          ,	-- PIC X(02).Codice causale di cessazione dal servizio. Obbligatorio: Solo per i dipendenti cessati.
	IMMPARTTIME		 ,	-- PIC X. Indica se il dipendente è stato immesso nell’Ente direttamente in part-time o 	meno.
									--Valori ammessi: 1 = immesso direttamente in part-time; 0 = non immesso in part-time.
	--Tabella contenente i dati relativi ai periodi di part-time. La tabella contiene al massimo 2 elementi. 
	--Nel caso di più periodi di part-time, devono essere comunicati gli ultimi 2 periodi. Ogni elemento è costituito dai sottocampi che seguono. 

	--	TAB-PART-TIME OCCURS 2
	TABPARTTIMETIPO  ,   -- PIC X.  Tipo di part-time  
							    -- Valori ammessi: O = part-time orizzontale; V = part-time verticale. 
								-- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TABPARTTIMEDECORRENZA  , -- PIC 9(08). Data di inizio periodo di part-time Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TABPARTTIMESCADENZA    , -- PIC 9(08).Data di fine periodo di part-time. Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TABPARTTIMEPERCENTUALE , -- PIC 9(02). Percentuale di part-time nel periodo indicato.
									   --Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	TIPORAPPORTO			, -- PIC X. Tipo di rapporto di lavoro del dipendente.
									   -- Valori ammessi: 0 = tempo indeterminato;
									   -- 1 = rapporto a termine.
									   -- Nel caso di ulteriore dettaglio sul rapporto a termine sono previsti i valori:
									   -- 2 = formazione lavoro
									   -- 3 = lavoro interinale
									   -- 4 = lavori socialmente utili
									   -- 5 = telelavoro
	FILLER1					, -- PIC X(20).
	FACOLTA					, -- PIC X(5).Facolta' del dipendente. Cfr. ELENCO CODICI. 

	DIPIST					, -- PIC X(5).Dipartimento, Istituto, Centro Comune o Struttura di Raccordo del dipendente. 
							  -- Se il dipendente non e' attribuibile a Dipartimento o Istituto, assegnare un codice dalla tabella ALTRE STRUTTURE. 
							  -- Cfr. ELENCO CODICI. 
	FACSUPPL				, -- PIC X(5).Facolta' di supplenza. Cfr. ELENCO CODICI. 
	AREAFUNZ				, -- PIC X(1).Area funzionale del dipendente (solo per il personale Tecnico / Amministrativo). 
							  -- Cfr. ELENCO CODICI. 
	ATTASSISTENZIALI		, -- PIC X(1).Indica se il dipendente viene impegnato in Attività di tipo Assistenziali convenzionate.
								   -- Valori ammessi: 
								   -- A = Presta Attività di tipo Assistenziale convenzionata;
								   -- N = NON presta Attività di tipo Assistenziale convenzionata.  
	FILLER2					  -- PIC X(1).

) 
--3G800290305680000000000201510201510GVEFRC84B60F499E08000AR240GEVI                          FEDERICA                      F19840220    00     80029030568            VT    000 2015010120150101201501011313    00000000000000    000000000000000000 0000000000000000001                                    N 
 
SELECT DISTINCT
	'3',					--TIPOREC			,     PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	'G',					--SEZIONE			,     PIC X.Il valore ammesso è ‘G’ (anagrafico-giuridica).
	ISNULL(@2cf,@p_iva),	--CODISTITENTE		,     PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	0,						--CODUNIORG			,	  9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	@start,		   		    --INIPERRIF			,	  9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	@stop,				    --FINPERRIF			,     9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	R.cf,					--CODFISCDIP		,     X(16).Codice fiscale del dipendente.
	'08',					--CODCOMP  			,     X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	'00',					--CODSCOMP  		,     X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
							--COD-QUA				  Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
													  --tabella qualifiche per il comparto università (codice a sei cifre)
	SUBSTRING(#Anagrafiche.codedaliaposition_contract,1,1),			  --CODRUOLO		,	  PIC X. 
	SUBSTRING(#Anagrafiche.codedaliaposition_contract,2,3),			  --CODPROFILO		,	  PIC X(03).
	SUBSTRING(#Anagrafiche.codedaliaposition_contract,5,2),			  --CODPOSECON		,     PIC X(02).
	R.forename,				--COGNOME			,	  PIC X(30). Cognome del dipendente.
	R.surname,				--NOME				,     PIC X(30). Nome del dipendente.
	R.gender,				--SESSO				,	  PIC X.  Sesso del dipendente. Valori ammessi: M = maschio; F = femmina.
	--CONVERT (varchar(8),R.birthdate	,112)	,	  --DATANASC			,	  PIC 9(8).Data di nascita del dipendente. AAAAMMGG.
	R.birthdate,
	null,					--CATSP				,	  PIC X(02). Codice dell''eventuale categoria speciale di appartenenza del dipendente.
	CASE R.idmaritalstatus 
		 WHEN 1  THEN   '01' -- CELIBE
		 WHEN 2  THEN   '01' -- NUBILE
		 WHEN 3  THEN   '03' -- VEDOVO
		 WHEN 4  THEN   '03' -- VEDOVA
		 WHEN 5  THEN   '02' -- CONIUGATO
		 ELSE null		 -- NON ASSEGNATO
	END,				 --STATOCIV			,	  PIC X(02). Codice stato civile.
	0,					--NUMFAM			,	  PIC 9(02).Numero di persone che costituiscono il nucleo familiare (escluso il dipendente).
	null,	--CLASCONC			,	  PIC X(04). Classe di concorso (solo per il personale della scuola).
	null,	--INDIN				,	  PIC X.Indicatore dello stato di servizio del dipendente presso l'istituzione/ente.
			--								 --spazio = appartenente all’ente di organico; 
			--								 --‘C’ = comandato da altri enti;
			--								 --‘F’ = fuori ruolo da altri enti;
			--								 --‘D’ = distaccato da altri enti;
			--								 --‘S’ = supplente.
	ISNULL(@2cf,@p_iva),	--CODENTEAPP		,	  PIC X(11).Codice fiscale dell'ente di appartenenza del dipendente.
			--							 -- Coincide con l’istituzione/ente, 
			--							 -- ad esclusione dei dipendenti comandati da altri enti - ovvero, per cui IND-IN è diverso da spazio.
	null,	--INDOUT			,     PIC X.Indicatore dell’eventuale assegnazione del dipendente presso un ente diverso da quello di appartenenza.
			--							 -- spazio = in servizio presso l’ente;
			--							 -- ‘C’ = comandato presso altri enti;
			--							 -- ‘F’ = fuori ruolo presso altri enti;
			--							 -- ‘D’ = distaccato presso altri enti.
	null,	--CODENTECOM		 ,    PIC X(11).--Codice fiscale dell'ente presso cui il dipendente è comandato, fuori ruolo o distaccato.
			--						  Da valorizzare solo se IND-OUT è diverso da spazio.
	@country,--PROVSERV  		 ,    X(02). Sigla della provincia di servizio del dipendente.
	null,	--NAZSERVEST		 ,    PIC X(04).Codice catastale della nazione della sede di servizio all'estero.
	0,		--GGSERVEST			 ,	  PIC 9(03). Numero giorni di servizio prestati all'estero nel periodo di riferimento.
	null,	--ESTERO			 ,	  PIC X. Indicatore dell’eventuale servizio alla data di fine periodo.
			--							 -- 0 = in servizio in Italia alla data di fine periodo
			--							 -- 1 = in servizio all’estero alla data di fine periodo.
	ISNULL (#Anagrafiche.legalstatusstart, @start),	--DATAASS			 ,	  PIC 9(08).Data di assunzione del dipendente nella Pubblica Amministrazione. Formato: AAAAMMGG.
	ISNULL (#Anagrafiche.legalstatusstart, @start),	--DATAIMMENTE		 ,	  PIC 9(08). Data giuridica di immissione del dipendente nell'ente o amministrazione in cui è in organico. AAAAMMGG.
	ISNULL (#Anagrafiche.legalstatusstart, @start),	--DATAIMMQUA		 ,    PIC 9(08). Data dell'ultima variazione di classe, scatto o qualifica COD-QUA
			--							 --(ad esclusione dei casi di modifica del regime di impegno e del passaggio da
			--							 --"Ricercatore non confermato" a "Ricercatore non confermato dopo un anno").
			--							 --(Sostituisce: Data dell'ultima variazione di inquadramento, classe, scatto o qualifica). Formato: C.
	isnull(#Anagrafiche.iddaliarecruitmentmotive,13),		--NOMINA A TEMPO DETERMINATO ,	--CAUIMM  			 ,	  X(02).Codice causale di immissione nell’ente.
	isnull(#Anagrafiche.iddaliarecruitmentmotive,13),	    --NOMINA A TEMPO DETERMINATO  CAUIMMQUALIFICA    ,    PIC X(02).Codice causale di immissione nella qualifica.
	null,	--CODCOMPQUAPREC     ,    PIC X(02).Codice del comparto relativo al ruolo, profilo, posizione economica precedenti. 
	null,	--CODSCOMPQUAPREC    ,    PIC X(02).Codice del contratto relativo al ruolo, profilo, posizione economica precedenti. 
	null,	--CODRUOLOPREC       ,	  PIC X.Codice del ruolo precedente del dipendente. 
	null,	--CODPROFILOPREC     ,    PIC X(03).Codice del profilo precedente del dipendente. 
	null,	--CODPOSECONPREC     ,    PIC X(02). Codice posizione economica precedente del dipendente.
	null,	--DATACESS			 ,	  PIC 9(08).Data giuridica di cessazione dal servizio. Formato: AAAAMMGG. Solo per i dipendenti cessati.
	null,	--CAUCESS            ,	  PIC X(02).Codice causale di cessazione dal servizio. Obbligatorio: Solo per i dipendenti cessati.
	null,	--IMMPARTTIME		 ,	  PIC X. Indica se il dipendente è stato immesso nell’Ente direttamente in part-time o 	meno.
			--						  Valori ammessi: 1 = immesso direttamente in part-time; 0 = non immesso in part-time.
			----Tabella contenente i dati relativi ai periodi di part-time. La tabella contiene al massimo 2 elementi. 
			----Nel caso di più periodi di part-time, devono essere comunicati gli ultimi 2 periodi. Ogni elemento è costituito dai sottocampi che seguono. 

			----	TAB-PART-TIME OCCURS 2
	null,	--TABPARTTIMETIPO   ,   PIC X.  Tipo di part-time  
			--						    -- Valori ammessi: O = part-time orizzontale; V = part-time verticale. 
			--							-- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	0,	--TABPARTTIMEDECORRENZA  , PIC 9(08). Data di inizio periodo di part-time Formato: AAAAMMGG. 
			--								   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	0,	--TABPARTTIMESCADENZA    , PIC 9(08).Data di fine periodo di part-time. Formato: AAAAMMGG. 
			--								   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	0,	--TABPARTTIMEPERCENTUALE , PIC 9(02). Percentuale di part-time nel periodo indicato.
			--								   --Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	1,	--TIPORAPPORTO			,  PIC X. Tipo di rapporto di lavoro del dipendente.
			--								   -- Valori ammessi: 0 = tempo indeterminato;
			--								   -- 1 = rapporto a termine.
			--								   -- Nel caso di ulteriore dettaglio sul rapporto a termine sono previsti i valori:
			--								   -- 2 = formazione lavoro
			--								   -- 3 = lavoro interinale
			--								   -- 4 = lavori socialmente utili
			--								   -- 5 = telelavoro
	replicate('',20),				--FILLER1			    , PIC X(20).
	null,		--FACOLTA			, PIC X(5).Facolta' del dipendente. Cfr. ELENCO CODICI. 

	--72172 Classe di SCIENZE UMANE	
	--75145 Classe di SCIENZE e TECNOLOGIE	
	--75173 Classe di SCIENZE BIOMEDICHE	
	--75198 ALTRE STRUTTURE	
	--75200 Istituto di SCIENZE UMANE e SOCIALI	
	--96001 Classe di SCIENZE UMANE	
	--96002 Classe di SCIENZE MAT. e NAT.	
	--96003 Classe di FISICA e Classe di MATEMATICA	
	--96004 Classe di SCIENZE SOCIALI 
	codedip,	--DIPIST			    , PIC X(5).Dipartimento, Istituto, Centro Comune o Struttura di Raccordo del dipendente. 
			--						  Se il dipendente non e' attribuibile a Dipartimento o Istituto, assegnare un codice dalla tabella ALTRE STRUTTURE. 
			--						  Cfr. ELENCO CODICI. 
			
	null,	--FACSUPPL				, PIC X(5).Facolta' di supplenza. Cfr. ELENCO CODICI. 
	codefunz,	--AREAFUNZ				, PIC X(1).Area funzionale del dipendente (solo per il personale Tecnico / Amministrativo). 
			--						  Cfr. ELENCO CODICI. 
	'N',	--ATTASSISTENZIALI		, PIC X(1).Indica se il dipendente viene impegnato in Attività di tipo Assistenziali convenzionate.
			--							   -- Valori ammessi: 
			--							   -- A = Presta Attività di tipo Assistenziale convenzionata;
			--							   -- N = NON presta Attività di tipo Assistenziale convenzionata.  
	replicate('',1)	--FILLER2				  PIC X(1).

 FROM #Anagrafiche 
 JOIN registry R ON #Anagrafiche.idreg = R.idreg
 --JOIN registrylegalstatus RLS ON #Anagrafiche.idreg = RLS.idreg AND (RLS.start <= @start) AND (RLS.stop IS NULL OR RLS.stop >= @stop)   
 --JOIN dalia_position DP ON DP.iddaliaposition = RLS.iddaliaposition 
 

DECLARE @numero_Record03 int
SET @numero_Record03 = (SELECT COUNT(*) FROM #Record3)
 
 --select * from #Record3

CREATE TABLE #RecordDiCoda
(
	--3.1.11 TRACCIATO DEL "RECORD DI CODA"
	TIPOREC  char(1), --PIC X.Indicatore tipo record.'9' = record di coda;
	NUMREC   int, --PIC 9(09). Numero dei record presenti sull'archivio, escluso quello di coda.
	FILLER   varchar(290)-- PIC X(290). 
)

INSERT INTO #RecordDiCoda
(   
	TIPOREC, --PIC X.Indicatore tipo record.'9' = record di coda;
	NUMREC, --PIC 9(09). Numero dei record presenti sull'archivio, escluso quello di coda.
	FILLER  -- PIC X(290). 
)
SELECT
'9',
 1 + 1 + @numero_Record03,   -- Un Record di testa + Un Record 02 + Numero di Record 03
replicate('',290)

-- Tabella di output
CREATE TABLE #tracciato(
    --ProgGen int identity(0,1),
    TipoRecord    varchar(2),        -- Tipo record (00-01-02)
    ProgrTipoRec  int identity(1,1),   
    stringa varchar(600) COLLATE SQL_Latin1_General_CP1_CI_AS
)

INSERT INTO #tracciato
(   
    TipoRecord,
    --ProgrTipoRec,   
    stringa
)
SELECT
    TIPOREC,
    --ProgrTipoRec,   
     [dbo].[GetStringFormatted_r](TIPOREC,1)			+	-- PIC X      Indicatore del tipo record. Valori ammessi: ‘1’ = record di testa.
	 [dbo].[GetStringFormatted_r](CODENTEFONTE,11)		+	-- varchar(11),    -- PIC X(11)  Codice fiscale dell'ente fonte (ente preposto all'invio dei dati).
	 [dbo].[GetStringFormatted_r](DENOMENTE,60)			+	-- varchar(60),    -- PIC X(60)  Denominazione dell'ente fonte.
	 [dbo].[GetStringFormatted_r](INDIRIZZO,30)			+	-- varchar(30),	-- PICX(30)   Indirizzo dell'ente fonte
	 [dbo].[GetStringFormatted_r](CAP,5)				+	-- varchar(05),	-- PIC X(05)  C.A.P. dell'ente fonte
	 [dbo].[GetStringFormatted_r](CODCITTA,4)			+	-- varchar(4),		-- X(04).	  PIC  Codice catastale del comune dell'ente fonte.
	 [dbo].[GetStringFormatted_r](PROVENTE,02)			+	-- varchar(02),	-- PIC X(02)  Sigla della provincia dell'ente fonte.
	 [dbo].[GetStringFormatted_r](PREFTELEFONO,5)		+   -- varchar(5),     -- PIC X(05)  Numero del prefisso telefonico dell'ente fonte.
	 [dbo].[GetStringFormatted_r](NUMTELEFONO,10)		+	-- varchar(10),	-- PIC X(10)  Numero di telefono dell'ente fonte.
	 [dbo].[GetStringFormatted_r](PREFFAX,5)			+   -- varchar(5),	    -- PIC X(05)  Numero del prefisso del fax dell'ente fonte.
	 [dbo].[GetStringFormatted_r](NUMFAX,10)			+	-- varchar(10),	-- PIC X(10)  Numero di fax dell'ente fonte.
	 [dbo].[GetStringFormatted_r](PERSONARIF,30)		+	-- varchar(30),    -- PIC X(30)  Persona responsabile dei dati inviati. 
	 [dbo].[GetStringFormatted_r](DESCRQUA,20)			+	-- varchar(20),    -- PIC X(20)  Descrizione della qualifica della persona di riferimento.
	 [dbo].[GetStringFormatted_r](TIPOCODIFICA,1)		+	-- char(1),       -- PIC X.     Indicatore del tipo di codifica utilizzato per la predisposizione del supporto magnetico.
															-- Valori ammessi: ‘E’ = codifica EBCDIC; ‘A’ = codifica ASCII
	 [dbo].[GetStringFormatted_r](FILLER,106)				-- varchar(106)   -- PIC X(106)
FROM #RecordTesta

 
INSERT INTO #tracciato
(   
    TipoRecord,
    --ProgrTipoRec,   
	stringa	
)
SELECT
    TIPOREC,
    --ProgrTipoRec,   
	[dbo].[GetStringFormatted_r](TIPOREC,1)			+		-- char(1),     -- PIC X.		Indicatore del tipo record. Valori ammessi: ‘2’ = record di istituzione/ente/sezione;
	[dbo].[GetStringFormatted_r](CODISTITENTE,11)	+	 	-- varchar(11), -- PIC X(11)   Codice fiscale dell'istituzione/ente cui si riferiscono i dati inviati.
	[dbo].[GetInt](CODUNIORG,10)					+	 	-- varchar(10), -- PIC 9(10)	Codice che individua la Struttura Organizzativa all'interno dell'istituzione/ente. 
													-- Se i dati di dettaglio riportati nella successiva sezione sono noti solo a livello 
															-- di istituzione/ente, tale campo non deve essere valorizzato.
	[dbo].[GetStringFormatted_r](DENOMENTE,60)		+       -- varchar(60), -- Denominazione della Struttura Organizzativa, se valorizzata, altrimenti Denominazione dell’istituzione/ente. 
	[dbo].[GetStringFormatted_r](INDIRIZZO,30)		+       -- varchar(30), -- Indirizzo della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](CAP,5)				+		-- varchar(5),  -- C.A.P. della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](CODCITTÀ,4)		+		-- varchar(4),	-- Codice catastale del comune della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](PROVENTE,2)		+       -- varchar(2),	-- Sigla della provincia della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](PREFTELEFONO,5)	+       -- varchar(5),	-- Numero del prefisso telefonico della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](NUMTELEFONO,10)	+       -- varchar(10), -- Numero di telefono della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente..
	[dbo].[GetStringFormatted_r](PREFFAX ,5)		+       -- varchar(5),	-- Numero del prefisso del fax della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](NUMFAX ,10)		+       -- varchar(10), -- Numero di fax della Struttura Organizzativa, se valorizzata, altrimenti dell’istituzione/ente.
	[dbo].[GetStringFormatted_r](YEAR(INIPERRIF),4) + [dbo].[Getint](MONTH(INIPERRIF),2) +       -- datetime,	-- Data di inizio del periodo cui si riferiscono i dati (formato: AAAAMM).
	[dbo].[GetStringFormatted_r](YEAR(FINPERRIF),4) + [dbo].[Getint](MONTH(FINPERRIF),2) +       -- datetime,	-- PIC 9(06).Data di fine del periodo cui si riferiscono i dati (formato: AAAAMM).
	[dbo].[GetStringFormatted_r](SEZIONE,1)			+       -- char(1),     -- PIC X.Sezione cui si riferiscono i dati. Valori ammessi: ‘G’ = anagrafico-giuridica;
	[dbo].[GetStringFormatted_r](FILLER	,134)		        -- varchar(134) -- PIC X(134).
FROM #Record2


INSERT INTO #tracciato
(   
    TipoRecord,
    --ProgrTipoRec,   
    stringa
)
SELECT
    TIPOREC,
    --ProgrTipoRec,   
	[dbo].[GetStringFormatted_r](TIPOREC,1)		   +   -- PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	[dbo].[GetStringFormatted_r](SEZIONE,1)		   +   -- PIC X.Il valore ammesso è ‘G’ (anagrafico-giuridica).
	[dbo].[GetStringFormatted_r](CODISTITENTE,11)  +   -- PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetInt](CODUNIORG,10)				   +   -- 9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(INIPERRIF),4) + [dbo].[Getint](MONTH(INIPERRIF),2)   +  -- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(FINPERRIF),4) + [dbo].[Getint](MONTH(FINPERRIF),2)   +  -- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](CODFISCDIP, 16)   +   -- X(16).Codice fiscale del dipendente.
	[dbo].[GetStringFormatted_r](CODCOMP,2)        +   -- X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	[dbo].[GetStringFormatted_r](CODSCOMP,2)       +   -- X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	[dbo].[GetStringFormatted_r](CODRUOLO,1)       +   -- PIC X. 
	[dbo].[GetStringFormatted_r](CODPROFILO,3)     +   -- PIC X(03).
	[dbo].[GetStringFormatted_r](CODPOSECON,2)     +   -- PIC X(02).
	[dbo].[GetStringFormatted_r](COGNOME,30)       +   -- PIC X(30). Cognome del dipendente.
	[dbo].[GetStringFormatted_r](NOME,30)          +   -- PIC X(30). Nome del dipendente.
	[dbo].[GetStringFormatted_r](SESSO,1)          +   -- PIC X.  Sesso del dipendente. Valori ammessi: M = maschio; F = femmina.
	[dbo].[GetStringFormatted_r](CONVERT(VARCHAR(8),DATANASC,112),8)  +   -- PIC	9(8).Data di nascita del dipendente. AAAAMMGG.
	[dbo].[GetStringFormatted_r](CATSP,2)		   +   -- PIC X(02). Codice dell''eventuale categoria speciale di appartenenza del dipendente.
	[dbo].[GetStringFormatted_r](STATOCIV,2)	   +   -- PIC X(02). Codice stato civile.
	[dbo].[GetInt](NUMFAM, 2)                      +   -- PIC 9(02).Numero di persone che costituiscono il nucleo familiare (escluso il dipendente).
	[dbo].[GetStringFormatted_r](CLASCONC, 4)      +   -- PIC X(04). Classe di concorso (solo per il personale della scuola).
	[dbo].[GetStringFormatted_r](INDIN,1)+	-- PIC X.Indicatore dello stato di servizio del dipendente presso l'istituzione/ente.
													   --spazio = appartenente all’ente di organico; 
													   -- ‘C’ = comandato da altri enti;
													   -- 'F’ = fuori ruolo da altri enti;
													   -- ‘D’ = distaccato da altri enti;
													   -- ‘S’ = supplente.
	[dbo].[GetStringFormatted_r](CODENTEAPP,11)    +   -- PIC X(11).Codice fiscale dell'ente di appartenenza del dipendente.
								 -- Coincide con l’istituzione/ente, 
								 -- ad esclusione dei dipendenti comandati da altri enti - ovvero, per cui IND-IN è diverso da spazio.
	[dbo].[GetStringFormatted_r](INDOUT,1)         +    -- PIC X.Indicatore dell’eventuale assegnazione del dipendente presso un ente diverso da quello di appartenenza.
														-- spazio = in servizio presso l’ente;
														-- ‘C’ = comandato presso altri enti;
														-- ‘F’ = fuori ruolo presso altri enti;
														-- ‘D’ = distaccato presso altri enti.
	[dbo].[GetStringFormatted_r](CODENTECOM,11)    +    -- PIC X(11).--Codice fiscale dell'ente presso cui il dipendente è comandato, fuori ruolo o distaccato.
					   -- Da valorizzare solo se IND-OUT è diverso da spazio.
	[dbo].[GetStringFormatted_r](PROVSERV, 2)      +    -- X(02). Sigla della provincia di servizio del dipendente.
	[dbo].[GetStringFormatted_r](NAZSERVEST, 4)    +    -- PIC X(04).Codice catastale della nazione della sede di servizio all'estero.
	[dbo].[GetInt](GGSERVEST,3)                    +	-- PIC 9(03). Numero giorni di servizio prestati all'estero nel periodo di riferimento.
	[dbo].[GetStringFormatted_r](ESTERO,1)+				-- PIC X. Indicatore dell’eventuale servizio alla data di fine periodo.
														-- 0 = in servizio in Italia alla data di fine periodo
														-- 1 = in servizio all’estero alla data di fine periodo.
	[dbo].[GetStringFormatted_r](CONVERT(VARCHAR(8),DATAASS,112) ,8)	   +  -- PIC 9(08).Data di assunzione del dipendente nella Pubblica Amministrazione. Formato: AAAAMMGG.
	[dbo].[GetStringFormatted_r](CONVERT(VARCHAR(8),DATAIMMENTE,112),8)    +  -- PIC 9(08). Data giuridica di immissione del dipendente nell'ente o amministrazione in cui è in organico. AAAAMMGG.
	[dbo].[GetStringFormatted_r](CONVERT(VARCHAR(8),DATAIMMQUA,112),8)     +  -- PIC 9(08). Data dell'ultima variazione di classe, scatto o qualifica COD-QUA
								 --(ad esclusione dei casi di modifica del regime di impegno e del passaggio da
								 --"Ricercatore non confermato" a "Ricercatore non confermato dopo un anno").
								 --(Sostituisce: Data dell'ultima variazione di inquadramento, classe, scatto o qualifica). Formato: AAAAMMGG.
	[dbo].[GetStringFormatted_r](CAUIMM,2)				+  -- X(02).Codice causale di immissione nell’ente.
	[dbo].[GetStringFormatted_r](CAUIMMQUALIFICA,2)		+  -- PIC X(02).Codice causale di immissione nella qualifica.
	[dbo].[GetStringFormatted_r](CODCOMPQUAPREC,2)		+  -- PIC X(02).Codice del comparto relativo al ruolo, profilo, posizione economica precedenti. 
	[dbo].[GetStringFormatted_r](CODSCOMPQUAPREC,2)		+  -- PIC X(02).Codice del contratto relativo al ruolo, profilo, posizione economica precedenti. 
	--[dbo].[GetStringFormatted_r](CODRUOLOPREC,1)		+  -- PIC X.Codice del ruolo precedente del dipendente. 
	--[dbo].[GetStringFormatted_r](CODPROFILOPREC,3)		+  -- PIC X(03).Codice del profilo precedente del dipendente. 
	--[dbo].[GetStringFormatted_r](CODPOSECONPREC,2)		+  -- PIC X(02). Codice posizione economica precedente del dipendente.
	
	[dbo].[GetInt](0,1)		+  -- PIC X.Codice del ruolo precedente del dipendente. 
	[dbo].[GetInt](0,3)		+  -- PIC X(03).Codice del profilo precedente del dipendente. 
	[dbo].[GetInt](0,2)		+  -- PIC X(02). Codice posizione economica precedente del dipendente.


	[dbo].[GetInt](0,8)	+	 -- PIC 9(08).Data giuridica di cessazione dal servizio. Formato: AAAAMMGG. Solo per i dipendenti cessati.
	[dbo].[GetStringFormatted_r](CAUCESS,2)				+  -- PIC X(02).Codice causale di cessazione dal servizio. Obbligatorio: Solo per i dipendenti cessati.
	[dbo].[GetStringFormatted_r](IMMPARTTIME,1)			+  -- PIC X. Indica se il dipendente è stato immesso nell’Ente direttamente in part-time o 	meno.
									--Valori ammessi: 1 = immesso direttamente in part-time; 0 = non immesso in part-time.
	--Tabella contenente i dati relativi ai periodi di part-time. La tabella contiene al massimo 2 elementi. 
	--Nel caso di più periodi di part-time, devono essere comunicati gli ultimi 2 periodi. Ogni elemento è costituito dai sottocampi che seguono. 

	--	TAB-PART-TIME OCCURS 2
	[dbo].[GetStringFormatted_r](TABPARTTIMETIPO,1)			+ -- PIC X.  Tipo di part-time  
							    -- Valori ammessi: O = part-time orizzontale; V = part-time verticale. 
								-- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetInt](0,8)	+ -- PIC 9(08). Data di inizio periodo di part-time Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetInt](0,8)	+	+ -- PIC 9(08).Data di fine periodo di part-time. Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetInt](TABPARTTIMEPERCENTUALE,2)				+ -- PIC 9(02). Percentuale di part-time nel periodo indicato.
									   --Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetStringFormatted_r](TABPARTTIMETIPO,1)			+ -- PIC X.  Tipo di part-time  
							    -- Valori ammessi: O = part-time orizzontale; V = part-time verticale. 
								-- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetInt](0,8)		+ -- PIC 9(08). Data di inizio periodo di part-time Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetInt](0,8)	+ -- PIC 9(08).Data di fine periodo di part-time. Formato: AAAAMMGG. 
									   -- Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetInt](TABPARTTIMEPERCENTUALE,2)				+ -- PIC 9(02). Percentuale di part-time nel periodo indicato.
									   --Solo per i dipendenti che effettuano il part-time o comunque lo hanno effettuato nel periodo di riferimento. 

	[dbo].[GetStringFormatted_r](TIPORAPPORTO,1)			+ -- PIC X. Tipo di rapporto di lavoro del dipendente.
									   -- Valori ammessi: 0 = tempo indeterminato;
									   -- 1 = rapporto a termine.
									   -- Nel caso di ulteriore dettaglio sul rapporto a termine sono previsti i valori:
									   -- 2 = formazione lavoro
									   -- 3 = lavoro interinale
									   -- 4 = lavori socialmente utili
									   -- 5 = telelavoro
	[dbo].[GetStringFormatted_r](FILLER1,20)				+ -- PIC X(20).
	[dbo].[GetStringFormatted_r](FACOLTA,5)					+ -- PIC X(5).Facolta' del dipendente. Cfr. ELENCO CODICI. 

	[dbo].[GetStringFormatted_r](DIPIST,5)					+ -- PIC X(5).Dipartimento, Istituto, Centro Comune o Struttura di Raccordo del dipendente. 
															  -- Se il dipendente non e' attribuibile a Dipartimento o Istituto, assegnare un codice dalla tabella ALTRE STRUTTURE. 
															  -- Cfr. ELENCO CODICI. 
	[dbo].[GetStringFormatted_r](FACSUPPL,5)				+ -- PIC X(5).Facolta' di supplenza. Cfr. ELENCO CODICI. 
	[dbo].[GetStringFormatted_r](AREAFUNZ,1)				+ -- PIC X(1).Area funzionale del dipendente (solo per il personale Tecnico / Amministrativo). 
							  -- Cfr. ELENCO CODICI. 
	[dbo].[GetStringFormatted_r](ATTASSISTENZIALI,1)		+ -- PIC X(1).Indica se il dipendente viene impegnato in Attività di tipo Assistenziali convenzionate.
															  -- Valori ammessi: 
															  -- A = Presta Attività di tipo Assistenziale convenzionata;
															  -- N = NON presta Attività di tipo Assistenziale convenzionata.  
	[dbo].[GetStringFormatted_r](FILLER2,1) 				  -- PIC X(1).
FROM #Record3


INSERT INTO #tracciato
(   
    TipoRecord,
    stringa
)
SELECT
    TIPOREC, 
	[dbo].[GetStringFormatted_r](TIPOREC,1)			+ --PIC X.Indicatore tipo record.'9' = record di coda;
	[dbo].[GetInt](NUMREC,9)						+ --PIC 9(09). Numero dei record presenti sull'archivio, escluso quello di coda.
	[dbo].[GetStringFormatted_r](FILLER, 290)		  --PIC X(290). 
FROM #RecordDiCoda

 
 
SELECT
    stringa as out_str
FROM #tracciato
ORDER BY  TipoRecord,ProgrTipoRec

END
GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

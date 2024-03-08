
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_dalia_dati_economici]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_interscambio_dalia_dati_economici
GO
 
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
 
CREATE PROCEDURE exp_interscambio_dalia_dati_economici
(
    @ayear int,		  -- esercizio di riferimento
    @start datetime,  -- data inizio
    @stop datetime	  -- data fine
)

AS
-- Esportazione di dati economici dei dipendenti su piattaforma Dalia
--exec exp_interscambio_dalia_dati_economici 2019, {ts '2019-01-01 01:00:03'},  {ts '2019-12-31 01:02:03'} 
--Le anagrafiche interessate da questa procedura dovranno rispettare congiuntamente le seguenti condizioni:
--1)    L’anagrafica di Easy sarà stata associata a una prestazione mappata per l'estrazione Dalia
--2)    La prestazione sarà stata liquidata nel periodo di riferimento

/*
201901A015+000546.54+000000.00+000000.00
201902A015+000546.54+000000.00+000000.00
201904A015+000546.54+000000.00+000000.00
201905A015+001093.08+000000.00+000000.00
201906A015+000546.54+000000.00+000000.00
201907A015+000546.54+000000.00+000000.00
201908A015+000546.54+000000.00+000000.00
201909A015+000546.54+000000.00+000000.00
201910A015+000546.54+000000.00+000000.00
201911A015+000546.54+000000.00+000000.00
201912A015+000546.54+000000.00+000000.00

Il tipo di campo può essere:
•numerico: i dati devono essere allineati a destra, riempiendo di zeri le cifre non significative; relativamente ai campi contenenti importi, deve essere fornito il segno nel primo carattere a sinistra del campo; 
•alfanumerico: i dati devono essere allineati a sinistra, con riempimento a spazi dei caratteri non significativi; relativamente al campo "codice fiscale del dipendente", lungo 16 caratteri, se il codice fiscale è di 11 cifre va allineato a sinistra e vanno riempiti a spazi i rimanenti 5 caratteri.
I valori di inizializzazione dei campi sono:
•zero, per i campi numerici;
•spazio, per i campi alfanumerici.
*/
/*
setuser 'amministrazione'
exec exp_interscambio_dalia_dati_economici 2019, {ts '2019-01-01 01:02:03'},  {ts '2019-12-31 01:02:03'} 
select * from registry where cf='BSCLRT83P65F499T'
*/
BEGIN
 
DECLARE @codeclassvocispesa varchar(20)
SET @codeclassvocispesa = 'VOCISPESA'  
 
DECLARE @idsortingdalia int
SELECT  @idsortingdalia = idsorkind FROM sortingkind WHERE codesorkind = @codeclassvocispesa

CREATE TABLE #error (message varchar(400))
 
CREATE TABLE #Ritenute
(
    idreg int,
	idexp int,
	registry varchar(200),		 
	start datetime, 
	stop datetime,
	taxcode int,  
	taxref varchar(20), 
	description varchar(200), 
	taxkind int, 
	tiporitenuta varchar(20),
	exemptionquota decimal(19,2), 
	abatements decimal(19,2), 
	taxablegross  decimal(19,2),  
	taxablenet decimal(19,2),  
	employtax decimal(19,2),  
	admintax decimal(19,2) ,
	insuranceagencycode varchar(10),
	transmissiondate datetime,
	codedaliaposition_contract varchar(10) 
)



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
	noperation int,
	classdalia varchar(20),
	codedaliaposition_contract varchar(10) 
)

------------------------------------------------------------------------------------------------------ 
--------------------------------------- INIZIO ESTRAZIONE DATI COMPENSI DALIA ------------------------
------------------------------------------------------------------------------------------------------ 

--1) COCOCO --  

INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	idcon,
	ycon,
	ncon,
	classdalia,
	amount, 
	codedaliaposition_contract,
	transmissiondate)
SELECT   DISTINCT
	parasubcontract.idser, 
	parasubcontract.idreg,
	expenselast.idexp,
	#service.module,
	parasubcontract.idcon,
	parasubcontract.ycon,
	parasubcontract.ncon,
	SOR.sortcode,
	expenseyear.amount,
	dalia_position.codedaliaposition,
	paymenttransmission.transmissiondate
FROM  payroll JOIN parasubcontract on payroll.idcon = parasubcontract.idcon
JOIN #service 
	ON parasubcontract.idser = #service.idser
JOIN parasubcontractsorting PS
	ON PS.idcon = parasubcontract.idcon
JOIN sorting SOR
	ON PS.idsor = SOR.idsor
    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position
	ON	parasubcontract.iddaliaposition = dalia_position.iddaliaposition
JOIN expensepayroll ON payroll.idpayroll	= expensepayroll.idpayroll
		JOIN expenselink    ON expenselink.idparent = expensepayroll.idexp
		JOIN expenselast    ON expenselast.idexp	= expenselink.idchild
		JOIN expenseyear    ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
		JOIN payment        ON payment.kpay         = expenselast.kpay
		JOIN paymenttransmission  ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
WHERE  paymenttransmission.ypaymenttransmission = @ayear 
AND    paymenttransmission.transmissiondate BETWEEN @start AND @stop 
AND    payroll.fiscalyear = @ayear

 
 
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
	amount,
	classdalia,
	codedaliaposition_contract)
SELECT  
	wageaddition.idser, 
	wageaddition.idreg,
	expenseyear.idexp,
	#service.module,
	wageaddition.ycon,
	wageaddition.ncon,
	paymenttransmission.transmissiondate,
	expenseyear.amount,
	SOR.sortcode,
	dalia_position.codedaliaposition
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
JOIN wageadditionsorting WGS
	ON WGS.ycon = wageaddition.ycon
	AND WGS.ncon = wageaddition.ncon
JOIN sorting SOR
	ON WGS.idsor = SOR.idsor
    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position
	ON	wageaddition.iddaliaposition = dalia_position.iddaliaposition
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND   paymenttransmission.transmissiondate BETWEEN @start AND @stop 

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
	amount,
	classdalia,
	codedaliaposition_contract)
SELECT  
	itineration.idser, 
	itineration.idreg,
	expenseyear.idexp,
	#service.module,
	itineration.iditineration,
	itineration.yitineration,
	itineration.nitineration,
	paymenttransmission.transmissiondate,
	expenseyear.amount,
	SOR.sortcode,
	dalia_position.codedaliaposition
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
JOIN itinerationsorting ITS
	 ON ITS.iditineration = itineration.iditineration
JOIN sorting SOR
	ON ITS.idsor = SOR.idsor
    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position
	ON	itineration.iddaliaposition = dalia_position.iddaliaposition
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND paymenttransmission.transmissiondate BETWEEN @start AND @stop 

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
	noperation,
	classdalia,
	codedaliaposition_contract)
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
	p.noperation,
	SOR.sortcode,
	dalia_position.codedaliaposition
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
	JOIN itinerationsorting ITS
		 ON ITS.iditineration = itin.iditineration
	JOIN sorting SOR
		ON ITS.idsor = SOR.idsor
		AND SOR.idsorkind = @idsortingdalia
	LEFT OUTER JOIN dalia_position
	ON	itin.iddaliaposition = dalia_position.iddaliaposition
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
	amount,
	classdalia,
	codedaliaposition_contract)
SELECT  
	casualcontract.idser, 
	casualcontract.idreg,
	expenseyear.idexp,
	#service.module,
	casualcontract.ycon,
	casualcontract.ncon,
	paymenttransmission.transmissiondate,
	expenseyear.amount,
	SOR.sortcode,
	dalia_position.codedaliaposition
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
JOIN casualcontractsorting CCS
	ON CCS.ycon = casualcontract.ycon
	AND CCS.ncon = casualcontract.ncon
JOIN sorting SOR
	ON CCS.idsor = SOR.idsor
    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position
	ON	casualcontract.iddaliaposition = dalia_position.iddaliaposition
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND paymenttransmission.transmissiondate BETWEEN @start AND @stop 

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
	noperation,
	classdalia,
	codedaliaposition_contract)
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
	p.noperation,
	SOR.sortcode,
	dalia_position.codedaliaposition
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
JOIN casualcontractsorting CCS
	ON CCS.ycon = cas.ycon
	AND CCS.ncon = cas.ncon
JOIN sorting SOR
	ON CCS.idsor = SOR.idsor
    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position
	ON	cas.iddaliaposition = dalia_position.iddaliaposition
WHERE p.yoperation = @ayear


INSERT INTO #contratti
	(idser, 
	idreg,
	idexp,
	module,
	ycon,
	ncon,
	transmissiondate,
	amount,
	classdalia,
	codedaliaposition_contract)
SELECT  
	profservice.idser, 
	profservice.idreg,
	expenseyear.idexp,
	#service.module,
	profservice.ycon,
	profservice.ncon,
	paymenttransmission.transmissiondate,
	expenseyear.amount,
	SOR.sortcode,
	dalia_position.codedaliaposition
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
join expenseinvoice				on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
JOIN expenselast				ON expenselast.idexp    = expenseinvoice.idexp
JOIN expenseyear				ON expenselast.idexp    = expenseyear.idexp AND expenseyear.ayear = @ayear
JOIN payment					ON payment.kpay         = expenselast.kpay
JOIN paymenttransmission		ON payment.kpaymenttransmission  = paymenttransmission.kpaymenttransmission
JOIN profservicesorting PSS		ON PSS.ycon = profservice.ycon	AND PSS.ncon = profservice.ncon
JOIN sorting SOR				ON PSS.idsor = SOR.idsor	    AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	profservice.iddaliaposition = dalia_position.iddaliaposition
WHERE paymenttransmission.ypaymenttransmission = @ayear
AND paymenttransmission.transmissiondate BETWEEN @start AND @stop 
 
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
	noperation,
	classdalia,
	codedaliaposition_contract)
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
	p.noperation ,
	SOR.sortcode,
	dalia_position.codedaliaposition
FROM pettycashoperationprofservice mov
JOIN profservice prof		ON  prof.ycon = mov.ycon   AND  prof.ncon = mov.ncon
JOIN #service				ON prof.idser = #service.idser
JOIN pettycashoperation p	ON mov.idpettycash = p.idpettycash	AND mov.yoperation = p.yoperation	AND mov.noperation = p.noperation
LEFT OUTER JOIN pettycashoperation rest	ON rest.idpettycash = p.idpettycash	AND rest.yoperation = p.yrestore	AND rest.noperation = p.nrestore
JOIN profservicesorting PSS	ON PSS.ycon = prof.ycon	AND PSS.ncon = prof.ncon
JOIN sorting SOR			ON PSS.idsor = SOR.idsor   AND SOR.idsorkind = @idsortingdalia
LEFT OUTER JOIN dalia_position	ON	prof.iddaliaposition = dalia_position.iddaliaposition
WHERE p.yoperation = @ayear

------------------------------------------------------------------------------------------------------ 
--------------------------------------- INIZIO ESTRAZIONE RITENUTE COMPENSI DALIA -------------------- 
------------------------------------------------------------------------------------------------------ 
INSERT INTO #Ritenute
(
    idreg,
	idexp,
	registry,		 
	start, 
	stop,
	taxcode,  
	taxref, 
	description, 
	taxkind, 
	tiporitenuta,
	exemptionquota, 
	abatements, 
	taxablegross,  
	taxablenet,  
	employtax,  
	admintax,
	insuranceagencycode, -- dalia
	transmissiondate,
	codedaliaposition_contract 
)
SELECT ET.idreg, ET.idexp ,ET.registry,  ET.start, ET.stop,
 ET.taxcode,  ET.taxref, ET.description, ET.taxkind, 
 CASE ET.taxkind
	WHEN 1 THEN 'fiscale'
	WHEN 2 THEN 'assistenzale'
	WHEN 3 THEN 'previdenziale'
	WHEN 4 THEN 'assicurativa'
	WHEN 5 THEN 'arretrati'
	ELSE 'altro'
 END AS tiporitenuta,
 ET.exemptionquota, ET.abatements, 
 ET.taxablegross, 
 ET.taxablenet, 
 ET.employtax, ET.admintax,
 T.insuranceagencycode, C.transmissiondate,
 C.codedaliaposition_contract 
 FROM  expensetaxofficialview ET  
  JOIN #Contratti C  
	ON C.idexp = ET.idexp AND  C.idreg = ET.idreg
  LEFT OUTER JOIN tax T  
	ON ET.taxcode = T.taxcode AND (ET.taxkind = 1 OR T.insuranceagencycode IS NOT NULL) 

 
 --select * from #Contratti
 --select * from #Ritenute where idreg = 209
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
--SELECT DISTINCT idreg FROM #Anagrafiche
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
    registryaddress.idreg,
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
LEFT OUTER JOIN geo_city	   ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country	    ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation	    ON geo_nation.idnation = registryaddress.idnation
JOIN  address				    ON address.idaddress = registryaddress.idaddresskind
WHERE
ISNULL(registryaddress.active,'S') <>'N'
	AND registryaddress.start =
	(SELECT MAX(cdi.start)
     FROM registryaddress cdi
     WHERE cdi.idaddresskind = registryaddress.idaddresskind
	 AND cdi.active <>'N' 
	 AND ((cdi.start IS NULL) OR (cdi.start <= @start))
	 --AND ((cdi.stop IS NULL) OR (cdi.stop >= @stop))		task 9373
	 AND cdi.idreg = registryaddress.idreg)
     AND idreg IN (SELECT DISTINCT idreg FROM #Contratti)

 --select * from #address


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
    (SELECT * FROM #Contratti WHERE idreg NOT IN
        (SELECT DISTINCT idreg FROM #address ind)))
BEGIN
    INSERT INTO #error (message)
    (SELECT 'L''anagrafica ' + registry.title +
    + ' non ha un indirizzo valido associato '
    FROM #Contratti
    join registry ON #Contratti.idreg = registry.idreg
    WHERE #Contratti.idreg NOT IN
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
		@address = SUBSTRING(license.address1, 1, 35),
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

--SELECT * FROM #CONTRATTI
-- In #tot_contratti totalizzo i dati dei contratti su idreg, codice qualifica dalia (potendo essere diversi per ogni compenso), 
-- voce competenza economica (classificazione voci spesa dalia) e anche mensilità di competenza
-- il codice qualifica dalia lo prendo o dal compenso oppure dall'anagrafica se manca nel compenso
CREATE TABLE #tot_contratti
(idreg int , amount decimal(19,2), pettycashamount decimal(19,2), classdalia varchar(20), mese int, codedaliaposition varchar(10))
INSERT INTO #tot_contratti 
(idreg, amount, pettycashamount, classdalia, mese, codedaliaposition)
SELECT idreg, sum(amount), sum(pettycashamount), classdalia, month(transmissiondate),  codedaliaposition_contract 
FROM #contratti
WHERE transmissiondate is not null
GROUP BY idreg, classdalia, month(transmissiondate),  codedaliaposition_contract 
having isnull(sum(amount),0)<>0  OR isnull(sum(pettycashamount),0)<>0


-------------------------------------------------------------------------------------------------------------------------
-- In #tot_ritenute totalizzo i dati delle ritenute applicate ai contratti sui campi idreg, codice qualifica dalia  ----- 
-- (potendo essere diversi per ogni compenso), codice ente previdenziale (valorizzato su alcune ritenute non fiscali) ---
-- e anche mensilità di competenza. Il codice qualifica dalia (codeposition) è stato preso dal compenso -----------------
------------------ oppure lo prendo dall'anagrafica se manca nel compenso -----------------------------------------------
-------------------------------------------------------------------------------------------------------------------------

CREATE TABLE #tot_ritenute
(idreg int, taxablenet decimal(19,2), 
 employtax decimal(19,2), admintax decimal(19,2), 
 insuranceagencycode varchar(20), mese int, tiporitenuta varchar(20), codedaliaposition varchar(10) )

INSERT INTO #tot_ritenute
(idreg, taxablenet, employtax,admintax,insuranceagencycode, mese,tiporitenuta, codedaliaposition )
SELECT idreg, sum(taxablenet),sum(employtax),sum(admintax), 
	   insuranceagencycode, month(transmissiondate) , tiporitenuta, codedaliaposition_contract
FROM #Ritenute 
GROUP BY idreg, insuranceagencycode, month(transmissiondate) , tiporitenuta,  codedaliaposition_contract 
having sum(employtax) <> 0 or sum(admintax) <> 0

 --SELECT '#tot_ritenute',* FROM #tot_ritenute  WHERE IDREG = 256
 -- SELECT 'SUM #tot_ritenute',SUM(EMPLOYTAX) FROM #tot_ritenute  WHERE IDREG = 256 AND TIPORITENUTA = 'fiscale'
 --SELECT '#tot_contratti',* FROM #tot_contratti  WHERE IDREG =    256


---------------------------------------------------------------------------------------------------------------------------------
-- In #tot_anagrafiche totalizzo i dati di compensi e relative ritenute sui seguenti campi : idreg, codeposition ----------------
-- perchè per la stessa anagrafica potremmo avere anche qualifiche DALIA diverse e devo ripartire i dati (imponibili, ritenute) -
---------------------------------- anche in base alle differenti qualifiche -----------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE #tot_anagrafiche
(idreg int, codedaliaposition varchar(10), 
 stringacompensi varchar(2000), 
 stringaritenutefiscali varchar(2000), 
 stringaritenutenonfiscali  varchar(2000),
 stringacompensi_2_tranche varchar(2000), --per eventuale primo record aggiuntivo se count_compensi > 25
 stringacompensi_3_tranche varchar(2000), --per eventuale secondo record aggiuntivo se count_compensi > 50
 stringaritenutefiscali_tranche_successive varchar(2000), -- per tutti gli eventuali i record aggiuntivi, valorizzato con tutti zeri
 stringaritenutenonfiscali_2_tranche varchar(2000),  --per eventuale secondo record aggiuntivo se count_ritenute_non_fiscali > 15
 stringaritenutenonfiscali_3_tranche varchar(2000), --per eventuale secondo record aggiuntivo se count_ritenute_non_fiscali > 30
 record_aggiuntivi int
)

--- leggo le coppie distinte (anagrafica, codedaliaposition) in #anagrafiche_ruolo_dalia
 CREATE TABLE #anagrafiche_ruolo_dalia
(idreg int, codedaliaposition varchar(10), count_compensi int, count_ritenute_non_fiscali int, record_aggiuntivi int)
INSERT INTO #anagrafiche_ruolo_dalia (idreg, codedaliaposition,record_aggiuntivi)
SELECT DISTINCT #tot_contratti.idreg, #tot_contratti.codedaliaposition, 0 FROM
#tot_contratti WHERE #tot_contratti.codedaliaposition IS NOT NULL

--------------------------------------------------------------------------------------------------------------------------------------
 -- Valorizzo i contatori dei compensi e delle ritenute non previdenziali che ho ottenuto per ogni coppia (idreg, codedaliaposition) -
 -- mi servirà dopo per effettuare il riempimento delle relative stringhe nella scrittura nel record ---------------------------------
 -- con opportune sequenze di caratteri fino al raggiungimento -----------------------------------------------------------------------
 -- del numero massimo di occorrenze previste dal tracciato (lunghezza fissa) ovvero 25 per la stringa compensi ----------------------
 -- e 15 per la stringa ritenute non previdenziali -----------------------------------------------------------------------------------
 -------------------------------------------------------------------------------------------------------------------------------------

 UPDATE #anagrafiche_ruolo_dalia  set count_compensi = (SELECT count(*) from #tot_contratti
 where  #tot_contratti.idreg =#anagrafiche_ruolo_dalia.idreg  and  
        #anagrafiche_ruolo_dalia.codedaliaposition = #tot_contratti.codedaliaposition)

 UPDATE #anagrafiche_ruolo_dalia  set count_ritenute_non_fiscali = (SELECT count(*) from #tot_ritenute
 where  #tot_ritenute.idreg =#anagrafiche_ruolo_dalia.idreg  and  
        #anagrafiche_ruolo_dalia.codedaliaposition = #tot_ritenute.codedaliaposition and 
		#tot_ritenute.tiporitenuta <> 'fiscale')

 -- sarà necessario aggiungere un record aggiuntivo per l'anagrafica e il ruolo dalia secondo i limiti previsti dal tracciato
 UPDATE #anagrafiche_ruolo_dalia  set record_aggiuntivi = 1  WHERE count_compensi > 25 OR count_ritenute_non_fiscali > 15
  -- sarà necessario aggiungere due record aggiuntivi per l'anagrafica e il ruolo dalia secondo i limiti previsti dal tracciato
 UPDATE #anagrafiche_ruolo_dalia  set record_aggiuntivi = 2  WHERE count_compensi > 50 OR count_ritenute_non_fiscali > 30

---------------------------------------------------------------------------------------------------------------------------------
---------- VALORIZZO LE STRINGHE COMPENSI, RITENUTE FISCALI E RITENUTE NON FISCALI VUOTE (IMPORTI TUTTI A ZERO) ----------------- 
---------------------------- SECONDO LA FORMATTAZIONE PREVISTA DAL TRACCIATO A LUNGHEZZA FISSA ----------------------------------
---------------------------------------------------------------------------------------------------------------------------------

DECLARE @stringa_ritenute_fiscali_vuota varchar(40)
SET @stringa_ritenute_fiscali_vuota = 		
			'+' +  [dbo].GetDecimal_19_2(0,9) +
			'+' +  [dbo].GetDecimal_19_2(0,9) +
			'+' +  [dbo].GetDecimal_19_2(0,9)

DECLARE @stringa_compensi_vuota varchar(1000) ---40 * 25
SET @stringa_compensi_vuota =   REPLICATE(
		 '          ' +	'+' +  [dbo].GetDecimal_19_2(0,9) + '+' +  [dbo].GetDecimal_19_2(0,9) +	'+' + [dbo].GetDecimal_19_2(0,9) , 25)
--select REPLICATE(	 '          ' +	'+' +  [dbo].GetDecimal_19_2(0,9) + '+' +  [dbo].GetDecimal_19_2(0,9) +	'+' + [dbo].GetDecimal_19_2(0,9) , 25)
DECLARE @stringa_ritenute_non_fiscali_vuota varchar(585) -- 39 * 15
SET 	@stringa_ritenute_non_fiscali_vuota = REPLACE (REPLICATE('*', 15),'*', 
							[dbo].[GetStringFormatted_r] ('',9) +
							'+' +  [dbo].GetDecimal_19_2(0,9) + 
							'+' +  [dbo].GetDecimal_19_2(0,9) +	
							'+' + [dbo].GetDecimal_19_2(0,9))


  
---------------------------------------------------------------------------------------------------------------------------------
-- Valorizzo la stringa dei compensi (voci economiche) effettuati per la coppia (idreg, codepositiondalia)-----------------------
-- è la concatenazione delle righe una tabella i cui valori sono ----------------------------------------------------------------
-- distinti per i vari mesi del periodo di riferimento (mensilità di competenza) ------------------------------------------------
-- e per tipologia di compenso (classificazione dalia) --------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------
INSERT INTO #tot_anagrafiche  (idreg, codedaliaposition,stringacompensi,record_aggiuntivi)
SELECT DISTINCT  #anagrafiche_ruolo_dalia.idreg, #anagrafiche_ruolo_dalia.codedaliaposition,
(SELECT CONVERT(VARCHAR(4), @ayear) + [dbo].GetInt(isnull(mese,0),2) +  [dbo].[GetStringFormatted_r](isnull(classdalia,'????'),4) +
	CASE 
		WHEN (ISNULL(amount,0) + ISNULL(pettycashamount,0)  >= 0)  
			THEN '+' +  [dbo].GetDecimal_19_2(ISNULL(amount,0) + ISNULL(pettycashamount,0),9) 
			ELSE '-'+  [dbo].GetDecimal_19_2(ISNULL(amount,0) + ISNULL(pettycashamount,0),9) 		
	END +
	+ 
	'+' +  [dbo].GetDecimal_19_2(0,9) 
	+ 
	'+' +  [dbo].GetDecimal_19_2(0,9)  AS [text()]

FROM #tot_contratti T1 
WHERE T1.idreg =  #anagrafiche_ruolo_dalia.idreg AND   T1.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition
FOR XML PATH ('')
),
#anagrafiche_ruolo_dalia.record_aggiuntivi
FROM #anagrafiche_ruolo_dalia  


--select * from #tot_anagrafiche where idreg=256

-- valorizzo la stringa delle ritenute fiscali ( IRPEF) che a differenza delle altre ritenute 
-- non è una tabella con valori distinti e  un massimo numero di occorrenze ma una stringa con i soli totali per il periodo considerato
UPDATE #tot_anagrafiche  SET stringaritenutefiscali = 
(SELECT 
	
	CASE 
		WHEN (isnull(sum(isnull(T1.employtax,0) + isnull(T1.admintax,0)),0)  >= 0)  THEN '+' +  [dbo].GetDecimal_19_2(isnull(sum(isnull(T1.employtax,0) + isnull(T1.admintax,0)),0) ,9) 	
		ELSE  '-' +  [dbo].GetDecimal_19_2(-isnull(sum(isnull(T1.employtax,0) + isnull(T1.admintax,0)),0) ,9) 	
	END 
	+
    '+' +  [dbo].GetDecimal_19_2(0,9) +
    '+' +  [dbo].GetDecimal_19_2(0,9) 
	   AS [text()]

FROM #tot_ritenute T1 
WHERE  T1.idreg =  #tot_anagrafiche.idreg AND   T1.codedaliaposition =  #tot_anagrafiche.codedaliaposition
AND   T1.tiporitenuta = 'fiscale'
FOR XML PATH (''))

-- Valorizzo la stringa delle ritenute previdenziali e assistenziali che a differenza delle   ritenute fiscali
--  è la concatenazione delle righe una tabella con valori distinti per ritenuta e  un massimo numero di occorrenze (15).  
UPDATE #tot_anagrafiche  SET stringaritenutenonfiscali  = 
 (SELECT 
	CONVERT(VARCHAR(4), @ayear) + [dbo].GetInt(isnull(T1.mese,0),2) + [dbo].[GetStringFormatted_r](T1.insuranceagencycode,3) +
	+ 
	CASE 
		WHEN (isnull(T1.taxablenet,0) >= 0)  THEN '+' +  [dbo].GetDecimal_19_2(isnull(T1.taxablenet,0),9) 
		ELSE '-'+ [dbo].GetDecimal_19_2(-T1.taxablenet,9) 		
	END
	+ 
	CASE 
		WHEN (isnull(T1.employtax,0) >= 0)  THEN '+' +  [dbo].GetDecimal_19_2(isnull(T1.employtax,0),9) 
		ELSE '-'+ [dbo].GetDecimal_19_2(-T1.employtax,9) 		
	END 
	+
	CASE 
		WHEN (isnull(T1.admintax,0) >= 0)  THEN '+' +  [dbo].GetDecimal_19_2(isnull(T1.admintax,0),9) 
		ELSE '-'+ [dbo].GetDecimal_19_2(-T1.admintax,9) 		
	END   AS [text()]
	
FROM #tot_ritenute T1 
WHERE  T1.idreg =  #tot_anagrafiche.idreg AND   T1.codedaliaposition =  #tot_anagrafiche.codedaliaposition
AND   T1.tiporitenuta <> 'fiscale'
FOR XML PATH (''))

--SELECT * FROM #tot_ritenute WHERE tiporitenuta <> 'fiscale'

---------------------------------------------------------------------------------------------------------------------------
-- SE il numero massimo stabilito dal tracciato per i il record 3 per i compensi (25) -------------------------------------
-- e per le ritenute previdenziali (15) è stato superat siamo costretti a SCINDERE la stringa compensi --------------------
-- (o la stringa ritenute previdenziali) in più tranches con la trasmissione  ---------------------------------------------
-- finalizzate alla trasmissione di almeno un record aggiuntivo per quell'anagrafica -------------------------------------- 
---------------------------------------------------------------------------------------------------------------------------

 UPDATE #tot_anagrafiche SET stringacompensi_2_tranche = 
							SUBSTRING(ISNULL(stringacompensi,'') , (40 * 25) + 1 ,  (40 * 25) )  
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_compensi > 25
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

 UPDATE #tot_anagrafiche SET stringacompensi_3_tranche = 
							SUBSTRING(ISNULL(stringacompensi,'') , 2* (40 * 25) + 1 ,  3*(40 * 25)  )  
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_compensi > 50
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

 UPDATE #tot_anagrafiche SET stringacompensi = 
							SUBSTRING(ISNULL(stringacompensi,'') , 1, 40 * 25 )  
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_compensi > 25
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition




 UPDATE #tot_anagrafiche SET stringaritenutenonfiscali_2_tranche = 
							SUBSTRING(ISNULL(stringaritenutenonfiscali ,'') , (39 * 15) + 1 ,  (39 * 15) )  
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali > 15 
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition


 UPDATE #tot_anagrafiche SET stringaritenutenonfiscali_3_tranche = 
							SUBSTRING(ISNULL(stringaritenutenonfiscali ,'') , 2* (39 * 15) + 1 ,  3*(39 * 15) )  
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali > 30
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

 UPDATE #tot_anagrafiche SET stringaritenutenonfiscali  = 
							SUBSTRING(ISNULL(stringaritenutenonfiscali ,'') , 1, 39 * 15 )  
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali > 15
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

------------------------------------------------------------------------------------------------------
-- Effettuo il riempimento di stringacompensi e stringaritenutenonfiscali ----------------------------
-- (prima ed eventualmente seconda tranche ed eventualmente terza tranche) ---------------------------
-- con le sequenze di caratteri indicate nel tracciato -----------------------------------------------
-- fino al raggiungimento della lunghezza fissa prevista per questi due campi del record -------------
------------------------------------------------------------------------------------------------------

UPDATE #tot_anagrafiche SET stringacompensi = 
							ISNULL(stringacompensi,'') +
							REPLICATE(
								[dbo].[GetStringFormatted_r] ('',10) +	'+' +  [dbo].GetDecimal_19_2(0,9) + '+' +  [dbo].GetDecimal_19_2(0,9) +	'+' + [dbo].GetDecimal_19_2(0,9),
								25 - count_compensi)
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg  and #anagrafiche_ruolo_dalia.count_compensi <= 25
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition


UPDATE #tot_anagrafiche SET stringaritenutenonfiscali  = 
							ISNULL(stringaritenutenonfiscali ,'') +
							REPLACE (REPLICATE('*',15 - count_ritenute_non_fiscali),'*', 
							[dbo].[GetStringFormatted_r] ('',9) +
							'+' +  [dbo].GetDecimal_19_2(0,9) + 
							'+' +  [dbo].GetDecimal_19_2(0,9) +	
							'+' + [dbo].GetDecimal_19_2(0,9))
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali <= 15
AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

UPDATE #tot_anagrafiche SET stringacompensi_2_tranche = 
							ISNULL(stringacompensi_2_tranche,'') +
							REPLACE (REPLICATE('*', 25 - (count_compensi  % 25)),'*', 
								[dbo].[GetStringFormatted_r] ('',10) +'+' +  [dbo].GetDecimal_19_2(0,9) + '+' +  [dbo].GetDecimal_19_2(0,9) +	'+' + [dbo].GetDecimal_19_2(0,9))
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg  and #anagrafiche_ruolo_dalia.count_compensi > 25 and #anagrafiche_ruolo_dalia.count_compensi <50
	--and count_compensi  % 25 >0
	AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

UPDATE #tot_anagrafiche SET stringacompensi_3_tranche = 
							ISNULL(stringacompensi_3_tranche,'') +
							REPLACE (REPLICATE('*', 25 - (count_compensi  % 25)),'*', [dbo].[GetStringFormatted_r] ('',10) +	
							'+' +  [dbo].GetDecimal_19_2(0,9) + '+' +  [dbo].GetDecimal_19_2(0,9) +	'+' + [dbo].GetDecimal_19_2(0,9))
FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg  and #anagrafiche_ruolo_dalia.count_compensi > 50
	--and count_compensi  % 50 >0
	AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

UPDATE #tot_anagrafiche SET stringaritenutenonfiscali_2_tranche = 
							ISNULL(stringaritenutenonfiscali_2_tranche,'') +
							REPLICATE(
							[dbo].[GetStringFormatted_r] ('',9) +
							'+' +  [dbo].GetDecimal_19_2(0,9) + 
							'+' +  [dbo].GetDecimal_19_2(0,9) +	
							'+' + [dbo].GetDecimal_19_2(0,9),15 - (count_ritenute_non_fiscali%15))

FROM #anagrafiche_ruolo_dalia   
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali > 15  and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali < 30
	--and  #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali%15 >0
	AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

UPDATE #tot_anagrafiche SET stringaritenutenonfiscali_3_tranche = 
							ISNULL(stringaritenutenonfiscali_3_tranche,'') +
							REPLICATE(
							[dbo].[GetStringFormatted_r] ('',9) +
							'+' +  [dbo].GetDecimal_19_2(0,9) + 
							'+' +  [dbo].GetDecimal_19_2(0,9) +	
							'+' + [dbo].GetDecimal_19_2(0,9),15 - (count_ritenute_non_fiscali%15))

FROM #anagrafiche_ruolo_dalia  
WHERE  #tot_anagrafiche.idreg =  #anagrafiche_ruolo_dalia.idreg and #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali > 30
	--and  #anagrafiche_ruolo_dalia.count_ritenute_non_fiscali%15 >0
	AND   #tot_anagrafiche.codedaliaposition =  #anagrafiche_ruolo_dalia.codedaliaposition

------------------------------------------------------------------------------------------------------
-- Effettuo il riempimento delle stringhe con importi pari a zero se nulle  -------------------------- 
------------------------------------------------------------------------------------------------------

UPDATE #tot_anagrafiche  SET stringaritenutefiscali = @stringa_ritenute_fiscali_vuota 
where stringaritenutefiscali is null

UPDATE #tot_anagrafiche  SET stringaritenutefiscali_tranche_successive = @stringa_ritenute_fiscali_vuota 
where stringaritenutefiscali_tranche_successive is null

UPDATE #tot_anagrafiche SET stringacompensi_2_tranche = @stringa_compensi_vuota					 
FROM #anagrafiche_ruolo_dalia  
WHERE   stringacompensi_2_tranche is null  

UPDATE #tot_anagrafiche SET stringacompensi_3_tranche = @stringa_compensi_vuota					 
FROM #anagrafiche_ruolo_dalia  
WHERE   stringacompensi_3_tranche is null  

UPDATE #tot_anagrafiche SET stringaritenutenonfiscali_2_tranche = @stringa_ritenute_non_fiscali_vuota					 
FROM #anagrafiche_ruolo_dalia  
WHERE   stringaritenutenonfiscali_2_tranche is null  

UPDATE #tot_anagrafiche SET stringaritenutenonfiscali_3_tranche = @stringa_ritenute_non_fiscali_vuota					 
FROM #anagrafiche_ruolo_dalia  
WHERE   stringaritenutenonfiscali_3_tranche is null  

--SELECT * FROM #tot_anagrafiche
------------------------------------------------------------------------------------------------------ 
--------------------------------------- INIZIO SCRITTURA FLUSSO --------------------------------------
------------------------------------------------------------------------------------------------------ 
-- Record 1
-- 180029030568UNIVERSITA' DEGLI STUDI DELLA TUSCIA                        Via Santa Maria in Gradi n. 4 01100M082VT                                                                                A                                                                                                          
CREATE TABLE #RecordTesta(
	 TIPOREC		char(1),	    -- PIC X      Indicatore del tipo record. Valori ammessi: ‘1’ = record di testa.
	 CODENTEFONTE	varchar(11),    -- PIC X(11)  Codice fiscale dell'ente fonte (ente preposto all'invio dei dati).
	 DENOMENTE      varchar(60),    -- PIC X(60)  Denominazione dell'ente fonte.
	 INDIRIZZO      varchar(30),	-- PICX(30)   Indirizzo dell'ente fonte
	 CAP			varchar(05),	-- PIC X(05)  C.A.P. dell'ente fonte
	 CODCITTA 		varchar(4),		-- PIC X(04)  Codice catastale del comune dell'ente fonte.
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
	SUBSTRING(ISNULL(@2cf,@p_iva),1,11),--CODENTEFONTE   ,
	@agencyname,		--DENOMENTE      ,
	@address,			--INDIRIZZO      ,
	@cap,				--CAP			 ,
	SUBSTRING(@codicecomuneente,1,4),	--CODCITTA 	     ,
	@country,   		--PROVENTE		 ,
	null,		    	--PREFTELEFONO   ,
	SUBSTRING(@phonenumber,1,10),		--NUMTELEFONO	 ,
	null,				--PREFFAX        ,
	SUBSTRING(@fax,1,10),				--NUMFAX 		 ,
	null,				--PERSONARIF	 ,   -- QUA SI DEVONO METTERE I DATI DEL RESPONSABILE DELLA TRASMISSIONE (TUTTAVIA NELL'ESEMPIO MANCA)
	null,				--DESCRQUA       ,   -- QUA SI DEVE METTERE LA QUALIFICA DEL RESPONSABILE DELLA TRASMISSIONE (TUTTAVIA NELL'ESEMPIO MANCA)
	'A',				--TIPOCODIFICA	 ,   -- CODIFICA ASCII
	null				--FILLER			 


-- TRACCIATO DEL "RECORD DI ISTITUZIONE/ENTE/SEZIONE"
-- Esempio record:
-- 2800290305680000000000UNIVERSITA' DEGLI STUDI DELLA TUSCIA                        Via Santa Maria in Gradi n. 4 01100M082VT                              201510201510F                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
CREATE TABLE #Record2( -- "RECORD DI ISTITUZIONE/ENTE/SEZIONE"
 TIPOREC			char(1),     -- PIC X.		Indicatore del tipo record. Valori ammessi: ‘2’ = record di istituzione/ente/sezione;
 CODISTITENTE		varchar(11), -- PIC X(11)   Codice fiscale dell'istituzione/ente cui si riferiscono i dati inviati.
 CODUNIORG          int,	-- PIC 9(10)	Codice che individua la Struttura Organizzativa all'interno dell'istituzione/ente. 
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
 SEZIONE			char(1),     -- PIC X.Sezione cui si riferiscono i dati. Valori ammessi: o	Significato: Sezione (tipologia dei dati economici) cui si riferiscono i dati.
								 -- o	Valori ammessi: ‘F’ = competenze fisse, eventualmente comprensive di compensi accessori se liquidati con lo stesso cedolino e nello stesso capitolo di bilancio;
								 -- ‘C’ = compensi accessori, liquidati con cedolini diversi da quelli relativi alle competenze fisse.
								 -- o	Obbligatorio: Si.
 FILLER				varchar(1635) -- PIC X(1635).
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
	0,				--CODUNIORG         ,  
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
	'F',				--SEZIONE		    ,    --- ‘F’ = competenze fisse, eventualmente comprensive di compensi accessori se liquidati con lo stesso cedolino e nello stesso capitolo di bilancio;
	null				--FILLER				 
 
 --3F800290305680000000000201510201510GVEFRC84B60F499E08000AR240   UNIVMVT00000000      201510I532+001613.94+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.00+000000.00+000000.00          +000000.0/*
 /*
STP-CAP
?Significato: Numero dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
Valori ammessi: spazi.

APP-CAP
?Significato: Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
?Valori ammessi: spazio.

NUM-CAP
?Valori ammessi: 
 -----------------UNIV = MIUR - finanziamento ordinario Universita';
 OSSE = MIUR - finanziamento ordinario Osservatori;
 OSPE = Ospedaliere;
 ENTI = finanziamento da altri enti pubblici o privati;
 ---------------- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
 FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
 spazi = negli altri casi. 
?N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, 
devono essere prodotti records diversi. 

TIPO-PAG
?Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
?Valori ammessi: ‘M’ = mandato;
 ‘R’ = ruolo di spesa fissa;
 ‘O’= ordine di accreditamento;
 ‘S’ = contabilità speciale.
?Obbligatorio: Si.

PROV-SERV
?Significato: Sigla della provincia di servizio del dipendente.
?Obbligatorio: Si.

CLASSE
?Significato: Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.

SCATTI
?Significato: Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
 
POS-STIP 
?Significato: Posizione stipendiale (solo per il personale della scuola).

TAB-VOCI-ECONOMICHE 
?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
 - competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
 - ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); 
 -------------------------------------------------------------------------------------------------------------------------------------------
 ------------------------------------------------------- IMPORTANTE ------------------------------------------------------------------------
 ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.
 -------------------------------------------------------------------------------------------------------------------------------------------
 -------------------------------------------------------------------------------------------------------------------------------------------

La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
 Ogni elemento della tabella è costituito dai sottocampi che seguono.

------------------------TAB-VOCI-MENS-COMPET  -- Utilizzare la mensilità della liquidazione
?Significato: Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
 N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
 
TAB-VOCI-ECO-COD -- E' stata creata la classificazione
?Significato: Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
?Congruenze: Diverso da spazi se uno degli importi relativi è diverso da zero.

----------------------TAB-VOCI-ECO-IMP-BASE
?Significato: Importo della voce economica. Per le competenze va riportata la sola voce base.

TAB-VOCI-ECO-ARR-CORR
?Significato: Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.

TAB-VOCI-ECO-ARR-PREC
?Significato: Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.

-------------------------IRPEF-CORRENTE
?Significato: Ritenuta fiscale effettuata sulle competenze base.

IRPEF-ARR-CORR
?Significato: Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.

IRPEF-ARR-PREC
?Significato: Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.

TAB-SINDACATO
?Significato: Tabella contenente i dati relativi alle ritenute sindacali.
 La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

TAB-SINDACATO-MENS-COMPET
?Significato: Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
 
TAB-SINDACATO-COD
?Significato: Codice fiscale dell’organizzazione sindacale.
?Congruenze: Diverso da spazi se il relativo importo risulta diverso da zero.

TAB-SINDACATO-IMP
?Significato: Importo versato all’organizzazione sindacale.

TAB-TRATT-RAP
?Significato: Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
 La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
 Ogni elemento è costituito dai sottocampi che seguono.

TAB-TRATT-RAP-MENS-COMPET 
?Significato: Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori 
dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; 
in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate 
con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale 
l’anno di competenza è sempre uguale all’anno di liquidazione.
 
TAB-TRATT-RAP-COD
?Significato: Codice del contributo previdenziale/assistenziale .
?Congruenze: Diverso da spazi se il relativo importo è diverso da zero.

TAB-TRATT-RAP-IMP
?Significato: Imponibile del contributo previdenziale/assistenziale.

TAB-TRATT-RAP-DIP
?Significato: Importo delle trattenute a carico del dipendente.

TAB-TRATT-RAP-AMM
?Significato: Importo dei contributi a carico dell'amministrazione.

FAM-ASS
?Significato: Numero dei familiari ai fini dell'assegno.

FAM-DETR
?Significato: Numero dei familiari ai fini delle detrazioni.
?Obbligatorio: Si.

DETRAZ
?Significato: Importo totale delle detrazioni d'imposta operate.

GG-PRES
?Significato: Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).

ULT-REC
 ?Significato: Indica se sono presenti più record per lo stesso dipendente
?Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
 '1' = sono presenti ulteriori successivi record per il dipendente.
?Obbligatorio: Si.
?Congruenze: Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
 - TIPO-REC
 - CODFISC-DIP
 - COD-COMP
 - COD-SCOMP
 - COD-RUOLO
 - COD-PROFILO
 - COD-POSECON
 - STP-CAP
 - APP-CAP
 - NUM-CAP
 - TIPO-PAG
 - TAB-MENS-COMPET.  
oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 

*/

 
CREATE TABLE #Record3
(
	idreg			int,
	TIPOREC			char(1),		-- PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	SEZIONE			char(1),		-- PIC X.Il valore ammesso è ‘G’ (anagrafico-giuridica).
	CODISTITENTE    varchar(11),	-- PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODUNIORG		int,			-- 9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	INIPERRIF		datetime,		-- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	FINPERRIF		datetime,		-- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODFISCDIP		varchar(16),	-- X(16).Codice fiscale del dipendente.
	CODCOMP  		varchar(2),		-- X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	CODSCOMP  		varchar(2),		-- X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CODRUOLO		char(1),		-- PIC X. 
	CODPROFILO		varchar(03),	-- PIC X(03).
	CODPOSECON		varchar(2),		-- PIC X(02).
	STPCAP			varchar(2),		-- PIC X(02). Numero dello stato di previsione dell’amministrazione nella Legge 
					-- di bilancio dello Stato per l’esercizio finanziario.Valori ammessi: spazi.
	APPCAP			char(1),		-- PIC X(01).Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
					-- Valori ammessi: spazio.
	NUMCAP			varchar(4),		-- PIC X(04).
	-- Valori ammessi: 
	-- UNIV = MIUR - finanziamento ordinario Universita';
	-- OSSE = MIUR - finanziamento ordinario Osservatori;
	-- OSPE = Ospedaliere;
	-- ENTI = finanziamento da altri enti pubblici o privati;
	-- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
	-- FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
	-- spazi = negli altri casi. 
	--N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, devono essere prodotti records diversi. 
	TIPOPAG			char(1), -- PIC X.
		--Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
		--Valori ammessi: ‘M’ = mandato;
		-- ‘R’ = ruolo di spesa fissa;
		-- ‘O’= ordine di accreditamento;
		-- ‘S’ = contabilità speciale.
	PROVSERV		varchar(2), -- PIC X(02). Sigla della provincia di servizio del dipendente.
	CLASSE			int, -- PIC 9(04).Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.
	SCATTI			int, -- PIC 9(04).Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
	POSSTIP			varchar(6), -- PIC X(06).Posizione stipendiale (solo per il personale della scuola).
	-- TABVOCIECONOMICHE OCCURS 25. ?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
	-- competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
	-- ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.

	-- La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	-- Ogni elemento della tabella è costituito dai sottocampi che seguono.

	TABVOCIMENSCOMPET varchar(6), -- PIC X(6). Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
					   -- N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
	TABVOCIECOCOD    varchar(4), -- PIC X(4). Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
				   -- Diverso da spazi se uno degli importi relativi è diverso da zero.
	TABVOCIECOIMPBASE	decimal(19,2), -- PIC +999999.99. Importo della voce economica. Per le competenze va riportata la sola voce base.
	TABVOCIECOARRCORR	decimal(19,2), -- PIC +999999.99. Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.
	TABVOCIECOARRPREC	decimal(19,2), -- PIC +999999.99. Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.
	IRPEFCORRENTE		decimal(19,2), -- PIC +999999.99. Ritenuta fiscale effettuata sulle competenze base.
	IRPEFARRCORR		decimal(19,2), -- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.
	IRPEFARRPREC		decimal(19,2), -- PIC +999999.99.Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.

	--TABSINDACATO, -- OCCURS 3.
	-- Tabella contenente i dati relativi alle ritenute sindacali.
	-- La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

	TABSINDACATOMENSCOMPET varchar(6), -- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	TABSINDACATOCOD			varchar(11), -- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	TABSINDACATOIMP		decimal(19,2), -- PIC +999999.99.Importo versato all’organizzazione sindacale.
	--TABTRATTRAP, -- OCCURS 15. 
	--Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
	--La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	--Ogni elemento è costituito dai sottocampi che seguono.

	TABTRATTRAPMENSCOMPET varchar(6), -- PIC X(6). --Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale l’anno di competenza è sempre uguale all’anno di liquidazione.
	TABTRATTRAPCOD		varchar(3), -- PIC X(3).Codice del contributo previdenziale/assistenziale .
									-- Diverso da spazi se il relativo importo è diverso da zero.
	TABTRATTRAPIMP		decimal(19,2), -- PIC +999999.99. Imponibile del contributo previdenziale/assistenziale.
	TABTRATTRAPDIP		decimal(19,2), -- PIC +999999.99. Importo delle trattenute a carico del dipendente.
	TABTRATTRAPAMM		decimal(19,2), -- PIC +999999.99. Importo dei contributi a carico dell'amministrazione.
	FAMASS				int, -- PIC 9(02). Numero dei familiari ai fini dell'assegno.
	FAMDETR				int, -- PIC 9(02).Numero dei familiari ai fini delle detrazioni.
	DETRAZ				decimal(19,2), -- PIC +999999.99.Importo totale delle detrazioni d'imposta operate.
	GGPRES				int, -- PIC 9(03).Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).
	ULTREC				char(1), -- PIC X. Indica se sono presenti più record per lo stesso dipendente
						-- Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
						-- '1' = sono presenti ulteriori successivi record per il dipendente.
						-- Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
						-- - TIPO-REC
						-- - CODFISC-DIP
						-- - COD-COMP
						-- - COD-SCOMP
						-- - COD-RUOLO
						-- - COD-PROFILO
						-- - COD-POSECON
						-- - STP-CAP
						-- - APP-CAP
						-- - NUM-CAP
						-- - TIPO-PAG
						-- - TAB-MENS-COMPET.  
						-- - oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 
	FILLER				varchar(2)-- PIC X(2).
	)

-----------------------------------------------------------------------------------------------------------------
------- RECORD  DI DETTAGLIO DELL'ANAGRAFICA, UNO PER OGNI COPPIA ANAGRAFICA- RUOLO DALIA DISTINTA -------------- 
--- L'EVENTUALE INSERIMENTO DI RECORD AGGIUNTIVI VERRA' EFFETTUATO NELLA SCRITTURA DEL TRACCIATO E NON ORA ------  
-----------------------------------------------------------------------------------------------------------------

INSERT INTO #Record3
(
	idreg			,
	TIPOREC			,   -- PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	SEZIONE			,   -- PIC X.Il valore ammesso è ‘E’ (anagrafico-giuridica).
	CODISTITENTE    ,   -- PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODUNIORG		,   -- 9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	INIPERRIF		,   -- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	FINPERRIF		,   -- 9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	CODFISCDIP		,   -- X(16).Codice fiscale del dipendente.
	CODCOMP  		,   -- X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	CODSCOMP  		,   -- X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CODRUOLO		,	--PIC X. 
	CODPROFILO		,	--PIC X(03).
	CODPOSECON		,   --PIC X(02).
	STPCAP			,	--PIC X(02). Numero dello stato di previsione dell’amministrazione nella Legge 
			-- di bilancio dello Stato per l’esercizio finanziario.Valori ammessi: spazi.
	APPCAP			, -- PIC X(01).Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
			-- Valori ammessi: spazio.
	NUMCAP			, -- PIC X(04).
				
	-- Valori ammessi: 
	-- UNIV = MIUR - finanziamento ordinario Universita';
	-- OSSE = MIUR - finanziamento ordinario Osservatori;
	-- OSPE = Ospedaliere;
	-- ENTI = finanziamento da altri enti pubblici o privati;
	-- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
	-- FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
	-- spazi = negli altri casi. 
	--N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, devono essere prodotti records diversi. 

	TIPOPAG			, -- PIC X.
		--Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
		--Valori ammessi: ‘M’ = mandato;
		-- ‘R’ = ruolo di spesa fissa;
		-- ‘O’= ordine di accreditamento;
		-- ‘S’ = contabilità speciale.
	PROVSERV		, -- PIC X(02). Sigla della provincia di servizio del dipendente.
	CLASSE			, -- PIC 9(04).Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.
	SCATTI			, -- PIC 9(04).Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
	POSSTIP			, -- PIC X(06).Posizione stipendiale (solo per il personale della scuola).
	-- TABVOCIECONOMICHE OCCURS 25. ?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
	-- competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
	-- ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.

	-- La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	-- Ogni elemento della tabella è costituito dai sottocampi che seguono.

	TABVOCIMENSCOMPET	, -- PIC X(6). Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
					   -- N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
	TABVOCIECOCOD		, -- PIC X(4). Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
				   -- Diverso da spazi se uno degli importi relativi è diverso da zero.
	TABVOCIECOIMPBASE	, -- PIC +999999.99. Importo della voce economica. Per le competenze va riportata la sola voce base.
	TABVOCIECOARRCORR	, -- PIC +999999.99. Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.
	TABVOCIECOARRPREC	, -- PIC +999999.99. Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.
	IRPEFCORRENTE		,	-- PIC +999999.99. Ritenuta fiscale effettuata sulle competenze base.
	IRPEFARRCORR		, -- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.
	IRPEFARRPREC		, -- PIC +999999.99.Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.

	--TABSINDACATO, -- OCCURS 3.
	-- Tabella contenente i dati relativi alle ritenute sindacali.
	-- La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

	TABSINDACATOMENSCOMPET	, -- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	TABSINDACATOCOD		, -- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	TABSINDACATOIMP		, -- PIC +999999.99.Importo versato all’organizzazione sindacale.
	--TABTRATTRAP, -- OCCURS 15. 
	--Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
	--La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	--Ogni elemento è costituito dai sottocampi che seguono.

	TABTRATTRAPMENSCOMPET	, -- PIC X(6). --Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale l’anno di competenza è sempre uguale all’anno di liquidazione.
	TABTRATTRAPCOD			, -- PIC X(3).Codice del contributo previdenziale/assistenziale .
					-- Diverso da spazi se il relativo importo è diverso da zero.
	TABTRATTRAPIMP	, -- PIC +999999.99. Imponibile del contributo previdenziale/assistenziale.
	TABTRATTRAPDIP	, -- PIC +999999.99. Importo delle trattenute a carico del dipendente.
	TABTRATTRAPAMM	, -- PIC +999999.99. Importo dei contributi a carico dell'amministrazione.
	FAMASS	, -- PIC 9(02). Numero dei familiari ai fini dell'assegno.
	FAMDETR		 , -- PIC 9(02).Numero dei familiari ai fini delle detrazioni.
	DETRAZ	, -- PIC +999999.99.Importo totale delle detrazioni d'imposta operate.
	GGPRES	, -- PIC 9(03).Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).
	ULTREC	, -- PIC X. Indica se sono presenti più record per lo stesso dipendente
			-- Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
			-- '1' = sono presenti ulteriori successivi record per il dipendente.
			--Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
			-- - TIPO-REC
			-- - CODFISC-DIP
			-- - COD-COMP
			-- - COD-SCOMP
			-- - COD-RUOLO
			-- - COD-PROFILO
			-- - COD-POSECON
			-- - STP-CAP
			-- - APP-CAP
			-- - NUM-CAP
			-- - TIPO-PAG
			-- - TAB-MENS-COMPET.  
			--oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 
	FILLER -- PIC X(2).

) 

SELECT DISTINCT
	R.idreg,
	'3',					--TIPOREC			,     PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	'F',					--SEZIONE			,     PIC X.Il valore ammesso è ‘G’ (anagrafico-giuridica).
	ISNULL(@2cf,@p_iva),	--CODISTITENTE		,     PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	0,						--CODUNIORG			,	  9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	@start,		   		    --INIPERRIF			,	  9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	@stop,				    --FINPERRIF			,     9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	R.cf,					--CODFISCDIP		,     X(16).Codice fiscale del dipendente.
	'08',					--CODCOMP  			,     X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	'00',					--CODSCOMP  		,     X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
							--COD-QUA				  Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
													  --tabella qualifiche per il comparto università (codice a sei cifre)
	SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1),			  --CODRUOLO		,	  PIC X. 
	SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3),			  --CODPROFILO		,	  PIC X(03).
	SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2),			  --CODPOSECON		,     PIC X(02).
	null,					-- STPCAP			,	  PIC X(02). Numero dello stato di previsione dell’amministrazione nella Legge 
	null,					--						  di bilancio dello Stato per l’esercizio finanziario.Valori ammessi: spazi.
							-- APPCAP			,	  PIC X(01).Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
	'UNIV',					--						  -- Valori ammessi: spazio.
							-- NUMCAP, -- PIC X(04).		
							---- Valori ammessi: 
							---- UNIV = MIUR - finanziamento ordinario Universita';
							---- OSSE = MIUR - finanziamento ordinario Osservatori;
							---- OSPE = Ospedaliere;
							---- ENTI = finanziamento da altri enti pubblici o privati;
							---- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
							---- FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
							---- spazi = negli altri casi. 
							---- N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, devono essere prodotti records diversi. 

	'M',						--TIPOPAG, -- PIC X.
							--	--Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
							--	--Valori ammessi: ‘M’ = mandato;
							--	-- ‘R’ = ruolo di spesa fissa;
							--	-- ‘O’= ordine di accreditamento;
							--	-- ‘S’ = contabilità speciale.
	@country,				-- PROVSERV, -- PIC X(02). Sigla della provincia di servizio del dipendente.
	0,					-- CLASSE,   -- PIC 9(04).Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.
	0,					-- SCATTI,   -- PIC 9(04).Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
	null,					-- POSSTIP,  -- PIC X(06).Posizione stipendiale (solo per il personale della scuola).
	--codice classificazione()	---- TABVOCIECONOMICHE OCCURS 25. ?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
							---- competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
							---- ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.

							---- La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
							---- Ogni elemento della tabella è costituito dai sottocampi che seguono.

	null,					-- TABVOCIMENSCOMPET, -- PIC X(6). Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
	null,					--				   -- N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
	null,					-- TABVOCIECOCOD, -- PIC X(4). Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
	null,					-- Diverso da spazi se uno degli importi relativi è diverso da zero.
	null,					-- TABVOCIECOIMPBASE, -- PIC +999999.99. Importo della voce economica. Per le competenze va riportata la sola voce base.
							-- TABVOCIECOARRCORR, -- PIC +999999.99. Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.
							-- TABVOCIECOARRPREC, -- PIC +999999.99. Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.
	null,					-- IRPEFCORRENTE, -- PIC +999999.99. Ritenuta fiscale effettuata sulle competenze base.
	null,					-- IRPEFARRCORR, -- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.
	null,					-- IRPEFARRPREC, -- PIC +999999.99.Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.

							---- TABSINDACATO, -- OCCURS 3.
							---- Tabella contenente i dati relativi alle ritenute sindacali.
							---- La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

	null,					-- TABSINDACATOMENSCOMPET, -- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	null,					-- TABSINDACATOCOD, -- PIC X(11). Codice fiscale dell’organizzazione sindacale.
							--				 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	null,					-- TABSINDACATOIMP, -- PIC +999999.99.Importo versato all’organizzazione sindacale.
							---- TABTRATTRAP, -- OCCURS 15. 
							----Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
							----La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
							----Ogni elemento è costituito dai sottocampi che seguono.

	null,					-- TABTRATTRAPMENSCOMPET, -- PIC X(6). --Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale l’anno di competenza è sempre uguale all’anno di liquidazione.
	null,					-- TABTRATTRAPCOD, -- PIC X(3).Codice del contributo previdenziale/assistenziale .
							--				-- Diverso da spazi se il relativo importo è diverso da zero.
	REPLICATE('0',9),					-- TABTRATTRAPIMP, -- PIC +999999.99. Imponibile del contributo previdenziale/assistenziale.
	REPLICATE('0',9),					-- TABTRATTRAPDIP, -- PIC +999999.99. Importo delle trattenute a carico del dipendente.
	REPLICATE('0',9),					-- TABTRATTRAPAMM, -- PIC +999999.99. Importo dei contributi a carico dell'amministrazione.
	0,					-- FAMASS, -- PIC 9(02). Numero dei familiari ai fini dell'assegno.
	0,					-- FAMDETR, -- PIC 9(02).Numero dei familiari ai fini delle detrazioni.
	null,					-- DETRAZ, -- PIC +999999.99.Importo totale delle detrazioni d'imposta operate.
	0 ,					-- GGPRES, -- PIC 9(03).Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).
	'0',					-- ULTREC, -- PIC X. Indica se sono presenti più record per lo stesso dipendente
							--		-- Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
							--		-- '1' = sono presenti ulteriori successivi record per il dipendente.
							--		-- Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
							--		-- - TIPO-REC
							--		-- - CODFISC-DIP
							--		-- - COD-COMP
							--		-- - COD-SCOMP
							--		-- - COD-RUOLO
							--		-- - COD-PROFILO
							--		-- - COD-POSECON
							--		-- - STP-CAP
							--		-- - APP-CAP
							--		-- - NUM-CAP
							--		-- - TIPO-PAG
							--		-- - TAB-MENS-COMPET.  
							--		-- - oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 
	null					-- FILLER -- PIC X(2).
 FROM #tot_anagrafiche
 JOIN registry R ON #tot_anagrafiche.idreg = R.idreg
 
 
--select * from #tot_anagrafiche
------select * from #Record2
--select * from #Record3


DECLARE @numero_Record02 int
SET @numero_Record02 = (SELECT COUNT(*) FROM #Record2)

DECLARE @numero_Record03 int
SET @numero_Record03 = (SELECT COUNT(*) FROM #Record3)


DECLARE @numero_Record03_aggiuntivi int
SET @numero_Record03_aggiuntivi = (SELECT SUM(record_aggiuntivi) FROM #anagrafiche_ruolo_dalia)
 
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
 1 +  @numero_Record02  + @numero_Record03 + @numero_Record03_aggiuntivi,   -- Un Record di testa + Un Record 02 + Numero di Record 03
replicate('',290)

-- Tabella di output
CREATE TABLE #tracciato(
    --ProgGen int identity(0,1),
    TipoRecord    varchar(2),        -- Tipo record (00-01-02)
    ProgrTipoRec  int identity(1,1),   
    stringa varchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS
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
	 [dbo].[GetStringFormatted_r](FILLER,1607)				-- varchar(1607)   -- PIC X(1607)
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
	[dbo].[GetStringFormatted_r](FILLER	,1635)		       -- varchar(1635) -- PIC X(1635).
FROM #Record2



-----------------------------------------------------------------------------------------------------------------
--------------------------------------- SCRITTURA DEL PRIMO RECORD DELL'ANAGRAFICA ------------------------------ 
-----------------------------------------------------------------------------------------------------------------

INSERT INTO #tracciato
(   
    TipoRecord,
    stringa
)
SELECT
    TIPOREC,
	[dbo].[GetStringFormatted_r](TIPOREC,1)			+ --   PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	[dbo].[GetStringFormatted_r](SEZIONE,1)			+ --   PIC X.Il valore ammesso è ‘E’ (anagrafico-giuridica).
	[dbo].[GetStringFormatted_r](CODISTITENTE,11)	+ --   PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetInt](CODUNIORG,10)					+ --   9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(INIPERRIF),4) + [dbo].[Getint](MONTH(INIPERRIF),2) + 	--   9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(FINPERRIF),4) + [dbo].[Getint](MONTH(FINPERRIF),2) +	--   9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](CODFISCDIP,16) +	--   X(16).Codice fiscale del dipendente.
	[dbo].[GetStringFormatted_r](CODCOMP,2) +		--   X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	[dbo].[GetStringFormatted_r](CODSCOMP,2) +		--   X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CASE WHEN #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODRUOLO,1)
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1),1)
	END  +  --   PIC X. 
	CASE WHEN  #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODPROFILO,3)  --   PIC X(03).
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3),3)
	END +
	CASE WHEN #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODPOSECON,2)   --   PIC X(02).
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2),2)
	END +
	[dbo].[GetStringFormatted_r](STPCAP,2) +  --   PIC X(02). Numero dello stato di previsione dell’amministrazione nella Legge 
			-- di bilancio dello Stato per l’esercizio finanziario.Valori ammessi: spazi.
	[dbo].[GetStringFormatted_r](APPCAP,1) +  --    PIC X(01).Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
			-- Valori ammessi: spazio.
	[dbo].[GetStringFormatted_r](NUMCAP,4) +  --   PIC X(04).
				
	-- Valori ammessi: 
	-- UNIV = MIUR - finanziamento ordinario Universita';
	-- OSSE = MIUR - finanziamento ordinario Osservatori;
	-- OSPE = Ospedaliere;
	-- ENTI = finanziamento da altri enti pubblici o privati;
	-- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
	-- FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
	-- spazi = negli altri casi. 
	-- N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, devono essere prodotti records diversi. 

	[dbo].[GetStringFormatted_r](TIPOPAG,1) +  --    PIC X.
		-- Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
		-- Valori ammessi: ‘M’ = mandato;
		-- ‘R’ = ruolo di spesa fissa;
		-- ‘O’= ordine di accreditamento;
		-- ‘S’ = contabilità speciale.
	[dbo].[GetStringFormatted_r](PROVSERV,2) + -- PIC X(02). Sigla della provincia di servizio del dipendente.
	[dbo].[GetInt](CLASSE,4)   + -- PIC 9(04).Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.
	[dbo].[GetInt](SCATTI,4)   + -- PIC 9(04).Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
	[dbo].[GetStringFormatted_r](POSSTIP,6)  + -- PIC X(06).Posizione stipendiale (solo per il personale della scuola).
	-- TABVOCIECONOMICHE OCCURS 25. ?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
	-- competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
	-- ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.

	-- La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	-- Ogni elemento della tabella è costituito dai sottocampi che seguono.
	--[dbo].[GetStringFormatted_r](TABVOCIMENSCOMPET,6) + -- PIC X(6). Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
	--				   -- N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
	--[dbo].[GetStringFormatted_r](TABVOCIECOCOD,4) +-- PIC X(4). Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
	--			   -- Diverso da spazi se uno degli importi relativi è diverso da zero.
	--[dbo].[GetStringFormatted_r](TABVOCIECOIMPBASE,10) +-- PIC +999999.99. Importo della voce economica. Per le competenze va riportata la sola voce base.
	--[dbo].[GetStringFormatted_r](TABVOCIECOARRCORR,10) +-- PIC +999999.99. Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.
	--[dbo].[GetStringFormatted_r](TABVOCIECOARRPREC,10) +-- PIC +999999.99. Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.
	 #tot_anagrafiche.stringacompensi +
	
	--[dbo].[GetStringFormatted_r](IRPEFCORRENTE,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sulle competenze base.
	--[dbo].[GetStringFormatted_r](IRPEFARRCORR,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.
	--[dbo].[GetStringFormatted_r](IRPEFARRPREC,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.
	#tot_anagrafiche.stringaritenutefiscali   +
	--TABSINDACATO, -- OCCURS 3.
	-- Tabella contenente i dati relativi alle ritenute sindacali.
	-- La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) +  + -- PIC +999999.99.Importo versato all’organizzazione sindacale.
	
	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) +  -- PIC +999999.99.Importo versato all’organizzazione sindacale.


	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) + -- PIC +999999.99.Importo versato all’organizzazione sindacale.


	--TABTRATTRAP, -- OCCURS 15. 
	--Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
	--La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	--Ogni elemento è costituito dai sottocampi che seguono.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPMENSCOMPET,6) + -- PIC X(6). --Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale l’anno di competenza è sempre uguale all’anno di liquidazione.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPCOD,3) + -- PIC X(3).Codice del contributo previdenziale/assistenziale .
	-- Diverso da spazi se il relativo importo è diverso da zero.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPIMP,1) +-- PIC +999999.99. Imponibile del contributo previdenziale/assistenziale.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPDIP,1) +-- PIC +999999.99. Importo delle trattenute a carico del dipendente.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPAMM,1) +-- PIC +999999.99. Importo dei contributi a carico dell'amministrazione.
	#tot_anagrafiche.stringaritenutenonfiscali +
	[dbo].[GetInt](FAMASS,2) + -- PIC 9(02). Numero dei familiari ai fini dell'assegno.
	[dbo].[GetInt](FAMDETR,2) + -- PIC 9(02).Numero dei familiari ai fini delle detrazioni.
	-- [dbo].[GetStringFormatted_r](DETRAZ,1) +-- PIC +999999.99.Importo totale delle detrazioni d'imposta operate.
	'+' +  [dbo].GetDecimal_19_2(0,9) +
	[dbo].[GetInt](GGPRES,3) +-- PIC 9(03).Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).
	CASE WHEN #tot_anagrafiche.record_aggiuntivi = 0   -- CAMPO ULTREC
		 THEN [dbo].[GetStringFormatted_r](0,1)  --- E' L'ULTIMO RECORD PER QUELL'ANAGRAFICA
	     ELSE [dbo].[GetStringFormatted_r](1,1)  --  SEGUONO ULTERIORI RECORD 
	END 
	+-- PIC X. Indica se sono presenti più record per lo stesso dipendente
			-- Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
			-- '1' = sono presenti ulteriori successivi record per il dipendente.
			-- Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
			-- - TIPO-REC
			-- - CODFISC-DIP
			-- - COD-COMP
			-- - COD-SCOMP
			-- - COD-RUOLO
			-- - COD-PROFILO
			-- - COD-POSECON
			-- - STP-CAP
			-- - APP-CAP
			-- - NUM-CAP
			-- - TIPO-PAG
			-- - TAB-MENS-COMPET.  
			--oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 
	[dbo].[GetStringFormatted_r](FILLER,2) -- PIC X(2).
FROM #Record3
JOIN #tot_anagrafiche ON #tot_anagrafiche.idreg = #Record3.idreg
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1) =	#Record3.CODRUOLO		 --	  PIC X. 
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3) = #Record3.CODPROFILO		 --   PIC X(03).
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2) =	#Record3.CODPOSECON		 --   PIC X(02).
JOIN registry R ON #tot_anagrafiche.idreg = R.idreg



--select * 
--FROM #Record3

--select idreg, count(idreg) 
--FROM #tot_anagrafiche group by idreg  having count( idreg ) > 1

--select * 
--FROM #Record3
--JOIN #tot_anagrafiche ON #tot_anagrafiche.idreg = #Record3.idreg
--	--(idreg, stringacompensi, stringaritenutefiscali, stringaritenutenonfiscali , mese)
--JOIN registry R ON #tot_anagrafiche.idreg = R.idreg
-----------------------------------------------------------------------------------------------------------------
------------------------- SCRITTURA DEL PRIMO RECORD AGGIUNTVO SE NECESSARIO ------------------------------------
-----------------------------------------------------------------------------------------------------------------

INSERT INTO #tracciato
(   
    TipoRecord,
    stringa
)
SELECT
    TIPOREC,
	[dbo].[GetStringFormatted_r](TIPOREC,1)			+ --   PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	[dbo].[GetStringFormatted_r](SEZIONE,1)			+ --   PIC X.Il valore ammesso è ‘E’ (anagrafico-giuridica).
	[dbo].[GetStringFormatted_r](CODISTITENTE,11)	+ --   PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetInt](CODUNIORG,10)					+ --   9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(INIPERRIF),4) + [dbo].[Getint](MONTH(INIPERRIF),2) + 	--   9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(FINPERRIF),4) + [dbo].[Getint](MONTH(FINPERRIF),2) +	--   9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](CODFISCDIP,16) +	--   X(16).Codice fiscale del dipendente.
	[dbo].[GetStringFormatted_r](CODCOMP,2) +		--   X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	[dbo].[GetStringFormatted_r](CODSCOMP,2) +		--   X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CASE WHEN #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODRUOLO,1)
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1),1)
	END  +  --   PIC X. 
	CASE WHEN  #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODPROFILO,3)  --   PIC X(03).
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3),3)
	END +
	CASE WHEN #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODPOSECON,2)   --   PIC X(02).
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2),2)
	END +
	[dbo].[GetStringFormatted_r](STPCAP,2) +  --   PIC X(02). Numero dello stato di previsione dell’amministrazione nella Legge 
			-- di bilancio dello Stato per l’esercizio finanziario.Valori ammessi: spazi.
	[dbo].[GetStringFormatted_r](APPCAP,1) +  --    PIC X(01).Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
			-- Valori ammessi: spazio.
	[dbo].[GetStringFormatted_r](NUMCAP,4) +  --   PIC X(04).
				
	-- Valori ammessi: 
	-- UNIV = MIUR - finanziamento ordinario Universita';
	-- OSSE = MIUR - finanziamento ordinario Osservatori;
	-- OSPE = Ospedaliere;
	-- ENTI = finanziamento da altri enti pubblici o privati;
	-- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
	-- FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
	-- spazi = negli altri casi. 
	-- N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, devono essere prodotti records diversi. 

	[dbo].[GetStringFormatted_r](TIPOPAG,1) +  --    PIC X.
		-- Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
		-- Valori ammessi: ‘M’ = mandato;
		-- ‘R’ = ruolo di spesa fissa;
		-- ‘O’= ordine di accreditamento;
		-- ‘S’ = contabilità speciale.
	[dbo].[GetStringFormatted_r](PROVSERV,2) + -- PIC X(02). Sigla della provincia di servizio del dipendente.
	[dbo].[GetInt](CLASSE,4)   + -- PIC 9(04).Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.
	[dbo].[GetInt](SCATTI,4)   + -- PIC 9(04).Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
	[dbo].[GetStringFormatted_r](POSSTIP,6)  + -- PIC X(06).Posizione stipendiale (solo per il personale della scuola).
	-- TABVOCIECONOMICHE OCCURS 25. ?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
	-- competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
	-- ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.

	-- La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	-- Ogni elemento della tabella è costituito dai sottocampi che seguono.
	--[dbo].[GetStringFormatted_r](TABVOCIMENSCOMPET,6) + -- PIC X(6). Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
	--				   -- N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
	--[dbo].[GetStringFormatted_r](TABVOCIECOCOD,4) +-- PIC X(4). Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
	--			   -- Diverso da spazi se uno degli importi relativi è diverso da zero.
	#tot_anagrafiche.stringacompensi_2_tranche +
	--[dbo].[GetStringFormatted_r](TABVOCIECOIMPBASE,1) +-- PIC +999999.99. Importo della voce economica. Per le competenze va riportata la sola voce base.
	--[dbo].[GetStringFormatted_r](TABVOCIECOARRCORR,1) +-- PIC +999999.99. Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.
	--[dbo].[GetStringFormatted_r](TABVOCIECOARRPREC,1) +-- PIC +999999.99. Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.
	
	--[dbo].[GetStringFormatted_r](IRPEFCORRENTE,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sulle competenze base.
	--[dbo].[GetStringFormatted_r](IRPEFARRCORR,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.
	--[dbo].[GetStringFormatted_r](IRPEFARRPREC,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.
	#tot_anagrafiche.stringaritenutefiscali_tranche_successive 	  +
	--TABSINDACATO, -- OCCURS 3.
	-- Tabella contenente i dati relativi alle ritenute sindacali.
	-- La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) +  + -- PIC +999999.99.Importo versato all’organizzazione sindacale.
	
	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) +  -- PIC +999999.99.Importo versato all’organizzazione sindacale.


	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) + -- PIC +999999.99.Importo versato all’organizzazione sindacale.


	--TABTRATTRAP, -- OCCURS 15. 
	--Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
	--La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	--Ogni elemento è costituito dai sottocampi che seguono.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPMENSCOMPET,6) + -- PIC X(6). --Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale l’anno di competenza è sempre uguale all’anno di liquidazione.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPCOD,3) + -- PIC X(3).Codice del contributo previdenziale/assistenziale .
	-- Diverso da spazi se il relativo importo è diverso da zero.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPIMP,1) +-- PIC +999999.99. Imponibile del contributo previdenziale/assistenziale.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPDIP,1) +-- PIC +999999.99. Importo delle trattenute a carico del dipendente.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPAMM,1) +-- PIC +999999.99. Importo dei contributi a carico dell'amministrazione.
	#tot_anagrafiche.stringaritenutenonfiscali_2_tranche  +
	[dbo].[GetInt](FAMASS,2) + -- PIC 9(02). Numero dei familiari ai fini dell'assegno.
	[dbo].[GetInt](FAMDETR,2) + -- PIC 9(02).Numero dei familiari ai fini delle detrazioni.
	-- [dbo].[GetStringFormatted_r](DETRAZ,1) +-- PIC +999999.99.Importo totale delle detrazioni d'imposta operate.
	'+' +  [dbo].GetDecimal_19_2(0,9) +
	[dbo].[GetInt](GGPRES,3) +-- PIC 9(03).Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).
	CASE WHEN #tot_anagrafiche.record_aggiuntivi = 1   -- CAMPO ULTREC
		 THEN [dbo].[GetStringFormatted_r](0,1)  --- E' L'ULTIMO RECORD PER QUELL'ANAGRAFICA
	     ELSE [dbo].[GetStringFormatted_r](1,1)  --  SEGUONO ULTERIORI RECORD 
	END 
	 +-- PIC X. Indica se sono presenti più record per lo stesso dipendente
			-- Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
			-- '1' = sono presenti ulteriori successivi record per il dipendente.
			-- Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
			-- - TIPO-REC
			-- - CODFISC-DIP
			-- - COD-COMP
			-- - COD-SCOMP
			-- - COD-RUOLO
			-- - COD-PROFILO
			-- - COD-POSECON
			-- - STP-CAP
			-- - APP-CAP
			-- - NUM-CAP
			-- - TIPO-PAG
			-- - TAB-MENS-COMPET.  
			--oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 
	[dbo].[GetStringFormatted_r](FILLER,2) -- PIC X(2).
FROM #Record3
JOIN #tot_anagrafiche ON #tot_anagrafiche.idreg = #Record3.idreg
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1) =	#Record3.CODRUOLO		 --	  PIC X. 
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3) = #Record3.CODPROFILO		 --   PIC X(03).
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2) =	#Record3.CODPOSECON		 --   PIC X(02).
JOIN registry R ON #tot_anagrafiche.idreg = R.idreg
WHERE   #tot_anagrafiche.record_aggiuntivi >= 1

-----------------------------------------------------------------------------------------------------------------
------------------------- SCRITTURA DEL SECONDO RECORD AGGIUNTVO SE NECESSARIO ---------------------------------- 
-----------------------------------------------------------------------------------------------------------------

INSERT INTO #tracciato
(   
    TipoRecord,
    stringa
)
SELECT
    TIPOREC,
	[dbo].[GetStringFormatted_r](TIPOREC,1)			+ --   PIC X.Indicatore del tipo record. Valori ammessi: '3' = record di dettaglio.
	[dbo].[GetStringFormatted_r](SEZIONE,1)			+ --   PIC X.Il valore ammesso è ‘E’ (anagrafico-giuridica).
	[dbo].[GetStringFormatted_r](CODISTITENTE,11)	+ --   PIC X(11).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetInt](CODUNIORG,10)					+ --   9(10).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(INIPERRIF),4) + [dbo].[Getint](MONTH(INIPERRIF),2) + 	--   9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](YEAR(FINPERRIF),4) + [dbo].[Getint](MONTH(FINPERRIF),2) +	--   9(06).cfr. "RECORD DI ISTITUZIONE/ENTE/SEZIONE" , paragrafo 3.1.4.
	[dbo].[GetStringFormatted_r](CODFISCDIP,16) +	--   X(16).Codice fiscale del dipendente.
	[dbo].[GetStringFormatted_r](CODCOMP,2) +		--   X(02).Codice del comparto di contrattazione collettiva cui appartiene il dipendente. Valori ammessi: 08.
	[dbo].[GetStringFormatted_r](CODSCOMP,2) +		--   X(02).Codice del contratto di appartenenza del dipendente. Valori ammessi: 00.
	-- COD-QUA			char(1), --  .Codice della qualifica del dipendente. Cfr. ELENCO CODICI. 
	CASE WHEN #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODRUOLO,1)
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1),1)
	END  +  --   PIC X. 
	CASE WHEN  #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODPROFILO,3)  --   PIC X(03).
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3),3)
	END +
	CASE WHEN #tot_anagrafiche.codedaliaposition IS NULL
		THEN [dbo].[GetStringFormatted_r](CODPOSECON,2)   --   PIC X(02).
		ELSE [dbo].[GetStringFormatted_r](SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2),2)
	END +
	[dbo].[GetStringFormatted_r](STPCAP,2) +  --   PIC X(02). Numero dello stato di previsione dell’amministrazione nella Legge 
			-- di bilancio dello Stato per l’esercizio finanziario.Valori ammessi: spazi.
	[dbo].[GetStringFormatted_r](APPCAP,1) +  --    PIC X(01).Appendice dello stato di previsione dell’amministrazione nella Legge di bilancio dello Stato per l’esercizio finanziario.
			-- Valori ammessi: spazio.
	[dbo].[GetStringFormatted_r](NUMCAP,4) +  --   PIC X(04).
				
	-- Valori ammessi: 
	-- UNIV = MIUR - finanziamento ordinario Universita';
	-- OSSE = MIUR - finanziamento ordinario Osservatori;
	-- OSPE = Ospedaliere;
	-- ENTI = finanziamento da altri enti pubblici o privati;
	-- RICF - Ricerca finanziata (Montalcini, PRIN, FIRB, “Futuro e Ricerca” , ERC-VII PQ, SIR);
	-- FUAT - Fondo unico d'ateneo (Nota MIUR Prot. 8312 del 05/04/2013);
	-- spazi = negli altri casi. 
	-- N.B. Se il dipendente ha ricevuto nel periodo emolumenti riferibili a valori diversi di questo campo, devono essere prodotti records diversi. 

	[dbo].[GetStringFormatted_r](TIPOPAG,1) +  --    PIC X.
		-- Significato: Indicatore delle modalità di emissione della spesa per il pagamento delle competenze.
		-- Valori ammessi: ‘M’ = mandato;
		-- ‘R’ = ruolo di spesa fissa;
		-- ‘O’= ordine di accreditamento;
		-- ‘S’ = contabilità speciale.
	[dbo].[GetStringFormatted_r](PROVSERV,2) + -- PIC X(02). Sigla della provincia di servizio del dipendente.
	[dbo].[GetInt](CLASSE,4)   + -- PIC 9(04).Numero classi di stipendio maturate dal dipendente all'interno della qualifica di appartenenza.
	[dbo].[GetInt](SCATTI,4)   + -- PIC 9(04).Numero scatti di stipendio maturati dal dipendente all'interno della qualifica di appartenenza.
	[dbo].[GetStringFormatted_r](POSSTIP,6)  + -- PIC X(06).Posizione stipendiale (solo per il personale della scuola).
	-- TABVOCIECONOMICHE OCCURS 25. ?Significato: Tabella contenente i dati relativi alle voci economiche che compongono il cedolino; comprendono:
	-- competenze erogate (voci del trattamento economico fondamentale; indennità; compensi accessori);
	-- ritenute varie (riscatti, fitti, conguaglio fiscale, etc..); ad eccezione delle ritenute sindacali, previdenziali, assistenziali ed erariali che vengono comunicate in altri campi descritti nel seguito.

	-- La tabella contiene al massimo 25 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	-- Ogni elemento della tabella è costituito dai sottocampi che seguono.
	--[dbo].[GetStringFormatted_r](TABVOCIMENSCOMPET,6) + -- PIC X(6). Mensilità di competenza della voce economica (Anno/mese). Se non valorizzata, si intende uguale alla mensilità di liquidazione.
	--				   -- N.B. La mensilita' di competenza diversa da quella di liquidazione e' da utilizzare solo in casi particolari per evidenziare una cifra importante (es. stipendio) che viene pagata per intero con mesi di ritardo. I normali arretrati, anche di anni precedenti, vanno dichiarati come per il passato nel mese in cui vengono pagati, nel campo arretrati corrispondente. 
	--[dbo].[GetStringFormatted_r](TABVOCIECOCOD,4) +-- PIC X(4). Codice della voce economica. (VOCI DI SPESA PER COMPETENZE FISSE; INDENNITÀ; VOCI DI SPESA PER COMPETENZE ACCESSORIE).
	--			   -- Diverso da spazi se uno degli importi relativi è diverso da zero.
	 #tot_anagrafiche.stringacompensi_3_tranche +
	--[dbo].[GetStringFormatted_r](TABVOCIECOIMPBASE,1) +-- PIC +999999.99. Importo della voce economica. Per le competenze va riportata la sola voce base.
	--[dbo].[GetStringFormatted_r](TABVOCIECOARRCORR,1) +-- PIC +999999.99. Importo degli arretrati della voce economica relativi all’anno corrente. Da impostare solo per le competenze.
	--[dbo].[GetStringFormatted_r](TABVOCIECOARRPREC,1) +-- PIC +999999.99. Importo degli arretrati della voce economica relativi ad anni precedenti. Da impostare solo per le competenze.
	
	--[dbo].[GetStringFormatted_r](IRPEFCORRENTE,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sulle competenze base.
	--[dbo].[GetStringFormatted_r](IRPEFARRCORR,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi all'anno corrente.
	--[dbo].[GetStringFormatted_r](IRPEFARRPREC,10)	  +-- PIC +999999.99. Ritenuta fiscale effettuata sugli arretrati relativi ad anni precedenti.
	#tot_anagrafiche.stringaritenutefiscali_tranche_successive	  +
	--TABSINDACATO, -- OCCURS 3.
	-- Tabella contenente i dati relativi alle ritenute sindacali.
	-- La tabella contiene al massimo 3 elementi costituiti ciascuno dai sottocampi che seguono.

	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) +  + -- PIC +999999.99.Importo versato all’organizzazione sindacale.
	
	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) +  -- PIC +999999.99.Importo versato all’organizzazione sindacale.


	[dbo].[GetStringFormatted_r](TABSINDACATOMENSCOMPET,6) +-- PIC X(6). Mensilità di competenza della voce sindacale. Se non valorizzata, si intende uguale alla mensilità di liquidazione. 
	[dbo].[GetStringFormatted_r](TABSINDACATOCOD,11) +-- PIC X(11). Codice fiscale dell’organizzazione sindacale.
					 -- Diverso da spazi se il relativo importo risulta diverso da zero.
	'+' +  [dbo].GetDecimal_19_2(0,9) + -- PIC +999999.99.Importo versato all’organizzazione sindacale.


	--TABTRATTRAP, -- OCCURS 15. 
	--Tabella contenente i dati relativi alle contribuzioni previdenziali e assistenziali. 
	--La tabella contiene al massimo 15 elementi. Nel caso di superamento di tale limite si deve predisporre un ulteriore record per il dipendente. 
	--Ogni elemento è costituito dai sottocampi che seguono.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPMENSCOMPET,6) + -- PIC X(6). --Mensilità di competenza (Anno/mese) della voce. Se non valorizzata, si intende uguale alla mensilità di liquidazione. Se valorizzato solo l’anno, come mensilità si intende dicembre. L’anno di competenza può assumere valori minori dell’anno di liquidazione solo per contribuzioni relative a Fondo pensioni, Opera di Previdenza e Fondo Credito; in tali casi, le contribuzioni relative ad anni anteriori al 1996 dovranno essere comunicate con anno di competenza uguale a 1995. Per tutti gli altri tipi di contribuzione previdenziale e assistenziale l’anno di competenza è sempre uguale all’anno di liquidazione.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPCOD,3) + -- PIC X(3).Codice del contributo previdenziale/assistenziale .
	-- Diverso da spazi se il relativo importo è diverso da zero.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPIMP,1) +-- PIC +999999.99. Imponibile del contributo previdenziale/assistenziale.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPDIP,1) +-- PIC +999999.99. Importo delle trattenute a carico del dipendente.
	--[dbo].[GetStringFormatted_r](TABTRATTRAPAMM,1) +-- PIC +999999.99. Importo dei contributi a carico dell'amministrazione.
	[dbo].[GetStringFormatted_r](#tot_anagrafiche.stringaritenutenonfiscali_3_tranche,585) +
	[dbo].[GetInt](FAMASS,2) + -- PIC 9(02). Numero dei familiari ai fini dell'assegno.
	[dbo].[GetInt](FAMDETR,2) + -- PIC 9(02).Numero dei familiari ai fini delle detrazioni.
	-- [dbo].[GetStringFormatted_r](DETRAZ,1) +-- PIC +999999.99.Importo totale delle detrazioni d'imposta operate.
	'+' +  [dbo].GetDecimal_19_2(0,9) +
	[dbo].[GetInt](GGPRES,3) +-- PIC 9(03).Numero giorni effettivamente lavorati nel periodo di riferimento (dato valorizzato solo per i dipendenti della Pubblica Istruzione).
	CASE WHEN #tot_anagrafiche.record_aggiuntivi = 2   -- CAMPO ULTREC
		 THEN [dbo].[GetStringFormatted_r](0,1)  --- E' L'ULTIMO RECORD PER QUELL'ANAGRAFICA
	     ELSE [dbo].[GetStringFormatted_r](1,1)  --  SEGUONO ULTERIORI RECORD MA NON DOVREBE VERIFICARSI
	END 
	+-- PIC X. Indica se sono presenti più record per lo stesso dipendente
			-- Valori ammessi: '0' = il record è unico, oppure è l’ultimo record nel caso di più record per il dipendente;
			-- '1' = sono presenti ulteriori successivi record per il dipendente.
			-- Nel caso di più record per il dipendente, per superamento del limite previsto per le occorrenze della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP, in ciascun record successivo al primo vanno sempre impostati i seguenti campi:
			-- - TIPO-REC
			-- - CODFISC-DIP
			-- - COD-COMP
			-- - COD-SCOMP
			-- - COD-RUOLO
			-- - COD-PROFILO
			-- - COD-POSECON
			-- - STP-CAP
			-- - APP-CAP
			-- - NUM-CAP
			-- - TIPO-PAG
			-- - TAB-MENS-COMPET.  
			--oltre agli ulteriori elementi della tabella TAB-VOCI-ECONOMICHE e/o della tabella TAB-TRATT-RAP. 
	[dbo].[GetStringFormatted_r](FILLER,2) -- PIC X(2).
FROM #Record3
JOIN #tot_anagrafiche ON #tot_anagrafiche.idreg = #Record3.idreg
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,1,1) =	#Record3.CODRUOLO		 --	  PIC X. 
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,2,3) = #Record3.CODPROFILO		 --   PIC X(03).
AND SUBSTRING(#tot_anagrafiche.codedaliaposition,5,2) =	#Record3.CODPOSECON		 --   PIC X(02).
JOIN registry R ON #tot_anagrafiche.idreg = R.idreg
WHERE   #tot_anagrafiche.record_aggiuntivi = 2

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
 --select * from #tracciato
 -- select * from  #Record3

SELECT
    stringa as out_str
FROM #tracciato
ORDER BY  SUBSTRING (stringa, 1,62), ProgrTipoRec

END
GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


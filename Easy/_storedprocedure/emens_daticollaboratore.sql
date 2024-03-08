
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


if exists (select * from dbo.sysobjects where id = object_id(N'[emens_daticollaboratore]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [emens_daticollaboratore]
GO 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE        PROCEDURE [emens_daticollaboratore]
(
	@ycommunication int,
	@startmonth int,
	@stopmonth int,
	@parentsp char(1),  --'E' chiamata dalla procedura del calcolo dell'EMENS, 'X' chiamata dalla procedura di esportazione Excel
    @adate datetime
)
AS BEGIN

-- exec emens_daticollaboratore 2022, 1,1,'E', {ts '2022-02-01 00:00:00'}
CREATE TABLE #employ
(
	idreg int,
	cf_employ varchar(16),
	surname varchar(50)  COLLATE SQL_Latin1_General_CP1_CI_AS ,
	firstname varchar(50)   COLLATE SQL_Latin1_General_CP1_CI_AS,
	idemenscontractkind varchar(2) NULL,
	activitycode varchar(2),
	taxable decimal(19,2),
	employrate decimal(19,6) NOT NULL,
	idotherinsurance varchar(3),
	start smalldatetime,
	stop smalldatetime,
	citycode varchar(20),
	calamitycode varchar(2),
	certificationcode varchar(3),
	taxcode int,
	idexp int,
	ycommunication int,
	mcommunication int,
	servicemodule varchar(20),
	taxref varchar(20),
	esiste_DIS_COLL_N char(1)
) 

DECLARE @idemenscontractkind_PA varchar(2)
SET @idemenscontractkind_PA = '11' -- Per i COCOCO non pensionati

DECLARE @idemenscontractkind_PENS varchar(2)
SET @idemenscontractkind_PENS = '10' -- Per i COCOCO pensionati

DECLARE @activitycode varchar(2)
SET @activitycode = '17'

DECLARE @idotherinsurance varchar(3)
SET @idotherinsurance = '001'

DECLARE @validità_17_INPS_DIS_COLL_N datetime
--SELECT @validità_17_INPS_DIS_COLL_N = CONVERT(datetime, '01-06-'+ CONVERT(varchar(4), 2017), 105)	/* 01/06/2017 */
SELECT @validità_17_INPS_DIS_COLL_N = CONVERT(datetime, '01-01-'+ CONVERT(varchar(4), 2022), 105)	/* 01/01/2022 */

DECLARE @DataStart datetime
SELECT @DataStart = CONVERT(datetime, '01-'+ CONVERT(varchar(2), @startmonth)+'-'+ CONVERT(varchar(4), @ycommunication), 105)

-- Dati rilevati dal modulo PARASUBORDINATI
INSERT INTO #employ
(
	idreg,
	cf_employ,
	surname,
	firstname,
	idemenscontractkind,
	activitycode,
	taxable,
	employrate,
	idotherinsurance,
	start,
	stop,
	calamitycode,
	certificationcode,
	taxcode,
	idexp,
	ycommunication,
	mcommunication,
	servicemodule,
	taxref,
	esiste_DIS_COLL_N
)
SELECT 
	registry.idreg,
	registry.cf,
	registry.surname,
	registry.forename,
	parasubcontractview.idemenscontractkind,
	parasubcontractview.activitycode,
	expensetaxofficial.taxablenet,
	-- ISNULL(expensetaxofficial.employrate,0),
	-- A partire da 01/01/2022, la ritenuta 'INPS soggetti non mutuati' va comunicata con aliquota 35,33%  = 32,72 + 1,31
	-- ove 1.31 è l'aliquota della ritenuta 'INPS contributo DIS_COLL'
	case when (tax.taxref = '07_INPS_N') and (@DataStart >= @validità_17_INPS_DIS_COLL_N) and exists(select * from expensetaxofficial TO2 
																join tax T2 ON TO2.taxcode = T2.taxcode
																where TO2.idexp = expensetaxofficial.idexp and T2.taxref='17_INPS_DIS_COLL_N')
		then  ISNULL(expensetaxofficial.employrate,0) + 0.0131
		else  ISNULL(expensetaxofficial.employrate,0)
	End,
																
	parasubcontractview.idotherinsurance,
	payroll.start,
	payroll.stop,
	NULL,
	NULL, -- Nel caso si voglia valorizzare questo campo bisognerebbe aggiungere il valore 003 = Università
	expensetaxofficial.taxcode,
	paymentcommunicated.idexp,
	YEAR(paymentcommunicated.competencydate),
	MONTH(paymentcommunicated.competencydate),
	'COCOCO',
	tax.taxref,
	case when (tax.taxref = '07_INPS_N') and (@DataStart >= @validità_17_INPS_DIS_COLL_N)  and exists(select * from expensetaxofficial TO2 
															join tax T2 ON TO2.taxcode = T2.taxcode
															where TO2.idexp = expensetaxofficial.idexp and T2.taxref='17_INPS_DIS_COLL_N')
	then  'S'
	else  'N'
	End
FROM registry
JOIN parasubcontractview		ON registry.idreg = parasubcontractview.idreg
JOIN payroll					ON payroll.idcon = parasubcontractview.idcon
JOIN expensepayroll				ON payroll.idpayroll = expensepayroll.idpayroll
JOIN expenselink				ON expensepayroll.idexp = expenselink.idparent
JOIN paymentcommunicated		ON paymentcommunicated.idexp = expenselink.idchild
JOIN expensetaxofficial			ON expensetaxofficial.idexp = paymentcommunicated.idexp
JOIN tax						ON expensetaxofficial.taxcode = tax.taxcode
WHERE payroll.disbursementdate IS NOT NULL
	AND payroll.flagbalance = 'N'
--dicembre: tutti i mandati trasmessi a dicembre + quelli trasmessi l'anno dopo ma con cedolino di competenza quest'anno
--gennaio: tutti i mandati trasmessi a gennaio ma non con cedolino di competenza l'anno scorso
	AND payroll.fiscalyear = @ycommunication
	AND (		YEAR(paymentcommunicated.competencydate) = @ycommunication 
			AND MONTH(paymentcommunicated.competencydate) BETWEEN @startmonth AND @stopmonth
		OR YEAR(paymentcommunicated.competencydate) > @ycommunication
			AND @stopmonth = 12)
	AND tax.taxkind = 3 AND ( tax.taxref LIKE '%INPS%' )
	AND parasubcontractview.ayear = @ycommunication
	AND expensetaxofficial.taxablenet > 0
	AND (      
                ( @adate IS NULL AND expensetaxofficial.stop IS NULL)
-- Dettaglio originale non soggetto ad alcuna correzioni:
                OR 
                        (@adate IS NOT NULL AND expensetaxofficial.start IS NULL AND expensetaxofficial.stop IS NULL)
-- Ultima dettaglio / correzione valido
                OR
                        ( @adate IS NOT NULL 
                        AND
                        (expensetaxofficial.start is null OR expensetaxofficial.start<=@adate )
                        AND 
                       (expensetaxofficial.stop is null OR expensetaxofficial.stop>= @adate)
                        )
	)
	and tax.taxref<>'17_INPS_DIS_COLL_N'

-- Dati rilevati dal modulo OCCASIONALE
INSERT INTO #employ
(
	idreg,
	cf_employ,
	surname,
	firstname,
	idemenscontractkind,
	activitycode,
	taxable,
	employrate,
	idotherinsurance,
	start,
	stop,
	calamitycode,
	certificationcode,
	taxcode,
	idexp,
	ycommunication,
	mcommunication,
	servicemodule,
	taxref
)
SELECT 
	registry.idreg,
	registry.cf,
	registry.surname,
	registry.forename,
	casualcontractview.idemenscontractkind,
	casualcontractview.activitycode,
	expensetaxofficial.taxablenet,
	ISNULL(expensetaxofficial.employrate,0),
	casualcontractview.idotherinsurance,
	casualcontractview.start,
	casualcontractview.stop,
	NULL,
	NULL, -- Nel caso si voglia valorizzare questo campo bisognerebbe aggiungere il valore 003 = UniversitÃƒÂ 
	expensetaxofficial.taxcode,
	paymentcommunicated.idexp,
	YEAR(paymentcommunicated.competencydate),
	MONTH(paymentcommunicated.competencydate),
	'OCCASIONALE',
	tax.taxref
FROM registry
JOIN casualcontractview			ON registry.idreg = casualcontractview.idreg
JOIN expensecasualcontract		ON casualcontractview.ycon = expensecasualcontract.ycon
									AND casualcontractview.ncon = expensecasualcontract.ncon
JOIN expenselink				ON expensecasualcontract.idexp = expenselink.idparent
JOIN paymentcommunicated		ON paymentcommunicated.idexp = expenselink.idchild
JOIN expensetaxofficial			ON expensetaxofficial.idexp = paymentcommunicated.idexp
JOIN tax						ON expensetaxofficial.taxcode = tax.taxcode
WHERE YEAR(paymentcommunicated.competencydate) = @ycommunication
	AND MONTH(paymentcommunicated.competencydate) BETWEEN @startmonth AND @stopmonth
	AND tax.taxkind = 3 AND ( tax.taxref LIKE '%INPS%' )
	AND casualcontractview.ayear = @ycommunication
	AND expensetaxofficial.taxablenet > 0
	AND (     
                ( @adate IS NULL AND expensetaxofficial.stop IS NULL)
-- Dettaglio originale non soggetto ad alcuna correzioni:
                OR (@adate IS NOT NULL AND expensetaxofficial.start IS NULL AND expensetaxofficial.stop IS NULL)
-- Ultima dettaglio / correzione valido
                OR
                (@adate IS NOT NULL 
-- il dettaglio deve avere DataFine > della data in oggetto.        
                AND isnull(expensetaxofficial.stop,{ts '2079-01-01 00:00:00'}) > @adate
-- il dettaglio deve avere DataInzio = alla MAX(datainzio) dei dettagli validi alla data in oggetto
                AND ISNULL(expensetaxofficial.start,{ts '1900-01-01 00:00:00'}) 
                        = (SELECT ISNULL(MAX(ETO.start),{ts '1900-01-01 00:00:00'})
                		FROM expensetaxofficial ETO
                		WHERE ETO.idexp = expensetaxofficial.idexp
                                        AND ETO.taxcode = expensetaxofficial.taxcode
                                        AND ETO.nbracket = expensetaxofficial.nbracket
                			AND isnull(ETO.stop,{ts '2079-01-01 00:00:00'}) > @adate
                                        AND ETO.start<=@adate
                                        )
                )
	)


-- Dati rilevati dal modulo PROFESSIONALE
INSERT INTO #employ
(
	idreg,
	cf_employ,
	surname,
	firstname,
	idemenscontractkind,
	activitycode,
	taxable,
	employrate,
	idotherinsurance,
	start,
	stop,
	calamitycode,
	certificationcode,
	taxcode,
	idexp,
	ycommunication,
	mcommunication,
	servicemodule,
	taxref
)
SELECT 
	registry.idreg,
	registry.cf,
	registry.surname,
	registry.forename,
	null, --profserviceview.idemenscontractkind,
	null, --profserviceview.activitycode,
	expensetaxofficial.taxablenet,
	ISNULL(expensetaxofficial.employrate,0),
	null, --profserviceview.idotherinsurance,
	profserviceview.start,
	profserviceview.stop,
	NULL,
	NULL, -- Nel caso si voglia valorizzare questo campo bisognerebbe aggiungere il valore 003 = UniversitÃƒÂ 
	expensetaxofficial.taxcode,
	paymentcommunicated.idexp,
	YEAR(paymentcommunicated.competencydate),
	MONTH(paymentcommunicated.competencydate),
	'PROFESSIONALE',
	tax.taxref
FROM registry
JOIN profserviceview				ON registry.idreg = profserviceview.idreg
--JOIN expenseprofservice				ON profserviceview.ycon = expenseprofservice.ycon AND profserviceview.ncon = expenseprofservice.ncon
--JOIN expenselink					ON expenseprofservice.idexp = expenselink.idparent
join expenseinvoice					on profserviceview.idinvkind = expenseinvoice.idinvkind and profserviceview.yinv = expenseinvoice.yinv and profserviceview.ninv = expenseinvoice.ninv
JOIN paymentcommunicated			ON paymentcommunicated.idexp = expenseinvoice.idexp --expenselink.idchild
JOIN expensetaxofficial				ON expensetaxofficial.idexp = paymentcommunicated.idexp
JOIN tax
	ON expensetaxofficial.taxcode = tax.taxcode
WHERE YEAR(paymentcommunicated.competencydate) = @ycommunication
	AND MONTH(paymentcommunicated.competencydate) BETWEEN @startmonth AND @stopmonth
	AND tax.taxkind = 3 AND ( tax.taxref LIKE '%INPS%' )
	--AND casualcontractview.ayear = @ycommunication
	AND expensetaxofficial.taxablenet > 0
	AND (     
                ( @adate IS NULL AND expensetaxofficial.stop IS NULL)
-- Dettaglio originale non soggetto ad alcuna correzioni:
                OR (@adate IS NOT NULL AND expensetaxofficial.start IS NULL AND expensetaxofficial.stop IS NULL)
-- Ultima dettaglio / correzione valido
                OR
                (@adate IS NOT NULL 
-- il dettaglio deve avere DataFine > della data in oggetto.        
                AND isnull(expensetaxofficial.stop,{ts '2079-01-01 00:00:00'}) > @adate
-- il dettaglio deve avere DataInzio = alla MAX(datainzio) dei dettagli validi alla data in oggetto
                AND ISNULL(expensetaxofficial.start,{ts '1900-01-01 00:00:00'}) 
                        = (SELECT ISNULL(MAX(ETO.start),{ts '1900-01-01 00:00:00'})
                		FROM expensetaxofficial ETO
                		WHERE ETO.idexp = expensetaxofficial.idexp
                                        AND ETO.taxcode = expensetaxofficial.taxcode
                                        AND ETO.nbracket = expensetaxofficial.nbracket
                			AND isnull(ETO.stop,{ts '2079-01-01 00:00:00'}) > @adate
                                        AND ETO.start<=@adate
                                        )
                )
	)


DECLARE @idsorkind int
SElecT @idsorkind = idsorkind from sortingkind where codesorkind = 'EMENS'

DECLARE @oplevel varchar(2)
SELECT @oplevel = MIN(nlevel)
FROM sortinglevel WHERE idsorkind = @idsorkind
	AND (flag&2)<>0

DECLARE @len_noopcode int
SELECT @len_noopcode = SUM(flag/256) FROM sortinglevel
WHERE nlevel < @oplevel
	AND idsorkind = @idsorkind

DECLARE @len_opcode int
SELECT @len_opcode = flag/256 FROM sortinglevel
WHERE idsorkind = @idsorkind
	AND nlevel = @oplevel

DECLARE @isk_attivita int
SElecT @isk_attivita = idsorkind from sortingkind where codesorkind = 'EMENS2'

DECLARE @oplvl_emens2 varchar(2)
SELECT @oplvl_emens2 = MIN(nlevel)
	FROM sortinglevel WHERE idsorkind = @isk_attivita
	AND (flag&2)<>0

DECLARE @len_noopcode_emens2 int
SELECT @len_noopcode_emens2 = SUM(flag/256) FROM sortinglevel
	WHERE nlevel < @oplvl_emens2
	AND idsorkind = @isk_attivita

DECLARE @len_opcode_emens2 int
SELECT @len_opcode_emens2 = flag/256 FROM sortinglevel
	WHERE idsorkind = @isk_attivita
	AND nlevel = @oplvl_emens2

DECLARE @isk_rapporto int
SElecT @isk_rapporto = idsorkind from sortingkind where codesorkind = 'EMENS3'
DECLARE @oplvl_emens3 varchar(2)
SELECT @oplvl_emens3 = MIN(nlevel)
FROM sortinglevel WHERE idsorkind = @isk_rapporto
	AND (flag&2)<>0

DECLARE @len_noopcode_emens3 int
SELECT @len_noopcode_emens3 = SUM(flag/256) FROM sortinglevel
WHERE nlevel < @oplvl_emens3
	AND idsorkind = @isk_rapporto

DECLARE @len_opcode_emens3 int
SELECT @len_opcode_emens3 = flag/256 FROM sortinglevel
WHERE idsorkind = @isk_rapporto
	AND nlevel = @oplvl_emens3

DECLARE @epsilon decimal(19,2)
SET @epsilon = 0.01

-- Dati rilevati dal modulo SPESA
INSERT INTO #employ
(
	idreg,
	cf_employ,
	surname,
	firstname,
	idemenscontractkind,
	activitycode,
	taxable,
	employrate,
	idotherinsurance,
	start,
	stop,
	calamitycode,
	certificationcode,
	taxcode,
	idexp,
	ycommunication,
	mcommunication,
	servicemodule,
	taxref
)
SELECT 
	registry.idreg,
	registry.cf,
	registry.surname,
	registry.forename,
	-- Calcolo idemenscontractkind
	CASE
		WHEN
			(SELECT COUNT(*)
			FROM registrysorting
			JOIN sorting
				ON registrysorting.idsor = sorting.idsor
			WHERE sorting.idsorkind = @isk_rapporto
				AND registrysorting.idreg = paymentcommunicated.idreg
				AND SUBSTRING(sorting.sortcode,1,4) = CONVERT(varchar(4),@ycommunication)) = 1
		THEN
			(SELECT SUBSTRING(sorting.sortcode, @len_noopcode_emens3 + 1, @len_opcode_emens3)
			FROM sorting
			JOIN registrysorting
				ON registrysorting.idsor = sorting.idsor
			WHERE sorting.idsorkind = @isk_rapporto
				AND registrysorting.idreg = paymentcommunicated.idreg
				AND SUBSTRING(sorting.sortcode,1,4) = CONVERT(varchar(4),@ycommunication))
		ELSE
			CASE
				WHEN service.module = 'OCCASIONALE' THEN '09'
				WHEN service.module = 'COCOCO'
					THEN 
					CASE
						WHEN tax.taxref = '07_INPS_P' THEN '10'
						ELSE '11'
					END
			END
	END,
	CASE
		WHEN service.module = 'COCOCO' THEN
			case when (SELECT count(*)
				FROM sorting
				JOIN registrysorting
					ON registrysorting.idsor = sorting.idsor
				WHERE sorting.idsorkind = @isk_attivita
					AND registrysorting.idreg = paymentcommunicated.idreg
					AND SUBSTRING(sorting.sortcode,1,4) = CONVERT(varchar(4),@ycommunication))=1
			then isnull((SELECT SUBSTRING(sorting.sortcode, @len_noopcode_emens2 + 1, @len_opcode_emens2)
				FROM sorting
				JOIN registrysorting
					ON registrysorting.idsor = sorting.idsor
				WHERE sorting.idsorkind = @isk_attivita
					AND registrysorting.idreg = paymentcommunicated.idreg
					AND SUBSTRING(sorting.sortcode,1,4) = CONVERT(varchar(4),@ycommunication)),'17')
			else '17'
			end
		ELSE NULL
	END,
	ISNULL(expensetaxofficial.taxablenet,0),
	ROUND(
		ISNULL(expensetaxofficial.employrate,
			(ISNULL(expensetaxofficial.employtax,0) + ISNULL(expensetaxofficial.admintax,0)) /
			ISNULL(expensetaxofficial.taxablenet,1)
		)
	,4),
	-- Calcolo della forma assicurativa
	CASE
		WHEN tax.taxref = '07_INPS_P' THEN '002' 
		WHEN 
		ROUND(
			ISNULL(expensetaxofficial.employrate,
				(ISNULL(expensetaxofficial.employtax,0) + ISNULL(expensetaxofficial.admintax,0)) /
				ISNULL(expensetaxofficial.taxablenet,1)
			)
		,4) BETWEEN (0.16 - @epsilon) AND (0.16 + @epsilon)
			THEN
				(SELECT 
				SUBSTRING(
					SUBSTRING(sorting.sortcode,@len_noopcode + 1,@len_opcode)
				,3,3)
				FROM registrysorting
				JOIN sorting
				ON sorting.idsor = registrysorting.idsor
				WHERE SUBSTRING(sorting.sortcode,1,2) = SUBSTRING(CONVERT(VARCHAR(4),@ycommunication),3,2)
				AND registrysorting.idreg = paymentcommunicated.idreg
				AND sorting.idsorkind = @idsorkind)
	END,
	ISNULL(paymentcommunicated.servicestart,paymentcommunicated.adate),
	ISNULL(paymentcommunicated.servicestop,paymentcommunicated.adate),
	NULL,
	NULL, -- Nel caso si voglia valorizzare questo campo bisognerebbe aggiungere il valore 003 = Università 
	expensetaxofficial.taxcode,
	paymentcommunicated.idexp,
	YEAR(paymentcommunicated.competencydate),
	MONTH(paymentcommunicated.competencydate),
	service.module,
	tax.taxref
FROM expensetaxofficial
JOIN paymentcommunicated
	ON expensetaxofficial.idexp = paymentcommunicated.idexp
JOIN registry
	ON registry.idreg = paymentcommunicated.idreg
JOIN registryclass
	ON registryclass.idregistryclass = registry.idregistryclass
JOIN tax
	ON tax.taxcode = expensetaxofficial.taxcode
JOIN service
	ON service.idser = paymentcommunicated.idser
WHERE tax.taxkind = 3
	AND( tax.taxref LIKE '%INPS%')
	AND service.module IN ('COCOCO','OCCASIONALE')
--per i cococo se il pagamento è stato trasmesso nell'anno x e isnull(expenselast.servicestart, paymenttransmission.transmissiondate) è < x 
--allora va inserito nell'emens di dicembre dell'anno x-1; altrimenti vale il mese della data di trasmissione del mandato.
--Per gli occasionali vale solo il mese della data di trasmissione
	AND (	YEAR(paymentcommunicated.competencydate) = @ycommunication
		AND MONTH(paymentcommunicated.competencydate) BETWEEN @startmonth AND @stopmonth
		AND (service.module <> 'COCOCO'
			or paymentcommunicated.competencydate >= dateadd(yy, @ycommunication-2000, {d '2000-01-13'})
			or paymentcommunicated.servicestart is null
			or year(paymentcommunicated.servicestart) = @ycommunication)
		OR service.module = 'COCOCO'
			and @stopmonth = 12
			and isnull(year(paymentcommunicated.servicestart), @ycommunication) = @ycommunication
			and datediff(d, dateadd(yy, @ycommunication-2000, {d '2001-01-01'}), paymentcommunicated.competencydate)
				between 0 and 11
	)
	AND NOT EXISTS (SELECT * FROM expensepayroll 
				JOIN expenselink
					ON expensepayroll.idexp = expenselink.idparent
			WHERE paymentcommunicated.idexp = expenselink.idchild )
	AND NOT EXISTS (SELECT * FROM expensecasualcontract
				JOIN expenselink
					ON expensecasualcontract.idexp = expenselink.idparent
			WHERE paymentcommunicated.idexp = expenselink.idchild )
	-- Escludo i creditori con tipologia MANDATI COLLETTIVI e i creditori che hanno un ruolo MANDATI COLLETTIVI
	AND registry.idregistryclass <> '10'
	AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = paymentcommunicated.idreg) 
	AND ISNULL(expensetaxofficial.taxablenet,0) > 0
	AND (      
                ( @adate IS NULL AND expensetaxofficial.stop IS NULL)
-- Dettaglio originale non soggetto ad alcuna correzioni:
                OR (@adate IS NOT NULL AND expensetaxofficial.start IS NULL AND expensetaxofficial.stop IS NULL)
-- Ultima dettaglio / correzione valido
                OR
                (@adate IS NOT NULL 
-- il dettaglio deve avere DataFine > della data in pggetto.        
                AND isnull(expensetaxofficial.stop,{ts '2079-01-01 00:00:00'}) > @adate
-- il dettaglio deve avere DataInzio = alla MAX(datainzio) dei dettagli validi alla data in oggetto
                AND ISNULL(expensetaxofficial.start,{ts '1900-01-01 00:00:00'}) 
                        = (SELECT ISNULL(MAX(ETO.start),{ts '1900-01-01 00:00:00'})
                		FROM expensetaxofficial ETO
                		WHERE ETO.idexp = expensetaxofficial.idexp
                                        AND ETO.taxcode = expensetaxofficial.taxcode
                                        AND ETO.nbracket = expensetaxofficial.nbracket
                			AND isnull(ETO.stop,{ts '2079-01-01 00:00:00'}) > @adate
                                        AND ETO.start<=@adate
                                        )
                )
	)

update #employ set 
	activitycode=null
	from emenscontractkind
	where emenscontractkind.idemenscontractkind=#employ.idemenscontractkind
	and emenscontractkind.ayear=@ycommunication
	and emenscontractkind.flagactivityrequested='N'

-- Impostazione del CodiceComune
DECLARE @idagency int
DECLARE @idcode int

SET @idagency = 1
SET @idcode = 1

--CREATE TABLE #distinct_reg (idreg int, start datetime)

--INSERT INTO #distinct_reg (idreg, start)
--SELECT DISTINCT idreg, start FROM #employ



UPDATE #employ SET citycode = (SELECT value FROM geo_city_agency WHERE idagency = @idagency AND idcode = @idcode 
                                AND idcity = ( SELECT idcity from license))

DECLARE @maxlensurname int
DECLARE @maxlenfirstname int
SET @maxlensurname = 30
SET @maxlenfirstname = 20
UPDATE #employ SET surname =
	SUBSTRING(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	surname,
	'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'$',' '),
	'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
	':',' '),';',' '),'<',' '),'=',' '),'>',' '),'?',' '),']',' '),'_',' '),'`',' '),'{',' '),'}',' '),'~',' '),
	'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),
	'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),'õ','o'),'ý','y'),
	'é','e'''),'à','a'''),'è','e'''),'ì','i'''),'ò','o'''),'ù','u'''),'á','a'''),'í','i'''),'ó','o'''),'É','e'''),
	'Á','a'''),'À','a'''),'È','e'''),'Í','i'''),'Ì','i'''),'Ó','o'''),'Ò','o'''),'Ú','u'''),'Ù','u'''),
	1,@maxlensurname),
	firstname = 
	SUBSTRING(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	firstname,
	'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'$',' '),
	'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
	':',' '),';',' '),'<',' '),'=',' '),'>',' '),'?',' '),']',' '),'_',' '),'`',' '),'{',' '),'}',' '),'~',' '),
	'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),
	'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),'õ','o'),'ý','y'),
	'é','e'''),'à','a'''),'è','e'''),'ì','i'''),'ò','o'''),'ù','u'''),'á','a'''),'í','i'''),'ó','o'''),'É','e'''),
	'Á','a'''),'À','a'''),'È','e'''),'Í','i'''),'Ì','i'''),'Ó','o'''),'Ò','o'''),'Ú','u'''),'Ù','u'''),
	1,@maxlenfirstname)

DECLARE @departmentname varchar(500)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' and 
				(start is null or start <= @adate) and
				(stop is null or stop >= @adate)
				),'Manca Cfg. Parametri Tutte le stampe')


-- Da decommentare, eventualmente, in futuro.
-- delete from #employ where taxref = '17_INPS_DIS_COLL_N' -- task 11241, è stata implementata, ma al momento non si sa ancora come gestirla per cui la togliamo dall'outptu altrimenti impedisce la gerazione dell'Emens

IF @parentsp = 'E'
BEGIN
	SELECT  @departmentname as departmentname,
		cf_employ,
		surname,
		firstname,
		idemenscontractkind,
		activitycode,
		SUM(taxable),
		employrate,
		idotherinsurance,
		MIN(start),
		MAX(stop),
		citycode,
		calamitycode,
		certificationcode,
		 servicemodule,
		taxref,
		isnull(esiste_DIS_COLL_N,'N') as esiste_DIS_COLL_N
	FROM #employ
	GROUP BY 
	cf_employ,surname,firstname,idemenscontractkind,activitycode,employrate,idotherinsurance,
	calamitycode,certificationcode, citycode, servicemodule,
		taxref,esiste_DIS_COLL_N
END
IF @parentsp = 'X'
BEGIN
	SELECT
        @departmentname as departmentname,
		#employ.idreg,
		#employ.cf_employ,
		#employ.surname,
		#employ.firstname,
		#employ.idemenscontractkind,
		#employ.activitycode,
		#employ.taxable,
		#employ.employrate,
		#employ.idotherinsurance,
		#employ.start,
		#employ.stop,
		--#employ.citycode,
		#employ.calamitycode,
		#employ.certificationcode,
		#employ.taxcode,
		#employ.idexp,
		#employ.ycommunication,
		#employ.mcommunication,
                tax.description as tax,
                paymentcommunicated.ymov,
                paymentcommunicated.nmov, 
                expensephase.description as expensephase,
                service.idser,
                service.description as service,       
        	paymentcommunicated.ypay,
	        paymentcommunicated.npay,
        	paymentcommunicated.ypaymenttransmission,
        	paymentcommunicated.npaymenttransmission,
	        paymentcommunicated.competencydate 
	FROM #employ
        JOIN expenselast
                ON #employ.idexp = expenselast.idexp                
        JOIN tax
        	ON #employ.taxcode = tax.taxcode
        JOIN service
        	ON service.idser = expenselast.idser
        JOIN expense
        	ON #employ.idexp = expense.idexp   
        JOIN expensephase
        	ON expensephase.nphase = expense.nphase
        LEFT OUTER JOIN paymentcommunicated
        	ON #employ.idexp = paymentcommunicated.idexp
        ORDER BY ycommunication,mcommunication
END
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

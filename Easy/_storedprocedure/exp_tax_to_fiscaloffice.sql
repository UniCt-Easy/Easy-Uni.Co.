
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_tax_to_fiscaloffice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_tax_to_fiscaloffice]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE [exp_tax_to_fiscaloffice]
(
	@start datetime,
	@stop datetime,
	@ayear int,
	@registry varchar(100),
	@unified varchar(1),
	@idser int
)
AS BEGIN

/* Versione 1.0.1 del 02/07/2008 ultima modifica: GIUSEPPE */

CREATE TABLE #tmpstr (DROPstr varchar(4000))
	
CREATE TABLE #movement
(
	nmov int,
	ymov int,
	registry varchar(100),
	idreg int,
	cf varchar(100),
	surname varchar(50),
	forename varchar(50),
	birthdate datetime,
	birthplace varchar(65),
	birthprovince varchar(2),
	birthnation varchar(65),
	sex char(1),
	idser int,
	desc_exp varchar(150),
	servicestart datetime,
	servicestop datetime,
	taxref varchar(20),
	taxcode  int,

	employtax_liq_periodo decimal(19,2),    --A
	admintax_liq_periodo decimal(19,2),     --A
	employtax_operate_prec decimal(19,2),   --B
	admintax_operate_prec decimal(19,2),    --B
	employtax_non_liq decimal(19,2),        --C
	admintax_non_liq decimal(19,2),         --C

	address varchar(150),
	location varchar(65),
	province varchar(2),
	nation varchar(65),
	cap varchar(20),
	fiscaltaxcity varchar(65),
	fiscaltaxregion varchar(50),
)

CREATE TABLE #link_tax
(
	npos int,
	taxcode int,
	var_name varchar(20)
)
DECLARE @index int
SET @index = 1
	
DECLARE @taxcode  int
DECLARE tax_crs INSENSITIVE CURSOR FOR
SELECT DISTINCT ISNULL(tax.maintaxcode,tax.taxcode) FROM tax
FOR READ ONLY
OPEN tax_crs
FETCH NEXT FROM tax_crs INTO @taxcode
WHILE (@@FETCH_STATUS = 0)
BEGIN
	DECLARE @str_index varchar(20)
	SET @str_index = CONVERT(varchar(20),@index)

	INSERT INTO #link_tax (npos, taxcode, var_name)
	SELECT @index, @taxcode, 'A' + @str_index FROM tax WHERE taxcode = @taxcode
	SET @index = @index + 1
	FETCH NEXT FROM tax_crs INTO @taxcode	
	
END

CLOSE tax_crs

DEALLOCATE tax_crs
UPDATE #link_tax SET var_name = REPLACE(var_name,'%','')

-- Informazioni da EXPENSETAX
/*      
A) rit. operate e liquidate del periodo : le ritenute + correzioni incluse nelle LIQUIDAZIONI RITENUTE che includono 
il periodo selezionato.
*/
INSERT INTO #movement
(
	nmov, ymov, registry,
	idreg, cf, surname, forename,
	birthdate, birthplace, birthprovince, birthnation,
	sex, idser, desc_exp,
	servicestart, servicestop,
	taxref, 

	employtax_liq_periodo,
	admintax_liq_periodo,

	fiscaltaxcity, fiscaltaxregion
)
SELECT
	E.nmov ,E.ymov, R.title, 
	R.idreg,coalesce(R.cf, R.foreigncf, R.title), R.surname, R.forename,
	R.birthdate, GC.title, GP.province, ISNULL(GN.title,'ITALIA'),
	R.gender,EL.idser, E.description,
	EL.servicestart,EL.servicestop,
	#link_tax.var_name,
	tab.employtax,tab.admintax,
	GC_rit.title, F.title
FROM 
	(SELECT
		ISNULL(SUM(ETV.employtax),0) AS employtax,
		ISNULL(SUM(ETV.admintax),0) AS admintax,
		ETV.idexp,
		ISNULL(T.maintaxcode,T.taxcode) as taxcode,
		E1.idreg,
		ETV.idcity,
		ETV.idfiscaltaxregion
	FROM expensetaxview AS ETV
	JOIN expense E1
		ON E1.idexp = ETV.idexp
	JOIN expenselast EL1
		ON E1.idexp = EL1.idexp
         JOIN taxpay
                ON taxpay.ytaxpay = ETV.ytaxpay
                AND taxpay.ntaxpay = ETV.ntaxpay
                AND taxpay.taxcode = ETV.taxcode
	LEFT OUTER JOIN tax T		
		ON ETV.taxcode = T.taxcode
	WHERE E1.ymov = @ayear
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND ETV.datetaxpay BETWEEN @start AND @stop -- operata nel periodo
		AND (EL1.idser = @idser OR @idser is null)
	GROUP BY E1.idreg,ETV.idexp,ISNULL(T.maintaxcode,T.taxcode), ETV.idcity, ETV.idfiscaltaxregion) 
AS tab
JOIN registry R
	ON R.idreg = tab.idreg
JOIN expense E
	ON E.idexp = tab.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = R.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = R.idnation
LEFT OUTER JOIN geo_city GC_rit
	ON GC_rit.idcity = tab.idcity
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = tab.idfiscaltaxregion
JOIN #link_tax 
	ON tab.taxcode = #link_tax.taxcode
WHERE R.title LIKE @registry
ORDER BY E.nmov

-- Informazioni da EXPENSETAXCORRIGE
INSERT INTO #movement
(
	nmov, ymov, registry,
	idreg, cf, surname, forename,
	birthdate, birthplace, birthprovince, birthnation,
	sex, idser, desc_exp,
	servicestart, servicestop,
	taxref,
	employtax_liq_periodo,-- A
        admintax_liq_periodo,  -- A
	fiscaltaxcity, fiscaltaxregion
)
SELECT
	E.nmov ,E.ymov, R.title, 
	R.idreg,coalesce(R.cf, R.foreigncf, R.title), R.surname, R.forename,
	R.birthdate, GC.title, GP.province, ISNULL(GN.title,'ITALIA'),
	R.gender,EL.idser, E.description,
	EL.servicestart,EL.servicestop,
	#link_tax.var_name,
	tab.employtax,tab.admintax,
	GC_rit.title, F.title
FROM 
	(SELECT
		ISNULL(SUM(ETV.employamount),0) AS employtax,
		ISNULL(SUM(ETV.adminamount),0) AS admintax,
		ETV.idexp,
		ISNULL(T.maintaxcode,T.taxcode) as taxcode,
		E1.idreg,
		ETV.idcity, ETV.idfiscaltaxregion
	FROM expensetaxcorrigeview AS ETV
	JOIN expense E1
		ON E1.idexp = ETV.idexp
	JOIN expenselast EL1
		ON E1.idexp = EL1.idexp
         JOIN taxpay
                ON taxpay.ytaxpay = ETV.ytaxpay
                AND taxpay.ntaxpay = ETV.ntaxpay
                AND taxpay.taxcode = ETV.taxcode
	LEFT OUTER JOIN tax T		
		ON ETV.taxcode = T.taxcode
	WHERE E1.ymov = @ayear
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND ETV.adate BETWEEN @start AND @stop -- operata nel periodo
		AND (EL1.idser = @idser OR @idser is null)
	GROUP BY E1.idreg,ETV.idexp,ISNULL(T.maintaxcode,T.taxcode),
		ETV.idcity, ETV.idfiscaltaxregion) 
AS tab
JOIN registry R
	ON R.idreg = tab.idreg
JOIN expense E
	ON E.idexp = tab.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = R.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = R.idnation
LEFT OUTER JOIN geo_city GC_rit
	ON GC_rit.idcity = tab.idcity
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = tab.idfiscaltaxregion
JOIN #link_tax 
	ON tab.taxcode = #link_tax.taxcode
WHERE R.title LIKE @registry
ORDER BY E.nmov

/*
B) rit. operate in periodi precedenti e liquidate nel periodo
*/
INSERT INTO #movement
(
	nmov, ymov, registry,
	idreg, cf, surname, forename,
	birthdate, birthplace, birthprovince, birthnation,
	sex, idser, desc_exp,
	servicestart, servicestop,
	taxref, 

	employtax_operate_prec, -- B
        admintax_operate_prec, -- B

	fiscaltaxcity, fiscaltaxregion
)
SELECT
	E.nmov ,E.ymov, R.title, 
	R.idreg,coalesce(R.cf, R.foreigncf, R.title), R.surname, R.forename,
	R.birthdate, GC.title, GP.province, ISNULL(GN.title,'ITALIA'),
	R.gender,EL.idser, E.description,
	EL.servicestart,EL.servicestop,
	#link_tax.var_name,
	tab.employtax,tab.admintax,
	GC_rit.title, F.title
FROM 
	(SELECT
		ISNULL(SUM(ETV.employtax),0) AS employtax,
		ISNULL(SUM(ETV.admintax),0) AS admintax,
		ETV.idexp,
		ISNULL(T.maintaxcode,T.taxcode) as taxcode,
		E1.idreg,
		ETV.idcity,
		ETV.idfiscaltaxregion
	FROM expensetaxview AS ETV
	JOIN expense E1
		ON E1.idexp = ETV.idexp
	JOIN expenselast EL1
		ON E1.idexp = EL1.idexp
         JOIN taxpay
                ON taxpay.ytaxpay = ETV.ytaxpay
                AND taxpay.ntaxpay = ETV.ntaxpay
                AND taxpay.taxcode = ETV.taxcode
	LEFT OUTER JOIN tax T		
		ON ETV.taxcode = T.taxcode
	WHERE E1.ymov = @ayear
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND ETV.datetaxpay < @start -- operata nel periodo precedente 
		AND (EL1.idser = @idser OR @idser is null)
	GROUP BY E1.idreg,ETV.idexp,ISNULL(T.maintaxcode,T.taxcode), ETV.idcity, ETV.idfiscaltaxregion) 
AS tab
JOIN registry R
	ON R.idreg = tab.idreg
JOIN expense E
	ON E.idexp = tab.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = R.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = R.idnation
LEFT OUTER JOIN geo_city GC_rit
	ON GC_rit.idcity = tab.idcity
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = tab.idfiscaltaxregion
JOIN #link_tax 
	ON tab.taxcode = #link_tax.taxcode
WHERE R.title LIKE @registry
ORDER BY E.nmov

-- Informazioni da EXPENSETAXCORRIGE
INSERT INTO #movement
(
	nmov, ymov, registry,
	idreg, cf, surname, forename,
	birthdate, birthplace, birthprovince, birthnation,
	sex, idser, desc_exp,
	servicestart, servicestop,
	taxref,
	employtax_operate_prec, -- B
        admintax_operate_prec, -- B
	fiscaltaxcity, fiscaltaxregion
)
SELECT
	E.nmov ,E.ymov, R.title, 
	R.idreg,coalesce(R.cf, R.foreigncf, R.title), R.surname, R.forename,
	R.birthdate, GC.title, GP.province, ISNULL(GN.title,'ITALIA'),
	R.gender,EL.idser, E.description,
	EL.servicestart,EL.servicestop,
	#link_tax.var_name,
	tab.employtax,tab.admintax,
	GC_rit.title, F.title
FROM 
	(SELECT
		ISNULL(SUM(ETV.employamount),0) AS employtax,
		ISNULL(SUM(ETV.adminamount),0) AS admintax,
		ETV.idexp,
		ISNULL(T.maintaxcode,T.taxcode) as taxcode,
		E1.idreg,
		ETV.idcity, ETV.idfiscaltaxregion
	FROM expensetaxcorrigeview AS ETV
	JOIN expense E1
		ON E1.idexp = ETV.idexp
	JOIN expenselast EL1
		ON E1.idexp = EL1.idexp
         JOIN taxpay
                ON taxpay.ytaxpay = ETV.ytaxpay
                AND taxpay.ntaxpay = ETV.ntaxpay
                AND taxpay.taxcode = ETV.taxcode
	LEFT OUTER JOIN tax T		
		ON ETV.taxcode = T.taxcode
	WHERE E1.ymov = @ayear
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND ETV.adate < @start -- operata nel periodo precedente 
		AND (EL1.idser = @idser OR @idser is null)
	GROUP BY E1.idreg,ETV.idexp,ISNULL(T.maintaxcode,T.taxcode),
		ETV.idcity, ETV.idfiscaltaxregion) 
AS tab
JOIN registry R
	ON R.idreg = tab.idreg
JOIN expense E
	ON E.idexp = tab.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = R.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = R.idnation
LEFT OUTER JOIN geo_city GC_rit
	ON GC_rit.idcity = tab.idcity
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = tab.idfiscaltaxregion
JOIN #link_tax 
	ON tab.taxcode = #link_tax.taxcode
WHERE R.title LIKE @registry
ORDER BY E.nmov


/*
C) rit. operate nel periodo e non liquidate NEL PERIODO
*/
INSERT INTO #movement
(
	nmov, ymov, registry,
	idreg, cf, surname, forename,
	birthdate, birthplace, birthprovince, birthnation,
	sex, idser, desc_exp,
	servicestart, servicestop,
	taxref, 

	employtax_non_liq,--C
        admintax_non_liq, --C

	fiscaltaxcity, fiscaltaxregion
)
SELECT
	E.nmov ,E.ymov, R.title, 
	R.idreg,coalesce(R.cf, R.foreigncf, R.title), R.surname, R.forename,
	R.birthdate, GC.title, GP.province, ISNULL(GN.title,'ITALIA'),
	R.gender,EL.idser, E.description,
	EL.servicestart,EL.servicestop,
	#link_tax.var_name,
	tab.employtax,tab.admintax,
	GC_rit.title, F.title
FROM 
	(SELECT
		ISNULL(SUM(ETV.employtax),0) AS employtax,
		ISNULL(SUM(ETV.admintax),0) AS admintax,
		ETV.idexp,
		ISNULL(T.maintaxcode,T.taxcode) as taxcode,
		E1.idreg,
		ETV.idcity,
		ETV.idfiscaltaxregion
	FROM expensetaxview AS ETV
	JOIN expense E1
		ON E1.idexp = ETV.idexp
	JOIN expenselast EL1
		ON E1.idexp = EL1.idexp
	LEFT OUTER JOIN tax T		
		ON ETV.taxcode = T.taxcode
	WHERE E1.ymov = @ayear
                AND ETV.datetaxpay BETWEEN @start AND @stop  -- operata nel periodo 
                AND NOT EXISTS-- NON liquidata nel periodo
                      ( SELECT * FROM taxpay
                        WHERE taxpay.ytaxpay = ETV.ytaxpay
                        AND taxpay.ntaxpay = ETV.ntaxpay
                        AND taxpay.taxcode = ETV.taxcode
                        AND (taxpay.start BETWEEN @start AND @stop
                                OR taxpay.stop BETWEEN @start AND @stop
                                OR @start BETWEEN taxpay.start AND taxpay.stop
                                OR @stop BETWEEN taxpay.start AND taxpay.stop)
                        )	
                AND (EL1.idser = @idser OR @idser is null)
	GROUP BY E1.idreg,ETV.idexp,ISNULL(T.maintaxcode,T.taxcode), ETV.idcity, ETV.idfiscaltaxregion) 
AS tab
JOIN registry R
	ON R.idreg = tab.idreg
JOIN expense E
	ON E.idexp = tab.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = R.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = R.idnation
LEFT OUTER JOIN geo_city GC_rit
	ON GC_rit.idcity = tab.idcity
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = tab.idfiscaltaxregion
JOIN #link_tax 
	ON tab.taxcode = #link_tax.taxcode
WHERE R.title LIKE @registry
ORDER BY E.nmov

-- Informazioni da EXPENSETAXCORRIGE
INSERT INTO #movement
(
	nmov, ymov, registry,
	idreg, cf, surname, forename,
	birthdate, birthplace, birthprovince, birthnation,
	sex, idser, desc_exp,
	servicestart, servicestop,
	taxref,
	employtax_non_liq,--C
        admintax_non_liq, --C
	fiscaltaxcity, fiscaltaxregion
)
SELECT
	E.nmov ,E.ymov, R.title, 
	R.idreg,coalesce(R.cf, R.foreigncf, R.title), R.surname, R.forename,
	R.birthdate, GC.title, GP.province, ISNULL(GN.title,'ITALIA'),
	R.gender,EL.idser, E.description,
	EL.servicestart,EL.servicestop,
	#link_tax.var_name,
	tab.employtax,tab.admintax,
	GC_rit.title, F.title
FROM 
	(SELECT
		ISNULL(SUM(ETV.employamount),0) AS employtax,
		ISNULL(SUM(ETV.adminamount),0) AS admintax,
		ETV.idexp,
		ISNULL(T.maintaxcode,T.taxcode) as taxcode,
		E1.idreg,
		ETV.idcity, ETV.idfiscaltaxregion
	FROM expensetaxcorrigeview AS ETV
	JOIN expense E1
		ON E1.idexp = ETV.idexp
	JOIN expenselast EL1
		ON E1.idexp = EL1.idexp
	LEFT OUTER JOIN tax T		
		ON ETV.taxcode = T.taxcode
	WHERE E1.ymov = @ayear
            AND NOT EXISTS -- NON liquidata nel periodo 
              (SELECT * FROM taxpay
               WHERE taxpay.ytaxpay = ETV.ytaxpay
                AND taxpay.ntaxpay = ETV.ntaxpay
                AND taxpay.taxcode = ETV.taxcode
                AND ( taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop)
                )
		AND ETV.adate BETWEEN @start AND @stop -- operata nel periodo
		AND (EL1.idser = @idser OR @idser is null)
	GROUP BY E1.idreg,ETV.idexp,ISNULL(T.maintaxcode,T.taxcode),
		ETV.idcity, ETV.idfiscaltaxregion) 
AS tab
JOIN registry R
	ON R.idreg = tab.idreg
JOIN expense E
	ON E.idexp = tab.idexp
JOIN expenselast EL
	ON E.idexp = EL.idexp
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = R.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = R.idnation
LEFT OUTER JOIN geo_city GC_rit
	ON GC_rit.idcity = tab.idcity
LEFT OUTER JOIN fiscaltaxregion F
	ON F.idfiscaltaxregion = tab.idfiscaltaxregion
JOIN #link_tax 
	ON tab.taxcode = #link_tax.taxcode
WHERE R.title LIKE @registry
ORDER BY E.nmov


CREATE TABLE #employ (idreg int)
	
INSERT INTO #employ (idreg)
SELECT DISTINCT idreg FROM #movement

-- Gestione degli indirizzi
CREATE TABLE #address_employ
(
	idreg int,
	idaddresskind int,
	address varchar(100),
	location varchar(120),
	cap varchar(20),
	province varchar(2),
	nation varchar(65),
)
	
DECLARE @dateindi datetime
SELECT @dateindi = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

INSERT INTO #address_employ
(
	idreg,
	idaddresskind,
	address,
	location,
	cap,
	province,
	nation
)
SELECT 
	RA.idreg,
	RA.idaddresskind,
	RA.address,
	ISNULL(GC.title,'') + ' ' + ISNULL(RA.location,''),
	RA.cap,
	GP.province,
	ISNULL(GN.title,'ITALIA') 
FROM registryaddress RA     
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = RA.idcity
LEFT OUTER JOIN geo_country GP
	ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN
	ON GN.idnation = RA.idnation
JOIN #employ
	ON #employ.idreg = RA.idreg
WHERE  RA.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = RA.idaddresskind
--		AND cdi.active <>'N' 
		AND cdi.start <= @dateindi
		AND cdi.idreg = RA.idreg)--)
	
DELETE #address_employ
	WHERE #address_employ.idaddresskind <> @nostand
	AND EXISTS(
		SELECT * FROM #address_employ r2 
		WHERE #address_employ.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
	
DELETE #address_employ
	WHERE #address_employ.idaddresskind NOT IN (@nostand, @stand)
	AND EXISTS(
		SELECT * FROM #address_employ r2 
		WHERE #address_employ.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
	
DELETE #address_employ
	WHERE (
		SELECT COUNT(*) FROM #address_employ r2 
		WHERE #address_employ.idreg = r2.idreg
	)>1
	
-- Inserimento del corretto indirizzo del soggetto a ritenuta
UPDATE #movement SET
	address = i1.address,
	location = i1.location,
	province = i1.province,
	nation = ISNULL(i1.nation,'ITALIA'),
	cap = i1.cap
FROM #address_employ i1
WHERE #movement.idreg = i1.idreg

CREATE TABLE #tax_movement
(
	nmov int,
	ymov int,
	registry varchar(100),
	cf varchar(100), 
	surname varchar(50),
	forename varchar(50),
	birthdate datetime,
	birthplace varchar(65), 
	birthprovince varchar(2), 
	birthnation varchar(65),
    	sex char(1), 
	idser int,
    	desc_exp varchar(150),
    	servicestart datetime,
    	servicestop datetime,
    	address varchar(100),
    	location varchar(65),
    	province varchar(2),
    	nation varchar(65),
    	cap varchar(20),
	todelete char(1),
	fiscaltaxcity varchar(65),
	fiscaltaxregion varchar(50)
)
DECLARE @var_name varchar(20)
DECLARE @SQL_string nvarchar(4000)

DECLARE #tax_crs1 INSENSITIVE CURSOR FOR
SELECT var_name FROM #link_tax
FOR READ ONLY
OPEN #tax_crs1
FETCH NEXT FROM #tax_crs1 INTO @var_name
WHILE (@@FETCH_STATUS = 0)
	BEGIN
-- Costruzione dinamica della tab #tax_movement nella parte dedicata alle ritenute
		SELECT @SQL_string = N'ALTER TABLE #tax_movement
			ADD 
                        [' + @var_name + '_dip_Appl_Liq_nel_periodo] decimal(23,6) NULL DEFAULT 0, 
                        [' + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo] decimal(23,6) NULL DEFAULT 0, 
                        [' + @var_name + '_dip_Appl_nel_Periodo_Non_Liq] decimal(23,6) NULL DEFAULT 0, 

                        [' + @var_name + '_amm_Appl_Liq_nel_periodo] decimal(23,6) NULL DEFAULT 0,
                        [' + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo] decimal(23,6) NULL DEFAULT 0,
                        [' + @var_name + '_amm_Appl_nel_Periodo_Non_Liq] decimal(23,6) NULL DEFAULT 0'
		EXEC sp_executesql @SQL_string

		FETCH NEXT FROM #tax_crs1 INTO @var_name
	END
CLOSE #tax_crs1
DEALLOCATE #tax_crs1

IF @unified = 'S'
BEGIN
-- Inserimento dei dati nella tab #tax_movement nel caso si scelga il consolidamento dei movimenti
	INSERT INTO #tax_movement
	(
		ymov, registry, cf, surname, forename,
		birthdate, birthplace, birthprovince, birthnation,
		sex, address, location, province, nation, cap, todelete--,
--		fiscaltaxcity, fiscaltaxregion
	)
	SELECT DISTINCT ymov, registry, cf, surname, forename,
		birthdate, birthplace, birthprovince, birthnation,
		sex, address, location, province, nation, cap,'S'--, 
--		fiscaltaxcity, fiscaltaxregion
	FROM #movement

	UPDATE #tax_movement SET fiscaltaxcity
	= #movement.fiscaltaxcity
	FROM #movement
	WHERE #tax_movement.cf = #movement.cf
                AND (#movement.employtax_liq_periodo <> 0 OR #movement.employtax_operate_prec <> 0 OR #movement.employtax_non_liq <> 0)
	AND #movement.fiscaltaxcity IS NOT NULL

	UPDATE #tax_movement SET fiscaltaxregion
	= #movement.fiscaltaxregion
	FROM #movement
	WHERE #tax_movement.cf = #movement.cf
                AND (#movement.employtax_liq_periodo <> 0 OR #movement.employtax_operate_prec <> 0 OR #movement.employtax_non_liq <> 0)
		AND #movement.fiscaltaxregion IS NOT NULL
END
ELSE
BEGIN
-- Inserimento dei dati nella tab #tax_movement nel caso non si scelga il consolidamento dei movimenti
	INSERT INTO #tax_movement
	(
		nmov, ymov, registry, cf, surname, forename,
		birthdate, birthplace, birthprovince, birthnation, sex, 
            	idser, desc_exp, servicestart, servicestop,
            	address, location, province, nation, cap, todelete--,
--		fiscaltaxcity, fiscaltaxregion
	)
	SELECT DISTINCT nmov, ymov, registry, cf, surname, forename,
		birthdate, birthplace, birthprovince, birthnation, sex,
		idser, desc_exp, servicestart, servicestop,
		address, location, province, nation, cap, 'S'--,
--		fiscaltaxcity, fiscaltaxregion
	FROM #movement

	UPDATE #tax_movement SET fiscaltaxcity
	= #movement.fiscaltaxcity
	FROM #movement
	WHERE #tax_movement.cf = #movement.cf
                AND ( #movement.employtax_liq_periodo <> 0 OR #movement.employtax_operate_prec <> 0 OR #movement.employtax_non_liq <> 0 )
		AND #tax_movement.nmov = #movement.nmov
		AND #tax_movement.ymov = #movement.ymov
		AND #movement.fiscaltaxcity IS NOT NULL

	UPDATE #tax_movement SET fiscaltaxregion
	= #movement.fiscaltaxregion
	FROM #movement
	WHERE #tax_movement.cf = #movement.cf
                AND ( #movement.employtax_liq_periodo <> 0 OR #movement.employtax_operate_prec <> 0 OR #movement.employtax_non_liq <> 0 )
		AND #tax_movement.nmov = #movement.nmov
		AND #tax_movement.ymov = #movement.ymov
		AND #movement.fiscaltaxregion IS NOT NULL
END

DECLARE @emp_str_A varchar(15)
DECLARE @adm_str_A varchar(15)

DECLARE @emp_str_B varchar(15)
DECLARE @adm_str_B varchar(15)

DECLARE @emp_str_C varchar(15)
DECLARE @adm_str_C varchar(15)

DECLARE @nbr_str varchar(15)
DECLARE	@registry_title varchar(100)
DECLARE	@cf varchar(100)
DECLARE @nmov int
DECLARE @employtax_liq_periodo decimal(23,6)
DECLARE @admintax_liq_periodo decimal(23,6)
DECLARE @employtax_operate_prec decimal(23,6)
DECLARE @admintax_operate_prec decimal(23,6)
DECLARE @employtax_non_liq decimal(23,6)
DECLARE @admintax_non_liq decimal(23,6)

DECLARE mov_crs INSENSITIVE CURSOR FOR
SELECT nmov, registry, cf, taxref,	--RTRIM(LTRIM(taxcode)), 
employtax_liq_periodo, admintax_liq_periodo,          --A
employtax_operate_prec,admintax_operate_prec,         --B
employtax_non_liq, admintax_non_liq                   --C
FROM #movement
ORDER BY nmov
FOR READ ONLY
OPEN mov_crs
FETCH NEXT FROM mov_crs INTO @nmov, @registry_title, @cf,
	@var_name, @employtax_liq_periodo, @admintax_liq_periodo,
        @employtax_operate_prec,@admintax_operate_prec, 
        @employtax_non_liq, @admintax_non_liq

WHILE (@@FETCH_STATUS = 0)
BEGIN
-- Calcolo degli importi delle ritenute:
-- @codiceritenuta_dip : Importo ritenuta a carico del Dipendente
-- @codiceritenuta_amm : Importo ritenuta a carico dell'Amministrazione

IF (@unified = 'S')
	BEGIN
		SET @emp_str_A = ISNULL(@employtax_liq_periodo,0)
		SET @adm_str_A = ISNULL(@admintax_liq_periodo,0)
		SET @emp_str_B = ISNULL(@employtax_operate_prec,0)
		SET @adm_str_B = ISNULL(@admintax_operate_prec,0)
		SET @emp_str_C = ISNULL(@employtax_non_liq,0)
		SET @adm_str_C = ISNULL(@admintax_non_liq,0)

		SET @SQL_string = N'UPDATE #tax_movement 
		 SET ' 
                + @var_name + '_dip_Appl_Liq_nel_periodo = ' + @var_name + '_dip_Appl_Liq_nel_periodo + ' + @emp_str_A +
		','
                 + @var_name + '_amm_Appl_Liq_nel_periodo = ' + @var_name + '_amm_Appl_Liq_nel_periodo + ' + @adm_str_A +
                ','
                + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo = ' + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo + ' + @emp_str_B +
		',' 
                + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo = ' + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo + ' + @adm_str_B +
                ','
                + @var_name + '_dip_Appl_nel_Periodo_Non_Liq = ' + @var_name + '_dip_Appl_nel_Periodo_Non_Liq + ' + @emp_str_C +
		',' 
                + @var_name + '_amm_Appl_nel_Periodo_Non_Liq = ' + @var_name + '_amm_Appl_nel_Periodo_Non_Liq + ' + @adm_str_C +

		' WHERE registry = ''' + REPLACE(@registry_title,'''','''''') + ''''+
		' AND cf = ''' + @cf + ''''
		EXEC sp_executesql @SQL_string

	END
	ELSE
	BEGIN
		SET @emp_str_A = ISNULL(@employtax_liq_periodo,0)
		SET @adm_str_A = ISNULL(@admintax_liq_periodo,0)
		SET @emp_str_B = ISNULL(@employtax_operate_prec,0)
		SET @adm_str_B = ISNULL(@admintax_operate_prec,0)
		SET @emp_str_C = ISNULL(@employtax_non_liq,0)
		SET @adm_str_C = ISNULL(@admintax_non_liq,0)
		SET @nbr_str = @nmov
		SET @SQL_string = 'UPDATE #tax_movement
		SET '
                + @var_name + '_dip_Appl_Liq_nel_periodo = ' + @var_name + '_dip_Appl_Liq_nel_periodo + ' + @emp_str_A +
		',' 
                + @var_name + '_amm_Appl_Liq_nel_periodo = ' + @var_name + '_amm_Appl_Liq_nel_periodo + ' + @adm_str_A +
                ',' 
                + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo = ' + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo + ' + @emp_str_B +
		',' 
                + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo = ' + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo + ' + @adm_str_B +
                ',' 
                + @var_name + '_dip_Appl_nel_Periodo_Non_Liq = ' + @var_name + '_dip_Appl_nel_Periodo_Non_Liq + ' + @emp_str_C +
		',' 
                + @var_name + '_amm_Appl_nel_Periodo_Non_Liq = ' + @var_name + '_amm_Appl_nel_Periodo_Non_Liq + ' + @adm_str_C +

		'WHERE nmov = '+ @nbr_str
		EXEC sp_executesql @SQL_string
	END
	FETCH NEXT FROM mov_crs INTO @nmov, @registry_title, @cf,  
		@var_name,  @employtax_liq_periodo, @admintax_liq_periodo,
        @employtax_operate_prec,@admintax_operate_prec, 
        @employtax_non_liq, @admintax_non_liq
END

-- UPDATE campo todelete per cancellazione righe vuote da #tax_movement
DECLARE #tax_crs1 INSENSITIVE CURSOR FOR
SELECT var_name FROM #link_tax
FOR READ ONLY
OPEN #tax_crs1
FETCH NEXT FROM #tax_crs1 INTO @var_name
WHILE (@@FETCH_STATUS = 0)
BEGIN
	DECLARE @no_del_condition nvarchar(4000)
	SET @no_del_condition = ''
	SET @no_del_condition =
        '[' + @var_name + '_dip_Appl_Liq_nel_periodo] <> 0 OR [' + @var_name + '_amm_Appl_Liq_nel_periodo] <> 0 '+
        ' OR [' + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo] <> 0 OR [' + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo] <> 0 '+
        ' OR [' + @var_name + '_dip_Appl_nel_Periodo_Non_Liq] <> 0 OR [' + @var_name + '_amm_Appl_nel_Periodo_Non_Liq] <> 0'

	SET @SQL_string = N'UPDATE #tax_movement set todelete = ''N'' WHERE ' + @no_del_condition
	EXEC sp_executesql @SQL_string		
	FETCH NEXT FROM #tax_crs1 INTO @var_name
END
CLOSE #tax_crs1
DEALLOCATE #tax_crs1
CLOSE mov_crs
DEALLOCATE mov_crs

-- Cancellazione di eventuali movimenti (righe) dove gli importi relativi alle ritenute
-- (imponibili, ritenute carico dipendente e carico amministrazione) sono tutti pari a zero
SET @SQL_string = N'DELETE #tax_movement WHERE todelete = ''S''' 
EXEC sp_executesql @SQL_string
DECLARE @DROPstring1 nvarchar(4000)
UPDATE #tax_movement SET cf = '''' + cf WHERE cf IS NOT NULL
DECLARE @var_output decimal(23,6)
DECLARE @print_taxcode varchar(20)

-- Creazione della SELECT finale (parte statica)
IF (@unified = 'N')
BEGIN
	SET @SQL_string = N'SELECT 
	nmov AS ''Num. Mov.'',ymov AS ''Eserc. Mov.'',registry AS Denominazione,cf AS ''C.F.'',surname AS Cognome,
	forename AS Nome,birthdate AS ''Data Nascita'',birthplace AS ''Luogo Nascita'',birthprovince AS ''Prov. Nascita'',
	birthnation AS ''Stato Nascita'',sex AS Sesso,idser AS ''Cod. Prestazione'',desc_exp AS ''Desc. Spesa'',
	servicestart AS ''Inizio Prest.'',servicestop AS ''Fine Prest.'',address AS Indirizzo,location AS ''Località'',
	province AS Provincia,nation as Stato, CAP, fiscaltaxcity as ''Comune'', fiscaltaxregion as ''Regione Fiscale'','
END
ELSE
BEGIN
	SET @SQL_string = N'SELECT 
	registry AS Denominazione,cf AS ''C.F.'',surname AS Cognome,forename AS Nome,birthdate AS ''Data Nascita'',
	birthplace AS ''Luogo Nascita'',birthprovince AS ''Prov. Nascita'',birthnation AS ''Stato Nascita'',sex AS Sesso,
	address AS Indirizzo,location AS ''Località'',province AS Provincia,nation AS Stato,CAP,
	fiscaltaxcity AS ''Comune'', fiscaltaxregion AS ''Regione Fiscale'','
END

INSERT INTO #tmpstr (DROPstr) SELECT @SQL_string

DECLARE @print_taxdesc varchar(50) 

DECLARE final_crs INSENSITIVE CURSOR FOR
SELECT var_name,taxcode FROM #link_tax
FOR READ ONLY
OPEN final_crs
FETCH NEXT FROM final_crs INTO @var_name,@taxcode
WHILE(@@FETCH_STATUS = 0)
	BEGIN
-- Creazione della SELECT finale (parte dinamica)
		SET @print_taxcode = REPLACE(@taxcode,'''','''''')

		SELECT @print_taxdesc = description FROM tax WHERE taxcode = @taxcode
		SELECT @print_taxdesc = REPLACE(@print_taxdesc,'''','''''''''')

		SELECT @DROPstring1 = 
' IF (SELECT SUM(' + @var_name + '_dip_Appl_Liq_nel_periodo) FROM #tax_movement)<>0  '+
' UPDATE #tmpstr SET DROPstr = DROPstr + '' '+@var_name + '_dip_Appl_Liq_nel_periodo ''''' + @print_taxdesc + '_C/Dip. Appl_Liq_nel_periodo'''' ,'''+

' IF (SELECT SUM(' + @var_name + '_amm_Appl_Liq_nel_periodo) FROM #tax_movement)<>0  '+
' UPDATE #tmpstr SET DROPstr = DROPstr + '' '+@var_name + '_amm_Appl_Liq_nel_periodo ''''' + @print_taxdesc + '_C/Amm. Appl_Liq_nel_periodo'''' ,'''+

' IF (SELECT SUM(' + @var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo) FROM #tax_movement)<>0  '+
' UPDATE #tmpstr SET DROPstr = DROPstr + '' '+@var_name + '_dip_Appl_Periodo_Prec_Liq_nel_periodo ''''' + @print_taxdesc + '_C/Dip. Appl_periodo_Prec_Liq_nel_periodo'''' ,'''+

' IF (SELECT SUM(' + @var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo) FROM #tax_movement)<>0  '+
' UPDATE #tmpstr SET DROPstr = DROPstr + '' '+@var_name + '_amm_Appl_Periodo_Prec_Liq_nel_periodo ''''' + @print_taxdesc + '_C/Amm. Appl_periodo_Prec_Liq_nel_periodo'''' ,'''+

' IF (SELECT SUM(' + @var_name + '_dip_Appl_nel_Periodo_Non_Liq) FROM #tax_movement)<>0  '+
' UPDATE #tmpstr SET DROPstr = DROPstr + '' '+@var_name + '_dip_Appl_nel_Periodo_Non_Liq ''''' + @print_taxdesc + '_C/Dip. Appl_nel_periodo_Non_Liq'''' ,'''+

' IF (SELECT SUM(' + @var_name + '_amm_Appl_nel_Periodo_Non_Liq) FROM #tax_movement)<>0  '+
' UPDATE #tmpstr SET DROPstr = DROPstr + '' '+@var_name + '_amm_Appl_nel_Periodo_Non_Liq ''''' + @print_taxdesc + '_C/Amm. Appl_nel_periodo_Non_Liq'''' ,'''



		EXEC sp_executesql @DROPstring1

		FETCH NEXT FROM final_crs INTO @var_name,@taxcode
	END
CLOSE final_crs
DEALLOCATE final_crs

-- Toglie l'ultima virgola e aggiunge la cluasola FROM
SET @SQL_string = SUBSTRING((SELECT DROPstr FROM #tmpstr),1,LEN((SELECT DROPstr FROM #tmpstr)) - 1) + ' FROM #tax_movement '

EXEC sp_executesql @SQL_string

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





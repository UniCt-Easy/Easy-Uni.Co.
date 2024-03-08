
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_ritenute_applicate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_ritenute_applicate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'
--exp_riepilogo_ritenute_applicate  2016,null,null,null,null,null,null
CREATE     PROCEDURE [exp_riepilogo_ritenute_applicate]
	@ayear                 int, 
	@idreg                 int,
	@tax                   int,
	@start             	 date,
	@stop               	 date,
	@idser int,             
	@unified_mov varchar(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

AS
  BEGIN

        CREATE TABLE #tax
	(
		employtax_liq_periodo decimal(19,2),    --A
		admintax_liq_periodo decimal(19,2),     --A
		employtax_operate_prec decimal(19,2),   --B
		admintax_operate_prec decimal(19,2),    --B
		employtax_non_liq decimal(19,2),        --C
		admintax_non_liq decimal(19,2),         --C
		idexp int,
		taxcode int,
		idser int,
		idreg int,
        -- info relative al mov. si spesa servonoin caso si decida di consolidare
        	nmov int,
        	ymov int,
        	desc_exp varchar(150),
        	servicestart date,
        	servicestop date,
        -- info relative all'indirizzo
            	address varchar(100),
            	location varchar(65),
            	province varchar(2),
            	nation varchar(65),
            	cap varchar(20),
        -- info relative al comune e regione fiscale
        	idcity int,
        	idfiscaltaxregion varchar(5)
	)
/*      
A) rit. operate e liquidate del periodo : le ritenute + correzioni incluse nelle LIQUIDAZIONI RITENUTE che includono 
il periodo selezionato.
*/

	INSERT INTO #tax
	(
        employtax_liq_periodo,-- A
	    admintax_liq_periodo,  -- A
		idexp,
		taxcode,
		idser,
		idreg,
		idcity,
		idfiscaltaxregion,
       	nmov,ymov,desc_exp,servicestart,servicestop 
	)
	SELECT	
	        isnull(sum(E.employtax),0),
	        isnull(sum(E.admintax),0),
                E.idexp,
                T.taxcode,
		EL.idser,
	        expense.idreg,
		E.idcity,
		E.idfiscaltaxregion,
       	        expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
	FROM expensetaxview as E
	JOIN expense			ON expense.idexp = E.idexp
	join expenseyear		on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	join upb				on expenseyear.idupb = upb.idupb	
	JOIN expenselast EL		ON E.idexp = EL.idexp
	JOIN tax T				ON T.taxcode = E.taxcode	
	JOIN taxpay				ON taxpay.ytaxpay = E.ytaxpay  AND taxpay.ntaxpay = E.ntaxpay  AND taxpay.taxcode = ISNULL(T.maintaxcode,T.taxcode)
	WHERE expense.ymov = @ayear  
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND E.datetaxpay BETWEEN @start AND @stop -- operata nel periodo
		AND (@tax is null OR  T.taxcode = @tax )
        AND (expense.idreg = @idreg  OR @idreg is null) 
        AND (El.idser = @idser  OR @idser is null) 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY expense.idreg, E.idexp,T.taxcode, EL.idser,
		E.idcity, E.idfiscaltaxregion,expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 

	INSERT INTO #tax
	(
	employtax_liq_periodo,-- A
	admintax_liq_periodo,  -- A
	idexp,
	taxcode,
	idser,
	idreg,
	idcity,
	idfiscaltaxregion,
	nmov,ymov,desc_exp,servicestart,servicestop 
	)
	SELECT 	
	        isnull(sum(E.employamount),0),
	        isnull(sum(E.adminamount),0),
                E.idexp,
                T.taxcode,
		EL.idser,
	        expense.idreg,
		E.idcity,
		E.idfiscaltaxregion,
       	        expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
	FROM expensetaxcorrigeview as E
	JOIN expense				ON expense.idexp = E.idexp
	join expenseyear			on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	join upb					on expenseyear.idupb = upb.idupb
	JOIN expenselast EL			ON E.idexp = EL.idexp
	JOIN tax T				ON T.taxcode = E.taxcode	
	JOIN taxpay				ON taxpay.ytaxpay = E.ytaxpay  AND taxpay.ntaxpay = E.ntaxpay  AND taxpay.taxcode = ISNULL(T.maintaxcode,T.taxcode)
	WHERE expense.ymov = @ayear  
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND E.adate BETWEEN @start AND @stop -- operata nel periodo
		AND (@tax is null OR  T.taxcode = @tax )
        AND (expense.idreg = @idreg  OR @idreg is null) 
        AND (El.idser = @idser  OR @idser is null) 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY expense.idreg, E.idexp, T.taxcode, EL.idser,
		E.idcity, E.idfiscaltaxregion,expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
/*
B) rit. operate in periodi precedenti e liquidate nel periodo
*/
	INSERT INTO #tax
	(
	employtax_operate_prec, -- B
	admintax_operate_prec, -- B
	idexp,
	taxcode,
	idser,
	idreg,
	idcity,
	idfiscaltaxregion,
	nmov,ymov,desc_exp,servicestart,servicestop 
	)
	SELECT	
		isnull(sum(E.employtax),0),
		isnull(sum(E.admintax),0),
		E.idexp,
		T.taxcode,
		EL.idser,
		expense.idreg,
		E.idcity,
		E.idfiscaltaxregion,
		expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
	FROM expensetaxview as E
	JOIN expense			ON expense.idexp = E.idexp
	join expenseyear		on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	join upb				on expenseyear.idupb = upb.idupb
	JOIN expenselast EL		ON E.idexp = EL.idexp
	JOIN tax T				ON T.taxcode = E.taxcode	
	JOIN taxpay				ON taxpay.ytaxpay = E.ytaxpay  AND taxpay.ntaxpay = E.ntaxpay  AND taxpay.taxcode = ISNULL(T.maintaxcode,T.taxcode)
	WHERE expense.ymov = @ayear  
                AND  -- liquidata nel periodo (prende le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND E.datetaxpay < @start -- operata nel periodo precedente 
		AND (@tax is null OR  T.taxcode = @tax )
        AND (expense.idreg = @idreg  OR @idreg is null) 
        AND (El.idser = @idser  OR @idser is null) 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY expense.idreg, E.idexp, T.taxcode, EL.idser,
		E.idcity, E.idfiscaltaxregion,expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 

	INSERT INTO #tax
	(		
	employtax_operate_prec, -- B
	admintax_operate_prec, -- B
	idexp,
	taxcode,
	idser,
	idreg,
	idcity,
	idfiscaltaxregion,
	nmov,ymov,desc_exp,servicestart,servicestop 
	)
	SELECT 	
		isnull(sum(E.employamount),0),
		isnull(sum(E.adminamount),0),
		E.idexp,
		T.taxcode,
		EL.idser,
		expense.idreg,
		E.idcity,
		E.idfiscaltaxregion,
		expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
	FROM expensetaxcorrigeview as E
	JOIN expense			ON expense.idexp = E.idexp
	join expenseyear		on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	join upb				on expenseyear.idupb = upb.idupb
	JOIN expenselast EL		ON E.idexp = EL.idexp
		JOIN tax T				ON T.taxcode = E.taxcode	
	JOIN taxpay				ON taxpay.ytaxpay = E.ytaxpay  AND taxpay.ntaxpay = E.ntaxpay  AND taxpay.taxcode = ISNULL(T.maintaxcode,T.taxcode)
	WHERE expense.ymov = @ayear  
                AND  -- liquidata nel periodo (prendi le liq. che hanno intersezione non nulla col periodo selezionato)
                      (  taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop
                        )
		AND E.adate < @start -- operata nel periodo precedente
		AND (@tax is null OR  T.taxcode = @tax )
        AND (expense.idreg = @idreg  OR @idreg is null) 
        AND (El.idser = @idser  OR @idser is null) 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY expense.idreg, E.idexp, T.taxcode,EL.idser,
		E.idcity, E.idfiscaltaxregion,
		expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 

/*
C) rit. operate nel periodo e non liquidate NEL PERIODO
*/
	INSERT INTO #tax
	(
	employtax_non_liq,--C
	admintax_non_liq, --C
	idexp,
	taxcode,
	idser,
	idreg,
	idcity,
	idfiscaltaxregion,
	nmov,ymov,desc_exp,servicestart,servicestop 
	)
	SELECT	
		isnull(sum(E.employtax),0),
		isnull(sum(E.admintax),0),
		E.idexp,
		T.taxcode,
		EL.idser,
		expense.idreg,
		E.idcity,
		E.idfiscaltaxregion,
		expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
	FROM expensetaxview as E
	JOIN expense			ON expense.idexp = E.idexp
	join expenseyear		on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	join upb				on expenseyear.idupb = upb.idupb
	JOIN expenselast EL		ON E.idexp = EL.idexp
	JOIN tax T				ON T.taxcode = E.taxcode	
	
	WHERE expense.ymov = @ayear  
                AND E.datetaxpay BETWEEN @start AND @stop  -- operata nel periodo 
                AND NOT EXISTS-- NON liquidata nel periodo
                      ( SELECT * FROM taxpay
                        WHERE taxpay.ytaxpay = E.ytaxpay
                        AND taxpay.ntaxpay = E.ntaxpay
                        AND taxpay.taxcode = E.taxcode
                        AND (taxpay.start BETWEEN @start AND @stop
                                OR taxpay.stop BETWEEN @start AND @stop
                                OR @start BETWEEN taxpay.start AND taxpay.stop
                                OR @stop BETWEEN taxpay.start AND taxpay.stop)
                        )		
		AND (@tax is null OR  T.taxcode = @tax )
        AND (expense.idreg = @idreg  OR @idreg is null) 
        AND (El.idser = @idser  OR @idser is null) 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY expense.idreg, E.idexp, T.taxcode, EL.idser,
		E.idcity, E.idfiscaltaxregion,
		expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 

	INSERT INTO #tax
	(
	employtax_non_liq,--C
	admintax_non_liq, --C
	idexp,
	taxcode,
	idser,
	idreg,
	idcity,
	idfiscaltaxregion,
	nmov,ymov,desc_exp,servicestart,servicestop 
	)
	SELECT 	isnull(sum(E.employamount),0),
		isnull(sum(E.adminamount),0),
		E.idexp,
		T.taxcode,
		EL.idser,
		expense.idreg,
		E.idcity,
		E.idfiscaltaxregion,
		expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 
	FROM expensetaxcorrigeview as E
	JOIN expense			ON expense.idexp = E.idexp
	join expenseyear		on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
	join upb				on expenseyear.idupb = upb.idupb
	JOIN expenselast EL		ON E.idexp = EL.idexp
	JOIN tax T	ON  T.taxcode = E.taxcode	
	WHERE expense.ymov = @ayear  
            AND NOT EXISTS -- NON liquidata nel periodo 
              (SELECT * FROM taxpay
               WHERE taxpay.ytaxpay = E.ytaxpay
                AND taxpay.ntaxpay = E.ntaxpay
                AND taxpay.taxcode = E.taxcode
                AND ( taxpay.start BETWEEN @start AND @stop
                         OR taxpay.stop BETWEEN @start AND @stop
                         OR @start BETWEEN taxpay.start AND taxpay.stop
                         OR @stop BETWEEN taxpay.start AND taxpay.stop)
                )
		AND E.adate BETWEEN @start AND @stop -- operata nel periodo
		AND (@tax is null OR  T.taxcode = @tax )
        AND (expense.idreg = @idreg  OR @idreg is null) 
        AND (El.idser = @idser  OR @idser is null) 
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY expense.idreg, E.idexp, T.taxcode, EL.idser,
		E.idcity, E.idfiscaltaxregion,
       	        expense.nmov,expense.ymov,expense.description,EL.servicestart,EL.servicestop 

--------------------------------------------------
-- Gestione degli indirizzi
--------------------------------------------------

CREATE TABLE #employ (idreg int)
	
INSERT INTO #employ (idreg)
SELECT DISTINCT idreg FROM #tax


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
	
DECLARE @dateindi date
SELECT @dateindi = CONVERT(date, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

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
WHERE  RA.idreg in (select idreg from #employ)
        AND RA.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = RA.idaddresskind
		AND cdi.start <= @dateindi
		AND cdi.idreg = RA.idreg)
	
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
UPDATE #tax SET
	address = i1.address,
	location = i1.location,
	province = i1.province,
	nation = ISNULL(i1.nation,'ITALIA'),
	cap = i1.cap
FROM #address_employ i1
WHERE #tax.idreg = i1.idreg

--------------------------------------------------
-- Fine gestione indirizzi
--------------------------------------------------


-- La condizione sul dipartimento è stata valutata solo col @unified_mov='N', perchè la sp del consolidmanto
-- chiama questa sp con @unified_mov = N, al fine di ottenere tutti i dati e poi elaborarli prima del'output.
-- Quindi se la sp viene chiamata dal consolidamento
-- il @show_department vale S e @unified_mov vale N
-- Se la sp non viene chiamata dal consolidamento
-- avremo "@show_department = N e @unified_mov = N"  oppure @unified_mov=S
-- In pratica solo la sp "normale" poò consolidare i movimenti dei percipienti
IF (@unified_mov='S') 
BEGIN
      SELECT
        R.title as 'Percipiente',
		R.cf 'C.F.',
        R.surname as 'Cognome', R.forename as 'Nome',
        R.birthdate as 'data Nascita', 
        GC.title as 'Luogo Nascita',
        GP.province as 'Prov.Nascita', 
        ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
        R.gender as 'Sesso',
        #tax.address as 'Indirizzo',
        #tax.location as 'Località',
        #tax.province as 'Provincia',
        #tax.nation as 'Stato',
        #tax.cap as 'CAP',
        GC_rit.title as 'Comune', 
        F.title as 'Regione Fiscale',
        tax.description as 'Ritenuta',
        ISNULL(SUM(#tax.employtax_liq_periodo),0) AS 'Rit/Dip. applicate e liquidate nel periodo',--A
        ISNULL(SUM(#tax.employtax_operate_prec),0) AS 'Rit/Dip. applicate in periodi prec. e liquidate nel periodo',--B
        ISNULL(SUM(#tax.employtax_non_liq),0) AS 'Rit/Dip. applicate nel periodo e non liquidate nel periodo',--C
        ISNULL(SUM(#tax.employtax_liq_periodo),0) +  ISNULL(SUM(#tax.employtax_operate_prec),0) AS 'Tot. Rit/Dip. Liquidato',-- A+B

        ISNULL(SUM(#tax.admintax_liq_periodo),0) AS 'Contributi applicati e liquidati nel periodo',--A
        ISNULL(SUM(#tax.admintax_operate_prec),0) AS 'Contributi applicati in periodi prec. e liquidate nel periodo',--B
        ISNULL(SUM(#tax.admintax_non_liq),0) AS 'Contributi applicati nel periodo e non liquidate nel periodo', --C
        ISNULL(SUM(#tax.admintax_liq_periodo),0) + ISNULL(SUM(#tax.admintax_operate_prec),0) AS 'Tot. Contributi Liquidati'--A+B
      FROM #tax
	join registry R						on #tax.idreg = R.idreg 
	left outer join tax					on #tax.taxcode =  Tax.taxcode
	left outer join service 			on #tax.idser = service.idser
    LEFT OUTER JOIN geo_city GC        	ON GC.idcity = R.idcity
    LEFT OUTER JOIN geo_country GP		ON GP.idcountry = GC.idcountry
    LEFT OUTER JOIN geo_nation GN		ON GN.idnation = R.idnation
    LEFT OUTER JOIN geo_city GC_rit     ON GC_rit.idcity = #tax.idcity
    LEFT OUTER JOIN fiscaltaxregion F	ON F.idfiscaltaxregion = #tax.idfiscaltaxregion
	GROUP BY R.cf ,R.title, tax.description,service.description, GC_rit.title ,F.title,
                R.surname, R.forename,R.birthdate,GC.title,GP.province, 
                GN.title, R.gender,#tax.address,#tax.location,#tax.province,#tax.nation,#tax.cap
        ORDER BY tax.description, R.title
END
IF (@unified_mov='N' ) 
BEGIN
      SELECT
        #tax.ymov as 'Eserc.Mov',
        #tax.nmov as 'Num.Mov.',
        R.title as 'Percipiente',
		R.cf 'C.F.',
        R.surname as 'Cognome', R.forename as 'Nome',
        R.birthdate as 'data Nascita', 
        GC.title as 'Luogo Nascita',
        GP.province as 'Prov.Nascita', 
        ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
        R.gender as 'Sesso',
	service.description as 'Prestazione',
        #tax.desc_exp as 'Descr.Spesa',
        #tax.servicestart as 'Inizio Prest.',
        #tax.servicestop as 'Fine Prest.',
        #tax.address as 'Indirizzo',
        #tax.location as 'Località',
        #tax.province as 'Provincia',
        #tax.nation as 'Stato',
        #tax.cap as 'CAP',
        GC_rit.title as 'Comune', 
        F.title as 'Regione Fiscale',
        tax.description as 'Ritenuta',
        ISNULL(SUM(#tax.employtax_liq_periodo),0) AS 'Rit/Dip. applicate e liquidate nel periodo',--A
        ISNULL(SUM(#tax.employtax_operate_prec),0) AS 'Rit/Dip. applicate in periodi prec. e liquidate nel periodo',--B
        ISNULL(SUM(#tax.employtax_non_liq),0) AS 'Rit/Dip. applicate nel periodo e non liquidate nel periodo',--C
        ISNULL(SUM(#tax.employtax_liq_periodo),0) +  ISNULL(SUM(#tax.employtax_operate_prec),0) AS 'Tot. Rit/Dip. Liquidato',-- A+B

        ISNULL(SUM(#tax.admintax_liq_periodo),0) AS 'Contributi applicati e liquidati nel periodo',--A
        ISNULL(SUM(#tax.admintax_operate_prec),0) AS 'Contributi applicati in periodi prec. e liquidate nel periodo',--B
        ISNULL(SUM(#tax.admintax_non_liq),0) AS 'Contributi applicati nel periodo e non liquidate nel periodo', --C
        ISNULL(SUM(#tax.admintax_liq_periodo),0) + ISNULL(SUM(#tax.admintax_operate_prec),0) AS 'Tot. Contributi Liquidati'--A+B
      FROM #tax
	join registry R
		on #tax.idreg = R.idreg 
	left outer join tax					on #tax.taxcode =  Tax.taxcode
	left outer join service 			on #tax.idser = service.idser
    LEFT OUTER JOIN geo_city GC     	ON GC.idcity = R.idcity
    LEFT OUTER JOIN geo_country GP        	ON GP.idcountry = GC.idcountry
    LEFT OUTER JOIN geo_nation GN        	ON GN.idnation = R.idnation
    LEFT OUTER JOIN geo_city GC_rit        	ON GC_rit.idcity = #tax.idcity
    LEFT OUTER JOIN fiscaltaxregion F      	ON F.idfiscaltaxregion = #tax.idfiscaltaxregion
	GROUP BY R.cf ,R.title, tax.description,service.description, GC_rit.title ,F.title,
                R.surname, R.forename,R.birthdate,GC.title,GP.province, 
                GN.title, R.gender,#tax.address,#tax.location,#tax.province,#tax.nation,#tax.cap,
                #tax.ymov, #tax.nmov,#tax.desc_exp,#tax.servicestart,#tax.servicestop
        ORDER BY tax.description, R.title
END


  END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_ritenute_applicate_inail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_ritenute_applicate_inail]
GO

--setuser'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exec exp_riepilogo_ritenute_applicate_inail 2016,null ,null,'S',null,null,null,null,null,'S'

CREATE  PROCEDURE [exp_riepilogo_ritenute_applicate_inail]
	@ayear int, 
	@idreg int, 
	@tax   int,
	@show_month char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@perpresavisione char(1)

---------------------------------------------------------------------------------------------------------
-- IMPORTANTE: 
-- @show_department @show_month gestisce la visualizzazione del Dip. e del mese sarà 'S' SOLO PER ROMA!!!
---------------------------------------------------------------------------------------------------------


AS
BEGIN
if (@perpresavisione = 'N') return  ---- l'esportazione non restituisce nulla
--- dipartimento di afferenza
declare @idsorkind01 int
declare @sortingkind01 varchar(50)
select  @idsorkind01  = idsorkind01 from uniconfig
select  @sortingkind01  = description  from sortingkind where idsorkind = @idsorkind01
 
 declare @dept  varchar(50)
select  @dept = description from sorting where idsor = @idsor01 
-- visualizza tutti i dettagli  

CREATE TABLE #spesa  (
	idexp int,nmov int,ymov int,npay int,
	codefin				varchar(50),
	codeupb				varchar(50),
    idreg				int, 
	datetaxpay			datetime,
	transmissiondate	datetime,
	desc_exp			varchar(150),
	idser				int,
	servicestart		date,
	servicestop			date,
	ncontract			int,
	startcontract		date,
	stopcontract		date,
	npayroll			int,
	startpayroll		date,
	stoptime			date,
	workingdays			int,
	idpat				int,			
	patcode				varchar(20),
	ayear				int, 
	patdescription		varchar(50),
	adminrate			decimal(19,6), 
	employrate			decimal(19,6), 
	validitystart		date,
	validitystop		date,
	idsor01				int
	)

INSERT INTO #spesa   
	(idexp, nmov, ymov,npay, 
	codefin,
	codeupb,
    idreg, 
	datetaxpay,
	transmissiondate,
	desc_exp,
	idser,servicestart,servicestop,
	ncontract,
	startcontract,
	stopcontract,
	npayroll,
	startpayroll,
	stoptime,
	workingdays,
	idpat, 
	patcode,
	patdescription,
	adminrate, 
	employrate, 
	validitystart,
	validitystop,
	idsor01			
)

SELECT 
	E.idexp,        --> idexp dei movimenti interessati
	expense.nmov,
	expense.ymov,P.npay,
	F.codefin, U.codeupb,
	expense.idreg,
	E.datetaxpay,
	PT.transmissiondate,
	expense.description,
	EL.idser,
	EL.servicestart,
	EL.servicestop,
	PARAS.ncon,
	PARAS.start,
	PARAS.stop,
	PY.npayroll,
	PY.start,
	PY.stop,
	PY.workingdays,
	pat.idpat, 
	pat.patcode,
	pat.description,
	pat.adminrate, 
	pat.employrate, 
	pat.validitystart,
	pat.validitystop,
	U.idsor01
FROM expensetaxview AS E 
JOIN tax T						ON T.taxcode = E.taxcode
JOIN expense			        ON expense.idexp = E.idexp
JOIN expenselast EL		        ON expense.idexp = EL.idexp
JOIN payment P			        ON P.kpay = EL.kpay 
JOIN paymenttransmission PT	    ON P.kpaymenttransmission = PT.kpaymenttransmission 
JOIN expenseyear				ON EL.idexp = expenseyear.idexp
JOIN fin F						ON expenseyear.idfin = F.idfin
JOIN upb U						ON expenseyear.idupb = U.idupb 
JOIN expenselink ELK			ON ELK.idchild = expense.idexp
JOIN expensepayroll EP			ON ELK.idparent = EP.idexp
JOIN payroll PY					ON EP.idpayroll = PY.idpayroll
JOIN parasubcontract PARAS		ON PARAS.idcon = PY.idcon
LEFT OUTER JOIN pat				ON pat.idpat = PARAS.idpat
WHERE expense.ymov = @ayear       
		AND expenseyear.ayear = @ayear   
        AND (E.taxcode = @tax OR @tax IS NULL) AND (T.taxkind = 4) --- ritenuta assicurativa inail
        AND E.datetaxpay is not null 
        AND (expense.idreg = @idreg OR @idreg IS NULL)
		--AND (PY.flagbalance = 'S')
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY expense.idreg,expense.nmov,expense.ymov,P.npay,F.codefin, U.codeupb,
	U.idsor01,E.idexp, E.datetaxpay,
	expense.description,EL.idser,EL.servicestart,EL.servicestop,PARAS.ncon,PT.transmissiondate,
	PARAS.start,
	PARAS.stop,
	PY.npayroll,
	PY.start,
	PY.stop,
	PY.workingdays,
	pat.idpat, 
	pat.patcode,
	pat.description,
	pat.adminrate, 
	pat.employrate, 
	pat.validitystart,
	pat.validitystop




CREATE TABLE #tax
(
        idreg int,
-- le info relative al mov. di spesa e alla prestazione
-- andranno visualizzate in caso di NON consolidamento
	desc_exp varchar(150),
	idser int,
	servicestart datetime,
	servicestop datetime,
	nmov int,
	ymov int,
	npay int,
	codefin varchar(50),
	codeupb varchar(50),
--info dell'anagafica
	cf varchar(16),
        p_iva varchar(15),
-- inforitenute
        taxcode int,
        taxablegross decimal(19,2),
        taxablenet decimal(19,2),
        employtax decimal(19,2),
        admintax decimal(19,2),
        abatements decimal(19,2),
        idexp int,
        stop datetime,datetaxpay datetime,
        rowkind char,
-- info relative all'indirizzo
    	address varchar(100),
    	location varchar(65),
    	province varchar(2),
    	nation varchar(65),
    	cap varchar(20),
-- info relative al comune e regione fiscale
	idcity int,
	idfiscaltaxregion varchar(5),
-- mese in cui dovrebbe essere fatta la Lx della ritenuta
        monthtaxpay int
)

--        1) Prendere le righe che hanno Data Inizio Validità NULL
-- Applica nel periodo
 
INSERT INTO #tax
(
		nmov,
		ymov,npay, codefin, codeupb,
		monthtaxpay,
		taxablegross,
		taxablenet,
		employtax,
		admintax,
		abatements,
		idexp,
		taxcode,
		idreg,
		datetaxpay,
		stop,
		rowkind,
		idcity,
		idfiscaltaxregion,
		desc_exp,idser,servicestart,servicestop
)
SELECT 
	S.nmov,
	S.ymov,
        S.npay,S.codefin, S.codeupb,
        month(S.datetaxpay),
        max(isnull(E.taxablegross,0)),
        isnull(sum(E.taxablenet),0),
        isnull(sum(E.employtax),0),
        isnull(sum(E.admintax),0),
        isnull(sum(E.abatements),0),
        E.idexp,
        E.taxcode,
        S.idreg,
        S.datetaxpay,
        E.stop,
        1,
        E.idcity,
	E.idfiscaltaxregion,
	S.desc_exp,
	S.idser,S.servicestart,S.servicestop 
FROM expensetaxofficial E
JOIN tax T		ON E.taxcode = T.taxcode
JOIN #spesa S	ON S.idexp = E.idexp
WHERE  (E.taxcode = @tax OR @tax IS NULL) AND (T.taxkind = 4) --- ritenuta assicurativa inail
AND    (E.start IS NULL OR (year(E.start) = @ayear))
GROUP BY E.idexp,S.nmov, S.ymov, S.npay,S.codefin, S.codeupb,S.idreg,E.taxcode, E.stop,S.datetaxpay,
	E.idcity,E.idfiscaltaxregion,S.desc_exp,
	S.idser,S.servicestart,S.servicestop 



/*        2) Prendere le righe che hanno Data Inizio Validità compresa nel range di date di input        */
-- Correzioni fatte nel periodo


 

--        3) Prendere le righe che hanno Data Fine Validità compresa nel range di date di input;
-- Annullamenti fatti nel periodo

INSERT INTO #tax(	
		nmov,
		ymov,npay,codefin, codeupb,
		monthtaxpay,
		E.taxablegross,
		E.taxablenet,
        E.employtax,
        E.admintax,
        E.abatements,
        idexp,
        taxcode,
        idreg,
        datetaxpay, 
        stop,
        rowkind,
        idcity,
	idfiscaltaxregion,
	desc_exp,idser,servicestart,servicestop 
)
SELECT 
        S.nmov,
		S.ymov,P.npay,
		F.codefin, U.codeupb,
        month(E.stop),
        max(isnull(E.taxablegross,0)),
        isnull(sum(E.taxablenet),0),
        isnull(sum(E.employtax),0),
        isnull(sum(E.admintax),0),
        isnull(sum(E.abatements),0),
        E.idexp,
        E.taxcode,
        S.idreg,        
        E.start,
        E.stop,
        3,
        E.idcity,
	E.idfiscaltaxregion,
	S.description,
	EL.idser,EL.servicestart,EL.servicestop  
FROM expensetaxofficial E
JOIN tax T			ON T.taxcode = E.taxcode
JOIN expense S      ON S.idexp = E.idexp
JOIN expenselast EL         ON S.idexp = EL.idexp
JOIN payment P		        ON P.kpay = EL.kpay
JOIN expenseyear			ON EL.idexp = expenseyear.idexp
JOIN fin F					ON expenseyear.idfin = F.idfin
JOIN upb U					ON expenseyear.idupb = U.idupb 
WHERE expenseyear.ayear = @ayear
		AND  (E.taxcode = @tax OR @tax IS NULL) AND (T.taxkind = 4) --- ritenuta assicurativa inail
        AND ( S.idreg = @idreg OR @idreg IS NULL ) AND (year(E.stop) = @ayear)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY E.idexp,S.nmov,S.ymov,P.npay, F.codefin, U.codeupb, S.idreg,E.taxcode, E.start, E.stop,
      E.idcity,E.idfiscaltaxregion,S.description,
	  EL.idser,EL.servicestart,EL.servicestop  
---select * from #tax
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
LEFT OUTER JOIN geo_city GC			ON GC.idcity = RA.idcity
LEFT OUTER JOIN geo_country GP		ON GP.idcountry = GC.idcountry
LEFT OUTER JOIN geo_nation GN		ON GN.idnation = RA.idnation
JOIN #employ						ON #employ.idreg = RA.idreg
WHERE  RA.start = 
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


-- In #tax lui ha le righe relative alle ritenute applicate con rowkind= 1 ed eventualmente con rowkind =2
-- e le righe relative alle ritenute annullate con rowkind = 3.


CREATE TABLE #output
(
        idreg int,
-- info del movimento di spea
		nmov int,
		ymov int,
		npay int,
		codefin varchar(50),
		codeupb varchar(50),
		desc_exp varchar(150),
-- info delle prestazioni 
		idser int,
		servicestart datetime,
		servicestop datetime,
		monthtaxpay int,
		cf varchar(16),
		p_iva varchar(15),
		taxcode int,
		taxablegross decimal(19,2),
		taxablenet decimal(19,2),
		employtax decimal(19,2),
		admintax decimal(19,2),
		abatements decimal(19,2),
		idexp int,
		stop date,datetaxpay date,
		rowkind char,
-- info relative all'indirizzo
    	address varchar(100),
    	location varchar(65),
    	province varchar(2),
    	nation varchar(65),
    	cap varchar(20),
-- info relative al comune e regione fiscale
		idcity int,
		idfiscaltaxregion varchar(5),
		ncontract			int,
		startcontract		date,
		stopcontract		date,
		npayroll			int,
		startpayroll		date,
		stoptime			date,
		workingdays			int,
		idpat				int,			
		patcode				varchar(20),
		ayear				int, 
		patdescription		varchar(50),
		adminrate			decimal(19,6), 
		employrate			decimal(19,6), 
		validitystart		date,
		validitystop		date
)

IF (@show_month<>'S') UPDATE #tax SET monthtaxpay = NULL

INSERT INTO #output
(
	idreg,idexp,
	nmov,
	ymov,npay,
	codefin,codeupb,
	desc_exp,
	idser,servicestart,servicestop,
	monthtaxpay,
	cf, 
	p_iva,
	address,
	location,
	province,
	nation,
	cap,
	taxcode,
	taxablegross,
	taxablenet,
	employtax,
	admintax,
	abatements,
	rowkind,
	idcity,
	idfiscaltaxregion
)
SELECT
	#tax.idreg,#tax.idexp,
	#tax.nmov,
	#tax.ymov,#tax.npay,
	#tax.codefin,#tax.codeupb,
	#tax.desc_exp,
	#tax.idser,#tax.servicestart,#tax.servicestop,
	#tax.monthtaxpay,
	#tax.cf, 
	#tax.p_iva,
	#tax.address,
	#tax.location,
	#tax.province,
	#tax.nation,
	#tax.cap, 
	taxcode,
	SUM(#tax.taxablegross),
	SUM(#tax.taxablenet),
	SUM(#tax.employtax),
	SUM(#tax.admintax),
	SUM(#tax.abatements),
	#tax.rowkind, -- vale: 1, 2, 3.
	#tax.idcity,
	#tax.idfiscaltaxregion
FROM #tax  
GROUP BY #tax.idreg,#tax.idexp,#tax.nmov,#tax.ymov,#tax.npay,#tax.codefin,#tax.codeupb,#tax.monthtaxpay, #tax.cf, #tax.p_iva, #tax.taxcode,#tax.rowkind,
        #tax.idcity,#tax.idfiscaltaxregion,
        #tax.address,#tax.location,#tax.province,#tax.nation,#tax.cap,
		#tax.desc_exp,#tax.idser,#tax.servicestart,#tax.servicestop	
ORDER BY idreg,rowkind,taxcode


        -- Quindi adesso
        -- riga 1 -> rit. Applicate
        -- riga 2 -> rit. Applicate
        -- riga 3 -> rit. Annullate
       
	
	IF (@show_month='S')
	BEGIN
      	SELECT convert(char(2),monthtaxpay) as 'Mese di competenza',  
		sorting.description as 'Dipartimento',
		ISNULL(R.cf, R.foreigncf) as 'Codice Fiscale',
			R.surname as 'Cognome', R.forename as 'Nome',
			R.title as 'Percipiente',
			S.description as 'Tipo Prestazione',
			#spesa.ncontract as 'Numero Contratto',
			#spesa.startcontract as 'Data Inizio Contratto',
			#spesa.stopcontract as ' Data Fine Contratto',
			#spesa.npayroll as 'Numero Cedolino',
			#spesa.startpayroll as 'Data Inizio Cedolino',
			#spesa.stoptime as 'Data Fine Cedolino',
			#spesa.workingdays as 'Giorni Cedolino',
			#spesa.transmissiondate as 'Data di pagamento (Distinta di trasmissione)',
			--      #output.nmov as 'Num.Mov.',
			--      #output.ymov as 'Eserc.Mov.',
			--      #output.npay as 'Num.Mandato',
			--		#output.codefin as'Bilancio del Pag.della prestazione',
			--		#output.codeupb as'UPB del Pag.della prestazione',
			CASE         
					WHEN #output.rowkind  in (1,2) then  tax.description +' (applicata) '
					WHEN #output.rowkind IN (3) then  tax.description +' (annullata) '
					ELSE tax.description
			END as 'Ritenuta',  
			#spesa.patcode as 'Codice PAT',
			#spesa.patdescription as 'PAT',
			#spesa.adminrate as 'AliquotaApplicata', 
			--#spesa.employrate as 'Aliquota Dip.', 
			--#spesa.validitystart as 'Inizio Validità PAT',
			--#spesa.validitystop		as 'Inizio Validità PAT'
			--R.p_iva as 'P.iva',
			--R.birthdate as 'data Nascita', GC.title as 'Luogo Nascita',
			--GP.province as 'Prov.Nascita', ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
			--R.gender as 'Sesso',
			--#output.desc_exp as 'Descr.Spesa',
			--#output.servicestart as 'Inizio Pres.',
			--#output.servicestop as 'Fine Prest',
			--#output.address as 'Indirizzo',
			--#output.location as 'Località',
			--#output.province as 'Provincia',
			--#output.nation as 'Stato',
			--#output.cap as 'CAP',
			--GC_rit.title as 'Comune', 
			--F.title as 'Regione Fiscale',
			#output.taxablegross as ' Imponibile Lordo',
			#output.taxablenet as 'Imponibile Netto',
			#output.employtax as 'Rit.Dip.',
			#output.admintax as 'Rit.Amm.',
			#output.abatements as 'Detrazioni Applicate'--  ,    
			--#spesa.workingdays as 'Giorni Lavorati',
        FROM #output  LEFT OUTER JOIN #spesa ON #output.idexp = #spesa.idexp
        JOIN tax			                ON tax.taxcode = #output.taxcode
        JOIN registry R		                ON #output.idreg = R.idreg
        LEFT OUTER JOIN service S           ON #output.idser = S.idser
        LEFT OUTER JOIN geo_city GC        	ON GC.idcity = R.idcity
        LEFT OUTER JOIN geo_country GP     	ON GP.idcountry = GC.idcountry
        LEFT OUTER JOIN geo_nation GN      	ON GN.idnation = R.idnation
        LEFT OUTER JOIN geo_city GC_rit    	ON GC_rit.idcity = #output.idcity
        LEFT OUTER JOIN fiscaltaxregion F  	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
		LEFT OUTER JOIN  sorting			ON sorting.idsor = #spesa.idsor01 
        WHERE   
      #output.rowkind in (1,3)
        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description,#output.nmov
	END

    IF (@show_month='N')
	BEGIN
      	SELECT	 
			sorting.description as 'Dipartimento',
			ISNULL(R.cf, R.foreigncf) as 'Codice Fiscale',
			R.surname as 'Cognome', R.forename as 'Nome',
			R.title as 'Percipiente',
			S.description as 'Tipo Prestazione',
			#spesa.ncontract as 'Numero Contratto',
			#spesa.startcontract as 'Data Inizio Contratto',
			#spesa.stopcontract as ' Data Fine Contratto',
			#spesa.npayroll as 'Numero Cedolino',
			#spesa.startpayroll as 'Data Inizio Cedolino',
			#spesa.stoptime as 'Data Fine Cedolino',
			#spesa.workingdays as 'Giorni Cedolino',
			#spesa.transmissiondate as 'Data di pagamento (Distinta di trasmissione)',
			--      #output.nmov as 'Num.Mov.',
			--      #output.ymov as 'Eserc.Mov.',
			--      #output.npay as 'Num.Mandato',
			--		#output.codefin as'Bilancio del Pag.della prestazione',
			--		#output.codeupb as'UPB del Pag.della prestazione',
			CASE         
					WHEN #output.rowkind  in (1,2) then  tax.description +' (applicata) '
					WHEN #output.rowkind IN (3) then  tax.description +' (annullata) '
					ELSE tax.description
			END as 'Ritenuta',  
			#spesa.patcode as 'Codice PAT',
			#spesa.patdescription as 'PAT',
			#spesa.adminrate as 'AliquotaApplicata', 
			--#spesa.employrate as 'Aliquota Dip.', 
			--#spesa.validitystart as 'Inizio Validità PAT',
			--#spesa.validitystop		as 'Inizio Validità PAT'
			--R.p_iva as 'P.iva',
			--R.birthdate as 'data Nascita', GC.title as 'Luogo Nascita',
			--GP.province as 'Prov.Nascita', ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
			--R.gender as 'Sesso',
			--#output.desc_exp as 'Descr.Spesa',
			--#output.servicestart as 'Inizio Pres.',
			--#output.servicestop as 'Fine Prest',
			--#output.address as 'Indirizzo',
			--#output.location as 'Località',
			--#output.province as 'Provincia',
			--#output.nation as 'Stato',
			--#output.cap as 'CAP',
			--GC_rit.title as 'Comune', 
			--F.title as 'Regione Fiscale',
			#output.taxablegross as ' Imponibile Lordo',
			#output.taxablenet as 'Imponibile Netto',
			#output.employtax as 'Rit.Dip.',
			#output.admintax as 'Rit.Amm.',
			#output.abatements as 'Detrazioni Applicate'--  ,    
			--#spesa.workingdays as 'Giorni Lavorati',
        FROM #output  LEFT OUTER JOIN #spesa ON #output.idexp = #spesa.idexp
        JOIN tax				            ON tax.taxcode = #output.taxcode
        JOIN registry R		                ON #output.idreg = R.idreg
        LEFT OUTER JOIN service S           ON #output.idser = S.idser
        LEFT OUTER JOIN geo_city GC       	ON GC.idcity = R.idcity
        LEFT OUTER JOIN geo_country GP     	ON GP.idcountry = GC.idcountry
        LEFT OUTER JOIN geo_nation GN      	ON GN.idnation = R.idnation
        LEFT OUTER JOIN geo_city GC_rit    	ON GC_rit.idcity = #output.idcity
        LEFT OUTER JOIN fiscaltaxregion F  	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
		LEFT OUTER JOIN  sorting ON sorting.idsor = #spesa.idsor01 
        WHERE  #output.rowkind in (1,3)
        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description,#output.nmov
	END
 

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_ritenute_applicate_impon_notax]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_ritenute_applicate_impon_notax]
GO
 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 ---- exec exp_riepilogo_ritenute_applicate_impon_notax '2016', '22403', null, '25', {ts '2016-03-01 00:00:00.000'}, {ts '2016-03-30 00:00:00.000'}, 'S', 'N', 'N', null, null, null, null, null
 -- setuser 'amministrazione'
CREATE  PROCEDURE [exp_riepilogo_ritenute_applicate_impon_notax]
	@ayear int, 
	@idreg int, 
	@tax   int,
	@idser int,  
	@start datetime,
	@stop  datetime,
	@mode  char(1),
	@unified_mov varchar(1),
	@show_month char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

---------------------------------------------------------------------------------------------------------
-- IMPORTANTE: 
-- @show_department @show_month gestisce la visualizzazione del Dip. e del mese sarà 'S' SOLO PER ROMA!!!
---------------------------------------------------------------------------------------------------------

AS
BEGIN
DECLARE @expensephase tinyint
DECLARE @taxvaliditykind int
SELECT  @expensephase = expensephase,
	    @taxvaliditykind = taxvaliditykind  -- data competenza delle ritenute
 FROM config WHERE ayear = @ayear

-- @mode è un radio button di selezione modalità, in cui si sceglie se:
-- visualizza tutti i dettagli - T
-- visualizza i dettagli raggruppati per applicato/annullato - R
-- visualizza solo saldo ( applicato-annullato ) - S

CREATE TABLE #spesa  (
	idexp int,nmov int,ymov int,npay int,
	codefin varchar(50),
	codeupb varchar(50),
    idreg int, 
	datetaxpay datetime,
	desc_exp varchar(150),
	idser int,
	servicestart datetime,
	servicestop datetime,
	curramount decimal(19,2),
-- info relative all'indirizzo
    address varchar(100),
    location varchar(65),
    province varchar(2),
    nation varchar(65),
    cap varchar(20),
	movkind int -- solo anticipoi missione
	)
INSERT INTO #spesa   
	(idexp, nmov, ymov,npay, 
	codefin,
	codeupb,
    idreg, 
	datetaxpay,
	desc_exp,
	idser,servicestart,servicestop,
	curramount
)

SELECT 
	expense.idexp,        --> idexp dei movimenti interessati
	expense.nmov,
	expense.ymov,P.npay,
	F.codefin, U.codeupb,
	expense.idreg,
	/*CASE  @taxvaliditykind
		WHEN 1 THEN  P.transmissiondate --Data dettaglio della ritenuta (in mancanza di ritenute prendo la data trasmissione)
		WHEN 2 THEN  expense.adate		--Data contabile dell'ultima fase di spesa
		WHEN 3 THEN  P.adate			--Data contabile del mandato
		WHEN 4 THEN  P.printdate		--Data Stampa del mandato
		WHEN 5 THEN  P.transmissiondate --Data trasmissione mandato
		WHEN 6 THEN  BT.transactiondate --Data esitazione mandato
		ELSE NULL
	END  ,   */
	PC1.competencydate,
	expense.description,
	EL.idser,
	EL.servicestart,
	EL.servicestop,
	SUM(ET.curramount)
FROM expense 
JOIN expenselast EL
        ON expense.idexp = EL.idexp
JOIN paymentview P
        ON P.kpay = EL.kpay 
JOIN expenseyear
	ON EL.idexp = expenseyear.idexp
JOIN expensetotal ET
	ON ET.idexp = expenseyear.idexp
JOIN fin F
	ON expenseyear.idfin = F.idfin
JOIN upb U
	ON expenseyear.idupb = U.idupb 
left outer 	JOIN paymentcommunicated PC1		
	ON PC1.idexp = EL.idexp
WHERE expense.ymov = @ayear       
		and EL.idser is not null
		AND expenseyear.ayear = @ayear   
		AND ET.ayear = @ayear 
		AND PC1.competencydate BETWEEN @start AND @stop 
        /*AND (
			(@taxvaliditykind = 1 AND P.transmissiondate  BETWEEN @start AND @stop)
			OR (@taxvaliditykind = 2 AND expense.adate BETWEEN @start AND @stop )
			OR (@taxvaliditykind = 3 AND P.adate BETWEEN @start AND @stop )
			OR (@taxvaliditykind = 4 AND P.printdate BETWEEN @start AND @stop )
		    OR (@taxvaliditykind = 5 AND P.transmissiondate BETWEEN @start AND @stop )
		    OR (@taxvaliditykind = 6 AND BT.transactiondate BETWEEN @start AND @stop )
			)*/
        AND ( expense.idreg = @idreg OR @idreg IS NULL )
        AND (EL.idser = @idser OR @idser is null)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY expense.idreg,expense.nmov,expense.ymov,P.npay,F.codefin, U.codeupb, expense.idexp, 
	PC1.competencydate,
	expense.description,EL.idser,EL.servicestart,EL.servicestop

 -- lettura degli anticipi di missione
INSERT INTO #spesa   
	(idexp, nmov, ymov,npay, 
	codefin,
	codeupb,
    idreg, 
	datetaxpay,
	desc_exp,
	idser,servicestart,servicestop,
	curramount,
	movkind
)

SELECT 
	expense.idexp,        --> idexp dei movimenti interessati
	expense.nmov,
	expense.ymov,P.npay,
	F.codefin, U.codeupb,
	expense.idreg,
	PC1.competencydate,
	expense.description,
	IT.idser,
	NULL,
	NULL,
	sum(ET.curramount),
	EIT.movkind
FROM expense 
JOIN expenselast EL
        ON expense.idexp = EL.idexp
JOIN paymentview P
        ON P.kpay = EL.kpay 
JOIN expenseyear
	ON EL.idexp = expenseyear.idexp
JOIN fin F
	ON expenseyear.idfin = F.idfin
JOIN expensetotal ET
	ON ET.idexp = expenseyear.idexp
JOIN upb U
	ON expenseyear.idupb = U.idupb 
JOIN expenselink ELK
	ON ELK.idchild = EL.idexp
	AND ELK.nlevel = @expensephase
JOIN expenseitineration EIT
	ON EIT.idexp = ELK.idparent
	AND EIT.movkind  in (5,6)
JOIN itineration IT
	ON EIT.iditineration = IT.iditineration
left outer 	JOIN paymentcommunicated PC1		
	ON PC1.idexp = EL.idexp
WHERE expense.ymov = @ayear       
		AND expenseyear.ayear = @ayear   
		AND ET.ayear = @ayear   
		AND PC1.competencydate BETWEEN @start AND @stop 
        AND ( expense.idreg = @idreg OR @idreg IS NULL )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY expense.idreg,expense.nmov,expense.ymov,P.npay,F.codefin, U.codeupb, expense.idexp,  
	PC1.competencydate,
	expense.description,EL.idser, EIT.movkind,IT.idser

--------------------------------------------------
-- Gestione degli indirizzi
--------------------------------------------------
CREATE TABLE #employ (idreg int)

INSERT INTO #employ (idreg) SELECT DISTINCT idreg FROM #spesa

CREATE TABLE #address_employ(
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

INSERT INTO #address_employ(
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
	



--------------------------------------------------
-- Fine gestione indirizzi
--------------------------------------------------
-- In #tax lui ha le righe relative alle ritenute applicate con rowkind= 1 ed eventualmente con rowkind =2
-- e le righe relative alle ritenute annullate con rowkind = 3.
-- In #output lui riversa il contenuto di #tax per poi calcolarsi il saldo, nel caso si scelga @mode=S,  o il 
-- raggruppamento dele applicate nel caso si scalga @mode =R

-- In caso di @mode = S le righe del saldo saranno marcate con rowkind=4
-- Nel caso di @mode = R, lui inserisce in #output la somma delle righe 1 e 2, marcando questa riga
-- con rowkind= 5, e nella SELECT finale prenderà quelle che hanno rowkind = 5 (applicate) e rowkind = 3 (annullate)
-- Questo è il motivo per cui nasce #output.
-- Se poi ho scelto #mode = T farà una SELECT delle rowkind =1,2,3.

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
		movkind int
)

-- Se non è il Roma azzero il mese affinchè non contribuisca a ragguppamenti sucessivi
-- se inceve è Roma allora il mese sarà un altro criterio di raggruppamento


-- Se ho deciso di consolidare, non verranno visualizzate le info del mov. di spesa
-- e della prestazione, quindi li azzero per accelerare le operazioni di raggruppamento siccessive.
--select * from #spesa
IF (@unified_mov = 'S') UPDATE  #spesa
		SET
		nmov = NULL,	
		ymov = NULL,
		desc_exp = NULL,
		idser = NULL,
		servicestart= null,
		servicestop = null

IF ( @unified_mov = 'N' )
BEGIN
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
		idfiscaltaxregion,
		movkind
	)
	SELECT
		idreg,idexp,
		nmov,
		ymov,npay,
		codefin,codeupb,
		desc_exp,
		idser,servicestart,servicestop,
		null as monthtaxpay,
		null as cf, 
		null as p_iva,
		null as address,
		null as location,
		null AS province,
		null as nation,
		null as cap, 
		null as taxcode,
		sum(curramount),
		sum(curramount),
		null as employtax,
		null as admintax,
		null as abatements,
		null as rowkind,
		null as idcity,
		null as idfiscaltaxregion,
		movkind
	FROM #spesa
	GROUP BY idreg,idexp,nmov,ymov,npay,codefin,codeupb, desc_exp,idser,servicestart,servicestop,movkind
	ORDER BY idreg 
END
ELSE

BEGIN

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
	idfiscaltaxregion,
	movkind 
)
SELECT
	idreg,
	null,
	null,
	null,null,
	null,null,
	null,
	idser,servicestart,servicestop,
	null as monthtaxpay,
	null as cf, 
	null as p_iva,
	null as address,
	null as location,
	null as province,
	null as nation,
	null as cap, 
	null as taxcode,
	isnull(sum(curramount),0),
	isnull(sum(curramount),0),
	null as employtax,
	null as admintax,
	null as abatements,
	null as rowkind,
	null as idcity,
	null as idfiscaltaxregion,
	movkind 
FROM #spesa
GROUP BY idreg, address,location,province,nation,cap,idser,servicestart,servicestop,movkind
ORDER BY idreg 
END

-- Inserimento del corretto indirizzo del soggetto a ritenuta
UPDATE #output SET
	address = i1.address,
	location = i1.location,
	province = i1.province,
	nation = ISNULL(i1.nation,'ITALIA'),
	cap = i1.cap
FROM #address_employ i1
WHERE #output.idreg = i1.idreg


IF ( @unified_mov = 'S' )
-- Si è scelto di CONSOLIDARE, quindi si vogliono consolidare i movimenti per Percipiente.
BEGIN
        IF (@show_month = 'S') 
		BEGIN
	        SELECT
					null as 'Mese',
	                R.title as Percipiente,
	        		ISNULL(R.cf, R.foreigncf) as 'CF',
	                CASE  #output.movkind
						WHEN 6 THEN 'Ant. Miss. su Capitolo di Spesa'
						WHEN 5 THEN 'Ant. Miss. Su  Partita di giro'
						ELSE NULL
					END as 'Ritenuta' ,      
	                R.surname as 'Cognome', R.forename as 'Nome',
	                R.p_iva as 'P.iva',
					R.birthdate as 'data Nascita', GC.title as 'Luogo Nascita',
					GP.province as 'Prov.Nascita', ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
	        		R.gender as 'Sesso',
	                #output.address as 'Indirizzo',
	            	#output.location as 'Località',
	            	#output.province as 'Provincia',
	            	#output.nation as 'Stato',
	            	#output.cap as 'CAP',
	                null as 'Comune', 
	                null as 'Regione Fiscale',
	                #output.taxablegross  as ' Imponibile Lordo',
	                #output.taxablenet as 'Imponibile Netto',
	                #output.employtax as 'Rit.Dip.',
	                #output.admintax as 'Rit.Amm.',
	                #output.abatements as 'Detrazioni Applicate' 
	        FROM #output
	        JOIN registry R
	                ON #output.idreg = R.idreg
			LEFT OUTER JOIN geo_city GC
        		ON GC.idcity = R.idcity
			LEFT OUTER JOIN geo_country GP
        		ON GP.idcountry = GC.idcountry
			LEFT OUTER JOIN geo_nation GN
        		ON GN.idnation = R.idnation
	        ORDER BY R.title,ISNULL(R.cf, R.foreigncf)
		End

        IF (@show_month = 'N') 
		BEGIN
	        SELECT
	                R.title as Percipiente,
	        		ISNULL(R.cf, R.foreigncf) as 'CF',
	                CASE  #output.movkind
						WHEN 6 THEN 'Ant. Miss. su Capitolo di Spesa'
						WHEN 5 THEN 'Ant. Miss. Su  Partita di giro'
						ELSE NULL
					END as 'Ritenuta' ,
	                R.surname as 'Cognome', R.forename as 'Nome',
	                R.p_iva as 'P.iva',
					R.birthdate as 'data Nascita', GC.title as 'Luogo Nascita',
					GP.province as 'Prov.Nascita', ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
	        		R.gender as 'Sesso',
	                #output.address as 'Indirizzo',
	            	#output.location as 'Località',
	            	#output.province as 'Provincia',
	            	#output.nation as 'Stato',
	            	#output.cap as 'CAP',
	                null as 'Comune', 
	                null as 'Regione Fiscale',
					#output.taxablegross  as ' Imponibile Lordo',
	                #output.taxablenet as 'Imponibile Netto',
	                #output.employtax as 'Rit.Dip.',
	                #output.admintax as 'Rit.Amm.',
	                #output.abatements as 'Detrazioni Applicate'
					     
	        FROM #output
	        JOIN registry R
	                ON #output.idreg = R.idreg
			LEFT OUTER JOIN geo_city GC
        		ON GC.idcity = R.idcity
			LEFT OUTER JOIN geo_country GP
        		ON GP.idcountry = GC.idcountry
			LEFT OUTER JOIN geo_nation GN
        		ON GN.idnation = R.idnation
	        ORDER BY R.title,ISNULL(R.cf, R.foreigncf)
		End
END-- (@unified_mov = 'S')

ELSE
-- (@unified_mov = 'N')
-- vuol dire che si è scelto di NON CONSOLIDARE, quindi si vuole distinguire i singoli movimenti per percipiente
BEGIN
	IF (@show_month='S')
	BEGIN	
      	SELECT	
				null as 'Mese',
                nmov as 'Num.Mov.',
                ymov as 'Eserc.Mov.',
                npay as 'Num.Mandato',
				codefin as'Bilancio del Pag.della prestazione',
				codeupb as'UPB del Pag.della prestazione',
                R.title as Percipiente,
        		ISNULL(R.cf, R.foreigncf) as 'CF',
				CASE  #output.movkind
						WHEN 6 THEN 'Ant. Miss. su Capitolo di Spesa'
						WHEN 5 THEN 'Ant. Miss. Su  Partita di giro'
						ELSE NULL
				END as 'Ritenuta' , 
                R.surname as 'Cognome', R.forename as 'Nome',
                R.p_iva as 'P.iva',
                R.birthdate as 'data Nascita', GC.title as 'Luogo Nascita',
                GP.province as 'Prov.Nascita', ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
        		R.gender as 'Sesso',
				desc_exp as 'Descr.Spesa',
				S.description as 'Prestazione',
				#output.servicestart as 'Inizio Pres.',
				#output.servicestop as 'Fine Prest',
                #output.address as 'Indirizzo',
            	#output.location as 'Località',
                #output.province as 'Provincia',
            	#output.nation as 'Stato',
            	#output.cap as 'CAP',
                null as 'Comune', 
                null as 'Regione Fiscale',
                #output.taxablegross as ' Imponibile Lordo',
                #output.taxablenet as 'Imponibile Netto',
                #output.employtax as 'Rit.Dip.',
                #output.admintax as 'Rit.Amm.',
                #output.abatements as 'Detrazioni Applicate'         
        FROM #output
        JOIN registry R
                ON #output.idreg = R.idreg
        LEFT OUTER JOIN service S
                ON #output.idser = S.idser
        LEFT OUTER JOIN geo_city GC
        	ON GC.idcity = R.idcity
        LEFT OUTER JOIN geo_country GP
        	ON GP.idcountry = GC.idcountry
        LEFT OUTER JOIN geo_nation GN
        	ON GN.idnation = R.idnation
        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),nmov
	End
	IF (@show_month='N')
	BEGIN	
      	SELECT	
                nmov as 'Num.Mov.',
                ymov as 'Eserc.Mov.',
                npay as 'Num.Mandato',
				codefin as'Bilancio del Pag.della prestazione',
				codeupb as'UPB del Pag.della prestazione',
                R.title as Percipiente,
        		ISNULL(R.cf, R.foreigncf) as 'CF',
				CASE  #output.movkind
						WHEN 6 THEN 'Ant. Miss. su Capitolo di Spesa'
						WHEN 5 THEN 'Ant. Miss. Su  Partita di giro'
						ELSE NULL
				END as 'Ritenuta' ,   
                R.surname as 'Cognome', R.forename as 'Nome',
                R.p_iva as 'P.iva',
                R.birthdate as 'data Nascita', GC.title as 'Luogo Nascita',
                GP.province as 'Prov.Nascita', ISNULL(GN.title,'ITALIA') as 'Stato Nascita',
        		R.gender as 'Sesso',
				desc_exp as 'Descr.Spesa',
				S.description as 'Prestazione',
				#output.servicestart as 'Inizio Pres.',
				#output.servicestop as 'Fine Prest',
                #output.address as 'Indirizzo',
            	#output.location as 'Località',
                #output.province as 'Provincia',
            	#output.nation as 'Stato',
            	#output.cap as 'CAP',
                null as 'Comune', 
                null as 'Regione Fiscale',
                #output.taxablegross as ' Imponibile Lordo',
                #output.taxablenet as 'Imponibile Netto',
                #output.employtax as 'Rit.Dip.',
                #output.admintax as 'Rit.Amm.',
                #output.abatements as 'Detrazioni Applicate'      
        FROM #output
        JOIN registry R
                ON #output.idreg = R.idreg
        LEFT OUTER JOIN service S
                ON #output.idser = S.idser
        LEFT OUTER JOIN geo_city GC
        	ON GC.idcity = R.idcity
        LEFT OUTER JOIN geo_country GP
        	ON GP.idcountry = GC.idcountry
        LEFT OUTER JOIN geo_nation GN
        	ON GN.idnation = R.idnation
        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),nmov
	End
END --  (@unified_mov = 'N') 

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



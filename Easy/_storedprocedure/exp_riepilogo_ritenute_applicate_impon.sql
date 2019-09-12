if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_ritenute_applicate_impon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_ritenute_applicate_impon]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [exp_riepilogo_ritenute_applicate_impon]
	@ayear int, 
	@idreg int, 
	@tax   int,
	@idser int,  
	@start date,
	@stop  date,
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


-- @mode è un radio button di selezione modalità, in cui si sceglie se:
-- visualizza tutti i dettagli - T
-- visualizza i dettagli raggruppati per applicato/annullato - R
-- visualizza solo saldo ( applicato-annullato ) - S

CREATE TABLE #spesa  (
	idexp int,nmov int,ymov int,npay int,
	codefin varchar(50),
	codeupb varchar(50),
    idreg int, 
	datetaxpay date,
	desc_exp varchar(150),
	idser int,
	servicestart date,
	servicestop date
	)
INSERT INTO #spesa   
	(idexp, nmov, ymov,npay, 
	codefin,
	codeupb,
    idreg, 
	datetaxpay,
	desc_exp,
	idser,servicestart,servicestop
)

SELECT 
	E.idexp,        --> idexp dei movimenti interessati
	expense.nmov,
	expense.ymov,P.npay,
	F.codefin, U.codeupb,
	expense.idreg,
	E.datetaxpay,
	expense.description,
	EL.idser,
	EL.servicestart,
	EL.servicestop
FROM expensetaxview AS E 
JOIN expense 
        ON expense.idexp = E.idexp
JOIN expenselast EL
        ON expense.idexp = EL.idexp
JOIN payment P
        ON P.kpay = EL.kpay 
JOIN expenseyear
	ON EL.idexp = expenseyear.idexp
JOIN fin F
	ON expenseyear.idfin = F.idfin
JOIN upb U
	ON expenseyear.idupb = U.idupb 
WHERE expense.ymov = @ayear       
		AND expenseyear.ayear = @ayear   
        AND (E.taxcode = @tax OR @tax IS NULL)
        AND E.datetaxpay is not null
        AND (E.datetaxpay BETWEEN @start AND @stop )
        AND ( expense.idreg = @idreg OR @idreg IS NULL )
        AND (EL.idser = @idser OR @idser is null)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY expense.idreg,expense.nmov,expense.ymov,P.npay,F.codefin, U.codeupb,E.idexp, E.datetaxpay,
	expense.description,EL.idser,EL.servicestart,EL.servicestop

CREATE TABLE #tax
(
        idreg int,
-- le info relative al mov. di spesa e alla prestazione
-- andranno visualizzate in caso di NON consolidamento
	desc_exp varchar(150),
	idser int,
	servicestart date,
	servicestop date,
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
JOIN #spesa S 
        ON S.idexp = E.idexp
WHERE  (E.taxcode = @tax OR @tax IS NULL)
AND E.start IS NULL
GROUP BY E.idexp,S.nmov, S.ymov, S.npay,S.codefin, S.codeupb,S.idreg,E.taxcode, E.stop,S.datetaxpay,
	E.idcity,E.idfiscaltaxregion,S.desc_exp,
	S.idser,S.servicestart,S.servicestop 

-- Raggruppare anche per start e/o stop  mi serve per distinguere le correzioni, 
-- se ho inserito 2 correzioni IRPEF nella stampa devo vedere 2 correzioni

/*        2) Prendere le righe che hanno Data Inizio Validità compresa nel range di date di input        */
-- Correzioni fatte nel periodo

INSERT INTO #tax
(	
        nmov,
		ymov,npay,
		codefin,codeupb,
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
	S.ymov,P.npay,
	F.codefin, U.codeupb,
        month(E.start),
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
        case when ( @mode ='T' ) 
                then 2        -- si desidera tutti i dettagli 
                else 1        -- si desidera raggrupparli   
        end,
        E.idcity,
	E.idfiscaltaxregion,
	S.description,
	EL.idser,EL.servicestart,EL.servicestop 
FROM expensetaxofficial E
JOIN expense S 
        ON S.idexp = E.idexp
JOIN expenselast EL 
        ON S.idexp = EL.idexp
JOIN payment P
        ON P.kpay = EL.kpay
JOIN expenseyear
	ON EL.idexp = expenseyear.idexp
JOIN fin F
	ON expenseyear.idfin = F.idfin
JOIN upb U
	ON expenseyear.idupb = U.idupb 
WHERE expenseyear.ayear = @ayear
		AND  (E.taxcode = @tax OR @tax IS NULL)
        AND		E.start between @start and @stop
        AND ( S.idreg = @idreg OR @idreg IS NULL )
        AND ( EL.idser = @idser OR @idser IS NULL )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY E.idexp,S.nmov, S.ymov,P.npay, F.codefin, U.codeupb,S.idreg,E.taxcode, E.start, E.stop,
	E.idcity,E.idfiscaltaxregion,S.description,
	EL.idser,EL.servicestart,EL.servicestop 
 

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
JOIN expense S 
        ON S.idexp = E.idexp
JOIN expenselast EL 
        ON S.idexp = EL.idexp
JOIN payment P
        ON P.kpay = EL.kpay
JOIN expenseyear
	ON EL.idexp = expenseyear.idexp
JOIN fin F
	ON expenseyear.idfin = F.idfin
JOIN upb U
	ON expenseyear.idupb = U.idupb 
WHERE expenseyear.ayear = @ayear
		AND  (E.taxcode = @tax OR @tax IS NULL)
        AND E.stop between @start and @stop
        AND ( S.idreg = @idreg OR @idreg IS NULL )
        AND ( EL.idser = @idser OR @idser IS NULL )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY E.idexp,S.nmov,S.ymov,P.npay, F.codefin, U.codeupb, S.idreg,E.taxcode, E.start, E.stop,
      E.idcity,E.idfiscaltaxregion,S.description,
	EL.idser,EL.servicestart,EL.servicestop  

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
		servicestart date,
		servicestop date,
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
		idfiscaltaxregion varchar(5)
)

-- Se non è il Roma azzero il mese affinchè non contribuisca a ragguppamenti sucessivi
-- se inceve è Roma allora il mese sarà un altro criterio di raggruppamento

IF (@show_month<>'S') UPDATE #tax SET monthtaxpay = NULL

-- Se ho deciso di consolidare, non verranno visualizzate le info del mov. di spesa
-- e della prestazione, quindi li azzero per accelerare le operazioni di raggruppamento siccessive.

IF (@unified_mov = 'S') UPDATE  #tax 
		SET
		nmov = NULL,	
		ymov = NULL,
		desc_exp = NULL,
		idser = NULL,
		servicestart= null,
		servicestop = null

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
	SUM(taxablegross),
	SUM(taxablenet),
	SUM(employtax),
	SUM(admintax),
	SUM(abatements),
	rowkind, -- vale: 1, 2, 3.
	idcity,
	idfiscaltaxregion 
FROM #tax
GROUP BY idreg,idexp,nmov,ymov,npay,codefin,codeupb,monthtaxpay, cf, p_iva, taxcode,rowkind,
        idcity,idfiscaltaxregion,
        address,location,province,nation,cap,
	desc_exp,idser,servicestart,servicestop
ORDER BY idreg,rowkind,taxcode

IF ( @unified_mov = 'S' )
-- Si è scelto di CONSOLIDARE, quindi si vogliono consolidare i movimenti per Percipiente.
BEGIN
        -- Per ogni percipiente, calcola e inserisce la riga del saldo per ogni ritenuta ad esso associata,
        -- marcando la riga del saldo come rowkind = 4 
        IF (@mode = 'S')
        Begin
      	  	INSERT INTO #output
                (
                        idreg,
                        taxcode,
                        taxablegross,
                        taxablenet,
                        employtax,
                        admintax,
                        abatements,
                        rowkind,monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap  
                )
                SELECT         
                        idreg,
                        taxcode,
                        ISNULL(
                                (SELECT SUM(T2.taxablegross)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S' AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')
                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.taxablegross)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.taxablenet)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.taxablenet)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.employtax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.employtax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.admintax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.admintax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.abatements)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.abatements)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        4, --> Riga del Saldo
                        monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap 
                FROM #tax
                GROUP BY  idreg,taxcode,monthtaxpay,address,location,province,nation,cap,idcity,idfiscaltaxregion  
        End

        -- Si è scelto di raggruppare per Applicate/Annullate, allora per ogni percipiente, raggruppa e inserisce
	-- in #output le ritenute applicate, ossia raggruppa le rowkind = 1 e 2, marcando la riga nuova 
	-- con rowkind = 4 
        IF (@mode = 'R')
        Begin
        	INSERT INTO #output
                (
                        idreg,
                        taxcode,
                        taxablegross,
                        taxablenet,
                        employtax,
                        admintax,
                        abatements,
                        rowkind,monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap 
                )
                SELECT         
                        idreg,
                        taxcode,
                        ISNULL(
                                (SELECT SUM(T2.taxablegross)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.taxablenet)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.employtax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.admintax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.abatements)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        5, --> Righe 1 e 2 raggruppate 
                        monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap 
                FROM #tax
                GROUP BY  idreg,taxcode,monthtaxpay,address,location,province,nation,cap,idcity,idfiscaltaxregion  
        End

        -- Quindi adesso
        -- riga 1 -> rit. Applicate
        -- riga 2 -> rit. Applicate
        -- riga 3 -> rit. Annullate
        -- riga 4 -> Saldo
        -- riga 5 -> rit. Applicate ottenute come 1+2

        IF (@show_month = 'S') 
		BEGIN
	        SELECT
					convert(char(2),monthtaxpay) as 'Mese ',
	                R.title as Percipiente,
	        		ISNULL(R.cf, R.foreigncf) as 'CF',
	                CASE         
	                        WHEN rowkind  in (1,2,5) then  tax.description +' (applicata) '
	                        WHEN rowkind IN (3) then  tax.description +' (annullata) '
	                        ELSE tax.description
	                END as 'Ritenuta',  
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
	                GC_rit.title as 'Comune', 
	                F.title as 'Regione Fiscale',
	                #output.taxablegross as ' Imponibile Lordo',
	                #output.taxablenet as 'Imponibile Netto',
	                #output.employtax as 'Rit.Dip.',
	                #output.admintax as 'Rit.Amm.',
	                #output.abatements as 'Detrazioni Applicate'      
	        FROM #output
	        JOIN tax
	                ON tax.taxcode = #output.taxcode
	        JOIN registry R
	                ON #output.idreg = R.idreg
	        LEFT OUTER JOIN geo_city GC
	        	ON GC.idcity = R.idcity
	        LEFT OUTER JOIN geo_country GP
	        	ON GP.idcountry = GC.idcountry
	        LEFT OUTER JOIN geo_nation GN
	        	ON GN.idnation = R.idnation
	        LEFT OUTER JOIN geo_city GC_rit
	        	ON GC_rit.idcity = #output.idcity
	        LEFT OUTER JOIN fiscaltaxregion F
	        	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
	        WHERE   (@mode='S' and #output.rowkind = 4)
	                OR (@mode='R' and #output.rowkind in (3,5))
	                OR (@mode='T' and #output.rowkind in (1,2,3))
	        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description
	END

    IF (@show_month = 'N')  
	BEGIN
	        SELECT
	                R.title as Percipiente,
	        		ISNULL(R.cf, R.foreigncf) as 'CF',
	                CASE         
	                        WHEN rowkind  in (1,2,5) then  tax.description +' (applicata) '
	                        WHEN rowkind IN (3) then  tax.description +' (annullata) '
	                        ELSE tax.description
	                END as 'Ritenuta',  
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
	                GC_rit.title as 'Comune', 
	                F.title as 'Regione Fiscale',
	                #output.taxablegross as ' Imponibile Lordo',
	                #output.taxablenet as 'Imponibile Netto',
	                #output.employtax as 'Rit.Dip.',
	                #output.admintax as 'Rit.Amm.',
	                #output.abatements as 'Detrazioni Applicate'      
	        FROM #output
	        JOIN tax
	                ON tax.taxcode = #output.taxcode
	        JOIN registry R
	                ON #output.idreg = R.idreg
	        LEFT OUTER JOIN geo_city GC
	        	ON GC.idcity = R.idcity
	        LEFT OUTER JOIN geo_country GP
	        	ON GP.idcountry = GC.idcountry
	        LEFT OUTER JOIN geo_nation GN
	        	ON GN.idnation = R.idnation
	        LEFT OUTER JOIN geo_city GC_rit
	        	ON GC_rit.idcity = #output.idcity
	        LEFT OUTER JOIN fiscaltaxregion F
	        	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
	        WHERE   (@mode='S' and #output.rowkind = 4)
	                OR (@mode='R' and #output.rowkind in (3,5))
	                OR (@mode='T' and #output.rowkind in (1,2,3))
	        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description
	END

END-- (@unified_mov = 'S')

ELSE
-- (@unified_mov = 'N')
-- vuol dire che si è scelto di NON CONSOLIDARE, quindi si vuole distinguire i singoli movimenti per percipiente
BEGIN
        -- Per ogni percipiente, calcola e inserisce la riga del saldo per ogni ritenuta ad esso associata,
        -- marcando la riga del saldo come rowkind = 4 
        IF (@mode = 'S')
        Begin
        	INSERT INTO #output
                (
                        idreg,nmov,ymov,npay,
						codefin,codeupb,
						desc_exp,
						idser,servicestart,servicestop,
                        taxcode,
                        taxablegross,
                        taxablenet,
                        employtax,
                        admintax,
                        abatements,
                        rowkind,monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap 
                )
                SELECT         
                        idreg,nmov,ymov,npay,
						codefin,codeupb,
						desc_exp,
						idser,servicestart,servicestop,
                        taxcode,
                        ISNULL(
                                (SELECT SUM(T2.taxablegross)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2) 
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.taxablegross)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3                                         
                                       AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.taxablenet)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2) 
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.taxablenet)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3 
                                       AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.employtax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2) 
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.employtax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3
                                       AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.admintax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2) 
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.admintax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3 
                                       AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.abatements)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2) 
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0)
                                -
                                ISNULL(
                                (SELECT SUM(T2.abatements)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                       AND T2.rowkind =3 
                                       AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')

                                ),0),
                        4, --> Riga del Saldo
                        monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap 
                FROM #tax
                GROUP BY  idreg,nmov,ymov,npay,	codefin,codeupb,taxcode,monthtaxpay,address,location,province,nation,cap,
					idcity,idfiscaltaxregion,  
					desc_exp,idser,servicestart,servicestop

        End

        -- Si è scelto di raggruppare per Applicate/Annullate, allora per ogni percipiente, raggruppa e inserisce
	-- in #output le ritenute applicate, ossia raggruppa le rowkind = 1 e 2, marcando la riga nuova 
	-- riga con rowkind = 4 
        IF (@mode = 'R')
        Begin
        	INSERT INTO #output
                (
                        idreg,nmov,ymov,npay,
						codefin,codeupb,
						desc_exp,
						idser,servicestart,servicestop,
                        taxcode,
                        taxablegross,
                        taxablenet,
                        employtax,
                        admintax,
                        abatements,
                        rowkind,monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap  
                )
                SELECT         
                        idreg,nmov,ymov,npay,
						codefin,codeupb,
						desc_exp,
						idser,servicestart,servicestop,
                        taxcode,
                        ISNULL(
                                (SELECT SUM(T2.taxablegross)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')
                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.taxablenet)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')
                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.employtax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')
                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.admintax)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')
                                ),0),
                        ISNULL(
                                (SELECT SUM(T2.abatements)
                                FROM #tax T2
                                WHERE T2.taxcode = #tax.taxcode AND T2.idreg = #tax.idreg
                                        AND T2.rowkind in (1,2)
                                        AND T2.nmov = #tax.nmov AND T2.ymov = #tax.ymov
                                        AND ( @show_month = 'S'AND #tax.monthtaxpay=T2.monthtaxpay
                                                 OR @show_month <> 'S')
                                ),0),
                        5, --> Righe 1 e 2 raggruppate 
                        monthtaxpay,
                        idcity,idfiscaltaxregion, 
                        address,location,province,nation,cap 
                FROM #tax
                GROUP BY  idreg,nmov,ymov,npay,	codefin,codeupb,taxcode, monthtaxpay,address,location,province,nation,
			cap,idcity,idfiscaltaxregion, 
			desc_exp,idser,servicestart,servicestop
        End
        -- Quindi adesso
        -- riga 1 -> rit. Applicate
        -- riga 2 -> rit. Applicate
        -- riga 3 -> rit. Annullate
        -- riga 4 -> Saldo
        -- riga 5 -> rit. Applicate ottenute come 1+2
	
	IF (@show_month='S')
	BEGIN
      	SELECT
	        convert(char(2),monthtaxpay) as 'Mese ',
                nmov as 'Num.Mov.',
                ymov as 'Eserc.Mov.',
                npay as 'Num.Mandato',
				codefin as'Bilancio del Pag.della prestazione',
				codeupb as'UPB del Pag.della prestazione',
                R.title as Percipiente,
        	ISNULL(R.cf, R.foreigncf) as 'CF',
                CASE         
                        WHEN rowkind  in (1,2,5) then  tax.description +' (applicata) '
                        WHEN rowkind IN (3) then  tax.description +' (annullata) '
                        ELSE tax.description
                END as 'Ritenuta',  
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
                GC_rit.title as 'Comune', 
                F.title as 'Regione Fiscale',
                #output.taxablegross as ' Imponibile Lordo',
                #output.taxablenet as 'Imponibile Netto',
                #output.employtax as 'Rit.Dip.',
                #output.admintax as 'Rit.Amm.',
                #output.abatements as 'Detrazioni Applicate'      
        FROM #output
        JOIN tax
                ON tax.taxcode = #output.taxcode
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
        LEFT OUTER JOIN geo_city GC_rit
        	ON GC_rit.idcity = #output.idcity
        LEFT OUTER JOIN fiscaltaxregion F
        	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
        WHERE   (@mode='S' and #output.rowkind = 4)
                OR (@mode='R' and #output.rowkind in (3,5))
                OR (@mode='T' and #output.rowkind in (1,2,3))
        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description,nmov
	END

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
                CASE         
                        WHEN rowkind  in (1,2,5) then  tax.description +' (applicata) '
                        WHEN rowkind IN (3) then  tax.description +' (annullata) '
                        ELSE tax.description
                END as 'Ritenuta',  
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
                GC_rit.title as 'Comune', 
                F.title as 'Regione Fiscale',
                #output.taxablegross as ' Imponibile Lordo',
                #output.taxablenet as 'Imponibile Netto',
                #output.employtax as 'Rit.Dip.',
                #output.admintax as 'Rit.Amm.',
                #output.abatements as 'Detrazioni Applicate'      
        FROM #output
        JOIN tax
                ON tax.taxcode = #output.taxcode
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
        LEFT OUTER JOIN geo_city GC_rit
        	ON GC_rit.idcity = #output.idcity
        LEFT OUTER JOIN fiscaltaxregion F
        	ON F.idfiscaltaxregion = #output.idfiscaltaxregion
        WHERE   (@mode='S' and #output.rowkind = 4)
                OR (@mode='R' and #output.rowkind in (3,5))
                OR (@mode='T' and #output.rowkind in (1,2,3))
        ORDER BY R.title,ISNULL(R.cf, R.foreigncf),tax.description,nmov
	END


END --  (@unified_mov = 'N') 

END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[fn_detrazione_coniuge_fascia1]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_detrazione_coniuge_fascia1
GO
CREATE FUNCTION [DBO].fn_detrazione_coniuge_fascia1(@reddito decimal(19,2),@mesi int) returns decimal(19,2) AS 
BEGIN
	declare @i int
	set @i = (@reddito / 15000.0) * 10000.0
	if (@i <= 0) return 0
	if (@i < 10000) return 800 - ( ((110*@i) / 10000.0)  *@mesi)/12.0;	
	return 800 - 110;
END

GO

 
if exists (select * from dbo.sysobjects where id = object_id(N'[fn_detrazione_coniuge_fascia2]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_detrazione_coniuge_fascia2
GO
CREATE FUNCTION [DBO].fn_detrazione_coniuge_fascia2(@reddito decimal(19,2),@mesi int) returns decimal(19,2) AS 
BEGIN
	declare @detrazione decimal(19,2)
	set @detrazione = 690.0*@mesi/12.0
	if (@reddito > 29000 and @reddito <= 29200) return @detrazione+10;
	if (@reddito > 29200 and @reddito <= 34700) return @detrazione+20;
	if (@reddito > 34700 and @reddito <= 35000) return @detrazione+30;
	if (@reddito > 35000 and @reddito <= 35100) return @detrazione+20;
	if (@reddito > 35100 and @reddito <= 35200) return @detrazione+10;
	return @detrazione;
END

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[fn_detrazione_coniuge_fascia3]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_detrazione_coniuge_fascia3
GO
CREATE FUNCTION [DBO].fn_detrazione_coniuge_fascia3(@reddito decimal(19,2),@mesi int) returns decimal(19,2) AS 
BEGIN
	declare @importo decimal(19,2)
	set @importo = ((80000.0  - @reddito) / 40000  ) * 10000;
	declare @i int
	set @i = @importo
	if (@i<=0) return 0;
	if (@i < 10000) return (  ((690 * @i) / 10000))*@mesi / 12.0
	return 690*@mesi / 12.0;
END

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[fn_calcola_detrazione_coniuge_su_fascia]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_calcola_detrazione_coniuge_su_fascia
GO
CREATE FUNCTION [DBO].fn_calcola_detrazione_coniuge_su_fascia(@reddito decimal(19,2), @mesi int) returns decimal(19,2) AS 
BEGIN
	declare @max_fascia1 decimal(19,2)
	set @max_fascia1=15000
	declare @max_fascia2 decimal(19,2)
	set @max_fascia2=40000
	declare @max_fascia3 decimal(19,2)
	set @max_fascia3=80000

	if (@reddito<= @max_fascia1) return DBO.fn_detrazione_coniuge_fascia1(@reddito,@mesi)
	if (@reddito<= @max_fascia2) return DBO.fn_detrazione_coniuge_fascia2(@reddito,@mesi)
	if (@reddito<= @max_fascia3) return DBO.fn_detrazione_coniuge_fascia3(@reddito,@mesi)
	return 0
END

GO




if exists (select * from dbo.sysobjects where id = object_id(N'[fn_detrazione_figli]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_detrazione_figli
GO
CREATE FUNCTION [DBO].fn_detrazione_figli(@detrazionebase decimal(19,2),@reddito decimal(19,2), @nfigli_anno int) returns decimal(19,2) AS 
BEGIN
	declare @inc decimal(19,2)
	set @inc = 15000 * (@nfigli_anno-1)
	declare @M decimal(19,2)
	set @M = 95000 + @inc
	declare @r decimal(19,6)
	set @r = ( (@M-@reddito) / @M) * 10000
	declare @i int
	set @i  = @r
	if (@i<=0) return 0
	if (@i< 10000) return  (@detrazionebase * @i) / 10000;
	return @detrazionebase
END
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[fn_scegliDetrazionePerFiglio]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_scegliDetrazionePerFiglio
GO
CREATE FUNCTION [DBO].fn_scegliDetrazionePerFiglio(@datarif DateTime, @starthandicap DateTime, @birthdate DateTime, @nfigli_anno int,
								@inizioApplicazione DateTime, @fineApplicazione DateTime, @percApplicazione float) returns decimal(19,2) AS 
BEGIN
	if (ROUND(@percApplicazione,2)=0) return 0;
	declare @MDProg decimal(19,2)    
	set @MDProg = 0
	declare @D_BASE decimal(19,2)
	set  @D_BASE= 950
	declare @PLUS_NO_3ANNI decimal(19,2)
	set  @PLUS_NO_3ANNI= 270
	declare @PLUS_HANDICAP decimal(19,2)
	set  @PLUS_HANDICAP= 400
	declare @PLUS_4FIGLI decimal(19,2)
	set  @PLUS_4FIGLI= 200
	declare @MD decimal(19,2)
	declare @primogen datetime
	set @primogen = dateadd(yy, year(@datarif)-2000, {d '2000-01-01'})
	declare @handicap datetime
	set @handicap = @starthandicap
	if (@handicap is not null and @handicap <= @primogen) set @handicap= @primogen
	declare @etainmesi int


	declare @progmese int
	set @progmese =0
	while (@progmese < 12) BEGIN
		set @progmese = @progmese +1 -- @progmese va da 1 a 12
		if (year(@inizioApplicazione) > year(@datarif) )continue;
		if (year(@inizioApplicazione) = year(@datarif) AND month(@inizioApplicazione) > @progmese)continue;
		if (year(@fineApplicazione) < year(@datarif) )continue;
		if (year(@fineApplicazione) = year(@datarif) AND month(@fineApplicazione) < @progmese)continue;

		--if (@progmese < month(@inizioApplicazione)) OR  (@progmese > month(@fineApplicazione)) continue;
		set @MD = @D_BASE

		-- Se ci sono almeno 4 figli viene aggiunta una detrazione di 200 €
        if (@nfigli_anno > 3) BEGIN
            SET @MD = @MD + @PLUS_4FIGLI;
        END

		if (@handicap is not null and month(@handicap) <= @progmese)begin
			SET @MD = @MD + @PLUS_HANDICAP;
		end
		if (@birthdate is not null) BEGIN
			set @etainmesi = 12 *(year(@datarif)-year(@birthdate))  + @progmese - month(@birthdate);
			if (@etainmesi <=36) set @MD  = @MD + @PLUS_NO_3ANNI
		END
		set @MDProg = @MDProg+ (@MD* @percApplicazione)
	END

	set @MDProg = @MDProg / 12
	RETURN round(@MDProg,2)
END

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[fn_detrazione_altri]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function fn_detrazione_altri
GO
CREATE FUNCTION [DBO].fn_detrazione_altri(@reddito decimal(19,2), @mesi int) returns decimal(19,2) AS 
BEGIN
	declare @r decimal(19,6)
	set @r =  (  (80000 - @reddito) / 80000) * 10000
	declare @i int
	set @i=@r
	if (@i<=0) return 0;
	if (@i< 10000) return ((750*@i)/10000)*@mesi / 12.0	

	RETURN round(750*@mesi / 12.0,2)
END
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[check_detrazioni_familiari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_detrazioni_familiari]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   procedure check_detrazioni_familiari (
@idreg int,
@annoredditi smallint,
@res int out
) as
BEGIN
	set @res=0
	SET NOCOUNT ON;

	declare @1gen15_XXX datetime
	set @1gen15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})
	declare @31dic15_XXX datetime
	set @31dic15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen16_XXX datetime
	set @1gen16_XXX =  dateadd(yy, @annoredditi-2000, {d '2001-01-01'})

	-- Tabella dei cedolini
	create table #cedolini (
		idpayroll int, 
		idexp int,
		idcon varchar(8),
		datacompetenza datetime, 
		startpayroll datetime,
		stoppayroll datetime,
		compensoprev decimal(19,2),
		ritprevtrattenuta decimal(19,2),
		inpsamm decimal(19,2),
		inail decimal(19,2)
	)

	-- Riempimento della tabella dei cedolini.
	-- Vengono inseriti tutti i cedolini trasmessi associati ai contratti del percipiente dell'anno dei redditi.
	-- Di questi cedolini si seleziona il movimento di spesa che li contabilizza, la data di trasmissione,
	-- la data di inizio e fine ed il contratto di appartenenza.
	insert into #cedolini 	(idpayroll,  idcon, startpayroll, stoppayroll)
	SELECT
		payroll.idpayroll, payroll.idcon,
		payroll.start, payroll.stop
	from payroll					
	join parasubcontract			on payroll.idcon= parasubcontract.idcon
	JOIN parasubcontractyear im		ON parasubcontract.idcon = im.idcon AND im.ayear = @annoredditi
	JOIN service					ON service.idser = parasubcontract.idser
	where	fiscalyear=@annoredditi 
			and parasubcontract.idreg = @idreg
			and payroll.flagcomputed='S'
			AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
			AND (service.rec770kind='G')
			AND payroll.flagsummarybalance='N'
			AND payroll.flagbalance='N'

	--select * from #cedolini

	-- Tabella dei contratti parasubordinati coinvolti
	create table #contratti
	(
		idcon varchar(8),
		padre varchar(8),
		taxablepension decimal(19,2),
		fiscaltaxablegross decimal(19,2),
		inpsinail decimal(19,2),
		deduction decimal(19,2),
		start datetime, -- Data inizio del cedolino di conguaglio
		stop datetime, -- Data fine del cedolino di conguaglio
		stopcontract datetime, -- Data Fine del Contratto
		capofila char(1),
		certificatekind char(1),
		idser int,
		servicecode770 varchar(20),
		highertax decimal(19,2),
		applicaritprevidenziali char(1),
		flagbonusappliance char(1),
		exemptioncode INT,
		flagsummarybalance char(1) -- questo flag indica se il cedolino di conguaglio è fittizio
	)

	-- Si inseriscono i contratti del percipiente corrente.
	-- per la Certificazione Unica
	-- Vengono presi tutti i contratti di un fissato percipiente per i quali esiste almeno un cedolino che sia stato trasmesso
	-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- al quadro G del 770 (rec770kind = 'G'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
	-- le deduzioni, l'imponibile fiscale lordo del contratto e l'id e la data di fine del cedolino di conguaglio.
 
	INSERT INTO #contratti
				(idcon, taxablepension, inpsinail, deduction,
				fiscaltaxablegross, stopcontract, 
				certificatekind, idser, servicecode770, highertax,
				applicaritprevidenziali, 
				flagbonusappliance, exemptioncode)
	SELECT
		co.idcon,	s.taxablepension,	s.inpsinail,	s.deduction,s.fiscaltaxablegross,	
		co.stop,	service.certificatekind,	co.idser,	ISNULL(service.codeser,service.servicecode770),	im.highertax,
		CASE
			WHEN EXISTS (SELECT * FROM servicetaxview ST  
			              WHERE ST.idser = service.idser
						    AND ST.taxkind = 3) THEN 'S'
			ELSE 'N'
		END,
		im.flagbonusappliance,		motive770service.exemptioncode	
	FROM  parasubcontract co						
   	JOIN parasubcontractyear im		ON co.idcon = im.idcon AND im.ayear = @annoredditi
    JOIN parasubcontractsummaryview s			ON s.idcon = im.idcon
													AND s.ayear = im.ayear
	JOIN service								ON service.idser = co.idser
	LEFT OUTER JOIN motive770service			ON service.idser = motive770service.idser
													AND motive770service.ayear = @annoredditi
	WHERE EXISTS (SELECT * from #cedolini  where  #cedolini.idcon=co.idcon)

	--select * from #contratti
	

	DECLARE @stopcontract datetime
	SELECT 	@stopcontract  = MAX(stopcontract)  FROM #contratti	

	
	
	-- Si aggiorna la catena tra contratti scaturita dall'uso dei CUD.
	-- La catena si aggiorna impostando il campo PADRE della tabella #contratti, dove nel campo PADRE si inserisce 
	-- sul contratto puntato dal CUD il contratto contenitore del CUD
	-- Esempio:
	-- Contratto 10
	-- Contratto 11
	-- CUD inserito nel contratto 11 riferito al contratto 10
	-- Il contratto 10 avrà come padre il contratto 11
	UPDATE #contratti	SET padre = exhibitedcud.idcon
	FROM exhibitedcud
	WHERE exhibitedcud.idlinkedcon = #contratti.idcon
		AND exhibitedcud.fiscalyear = @annoredditi


	
	
		-- Si definisce un contratto capofila per il percipiente
	-- Un contratto capofila è da considerarsi come radice dell'albero dei contratti
	-- Se esiste un solo contratto con il campo PADRE non valorizzato sarà questo contratto
	-- ad essere individuato come capofila
	-- altrimenti si sceglie come capofila un contratto tra tutti quelli senza padre.
	-- N.B. Per le prestazioni Co.Co.Co. per cui la certificazione associata è il CUD
	-- ove ci siano più contratti c'è sempre un capofila, mentre per prestazioni tipo
	-- assegnisti di ricerca accade che ci siano più contratti non legati tra loro in quanto
	-- non esiste il concetto di trasformare un contratto pregresso in CUD per uno nuovo
	-- in quanto non vi è l'esigenza di effettuare un conguaglio fiscale.
	IF (SELECT COUNT(*) FROM #contratti WHERE padre IS NULL) = 1
	BEGIN
		UPDATE #contratti		SET capofila = 'S'		WHERE #contratti.padre IS NULL
	END
	ELSE
	BEGIN
		UPDATE #contratti	SET capofila = 'S'		WHERE idcon = (SELECT TOP 1 idcon FROM #contratti WHERE padre IS NULL)
	END

	-- Tabella dei giorni lavorati
	create table #workdays 	(giorno smalldatetime, worked char(1)) 
	DECLARE @1gen00 datetime
	SET @1gen00 = DATEADD(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @giorno smalldatetime
	set @giorno=@1gen00
	WHILE (datepart(year,@giorno)<=@annoredditi)
	BEGIN
		insert into #workdays(giorno) values (@giorno)
		set @giorno=DATEADD(dd,1,@giorno)
	END
	

	-- Calcolo dei giorni lavorati
	-- Si settano tutti i giorni a NON LAVORATI
	update #workdays set worked='N'

	-- Si settano tutti i giorni rientranti nella durata dei cedolini a LAVORATI
	update #workdays set worked='S' where exists
		(SELECT * from #cedolini
		JOIN #contratti				ON #contratti.idcon = #cedolini.idcon
		WHERE #workdays.giorno BETWEEN #cedolini.startpayroll AND #cedolini.stoppayroll
			AND NOT EXISTS
				(SELECT * FROM servicetaxview
				WHERE servicetaxview.idser = #contratti.idser
					AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
		)

	-- Si settano tutti i giorni rientranti nella durata di CUD cartacei a LAVORATI
	update #workdays set worked='S' where exists
	(SELECT * from exhibitedcud 
		join #contratti on exhibitedcud.idcon=#contratti.idcon
		where exhibitedcud.idlinkedcon is null and --controllo preciso ma superfluo
			 #workdays.giorno between exhibitedcud.start and exhibitedcud.stop
			AND exhibitedcud.fiscalyear = @annoredditi
	)
	

	declare @onerisostenutiinaltricontratti dec(19,2)
	SET @onerisostenutiinaltricontratti =
	ISNULL(
		(SELECT 
			ISNULL(SUM(exhibitedcud.taxablepension),0) -
			ISNULL(SUM(exhibitedcud.taxablegross),0)
		FROM exhibitedcud 
		JOIN #contratti  ON #contratti.idcon = exhibitedcud.idcon
		WHERE #contratti.padre IS NULL
					AND exhibitedcud.fiscalyear = @annoredditi)
	,0)



	-- Calcolo dei redditi ai quali si possono applicare le deduzioni art. 11 e imposta lorda
	-- Esso è pari alla somma degli imponibili lordi delle ritenute fiscali nazionali associate ai
	-- contratti del percipiente. I contratti da considerare sono solo quelli associati alla certificazione
	-- CUD che non sono diventati a loro volta CUD per altri contratti. Si scartano le ritenute con codice
	-- 08_IRPEF_FOC e 07_IRPEF_FO in quanto sono ritenute applicate a stranieri che non rientrano in questo calcolo
	-- L'imposta lorda è pari alla somma delle ritenute (il filtro è quello descritto precedentemente), tant'è che la
	-- query è la medesima
	DECLARE @taxablegross	DECIMAL(19,2)
	DECLARE @employtaxgross DECIMAL(19,2)
	DECLARE @deduzioni		DECIMAL(19,2)
	SELECT  @employtaxgross = SUM(cr.employtaxgross),	
			@deduzioni = SUM(cr.deduction),	
			@taxablegross   = SUM (cr.taxablegross)
	FROM	#cedolini P
	JOIN #contratti 		ON #contratti.idcon = P.idcon
	join parasubcontract PP on PP.idcon=P.idcon
	JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
	JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	AND geoappliance IS NULL
	WHERE   tax.taxref <> '14_BONUS_FISCALE' AND  #contratti.padre IS NULL
			AND NOT EXISTS (SELECT * FROM servicetaxview
				       WHERE servicetaxview.idser = PP.idser  AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))


	set @deduzioni = isnull(@deduzioni,0)
	set @taxablegross = isnull(@taxablegross,0)
	

	-- Calcolo della detrazione APPLICATA per familiari
	-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
	-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
	-- Si considera ovviamente la sola detrazione con codice 29 che si riferisce al reddito
	DECLARE @detrazioni_familiari DECIMAL(19,2)
	--DECLARE @detrazioni_annue_per_reddito DECIMAL(19,2)
	
	SELECT @detrazioni_familiari = SUM(payrollabatement.curramount)
		 -- @detrazioni_annue_per_reddito = SUM(payrollabatement.annualamount)
		FROM payrollabatement
		join abatement A on payrollabatement.idabatement = A.idabatement
		JOIN #cedolini					ON #cedolini.idpayroll = payrollabatement.idpayroll
		JOIN #contratti 		ON #contratti.idcon = #cedolini.idcon
		WHERE A.evaluatesp ='calcola_detrazione_familiari' AND #contratti.padre IS NULL
 
	 SET @detrazioni_familiari = ISNULL(@detrazioni_familiari,0)


	 

	declare @giorni_anno int
	set @giorni_anno = 365
	if  ((@annoredditi % 4 = 0) and (@annoredditi % 100 != 0)) or (@annoredditi % 400 = 0) begin
		set @giorni_anno = 366
	end

	-- Conteggio dei giorni lavorati
	DECLARE @workingdays INT
	SELECT @workingdays = count(*) from #workdays where worked='S'

	-- Se i giorni lavorati superano l'anno si pongono pari al numero di giorni dell'anno
	-- non è contemplato, a quanto pare, l'anno bisestile
	IF @workingdays>@giorni_anno 
	BEGIN
		SET @workingdays=@giorni_anno
	END


	DECLARE @totale_redditi_da_cud DECIMAL(19,2)
	SET @totale_redditi_da_cud  = --@DB001301
					ISNULL(
						(SELECT SUM(taxablegross)
						FROM exhibitedcud
						JOIN #contratti 		ON #contratti.idcon = exhibitedcud.idcon
						WHERE			fiscalyear = @annoredditi 
							AND idlinkedcon is null)
					,0)

	set @totale_redditi_da_cud = isnull(@totale_redditi_da_cud,0)

	

	declare @totale_reddito decimal (19,2)
	set @totale_reddito = @taxablegross-@deduzioni+@totale_redditi_da_cud
	declare @maxdetrazione decimal(19,2)
	set @maxdetrazione = 0


	create table #coniuge (
		idconiuge int,
		codiceFiscaleConiuge varchar(16),
		numeroMesiACarico  int,
		anno int
	)

 	-- Tabella dove vengono inseriti i primi figli (per le detrazioni su familiari)
	create table #primoFiglio (
		idPrimoFiglio int,
		casellaPrimoFiglio int,
		casellaDisabile int, 
		codiceFiscalePrimoFiglio varchar(16),
		numeroMesiACarico int, 
		minoreDiTreAnni int,
		percentualeDiDetrazioneSpettante dec(19,6),
		detrazionePerConiugeACarico char,
		anno int
	)

	-- Tabella dove vengono inseriti i figli diversi dal primo (per le detrazioni su familiari)
	create table #altroFiglio (
		idAltroFiglio int,
		casellaFiglio int,
		casellaAltroFamiliare int,
		casellaDisabile int,
		codiceFiscaleFamiliare  varchar(16),
		numeroMesiACarico int,
		minoreDiTreAnni int, 
		percentualeDiDetrazioneSpettante dec(19,6),
		detrazionePerConiugeACarico char,
		anno int
	)
	
	declare @idfamily	int
	-- Gestione dei familiari
	declare @birthdate smalldatetime
	declare @startapplication smalldatetime
	declare @stopapplication smalldatetime
	declare @starthandicap smalldatetime
	declare @idaffinity char
	declare @meseinizio int
	declare @mesefine int
	declare @mese int
	declare @cfFamigliare varchar(16)
	declare @detrazionePerConiugeACarico char
	declare @appliancePercentage dec(19,6)
	declare @idcontract int

	declare @numeroFigliAnno int
	set @numeroFigliAnno=0
	select @numeroFigliAnno = count(distinct F.CF) 
	FROM parasubcontractfamily F
	JOIN #contratti						ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
			AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
			AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
			AND F.idaffinity='F'
			AND #contratti.padre IS NULL

	declare @esiste_coniuge int
	set @esiste_coniuge=0
	select @esiste_coniuge = count(distinct F.CF) 
	FROM parasubcontractfamily F
	JOIN #contratti						ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
			--AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
			--AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
			AND F.idaffinity='C'
			AND #contratti.padre IS NULL

	declare @detrazione_annua_figli decimal(19,2)
	set @detrazione_annua_figli = 0

	declare @n_effettivi_a_carico int
	set @n_effettivi_a_carico = 0

	declare @primodelmese datetime
	declare @ultimodelmese datetime

	-- Definizione del cursore che cicla su tutti i familiari presenti solamente sul contratto CAPOFILA,
	-- i familiari non devono necessariamente risultare a carico e devono avere una applicazione ricadente nel periodo dell'anno
	-- in cui sono maturati i redditi
	declare @cursFigli cursor
	set @cursFigli = cursor for 
	SELECT 
		F.birthdate,isnull(F.cf, ''),
		min(ISNULL(F.startapplication, @1gen15_XXX)),
		max(ISNULL(F.stopapplication, @31dic15_XXX)),
		max(ISNULL(F.starthandicap, @1gen16_XXX)),
		max(ISNULL(F.appliancepercentage, 1))
	FROM parasubcontractfamily F
	JOIN #contratti						ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
			AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
			AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
			AND F.idaffinity='F'
				AND #contratti.padre IS NULL
				group by F.birthdate,ISNULL(F.cf, '')
	order by birthdate



	open @cursFigli
	fetch next from @cursFigli into @birthdate, @cfFamigliare,@startapplication,@stopapplication,@starthandicap,@appliancePercentage 

	declare @primofiglio char(1)
	declare @childAsParent char(1)
	set @primofiglio='S'
	-- Ciclo sui familiari
	WHILE (@@fetch_status=0) 
	begin
		print 'figlio'

		print '@birthdate'
		print @birthdate
		print '@cfFamigliare' 
		print @cfFamigliare 
		print '@startapplication' 
		print @startapplication 
		print '@stopapplication'
		print @stopapplication 
		print '@starthandicap'
		print @starthandicap
		print '@appliancePercentage'
		print @appliancePercentage 
		if (isnull(@appliancePercentage,0)=0) begin
			set @primofiglio='N'
			fetch next from @cursFigli into @birthdate, @cfFamigliare,@startapplication,@stopapplication,@starthandicap,@appliancePercentage 
			continue;
		end
		declare @detrazionePerQuestoFiglio decimal(19,2)
		set @detrazionePerQuestoFiglio = DBO.fn_scegliDetrazionePerFiglio(@1gen15_XXX, @starthandicap, @birthdate, @numeroFigliAnno,	
													@startapplication,@stopapplication, @appliancePercentage)
		set @n_effettivi_a_carico =  @n_effettivi_a_carico+1

		set @meseinizio = 1		--mese inizio applicazione familiare a carico
		set @mesefine = 12		--mese inizio applicazione familiare a carico
		declare @nmesi_applicazione int
	

		-- Si definiscono i mesi di inizio e fine pari ai mesi delle date di inizio e fine applicazione	
		if (year(@startapplication) = @annoredditi) 	set @meseinizio = month(@startapplication)
		if (year(@stopapplication) = @annoredditi ) 	set @mesefine = month(@stopapplication)
		set @nmesi_applicazione= @mesefine-@meseinizio+1

		set @childAsParent = 'N'
		if (@primofiglio='S' and @esiste_coniuge=0 and @appliancePercentage=1) begin
			--Caso di primo figlio senza coniuge -- Si considera il primo figlio come un coniuge ove convenga
			declare @detrazioneAnnuaConiuge decimal(19,2)
			set @detrazioneAnnuaConiuge=  DBO.fn_calcola_detrazione_coniuge_su_fascia(@totale_reddito,@nmesi_applicazione)
			set @detrazionePerQuestoFiglio= DBO.fn_detrazione_figli(@detrazionePerQuestoFiglio,@totale_reddito,@numeroFigliAnno);
			if (@detrazioneAnnuaConiuge > @detrazionePerQuestoFiglio) BEGIN
                        SET @detrazionePerQuestoFiglio = @detrazioneAnnuaConiuge;
                        set @childAsParent='S'
			END
         END
		 ELSE BEGIN   
			-- Caso Normale
			set @detrazionePerQuestoFiglio = DBO.fn_detrazione_figli(@detrazionePerQuestoFiglio,@totale_reddito,@numeroFigliAnno);
		 END
		 SET @detrazione_annua_figli = @detrazione_annua_figli + @detrazionePerQuestoFiglio ;		

		set @primofiglio='N'
		fetch next from @cursFigli into @birthdate, @cfFamigliare,@startapplication,@stopapplication,@starthandicap,@appliancePercentage 
	end
	
	if (@n_effettivi_a_carico > 3) BEGIN
              declare @detrazione_piu_di_trefigli decimal
			  set @detrazione_piu_di_trefigli = 1200; 
			  SET @detrazione_annua_figli = @detrazione_annua_figli +     @detrazione_piu_di_trefigli       
	END


	declare @detrazione_annua_coniuge decimal(19,2)
	set  @detrazione_annua_coniuge  = 0


    declare @cursConiuge cursor
	set @cursConiuge = cursor for 
	SELECT 
		ISNULL(F.cf, ''),
		min(ISNULL(F.startapplication, @1gen15_XXX)),
		max(ISNULL(F.stopapplication, @31dic15_XXX)),
		max(ISNULL(F.starthandicap, @1gen16_XXX))	
	FROM parasubcontractfamily F
	JOIN #contratti						ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
			AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
			AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
			AND F.idaffinity='C'		--coniuge
			and F.flagdependent='S'		--a carico
			AND #contratti.padre IS NULL
			group by  ISNULL(F.cf, '')

	open @cursConiuge
	fetch next from @cursConiuge into @cfFamigliare, @startapplication, @stopapplication, @starthandicap

	-- Ciclo sui coniugi
	WHILE (@@fetch_status=0) 
	begin
		print 'coniugi'
		 

		set @meseinizio = 1		--mese inizio applicazione familiare a carico
		set @mesefine = 12		--mese inizio applicazione familiare a carico
		declare @nmesi_applicazione_coniuge int		

		-- Si definiscono i mesi di inizio e fine pari ai mesi delle date di inizio e fine applicazione	
		if (year(@startapplication) = @annoredditi) 	set @meseinizio = month(@startapplication)
		if (year(@stopapplication) = @annoredditi ) 	set @mesefine = month(@stopapplication)
		set @nmesi_applicazione_coniuge= @mesefine-@meseinizio+1
		
		declare @detrazioneAnnuaQuestoConiuge decimal(19,2)
		set @detrazioneAnnuaQuestoConiuge = ROUND(DBO.fn_calcola_detrazione_coniuge_su_fascia(@totale_reddito,@nmesi_applicazione_coniuge) ,2);

		set @detrazione_annua_coniuge = @detrazione_annua_coniuge+ @detrazioneAnnuaQuestoConiuge
		fetch next from @cursConiuge into @cfFamigliare, @startapplication, @stopapplication, @starthandicap
	end

	

	declare @detrazioneperaltrifamiliari decimal(19,2)
	set @detrazioneperaltrifamiliari = 0


	declare @cursAltri cursor
	set @cursAltri = cursor for 
	SELECT  
		ISNULL(F.cf, ''),
		min(ISNULL(F.startapplication, @1gen15_XXX)),
		max(ISNULL(F.stopapplication, @31dic15_XXX)),
		max(ISNULL(F.appliancepercentage, 1))
	FROM parasubcontractfamily F
	JOIN #contratti						ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
			AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
			AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
			AND F.idaffinity='A'		--altri
			AND #contratti.padre IS NULL
			GROUP BY  	ISNULL(F.cf, '')

	open @cursAltri
	fetch next from @cursAltri into @cfFamigliare,@startapplication,@stopapplication,@appliancePercentage
	-- Ciclo sugli altri familiari
	WHILE (@@fetch_status=0) 
	begin
		print 'altri'
 

		set @meseinizio = 1		--mese inizio applicazione familiare a carico
		set @mesefine = 12		--mese inizio applicazione familiare a carico
		declare @nmesi_applicazione_altri int		

		-- Si definiscono i mesi di inizio e fine pari ai mesi delle date di inizio e fine applicazione	
		if (year(@startapplication) = @annoredditi) 	set @meseinizio = month(@startapplication)
		if (year(@stopapplication) = @annoredditi ) 	set @mesefine = month(@stopapplication)
		set @nmesi_applicazione_altri= @mesefine-@meseinizio+1


		 declare  @detrazioneAnnuaPerQuestoAltroFamiliare decimal(19,2)
		 set @detrazioneAnnuaPerQuestoAltroFamiliare = DBO.fn_detrazione_altri(@totale_reddito,@nmesi_applicazione_altri);         
         set @detrazioneperaltrifamiliari = @detrazioneperaltrifamiliari +Round(@detrazioneAnnuaPerQuestoAltroFamiliare * @appliancePercentage, 2);

		fetch next from @cursConiuge into @cfFamigliare,@startapplication,@stopapplication,@appliancePercentage
	end

	set @maxdetrazione = @detrazione_annua_coniuge + @detrazione_annua_figli + @detrazioneperaltrifamiliari
	--print 'detrazioni'
	--print @detrazioni_familiari
	--print @maxdetrazione

	if (@detrazioni_familiari> @maxdetrazione)BEGIN
		set @res=1
	END


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amm'
declare @res int
exec check_detrazioni_familiari 3468,2015, @res out
select @res

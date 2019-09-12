if exists (select * from dbo.sysobjects where id = object_id(N'[check_detrazioni_reddito]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_detrazioni_reddito]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'


CREATE   procedure check_detrazioni_reddito (
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
	insert into #cedolini 	(idpayroll, idcon, startpayroll, stoppayroll)
	SELECT
		payroll.idpayroll,  payroll.idcon, payroll.start, payroll.stop
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
		co.stop,	service.certificatekind,	co.idser,	ISNULL(service.servicecode770,service.codeser),	im.highertax,
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
	--select * from #contratti
	-- Tabella dei giorni lavorati
	create table #workdays 	(giorno smalldatetime, worked char(1)) 
	DECLARE @1gen00 datetime
	SET @1gen00 = DATEADD(yy, @annoredditi-2009, {d '2000-01-01'})

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
	WHERE   tax.taxref <> '14_BONUS_FISCALE'  AND #contratti.padre IS NULL
			AND NOT EXISTS (SELECT * FROM servicetaxview
				       WHERE servicetaxview.idser = PP.idser  AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))

--SELECT * FROM #cedolini
	set @deduzioni = isnull(@deduzioni,0)
	set @taxablegross = isnull(@taxablegross,0)

	-- Calcolo della detrazione per reddito
	-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
	-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
	-- Si considera ovviamente la sola detrazione con codice 29 che si riferisce al reddito
	DECLARE @detrazioni_per_reddito DECIMAL(19,2)
	--DECLARE @detrazioni_annue_per_reddito DECIMAL(19,2)
	--SELECT payrollabatement.curramount, * 
	--	 -- @detrazioni_annue_per_reddito = SUM(payrollabatement.annualamount)
	--	FROM payrollabatement
	--	join abatement A on payrollabatement.idabatement = A.idabatement
	--	JOIN #cedolini					ON #cedolini.idpayroll = payrollabatement.idpayroll
	--	JOIN #contratti 		ON #contratti.idcon = #cedolini.idcon
	--	WHERE A.evaluatesp ='calcola_detrazione_reddito'
	--	AND #contratti.padre IS NULL

	SELECT @detrazioni_per_reddito = SUM(payrollabatement.curramount)
		 -- @detrazioni_annue_per_reddito = SUM(payrollabatement.annualamount)
		FROM payrollabatement
		join abatement A on payrollabatement.idabatement = A.idabatement
		JOIN #cedolini					ON #cedolini.idpayroll = payrollabatement.idpayroll
		JOIN #contratti 		ON #contratti.idcon = #cedolini.idcon
		WHERE A.evaluatesp ='calcola_detrazione_reddito'
		AND #contratti.padre IS NULL

		print 'detrazioni per reddito'
	 SET @detrazioni_per_reddito = ISNULL(@detrazioni_per_reddito,0)

	 -- Calcolo della detrazione per oneri
	-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
	-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
	-- Si considerano tutte le detrazioni che sono marcate come oneri detraibili (flagabatableexpense = 'S')
	DECLARE @detrazioni_per_oneri DECIMAL(19,2)
	--DECLARE @detrazioni_annue_per_oneri DECIMAL(19,2)
 
	SELECT 
	@detrazioni_per_oneri = SUM(payrollabatement.curramount)
	--@detrazioni_annue_per_oneri = SUM(payrollabatement.annualamount)
	FROM payrollabatement
	JOIN #cedolini			ON #cedolini.idpayroll = payrollabatement.idpayroll
	JOIN abatement			ON abatement.idabatement = payrollabatement.idabatement
	JOIN #contratti 		ON #contratti.idcon = #cedolini.idcon
	WHERE abatement.flagabatableexpense = 'S'	AND #contratti.padre IS NULL
			  
	SET @detrazioni_per_oneri = ISNULL(@detrazioni_per_oneri,0)

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

	declare @massimale decimal(19,2)

	declare @totale_reddito decimal (19,2)
	set @totale_reddito = @taxablegross-@deduzioni+@totale_redditi_da_cud
	declare @maxdetrazione decimal(19,2)
	set @maxdetrazione = 0

	-- Per la prima fascia la minima detrazione non è 690 ma 1380 perché sono lavoratori a tempo determinato
    declare @min_detrazione decimal
	set @min_detrazione = 1380 

	declare @max_fascia1 decimal(19,2) -- reddito
	set @max_fascia1= 8000

	declare @max_fascia2 decimal(19,2)
	set @max_fascia2= 28000

	declare @max_fascia3 decimal(19,2)
	set @max_fascia3= 55000

	if (@totale_reddito <=@max_fascia1) begin
	--1880 massimale detrazione
	     set @maxdetrazione = (1880 / @giorni_anno) * @workingdays;
		 print 'fascia 1'
		 print  'calcolo detrazione applicata al percipiente rapportata al periodo di lavoro'
		 print 	@maxdetrazione	
		 print 'giorni lavorati'
		 print @workingdays
		 --minima detrazione per la prima fascia
		 if (@maxdetrazione <= 1380) BEGIN
                SET @maxdetrazione = 1380;
         end
	end
	print @detrazioni_per_reddito
	print 'totale reddito'
	print @totale_reddito
	print @giorni_anno
	print @workingdays

    if (@totale_reddito >@max_fascia1 and @totale_reddito <=@max_fascia2) begin
		print 'fascia 2'
		 set @maxdetrazione =  978    +   (902 * (28000 - @totale_reddito)) / 20000;
		 set  @maxdetrazione = (@maxdetrazione / @giorni_anno) * @workingdays
		  print  'calcolo detrazione applicata al percipiente rapportata al periodo di lavoro'
		 print 	@maxdetrazione	
		 print 'giorni lavorati'
		 print @workingdays
	end
 
	if (@totale_reddito >=@max_fascia2 and @totale_reddito <=@max_fascia3) begin	 
		print 'fascia 3'
		set @maxdetrazione= (978 * (55000 - @totale_reddito)) / 27000;
		set  @maxdetrazione = (@maxdetrazione / @giorni_anno) * @workingdays
		 print  'calcolo detrazione applicata al percipiente rapportata al periodo di lavoro'
		 print 	@maxdetrazione	
		 print 'giorni lavorati'
		 print @workingdays
	end
    
	print 'detrazioni'
	--print @detrazioni_per_reddito
	--print @maxdetrazione

	
	if (@detrazioni_per_reddito> @maxdetrazione)BEGIN
		set @res=1
	END


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

--setuser 'amm'
--declare @res int
--exec check_detrazioni_reddito 5960,2015, @res out
--select @res

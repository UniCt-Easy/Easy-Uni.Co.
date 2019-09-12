if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_g_15]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_g_15]
GO
 
--exec exp_certificazioneunica_g_15 21,1,'S'
CREATE PROCEDURE [exp_certificazioneunica_g_15]
 -- estraggo il record H relativo ad un determinato percipiente, il progressivo comunicazione
 -- indica l'ordine all'interno dei percipienti del sostituto d'imposta
(
	 @idreg int,
	 @progrCom int,
	 @print char(1)  -- vale S per la stampa N altrimenti
	 --@newprogrCom int out
) 
 
AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = 2014

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1
 
-- Sezione dichiarativa	
	DECLARE @progrModulo int -- normalmente costante pari a uno
	DECLARE @codfiscEnte varchar(16)
	DECLARE @au1cf varchar(16) -- codice fiscale del percipiente

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	SET @progrModulo = 1
 
	SELECT @au1cf =  isnull(cf,p_iva) FROM registry
	WHERE registry.idreg = @idreg
	
	
	DECLARE @agencynumber VARCHAR(10)
		
	SELECT @agencynumber =  agencynumber FROM config
	WHERE  ayear = @annodichiarazione
	
	-- Il quadro G è per i Dati relativi alla comunicazione dati certificazioni lavoro dipendente, assimilati ed assistenza fiscale
	CREATE TABLE #recordG 
	(
		progr int,
		modulo int,
		quadro varchar(6),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		decimale decimal(19,2),
		data datetime,
		intero int
	)
		
	----------------------------------------------------
	---- Intestazione Record G, parte posizionale ------
	----------------------------------------------------
	
	insert into #recordG (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
	exec exp_certificazioneunica_d_15  @idreg, @progrCom, 'G',NULL, @print
	
	SELECT @codfiscEnte = cf FROM license
	--1 Tipo record
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom, 1, 'HRG', 1, '01', 'G')
	--2 Codice fiscale del sostituto d'imposta
	INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, stringa)  VALUES(@progrCom, 1, 'HRG', 1, '02', @codfiscEnte)
	--3 Progressivo modulo
	INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, intero)   VALUES(@progrCom, 1, 'HRG', 1, '03', @progrModulo)
	--4 Codice fiscale del percipiente
	INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, stringa)  VALUES(@progrCom, 1, 'HRG', 1, '04', @au1cf)
	--5 Progressivo certificazione
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)  VALUES(@progrCom, 1, 'HRG', 1, '05', @progrCom)
	
	----------------------------------------------------
    --- Estrazione dati relativi alle somme erogate ----
    ----------------------------------------------------
    
	-- Ricordarsi di cambiare ogni anno l'anno delle date
	declare @1gen14_XXX datetime
	set @1gen14_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @13gen14_XXX datetime
	set @13gen14_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-13'})

	declare @31dic14_XXX datetime
	set @31dic14_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen15_XXX datetime
	set @1gen15_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-01'})

	declare @12gen15_XXX datetime
	set @12gen15_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

	-- Tabella dei giorni lavorati
	create table #workdays 	(giorno smalldatetime, worked char(1) )

	DECLARE @1gen00 datetime
	SET @1gen00 = DATEADD(yy, @annoredditi-2009, {d '2000-01-01'})

	declare @giorno smalldatetime
	set @giorno=@1gen00
	WHILE (datepart(year,@giorno)<=@annoredditi)
	BEGIN
		insert into #workdays(giorno) values (@giorno)
		set @giorno=DATEADD(dd,1,@giorno)
	END
	
	-- Tabella dei contratti parasubordinati coinvolti nella certificazione unica
	create table #contratti
	(
		idcon varchar(8),
		padre varchar(8),
		taxablepension decimal(19,2),
		fiscaltaxablegross decimal(19,2),
		inpsinail decimal(19,2),
		deduction decimal(19,2),
		idpayroll int, -- Cedolino di conguaglio
		start datetime, -- Data inizio del cedolino di conguaglio
		stop datetime, -- Data fine del cedolino di conguaglio
		capofila char(1),
		certificatekind char(1),
		idser int,
		codeser varchar(20),
		highertax decimal(19,2),
		applicaritprevidenziali char(1)
	)

	-- Tabella dei cedolini
	create table #cedolini (
		idcedolino int, 
		idexp int,
		idcon varchar(8),
		datacompetenza datetime, 
		startpayroll datetime,
		stoppayroll datetime,
		compensoprev decimal(19,2),
		ritprevtrattenuta decimal(19,2),
		inpsamm decimal(19,2),
		inail decimal(19,2),
	)
	
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
	
	-- Si inseriscono i contratti del percipiente corrente.
	-- per la Certificazione Unica
	-- Vengono presi tutti i contratti di un fissato percipiente per i quali esiste almeno un cedolino che sia stato trasmesso
	-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- al quadro G del 770 (rec770kind = 'G'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
	-- le deduzioni, l'imponibile fiscale lordo del contratto e l'id e la data di fine del cedolino di conguaglio.
 
	INSERT INTO #contratti
				(idcon, taxablepension, inpsinail, deduction,
				fiscaltaxablegross, idpayroll,start, stop, 
				certificatekind, idser, codeser, highertax,
				applicaritprevidenziali)
	SELECT
		co.idcon,
		s.taxablepension,
		s.inpsinail,
		s.deduction,
		s.fiscaltaxablegross,
		ce.idpayroll,
		ce.start,
		ce.stop,
		service.certificatekind,
		co.idser,
		service.codeser,
		im.highertax,
		CASE
			WHEN EXISTS (SELECT * FROM servicetaxview ST  
			              WHERE ST.idser = service.idser
						    AND ST.taxkind = 3) THEN 'S'
			ELSE 'N'
		END
	FROM payroll ce 
	JOIN parasubcontract co
		ON co.idcon = ce.idcon
            JOIN parasubcontractyear im
		ON co.idcon = im.idcon
		AND im.ayear = @annoredditi
            JOIN parasubcontractsummaryview s
		ON s.idcon = im.idcon
		AND s.ayear = im.ayear
	JOIN service
		ON service.idser = co.idser
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		AND ce.disbursementdate is not null
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
		AND payroll.fiscalyear = @annoredditi)
		AND (service.rec770kind='G')
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
		AND co.idreg = @idreg
		 
		 --SELECT * FROM #contratti
	DECLARE @start datetime 
	DECLARE @stop  datetime 
	
	SELECT 	@start = MIN(start) FROM #contratti	
	SELECT 	@stop  = MAX(stop)  FROM #contratti	
	-- Si aggiorna la catena tra contratti scaturita dall'uso dei CUD.
	-- La catena si aggiorna impostando il campo PADRE della tabella #contratti, dove nel campo PADRE si inserisce 
	-- sul contratto puntato dal CUD il contratto contenitore del CUD
	-- Esempio:
	-- Contratto 10
	-- Contratto 11
	-- CUD inserito nel contratto 11 riferito al contratto 10
	-- Il contratto 10 avrà come padre il contratto 11
	UPDATE #contratti
	SET padre = exhibitedcud.idcon
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
		UPDATE #contratti
		SET capofila = 'S'
		WHERE #contratti.padre IS NULL
	END
	ELSE
	BEGIN
		UPDATE #contratti
		SET capofila = 'S'
		WHERE idcon = (SELECT TOP 1 idcon FROM #contratti WHERE padre IS NULL)
	END
	
	-- Riempimento della tabella dei cedolini.
	-- Vengono inseriti tutti i cedolini trasmessi associati ai contratti del percipiente dell'anno dei redditi.
	-- Di questi cedolini si seleziona il movimento di spesa che li contabilizza, la data di trasmissione,
	-- la data di inizio e fine ed il contratto di appartenenza.
	insert into #cedolini
	(idcedolino, idexp, idcon, datacompetenza, startpayroll, stoppayroll)
	SELECT
		expensepayroll.idpayroll, expensepayroll.idexp, payroll.idcon,
		transmissiondate, payroll.start, payroll.stop
	from expensepayroll
	join payroll on payroll.idpayroll=expensepayroll.idpayroll
	join expenselink ON expenselink.idparent = expensepayroll.idexp
	join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
	join payment on payment.kpay=expenselast.kpay
	join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
	join #contratti on payroll.idcon=#contratti.idcon
	where fiscalyear=@annoredditi
	order by payroll.stop
		

	-- Calcolo dei giorni lavorati
	-- Si settano tutti i giorni a NON LAVORATI
	update #workdays set worked='N'
	-- Si settano tutti i giorni rientranti nella durata dei cedolini a LAVORATI
	update #workdays set worked='S' where exists
		(SELECT * from #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
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
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
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
	SELECT  @employtaxgross = SUM(cr.employtaxgross),	
			@taxablegross   = SUM (cr.taxablegross)
	FROM	#contratti	 			 
	JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
	JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
	JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	AND geoappliance IS NULL
	WHERE #contratti.padre IS NULL AND tax.taxref <> '14_BONUS_FISCALE'
	AND NOT EXISTS (SELECT * FROM servicetaxview
				       WHERE servicetaxview.idser = #contratti.idser
					         AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
								         
	SET @taxablegross  = isnull(@taxablegross,0)
	SET @employtaxgross  = isnull(@employtaxgross,0)

	-- Lo commento perchè Antonio dice che i dati fiscali non vanno inseriti per le 
	-- le prestazioni degli assegnisti totalmente esenti
	--SET @taxablegross = @taxablegross + ISNULL (
	--	(SELECT SUM(p.feegross) 	FROM	#contratti	 			 
	--			JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
	--			WHERE #contratti.padre IS NULL
	--				AND NOT EXISTS (SELECT * FROM servicetaxview
	--						       WHERE servicetaxview.idser = #contratti.idser
	--							         AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
	--				AND NOT EXISTS(SELECT * FROM payrolltax cr
	--									JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	AND geoappliance IS NULL
	--									WHERE   cr.idpayroll= P.idpayroll)
	--	),0)
	

	
					
	--SET @taxablegross  = isnull(@taxablegross,0)
	--SET @employtaxgross  = isnull(@employtaxgross,0)

	-- Calcolo della detrazione per familiari a carico
	-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
	-- non divenuti CUD per altri e la cui prestazione ricade nella certificazione CUD
	-- Si considera ovviamente la sola detrazione con codice 28 che si riferisce ai familiari
	DECLARE @detrazioni_familiari_a_carico	DECIMAL(19,2)
	--DECLARE @detrazioni_annue_familiari_a_carico	DECIMAL(19,2)
 
	SELECT 
	@detrazioni_familiari_a_carico = SUM(payrollabatement.curramount)
	--@detrazioni_annue_familiari_a_carico =  SUM(payrollabatement.annualamount)
	FROM payrollabatement
	JOIN #contratti
		ON #contratti.idpayroll = payrollabatement.idpayroll
	WHERE idabatement in( 28,68)
		AND #contratti.padre IS NULL 
 
	 SET @detrazioni_familiari_a_carico = ISNULL(@detrazioni_familiari_a_carico,0)
	-- SET @detrazioni_annue_familiari_a_carico = ISNULL(@detrazioni_annue_familiari_a_carico,0)

	
	-- Calcolo della detrazione per reddito
	-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
	-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
	-- Si considera ovviamente la sola detrazione con codice 29 che si riferisce al reddito
	DECLARE @detrazioni_per_reddito DECIMAL(19,2)
	--DECLARE @detrazioni_annue_per_reddito DECIMAL(19,2)
	
	SELECT @detrazioni_per_reddito = SUM(payrollabatement.curramount)
		 -- @detrazioni_annue_per_reddito = SUM(payrollabatement.annualamount)
		FROM payrollabatement
		JOIN #contratti
			ON #contratti.idpayroll = payrollabatement.idpayroll
		WHERE idabatement in ( 29,69)
			AND #contratti.padre IS NULL
 
	 SET @detrazioni_per_reddito = ISNULL(@detrazioni_per_reddito,0)
	 --SET @detrazioni_annue_per_reddito = ISNULL(@detrazioni_annue_per_reddito,0)
	
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
	JOIN #contratti
		ON #contratti.idpayroll = payrollabatement.idpayroll
	JOIN abatement
		ON abatement.idabatement = payrollabatement.idabatement
	WHERE abatement.flagabatableexpense = 'S'
		AND #contratti.padre IS NULL 
	  
	SET @detrazioni_per_oneri = ISNULL(@detrazioni_per_oneri,0)
	--SET @detrazioni_annue_per_oneri = ISNULL(@detrazioni_annue_per_oneri,0)
                        
    -- Totale detrazioni  
    DECLARE @totale_detrazioni DECIMAL(19,2)
	SET @totale_detrazioni  = @detrazioni_familiari_a_carico  + @detrazioni_per_reddito  + @detrazioni_per_oneri 
	-- Calcolo della deduzione art. 10
	-- Essa è pari alla somma tra gli oneri sostenuti in altri contratti  e la somma delle deduzioni
	-- applicate sui cedolini associati ai contratti non divenuti CUD per altri e la cui prestazione
	-- ricade nella cetificazione CUD e che non abbiamo come ritenute fiscali nazionali quelle con codice
	-- 08_IRPEF_FOC o 07_IRPEF_FO
	-- Si considerano tutte le deduzioni associate alle ritenute fiscali locali
	
	DECLARE @deduzioni_art10 DECIMAL(19,2)
	SET @deduzioni_art10  =
	@onerisostenutiinaltricontratti +
	ISNULL(
		(SELECT SUM(cr.deduction)
		FROM payrolltax cr 
		JOIN #contratti
			ON #contratti.idpayroll = cr.idpayroll
		JOIN tax
			ON cr.taxcode=tax.taxcode
		WHERE taxkind = 1
			AND geoappliance = 'R'
		AND #contratti.padre IS NULL
		AND NOT EXISTS
			(SELECT * FROM servicetaxview
			WHERE servicetaxview.idser = #contratti.idser
				AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
		)
	,0) 
	-- Vengono prese le deduzioni associate alla sola ritenuta fiscale con applicazione regionale
	-- si poteva anche scegliere quella comunale ma ce ne sono due (acconto e saldo) e sarebbe stato + oneroso scegliere

	-- Calcolo della ritenute IRPEF
	-- Si considera la somma delle ritenute nette fiscali nazionali con codice differente
	-- da 08_IRPEF_FOC e 07_IRPEF_FO
	-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
	-- non pagano IRPEF e quindi il loro contributo è nullo
	DECLARE @ritenuta_irpef DECIMAL(19,2)
	SET @ritenuta_irpef =
	ISNULL(
		(SELECT SUM(expensetaxofficial.employtax)
		FROM #cedolini
		JOIN expenselink
			ON #cedolini.idexp = expenselink.idparent
		JOIN expensetaxofficial
			ON expensetaxofficial.idexp = expenselink.idchild
		JOIN tax ON expensetaxofficial.taxcode = tax.taxcode
		WHERE taxkind = 1 AND geoappliance IS NULL
            AND expensetaxofficial.stop is null
			AND tax.taxref NOT IN ('08_IRPEF_FOC','07_IRPEF_FO'))
	,0)

	-- Al primo calcolo parziale, si somma anche la ritenuta IRPEF applicata nei CUD cartacei associati ai contratti
	SET @ritenuta_irpef =
	@ritenuta_irpef +
	ISNULL(
		(SELECT SUM(exhibitedcud.irpefapplied)
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi
			AND exhibitedcud.idlinkedcon IS NULL)
		--and not exists (SELECT * from license where ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy)
		,0)
		
	-- Calcolo della addizionale regionale all'IRPEF
		-- Si considera la somma delle ritenute nette fiscali regionali dei cedolini associati a contratti
		-- che non hanno ritenute con codice uguale a 08_IRPEF_FOC e 07_IRPEF_FO
		-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
		-- non pagano le addizionali regionali e quindi il loro contributo è nullo
	DECLARE @ritenuta_addreg_irpef DECIMAL(19,2)	
	SET @ritenuta_addreg_irpef =
		ISNULL(
			(SELECT SUM(expensetaxofficial.employtax)
			FROM #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode=tax.taxcode
			WHERE taxkind = 1 AND geoappliance = 'R'
                                    and expensetaxofficial.stop is null
				AND NOT EXISTS
				(SELECT * FROM servicetaxview
				WHERE servicetaxview.idser = #contratti.idser
					AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
			)
		,0) 
		
		SET @ritenuta_addreg_irpef =
		@ritenuta_addreg_irpef +
		ISNULL(
			(SELECT SUM(exhibitedcud.regionaltaxapplied)
			FROM exhibitedcud
			JOIN #contratti
				ON #contratti.idcon = exhibitedcud.idcon
			WHERE fiscalyear = @annoredditi
				AND exhibitedcud.idlinkedcon IS NULL)
		,0)

		-- Calcolo dell'acconto all'addizionale comunale all'IRPEF
		-- Si considera la somma degli acconti specificati all'interno dei contratti
		DECLARE @ritenuta_addcom_irpef_acconto_2014 DECIMAL(19,2)
		SET @ritenuta_addcom_irpef_acconto_2014 =
		ISNULL(
			(SELECT SUM(citytax_account)
			FROM parasubcontractyear
			WHERE idcon IN (SELECT DISTINCT idcon FROM #contratti)
				AND ayear = @annoredditi)
		,0)

		-- Al primo calcolo parziale, si somma anche l'acconto all'addizionale comunale applicata nei CUD
		-- cartacei associati ai contratti
		SET @ritenuta_addcom_irpef_acconto_2014 =
		@ritenuta_addcom_irpef_acconto_2014 +
		ISNULL(
			(SELECT SUM(exhibitedcud.citytax_account)
			FROM exhibitedcud
			JOIN #contratti
				ON #contratti.idcon = exhibitedcud.idcon
			WHERE fiscalyear = @annoredditi
			AND exhibitedcud.idlinkedcon IS NULL)
		,0)
		-- Calcolo della addizionale comunale all'IRPEF
		-- Si considera la somma delle ritenute nette fiscali comunali con codice pari a 05_ADDCOMU
		-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
		-- non pagano le addizionali regionali e quindi il loro contributo è nullo
		DECLARE @ritenuta_addcom_irpef_saldo_2014 DECIMAL(19,2)
		SET @ritenuta_addcom_irpef_saldo_2014 =
		ISNULL(
			(SELECT SUM(employtax)
			FROM #cedolini
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode=tax.taxcode
			WHERE tax.taxref = '05_ADDCOMU' and expensetaxofficial.stop is null)
		,0)

	-- Al primo calcolo parziale, si somma anche l'addizionale comunale applicata nei CUD cartacei associati ai contratti
	SET @ritenuta_addcom_irpef_saldo_2014 =
	@ritenuta_addcom_irpef_saldo_2014 +
	ISNULL(
		(SELECT SUM(exhibitedcud.citytaxapplied)
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi
			AND exhibitedcud.idlinkedcon IS NULL)
	,0)

	-- Il saldo dell'addizionale comunale è pari alla differenza tra addizionale comunale e acconto alla stessa
	SELECT @ritenuta_addcom_irpef_saldo_2014  = @ritenuta_addcom_irpef_saldo_2014 - @ritenuta_addcom_irpef_acconto_2014   

	-- Se il saldo è negativo si valorizza il solo campo inerente all'acconto impostando a NULL il campo del saldo
	-- altrimenti si valorizza il campo del saldo impostando a NULL il campo dell'acconto
	if @ritenuta_addcom_irpef_saldo_2014 < 0
	begin
		set @ritenuta_addcom_irpef_acconto_2014 = @ritenuta_addcom_irpef_acconto_2014 + @ritenuta_addcom_irpef_saldo_2014
		set @ritenuta_addcom_irpef_saldo_2014 = null
	end
	else
	begin
		if @ritenuta_addcom_irpef_acconto_2014 < 0
		begin
			set @ritenuta_addcom_irpef_saldo_2014 = @ritenuta_addcom_irpef_saldo_2014 + @ritenuta_addcom_irpef_acconto_2014
			set @ritenuta_addcom_irpef_acconto_2014 = null
		end
	end
			 
	
	-- Conteggio dei giorni lavorati
	DECLARE @workingdays INT
	SELECT @workingdays = count(*) from #workdays where worked='S'

	-- Se i giorni lavorati superano l'anno si pongono pari al numero di giorni dell'anno
	-- non è contemplato, a quanto pare, l'anno bisestile
	IF @workingdays>365 
	BEGIN
		SET @workingdays=365
	END
--setuser 'amm'
	---------------------------------------------------------
	-- Redditi assoggettati a ritenuta a titolo di imposta --
	---------------------------------------------------------
	-- Tabella delle prestazioni adoperate nei contratti
	CREATE TABLE #ser (idser int, codeser varchar(20))
	
	-- Inserimento delle prestazioni associate ai contratti che non sono divenuti CUD per altri
	INSERT INTO #ser (idser, codeser)
	SELECT DISTINCT service.idser, service.codeser
	FROM service
	JOIN #contratti ON service.idser = #contratti.idser
	--WHERE #contratti.padre IS NULL
	
	-- Codice ritenute per stranieri in convenzione
	DECLARE @tax_convenzione int
	SET @tax_convenzione = NULL

	SELECT @tax_convenzione = taxcode FROM tax WHERE taxref = '07_IRPEF_FC'

	-- Calcolo del flag straniero_conv	
	DECLARE @straniero_conv char(1)
	-- Si considera uno straniero in convenzione se esiste almeno una prestazione legata al percipiente
	-- che ha associata la ritenuta con codice 07_IRPEF_FC
	SET @straniero_conv =
	CASE
		WHEN
		ISNULL((SELECT COUNT(*)
		FROM #ser
		JOIN servicetax
			ON servicetax.idser = #ser.idser
		WHERE servicetax.taxcode = @tax_convenzione),0) = 0
		THEN 'N'
		ELSE 'S'
	END
	
	DECLARE @prestazione_esente char(1) -- indica esenzione da imposizione fiscale 
	
	SET @prestazione_esente = 
	CASE
		WHEN
		ISNULL((SELECT COUNT(*)
		FROM #ser
		WHERE EXISTS
		( SELECT *  
			FROM servicetaxview 
		   WHERE servicetaxview.idser = #ser.idser
		     AND servicetaxview.taxkind = 1))
		,0) = 0
		THEN 'S'
		ELSE 'N'
	END
	
	IF
	(SELECT COUNT(*)
	FROM #ser
	JOIN servicetax
		ON #ser.idser = servicetax.idser
	JOIN tax
		ON tax.taxcode = servicetax.taxcode
	WHERE tax.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')) > 0
	BEGIN
	

		
	DECLARE @taxablegross_irpef_stranieri decimal(19,2)
	DECLARE @ritenuta_irpef_stranieri decimal(19,2)
	-- Calcolo dei redditi ai quali si possono applicare le deduzioni art. 11
	-- Esso è pari alla somma degli imponibili lordi delle ritenute fiscali con codice 08_IRPEF_FOC o 07_IRPEF_FO
	-- associate ai contratti del percipiente. I contratti da considerare sono solo quelli associati alla certificazione
	-- CUD che non sono diventati a loro volta CUD per altri contratti. 
			
	SELECT  	@taxablegross_irpef_stranieri   = SUM (cr.taxablegross)
		FROM	#contratti	 			 
				JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
				JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
				JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	AND geoappliance IS NULL
				WHERE #contratti.padre IS NULL AND tax.taxref <> '14_BONUS_FISCALE'
					AND EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
								         AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
								         
	SET @taxablegross_irpef_stranieri  = ISNULL(@taxablegross_irpef_stranieri,0)
 
	SET @taxablegross_irpef_stranieri = @taxablegross_irpef_stranieri + ISNULL (
		(SELECT SUM(p.feegross) 	FROM	#contratti	 			 
				JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
				WHERE #contratti.padre IS NULL
					AND EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
								         AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
					AND NOT EXISTS(SELECT * FROM payrolltax cr
										JOIN tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	
										 AND geoappliance IS NULL
										WHERE   cr.idpayroll= P.idpayroll)
		),0)
	
	SET @taxablegross_irpef_stranieri  = ISNULL(@taxablegross_irpef_stranieri,0)
 
	-- Calcolo della ritenute IRPEF
	-- Si considera la somma delle ritenute nette fiscali nazionali con codice uguale
	-- a 08_IRPEF_FOC o 07_IRPEF_FO
	SET @ritenuta_irpef_stranieri  =
	ISNULL(
		(SELECT SUM(expensetaxofficial.employtax)
		FROM #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
		JOIN expenselink
			ON #cedolini.idexp = expenselink.idparent
		JOIN expensetaxofficial
			ON expensetaxofficial.idexp = expenselink.idchild
		JOIN tax
			ON expensetaxofficial.taxcode = tax.taxcode
		WHERE taxkind = 1 AND geoappliance IS NULL
                                    and expensetaxofficial.stop is null
			AND EXISTS
				(SELECT * FROM servicetaxview
				WHERE servicetaxview.idser = #contratti.idser
				AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
	,0) +
	ISNULL(
		(SELECT SUM(exhibitedcud.irpefapplied)
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi
			AND exhibitedcud.idlinkedcon IS NULL
			AND EXISTS
				(SELECT * FROM servicetaxview
				WHERE servicetaxview.idser = #contratti.idser
				AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
	,0)
				
	END
	
	--------------------------------------------------------------------------------------------
	------------- CALCOLI SEZIONE 3 INPS GESTIONE DIPENDENTI PUBBLICI (EX INPDAP) --------------
	--------------------------------------------------------------------------------------------
	--	PRESTAZIONE CONSIDERATA 14_DIPENDPUBBLICI
	--  RITENUTE CONSIDERATE '07_INPDAP_CAMM','07_INPDAP_CDIP', '14_Rit. L.438/9','07_FDOCRE' 
 
	IF
	(SELECT COUNT(*)
	FROM #ser
	WHERE 	#ser.codeser = '14_DIPENDPUBBLICI'
	--tax.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP', '14_Rit. L.438/9','07_FDOCRE' )
	) 
	> 0
	BEGIN
		
	DECLARE @taxablegross_dipendentipubblici				decimal(19,2)
	DECLARE @ritenuta_previdenziale_dipendentipubblici		decimal(19,2)
	DECLARE @ritenuta_previdenziale_dipendentipubblici_dip	decimal(19,2)
	DECLARE @ritenuta_previdenziale_dipendentipubblici_amm	decimal(19,2)
	DECLARE @taxablegross_fondocredito_dipendentipubblici	decimal(19,2)
	DECLARE @ritenuta_fondocredito_dipendentipubblici		decimal(19,2)
	
	-- Esso è pari alla somma degli imponibili lordi delle ritenute previdenziali con codice 07_INPDAP_CAMM o 07_INPDAP_CDIP o 14_Rit. L.438/9
	-- associate ai contratti del percipiente. I contratti da considerare sono solo quelli associati alla certificazione
	-- CUD che non sono diventati a loro volta CUD per altri contratti. 
									         
	SET  @taxablegross_dipendentipubblici = ISNULL(( SELECT SUM(cr.taxablegross)
		FROM	#contratti	 			 
				JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
				JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
				JOIN    tax ON cr.taxcode = tax.taxcode  AND taxkind = 3	 
				WHERE  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
										 AND servicetaxview.codeser = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  cr.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM'))	),0)
										 
								         	
	-- Si considera la somma delle ritenute   previdenziali nazionali con codice uguale
	-- a '07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/9'
	SET @ritenuta_previdenziale_dipendentipubblici_dip  =
	ISNULL(
		(SELECT SUM(expensetaxofficial.employtax)
		FROM #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
		JOIN expenselink
			ON #cedolini.idexp = expenselink.idparent
		JOIN expensetaxofficial
			ON expensetaxofficial.idexp = expenselink.idchild
		JOIN tax
			ON expensetaxofficial.taxcode = tax.taxcode
		WHERE taxkind = 3  
            AND  expensetaxofficial.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
										 AND servicetaxview.codeser = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  tax.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/9' ))
	),0)	
	
	SET @ritenuta_previdenziale_dipendentipubblici_amm  =
	ISNULL(
		(SELECT SUM(expensetaxofficial.admintax)
		FROM #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
		JOIN expenselink
			ON #cedolini.idexp = expenselink.idparent
		JOIN expensetaxofficial
			ON expensetaxofficial.idexp = expenselink.idchild
		JOIN tax
			ON expensetaxofficial.taxcode = tax.taxcode
		WHERE taxkind = 3  
            AND  expensetaxofficial.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
										 AND servicetaxview.codeser = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  tax.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/9' ))
	),0)	
	
	SET @ritenuta_previdenziale_dipendentipubblici = @ritenuta_previdenziale_dipendentipubblici_dip + @ritenuta_previdenziale_dipendentipubblici_amm

	
	SELECT  @taxablegross_fondocredito_dipendentipubblici =  SUM (cr.taxablegross)
	FROM	#contratti	 			 
			JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
			JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
			JOIN tax ON cr.taxcode = tax.taxcode  AND taxkind = 3	AND tax.taxref = '07_FDOCRE' 
			WHERE EXISTS (SELECT * FROM servicetaxview
						       WHERE servicetaxview.idser = #contratti.idser
									 AND servicetaxview.codeser = '14_DIPENDPUBBLICI')	
	
	
	--	Calcolo della ritenute PREVIDENZIALI CON CODICE FONDO CREDITO
	-- Si considera la somma delle ritenute   previdenziali nazionali con codice uguale
	-- a '07_FDOCRE'
	SET @ritenuta_fondocredito_dipendentipubblici  =
	ISNULL(
		(SELECT SUM(expensetaxofficial.employtax)
		FROM #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
		JOIN expenselink
			ON #cedolini.idexp = expenselink.idparent
		JOIN expensetaxofficial
			ON expensetaxofficial.idexp = expenselink.idchild
		JOIN tax
			ON expensetaxofficial.taxcode = tax.taxcode
		WHERE taxkind = 3  
            AND  expensetaxofficial.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
							       	 AND servicetaxview.taxcode =  tax.taxcode
										 AND servicetaxview.codeser = '14_DIPENDPUBBLICI'
								         AND servicetaxview.taxref = '07_FDOCRE')
	),0)	
	+
	ISNULL(
		(SELECT SUM(expensetaxofficial.admintax)
		FROM #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
		JOIN expenselink
			ON #cedolini.idexp = expenselink.idparent
		JOIN expensetaxofficial
			ON expensetaxofficial.idexp = expenselink.idchild
		JOIN tax
			ON expensetaxofficial.taxcode = tax.taxcode
		WHERE taxkind = 3  
            AND  expensetaxofficial.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = #contratti.idser
							       	 AND servicetaxview.taxcode =  tax.taxcode
										 AND servicetaxview.codeser = '14_DIPENDPUBBLICI'
								         AND servicetaxview.taxref = '07_FDOCRE')
	),0)	
	
	declare @mesiSenzaEmensdipendentipubblici VARCHAR(12)
	declare @emensTuttiIMesidipendentipubblici int
	-- Calcolo dei mesi dove non è stato prodotto l'E-Mense
	set @mesiSenzaEmensdipendentipubblici = --todo: eliminare i mesi in cui inps=0
		  case WHEN exists (SELECT * from #cedolini
		  JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 1 and year(datacompetenza)=@annoredditi 
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S'
			) THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 2 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S')  THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 3 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 4 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 5 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 6 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 7 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 8 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 9 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=10 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=11 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)=12 and year(datacompetenza)=@annoredditi
			AND #contratti.codeser = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
	
	SET @emensTuttiIMesidipendentipubblici = 0
	IF (@mesiSenzaEmensdipendentipubblici = REPLICATE('0',12))
	BEGIN
		SET @emensTuttiIMesidipendentipubblici = 1
	END
							
	END		         
	--------------------------------------------------------------------------------------------
	-- Calcolo delle detrazioni derivanti da oneri detraibili ----------------------------------
	-- Si considerano gli oneri associati ai contratti non divenuti CUD per altri --------------
	-- e che sono associati  alla certificazione CUD -------------------------------------------
	--------------------------------------------------------------------------------------------
	---- Siccome nel 2014 non sono stati usati oneri detraibili su suggerimento sia ------------
	---- di antonio che Nino non si compila la sezione -----------------------------------------
	--------------------------------------------------------------------------------------------
	--create table #oneridetraibili
	--(
	--	idcon varchar(8),
	--	oneridetraibili decimal(19,2),
	--	cod_oneredetraibile varchar(20)
	--)
	
	--insert into #oneridetraibili
	--(
	--	idcon,
	--	oneridetraibili,
	--	cod_oneredetraibile
	-- )
	
	
	--SELECT
	--	#contratti.idcon,
	--	ISNULL( SUM(
	--		CASE
	--			WHEN ISNULL(abatableexpense.totalamount,0) <=
	--			ISNULL(abatementcode.maximal, ISNULL(abatableexpense.totalamount,0))
	--			THEN ISNULL(abatableexpense.totalamount,0)
	--			ELSE abatementcode.maximal
	--		END 
	--		- ISNULL(abatementcode.exemption,0)
	--	),0),
	--	abatementcode.code
	--	FROM abatableexpense 
	--	JOIN #contratti
	--		ON #contratti.idcon = abatableexpense.idcon
	--	JOIN abatementcode
	--		ON abatableexpense.idabatement = abatementcode.idabatement
	--	WHERE abatableexpense.ayear = @annoredditi
	--		AND abatementcode.ayear=@annoredditi
	--		AND #contratti.padre IS NULL
	--		AND #contratti.certificatekind = 'U' 
			
	--	DECLARE @oneridetraibili DECIMAL(19,2)
	--	DECLARE @cod_oneredetraibile varchar(20)
 
	--	DECLARE rowcursor INSENSITIVE CURSOR FOR
	--	SELECT  oneridetraibili,cod_oneredetraibile
	--	FROM    #oneridetraibili

	--	FOR READ ONLY
	--	OPEN rowcursor
	--	FETCH NEXT FROM rowcursor
	--	INTO @oneridetraibili, @cod_oneredetraibile
	--	WHILE @@FETCH_STATUS = 0
	--	BEGIN 
	--		-------------------------------------------
			
	--		FETCH NEXT FROM rowcursor
	--		INTO @oneridetraibili, @cod_oneredetraibile
	--	END 
	--	DEALLOCATE rowcursor
	--	END


	DECLARE @totale_redditi_altri_soggetti DECIMAL(19,2)
	SET @totale_redditi_altri_soggetti  = --@DB001301
					ISNULL(
						(SELECT SUM(taxablegross)
						FROM exhibitedcud
						JOIN #contratti
							ON #contratti.idcon = exhibitedcud.idcon
						WHERE fiscalyear = @annoredditi 
							AND NOT EXISTS (SELECT * FROM license where ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy))
					,0)
					
	create table #redditialtrisoggetti
	(
		idcon varchar(8),
		cf_altro_sostituto varchar(16),
		reddito_conguagliato decimal(19,2),
		ritenute_irpef decimal(19,2),
		addizionale_regionale_irpef decimal(19,2),
		addizionale_comunale_irpef_acconto decimal(19,2),
		addizionale_comunale_irpef_saldo decimal(19,2)
	)
	
	insert into #redditialtrisoggetti
	(
		idcon,
		cf_altro_sostituto,					-- @DB001305
		reddito_conguagliato,               -- @DB001308
		ritenute_irpef,						-- @DB001313
		addizionale_regionale_irpef,		-- @DB001315
		addizionale_comunale_irpef_acconto, -- @DB001316
		addizionale_comunale_irpef_saldo	-- @DB001317
	)	 
	SELECT  
		#contratti.idcon,
		exhibitedcud.cfotherdeputy,
		exhibitedcud.taxablegross,
		exhibitedcud.irpefapplied,
		exhibitedcud.regionaltaxapplied,
		exhibitedcud.citytax_account,
		exhibitedcud.citytaxapplied
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi 
			AND NOT EXISTS 
			(SELECT * FROM license 
			  WHERE  ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy )
	
	----------------------------------------------------------------------------------------------------------------
	-------- Dati previdenziali ed assistenziali INPS - Sezione 2 - Collab. Coordinate e continuative 47 -----------
	----------------------------------------------------------------------------------------------------------------
	IF
	(SELECT COUNT(*)
	FROM #ser
	WHERE 	#ser.codeser <> '14_DIPENDPUBBLICI'
	--tax.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP', '14_Rit. L.438/9','07_FDOCRE' )
	) 
	> 0
	BEGIN
		-- Calcolo dell'imponibile previdenziale dei cedolini
		-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
		-- alla ritenuta previdenziale
		update #cedolini set compensoprev = (SELECT max(taxablegross)
			from expensetaxofficial
			join tax on expensetaxofficial.taxcode=tax.taxcode
			join expenselink
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			WHERE #cedolini.idexp = expenselink.idparent
				and taxkind = 3 and expensetaxofficial.stop is null 
				AND #contratti.codeser <> '14_DIPENDPUBBLICI')

		-- Calcolo della ritenuta previdenziale c/dipendente dei cedolini
		-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
		-- alla ritenuta previdenziale
		update #cedolini set ritprevtrattenuta = (SELECT isnull(sum(employtax),0)
			from expensetaxofficial
			join tax on expensetaxofficial.taxcode=tax.taxcode
			join expenselink
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			WHERE #cedolini.idexp = expenselink.idparent
				and taxkind = 3 and expensetaxofficial.stop is null
				AND #contratti.codeser <> '14_DIPENDPUBBLICI')

		-- Calcolo della ritenuta previdenziale c/amministrazione dei cedolini
		-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
		-- alla ritenuta previdenziale
		update #cedolini set inpsamm = (SELECT isnull(sum(admintax),0) 
			from expensetaxofficial
			join tax on expensetaxofficial.taxcode=tax.taxcode
			join expenselink
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			WHERE #cedolini.idexp = expenselink.idparent
				and taxkind = 3 and expensetaxofficial.stop is null
				AND #contratti.codeser <> '14_DIPENDPUBBLICI')
				
				
		declare @mesiSenzaEmens VARCHAR(12)
		declare @emensTuttiIMesi int
		-- Calcolo dei mesi dove non è stato prodotto l'E-Mense
		set @mesiSenzaEmens = --todo: eliminare i mesi in cui inps=0
			  case WHEN exists (SELECT * from #cedolini
			  JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 1 and year(datacompetenza)=@annoredditi 
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 2 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
				JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 3 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				where month(datacompetenza)= 4 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				where month(datacompetenza)= 5 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 6 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				where month(datacompetenza)= 7 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 8 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 9 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=10 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=11 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)=12 and year(datacompetenza)=@annoredditi
				AND #contratti.codeser <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		
		SET @emensTuttiIMesi = 0
		IF (@mesiSenzaEmens = REPLICATE('0',12))
		BEGIN
			SET @emensTuttiIMesi = 1
		END

		DECLARE @compensoprev DECIMAL(19,2)
		DECLARE @ritprevdovuta DECIMAL(19,2)
		DECLARE @ritprevtrattenuta DECIMAL(19,2)
		DECLARE @ritprevpagata DECIMAL(19,2)
		DECLARE @ritprevamministrazione DECIMAL(19,2)
		
		SELECT	@compensoprev = sum(compensoprev),
				@ritprevdovuta = sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),
				@ritprevtrattenuta = sum(ritprevtrattenuta),
				@ritprevpagata = sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),
				@ritprevamministrazione = sum(ISNULL(inpsamm,0))
		FROM #cedolini JOIN #contratti
		ON #contratti.idcon = #cedolini.idcon
		AND #contratti.codeser <> '14_DIPENDPUBBLICI'

		SELECT  @compensoprev = isnull(@compensoprev, 0) + isnull(sum(exhibitedcud.taxablepension),0),
				@ritprevdovuta = isnull(@ritprevdovuta, 0) + isnull(sum(exhibitedcud.inpsowed),0),
				@ritprevtrattenuta = isnull(@ritprevtrattenuta, 0) + isnull(sum(exhibitedcud.inpsretained),0),
				@ritprevpagata = isnull(@ritprevpagata, 0) + isnull(sum(exhibitedcud.inpsowed),0),
				@ritprevamministrazione = isnull(@ritprevamministrazione,0) + ISNULL(sum(inpsowed),0)
		FROM exhibitedcud
		JOIN #contratti on #contratti.idcon = exhibitedcud.idcon
		AND #contratti.codeser <> '14_DIPENDPUBBLICI'
		WHERE exhibitedcud.fiscalyear = @annoredditi
		AND NOT EXISTS(SELECT * FROM license WHERE ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy)

	END

	-------------------------------------------------------------------------------------------------
	---------------------- Dati relativi al coniuge e ai familiari a carico -------------------------
	-------------------------------------------------------------------------------------------------

	-- Svuotamento delle tabelle dei familiari
	truncate table #coniuge
	truncate table #primofiglio
	truncate table #altrofiglio

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
	-- Definizione del cursore che cicla su tutti i familiari presenti solamente sul contratto CAPOFILA,
	-- i familairi devono risultare a carico e devono avere una applicazione ricadente nel periodo dell'anno
	-- in cui sono maturati i redditi
	declare @cursFamigliare cursor
	set @cursFamigliare = cursor for 
	SELECT
		F.idcon,
		F.idfamily, F.birthdate, F.idaffinity,
		ISNULL(F.startapplication, @1gen14_XXX),
		ISNULL(F.stopapplication, @31dic14_XXX),
		ISNULL(F.starthandicap, @1gen15_XXX),
		ISNULL(F.cf, ''),
		ISNULL(F.appliancepercentage, 1)
	FROM parasubcontractfamily F
	JOIN #contratti
		ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
	AND #contratti.capofila = 'S'
	AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
	AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
	AND (F.flagdependent is null or F.flagdependent = 'S')  
	order by idaffinity, birthdate
	
	open @cursFamigliare
	fetch next from @cursfamigliare into @idcontract,@idfamily, @birthdate, @idaffinity, @startapplication,
	@stopapplication, @starthandicap, @cfFamigliare, @appliancePercentage 
	-- Ciclo sui familiari
	WHILE (@@fetch_status=0) 
	begin
		-- Si contano i figli maggiori dalla tabella #primofiglio
		declare @figlimaggiori int
		SELECT  @figlimaggiori = count(*) from #primofiglio
		set     @figlimaggiori = isnull(@figlimaggiori, 0)

		set @meseinizio = 1
		set @mesefine = 12

		-- Si definiscono i mesi di inizio e fine pari ai mesi delle date di inizio e fine applicazione	
		if year(@startapplication) = @annoredditi
			set @meseinizio = month(@startapplication)

		if year(@stopapplication) = @annoredditi
			set @mesefine = month(@stopapplication)

		set @mese = @meseinizio

		-- Si cicla partendo dal mese inizio arrivando al mese di fine
		WHILE @mese <= @mesefine
		begin
			set @detrazionePerConiugeACarico = ''
			if @figlimaggiori = 0 and isnull(@appliancepercentage,1) = 1 and
					not exists (SELECT * from parasubcontractfamily where idcon = @idcontract and idaffinity='C' ) 
			begin
				set @detrazionePerConiugeACarico = 'C'
			end

			declare @diffhand int
			set @diffhand = datediff(m, @starthandicap, dateadd(m, @mese-1, @1gen14_XXX))

			declare @casellaparentela char(2)
			SET @casellaparentela = 'A'

			if @idaffinity = 'C' set @casellaParentela = 'C'

			if @idaffinity = 'F' and @figlimaggiori = 0 and @diffhand < 0
				set @casellaParentela = 'F1'

			if @idaffinity = 'F' and @figlimaggiori = 0 and @diffhand >= 0
				set @casellaParentela = 'D1'

			if @idaffinity = 'F' and @figlimaggiori > 0 and @diffhand < 0
				set @casellaParentela = 'F'

			if @idaffinity = 'A' and @diffhand < 0
				set @casellaParentela = 'A'

			if @diffhand >= 0 and (@idaffinity = 'A' or @idaffinity = 'F' and @figlimaggiori > 0)
				set @casellaParentela = 'D'

			-- Gestione del coniuge
			if @casellaParentela = 'C' 
			begin
				declare @idconiuge int
				set @idconiuge = null

				SELECT @idconiuge = idconiuge from #coniuge
					where codiceFiscaleConiuge = @cfFamigliare
					and anno = @annoredditi

				if @idconiuge is not null
				begin
					update #coniuge set
						numeroMesiACarico = numeroMesiACarico + 1 
						where idconiuge = @idconiuge
				end ELSE begin
					SELECT @idconiuge = 1 + count(*) from #coniuge

					insert into #coniuge values (
						@idconiuge,
						@cfFamigliare,
						1,
						@annoredditi)
				end
			end

			-- Gestione della detrazione per priomo figlio
			if (@idaffinity = 'F' and @figlimaggiori = 0) 
			begin
				declare @idPrimoFiglio int
				set @idPrimoFiglio = null

				SELECT @idPrimoFiglio = idPrimoFiglio
					from #primofiglio
					where (casellaPrimoFiglio =1 and @casellaParentela='F1' 
						or  casellaDisabile =1 and @casellaParentela='D1')
					and codiceFiscalePrimoFiglio = @cfFamigliare
					and detrazionePerConiugeACarico = @detrazionePerConiugeACarico
					and anno = @annoredditi

				if @idPrimoFiglio is not null
				begin
					update #PrimoFiglio set
						numeroMesiACarico  = isnull(numeroMesiACarico,0) + 1,
						minoreDiTreAnni = isnull(minoreDiTreAnni,0) + case WHEN datediff(m, dateadd(m, @mese-1, @1gen14_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 ELSE 0 end,
						percentualeDiDetrazioneSpettante  = isnull(percentualeDiDetrazioneSpettante,0) 
											+ isnull(@appliancepercentage,1)
						where idPrimoFiglio = @idPrimoFiglio
				end ELSE begin
					SELECT @idPrimoFiglio = 1 + count(*) from #primofiglio

					insert into #PrimoFiglio values (
						@idprimofiglio,
						case @casellaParentela WHEN 'F1' THEN '1' end,
						case @casellaParentela WHEN 'D1' THEN '1' end,
						@cfFamigliare,
						1,
						case WHEN datediff(m, dateadd(m, @mese-1, @1gen14_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 end,
						case @detrazionePerConiugeACarico WHEN '' THEN isnull(@appliancepercentage,1) end,
						@detrazionePerConiugeACarico,
						@annoredditi)
				end
			end
		
			-- Gestione detrazione per altri figli
			if @casellaParentela IN ('F', 'A', 'D')
			begin
				declare @idAltroFiglio int
				set @idAltroFiglio = null
				SELECT @idAltroFiglio = idAltroFiglio
					from #altrofiglio
					where (casellaFiglio = 1 and @casellaParentela='F' 
						or casellaAltroFamiliare = 1 and @casellaParentela='A'
						or casellaDisabile =1 and @casellaParentela='D')
					and codiceFiscaleFamiliare  = @cfFamigliare
					and  detrazionePerConiugeACarico  = @detrazionePerConiugeACarico
					and  anno = @annoredditi

				if @idAltroFiglio is not null
				begin
					update #AltroFiglio set
						numeroMesiACarico = isnull(numeroMesiACarico,0) + 1,
						minoreDiTreAnni   = isnull(minoreDiTreAnni,0) + 
								case WHEN datediff(m, dateadd(m, @mese-1, @1gen14_XXX), 
									dateadd(yy, 3, @birthdate)) >= 0 THEN 1 
									ELSE 0 
								end,
						percentualeDiDetrazioneSpettante = isnull(percentualeDiDetrazioneSpettante,0)
											 + isnull(@appliancepercentage,1)
						where idAltroFiglio = @idAltroFiglio
				end ELSE begin
					SELECT @idAltroFiglio = 1 + count(*) from #altrofiglio
					insert into #AltroFiglio values (
						@idaltrofiglio,
						case @casellaParentela WHEN 'F' THEN '1' end,
						case @casellaParentela WHEN 'A' THEN '1' end,
						case @casellaParentela WHEN 'D' THEN '1' end,
						@cfFamigliare,
						1,
						case WHEN datediff(m, dateadd(m, @mese-1, @1gen14_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 end,
						case @detrazionePerConiugeACarico WHEN '' THEN isnull(@appliancepercentage,1) end,
						@detrazionePerConiugeACarico,
						@annoredditi
					)
				end
			end
			set @mese = @mese + 1
		end

		fetch next from  @cursfamigliare into @idcontract,@idfamily, @birthdate, @idaffinity, @startapplication,
		@stopapplication, @starthandicap, @cfFamigliare, @appliancePercentage
	end
	
    --------------------------------------------- 
	---- Record G, parte non  posizionale -------
	--------------------------------------------- 
	--------------------------------------------------------------------------------------------
	---------- Dati fiscali  Dati per la eventuale compilazione della dichiarazione ------------
	---------------------------------- SEZIONE REDDITI -----------------------------------------
	--------------------------------------------------------------------------------------------
	---- NB. questa sezione va compilata solo per i redditi imponibili ai fini fiscali, --------
	-------------------------------- no assegnisti ---------------------------------------------
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001001 DECIMAL(19,2) -- Redditi di lavoro dipendente e assimilati
	DECLARE @DB001002 INT			-- Casella Determinato/indeterminato (Vale 1 o 2)
	DECLARE	@DB001006 INT			-- Numero di giorni per i quali spettano le detrazioni di lavoro dipendente
 
	DECLARE @DB001008 DATETIME		-- Data inizio Rapporto di Lavoro
	DECLARE @DB001009 DATETIME		-- Data fine Rapporto di Lavoro
	DECLARE @DB001010 INT			-- Casella "con interruzione"
 
	SET @DB001001= isnull(@taxablegross,0) 

	-- Conteggio dei giorni lavorati
	-- select * from #workdays 
	-- select * from #contratti
	IF isnull(@taxablegross,0) <> 0
	BEGIN
		SET @DB001002= 2
		SET @DB001006= @workingdays
		SET @DB001008= @start -- Data inizio Rapporto di Lavoro
		SET @DB001009= @stop  -- Data fine Rapporto di Lavoro
		--SELECT @workingdays
		--SELECT datediff(d,@start, @stop) + 1
		IF @workingdays < (datediff(d,@start, @stop) + 1)
			SET @DB001010= 1 --  con interruzione
		ELSE 
			SET @DB001010= 0
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '001', @DB001001)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	  VALUES(@progrCom, 1, 'DB001', 1, '002', @DB001002)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '006', @DB001006)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data)	  VALUES(@progrCom,1,  'DB001', 1, '008', @DB001008)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data)     VALUES(@progrCom,1,  'DB001', 1, '009', @DB001009)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '010', @DB001010)

	END

	
	--select * from #recordG  
   	--------------------------------------------------------------------------------------------
   	---------------------------------- SEZIONE RITENUTE ----------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001011 DECIMAL(19,2) -- Ritenute IRPEF
	DECLARE @DB001012 DECIMAL(19,2)	-- Addizionale regionale all'Irpef
	DECLARE	@DB001017 DECIMAL(19,2)	-- Addizionale comunale all'Irpef - Saldo 2014
	
	SET @DB001011= isnull(@ritenuta_irpef,0)
	SET @DB001012= isnull(@ritenuta_addreg_irpef,0)
	SET @DB001017= isnull(@ritenuta_addcom_irpef_saldo_2014,0)
 
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '011', @DB001011)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '012', @DB001012)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '017', @DB001017)
	--select * from #recordG  
   	--------------------------------------------------------------------------------------------
	--------------------------------- ONERI DETRAIBILI -----------------------------------------
	--------------------------------------------------------------------------------------------
	---- Siccome nel 2014 non sono stati usati oneri detraibili su suggerimento sia ------------
	---- di antonio che Nino non si compila la sezione -----------------------------------------
	--DECLARE @DB001071 INT				-- Codice onere detraibile
	--DECLARE @DB001072 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001073 INT				-- Codice onere detraibile
	--DECLARE @DB001074 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001075 INT				-- Codice onere detraibile
	--DECLARE @DB001076 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001077 INT				-- Codice onere detraibile
	--DECLARE @DB001078 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001079 INT				-- Codice onere detraibile
	--DECLARE @DB001080 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001081 INT				-- Codice onere detraibile
	--DECLARE @DB001082 DECIMAL (19,2)	-- Importo Onere
	
	--SET @DB001071= isnull(@oneridetraibili,0)
	--SET @DB001072= isnull(@cod_oneredetraibile,0)
	--SET @DB001073= isnull(@oneridetraibili,0)
	--SET @DB001074= isnull(@cod_oneredetraibile,0)
	--SET @DB001075= isnull(@oneridetraibili,0)
	--SET @DB001076= isnull(@cod_oneredetraibile,0)
	--SET @DB001077= isnull(@oneridetraibili,0)
	--SET @DB001078= isnull(@cod_oneredetraibile,0)
	--SET @DB001079= isnull(@oneridetraibili,0)
	--SET @DB001080= isnull(@cod_oneredetraibile,0)
	--SET @DB001081= isnull(@oneridetraibili,0)
	--SET @DB001082= isnull(@cod_oneredetraibile,0)
	
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '071', @DB001071)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '072', @DB001072)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '073', @DB001073)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '074', @DB001074)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '075', @DB001075)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '076', @DB001076)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '077', @DB001077)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '078', @DB001078)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '079', @DB001079)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '080', @DB001080)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '081', @DB001081)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '083', @DB001082)

	--------------------------------------------------------------------------------------------
	-------------------------------- DETRAZIONI E CREDITI --------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001101 DECIMAL (19,2)	-- Imposta Lorda
	DECLARE @DB001102 DECIMAL (19,2)	-- Detrazioni per carichi di famiglia
	DECLARE @DB001107 DECIMAL (19,2)	-- Detrazione per lavoro dipendente, pensioni e redditi assimilati
	DECLARE @DB001108 DECIMAL (19,2)	-- Totale Detrazioni per oneri
	DECLARE @DB001113 DECIMAL (19,2)	-- Totale detrazioni
	 
	SET @DB001101= isnull(@employtaxgross,0)
	SET @DB001102= isnull(@detrazioni_familiari_a_carico,0)
	SET @DB001107= isnull(@detrazioni_per_reddito,0)
	SET @DB001108= isnull(@detrazioni_per_oneri,0)
	SET @DB001113= isnull(@totale_detrazioni,0)
	
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '101', @DB001101)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '102', @DB001102)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '107', @DB001107)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '108', @DB001108)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '113', @DB001113)
	--select * from #recordG  
	--------------------------------------------------------------------------------------------
	----------------------------------- SEZIONE BONUS ------------------------------------------
	--------------------------------------------------------------------------------------------
	---------- NB. Questa sezione va compilata solo per redditi imponibili ai fini IRPEF -------
	---  non per assegnisti e prestazioni esenti , dove mettiamo solo dati previdenziali -------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001119 INT				-- CREDITO BONUS IRPEF - Codice Bonus Vale 1 o 2
	DECLARE @DB001120 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus erogato
	DECLARE @DB001121 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus non erogato
	
	IF ISNULL(@taxablegross,0) <> 0
	BEGIN
		SET @DB001119= 2 -- non riconosciuto
		SET @DB001120= 0
		SET @DB001121= 0
		
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DB001', 1, '119', @DB001119)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '120', @DB001120)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '121', @DB001121)
	END
	--select * from #recordG  
	--------------------------------------------------------------------------------------------
	----------------------------------- ONERI DEDUCIBILI --------------------------------------- 
	--------------------------------------------------------------------------------------------
	--DECLARE @DB001161 DECIMAL (19,2)	-- Totale oneri deducibili esclusi dai redditi indicati nei punti 1, 3, 4 e 5
	--DECLARE @DB001162 DECIMAL (19,2)	-- Totale oneri deducibili non esclusi dai redditi indicati nei punti 1, 3, 4 e 5
	--DECLARE @DB001163 DECIMAL (19,2)	-- Contributi versati a enti e casse aventi esclusivamente fini assistenziali dedotti
	--DECLARE @DB001164 DECIMAL (19,2)	-- Contributi versati a enti e casse aventi esclusivamente fini assistenziali non dedotti
	--DECLARE @DB001166 INT				-- Assicurazioni Sanitarie
	
	--SET @DB001161= isnull(@deduzioni_art10,0)
	--SET @DB001162= 0
	--SET @DB001163= 0
	--SET @DB001164= 0
	--SET @DB001166= 0
	
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '161', @DB001161)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '162', @DB001162)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '163', @DB001163)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '164', @DB001164)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB001', 1, '166', @DB001166)
 
	--------------------------------------------------------------------------------------------
	-------------------------------------- ALTRI DATI ------------------------------------------ 
	--------------------------------------------------------------------------------------------
	--DECLARE @DB001191 int	-- Applicazione maggiore ritenuta CB
	
	--SET @DB001191 = (SELECT 
	--CASE
	--	WHEN (SELECT COUNT(*) FROM #contratti WHERE ISNULL(highertax,0) > 0) > 0 THEN '1'
	--	ELSE null
	--END )
	
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DB001', 1, '191', @DB001191)
 	--------------------------------------------------------------------------------------------
	-------------- Redditi assoggettati a ritenuta a titolo di imposta ------------------------- 
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001221 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale redditi
	DECLARE @DB001222 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef
	DECLARE @DB001223 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef sospese
	
	SET @DB001221= isnull(@taxablegross_irpef_stranieri,0)
	SET @DB001222= isnull(@ritenuta_irpef_stranieri,0)
	-- SET @DB001223= 0
	
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '221', @DB001221)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '222', @DB001222)
	-- INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '123', @DB001223)
	--------------------------------------------------------------------------------------------
	-------- Dati relativi ai conguagli in caso di Redditi erogati da altri soggetti -----------
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001301 DECIMAL(19,2)		-- Totale redditi conguagliati già compresi nel punto 1
	DECLARE @DB001305 VARCHAR(16)	    -- Codice fiscale
	DECLARE @DB001308 DECIMAL(19,2)		-- Reddito conguagliato già compreso nel punto 1
	DECLARE @DB001313 DECIMAL(19,2)	    -- Ritenute
	DECLARE @DB001315 DECIMAL(19,2)		-- Addizionale regionale
	DECLARE @DB001316 DECIMAL(19,2)	    -- Addizionale comunale Acconto 2014
	DECLARE @DB001317 DECIMAL(19,2)	    -- Addizionale comunale Saldo 2014
	
	SET @DB001301= isnull(@totale_redditi_altri_soggetti,0)
		
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom, 1, 'DB001', 1, '301', @DB001301)
	
	DECLARE @cf_altro_sostituto		varchar(16)
	DECLARE @reddito_conguagliato 	decimal(19,2)
	DECLARE @ritenute_irpef			decimal(19,2)
	DECLARE @addizionale_regionale_irpef		 decimal(19,2)
	DECLARE @addizionale_comunale_irpef_acconto  decimal(19,2)
	DECLARE @addizionale_comunale_irpef_saldo    decimal(19,2)
	DECLARE @counter	int
	
	SET @counter = 0
	DECLARE rowcursor INSENSITIVE CURSOR FOR
	SELECT  cf_altro_sostituto,reddito_conguagliato,ritenute_irpef,
			addizionale_regionale_irpef,addizionale_comunale_irpef_acconto,
			addizionale_comunale_irpef_saldo
	FROM    #redditialtrisoggetti

	FOR READ ONLY
	OPEN rowcursor
	FETCH NEXT FROM rowcursor
	INTO	@cf_altro_sostituto,@reddito_conguagliato,@ritenute_irpef,
			@addizionale_regionale_irpef,@addizionale_comunale_irpef_acconto,
			@addizionale_comunale_irpef_saldo
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		SET @counter  = @counter + 1
		SET @DB001305 = @cf_altro_sostituto					 
		SET @DB001308 = @reddito_conguagliato					 
		SET @DB001313 = @ritenute_irpef	 
		SET @DB001315 = @addizionale_regionale_irpef 
		SET @DB001316 =	@addizionale_comunale_irpef_acconto	 
		SET @DB001317 =	@addizionale_comunale_irpef_saldo
	
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)  VALUES(@progrCom,1, 'DB001', @counter, '305', @DB001305)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '308', @DB001308)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '313', @DB001313)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '315', @DB001315)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '316', @DB001316)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '317', @DB001317)

	FETCH NEXT FROM rowcursor
	INTO	@cf_altro_sostituto,@reddito_conguagliato,@ritenute_irpef,
			@addizionale_regionale_irpef,@addizionale_comunale_irpef_acconto,
			@addizionale_comunale_irpef_saldo
	END 
	DEALLOCATE rowcursor
	END
	
	

	-------------------------------------------------------------------------------------------------
	---------------------- Dati relativi al coniuge e ai familiari a carico -------------------------
	-------------------------------------------------------------------------------------------------
	
	--DECLARE @DB801001	VARCHAR(20)--Relazione di parentela	CB
	--DECLARE @DB801004	VARCHAR(16)--Codice fiscale	CF
	--DECLARE @DB801005	INT--Mesi a carico	N2
	--DECLARE @DB802001	VARCHAR(20)--Relazione di parentela	AN
	--DECLARE @DB802004	VARCHAR(16)--Codice fiscale	CF
	--DECLARE @DB802005	INT--Mesi a carico	N2
	--DECLARE @DB802006	INT--Minore di tre anni	N2
	--DECLARE @DB802008	CHAR(1)--Detrazione 100% affidamento figli	CB
	--DECLARE @DB802A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	--DECLARE @DB802B07	CHAR(1)--Percentuale di detrazione spettante	AN
	--DECLARE @DB803001	VARCHAR(20)--Relazione di parentela	AN
	--DECLARE @DB803004	VARCHAR(16)--Codice fiscale	CF
	--DECLARE @DB803005	INT--Mesi a carico	N2
	--DECLARE @DB803006	INT--Minore di tre anni	N2
	--DECLARE @DB803008	CHAR(1)--Detrazione 100% affidamento figli	CB
	--DECLARE @DB803A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	 
	-- Si procede all'inserimento dei dati inerenti i familiari all'interno della tabella di output
	-- estraendoli dalle tabelle definite per i familiari a carico
	
	-----------------------------------------------------------
	---------------- LETTURA DATI CONIUGE ---------------------
	-----------------------------------------------------------
	-- DECLARE @DB801001 VARCHAR(20)--Relazione di parentela	CB
	INSERT INTO #recordg (progr, modulo, quadro, riga, colonna, intero) 
		SELECT @progrCom, 1, 'DB801', idconiuge, '001', 1 FROM #coniuge
		
	-- DECLARE @DB801004 VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 1, 'DB801', idconiuge, '004', 
		codiceFiscaleConiuge FROM #coniuge WHERE  
		codiceFiscaleConiuge <> ''

	-- DECLARE @DB801005	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero) 
	SELECT @progrCom, 1, 'DB801', idconiuge, '005', 
	numeroMesiACarico FROM #coniuge numeroMesiACarico
	
	-----------------------------------------------------------
	------------- LETTURA DATI PRIMO FIGLIO -------------------
	-----------------------------------------------------------

	--DECLARE @DB802001	VARCHAR(20)--Relazione di parentela	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom,  1,'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '001', 
		CASE  WHEN casellaDisabile   =  1 then 'D' 
		ELSE  'F'
		END 
		FROM #primofiglio

	-- DECLARE @DB802004	VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 1, 'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '004', 
		codiceFiscalePrimoFiglio from #primofiglio 
		where codiceFiscalePrimoFiglio <> ''

	--DECLARE @DB802005	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1,'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '005', 
		numeroMesiACarico  from #primofiglio

	--DECLARE @DB802006	INT--Minore di tre anni	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1,'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1),idprimofiglio, '006', 
		minoreDiTreAnni from #primofiglio

	--DECLARE @DB802A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	INSERT INTO #recordg (progr, modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1, 'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, 'A07', 
		100 * percentualeDiDetrazioneSpettante / numeroMesiACarico 
		from #primofiglio where detrazionePerConiugeACarico <> 'C'

	--DECLARE @DB802B07	CHAR(1)--Percentuale di detrazione spettante	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 1, 'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, 'B07', detrazionePerConiugeACarico 
		from #primofiglio where detrazionePerConiugeACarico = 'C'
		
	--DECLARE @DB802008	CHAR(1)--Detrazione 100% affidamento figli	CB
		--INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
		--SELECT @progrCom, 'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '008', 1 
		--from #primofiglio where detrazionePerConiugeACarico = 'C'
	
	-----------------------------------------------------------
	------------- LETTURA DATI ALTRI FIGLI --------------------
	-----------------------------------------------------------	
	-- DECLARE @DB803001	VARCHAR(20)--Relazione di parentela	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom,  1, 'DB80'+ CONVERT(VARCHAR(3),idaltrofiglio+2),1, '001', 
		CASE  WHEN casellaDisabile = 1 then 'D'
			  WHEN casellaFiglio = 1 THEN 'F' 
			  WHEN casellaAltroFamiliare = 1 THEN 'A'
			  else null
		END
		FROM #altrofiglio

	-- DECLARE @DB803004	VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom,  1, 'DB80'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'004', codiceFiscaleFamiliare
		FROM #altrofiglio

	--DECLARE @DB803005	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1, 'DB80'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'005', numeroMesiACarico 
		FROM #altrofiglio

	--DECLARE @DB803006	INT--Minore di tre anni	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero) 
		SELECT @progrCom,  1, 'DB80'+ CONVERT(VARCHAR(3),idaltrofiglio+2),1, '006', minoreDiTreAnni 
		FROM #altrofiglio where minoreDiTreAnni <> ''

	--DECLARE @DB803A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC si può omettee se c'è la percentuale
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom, 1, 'DB80'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'A07',
		100 * percentualeDiDetrazioneSpettante/numeroMesiACarico 
		FROM #altrofiglio where detrazionePerConiugeACarico <> 'C'

	--DECLARE @DB803B07	CHAR(1)--Percentuale di detrazione spettante	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom, 1, 'DB80'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'B07', 'C'  
		FROM #altrofiglio where detrazionePerConiugeACarico = 'C'
		
	--DECLARE @DB802008	CHAR(1)--Detrazione 100% affidamento figli	CB
	--INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
	--	SELECT @progrCom, 'DB80' + CONVERT(VARCHAR(3),idaltrofiglio +1), '008', 0 
	--	FROM #altrofiglio where detrazionePerConiugeACarico = 'C'

	----------------------------------------------------------------------------------------------------------------
	-------- Dati previdenziali ed assistenziali INPS - Sezione 2 - Collab. Coordinate e continuative 47 -----------
	----------------------------------------------------------------------------------------------------------------
	IF
	((SELECT	COUNT(*)
		FROM	#ser
		WHERE 	#ser.codeser <> '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@compensoprev,0) > 0))
	BEGIN
		DECLARE @DC001001	VARCHAR(10)		-- Matricola azienda N10
		DECLARE @DC001009	DECIMAL (19,2)	-- Compensi corrisposti al collaboratore VP
		DECLARE @DC001010	DECIMAL (19,2)	-- Contributi dovuti VP
		DECLARE @DC001011	DECIMAL (19,2)	-- Contributi a carico del collaboratore trattenuti VP
		DECLARE @DC001012	DECIMAL (19,2)	-- Contributi versati VP
		DECLARE @DC001013	INT				-- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DC001014	VARCHAR(12)		-- Mesi per i quali è stata presentata la denuncia UniEmens
		
		SET @DC001001 = @agencynumber 
		SET @DC001009= isnull(@compensoprev,0)
		SET @DC001010= isnull(@ritprevdovuta,0)
		SET @DC001011= isnull(@ritprevtrattenuta,0)
		SET @DC001012= isnull(@ritprevpagata,0)
		SET @DC001013= isnull(@emensTuttiIMesi,0)
		SET @DC001014= @mesiSenzaEmens
		--exec exp_certificazioneunica_g_15 21,1
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '001', @DC001001)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '009', @DC001009)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '010', @DC001010)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '011', @DC001011)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '012', @DC001012)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '013', @DC001013)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '014', @DC001014)
	END
	------------------------------------------------------------------------------------------------------------------------------
	----------------------------------- Sezione 3 - INPS GESTIONE DIPENDENTI PUBBLICI (EX INPDAP) --------------------------------
	------------------------------------------------------------------------------------------------------------------------------
	IF
	((SELECT COUNT(*)
		FROM #ser
		WHERE 	#ser.codeser = '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@taxablegross_dipendentipubblici,0) > 0))
	BEGIN
		DECLARE @DC001015	VARCHAR(16)	    -- Codice fiscale Amministrazione	  
		DECLARE @DC001016	VARCHAR(10)		-- Progressivo azienda
		DECLARE @DC001018	INT				-- Gestione Pensionistica
		DECLARE @DC001020	INT				-- Gestione Credito
		DECLARE @DC001022	INT				-- Anno di riferimento	
		DECLARE @DC001023	DECIMAL (19,2)	-- Totale imponibile pensionistico	
		DECLARE @DC001024	DECIMAL (19,2)	-- Totale contributi pensionistici
		DECLARE @DC001029	DECIMAL (19,2)	-- Totale imponibile Gestione Credito
		DECLARE @DC001030	DECIMAL (19,2)	-- Totale contributo Gestione Credito
		DECLARE @DC001033	INT				-- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DC001034	VARCHAR(12)		-- Mesi per i quali è stata presentata la denuncia UniEmens
 
		SET @DC001015 =	@codfiscEnte -- Codice fiscale Amministrazione	  
		SET @DC001016 = '00000'   -- Progressivo azienda
		SET @DC001018 = 1		  -- Gestione Pensionistica
		SET @DC001020 = 9         -- Gestione Credito
		SET @DC001022 = @annoredditi   -- Anno di riferimento	
		SET @DC001023 = @taxablegross_dipendentipubblici			  -- Totale imponibile pensionistico	
		SET @DC001024 = @ritenuta_previdenziale_dipendentipubblici	  -- Totale contributi pensionistici
		SET @DC001029 = @taxablegross_fondocredito_dipendentipubblici -- Totale imponibile Gestione Credito
		SET @DC001030 = @ritenuta_fondocredito_dipendentipubblici     -- Totale contributo Gestione Credito
		SET @DC001033 = isnull(@emensTuttiIMesidipendentipubblici,0)
		SET @DC001034 = @mesiSenzaEmensdipendentipubblici
	
 		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '015', @DC001015)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '016', @DC001016)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '018', @DC001018)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '020', @DC001020)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '022', @DC001022)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '023', @DC001023)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '024', @DC001024)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '029', @DC001029)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '030', @DC001030)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '033', @DC001033)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '034', @DC001034)
	END 
 	---------------------------------------------------------------------------------------------------------------------------
	------------------------------------------------- Dati assicurativi INAIL -------------------------------------------------
	------------------------------ PER IL PRIMO ANNO SI PUO' SCEGLIERE DI NON COMPILARLA --------------------------------------
	---------------------------------------------------------------------------------------------------------------------------
	--DECLARE @DC001035 CHAR(1)		-- Qualifica AN Vale B, C, D, E, F,G, H, L, M, N, P,Q, Z
	--DECLARE @DC001036 INT			-- Posizione assicurativa territoriale N11
	--DECLARE @DC001037 DATETIME	-- Data inizio D4
	--DECLARE @DC001038 DATETIME	-- Data fine D4
	--DECLARE @DC001039 VARCHAR(10)	-- Codice comune AN .
	--DECLARE @DC001040 INT			-- Personale viaggiante CB 
	
	--SET @DC001035= isnull(@taxablegross,0)
	--SET @DC001036= isnull(@taxablegross,0)
	--SET @DC001037= isnull(@taxablegross,0)
	--SET @DC001038= isnull(@taxablegross,0)
	--SET @DC001039= isnull(@taxablegross,0)
	--SET @DC001040= isnull(@taxablegross,0)
	
	--INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom, 'DC001', 1, '035', @DC001035)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)	VALUES(@progrCom, 'DC001', 1, '036', @DC001036)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, data)		VALUES(@progrCom, 'DC001', 1, '037', @DC001037)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, data)		VALUES(@progrCom, 'DC001', 1, '038', @DC001038)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom, 'DC001', 1, '039', @DC001039)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)	VALUES(@progrCom, 'DC001', 1, '040', @DC001040)
	
------------------------------------------------------------------------------------------------------------------
------------------------------------ INSERIMENTO DELLE ANNOTAZIONI -----------------------------------------------
------------------------------------------------------------------------------------------------------------------
--AC – La detrazione per carichi di famiglia è stata calcolata in relazione alla durata del rapporto di lavoro.
--Nel caso di rapporto di lavoro inferiore all’anno solare, il sostituto calcola la detrazione 
--per carichi di famiglia in relazione al periodo di lavoro, salvo che il sostituito non abbia richiesto 
--espressamente di poterne fruire per l’intero periodo di imposta (qualora ne ricorrano i presupposti). 
--Nel caso in cui le suddette detrazioni siano state determinate in relazione al periodo di lavoro, 
--il sostituto ne deve dare comunicazione al percipiente nelle annotazioni (cod. AC).
--------------- NOI LE APPLICHIAMO SEMPRE PER INTERO PERCIO' QUESTE ANNOTAZIONI NON VANNOI SCRITTE ---------------- 
-------------------------------------------------------------------------------------------------------------------

	--AI - Informazioni relative al reddito/i certificato/i: tipologia (…), data inizio e data fine per ciascun periodo di lavoro o pensione (…), importo (… ).
	--Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, rapporto a tempo determinato, data inizio e data fine per ciascun periodo di lavoro dal …. Al ….  importo euro …..
	--(Da valorizzare ogni volta che è valorizzato il campo 1 Redditi di lavoro dipendente e assimilati....)

	--"AJ - Redditi totalmente esentati da imposizione in Italia: indicare Importo del reddito."
	--(Quando si usa una prestazione che abbia il flag sul tipo di prestazione "Per residenti all'estero" e la prestazione non ha ritenute fiscali associate), 
	-- Indicare l'importo lordo del reddito

	--"AL - Le addizionali regionali e comunali sono state interamente trattenute. "
	--(Costante quando i campi relativi alle addizionali comunali e regionali sono stati valorizzati)

	--AM - "Rimborsi effettuati dal sostituto a seguito di assistenza fiscale" (verificare la presenza nel contratto dei rimborsi IRPEF da CAF)
	--"Credito Irpef Rimborsato: importo del sostituito e importo del coniuge"
	--"Credito addizionale regionale rimborsaro: importo del sostituito e importo del coniuge"
	--"Credito addizionale comunale rimborsaro: importo del sostituito e importo del coniuge"

	--"AN - La detrazione minima è stata ragguagliata al periodi di lavoro. Il percipiente può fruire della detrazione per l'intero anno in sede di dichiarazione dei redditi, semprechè non sia stata già attribuita da un altro datore di lavoro e risulti effettivamente spettante."
	--(Nel caso di rapporti di lavoro a tempo determinato o a tempo indeterminato di durata inferiore all’anno (inizio o cessazione del rapporto di lavoro nel corso dell’anno), limitatamente ai contratti in cui è stato scelto di applicare la detrazione)

	--"AR - Dettaglio oneri deducibili: descrizione onere, importo. Tali importi non vanno riportati nella dichiarazione dei redditi"
	--(Nel contratto abbiamo la possibilità di inserire gli oneri deducibili)

	--"AX - Reddito assimilato assoggettato a ritenuta a titolo d'imposta, indicare importo, indicare ritenuta a titolo d'imposta operata."
	--(Valorizzare quando il compenso è un parasubordinato ed è associata ad una ritenuta IRPEF del 30%. La stessa condizione che abbiamo quando valorizziamo il campi del modello 221 e 222)

	--"BB - Saldo dell'addizionale comunale all'IRPEF non operata in quanto in possesso dei requisiti reddituali per usufruire interamente della fascia di esenzione deliberata"
	--(Da indicare quando non si calcola l'addizionale comunale all'IRPEF perchè il reddito rientra nei limiti di esenzione. Ad esempio se il comune prevede una fascia di esenzione dell'addizionale comunale all'IRPEF)

	--"BQ - Redditi totalmente esentati da imposizione in Italia: indicare Importo del reddito."
	--(Qundo si usa una prestazione che non abbia il falg in tipo prestazione sull'opzione "Per residenti all'estero" e la prestazione non ha ritenute fiscali associate)

	--"GH - Le operazioni di conguaglio sono state effettuate con riferimento ad un domicilio fiscale individuata sulla base della precedente normativa, il contribuente deve procedere alla presentazione della dichiarazione dei redditi per la corretta liquidazione delle imposte dovute."
	--(Tale dicitura deve esserci quando il percipiente ha cambiato indirizzo nel corso dell'anno 2014 e il contratto non è arrivato al 31/12/2014, quindi il contratto si chiude a fine anno)
	-- Gestione delle note AI e AJ
	-- Queste note per ogni contratto o CUD cartaceo presentato devono annotare il periodo di lavoro e la tipologia
	-- di lavoro intrapresa tra il percipiente ed il datore di lavoro
	-- La nota AI vale per i soli percipienti che non sono stranieri in convenzione
	-- mentre la nota AJ deve essere specificata per gli stranieri, dove sis specifica che il reddito è risultato 
	-- esente in Italia
	DECLARE @NN VARCHAR(400)
	DECLARE @contacud int
	SET @contacud = 1
	DECLARE @contacudconvenzione int
	SET @contacudconvenzione = 1
	DECLARE @offset_ai int
	SET @offset_ai = 2

	DECLARE @ai_inserted char(1)
	SET @ai_inserted = 'N'

	DECLARE @aj_inserted char(1)
	SET @aj_inserted = 'N'

	DECLARE @ec_taxablegross decimal(19,2)
	DECLARE @ec_start datetime
	DECLARE @ec_stop datetime
	DECLARE @ec_idlinkedcon varchar(8)
	DECLARE @codeser varchar(20)
	--  Il cursore seleziona tutti i contratti la cui prestazione ricade nella certificazione CUD
	--  e tutti i CUD cartacei associati ai contratti.
	DECLARE #cud_crs INSENSITIVE CURSOR FOR
	SELECT
		#contratti.fiscaltaxablegross,
		payroll.start, payroll.stop, #contratti.idcon,
		#contratti.codeser
	FROM #contratti
	JOIN payroll
		ON #contratti.idcon = payroll.idcon
	WHERE payroll.flagbalance = 'S'
		AND payroll.fiscalyear = @annoredditi
		--AND #contratti.certificatekind = 'U'
	UNION ALL
	SELECT exhibitedcud.taxablegross, 
		exhibitedcud.start, exhibitedcud.stop, NULL,NULL
	FROM exhibitedcud
	JOIN #contratti
		ON #contratti.idcon = exhibitedcud.idcon
	WHERE exhibitedcud.idlinkedcon IS NULL
		AND exhibitedcud.fiscalyear = @annoredditi
		FOR READ ONLY
	
	--select * from #contratti
	 
	OPEN #cud_crs
	FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon,@codeser

	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		IF (@ec_idlinkedcon IS NOT NULL) 
		AND
		(SELECT COUNT(*)
		FROM #ser
		JOIN service
			ON #ser.idser = service.idser)> 0
		AND @straniero_conv = 'N'
		AND ISNULL(@taxablegross,0) > 0
		BEGIN
			---------------------------------------------------------
			------------------- NOTE AI -----------------------------
			---------------------------------------------------------
			
			-- Note dipendenti dai CUD
			SELECT @NN = 
				CASE 
					WHEN  @codeser = '07_BRS_GEN' 
					THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c) D.P.R. 917/86, '
					WHEN  @codeser IN ('07_COPENOINPS', '05_COORDM', '05_COORDN', 
					                   '05_COORDP', '05_COSTCON', '05_CORNOINPS', '05_COORDN_L.326/03', 
					                   '08_COSTCON_NOINPS', '10_COSTCONMUT', 
					                   'N_VISITINGPROFESSOR', 'M_VISITINGPROFESSOR', '14_COORNM10%IRPEF')
					THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c-bis) D.P.R. 917/86, '
					ELSE 'AI - Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, ' 
				END
				 +
				'Rapporto a tempo determinato,  da ' + CONVERT(varchar(16), @ec_start, 105) + ' a ' + CONVERT(varchar(16), @ec_stop, 105) + 
			 +  ' Importo: € ' + CONVERT(varchar(16), @ec_taxablegross)  
			-- [Nota AI] (Questa nota è sicuramente presente almeno per il contratto principale)
			-- 
			INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
				VALUES(@progrCom, 'NN', 1, @contacud, '001', @NN)
		END
		IF (@ec_idlinkedcon IS NOT NULL) 
			AND
			(SELECT COUNT(*)
			FROM #ser
			JOIN service
				ON #ser.idser = service.idser)> 0
			AND @straniero_conv = 'S'
			AND ISNULL(@taxablegross_irpef_stranieri,0) = 0 
		BEGIN
			-----------------------------------------------------------------
			-------------------------- NOTE AJ ------------------------------
			-- "AJ - Redditi totalmente esentati da imposizione in Italia: --
			---------------- indicare Importo del reddito." -----------------
			--  (Quando si usa una prestazione che abbia il flag ------------
			-- sul tipo di prestazione "Per residenti all'estero" -----------
			-- e la prestazione non ha ritenute fiscali associate), ---------
			---------- Indicare l'importo lordo del reddito ----------------- 
			-----------------------------------------------------------------
			DECLARE @previdenza decimal(19,2)
			SET @previdenza =
			ISNULL(
			(SELECT taxablepension
			FROM parasubcontractsummaryview
			WHERE idcon = @ec_idlinkedcon
			AND ayear = @annoredditi)
			,0)
			 
				SET @NN =
					'AJ - Redditi totalmente esentati da imposizione in Italia: '   
					+ 'Importo: € ' + CONVERT(varchar(16), @previdenza)  
				INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
					VALUES(@progrCom, 'NN', 1, @contacud, '002', @NN)
		END
		FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon,@codeser
		SET @contacud = @contacud + 1
		END
		
		CLOSE #cud_crs
		DEALLOCATE #cud_crs
	--------------------------------------------------------------------------------------------
	-- AM - "Rimborsi effettuati dal sostituto a seguito di assistenza fiscale" 
	-- (verificare la presenza nel contratto dei rimborsi IRPEF da CAF) ------------------------
	-- Credito Irpef Rimborsato: importo del sostituito e importo del coniuge" -----------------
	-- Credito addizionale regionale rimborsaro: importo del sostituito e importo del coniuge" -
	-- Credito addizionale comunale rimborsaro: importo del sostituito e importo del coniuge" --
	-- Non sono stati effettuati rimborsi dai sostituti ma bensì solo ritenute -----------------
    
    --------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
	-- "AN - La detrazione minima è stata ragguagliata al periodi di lavoro. -------------------
	-- Il percipiente può fruire della detrazione per l'intero anno in sede --------------------
	-- di dichiarazione dei redditi, semprechè non sia stata già attribuita --------------------
	-- da un altro datore di lavoro e risulti effettivamente spettante." -----------------------
	-- (Nel caso di rapporti di lavoro a tempo determinato -------------------------------------
	-- o a tempo indeterminato di durata inferiore ---------------------------------------------
	-- all’anno (inizio o cessazione del rapporto di lavoro nel corso dell’anno), --------------
	-- limitatamente ai contratti in cui è stato scelto di applicare la detrazione) ------------
	--------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
    
    -- NOTE AL
	IF ((@DB001012 <> 0)  --@ritenuta_addreg_irpef
		 OR 
		(@DB001017 <> 0)) --@ritenuta_addcom_irpef_saldo_2014
	BEGIN
		SET @NN =
		CASE 
			WHEN ((@DB001012 <> 0) AND  (@DB001017 = 0))  THEN 'AL - Le addizionali regionali sono state interamente trattenute.'
			WHEN ((@DB001017 <> 0) AND (@DB001012 = 0))  THEN 'AL - Le addizionali comunali sono state interamente trattenute.' 
			ELSE 'AL - Le addizionali regionali e comunali sono state interamente trattenute.'
		END
		    INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			VALUES(@progrCom, 'NN', 1, 1, '003', @NN)
	END	
		
	IF (@workingdays < 365)  AND (@taxablegross<> 0) AND (@DB001107 <> 0) 
	BEGIN
		SET @NN =
		'AN - La detrazione minima è stata ragguagliata al periodo di lavoro.' + 
		' Il percipiente può fruire della detrazione per l''intero anno in sede' +
		' di dichiarazione dei redditi, semprechè non sia stata già attribuita' +
		' da un altro datore di lavoro e risulti effettivamente spettante.'
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
		VALUES(@progrCom, 'NN', 1, 1, '004', @NN)
	END
	
	--	"AX - Reddito assimilato assoggettato a ritenuta a titolo d'imposta, 
	--  indicare importo, indicare ritenuta a titolo d'imposta operata."
	--  (Valorizzare quando il compenso è un parasubordinato ed è associata 
	--  ad una ritenuta IRPEF del 30%. 
	--  La stessa condizione che abbiamo quando valorizziamo il campi del modello 
	--  221 e 222)
	IF ((@DB001221 <> 0)  --@taxablegross_irpef_stranieri
		 OR 
	    (@DB001222 <> 0)) --@ritenuta_irpef_stranieri
	BEGIN
		SET @NN =
		'AX - Reddito assimilato assoggettato a ritenuta a titolo d''imposta,' +
		+ ' Importo: € ' + CONVERT(varchar(16), @taxablegross_irpef_stranieri) 
		+ ' Importo ritenuta a titolo d''imposta operata: € ' + CONVERT(varchar(16), @ritenuta_irpef_stranieri)   
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
		VALUES(@progrCom, 'NN', 1, 1, '005', @NN)
	END
	

	
	-- "BB - Saldo dell'addizionale comunale all'IRPEF non operata in quanto 
	-- in possesso dei requisiti reddituali per usufruire interamente della fascia
	-- di esenzione deliberata"
	-- (Da indicare quando non si calcola l'addizionale comunale all'IRPEF 
	-- perchè il reddito rientra nei limiti di esenzione. 
	-- Ad esempio se il comune prevede una fascia di esenzione 
	-- dell'addizionale comunale all'IRPEF)
	-- NOTE AL
	IF
	(SELECT COUNT(*)
	FROM #ser
	JOIN servicetax
		ON #ser.idser = servicetax.idser
	JOIN tax
		ON tax.taxcode = servicetax.taxcode
	WHERE tax.taxref IN ('05_ADDCOMU')) > 0
	AND
	(@DB001017 =  0) --@ritenuta_addcom_irpef_saldo_2014 non applicata
	BEGIN
		SET @NN =
		'BB - Saldo dell''addizionale comunale all''IRPEF non operata in quanto' + 
		' in possesso dei requisiti reddituali per usufruire interamente della fascia' +
		' di esenzione deliberata'
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			VALUES(@progrCom, 'NN', 1, 1, '006', @NN)
	END
	
	-- GH - Le operazioni di conguaglio sono state effettuate con riferimento 
	-- ad un domicilio fiscale individuata sulla base della precedente normativa, 
	-- il contribuente deve procedere alla presentazione della dichiarazione dei redditi per la corretta liquidazione delle imposte dovute."
	-- (Tale dicitura deve esserci quando il percipiente ha cambiato indirizzo 
	-- nel corso dell'anno 2014 e il contratto non è arrivato al 31/12/2014, 
	-- quindi il contratto si chiude a fine anno)
 	
		CREATE TABLE #comuniaddcom
	(
		idcon int,
		idcedolino int,
		idcity int,
		idfiscaltaxregion int ,
		codcatastale varchar(4)
	)
	
	INSERT INTO #comuniaddcom
	(idcon, idcedolino, idcity, idfiscaltaxregion,codcatastale)
	SELECT #contratti.idcon, #contratti.idpayroll, payrolltax.idcity, payrolltax.idfiscaltaxregion, G.value
	FROM payrolltax 
	JOIN #contratti ON #contratti.idpayroll = payrolltax.idpayroll
	JOIN tax ON tax.taxcode = payrolltax.taxcode
	LEFT OUTER JOIN geo_city_agency G  -- lettura del codice catastale
    ON  G.idcity = payrolltax.idcity
    AND G.idagency = 1 and G.idcode = 1
	WHERE tax.taxref = '05_ADDCOMU' 
	
	--select * from #comuniaddcom
	
	DECLARE @cod_catastale_01_01_15 varchar(4)
	SET @cod_catastale_01_01_15 = (SELECT stringa FROM #recordG WHERE quadro = 'DA002' and colonna = '025')

	IF (@cod_catastale_01_01_15 IS NOT NULL) 
	AND EXISTS (SELECT codcatastale FROM #comuniaddcom WHERE ISNULL(codcatastale,'') <> @cod_catastale_01_01_15)
 
	BEGIN
		SET @NN =
		'GH - Le operazioni di conguaglio sono state effettuate con riferimento 
		 ad un domicilio fiscale individuato sulla base della precedente normativa, 
		 il contribuente deve procedere alla presentazione della dichiarazione dei redditi 
		 per la corretta liquidazione delle imposte dovute.'
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			 VALUES(@progrCom, 'NN', 1, 1, '007', @NN)
	END
	
	IF 
	((@DC001011 <> 0)  -- @ritprevtrattenuta
	 OR 
     (@DC001012 <> 0)) --@ritprevpagata
	BEGIN
		SET @NN =
		'ZZ - Le ritenute INPS trattenute ai sensi della Legge 335/95 art.2/c.26 e Legge 449/97 art.59/c.16' +
		' sono state regolarmente versate all''INPS: ' +
		' ritenute a carico percipiente: € ' + CONVERT(varchar(16), @ritprevtrattenuta)  +
		' e ritenute a carico ente: € ' + CONVERT(varchar(16), @ritprevamministrazione)
 
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			 VALUES(@progrCom, 'NN', 1, 1, '008', @NN)
	END
	
	IF (@DB001001 = 0) AND (@prestazione_esente = 'S') -- imponibile IRPEF Italiani
	BEGIN
		 SET @NN =
		 'BQ - Redditi totalmente esentati da imposizione: € ' + CONVERT(varchar(16),@compensoprev) + ') ' 
		 INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			 VALUES(@progrCom, 'NN', 1, 1, '009', @NN)
	END
 
	
IF (@print = 'S')
BEGIN
	SELECT * FROM #recordG 
	WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL OR decimale<>0
END
ELSE
BEGIN
	SELECT * FROM #recordG 
	WHERE (stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL OR decimale<>0)
	AND ltrim(rtrim(quadro)) <> 'NN'
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 --exec exp_certificazioneunica_g_15 687,1,'S'
 --exec exp_certificazioneunica_g_15 1666,1,'S'
 --exec exp_certificazioneunica_g_15 1752,1,'S'
 --exec exp_certificazioneunica_g_15 2367,1,'S'
 --exec exp_certificazioneunica_g_15 2545,1,'S'
 --exec exp_certificazioneunica_g_15 2785,1,'S'

 --exec exp_certificazioneunica_g_15 1785,1,'S'
 --exec exp_certificazioneunica_g_15 1110,1,'S'
 --exec exp_certificazioneunica_g_15 6398,1,'S'

 --exec exp_certificazioneunica_percipienti_g_15
 
 --select * from tAX ORDER BY DESCRIPTION
 
 
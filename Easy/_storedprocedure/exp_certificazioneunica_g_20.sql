
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_g_20]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_g_20]
GO
 
CREATE PROCEDURE [exp_certificazioneunica_g_20]
 -- estraggo il record H relativo ad un determinato percipiente, il progressivo comunicazione
 -- indica l'ordine all'interno dei percipienti del sostituto d'imposta
(
	 @idreg int,
	 @progrCom int,
	 @print char(1)  -- vale S per la stampa N altrimenti
	 --@newprogrCom int out
) 
 
-- exec exp_certificazioneunica_g_20  478,1,'S' 
AS BEGIN 
	declare @annodichiarazione int
	set @annodichiarazione = 2020

	declare @annoredditi int
	set @annoredditi = 2019

	declare @31dic19 datetime
	set @31dic19 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1
 
-- Sezione dichiarativa	
	DECLARE @progrModulo int -- normalmente costante pari a uno
	DECLARE @codfiscEnte varchar(16)
	DECLARE @idcityente varchar(16)
	DECLARE @au1cf varchar(16) -- codice fiscale del percipiente

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	SET @progrModulo = 1
 
	SELECT @au1cf =  isnull(cf,p_iva) FROM registry
	WHERE registry.idreg = @idreg
	
	
	DECLARE @agencynumber VARCHAR(10)
		
	SELECT @agencynumber =  agencynumber FROM config
	WHERE  ayear = @annodichiarazione
	
	SELECT  @codfiscEnte = cf, @idcityEnte = idcity FROM license
	
	DECLARE @codiceComuneEnte VARCHAR(4)
	SET @codiceComuneEnte = null
	
	SELECT @codiceComuneEnte = value from geo_city_agency   -- CODICE CATASTALE COMUNE ENTE 
	WHERE  idcode=1 and idcity=@idcityente and idagency=1
			
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
	exec exp_certificazioneunica_d_20  @idreg, @progrCom, 'G',NULL, @print
	
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
	declare @1gen19_XXX datetime
	set @1gen19_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @13gen19_XXX datetime
	set @13gen19_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-13'})

	declare @31dic19_XXX datetime
	set @31dic19_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen20_XXX datetime
	set @1gen20_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-01'})

	declare @12gen19_XXX datetime
	set @12gen19_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

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
		stopcontract datetime, -- Data Fine del Contratto
		capofila char(1),
		certificatekind char(1),
		idser int,
		servicecode770 varchar(20),
		highertax decimal(19,2),
		applicaritprevidenziali char(1),
		flagbonusappliance char(1),
		exemptioncode INT,
		flagsummarybalance char(1), -- questo flag indica se il cedolino di conguaglio è fittizio
		idemenscontractkind varchar(2)
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
		inail decimal(19,2)
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
		anno int,
		flagdependent char
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
				fiscaltaxablegross, idpayroll,start, stop,stopcontract, 
				certificatekind, idser, servicecode770, highertax,
				applicaritprevidenziali, flagbonusappliance, exemptioncode,
				flagsummarybalance, idemenscontractkind)
	SELECT
		co.idcon,
		s.taxablepension,
		s.inpsinail,
		s.deduction,
		s.fiscaltaxablegross,
		ce.idpayroll,
		ce.start,
		ce.stop,
		co.stop,
		service.certificatekind,
		co.idser,
		ISNULL(service.servicecode770,service.codeser),
		im.highertax,
		CASE
			WHEN EXISTS (SELECT * FROM servicetaxview ST  
			              WHERE ST.idser = service.idser
						    AND ST.taxkind = 3) THEN 'S'
			ELSE 'N'
		END,
		im.flagbonusappliance,
		motive770service.exemptioncode,
		ce.flagsummarybalance,
		im.idemenscontractkind 
	FROM payroll ce 
	JOIN parasubcontract co						ON co.idcon = ce.idcon
    JOIN parasubcontractyear im					ON co.idcon = im.idcon
													AND im.ayear = @annoredditi
    JOIN parasubcontractsummaryview s			ON s.idcon = im.idcon
													AND s.ayear = im.ayear
	JOIN service								ON service.idser = co.idser
	LEFT OUTER JOIN motive770service			ON service.idser = motive770service.idser
													AND motive770service.ayear = @annoredditi
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
	DECLARE @stopcontract datetime
	SELECT 	@start = MIN(start) FROM #contratti	
	SELECT 	@stop  = MAX(stop)  FROM #contratti	
	SELECT 	@stopcontract  = MAX(stopcontract)  FROM #contratti	
	-- Effettuato cedolino riepilogativo in assenza di conguaglio
	DECLARE @summarybalance char(1) 
	IF (SELECT COUNT(*) FROM #contratti 
		 WHERE ISNULL(flagsummarybalance,'N') = 'S') > 0
	BEGIN
		SET @summarybalance = 'S'
	END
	ELSE
	BEGIN
		SET @summarybalance = 'N'
	END 
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
		UPDATE #contratti 		SET capofila = 'S'	WHERE #contratti.padre IS NULL
	END
	ELSE
	BEGIN
		UPDATE #contratti		SET capofila = 'S'	WHERE #contratti.padre IS NULL 
	END
	
	--SELECT * FROM #contratti

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
					         
	DECLARE @bonus_fiscale DECIMAL(19,2)
	
	SELECT  @bonus_fiscale = - SUM(cr.employtaxgross)	
	FROM	#contratti	 			 
	JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
	JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
	JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	AND geoappliance IS NULL
	WHERE #contratti.padre IS NULL AND tax.taxref = '14_BONUS_FISCALE' 
	AND ISNULL(#contratti.flagbonusappliance,'S') = 'S'
	
	-- Al primo calcolo parziale, si somma anche la ritenuta IRPEF applicata nei CUD   associati ai contratti
	SET @bonus_fiscale =
	@bonus_fiscale +
	ISNULL(
		(SELECT SUM(exhibitedcud.fiscalbonusapplied)
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi
			--AND exhibitedcud.idlinkedcon IS NULL
			)
		--and not exists (SELECT * from license where ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy)
		,0)
		
	 			         							         
	SET @taxablegross    = isnull(@taxablegross,0)
	SET @employtaxgross  = isnull(@employtaxgross,0)
	SET @bonus_fiscale   = isnull(@bonus_fiscale,0)
	
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
		
	-- Al primo calcolo parziale, si somma anche IL B0NUS IRPEF applicat0
	SET @ritenuta_irpef = @ritenuta_irpef + ISNULL(@bonus_fiscale,0)
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
		DECLARE @ritenuta_addcom_irpef_acconto_2017 DECIMAL(19,2)
		SET @ritenuta_addcom_irpef_acconto_2017 =
		ISNULL(
			(SELECT SUM(employtax)
			FROM #cedolini
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode=tax.taxcode
			WHERE tax.taxref = '07_ACC_ADDCOM' and expensetaxofficial.stop is null)
		,0) -- 07_ACC_ADDCOM


		-- Al primo calcolo parziale, si somma anche l'acconto all'addizionale comunale applicata nei CUD
		-- cartacei associati ai contratti
		SET @ritenuta_addcom_irpef_acconto_2017 =
		@ritenuta_addcom_irpef_acconto_2017 +
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
		DECLARE @ritenuta_addcom_irpef_saldo_2017 DECIMAL(19,2)
		SET @ritenuta_addcom_irpef_saldo_2017 =
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
	SET @ritenuta_addcom_irpef_saldo_2017 =
	@ritenuta_addcom_irpef_saldo_2017 +
	ISNULL(
		(SELECT SUM(exhibitedcud.citytaxapplied)
		FROM exhibitedcud
		JOIN #contratti
			ON #contratti.idcon = exhibitedcud.idcon
		WHERE fiscalyear = @annoredditi
			AND exhibitedcud.idlinkedcon IS NULL)
	,0)

	-- Il saldo dell'addizionale comunale è pari alla differenza tra addizionale comunale e acconto alla stessa
	SELECT @ritenuta_addcom_irpef_saldo_2017  = @ritenuta_addcom_irpef_saldo_2017 - @ritenuta_addcom_irpef_acconto_2017   

	-- Se il saldo è negativo si valorizza il solo campo inerente all'acconto impostando a NULL il campo del saldo
	-- altrimenti si valorizza il campo del saldo impostando a NULL il campo dell'acconto
	if @ritenuta_addcom_irpef_saldo_2017 < 0
	begin
		set @ritenuta_addcom_irpef_acconto_2017 = @ritenuta_addcom_irpef_acconto_2017 + @ritenuta_addcom_irpef_saldo_2017
		set @ritenuta_addcom_irpef_saldo_2017 = null
	end
	else
	begin
		if @ritenuta_addcom_irpef_acconto_2017 < 0
		begin
			set @ritenuta_addcom_irpef_saldo_2017 = @ritenuta_addcom_irpef_saldo_2017 + @ritenuta_addcom_irpef_acconto_2017
			set @ritenuta_addcom_irpef_acconto_2017 = null
		end
	end
			 
	-------------------------------------------------------------------------- CAF ---------------------------------------------------------------------------
	-- 07_IRPEF_CAF: da trattenere - da rimborsare
DECLARE	@daTrattenere07_IRPEF_CAF decimal(19,2) -- cafdocument.irpeftoretain
DECLARE @Trattenuto07_IRPEF_CAF decimal(19,2) -- da calcolare DB001061
DECLARE @nonTrattenuto07_IRPEF_CAF decimal(19,2)-- da calcolare DB001063
DECLARE @daRimborsare07_IRPEF_CAF decimal(19,2)  ---cafdocument.irpeftorefund
DECLARE @Rimborsato07_IRPEF_CAF  decimal(19,2)  --da calcolare DB001062
DECLARE @nonRimborsato07_IRPEF_CAF  decimal(19,2) --da calcolare DB001064
-- Sarà valorizato o il campo da trattenere o il campo da rimborsare.
set @Trattenuto07_IRPEF_CAF = 0
set @nonTrattenuto07_IRPEF_CAF = 0
SET @daTrattenere07_IRPEF_CAF = ISNULL(( SELECT SUM(C.irpeftoretain) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)

if (@daTrattenere07_IRPEF_CAF > 0)
	begin
		SET @Trattenuto07_IRPEF_CAF =
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
			WHERE tax.taxref= '07_IRPEF_CAF' and expensetaxofficial.stop is null),0)
		SET @nonTrattenuto07_IRPEF_CAF = @daTrattenere07_IRPEF_CAF - @Trattenuto07_IRPEF_CAF
	End
SET @Rimborsato07_IRPEF_CAF = 0
SET @nonRimborsato07_IRPEF_CAF = 0
SET @daRimborsare07_IRPEF_CAF =  ISNULL(( SELECT SUM(C.irpeftorefund) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)

	if (@daRimborsare07_IRPEF_CAF > 0)
	Begin
		set @Rimborsato07_IRPEF_CAF =
		ISNULL(
			(SELECT - SUM(expensetaxofficial.employtax) --> metto il meno perchè è un rimborso, quindi la ritenuta è negativa
			FROM #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode = tax.taxcode
			WHERE tax.taxref= '07_IRPEF_CAF' and expensetaxofficial.stop is null),0)
		SET @nonRimborsato07_IRPEF_CAF = @daRimborsare07_IRPEF_CAF - @Rimborsato07_IRPEF_CAF
		

	End
	-- qui
	
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '061', @Trattenuto07_IRPEF_CAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '062', @Rimborsato07_IRPEF_CAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '063', @nonTrattenuto07_IRPEF_CAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '064', @nonRimborsato07_IRPEF_CAF)

-- 07_ADDREGCAF: regionaltaxtoretain + regionaltaxtoretainhusband - regionaltaxtorefund - regionaltaxtorefundhusband
DECLARE	@daTrattenere07_ADDREGCAF decimal(19,2)		--	cafdocument.regionaltaxtoretain
DECLARE	@Trattenuta07_ADDREGCAF decimal(19,2)		--	da calcolare DB001071
DECLARE	@nonTrattenuta07_ADDREGCAF decimal(19,2)	--	da calcolare DB001073
DECLARE	@daRimborsare07_ADDREGCAF decimal(19,2)		--	cafdocument.regionaltaxtorefund
DECLARE	@Rimborsato07_ADDREGCAF  decimal(19,2)		--	da calcolare DB001072
DECLARE	@nonRimborsato07_ADDREGCAF  decimal(19,2)	--	da calcolare DB001074
DECLARE	@CodRegione07_ADDREGCAF int					-- DB001075 select idfiscaltaxregion, * from cafdocumentview

-- 07_ADDREGCAF (coniuge)
DECLARE	@daTrattenere07_ADDREGCAF_coniuge decimal(19,2) --	cafdocument.regionaltaxtoretainhusband
DECLARE	@Trattenuta07_ADDREGCAF_coniuge decimal(19,2)	--	da calcolare DB001271
DECLARE	@nonTrattenuta07_ADDREGCAF_coniuge decimal(19,2)--	da calcolare DB001273
DECLARE	@daRimborsare07_ADDREGCAF_coniuge decimal(19,2) --	cafdocument.regionaltaxtorefundhusband
DECLARE	@Rimborsato07_ADDREGCAF_coniuge  decimal(19,2)  --	da calcolare DB001272
DECLARE	@nonRimborsato07_ADDREGCAF_coniuge decimal(19,2) --	da calcolare DB001274
DECLARE	@CodRegione07_ADDREGCAF_coniuge int				-- DB001275 select idfiscaltaxregion, * from cafdocumentview

SET @Trattenuta07_ADDREGCAF = 0
SET @nonTrattenuta07_ADDREGCAF = 0
set @Trattenuta07_ADDREGCAF_coniuge =0
set @nonTrattenuta07_ADDREGCAF_coniuge  =0

SET @daTrattenere07_ADDREGCAF =			ISNULL(( SELECT SUM(C.regionaltaxtoretain) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
SET @daTrattenere07_ADDREGCAF_coniuge = ISNULL(( SELECT SUM(C.regionaltaxtoretainhusband) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi ),0)
SET @CodRegione07_ADDREGCAF =			(SELECT TOP 1 C.idfiscaltaxregion FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi )
SET @CodRegione07_ADDREGCAF_coniuge =   (SELECT TOP 1 C.idfiscaltaxregion FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi)
SET @daRimborsare07_ADDREGCAF =			ISNULL(( SELECT SUM(C.regionaltaxtorefund) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
SET @daRimborsare07_ADDREGCAF_coniuge = ISNULL(( SELECT SUM(C.regionaltaxtorefundhusband) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)

if (@daTrattenere07_ADDREGCAF + @daTrattenere07_ADDREGCAF_coniuge>0)
Begin
	set @Trattenuta07_ADDREGCAF =
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
			WHERE tax.taxref= '07_ADDREGCAF' and expensetaxofficial.stop is null),0)

	if (@Trattenuta07_ADDREGCAF = @daTrattenere07_ADDREGCAF + @daTrattenere07_ADDREGCAF_coniuge)-- Ho trattenuto tutto quello che dovevo
	Begin
		set @Trattenuta07_ADDREGCAF = @daTrattenere07_ADDREGCAF
		set @Trattenuta07_ADDREGCAF_coniuge = @daTrattenere07_ADDREGCAF_coniuge
	End
	Else
	begin
		if(@Trattenuta07_ADDREGCAF >= @daTrattenere07_ADDREGCAF)-- se ho trattenuto più del "da trattenere" del dichiarante, vuol dire che un pezzettino è del coniuge
		begin
			set @Trattenuta07_ADDREGCAF_coniuge = @Trattenuta07_ADDREGCAF - @daTrattenere07_ADDREGCAF 
			set @nonTrattenuta07_ADDREGCAF_coniuge = @daTrattenere07_ADDREGCAF_coniuge - @Trattenuta07_ADDREGCAF_coniuge
			set @Trattenuta07_ADDREGCAF = @daTrattenere07_ADDREGCAF
			set @nonTrattenuta07_ADDREGCAF = 0
		End
		if(@Trattenuta07_ADDREGCAF < @daTrattenere07_ADDREGCAF)-- ho trattenuto meno del dovuto
		Begin
			set @nonTrattenuta07_ADDREGCAF = @daTrattenere07_ADDREGCAF - @Trattenuta07_ADDREGCAF
			set @Trattenuta07_ADDREGCAF_coniuge = 0
			set @nonTrattenuta07_ADDREGCAF_coniuge = @daTrattenere07_ADDREGCAF_coniuge
		End
	end
End -- if (@daTrattenere07_ADDREGCAF + @daTrattenere07_ADDREGCAF_coniuge>0)

if (@daRimborsare07_ADDREGCAF + @daRimborsare07_ADDREGCAF_coniuge>0)
Begin
	set @Rimborsato07_ADDREGCAF =
		ISNULL(
			(SELECT -SUM(expensetaxofficial.employtax) --> metto il meno perchè è un rimborso, quindi la ritenuta è negativa
			FROM #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode = tax.taxcode
			WHERE tax.taxref= '07_ADDREGCAF' and expensetaxofficial.stop is null),0)

	if (@Rimborsato07_ADDREGCAF = @daRimborsare07_ADDREGCAF + @daRimborsare07_ADDREGCAF_coniuge)-- Ho rimborsato tutto quello che dovevo
	Begin
		set @Rimborsato07_ADDREGCAF = @daRimborsare07_ADDREGCAF
		set @Rimborsato07_ADDREGCAF_coniuge = @daRimborsare07_ADDREGCAF_coniuge
	End
	Else
	begin
		if(@Rimborsato07_ADDREGCAF >= @daRimborsare07_ADDREGCAF)-- se ho rimborsato più del "da Rimborsare" del dichiarante, vuol dire che un pezzettino è del coniuge
		begin
			set @Rimborsato07_ADDREGCAF_coniuge = @Rimborsato07_ADDREGCAF - @daRimborsare07_ADDREGCAF 
			set @nonRimborsato07_ADDREGCAF_coniuge = @daRimborsare07_ADDREGCAF_coniuge - @Rimborsato07_ADDREGCAF_coniuge
			set @Rimborsato07_ADDREGCAF = @daRimborsare07_ADDREGCAF
			set @nonRimborsato07_ADDREGCAF = 0
		End
		if(@Rimborsato07_ADDREGCAF < @daRimborsare07_ADDREGCAF)-- ho rimborsato meno del dovuto
		Begin
			set @nonRimborsato07_ADDREGCAF = @daRimborsare07_ADDREGCAF - @Rimborsato07_ADDREGCAF
			set @Rimborsato07_ADDREGCAF_coniuge = 0
			set @nonRimborsato07_ADDREGCAF_coniuge = @daRimborsare07_ADDREGCAF_coniuge
		End
	end
End -- if (@daRimborsare07_ADDREGCAF + @daRimborsare07_ADDREGCAF_coniuge>0)

INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '071', @Trattenuta07_ADDREGCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '072', @Rimborsato07_ADDREGCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '073', @nonTrattenuta07_ADDREGCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '074', @nonRimborsato07_ADDREGCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '075', @CodRegione07_ADDREGCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '271', @Trattenuta07_ADDREGCAF_coniuge)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '272', @Rimborsato07_ADDREGCAF_coniuge)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '273', @nonTrattenuta07_ADDREGCAF_coniuge)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '274', @nonRimborsato07_ADDREGCAF_coniuge)
if( @Trattenuta07_ADDREGCAF_coniuge <>0 or @Rimborsato07_ADDREGCAF_coniuge<>0 or @nonTrattenuta07_ADDREGCAF_coniuge<>0 or @nonRimborsato07_ADDREGCAF_coniuge<>0)
Begin
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero) VALUES(@progrCom,1,  'DB001', 1, '275', @CodRegione07_ADDREGCAF_coniuge)
End

-- 07_ADDCOMCAF : citytaxtoretain + citytaxtoretainhusband -  citytaxtorefund - citytaxtorefundhusband
DECLARE @daTrattenere07_ADDCOMCAF decimal(19,2)		--	cafdocument.citytaxtoretain
DECLARE @Trattenuta07_ADDCOMCAF decimal(19,2)		--	da calcolare DB001081
DECLARE @nonTrattenuta07_ADDCOMCAF decimal(19,2)	--	da calcolare DB001082
DECLARE @daRimborsare07_ADDCOMCAF decimal(19,2)		--	cafdocument.citytaxtorefund
DECLARE @Rimborsato07_ADDCOMCAF  decimal(19,2) 		--	da calcolare DB001083
DECLARE @nonRimborsato07_ADDCOMCAF  decimal(19,2) 	--	da calcolare DB001084
DECLARE @CodComune07_ADDCOMCAF varchar(20)					-- DB001085 select citycode, * from cafdocumentview (da verificare)
-- 07_ADDCOMCAF(coniuge)
DECLARE @daTrattenere07_ADDCOMCAF_coniuge decimal(19,2) --	cafdocument.citytaxtoretainhusband
DECLARE @Trattenuta07_ADDCOMCAF_coniuge decimal(19,2)	--	da calcolare DB001281
DECLARE @nonTrattenuta07_ADDCOMCAF_coniuge decimal(19,2)	--	da calcolare DB001282
DECLARE @daRimborsare07_ADDCOMCAF_coniuge decimal(19,2) ---	cafdocument.citytaxtorefundhusband
DECLARE @Rimborsato07_ADDCOMCAF_coniuge  decimal(19,2)  --	da calcolare DB001283
DECLARE @nonRimborsato07_ADDCOMCAF_coniuge  decimal(19,2)  --	da calcolare DB001284
DECLARE @CodComune07_ADDCOMCAF_coniuge varchar(20)    -- DB001085 select citycode, * from cafdocumentview (da verificare)
DECLARE @acconto_addcomunale_irpef_dichiarante  decimal(19,2)
DECLARE @acconto_addcomunale_irpef_coniuge  decimal(19,2)

DECLARE @DB001124 decimal(19,2)
DECLARE @DB001125 varchar(4)
DECLARE @DB001324 decimal(19,2)
DECLARE @DB001325 varchar(4)

SET @Trattenuta07_ADDCOMCAF = 0
SET @nonTrattenuta07_ADDCOMCAF = 0
set @Trattenuta07_ADDCOMCAF_coniuge =0
set @nonTrattenuta07_ADDCOMCAF_coniuge  =0

SET @daTrattenere07_ADDCOMCAF =			ISNULL(( SELECT SUM(C.citytaxtoretain) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
SET @daTrattenere07_ADDCOMCAF_coniuge = ISNULL(( SELECT SUM(C.citytaxtoretainhusband) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
SET @CodComune07_ADDCOMCAF =			( SELECT TOP 1 C.citycode FROM #contratti JOIN cafdocumentview C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi)
SET @CodComune07_ADDCOMCAF_coniuge =   ( SELECT TOP 1 C.citycode FROM #contratti JOIN cafdocumentview C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi)
SET @daRimborsare07_ADDCOMCAF =			ISNULL(( SELECT SUM(C.citytaxtorefund) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
SET @daRimborsare07_ADDCOMCAF_coniuge = ISNULL(( SELECT SUM(C.citytaxtorefundhusband) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi ),0)
SET @acconto_addcomunale_irpef_dichiarante = ISNULL(( SELECT SUM(C.citytaxaccount) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
SET @acconto_addcomunale_irpef_coniuge = ISNULL(( SELECT SUM(C.citytaxaccounthusband) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)



if (@daTrattenere07_ADDCOMCAF + @daTrattenere07_ADDCOMCAF_coniuge>0)
Begin
	set @Trattenuta07_ADDCOMCAF =
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
			WHERE tax.taxref= '07_ADDCOMCAF' and expensetaxofficial.stop is null),0)

	if (@Trattenuta07_ADDCOMCAF = @daTrattenere07_ADDCOMCAF + @daTrattenere07_ADDCOMCAF_coniuge)-- Ho trattenuto tutto quello che dovevo
	Begin

		set @Trattenuta07_ADDCOMCAF = @daTrattenere07_ADDCOMCAF
		set @Trattenuta07_ADDCOMCAF_coniuge = @daTrattenere07_ADDCOMCAF_coniuge
	End
	Else
	begin
		if(@Trattenuta07_ADDCOMCAF >= @daTrattenere07_ADDCOMCAF)-- se ho trattenuto più del "da trattenere" del dichiarante, vuol dire che un pezzettino è del coniuge
		begin
			set @Trattenuta07_ADDCOMCAF_coniuge = @Trattenuta07_ADDCOMCAF - @daTrattenere07_ADDCOMCAF 
			set @nonTrattenuta07_ADDCOMCAF_coniuge = @daTrattenere07_ADDCOMCAF_coniuge - @Trattenuta07_ADDCOMCAF_coniuge
			set @Trattenuta07_ADDCOMCAF = @daTrattenere07_ADDCOMCAF
			set @nonTrattenuta07_ADDCOMCAF = 0
		End
		if(@Trattenuta07_ADDCOMCAF < @daTrattenere07_ADDCOMCAF)-- ho trattenuto meno del dovuto
		Begin
			set @nonTrattenuta07_ADDCOMCAF = @daTrattenere07_ADDCOMCAF - @Trattenuta07_ADDCOMCAF
			set @Trattenuta07_ADDCOMCAF_coniuge = 0
			set @nonTrattenuta07_ADDCOMCAF_coniuge = @daTrattenere07_ADDCOMCAF_coniuge
		End
	end
End -- if (@daTrattenere07_ADDCOMCAF + @daTrattenere07_ADDCOMCAF_coniuge>0)

if (@daRimborsare07_ADDCOMCAF + @daRimborsare07_ADDCOMCAF_coniuge>0)
Begin
	set @Rimborsato07_ADDCOMCAF =
		ISNULL(
			(SELECT - SUM(expensetaxofficial.employtax) --> metto il meno perchè è un rimborso, quindi la ritenuta è negativa
			FROM #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode = tax.taxcode
			WHERE tax.taxref= '07_ADDCOMCAF' and expensetaxofficial.stop is null),0)

	if (@Rimborsato07_ADDCOMCAF = @daRimborsare07_ADDCOMCAF + @daRimborsare07_ADDCOMCAF_coniuge)-- Ho rimborsato tutto quello che dovevo
	Begin
		set @Rimborsato07_ADDCOMCAF = @daRimborsare07_ADDCOMCAF
		set @Rimborsato07_ADDCOMCAF_coniuge = @daRimborsare07_ADDCOMCAF_coniuge
	End
	Else
	begin
		if(@Rimborsato07_ADDCOMCAF >= @daRimborsare07_ADDCOMCAF)-- se ho rimborsato più del "da Rimborsare" del dichiarante, vuol dire che un pezzettino è del coniuge
		begin
			set @Rimborsato07_ADDCOMCAF_coniuge = @Rimborsato07_ADDCOMCAF - @daRimborsare07_ADDCOMCAF 
			set @nonRimborsato07_ADDCOMCAF_coniuge = @daRimborsare07_ADDCOMCAF_coniuge - @Rimborsato07_ADDCOMCAF_coniuge
			set @Rimborsato07_ADDCOMCAF = @daRimborsare07_ADDCOMCAF
			set @nonRimborsato07_ADDCOMCAF = 0
		End
		if(@Rimborsato07_ADDCOMCAF < @daRimborsare07_ADDCOMCAF)-- ho rimborsato meno del dovuto
		Begin
			set @nonRimborsato07_ADDCOMCAF = @daRimborsare07_ADDCOMCAF - @Rimborsato07_ADDCOMCAF
			set @Rimborsato07_ADDCOMCAF_coniuge = 0
			set @nonRimborsato07_ADDCOMCAF_coniuge = @daRimborsare07_ADDCOMCAF_coniuge
		End
	end
End -- if (@daRimborsare07_ADDCOMCAF

INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '081', @Trattenuta07_ADDCOMCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '082', @Rimborsato07_ADDCOMCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '083', @nonTrattenuta07_ADDCOMCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '084', @nonRimborsato07_ADDCOMCAF)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)  VALUES(@progrCom,1,   'DB001',1, '085', @CodComune07_ADDCOMCAF)

INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '281', @Trattenuta07_ADDCOMCAF_coniuge)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '282', @Rimborsato07_ADDCOMCAF_coniuge)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '283', @nonTrattenuta07_ADDCOMCAF_coniuge)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '284', @nonRimborsato07_ADDCOMCAF_coniuge)
if (@Trattenuta07_ADDCOMCAF_coniuge<>0 or @nonTrattenuta07_ADDCOMCAF_coniuge<>0 or @Rimborsato07_ADDCOMCAF_coniuge<>0 or @nonRimborsato07_ADDCOMCAF_coniuge<>0)
Begin
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom,1,  'DB001', 1, '285', @CodComune07_ADDCOMCAF_coniuge)
End
-- 07_TASSASEP : separatedincome + separatedincomehusband
DECLARE @daTrattenere07_TASSASEP decimal(19,2) -- acconto del 20% su redditi a tassazione separata: cafdocument.separatedincome
DECLARE @Trattenuto07_TASSASEP decimal(19,2)	-- da calcolare DB001111
DECLARE @nonTrattenuto07_TASSASEP decimal(19,2) -- da calcolare DB001112
SET @daTrattenere07_TASSASEP =  ISNULL(( SELECT SUM(isnull(C.separatedincome,0) + isnull(C.separatedincomehusband,0)) FROM #contratti JOIN cafdocument C ON #contratti.idcon = C.idcon WHERE C.ayear = @annoredditi),0)
set @Trattenuto07_TASSASEP =
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
			WHERE tax.taxref= '07_TASSASEP' and expensetaxofficial.stop is null),0)
set @nonTrattenuto07_TASSASEP = @daTrattenere07_TASSASEP - @Trattenuto07_TASSASEP

INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '111', @Trattenuto07_TASSASEP)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '112', @nonTrattenuto07_TASSASEP)


DECLARE @Acconto07_IRPEF_R1 decimal(19,2) -- DB001121 Prima Rata Acconto IRPEF : cafdocument.firstrateadvance. No, va preso quello effettivo
DECLARE @Acconto07_IRPEF_R2 decimal(19,2) -- DB001122 Seconda Rata Acconto IRPEF : cafdocument.secondrateadvance. No, va preso quello effettivo
set @Acconto07_IRPEF_R1 =
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
			WHERE tax.taxref= '07_IRPEF_R1' and expensetaxofficial.stop is null),0)
set @Acconto07_IRPEF_R2 =
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
			WHERE tax.taxref= '07_IRPEF_R2' and expensetaxofficial.stop is null),0)

SET  @DB001124 = @acconto_addcomunale_irpef_dichiarante
SET  @DB001125 = @CodComune07_ADDCOMCAF  
SET  @DB001324 = @acconto_addcomunale_irpef_coniuge
SET  @DB001325 = @CodComune07_ADDCOMCAF_coniuge 

INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '121', @Acconto07_IRPEF_R1)
INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '122', @Acconto07_IRPEF_R2)

IF (ISNULL(@DB001124,0))<> 0 
BEGIN
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '124', @DB001124)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)  VALUES(@progrCom,1,  'DB001', 1, '125', @DB001125)
END 
IF (ISNULL(@DB001324,0))<> 0 
BEGIN
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '324', @DB001324)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)  VALUES(@progrCom,1,  'DB001', 1, '325', @DB001325)
END 
------------------------------------------------------------------------------------------------------ FINE CAF ---------------------------------------------------------------------------------------------------
	
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
	CREATE TABLE #ser (idser int, servicecode770 varchar(20), description varchar(200), annotation varchar(400), exemptioncode int)
	
	-- Inserimento delle prestazioni associate ai contratti che non sono divenuti CUD per altri
	INSERT INTO #ser (idser, servicecode770, description, annotation, exemptioncode)
	SELECT DISTINCT #contratti.idser, ISNULL(service.servicecode770,service.codeser),servprincipale.description,
			motive770service.annotation, motive770service.exemptioncode
	FROM service
	JOIN #contratti ON service.idser = #contratti.idser
	JOIN  service servprincipale ON service.servicecode770 = servprincipale.codeser
	LEFT OUTER JOIN motive770service  ON servprincipale.idser = motive770service.idser
									  AND motive770service.ayear = @annoredditi
	
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
	
	DECLARE @EsisteAlmenoUnaPrestazioneTotalmenteEsente char(1) 
	SET @EsisteAlmenoUnaPrestazioneTotalmenteEsente = 
	CASE
		WHEN
		ISNULL((SELECT COUNT(*)
		FROM #ser
		WHERE not EXISTS
		( SELECT *  
			FROM servicetaxview 
		   WHERE servicetaxview.idser = #ser.idser
			 AND servicetaxview.taxkind in(1,3)))
		,0) <> 0
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
	WHERE 	#ser.servicecode770 = '14_DIPENDPUBBLICI'
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
	DECLARE @ritenuta_fondocredito_dipendentipubblici_dip	decimal(19,2)
	
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
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
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
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  tax.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/92' ))
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
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  tax.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/92' ))
	),0)	
	
	SET @ritenuta_previdenziale_dipendentipubblici = @ritenuta_previdenziale_dipendentipubblici_dip + @ritenuta_previdenziale_dipendentipubblici_amm

	
	SELECT  @taxablegross_fondocredito_dipendentipubblici =  SUM (cr.taxablegross)
	FROM	#contratti	 			 
			JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
			JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
			JOIN tax ON cr.taxcode = tax.taxcode  AND taxkind = 3	AND tax.taxref = '07_FDOCRE' 
			WHERE EXISTS (SELECT * FROM servicetaxview
						       WHERE servicetaxview.idser = #contratti.idser
									 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI')	
	
	
	--	Calcolo della ritenute PREVIDENZIALI CON CODICE FONDO CREDITO
	-- Si considera la somma delle ritenute   previdenziali nazionali con codice uguale
	-- a '07_FDOCRE'
	SET @ritenuta_fondocredito_dipendentipubblici_dip   =
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
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
								         AND servicetaxview.taxref = '07_FDOCRE')
	),0)	

	SET @ritenuta_fondocredito_dipendentipubblici  =   @ritenuta_fondocredito_dipendentipubblici_dip 	
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
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
								         AND servicetaxview.taxref = '07_FDOCRE')
	),0)	
	
	declare @mesiConEmensdipendentipubblici VARCHAR(12)
	declare @emensTuttiIMesidipendentipubblici int
	declare @periodiretributivisoggettodenuncia varchar(12)
	-- Calcolo dei mesi dove non è stato prodotto l'E-Mense
	set @mesiConEmensdipendentipubblici = --todo: eliminare i mesi in cui inps=0
		  case WHEN exists (SELECT * from #cedolini
		  JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 1 and year(datacompetenza)=@annoredditi 
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 2 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S')  THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 3 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 4 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 5 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 6 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 7 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 8 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 9 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=10 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=11 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)=12 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '1' ELSE '0' end

	SET @periodiretributivisoggettodenuncia = REPLACE(REPLACE(@mesiConEmensdipendentipubblici,'0','X'), '1', 'Z')
	
	SET @periodiretributivisoggettodenuncia = REPLACE(REPLACE(@mesiConEmensdipendentipubblici,'X','1'), 'Z', '0')

	SET @emensTuttiIMesidipendentipubblici = 0
	IF (@mesiConEmensdipendentipubblici = REPLICATE('1',12))
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
	WHERE 	#ser.servicecode770 <> '14_DIPENDPUBBLICI'
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
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI')

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
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI')

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
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI')
				
			-- Calcolo della ritenuta assicurativa sia c/dipendente sia c/amministrazione dei cedolini
			-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
			-- alla ritenuta assicurativa
			update #cedolini set inail = (SELECT isnull(sum(employtax+admintax),0) 
				from expensetaxofficial
				join tax on expensetaxofficial.taxcode=tax.taxcode
				join expenselink
					ON expensetaxofficial.idexp = expenselink.idchild
					JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 4 and expensetaxofficial.stop is null
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI')
					
					
		declare @mesiSenzaEmens VARCHAR(12)
		declare @emensTuttiIMesi int
		-- Calcolo dei mesi dove non è stato prodotto l'E-Mense
		set @mesiSenzaEmens = --todo: eliminare i mesi in cui inps=0
			  case WHEN exists (SELECT * from #cedolini
			  JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 1 and year(datacompetenza)=@annoredditi 
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 2 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
				JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 3 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				where month(datacompetenza)= 4 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				where month(datacompetenza)= 5 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)= 6 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
				where month(datacompetenza)= 7 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 8 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 9 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=10 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=11 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
			+ case WHEN exists (SELECT * from #cedolini 
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon 
				where month(datacompetenza)=12 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
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
		DECLARE @idemenscontractkind varchar(2)

		SELECT  @idemenscontractkind = MAX(idemenscontractkind) FROM #contratti
		WHERE  #contratti.servicecode770 <> '14_DIPENDPUBBLICI'

		SELECT	@compensoprev = sum(compensoprev),
				@ritprevdovuta = sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),
				@ritprevtrattenuta = sum(ritprevtrattenuta),
				@ritprevpagata = sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),
				@ritprevamministrazione = sum(ISNULL(inpsamm,0))
		FROM #cedolini JOIN #contratti
		ON #contratti.idcon = #cedolini.idcon
		AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'

		SELECT  @compensoprev = isnull(@compensoprev, 0) + isnull(sum(exhibitedcud.taxablepension),0),
				@ritprevdovuta = isnull(@ritprevdovuta, 0) + isnull(sum(exhibitedcud.inpsowed),0),
				@ritprevtrattenuta = isnull(@ritprevtrattenuta, 0) + isnull(sum(exhibitedcud.inpsretained),0),
				@ritprevpagata = isnull(@ritprevpagata, 0) + isnull(sum(exhibitedcud.inpsowed),0),
				@ritprevamministrazione = isnull(@ritprevamministrazione,0) + ISNULL(sum(inpsowed),0)
		FROM exhibitedcud
		JOIN #contratti on #contratti.idcon = exhibitedcud.idcon
		AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
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
	declare @flagdependent char
	declare @appliancePercentage dec(19,6)
	declare @idcontract int
	-- Definizione del cursore che cicla su tutti i familiari presenti solamente sul contratto CAPOFILA,
	-- i familiari non devono necessariamente risultare a carico e devono avere una applicazione ricadente nel periodo dell'anno
	-- in cui sono maturati i redditi
	declare @cursFamigliare cursor
	set @cursFamigliare = cursor for 
	SELECT
		F.idcon,
		F.idfamily, F.birthdate, F.idaffinity,
		ISNULL(F.startapplication, @1gen19_XXX),
		ISNULL(F.stopapplication, @31dic19_XXX),
		ISNULL(F.starthandicap, @1gen20_XXX),
		ISNULL(F.cf, ''),
		ISNULL(F.appliancepercentage, 1),
		F.flagdependent
	FROM parasubcontractfamily F
	JOIN #contratti
		ON #contratti.idcon = F.idcon
	WHERE ayear = @annoredditi
	AND #contratti.capofila = 'S'
	AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
	AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
	--AND (F.flagdependent is null or F.flagdependent = 'S')  // tolgo la condizione che devono essere a carico
	order by idaffinity, birthdate
	declare @valore_mese int

	open @cursFamigliare
	fetch next from @cursfamigliare into @idcontract,@idfamily, @birthdate, @idaffinity, @startapplication,
	@stopapplication, @starthandicap, @cfFamigliare, @appliancePercentage,@flagdependent 
	-- Ciclo sui familiari
	WHILE (@@fetch_status=0) 
	begin
		

		-- Si contano i figli maggiori dalla tabella #primofiglio
		declare @figlimaggiori int
		SELECT  @figlimaggiori = count(*) from #primofiglio where flagdependent='S'
		set     @figlimaggiori = isnull(@figlimaggiori, 0)

		set @meseinizio = 1
		set @mesefine = 12

		-- Si definiscono i mesi di inizio e fine pari ai mesi delle date di inizio e fine applicazione	
		if year(@startapplication) = @annoredditi
			set @meseinizio = month(@startapplication)

		if year(@stopapplication) = @annoredditi
			set @mesefine = month(@stopapplication)

		set @mese = @meseinizio
		set @valore_mese  = 1
		if (@flagdependent='N') set @valore_mese=0

		-- Si cicla partendo dal mese inizio arrivando al mese di fine
		WHILE @mese <= @mesefine
		begin
			set @detrazionePerConiugeACarico = ''
			if @figlimaggiori = 0 and isnull(@appliancepercentage,1) = 1 and @idaffinity = 'F' 
					and @flagdependent='S'
					and not exists (SELECT * from parasubcontractfamily where idcon = @idcontract and idaffinity='C' AND ayear = @annoredditi) 
			begin
				set @detrazionePerConiugeACarico = 'C'
			end

			declare @diffhand int
			set @diffhand = datediff(m, @starthandicap, dateadd(m, @mese-1, @1gen19_XXX))

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
						numeroMesiACarico = numeroMesiACarico + @valore_mese 
						where idconiuge = @idconiuge
				end ELSE begin
					SELECT @idconiuge = 1 + count(*) from #coniuge

					insert into #coniuge values (
						@idconiuge,
						@cfFamigliare,
						@valore_mese,
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
						numeroMesiACarico  = isnull(numeroMesiACarico,0) + @valore_mese,
						minoreDiTreAnni = isnull(minoreDiTreAnni,0) + 
								case WHEN datediff(m, dateadd(m, @mese-1, @1gen19_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN @valore_mese ELSE 0 end,
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
						@valore_mese,
						case WHEN datediff(m, dateadd(m, @mese-1, @1gen19_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN @valore_mese end,
						case @detrazionePerConiugeACarico WHEN '' THEN isnull(@appliancepercentage,1) end,
						@detrazionePerConiugeACarico,
						@annoredditi,
						@flagdependent)
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
						numeroMesiACarico = isnull(numeroMesiACarico,0) + @valore_mese,
						minoreDiTreAnni   = isnull(minoreDiTreAnni,0) + 
								case WHEN datediff(m, dateadd(m, @mese-1, @1gen19_XXX), 
									dateadd(yy, 3, @birthdate)) >= 0 THEN @valore_mese 
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
						@valore_mese,
						case WHEN datediff(m, dateadd(m, @mese-1, @1gen19_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN @valore_mese end,
						case @detrazionePerConiugeACarico WHEN '' THEN isnull(@appliancepercentage,1) end,
						@detrazionePerConiugeACarico,
						@annoredditi
					)
				end
			end
			set @mese = @mese + 1
		end

		fetch next from  @cursfamigliare into @idcontract,@idfamily, @birthdate, @idaffinity, @startapplication,
		@stopapplication, @starthandicap, @cfFamigliare, @appliancePercentage,@flagdependent
	end
	
	--select * from #coniuge
	--select * from #primofiglio
	--select * from #altrofiglio
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
	
	DECLARE @DB001002 DECIMAL(19,2) -- Redditi di lavoro dipendente e assimilati con contratto a tempo determinato  

	DECLARE	@DB001006 INT			-- Numero di giorni per i quali spettano le detrazioni di lavoro dipendente
 
	DECLARE @DB001008 DATETIME		-- Data inizio Rapporto di Lavoro
	DECLARE @DB001009 DATETIME		-- Data fine Rapporto di Lavoro
	DECLARE @DB001010 INT			-- Casella Barrata "In forza al 31/12"
 	DECLARE @DB001011 INT           -- Periodi Particolari
 	-- IL CAMPO SUCCESSIVO RIENTRA NEL RECORD D (HRD, OVVERO NELLA PARTE POSIZIONALE, TUTTAVIA LO VALORIZZIAMO QUI PERCHE'
 	-- ABBIAMO DATI SUFFICIENTI A DETERMINARLO)
 	DECLARE @HRD001011 INT			-- Flag conferma Singola Certificazione per i controlli di rispondenza CB
	SET @DB001002= isnull(@taxablegross,0) 

	-- Conteggio dei giorni lavorati
	-- select * from #workdays 
	-- select * from #contratti
	IF isnull(@taxablegross,0) <> 0
	BEGIN
		SET @DB001006= @workingdays --GIORNI PER I QUALI SPETTANO LE DETRAZIONI
		SET @DB001008= @start -- Data inizio Rapporto di Lavoro DEVE INCLUDERE ANCHE I CUD INTERNI DELLA STESSA UNIVERSITA' INSERITI NEL CONTRATTO
		SET @DB001009= @stop  -- Data fine Rapporto di Lavoro Non deve essere valorizzato in caso di continuazione del rapporto di lavoro oltre il 31/12/2017 ricavabile dalla data fine del contratto inserito. N.B.: il campo 9 è alternativo al campo 10.
		
		-- "In forza al 31/12"
		IF (@stopcontract > @31dic19)
			BEGIN
			SET @DB001010	= 1  
			END
		ELSE 
			SET @DB001010	= 0
		
		IF (
		    (
			((Year(@start) < @annoredditi) AND (@workingdays < 365)     ) 
			OR
			((Year(@start) < @annoredditi) AND (@workingdays = 365) AND (@stop < @31dic19)  ) 

			OR (Year(@stop) < @annoredditi   ) 
			OR
				(	-- IN FORZA AL 31 12, con data ultimo cedolino dell'anno inferiore 
					(@stopcontract > @31dic19)  AND (@stop < @31dic19) 
				) 
			)	
			)
			AND (@workingdays >0)		
			SET @DB001011 = 4  
		 ELSE 
			BEGIN
				IF   (@workingdays >0) AND	(@workingdays < 365) AND (  (@workingdays <> (datediff(d,@start, @stop) + 1)) )					
					SET @DB001011 = 1 -- PERIODI PARTICOLARI, OVVERO INTERRUZIONI DEL PERIODO DI LAVORO
				ELSE 
					SET @DB001011 = NULL
			END
		-- DICHIARAZIONE DA CONFERMARE: indica anomalie che riguardano il conteggio dei giorni lavorati  @workingdays (@DB001006)
		--- Se data inizio cedolino di conguaglio < anno redditi --> Dichiarazione da confermare
		--- Se lavoratore in forza al 31/12 e, pur non essendovi interruzioni (rappresentato dal flag periodi particolari), il numero dei giorni
		--- lavorati è inferiore al periodo data inizio -- 31/12 --> Dichiarazione da confermare
		--  In caso di periodi particolari non c'è bisogno del flag di conferma della dichiarazione
		IF 
		(
			-- NON CI SONO PERIODI PARTICOLARI, OVVERO INTERRUZIONI DEL PERIODO DI LAVORO. 
			(isnull(@DB001011,0) = 0)	
			AND
		(	(year(@start)<@annoredditi)
			OR
			(	-- IN FORZA AL 31 12
				(@stopcontract > @31dic19)  AND (@stop < @31dic19)	
			) 
			OR
			(
			   (@stopcontract <= @31dic19)  AND (@stop < @stopcontract) 
			)
		) 
		
		)	
		 				 					
		SET @HRD001011 = 1 -- richiede conferma della dichiarazione
		ELSE
		SET @HRD001011 = NULL -- non richiede conferma della dichiarazione
 
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '002', @DB001002)
		-- Redditi dei punti da 1 a 5 al netto dei compensi di campione d'Italia
		--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '772', @DB001002)
		-- PARTICOLARI TIPOLOGIE REDDITUALI 741 e 742
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero) VALUES(@progrCom,1,  'DB001', 1, '741', '2') 
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '742', @DB001002)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '006', @DB001006)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data)	  VALUES(@progrCom,1,  'DB001', 1, '008', @DB001008)
		IF (@stopcontract <= @31dic19)
		BEGIN
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data)     VALUES(@progrCom,1,  'DB001', 1, '009', @DB001009)
		END
		ELSE
		BEGIN
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '010', @DB001010)
		END
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '011', @DB001011)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'HRD', 1, '11', @HRD001011)
	END

 
	--select * from #recordG  
   	--------------------------------------------------------------------------------------------
   	---------------------------------- SEZIONE RITENUTE ----------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001021 DECIMAL(19,2) -- Ritenute IRPEF
	DECLARE @DB001022 DECIMAL(19,2)	-- Addizionale regionale all'Irpef
	DECLARE	@DB001027 DECIMAL(19,2)	-- Addizionale comunale all'Irpef - Saldo 2017
	-- Si intendono i rapporti cessati entro il 31 12 dell'anno redditi
	DECLARE @DB001024 DECIMAL(19,2)	--  DB001024 Addizionale regionale 2017 rapporti cessati
	DECLARE @DB001028 DECIMAL(19,2)	--  DB001028 Addizionale comunale all'Irpef - Rapporti cessati 2017
	
	SET @DB001021= isnull(@ritenuta_irpef,0)
	SET @DB001022= isnull(@ritenuta_addreg_irpef,0)
	SET @DB001027= isnull(@ritenuta_addcom_irpef_saldo_2017,0)
	
	IF ((year(@stopcontract) = @annoredditi) AND (@stopcontract <= @31dic19))
	BEGIN
		SET @DB001024= isnull(@ritenuta_addreg_irpef,0)
		SET @DB001028= isnull(@ritenuta_addcom_irpef_saldo_2017,0)
	END

	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '021', @DB001021)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '022', @DB001022)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '027', @DB001027)
	IF ((year(@stopcontract) = @annoredditi) AND (@stopcontract <= @31dic19))
		BEGIN
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '024', @DB001024)
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '028', @DB001028)
		END
	
	--select * from #recordG  
    	
	--------------------------------------------------------------------------------------------
	----------------------------------- ONERI DETRAIBILI --------------------------------------- 
	--------------------------------------------------------------------------------------------
	----------------------- ANTONIO HA VERIFICATO CHE NON CE NE SONO ---------------------------
	--------------------------------------------------------------------------------------------
	-- Oneri detraibili
	-- Nei punti 341, 343, 345, 347, 349, e 351 va indicato il codice relativo all’onere detraibile, per il quale spetta la detrazione
	-- dall’imposta lorda nella misura del 19%, e del 26%, prelevabile dalle tabelle A e B poste in appendice alle presenti
	-- istruzioni.
	-- Nei punti 342, 344, 346, 348, 350 e 352 va indicato l’importo dell’onere detraibile relativo al codice riportato nei
	-- precedenti punti.
	-- Si precisa che gli importi degli oneri detraibili contenuti in tali punti devono

	--DECLARE @DB001341	INT				-- Codice Onere detraibile - Vale da 1 a 18, da 20 a 33, 35, 36, 37, 41, 42, 99
	--DECLARE @DB001342 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001343 INT				-- Codice Onere detraibile  Vale da 1 a 18, da 20 a 33, 35, 36, 37, 41, 42, 99
	--DECLARE @DB001344 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001345 INT				-- Codice Onere detraibile  Vale da 1 a 18, da 20 a 33, 35, 36, 37, 41, 42, 99
	--DECLARE @DB001346 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001347 INT				-- Codice Onere detraibile  Vale da 1 a 18, da 20 a 33, 35, 36, 37, 41, 42, 99
	--DECLARE @DB001348 DECIMAL (19,2)	-- Importo Onere	
	--DECLARE @DB001349 INT				-- Codice Onere detraibile  Vale da 1 a 18, da 20 a 33, 35, 36, 37, 41, 42, 99 
	--DECLARE @DB001350 DECIMAL (19,2)	-- Importo Onere
	--DECLARE @DB001351 INT				-- Codice Onere detraibile	Vale da 1 a 18, da 20 a 33, 35, 36, 37, 41, 42, 99
	--DECLARE @DB001352 DECIMAL (19,2)	-- Importo Onere 
	
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
	--		--AND #contratti.certificatekind = 'U' 
			
	--	DECLARE @oneridetraibili DECIMAL(19,2)
	--	DECLARE @cod_oneredetraibile varchar(20)
	--	DECLARE @counter_oneri INT
	--	SET @counter_oneri = 1
	--	DECLARE rowcursor INSENSITIVE CURSOR FOR
	--	SELECT  oneridetraibili,cod_oneredetraibile
	--	FROM    #oneridetraibili

	--	FOR READ ONLY
	--	OPEN rowcursor
	--	FETCH NEXT FROM rowcursor
	--	INTO @oneridetraibili, @cod_oneredetraibile
	--	WHILE @@FETCH_STATUS = 0
	--	BEGIN 
	--		 INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	VALUES(@progrCom,1, 'DB001', 1, CONVERT(VARCHAR(3),340 + @counter_oneri), @cod_oneredetraibile)
	--		 INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1, 'DB001', 1, CONVERT(VARCHAR(3),341 + @counter_oneri), isnull(@oneridetraibili,0))
	--		 SET @counter_oneri = @counter_oneri + 1
	--		FETCH NEXT FROM rowcursor
	--		INTO @oneridetraibili, @cod_oneredetraibile
	--	END 
	--	DEALLOCATE rowcursor
	--	END

	--------------------------------------------------------------------------------------------
	-------------------------------- DETRAZIONI E CREDITI --------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001361 DECIMAL (19,2)	-- Imposta Lorda
	DECLARE @DB001362 DECIMAL (19,2)	-- Detrazioni per carichi di famiglia
	DECLARE @DB001363 DECIMAL (19,2)	-- Detrazioni per famiglie numerose
	DECLARE @DB001367 DECIMAL (19,2)	-- Detrazione per lavoro dipendente, pensioni e redditi assimilati
	DECLARE @DB001368 DECIMAL (19,2)	-- Totale Detrazioni per oneri
	DECLARE @DB001373 DECIMAL (19,2)	-- Totale detrazioni
	 
	SET @DB001361= isnull(@employtaxgross,0)
	SET @DB001362= isnull(@detrazioni_familiari_a_carico,0)
	SET @DB001367= isnull(@detrazioni_per_reddito,0)
	SET @DB001368= isnull(@detrazioni_per_oneri,0)
	SET @DB001373= isnull(@totale_detrazioni,0)
	
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '361', @DB001361)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '362', @DB001362)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '367', @DB001367)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '368', @DB001368)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '373', @DB001373)
	--select * from #recordG  
	--------------------------------------------------------------------------------------------
	----------------------------------- SEZIONE BONUS ------------------------------------------
	--------------------------------------------------------------------------------------------
	---------- NB. Questa sezione va compilata solo per redditi imponibili ai fini IRPEF -------
	---  non per assegnisti e prestazioni esenti , dove mettiamo solo dati previdenziali -------
	--------------------------------------------------------------------------------------------
	------------ I CAMPI RELATIVI AD ALTRI SOSTITUTI DI IMPOSTA VANNO OMESSI -------------------
	---------------------- PER QUEST'ANNO IN QUANTO NON VE NE SONO -----------------------------
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001391 INT				-- CREDITO BONUS IRPEF - Codice Bonus Vale 1 o 2
	DECLARE @DB001392 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus erogato
	DECLARE @DB001393 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus non erogato
	DECLARE @DB001394 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus recuperato
	DECLARE @DB001395 INT				-- CREDITO BONUS IRPEF EROGATO DA ALTRI SOGGETTI - Codice Bonus Vale 1 o 2
	DECLARE @DB001396 DECIMAL (19,2)    -- CREDITO BONUS IRPEF EROGATO DA ALTRI SOGGETTI - Bonus
	DECLARE @DB001397 DECIMAL (19,2)    -- CREDITO BONUS IRPEF EROGATO DA ALTRI SOGGETTI - Bonus non erogato	
	DECLARE @DB001399 VARCHAR(16)		-- CREDITO BONUS IRPEF EROGATO DA ALTRI SOGGETTI - Codice Fiscale
	
	IF ISNULL(@taxablegross,0) <> 0   
	BEGIN
		IF ISNULL(@bonus_fiscale,0)  = 0 
		BEGIN
			SET @DB001391= 2 -- non riconosciuto
			SET @DB001392= 0
			SET @DB001393= 0
		END
		ELSE
		BEGIN
			SET @DB001391= 1 --  riconosciuto
			SET @DB001392= @bonus_fiscale
			SET @DB001393= 0
		END
		
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DB001', 1, '391', @DB001391)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '392', @DB001392)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '393', @DB001393)
	END
	--select * from #recordG  
	--------------------------------------------------------------------------------------------
	----------------------------------- ONERI DEDUCIBILI --------------------------------------- 
	--------------------------------------------------------------------------------------------
 	----------------------- ANTONIO HA VERIFICATO CHE NON CE NE SONO ---------------------------
	--------------------------------------------------------------------------------------------
	--DECLARE @DB001431 DECIMAL (19,2)	-- Totale oneri deducibili esclusi dai redditi indicati nei punti 1, 3, 4 e 5
	--DECLARE @DB001432 INT				-- Codice Onere
	--DECLARE @DB001433 DECIMAL (19,2)	-- Importo
	--DECLARE @DB001434 INT				-- Codice Onere
	--DECLARE @DB001435 DECIMAL (19,2)	-- Importo
	--DECLARE @DB001436 INT				-- Codice Onere
	--DECLARE @DB001437 DECIMAL (19,2)	-- Importo
	--DECLARE @DB001438 DECIMAL (19,2)	-- Somme restituite nell''anno		
	--DECLARE @DB001439 DECIMAL (19,2)	-- Residuo anno precendente	
	--DECLARE @DB001440 DECIMAL (19,2)	-- Somme restituite non dedotte dai redditi di cui ai punti 1, 3, 4, 5		
	--DECLARE @DB001441 DECIMAL (19,2)	-- Contributi versati a enti e casse aventi esclusivamente fini assistenziali dedotti	
	--DECLARE @DB001442 DECIMAL (19,2)	-- Contributi versati a enti e casse aventi esclusivamente fini assistenziali non dedotti	
	--DECLARE @DB001443 VARCHAR(16)		-- Codice Fiscale degli enti o casse	
	--DECLARE @DB001444 INT				-- Assicurazioni Sanitarie Casella Barrata
	
	--SET @DB001431= isnull(@deduzioni_art10,0)
 
	
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 , 'DB001', 1, '431', @DB001431)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	VALUES(@progrCom,1 ,  'DB001', 1, '432', @DB001432)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '433', @DB001433)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	VALUES(@progrCom,1 ,  'DB001', 1, '434', @DB001434)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '435', @DB001435)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	VALUES(@progrCom,1 ,  'DB001', 1, '436', @DB001436)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '437', @DB001437)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '438', @DB001438)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '439', @DB001439)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '440', @DB001440)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '441', @DB001441)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom,1 ,  'DB001', 1, '442', @DB001442)
	--INSERT INTO #recordG (progr, modulo,  quadro, riga, colonna, stringa)	VALUES(@progrCom,1 ,  'DB001', 1, '443', @DB001443)
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	VALUES(@progrCom,1 ,  'DB001', 1, '444', @DB001444)
 
	--------------------------------------------------------------------------------------------
	-------------------------------------- ALTRI DATI ------------------------------------------ 
	--------------------------------------------------------------------------------------------
	-- Inseriamo qui alcuni tipi di prestazioni esenti da imposizione fiscale ma non perchè si tratti
	-- di stranieri in convenzione. qui troveremo le prestazioni riservate ad assegnisti
	-- ed altre totalmente esenti. Come reddito di riferimento prendiamo feegross del cedolino
	-- dal momento che non possiamo dare per scontata la presenza di ritenute.
	-- Per quanto riguarda la presenza di prestazioni parzialmente esenti, allora in questo caso
	-- bisogna considerare quelle prestazioni associate a ritenute fiscali applicate a una quota di 
	-- imponibile. A titolo di esempio la  07_IRPEF_L.326/03. Queste ritenute indicano le prestazioni
	-- parzialmente esenti fiscalmente. Con una query ho verificato almeno per il 2014 non sono state
	-- usate. Da completare la query su Cassino	--DECLARE @DB001475 int	-- Applicazione maggiore ritenuta CB
				-- Calcolo deli incassi=rimborsi derivanti da questi compensi. Vedi task 9268

	declare @rimborso decimal(19,2)
	select @rimborso = sum(ROUND(estimatedetail.taxable * estimatedetail.number * 
		     		CONVERT(decimal(19,6),estimate.exchangerate) * 
		     		(1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2))
		FROM estimatedetail 
		JOIN estimate 
  			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
  			AND estimatedetail.nestim = estimate.nestim
		JOIN estimatekind
			ON estimatekind.idestimkind = estimate.idestimkind
		join incomeestimate
			on incomeestimate.idinc = estimatedetail.idinc_taxable
		JOIN incomelink
			ON incomelink.idparent = incomeestimate.idinc
		join incomelast 
			on incomelink.idchild = incomelast.idinc
		join historyproceedsview HPV
			on HPV.idinc = incomelast.idinc
		where  (HPV.idreg = @idreg )
			and estimatedetail.stop is null
			AND year(HPV.competencydate) = @annoredditi 
			and (estimatekind.flag&2)<>0 --C.A. di tipo Rimborso 
	---------------------- Dobbiamo dichiarare l'importo ricevuto al netto di eventuali rimborsi

	declare  @rimborso_residuo decimal(19,2)
	set @rimborso = isnull(@rimborso,0)
	set @rimborso_residuo= @rimborso;

	DECLARE @reddito_esente	 decimal(19,2)
	DECLARE @reddito_esente_codice_3 decimal(19,2)
	DECLARE @counter	int
	DECLARE @servicecode770 VARCHAR(20)
	DECLARE @exemptioncode int
	DECLARE @DB001464 int	-- Redditi Esenti - Codice  -- prevedere una tabella di configurazione delle prestazioni?
	DECLARE @DB001465 decimal(19,2)	-- Redditi Esenti - Ammontare
	set @reddito_esente_codice_3 = 0
	SET @counter = 0
	DECLARE rowcursor_e INSENSITIVE CURSOR FOR
	SELECT  DISTINCT exemptioncode
	FROM    #ser WHERE exemptioncode IS NOT NULL  order by exemptioncode

	---------- SARA --------------------------
	FOR READ ONLY
	OPEN rowcursor_e
	FETCH NEXT FROM rowcursor_e
	INTO	 @exemptioncode 
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		SET @counter  = @counter + 1
		-- Prestazioni degli assegnisti totalmente esenti, no stranieri
		print 'esente '
		print @exemptioncode

			SET @reddito_esente =  ISNULL (
			(SELECT SUM(p.feegross) 	FROM	#contratti	 			 
					JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
					WHERE #contratti.exemptioncode = @exemptioncode
			),0)


		--non funziona se ci sono più redditi esenti
		if (@rimborso_residuo>0) begin
			if( @reddito_esente >= @rimborso_residuo )
				Begin
					set @reddito_esente = @reddito_esente - @rimborso_residuo
					set @rimborso_residuo=0
				End
			else 
				begin 
					set @rimborso_residuo= @rimborso_residuo -@reddito_esente
					set @reddito_esente=0					
				end

		end
 
		SET @DB001464 = @exemptioncode					 
		SET @DB001465 = @reddito_esente					 
		if(@DB001465 <>0)
		Begin
			INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, intero)   VALUES(@progrCom,1,'DB001', @counter, '464', @DB001464)
			INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, decimale) VALUES(@progrCom,1,'DB001', @counter, '465', @DB001465)
		End	
		IF (@exemptioncode = 3) SET @reddito_esente_codice_3 = @reddito_esente --- SERVIRA' PER VALORIZZARE LE ANNOTAZIONI BW
	 
	FETCH NEXT FROM rowcursor_e
	INTO @exemptioncode 
	END 
	DEALLOCATE rowcursor_e
	
	--select * from #recordG
	-- Sebbene possiamo osservare che la maggiore ritenuta sia stata indicata nei compensi
	-- tuttavia molto probabilmente si tratta di casi in cui non c'è stata esplicita richiesta.
	-- Pertanto non lo scriviamo
 
	--SET @DB001475 = (SELECT 
	--CASE
	--	WHEN (SELECT COUNT(*) FROM #contratti WHERE ISNULL(highertax,0) > 0) > 0 THEN '1'
	--	ELSE null
	--END )
	
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DB001', 1, '475', @DB001475)
	
 	--------------------------------------------------------------------------------------------
	-------------- Redditi assoggettati a ritenuta a titolo di imposta ------------------------- 
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001481 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale redditi
	DECLARE @DB001482 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef
	DECLARE @DB001485 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale redditi con causale 2
	DECLARE @DB001487 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef  con causale 2
	DECLARE @DB001483 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef sospese
	
	SET @DB001481= isnull(@taxablegross_irpef_stranieri,0)
	SET @DB001485= isnull(@taxablegross_irpef_stranieri,0)

	SET @DB001482= isnull(@ritenuta_irpef_stranieri,0)
	SET @DB001487= isnull(@ritenuta_irpef_stranieri,0)
	-- SET @@DB001483= 0
	
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '481', @DB001481)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '482', @DB001482)
	IF (isnull(@ritenuta_irpef_stranieri,0) <> 0)
	BEGIN 
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DB001', 1, '484', 2)
	END
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '485', @DB001485)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '487', @DB001487)
	-- INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '483', @DB001483)
	--------------------------------------------------------------------------------------------
	-------- Dati relativi ai conguagli in caso di Redditi erogati da altri soggetti -----------
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001531 DECIMAL(19,2)		-- Totale redditi conguagliati già compresi nel punto 1
	DECLARE @DB001536 VARCHAR(16)	    -- Codice fiscale
	DECLARE @DB001538 DECIMAL(19,2)		-- Reddito conguagliato già compreso nel punto 1
	DECLARE @DB001543 DECIMAL(19,2)	    -- Ritenute
	DECLARE @DB001544 DECIMAL(19,2)		-- Addizionale regionale
	DECLARE @DB001545 DECIMAL(19,2)	    -- Addizionale comunale Acconto 2017
	DECLARE @DB001546 DECIMAL(19,2)	    -- Addizionale comunale Saldo 2017
	
	SET @DB001531= isnull(@totale_redditi_altri_soggetti,0)
		
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom, 1, 'DB001', 1, '531', @DB001531)
	
	DECLARE @cf_altro_sostituto		varchar(16)
	DECLARE @reddito_conguagliato 	decimal(19,2)
	DECLARE @ritenute_irpef			decimal(19,2)
	DECLARE @addizionale_regionale_irpef		 decimal(19,2)
	DECLARE @addizionale_comunale_irpef_acconto  decimal(19,2)
	DECLARE @addizionale_comunale_irpef_saldo    decimal(19,2)
	DECLARE @counter_altro_sostituto	int
	
	SET @counter_altro_sostituto = 0
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
		SET @counter_altro_sostituto  = @counter_altro_sostituto + 1
		SET @DB001536 = @cf_altro_sostituto					 
		SET @DB001538 = @reddito_conguagliato					 
		SET @DB001543 = @ritenute_irpef	 
		SET @DB001544 = @addizionale_regionale_irpef 
		SET @DB001545 =	@addizionale_comunale_irpef_acconto	 
		SET @DB001546 =	@addizionale_comunale_irpef_saldo
	
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)  VALUES(@progrCom,1, 'DB001', @counter, '536', @DB001536)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '538', @DB001538)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '543', @DB001543)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '544', @DB001544)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '545', @DB001545)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', @counter, '546', @DB001546)

	FETCH NEXT FROM rowcursor
	INTO	@cf_altro_sostituto,@reddito_conguagliato,@ritenute_irpef,
			@addizionale_regionale_irpef,@addizionale_comunale_irpef_acconto,
			@addizionale_comunale_irpef_saldo
	END 
	DEALLOCATE rowcursor
	--END
	
 
 
	-------------------------------------------------------------------------------------------------
	---------------------- Dati relativi al coniuge e ai familiari a carico -------------------------
	-------------------------------------------------------------------------------------------------
	
	--DECLARE @DB601001	VARCHAR(20)--Relazione di parentela	CB
	--DECLARE @DB601004	VARCHAR(16)--Codice fiscale	CF
	--DECLARE @DB601005	INT--Mesi a carico	N2
	--DECLARE @DB602001	VARCHAR(20)--Relazione di parentela	AN
	--DECLARE @DB602004	VARCHAR(16)--Codice fiscale	CF
	--DECLARE @DB602005	INT--Mesi a carico	N2
	--DECLARE @DB602006	INT--Minore di tre anni	N2
	--DECLARE @DB602008	CHAR(1)--Detrazione 100% affidamento figli	CB
	--DECLARE @DB602A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	--DECLARE @DB602B07	CHAR(1)--Percentuale di detrazione spettante	AN
	--DECLARE @DB603001	VARCHAR(20)--Relazione di parentela	AN
	--DECLARE @DB603004	VARCHAR(16)--Codice fiscale	CF
	--DECLARE @DB603005	INT--Mesi a carico	N2
	--DECLARE @DB603006	INT--Minore di tre anni	N2
	--DECLARE @DB603008	CHAR(1)--Detrazione 100% affidamento figli	CB
	--DECLARE @DB603A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	 
	-- Si procede all'inserimento dei dati inerenti i familiari all'interno della tabella di output
	-- estraendoli dalle tabelle definite per i familiari a carico
	
	-----------------------------------------------------------
	---------------- LETTURA DATI CONIUGE ---------------------
	-----------------------------------------------------------

	UPDATE #coniuge SET numeroMesiACarico = 12 where isnull(numeroMesiACarico,0) > 12
	UPDATE #altrofiglio SET numeroMesiACarico = 12 where isnull(numeroMesiACarico,0) > 12
	UPDATE #primofiglio SET numeroMesiACarico = 12 where isnull(numeroMesiACarico,0) > 12
 
	UPDATE #altrofiglio SET minoreDiTreAnni = 12 where isnull(minoreDiTreAnni,0) > 12
	UPDATE #primofiglio SET minoreDiTreAnni = 12 where isnull(minoreDiTreAnni,0) > 12

	-- DECLARE @DB601001 VARCHAR(20)--Relazione di parentela	CB
	INSERT INTO #recordg (progr, modulo, quadro, riga, colonna, intero) 
		SELECT @progrCom, 1, 'DB601', idconiuge, '001', 1 FROM #coniuge
		
	-- DECLARE @DB601004 VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 1, 'DB601', idconiuge, '004', 
		codiceFiscaleConiuge FROM #coniuge WHERE  
		codiceFiscaleConiuge <> ''

	-- DECLARE @DB601005	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero) 
	SELECT @progrCom, 1, 'DB601', idconiuge, '005', 
	numeroMesiACarico FROM #coniuge numeroMesiACarico	
	
	-----------------------------------------------------------
	------------- LETTURA DATI PRIMO FIGLIO -------------------
	-----------------------------------------------------------

	--DECLARE @DB602001	VARCHAR(20)--Relazione di parentela	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom,  1,'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '001', 
		CASE  WHEN casellaDisabile   =  1 then 'D' 
		ELSE  'F'
		END 
		FROM #primofiglio

	-- DECLARE @DB602004	VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 1, 'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '004', 
		codiceFiscalePrimoFiglio from #primofiglio 
		where codiceFiscalePrimoFiglio <> ''

	--DECLARE @DB602005	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1,'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '005', 
		numeroMesiACarico  from #primofiglio

	--DECLARE @DB602006	INT--Minore di tre anni	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1,'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1),idprimofiglio, '006', 
		minoreDiTreAnni from #primofiglio

	--DECLARE @DB602A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	INSERT INTO #recordg (progr, modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1, 'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, 'A07', 
		100 * percentualeDiDetrazioneSpettante / numeroMesiACarico 
		from #primofiglio where detrazionePerConiugeACarico <> 'C'
		and numeroMesiACarico  <>0

	--DECLARE @DB602B07	CHAR(1)--Percentuale di detrazione spettante	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 1, 'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, 'B07', detrazionePerConiugeACarico 
		from #primofiglio where detrazionePerConiugeACarico = 'C'
		
	--DECLARE @DB602008	CHAR(1)--Detrazione 100% affidamento figli	CB
		--INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
		--SELECT @progrCom, 'DB60' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '008', 1 
		--from #primofiglio where detrazionePerConiugeACarico = 'C'
	
	-----------------------------------------------------------
	------------- LETTURA DATI ALTRI FIGLI --------------------
	-----------------------------------------------------------	
	-- DECLARE @DB603001	VARCHAR(20)--Relazione di parentela	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom,  1, 'DB60'+ CONVERT(VARCHAR(3),idaltrofiglio+2),1, '001', 
		CASE  WHEN casellaDisabile = 1 then 'D'
			  WHEN casellaFiglio = 1 THEN 'F' 
			  WHEN casellaAltroFamiliare = 1 THEN 'A'
			  else null
		END
		FROM #altrofiglio

	-- DECLARE @DB603004	VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom,  1, 'DB60'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'004', codiceFiscaleFamiliare
		FROM #altrofiglio

	--DECLARE @DB603005	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom,  1, 'DB60'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'005', numeroMesiACarico 
		FROM #altrofiglio

	--DECLARE @DB603006	INT--Minore di tre anni	N2
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero) 
		SELECT @progrCom,  1, 'DB60'+ CONVERT(VARCHAR(3),idaltrofiglio+2),1, '006', minoreDiTreAnni 
		FROM #altrofiglio where minoreDiTreAnni <> ''

	--DECLARE @DB603A07	DECIMAL(19,6)--Percentuale di detrazione spettante	PC si può omettee se c'è la percentuale
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, intero)
		SELECT @progrCom, 1, 'DB60'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'A07',
		100 * percentualeDiDetrazioneSpettante/numeroMesiACarico 
		FROM #altrofiglio where detrazionePerConiugeACarico <> 'C'
		and numeroMesiACarico  <>0
	--DECLARE @DB603B07	CHAR(1)--Percentuale di detrazione spettante	AN
	INSERT INTO #recordg (progr,  modulo, quadro, riga, colonna, stringa)
		SELECT @progrCom, 1, 'DB60'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,'B07', 'C'  
		FROM #altrofiglio where detrazionePerConiugeACarico = 'C'
		
	--DECLARE @DB602008	CHAR(1)--Detrazione 100% affidamento figli	CB
	--INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
	--	SELECT @progrCom, 'DB50' + CONVERT(VARCHAR(3),idaltrofiglio +1), '008', 0 
	--	FROM #altrofiglio where detrazionePerConiugeACarico = 'C'

	----------------------------------------------------------------------------------------------------------------
	----------- Dati previdenziali ed assistenziali  SEZIONE 3 "INPS GESTIONE SEPARATA PARASUBORDINATI" ------------
	----------------------------------------------------------------------------------------------------------------
	--	SEZIONE 3 "INPS GESTIONE SEPARATA PARASUBORDINATI"

	IF
	((SELECT	COUNT(*)
		FROM	#ser
		WHERE 	#ser.servicecode770 <> '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@compensoprev,0) > 0))
	BEGIN
		--DECLARE @DC001001	VARCHAR(10)		-- Matricola azienda N10
		DECLARE @DC001043	DECIMAL (19,2)	-- Compensi corrisposti sul parasubordinatoVP
		DECLARE @DC001044	DECIMAL (19,2)	-- Contributi Dovuti VP
		DECLARE @DC001045	DECIMAL (19,2)	-- Contributi a carico del lavoratore VP
		DECLARE @DC001046	DECIMAL (19,2)	-- Contributi versati VP
		DECLARE @DC001047	INT				-- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DC001048	VARCHAR(12)		-- singoli mesi
		DECLARE @DC001049	VARCHAR(2)		-- Tipo rapporto Emens
		
		--SET @DC001001 = @agencynumber 
		SET @DC001043= isnull(@compensoprev,0)
		SET @DC001044= isnull(@ritprevdovuta,0)
		SET @DC001045= isnull(@ritprevtrattenuta,0)
		SET @DC001046= isnull(@ritprevpagata,0)
		SET @DC001047= isnull(@emensTuttiIMesi,0)
		SET @DC001048= @mesiSenzaEmens
		SET @DC001049= @idemenscontractkind
		--exec exp_certificazioneunica_g_17 21,1
		--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '001', @DC001001)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '043', @DC001043)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '044', @DC001044)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '045', @DC001045)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '046', @DC001046)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '047', @DC001047)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '048', @DC001048)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '049', @DC001049)
	END
	------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------- Sezione 2 - INPS GESTIONE DIPENDENTI PUBBLICI ---------------------------------------
	------------------------------------------------------------------------------------------------------------------------------
	IF
	((SELECT COUNT(*)
		FROM #ser
		WHERE 	#ser.servicecode770 = '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@taxablegross_dipendentipubblici,0) > 0))
	BEGIN

		--DC001	017	2018-01-11 14:43:42.773	assistenza	Anno di riferimento
		--DC001	018	2018-01-11 14:43:42.773	assistenza	Imponibile pensionistico
		--DC001	019	2018-01-11 14:43:42.773	assistenza	Contributi pensionistici dovuti
		--DC001	020	2018-01-11 14:43:42.773	assistenza	Contributi pensionistici a carico lavoratore trattenuti
		--DC001	021	2018-01-11 14:43:42.773	assistenza	Imponibili TFS
		--DC001	022	2018-01-11 14:43:42.773	assistenza	Contributi TFS
		--DC001	023	2018-01-11 14:43:42.773	assistenza	Contributi TFS a carico lavoratore trattenuti
		--DC001	024	2018-01-11 14:43:42.773	assistenza	Imponibile TFR
		--DC001	025	2018-01-11 14:43:42.773	assistenza	Contributi TFR dovuti 
		--DC001	026	2018-01-11 14:43:42.773	assistenza	Imponibile Gestione Credito
		--DC001	027	2018-01-11 14:43:42.773	assistenza	Contributo Gestione Credito dovuti
		--DC001	028	2018-01-11 14:43:42.773	assistenza	Contributo Gestione Credito trattenuti a carico del lavoratore

		--DC001037 Codice fiscale soggetto denuncia CF
		--DC001038 Periodi retributivi soggetto denuncia CB12 prendo dal 36 oppure spuntarli tutti se barrato il 35
		--DC001039 Codice fiscale conguaglio CF
		--DC001040 Imponibile conguaglio V

		DECLARE @DC001009	VARCHAR(16)	    -- Codice fiscale Amministrazione	  
		DECLARE @DC001010	VARCHAR(10)		-- Progressivo azienda
		DECLARE @DC001012	INT				-- Gestione Pensionistica
		DECLARE @DC001014	INT				-- Gestione Credito
		DECLARE @DC001017	INT				-- Anno di riferimento	
		DECLARE @DC001018	DECIMAL (19,2)	-- Imponibile pensionistico	
		DECLARE @DC001019	DECIMAL (19,2)	-- Contributi pensionistici dovuti
		DECLARE @DC001020	DECIMAL (19,2)	-- Contributi pensionistici a carico lavoratore trattenuti
		DECLARE @DC001026	DECIMAL (19,2)	-- Imponibile Gestione Credito
		DECLARE @DC001027	DECIMAL (19,2)	-- Contributo Gestione Credito dovuti
		DECLARE @DC001028	DECIMAL (19,2)	-- Contributo Gestione Credito trattenuti a carico del lavoratore
		DECLARE @DC001035	INT				-- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DC001036	VARCHAR(12)		-- Mesi per i quasi è stata presentata la denuncia UniEmens - Tutti con esclusione di
		DECLARE @DC001037	VARCHAR(16)	    -- Codice fiscale soggetto denuncia
		DECLARE @DC001038	VARCHAR(12)		-- Periodi retributivi soggetto denuncia CB12, opposto di @mesiConEmensdipendentipubblici
		
		SET @DC001009 =	@codfiscEnte -- Codice fiscale Amministrazione	  
		SET @DC001010 = '00000'   -- Progressivo azienda
		SET @DC001012 = 1		  -- Gestione Pensionistica
		SET @DC001014 = 9         -- Gestione Credito
		SET @DC001017 = @annoredditi   -- Anno di riferimento	
		SET @DC001018 = @taxablegross_dipendentipubblici			  -- Imponibile pensionistico		
		SET @DC001019 = @ritenuta_previdenziale_dipendentipubblici	  -- Contributi pensionistici dovuti
		SET @DC001020 = @ritenuta_previdenziale_dipendentipubblici_dip	  -- Contributi pensionistici a carico lavoratore trattenuti
		SET @DC001026 = @taxablegross_fondocredito_dipendentipubblici -- Totale imponibile Gestione Credito
		SET @DC001027 = @ritenuta_fondocredito_dipendentipubblici     -- Contributo Gestione Credito dovuti
		SET @DC001028 = @ritenuta_fondocredito_dipendentipubblici_dip -- Contributo Gestione Credito trattenuti a carico del lavoratore (fondo credito carico dipendente)
		SET @DC001035 = isnull(@emensTuttiIMesidipendentipubblici,0)  -- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		SET @DC001036 = @mesiConEmensdipendentipubblici			  -- Mesi per i quasi è stata presentata la denuncia UniEmens - non è più quelli esclusi, ma i mesi inclusi
		SET @DC001037 =	@codfiscEnte --  Codice fiscale soggetto denuncia
		SET @DC001038 = @periodiretributivisoggettodenuncia
	
 		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '009', @DC001009)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '010', @DC001010)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '012', @DC001012)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '014', @DC001014)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '017', @DC001017)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '018', @DC001018)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '019', @DC001019)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '020', @DC001020)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '026', @DC001026)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '027', @DC001027)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '028', @DC001028)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '035', @DC001035)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '036', @DC001036)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '037', @DC001037)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '038', @DC001038)
	END 
 	---------------------------------------------------------------------------------------------------------------------------
	------------------------------------------------- Dati assicurativi INAIL -------------------------------------------------
	------------------  PER IL PRIMO ANNO SI POTEVA SCEGLIERE DI NON COMPILARLA, MA PER GLI ANNI SUCCESSIVI NO ---------------- 
	---------------------------------------------------------------------------------------------------------------------------
	IF
	((SELECT	COUNT(*)
		FROM	#ser
		WHERE 	#ser.servicecode770 <> '14_DIPENDPUBBLICI')
	) 
	> 0 
	BEGIN 
		DECLARE @patcode varchar(20)
		DECLARE @oldpat  varchar(20)
		DECLARE @startpayroll smalldatetime
		DECLARE @stoppayroll smalldatetime
		DECLARE @oldstop smalldatetime 
		SET @oldstop = null
		DECLARE @DC001071 CHAR(1)		-- Qualifica AN Vale B, C, D, E, F,G, H, L, M, N, P,Q, Z CREARE TABELLA DI CONFIGURAZIONE
		DECLARE @DC001072 VARCHAR(20)	-- Posizione assicurativa territoriale N11
		DECLARE @DC001073 DATETIME		-- Data inizio D4
		DECLARE @DC001074 DATETIME		-- Data fine D4
		DECLARE @DC001075 VARCHAR(10)	-- Codice comune AN .
		DECLARE @DC001076 INT			-- Personale viaggiante CB   NON LO METTIAMO 
		DECLARE @modulopat INT
		SET @modulopat = 0
		-- Cursore sui cedolini per determinare la P.A.T. associata ai contratti e per determinare le date
		-- di inizio e fine rispettivamente minime e massime
		declare @cursorecedolini cursor
		set @cursorecedolini = cursor for
			SELECT pat.patcode, MIN(startpayroll) AS startpayroll, MAX(stoppayroll) AS stoppayroll
			FROM #cedolini
			JOIN parasubcontract
				ON parasubcontract.idcon = #cedolini.idcon
			JOIN pat
				ON pat.idpat = parasubcontract.idpat
			WHERE (inail > 0)
				AND (year(stoppayroll) >= @annoredditi)
			GROUP BY pat.patcode
			UNION ALL
			SELECT null, {d '2079-06-06'}, null
			ORDER BY startpayroll

		open @cursorecedolini
		fetch next from @cursorecedolini into @patcode, @startpayroll, @stoppayroll

		declare @oldstart smalldatetime
		if @startpayroll < @1gen19_XXX set @oldstart = @1gen19_XXX ELSE set @oldstart = @startpayroll
		if @stoppayroll > @31dic19_XXX set @oldstop =  @31dic19_XXX ELSE set @oldstop = @stoppayroll
		-- Inserimento dei dati assicurativi distinti per mese
		WHILE @@fetch_status = 0
		begin
			--Dati assicurativi INAIL
		
			if @startpayroll < @1gen19_XXX set @startpayroll = @1gen19_XXX
			if @stoppayroll > @31dic19_XXX set @stoppayroll = @31dic19_XXX

			if datediff(d, @oldstop, @startpayroll) > 1
			begin
				SET @modulopat = @modulopat+1
				SET @DC001071 = NULL -- Qualifica AN Vale B, C, D, E, F,G, H, L, M, N, P,Q, Z CREARE TABELLA DI CONFIGURAZIONE ASSOCIATA ALL'ANAGRAFICA
				SET @DC001072 = @oldpat	-- Posizione assicurativa territoriale N11
				SET @DC001073 =	@oldstart	-- Data inizio D4
				SET @DC001074 = @oldstop	-- Data fine D4
				SET @DC001075 = @codiceComuneEnte -- Codice comune AN .
				SET @DC001076 = NULL		-- Personale viaggiante CB   NON LO METTIAMO 

				--@DC001071 		-- Qualifica AN Vale B, C, D, E, F,G, H, L, M, N, P,Q, Z CREARE TABELLA DI CONFIGURAZIONE

				-- Ripeto intestazione RECORD G per i moduli successivi al primo
				if (@modulopat) > 1 
				BEGIN
					--1 Tipo record
					INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom, @modulopat, 'HRG', 1, '01', 'G')
					--2 Codice fiscale del sostituto d'imposta
					INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, stringa)  VALUES(@progrCom, @modulopat, 'HRG', 1, '02', @codfiscEnte)
					--3 Progressivo modulo
					INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, intero)   VALUES(@progrCom, @modulopat, 'HRG', 1, '03', @modulopat)
					--4 Codice fiscale del percipiente
					INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, stringa)  VALUES(@progrCom, @modulopat, 'HRG', 1, '04', @au1cf)
					--5 Progressivo certificazione
					INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)  VALUES(@progrCom, @modulopat, 'HRG', 1, '05', @progrCom)
				END

				INSERT INTO #recordG (progr, modulo, quadro, riga, colonna,  intero) VALUES(@progrCom, @modulopat,  'DC001', 1, '071',  @DC001071)
				-- @DC001072 Posizione assicurativa territoriale N11
				if ((@DC001072   is not null) and (@print ='N'))
				Begin
						--  a PAT è un N11, ove Nx : Campo numerico al massimo di x cifre allineate a destra (x assume valori da 1 a 16)
						--	Quindi deve essere di x cifre, allinenata a destra, con gli spazi a sinistra
						--	DC001072      9209713813
					SET @DC001072 =  REPLICATE('0',11 - DATALENGTH(@DC001072)) + @DC001072  
				End
				INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom, @modulopat, 'DC001', @modulopat, '072', @DC001072)
				-- @DC001073 Data inizio D4
				INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data) VALUES(@progrCom, @modulopat, 'DC001', @modulopat, '073', @DC001073)
				-- @DC001074 Data fine D4
				INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data) VALUES(@progrCom, @modulopat, 'DC001', @modulopat, '074', @DC001074)
				-- @DC001075  Codice comune AN  
				INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom, @modulopat, 'DC001', @modulopat, '075', @DC001075)
				--@DC001076  -- Personale viaggiante CB   NON LO METTIAMO 
				INSERT INTO #recordG (progr, modulo, quadro, riga, colonna,  intero) VALUES(@progrCom, @modulopat,  'DC001', @modulopat, '076',  @DC001076)
			
				set @oldstart = @startpayroll

			end
				
			set @oldstop = @stoppayroll
			set @oldpat = @patcode
			fetch next from @cursorecedolini into @patcode, @startpayroll, @stoppayroll
	
		end
		DEALLOCATE @cursorecedolini
 
	END
	
------------------------------------------------------------------------------------------------------------------
------------------------------------ INSERIMENTO DELLE ANNOTAZIONI -----------------------------------------------
------------------------------------------------------------------------------------------------------------------
	--AC – La detrazione per carichi di famiglia è stata calcolata in relazione alla durata del rapporto di lavoro.
	--Nel caso di rapporto di lavoro inferiore all’anno solare, il sostituto calcola la detrazione 
	--per carichi di famiglia in relazione al periodo di lavoro, salvo che il sostituito non abbia richiesto 
	--espressamente di poterne fruire per l’intero periodo di imposta (qualora ne ricorrano i presupposti). 
	--Nel caso in cui le suddette detrazioni siano state determinate in relazione al periodo di lavoro, 
	--il sostituto ne deve dare comunicazione al percipiente nelle annotazioni (cod. AC).
	--------------- NOI LE APPLICHIAMO SEMPRE PER INTERO PERCIO' QUESTE ANNOTAZIONI NON VANNO SCRITTE ----------------- 
	-------------------------------------------------------------------------------------------------------------------

	--AI - Informazioni relative al reddito/i certificato/i: tipologia (…), data inizio e data fine per ciascun periodo di lavoro o pensione (…), importo (… ).
	--Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, rapporto a tempo determinato, data inizio e data fine per ciascun periodo di lavoro dal …. Al ….  importo euro …..
	--(Da valorizzare ogni volta che è valorizzato il campo 1 Redditi di lavoro dipendente e assimilati....)

	--BW Redditi esentati da imposizione in Italia in quanto il percipiente risiede in uno Stato estero: importo del reddito esente percepito (…)
	--in questa confluiscono le vecchie AJ nel caso in cui il codice di esenzione indicato nel campo 468 sia pari a 3.

	--"AL - Le addizionali regionali e comunali sono state interamente trattenute. "
	--(Costante quando i campi relativi alle addizionali comunali e regionali sono stati valorizzati)

	--"AN - La detrazione minima è stata ragguagliata al periodi di lavoro. Il percipiente può fruire della detrazione per l'intero anno in sede di dichiarazione dei redditi, semprechè non sia stata già attribuita da un altro datore di lavoro e risulti effettivamente spettante."
	--(Nel caso di rapporti di lavoro a tempo determinato o a tempo indeterminato di durata inferiore all’anno (inizio o cessazione del rapporto di lavoro nel corso dell’anno), limitatamente ai contratti in cui è stato scelto di applicare la detrazione)

	--"AR - Dettaglio oneri deducibili: descrizione onere, importo. Tali importi non vanno riportati nella dichiarazione dei redditi"
	--(Nel contratto abbiamo la possibilità di inserire gli oneri deducibili)

	--"AX - Reddito assimilato assoggettato a ritenuta a titolo d'imposta, indicare importo, indicare ritenuta a titolo d'imposta operata."
	--(Valorizzare quando il compenso è un parasubordinato ed è associata ad una ritenuta IRPEF del 30%. La stessa condizione che abbiamo quando valorizziamo il campi del modello 221 e 222)

	--"BB - Saldo dell'addizionale comunale all'IRPEF non operata in quanto in possesso dei requisiti reddituali per usufruire interamente della fascia di esenzione deliberata"
	--(Da indicare quando non si calcola l'addizionale comunale all'IRPEF perchè il reddito rientra nei limiti di esenzione. Ad esempio se il comune prevede una fascia di esenzione dell'addizionale comunale all'IRPEF)

	--"ZZ - Redditi totalmente esentati da imposizione in Italia: indicare Importo del reddito."
	--(Qundo si usa una prestazione che non abbia il falg in tipo prestazione sull'opzione "Per residenti all'estero" e la prestazione non ha ritenute fiscali associate)

	--ZZ - Il percipiente dovrà procedere ad effettuare le operazioni di conguaglio in sede di dichiarazione dei redditi in quanto i redditi certificati non sono stati oggetto di conguaglio da parte del sostituto.
	-- (Quanto è stato erogato un cedolino di conguaglio riepilogativo fittizio)
	
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
 
	--  Il cursore seleziona tutti i contratti la cui prestazione ricade nella certificazione CUD
	--  e tutti i CUD cartacei associati ai contratti.
	DECLARE #cud_crs INSENSITIVE CURSOR FOR
	SELECT
		#contratti.fiscaltaxablegross,
		payroll.start, payroll.stop, #contratti.idcon,
		#contratti.servicecode770
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
	FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon,@servicecode770

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
					WHEN  @servicecode770 = '07_BRS_GEN' 
					THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c) D.P.R. 917/86, '
					WHEN  @servicecode770 IN ('07_COPENOINPS', '05_COORDM', '16_COORDM_DS','16_COORDM_AS',
									   '05_COORDN', '16_COORDN_DS','16_COORDN_AS',
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
	
 
		FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon,@servicecode770
		SET @contacud = @contacud + 1
		END
		
		CLOSE #cud_crs
		DEALLOCATE #cud_crs
		
		------------------------------------------------------------------
		-- ATTENZIONE: L'ANNOTAZIONE AJ E' STATA SOSTITUITA CON BW MA SOLO 
		-- IN CASO SPECIFICO DI ESENZIONE --------------------------------
		------------------------------------------------------------------
		IF  @reddito_esente_codice_3 > 0 -- CODICE ESENZIONE = 3   
		BEGIN
			-----------------------------------------------------------------
			-------------------------- NOTE BW ------------------------------
			-- "BW - Redditi totalmente esentati da imposizione in Italia: --
			---------------- indicare Importo del reddito." -----------------
			--  (Quando si usa una prestazione che abbia il flag ------------
			-- sul tipo di prestazione "Per residenti all'estero" -----------
			-- e la prestazione non ha ritenute fiscali associate), ---------
			-- e il codice esenzione indicato nella casella 468 è pari a 3 --
			-- Nel caso di redditi parzialmente esentati da imposizioni -----
			-- in Italia, l’ammontare del reddito escluso dalla tassazione --
			-- deve essere indicato nel punto 469, riportando altresì -------
			-- il codice 3 nel punto 468. -----------------------------------
			---------- Indicare l'importo lordo del reddito ----------------- 
			-----------------------------------------------------------------

			SET @NN =
				'BW - Redditi  esentati da imposizione in Italia il quanto ' + 
				'il percipiente risiede in uno Stato estero: '   
				+ 'Importo del reddito esente percepito: € ' + CONVERT(varchar(16), @reddito_esente_codice_3)  
			INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
				VALUES(@progrCom, 'NN', 1, 1, '002', @NN)
		END



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
	IF ((@DB001022 <> 0)  --@ritenuta_addreg_irpef
		 OR 
		(@DB001027 <> 0)) --@ritenuta_addcom_irpef_saldo_2017
	BEGIN
		SET @NN =
		CASE 
			WHEN ((@DB001022 <> 0) AND  (@DB001027 = 0))  THEN 'AL - Le addizionali regionali sono state interamente trattenute.'
			WHEN ((@DB001027 <> 0) AND (@DB001022 = 0))  THEN 'AL - Le addizionali comunali sono state interamente trattenute.' 
			ELSE 'AL - Le addizionali regionali e comunali sono state interamente trattenute.'
		END
		    INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			VALUES(@progrCom, 'NN', 1, 1, '003', @NN)
	END	
		
	IF (@workingdays < 365)  AND (@taxablegross<> 0) AND (@DB001367 <> 0) 
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
	IF ((@DB001481 <> 0)  --@taxablegross_irpef_stranieri
		 OR 
	    (@DB001482 <> 0)) --@ritenuta_irpef_stranieri
	BEGIN
		SET @NN =
		'AX - Reddito assimilato assoggettato a ritenuta a titolo d''imposta,' +
		+ ' Importo: € ' + CONVERT(varchar(16), @taxablegross_irpef_stranieri) 
		+ ' Importo ritenuta a titolo d''imposta operata: € ' + CONVERT(varchar(16), @ritenuta_irpef_stranieri)   
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
		VALUES(@progrCom, 'NN', 1, 1, '006', @NN)
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
	(@DB001367 =  0) --@ritenuta_addcom_irpef_saldo_2017 non applicata
	BEGIN
		SET @NN =
		'BB - Saldo dell''addizionale comunale all''IRPEF non operata in quanto' + 
		' in possesso dei requisiti reddituali per usufruire interamente della fascia' +
		' di esenzione deliberata'
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			VALUES(@progrCom, 'NN', 1, 1, '007', @NN)
	END
	
 
	IF 
	(( @ritprevtrattenuta <> 0)  -- @ritprevtrattenuta
	 OR 
     (@ritprevpagata <> 0)) --@ritprevpagata
	BEGIN
		SET @NN =
		'ZZ - Le ritenute INPS trattenute ai sensi della Legge 335/95 art.2/c.26 e Legge 449/97 art.59/c.16' +
		' sono state regolarmente versate all''INPS: ' +
		' ritenute a carico percipiente: ' + char(128) + CONVERT(varchar(16), @ritprevtrattenuta)  +
		--' ritenute a carico percipiente: ' + Format(@ritprevtrattenuta,'C','it-it')  collate Latin1_General_CS_AS +
		' e ritenute a carico ente: ' + char(128) +  + CONVERT(varchar(16), @ritprevamministrazione)
 		--' e ritenute a carico ente: ' +  FORMAT( @ritprevamministrazione,'C','it-it') collate Latin1_General_CS_AS
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			 VALUES(@progrCom, 'NN', 1, 1, '009', @NN)
	END
	
	
	IF @summarybalance = 'S'
	BEGIN
		SET @NN = (SELECT 'ZZ - Il percipiente dovrà procedere ad effettuare le operazioni di conguaglio in sede di dichiarazione dei redditi in quanto i redditi certificati non sono stati oggetto di conguaglio da parte del sostituto.')
		INSERT INTO #recordg (progr, quadro,modulo, riga, colonna, stringa)
							VALUES(@progrCom, 'NN', 1,1 ,'009', @NN collate  SQL_Latin1_General_CP1_CI_AS  )
	END 
	--SELECT  DISTINCT servicecode770, exemptioncode
	--FROM    #ser WHERE exemptioncode IS NOT NULL order by exemptioncode
	-- LE VECCHIE ANNOTAZIONI BQ ORA CONFLUISCONO IN ZZ
	SET  @counter = 0
	DECLARE @reddito_esente_servicecode770 DECIMAL(19,2)
	DECLARE @text_for_annotation varchar(400) 
	DECLARE @annotation varchar(400)
	DECLARE @description varchar(200)
	DECLARE rowcursor_bq INSENSITIVE CURSOR FOR
	SELECT  DISTINCT servicecode770, exemptioncode --,annotation, description
	FROM    #ser WHERE exemptioncode IS NOT NULL order by exemptioncode

	FOR READ ONLY
	OPEN rowcursor_bq
	FETCH NEXT FROM rowcursor_bq
	INTO @servicecode770, @exemptioncode -- ,@annotation, @description
	set @rimborso_residuo  = @rimborso

	WHILE @@FETCH_STATUS = 0
	BEGIN 
		SET @counter  = @counter + 1
		print @servicecode770
		print @exemptioncode
		-- Prestazioni degli assegnisti totalmente esenti, no stranieri
		--print 'note_esente'
 	--		 SELECT *	FROM	#contratti	 			 
		--			JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
		--			WHERE /*#contratti.padre IS NULL
		--				AND*/ NOT EXISTS (SELECT * FROM servicetaxview
		--							   WHERE servicetaxview.idser = #contratti.idser
		--									 AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
		--				AND NOT EXISTS(SELECT * FROM payrolltax cr
		--									JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind in (1,3)	AND geoappliance IS NULL
		--									WHERE   cr.idpayroll= P.idpayroll)
		--				AND #contratti.servicecode770 = @servicecode770
		--				AND #contratti.exemptioncode = @exemptioncode
 
		SET @reddito_esente_servicecode770 =  ISNULL (
			(SELECT SUM(p.feegross) 	FROM	#contratti	 			 
					JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
					WHERE /*#contratti.padre IS NULL
						AND*/ NOT EXISTS (SELECT * FROM servicetaxview
									   WHERE servicetaxview.idser = #contratti.idser
											 AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
						AND NOT EXISTS(SELECT * FROM payrolltax cr
											JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind in (1,3)	AND geoappliance IS NULL
											WHERE   cr.idpayroll= P.idpayroll)
						AND #contratti.servicecode770 = @servicecode770
						AND #contratti.exemptioncode = @exemptioncode
			),0)

			--select @reddito_esente_servicecode770
	    if (@rimborso_residuo>0) 
			begin
				if (@reddito_esente_servicecode770 >= @rimborso_residuo) 
					begin
						SET @reddito_esente_servicecode770  = isnull(@reddito_esente_servicecode770,0)-isnull(@rimborso_residuo,0)
						set @rimborso_residuo=0;
					end
			    else 
					begin
						set @rimborso_residuo= @rimborso_residuo- @reddito_esente_servicecode770;
						set @reddito_esente_servicecode770=0;
					end
			end

		IF	(SELECT COUNT(*)
			FROM #ser
			JOIN service
				ON #ser.idser = service.idser)> 0
			AND @straniero_conv = 'N'
			AND (
					(@DB001002 = 0
					AND (@prestazione_esente = 'S') --> imponibile IRPEF Italiani 
					AND isnull(@taxablegross_dipendentipubblici	,0) = 0	  --> @taxablegross_dipendentipubblici	 
					AND isnull(@compensoprev,0) = 0   --> Totale imponibile pensionistico
					)
				OR @EsisteAlmenoUnaPrestazioneTotalmenteEsente = 'S'
				)
				 
 				if (@reddito_esente_servicecode770 <> 0)  
				BEGIN
						SET @text_for_annotation = ( SELECT top 1 annotation FROM #ser WHERE servicecode770 = @servicecode770) 
						IF (@text_for_annotation IS NULL) 
							SET @text_for_annotation = (SELECT 'ZZ - Redditi totalmente esentati da imposizione:')
						ELSE 
							SET @text_for_annotation =  'ZZ' +  @text_for_annotation
						SET @NN = @text_for_annotation + ' ' + (SELECT top 1 description FROM #ser WHERE servicecode770 = @servicecode770 ) +  ': ' + char(128) + CONVERT(varchar(16),
									@reddito_esente_servicecode770)  
				 
						INSERT INTO #recordg (progr, quadro,modulo, riga, colonna, stringa)
							VALUES(@progrCom, 'NN', 1,@counter ,'009', @NN)
				END		 

	FETCH NEXT FROM rowcursor_bq
	INTO @servicecode770, @exemptioncode 
	END 
	DEALLOCATE rowcursor_bq
	
	-- GL: Importi non trattenuti a seguito di assistenza fiscale: Saldo Irpef 2014, importo (...); addizionale regionale 2014, importo
	--(...); saldo addizionale comunale 2014, importo (...);importo (...) acconto tassazione separata, importo (...).
	-- Sono gli importo CAF
/*	Campo 63: qualora l'importo non fosse stato tutto o in parte trattento, va indicata la parte non trattenuta (***)
	Campo 73 - Add.Regionale da Trattenere, quota non trattenuta (***)
	Campo 82 - Add.Comunale da Trattenere, quota non trattenuta (***)
	Campo 112 -  acconto del 20% su redditi a tassazione separata, quota non trattenuta(***)
	@nonTrattenuto07_IRPEF_CAF decimal(19,2)-- da calcolare DB001063
	@nonTrattenuta07_ADDREGCAF decimal(19,2)	--	da calcolare DB001073
	@nonTrattenuta07_ADDCOMCAF decimal(19,2),	--	da calcolare DB001082
	@nonTrattenuto07_TASSASEP decimal(19,2), -- da calcolare DB001112
*/
	if(@nonTrattenuto07_IRPEF_CAF<> 0 or @nonTrattenuta07_ADDREGCAF <>0 or  @nonTrattenuta07_ADDCOMCAF<>0 or @nonTrattenuto07_TASSASEP<>0)
	Begin
		SET @NN = 'GL - Importi non trattenuti a seguito di assistenza fiscale:'
		if (@nonTrattenuto07_IRPEF_CAF<>0 ) SET @NN = @NN + 'Saldo Irpef 2014, importo ('+ CONVERT(varchar(16), @nonTrattenuto07_IRPEF_CAF) +');'
		if (@nonTrattenuta07_ADDREGCAF<>0 ) SET @NN = @NN + 'addizionale regionale 2014, importo ('+ CONVERT(varchar(16), @nonTrattenuta07_ADDREGCAF) +');'
		if (@nonTrattenuta07_ADDCOMCAF<>0 ) SET @NN = @NN + 'saldo addizionale comunale 2014, importo ('+ CONVERT(varchar(16), @nonTrattenuta07_ADDCOMCAF) +');'
		if (@nonTrattenuto07_TASSASEP<>0 )	SET @NN = @NN + 'acconto tassazione separata, importo  ('+ CONVERT(varchar(16), @nonTrattenuto07_TASSASEP) +');' 
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
		VALUES(@progrCom, 'NN', 1, 1, '010', @NN)
	End
		
	SET @NN = 'ZZ - Si consiglia di presentare la dichiarazione dei redditi (mod. 730 o Unico) per effettuare eventuali operazioni di conguaglio non effettuate dal sostituto d''imposta. '
	INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
		VALUES(@progrCom, 'NN', 1, 1, '011', @NN)

	--SELECT   stringa
	--FROM    #recordg WHERE 
	--quadro = 'NN'
 
	--DECLARE @codean varchar(2)
	--DECLARE @counter_an int
	--SET @counter_an = 0
	---- In questo ciclo 
	--DECLARE rowcursor_ann INSENSITIVE CURSOR FOR
	--SELECT  DISTINCT  substring(stringa,1, 2)
	--FROM    #recordg WHERE 
	--quadro = 'NN'
	--FOR READ ONLY
	
	--OPEN rowcursor_ann
	--FETCH NEXT FROM rowcursor_ann
	--INTO @codean
	--WHILE @@FETCH_STATUS = 0
	--BEGIN 
	--	SET @counter_an  = @counter_an + 1
	--	INSERT INTO #recordg (progr, quadro,modulo, riga, colonna, stringa)
	--	VALUES(@progrCom, 'NN', 1,1, RIGHT('000' +  convert(varchar(3), @counter_an),3),@codean  )	
	--	FETCH NEXT FROM rowcursor_ann
	--	INTO @codean		 
	--END

	--DEALLOCATE rowcursor_ann

--	SELECT * FROM #recordG 

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
END
GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 
 
 

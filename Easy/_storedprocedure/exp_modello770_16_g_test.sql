
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


if exists (SELECT * from dbo.sysobjects where id = object_id(N'[exp_modello770_16_g_test]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_16_g_test]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  PROCEDURE [exp_modello770_16_g_test] 
AS BEGIN
-- exec exp_modello770_15_g_test

	-- Inizio Sezione dichiarativa
 

	declare @annodichiarazione int
	set @annodichiarazione = 2016

	declare @annoredditi int
	set @annoredditi = 2015
	
	declare @expensephase int
	
	select  @expensephase = expensephase from config where ayear = @annoredditi

 

	declare @31dic15 datetime
	set @31dic15 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})
	
	-- Ricordarsi di cambiare ogni anno l'anno delle date
	declare @1gen15_XXX datetime
	set @1gen15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @13gen15_XXX datetime
	set @13gen15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-13'})

	declare @31dic15_XXX datetime
	set @31dic15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen16_XXX datetime
	set @1gen16_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-01'})

	declare @12gen16_XXX datetime
	set @12gen16_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

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


	DECLARE @agencynumber VARCHAR(10)
		
	SELECT @agencynumber =  agencynumber FROM config
	WHERE  ayear = @annodichiarazione
	
	-- Fine Sezione dichiarativa
	-- La tabella #modulocococo ha dentro di se solamente il riferimento al percipiente, perché la certificazione deve essere prodotta a livello
	-- di percipiente.
	--------------------------------------------------------------------------------
	-------------------------- Estrazione dei Percipienti --------------------------
	--------------------------------------------------------------------------------
	CREATE TABLE #modulocococo (idreg int, cf varchar(16)) -- Codice del percipiente

	/*
		Inserisco per il momento solo i dati relativi alle rit. fiscali dei soli CEDOLINI di CONGUAGLIO
		perchè ho bisogno di prendere i dati conguagliati. C'è un problema derivante dal conguaglio in presenza
		di un cud presentato: Non c'è modo di capire se il cud presentato è un precedente contratto o altro
		Questo implica che gli imponibili (LE RITENUTE SONO OK) non possono essere tenuti in considerazione
		per la sommatoria che si farà in seguito per calcolare i redditi
	*/

	-- Riempimento della tabella dei percipienti coinvolti nella certificazione.
	-- per Modello 770
	-- Vengono presi tutti i percipienti associati a cedolini di conguaglio con anno di competenza quello della dichiarazione
	-- e trasmessi, inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- al quadro G del 770 (rec770kind = 'G') e di cui almeno un cedolino dell'anno corrente sia stato trasmesso
	-- per CUD
	-- Vengono presi tutti i percipienti associati a cedolini di conguaglio con anno di competenza quello della dichiarazione
	-- e trasmessi, inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- alla certificazione CUD (certificatekind = 'U') e di cui almeno un cedolino dell'anno corrente sia stato trasmesso
	INSERT INTO #modulocococo (idreg,cf) 
	SELECT DISTINCT co.idreg, registry.cf       
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service on service.idser = co.idser
		JOIN registry on registry.idreg = co.idreg
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND service.rec770kind='G'
		AND ce.disbursementdate is not null
		--------------------------------------------------------------------------------
		----- da rimuovere non appena sarà corretto l'errore dal software SOGEI --------
		--------------------------------------------------------------------------------
		AND (registry.cf IS NOT NULL) 
		--AND (registry.cf = @cf OR @cf IS NULL) -- decidere se fare la dichiarazione ad personam su specifici percipienti
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N') -- escludiamo determinati contratti marcati come da non esportare
		and registry.cf = 'PYNVGN77P53Z131H' 
		ORDER BY registry.cf 

--SELECT * FROM #modulocococo
		DECLARE @birthplace  varchar(200)
		DECLARE @birthnation varchar(200)
		DECLARE @birthprovince varchar(2)
		DECLARE @idcitynascita int
		
		DECLARE @DA001001 VARCHAR(50)
		DECLARE @DA001002 VARCHAR(100)
		DECLARE @DA001003 VARCHAR(100)
		DECLARE @DA001004 CHAR(1)
		DECLARE @DA001005 DATETIME
		DECLARE @DA001006 VARCHAR(200)
		DECLARE @DA001007 VARCHAR(2)
	 
		DECLARE @DA001008 VARCHAR(2)  -- CATEGORIE PARTICOLARI
		DECLARE @DA001009 INT		  -- EVENTI ECCEZIONALI
		DECLARE @DA001010 INT		  -- CASI ESCLUSIONE PRECOMPILATA
		
		--Domicilio fiscale al 1/1/2014
		DECLARE @DA001020 VARCHAR(200)
		DECLARE @DA001021 VARCHAR(2)
		DECLARE @DA001022 VARCHAR(4)
		--Domicilio fiscale al 1/1/2015
		DECLARE @DA001023 VARCHAR(200)
		DECLARE @DA001024 VARCHAR(2)
		DECLARE @DA001025 VARCHAR(4)
		DECLARE @DA001026 VARCHAR(3)
		
		DECLARE @DA001040 VARCHAR(50)
		DECLARE @DA001041 VARCHAR(200)
		DECLARE @DA001042 VARCHAR(100)
		DECLARE @DA001043 VARCHAR(4)
		
	declare
		@servicecode770 varchar(20),
		@idreg int,
		@denominazione varchar(50),
		@p_iva varchar(15),

		@idnationnascita int,
		@flagcfestero char,

		@a1cf varchar(20),
		@registryspecialcategory varchar(2),
		@codiceComuneEnte varchar(4)
		
	DECLARE @codfiscEnte varchar(16)
	declare @idcityEnte int
	SELECT  @codfiscEnte = cf, @idcityEnte = idcity FROM license

	-- Fine Seconda Sezione dichiarativa

	---- Tabella di output che contiene le informazioni del record G (che successivamente verranno elaborate dal form del 770)
	--CREATE TABLE #recordg
	--(
	--	progr int,
	--	quadro varchar(3),
	--	riga int,
	--	colonna varchar(3),
	--	stringa varchar(100),
	--	decimale dec(19,2),
	--	intero int,
	--	data datetime
	--)
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

	-- Fase massima di spesa
	DECLARE @maxexpensephase tinyint
	SELECT @maxexpensephase = MAX(nphase) FROM expensephase

	-- Tabella delle prestazioni adoperate nei contratti
	CREATE TABLE #ser (idser int, servicecode770 varchar(20), annotation varchar(400), exemptioncode int)

	-- Vengono considerate solo le prestazioni NON presenti nel modulo PARASUBORDINATI
	-- Riempimento della tabella dei percipienti coinvolti nella certificazione.
	-- per Modello 770
	-- Vengono presi tutti i movimenti di spesa il cui percipiente ha una tipologia differente da quella "per mandati"
	-- con importo netto maggiore di zero e con data di trasmissione avvenuta tra il 13 gennaio dell'anno precedente ed il 12 gennaio
	-- dell'anno corrente, che il movimento di spesa non derivi dalla contabilizzazione di un cedolino e che la prestazione
	-- associata al movimento di spesa ricada nel quadro G del 770

	-- Tabella dei contratti parasubordinati coinvolti nel 770
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
		stopcontract datetime, -- Data cessazione rapporto di lavoro
		capofila char(1),
		certificatekind char(1),
		idser int,
		servicecode770 varchar(20),
		highertax decimal(19,2),
		applicaritprevidenziali char(1),
		exemptioncode int
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
	
	-- Tabella del coniuge (per le detrazioni su familiari)
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

		CREATE TABLE #comuniaddcom
	(
		idcon int,
		idcedolino int,
		idcity int,
		idfiscaltaxregion int ,
		codcatastale varchar(4)
	)
		

	CREATE TABLE #address
		(
			idaddresskind int,
			codeaddress varchar(20),
			idreg int,
			address varchar(100),
			location varchar(116),
			cap varchar(15),
			province varchar(2),
			idcity int,
			idnation int,
			nation varchar(65),
			start datetime,
			stop datetime,
			rif_address char(1),
			codice_catastale varchar(4),
			codice_iso_nazione varchar(4)
		)
		
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
	
	-- Progressivo comunicazione
	declare @progrCom int
	set @progrCom = 1

	declare @chiave int

	declare @cognome varchar(60)	
	declare @registry_cf varchar(20)

	declare @cursorecomunicazione cursor 

	-- Si definisce un cursore per ciclare sui percipienti (nel caso di prestazioni inserite da modulo parasubordinati).
	
	set @cursorecomunicazione = cursor for
		SELECT DISTINCT #modulocococo.idreg,surname,  #modulocococo.cf
		FROM #modulocococo
		JOIN registry
			ON #modulocococo.idreg = registry.idreg
		order by #modulocococo.cf
	 

	open @cursorecomunicazione
	fetch next from @cursorecomunicazione into @chiave, @cognome ,@registry_cf

	WHILE @@fetch_status=0 
	begin
		-- Inizio Sezione azzeramento variabili
		set @a1cf = null
		
		-- Inizio Sezione azzeramento variabili

		SELECT @codiceComuneEnte = value from geo_city_agency 
			where idcode=1 and idcity=@idcityente and idagency=1
	
		--4 Spazio a disposizione dell'utente (non credo sia necessario)
		--- INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRG', 1, '04', @tipo)
		--8 Spazio a disposizione dell'utente per l'identificazione della dichiarazione
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRG', 1, '08', @chiave)
			
		-- Si imposta la variabile il percipiente che nel caso di spesa viene estratta in base al movimento di spesa
		-- nel caso di parasubordinato è direttamente il valore della variabile @chiave
	
		SET @idreg = @chiave
	
		-- Modulo Parasubordinati

		-- Si svuota la tabella dei contratti legata al percipiente
		DELETE #contratti
		-- insert into #contratti (idcon, padre) values (@chiave, null)

		-- Si inseriscono i contratti del percipiente corrente.
		-- La query eseguita ricalca quella adottata per la selezione dei percipienti (riempimento della tabella #modulocococo)
		-- Più precisamente:
		-- per Modello 770
		-- Vengono presi tutti i contratti di un fissato percipiente per i quali esiste almeno un cedolino che sia stato trasmesso
		-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
		-- al quadro G del 770 (rec770kind = 'G'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
		-- le deduzioni, l'imponibile fiscale lordo del contratto e l'id e la data di fine del cedolino di conguaglio.
			
		INSERT INTO #contratti
			(idcon, taxablepension, inpsinail, deduction,
			 fiscaltaxablegross, idpayroll, start, stop, stopcontract, certificatekind, idser,
			 servicecode770, highertax,
			 applicaritprevidenziali, exemptioncode)
		SELECT
			co.idcon,
			s.taxablepension,
			s.inpsinail,
			s.deduction,
			s.fiscaltaxablegross,
			ce.idpayroll,
			ce.start,
			ce.stop,
			co.stop, -- data cessazione del rapporto di lavoro
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
		motive770service.exemptioncode
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
		LEFT OUTER JOIN motive770service
			ON service.idser = motive770service.idser
			AND motive770service.ayear = @annoredditi
		WHERE ce.flagbalance = 'S'
			AND ce.fiscalyear=@annoredditi
			-- AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
			AND EXISTS (SELECT payroll.idpayroll from payroll 
					join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
					join expenselink ON expenselink.idparent = expensepayroll.idexp
					join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
					join payment on payment.kpay=expenselast.kpay
					where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
			AND (service.rec770kind='G')
			AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
			AND co.idreg = @chiave

		DECLARE @start datetime 
		DECLARE @stop  datetime 
		
		SELECT 	@start = MIN(start) FROM #contratti   
		WHERE EXISTS
			( SELECT *  
				FROM servicetaxview 
			   WHERE servicetaxview.idser = #contratti.idser
				 AND servicetaxview.taxkind = 1) 
	 
			
		SELECT 	@stop  = MAX(stop)  FROM #contratti	   
		WHERE EXISTS
			( SELECT *  
				FROM servicetaxview 
			   WHERE servicetaxview.idser = #contratti.idser
				 AND servicetaxview.taxkind = 1) 
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
 
	 	--------------------------------------------------------------------------------------------
	 	------------------------------------- PARTE A-----------------------------------------------
		------- Dati relativi al dipendente, pensionato o altro percettore delle somme -------------
		--------------------------------------------------------------------------------------------
		-- Valorizzazione delle informazioni relative al percipiente
		
		SELECT
			@denominazione = registry.title,
			@a1cf =  registry.cf,
			@p_iva = registry.p_iva,
			@DA001002 = registry.surname,
			@DA001003 = registry.forename,
			@DA001005 = registry.birthdate,
			@DA001004 = registry.gender,
			@idcitynascita = registry.idcity,
			@idnationnascita = registry.idnation,
			@flagcfestero = CASE 
				WHEN registry.cf IS NULL THEN 'S'
				WHEN registry.cf IS NOT NULL THEN 'N'
			END,
			@registryspecialcategory = idspecialcategory770
			FROM registry
			LEFT OUTER JOIN  registryspecialcategory770
				ON registry.idreg = registryspecialcategory770.idreg
				AND  registryspecialcategory770.ayear = @annoredditi
			WHERE registry.idreg = @idreg
	
	--SELECT @denominazione, @a1cf
		-- Attualizzazione del comune di nascita
		if (@idcitynascita is not null)
		BEGIN
			while (select newcity from geo_city where idcity=@idcitynascita) is not null
			BEGIN
				select @idcitynascita=newcity from geo_city where idcity=@idcitynascita 
			END
			SELECT
				@birthplace = geo_city.title,
				@birthprovince =  geo_country.province 
				FROM geo_city 
				LEFT OUTER JOIN geo_country ON geo_city.idcountry = geo_country.idcountry
				WHERE geo_city.idcity=@idcitynascita
		END
		
		IF (@birthplace IS NOT NULL)   
			BEGIN
				SET @DA001006 = @birthplace
				SET @DA001007 = ISNULL(@birthprovince,'EE')
			END
		  
		IF (@birthnation IS NOT NULL)   
			BEGIN
				SET @DA001006 = @birthnation
				SET @DA001007 = 'EE'
			END
		
		IF(@registryspecialcategory IS NOT NULL)
		BEGIN
				SET @DA001008 = @registryspecialcategory
		END
		
		----------------------------------------------
		------------  LETTURA DEGLI INDIRIZZI --------
		----------------------------------------------

		DECLARE @codenostand varchar(20)
		SET @codenostand = '07_SW_DOM' -- DOMICILIO FISCALE

		DECLARE @codestand varchar(20)
		SET @codestand = '07_SW_DEF' -- RESIDENZA

		----------------------------------------------------
		------------ DOMICILIO FISCALE ALL'1/1/2014 --------
		----------------------------------------------------
		DECLARE @STAND int
		SELECT  @STAND = idaddress FROM address WHERE codeaddress = @codestand

		DECLARE @NOSTAND int
		SELECT  @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

		DECLARE @dateindi_01_gen_14 datetime
		DECLARE @dateindi_01_gen_15 datetime

		SET @dateindi_01_gen_14 = DATEADD(yy, @annoredditi - 2000, {d '2000-01-01'})
		SET @dateindi_01_gen_15 = DATEADD(yy, @annodichiarazione - 2000, {d '2000-01-01'})
		
		DELETE FROM  #address
		

		INSERT INTO #address
		(
			idaddresskind,
			codeaddress,
			idreg,
			address,
			location,
			cap,
			province,
			idcity,
			idnation,
			nation,
			start,
			stop,
			codice_catastale,
			codice_iso_nazione
		)
		SELECT
			idaddresskind,
			codeaddress,
			idreg,
			registryaddress.address,
			ISNULL(geo_city.title,registryaddress.location),
			registryaddress.cap,
			geo_country.province,
			registryaddress.idcity,
			CASE
				WHEN flagforeign = 'N' THEN 1
				ELSE geo_nation.idnation
			END,
			CASE
				WHEN flagforeign = 'N' THEN 'ITALIA'
				ELSE geo_nation.title
			END,
			registryaddress.start,
			registryaddress.stop,
			G.value,
			N.value
		FROM registryaddress
		LEFT OUTER JOIN geo_city
			ON geo_city.idcity = registryaddress.idcity
		LEFT OUTER JOIN geo_country
			ON geo_city.idcountry = geo_country.idcountry
		LEFT OUTER JOIN geo_nation
			ON geo_nation.idnation = registryaddress.idnation
		JOIN  address
			ON address.idaddress = registryaddress.idaddresskind
		LEFT OUTER JOIN geo_city_agency G  -- lettura del codice catastale
			ON  G.idcity = registryaddress.idcity
			AND G.idagency = 1 and G.idcode = 1
		LEFT OUTER JOIN geo_nation_agency N -- eventuale nazione di residenza, se estero
			ON N.idnation = registryaddress.idnation
			AND N.idagency = 5 -- ente ISO           
			AND N.idcode = 1 -- codifica nazioni ISO
			AND N.version = 1
			AND N.stop IS NULL
		WHERE
		((registryaddress.stop IS NULL AND registryaddress.active <>'N' ) OR (registryaddress.stop >= @dateindi_01_gen_14))
			AND registryaddress.start =
			(SELECT MAX(cdi.start)
			FROM registryaddress cdi
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
				AND (cdi.start <= @dateindi_01_gen_14)
				AND ((cdi.stop IS NULL AND  cdi.active <>'N') OR (cdi.stop >= @dateindi_01_gen_14))
				AND cdi.idreg = registryaddress.idreg)
				AND idreg = @idreg
		   
		DELETE #address
		WHERE #address.idaddresskind NOT IN (@nostand, @stand)
			AND EXISTS(
				SELECT * FROM #address r2
				WHERE #address.idreg = r2.idreg
					AND (r2.idaddresskind = @stand
					OR r2.idaddresskind = @nostand)
			)

		SELECT @DA001020 = location FROM #address WHERE nation = 'ITALIA'
		SELECT @DA001021 = province FROM #address WHERE nation = 'ITALIA'
		SELECT @DA001022 = codice_catastale FROM #address WHERE nation = 'ITALIA'

		DECLARE @IND001 VARCHAR(200)
		SET @IND001 = @DA001002 + ' ' + @DA001003 -- Riga 1: cognome nome

		DECLARE @IND002 VARCHAR(200)
		SELECT @IND002 = address FROM #address  -- Riga 2: Via....

		DECLARE @IND003 VARCHAR(300) -- Riga 3 Paese
		if ((select TOP 1 nation from #address) ='ITALIA')
		begin
			SELECT @IND003 = cap + ' ' + @DA001020 + '  ' + @DA001021 FROM #address 
		end
		else
		begin
			SELECT @IND003 = nation FROM #address  
		end
				
		----------------------------------------------------
		------------ DOMICILIO FISCALE ALL'1/1/2015 --------
		----------------------------------------------------
		DELETE FROM #address

		INSERT INTO #address
		(
			idaddresskind,
			codeaddress,
			idreg,
			address,
			location,
			cap,
			province,
			idcity,
			idnation,
			nation,
			start,
			stop,
			codice_catastale,
			codice_iso_nazione
		)
		SELECT
			idaddresskind,
			codeaddress,
			idreg,
			registryaddress.address,
			ISNULL(geo_city.title,registryaddress.location),
			registryaddress.cap,
			geo_country.province,
			registryaddress.idcity,
			CASE
				WHEN flagforeign = 'N' THEN 1
				ELSE geo_nation.idnation
			END,
			CASE
				WHEN flagforeign = 'N' THEN 'ITALIA'
				ELSE geo_nation.title
			END,
			registryaddress.start,
			registryaddress.stop,
			G.value,
			N.value
		FROM registryaddress
		LEFT OUTER JOIN geo_city
			ON geo_city.idcity = registryaddress.idcity
		LEFT OUTER JOIN geo_country
			ON geo_city.idcountry = geo_country.idcountry
		LEFT OUTER JOIN geo_nation
			ON geo_nation.idnation = registryaddress.idnation
		JOIN  address
			ON address.idaddress = registryaddress.idaddresskind
		LEFT OUTER JOIN geo_city_agency G  -- lettura del codice catastale
			ON  G.idcity = registryaddress.idcity
			AND G.idagency = 1 and G.idcode = 1
		LEFT OUTER JOIN geo_nation_agency N -- eventuale nazione di residenza, se estero
			ON N.idnation = registryaddress.idnation
			AND N.idagency = 5 -- ente Ufficio Cambi           
			AND N.idcode = 1 -- codifica Ufficio Cambi   
			AND N.version = 1
			AND N.stop IS NULL
		WHERE
		((registryaddress.stop IS NULL AND registryaddress.active <>'N' ) OR (registryaddress.stop >= @dateindi_01_gen_15))
			AND registryaddress.start =
			(SELECT MAX(cdi.start)
			FROM registryaddress cdi
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
				AND (cdi.start <=  @dateindi_01_gen_15)
				AND ((cdi.stop IS NULL AND cdi.active <>'N') OR (cdi.stop >= @dateindi_01_gen_15))
				AND cdi.idreg = registryaddress.idreg)
				AND idreg = @idreg
		   
		DELETE #address
		WHERE #address.idaddresskind NOT IN (@nostand, @stand)
			AND EXISTS(
				SELECT * FROM #address r2
				WHERE #address.idreg = r2.idreg
					AND (r2.idaddresskind = @stand
					OR r2.idaddresskind = @nostand)
			)
	  
		SELECT @DA001023 = location FROM #address WHERE nation = 'ITALIA'
		SELECT @DA001024 = province FROM #address WHERE nation = 'ITALIA'
		SELECT @DA001025 = codice_catastale FROM #address WHERE nation = 'ITALIA'

		SELECT @DA001043 = codice_iso_nazione FROM #address WHERE nation <> 'ITALIA'

		-- SELECT @stop = MAX(stop) FROM #contratti
			
	
		-- Inizio Sezione di inserimento nella tabella di output delle righe inerenti la testata del quadro G
		--1 Tipo record
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRG', 1, '01', 'G')
		--2 Codice fiscale del soggetto dichiarante
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRG', 1, '02', @codfiscEnte)
		--3 Progressivo comunicazione
		INSERT INTO #recordg (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'HRG', 1, '03', @progrCom)
		--6 Codice fiscale del percipiente
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRG', 1, '06', @a1cf)
		-- Fine Sezione di inserimento nella tabella di output delle righe inerenti la testata del quadro G

		------------------------------------------------------------------------------------------------------------ 
		-- Inizio Sezione di inserimento nella tabella di output delle righe inerenti alla sezione A del quadro G --
		---------------------------------------------PARTE A -------------------------------------------------------
		-------------- Dati relativi al dipendente, pensionato o altro percettore delle somme ----------------------
		------------------------------------------------------------------------------------------------------------
		
		--DA001001 Codice fiscale
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '001', @a1cf)
		--DA001002 Cognome
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '002', @DA001002)
		--DA001003 Nome
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '003', @DA001003)
		--DA001004 Sesso
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '004', @DA001004)
		--DA001005 Data di nascita
		INSERT INTO #recordg (progr, quadro, riga, colonna, data)    VALUES(@progrCom, 'DA', 1, '005', @DA001005)
		--DA001006 Comune (o Stato estero) di nascita
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '006', @DA001006)
		--DA001007 Provincia di nascita (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '007', @DA001007)
		--DA001008 Categorie Particolari 
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '008', @DA001008)

		-------------------------------------------------------------------------------------------------------------
		------------------------------------ DOMICILIO FISCALE ALL'01 01 2014 ---------------------------------------
		-------------------------------------------------------------------------------------------------------------
		--DA001020 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '020', @DA001020)
		--DA001021 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '021', @DA001021)
		--DA001022 Codice comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '022', @DA001022)
		-------------------------------------------------------------------------------------------------------------
		------------------------------------ DOMICILIO FISCALE ALL'01 01 2015 ---------------------------------------
		-------------------------------------------------------------------------------------------------------------
		--DA001023 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '023', @DA001023)
		--DA001024 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '024', @DA001024)
		--DA001025 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DA', 1, '025', @DA001025)
		--@DA001043 Codice Stato Estero Residenza
		INSERT INTO #recordg (progr,quadro, riga, colonna, intero)  VALUES(@progrCom, 'DA', 1, '043', @DA001043)
		-- Fine Sezione di inserimento nella tabella di output delle righe inerenti alla sezione A del quadro G
		-------------------------------------------------------------------------------------------------------------
		---------------------------------------- PARTE B - Dati fiscali ---------------------------------------------
		-------------------------------------------------------------------------------------------------------------
		--inizio modulo cococo
		delete #cedolini
		-- Riempimento della tabella dei cedolini.
		-- Vengono inseriti tutti i cedolini trasmessi associati ai contratti del percipiente dell'anno dei redditi.
		-- Di questi cedolini si seleziona il movimento di spesa che li contabilizza, la data di trasmissione,
		-- la data di inizio e fine ed il contratto di appartenenza.
			
		insert into #cedolini
		(idcedolino, idexp, idcon, datacompetenza, startpayroll, stoppayroll)
		SELECT
			expensepayroll.idpayroll, expensepayroll.idexp, payroll.idcon,
			null, payroll.start, payroll.stop
		from expensepayroll
		JOIN payroll on payroll.idpayroll=expensepayroll.idpayroll
		AND EXISTS ( SELECT *  FROM expenselast
			JOIN payment ON payment.kpay=expenselast.kpay
			JOIN paymenttransmission ON paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
			JOIN #contratti ON payroll.idcon=#contratti.idcon
			JOIN expenselink on expenselink.idparent=expensepayroll.idexp
			AND   expenselink.idchild = expenselast.idexp 
			where  (YEAR(paymenttransmission.transmissiondate)=@annoredditi  or (year(paymenttransmission.transmissiondate) = @annodichiarazione and 
			paymenttransmission.transmissiondate <= @12gen16_XXX))
		) 
		where fiscalyear=@annoredditi
		order by payroll.stop
		
		update #cedolini SET datacompetenza =
		(SELECT MAX(transmissiondate) 
			FROM expensepayroll 
			JOIN expenselink ON expenselink.idparent = expensepayroll.idexp
			JOIN expenselast ON expenselink.idchild  = expenselast.idexp
			JOIN payment ON  payment.kpay=expenselast.kpay
			JOIN paymenttransmission  ON payment.kpaymenttransmission=paymenttransmission.kpaymenttransmission
			WHERE (YEAR(paymenttransmission.transmissiondate)=@annoredditi  or (year(paymenttransmission.transmissiondate) = @annodichiarazione and 
			paymenttransmission.transmissiondate <= @12gen16_XXX))
			AND expensepayroll.idexp=#cedolini.idexp
	     )

		
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
					AND   EXISTS
					(SELECT * FROM servicetaxview
					WHERE servicetaxview.idser = #contratti.idser
						AND servicetaxview.taxkind = 1)
			)
			
		-- Si settano tutti i giorni rientranti nella durata di CUD cartacei a LAVORATI
		update #workdays set worked='S' where exists
		(SELECT * from exhibitedcud 
			join #contratti on exhibitedcud.idcon=#contratti.idcon
			where exhibitedcud.idlinkedcon is null and --controllo preciso ma superfluo
				 #workdays.giorno between exhibitedcud.start and exhibitedcud.stop
				AND exhibitedcud.fiscalyear = @annoredditi
		)
	
		-- Calcolo degli oneri sostenuti in altri contratti
		-- Essi sono dati dalla somma della differenza tra l'imponibile previdenziale e l'imponibile fiscale lordo
		-- dei CUD associati ai contratti non divenuti CUD per altri
		DECLARE @onerisostenutiinaltricontratti dec(19,2)
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

		-- Calcolo della detrazione per familiari a carico
		-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
		-- non divenuti CUD per altri
		-- Si considera ovviamente la sola detrazione con codice 28 che si riferisce ai familiari
		DECLARE @detrazioni_familiari_a_carico	DECIMAL(19,2)
		SET @detrazioni_familiari_a_carico  =
			ISNULL(
				(SELECT SUM(payrollabatement.curramount)
				FROM payrollabatement
				JOIN #contratti
					ON #contratti.idpayroll = payrollabatement.idpayroll
				WHERE idabatement in( 28,68)
					AND #contratti.padre IS NULL)
			,0)
		SET @detrazioni_familiari_a_carico = ISNULL(@detrazioni_familiari_a_carico,0)

		-- Calcolo della detrazione per reddito
		-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
		-- non divenuti CUD per altri 
		-- Si considera ovviamente la sola detrazione con codice 29 che si riferisce al reddito
		DECLARE @detrazioni_per_reddito DECIMAL(19,2)
			SET @detrazioni_per_reddito  =
			ISNULL(
				(SELECT SUM(payrollabatement.curramount)
				FROM payrollabatement
				JOIN #contratti
					ON #contratti.idpayroll = payrollabatement.idpayroll
				WHERE idabatement in (29,69)
					AND #contratti.padre IS NULL)
			,0)

		SET @detrazioni_per_reddito = ISNULL(@detrazioni_per_reddito,0)
		-- Calcolo della detrazione per oneri
		-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
		-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
		-- Si considerano tutte le detrazioni che sono marcate come oneri detraibili (flagabatableexpense = 'S')
		
		DECLARE @detrazioni_per_oneri DECIMAL(19,2)
		
		SET @detrazioni_per_oneri  =
		ISNULL(
			(SELECT SUM(payrollabatement.curramount)
			FROM payrollabatement
			JOIN #contratti
				ON #contratti.idpayroll = payrollabatement.idpayroll
			JOIN abatement
				ON abatement.idabatement = payrollabatement.idabatement
			WHERE abatement.flagabatableexpense = 'S'
				AND #contratti.padre IS NULL)
		,0)
        SET @detrazioni_per_oneri = ISNULL(@detrazioni_per_oneri,0)
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
			,0) -- Vengono prese le deduzioni associate alla sola ritenuta fiscale con applicazione regionale
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
                    AND expensetaxofficial.stop IS NULL
					AND tax.taxref NOT IN ('08_IRPEF_FOC','07_IRPEF_FO','14_BONUS_FISCALE'))
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

			-- Al primo calcolo parziale, si somma anche l'addizionale regionale applicata nei CUD cartacei associati ai contratti
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

		
DECLARE @ritenuta_addreg_irpef_rapporti_cessati DECIMAL(19,2)
	SET @ritenuta_addreg_irpef_rapporti_cessati =
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
			WHERE YEAR(#contratti.stopcontract)= @annoredditi AND  taxkind = 1 AND geoappliance = 'R'
                                    and expensetaxofficial.stop is null
				AND NOT EXISTS
				(SELECT * FROM servicetaxview
				WHERE servicetaxview.idser = #contratti.idser
					AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
			)
		,0) 

	-- Al primo calcolo parziale, si somma anche la ritenuta IRPEF applicata nei CUD cartacei associati ai contratti
	SET @ritenuta_addreg_irpef_rapporti_cessati =
		@ritenuta_addreg_irpef_rapporti_cessati +
		ISNULL(
			(SELECT SUM(exhibitedcud.regionaltaxapplied)
			FROM exhibitedcud
			JOIN #contratti
				ON #contratti.idcon = exhibitedcud.idcon
			WHERE fiscalyear = @annoredditi AND YEAR(#contratti.stopcontract)= @annoredditi  
				AND exhibitedcud.idlinkedcon IS NULL)
		,0)
		
		
		-- Campo 16 – Addizionale comunale acconto 2014. Va indicato l’importo dell’addizionale comunale all’IRPEF 
		-- effettivamente trattenuta dal sostituto a titolo d’acconto per il periodo d’imposta 2014. 
		-- Lo gestiamo con il codice ritenuta 07_ACC_ADDCOM.


-- Calcolo dell'acconto all'addizionale comunale all'IRPEF
		-- Si considera la somma degli acconti specificati all'interno dei contratti
		DECLARE @ritenuta_addcom_irpef_acconto_2014 DECIMAL(19,2)
		SET @ritenuta_addcom_irpef_acconto_2014 =
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
		
		
		DECLARE @ritenuta_addcom_irpef_saldo_2014_rapporti_cessati DECIMAL(19,2)
		SET @ritenuta_addcom_irpef_saldo_2014_rapporti_cessati =
		ISNULL(
			(SELECT SUM(employtax)
			FROM #cedolini
			JOIN #contratti
				ON #contratti.idcon = #cedolini.idcon
			JOIN expenselink
				ON #cedolini.idexp = expenselink.idparent
			JOIN expensetaxofficial
				ON expensetaxofficial.idexp = expenselink.idchild
			JOIN tax
				ON expensetaxofficial.taxcode=tax.taxcode
			WHERE tax.taxref = '05_ADDCOMU' and expensetaxofficial.stop is null  
			AND YEAR(#contratti.stopcontract) = @annoredditi)
		,0)

		-- Al primo calcolo parziale, si somma anche l'addizionale comunale applicata nei CUD cartacei associati ai contratti
		SET @ritenuta_addcom_irpef_saldo_2014_rapporti_cessati =
		@ritenuta_addcom_irpef_saldo_2014_rapporti_cessati +
		ISNULL(
			(SELECT SUM(exhibitedcud.citytaxapplied)
			FROM exhibitedcud
			JOIN #contratti
				ON #contratti.idcon = exhibitedcud.idcon
			WHERE fiscalyear = @annoredditi 
			    AND YEAR(#contratti.stopcontract) = @annoredditi
				AND exhibitedcud.idlinkedcon IS NULL)
		,0)

		-- Il saldo dell'addizionale comunale è pari alla differenza tra addizionale comunale e acconto alla stessa
		SELECT @ritenuta_addcom_irpef_saldo_2014  = @ritenuta_addcom_irpef_saldo_2014 - @ritenuta_addcom_irpef_acconto_2014   
		
		-- Il saldo dell'addizionale comunale rapporti cessati è pari alla differenza tra addizionale comunale e acconto alla stessa
		SELECT @ritenuta_addcom_irpef_saldo_2014_rapporti_cessati  = 
		@ritenuta_addcom_irpef_saldo_2014_rapporti_cessati - @ritenuta_addcom_irpef_acconto_2014   
		
		-- Se il saldo è negativo si valorizza il solo campo inerente all'acconto impostando a NULL il campo del saldo
		-- altrimenti si valorizza il campo del saldo impostando a NULL il campo dell'acconto (chiedere a Nino)
			--if @ritenuta_addcom_irpef_saldo_2014 < 0
			--begin
			--	set @ritenuta_addcom_irpef_acconto_2014 = @ritenuta_addcom_irpef_acconto_2014 + @ritenuta_addcom_irpef_saldo_2014
			--	set @ritenuta_addcom_irpef_saldo_2014 = null
			--end
			--else
			--begin
			--	if @ritenuta_addcom_irpef_acconto_2014 < 0
			--	begin
			--		set @ritenuta_addcom_irpef_saldo_2014 = @ritenuta_addcom_irpef_saldo_2014 + @ritenuta_addcom_irpef_acconto_2014
			--		set @ritenuta_addcom_irpef_acconto_2014 = null
			--	end
			--end
		
	
			--		-- Calcolo della prima rata IRPEF da CAF
			--		DECLARE @tr_primaratacaf int
			--		SELECT @tr_primaratacaf = taxcode FROM tax WHERE taxref = '07_IRPEF_R1'
			
			--		-- La prima rata è data dalla somma della ritenute netta associata ai cedolini con codice 07_IRPEF_R1
			--		SET @zb21primaratairpef_caf = 
			--		ISNULL(
			--			(SELECT SUM(expensetaxofficial.employtax)
			--			FROM #cedolini
			--			JOIN expenselink
			--				ON #cedolini.idexp = expenselink.idparent
			--			JOIN expensetaxofficial
			--				ON expensetaxofficial.idexp = expenselink.idchild
			--			WHERE taxcode = @tr_primaratacaf and expensetaxofficial.stop is null )
			--		,0)

			--		-- Calcolo della seconda rata IRPEF da CAF
			--		DECLARE @tr_secondaratacaf int
			--		SELECT @tr_secondaratacaf = taxcode FROM tax WHERE taxref = '07_IRPEF_R2'
			
			--		-- La seconda rata è data dalla somma della ritenute netta associata ai cedolini con codice 07_IRPEF_R2
			--		SET @zb22secondaratairpef_caf = 
			--		ISNULL(
			--			(SELECT SUM(expensetaxofficial.employtax)
			--			FROM #cedolini
			--			JOIN expenselink
			--				ON #cedolini.idexp = expenselink.idparent
			--			JOIN expensetaxofficial
			--				ON expensetaxofficial.idexp = expenselink.idchild
			--			WHERE taxcode = @tr_secondaratacaf and expensetaxofficial.stop is null)
			--		,0)
			
			--		-- Calcolo della maggiore ritenuta (sempre impostato a zero)
			--		SELECT @zb64maggioreritenuta_MOD  = 0
			--				--CASE WHEN applybrackets = 'N' THEN 0 ELSE null end 
			----					from parasubcontractyear where idcon=@chiave and ayear=@annoredditi
	
			-- Conteggio dei giorni lavorati
			DECLARE @workingdays INT
			SELECT  @workingdays = count(*) from #workdays where worked='S'

			-- Se i giorni lavorati superano l'anno si pongono pari al numero di giorni dell'anno
			-- non è contemplato, a quanto pare, l'anno bisestile
			IF @workingdays>365 
			BEGIN
				SET @workingdays=365
			END

			---- Calcolo delle detrazioni derivanti da oneri detraibili
			---- Si considerano gli oneri associati ai contratti non divenuti CUD per altri e che sono associati 
			---- alla certificazione CUD
			--DECLARE @totale_oneri_detrazione_imposta
			--SET @totale_oneri_detrazione_imposta  =
			--ISNULL(
			--	(SELECT
			--		SUM(
			--			CASE
			--				WHEN ISNULL(abatableexpense.totalamount,0) <=
			--				ISNULL(abatementcode.maximal, ISNULL(abatableexpense.totalamount,0))
			--				THEN ISNULL(abatableexpense.totalamount,0)
			--				ELSE abatementcode.maximal
			--			END - ISNULL(abatementcode.exemption,0)
			--		)
			--	FROM abatableexpense 
			--	JOIN #contratti
			--		ON #contratti.idcon = abatableexpense.idcon
			--	JOIN abatementcode
			--		ON abatableexpense.idabatement = abatementcode.idabatement
			--	WHERE abatableexpense.ayear = @annoredditi
			--		AND abatementcode.ayear=@annoredditi
			--		AND #contratti.padre IS NULL)
			--,0)

			---------------------------------------------------------
			-- Redditi assoggettati a ritenuta a titolo di imposta --
			---------------------------------------------------------
			-- Azzeramento delle prestazioni
			DELETE FROM #ser

			-- Inserimento delle prestazioni associate ai contratti che non sono divenuti CUD per altri
			INSERT INTO #ser (idser, servicecode770, annotation, exemptioncode)
			SELECT DISTINCT parasubcontract.idser, isnull(service.servicecode770,service.codeser),
			motive770service.annotation, motive770service.exemptioncode
			FROM service
			JOIN parasubcontract
				ON service.idser = parasubcontract.idser
			JOIN #contratti
				ON #contratti.idcon = parasubcontract.idcon
			LEFT OUTER JOIN motive770service
				ON service.idser = motive770service.idser
				AND motive770service.ayear = @annoredditi
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
				(SELECT COUNT(*)
				FROM #ser
				JOIN servicetax
					ON servicetax.idser = #ser.idser
				WHERE servicetax.taxcode = @tax_convenzione) = 0
				THEN 'N'
				ELSE 'S'
			END

		--- esistono differenti tipi di esenzione, codificati anche con il tipo prestazione
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
		
		--- La persona ha svolto anche solo una prestazione totalmente esente. Serve per la nota BQ
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
										 AND ISNULL(servicetaxview.codeser,servicetaxview.servicecode770) = '14_DIPENDPUBBLICI'
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
										 AND ISNULL(servicetaxcode.codeser,servicetaxview.servicecode770) = '14_DIPENDPUBBLICI'
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
										 AND isnull(servicetaxview.codeser,servicetaxview.servicecode770) = '14_DIPENDPUBBLICI'
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
									 AND isnull(servicetaxview.codeser,servicetaxview.servicecode770) = '14_DIPENDPUBBLICI')	
	
	
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
										 AND isnull(servicetaxview.codeser,servicetaxview.servicecode770) = '14_DIPENDPUBBLICI'
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
										 AND isnull(servicetaxview.codeser,servicetaxview.servicecode770) = '14_DIPENDPUBBLICI'
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
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S'
			) THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 2 and year(datacompetenza)=@annoredditi
				AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S')  THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 3 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 4 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
				AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 5 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)= 6 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon
			where month(datacompetenza)= 7 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 8 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)= 9 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=10 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon where month(datacompetenza)=11 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
		+ case WHEN exists (SELECT * from #cedolini 
		JOIN #contratti
			ON #contratti.idcon = #cedolini.idcon 
			where month(datacompetenza)=12 and year(datacompetenza)=@annoredditi
			AND #contratti.servicecode770 = '14_DIPENDPUBBLICI'
			AND #contratti.applicaritprevidenziali = 'S') THEN '0' ELSE '1' end
	
	SET @emensTuttiIMesidipendentipubblici = NULL
	IF (@mesiSenzaEmensdipendentipubblici = REPLICATE('0',12))
	BEGIN
		SET @emensTuttiIMesidipendentipubblici = 1
	END
							
	END		
	
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
					
	DELETE FROM #redditialtrisoggetti
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
					AND #contratti.servicecode770 <> '14_DIPENDPUBBLICI'
					)
					
					
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
		
		SET @emensTuttiIMesi = NULL
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
		ISNULL(F.startapplication, @1gen15_XXX),
		ISNULL(F.stopapplication, @31dic15_XXX),
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
			set @diffhand = datediff(m, @starthandicap, dateadd(m, @mese-1, @1gen15_XXX))

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
						minoreDiTreAnni = isnull(minoreDiTreAnni,0) + case WHEN datediff(m, dateadd(m, @mese-1, @1gen15_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 ELSE 0 end,
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
						case WHEN datediff(m, dateadd(m, @mese-1, @1gen15_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 end,
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
								case WHEN datediff(m, dateadd(m, @mese-1, @1gen15_XXX), 
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
						case WHEN datediff(m, dateadd(m, @mese-1, @1gen15_XXX), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 end,
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

		---- Conteggio dei giorni lavorati
		--select @start, @stop, @workingdays,datediff(d,@start, @stop) + 1
		select * from #workdays 
		select * from #contratti
		select * from #cedolini
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
	 
			INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '001', @DB001001)
			INSERT INTO #recordG (progr, quadro, riga, colonna, intero)	  VALUES(@progrCom, 'DB', 1, '002', @DB001002)
			INSERT INTO #recordG (progr, quadro, riga, colonna, intero)   VALUES(@progrCom, 'DB', 1, '006', @DB001006)
			INSERT INTO #recordG (progr, quadro, riga, colonna, data)	  VALUES(@progrCom, 'DB', 1, '008', @DB001008)
			INSERT INTO #recordG (progr, quadro, riga, colonna, data)     VALUES(@progrCom, 'DB', 1, '009', @DB001009)
			INSERT INTO #recordG (progr, quadro, riga, colonna, intero)   VALUES(@progrCom, 'DB', 1, '010', @DB001010)

		END
		
			--select * from #recordG  
   	--------------------------------------------------------------------------------------------
   	---------------------------------- SEZIONE RITENUTE ----------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001011 DECIMAL(19,2) -- Ritenute IRPEF
	DECLARE @DB001012 DECIMAL(19,2)	-- Addizionale regionale all'Irpef
	DECLARE	@DB001014 DECIMAL(19,2)	-- Addizionale regionale 2014 - rapporti cessati. 
	DECLARE	@DB001016 DECIMAL(19,2)	-- Addizionale comunale acconto 2014. 
	DECLARE	@DB001017 DECIMAL(19,2)	-- Addizionale comunale all'Irpef - Saldo 2014
	DECLARE	@DB001018 DECIMAL(19,2)	-- Addizionale comunale all'Irpef - Rapporti cessati 2014
	
	--Campo 14 – Addizionale regionale 2014 rapporti cessati. Campo di nuova istituzione. 
	--Va indicato l’ammontare dell’addizionale regionale all’Irpef 2014 trattenuta nel 2014 
	--dal sostituto in caso di cessazione del rapporto di lavoro nel corso del 2014 
	--già indicato nel precedente campo 12 (Addizionale regionale all'Irpef). Quindi in caso in cui la fine rapporto nell’esercizio 2014 
	--il campo deve essere valorizzato.
	
	SET @DB001011= isnull(@ritenuta_irpef,0)
	SET @DB001012= isnull(@ritenuta_addreg_irpef,0)
	SET @DB001014= isnull(@ritenuta_addreg_irpef_rapporti_cessati,0)
	SET @DB001016= isnull(@ritenuta_addcom_irpef_acconto_2014,0)
	SET @DB001017= isnull(@ritenuta_addcom_irpef_saldo_2014,0)
	SET @DB001018= isnull(@ritenuta_addcom_irpef_saldo_2014_rapporti_cessati,0)
	 
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '011', @DB001011)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '012', @DB001012)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '014', @DB001014)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '016', @DB001016)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '017', @DB001017)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom, 'DB', 1, '018', @DB001018)
	
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
	 
	-- Campi 103, 104, 105, 106, – Detrazioni per famiglie numerose – Vedere se è necessario gestire questi campi 
	-- per il per il 770/2015. A memoria non penso che ci siano stati nel 2014 compensi con questo tipo di detrazioni 
	-- (almeno quattro figli a carico). Ho verificato che non ce ne sono stati
	
	--Già in fase di elaborazione della CU è stato segnalato questo problema che comunque 
	--al momento non poteva avere una soluzione. Per questo Questo è un problema già segnalato nella CU, 
	--penso che noi valorizziamo nei campi 102, 107 e 108 l’importo della detrazione effettivamente operata 
	--e non effettivamente spettante.
	
	SET @DB001101= isnull(@employtaxgross,0)
	SET @DB001102= isnull(@detrazioni_familiari_a_carico,0)
	SET @DB001107= isnull(@detrazioni_per_reddito,0)
	SET @DB001108= isnull(@detrazioni_per_oneri,0)
	SET @DB001113= isnull(@totale_detrazioni,0)
	
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '101', @DB001101)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '102', @DB001102)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '107', @DB001107)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '108', @DB001108)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '113', @DB001113)
	
	--------------------------------------------------------------------------------------------
	----------------------------------- SEZIONE BONUS ------------------------------------------
	--------------------------------------------------------------------------------------------
	---------- NB. Questa sezione va compilata solo per redditi imponibili ai fini IRPEF -------
	---  non per assegnisti e prestazioni esenti , dove mettiamo solo dati previdenziali -------
	--------------------------------------------------------------------------------------------
	
	-- Ho verificato che per il 2014 il bonus non è stato erogato
	DECLARE @DB001119 INT				-- CREDITO BONUS IRPEF - Codice Bonus Vale 1 o 2
	DECLARE @DB001120 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus erogato
	DECLARE @DB001121 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus non erogato
	DECLARE @DB001122 DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus recuperato (Codice Bonus in questo caso varrà 1 in caso di 
										-- recupero parziale, 2 in caso di recupero totale)
	-- Non essendo stato erogato nel 2014 non c'è bisogno di compilare neanche il codice erogato da altri soggetti
	DECLARE @DBXXX123 INT				-- CREDITO BONUS IRPEF altri soggetti - Codice Bonus Vale 1 o 2
	DECLARE @DBXXX124 DECIMAL (19,2)	-- CREDITO BONUS IRPEF altri soggetti - Bonus erogato
	DECLARE @DBXXX125 DECIMAL (19,2)	-- CREDITO BONUS IRPEF altri soggetti - Bonus non erogato
	DECLARE @DBXXX126 DECIMAL (19,2)	-- CREDITO BONUS IRPEF altri soggetti - Bonus recuperato (Codice Bonus in questo caso varrà 1 in caso di 
										-- recupero parziale, 2 in caso di recupero totale)
	DECLARE @DBXXX127 VARCHAR(16)		-- CREDITO BONUS IRPEF EROGATO DA ALTRI SOGGETTI - Codice Fiscale
										
	IF ISNULL(@taxablegross,0) <> 0
	BEGIN
		SET @DB001119= 2 -- non riconosciuto
		SET @DB001120= 0
		SET @DB001121= 0
		
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB', 1, '119', @DB001119)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '120', @DB001120)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '121', @DB001121)
		--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '122', @DB001122)
	END
	
	--------------------------------------------------------------------------------------------
	----------------------------------- ONERI DEDUCIBILI --------------------------------------- 
	--------------------------------------------------------------------------------------------
	DECLARE @DB001161 DECIMAL (19,2)	-- Totale oneri deducibili esclusi dai redditi indicati nei punti 1, 3, 4 e 5
	--DECLARE @DB001162 DECIMAL (19,2)	-- Totale oneri deducibili non esclusi dai redditi indicati nei punti 1, 3, 4 e 5
	--DECLARE @DB001163 DECIMAL (19,2)	-- Contributi versati a enti e casse aventi esclusivamente fini assistenziali dedotti
	--DECLARE @DB001164 DECIMAL (19,2)	-- Contributi versati a enti e casse aventi esclusivamente fini assistenziali non dedotti
	--DECLARE @DB001166 INT				-- Assicurazioni Sanitarie
	
	--SET @DB001161= isnull(@deduzioni_art10,0)
	--SET @DB001162= 0
	--SET @DB001163= 0
	--SET @DB001164= 0
	--SET @DB001166= 0
	
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '161', @DB001161)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '162', @DB001162)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '163', @DB001163)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB001', 1, '164', @DB001164)
	--INSERT INTO #recordG (progr, quadro, riga, colonna, intero)	VALUES(@progrCom, 'DB001', 1, '166', @DB001166)

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
	-- usate. Da completare la query su Cassino
	DECLARE @reddito_esente	 decimal(19,2)
	DECLARE @counter	int
	DECLARE @exemptioncode int
	DECLARE @DB001180 int	-- Redditi Esenti - Codice  -- prevedere una tabella di configurazione delle prestazioni?
	DECLARE @DB001181 decimal(19,2)	-- Redditi Esenti - Ammontare
	-- Sebbene possiamo osservare che la maggiore ritenuta sia stata indicata nei compensi
	-- tuttavia molto probabilmente si tratta di casi in cui non c'è stata esplicita richiesta.
	-- Pertanto non lo scriviamo
	
	DECLARE @DB001191 int	-- Applicazione maggiore ritenuta CB
	
	--SET @DB001191 = (SELECT 
	--CASE
	--	WHEN (SELECT COUNT(*) FROM #contratti WHERE ISNULL(highertax,0) > 0) > 0 THEN '1'
	--	ELSE 0
	--END )
	--SET @DB001191 = 0
	--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero) VALUES(@progrCom, 1, 'DB', 1, '191', @DB001191)
	
	SET @counter = 0
	DECLARE rowcursor_e INSENSITIVE CURSOR FOR
	SELECT  servicecode770, exemptioncode
	FROM    #ser WHERE exemptioncode IS NOT NULL 

	FOR READ ONLY
	OPEN rowcursor_e
	FETCH NEXT FROM rowcursor_e
	INTO	@servicecode770,@exemptioncode 
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		SET @counter  = @counter + 1
		-- Prestazioni degli assegnisti totalmente esenti, no stranieri
		print 'esente'
		SET @reddito_esente =  ISNULL (
			(SELECT SUM(p.feegross) 	FROM	#contratti	 			 
					JOIN 	payroll P ON #contratti.idpayroll = P.idpayroll
					WHERE /*#contratti.padre IS NULL
						AND*/ NOT EXISTS (SELECT * FROM servicetaxview
									   WHERE servicetaxview.idser = #contratti.idser
											 AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
						AND NOT EXISTS(SELECT * FROM payrolltax cr
											JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind in (1,3)	AND geoappliance IS NULL
											WHERE   cr.idpayroll= P.idpayroll)
						--AND #contratti.servicecode770 = @servicecode770
						and #contratti.exemptioncode = @exemptioncode
			),0)

		SET @reddito_esente  = isnull(@reddito_esente,0)

		SET @DB001180 = @exemptioncode					 
		SET @DB001181 = @reddito_esente					 
	 
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)   VALUES(@progrCom,'DB', @counter, '180', @DB001180)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', @counter, '181', @DB001181)
	 
	FETCH NEXT FROM rowcursor_e
	INTO	@servicecode770,@exemptioncode 
	END 
	DEALLOCATE rowcursor_e
	
	--------------------------------------------------------------------------------------------
	-------------- Redditi assoggettati a ritenuta a titolo di imposta ------------------------- 
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001221 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale redditi
	DECLARE @DB001222 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef
	DECLARE @DB001223 DECIMAL (19,2)	-- Redditi assoggettati a ritenuta a titolo di imposta - Totale ritenute irpef sospese
	DECLARE @DB001224 INT				-- Causale
	-- Campo 225 – Redditi. Campo di nuova introduzione. Nel campo 225 deve essere indicato l’importo del reddito, 
	-- già compreso a campo 221, relativo ad ogni singola codifica riportata al precedente campo 224.
	DECLARE @DB001225 DECIMAL (19,2)
	
	SET @DB001221= isnull(@taxablegross_irpef_stranieri,0)
	SET @DB001222= isnull(@ritenuta_irpef_stranieri,0)
	IF (isnull(@taxablegross_irpef_stranieri,0) <>0)
	BEGIN
		SET @DB001224 = 2 -- Dato che noi gestiamo con Easy solo Co.co.co. il codice da mettere è fisso ed è pari a 2
	END
	-- SET @DB001223= 0
	SET @DB001225= isnull(@taxablegross_irpef_stranieri,0)
	
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '221', @DB001221)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '222', @DB001222)
	-- INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '223', @DB001223)
	INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DB', 1, '224', @DB001224)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '225', @DB001225)
	INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DB', 1, '227', @DB001222)
	--select * from #recordG  
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
		
	INSERT INTO #recordG (progr,quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', 1, '301', @DB001301)
	
	DECLARE @cf_altro_sostituto		varchar(16)
	DECLARE @reddito_conguagliato 	decimal(19,2)
	DECLARE @ritenute_irpef			decimal(19,2)
	DECLARE @addizionale_regionale_irpef		 decimal(19,2)
	DECLARE @addizionale_comunale_irpef_acconto  decimal(19,2)
	DECLARE @addizionale_comunale_irpef_saldo    decimal(19,2)

	
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
	
		INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)  VALUES(@progrCom,'DB', @counter, '305', @DB001305)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', @counter, '308', @DB001308)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', @counter, '313', @DB001313)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', @counter, '315', @DB001315)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', @counter, '316', @DB001316)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale) VALUES(@progrCom,'DB', @counter, '317', @DB001317)
	
	FETCH NEXT FROM rowcursor
	INTO	@cf_altro_sostituto,@reddito_conguagliato,@ritenute_irpef,
			@addizionale_regionale_irpef,@addizionale_comunale_irpef_acconto,
			@addizionale_comunale_irpef_saldo 
			END
	DEALLOCATE rowcursor
	 
	
	-------------------------------------------------------------------------------------------------
	---------------------- Dati relativi al coniuge e ai familiari a carico -------------------------
	-------------------------------------------------------------------------------------------------
	-- Si procede all'inserimento dei dati inerenti i familiari all'interno della tabella di output
	-- estraendoli dalle tabelle definite per i familiari a carico
	
	-----------------------------------------------------------
	---------------- LETTURA DATI CONIUGE ---------------------
	-----------------------------------------------------------
	-- DECLARE @DBXXX701 VARCHAR(20)--Casella Coniuge	CB
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
		SELECT @progrCom, 'DB', idconiuge, '701', 1 FROM #coniuge
		
	-- DECLARE @DBXXX702 VARCHAR(16)-- Codice fiscale coniuge CF
	INSERT INTO #recordg (progr,quadro, riga, colonna, stringa) 
		SELECT @progrCom,'DB', idconiuge, '702', 
		codiceFiscaleConiuge FROM #coniuge WHERE  
		codiceFiscaleConiuge <> ''

	-- DECLARE @DBXXX703	INT--Numero mesi a carico	N2
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
	SELECT @progrCom, 'DB', idconiuge, '703', 
	numeroMesiACarico FROM #coniuge
	
	-----------------------------------------------------------
	------------- LETTURA DATI PRIMO FIGLIO -------------------
	-----------------------------------------------------------

	--DECLARE @DBXXX704	VARCHAR(20)--casella primo figlio CB
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom, 'DB', idprimofiglio, '704', 1
		FROM #primofiglio WHERE  casellaPrimoFiglio =  1 AND  casellaDisabile IS  NULL
	
	--DECLARE @DBXXX705	VARCHAR(20)--casella disabile CB
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom, 'DB', idprimofiglio, '705', 1
		FROM #primofiglio WHERE casellaDisabile = 1 AND casellaPrimoFiglio IS NULL

	-- DECLARE @DBXXX706	VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 'DB', idprimofiglio, '706', 
		codiceFiscalePrimoFiglio from #primofiglio 
		where codiceFiscalePrimoFiglio <> ''

	--DECLARE @DBXXX707	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom,'DB', idprimofiglio, '707', 
		numeroMesiACarico  from #primofiglio

	--DECLARE @DBXXX708	INT--Minore di tre anni	N2
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom, 'DB',idprimofiglio, '708', 
		minoreDiTreAnni from #primofiglio

	--DECLARE @DBXXXC09	DECIMAL(19,6)--Percentuale di detrazione spettante	PC
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom, 'DB', idprimofiglio, 'C09', 
		100 * percentualeDiDetrazioneSpettante / numeroMesiACarico 
		from #primofiglio where detrazionePerConiugeACarico <> 'C'

	--DECLARE @DBXXXD09	CHAR(1)--Percentuale di detrazione spettante	AN
	INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
		SELECT @progrCom, 'DB', idprimofiglio, 'D09', detrazionePerConiugeACarico 
		from #primofiglio where detrazionePerConiugeACarico = 'C'
		
	--DECLARE @DBXXX710	CHAR(1)--Detrazione 100% affidamento figli	CB
		--INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
		--SELECT @progrCom, 'DB80' + CONVERT(VARCHAR(3),@idprimofiglio +1), idprimofiglio, '008', 1 
		--from #primofiglio where detrazionePerConiugeACarico = 'C'
	
	-----------------------------------------------------------
	------------- LETTURA DATI ALTRI FIGLI --------------------
	-----------------------------------------------------------	
	-- DECLARE @DBXXX711 INT CB casella figlio   -- 719 727 735 743 751 759
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom,'DB',1, CONVERT(VARCHAR(3), 
		711 + 8*(idaltrofiglio -1) ),1
		FROM #altrofiglio WHERE casellaFiglio = 1  AND  casellaDisabile IS  NULL

	-- DECLARE @DBXXX712 INT CB casella altro familiare
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom, 'DB',1, CONVERT(VARCHAR(3), 
		712 + 8*(idaltrofiglio -1)),  1  
		FROM #altrofiglio 	 
		WHERE casellaAltroFamiliare = 1  AND casellaDisabile IS  NULL
		
	-- DECLARE @DBXXX713 INT CB casella figlio con disabilità
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom, 'DB',1, CONVERT(VARCHAR(3), 
		713 + 8*(idaltrofiglio -1)), 1
		FROM #altrofiglio 
		WHERE casellaDisabile = 1  AND casellaFiglio IS NULL
		
	-- DECLARE @DBXXX714	VARCHAR(16)--Codice fiscale	CF
	INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
		SELECT @progrCom, 'DB', 1, CONVERT(VARCHAR(3), 
		714 + 8*(idaltrofiglio -1)), codiceFiscaleFamiliare
		FROM #altrofiglio

	--DECLARE @DBXXX715	INT--Mesi a carico	N2
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom,'DB', 1,
		CONVERT(VARCHAR(3), 715 + 8*(idaltrofiglio -1)), numeroMesiACarico 
		FROM #altrofiglio

	--DECLARE @DBXXX716	INT--Minore di tre anni	N2
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
		SELECT @progrCom, 'DB', 1,CONVERT(VARCHAR(3), 716 + 8*(idaltrofiglio -1)) , minoreDiTreAnni 
		FROM #altrofiglio where minoreDiTreAnni <> ''
	
	--DECLARE @DBXXXC17	DECIMAL(19,6)--Percentuale di detrazione spettante	PC si può omettee se c'è la percentuale
	INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
		SELECT @progrCom,'DB' , 1, 'C' + CONVERT(VARCHAR(3), 17 + 8*(idaltrofiglio -1)),
		100 * percentualeDiDetrazioneSpettante/numeroMesiACarico 
		FROM #altrofiglio where detrazionePerConiugeACarico <> 'C'

	--DECLARE @DBXXXD17	CHAR(1)--Percentuale di detrazione spettante	AN
	INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
		SELECT @progrCom, 'DB'+ CONVERT(VARCHAR(3),idaltrofiglio+2), 1,
		'D' + CONVERT(VARCHAR(3), 17 + 8*(idaltrofiglio -1)), 'C'  
		FROM #altrofiglio where detrazionePerConiugeACarico = 'C'
		
	--DECLARE @DBXXX718	CHAR(1)--Detrazione 100% affidamento figli	CB
	--INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
	--	SELECT @progrCom, 'DB80' + CONVERT(VARCHAR(3),idaltrofiglio +1), '008', 0 
	--	FROM #altrofiglio where detrazionePerConiugeACarico = 'C'
		
 	 	--fine modulo cococo

	----------------------------------------------------------------------------------------------------------------
	-------- Dati previdenziali ed assistenziali INPS - Sezione 2 - Collab. Coordinate e continuative 47 -----------
	----------------------------------------------------------------------------------------------------------------
	IF
	((SELECT	COUNT(*)
		FROM	#ser
		WHERE 	#ser.servicecode770 <> '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@compensoprev,0) > 0))
	BEGIN
		DECLARE @DCXXX001	VARCHAR(10)		-- Matricola azienda N10
		DECLARE @DCXXX009	DECIMAL (19,2)	-- Compensi corrisposti al collaboratore VP
		DECLARE @DCXXX010	DECIMAL (19,2)	-- Contributi dovuti VP
		DECLARE @DCXXX011	DECIMAL (19,2)	-- Contributi a carico del collaboratore trattenuti VP
		DECLARE @DCXXX012	DECIMAL (19,2)	-- Contributi versati VP
		DECLARE @DCXXX013	INT				-- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DCXXX014	VARCHAR(12)		-- Mesi per i quali è stata presentata la denuncia UniEmens
		
		SET @DCXXX001 = @agencynumber 
		SET @DCXXX009= isnull(@compensoprev,0)
		SET @DCXXX010= isnull(@ritprevdovuta,0)
		SET @DCXXX011= isnull(@ritprevtrattenuta,0)
		SET @DCXXX012= isnull(@ritprevpagata,0)
		SET @DCXXX013= @emensTuttiIMesi
		SET @DCXXX014= @mesiSenzaEmens
		--exec exp_certificazioneunica_g_15 21,1
		-- INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom,'DC', 1, '001', @DCXXX001)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom,'DC', 1, '009', @DCXXX009)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom,'DC', 1, '010', @DCXXX010)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom,'DC', 1, '011', @DCXXX011)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom,'DC', 1, '012', @DCXXX012)
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom,'DC', 1, '013', @DCXXX013)
		INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom,'DC', 1, '014', @DCXXX014)
	END

	------------------------------------------------------------------------------------------------------------------------------
	----------------------------------- Sezione 3 - INPS GESTIONE DIPENDENTI PUBBLICI (EX INPDAP) --------------------------------
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
		DECLARE @DCXXX015	VARCHAR(16)	    -- Codice fiscale Amministrazione	  
		DECLARE @DCXXX016	VARCHAR(10)		-- Progressivo azienda
		DECLARE @DCXXX018	INT				-- Gestione Pensionistica
		DECLARE @DCXXX020	INT				-- Gestione Credito
		DECLARE @DCXXX022	INT				-- Anno di riferimento	
		DECLARE @DCXXX023	DECIMAL (19,2)	-- Totale imponibile pensionistico	
		DECLARE @DCXXX024	DECIMAL (19,2)	-- Totale contributi pensionistici
		DECLARE @DCXXX029	DECIMAL (19,2)	-- Totale imponibile Gestione Credito
		DECLARE @DCXXX030	DECIMAL (19,2)	-- Totale contributo Gestione Credito
		DECLARE @DCXXX033	INT				-- Mesi per i quali è stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DCXXX034	VARCHAR(12)		-- Mesi per i quali è stata presentata la denuncia UniEmens
		
		--if IsNumeric(@codfiscEnte) = 1
		--	SET @DCXXX015 =	convert(int,@codfiscEnte) -- Codice fiscale Amministrazione	  
		SET @DCXXX015 = @codfiscEnte
		SET @DCXXX016 = '00000'   -- Progressivo azienda
		SET @DCXXX018 = 1		  -- Gestione Pensionistica
		SET @DCXXX020 = 9         -- Gestione Credito
		SET @DCXXX022 = @annoredditi   -- Anno di riferimento	
		SET @DCXXX023 = @taxablegross_dipendentipubblici			  -- Totale imponibile pensionistico	
		SET @DCXXX024 = @ritenuta_previdenziale_dipendentipubblici	  -- Totale contributi pensionistici
		SET @DCXXX029 = @taxablegross_fondocredito_dipendentipubblici -- Totale imponibile Gestione Credito
		SET @DCXXX030 = @ritenuta_fondocredito_dipendentipubblici     -- Totale contributo Gestione Credito
		SET @DCXXX033 = @emensTuttiIMesidipendentipubblici
		SET @DCXXX034 = @mesiSenzaEmensdipendentipubblici
	
 		INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom, 'DC', 1, '015', @DCXXX015)
		INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom, 'DC', 1, '016', @DCXXX016)
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DC', 1, '018', @DCXXX018)
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DC', 1, '020', @DCXXX020)
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DC', 1, '022', @DCXXX022)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DC', 1, '023', @DCXXX023)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DC', 1, '024', @DCXXX024)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DC', 1, '029', @DCXXX029)
		INSERT INTO #recordG (progr, quadro, riga, colonna, decimale)	VALUES(@progrCom, 'DC', 1, '030', @DCXXX030)
		INSERT INTO #recordG (progr, quadro, riga, colonna, intero)		VALUES(@progrCom, 'DC', 1, '033', @DCXXX033)
		INSERT INTO #recordG (progr, quadro, riga, colonna, stringa)	VALUES(@progrCom, 'DC', 1, '034', @DCXXX034)
	END 
	------------------------------------------------------------------------------------------------------------------------------
	----------------------------------- Dati assicurativi INAIL ------------------------------------------------------------------
	------------------------------------------------------------------------------------------------------------------------------

	declare @startpayroll smalldatetime
	declare @stoppayroll smalldatetime

	declare @contaprestazioni int
	set @contaprestazioni = 1

	declare @oldstop smalldatetime
	set @oldstop = null

	--	DECLARE @idpayroll int
	DECLARE @patcode varchar(20)
	SELECT pat.patcode, MIN(startpayroll) AS startpayroll, MAX(stoppayroll) AS stoppayroll
	FROM #cedolini
	JOIN parasubcontract
		ON parasubcontract.idcon = #cedolini.idcon
	JOIN pat
		ON pat.idpat = parasubcontract.idpat
	WHERE (inail > 0)
		AND (year(stoppayroll) >= @annoredditi)
	GROUP BY pat.patcode
	ORDER BY startpayroll
	
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
	ORDER BY startpayroll

	open @cursorecedolini
	fetch next from @cursorecedolini into @patcode, @startpayroll, @stoppayroll

	declare @oldstart smalldatetime
	declare @oldpatcode varchar(20)
	if @startpayroll < @1gen15_XXX set @oldstart = @1gen15_XXX ELSE set @oldstart = @startpayroll
	if @stoppayroll > @31dic15_XXX set @oldstop = @31dic15_XXX ELSE set @oldstop = @stoppayroll
 
	-- Inserimento dei dati assicurativi distinti per mese
	WHILE @@fetch_status = 0
	begin
		--Dati assicurativi INAIL
		if @startpayroll < @1gen15_XXX set @startpayroll = @1gen15_XXX
		if @stoppayroll > @31dic15_XXX set @stoppayroll = @31dic15_XXX
	 
 
	-- DCXXX035 Qualifica
	-- DCXXX036 Posizione assicurativa territoriale
 
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DC', @contaPrestazioni, '036',      replicate('0', 11 - len(@patcode)) + @patcode)	-- DCXXX036 Codice PAT
		-- DCXXX037 Data inizio
		INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrCom, 'DC', @contaPrestazioni, '037', @startpayroll)
	-- DCXXX038 Data fine
		INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrCom, 'DC', @contaPrestazioni, '038', @stoppayroll)
	-- DCXXX039 Codice comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'DC', @contaPrestazioni, '039', @codiceComuneEnte)

		set @oldstart = @startpayroll
		set @contaprestazioni = @contaprestazioni + 1
 
		
	set @oldstop = @stoppayroll

	fetch next from @cursorecedolini into @patcode, @startpayroll, @stoppayroll
		
	end
	
 
	-- DA001010 Casi esclusione dalla precompilata
	-- Campo 10 Casi di Esclusione dalla Precompilata:Il presente campo, di nuova istituzione, deve essere compilato per segnalare casi particolari di presentazione della certificazione unica esclusi dall’obbligo della dichiarazione precompilata.
	-- In particolare, a campo 10, deve essere indicato:
	-- il codice 1, nell’ipotesi in cui nella CU siano stati certificati esclusivamente redditi di cui all’art. 50, comma 1, lettere b), e), f), g) relativamente alle indennità percepite dai membri del Parlamento europeo, h) e h-bis);
	-- il codice 2, nell’ipotesi in cui siano stati certificati soltanto dati previdenziali ed assistenziali.
	-- Riguardo al campo 10 per il codice 1 non si ha un modo diretto di valorizzarlo mentre per il codice 2 si. Quindi dobbiamo valorizzare il codice 2 quando si sono certificati soltanto i dati previdenziali e assistenziali.
	--SELECT @DB001001, @DB001101, @DB001161, @DB001301, @DB001221
	--SELECT @DCXXX023, @patcode, @compensoprev 
	IF (
		isnull(@DB001001,0) = 0	   -- @taxablegross    
		AND isnull(@DB001101,0) = 0  -- @employtaxgross  
		AND isnull(@DB001161,0) = 0  -- isnull(@deduzioni_art10,0) 	 
		AND isnull(@DB001301,0) = 0  -- isnull(@totale_redditi_altri_soggetti,0)
		AND isnull(@DB001221,0) = 0  -- isnull(@taxablegross_irpef_stranieri,0) 	
	) 
	AND 
	(
		 isnull(@DCXXX023,0) <> 0			-- @taxablegross_dipendentipubblici	 
		 OR isnull(@compensoprev,0) <> 0    -- Totale imponibile pensionistico
	 )
	BEGIN
		SET 	@DA001010 = 2	
		INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrCom, 'DA', 1, '010', @DA001010)
	END
	------------------------------------------------------------------------------------------------------------------
	------------------------------------ INSERIMENTO DELLE ANNOTAZIONI -----------------------------------------------
	------------------------------------------------------------------------------------------------------------------

	--AI - Informazioni relative al reddito/i certificato/i: tipologia (…), data inizio e data fine per ciascun periodo di lavoro o pensione (…), importo (… ).
	--Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, rapporto a tempo determinato, data inizio e data fine per ciascun periodo di lavoro dal …. Al ….  importo euro …..
	--(Da valorizzare ogni volta che è valorizzato il campo 1 Redditi di lavoro dipendente e assimilati....)
	DECLARE @NN VARCHAR(400)
	DECLARE @contacud int
	SET @contacud = 1
	DECLARE @contacudconvenzione int
	SET @contacudconvenzione = 1

	DECLARE @counter_annotations int
	SET @counter_annotations = 0
	
	DECLARE @ai_inserted char(1)
	SET @ai_inserted = 'N'

	DECLARE @aj_inserted char(1)
	SET @aj_inserted = 'N'
	
	DECLARE @bq_inserted char(1)
	SET @bq_inserted = 'N'

	DECLARE @ec_taxablegross decimal(19,2)
	DECLARE @ec_start datetime
	DECLARE @ec_stop datetime
	DECLARE @ec_idlinkedcon varchar(8)
	DECLARE @text_for_annotation varchar(400)
	--DECLARE @servicecode770 varchar(20)
	--  Il cursore seleziona tutti i contratti la cui prestazione ricade nella certificazione 770
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
		 
				SET @text_for_annotation = (SELECT annotation FROM #ser WHERE servicecode770 = @servicecode770) 
				IF (@text_for_annotation IS NULL) 
				BEGIN
				SET @text_for_annotation = (SELECT  
					CASE 
						WHEN  @servicecode770 = '07_BRS_GEN' 
						THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c) D.P.R. 917/86, '
						WHEN  @servicecode770 IN ('07_COPENOINPS',  '05_COORDM', '16_COORDM_DS','16_COORDM_AS',
										   '05_COORDN', '16_COORDN_DS','16_COORDN_AS',
										   '05_COORDP', '05_COSTCON', '05_CORNOINPS', '05_COORDN_L.326/03', 
										   '08_COSTCON_NOINPS', '10_COSTCONMUT', 
										   'N_VISITINGPROFESSOR', 'M_VISITINGPROFESSOR', '14_COORNM10%IRPEF')
						THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c-bis) D.P.R. 917/86, '
						ELSE 'AI - Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, ' 
					END)
				END
				SELECT @NN = 
				 @text_for_annotation
				 +
				'Rapporto a tempo determinato,  da ' + CONVERT(varchar(16), @ec_start, 105) + ' a ' + CONVERT(varchar(16), @ec_stop, 105) + 
			 +  ' Importo: € ' + CONVERT(varchar(16), @ec_taxablegross)  
		 
			-- Note dipendenti dai CUD
			
			-- [Nota AI] (Questa nota è sicuramente presente almeno per il contratto principale)
			-- 
			IF (@ai_inserted = 'N')
			BEGIN
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
				SET @ai_inserted = 'S'
				SET @counter_annotations = @counter_annotations + 1
			END
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
				--SET @counter_annotations = @counter_annotations + 1
		END
		-----------------------------------------------------------------
		-------------------------- NOTE AJ ------------------------------
		-- "AJ - Redditi totalmente esentati da imposizione in Italia: --
		---------------- indicare Importo del reddito." -----------------
		--  (Quando si usa una prestazione che abbia il flag ------------
		-- sul tipo di prestazione "Per residenti all'estero" -----------
		-- e la prestazione non ha ritenute fiscali associate), ---------
		---------- Indicare l'importo lordo del reddito ----------------- 
		-----------------------------------------------------------------
		IF (@ec_idlinkedcon IS NOT NULL) 
			AND
			(SELECT COUNT(*)
			FROM #ser
			JOIN service
				ON #ser.idser = service.idser)> 0
			AND @straniero_conv = 'S'
			AND ISNULL(@taxablegross_irpef_stranieri,0) = 0 
		BEGIN
			DECLARE @previdenza decimal(19,2)
			SET @previdenza =
			ISNULL(
			(SELECT taxablepension
			FROM parasubcontractsummaryview
			WHERE idcon = @ec_idlinkedcon
			AND ayear = @annoredditi)
			,0)
			
			SET @text_for_annotation = (SELECT annotation FROM #ser WHERE servicecode770 = @servicecode770) 
			IF (@text_for_annotation IS NULL) 
			BEGIN
			SET @text_for_annotation = (SELECT  
				'AJ - Redditi totalmente esentati da imposizione in Italia: ')
			END
			SET @NN =
			@text_for_annotation  
			+ ' Importo: € ' + CONVERT(varchar(16), @previdenza)  
			 
			IF (@aj_inserted = 'N')
			BEGIN
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
				SET @aj_inserted = 'S'
				SET @counter_annotations = @counter_annotations + 1
			END
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			--SET @counter_annotations = @counter_annotations + 1
		END
			 
		-- eliminiamo l'annotazione BQ sulle prestazioni non esenti previdenzialmente, in quanto essa "sporca" la sezione "B Dati fiscali"
		-- pertanto va in conflitto con il campo "Casi esclusione dalla precompilata" provocando il rigetto del flusso
		IF (@ec_idlinkedcon IS NOT NULL) 
		AND
		(SELECT COUNT(*)
		FROM #ser
		JOIN service
			ON #ser.idser = service.idser)> 0
		AND @straniero_conv = 'N'
		AND (
				(@DB001001 = 0
				AND (@prestazione_esente = 'S') --> imponibile IRPEF Italiani 
				AND isnull(@DCXXX023,0) = 0	  --> @taxablegross_dipendentipubblici	 
				AND isnull(@compensoprev,0) = 0   --> Totale imponibile pensionistico
				)
			OR @EsisteAlmenoUnaPrestazioneTotalmenteEsente = 'S'
			)
		BEGIN
			SET @text_for_annotation = (SELECT annotation FROM #ser WHERE servicecode770 = @servicecode770) 
			IF (@text_for_annotation IS NULL) 
			SET @text_for_annotation = (SELECT 'BQ - Redditi totalmente esentati da imposizione')
			SET @NN = @text_for_annotation +  ': € ' + CONVERT(varchar(16),@compensoprev)  
			IF (@bq_inserted = 'N')
			BEGIN
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
				SET @bq_inserted = 'S'
			END
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			SET @counter_annotations = @counter_annotations + 1
		END
			
		FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon,@servicecode770

		END
		
		CLOSE #cud_crs
		DEALLOCATE #cud_crs
		-- Detrazione per Reddito da Lavoro Dipendente ragguagliata al periodo di lavoro
		--CODICE AN
		--Per rapporti di lavoro a tempo determinato ovvero a tempo indeterminato di durata inferiore all’anno 
		--(assunzione/ cessazione in corso d’anno), in riferimento ai quali il sostituto d’imposta ha ragguagliato la detrazione minima al periodo di lavoro.
	 
		IF (@workingdays < 365)  AND (@taxablegross<> 0) AND (@DB001107 <> 0) 
		BEGIN
			SET @NN =
			'AN - La detrazione minima è stata ragguagliata al periodo di lavoro.' + 
			' Il percipiente può fruire della detrazione per l''intero anno in sede' +
			' di dichiarazione dei redditi, semprechè non sia stata già attribuita' +
			' da un altro datore di lavoro e risulti effettivamente spettante.'
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			SET @counter_annotations = @counter_annotations + 1
		END
		
		IF (@workingdays < 365)  AND (@taxablegross<> 0) AND (@DB001102 <> 0) 
		BEGIN
			SET @NN =
			'AC - Le detrazioni per carichi di famiglia sono state ragguagliate al periodo di lavoro.'
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			SET @counter_annotations = @counter_annotations + 1
		END
		DECLARE @deduction  varchar(200)
		
	/*DECLARE @deduction_amount DECIMAL(19,2)
	DECLARE rowcursor_ded_art10  INSENSITIVE CURSOR FOR
	SELECT  deductioncode.description, cr.deduction
    FROM payrolltax cr  
    JOIN #cedolini
     ON #cedolini.idcedolino = cr.idpayroll
         JOIN #contratti
     ON #contratti.idcon = #cedolini.idcon   
    JOIN tax
     ON cr.taxcode=tax.taxcode
    JOIN payrolldeduction
		on payrolldeduction.idpayroll = cr.idpayroll
     JOIN deductioncode ON ayear = @annoredditi 
      AND deductioncode.iddeduction = payrolldeduction.iddeduction
    WHERE taxkind = 1
     AND geoappliance = 'R'
    AND #contratti.padre IS NULL
    AND NOT EXISTS
     (SELECT * FROM servicetaxview
     WHERE servicetaxview.idser = #contratti.idser
      AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))

	
	FOR READ ONLY
	OPEN rowcursor_ded_art10
	FETCH NEXT FROM rowcursor_ded_art10
	INTO	@deduction,@deduction_amount 
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		SET   @NN =
			'AR -  ' + @deduction + ' : € ' + CONVERT(varchar(16),@deduction_amount) + 
			' da non considerare al fine dell''eventuale dichiarazione dei redditi ' +
			' in quanto già incluso nelle operazioni di conguaglio.'
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
		--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
		--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
		--		VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
				SET @counter_annotations = @counter_annotations + 1
	FETCH NEXT FROM rowcursor_ded_art10
	INTO	@deduction,@deduction_amount 
			END
	DEALLOCATE rowcursor_ded_art10
	*/
		--  CODICE AX
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
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			SET @counter_annotations = @counter_annotations + 1
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
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			SET @counter_annotations = @counter_annotations + 1
		END
		
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
		    INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			SET @counter_annotations = @counter_annotations + 1
	END	
		
		
	IF 
	((@DCXXX011 <> 0)  -- @ritprevtrattenuta
	 OR 
     (@DCXXX012 <> 0)) --@ritprevpagata
     AND @DB001001 = 0
     AND @straniero_conv = 'N'
     AND @prestazione_esente = 'N'
	BEGIN
		SET @NN =
		'ZZ - Le ritenute INPS trattenute ai sensi della Legge 335/95 art.2/c.26 e Legge 449/97 art.59/c.16' +
		' sono state regolarmente versate all''INPS: ' +
		' ritenute a carico percipiente: € ' + CONVERT(varchar(16), @ritprevtrattenuta)  +
		' e ritenute a carico ente: € ' + CONVERT(varchar(16), @ritprevamministrazione)
 
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
		VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			SET @counter_annotations = @counter_annotations + 1
	END
	
		-- CODICE GH
		-- In caso di cessazione del rapporto di lavoro durante l’anno, qualora le operazioni di conguaglio 
		-- sono state operate con riferimento a un domicilio fiscale diverso dal 1° gennaio del periodo d’imposta 
		-- di riferimento, con il codice GH, di nuova istituzione, il sostituto informerà il contribuente 
		-- della necessità di presentare la dichiarazione dei redditi per la corretta liquidazione delle imposte 
		-- dovute.
		
		DELETE FROM #comuniaddcom
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
				
		DECLARE @cod_catastale_01_01_15 varchar(4)
		SET @cod_catastale_01_01_15 = @DA001025

		IF (@cod_catastale_01_01_15 IS NOT NULL) 
		AND EXISTS (SELECT codcatastale FROM #comuniaddcom WHERE ISNULL(codcatastale,'') <> ISNULL(@cod_catastale_01_01_15,''))
	 
		BEGIN
			SET @NN =
			'GH - Le operazioni di conguaglio sono state effettuate con riferimento 
			 ad un domicilio fiscale individuato sulla base della precedente normativa, 
			 il contribuente deve procedere alla presentazione della dichiarazione dei redditi 
			 per la corretta liquidazione delle imposte dovute.'
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
				VALUES(@progrCom, 'DB', 1, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,1,2))
			--------------- il software di compilazione SOGEI non legge il testo delle note ma solo il codice ---------------
			--INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
			--	VALUES(@progrCom, 'DB', 2, convert(varchar(3), 601 + @counter_annotations) , SUBSTRING(@NN,5,400))
			SET @counter_annotations = @counter_annotations + 1
		END

		set @progrCom = @progrCom + 1
		-- azzeramento variabili!
		SET @addizionale_comunale_irpef_acconto = NULL
		SET @addizionale_comunale_irpef_saldo = NULL
		SET @addizionale_regionale_irpef = NULL
		SET @appliancePercentage = NULL
		SET @cod_catastale_01_01_15 = NULL
		SET @compensoprev = NULL
		SET @contacud = NULL
		SET @contacudconvenzione = NULL
		SET @contaprestazioni = NULL
		SET @counter = NULL
		SET @counter_annotations = NULL
		SET @DA001001 = NULL
		SET @DA001002 = NULL
		SET @DA001003 = NULL
		SET @DA001004 = NULL
		SET @DA001005 = NULL
		SET @DA001006 = NULL
		SET @DA001007 = NULL
		SET @DA001008 = NULL
		SET @DA001009 = NULL
		SET @DA001010 = NULL
		SET @DA001020 = NULL
		SET @DA001021 = NULL
		SET @DA001022 = NULL
		SET @DA001023 = NULL
		SET @DA001024 = NULL
		SET @DA001025 = NULL
		SET @DA001026 = NULL
		SET @DA001040 = NULL
		SET @DA001041 = NULL
		SET @DA001042 = NULL
		SET @DA001043 = NULL
		SET @DB001001 = NULL
		SET @DB001002 = NULL
		SET @DB001006 = NULL
		SET @DB001008 = NULL
		SET @DB001009 = NULL
		SET @DB001010 = NULL
		SET @DB001011 = NULL
		SET @DB001012 = NULL
		SET @DB001014 = NULL
		SET @DB001016 = NULL
		SET @DB001017 = NULL
		SET @DB001018 = NULL
		SET @DB001101 = NULL
		SET @DB001102 = NULL
		SET @DB001107 = NULL
		SET @DB001108 = NULL
		SET @DB001113 = NULL
		SET @DB001119 = NULL
		SET @DB001120 = NULL
		SET @DB001121 = NULL
		SET @DB001122 = NULL
		SET @DB001161 = NULL
		SET @DB001180 = NULL
		SET @DB001181 = NULL
		SET @DB001221 = NULL
		SET @DB001222 = NULL
		SET @DB001223 = NULL
		SET @DB001224 = NULL
		SET @DB001225 = NULL
		SET @DB001301 = NULL
		SET @DB001305 = NULL
		SET @DB001308 = NULL
		SET @DB001313 = NULL
		SET @DB001315 = NULL
		SET @DB001316 = NULL
		SET @DB001317 = NULL
		SET @DBXXX123 = NULL
		SET @DBXXX124 = NULL
		SET @DBXXX125 = NULL
		SET @DBXXX126 = NULL 	
		SET @DBXXX127 = NULL
		SET @DCXXX001 = NULL
		SET @DCXXX009 = NULL
		SET @DCXXX010 = NULL
		SET @DCXXX011 = NULL
		SET @DCXXX012 = NULL
		SET @DCXXX013 = NULL
		SET @DCXXX014 = NULL
		SET @DCXXX015 = NULL
		SET @DCXXX016 = NULL
		SET @DCXXX018 = NULL
		SET @DCXXX020 = NULL
		SET @DCXXX022 = NULL
		SET @DCXXX023 = NULL
		SET @DCXXX024 = NULL
		SET @DCXXX029 = NULL
		SET @DCXXX030 = NULL
		SET @DCXXX033 = NULL
		SET @DCXXX034 = NULL
		SET @deduzioni_art10 = NULL
		SET @detrazionePerConiugeACarico= NULL
		SET @detrazioni_familiari_a_carico= NULL
		SET @detrazioni_per_oneri= NULL
		SET @detrazioni_per_reddito= NULL
		SET @diffhand= NULL
		SET @ec_idlinkedcon= NULL
		SET @ec_start= NULL
		SET @ec_start= NULL
		SET @ec_stop= NULL
		SET @ec_taxablegross= NULL
		SET @emensTuttiIMesi= NULL
		SET @emensTuttiIMesidipendentipubblici= NULL
		SET @employtaxgross= NULL
		SET @exemptioncode= NULL
		SET @figlimaggiori= NULL
		SET @flagcfestero= NULL
		SET @giorno= NULL
		SET @idaffinity= NULL
		SET @idAltroFiglio= NULL
		SET @idconiuge= NULL
		SET @idcontract= NULL
		SET @idfamily= NULL
		SET @idPrimoFiglio= NULL
		SET @mese= NULL
		SET @mesefine= NULL
		SET @meseinizio= NULL
		SET @mesiSenzaEmens= NULL
		SET @mesiSenzaEmensdipendentipubblici= NULL
		SET @NN= NULL
		SET @oldstart= NULL
		SET @oldstop=NULL
		SET @onerisostenutiinaltricontratti= NULL
		SET @patcode= NULL
		SET @prestazione_esente= NULL
		SET @previdenza= NULL
		SET @reddito_conguagliato= NULL
		SET @reddito_esente= NULL
		SET @registryspecialcategory= NULL
		SET @ritenuta_addcom_irpef_acconto_2014= NULL
		SET @ritenuta_addcom_irpef_saldo_2014= NULL
		SET @ritenuta_addcom_irpef_saldo_2014_rapporti_cessati= NULL
		SET @ritenuta_addreg_irpef= NULL
		SET @ritenuta_addreg_irpef_rapporti_cessati= NULL
		SET @ritenuta_fondocredito_dipendentipubblici= NULL
		SET @ritenuta_irpef= NULL
		SET @ritenuta_irpef_stranieri= NULL
		SET @ritenuta_previdenziale_dipendentipubblici= NULL
		SET @ritenuta_previdenziale_dipendentipubblici_amm= NULL
		SET @ritenuta_previdenziale_dipendentipubblici_dip= NULL
		SET @ritenute_irpef= NULL
		SET @ritprevamministrazione= NULL
		SET @ritprevdovuta= NULL
		SET @ritprevpagata= NULL
		SET @ritprevtrattenuta= NULL
		SET @start= NULL
		SET @startapplication= NULL
		SET @starthandicap= NULL
		SET @startpayroll= NULL
		SET @stop= NULL
		SET @stopapplication= NULL
		SET @stoppayroll= NULL
		SET @straniero_conv= NULL
		SET @tax_convenzione= NULL
		SET @taxablegross= NULL
		SET @taxablegross_dipendentipubblici= NULL
		SET @taxablegross_fondocredito_dipendentipubblici= NULL
		SET @taxablegross_irpef_stranieri= NULL
		SET @text_for_annotation= NULL
		SET @totale_detrazioni= NULL
		SET @totale_redditi_altri_soggetti= NULL
		SET @workingdays = NULL
		
		fetch next from @cursorecomunicazione into @chiave,@cognome ,@registry_cf
	end
	CLOSE @cursorecomunicazione
	DEALLOCATE @cursorecomunicazione
	
	SELECT 
		progr, quadro, riga, colonna, stringa, 
		intero , 
		decimale, 
		data
	FROM #recordg
	where (intero is not null or stringa is not null or data is not null or isnull(decimale,0)<>0)
	order by progr, quadro,riga, colonna
	END
	
	GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

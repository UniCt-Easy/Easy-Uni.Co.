if exists (SELECT * from dbo.sysobjects where id = object_id(N'[exp_modello770_pat_17]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_pat_17]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  PROCEDURE [exp_modello770_pat_17] 
AS BEGIN
-- setuser'amm'
-- exec exp_modello770_pat_17  

	declare @annodichiarazione int
	set @annodichiarazione = 2017

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1 
	
	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annoredditi


	declare @31dic16 datetime
	set @31dic16 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})
	
	-- Ricordarsi di cambiare ogni anno l'anno delle date
	declare @1gen16_XXX datetime
	set @1gen16_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @13gen16_XXX datetime
	set @13gen16_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-13'})

	declare @31dic16_XXX datetime
	set @31dic16_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen17_XXX datetime
	set @1gen17_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-01'})

	declare @13gen17_XXX datetime
	set @13gen17_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

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
		ORDER BY registry.cf 

--SELECT * FROM #modulocococo
	 
		
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
		idreg int,
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
		exemptioncode int,
		patcode varchar(20)
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
	 
		SELECT @codiceComuneEnte = value from geo_city_agency 
			where idcode=1 and idcity=@idcityente and idagency=1

			
		INSERT INTO #contratti
			(idreg,idcon, taxablepension, inpsinail, deduction,
			 fiscaltaxablegross, idpayroll, start, stop, stopcontract, certificatekind, idser,
			 servicecode770, highertax,
			 applicaritprevidenziali, exemptioncode,patcode)
		SELECT
		co.idreg,
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
			isnull(service.servicecode770,service.codeser),
			im.highertax,
			CASE
				WHEN EXISTS (SELECT * FROM servicetaxview ST  
							  WHERE ST.idser = service.idser
								AND ST.taxkind = 3) THEN 'S'
				ELSE 'N'
			END,
		motive770service.exemptioncode,
		pat.patcode
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
		JOIN #modulocococo on co.idreg = #modulocococo.idreg
		JOIN pat
		ON pat.idpat = co.idpat
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
		

 
		UPDATE #contratti
		SET padre = exhibitedcud.idcon
		FROM exhibitedcud
		WHERE exhibitedcud.idlinkedcon = #contratti.idcon
		AND exhibitedcud.fiscalyear = @annoredditi
 
	 	--------------------------------------------------------------------------------------------
	 	------------------------------------- PARTE A-----------------------------------------------
		------- Dati relativi al dipendente, pensionato o altro percettore delle somme -------------
		--------------------------------------------------------------------------------------------
		-- Valorizzazione delle informazioni relative al percipiente
		
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
			where ( YEAR(paymenttransmission.transmissiondate)=@annoredditi  or (year(paymenttransmission.transmissiondate) = @annodichiarazione and 
			paymenttransmission.transmissiondate <= @13gen17_XXX))
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
			paymenttransmission.transmissiondate <= @13gen17_XXX))
			AND expensepayroll.idexp=#cedolini.idexp
	     )
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
	------------------------------------------------------------------------------------------------------------------------------
	----------------------------------- Dati assicurativi INAIL ------------------------------------------------------------------
	------------------------------------------------------------------------------------------------------------------------------
 
 --select * from #contratti
 --select * from #cedolini
	print 'si'
	SELECT 
		registry.title,
		registry.cf,
	    registry.p_iva,
		registry.surname,
		registry.forename,
		registry.birthdate,
		registry.gender,
		#contratti.patcode, MIN(startpayroll) AS startpayroll, MAX(stoppayroll) AS stoppayroll
	FROM #cedolini
	JOIN #contratti
		ON #contratti.idcon = #cedolini.idcon
	JOIN registry on
		#contratti.idreg =  registry.idreg
	WHERE (inail > 0)
		AND (year(stoppayroll) >= @annoredditi)
	GROUP BY #contratti.patcode,registry.title,
		registry.cf,
	    registry.p_iva,
		registry.surname,
		registry.forename,
		registry.birthdate,
		registry.gender,
	    registry.idcity,
		registry.idnation
	ORDER BY registry.cf,startpayroll,stoppayroll
END
 
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
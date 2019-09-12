if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_16_i]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_16_i]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--exec exp_modello770_16_i
CREATE PROCEDURE [exp_modello770_16_i]
AS BEGIN

-------------------------------------------------------------------------------------------------------
----------------------------------------- RECORD DI TIPO "I": Dati relativi ---------------------------
----------------------------------al prospetto SY del mod. 770/2016 semplificato ----------------------
-------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------
----------------------------------------- PARTE  POSIZIONALE ------------------------------------------
-------------------------------------------------------------------------------------------------------


-- RECORD DI TIPO "I": Dati relativi al prospetto SY del mod. 770/2015 semplificato

-- codice fiscale soggetto dichiarante (codice fiscale ente)
-- progressivo modulo SY, parte da 1 e viene incrementato ogni volta di 1
-- Tipo operazione, dovrebbe essere fisso 'I'
-- Tutti i caratteri alfabetici devono essere impostati in maiuscolo.
-------------------------------------------------------------------------------------------------------
----------------------------------------- PARTE NON POSIZIONALE ---------------------------------------
-------------------------------------------------------------------------------------------------------
-------- Prospetto SY - Somme liquidate a seguito di procedure di pignoramento presso terzi da --------
----------------------------------------- art.25 del D.L.n.78/2010 ------------------------------------
-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------
-- Sezione II - Riservata al soggetto erogatore delle somme --
-------------------------------------------------------------

-----------------------------------------------------------
-- CAMPI POSIZIONALI (da carattere 1890 a carattere 1900)--
-----------------------------------------------------------

	DECLARE @codfiscEnte varchar(16)
	declare @idcityEnte int
	SELECT @codfiscEnte = cf, @idcityEnte = idcity FROM license

	-- Fine Seconda Sezione dichiarativa

	-- Tabella di output che contiene le informazioni del record I (che successivamente verranno elaborate dal form del 770)
	CREATE TABLE #recordI
	(
		progr int,
		quadro varchar(5),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		decimale decimal(19,2),
		data datetime
	)
	
 

	--INIZIO PRELIEVO DATI DA expensetax
	-- Tabella che contiene i movimenti finanziari di prestazioni pagate mediante il modulo dipendenti
	CREATE TABLE #expense
	(
		idexp int,
		idreg int,
		idreg_distrained int,
		cf_reg varchar(16),
		cf_reg_distrained varchar(16),
		taxdescription varchar(50),
		expensedescription varchar(150),	
		commondetail char(1),
		taxablenet decimal(19,2),
		employtax decimal(19,2),
		admintax decimal(19,2),
		grossamount decimal (19,2),
		transmissiondate datetime,
		service varchar(50),
		module varchar(15),
		servicecode770 varchar(20),
		npay int
	)

	-- Fase massima di spesa
	declare @annodichiarazione int
	set @annodichiarazione = 2016

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1

	declare @31dic15 datetime
	set @31dic15 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})
	
	declare @expensephase int
	select @expensephase=expensephase from config where ayear = @annodichiarazione-1
	-- PIGNORAMENTI CON APPLICAZIONE DELLA RITENUTA
	INSERT INTO #expense
	(
		idexp,
		idreg,
		idreg_distrained,
		cf_reg,
		cf_reg_distrained,
		taxablenet,
		employtax, 
		admintax, 
		grossamount,--Importo Lordo del Pagamento
		transmissiondate,
		service,
		servicecode770,
		module,
		npay
	)
	SELECT
		T.idexp,
		T.idreg,
		T.idreg_distrained,
		isnull(R.cf,R.p_iva),
		isnull(R_DISTR.cf,R_DISTR.p_iva),
		SUM(T.taxablenet),
		SUM(T.employtax),
		SUM(T.admintax), 
		CASE 
		WHEN service.module in ('DIPENDENTE') THEN
		(ISNULL(expenseyear.amount,0) + 
		 ISNULL(
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensevar v
			WHERE idexp=T.idexp					
				AND (ISNULL(v.autokind,0)<>4)					
			),0)		
		)
		ELSE NULL
		END,
		paymenttransmission.transmissiondate,
		service.description,
		isnull(service.servicecode770, service.codeser),
		service.module,
		payment.npay
FROM
	(SELECT
		SUM(ISNULL(E.taxablenet,0)) AS taxablenet,
		SUM(ISNULL(E.employtax,0)) AS employtax,
		SUM(ISNULL(E.admintax,0)) AS admintax,
		E.idexp as idexp,
		expense.idreg AS idreg,
		W.idreg_distrained AS idreg_distrained ,
		E.description as taxdescription,
		expense.description as expensedescription,
		expenselast.idser,
		expenselast.kpay
	FROM expensetaxofficialview AS E
	JOIN expense 
		ON expense.idexp = E.idexp
	JOIN expenselast
		ON expenselast.idexp = expense.idexp 
	JOIN service
		ON service.idser = expenselast.idser
	JOIN wageaddition W
		ON W.idser =  service.idser
	JOIN expensewageaddition EW
		ON EW.ycon = W.ycon
		AND EW.ncon = W.ncon
	JOIN expenselink EL
		ON EL.idparent = EW.idexp 
		AND EL.idchild =  E.idexp
	WHERE expense.ymov = @annoredditi  
		AND E.stop IS NULL
	GROUP BY expense.idreg,E.idexp,expenselast.idser,W.idreg_distrained,
		E.description ,expense.description,
        expenselast.kpay
                ) AS T
JOIN expensetotal
	ON T.idexp = expensetotal.idexp  
JOIN expenseyear
	ON T.idexp = expenseyear.idexp
JOIN service
	ON T.idser = service.idser  
JOIN payment 
	ON T.kpay = payment.kpay  
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
	JOIN registry R
		ON R.idreg = T.idreg 
	JOIN registry R_DISTR
		ON R_DISTR.idreg = T.idreg_distrained
WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and isnull(service.servicecode770,service.codeser) = '11_PIGNORA'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
	AND  R.idregistryclass <> '22'  -- IL CREDITORE PIGNORATIZIO NON PUO' ESSERE PERSONA FISICA
GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay, paymenttransmission.transmissiondate,	
	isnull(R.cf,R.p_iva),isnull(R_DISTR.cf,R_DISTR.p_iva), isnull(service.servicecode770,service.codeser) ,  R.idregistryclass	
-- FINE PRELIEVO DATI DA expensetax

-- PIGNORAMENTI ESENTI DA RITENUTA
INSERT INTO #expense
	(
		idexp,
		idreg,
		idreg_distrained,
		cf_reg,
		cf_reg_distrained,
		taxablenet,
		employtax, 
		admintax, 
		grossamount,--Importo Lordo del Pagamento
		transmissiondate,
		service,
		servicecode770,
		module,
		npay
	)
	SELECT
		T.idexp,
		T.idreg,
		T.idreg_distrained,
		isnull(R.cf,R.p_iva),
		isnull(R_DISTR.cf,R_DISTR.p_iva),
		0,
		0,
		0, 
		CASE 
		WHEN service.module in ('DIPENDENTE') THEN
		(ISNULL(expenseyear.amount,0) + 
		 ISNULL(
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensevar v
			WHERE idexp=T.idexp					
				AND (ISNULL(v.autokind,0)<>4)					
			),0)		
		)
		ELSE NULL
		END,
		paymenttransmission.transmissiondate,
		service.description,
		isnull(service.servicecode770, service.codeser),
		service.module,
		payment.npay
FROM
	(SELECT
		E.idexp as idexp,
		E.idreg as idreg,
		W.idreg_distrained as idreg_distrained,
		expenselast.idser as idser,
		expenselast.kpay as kpay
	FROM expense  E
	JOIN expenselast
		ON expenselast.idexp = E.idexp 
	JOIN service
		ON service.idser = expenselast.idser
	JOIN wageaddition W
		ON W.idser =  service.idser
	JOIN expensewageaddition EW
		ON EW.ycon = W.ycon
		AND EW.ncon = W.ncon
	JOIN expenselink EL
		ON EL.idparent = EW.idexp 
		AND EL.idchild =  E.idexp
	WHERE E.ymov = @annoredditi  
	GROUP BY E.idreg,E.idexp,expenselast.idser,W.idreg_distrained,
                expenselast.kpay) AS T
JOIN expensetotal
	ON T.idexp = expensetotal.idexp  
JOIN expenseyear
	ON T.idexp = expenseyear.idexp
JOIN service
	ON T.idser = service.idser  
JOIN payment 
	ON T.kpay = payment.kpay  
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
JOIN registry R
		ON R.idreg = T.idreg 
	JOIN registry R_DISTR
		ON R_DISTR.idreg = T.idreg_distrained

WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and ISNULL(service.servicecode770,service.codeser) = '11_PIGNORA_ESE'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
	AND  R.idregistryclass <> '22'  -- IL CREDITORE PIGNORATIZIO NON PUO' ESSERE PERSONA FISICA
GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay,paymenttransmission.transmissiondate,
	isnull(R.cf,R.p_iva),	isnull(R_DISTR.cf,R_DISTR.p_iva), ISNULL(service.servicecode770,service.codeser),  R.idregistryclass 	

-- Ciclo con valorizzazione del progressivo modulo, ogni cinque pagamenti bisogna incrementare il progressivo modulo

DECLARE @contaPagamenti int
SET @contaPagamenti = 0

DECLARE @progrModulo int
SET @progrModulo = 0

DECLARE @cf_reg varchar(16)
DECLARE @cf_reg_distrained varchar(16)
DECLARE @taxablenet decimal(19,2)
DECLARE @employtax decimal(19,2)
DECLARE @admintax decimal(19,2)
DECLARE @grossamount decimal(19,2)
DECLARE @servicecode770 varchar(20)

DECLARE cursoreexpense CURSOR FOR 
SELECT 
		#expense.cf_reg,
		#expense.cf_reg_distrained,
		isnull(sum(#expense.taxablenet),0),
		isnull(sum(#expense.employtax),0), 
		isnull(sum(#expense.admintax),0),
		isnull(sum(#expense.grossamount),0),--Importo Lordo del Pagamento
		#expense.servicecode770 
FROM #expense
GROUP BY #expense.cf_reg,
		#expense.cf_reg_distrained,#expense.servicecode770

--DECLARE @progrModulo int
SET @progrModulo = 0

SELECT @codfiscEnte = cf FROM license
	DECLARE @cfsoftwarehouse varchar(16)
	SET @cfsoftwarehouse = '02890460781' --- TEMPO SRL
	
OPEN cursoreexpense
FETCH NEXT FROM cursoreexpense
INTO @cf_reg, @cf_reg_distrained, @taxablenet, @employtax,@admintax,@grossamount,@servicecode770
	WHILE @@FETCH_STATUS = 0
		BEGIN
		IF ((@contaPagamenti%5) = 0)  
			BEGIN
				-- INIZIO PARTE POSIZIONALE
					SET  @progrModulo = @progrModulo + 1
					--1 Tipo record
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '01', 'I')
					--2 Codice fiscale del soggetto dichiarante
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '02', @codfiscEnte)
					--3 Progressivo modulo
						INSERT INTO #recordI (progr, quadro, riga, colonna, intero)  VALUES(@progrModulo, 'HRI', 1, '03', @progrModulo)
					--8 Identificativo del produttore del software (codice fiscale)
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '08', @cfsoftwarehouse)

					-- INIZIO PARTE NON POSIZIONALE
					 
		    END
		
		/*
		SY007	001	2012-05-22 11:04:33.337	assistenza	Codice fiscale debitore principale 
		SY007	002	2012-05-22 11:04:33.337	assistenza	Codice fiscale creditore pignoratizio 
		SY007	003	2012-05-22 11:04:33.337	assistenza	Somme erogate 
		*/
		--- attenzione! per i seguenti importi deve essere effettuato il troncamento della parte decimale e non l'arrotondamento
		INSERT INTO #recordI(progr,quadro, riga, colonna,stringa ) VALUES (@progrModulo, 'SY' +'0' +RIGHT(REPLICATE('0', 2) + convert(varchar(2),@contaPagamenti%5 + 7),2) ,1, '001',@cf_reg_distrained)
		INSERT INTO #recordI(progr,quadro, riga, colonna,stringa ) VALUES (@progrModulo, 'SY' +'0' +RIGHT(REPLICATE('0', 2) + convert(varchar(2),@contaPagamenti%5 + 7),2),1, '002',@cf_reg)
		IF @servicecode770 = '11_PIGNORA_ESE' 
			BEGIN
				INSERT INTO #recordI(progr,quadro, riga, colonna,decimale ) VALUES (@progrModulo, 'SY' + '0' +RIGHT(REPLICATE('0', 2) + convert(varchar(2),@contaPagamenti%5 + 7),2),1, '003',@grossamount)
			END
		ELSE
			BEGIN
				INSERT INTO #recordI(progr,quadro, riga, colonna,decimale ) VALUES (@progrModulo, +RIGHT(REPLICATE('0', 2) + convert(varchar(2),@contaPagamenti%5 + 7),2),1, '003',@taxablenet)
			END
		SET @contaPagamenti = @contaPagamenti + 1
		FETCH NEXT FROM cursoreexpense
		INTO @cf_reg, @cf_reg_distrained, @taxablenet, @employtax,@admintax,@grossamount,@servicecode770
	END
CLOSE cursoreexpense
DEALLOCATE cursoreexpense

--insert into #recordI 
--exec [exp_modello770_16_i_stranieri]


--		progr int,
--		quadro varchar(3),
--		riga int,
--		colonna varchar(3),
--		stringa varchar(100),
--		intero int,
--		decimale decimal(19,2),
--		data datetime


--2016	SY016	001	Cognome/Denominazione	AN
	--2016	SY016	002	Nome	AN
	--2016	SY016	003	Sesso	AN
	--2016	SY016	004	Data di Nascita	DT
	--2016	SY016	005	Codice di identificazione  fiscale estero	AN
	--2016	SY016	006	Località di residenza estera	AN
	--2016	SY016	007	Via e numero civico	AN
	--2016	SY016	008	Codice stato estero	N3
	--2016	SY016	009	Causale	AN
	--2016	SY016	010	Ammontare lordo corrisposto	VP
	--2016	SY016	011	Somme non soggette a  ritenuta per regime  convenzionale	VP
	--2016	SY016	012	Altre somme non soggette a ritenuta	VP
	--2016	SY016	013	Imponibile	VP
	--2016	SY016	014	Ritenute a titolo d''imposta	VP
	--2016	SY016	015	Ritenute sospese	VP
	CREATE TABLE #annualpayedrefund_Stranieri
	(
		payed_lastyear decimal(19,2),
		payed_lastyear_P decimal(19,2),
		payed_total decimal(19,2),
		payed_total_P decimal(19,2),
		payed_prevyears decimal(19,2),
		F_refund_lastyear decimal(19,2),
		P_refund_lastyear decimal(19,2),
		F_refund_total decimal(19,2),
		P_refund_total decimal(19,2),
		F_refund_residual decimal(19,2),
		P_refund_residual decimal(19,2),
		exemptionquota_applied decimal(19,2)
	)

-- Il quadro H è per il lavoro autonomo
	CREATE TABLE #recI_StranieriNonArrot
	(
		progr int,
		quadro varchar(10),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		decimfisc decimal(19,2),
		decimprev decimal(19,2),
		data datetime,
		intero int,
		causale_riferimento varchar(10)
	)
 
-- Sezione dichiarativa	
 
	DECLARE @idreg int
	DECLARE @cf varchar(16)
	DECLARE @cognomePercipiente varchar(50)
	DECLARE @nomePercipiente varchar(30)
	DECLARE @gender char(1)
	DECLARE @birthdate datetime
	DECLARE @birthplace varchar(61)
	DECLARE @birthprovince varchar(2)
	DECLARE @foreigncf varchar(25)
	declare @categorieparticolari varchar(2)
	--
	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #expense2015_stranieri
	(
		idexp int,
		idreg int,
		idser int,
		employtaxamount decimal(19,2),
		motive770 varchar(10)
	)


	INSERT INTO #expense2015_stranieri
		(
			idexp,--1
			idreg,--2
			idser,--3
			employtaxamount--6
		)
		SELECT
			expense.idexp,--1
			expense.idreg,--2
			expenselast.idser,--3
			ISNULL((SELECT SUM(employtax) FROM expensetaxofficial 
				WHERE expensetaxofficial.idexp = expense.idexp 
				AND expensetaxofficial.stop IS NULL),0)
		FROM expense
		join expenselast on expense.idexp = expenselast.idexp
		join payment 
			on payment.kpay = expenselast.kpay
		join paymenttransmission
			on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		JOIN service on service.idser=expenselast.idser
		JOIN registry ON expense.idreg = registry.idreg
		WHERE 	registry.idregistryclass <> '10' and registry.idregistryclass <> '24'

			--AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg)
			AND year(paymenttransmission.transmissiondate)=@annoredditi
			AND service.rec770kind = 'H'
			AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp)
			+ ISNULL(
				(SELECT SUM(amount) FROM expensevar
				WHERE expensevar.idexp = expense.idexp
				-- AND expensevar.yvar <= @annoredditi  superfluo poiché expense di ultima fase
				AND ISNULL(autokind,0) <> 4)
			,0)) > 0
			and (select count(*) from expensetaxofficial 
			      where expensetaxofficial.idexp=expense.idexp
			      AND   expensetaxofficial.stop IS NULL) > 0
			AND (registry.cf IS NULL) AND (registry.foreigncf IS  NOT NULL) 
 

	update #expense2015_stranieri set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #expense2015_stranieri.idser
		AND motive770service.ayear = @annodichiarazione-1

		--SELECT DISTINCT  #expense2015_stranieri.idreg, surname, registry.foreigncf ,idexp
		--FROM #expense2015_stranieri
		--join registry on registry.idreg = #expense2015_stranieri.idreg
		--order by registry.foreigncf 

 
	declare @cognome varchar(60)
	declare @codice_fiscale varchar(20)
	DECLARE registry_crs CURSOR FOR 
		SELECT DISTINCT #expense2015_stranieri.idreg, surname, registry.foreigncf 
		FROM #expense2015_stranieri
		join registry on registry.idreg = #expense2015_stranieri.idreg
		order by registry.foreigncf 
	OPEN registry_crs
 
	DECLARE @progrPercStraniero int
	SET @progrPercStraniero = 0  ---- il percipiente considerato
	FETCH NEXT FROM registry_crs into   @idreg, @cognome,@codice_fiscale
	
	declare @idcitynascita int
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		print  @idreg
		print  @cognome
		print  @codice_fiscale
		set @foreigncf=null
		set @cognomePercipiente=null
		set @nomePercipiente=null
		set @gender=null
		set @birthdate=null
		set @birthplace=null
		set @birthprovince=null
		set @categorieparticolari = null

		SELECT
			@birthplace =  geo_nation.title,
			@foreigncf = registry.foreigncf,
			@cognomePercipiente = coalesce(registry.surname, registry.title),
			@nomePercipiente = registry.forename,
			@gender = registry.gender,
			@birthdate = registry.birthdate,
			@idcitynascita= registry.idcity,
			@categorieparticolari = idspecialcategory770
			FROM registry 		
			LEFT OUTER JOIN geo_nation ON registry.idnation = geo_nation.idnation
			LEFT OUTER JOIN  registryspecialcategory770
				ON registry.idreg = registryspecialcategory770.idreg
				AND  registryspecialcategory770.ayear = @annoredditi
			WHERE registry.idreg = @idreg


		
		if (@idcitynascita is not null)
		BEGIN
			while (select newcity from geo_city where idcity=@idcitynascita) is not null
			BEGIN
				select @idcitynascita=newcity from geo_city where idcity=@idcitynascita 
			END

			--sezione di impostazione vecchio comune poiché quello del 770 non è aggiornato, DA RIMUOVERE nel 2010!!
			SELECT
				@birthplace = geo_city.title,
				@birthprovince =  geo_country.province 
				FROM geo_city 
				LEFT OUTER JOIN geo_country ON geo_city.idcountry = geo_country.idcountry
				WHERE geo_city.idcity=@idcitynascita
		END
		SELECT @codfiscEnte = cf FROM license
		
		DECLARE @provincia varchar(4)
		DECLARE @codiceRegione varchar(20)
		DECLARE @codiceNazione varchar(20)
		DECLARE @location varchar(160)
		DECLARE @address varchar(160)

		set @location=null
		set @provincia=null
		set @codiceRegione=null
		set @location=null
		set @address=null

		declare @stand int
		select  @stand = idaddress from address where codeaddress = '07_SW_DEF'

		declare @domfi int
		select  @domfi = idaddress from address where codeaddress = '07_SW_DOM'

		declare @idcitydom int
		set @idcitydom=null

		SELECT TOP 1 
			@idcitydom = registryaddress.idcity,
			@location = coalesce( geo_nation.title, registryaddress.location),
			@codiceNazione = isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end),
			@address = registryaddress.address
			FROM registryaddress 
			LEFT OUTER JOIN geo_nation
				ON registryaddress.idnation = geo_nation.idnation
			LEFT OUTER JOIN geo_nation_agency
				ON geo_nation.idnation = geo_nation_agency.idnation
				AND geo_nation_agency.idagency = 5
				AND geo_nation_agency.idcode = 1
			WHERE registryaddress.idreg = @idreg
				AND registryaddress.start <= @31dic15
				AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic15)
			ORDER BY
			CASE idaddresskind
				WHEN @stand THEN 1
				WHEN @domfi THEN 2
				ELSE 3
			END


		if (@idcitydom is not null)
		BEGIN
			while (select newcity from geo_city where idcity=@idcitydom) is not null
			BEGIN
				select @idcitydom=newcity from geo_city where idcity=@idcitydom 
			END

			SELECT
			@location = geo_city.title, 
			@provincia = geo_country.province,
			@codiceRegione = geo_country_agency.value
			FROM geo_city
			LEFT OUTER JOIN geo_country
				ON geo_country.idcountry = geo_city.idcountry
			LEFT OUTER JOIN geo_country_agency
				ON geo_country.idcountry = geo_country_agency.idcountry
				AND geo_country_agency.idagency = 5
				AND geo_country_agency.idcode = 1
			WHERE geo_city.idcity=@idcitydom


		END

		
			
		DECLARE @locationestera varchar(160)
		DECLARE @addressestero varchar(160)
		DECLARE @tmpidcity int


		set @locationestera = null
		set @addressestero = null
		IF (@codiceNazione is not null)
		BEGIN
			set @locationestera = @location
			set @addressestero = @address

			set @location=null
			set @provincia=null
			set @codiceRegione=null
			set @address=null
			set @tmpidcity=null
			--Mi ricavo il domicilio fiscale italiano
			SELECT TOP 1 
				@tmpidcity = geo_city.idcity,
				@location =  registryaddress.location,
				@address = registryaddress.address
				FROM registryaddress 
				LEFT OUTER JOIN geo_city
					ON registryaddress.idcity = geo_city.idcity
				WHERE registryaddress.idreg = @idreg
					AND registryaddress.start <= @31dic15
					AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic15)
					AND idaddresskind = @domfi


			if (@tmpidcity is not null)
			BEGIN
				while (select newcity from geo_city where idcity=@tmpidcity) is not null
				BEGIN
					select @tmpidcity=newcity from geo_city where idcity=@tmpidcity 
				END

				SELECT 
					@location =  geo_city.title,
					@provincia = geo_country.province		
					FROM  geo_city					
					LEFT OUTER JOIN geo_country
						ON geo_country.idcountry = geo_city.idcountry
					LEFT OUTER JOIN geo_country_agency
						ON geo_country.idcountry = geo_country_agency.idcountry
						AND geo_country_agency.idagency = 5
						AND geo_country_agency.idcode = 1
					WHERE geo_city.idcity=@tmpidcity
						
			END
		END
 
	--- 'SY0' + convert(varchar(2),@contaPagamenti%5 + 16
	IF (@codiceNazione is not null)

	BEGIN
		SET @progrPercStraniero =  @progrPercStraniero +1
	--SY016	001	Cognome/Denominazione	AN
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrPercStraniero,'SY016' , 1, '001', @cognomePercipiente)
	--SY016	002	Nome	AN
 		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrPercStraniero, 'SY016', 1, '002', @nomePercipiente)
	--SY016	003	Sesso	AN
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrPercStraniero, 'SY016', 1, '003', @gender)
	--SY016	004	Data di Nascita	DT
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, data)    VALUES(@progrPercStraniero, 'SY016', 1, '004', @birthdate)
	--SY016	005	Codice di identificazione  fiscale estero	AN
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa)    VALUES(@progrPercStraniero, 'SY016', 1, '005', @foreigncf)
	--SY016	006	Località di residenza estera	AN
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrPercStraniero, 'SY016', 1, '006', @locationestera)
	--SY016	007	Via e numero civico	AN
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrPercStraniero, 'SY016', 1, '007', @addressestero)
	--SY016	008	Codice stato estero	N3
		INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, intero) VALUES(@progrPercStraniero, 'SY016', 1, '008',  CONVERT(int,@codiceNazione))

		--select * from #recI_StranieriNonArrot
		DECLARE @employtaxamount decimal(19,2)
		DECLARE @SommeNonSoggetteARitenutaPerRegimeConvenzionale decimal(19,2)
		DECLARE @AltreSommeNonSoggetteARitenuta decimal(19,2)
		DECLARE @ammontarelordocorrisposto decimal(19,2)
		DECLARE @imponibile decimal(19,2)
		DECLARE @idexp int
		DECLARE @idser int
		DECLARE @taxcodefiscale int
		DECLARE @ritIRPEF decimal(19,2)
		DECLARE @ritprevidenzialeamm decimal(19,2)
		DECLARE @ritprevidenzialedip decimal(19,2)
		DECLARE @causale char(1)
		--SELECT 
		--		#expense2015_stranieri.employtaxamount,
		--		#expense2015_stranieri.idexp,
		--		#expense2015_stranieri.idser,
		--		#expense2015_stranieri.motive770
		--	FROM #expense2015_stranieri
		--	join expenselink 
		--		on expenselink.idchild = #expense2015_stranieri.idexp
		--		and nlevel = @expensephase
		--	left outer join expenseprofservice
		--		on expenselink.idparent = expenseprofservice.idexp
		--	WHERE #expense2015_stranieri.idreg=@idreg 
		--		and isnull(movkind,0) <> 2

		DECLARE cursoreexpense CURSOR FOR 
			SELECT 
				#expense2015_stranieri.employtaxamount,
				#expense2015_stranieri.idexp,
				#expense2015_stranieri.idser,
				#expense2015_stranieri.motive770
			FROM #expense2015_stranieri
			join expenselink 
				on expenselink.idchild = #expense2015_stranieri.idexp
				and nlevel = @expensephase
			left outer join expenseprofservice
				on expenselink.idparent = expenseprofservice.idexp
			WHERE #expense2015_stranieri.idreg=@idreg 
				and isnull(movkind,0) <> 2

		OPEN cursoreexpense
		FETCH NEXT FROM cursoreexpense
			INTO @employtaxamount, @idexp, @idser, @causale
	
		DECLARE @contaPrestazioni int
		SET @contaPrestazioni = 1

	
		WHILE @@FETCH_STATUS = 0
		BEGIN
			print @employtaxamount
		print @idexp 
		print @idser 
		print @causale

			SELECT @taxcodefiscale = expensetax.taxcode
				FROM expensetax
				JOIN tax
					ON tax.taxcode = expensetax.taxcode
				WHERE expensetax.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')= 'N'--IS NULL
					

			SELECT @ritIRPEF= ISNULL(SUM(expensetaxofficial.employtax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')='N'-- IS NULL
					AND expensetaxofficial.stop IS NULL

			SELECT  @ritprevidenzialedip = isnull(SUM(expensetaxofficial.employtax),0),
				@ritprevidenzialeamm = isnull(SUM(expensetaxofficial.admintax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
				AND tax.taxkind = 3
				AND expensetaxofficial.stop IS NULL
 
	-- Ammontare lordo corrisposto = Imponibile Lordo SUM (feegross) di quel percipiente.
	set @ammontarelordocorrisposto=0
	
	DECLARE @spesededucibilifis decimal(19,2)
	DECLARE @imponibilereale decimal(19,2)	
	DECLARE @impon_spesa decimal(19,2)
	DECLARE @impon_contratto decimal(19,2)
	declare @quota_contratto float
	set @quota_contratto=1

	DECLARE @ycon int
	DECLARE @ncon int
	SET @ycon = null
	SET @ncon = null

	DECLARE @ypro int
	DECLARE @npro int
	SET @ypro = null
	SET @npro = null


	SELECT @ycon = ycon, @ncon = ncon
		FROM casualcontract C
		WHERE EXISTS(select * from expensecasualcontract EC
				join expenselink EL on EC.idexp=EL.idparent						
				where EL.idchild=@idexp
					AND C.ycon=EC.ycon and C.ncon=EC.ncon
			)

	IF (@ycon is not null)  -- si tratta di un contratto occasionale
	BEGIN
		DELETE FROM #annualpayedrefund_Stranieri
		INSERT INTO #annualpayedrefund_Stranieri (		
			payed_lastyear,
			payed_lastyear_P,
			payed_total,
			payed_total_P,
			payed_prevyears ,
			F_refund_lastyear,
			P_refund_lastyear,
			F_refund_total,
			P_refund_total,
			F_refund_residual,
			P_refund_residual,
			exemptionquota_applied 
		)
		EXEC compute_casualcontract @annoredditi,@ycon,@ncon

			SET @imponibilereale = 
				ISNULL( (SELECT payed_lastyear  from #annualpayedrefund_Stranieri),0)

			SELECT @ammontarelordocorrisposto = 

			ISNULL(
				(SELECT amount 
					FROM expenseyear where idexp=@idexp)				
				,0) +
			ISNULL(
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expensevar v
				WHERE idexp=@idexp					
					AND (ISNULL(v.autokind,0)<>4)					
				)
				,0)
			
			

			IF EXISTS (SELECT * 
				FROM pettycashoperationcasualcontract 
					WHERE pettycashoperationcasualcontract.ycon = @ycon
					AND pettycashoperationcasualcontract.ncon = @ncon )
			BEGIN
				SET @ammontarelordocorrisposto = @imponibilereale
				
			END
			
			set @quota_contratto =  @ammontarelordocorrisposto/@imponibilereale 

	END
		
	ELSE
	BEGIN
		SELECT @ypro = ycon, @npro = ncon
		FROM profservice  C
		WHERE EXISTS(select * from expenseprofservice EC
				join expenselink EL on EC.idexp=EL.idparent						
				where EL.idchild=@idexp
					AND C.ycon=EC.ycon and C.ncon=EC.ncon)
		IF (@ypro is not null)  -- si tratta di un contratto professionale
		BEGIN
		print  @idexp
			SELECT @spesededucibilifis= SUM(amount) from profservicerefund PR
				join profrefund P on PR.idlinkedrefund=P.idlinkedrefund
				WHERE P.flagfiscaldeduction='S' AND
					PR.ycon=@ypro and PR.ncon=@npro
					
				SELECT @imponibilereale =	  
					ISNULL( (SELECT SUM(convert(decimal(19,2),ROUND(taxablenet*isnull(taxabledenominator,1)/isnull(taxablenumerator,1),2)))
					from profservicetax	 
					JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1
				 AND ISNULL(taxablenumerator,0) <> 0),0)
				 
				 +   
				   ISNULL((SELECT SUM(convert(decimal(19,2),taxablenet ))
					from profservicetax	 
					JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1
				AND  ISNULL(taxablenumerator,0) = 0),0)
				 
		 
				
			-----------------------------------------------------------------------	
			-- IMPONIBILE DELLA SPESA ---------------------------------------------
			-----------------------------------------------------------------------
			select  @impon_spesa = SUM(ET.taxablegross) from expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 	
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
			-----------------------------------------------------------------------
			-----------------------------------------------------------------------
			select  @impon_contratto = taxablegross from profservicetax	
				JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1		
			SET     @quota_contratto=isnull(@impon_spesa,0)/isnull(@impon_contratto,0)
			
			SELECT  @ammontarelordocorrisposto = 
				ROUND(@quota_contratto*(isnull(@spesededucibilifis,0)+isnull(@imponibilereale,0) ),2)

		END
		ELSE
		BEGIN --MOV. DI SPESA
			SELECT @ammontarelordocorrisposto = 
				MAX(ET.taxablegross)
				FROM expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
		END
	END
		
	set @ammontarelordocorrisposto= isnull(@ammontarelordocorrisposto,0)
		
--  Somme non soggette a ritenuta per regime convenzionale
-- leggere il feegross delle prestazioni che hanno la ritenuta IRPEF STRANIERI con convenzione. Tali prestazioni hanno ritenuta a zero
	SET @SommeNonSoggetteARitenutaPerRegimeConvenzionale=0
	SELECT @SommeNonSoggetteARitenutaPerRegimeConvenzionale = ISNULL(SUM(taxablenet),0)
		FROM expensetaxofficial 
		JOIN tax 
			ON tax.taxcode = expensetaxofficial.taxcode
		WHERE expensetaxofficial.idexp = @idexp 
			AND tax.taxkind = 1
			AND taxref ='07_IRPEF_FC'
			AND expensetaxofficial.stop IS NULL
	
---  Imponibile Lordo SUM (feegross) - Imponibile Netto (SUM(taxablenet) da expensetax where (taxkind=1 ossia fiscali)
	set @AltreSommeNonSoggetteARitenuta=0
	SET @AltreSommeNonSoggetteARitenuta = 
					@ammontarelordocorrisposto
					- ISNULL((SELECT SUM(taxablenet) --somma imponibili netti ove la rit fiscale non è zero esclusi stranieri conv.
							FROM expensetaxofficial
				              		join tax
								ON tax.taxcode = expensetaxofficial.taxcode
							where expensetaxofficial.idexp = @idexp
							AND taxkind = 1
							AND employtax<>0
							-- considero le ritenute diverse dalla IRPEF STRANIERI IN CONVENZIONE
							AND taxref <>'07_IRPEF_FC'
							AND expensetaxofficial.stop is null
					),0)
					-- RITENUTA IPREF STRANIERI IN CONVENZIONE, è necessario prenderle a parte poiché per esse la ritenuta è zero
					- @SommeNonSoggetteARitenutaPerRegimeConvenzionale
					

	SET @imponibile = @ammontarelordocorrisposto - @SommeNonSoggetteARitenutaPerRegimeConvenzionale-@AltreSommeNonSoggetteARitenuta

	--SY016	009	Causale	AN
	INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, stringa,causale_riferimento) VALUES(@progrPercStraniero,'SY016' , @contaPrestazioni, '009', @causale,@causale)
	--SY016	010	Ammontare lordo corrisposto	VP
	INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, decimfisc,causale_riferimento) VALUES(@progrPercStraniero,'SY016' , @contaPrestazioni, '010', @ammontarelordocorrisposto,@causale)
	--SY016	011	Somme non soggette a  ritenuta per regime  convenzionale	VP
	INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, decimfisc,causale_riferimento) VALUES(@progrPercStraniero,'SY016' , @contaPrestazioni, '011', @SommeNonSoggetteARitenutaPerRegimeConvenzionale,@causale)
		--SY016	012	Altre somme non soggette a ritenuta	VP
	INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, decimfisc,causale_riferimento) VALUES(@progrPercStraniero,'SY016' , @contaPrestazioni, '012', @AltreSommeNonSoggetteARitenuta,@causale)
	--SY016	013	Imponibile	VP
	INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, decimfisc,causale_riferimento) VALUES(@progrPercStraniero,'SY016' , @contaPrestazioni, '013', @imponibile,@causale)
	--SY016	014	Ritenute a titolo d''imposta	VP
		--select * from #recI_StranieriNonArrot
	if (@idser in (select  service.idser from service join servicetax ON servicetax.idser=service.idser
				join tax on servicetax.taxcode=tax.taxcode
				where  tax.taxref in ('08_IRPEF_FOC','07_IRPEF_FO') 
			) 
		)
	BEGIN
			INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, decimfisc,causale_riferimento) VALUES(@progrPercStraniero,'SY016', @contaPrestazioni, '014', @ritIRPEF,@causale)
	END
	--SY016	015	Ritenute sospese	VP
	-- INSERT INTO #recI_StranieriNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrModulo,'SY016' , @contaPrestazioni, '015', 0)
		
	SET @contaPrestazioni = @contaPrestazioni + 1
			print '	FETCH NEXT FROM cursoreexpense'
			FETCH NEXT FROM cursoreexpense
			INTO @employtaxamount, @idexp, @idser, @causale
		END
		CLOSE cursoreexpense
		DEALLOCATE cursoreexpense
		END

		 

		FETCH NEXT FROM registry_crs into  @idreg, @cognome,@codice_fiscale
		END
	  
	
	CLOSE registry_crs
 
	DEALLOCATE registry_crs

 --select * from #recI_StranieriNonArrot
	
	--2016	SY016	001	Cognome/Denominazione	AN
	--2016	SY016	002	Nome	AN
	--2016	SY016	003	Sesso	AN
	--2016	SY016	004	Data di Nascita	DT
	--2016	SY016	005	Codice di identificazione  fiscale estero	AN
	--2016	SY016	006	Località di residenza estera	AN
	--2016	SY016	007	Via e numero civico	AN
	--2016	SY016	008	Codice stato estero	N3
	--2016	SY016	009	Causale	AN
	--2016	SY016	010	Ammontare lordo corrisposto	VP
	--2016	SY016	011	Somme non soggette a  ritenuta per regime  convenzionale	VP
	--2016	SY016	012	Altre somme non soggette a ritenuta	VP
	--2016	SY016	013	Imponibile	VP
	--2016	SY016	014	Ritenute a titolo d''imposta	VP
	--2016	SY016	015	Ritenute sospese	VP
	--select * from #recI_StranieriNonArrot


	declare @progr int
	declare @riga int
	declare @causale_cur varchar(10)

	DECLARE @contaPrestazioniStranieri int
	SET @contaPrestazioniStranieri = 0


	declare @cursore cursor
	
	set @progr = 1
	while @progr <= @progrPercStraniero
	
	BEGIN
 
		--- CICLO SULLA CAUSALE, BISOGNA TOTALIZZARE GLI IMPORTI E COPIARE LE ALTRE INFO
		set @cursore = cursor for 
			select distinct stringa
			from #recI_StranieriNonArrot 
			where progr = @progr and quadro='SY016' and colonna = '009'
			
		open @cursore
	
		fetch next from @cursore into @causale_cur
		while @@fetch_status = 0 
		begin
				
				if (@contaPrestazioniStranieri%5 = 0)
				begin
					SET @progrModulo = @progrModulo + 1
					--1 Tipo record
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '01', 'I')
					--2 Codice fiscale del soggetto dichiarante
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '02', @codfiscEnte)
					--3 Progressivo modulo
						INSERT INTO #recordI (progr, quadro, riga, colonna, intero)  VALUES(@progrModulo, 'HRI', 1, '03', @progrModulo)
					--8 Identificativo del produttore del software (codice fiscale)
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '08', @cfsoftwarehouse)

					-- INIZIO PARTE NON POSIZIONALE
					
				END
				-- dati anagrafici percipiente estero
				insert into #recordI (progr, quadro, riga, colonna, stringa, intero, data)
				SELECT  @progrModulo, 'SY0' + convert(varchar(2),@contaPrestazioniStranieri%5 + 16), 1, colonna, stringa,intero, data
				FROM #recI_StranieriNonArrot 
				where progr = @progr and quadro='SY016' and riga = 1 and  colonna IN ( '001','002','003','004','005','006','007','008' ) 
				AND  (stringa is not null or data is not null or intero is not null) AND #recI_StranieriNonArrot.causale_riferimento is null   
				
				-- inserisco la causale
				insert into #recordI (progr, quadro, riga, colonna, stringa)
					SELECT  @progrModulo, 'SY0' + convert(varchar(2),@contaPrestazioniStranieri%5 + 16), 1, '009', @causale_cur
				-- inseirsco i dati fiscali totalizzati per percipiente e causale
				insert into #recordI (progr, quadro, riga, colonna, decimale)
					select @progrModulo, 'SY0' + convert(varchar(2),@contaPrestazioniStranieri%5 + 16), 1, #recI_StranieriNonArrot.colonna, sum(#recI_StranieriNonArrot.decimfisc)
					from #recI_StranieriNonArrot 
					where progr = @progr and quadro='SY016' and #recI_StranieriNonArrot.causale_riferimento = @causale_cur
					and isnull(#recI_StranieriNonArrot.decimfisc,0) <> 0
					group by #recI_StranieriNonArrot.quadro, #recI_StranieriNonArrot.colonna,  #recI_StranieriNonArrot.causale_riferimento
					having ( sum(#recI_StranieriNonArrot.decimfisc)) <> 0
					
			 set @contaPrestazioniStranieri = @contaPrestazioniStranieri +1
			fetch next from @cursore into @causale_cur
		end

		set @progr = @progr + 1
	end


SELECT * FROM #recordI 


DROP TABLE #annualpayedrefund_Stranieri
DROP TABLE #recordI
DROP TABLE #recI_StranieriNonArrot
DROP TABLE #expense2015_stranieri
DROP TABLE #expense

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
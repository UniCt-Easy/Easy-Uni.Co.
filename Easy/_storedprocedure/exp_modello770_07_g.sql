
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_07_g]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_07_g]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [exp_modello770_07_g] (@modello varchar(10))
AS BEGIN
	create table #cudpresentati (
		idcon varchar(8),
		idexhibitedcud int,
		idlinkedcon varchar(8),
		fiscalyear int,
		taxablegross dec(19,2)
	)

	insert into #cudpresentati (idcon, idexhibitedcud, idlinkedcon, fiscalyear, taxablegross)
		select exhibitedcud.idcon, idexhibitedcud, idlinkedcon, fiscalyear, taxablegross
		from exhibitedcud
		join parasubcontract collegato on collegato.idcon = exhibitedcud.idlinkedcon
		join parasubcontract corrente on corrente.idcon = exhibitedcud.idcon
		join service prest_collegato on prest_collegato.idser = collegato.idser
		join service prest_corrente on prest_corrente.idser = corrente.idser
		where @modello='cud' and isnull(prest_corrente.certificatekind,'') = 'U' and isnull(prest_collegato.certificatekind,'') = 'U'
			or @modello='770' and isnull(prest_corrente.rec770kind,'') = 'G' and isnull(prest_collegato.rec770kind,'') = 'G'


	-- ipotesi fondamentale: Gestione del solo modulo PARASUBORDINATI poichè è l'unica tipologia di reddito a cui si riferisce il CUD
	CREATE TABLE #modulocococo
	(
		idpayroll int,
		idreg int, -- Codice del creditore/debitore
		idcon varchar(8)
	)

-- Inserimento modulo COCOCO (contabilizzazione del payroll)
	INSERT INTO #modulocococo
	(
		idreg,
		idpayroll,
		idcon
	)			-- inserisco per il momento solo i dati relativi alle rit. fiscali dei soli CEDOLINI di CONGUAGLIO
	SELECT			-- perchè ho bisogno di prendere i dati conguagliati. C'è un problema derivante dal conguaglio in presenza
		co.idreg, -- di un cud presentato: Non c'è modo di capire se il cud presentato è un precedente contratto o altro
		ce.idpayroll,		-- Questo implica che gli imponibili (LE RITENUTE SONO OK) non possono essere tenuti in considerazione
		ce.idcon		-- per la sommatoria che si farà in seguito per calcolare i redditi
		FROM  payroll ce 
			JOIN parasubcontract co ON co.idcon = ce.idcon
	                join parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = 2006
			join service on service.idser = co.idser
		WHERE ce.flagbalance = 'S'
			and ce.fiscalyear=2006
			AND ce.disbursementdate is not null
			and not exists (select idlinkedcon from #cudpresentati where idlinkedcon=ce.idcon)
			and (@modello='cud' and service.certificatekind='U' or @modello='770' and service.rec770kind='G')


	declare
		@idreg int,
		@denominazione varchar(50),
		@p_iva varchar(15),
		@idcitynascita int,
		@idnationnascita int,
		@flagcfestero char,
		@start06 datetime,
		@idaddresskind06 int,
		@start07 datetime,
		@idaddresskind07 varchar(6),
		@a1cf varchar(20),
		@a2cognome varchar(50),
		@a3nome varchar(50),
		@a4gender char,
		@a5birthdate datetime,
		@a6comuneostatonascita varchar(50),
		@a7provNascita varchar(2),
		@a11comune31dic varchar(50),--cambiato da 10 in 11
		@a12prov31dic varchar(2),--cambiato da 11 a 12
		@a13codiceComune31dic varchar(10),--cambiato da 12 a 13
		@a14comune1gen varchar(50),
		@a15prov1gen varchar(2),
		@a16codiceComune1gen varchar(10),
		@wb1RedditoDedArt11 decimal(19,2), --Redditi per i quali è possibile fruire della intera deduzione di cui all’art.11 del TUIR
		 -- Questi redditi sono quelli già dedotti art.10 e quindi sono 
		@wb3workingdays int,
		@wb5ritIRPEF decimal(19,2),
		@wb6add_reg decimal(19,2),
		@wb7add_com decimal(19,2),
		@wb7accontoaddcom decimal(19,2),
		@wB17notaxarea decimal(19,2),		-- Deduzione per la progressività dell’imposizione (art. 11 del TUIR)
		@wb18notaxfamilyarea decimal(19,2),	-- Deduzione per coniuge e familiari a carico (art. 12, cc. 1 e 2 del TUIR)
		@wb19ImponibileIrpef decimal(19,2), 
		@wb20ImpostaLorda decimal(19,2), 
		@wb21detrazionefiscale decimal(19,2),
		@wb26deductionart10 decimal(19,2),
		@wb27oneridetraibili decimal(19,2),
		@wb35maggioreritenuta varchar(10),
		@wb36NonApplicareNoTax varchar(10),
		@wb40altriredditi decimal(19,2),
		@wb45totaleredditiconguagliato decimal(19,2),
		@wb47cudcodfisc varchar(16), 
		@wb50cudimpfisclordo decimal(19,2), 
		@wb51cudirpef decimal(19,2), 
		@wb52cudirpefsosp decimal(19,2), 
		@wb53cudaddreg decimal(19,2), 
		@wb54cudaddregsosp decimal(19,2), 
		@wb55cudaddcom decimal(19,2), 
		@wb56cudaddcomsosp decimal(19,2),
		@wc12compensoprev decimal(19,2),
		@wc13ritprevdovuta decimal(19,2),
		@wc14ritprevtrattenuta decimal(19,2),
		@wc15ritprevpagata decimal(19,2),
		@wc16emensTuttiIMesi int,
		@wc17mesiSenzaEmens varchar(12),
		@wc80patcode varchar(10),
		@wc81start datetime,
		@wc82stop datetime,
		@zb1RedditoDedArt11 decimal(19,2), --Redditi per i quali è possibile fruire della intera deduzione di cui all’art.11 del TUIR
		 -- Questi redditi sono quelli già dedotti art.10 e quindi sono 
		@zb3workingdays int,
		@zb5ritIRPEF decimal(19,2),
		@zb6add_reg decimal(19,2),
		@zb7add_com decimal(19,2),
		@zb7accontoaddcom decimal(19,2),
		@zB17notaxarea decimal(19,2),		-- Deduzione per la progressività dell’imposizione (art. 11 del TUIR)
		@zb18notaxfamilyarea decimal(19,2),	-- Deduzione per coniuge e familiari a carico (art. 12, cc. 1 e 2 del TUIR)
		@zb19ImponibileIrpef decimal(19,2), 
		@zb20ImpostaLorda decimal(19,2), 
		@zb21detrazionefiscale decimal(19,2),
		@zb26deductionart10 decimal(19,2),
		@zb27oneridetraibili decimal(19,2),
		@zb35maggioreritenuta varchar(10),
		@zb36NonApplicareNoTax varchar(10),
		@zb40altriredditi decimal(19,2),
		@zb45totaleredditiconguagliato decimal(19,2),
		@zb47cudcodfisc varchar(16), 
		@zb50cudimpfisclordo decimal(19,2), 
		@zb51cudirpef decimal(19,2), 
		@zb52cudirpefsosp decimal(19,2), 
		@zb53cudaddreg decimal(19,2), 
		@zb54cudaddregsosp decimal(19,2), 
		@zb55cudaddcom decimal(19,2), 
		@zb56cudaddcomsosp decimal(19,2),
		@zc12compensoprev decimal(19,2),
		@zc13ritprevdovuta decimal(19,2),
		@zc14ritprevtrattenuta decimal(19,2),
		@zc15ritprevpagata decimal(19,2),
		@zc16emensTuttiIMesi int,
		@zc17mesiSenzaEmens varchar(12),
		@zc80patcode varchar(10),
		@zc81start datetime,
		@zc82stop datetime,
		@c83codiceComuneEnte varchar(4)

	DECLARE @codfiscEnte varchar(16)
	declare @idcityEnte int
	SELECT @codfiscEnte = cf, @idcityEnte = idcity FROM license

	select @c83codiceComuneEnte = value from geo_city_agency 
		where idcode=1 and idcity=@idcityente and idagency=1

	CREATE TABLE #recordg
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data datetime
	)


--INIZIO PRELIEVO DATI DA expensetax
	CREATE TABLE #wizard
	(
		idexp varchar(72),
		idreg int,
		idser int,
		importocorrente decimal(19,2),
		servicestart datetime,
		servicestop datetime,
		adate datetime,
		imponibile decimal(19,2),
		taxcode varchar(10),
		importoritenuta decimal(19,2),
		deduzione decimal(19,2),
		detrazione decimal(19,2),
		taxkind char,
		geoappliance char,
		ytaxpay int,
		ntaxpay int,
		idmot varchar(10),
		admintax decimal(19,2)
	)
	DECLARE @maxexpensephase char
	SELECT @maxexpensephase = MAX(nphase) FROM expensephase

	-- Vengono considerate solo le prestazioni NON presenti nel modulo PARASUBORDINATI
	INSERT INTO #wizard
		(
			idexp,--1
			idreg,--2
			idser,--3
			importocorrente,--4
			servicestart,--5
			servicestop,--6
			adate,--7
			imponibile,--8
			taxcode,--9
			importoritenuta,--10
			deduzione,--11
			detrazione,--12
			taxkind,--13
			geoappliance,--14
			ytaxpay,--15
			ntaxpay,--16
			idmot,--17
			admintax
		)
		SELECT
			expense.idexp,--1
			expense.idreg,--2
			expenselast.idser,--3
			expenseyear.amount
			+ ISNULL(
				(SELECT SUM(amount) FROM expensevar
				WHERE expensevar.idexp = expense.idexp
				AND expensevar.yvar <= 2006
				AND ISNULL(autokind,0) <> 4)
			,0),--4
			expenselast.servicestart,--5
			expenselast.servicestop,--6
			expense.adate,--7
			expensetax.taxablegross,--8
			expensetax.taxcode,--9
			expensetax.employtax,--10
			expensetax.exemptionquota,--11
			expensetax.abatements,--12
			tax.taxkind,--13
			tax.geoappliance,--14
			expensetax.ytaxpay,--15
			expensetax.ntaxpay,--16
			motive770service.idmot,--17
			expensetax.admintax--18
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
		JOIN expenselast
			ON expense.idexp = expenselast.idexp
		JOIN expensetax 
			ON expense.idexp = expensetax.idexp
		JOIN service
			ON service.idser=expenselast.idser
		JOIN tax
			ON expensetax.taxcode = tax.taxcode
		JOIN registry
			ON expense.idreg = registry.idreg
		join payment 
			on payment.kpay=expenselast.kpay
		join paymenttransmission 
			on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
		left outer JOIN motive770service
			ON motive770service.idser = service.idser
			AND motive770service.ayear = 2007
		where transmissiondate between {d '2006-01-13'} and {d '2007-01-12'}
			AND registry.idregistryclass <> '10'
			AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg)
			AND (@modello='cud' and service.certificatekind = 'U' or @modello='770' and service.rec770kind='G')
			AND (expenseyear.amount
				+ ISNULL(
					(SELECT SUM(amount) FROM expensevar
					WHERE expensevar.idexp = expense.idexp
					AND expensevar.yvar <= 2006
					AND ISNULL(autokind,0) <> 4)
				,0)) > 0
			and not exists (select * from expensepayroll
			join expenselink
				on expenselink.idparent = expensepayroll.idexp
			where expensetax.idexp = expenselink.idchild)
-- FINE PRELIEVO DATI DA expensetax

	create table #contratti (idcon varchar(8), padre varchar(8))

	create table #cedolini (
		idcedolino int, 
		idexp int,
		datacompetenza datetime, 
		startpayroll datetime,
		stoppayroll datetime,
		compensoprev decimal(19,2),
		ritprevtrattenuta decimal(19,2),
		inpsamm decimal(19,2),
		inail decimal(19,2)
	)
	

	declare @progrComunic int
	set @progrComunic = 1

	declare @chiave varchar(72)
	declare @tipo char
	declare @cognome varchar(60)

	declare @cursorecomunicazione cursor 

	set @cursorecomunicazione = cursor for
		select distinct idcon, tipo='C', surname from #modulocococo
			join registry on #modulocococo.idreg=registry.idreg
		union all
		select distinct idexp, 'W', surname from #wizard
			join registry on #wizard.idreg=registry.idreg
		order by tipo, surname


	open @cursorecomunicazione
	fetch next from @cursorecomunicazione into @chiave, @tipo, @cognome

	while @@fetch_status=0 
	begin
		set @a1cf = null
		set @a2cognome = null
		set @a3nome = null
		set @a4gender = null
		set @a5birthdate = null
		set @a6comuneostatonascita = null
		set @a7provNascita = null
		set @a11comune31dic = null
		set @a12prov31dic = null
		set @a13codiceComune31dic = null
		set @a14comune1gen = null
		set @a15prov1gen = null
		set @a16codiceComune1gen = null
		set @wb1RedditoDedArt11 = null
		set @wb3workingdays = null
		set @wb5ritIRPEF = null
		set @wb6add_reg = null
		set @wb7add_com = null
		set @wb7accontoaddcom = null
		set @wb17notaxarea = null
		set @wb18notaxfamilyarea = null
		set @wb19ImponibileIrpef = null
		set @wb20ImpostaLorda = null
		set @wb21detrazionefiscale = null
		set @wb26deductionart10 = null
		set @wb27oneridetraibili = null
		set @wb35maggioreritenuta = null
		set @wb36NonApplicareNoTax = null
		set @wb40altriredditi = null
		set @wb45totaleredditiconguagliato = null
		set @wb47cudcodfisc = null
		set @wb50cudimpfisclordo = null
		set @wb51cudirpef = null
		set @wb52cudirpefsosp = null
		set @wb53cudaddreg = null
		set @wb54cudaddregsosp = null
		set @wb55cudaddcom = null
		set @wb56cudaddcomsosp = null
		set @wc12compensoprev = null
		set @wc13ritprevdovuta = null
		set @wc14ritprevtrattenuta = null
		set @wc15ritprevpagata = null
		set @wc16emensTuttiIMesi = null
		set @wc17mesiSenzaEmens = null
		set @wc80patcode = null
		set @wc81start = null
		set @wc82stop = null
--		set @wc83codiceComuneEnte = null
		set @zb1RedditoDedArt11 = null
		set @zb3workingdays = null
		set @zb5ritIRPEF = null
		set @zb6add_reg = null
		set @zb7add_com = null
		set @zb7accontoaddcom = null
		set @zb17notaxarea = null
		set @zb18notaxfamilyarea = null
		set @zb19ImponibileIrpef = null
		set @zb20ImpostaLorda = null
		set @zb21detrazionefiscale = null
		set @zb26deductionart10 = null
		set @zb27oneridetraibili = null
		set @zb35maggioreritenuta = null
		set @zb36NonApplicareNoTax = null
		set @zb40altriredditi = null
		set @zb45totaleredditiconguagliato = null
		set @zb47cudcodfisc = null
		set @zb50cudimpfisclordo = null
		set @zb51cudirpef = null
		set @zb52cudirpefsosp = null
		set @zb53cudaddreg = null
		set @zb54cudaddregsosp = null
		set @zb55cudaddcom = null
		set @zb56cudaddcomsosp = null
		set @zc12compensoprev = null
		set @zc13ritprevdovuta = null
		set @zc14ritprevtrattenuta = null
		set @zc15ritprevpagata = null
		set @zc16emensTuttiIMesi = null
		set @zc17mesiSenzaEmens = null
		set @zc80patcode = null
		set @zc81start = null
		set @zc82stop = null
--		set @zc83codiceComuneEnte = null
	

	--4 Spazio a disposizione dell'utente
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '04', @tipo)
	--8 Spazio a disposizione dell'utente per l'identificazione della dichiarazione
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '08', @chiave)
		
		if @tipo='C' select @idreg=idreg from #modulocococo where idcon=@chiave
			else select @idreg=idreg from #wizard where idexp=@chiave

		select
			@denominazione = registry.title,
			@a1cf =  registry.cf,
			@p_iva = registry.p_iva,
			@a2cognome = registry.surname,
			@a3nome = registry.forename,
			@a5birthdate = registry.birthdate,
			@a4gender = registry.gender,
			@idcitynascita = registry.idcity,
			@idnationnascita = registry.idnation,
			@flagcfestero = CASE 
				WHEN registry.cf IS NULL THEN 'S'
				WHEN registry.cf IS NOT NULL THEN 'N'
			END
			FROM registry
			WHERE registry.idreg = @idreg

		select
			@a6comuneostatonascita = geo_city.title,
			@a7provNascita = geo_country.province
			from geo_city join geo_country on geo_city.idcountry = geo_country.idcountry
			where geo_city.idcity = @idcitynascita

		if (@a6comuneostatonascita is null) 
		begin
			select @a6comuneostatonascita = geo_nation.title
				from geo_nation where geo_nation.idnation = @idnationnascita
		end

		DECLARE @codeaddress varchar(20)
		SET @codeaddress = '07_SW_DOM'
		DECLARE @idaddress int
		SET @idaddress = ISNULL((SELECT idaddress FROM address WHERE codeaddress = @codeaddress),0)

		select 
			@idaddresskind06 = @idaddress,
			@start06 = (select max(registryaddress.start) from registryaddress 
			where registryaddress.idreg = @idreg
			and registryaddress.idaddresskind = @idaddress
			and year(registryaddress.start) <= 2006)

		SET @codeaddress = '07_SW_DEF'
		SET @idaddress = ISNULL((SELECT idaddress FROM address WHERE codeaddress = @codeaddress),0)

		if (@start06 is null) begin
			select @idaddresskind06 = @idaddress,
				@start06 = (select max(registryaddress.start)
				from registryaddress 
				where registryaddress.idreg = @idreg
				and registryaddress.idaddresskind = @codeaddress
				and year(registryaddress.start) <= 2006)
		end
	
		if (@start06 is null) begin
			select @start06 = max(registryaddress.start)
				from registryaddress 
				where registryaddress.idreg = @idreg
				and year(registryaddress.start) <= 2006
		end
		if (@idaddresskind06 is null) begin
			select @idaddresskind06 = registryaddress.idaddresskind
				from registryaddress 
				where registryaddress.idreg = @idreg
				and registryaddress.start = @start06
		end

		select
			@a11comune31dic = geo_city.title,
			@a12prov31dic = geo_country.province,
			@a13codiceComune31dic = geo_city_agency.value
			FROM registryaddress
			left outer join geo_city
				on registryaddress.idcity = geo_city.idcity
			left outer join geo_country
				on geo_city.idcountry = geo_country.idcountry
			LEFT OUTER JOIN geo_city_agency 
				on geo_city.idcity=geo_city_agency.idcity and geo_city_agency.idagency = 1 and geo_city_agency.idcode = 1
			where registryaddress.idreg = @idreg
				AND registryaddress.idaddresskind = @idaddresskind06
				AND registryaddress.start = @start06

		SET @codeaddress = '07_SW_DOM'
		SET @idaddress = ISNULL((SELECT idaddress FROM address WHERE codeaddress = @codeaddress),0)

		select 
			@idaddresskind07 = @idaddress,
			@start07 = (select max(registryaddress.start) from registryaddress 
			where registryaddress.idreg = @idreg
			and registryaddress.idaddresskind = @idaddress
			and year(registryaddress.start) >= 2007)

		SET @codeaddress = '07_SW_DOM'
		SET @idaddress = ISNULL((SELECT idaddress FROM address WHERE codeaddress = @codeaddress),0)

		if (@start07 is null) begin
			select @idaddresskind07 = @idaddress,
				@start07 = (select max(registryaddress.start)
				from registryaddress 
				where registryaddress.idreg = @idreg
				and registryaddress.idaddresskind = @idaddress
				and year(registryaddress.start) >= 2007)
		end
	
		if (@start07 is null) begin
			select @start07 = max(registryaddress.start)
				from registryaddress 
				where registryaddress.idreg = @idreg
				and year(registryaddress.start) <= 2007
		end
		if (@idaddresskind07 is null) begin
			select @idaddresskind07 = registryaddress.idaddresskind
				from registryaddress 
				where registryaddress.idreg = @idreg
				and registryaddress.start = @start07
		end

		select
			@a14comune1gen = geo_city.title,
			@a15prov1gen = geo_country.province,
			@a16codiceComune1gen = geo_city_agency.value
			FROM registryaddress
			left outer join geo_city
				on registryaddress.idcity = geo_city.idcity
			left outer join geo_country
				on geo_city.idcountry = geo_country.idcountry
			LEFT OUTER JOIN geo_city_agency 
				on geo_city.idcity=geo_city_agency.idcity and geo_city_agency.idagency = 1 and geo_city_agency.idcode = 1
			where registryaddress.idreg = @idreg
				AND registryaddress.idaddresskind = @idaddresskind07
				AND registryaddress.start = @start07
	--1 Tipo record
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '01', 'G')
	--2 Codice fiscale del soggetto dichiarante
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '02', @codfiscEnte)
	--3 Progressivo comunicazione
		INSERT INTO #recordg (progr, quadro, riga, colonna, intero)  VALUES(@progrComunic, 'HRG', 1, '03', @progrComunic)
	--6 Codice fiscale del percipiente
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '06', @a1cf)
--PARTE A
--Dati relativi al dipendente, pensionato o altro percettore delle somme
	--DA001001 Codice fiscale
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '001', @a1cf)
	--DA001002 Cognome
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '002', @a2cognome)
	--DA001003 Nome
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '003', @a3nome)
	--DA001004 Sesso
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '004', @a4gender)
	--DA001005 Data di nascita
		INSERT INTO #recordg (progr, quadro, riga, colonna, data)    VALUES(@progrComunic, 'DA', 1, '005', @a5birthdate)
	--DA001006 Comune (o Stato estero) di nascita
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '006', @a6comuneostatonascita)
	--DA001007 Provincia di nascita (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '007', @a7provNascita)
	--DA001011 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '011', @a11comune31dic)
	--DA001012 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '012', @a12prov31dic)
	--DA001013 Codice comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '013', @a13codiceComune31dic)
	--DA001014 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '014', @a14comune1gen)
	--DA001015 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '015', @a15prov1gen)
	--DA001016 Codice comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '016', @a16codiceComune1gen)

--PARTE B - Dati fiscali
--Dati per la eventuale compilazione della dichiarazione dei redditi
-----------------------------------------
-- Riempimento Quadro B - Dati Fiscali --
-----------------------------------------
		if @tipo='C'
		begin
--inizio modulo cococo
--riempimento dei contratti e dei cedolini
			delete #contratti
			insert into #contratti values (@chiave, null)

			declare @numcontratti int
			set @numcontratti = 0

			while (@numcontratti<>(select count(*) from #contratti))
			begin
				select @numcontratti = count(*) from #contratti
				insert into #contratti
					select #cudpresentati.idlinkedcon, #cudpresentati.idcon
					from #cudpresentati 
					join #contratti on #cudpresentati.idcon=#contratti.idcon
						and #cudpresentati.idlinkedcon not in (select idcon from #contratti)
			end

			delete #cedolini
			insert into #cedolini
				select expensepayroll.idpayroll, expensepayroll.idexp, transmissiondate, start, stop, null, null, null, null
				from expensepayroll
				join payroll on payroll.idpayroll=expensepayroll.idpayroll
				join expenselink
					ON expenselink.idparent = expensepayroll.idexp
				join expense on expense.idexp = expenselink.idchild
				join expenselast on expenselast.idexp = expense.idexp
				join payment on payment.kpay=expenselast.kpay
				join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
				join #contratti on payroll.idcon=#contratti.idcon
				where fiscalyear=2006
				order by expense.adate
	
--fine riempimento dei contratti e dei cedolini
			
			declare @idpayroll int
			select @idpayroll=idpayroll from #modulocococo where idcon=@chiave

			declare @onerisostenutiinaltricontratti dec(19,2)
			select @onerisostenutiinaltricontratti = ISNULL(SUM(deduction),0) 
				from payrolltax--altro contratto
				join tax--altro contratto
					on payrolltax.taxcode=tax.taxcode and tax.taxkind = 1 AND tax.geoappliance = 'C'
				join payroll--altro contratto 
					on payrolltax.idpayroll=payroll.idpayroll and payroll.flagbalance='S'
				join #cudpresentati ccc
					on ccc.idlinkedcon=payroll.idcon
					and ccc.idcon=@chiave

			select @zb1RedditoDedArt11 = ISNULL(SUM(taxablegross),0),
				@zb21detrazionefiscale = ISNULL(SUM(abatements),0),
				@zb20ImpostaLorda = ISNULL(SUM(employtaxgross),0),
				@zb19ImponibileIrpef = ISNULL(SUM(taxablenet),0)
				from payrolltax cr
				join tax on cr.taxcode=tax.taxcode
				WHERE idpayroll=@idpayroll and taxkind = 1 AND geoappliance IS NULL

--			set @b5ritIRPEF = @b20ImpostaLorda - @b21detrazionefiscale
				
			select @zb26deductionart10 = @onerisostenutiinaltricontratti + isnull(cr.deduction,0) 
				FROM payrolltax cr 
				join tax on cr.taxcode=tax.taxcode
				WHERE idpayroll=@idpayroll and taxkind = 1 AND geoappliance = 'C' -- me ne serve solo una delle due, tanto sono uguali

			set @zb17notaxarea = 0
			if (@zb1RedditoDedArt11>0)
			begin
				select @zb17notaxarea = curramount
					FROM payrolldeduction ddc
					WHERE ddc.idpayroll = @idpayroll
					AND iddeduction = 19
			end

			SELECT @zb18notaxfamilyarea = curramount 
				FROM payrolldeduction ddc
				WHERE ddc.idpayroll = @idpayroll
				AND iddeduction = 20

			select @zb5ritIRPEF = isnull(sum(employtax),0) 
				from #cedolini
				join expenselink
					ON #cedolini.idexp = expenselink.idparent
				join expensetax
					ON expensetax.idexp = expenselink.idchild
				join tax on expensetax.taxcode=tax.taxcode
				WHERE taxkind = 1 AND geoappliance is null

			select @zb6add_reg = isnull(sum(employtax),0) 
				from #cedolini
				join expenselink
					ON #cedolini.idexp = expenselink.idparent
				join expensetax
					ON expensetax.idexp = expenselink.idchild
				join tax on expensetax.taxcode=tax.taxcode
				WHERE taxkind = 1 AND geoappliance='R'

			select @zb7add_com = isnull(sum(employtax),0) 
				from #cedolini
				join expenselink
					ON #cedolini.idexp = expenselink.idparent
				join expensetax
					ON expensetax.idexp = expenselink.idchild
				join tax on expensetax.taxcode=tax.taxcode
				WHERE taxkind = 1 AND geoappliance='C'

			select @zb7accontoaddcom = isnull(sum(citytax_account),0)
				from parasubcontractyear
				join parasubcontract on parasubcontractyear.idcon=parasubcontract.idcon
				join registry on registry.idreg=parasubcontract.idreg
				join parasubcontract contratto on contratto.idreg=parasubcontract.idreg
				WHERE contratto.idcon=@chiave and ayear=2007

			select @zb35maggioreritenuta = CASE WHEN applybrackets = 'N' THEN 0 ELSE null end
				from parasubcontractyear where idcon=@chiave and ayear=2006

			set @zb36NonApplicareNoTax = 0
			if (select notaxappliance from parasubcontractyear where idcon=@chiave and ayear=2006)='N'
					and exists (select * from #cudpresentati where idcon=@chiave and fiscalyear=2006)
				set @zb36NonApplicareNoTax = 1

--sempre modulo cococo
			SELECT @zb3workingdays = isnull(sum(workingdays),0)
				from payroll 
				join #cedolini on payroll.idpayroll=#cedolini.idcedolino

			if @zb3workingdays>365 
				set @zb3workingdays=365

--		'B27 Totale oneri detraibili' = abatements, --rivedere deve essere calcolato al netto delle franchigie. presumo che nessuno abbia inserito oneri
			SELECT @zb27oneridetraibili = sum(abatableexpense.totalamount-isnull(abatementcode.exemption,0))
				FROM abatableexpense 
				join abatementcode on abatableexpense.idabatement=abatementcode.idabatement
				WHERE abatableexpense.ayear = 2006 and abatementcode.ayear=2006
				AND idcon=@chiave

/*			if exists (select * from parasubcontract
				join servicetax rp on parasubcontract.idser=rp.idser
				join tax tr on rp.taxcode=tr.taxcode
				where idcon=@chiave and taxkind='F' and geoappliance is null)
			begin*/
	--DB001001 Redditi per i quali è possibile fruire della deduzione di cui all'art. 11 del TUIR
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '001', @zb1RedditoDedArt11)
	--DB001002 Redditi per i quali è possibile fruire della sola deduzione di cui all'art.11, c. 1 del TUIR
				-- Il campo seguente viene posto a zero in quanto non riusciamo a distinguere tali prestazioni e, quindi a valorizzarlo correttamente
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '002', 0)
	--DB001003 Numero di giorni per i quali spettano le deduzioni di cui all'art. 11 commi 2 e 3 del TUIR - LAVORO DIPENDENTE
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '003', @zb3workingdays)
	--DB001005 Ritenute Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '005', @zb5ritIRPEF)
	--DB001006 Addizionale regionale all'Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '006', @zb6add_reg)
	--DB001007 Addizionale comunale all'Irpef - Imposta 2006
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '007', @zb7add_com)
	--DB001A07 Addizionale comunale all'Irpef - Acconto 2007
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, 'A07', @zb7accontoaddcom)
	--DB001017 Deduzione per la progressività dell'imposizione(art. 11 del TUIR)
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '017', @zb17notaxarea)
	--DB001018 Deduzione per coniuge e familiari a carico (art. 12, cc. 1 e 2 del TUIR)
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '018', @zb18notaxfamilyarea)
	--DB001019 Imponibile IRPEF
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '019', @zb19ImponibileIrpef)
	--DB001020 Imposta lorda
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '020', @zb20ImpostaLorda)
	--DB001021 Detrazioni per oneri
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '021', @zb21detrazionefiscale)
	--DB001026 Totale oneri sostenuti esclusi dai redditi indicati nei punti 1 e 2
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '026', @zb26deductionart10)
	--DB001027 Totale oneri per i quali è prevista la detrazione d'imposta
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '027', @zb27oneridetraibili)
	--DB001035 Applicazione maggiore ritenuta
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '035', @zb35maggioreritenuta)
	--DB001036 Richiesta di non applicazione della deduzione di cui all'art. 11 del TUIR
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '036', @zb36NonApplicareNoTax)
		
	--sempre modulo cococo
				select @zb40altriredditi=0--sum(taxablegross) 
	--					from cudpresentati
	--					where idcon=@chiave and fiscalyear=2006 and idcudpresentati not in
	--						(select idcudpresentati from cudpresentati where idcon=@chiave)
	
	--				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '040', @zb40altriredditi)--Altri redditi
	
				select @zb45totaleredditiconguagliato = sum(taxablegross)
					from #cudpresentati
					where idcon=@chiave and fiscalyear=2006 /*and idexhibitedcud not in
						(select idexhibitedcud from exhibitedcud where idcon=@chiave)*/
	
	--DB001045 Totale redditi conguagliato già compreso nel punto 1
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '045', @zb45totaleredditiconguagliato)--Totale redditi conguagliato già compreso nel punto 1

				declare @cursorecud cursor
				set @cursorecud = cursor for 
					select cfotherdeputy, exhibitedcud.taxablegross, irpefapplied, 
						irpefsuspended, regionaltaxapplied, suspendedregionaltax, citytaxapplied, suspendedcitytax
					from #cudpresentati
					join exhibitedcud on exhibitedcud.idcon=#cudpresentati.idcon and exhibitedcud.idcon=#cudpresentati.idcon
					where exhibitedcud.idcon=@chiave and exhibitedcud.fiscalyear=2006 /*and idexhibitedcud not in
						(select idexhibitedcud from exhibitedcud where idcon=@chiave)*/
						and not exists (SELECT * from license where ISNULL(cf,p_iva)=cfotherdeputy)
	
				declare @contacud int
				set @contacud = 1
		
				open @cursorecud
		
				fetch next from @cursorecud 
					into @zb47cudcodfisc, @zb50cudimpfisclordo, @zb51cudirpef, 
					@zb52cudirpefsosp, @zb53cudaddreg, @zb54cudaddregsosp, @zb55cudaddcom, @zb56cudaddcomsosp
				
				while @@fetch_status=0 
				begin
	--DBXXX047 Codice fiscale
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @contacud, '047', @zb47cudcodfisc)--Altri redditi
	--DBXXX048 Causa - Casella 48
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '048', 6)--Causa - Casella 48
	--DBXXX049 Causa - Casella 49
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '049', 1)--Causa - Casella 49
	--DBXXX050 Reddito conguagliato
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '050', @zb50cudimpfisclordo)--Reddito conguagliato
	--DBXXX051 Ritenute
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '051', @zb51cudirpef)--Ritenute
	--DBXXX052 Ritenute sospese
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '052', @zb52cudirpefsosp)--Altri redditi
	--DBXXX053 Addizionale regionale
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '053', @zb53cudaddreg)--Addizionale regionale
	--DBXXX054 Addizionale regionale sospesa
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '054', @zb54cudaddregsosp)--Addizionale regionale soexpense
	--DBXXX055 Addizionale comunale
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '055', @zb55cudaddcom)--Addizionale regionale
	--DBXXX056 Addizionale comunale sospesa
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '056', @zb56cudaddcomsosp)--Addizionale regionale soexpense
					set @contacud = @contacud + 1
					fetch next from @cursorecud 
						into @zb47cudcodfisc, @zb50cudimpfisclordo, @zb51cudirpef, 
						@zb52cudirpefsosp, @zb53cudaddreg, @zb54cudaddregsosp, @zb55cudaddcom, @zb56cudaddcomsosp
				end
	--fine modulo cococo
--			end
		end

		if @tipo='W'
		begin
--inizio wizard
			DECLARE @imponibilelordoirpef decimal(19,2)
			-- Calcolo dati fiscali:
	
			declare @imponibileaddreg decimal(19,2)
			declare @imponibileaddcom decimal(19,2)
			declare @deduzioneirpef decimal(19,2)

	
			SELECT
				@imponibilelordoirpef = ISNULL(SUM(imponibile),0), 
				@wb5ritIRPEF = ISNULL(SUM(importoritenuta),0),
				@deduzioneirpef = ISNULL(SUM(deduzione),0),
				@wb21detrazionefiscale = ISNULL(SUM(detrazione),0)
				FROM #wizard 
				WHERE taxkind = 1
				AND geoappliance IS NULL
				and idexp=@chiave
	
			SELECT @wb7add_com = ISNULL(SUM(importoritenuta),0), @imponibileaddcom=isnull(SUM(imponibile),0)
				FROM #wizard
				WHERE taxkind = 1
				AND geoappliance = 'C'
				and idexp=@chiave
	
			SELECT @wb6add_reg = ISNULL(SUM(importoritenuta),0), @imponibileaddreg=isnull(SUM(imponibile),0)
				FROM #wizard
				WHERE taxkind = 1
				AND geoappliance = 'R'
				and idexp=@chiave
	
			set @wb1RedditoDedArt11 = isnull(@imponibilelordoirpef, 0)
			if @wb1RedditoDedArt11 < @imponibileaddcom set @wb1RedditoDedArt11 = @imponibileaddcom
			if @wb1RedditoDedArt11 < @imponibileaddreg set @wb1RedditoDedArt11 = @imponibileaddreg
			set @wb17notaxarea = @wb1RedditoDedArt11 - @imponibilelordoirpef + @deduzioneirpef
--sempre wizard		
			-- Questo dato è MOLTO fittizio in quanto non viene gestito nelle vecchie tabelle, potrà essere valorizzato
			-- seriamente a partire dal prossimo anno quando sarà utilizzato il modulo COCOCO
			SELECT @wb3workingdays = SUM(ISNULL(DATEDIFF(DAY, expenselast.servicestart,expenselast.servicestop),1))
				FROM expenselast
				WHERE idexp=@chiave

			select @wb26deductionart10 = ISNULL(SUM(importoritenuta),0) 
				FROM #wizard WHERE taxkind<>1
				and exists (select * from #wizard s2 where s2.idexp=#wizard.idexp and taxkind=1)
				and idexp=@chiave

			
			-- N.B. I campi da DB001015 a DB001019 non sono attualmente gestiti. Possono essere valorizzati nel prossimo anno quando
			-- verrà usato il modulo PARASUBORDINATI
			-- Calcolo del campo DB001031 (Imponibile IRPEF):
			-- Secondo le specifiche il risultato è dato da DB001001 + DB001002 - DB001024 - DB001042
			-- I campi DB001002 e DB001042 non vengono gestiti quindi l'espresisone diventa
			-- DB001001 - DB001024
			SET @wb19ImponibileIrpef = 0
			IF (@wb1RedditoDedArt11 > @wb17notaxarea)
			BEGIN
				SET @wb19ImponibileIrpef = @wb1RedditoDedArt11 - @wb17notaxarea
			END

			set @wb20ImpostaLorda = @wb5ritIRPEF + @wb21detrazionefiscale
--sempre wizard
	--DB001001 Redditi per i quali è possibile fruire della deduzione di cui all'art. 11 del TUIR
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '001', @wb1RedditoDedArt11)
	--DB001002 Redditi per i quali è possibile fruire della sola deduzione di cui all'art.11, c. 1 del TUIR
			-- Il campo seguente viene posto a zero in quanto non riusciamo a distinguere tali prestazioni e, quindi a valorizzarlo correttamente
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '002', 0)
	--DB001003 Numero di giorni per i quali spettano le deduzioni di cui all'art. 11 commi 2 e 3 del TUIR - LAVORO DIPENDENTE
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '003', @wb3workingdays)
	--DB001005 Ritenute Irpef
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '005', @wb5ritIRPEF)
	--DB001006 Addizionale regionale all'Irpef
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '006', @wb6add_reg)
	--DB001007 Addizionale comunale all'Irpef - Imposta 2006
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '007', @wb7add_com)
	--DB001A07 Addizionale comunale all'Irpef - Acconto 2007
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, 'A07', @wb7accontoaddcom)
	--DB001017 Deduzione per la progressività dell'imposizione(art. 11 del TUIR)
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '017', @wb17notaxarea)
	--DB001018 Deduzione per coniuge e familiari a carico (art. 12, cc. 1 e 2 del TUIR)
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '018', @wb18notaxfamilyarea)
	--DB001019 Imponibile IRPEF
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '019', @wb19ImponibileIrpef)
	--DB001020 Imposta lorda
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '020', @wb20ImpostaLorda)
	--DB001021 Detrazioni per oneri
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '021', @wb21detrazionefiscale)
	--DB001026 Totale oneri sostenuti esclusi dai redditi indicati nei punti 1 e 2
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '026', @wb26deductionart10)
	--DB001027 Totale oneri per i quali è prevista la detrazione d'imposta
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '027', @wb27oneridetraibili)
	--DB001035 Applicazione maggiore ritenuta
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '035', @wb35maggioreritenuta)
	--DB001036 Richiesta di non applicazione della deduzione di cui all'art. 11 del TUIR
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '036', @wb36NonApplicareNoTax)
	
		end

--Dati previdenziali ed assistenziali INPS
		if @tipo='W'
		begin
--inizio wizard
			DECLARE @importocorrente decimal(19,2)
			declare @servicestart datetime
			declare @servicestop datetime
			declare @adate datetime
			declare @wdatacompetenza datetime
	
			SELECT DISTINCT
				@wdatacompetenza=paymenttransmission.transmissiondate,
				@servicestart=#wizard.servicestart,
				@servicestop=#wizard.servicestop,
				@adate=#wizard.adate,
				@importocorrente=#wizard.importocorrente
				FROM #wizard
				join expense on expense.idexp=#wizard.idexp
				join expenselast on expense.idexp = expenselast.idexp
				join payment on payment.kpay=expenselast.kpay
				join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
				WHERE #wizard.idexp=@chiave
		
--sempre wizard	
			SELECT @wc12compensoprev = isnull(max(imponibile), 0),
				@wc14ritprevtrattenuta = ISNULL(SUM(importoritenuta),0) 
				FROM #wizard 
				WHERE idexp = @chiave and taxkind=3

			SELECT @wc13ritprevdovuta = @wc14ritprevtrattenuta + ISNULL(SUM(admintax),0) 
				FROM #wizard 
				WHERE idexp = @chiave and taxkind=3

			SET @wc15ritprevpagata = @wc13ritprevdovuta
			
			set @wc16emensTuttiIMesi = 0
--todo: eliminare i mesi con inps=0
			if year(@wdatacompetenza)=2006 
				set @wc17mesiSenzaEmens = replicate('1',month(@wdatacompetenza)-1)+'0'+replicate('1',12-month(@wdatacompetenza))
			else set @wc17mesiSenzaEmens = '111111111111'

--Dati previdenziali ed assistenziali INPS - Sezione 2 - Collab. Coordinate e continuative
	--DCXXX012 Compensi corrisposti al collaboratore
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '012', ROUND(@wc12compensoprev,0))
	--DCXXX013 Contributi dovuti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '013', ROUND(@wc13ritprevdovuta,0))
	--DCXXX014 Contributi a carico del collaboratore trattenuti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '014', ROUND(@wc14ritprevtrattenuta,0))
	--DCXXX015 Contributi versati
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '015', ROUND(@wc15ritprevpagata,0))
	--DCXXX016 Mesi per i quasi è stata presentata la denuncia EMens - Tutti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '016', @wc16emensTuttiIMesi)
	--DCXXX017 Mesi per i quasi è stata presentata la denuncia EMens - Tutti con esclusione di
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '017', @wc17mesiSenzaEmens)

			--Dati assicurativi INAIL
--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '079', ROUND(@wc15ritprevpagata,0))
--declare @patcode varchar(12)
--set @patcode='9034567665'
--				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '080', @patcode)
			set @wc81start=ISNULL(@servicestart,@adate)
	--DCXXX081 Data inizio
			INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', 1, '081', @wc81start)
			set @wc82stop=ISNULL(@servicestop,@adate)
	--DCXXX082 Data fine
			INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', 1, '082', @wc82stop)
	--DCXXX083 Codice comune
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '083', @c83codiceComuneEnte)
	--DCXXX084 Personale viaggiante
--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '084', ROUND(@c15ritprevpagata,0))

--fine wizard
		end
		
		if @tipo='C'
		begin
--inizio modulo cococo		
			select @zc80patcode = patcode from pat join parasubcontract on parasubcontract.idpat=pat.idpat where idcon=@chiave

			update #cedolini set compensoprev = (select max(taxablegross)
				from expensetax
				join tax on expensetax.taxcode=tax.taxcode
				join expenselink
					ON expensetax.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 3)

			update #cedolini set ritprevtrattenuta = (select isnull(sum(employtax),0)
				from expensetax
				join tax on expensetax.taxcode=tax.taxcode
				join expenselink
					ON expensetax.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 3)

			update #cedolini set inpsamm = (select isnull(sum(admintax),0) 
				from expensetax
				join tax on expensetax.taxcode=tax.taxcode
				join expenselink
					ON expensetax.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 3)

			update #cedolini set inail = (select isnull(sum(employtax+admintax),0) 
				from expensetax
				join tax on expensetax.taxcode=tax.taxcode
				join expenselink
					ON expensetax.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 4)

			set @zc17mesiSenzaEmens = --todo: eliminare i mesi in cui inps=0
				  case when exists (select * from #cedolini where month(datacompetenza)= 1 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 2 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 3 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 4 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 5 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 6 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 7 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 8 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)= 9 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)=10 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)=11 and year(datacompetenza)=2006) then '0' else '1' end
				+ case when exists (select * from #cedolini where month(datacompetenza)=12 and year(datacompetenza)=2006) then '0' else '1' end

			select	@zc12compensoprev = round(sum(compensoprev),0),
				@zc13ritprevdovuta = round(sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),0),
				@zc14ritprevtrattenuta = round(sum(ritprevtrattenuta),0),
				@zc15ritprevpagata = round(sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),0)
				from #cedolini

			declare @zzc12compensoprev dec(19,2)
			declare @zzc13ritprevdovuta dec(19,2)
			declare @zzc14ritprevtrattenuta dec(19,2)
			declare	@zzc15ritprevpagata dec(19,2)

			SELECT @zzc12compensoprev = isnull(max(expensetax.taxablegross), 0),
				@zzc14ritprevtrattenuta = ISNULL(SUM(employtax),0) 
				FROM expensetax
				join tax on expensetax.taxcode=tax.taxcode
				join expenselink
					ON expensetax.idexp = expenselink.idchild
				JOIN #cedolini
					ON #cedolini.idexp = expenselink.idparent
				WHERE taxkind=3

			SELECT @zzc13ritprevdovuta = @zzc14ritprevtrattenuta + ISNULL(SUM(admintax),0) 
				FROM expensetax
				join tax on expensetax.taxcode=tax.taxcode
				join expenselink
					ON expensetax.idexp = expenselink.idchild
				JOIN #cedolini
					ON #cedolini.idexp = expenselink.idparent
				WHERE taxkind=3

			SET @zzc15ritprevpagata = @wc13ritprevdovuta

/*			SELECT zzc12compensoprev = expensetax.taxablegross,
				zzc14ritprevtrattenuta = employtax
				FROM expensetax
--				join tax on expensetax.taxcode=tax.taxcode
				WHERE 
--taxkind='P' and
				idexp like '06000023%'
or idexp like '06000133%'
or idexp like '06000229%'
or idexp like '06000275%'
or idexp like '06000391%'
or idexp like '06000451%'
or idexp like '06000595%'
or idexp like '06000660%'
or idexp like '06000777%'
or idexp like '06000912%'
or idexp like '06000990%'

SELECT * from expensepayroll where idpayroll=315
select * from expensetax where idexp='06000660'
SELECT * FROM EXPENSETAX WHERE IDEXP IN (
'06000023',
'06000133',
'06000229',
'06000275',
'06000391',
'06000451',
'06000595',
'06000660',
'06000777',
'06000912',
'06000990')


select * from #cedolini*/

--			if (@zzc12compensoprev<>@zc12compensoprev) select '@zc12compensoprev', @chiave, @zzc12compensoprev, @zc12compensoprev
			if (round(@zzc13ritprevdovuta,0)<>@zc13ritprevdovuta) select '@zc13ritprevdovuta', @chiave, @zzc13ritprevdovuta, @zc13ritprevdovuta
			if (round(@zzc14ritprevtrattenuta,0)<>@zc14ritprevtrattenuta) select '@zc14ritprevtrattenuta', @chiave, @zzc14ritprevtrattenuta, @zc14ritprevtrattenuta
			if (round(@zzc15ritprevpagata,0)<>@zc15ritprevpagata) select '@zc15ritprevpagata', @chiave, @zzc15ritprevpagata, @zc15ritprevpagata

--inizio contaprestazioni
	--DCXXX012 Compensi corrisposti al collaboratore
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '012', @zc12compensoprev)
	--DCXXX013 Contributi dovuti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '013', @zc13ritprevdovuta)
	--DCXXX014 Contributi a carico del collaboratore trattenuti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '014', @zc14ritprevtrattenuta)--Contributi a carico del collaboratore trattenuti
	--DCXXX015 Contributi versati
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '015', @zc15ritprevpagata)--Contributi versati
	--DCXXX016 Mesi per i quasi è stata presentata la denuncia EMens - Tutti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '016', 0)
	--DCXXX017 Mesi per i quasi è stata presentata la denuncia EMens - Tutti con esclusione di
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '017', @zc17mesiSenzaEmens)

			declare @cursorecedolini cursor
	
			set @cursorecedolini = cursor for
				select idcedolino, datacompetenza, startpayroll, stoppayroll, inail from #cedolini
	
			declare @startpayroll datetime
			declare @stoppayroll datetime
			declare @inail decimal(19,2)
			declare @contaprestazioni int
			declare @zdatacompetenza datetime
	
			open @cursorecedolini
			fetch next from @cursorecedolini into @idpayroll, @zdatacompetenza, @startpayroll, @stoppayroll, @inail
			set @contaprestazioni = 1
	
			while @@fetch_status = 0
			begin
				--Dati assicurativi INAIL
				if @inail>0 
				begin
					if @startpayroll<{d '2006-01-01'} set @startpayroll={d '2006-01-01'}
					if @stoppayroll>{d '2006-12-31'} set @stoppayroll={d '2006-12-31'}
	--DCXXX079 Qualifica
		--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', @contaPrestazioni, '079', ROUND(@c15ritprevpagata,0))
	--DCXXX080 Posizione assicurativa territoriale
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', @contaPrestazioni, '080', @zc80patcode)
	--DCXXX081 Data inizio
					INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', @contaPrestazioni, '081', @startpayroll)
	--DCXXX082 Data fine
					INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', @contaPrestazioni, '082', @stoppayroll)
	--DCXXX083 Codice comune
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', @contaPrestazioni, '083', @c83codiceComuneEnte)
	--DCXXX084 Personale viaggiante
		--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', @contaPrestazioni, '084', ROUND(@c15ritprevpagata,0))
				end
	
				set @contaprestazioni = @contaprestazioni + 1
				fetch next from @cursorecedolini into @idpayroll, @zdatacompetenza, @startpayroll, @stoppayroll, @inail
	
			end
--fine modulo cococo
		end
		set @progrComunic = @progrComunic + 1
		fetch next from @cursorecomunicazione into @chiave, @tipo, @cognome
	end
	CLOSE @cursorecomunicazione
	DEALLOCATE @cursorecomunicazione
	select * from #recordg where (intero is not null or stringa is not null or data is not null)

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

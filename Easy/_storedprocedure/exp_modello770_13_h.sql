
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_13_h]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_13_h]
GO
--exec exp_modello770_13_h
CREATE PROCEDURE [exp_modello770_13_h]
AS BEGIN
-- OK
	declare @SS003001 dec(19,2)
	declare @SS003002 dec(19,2)

	declare @annodichiarazione int
	set @annodichiarazione = 2013

	declare @annoredditi int
	set @annoredditi = 2012

	declare @31dic11 datetime
	set @31dic11 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select @expensephase=expensephase from config where ayear = @annodichiarazione-1


CREATE TABLE #annualpayedrefundH
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
	CREATE TABLE #recHNonArrot
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		decimfisc decimal(19,2),
		decimprev decimal(19,2),
		data datetime,
		intero int
	)


-- Sezione dichiarativa	
	DECLARE @progrCom int
	DECLARE @codfiscEnte varchar(16)
	DECLARE @idreg int
	DECLARE @au1cf varchar(16)
	DECLARE @au2cognomePercipiente varchar(50)
	DECLARE @au3nomePercipiente varchar(30)
	DECLARE @au4gender char(1)
	DECLARE @au5birthdate datetime
	DECLARE @au6birthplace varchar(61)
	DECLARE @au7birthprovince varchar(2)
	DECLARE @au14foreigncf varchar(25)
	--
	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #expense2012
	(
		idexp int,
		idreg int,
		idser int,
		employtaxamount decimal(19,2),
		motive770 varchar(10)
	)


	INSERT INTO #expense2012
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

	update #expense2012 set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #expense2012.idser
		AND motive770service.ayear = @annodichiarazione-1

	declare @cognome varchar(60)

	DECLARE registry_crs CURSOR FOR 
		SELECT DISTINCT isnull(cf,p_iva), #expense2012.idreg, surname FROM #expense2012
		join registry on registry.idreg = #expense2012.idreg
		order by surname
	OPEN registry_crs
	
	SET @progrCom = 1
	FETCH NEXT FROM registry_crs into @au1cf, @idreg, @cognome
	
	declare @idcitynascita int
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		set @au14foreigncf=null
		set @au2cognomePercipiente=null
		set @au3nomePercipiente=null
		set @au4gender=null
		set @au5birthdate=null
		set @au6birthplace=null
		set @au7birthprovince=null

		SELECT
			@au6birthplace =  geo_nation.title,
			@au14foreigncf = registry.foreigncf,
			@au2cognomePercipiente = coalesce(registry.surname, registry.title),
			@au3nomePercipiente = registry.forename,
			@au4gender = registry.gender,
			@au5birthdate = registry.birthdate,
			@idcitynascita= registry.idcity
			FROM registry 		
			LEFT OUTER JOIN geo_nation ON registry.idnation = geo_nation.idnation
			WHERE registry.idreg = @idreg


		
		if (@idcitynascita is not null)
		BEGIN
			while (select newcity from geo_city where idcity=@idcitynascita) is not null
			BEGIN
				select @idcitynascita=newcity from geo_city where idcity=@idcitynascita 
			END

			--sezione di impostazione vecchio comune poiché quello del 770 non è aggiornato, DA RIMUOVERE nel 2010!!
			SELECT
				@au6birthplace = geo_city.title,
				@au7birthprovince =  geo_country.province 
				FROM geo_city 
				LEFT OUTER JOIN geo_country ON geo_city.idcountry = geo_country.idcountry
				WHERE geo_city.idcity=@idcitynascita
		END
		SELECT @codfiscEnte = cf FROM license
	--1 Tipo record
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '01', 'H')
	--2 Codice fiscale del soggetto dichiarante
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '02', @codfiscEnte)
	--3 Progressivo comunicazione
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'HRH', 1, '03', @progrCom)
	--6 Codice fiscale del percipiente
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '06', @au1cf)
		DECLARE @cfsoftwarehouse varchar(16)
		SET @cfsoftwarehouse = '02890460781'
	--9 Identificativo del produttore del software (codice fiscale)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '09', @cfsoftwarehouse)
	
		DECLARE @au9provincia varchar(4)
		DECLARE @au10codiceRegione varchar(20)
		DECLARE @au17codiceNazione varchar(20)
		DECLARE @au8location varchar(160)
		DECLARE @au11address varchar(160)

		set @au8location=null
		set @au9provincia=null
		set @au10codiceRegione=null
		set @au17codiceNazione=null
		set @au11address=null

		declare @stand int
		select  @stand = idaddress from address where codeaddress = '07_SW_DEF'

		declare @domfi int
		select  @domfi = idaddress from address where codeaddress = '07_SW_DOM'

		declare @idcitydom int
		set @idcitydom=null

		SELECT TOP 1 
			@idcitydom = registryaddress.idcity,
			@au8location = coalesce( geo_nation.title, registryaddress.location),
			@au17codiceNazione = isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end),
			--CASE
			--	--sezione di impostazione vecchio stato poiché quello del 770 non è aggiornato, DA RIMUOVERE nel 2010!!
			--	WHEN isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end) = 289 THEN 288
			--	WHEN isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end) = 290 THEN 288
			--	ELSE isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end)
			--END,
			@au11address = registryaddress.address
			FROM registryaddress 
			LEFT OUTER JOIN geo_nation
				ON registryaddress.idnation = geo_nation.idnation
			LEFT OUTER JOIN geo_nation_agency
				ON geo_nation.idnation = geo_nation_agency.idnation
				AND geo_nation_agency.idagency = 5
				AND geo_nation_agency.idcode = 1
			WHERE registryaddress.idreg = @idreg
				AND registryaddress.start <= @31dic11
				AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic11)
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
			@au8location = geo_city.title, 
			@au9provincia = geo_country.province,
			--case 
			--	--sezione di impostazione vecchio comune poiché quello del 770 non è aggiornato, DA RIMUOVERE nel 2010!!
			--	when geo_city.idcity in (13935, 13936, 13937, 13938, 13940, 13942, 13943) then 'BA'
			--	when geo_city.idcity in (13939, 13941, 13944) then 'FG'
			--	else geo_country.province end,
			@au10codiceRegione = geo_country_agency.value
			FROM geo_city
			LEFT OUTER JOIN geo_country
				ON geo_country.idcountry = geo_city.idcountry
			LEFT OUTER JOIN geo_country_agency
				ON geo_country.idcountry = geo_country_agency.idcountry
				AND geo_country_agency.idagency = 5
				AND geo_country_agency.idcode = 1
			WHERE geo_city.idcity=@idcitydom


		END


	--AU001001 Codice fiscale
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '001', @au1cf)
	--AU001002 Cognome o denominazione
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '002', @au2cognomePercipiente)
	--AU001003 Nome
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '003', @au3nomePercipiente)
	--AU001004 Sesso
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '004', @au4gender)
	--AU001005 Data di nascita
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, data)    VALUES(@progrCom, 'AU', 1, '005', @au5birthdate)
	--AU001006 Comune (o Stato estero) di nascita
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '006', @au6birthplace)
	--AU001007 Provincia di nascita (sigla)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '007', @au7birthprovince)

		DECLARE @au15locationestera varchar(160)
		DECLARE @au16addressestero varchar(160)
		DECLARE @tmpidcity int



		set @au15locationestera = null
		set @au16addressestero = null
		IF (@au17codiceNazione is not null)
		BEGIN
			set @au15locationestera = @au8location
			set @au16addressestero = @au11address

			set @au8location=null
			set @au9provincia=null
			set @au10codiceRegione=null
			set @au11address=null
			set @tmpidcity=null
			--Mi ricavo il domicilio fiscale italiano
			SELECT TOP 1 
				@tmpidcity = geo_city.idcity,
				@au8location =  registryaddress.location,
				@au11address = registryaddress.address
				FROM registryaddress 
				LEFT OUTER JOIN geo_city
					ON registryaddress.idcity = geo_city.idcity
				WHERE registryaddress.idreg = @idreg
					AND registryaddress.start <= @31dic11
					AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic11)
					AND idaddresskind = @domfi


			if (@tmpidcity is not null)
			BEGIN
				while (select newcity from geo_city where idcity=@tmpidcity) is not null
				BEGIN
					select @tmpidcity=newcity from geo_city where idcity=@tmpidcity 
				END

				SELECT 
					@au8location =  geo_city.title,
					@au9provincia = geo_country.province,
					--case 
					----sezione di impostazione vecchio comune poiché quello del 770 non è aggiornato, DA RIMUOVERE nel 2010!!
					--	when geo_city.idcity in (13935, 13936, 13937, 13938, 13940, 13942, 13943) then 'BA'
					--	when geo_city.idcity in (13939, 13941, 13944) then 'FG'
					--	else geo_country.province end,
					@au10codiceRegione = geo_country_agency.value
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

	--AU001008 Comune
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '008', @au8location)
	--AU001009 Provincia (sigla)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '009', @au9provincia)
		-- Il campo AU001010 non viene mai riempito in quanto la causale (campo AU001016) vale sempre A o M e mai N (condizione per cui tale campo deve essere valorizzato)

		if exists (select * from #expense2012 where idreg=@idreg and motive770='N')
		begin
	--AU001010 Codice regione
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', 1, '010', @au10codiceRegione)
		end
	--AU001011 Via e numero civico
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '011', @au11address)
		IF (@au17codiceNazione is not null)
		BEGIN
		-- I campi da AU001012 ad AU001015 vengono valorizzati qualora si tratti di persone residenti all'estero
	--AU001014 Codice di identificazione fiscale estero
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '014', @au14foreigncf)
	--AU001015 Località di residenza estera
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '015', @au15locationestera)
	--AU001016 Via e numero civico
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '016', @au16addressestero)
			-- N.B. il codiceNazione deve essere memorizzato come intero (come da specifiche del 770), sul DB il dato è memorizzato come varchar
			-- ma trattandosi di codice ISIN non ci sono problemi in quanto sono effettivamente valori numerici
	--AU001017 Codice stato estero
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, intero) VALUES(@progrCom, 'AU', 1, '017', CONVERT(int,@au17codiceNazione))
		END

		DECLARE @employtaxamount decimal(19,2)
		DECLARE @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale decimal(19,2)
		DECLARE @au24_AltreSommeNonSoggetteARitenuta decimal(19,2)
		DECLARE @au21_ammontarelordocorrisposto decimal(19,2)
		DECLARE @au25imponibile decimal(19,2)
		DECLARE @idexp int
		DECLARE @idser int
		DECLARE @taxcodefiscale int
		DECLARE @au26_27ritIRPEF decimal(19,2)
		DECLARE @au34ritprevidenzialeamm decimal(19,2)
		DECLARE @au35ritprevidenzialedip decimal(19,2)
		DECLARE @au18causale char(1)
		DECLARE cursoreexpense CURSOR FOR 
			SELECT 
				#expense2012.employtaxamount,
				#expense2012.idexp,
				#expense2012.idser,
				#expense2012.motive770
			FROM #expense2012
			join expenselink 
				on expenselink.idchild = #expense2012.idexp
				and nlevel = @expensephase
			left outer join expenseprofservice
				on expenselink.idparent = expenseprofservice.idexp
			WHERE #expense2012.idreg=@idreg 
				and isnull(movkind,0) <> 2

		OPEN cursoreexpense
		FETCH NEXT FROM cursoreexpense
			INTO @employtaxamount, @idexp, @idser, @au18causale
	
		DECLARE @contaPrestazioni int
		SET @contaPrestazioni = 1

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SELECT @taxcodefiscale = expensetax.taxcode
				FROM expensetax
				JOIN tax
					ON tax.taxcode = expensetax.taxcode
				WHERE expensetax.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')= 'N'--IS NULL
					

			SELECT @au26_27ritIRPEF = ISNULL(SUM(expensetaxofficial.employtax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')='N'-- IS NULL
					AND expensetaxofficial.stop IS NULL

			SELECT  @au35ritprevidenzialedip = isnull(SUM(expensetaxofficial.employtax),0),
				@au34ritprevidenzialeamm = isnull(SUM(expensetaxofficial.admintax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
				AND tax.taxkind = 3
				AND expensetaxofficial.stop IS NULL

	--AUXXX018 Causale
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', @contaPrestazioni, '018', @au18causale)


	-- AUX0021 Ammontare lordo corrisposto = Imponibile Lordo SUM (feegross) di quel percipiente.
	set @au21_ammontarelordocorrisposto=0
	
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

	-- calcola @au21_ammontarelordocorrisposto

	SELECT @ycon = ycon, @ncon = ncon
		FROM casualcontract C
		WHERE EXISTS(select * from expensecasualcontract EC
				join expenselink EL on EC.idexp=EL.idparent						
				where EL.idchild=@idexp
					AND C.ycon=EC.ycon and C.ncon=EC.ncon
			)

	IF (@ycon is not null)  -- si tratta di un contratto occasionale
	BEGIN
		DELETE FROM #annualpayedrefundH
		INSERT INTO #annualpayedrefundH (		
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

-- select payed_lastyear,@annoredditi as annoredditi,@ycon as ycon,@ncon as ncon, * from #annualpayedrefundH

			 SET @imponibilereale = 
				ISNULL( (SELECT payed_lastyear  from #annualpayedrefundH),0)
				--	ISNULL(feegross,0) FROM casualcontract WHERE @ycon = ycon AND @ncon = ncon


			SELECT @au21_ammontarelordocorrisposto = 

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
				SET @au21_ammontarelordocorrisposto = @imponibilereale
				
			END
			
			set @quota_contratto =  @au21_ammontarelordocorrisposto/@imponibilereale 

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
			
			SELECT  @au21_ammontarelordocorrisposto = 
				ROUND(@quota_contratto*(isnull(@spesededucibilifis,0)+isnull(@imponibilereale,0) ),2)

		END
		ELSE
		BEGIN --MOV. DI SPESA
			SELECT @au21_ammontarelordocorrisposto = 
				MAX(ET.taxablegross)
				FROM expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
		END
	END
		
	set @au21_ammontarelordocorrisposto= isnull(@au21_ammontarelordocorrisposto,0)
		
	INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '021', @au21_ammontarelordocorrisposto)

-- AUXXX022 Somme non soggette a ritenuta per regime convenzionale
-- leggere il feegross delle prestazioni che hanno la ritenuta IRPEF STRANIERI con convenzione. Tali prestazioni hanno ritenuta a zero
	SET @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale=0
	SELECT @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale = ISNULL(SUM(taxablenet),0)
		FROM expensetaxofficial 
		JOIN tax 
			ON tax.taxcode = expensetaxofficial.taxcode
		WHERE expensetaxofficial.idexp = @idexp 
			AND tax.taxkind = 1
			AND taxref ='07_IRPEF_FC'
			AND expensetaxofficial.stop IS NULL
	
	if (@au22SommeNonSoggetteARitenutaPerRegimeConvenzionale <> 0) 
	BEGIN
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '022', @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale)
	END
---AUX0024 = Imponibile Lordo SUM (feegross) - Imponibile Netto (SUM(taxablenet) da expensetax where (taxkind=1 ossia fiscali)
	set @au24_AltreSommeNonSoggetteARitenuta=0
	SET @au24_AltreSommeNonSoggetteARitenuta = 
					@au21_ammontarelordocorrisposto
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
					- @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale
					
	-- mettiamo 3 se diverso da zero 
	if (@au24_AltreSommeNonSoggetteARitenuta <> 0) 
	BEGIN
		--- AUXXX023 Codice NP Vale sempre 3 
		--- AUX0024 Altre Somme Non Soggette a Ritenuta
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, intero) VALUES(@progrCom, 'AU', @contaPrestazioni, '023', 3)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '024', @au24_AltreSommeNonSoggetteARitenuta)
	END
	
	


--	AUXXX025 Imponibile
--	AUX025 = AUX0021 - AUX0022 - AUX0024
	SET @au25imponibile = @au21_ammontarelordocorrisposto - @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale-@au24_AltreSommeNonSoggetteARitenuta

	INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '025', @au25imponibile)


			declare @certificatekind char
			set 	@certificatekind = null
			select 	@certificatekind = certificatekind from service where idser = @idser

			DECLARE @colonna varchar(3)
			if (@idser in (select  service.idser from service join servicetax ON servicetax.idser=service.idser
						join tax on servicetax.taxcode=tax.taxcode
						where  tax.taxref in ('08_IRPEF_FOC','07_IRPEF_FO') 
					) 
			    )
			--IF (@certificatekind = 'T') --sostituire con check su codice ritenuta 07_IRPEF_FO
			BEGIN
				SET @colonna = '027' --AUXXX027 Ritenute a titolo di imposta
				set @SS003002 = isnull(@SS003002, 0) + isnull(@au26_27ritIRPEF, 0)
			END
			ELSE
			BEGIN
				SET @colonna = '026' --AUXXX026 Ritenute a titolo di acconto
				set @SS003001 = isnull(@SS003001, 0) + isnull(@au26_27ritIRPEF, 0)
			END
	--AUXXX026 Ritenute a titolo di acconto
	--AUXXX027 Ritenute a titolo di imposta
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, @colonna, @au26_27ritIRPEF)

	--AUXXX034 Contributi previdenziali a carico del soggetto erogante
			IF (@au34ritprevidenzialeamm <> 0)
			BEGIN
				INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimprev)  VALUES(@progrCom, 'AU', @contaPrestazioni, '034', @au34ritprevidenzialeamm)
			END
	--AUXXX035 Contributi previdenziali a carico del percipiente
			IF (@au35ritprevidenzialedip <> 0)
			BEGIN
				INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimprev)  VALUES(@progrCom, 'AU', @contaPrestazioni, '035', @au35ritprevidenzialedip)
			END

			declare @au36speseRimborsate dec(19,2)
			set @au36speseRimborsate=0
			IF (@ycon is not null)  -- si tratta di un contratto occasionale
				select  @au36speseRimborsate =  ISNULL( (SELECT P_refund_lastyear  from #annualpayedrefundH),0)

			set  @au36speseRimborsate = @au36speseRimborsate * @quota_contratto
	--AUXXX036 Spese rimborsate
			IF (@au36speseRimborsate <> 0)
			BEGIN
				INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimprev)  VALUES(@progrCom, 'AU', @contaPrestazioni, '036', @au36speseRimborsate)
			END

			SET @contaPrestazioni = @contaPrestazioni + 1
	
			FETCH NEXT FROM cursoreexpense
				INTO @employtaxamount, @idexp, @idser, @au18causale
		END
		CLOSE cursoreexpense
		DEALLOCATE cursoreexpense


		SET @progrCom = @progrCom + 1

		FETCH NEXT FROM registry_crs into @au1cf, @idreg, @cognome
	END
	CLOSE registry_crs
	DEALLOCATE registry_crs

	CREATE TABLE #recordH
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		decimale decimal(19,2),
		data datetime
	)

-- SS003001  	 Ritenute a titolo d'acconto  
--	set @SS003001 = isnull(@SS003001, 0) + isnull(@au26_27ritIRPEF, 0)
-- J.T.R. Commentate per il 2010, nel 2010 si valutra se riempire il prospetto SS
--	INSERT INTO #recordH (progr, quadro, riga, colonna, intero) VALUES(1, 'SS', 3, '001', isnull(@SS003001, 0))

-- SS003002  	 Ritenute a titolo d'imposta  
--	set @SS003002 = isnull(@SS003002, 0) + isnull(@au26_27ritIRPEF, 0)
--	INSERT INTO #recordH (progr, quadro, riga, colonna, intero) VALUES(1, 'SS', 3, '002', isnull(@SS003002, 0))
	
	declare @progr int
	declare @riga int
	declare @causale varchar(10)

	declare @cursore cursor
	
	set @progr = 1
	while @progr < @progrcom
	begin
		insert into #recordH (progr, quadro, riga, colonna, stringa, data, intero)
			select @progr, quadro, riga, colonna, stringa, data, intero
			from #recHNonArrot 
			where (stringa is not null or data is not null or intero is not null)
			and (quadro<>'AU' or colonna <> '018')
			and (colonna <> '023')
			and progr = @progr
			and riga = 1

		set @riga = 1

		set @cursore = cursor for 
			select distinct stringa
			from #recHNonArrot 
			where progr = @progr and quadro='AU' and colonna = '018'
			
		open @cursore
	
		fetch next from @cursore into @causale
		while @@fetch_status = 0 
		begin
			insert into #recordH (progr, quadro, riga, colonna, stringa)
				values (@progr, 'AU', @riga, '018', @causale)
			
				

			insert into #recordH (progr, quadro, riga, colonna, intero)
				select distinct @progr, #recHNonArrot.quadro, @riga, #recHNonArrot.colonna,  #recHNonArrot.intero
				from #recHNonArrot 
				WHERE #recHNonArrot.intero is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna = '023'
				and #recHNonArrot.progr = @progr


			insert into #recordH (progr, quadro, riga, colonna, decimale)
				select @progr, #recHNonArrot.quadro, @riga, #recHNonArrot.colonna, sum(#recHNonArrot.decimfisc)
				from #recHNonArrot 
				join #recHNonArrot rif on #recHNonArrot.progr = rif.progr and #recHNonArrot.riga = rif.riga
				where rif.progr = @progr
				and isnull(rif.stringa,'') = isnull(@causale,'')
				and rif.quadro = 'AU'
				and rif.colonna = '018'
				and #recHNonArrot.decimfisc is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna
				having ( sum(#recHNonArrot.decimfisc)) <> 0
					
			insert into #recordH (progr, quadro, riga, colonna, decimale)
				select @progr, #recHNonArrot.quadro, @riga, #recHNonArrot.colonna, sum(#recHNonArrot.decimprev)
				from #recHNonArrot 
				join #recHNonArrot rif on #recHNonArrot.progr = rif.progr and #recHNonArrot.riga = rif.riga
				where rif.progr = @progr
				and isnull(rif.stringa,'') = isnull(@causale,'')
				and rif.quadro = 'AU'
				and rif.colonna = '018'
				and #recHNonArrot.decimprev is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna
				having ( sum(#recHNonArrot.decimprev)) <> 0
				
			set @riga = @riga + 1
	
			fetch next from @cursore into @causale
		end

		set @progr = @progr + 1
	end


SELECT * FROM #recordh 


DROP TABLE #annualpayedrefundH
DROP TABLE #recordh
DROP TABLE #recHNonArrot
DROP TABLE #expense2012

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--- exec exp_modello770_13_h

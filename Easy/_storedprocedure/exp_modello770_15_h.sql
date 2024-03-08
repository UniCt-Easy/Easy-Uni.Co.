
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_15_h]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_15_h]
GO
 
--exec exp_modello770_15_h
CREATE PROCEDURE [exp_modello770_15_h]
AS BEGIN
-- OK
	declare @SS003001 dec(19,2)
	declare @SS003002 dec(19,2)

	declare @annodichiarazione int
	set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = 2014

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

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
	DECLARE @auA01cf varchar(16)
	DECLARE @auA02cognomePercipiente varchar(50)
	DECLARE @auA03nomePercipiente varchar(30)
	DECLARE @auA04gender char(1)
	DECLARE @auA05birthdate datetime
	DECLARE @auA06birthplace varchar(61)
	DECLARE @auA07birthprovince varchar(2)
	DECLARE @auA40foreigncf varchar(25)
	declare @auA08categorieparticolari varchar(2)
	--
	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #expense2014
	(
		idexp int,
		idreg int,
		idser int,
		employtaxamount decimal(19,2),
		motive770 varchar(10)
	)


	INSERT INTO #expense2014
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

	update #expense2014 set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #expense2014.idser
		AND motive770service.ayear = @annodichiarazione-1

	declare @cognome varchar(60)
	declare @codice_fiscale varchar(20)
	DECLARE registry_crs CURSOR FOR 
		SELECT DISTINCT isnull(cf,p_iva), #expense2014.idreg, surname, coalesce(registry.cf,registry.p_iva,registry.foreigncf) 
		FROM #expense2014
		join registry on registry.idreg = #expense2014.idreg
		order by coalesce(registry.cf,registry.p_iva,registry.foreigncf) 
	OPEN registry_crs
 
	SET @progrCom = 1
	FETCH NEXT FROM registry_crs into @auA01cf, @idreg, @cognome,@codice_fiscale
	
	declare @idcitynascita int
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		set @auA40foreigncf=null
		set @auA02cognomePercipiente=null
		set @auA03nomePercipiente=null
		set @auA04gender=null
		set @auA05birthdate=null
		set @auA06birthplace=null
		set @auA07birthprovince=null
		set @auA08categorieparticolari = null

		SELECT
			@auA06birthplace =  geo_nation.title,
			@auA40foreigncf = registry.foreigncf,
			@auA02cognomePercipiente = coalesce(registry.surname, registry.title),
			@auA03nomePercipiente = registry.forename,
			@auA04gender = registry.gender,
			@auA05birthdate = registry.birthdate,
			@idcitynascita= registry.idcity,
			@auA08categorieparticolari = idspecialcategory770
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
				@auA06birthplace = geo_city.title,
				@auA07birthprovince =  geo_country.province 
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
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '06', @auA01cf)
		DECLARE @cfsoftwarehouse varchar(16)
		SET @cfsoftwarehouse = '02890460781'
	--9 Identificativo del produttore del software (codice fiscale)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '09', @cfsoftwarehouse)
	
		DECLARE @auA21provincia varchar(4)
		DECLARE @au10codiceRegione varchar(20)
		DECLARE @auA43codiceNazione varchar(20)
		DECLARE @auA20location varchar(160)
		DECLARE @au12address varchar(160)

		set @auA20location=null
		set @auA21provincia=null
		set @au10codiceRegione=null
		set @auA43codiceNazione=null
		set @au12address=null

		declare @stand int
		select  @stand = idaddress from address where codeaddress = '07_SW_DEF'

		declare @domfi int
		select  @domfi = idaddress from address where codeaddress = '07_SW_DOM'

		declare @idcitydom int
		set @idcitydom=null

		SELECT TOP 1 
			@idcitydom = registryaddress.idcity,
			@auA20location = coalesce( geo_nation.title, registryaddress.location),
			@auA43codiceNazione = isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end),
			--CASE
			--	--sezione di impostazione vecchio stato poiché quello del 770 non è aggiornato, DA RIMUOVERE nel 2010!!
			--	WHEN isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end) = 289 THEN 288
			--	WHEN isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end) = 290 THEN 288
			--	ELSE isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end)
			--END,
			@au12address = registryaddress.address
			FROM registryaddress 
			LEFT OUTER JOIN geo_nation
				ON registryaddress.idnation = geo_nation.idnation
			LEFT OUTER JOIN geo_nation_agency
				ON geo_nation.idnation = geo_nation_agency.idnation
				AND geo_nation_agency.idagency = 5
				AND geo_nation_agency.idcode = 1
			WHERE registryaddress.idreg = @idreg
				AND registryaddress.start <= @31dic14
				AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic14)
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
			@auA20location = geo_city.title, 
			@auA21provincia = geo_country.province,
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


	--AU001A01 Codice fiscale
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A01', @auA01cf)
	--AU001A02 Cognome o denominazione
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A02', @auA02cognomePercipiente)
	--AU001A03 Nome
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A03', @auA03nomePercipiente)
	--AU001A04 Sesso
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A04', @auA04gender)
	--AU001A05 Data di nascita
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, data)    VALUES(@progrCom, 'AU', 1, 'A05', @auA05birthdate)
	--AU001A06 Comune (o Stato estero) di nascita
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A06', @auA06birthplace)
	--AU001A07 Provincia di nascita (sigla)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A07', @auA07birthprovince)

	-- AU001A08 Categorie Particolari 
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A08', @auA08categorieparticolari)
		
		DECLARE @auA41locationestera varchar(160)
		DECLARE @auA42addressestero varchar(160)
		DECLARE @tmpidcity int


		set @auA41locationestera = null
		set @auA42addressestero = null
		IF (@auA43codiceNazione is not null)
		BEGIN
			set @auA41locationestera = @auA20location
			set @auA42addressestero = @au12address

			set @auA20location=null
			set @auA21provincia=null
			set @au10codiceRegione=null
			set @au12address=null
			set @tmpidcity=null
			--Mi ricavo il domicilio fiscale italiano
			SELECT TOP 1 
				@tmpidcity = geo_city.idcity,
				@auA20location =  registryaddress.location,
				@au12address = registryaddress.address
				FROM registryaddress 
				LEFT OUTER JOIN geo_city
					ON registryaddress.idcity = geo_city.idcity
				WHERE registryaddress.idreg = @idreg
					AND registryaddress.start <= @31dic14
					AND (registryaddress.stop IS NULL OR registryaddress.stop >= @31dic14)
					AND idaddresskind = @domfi


			if (@tmpidcity is not null)
			BEGIN
				while (select newcity from geo_city where idcity=@tmpidcity) is not null
				BEGIN
					select @tmpidcity=newcity from geo_city where idcity=@tmpidcity 
				END

				SELECT 
					@auA20location =  geo_city.title,
					@auA21provincia = geo_country.province		
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
	--Campo 22 – Non deve essere compilato in quanto le istruzioni indicano che devono essere compilati solo quando la causale è N. In Easy non è mai N.
	----AU001A20 Comune
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A20', @auA20location)
	----AU001A21 Provincia (sigla)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A21', @auA21provincia) 
	----AU001022 Codice Comune
		
	 IF (@auA43codiceNazione is not null)
		BEGIN
		-- I campi da AU001A40 ad AU001A43 vengono valorizzati qualora si tratti di persone residenti all'estero
	--AU001A40 Codice di identificazione fiscale estero
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A40', @auA40foreigncf)
	--AU001A41 Località di residenza estera
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A41', @auA41locationestera)
	--AU001A42 Via e numero civico
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, 'A42', @auA42addressestero)
			-- N.B. il codiceNazione deve essere memorizzato come intero (come da specifiche del 770), sul DB il dato è memorizzato come varchar
			-- ma trattandosi di codice ISIN non ci sono problemi in quanto sono effettivamente valori numerici
	--AU001A43 Codice stato estero
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, intero) VALUES(@progrCom, 'AU', 1, 'A43', CONVERT(int,@auA43codiceNazione))
		END

		DECLARE @employtaxamount decimal(19,2)
		DECLARE @au005SommeNonSoggetteARitenutaPerRegimeConvenzionale decimal(19,2)
		DECLARE @au007_AltreSommeNonSoggetteARitenuta decimal(19,2)
		DECLARE @au004_ammontarelordocorrisposto decimal(19,2)
		DECLARE @au008imponibile decimal(19,2)
		DECLARE @idexp int
		DECLARE @idser int
		DECLARE @taxcodefiscale int
		DECLARE @au009_010ritIRPEF decimal(19,2)
		DECLARE @au020ritprevidenzialeamm decimal(19,2)
		DECLARE @au021ritprevidenzialedip decimal(19,2)
		DECLARE @au001causale char(1)
		DECLARE cursoreexpense CURSOR FOR 
			SELECT 
				#expense2014.employtaxamount,
				#expense2014.idexp,
				#expense2014.idser,
				#expense2014.motive770
			FROM #expense2014
			join expenselink 
				on expenselink.idchild = #expense2014.idexp
				and nlevel = @expensephase
			left outer join expenseprofservice
				on expenselink.idparent = expenseprofservice.idexp
			WHERE #expense2014.idreg=@idreg 
				and isnull(movkind,0) <> 2

		OPEN cursoreexpense
		FETCH NEXT FROM cursoreexpense
			INTO @employtaxamount, @idexp, @idser, @au001causale
	
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
					

			SELECT @au009_010ritIRPEF= ISNULL(SUM(expensetaxofficial.employtax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')='N'-- IS NULL
					AND expensetaxofficial.stop IS NULL

			SELECT  @au021ritprevidenzialedip = isnull(SUM(expensetaxofficial.employtax),0),
				@au020ritprevidenzialeamm = isnull(SUM(expensetaxofficial.admintax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
				AND tax.taxkind = 3
				AND expensetaxofficial.stop IS NULL

	--AUXXX019 Causale
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', @contaPrestazioni, '001', @au001causale)

	-- AUX0022 Ammontare lordo corrisposto = Imponibile Lordo SUM (feegross) di quel percipiente.
	set @au004_ammontarelordocorrisposto=0
	
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

	-- calcola @au004_ammontarelordocorrisposto

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


			SELECT @au004_ammontarelordocorrisposto = 

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
				SET @au004_ammontarelordocorrisposto = @imponibilereale
				
			END
			
			set @quota_contratto =  @au004_ammontarelordocorrisposto/@imponibilereale 

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
			
			SELECT  @au004_ammontarelordocorrisposto = 
				ROUND(@quota_contratto*(isnull(@spesededucibilifis,0)+isnull(@imponibilereale,0) ),2)

		END
		ELSE
		BEGIN --MOV. DI SPESA
			SELECT @au004_ammontarelordocorrisposto = 
				MAX(ET.taxablegross)
				FROM expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
		END
	END
		
	set @au004_ammontarelordocorrisposto= isnull(@au004_ammontarelordocorrisposto,0)
		
	INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '004', @au004_ammontarelordocorrisposto)

-- AUXXX005 Somme non soggette a ritenuta per regime convenzionale
-- leggere il feegross delle prestazioni che hanno la ritenuta IRPEF STRANIERI con convenzione. Tali prestazioni hanno ritenuta a zero
	SET @au005SommeNonSoggetteARitenutaPerRegimeConvenzionale=0
	SELECT @au005SommeNonSoggetteARitenutaPerRegimeConvenzionale = ISNULL(SUM(taxablenet),0)
		FROM expensetaxofficial 
		JOIN tax 
			ON tax.taxcode = expensetaxofficial.taxcode
		WHERE expensetaxofficial.idexp = @idexp 
			AND tax.taxkind = 1
			AND taxref ='07_IRPEF_FC'
			AND expensetaxofficial.stop IS NULL
	
	if (@au005SommeNonSoggetteARitenutaPerRegimeConvenzionale <> 0) 
	BEGIN
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '005', @au005SommeNonSoggetteARitenutaPerRegimeConvenzionale)
	END
---AUX0025 = Imponibile Lordo SUM (feegross) - Imponibile Netto (SUM(taxablenet) da expensetax where (taxkind=1 ossia fiscali)
	set @au007_AltreSommeNonSoggetteARitenuta=0
	SET @au007_AltreSommeNonSoggetteARitenuta = 
					@au004_ammontarelordocorrisposto
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
					- @au005SommeNonSoggetteARitenutaPerRegimeConvenzionale
					
	-- mettiamo 3 se diverso da zero 
	if (@au007_AltreSommeNonSoggetteARitenuta <> 0) 
	BEGIN
		--- AUXXX006 Codice NP Vale sempre 3 
		--- AUXXX007 Altre Somme Non Soggette a Ritenuta
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, intero) VALUES(@progrCom, 'AU', @contaPrestazioni, '006', 3)
		INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '007', @au007_AltreSommeNonSoggetteARitenuta)
	END
	
 


--	AUXXX008 Imponibile
--	AUXXX008 = AUXXX004 - AUXXX005 - AUXXX007
	SET @au008imponibile = @au004_ammontarelordocorrisposto - @au005SommeNonSoggetteARitenutaPerRegimeConvenzionale-@au007_AltreSommeNonSoggetteARitenuta

	INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, '008', @au008imponibile)
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
				SET @colonna = '010' --AUXXX010 Ritenute a titolo di imposta
				set @SS003002 = isnull(@SS003002, 0) + isnull(@au009_010ritIRPEF, 0)
			END
			ELSE
			BEGIN
				SET @colonna = '009' --AUXXX009 Ritenute a titolo di acconto
				set @SS003001 = isnull(@SS003001, 0) + isnull(@au009_010ritIRPEF, 0)
			END
	--AUXXX009 Ritenute a titolo di acconto
	--AUXXX010 Ritenute a titolo di imposta
			INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimfisc) VALUES(@progrCom, 'AU', @contaPrestazioni, @colonna, @au009_010ritIRPEF)

	--AUXXX020 Contributi previdenziali a carico del soggetto erogante
			IF (@au020ritprevidenzialeamm <> 0)
			BEGIN
				INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimprev)  VALUES(@progrCom, 'AU', @contaPrestazioni, '020', @au020ritprevidenzialeamm)
			END
	--AUXXX021 Contributi previdenziali a carico del percipiente
			IF (@au021ritprevidenzialedip <> 0)
			BEGIN
				INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimprev)  VALUES(@progrCom, 'AU', @contaPrestazioni, '021', @au021ritprevidenzialedip)
			END

			declare @au022speseRimborsate dec(19,2)
			set @au022speseRimborsate=0
			IF (@ycon is not null)  -- si tratta di un contratto occasionale
				select  @au022speseRimborsate =  ISNULL( (SELECT P_refund_lastyear  from #annualpayedrefundH),0)

			set  @au022speseRimborsate = @au022speseRimborsate * @quota_contratto
	--AUXXX022 Spese rimborsate
			IF (@au022speseRimborsate <> 0)
			BEGIN
				INSERT INTO #recHNonArrot (progr, quadro, riga, colonna, decimprev)  VALUES(@progrCom, 'AU', @contaPrestazioni, '022', @au022speseRimborsate)
			END

			SET @contaPrestazioni = @contaPrestazioni + 1
	
			FETCH NEXT FROM cursoreexpense
				INTO @employtaxamount, @idexp, @idser, @au001causale
		END
		CLOSE cursoreexpense
		DEALLOCATE cursoreexpense


		SET @progrCom = @progrCom + 1

		FETCH NEXT FROM registry_crs into @auA01cf, @idreg, @cognome,@codice_fiscale
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
			and (quadro<>'AU' or colonna <> '001')
			and (colonna <> '006')
			and progr = @progr
			and riga = 1

		set @riga = 1

		set @cursore = cursor for 
			select distinct stringa
			from #recHNonArrot 
			where progr = @progr and quadro='AU' and colonna = '001'
			
		open @cursore
	
		fetch next from @cursore into @causale
		while @@fetch_status = 0 
		begin
			insert into #recordH (progr, quadro, riga, colonna, stringa)
				values (@progr, 'AU', @riga, '001', @causale)
			


			insert into #recordH (progr, quadro, riga, colonna, decimale)
				select @progr, #recHNonArrot.quadro, @riga, #recHNonArrot.colonna, sum(#recHNonArrot.decimfisc)
				from #recHNonArrot 
				join #recHNonArrot rif on #recHNonArrot.progr = rif.progr and #recHNonArrot.riga = rif.riga
				where rif.progr = @progr
				and isnull(rif.stringa,'') = isnull(@causale,'')
				and rif.quadro = 'AU'
				and rif.colonna = '001'
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
				and rif.colonna = '001'
				and #recHNonArrot.decimprev is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna
				having ( sum(#recHNonArrot.decimprev)) <> 0
				
				insert into #recordH (progr, quadro, riga, colonna, intero)
				select distinct @progr, #recHNonArrot.quadro, @riga, #recHNonArrot.colonna,  #recHNonArrot.intero
				from #recHNonArrot 
				WHERE #recHNonArrot.intero is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna = '006'
				and #recHNonArrot.progr = @progr
				and exists (select * from #recordH r1 where r1.quadro = 'AU'
				and r1.colonna = '007'
				and r1.progr = @progr AND r1.riga = @riga  AND ISNULL(r1.decimale,0) <> 0)
				
			set @riga = @riga + 1
	
			fetch next from @cursore into @causale
		end

		set @progr = @progr + 1
	end


SELECT * FROM #recordh 


DROP TABLE #annualpayedrefundH
DROP TABLE #recordh
DROP TABLE #recHNonArrot
DROP TABLE #expense2014

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

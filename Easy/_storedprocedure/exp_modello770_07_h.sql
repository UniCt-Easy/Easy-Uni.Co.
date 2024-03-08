
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_07_h]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_07_h]
GO

create PROCEDURE [exp_modello770_07_h]
AS BEGIN
-- Il quadro H è per il lavoro autonomo
	CREATE TABLE #recordh
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data datetime
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
	SELECT @maxexpensephase = MAX(nphase) FROM expensephase
	CREATE TABLE #expense2006
	(
		idexp varchar(72),
		idreg int,
		idser varchar(10),
		employtaxamount decimal(19,2),
		motive770 varchar(10)
	)

	INSERT INTO #expense2006
		(
			idexp,--1
			idreg,--2
			idser,--3
			employtaxamount--6
		)
		SELECT
			expense.idexp,--1
			expense.idreg,--2
			expense.idser,--3
			ISNULL((SELECT SUM(employtax) FROM expensetax WHERE expensetax.idexp = expense.idexp),0)
		FROM expense 
		join payment 
			on payment.ypay=expense.ypay
			and payment.npay=expense.npay
		join paymenttransmission
			on paymenttransmission.ypaymenttransmission=payment.ypaymenttransmission
			and paymenttransmission.npaymenttransmission=payment.npaymenttransmission
		JOIN service on service.idser=expense.idser
		JOIN registry ON expense.idreg = registry.idreg
		WHERE 	registry.idregistryclass <> '10'
			AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg)
			AND year(paymenttransmission.transmissiondate)=2006
			AND service.rec770kind = 'H'
			AND (expense.amount
			+ ISNULL(
				(SELECT SUM(amount) FROM expensevar
				WHERE expensevar.idexp = expense.idexp
				AND expensevar.yvar <= 2006
				AND ISNULL(autokind,'') <> 'RITEN')
			,0)) > 0
			and exists (select * from expensetax where expensetax.idexp=expense.idexp)

	update #expense2006 set motive770 = motive770service.idmot
		from motive770service 
		where motive770service.idser = #expense2006.idser
			AND motive770service.ayear = 2007

	declare @cognome varchar(60)

	DECLARE registry_crs CURSOR FOR 
		SELECT DISTINCT isnull(cf,p_iva), #expense2006.idreg, surname FROM #expense2006
		join registry on registry.idreg = #expense2006.idreg
		order by surname
	OPEN registry_crs
	
	SET @progrCom = 1
	FETCH NEXT FROM registry_crs into @au1cf, @idreg, @cognome

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
			@au14foreigncf = registry.foreigncf,
			@au2cognomePercipiente = coalesce(registry.surname, registry.title),
			@au3nomePercipiente = registry.forename,
			@au4gender = registry.gender,
			@au5birthdate = registry.birthdate,
			@au6birthplace = coalesce(geo_city.title, geo_nation.title),
			@au7birthprovince = geo_country.province
			FROM registry 
			LEFT OUTER JOIN geo_city ON registry.idcity = geo_city.idcity
			LEFT OUTER JOIN geo_country ON geo_city.idcountry = geo_country.idcountry
			LEFT OUTER JOIN geo_nation ON registry.idnation = geo_nation.idnation
			WHERE registry.idreg = @idreg

		SELECT @codfiscEnte = cf FROM license
	--1 Tipo record
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '01', 'H')
	--2 Codice fiscale del soggetto dichiarante
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '02', @codfiscEnte)
	--3 Progressivo comunicazione
		INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'HRH', 1, '03', @progrCom)
	--6 Codice fiscale del percipiente
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '06', @au1cf)
		DECLARE @cfsoftwarehouse varchar(16)
		SET @cfsoftwarehouse = '05587470724'
	--9 Identificativo del produttore del software (codice fiscale)
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'HRH', 1, '09', @cfsoftwarehouse)
	
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

		SELECT TOP 1 
			@au8location = coalesce(geo_city.title, geo_nation.title, registryaddress.location),
			@au9provincia = geo_country.province,
			@au10codiceRegione = geo_country_agency.value,
			@au17codiceNazione = isnull(geo_nation_agency.value, case registryaddress.flagforeign when 'S' then '-1' end),
			@au11address = registryaddress.address
			FROM registryaddress 
			LEFT OUTER JOIN geo_city
				ON registryaddress.idcity = geo_city.idcity
			LEFT OUTER JOIN geo_country
				ON geo_country.idcountry = geo_city.idcountry
			LEFT OUTER JOIN geo_country_agency
				ON geo_country.idcountry = geo_country_agency.idcountry
				AND geo_country_agency.idagency = 5
				AND geo_country_agency.idcode = 1
			LEFT OUTER JOIN geo_nation
				ON registryaddress.idnation = geo_nation.idnation
			LEFT OUTER JOIN geo_nation_agency
				ON geo_nation.idnation = geo_nation_agency.idnation
				AND geo_nation_agency.idagency = 5
				AND geo_nation_agency.idcode = 1
			WHERE registryaddress.idreg = @idreg
				AND registryaddress.start <= {d '2006-12-31'}
				AND (registryaddress.stop IS NULL OR registryaddress.stop >= {d '2006-12-31'})
			ORDER BY
			CASE idaddresskind
				WHEN 'STAND' THEN 1
				WHEN 'DOMFI' THEN 2
				ELSE 3
			END

	--AU001001 Codice fiscale
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '001', @au1cf)
	--AU001002 Cognome o denominazione
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '002', @au2cognomePercipiente)
	--AU001003 Nome
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '003', @au3nomePercipiente)
	--AU001004 Sesso
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '004', @au4gender)
	--AU001005 Data di nascita
		INSERT INTO #recordh (progr, quadro, riga, colonna, data)    VALUES(@progrCom, 'AU', 1, '005', @au5birthdate)
	--AU001006 Comune (o Stato estero) di nascita
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '006', @au6birthplace)
	--AU001007 Provincia di nascita (sigla)
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '007', @au7birthprovince)

		DECLARE @au15locationestera varchar(160)
		DECLARE @au16addressestero varchar(160)
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
			--Mi ricavo il domicilio fiscale italiano
			SELECT TOP 1 
				@au8location = coalesce(geo_city.title, registryaddress.location),
				@au9provincia = geo_country.province,
				@au10codiceRegione = geo_country_agency.value,
				@au11address = registryaddress.address
				FROM registryaddress 
				LEFT OUTER JOIN geo_city
					ON registryaddress.idcity = geo_city.idcity
				LEFT OUTER JOIN geo_country
					ON geo_country.idcountry = geo_city.idcountry
				LEFT OUTER JOIN geo_country_agency
					ON geo_country.idcountry = geo_country_agency.idcountry
					AND geo_country_agency.idagency = 5
					AND geo_country_agency.idcode = 1
				WHERE registryaddress.idreg = @idreg
					AND registryaddress.start <= {d '2006-12-31'}
					AND (registryaddress.stop IS NULL OR registryaddress.stop >= {d '2006-12-31'})
					AND idaddresskind = 'DOMFI'
		END

	--AU001008 Comune
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '008', @au8location)
	--AU001009 Provincia (sigla)
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '009', @au9provincia)
		-- Il campo AU001010 non viene mai riempito in quanto la causale (campo AU001016) vale sempre A o M e mai N (condizione per cui tale campo deve essere valorizzato)


		if exists (select * from #expense2006 where idreg=@idreg and motive770='N')
		begin
	--AU001009 Provincia (sigla)
			INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', 1, '010', @au10codiceRegione)
		end
	--AU001011 Via e numero civico
		INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '011', @au11address)
		IF (@au17codiceNazione is not null)
		BEGIN
		-- I campi da AU001012 ad AU001015 vengono valorizzati qualora si tratti di persone residenti all'estero
	--AU001014 Codice di identificazione fiscale estero
			INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '014', @au14foreigncf)
	--AU001015 Località di residenza estera
			INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '015', @au15locationestera)
	--AU001016 Via e numero civico
			INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', 1, '016', @au16addressestero)
			-- N.B. il codiceNazione deve essere memorizzato come intero (come da specifiche del 770), sul DB il dato è memorizzato come varchar
			-- ma trattandosi di codice ISIN non ci sono problemi in quanto sono effettivamente valori numerici
	--AU001017 Codice stato estero
			INSERT INTO #recordh (progr, quadro, riga, colonna, intero) VALUES(@progrCom, 'AU', 1, '017', CONVERT(int,@au17codiceNazione))
		END

		DECLARE @employtaxamount decimal(19,2)
		DECLARE @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale decimal(19,2)
		DECLARE @au24imponibile decimal(19,2)
		DECLARE @idexp varchar(72)
		DECLARE @idser varchar(10)
		DECLARE @taxcodefiscale varchar(10)
		DECLARE @au25_26ritIRPEF decimal(19,2)
		DECLARE @au34ritprevidenzialedip decimal(19,2)
		DECLARE @au33ritprevidenzialeamm decimal(19,2)
		DECLARE @au18causale char(1)
		DECLARE cursoreexpense CURSOR FOR 
			SELECT 
				#expense2006.employtaxamount,
				#expense2006.idexp,
				#expense2006.idser,
				#expense2006.motive770
			FROM #expense2006
			left outer join expenseprofservice
				on #expense2006.idexp like expenseprofservice.idexp+'%'
			WHERE #expense2006.idreg=@idreg 
				and isnull(movkind,'pino')<>'IMPOS'
	
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
					AND tax.taxkind = 'F'
					AND tax.geoappliance IS NULL

			SELECT @au25_26ritIRPEF = isnull(SUM(expensetax.employtax),0)
				FROM expensetax
				JOIN tax
					ON tax.taxcode = expensetax.taxcode
				WHERE expensetax.idexp = @idexp
					AND tax.taxkind = 'F'
					AND tax.geoappliance IS NULL

			SELECT @au34ritprevidenzialedip = isnull(SUM(expensetax.employtax),0),
				@au33ritprevidenzialeamm = isnull(SUM(expensetax.admintax),0)
				FROM expensetax
				JOIN tax
					ON tax.taxcode = expensetax.taxcode
				WHERE expensetax.idexp = @idexp
				AND tax.taxkind = 'P'

	--AUXXX018 Causale
			INSERT INTO #recordh (progr, quadro, riga, colonna, stringa) VALUES(@progrCom, 'AU', @contaPrestazioni, '018', @au18causale)
			-- Il campo AU001017 non viene valorizzato in quanto il campo AU001016 vale sempre A o M e mai G o H e, nel contempo il campo 18 non viene valorizzato
--			INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '017', @ayear)

			IF (isnull(@au25_26ritIRPEF,0)=0) and (@au17codiceNazione is not null)-- AND (@au19imponibile > 0) AND (@au25_26ritIRPEF = 0)
			BEGIN
				SELECT @au22SommeNonSoggetteARitenutaPerRegimeConvenzionale = isnull(MAX(taxablegross),0)
					FROM expensetax
	                      		join tax
						ON tax.taxcode = expensetax.taxcode
					where expensetax.idexp = @idexp

	--AUXXX021 Ammontare lordo corrisposto
				INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '021', ROUND(ISNULL(@au22SommeNonSoggetteARitenutaPerRegimeConvenzionale,0),0,1))
	--AUXXX022 Somme non soggette a ritenuta per regime convenzionale
				INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '022', ROUND(ISNULL(@au22SommeNonSoggetteARitenutaPerRegimeConvenzionale,0),0,1))
			END 
			else 
			begin
				SELECT @au24imponibile = isnull(MAX(taxablegross),0)
					FROM expensetax
	                      		join tax
						ON tax.taxcode = expensetax.taxcode
					where expensetax.idexp = @idexp
					AND taxkind = 'F'
	--AUXXX021 Ammontare lordo corrisposto
				INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '021', ROUND(ISNULL(@au24imponibile,0),0,1))
	--AUXXX024 Imponibile
				INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '024', ROUND(ISNULL(@au24imponibile,0),0,1))
			end

			DECLARE @colonna varchar(3)
			IF (@taxcodefiscale = 'ACCONTO')
			BEGIN
				SET @colonna = '025' --AUXXX025 Ritenute a titolo di acconto
			END
			ELSE
			BEGIN
				SET @colonna = '026' --AUXXX026 Ritenute a titolo di imposta
			END
	--AUXXX025 Ritenute a titolo di acconto
	--AUXXX026 Ritenute a titolo di imposta
			INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, @colonna, ROUND(ISNULL(@au25_26ritIRPEF,0),0,1))

	--AUXXX033 Contributi previdenziali a carico del soggetto erogante
			INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '033', ROUND(ISNULL(@au33ritprevidenzialeamm,0),0))
	--AUXXX034 Contributi previdenziali a carico del percipiente
			INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '034', ROUND(ISNULL(@au34ritprevidenzialedip,0),0))

			declare @au35speseRimborsate dec(19,2)
			select @au35speseRimborsate = isnull(sum(amount),0)
				from casualcontractrefund s
				join expensecasualcontract m on s.ycon=m.ycon and s.ncon=m.ncon
				join casualrefund t on s.idlinkedrefund=t.idlinkedrefund
				where @idexp like idexp+'%' and deduction='P'

	--AUXXX035 Spese rimborsate
			INSERT INTO #recordh (progr, quadro, riga, colonna, intero)  VALUES(@progrCom, 'AU', @contaPrestazioni, '035', ROUND(ISNULL(@au35speseRimborsate,0),0))

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
	
	SELECT * FROM #recordh WHERE (stringa IS NOT NULL or intero IS NOT NULL or data IS NOT NULL)
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


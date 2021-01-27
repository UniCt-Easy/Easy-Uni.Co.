
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_17_b]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_17_b]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- exec exp_modello770_17_b 1,1,1
create PROCEDURE [exp_modello770_17_b]
(
	@numdichquadrog int,
	@numdichquadroh int,
	@numdichquadroi int
)
AS BEGIN

	declare @ayear int
	set @ayear=2016
	create table #recordb
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data datetime
	)
	DECLARE @2cf varchar(16)
	DECLARE @agencyname varchar(60) -- 60 è limite imposto per la compilazione del 770
	DECLARE @phonenumber varchar(20)
	DECLARE @fax varchar(20)
	DECLARE @email varchar(100)
	DECLARE @location varchar(40)
	DECLARE @country varchar(2)
	DECLARE @address varchar(35)
	DECLARE @cap varchar(5)
	SELECT
		@2cf = ISNULL(license.cf, license.p_iva),
		@agencyname = SUBSTRING(license.agencyname, 1, 60),
		@phonenumber = license.phonenumber,
		@fax = license.fax,
		@email = license.email,
		@location = SUBSTRING(isnull(geo_city.title, license.location), 1, 40),
		@country = license.country,
		@address = SUBSTRING(license.address1, 1, 35),
		@cap = license.cap
		FROM license
		left outer join geo_city on geo_city.idcity = license.idcity

	--declare @38codicecomuneente varchar(16)
	--select @38codicecomuneente=value from geo_city_agency where idagency=1 and idcity in (select idcity from license) and idcode=1

	DECLARE @manager_cf varchar(16)
	DECLARE @manager_surname varchar(24)
	DECLARE @manager_forename varchar(20)
	DECLARE @manager_gender char(1)
	DECLARE @manager_b_date datetime
	DECLARE @manager_b_city varchar(65)
	DECLARE @manager_b_country varchar(2)
	DECLARE @manager_r_cap varchar(5)
	DECLARE @manager_r_address_e varchar(35)
	DECLARE	@manager_r_code_e varchar(3)
	DECLARE @manager_r_nation_e varchar(24)
	DECLARE @manager_r_location_e varchar(24)

	DECLARE @manager_phonenumber varchar(20)
	DECLARE @idtrasmissiondocument varchar(10)

	SET @idtrasmissiondocument = '770'
	SELECT
		@manager_cf = cf,
		@manager_surname = SUBSTRING(surname,1,24),
		@manager_forename = SUBSTRING(forename,1,20),
		@manager_b_city = city,
		@manager_b_date = birthdate,
		@manager_gender = gender,
		@manager_b_country = province,
		@manager_phonenumber = phonenumber
	FROM trasmissionmanagerview
	WHERE idtrasmissiondocument = @idtrasmissiondocument AND ayear = (@ayear+1)

	declare @t varchar(12)
	declare @i int
	if @phonenumber is not null begin
		set @t = ''
		set @i=1
		while @i <= len(@phonenumber)
		begin
			if substring(@phonenumber, @i, 1) between '0' and '9'
				set @t = @t + substring(@phonenumber, @i, 1)
			set @i = @i + 1
		end
		set @phonenumber = @t
	end
	if @manager_phonenumber is not null begin
		set @t = ''
		set @i=1
		while @i <= len(@manager_phonenumber) and @i<100
		begin
			if substring(@manager_phonenumber, @i, 1) between '0' and '9'
				set @t = @t + substring(@manager_phonenumber, @i, 1)
			set @i = @i + 1
		end
		set @manager_phonenumber = @t
	end
	if @fax is not null begin
		set @t = ''
		set @i=1
		while @i <= len(@fax) and @i<100
		begin
			if substring(@fax, @i, 1) between '0' and '9'
				set @t = @t + substring(@fax, @i, 1)
			set @i = @i + 1
		end 
		set @fax = @t
	end
	DECLARE @lastday datetime
	SET @lastday = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)
DECLARE @lenvalue int
SET @lenvalue = 3
-- Dati relativi alla residenza anagrafica.

	SELECT TOP 1
		@manager_r_address_e = SUBSTRING(registryaddress.address,1,35), 
		@manager_r_location_e = SUBSTRING(registryaddress.location,1,24),
		@manager_r_code_e = 
		CASE
				WHEN DATALENGTH(ISNULL(geo_nation_agency.value,'')) <= @lenvalue
				THEN SUBSTRING(REPLICATE('0',@lenvalue),1,@lenvalue - DATALENGTH(ISNULL(geo_nation_agency.value,'')))		+ ISNULL(geo_nation_agency.value,'')
				ELSE SUBSTRING(geo_nation_agency.value,1,@lenvalue)
			END,
		@manager_r_nation_e = SUBSTRING(geo_nation.title,1,24)
		FROM registryaddress
		JOIN address 
			ON address.idaddress = registryaddress.idaddresskind
		JOIN trasmissionmanager
			ON registryaddress.idreg = trasmissionmanager.idreg
		LEFT OUTER JOIN geo_nation
			ON geo_nation.idnation = registryaddress.idnation
		JOIN geo_nation_agency
				ON geo_nation.idnation = geo_nation_agency.idnation
				AND geo_nation_agency.idagency = 5
				AND geo_nation_agency.idcode = 1
		WHERE trasmissionmanager.ayear = (@ayear+1)
			AND trasmissionmanager.idtrasmissiondocument = @idtrasmissiondocument
			AND registryaddress.start <= @lastday
			AND (registryaddress.stop IS NULL OR registryaddress.stop >= @lastday)
			AND ISNULL(flagforeign,'N') = 'S'
		ORDER BY
		CASE codeaddress
			WHEN '07_SW_DOM' THEN 1
			WHEN '07_SW_DEF' THEN 2
			ELSE 3
		END

	DECLARE @7cfsoftwarehouse varchar(16)
	SET @7cfsoftwarehouse = '02890460781'
	-- Il codice attività è stato preso dalla tabella ATECOFIN2004 delle attività produttive.
	-- Consultare il sito del Ministero delle Finanze (www.finanze.gov.it) o dell'Agenzia delle Entrate
	-- (www.agenziaentrate.gov.it)
	DECLARE @codiceattivita varchar(6)
	SELECT @codiceattivita = REPLACE(cudactivitycode,'.','')  FROM config WHERE ayear = @ayear
	--1 Tipo record
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '001', 'B')
	--2 Codice fiscale del soggetto dichiarante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '002', @2cf)
	--3 Progressivo modulo
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '003', 1)
	--7 Identificativo del produttore del software (codice fiscale)
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '007', @7cfsoftwarehouse)
--8-8Comunicazione di mancata corrispondenza dei dati da trasmettere con quelli risultanti dalla dichiarazione
	--8 Flag conferma
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '008', 1)
--Dati del Frontespizio
--Dati relativi al Sostituto
	--9 Tipologia del sostituto, mettiamo il valore costante 1, che corrisponde al modello semplificato
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '009', 1)
	--15 Denominazione
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '015', @agencyname)
	--23 Codice attività
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '023', @codiceattivita)
	--24 Indirizzo di posta elettronica
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '024', @email)
	--25 Telefono o Fax
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '025', @phonenumber)
--Dati Soggetti diversi da persona fisica


--Codici statistici (stato, natura e situazione) Stato: il relativo codice deve essere rilevato dalla tabella SA. 
--Natura giuridica: il relativo codice deve essere rilevato dalla tabella SB. 
--La tabella è comprensiva di tutti i codici relativi alla diversa modulistica dichiarativa 
--ed utilizzabili solo in funzione della specificità di ogni singolo modello. Pertanto, 
--il soggetto che compila la dichiarazione avrà cura di individuare il codice ad esso riferibile 
--in relazione alla natura giuridica rivestita. Situazione: il relativo codice deve essere rilevato dalla tabella SC

-- 29 stato
	-- STATO DELLA SOCIETÀ O ENTE ALL’ATTO DELLA PRESENTAZIONE DELLA DICHIARAZIONE
	--TABELLA SB - CLASSIFICAZIONE GENERALE NATURA GIURIDICA
	--1) Soggetto in normale attività 2) Soggetto in liquidazione per cessazione di attività
	--3) Soggetto in fallimento o in liquidazione coatta amministrativa 4) Soggetto estinto

	-- 1) Soggetto in normale attività 
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '029', 1)  
	--30 Natura giuridica
	---- 14 Soggetto che sottoscrive la dichiarazione per conto di una pubblica amministrazione 
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '030', 14)
	-- 31 situazione
	-- SITUAZIONE DELLA SOCIETÀ O ENTE RELATIVAMENTE AL PERIODO D’IMPOSTA CUI SI RIFERISCE LA DICHIARAZIONE
	-- 6) Periodo normale d’imposta

	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '031', 6)  

	----35 Comune della sede legale
	--INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '035', @location)
	----36 Sigla della provincia della sede legale
	--INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '036', @country)
	----37 C.A.P. del comune della sede legale
	--INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '037', @cap)
	----38 Codice comune
	--INSERT INTO #recordb (progr, quadro, riga, colonna, stringa)  VALUES(1, 'HRB', 1, '038', @38codicecomuneente)
	----39 Indirizzo della sede legale: frazione, via e numero civico
	--INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '039', @address)
	----46 Stato
	--INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '046', 1)
	----47 Situazione
	--INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '047', 6)

	--Dati relativi al rappresentante firmatario della dichiarazione.
	--36 Codice fiscale del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '036', @manager_cf)
	--37 Codice carica del rappresentante
	--INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '037', 14)
	--41 Cognome del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '041', @manager_surname)
	--42 Nome del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '042', @manager_forename)
	--43 Sesso del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '043', @manager_gender)
	--44 Data di nascita del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, data)    VALUES(1, 'HRB', 1, '044', @manager_b_date)
	--45 Comune o stato estero di nascita del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '045', @manager_b_city)
	--46 Sigla della provincia di nascita del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '046', @manager_b_country)
-- Residenza all'estero

-- 47	Codice stato estero
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero) VALUES(1, 'HRB', 1, '047',  CONVERT(INT,@manager_r_code_e) )
-- 48	Stato federato, provincia, contea
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '048', @manager_r_nation_e)
-- 49	Località di residenza
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '049', @manager_r_location_e)
-- 50	Indirizzo estero
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '050', @manager_r_address_e)
-- 51	telefono - cellulare del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '051', @manager_phonenumber)

-- 53	Codice fiscale societa o ente dichiarante
INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '053', @2cf)
	

	

-- Firma della Dichiarazione - Prospetti compilati
 
	--058 Casella relativa a certificazioni lavoro dipendente ed assimilati
	IF (@numdichquadrog > 0)
		INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '058', 1)

	--059 Casella relativa a certificazioni lavoro autonomo e provvigioni
	IF (@numdichquadroh > 0)
		INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '059', 1)
	
	--061 Casella prospetto ST
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '061', 0)
	--062 Casella prospetto SV
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '062', 0)
	--063 Casella prospetto SX
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '063', 0)
	--064 Casella prospetto SY   -- qui non deve essere 0 ma si dovrebbe verificare se pignoramenti sono stati fatti
	IF (@numdichquadroi > 0)
		INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '064', 1)
	ELSE
		INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '064', 0)

	-- 76 Firma del dichiarante
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '076', 1)
		
	SELECT * FROM #recordb WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec exp_modello770_17_b 1,1

 


/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_07_b]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_07_b]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE [exp_modello770_07_b]
(
	@numdichquadrog int,
	@numdichquadroh int
)
AS BEGIN
	declare @ayear int
	set @ayear=2006
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
	DECLARE @agencyname varchar(60) -- 60 � limite imposto per la compilazione del 770
	DECLARE @phonenumber varchar(20)
	DECLARE @fax varchar(20)
	DECLARE @email varchar(100)
	DECLARE @location varchar(40)
	DECLARE @country varchar(2)
	DECLARE @address varchar(35)
	DECLARE @cap varchar(5)
	SELECT
		@2cf = ISNULL(cf,p_iva),
		@agencyname = SUBSTRING(agencyname,1,60),
		@phonenumber = phonenumber,
		@fax = fax,
		@email = email,
		@location = SUBSTRING(location,1,40),
		@country = country,
		@address = SUBSTRING(address1,1,35),
		@cap = cap
		FROM license

	declare @39codicecomuneente varchar(16)
	select @39codicecomuneente=value from geo_city_agency where idagency=1 and idcity in (select idcity from license) and idcode=1

	DECLARE @manager_cf varchar(16)
	DECLARE @manager_surname varchar(24)
	DECLARE @manager_forename varchar(20)
	DECLARE @manager_gender char(1)
	DECLARE @manager_b_date datetime
	DECLARE @manager_b_city varchar(65)
	DECLARE @manager_b_country varchar(2)
	DECLARE @manager_r_city varchar(65)
	DECLARE @manager_r_country varchar(2)
	DECLARE @manager_r_cap varchar(5)
	DECLARE @manager_r_address varchar(35)
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
	SELECT TOP 1
		@manager_r_city = ISNULL(geo_city.title,registryaddress.location),
		@manager_r_country = geo_country.province,
		@manager_r_cap = registryaddress.cap,
		@manager_r_address = SUBSTRING(registryaddress.address,1,35)
		FROM registryaddress
		JOIN trasmissionmanager
		ON registryaddress.idreg = trasmissionmanager.idreg
		LEFT OUTER JOIN geo_city
		ON geo_city.idcity = registryaddress.idcity
		LEFT OUTER JOIN geo_country
		ON geo_country.idcountry = geo_city.idcountry
		WHERE trasmissionmanager.ayear = (@ayear+1)
		AND trasmissionmanager.idtrasmissiondocument = @idtrasmissiondocument
		AND registryaddress.start <= @lastday
		AND (registryaddress.stop IS NULL OR registryaddress.stop >= @lastday)
		ORDER BY
		CASE idaddresskind
			WHEN 'DOMFI' THEN 1
			WHEN 'STAND' THEN 2
			ELSE 3
		END
	DECLARE @7cfsoftwarehouse varchar(16)
	SET @7cfsoftwarehouse = '05587470724'
	-- Il codice attivit� � stato preso dalla tabella ATECOFIN2004 delle attivit� produttive.
	-- Consultare il sito del Ministero delle Finanze (www.finanze.gov.it) o dell'Agenzia delle Entrate
	-- (www.agenziaentrate.gov.it)
	DECLARE @codiceattivita varchar(5)
	SET @codiceattivita = '80301'
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
--9-12Tipo di dichiarazione
	--12 Eventi eccezionali
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '012', 0)
--13-22Dati del Contribuente
	--15 Denominazione
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '015', @agencyname)
	--19 Codice attivit�
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '019', @codiceattivita)
	--20 Indirizzo di posta elettronica
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '020', @email)
	--21 Telefono - Prefisso e numero
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '021', @phonenumber)
	--22 FAX - Prefisso e numero
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '022', @fax)
--Dati anagrafici Persona Fisica
--23-32La sezione (e i controlli in essa descritti) deve essere presente se presenti i campi 13, 14.
--Dati Soggetti diversi da persona fisica
--33-52La sezione (e i controlli in essa descritti) deve essere presente se presente il campo 15.
	--33 Natura giuridica
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '033', 15)
	--35 Comune della sede legale
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '035', @location)
	--36 Sigla della provincia della sede legale
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '036', @country)
	--37 Indirizzo della sede legale: frazione, via e numero civico
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '037', @address)
	--38 C.A.P. del comune della sede legale
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '038', @cap)
	--39 Codice comune
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa)  VALUES(1, 'HRB', 1, '039', @39codicecomuneente)
	--46 Stato
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '046', 1)
	--47 Situazione
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '047', 6)
--53-74Firma della Dichiarazione
	--54 Firma del dichiarante
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '054', '1')
--75-81Redazione della dichiarazione
	--75 Redazione della dichiarazione
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '075', 1)
	--76 Numero comunicazioni relative a certificazioni lavoro dipendente ed assimilati
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '076', @numdichquadrog)
	--77 Numero comunicazioni relative a certificazioni lavoro autonomo e provvigioni
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '077', @numdichquadroh)
	--78 Casella prospetto ST
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '078', 0)
	--79 Casella prospetto SX
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '079', 0)
	--80 Presenza di modello 770 ordinario 2007
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '080', 0)
--Dati relativi al rappresentante firmatario della dichiarazione.
--106-126La sezione � obbligatoria per i contribuenti diversi dalle persone fisiche
	--106 Codice fiscale del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '106', @manager_cf)
	--107 Codice carica del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '107', 14)
	--111 Cognome del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '111', @manager_surname)
	--112 Nome del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '112', @manager_forename)
	--113 Sesso del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '113', @manager_gender)
	--114 Data di nascita del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, data)    VALUES(1, 'HRB', 1, '114', @manager_b_date)
	--Comune o stato estero di nascita del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '115', @manager_b_city)
	--116 Sigla della provincia di nascita del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '116', @manager_b_country)
	--117 Comune di residenza anagrafica del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '117', @manager_r_city)
	--118 Sigla della provincia di residenza del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '118', @manager_r_country)
	--119 Cap del comune di residenza del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '119', @manager_r_cap)
	--120 Frazione, via e numero civico del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '120', @manager_r_address)
	--121 Numero di telefono del rappresentante
	INSERT INTO #recordb (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRB', 1, '121', @manager_phonenumber)
--	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '214', '1')--Firma del Presidente o dei componenti dell'organo di controllo
--	INSERT INTO #recordb (progr, quadro, riga, colonna, intero)  VALUES(1, 'HRB', 1, '202', '1')--Le universit� presentano solo il modello 770 SEMPLIFICATO (Numero Sezione)
	
	SELECT * FROM #recordb WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


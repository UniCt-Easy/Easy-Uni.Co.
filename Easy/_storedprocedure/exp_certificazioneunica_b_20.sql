
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_b_20]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_b_20]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- exec exp_certificazioneunica_b_20 1,1,'S'
create PROCEDURE [exp_certificazioneunica_b_20]
(
	@numdichquadrog int,
	@numdichquadroh int,
	@print char(1)  -- vale S per la stampa N altrimenti
)
AS BEGIN

	declare @ayear int
	set @ayear=2019
	create table #recordb
	(
		progr int,
		modulo int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		intero int,
		data datetime,
		decimale decimal(19,2)
	)
	DECLARE @2cf varchar(16)
	DECLARE @p_iva varchar(11)
	DECLARE @agencyname varchar(60) -- 60 è limite imposto per la compilazione del 770
	DECLARE @phonenumber varchar(20)
	DECLARE @fax varchar(20)
	DECLARE @email varchar(100)
	DECLARE @location varchar(40)
	DECLARE @country varchar(2)
	DECLARE @address varchar(35)
	DECLARE @cap varchar(5)
	SELECT
		@2cf = license.cf,
		@p_iva = license.p_iva,
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

	declare @38codicecomuneente varchar(16)
	select @38codicecomuneente=value from geo_city_agency where idagency=1 and idcity in (select idcity from license) and idcode=1

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
	DECLARE @manager_annotations varchar(50)
	DECLARE @idtrasmissiondocument varchar(20)

	SET @idtrasmissiondocument = 'certificazioneunica'
	SELECT
		@manager_cf = cf,
		@manager_surname = SUBSTRING(surname,1,24),
		@manager_forename = SUBSTRING(forename,1,20),
		@manager_b_city = city,
		@manager_b_date = birthdate,
		@manager_gender = gender,
		@manager_b_country = province,
		@manager_phonenumber = phonenumber,
		@manager_annotations = annotations
	FROM trasmissionmanagerview
	WHERE idtrasmissiondocument = @idtrasmissiondocument AND ayear = (@ayear+1)


	

	declare @t varchar(100)
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
 
DECLARE @HRB016 varchar(50)
	SELECT  @HRB016 = COALESCE(@phonenumber,@fax)
	
	DECLARE @7cfsoftwarehouse varchar(16)
	SET @7cfsoftwarehouse = '02890460781'
	-- Il codice attività è stato preso dalla tabella ATECOFIN2004 delle attività produttive.
	-- Consultare il sito del Ministero delle Finanze (www.finanze.gov.it) o dell'Agenzia delle Entrate
	-- (www.agenziaentrate.gov.it)
	DECLARE @codiceattivita varchar(6)
	SELECT @codiceattivita = REPLACE(cudactivitycode,'.','')  FROM config WHERE ayear = @ayear
	--1 Tipo record
	INSERT INTO #recordb (progr, modulo,quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '001', 'B')
	--2 Codice fiscale del soggetto dichiarante
	INSERT INTO #recordb (progr, modulo,quadro, riga, colonna, stringa) VALUES(1, 1,'HRB', 1, '002', @2cf)
	--3 Progressivo modulo
	INSERT INTO #recordb (progr,  modulo,quadro, riga, colonna, intero)  VALUES(1,1, 'HRB', 1, '003', 1)
	--8 Identificativo del produttore del software (codice fiscale)
	INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, stringa) VALUES(1, 1,'HRB', 1, '008', @7cfsoftwarehouse)
    --Dati del sostituto d'Imposta
	--14 Denominazione
	INSERT INTO #recordb (progr,  modulo,quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '014', @agencyname)
	--15 Indirizzo di posta elettronica
	INSERT INTO #recordb (progr,  modulo, quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '015', @email)
	--16 Telefono o Fax
	INSERT INTO #recordb (progr,  modulo,quadro, riga, colonna, stringa) VALUES(1, 1,'HRB', 1, '016', @HRB016)
	 
	--Dati relativi al rappresentante firmatario della dichiarazione.
	--18 Codice fiscale del rappresentante
	INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '018', @manager_cf)
	--19 Codice carica del rappresentante
	INSERT INTO #recordb (progr,  modulo,quadro, riga, colonna, intero)  VALUES(1,1, 'HRB', 1, '019', 1)
	--20 Cognome del rappresentante
	INSERT INTO #recordb (progr,  modulo,quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '020', @manager_surname)
	--21 Nome del rappresentante
	INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '021', @manager_forename)
	--22 Codice fiscale società o ente dichiarante
	INSERT INTO #recordb (progr, modulo,  quadro, riga, colonna, stringa) VALUES(1,1, 'HRB', 1, '022', @2cf)
	--24 Numero comunicazioni relative a certificazioni 
	INSERT INTO #recordb (progr, modulo, quadro, riga, colonna, intero)  VALUES(1, 1,'HRB', 1, '024', ISNULL(@numdichquadrog,0)+ ISNULL(@numdichquadroh,0))
	--25 Casella Quadro CT Se barrata deve essere compilato il campo 23. Vale 1 in presenza del quadro CT. Noi non compiliamo il quadro CT
	--26 Firma 
    INSERT INTO #recordb (progr,  modulo,quadro, riga, colonna, intero)  VALUES(1,1, 'HRB', 1, '026', 1)
		
	IF( @print ='S') -- solo ai fini della stampa del modello
	BEGIN
		-- Dicitura con la firma del rappresentante firmatario, che appare nel frontespizio, quasi in tutti i casi è il Rettore, tranne alcuni 
		INSERT INTO #recordb (progr, modulo,quadro, riga, colonna, stringa) VALUES(1, 1, 'FIR', 1, '001', ISNULL(@manager_annotations,'F.to Il Rettore') )
	END
	SELECT * FROM #recordb WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL
END


 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
--exec exp_certificazioneunica_b_17 10,1
 

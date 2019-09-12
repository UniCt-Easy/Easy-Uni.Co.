if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_d_18]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_d_18]
GO

-- exec exp_certificazioneunica_d_18  19335 , 1, 'G', {d '2018-12-31'},'S'
CREATE PROCEDURE [exp_certificazioneunica_d_18]
 -- estraggo il record D relativo ad un determinato percipiente, il progressivo comunicazione
 -- indica l'ordine all'interno dei percipienti del sostituto d'imposta
(
	@idreg int,
	@progrCert int,
	@tipoRecord char(1),
	@datarif datetime,
	@print char(1)  -- vale S per la stampa N altrimenti
) 

AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2018

	declare @annoredditi int
	set @annoredditi = 2017

	declare @31dic16 datetime
	set @31dic16 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

create table #recordd
	(
		progr int,
		modulo int,
		quadro varchar(6),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		decimale decimal(19,2),
		intero int,
		data datetime
	)
-- Sezione dichiarativa	
	DECLARE @progrModulo int -- normalmente costante pari a uno
	DECLARE @codfiscEnte varchar(16)
	DECLARE @cf_italia   varchar(16) -- codice fiscale del percipiente
	DECLARE @cf_foreign  varchar(16) -- codice fiscale estero del percipiente
	SET @progrModulo = 1
	
	SELECT @cf_italia =  isnull(cf,p_iva), @cf_foreign = foreigncf FROM registry   -- codice fiscale italia e codeice fiscale estero
	WHERE registry.idreg = @idreg
	
	--------------------------------------------------------------
	---- Intestazione Record D, parte posizionale (da 1 89) ------
	--------------------------------------------------------------
	
	SELECT @codfiscEnte = cf FROM license
	--1 Tipo record
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'HRD', 1, '01', 'D')
	--2 Codice #recordd del sostituto d'imposta
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo,'HRD', 1, '02', @codfiscEnte)
	--3 Progressivo modulo
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, intero)  VALUES(@progrCert,@progrModulo, 'HRD', 1, '03', @progrModulo)
	--4Codice fiscale del percipiente
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'HRD', 1, '04', @cf_italia )
    --5 Progressivo Certificazione
	INSERT INTO #recordd (progr, modulo, quadro, riga, colonna, intero) VALUES(@progrCert, @progrModulo,'HRD', 1, '05', @progrCert)
	 
	-----------------------------------------------------------------------------------------------------------------------
	----- Sezione da compilare per la sostituzione di una singola certificazione già trasmessa e accolta (Campi 6 e 7) ----
	-----------------------------------------------------------------------------------------------------------------------
	--- (non la compiliamo)---
	--------------------------
	
	--------------------------------------------- 
	---- Record D, parte non  posizionale -------
	--------------------------------------------- 

	--------------------------------------------------------------------------------------------
	---- Dati relativi al datore di lavoro, ente pensionistico o altro sostituto d'imposta -----
	--------------------------------------------------------------------------------------------
	DECLARE @DA001001 VARCHAR(16)  -- Codice Fiscale
	DECLARE @DA001002 VARCHAR(60)  -- Cognome o Denominazione
	DECLARE @DA001003 VARCHAR(200) -- Nome (non utilizzato in quanto il sostituto d'imposta non è persona fisica)
	DECLARE @DA001004 VARCHAR(200) -- Comune di Residenza
	DECLARE @DA001005 VARCHAR(2)   -- Provincia di Residenza (sigla)
	DECLARE	@DA001006 VARCHAR(5)   -- CAP
	DECLARE @DA001007 VARCHAR(200) -- Via e numero civico
	DECLARE @DA001008 VARCHAR(50)  -- Telefono/Fax
	DECLARE @DA001009 VARCHAR(100) -- Indirizzo di posta elettronica del sostituto
	DECLARE @DA001010 VARCHAR(50)  -- Codice Attività
	DECLARE @DA001011 VARCHAR(50)  -- Codice Sede  (solo per chi ha più sedi)
	
	DECLARE @phonenumber varchar(20)
	DECLARE @fax varchar(20)
	SELECT
		@DA001001 = license.cf,     -- Codice Fiscale (non deve essere riportatata la Partita IVA)
		@DA001002 = SUBSTRING(license.agencyname, 1, 60),  -- Cognome o Denominazione
		@phonenumber = replace(replace(license.phonenumber,'/',''),'-',''),
		@fax = replace(replace(license.fax,'/',''),'-',''),
		@DA001009 = license.email,
		@DA001004 = SUBSTRING(isnull(geo_city.title, license.location), 1, 40),
		@DA001005 = license.country,
		@DA001007 = SUBSTRING(license.address1, 1, 35),
		@DA001006 = license.cap
	FROM license
	left outer join geo_city on geo_city.idcity = license.idcity
	
	SELECT  @DA001008 = 
	CASE 
		WHEN ((ISNULL(@phonenumber,'') <> '') AND (ISNULL(@fax,'') <> ''))  THEN  ISNULL(@phonenumber,'') 
		WHEN ((ISNULL(@phonenumber,'') = '') AND  (ISNULL(@fax,'') <> ''))   THEN  ISNULL(@fax,'') 
		WHEN ((ISNULL(@phonenumber,'') = '')  AND (ISNULL(@fax,'') = ''))  THEN NULL
		ELSE NULL 
	END
			 	 		-- (www.agenziaentrate.gov.it)	DECLARE @codiceattivita varchar(6)  --◾85.42.00◾85.42.00
	-- http://www.codiciateco.it/istruzione-universitaria-e-post-universitaria--accademie-e-conservatori/P-85-4-2-0
	-- 85.42.00 Istruzione universitaria e post-universitaria; accademie e conservatori
	-- istruzione di livello superiore all'istruzione secondaria che consente il conseguimento di una laurea, di un diploma universitario o di un titolo equipollente
	-- corsi di specializzazione post-laurea e corsi speciali di formazione post-universitaria

	SELECT  @DA001010 = REPLACE(cudactivitycode,'.','')  FROM config WHERE ayear = @annodichiarazione    
	 
	
	--2018	DA001	001	Codice fiscale	CF
	--2018	DA001	002	Cognome o denominazione	AN
	--2018	DA001	003	Nome	AN
	--2018	DA001	004	Comune di Residenza	AN
	--2018	DA001	005	Provincia di Residenza (sigla)	PR
	--2018	DA001	006	CAP	AN
	--2018	DA001	007	Via e numero civico	AN
	--2018	DA001	008	Telefono/Fax	AN
	--2018	DA001	009	Indirizzo di posta elettronica del sostituto	AN
	--2018	DA001	010	Codice Attività	AN
	--2018	DA001	011	Codice Sede	AN (solo per chi ha più sedi)
	
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '001', @DA001001)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '002', @DA001002)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '004', @DA001004)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '005', @DA001005)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '006', @DA001006)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '007', @DA001007)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '008', @DA001008)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '009', @DA001009)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA001', 1, '010', @DA001010)
 
	--------------------------------------------------------------------------------------------
	------- Dati relativi al dipendente, pensionato o altro percettore delle somme -------------
	--------------------------------------------------------------------------------------------
	DECLARE @birthplace  varchar(200)
	DECLARE @birthnation varchar(200)
	DECLARE @birthprovince varchar(2)
	DECLARE @idcitynascita int
	
	DECLARE @DA002001 VARCHAR(50)
	DECLARE @DA002002 VARCHAR(100)
	DECLARE @DA002003 VARCHAR(100)
	DECLARE @DA002004 CHAR(1)
	DECLARE @DA002005 DATETIME
	DECLARE @DA002006 VARCHAR(200)
	DECLARE @DA002007 VARCHAR(2)
	DECLARE @DA002010 INT
 
	DECLARE @DA002020 VARCHAR(200)
	DECLARE @DA002021 VARCHAR(2)
	DECLARE @DA002022 VARCHAR(50)
	
	DECLARE @DA002024 VARCHAR(200)
	DECLARE @DA002025 VARCHAR(2)
	DECLARE @DA002026 VARCHAR(50)
	
	DECLARE @DA002040 VARCHAR(50)
	DECLARE @DA002041 VARCHAR(200)
	DECLARE @DA002042 VARCHAR(100)
	DECLARE @DA002044 VARCHAR(4)
	 
	
	SET @DA002001 = @cf_italia  -- inserisco il codice fiscale italia
	
	SELECT
	@birthnation =  geo_nation.title,
	@DA002002 = coalesce(registry.surname, registry.title),
	@DA002003 = registry.forename,
	@DA002004 = registry.gender,
	@DA002005 = registry.birthdate,
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
			SELECT
				@birthplace = geo_city.title,
				@birthprovince =  geo_country.province 
				FROM geo_city 
				LEFT OUTER JOIN geo_country ON geo_city.idcountry = geo_country.idcountry
				WHERE geo_city.idcity=@idcitynascita
		END
		
 

	IF (@birthplace IS NOT NULL)   
		BEGIN
			SET @DA002006 = @birthplace
			SET @DA002007 = ISNULL(@birthprovince,'EE')
		END
	  
	IF (@birthnation IS NOT NULL)   
		BEGIN
			SET @DA002006 = @birthnation
			SET @DA002007 = 'EE'
		END
		
----------------------------------------------
------------  LETTURA DEGLI INDIRIZZI --------
----------------------------------------------

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM' -- DOMICILIO FISCALE

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF' -- RESIDENZA

----------------------------------------------------
------------ DOMICILIO FISCALE ALL'1/1/2017 --------
----------------------------------------------------

DECLARE @STAND int
SELECT  @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT  @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @dateindi_01_gen_16 datetime
DECLARE @dateindi_01_gen_18 datetime

SET @dateindi_01_gen_16 = DATEADD(yy, @annoredditi - 2000, {d '2000-01-01'})
SET @dateindi_01_gen_18 = DATEADD(yy, @annodichiarazione - 2000, {d '2000-01-01'})

CREATE TABLE #address
(
    idaddresskind int,    codeaddress varchar(20),    idreg int,    address varchar(100),    location varchar(116),
    cap varchar(15),    province varchar(2),    idcity int,    idnation int,    nation varchar(65),    start datetime,
    stop datetime,	rif_address char(1),	codice_catastale varchar(4),	codice_iso_nazione varchar(4)
)

INSERT INTO #address
(
    idaddresskind,    codeaddress,    idreg,    address,    location,    cap,    province,    idcity,
    idnation,    nation,    start,    stop,    codice_catastale,    codice_iso_nazione
)
SELECT
    idaddresskind,     codeaddress,    idreg,    registryaddress.address,    ISNULL(geo_city.title,registryaddress.location),
    registryaddress.cap,    geo_country.province,    registryaddress.idcity,
    CASE
        WHEN flagforeign = 'N' THEN 1
        ELSE geo_nation.idnation
    END,
    CASE
        WHEN flagforeign = 'N' THEN 'ITALIA'
        ELSE geo_nation.title
    END,
    registryaddress.start,    registryaddress.stop,    G.value,    N.value
FROM registryaddress
LEFT OUTER JOIN geo_city				    ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country				    ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation				    ON geo_nation.idnation = registryaddress.idnation
JOIN  address							    ON address.idaddress = registryaddress.idaddresskind
LEFT OUTER JOIN geo_city_agency G  -- lettura del codice catastale
    ON  G.idcity = registryaddress.idcity	    AND G.idagency = 1 and G.idcode = 1
LEFT OUTER JOIN geo_nation_agency N -- eventuale nazione di residenza, se estero
    ON N.idnation = registryaddress.idnation	
    AND N.idagency = 5 -- ente ISO           
    AND N.idcode = 1 -- codifica nazioni ISO
    AND N.version = 1
    AND N.stop IS NULL
WHERE
((registryaddress.stop IS NULL AND registryaddress.active <>'N' ) OR (registryaddress.stop >= @dateindi_01_gen_16))
    AND registryaddress.start =
    (SELECT MAX(cdi.start)
    FROM registryaddress cdi
    WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND (cdi.start <= @dateindi_01_gen_16)
        AND ((cdi.stop IS NULL AND  cdi.active <>'N') OR (cdi.stop >= @dateindi_01_gen_16))
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

SELECT @DA002020 = location FROM #address WHERE nation = 'ITALIA'
SELECT @DA002021 = province FROM #address WHERE nation = 'ITALIA'
SELECT @DA002022 = codice_catastale FROM #address WHERE nation = 'ITALIA'

DECLARE @IND001 VARCHAR(200)
SET @IND001 = @DA002002 + ' ' + ISNULL(@DA002003,'') -- Riga 1: cognome nome

DECLARE @IND002 VARCHAR(200)
SELECT @IND002 = address FROM #address  -- Riga 2: Via....

DECLARE @IND003 VARCHAR(300) -- Riga 3 Paese
if ((select TOP 1 nation from #address) ='ITALIA')
begin
	SELECT @IND003 = cap + ' ' + @DA002020 + '  ' + @DA002021 FROM #address 
end
else
begin
	SELECT @IND003 = nation FROM #address  
end



DECLARE @IND005 VARCHAR(200) -- Riga 5 EMAIL
SELECT @IND005= email from registryreference where idreg = @idreg and flagdefault='S'
if (@ind005 is null) begin
	select @ind005 =max(email) from  registryreference where idreg = @idreg and email is not null
end
 


----------------------------------------------------
------------ DOMICILIO FISCALE ALL'1/1/2018 --------
----------------------------------------------------
DELETE FROM #address

INSERT INTO #address
(
    idaddresskind,     codeaddress,    idreg,    address,    location,    cap,    province,    idcity,    idnation,
    nation,    start,    stop,    codice_catastale,    codice_iso_nazione
)
SELECT
    idaddresskind,    codeaddress,    idreg,    registryaddress.address,    ISNULL(geo_city.title,registryaddress.location),
    registryaddress.cap,    geo_country.province,    registryaddress.idcity,
    CASE
        WHEN flagforeign = 'N' THEN 1
        ELSE geo_nation.idnation
    END,
    CASE
        WHEN flagforeign = 'N' THEN 'ITALIA'
        ELSE geo_nation.title
    END,
    registryaddress.start,    registryaddress.stop,    G.value,    N.value
FROM registryaddress
LEFT OUTER JOIN geo_city		    ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country		    ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation		    ON geo_nation.idnation = registryaddress.idnation
JOIN  address					    ON address.idaddress = registryaddress.idaddresskind
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
((registryaddress.stop IS NULL AND registryaddress.active <>'N' ) OR (registryaddress.stop >= ISNULL(@datarif,@dateindi_01_gen_18)))
    AND registryaddress.start =
    (SELECT MAX(cdi.start)
    FROM registryaddress cdi
    WHERE cdi.idaddresskind = registryaddress.idaddresskind
        AND (cdi.start <= ISNULL(@datarif,@dateindi_01_gen_18))
        AND ((cdi.stop IS NULL AND cdi.active <>'N') OR (cdi.stop >= ISNULL(@datarif,@dateindi_01_gen_18)))
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
	  
SELECT @DA002024 = location FROM #address WHERE nation = 'ITALIA'
SELECT @DA002025 = province FROM #address WHERE nation = 'ITALIA'
SELECT @DA002026 = codice_catastale FROM #address WHERE nation = 'ITALIA'

--- SE NON E' AVVENUTO UN CAMBIO RESIDENZA ALLORA NON COMPILO I CAMPI DOMICILIO FISCALE ALL 1/1/ESERCIZIO CORRENTE
IF ((@DA002020 = @DA002024) AND (@DA002021 = @DA002025) AND (@DA002022 = @DA002026))
BEGIN
	SET @DA002024 = NULL
	SET @DA002025 = NULL
	SET @DA002026 = NULL
END
SELECT @DA002040 = @cf_foreign FROM #address WHERE nation <> 'ITALIA'
SELECT @DA002041 = location FROM #address WHERE nation <> 'ITALIA'
SELECT @DA002042 = address FROM #address WHERE nation <> 'ITALIA'
SELECT @DA002044 = codice_iso_nazione FROM #address WHERE nation <> 'ITALIA'

--select * from #address
	--2018	DA002	001	Codice fiscale	CF
	--2018	DA002	002	Cognome	AN
	--2018	DA002	003	Nome	AN
	--2018	DA002	004	Sesso	AN
	--2018	DA002	005	Data di nascita	DT
	--2018	DA002	006	Comune (o Stato estero) di nascita	AN
	--2018	DA002	007	Provincia di nascita (sigla)	PN
	--2018	DA002	008	Categorie particolari	AN -- non compiliamo
	--2018	DA002	009	Eventi eccezionali	N1 -- non compiliamo 
	--2018	DA002	010	Casi di esclusione dalla  precompilata	N1 -- non compiliamo
	--2018	DA002	020	Comune	AN  (Domicilio fiscale al 1/1/2017)
	--2018	DA002	021	Provincia (sigla)	PR  (Domicilio fiscale al 1/1/2017)
	--2018	DA002	022	Codice comune	AN (Domicilio fiscale al 1/1/2017) 
	--2018	DA002	023	Comune	AN   (Domicilio fiscale al 1/1/2018)
	--2018	DA002	024	Provincia (sigla)	PR  (Domicilio fiscale al 1/1/2018)
	--2018	DA002	025	Codice comune	PR  (Domicilio fiscale al 1/1/2018)
	--2018	DA002	030	Dati relativi al rappresentante	CF  -- minori, incapaci ecc.. (non compiliamo)
	--2018	DA002	040	Codice di identificazione fiscale estero	AN
	--2018	DA002	041	Località di residenza estera	AN
	--2018	DA002	042	Via e numero civico	AN
	--2018	DA002	043	Non Residenti Shumacker CB
	--2018	DA002	044	Codice stato estero	N3

	--Mentre verrà valorizzato con il codice 2 
	--nel caso siano stati cerificati soltanto dati previdenziali ed assistenziali E/O quadro relativo alle annotazioni.
	--Pertanto una CU che abbia un reddito esente dal punto di vista fiscale e NON anche dal punto di vista 
	-- previdenziale o assistenziale, dovrà essere indicato il valore 2.
	--Una CU che abbia un reddito completamente esente, sia dal punto di vista fiscale che previdenziale e assistenziale, 
    --dovrà essere indicato comunque il valore 2 in presenza della sezione relativa alle annotazioni.
    --Secondo me anche in caso di redditi non esenti perchè si scriveranno le annotazioni
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA002', 1, '001', @DA002001)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA002', 1, '002', @DA002002)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA002', 1, '003', @DA002003)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA002', 1, '004', @DA002004)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, data)	VALUES(@progrCert, @progrModulo, 'DA002', 1, '005', @DA002005)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA002', 1, '006', @DA002006)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'DA002', 1, '007', @DA002007)
	-- Casi di esclusione dalla  precompilata, per ora non lo compiliamo perchè determina lo scarto di tutte le certificazioni 
	-- molto probabilmente per un bug del software dell' Ag. Entrate
	--IF (@tipoRecord <> 'H')
	--BEGIN
	--	SELECT @DA002010 = 2
	--	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, intero) VALUES(@progrCert, @progrModulo, 'DA002', 1, '010', @DA002010)
	--END 
if( @print ='S')
Begin

	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'IND', 1, '001', @IND001)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'IND', 1, '002', @IND002)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'IND', 1, '003', @IND003)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, intero)  VALUES(@progrCert, @progrModulo, 'IND', 1, '004', @idreg)
	INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo, 'IND', 1, '005', @IND005)
End
IF (@tipoRecord <> 'H')
	BEGIN
		-- (Domicilio fiscale al 1/1/2017)
		INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'DA002', 1, '020', @DA002020)
		INSERT INTO #recordd (progr, modulo,quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'DA002', 1, '021', @DA002021)
		INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'DA002', 1, '022', @DA002022)
		-- (Domicilio fiscale al 1/1/2018)
		INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'DA002', 1, '024', @DA002024)
		INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'DA002', 1, '025', @DA002025)
		INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert,@progrModulo, 'DA002', 1, '026', @DA002026)
	END
	--Riservato ai percipienti esteri 
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo,'DA002', 1, '040', @DA002040)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo,'DA002', 1, '041', @DA002041)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, stringa) VALUES(@progrCert, @progrModulo,'DA002', 1, '042', @DA002042)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, intero)  VALUES(@progrCert, @progrModulo,'DA002', 1, '044', @DA002044)
 
	---------------------------------------------------- 
	------- Sezione Firma Certificazione Unica --------- 
	----------------------------------------------------
	 
	DECLARE @DA003001 DATETIME
	DECLARE @DA003002 CHAR(1)
	
	SELECT @DA003001 = GETDATE()
	SELECT @DA003002 = 1
	
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, data) VALUES (@progrCert, @progrModulo,'DA003', 1, '001', @DA003001)
	INSERT INTO #recordd (progr,modulo, quadro, riga, colonna, intero) VALUES (@progrCert,@progrModulo, 'DA003', 1, '002', @DA003002)

    SELECT progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data FROM #recordd 
    WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
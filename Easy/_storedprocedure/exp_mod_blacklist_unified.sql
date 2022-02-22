
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_blacklist_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_blacklist_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_blacklist_unified] 
(
	-- A seconda della periodicità ossia T o M, si dovrà indicare il periodo di riferimento
	@anno int,
	@mese int, 
	@trimestre int,
	@periodicita char(1) -- M = dichiarazione Mensile, T = dichiarazione Trimestrale
)
AS
BEGIN

-- [exp_mod_blacklist_unified] 2010,null ,3, 'T'
DECLARE @meseinizio int
DECLARE @mesefine int
DECLARE @start datetime

IF (@periodicita = 'T')
begin
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7 
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9 
			when @trimestre = 4 then 12
			End
end

DECLARE @lingua varchar(150)
select @lingua = @@language 

IF @lingua ='Italiano' 
	 SET @start = CONVERT(smalldatetime, '01-' + CONVERT(varchar(2),ISNULL(@mese,@meseinizio))+ '-'+ CONVERT(char(4),@anno), 105)
ELSE
	 SET @start = CONVERT(smalldatetime, CONVERT(varchar(2),ISNULL(@mese,@meseinizio))+ '-'+ '01-' +  CONVERT(char(4),@anno), 105)

print @start
-- Tabella di output
CREATE TABLE #trace(out_str varchar(1900)) -- record a lunghezza fissa di 1900 caratteri


DECLARE @lenanno INT
SET @lenanno = 4
DECLARE @lenmese INT
SET @lenmese = 2
DECLARE @lenday INT
SET @lenday = 2


-- Tutti i campi presenti nella tabella #RecordA sono obbligatori.
CREATE TABLE #RecordA
(
	codiceFornitura			varchar(5),		-- Fisso IVL10
	tipoFornitore			char(2),		-- Lungh. 2 -- 01 --> Soggetti che inviano le proprie dichiarazioni direttamente/
											-- 10 CAF o altri intermediari
	codiceFiscaleFornitore	varchar(16)		-- Lungh. 16 --	Codice Fiscale del Fornitore 
)


CREATE TABLE #RecordB
(
	codiceFiscaleContribuente			varchar(16), -- Codice Fiscale Contribuente
	codiceFiscaleSoftware				varchar(16), -- Codice Fiscale del Fornitore di SW
	--- Dati del Frontespizio
	tipoCorrettiva							char(1), -- casella barrata 0/1
	tipoIntegrativa							char(1), -- casella barrata 0/1
	--- Dati del Contribuente
	partitaIVA							varchar(13),		
	email								varchar(100),
	telefono							varchar(12), --prefisso e numero
	fax									varchar(12), --prefisso e numero
	-- Dati anagrafici persona fisica
	cognome								varchar(24),
	nome								varchar(20),
	sesso								char(1),	 -- M o  F
	comuneoStatoNascita					varchar(79),
	provNascita							varchar(2),  -- sigla
	dataNascita							varchar(8),
	-- Dati Soggetti non Persona Fisica
	denominazione						varchar(60),
	naturaGiurid						varchar(2), -- vale da 1 a 44, da 50 a 58
	-- Dati soggetto Estero				
	statoResidenza						varchar(24),
	codicePaeseStero					varchar(3), -- come da tabella allegata alla documentazione
	numeroIdentIva						varchar(24),
	--Dati Rappresentante Firmatario
	codiceFiscaleRappresentante			varchar(16),
	codiceCarica						char(2), -- vale 1-9/11-15
	codiceFiscaleSocDichiarante			varchar(16),
	cognomeRappresentante				varchar(24),
	nomeRappresentante					varchar(20),
	sessoRappresentante					char(1),	-- M o  F
	dataNascitaRappresentante			varchar(8),
	comuneoStatoNascitaRappresentante	varchar(40),
	provNascitaRappresentante			varchar(2), -- sigla
	comuneoStatoResidRappresentante		varchar(40),
	provResidRappresentante				varchar(2), -- sigla
	capComuneResidRappresentante		varchar(5),
	indirizzoRappresentante				varchar(35),
	telefonoRappresentante				varchar(12), -- prefisso e numero
	--Firma della comunicazione
	numeroModuli						int,
	firmaDichiarante					char(1)
)	

CREATE TABLE #RecordC
(	
	iddbdepartment						varchar(50), -- nome del dipartimento
	adate								smalldatetime,	-- Operazioni ATTIVE
	idreg								int,
	-- OPERAZIONI IMPONIBILI
	-- cessioni di Beni
	totImponibiliCessioni				decimal(19,2),  --A1002001
	totIvaCessioni						decimal(19,2),  --A1003001
	--- Prestazioni di Servizi
	totImponibiliPrestazioni			decimal(19,2),   --A1004001
	totIvaPrestazioni					decimal(19,2),   --A1005001
	-- OPERAZIONI NON IMPONIBILI
	totNonImponibiliCessioni			decimal(19,2),  --A1006001
	totNonImponibiliPrestazioni			decimal(19,2),	--A1007001
	-- OPERAZIONI ESENTI
	totEsenti							decimal(19,2),	--A1008001
	totEsentiCessioni					decimal(19,2),	--A1009001
	totEsentiPrestazioni				decimal(19,2),  --A10010001
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarCessioniAnnoCorr			decimal(19,2),  --A1011001
	totIvaVarCessioniAnnoCorr			decimal(19,2),	--A1012001
	totImponVarPrestazioniAnnoCorr		decimal(19,2),	--A1013001
	totIvaVarPrestazioniAnnoCorr		decimal(19,2),	--A1014001
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarCessioniAnnoPrec			decimal(19,2),	--A1015001
	totIvaVarCessioniAnnoPrec			decimal(19,2),	--A1016001
	totImponVarPrestazioniAnnoPrec		decimal(19,2),	--A1017001
	totIvaVarPrestazioniAnnoPrec		decimal(19,2),	--A1018001
	-- Operazioni PASSIVE
	-- OPERAZIONI IMPONIBILI
	-- cessioni di Beni
	totImponibiliAcquisti				decimal(19,2),	--A1019001
	totIvaAcquisti						decimal(19,2),	--A1020001
	--- Prestazioni di Servizi
	totImponibiliServizi				decimal(19,2),	--A1021001
	totIvaServizii						decimal(19,2),	--A1022001
	-- OPERAZIONI NON IMPONIBILI
	totNonImponibiliAcquisti			decimal(19,2),	--A1023001
	totNonImponibiliServizi				decimal(19,2),	--A1024001
	-- OPERAZIONI ESENTI
	totEsentiPassive					decimal(19,2),	--A1025001
	totEsentiAcquisti					decimal(19,2),	--A1026001
	totEsentiServizi					decimal(19,2),	--A1027001
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarAcquistiAnnoCorr			decimal(19,2),	--A1028001
	totIvaVarAcquistiAnnoCorr			decimal(19,2),	--A1029001
	totImponVarServiziAnnoCorr			decimal(19,2),	--A1030001
	totIvaVarServiziAnnoCorr			decimal(19,2),	--A1031001
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarAcquistiAnnoPrec			decimal(19,2),	--A1032001
	totIvaVarAcquistiAnnoPrec			decimal(19,2),	--A1033001
	totImponVarServiziAnnoPrec		decimal(19,2),  --A1034001
	totIvaVarServiziAnnoPrec		decimal(19,2)	--A1035001
)


CREATE TABLE #RecordC_Consol
(	
	idreg								int,
	progressivoModulo					int identity(1,1),
	-- Operazioni ATTIVE
	-- OPERAZIONI IMPONIBILI
	-- cessioni di Beni
	totImponibiliCessioni				decimal(19,2),  --A1002001
	totIvaCessioni						decimal(19,2),  --A1003001
	--- Prestazioni di Servizi
	totImponibiliPrestazioni			decimal(19,2),   --A1004001
	totIvaPrestazioni					decimal(19,2),   --A1005001
	-- OPERAZIONI NON IMPONIBILI
	totNonImponibiliCessioni			decimal(19,2),  --A1006001
	totNonImponibiliPrestazioni			decimal(19,2),	--A1007001
	-- OPERAZIONI ESENTI
	totEsenti							decimal(19,2),	--A1008001
	totEsentiCessioni					decimal(19,2),	--A1009001
	totEsentiPrestazioni				decimal(19,2),  --A10010001
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarCessioniAnnoCorr			decimal(19,2),  --A1011001
	totIvaVarCessioniAnnoCorr			decimal(19,2),	--A1012001
	totImponVarPrestazioniAnnoCorr		decimal(19,2),	--A1013001
	totIvaVarPrestazioniAnnoCorr		decimal(19,2),	--A1014001
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarCessioniAnnoPrec			decimal(19,2),	--A1015001
	totIvaVarCessioniAnnoPrec			decimal(19,2),	--A1016001
	totImponVarPrestazioniAnnoPrec		decimal(19,2),	--A1017001
	totIvaVarPrestazioniAnnoPrec		decimal(19,2),	--A1018001
	-- Operazioni PASSIVE
	-- OPERAZIONI IMPONIBILI
	-- cessioni di Beni
	totImponibiliAcquisti				decimal(19,2),	--A1019001
	totIvaAcquisti						decimal(19,2),	--A1020001
	--- Prestazioni di Servizi
	totImponibiliServizi				decimal(19,2),	--A1021001
	totIvaServizii						decimal(19,2),	--A1022001
	-- OPERAZIONI NON IMPONIBILI
	totNonImponibiliAcquisti			decimal(19,2),	--A1023001
	totNonImponibiliServizi				decimal(19,2),	--A1024001
	-- OPERAZIONI ESENTI
	totEsentiPassive					decimal(19,2),	--A1025001
	totEsentiAcquisti					decimal(19,2),	--A1026001
	totEsentiServizi					decimal(19,2),	--A1027001
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarAcquistiAnnoCorr			decimal(19,2),	--A1028001
	totIvaVarAcquistiAnnoCorr			decimal(19,2),	--A1029001
	totImponVarServiziAnnoCorr			decimal(19,2),	--A1030001
	totIvaVarServiziAnnoCorr			decimal(19,2),	--A1031001
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarAcquistiAnnoPrec			decimal(19,2),	--A1032001
	totIvaVarAcquistiAnnoPrec			decimal(19,2),	--A1033001
	totImponVarServiziAnnoPrec			decimal(19,2),  --A1034001
	totIvaVarServiziAnnoPrec			decimal(19,2)	--A1035001
)

CREATE TABLE #Dettaglio_FORNITORI_CLIENTI
(
	idreg int,
	adate smalldatetime,
	cognome varchar(24),
	ragioneSociale varchar(100),
	nome varchar(20),
	datanascita varchar(8),	
	comuneOStatoEsteroNascita varchar(79),
	provincia char(2), -- sigla provincia o EE per provincia estera
	codiceStatoEstero char(3),
	statoEstero varchar(79),
	localitaResidenza varchar(100),
	indirizzoEstero varchar(100),
	codiceIvaEstero varchar(13),
	codiceFiscaleEstero varchar(16)
)
DECLARE @cfsoftwarehouse varchar(16)
SET @cfsoftwarehouse = '05587470724' + SUBSTRING(SPACE(16),1,16 - DATALENGTH('05587470724')) -- P IVA Software and More

DECLARE @agency varchar(60)
DECLARE @cfFornitore varchar(16)
DECLARE @partitaIVAFornitore varchar(13)

SELECT
@agency = 
		CASE 
			WHEN agency IS NOT NULL THEN UPPER(agency) + SUBSTRING(SPACE(60),1,60 - DATALENGTH(agency))
			ELSE SPACE(60)
		END,
@cfFornitore  = 
		CASE 
			WHEN cf IS NOT NULL THEN UPPER(cf) + SUBSTRING(SPACE(16),1,16 - DATALENGTH(cf))
			ELSE SPACE(16)
		END,
@partitaIVAFornitore = 
		CASE
			WHEN p_iva IS NOT NULL THEN UPPER(p_iva)  + SUBSTRING(SPACE(11),1,11 - DATALENGTH(p_iva))		
			ELSE SPACE(11)	
		END					
FROM license

INSERT INTO #RecordA
(
	codiceFornitura,
	tipoFornitore,
	codiceFiscaleFornitore
)
SELECT
'IVL10',
'01',
@cfFornitore -- codice fiscale del fornitore = Codice fiscale dell'università


INSERT INTO #trace 
(out_str)
SELECT
'A'+ --tipo Record
REPLICATE(' ',14) +
codiceFornitura + 
tipoFornitore + 
codiceFiscaleFornitore +
SPACE(483) +
REPLICATE('0',4) + REPLICATE('0',4) +
SPACE(100) +
SPACE(1068) +
SPACE(200) +
'A' --+ 
--CHAR(13) + CHAR(10)
FROM 
#RecordA

--------------------------------------------------------------------------------
-------------- INDIVIDUAZIONE DEL RESPONSABILE DELLA TRASMISSIONE --------------
--------------------------------------------------------------------------------

DECLARE @idregRespTrasm int
DECLARE @cfRespTrasm varchar(16)
DECLARE @cognomeRespTrasm varchar(24)
DECLARE @nomeRespTrasm varchar(20)
DECLARE @sessoRespTrasm char(1)
DECLARE @dataNascitaRespTrasm varchar(8)
DECLARE @comuneOStatoNascitaRespTrasm varchar(40)
--DECLARE @provNascitaRespTrasm varchar(2)
DECLARE @comuneOStatoResidRespTrasm varchar(40)
--DECLARE @provResidRespTrasm varchar(2)
--DECLARE @capResidRespTrasm varchar(5)
--DECLARE @adressResidRespTrasm varchar(35)
--DECLARE @telRespTrasm varchar(12)


DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'  --residenza anagrafica

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

SELECT 
	@idregRespTrasm = M.idreg,
	@cfRespTrasm = 
	CASE
		WHEN R.cf IS NOT NULL THEN UPPER(R.cf) + SUBSTRING(SPACE(16),1,16 - DATALENGTH(R.cf))
		ELSE SPACE(16)
	END,
	@cognomeRespTrasm = 
	CASE
		WHEN surname IS NOT NULL THEN UPPER(surname) + SUBSTRING(SPACE(24),1,24 - DATALENGTH(surname))
		ELSE SPACE(24)
	END,
	@nomeRespTrasm		= 
	CASE
		WHEN forename IS NOT NULL  THEN UPPER(forename) + SUBSTRING(SPACE(20),1,20 - DATALENGTH(forename))
		ELSE SPACE(20)
	END,
	@sessoRespTrasm		= 
	CASE 
		WHEN gender IS NOT NULL THEN UPPER(gender)
		ELSE SPACE(1)
	END,
	@dataNascitaRespTrasm = 
	CASE 
		WHEN birthdate IS NOT NULL 
		THEN 
			SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(birthdate)))) + CONVERT(varchar(2),DAY(birthdate))
			+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(birthdate)))) + CONVERT(varchar(2),MONTH(birthdate))
			+ CONVERT(varchar(4),YEAR(birthdate))
		ELSE REPLICATE('8',8)
	END,
	@comuneOStatoNascitaRespTrasm = 
		CASE 
			WHEN ISNULL(city,nation) IS NOT NULL 
			THEN ISNULL(UPPER(city),UPPER(nation)) + SUBSTRING(SPACE(40),1,40 - DATALENGTH(ISNULL(city,nation) ))
			ELSE SPACE(40)
		END
FROM trasmissionmanager M
JOIN trasmissiondocument D
	ON M.idtrasmissiondocument = D.idtrasmissiondocument
JOIN registrymainview R
	ON R.idreg = M.idreg
WHERE D.idtrasmissiondocument ='BLACKLIST'
AND   M.ayear = @anno


SELECT TOP 1 @comuneOStatoResidRespTrasm = ISNULL(UPPER(city),UPPER(nation)) + 
										   SUBSTRING(SPACE(40),1,40 - DATALENGTH(ISNULL(city,nation) ))
FROM registryaddressview 
WHERE registryaddressview.active <>'N' 
AND registryaddressview.idaddresskind = @STAND
AND registryaddressview.idreg = @idregRespTrasm
AND stop is null 
AND start <= @start
ORDER BY start desc


DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM'   -- domicilio fiscale

DECLARE @NOSTAND int
SELECT  @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

IF  @comuneOStatoResidRespTrasm IS NULL -- se non trova l'indirizzo di residenza, considera il domicilio fiscale
BEGIN
	SELECT TOP 1 @comuneOStatoResidRespTrasm = ISNULL(UPPER(city),UPPER(nation))
	FROM registryaddressview 
	WHERE registryaddressview.active <>'N' 
	AND registryaddressview.idaddresskind = @NOSTAND
	AND registryaddressview.idreg = @idregRespTrasm
	AND stop is null 
	AND start <= @start
	ORDER BY start desc
END

INSERT INTO #RecordB
(
	codiceFiscaleContribuente,			
	codiceFiscaleSoftware,				
	--- Dati del Frontespizio
	tipoCorrettiva,	
	tipoIntegrativa,								
	--- Dati del Contribuente
	partitaIVA,								
	email,							
	telefono,							
	fax,								
	-- Dati anagrafici persona fisica
	cognome,								
	nome,								
	sesso,								
	comuneoStatoNascita,				
	provNascita,						
	dataNascita,							
	-- Dati Soggetti non Persona Fisica
	denominazione,						
	naturaGiurid,						
	-- Dati soggetto Estero				
	statoResidenza,						
	codicePaeseStero,				
	numeroIdentIva,						
	--Dati Rappresentante Firmatario
	codiceFiscaleRappresentante,			
	codiceCarica,						
	codiceFiscaleSocDichiarante,			
	cognomeRappresentante,				
	nomeRappresentante,					
	sessoRappresentante,				
	dataNascitaRappresentante,			
	comuneoStatoNascitaRappresentante,	
	provNascitaRappresentante,			
	comuneoStatoResidRappresentante,		
	provResidRappresentante,				
	capComuneResidRappresentante,		
	indirizzoRappresentante,				
	telefonoRappresentante,				
	--Firma della comunicazione
	firmaDichiarante					
)
VALUES
(
	@cfFornitore,
	@cfsoftwarehouse + SUBSTRING(SPACE(16),1,16 - DATALENGTH(@cfsoftwarehouse)),
	'0',
	'0',
	@partitaIVAFornitore,
	SPACE(100),  --EMAIL non lo valorizzo
	REPLICATE('0',12),  -- TELEFONO  non lo valorizzo
	REPLICATE('0',12),  -- FAX  non lo valorizzo
	SPACE(24),
	SPACE(20),
	SPACE(1),
	SPACE(79),
	SPACE(2),
	REPLICATE('0',8),
	@agency,
	'15', -- Enti pubblici non economici (classificazione natura giuridica secondo tabella allegata al modello)
	SPACE(24),
	REPLICATE('0',3),
	SPACE(24),
	--Dati Rappresentante Firmatario, responsabile della trasmissione telematica
	@cfRespTrasm,
	'14', -- codice carica: Soggetto che sottoscrive la dichiarazione per conto di una pubblica amministrazione
	@partitaIVAFornitore,
	@cognomeRespTrasm,
	@nomeRespTrasm,
	@sessoRespTrasm,
	-- Data  formato (ggmmaaaa)
	@dataNascitaRespTrasm,
	@comuneOStatoNascitaRespTrasm,
	SPACE(2),
	@comuneOStatoResidRespTrasm,
	SPACE(2), --prov residenza
	REPLICATE('0',5), -- cap residenza
	SPACE(35),
	REPLICATE('0',12),  -- TELEFONO  non lo valorizzo
	-- Firma della comunicazione
	'1' 
)

--SELECT * FROM #RecordB


-- valorizzare opportunamente il numero dei moduli in base all'estrazione
-- dati per il record C

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor
DECLARE @s varchar(300)

SET 	@crsdepartment = cursor for 
		select  iddbdepartment from dbdepartment
		where (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @s = @iddbdepartment + '.exp_mod_blacklist'
		
INSERT INTO #RecordC
		(
		iddbdepartment									,
		adate											,
		idreg											,
		-- Operazioni ATTIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		totImponibiliCessioni							,  --A1002001
		totIvaCessioni									,  --A1003001
		--- Prestazioni di Servizi
		totImponibiliPrestazioni						,   --A1004001
		totIvaPrestazioni								,   --A1005001
		-- OPERAZIONI NON IMPONIBILI
		totNonImponibiliCessioni						,  --A1006001
		totNonImponibiliPrestazioni						,  --A1007001
		-- OPERAZIONI ESENTI
		totEsenti										,  --A1008001
		totEsentiCessioni								,  --A1009001
		totEsentiPrestazioni							,  --A10010001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		totImponVarCessioniAnnoCorr						,  --A1011001
		totIvaVarCessioniAnnoCorr						,  --A1012001
		totImponVarPrestazioniAnnoCorr					,  --A1013001
		totIvaVarPrestazioniAnnoCorr					,  --A1014001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		totImponVarCessioniAnnoPrec						,	--A1015001
		totIvaVarCessioniAnnoPrec						,	--A1016001
		totImponVarServiziAnnoPrec						,	--A1017001
		totIvaVarServiziAnnoPrec						,	--A1018001
		-- Operazioni PASSIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		totImponibiliAcquisti							,	--A1019001
		totIvaAcquisti									,	--A1020001
		--- Prestazioni di Servizi
		totImponibiliServizi							,	--A1021001
		totIvaServizii									,	--A1022001
		-- OPERAZIONI NON IMPONIBILI
		totNonImponibiliAcquisti						,	--A1023001
		totNonImponibiliServizi							,	--A1024001
		-- OPERAZIONI ESENTI
		totEsentiPassive								,	--A1025001
		totEsentiAcquisti								,	--A1026001
		totEsentiServizi								,	--A1027001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		totImponVarAcquistiAnnoCorr						,	--A1028001
		totIvaVarAcquistiAnnoCorr						,	--A1029001
		totImponVarServiziAnnoCorr						,	--A1030001
		totIvaVarServiziAnnoCorr						,	--A1031001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		totImponVarAcquistiAnnoPrec						,	--A1032001
		totIvaVarAcquistiAnnoPrec						,	--A1033001
		totImponVarPrestazioniAnnoPrec					,   --A1034001
		totIvaVarPrestazioniAnnoPrec					    --A1035001
	)
	EXEC @s @anno,@mese,@trimestre,@periodicita
	FETCH next FROM @crsdepartment INTO @iddbdepartment
END
CLOSE @crsdepartment
DEALLOCATE @crsdepartment


INSERT INTO #Dettaglio_FORNITORI_CLIENTI
	(
		idreg,
		cognome,
		ragioneSociale,
		nome,
		datanascita,	
		comuneOStatoEsteroNascita,
		provincia, --sigla provincia o EE per provincia estera di nascita
		codiceIvaEstero,
		codiceFiscaleEstero
	)
SELECT DISTINCT
	R.idreg,
	CASE 
		WHEN idregistryclass = 22   --persona fisica
		THEN R.surname
		ELSE null
	END,
	CASE 
		WHEN idregistryclass <> 22 -- non persona fisica: ragione sociale dell'azienda fornitrice
		THEN R.title
		ELSE null
	END,
	CASE 
		WHEN idregistryclass = 22 
		THEN R.forename
		ELSE null
	END,
	CASE 
		WHEN idregistryclass = 22  AND R.birthdate  IS NOT NULL
		THEN 
			SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(R.birthdate)))) + CONVERT(varchar(2),DAY(R.birthdate))
			+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(R.birthdate)))) + CONVERT(varchar(2),MONTH(R.birthdate))
			+ CONVERT(varchar(4),YEAR(R.birthdate))
		ELSE SPACE(8)
	END,
	CASE 
		WHEN idregistryclass = 22 
		THEN ISNULL(convert(varchar(79),CITY_BIRTH.title),convert(varchar(79),NATION_BIRTH.title))
		ELSE null
	END,
		CASE 
		WHEN idregistryclass = 22 
		THEN ISNULL(convert(varchar(2),CITY_BIRTH.provincecode), 'EE')
		ELSE null
	END,
	R.p_iva,
	R.foreigncf
FROM #RecordC
JOIN registry R
ON #RecordC.idreg = R.idreg
LEFT OUTER JOIN geo_cityview CITY_BIRTH 
	ON CITY_BIRTH.idcity = R.idcity
LEFT OUTER JOIN geo_nation NATION_BIRTH 
	ON NATION_BIRTH.idnation = R.idnation


UPDATE #Dettaglio_FORNITORI_CLIENTI
SET adate = (SELECT MIN(adate)
				FROM #RecordC
			   WHERE #Dettaglio_FORNITORI_CLIENTI.idreg = #RecordC.idreg)

-------------------------------------------------------------------
--- ALGORITMO DI CALCOLO DELL'INDIRIZZO PER CLIENTI E FORNITORI ---
-------------------------------------------------------------------
DECLARE @idreg int
DECLARE @adate smalldatetime
DECLARE @idblacklist int
DECLARE @idnation int
DECLARE @blcode char(3)

CREATE TABLE #address
(
	idaddresskind 	int,
	idreg		int,
	address		varchar(100),
	location	varchar(120),
	idnation	int,
	nation		varchar(65)	 
)

DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT D.idreg, D.adate
FROM #Dettaglio_FORNITORI_CLIENTI D
FOR READ ONLY
OPEN rowcursor

FETCH NEXT FROM rowcursor
INTO  @idreg, @adate
WHILE @@FETCH_STATUS = 0
BEGIN 
		
	INSERT INTO #address
	(
		idaddresskind,
		idreg,
		address,
		location,
		idnation,
		nation						
	)
	SELECT
		idaddresskind,
		idreg, 
		address,
		location = ISNULL(geo_city.title,'')+ ' ' +ISNULL(registryaddress.location,'') ,
		case 
			when flagforeign = 'N' then 1
			else geo_nation.idnation
		end,
		nation = 
		case 
			when flagforeign = 'N' then 'Italia'
			else geo_nation.title
		end
	FROM registryaddress
	left outer join geo_city
		ON geo_city.idcity = registryaddress.idcity
	left outer join geo_country
		ON geo_city.idcountry = geo_country.idcountry
	left outer join geo_nation
		ON geo_nation.idnation = registryaddress.idnation
	WHERE 
		(
		registryaddress.active <>'N' 
		AND registryaddress.start = 
			(SELECT MAX(cdi.start) 
			FROM registryaddress cdi 
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND cdi.start <= @adate
			and cdi.idreg = registryaddress.idreg))
			AND idreg = @idreg

	delete #address
	where #address.idaddresskind <> @nostand
		and exists
			(select * from #address r2 
			where #address.idreg=r2.idreg
			and r2.idaddresskind = @nostand)

	delete #address
	where #address.idaddresskind not in (@nostand, @stand)
		and exists (
			select * from #address r2 
			where #address.idreg=r2.idreg
			and r2.idaddresskind = @stand
			)

	delete #address
	where (
		select count(*) from #address r2 
		where #address.idreg=r2.idreg
		)>1
	
	SELECT @blcode = idblacklist,@blcode = blcode FROM blacklist
	WHERE  idnation = (SELECT TOP 1 idnation FROM #address 
				        WHERE ISNULL(stop,{d '2079-06-06'}) > @adate order by start desc) 
	
	UPDATE #Dettaglio_FORNITORI_CLIENTI
	SET codiceStatoEstero = @blcode,
		statoEstero = nation,
		localitaResidenza = location,
		indirizzoEstero = address
	FROM #address

	FETCH NEXT FROM rowcursor
	INTO @idreg, @adate
END 
CLOSE rowcursor
DEALLOCATE rowcursor

--SELECT * FROM #RecordC



-- Travaso nella #RecordC Consolidata e aggregazione su Anagrafiche
INSERT INTO #RecordC_Consol
(
		idreg											,
		totImponibiliCessioni							,  --A1002001
		totIvaCessioni									,  --A1003001
		--- Prestazioni di Servizi
		totImponibiliPrestazioni						,   --A1004001
		totIvaPrestazioni								,   --A1005001
		-- OPERAZIONI NON IMPONIBILI
		totNonImponibiliCessioni						,  --A1006001
		totNonImponibiliPrestazioni						,  --A1007001
		-- OPERAZIONI ESENTI
		totEsenti										,  --A1008001
		totEsentiCessioni								,  --A1009001
		totEsentiPrestazioni							,  --A10010001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		totImponVarCessioniAnnoCorr						,  --A1011001
		totIvaVarCessioniAnnoCorr						,  --A1012001
		totImponVarPrestazioniAnnoCorr					,  --A1013001
		totIvaVarPrestazioniAnnoCorr					,  --A1014001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		totImponVarCessioniAnnoPrec						,	--A1015001
		totIvaVarCessioniAnnoPrec						,	--A1016001
		totImponVarServiziAnnoPrec						,	--A1017001
		totIvaVarServiziAnnoPrec						,	--A1018001
		-- Operazioni PASSIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		totImponibiliAcquisti							,	--A1019001
		totIvaAcquisti									,	--A1020001
		--- Prestazioni di Servizi
		totImponibiliServizi							,	--A1021001
		totIvaServizii									,	--A1022001
		-- OPERAZIONI NON IMPONIBILI
		totNonImponibiliAcquisti						,	--A1023001
		totNonImponibiliServizi							,	--A1024001
		-- OPERAZIONI ESENTI
		totEsentiPassive								,	--A1025001
		totEsentiAcquisti								,	--A1026001
		totEsentiServizi								,	--A1027001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		totImponVarAcquistiAnnoCorr						,	--A1028001
		totIvaVarAcquistiAnnoCorr						,	--A1029001
		totImponVarServiziAnnoCorr						,	--A1030001
		totIvaVarServiziAnnoCorr						,	--A1031001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		totImponVarAcquistiAnnoPrec						,	--A1032001
		totIvaVarAcquistiAnnoPrec						,	--A1033001
		totImponVarPrestazioniAnnoPrec					,   --A1034001
		totIvaVarPrestazioniAnnoPrec					    --A1035001
)	
SELECT DISTINCT
		idreg											,
		ISNULL(SUM(totImponibiliCessioni),0)			,  --A1002001
		ISNULL(SUM(totIvaCessioni),0)					,  --A1003001
		--- Prestazioni di Servizi
		ISNULL(SUM(totImponibiliPrestazioni),0)			,   --A1004001
		ISNULL(SUM(totIvaPrestazioni),0)				,   --A1005001
		-- OPERAZIONI NON IMPONIBILI
		ISNULL(SUM(totNonImponibiliCessioni),0)			,  --A1006001
		ISNULL(SUM(totNonImponibiliPrestazioni),0)		,  --A1007001
		-- OPERAZIONI ESENTI
		ISNULL(SUM(totEsenti),0)						,  --A1008001
		ISNULL(SUM(totEsentiCessioni),0)				,  --A1009001
		ISNULL(SUM(totEsentiPrestazioni),0)				,  --A10010001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		ISNULL(SUM(totImponVarCessioniAnnoCorr),0)		,  --A1011001
		ISNULL(SUM(totIvaVarCessioniAnnoCorr),0)		,  --A1012001
		ISNULL(SUM(totImponVarPrestazioniAnnoCorr),0)	,  --A1013001
		ISNULL(SUM(totIvaVarPrestazioniAnnoCorr),0)		,  --A1014001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		ISNULL(SUM(totImponVarCessioniAnnoPrec),0)		,	--A1015001
		ISNULL(SUM(totIvaVarCessioniAnnoPrec),0)		,	--A1016001
		ISNULL(SUM(totImponVarServiziAnnoPrec),0)		,	--A1017001
		ISNULL(SUM(totIvaVarServiziAnnoPrec),0)			,	--A1018001
		-- Operazioni PASSIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		ISNULL(SUM(totImponibiliAcquisti),0)			,	--A1019001
		ISNULL(SUM(totIvaAcquisti),0)					,	--A1020001
		--- Prestazioni di Servizi
		ISNULL(SUM(totImponibiliServizi),0)				,	--A1021001
		ISNULL(SUM(totIvaServizii),0)					,	--A1022001
		-- OPERAZIONI NON IMPONIBILI
		ISNULL(SUM(totNonImponibiliAcquisti),0)			,	--A1023001
		ISNULL(SUM(totNonImponibiliServizi)	,0)			,	--A1024001
		-- OPERAZIONI ESENTI
		ISNULL(SUM(totEsentiPassive),0)					,	--A1025001
		ISNULL(SUM(totEsentiAcquisti),0)				,	--A1026001
		ISNULL(SUM(totEsentiServizi),0)					,	--A1027001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		ISNULL(SUM(totImponVarAcquistiAnnoCorr)	,0)		,	--A1028001
		ISNULL(SUM(totIvaVarAcquistiAnnoCorr),0)		,	--A1029001
		ISNULL(SUM(totImponVarServiziAnnoCorr),0)		,	--A1030001
		ISNULL(SUM(totIvaVarServiziAnnoCorr),0)			,	--A1031001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		ISNULL(SUM(totImponVarAcquistiAnnoPrec),0)		,	--A1032001
		ISNULL(SUM(totIvaVarAcquistiAnnoPrec),0)		,	--A1033001
		ISNULL(SUM(totImponVarPrestazioniAnnoPrec),0)	,   --A1034001
		ISNULL(SUM(totIvaVarPrestazioniAnnoPrec),0)		    --A1035001
FROM    #RecordC
GROUP BY #RecordC.idreg   
	
DECLARE @numero_RecordB int
DECLARE @numero_RecordC int

SET @numero_RecordB = (SELECT COUNT(*) FROM #RecordB)
SET @numero_RecordC = (SELECT COUNT(*) FROM #RecordC_Consol)


--SELECT * FROM #RecordC_Consol
--SELECT * FROM #Dettaglio_FORNITORI_CLIENTI
INSERT INTO #trace 
	(out_str)
SELECT
	'B' + --Tipo Record
	codiceFiscaleContribuente + 
	'00000001' + -- progressivo modulo
	SPACE(3)  +
	SPACE(25) +
	SPACE(20) +
	codiceFiscaleSoftware +		
	'0' +	
	--- Dati del Frontespizio
	tipoCorrettiva +
	tipoIntegrativa +		
	--- Periodo di riferimento
	SUBSTRING(REPLICATE('0',4),1, 4 - DATALENGTH(CONVERT(varchar(4),ISNULL(@anno,0)))) + CONVERT(varchar(4),ISNULL(@anno,0)) +
	SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),ISNULL(@mese,0)))) + CONVERT(varchar(2),ISNULL(@mese,0)) +
	CONVERT(varchar(1),ISNULL(@trimestre,0)) + 
	'0' + 
	--- Dati del Contribuente
	partitaIVA +								
	email +					
	telefono +							
	fax +							
	-- Dati anagrafici persona fisica
	cognome + 						
	nome +							
	sesso +								
	comuneoStatoNascita + 			
	provNascita +		
	dataNascita +
	-- Dati soggetti non Persona Fisica
	denominazione +						
	naturaGiurid +						
	-- Dati soggetto Estero				
	statoResidenza +						
	codicePaeseStero +				
	numeroIdentIva  +						
	--Dati Rappresentante Firmatario
	codiceFiscaleRappresentante +			
	codiceCarica  +						
	codiceFiscaleSocDichiarante +			
	cognomeRappresentante +		
	nomeRappresentante +				
	sessoRappresentante +		
	dataNascitaRappresentante + 
	comuneoStatoNascitaRappresentante + 	
	provNascitaRappresentante +			
	comuneoStatoResidRappresentante +		
	provResidRappresentante +		
	capComuneResidRappresentante +		
	indirizzoRappresentante + 				
	telefonoRappresentante + 				
	-- Firma della comunicazione
	-- numero dei moduli --  deve essere valorizzato opportunamente
	SUBSTRING(REPLICATE('0',8),1,8 - DATALENGTH(convert(varchar(8),@numero_RecordC))) + convert(varchar(8),@numero_RecordC) + 
	firmaDichiarante + 		
	-- Impegno alla trasmissione telematica --
	SPACE(16) +	
	REPLICATE('0',5) +
	'0' +
	REPLICATE('0',8) +
	'0' +
	SPACE(1103)+
	SPACE(20) +
	SPACE(34) +
	'A' --+
	--CHAR(13) + CHAR(10)
FROM  #RecordB

-- CICLO CON CURSORE PER DETERMINARE LA STRINGA DEL RECORD C
DECLARE @cognome varchar(24)
DECLARE @ragioneSociale varchar(100)
DECLARE @nome varchar(20)
DECLARE @datanascita varchar(8)	
DECLARE @comuneOStatoEsteroNascita varchar(79)
DECLARE @provincia char(2)-- sigla provincia o EE per provincia estera
DECLARE @codiceStatoEstero char(3)
DECLARE @statoEstero varchar(79)
DECLARE @localitaResidenza varchar(100)
DECLARE @indirizzoEstero varchar(100)
DECLARE @codiceIvaEstero varchar(13)
DECLARE @codiceFiscaleEstero varchar(16)
DECLARE @progressivoModulo		int

-- Operazioni ATTIVE
-- OPERAZIONI IMPONIBILI
-- cessioni di Beni
DECLARE @totImponibiliCessioni				decimal(19,2)	--A1002001
DECLARE @totIvaCessioni						decimal(19,2)	--A1003001
--- Prestazioni di Servizi
DECLARE @totImponibiliPrestazioni			decimal(19,2)	--A1004001
DECLARE @totIvaPrestazioni					decimal(19,2)	--A1005001
-- OPERAZIONI NON IMPONIBILI
DECLARE @totNonImponibiliCessioni			decimal(19,2)	--A1006001
DECLARE @totNonImponibiliPrestazioni		decimal(19,2)	--A1007001
-- OPERAZIONI ESENTI
DECLARE @totEsenti							decimal(19,2)	--A1008001
DECLARE @totEsentiCessioni					decimal(19,2)	--A1009001
DECLARE @totEsentiPrestazioni				decimal(19,2)	--A10010001
-- NOTE DI VARIAZIONE ANNO CORRENTE
DECLARE @totImponVarCessioniAnnoCorr		decimal(19,2)	--A1011001
DECLARE @totIvaVarCessioniAnnoCorr			decimal(19,2)	--A1012001
DECLARE @totImponVarPrestazioniAnnoCorr		decimal(19,2)	--A1013001
DECLARE @totIvaVarPrestazioniAnnoCorr		decimal(19,2)	--A1014001
-- NOTE DI VARIAZIONE ANNI PRECEDENTE
DECLARE @totImponVarCessioniAnnoPrec		decimal(19,2)	--A1015001
DECLARE @totIvaVarCessioniAnnoPrec			decimal(19,2)	--A1016001
DECLARE @totImponVarPrestazioniAnnoPrec		decimal(19,2)	--A1017001
DECLARE @totIvaVarPrestazioniAnnoPrec		decimal(19,2)	--A1018001
-- Operazioni PASSIVE
-- OPERAZIONI IMPONIBILI
-- cessioni di Beni
DECLARE @totImponibiliAcquisti				decimal(19,2)	--A1019001
DECLARE @totIvaAcquisti						decimal(19,2)	--A1020001
--- Prestazioni di Servizi
DECLARE @totImponibiliServizi				decimal(19,2)	--A1021001
DECLARE @totIvaServizii						decimal(19,2)	--A1022001
-- OPERAZIONI NON IMPONIBILI
DECLARE @totNonImponibiliAcquisti			decimal(19,2)	--A1023001
DECLARE @totNonImponibiliServizi			decimal(19,2)	--A1024001
-- OPERAZIONI ESENTI
DECLARE @totEsentiPassive					decimal(19,2)	--A1025001
DECLARE @totEsentiAcquisti					decimal(19,2)	--A1026001
DECLARE @totEsentiServizi					decimal(19,2)	--A1027001
-- NOTE DI VARIAZIONE ANNO CORRENTE
DECLARE @totImponVarAcquistiAnnoCorr		decimal(19,2)	--A1028001
DECLARE @totIvaVarAcquistiAnnoCorr			decimal(19,2)	--A1029001
DECLARE @totImponVarServiziAnnoCorr			decimal(19,2)	--A1030001
DECLARE @totIvaVarServiziAnnoCorr			decimal(19,2)	--A1031001
-- NOTE DI VARIAZIONE ANNI PRECEDENTE
DECLARE @totImponVarAcquistiAnnoPrec		decimal(19,2)	--A1032001
DECLARE @totIvaVarAcquistiAnnoPrec			decimal(19,2)	--A1033001
DECLARE @totImponVarServiziAnnoPrec			decimal(19,2)	--A1034001
DECLARE @totIvaVarServiziAnnoPrec			decimal(19,2)	--A1035001

DECLARE @varRecordC varchar(3000)

DECLARE rowcursorC INSENSITIVE CURSOR FOR
SELECT	D.idreg, D.cognome, D.ragioneSociale,D.nome,D.datanascita,
		D.comuneOStatoEsteroNascita,D.provincia, --sigla provincia o EE per provincia estera di nascita
		D.codiceStatoEstero,D.statoEstero,D.localitaResidenza,D.indirizzoEstero,
		D.codiceIvaEstero,codiceFiscaleEstero,RC.progressivoModulo,
		RC.totImponibiliCessioni						,  --A1002001
	    RC.totIvaCessioni								,  --A1003001
	    --- Prestazioni di Servizi
		RC.totImponibiliPrestazioni						,  --A1004001
		RC.totIvaPrestazioni							,  --A1005001
		-- OPERAZIONI NON IMPONIBILI
		RC.totNonImponibiliCessioni						,  --A1006001
		RC.totNonImponibiliPrestazioni					,  --A1007001
		-- OPERAZIONI ESENTI
		RC.totEsenti									,  --A1008001
		RC.totEsentiCessioni							,  --A1009001
		RC.totEsentiPrestazioni							,  --A10010001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		RC.totImponVarCessioniAnnoCorr					,  --A1011001
		RC.totIvaVarCessioniAnnoCorr					,  --A1012001
		RC.totImponVarPrestazioniAnnoCorr				,  --A1013001
		RC.totIvaVarPrestazioniAnnoCorr					,  --A1014001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		RC.totImponVarCessioniAnnoPrec					,	--A1015001
		RC.totIvaVarCessioniAnnoPrec					,	--A1016001
		RC.totImponVarServiziAnnoPrec					,	--A1017001
		RC.totIvaVarServiziAnnoPrec						,	--A1018001
		-- Operazioni PASSIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		RC.totImponibiliAcquisti						,	--A1019001
		RC.totIvaAcquisti								,	--A1020001
		--- Prestazioni di Servizi
		RC.totImponibiliServizi							,	--A1021001
		RC.totIvaServizii								,	--A1022001
		-- OPERAZIONI NON IMPONIBILI
		RC.totNonImponibiliAcquisti						,	--A1023001
		RC.totNonImponibiliServizi						,	--A1024001
		-- OPERAZIONI ESENTI
		RC.totEsentiPassive								,	--A1025001
		RC.totEsentiAcquisti							,	--A1026001
		RC.totEsentiServizi								,	--A1027001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		RC.totImponVarAcquistiAnnoCorr					,	--A1028001
		RC.totIvaVarAcquistiAnnoCorr					,	--A1029001
		RC.totImponVarServiziAnnoCorr					,	--A1030001
		RC.totIvaVarServiziAnnoCorr						,	--A1031001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		RC.totImponVarAcquistiAnnoPrec					,	--A1032001
		RC.totIvaVarAcquistiAnnoPrec					,	--A1033001
		RC.totImponVarPrestazioniAnnoPrec				,   --A1034001
		RC.totIvaVarPrestazioniAnnoPrec					    --A1035001
FROM #RecordC_Consol RC
JOIN #Dettaglio_FORNITORI_CLIENTI D
	ON D.idreg = RC.idreg
FOR READ ONLY
OPEN rowcursorC

FETCH NEXT FROM rowcursorC
INTO	@idreg, @cognome, @ragioneSociale,@nome,@datanascita,
		@comuneOStatoEsteroNascita,@provincia, --sigla provincia o EE per provincia estera di nascita
		@codiceStatoEstero,@statoEstero, @localitaResidenza,@indirizzoEstero,
		@codiceIvaEstero,@codiceFiscaleEstero,@progressivoModulo,
		@totImponibiliCessioni						,  --A1002001
	    @totIvaCessioni								,  --A1003001
	    --- Prestazioni di Servizi
		@totImponibiliPrestazioni					,  --A1004001
		@totIvaPrestazioni							,  --A1005001
		-- OPERAZIONI NON IMPONIBILI
		@totNonImponibiliCessioni					,  --A1006001
		@totNonImponibiliPrestazioni				,  --A1007001
		-- OPERAZIONI ESENTI
		@totEsenti									,  --A1008001
		@totEsentiCessioni							,  --A1009001
		@totEsentiPrestazioni						,  --A10010001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		@totImponVarCessioniAnnoCorr				,  --A1011001
		@totIvaVarCessioniAnnoCorr					,  --A1012001
		@totImponVarPrestazioniAnnoCorr				,  --A1013001
		@totIvaVarPrestazioniAnnoCorr				,  --A1014001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		@totImponVarCessioniAnnoPrec				,	--A1015001
		@totIvaVarCessioniAnnoPrec					,	--A1016001
		@totImponVarServiziAnnoPrec					,	--A1017001
		@totIvaVarServiziAnnoPrec					,	--A1018001
		-- Operazioni PASSIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		@totImponibiliAcquisti						,	--A1019001
		@totIvaAcquisti								,	--A1020001
		--- Prestazioni di Servizi
		@totImponibiliServizi						,	--A1021001
		@totIvaServizii								,	--A1022001
		-- OPERAZIONI NON IMPONIBILI
		@totNonImponibiliAcquisti					,	--A1023001
		@totNonImponibiliServizi					,	--A1024001
		-- OPERAZIONI ESENTI
		@totEsentiPassive							,	--A1025001
		@totEsentiAcquisti							,	--A1026001
		@totEsentiServizi							,	--A1027001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		@totImponVarAcquistiAnnoCorr				,	--A1028001
		@totIvaVarAcquistiAnnoCorr					,	--A1029001
		@totImponVarServiziAnnoCorr					,	--A1030001
		@totIvaVarServiziAnnoCorr					,	--A1031001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		@totImponVarAcquistiAnnoPrec				,	--A1032001
		@totIvaVarAcquistiAnnoPrec					,	--A1033001
		@totImponVarPrestazioniAnnoPrec				,   --A1034001
		@totIvaVarPrestazioniAnnoPrec					--A1035001
WHILE @@FETCH_STATUS = 0
BEGIN 
	SET		@varRecordC = 
	--------------------------------------
	------INIZIO PARTE POSIZIONALE -------
	--------------------------------------
	'C' +
	@cfFornitore + SUBSTRING(SPACE(16),1,16 - DATALENGTH(@cfFornitore)) +  
	SUBSTRING(REPLICATE('0',8),1, 8 - DATALENGTH(CONVERT(varchar(8),ISNULL(@progressivoModulo,0)))) 
			  + CONVERT(varchar(8),ISNULL(@progressivoModulo,0)) + 
	SPACE(3) +
	SPACE(25) +
	SPACE(20) +
	@cfsoftwarehouse + SUBSTRING(SPACE(16),1,16 - DATALENGTH(@cfsoftwarehouse))
	-------------------------------------
	----- FINE PARTE POSIZIONALE --------
	-------------------------------------
	IF (ISNULL(@cognome,'')<> '')
	BEGIN
		SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A100101A', ISNULL(@cognome,''),16)
		IF (ISNULL(@nome,'') <> '')
			SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A1001002', ISNULL(@nome,''),16) 
		IF (ISNULL(@datanascita,'') <> '')
			SET @varRecordC = @varRecordC + 'A1001003' + ISNULL(@datanascita,'')  
		IF (ISNULL(@comuneOStatoEsteroNascita,'') <> '')
			SET @varRecordC = @varRecordC +  [dbo].getsplittedstring('A1001004',ISNULL(@comuneOStatoEsteroNascita,''),16)   
		IF (ISNULL(@provincia,'') <> '')
			SET @varRecordC = @varRecordC +  'A1001005' + ISNULL(@provincia,'')   
	END
	ELSE 
		BEGIN
		IF (ISNULL(@ragioneSociale,'') <> '')
			SET @varRecordC = @varRecordC +  [dbo].getsplittedstring('A100101B',ISNULL(@ragioneSociale,''),16)   
		END 
	
	IF (ISNULL(@codiceStatoEstero,'') <> '')
		SET @varRecordC = @varRecordC + 'A1001006' + SUBSTRING(SPACE(16),1,16 - DATALENGTH(@codiceStatoEstero)) +  
	ISNULL(@codiceStatoEstero,'') 
	
	IF (ISNULL(@statoEstero,'') <> '')
		SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A1001007', ISNULL(@statoEstero,''),16) 

	IF (ISNULL(@localitaResidenza,'') <> '')
		SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A1001008', ISNULL(@localitaResidenza,''),16) 

	IF (ISNULL(@indirizzoEstero,'') <> '')
		SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A1001009', ISNULL(@indirizzoEstero,''),16) 

	IF (ISNULL(@codiceIvaEstero,'') <> '')
		SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A1001010', ISNULL(@codiceIvaEstero,''),16) 
	
	IF (ISNULL(@codiceFiscaleEstero,'') <> '')
		SET @varRecordC = @varRecordC + [dbo].getsplittedstring('A1001011', ISNULL(@codiceFiscaleEstero,''),16) 

		
	print @varRecordC
	print @codiceStatoEstero
	-------------------------------------------------------
	-------------- IMPORTI OPERAZIONI ATTIVE --------------
	-------------------------------------------------------
	IF (@totImponibiliCessioni <> 0)
		SET @varRecordC = @varRecordC + 'A1002001' + [dbo].getsignedint(@totImponibiliCessioni,16)
	IF (@totIvaCessioni <> 0)
		SET @varRecordC = @varRecordC + 'A1003001' + [dbo].getsignedint(@totIvaCessioni,16)
	IF (@totImponibiliPrestazioni <> 0)
		SET @varRecordC = @varRecordC + 'A1004001' + [dbo].getsignedint(@totImponibiliPrestazioni,16)
	IF (@totIvaPrestazioni <> 0)
		SET @varRecordC = @varRecordC + 'A1005001' + [dbo].getsignedint(@totIvaPrestazioni,16)
	IF (@totNonImponibiliCessioni <> 0)
		SET @varRecordC = @varRecordC + 'A1006001' + [dbo].getsignedint(@totNonImponibiliCessioni,16)
	IF (@totNonImponibiliPrestazioni <> 0)
		SET @varRecordC = @varRecordC + 'A1007001' + [dbo].getsignedint(@totNonImponibiliPrestazioni,16)
	IF (@totEsenti <> 0)
		SET @varRecordC = @varRecordC + 'A1008001' + [dbo].getsignedint(@totEsenti,16)
	IF (@totEsentiCessioni <> 0)
		SET @varRecordC = @varRecordC + 'A1009001' + [dbo].getsignedint(@totEsentiCessioni,16)
	IF (@totEsentiPrestazioni <> 0)
		SET @varRecordC = @varRecordC + 'A1010001' + [dbo].getsignedint(@totEsentiPrestazioni,16)
	
	IF (@totImponVarCessioniAnnoCorr <> 0)
		SET @varRecordC = @varRecordC + 'A1011001' + [dbo].getsignedint(@totImponVarCessioniAnnoCorr,16)
	IF (@totIvaVarCessioniAnnoCorr <> 0)
		SET @varRecordC = @varRecordC + 'A1012001' + [dbo].getsignedint(@totIvaVarCessioniAnnoCorr,16)
	IF (@totImponVarPrestazioniAnnoCorr <> 0)
		SET @varRecordC = @varRecordC + 'A1013001' + [dbo].getsignedint(@totImponVarPrestazioniAnnoCorr,16)
	IF (@totIvaVarPrestazioniAnnoCorr <> 0)
		SET @varRecordC = @varRecordC + 'A1014001' + [dbo].getsignedint(@totIvaVarPrestazioniAnnoCorr,16)
	IF (@totImponVarCessioniAnnoPrec <> 0)
		SET @varRecordC = @varRecordC + 'A1015001' + [dbo].getsignedint(@totImponVarCessioniAnnoPrec,16)
	IF (@totIvaVarCessioniAnnoPrec <> 0)
		SET @varRecordC = @varRecordC + 'A1016001' + [dbo].getsignedint(@totIvaVarCessioniAnnoPrec,16)
	IF (@totImponVarServiziAnnoPrec <> 0)
		SET @varRecordC = @varRecordC + 'A1017001' + [dbo].getsignedint(@totImponVarServiziAnnoPrec,16)
	IF (@totIvaVarServiziAnnoPrec <> 0)
		SET @varRecordC = @varRecordC + 'A1018001' + [dbo].getsignedint(@totIvaVarServiziAnnoPrec,16)
	-------------------------------------------------------
	-------------- IMPORTI OPERAZIONI PASSIVE -------------
	-------------------------------------------------------
	IF (@totImponibiliAcquisti <> 0)
		SET @varRecordC = @varRecordC + 'A1019001' + [dbo].getsignedint(@totImponibiliAcquisti,16)
	IF (@totIvaAcquisti <> 0)
		SET @varRecordC = @varRecordC + 'A1020001' + [dbo].getsignedint(@totIvaAcquisti,16)
	IF (@totImponibiliServizi <> 0)
		SET @varRecordC = @varRecordC + 'A1021001' + [dbo].getsignedint(@totImponibiliServizi,16)
	IF (@totIvaServizii <> 0)
		SET @varRecordC = @varRecordC + 'A1022001' + [dbo].getsignedint(@totIvaServizii,16)
	IF (@totNonImponibiliAcquisti <> 0)
		SET @varRecordC = @varRecordC + 'A1023001' + [dbo].getsignedint(@totNonImponibiliAcquisti,16)
	IF (@totNonImponibiliServizi <> 0)
		SET @varRecordC = @varRecordC + 'A1024001' + [dbo].getsignedint(@totNonImponibiliServizi,16)
	IF (@totEsentiPassive <> 0)
		SET @varRecordC = @varRecordC + 'A1025001' + [dbo].getsignedint(@totEsentiPassive,16)
	IF (@totEsentiAcquisti <> 0)
		SET @varRecordC = @varRecordC + 'A1026001' + [dbo].getsignedint(@totEsentiAcquisti,16)
	IF (@totEsentiServizi <> 0)
		SET @varRecordC = @varRecordC + 'A1027001' + [dbo].getsignedint(@totEsentiServizi,16)
	IF (@totImponVarAcquistiAnnoCorr <> 0)
			SET @varRecordC = @varRecordC + 'A1028001' + [dbo].getsignedint(@totImponVarAcquistiAnnoCorr,16)
	IF (@totIvaVarAcquistiAnnoCorr <> 0)
			SET @varRecordC = @varRecordC + 'A1029001' + [dbo].getsignedint(@totIvaVarAcquistiAnnoCorr,16)
	IF (@totImponVarServiziAnnoCorr <> 0)
			SET @varRecordC = @varRecordC + 'A1030001' + [dbo].getsignedint(@totImponVarServiziAnnoCorr,16)
	IF (@totIvaVarServiziAnnoCorr <> 0)
			SET @varRecordC = @varRecordC + 'A1031001' + [dbo].getsignedint(@totIvaVarServiziAnnoCorr,16)
	IF (@totImponVarAcquistiAnnoPrec <> 0)
			SET @varRecordC = @varRecordC + 'A1032001' + [dbo].getsignedint(@totImponVarAcquistiAnnoPrec,16)
	IF (@totIvaVarAcquistiAnnoPrec <> 0)
			SET @varRecordC = @varRecordC + 'A1033001' + [dbo].getsignedint(@totIvaVarAcquistiAnnoPrec,16)
	IF (@totImponVarPrestazioniAnnoPrec <> 0)
			SET @varRecordC = @varRecordC + 'A1034001' + [dbo].getsignedint(@totImponVarPrestazioniAnnoPrec,16)
	IF (@totIvaVarPrestazioniAnnoPrec <> 0)
			SET @varRecordC = @varRecordC + 'A1035001' + [dbo].getsignedint(@totIvaVarPrestazioniAnnoPrec,16)
	
	print len(@varRecordC)
	SET @varRecordC =  @varRecordC + SPACE(8) + SPACE(1) + SPACE(2)
INSERT INTO #trace 
	(out_str)
SELECT @varRecordC


FETCH NEXT FROM rowcursorC
INTO	@idreg, @cognome, @ragioneSociale,@nome,@datanascita,
		@comuneOStatoEsteroNascita,@provincia, --sigla provincia o EE per provincia estera di nascita
		@codiceStatoEstero,@statoEstero, @localitaResidenza,@indirizzoEstero,
		@codiceIvaEstero,@codiceFiscaleEstero,@progressivoModulo,
		@totImponibiliCessioni						,  --A1002001
	    @totIvaCessioni								,  --A1003001
	    --- Prestazioni di Servizi
		@totImponibiliPrestazioni					,  --A1004001
		@totIvaPrestazioni							,  --A1005001
		-- OPERAZIONI NON IMPONIBILI
		@totNonImponibiliCessioni					,  --A1006001
		@totNonImponibiliPrestazioni				,  --A1007001
		-- OPERAZIONI ESENTI
		@totEsenti									,  --A1008001
		@totEsentiCessioni							,  --A1009001
		@totEsentiPrestazioni						,  --A10010001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		@totImponVarCessioniAnnoCorr				,  --A1011001
		@totIvaVarCessioniAnnoCorr					,  --A1012001
		@totImponVarPrestazioniAnnoCorr				,  --A1013001
		@totIvaVarPrestazioniAnnoCorr				,  --A1014001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		@totImponVarCessioniAnnoPrec				,	--A1015001
		@totIvaVarCessioniAnnoPrec					,	--A1016001
		@totImponVarServiziAnnoPrec					,	--A1017001
		@totIvaVarServiziAnnoPrec					,	--A1018001
		-- Operazioni PASSIVE
		-- OPERAZIONI IMPONIBILI
		-- cessioni di Beni
		@totImponibiliAcquisti						,	--A1019001
		@totIvaAcquisti								,	--A1020001
		--- Prestazioni di Servizi
		@totImponibiliServizi						,	--A1021001
		@totIvaServizii								,	--A1022001
		-- OPERAZIONI NON IMPONIBILI
		@totNonImponibiliAcquisti					,	--A1023001
		@totNonImponibiliServizi					,	--A1024001
		-- OPERAZIONI ESENTI
		@totEsentiPassive							,	--A1025001
		@totEsentiAcquisti							,	--A1026001
		@totEsentiServizi							,	--A1027001
		-- NOTE DI VARIAZIONE ANNO CORRENTE
		@totImponVarAcquistiAnnoCorr				,	--A1028001
		@totIvaVarAcquistiAnnoCorr					,	--A1029001
		@totImponVarServiziAnnoCorr					,	--A1030001
		@totIvaVarServiziAnnoCorr					,	--A1031001
		-- NOTE DI VARIAZIONE ANNI PRECEDENTE
		@totImponVarAcquistiAnnoPrec				,	--A1032001
		@totIvaVarAcquistiAnnoPrec					,	--A1033001
		@totImponVarPrestazioniAnnoPrec				,   --A1034001
		@totIvaVarPrestazioniAnnoPrec					--A1035001 
END
CLOSE rowcursorC
DEALLOCATE  rowcursorC


-----------------------------
--- RECORD DI RIEPILOGO Z ---
-----------------------------

INSERT INTO #trace 
(out_str)
SELECT
'Z'+ --tipo Record
SPACE(14) +
SUBSTRING(REPLICATE('0',9),1,9 - DATALENGTH(convert(varchar(9),@numero_RecordB)))+ convert(varchar(9),@numero_RecordB) + 
SUBSTRING(REPLICATE('0',9),1,9 - DATALENGTH(convert(varchar(9),@numero_RecordC))) + convert(varchar(9),@numero_RecordC) + 
SPACE(1864) +
'A' -- + 
--CHAR(13) + CHAR(10)

--select * from #Dettaglio_FORNITORI_CLIENTI
--select * from #RecordC_Consol
--select * from #RecordB
SELECT out_str FROM #trace 

DROP TABLE #RecordA
DROP TABLE #RecordB
DROP TABLE #RecordC
DROP TABLE #address
DROP TABLE #Dettaglio_FORNITORI_CLIENTI
DROP TABLE #trace

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


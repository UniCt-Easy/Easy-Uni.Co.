
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro_SE_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro_SE_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_mod_spesometro_SE_unified](
@ayear int,
@month int
)
AS BEGIN

DECLARE @CFsoftwarehouse varchar(16)
SET @CFsoftwarehouse = '02890460781'
SET @CFsoftwarehouse =  @CFsoftwarehouse +  SUBSTRING(SPACE(16),1,16 - DATALENGTH(@CFsoftwarehouse)) 

declare @cudactivitycode varchar(6)
select  @cudactivitycode = replace(cudactivitycode,'.','') from config where ayear = @ayear

declare @codfiscEnte varchar(16)
declare @PivaEnte varchar(11)
declare @DenominazioneEnte varchar(60)
declare @TelEnte varchar(12)
declare @FaxEnte varchar(12)
declare @EmailEnte varchar(50)

SELECT
	@DenominazioneEnte = SUBSTRING(agencyname, 1, 60)			+ substring(space(60),1,60-DATALENGTH(ISNULL(substring(agencyname,1,60),space(60)))),
	@codfiscEnte = cf +  SUBSTRING(SPACE(16),1,16 - DATALENGTH(cf)), 
	@PivaEnte = p_iva +  SUBSTRING(SPACE(11),1,11 - DATALENGTH(p_iva)), 
	@TelEnte = ISNULL(substring(phonenumber,1,12),space(12))	+ substring(space(12),1,12-DATALENGTH(ISNULL(substring(phonenumber,1,12),space(12)))),
	@FaxEnte = ISNULL(substring(fax,1,12), space(12))			+ substring(space(12),1,12-DATALENGTH(ISNULL(substring(fax,1,12),space(12)))),
	@EmailEnte = ISNULL(substring(email, 1,50),space(50))		+ substring(space(50),1,50-DATALENGTH(ISNULL(substring(email,1,50),space(50))))
	--@location = SUBSTRING(isnull(geo_city.title, license.location), 1, 40),
	--@country = license.country,
	--@address = SUBSTRING(license.address1, 1, 35),
	--@cap = license.cap
FROM license

DECLARE @idtrasmissiondocument varchar(10)
SET @idtrasmissiondocument = 'SPESOMETRO'

CREATE TABLE #error (message varchar(400))

IF(
(SELECT COUNT(*) FROM trasmissionmanager
WHERE idtrasmissiondocument = @idtrasmissiondocument and ayear = @ayear ) = 0)
BEGIN
	INSERT INTO #error
	VALUES('Inserire il Responsabile della trasmissione del modello INTRA12. Andare in Configurazione\Configurazione\Responsabile della trasmissione...')
END 


IF(
(SELECT COUNT(*) FROM trasmissionmanager
WHERE idtrasmissiondocument = @idtrasmissiondocument and ayear = @ayear ) = 0)
BEGIN
	INSERT INTO #error
	VALUES('Inserire il Responsabile della trasmissione dello Spesometro. Andare in Configurazione\Configurazione\Responsabile della trasmissione...')
END 


-- PRENDERE I DATI DAL RESPONSABILE DELLA TRASMISSIONE 
	DECLARE @CFdelrappresentante varchar(16)		
	DECLARE @codiceCaricaRappresentante varchar(2)	
	DECLARE @CognomeRappresentante varchar(24)
	DECLARE @NomeRappresentante varchar(20)
	DECLARE @SessoRappresentante char(1)		
	DECLARE @DataNascitaRappresentante varchar(8)
	DECLARE @ComuneNascitaRappresentante varchar(40)
	DECLARE @ProvinciaNascitaRappresentante varchar(2)	
	SELECT
		@codiceCaricaRappresentante = '01', -- 1 = Rappresentante legale, negoziale o di fatto, socio amministratore
		@CFdelrappresentante = R.cf,
		@CognomeRappresentante = SUBSTRING(R.surname, 1, 24)			+ substring(space(24),1,24-DATALENGTH(ISNULL(substring(R.surname,1,24),space(24)))),
		@NomeRappresentante = SUBSTRING(R.forename, 1, 20)			+ substring(space(20),1,20-DATALENGTH(ISNULL(substring(R.forename,1,20),space(20)))) ,
		@SessoRappresentante = R.gender,
		@DataNascitaRappresentante = 			
			SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),DAY(R.birthdate)))) + CONVERT(varchar(2),DAY(R.birthdate))
			+ SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),MONTH(R.birthdate)))) + CONVERT(varchar(2),MONTH(R.birthdate))
			+ CONVERT(varchar(4),YEAR(R.birthdate)),
		@ComuneNascitaRappresentante =SUBSTRING(C.title, 1, 40)			+ substring(space(40),1,40-DATALENGTH(ISNULL(substring(C.title,1,40),space(40))))  ,
		@ProvinciaNascitaRappresentante = P.provincecode 
	FROM trasmissionmanager
	JOIN trasmissiondocument
		ON trasmissionmanager.idtrasmissiondocument = trasmissiondocument.idtrasmissiondocument
	JOIN registry R
		ON R.idreg = trasmissionmanager.idreg
	LEFT OUTER JOIN geo_city C 
		ON C.idcity = R.idcity
	LEFT OUTER JOIN geo_cityview P 
		ON P.idcity = R.idcity
	WHERE trasmissionmanager.idtrasmissiondocument = @idtrasmissiondocument AND ayear = @ayear

	
-- Tabella di output
CREATE TABLE #traceByRecord(recordkind char(1), out_str varchar(1900)) -- I byte, fino al raggiungimento della posizione 1897 di ogni record a struttura variabile, 
							-- eventualmente inutilizzati devono essere inizializzati con spazi.
							-- Quindi dobbiamo contare lo spazio utilizzato, per capire quanti spaze aggiungere
CREATE TABLE #trace(out_str varchar(1900)) -- record a lunghezza fissa di 1900 caratteri

INSERT INTO #traceByRecord (recordkind, out_str)
-- RECORD "A"
select
'A',
'A'
+ space(14) -- Filler
+ 'NSP00' -- Codice fornitura
+ '01' -- Soggetti che inviano la proprio comunciazione
+ @codfiscEnte -- CF del soggetto obbligato alla comunicazione
+ space(483) -- Filler
+ '0001' -- Progressivo Invio Telematico  CONTROLLARE
+ '0001' -- Numero totale degli invii telematici CONTROLLARE
+ space(100) -- Spazio a disposione dell'utente
+ space(1068) -- Filler
+ space(200) -- Spazio riservato al Servizio Telematico
+ 'A' -- Carattere di controllo, impostare al valore "A"

INSERT INTO #traceByRecord (recordkind, out_str)
-- RECORD "B"
select 
'B',
'B'
+ @codfiscEnte -- CF del soggetto obbligato alla comunicazione
+ SUBSTRING(REPLICATE('0',8),1,7) + '1'  --Progressivo modulo. Vale 1
+ space(3)-- Spazio a disposizione dell'utente
+ space(25) -- filler
+ space(20)-- spazio a disposizione dell'utente
+ @CFsoftwarehouse -- CD del produttore del software
+ '1' -- comunicazione ordinaria
+ '0' -- comunicazione sostitutiva
+ '0' -- comunicazione di annullamento
+ REPLICATE('0',17) --Protocollo della comunicazione da sostituire o annullare
+ REPLICATE('0',6) -- Protocollo documento da sostituire o da annullare
+ '1' -- Dati aggragati
+ '0' -- Dati analitici
+ '0'	-- Quadro FA – Operazioni documentate da fattura esposte in forma aggregata 
+ '0'	-- Quadro SA – Operazioni senza fattura esposte in forma aggregata = Registri corrispettivi. DA NON COMPILARE
+ '0'	--Quadro BL -	Operazioni con soggetti aventi sede, residenza o domicilio in paesi con fiscalità privilegiata  
		--				Operazioni con soggetti non residenti in forma aggregata  
		--				Acquisti di servizi da non residenti in forma aggregata .
+ '0'-- Quadro FE - Relativo alla comunicazione analitica 
+ '0'-- Quadro FR - Relativo alla comunicazione analitica 
+ '0'-- Quadro NE - Relativo alla comunicazione analitica 
+ '0'-- Quadro NR - Relativo alla comunicazione analitica 
+ '0'-- Quadro DF - Relativo alla comunicazione analitica 
+ '0'-- Quadro FN - Relativo alla comunicazione analitica 
+ '1'-- Quadro SE – Limitatamente agli acquisti con operatori di San Marino(scritto nel pdf).  Acquisti di servizi da non residenti e Acquisti da operatori di San Marino.
		-- Per SE faremo una exp a parte!!!
+ '0'-- Quadro TU–  Operazioni legate al turismo. DA NON COMPILARE
+ '1'-- Quadro TA- Riepilogo

+ @PivaEnte 
+ @cudactivitycode -- Codice attività ATECO
+ @TelEnte
+ @FaxEnte
+ @EmailEnte
-->> Dati Anagrafici del Soggetto cui si riferisce la comunicazione - Persona Fisica
+ space(24) -- cognome
+ space(20) -- nome
+ space(1)	--sesso
+ space(8)	-- data di nascita
+ space(40) -- comune di nascita
+ space(2)	-- provincia di nascita
-- Dati del Soggetto cui si riferisce la comunicazione - Persona non fisica
+ @DenominazioneEnte
+ convert(varchar(4),@ayear) -- Anno riferimento
--	Trimestre/Mese riferimento. Il mese va valorizzare obbligatoriamente solo se presenti Acquisti da Operatori di San Marino. 
--	il trimestre per op. da Black list.In tutti gli altri casi non deve essere compilato
+ case 
	when len(convert(varchar(2),@month))=1 then space(1)+ convert(varchar(2),@month)
	else convert(varchar(2),@month)
 end
-->> Dati del Soggetto tenuto alla comunicazione(soggetto che effettua la comunicazione, se diverso dal soggetto cui si riferisce la comunicazione)
+ @CFdelrappresentante -- CF
+ @codiceCaricaRappresentante -- codice carica
+ space(8) -- Data inizio procedura o data di decesso del contribuente NO
+ space(8) -- data fine procedura NO
+ @CognomeRappresentante --cognome
+ @NomeRappresentante -- nome
+ @SessoRappresentante	--sesso
+ @DataNascitaRappresentante	-- data di nascita
+ @ComuneNascitaRappresentante	-- comune di nascita
+ @ProvinciaNascitaRappresentante	-- provincia di nascita
+ space(24) -- denominazione 
-->>Impegno alla trasmissione telematica
+ space(16)--- CF intermediario
+ REPLICATE('0',5)  -- n.iscrizione CAF
+ REPLICATE('0',1)
+ space(1)	--filler
+ space(8)	-- data dell'impegno
+ space(1294) -- Filler
+ space(20)  -- Filler
+ space(18)	-- Fillee
+ 'A'


-- RECORD "D" -> Solo importi

CREATE TABLE #RECORD_D(
	idreg int,
	ProgressivoModulo int , -- Impostare ad 1 per il primo modulo di ogni quadro compilato, incrementando tale valore di una unità per ogni ulteriore modulo
-->> QUADRO SE - Acquisti da operatori di San Marino
	SE001012_dataemissionefattura datetime,
	SE001013_dataregistrazionefattura datetime,--la data deve essere inclusa nell'anno di riferimento
	SE001014_numfattura  varchar(35),
	SE001015_imponibile int,
	SE001016_imposta  int,
	SE001017_confermaimporto int-- dato obbligatorio se l'importo è maggiore di 999999
)


DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor
DECLARE @spname varchar(300)

SET 	@crsdepartment = cursor for 
		select  iddbdepartment from dbdepartment
		where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
				-- AND iddbdepartment ='amm'
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @spname = @iddbdepartment + '.exp_mod_spesometro_SE'
		
INSERT INTO #RECORD_D(
	idreg,
	SE001012_dataemissionefattura,
	SE001013_dataregistrazionefattura,
	SE001014_numfattura,
	SE001015_imponibile,
	SE001016_imposta,
	SE001017_confermaimporto
	)
	EXEC @spname @ayear, @month
	FETCH next FROM @crsdepartment INTO @iddbdepartment
END
CLOSE @crsdepartment
DEALLOCATE @crsdepartment


CREATE TABLE #RECORD_D_UNIFIED(
	idreg int,
	ProgressivoModulo int identity(1,1),
	SE001012_dataemissionefattura datetime,
	SE001013_dataregistrazionefattura datetime,--la data deve essere inclusa nell'anno di riferimento
	SE001014_numfattura  varchar(35),
	SE001015_imponibile int,
	SE001016_imposta  int,
	SE001017_confermaimporto int,	-- dato obbligatorio se l'importo è maggiore di 999999
	riga varchar(5) -- Valorizziamo quadro riga, tipo SE001, SE002, poi nella select finale faremo riga+001=> SE001001, SE001002...SE001016.SE002001, SE002002...SE002016
)


INSERT INTO #RECORD_D_UNIFIED(
	idreg,
	SE001012_dataemissionefattura,
	SE001013_dataregistrazionefattura,
	SE001014_numfattura,
	SE001015_imponibile,
	SE001016_imposta,
	SE001017_confermaimporto

)
SELECT 
	idreg,
	SE001012_dataemissionefattura,
	SE001013_dataregistrazionefattura,
	SE001014_numfattura,
	sum(SE001015_imponibile) as  SE001015_imponibile,
	sum(SE001016_imposta) as SE001016_imposta,
	SE001017_confermaimporto
FROM #RECORD_D
GROUP BY idreg, SE001012_dataemissionefattura,SE001013_dataregistrazionefattura, SE001014_numfattura, SE001017_confermaimporto

UPDATE	#RECORD_d_UNIFIED set riga= SUBSTRING(REPLICATE('0',3),1,3-len(substring(convert(char(3), ProgressivoModulo),1,3))) + convert(varchar(3), ProgressivoModulo)

declare @31dic datetime
set @31dic = dateadd(yy, (@ayear-1)-2000, {d '2000-12-31'})

CREATE TABLE #ANAGRAFICHE(
	idreg int,
	SE001001_cognome varchar(50), 
	SE001002_nome varchar(50),
	SE001003_datanascita datetime,
	SE001004_comune varchar(65),
	SE001005_provincia varchar(2),
	SE001006_codicestatoestero int,
	SE001007_denominazione varchar(100),
	SE001008_cittàestera varchar(65),
	SE001009_codicestatoestero varchar(20), 
	SE001010_indirizzoestero varchar(100),
	SE001011_CodIVA varchar(20)
)
	
-- Inserire dati anagrafici delle anagrafiche del quadro BL
INSERT INTO #ANAGRAFICHE(idreg, 
	SE001001_cognome,		--Persona Fisica
	SE001002_nome,			--Persona Fisica
	SE001003_datanascita,	--Persona Fisica
	SE001004_comune,		--Persona Fisica
	SE001005_provincia,		--Persona Fisica
	SE001006_codicestatoestero,	--Persona Fisica

	SE001007_denominazione,		-- Persona NON Fisica
	SE001008_cittàestera,		-- Persona NON Fisica
	SE001009_codicestatoestero, -- Persona NON Fisica
	SE001010_indirizzoestero,	-- Persona NON Fisica
	SE001011_CodIVA
	)				
SELECT distinct R.idreg,
	CASE 
		WHEN idregistryclass = 22   --persona fisica
		THEN R.surname
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
			SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),DAY(R.birthdate)))) + CONVERT(varchar(2),DAY(R.birthdate))
			+ SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),MONTH(R.birthdate)))) + CONVERT(varchar(2),MONTH(R.birthdate))
			+ CONVERT(varchar(4),YEAR(R.birthdate))
		ELSE null
	END,
	CASE 
		WHEN ISNULL(CITY_BIRTH.title,NATION_BIRTH.title) IS NOT NULL 
		THEN ISNULL(CITY_BIRTH.title,NATION_BIRTH.title)
		ELSE null
	END,
	CASE 
			WHEN idregistryclass = 22 and RA.flagforeign='S'
			then 'EE'-->La Provincia estera di nascita è rappresentata dalla sigla 'EE'
			WHEN idregistryclass = 22 and RA.flagforeign='N' 
			THEN CITY_BIRTH.provincecode
	ELSE null
	END,
	CASE 
		WHEN idregistryclass = 22 and RA.flagforeign='S'
		THEN NATION_ADDRESS_AGENCY.value
		ELSE null
	END,
	CASE 
		WHEN idregistryclass <> 22   -- NON persona fisica
		THEN R.title
		ELSE null
	END,
	-- SE001008_cittàestera: Città estera delle Sede legale
	CASE 
		WHEN idregistryclass <> 22 and (NATION_ADDRESS.title IS NOT NULL )
		THEN NATION_ADDRESS.title
		ELSE null
	END,
	--SE001009_codicestatoestero
	CASE 
		WHEN idregistryclass <> 22 and (NATION_ADDRESS_AGENCY.value IS NOT NULL )
		THEN NATION_ADDRESS_AGENCY.value
		ELSE null
	END,
	--SE001010_indirizzoestero
	CASE 
		WHEN idregistryclass <> 22 and (RA.address IS NOT NULL )
		THEN RA.address
		ELSE null
	END,
--	SE001011_CodIVA 
	CASE 
		WHEN idregistryclass <> 22 and (R.foreigncf IS NOT NULL )
		THEN R.foreigncf
		ELSE null
	END
FROM registry R
JOIN #RECORD_D_UNIFIED D
	ON R.idreg = D.idreg
JOIN registryaddress RA
	ON R.idreg = RA.idreg
JOIN address A
	ON RA.idaddresskind = A.idaddress
LEFT OUTER JOIN geo_cityview CITY_BIRTH 
	ON CITY_BIRTH.idcity = R.idcity
LEFT OUTER JOIN geo_nation NATION_BIRTH 
	ON NATION_BIRTH.idnation = R.idnation
LEFT OUTER JOIN geo_nation NATION_ADDRESS
	ON RA.idnation = NATION_ADDRESS.idnation
LEFT OUTER JOIN geo_nation_agency NATION_ADDRESS_AGENCY
	ON NATION_ADDRESS.idnation = NATION_ADDRESS_AGENCY.idnation
	AND NATION_ADDRESS_AGENCY.idagency = 5
	AND NATION_ADDRESS_AGENCY.idcode = 1
WHERE  A.codeaddress = '07_SW_DEF'
	AND RA.start <= @31dic 	AND (RA.stop IS NULL OR RA.stop >= @31dic)	-- Lascio il filtro sulla data, per prendere quello validido al 31/12
	AND ISNULL(RA.flagforeign,'N') = 'S'
	

-- RECORD "D"
INSERT INTO #traceByRecord (recordkind, out_str)
-- RECORD "D"
SELECT
'D',
'D'
+ @codfiscEnte
+ SUBSTRING(REPLICATE('0',8),1,8-len(substring(convert(char(8), D.ProgressivoModulo),1,8))) + convert(varchar(4), D.ProgressivoModulo)
+ space(3) -- Spazio a disposizione dell'utente
+ space(25) -- Filler
+ space(20) -- Spazio utente
+ @CFsoftwarehouse -- Identificativo produttore SW
-- Fine campi posizionali

+ CASE when (A.SE001001_cognome is not null) then 'SE' + D.riga + '001' + SE001001_cognome else''  end
+ CASE when (A.SE001001_cognome is not null) then 'SE' + D.riga + '002' + SE001002_nome else''  end
+ CASE when (A.SE001001_cognome is not null) then 'SE' + D.riga + '003' + convert(varchar(8),SE001003_datanascita) else''  end
+ CASE when (A.SE001001_cognome is not null) then 'SE' + D.riga + '004' + SE001004_comune else''  end
+ CASE when (A.SE001001_cognome is not null) then 'SE' + D.riga + '005' + SE001005_provincia else''  end
+ CASE when (A.SE001001_cognome is not null) then 'SE' + D.riga + '006' + convert(varchar(4),SE001006_codicestatoestero) else''  end
+ case when (A.SE001007_denominazione is not null) then 'SE' + D.riga + '007' + SE001007_denominazione else''  end
+ case when (A.SE001007_denominazione is not null) then 'SE' + D.riga + '008' + SE001008_cittàestera else''  end
+ case when (A.SE001007_denominazione is not null) then 'SE' + D.riga + '009' + convert(varchar(4),SE001009_codicestatoestero) else''  end
+ case when (A.SE001007_denominazione is not null) then 'SE' + D.riga + '010' + SE001010_indirizzoestero else''  end
+ case when SE001011_CodIVA is not null then 'SE' + D.riga + '011' + SE001011_CodIVA else''  end
+ case when SE001012_dataemissionefattura is not null 
	then 'SE' + D.riga + '012' + convert(varchar(8),SE001012_dataemissionefattura) else''  end	
+ case when SE001013_dataregistrazionefattura is not null 
	then 'SE' + D.riga + '013' + convert(varchar(8),SE001013_dataregistrazionefattura) else''  end	
+ case when SE001014_numfattura is not null 
	then 'SE' + D.riga + '014' + SE001014_numfattura + space(16-len(convert(varchar(16),SE001014_numfattura))) else''  end	
+ case when SE001015_imponibile is not null 
	then 'SE' + D.riga + '015' 
	+  space(16-len(convert(varchar(16), SE001015_imponibile)))+convert(varchar(16), SE001015_imponibile)	 else''  end	
+ case when SE001016_imposta is not null 
	then 'SE' + D.riga + '016' 
	+  space(16-len(convert(varchar(16), SE001016_imposta)))+convert(varchar(16), SE001016_imposta)	 else''  end	
+ case when SE001017_confermaimporto is not null 
	then  'SE' + D.riga + '017' 
	+  space(16-len(convert(varchar(16), SE001017_confermaimporto)))+convert(varchar(16), SE001017_confermaimporto)	 else''  end	
+ case when D.idreg is not null then 'A' else '' end -- Serve a non far andar in eccezione la SP quando non ci sono operazioni da dichiarare
FROM #RECORD_D_UNIFIED D
JOIN #ANAGRAFICHE A
	ON D.idreg = A.idreg

declare @CountD int
select @CountD = count(idreg) from #RECORD_D_UNIFIED


INSERT INTO #traceByRecord (recordkind, out_str)
-- RECORD "E"
SELECT
'E',
'E'
+ @codfiscEnte
+ '000000001' -- Numero record di tipo E
+ space(3) -- Spazio a disposizione dell'utente
+ space(25) -- Filler
+ space(20) -- Spazio utente
+ @CFsoftwarehouse -- Identificativo produttore SW
-- Fine campi posizionali

-- Numero complessivo dei righi compilati presenti nel quadro SE di tutti i moduli compilati
+ 'TA010001'+ SUBSTRING(REPLICATE(' ',16),1,16-len(substring(convert(char(16), @CountD),1,16))) + convert(varchar(16), @CountD)

INSERT INTO #traceByRecord (recordkind, out_str)
SELECT 
'Z',
'Z'
+ space(14) -- Filler
+ '000000001' -- Numero record di tipo B
+ '000000000' -- Numero record di tipo C
+ SUBSTRING(REPLICATE('0',9),1,9-len(substring(convert(char(9), @CountD),1,9))) + convert(varchar(4), @CountD) -- Numero record di tipo D
+ '000000000' -- Numero record di tipo E
+ space(1846) --Filler
+ 'A'


INSERT INTO #trace (out_str) SELECT out_str FROM #traceByRecord where recordkind='A'
INSERT INTO #trace (out_str) SELECT out_str FROM #traceByRecord where recordkind='B'

INSERT INTO #trace (out_str) 
SELECT out_str + space(1897-len(out_str)) + 'A'
FROM #traceByRecord where recordkind='D'

INSERT INTO #trace (out_str) 
SELECT out_str + space(1897-len(out_str)) + 'A'
FROM #traceByRecord where recordkind='E'

INSERT INTO #trace (out_str) SELECT out_str FROM #traceByRecord where recordkind='Z'


-- Il file viene creato SOLO se è stato compilato il Record D, contente gli importi.
if ( select count(*) from #traceByRecord where recordkind='D')>0
Begin
	SELECT out_str FROM #trace 
End





END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--- exec exp_mod_spesometro_SE_unified 2012,4 

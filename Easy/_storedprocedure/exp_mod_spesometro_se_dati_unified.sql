
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro_SE_dati_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro_SE_dati_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_mod_spesometro_SE_dati_unified](
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
FROM license

DECLARE @idtrasmissiondocument varchar(10)
SET @idtrasmissiondocument = 'SPESOMETRO'

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
DECLARE @s varchar(300)

SET 	@crsdepartment = cursor for 
		select  iddbdepartment from dbdepartment
		where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @iddbdepartment='amm'
		set @s = @iddbdepartment + '.exp_mod_spesometro_SE'
		
INSERT INTO #RECORD_D(
	idreg,
	SE001012_dataemissionefattura,
	SE001013_dataregistrazionefattura,
	SE001014_numfattura,
	SE001015_imponibile,
	SE001016_imposta,
	SE001017_confermaimporto
	)
	EXEC @s @ayear, @month
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
	SE001017_confermaimporto int-- dato obbligatorio se l'importo è maggiore di 999999
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
SELECT
 @codfiscEnte as 'CF ente',
 @PivaEnte as 'P.iva',
 @cudactivitycode as 'Codice attività ATECO',
 @TelEnte as 'Tel.',
 @FaxEnte as 'FAX ',
 @EmailEnte as 'e-mail',
 @DenominazioneEnte as 'Denominazione',
 SUBSTRING(REPLICATE('0',8),1,8-len(substring(convert(char(8), D.ProgressivoModulo),1,8))) + convert(varchar(4), D.ProgressivoModulo)as 'Progressivo',
 -- soggetto tenuto alla comunicazione
@CFdelrappresentante as 'CF del soggetto tenuto alla comunicazione',
@codiceCaricaRappresentante as 'Codice Carica',
@CognomeRappresentante as 'Cognome',
@NomeRappresentante as 'Nome',
@DataNascitaRappresentante	as 'Data nascita',
@ComuneNascitaRappresentante as 'Comune nascita',
@ProvinciaNascitaRappresentante	as 'pv.nascita',

 -- Fine campi posizionali

 CASE when (A.SE001001_cognome is not null) then  SE001001_cognome else''  end as 'SE001001',
 CASE when (A.SE001001_cognome is not null) then  SE001002_nome else''  end as 'SE001002',
 CASE when (A.SE001001_cognome is not null) then  convert(varchar(8),SE001003_datanascita) else''  end as 'SE001003',
 CASE when (A.SE001001_cognome is not null) then  SE001004_comune else''  end as 'SE001004',
 CASE when (A.SE001001_cognome is not null) then  SE001005_provincia else''  end  as 'SE001005',
 CASE when (A.SE001001_cognome is not null) then  convert(varchar(4),SE001006_codicestatoestero) else''  end as 'SE001006',
 case when (A.SE001007_denominazione is not null) then SE001007_denominazione else''  end as 'SE001007',
 case when (A.SE001007_denominazione is not null) then SE001008_cittàestera else''  end as 'SE001008',
 case when (A.SE001007_denominazione is not null) then convert(varchar(4),SE001009_codicestatoestero) else''  end as 'SE001009',
 case when (A.SE001007_denominazione is not null) then SE001010_indirizzoestero else''  end as 'SE001010',
 case when SE001011_CodIVA is not null then  SE001011_CodIVA else''  end as 'SE001011',
 case when SE001012_dataemissionefattura is not null 
	then convert(varchar(8),SE001012_dataemissionefattura) else''  end	 as 'SE001012',
 case when SE001013_dataregistrazionefattura is not null 
	then convert(varchar(8),SE001013_dataregistrazionefattura) else''  end	 as 'SE001013',
 case when SE001014_numfattura is not null 
	then  SE001014_numfattura else''  end	 as 'SE001014',
 case when SE001015_imponibile is not null 
	then  convert(varchar(20),SE001015_imponibile) else''  end	 as 'SE001015',
 case when SE001016_imposta is not null 
	then convert(varchar(20),SE001016_imposta) else''  end	 as 'SE001016',
 case when SE001017_confermaimporto is not null 
	then convert(varchar(1),SE001017_confermaimporto) else''  end	 as 'SE001017'
FROM #RECORD_D_UNIFIED D
JOIN #ANAGRAFICHE A
	ON D.idreg = A.idreg



END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


exec exp_mod_spesometro_SE_dati_unified 2013,10


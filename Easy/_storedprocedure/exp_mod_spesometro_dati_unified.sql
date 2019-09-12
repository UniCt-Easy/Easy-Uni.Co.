if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro_dati_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro_dati_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_mod_spesometro_dati_unified](
	@ayear int,
	@kind char(1), --F: op.esposte in fattura, B:op.da blacklist e va indicato anche il trimestre di riferimento
	@trimestre int, -- Per B è possibile specificare o il trimestre o il mese
	@mese int 
)
AS BEGIN
--setuser'amministrazione'
--exec exp_mod_spesometro_dati_unified 2017, 'F',null,null
declare @ayear_dichiarazione int
set @ayear_dichiarazione = @ayear


SET @ayear = @ayear -1

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
WHERE trasmissionmanager.idtrasmissiondocument = @idtrasmissiondocument AND ayear = @ayear_dichiarazione


CREATE TABLE #RECORD_C(
	idreg int,
	ProgressivoModulo int , -- Impostare ad 1 per il primo modulo di ogni quadro compilato, incrementando tale valore di una unità per ogni ulteriore modulo
-->> QUADRO FA - Operazioni documentate da fattura esposte in forma aggregata
	FA001004_num_op_attive_aggregate int,
	FA001005_num_op_passive_aggregate int,
	FA001006_noleggioleasing char(1),
	FA001007_op_imponibili_nonimponibili_esenti_ven int,
	FA001008_imposta_ven  int,
	FA001009_op_iva_nonesposta_ven int,
	FA001010_var_debito_ven  int,
	FA001011_var_debito_imposta_ven  int,
	FA001012_op_imponibili_nonimponibili_esenti_acqu int,
	FA001013_imposta_acqu  int,
	FA001014_op_iva_nonesposta_acqu  int,
	FA001015_var_credito_acqu int,
	FA001016_var_credito_imposta_acqu  int,
-->>	QUADRO BL
--	 OPERAZIONI CON SOGGETTI AVENTI SEDE, RESIDENZA O DOMICILIO IN PAESI CON FISCALITÀ PRIVILEGIATA
--	 OPERAZIONI CON SOGGETTI NON RESIDENTI IN FORMA AGGREGATA
--	 ACQUISTI DI SERVIZI DA NON RESIDENTI IN FORMA AGGREGATA
-- BL002
	BL002002_Blacklist int,
	BL002003_NonResident int,
	BL002004_Acqu_NonResidenti int,
-- Operazioni ATTIVE
-- BL003 - Operazioni imponibili, non imponibili ed esenti. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" o "Operazioni con soggetti non residenti" 
	BL003001_importocomplessivo int,
	BL003002_imposta int,
-- BL004 - Operazioni non soggette ad IVA. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata"
	BL004001_cessionebeni int,
	BL004002_servizi int,
--BL005 - Note di variazione. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" (caselle BL002002) 
	BL005001_importocomplessivo int,
	BL005002_imposta int,
-- Operazioni PASSIVE
--BL006 - Operazioni imponibili, non imponibili ed esenti. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" o "Operazioni con soggetti non residenti" 
	BL006001_importocomplessivo int,
	BL006002_imposta int,
-- BL007 - Operazioni non soggette ad IVA. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" 
	BL007001_importocomplessivo int,
-- BL008 - Note di variazione. La sezione può essere compilata solo in caso di "Operazioni con paesi con fiscalità privilegiata" 
	BL008001_importocomplessivo int,
	BL008002_imposta int
)


DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor
DECLARE @spname varchar(300)

SET 	@crsdepartment = cursor for 
		select  iddbdepartment from dbdepartment
		where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @spname = @iddbdepartment + '.exp_mod_spesometro'
		
INSERT INTO #RECORD_C(
	idreg,
	FA001004_num_op_attive_aggregate,
	FA001005_num_op_passive_aggregate,
	FA001006_noleggioleasing,
	FA001007_op_imponibili_nonimponibili_esenti_ven,
	FA001008_imposta_ven,
	FA001009_op_iva_nonesposta_ven,
	FA001010_var_debito_ven,
	FA001011_var_debito_imposta_ven,
	FA001012_op_imponibili_nonimponibili_esenti_acqu,
	FA001013_imposta_acqu,
	FA001014_op_iva_nonesposta_acqu,
	FA001015_var_credito_acqu,
	FA001016_var_credito_imposta_acqu,
	BL002002_Blacklist,
	BL002003_NonResident,
	BL002004_Acqu_NonResidenti,
	BL003001_importocomplessivo,
	BL003002_imposta,
	BL004001_cessionebeni,
	BL004002_servizi,
	BL005001_importocomplessivo,
	BL005002_imposta,
	BL006001_importocomplessivo,
	BL006002_imposta,
	BL007001_importocomplessivo,
	BL008001_importocomplessivo,
	BL008002_imposta 
	)
	EXEC @spname @ayear , @kind, @trimestre,	@mese
	FETCH next FROM @crsdepartment INTO @iddbdepartment
END
CLOSE @crsdepartment
DEALLOCATE @crsdepartment

CREATE TABLE #RECORD_C_UNIFIED(
	idreg int,
	ProgressivoModulo int identity(1,1),
	FA001004_num_op_attive_aggregate int,
	FA001005_num_op_passive_aggregate int,
	FA001006_noleggioleasing char(1),
	FA001007_op_imponibili_nonimponibili_esenti_ven decimal(19,2),-- NP campo numerico positivo
	FA001008_imposta_ven  decimal(19,2),
	FA001009_op_iva_nonesposta_ven  decimal(19,2),
	FA001010_var_debito_ven  decimal(19,2),
	FA001011_var_debito_imposta_ven  decimal(19,2),
	FA001012_op_imponibili_nonimponibili_esenti_acqu decimal(19,2),
	FA001013_imposta_acqu  decimal(19,2),
	FA001014_op_iva_nonesposta_acqu  decimal(19,2),
	FA001015_var_credito_acqu  decimal(19,2),
	FA001016_var_credito_imposta_acqu  decimal(19,2),
	BL002002_Blacklist int,
	BL002003_NonResident int ,
	BL002004_Acqu_NonResidenti int,
	BL003001_importocomplessivo int,
	BL003002_imposta int,
	BL004001_cessionebeni int,
	BL004002_servizi int,
	BL005001_importocomplessivo int,
	BL005002_imposta int,
	BL006001_importocomplessivo int,
	BL006002_imposta int,
	BL007001_importocomplessivo int,
	BL008001_importocomplessivo int,
	BL008002_imposta int
)


INSERT INTO #RECORD_C_UNIFIED(
	idreg,
	FA001004_num_op_attive_aggregate,
	FA001005_num_op_passive_aggregate,
	FA001006_noleggioleasing,
	FA001007_op_imponibili_nonimponibili_esenti_ven,
	FA001008_imposta_ven,
	FA001009_op_iva_nonesposta_ven,
	FA001010_var_debito_ven ,
	FA001011_var_debito_imposta_ven,
	FA001012_op_imponibili_nonimponibili_esenti_acqu,
	FA001013_imposta_acqu,
	FA001014_op_iva_nonesposta_acqu,
	FA001015_var_credito_acqu,
	FA001016_var_credito_imposta_acqu,
	BL002002_Blacklist,
	BL002003_NonResident,
	BL002004_Acqu_NonResidenti,
	BL003001_importocomplessivo,
	BL003002_imposta,
	BL004001_cessionebeni,
	BL004002_servizi,
	BL005001_importocomplessivo,
	BL005002_imposta,
	BL006001_importocomplessivo,
	BL006002_imposta,
	BL007001_importocomplessivo,
	BL008001_importocomplessivo,
	BL008002_imposta 
)
SELECT 
	idreg,
	isnull(sum(FA001004_num_op_attive_aggregate),0) as FA001004_num_op_attive_aggregate,
	isnull(sum(FA001005_num_op_passive_aggregate),0) as FA001005_num_op_passive_aggregate,
	isnull(FA001006_noleggioleasing,'') as FA001006_noleggioleasing,
	isnull(sum(FA001007_op_imponibili_nonimponibili_esenti_ven),0) as FA001007_op_imponibili_nonimponibili_esenti_ven,
	isnull(sum(FA001008_imposta_ven),0) as FA001008_imposta_ven,
	isnull(sum(FA001009_op_iva_nonesposta_ven),0) as FA001009_op_iva_nonesposta_ven,
	isnull(sum(FA001010_var_debito_ven),0) as FA001010_var_debito_ven,
	isnull(sum(FA001011_var_debito_imposta_ven),0) as FA001011_var_debito_imposta_ven,
	isnull(sum(FA001012_op_imponibili_nonimponibili_esenti_acqu),0) as FA001012_op_imponibili_nonimponibili_esenti_acqu,
	isnull(sum(FA001013_imposta_acqu),0) as FA001013_imposta_acqu,
	isnull(sum(FA001014_op_iva_nonesposta_acqu),0) as FA001014_op_iva_nonesposta_acqu,
	isnull(sum(FA001015_var_credito_acqu),0) as FA001015_var_credito_acqu,
	isnull(sum(FA001016_var_credito_imposta_acqu),0) as FA001016_var_credito_imposta_acqu,
	isnull(sum(BL002002_Blacklist),0) as BL002002_Blacklist, -- CB
	isnull(sum(BL002003_NonResident),0) as BL002003_NonResident, -- CB
	isnull(sum(BL002004_Acqu_NonResidenti),0) as BL002004_Acqu_NonResidenti, --CB
	isnull(sum(BL003001_importocomplessivo),0) as BL003001_importocomplessivo,
	isnull(sum(BL003002_imposta),0) as BL003002_imposta,
	isnull(sum(BL004001_cessionebeni),0) as BL004001_cessionebeni,
	isnull(sum(BL004002_servizi),0) as BL004002_servizi,
	isnull(sum(BL005001_importocomplessivo),0) as BL005001_importocomplessivo,
	isnull(sum(BL005002_imposta),0) as BL005002_imposta,
	isnull(sum(BL006001_importocomplessivo),0) as BL006001_importocomplessivo,
	isnull(sum(BL006002_imposta),0) as BL006002_imposta,
	isnull(sum(BL007001_importocomplessivo),0) as BL007001_importocomplessivo,
	isnull(sum(BL008001_importocomplessivo),0) as BL008001_importocomplessivo,
	isnull(sum(BL008002_imposta),0) as BL008002_imposta
FROM #RECORD_C
GROUP BY idreg,isnull(FA001006_noleggioleasing,'')

CREATE TABLE #ANAGRAFICHE(
	idreg int,
	FA001001_piva varchar(11),
	FA001002_cf varchar(16),
	BL001001_cognome varchar(50), 
	BL001002_nome varchar(50),
	BL001003_datanascita datetime,
	BL001004_comune varchar(65),
	BL001005_provincia varchar(2),
	BL001006_codicestatoestero int,
	BL001007_denominazione varchar(100),
	BL001008_cittàestera varchar(65),
	BL001009_codicestatoestero varchar(20), 
	BL001010_indirizzoestero varchar(100),
	BL002001_CodIVA varchar(20)
)
	
-- Inserire Piva e CF delle anagrafiche del quadro FA	
-- Usiamo il distinct perchè in #RECORD_C_UNIFIED, potrebbero esserci due righe per la stessa anagrafica, una con FA001006_noleggioleasing = S e una con FA001006_noleggioleasing = N
INSERT INTO #ANAGRAFICHE(idreg, FA001001_piva,FA001002_cf)				
SELECT distinct R.idreg, R.p_iva, R.cf
FROM registry R
JOIN #RECORD_C_UNIFIED C
	ON R.idreg = C.idreg
WHERE isnull(FA001004_num_op_attive_aggregate,0) >0
	OR
	isnull(FA001005_num_op_passive_aggregate,0)>0

declare @31dic datetime
set @31dic = dateadd(yy, (@ayear-1)-2000, {d '2000-12-31'})


-- Inserire dati anagrafici delle anagrafiche del quadro BL
INSERT INTO #ANAGRAFICHE(idreg, 
	BL001001_cognome,		--Persona Fisica
	BL001002_nome,			--Persona Fisica
	BL001003_datanascita,	--Persona Fisica
	BL001004_comune,		--Persona Fisica
	BL001005_provincia,		--Persona Fisica
	BL001006_codicestatoestero,	--Persona Fisica

	BL001007_denominazione,		-- Persona NON Fisica
	BL001008_cittàestera,		-- Persona NON Fisica
	BL001009_codicestatoestero, -- Persona NON Fisica
	BL001010_indirizzoestero,	-- Persona NON Fisica
	BL002001_CodIVA 
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
	-- BL001008_cittàestera: Città estera delle Sede legale
	CASE 
		WHEN idregistryclass <> 22 and (NATION_ADDRESS.title IS NOT NULL )
		THEN NATION_ADDRESS.title
		ELSE null
	END,
	--BL001009_codicestatoestero
	CASE 
		WHEN idregistryclass <> 22 and (NATION_ADDRESS_AGENCY.value IS NOT NULL )
		THEN NATION_ADDRESS_AGENCY.value
		ELSE null
	END,
	--BL001010_indirizzoestero
	CASE 
		WHEN idregistryclass <> 22 and (RA.address IS NOT NULL )
		THEN RA.address
		ELSE null
	END,
--	BL002001_CodIVA 
	CASE 
		WHEN idregistryclass <> 22 and (R.foreigncf IS NOT NULL )
		THEN R.foreigncf
		ELSE null
	END
FROM registry R
JOIN #RECORD_C_UNIFIED C
	ON R.idreg = C.idreg
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
	AND ( BL002002_Blacklist = 1 or BL002003_NonResident = 1 or BL002004_Acqu_NonResidenti = 1)

-- RECORD "C"
if(@kind = 'F')
Begin 
	SELECT
	 @codfiscEnte as 'CF ente',
	 @PivaEnte as 'P.iva',
	 @cudactivitycode as 'Codice attività ATECO',
	 @TelEnte as 'Tel.',
	 @FaxEnte as 'FAX ',
	 @EmailEnte as 'e-mail',
	 @DenominazioneEnte as 'Denominazione Ente',
	-- soggetto tenuto alla comunicazione
	@CFdelrappresentante as 'CF del soggetto tenuto alla comunicazione',
	@codiceCaricaRappresentante as 'Codice Carica',
	@CognomeRappresentante as 'Cognome',
	@NomeRappresentante as 'Nome',
	@DataNascitaRappresentante	as 'Data nascita',
	@ComuneNascitaRappresentante as 'Comune nascita',
	@ProvinciaNascitaRappresentante	as 'prov.nascita',

	 SUBSTRING(REPLICATE('0',8),1,8-len(substring(convert(char(8), C.ProgressivoModulo),1,8))) + convert(varchar(4), C.ProgressivoModulo) as 'Progressivo',
	 case 
		when (A.FA001001_piva is not null)	then  convert(varchar(20),A.FA001001_piva)
		else''  end as 'FA001001',
	 case 
		when (A.FA001001_piva is not null) then  ''
		when (A.FA001001_piva is null and A.FA001002_cf is not null) then  convert(varchar(20),A.FA001002_cf) 
		else''  end as 'FA001002',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null)  AND FA001004_num_op_attive_aggregate >0   
		then  convert(varchar(20),FA001004_num_op_attive_aggregate)	
		else '' end as 'FA001004',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null)  AND FA001005_num_op_passive_aggregate >0  
		then  convert(varchar(20),FA001005_num_op_passive_aggregate	)	
		else ''
		end as 'FA001005',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) AND FA001006_noleggioleasing ='N'
		then   convert(varchar(20),'')
		when (isnull(A.FA001001_piva,A.FA001002_cf) is not null)
		then   convert(varchar(20),FA001006_noleggioleasing)
		else'' end as 'FA001006',
	CASE when isnull(FA001004_num_op_attive_aggregate,0) >0
		then  convert(varchar(20),FA001007_op_imponibili_nonimponibili_esenti_ven 	)
		else '' end as 'FA001007',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001008_imposta_ven>0
		then   convert(varchar(20),FA001008_imposta_ven ) 
		else ''  end as 'FA001008',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001009_op_iva_nonesposta_ven>0
		then     convert(varchar(20),FA001009_op_iva_nonesposta_ven ) 
		else ''  end as 'FA001009',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001010_var_debito_ven>0
		then   convert(varchar(20),FA001010_var_debito_ven ) 
		else ''  end as 'FA001010',
	CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001011_var_debito_imposta_ven>0
		then  convert(varchar(20),FA001011_var_debito_imposta_ven ) 
		else ''  end as 'FA001011',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001012_op_imponibili_nonimponibili_esenti_acqu>0
		then	convert(varchar(20),FA001012_op_imponibili_nonimponibili_esenti_acqu )   
		else ''  end 'FA001012',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001013_imposta_acqu>0
		then   convert(varchar(20),FA001013_imposta_acqu )  
		else ''  end as 'FA001013',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001014_op_iva_nonesposta_acqu>0
		then   convert(varchar(20),FA001014_op_iva_nonesposta_acqu )   
		else ''  end as 'FA001014',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001015_var_credito_acqu>0
		then    convert(varchar(20),FA001015_var_credito_acqu ) 
		else ''  end as 'FA001015',
	 CASE when (isnull(A.FA001001_piva,A.FA001002_cf) is not null) and FA001016_var_credito_imposta_acqu>0
		then   convert(varchar(20),FA001016_var_credito_imposta_acqu )  
		else ''  end as 'FA001016'
	FROM #RECORD_C_UNIFIED C
	JOIN #ANAGRAFICHE A
		ON C.idreg = A.idreg
	where (A.FA001001_piva is not null or  A.FA001002_cf is not null ) 
end
else
begin
	SELECT
	 @codfiscEnte as 'CF ente',
	 @PivaEnte as 'P.iva',
	 @cudactivitycode as 'Codice attività ATECO',
	 @TelEnte as 'Tel.',
	 @FaxEnte as 'FAX ',
	 @EmailEnte as 'e-mail',
	 @DenominazioneEnte as 'Denominazione Ente',
	-- soggetto tenuto alla comunicazione
	@CFdelrappresentante as 'CF del soggetto tenuto alla comunicazione',
	@codiceCaricaRappresentante as 'Codice Carica',
	@CognomeRappresentante as 'Cognome',
	@NomeRappresentante as 'Nome',
	@DataNascitaRappresentante	as 'Data nascita',
	@ComuneNascitaRappresentante as 'Comune nascita',
	@ProvinciaNascitaRappresentante	as 'prov.nascita',

	 CASE when (A.BL001001_cognome is not null) then  BL001001_cognome else''  end as 'BL001001',
	 CASE when (A.BL001001_cognome is not null) then  BL001002_nome else''  end as 'BL001002',
	 CASE when (A.BL001001_cognome is not null) then  convert(varchar(8),BL001003_datanascita) else''  end as 'BL001003',
	 CASE when (A.BL001001_cognome is not null) then  BL001004_comune else''  end as 'BL001004',
	 CASE when (A.BL001001_cognome is not null) then  BL001005_provincia else''  end as 'BL001005',
	 CASE when (A.BL001001_cognome is not null) then  convert(varchar(4),BL001006_codicestatoestero) else''  end as 'BL001006',
	 case when (A.BL001007_denominazione is not null) then  BL001007_denominazione else''  end as 'BL001007',
	 case when (A.BL001007_denominazione is not null) then  BL001008_cittàestera else''  end as 'BL001008',
	 case when (A.BL001007_denominazione is not null) then  convert(varchar(4),BL001009_codicestatoestero) else''  end as 'BL001009',
	 case when (A.BL001007_denominazione is not null) then  BL001010_indirizzoestero else''  end as 'BL001010',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002001_CodIVA is not null then  BL002001_CodIVA else''  end as 'BL002001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002002_Blacklist=1 then  '1' else''  end as 'BL002002',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002003_NonResident=1 then '1' else''  end  as 'BL002003',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002004_Acqu_NonResidenti=1 then  '1' else''  end  as 'BL002004',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL003001_importocomplessivo is not null 
		then  convert(varchar(20),BL003001_importocomplessivo) else''  end	 as 'BL003001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL003002_imposta is not null 
		then convert(varchar(20),BL003002_imposta) else''  end		 as 'BL003002',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL004001_cessionebeni is not null 
		then  convert(varchar(20),BL004001_cessionebeni) else''  end		 as 'BL004001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL004002_servizi is not null 
		then  convert(varchar(20),BL004002_servizi) else''  end		 as 'BL004002',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL005001_importocomplessivo is not null 
		then  convert(varchar(20),BL005001_importocomplessivo) else''  end		 as 'BL005001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL005002_imposta is not null 
		then  convert(varchar(20),BL005002_imposta) else''  end		 as 'BL005002',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL006001_importocomplessivo is not null 
		then  convert(varchar(20),BL006001_importocomplessivo) else''  end	 as 'BL006001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL006002_imposta is not null 
		then  convert(varchar(20),BL006002_imposta) else''  end		 as 'BL006002',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL007001_importocomplessivo is not null 
		then  convert(varchar(20),BL007001_importocomplessivo) else''  end		 as 'BL007001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL008001_importocomplessivo is not null 
		then  convert(varchar(20),BL008001_importocomplessivo) else''  end		 as 'BL008001',
	 case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL008002_imposta is not null 
		then  convert(varchar(20),BL008002_imposta) else''  end		 as 'BL008002'
	FROM #RECORD_C_UNIFIED C
	JOIN #ANAGRAFICHE A
		ON C.idreg = A.idreg
	WHERE A.BL001001_cognome is not null OR A.BL001007_denominazione is not null
end




END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



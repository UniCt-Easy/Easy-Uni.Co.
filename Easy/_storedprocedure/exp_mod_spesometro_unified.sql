
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_spesometro_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_spesometro_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec exp_mod_spesometro_unified 2016, 'F', 1,1
CREATE       PROCEDURE [exp_mod_spesometro_unified](
	@ayear int,
	@kind char(1),  --F: op.esposte in fattura, B:op.da blacklist e va indicato anche il trimestre di riferimento
	@trimestre int, -- Per B è possibile specificare o il trimestre o il mese
	@mese int 
)
AS BEGIN

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
	@TelEnte = ISNULL(substring(replace(phonenumber,'-',''),1,12),space(12))	+ substring(space(12),1,12-DATALENGTH(ISNULL(substring(replace(phonenumber,'-',''),1,12),space(12)))),
	@FaxEnte = ISNULL(substring(replace(fax,'-',''),1,12), space(12))			+ substring(space(12),1,12-DATALENGTH(ISNULL(substring(replace(fax,'-',''),1,12),space(12)))),
	@EmailEnte = ISNULL(substring(email, 1,50),space(50))		+ substring(space(50),1,50-DATALENGTH(ISNULL(substring(email,1,50),space(50))))
	--@location = SUBSTRING(isnull(geo_city.title, license.location), 1, 40),
	--@country = license.country,
	--@address = SUBSTRING(license.address1, 1, 35),
	--@cap = license.cap
FROM license
	
DECLARE @idtrasmissiondocument varchar(10)
SET @idtrasmissiondocument = 'SPESOMETRO'

-- Tabella di output
CREATE TABLE #traceByRecord(recordkind char(1), out_str varchar(1900)) -- I byte, fino al raggiungimento della posizione 1897 di ogni record a struttura variabile, 
							-- eventualmente inutilizzati devono essere inizializzati con spazi.
							-- Quindi dobbiamo contare lo spazio utilizzato, per capire quanti spaze aggiungere
CREATE TABLE #trace(out_str varchar(1900), orderrow int) -- record a lunghezza fissa di 1900 caratteri


IF(
(SELECT COUNT(*) FROM trasmissionmanager
WHERE idtrasmissiondocument = @idtrasmissiondocument and ayear = @ayear_dichiarazione ) = 0)
BEGIN
	INSERT INTO #trace(out_str)
	VALUES('Inserire il Responsabile della trasmissione dello Spesometro. Andare in Configurazione\Configurazione\Responsabile della trasmissione...')
	select out_str as ERRORE from #trace
	RETURN
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
	WHERE trasmissionmanager.idtrasmissiondocument = @idtrasmissiondocument AND ayear = @ayear_dichiarazione


INSERT INTO #traceByRecord (recordkind, out_str)
-- RECORD "A"
select
'A',
'A'
+ space(14) -- Filler
+ 'NSP00' -- Codice fornitura
+ '01' -- Soggetti che inviano la proprio comunciazione
+ @CFdelrappresentante --@CFdelrappresentanteCF del soggetto obbligato alla comunicazione
+ space(483) -- Filler
+ '0000' -- Progressivo Invio Telematico  CONTROLLARE -- Avevo impostato ad 1, ma il file veniva rifiutato,
+ '0000' -- Numero totale degli invii telematici CONTROLLARE -- idem come sopra
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
+ '1'	-- Quadro FA – Operazioni documentate da fattura esposte in forma aggregata 
+ '0'	-- Quadro SA – Operazioni senza fattura esposte in forma aggregata = Registri corrispettivi. DA NON COMPILARE
		--Quadro BL - Op.con soggetti aventi sede, residenza o domicilio in paesi con fiscalità privilegiata;Op.con soggetti non residenti in forma aggregata;Acquisti di servizi da non residenti in forma aggregata .
+ case	when (@kind='F') then '0'
		else '1'
 end
+ '0'-- Quadro FE - Relativo alla comunicazione analitica 
+ '0'-- Quadro FR - Relativo alla comunicazione analitica 
+ '0'-- Quadro NE - Relativo alla comunicazione analitica 
+ '0'-- Quadro NR - Relativo alla comunicazione analitica 
+ '0'-- Quadro DF - Relativo alla comunicazione analitica 
+ '0'-- Quadro FN - Relativo alla comunicazione analitica 
+ '0'-- Quadro SE – Limitatamente agli acquisti con operatori di San Marino(scritto nel pdf).  Acquisti di servizi da non residenti e Acquisti da operatori di San Marino.
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
+ replicate('0',8)	-- data di nascita
+ space(40) -- comune di nascita
+ space(2)	-- provincia di nascita
-- Dati del Soggetto cui si riferisce la comunicazione - Persona non fisica
+ @DenominazioneEnte
+ convert(varchar(4),@ayear_dichiarazione) -- Anno riferimento
-- Trimestre/Mese riferimento. Il mese va valorizzare obbligatoriamente solo se presenti Acquisti da Operatori di San Marino. 
	--il trimestre per op. da Black list.In tutti gli altri casi non deve essere compilato
+ case	when (@kind='B' and @trimestre is not null) then 'T'+ convert(char(1),@trimestre)
		when (@kind='B' and @mese is not null) then SUBSTRING(REPLICATE(' ',2),1,2-len(substring(convert(char(2), @mese),1,2))) + convert(varchar(2), @mese)
		when @kind='F' then space(2)
	end
-->> Dati del Soggetto tenuto alla comunicazione(soggetto che effettua la comunicazione, se diverso dal soggetto cui si riferisce la comunicazione)->RETTORE
+ @CFdelrappresentante -- CF
+ @codiceCaricaRappresentante -- codice carica
+ replicate('0',8) -- Data inizio procedura o data di decesso del contribuente NO
+ replicate('0',8) -- data fine procedura NO
+ @CognomeRappresentante --cognome
+ @NomeRappresentante -- nome
+ @SessoRappresentante	--sesso
+ @DataNascitaRappresentante	-- data di nascita
+ @ComuneNascitaRappresentante	-- comune di nascita
+ @ProvinciaNascitaRappresentante	-- provincia di nascita
+ space(60) -- denominazione NO

-->>Impegno alla trasmissione telematica
+ space(16)--- CF intermediario
+ REPLICATE('0',5)  -- n.iscrizione CAF
+ REPLICATE('0',1)
+ space(1)	--filler
+ replicate('0',8) -- data dell'impegno
+ space(1258) -- Filler
+ space(20)  -- Filler
+ space(18)	-- Fillee
+ 'A'


-- RECORD "C" -> Solo importi

CREATE TABLE #RECORD_C(
	idreg int,
	Progressivo int , -- Impostare ad 1 per il primo modulo di ogni quadro compilato, incrementando tale valore di una unità per ogni ulteriore modulo
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
	FA001015_var_credito_acqu  int,
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
		--AND iddbdepartment ='amm'
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
	EXEC @spname @ayear, @kind, @trimestre,	@mese

	FETCH next FROM @crsdepartment INTO @iddbdepartment
END
CLOSE @crsdepartment
DEALLOCATE @crsdepartment

CREATE TABLE #RECORD_C_UNIFIED(
	idreg int,
	Progressivo int identity(1,1),
	FA001004_num_op_attive_aggregate int,
	FA001005_num_op_passive_aggregate int,
	FA001006_noleggioleasing char(1),
	FA001007_op_imponibili_nonimponibili_esenti_ven int,-- NP campo numerico positivo
	FA001008_imposta_ven  int,
	FA001009_op_iva_nonesposta_ven  int,
	FA001010_var_debito_ven  int,
	FA001011_var_debito_imposta_ven  int,
	FA001012_op_imponibili_nonimponibili_esenti_acqu int,
	FA001013_imposta_acqu  int,
	FA001014_op_iva_nonesposta_acqu  int,
	FA001015_var_credito_acqu  int,
	FA001016_var_credito_imposta_acqu  int,
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
	BL008002_imposta int,
	colonnaFA int,
	riga_recC varchar(5) -- Valorizziamo quadro riga_recC, tipo FA001, FA002, poi nella select finale faremo riga_recC+001=> FA001001, FA001002...FA001016.FA002001, FA002002...FA002016
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
	isnull(FA001006_noleggioleasing,'N') as FA001006_noleggioleasing,
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
GROUP BY idreg,isnull(FA001006_noleggioleasing,'N')


if(@kind='F')
Begin
	--UPDATE	#RECORD_C_UNIFIED set riga_recC= SUBSTRING(REPLICATE('0',3),1,3-len(substring(convert(char(3), Progressivo),1,3))) + convert(varchar(3), Progressivo)
	update #RECORD_C_UNIFIED set riga_recC = CASE 
									when Progressivo<=3 then 1
									when (Progressivo % 3)=0 then Progressivo/3
									when (Progressivo %3)<>0 then Progressivo/3+1
								end
End

CREATE TABLE #RECORD_C_UNIFIED_FA(
	FA001_idreg int,FA002_idreg int,FA003_idreg int,
	riga_recC int,
	FA001004_num_op_attive_aggregate int,
	FA001005_num_op_passive_aggregate int,
	FA001006_noleggioleasing char(1),
	FA001007_op_imponibili_nonimponibili_esenti_ven int,
	FA001008_imposta_ven  int,
	FA001009_op_iva_nonesposta_ven  int,
	FA001010_var_debito_ven  int,
	FA001011_var_debito_imposta_ven  int,
	FA001012_op_imponibili_nonimponibili_esenti_acqu int,
	FA001013_imposta_acqu  int,
	FA001014_op_iva_nonesposta_acqu  int,
	FA001015_var_credito_acqu  int,
	FA001016_var_credito_imposta_acqu int,
		
	FA002004_num_op_attive_aggregate int,
	FA002005_num_op_passive_aggregate int,
	FA002006_noleggioleasing char(1),
	FA002007_op_imponibili_nonimponibili_esenti_ven int,
	FA002008_imposta_ven  int,
	FA002009_op_iva_nonesposta_ven  int,
	FA002010_var_debito_ven  int,
	FA002011_var_debito_imposta_ven  int,
	FA002012_op_imponibili_nonimponibili_esenti_acqu int,
	FA002013_imposta_acqu  int,
	FA002014_op_iva_nonesposta_acqu  int,
	FA002015_var_credito_acqu  int,
	FA002016_var_credito_imposta_acqu int,

	FA003004_num_op_attive_aggregate int,
	FA003005_num_op_passive_aggregate int,
	FA003006_noleggioleasing char(1),
	FA003007_op_imponibili_nonimponibili_esenti_ven int,
	FA003008_imposta_ven  int,
	FA003009_op_iva_nonesposta_ven  int,
	FA003010_var_debito_ven  int,
	FA003011_var_debito_imposta_ven  int,
	FA003012_op_imponibili_nonimponibili_esenti_acqu int,
	FA003013_imposta_acqu  int,
	FA003014_op_iva_nonesposta_acqu  int,
	FA003015_var_credito_acqu  int,
	FA003016_var_credito_imposta_acqu int,
	)
INSERT INTO	#RECORD_C_UNIFIED_FA(
	FA001_idreg  ,
	riga_recC  ,
	FA001004_num_op_attive_aggregate  ,
	FA001005_num_op_passive_aggregate  ,
	FA001006_noleggioleasing ,
	FA001007_op_imponibili_nonimponibili_esenti_ven  ,
	FA001008_imposta_ven   ,
	FA001009_op_iva_nonesposta_ven   ,
	FA001010_var_debito_ven   ,
	FA001011_var_debito_imposta_ven   ,
	FA001012_op_imponibili_nonimponibili_esenti_acqu  ,
	FA001013_imposta_acqu   ,
	FA001014_op_iva_nonesposta_acqu   ,
	FA001015_var_credito_acqu   ,
	FA001016_var_credito_imposta_acqu   
)

select 	idreg  ,
	riga_recC  ,
	FA001004_num_op_attive_aggregate  ,
	FA001005_num_op_passive_aggregate  ,
	FA001006_noleggioleasing ,
	FA001007_op_imponibili_nonimponibili_esenti_ven  ,
	FA001008_imposta_ven   ,
	FA001009_op_iva_nonesposta_ven   ,
	FA001010_var_debito_ven   ,
	FA001011_var_debito_imposta_ven   ,
	FA001012_op_imponibili_nonimponibili_esenti_acqu  ,
	FA001013_imposta_acqu   ,
	FA001014_op_iva_nonesposta_acqu   ,
	FA001015_var_credito_acqu   ,
	FA001016_var_credito_imposta_acqu    
 from #RECORD_C_UNIFIED 
where Progressivo = (select min(R2.Progressivo) from #RECORD_C_UNIFIED R2 where R2.riga_recC = #RECORD_C_UNIFIED.riga_recC)


update #RECORD_C_UNIFIED_FA
set FA002_idreg=	#RECORD_C_UNIFIED.idreg  ,
	riga_recC = #RECORD_C_UNIFIED.riga_recC  ,
	FA002004_num_op_attive_aggregate = #RECORD_C_UNIFIED.FA001004_num_op_attive_aggregate  ,
	FA002005_num_op_passive_aggregate = #RECORD_C_UNIFIED.FA001005_num_op_passive_aggregate  ,
	FA002006_noleggioleasing = #RECORD_C_UNIFIED.FA001006_noleggioleasing  ,
	FA002007_op_imponibili_nonimponibili_esenti_ven = #RECORD_C_UNIFIED.FA001007_op_imponibili_nonimponibili_esenti_ven  ,
	FA002008_imposta_ven = #RECORD_C_UNIFIED.FA001008_imposta_ven   ,
	FA002009_op_iva_nonesposta_ven  = #RECORD_C_UNIFIED.FA001009_op_iva_nonesposta_ven,
	FA002010_var_debito_ven =  #RECORD_C_UNIFIED.FA001010_var_debito_ven,
	FA002011_var_debito_imposta_ven =  #RECORD_C_UNIFIED.FA001011_var_debito_imposta_ven,
	FA002012_op_imponibili_nonimponibili_esenti_acqu = #RECORD_C_UNIFIED.FA001012_op_imponibili_nonimponibili_esenti_acqu  ,
	FA002013_imposta_acqu = #RECORD_C_UNIFIED.FA001013_imposta_acqu  , 
	FA002014_op_iva_nonesposta_acqu = #RECORD_C_UNIFIED.FA001014_op_iva_nonesposta_acqu,
	FA002015_var_credito_acqu = #RECORD_C_UNIFIED.FA001015_var_credito_acqu ,
	FA002016_var_credito_imposta_acqu    =#RECORD_C_UNIFIED.FA001016_var_credito_imposta_acqu
from #RECORD_C_UNIFIED
where #RECORD_C_UNIFIED.Progressivo = (select min(R2.Progressivo)+1 from #RECORD_C_UNIFIED R2 where R2.riga_recC = #RECORD_C_UNIFIED_FA.riga_recC)

update #RECORD_C_UNIFIED_FA
set FA003_idreg=	#RECORD_C_UNIFIED.idreg  ,
	riga_recC = #RECORD_C_UNIFIED.riga_recC  ,
	FA003004_num_op_attive_aggregate = #RECORD_C_UNIFIED.FA001004_num_op_attive_aggregate  ,
	FA003005_num_op_passive_aggregate = #RECORD_C_UNIFIED.FA001005_num_op_passive_aggregate  ,
	FA003006_noleggioleasing = #RECORD_C_UNIFIED.FA001006_noleggioleasing  ,
	FA003007_op_imponibili_nonimponibili_esenti_ven = #RECORD_C_UNIFIED.FA001007_op_imponibili_nonimponibili_esenti_ven  ,
	FA003008_imposta_ven = #RECORD_C_UNIFIED.FA001008_imposta_ven   ,
	FA003009_op_iva_nonesposta_ven  = #RECORD_C_UNIFIED.FA001009_op_iva_nonesposta_ven,
	FA003010_var_debito_ven =  #RECORD_C_UNIFIED.FA001010_var_debito_ven,
	FA003011_var_debito_imposta_ven =  #RECORD_C_UNIFIED.FA001011_var_debito_imposta_ven,
	FA003012_op_imponibili_nonimponibili_esenti_acqu = #RECORD_C_UNIFIED.FA001012_op_imponibili_nonimponibili_esenti_acqu  ,
	FA003013_imposta_acqu = #RECORD_C_UNIFIED.FA001013_imposta_acqu  , 
	FA003014_op_iva_nonesposta_acqu = #RECORD_C_UNIFIED.FA001014_op_iva_nonesposta_acqu,
	FA003015_var_credito_acqu = #RECORD_C_UNIFIED.FA001015_var_credito_acqu ,
	FA003016_var_credito_imposta_acqu    =#RECORD_C_UNIFIED.FA001016_var_credito_imposta_acqu 
 from #RECORD_C_UNIFIED
where #RECORD_C_UNIFIED.Progressivo = (select min(R2.Progressivo)+2 from #RECORD_C_UNIFIED R2 where R2.riga_recC = #RECORD_C_UNIFIED_FA.riga_recC)



CREATE TABLE #ANAGRAFICHE(
	--idRecordFA_BL int identity(1,1),
	idreg int,
	FA_piva varchar(11),
	FA_cf varchar(40),
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
-- Usiamo il distinct perchè in #RECORD_C_UNIFIED, potrebbero esserci n righe per la stessa anagrafica, ma con FA001006_noleggioleasing diverso
if (@kind='F')
begin
	INSERT INTO #ANAGRAFICHE(idreg, FA_piva,FA_cf)				
	SELECT distinct R.idreg, R.p_iva, R.cf
	FROM registry R
	JOIN #RECORD_C_UNIFIED C
		ON R.idreg = C.idreg
	WHERE ( isnull(FA001004_num_op_attive_aggregate,0) >0 		OR 		isnull(FA001005_num_op_passive_aggregate,0)>0)
		and (R.p_iva is not null or  R.cf is not null)
end



declare @31dic datetime
set @31dic = dateadd(yy, (@ayear-1)-2000, {d '2000-12-31'})

-- Inserire dati anagrafici delle anagrafiche del quadro BL
if (@kind='B')
Begin
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
		--AND (BL001001_cognome is not null OR BL001007_denominazione is not null)
End

-- RECORD "C"

IF (@kind='F')
BEGIN
		INSERT INTO #traceByRecord (recordkind, out_str)
		-- RECORD "C"
		SELECT
		'C',
		'C'
		+ @codfiscEnte
		+ SUBSTRING(REPLICATE('0',8),1,8-len(substring(convert(char(8), C.riga_recC),1,8))) + convert(varchar(4), C.riga_recC)
		+ space(3) -- Spazio a disposizione dell'utente
		+ space(25) -- Filler
		+ space(20) -- Spazio utente
		+ @CFsoftwarehouse -- Identificativo produttore SW
		-- Fine campi posizionali
-- FA1
--FA001001	Partita IVA : 11 caratteri,  con zeri a destra
--FA001002	Codice Fiscale : 16 caratteri, oppure 11 numeri con spazi a destra

		+ case 
			when (A1.FA_piva is not null and  A1.FA_cf is not null )	then 'FA001001' + substring(A1.FA_piva, 1, datalength(A1.FA_piva)) + space(16-datalength(A1.FA_piva))--	substring(A1.FA_piva,1,11) + space(5)
			when (A1.FA_piva is not null )								then 'FA001001' + substring(A1.FA_piva, 1, datalength(A1.FA_piva)) + space(16-datalength(A1.FA_piva))
			when (A1.FA_cf is not null)	and len(A1.FA_cf) = 16			then 'FA001002' + A1.FA_cf
			when (A1.FA_cf is not null)	and len(A1.FA_cf) < 16			then 'FA001002' + substring(A1.FA_cf, 1, datalength(A1.FA_cf)) + space(16-datalength(A1.FA_cf))
			else''  end
		--+ FA 003: Casella documento riepilogativo
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null)  AND FA001004_num_op_attive_aggregate >0   
			then 'FA001004' 
				+ space(16-len(convert(varchar(16), FA001004_num_op_attive_aggregate)))+convert(varchar(16), FA001004_num_op_attive_aggregate)	
			else'' end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null)  AND FA001005_num_op_passive_aggregate >0  
			then 'FA001005' 
				+ space(16-len(convert(varchar(16), FA001005_num_op_passive_aggregate)))+convert(varchar(16), FA001005_num_op_passive_aggregate)	
			else''
			end 
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and isnull(FA001006_noleggioleasing,'N')in ('A','B','C','D','E')
			then 'FA001006' 
				+ FA001006_noleggioleasing +space(15)
			else''end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001007_op_imponibili_nonimponibili_esenti_ven>0
			then 'FA001007' 
				+  space(16-len(convert(varchar(16), FA001007_op_imponibili_nonimponibili_esenti_ven)))+convert(varchar(16), FA001007_op_imponibili_nonimponibili_esenti_ven)	 
			else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001008_imposta_ven>0
			then 'FA001008' 
				+ space(16-len(convert(varchar(16), FA001008_imposta_ven)))+convert(varchar(16), FA001008_imposta_ven)
			else '' end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001009_op_iva_nonesposta_ven>0
			then 'FA001009' 
				+ space(16-len(convert(varchar(16), FA001009_op_iva_nonesposta_ven)))+convert(varchar(16), FA001009_op_iva_nonesposta_ven)	 
			else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001010_var_debito_ven>0
			then 'FA001010' 
				+ space(16-len(convert(varchar(16), FA001010_var_debito_ven)))+convert(varchar(16), FA001010_var_debito_ven)	 
			else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001011_var_debito_imposta_ven>0
			then 'FA001011' 
				+  space(16-len(convert(varchar(16), FA001011_var_debito_imposta_ven)))+convert(varchar(16), FA001011_var_debito_imposta_ven)	 
			else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001012_op_imponibili_nonimponibili_esenti_acqu>0
			then 'FA001012' 
				+  space(16-len(convert(varchar(16), FA001012_op_imponibili_nonimponibili_esenti_acqu)))+convert(varchar(16), FA001012_op_imponibili_nonimponibili_esenti_acqu)	 
			else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001013_imposta_acqu>0
			then 'FA001013' 
				+  space(16-len(convert(varchar(16), FA001013_imposta_acqu)))+convert(varchar(16), FA001013_imposta_acqu)	 else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001014_op_iva_nonesposta_acqu>0
			then 'FA001014' 
				+  space(16-len(convert(varchar(16), FA001014_op_iva_nonesposta_acqu)))+convert(varchar(16), FA001014_op_iva_nonesposta_acqu)	 else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001015_var_credito_acqu>0
			then 'FA001015' 
				+  space(16-len(convert(varchar(16), FA001015_var_credito_acqu)))+convert(varchar(16), FA001015_var_credito_acqu)	 else''  end
		+ CASE when (isnull(A1.FA_piva,A1.FA_cf) is not null) and FA001016_var_credito_imposta_acqu>0
			then 'FA001016' 
				+  space(16-len(convert(varchar(16), FA001016_var_credito_imposta_acqu)))+convert(varchar(16), FA001016_var_credito_imposta_acqu)	 else''  end
-- FA 002
		+ case 
			when (A2.FA_piva is not null and  A2.FA_cf is not null )	then 'FA002001' + substring(A2.FA_piva, 1, datalength(A2.FA_piva)) + space(16-datalength(A2.FA_piva))
			when (A2.FA_piva is not null )								then 'FA002001' + substring(A2.FA_piva, 1, datalength(A2.FA_piva)) + space(16-datalength(A2.FA_piva))
			when (A2.FA_cf is not null)	and len(A2.FA_cf) = 16			then 'FA002002' + A2.FA_cf
			when (A2.FA_cf is not null)	and len(A2.FA_cf) < 16			then 'FA002002' + substring(A2.FA_cf, 1, datalength(A2.FA_cf)) + space(16-datalength(A2.FA_cf))
			else''  end
		--+ FA 003: Casella documento riepilogativo
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null)  AND FA002004_num_op_attive_aggregate >0   
			then 'FA002004' 
				+ space(16-len(convert(varchar(16), FA002004_num_op_attive_aggregate)))+convert(varchar(16), FA002004_num_op_attive_aggregate)	
			else'' end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null)  AND FA002005_num_op_passive_aggregate >0  
			then 'FA002005' 
				+ space(16-len(convert(varchar(16), FA002005_num_op_passive_aggregate)))+convert(varchar(16), FA002005_num_op_passive_aggregate)	
			else''
			end 
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and isnull(FA002006_noleggioleasing,'N')in ('A','B','C','D','E')
			then 'FA002006' 
				+ FA002006_noleggioleasing +space(15)
			else''end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002007_op_imponibili_nonimponibili_esenti_ven>0
			then 'FA002007' 
				+  space(16-len(convert(varchar(16), FA002007_op_imponibili_nonimponibili_esenti_ven)))+convert(varchar(16), FA002007_op_imponibili_nonimponibili_esenti_ven)	 
			else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002008_imposta_ven>0
			then 'FA002008' 
				+ space(16-len(convert(varchar(16), FA002008_imposta_ven)))+convert(varchar(16), FA002008_imposta_ven)
			else '' end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002009_op_iva_nonesposta_ven>0
			then 'FA002009' 
				+ space(16-len(convert(varchar(16), FA002009_op_iva_nonesposta_ven)))+convert(varchar(16), FA002009_op_iva_nonesposta_ven)	 
			else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002010_var_debito_ven>0
			then 'FA002010' 
				+ space(16-len(convert(varchar(16), FA002010_var_debito_ven)))+convert(varchar(16), FA002010_var_debito_ven)	 
			else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002011_var_debito_imposta_ven>0
			then 'FA002011' 
				+  space(16-len(convert(varchar(16), FA002011_var_debito_imposta_ven)))+convert(varchar(16), FA002011_var_debito_imposta_ven)	 
			else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002012_op_imponibili_nonimponibili_esenti_acqu>0
			then 'FA002012' 
				+  space(16-len(convert(varchar(16), FA002012_op_imponibili_nonimponibili_esenti_acqu)))+convert(varchar(16), FA002012_op_imponibili_nonimponibili_esenti_acqu)	 
			else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002013_imposta_acqu>0
			then 'FA002013' 
				+  space(16-len(convert(varchar(16), FA002013_imposta_acqu)))+convert(varchar(16), FA002013_imposta_acqu)	 else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002014_op_iva_nonesposta_acqu>0
			then 'FA002014' 
				+  space(16-len(convert(varchar(16), FA002014_op_iva_nonesposta_acqu)))+convert(varchar(16), FA002014_op_iva_nonesposta_acqu)	 else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002015_var_credito_acqu>0
			then 'FA002015' 
				+  space(16-len(convert(varchar(16), FA002015_var_credito_acqu)))+convert(varchar(16), FA002015_var_credito_acqu)	 else''  end
		+ CASE when (isnull(A2.FA_piva,A2.FA_cf) is not null) and FA002016_var_credito_imposta_acqu>0
			then 'FA002016' 
				+  space(16-len(convert(varchar(16), FA002016_var_credito_imposta_acqu)))+convert(varchar(16), FA002016_var_credito_imposta_acqu)	 else''  end
--- FA 0003
		+ case 
			when (A3.FA_piva is not null and  A3.FA_cf is not null )	then 'FA003001' + substring(A3.FA_piva, 1, datalength(A3.FA_piva)) + space(16-datalength(A3.FA_piva))
			when (A3.FA_piva is not null )								then 'FA003001' + substring(A3.FA_piva, 1, datalength(A3.FA_piva)) + space(16-datalength(A3.FA_piva))
			when (A3.FA_cf is not null)	and len(A3.FA_cf) = 16			then 'FA003002' + A3.FA_cf
			when (A3.FA_cf is not null)	and len(A3.FA_cf) < 16			then 'FA003002' + substring(A3.FA_cf, 1, datalength(A3.FA_cf)) + space(16-datalength(A3.FA_cf))

			else''  end
		--+ FA 003: Casella documento riepilogativo
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null)  AND FA003004_num_op_attive_aggregate >0   
			then 'FA003004' 
				+ space(16-len(convert(varchar(16), FA003004_num_op_attive_aggregate)))+convert(varchar(16), FA003004_num_op_attive_aggregate)	
			else'' end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null)  AND FA003005_num_op_passive_aggregate >0  
			then 'FA003005' 
				+ space(16-len(convert(varchar(16), FA003005_num_op_passive_aggregate)))+convert(varchar(16), FA003005_num_op_passive_aggregate)	
			else''
			end 
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and isnull(FA003006_noleggioleasing,'N')in ('A','B','C','D','E')
			then 'FA003006' 
				+ FA003006_noleggioleasing +space(15)
			else''end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003007_op_imponibili_nonimponibili_esenti_ven>0
			then 'FA003007' 
				+  space(16-len(convert(varchar(16), FA003007_op_imponibili_nonimponibili_esenti_ven)))+convert(varchar(16), FA003007_op_imponibili_nonimponibili_esenti_ven)	 
			else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003008_imposta_ven>0
			then 'FA003008' 
				+ space(16-len(convert(varchar(16), FA003008_imposta_ven)))+convert(varchar(16), FA003008_imposta_ven)
			else '' end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003009_op_iva_nonesposta_ven>0
			then 'FA003009' 
				+ space(16-len(convert(varchar(16), FA003009_op_iva_nonesposta_ven)))+convert(varchar(16), FA003009_op_iva_nonesposta_ven)	 
			else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003010_var_debito_ven>0
			then 'FA003010' 
				+ space(16-len(convert(varchar(16), FA003010_var_debito_ven)))+convert(varchar(16), FA003010_var_debito_ven)	 
			else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003011_var_debito_imposta_ven>0
			then 'FA003011' 
				+  space(16-len(convert(varchar(16), FA003011_var_debito_imposta_ven)))+convert(varchar(16), FA003011_var_debito_imposta_ven)	 
			else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003012_op_imponibili_nonimponibili_esenti_acqu>0
			then 'FA003012' 
				+  space(16-len(convert(varchar(16), FA003012_op_imponibili_nonimponibili_esenti_acqu)))+convert(varchar(16), FA003012_op_imponibili_nonimponibili_esenti_acqu)	 
			else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003013_imposta_acqu>0
			then 'FA003013' 
				+  space(16-len(convert(varchar(16), FA003013_imposta_acqu)))+convert(varchar(16), FA003013_imposta_acqu)	 else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003014_op_iva_nonesposta_acqu>0
			then 'FA003014' 
				+  space(16-len(convert(varchar(16), FA003014_op_iva_nonesposta_acqu)))+convert(varchar(16), FA003014_op_iva_nonesposta_acqu)	 else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003015_var_credito_acqu>0
			then 'FA003015' 
				+  space(16-len(convert(varchar(16), FA003015_var_credito_acqu)))+convert(varchar(16), FA003015_var_credito_acqu)	 else''  end
		+ CASE when (isnull(A3.FA_piva,A3.FA_cf) is not null) and FA003016_var_credito_imposta_acqu>0
			then 'FA003016' 
				+  space(16-len(convert(varchar(16), FA003016_var_credito_imposta_acqu)))+convert(varchar(16), FA003016_var_credito_imposta_acqu)	 else''  end
		-->	+ 'A' LO AGGIUNGIAMO ALLA FINE
		FROM #RECORD_C_UNIFIED_FA C
		JOIN #ANAGRAFICHE A1
			ON C.FA001_idreg = A1.idreg
		left outer JOIN #ANAGRAFICHE A2
			ON C.FA002_idreg = A2.idreg
		left outer	JOIN #ANAGRAFICHE A3
			ON C.FA003_idreg = A3.idreg
END


IF(@kind='B')
BEGIN
		INSERT INTO #traceByRecord (recordkind, out_str)
		-- RECORD "C"
		SELECT
		'C',
		'C'
		+ @codfiscEnte
		+ SUBSTRING(REPLICATE('0',8),1,8-len(substring(convert(char(8), C.Progressivo),1,8))) + convert(varchar(4), C.Progressivo)
		+ space(3) -- Spazio a disposizione dell'utente
		+ space(25) -- Filler
		+ space(20) -- Spazio utente
		+ @CFsoftwarehouse -- Identificativo produttore SW
		-- Fine campi posizionali

		+ CASE when (A.BL001001_cognome is not null) then 'BL001001' + BL001001_cognome else''  end
		+ CASE when (A.BL001001_cognome is not null) then 'BL001002' + BL001002_nome else''  end
		+ CASE when (A.BL001001_cognome is not null) then 'BL001003' + convert(varchar(8),BL001003_datanascita) else''  end
		+ CASE when (A.BL001001_cognome is not null) then 'BL001004' + BL001004_comune else''  end
		+ CASE when (A.BL001001_cognome is not null) then 'BL001005' + BL001005_provincia else''  end
		+ CASE when (A.BL001001_cognome is not null) then 'BL001006' + convert(varchar(4),BL001006_codicestatoestero) else''  end
		+ case when (A.BL001007_denominazione is not null) then 'BL001007' + BL001007_denominazione else''  end
		+ case when (A.BL001007_denominazione is not null) then 'BL001008' + BL001008_cittàestera else''  end
		+ case when (A.BL001007_denominazione is not null) then 'BL001009' + convert(varchar(4),BL001009_codicestatoestero) else''  end
		+ case when (A.BL001007_denominazione is not null) then 'BL001010' + BL001010_indirizzoestero else''  end
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002001_CodIVA is not null then 'BL002001' + BL002001_CodIVA else''  end
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002002_Blacklist=1 then 'BL002002' + space(15)+'1' else''  end
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002003_NonResident=1 then 'BL002003' + space(15)+'1' else''  end
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL002004_Acqu_NonResidenti=1 then 'BL002004' + space(15)+'1' else''  end
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL003001_importocomplessivo is not null 
			then 'BL003001' + space(16-len(convert(varchar(16), BL003001_importocomplessivo)))+convert(varchar(16), BL003001_importocomplessivo)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL003002_imposta is not null 
			then 'BL003002' + space(16-len(convert(varchar(16), BL003002_imposta)))+convert(varchar(16), BL003002_imposta)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL004001_cessionebeni is not null 
			then 'BL004001' +  space(16-len(convert(varchar(16), BL004001_cessionebeni)))+convert(varchar(16), BL004001_cessionebeni)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL004002_servizi is not null 
			then 'BL004002' +  space(16-len(convert(varchar(16), BL004002_servizi)))+convert(varchar(16), BL004002_servizi)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL005001_importocomplessivo is not null 
			then 'BL005001' +  space(16-len(convert(varchar(16), BL005001_importocomplessivo)))+convert(varchar(16), BL005001_importocomplessivo)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL005002_imposta is not null 
			then 'BL005002' +  space(16-len(convert(varchar(16), BL005002_imposta)))+convert(varchar(16), BL005002_imposta)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL006001_importocomplessivo is not null 
			then 'BL006001' +  space(16-len(convert(varchar(16), BL006001_importocomplessivo)))+convert(varchar(16), BL006001_importocomplessivo)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL006002_imposta is not null 
			then 'BL006002' +  space(16-len(convert(varchar(16), BL006002_imposta)))+convert(varchar(16), BL006002_imposta)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL007001_importocomplessivo is not null 
			then 'BL007001' +  space(16-len(convert(varchar(16), BL007001_importocomplessivo)))+convert(varchar(16), BL007001_importocomplessivo)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL008001_importocomplessivo is not null 
			then 'BL008001' +  space(16-len(convert(varchar(16), BL008001_importocomplessivo)))+convert(varchar(16), BL008001_importocomplessivo)	 else''  end	
		+ case when isnull(A.BL001001_cognome,A.BL001007_denominazione) is not null and BL008002_imposta is not null 
			then 'BL008002' +  space(16-len(convert(varchar(16), BL008002_imposta)))+convert(varchar(16), BL008002_imposta)	 else''  end	
		-->	+ 'A' LO AGGIUNGIAMO ALLA FINE
		FROM #RECORD_C_UNIFIED C
		JOIN #ANAGRAFICHE A
			ON C.idreg = A.idreg
END

-- Contiamo i Record C inseriti in #RECORD_C_UNIFIED, dove abbiamo un idreg per riga_recC
declare @CountFA int
select @CountFA = max(Progressivo) from #RECORD_C_UNIFIED

-- Poi andremo ad inserire 3 rige di RECORD_C_UNIFIED in 1 riga_recC di #RECORD_C_UNIFIED_FA come FA001, FA002, FA003
-- Quindi il numero di righe di #RECORD_C_UNIFIED_FA, è il numero di Record C del file finale.
declare @CountC int
select @CountC = max(riga_recC) from #RECORD_C_UNIFIED_FA


declare @TA003001 int
SET @TA003001 = isnull((select count(BL002001_CodIVA) 
FROM #RECORD_C_UNIFIED C
JOIN #ANAGRAFICHE A
	ON C.idreg = A.idreg
WHERE isnull(C.BL002002_Blacklist,0) =1),0)

declare @TA003002 int
SET @TA003002 = isnull((select count(BL002001_CodIVA) 
FROM #RECORD_C_UNIFIED C
JOIN #ANAGRAFICHE A
	ON C.idreg = A.idreg
WHERE isnull(C.BL002003_NonResident,0) =1 ),0)

declare @TA003003 int
SET @TA003003 = isnull((select count(BL002001_CodIVA) 
FROM #RECORD_C_UNIFIED C
JOIN #ANAGRAFICHE A
	ON C.idreg = A.idreg
WHERE isnull(C.BL002004_Acqu_NonResidenti,0) =1),0)

INSERT INTO #traceByRecord (recordkind, out_str)
-- RECORD "E"
SELECT
'E',
'E'
+ @codfiscEnte
+ '00000001' -- Numero record di tipo E
+ space(3) -- Spazio a disposizione dell'utente
+ space(25) -- Filler
+ space(20) -- Spazio utente
+ @CFsoftwarehouse -- Identificativo produttore SW
-- Fine campi posizionali

-- Numero complessivo dei righi compilati presenti nel quadro FA di tutti i  moduli compilati
+ 'TA001001'+ SUBSTRING(REPLICATE(' ',16),1,16-len(substring(convert(char(16), @CountFA),1,16))) + convert(varchar(16), @CountFA)

--- Numero complessivo delle controparti presenti nel quadro BL di tutti i moduli compilati, se barrata la casella BL002002
+ case when (@TA003001 > 0 )
	then 'TA003001' + SUBSTRING(REPLICATE(' ',16),1,16-len(substring(convert(char(16), @TA003001),1,16))) + convert(varchar(16), @TA003001)
	else ''
	end
--- Numero complessivo delle controparti presenti nel quadro BL di tutti i moduli compilati, se barrata la casella BL002003
+ case when (@TA003002>0)
	then 'TA003002' + SUBSTRING(REPLICATE(' ',16),1,16-len(substring(convert(char(16), @TA003002),1,16))) + convert(varchar(16), @TA003002)
	else ''
	end
--- Numero complessivo delle controparti presenti nel quadro BL di tutti i moduli compilati, se barrata la casella BL002004
+ case when (@TA003002 >0)
	then 'TA003003' + SUBSTRING(REPLICATE(' ',16),1,16-len(substring(convert(char(16), @TA003003),1,16))) + convert(varchar(16), @TA003003)
	else ''
	end


INSERT INTO #traceByRecord(recordkind, out_str)
-- RECORD "Z"
SELECT 
'Z',
'Z'
+ space(14) -- Filler
+ '000000001' -- Numero record di tipo B
+ SUBSTRING(REPLICATE('0',9),1,9-len(substring(convert(char(9), @CountC),1,9))) + convert(varchar(4), @CountC) -- Numero record di tipo C
+ '000000000' -- Numero record di tipo D
+ '000000001' -- Numero record di tipo E
+ space(1846) --Filler
+ 'A'

INSERT INTO #trace (out_str, orderrow) SELECT out_str,1 FROM #traceByRecord where recordkind='A'
INSERT INTO #trace (out_str, orderrow) SELECT out_str, 2 FROM #traceByRecord where recordkind='B'

INSERT INTO #trace (out_str, orderrow) 
SELECT out_str + space(1897-len(out_str)) + 'A', 3
FROM #traceByRecord where recordkind='C'

INSERT INTO #trace (out_str, orderrow) 
SELECT out_str + space(1897-len(out_str)) + 'A',4
FROM #traceByRecord where recordkind='E'

INSERT INTO #trace (out_str, orderrow) SELECT out_str,5 FROM #traceByRecord where recordkind='Z'

-- Il file viene creato SOLO se è stato compilato il Record C, contente gli importi.
if ( select count(*) from #traceByRecord where recordkind='C')>0
Begin
	SELECT out_str FROM #trace order by orderrow
End




END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



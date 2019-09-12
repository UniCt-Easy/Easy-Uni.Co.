if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intra12_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intra12_unified]
GO
 
/*

EXEC exp_mod_intra12_unified 2016, 1, {d '2016-03-03'},'S'
 
*/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_intra12_unified] (
	@ayear smallint,
	@mese smallint, -- Mese della dichiarazione
	@dataversamento datetime, -- Data versamento @TR012014
	@unified char(1)
)
AS
BEGIN

DECLARE @idtrasmissiondocument varchar(10)
SET @idtrasmissiondocument = 'INTRA12'

CREATE TABLE #error (message varchar(400))


IF(
(SELECT COUNT(*) FROM trasmissionmanager
WHERE idtrasmissiondocument = @idtrasmissiondocument and ayear = @ayear ) = 0)
BEGIN
	INSERT INTO #error
	VALUES('Inserire il Responsabile della trasmissione del modello INTRA12. Andare in Configurazione\Configurazione\Responsabile della trasmissione...')
END 

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

	DECLARE @5a_2b_31b_2c_CF_universita varchar(11)	-- 16 CF. e' Sai il @5 del Record A che il @2 del record B
	
	DECLARE @lenCF16 int
	SET @lenCF16 = 16

	DECLARE @lenCF11 int
	SET @lenCF11 = 11

	DECLARE @lenPiva int
	SET @lenPiva = 11

	DECLARE @lenanno INT
	SET @lenanno = 4
	DECLARE @lenmese INT
	SET @lenmese = 2
	DECLARE @lenday INT
	SET @lenday = 2

	DECLARE @lenDenominazione int
	SET @lenDenominazione  = 60

	DECLARE @13PartitaIVA varchar(11)
	DECLARE @22Denominazione varchar(150)
	DECLARE @23NaturaGiuridica varchar(2) --> la impostiamo a 15 = 'Enti pubblici non economici.'

	SELECT	@5a_2b_31b_2c_CF_universita = cf,
			@13PartitaIVA = p_iva, 
			@22Denominazione = agencyname,
			@23NaturaGiuridica = '15'  
	FROM license
 
	DECLARE @7Codicefiscalesocietadichiarante varchar(11)	-- 11 CF
	SET @7Codicefiscalesocietadichiarante = '02890460781'  -- §Tempo

	DECLARE @14CodiceAttivita varchar(6)	  -- va riportato senza il punto, perchè il campo ha lunghezza 6
	SELECT @14CodiceAttivita = REPLACE(cudactivitycode,'.','') FROM config WHERE ayear = @ayear

 	
 
-- PRENDERE I DATI DAL RESPONSABILE DELLA TRASMISSIONE 
	DECLARE @29CFdelrappresentante varchar(16)		-- 16 CF : Codice fiscale del rappresentante 
	DECLARE @30codiceCaricaRappresentante varchar(2)	-- 2 Codice carica del rappresentante
	DECLARE @idregRappresentante int			
	DECLARE @32CognomeRappresentante varchar(50)	-- 24 AN

	DECLARE @lenCognome int
	SET @lenCognome = 24

	DECLARE @33NomeRappresentante varchar(50)		-- 20 AN

	DECLARE @lenNome int
	SET @lenNome = 20

	DECLARE @34SessoRappresentante char(1)		--  1 AN
	DECLARE @35DataNascitaRappresentante datetime	-- 8 DT
	DECLARE @36Comune_oStatoEstero_NascitaRappresentante varchar(65)	-- 40 AN : Comune o stato estero di nascita del rappresentante
	DECLARE @lenComune int
	SET @lenComune = 40
	DECLARE @37ProvinciaNascitaRappresentante varchar(2)	-- 2 PN

-- Se è presente almeno uno dei campi 38, 39, 40, 41, i campi 38 e 41 sono obbligatori.
	DECLARE @38CodiceStatoesteroRappresentante varchar(3)	-- 3 NU
	DECLARE @39Statofederatoprovinciacontea varchar(65)		-- 24 AN

	DECLARE @lenStatofederatoprovinciacontea int
	SET @lenStatofederatoprovinciacontea = 24

	DECLARE @40LocalitaResidenza varchar(50)				-- 24 AN
	DECLARE @lenLocalitaResidenza int
	SET @lenLocalitaResidenza = 24

	DECLARE @41IndirizzoEstero varchar(100)					-- 35 AN
	DECLARE @lenIndirizzoEstero int
	SET @lenIndirizzoEstero = 35

-- 	DECLARE @42telefono varchar(12)							-- 12 AN, il dato deve essere numerico.NON credo sia obbligatorio
	DECLARE @43Firmadellacomunicazione varchar(1)			-- 1 CB

	SELECT
		@29CFdelrappresentante = R.cf,
		@idregRappresentante = R.idreg,
		@32CognomeRappresentante = R.surname, 
		@33NomeRappresentante = R.forename, 
		@34SessoRappresentante = R.gender, 
		@35DataNascitaRappresentante = R.birthdate,
		@36Comune_oStatoEstero_NascitaRappresentante = C.title ,
		@37ProvinciaNascitaRappresentante = P.provincecode 
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

	CREATE TABLE #address(
		idaddresskind int,
		address varchar(100),
		location varchar(50),
		nation varchar(65)
	)

	DECLARE @dateaddress datetime
	SELECT @dateaddress = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

	DECLARE @codenostand varchar(20)
	SET @codenostand = '07_SW_DOM'

	DECLARE @codestand varchar(20)
	SET @codestand = '07_SW_DEF'

	DECLARE @STAND int
	SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

	DECLARE @NOSTAND int
	SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @natoallestero char(1)

IF(@36Comune_oStatoEstero_NascitaRappresentante IS NULL)
begin
	SET @natoallestero = 'N'
end
else
begin
	SET @natoallestero = 'S'
end

IF (@natoallestero = 'N')
-- Vuol dire che è nato all'estero
Begin
-- Leggiamo i dati della Nascita : stato estero di nascita 
	SELECT @36Comune_oStatoEstero_NascitaRappresentante = N.title 
	FROM registry R
	JOIN geo_nation N 
		ON N.idnation = R.idnation
	WHERE R.idreg = @idregRappresentante
End


DECLARE @message varchar(400)
IF (@29CFdelrappresentante IS NULL OR @29CFdelrappresentante = '')
BEGIN
	SET @message = 'Manca il Codice Fiscale del Responsabile della Trasmissione per il Modello INTRA 12. Andare nella scheda Anagrafica e inserire il CF.'
	INSERT INTO #error VALUES(@message)
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

SET @30codiceCaricaRappresentante = '01' -- lo impostiamo a 01 

------------------------------------------------------------------------------------------------
---------------------------- ESTRAZIONE DATI DELLE FATTURE -------------------------------------
------------------------------------------------------------------------------------------------

CREATE TABLE #RecordIntra12
(	
	iddbdepartment						varchar(50),   -- Nome del dipartimento
	TR012001							decimal(19,5), -- Acquisti Intra - Imponibile
	TR012002							decimal(19,5), -- Acquisti Intra - Imposta
	TR012003							decimal(19,5), -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Beni
	TR012004							decimal(19,5), -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Beni
	TR012005							decimal(19,5), -- Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Servizi
	TR012006							decimal(19,5), -- Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Servizi art.7
	TR012007							decimal(19,5), -- Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Servizi
	TR012008							decimal(19,5), -- Acquisti Entra-UE - Imponibile Beni
	TR012009							decimal(19,5), -- Acquisti Entra-UE - Imposta Beni
	TR012010							decimal(19,5), -- Acquisti Entra-UE - Imponibile Servizi
	TR012011							decimal(19,5), -- Acquisti Entra-UE - Imponibile Servizi art.7
	TR012012							decimal(19,5), -- Acquisti Entra-UE - Imposta Servizi
	TR012013							decimal(19,5), -- Totale Imposta  
	TR012014							datetime, -- Data Versamento
)

DECLARE @s varchar(300)

IF(@unified<>'S')
Begin
	set @s = 'exp_mod_intra12'
		INSERT INTO #RecordIntra12(
			TR012001		, -- Acquisti Intra - Imponibile
			TR012002		, -- Acquisti Intra - Imposta
			TR012003		, -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Beni
			TR012004		, -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Beni
			TR012005		, -- Acquisti - Imponibile Servizi
			TR012006		, -- Acquisti - Imponibile Servizi art.7
			TR012007		, -- Acquisti - Imposta Servizi
			TR012008		, -- Acquisti Entra-UE - Imponibile Beni
			TR012009		, -- Acquisti Entra-UE - Imposta Beni
			TR012010		, -- Acquisti Entra-UE - Imponibile Servizi
			TR012011		, -- Acquisti Entra-UE - Imponibile Servizi art.7
			TR012012		, -- Acquisti Entra-UE - Imposta Servizi
			TR012013		, -- Totale Imposta  
			TR012014		 -- Data Versamento
		)
	exec @s @ayear,@mese,@dataversamento

	print @s
	--select * from #RecordIntra12
End

Else
Begin
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET 	@crsdepartment = cursor for 
						 select iddbdepartment from dbdepartment
						 where  (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @s = @iddbdepartment + '.exp_mod_intra12'

		INSERT INTO #RecordIntra12(
			TR012001		, -- Acquisti Intra - Imponibile
			TR012002		, -- Acquisti Intra - Imposta
			TR012003		, -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Beni
			TR012004		, -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Beni
			TR012005		, -- Acquisti - Imponibile Servizi
			TR012006		, -- Acquisti - Imponibile Servizi art.7
			TR012007		, -- Acquisti - Imposta Servizi
			TR012008		, -- Acquisti Entra-UE - Imponibile Beni
			TR012009		, -- Acquisti Entra-UE - Imposta Beni
			TR012010		, -- Acquisti Entra-UE - Imponibile Servizi
			TR012011		, -- Acquisti Entra-UE - Imponibile Servizi art.7
			TR012012		, -- Acquisti Entra-UE - Imposta Servizi
			TR012013		, -- Totale Imposta  
			TR012014		 -- Data Versamento
		)

		exec @s @ayear,@mese,@dataversamento
		print @iddbdepartment
		
		UPDATE #RecordIntra12 set iddbdepartment = @iddbdepartment
		WHERE  #RecordIntra12.iddbdepartment is null

		fetch next from @crsdepartment into @iddbdepartment
end
End



DECLARE @TR012001 decimal(19,5) -- Acquisti Intra - Imponibile
SET @TR012001 = isnull(( SELECT SUM(TR012001) FROM #RecordIntra12),0)
			
DECLARE @TR012002 decimal(19,2) -- Acquisti Intra - Imposta
SET @TR012002 =  isnull(( SELECT SUM(TR012002) FROM #RecordIntra12),0)

DECLARE @TR012003 decimal(19,5) -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Beni
SET @TR012003 =  isnull(( SELECT SUM(TR012003) FROM #RecordIntra12),0)

DECLARE @TR012004 decimal(19,2) -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Beni
SET @TR012004 =  isnull(( SELECT SUM(TR012004) FROM #RecordIntra12),0)

DECLARE @TR012005 decimal(19,5) -- Acquisti - Imponibile Servizi
SET @TR012005 = isnull(( SELECT SUM(TR012005) FROM #RecordIntra12),0)

DECLARE @TR012006 decimal(19,5) -- Acquisti - Imponibile Servizi art.7
SET @TR012006 =  isnull(( SELECT SUM(TR012006) FROM #RecordIntra12),0)

DECLARE @TR012007 decimal(19,2) -- Acquisti - Imposta Servizi
SET @TR012007 = isnull(( SELECT SUM(TR012007) FROM #RecordIntra12),0)


DECLARE @TR012008 decimal(19,5) -- Acquisti Entra-UE - Imponibile Beni
SET @TR012008 =  isnull(( SELECT SUM(TR012008) FROM #RecordIntra12),0)

DECLARE @TR012009 decimal(19,2) -- Acquisti Entra-UE - Imposta Beni
SET @TR012009 =   isnull(( SELECT SUM(TR012009) FROM #RecordIntra12),0) -- prende le fattura associate a registri Istituzionali
			

DECLARE @TR012010 decimal(19,5) -- Acquisti Entra-UE - Imponibile Servizi
SET @TR012010 =  isnull(( SELECT SUM(TR012010) FROM #RecordIntra12),0)

DECLARE @TR012011 decimal(19,5) -- Acquisti Entra-UE - Imponibile Servizi art.7
SET @TR012011 =  isnull(( SELECT SUM(TR012011) FROM #RecordIntra12),0)

DECLARE @TR012012 decimal(19,2) -- Acquisti Entra-UE - Imposta Servizi
SET @TR012012 =  isnull(( SELECT SUM(TR012012) FROM #RecordIntra12),0)

DECLARE @TR012013 decimal(19,2) -- Totale Imposta  
SET @TR012013 =  isnull(@TR012002,0) + isnull(@TR012004,0) +  isnull(@TR012007,0)+ isnull(@TR012009,0) + isnull(@TR012012,0)

DECLARE @TR012014 datetime
SET @TR012014 = @dataversamento

------------------------------------------------------------------------------------------------
----------------------- FORMATTAZIONE FILE DI TRASMISSIONE -------------------------------------
------------------------------------------------------------------------------------------------


-- Formattazione file di trasmissione
-- Tabella di output
CREATE TABLE #trace(
	out_str varchar(2200) COLLATE SQL_Latin1_General_CP1_CI_AS
)

CREATE TABLE #RECORD_C(
	out_str varchar(2200) COLLATE SQL_Latin1_General_CP1_CI_AS
)


-- RECORD A
INSERT INTO #trace (out_str)
SELECT
	'A' +				-- Tipo Record
	SPACE(14) +			-- Filler	
	'T1210' +			-- Codice Fornitura, va impostato a "T1210"
	'01' +				-- tipo fornitore
						 -- Codice fiscale del fornitore
	CASE
		WHEN DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')) <= @lenCF16
		THEN ISNULL(@5a_2b_31b_2c_CF_universita,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')))
		ELSE SUBSTRING(@5a_2b_31b_2c_CF_universita,1,@lenCF16)
	END + 
	SPACE(483) +			-- Filler	
	REPLICATE('0',8) +		-- Filler
	SPACE(100) +			-- Filler	
	SPACE(1068) +			-- Filler	
	SPACE(200) +			-- Filler	
	'A'					-- Carattere di controllo. Va impostato al valore A
 
 --select 'mese',@mese, CASE
	--	WHEN DATALENGTH(CONVERT(varchar(2),@mese)) <= 2
	--	THEN SUBSTRING(SPACE(2),1,2 - DATALENGTH(CONVERT(varchar(2),@mese))) + CONVERT(varchar(2),@mese) 
	--	ELSE CONVERT(varchar(2),@mese)
	--END 

-- RECORD B
INSERT INTO #trace (out_str)
SELECT
	'B' +				-- Tipo Record
	--Codice fiscale del soggetto dichiarante
	CASE
		WHEN DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')) <= @lenCF16
		THEN ISNULL(@5a_2b_31b_2c_CF_universita,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')))
		ELSE SUBSTRING(@5a_2b_31b_2c_CF_universita,1,@lenCF16)
	END + 
	'00000001'+ -- Progressivo modulo
	SPACE(3) + 
	SPACE(25) +  --Filler
	SPACE(20) + 
	-- Identificativo del produttore del SW (codice fiscale)
	CASE
		WHEN DATALENGTH(ISNULL(@7Codicefiscalesocietadichiarante,'')) <= @lenCF16
		THEN ISNULL(@7Codicefiscalesocietadichiarante,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@7Codicefiscalesocietadichiarante,'')))
		ELSE SUBSTRING(@7Codicefiscalesocietadichiarante,1,@lenCF16)
	END + 
	'1'+ -- Flag conferma -- Il formato CB è composto da 15 spazi e un numero '1'.
	  -- Ufficio Competente	ora c'è un Filler in base alle specifiche aggiornate 
	SPACE(3) + 
	convert(varchar(4),@ayear) + -- Anno di riferimento
	-- Mese di riferimento
	CASE
		WHEN DATALENGTH(CONVERT(varchar(2),@mese)) <= 2
		THEN SUBSTRING(REPLICATE('0',2),1,2 - DATALENGTH(CONVERT(varchar(2),@mese))) + CONVERT(varchar(2),@mese)  
		ELSE CONVERT(varchar(2),@mese)
	END + 
	'0' + 	-- Correttiva nei termini CB
	-- Partita IVA
	CASE
		WHEN DATALENGTH(ISNULL(@13PartitaIVA,'')) <= @lenPiva
		THEN ISNULL(@13PartitaIVA,'') + SUBSTRING(SPACE(@lenPiva),1,@lenPiva - DATALENGTH(ISNULL(@13PartitaIVA,'')))
		ELSE SUBSTRING(@13PartitaIVA,1,@lenPiva)
	END + 
	@14CodiceAttivita + -- Codice Attività
	'0' + -- Eventi eccezionali CB
	SPACE(24) + -- Cognome
	SPACE(20) + -- Nome
	SPACE(40) + -- Comune di Nascita
	SPACE(2)  + -- Provincia di nascita
	REPLICATE('0',8)  + -- Data di nascita
	SPACE(1)  + -- Sesso
	-- Denominazione
	CASE
		WHEN DATALENGTH(ISNULL(@22Denominazione,'')) <= @lenDenominazione
		THEN ISNULL(@22Denominazione,'') + SUBSTRING(SPACE(@lenDenominazione),1,@lenDenominazione - DATALENGTH(ISNULL(@22Denominazione,'')))
		ELSE SUBSTRING(@22Denominazione,1,@lenDenominazione)
	END + 
	@23NaturaGiuridica + -- Natura giuridica
	SPACE(40) +			-- Filler
	SPACE(2) +			-- Filler
	SPACE(35) +			-- Filler
	REPLICATE('0',5) +  -- Filler
	SPACE(4) +  -- Filler
	-- CF del rappresentante	
	CASE
		WHEN DATALENGTH(ISNULL(@29CFdelrappresentante,'')) <= @lenCF16
		THEN ISNULL(@29CFdelrappresentante,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@29CFdelrappresentante,'')))
		ELSE SUBSTRING(@29CFdelrappresentante,1,@lenCF16)
	END + 
	@30codiceCaricaRappresentante +	-- Codice carica del rappresentante
	-- Codice fiscale società dichiarante
	CASE
		WHEN DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')) <= @lenCF11
		THEN ISNULL(@5a_2b_31b_2c_CF_universita,'') + SUBSTRING(SPACE(@lenCF11),1,@lenCF11 - DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')))
		ELSE SUBSTRING(@5a_2b_31b_2c_CF_universita,1,@lenCF11)
	END + 
	-- Cognome del Rappresentante
	CASE
		WHEN DATALENGTH(ISNULL(@32CognomeRappresentante,'')) <= @lenCognome
		THEN ISNULL(@32CognomeRappresentante,'') + SUBSTRING(SPACE(@lenCognome),1,@lenCognome - DATALENGTH(ISNULL(@32CognomeRappresentante,'')))
		ELSE SUBSTRING(@32CognomeRappresentante,1,@lenCognome)
	END + 
	-- Nome del Rappresentante
	CASE
		WHEN DATALENGTH(ISNULL(@33NomeRappresentante,'')) <= @lenNome
		THEN ISNULL(@33NomeRappresentante,'') + SUBSTRING(SPACE(@lenNome),1,@lenNome - DATALENGTH(ISNULL(@33NomeRappresentante,'')))
		ELSE SUBSTRING(@33NomeRappresentante,1,@lenNome)
	END + 
	@34SessoRappresentante + -- Sesso del rappresentante 
	-- Data Nascita Rappresentante 
	 SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(@35DataNascitaRappresentante)))) + CONVERT(varchar(2),DAY(@35DataNascitaRappresentante))
	+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(@35DataNascitaRappresentante)))) + CONVERT(varchar(2),MONTH(@35DataNascitaRappresentante))
	+ CONVERT(varchar(4),YEAR(@35DataNascitaRappresentante))
	
	-- ComuneNascitaRappresentante
	+ CASE
		WHEN DATALENGTH(ISNULL(@36Comune_oStatoEstero_NascitaRappresentante,'')) <= @lenComune
		THEN ISNULL(@36Comune_oStatoEstero_NascitaRappresentante,'') + SUBSTRING(SPACE(@lenComune),1,@lenComune - DATALENGTH(ISNULL(@36Comune_oStatoEstero_NascitaRappresentante,'')))
		ELSE SUBSTRING(@36Comune_oStatoEstero_NascitaRappresentante,1,@lenComune)
	END + 
	@37ProvinciaNascitaRappresentante +		-- Provincia Nascita Rappresentante
	-- Ex Codice Stato estero ora c'è un Filler in base alle specifiche aggiornate 
	SPACE (3) + 
	-- Ex Stato federato provincia contea ora c'è un Filler in base alle specifiche aggiornate 
	SPACE(24) + 
	-- Ex Località di residenza ora c'è un Filler in base alle specifiche aggiornate  
	SPACE(24) + 
	-- Ex IndirizzoEstero ora c'è un Filler in base alle specifiche aggiornate  
	SPACE(35) + 
	SPACE(12) + -- Telefono - cellulare del rappresentante
	'1'+ -- Firma della Comunicazione CB
	SPACE(16) +  -- Codice fiscale dell'intermediario
	SPACE(5) + -- eX  Numero di iscrizione all'albo del C.A.F.	 ora Filler
	REPLICATE('0',1) + --  Soggetto che ha predisposto la dichiarazione 606 1 NU  Vale 1 o 2, obbligatorio se presente campo 44
	SPACE(1) + -- Filler 
	REPLICATE('0',8) + -- Data dell'impegno
	'0'+ --  Firma dell'intermediario CB
	SPACE(1227) +  -- Filler
	SPACE(20) +   --Spazio riservato al Servizio Telematico
	SPACE(34) +  -- Filler
	'A'  


DECLARE @len_amount int
SET @len_amount = 15 -- con la virgola fa 16

-- RECORD C
INSERT INTO #RECORD_C ( out_str)
SELECT
	CASE 
		WHEN ( @TR012001 > 0 )
		THEN 	'TR012001'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012001))) +
			SUBSTRING(CONVERT(varchar(16),@TR012001),1,	DATALENGTH(CONVERT(varchar(16),@TR012001)))
		ELSE ''--SPACE(16)
	END	+
	CASE 
		WHEN ( @TR012002 > 0 )
		THEN	'TR012002'+
		SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012002))) +
		SUBSTRING(CONVERT(varchar(16),@TR012002),1,	DATALENGTH(CONVERT(varchar(16),@TR012002)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END +
	CASE 
		WHEN ( @TR012003 > 0 )
		THEN	'TR012003'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012003))) +
			SUBSTRING(CONVERT(varchar(16),@TR012003),1,	DATALENGTH(CONVERT(varchar(16),@TR012003)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END + 
	CASE 
		WHEN ( @TR012004 > 0 )
		THEN	'TR012004'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012004))) +
			SUBSTRING(CONVERT(varchar(16),@TR012004),1,	DATALENGTH(CONVERT(varchar(16),@TR012004)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END +
	CASE 
		WHEN ( @TR012005 > 0 )
		THEN	'TR012005'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012005))) +
			SUBSTRING(CONVERT(varchar(16),@TR012005),1,	DATALENGTH(CONVERT(varchar(16),@TR012005)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END +
	CASE 
		WHEN ( @TR012006 > 0 )
		THEN	'TR012006'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012006))) +
			SUBSTRING(CONVERT(varchar(16),@TR012006),1,	DATALENGTH(CONVERT(varchar(16),@TR012006)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END +
	CASE 
		WHEN ( @TR012007 > 0 )
		THEN 'TR012007'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012007))) +
			SUBSTRING(CONVERT(varchar(16),@TR012007),1,	DATALENGTH(CONVERT(varchar(16),@TR012007)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END +
	CASE 
		WHEN ( @TR012008 > 0 )
		THEN 'TR012008'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012008))) +
			SUBSTRING(CONVERT(varchar(16),@TR012008),1,	DATALENGTH(CONVERT(varchar(16),@TR012008)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END + 
	CASE 
		WHEN ( @TR012009 > 0 )
		THEN	'TR012009'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012009))) +
			SUBSTRING(CONVERT(varchar(16),@TR012009),1,	DATALENGTH(CONVERT(varchar(16),@TR012009)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END + 
	CASE 
		WHEN ( @TR012010 > 0 )
		THEN 'TR012010'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012010))) +
			SUBSTRING(CONVERT(varchar(16),@TR012010),1,	DATALENGTH(CONVERT(varchar(16),@TR012010)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END + 
	CASE 
		WHEN ( @TR012011 > 0 )
		THEN	'TR012011'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012011))) +
			SUBSTRING(CONVERT(varchar(16),@TR012011),1,	DATALENGTH(CONVERT(varchar(16),@TR012011)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore	
	END + 
	CASE 
		WHEN ( @TR012012 > 0 )
		THEN 'TR012012'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012012))) +
			SUBSTRING(CONVERT(varchar(16),@TR012012),1,	DATALENGTH(CONVERT(varchar(16),@TR012012)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END +
	CASE 
		WHEN ( @TR012013 > 0 )
		THEN	'TR012013'+
			SUBSTRING(REPLICATE(' ',@len_amount),1,1 + @len_amount - 	DATALENGTH(CONVERT(varchar(16),@TR012013))) +
			SUBSTRING(CONVERT(varchar(16),@TR012013),1,	DATALENGTH(CONVERT(varchar(16),@TR012013)))
		ELSE ''--SPACE(24)-- 8 Campi carattere + 16 campi valore
	END 

-- Sostituisce il punto con la virgola
UPDATE #RECORD_C SET  out_str = REPLACE(out_str,'.',',')
-- Il Record C ha la prima parte posizionale fino alla posizione 90, poi ci sono i campi NON posizionali fino alla posizione 1898, ossia i dati che si riferiscono agli
-- importi TR012001,002,003....questi campi vanno comunicati SOLO se valorizzati. 
-- Quindi nel file dobbiamo valorizzare le prime 90 posizioni con i campi indicati dal tracciato, poi vanno inseriti questi importi, quindi vanno messi tanti
-- filler fino alla posizione 1898. Per calcola quanti filler servono facciamo:
-- 1898 - 90 -(select datalength(out_str) FROM #RECORD_C)- 24, ove 24 è la lunghezza dell'ultimo campo non posizionale TR012014 in cui alorizzaremo la data del versamento

DECLARE @1898Filler int
SET @1898Filler =  1898 - 90 - (select datalength(out_str) FROM #RECORD_C)- 24

INSERT INTO #trace (out_str)
SELECT
	'C' +				-- Tipo Record
	--Codice fiscale del soggetto dichiarante
	CASE
		WHEN DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')) <= @lenCF16
		THEN ISNULL(@5a_2b_31b_2c_CF_universita,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')))
		ELSE SUBSTRING(@5a_2b_31b_2c_CF_universita,1,@lenCF16)
	END + 
	'00000001'+ -- Progressivo modulo
	SPACE(3) + 
	SPACE(25) +  --Filler
	SPACE(20)  
	-- Identificativo del produttore del SW (codice fiscale)
	+ CASE
		WHEN DATALENGTH(ISNULL(@7Codicefiscalesocietadichiarante,'')) <= @lenCF16
		THEN ISNULL(@7Codicefiscalesocietadichiarante,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@7Codicefiscalesocietadichiarante,'')))
		ELSE SUBSTRING(@7Codicefiscalesocietadichiarante,1,@lenCF16)
	END 
	+ (SELECT out_str FROM #RECORD_C)
	+
	'TR012014'+ SPACE(8)+
	-- Data Versamento
	 SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(@dataversamento)))) + CONVERT(varchar(2),DAY(@dataversamento))
	+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(@dataversamento)))) + CONVERT(varchar(2),MONTH(@dataversamento))
	+ CONVERT(varchar(4),YEAR(@dataversamento))
	+ SPACE (@1898Filler) -- + SPACE(1488) -- Filler
	+ 'A'  


-- RECORD Z
INSERT INTO #trace (out_str)
SELECT
	'Z' +				-- Tipo Record
	SPACE(14) +
	'000000001' + -- Nmero di record B
	'000000001' +-- Nmero di record C
	SPACE(1864) +
	+ 'A'  

SELECT out_str FROM #trace


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
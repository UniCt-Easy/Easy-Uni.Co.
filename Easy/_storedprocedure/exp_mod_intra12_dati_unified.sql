
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intra12_dati_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intra12_dati_unified]
GO 
/*
EXEC exp_mod_intra12_dati_unified 2010, 10, {d '2010-10-10'},'XX','999','S'
*/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_intra12_dati_unified] (
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
	SET @7Codicefiscalesocietadichiarante = '02890460781' -- Tempo

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


SET @30codiceCaricaRappresentante = '01' 

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
	TR012005							decimal(19,5), -- Acquisti - Imponibile Servizi
	TR012006							decimal(19,5), -- Acquisti - Imponibile Servizi art.7
	TR012007							decimal(19,5), -- Acquisti - Imposta Servizi
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
	UPDATE #RecordIntra12 set iddbdepartment = user
	WHERE   #RecordIntra12.iddbdepartment is null
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
			TR012005		, -- Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Servizi
			TR012006		, -- Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Servizi art.7
			TR012007		, -- Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Servizi
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
		WHERE   #RecordIntra12.iddbdepartment is null

		fetch next from @crsdepartment into @iddbdepartment
end
End

------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------


DECLARE @len_amount int
SET @len_amount = 15 -- con la virgola fa 16


SELECT 
	ISNULL(description,'') as 'Denominazione',
	'T1210'as 'Codice Fornitura',
	'01' as 'Tipo fornitore',
	CASE
		WHEN DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')) <= @lenCF16
		THEN ISNULL(@5a_2b_31b_2c_CF_universita,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@5a_2b_31b_2c_CF_universita,'')))
		ELSE SUBSTRING(@5a_2b_31b_2c_CF_universita,1,@lenCF16)
	END as 'CF',
	@ayear AS 'Anno di riferimento',
	CASE
		WHEN DATALENGTH(CONVERT(varchar(2),@mese)) <= 2
		THEN CONVERT(varchar(2),@mese) + SUBSTRING(SPACE(2),1,2 - DATALENGTH(CONVERT(varchar(2),@mese)))
		ELSE CONVERT(varchar(2),@mese)
	END as 'Mese di riferimento',+ 
	'0' as 'Correttiva',
	-- Partita IVA
	CASE
		WHEN DATALENGTH(ISNULL(@13PartitaIVA,'')) <= @lenPiva
		THEN ISNULL(@13PartitaIVA,'') + SUBSTRING(SPACE(@lenPiva),1,@lenPiva - DATALENGTH(ISNULL(@13PartitaIVA,'')))
		ELSE SUBSTRING(@13PartitaIVA,1,@lenPiva)
	END as 'P.iva',
	@14CodiceAttivita as 'Codice Attività',
	'0' as 'Eventi eccezionali',
	CASE
		WHEN DATALENGTH(ISNULL(@22Denominazione,'')) <= @lenDenominazione
		THEN ISNULL(@22Denominazione,'') + SUBSTRING(SPACE(@lenDenominazione),1,@lenDenominazione - DATALENGTH(ISNULL(@22Denominazione,'')))
		ELSE SUBSTRING(@22Denominazione,1,@lenDenominazione)
	END as ' Denominazione', 
	@23NaturaGiuridica as 'Natura giuridica',
	CASE
		WHEN DATALENGTH(ISNULL(@29CFdelrappresentante,'')) <= @lenCF16
		THEN ISNULL(@29CFdelrappresentante,'') + SUBSTRING(SPACE(@lenCF16),1,@lenCF16 - DATALENGTH(ISNULL(@29CFdelrappresentante,'')))
		ELSE SUBSTRING(@29CFdelrappresentante,1,@lenCF16)
	END as 'CF del Resp.', 
	@30codiceCaricaRappresentante as 'Cod.carica del Resp.',
	CASE
		WHEN DATALENGTH(ISNULL(@32CognomeRappresentante,'')) <= @lenCognome
		THEN ISNULL(@32CognomeRappresentante,'') + SUBSTRING(SPACE(@lenCognome),1,@lenCognome - DATALENGTH(ISNULL(@32CognomeRappresentante,'')))
		ELSE SUBSTRING(@32CognomeRappresentante,1,@lenCognome)
	END as 'Cognome del Resp.' ,
	CASE
		WHEN DATALENGTH(ISNULL(@33NomeRappresentante,'')) <= @lenNome
		THEN ISNULL(@33NomeRappresentante,'') + SUBSTRING(SPACE(@lenNome),1,@lenNome - DATALENGTH(ISNULL(@33NomeRappresentante,'')))
		ELSE SUBSTRING(@33NomeRappresentante,1,@lenNome)
	END as 'Nome del Resp.' ,
	 SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(@35DataNascitaRappresentante)))) + CONVERT(varchar(2),DAY(@35DataNascitaRappresentante))
	+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(@35DataNascitaRappresentante)))) + CONVERT(varchar(2),MONTH(@35DataNascitaRappresentante))
	+ CONVERT(varchar(4),YEAR(@35DataNascitaRappresentante))
	as ' Data Nascita Resp. ',
	CASE
		WHEN DATALENGTH(ISNULL(@36Comune_oStatoEstero_NascitaRappresentante,'')) <= @lenComune
		THEN ISNULL(@36Comune_oStatoEstero_NascitaRappresentante,'') + SUBSTRING(SPACE(@lenComune),1,@lenComune - DATALENGTH(ISNULL(@36Comune_oStatoEstero_NascitaRappresentante,'')))
		ELSE SUBSTRING(@36Comune_oStatoEstero_NascitaRappresentante,1,@lenComune)
	END as 'Comune Nascita Resp.' , 
	@37ProvinciaNascitaRappresentante as'Pr. Nascita Resp.',

	TR012001 as 'Acquisti intracomunitari - Imponibile', 
	TR012002 as 'Acquisti intracomunitari - Imposta', 
	TR012003 as 'Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea - Beni - Imponibile', 
	TR012004 as 'Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea - Beni - Imposta', 
	TR012005 as 'Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Servizi - Imponibile', 
	TR012006 as 'Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea - Servizi - Imponibile di cui art. 7Ter', 
	TR012007 as 'Acquisti soggetti stabiliti in altri Stati appartenenti all''Unione Europea - Servizi - Imposta', 
	TR012008 as 'Acquisti soggetti stabiliti in Stati non appartenenti all''Unione Europea - Beni - Imponibile', 
	TR012009 as 'Acquisti soggetti stabiliti in Stati non appartenenti all''Unione Europea - Beni - Imposta', 
	TR012010 as 'Acquisti soggetti stabiliti in Stati non appartenenti all''Unione Europea - Servizi - Imponibile', 
	TR012011 as 'Acquisti soggetti stabiliti in Stati non appartenenti all''Unione Europea - Servizi - Imponibile di cui art. 7 ', 
	TR012012 as 'Acquisti soggetti stabiliti in Stati non appartenenti all''Unione Europea - Servizi - Imposta', 
	TR012013 as 'Totale imposta', 
	TR012014 as  'Data Versamento'
FROM #RecordIntra12
LEFT OUTER JOIN dbdepartment ON #RecordIntra12.iddbdepartment = dbdepartment.iddbdepartment
WHERE (TR012001 <> 0 OR TR012002 <> 0 OR TR012003 <> 0 OR TR012004 <> 0 OR TR012005 <> 0 OR TR012006 <> 0 OR TR012007 <> 0 OR
TR012008 <> 0 OR TR012009 <> 0 OR TR012010 <> 0 OR TR012011 <> 0 OR TR012012 <> 0 OR TR012013 <> 0) 

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




 

                      --setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_opisiopeplus_var]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_opisiopeplus_var]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
---setuser 'amm'
 --setuser 'amministrazione'
 -- exec trasmele_income_opisiopeplus_var 2019, 126

CREATE  PROCEDURE [trasmele_income_opisiopeplus_var]
(
	@y int,
	@n int
)
AS BEGIN


----------------------------------------------------------------
--  STORED PROCEDURE PER LA TRASMISSIONE DELLE REVERSALI PER  --
--------------- BANCA POPOLARE DEL CASSINATE--------------------
----------------------------------------------------------------
-- Inizio Sezione dichiarativa
DECLARE @len_codentebt INT
SET @len_codentebt = 7

DECLARE @len_desc_dept int
SET @len_desc_dept = 30

DECLARE @len_address_dept int
SET @len_address_dept = 30

DECLARE @len_location_dept int
SET @len_location_dept = 35

DECLARE @len_cf int
SET @len_cf = 35

DECLARE @len_pi int
SET @len_pi = 35

DECLARE @len_pi_estera int
SET @len_pi_estera = 15

DECLARE @len_ABI int
SET @len_ABI = 5

DECLARE @len_CAB int
SET @len_CAB = 5

DECLARE @len_cc int
SET @len_cc = 12


DECLARE @idtreasurer int
DECLARE @k int
SELECT @idtreasurer = idtreasurer, @k = kproceedstransmission
FROM proceedstransmission
WHERE yproceedstransmission = @y
	AND nproceedstransmission = @n

--Può assumere i valori 
--INSERIMENTO– Inserimento  Ordinativo 
--VARIAZIONE- Variazione Ordinativo
--ANNNULLO- Annullo Ordinativo
--SOSTITUZIONE- Sostituzione Ordinativo
--(vedere specifiche tracciato ma non la gestiamo)

DECLARE @cod_department varchar(20) -- Codice dell'ente da esportare
DECLARE @cc varchar(28) -- Numero del Conto dell'ente presso l'istituto cassiere
DECLARE @cin char(2) -- Codice CIN
DECLARE @ABI_code varchar(5)
-- Fine Sezione Dichiarativa
DECLARE @destinazione varchar(20)

DECLARE @cc_vincolato varchar(8)

DECLARE @CodiceStruttura varchar(16)
DECLARE @len_CodiceStruttura int
SET @len_CodiceStruttura = 16

SELECT 
	@cod_department = ISNULL(RTRIM(agencycodefortransmission),''),
	@cc = ISNULL(cc,''),
	@cc_vincolato =  trasmcode		,
	@cin = ISNULL(cin, '00'),
	@ABI_code = SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(idbank,'')))
	+ ISNULL(idbank,''),
	@CodiceStruttura = 
		CASE
		WHEN DATALENGTH(ISNULL(billcode,'')) <= @len_CodiceStruttura
		THEN ISNULL(billcode,'') + SUBSTRING(SPACE(@len_CodiceStruttura),1,@len_CodiceStruttura - DATALENGTH(ISNULL(billcode,'')))
		ELSE SUBSTRING(billcode,1,@len_CodiceStruttura)
		END,
	@destinazione = (case when (flag&4)=0 then'LIBERA' else 'VINCOLATA' end)
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @cf_dept varchar(16)
DECLARE @desc_dept varchar(150)
DECLARE @address_dept varchar(30)
DECLARE @location_dept varchar(35)

SELECT  @cf_dept = ISNULL(cf,p_iva),
@desc_dept =  ISNULL(agencyname,''),
@address_dept = ISNULL(address1,''),
@location_dept = ISNULL(location,'') 
FROM license

DECLARE @Codice_ipa_struttura varchar(10)
SET @Codice_ipa_struttura = ( select ipa_fe from ipa where useforopi ='S')

DECLARE @len_agencycode int
SET @len_agencycode = 7

CREATE TABLE #error (message varchar(400))

-- Inizio Sezione Controlli
DECLARE @message varchar(200)
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
IF(
(SELECT COUNT(*) FROM incomevarview
WHERE kproceedstransmission = @k) = 0)
BEGIN
	INSERT INTO #error
	VALUES('La distinta di trasmissione ' + CONVERT(varchar(4),@y) + '/'
	+ CONVERT(varchar(6),@n) + ' è vuota')
END

-- CONTROLLO N. 1. Presenza dei dati dell'ente
DECLARE @error char(1)
SET @error = 'N'
SET @message = 'Mancano i seguenti dati: '
IF (@cod_department IS NULL OR @cod_department = '')
BEGIN
	SET @message = @message + ' Il Codice Ente'
	SET @error = 'S'
END

IF (@ABI_code IS NULL OR @ABI_code = '')
BEGIN
	SET @message = @message + ' Il codice ABI'
	SET @error = 'S'
END
IF (@error = 'S')
BEGIN
	SET @message = @message + ' Andare nella maschera CONFIGURAZIONE - CASSIERE - CASSIERE ed inserire i dati'
	INSERT INTO #error VALUES(@message)
END

-- CONTROLLO N. 2. Lunghezza del codice ente
IF (DATALENGTH(@cod_department) > @len_agencycode)
BEGIN
	INSERT INTO #error
	VALUES ('Il codice Ente inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@len_agencycode))
END

-- CONTROLLO N. 3  Presenza tipologia dei creditori
INSERT INTO #error (message)
SELECT 'Il versante ' + ISNULL(R.title,'XXX') + ' con codice ' + CONVERT(varchar(6),R.idreg) + ' non ha una tipologia associata. E'' necessario inserirla'
FROM income I
JOIN incomelast IL				ON I.idinc = IL.idinc
JOIN incomevar IV				ON IV.idinc = IL.idinc
JOIN proceeds P					ON P.kpro = IL.kpro
JOIN proceedstransmission T		ON T.kproceedstransmission = P.kproceedstransmission
JOIN registry R					ON R.idreg = I.idreg
WHERE R.idregistryclass IS NULL
	AND IV.kproceedstransmission = @k

-- CONTROLLO N. 4  Presenza di variazioni dati non trasmesse sullo stesso incasso
INSERT INTO #error (message)
SELECT 'Il movimento di entrata ' + CONVERT(varchar(6),I.nmov) + '/' + CONVERT(varchar(4),I.ymov) +
' ha altre variazioni dati non trasmesse'
FROM income I
JOIN incomelast IL
	ON I.idinc = IL.idinc
JOIN incomevar V
	ON IL.idinc = V.idinc
WHERE V.autokind = 22 
AND EXISTS (SELECT * FROM incomevar 
			 WHERE incomevar.idinc = V.idinc 
			   AND incomevar.nvar <> V.nvar 
			   AND incomevar.autokind = 22
			   AND incomevar.kproceedstransmission is null)
AND V.kproceedstransmission = @k

-- CONTROLLO N. 5  per BPS non sono ammessi annullamenti parziali
INSERT INTO #error (message)
SELECT ' La reversale di incasso n°' + CONVERT(varchar(6),IL.npro) + '/' + CONVERT(varchar(4),I.ymov) +
' deve essere annullata totalmente '
FROM income I
JOIN incomelastview IL
	ON I.idinc = IL.idinc
JOIN incomevar V
	ON IL.idinc = V.idinc
WHERE V.autokind IN  (10,11) 
AND EXISTS (SELECT * FROM incomelastview  IL1
			 WHERE IL1.kpro = IL.kpro 
			   AND IL1.idinc <> IL.idinc 
			   AND ISNULL(IL1.curramount,0) >0 )
AND V.kproceedstransmission = @k



IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
-- Fine Sezione Controlli

-- Tabella degli incassi
CREATE TABLE #proceeds
(
	opkind varchar(20),
	totalann char(1),
	autokind int,
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	kpro int,
	idinc int,
	ymov int, 
	nmov int, 
	nphase tinyint, 
	phase varchar(50),
	curramount decimal(19,2),
	curramount_expense decimal(19,2), -- importo della spesa accessoria
	originalamount decimal(19,2),
	idreg int,
	income_adate datetime,
	proceeds_adate datetime,
	transmissiondate datetime,
	idpro int, 
	accountkind char(1),
	title_ver varchar(140),
	address_ver varchar(116),
	cap_ver varchar(16),
	location_ver varchar(30),
	province_ver varchar(2),
	iso_code_ver varchar(2),
	pi_ver varchar(11),
	pi_ver_estera varchar(15),
	cf_ver varchar(16),
	free_stamp char(1),
	stamphandling varchar(50),
	stamp_charge char(1),
	exemption_stamp_motive varchar(20),
	proceedsdescr varchar(370),
	fulfilled char(1),
	idexp varchar(72),
	nbill varchar(7),
	cu varchar(64),
	codefin varchar(50),
	CR varchar(10),
	CUP varchar(15),
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodeincome varchar(15),
	tipo_riscossione varchar(50),
	destinazione varchar(20),
	tipo_entrata varchar(20),
	ccp_collection varchar(12),
	txt varchar(200) ,
	npay int,
	idpay int,
	flagpendingincome char(1),
	flagcompensation char(1)
)

-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	yproceedstransmission int,
	nproceedstransmission int,
	opkind varchar(20),
	ydoc int,
	ndoc int, 
	idpro int, idinc int,
	sortcode varchar(30),
	descr_sorting varchar(200),
	amount decimal(19,2),   -- importo classificato
	curramount decimal(19,2), -- importo reale incasso
	amount_expense decimal(19,2),  --- importo spesa accessoria
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodeincome varchar(15),
	flagpendingincome char(1),
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	importoclassificazionemov decimal(19,2),
	importo_siope decimal(19,2),
	natura_spesa_siope varchar(10),-- CORRENTE o CAPITALE
	data_scadenza_pagam_siope datetime,
	motivo_scadenza_siope varchar(50),
	flagnc char(1)
)

-- Tabella delle informazioni aggiuntive richieste dall'Ente
CREATE TABLE #note
(
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	idpro int, idinc int,
	nome_campo varchar(50),
	testo varchar(500)
)
        
DECLARE @incomeregphase	tinyint
SELECT @incomeregphase = incomeregphase FROM uniconfig

-- Tabella delle variazioni pagamenti annullati totalmente/parzialmente o variati di Siope
CREATE TABLE #proceedsvar
(
	idinc int,
	idpro int,
	amount decimal(19,2),
	autokind int,
	kpro int,
	totalann char(1)
)

--- 10 VARIAZIONI DI ANNULLAMENTO PARZIALE -- NON CONSENITE IN BPS
--- 11 VARIAZIONI DI ANNULLAMENTO TOTALE
--- 22 VARIAZIONI DATI = SIOPE

INSERT INTO #proceedsvar
(
	idinc, idpro, amount, autokind, kpro, totalann
)
SELECT
	e.idinc, el.idpro, v.amount, v.autokind, d.kpro,
	CASE v.autokind WHEN 11 THEN 'S' ELSE 'N' END
FROM incomevar v		
JOIN income e						ON v.idinc = e.idinc
JOIN incomelast el					ON e.idinc = el.idinc
JOIN proceeds d						ON d.kpro = el.kpro
JOIN proceedstransmission t			ON t.kproceedstransmission = d.kproceedstransmission
JOIN proceedstransmission tv		ON tv.kproceedstransmission = v.kproceedstransmission
WHERE v.kproceedstransmission = @k

--select * from #proceedsvar


-- Riempimento della tabella degli incassi con i movimenti che sono presenti nella distinta di trasmissione
INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, kpro, ydoc, ndoc, idinc, curramount,
	curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate,stamphandling,
	stamp_charge,exemption_stamp_motive, accountkind,
	title_ver, cf_ver, pi_ver, pi_ver_estera, proceedsdescr, fulfilled, idexp, 
	nbill, idpro,
	cupcodefin,cupcodeupb,cupcodeincome,tipo_riscossione, ccp_collection,
	destinazione, tipo_entrata,txt  , npay, idpay , flagpendingincome,
	flagcompensation 
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.kpro, d.ypro, d.npro, e.idinc, 
	i.curramount,
	CASE
		WHEN ((il.flag&32) <> 0) THEN isnull(el1.curramount,et.curramount)
		ELSE 0
	END,
	e.idreg, e.adate, d.adate, t.transmissiondate, 
	tb.description, 
	CASE 
		WHEN (tb.flag&0) <> 0 THEN 'N'
		ELSE 'S'
	END, --esenzione bollo
	ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'F'
		ELSE 'I'
	END,
	ISNULL(c.title,''),
	CASE
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
			THEN c.cf  
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
			THEN null --SPACE(@len_cf)
		ELSE null -- SPACE(@len_cf)
	END,
-- Partita IVA
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
			THEN null--SPACE(@len_pi) 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
		THEN SUBSTRING(isnull(c.p_iva,''),1,@len_pi)
		ELSE null--SPACE(@len_pi) 
	END,
-- Partita Iva estera
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
		-- Se è straniera la copiamo tale e quale. Quando verrrà inserita nel Record MP verrà interrogata nuovamente.		
		THEN c.p_iva
		ELSE NULL
	END,
	-- Causale riscossione
	ISNULL(e.description,'') ,
	CASE
		when (( il.flag & 1)=1) then 'S'
		else 'N'
	End,
	CASE
		WHEN ((il.flag&32) <> 0) THEN null
		ELSE isnull(el1.idexp,e.idpayment)
	END ,
	il.nbill, 
	il.idpro,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	CASE
		when ((( il.flag & 4)<> 0) and (( il.flag & 1)= 0)) then 'PRELIEVO DA CC POSTALE'
		when (((il.flag & 8)<> 0) and (( il.flag & 1)= 0)) then 'ACCREDITO BANCA D''ITALIA'
		when (((il.flag & 8)<> 0) and (( il.flag & 1)<>0)) then 'REGOLARIZZAZIONE ACCREDITO BANCA D''ITALIA'
		when (( il.flag & 1)<>0) then'REGOLARIZZAZIONE'
		else 'CASSA'
	END,
	c.ccp,
	/*CASE
		when  (( il.flag & 16)= 0) then 'LIBERA'
		else 'VINCOLATA'
	END,*/
	@destinazione,
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'FRUTTIFERO'
		ELSE 'INFRUTTIFERO'
	END,
	ltrim(rtrim(substring(e.txt, 1, 200))),
	isnull(el1.npay,pm.npay), isnull(el1.idpay,el.idpay),
	CASE
		WHEN ((il.flag&32) <> 0) THEN 'S'
		ELSE 'N'
	END,
	'N' 
FROM income e
JOIN incomelast il					ON e.idinc = il.idinc
JOIN incomeyear y					ON y.idinc = e.idinc
JOIN incometotal i					ON i.idinc = e.idinc
JOIN proceeds d						ON d.kpro = il.kpro
JOIN proceedstransmission t			ON t.kproceedstransmission = d.kproceedstransmission
JOIN registry c						ON c.idreg = e.idreg
JOIN registryclass ctc				ON ctc.idregistryclass = c.idregistryclass
JOIN incomelink as RegPhaseELK		ON RegPhaseELK.idchild = il.idinc AND RegPhaseELK.nlevel = @incomeregphase -- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
JOIN income RegPhase				ON RegPhase.idinc = RegPhaseELK.idparent  -- fase del Creditore
JOIN upb U							ON U.idupb = y.idupb
JOIN finlast						ON finlast.idfin = y.idfin
LEFT OUTER JOIN stamphandling tb	ON d.idstamphandling = tb.idstamphandling
LEFT OUTER JOIN fin f				ON f.idfin = d.idfin
LEFT OUTER JOIN expenselast el		ON 	el.idexp = e.idpayment
LEFT OUTER JOIN expense sp			ON el.idexp = sp.idexp	AND  sp.idreg = e.idreg
LEFT OUTER JOIN expenseyear  ey		ON el.idexp = ey.idexp
LEFT OUTER JOIN expensetotal et		ON et.idexp = ey.idexp
LEFT OUTER JOIN payment pm			ON el.kpay = pm.kpay
-- Contributi a carico dell'ente
--  se la configurazione dei contributi prevede un automatismo di spesa e uno di entrata su partita di giro
-- per gli automatismi dei contributi trasmetto anche il mandato  del corrispondente automatismo di spesa
 
LEFT OUTER JOIN expenselastview el1		ON 	el1.idpayment = e.idpayment	AND e.autokind = 4 -- Contributo
								AND el1.autokind = 4 AND el1.autocode  = e.autocode	AND el1.idreg = e.idreg	AND i.curramount = el1.curramount
	--AND @admintaxkind = 2 -- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro
WHERE  d.kpro IN (SELECT kpro FROM #proceedsvar) --> Solo le reversali variate  o annullate totalmente


---INSERISCO GLI INCASSI VIRTUALI OTTENUTI DAGLI INCASSI A REGOLARIZZAZIONE DI SOSPESI 
-- L'incasso reale sarà suddiviso in due tranches, uno a regolarizzazione di importo pari al sospeso e non collegato alla spesa
-- l'altro sarà un incasso virtuale  collegato alla spesa (in modo da ottenere complessivamente saldo zero ) e con idpro
-- fittizio pari a 2 (obblighiamo a fare le reversali singole in tali casi)
INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, kpro, ydoc, ndoc, idinc, curramount,
	curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate,stamphandling,
	stamp_charge,exemption_stamp_motive, accountkind,
	title_ver, cf_ver, pi_ver, pi_ver_estera, proceedsdescr, fulfilled, idexp, 
	nbill, idpro,
	cupcodefin,cupcodeupb,cupcodeincome,tipo_riscossione, ccp_collection,
	destinazione, tipo_entrata,txt  , npay, idpay , flagpendingincome,
	flagcompensation  
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.kpro, d.ypro, d.npro, e.idinc, 
	i.curramount,
	CASE
		WHEN ((il.flag&32) <> 0) THEN et.curramount
		ELSE 0
	END,
	e.idreg, e.adate, d.adate, t.transmissiondate, 
	tb.description, 
	CASE 
		WHEN (tb.flag&0) <> 0 THEN 'N'
		ELSE 'S'
	END, --esenzione bollo
	ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'F'
		ELSE 'I'
	END,
	ISNULL(c.title,''),
	CASE
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
			THEN c.cf  
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
			THEN null--SPACE(@len_cf)
		ELSE null--SPACE(@len_cf)
	END,
-- Partita IVA
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
			THEN null--SPACE(@len_pi) 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
		THEN SUBSTRING(isnull(c.p_iva,''),1,@len_pi)
		ELSE null--SPACE(@len_pi) 
	END,
-- Partita Iva estera
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
		-- Se è straniera la copiamo tale e quale. Quando verrrà inserita nel Record MP verrà interrogata nuovamente.		
		THEN c.p_iva
		ELSE NULL
	END,
	-- Causale riscossione
	ISNULL(e.description,'') ,
	CASE
		when (( il.flag & 1)=1) then 'S'
		else 'N'
	End,
	e.idpayment,
	null, --il.nbill, 
	il.idpro +1,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	CASE
		when ((( il.flag & 4)<> 0) and (( il.flag & 1)= 0)) then 'PRELIEVO DA CC POSTALE'
		when (((il.flag & 8)<> 0) and (( il.flag & 1)= 0)) then 'ACCREDITO BANCA D''ITALIA'
		when (((il.flag & 8)<> 0) and (( il.flag & 1)<>0)) then 'REGOLARIZZAZIONE ACCREDITO BANCA D''ITALIA'
		else 'CASSA'
	END,
	c.ccp,
	/*CASE
		when  (( il.flag & 16)= 0) then 'LIBERA'
		else 'VINCOLATA'
	END,*/
	@destinazione,
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'FRUTTIFERO'
		ELSE 'INFRUTTIFERO'
	END,
	ltrim(rtrim(substring(e.txt, 1, 200))),
	pm.npay, el.idpay,
	CASE
		WHEN ((il.flag&32) <> 0) THEN 'S'
		ELSE 'N'
	END,
	'N' 
FROM income e
JOIN incomelast il				ON e.idinc = il.idinc
JOIN incomeyear y				ON y.idinc = e.idinc
JOIN incometotal i				ON i.idinc = e.idinc
JOIN proceeds d					ON d.kpro = il.kpro
JOIN proceedstransmission t		ON t.kproceedstransmission = d.kproceedstransmission
JOIN registry c					ON c.idreg = e.idreg
JOIN registryclass ctc			ON ctc.idregistryclass = c.idregistryclass
JOIN incomelink as RegPhaseELK	ON RegPhaseELK.idchild = il.idinc	AND RegPhaseELK.nlevel = @incomeregphase -- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
JOIN income RegPhase			ON RegPhase.idinc = RegPhaseELK.idparent  -- fase del Creditore
JOIN upb U						ON U.idupb = y.idupb
JOIN finlast					ON finlast.idfin = y.idfin
LEFT OUTER JOIN stamphandling tb	ON d.idstamphandling = tb.idstamphandling
LEFT OUTER JOIN fin f			ON f.idfin = d.idfin
LEFT OUTER JOIN expenselast el	ON 	el.idexp = e.idpayment
LEFT OUTER JOIN expense sp		ON el.idexp = sp.idexp	AND  sp.idreg = e.idreg
LEFT OUTER JOIN expenseyear  ey	ON el.idexp = ey.idexp
LEFT OUTER JOIN expensetotal et	ON et.idexp = ey.idexp
LEFT OUTER JOIN payment pm		ON el.kpay = pm.kpay
WHERE  d.kpro IN (SELECT kpro FROM #proceedsvar) --> Solo le reversali variate  o annullate totalmente
AND ((il.flag&32) <>  0) 

UPDATE #proceeds SET CUP = ISNULL(cupcodeincome,  ISNULL(cupcodeupb, ISNULL(cupcodefin,''))) --Codice CUP

--------------------------------------------------------------------------------------------------------------------------------------
-- Le reversali a singola posta annullate (consideriamo i raggruppamenti dei movimenti bancari) si considerano annullate totalmente --
--------------------------------------------------------------------------------------------------------------------------------------
UPDATE #proceedsvar SET totalann = 'S' 
WHERE #proceedsvar.autokind = 10
	AND ((SELECT COUNT(idpro) FROM proceeds_bank WHERE proceeds_bank.kpro = #proceedsvar.kpro) = 1)
	AND (SELECT COUNT(idinc) FROM #proceeds
						 WHERE  #proceeds.idinc = #proceedsvar.idinc
						 AND ISNULL(#proceeds.curramount,0) = 0 ) = 1

UPDATE #proceeds 
SET autokind = #proceedsvar.autokind,
	totalann = #proceedsvar.totalann,
	opkind   = CASE
					#proceedsvar.totalann
					WHEN 'S' THEN 'ANNULLO'
					ELSE 'VARIAZIONE'
			   END 
FROM #proceedsvar
WHERE #proceeds.kpro = #proceedsvar.kpro

-- Calcoliamo l'importo originale dei sub annullati come : curramount + le var inserite nella distinta in oggetto.
UPDATE #proceeds SET originalamount = isnull(curramount,0) 
									- ISNULL((select sum(incomevar.amount)  -- Le var. sono negative, quindi col meno d'avanti, cambio il segno.
									FROM incomevar
									join proceedstransmission 
										ON incomevar.kproceedstransmission= proceedstransmission.kproceedstransmission
									Where proceedstransmission.yproceedstransmission = @y
										and proceedstransmission.nproceedstransmission = @n
										and incomevar.idinc = #proceeds.idinc
										),0)
										WHERE #proceeds.opkind = 'ANNULLO'
--select * from #proceeds				


-- Unificazione descrizioni di incasso per movimenti di entrata che sono stati accorpati
UPDATE #proceeds
SET proceedsdescr = 'ACCORPAMENTO INCASSI' -- + SPACE(350)--La formattazione l'ho postata alla fine, perchè deve scrivere anche il CUP, ponendolo come prima info del campo 'casuale riscossione'
WHERE
	(SELECT COUNT(*)
	FROM #proceeds i2
	WHERE i2.yproceedstransmission = #proceeds.yproceedstransmission
		AND i2.nproceedstransmission = #proceeds.nproceedstransmission
		AND i2.ydoc = #proceeds.ydoc
		AND i2.ndoc = #proceeds.ndoc
		AND i2.idpro = #proceeds.idpro) > 1
	AND 
		(SELECT COUNT(*)
		FROM #proceeds i2
		WHERE i2.yproceedstransmission = #proceeds.yproceedstransmission
			AND i2.nproceedstransmission = #proceeds.nproceedstransmission
			AND i2.ydoc = #proceeds.ydoc
			AND i2.ndoc = #proceeds.ndoc
			AND i2.idpro = #proceeds.idpro) <>
		(SELECT COUNT(*)
		FROM #proceeds i2
		WHERE i2.yproceedstransmission = #proceeds.yproceedstransmission
			AND i2.nproceedstransmission = #proceeds.nproceedstransmission
			AND i2.ydoc = #proceeds.ydoc
			AND i2.ndoc = #proceeds.ndoc
			AND i2.idpro = #proceeds.idpro
			AND i2.proceedsdescr = #proceeds.proceedsdescr)
DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase

CREATE TABLE #tax
(

	idexp int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	curramount decimal(19,2),
	curramount_expense decimal(19,2),
	idpro int,
	flagtotannullment char(1)
)
-- Calcolo del saldo dei pagamenti principali associati per capire se stiamo trasmettendo 
-- incassi a compensazione
-- Leggo TUTTI gli incassi ritenute e recuperi sugli stessi pagamenti principali prima estratti 
INSERT INTO #tax
(
	idexp, idinc, ypro, npro,  curramount,	curramount_expense,
	ymov_income, nmov_income, idpro,
	flagtotannullment
)
SELECT
	p.idexp, e.idinc, di.ypro, di.npro,  
	ey.amount, sy.amount, e.ymov, e.nmov, il.idpro,
	CASE  WHEN EXISTS (SELECT * FROM #proceedsvar PV WHERE PV.idinc = p.idinc AND
			   ((PV.autokind = 11) OR ((PV.autokind = 10) AND (ISNULL(p.curramount,0) = 0)) ) ) 
		  THEN  'S'
	      ELSE 'N'
	END
FROM #proceeds p
JOIN income e			ON e.idpayment = p.idexp	
JOIN incomelast il		ON e.idinc = il.idinc
JOIN incometotal ie		ON e.idinc = ie.idinc
JOIN incomeyear ey		ON p.idinc = ey.idinc AND  ie.ayear = ey.ayear
JOIN expenselast el		ON p.idexp = el.idexp
JOIN expensetotal se	ON p.idexp = se.idexp
JOIN expenseyear sy		ON p.idexp = sy.idexp AND  se.ayear = sy.ayear
JOIN proceeds di		ON di.kpro = il.kpro
WHERE e.nphase = @maxincomephase	AND e.idreg = p.idreg AND ie.ayear = @y
 
UPDATE #tax SET curramount = curramount + ISNULL((select SUM(amount) FROM incomevar WHERE incomevar.idinc = #tax.idinc AND incomevar.autokind NOT IN (10,11) ),0)
UPDATE #tax SET curramount_expense = curramount_expense + ISNULL((select SUM(amount) FROM expensevar WHERE expensevar.idexp = #tax.idexp 
																 AND expensevar.autokind NOT IN (10,11) ),0)
 
 DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase
-- Tabella delle trattenute a carico dell'ente
-- se la configurazione dei contributi prevede un automatismo di spesa e uno di entrata su partita di giro
-- per gli automatismi dei contributi leggo  i corrispondenti automatismi di spesa
CREATE TABLE #admintax
(

	idexp int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	amount decimal(19,2),
	amount_expense decimal(19,2),
	idpro int,
	flagtotannullment char(1)
)



 
 -- Leggo configurazione dell'applicazione dei contributi 
DECLARE @admintaxkind int
SELECT  @admintaxkind = (automanagekind & 0xf) FROM config WHERE ayear = @y


-- Inserimento delle trattenute (vengono inseriti i contributi c/amministrazione)
INSERT INTO #admintax
(
	idexp, idinc, ypro, npro,  amount, amount_expense,
	ymov_income, nmov_income, idpro,flagtotannullment
)	
	SELECT
	p.idexp, e.idinc, di.ypro, di.npro, iy.amount, sy.amount,
	e.ymov, e.nmov, il.idpro,
	CASE  WHEN EXISTS (SELECT * FROM #proceedsvar PV WHERE PV.idinc = p.idinc AND
	((PV.autokind = 11) OR ((PV.autokind = 10) AND (ISNULL(p.curramount,0) = 0)) ) ) THEN  'S'
	ELSE 'N'
	END
FROM #proceeds p
JOIN income e				ON e.idinc = p.idinc	
JOIN incomelast il			ON e.idinc = il.idinc
JOIN incometotal ie			ON e.idinc = ie.idinc
JOIN incomeyear iy			ON iy.idinc = ie.idinc	AND iy.ayear = ie.ayear 
JOIN proceeds di			ON di.kpro = il.kpro
JOIN expense s				ON s.idpayment = e.idpayment
JOIN expenselast el			ON s.idexp = el.idexp
JOIN expensetotal se		ON s.idexp = se.idexp
JOIN expenseyear sy			ON sy.idexp = se.idexp	AND sy.ayear = se.ayear
WHERE e.nphase = @maxincomephase
	and s.nphase = @maxexpensephase
	AND e.autokind = 4 -- Contributo
	AND s.autokind = 4 
	AND s.autocode  = e.autocode
	AND p.idreg = e.idreg
	AND ie.ayear = @y
	AND se.ayear = @y
	AND iy.amount = sy.amount
	AND @admintaxkind = 2-- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro-- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro
	 
-- gli incassi su partita di giro per contributi sono a compensazione
UPDATE #proceeds SET flagcompensation = 'S' 
WHERE idinc in (select idinc FROM #admintax)

 --- Mentre prima usavamo la modalità compensazione solo se il saldo complessivo dell'operazione (netto a pagare)
 --  fosse pari a zero, adesso invece tutti gli incassi associati a pagamenti sono a compensazione,
 --  in base alle linee guida OPI
 
UPDATE #proceeds SET flagcompensation = 'S' WHERE idexp in (select idexp FROM #tax) 
--WHERE idexp in (select idexp FROM #tax WHERE curramount_expense = 
--							isnull( (select sum(curramount) FROM #tax T1 where #tax.idexp = T1.idexp),0))

-- Gestione Indirizzi Versante 
DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_AVV'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @dateindi smalldatetime
SET @dateindi = (SELECT transmissiondate FROM proceedstransmission WHERE yproceedstransmission = @y AND nproceedstransmission = @n)

CREATE TABLE #address
(
	idaddresskind int,
	idreg int,
	address varchar(100),
	location varchar(116),
	cap varchar(15),
	province varchar(2),
	nation varchar(65),
	iso_code varchar(10)
)

INSERT INTO #address
(
	idaddresskind,
	idreg,
	address,
	location,
	cap,
	province,
	nation,
	iso_code
)
SELECT
	idaddresskind,
	idreg, 
	address,
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
	registryaddress.cap,
	geo_country.province,
	CASE 
		WHEN flagforeign = 'N' THEN 'ITALIA'
		ELSE geo_nation.title
	END,
	ISNULL(geo_nation_agency.value,'IT') 
FROM registryaddress
LEFT OUTER JOIN geo_city		ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country		ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation		ON geo_nation.idnation = registryaddress.idnation
LEFT OUTER JOIN geo_nation_agency	ON geo_nation_agency.idnation = registryaddress.idnation 
							AND geo_nation_agency.idagency = 6 -- ente ISO			
							AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
							AND geo_nation_agency.version = 1	AND geo_nation_agency.stop IS NULL
WHERE 
(registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND ((cdi.stop is null) OR (cdi.stop >= @dateindi))
			AND cdi.idreg = registryaddress.idreg))
			AND (idreg IN (SELECT DISTINCT idreg FROM #proceeds))

DELETE #address
WHERE #address.idaddresskind <> @nostand
	AND EXISTS(
		SELECT * FROM #address r2 
		WHERE #address.idreg = r2.idreg
			AND r2.idaddresskind = @nostand
	)

DELETE #address
WHERE #address.idaddresskind NOT IN (@nostand, @stand)
	AND EXISTS(
		SELECT * FROM #address r2 
		WHERE #address.idreg = r2.idreg
			AND r2.idaddresskind = @stand
	)

DELETE #address
WHERE (
	SELECT COUNT(*) FROM #address r2 
	WHERE #address.idreg = r2.idreg
)>1

-- Aggiornamento dei dati inerenti l'address del beneficiario	
UPDATE #proceeds
SET address_ver =
	(SELECT  ISNULL(address,'')
	FROM #address
	WHERE #proceeds.idreg = #address.idreg),
cap_ver =
	(SELECT  ISNULL(cap,'')
	FROM #address
	WHERE #proceeds.idreg = #address.idreg),
location_ver =
	(SELECT ISNULL(location,'')
	FROM #address
	WHERE #proceeds.idreg = #address.idreg),
province_ver =
	(SELECT ISNULL(province,'')),
iso_code_ver = 
	(SELECT iso_code	)
FROM #address
WHERE #proceeds.idreg = #address.idreg


-- Tabella delle Fatture pagate coi movimenti di spesa incorporati nel flusso 
CREATE TABLE #DocContabilizzato(
	ydoc int,
	ndoc int,
	idpro int,
	sortcode varchar(30),
	sorting varchar(200),
	--amount decimal(19,2),
	idinc int,
	
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	flagnc char(1),
	importo_siope decimal(19,2),
	natura_spesa_siope varchar(10),-- CORRENTE o CAPITALE
	data_scadenza_pagam_siope datetime,
	motivo_scadenza_siope varchar(50),
	var_present char(1)
)

INSERT INTO #DocContabilizzato(
	ydoc, ndoc,	idpro, idinc, 

	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope, 
	--importo_siope,
	natura_spesa_siope,-- CORRENTE o CAPITALE
	data_scadenza_pagam_siope,
	motivo_scadenza_siope
)
/*
nota di variazione = N
registro Acquisti 

OR
recupero cplit payment
=> COMMERCIALE
*/
SELECT distinct 
	#proceeds.ydoc, #proceeds.ndoc, #proceeds.idpro, #proceeds.idinc,
	case when invoicekind.enable_fe='S' THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end,
	I.ipa_acq,
	case when invoicekind.enable_fe='S' then 'ELETTRONICO' else 'ANALOGICO' end,
	convert(varchar(20), sdi_acquisto.identificativo_sdi),
	case when invoicekind.enable_fe='N' then 'FATT_ANALOGICA' else null end,
	@cf_dept,
	year(I.adate),
	case when invoicekind.enable_fe='S'  then sdi_acquisto.ninvoice else substring(I.doc,1,20) end ,
	case when	(select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO')>
				(select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA')
				then 'CORRENTE'
				else 'CAPITALE'
	end,
	-- Data Scadenza Pagamento
	case 
	-- Data contabile(data registrazione)  = Numero gg D.R.F.
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
	-- Data documento = Numero gg  D.F.
	when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
	when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
	-- Fine mese data documento = Numero gg F.M.D.F.
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
	-- Fine mese data contabile = Numero gg F.M.D.R.F.
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
	--	Pagamento Immediato  = data registrazione
	when I.idexpirationkind = 5 then I.adate
	-- Data ricezione
	when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
	when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end,
	-- motivo scadenza siope
	case when  D.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL') then 'SOSP_DECORRENZA_TERMINI'
		when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
	else null
	end
FROM #proceeds
JOIN invoicedetail D		ON #proceeds.idinc = D.idinc_taxable
join invoice I				on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
join invoicekind			on I.idinvkind = invoicekind.idinvkind
left outer join sdi_acquisto	on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
where D.idinc_taxable = D.idinc_iva -- Contabilizzazione totale
	/*NOTE CREDITO DI ACQUISTO INCASSATE: nota di variazione = N and registro Acquisti */
	and	(invoicekind.flag&4=0)
	and (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK 
					on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = i.idinvkind
					and RK.registerclass = 'A' -- il tipo documento è associato a un registro Acquisti
				) >0
UNION

SELECT distinct 
	#proceeds.ydoc, #proceeds.ndoc, #proceeds.idpro, #proceeds.idinc,
	case when invoicekind.enable_fe='S' THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end,
	I.ipa_acq,
	case when invoicekind.enable_fe='S' then 'ELETTRONICO' else 'ANALOGICO' end,
	convert(varchar(20), sdi_acquisto.identificativo_sdi),
	case when invoicekind.enable_fe='N' then 'FATT_ANALOGICA' else null end,
	@cf_dept,
	year(I.adate),
	case when invoicekind.enable_fe='S'  then sdi_acquisto.ninvoice else substring(I.doc,1,20) end ,
	case when	(select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO')>
				(select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA')
				then 'CORRENTE'
				else 'CAPITALE'
	end,
	-- Data Scadenza Pagamento
	case 
	-- Data contabile(data registrazione)  = Numero gg D.R.F.
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
	-- Data documento = Numero gg  D.F.
	when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
	when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
	-- Fine mese data documento = Numero gg F.M.D.F.
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
	-- Fine mese data contabile = Numero gg F.M.D.R.F.
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
	--	Pagamento Immediato  = data registrazione
	when I.idexpirationkind = 5 then I.adate
	-- Data ricezione
	when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
	when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end,
	-- motivo scadenza siope
	case when  D.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL') then 'SOSP_DECORRENZA_TERMINI'
		when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
	else null
	end
FROM #proceeds
JOIN invoicedetail D							ON #proceeds.idinc = D.idinc_taxable
join invoice I									on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
join invoicekind								on I.idinvkind = invoicekind.idinvkind
left outer join sdi_acquisto					on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
where D.idinc_taxable is not null and (D.idinc_iva is null or D.idinc_taxable <> D.idinc_iva ) -- Contabilizzazione SOLO IMPON
	/*NOTE CREDITO DI ACQUISTO INCASSATE: nota di variazione = N and registro Acquisti */
	and	(invoicekind.flag&4=0)
	and (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK 
					on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = i.idinvkind
					and RK.registerclass = 'A' -- il tipo documento è associato a un registro Acquisti
				) >0
UNION 
SELECT distinct 
	#proceeds.ydoc, #proceeds.ndoc, #proceeds.idpro, #proceeds.idinc,
	case when invoicekind.enable_fe='S' THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end,
	I.ipa_acq,
	case when invoicekind.enable_fe='S' then 'ELETTRONICO' else 'ANALOGICO' end,
	convert(varchar(20), sdi_acquisto.identificativo_sdi),
	case when invoicekind.enable_fe='N' then 'FATT_ANALOGICA' else null end,
	@cf_dept,
	year(I.adate),
	case when invoicekind.enable_fe='S'  then sdi_acquisto.ninvoice else substring(I.doc,1,20) end ,
	case when	(select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO')>
				(select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA')
				then 'CORRENTE'
				else 'CAPITALE'
	end,
	-- Data Scadenza Pagamento
	case 
	-- Data contabile(data registrazione)  = Numero gg D.R.F.
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
	-- Data documento = Numero gg  D.F.
	when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
	when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
	-- Fine mese data documento = Numero gg F.M.D.F.
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
	-- Fine mese data contabile = Numero gg F.M.D.R.F.
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
	--	Pagamento Immediato  = data registrazione
	when I.idexpirationkind = 5 then I.adate
	-- Data ricezione
	when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
	when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end,
	-- motivo scadenza siope
	case when  D.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL') then 'SOSP_DECORRENZA_TERMINI'
		when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
	else null
	end
FROM #proceeds
JOIN invoicedetail D						ON #proceeds.idinc = D.idinc_iva
join invoice I								on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
join invoicekind							on I.idinvkind = invoicekind.idinvkind
left outer join sdi_acquisto				on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
where D.idinc_iva is not null and (D.idinc_taxable is null or D.idinc_taxable <> D.idinc_iva ) -- Contabilizzazione SOLO IVA
	/*NOTE CREDITO DI ACQUISTO INCASSATE: nota di variazione = N and registro Acquisti */
	and	(invoicekind.flag&4=0)
	and (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK 
					on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = i.idinvkind
					and RK.registerclass = 'A' -- il tipo documento è associato a un registro Acquisti
				) >0


-- Inseriamo i dati delle fatture di acquisto soggette a SplitPayment il cui recupero iva è un mov. di entrata acssociato alla reversale in oggetto.
INSERT INTO #DocContabilizzato(
	ydoc, ndoc,	idpro, idinc, 

	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/ 
	numero_fattura_siope, 
	flagnc,
	importo_siope,
	natura_spesa_siope, -- CORRENTE o CAPITALE
	data_scadenza_pagam_siope,
	motivo_scadenza_siope,
	var_present
)
--Prima inserisce le fatture aventi anche una NC associata, e poi le fatture senza NC associata.
SELECT  
	#proceeds.ydoc, #proceeds.ndoc, #proceeds.idpro, #proceeds.idinc,
	case when invoicekind.enable_fe='S' THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end,
	I.ipa_acq,
	case when invoicekind.enable_fe='S' then 'ELETTRONICO' else 'ANALOGICO' end,
	convert(varchar(20), sdi_acquisto.identificativo_sdi),
	case when invoicekind.enable_fe='N' then 'FATT_ANALOGICA' else null end,
	@cf_dept,
	year(I.adate),
	case when invoicekind.enable_fe='S'  then sdi_acquisto.ninvoice else substring(I.doc,1,20) end ,
	case when ((invoicekind.flag&4)<>0) then 'S' else 'N' end,
	CASE when ((invoicekind.flag&4)<>0) THEN 
		- (
		CONVERT(decimal(19,2),ROUND(ISNULL(D.tax,0),2))
		)
	else 	CONVERT(decimal(19,2),ROUND(ISNULL(D.tax,0),2))
	end,
	case when	(select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO')>
				(select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA')
				then 'CORRENTE'
				else 'CAPITALE'
	end,
	-- Data Scadenza Pagamento
	case 
	-- Data contabile(data registrazione)  = Numero gg D.R.F.
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
	-- Data documento = Numero gg  D.F.
	when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
	when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
	-- Fine mese data documento = Numero gg F.M.D.F.
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
	-- Fine mese data contabile = Numero gg F.M.D.R.F.
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
	--	Pagamento Immediato  = data registrazione
	when I.idexpirationkind = 5 then I.adate
	-- Data ricezione
	when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
	when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end,
	-- motivo scadenza siope
	case when  D.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL') then 'SOSP_DECORRENZA_TERMINI'
		when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
	else null
	end,
	'S'
FROM #proceeds
JOIN invoicedetail D			ON #proceeds.idexp = D.idexp_taxable
join invoice I					on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
join invoicekind				on I.idinvkind = invoicekind.idinvkind
left outer join sdi_acquisto	on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
where  (select count(*) from expensevar where expensevar.idexp = #proceeds.idexp) >0 /*Esiste un NC contabilizzata col Pagamento*/
UNION
SELECT  
	#proceeds.ydoc, #proceeds.ndoc, #proceeds.idpro, #proceeds.idinc,
	case when invoicekind.enable_fe='S' THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end,
	I.ipa_acq,
	case when invoicekind.enable_fe='S' then 'ELETTRONICO' else 'ANALOGICO' end,
	convert(varchar(20), sdi_acquisto.identificativo_sdi),
	case when invoicekind.enable_fe='N' then 'FATT_ANALOGICA' else null end,
	@cf_dept,
	year(I.adate),
	case when invoicekind.enable_fe='S'  then sdi_acquisto.ninvoice else substring(I.doc,1,20) end ,
	case when ((invoicekind.flag&4)<>0) then 'S' else 'N' end,
	null, --importo_siope,
	case when	(select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO')>
				(select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA')
				then 'CORRENTE'
				else 'CAPITALE'
	end,
	-- Data Scadenza Pagamento
	case 
	-- Data contabile(data registrazione)  = Numero gg D.R.F.
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
	when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
	-- Data documento = Numero gg  D.F.
	when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
	when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
	-- Fine mese data documento = Numero gg F.M.D.F.
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
	when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
	-- Fine mese data contabile = Numero gg F.M.D.R.F.
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
	when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
	--	Pagamento Immediato  = data registrazione
	when I.idexpirationkind = 5 then I.adate
	-- Data ricezione
	when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
	when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end,
	-- motivo scadenza siope
	case when  D.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL') then 'SOSP_DECORRENZA_TERMINI'
		when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
	else null
	end,
	'N'
FROM #proceeds
JOIN invoicedetail D			ON #proceeds.idexp = D.idexp_taxable
join invoice I					on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
join invoicekind				on I.idinvkind = invoicekind.idinvkind
left outer join sdi_acquisto	on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
where  (select count(*) from expensevar where expensevar.idexp = #proceeds.idexp) =0 /*Non Esiste un NC contabilizzata col Pagamento*/
and (select income.autokind from income where income.idinc =  #proceeds.idinc) = 6  

-- Riempimento della tabella con i dati della classificazione SIOPE
DECLARE @codeclassSIOPE varchar(20)

SELECT  @codeclassSIOPE  =  
CASE  
	WHEN  (@y<= 2006) THEN  'SIOPE'
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  '07E_SIOPE'
	ELSE   'SIOPE_E_18'
END

	
DECLARE @classSIOPE int
SELECT @classSIOPE = idsorkind FROM sortingkind WHERE codesorkind = @codeclassSIOPE

-- Riempimento della tabella delle classificazioni SIOPE
INSERT INTO #siope
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idpro,idinc,
	sortcode, descr_sorting, 
	curramount, amount_expense, 
	importoclassificazionemov, --> CLASSIIFCAZIONE SIOPE
	importo_siope,
	cupcodefin, cupcodeupb, cupcodeincome,opkind,flagpendingincome,
	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope, 
	natura_spesa_siope, -- CORRENTE o CAPITALE
	data_scadenza_pagam_siope,
	motivo_scadenza_siope,
	flagnc
)
	SELECT
		#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
		#proceeds.idpro, #proceeds.idinc, 
		sorting.sortcode,sorting.description,  
		SUM(#proceeds.curramount), SUM(#proceeds.curramount_expense),

		incomesorted.amount, 
		SUM(DOC.importo_siope),		
		#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome, #proceeds.opkind,#proceeds.flagpendingincome,
		--DOC.tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
		case when DOC.tipo_debito_siope is not null then DOC.tipo_debito_siope
			else 'NON COMMERCIALE'
			end,
		DOC.codice_ipa_ente_siope,
	
		DOC.tipo_documento_siope, -- ELETTRONICO o ANALOGICO
		DOC.identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
		DOC.tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
		/*Se cartacea*/
		DOC.codice_fiscale_emittente_siope,
		DOC.anno_emissione_fattura_siope ,
	
		/*ctDati_fattura_siope*/
		DOC.numero_fattura_siope, 
		DOC.natura_spesa_siope,-- CORRENTE o CAPITALE
		DOC.data_scadenza_pagam_siope,
		DOC.motivo_scadenza_siope,
		DOC.flagnc
	FROM #proceeds
	JOIN incomesorted			ON #proceeds.idinc = incomesorted.idinc
	JOIN sorting				ON sorting.idsor = incomesorted.idsor
	join #DocContabilizzato DOC	on DOC.idinc = #proceeds.idinc
	WHERE sorting.idsorkind = @classSIOPE
	 and DOC.var_present='S'
 	AND NOT EXISTS (SELECT * FROM #proceedsvar PV WHERE PV.idinc = #proceeds.idinc AND
		((PV.autokind = 11) OR ((PV.autokind = 10) AND (ISNULL(#proceeds.curramount,0) = 0)) ) )
	GROUP BY
		#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
		#proceeds.idpro, #proceeds.idinc,sorting.sortcode,sorting.description,
		#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome,#proceeds.opkind,#proceeds.flagpendingincome,
		DOC.tipo_debito_siope,
		DOC.codice_ipa_ente_siope,	DOC.tipo_documento_siope, 
		DOC.identificativo_lotto_sdi_siope,	DOC.tipo_documento_analogico_siope , 
		DOC.codice_fiscale_emittente_siope,	DOC.anno_emissione_fattura_siope ,
		DOC.numero_fattura_siope, 	DOC.natura_spesa_siope,DOC.data_scadenza_pagam_siope,	
		DOC.motivo_scadenza_siope,DOC.flagnc,incomesorted.amount
	HAVING SUM(incomesorted.amount) <> 0
UNION
--Iserisce le fatture di acquisto che hanno dato origine al recupero split, aventi una NC collegata
-- e gli incassi senza documento
	SELECT
		#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
		#proceeds.idpro, #proceeds.idinc, sorting.sortcode,sorting.description,  
		SUM(#proceeds.curramount), SUM(#proceeds.curramount_expense),
		incomesorted.amount, 
		SUM(incomesorted.amount), 
		#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome, #proceeds.opkind,#proceeds.flagpendingincome,
		--DOC.tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
		case when DOC.tipo_debito_siope is not null then DOC.tipo_debito_siope
			else 'NON COMMERCIALE'
			end,
		DOC.codice_ipa_ente_siope,
	
		DOC.tipo_documento_siope, -- ELETTRONICO o ANALOGICO
		DOC.identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
		DOC.tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
		/*Se cartacea*/
		DOC.codice_fiscale_emittente_siope,
		DOC.anno_emissione_fattura_siope ,
	
		/*ctDati_fattura_siope*/
		DOC.numero_fattura_siope, 
		DOC.natura_spesa_siope,-- CORRENTE o CAPITALE
		DOC.data_scadenza_pagam_siope,
		DOC.motivo_scadenza_siope,
		isnull(DOC.flagnc,'N')
	FROM #proceeds
	JOIN incomesorted			ON #proceeds.idinc = incomesorted.idinc
	JOIN sorting				ON sorting.idsor = incomesorted.idsor
	left outer join #DocContabilizzato DOC	on DOC.idinc = #proceeds.idinc
	WHERE sorting.idsorkind = @classSIOPE
		and (DOC.var_present='N' or   DOC.var_present is null)
		AND NOT EXISTS (SELECT * FROM #proceedsvar PV WHERE PV.idinc = #proceeds.idinc AND
		((PV.autokind = 11) OR ((PV.autokind = 10) AND (ISNULL(#proceeds.curramount,0) = 0)) ) )
GROUP BY
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro, #proceeds.idinc,sorting.sortcode,sorting.description,
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome,#proceeds.opkind,#proceeds.flagpendingincome,
	DOC.tipo_debito_siope,
	DOC.codice_ipa_ente_siope,	DOC.tipo_documento_siope, 
	DOC.identificativo_lotto_sdi_siope,	DOC.tipo_documento_analogico_siope , 
	DOC.codice_fiscale_emittente_siope,	DOC.anno_emissione_fattura_siope ,
	DOC.numero_fattura_siope, 	DOC.natura_spesa_siope,DOC.data_scadenza_pagam_siope,	
	DOC.motivo_scadenza_siope,DOC.flagnc,incomesorted.amount
HAVING SUM(incomesorted.amount) <> 0

-- Riproporziono l'importo delle classificazioni SIOPE
-- Per idpro 1
-- vecchio importo classificato : nuovo importo classificato = importo corrente : importo corrente - spesa accessoria
-- nuovo importo classificato = vecchio importo classificato * (importo corrente -spesa accessoria) / importo corrente  
UPDATE #siope SET importoclassificazionemov= isnull(#siope.importoclassificazionemov,0) * (isnull(#siope.curramount,0) - isnull(#siope.amount_expense,0))/isnull(#siope.curramount,0) 
WHERE #siope.flagpendingincome  = 'S' and #siope.idpro = 1

--Per idpro 2
--vecchio importo classificato : nuovo importo classificato = importo corrente : spesa accessoria
--nuovo importo classificato = vecchio importo classificato * spesa accessoria / importo corrente
UPDATE #siope SET importoclassificazionemov = isnull(#siope.importoclassificazionemov,0) * (isnull(#siope.amount_expense,0)/isnull(#siope.curramount,0))
WHERE #siope.flagpendingincome  = 'S' and #siope.idpro = 2

-- L'incasso virtuale viene modificato per quanto attiene il flag a copertura, in quanto non può essere agganciato al sospeso,
-- solo la porzione di importo corrente - spesa accessoria deve figurare a regolarizzazione (idpro 1)
UPDATE #proceeds SET fulfilled = 'N'
WHERE #proceeds.flagpendingincome  = 'S' and #proceeds.idpro = 2

-- Infine  ricalcolo l'importo degli incassi
UPDATE #proceeds SET curramount=  isnull(#proceeds.curramount,0) - isnull(#proceeds.curramount_expense,0)
WHERE #proceeds.flagpendingincome  = 'S' and #proceeds.idpro = 1

UPDATE #proceeds SET curramount= isnull(#proceeds.curramount_expense,0)
WHERE #proceeds.flagpendingincome  = 'S' and #proceeds.idpro = 2

-- Tabella delle bollette multiple 
CREATE TABLE #incomebill
(
	yproceedstransmission int,
	nproceedstransmission int,
	idinc int,
	ydoc int,
	ndoc int,
	idpro int,
	ybill int,
	nbill int,
	amount decimal(19,2),
	opkind char(1)
)
-- Riempimento della tabella delle bollette  

--  Bollette singole
INSERT INTO  #incomebill
(	yproceedstransmission, nproceedstransmission, idinc,
	ydoc, ndoc, idpro, ybill,nbill, amount)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.idinc, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro, ydoc, incomelast.nbill,     
	CASE 
  		WHEN (#proceeds.opkind = 'VARIAZIONE') THEN  #proceeds.curramount
  		WHEN (#proceeds.opkind = 'ANNULLO') THEN  #proceeds.originalamount 				 
	END
FROM #proceeds JOIN incomelast ON #proceeds.idinc = incomelast.idinc
WHERE   incomelast.nbill IS NOT NULL AND #proceeds.fulfilled = 'S'  
 
	
 -- Bollette multiple
INSERT INTO  #incomebill
(	yproceedstransmission, nproceedstransmission, idinc,
	ydoc, ndoc, idpro, ybill,nbill, amount)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.idinc, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro, incomebill.ybill, incomebill.nbill,    incomebill.amount
FROM #proceeds
JOIN incomebill ON #proceeds.idinc = incomebill.idinc AND #proceeds.fulfilled = 'S'  
WHERE (#proceeds.flagpendingincome = 'N' OR (#proceeds.flagpendingincome = 'S' AND #proceeds.idpro <> 2))
-----------------------------------------------------------------------------------------------------------------
----------------------------------------------inizio tracciato---------------------------------------------------
-----------------------------------------------------------------------------------------------------------------
 
---------------------------------------------
---------- testata flusso -------------------
---------------------------------------------
DECLARE @codice_ABI_BT varchar(5)
DECLARE @identificativo_flusso  varchar(10)
--DECLARE @data_ora_creazione_flusso  varchar(20)
--SET     @data_ora_creazione_flusso = CONVERT(varchar(19),CONVERT(smalldatetime, GETDATE(), 126),126) 
DECLARE @data_ora_creazione_flusso  datetime
SET   @data_ora_creazione_flusso =  GETDATE()

DECLARE @codice_ente  varchar(16) -- (PRIMA : da valorizzare con partita iva ente oppure codice fiscale) NEW : Codice IPA dell'ente (cod_uni_ou). Si potrebbe prendere dalla tabella IPA
 --set @codice_ente = 'uni_rm2' --DA USARE PER IL TEST SU https://oil.test.uniit.it
set @codice_ente = ( select ipa_fe from ipa where useforopi ='S')

DECLARE @codice_fiscale_ente varchar(16)	--(new)Prima veniva valorizzato @codice_ente col CF, adesso valorizziamo @codice_fiscale_ente
SET @codice_fiscale_ente = @cf_dept

---SET @codice_ente = @cf_dept
DECLARE @descrizione_ente varchar(150)
set @descrizione_ente = @desc_dept
DECLARE @codice_ente_BT  varchar(9)
SET @codice_ente_BT = @cod_department
DECLARE @codice_tramite_BT VARCHAR(20) --(NEW) -- TODO: aggiungere alla tabella treasurer FATTO
DECLARE @codice_istat_ente	varchar(20)--(new)-- Codice ISTAT dell'ente.contiene il codice ente SIOPE in corso di validità.  TODO: aggiungere alla tabella treasurer. FATTO
declare @codice_tramite_ente  VARCHAR(20) --(NEW) -- TODO: aggiungere alla tabella treasurer FATTO
SELECT  @codice_tramite_BT = ISNULL(RTRIM(tramite_bt_code),''),
	@codice_tramite_ente =  ISNULL(RTRIM(tramite_agency_code),''),
	@codice_istat_ente = ISNULL(RTRIM(agency_istat_code),'')
FROM treasurer WHERE idtreasurer = @idtreasurer
DECLARE @riferimento_ente varchar(30)
DECLARE @esercizio int
SET @esercizio = @y -- esercizio finanziario
SET @codice_ABI_BT = @ABI_code
---------------------------------------------
----- fine testata flusso -------------------
---------------------------------------------

-- Tabella di output
CREATE TABLE #trace
(
	kind char(50), 
	-------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------INIZIO TIPO RIGA TESTATA--------------------------------------------------------
	--- contiene le informazioni relative all'intera distinta, come l'identificativo, l'esercizio ecc..----------------------------------
    --- KIND : TESTATA ------------------------------------------------------------------------------------------------------------------
    -------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------
	---------- testata flusso -------------------
	---------------------------------------------
	codice_ABI_BT varchar(5),
	identificativo_flusso varchar(20),
	data_ora_creazione_flusso datetime,---varchar(20),
	codice_ente varchar(16), -- Prima : partita iva o codice fiscale, Ora:ipa
	descrizione_ente varchar(150),
	codice_istat_ente varchar(20),
	codice_fiscale_ente varchar(16), 
	codice_tramite_ente varchar(20),
	codice_ente_BT varchar(20),
	codice_tramite_BT VARCHAR(20), --new
	riferimento_ente varchar(20),
	esercizio int,
	
	-------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA TESTATA-----------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA REVERSALE -------------------------------------------------------
    --- contiene le informazioni relative all'intera reversale. L'identificativo è dato da ndoc (corrisponde a npro nella tabella proceeds)-- 
	--- KIND : REVERSALE, TIPO RIGA PADRE: TESTATA, CHIAVE: ndoc----------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------

	---------------------------------------------
	----------------- reversale -------------------
	---------------------------------------------
	ndoc int,	
	tipo_operazione varchar(20),
	numero_reversale int,
	data_reversale varchar(20),
	importo_reversale decimal(19,2), 
	conto_evidenza varchar(10), -- mettere 1
	dati_codice_struttura varchar(20),
	dati_codice_ipa_struttura varchar(20),
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA REVERSALE ---------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA INFO_VERSANTE---------------------------------------------------- 
    --- contiene le informazioni relative alla riga di reversale (sub del mandato), che nella terminologia del tracciato BPS si chiama ----
    --  versante. In questo tipo riga  ho inserito non solo le informazioni relative alla sezione info_versante del tracciato XML ---------
    --  ma ho aggiunto anche altre sezioni in corrispondenza uno a uno con la riga di reversale, come bollo, sospeso, mandato associato ---
	--  KIND : INFO_VERSANTE,   TIPO RIGA PADRE: REVERSALE, SELETTORI: ndoc (sarebbe npro, riferimento alla reversale), CHIAVE: idpro -----
	---------------------------------------------------------------------------------------------------------------------------------------

	----------------------------------------------------
	-----------------info versante -----------------
	----------------------------------------------------
	idpro int,	idinc int,
	progressivo_versante int,
	importo_versante decimal(19,2),
	tipo_riscossione varchar(50),
	numero_ccp varchar(20),
	tipo_entrata varchar(20),
	destinazione varchar(20),
	
	---------------------------------------------
	----------------- bollo ---------------------
	---------------------------------------------
	assoggettamento_bollo varchar(50),
	causale_esenzione_bollo varchar(50),
	---------------------------------------------
	----------------- versante ------------------
	---------------------------------------------
	anagrafica_versante varchar(100),
	indirizzo_versante varchar(100),
	cap_versante varchar(16),
	localita_versante varchar(116),
	provincia_versante varchar(10),
	stato_versante varchar(2),
	partita_iva_versante varchar(20),
	codice_fiscale_versante varchar(20),
	---------------------------------------------
	----------------- causale ------------------
	---------------------------------------------
	causale varchar(400),
	-----------------------------------------------
	------------------ sospeso --------------------
	-----------------------------------------------
	numero_provvisorio int, 
	importo_provvisorio decimal(19,2),
	-----------------------------------------------
	------------------ mandato--------------------
	-----------------------------------------------
	numero_mandato int,
	progressivo_beneficiario int,
	-----------------------------------------------
	---------- informazioni aggiuntive-------------
	-----------------------------------------------
	lingua varchar(10),
	riferimento_documento_esterno varchar(20),
	note varchar(400),
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA INFO_REVERSALE ----------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	----------------------------------------------------INIZIO TIPO RIGA CLASSIFICAZIONI ------------------------------------------------- 
    --- contiene le informazioni relative alle classificazioni SIOPE associate alla riga di reversale (sub della reversale), che nella ---------
    --  terminologia del tracciato BPS si chiama versante. Infatti possono esserci delle righe di mandato multiclassificate ----------- 
	--  KIND : CLASSIFICAZIONI,   TIPO RIGA PADRE: INFO_VERSANTE, SELETTORI: ndoc (sarebbe npro, riferimento alla reversale ) e idpro ------
	--- CHIAVE: codice_cge (codice SIOPE USCITE)-------------------------------------------------------------------------------------------
	---------------------------------------------------------------------------------------------------------------------------------------

	---------------------------------------------
	----------------- classificazioni -----------
	---------------------------------------------
	codice_cge varchar(10),
	importoclassificazionemov decimal(19,2),
	importo_siope decimal(19,2),
		--classificazione_dati_siope_uscite
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	--importo_siope decimal(19,2),
	natura_spesa_siope varchar(10), -- CORRENTE o CAPITALE
	data_scadenza_pagam_siope varchar(20),
	motivo_scadenza_siope varchar(50),
	-----------------------------------------------
	---- dati_a_disposizione_ente_versante --------
	-----------------------------------------------
	dati_a_disposizione_ente_versante varchar(400),
	-----------------------------------------------
	---- dati_a_disposizione_ente_reversale ---------
	-----------------------------------------------
	dati_a_disposizione_ente_reversale varchar(400)
	)
	
	---------------------------------------------
	---------- testata flusso -------------------
	--------------------------------------------
	INSERT INTO #trace(kind,
				   codice_ABI_BT,
				   identificativo_flusso,
				   data_ora_creazione_flusso,
				   codice_ente,
				   descrizione_ente,
				   codice_istat_ente,
				   codice_fiscale_ente,
				   codice_tramite_ente,
				   codice_tramite_BT,
				   codice_ente_BT,
				   riferimento_ente,
				   esercizio)
SELECT 
				   'TESTATA',
				   @codice_ABI_BT,
				   'reversali_'+ convert(varchar(4),@y) + '_' + convert(varchar(4),@n),
				   @data_ora_creazione_flusso,
				   @codice_ente,
				   @descrizione_ente,
				   @codice_istat_ente,
					@codice_fiscale_ente,
					@codice_tramite_ente,
					@codice_tramite_BT,
				   @codice_ente_BT,
				   @riferimento_ente,
				   @y
				   
				   
INSERT INTO #trace(kind,
				   ndoc,
				   tipo_operazione,
				   numero_reversale,
				   data_reversale,
				   importo_reversale, 
				   conto_evidenza,  -- mettere 1
				   dati_codice_struttura,
				   dati_codice_ipa_struttura
				   )		
SELECT 
				   'REVERSALE',
				   ndoc, 
				   opkind,
				   ndoc,
				   CONVERT(VARCHAR(10),proceeds_adate,20),
				   CASE #proceeds.opkind
						WHEN 'VARIAZIONE' THEN SUM(curramount)
						ELSE SUM(originalamount)
				   END, 
				   @cc_vincolato,
				   @CodiceStruttura,
				   @Codice_ipa_struttura
FROM #proceeds
GROUP BY  #proceeds.ndoc,proceeds_adate, opkind	
ORDER BY  #proceeds.ndoc
 
INSERT INTO #trace(kind,
				   ndoc,
				   ----------------------------------------------
				   ------------------- info versante ------------
				   ----------------------------------------------
				   idpro, idinc,
				   progressivo_versante,
				   importo_versante,
				   tipo_riscossione,
				   numero_ccp,
				   tipo_entrata,
				   destinazione,
				   ---------------------------------------------
				   ----------------- versante ------------------
	               ---------------------------------------------
				   anagrafica_versante,
				   indirizzo_versante,
				   cap_versante,
				   localita_versante ,
				   provincia_versante,
				   stato_versante,
				   partita_iva_versante ,
				   codice_fiscale_versante,
				   causale,
				   ---------------------------------------------
				   -------------------- bollo ------------------
				   ---------------------------------------------
				   assoggettamento_bollo,
				   causale_esenzione_bollo,
				   -----------------------------------------------
				   ------------------ mandato --------------------
				   -----------------------------------------------
				   numero_mandato,
				   progressivo_beneficiario,
				   -----------------------------------------------
				   ---------- informazioni aggiuntive-------------
				   -----------------------------------------------
				   lingua,
				   riferimento_documento_esterno,
				   note,
				   dati_a_disposizione_ente_versante
				   )
SELECT
 'INFO_VERSANTE',
				   #proceeds.ndoc,
				   idpro, #proceeds.idinc,
				   idpro,
				   CASE 
  						WHEN  #proceeds.opkind = 'VARIAZIONE' THEN SUM(#proceeds.curramount)
  						WHEN  #proceeds.opkind = 'ANNULLO'    THEN SUM(#proceeds.originalamount)
  						ELSE NULL
  				   END,
				   --- CAMBIO IL TIPO RISCOSSIONE IN COMPENSAZIONE NEI CASI PREVISTI (ASSOCIAZIONE CON MOVIMENTI DI SPESA A SALDO ZERO)
				   CASE WHEN flagcompensation = 'S'  THEN 'COMPENSAZIONE'
				   ELSE tipo_riscossione
				   END ,
				   ccp_collection,
				   tipo_entrata,
				   destinazione, 
				   SUBSTRING(title_ver,1,60), 
				   -- Indirizzo Versante
				   SUBSTRING(address_ver,1,30),
				   -- C.A.P. Versante
				   cap_ver,
				   -- Località Versante
				   SUBSTRING(location_ver,1,30),
				   -- Provincia Versante
				   province_ver,
				   -- Stato Versante
				   iso_code_ver,
				   pi_ver,
				   cf_ver, 
				   SUBSTRING(proceedsdescr,1,160),
				   --- Bollo
				   stamphandling,
				   -- causale esenzione bollo
				   case
				     WHEN (fulfilled = 'S') THEN 'DOCUMENTO A REGOLARIZZAZIONE DI PROVVISORI/SOSPESI'
					 WHEN (stamp_charge = 'S' ) THEN exemption_stamp_motive
					  ELSE null
  				   END,
  				   --- MANDATO COLLEGATO --
  				   npay,
  				   idpay,
  				   null,
				   -- Riferimento Documento Esterno  
				   null,
				   -- Informazioni Tesoriere
				   isnull(#proceeds.txt,''),
				   null
FROM #proceeds
--WHERE #proceeds.opkind <> 'ANNULLO'
GROUP BY #proceeds.ndoc, #proceeds.idpro,#proceeds.idinc, #proceeds.opkind , tipo_riscossione, ccp_collection,tipo_entrata,
destinazione, title_ver, address_ver, cap_ver, location_ver, province_ver,
iso_code_ver, pi_ver, cf_ver, proceedsdescr, stamphandling, stamp_charge,exemption_stamp_motive,
isnull(#proceeds.txt,''), npay,  idpay,flagcompensation, fulfilled
ORDER BY  #proceeds.ndoc, #proceeds.idpro 
				 
INSERT INTO #trace(
					kind,
					ndoc,idinc,
					idpro,
					codice_cge,

					importoclassificazionemov,
					importo_siope,

					tipo_debito_siope,
					codice_ipa_ente_siope,
	
					tipo_documento_siope, -- ELETTRONICO o ANALOGICO
					identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
					tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
					/*Se cartacea*/
					codice_fiscale_emittente_siope,
					anno_emissione_fattura_siope ,
	
					/*ctDati_fattura_siope*/
					numero_fattura_siope, 
					natura_spesa_siope,
					data_scadenza_pagam_siope,
					motivo_scadenza_siope
				   )
SELECT 
					'CLASSIFICAZIONI_FATTURASIOPE',
					ndoc,
					idinc, idpro, 
					sortcode,
					SUM(importoclassificazionemov), 
					SUM(importo_siope),

					tipo_debito_siope,
					codice_ipa_ente_siope,
	
					tipo_documento_siope,
					identificativo_lotto_sdi_siope,
					tipo_documento_analogico_siope,
					/*Se cartacea*/
					codice_fiscale_emittente_siope,
					anno_emissione_fattura_siope,
	
					/*ctDati_fattura_siope*/
					numero_fattura_siope,
					natura_spesa_siope,
				CONVERT(VARCHAR(10),data_scadenza_pagam_siope,20),
					motivo_scadenza_siope
FROM #siope
 where opkind <> 'ANNULLO'
GROUP BY  ndoc, idpro, idinc, sortcode,
		tipo_debito_siope, codice_ipa_ente_siope,tipo_documento_siope,
		identificativo_lotto_sdi_siope,	tipo_documento_analogico_siope,	codice_fiscale_emittente_siope, anno_emissione_fattura_siope,
		numero_fattura_siope,		--importo_siope ,
		natura_spesa_siope,data_scadenza_pagam_siope, motivo_scadenza_siope
ORDER BY  ndoc, idpro, sortcode

INSERT INTO #trace(
				   kind,
				   ndoc,idinc,
				   idpro,
				   codice_cge,
				   importoclassificazionemov,
					tipo_debito_siope--,
					--codice_ipa_ente_siope,
	
					--tipo_documento_siope, -- ELETTRONICO o ANALOGICO
					--identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
					--tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
					--/*Se cartacea*/
					--codice_fiscale_emittente_siope,
					--anno_emissione_fattura_siope ,
	
					--/*ctDati_fattura_siope*/
					--numero_fattura_siope, 
					--natura_spesa_siope,
					--data_scadenza_pagam_siope,
					--motivo_scadenza_siope
				   )
SELECT 
				   'CLASSIFICAZIONI',
				   ndoc,
				   idinc, idpro, 
				   sortcode,
				   	importoclassificazionemov, 
					tipo_debito_siope--,
					--codice_ipa_ente_siope,
	
				--	tipo_documento_siope,
				--	identificativo_lotto_sdi_siope,
				--	tipo_documento_analogico_siope,
				--	/*Se cartacea*/
				--	codice_fiscale_emittente_siope,
				--	anno_emissione_fattura_siope,
	
				--	/*ctDati_fattura_siope*/
				--	numero_fattura_siope,
				--	natura_spesa_siope,
				--CONVERT(VARCHAR(10),data_scadenza_pagam_siope,20),
				--	motivo_scadenza_siope
FROM #siope
where flagnc='N' -- Prende le righe della classificazione Fattura o mov principale. 
	AND opkind <> 'ANNULLO'
ORDER BY  ndoc, idpro, sortcode

--INSERT INTO #trace(
--				   kind,
--				   ndoc,
--				   idpro, idinc,
--				   codice_cge,
--				   importo_siope,
--				   tipo_debito_siope,
--				   codice_ipa_ente_siope,
	
--					tipo_documento_siope, -- ELETTRONICO o ANALOGICO
--					identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
--					tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
--					/*Se cartacea*/
--					codice_fiscale_emittente_siope,
--					anno_emissione_fattura_siope ,
	
--					/*ctDati_fattura_siope*/
--					numero_fattura_siope, 
--					natura_spesa_siope
--				   )
--SELECT 
--				   'CLASSIFICAZIONI',
--				   ndoc,
--				   idpro, idinc,
--				   '9999',
--				   SUM(#siope.amount),
--				   	tipo_debito_siope,
--					codice_ipa_ente_siope,
	
--					tipo_documento_siope,
--					identificativo_lotto_sdi_siope,
--					tipo_documento_analogico_siope,
--					/*Se cartacea*/
--					codice_fiscale_emittente_siope,
--					anno_emissione_fattura_siope,
	
--					/*ctDati_fattura_siope*/
--					numero_fattura_siope,
--					--importo_siope ,
--					natura_spesa_siope
--FROM #siope
--WHERE opkind = 'ANNULLO'
--GROUP BY  ndoc, idpro, idinc, sortcode,
--		tipo_debito_siope, codice_ipa_ente_siope,tipo_documento_siope,
--		identificativo_lotto_sdi_siope,	tipo_documento_analogico_siope,	codice_fiscale_emittente_siope, anno_emissione_fattura_siope,
--		numero_fattura_siope,		--importo_siope ,
--		natura_spesa_siope 
--ORDER BY  ndoc, idpro, sortcode 
				 
INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpro, idinc,
				   importo_provvisorio,
				   numero_provvisorio
				   )
SELECT 
				   'SOSPESI',
				   ndoc,
				   idpro, idinc,
				   amount,
				   nbill    	
FROM #incomebill
ORDER BY  #incomebill.ndoc, #incomebill.idpro, #incomebill.idinc, #incomebill.nbill
				 
END

SELECT * from #trace

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


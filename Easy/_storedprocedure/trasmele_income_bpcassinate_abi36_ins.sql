
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


--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_bpcassinate_abi36_ins]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_bpcassinate_abi36_ins]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [trasmele_income_bpcassinate_abi36_ins]
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
SET @len_cf = 16

DECLARE @len_pi int
SET @len_pi = 11

DECLARE @len_pi_estera int
SET @len_pi_estera = 15

DECLARE @len_ABI int
SET @len_ABI = 5

DECLARE @len_CAB int
SET @len_CAB = 5

DECLARE @len_cc int
SET @len_cc = 12
 
 
DECLARE @ABI_codebps varchar(5)
SET @ABI_codebps = '05372'   -- 05372 ABI BANCA POPOLARE DEL CASSINATE

DECLARE @idtreasurer int
DECLARE @k int
SELECT @idtreasurer = idtreasurer, @k = kproceedstransmission
FROM proceedstransmission
WHERE yproceedstransmission = @y
	AND nproceedstransmission = @n


DECLARE @opkind varchar(20) -- Può assumere il valore INSERIMENTO (vedere specifiche tracciato)
SET @opkind = 'INSERIMENTO'
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
DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 8

DECLARE @cc_vincolato varchar(8)

DECLARE @CodiceStruttura varchar(16)
DECLARE @len_CodiceStruttura int
SET @len_CodiceStruttura = 16

SELECT 
	@cod_department = ISNULL(RTRIM(agencycodefortransmission),''),
	@cc = ISNULL(cc,''),
	@cc_vincolato = SUBSTRING(REPLICATE('0',@lenCC_vincolato),1,@lenCC_vincolato - 
					DATALENGTH(CONVERT(varchar(7),ISNULL(trasmcode,'0')))) + CONVERT(varchar(7),ISNULL(trasmcode,'0')),
	@cin = ISNULL(cin, '00'),
	@ABI_code = SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(idbank,'')))
	+ ISNULL(idbank,''),
	@CodiceStruttura = 
		CASE
		WHEN DATALENGTH(ISNULL(billcode,'')) <= @len_CodiceStruttura
		THEN ISNULL(billcode,'') + SUBSTRING(SPACE(@len_CodiceStruttura),1,@len_CodiceStruttura - DATALENGTH(ISNULL(billcode,'')))
		ELSE SUBSTRING(billcode,1,@len_CodiceStruttura)
		END
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


--DECLARE @len_agencycode int
--SET @len_agencycode = 20

CREATE TABLE #error (message varchar(400))

-- Inizio Sezione Controlli
DECLARE @message varchar(200)
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
IF(
(SELECT COUNT(*) FROM proceeds
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

---- CONTROLLO N. 2. Lunghezza del codice ente
--IF (DATALENGTH(@cod_department) > @len_agencycode)
--BEGIN
--	INSERT INTO #error
--	VALUES ('Il codice Ente inserito è superiore alla lunghezza massima fissata a '
--	+ CONVERT(varchar(2),@len_agencycode))
--END

-- CONTROLLO N. 3  Presenza tipologia dei creditori
INSERT INTO #error (message)
SELECT 'Il versante ' + ISNULL(R.title,'XXX') + ' con codice ' + CONVERT(varchar(6),R.idreg) + ' non ha una tipologia associata. E'' necessario inserirla'
FROM income I
JOIN incomelast IL
	ON I.idinc = IL.idinc
JOIN proceeds P
	ON P.kpro = IL.kpro
JOIN proceedstransmission T
	ON T.kproceedstransmission = P.kproceedstransmission
JOIN registry R
	ON R.idreg = I.idreg
WHERE R.idregistryclass IS NULL
	AND T.kproceedstransmission = @k

-- CONTROLLO N.4. Movimento di Entrata a Importo zero
INSERT INTO #error (message)
(SELECT 'Il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' ha importo pari a zero'
FROM proceedscommunicated
WHERE yproceedstransmission = @y
	AND nproceedstransmission = @n
	AND ISNULL(curramount,0) = 0)
	
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
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	idinc int,
	ymov int, 
	nmov int, 
	nphase tinyint, 
	phase varchar(50),
	curramount decimal(19,2),
	curramount_expense decimal(19,2),-- importo della spesa accessoria
	idreg int,
	income_adate datetime,
	proceeds_adate datetime,
	transmissiondate datetime,
	idpro int, 
	accountkind char(1),
	title_ver varchar(140),
	address_ver varchar(100),
	cap_ver varchar(16),
	location_ver varchar(116),
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
	txt varchar(200),
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
	ndocformatted varchar(7),
	idpro int,
	sortcode varchar(30),
	descr_sorting varchar(200),
	amount decimal(19,2),   -- importo classificato
	curramount decimal(19,2), -- importo reale incasso
	amount_expense decimal(19,2),  --- importo spesa accessoria
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodeincome varchar(15),
	flagpendingincome char(1)
)


-- Tabella delle informazioni aggiuntive richieste dall'Ente
CREATE TABLE #note
(
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	idpro int,
	nome_campo varchar(50),
	testo varchar(500)
)
        
DECLARE @incomeregphase	tinyint
SELECT @incomeregphase = incomeregphase FROM uniconfig


-- Leggo configurazione dell'applicazione dei contributi 
DECLARE @admintaxkind int
SELECT  @admintaxkind = (automanagekind & 0xf) FROM config WHERE ayear = @y

-- Riempimento della tabella degli incassi con i movimenti che sono presenti nella distinta di trasmissione
INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idinc, curramount,curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate,stamphandling,
	stamp_charge,exemption_stamp_motive, accountkind,
	title_ver, cf_ver, pi_ver, pi_ver_estera, proceedsdescr, fulfilled, idexp, 
	nbill, idpro,
	cupcodefin,cupcodeupb,cupcodeincome,tipo_riscossione, ccp_collection,
	destinazione, tipo_entrata,txt, npay, idpay ,flagpendingincome,flagcompensation
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.ypro, d.npro, e.idinc, i.curramount,
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
			THEN SPACE(@len_cf)
		ELSE SPACE(@len_cf)
	END,
-- Partita IVA
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
			THEN SPACE(@len_pi) 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
		THEN SUBSTRING(isnull(c.p_iva,''),1,@len_pi)
		ELSE SPACE(@len_pi) 
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
		when (( il.flag & 1)<> 0) then'REGOLARIZZAZIONE'
		else 'CASSA'
	END,
	c.ccp,
	CASE
		when  (( il.flag & 16)= 0) then 'LIBERA'
		else 'VINCOLATA'
	END,
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
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incomeyear y
	ON y.idinc = e.idinc
JOIN incometotal i
	ON i.idinc = e.idinc
JOIN proceeds d
	ON d.kpro = il.kpro
JOIN proceedstransmission t
	ON t.kproceedstransmission = d.kproceedstransmission
JOIN registry c
	ON c.idreg = e.idreg
JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
JOIN incomelink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
	ON RegPhaseELK.idchild = il.idinc
	AND RegPhaseELK.nlevel = @incomeregphase
JOIN income RegPhase			-- fase del Creditore
	ON RegPhase.idinc = RegPhaseELK.idparent 
JOIN upb U
	ON U.idupb = y.idupb
JOIN finlast 
	ON finlast.idfin = y.idfin
LEFT OUTER JOIN fin f
	ON f.idfin = d.idfin
LEFT OUTER JOIN stamphandling tb
	ON d.idstamphandling = tb.idstamphandling
LEFT OUTER JOIN expenselast el
	ON 	el.idexp = e.idpayment
LEFT OUTER JOIN expense sp
	ON el.idexp = sp.idexp
	AND  sp.idreg = e.idreg
LEFT OUTER JOIN expenseyear  ey
	ON el.idexp = ey.idexp
LEFT OUTER JOIN expensetotal et
	ON et.idexp = ey.idexp
LEFT OUTER JOIN payment pm
	ON el.kpay = pm.kpay
-- Contributi a carico dell'ente
--  se la configurazione dei contributi prevede un automatismo di spesa e uno di entrata su partita di giro
-- per gli automatismi dei contributi trasmetto anche il mandato  del corrispondente automatismo di spesa
 
LEFT OUTER JOIN expenselastview el1
	ON 	el1.idpayment = e.idpayment
	AND e.autokind = 4 -- Contributo
	AND el1.autokind = 4 
	AND el1.autocode  = e.autocode
	AND el1.idreg = e.idreg
	AND i.curramount = el1.curramount
	--AND @admintaxkind = 2 -- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro
WHERE t.kproceedstransmission = @k
 


---INSERISCO GLI INCASSI VIRTUALI OTTENUTI DAGLI INCASSI A REGOLARIZZAZIONE DI SOSPESI 
-- L'incasso reale sarà suddiviso in due tranches, uno a regolarizzazione di importo pari al sospeso e non collegato alla spesa
-- l'altro sarà un incasso virtuale  collegato alla spesa (in modo da ottenere complessivamente saldo zero ) e con idpro
-- fittizio pari a 2 (obblighiamo a fare le reversali singole in tali casi)

INSERT INTO #proceeds 
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idinc, curramount,curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate,stamphandling,
	stamp_charge,exemption_stamp_motive, accountkind,
	title_ver, cf_ver, pi_ver, pi_ver_estera, proceedsdescr, fulfilled, idexp, 
	nbill, idpro,
	cupcodefin,cupcodeupb,cupcodeincome,tipo_riscossione, ccp_collection,
	destinazione, tipo_entrata,txt, npay, idpay ,flagpendingincome,flagcompensation
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.ypro, d.npro, e.idinc, i.curramount,et.curramount,
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
			THEN SPACE(@len_cf)
		ELSE SPACE(@len_cf)
	END,
-- Partita IVA
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
			THEN SPACE(@len_pi) 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
		THEN SUBSTRING(isnull(c.p_iva,''),1,@len_pi)
		ELSE SPACE(@len_pi) 
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
	CASE
		when  (( il.flag & 16)= 0) then 'LIBERA'
		else 'VINCOLATA'
	END,
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
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incomeyear y
	ON y.idinc = e.idinc
JOIN incometotal i
	ON i.idinc = e.idinc
JOIN proceeds d
	ON d.kpro = il.kpro
JOIN proceedstransmission t
	ON t.kproceedstransmission = d.kproceedstransmission
JOIN registry c
	ON c.idreg = e.idreg
JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
JOIN incomelink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
	ON RegPhaseELK.idchild = il.idinc
	AND RegPhaseELK.nlevel = @incomeregphase
JOIN income RegPhase			-- fase del Creditore
	ON RegPhase.idinc = RegPhaseELK.idparent 
JOIN upb U
	ON U.idupb = y.idupb
JOIN finlast 
	ON finlast.idfin = y.idfin
LEFT OUTER JOIN fin f
	ON f.idfin = d.idfin
LEFT OUTER JOIN stamphandling tb
	ON d.idstamphandling = tb.idstamphandling
LEFT OUTER JOIN expenselast el
	ON 	el.idexp = e.idpayment
LEFT OUTER JOIN expense sp
	ON el.idexp = sp.idexp
	AND  sp.idreg = e.idreg
LEFT OUTER JOIN expenseyear  ey
	ON el.idexp = ey.idexp
LEFT OUTER JOIN expensetotal et
	ON et.idexp = ey.idexp
LEFT OUTER JOIN payment pm
	ON el.kpay = pm.kpay
WHERE t.kproceedstransmission = @k
AND ((il.flag&32) <>  0) 


UPDATE #proceeds SET CUP = ISNULL(cupcodeincome,  ISNULL(cupcodeupb, ISNULL(cupcodefin,''))) --Codice CUP

----------------------------------------------------------------
DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase

DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase


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

-- gli incassi su partita di giro per contributi sono a compensazione
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
	idpro int
)
-- Calcolo del saldo dei pagamenti principali associati per capire se stiamo trasmettendo 
-- incassi a compensazione
-- Leggo TUTTI gli incassi ritenute e recuperi sugli stessi pagamenti principali prima estratti 
INSERT INTO #tax
(
	idexp, idinc, ypro, npro,  curramount,	curramount_expense,
	ymov_income, nmov_income, idpro
)
SELECT
	p.idexp, e.idinc, di.ypro, di.npro,  
	ie.curramount, se.curramount, e.ymov, e.nmov, il.idpro
FROM #proceeds p
JOIN income e
	ON e.idpayment = p.idexp	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN expenselast el
	ON p.idexp = el.idexp
JOIN expensetotal se
	ON p.idexp = se.idexp
JOIN proceeds di
	ON di.kpro = il.kpro
WHERE e.nphase = @maxincomephase
AND e.idreg = p.idreg 
AND ie.ayear = @y


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
	idpro int
)



 
-- Inserimento delle trattenute (vengono inseriti i contributi c/amministrazione)
INSERT INTO #admintax
(
	idexp, idinc, ypro, npro,  amount, amount_expense,
	ymov_income, nmov_income, idpro
)	
	SELECT
	p.idexp, e.idinc, di.ypro, di.npro, iy.amount, sy.amount,
	e.ymov, e.nmov, il.idpro
FROM #proceeds p
JOIN income e
	ON e.idinc = p.idinc	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN incomeyear iy
	ON iy.idinc = ie.idinc
	AND iy.ayear = ie.ayear
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN expense s
	ON s.idpayment = e.idpayment
JOIN expenselast el
	ON s.idexp = el.idexp
JOIN expensetotal se
	ON s.idexp = se.idexp
JOIN expenseyear sy
	ON sy.idexp = se.idexp
	AND sy.ayear = se.ayear
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
	-- e movimento di entrata su partita di giro
			
UPDATE #proceeds SET flagcompensation = 'S' 
WHERE idinc in (select idinc FROM #admintax)

UPDATE #proceeds SET flagcompensation = 'S' 
WHERE idexp in (select idexp FROM #tax WHERE curramount_expense = 
							isnull( (select sum(curramount) FROM #tax T1 where #tax.idexp = T1.idexp),0))

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
	cap varchar(16),
	province varchar(2),
	nation varchar(65),
	iso_code varchar(2)
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
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation 
	ON geo_nation.idnation = registryaddress.idnation
LEFT OUTER JOIN geo_nation_agency
	ON geo_nation_agency.idnation = registryaddress.idnation 
	AND geo_nation_agency.idagency = 6 -- ente ISO			
	AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
	AND geo_nation_agency.version = 1
	AND geo_nation_agency.stop IS NULL
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
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idpro,
	sortcode, descr_sorting, curramount, amount, amount_expense, 
	cupcodefin, cupcodeupb, cupcodeincome,opkind,flagpendingincome
)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro, sorting.sortcode,sorting.description,  
	SUM(#proceeds.curramount), SUM(incomesorted.amount), SUM(#proceeds.curramount_expense),
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome, #proceeds.opkind,#proceeds.flagpendingincome
FROM #proceeds
JOIN incomesorted
	ON #proceeds.idinc = incomesorted.idinc
JOIN sorting
	ON sorting.idsor = incomesorted.idsor
WHERE sorting.idsorkind = @classSIOPE

GROUP BY
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro,sorting.sortcode,sorting.description,
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome,#proceeds.opkind,#proceeds.flagpendingincome
HAVING SUM(incomesorted.amount) <> 0


-- Riproporziono l'importo delle classificazioni SIOPE
-- Per idpro 1
-- vecchio importo classificato : nuovo importo classificato = importo corrente : importo corrente - spesa accessoria
-- nuovo importo classificato = vecchio importo classificato * (importo corrente -spesa accessoria) / importo corrente  
UPDATE #siope SET amount= isnull(#siope.amount,0) * (isnull(#siope.curramount,0) - isnull(#siope.amount_expense,0))/isnull(#siope.curramount,0) 
WHERE #siope.flagpendingincome  = 'S' and #siope.idpro = 1

--Per idpro 2
--vecchio importo classificato : nuovo importo classificato = importo corrente : spesa accessoria
--nuovo importo classificato = vecchio importo classificato * spesa accessoria / importo corrente
UPDATE #siope SET amount = isnull(#siope.amount,0) * (isnull(#siope.amount_expense,0)/isnull(#siope.curramount,0))
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
	#proceeds.idpro, ydoc, incomelast.nbill,   #proceeds.curramount
FROM #proceeds JOIN incomelast ON #proceeds.idinc = incomelast.idinc
WHERE   incomelast.nbill IS NOT NULL AND #proceeds.fulfilled = 'S'

	
 -- Bollette multiple
INSERT INTO  #incomebill
(	yproceedstransmission, nproceedstransmission, idinc,
	ydoc, ndoc, idpro, ybill,nbill, amount)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.idinc, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro, incomebill.ybill, incomebill.nbill,  incomebill.amount
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
DECLARE @data_ora_creazione_flusso  varchar(20)
SET   @data_ora_creazione_flusso = CONVERT(varchar(19),CONVERT(smalldatetime, GETDATE(), 126),126) 
DECLARE @codice_ente  varchar(16) -- da valorizzare con partita iva ente oppure codice fiscale
SET @codice_ente = @cf_dept
DECLARE @descrizione_ente varchar(150)
set @descrizione_ente = @desc_dept
DECLARE @codice_ente_BT  varchar(20)
SET @codice_ente_BT = @cod_department
DECLARE @riferimento_ente varchar(30)
DECLARE @esercizio int
SET @esercizio = @y -- esercizio finanziario
SET @codice_ABI_BT = @ABI_codebps
---------------------------------------------
----- fine testata flusso -------------------
---------------------------------------------

-- Tabella di output
CREATE TABLE #trace
(
	kind char(50), 
	---------------------------------------------
	---------- testata flusso -------------------
	---------------------------------------------
	codice_ABI_BT varchar(5),
	identificativo_flusso varchar(20),
	data_ora_creazione_flusso varchar(20),
	codice_ente varchar(16), -- partita iva o codice fiscale
	descrizione_ente varchar(150),
	codice_ente_BT varchar(20),
	riferimento_ente varchar(20),
	esercizio int,
	---------------------------------------------
	----------------- reversale -------------------
	---------------------------------------------
	ndoc int,
	tipo_operazione varchar(20),
	numero_reversale int,
	data_reversale varchar(20),
	importo_reversale decimal(19,2), 
	conto_evidenza varchar(10), -- mettere 1
	----------------------------------------------------
	-----------------info versante -----------------
	----------------------------------------------------
	idpro int,
	progressivo_versante int,
	importo_versante decimal(19,2),
	tipo_riscossione varchar(50),
	numero_ccp varchar(20),
	tipo_entrata varchar(20),
	destinazione varchar(20),
	---------------------------------------------
	----------------- classificazioni -----------
	---------------------------------------------
	codice_cge varchar(10),
	importo_siope decimal(19,2),
	---------------------------------------------
	----------------- bollo ---------------------
	---------------------------------------------
	assoggettamento_bollo varchar(50),
	causale_esenzione_bollo varchar(20),
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
	-----------------------------------------------
	---- dati_a_disposizione_ente_versante --------
	-----------------------------------------------
	dati_a_disposizione_ente_versante varchar(400),
	-----------------------------------------------
	---- dati_a_disposizione_ente_reversale -------
	-----------------------------------------------
	dati_a_disposizione_ente_reversale varchar(400)
	)
	---------------------------------------------
	---------- testata flusso -------------------
	---------------------------------------------
	INSERT INTO #trace(kind,
				   codice_ABI_BT,
				   identificativo_flusso,
				   data_ora_creazione_flusso,
				   codice_ente,
				   descrizione_ente,
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
				   dati_a_disposizione_ente_reversale
				   )		
SELECT 
				   'REVERSALE',
				   ndoc, 
				   @opkind,
				   ndoc,
				   CONVERT(VARCHAR(10),proceeds_adate,20),
				   SUM(curramount),
				   ISNULL(@cc_vincolato,'0000001'),
				   null
FROM #proceeds
GROUP BY  #proceeds.ndoc,opkind,proceeds_adate	
ORDER BY  #proceeds.ndoc
	   
INSERT INTO #trace(kind,
				   ndoc,
				   ----------------------------------------------
				   ------------------- info versante ------------
				   ----------------------------------------------
				   idpro,
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
				   idpro, 
				   idpro,
				   SUM(#proceeds.curramount),
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
				   stamphandling,
				   CASE   
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
GROUP BY #proceeds.ndoc, #proceeds.idpro, tipo_riscossione, ccp_collection,tipo_entrata,
destinazione, title_ver, address_ver, cap_ver, location_ver, province_ver,
iso_code_ver, pi_ver, cf_ver, proceedsdescr, stamphandling, stamp_charge,exemption_stamp_motive,
isnull(#proceeds.txt,'') , npay,  idpay,flagcompensation
ORDER BY #proceeds.ndoc, #proceeds.idpro
				 

INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpro,
				   codice_cge,
				   importo_siope
				   )
SELECT 
				   'CLASSIFICAZIONI',
				   ndoc,
				   idpro, 
				   sortcode,
				   SUM(#siope.amount)
FROM #siope
GROUP BY  ndoc, idpro, sortcode
ORDER BY  ndoc, idpro, sortcode


INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpro,
				   importo_provvisorio,
				   numero_provvisorio
				   )
SELECT 
				   'SOSPESI',
				   ndoc,
				   idpro, 
				   amount,
				   nbill    	
FROM #incomebill
ORDER BY  #incomebill.ndoc, #incomebill.idpro, #incomebill.nbill


SELECT * from #trace
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

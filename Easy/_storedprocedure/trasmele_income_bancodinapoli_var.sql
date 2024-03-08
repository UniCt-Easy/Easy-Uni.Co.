
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_bancodinapoli_var]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_bancodinapoli_var]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE  PROCEDURE [trasmele_income_bancodinapoli_var]
(
	@y int,
	@n int
)
AS BEGIN

/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */

-- Inizio Sezione dichiarativa
DECLARE @docversion varchar(5)
SET @docversion = '2.100'

DECLARE @n_pro_trans int
SET @n_pro_trans = 6

DECLARE @len_ndoc int
SET @len_ndoc = 7

DECLARE @len_amount int
SET @len_amount = 15

DECLARE @len_desc_dept int
SET @len_desc_dept = 30

DECLARE @len_address_dept int
SET @len_address_dept = 30

DECLARE @len_location_dept int
SET @len_location_dept = 35

DECLARE @len_idpay int
SET @len_idpay = 7

DECLARE @len_idpro int
SET @len_idpro = 7

DECLARE @len_registry_title int
SET @len_registry_title = 140

DECLARE @len_address int
SET @len_address = 30

DECLARE @len_cap int
SET @len_cap = 5

DECLARE @len_location int
SET @len_location = 30

DECLARE @len_province int
SET @len_province = 2

DECLARE @len_cf int
SET @len_cf = 16

DECLARE @len_pi int
SET @len_pi = 11

DECLARE @len_ABI int
SET @len_ABI = 5

DECLARE @len_CAB int
SET @len_CAB = 5

DECLARE @len_cc int
SET @len_cc = 12

DECLARE @len_desc_paymethod int
SET @len_desc_paymethod = 30

DECLARE @len_sortcode int
SET @len_sortcode = 10

DECLARE @len_desc_sort int
SET @len_desc_sort = 60

DECLARE @len_codiceoperatore int 
SET @len_codiceoperatore = 12

DECLARE @idtreasurer int
DECLARE @k int
SELECT @idtreasurer = idtreasurer, @k = kproceedstransmission
FROM proceedstransmission
WHERE yproceedstransmission = @y
	AND nproceedstransmission = @n

IF (@idtreasurer IS NULL) 
BEGIN
	SELECT @idtreasurer = MAX(idtreasurer) FROM treasurer WHERE flagdefault = 'S'
END
IF (@idtreasurer IS NULL) 
BEGIN
	SELECT @idtreasurer = MAX(idtreasurer) FROM treasurer
END

DECLARE @opkind char(2) -- Può assumere i valori I, A, S, N (vedere specifiche tracciato)
SET @opkind = 'I ' -- Attualmente può assumere solamente valore ' I'


DECLARE @len_desc_proceeds int
SET @len_desc_proceeds = 370

DECLARE @cod_department varchar(9) -- Codice dell'ente da esportare
DECLARE @cc varchar(28) -- Numero del Conto dell'ente presso l'istituto cassiere
DECLARE @cin char(2) -- Codice CIN
DECLARE @ABI_code varchar(5)
-- Fine Sezione Dichiarativa
DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 7

DECLARE @cc_vincolato varchar(7)

DECLARE @CodiceStruttura varchar(16)
DECLARE @len_CodiceStruttura int
SET @len_CodiceStruttura = 16

SELECT 
	@cod_department = ISNULL(agencycodefortransmission,''),
	@cc = ISNULL(cc,''),
	--@cc_vincolato = SUBSTRING(REPLICATE('0',@len_cc), 1, @len_cc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,''),
	@cc_vincolato = SUBSTRING( REPLICATE(' ',7), 1, @lenCC_vincolato- DATALENGTH(SUBSTRING(ISNULL(trasmcode,''), DATALENGTH(ISNULL(trasmcode,''))-6,@lenCC_vincolato))) + substring(ISNULL(trasmcode,''), DATALENGTH(ISNULL(trasmcode,''))-6,@lenCC_vincolato),
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
DECLARE @desc_dept varchar(30)
DECLARE @address_dept varchar(30)
DECLARE @location_dept varchar(35)
SELECT @cf_dept = ISNULL(cf,'') + SUBSTRING(SPACE(@len_cf),1,@len_cf - DATALENGTH(ISNULL(cf,''))) ,
@desc_dept = 
CASE
	WHEN DATALENGTH(ISNULL(agencyname,'')) <= @len_desc_dept
	THEN ISNULL(agencyname,'') + SUBSTRING(SPACE(@len_desc_dept),1,@len_desc_dept - DATALENGTH(ISNULL(agencyname,'')))
	ELSE SUBSTRING(agencyname,1,@len_desc_dept)
END,
@address_dept =
CASE 
	WHEN DATALENGTH(ISNULL(address1,'')) <= @len_address_dept
	THEN ISNULL(address1,'') + SUBSTRING(SPACE(@len_address_dept),1,@len_address_dept - DATALENGTH(ISNULL(address1,'')))
	ELSE SUBSTRING(address1,1,@len_address_dept)
END,
@location_dept = 
CASE 
	WHEN DATALENGTH(ISNULL(location,'')) <= @len_location_dept
	THEN ISNULL(location,'') + SUBSTRING(SPACE(@len_location_dept),1,@len_location_dept - DATALENGTH(ISNULL(location,'')))
	ELSE SUBSTRING(location,1,@len_location_dept)
END
FROM license

DECLARE @len_agencycode int
SET @len_agencycode = 7

CREATE TABLE #error (message varchar(400))

IF (DATALENGTH(@cod_department) < @len_agencycode) 
BEGIN
	SET @cod_department = @cod_department + SUBSTRING(SPACE(@len_agencycode),1,@len_agencycode - DATALENGTH(@cod_department))
END

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
JOIN incomelast IL
	ON I.idinc = IL.idinc
JOIN incomevar IV
	ON IV.idinc = IL.idinc
JOIN proceeds P
	ON P.kpro = IL.kpro
JOIN proceedstransmission T
	ON T.kproceedstransmission = P.kproceedstransmission
JOIN registry R
	ON R.idreg = I.idreg
WHERE R.idregistryclass IS NULL
	AND IV.kproceedstransmission = @k

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
-- Fine Sezione Controlli

-- Tabella di output
CREATE TABLE #trace
(
	y int,
	n int,
	ndoc int,
	nrow int,
	out_str varchar(2193) COLLATE SQL_Latin1_General_CP1_CI_AS
)

-- Tabella degli incassi
CREATE TABLE #proceeds
(
	opkind char(2), -- Può assumere i valori A o VB
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idinc int,
	curramount decimal(19,2),
	curramount_expense decimal(19,2), -- importo della spesa accessoria
	idreg int,
	income_adate datetime,
	proceeds_adate datetime,
	transmissiondate datetime,
	idpro int, 
	accountkind char(1),
	title_ver varchar(140),
	address_ver varchar(30),
	cap_ver varchar(5),
	location_ver varchar(30),
	province_ver varchar(2),
	pi_ver varchar(11),
	pi_ver_estera varchar(15),
	cf_ver varchar(16),
	free_stamp char(1),
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
	originalamount decimal(19,2),
	txt varchar(200),
	flagpendingincome char(1)
)

-- ATTENZIONE! Bisogna importare tutti i mov. di spesa associati ai mandati associati alle reversali
-- che stiamo processando in quanto bisogna assegnare il progressivo del beneficiario che deve necessariamente
-- corrispondere a quello calcolato nella SP inerente i pagamenti. Diversamente si ha che i riferimenti verrebbero
-- ricalcolati in modo differente. C'è un problema, nel caso in cui si decida di inserire successivamente
-- dei mov. di spesa nel mandato, in tal caso probabilmente il progressivo beneficiario può cambiare.
CREATE TABLE #payment
(
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idexp varchar(72),
	curramount decimal(19,2),
	idreg int,
	idpay int,
	idpaymethodEASY int,
	idpaymethodTRS varchar(20),
	desc_paymethod varchar(30),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25),
	cin varchar(2),
	iddeputy int,
	flagpendingincome char(1)
)

-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int, 
	ndocformatted varchar(7),
	idpro int,
	sortcode varchar(30),
	descr_sorting varchar(60),
	curramount decimal(19,2),  --- importo reale incasso
	amount decimal(19,2),
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
	ndocformatted varchar(7),
	idpro int,
	nome_campo varchar(50),
	testo varchar(200)
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
	totalann char(1),
	varsiope char(1)
)

--- 10 VARIAZIONI DI ANNULLAMENTO PARZIALE
--- 11 VARIAZIONI DI ANNULLAMENTO TOTALE
--- 22 VARIAZIONI DATI = SIOPE

INSERT INTO #proceedsvar
(
	idinc, idpro, amount, autokind, kpro, varsiope
)
SELECT
	s.idinc, el.idpro, v.amount, v.autokind, d.kpro,
	CASE v.autokind WHEN 22 THEN 'S' ELSE 'N' END
FROM incomevar v
JOIN income s
	ON v.idinc = s.idinc
JOIN incomelast el
	ON S.idinc = el.idinc
JOIN proceeds d
	ON d.kpro = el.kpro
JOIN proceedstransmission t
	ON t.kproceedstransmission = d.kproceedstransmission
WHERE v.kproceedstransmission = @k


-- Riempimento della tabella degli incassi con i movimenti che sono presenti nella distinta di trasmissione
INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idinc, curramount,curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate, free_stamp, accountkind,
	title_ver, cf_ver, pi_ver, proceedsdescr, fulfilled, idexp, 
	nbill, idpro, cu, codefin,	CR,
	cupcodefin,cupcodeupb,cupcodeincome,txt ,flagpendingincome
)
SELECT
	@y, @n, d.ypro, d.npro, e.idinc, i.curramount,
	CASE
		WHEN ((il.flag&32) <> 0) THEN et.curramount
		ELSE 0
	END,
	e.idreg, e.adate, d.adate, t.transmissiondate, 
	'S',
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'F'
		ELSE 'I'
	END,
	ISNULL(c.title,'') + SUBSTRING(SPACE(@len_registry_title),1,@len_registry_title - DATALENGTH(c.title)),
	CASE
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
			THEN c.cf + SUBSTRING(SPACE(@len_cf),1,@len_cf - DATALENGTH(c.cf))
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
			THEN REPLICATE('9',@len_cf)
		ELSE SPACE(@len_cf)
	END,
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
		-- Se è straniera la copiamo tale e quale. Se è straniera non dobbiamo manipolarla aggiungendo zeri iniziali.
		-- Quando verrrà inserita nel Record PR verrà interrogata nuovamente.		
		THEN c.p_iva 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
		THEN SUBSTRING(REPLICATE('0',@len_pi),1,@len_pi - 
				ISNULL(DATALENGTH(SUBSTRING(isnull(c.p_iva,''),1,@len_pi)),0)) 
				+ SUBSTRING(isnull(c.p_iva,''),1,@len_pi)
		ELSE REPLICATE('0',@len_pi)
	END,
	-- Causale riscossione
	--ISNULL(e.description,'') + SUBSTRING(SPACE(@len_desc_proceeds),1,@len_desc_proceeds - ISNULL(DATALENGTH(e.description),0)),
	ISNULL(e.description,'') ,
	--ISNULL(e.fulfilled,'N'),
	CASE
		when (( il.flag & 1)=1) then 'S'
		else 'N'
	End,
	CASE
		WHEN ((il.flag&32) <> 0) THEN null
		ELSE e.idpayment
	END ,
	ISNULL(REPLICATE('0',7-DATALENGTH(CONVERT(varchar(7),il.nbill))) + CONVERT(varchar(7),il.nbill),REPLICATE('0',7)),
	il.idpro,
	CASE
		WHEN DATALENGTH(ISNULL(d.cu,'')) <= @len_codiceoperatore
		THEN ISNULL(d.cu,'') + SPACE(@len_codiceoperatore - DATALENGTH(ISNULL(d.cu, '')))
		ELSE SUBSTRING(d.cu, 1, @len_codiceoperatore)
	END,
	CASE
		WHEN ((d.flag&3)<> 0) THEN 	f.codefin
		WHEN ((d.flag&4)<> 0) THEN 	'0000000'
	END,
	CASE
		WHEN ((d.flag&1)<> 0) THEN 'Competenza'
		WHEN ((d.flag&2)<> 0) THEN '   Residuo'
		WHEN ((d.flag&4)<> 0) THEN REPLICATE(' ',10)
	END,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	ltrim(rtrim(substring(d.txt, 1, 200))),
	CASE
		WHEN ((il.flag&32) <> 0) THEN 'S'
		ELSE 'N'
	END 
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
LEFT OUTER JOIN expenselast el
	ON 	el.idexp = e.idpayment
LEFT OUTER JOIN expense sp
	ON el.idexp = sp.idexp
	AND  sp.idreg = e.idreg
LEFT OUTER JOIN expenseyear  ey
	ON el.idexp = ey.idexp
LEFT OUTER JOIN expensetotal et
	ON et.idexp = ey.idexp
WHERE d.kpro IN (SELECT kpro FROM #proceedsvar) --> Solo le reversali variati di Siope o annullati
	AND (
		-- Per gli annulli prendiamo solo i SUB non esitati
		( (select count(*) FROM #proceedsvar where varsiope = 'N')>=1 AND ISNULL((SELECT SUM(amount) FROM banktransaction WHERE yban = @y AND idinc = il.idinc),0) = 0 )
		OR
		-- Per le var siope tutti i SUB esitati e non, purchè abbiano subito della var. Siope
		(select count(*) FROM #proceedsvar where varsiope = 'S')>=1 AND il.idinc in (select idinc FROM #proceedsvar)
		)

---INSERISCO GLI INCASSI VIRTUALI OTTENUTI DAGLI INCASSI A REGOLARIZZAZIONE DI SOSPESI 
-- L'incasso reale sarà suddiviso in due tranches, uno di importo parti al sospeso e non collegato alla spesa
-- l'altro sarà un incasso virtuale  collegato alla spesa (in modo da ottenere complessivamente saldo zero ) e con idpro
-- fittizio pari a 2 (obblighiamo a fare le reversali singole in tali casi)
INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idinc, curramount,curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate, free_stamp, accountkind,
	title_ver, cf_ver, pi_ver, pi_ver_estera, proceedsdescr, fulfilled, idexp, 
	nbill, idpro, cu, codefin,	CR,
	cupcodefin,cupcodeupb,cupcodeincome, txt,flagpendingincome
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.ypro, d.npro, e.idinc, i.curramount,
	et.curramount,
	e.idreg, e.adate, d.adate, t.transmissiondate, 
	'S',
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'F'
		ELSE 'I'
	END,
	ISNULL(c.title,'') + SUBSTRING(SPACE(@len_registry_title),1,@len_registry_title - DATALENGTH(c.title)),
	CASE
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
			THEN c.cf + SUBSTRING(SPACE(@len_cf),1,@len_cf - DATALENGTH(c.cf))
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
			THEN REPLICATE('9',@len_cf)
		ELSE SPACE(@len_cf)
	END,
-- Partita IVA
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
			THEN REPLICATE('9',@len_pi) ---> Se estera la valorizziamo con undici cifre uguali a 9.
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
		THEN SUBSTRING(REPLICATE('0',@len_pi),1,@len_pi - 
				ISNULL(DATALENGTH(SUBSTRING(isnull(c.p_iva,''),1,@len_pi)),0)) 
				+ SUBSTRING(isnull(c.p_iva,''),1,@len_pi)
		ELSE REPLICATE('0',@len_pi)
	END,
-- Partita Iva estera
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL AND ASCII(SUBSTRING(c.p_iva,1,1)) NOT BETWEEN 48 AND 57
		-- Se è straniera la copiamo tale e quale. Quando verrrà inserita nel Record MP verrà interrogata nuovamente.		
		THEN c.p_iva
		ELSE NULL
	END,
	-- Causale riscossione
	--ISNULL(e.description,'') + SUBSTRING(SPACE(@len_desc_proceeds),1,@len_desc_proceeds - ISNULL(DATALENGTH(e.description),0)),
	ISNULL(e.description,'') ,
	--ISNULL(e.fulfilled,'N'),
	CASE
		when (( il.flag & 1)=1) then 'S'
		else 'N'
	End,
	e.idpayment,
	--ISNULL(REPLICATE('0',7-DATALENGTH(CONVERT(varchar(7),il.nbill))) + CONVERT(varchar(7),il.nbill),REPLICATE('0',7)),
	null, --il.nbill, 
	il.idpro + 1,  -- Per gli incassi virtuali associo id fittizio pari a 2
	CASE
		WHEN DATALENGTH(ISNULL(d.cu,'')) <= @len_codiceoperatore
		THEN ISNULL(d.cu,'') + SPACE(@len_codiceoperatore - DATALENGTH(ISNULL(d.cu, '')))
		ELSE SUBSTRING(d.cu, 1, @len_codiceoperatore)
	END,
	CASE
		WHEN ((d.flag&3)<> 0) THEN 	f.codefin
		WHEN ((d.flag&4)<> 0) THEN 	'0000000'
	END,
	CASE
		WHEN ((d.flag&1)<> 0) THEN 'Competenza'
		WHEN ((d.flag&2)<> 0) THEN '   Residuo'
		WHEN ((d.flag&4)<> 0) THEN REPLICATE(' ',10)
	END,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	ltrim(rtrim(substring(d.txt, 1, 150))),
	CASE
		WHEN ((il.flag&32) <> 0) THEN 'S'
		ELSE 'N'
	END 
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
LEFT OUTER JOIN expenselast el
	ON 	el.idexp = e.idpayment
LEFT OUTER JOIN expense sp
	ON el.idexp = sp.idexp
	AND  sp.idreg = e.idreg
LEFT OUTER JOIN expenseyear  ey
	ON el.idexp = ey.idexp
LEFT OUTER JOIN expensetotal et
	ON et.idexp = ey.idexp
LEFT OUTER JOIN fin f
	ON f.idfin = d.idfin
WHERE ((il.flag&32) <> 0) 
AND  d.kpro IN (SELECT kpro FROM #proceedsvar) --> Solo le reversali variati di Siope o annullati
	AND (
		-- Per gli annulli prendiamo solo i SUB non esitati
		( (select count(*) FROM #proceedsvar where varsiope = 'N')>=1 AND ISNULL((SELECT SUM(amount) FROM banktransaction WHERE yban = @y AND idinc = il.idinc),0) = 0 )
		OR
		-- Per le var siope tutti i SUB esitati e non, purchè abbiano subito della var. Siope
		(select count(*) FROM #proceedsvar where varsiope = 'S')>=1 AND il.idinc in (select idinc FROM #proceedsvar)
		)

UPDATE #proceeds SET opkind = (SELECT  
							Case 
								when ((select count(*) from #proceedsvar where #proceedsvar.varsiope = 'S'/* and idinc = #proceeds.idinc*/)>=1)
									then 'VB'
								else 'A'
							End
							)

DECLARE @max_count_idpro int
SET @max_count_idpro   = 500

INSERT INTO #error (message)
SELECT 'La reversale d''incasso n° ' + CONVERT(varchar(6),p.ndoc) + '/' + CONVERT(varchar(4),p.ydoc) 
+ ' contiene un numero di versanti superiore a ' + CONVERT(varchar(4),@max_count_idpro)
+ ' Si consiglia di controllare gli incassi contenuti nella reversale.'
FROM #proceeds p
WHERE p.opkind = 'VB'
GROUP BY p.ydoc, p.ndoc
HAVING COUNT(p.idpro) > @max_count_idpro

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Calcoliamo l'importo originale dei dei sub annullati come : curramount + le var inserite nella distinta in oggetto.
UPDATE #proceeds SET originalamount = isnull(curramount,0) 
									- ISNULL((select sum(incomevar.amount)  -- Le var. sono negative, quindi col meno d'avanti, cambio il segno.
									FROM incomevar
									join proceedstransmission 
									ON incomevar.kproceedstransmission = proceedstransmission.kproceedstransmission
									Where proceedstransmission.yproceedstransmission = @y
										and proceedstransmission.nproceedstransmission = @n
										and incomevar.idinc = #proceeds.idinc),0)
				

-- Valorizza codice di bilancio --
DECLARE @len_codifica_bilancio int 
SET @len_codifica_bilancio = 7

DECLARE @minoplevel tinyint

SELECT  @minoplevel = min(nlevel)
FROM 	finlevel
WHERE 	ayear = @y and flag&2 <> 0

DECLARE @lencod_lev int
SET  @lencod_lev = (SELECT  SUM (flag / 256) 
				FROM finlevel
				WHERE ayear = @y AND 	nlevel <= @minoplevel )

IF ( @lencod_lev <= 7 )
BEGIN
	UPDATE #proceeds SET codefin = SUBSTRING(REPLICATE('0',@len_codifica_bilancio),1,@len_codifica_bilancio - DATALENGTH(CONVERT(varchar(7),codefin))) + CONVERT(varchar(7),codefin)
END
ELSE
BEGIN
	UPDATE #proceeds SET codefin = REPLICATE('0',@len_codifica_bilancio)
END

UPDATE #proceeds SET codefin = REPLICATE('0',@len_codifica_bilancio) WHERE ( ISNUMERIC(ISNULL(codefin,'')) <> 1 )


UPDATE #proceeds SET CUP = ISNULL(cupcodeincome,  ISNULL(cupcodeupb, ISNULL(cupcodefin,''))) --Codice CUP

--  Controllo sui  CUP 
 
INSERT INTO #error (message)
SELECT DISTINCT 'La reversale di incasso n° ' + CONVERT(varchar(6),p.ndoc) + '/' + CONVERT(varchar(4),p.ydoc) 
+ ' contiene l''incasso ' 
+ CONVERT(varchar(6),i.nmov) + '/' + CONVERT(varchar(4),i.ymov)  + ' raggruppato con altri ' 
+ ' che tuttavia sono ora distinguibili per il CUP. ' 
+ ' Si consiglia di controllare i codici CUP assegnati e di salvare nuovamente la reversale per correggere l''errore. ' 
FROM #proceeds p
JOIN incomeview i on  p.idinc = i.idinc
JOIN #proceeds p2
	ON  p.ydoc = p2.ydoc
	AND p.ndoc = p2.ndoc
	AND p.idpro = p2.idpro
WHERE  (isnull(p.CUP,'') <> isnull(p2.CUP,'') )
AND   (p.opkind <> 'A' )
----------------------------------------------------------------

-- Calcolo del campo ndocformatted
UPDATE #proceeds
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),ndoc))) +
CONVERT(varchar(7),ndoc)

DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase

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
	nation varchar(65)
)

INSERT INTO #address
(
	idaddresskind,
	idreg,
	address,
	location,
	cap,
	province,
	nation
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
	END
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation 
	ON geo_nation.idnation = registryaddress.idnation
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
	(SELECT
	CASE
		WHEN DATALENGTH(address) <= @len_address OR address IS NULL
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@len_address),1,@len_address - ISNULL(DATALENGTH(address),0))
		ELSE SUBSTRING(address,1,@len_address)
	END
	FROM #address
	WHERE #proceeds.idreg = #address.idreg),
cap_ver =
	(SELECT
	CASE
		WHEN DATALENGTH(cap) <= @len_cap OR cap IS NULL
		THEN SUBSTRING(REPLICATE('0',@len_cap),1,@len_cap - ISNULL(DATALENGTH(cap),0)) + ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #proceeds.idreg = #address.idreg),
location_ver =
	(SELECT
	CASE
		WHEN DATALENGTH(location) <= @len_location OR location IS NULL
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@len_location),1,@len_location - ISNULL(DATALENGTH(location),0))
		ELSE SUBSTRING(location,1,@len_location)
	END
	FROM #address
	WHERE #proceeds.idreg = #address.idreg),
province_ver =
	(SELECT
	CASE
		WHEN DATALENGTH(province) <= @len_province OR province IS NULL
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@len_province),1,@len_province - ISNULL(DATALENGTH(province),0))
		ELSE SUBSTRING(province,1,@len_province)
	END
FROM #address
WHERE #proceeds.idreg = #address.idreg)

-- Aggiornamento dei campi inerenti l'address nel caso in cui non esista un address per il versante
UPDATE #proceeds
SET address_ver = SPACE(@len_address)
WHERE #proceeds.address_ver IS NULL

UPDATE #proceeds
SET cap_ver = SPACE(@len_cap)
WHERE #proceeds.cap_ver IS NULL

UPDATE #proceeds
SET location_ver = SPACE(@len_location)
WHERE #proceeds.location_ver IS NULL

UPDATE #proceeds
SET province_ver = SPACE(@len_province)
WHERE #proceeds.province_ver IS NULL

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

-- Riempimento della tabella con i dati della classificazione SIOPE
DECLARE @npos int
DECLARE @codeclassSIOPE varchar(20)

SELECT  @codeclassSIOPE  =  
CASE  
	WHEN  (@y<= 2006) THEN  'SIOPE'
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  '07E_SIOPE'
	ELSE   'SIOPE_E_18'
END

SELECT  @npos  =  
CASE  
	WHEN  (@y<= 2006) THEN  2
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  1
	ELSE   1
END

DECLARE @classSIOPE int
SELECT @classSIOPE = idsorkind FROM sortingkind WHERE codesorkind = @codeclassSIOPE

-- Riempimento della tabella delle classificazioni SIOPE
INSERT INTO #siope
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro,
	sortcode, descr_sorting,  curramount, amount, amount_expense, 
	cupcodefin, cupcodeupb, cupcodeincome,flagpendingincome
)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc, #proceeds.ndocformatted,
	#proceeds.idpro, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)),
	SUBSTRING(sorting.description,1,@len_desc_sort), 
	SUM(#proceeds.curramount), SUM(incomesorted.amount),SUM(#proceeds.curramount_expense),
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome,
	#proceeds.flagpendingincome
FROM #proceeds
JOIN incomesorted
	ON #proceeds.idinc = incomesorted.idinc
JOIN sorting
	ON sorting.idsor = incomesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
	AND #proceeds.idinc in (select idinc FROM #proceedsvar where varsiope = 'S')
GROUP BY
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc, #proceeds.ndocformatted,
	#proceeds.idpro, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)),
	SUBSTRING(sorting.description,1,@len_desc_sort),
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome,
	flagpendingincome

-- Riproporziono l'importo delle classificazioni SIOPE
-- Per idpro 1
-- vecchio importo classificato : nuovo importo classificato = importo corrente : importo corrente - spesa accessoria
-- nuovo importo classificato = vecchio importo classificato * (importo corrente -spesa accessoria) / importocorrente
UPDATE #siope SET #siope.amount= isnull(#siope.amount,0) * ((isnull(#siope.curramount,0) - isnull(#siope.amount_expense,0))/isnull(#siope.curramount,0))
WHERE #siope.flagpendingincome  = 'S' and #siope.idpro = 1

--Per idpro 2
--vecchio importo classificato : nuovo importo classificato = importo corrente : spesa accessoria
--nuovo importo classificato = vecchio importo classificato * spesa accessoria / importo corrente
UPDATE #siope SET amount= isnull(#siope.amount,0) * (isnull(#siope.amount_expense,0)/isnull(#siope.curramount,0))
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

-- CONTROLLO N. 4 Il numero di classificazioni non può superare il limite massimo per ogni beneficiario
--DECLARE @max_sort_number int
--SET @max_sort_number = 15

--INSERT INTO #error (message)
--(SELECT 'La reversale n. ' + CONVERT(varchar(6),ndoc) + '/' + CONVERT(varchar(4),ydoc)
--+ ' contiene più di ' + CONVERT(varchar(2),@max_sort_number) + ' classificazioni SIOPE'
--FROM #siope WHERE
--	(SELECT COUNT(*) FROM #siope s2
--	WHERE s2.yproceedstransmission = #siope.yproceedstransmission
--		AND s2.nproceedstransmission = #siope.nproceedstransmission
--		AND s2.ydoc = #siope.ydoc
--		AND s2.ndoc = #siope.ndoc
--		AND s2.idpro = #siope.idpro)
--> @max_sort_number)

--IF (SELECT COUNT(*) FROM #error) > 0
--BEGIN
--	SELECT * FROM #error
--	RETURN
--END



-- Inserimento delle note per il record DM
INSERT INTO #note (yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro, nome_campo, testo)
SELECT  DISTINCT
yproceedstransmission, 
nproceedstransmission, 
ydoc, 
ndoc,
ndocformatted,
1,  -- lo valorizzo solo per il primo sub
[dbo].getstringformatted_r('Note', 50),
[dbo].getstringformatted_r(txt, 200) 
FROM #proceeds
WHERE ltrim(rtrim(#proceeds.txt)) <> ''
GROUP BY yproceedstransmission, nproceedstransmission, ndoc, idpro, 
		 ydoc, ndocformatted, txt



-- Gestione Mandati Associati
-- (a) Se l'incasso si riferisce a una ritenuta c/beneficiario
INSERT INTO #payment
(
	ydoc, ndoc, idexp, curramount, idreg,
	idpaymethodEASY, idpaymethodTRS, ABI, CAB, cc, cin, iddeputy, idpay
)
SELECT 
	s.ymov, d.npay, s.idexp, i.curramount, s.idreg,
	el.idpaymethod, m.methodbankcode,
	SUBSTRING(ISNULL(el.idbank,''),1,5), SUBSTRING(ISNULL(el.idcab,''),1,5),
	SUBSTRING(ISNULL(el.cc,''),1,20),  
	SUBSTRING(ISNULL(el.cin,''),1,2), 
	el.iddeputy,
	el.idpay
FROM expense s
JOIN expenselast el
	ON s.idexp = el.idexp
JOIN expensetotal i
	ON s.idexp = i.idexp
JOIN payment d
	ON el.kpay = d.kpay
JOIN paymethod m
	ON m.idpaymethod = el.idpaymethod
WHERE d.npay IN
	(SELECT DISTINCT payment.npay
		FROM expense
		JOIN expenselast
			ON expense.idexp = expenselast.idexp 
		JOIN payment
			ON payment.kpay = expenselast.kpay
		JOIN income
			ON expense.idexp = income.idpayment
			AND expense.idreg = income.idreg
		JOIN incomelast
			ON incomelast.idinc =income.idinc
		JOIN proceeds
			ON proceeds.kpro = incomelast.kpro
		JOIN proceedstransmission
			ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
		WHERE proceedstransmission.kproceedstransmission = @k)
AND s.ymov = @y
AND i.ayear = @y

-- Gestione Mandati Associati
-- (b) Se l'incasso si riferisce a un contributo c/ente, prendo il mandato su partita di giro
-- ad esso associato

INSERT INTO #payment
(
	ydoc, ndoc, idexp, curramount, idreg,
	idpaymethodEASY, idpaymethodTRS, ABI, CAB, cc, cin, iddeputy, idpay
)
SELECT 
	s.ymov, d.npay, s.idexp, i.curramount, s.idreg,
	el.idpaymethod, m.methodbankcode,
	ISNULL(el.idbank,''), ISNULL(el.idcab,''),ISNULL(el.cc,''),ISNULL(el.cin,' '), el.iddeputy,
	el.idpay
FROM expense s
JOIN expenselast el
	ON s.idexp = el.idexp
JOIN expensetotal i
	ON s.idexp = i.idexp
JOIN payment d
	ON el.kpay = d.kpay
JOIN paymethod m
	ON m.idpaymethod = el.idpaymethod
WHERE d.npay IN
	(SELECT DISTINCT payment.npay
		FROM expense
		JOIN expenselast
			ON expense.idexp = expenselast.idexp 
		JOIN payment
			ON payment.kpay = expenselast.kpay
		JOIN income
			ON expense.idpayment = income.idpayment
			AND expense.idreg = income.idreg
			AND expense.autocode  = income.autocode -- taxcode (es. IRAP)
			AND income.autokind = 4 -- Automatismo applicazione Contributo
			AND expense.autokind = 4 
		JOIN incomelast
			ON incomelast.idinc =income.idinc
		JOIN proceeds
			ON proceeds.kpro = incomelast.kpro
		JOIN proceedstransmission
			ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
		WHERE proceedstransmission.kproceedstransmission = @k)
AND s.ymov = @y
AND i.ayear = @y


UPDATE #payment
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),ndoc))) +
CONVERT(varchar(7),ndoc)


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

-- Fine Gestione Mandati associati
-- La tabella di rif. della banca porta un'unica descrizione "Incasso per Cassa"
DECLARE @descr_Encashment varchar(30)
SET @descr_Encashment = 'Incasso per Cassa' + SPACE(13)
DECLARE @code_Encashment varchar(2)
SET @code_Encashment = '51'

-- Inserimento di tutte le testate di flusso che corrispondono alle distinte di trasmissione
-- RECORD TF
INSERT INTO #trace (y, n, ndoc, nrow, out_str)
SELECT
	yproceedstransmission, nproceedstransmission, 0, 0,
	'TF' + @ABI_code + SUBSTRING('000000',1,@n_pro_trans - DATALENGTH(CONVERT(varchar(6),nproceedstransmission))) +
	CONVERT(varchar(6),nproceedstransmission) +
	CONVERT(varchar(19),CONVERT(smalldatetime, GETDATE(), 126),126) +
	CONVERT(varchar(4),@y) + @cod_department + @docversion
FROM proceedstransmission
WHERE kproceedstransmission = @k

-- RECORD TR
INSERT INTO #trace (y, n, ndoc, nrow, out_str)
SELECT
	yproceedstransmission, nproceedstransmission, ndoc, 1,
	-- Tipo Record
	'TR' +
	-- Codice Ente
	@cod_department +
	-- Esercizio
	CONVERT(varchar(4), ydoc) +
	-- Numero Documento (default a zero)
	'0000000' +
	-- Codice Funzione
	opkind +
	-- Numero Reversale
	ndocformatted +
	-- Data Reversale
	CONVERT(varchar(4),YEAR(proceeds_adate)) + '-' +
	SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(proceeds_adate)))) +
	CONVERT(varchar(2),MONTH(proceeds_adate)) + '-' +
	SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(proceeds_adate)))) +
	CONVERT(varchar(2),DAY(proceeds_adate)) +
	-- amount Reversale
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
	-- Tipo Contabilità
	'O' +
	-- Tipo Entrata
	accountkind +
	-- Destinazione:Numero del conto Libero o Vincolato intrattenuto presso il Tesoriere
	@cc_vincolato +

	-- Codifica Bilancio 
	codefin +
	--	(Articolo) + Voce Economica
	REPLICATE('0',7) +
	-- Descrizione Codifica 
	SPACE(30) +
	-- Gestione
	CR +
	-- Anno Residuo
	REPLICATE('0',4) +
	-- Filler EX Testata Classificazione
	SPACE(3) +
	-- Codice ABI
	@ABI_code +
	-- Codice Fiscale Ente
	@cf_dept +
	-- Descrizione Ente
	@desc_dept +
	-- address Ente
	@address_dept +
	-- Località Ente
	@location_dept +
	-- Codice Ente
	@cod_department +
	-- Esercizio Emissione Reversale
	CONVERT(varchar(4),ydoc) +
	-- Codice Struttura 
	@CodiceStruttura + 
	--Progressivo Reversale Struttura 
	SPACE(6) +
	-- Gestione SIOPE
	SPACE(70)
FROM #proceeds
GROUP BY opkind, yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, proceeds_adate, accountkind, codefin, CR

DECLARE @nota_pivaestera varchar(50)
SET @nota_pivaestera = 'P. Iva Estera'

-- RECORD PR
INSERT INTO #trace (y, n, ndoc, nrow, out_str)
SELECT
	yproceedstransmission, nproceedstransmission, ndoc, 4 * idpro - 2, 
	-- Tipo Record
	'PR' +
	-- Codice Ente
	@cod_department +
	-- Esercizio Emissione Reversale
	CONVERT(varchar(4),ydoc) +
	-- Numero Mandato
	ndocformatted +
	-- Progressivo Beneficiario
	SUBSTRING(REPLICATE('0',@len_idpro),1,@len_idpro - DATALENGTH(CONVERT(varchar(7),idpro))) + 
	CONVERT(varchar(7),idpro) +
	-- Anagrafica Beneficiario
	title_ver +
	-- address Beneficiario
	address_ver +
	-- C.A.P. Beneficiario
	cap_ver + 
	-- Località Beneficiario
	location_ver +
	-- province Beneficiario
	province_ver +
	-- Partita IVA (Se la Partita IVA è estera valorizzare il campo con 11 nove e contestualmente valorizzare
	pi_ver + -->  SE Italiana sarà già stata valorizzata bene nella SELECT iniziale, SE Estera sarà stata valorizzata con 11 nove. Quindi la leggiamo e basta.
	-- Codice Fiscale
	cf_ver +
	-- Flag Incasso Condizionato
	' ' +
	-- Esenzione
	free_stamp +
	-- Assoggettamento Bollo
	' ' +
	-- Causale Esenzione Bollo
	SPACE(30) +
	-- amount Bollo (DA NON VALORIZZARE SU RICHIESTA DELLA BANCA)
	REPLICATE('0',7) +
	-- Carico Spese
	' ' +
	-- Importo Spese
	REPLICATE('0',7) +
	-- Carico Commissioni
	' ' +
	-- Importo Commissioni
	REPLICATE('0',7) +
	-- Descrizione Riscossione
	@descr_Encashment +
	-- Codice Riscossione
	@code_Encashment +
	-- amount Dettagli
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(originalamount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(originalamount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(originalamount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(originalamount)),
	DATALENGTH(CONVERT(varchar(15),SUM(originalamount)))-1,2) +
	-- Causale Riscossione
	-- proceedsdescr +
	------------------------------------------------------------------------------------------------------------------------------------------------
	CASE
	-- CUP  e DESCRIZIONE
			WHEN ( (DATALENGTH(isnull(CUP,'')) >0
					AND (6 + DATALENGTH(ISNULL(CUP,''))+ DATALENGTH(ISNULL(proceedsdescr,''))) <= @len_desc_proceeds )) 
			THEN 'CUP:'+isnull(CUP,'') + '; '+ISNULL(proceedsdescr, '') 
					+ SUBSTRING(
								SPACE(@len_desc_proceeds),
								1,
								@len_desc_proceeds - 6 - DATALENGTH(ISNULL(CUP,'') + ISNULL(proceedsdescr,''))
								)
	-- DESCRIZIONE
			ELSE ISNULL(proceedsdescr, '') 
					+ SUBSTRING(SPACE(@len_desc_proceeds),1,	@len_desc_proceeds - DATALENGTH(ISNULL(proceedsdescr,'')))
	END +
	------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


	-- mls genn 2006 , unicredit chiede di lasciare vuota la data
	-- Data Esecuzione Riscossione
	SPACE(10) +
	-- Lingua
	'I' + 
	-- Riferimento Documento Esterno (Decidere quando valorizzare ad 8)
	SPACE(1) +
	-- Informazioni Tesoriere
	CASE
		WHEN pi_ver_estera is not null  
		THEN @nota_pivaestera + pi_ver_estera + 
			SPACE(150 - LEN(@nota_pivaestera) - LEN(pi_ver_estera))
		ELSE SPACE(150)
	END +
	-- Codice Generico
	SPACE(20) +
	-- Flag Copertura 
	fulfilled +
	-- Gruppo Sostituzione Reversale (3 campi)
	SPACE(14) + REPLICATE('0',4) +
	-- Gruppo Info Servizio Reversale Testata (7 campi)
	--SPACE(926)
	SPACE(914)+
	cu -- 12
FROM #proceeds 
WHERE #proceeds.idinc in (select idinc FROM #proceedsvar)-- Vanno inseriti SOLO i sub annullati
GROUP BY yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro,
title_ver, address_ver, cap_ver, location_ver, province_ver,
pi_ver,pi_ver_estera, cf_ver, free_stamp, proceedsdescr, transmissiondate, fulfilled, cu, CUP

-- RECORD CR
--UNISOB non dee trasmettere il record siope
--INSERT INTO #trace (y, n, ndoc, nrow, out_str)
--SELECT
--	yproceedstransmission, nproceedstransmission, ndoc, 4 * idpro - 1,
--	'CR' + @cod_department + CONVERT(varchar(4),ydoc) + ndocformatted +
--	SUBSTRING(REPLICATE('0',@len_idpro),1,@len_idpro - DATALENGTH(CONVERT(varchar(7),idpro))) + 
--	CONVERT(varchar(7),idpro) +
--	sortcode + SUBSTRING(SPACE(@len_sortcode),1,@len_sortcode - DATALENGTH(sortcode)) +
--	descr_sorting + SUBSTRING(SPACE(@len_desc_sort),1,@len_desc_sort - DATALENGTH(descr_sorting)) +
--	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
--	DATALENGTH(CONVERT(varchar(15),SUM(amount)))) +
--	SUBSTRING(CONVERT(varchar(15),SUM(amount)),1,
--	DATALENGTH(CONVERT(varchar(15),SUM(amount)))-3) +
--	SUBSTRING(CONVERT(varchar(15),SUM(amount)),
--	DATALENGTH(CONVERT(varchar(15),SUM(amount)))-1,2)
--FROM #siope
--GROUP BY yproceedstransmission, nproceedstransmission, ndoc, idpro, sortcode, descr_sorting, ydoc, ndocformatted

-- RECORD BR (Estremi Bilancio) Non bisogna dare informazioni

-- RECORD MR (Mandati Associati) - Va compilato solo in caso di modifiche SIOPE
INSERT INTO #trace (y, n, ndoc, nrow, out_str)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ndoc, 4*#proceeds.idpro,
	'MR' + @cod_department + CONVERT(varchar(4),#proceeds.ydoc) + #proceeds.ndocformatted +
	SUBSTRING(REPLICATE('0',@len_idpro),1,@len_idpro - DATALENGTH(CONVERT(varchar(7),#proceeds.idpro))) + 
	CONVERT(varchar(7),#proceeds.idpro) +
	#payment.ndocformatted +
	SUBSTRING(REPLICATE('0',@len_idpay),1,@len_idpay - DATALENGTH(CONVERT(varchar(7),#payment.idpay))) + 
	CONVERT(varchar(7),#payment.idpay) +
	CONVERT(varchar(4),#payment.ydoc) +

	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount -
	DATALENGTH(CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #payment WHERE #payment.idexp = #proceeds.idexp)))) +
	SUBSTRING(CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #payment WHERE #payment.idexp = #proceeds.idexp)),1,
	DATALENGTH(CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #payment WHERE #payment.idexp = #proceeds.idexp)))-3) +
	SUBSTRING(CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #payment WHERE #payment.idexp = #proceeds.idexp)),
	DATALENGTH(CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #payment WHERE #payment.idexp = #proceeds.idexp)))-1,2)
FROM #proceeds
JOIN #payment
	ON #proceeds.idexp = #payment.idexp
WHERE (select COUNT(*) FROM #proceedsvar where varsiope = 'S')>=1
GROUP BY #proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.ndocformatted, #payment.ydoc, #payment.ndocformatted, #proceeds.idpro, #payment.idpay, #proceeds.idexp
 
  
-- AL MOMENTO NON DOBBIAMO TRASMETTERE L'INFORMAZIONE SUL SOSPESO NEL RECORD  SR AL BANCO DI NAPOLI)
-- RECORD SR (Sospesi) - Va compilato solo in caso di modifiche SIOPE
INSERT INTO #trace (y, n, ndoc, nrow, out_str)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ndoc, 4 * #proceeds.idpro + 1,
	'SR' --Fisso "SR"
	+ @cod_department --Codice identificativo dell'Ente
	+ CONVERT(varchar(4),#proceeds.ydoc) --Esercizio di emissione del mandato
	+ #proceeds.ndocformatted --Numero del mandato; se numerico allineato a destra e preceduto da zeri
	--"numero progressivo delle disposizioni contenute nel mandato; se numerico allineato a destra e preceduto da zeri.
	--In caso di mandato monobeneficiario il progressivo deve essere imponation sempre ad 1."
	+ SUBSTRING(REPLICATE('0',@len_idpro),1,@len_idpro - DATALENGTH(CONVERT(varchar(7),#proceeds.idpro))) + CONVERT(varchar(7),#proceeds.idpro)
	+ REPLICATE('0',7 - LEN(CONVERT(varchar(7),#incomebill.nbill))) + CONVERT(varchar(7),#incomebill.nbill) --numero del provvisorio emesso per l'incasso anticipato
	+ SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - DATALENGTH(CONVERT(varchar(15),SUM(#incomebill.amount)))) 
	+ SUBSTRING(CONVERT(varchar(15),SUM(#incomebill.amount)),1, DATALENGTH(CONVERT(varchar(15),SUM(#incomebill.amount)))-3) 
	+ SUBSTRING(CONVERT(varchar(15),SUM(#incomebill.amount)), DATALENGTH(CONVERT(varchar(15),SUM(#incomebill.amount)))-1,2) --amount del provvisorio emesso per il pagamento anticipato
FROM #proceeds JOIN #incomebill ON #proceeds.idinc = #incomebill.idinc 
WHERE    (select COUNT(*) FROM #proceedsvar where varsiope = 'S')>=1
GROUP BY #proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc, #proceeds.ndocformatted, #proceeds.idpro,  
#incomebill.nbill

---- RECORD DM  SOSPESA LA SCRITTURA DEL RECORD DM PER IL MOMENTO
--INSERT INTO #trace (y, n, ndoc, nrow, out_str)
--SELECT
--	yproceedstransmission, nproceedstransmission, ndoc,  4 * idpro + 2,
--	'DM' + @cod_department + CONVERT(varchar(4),ydoc) + ndocformatted +
--	SUBSTRING(REPLICATE('0',@len_idpro),1,@len_idpro - DATALENGTH(CONVERT(varchar(7),#note.idpro))) + 
--	nome_campo +  -- nome campo da 28 57
--	testo 		  -- valore campo da 58 257
--FROM #note
--WHERE (select COUNT(*) FROM #proceedsvar where varsiope = 'S')>=1
--GROUP BY yproceedstransmission, nproceedstransmission, ndoc,ndocformatted,idpro



-- RECORD CF 
INSERT INTO #trace (y, n, ndoc, nrow, out_str)
SELECT
	yproceedstransmission, nproceedstransmission, 99999999, 2147483647, 
	'CF' + @ABI_code + SUBSTRING('000000',1,@n_pro_trans - LEN(CONVERT(varchar(6),nproceedstransmission))) +
	CONVERT(varchar(6),nproceedstransmission) +
	CONVERT(varchar(19),CONVERT(smalldatetime, GETDATE(), 126),126) +
	CONVERT(varchar(4),@y) + @cod_department +
	-- Numero Record
	SUBSTRING('0000000',1,@len_ndoc -
	DATALENGTH(CONVERT(varchar(7),
		(SELECT COUNT(*)
		FROM #trace
		WHERE out_str LIKE 'MP%'
			AND yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission))
	)) +
	CONVERT(varchar(7),
		(SELECT COUNT(*)
		FROM #trace
		WHERE out_str LIKE 'MP%'
			AND yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission)) +
	-- Importo Lordo
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount -
	DATALENGTH(CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #proceeds
		WHERE yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission))
	)) +
	SUBSTRING(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #proceeds
		WHERE yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission)),1,
	DATALENGTH(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #proceeds
		WHERE yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission))
	) - 3
	) + 
	SUBSTRING(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #proceeds
		WHERE yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission)),
	DATALENGTH(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #proceeds
		WHERE yproceedstransmission = proceedstransmission.yproceedstransmission
			AND nproceedstransmission = proceedstransmission.nproceedstransmission))
	) -1,2
	)
FROM proceedstransmission
WHERE yproceedstransmission = @y
	AND nproceedstransmission = @n

-- Rimozione dei caratteri non consentiti
UPDATE #trace SET out_str = REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(
out_str,
'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'Ù','u'),
'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
']',' '),'`',' '),'{',' '),'}',' '),'~',' '),'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),
'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),
'õ','o'),'ý','y'),'é','e'),'à','a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'á','a'),'í','i'),'ó','o'),'É','e'),
'Á','a'),'À','a'),'È','e'),'Í','i'),'Ì','i'),'Ó','o'),'Ò','o'),'Ú','u'),'°',' '),
CHAR(9),' '),CHAR(10),' '),CHAR(13),' ')

SELECT out_str FROM #trace
ORDER BY y, n, ndoc, nrow
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


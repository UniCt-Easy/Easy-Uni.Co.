
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_carime_ins_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_carime_ins_new]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        PROCEDURE [trasmele_income_carime_ins_new]
(
	@y int,
	@n int
)
AS BEGIN

DECLARE @len_numericdata int
SET @len_numericdata = 7

DECLARE @len_amount int
SET @len_amount = 15

DECLARE @len_codentebt INT
SET @len_codentebt = 7

DECLARE @len_ndoc int
SET @len_ndoc = 7

DECLARE @len_registry_title int
SET @len_registry_title = 100 

-- singola tranche del nominativo, i nomi lunghi vengono suddivisi in tranches, 
-- da riportare in un record addizionale relativo al beneficiario
DECLARE @len_tranche int
SET @len_tranche = 30   -- campo zanaben ANAGRAFICA VERSANTE

DECLARE @len_tranche_aggiuntiva int
SET @len_tranche_aggiuntiva = 70   -- campo aggiuntivo ANAGRAFICA VERSANTE E CAUSALE

DECLARE @len_address int
SET @len_address = 30

DECLARE @len_cap int
SET @len_cap = 5

DECLARE @len_location int
SET @len_location = 28

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

DECLARE @len_cin int
SET @len_cin = 1


DECLARE @len_desc_proceeds int
SET @len_desc_proceeds = 370

DECLARE @len_sortcode int
SET @len_sortcode = 10 --codice siope


DECLARE @len_idstamphandling int
SET @len_idstamphandling = 3

DECLARE @len_zinfent INT
SET @len_zinfent = 250 --informazioni aggiuntive ente

DECLARE @ABI_codecarime varchar(5)
SET @ABI_codecarime = '03067'   -- 03067 abi carime

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

DECLARE @opkind char(3) 
--Può assumere i valori 
--INS– Inserimento  Ordinativo 
--VAR- Variazione Ordinativo
--ANN- Annullo Ordinativo
--SOS- Sostituzione Ordinativo
--(vedere specifiche tracciato)

DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 7

DECLARE @cc_vincolato varchar(7)

DECLARE @len_agencycode int
SET @len_agencycode = 7


SET @opkind = 'INS' -- Attualmente può assumere solamente valore 'INS'

DECLARE @cod_department varchar(9) -- Codice dell'ente da esportare
DECLARE @ABI_code varchar(5)
SELECT  @cod_department = ISNULL(agencycodefortransmission,''),
	@ABI_code = SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(idbank,'')))+ ISNULL(idbank,''),
	@cc_vincolato = SUBSTRING(REPLICATE('0',@lenCC_vincolato),1,@lenCC_vincolato - 
					DATALENGTH(CONVERT(varchar(7),ISNULL(trasmcode,'0')))) + CONVERT(varchar(7),ISNULL(trasmcode,'0'))
FROM treasurer WHERE idtreasurer = @idtreasurer


-- Inizio Sezione Controlli

CREATE TABLE #error (message varchar(400))

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

-- CONTROLLO N. 2. Lunghezza del codice ente
IF (DATALENGTH(@cod_department) > @len_agencycode)
BEGIN
	INSERT INTO #error
	VALUES ('Il codice Ente inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@len_agencycode))
END

IF (DATALENGTH(@cod_department) < @len_agencycode)
BEGIN
	INSERT INTO #error
	VALUES ('Il codice Ente inserito è inferiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@len_agencycode))
END

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

-- CONTROLLO N. 14. Presenza trattamento bollo
INSERT INTO #error (message)
SELECT 'Il trattamento bollo deve essere obbligatoriamente impostato per la reversale n° ' + CONVERT(varchar(6),P.npro) 
FROM proceeds P
WHERE P.idstamphandling IS NULL
	  AND P.kproceedstransmission = @k

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
-- Fine Sezione Controlli

SET @cod_department = @cod_department + SUBSTRING(SPACE(@len_agencycode),1,@len_agencycode - DATALENGTH(@cod_department))

-- Tabella di output
CREATE TABLE #trace
(
	y int,
	n int,
	ndoc int,
	nrow int,
	kind char(1),
	out_str varchar(400) COLLATE SQL_Latin1_General_CP1_CI_AS
)

DECLARE @incomeregphase	tinyint
SELECT  @incomeregphase = incomeregphase FROM uniconfig

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
	idpaymethodEASY varchar(10),
	idpaymethodTRS varchar(10),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25),
	cin varchar(2),
	iddeputy int,
	flagpendingincome char(1)
)


-- Tabella degli incassi
CREATE TABLE #proceeds
(
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idinc int,
	ymov int, 
	nmov int, 
	nphase tinyint, 
	phase varchar(50),
	curramount decimal(19,2),
	curramount_expense decimal(19,2), -- importo della spesa accessoria
	flagcr char(1),
	idreg int,
	income_adate datetime,
	proceeds_adate datetime,
	transmissiondate datetime,
	idpro int, 
	accountkind char(1),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25), -- Viene impostato a 25 in quanto gli utenti possono adoperare un C/C che eccede tale lunghezza
	cin char(1),
	iban varchar(50),
	title_ver varchar(140),
	address_ver varchar(30),
	cap_ver varchar(5),
	iso_code_ver varchar(2),
	location_ver varchar(30),
	province_ver varchar(2),
	pi_ver varchar(11),
	cf_ver varchar(16),
	ccp_collection varchar(12), -- conto corrente postale riscossione (incamero tasse universitarie)
	proceedsdescr varchar(370),
	stamp_charge varchar(3),
	girofondo char(1),
	registry_tosplit char(1),
	proceedsdescr_tosplit char(1),
	txt text, 
	doc varchar(35),
	newproceedsdescr varchar(500),
	fulfilled char(1),
	flagbankitaliaproceeds char(1),
	idexp varchar(72),
	nbill varchar(7),
	cu varchar(64),
	codefin varchar(50),
	CR varchar(10),
	CUP varchar(15),
	codeupb varchar(50), upbtitle varchar(150),
	inccodefin	varchar(50), fintitle varchar(150), 
	nlevel tinyint, finlevel varchar(50),
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
	progressive int,
	testo varchar(250)
)

-- Riempimento della tabella degli incassi con i movimenti che sono presenti nella distinta di trasmissione
INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idinc, 
	ymov, nmov, nphase, phase,flagcr,curramount,curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate, stamp_charge, registry_tosplit, girofondo,
	accountkind, title_ver, cf_ver, pi_ver, proceedsdescr,fulfilled, flagbankitaliaproceeds, idexp, 
	nbill, idpro,codeupb, upbtitle, inccodefin, fintitle, nlevel,finlevel,
	cupcodefin,cupcodeupb,cupcodeincome, ccp_collection,flagpendingincome
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.ypro, d.npro, e.idinc, 
	e.ymov, e.nmov, e.nphase, iph.description, 
	CASE
		WHEN ((i.flag&1)=0) THEN 'C'
		WHEN ((i.flag&1)=1) THEN 'R'
	END, 
	i.curramount,
	CASE
		WHEN ((il.flag&32) <> 0) THEN et.curramount
		ELSE 0
	END,
	e.idreg, e.adate, d.adate, t.transmissiondate, 
	CASE 
		WHEN DATALENGTH(ISNULL(tb.handlingbankcode,'')) <= @len_idstamphandling
		THEN ISNULL(tb.handlingbankcode,'') + SPACE(@len_idstamphandling - DATALENGTH(ISNULL(tb.handlingbankcode,'')))
		ELSE SUBSTRING(tb.handlingbankcode,1,@len_idstamphandling)
	END,
	CASE 
		WHEN LEN (ISNULL(c.title,'')) >@len_tranche THEN 'S'
		ELSE 'N'
	END,
	'N', -- girofondo
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'F'  -- fruttifero
		ELSE 'I' -- infruttifero
	END,
	ISNULL(c.title,'') + SUBSTRING(SPACE(@len_registry_title),1,@len_registry_title - DATALENGTH(c.title)),
	CASE
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
		THEN c.cf + SUBSTRING(SPACE(@len_cf),1,@len_cf - DATALENGTH(c.cf))
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
		THEN REPLICATE('',@len_cf)
		ELSE SPACE(@len_cf)
	END,
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
			AND DATALENGTH(c.p_iva) <= @len_pi
		THEN  SUBSTRING(ISNULL(c.p_iva,''),1,@len_pi)+ SUBSTRING(REPLICATE('',@len_pi),1,@len_pi
			  - ISNULL(DATALENGTH(SUBSTRING(ISNULL(c.p_iva,''),1,@len_pi)),0)) 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
			AND DATALENGTH(c.p_iva) > @len_pi
		THEN SUBSTRING(c.p_iva, 1, @len_pi)
		ELSE REPLICATE('',@len_pi)
	END,
	-- Causale riscossione
	ISNULL(e.description,'') ,
	CASE
		WHEN (( il.flag & 1)=1) then 'S'
		ELSE 'N'
	End,
	CASE
		WHEN ((il.flag & 8)<> 0) then 'S' -- flagbankitaliaproceeds RISCOSSIONE PRESSO TPS
		ELSE 'N'
	End,
	CASE
		WHEN ((il.flag&32) <> 0) THEN null
		ELSE e.idpayment
	END ,
	ISNULL(REPLICATE('0',7-DATALENGTH(CONVERT(varchar(7),il.nbill))) + CONVERT(varchar(7),il.nbill),REPLICATE('0',7)),
	il.idpro,
	upb.codeupb, upb.title,
	fin.codefin, fin.title, 
	fin.nlevel,finlevel.description,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	r.ccp, -- conto corrente postale di versamento tasse universitarie
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
JOIN incomephase iph
	ON iph.nphase = e.nphase
JOIN upb 
	ON upb.idupb = y.idupb
JOIN fin
	ON fin.idfin = y.idfin
JOIN finlevel 
	ON fin.nlevel = finlevel.nlevel
	AND finlevel.ayear = y.ayear
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
JOIN income RegPhase -- fase del Versante
	ON RegPhase.idinc = RegPhaseELK.idparent 
JOIN upb U
	ON U.idupb = y.idupb
JOIN finlast 
	ON finlast.idfin = y.idfin
JOIN registry r
	ON r.idreg = e.idreg
LEFT OUTER JOIN stamphandling tb
	ON d.idstamphandling = tb.idstamphandling
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
WHERE t.kproceedstransmission = @k

---INSERISCO GLI INCASSI VIRTUALI OTTENUTI DAGLI INCASSI A REGOLARIZZAZIONE DI SOSPESI 
-- L'incasso reale sarà suddiviso in due tranches, uno a regolarizzazione di importo pari al sospeso e non collegato alla spesa
-- l'altro sarà un incasso virtuale  collegato alla spesa (in modo da ottenere complessivamente saldo zero ) e con idpro
-- fittizio pari a 2 (obblighiamo a fare le reversali singole in tali casi)

INSERT INTO #proceeds
(
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, idinc, 
	ymov, nmov, nphase, phase,flagcr,curramount,curramount_expense,
	idreg, income_adate, proceeds_adate, transmissiondate, stamp_charge, registry_tosplit, girofondo,
	accountkind, title_ver, cf_ver, pi_ver, proceedsdescr,fulfilled, flagbankitaliaproceeds, idexp, 
	nbill, idpro,codeupb, upbtitle, inccodefin, fintitle, nlevel,finlevel,
	cupcodefin,cupcodeupb,cupcodeincome, ccp_collection,flagpendingincome
)
SELECT
	t.yproceedstransmission, t.nproceedstransmission, d.ypro, d.npro, e.idinc, 
	e.ymov, e.nmov, e.nphase, iph.description, 
	CASE
		WHEN ((i.flag&1)=0) THEN 'C'
		WHEN ((i.flag&1)=1) THEN 'R'
	END, 
	i.curramount,
	CASE
		WHEN ((il.flag&32) <> 0) THEN et.curramount
		ELSE 0
	END,
	e.idreg, e.adate, d.adate, t.transmissiondate, 
	CASE 
		WHEN DATALENGTH(ISNULL(tb.handlingbankcode,'')) <= @len_idstamphandling
		THEN ISNULL(tb.handlingbankcode,'') + SPACE(@len_idstamphandling - DATALENGTH(ISNULL(tb.handlingbankcode,'')))
		ELSE SUBSTRING(tb.handlingbankcode,1,@len_idstamphandling)
	END,
	CASE 
		WHEN LEN (ISNULL(c.title,'')) >@len_tranche THEN 'S'
		ELSE 'N'
	END,
	'N', -- girofondo
	CASE
		WHEN (d.flag & 8) <> 0 THEN 'F'  -- fruttifero
		ELSE 'I' -- infruttifero
	END,
	ISNULL(c.title,'') + SUBSTRING(SPACE(@len_registry_title),1,@len_registry_title - DATALENGTH(c.title)),
	CASE
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
		THEN c.cf + SUBSTRING(SPACE(@len_cf),1,@len_cf - DATALENGTH(c.cf))
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
		THEN REPLICATE('',@len_cf)
		ELSE SPACE(@len_cf)
	END,
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
			AND DATALENGTH(c.p_iva) <= @len_pi
		THEN  SUBSTRING(ISNULL(c.p_iva,''),1,@len_pi)+ SUBSTRING(REPLICATE('',@len_pi),1,@len_pi
			  - ISNULL(DATALENGTH(SUBSTRING(ISNULL(c.p_iva,''),1,@len_pi)),0)) 
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
			AND DATALENGTH(c.p_iva) > @len_pi
		THEN SUBSTRING(c.p_iva, 1, @len_pi)
		ELSE REPLICATE('',@len_pi)
	END,
	-- Causale riscossione
	ISNULL(e.description,'') ,
	CASE
		WHEN (( il.flag & 1)=1) then 'S'
		ELSE 'N'
	End,
	CASE
		WHEN ((il.flag & 8)<> 0) then 'S' -- flagbankitaliaproceeds RISCOSSIONE PRESSO TPS
		ELSE 'N'
	End,
	e.idpayment,
	null, --ISNULL(REPLICATE('0',7-DATALENGTH(CONVERT(varchar(7),il.nbill))) + CONVERT(varchar(7),il.nbill),REPLICATE('0',7)),
	il.idpro +1,
	upb.codeupb, upb.title,
	fin.codefin, fin.title, 
	fin.nlevel,finlevel.description,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	r.ccp, -- conto corrente postale di versamento tasse universitarie
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
JOIN incomephase iph
	ON iph.nphase = e.nphase
JOIN upb 
	ON upb.idupb = y.idupb
JOIN fin
	ON fin.idfin = y.idfin
JOIN finlevel 
	ON fin.nlevel = finlevel.nlevel
	AND finlevel.ayear = y.ayear
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
JOIN income RegPhase -- fase del Versante
	ON RegPhase.idinc = RegPhaseELK.idparent 
JOIN upb U
	ON U.idupb = y.idupb
JOIN finlast 
	ON finlast.idfin = y.idfin
JOIN registry r
	ON r.idreg = e.idreg
LEFT OUTER JOIN stamphandling tb
	ON d.idstamphandling = tb.idstamphandling
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
WHERE t.kproceedstransmission = @k
AND ((il.flag&32) <> 0) 

-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	yproceedstransmission int,
	nproceedstransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpro int,
	progressive int,
	sortcode varchar(30),
	sorting varchar(200),
	amount decimal(19,2),   -- importo classificato
	curramount decimal(19,2), -- importo reale incasso
	amount_expense decimal(19,2),  --- importo spesa accessoria
	idinc int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15), 
	cupcodeincome varchar(15),
	flagpendingincome char(1)
)

-- Valorizza codice cup -----
UPDATE #proceeds SET CUP = ISNULL(cupcodeincome,  ISNULL(cupcodeupb, ISNULL(cupcodefin,''))) --Codice CUP


UPDATE #proceeds SET newproceedsdescr = (SELECT
CASE
	-- CUP  e DESCRIZIONE
			WHEN ( (DATALENGTH(isnull(CUP,'')) >0)) 
			THEN 'CUP:'+isnull(CUP,'') + '; '+ISNULL(proceedsdescr, '') 
					+ SUBSTRING(
								SPACE(@len_desc_proceeds),
								1,
								@len_desc_proceeds - 6 - DATALENGTH(ISNULL(CUP,'') + ISNULL(proceedsdescr,''))
								)
	-- DESCRIZIONE
			ELSE ISNULL(proceedsdescr, '') 
					+ SUBSTRING(SPACE(@len_desc_proceeds),1,	@len_desc_proceeds - DATALENGTH(ISNULL(proceedsdescr,'')))
	END )
FROM #proceeds 


UPDATE #proceeds SET  proceedsdescr_tosplit = 'S' WHERE LEN (ISNULL(newproceedsdescr,'')) > 3*@len_tranche
UPDATE #proceeds SET  proceedsdescr_tosplit = 'N' WHERE LEN (ISNULL(newproceedsdescr,'')) <=3*@len_tranche



-- Gestione Mandati Associati
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
			ON expense.idexp = income.idpayment
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

--SELECT 'MANDATO PRINCIPALE', *  FROM #PAYMENT
--SELECT 'REVERSALE RITENUTE', *  FROM #PROCEEDS WHERE idexp IS NOT NULL
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

-- Inizio Formattazione del C/C	
-- Carime ammette come C/C numeri e caratteri maiuscoli, il C/C deve essere allineato a destra, carattere di padding lo 0
UPDATE #proceeds
SET cc = 
	UPPER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ',''))

UPDATE #proceeds SET cc = REPLICATE('0',@len_cc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
-- Fine Formattazione del C/C

-- Calcolo del campo ndocformatted
UPDATE #proceeds
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),ndoc))) + CONVERT(varchar(7),ndoc)

DECLARE @maxincomephase char(1)
SELECT  @maxincomephase = MAX(nphase) FROM incomephase

-- CONTROLLO N. 13 Controllo che i movimenti di entrata associati ai movimenti di spesa che stiamo trasmettendo siano stati inseriti
-- in una distinta di trasmissione
INSERT INTO #error (message)
SELECT 'Il movimento di entrata ' + CONVERT(varchar(6),I.nmov) + '/' + CONVERT(varchar(4),I.ymov)
+ ' associato al movimento di spesa ' + CONVERT(varchar(6),E.nmov) + '/' + CONVERT(varchar(4),E.nmov)
+ ' non è stato inserito in una distinta di trasmissione'
FROM #proceeds P
JOIN income I
	ON I.idpayment = P.idexp	
JOIN expense E
	ON P.idexp = E.idexp
JOIN incomelast IL
	ON I.idinc = il.idinc
JOIN incometotal IT
	ON I.idinc = IT.idinc
LEFT OUTER JOIN proceeds S
	ON S.kpro = IL.kpro
LEFT OUTER JOIN proceedstransmission T
	ON S.kproceedstransmission = T.kproceedstransmission
WHERE I.nphase = @maxincomephase
	AND ((I.autokind = 6) /* <--Recupero*/	OR (I.autokind = 14) /*<--automatismo generico*/OR (I.autokind = 4 AND I.idreg = P.idreg)/*<--Ritenuta*/)
	AND IT.ayear = @y
	AND T.yproceedstransmission IS NULL

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END




-- Gestione Indirizzi Beneficiario / Delegato
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

-- Tabella utilizzata per immagazzinare gli indirizzi dei versanti che si trovano
-- nelle distinte di trasmissione da esportare
CREATE TABLE #address
(
	idaddresskind int,
	idreg int,
	address varchar(100),
	location varchar(116),
	cap varchar(15),
	province varchar(2),
	idnation int,
	nation varchar(65),
	iso_nation varchar(2)
)

INSERT INTO #address
(
	idaddresskind,
	idreg,
	address,
	location,
	cap,
	province,
	idnation,
	nation,
	iso_nation
)
SELECT
	idaddresskind,
	idreg, 
	address,
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
	registryaddress.cap,
	geo_country.province,
	CASE 
		WHEN flagforeign = 'N' THEN 1
		ELSE geo_nation.idnation
	END,
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
		AND ((cdi.stop IS NULL) OR (cdi.stop >= @dateindi))
		AND cdi.idreg = registryaddress.idreg))
		AND idreg IN (SELECT DISTINCT idreg FROM #proceeds)

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
	WHERE #proceeds.idreg = #address.idreg)/*,
	-- commentato perchè non viene mai usato
iso_code_ver = 
	(SELECT iso_code
	FROM #address
	WHERE #proceeds.idreg = #address.idreg
	)*/



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
	sortcode, sorting,  curramount, amount, amount_expense, cupcodefin, 
	cupcodeupb, cupcodeincome, progressive,flagpendingincome
)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc, #proceeds.ndocformatted,
	#proceeds.idpro, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description, 
	SUM(#proceeds.curramount), SUM(incomesorted.amount), SUM(#proceeds.curramount_expense),
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome, 1,
	#proceeds.flagpendingincome
FROM #proceeds
JOIN incomesorted
	ON #proceeds.idinc = incomesorted.idinc
JOIN sorting
	ON sorting.idsor = incomesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
GROUP BY
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc, #proceeds.ndocformatted,
	#proceeds.idpro, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)),sorting.description,
	#proceeds.cupcodefin, #proceeds.cupcodeupb, #proceeds.cupcodeincome,
	#proceeds.flagpendingincome

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


-- Calcolo del progressivo SIOPE
-- Anche la classificazione ha un suo progressivo che è pari al numero di codici classificazione distinti precedente al corrente,
-- legati allo stesso progressivo percipiente.
UPDATE #siope
SET progressive = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT sortcode)
	FROM #siope s2
	WHERE  s2.ydoc = #siope.ydoc
		AND s2.ndoc = #siope.ndoc
		AND s2.idpro =  #siope.idpro 
		AND s2.sortcode <  #siope.sortcode 
		)
,0)

INSERT INTO #note (yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro, testo)
SELECT  
yproceedstransmission, 
nproceedstransmission, 
ydoc, 
ndoc,
ndocformatted,
idpro,
[dbo].getstringformatted_r(finlevel + ': ' + inccodefin + ' - ' + fintitle + ' ,UPB: ' + codeupb + ' - ' + upbtitle, @len_zinfent)
FROM #proceeds
GROUP BY yproceedstransmission, nproceedstransmission, ndoc, idpro, 
		 ydoc, ndocformatted, finlevel, inccodefin, fintitle, codeupb, upbtitle


-- RECORD FASE + MOVIMENTO
INSERT INTO #note (yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro, testo)
SELECT  
yproceedstransmission, 
nproceedstransmission, 
ydoc, 
ndoc,
ndocformatted,
idpro,
--Informazione Ente ZINFENT
[dbo].getstringformatted_r(phase + ' n.' + convert(varchar(10),nmov) + ' / ' + + convert(varchar(4),ymov) + ', Competenza/Residui: ' + flagcr , @len_zinfent) 
FROM #proceeds
GROUP BY yproceedstransmission, nproceedstransmission, ndoc, idpro, 
		 ydoc, ndocformatted,phase, ymov, nmov,flagcr

-- RECORD DESCRIZIONE CLASSIFICAZIONE SIOPE 
INSERT INTO #note (yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro, testo)
SELECT  
yproceedstransmission, 
nproceedstransmission, 
ydoc, 
ndoc,
ndocformatted,
idpro,
--Informazione Ente ZINFENT
[dbo].getstringformatted_r('SIOPE: ' + sortcode + ' - ' + sorting + ', Importo: ' + convert(varchar(30), amount), @len_zinfent) 
FROM #siope
GROUP BY yproceedstransmission, nproceedstransmission, ndoc, idpro, sortcode, sorting, amount,
		 ydoc, ndocformatted
		 
		 
UPDATE #note
SET progressive = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT testo)
	FROM #note n2
	WHERE  n2.ydoc = #note.ydoc
		AND n2.ndoc = #note.ndoc
		AND n2.idpro =  #note.idpro
		AND n2.testo <  #note.testo 
		)
,0)

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
WHERE   incomelast.nbill IS NOT NULL  AND #proceeds.fulfilled = 'S'  

	
 -- Bollette multiple
INSERT INTO  #incomebill
(	yproceedstransmission, nproceedstransmission, idinc,
	ydoc, ndoc, idpro, ybill,nbill, amount)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.idinc, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.idpro, incomebill.ybill, incomebill.nbill,  incomebill.amount
FROM #proceeds
JOIN incomebill ON #proceeds.idinc = incomebill.idinc  AND #proceeds.fulfilled = 'S'  
 WHERE (#proceeds.flagpendingincome = 'N' OR (#proceeds.flagpendingincome = 'S' AND #proceeds.idpro <> 2))

-----------------------------------------------------------------------------------------------------------------
----------------------------------------------inizio tracciato---------------------------------------------------
-----------------------------------------------------------------------------------------------------------------
-- Tutti i record indipendentemente dalla tipologia hanno la parte iniziale fissa
-- contenente ABI CARIME + CODICE ENTE BT (agencycodefortransmission di treasurer) + ESERCIZIO E NUMERO DISTINTA
DECLARE @prefisso_record varchar(23)
SET @prefisso_record   = (SELECT @ABI_code + 
					   CONVERT(varchar(7),[dbo].getint(@cod_department,@len_codentebt)) +
                       CONVERT(varchar(4),[dbo].getint(@y,4) ) + 
					   CONVERT(varchar(7),[dbo].getint(@n,@len_ndoc)))
-------------------------------
---  5.1 REVERSALI RECORD 0 ---	
-------------------------------

INSERT INTO #trace (y, n, ndoc, nrow, kind, out_str)
SELECT
	yproceedstransmission, nproceedstransmission, 0, 0,'0',
    @prefisso_record +
	ndocformatted + 
	REPLICATE('0',7) + --NSUB
	'0' +  -- TIPO RECORD
	--- DATA TRASMISSIONE
	[dbo].GetData(transmissiondate) +
	-- Importo Reversale
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
	-- NCAP + NART + NRES + CVOCNEW: I CAMPI RELATIVI ALLA GESTIONE DEL BILANCIO DEVONO RESTARE VUOTI
	-- PER QUESTA TIPOLOGIA DI ENTE NON SONO RILEVANTI
	REPLICATE('0',7) + -- NCAP
	REPLICATE('0',3) + -- NART
	REPLICATE('0',4) + -- NRES 
	REPLICATE('0',3) + -- CVOCNEW
	@cc_vincolato + -- NUMERO CONTO DI PROCEDURA NCNT
	REPLICATE('0',7) + -- CENTFDL
	'N' + -- FLAG SOMME IMPIGNORABILI)
	-- IMPORTO A COPERTURA DEL PROVVISORIO ----IDOCCOP
	CASE fulfilled  -- FLAG MANDATO A COPERTURA
		WHEN 'S' THEN	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
						DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
						SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
						DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
						SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
						DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) 
		ELSE REPLICATE('0', @len_amount)
	END + 
	REPLICATE(' ',20) +
	[dbo].GetData(proceeds_adate) +
	REPLICATE(' ',240)+ -- FILLER
	REPLICATE('0' ,7) + -- NUMERO REVERSALE COLLEGATA
	REPLICATE(' ', 3) + 
	-- reversale con disposizioni di incasso (elenco versanti), non lo gestiamo
	REPLICATE(' ', 3) +
	REPLICATE('0', 7) + -- NUMERO DISPOSIZIONE DI INCASSO ASSOCIATA DA VALORIZZARE (NON GESTITA)
	@opkind + 
	'R'
FROM #proceeds
GROUP BY yproceedstransmission, nproceedstransmission, transmissiondate,
		 ydoc, ndoc, ndocformatted,fulfilled 
		 
----------------------------------------------
-----------  5.3REVERSALI RECORD 1 -------------	
----------------------------------------------
INSERT INTO #trace (y, n, ndoc, nrow, kind, out_str)
SELECT
	yproceedstransmission, nproceedstransmission, ndoc, 1,'0',
	-- Tipo Record
	@prefisso_record +
	-- Numero Reversale NREV
	ndocformatted +
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(idpro, @len_numericdata)) +
	-- TIPO RECORD  CTIPREC
	'1' +
	-- NCAP + NART + NRES + CVOCNEW: I CAMPI RELATIVI ALLA GESTIONE DEL BILANCIO DEVONO RESTARE VUOTI
	-- PER QUESTA TIPOLOGIA DI ENTE NON SONO RILEVANTI
	REPLICATE('0',7) + -- NCAP
	REPLICATE('0',3) + -- NART
	REPLICATE('0',4) + -- NRES 
	REPLICATE('0',3) + -- CVOCNEW
	REPLICATE('0',7) + -- NUMERO CONTO DI PROCEDURA NCNT
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount -    --- IVER IMPORTO BENEFICIARIO
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
	REPLICATE(' ',3) + -- CODICE DIVISA VERSANTE CDIVER
	REPLICATE('0',8) + -- DATA VALUTA VERSANTE NON VALORIZZARE SU RICHIESTA CARIME, LE DATE HANNO IL FORMATO NUMERICO
	-- Codice Trattamento bollo
	CASE fulfilled 
		WHEN 'S'  THEN REPLICATE('0' ,3)
		ELSE [dbo].getstringformatted_r(SUBSTRING(stamp_charge,1,3),3) 
	END + 
	-- Importo Bollo, valorizzare con zero
	REPLICATE('0',9) +
	-- Codice trattamento spese: da valorizzare sempre a “000”(zero), sarà gestito dalla banca
	REPLICATE('0',3) +
	-- Importo Spese, valorizzare con zero
	REPLICATE('0',9) +
	CASE
		WHEN ((fulfilled = 'S') AND (flagbankitaliaproceeds = 'S') AND (accountkind = 'F')) THEN '04'  -- FRUTTIFERA LIBERA
		WHEN ((fulfilled = 'S') AND (flagbankitaliaproceeds = 'S') AND (accountkind = 'I')) THEN '05'  -- INFRUTTIFERA LIBERA
		ELSE  '01' --FRUTTIFERA LIBERA
	END + --  TIPO IMPUTAZIONE (NON GESTIAMO LA DESTINAZIONE VINCOLATA)
	--- REVERSALE A COPERTURA DI PROVVISORI GIA' EMESSI CHE LA BANCA DEVE REGOLARIZZARE 
	fulfilled +  -- INDICATORE REVERSALE A COPERTURA
	CASE
			-- Partita IVA
			WHEN LTRIM(RTRIM(pi_ver)) <> '' THEN [dbo].getstringformatted_r(SUBSTRING(pi_ver,1,@len_cf),@len_cf) 
			-- Codice Fiscale
			ELSE [dbo].getstringformatted_r(SUBSTRING(cf_ver,1,@len_cf),@len_cf)  
	END +
	--Codice Istat versante
	REPLICATE('0',7) +
	-- Codice lingua versante
	SPACE(1) +
	[dbo].getstringformatted_r(SUBSTRING (title_ver, 1, @len_tranche),@len_tranche) + 
	-- Indirizzo Versante
	[dbo].getstringformatted_r(address_ver,@len_tranche) +
	-- C.A.P. Versante
	[dbo].getstringformatted_r(cap_ver,5) + 
	-- Località Versante
	[dbo].getstringformatted_r(location_ver,28) +
	-- Provincia Versante
	[dbo].getstringformatted_r(province_ver,2) +
	-- Codice ABI Versante
	REPLICATE('0',@len_ABI)+
	-- Codice CAB Versante
	REPLICATE('0',@len_CAB)+
	-- Conto Corrente Postale Versante
	CASE
		WHEN ((ccp_collection IS NOT NULL) AND (fulfilled <> 'S')) THEN [dbo].getstringformatted_r(ccp_collection, @len_cc)
		ELSE REPLICATE(' ',@len_cc)
	END +  -- DA VALORIZZARE SE MODALITA' RISCOSSIONE PREVEDE IL PRELIEVO DA CC POSTALE
	-- CIN
	' ' +
	REPLICATE('0',3) + --  CCAU	
	-- Causale Riscossione
	[dbo].getstringformatted_r(substring(newproceedsdescr,1,@len_tranche), @len_tranche)				  + --	ZCAU1
	[dbo].getstringformatted_r(substring(newproceedsdescr,@len_tranche + 1,@len_tranche), @len_tranche)   + --	ZCAU2		
	[dbo].getstringformatted_r(substring(newproceedsdescr,2*@len_tranche + 1,@len_tranche), @len_tranche) + --	ZCAU3	
	REPLICATE(' ',@len_cf) + --	CVER	
	REPLICATE(' ',4)  + --	CTIPVER	
	REPLICATE('0',@len_numericdata)+  -- NUMERO CONTO BANCA ITALIA
	CASE -- CRIS codice Riscossione
		WHEN ((ccp_collection IS NOT NULL) AND (fulfilled <> 'S')) THEN '76'
		ELSE '01'
	END +
	REPLICATE('0',3)  + --	CNOT1	
	REPLICATE('0',3)  + --	CNOT2	
	REPLICATE('0',3)  + --	CNOT3	
	REPLICATE('0',8) + --  FILLER
	@opkind + 
	'R'	
	FROM #proceeds
	GROUP BY
	yproceedstransmission, nproceedstransmission, ydoc, ndoc, ndocformatted, idpro,
	title_ver, address_ver, cap_ver, location_ver, province_ver,
	pi_ver, cf_ver, ABI, CAB, cc, cin, 
	newproceedsdescr,CUP,transmissiondate, fulfilled,flagbankitaliaproceeds,
	stamp_charge,ccp_collection,accountkind

----------------------------------------------	
------ REVERSALI RECORD 4 – TIPO V  ----------
----------------------------------------------	
-- RECORD SUPPLEMENTARE PER QUEI VERSANTI	
-- CHE HANNO UN NOME PIU' LUNGO DI 30 CAR.
-- IL NOME VIENE SPLITTATO IN TRANCHE AGGIUNTIVE DI 70 CAR.

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	yproceedstransmission, Nproceedstransmission, ndoc, 4,'B',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Reversale
	ndocformatted +
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(idpro, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'V' +
	--ZINF01
	[dbo].getstringformatted_r(SUBSTRING(title_ver,@len_tranche + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF02
	[dbo].getstringformatted_r(SUBSTRING(title_ver,@len_tranche +@len_tranche_aggiuntiva +1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF03
	[dbo].getstringformatted_r(SUBSTRING(title_ver,@len_tranche + 2*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF04
	[dbo].getstringformatted_r(SUBSTRING(title_ver, @len_tranche + 3*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--FILLER
	REPLICATE (' ', 77) +
	--SOPE
	@opkind + 
	--SDOC
	'R'
FROM #proceeds
WHERE registry_tosplit = 'S'
GROUP BY
yproceedstransmission, nproceedstransmission, ydoc, ndoc, 
ndocformatted, idpro,title_ver

----------------------------------------------------	
-------- REVERSALI RECORD 4 – TIPO C  --------------
----------------------------------------------------	
-- RECORD SUPPLEMENTARE PER QUELLE RISCOSSIONI	
-- CHE HANNO UNA DESCRIZIONE PIU' LUNGA DEI 
-- 90 CAR. MESSI A DISPOSIZIONE NEL RECORD PRINCIPALE 
-- LA STRINGA VIENE SPLITTATA IN TRANCHE AGGIUNTIVE 
-- DI 70 CAR.


INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	yproceedstransmission, nproceedstransmission, ndoc, 4,'C',
	-- Tipo Record
	@prefisso_record +
	--NREV
	-- Numero Reversale
	ndocformatted +
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(idpro, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'C' +
	--ZINF01
	[dbo].getstringformatted_r(SUBSTRING(newproceedsdescr,3*@len_tranche + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF02
	[dbo].getstringformatted_r(SUBSTRING(newproceedsdescr,3*@len_tranche +@len_tranche_aggiuntiva +1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF03
	[dbo].getstringformatted_r(SUBSTRING(newproceedsdescr,3*@len_tranche + 2*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF04
	[dbo].getstringformatted_r(SUBSTRING(newproceedsdescr,3*@len_tranche + 3*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--FILLER
	REPLICATE(' ' ,77) +
	--SOPE
	@opkind + 
	--SDOC
	'R'
FROM #proceeds
WHERE proceedsdescr_tosplit = 'S'
GROUP BY
yproceedstransmission, nproceedstransmission, ydoc, ndoc, 
ndocformatted, idpro,newproceedsdescr
	

-------------------------------------------------	
-------------- REVERSALI RECORD 5 ---------------
-------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI CON RITENUTE CHE DEVONO ESSERE
-- A CARICO DEL BENEFICIARIO, RAPPRESENTA
-- IL MANDATO PRINCIPALE
-- SU RICHIESTA DELLA CARIME VIENE COMMENTATA QUESSTA PARTE
-- PERCHE' IL MANDATO ASSOCIATO ALLA REVERSALE NON VIENE GESTITO DAL LORO SISTEMA

/*
INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ndoc, 5,'0',
	-- Tipo Record
	@prefisso_record +
	--NREV
	-- Numero Reversale
	#proceeds.ndocformatted +
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(#proceeds.idpro, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'5' +
	-- IASS IMPORTO ASSOCIATO
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(#payment.curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(#payment.curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(#payment.curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(#payment.curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(#payment.curramount)))-1,2) +
	-- NDOCRIT NUMERO DOCUMENTO ASSOCIATO
	#payment.ndocformatted +
	-- NSUBRIT NUMERO SUB MANDATO PRINCIPALE
	CONVERT(varchar(7),[dbo].getint(#payment.idpay, @len_numericdata)) +
	-- STIPASS TIPO ASSOCIAZIONE AL MANDATO PRINCIPALE
	'R' +
	-- CTIPDOC TIPO DOCUMENTO ASSOCIATO
	'MAN' +
	-- FILLER
	SPACE(325) +
	@opkind + 
	'R'
FROM #proceeds
JOIN #payment
	ON #proceeds.idexp = #payment.idexp
GROUP BY #proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc,
	#proceeds.ndocformatted, #payment.ydoc, #payment.ndocformatted, #proceeds.idpro, #payment.idpay, #proceeds.idexp
*/


-------------------------------------------------	
-------------- REVERSALI RECORD 6 ---------------
-------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- DOCUMENTI  A REGOLARIZZAZIONE DI 
-- PROVVISORI

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	#proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ndoc, 6,'0',
	-- Tipo Record
	@prefisso_record +
	--NREV
	-- Numero Reversale
	#proceeds.ndocformatted +
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(#proceeds.idpro, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'6' +
	-- NPRO
	REPLICATE('0',7 - LEN(CONVERT(varchar(7),#incomebill.nbill))) + CONVERT(varchar(7),#incomebill.nbill) + --numero del provvisorio emesso per la riscossione anticipata
	--IREG
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - DATALENGTH(CONVERT(varchar(15),SUM(#incomebill.amount))))  +
	SUBSTRING(CONVERT(varchar(15),SUM(#incomebill.amount)),1, DATALENGTH(CONVERT(varchar(15),SUM(#incomebill.amount)))-3)  +
	SUBSTRING(CONVERT(varchar(15),SUM(#incomebill.amount)), DATALENGTH(CONVERT(varchar(15),SUM(#incomebill.amount)))-1,2) + --importo del provvisorio emesso per il pagamento anticipato
	-- FILLER
	SPACE(336) +
	@opkind + 
	'R'
FROM #proceeds JOIN #incomebill ON #proceeds.idinc = #incomebill.idinc 
GROUP BY #proceeds.yproceedstransmission, #proceeds.nproceedstransmission, #proceeds.ydoc, #proceeds.ndoc, #proceeds.ndocformatted, #proceeds.idpro,  
#incomebill.nbill

-------------------------------------------------	
-------------- REVERSALI RECORD 7 ---------------
-------------------------------------------------	
--RECORD INFORMAZIONI AGGIUNTIVE ENTE

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	yproceedstransmission, nproceedstransmission, ndoc, 7,'0',
	@prefisso_record +
	-- Numero Reversale
	ndocformatted +  --NREV
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(#note.idpro, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'7' +
	-- Numero Sotto Tipo Record NSTIPREC
	CONVERT(varchar(7),[dbo].getint(progressive , 3)) +
	--Informazione Ente ZINFENT
	[dbo].getstringformatted_r(testo, @len_zinfent) +
	--FILLER
	SPACE(105)+ 
	--SOPE
	'INS' + 
	--SDOC
	'R'
FROM #note
ORDER BY ndoc,idpro,progressive


-------------------------------------------------	
-------------- REVERSALI RECORD 8 -----------------
-------------------------------------------------	
-- RECORD CLASSIFICAZIONI SIOPE

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	yproceedstransmission, nproceedstransmission, ndoc, 8,'0',
	@prefisso_record +
	-- Numero Reversale
	ndocformatted +
	-- Numero Subordinativo (idpro) NSUB
	CONVERT(varchar(7),[dbo].getint(#siope.idpro, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'8' +
	--NPRG
	CONVERT(varchar(7),[dbo].getint(#siope.progressive, @len_numericdata)) +
	--NCAPAFP
	REPLICATE('0',7) +
	--NARTAFP
	REPLICATE('0',3) +
	--NRESAFP
	REPLICATE('0',4) +
	--CVOCAFP
	REPLICATE('0',3) +
	--CCGU
	[dbo].getstringformatted_r(sortcode, @len_sortcode) +
	[dbo].getstringformatted_r(ISNULL(cupcodeincome,ISNULL(cupcodedetail, ISNULL(cupcodeupb, cupcodefin))),15) + --Codice Cup
	SPACE(14) + --Codice CCPV
	--IIMPAFP
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(#siope.amount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(#siope.amount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(#siope.amount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(#siope.amount)),
	DATALENGTH(CONVERT(varchar(15),SUM(#siope.amount)))-1,2) + 
	--FILLER
	SPACE(280)+ 
	@opkind + 
	'R'
FROM #siope
GROUP BY yproceedstransmission, nproceedstransmission, ndoc, idpro, sortcode, 
		 ydoc, ndocformatted,  cupcodeincome,  cupcodedetail, cupcodeupb,cupcodefin, progressive

-- Rimozione dei caratteri non consentiti

--select *, datalength(out_str) from #trace

UPDATE #trace SET out_str = 
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
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
'Á','a'),'À','a'),'È','e'),'Í','i'),'Ì','i'),'Ó','o'),'Ò','o'),'Ú','u'),
CHAR(9),' '),CHAR(10),' '),CHAR(13),' '),CHAR(31),' ' )

SELECT out_str FROM #trace ORDER BY substring(out_str, 1,38) --y, n, ndoc, nrow, kind
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


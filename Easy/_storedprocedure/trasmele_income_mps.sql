
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_mps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_mps]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [trasmele_income_mps]
(
	@y int,
	@n int
)
AS
BEGIN
/* Versione 1.0.0 del 09/11/2007 ultima modifica: GIUSEPPE */
-- Inizio Sezione Dichiarativa
DECLARE @codicefiliale varchar(5) -- Codice della filiale
DECLARE @codiceente varchar(9) -- Codice dell'ente da esportare
DECLARE @numeroconto varchar(28) -- Numero del Conto dell'ente presso l'istituto cassiere
DECLARE @cino char(2) -- Codice CIN
DECLARE @codiceABI varchar(5)
DECLARE @lennumelenco int
DECLARE @lennumdoc int
DECLARE @lenimporto int
DECLARE @lendescente int
DECLARE @lenindirizzoente int
DECLARE @lenlocalitaente int
DECLARE @lenprogrbeneficiario int
DECLARE @lenprogrreversale int
DECLARE @lendenominazione int
DECLARE @lenindirizzo int
DECLARE @lencap int
DECLARE @lenlocalita int
DECLARE @lenprovincia int
DECLARE @lencf int
DECLARE @lenpi int
DECLARE @lencodiceabi int
DECLARE @lencodicecab int
DECLARE @lencc int
DECLARE @lenccp int
DECLARE @lendescrmodalitapag int
DECLARE @lendescpagamento int
DECLARE @lencodiceclass int
DECLARE @lendendelegato int
DECLARE @lenprogrflusso int
DECLARE @lencognomedelegato int
DECLARE @lennomedelegato int
DECLARE @lencin int
DECLARE @lendescincasso int

SET @lennumelenco = 5
SET @lennumdoc = 7
SET @lenimporto = 15
SET @lencf = 16
SET @lendescente = 35
SET @lenindirizzoente = 30
SET @lenlocalitaente = 35
SET @lenprogrbeneficiario = 5
SET @lenprogrreversale = 5
SET @lendenominazione = 60
SET @lenindirizzo = 60
SET @lencap = 5
SET @lenlocalita = 35
SET @lenprovincia = 2
SET @lencf = 16
SET @lenpi = 16
SET @lencodiceabi = 5
SET @lencodicecab = 5
SET @lencc = 12
SET @lenccp = 10
SET @lendescrmodalitapag = 30
SET @lendescpagamento = 150
SET @lencodiceclass = 10
SET @lendendelegato = 140
SET @lenprogrflusso = 5
SET @lencognomedelegato = 50
SET @lennomedelegato = 50
SET @lencin = 1
SET @lendescincasso = 150

DECLARE @kproceedstransmission int
DECLARE @idtreasurer int

-- Fine sezione dichiarativa
DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 7

DECLARE @cc_vincolato varchar(7)

SELECT @idtreasurer = idtreasurer, @kproceedstransmission = kproceedstransmission
FROM proceedstransmission
WHERE yproceedstransmission =@y and nproceedstransmission = @n

IF (@idtreasurer is null) 
BEGIN
	SELECT @idtreasurer= max(idtreasurer) from treasurer where flagdefault='S'
END
if (@idtreasurer is null) 
BEGIN
	SELECT @idtreasurer= max(idtreasurer) from treasurer 
END
	
SELECT 
@codicefiliale = ISNULL(cabcodefortransmission,''),
@codiceente = ISNULL(agencycodefortransmission,''),
@numeroconto = ISNULL(cc,''),
@cino = ISNULL(cin, '00'),
@codiceABI = SUBSTRING(REPLICATE('0',@lencodiceabi),1,@lencodiceabi - DATALENGTH(ISNULL(idbank,'')))
+ ISNULL(idbank,''),
@cc_vincolato = SUBSTRING( REPLICATE('0',7), 1, @lenCC_vincolato - DATALENGTH(SUBSTRING(ISNULL(trasmcode,''), DATALENGTH(ISNULL(trasmcode,''))-6,@lenCC_vincolato))) + substring(ISNULL(trasmcode,''), DATALENGTH(ISNULL(trasmcode,''))-6,@lenCC_vincolato)
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @cfente varchar(16)
DECLARE @descente varchar(35)
DECLARE @indirizzoente varchar(30)
DECLARE @localitaente varchar(35)
SELECT @cfente = ISNULL(cf,'') + SUBSTRING(SPACE(@lencf),1,@lencf - DATALENGTH(ISNULL(cf,''))) ,
@descente = 
CASE
	WHEN DATALENGTH(ISNULL(departmentname,'')) <= @lendescente
	THEN ISNULL(departmentname,'') + SUBSTRING(SPACE(@lendescente),1,@lendescente - DATALENGTH(ISNULL(departmentname,'')))
	ELSE SUBSTRING(departmentname,1,@lendescente)
END,
@indirizzoente =
CASE 
	WHEN DATALENGTH(ISNULL(address1,'')) <= @lenindirizzoente
	THEN ISNULL(address1,'') + SUBSTRING(SPACE(@lenindirizzoente),1,@lenindirizzoente - DATALENGTH(ISNULL(address1,'')))
	ELSE SUBSTRING(address1,1,@lenindirizzoente)
END,
@localitaente = 
CASE 
	WHEN DATALENGTH(ISNULL(location,'')) <= @lenlocalitaente
	THEN ISNULL(location,'') + SUBSTRING(SPACE(@lenlocalitaente),1,@lenlocalitaente - DATALENGTH(ISNULL(location,'')))
	ELSE SUBSTRING(location,1,@lenlocalitaente)
END
FROM license

DECLARE @lencodiceente int
SET @lencodiceente = 3
DECLARE @lencodicefiliale int
SET @lencodicefiliale = 5

CREATE TABLE #error (message varchar(400))

-- Inizio Sezione Controlli
DECLARE @message varchar(200)
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
IF(
(SELECT COUNT(*) FROM proceeds
WHERE kproceedstransmission = @kproceedstransmission) = 0)
BEGIN
	INSERT INTO #error
	VALUES ('La distinta di trasmissione ' + CONVERT(varchar(4),@y) + '/'
	+ CONVERT(varchar(6),@n) + ' è vuota')
END
-- CONTROLLO N. 1. Presenza dei dati dell'ente
DECLARE @errore char(1)
SET @errore = 'N'
SET @message = 'Mancano i seguenti dati: '

IF (@codicefiliale IS NULL OR @codicefiliale = '')
BEGIN
	SET @message = @message + ' Il Codice Filiale'
	SET @errore = 'S'
END
IF (@codiceente IS NULL OR @codiceente = '')
BEGIN
	SET @message = @message + ' Il Codice Ente'
	SET @errore = 'S'
END
IF (@codiceABI IS NULL OR @codiceABI = '')
BEGIN
	SET @message = @message + ' Il codice ABI'
	SET @errore = 'S'
END
IF (@errore = 'S')
BEGIN
	SET @message = @message + ' Andare nella maschera CONFIGURAZIONE - CASSIERE - CASSIERE ed inserire i dati'
	INSERT INTO #error VALUES(@message)
END
-- CONTROLLO N. 2. Lunghezza del codice ente
IF (DATALENGTH(@codiceente)>@lencodiceente)
BEGIN
	INSERT INTO #error VALUES ( 'Il codice Ente inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@lencodiceente))
END
-- CONTROLLO N. 3. Lunghezza del codice filiale
IF (DATALENGTH(@codicefiliale)>@lencodicefiliale)
BEGIN
	INSERT INTO #error VALUES (  'Il codice Filiale inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@lencodicefiliale))
END

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

-- Attenzione! Altri controlli sono presenti nel testo della SP in quanto non era possibile calcolarli a priori
-- I controlli vengono riconosciuti in quanto il prefisso adoperato come linea di commento sarà CONTROLLO N. x.
-- Fine Sezione Controlli
SET @codiceente = SUBSTRING(REPLICATE('0',@lencodiceente),1,@lencodiceente - DATALENGTH(@codiceente)) + @codiceente
SET @codicefiliale = SUBSTRING(REPLICATE('0',@lencodicefiliale),1,@lencodicefiliale - DATALENGTH(@codicefiliale)) + @codicefiliale
	
-- Tabella di output
CREATE TABLE #tracciato
(
	y int,
	n int,
	ndoc int,
	progr_submovimento int,
	rownum int,
	stringa varchar(600) COLLATE SQL_Latin1_General_CP1_CI_AS
)

DECLARE @incomeregphase	tinyint
SELECT @incomeregphase = incomeregphase FROM  uniconfig


-- Tabella degli incassi
CREATE TABLE #incasso
(
	y int,
	n int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idinc varchar(72),
	curramount decimal(19,2),
	idreg int,
	income_adate datetime,
	proceeds_adate datetime,
	transmissiondate datetime,
	registry_prog int,
	reg_title varchar(140),
	reg_address varchar(60),
	reg_cap varchar(5),
	reg_location varchar(35),
	reg_p_iva varchar(16),
	reg_cf varchar(16), 
	fruitfull char(1),
	proceedsdescr varchar(150),
	fulfilled char(1),
	nbill varchar(7),
	idpayment int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodeincome varchar(15)
)
	
-- Tabella classificazione SIOPE
CREATE TABLE #siope
(
	y int,
	n int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	registry_prog int,
	sortcode varchar(30),
	amount decimal(19,2),
	progressive int,
	formatted_progressive varchar(3),
	idinc int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodeincome varchar(15)
)

-- Tabella utilizzata per immagazzinare gli indirizzi dei creditori debitori che si trovano
-- nelle distinte di trasmissione da esportare
CREATE TABLE #rptindirizzoavpag
(
	idaddresskind int,
	idreg int,
	address varchar(100),
	location varchar(116),
	cap varchar(15),
	province varchar(2),
	nation varchar(65)
)
	
-- Inserimento degli incassi presenti nella distinta di trasmissione
INSERT INTO #incasso (y, n, ydoc, ndoc, idinc, curramount,
idreg, income_adate, proceeds_adate, transmissiondate, fruitfull,
reg_title, reg_cf, reg_p_iva, proceedsdescr, fulfilled, nbill,idpayment,
cupcodefin,cupcodeupb,cupcodeincome)
SELECT t.yproceedstransmission, t.nproceedstransmission, d.ypro, d.npro, e.idinc, i.curramount,
e.idreg, e.adate, d.adate, t.transmissiondate, 
CASE
	WHEN ((d.flag & 8) <> 0) THEN '1'
	ELSE '2'
END,
CASE
	WHEN DATALENGTH(ISNULL(c.title,'')) <= @lendenominazione
	THEN ISNULL(c.title,'') + SPACE(@lendenominazione - DATALENGTH(ISNULL(c.title,'')))
	ELSE SUBSTRING(c.title, 1, @lendenominazione)
END,
CASE
	WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL
	THEN c.cf + SUBSTRING(SPACE(@lencf),1,@lencf - DATALENGTH(c.cf))
	WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
	THEN SPACE(@lencf)
END,
CASE
	WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
	THEN SUBSTRING(REPLICATE('0',@lenpi),1,@lenpi - 
			ISNULL(DATALENGTH(SUBSTRING(ISNULL(c.p_iva,''),1,@lenpi)),0)) 
			+ SUBSTRING(ISNULL(c.p_iva,''),1,@lenpi)
	ELSE SPACE(@lenpi)
END,
CASE
	WHEN DATALENGTH(ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') + ISNULL(e.description,'')) <= @lendescincasso
	THEN
		ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') + ISNULL(e.description,'') +
		SPACE(@lendescincasso -
		DATALENGTH(ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') + ISNULL(e.description,'')))
	ELSE
		ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') +
		SUBSTRING(ISNULL(e.description,''),1,@lendescincasso - DATALENGTH(ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'')))
END,
CASE
	when (( il.flag & 1)=1) then 'S'
	else 'N'
End,
ISNULL(REPLICATE('0', 7-DATALENGTH(CONVERT(varchar(7),il.nbill))) + CONVERT(varchar(7),il.nbill),REPLICATE('0',7)),
e.idpayment,
finlast.cupcode,
u.cupcode,
RegPhase.cupcode
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

JOIN upb u
	ON u.idupb = y.idupb
JOIN fin f
	ON f.idfin = y.idfin
JOIN finlast 
	ON finlast.idfin = f.idfin
JOIN incomelink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
	ON RegPhaseELK.idchild = il.idinc
	AND RegPhaseELK.nlevel = @incomeregphase
JOIN income RegPhase			-- fase del Creditore
	ON RegPhase.idinc = RegPhaseELK.idparent 

LEFT OUTER JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
WHERE t.yproceedstransmission = @y
	AND t.nproceedstransmission = @n
	AND i.ayear = @y
	
-- Calcolo di ndocformatted
UPDATE #incasso
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@lennumdoc),1,@lennumdoc - DATALENGTH(CONVERT(varchar(7),ndoc))) +
CONVERT(varchar(7),ndoc)
	
-- Calcolo del progressivo
-- Si calcola il progressivo come numero di movimenti di entrata distinti precedenti al corrente
UPDATE #incasso
SET registry_prog = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT idinc)
	FROM #incasso p2
	WHERE p2.y = #incasso.y
		AND p2.n = #incasso.n
		AND p2.ydoc = #incasso.ydoc
		AND p2.ndoc = #incasso.ndoc
		AND p2.idinc < #incasso.idinc)
,0)
	
-- Gestione Indirizzi Beneficiario / Obbligato
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

INSERT INTO #rptindirizzoavpag
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
isnull(geo_city.title,'')+' ' +isnull(registryaddress.location,'') ,
registryaddress.cap,
geo_country.province,
case 
	when flagforeign = 'N' then 'ITALIA'
	else geo_nation.title
end
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
	AND 
 (	(idreg IN (SELECT DISTINCT idreg FROM #incasso))
)

DELETE #rptindirizzoavpag
	where #rptindirizzoavpag.idaddresskind <> @nostand
	and exists (
		select * from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg=r2.idreg
		and r2.idaddresskind = @nostand
	)

DELETE #rptindirizzoavpag
	where #rptindirizzoavpag.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg=r2.idreg
		and r2.idaddresskind = @stand
	)

DELETE #rptindirizzoavpag
	where (
		select count(*) from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg=r2.idreg
	)>1

-- Unificazione descrizioni di pagamento per movimenti di spesa che sono stati accorpati
UPDATE #incasso
SET proceedsdescr = 'ACCORPAMENTO INCASSI' + SPACE(@lendescincasso - DATALENGTH('ACCORPAMENTO INCASSI'))
WHERE
	(SELECT COUNT(*)
	FROM #incasso p2
	WHERE p2.y = #incasso.y
		AND p2.n = #incasso.n
		AND p2.ydoc = #incasso.ydoc
		AND p2.ndoc = #incasso.ndoc
		AND p2.registry_prog = #incasso.registry_prog) > 1
	AND 
		(SELECT COUNT(*)
		FROM #incasso p2
		WHERE p2.y = #incasso.y
			AND p2.n = #incasso.n
			AND p2.ydoc = #incasso.ydoc
			AND p2.ndoc = #incasso.ndoc
			AND p2.registry_prog = #incasso.registry_prog) <>
		(SELECT COUNT(*)
		FROM #incasso p2
		WHERE p2.y = #incasso.y
			AND p2.n = #incasso.n
			AND p2.ydoc = #incasso.ydoc
			AND p2.ndoc = #incasso.ndoc
			AND p2.registry_prog = #incasso.registry_prog
			AND p2.proceedsdescr = #incasso.proceedsdescr)

-- Aggiornamento dei dati inerenti l'indirizzo dell'obbligato	
UPDATE #incasso
SET reg_address =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @lenindirizzo
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@lenindirizzo),1,@lenindirizzo - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@lenindirizzo)
	END
	FROM #rptindirizzoavpag
	WHERE #incasso.idreg = #rptindirizzoavpag.idreg)
,SPACE(@lenindirizzo)),
reg_cap =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @lencap
		THEN SUBSTRING(REPLICATE('0',@lencap),1,@lencap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@lencap)
	END
	FROM #rptindirizzoavpag
	WHERE #incasso.idreg = #rptindirizzoavpag.idreg)
,REPLICATE('0',@lencap)),
reg_location =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @lenlocalita
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@lenlocalita),1,@lenlocalita - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@lenlocalita)
	END
	FROM #rptindirizzoavpag
	WHERE #incasso.idreg = #rptindirizzoavpag.idreg)
,SPACE(@lenlocalita))

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
INSERT INTO #siope (y, n, ydoc, ndoc, ndocformatted,
registry_prog, sortcode, amount,idinc,
cupcodefin,cupcodeupb,cupcodeincome)
SELECT #incasso.y, #incasso.n,
#incasso.ydoc, #incasso.ndoc, #incasso.ndocformatted,
#incasso.registry_prog,
SUBSTRING(sorting.sortcode,@npos,@lencodiceclass),
SUM(incomesorted.amount),
#incasso.idinc,
#incasso.cupcodefin,#incasso.cupcodeupb, #incasso.cupcodeincome
FROM #incasso
JOIN incomesorted
ON #incasso.idinc = incomesorted.idinc
JOIN sorting
	ON sorting.idsor = incomesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
GROUP BY #incasso.y, #incasso.n, #incasso.ydoc,
#incasso.ndoc, #incasso.ndocformatted, sorting.sortcode,
#incasso.registry_prog,#incasso.idinc,
#incasso.cupcodefin,#incasso.cupcodeupb, #incasso.cupcodeincome


-- Calcolo del progressivo SIOPE come conteggio dei codici SIOPE distinti precedenti al corrente presenti nella stessa reversale
UPDATE #siope
SET progressive = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT sortcode)
	FROM #siope s2
	WHERE s2.y = #siope.y
		AND s2.n = #siope.n
		AND s2.ydoc = #siope.ydoc
		AND s2.ndoc = #siope.ndoc
		AND
		CONVERT(varchar(5),s2.registry_prog) + s2.sortcode < 
		CONVERT(varchar(5),#siope.registry_prog) + #siope.sortcode)
,0)

DECLARE @lenprogressivo int
SET @lenprogressivo = 3

UPDATE #siope SET formatted_progressive = 
CASE
	WHEN DATALENGTH(CONVERT(varchar(3),progressive)) <= @lenprogressivo
	THEN REPLICATE('0',@lenprogressivo - DATALENGTH(CONVERT(varchar(3),progressive))) + CONVERT(varchar(3),progressive)
	ELSE SUBSTRING(CONVERT(varchar(3),progressive),1,@lenprogressivo)
END
	
-- CONTROLLO N. 11 Il numero di classificazioni non può superare il limite massimo per ogni beneficiario
DECLARE @limiteclassificazioni int
SET @limiteclassificazioni = 15

IF EXISTS(
	(SELECT COUNT(*) FROM #siope
	GROUP BY y, n, ydoc, ndoc, registry_prog
	HAVING COUNT(*) > @limiteclassificazioni))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il mandato n. ' + CONVERT(varchar(6),ndoc) + '/' + CONVERT(varchar(4),ydoc)
	+ ' contiene più di ' + CONVERT(varchar(2),@limiteclassificazioni) + ' classificazioni SIOPE'
	FROM #siope WHERE
		(SELECT COUNT(*) FROM #siope s2
		WHERE s2.y = #siope.y
			AND s2.n = #siope.n
			AND s2.ydoc = #siope.ydoc
			AND s2.ndoc = #siope.ndoc
			AND s2.registry_prog = #siope.registry_prog)
	> @limiteclassificazioni)
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

DECLARE @dataproduzione datetime
SET @dataproduzione = GETDATE()
DECLARE @dataformattata varchar(8)
SET @dataformattata =
CONVERT(varchar(4),YEAR(@dataproduzione)) +
REPLICATE('0',2 - DATALENGTH(CONVERT(varchar(2),MONTH(@dataproduzione)))) + CONVERT(varchar(2),MONTH(@dataproduzione)) +
REPLICATE('0',2 - DATALENGTH(CONVERT(varchar(2),DAY(@dataproduzione)))) + CONVERT(varchar(2),DAY(@dataproduzione))

DECLARE @tipoflusso varchar(3)
SET @tipoflusso = '001'

DECLARE @lencodiceCUP int
SET @lencodiceCUP = 15
-- RECORD 01
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento,rownum, stringa)
SELECT yproceedstransmission, nproceedstransmission, 0, 0, 0, 
'01' + '00001' + @tipoflusso + @dataformattata +
-- Progressivo per data
'0' +
@codicefiliale + @codiceente + @descente +
REPLICATE('0',@lennumelenco - DATALENGTH(CONVERT(varchar(5),nproceedstransmission))) + CONVERT(varchar(5),nproceedstransmission) +
-- Codice Ente Nazionale e Decodifica Ente Nazionale
SPACE(22) +
-- Filler
SPACE(510) +
-- Fine Record
'0'
FROM proceedstransmission
WHERE yproceedstransmission = @y AND nproceedstransmission = @n

INSERT INTO #tracciato (y, n, ndoc, progr_submovimento,rownum, stringa)
SELECT #incasso.y, #incasso.n, ndoc,0, 1,
'02' + '00000' + ndocformatted + CONVERT(varchar(4),#incasso.ydoc)
+ '0' + 
-- Data Contabile Reversale
CONVERT(varchar(4),YEAR(proceeds_adate)) +
SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(proceeds_adate)))) +
CONVERT(varchar(2),MONTH(proceeds_adate)) +
SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(proceeds_adate)))) +
CONVERT(varchar(2),DAY(proceeds_adate)) +
-- Capitolo e Articolo di Bilancio
REPLICATE('0',10) +
-- Competenza - Residui (Valorizzo sempre a ZERO perché è un dato facoltativo)
'0' +
-- Fruttifero - Infruttfero (per le spese vale sempre ZERO)
fruitfull +
-- Importo Totale
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
-- Dati del funzionario delegato (NON VALORIZZATI) (4 campi carattere ed 1 campo numerico)
SPACE(77) + REPLICATE('0',7) +
-- Tipo Atto
SPACE(60) +
-- Data Protocollo
REPLICATE('0',8) +
-- Numero Protocollo
SPACE(20) +
-- Data Scadenza
REPLICATE('0',8) +
-- Operatore
SPACE(20) +
-- Filler
SPACE(345) +
-- Fine Record
'0'
FROM #incasso
GROUP BY #incasso.y, #incasso.n, #incasso.ydoc, #incasso.ndocformatted,
#incasso.proceeds_adate, #incasso.ndoc, #incasso.fruitfull

INSERT INTO #tracciato (y, n, ndoc,progr_submovimento, rownum, stringa)
SELECT #incasso.y, #incasso.n, ndoc, registry_prog, 2,
'03' + '00000' + ndocformatted + 
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog) +
-- Data Scadenza
REPLICATE('0',8) +
-- Importo dettagli
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
-- Valuta per ente
REPLICATE('0',8) + 
-- Valuta per beneficiario
REPLICATE('0',8) +
-- Anagrafica Beneficiario
reg_title +
-- Indirizzo Beneficiario
reg_address +
-- Località Beneficiario
reg_location +
-- CAP Beneficiario
reg_cap +
-- Codice Fiscale - Partita IVA Beneficiario
CASE
	WHEN RTRIM(reg_cf) <> '' THEN reg_cf
 	WHEN RTRIM(reg_cf) = '' AND RTRIM(reg_p_iva) <> '' THEN reg_p_iva
	ELSE SPACE(@lencf)
END +
-- Descrizione Pagamento
proceedsdescr +
-- Modalità di Esecuzione
-- Parte di RIDEFINIZIONE in base alla Modalità di Pagamento adoperata
-- Se la bolletta è valorizzata allora R (a regolarizzazione), altrimenti C (cassa)
CASE 
	WHEN ((idpayment is not null) AND (nbill = REPLICATE('0',7))) THEN 'T' + REPLICATE('0',19) + SPACE(31) 
	WHEN (nbill <> REPLICATE('0',7)) THEN 'R' + nbill + SPACE(43)
	ELSE 'C' +  REPLICATE('0',19) + SPACE(31) 
END
+
-- Dati riservati all'ente
SPACE(7) +
-- Conto Corrente di Riferimento (L'università ha sempre un solo CC, tuttavia
-- può avere più sottoconti vincolati corrispondenti ai vari dipartimenti nella gestione Bilancio Unico)
@cc_vincolato +
-- Esenzione del bollo
'0' +
-- Importo Trattenute
REPLICATE('0',@lenimporto) +
-- Numero Ordinativo Trattenuta
REPLICATE('0',7) +
-- Numero Sub Ordinativo
REPLICATE('0',5) +
-- Capitolo / Articolo
REPLICATE('0',10) +
-- Dipendente Azienda
SPACE(1) +
-- Lingua
'I' +
-- da Causale Esenzione Bollo a Ufficio Responsabile (5 campi)
SPACE(105) +
-- Impignorabile
' ' +
-- Frazionabile
' ' +
-- Destinatario Spese
'B' +
-- Filler
SPACE(2) +
-- Fine Record
'0'
FROM #incasso
GROUP BY #incasso.y, #incasso.n, #incasso.ydoc, #incasso.ndocformatted,
#incasso.proceeds_adate, #incasso.ndoc,	reg_title, reg_address, reg_location, reg_cap, reg_cf,
proceedsdescr, registry_prog, fruitfull, #incasso.idinc, #incasso.reg_p_iva, #incasso.nbill, #incasso.idpayment
-- Record '04' non viene prodotto - la descrizione dei pagamenti non supera mai il limite imposto dalla banca

-- Record '05' Delegato - Non esiste per le entrate

-- Record '08' Siope
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento,rownum, stringa)
SELECT y, n, ndoc, #siope.registry_prog, 8,
'08' + '00000' + #siope.ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),#siope.registry_prog))) + 
CONVERT(varchar(5),#siope.registry_prog) +
-- Progressivo
#siope.formatted_progressive +
#siope.sortcode + SUBSTRING(SPACE(@lencodiceclass),1,@lencodiceclass - DATALENGTH(#siope.sortcode)) +
--Codice Cup
--ISNULL(upb.cupcode,ISNULL(finlast.cupcode,'')) + SUBSTRING(SPACE(@lencodiceCUP),1,@lencodiceCUP - DATALENGTH(ISNULL(upb.cupcode,ISNULL(finlast.cupcode,'')) )) +
ISNULL(#siope.cupcodeincome, ISNULL(#siope.cupcodeupb,ISNULL(#siope.cupcodefin,'')))
	+ SUBSTRING(SPACE(@lencodiceCUP),1,@lencodiceCUP - DATALENGTH(ISNULL(#siope.cupcodeincome,ISNULL(#siope.cupcodeupb,ISNULL(#siope.cupcodefin,''))))) + 
-- da Codice CUP a Codice CPV (2 campi)
SPACE(14) +
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(#siope.amount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(#siope.amount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(#siope.amount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(#siope.amount)),
DATALENGTH(CONVERT(varchar(15),SUM(#siope.amount)))-1,2) +
-- Filler
SPACE(523) +
-- Fine Record
'0'
FROM #siope
	JOIN incomeyear 
		ON #siope.idinc = incomeyear.idinc
	JOIN upb 
		on upb.idupb = incomeyear.idupb
	JOIN fin 
		on fin.idfin = incomeyear.idfin
	JOIN finlast 
		on finlast.idfin = incomeyear.idfin
WHERE incomeyear.ayear = #siope.y
GROUP BY y, n, ndoc, registry_prog,
sortcode, ydoc, ndocformatted, formatted_progressive,
cupcodeincome, cupcodeupb, cupcodefin

-- Record '07' Dettaglio trattenute - Non esiste per le entrate

-- Record '06' Informazioni Bilancio Non Prodotto
DECLARE @numreversali int
SET @numreversali = (SELECT COUNT(*) FROM #tracciato WHERE stringa LIKE '02%')

-- Record '09' Riepilogativa (OBBLIGATORIO)
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT yproceedstransmission, nproceedstransmission, 999999, 999999, 9,
'09' + '00000' + @dataformattata + '0'
+ @codicefiliale + @codiceente +
-- Numero Reversali (Le reversali sono trasmesse da un'altra procedura, ciò che qui trasmetto sono le tratenute)
REPLICATE('0',5 - DATALENGTH(CONVERT(varchar(5),@numreversali))) + CONVERT(varchar(5),@numreversali) +
-- Totale Entrate
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto -
	DATALENGTH(
		CONVERT(varchar(15),
			(SELECT SUM(curramount) FROM #incasso
			WHERE y = proceedstransmission.yproceedstransmission
			AND n = proceedstransmission.nproceedstransmission)
		)
	)
) +
SUBSTRING(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #incasso
		WHERE y = proceedstransmission.yproceedstransmission
		AND n = proceedstransmission.nproceedstransmission)
	),1,
	DATALENGTH(
		CONVERT(varchar(15),
			(SELECT SUM(curramount) FROM #incasso
			WHERE y = proceedstransmission.yproceedstransmission
			AND n = proceedstransmission.nproceedstransmission)
		)
	) - 3
) + 
SUBSTRING(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #incasso
		WHERE y = proceedstransmission.yproceedstransmission
		AND n = proceedstransmission.nproceedstransmission)
	),
	DATALENGTH(
		CONVERT(varchar(15),
			(SELECT SUM(curramount) FROM #incasso
			WHERE y = proceedstransmission.yproceedstransmission
			AND n = proceedstransmission.nproceedstransmission)
		)
	)-1, 2
) +
-- Numero Mandati
REPLICATE('0',5) +
-- Totale Uscite (Sempre ZERO)
REPLICATE('0',@lenimporto) +
-- Filler
SPACE(535) +
-- Fine Record
'0'
FROM proceedstransmission
WHERE yproceedstransmission = @y AND nproceedstransmission = @n

-- Record '10' Descrittiva - Non esiste per le entrate
-- Record '11' Spese Non lo produciamo
-- Sezione formattazione finale stringa
-- REPLACE dei caratteri speciali non ammessi / Conversione in caratteri maiuscoli
UPDATE #tracciato SET stringa = 
UPPER(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(
stringa,
'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'Ù','u'),
'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
']',' '),'`',' '),'{',' '),'}',' '),'~',' '),'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),
'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),
'õ','o'),'ý','y'),'é','e'),'à','a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'á','a'),'í','i'),'ó','o'),'É','e'),
'Á','a'),'À','a'),'È','e'),'Í','i'),'Ì','i'),'Ó','o'),'Ò','o'),'Ú','u'),
CHAR(9),' '),CHAR(10),' '),CHAR(13),' ')
)
-- Assegnazione del progressivo del flusso
DECLARE @stringa varchar(600)
DECLARE @str varchar(600)
DECLARE @progrflusso int
DECLARE @pf_str varchar(5)
SET @progrflusso = 1
DECLARE curr_stringa INSENSITIVE CURSOR FOR
SELECT stringa FROM #tracciato
ORDER BY y, n, ndoc, progr_submovimento, rownum
FOR READ ONLY
OPEN curr_stringa
FETCH NEXT FROM curr_stringa INTO @stringa
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SET @pf_str = REPLICATE('0',5 - DATALENGTH(CONVERT(varchar(5),@progrflusso))) +
	CONVERT(varchar(5),@progrflusso)
	
	SET @str = SUBSTRING(@stringa,1,2) + @pf_str + SUBSTRING(@stringa,8,DATALENGTH(@stringa))
	
	UPDATE #tracciato SET stringa = @str WHERE stringa = @stringa
	SET @progrflusso = @progrflusso + 1
	FETCH NEXT FROM curr_stringa INTO @stringa
END
CLOSE curr_stringa
DEALLOCATE curr_stringa
SELECT stringa as out_str FROM #tracciato
-- ORDER BY y, n, ndoc, rownum
ORDER BY y, n, ndoc, progr_submovimento, rownum
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_bancaroma]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_bancaroma]
GO

CREATE PROCEDURE [trasmele_income_bancaroma]
(
	@y int,
	@n int
)
AS BEGIN

DECLARE @n_pro_trans int
SET @n_pro_trans = 6

DECLARE @len_ndoc int
SET @len_ndoc = 7

DECLARE @len_amount int
SET @len_amount = 15

DECLARE @len_idpro int
SET @len_idpro = 4

DECLARE @len_registry_title int
SET @len_registry_title = 40

DECLARE @len_address int
SET @len_address = 40

DECLARE @len_cap int
SET @len_cap = 5

DECLARE @len_location int
SET @len_location = 30

DECLARE @len_province int
SET @len_province = 2

DECLARE @len_cf int
SET @len_cf = 16

DECLARE @len_pi int
SET @len_pi = 16

DECLARE @len_desc_proceeds int
SET @len_desc_proceeds = 60

DECLARE @len_sortcode int
SET @len_sortcode = 10

DECLARE @len_birthplace int
SET @len_birthplace = 30

DECLARE @idtreasurer int
DECLARE @kproceedstransmission int

SELECT @idtreasurer = idtreasurer, @kproceedstransmission = kproceedstransmission
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

DECLARE @cod_department varchar(20) -- Codice dell'ente da esportare
DECLARE @cod_filiale varchar(20)

SELECT 
	@cod_department = ISNULL(agencycodefortransmission,''),
	@cod_filiale = ISNULL(cabcodefortransmission,'')
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @len_agencycode int
SET @len_agencycode = 6

DECLARE @len_codfiliale int
SET @len_codfiliale = 5

CREATE TABLE #error (message varchar(400))

IF (DATALENGTH(@cod_department) < @len_agencycode) 
BEGIN
	SET @cod_department = @cod_department + SUBSTRING(SPACE(@len_agencycode),1,@len_agencycode - DATALENGTH(@cod_department))
END

IF (DATALENGTH(@cod_filiale) < @len_codfiliale) 
BEGIN
	SET @cod_filiale = @cod_filiale + SPACE(@len_codfiliale - DATALENGTH(@cod_filiale))
END

-- Inizio Sezione Controlli
DECLARE @message varchar(200)
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
IF(
(SELECT COUNT(*) FROM proceeds
WHERE ypro = @y
AND npro = @n) = 0)
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

IF (@cod_filiale IS NULL OR @cod_filiale = '')
BEGIN
	SET @message = @message + ' Il Codice Filiale'
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

IF (DATALENGTH(@cod_filiale) > @len_codfiliale)
BEGIN
	INSERT INTO #error
	VALUES ('Il codice Filiale inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@len_codfiliale))
END

-- CONTROLLO N. 3  Presenza tipologia dei creditori
INSERT INTO #error (message)
SELECT 'Il versante ' + ISNULL(R.title,'XXX') + ' con codice ' + CONVERT(varchar(6),R.idreg) + ' non ha una tipologia associata. E'' necessario inserirla'
FROM income I
JOIN incomelast L
	ON I.idinc = L.idinc
JOIN proceeds P
	ON P.kpro = L.kpro
JOIN registry R
	ON R.idreg = I.idreg
WHERE R.idregistryclass IS NULL
	AND P.kproceedstransmission = @kproceedstransmission

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Fine Sezione Controlli
CREATE TABLE #trace
(
	y int,
	n int,
	ndoc int,
	nrow int,
	out_str varchar(400) COLLATE SQL_Latin1_General_CP1_CI_AS
)

CREATE TABLE #allexpense
(
	idexp int,
	kpay int,
	ypay int,
	npay int,
	kpaymenttransmission int,
	ypaymenttransmission int,
	npaymenttransmission int,
	amount decimal(19,2),
	haspro char(1),
	netamount decimal(19,2)
)

CREATE TABLE #allincome
(
	idinc int,
	idexp int,
	kpro int,
	ypro int,
	npro int,
	kproceedstransmission int,
	yproceedstransmission int,
	nproceedstransmission int,
	amount decimal(19,2)
)

-- 1. Inserimento dei movimenti di entrata della trasmissione
INSERT INTO #allincome
(
	idinc, idexp, kpro, ypro, npro, kproceedstransmission, yproceedstransmission, nproceedstransmission, amount
)
SELECT
	L.idinc,
	CASE
		WHEN income.idpayment IS NOT NULL
		THEN
		CASE
			WHEN (income.autokind = 4 AND income.idreg = E.idreg) OR (income.autokind = 6)
			THEN income.idpayment
			ELSE NULL
		END
		ELSE NULL
	END, L.kpro, P.ypro, P.npro, P.kproceedstransmission, @y, @n, T.curramount
FROM incomelast L
JOIN incometotal T
	ON L.idinc = T.idinc
JOIN income
	ON income.idinc = L.idinc
JOIN proceeds P
	ON P.kpro = L.kpro
LEFT OUTER JOIN expense E
	ON E.idexp = income.idpayment
WHERE P.kproceedstransmission = @kproceedstransmission

-- 2. Inserimento dei movimenti di spesa legati a quelli di entrata
INSERT INTO #allexpense
(
	idexp, kpay, ypay, npay, kpaymenttransmission, ypaymenttransmission, npaymenttransmission, amount
)
SELECT
	L.idexp, L.kpay, P.ypay, P.npay, P.kpaymenttransmission, @y, @n, T.curramount
FROM expenselast L
JOIN expensetotal T
	ON L.idexp = T.idexp
JOIN payment P
	ON P.kpay = L.kpay
LEFT OUTER JOIN paymenttransmission PT
	ON PT.kpaymenttransmission = P.kpaymenttransmission
WHERE L.idexp IN
	(SELECT DISTINCT idexp FROM #allincome)

UPDATE #allexpense
SET haspro = 
CASE
	WHEN (SELECT COUNT(*)
	FROM #allincome
	WHERE #allincome.idexp = #allexpense.idexp) > 0
	THEN 'S'
	ELSE 'N'
END

UPDATE #allexpense
SET netamount = ISNULL(amount,0) -
ISNULL(
	(SELECT SUM(amount) FROM #allincome
	WHERE #allincome.idexp = #allexpense.idexp)
,0)
WHERE haspro = 'S'

DECLARE @code_eSIOPE varchar(20)
DECLARE @code_iSIOPE varchar(20)
DECLARE @npos int

IF (@y <= 2006)
BEGIN
	SET @code_eSIOPE = 'SIOPE'
	SET @code_iSIOPE = 'SIOPE'
	SET @npos = 2
END
ELSE
BEGIN
	SET @code_eSIOPE = '07U_SIOPE'
	SET @code_iSIOPE = '07E_SIOPE'
	SET @npos = 1
END

DECLARE @eSIOPE int
DECLARE @iSIOPE int

SET @eSIOPE = (SELECT idsorkind FROM sortingkind WHERE codesorkind = @code_eSIOPE)
SET @iSIOPE = (SELECT idsorkind FROM sortingkind WHERE codesorkind = @code_iSIOPE)

IF (@eSIOPE = NULL)
BEGIN
	INSERT INTO #error (message) VALUES
	('Errore di sistema, la classificazione SIOPE per le SPESE non esiste, Contattare il servizio assistenza')
END

IF (@iSIOPE = NULL)
BEGIN
	INSERT INTO #error (message) VALUES
	('Errore di sistema, la classificazione SIOPE per le SPESE non esiste, Contattare il servizio assistenza')
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

INSERT INTO #error (message)
SELECT 'Il movimento di spesa n. ' + CONVERT(varchar(6), expense.nmov) + '/' + CONVERT(varchar(4), expense.ymov) +
' non è correttamente classificato'
FROM expense
JOIN #allexpense
	ON #allexpense.idexp = expense.idexp
WHERE #allexpense.amount <>
ISNULL(
	(SELECT SUM(expensesorted.amount)
	FROM expensesorted
	JOIN sorting
		ON expensesorted.idsor = sorting.idsor
	WHERE sorting.idsorkind = @eSIOPE
		AND expensesorted.idexp = expense.idexp)
,0)

INSERT INTO #error (message)
SELECT 'Il movimento di entrata n. ' + CONVERT(varchar(6), income.nmov) + '/' + CONVERT(varchar(4), income.ymov) +
' non è correttamente classificato'
FROM income
JOIN #allincome
	ON #allincome.idinc = income.idinc
WHERE #allincome.amount <>
ISNULL(
	(SELECT SUM(incomesorted.amount)
	FROM incomesorted
	JOIN sorting
		ON incomesorted.idsor = sorting.idsor
	WHERE sorting.idsorkind = @iSIOPE
		AND incomesorted.idinc = income.idinc)
,0)

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

CREATE TABLE #SIOPE_mov
(
	idprog int identity(1,1),
	idprog_pro int,
	idinc int,
	idexp int,
	npro int,
	npay int,
	idsor_i int,
	idsor_e int,
	amount_class_i decimal(19,2),
	amount_class_e decimal(19,2),
	amount_i decimal(19,2),
	amount_e decimal(19,2),
	amount_i_prop decimal(19,2)
)

INSERT INTO #SIOPE_mov
(
	idinc, idexp, npro, npay,
	idsor_i, idsor_e,
	amount_class_i, amount_class_e,
	amount_i, amount_e
)
SELECT 
	AI.idinc, AE.idexp, AI.npro, AE.npay, 
	I_S.idsor, E_S.idsor,
	I_S.amount, E_S.amount,
	AI.amount, AE.amount
FROM incomesorted I_S
JOIN sorting SI
	ON SI.idsor = I_S.idsor
JOIN #allincome AI
	ON AI.idinc = I_S.idinc
LEFT OUTER JOIN #allexpense AE
	ON AE.idexp = AI.idexp
LEFT OUTER JOIN expensesorted E_S
	ON AE.idexp = E_S.idexp
LEFT OUTER JOIN sorting SE
	ON SE.idsor = E_S.idsor
WHERE SI.idsorkind = @iSIOPE
	AND (SE.idsorkind = @eSIOPE OR SE.idsorkind IS NULL)
ORDER BY AI.npro, AE.npay, AI.idinc, AE.idexp, I_S.idsor, E_S.amount

UPDATE #SIOPE_mov
SET amount_i_prop = 
CASE
	WHEN idexp IS NOT NULL
	THEN
		CASE
			WHEN amount_e <> 0 THEN (amount_class_i * amount_class_e) / amount_e
			ELSE 0
		END
	ELSE amount_class_i
END

UPDATE #SIOPE_mov
SET amount_i_prop = amount_i_prop +
amount_i -
ISNULL(
	(SELECT SUM(C.amount_i_prop)
	FROM #SIOPE_mov C
	WHERE #SIOPE_mov.idinc = C.idinc
		AND C.idprog <= #SIOPE_mov.idprog)
,0)
WHERE #SIOPE_mov.idprog =
	(SELECT MAX(idprog) FROM #SIOPE_MOV C
	WHERE C.idinc = #SIOPE_mov.idinc)

UPDATE #SIOPE_mov
SET idprog_pro = 1 + idprog -
ISNULL(
	(SELECT MIN(idprog) FROM #SIOPE_mov C
	WHERE C.npro = #SIOPE_mov.npro)
,0)

CREATE TABLE #tempPRO
(
	ypro int,
	npro int,
	idpro int,
	idinc int,
	curramount decimal(19,2)
)

INSERT INTO #tempPRO (ypro, npro, idpro, idinc, curramount)
SELECT p.ypro, p.npro, pb.idpro, i.idinc, i.curramount
FROM incomelastview i
JOIN proceeds_bank pb
	ON pb.kpro = i.kpro
	AND pb.idpro = i.idpro
JOIN proceeds p
	ON p.kpro = i.kpro
WHERE p.kproceedstransmission = @kproceedstransmission

CREATE TABLE #proceeds
(
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idinc int,
	idreg int,
	idpro int, 
	accountkind char(1),
	title_ver varchar(40),
	address_ver varchar(40),
	cap_ver varchar(5),
	location_ver varchar(30),
	province_ver varchar(2),
	cf_ver varchar(16),
	free_stamp char(1),
	proceedsdescr varchar(370),
	fulfilled char(1),
	idexp varchar(72),
	nbill varchar(7),
	totproceeds varchar(15),
	totproceedsdec decimal(19,2),
	gender_ver char(1),
	birthplace_ver varchar(30),
	birthdate_ver varchar(8),
	curramount decimal(19,2),
	cge char(10),
	idver int
)

INSERT INTO #proceeds
(
	ydoc, ndoc, idinc, 
	idreg, free_stamp,
	accountkind,
	title_ver,
	cf_ver,
	proceedsdescr,
	fulfilled,
	idexp, nbill,
	idpro,
	gender_ver, birthdate_ver, birthplace_ver,
	curramount, cge, idver
)
SELECT
	d.ypro, d.npro, e.idinc, 
	e.idreg, 'S',
	CASE
		WHEN ((d.flag & 8) = 0) THEN 'N'
		ELSE 'S'
	END,
	CASE
		WHEN DATALENGTH(ISNULL(c.title,'')) <= @len_registry_title
		THEN ISNULL(c.title,'') + SPACE(@len_registry_title - DATALENGTH(c.title))
		ELSE SUBSTRING(c.title, 1, @len_Registry_title)
	END,
	CASE 
		WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
		THEN 
			CASE
				WHEN DATALENGTH(c.cf) <= @len_cf
				THEN c.cf + SPACE(@len_cf - DATALENGTH(c.cf))
				ELSE SUBSTRING(c.cf, 1, @len_cf)
			END
		WHEN (ctc.flaghuman = 'S' AND ISNULL(c.cf,'') = '') OR (ctc.flaghuman = 'N')
		THEN
			CASE
				WHEN DATALENGTH(ISNULL(c.p_iva,'')) <= @len_pi
				THEN ISNULL(c.p_iva,'') + SPACE(@len_pi - DATALENGTH(ISNULL(c.p_iva,'')))
				ELSE SUBSTRING(c.p_iva, 1, @len_pi)
			END
		ELSE SPACE(@len_cf)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(e.description,'')) <= @len_desc_proceeds
		THEN ISNULL(e.description,'') + SPACE(@len_desc_proceeds - ISNULL(DATALENGTH(e.description),0))
		ELSE SUBSTRING(e.description, 1, @len_desc_proceeds)
	END,
	CASE
		WHEN ((l.flag & 1) = 1) THEN 'S'
		ELSE 'N'
	END,
	e.idpayment, ISNULL(REPLICATE('0',7-DATALENGTH(CONVERT(varchar(7),l.nbill))) + CONVERT(varchar(7),l.nbill),REPLICATE('0',7)),
	l.idpro, 
	CASE
		WHEN ctc.flaghuman = 'S' THEN ISNULL(c.gender,' ')
		ELSE ' '
	END,
	CASE
		WHEN ctc.flaghuman = 'S' AND c.birthdate IS NOT NULL
		THEN CONVERT(varchar(4),YEAR(c.birthdate))
		+ REPLICATE('0', 2 - LEN(CONVERT(varchar(2),MONTH(c.birthdate)))) + CONVERT(varchar(2),MONTH(c.birthdate))
		+ REPLICATE('0', 2 - LEN(CONVERT(varchar(2),DAY(c.birthdate)))) + CONVERT(varchar(2),DAY(c.birthdate))
		ELSE REPLICATE('0',8)
	END,
	CASE
		WHEN ctc.flaghuman = 'S'
		THEN
			CASE
				WHEN DATALENGTH(ISNULL(gc.title,'')) <= @len_birthplace
				THEN ISNULL(gc.title,'') + SPACE(@len_birthplace - DATALENGTH(ISNULL(gc.title,'')))
				ELSE SUBSTRING(gc.title, 1, @len_birthplace)
			END
		ELSE SPACE(@len_birthplace)
	END,
	#siope_mov.amount_i_prop,
	CASE
		WHEN SUBSTRING(S.sortcode,@npos,DATALENGTH(S.sortcode)) <= @len_sortcode
		THEN SUBSTRING(S.sortcode,@npos,DATALENGTH(S.sortcode)) +
		SPACE(@len_sortcode - DATALENGTH(SUBSTRING(S.sortcode,@npos,DATALENGTH(S.sortcode))))
		ELSE SUBSTRING(S.sortcode, @npos, @len_sortcode)
	END,
	#siope_mov.idprog_pro
FROM income e
JOIN incomelast l
	ON e.idinc = l.idinc
JOIN incometotal i
	ON i.idinc = e.idinc
JOIN proceeds d
	ON d.kpro = l.kpro
JOIN proceedstransmission t
	ON t.kproceedstransmission = d.kproceedstransmission
JOIN registry c
	ON c.idreg = e.idreg
JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = c.idcity
JOIN #tempPRO
	ON e.ymov = #tempPRO.ypro
	AND d.npro = #tempPRO.npro
	AND l.idpro = #tempPRO.idpro
	AND e.idinc = #tempPRO.idinc
JOIN #SIOPE_mov
	ON #SIOPE_mov.idinc = e.idinc
JOIN sorting S
	ON #siope_mov.idsor_i = S.idsor
WHERE t.yproceedstransmission = @y
	AND t.nproceedstransmission = @n

UPDATE #proceeds
SET ndocformatted = 
	SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),ndoc))) +
	CONVERT(varchar(7),ndoc),
totproceedsdec = 
	ISNULL((SELECT SUM(curramount) FROM #proceeds p2 WHERE p2.ydoc = #proceeds.ydoc AND p2.ndoc = #proceeds.ndoc),0)

UPDATE #proceeds SET totproceeds = 
	REPLICATE('0',1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),totproceedsdec))) +
	SUBSTRING(CONVERT(varchar(15),totproceedsdec ),1,
	DATALENGTH(CONVERT(varchar(15),totproceedsdec))-3) +
	SUBSTRING(CONVERT(varchar(15),totproceedsdec),
	DATALENGTH(CONVERT(varchar(15),totproceedsdec))-1,2)

DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase

-- Unificazione descrizioni di incasso per movimenti di entrata che sono stati accorpati
DECLARE @const varchar(20)SET @const = 'ACCORPAMENTO INCASSI'

UPDATE #proceeds
SET proceedsdescr = @const + SPACE(@len_desc_proceeds - LEN(@const))
WHERE
	(SELECT COUNT(*)
	FROM #proceeds i2
	WHERE i2.ydoc = #proceeds.ydoc
		AND i2.ndoc = #proceeds.ndoc
		AND i2.idpro = #proceeds.idpro) > 1
	AND 
		(SELECT COUNT(*)
		FROM #proceeds i2
		WHERE i2.ydoc = #proceeds.ydoc
			AND i2.ndoc = #proceeds.ndoc
			AND i2.idpro = #proceeds.idpro) <>
		(SELECT COUNT(*)
		FROM #proceeds i2
		WHERE i2.ydoc = #proceeds.ydoc
			AND i2.ndoc = #proceeds.ndoc
			AND i2.idpro = #proceeds.idpro
			AND i2.proceedsdescr = #proceeds.proceedsdescr)

-- La tabella di rif. della banca porta un'unica descrizione "Incasso per Cassa"
DECLARE @code_Encashment varchar(2)
SET @code_Encashment = '51'

CREATE TABLE #final
(
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idreg int,
	idpro int, 
	accountkind char(1),
	title_ver varchar(40),
	address_ver varchar(40),
	cap_ver varchar(5),
	location_ver varchar(30),
	province_ver varchar(2),
	cf_ver varchar(16),
	free_stamp char(1),
	proceedsdescr varchar(370),
	fulfilled char(1),
	nbill varchar(7),
	totproceeds varchar(15),
	proceedskind char(1), -- S Singolo; C Collettivo
	gender_ver char(1),
	birthplace_ver varchar(30),
	birthdate_ver varchar(8),
	curramount decimal(19,2),
	cge varchar(10),
	idver int,
	stamphandling char(2)
)

INSERT INTO #final
(
	ydoc, ndoc, ndocformatted, idreg, idpro, accountkind, title_ver, 
	cf_ver, free_stamp, proceedsdescr, fulfilled, nbill,
	totproceeds, gender_ver, birthplace_ver, birthdate_ver, curramount, cge,
	idver
)
SELECT
	ydoc, ndoc, ndocformatted, idreg, idpro, accountkind, title_ver, 
	cf_ver, free_stamp, proceedsdescr, fulfilled, nbill,
	totproceeds, gender_ver, birthplace_ver, birthdate_ver, SUM(curramount), cge,
	idver
FROM #proceeds
GROUP BY
	ydoc, ndoc, ndocformatted, idreg, idpro, accountkind, title_ver, 
	cf_ver, free_stamp, proceedsdescr, fulfilled, nbill,
	totproceeds, gender_ver, birthplace_ver, birthdate_ver, cge,
	idver

UPDATE #final
SET proceedskind = 
CASE
	WHEN
		(SELECT COUNT(*)
		FROM #final f2
		WHERE f2.ydoc = #final.ydoc
			AND f2.ndoc = #final.ndoc
			--AND f2.idver = #final.idver
		) = 1
	THEN 'S'
	ELSE 'C'
END

-- Inizio Controllo aggiunto su richiesta della Bca Roma anche se nelle specifiche non è specificato con l'avallo di francesco
DECLARE @cfente varchar(16)
SELECT @cfente = 
CASE
	WHEN DATALENGTH(ISNULL(cf,'')) <= @len_cf THEN ISNULL(cf, '') + SPACE(@len_cf - DATALENGTH(ISNULL(cf,'')))
	ELSE SUBSTRING(cf, 1, @len_cf)
END
FROM license

DECLARE @empty varchar(16)
SET @empty = SPACE(@len_cf)

UPDATE #final
SET cf_ver = @cfente WHERE (cf_ver IS NULL) OR (cf_ver = @empty)

DECLARE @limitcfnull decimal(19,2)
SET @limitcfnull = 5164.57

INSERT INTO #error
SELECT 'Nella reversale ' + CONVERT(varchar(6), ndoc) + ' i movimenti imputati al versante ' + ISNULL(registry.title,'XXX') + 
' non possono essere trasmessi in quanto bisogna specificare il C.F. (P. IVA) in quanto l''importo degli stessi è superiore a '
+ CONVERT (varchar(20), @limitcfnull) + '. Impostare il c.f./p. iva'
FROM #final
LEFT OUTER JOIN registry
	on #final.idreg = registry.idreg
WHERE cf_ver = @empty
AND curramount > @limitcfnull

IF (SELECT COUNT(*) FROM #error)>0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Fine Controllo
DECLARE @limitamount decimal(19,2)
SET @limitamount = 77.47
UPDATE #final
SET stamphandling = 
	CASE
		WHEN curramount <= @limitamount THEN '00'
		ELSE '13'
	END

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
UPDATE #final
SET address_ver =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(address) <= @len_address OR address IS NULL
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@len_address),1,@len_address - ISNULL(DATALENGTH(address),0))
		ELSE SUBSTRING(address,1,@len_address)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg)
,SPACE(@len_address)),
cap_ver =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(cap) <= @len_cap OR cap IS NULL
		THEN SUBSTRING(REPLICATE('0',@len_cap),1,@len_cap - ISNULL(DATALENGTH(cap),0)) + ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg)
,SPACE(@len_cap)),
location_ver =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(location) <= @len_location OR location IS NULL
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@len_location),1,@len_location - ISNULL(DATALENGTH(location),0))
		ELSE SUBSTRING(location,1,@len_location)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg)
,SPACE(@len_location)),
province_ver =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(province) <= @len_province OR province IS NULL
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@len_province),1,@len_province - ISNULL(DATALENGTH(province),0))
		ELSE SUBSTRING(province,1,@len_province)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg)
,SPACE(@len_province))

INSERT INTO #trace (ndoc, nrow, out_str)
SELECT
	#final.ndoc, 1,
	-- Tipo Record
	'RE' +
	-- Codice Banca
	'01' +
	-- Codice Ente
	@cod_department +
	-- Esercizio
	CONVERT(varchar(4), #final.ydoc) +
	-- Numero Reversale
	#final.ndocformatted +
	-- Numero Debitore
	REPLICATE('0', @len_idpro - DATALENGTH(CONVERT(varchar(7),#final.idver))) + CONVERT(varchar(7),#final.idver) +
	-- Anno Residuo
	'0000' +
	-- Capitolo
	SPACE(6) +
	-- Articolo
	'000' +
	-- Lettera
	SPACE(1) +
	-- Importo Reversale
	totproceeds +
	-- Tipo Reversale
	proceedskind +
	-- Codice Partitario
	SPACE(7) +
	-- Conto Bankit
	REPLICATE('0',7) +
	-- Flag fruttifero
	accountkind + 
	-- Flag regolarizzazione
	fulfilled +
	-- Flag girofondi
	'N' +
	-- Codice Fiscale Debitore
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_cf)
		ELSE cf_ver
	END +
	-- Cognome Debitore
	CASE
		WHEN fulfilled = 'S' THEN 'regol' + SPACE(@len_registry_title - LEN('regol'))
		ELSE title_ver
	END +
	-- Nome Debitore
	SPACE(30) +
	-- Sesso Debitore
	CASE
		WHEN fulfilled = 'S' THEN ' '
		ELSE gender_ver
	END +
	-- Indirizzo Debitore
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_address)
		ELSE address_ver
	END +
	-- Località Debitore
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_location)
		ELSE location_ver
	END +
	-- Provincia Debitore
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_province)
		ELSE province_ver
	END +
	-- Località Nascita Debitore
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_location)
		ELSE birthplace_ver
	END +
	-- Data di nascita Debitore
	CASE
		WHEN fulfilled = 'S' THEN REPLICATE('0',8)
		ELSE birthdate_ver
	END +
	-- C.A.P. Debitore
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_cap)
		ELSE cap_ver
	END + 
	-- Modalità Incasso
	'01' +
	-- Importo Debitore
	REPLICATE('0',1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),curramount))) +
	SUBSTRING(CONVERT(varchar(15),curramount ),1,
	DATALENGTH(CONVERT(varchar(15),curramount))-3) +
	SUBSTRING(CONVERT(varchar(15),curramount),
	DATALENGTH(CONVERT(varchar(15),curramount))-1,2) +
	-- Codice esenzione bollo
	stamphandling +
	-- Importo Bollo
	REPLICATE('0', 7) +
	-- Codice Motivo Incasso
	CASE
		WHEN fulfilled = 'S' THEN SPACE(2)
		ELSE '00'
	END +
	-- Descrizione Motivo Incasso
	CASE 
		WHEN fulfilled = 'S' THEN SPACE(@len_desc_proceeds)
		ELSE proceedsdescr
	END +
	-- Anno Emissione Reversale
	'0000' +
	-- Bolletta
	nbill +
	-- CGE
	cge +
	-- Filler
	SPACE(11) +
	-- Divisa
	'E' +
	-- Codice filiale mittente
	@cod_filiale
FROM #final
ORDER BY #final.ydoc, #final.ndoc, #final.idpro

-- Rimozione dei caratteri non consentiti
UPDATE #trace SET out_str = 
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
'Á','a'),'À','a'),'È','e'),'Í','i'),'Ì','i'),'Ó','o'),'Ò','o'),'Ú','u'),
CHAR(9),' '),CHAR(10),' '),CHAR(13),' ')

SELECT out_str FROM #trace
ORDER BY y, n, ndoc, nrow
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


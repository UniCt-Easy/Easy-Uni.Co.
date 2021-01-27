
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_bancaroma]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_bancaroma]
GO

CREATE        PROCEDURE [trasmele_expense_bancaroma]
(
	@y int,
	@n int
)
AS BEGIN
-- Attenzione esiste un solo tipo record (MA) per i mandati plurisiope bisogna generare N record MA opportunamente spezzettati
-- per ogni codice SIOPE

DECLARE @len_ndoc int
SET @len_ndoc = 7

DECLARE @len_amount int
SET @len_amount = 15

DECLARE @len_idpay int
SET @len_idpay = 4

DECLARE @len_idpro int
SET @len_idpro = 15

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

DECLARE @len_ABI int
SET @len_ABI = 5

DECLARE @len_CAB int
SET @len_CAB = 5

DECLARE @len_cc int
SET @len_cc = 15

DECLARE @len_cin int
SET @len_cin = 1

DECLARE @len_desc_paymethod int
SET @len_desc_paymethod = 30

DECLARE @len_desc_payment int
SET @len_desc_payment = 60

DECLARE @len_sortcode int
SET @len_sortcode = 10

DECLARE @len_deputy int
SET @len_deputy = 30

DECLARE @len_idstamphandling int
SET @len_idstamphandling = 2

DECLARE @len_birthplace int
SET @len_birthplace = 30

DECLARE @ABI_codebcaroma varchar(5)
SET @ABI_codebcaroma = '03002'

DECLARE @idtreasurer int
DECLARE @kpaymenttransmission int

SELECT @idtreasurer = idtreasurer,
@kpaymenttransmission = kpaymenttransmission
FROM paymenttransmission
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n

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
SELECT @cod_department = ISNULL(agencycodefortransmission,''),
@cod_filiale = ISNULL(cabcodefortransmission, '')
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @len_agencycode int
SET @len_agencycode = 6

DECLARE @len_codfiliale int
SET @len_codfiliale = 5

DECLARE @cf_agency char(16)
SELECT @cf_agency = cf FROM license

CREATE TABLE #error (message varchar(400))

-- Inizio Sezione Controlli
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
IF(
(SELECT COUNT(*) FROM payment
WHERE kpaymenttransmission = @kpaymenttransmission) = 0)
BEGIN
	INSERT INTO #error
	VALUES('La distinta di trasmissione ' + CONVERT(varchar(4),@y) + '/'
	+ CONVERT(varchar(6),@n) + ' è vuota')
END
-- CONTROLLO N. 1. Presenza dei dati dell'ente
DECLARE @error char(1)
SET @error = 'N'
DECLARE @message varchar(400)
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

-- CONTROLLO N. 3. Movimento di Spesa senza Modalità di Pagamento
INSERT INTO #error (message)
(SELECT 'Per il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' non è stata scelta una modalità di pagamento'
FROM paymentcommunicated
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n
	AND idpaymethod IS NULL)

-- CONTROLLO N. 5. Movimento di Spesa con Modalità di Pagamento non configurata
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' la modalità di pagamento scelta non è configurata, Andare in Configurazione - Anagrafica - Modalità di Pagamento'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND (paymethod.methodbankcode IS NULL OR REPLACE(paymethod.methodbankcode,' ','') = '')
)

-- CONTROLLO N. 6. Codice ABI e CAB devono essere valorizzati nel caso di modalità di pagamento 02 e 03
INSERT INTO #error (message)
(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento scelta non è stato assegnato il codice ABI / CAB.'
FROM paymentcommunicated
	JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.idpaymethod IN ('02','03')
	AND (paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
	AND (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
)

-- CONTROLLO N. 6BIS. Se il codice ABI è quello della Banca di Roma la mod. di pagamento deve essere la 02
INSERT INTO #error (message)
(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' la modalità di pagamento scelta non è congrua con l''ABI specificato.'
FROM paymentcommunicated
	JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode <> '02'
	AND (paymentcommunicated.idbank = @ABI_codebcaroma) 
)

-- CONTROLLO N. 7. Il codice ABI, CAB e il CIN non devono eccedere la lunghezza massima nel caso di modalità di pagamento 02 e 03
INSERT INTO #error (message)
(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento il codice ABI eccede la lunghezza di '
+ CONVERT(varchar(3),@len_ABI) + ' caratteri e/o il codice CAB eccede la lunghezza di '
+ CONVERT(varchar(3),@len_CAB) + ' caratteri e/o il CIN eccede la lunghezza di '
+ CONVERT(varchar(3),@len_cin) + ' caratteri'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode IN ('02','03')
	AND (
	(DATALENGTH(paymentcommunicated.idcab) > @len_CAB)
	OR (DATALENGTH(paymentcommunicated.idbank) > @len_ABI)
	OR (DATALENGTH(paymentcommunicated.cin) > @len_cin)
		)
	)
-- CONTROLLO N. 8. Conto Corrente valorizzato e di lunghezza massima 12 caratteri nel caso di modalità di pagamento 02, 03
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode IN ('02','03')
AND (paymentcommunicated.cc IS NULL
	OR REPLACE(paymentcommunicated.cc,' ','') = ''
	OR DATALENGTH(ISNULL(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(paymentcommunicated.cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ','')
	,'')) > @len_cc)
)
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
	+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov)
	+ ' nella modalità di pagamento non è stato il C/C o la lunghezza del C/C eccede i '
	+ CONVERT(varchar(2),@len_cc) + ' caratteri'
	FROM paymentcommunicated
	JOIN paymethod
		ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
	WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode IN ('02','03')
	AND (paymentcommunicated.cc IS NULL
		OR REPLACE(paymentcommunicated.cc,' ','') = ''
		OR DATALENGTH(ISNULL(paymentcommunicated.cc,'')) > @len_cc)
	)
END

-- CONTROLLO N. 9. Presenza tipologia dei beneficiari
DECLARE @denomcred_err varchar(200)
INSERT INTO #error (message)
SELECT 'Il beneficiario ' + ISNULL(R.title,'XXX') + ' con codice ' + CONVERT(varchar(6),R.idreg) + ' non ha una tipologia associata. E'' necessario inserirla'
FROM expense E
JOIN expenselast L
	ON E.idexp = L.idexp
JOIN payment P
	ON P.kpay = L.kpay
JOIN registry R
	ON R.idreg = E.idreg
WHERE R.idregistryclass IS NULL
	AND P.kpaymenttransmission = @kpaymenttransmission

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
-- Attenzione! Altri controlli sono presenti nel testo della SP in quanto non era possibile calcolarli a priori
-- I controlli vengono riconosciuti in quanto il prefisso adoperato come linea di commento sarà CONTROLLO N. x.
-- Fine Sezione Controlli

SET @cod_department = @cod_department + SUBSTRING(SPACE(@len_agencycode),1,@len_agencycode - DATALENGTH(@cod_department))
SET @cod_filiale = SUBSTRING(REPLICATE('0',@len_codfiliale),1,@len_codfiliale - DATALENGTH(@cod_filiale)) + @cod_filiale

CREATE TABLE #trace
(
	y int,
	n int,
	ndoc int,
	nrow int,
	out_str varchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS
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

-- 1. Inserimento dei movimenti di spesa PROPRI della trasmissione
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
WHERE P.kpaymenttransmission = @kpaymenttransmission

-- 2. Inserimento dei movimenti di entrata presenti nelle reversali associate a questa trasmissione
INSERT INTO #allincome
(
	idinc, idexp, kpro, ypro, npro, kproceedstransmission, yproceedstransmission, nproceedstransmission, amount
)
SELECT
	I.idinc, I.idpayment, L.kpro, P.ypro, P.npro, P.kproceedstransmission, PT.yproceedstransmission, PT.nproceedstransmission, T.curramount
FROM income I
JOIN incomelast L
	ON I.idinc = L.idinc
JOIN incometotal T
	ON T.idinc = I.idinc
JOIN #allexpense E
	ON E.idexp = I.idpayment
JOIN proceeds P
	ON P.kpro = L.kpro
JOIN proceedstransmission PT
	ON PT.kproceedstransmission = P.kproceedstransmission

-- 3. Inserimento dei movimenti di spesa non appartenenti alla trasmissione corrente ma che hanno riferimenti con movimenti di entrata
-- presenti in una reversale che dovrà comparire in questa trasmissione
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
WHERE (PT.kpaymenttransmission <> @kpaymenttransmission OR PT.kpaymenttransmission IS NULL)
AND EXISTS
	(SELECT * FROM incomelast
	JOIN income
		ON income.idinc = incomelast.idinc
	WHERE incomelast.kpro IN (SELECT kpro FROM #allincome)
	AND income.idpayment = L.idexp)

-- 4. Inserimento dei movimenti di entrata presenti nelle reversali collegati anche se non figurano nella trasmissione
INSERT INTO #allincome
(
	idinc, idexp, kpro, ypro, npro, kproceedstransmission, yproceedstransmission, nproceedstransmission, amount
)
SELECT
	I.idinc, I.idpayment, L.kpro, P.ypro, P.npro, P.kproceedstransmission, PT.yproceedstransmission, PT.nproceedstransmission, T.curramount
FROM income I
JOIN incomelast L
	ON I.idinc = L.idinc
JOIN incometotal T
	ON T.idinc = I.idinc
JOIN proceeds P
	ON P.kpro = L.kpro
JOIN proceedstransmission PT
	ON PT.kproceedstransmission = P.kproceedstransmission
WHERE L.kpro IN (SELECT kpro FROM #allincome I2)
AND NOT EXISTS (SELECT idinc FROM #allincome I3 WHERE I3.idinc = I.idinc)

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
	AND SE.idsorkind = @eSIOPE
ORDER BY AI.npro, AE.npay, AI.idinc, AE.idexp, I_S.idsor, E_S.amount

UPDATE #SIOPE_mov
SET amount_i_prop = 
CASE
	WHEN amount_e <> 0 THEN (amount_class_i * amount_class_e) / amount_e
	ELSE 0
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

CREATE TABLE #SIOPE_onlyexp
(
	idexp int,
	sortcode char(10),
	amount decimal(19,2)
)

INSERT INTO #SIOPE_onlyexp (idexp, sortcode, amount)
SELECT #allexpense.idexp, 
	CASE
		WHEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) <= @len_sortcode
		THEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) +
		SPACE(@len_sortcode - DATALENGTH(SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode))))
		ELSE SUBSTRING(sorting.sortcode, @npos, @len_sortcode)
	END,
SUM(expensesorted.amount)
FROM #allexpense
JOIN expensesorted
	ON expensesorted.idexp = #allexpense.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE #allexpense.haspro = 'N'
	AND sorting.idsorkind = @eSIOPE
GROUP BY #allexpense.idexp, sorting.sortcode

INSERT INTO #SIOPE_onlyexp (idexp, sortcode, amount)
SELECT
	ES.idexp, 
	CASE
		WHEN SUBSTRING(S.sortcode,@npos,DATALENGTH(S.sortcode)) <= @len_sortcode
		THEN SUBSTRING(S.sortcode,@npos,DATALENGTH(S.sortcode)) +
		SPACE(@len_sortcode - DATALENGTH(SUBSTRING(S.sortcode,@npos,DATALENGTH(S.sortcode))))
		ELSE SUBSTRING(S.sortcode, @npos, @len_sortcode)
	END,
	SUM(ES.amount) - 
	ISNULL(
		(SELECT SUM(amount_i_prop)
		FROM #SIOPE_mov M
		JOIN expense E
			ON E.idexp = M.idexp
		JOIN income I
			ON I.idinc = M.idinc
		WHERE M.idexp = ES.idexp
			AND M.idsor_e = ES.idsor
			AND ((I.autokind = 4 AND I.idreg = E.idreg) OR (I.autokind = 6)))
	,0)
FROM expensesorted ES
JOIN #allexpense
	ON #allexpense.idexp = ES.idexp
JOIN sorting S
	ON ES.idsor = s.idsor
WHERE S.idsorkind = @eSIOPE
	AND #allexpense.haspro = 'S'
GROUP BY ES.idexp, S.sortcode, ES.idsor

CREATE TABLE #tempPAY
(
	idexp int,
	ypay int,
	npay int,
	idpay int,
	curramount decimal(19,2),
	totpayment decimal(19,2)
)

INSERT INTO #tempPAY (idexp, curramount, ypay, npay, idpay, totpayment)
SELECT
	e.idexp, e.curramount, p.ypay, p.npay, pb.idpay, 
	ISNULL((SELECT SUM(curramount) FROM expenselastview e2 WHERE e2.kpay = e.kpay),0)
FROM expenselastview e
JOIN payment_bank pb
	ON e.kpay = pb.kpay
	AND e.idpay = pb.idpay
JOIN payment p
	ON pb.kpay = p.kpay
WHERE p.kpaymenttransmission = @kpaymenttransmission

CREATE TABLE #payment
(
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idexp int,
	curramount decimal(19,2),
	idreg int,
	idpay int,
	idpaymethodTRS varchar(10),
	desc_paymethod varchar(30),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25), -- Viene impostato a 25 in quanto gli utenti possono adoperare un C/C che eccede tale lunghezza
	cin char(1),
	title_ben varchar(140),
	address_ben varchar(40),
	cap_ben varchar(5),
	location_ben varchar(30),
	province_ben varchar(2),
	cf_ben varchar(16),
	gender_ben char(1),
	birthdate_ben varchar(8),
	birthplace_ben varchar(30),
	stamp_charge varchar(2),
	free_stamp char(1),
	paymentdescr varchar(370),
	fulfilled char(1),
	iddeputy int,
	nbill int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	curramountpro decimal(19,2),
	idpro int,
	idregpro int,
	autokind tinyint,
	totpayment int, -- Totale mandato, calcolato già come int x formattazione
	netamount decimal(19,2),
	yproceedstransmission int,
	idben int,
	iddeb int,
	cgu char(10)
)

CREATE TABLE #deputy
(
	iddeputy int,
	title_deputy varchar(30)
)

INSERT INTO #payment
(
	ydoc, ndoc, idexp, curramount,
	idreg, 
	stamp_charge,
	free_stamp,
	idpaymethodTRS,
	desc_paymethod,
	ABI,
	CAB,
	cc,
	cin,
	title_ben, cf_ben, paymentdescr, fulfilled, iddeputy,
	nbill, idpay, 
	gender_ben, birthdate_ben, birthplace_ben, totpayment, netamount, cgu,
	idinc, ymov_income, nmov_income, ypro, npro, nproformatted, curramountpro, idpro, idregpro, yproceedstransmission, iddeb
)
SELECT
	d.ypay, d.npay, s.idexp, i.curramount,
	s.idreg, 
	CASE
		WHEN m.methodbankcode = '05' THEN '00'
		ELSE
		CASE 
			WHEN DATALENGTH(ISNULL(tb.handlingbankcode,'')) <= @len_idstamphandling
			THEN REPLICATE('0', @len_idstamphandling - DATALENGTH(ISNULL(tb.handlingbankcode,''))) + ISNULL(tb.handlingbankcode,'')
			ELSE SUBSTRING(tb.handlingbankcode,1,@len_idstamphandling)
		END
	END,
	CASE
		WHEN ISNULL(tb.handlingbankcode,' ') IN (' ','') THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN m.methodbankcode = '99' THEN '03'
		ELSE m.methodbankcode
	END,
	CASE
		WHEN DATALENGTH(ISNULL(m.description,'')) <= @len_desc_paymethod
		THEN ISNULL(m.description,'') + SPACE(@len_desc_paymethod - DATALENGTH(ISNULL(m.description,'')))
		ELSE SUBSTRING(m.description,1, @len_desc_paymethod)
	END,
	CASE
		WHEN m.methodbankcode = '99' THEN '00000'
		ELSE
		CASE
			WHEN DATALENGTH(ISNULL(l.idbank,'')) <= @len_ABI
			THEN SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(l.idbank,''))) + ISNULL(l.idbank,'')
			ELSE SUBSTRING(l.idbank,1,@len_ABI)
		END
	END,
	CASE
		WHEN m.methodbankcode = '99' THEN '00000'
		ELSE
		CASE
			WHEN DATALENGTH(ISNULL(l.idcab,'')) <= @len_CAB
			THEN SUBSTRING(REPLICATE('0',@len_CAB),1,@len_CAB - DATALENGTH(ISNULL(l.idcab,''))) + ISNULL(l.idcab,'')
			ELSE SUBSTRING(l.idcab,1,@len_CAB)
		END
	END,
	CASE
		WHEN l.idbank = @ABI_codebcaroma
		THEN
			CASE
				WHEN DATALENGTH(ISNULL(l.cc,'')) <= @len_cc
				THEN REPLICATE('0', @len_cc - DATALENGTH(ISNULL(l.cc,''))) + ISNULL(l.cc,'')
				ELSE SUBSTRING(l.cc, 1, @len_cc)
			END
		WHEN l.idbank IS NOT NULL AND l.idbank <> @ABI_codebcaroma
		THEN 
			CASE
				WHEN DATALENGTH(ISNULL(l.cc,'')) <= @len_cc
				THEN ISNULL(l.cc,'') + SPACE(@len_cc - DATALENGTH(ISNULL(l.cc,'')))
				ELSE SUBSTRING(l.cc, 1, @len_cc)
			END
	END,
	CASE
		WHEN DATALENGTH(ISNULL(l.cin,'')) <= @len_cin
		THEN ISNULL(l.cin,'') + SPACE(@len_cin - DATALENGTH(ISNULL(l.cin,'')))
		ELSE SUBSTRING(l.cin,1,@len_cin)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(c.title, '')) <= @len_registry_title
		THEN ISNULL(c.title,'') + SUBSTRING(SPACE(@len_registry_title),1,@len_registry_title - DATALENGTH(ISNULL(c.title,'')))
		ELSE SUBSTRING(c.title, 1, @len_registry_title)
	END,
	CASE 
		WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL
		THEN 
			CASE
				WHEN DATALENGTH(c.cf) <= @len_cf
				THEN c.cf + SUBSTRING(SPACE(@len_cf),1,@len_cf - DATALENGTH(c.cf))
				ELSE SUBSTRING(c.cf, 1, @len_cf)
			END
		WHEN (ctc.flaghuman = 'S' AND c.cf IS NULL) OR (ctc.flaghuman = 'N')
		THEN
			CASE
				WHEN DATALENGTH(ISNULL(c.p_iva,'')) <= @len_pi
				THEN ISNULL(c.p_iva,'') + SUBSTRING(SPACE(@len_pi), 1, @len_pi - DATALENGTH(ISNULL(c.p_iva,'')))
				ELSE SUBSTRING(c.p_iva, 1, @len_pi)
			END
	END,
	CASE 
		WHEN DATALENGTH(ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'')) <= @len_desc_payment
		THEN ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'') +
			SPACE(@len_desc_payment -
			DATALENGTH(ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'')))
		ELSE SUBSTRING(ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,''),1, @len_desc_payment)
	END,
	CASE
		WHEN ((l.flag & 1) <> 0) THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN m.allowdeputy = 'S' THEN l.iddeputy -- Codice Mod. Banca 01
		ELSE NULL
	END,
	ISNULL(REPLICATE('0', 7-DATALENGTH(CONVERT(varchar(7),l.nbill))) + CONVERT(varchar(7),l.nbill),REPLICATE('0',7)),
	l.idpay,
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
	CONVERT(int,#tempPAY.totpayment * 100),
	SOE.amount, SOE.sortcode,
	-- CAMPI FITTIZZI MESSI A ZERO O SPAZIO
	'', 0, 0, 0, 0, REPLICATE('0',7), 0, 0, 0, 0, 0
FROM expense s
JOIN expenselast l
	ON s.idexp = l.idexp
JOIN expensetotal i
	ON i.idexp = s.idexp
JOIN payment d
	ON d.kpay = l.kpay
JOIN paymenttransmission t
	ON t.kpaymenttransmission = d.kpaymenttransmission
JOIN paymethod m
	ON l.idpaymethod = m.idpaymethod
LEFT OUTER JOIN registrypaymethod mcd
	ON mcd.idregistrypaymethod = l.idregistrypaymethod
	AND mcd.idreg = s.idreg
JOIN registry c
	ON c.idreg = s.idreg
JOIN registryclass ctc 
	ON ctc.idregistryclass = c.idregistryclass
LEFT OUTER JOIN stamphandling tb
	ON d.idstamphandling = tb.idstamphandling
LEFT OUTER JOIN geo_city GC
	ON GC.idcity = c.idcity
JOIN #tempPAY
	ON s.ymov = #tempPAY.ypay
	AND d.npay = #tempPAY.npay
	AND l.idpay = #tempPAY.idpay
	AND s.idexp = #tempPAY.idexp
JOIN #SIOPE_onlyexp SOE
	ON s.idexp = SOE.idexp
WHERE t.ypaymenttransmission = @y
	AND t.npaymenttransmission = @n

-- Inizio Formattazione del C/C	
-- Banca di Roma ammette come C/C numeri e caratteri maiuscoli, il C/C deve essere allineato a destra, carattere di padding lo 0 a seconda della banca
-- se il c/c è della Banca di Roma non ci sono caratteri diversi da numeri altrimenti possono restare
UPDATE #payment
SET cc = 
	UPPER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ',''))
WHERE ABI = @ABI_codebcaroma

UPDATE #payment SET cc = REPLICATE('0',@len_cc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
-- Fine Formattazione del C/C

IF (SELECT COUNT(*) FROM #payment WHERE cf_ben IS NULL OR cf_ben = SPACE(@len_cf)) > 0
BEGIN
	IF @cf_agency IS NULL OR @cf_agency = SPACE(@len_cf)
	BEGIN
		INSERT INTO #error (message) VALUES ('Il codice fiscale dell''ente è assente')
	END
	IF (SELECT COUNT(*) FROM #error) > 0
	BEGIN
		SELECT * FROM #error
		RETURN
	END

	UPDATE #payment SET cf_ben = @cf_agency WHERE cf_ben IS NULL OR cf_ben = SPACE(@len_cf)
END

UPDATE #payment
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),ndoc))) + CONVERT(varchar(7),ndoc)

DECLARE @maxincomephase char(1)
SELECT @maxincomephase = MAX(nphase) FROM incomephase

-- Aggiunta delle reversali associate al movimento di spesa
INSERT INTO #payment
(
	ydoc, ndoc, idexp, curramount,
	idreg, stamp_charge, free_stamp,
	idpaymethodTRS, desc_paymethod, ABI, CAB, cc, cin,
	title_ben, cf_ben, fulfilled, iddeputy,
	nbill, idpay, totpayment,
	gender_ben, birthdate_ben, birthplace_ben,
	ndocformatted,
	idinc, ypro, npro, 
	curramountpro, idregpro, autokind,
	ymov_income, nmov_income, idpro,  
	paymentdescr,
	yproceedstransmission,
	cgu,
	netamount,
	nproformatted, iddeb
)
SELECT
	p.ydoc, p.ndoc, p.idexp, p.curramount,
	p.idreg, p.stamp_charge, p.free_stamp,
	p.idpaymethodTRS, p.desc_paymethod, p.ABI, p.CAB, p.cc, p.cin,
	p.title_ben, p.cf_ben, p.fulfilled, p.iddeputy,
	p.nbill, p.idpay, p.totpayment,
	p.gender_ben, p.birthdate_ben, p.birthplace_ben,
	p.ndocformatted,
	e.idinc, di.ypro, di.npro,
	ie.curramount, e.idreg, e.autokind,
	e.ymov, e.nmov, l.idpro,
	CASE 
		WHEN DATALENGTH(e.description) <= @len_desc_payment
		THEN e.description + SPACE(@len_desc_payment - DATALENGTH(e.description))
		ELSE SUBSTRING(e.description, 1, @len_desc_payment)
	END,
	pt.yproceedstransmission,
	CASE
		WHEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) <= @len_sortcode
		THEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) +
		SPACE(@len_sortcode - DATALENGTH(SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode))))
		ELSE SUBSTRING(sorting.sortcode, @npos, @len_sortcode)
	END,
	#SIOPE_mov.amount_i_prop, 
	SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),di.npro))) +
	CONVERT(varchar(7),di.npro), #SIOPE_mov.idprog_pro
FROM
(SELECT
	DISTINCT pa.ydoc, pa.ndoc, pa.idexp, pa.curramount,
	pa.idreg, pa.stamp_charge, pa.free_stamp,
	pa.idpaymethodTRS, pa.desc_paymethod, pa.ABI, pa.CAB, pa.cc, pa.cin,
	pa.title_ben, pa.cf_ben, pa.fulfilled, pa.iddeputy,
	pa.nbill, pa.idpay, pa.totpayment,
	pa.gender_ben, pa.birthdate_ben, pa.birthplace_ben,
	pa.ndocformatted
FROM #payment pa) AS p
JOIN income e
	ON e.idpayment = p.idexp
JOIN incomelast l
	ON e.idinc = l.idinc 
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN proceeds di
	ON di.kpro = l.kpro
JOIN proceedstransmission pt
	ON pt.kproceedstransmission = di.kproceedstransmission
JOIN #SIOPE_mov
	ON di.npro = #SIOPE_mov.npro
	AND e.idinc = #SIOPE_mov.idinc
JOIN sorting
	ON sorting.idsor = #SIOPE_mov.idsor_e
LEFT OUTER JOIN expense
	ON expense.idexp = e.idpayment
WHERE e.nphase = @maxincomephase
	AND e.ymov = @y
	AND ((e.autokind = 4 AND e.idreg = expense.idreg) OR (e.autokind = 6))
	AND ie.ayear = @y

INSERT INTO #deputy (iddeputy, title_deputy)
SELECT
	DISTINCT #payment.iddeputy,
	CASE
		WHEN DATALENGTH(ISNULL(registry.title,'')) <= @len_deputy
		THEN ISNULL(registry.title,'') 
		+ SUBSTRING(SPACE(@len_deputy),1,@len_deputy - DATALENGTH(ISNULL(registry.title,'')))
		ELSE SUBSTRING(registry.title, 1 ,@len_deputy)
	END
FROM #payment
JOIN registry
	ON #payment.iddeputy = registry.idreg

-- Unificazione descrizioni di pagamento per movimenti di spesa che sono stati accorpati
DECLARE @const_descr varchar(60)
SET @const_descr = 'ACCORPAMENTO PAGAMENTI'
UPDATE #payment
SET paymentdescr = @const_descr + SPACE(@len_desc_payment - LEN(@const_descr))
WHERE
	(SELECT COUNT(*)
	FROM #payment p2
	WHERE p2.ydoc = #payment.ydoc
		AND p2.ndoc = #payment.ndoc
		AND p2.idpay = #payment.idpay
		AND p2.autokind IS NULL) > 1
	AND 
		(SELECT COUNT(*)
		FROM #payment p2
		WHERE p2.ydoc = #payment.ydoc
			AND p2.ndoc = #payment.ndoc
			AND p2.idpay = #payment.idpay
			AND p2.autokind IS NULL) <>
		(SELECT COUNT(*)
		FROM #payment p2
		WHERE p2.ydoc = #payment.ydoc
			AND p2.ndoc = #payment.ndoc
			AND p2.idpay = #payment.idpay
			AND p2.paymentdescr = #payment.paymentdescr
			AND p2.autokind IS NULL)
AND autokind IS NULL

SET @const_descr = 'SU ACCORPAMENTO PAGAMENTI'
UPDATE #payment
SET paymentdescr = @const_descr + SPACE(@len_desc_payment - LEN(@const_descr))
WHERE
	(SELECT COUNT(*)
	FROM #payment p2
	WHERE p2.ydoc = #payment.ydoc
		AND p2.ndoc = #payment.ndoc
		AND p2.idpay = #payment.idpay
		AND p2.autokind IS NOT NULL) > 1
	AND 
		(SELECT COUNT(*)
		FROM #payment p2
		WHERE p2.ydoc = #payment.ydoc
			AND p2.ndoc = #payment.ndoc
			AND p2.idpay = #payment.idpay
			AND p2.autokind IS NOT NULL) <>
		(SELECT COUNT(*)
		FROM #payment p2
		WHERE p2.ydoc = #payment.ydoc
			AND p2.ndoc = #payment.ndoc
			AND p2.idpay = #payment.idpay
			AND p2.paymentdescr = #payment.paymentdescr
			AND p2.autokind IS NOT NULL)
AND autokind IS NOT NULL

CREATE TABLE #final
(
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idreg int,
	idpay int,
	idpaymethodTRS varchar(10),
	desc_paymethod varchar(30),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25), -- Viene impostato a 25 in quanto gli utenti possono adoperare un C/C che eccede tale lunghezza
	cin char(1),
	title_ben varchar(140),
	address_ben varchar(40),
	cap_ben varchar(5),
	location_ben varchar(30),
	province_ben varchar(2),
	cf_ben varchar(16),
	gender_ben char(1),
	birthdate_ben varchar(8),
	birthplace_ben varchar(30),
	stamp_charge varchar(2),
	free_stamp char(1),
	paymentdescr varchar(370),
	fulfilled char(1),
	iddeputy int,
	nbill int,
	paymentkind char(1), -- S = Singolo; C = Collettivo
	ypro int,
	npro int,
	nproformatted varchar(7),
	curramountpro decimal(19,2),
	idpro int,
	idregpro int,
	autokind varchar(5),
	totpayment int, -- Totale mandato, calcolato già come int x formattazione
	netamount decimal(19,2),
	yproceedstransmission int,
	idben int,
	iddeb int,
	cgu varchar(10)
)

INSERT INTO #final
(
	ydoc, ndoc, ndocformatted, netamount, idreg, idpay, idpaymethodTRS, desc_paymethod, ABI, CAB, cc, cin, title_ben,
	cf_ben, birthplace_ben, birthdate_ben, gender_ben, stamp_charge, free_stamp, paymentdescr, 
	fulfilled, iddeputy, nbill, ypro, npro, nproformatted, curramountpro, idpro, idregpro, autokind, totpayment, 
	yproceedstransmission, cgu, iddeb
)
SELECT
	ydoc, ndoc, ndocformatted, SUM(netamount), idreg, idpay, idpaymethodTRS, desc_paymethod, ABI, CAB, cc, cin, title_ben,
	cf_ben, birthplace_ben, birthdate_ben, gender_ben, stamp_charge, free_stamp, paymentdescr, 
	fulfilled, iddeputy, nbill, ypro, npro, nproformatted, SUM(curramountpro), idpro, idregpro, autokind, totpayment, 
	yproceedstransmission, cgu, iddeb
FROM #payment
GROUP BY
	ydoc, ndoc, ndocformatted, idreg, idpay, idpaymethodTRS, desc_paymethod, ABI, CAB, cc, cin, title_ben,
	cf_ben, birthplace_ben, birthdate_ben, gender_ben, stamp_charge, free_stamp, paymentdescr, 
	fulfilled, iddeputy, nbill, ypro, npro, nproformatted, idpro, idregpro, autokind, totpayment, 
	yproceedstransmission, cgu, iddeb

UPDATE #final
SET idben = 1 +
	ISNULL(
		(SELECT COUNT(*) FROM #final f2
		WHERE f2.autokind IS NULL
			AND f2.ydoc = #final.ydoc
			AND f2.ndoc = #final.ndoc
			AND f2.idpay = #final.idpay AND f2.cgu < #final.cgu)
	,0) +
	ISNULL(
		(SELECT COUNT(*) FROM #final f2
		WHERE f2.ydoc = #final.ydoc
			AND f2.ndoc = #final.ndoc
			AND f2.idpay < #final.idpay)
	,0)
WHERE autokind IS NULL

-- Cancella i mandati a zero come importo netto
DELETE FROM #final WHERE netamount = 0

UPDATE #final
SET idben = 1 +
	ISNULL(
		(SELECT MAX(idben) FROM #final p2
		WHERE p2.autokind IS NULL
			AND p2.ydoc = #final.ydoc
			AND p2.ndoc = #final.ndoc
			AND p2.idpay = #final.idpay)
	,0) +
	ISNULL(
		(SELECT COUNT(*) FROM #final p2
		WHERE p2.autokind IS NOT NULL
			AND p2.ydoc = #final.ydoc
			AND p2.ndoc = #final.ndoc
			AND p2.idpay = #final.idpay
			AND CONVERT(varchar(6),p2.npro) + CONVERT(varchar(6), p2.iddeb) + p2.cgu <
			CONVERT(varchar(6),#final.npro) + CONVERT(varchar(6), #final.iddeb) + #final.cgu)
	,0)
WHERE autokind IS NOT NULL

UPDATE #final
SET idpaymethodTRS = '01'
WHERE curramountpro = netamount

DECLARE @limitamount decimal(19,2)
SET @limitamount = 77.47

-- Cambio del codice bollo a 00 (esente) se l'importo del pagamento non supera i 77,47 €
-- J.T.R. 09.01.2008 - Dopo conversazione con Martinoli (Bca di Roma), siamo arrivati alla conclusione che tutti gli importi inferiori alla soglia
-- devono avere bollo esente.
-- Ad esempio: Se ho un mandato di 100 euro con unico mov. di spesa, dovrei pagare il bollo, ma se quel mov. di spesa
-- è classificato con 2 voci SIOPE differenti al 50%, dato che verranno date in output 2 righe di importo pari a 50 euro
-- il bollo sarà esente per entrambe le righe

UPDATE #final
SET stamp_charge = '00'
WHERE stamp_charge <> '00' AND netamount <= @limitamount

UPDATE #final
SET paymentkind = 
CASE
	WHEN (SELECT COUNT(*) FROM #final f2
		WHERE f2.ndoc = #final.ndoc) > 1 THEN 'C'
	ELSE 'S'
END

-- CONTROLLO N. 13 Controllo che i movimenti di entrata associati ai movimenti di spesa che stiamo trasmettendo siano stati inseriti
-- in una distinta di trasmissione
INSERT INTO #error (message)
SELECT 'Il movimento di entrata ' + CONVERT(varchar(6),#payment.nmov_income) + '/' + CONVERT(varchar(4),#payment.ymov_income)
+ ' associato al movimento di spesa ' + CONVERT(varchar(6),expense.nmov) + '/' + CONVERT(varchar(4),expense.nmov)
+ ' non è stato inserito in una distinta di trasmissione'
FROM #payment
JOIN expense
	ON #payment.idexp = expense.idexp
WHERE yproceedstransmission IS NULL AND #payment.autokind IS NOT NULL

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

DECLARE @dateindi datetime
SET @dateindi = (SELECT transmissiondate FROM paymenttransmission WHERE ypaymenttransmission = @y AND npaymenttransmission = @n)

-- Tabella utilizzata per immagazzinare gli indirizzi dei creditori debitori che si trovano
-- nelle distinte di trasmissione da esportare
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
		AND ((cdi.stop IS NULL) OR (cdi.stop >= @dateindi))
		AND cdi.idreg = registryaddress.idreg))
		AND 
		 (	(idreg IN (SELECT DISTINCT idreg FROM #payment)))

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

-- CONTROLLO N. 10 Ogni beneficiario deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #final WHERE idreg NOT IN
		(SELECT DISTINCT idreg FROM #address ind)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il beneficiario ' + #final.title_ben +
	+ ' non ha un indirizzo valido associato '
	FROM #final
	WHERE idreg NOT IN
		(SELECT DISTINCT idreg FROM #address ind)
	)
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Aggiornamento dei dati inerenti l'indirizzo del beneficiario	
UPDATE #final
SET address_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @len_address
		THEN ISNULL(address,'') + SPACE(@len_address - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@len_address)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg),
cap_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @len_cap
		THEN SUBSTRING(REPLICATE('0',@len_cap),1,@len_cap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg),
location_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @len_location
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@len_location),1,@len_location - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@len_location)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg),
province_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(province,'')) <= @len_province
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@len_province),1,@len_province - DATALENGTH(ISNULL(province,'')))
		ELSE SUBSTRING(province,1,@len_province)
	END
	FROM #address
	WHERE #final.idreg = #address.idreg)

DECLARE @importobollo varchar(7)
SET @importobollo = '0000181'

-- RECORD MA
INSERT INTO #trace (ndoc, nrow, out_str)
SELECT
	#final.ndoc, 1,
	-- Tipo Record
	'MA' +
	-- Codice Banca
	'01' +
	-- Codice Ente
	@cod_department +
	-- Esercizio
	CONVERT(varchar(4), #final.ydoc) +
	-- Numero Mandato
	#final.ndocformatted +
	-- Numero Beneficiario
	REPLICATE('0', @len_idpay - DATALENGTH(CONVERT(varchar(7),#final.idben))) + CONVERT(varchar(7),#final.idben) +
	-- Anno Residuo
	'0000' +
	-- Capitolo
	SPACE(6) +
	-- Articolo
	'000' +
	-- Lettera
	SPACE(1) +
	-- Importo Mandato
	REPLICATE('0', @len_amount - LEN(CONVERT(varchar(15), totpayment))) +
	CONVERT(varchar(15), totpayment) +
	-- Tipo Mandato
	paymentkind +
	-- Codice Partitario
	SPACE(7) +
	-- Conto Bankit
	REPLICATE('0',7) +
	-- Flag regolarizzazione
	fulfilled +
	-- Flag girofondi
	'N' +
	-- Codice Funz. Delegato
	'0000' +
	-- Codice Fiscale Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_cf)
		ELSE cf_ben
	END +
	-- Cognome Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN 'regol' + SPACE(@len_registry_title - LEN('regol'))
		ELSE title_ben
	END +
	-- Nome Beneficiario
	SPACE(30) +
	-- Quietanzante
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_deputy)
		ELSE ISNULL(#deputy.title_deputy,SPACE(@len_deputy))
	END +
	-- Sesso Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN ' '
		ELSE gender_ben
	END +
	-- Indirizzo Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_address)
		ELSE address_ben
	END +
	-- Località Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_location)
		ELSE location_ben
	END +
	-- Provincia Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_province)
		ELSE province_ben
	END +
	-- Località Nascita Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_location)
		ELSE birthplace_ben
	END +
	-- Data di nascita beneficiario
	CASE
		WHEN fulfilled = 'S' THEN REPLICATE('0',8)
		ELSE birthdate_ben 
	END +
	-- C.A.P. Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_cap)
		ELSE cap_ben
	END + 
	-- Modalità Pagamento
	CASE
		WHEN fulfilled = 'S' THEN '01'
		ELSE idpaymethodTRS
	END +
	-- Num reversale associata
	CASE
		WHEN (fulfilled = 'S' OR autokind IS NULL) THEN REPLICATE('0',7)
		ELSE nproformatted
	END +
	-- Progr. debitore
	CASE
		WHEN (fulfilled = 'S' OR autokind IS NULL) THEN REPLICATE('0',@len_idpro)
		ELSE REPLICATE('0', @len_idpro - DATALENGTH(CONVERT(varchar(7),iddeb))) + CONVERT(varchar(7),iddeb)
	END + 
	-- Conto Corrente Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_cc)
		ELSE
		CASE
			WHEN idpaymethodTRS IN ('02','03') THEN cc
			ELSE SPACE(@len_cc)
		END
	END +
	-- Codice ABI Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_ABI)
		ELSE
		CASE
			WHEN idpaymethodTRS IN ('02','03') THEN ABI
			ELSE REPLICATE('0',@len_ABI)
		END
	END +
	-- Codice CAB Beneficiario
	CASE
		WHEN fulfilled = 'S' THEN SPACE(@len_CAB)
		ELSE
		CASE
			WHEN idpaymethodTRS IN ('02','03') THEN CAB
			ELSE REPLICATE('0',@len_CAB)
		END

	END +
	-- Data Valuta Beneficiario
	REPLICATE('0',8) +
	-- Importo Beneficiario
	REPLICATE('0', @len_amount - LEN(CONVERT(varchar(15), CONVERT(int,netamount * 100)))) +
	CONVERT(varchar(15),CONVERT(int,netamount * 100)) +
	-- Codice esenzione bollo
	stamp_charge +
	-- Importo Bollo
	CASE
		WHEN stamp_charge NOT IN ('00','13') THEN @importobollo
		ELSE REPLICATE('0', 7)
	END +
	-- da Codice Spese a Codice Motivo Pagamento (3 campi) 2 + 7 + 2
	REPLICATE('0',11) +
	-- Descrizione Motivo Pagamento
	CASE 
		WHEN fulfilled = 'S' THEN SPACE(@len_desc_payment)
		ELSE paymentdescr
	END +
	-- Anno Emissione Mandato
	'0000' +
	-- Codice per il Netto
	SPACE(9) +
	-- Conto Bankit Beneficiario
	REPLICATE('0',7) +
	-- CGU
	cgu +
	-- Filler
	SPACE(5) +
	-- Divisa
	'E' +
	-- Codice filiale mittente
	@cod_filiale
FROM #final
LEFT OUTER JOIN #deputy
	ON #final.iddeputy = #final.iddeputy
ORDER BY #final.ydoc, #final.ndoc, #final.idben

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

SELECT out_str FROM #trace ORDER BY y, n, ndoc, nrow
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


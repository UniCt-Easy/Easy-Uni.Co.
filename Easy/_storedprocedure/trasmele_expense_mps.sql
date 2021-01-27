
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


--setuser 'amm' 
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_mps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_mps]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [trasmele_expense_mps]
(
	@y int,
	@n int
)
AS
BEGIN
-- exec trasmele_expense_mps 2015,12
/* Versione 1.0.2 del 09/11/2007 ultima modifica: GIUSEPPE */
-- Parte dichiarativa
DECLARE @codicefiliale varchar(20) -- Codice della filiale
DECLARE @codiceente varchar(20) -- Codice dell'ente da esportare
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
DECLARE @lenpaymethod_descr int
DECLARE @lendescpagamento int
DECLARE @lencodiceclass int
DECLARE @lendendelegato int
DECLARE @lenprogrflusso int
DECLARE @lencognomedelegato int
DECLARE @lennomedelegato int
DECLARE @lencin int
DECLARE @lendescincasso int
DECLARE @lencodicetrattamento int
DECLARE @lencodicecontabilitaspeciale int

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
SET @lenpaymethod_descr = 30
SET @lendescpagamento = 150
SET @lencodiceclass = 10
SET @lendendelegato = 100
SET @lenprogrflusso = 5
SET @lencognomedelegato = 50
SET @lennomedelegato = 50
SET @lencin = 1
SET @lendescincasso = 150
SET @lencodicetrattamento = 1
SET @lencodicecontabilitaspeciale = 7	

DECLARE @idtreasurer int
SELECT @idtreasurer = idtreasurer from paymenttransmission where ypaymenttransmission =@y and npaymenttransmission = @n
IF (@idtreasurer is null) 
BEGIN
	SELECT @idtreasurer = MAX(idtreasurer) FROM treasurer WHERE flagdefault='S'
END
IF (@idtreasurer is null) 
BEGIN
	SELECT @idtreasurer = MAX(idtreasurer) FROM treasurer 
END

DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 7

DECLARE @cc_vincolato varchar(7)

--DECLARE @CodiceStruttura varchar(16)
--DECLARE @len_CodiceStruttura int
--SET @len_CodiceStruttura = 7

SELECT 
	@codicefiliale = ISNULL(cabcodefortransmission,''),
	@codiceente = ISNULL(agencycodefortransmission,''),
	@numeroconto = ISNULL(cc,''),
	@cino = ISNULL(cin, '00'),
	@codiceABI =
	CASE
		WHEN DATALENGTH(ISNULL(idbank,'')) <= @lencodiceabi
		THEN SUBSTRING(REPLICATE('0',@lencodiceabi),1,@lencodiceabi - DATALENGTH(ISNULL(idbank,'')))
		+ ISNULL(idbank,'')
		ELSE SUBSTRING(idbank, 1, @lencodiceabi)
	END,
	@cc_vincolato = SUBSTRING( REPLICATE('0',7), 1, @lenCC_vincolato - DATALENGTH(SUBSTRING(ISNULL(trasmcode,''), DATALENGTH(ISNULL(trasmcode,''))-6,@lenCC_vincolato))) + substring(ISNULL(trasmcode,''), DATALENGTH(ISNULL(trasmcode,''))-6,@lenCC_vincolato)
	--@CodiceStruttura = 
	--	CASE
	--	WHEN DATALENGTH(ISNULL(billcode,'')) <= @len_CodiceStruttura
	--	THEN ISNULL(billcode,'') + SUBSTRING(SPACE(@len_CodiceStruttura),1,@len_CodiceStruttura - DATALENGTH(ISNULL(billcode,'')))
	--	ELSE SUBSTRING(billcode,1,@len_CodiceStruttura)
	--	END
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @cfente varchar(16)
DECLARE @descente varchar(35)
DECLARE @indirizzoente varchar(30)
DECLARE @localitaente varchar(35) 
SELECT  @cfente = 
CASE
	WHEN DATALENGTH(ISNULL(cf,'')) <= @lencf
	THEN ISNULL(cf,'') + SUBSTRING(SPACE(@lencf),1,@lencf - DATALENGTH(ISNULL(cf,'')))
	ELSE SUBSTRING(cf, 1, @lencf)
END,
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

-- Inizio Sezione Controlli

CREATE TABLE #error (message varchar(400))

DECLARE @message varchar(200)
-- CONTROLLO N. 0. Distinta di Trasmissione vuoto
IF(
(SELECT COUNT(*) FROM payment
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @y
AND paymenttransmission.npaymenttransmission = @n) = 0)
BEGIN
	INSERT INTO #error
	VALUES('La distinta di trasmissione ' + CONVERT(varchar(4),@y) + '/'
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
	INSERT INTO #error VALUES( 'Il codice Ente inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@lencodiceente))
END

-- CONTROLLO N. 3. Lunghezza del codice filiale
IF (DATALENGTH(@codicefiliale)>@lencodicefiliale)
BEGIN
	INSERT INTO #error VALUES ( 'Il codice Filiale inserito è superiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@lencodicefiliale))
END

DECLARE @kpaymenttransmission int
SELECT @kpaymenttransmission = kpaymenttransmission FROM paymenttransmission
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n

-- CONTROLLO N. 4. Movimento di Spesa senza Modalità di Pagamento
IF EXISTS
(SELECT * FROM paymentcommunicated
WHERE ypaymenttransmission = @y
AND npaymenttransmission = @n
AND idpaymethod IS NULL)
BEGIN
	INSERT INTO #error (message)
	 (SELECT 'Il movimento n.' + CONVERT(varchar(6),nmov) 
		+ '/' + CONVERT(varchar(4),ymov) + ' non è stata scelta una modalità di pagamento'
		FROM paymentcommunicated 
		WHERE kpaymenttransmission = @kpaymenttransmission
		AND idpaymethod IS NULL)
END
-- CONTROLLO N. 5. Movimento di Spesa con Modalità di Pagamento non configurata
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
AND (paymethod.methodbankcode IS NULL OR REPLACE(paymethod.methodbankcode,' ','') = '')
)
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Il movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' la modalità di pagamento scelta non è configurata, Andare in Configurazione - Anagrafica - Modalità di Pagamento'
		FROM paymentcommunicated
		JOIN paymethod
		ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
		AND (paymethod.methodbankcode IS NULL OR REPLACE(paymethod.methodbankcode,' ','') = '')
		)
END

-- CONTROLLO N. 6. Movimento di Spesa con trattamento bollo non configurato
IF EXISTS
(SELECT * FROM expenselast
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN stamphandling
	ON stamphandling.idstamphandling = payment.idstamphandling
WHERE payment.kpaymenttransmission = @kpaymenttransmission
	AND (stamphandling.handlingbankcode IS NULL OR REPLACE(stamphandling.handlingbankcode,' ','') = '')
)
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Nel mandato n.' + CONVERT(varchar(6),payment.ypay) 
	+ '/' + CONVERT(varchar(4),payment.npay) + ' il trattamento bollo scelto non è configurato, Andare in Configurazione - Anagrafica - Trattamento del Bollo'
	FROM expenselast
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN stamphandling
		ON stamphandling.idstamphandling = payment.idstamphandling
	WHERE payment.kpaymenttransmission = @kpaymenttransmission
		AND (stamphandling.handlingbankcode IS NULL OR REPLACE(stamphandling.handlingbankcode,' ','') = '')
	)
END

-- CONTROLLO N. 7. Trattamento bollo che eccede la lunghezza
IF EXISTS
(SELECT * FROM expenselast
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN stamphandling
	ON stamphandling.idstamphandling = payment.idstamphandling
WHERE payment.kpaymenttransmission = @kpaymenttransmission
	AND DATALENGTH(ISNULL(stamphandling.handlingbankcode,'')) > @lencodicetrattamento
)
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Nel mandato n.' + CONVERT(varchar(6),payment.npay) 
	+ '/' + CONVERT(varchar(4),payment.ypay) + ' il trattamento bollo scelto eccede la lunghezza massima di '
	+ CONVERT(varchar(2),@lencodicetrattamento) + ' caratteri'
	FROM expenselast
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN stamphandling
		ON stamphandling.idstamphandling = payment.idstamphandling
	WHERE payment.kpaymenttransmission = @kpaymenttransmission
		AND DATALENGTH(ISNULL(stamphandling.handlingbankcode,'')) > @lencodicetrattamento
	)
END
-- CONTROLLO N. 8. Codice ABI e CAB devono essere valorizzati nel caso di modalità di pagamento 53 e 63
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode = 'B'
	AND (
		(paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
		OR (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
		OR (paymentcommunicated.iban IS NULL OR REPLACE(paymentcommunicated.iban,' ','') = '')
	)
)
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento scelta non è stato assegnato il codice ABI / CAB / IBAN.'
		FROM paymentcommunicated
		JOIN paymethod
			ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
			AND paymethod.methodbankcode = 'B'
			AND (
				(paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
				OR (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
				OR (paymentcommunicated.iban IS NULL OR REPLACE(paymentcommunicated.iban,' ','') = '')
			)
		)
END

-- CONTROLLO N. 9. Il codice ABI e CAB non devono eccedere la lunghezza massima nel caso di modalità di pagamento 53 e 63
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode  = 'B'
	AND (
		(DATALENGTH(paymentcommunicated.idcab) > @lencodicecab)
		OR (DATALENGTH(paymentcommunicated.idbank) > @lencodiceabi)
		)
)
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento il codice ABI eccede la lunghezza di '
		+ CONVERT(varchar(3),@lencodiceabi) + ' caratteri e/o il codice CAB eccede la lunghezza di '
		+ CONVERT(varchar(3),@lencodicecab) + ' caratteri'
		FROM paymentcommunicated
		JOIN paymethod
			ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
			AND paymethod.methodbankcode  = 'B'
			AND (
				(DATALENGTH(paymentcommunicated.idcab) > @lencodicecab)
				OR (DATALENGTH(paymentcommunicated.idbank) > @lencodiceabi)
				)
		)
END
-- CONTROLLO N. 10. Conto Corrente valorizzato e di lunghezza massima 12 caratteri nel caso di modalità di pagamento 52, 53 e 63
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode = 'B'
	AND (paymentcommunicated.cc IS NULL
		OR REPLACE(paymentcommunicated.cc,' ','') = ''
		OR DATALENGTH(ISNULL(
		REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
		REPLACE(REPLACE(REPLACE(REPLACE(paymentcommunicated.cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
		'/',''),':',''),';','')
		,'')) > @lencc)
)
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov)
		+ ' nella modalità di pagamento non è stato inserito il C/C o la lunghezza del C/C eccede i '
		+ CONVERT(varchar(2),@lencc) + ' caratteri'
		FROM paymentcommunicated
		JOIN paymethod
			ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
			AND paymethod.methodbankcode = 'B'
			AND (paymentcommunicated.cc IS NULL
				OR REPLACE(paymentcommunicated.cc,' ','') = ''
				OR DATALENGTH(ISNULL(paymentcommunicated.cc,'')) > @lencc)
		)
END


-- CONTROLLO N. 11. Movimento di Spesa a Importo zero
INSERT INTO #error (message)
(SELECT 'Il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' ha importo pari a zero'
FROM paymentcommunicated
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n
	AND ISNULL(curramount,0) = 0)
	

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
	-- CONTROLLO N. 11. Conto Corrente Postale valorizzato e di lunghezza massima 10 caratteri nel caso di modalità di pagamento O,P,Q
	IF EXISTS
	(SELECT * FROM paymentcommunicated
	JOIN paymethod
		ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
	WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
		AND paymethod.methodbankcode IN ('O','P','Q')
		AND (paymentcommunicated.cc IS NULL
			OR REPLACE(paymentcommunicated.cc,' ','') = ''
			OR DATALENGTH(ISNULL(
			REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
			REPLACE(REPLACE(REPLACE(REPLACE(paymentcommunicated.cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
			'/',''),':',''),';','')
			,'')) > @lenccp)
	)
	BEGIN
		INSERT INTO #error (message)
			(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
			+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov)
			+ ' nella modalità di pagamento non è stato inserito il C/CP o la lunghezza del C/CP eccede i '
			+ CONVERT(varchar(2),@lenccp) + ' caratteri'
			FROM paymentcommunicated
			JOIN paymethod
				ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
			WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
				AND paymethod.methodbankcode IN ('O','P','Q')
				AND (paymentcommunicated.cc IS NULL
					OR REPLACE(paymentcommunicated.cc,' ','') = ''
					OR DATALENGTH(ISNULL(paymentcommunicated.cc,'')) > @lenccp)
			)

	END

-- CONTROLLO N. 12. codice contabilita speciale errato o mancante
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
join expenselast
	ON paymentcommunicated.idexp = expenselast.idexp
join expense
        on expenselast.idexp = expense.idexp 
join registrypaymethod
        on registrypaymethod.idreg = expense.idreg
        and registrypaymethod.idpaymethod = expenselast.idpaymethod
WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode = 'G'
	AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
		OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode) ,' ','') = ''
		OR DATALENGTH(ISNULL(
		REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
		REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
		'/',''),':',''),';','')
		,'')) > @lencodicecontabilitaspeciale)
)
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov)
		+ ' nella modalità di pagamento non è stato inserito il Codice contabilità speciale o la sua lunghezza supera i '
		+ CONVERT(varchar(7),@lencodicecontabilitaspeciale) + ' caratteri'
		FROM paymentcommunicated
                JOIN paymethod
                	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
                join expenselast
                	ON paymentcommunicated.idexp = expenselast.idexp
                join expense
                        on expenselast.idexp = expense.idexp 
                join registrypaymethod
                        on registrypaymethod.idreg = expense.idreg
                        and registrypaymethod.idpaymethod = expenselast.idpaymethod
		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
			AND paymethod.methodbankcode = 'G'
			AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
				OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode) ,' ','') = ''
				OR DATALENGTH(ISNULL(ISNULL(expenselast.extracode,registrypaymethod.extracode),'')) > @lencodicecontabilitaspeciale)
		)
END

-- CONTROLLO N. 15. Movimento di Spesa a Importo zero
INSERT INTO #error (message)
(SELECT 'Il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' ha importo pari a zero'
FROM paymentcommunicated
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n
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

DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

-- Tabella dei pagamenti
CREATE TABLE #pagamento
(
	y int,
	n int,
	kpay int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idexp int,
	idpaydisposition int,
	iddetail int,
	curramount decimal(19,2),
	exp_curramount decimal(19,2), -- importo corrente del movimento finanziario per le dipos. pagamento
	idreg int,
	expense_adate datetime,
	payment_adate datetime,
	transmissiondate datetime,
	registry_prog int,
	idpaymethodTRS varchar(10),
	paymethod_descr varchar(30),
	abi varchar(5),
	cab varchar(5),
	cc varchar(25),
	cin char(1),
	nbill varchar(7),
	checkdigit varchar(2),
	countrycode varchar(2),
	reg_title varchar(140),
	reg_address varchar(60),
	reg_cap varchar(5),
	reg_location varchar(35),
	reg_p_iva varchar(16),
	reg_cf varchar(16),
	reg_province varchar(2),
	freestamp char(1),
	paymentdescr varchar(150),
	fulfilled char(1),
	iddeputy int,
	taxamount decimal(19,2),
	netamount decimal(19,2),
	employ char(1),
    extracode varchar(7),
    idpaymethodflag tinyint,
    iban varchar(50),	-- variabile inserita per i bonifici esteri,ci serve l'iban intero col checkdigit che ha messo l'utente .
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15),
	cupcodeexpense varchar(15),
	CIG varchar(10),
	CUP varchar(15),
	cigcodeexpense varchar(10),
	cigcodemandate varchar(10)
)
	
-- Tabella del delagato
CREATE TABLE #deputy
(
	iddeputy int,
	title varchar(140),
	surname varchar(50),
	forename varchar(50),
	address varchar(30),
	cap varchar(5),
	location varchar(30),
	province varchar(2),
	cf varchar(16),
	human char(1) 
)
	
-- Tabella delle trattenute
CREATE TABLE #ritenute
(
	y int,
	n int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	registry_prog int,
	idexp int,
	idinc int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	curramount decimal(19,2),
	proceeds_prog int,
	idreg int,
	obb_title varchar(60),
	obb_address varchar(60),
	obb_location varchar(35),
	obb_cap varchar(5),
	obb_cf varchar(16),
	obb_p_iva varchar(16),
	proceedsdescr varchar(150)
)
-- Tabella delle trattenute a carico dell'ente
-- se la configurazione dei contributi prevede un automatismo di spesa e uno di entrata su partita di giro
-- per gli automatismi dei contributi trasmetto anche la reversale del corrispondente automatismo di entrata
/*
CREATE TABLE #admintax
(
	y int,
	n int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpay int,
	idexp int,
	idinc int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	curramount decimal(19,2),
	idpro int,
	idreg int,
	obb_title varchar(60),
	obb_address varchar(60),
	obb_location varchar(35),
	obb_cap varchar(5),
	obb_cf varchar(16),
	obb_p_iva varchar(16),
	autokind varchar(5),
	proceedsdescr varchar(150)
)
*/
-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	y int,
	n int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	registry_prog int,
	sortcode varchar(50),
	idsor int,
	amount decimal(19,2),
	progressive int,
	formatted_progressive varchar(3),
	rowkind char(1), -- Campo che vale 'P' = Movimento Principale, 'T' = Trattenute
	idinc int,
	idexp int,
	idpaydisposition int,
	iddetail int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15), 
	cupcodeexpense varchar(15)
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
	nation varchar(65),
	idpaydisposition int,
	iddetail int
)

-- Inserimento dei pagamenti presenti nella distinta di trasmissione che si vuole trasmettere
-- Si cerca di reperire più informazioni possibile all'interno di questa insert formattando già i dati.
INSERT INTO #pagamento (y, n, kpay, ydoc, ndoc, idexp, idpaydisposition, iddetail, curramount,
idreg, expense_adate, payment_adate, transmissiondate,freestamp,
idpaymethodTRS,idpaymethodflag,iban, nbill, paymethod_descr, abi, cab, cc, cin, checkdigit, countrycode,
reg_title, reg_cf, reg_p_iva, paymentdescr, fulfilled, iddeputy, employ, extracode,cupcodefin,cupcodeupb,
cupcodeexpense, cigcodeexpense)
SELECT t.ypaymenttransmission, t.npaymenttransmission,d.kpay,d.ypay, d.npay, s.idexp, 0,0, i.curramount,
s.idreg, s.adate, d.adate, t.transmissiondate, 
CASE
	WHEN DATALENGTH(ISNULL(tb.handlingbankcode,'')) <= @lencodicetrattamento
	THEN ISNULL(tb.handlingbankcode,'') + SPACE(@lencodicetrattamento - DATALENGTH(ISNULL(tb.handlingbankcode,'')))
	ELSE SUBSTRING(tb.handlingbankcode,1,@lencodicetrattamento)
END,
m.methodbankcode,m.flag,el.iban,
ISNULL(REPLICATE('0', 7-DATALENGTH(CONVERT(varchar(7),el.nbill))) + CONVERT(varchar(7),el.nbill),REPLICATE('0',7)),
CASE
	WHEN DATALENGTH(ISNULL(m.description,'')) <= @lenpaymethod_descr
	THEN ISNULL(m.description,'') + SUBSTRING(SPACE(@lenpaymethod_descr),1,@lenpaymethod_descr - DATALENGTH(ISNULL(m.description,'')))
	ELSE SUBSTRING(m.description,1, @lenpaymethod_descr)
END,
CASE
	WHEN DATALENGTH(ISNULL(el.idbank,'')) <= @lencodiceabi
	THEN SUBSTRING(REPLICATE('0',@lencodiceabi),1,@lencodiceabi - DATALENGTH(ISNULL(el.idbank,''))) + ISNULL(el.idbank,'')
	ELSE SUBSTRING(el.idbank,1,@lencodiceabi)
END,
CASE
	WHEN DATALENGTH(ISNULL(el.idcab,'')) <= @lencodicecab
	THEN SUBSTRING(REPLICATE('0',@lencodicecab),1,@lencodicecab - DATALENGTH(ISNULL(el.idcab,''))) + ISNULL(el.idcab,'')
	ELSE SUBSTRING(el.idcab,1,@lencodicecab)
END,
ISNULL(el.cc,''),
CASE
	WHEN DATALENGTH(ISNULL(el.cin,' ')) <= @lencin
	THEN ISNULL(el.cin, ' ') + SPACE(1 - DATALENGTH(ISNULL(el.cin,' ')))
	ELSE SUBSTRING(el.cin,1,@lencin)
END,
CASE
	WHEN SUBSTRING(ISNULL(el.iban,''),1,2) = 'IT'
	THEN SUBSTRING(el.iban,3,2)
	ELSE SPACE(2)
END,
CASE
	WHEN SUBSTRING(ISNULL(el.iban,''),1,2) = 'IT'
	THEN SUBSTRING(el.iban,1,2)
	ELSE SPACE(2)
END,
CASE
	WHEN DATALENGTH(ISNULL(c.title,'')) <= @lendenominazione
	THEN ISNULL(c.title,'') + SUBSTRING(SPACE(@lendenominazione),1,@lendenominazione - DATALENGTH(ISNULL(c.title,'')))
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
			ISNULL(DATALENGTH(SUBSTRING(isnull(c.p_iva,''),1,@lenpi)),0)) 
			+ SUBSTRING(isnull(c.p_iva,''),1,@lenpi)
	ELSE SPACE(@lenpi)
END,
-- paymentdescr:
CASE
	WHEN DATALENGTH(ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'')) <= @lendescpagamento
	THEN 
		ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'') 
	ELSE ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') +
		SUBSTRING(ISNULL(s.description,''),1,@lendescpagamento - DATALENGTH(ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'')))
END,
CASE
	when (( el.flag & 1)<>0) then 'S'
	else 'N'
End,

CASE
	WHEN m.allowdeputy = 'S' THEN el.iddeputy -- Codice Mod. Banca 01
	ELSE NULL
END, 
CASE
	WHEN el.idser IS NOT NULL
	THEN 'D'
	ELSE ' '
END,
CASE
	WHEN DATALENGTH(ISNULL(ISNULL(el.extracode,mcd.extracode),'')) <= @lencodicecontabilitaspeciale
	THEN SUBSTRING(REPLICATE('0',@lencodicecontabilitaspeciale),1,@lencodicecontabilitaspeciale - DATALENGTH(ISNULL(ISNULL(el.extracode,mcd.extracode),''))) + ISNULL(ISNULL(el.extracode,mcd.extracode),'')
	ELSE SUBSTRING(ISNULL(el.extracode,mcd.extracode),1,@lencodicecontabilitaspeciale)
END,
finlast.cupcode,
u.cupcode,
RegPhase.cupcode,
RegPhase.cigcode
FROM expense s
JOIN expenselast el
	ON s.idexp = el.idexp
JOIN expensetotal i
	ON i.idexp = s.idexp
JOIN expenseyear y
	ON y.idexp = s.idexp
JOIN payment d
	ON d.kpay = el.kpay
JOIN paymenttransmission t
	ON t.kpaymenttransmission = d.kpaymenttransmission
JOIN paymethod m
	ON el.idpaymethod = m.idpaymethod
LEFT OUTER JOIN registrypaymethod mcd
	ON mcd.idregistrypaymethod = el.idregistrypaymethod
	AND mcd.idreg = s.idreg
JOIN registry c
	ON c.idreg = s.idreg
JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
LEFT OUTER JOIN bank
	ON bank.idbank = el.idbank
LEFT OUTER JOIN stamphandling tb
	ON tb.idstamphandling = d.idstamphandling
LEFT OUTER JOIN paydisposition p
	ON p.kpay = d.kpay
JOIN upb u
	ON u.idupb = y.idupb
JOIN fin f
	ON f.idfin = y.idfin
JOIN finlast 
	ON finlast.idfin = f.idfin
JOIN expenselink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
	ON RegPhaseELK.idchild = el.idexp
	AND RegPhaseELK.nlevel = @expenseregphase
JOIN expense RegPhase			-- fase del Creditore
	ON RegPhase.idexp = RegPhaseELK.idparent 
WHERE t.ypaymenttransmission = @y
	AND t.npaymenttransmission = @n
	AND i.ayear = @y
AND  p.idpaydisposition IS NULL

-- Inserimento dei pagamenti presenti nella distinta di trasmissione che si vuole trasmettere
-- che siano collegati alle disposizioni di pagamento

INSERT INTO #pagamento (y, n, kpay, ydoc, ndoc, idexp, idpaydisposition, iddetail,curramount,exp_curramount,
	idreg, expense_adate, payment_adate, transmissiondate,freestamp,
	idpaymethodTRS,idpaymethodflag,iban, nbill, paymethod_descr, abi, cab, cc, cin, checkdigit, countrycode,
	reg_title, reg_cf, reg_p_iva, paymentdescr, fulfilled, iddeputy, employ, extracode, cupcodefin, cupcodeupb,
	cupcodeexpense, cigcodeexpense)
SELECT t.ypaymenttransmission, t.npaymenttransmission, d.kpay, d.ypay, d.npay, el.idexp, 
pd.idpaydisposition, pd.iddetail, pd.amount, i.curramount,
null, d.adate, d.adate, t.transmissiondate, 
CASE
	WHEN DATALENGTH(ISNULL(tb.handlingbankcode,'')) <= @lencodicetrattamento
	THEN ISNULL(tb.handlingbankcode,'') + SPACE(@lencodicetrattamento - DATALENGTH(ISNULL(tb.handlingbankcode,'')))
	ELSE SUBSTRING(tb.handlingbankcode,1,@lencodicetrattamento)
END,
CASE
	WHEN pd.iban IS NOT NULL THEN 'B' -- Bonifico
	ELSE 'C' -- Sportello
END
,null,pd.iban,
REPLICATE('0', 7),
CASE
	WHEN pd.iban IS NOT NULL THEN 'Bonifico' + SUBSTRING(SPACE(@lenpaymethod_descr),1,@lenpaymethod_descr - DATALENGTH('Bonifico'))
	ELSE 'Sportello' + SUBSTRING(SPACE(@lenpaymethod_descr),1,@lenpaymethod_descr - DATALENGTH('Sportello'))
END,

CASE
	WHEN DATALENGTH(ISNULL(pd.abi,'')) <= @lencodiceabi
	THEN SUBSTRING(REPLICATE('0',@lencodiceabi),1,@lencodiceabi - DATALENGTH(ISNULL(pd.abi,''))) + ISNULL(pd.abi,'')
	ELSE SUBSTRING(pd.abi,1,@lencodiceabi)
END,
CASE
	WHEN DATALENGTH(ISNULL(pd.cab,'')) <= @lencodicecab
	THEN SUBSTRING(REPLICATE('0',@lencodicecab),1,@lencodicecab - DATALENGTH(ISNULL(pd.cab,''))) + ISNULL(pd.cab,'')
	ELSE SUBSTRING(pd.cab,1,@lencodicecab)
END,
ISNULL(pd.cc,''),
CASE
	WHEN DATALENGTH(ISNULL(pd.cin,' ')) <= @lencin
	THEN ISNULL(pd.cin, ' ') + SPACE(1 - DATALENGTH(ISNULL(pd.cin,' ')))
	ELSE SUBSTRING(pd.cin,1,@lencin)
END,
CASE
	WHEN SUBSTRING(ISNULL(pd.iban,''),1,2) = 'IT'
	THEN SUBSTRING(pd.iban,3,2)
	ELSE SPACE(2)
END,
CASE
	WHEN SUBSTRING(ISNULL(pd.iban,''),1,2) = 'IT'
	THEN SUBSTRING(pd.iban,1,2)
	ELSE SPACE(2)
END,
CASE
	WHEN DATALENGTH(ISNULL(pd.title,ISNULL(pd.surname,'') + ' ' + ISNULL(pd.forename,'') )) <= @lendenominazione
	THEN ISNULL(pd.title,ISNULL(pd.surname,'') + ' ' +  ISNULL(pd.forename,'') ) + SUBSTRING(SPACE(@lendenominazione),1,@lendenominazione - DATALENGTH(ISNULL(pd.title,ISNULL(pd.surname,'') + ' ' +ISNULL(pd.forename,'') )))
	ELSE SUBSTRING(pd.title, 1, @lendenominazione)
END,
CASE
	WHEN pd.flaghuman = 'S' AND pd.cf IS NOT NULL
	THEN pd.cf + SUBSTRING(SPACE(@lencf),1,@lencf - DATALENGTH(pd.cf))
	WHEN pd.flaghuman = 'S' AND pd.cf IS NULL
	THEN SPACE(@lencf)
END,
CASE
	WHEN pd.flaghuman = 'N' AND pd.p_iva IS NOT NULL
	THEN SUBSTRING(REPLICATE('0',@lenpi),1,@lenpi - 
			ISNULL(DATALENGTH(SUBSTRING(isnull(pd.p_iva,''),1,@lenpi)),0)) 
			+ SUBSTRING(isnull(pd.p_iva,''),1,@lenpi)
	ELSE SPACE(@lenpi)
END,
-- paymentdescr:
CASE
	WHEN LEN(ISNULL(pd.motive,'')) <= @lendescpagamento
	THEN 
		ISNULL(pd.motive,'') 
	ELSE 	
		SUBSTRING(ISNULL(pd.motive,''),1,@lendescpagamento)
END,
'N',
NULL, 
' ',
REPLICATE('0',@lencodicecontabilitaspeciale),
finlast.cupcode,
u.cupcode,
RegPhase.cupcode,
RegPhase.cigcode
FROM expenselast el
JOIN expensetotal i
	ON i.idexp = el.idexp
JOIN expenseyear y
	ON y.idexp = el.idexp
JOIN payment d
	ON d.kpay = el.kpay
JOIN paymenttransmission t
	ON t.kpaymenttransmission = d.kpaymenttransmission
JOIN paydisposition p
	ON p.kpay = d.kpay
JOIN paydispositiondetail pd
	ON p.idpaydisposition = pd.idpaydisposition
LEFT OUTER JOIN bank bancadisposition
	ON bancadisposition.idbank = pd.abi
LEFT OUTER JOIN cab sportellodisposition
	ON sportellodisposition.idbank = pd.abi
	AND sportellodisposition.idcab = pd.cab
LEFT OUTER JOIN stamphandling tb
	ON tb.idstamphandling = d.idstamphandling
JOIN upb u
	ON u.idupb = y.idupb
JOIN fin f
	ON f.idfin = y.idfin
JOIN finlast 
	ON finlast.idfin = f.idfin
JOIN expenselink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
	ON RegPhaseELK.idchild = el.idexp
	AND RegPhaseELK.nlevel = @expenseregphase
JOIN expense RegPhase			-- fase del Creditore
	ON RegPhase.idexp = RegPhaseELK.idparent 
WHERE t.ypaymenttransmission = @y
	AND t.npaymenttransmission = @n
	AND i.ayear = @y

-- Inizio Formattazione del C/C	
UPDATE #pagamento
SET cc = 
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';','')

UPDATE #pagamento SET cc = 
CASE 
	WHEN idpaymethodTRS = 'B'
	THEN REPLICATE('0',@lencc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
	ELSE REPLICATE('0',@lenccp - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
END

-- Fine Formattazione del C/C

UPDATE #pagamento
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@lennumdoc),1,@lennumdoc - DATALENGTH(CONVERT(varchar(7),ndoc))) +
CONVERT(varchar(7),ndoc)

-- Cambio la modalità di pagamento in R (Regolarizzazione) se è valorizzato il numero bolletta
UPDATE #pagamento
SET    idpaymethodTRS = 'R'
WHERE  nbill <>  REPLICATE('0',7)
	
declare @fasecontrattopassivo int
select @fasecontrattopassivo = expensephase from config where ayear=@y

-- Valorizza codice cup da eventuali -----
-- contabilizzazioni di dettagli ordine --
UPDATE #pagamento SET cupcodedetail = 
	   (SELECT MAX( cupcode )
		  FROM mandatedetail
		 WHERE (idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #pagamento.idexp and nlevel=@fasecontrattopassivo) 
			OR idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #pagamento.idexp and nlevel=@fasecontrattopassivo))
		   AND cupcode IS NOT NULL)
where cupcodeexpense is null		   

-- Valorizza il codice CGI eventualmente presente del contratto passivo
UPDATE #pagamento SET cigcodemandate = 
	   (SELECT MAX(mandate.cigcode )
			FROM mandate
			JOIN mandatedetail
				ON	mandate.idmankind = mandatedetail.idmankind 
				AND mandate.yman = mandatedetail.yman 
				AND mandate.nman = mandatedetail.nman
		 WHERE (mandatedetail.idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #pagamento.idexp and nlevel=@fasecontrattopassivo) 
			OR mandatedetail.idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #pagamento.idexp and nlevel=@fasecontrattopassivo))
		 )
where cigcodeexpense is null

-- Valorizza il codice CIG eventualmente presente nella fattura
UPDATE #pagamento SET cigcodemandate = 
	   (SELECT MAX( invoicedetail.cigcode )
			FROM invoicedetail 
		WHERE (invoicedetail.idexp_taxable = #pagamento.idexp
				OR invoicedetail.idexp_iva = #pagamento.idexp)
		)
where cigcodeexpense is null and cigcodemandate is null		 
		 

UPDATE #pagamento SET CIG = ISNULL(cigcodeexpense,ISNULL(cigcodemandate,''))  --Codice CIG
UPDATE #pagamento SET CUP = ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, ISNULL(cupcodefin,'')))) --Codice CUP


DECLARE @faseentratamax tinyint
SELECT @faseentratamax = MAX(nphase) FROM incomephase

-- CONTROLLO N. 13 Controllo che i movimenti di entrata associati ai movimenti di spesa che stiamo trasmettendo siano stati inseriti
-- in una distinta di trasmissione
INSERT INTO #error (message)
SELECT 'Il movimento di entrata ' + CONVERT(varchar(6),I.nmov) + '/' + CONVERT(varchar(4),I.ymov)
+ ' associato al movimento di spesa ' + CONVERT(varchar(6),E.nmov) + '/' + CONVERT(varchar(4),E.nmov)
+ ' non è stato inserito in una distinta di trasmissione'

FROM #pagamento P
JOIN income I
	ON I.idpayment = P.idexp
JOIN expense E
	ON P.idexp = E.idexp
JOIN incomelast IL
	ON IL.idinc = I.idinc
JOIN incometotal IT
	ON I.idinc = IT.idinc
JOIN registry R
	ON I.idreg = R.idreg
JOIN registryclass CTC
	ON CTC.idregistryclass = R.idregistryclass
LEFT OUTER JOIN proceeds S
	ON S.kpro = IL.kpro
WHERE I.nphase = @faseentratamax
	AND (
		(I.autokind = 6)  
		OR (I.autokind = 14) --'GENER' automatismo generico
		OR (I.autokind = 4 AND I.idreg = P.idreg)
	)
	AND IT.ayear = @y
	AND S.kproceedstransmission IS NULL
	
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END


-- Riempimento della tabella delle trattenute.
-- Vengono considerati tutti i movimenti di entrata derivanti da ritenute c/dipendente (autokind = 4) o da recuperi (autokind = 6).
-- Una ritenuta è c/dipendente se autokind = 4 e il versante del movimento di entrata è il medesimo del movimento principale di spesa,
-- invece quando il versante è diverso siamo di fronte ad un contributo e quindi non dobbiamo considerarlo.
INSERT INTO #ritenute (y, n, ydoc, ndoc, ndocformatted, registry_prog,
idexp, idinc, ypro, npro, curramount, idreg,
obb_cf, obb_p_iva, obb_title,
proceedsdescr, proceeds_prog)
SELECT p.y, p.n, p.ydoc, p.ndoc, p.ndocformatted, null,
p.idexp, e.idinc, di.ypro, di.npro, ie.curramount, e.idreg,
CASE
	WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
	THEN
		CASE
			WHEN DATALENGTH(c.cf) <= @lencf
			THEN c.cf + SPACE(@lencf - DATALENGTH(c.cf))
			ELSE SUBSTRING(c.cf, 1, @lencf)
		END
	WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
	THEN SPACE(@lencf)
END,
CASE
	WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
	THEN
		CASE
			WHEN DATALENGTH(c.p_iva) <= @lenpi
			THEN REPLICATE ('0', @lenpi - DATALENGTH(c.p_iva)) + c.p_iva
			ELSE SUBSTRING(c.p_iva, 1, @lenpi)
		END
	ELSE SPACE(@lenpi)
END,
CASE
	WHEN DATALENGTH(ISNULL(c.title, '')) <= @lendenominazione
	THEN ISNULL(c.title, '') + SPACE(@lendenominazione - DATALENGTH(ISNULL(c.title, '')))
	ELSE SUBSTRING(c.title, 1, @lendenominazione)
END,
CASE
	WHEN DATALENGTH(ISNULL(e.description,'')) <= @lendescincasso
	THEN ISNULL(e.description,'') + SPACE(@lendescincasso - DATALENGTH(ISNULL(e.description,'')))
	ELSE SUBSTRING(e.description,1,@lendescincasso)
END,
il.idpro
FROM #pagamento p
JOIN income e
	ON e.idpayment = p.idexp
JOIN incomelast il
	ON il.idinc = e.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN registry c
	ON e.idreg = c.idreg
JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
WHERE e.nphase = @faseentratamax
AND (
	(e.autokind = 6)  
	OR (e.autokind = 14) --'GENER' automatismo generico
	OR (e.autokind = 4 AND e.idreg = p.idreg)
	OR (e.autokind = 20 AND e.idreg = p.idreg) -- AUTOMATISMI DA CSA
)
AND ie.ayear = @y

-- Calcolo dell'importo delle trattenute
UPDATE #pagamento
SET taxamount = 
ISNULL(
	(SELECT SUM(curramount)
	FROM #ritenute
	WHERE #ritenute.idexp = #pagamento.idexp)
,0)
WHERE EXISTS (SELECT * FROM #ritenute WHERE
 #ritenute.idexp = #pagamento.idexp) 
 
 
-- Calcolo del netto (vale sia per contributi che per ritenute)
UPDATE #pagamento 
SET netamount = ISNULL(curramount,0) - ISNULL(taxamount,0)

	
-- Calcolo del progressivo dei movimenti di spesa
-- M.P.S. vuole che all'interno dello stesso mandato venga calcolato un progressivo per indicare
-- i diversi beneficiari. Nel caso ci sia un beneficiario al quale si sta pagando una prestazione con trattenute
-- bisogna generare un record per il netto con un suo progressivo beneficiario e poi altri record delle trattenute
-- con progressivi beneficiario successivi

-- Quindi la logica adottata nel calcolo è la seguente:
-- Il progressivo beneficiario è pari al numero di movimenti di spesa (distinti) presenti nella tabella #pagamento appartenenti allo stesso
-- mandato e con idexp inferiore al corrente, più il numero di trattenute associate ai movimenti di spesa precedenti al corrente.
-- In modo da avere una situazione del genere:
-- Supponendo di avere 2 movimenti di spesa (A e B) appartenenti allo stesso mandato, con A che ha 2 trattenute associate
-- Mov. Spesa A (idexp = 2) Progr. 1
-- Tratt. ad A ritenuta X Progr. 2
-- Tratt. ad A ritenuta Y Progr. 3
-- Mov. Spesa B (idexp = 3) Progr. 4
UPDATE #pagamento
SET registry_prog = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT (iddetail + idexp)) 
	FROM #pagamento p2
	WHERE p2.y = #pagamento.y
	AND p2.n = #pagamento.n
	AND p2.ydoc = #pagamento.ydoc
	AND p2.ndoc = #pagamento.ndoc 
	AND p2.netamount > 0
	AND p2.idexp + p2.iddetail < #pagamento.idexp+#pagamento.iddetail
	)
,0) +
ISNULL(
	(SELECT COUNT(idexp)
	FROM #ritenute r2
	WHERE r2.y = #pagamento.y
	AND r2.n = #pagamento.n
	AND r2.ydoc = #pagamento.ydoc
	AND r2.ndoc = #pagamento.ndoc
	AND r2.idexp < #pagamento.idexp)
,0)

-- Formattazione del campo npro
UPDATE #ritenute
SET nproformatted = 
SUBSTRING(REPLICATE('0',@lennumdoc),1,@lennumdoc - DATALENGTH(CONVERT(varchar(7),npro))) +
CONVERT(varchar(7),npro)

-- Calcolo del progressivo delle trattenute
-- Il progressivo delle trattenute deve essere successivo a quello del movimento di spesa principale al
-- quale le trattenute sono associate.
-- Ovviamente anche le trattenute devono essere distinte, quindi oltre a considerare nel caso il progressivo
-- del movimento di spesa, bisogna contare le trattenute precedenti alla corrente (si ordinano le trattenute per idinc crescenti)
-- Tornando all'esempio precedente:
-- Supponendo di avere 2 movimenti di spesa (A e B) appartenenti allo stesso mandato, con A che ha 2 trattenute associate
-- Mov. Spesa A (idexp = 2) Progr. 1
-- Tratt. ad A ritenuta X Progr. 2
-- Tratt. ad A ritenuta Y Progr. 3
-- Mov. Spesa B (idexp = 3) Progr. 4
-- La prima trattenuta, alla quale abbiamo associato il progressivo 2 ha preso il progressivo del movimento di spesa principale che vale 1,
-- ha cercato se c'erano altre trattenute precedenti ad essa, associate allo stesso movimento di spesa, quindi il risultato è stato 0, quindi 
-- il suo offset è 1 + 0 = 1. A questo offset si somma 1 per indicare il primo progressivo libero, quindi le assegneremo come valore 2.
-- Per la seconda trattenuta il concetto è analogo, quindi prenderemo 1 perché è il progressivo del movimento di spesa collegato ed 1 perché c'è
-- una trattenuta precedente. Quindi l'offset sarà 1 + 1 = 2 al quale sommiamo 1 per indicare il primo progressivo disponibile e quindi avremo 3.
UPDATE #ritenute
SET registry_prog = 1 + 
ISNULL(
	(SELECT registry_prog
	FROM #pagamento p2
	WHERE p2.idexp = #ritenute.idexp
	AND p2.netamount > 0)
,0) +
ISNULL(
	(SELECT COUNT(*)
	FROM #ritenute r2
	WHERE r2.y = #ritenute.y
	AND r2.n = #ritenute.n
	AND r2.ydoc = #ritenute.ydoc
	AND r2.ndoc = #ritenute.ndoc
	AND r2.idexp = #ritenute.idexp
	AND r2.idinc < #ritenute.idinc)
,0)

-- Calcolo del progressivo debitore
-- M.P.S. vuole che ogni riga delle ritenute debba avere una sua numerazione progressiva all'interno del flusso dei dati
-- Questa numerazione è interna alla reversale che contiene queste trattenute, questo progressivo non è da 
-- confondere col progressivo beneficiario calcolato poco sopra
-- Il progressivo debitore sarà quindi calcolato contando il numero di percipienti distinti precedenti al corrente
-- presenti nella medesima reversale
-- Scriviamo, anche in questo caso, un esempio chiarificatore:
-- Tratt. X con percipiente XX in reversale A 1
-- Tratt. Y con percipiente YY in reversale A 2
-- Tratt. Z con percipiente ZZ in reversale B 1
-- La Tratt. X avrà progressivo 1; la Tratt. Y avrà progressivo 2 (1 derivante dal fatto che la Tratt. X ha percipiente precedente
-- ed è presente nella stessa reversale, +1 per il primo progressivo libero)
-- La Tratt. Z avrà progressivo 1 perché non ci sono altre trattenute nella sua reversale.
--UPDATE #ritenute
--SET proceeds_prog = 1 +
--ISNULL(
--	(SELECT COUNT(DISTINCT idreg)
--	FROM #ritenute r2
--	WHERE r2.ypro = #ritenute.ydoc
--	AND r2.npro = #ritenute.ndoc
--	AND r2.idreg < #ritenute.idreg)
--,0)



 

--select * from #pagamento
--select * from #ritenute
-- Gestione del delegato
-- In questa tabella
INSERT INTO #deputy (iddeputy, title, surname, forename, cf, human)
SELECT DISTINCT
	#pagamento.iddeputy,
	ISNULL(registry.title,'')
	+ SUBSTRING(SPACE(@lendendelegato),1,@lendendelegato - DATALENGTH(ISNULL(registry.title,''))),
	ISNULL(registry.surname,'')
	+ SUBSTRING(SPACE(@lencognomedelegato),1,@lencognomedelegato - DATALENGTH(ISNULL(registry.surname,''))),
	ISNULL(registry.forename,'')
	+ SUBSTRING(SPACE(@lennomedelegato),1,@lennomedelegato - DATALENGTH(ISNULL(registry.forename,''))),
	ISNULL(registry.cf,SPACE(@lencf)),
	registryclass.flaghuman
FROM #pagamento
JOIN registry
	ON #pagamento.iddeputy = registry.idreg
LEFT OUTER JOIN registryclass
	ON registryclass.idregistryclass = registry.idregistryclass

/*
-- Leggo configurazione dell'applicazione dei contributi 
DECLARE @admintaxkind int
SELECT  @admintaxkind = (automanagekind & 0xf) FROM config WHERE ayear = @y
 
-- Inserimento delle trattenute (vengono inseriti i contributi c/amministrazione)
INSERT INTO #admintax
(
	y, n, ydoc, ndoc, ndocformatted, idpay,
	idexp, idinc, ypro, npro, curramount, idreg, autokind,
	idpro,obb_cf, obb_p_iva, obb_title,proceedsdescr
)
SELECT
	p.y , p.n , p.ydoc, p.ndoc, p.ndocformatted, null,
	p.idexp, e.idinc, di.ypro, di.npro,
	ie.curramount, e.idreg, e.autokind,il.idpro,
CASE
	WHEN ctc.flaghuman = 'S' AND c.cf IS NOT NULL
	THEN
		CASE
			WHEN DATALENGTH(c.cf) <= @lencf
			THEN c.cf + SPACE(@lencf - DATALENGTH(c.cf))
			ELSE SUBSTRING(c.cf, 1, @lencf)
		END
	WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
	THEN SPACE(@lencf)
END,
CASE
	WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
	THEN
		CASE
			WHEN DATALENGTH(c.p_iva) <= @lenpi
			THEN REPLICATE ('0', @lenpi - DATALENGTH(c.p_iva)) + c.p_iva
			ELSE SUBSTRING(c.p_iva, 1, @lenpi)
		END
	ELSE SPACE(@lenpi)
END,
CASE
	WHEN DATALENGTH(ISNULL(c.title, '')) <= @lendenominazione
	THEN ISNULL(c.title, '') + SPACE(@lendenominazione - DATALENGTH(ISNULL(c.title, '')))
	ELSE SUBSTRING(c.title, 1, @lendenominazione)
END,
CASE
	WHEN DATALENGTH(ISNULL(e.description,'')) <= @lendescincasso
	THEN ISNULL(e.description,'') + SPACE(@lendescincasso - DATALENGTH(ISNULL(e.description,'')))
	ELSE SUBSTRING(e.description,1,@lendescincasso)
END
FROM #pagamento p
JOIN expense s
	ON s.idexp = p.idexp
JOIN income e
	ON e.idpayment = s.idpayment	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN proceedstransmission
	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
JOIN registry c
	ON e.idreg = c.idreg
JOIN registryclass ctc
	ON ctc.idregistryclass = c.idregistryclass
WHERE e.autokind = 4 -- Contributo
	AND s.autokind = 4 
	AND s.autocode  = e.autocode
	AND p.idreg = e.idreg
	AND ie.ayear = @y
	AND @admintaxkind = 2 -- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro
	
-- Valorizzazione del campo nproformatted
UPDATE #admintax
SET nproformatted = 
SUBSTRING(REPLICATE('0',@lennumdoc),1,@lennumdoc - DATALENGTH(CONVERT(varchar(7),npro))) +
CONVERT(varchar(7),npro) 

-- Calcolo del progressivo delle trattenute
-- Il progressivo delle trattenute conto ente deve essere successivo a quello del movimento di spesa principale al
-- quale le trattenute sono associate.
-- Ovviamente anche le trattenute devono essere distinte, quindi oltre a considerare nel caso il progressivo
-- del movimento di spesa, bisogna contare le trattenute precedenti alla corrente (si ordinano le trattenute per idinc crescenti)
-- Tornando all'esempio precedente:
-- Supponendo di avere 2 movimenti di spesa (A e B) appartenenti allo stesso mandato, con A che ha 2 trattenute associate
-- Mov. Spesa A (idexp = 2) Progr. 1
-- Tratt. ad A ritenuta X Progr. 2
-- Tratt. ad A ritenuta Y Progr. 3
-- Mov. Spesa B (idexp = 3) Progr. 4
-- La prima trattenuta, alla quale abbiamo associato il progressivo 2 ha preso il progressivo del movimento di spesa principale che vale 1,
-- ha cercato se c'erano altre trattenute precedenti ad essa, associate allo stesso movimento di spesa, quindi il risultato è stato 0, quindi 
-- il suo offset è 1 + 0 = 1. A questo offset si somma 1 per indicare il primo progressivo libero, quindi le assegneremo come valore 2.
-- Per la seconda trattenuta il concetto è analogo, quindi prenderemo 1 perché è il progressivo del movimento di spesa collegato ed 1 perché c'è
-- una trattenuta precedente. Quindi l'offset sarà 1 + 1 = 2 al quale sommiamo 1 per indicare il primo progressivo disponibile e quindi avremo 3.
UPDATE #pagamento
SET registry_prog = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT (iddetail + idexp)) 
	FROM #pagamento p2
	WHERE p2.y = #pagamento.y
	AND p2.n = #pagamento.n
	AND p2.ydoc = #pagamento.ydoc
	AND p2.ndoc = #pagamento.ndoc 
	AND p2.idexp + p2.iddetail < #pagamento.idexp+#pagamento.iddetail
	)
,0) +
ISNULL(
	(SELECT COUNT(idexp)
	FROM #admintax r2
	WHERE r2.y = #pagamento.y
	AND r2.n = #pagamento.n
	AND r2.ydoc = #pagamento.ydoc
	AND r2.ndoc = #pagamento.ndoc 
	AND r2.idexp < #pagamento.idexp)
,0)

UPDATE #admintax
SET idpay = 1 + 
ISNULL(
	(SELECT registry_prog
	FROM #pagamento p2
	WHERE p2.idexp = #admintax.idexp)
,0) +
ISNULL(
	(SELECT COUNT(*)
	FROM #admintax r2
	WHERE r2.y = #admintax.y
	AND r2.n = #admintax.n
	AND r2.ydoc = #admintax.ydoc
	AND r2.ndoc = #admintax.ndoc
	AND r2.idexp = #admintax.idexp
	AND r2.idinc < #admintax.idinc)
,0)

-- Calcolo del progressivo debitore
-- M.P.S. vuole che ogni riga delle ritenute debba avere una sua numerazione progressiva all'interno del flusso dei dati
-- Questa numerazione è interna alla reversale che contiene queste trattenute, questo progressivo non è da 
-- confondere col progressivo beneficiario calcolato poco sopra
-- Il progressivo debitore sarà quindi calcolato contando il numero di percipienti distinti precedenti al corrente
-- presenti nella medesima reversale
-- Scriviamo, anche in questo caso, un esempio chiarificatore:
-- Tratt. X con percipiente XX in reversale A 1
-- Tratt. Y con percipiente YY in reversale A 2
-- Tratt. Z con percipiente ZZ in reversale B 1
-- La Tratt. X avrà progressivo 1; la Tratt. Y avrà progressivo 2 (1 derivante dal fatto che la Tratt. X ha percipiente precedente
-- ed è presente nella stessa reversale, +1 per il primo progressivo libero)
-- La Tratt. Z avrà progressivo 1 perché non ci sono altre trattenute nella sua reversale.
--UPDATE #admintax
--SET idpro = 1 +
--ISNULL(
--	(SELECT COUNT(DISTINCT idreg)
--	FROM #admintax r2
--	WHERE r2.ypro = #admintax.ydoc
--	AND r2.npro = #admintax.ndoc
--	AND r2.idreg < #admintax.idreg)
--,0)

-- Calcolo dell'importo delle trattenute
UPDATE #pagamento
SET taxamount = 
ISNULL(
	(SELECT SUM(curramount)
	FROM #admintax
	WHERE #admintax.idexp = #pagamento.idexp)
,0)
WHERE EXISTS (SELECT * FROM #admintax WHERE
 #admintax.idexp = #pagamento.idexp) 

UPDATE #pagamento
SET taxamount = 0 where taxamount is null
--select * from #pagamento
*/


--select * from #pagamento  
--select * from #ritenute   
--select * from #admintax 
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
SET @dateindi = (SELECT transmissiondate FROM paymenttransmission WHERE ypaymenttransmission = @y AND npaymenttransmission = @n)

INSERT INTO #rptindirizzoavpag
(
	idaddresskind,
	idreg,
	address,
	location,
	cap,
	province,
	nation,
	idpaydisposition,
	iddetail
)
SELECT
	idaddresskind,
	idreg, 
	address,
	isnull(geo_city.title,'')+' ' +isnull(registryaddress.location,'') ,
	registryaddress.cap,
	geo_country.province,
	case 
		when flagforeign = 'N' THEN 'ITALIA'
		else geo_nation.title
	end,
	0,
	0
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
and cdi.idreg = registryaddress.idreg))

AND 
 (	(idreg IN (select  idreg from #pagamento)) 
	OR 
	(idreg IN (select  idreg from #ritenute))
	--OR 
	--(idreg IN (select distinct idreg from #admintax))
)
 


delete #rptindirizzoavpag
	where #rptindirizzoavpag.idaddresskind <> @nostand
	and exists (
		select * from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg = r2.idreg
		and r2.idaddresskind = @nostand
	)
delete #rptindirizzoavpag
	where #rptindirizzoavpag.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg=r2.idreg
		and r2.idaddresskind = @stand
	)

delete #rptindirizzoavpag
	where (
		select count(*) from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg=r2.idreg
	)>1



-- CONTROLLO N. 12 Ogni beneficiario deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #pagamento WHERE idpaydisposition = 0 AND idreg NOT IN
		(SELECT  idreg FROM #rptindirizzoavpag ind)))
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Il beneficiario ' + #pagamento.reg_title +
		+ ' non ha un indirizzo valido associato '
		FROM #pagamento
		WHERE idreg NOT IN
			(SELECT  idreg FROM #rptindirizzoavpag ind)
		)
END
	
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN 
END


-- Legge i dati dell'indirizzo dalla tabella paydisposition
INSERT INTO #rptindirizzoavpag
(
	idaddresskind,
	address,
	location,
	cap,
	province,
	nation,
	idpaydisposition,
	iddetail
)
SELECT
	@stand,
	address,
	ISNULL(paydispositiondetail.location,''),
	paydispositiondetail.cap,
	paydispositiondetail.province,
	'Italia',
	paydisposition.idpaydisposition,
	paydispositiondetail.iddetail
FROM paydisposition 
JOIN paydispositiondetail
	ON paydisposition.idpaydisposition = paydispositiondetail.idpaydisposition
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = paydispositiondetail.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = paydispositiondetail.idnation
WHERE  paydisposition.kpay in (select  kpay from #pagamento
				WHERE  idpaydisposition <>0)


-- CONTROLLO N. 12 Ogni beneficiario di una disposizione di pagamento deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #pagamento WHERE idpaydisposition <>0 AND 
		NOT EXISTS 
			(SELECT  * FROM #rptindirizzoavpag ind
			  WHERE  ind.idpaydisposition = #pagamento.idpaydisposition AND
				 ind.iddetail = #pagamento.iddetail) ))
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Il beneficiario ' + #pagamento.reg_title +
		+ ' non ha un indirizzo valido associato '
		FROM #pagamento
		WHERE idpaydisposition <> 0 AND NOT EXISTS 
			(SELECT  * FROM #rptindirizzoavpag ind
			  WHERE  ind.idpaydisposition = #pagamento.idpaydisposition AND
				 ind.iddetail = #pagamento.iddetail 
				  )
		)
END

-- Unificazione descrizioni di pagamento per movimenti di spesa che sono stati accorpati
-- Questo pezzo di codice è stato scritto inizialmente quando si pensava di emulare il comportamento di Unicredit
-- per come oggi viene calcolato il registry_prog l'accorpamento non dovrebbe mai avvenire, viene
-- comunque lasciato per maggiore sicurezza
UPDATE #pagamento
SET paymentdescr = 'ACCORPAMENTO PAGAMENTI' -- + SPACE(@lendescpagamento - DATALENGTH('ACCORPAMENTO PAGAMENTI')) La formattazione l'ho postata alla fine, perchè deve scrivere anche il CUP e CIG, ponendoli come prima info del campo 'casuale pagamento'
WHERE
	(SELECT COUNT(*)
	FROM #pagamento p2
	WHERE p2.y = #pagamento.y
	AND p2.n = #pagamento.n
	AND p2.ydoc = #pagamento.ydoc
	AND p2.ndoc = #pagamento.ndoc
	AND p2.registry_prog = #pagamento.registry_prog) > 1
AND 
	(SELECT COUNT(*)
	FROM #pagamento p2
	WHERE p2.y = #pagamento.y
	AND p2.n = #pagamento.n
	AND p2.ydoc = #pagamento.ydoc
	AND p2.ndoc = #pagamento.ndoc
	AND p2.registry_prog = #pagamento.registry_prog) <>
	(SELECT COUNT(*)
	FROM #pagamento p2
	WHERE p2.y = #pagamento.y
	AND p2.n = #pagamento.n
	AND p2.ydoc = #pagamento.ydoc
	AND p2.ndoc = #pagamento.ndoc
	AND p2.registry_prog = #pagamento.registry_prog
	AND p2.paymentdescr = #pagamento.paymentdescr)

-- Aggiornamento dei dati inerenti l'indirizzo del beneficiario	
UPDATE #pagamento
SET reg_address =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @lenindirizzo
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@lenindirizzo),1,@lenindirizzo - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@lenindirizzo)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idreg = #rptindirizzoavpag.idreg 
	),
reg_cap =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @lencap
		THEN SUBSTRING(REPLICATE('0',@lencap),1,@lencap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@lencap)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idreg = #rptindirizzoavpag.idreg
	),
reg_location =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @lenlocalita
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@lenlocalita),1,@lenlocalita - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@lenlocalita)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idreg = #rptindirizzoavpag.idreg
	),
reg_province = 
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(province,'')) <= @lenprovincia
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@lenprovincia),1,@lenprovincia - DATALENGTH(ISNULL(province,'')))
		ELSE SUBSTRING(province,1,@lenprovincia)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idreg = #rptindirizzoavpag.idreg
	)
	WHERE #pagamento.idreg  IS NOT NULL

--- disposizioni di pagamento
UPDATE #pagamento
SET reg_address =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @lenindirizzo
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@lenindirizzo),1,@lenindirizzo - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@lenindirizzo)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idpaydisposition = #rptindirizzoavpag.idpaydisposition AND
	      #pagamento.iddetail = #rptindirizzoavpag.iddetail
		  ),
reg_cap =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @lencap
		THEN SUBSTRING(REPLICATE('0',@lencap),1,@lencap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@lencap)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idpaydisposition = #rptindirizzoavpag.idpaydisposition AND
	      #pagamento.iddetail = #rptindirizzoavpag.iddetail
		 ),
reg_location =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @lenlocalita
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@lenlocalita),1,@lenlocalita - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@lenlocalita)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idpaydisposition = #rptindirizzoavpag.idpaydisposition AND
	      #pagamento.iddetail = #rptindirizzoavpag.iddetail
		  ),
reg_province = 
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(province,'')) <= @lenprovincia
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@lenprovincia),1,@lenprovincia - DATALENGTH(ISNULL(province,'')))
		ELSE SUBSTRING(province,1,@lenprovincia)
	END
	FROM #rptindirizzoavpag
	WHERE #pagamento.idpaydisposition = #rptindirizzoavpag.idpaydisposition AND
	      #pagamento.iddetail = #rptindirizzoavpag.iddetail
		  )
WHERE  #pagamento.idpaydisposition  <>0

--select * from #rptindirizzoavpag 
-- Aggiornamento dati indirizzo obbligato
UPDATE #ritenute
SET obb_address =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @lenindirizzo
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@lenindirizzo),1,@lenindirizzo - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@lenindirizzo)
	END
	FROM #rptindirizzoavpag
	WHERE #ritenute.idreg = #rptindirizzoavpag.idreg)
,SPACE(@lenindirizzo)),
obb_cap =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @lencap
		THEN SUBSTRING(REPLICATE('0',@lencap),1,@lencap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@lencap)
	END
	FROM #rptindirizzoavpag
	WHERE #ritenute.idreg = #rptindirizzoavpag.idreg)
,REPLICATE('0',@lencap)),
obb_location =
ISNULL(
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @lenlocalita
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@lenlocalita),1,@lenlocalita - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@lenlocalita)
	END
	FROM #rptindirizzoavpag
	WHERE #ritenute.idreg = #rptindirizzoavpag.idreg)
,SPACE(@lenlocalita))

--UPDATE #admintax
--SET obb_address =
--ISNULL(
--	(SELECT
--	CASE
--		WHEN DATALENGTH(ISNULL(address,'')) <= @lenindirizzo
--		THEN ISNULL(address,'') + SUBSTRING(SPACE(@lenindirizzo),1,@lenindirizzo - DATALENGTH(ISNULL(address,'')))
--		ELSE SUBSTRING(address,1,@lenindirizzo)
--	END
--	FROM #rptindirizzoavpag
--	WHERE #admintax.idreg = #rptindirizzoavpag.idreg)
--,SPACE(@lenindirizzo)),
--obb_cap =
--ISNULL(
--	(SELECT
--	CASE
--		WHEN DATALENGTH(ISNULL(cap,'')) <= @lencap
--		THEN SUBSTRING(REPLICATE('0',@lencap),1,@lencap - DATALENGTH(ISNULL(cap,'')))
--		+ ISNULL(cap,'')
--		ELSE SUBSTRING(cap,1,@lencap)
--	END
--	FROM #rptindirizzoavpag
--	WHERE #admintax.idreg = #rptindirizzoavpag.idreg)
--,REPLICATE('0',@lencap)),
--obb_location =
--ISNULL(
--	(SELECT
--	CASE
--		WHEN DATALENGTH(ISNULL(location,'')) <= @lenlocalita
--		THEN ISNULL(location,'') + SUBSTRING(SPACE(@lenlocalita),1,@lenlocalita - DATALENGTH(ISNULL(location,'')))
--		ELSE SUBSTRING(location,1,@lenlocalita)
--	END
--	FROM #rptindirizzoavpag
--	WHERE #admintax.idreg = #rptindirizzoavpag.idreg)
--,SPACE(@lenlocalita))


-- Riempimento della tabella con i dati della classificazione SIOPE
-- La tabella #siope viene riempita a seconda di come sono stati creati i movimenti finanziari di spesa.
-- Ci sono fondamentalmente due casi:
-- Caso 1: Movimento di spesa senza trattenute associate (significa senza ritenute e recuperi)
-- Caso 2: Movimento di spesa con trattenute associate (significa con ritenute e/o recuperi)
-- Le banche, purtroppo, non tenendo conto che il SIOPE si occupa di classificare il movimento di spesa al lordo
-- vogliono sempre che il movimento di spesa venga classificato al netto e che la parte delle trattenute venga associata
-- la parte restante della classificazione.
-- Dopo accordi con i singoli istituti, si è arrivati alla conclusione che, ove richiesto, il movimento di spesa venga classificato al netto
-- ma le trattenute nella trasmissione dei mandati vengano classificate mediante i codici SIOPE di spesa, sarà poi compito della trasmissione
-- delle reversali comunicare la classificazione di entrata delle trattenute.
-- Detto questo, nel caso, quindi ci siano movimenti di spesa con trattenute, si classificano prima le trattenute con i codici SIOPE
-- applicando la quota parte della classificazione rispetto al loro importo e poi per differenza si procede a classificare il movimento principale
-- Facciamo un esempio esplicativo:
/*
Movimento di spesa 1000 Ritenute 200
Movimento classificato in siope con codici di spesa per 600 con codice A e 400 codice B
Ritenuta classificata in siope con codici di entrata per 200 con codice C

Nella trasmissione dei mandati (quella che stiamo spiegando)
Verranno create 4 righe in #siope
Riga 1 120 con codice A associata alla trattenuta
Riga 2 80 con codice B associata alla ritenuta
Riga 3 480 con codice A associata al movimento di spesa
Riga 4 320 con codice B associata al movimento di spesa

Nella trasmissione delle reversali la trattenuta sarà classificata per 200 con codice C
*/

DECLARE @npos int
DECLARE @codeclassSIOPE varchar(36)

SELECT  @codeclassSIOPE  =  
CASE  
	WHEN  (@y<= 2006) THEN  'SIOPE'
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  '07U_SIOPE'
	ELSE   'SIOPE_U_18'
END

SELECT  @npos  =  
CASE  
	WHEN  (@y<= 2006) THEN  2
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  1
	ELSE   1
END

DECLARE @idsorkindSiope int
SELECT @idsorkindSiope = idsorkind FROM sortingkind WHERE codesorkind = @codeclassSIOPE

-- Caso 1. Movimento di Spesa senza trattenute
INSERT INTO #siope (y, n, ydoc, ndoc, ndocformatted,
registry_prog, idsor, sortcode, amount, rowkind, idexp,
cupcodefin,cupcodeupb,cupcodedetail, cupcodeexpense)
SELECT #pagamento.y, #pagamento.n,
#pagamento.ydoc, #pagamento.ndoc, #pagamento.ndocformatted,
#pagamento.registry_prog,
expensesorted.idsor,
SUBSTRING(sorting.sortcode,@npos,@lencodiceclass),
CASE
	WHEN #pagamento.iddetail = 0 THEN SUM(expensesorted.amount)
	ELSE SUM(expensesorted.amount) * (#pagamento.curramount/#pagamento.exp_curramount)
END, 
'P', #pagamento.idexp,
#pagamento.cupcodefin,#pagamento.cupcodeupb,#pagamento.cupcodedetail, #pagamento.cupcodeexpense
FROM #pagamento
JOIN expensesorted
	ON #pagamento.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @idsorkindSiope
	AND ISNULL(#pagamento.taxamount,0) = 0
GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc,
	#pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
	#pagamento.registry_prog, expensesorted.idsor, #pagamento.idexp,
	#pagamento.curramount,#pagamento.exp_curramount,
	#pagamento.idpaydisposition,#pagamento.iddetail,
	#pagamento.cupcodeexpense, #pagamento.cupcodedetail,#pagamento.cupcodeupb, #pagamento.cupcodefin
--select * from #pagamento
--select * from #siope
-- Caso 2 a). Movimento di Spesa con trattenute
-- Inserimento di dettagli SIOPE sul mov. principale riferito alle trattenute (calcolo per rapporto)
INSERT INTO #siope (y, n, ydoc, ndoc, ndocformatted,
registry_prog, idsor, sortcode, amount, rowkind, idinc, idexp)
SELECT #pagamento.y, #pagamento.n,
#pagamento.ydoc, #pagamento.ndoc, #pagamento.ndocformatted,
#ritenute.registry_prog,
expensesorted.idsor,
SUBSTRING(sorting.sortcode,@npos,@lencodiceclass),
case #pagamento.curramount when 0 then 0 else SUM(expensesorted.amount) * #ritenute.curramount / #pagamento.curramount end,
'T', #ritenute.idinc, #ritenute.idexp
FROM #ritenute
JOIN #pagamento
	ON #ritenute.idexp = #pagamento.idexp
JOIN expensesorted
	ON #pagamento.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @idsorkindSiope
	AND ISNULL(#pagamento.taxamount,0) <> 0
GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc,
	#pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
	#pagamento.registry_prog, #pagamento.curramount, #ritenute.curramount,
	expensesorted.idsor, #ritenute.idinc, #ritenute.registry_prog, #ritenute.idexp


-- Caso 2 b). Movimento di Spesa con trattenute
-- Inserimento di dettagli SIOPE sul mov. principale riferito ai contributi (calcolo per rapporto)
--INSERT INTO #siope (y, n, ydoc, ndoc, ndocformatted,
--registry_prog, idsor, sortcode, amount, rowkind, idinc, idexp)
--SELECT #pagamento.y, #pagamento.n,
--#pagamento.ydoc, #pagamento.ndoc, #pagamento.ndocformatted,
--#admintax.idpay,
--expensesorted.idsor,
--CASE
--	WHEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) <= @lencodiceclass
--	THEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) +
--	SPACE(@lencodiceclass - DATALENGTH(SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode))))
--	ELSE SUBSTRING(sorting.sortcode,@npos,@lencodiceclass)
--END,
--case #pagamento.curramount when 0 then 0 else SUM(expensesorted.amount) * #admintax.curramount / #pagamento.curramount end,
--'T', #admintax.idinc, #admintax.idexp
--FROM #admintax
--JOIN #pagamento
--	ON #admintax.idexp = #pagamento.idexp
--JOIN expensesorted
--	ON #pagamento.idexp = expensesorted.idexp
--JOIN sorting
--	ON sorting.idsor = expensesorted.idsor
--WHERE sorting.idsorkind = @idsorkindSiope
--	AND #pagamento.taxamount <> 0
--GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc,
--	#pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
--	#pagamento.registry_prog, #pagamento.curramount, #admintax.curramount,
--	expensesorted.idsor, #admintax.idinc, #admintax.idpay, #admintax.idexp
	
		
-- Inserimento dei dettagli SIOPE del movimento principale (calcolo per differenza)
INSERT INTO #siope (y, n, ydoc, ndoc, ndocformatted,registry_prog, 
idsor, sortcode, amount, rowkind, idexp,cupcodefin,cupcodeupb,cupcodedetail,cupcodeexpense)
SELECT #pagamento.y, #pagamento.n,
#pagamento.ydoc, #pagamento.ndoc, #pagamento.ndocformatted,
#pagamento.registry_prog,
expensesorted.idsor,
SUBSTRING(sorting.sortcode,@npos,@lencodiceclass),
SUM(expensesorted.amount) - 
ISNULL(
	(SELECT SUM(#siope.amount)
	FROM #siope
	WHERE #siope.y = #pagamento.y
		AND #siope.n = #pagamento.n
		AND #siope.ydoc = #pagamento.ydoc
		AND #siope.ndoc = #pagamento.ndoc
		AND #siope.idexp = #pagamento.idexp
		AND #siope.idsor = expensesorted.idsor
		AND #siope.rowkind = 'T')
,0), 'P', #pagamento.idexp, 
#pagamento.cupcodefin, #pagamento.cupcodeupb, #pagamento.cupcodedetail, #pagamento.cupcodeexpense
FROM #pagamento
JOIN expensesorted
	ON #pagamento.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @idsorkindSiope
	AND ISNULL(#pagamento.taxamount,0) <> 0
	AND ISNULL(#pagamento.netamount,0) <> 0   --- escludo i sub che abbiano un netto pari a zero
GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc,
#pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
#pagamento.registry_prog, #pagamento.curramount, expensesorted.idsor, 
#pagamento.idexp, #pagamento.cupcodeexpense, #pagamento.cupcodedetail, #pagamento.cupcodeupb,#pagamento.cupcodefin


-- Calcolo del progressivo SIOPE
-- Anche la classificazione ha un suo progressivo che è pari al numero di codici classificazione distinti precedente al corrente,
-- legati allo stesso progressivo percipiente.
UPDATE #siope
SET progressive = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT sortcode)
	FROM #siope s2
	WHERE s2.y = #siope.y
		AND s2.n = #siope.n
		AND s2.ydoc = #siope.ydoc
		AND s2.ndoc = #siope.ndoc
		AND s2.rowkind = #siope.rowkind
		AND
		CONVERT(varchar(5),s2.registry_prog) + s2.sortcode < 
		CONVERT(varchar(5),#siope.registry_prog) + #siope.sortcode)
,0)
 WHERE #siope.rowkind = 'P'
 
-- Calcolo del progressivo SIOPE sulle trattenute
-- Anche sulle trattenute si calcola il progressivo SIOPE che è pari al progressivo del movimento principale più 1
DECLARE @currprog int
DECLARE @y_siope int
DECLARE @n_siope int
DECLARE @esercdoc_siope int
DECLARE @numdoc_siope int
DECLARE @idinc_siope varchar(72)
DECLARE @codiceclass_siope varchar(30)
DECLARE curr_siope INSENSITIVE CURSOR FOR
SELECT y, n, ydoc, ndoc, idinc, sortcode FROM #siope
WHERE rowkind = 'T'
ORDER BY y, n, ydoc, ndoc, idinc, sortcode
FOR READ ONLY
OPEN curr_siope
FETCH NEXT FROM curr_siope
INTO @y_siope, @n_siope, @esercdoc_siope, @numdoc_siope, @idinc_siope, @codiceclass_siope
WHILE(@@FETCH_STATUS = 0)
BEGIN
	SET @currprog = 1 +
	ISNULL(
		(SELECT MAX(progressive) FROM #siope
		WHERE y = @y_siope
			AND n = @n_siope
			AND ydoc = @esercdoc_siope
			AND ndoc = @numdoc_siope)
	,0)

	UPDATE #siope SET progressive = @currprog
	WHERE y = @y_siope
		AND n = @n_siope
		AND ydoc = @esercdoc_siope
		AND ndoc = @numdoc_siope
		AND idinc = @idinc_siope
		AND sortcode = @codiceclass_siope
		AND rowkind = 'T'
	FETCH NEXT FROM curr_siope
	INTO @y_siope, @n_siope, @esercdoc_siope, @numdoc_siope, @idinc_siope, @codiceclass_siope
END
CLOSE curr_siope
DEALLOCATE curr_siope


DECLARE @lenprogressivo int
SET @lenprogressivo = 3

-- Formattazione del progressivo (campo formatted_progressive)
UPDATE #siope SET formatted_progressive = 
CASE
	WHEN DATALENGTH(CONVERT(varchar(3),progressive)) <= @lenprogressivo
	THEN REPLICATE('0',@lenprogressivo - DATALENGTH(CONVERT(varchar(3),progressive))) + CONVERT(varchar(3),progressive)
	ELSE SUBSTRING(CONVERT(varchar(3),progressive),1,@lenprogressivo)
END
	
-- CONTROLLO N. 13 Il numero di classificazioni non può superare il limite massimo per ogni beneficiario
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

IF (SELECT COUNT(*) FROM #pagamento
WHERE idpaymethodTRS = 'D' AND ISNULL(paymentdescr,'') = '') > 0
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il mandato n. ' + CONVERT(varchar(6),ndoc) + '/' + CONVERT(varchar(4),ydoc)
	+ ' contiene movimenti con mod. di pag. DESCRITTIVA senza che sia stata specificata la descrizione per il pagamento'
	FROM #pagamento
	WHERE idpaymethodTRS = 'D' AND ISNULL(paymentdescr,'') = '')

END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN 
END

DECLARE @lencodiceCUP int
SET @lencodiceCUP = 15

DECLARE @dataproduzione datetime
SET @dataproduzione = GETDATE()
DECLARE @dataformattata varchar(8)
SET @dataformattata =
CONVERT(varchar(4),YEAR(@dataproduzione)) +
REPLICATE('0',2 - DATALENGTH(CONVERT(varchar(2),MONTH(@dataproduzione)))) + CONVERT(varchar(2),MONTH(@dataproduzione)) +
REPLICATE('0',2 - DATALENGTH(CONVERT(varchar(2),DAY(@dataproduzione)))) + CONVERT(varchar(2),DAY(@dataproduzione))
DECLARE @tipoflusso varchar(3)
SET @tipoflusso = '001'

-- RECORD 01
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT ypaymenttransmission, npaymenttransmission, 0, 0, 0, 
'01' + '00001' + @tipoflusso + @dataformattata +
-- Progressivo per data
'0' +
@codicefiliale + @codiceente + @descente +
REPLICATE('0',@lennumelenco - DATALENGTH(CONVERT(varchar(5),npaymenttransmission))) + CONVERT(varchar(5),npaymenttransmission) +
-- Codice Ente Nazionale e Decodifica Ente Nazionale
SPACE(22) +
-- Filler
SPACE(510) +
-- Fine Record
'0'
FROM paymenttransmission
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n

print '01'

-- RECORD 02
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT #pagamento.y, #pagamento.n, ndoc,0, 1,
'02' + '00000' + ndocformatted + CONVERT(varchar(4),#pagamento.ydoc)
+ '1' + 
-- Data Contabile Mandato
CONVERT(varchar(4),YEAR(payment_adate)) +
SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(payment_adate)))) +
CONVERT(varchar(2),MONTH(payment_adate)) +
SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(payment_adate)))) +
CONVERT(varchar(2),DAY(payment_adate)) +
-- Capitolo e Articolo di Bilancio
REPLICATE('0',10) +
-- Competenza - Residui (Valorizzo sempre a ZERO perché è un dato facoltativo)
'0' +
-- Fruttifero - Infruttfero (per le spese vale sempre ZERO)
'0' +
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
FROM #pagamento
GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc, #pagamento.ndocformatted,
#pagamento.payment_adate, #pagamento.ndoc

print '02'
-- RECORD 03
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT #pagamento.y, #pagamento.n, ndoc, registry_prog, 2,
'03' + '00000' + ndocformatted + 
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog) +
-- Data Scadenza
REPLICATE('0',8) +
-- Importo dettagli
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(netamount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(netamount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(netamount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(netamount)),
DATALENGTH(CONVERT(varchar(15),SUM(netamount)))-1,2) +
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
-- Descrizione Pagamento : paymentdescr 
------------------------------------------------------------------------------------------------------------------------------------------------
	CASE
	-- CIG  e DESCRIZIONE
			WHEN ( (	DATALENGTH(isnull(CIG,'')) >0
					AND (6+DATALENGTH(ISNULL(CIG,''))+ DATALENGTH(ISNULL(paymentdescr,''))) <= @lendescpagamento ) )
			THEN 'CIG:'+isnull(CIG,'') + '; '+ISNULL(paymentdescr, '') 
					+ SUBSTRING(
								SPACE(@lendescpagamento),
								1,
								@lendescpagamento - 6 - DATALENGTH(ISNULL(CIG,'') + ISNULL(paymentdescr,''))
								)
	-- CIG + DESCRIZIONE troncata
			WHEN ( (	DATALENGTH(isnull(CIG,'')) >0
					AND (6+DATALENGTH(ISNULL(CIG,''))+ DATALENGTH(ISNULL(paymentdescr,''))) > @lendescpagamento ) )
			THEN 'CIG:'+isnull(CIG,'') + '; '+
					+ substring(ISNULL(paymentdescr,''),1,@lendescpagamento -6 -DATALENGTH(isnull(CIG,'')))

	-- DESCRIZIONE e basta, perchè il CIG è null
			ELSE ISNULL(paymentdescr, '') 
					+ SUBSTRING(SPACE(@lendescpagamento),1,	@lendescpagamento - DATALENGTH(ISNULL(paymentdescr,'')))
	END +
	------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Modalità di Esecuzione
idpaymethodTRS +
-- Parte di RIDEFINIZIONE in base alla Modalità di Pagamento adoperata
-- Attenzione per la modalità di pagamento B chiedere a MPS che cosa è precisamente il codice versante (10 caratteri)
CASE 
	WHEN idpaymethodTRS = 'B'
	THEN abi + cab + cc + checkdigit + cin + countrycode + SPACE(23)
	WHEN idpaymethodTRS IN ('O','P','Q')
	THEN cc + SPACE(40)
	WHEN idpaymethodTRS = 'R'
	THEN nbill + SPACE(43)
	WHEN idpaymethodTRS IN ('H')
	THEN REPLICATE('0',19) + SPACE(31)
	WHEN idpaymethodTRS IN ('G')
        THEN extracode + REPLICATE('0',12) + SPACE(31)
	WHEN idpaymethodTRS = 'I'
	THEN reg_location + reg_province
	ELSE SPACE(50)
END +
-- Dati riservati all'ente
SPACE(7) +
-- Conto Corrente di Riferimento (L'università ha sempre un solo CC, tuttavia ha dei sottoconti 
-- corrispondenti ai vari dipartimenti in caso di gestione con Bilancio Unico)
@cc_vincolato + 
-- Esenzione del bollo
freestamp +
-- Importo Trattenute - impostato sempre a ZERO
REPLICATE('0',@lenimporto) +
-- Numero Ordinativo Trattenuta
CASE
	WHEN taxamount = 0 THEN REPLICATE('0',7)
	ELSE ndocformatted
END +
-- Numero Sub Ordinativo
CASE
	WHEN taxamount = 0 THEN REPLICATE('0',5)
	ELSE SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario -
		DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
		CONVERT(varchar(5),registry_prog)
END +
-- Capitolo / Articolo
REPLICATE('0',10) +
-- Dipendente Azienda
employ +
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
FROM #pagamento
GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc, #pagamento.ndocformatted,
#pagamento.payment_adate, #pagamento.ndoc,
reg_title, reg_address, reg_location, reg_cap, reg_cf, paymentdescr,  CIG, idpaymethodTRS,
registry_prog, abi, cab, cc, extracode,cin, freestamp, #pagamento.idexp, #pagamento.reg_province,
#pagamento.checkdigit, #pagamento.countrycode,
#pagamento.netamount, #pagamento.taxamount, #pagamento.reg_p_iva, #pagamento.employ, #pagamento.nbill
HAVING SUM(netamount) <> 0  --- escludo i sub che abbiano un netto pari a zero

/*
SELECT #pagamento.y, #pagamento.n, ndoc, 2,
'03' + '00000' + ndocformatted + 
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog) +
-- Data Scadenza
REPLICATE('0',8) +
-- Importo dettagli
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(netamount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(netamount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(netamount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(netamount)),
DATALENGTH(CONVERT(varchar(15),SUM(netamount)))-1,2) +
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
paymentdescr +
-- Modalità di Esecuzione
idpaymethodTRS +
-- Parte di RIDEFINIZIONE in base alla Modalità di Pagamento adoperata
-- Attenzione per la modalità di pagamento B chiedere a MPS che cosa è precisamente il codice versante (10 caratteri)
CASE 
	WHEN idpaymethodTRS = 'B'
	THEN abi + cab + cc + checkdigit + cin + countrycode + SPACE(23)
	WHEN idpaymethodTRS IN ('O','P','Q')
	THEN cc + SPACE(40)
	WHEN idpaymethodTRS = 'R'
	THEN nbill + SPACE(43)
	WHEN idpaymethodTRS IN ('H')
	THEN REPLICATE('0',19) + SPACE(31)
	WHEN idpaymethodTRS IN ('G')
        THEN extracode + REPLICATE('0',12) + SPACE(31)
	WHEN idpaymethodTRS = 'I'
	THEN reg_location + reg_province
	ELSE SPACE(50)
END +
-- Dati riservati all'ente
SPACE(7) +
-- Conto Corrente di Riferimento (L'università ha sempre un solo CC)
REPLICATE('0',7) +
-- Esenzione del bollo
freestamp +
-- Importo Trattenute - impostato sempre a ZERO
REPLICATE('0',@lenimporto) +
-- Numero Ordinativo Trattenuta
CASE
	WHEN taxamount = 0 THEN REPLICATE('0',7)
	ELSE ndocformatted
END +
-- Numero Sub Ordinativo
CASE
	WHEN taxamount = 0 THEN REPLICATE('0',5)
	ELSE SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario -
		DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
		CONVERT(varchar(5),registry_prog)
END +
-- Capitolo / Articolo
REPLICATE('0',10) +
-- Dipendente Azienda
employ +
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
FROM #pagamento
GROUP BY #pagamento.y, #pagamento.n, #pagamento.ydoc, #pagamento.ndocformatted,
#pagamento.payment_adate, #pagamento.ndoc,
reg_title, reg_address, reg_location, reg_cap, reg_cf, paymentdescr, idpaymethodTRS,
registry_prog, abi, cab, cc, extracode,cin, freestamp, #pagamento.idexp, #pagamento.reg_province,
#pagamento.checkdigit, #pagamento.countrycode,
#pagamento.netamount, #pagamento.taxamount, #pagamento.reg_p_iva, #pagamento.employ, #pagamento.nbill
*/
-- RECORD 03 a) (per le ritenute)
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT @y, @n, ndoc,registry_prog, 4, 
'03' + '00000' +
ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog) +
-- Data Scadenza
REPLICATE('0',8) +
-- Importo Dettagli
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
-- Anagrafica Obbligato
obb_title +
-- Indirizzo
obb_address +
-- Località
obb_location +
-- CAP
obb_cap +
-- Codice Fiscale / Partita IVA
CASE
	WHEN RTRIM(obb_cf) <> '' THEN obb_cf
 	WHEN RTRIM(obb_cf) = '' AND RTRIM(obb_p_iva) <> '' THEN obb_p_iva
	ELSE SPACE(@lencf)
END +
-- Descrizione Incasso
proceedsdescr + 
-- Modalità di Esecuzione
'T' + 
-- Ridefizioni
SPACE(50) +
-- Dati riservati all'ente
SPACE(7) +
-- Conto Corrente di Riferimento (L'università ha sempre un solo CC, possono esserci i sottoconti vincolati
--relativi  ai dipartimenti in caso di Gestione Bilancio Unico)
@cc_vincolato + 
-- Esenzione del bollo
'0' +
-- Importo Trattenute
REPLICATE('0',@lenimporto) +
-- Ordinativo
nproformatted +
-- Sub - Ordinativo
SUBSTRING(REPLICATE('0',@lenprogrreversale),1,@lenprogrreversale - DATALENGTH(CONVERT(varchar(5),proceeds_prog))) + 
CONVERT(varchar(5),proceeds_prog)  +
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
FROM #ritenute 
GROUP BY ndoc, nproformatted, obb_title, obb_address, obb_location, obb_cap, obb_cf, obb_p_iva,
proceeds_prog, proceedsdescr, ndocformatted, registry_prog

/*
-- RECORD 03 a) (per i contributi)
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT @y, @n, ndoc,idpay, 4, 
'03' + '00000' +
ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),idpay))) + 
CONVERT(varchar(5),idpay) +
-- Data Scadenza
REPLICATE('0',8) +
-- Importo Dettagli
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
-- Anagrafica Obbligato
obb_title +
-- Indirizzo
obb_address +
-- Località
obb_location +
-- CAP
obb_cap +
-- Codice Fiscale / Partita IVA
CASE
	WHEN RTRIM(obb_cf) <> '' THEN obb_cf
 	WHEN RTRIM(obb_cf) = '' AND RTRIM(obb_p_iva) <> '' THEN obb_p_iva
	ELSE SPACE(@lencf)
END +
-- Descrizione Incasso
proceedsdescr + 
-- Modalità di Esecuzione
'T' + 
-- Ridefizioni
SPACE(50) +
-- Dati riservati all'ente
SPACE(7) +
-- Conto Corrente di Riferimento (L'università ha sempre un solo CC, possono esserci i sottoconti vincolati
--relativi  ai dipartimenti in caso di Gestione Bilancio Unico)
@cc_vincolato + 
-- Esenzione del bollo
'0' +
-- Importo Trattenute
REPLICATE('0',@lenimporto) +
-- Ordinativo
nproformatted +
-- Sub - Ordinativo
SUBSTRING(REPLICATE('0',@lenprogrreversale),1,@lenprogrreversale - DATALENGTH(CONVERT(varchar(5),idpro))) + 
CONVERT(varchar(5),idpro)  +
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
FROM #admintax
GROUP BY ndoc, nproformatted, obb_title, obb_address, obb_location, obb_cap, obb_cf, obb_p_iva,
idpro, proceedsdescr, ndocformatted, idpay
*/
-- Devono essere aggiunti N record 03 uno per ogni trattenuta.
-- Record '04' non viene prodotto - la descrizione dei pagamenti non supera mai il limite imposto dalla banca
	
-- Record '05' Delegato
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT #pagamento.y, #pagamento.n, #pagamento.ndoc,registry_prog, 5,
'05' + '00000' + ndocformatted + 
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog)  +
CASE
	WHEN #deputy.human = 'S'
	THEN #deputy.surname
	ELSE SPACE(@lencognomedelegato)
END +
CASE
	WHEN #deputy.human = 'S'
	THEN #deputy.forename

	ELSE SPACE(@lennomedelegato)
END +
CASE
	WHEN #deputy.human = 'N'
	THEN #deputy.title
	ELSE SPACE(@lendendelegato)
END +
-- Ruolo del quietanzante
SPACE(170) +
-- Filler
SPACE(210) +
-- Fine Record
'0'
FROM #pagamento
JOIN #deputy
ON #pagamento.iddeputy = #deputy.iddeputy
-- Record '06' Informazioni Bilancio Non Prodotto

-- Record '07' a) Dettaglio trattenute
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT y, n, ndoc, registry_prog, 7,
'07' + '00000' + 
ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog) +
nproformatted +
SUBSTRING(REPLICATE('0',@lenprogrreversale),1,@lenprogrreversale - DATALENGTH(CONVERT(varchar(5),proceeds_prog))) + 
CONVERT(varchar(5),proceeds_prog) +
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
-- Filler
SPACE(553) +
-- Fine Record
'0'
FROM #ritenute
GROUP BY y, n, ndoc, ndocformatted, nproformatted, proceeds_prog, registry_prog

/*
-- Record '07' b) Dettaglio contributi
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT y, n, ndoc, idpay, 7,
'07' + '00000' + 
ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),idpay))) + 
CONVERT(varchar(5),idpay) +
nproformatted +
SUBSTRING(REPLICATE('0',@lenprogrreversale),1,@lenprogrreversale - DATALENGTH(CONVERT(varchar(5),idpro))) + 
CONVERT(varchar(5),idpro) +
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
-- Filler
SPACE(553) +
-- Fine Record
'0'
FROM #admintax
GROUP BY y, n, ndoc, ndocformatted, nproformatted, idpro, idpay
*/
-- Record '08' Siope
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT #siope.y, #siope.n, #siope.ndoc,registry_prog, 8,
'08' + '00000' + #siope.ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),#siope.registry_prog))) + 
CONVERT(varchar(5),#siope.registry_prog) +
-- Progressivo
#siope.formatted_progressive +
#siope.sortcode + SUBSTRING(SPACE(@lencodiceclass),1,@lencodiceclass - DATALENGTH(#siope.sortcode)) +
--Codice Cup
ISNULL(cupcodeexpense, ISNULL(cupcodedetail,ISNULL(cupcodeupb,ISNULL(cupcodefin,'')))) 
	+ SUBSTRING(SPACE(@lencodiceCUP),1,@lencodiceCUP - DATALENGTH(ISNULL(cupcodeexpense,ISNULL(cupcodedetail,ISNULL(cupcodeupb,ISNULL(cupcodefin,'')))))) + 
-- da Codice CUP a Codice CPV (2 campi)
SPACE(14) +
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto - 
DATALENGTH(CONVERT(varchar(15),#siope.amount))) +
SUBSTRING(CONVERT(varchar(15),#siope.amount),1,
DATALENGTH(CONVERT(varchar(15),#siope.amount))-3) +
SUBSTRING(CONVERT(varchar(15),#siope.amount),
DATALENGTH(CONVERT(varchar(15),#siope.amount))-1,2) +
-- Filler
SPACE(523) +
-- Fine Record
'0'
FROM #siope
ORDER BY y, n,ndoc, #siope.progressive

DECLARE @nummandati int
SET @nummandati = (SELECT COUNT(*) FROM #tracciato WHERE stringa LIKE '02%')

DECLARE @limitedatioperativi int
SET @limitedatioperativi = 255

-- Record '10' Informazioni aggiuntive per modalità DESCRITTIVA - D
INSERT INTO #tracciato (y, n, ndoc, progr_submovimento, rownum, stringa)
SELECT y, n, ndoc,registry_prog, 10,
'10' + '00000' + ndocformatted +
SUBSTRING(REPLICATE('0',@lenprogrbeneficiario),1,@lenprogrbeneficiario - DATALENGTH(CONVERT(varchar(5),registry_prog))) + 
CONVERT(varchar(5),registry_prog) +
-- Dati Operativi
CASE
        WHEN ((idpaymethodflag&4)<>0 -->coord.banc.obbligatorie
                AND (DATALENGTH(ISNULL(iban,''))+ 6 + DATALENGTH(ISNULL(paymentdescr,''))) <= @limitedatioperativi ) 
        THEN 'IBAN:' + iban +' '+ISNULL(paymentdescr, '') 
                + SPACE(@limitedatioperativi -  DATALENGTH(ISNULL(iban,''))- 6 - DATALENGTH(ISNULL(paymentdescr,'')))
        WHEN ((idpaymethodflag&4)<>0 
                AND (DATALENGTH(ISNULL(paymentdescr,''))+ DATALENGTH(ISNULL(iban,''))+6) > @limitedatioperativi ) 
        THEN 'IBAN:' + iban + SPACE(@limitedatioperativi -  DATALENGTH(ISNULL(iban,''))-5 )
	WHEN DATALENGTH(ISNULL(paymentdescr,'')) <= @limitedatioperativi
	THEN ISNULL(paymentdescr, '') + SPACE(@limitedatioperativi - DATALENGTH(ISNULL(paymentdescr,'')))
	ELSE SUBSTRING(paymentdescr, 1, @limitedatioperativi)
END +
-- Filler
SPACE(325) +
-- Fine Record
'0'
FROM #pagamento
WHERE idpaymethodTRS = 'D'

-- Record '09' Riepilogativa (OBBLIGATORIO)
INSERT INTO #tracciato (y, n, ndoc,progr_submovimento, rownum, stringa)
SELECT ypaymenttransmission, npaymenttransmission,999999, 999999, 19,
'09' + '00000' + @dataformattata + '0'
+ @codicefiliale + @codiceente +
-- Numero Reversali (Le reversali sono trasmesse da un'altra procedura, ciò che qui trasmetto sono le trattenute)
REPLICATE('0',5) +
-- Totale Entrate (Sempre ZERO)
REPLICATE('0',@lenimporto) +
-- Numero Mandati
REPLICATE('0',5 - DATALENGTH(CONVERT(varchar(5),@nummandati))) + CONVERT(varchar(5),@nummandati) +
-- Totale Uscite
SUBSTRING(REPLICATE('0',@lenimporto),1,1 + @lenimporto -
	DATALENGTH(
		CONVERT(varchar(15),
			(SELECT SUM(curramount) FROM #pagamento
			WHERE y = paymenttransmission.ypaymenttransmission
			AND n = paymenttransmission.npaymenttransmission)
		)
	)
) +
SUBSTRING(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #pagamento
		WHERE y = paymenttransmission.ypaymenttransmission
		AND n = paymenttransmission.npaymenttransmission)
	),1,
	DATALENGTH(
		CONVERT(varchar(15),
			(SELECT SUM(curramount) FROM #pagamento
			WHERE y = paymenttransmission.ypaymenttransmission
			AND n = paymenttransmission.npaymenttransmission)
		)
	) - 3
) + 
SUBSTRING(
	CONVERT(varchar(15),
		(SELECT SUM(curramount) FROM #pagamento
		WHERE y = paymenttransmission.ypaymenttransmission
		AND n = paymenttransmission.npaymenttransmission)
	),
	DATALENGTH(
		CONVERT(varchar(15),
			(SELECT SUM(curramount) FROM #pagamento
			WHERE y = paymenttransmission.ypaymenttransmission
			AND n = paymenttransmission.npaymenttransmission)
		)
	)-1, 2
) +
-- Filler
SPACE(535) +
-- Fine Record
'0'
FROM paymenttransmission
WHERE ypaymenttransmission = @y
AND npaymenttransmission = @n

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
-- M.P.S. vuole che ogni riga del flusso debba avere una numerazione continua partendo da 1, quindi bisogna
-- rinumerare tutte le righe cambiando i 5 caratteri dalla posizione 3 alla 7
-- A tal fine si definisce una variabile @progrflusso che per ogni riga effettui questa rinumerazione.
-- Attenzione questo progressivo non ha nulla a che vedere con i progressivi degli ordinativi!
DECLARE @stringa varchar(600)
DECLARE @str varchar(600)
DECLARE @progrflusso int
DECLARE @pf_str varchar(5)
SET @progrflusso = 1
DECLARE curr_stringa INSENSITIVE CURSOR FOR
SELECT stringa FROM #tracciato
ORDER BY y, n, ndoc,progr_submovimento, rownum
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
ORDER BY y, n, ndoc, progr_submovimento,  rownum
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



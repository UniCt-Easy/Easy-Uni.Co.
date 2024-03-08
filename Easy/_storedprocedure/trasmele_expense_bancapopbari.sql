
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_bancapopbari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_bancapopbari]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [trasmele_expense_bancapopbari]
	@y smallint,
	@n int
AS BEGIN
/* Versione 1.1.0 del 09/07/2008 ultima modifica: GIUSEPPE */

-- Inizio Sezione dei controlli preventivi
CREATE TABLE #error (message varchar(400))
DECLARE @maxexpensephase tinyint -- Ultima fase di spesa (fase di cassa)
SELECT @maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @lastexpensephase varchar(50)
SELECT @lastexpensephase = description FROM expensephase WHERE nphase = @maxexpensephase

DECLARE @kpaymenttransmission int

SELECT 	@kpaymenttransmission = kpaymenttransmission
FROM 	paymenttransmission
WHERE 	ypaymenttransmission = @y
	AND npaymenttransmission = @n

DECLARE @message varchar(250)

IF EXISTS
(SELECT * FROM paymentcommunicated
WHERE ypaymenttransmission = @y
AND npaymenttransmission = @n
AND idpaymethod IS NULL)
BEGIN
	INSERT INTO #error (message)
		(SELECT ' Nella ' + @lastexpensephase + ' n.' + CONVERT(varchar(6),nmov) 
		+ '/' + CONVERT(varchar(4),ymov) + ' non è stata scelta una modalità di pagamento'
		FROM paymentcommunicated
		WHERE ypaymenttransmission = @y
		AND npaymenttransmission = @n
		AND idpaymethod IS NULL)
END

IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
AND paymentcommunicated.npaymenttransmission = @n
AND (paymethod.methodbankcode IS NULL OR REPLACE(paymethod.methodbankcode,' ','') = '')
)
BEGIN
	INSERT INTO #error (message)
		(SELECT ' Nella ' + @lastexpensephase + ' n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' la modalità di pagamento scelta non è configurata, Andare in Configurazione - Anagrafica - Modalità di Pagamento'
		FROM paymentcommunicated
		JOIN paymethod
		ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.ypaymenttransmission = @y
		AND paymentcommunicated.npaymenttransmission = @n
		AND (paymethod.methodbankcode IS NULL OR REPLACE(paymethod.methodbankcode,' ','') = '')
		)
END

IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
AND paymentcommunicated.npaymenttransmission = @n
AND paymethod.methodbankcode = '03'
AND (paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
AND (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
)
BEGIN
	INSERT INTO #error (message)
		(SELECT ' Nella ' + @lastexpensephase + ' n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento scelta non è stato assegnato il codice ABI / CAB.'
		FROM paymentcommunicated
		JOIN paymethod
		ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.ypaymenttransmission = @y
		AND paymentcommunicated.npaymenttransmission = @n
		AND paymethod.methodbankcode = '03'
		AND (paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
		AND (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
		)
END

IF EXISTS
(SELECT * FROM payment
JOIN stamphandling
	ON payment.idstamphandling = stamphandling.idstamphandling
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @y
AND paymenttransmission.npaymenttransmission = @n
AND (stamphandling.handlingbankcode IS NULL OR stamphandling.handlingbankcode = '')
)
BEGIN
	INSERT INTO #error (message)
		(SELECT ' Nel mandato ' + ' n.' + CONVERT(varchar(6),payment.ypay) 
		+ '/' + CONVERT(varchar(4),payment.npay) + ' il trattamento del bollo non è stato configurato'
		FROM payment
		JOIN stamphandling
		ON payment.idstamphandling = stamphandling.idstamphandling
		JOIN paymenttransmission
			ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		WHERE paymenttransmission.ypaymenttransmission = @y
		AND paymenttransmission.npaymenttransmission = @n
		AND (stamphandling.handlingbankcode IS NULL OR stamphandling.handlingbankcode = '')
		)
END

DECLARE @dipendenza varchar(5) -- Variabile di dipendenza comunicabile dalla Banca che richiede l'esportazione
DECLARE @codicefiliale varchar(3) -- Codice della filiale
DECLARE @codiceente varchar(9) -- Codice dell'ente da esportare
DECLARE @cc_number varchar(28) -- Numero del Conto dell'ente presso l'istituto cassiere
DECLARE @cino char(2) -- Codice CIN

-- J.T.R. su richiesta della Banca Pop. di Bari il CIN del tesoriere deve sempre essere trasmesso come 00
SET @cino = '00'

DECLARE @idtreasurer int
SELECT @idtreasurer = idtreasurer from paymenttransmission where ypaymenttransmission = @y and npaymenttransmission = @n
IF (@idtreasurer IS NULL) 
BEGIN
	SELECT @idtreasurer = MAX(idtreasurer) FROM treasurer WHERE flagdefault='S'
END
IF (@idtreasurer IS NULL) 
BEGIN
	SELECT @idtreasurer = MAX(idtreasurer) FROM treasurer 
END

SELECT
	@dipendenza = depcodefortransmission,
	@codicefiliale = cabcodefortransmission,
	@codiceente = agencycodefortransmission,
	@cc_number = ISNULL(cc,'')
	--@cino = ISNULL(cin, '00') 
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @errore char(1)
SET @errore = 'N'
SET @message = 'Mancano i seguenti dati: '
IF (@dipendenza IS NULL OR @dipendenza = '')
BEGIN		SET @message = @message + ' Il Codice Istituto'
	SET @errore = 'S'
END
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
IF (@errore = 'S')
BEGIN
	SET @message = @message + ' Andare nella maschera CONFIGURAZIONE - CASSIERE - CASSIERE ed inserire i dati'
	INSERT INTO #error VALUES(@message)
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

DECLARE @codeclassSIOPE varchar(20)

-- In questo IF si sceglie il codice del tipo classificazione a seconda se stiamo trasmettendo fino al 2006 o dal 2007 in poi
DECLARE @npos int
IF (@y <= 2006)
BEGIN
	SET @codeclassSIOPE = 'SIOPE'
	SET @npos = 2
END
ELSE
BEGIN
	SET @codeclassSIOPE = '07U_SIOPE'
	SET @npos = 1
END

DECLARE @classSIOPE int
SELECT @classSIOPE = idsorkind FROM sortingkind WHERE codesorkind = @codeclassSIOPE
CREATE TABLE #nclass_SIOPE
(
	ydoc int,
	ndoc int,
	idreg int,
	nsorting int
)

INSERT INTO #nclass_SIOPE
SELECT ydoc, ndoc, idreg, COUNT(*)
FROM
	(SELECT 
		expensesorted.idsor AS idsor,
		expense.idreg AS idreg,
		expense.ymov AS ydoc,
		payment.npay AS ndoc
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN expensesorted
		ON expense.idexp = expensesorted.idexp
	JOIN sorting
		ON sorting.idsor = expensesorted.idsor
	JOIN payment
		ON expenselast.kpay = payment.kpay
	JOIN paymenttransmission
		ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
	WHERE paymenttransmission.ypaymenttransmission = @y
		AND paymenttransmission.npaymenttransmission = @n
		AND sorting.idsorkind = @classSIOPE
	GROUP BY expense.idreg, expense.ymov, payment.npay,
	expensesorted.idsor) AS tabella
GROUP BY idreg, ydoc, ndoc

DECLARE @limite int
SET @limite = 12
IF EXISTS(SELECT * FROM #nclass_SIOPE WHERE nsorting > @limite)
BEGIN
	INSERT INTO #error (message)
		SELECT 'Nel mandato ' + CONVERT(varchar(6),ndoc) + '/' + CONVERT(varchar(4),ydoc)
		+ ' i movimenti di spesa associati al percipiente ' + registry.title
		+ ' hanno un numero di classificazioni SIOPE superiore al limite di ' + CONVERT(varchar(3),@limite)
		FROM #nclass_SIOPE
		JOIN registry
		ON #nclass_SIOPE.idreg = registry.idreg
		WHERE nsorting > @limite
		ORDER BY nsorting
		
END

-- Uso di modalità di pagamento con codice methodbankcode 
-- di lunghezza diversa da due
INSERT INTO #error (message)
SELECT distinct 'Correggere il codice della modalità di pagamento ' + pm.description + '. La lunghezza deve essere 2. '
FROM expenselast el
JOIN payment p
	ON p.kpay = el.kpay
JOIN paymethod pm
	ON el.idpaymethod = pm.idpaymethod
WHERE p.kpaymenttransmission = @kpaymenttransmission 
        AND len(pm.methodbankcode)<>2

--Uso di modalità di pagamento NON ammesse dalla banca-  
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata una modalità di pagamento non prevista dalla banca.'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode NOT IN ('00','01','02','03','05','09')
)


IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
	
-- Fine Sezione dei controlli preventivi

DECLARE @tipodocumento char(1) --
-- Dichiarazione delle lunghezze dei campi utilizzate nel tracciato, in modo che se dovesse cambiare in futuro la lunghezza di uno di questi campi
-- si modifica solo la riga SET corrispondente
DECLARE @lendipendenza int -- Lunghezza della Dipendenza (Il valore viene comunicato dall'istituto cassiere)
DECLARE @lencodicefiliale int -- Lunghezza del Codice Filiale (Il valore viene comunicato dall'istituto cassiere)
DECLARE @lencodiceente int -- Lunghezza del Codice Ente (Il valore viene comunicato dall'istituto cassiere)
DECLARE @tipodoc char(1)  -- Tipo di documento ( M = Mandato)
DECLARE @lennumdoc int -- Lunghezza del numero di documento
DECLARE @lennumsubmov int -- Lunghezza del numero del sub movimento
DECLARE @lenritenute int -- Lunghezza importo ritenute
DECLARE @causaleente varchar(2) -- Causale conto dell'ente
DECLARE @lenCC int -- Lunghezza del C/C
DECLARE @lenCIN int -- Lunghezza del CIN
DECLARE @lenABI int -- Lunghezza del Codice ABI
DECLARE @lenCAB int -- Lunghezza del codice CAB
DECLARE @lendescrizione int -- Lunghezza della descrizione del mandato
DECLARE @lencreditore int -- Lunghezza della denominazione del creditore
DECLARE @lenindirizzo int -- Lunghezza dell'indirizzo
DECLARE @lenlocalita int -- Lunghezza della località
DECLARE @lencodicepostale int -- Lunghezza del Codice Postale
DECLARE @lenprovincia int -- Lunghezza della sigla della provincia
DECLARE @lencodeSIOPE int -- Lunghezza del codice SIOPE
DECLARE @lenCCmod0203 int -- Lunghezza del C/C nelle modalità 02 e 03
DECLARE @lenIBAN int -- Lunghezza del codice IBAN
DECLARE @lencf int -- Lunghezza del Codice Fiscale

SET @lendipendenza = 3
SET @lencodicefiliale = 3
SET @lencodiceente = 9
SET @tipodoc = 'M'
SET @lennumdoc = 7
SET @lennumsubmov = 7
SET @lenritenute = 14
SET @causaleente = '4M'
SET @lenCC = 8
SET @lenCCmod0203 = 12
SET @lenCIN = 2
SET @lenABI = 5
SET @lenCAB = 5
SET @lendescrizione = 60
SET @lencreditore = 50
SET @lenindirizzo = 30	SET @lenlocalita = 25
SET @lencodicepostale = 5
SET @lenprovincia = 2
SET @lencodeSIOPE = 10
SET @lenIBAN = 34
SET @lencf = 16
	
-- Formattazione dei codici per il riconoscimento della banca, e del C/C in tal modo risparmio gli N controlli nella UNION
SET @dipendenza =
	CASE 
		WHEN LEN(@dipendenza)<= @lendipendenza THEN 
			SUBSTRING('000', 1, @lendipendenza - LEN(@dipendenza))+ CONVERT(varchar(3),@dipendenza)
		ELSE CONVERT(varchar(3),@dipendenza)
	END
SET @codicefiliale = 
	CASE 
		WHEN LEN(RTRIM(@codicefiliale))<= @lencodicefiliale THEN 
			SUBSTRING('000', 1, @lencodicefiliale - LEN(RTRIM(@codicefiliale)))+ CONVERT(varchar(3),@codicefiliale)
		ELSE CONVERT(varchar(3),RTRIM(@codicefiliale))
	END
SET @codiceente =
	CASE 
		WHEN LEN(RTRIM(@codiceente))<= @lencodiceente THEN 
			SUBSTRING('000000000', 1, @lencodiceente - LEN(RTRIM(@codiceente)))+ CONVERT(varchar(9),@codiceente)
		ELSE CONVERT(varchar(9),RTRIM(@codiceente))
	END
SET @cc_number = 
	CASE 
		WHEN LEN(RTRIM(@cc_number)) <= @lenCC THEN 
			SUBSTRING('00000000', 1, @lenCC - LEN(RTRIM(@cc_number))) + CONVERT(varchar(8),RTRIM(@cc_number))
		WHEN LEN(RTRIM(@cc_number)) > @lenCC AND SUBSTRING(@cc_number, 1, 4) = '0000'
			THEN SUBSTRING(SUBSTRING(@cc_number,5,LEN(RTRIM(@cc_number))), 1, @lenCC)
		ELSE SUBSTRING(RTRIM(@cc_number), 1, @lenCC)
	END
-- Questa parte è stata commentata su richiesta della banca che non vuole impostare il CIN
/*
	SET @cino = 
		CASE 
			WHEN LEN(@cino)<= @lenCIN THEN SUBSTRING('00', 1, @lenCIN - LEN(@cino))+ @cino
			ELSE SUBSTRING(@cino,1,@lenCIN)
		END
*/
-- Fine Formattazione
	
-- Tabella di OUTPUT
CREATE TABLE  #temp (stri varchar(400) COLLATE SQL_Latin1_General_CP1_CI_AS)

--- RITENUTE --
-- Creazione per ogni singolo beneficiario di due sub: 
-- IL PRIMO per l'importo netto da riconoscere 
-- al beneficiario, a cui dovrà essere associato il tipo di pagamento previsto dalla NOTA 2
-- IL SECONDO per l'importo delle ritenute a cui sarà associato il tipo pagamento 01 fisso
-- azzerando le eventuali coordinate bancarie impostate 
-- 
-- Qualora il mandato sia emesso a favore di più beneficiari potranno essere caricati tanti sub quanti sono
-- i beneficiari stessi per l'importo netto e un unico sub riferito all'importo complessivo delle ritenute
-- Ho inserito qui il campo Descrizione in quanto non voglio che sia ripetuto piu'
-- volte il record a causa del fatto che ogni riga di mandato ha una descrizione diversa
	
-- Esportazione dei mandati di pagamento
CREATE TABLE #totale
(
	ndoc int, 
	kdoc int,
	nsub int, 
	amount_payment decimal(19,2), 
	tax decimal(19,2), 
	clawback decimal(19,2), 
	netamount decimal(19,2),
	idreg int,
	idpaymethodTRS varchar(9),
	abi varchar(10), 
	cab varchar(10), 
	cc varchar(25), 
	iban varchar(34), 
	description varchar(100), 
	paymentdescr varchar(100),
	ndocformatted varchar(7),
	nsubformatted varchar(7),
	adate datetime,
	registry varchar(100), 
	cf varchar(20), 
	p_iva varchar(15), 
	idstamphandling varchar(20), 
	address varchar(80), 
	location varchar(50), 
	cap varchar(15), 
	province varchar(2),
	birthdate varchar(30),
	cin1 varchar(20)
)

-- Esportazione dei mandati e delle ritenute associate
CREATE TABLE #tax_pag_detail
(
	agencycode varchar(9), 
	ydoc int, 
	kind char(1), 
	ndoc int, 
	ndocformatted varchar(7),
	nsub int, 
	nsubformatted varchar(7),
	tax decimal(19,2), 
	clawback decimal(19,2) 
)

-- Esportazione dei pagamenti
CREATE TABLE #pagamento
(
	idexp int,
	agencycode varchar(9), 
	kdoc int,
	ydoc int, 
	kind char(1), 
	ndoc int, 
	ndocformatted varchar(7),
	fulfilled char(1),
	paymentdescr varchar(150), 
	nmov int, 
	amount_submov decimal(19,2), 
	idreg int,
	registry varchar(100), 
	cf varchar(20), 
	p_iva varchar(15), 
	idstamphandling varchar(20), 
	address varchar(80), 
	location varchar(50), 
	cap varchar(15), 
	province varchar(2), 
	description varchar(150), 
	abi varchar(10), 
	cab varchar(10), 
	cin1 varchar(20),
	cc varchar(25),
	iban varchar(34),
	idpaymethodTRS varchar(9),
	tax decimal(19,2), 
	clawback decimal(19,2), 
	adate varchar(11), 
	transmissiondate varchar(11), 
	birthdate varchar(30) 
)
	
-- Tabella utilizzata per immagazzinare gli indirizzi dei creditori debitori che si trovano negli eLENchi di trasmissione da esportare
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

-- Inizio Gestione degli indirizzi
DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_AVV'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand
	
-- Si fissa una data di riferimento per la validità degli indirizzi
-- Si sceglie di selezionare la data di trasmissione della distinta
DECLARE @transdate datetime
SELECT @transdate = transmissiondate FROM paymenttransmission WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n

DECLARE @dateindi datetime
SET @dateindi = @transdate
	
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
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
	registryaddress.cap,
	geo_country.province,
	CASE 
		WHEN registryaddress.flagforeign = 'N' THEN 'ITALIA'
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
		AND idreg IN
			(SELECT idreg FROM paymentcommunicated
			WHERE ypaymenttransmission = @y and npaymenttransmission = @n)

DELETE #rptindirizzoavpag
WHERE #rptindirizzoavpag.idaddresskind <> @nostand
AND EXISTS(
	SELECT * FROM #rptindirizzoavpag r2 
	WHERE #rptindirizzoavpag.idreg=r2.idreg
	AND r2.idaddresskind = @nostand
)

DELETE #rptindirizzoavpag
WHERE #rptindirizzoavpag.idaddresskind NOT IN (@nostand, @stand)
AND EXISTS(
	SELECT * FROM #rptindirizzoavpag r2 
	WHERE #rptindirizzoavpag.idreg=r2.idreg
	AND r2.idaddresskind = @stand
)

DELETE #rptindirizzoavpag
WHERE (
	SELECT COUNT(*) FROM #rptindirizzoavpag r2 
	WHERE #rptindirizzoavpag.idreg=r2.idreg
)>1

-- CONTROLLO N. 7 Ogni beneficiario deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM paymentcommunicated WHERE idreg NOT IN
		(SELECT  idreg FROM #rptindirizzoavpag ind)
	AND ypaymenttransmission = @y
	AND npaymenttransmission = @n)
)
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Il beneficiario ' + ISNULL(registry.title,' ') +
		+ ' non ha un indirizzo valido associato '
		FROM paymentcommunicated
		JOIN registry
			ON paymentcommunicated.idreg = registry.idreg
		WHERE paymentcommunicated.idreg NOT IN
			(SELECT  idreg FROM #rptindirizzoavpag ind)
		AND ypaymenttransmission = @y
		AND npaymenttransmission = @n
		)
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
-- Fine Gestione degli Indirizzi

-- Il tipo documento è determinato dalla Banca e vale sempre 1 per la trasmissione dei mandati
SELECT @tipodocumento = '1'
	
-- La tabella viene riempita con tutti i movimenti di spesa che rientrano nella distinta di trasmissione.
-- Durante il riempimento si cerca di formattare i dati secondo le specifiche tecniche fornite dalla banca.
INSERT INTO #pagamento
(	
	idexp,
	agencycode,
	kdoc,
	ydoc,
	kind,
	ndoc,
	nmov,
	fulfilled,
	paymentdescr,
	amount_submov,
	idreg,
	registry,
	cf,
	p_iva,
	idstamphandling,
	address,
	location,
	cap,
	province,
	description,
	abi,
	cab,
	cin1,
	cc,
	iban,
	idpaymethodTRS,
	adate,
	transmissiondate,
	birthdate,
	tax
)
SELECT DISTINCT
	expense.idexp,
	@codiceente,
	expenselast.kpay,
	expense.ymov,
	@tipodocumento,
	payment.npay,
	expense.nmov,
	CASE
		WHEN (( expenselast.flag & 1) = 0) THEN 'N'
		WHEN (( expenselast.flag & 1) <> 0) THEN 'S'
	END,
	expenselast.paymentdescr,
	expensetotal.curramount,
	registry.idreg,
	CASE
		WHEN RTRIM(DATALENGTH(registry.title)) <= @lencreditore THEN
			RTRIM(registry.title) + SPACE(@lencreditore - DATALENGTH(RTRIM(registry.title)))
		ELSE SUBSTRING(registry.title,1,@lencreditore)
	END,
	registry.cf,
	registry.p_iva,
	stamphandling.handlingbankcode,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.address,'')) <= @lenindirizzo
		THEN SPACE(@lenindirizzo - DATALENGTH(ISNULL(#rptindirizzoavpag.address,''))) + ISNULL(#rptindirizzoavpag.address,'')
		ELSE SUBSTRING(#rptindirizzoavpag.address, 1, @lenindirizzo)
	END,
	CASE
		WHEN DATALENGTH(#rptindirizzoavpag.location) <= @lenlocalita
		THEN SPACE(@lenlocalita - DATALENGTH(ISNULL(#rptindirizzoavpag.location,''))) + ISNULL(#rptindirizzoavpag.location,'')
		ELSE SUBSTRING(#rptindirizzoavpag.location, 1, @lenlocalita)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.cap,'')) <= @lencodicepostale
		THEN REPLICATE('0', @lencodicepostale - DATALENGTH(ISNULL(#rptindirizzoavpag.cap,''))) + ISNULL(#rptindirizzoavpag.cap,'')
		ELSE SUBSTRING(#rptindirizzoavpag.cap, 1, @lencodicepostale)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.province,'')) <= @lenprovincia
		THEN SPACE(@lenprovincia - DATALENGTH(ISNULL(#rptindirizzoavpag.province,''))) + ISNULL(#rptindirizzoavpag.province,'')
		ELSE SUBSTRING(#rptindirizzoavpag.province,1,@lenprovincia)
	END,
	expense.description,
	CASE
		WHEN paymethod.methodbankcode IN ('03', '04') THEN
		CASE
			WHEN LEN(RTRIM(ISNULL(expenselast.idbank,''))) <= @lenABI THEN 
				REPLICATE('0', @lenABI - LEN(RTRIM(ISNULL(expenselast.idbank,'')))) + RTRIM(ISNULL(expenselast.idbank,''))
			ELSE SUBSTRING(RTRIM(expenselast.idbank), 1, @lenABI)
		END
	END,
	CASE
		WHEN paymethod.methodbankcode = '03' THEN
		CASE
			WHEN LEN(RTRIM(ISNULL(expenselast.idcab,''))) <= @lenCAB THEN
				REPLICATE('0', @lenCAB - LEN(RTRIM(ISNULL(expenselast.idcab,'')))) + RTRIM(ISNULL(expenselast.idcab,''))
			ELSE SUBSTRING(RTRIM(expenselast.idcab), 1, @lenCAB)
		END
	END,
	expenselast.cin,
	expenselast.cc,
	CASE 
		WHEN expenselast.iban IS NULL THEN SPACE(@lenIBAN)
		WHEN LEN(RTRIM(expenselast.iban)) <= @lenIBAN THEN
		SPACE(@lenIBAN - LEN(RTRIM(expenselast.iban))) + RTRIM(expenselast.iban)
		ELSE SUBSTRING(expenselast.iban, 1, @lenIBAN)
	END,
	paymethod.methodbankcode,
	payment.adate,
	paymenttransmission.transmissiondate,
	registry.birthdate,
	ISNULL(
		(SELECT SUM(expensetax.employtax)
		FROM expensetax
		WHERE expensetax.idexp = expense.idexp)
	,0) 
	+
	ISNULL(
		(SELECT SUM(expenseclawback.amount)
		FROM expenseclawback
		WHERE expenseclawback.idexp = expense.idexp)
	,0)
	+
	ISNULL(
		(SELECT SUM(incomeyear.amount)
		   FROM income
		   JOIN incomelast
		     ON income.idinc = incomelast.idinc
		   JOIN incometotal
		     ON income.idinc = incometotal.idinc and ((incometotal.flag & 2) = 2) 
		   JOIN incomeyear
		     ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
		  WHERE ISNULL(income.autokind,0) = 14 
		    AND income.idpayment = expense.idexp
		    AND income.autocode IS NULL)
	,0)
FROM expense
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission
JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN #rptindirizzoavpag
	ON #rptindirizzoavpag.idreg = registry.idreg		
LEFT OUTER JOIN paymethod
	ON expenselast.idpaymethod = paymethod.idpaymethod
LEFT OUTER JOIN stamphandling
	ON payment.idstamphandling = stamphandling.idstamphandling
WHERE paymenttransmission.ypaymenttransmission = @y
	AND paymenttransmission.npaymenttransmission = @n
	AND expensetotal.ayear = @y
ORDER BY expense.ymov, payment.npay

-- Si calcola il campo ndocformatted che rappresenta il campo ndoc in formato stringa, conviene adoperarlo in modo da risparmiare successivamente
-- tempo nel calcolarlo
UPDATE #pagamento
SET ndocformatted =
CASE
	WHEN LEN(#pagamento.ndoc)<= @lennumdoc THEN 
		REPLICATE('0', @lennumdoc - LEN(CONVERT(varchar(7), #pagamento.ndoc))) + 
		CONVERT(varchar(7),#pagamento.ndoc)
	ELSE SUBSTRING(CONVERT(varchar(7),#pagamento.ndoc), 1, @lennumdoc)
END

-- Calcolo i mandati raggruppandoli per percipiente
INSERT INTO #totale
(
	ndoc, ndocformatted, kdoc,
	amount_payment,
	idreg,
	abi, cab, cc, iban,
	idpaymethodTRS, description, tax,
	adate, 
	registry, cf, p_iva, idstamphandling, 
	address, location, cap, province, birthdate, cin1
)
SELECT 
	ndoc, ndocformatted, kdoc, 
	ISNULL(SUM(amount_submov),0),
	idreg,
	ISNULL(abi,''), ISNULL(cab,''), ISNULL(cc, ''),
	iban,
	ISNULL(idpaymethodTRS,''), ' ', SUM(tax),
	adate,
	registry, cf, p_iva, idstamphandling, 
	address, location, cap, province, birthdate, cin1
FROM #pagamento
GROUP BY ndoc, ndocformatted, kdoc, idreg, ISNULL(idpaymethodTRS, ''),
	ISNULL(abi,''),ISNULL(cab,''),ISNULL(cc, ''), iban, adate,
	registry, cf, p_iva, idstamphandling, 
	address, location, cap, province, birthdate, cin1

-- Sezione per l'assegnazione del submovimento
/*
  Il submovimento viene calcolato alla stregua dell'uguaglianza dei seguenti campi:
  ID del percipiente, modalità di pagamento e coordinate bancarie appartenenti allo stesso mandato
*/

DECLARE @idreg int
DECLARE @numdoc int
DECLARE @numsubmov int
DECLARE @numdoc1 int
DECLARE @idpaymethodTRS varchar(9)
DECLARE @coordbancarie varchar(50)
DECLARE @codiceabi varchar(50)
DECLARE @codicecab varchar(50) 
DECLARE @contocorrente varchar(50)
DECLARE @iban varchar(34)
DECLARE @numdocold int
DECLARE @idregold int
SELECT @numsubmov = 0

-- Si definisce il cursore sulla tabella totale (dove i pagamenti sono stati già raggruppati)
DECLARE #esercizio_cursor1 INSENSITIVE CURSOR FOR
SELECT
	ndoc, idreg, idpaymethodTRS, 
	abi,cab,cc, iban
FROM #totale

OPEN #esercizio_cursor1
FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @idreg, @idpaymethodTRS, @codiceabi, @codicecab, @contocorrente, @iban
-- Si pone la var numdoc1 pari a numdoc (estratta dal cursore), numdoc1 funge da variabile di confronto
SELECT @numdoc1 = @numdoc 
WHILE (@@FETCH_STATUS = 0)
BEGIN		
	-- Finchè il numdoc1 è uguale a numdoc si incrementa il submovimento
	WHILE (@numdoc1 = @numdoc) AND (@@FETCH_STATUS = 0)
	BEGIN
		SELECT @numsubmov = @numsubmov + 1
		
		UPDATE #totale SET nsub = @numsubmov
		WHERE ndoc = @numdoc
			AND idreg = @idreg	
			AND idpaymethodTRS = @idpaymethodTRS
			AND ISNULL(abi,'') = ISNULL(@codiceabi,'')
			AND ISNULL(cab,'') = ISNULL(@codicecab,'')
			AND ISNULL(cc,'') = ISNULL(@contocorrente,'')
			AND ISNULL(iban,'') = ISNULL(@iban,'')

		SELECT @numdocold = @numdoc
		SELECT @idregold = @idreg	

		FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @idreg, @idpaymethodTRS, @codiceabi, @codicecab, @contocorrente, @iban
	END 

	-- Se il submovimento è pari a 1 viene reimpostato a zero (sono disposizioni della banca)
	IF @numsubmov = 1
	BEGIN
		UPDATE #totale SET nsub = 0
		WHERE ndoc = @numdocold AND idreg = @idregold	
	END

	SELECT @numsubmov = 0
	SELECT @numdoc1 = @numdoc 
END
CLOSE #esercizio_cursor1
DEALLOCATE #esercizio_cursor1
	
-- Si definisce un nuovo cursore per impostare descrizione e descrizione del pagamento identici per tutti i sub
DECLARE @descrizione varchar(100)
DECLARE @descrizionePAGAM varchar(100)
DECLARE #esercizio_cursor1 INSENSITIVE CURSOR FOR
SELECT ndoc,idreg,description,paymentdescr FROM #pagamento
OPEN #esercizio_cursor1
FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @idreg, @descrizione, @descrizionePAGAM
WHILE (@@FETCH_STATUS = 0)
BEGIN
	UPDATE #totale SET description = @descrizione
	WHERE #totale.ndoc = @numdoc 
		AND #totale.idreg = @idreg

	UPDATE #totale SET paymentdescr = @descrizionePAGAM
	WHERE #totale.ndoc = @numdoc 
		AND #totale.idreg = @idreg

	FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @idreg, @descrizione, @descrizionePAGAM
END 
DEALLOCATE #esercizio_cursor1

-- Si imposta il netto pari alla differenza tra importo del sub e le trattenute
UPDATE #totale SET netamount = ISNULL(amount_payment, 0) - ISNULL(tax, 0)

-- Inizializzazioni variabili fisse
-- Ricalcolo del C/C nel caso in cui ci siano simboli separatori
-- Si scartano i simboli "-", ".", "/" dal conto corrente, successivamente si valuta la sua lunghezza e si confronta con le lunghezze definite
-- dalla banca a seconda della modalità di pagamento.
-- Se il C/C ha lunghezza superiore la procedura viene terminata, diversamente si procede a riempire il C/C dei caratteri mancanti
DECLARE @strCC varchar(12)
DECLARE @strC varchar(12)
DECLARE @codmod varchar(10)
DECLARE @ydoc int
DECLARE @ndoc int
DECLARE @nmov int
DECLARE CC_Cursor INSENSITIVE CURSOR FOR
SELECT cc, idpaymethodTRS, ydoc, ndoc, nmov FROM #pagamento
WHERE idpaymethodTRS IN ('02','03','09')
OPEN CC_Cursor
FETCH NEXT FROM CC_Cursor INTO @strCC,@codmod,@ydoc,@ndoc,@nmov
WHILE (@@FETCH_STATUS = 0)
BEGIN
SET @strC = @strCC
IF PATINDEX('%-%',@strCC) > 0
	SELECT @strC = SUBSTRING(@strCC,1,PATINDEX('%-%',@strCC)-1)
IF PATINDEX('%.%',  @strC) > 0
	SELECT @strC = SUBSTRING(@strC,1,PATINDEX('%.%', @strC)-1)
IF PATINDEX('%/%',  @strC) > 0
	SELECT @strC = SUBSTRING(@strC,1,PATINDEX('%/%', @strC)-1)
DECLARE @lunghezzaCC int
-- Nel caso di modalità di pag. 02 e 03 la lunghezza del CC deve esssere 12
IF @codmod IN ('02','03')
BEGIN
	SET @lunghezzaCC = @lenCCmod0203
END
-- Nel caso di modalità di pag. 09 la lunghezza del CC deve essere 8
IF @codmod = '09'
BEGIN
	SET @lunghezzaCC = @lenCC
	-- Se il C/C ha lunghezza 12 ed inizia con 4 zeri allora tronchiamo i 4 zeri
	IF (LEN(@strC) = 12 AND SUBSTRING(@strC,1,4) = '0000')
	BEGIN
		SET @strC = SUBSTRING(@strC,5,LEN(@strC))
	END
END

IF (LEN(@strC) > @lunghezzaCC) AND (@codmod IN ('02','03','09'))
BEGIN
	INSERT INTO #error (message)VALUES( 'Nel mandato ' + CONVERT(varchar(6),@ndoc) + '/' + CONVERT(varchar(4),@ydoc)
	+ ' il movimento n. ' + CONVERT(varchar(6),@nmov) + ' ha il c/c che supera la lunghezza di '
	+ CONVERT(varchar(4),@lunghezzaCC) + ' caratteri')
	IF (SELECT COUNT(*) FROM #error) > 0
	BEGIN
		SELECT * FROM #error
		RETURN
	END
END
SET @strC = SUBSTRING(REPLICATE('0',@lunghezzaCC),1,@lunghezzaCC - LEN(@strC)) + @strC
UPDATE #totale SET cc = @strC WHERE cc = @strCC 

FETCH NEXT FROM CC_Cursor INTO @strCC,@codmod,@ydoc,@ndoc,@nmov
END
DEALLOCATE CC_Cursor 
	
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- I sub movimenti che hanno trattenute associate ed hanno codice 0 (impostato precedentemente) vengono posti a 1 (sempre su disposizioni della banca)
UPDATE #totale SET nsub = 1
WHERE ISNULL(tax, 0) > 0
	AND nsub = 0

-- Si formatta il numero del submovimento
UPDATE #totale
SET nsubformatted = 
CASE 
	WHEN LEN(CONVERT(varchar(7),#totale.nsub))<= @lennumsubmov
	THEN REPLICATE('0', @lennumsubmov - LEN(CONVERT(varchar(7), #totale.nsub))) + CONVERT(varchar(7),#totale.nsub)
	ELSE SUBSTRING(CONVERT(varchar(7),#totale.nsub),1, @lennumsubmov)
END

-- Inserimento di eventuali ritenute e assegnazione del progressivo Sub
-- Si inserisce nella tabella dei dettagli delle trattenute le eventuali trattenute applicate ai submmovimenti
-- Successivamente si assegna un nuovo sub pari al sub del movimento principale più 1
INSERT INTO #tax_pag_detail (ndoc, nsub, tax, clawback, agencycode, kind, ydoc)
SELECT ndoc, MAX(nsub), ISNULL(SUM(#totale.tax), 0), 
ISNULL(SUM(#totale.clawback), 0), @codiceente, @tipodocumento, @y
FROM #totale GROUP BY ndoc

UPDATE #tax_pag_detail SET nsub = nsub + 1

UPDATE #tax_pag_detail
SET ndocformatted = 
CASE
	WHEN LEN(ndoc)<= @lennumdoc THEN 
		REPLICATE('0', @lennumdoc - LEN(CONVERT(varchar(7), ndoc))) + 
		CONVERT(varchar(7),ndoc)
	ELSE SUBSTRING(CONVERT(varchar(7),ndoc), 1, @lennumdoc)
END,
nsubformatted = 
CASE
	WHEN LEN(nsub)<= @lennumsubmov THEN 
		REPLICATE('0', @lennumsubmov - LEN(CONVERT(varchar(7), nsub))) + 
		CONVERT(varchar(7),nsub)
	ELSE SUBSTRING(CONVERT(varchar(7),nsub), 1, @lennumsubmov)
END

-- Sezione della Gestione della Classificazione SIOPE
CREATE TABLE #siope
(
	ndoc int,
	ndocformatted varchar(7),
	sortcode varchar(30),
	idsor varchar(36),
	amount decimal(19,2),
	progressive int,
	formatted_progressive varchar(3),
	rowkind char(1), -- Campo che vale 'P' = Movimento Principale, 'T' = Trattenute
	idinc int,
	idexp int
)
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

-- Caso 1. Movimento di Spesa senza trattenute
INSERT INTO #siope (ndoc, ndocformatted,
idsor, sortcode, amount, rowkind, idexp)
SELECT #pagamento.ndoc, #pagamento.ndocformatted,
expensesorted.idsor,
CASE
	WHEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) <= @lencodeSIOPE
	THEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) +
	SPACE(@lencodeSIOPE - DATALENGTH(SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode))))
	ELSE SUBSTRING(sorting.sortcode,@npos,@lencodeSIOPE)
END,
SUM(expensesorted.amount), 'P', #pagamento.idexp
FROM #pagamento
JOIN expensesorted
	ON #pagamento.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
	AND #pagamento.tax = 0
GROUP BY #pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
	expensesorted.idsor, #pagamento.idexp

-- Caso 2. Movimento di Spesa con trattenute
-- Inserimento di dettagli SIOPE sul mov. principale riferito alle trattenute (calcolo per rapporto)
INSERT INTO #siope (ndoc, ndocformatted,
idsor, sortcode, amount, rowkind, idexp)
SELECT #pagamento.ndoc, #pagamento.ndocformatted,
expensesorted.idsor,
CASE
	WHEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) <= @lencodeSIOPE
	THEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) +
	SPACE(@lencodeSIOPE - DATALENGTH(SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode))))
	ELSE SUBSTRING(sorting.sortcode,@npos,@lencodeSIOPE)
END,
CASE
	#pagamento.amount_submov WHEN 0 THEN 0
	ELSE SUM(expensesorted.amount) * #pagamento.tax / #pagamento.amount_submov
END,
'T', #pagamento.idexp
FROM #pagamento
JOIN expensesorted
	ON #pagamento.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
	AND #pagamento.tax <> 0
GROUP BY #pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
	#pagamento.amount_submov, #pagamento.tax, #pagamento.idexp,
	expensesorted.idsor

-- Inserimento dei dettagli SIOPE del movimento principale (calcolo per differenza)
INSERT INTO #siope (ndoc, ndocformatted,
idsor, sortcode, amount, rowkind, idexp)
SELECT #pagamento.ndoc, #pagamento.ndocformatted,
expensesorted.idsor,
CASE
	WHEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) <= @lencodeSIOPE
	THEN SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)) +
	SPACE(@lencodeSIOPE - DATALENGTH(SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode))))
	ELSE SUBSTRING(sorting.sortcode,@npos,@lencodeSIOPE)
END,
SUM(expensesorted.amount) - 
ISNULL(
	(SELECT SUM(#siope.amount)
	FROM #siope
	WHERE #siope.ndoc = #pagamento.ndoc
		AND #siope.idexp = #pagamento.idexp
		AND #siope.idsor = expensesorted.idsor
		AND #siope.rowkind = 'T')
,0), 'P', #pagamento.idexp
FROM #pagamento
JOIN expensesorted
	ON #pagamento.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
	AND #pagamento.tax <> 0
GROUP BY #pagamento.ndoc, #pagamento.ndocformatted, sorting.sortcode,
#pagamento.amount_submov, expensesorted.idsor, #pagamento.idexp

-- In questa tabella vengono inserite solamente le righe di #siope collegate al movimento di spesa principale
-- e non quelle collegate alle trattenute
CREATE TABLE #mandatoSIOPE
(
	ndoc int, 
	kdoc int,
	nsub int, 
	codeSIOPE varchar(10),
	amountSIOPE decimal(19,2)
)

-- Riempimento della tabella #mandatoSIOPE
INSERT INTO #mandatoSIOPE (ndoc, kdoc, nsub, codeSIOPE, amountSIOPE)
SELECT
	#totale.ndoc, #totale.kdoc, #totale.nsub,
	#siope.sortcode, SUM(#siope.amount)
FROM #siope
JOIN expense
	ON #siope.idexp = expense.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN #totale
	ON expenselast.kpay = #totale.kdoc
	AND expense.idreg = #totale.idreg
WHERE #siope.rowkind = 'P'
GROUP BY #siope.sortcode, #totale.ndoc, #totale.kdoc, #totale.nsub

-- Tabella che conterrà la trasposizione della tabella #mandatoSIOPE
-- ossia le righe di #mandatoSIOPE raggruppate per submovimento diventeranno una riga di #stringaSIOPE
-- Questa operazione viene fatta perché la Banca Popolare di Bari destina per il SIOPE un record formato da una sola riga per submovimento
-- dove vengono scritte tutte le classificazioni associate al submovimento. Altre banche non hanno questa limitazione
CREATE TABLE #stringaSIOPE
(
	ndoc int, 
	ndocformatted varchar(7),
	nsub int, 
	nsubformatted varchar(7),
	stringa varchar(300) -- La banca popolare di Bari accetta fino a 12 classificazioni di cui ogni classificazione occupa 25 posizioni
)

-- Riempimento della tabella #stringaSIOPE
DECLARE @stringa varchar(300)
DECLARE @numdocSIOPE int
DECLARE @numsubmovSIOPE int
DECLARE @codeSIOPE varchar(10)
DECLARE @amountSIOPE decimal(19,2)
DECLARE @numdocSIOPEcurr int
DECLARE @numsubmovSIOPEcurr int
DECLARE @numClassificazioniInseriteInRiga int
DECLARE @lenClassificazione int
DECLARE @counter int
DECLARE @ndocformatted varchar(7)
DECLARE @nsubformatted varchar(7)
DECLARE @ndocformattedCURR varchar(7)
DECLARE @nsubformattedCURR varchar(7)

SET @numdocSIOPEcurr = 0
SET @numsubmovSIOPEcurr = 0

SET @ndocformattedCURR = ''
SET @nsubformattedCURR = ''

SET @stringa = ''
SET @lenClassificazione = @lencodeSIOPE + 15 -- 15 = Lunghezza Max Importo

-- Si definisce il cursore come una join tra #mandatoSIOPE e #totale (serve per i ndoc e nsub formattati)
-- Si procede quindi a concatenare tutte le classificazioni di un submovimento in modo da formare una unica riga
-- il formato della riga sarà codice1 importo1 codice2 importo2...codiceN importoN
DECLARE #siope INSENSITIVE CURSOR FOR
SELECT
	#mandatoSIOPE.ndoc, #totale.ndocformatted,
	#mandatoSIOPE.nsub, #totale.nsubformatted,
	#mandatoSIOPE.codeSIOPE, #mandatoSIOPE.amountSIOPE
FROM #mandatoSIOPE
JOIN #totale
	ON #totale.ndoc = #mandatoSIOPE.ndoc
	AND #totale.nsub = #mandatoSIOPE.nsub
ORDER BY #mandatoSIOPE.ndoc, #mandatoSIOPE.nsub
FOR READ ONLY
OPEN #siope

FETCH NEXT FROM #siope INTO @numdocSIOPE, @ndocformatted, @numsubmovSIOPE, @nsubformatted, @codeSIOPE, @amountSIOPE
SET @numdocSIOPEcurr = @numdocSIOPE
SET @numsubmovSIOPEcurr = @numsubmovSIOPE

SET @ndocformattedCURR = @ndocformatted
SET @nsubformattedCURR = @nsubformatted

WHILE (@@FETCH_STATUS = 0)
BEGIN
	DECLARE @str_amountSIOPE varchar(15)
	SET @str_amountSIOPE = 
		CASE 
			WHEN LEN(@amountSIOPE)< 15 THEN 
				SUBSTRING('0000000000000000', 1, 15 - LEN(@amountSIOPE) + 1)+ 
				SUBSTRING (CONVERT (varchar(15),@amountSIOPE),1,LEN(@amountSIOPE)-3)
			ELSE
				SUBSTRING (CONVERT (varchar(15),@amountSIOPE),1,LEN(@amountSIOPE)-3)
		END	+ 
		SUBSTRING (CONVERT (varchar(15),@amountSIOPE),LEN(@amountSIOPE)-1,
		LEN(@amountSIOPE))

	DECLARE @codSIOPEdainserire varchar(10)
	SET @codSIOPEdainserire = @codeSIOPE + SUBSTRING(SPACE(@lencodeSIOPE),1,@lencodeSIOPE - LEN(@codeSIOPE))

	IF (@numdocSIOPEcurr <> @numdocSIOPE) OR (@numsubmovSIOPEcurr <> @numsubmovSIOPE)
	BEGIN
		SET @stringa = @codSIOPEdainserire + @str_amountSIOPE
	END
	ELSE
	BEGIN
		SET @stringa = @stringa + @codSIOPEdainserire + @str_amountSIOPE
	END

	SET @numdocSIOPEcurr = @numdocSIOPE
	SET @numsubmovSIOPEcurr = @numsubmovSIOPE

	SET @ndocformattedCURR = @ndocformatted
	SET @nsubformattedCURR = @nsubformatted	

	FETCH NEXT FROM #siope INTO @numdocSIOPE, @ndocformatted, @numsubmovSIOPE, @nsubformatted, @codeSIOPE, @amountSIOPE

	IF (@numdocSIOPEcurr <> @numdocSIOPE) OR (@numsubmovSIOPEcurr <> @numsubmovSIOPE)
	BEGIN
		SET @numClassificazioniInseriteInRiga = LEN(@stringa) / @lenClassificazione
		SET @counter = @numClassificazioniInseriteInRiga
		WHILE (@counter < @limite)
		BEGIN
			SET @stringa = @stringa + SPACE(@lencodeSIOPE) + REPLICATE('0',15)
			SET @counter = @counter + 1
		END
		INSERT INTO #stringaSIOPE (ndoc, ndocformatted, nsub, nsubformatted, stringa)
		VALUES(@numdocSIOPEcurr, @ndocformattedCURR, @numsubmovSIOPEcurr, @nsubformattedCURR, @stringa)
	END
END
SET @numClassificazioniInseriteInRiga = LEN(@stringa) / @lenClassificazione
SET @counter = @numClassificazioniInseriteInRiga
WHILE (@counter < @limite)
BEGIN
	SET @stringa = @stringa + SPACE(@lencodeSIOPE) + REPLICATE('0',15)
	SET @counter = @counter + 1
END
INSERT INTO #stringaSIOPE (ndoc, ndocformatted, nsub, nsubformatted, stringa)
VALUES(@numdocSIOPEcurr, @ndocformattedCURR, @numsubmovSIOPEcurr, @nsubformattedCURR, @stringa)

CLOSE #siope
DEALLOCATE #siope
	
-- La stessa operazione fatta in precedenza sulle classificazioni associate al movimento di spesa principale
-- viene eseguita per le trattenute, si definisce quindi una nuova tabellea #reversaleSIOPE che verrà poi trasformata
-- in #stringaSIOPE_rit
CREATE TABLE #reversaleSIOPE
(
	ndoc int, 
	kdoc int,
	nsub int, 
	codeSIOPE varchar(10),
	amountSIOPE decimal(19,2)
)

INSERT INTO #reversaleSIOPE (ndoc, kdoc, nsub, codeSIOPE, amountSIOPE)
SELECT
	#totale.ndoc, #totale.kdoc, #totale.nsub,
	#siope.sortcode, SUM(#siope.amount)
FROM #siope
JOIN expense
	ON #siope.idexp = expense.idexp
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN #totale
	ON expenselast.kpay = #totale.kdoc
	AND expense.idreg = #totale.idreg
WHERE #siope.rowkind = 'T'
GROUP BY #siope.sortcode, #totale.ndoc, #totale.kdoc, #totale.nsub

UPDATE #reversaleSIOPE SET nsub = nsub + 1

CREATE TABLE #stringaSIOPE_rit
(
	ndoc int, 
	ndocformatted varchar(7),
	nsub int, 
	nsubformatted varchar(7),
	stringa varchar(300) -- La banca popolare di Bari accetta fino a 12 classificazioni di cui ogni classificazione occupa 25 posizioni
)

SET @ndocformatted = NULL
SET @numsubmovSIOPE = NULL
SET @nsubformatted = NULL
SET @codeSIOPE = NULL
SET @amountSIOPE = NULL
SET @str_amountSIOPE = NULL
SET @codSIOPEdainserire = NULL

SET @numdocSIOPEcurr = 0
SET @numsubmovSIOPEcurr = 0

SET @ndocformattedCURR = ''
SET @nsubformattedCURR = ''

SET @stringa = ''

DECLARE #siope INSENSITIVE CURSOR FOR
SELECT
	#reversaleSIOPE.ndoc, #tax_pag_detail.ndocformatted,
	#reversaleSIOPE.nsub, #tax_pag_detail.nsubformatted,
	#reversaleSIOPE.codeSIOPE, #reversaleSIOPE.amountSIOPE
FROM #reversaleSIOPE
JOIN #tax_pag_detail
	ON #tax_pag_detail.ndoc = #reversaleSIOPE.ndoc
	AND #tax_pag_detail.nsub = #reversaleSIOPE.nsub
ORDER BY #reversaleSIOPE.ndoc, #reversaleSIOPE.nsub
FOR READ ONLY
OPEN #siope

FETCH NEXT FROM #siope INTO @numdocSIOPE, @ndocformatted, @numsubmovSIOPE, @nsubformatted, @codeSIOPE, @amountSIOPE
SET @numdocSIOPEcurr = @numdocSIOPE
SET @numsubmovSIOPEcurr = @numsubmovSIOPE

SET @ndocformattedCURR = @ndocformatted
SET @nsubformattedCURR = @nsubformatted

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @str_amountSIOPE = 
		CASE 
			WHEN LEN(@amountSIOPE)< 15 THEN 
				SUBSTRING('0000000000000000', 1, 15 - LEN(@amountSIOPE) + 1)+ 
				SUBSTRING (CONVERT (varchar(15),@amountSIOPE),1,LEN(@amountSIOPE)-3)
			ELSE
				SUBSTRING (CONVERT (varchar(15),@amountSIOPE),1,LEN(@amountSIOPE)-3)
		END	+ 
		SUBSTRING (CONVERT (varchar(15),@amountSIOPE),LEN(@amountSIOPE)-1,
		LEN(@amountSIOPE))

	SET @codSIOPEdainserire = @codeSIOPE + SUBSTRING(SPACE(@lencodeSIOPE),1,@lencodeSIOPE - LEN(@codeSIOPE))

	IF (@numdocSIOPEcurr <> @numdocSIOPE) OR (@numsubmovSIOPEcurr <> @numsubmovSIOPE)
	BEGIN
		SET @stringa = @codSIOPEdainserire + @str_amountSIOPE
	END
	ELSE
	BEGIN
		SET @stringa = @stringa + @codSIOPEdainserire + @str_amountSIOPE
	END
	SET @numdocSIOPEcurr = @numdocSIOPE
	SET @numsubmovSIOPEcurr = @numsubmovSIOPE

	SET @ndocformattedCURR = @ndocformatted
	SET @nsubformattedCURR = @nsubformatted

	FETCH NEXT FROM #siope INTO @numdocSIOPE, @ndocformatted, @numsubmovSIOPE, @nsubformatted, @codeSIOPE, @amountSIOPE

	IF (@numdocSIOPEcurr <> @numdocSIOPE) OR (@numsubmovSIOPEcurr <> @numsubmovSIOPE)
	BEGIN
		SET @numClassificazioniInseriteInRiga = LEN(@stringa) / @lenClassificazione
		SET @counter = @numClassificazioniInseriteInRiga
		WHILE (@counter < @limite)
		BEGIN
			SET @stringa = @stringa + SPACE(@lencodeSIOPE) + REPLICATE('0',15)
			SET @counter = @counter + 1
		END
		INSERT INTO #stringaSIOPE_rit (ndoc, ndocformatted, nsub, nsubformatted, stringa)
		VALUES(@numdocSIOPEcurr, @ndocformattedCURR, @numsubmovSIOPEcurr, @nsubformattedCURR, @stringa)
	END
END
SET @numClassificazioniInseriteInRiga = LEN(@stringa) / @lenClassificazione
SET @counter = @numClassificazioniInseriteInRiga
WHILE (@counter < @limite)
BEGIN
	SET @stringa = @stringa + SPACE(@lencodeSIOPE) + REPLICATE('0',15)
	SET @counter = @counter + 1
END
INSERT INTO #stringaSIOPE_rit (ndoc, ndocformatted, nsub, nsubformatted, stringa)
VALUES(@numdocSIOPEcurr, @ndocformattedCURR, @numsubmovSIOPEcurr, @nsubformattedCURR, @stringa)

CLOSE #siope
DEALLOCATE #siope

---- Inizio scrittura della tabella di OUPUT finale
-- RECORD '01'
INSERT INTO #temp
SELECT
	-- Codice Istituto
	@dipendenza +
	-- Codice Filiale
	@codicefiliale +
	-- Codice Ente
	@codiceente +
	-- Esercizio di Riferimento
	CONVERT(varchar(4),@y) +
	-- Tipo Documento
	@tipodoc +
	-- Numero Mandato
	-- Prendo il numero del documento da rptexppagamenti invece che da rptexppagmentiT
	#totale.ndocformatted + 
	-- Progressivo Sub Movimento
	#totale.nsubformatted +
	-- Tipo Record
	'01' +
	-- da Capitolo a Codice Meccanografico di Bilancio (4 campi)
	REPLICATE('0',25) +
	-- Causale conto dell'ente
	@causaleente +
	-- Filiale del conto corrente ente
	'000' + 
	-- Conto Corrente
	@cc_number +
	-- CIN
	@cino +
	-- contabilita ordinaria
	'O' +	
	-- infrutttifero
	'F' +
	-- Accredito
	'+' +
	-- Importo NETTO totale del Mandato (o Sub)
	CASE 
		WHEN LEN(#totale.netamount)< 15 THEN 
			SUBSTRING('0000000000000000', 1, 15 - LEN(#totale.netamount) + 1)+ 
			SUBSTRING (CONVERT (varchar(15),#totale.netamount),1,LEN(#totale.netamount)-3)
		ELSE
			SUBSTRING (CONVERT (varchar(15),#totale.netamount),1,LEN(#totale.netamount)-3)
	END	+ 
	SUBSTRING (CONVERT (varchar(15),#totale.netamount),LEN(#totale.netamount)-1,
	LEN(#totale.netamount)) +
	-- Tipo pagamento 
	CASE 
		WHEN (#totale.idpaymethodTRS IS NULL) THEN '01'
		ELSE SUBSTRING('00', 1, 2 - LEN(#totale.idpaymethodTRS)) + #totale.idpaymethodTRS 
	END +
	-- Codice bolli
	-- 1: Non esente da bollo; 2: Esente da bollo
	CASE
		WHEN ISNULL(idstamphandling,'') IN ('S', ' ') THEN 'S'
		ELSE 'N'
	END +
	-- Bollo a Carico
	SPACE(1) +
	-- Si presuppone che le commissioni siano sempre a ZERO
	REPLICATE('0',7) +
	-- Importo Commissioni
	CASE
		WHEN #totale.idpaymethodTRS IN ('09','03') THEN 'C'
		ELSE SPACE(1)
	END +
	-- da Data Valuta Incasso a Importo Ritenute (4 campi)
	REPLICATE('0', 34) +
	-- Data Valuta Pagamento
	CONVERT (varchar(4), DATEPART(YEAR, adate)) +
	SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(MONTH,adate)))) +
	CONVERT(varchar(2),DATEPART(MONTH,adate)) +
	SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(DAY,adate)))) +
	CONVERT(varchar(2),DATEPART(DAY,adate)) +
	-- da Data Prenotazione a Spese Postali (6 campi)
	REPLICATE('0',38) +
	-- da Indicativo di Spese PT a Carico a Filler 4 campi)
	SPACE(166)
FROM #totale
WHERE #totale.amount_payment > 0

-- RECORD '05'
INSERT INTO #temp
SELECT
	---- Codice Istituto
	@dipendenza +
	---- Codice Filiale
	@codicefiliale +
	---- Codice Ente
	@codiceente +
	---- Esercizio di Riferimento
	CONVERT(varchar(4),@y) +
	---- Tipo Documento
	@tipodoc +
	-- Numero Mandato
	#totale.ndocformatted +
	-- Progressivo Sub Movimento
	#totale.nsubformatted +
	-- Tipo Record
	'05' +
	-- Causale del pagamento
	CASE 
		WHEN LEN(#totale.description) <= @lendescrizione THEN
			RTRIM(#totale.description) + SUBSTRING(REPLICATE(' ',@lendescrizione),1,@lendescrizione - LEN(RTRIM(#totale.description)))
		ELSE SUBSTRING(#totale.description,1, @lendescrizione)
	END +
	-- Ragione sociale
	#totale.registry +
	CASE
		WHEN #totale.birthdate IS NULL THEN REPLICATE('0',8)
		ELSE
			CONVERT (varchar(4), DATEPART(YEAR, birthdate)) +
			SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(MONTH,birthdate)))) +
			CONVERT(varchar(2),DATEPART(MONTH,birthdate)) +
			SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(DAY,birthdate)))) +
			CONVERT(varchar(2),DATEPART(DAY,birthdate))
	END + 
	SPACE(2) +
	-- 16 C.F. / partita IVA
	CASE 
		WHEN #totale.cf IS NOT NULL AND DATALENGTH(#totale.cf) <= @lencf
			THEN SPACE(@lencf - DATALENGTH(#totale.cf)) + #totale.cf
		WHEN #totale.cf IS NOT NULL AND DATALENGTH(#totale.cf) > @lencf
			THEN SUBSTRING(#totale.cf, 1, @lencf)
		ELSE
		CASE
			WHEN #totale.p_iva IS NOT NULL AND DATALENGTH(#totale.p_iva) <= @lencf
				THEN SPACE(@lencf - DATALENGTH(#totale.p_iva)) + #totale.p_iva
			WHEN #totale.p_iva IS NOT NULL AND DATALENGTH(#totale.p_iva) > @lencf
				THEN SUBSTRING(#totale.p_iva,1, @lencf)
			ELSE SPACE(16)
		END
	END +
	'N' +
	SPACE(179)
FROM #totale
WHERE #totale.amount_payment > 0

-- RECORD '10'
INSERT INTO #temp
SELECT
	---- Codice Istituto
	@dipendenza +
	---- Codice Filiale
	@codicefiliale +
	---- Codice Ente
	@codiceente +
	-- Esercizio di Riferimento
	CONVERT(varchar(4),@y) +
	-- Tipo Documento
	@tipodoc +
	-- Numero Mandato
	#totale.ndocformatted +
	-- Progressivo Sub
	#totale.nsubformatted +
	-- Tipo Record
	'10' +
	-- da Note operazioni di tesoreria a Codici Generici per Ente (2 campi)
	SPACE(80) +
	-- Indirizzo versante
	-- "Diversi" o "Diversi su c/c postale" o "Beneficiari diversi"
	#totale.address + 
	-- Localita percipiente
	#totale.location +
	-- CAP
	#totale.cap + 
	-- Provincia
	#totale.province + 
	-- Filler
	SPACE(174)
FROM  #totale
WHERE #totale.amount_payment >0

-- RECORD '15'
INSERT INTO #temp
SELECT
	-- Codice Istituto
	@dipendenza +
	-- Codice Filiale
	@codicefiliale +
	-- Codice Ente
	@codiceente +
	-- Esercizio di Riferimento
	CONVERT(varchar(4),@y) +
	-- Tipo Documento
	@tipodoc +
	-- Numero Mandato
	#totale.ndocformatted +
	-- Progressivo Sub
	#totale.nsubformatted + 
	-- Tipo Record
	'15' +
	CASE
		WHEN #totale.idpaymethodTRS = '03' THEN
			-- Codice ABI
			#totale.abi +
			-- Codice CAB
			#totale.cab +
			-- Conto Corrente
			#totale.cc +
			-- Cin
			'0' +
			-- Presenza allegati
			' ' +
			-- da Valuta Beneficiario a Valuta Banca Corrispondente
			REPLICATE ('0',16) +
			-- Ind. contro-ritiro quietanza
			SPACE(1) +
			-- IBAN
			#totale.iban +
			-- Filler
			SPACE(241)
		WHEN #totale.idpaymethodTRS = '04' THEN
			-- Codice ABI
			#totale.abi +
			-- Valuta beneficiario
			REPLICATE ('0', 8) +
			-- Indirizzo + località + CAP + provincia percipiente
			#totale.address + #totale.location + #totale.cap + #totale.province +
			-- Indirizzo contro ritiro quietanza
			SPACE (242)
		WHEN #totale.idpaymethodTRS IN ('05','08') THEN
			'S' + SPACE(1) +
			-- Indirizzo + località + CAP + provincia percipiente
			#totale.address + #totale.location + #totale.cap + #totale.province +
			SPACE(252)
		WHEN #totale.idpaymethodTRS = '07' THEN
			-- Indirizzo + località + CAP + provincia percipiente
			#totale.address + #totale.location + #totale.cap + #totale.province +
			SPACE(255)
		WHEN #totale.idpaymethodTRS = '09' THEN
			-- Codice Filiale
			@codicefiliale +
			-- Conto Corrente
			CASE
				WHEN DATALENGTH(#totale.cc) <= @lenCC THEN
					SUBSTRING(SPACE(@lenCC),1,@lenCC - DATALENGTH(#totale.cc)) + #totale.cc
				ELSE SUBSTRING(#totale.cc,1,@lenCC)
			END +
			-- Cin
			CASE 
				WHEN DATALENGTH(cin1)<= @lenCIN THEN 
					SUBSTRING('00', 1, @lenCIN - DATALENGTH(cin1))+ cin1
				ELSE CONVERT(varchar(2),ISNULL(cin1,'00'))
			END +
			-- Valuta beneficiario
			REPLICATE ('0', 8)+ SPACE(295)
		WHEN #totale.idpaymethodTRS = '31' THEN
			-- Provincia percipiente
			#totale.province +
			SPACE(7) + 
			'I' +
			SPACE(307)
		WHEN #totale.idpaymethodTRS = '02' THEN
			-- Conto Corrente Postale
			#totale.cc +
			-- Esenzione Spese Postali
			'S' +
			SPACE(303)
	END
FROM #totale
WHERE #totale.amount_payment > 0
	
-- RECORD '02'
IF EXISTS(SELECT * FROM #stringaSIOPE)
BEGIN
	INSERT INTO #temp
	SELECT
	-- Chiave del Mandato
	-- Codice Istituto
	@dipendenza +
	-- Codice Filiale
	@codicefiliale +
	-- Codice Ente
	@codiceente +
	-- Esercizio di Riferimento
	CONVERT(varchar(4),@y) +
	-- Tipo Documento
	@tipodoc +
	-- Numero Mandato
	ndocformatted + 
	-- Progressivo Sub Movimento
	nsubformatted +
	-- Tipo Record
	'02' + 
	stringa +
	SPACE(14) -- Filler
	FROM #stringaSIOPE
END

IF EXISTS(SELECT * FROM #tax_pag_detail)
BEGIN
	-- RECORD '01' X RITENUTE
	INSERT INTO #temp
	SELECT
		-- Codice Istituto
		@dipendenza +
		-- Codice Filiale
		@codicefiliale +
		-- Codice Ente
		@codiceente +
		-- Esercizio di Riferimento
		CONVERT(varchar(4), @y) +
		-- Tipo Documento
		@tipodoc +
		-- Numero Mandato
		#tax_pag_detail.ndocformatted +
		-- Progressivo Sub Movimento
		#tax_pag_detail.nsubformatted + 
		-- Tipo Record
		'01' +
		-- da Capitolo a Codice Meccanografico di bilancio (4 campi)
		REPLICATE('0',25) +
		-- Causale conto dell'ente
		@causaleente +
		-- Filiale del conto corrente ente
		---- Codice Filiale
		@codicefiliale +
		-- Conto Corrente
		@cc_number +
		-- CIN
		@cino +
		-- Contabilità Ordinaria
		'O' +	
		-- Destinazione Ente T.U, (Fruttifero / Infrutttifero)
		'F' +
		-- Accredito
		'+' +
		-- Importo del Mandato (o Sub)
		CASE 
			WHEN LEN(#tax_pag_detail.tax)< 14 THEN 
				SUBSTRING('0000000000000000', 1, 15 -LEN(#tax_pag_detail.tax)+1)+ 
				SUBSTRING (CONVERT (varchar(15),#tax_pag_detail.tax),1,LEN(#tax_pag_detail.tax)-3)
			ELSE
				SUBSTRING (CONVERT (varchar(15),#tax_pag_detail.tax),1,LEN(#tax_pag_detail.tax)-3)
		END + 
		SUBSTRING (CONVERT (varchar(15),#tax_pag_detail.tax),LEN(#tax_pag_detail.tax)-1,
		LEN(#tax_pag_detail.tax)) +
-- Tipo pagamento 
		'01' +
-- Esenzione Bollo 
	 	'S' +
-- da Bollo a Carico a Indicativo di Carico Commissioni (3 campi)
		SPACE(9) +
-- da Data Valuta Incasso a Spese Postali (11 campi)
		REPLICATE('0',80) +
-- da Indicativo di spese pt a carico a Filler (5 campi)
		SPACE(166)
	FROM #tax_pag_detail
	WHERE ISNULL(#tax_pag_detail.tax,0) > 0

	-- RECORD '02' X RITENUTE
	INSERT INTO #temp
	SELECT
		-- Chiave del Mandato
		-- Codice Istituto
		@dipendenza +
		-- Codice Filiale
		@codicefiliale +
		-- Codice Ente
		@codiceente +
		-- Esercizio di Riferimento
		CONVERT(varchar(4),@y) +
		-- Tipo Documento
		@tipodoc +
		-- Numero Mandato
		ndocformatted + 
		-- Progressivo Sub Movimento
		nsubformatted +
		-- Tipo Record
		'02' + 
		stringa +
		SPACE(14) -- Filler
	FROM #stringaSIOPE_rit

	-- RECORD '05' X RITENUTE
	INSERT INTO #temp
	SELECT
		-- Codice Istituto
		@dipendenza +
		-- Codice Filiale
		@codicefiliale +
		-- Codice Ente
		@codiceente +
		-- Esercizio di Riferimento
		CONVERT(varchar(4),@y) +
		-- Tipo Documento
		@tipodoc +
		-- Numero Mandato
		ndocformatted +
		-- Progressivo Sub
		nsubformatted +
		-- Tipo Record
		'05' +
		-- Causale del pagamento
		'PER RITENUTE' +
		SPACE(48) +
		'RITENUTE' +
		-- 7 campi
		SPACE(248)
	FROM #tax_pag_detail
	WHERE ISNULL(#tax_pag_detail.tax,0) > 0
END

-- Pulizia dai caratteri non consentiti
-- Cancella le righe vuote
DELETE FROM #temp WHERE stri IS NULL
-- Aggiorna le rimanenti
UPDATE #temp SET stri = 
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(
stri,
'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'Ù','u'),
'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
']',' '),'`',' '),'{',' '),'}',' '),'~',' '),'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),
'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),
'õ','o'),'ý','y'),'é','e'),'à','a'),'è','e'),'ì','i'),'ò','o'),'ù','u'),'á','a'),'í','i'),'ó','o'),'É','e'),
'Á','a'),'À','a'),'È','e'),'Í','i'),'Ì','i'),'Ó','o'),'Ò','o'),'Ú','u'),
CHAR(9),' '),CHAR(10),' '),CHAR(13),' ')
SELECT SUBSTRING(stri , 1, 350) as out_str FROM #temp
ORDER BY SUBSTRING(stri , 1, 28), SUBSTRING(stri , 1, 37)
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

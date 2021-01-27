
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
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_carime_ins]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_carime_ins]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        PROCEDURE [trasmele_expense_carime_ins]
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

DECLARE @lencodicecontabilitaspeciale int
SET @lencodicecontabilitaspeciale = 7	

DECLARE @lenbic_swift_code INT 
SET @lenbic_swift_code = 11

-- singola tranche del nominativo, i nomi lunghi vengono suddivisi in tranches, 
-- da riportare in un record addizionale relativo al beneficiario
DECLARE @len_tranche int
SET @len_tranche = 30   -- campo zanaben ANAGRAFICA BENEFICIARIO

DECLARE @len_tranche_aggiuntiva int
SET @len_tranche_aggiuntiva = 70   -- campo aggiuntivo ANAGRAFICA BENEFICIARIO E CAUSALE

DECLARE @len_tranche_note int
SET @len_tranche_note = 50   -- campo ZINFO informazioni al tesoriere

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

DECLARE @len_desc_paymethod int
SET @len_desc_paymethod = 30

DECLARE @len_desc_payment int
SET @len_desc_payment = 370

DECLARE @len_sortcode int
SET @len_sortcode = 10 --codice siope

DECLARE @len_deputy int
SET @len_deputy = 100

DECLARE @len_refexternaldoc int
SET @len_refexternaldoc = 50  -- note al tesoriere

DECLARE @len_idstamphandling int
SET @len_idstamphandling = 3

DECLARE @len_zinfent INT
SET @len_zinfent = 250 --informazioni aggiuntive ente

 

DECLARE @idtreasurer int
DECLARE @kpaymenttransmission int


SELECT @idtreasurer = idtreasurer, @kpaymenttransmission = kpaymenttransmission FROM paymenttransmission
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

-- CONTROLLO N. 2. Lunghezza del codice ente
IF (DATALENGTH(@cod_department) < @len_agencycode)
BEGIN
	INSERT INTO #error
	VALUES ('Il codice Ente inserito è inferiore alla lunghezza massima fissata a '
	+ CONVERT(varchar(2),@len_agencycode))
END

-- CONTROLLO N. 3. Movimento di Spesa senza Modalità di Pagamento
INSERT INTO #error (message)
(SELECT 'Per il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' non è stata scelta una modalità di pagamento'
FROM paymentcommunicated
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n
	AND idpaymethod IS NULL)


-- CONTROLLO N. 4. Movimento di Spesa con Modalità di Pagamento non configurata
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

-- CONTROLLO N. 5. Codice IBAN o ABI o CAB devono essere valorizzati nel caso di modalità di pagamento 53 e 63
--- ABI, CAB, CIN, NUMERO CONTO obbligatori in caso di BONIFICI
--- NUMERO CONTO obbligatorio in caso di BOLLETTINO CCP
INSERT INTO #error (message)
(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento scelta non è stato assegnato il codice ABI / CAB.'
FROM paymentcommunicated
	JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode IN ('52','53','60')
	AND (
		(paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
		OR (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
	)
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
	AND NOT EXISTS (SELECT * FROM expenseview WHERE expenseview.idexp =paymentcommunicated.idexp AND  netamount = 0)
)

-- CONTROLLO N. 6. Il codice ABI, CAB e il CIN non devono eccedere la lunghezza massima nel caso di modalità di pagamento 53 e 63
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
	AND paymethod.methodbankcode IN ('52','53','60')
	AND (
	(DATALENGTH(paymentcommunicated.idcab) > @len_CAB)
	OR (DATALENGTH(paymentcommunicated.idbank) > @len_ABI)
	OR (DATALENGTH(paymentcommunicated.cin) > @len_cin)
		)
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
	)
-- CONTROLLO N. 7. Conto Corrente valorizzato e di lunghezza massima 12 caratteri nel caso di modalità di pagamento '52','53','60','12'
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode IN ('52','53','60','09','12') 
AND (paymentcommunicated.cc IS NULL
	OR REPLACE(paymentcommunicated.cc,' ','') = ''
	OR DATALENGTH(ISNULL(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(paymentcommunicated.cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ','')
	,'')) > @len_cc)
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
)
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
	+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov)
	+ ' nella modalità di pagamento non è stato valorizzato il C/C o la lunghezza del C/C eccede i '
	+ CONVERT(varchar(2),@len_cc) + ' caratteri'
	FROM paymentcommunicated
	JOIN paymethod
		ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
	WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode IN ('52','53','60','09','12')
	AND (paymentcommunicated.cc IS NULL
		OR REPLACE(paymentcommunicated.cc,' ','') = ''
		OR DATALENGTH(ISNULL(paymentcommunicated.cc,'')) > @len_cc)
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
	)
END

-- CONTROLLO N. 8. Presenza tipologia dei beneficiari
DECLARE @denomcred_err varchar(200)
INSERT INTO #error (message)
SELECT 'Il beneficiario ' + ISNULL(R.title,'XXX') + ' con codice ' + CONVERT(varchar(6),R.idreg) + ' non ha una tipologia associata. E'' necessario inserirla'
FROM expense E
JOIN expenselast EL
	ON E.idexp = EL.idexp
JOIN payment P
	ON P.kpay = EL.kpay
JOIN registry R
	ON R.idreg = E.idreg
WHERE R.idregistryclass IS NULL
	AND P.kpaymenttransmission = @kpaymenttransmission


-- CONTROLLO N. 9
INSERT INTO #error (message)
SELECT distinct 'Correggere il codice della modalità di pagamento ' + pm.description + '. La lunghezza deve essere 2. '
FROM expenselast el
JOIN payment p
	ON p.kpay = el.kpay
JOIN paymethod pm
	ON el.idpaymethod = pm.idpaymethod
WHERE p.kpaymenttransmission = @kpaymenttransmission 
        AND len(rtrim(pm.methodbankcode))<>2


-- CONTROLLO N. 10. Uso di modlaità di pagamento NON ammesse dalla banca-  vedi Specifiche tracciato
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata una modalità di pagamento non prevista dalla banca.'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode NOT IN ('01','09','12','52','53','55','56','57','60','80','81','83','84','85', '58','90', '91','92')
)


-- CONTROLLO N. 11. Modalità di Pagamento Esclusiva Cassiere
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' la modalità di pagamento scelta è Esclusiva Cassiere. Sostituirla con una più adeguata, al fine di attribuirne un significato più consono nella trasmissione telematica. '
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND (paymethod.description like 'Esclusiva%Cassiere')
)

/*
-- CONTROLLO N. 12. Uso di modalità di pagamento Bonifico verso Istituto Cassiere e ABI differente da CARIME '03067'
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata la modalità di pagamento Bonifico Interno ma il codice ABI non è corretto.'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode  = '52'
	AND ISNULL(paymentcommunicated.idbank,'')  <> '03067'
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
)


-- CONTROLLO N. 12. Uso di modalità di pagamento Bonifico verso Altre Banche e ABI uguale a CARIME '03067'
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata la modalità di pagamento Bonifico Esterno ma il codice ABI non è corretto.'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode  = '53'
	AND ISNULL(paymentcommunicated.idbank,'')  = '03067'
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
)
*/
-- Bollettino postale (cod. pag. 09)i codici ABI e CAB non devono essere valorizzati, lo deve essere solo il numero del C/C-- 
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata la modalità di pagamento Bollettino Postale  ma il codice ABI  e CAB non devono essere valorizzati'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode  IN ('09','12')
	AND 
	(
		paymentcommunicated.idbank  IS NOT NULL OR
		paymentcommunicated.idcab  IS NOT NULL 
	)	 
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
)

-- CONTROLLO N. 14. Presenza trattamento bollo
INSERT INTO #error (message)
SELECT 'Il trattamento bollo deve essere obbligatoriamente impostato per il mandato n° ' + CONVERT(varchar(6),P.npay) 
FROM payment P
WHERE P.idstamphandling IS NULL
	  AND P.kpaymenttransmission = @kpaymenttransmission


-- CONTROLLO N. 14. codice contabilita speciale errato o mancante
IF EXISTS
(SELECT * FROM paymentcommunicated
        join expenselast
        	ON paymentcommunicated.idexp = expenselast.idexp
        join expense
              on expenselast.idexp = expense.idexp 
        join registrypaymethod
                on registrypaymethod.idreg = expense.idreg
                and registrypaymethod.idpaymethod = expenselast.idpaymethod
				and registrypaymethod.idregistrypaymethod = expenselast.idregistrypaymethod
        JOIN paymethod
        	ON expenselast.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
	AND ((paymethod.flag&256)<>0 OR (paymethod.flag&512)<> 0 OR (paymethod.flag&1024)<> 0) -- modalità di pagamento girofondo
	AND (ISNULL(expenselast.extracode,registrypaymethod.extracode)IS NULL
		OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),' ','') = ''
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
        join expenselast
        	ON paymentcommunicated.idexp = expenselast.idexp
        join expense
              on expenselast.idexp = expense.idexp 
        join registrypaymethod
                on registrypaymethod.idreg = expense.idreg
                and registrypaymethod.idpaymethod = expenselast.idpaymethod
				and registrypaymethod.idregistrypaymethod = expenselast.idregistrypaymethod
        JOIN paymethod
        	ON expenselast.idpaymethod = paymethod.idpaymethod
		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
			AND ((paymethod.flag&256)<>0 OR (paymethod.flag&512)<> 0 OR (paymethod.flag&1024)<> 0) -- modalità di pagamento girofondo
			AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
				OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),' ','') = ''
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

DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

-- Tabella dei pagamenti
CREATE TABLE #payment
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idexp int,
	ymov int, 
	nmov int, 
	nphase tinyint, 
	phase varchar(50),
	curramount decimal(19,2),
	flagcr char(1),
	idreg int,
	expense_adate datetime,
	payment_adate datetime,
	transmissiondate datetime,
	idpay int,
	idpaydisposition int,
	idpaymethodTRS varchar(10),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25), -- Viene impostato a 25 in quanto gli utenti possono adoperare un C/C che eccede tale lunghezza
	cin char(1),
	iban varchar(50),
	title_ben varchar(100),
	address_ben varchar(30),
	cap_ben varchar(5),
	location_ben varchar(28),
	province_ben varchar(2),
	pi_ben varchar(11),
	cf_ben varchar(16),
	stamp_charge varchar(3),
	girofondo char(1),
	girofondo_infruttifero_libero char(1),
	girofondo_infruttifero_vincolato char(1),
	girofondo_infruttifero_libero_tab_b char(1),
	extracode varchar(7),
	biccode varchar(20),
	flag_sepa char(1),
	registry_tosplit char(1),
	paymentdescr_tosplit char(1),
	paymentdescr varchar(370),
	txt text, 
	doc varchar(35),
	newpaymentdescr varchar(500),
	expenselast_paymentdescr varchar(150),
	fulfilled char(1),
	uncharged char(1),
	iddeputy int,
	refexternaldoc char(50), -- S/N
	nbill int,
	doc_docdate varchar(50),
	cu varchar(20),
	CUP varchar(15),
	codeupb varchar(50), upbtitle varchar(150),
	codefin	varchar(50), fintitle varchar(150), 
	nlevel tinyint, finlevel varchar(50),
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15),
	cupcodeexpense varchar(15),
	CIG varchar(10),
	cigcodeexpense varchar(10),
	cigcodemandate varchar(10)
)

-- Tabella per il delegato
CREATE TABLE #deputy
(
	iddeputy int,
	title_deputy varchar(140),
	address_deputy varchar(30),
	cap_deputy varchar(5),
	location_deputy varchar(30),
	province_deputy varchar(2),
	nation_deputy varchar(2), -- sigla ISO IT/FR/....
	cf_deputy varchar(16)
)

-- Tabella delle trattenute
CREATE TABLE #tax
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpay int,
	idexp int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	yproceedstransmission int,
	curramount decimal(19,2),
	idpro int,
	idreg int,
	autokind varchar(5)
)

-- Tabella incassi da regolarizzare al netto delle spese accessorie
-- inserisco qui gli incassi a regolarizzazione collegati alle spese da trasmettere, di importo superiore alla spesa stessa
-- da suddividere in due tranches, la prima a regolarizzazione di importo pari al netto e scollegata dalla spesa
-- e la seconda tranche (collegata alla spesa da trasmettere, di importo pari al residuo)

CREATE TABLE #pendingincome
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpay int,
	idexp int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	yproceedstransmission int,
	curramount decimal(19,2),
	curramount_expense decimal(19,2),
	idpro int,
	idreg int,
	autokind varchar(5)
)


-- Tabella delle trattenute a carico dell'ente
-- se la configurazione dei contributi prevede un automatismo di spesa e uno di entrata su partita di giro
-- per gli automatismi dei contributi trasmetto anche la reversale del corrispondente automatismo di entrata
CREATE TABLE #admintax
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpay int,
	idexp int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	yproceedstransmission int,
	curramount decimal(19,2),
	idpro int,
	idreg int,
	autokind varchar(5)
)

-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpay int,
	progressive int,
	sortcode varchar(30),
	sorting varchar(200),
	amount decimal(19,2),
	idexp int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15), 
	cupcodeexpense varchar(15)
)


-- Tabella delle informazioni aggiuntive richieste dall'Ente
CREATE TABLE #note
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	ndocformatted varchar(7),
	idpay int,
	progressive int,
	testo varchar(250)
)


-- Inserimento dei movimenti di spesa presenti nella distinta di trasmissione
INSERT INTO #payment
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, 
	idexp, ymov, nmov, nphase, phase,flagcr, curramount,  --6
    idreg, expense_adate, payment_adate, transmissiondate, stamp_charge,registry_tosplit, --6
    idpaymethodTRS, ABI, CAB, cc, cin, iban, -- 6
    title_ben, cf_ben, pi_ben , paymentdescr,  doc_docdate, expenselast_paymentdescr, fulfilled, uncharged, --6
	girofondo, girofondo_infruttifero_libero, girofondo_infruttifero_vincolato, girofondo_infruttifero_libero_tab_b,
	extracode, biccode,flag_sepa,
	iddeputy, refexternaldoc, nbill, idpay, --6
    idpaydisposition, codeupb, upbtitle,
	codefin, fintitle, nlevel,finlevel,
    cupcodefin,cupcodeupb,cupcodeexpense, cigcodeexpense, txt, doc --5
)
SELECT
	t.ypaymenttransmission, t.npaymenttransmission, d.ypay, d.npay, s.idexp,  
	s.ymov, s.nmov, s.nphase, eph.description, 
	CASE
		WHEN ((i.flag&1)=0) THEN 'C'
		WHEN ((i.flag&1)=1) THEN 'R'
	END, 
	i.curramount, --6
	s.idreg, s.adate, d.adate, t.transmissiondate, 
	CASE 
		WHEN DATALENGTH(ISNULL(tb.handlingbankcode,'')) <= @len_idstamphandling
		THEN ISNULL(tb.handlingbankcode,'') + SPACE(@len_idstamphandling - DATALENGTH(ISNULL(tb.handlingbankcode,'')))
		ELSE SUBSTRING(tb.handlingbankcode,1,@len_idstamphandling)
	END,
	CASE 
		WHEN LEN (ISNULL(c.title,'')) >@len_tranche THEN 'S'
		ELSE 'N'
	END , --6
	ltrim(rtrim(m.methodbankcode)),
	CASE
		WHEN DATALENGTH(ISNULL(el.idbank,'')) <= @len_ABI
		THEN SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(el.idbank,''))) + ISNULL(el.idbank,'')
		ELSE SUBSTRING(el.idbank,1,@len_ABI)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(el.idcab,'')) <= @len_CAB
		THEN SUBSTRING(REPLICATE('0',@len_CAB),1,@len_CAB - DATALENGTH(ISNULL(el.idcab,''))) + ISNULL(el.idcab,'')
		ELSE SUBSTRING(el.idcab,1,@len_CAB)
	END,
	ISNULL(el.cc,''),
	CASE
		WHEN DATALENGTH(ISNULL(el.cin,'')) <= @len_cin
		THEN ISNULL(el.cin,'') + SPACE(@len_cin - DATALENGTH(ISNULL(el.cin,'')))
		ELSE SUBSTRING(el.cin,1,@len_cin)
	END,
	ISNULL(el.iban,''),--6
	ISNULL(c.title,''), 
	CASE
		WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL
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
	-- paymentdescr:
	ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'') +
		SUBSTRING(SPACE(@len_desc_payment),1,@len_desc_payment -
		DATALENGTH(ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,''))),
	ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') ,
	el.paymentdescr,
	CASE
		WHEN (( el.flag & 1)<>0) then 'S'
		ELSE 'N'
	END , --6
	CASE
		WHEN (( el.flag & 8)<>0) then 'S'
		ELSE 'N'
	END , 
	CASE
		WHEN (( m.flag & 64) <> 0) then 'S'
		ELSE 'N'
	END , -- girofondo (F24EP)
	CASE
		WHEN (( m.flag & 256) <> 0) then 'S'
		ELSE 'N'
	END, -- girofondo_infruttifero_libero (trasferimento tra enti)
	CASE
		WHEN (( m.flag & 512) <> 0) then 'S'
		ELSE 'N'
	END, --girofondo_infruttifero_vincolato (trasferimento tra enti)
	CASE
		WHEN (( m.flag & 1024) <> 0) then 'S'
		ELSE 'N'
	END, --girofondo_infruttifero_libero_tab_b
	CASE
		WHEN DATALENGTH(ISNULL(ISNULL(el.extracode,mcd.extracode),'')) <= @lencodicecontabilitaspeciale
		THEN SUBSTRING(REPLICATE('0',@lencodicecontabilitaspeciale),1,@lencodicecontabilitaspeciale - DATALENGTH(ISNULL(ISNULL(el.extracode,mcd.extracode),''))) + ISNULL(ISNULL(el.extracode,mcd.extracode),'')
		ELSE SUBSTRING(ISNULL(el.extracode,mcd.extracode),1,@lencodicecontabilitaspeciale)
	END,
	CASE
        WHEN DATALENGTH(ISNULL(ISNULL(el.biccode,mcd.biccode),'')) <= @lenbic_swift_code
        THEN ISNULL(ISNULL(el.biccode,mcd.biccode),'') + SPACE(@lenbic_swift_code - DATALENGTH(ISNULL(ISNULL(el.biccode,mcd.biccode),'')))
        ELSE SUBSTRING(ISNULL(el.biccode,mcd.biccode),1,@lenbic_swift_code)
    END,
	CASE ---- flag_sepa
        WHEN (( el.paymethod_flag & 8192)<>0) then 'S'
        ELSE 'N'
    END,
    CASE
		WHEN m.allowdeputy = 'S' THEN el.iddeputy 
		ELSE NULL
	END,
	ISNULL(el.refexternaldoc,''),
	ISNULL(REPLICATE('0', 7-DATALENGTH(CONVERT(varchar(7),el.nbill))) + CONVERT(varchar(7),el.nbill),REPLICATE('0',7)),
	el.idpay, --6 
	p.idpaydisposition,
	upb.codeupb, upb.title,
	fin.codefin, fin.title, 
	fin.nlevel,finlevel.description,
	finlast.cupcode,
	u.cupcode,
	RegPhase.cupcode,
	RegPhase.cigcode, --5
	s.txt,
	s.doc 
FROM expense s
JOIN expenselast el
	ON S.idexp = el.idexp
JOIN expensetotal i
	ON i.idexp = s.idexp
JOIN expenseyear y
	ON y.idexp = s.idexp
JOIN expensephase eph
	ON eph.nphase = s.nphase
JOIN upb 
	ON upb.idupb = y.idupb
JOIN fin
	ON fin.idfin = y.idfin
JOIN finlevel 
	ON fin.nlevel = finlevel.nlevel
	AND finlevel.ayear = y.ayear
JOIN payment d
	ON d.kpay = el.kpay
JOIN paymenttransmission t
	ON t.kpaymenttransmission = d.kpaymenttransmission
JOIN paymethod m
	ON el.idpaymethod = m.idpaymethod
JOIN expenselink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
	ON RegPhaseELK.idchild = el.idexp
	AND RegPhaseELK.nlevel = @expenseregphase
JOIN expense RegPhase	-- fase del Creditore
	ON RegPhase.idexp = RegPhaseELK.idparent 
LEFT OUTER JOIN registrypaymethod mcd
	ON mcd.idregistrypaymethod = el.idregistrypaymethod
	AND mcd.idreg = s.idreg
LEFT OUTER JOIN paydisposition p
	ON p.kpay = d.kpay
JOIN registry c
	ON c.idreg = s.idreg
JOIN registryclass ctc 
	ON ctc.idregistryclass = c.idregistryclass
LEFT OUTER JOIN bank
	ON bank.idbank = el.idbank
LEFT OUTER JOIN stamphandling tb
	ON d.idstamphandling = tb.idstamphandling
LEFT OUTER JOIN fin f
	ON d.idfin = f.idfin
JOIN upb u
	ON u.idupb = y.idupb
JOIN fin f1
	ON f1.idfin = y.idfin
JOIN finlast 
	ON finlast.idfin = f1.idfin
WHERE t.ypaymenttransmission = @y
	AND t.npaymenttransmission = @n


declare @fasecontrattopassivo int
select @fasecontrattopassivo = expensephase from config where ayear=@y


-- Valorizza codice cup da eventuali -----
-- contabilizzazioni di dettagli ordine --
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX(cupcode )
		  FROM mandatedetail
		 WHERE (idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo) 
			OR idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo))
		   AND cupcode IS NOT NULL)
where cupcodeexpense is null

-- Valorizza il codice CGI eventualmente presente del contratto passivo
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX(mandate.cigcode)
			FROM mandate
			JOIN mandatedetail
				ON	mandate.idmankind = mandatedetail.idmankind 
				AND mandate.yman = mandatedetail.yman 
				AND mandate.nman = mandatedetail.nman
		 WHERE (mandatedetail.idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo) 
			OR mandatedetail.idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo))
		 )
where cigcodeexpense is null
		 
-- Valorizza il codice CIG eventualmente presente nella fattura
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX( invoicedetail.cigcode )
			FROM invoicedetail 
		WHERE (invoicedetail.idexp_taxable = #payment.idexp
				OR invoicedetail.idexp_iva = #payment.idexp)

		)
where cigcodeexpense is null and cigcodemandate is null		 


UPDATE #payment SET CIG = ISNULL(cigcodeexpense,ISNULL(cigcodemandate,''))  --Codice CIG
UPDATE #payment SET CUP = ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, ISNULL(cupcodefin,'')))) --Codice CUP

UPDATE #payment SET newpaymentdescr = (SELECT
CASE
	-- CUP CIG  e DESCRIZIONE
			WHEN ((		DATALENGTH(isnull(CUP,'')) >0
					AND DATALENGTH(isnull(CIG,'')) >0) )
			THEN 'CUP:' + isnull(CUP,'') +';CIG:'+isnull(CIG,'') + '; '+ ISNULL(paymentdescr, '') 
	-- CIG  e DESCRIZIONE
			WHEN ( (	DATALENGTH(isnull(CIG,'')) >0) )
			THEN 'CIG:'+isnull(CIG,'') + '; '+ISNULL(paymentdescr, '') 
	-- CUP  e DESCRIZIONE
			WHEN ( (DATALENGTH(isnull(CUP,'')) >0 )) 
			THEN 'CUP:'+isnull(CUP,'') + '; '+ISNULL(paymentdescr, '') 
	-- DESCRIZIONE
			ELSE ISNULL(paymentdescr, '') 
	END 
	)
	FROM #payment

UPDATE #payment SET  paymentdescr_tosplit = 'S' WHERE LEN (ISNULL(newpaymentdescr,'')) >3*@len_tranche
UPDATE #payment SET  paymentdescr_tosplit = 'N' WHERE LEN (ISNULL(newpaymentdescr,'')) <=3*@len_tranche


UPDATE #payment SET  idpaymethodTRS = '85' WHERE idpaydisposition IS NOT NULL
UPDATE #payment SET  idpaymethodTRS = '01' WHERE  fulfilled = 'S'
UPDATE #payment SET  idpaymethodTRS = '52' WHERE  idpaymethodTRS = '53' AND ISNULL(ABI,'') = '03067' 
UPDATE #payment SET  idpaymethodTRS = '53' WHERE  idpaymethodTRS = '52' AND isnull(ABI,'') <> '03067' 
UPDATE #payment SET  idpaymethodTRS = '01' WHERE  idpaymethodTRS IN ('09','12')


----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

-- Inizio Formattazione del C/C	
-- Unicredit ammette come C/C numeri e caratteri maiuscoli, il C/C deve essere allineato a destra, carattere di padding lo 0
UPDATE #payment
SET cc = 
	UPPER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ',''))

UPDATE #payment SET cc = REPLICATE('0',@len_cc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
-- Fine Formattazione del C/C

-- Calcolo del campo ndocformatted
UPDATE #payment
SET ndocformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),ndoc))) + CONVERT(varchar(7),ndoc)

DECLARE @maxincomephase char(1)
SELECT @maxincomephase = MAX(nphase) FROM incomephase


-- CONTROLLO N. 13 Controllo che i movimenti di entrata associati ai movimenti di spesa che stiamo trasmettendo siano stati inseriti
-- in una distinta di trasmissione
INSERT INTO #error (message)
SELECT 'Il movimento di entrata ' + CONVERT(varchar(6),I.nmov) + '/' + CONVERT(varchar(4),I.ymov)
+ ' associato al movimento di spesa ' + CONVERT(varchar(6),E.nmov) + '/' + CONVERT(varchar(4),E.nmov)
+ ' non è stato inserito in una distinta di trasmissione'
FROM #payment P
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


-- Inserimento delle trattenute (vengono inseriti recuperi e ritenute, quest'ultime solo dipendenti)
INSERT INTO #tax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, idreg, autokind,
	ymov_income, nmov_income, idpro
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.ndocformatted, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro
FROM #payment p
JOIN income e
	ON e.idpayment = p.idexp	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN proceedstransmission
	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
AND (p.idpaymethodTRS <> '85' AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 (p.girofondo <> 'S') AND
	 (p.girofondo_infruttifero_libero <> 'S') AND
	 (p.girofondo_infruttifero_vincolato <> 'S') AND
	 (p.girofondo_infruttifero_libero_tab_b <> 'S')
	 ) 
	AND ((e.autokind = 6) -- Recupero
	OR (e.autokind = 14) --automatismo generico
	OR (e.autokind = 4 AND e.idreg = p.idreg)) -- Ritenuta
	AND ie.ayear = @y

-- L'incasso reale sarà suddiviso in due tranches, uno di importo parti al sospeso e non collegato alla spesa
-- l'altro sarà un incasso virtuale  collegato alla spesa (in modo da ottenere complessivamente saldo zero ) e con idpro
-- fittizio pari a 2 (obblighiamo a fare le reversali singole in tali casi)
INSERT INTO #pendingincome
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, curramount_expense, idreg, autokind,
	ymov_income, nmov_income, idpro,ndocformatted
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, p.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro,p.ndocformatted
FROM #payment p
JOIN income e
	ON e.idpayment = p.idexp	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN proceedstransmission
	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
AND (p.idpaymethodTRS <> '85' AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 (p.girofondo <> 'S') AND
	 (p.girofondo_infruttifero_libero <> 'S') AND
	 (p.girofondo_infruttifero_vincolato <> 'S') AND
	 (p.girofondo_infruttifero_libero_tab_b <> 'S')
	 )	
AND (e.autokind = 28 AND e.idreg = p.idreg) -- Incasso da regolarizzare con spesa accessoria e sospeso pari al netto
AND ie.ayear = @y
AND (il.flag&32 <> 0)
 
 
-- Valorizzazione del campo nproformatted
UPDATE #tax
SET nproformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),npro))) +
CONVERT(varchar(7),npro)

UPDATE #pendingincome
SET nproformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),npro))) +
CONVERT(varchar(7),npro)

-- Leggo configurazione dell'applicazione dei contributi 
DECLARE @admintaxkind int
SELECT  @admintaxkind = (automanagekind & 0xf) FROM config WHERE ayear = @y
 
-- Inserimento delle trattenute (vengono inseriti i contributi c/amministrazione)
INSERT INTO #admintax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, idreg, autokind,
	ymov_income, nmov_income, idpro
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.ndocformatted, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro
FROM #payment p
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
WHERE e.nphase = @maxincomephase
AND (p.idpaymethodTRS <> '85' AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 (p.girofondo <> 'S') AND
	 (p.girofondo_infruttifero_libero <> 'S') AND
	 (p.girofondo_infruttifero_vincolato <> 'S') AND
	 (p.girofondo_infruttifero_libero_tab_b <> 'S')
	 ) 
	AND e.autokind = 4 -- Contributo
	AND s.autokind = 4 
	AND s.autocode  = e.autocode
	AND p.idreg = e.idreg
	AND ie.ayear = @y
	AND @admintaxkind = 2 -- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro
	
-- Valorizzazione del campo nproformatted
UPDATE #admintax
SET nproformatted = 
SUBSTRING(REPLICATE('0',@len_ndoc),1,@len_ndoc - DATALENGTH(CONVERT(varchar(7),npro))) +
CONVERT(varchar(7),npro)

-- Riempimento della tabella del delegato
INSERT INTO #deputy (iddeputy, title_deputy, cf_deputy)
SELECT
	DISTINCT #payment.iddeputy,
	ISNULL(registry.title,'')
	+ SUBSTRING(SPACE(@len_deputy),1,@len_deputy - DATALENGTH(ISNULL(registry.title,''))),
	ISNULL(registry.cf,SPACE(@len_cf))
FROM #payment
JOIN registry
	ON #payment.iddeputy = registry.idreg

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
	idnation int,
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
	idnation,
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
		WHEN flagforeign = 'N' THEN 1
		ELSE geo_nation.idnation
	END,
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
		 (	(idreg IN (SELECT DISTINCT idreg FROM #payment))
			OR
			(idreg IN (SELECT DISTINCT iddeputy FROM #payment))
		)

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
	(SELECT * FROM #payment WHERE idreg NOT IN
		(SELECT DISTINCT idreg FROM #address ind)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il beneficiario ' + #payment.title_ben +
	+ ' non ha un indirizzo valido associato '
	FROM #payment
	WHERE idreg NOT IN
		(SELECT DISTINCT idreg FROM #address ind)
	)
END



-- CONTROLLO N. 11 Ogni delegato deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #deputy WHERE iddeputy NOT IN
		(SELECT DISTINCT idreg FROM #address ind)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il delegato ' + #deputy.title_deputy +
	+ ' non ha un indirizzo valido associato '
	FROM #deputy
	WHERE iddeputy NOT IN
		(SELECT DISTINCT idreg FROM #address ind)
	)
END

-- CONTROLLO N. 12 Ogni delegato estero deve avere una nazione associata
IF EXISTS(
	(SELECT * FROM #deputy WHERE iddeputy IN
		(SELECT DISTINCT idreg FROM #address ind WHERE idnation IS NULL)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il delegato ' + #deputy.title_deputy +
	+ ' non ha una nazione estera valida associata '
	FROM #deputy
	WHERE iddeputy IN
		(SELECT DISTINCT idreg FROM #address ind WHERE idnation IS NULL)
	)
END
--select * from #address where idreg in (select iddeputy from #deputy)
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Aggiornamento dei dati inerenti l'indirizzo del beneficiario	

UPDATE #payment
SET address_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @len_address
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@len_address),1,@len_address - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@len_address)
	END
	FROM #address
	WHERE #payment.idreg = #address.idreg),
cap_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @len_cap
		THEN SUBSTRING(REPLICATE('0',@len_cap),1,@len_cap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #payment.idreg = #address.idreg),
location_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @len_location
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@len_location),1,@len_location - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@len_location)
	END
	FROM #address
	WHERE #payment.idreg = #address.idreg),
province_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(province,'')) <= @len_province
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@len_province),1,@len_province - DATALENGTH(ISNULL(province,'')))
		ELSE SUBSTRING(province,1,@len_province)
	END
	FROM #address
	WHERE #payment.idreg = #address.idreg)

-- Aggiornamento dati indirizzo delegato
UPDATE #deputy
SET address_deputy =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(address,'')) <= @len_address
		THEN ISNULL(address,'') + SUBSTRING(SPACE(@len_address),1,@len_address - DATALENGTH(ISNULL(address,'')))
		ELSE SUBSTRING(address,1,@len_address)
	END
	FROM #address
	WHERE #deputy.iddeputy = #address.idreg),
cap_deputy =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @len_cap
		THEN SUBSTRING(REPLICATE('0',@len_cap),1,@len_cap - DATALENGTH(ISNULL(cap,'')))
		+ ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #deputy.iddeputy = #address.idreg),
location_deputy =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(location,'')) <= @len_location
		THEN ISNULL(location,'') + SUBSTRING(SPACE(@len_location),1,@len_location - DATALENGTH(ISNULL(location,'')))
		ELSE SUBSTRING(location,1,@len_location)
	END
	FROM #address
	WHERE #deputy.iddeputy = #address.idreg),
province_deputy =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(province,'')) <= @len_province
		THEN ISNULL(province,'') + SUBSTRING(SPACE(@len_province),1,@len_province - DATALENGTH(ISNULL(province,'')))
		ELSE SUBSTRING(province,1,@len_province)
	END
	FROM #address
	WHERE #deputy.iddeputy = #address.idreg),
	nation_deputy = (SELECT 
	ISNULL((SELECT value
		FROM #address JOIN geo_nation_agency
			ON #address.idnation = geo_nation_agency.idnation
			AND geo_nation_agency.idagency = 6 -- ente ISO			
			AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
			AND geo_nation_agency.version = 1
			AND geo_nation_agency.stop IS NULL
		WHERE #deputy.iddeputy = #address.idreg), 'IT')) --  da valorizzare con codice ISO per nazioni estere
		

-- Riempimento della tabella con i dati della classificazione SIOPE
DECLARE @npos int
DECLARE @codeclassSIOPE varchar(20)

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
DECLARE @classSIOPE int
SELECT @classSIOPE = idsorkind FROM sortingkind WHERE codesorkind = @codeclassSIOPE
-- Inserimento delle classificazioni SIOPE dei movimenti di spesa
INSERT INTO #siope
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted,
	idpay, sortcode, sorting, amount,idexp, cupcodefin, cupcodeupb, cupcodedetail, cupcodeexpense, progressive
)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc, #payment.ndocformatted,
	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description,
	SUM(expensesorted.amount),
	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1
FROM #payment
JOIN expensesorted
	ON #payment.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
GROUP BY #payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.ydoc,
	#payment.ndoc, #payment.ndocformatted,
	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)),sorting.description,
	#payment.idexp, 
	#payment.cupcodeexpense, #payment.cupcodedetail,#payment.cupcodeupb, #payment.cupcodefin

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
		AND s2.idpay =  #siope.idpay 
		AND s2.sortcode <  #siope.sortcode 
		)
,0)


INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay, testo)
SELECT  
ypaymenttransmission, 
npaymenttransmission, 
ydoc, 
ndoc,
ndocformatted,
idpay,
[dbo].getstringformatted_r(finlevel + ': ' + codefin + ' - ' + fintitle + ' ,UPB: ' + codeupb + ' - ' + upbtitle, @len_zinfent)
FROM #payment
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, 
		 ydoc, ndocformatted, finlevel, codefin, fintitle, codeupb, upbtitle


-- RECORD FASE + MOVIMENTO
INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay, testo)
SELECT  
ypaymenttransmission, 
npaymenttransmission, 
ydoc, 
ndoc,
ndocformatted,
idpay,
--Informazione Ente ZINFENT
	[dbo].getstringformatted_r(phase + ' n.' + convert(varchar(10),nmov) + ' / ' + + convert(varchar(4),ymov) + ', Competenza/Residui: ' + flagcr , @len_zinfent) 
FROM #payment
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, 
		 ydoc, ndocformatted,phase, ymov, nmov,flagcr

-- RECORD DESCRIZIONE CLASSIFICAZIONE SIOPE 
INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay, testo)
SELECT  
ypaymenttransmission, 
npaymenttransmission, 
ydoc, 
ndoc,
ndocformatted,
idpay,
--Informazione Ente ZINFENT
[dbo].getstringformatted_r('SIOPE: ' + sortcode + ' - ' + sorting + ', Importo: ' + convert(varchar(30), amount), @len_zinfent) 
FROM #siope
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, sortcode, sorting, amount,
		 ydoc, ndocformatted
		 
		 
UPDATE #note
SET progressive = 1 +
ISNULL(
	(SELECT COUNT(DISTINCT testo)
	FROM #note n2
	WHERE  n2.ydoc = #note.ydoc
		AND n2.ndoc = #note.ndoc
		AND n2.idpay =  #note.idpay 
		AND n2.testo <  #note.testo 
		)
,0)

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
	print @cc_vincolato


-- Tabella delle bollette multiple 
CREATE TABLE #expensebill
(
	ypaymenttransmission int,
	npaymenttransmission int,
	idexp int,
	ydoc int,
	ndoc int,
	idpay int,
	ybill int,
	nbill int,
	amount decimal(19,2) 
)
-- Riempimento della tabella delle bollette  

--  Bollette singole
INSERT INTO  #expensebill
(	ypaymenttransmission, npaymenttransmission, idexp,
	ydoc, ndoc, idpay, ybill,nbill, amount)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.idexp, 
	#payment.ydoc, #payment.ndoc,
	#payment.idpay, #payment.ydoc, expenselast.nbill,     
	#payment.curramount			 
FROM  #payment JOIN expenselast ON #payment.idexp = expenselast.idexp
WHERE   expenselast.nbill IS NOT NULL
 
	
 -- Bollette multiple
INSERT INTO  #expensebill
(	ypaymenttransmission, npaymenttransmission, idexp,
	ydoc, ndoc, idpay, ybill,nbill, amount)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,  #payment.idexp,  #payment.ydoc, #payment.ndoc,
	#payment.idpay, expensebill.ybill, expensebill.nbill, expensebill.amount
FROM #payment
JOIN expensebill ON #payment.idexp = expensebill.idexp

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
----------------------------
---  4.1MANDATI RECORD 0 ---	
----------------------------

INSERT INTO #trace (y, n, ndoc, nrow, kind, out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, 0, 0,'0',
    @prefisso_record +
	ndocformatted + 
	REPLICATE('0',7) + --NSUB
	'0' +  -- TIPO RECORD
	--- DATA TRASMISSIONE
	[dbo].GetData(transmissiondate) +
	-- Importo Mandato
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
	REPLICATE(' ',20) + --CENTGEN
	REPLICATE(' ',248)+ --FILLER
	REPLICATE('0' ,7) + -- NUMERO MANDATO COLLEGATO
	REPLICATE(' ', 3) + 
	CASE -- mandato con disposizioni di pagamento (elenco beneficiari)
		WHEN ((idpaydisposition IS NOT NULL) AND (fulfilled = 'N')) THEN 'BEN'  -- DISPOSIZIONI DI PAGAMENTO ALLEGATE
		ELSE  REPLICATE(' ', 3) 
	END +
	CONVERT(varchar(7),[dbo].getint(idpaydisposition, @len_numericdata)) + -- NUMERO DISPOSIZIONE DI PAGAMENTO ASSOCIATA DA VALORIZZARE
	-- REPLICATE('0', 7) + 
	@opkind + 
	'M'
FROM #payment
GROUP BY ypaymenttransmission, npaymenttransmission, transmissiondate,
		 ydoc, ndoc, ndocformatted,fulfilled, idpaydisposition 
		 
----------------------------------------------
-----------  4.2MANDATI RECORD 1 -------------	
----------------------------------------------
INSERT INTO #trace (y, n, ndoc, nrow, kind, out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 1,'0',
	-- Tipo Record
	@prefisso_record +
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay)
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD 
	'1' +
	-- NCAP + NART + NRES + CVOCNEW: I CAMPI RELATIVI ALLA GESTIONE DEL BILANCIO DEVONO RESTARE VUOTI
	-- PER QUESTA TIPOLOGIA DI ENTE NON SONO RILEVANTI
	REPLICATE('0',7) + -- NCAP
	REPLICATE('0',3) + -- NART
	REPLICATE('0',4) + -- NRES 
	REPLICATE('0',3) + -- CVOCNEW
	REPLICATE('0',7) + -- NUMERO CONTO DI PROCEDURA NCNT
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount -    --- IBEN IMPORTO BENEFICIARIO
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) +
	REPLICATE(' ',3) + -- CODICE DIVISA BENEFICIARIO
	--CODICE MODALITA' PAGAMENTO BANCA
	CASE fulfilled 
		WHEN 'S'  THEN  '01' --PAGAMENTO A COPERTURA
		ELSE [dbo].getstringformatted_r(idpaymethodTRS,2)  
	END + 
	REPLICATE('0',8) + -- DATA ESECUZIONE PAGAMENTO NON VALORIZZARE SU RICHIESTA CARIME, LE DATE HANNO IL FORMATO NUMERICO
	REPLICATE('0',8) + -- DATA VALUTA BENEFICIARIO
	-- Codice Trattamento bollo
	CASE fulfilled 
		WHEN 'S'  THEN REPLICATE('0' ,3)
		ELSE [dbo].getstringformatted_r(SUBSTRING(stamp_charge,1,3),3) 
	END + 
	-- Importo Bollo, valorizzare con zero
	REPLICATE('0',9) +
	-- Codice trattamento spese: da valorizzare sempre a “000”(zero), tranne in caso di esenzione. L'importo sarà gestito dalla banca
	CASE uncharged 
		WHEN 'N'  THEN REPLICATE('0' ,3) --- gestione a carico della banca
		ELSE '075' --- esenzione spese
	END + 
	-- Importo Spese, valorizzare con zero
	REPLICATE('0',9) +
	 -- GIROFONDI VERSO BANCA D'ITALIA 
	 --- MANDATO A COPERTURA DI PROVVISORI GIA' EMESSI CHE LA BANCA DEVE REGOLARIZZARE (AD ESEMPIO F24 EP) 
	CASE  
		WHEN (girofondo = 'S') THEN '09'
		WHEN (girofondo_infruttifero_libero_tab_b = 'S') THEN '09'
		WHEN (girofondo_infruttifero_libero = 'S') THEN '18'
		WHEN (girofondo_infruttifero_vincolato = 'S') THEN '20'
		ELSE '01' -- FRUTTIFERA
	END +  -- TIPO IMPUTAZIONE
	CASE  
		WHEN  ((girofondo = 'S') AND (UPPER(USER) = 'AMMINISTRAZIONE')) THEN CONVERT(varchar(7),[dbo].getint(1777,@len_numericdata) ) 
		WHEN  (girofondo_infruttifero_libero = 'S') THEN CONVERT(varchar(7),[dbo].getint(extracode,@len_numericdata) ) 
		WHEN  (girofondo_infruttifero_libero_tab_b = 'S') THEN CONVERT(varchar(7),[dbo].getint(extracode,@len_numericdata) ) 
		WHEN  (girofondo_infruttifero_vincolato = 'S') THEN CONVERT(varchar(7),[dbo].getint(extracode,@len_numericdata) ) 
		ELSE  REPLICATE('0',@len_numericdata)
	END +  -- NUMERO CONTO BANCA ITALIA
	fulfilled +  -- INDICATORE MANDATO A COPERTURA
	CASE
			-- Partita IVA
			WHEN LTRIM(RTRIM(pi_ben)) <> '' THEN [dbo].getstringformatted_r(SUBSTRING(pi_ben,1,@len_cf),@len_cf) 
			-- Codice Fiscale
			ELSE [dbo].getstringformatted_r(SUBSTRING(cf_ben,1,@len_cf),@len_cf)  
	END +
	--Codice Istat beneficiario
	REPLICATE('0',7) +
	-- Codice lingua beneficiario
	SPACE(1) +
	[dbo].getstringformatted_r(SUBSTRING (title_ben, 1, @len_tranche),@len_tranche) + 
	-- Indirizzo Beneficiario
	[dbo].getstringformatted_r(address_ben,@len_tranche) +
	-- C.A.P. Beneficiario
	[dbo].getstringformatted_r(cap_ben,5) + 
	-- Località Beneficiario
	[dbo].getstringformatted_r(location_ben,28) +
	-- Provincia Beneficiario
	[dbo].getstringformatted_r(province_ben,2) +
	-- Codice ABI Beneficiario
	CASE
		WHEN ((idpaymethodTRS IN ('52','53','60')) AND (fulfilled = 'N')) THEN ABI
		ELSE REPLICATE('0',@len_ABI)
	END +
	-- Codice CAB Beneficiario
	CASE
		WHEN ((idpaymethodTRS IN ('52','53','60')) AND (fulfilled = 'N')) THEN CAB
		ELSE REPLICATE('0',@len_CAB)
	END +
	-- Conto Corrente Beneficiario
	CASE
		WHEN  ((idpaymethodTRS IN ('52','53','60','09','12')) AND (fulfilled = 'N')) THEN cc
		ELSE REPLICATE(' ',@len_cc)
	END +
	-- CIN
	CASE 
		WHEN  ((idpaymethodTRS IN ('52','53','60')) AND (fulfilled = 'N'))  THEN cin
		ELSE ' ' 
	END +
	REPLICATE('0',3) + --  CCAU	
	-- Causale Pagamento
	[dbo].getstringformatted_r(substring(newpaymentdescr,1,@len_tranche), @len_tranche)				     + --	ZCAU1
	[dbo].getstringformatted_r(substring(newpaymentdescr,@len_tranche + 1,@len_tranche), @len_tranche)   + --	ZCAU2		
	[dbo].getstringformatted_r(substring(newpaymentdescr,2*@len_tranche + 1,@len_tranche), @len_tranche) + --	ZCAU3	
	REPLICATE(' ',@len_cf) + --	CBEN	
	REPLICATE(' ',4)  + --	CTIPBEN	
	REPLICATE('0',3)  + --	CNOT1	
	REPLICATE('0',3)  + --	CNOT2	
	REPLICATE('0',3)  + --	CNOT3	
	@opkind + 
	'M'
	FROM #payment
	GROUP BY
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay,
	title_ben, address_ben, cap_ben, location_ben, province_ben,
	pi_ben, cf_ben, ABI, CAB, cc, cin, 
	idpaymethodTRS, newpaymentdescr,CUP, CIG, transmissiondate, fulfilled,uncharged,
	stamp_charge,  girofondo, girofondo_infruttifero_libero,girofondo_infruttifero_vincolato, 
	girofondo_infruttifero_libero_tab_b,
	extracode

--------------------------------------------	
------ MANDATI RECORD 4 – TIPO B  ----------
--------------------------------------------	
-- RECORD SUPPLEMENTARE PER QUEI BENEFICIARI	
-- CHE HANNO UN NOME PIU' LUNGO DI 30 CAR.
-- IL NOME VIENE SPLITTATO IN TRANCHE AGGIUNTIVE DI 70 CAR.

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 4,'B',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'B' +
	--ZINF01
	[dbo].getstringformatted_r(SUBSTRING(title_ben,@len_tranche + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF02
	[dbo].getstringformatted_r(SUBSTRING(title_ben,@len_tranche +@len_tranche_aggiuntiva +1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF03
	[dbo].getstringformatted_r(SUBSTRING(title_ben,@len_tranche + 2*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF04
	[dbo].getstringformatted_r(SUBSTRING(title_ben, @len_tranche + 3*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--FILLER
	REPLICATE (' ', 77) +
	--SOPE
	@opkind + 
	--SDOC
	'M'
FROM #payment
WHERE registry_tosplit = 'S'
GROUP BY
ypaymenttransmission, npaymenttransmission, ydoc, ndoc, 
ndocformatted, idpay,title_ben

-------------------------------------------------	
-------- MANDATI RECORD 4 – TIPO C  -------------
-------------------------------------------------	
-- RECORD SUPPLEMENTARE PER QUEI PAGAMENTI	
-- CHE HANNO UNA DESCRIZIONE PIU' LUNGA DEI 
-- 90 CAR. MESSI A DISPOSIZIONE NEL RECORD PRINCIPALE 
-- LA STRINGA VIENE SPLITTATA IN TRANCHE AGGIUNTIVE 
-- DI 70 CAR.


INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 4,'C',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'C' +
	--ZINF01
	[dbo].getstringformatted_r(SUBSTRING(newpaymentdescr,3*@len_tranche + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF02
	[dbo].getstringformatted_r(SUBSTRING(newpaymentdescr,3*@len_tranche +@len_tranche_aggiuntiva +1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF03
	[dbo].getstringformatted_r(SUBSTRING(newpaymentdescr,3*@len_tranche + 2*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--ZINF04
	[dbo].getstringformatted_r(SUBSTRING(newpaymentdescr,3*@len_tranche + 3*@len_tranche_aggiuntiva + 1,@len_tranche_aggiuntiva),@len_tranche_aggiuntiva) +
	--FILLER
	REPLICATE(' ' ,77) +
	--SOPE
	@opkind + 
	--SDOC
	'M'
FROM #payment
WHERE paymentdescr_tosplit = 'S'
GROUP BY
ypaymenttransmission, npaymenttransmission, ydoc, ndoc, 
ndocformatted, idpay,newpaymentdescr
	

-------------------------------------------------	
-------- MANDATI RECORD 4 – TIPO D  -------------
-------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI IN CUI E' PREVISTA LA FIGURA
-- DEL DELEGATO DEL BENEFICIARIO

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 4,'D',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'D' +
	--ZANADEL
	[dbo].getstringformatted_r(SUBSTRING(title_deputy,1,@len_tranche), @len_tranche) +
	--ZINDDEL
	[dbo].getstringformatted_r(address_deputy,@len_tranche) +
	--CCCAPDEL
	[dbo].getstringformatted_r(cap_deputy,5) +
	--ZLOCDEL
	[dbo].getstringformatted_r(location_deputy,@len_tranche) +
	--CFISDEL
	[dbo].getstringformatted_r(cf_deputy,16) + 
	--ZANADEL2
	[dbo].getstringformatted_r(SUBSTRING(title_deputy,@len_tranche + 1,@len_tranche + @len_tranche_aggiuntiva),@len_tranche + @len_tranche_aggiuntiva) +
	--ZANADEL2
	'IT' + -- vedere come valorizzare per le nazioni estere
	--FILLER
	SPACE(144) +
	--SOPE
	@opkind + 
	--SDOC
	'M'
FROM #payment
JOIN #deputy
	ON #payment.iddeputy = #deputy.iddeputy

-------------------------------------------------	
-------- MANDATI RECORD 4 – TIPO I  -------------
-------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI IN CUI E' STATA UTILIZZATA LA MODALITA' 
-- DI PAGAMENTO BONIFICO, INFATTI IN TALI CASI E'
--OBBLIGATORIO L'IBAN DAL 2008

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 4,'I',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'I' +
	--CBAN = CPAE (codice paese) + CHDI (check digit) + BBAN
	[dbo].getstringformatted_r(iban,34) + 
	-- CBIC (codice banca destinataria)
	SPACE(11) +
		/*
		--CSWI 
		SPACE(8) +
		--CBRA
		SPACE(3) +
		*/
	--DBDEST
	SPACE(120) +
	--CBICTRA
	SPACE(11) +
	-- CSWITRA (codice swift)
		/*
		SPACE(8) + 
		-- CBRATRA (codice branch)
		SPACE(3) +
		*/
	--DBTRA (descrizione banca e agenzia transitata)
	SPACE(120) +
	-- CVERCAS
	SPACE(10) +
	--CEND
	SPACE(20)+
	--FILLER
	SPACE(31) +
	@opkind + 
	'M'
FROM #payment
WHERE idpaymethodTRS in ('52','53','60','58') -- pagamento con bonifico
AND fulfilled = 'N' -- (il record IBAN non deve essere valorizzato per i mandati a regolarizzazione, che diventano per cassa 01)
GROUP BY ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay, iban


/*
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 4,'I',
	-- Tipo Record
	len(@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'I' +
	--CBAN = CPAE (codice paese) + CHDI (check digit) + BBAN
	[dbo].getstringformatted_r(iban,34) + 
	-- CBIC (codice banca destinataria)
	SPACE(11) +
		/*
		--CSWI 
		SPACE(8) +
		--CBRA
		SPACE(3) +
		*/
	--DBDEST
	SPACE(120) +
	--CBICTRA
	SPACE(11) +
	-- CSWITRA (codice swift)
		/*
		SPACE(8) + 
		-- CBRATRA (codice branch)
		SPACE(3) +
		*/
	--DBTRA (descrizione banca e agenzia transitata)
	SPACE(120) +
	-- CVERCAS
	SPACE(10) +
	--CEND
	SPACE(20)+
	--FILLER
	SPACE(31) +
	@opkind + 
	'M')
FROM #payment
WHERE idpaymethodTRS in ('52','53','60') -- pagamento con bonifico
GROUP BY ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay, iban
*/
-------------------------------------------------	
-------- MANDATI RECORD 4 – TIPO N  -------------
-------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI IN CUI E' ALLEGATA LA 
-- DISPOSIZIONE DOCUMENTO ESTERNO (COD. BANCA 84)
-- (PAGAMENTO DI MAV, F23) ECC. CHE VIENE POSTICIPATO
-- AL MOMENTO DELLA RICEZIONE DELL'ALLEGATO CARTACEO

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 4,'N',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'4' +
	--CINF
	'N' +
	--ZINF
	--REPLICATE(' ',50) +
	[dbo].getstringformatted_r(SUBSTRING(CONVERT(varchar(50),expenselast_paymentdescr), 1, 50),50) + 
	--ZINF RESIDUO
	SPACE(230) +  
		/* DETTAGLIO CAMPI ZINF: SOLO I PRIMI 5O SONO UTILIZZABILI
		-- ZINF01
		SPACE(70)  +
		-- ZINFA1
		SPACE(50)  +
		-- ZINFB1
		SPACE(20)  +
		--ZINF02
		SPACE(70)  +
		--ZINF03
		SPACE(70)  +
		--ZINF04
		SPACE(70)  +*/
	--FILLER
	SPACE(77) +
	@opkind + 
	'M'
FROM #payment
WHERE idpaymethodTRS = '84' -- pagamento con disposizione cartacea allegata
AND fulfilled = 'N'
GROUP BY ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted,
expenselast_paymentdescr, idpay


----------------------------------------------------	
-------------- MANDATI RECORD 5 (a)-----------------
----------------------------------------------------

-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI CON RITENUTE CHE DEVONO ESSERE
-- A CARICO DEL BENEFICIARIO

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 5,'0',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'5' +
	-- IASS IMPORTO ASSOCIATO
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(#tax.curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(#tax.curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(#tax.curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(#tax.curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(#tax.curramount)))-1,2) +
	-- NREVRIT NUMERO REVERSALE RITENUTE
	#tax.nproformatted +
	-- NSUBRIT NUMERO SUB RITENUTE
	CONVERT(varchar(7),[dbo].getint(#tax.idpro, @len_numericdata)) +
	-- STIPASS TIPO ASSOCIAZIONE AL MANDATO PRINCIPALE
	'R' +
	-- CTIPDOC TIPO DOCUMENTO ASSOCIATO
	'REV' +
	-- FILLER
	SPACE(325) +
	@opkind + 
	'M'
FROM #tax
GROUP BY #tax.ypaymenttransmission, #tax.npaymenttransmission, #tax.ydoc, #tax.ndoc, #tax.ndocformatted,
#tax.idpay, #tax.npro, #tax.nproformatted, #tax.idpro

----------------------------------------------------	
-------------- MANDATI RECORD 5 (b)-----------------
----------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI RELATIVI ALL'APPLICAZIONE DEI CONTRIBUTI (ES. IRAP)
-- CON CORRISPONDENTE MOVIMENTO DI ENTRATA SU PARTITA DI GIRO

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 5,'0',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'5' +
	-- IASS IMPORTO ASSOCIATO
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(#admintax.curramount)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(#admintax.curramount)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(#admintax.curramount)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(#admintax.curramount)),
	DATALENGTH(CONVERT(varchar(15),SUM(#admintax.curramount)))-1,2) +
	-- NREVRIT NUMERO REVERSALE RITENUTE
	#admintax.nproformatted +
	-- NSUBRIT NUMERO SUB RITENUTE
	CONVERT(varchar(7),[dbo].getint(#admintax.idpro, @len_numericdata)) +
	-- STIPASS TIPO ASSOCIAZIONE AL MANDATO PRINCIPALE
	'R' +
	-- CTIPDOC TIPO DOCUMENTO ASSOCIATO
	'REV' +
	-- FILLER
	SPACE(325) +
	@opkind + 
	'M'
FROM #admintax
GROUP BY #admintax.ypaymenttransmission, #admintax.npaymenttransmission, #admintax.ydoc, #admintax.ndoc, #admintax.ndocformatted,
#admintax.idpay, #admintax.npro, #admintax.nproformatted, #admintax.idpro

----------------------------------------------------	
-------------- MANDATI RECORD 5 (c)-----------------
----------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI ACCESSORI RELATIVI A INCASSI DA REGOLARIZZARE CON SOSPESO PARI ALLA DIFFERENZA TRA INCASSO REALE E SPESA
-- INSERISCO NEL RECORD RITENUTE IL CORRISPONDENTE MOVIMENTO DI ENTRATA VIRTUALE DI IMPORTO PARI ALLA SPESA
-- E IDPRO FITTIZIO PARI A 2 (SE L'ORIGINALE E' 1)

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 5,'0',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'5' +
	-- IASS IMPORTO ASSOCIATO
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - 
	DATALENGTH(CONVERT(varchar(15),SUM(#pendingincome.curramount_expense)))) +
	SUBSTRING(CONVERT(varchar(15),SUM(#pendingincome.curramount_expense)),1,
	DATALENGTH(CONVERT(varchar(15),SUM(#pendingincome.curramount_expense)))-3) +
	SUBSTRING(CONVERT(varchar(15),SUM(#pendingincome.curramount_expense)),
	DATALENGTH(CONVERT(varchar(15),SUM(#pendingincome.curramount_expense)))-1,2) +
	-- NREVRIT NUMERO REVERSALE RITENUTE
	#pendingincome.nproformatted +
	-- NSUBRIT NUMERO SUB RITENUTE
	CONVERT(varchar(7),[dbo].getint(#pendingincome.idpro +1 , @len_numericdata)) +
	-- STIPASS TIPO ASSOCIAZIONE AL MANDATO PRINCIPALE
	'R' +
	-- CTIPDOC TIPO DOCUMENTO ASSOCIATO
	'REV' +
	-- FILLER
	SPACE(325) +
	'VAR' + 
	'M'
FROM #pendingincome
GROUP BY #pendingincome.ypaymenttransmission, #pendingincome.npaymenttransmission, 
#pendingincome.ydoc, #pendingincome.ndoc, #pendingincome.ndocformatted,
#pendingincome.idpay, #pendingincome.npro, #pendingincome.nproformatted, #pendingincome.idpro

-------------------------------------------------	
-------------- MANDATI RECORD 6 -----------------
-------------------------------------------------	
-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- DOCUMENTI  A REGOLARIZZAZIONE DI 
-- PROVVISORI

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	#payment.ypaymenttransmission,  #payment.npaymenttransmission,  #payment.ndoc, 6,'0',
	-- Tipo Record
	@prefisso_record +
	--NMAN
	-- Numero Mandato
	 #payment.ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint( #payment.idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'6' +
	-- NPRO
	REPLICATE('0',7 - LEN(CONVERT(varchar(7), #expensebill.nbill))) + CONVERT(varchar(7), #expensebill.nbill) + --numero del provvisorio emesso per il pagamento anticipato
	--IREG
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - DATALENGTH(CONVERT(varchar(15),SUM(#expensebill.amount))))  +
	SUBSTRING(CONVERT(varchar(15),SUM(#expensebill.amount)),1, DATALENGTH(CONVERT(varchar(15),SUM(#expensebill.amount)))-3)  +
	SUBSTRING(CONVERT(varchar(15),SUM(#expensebill.amount)), DATALENGTH(CONVERT(varchar(15),SUM(#expensebill.amount)))-1,2) + --importo del provvisorio emesso per il pagamento anticipato
	-- FILLER
	SPACE(336) +
	@opkind + 
	'M'
FROM #payment JOIN #expensebill ON #payment.idexp = #expensebill.idexp 
GROUP BY #payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.ydoc, #payment.ndoc, 
#payment.ndocformatted, #payment.idpay, #expensebill.nbill

/*
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 6,'0',
	-- Tipo Record
	len(@prefisso_record +
	--NMAN
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(idpay, @len_numericdata)) +
	-- TIPO RECORD CTIPREC
	'6' +
	-- NPRO
	REPLICATE('0',7 - LEN(CONVERT(varchar(7),nbill))) + CONVERT(varchar(7),nbill) + --numero del provvisorio emesso per il pagamento anticipato
	--IREG
	SUBSTRING(REPLICATE('0',@len_amount),1,1 + @len_amount - DATALENGTH(CONVERT(varchar(15),SUM(curramount))))  +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)),1, DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-3)  +
	SUBSTRING(CONVERT(varchar(15),SUM(curramount)), DATALENGTH(CONVERT(varchar(15),SUM(curramount)))-1,2) + --importo del provvisorio emesso per il pagamento anticipato
	-- FILLER
	SPACE(336) +
	@opkind + 
	'M')
FROM #payment
WHERE fulfilled = 'S'
GROUP BY ypaymenttransmission, npaymenttransmission, ydoc, ndoc, ndocformatted, idpay, fulfilled, nbill
*/

-------------------------------------------------	
-------------- MANDATI RECORD 7 -----------------
-------------------------------------------------	

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 7,'0',
	@prefisso_record +
	-- Numero Mandato
	ndocformatted +  --NMAN
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(#note.idpay, @len_numericdata)) +
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
	'M'
FROM #note
ORDER BY ndoc,idpay,progressive


		 
-------------------------------------------------	
-------------- MANDATI RECORD 8 -----------------
-------------------------------------------------	
-- RECORD CLASSIFICAZIONI SIOPE

INSERT INTO #trace (y, n, ndoc, nrow, kind,out_str)
SELECT
	ypaymenttransmission, npaymenttransmission, ndoc, 8,'0',
	@prefisso_record +
	-- Numero Mandato
	ndocformatted +
	-- Numero Subordinativo (idpay) NSUB
	CONVERT(varchar(7),[dbo].getint(#siope.idpay, @len_numericdata)) +
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
	[dbo].getstringformatted_r(ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, cupcodefin))),15) + --Codice Cup
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
	'M'
FROM #siope
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, sortcode, 
		 ydoc, ndocformatted,  cupcodeexpense,  cupcodedetail, cupcodeupb,cupcodefin, progressive

-- Rimozione dei caratteri non consentiti

--select  *  FROM #payment
--WHERE idpaymethodTRS in ('52','53','60') -- pagamento con bonifico

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

SELECT out_str FROM #trace ORDER BY substring(out_str, 1,38) --y, n, ndoc, nrow
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



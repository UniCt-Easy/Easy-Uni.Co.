
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
 if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_bppugliese_var]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_bppugliese_var]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE        PROCEDURE [trasmele_expense_bppugliese_var]
(
	@y int,
	@n int
)
AS BEGIN

--------------------------------------------------------------
---  STORED PROCEDURE PER LA TRASMISSIONE DEI MANDATI PER  ---
----------- BANCA POPOLARE PUGLIESE---------------------------
--------------------------------------------------------------
DECLARE @len_numericdata int
SET @len_numericdata = 7

DECLARE @len_codentebt INT
SET @len_codentebt = 7

DECLARE @lencodicecontabilitaspeciale int
SET @lencodicecontabilitaspeciale = 7	

DECLARE @len_cap int
SET @len_cap = 16

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

DECLARE @len_bank int
SET @len_bank =50

DECLARE @idtreasurer int
DECLARE @kpaymenttransmission int
DECLARE @adate datetime
SELECT @idtreasurer = idtreasurer, @kpaymenttransmission = kpaymenttransmission FROM paymenttransmission
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n

select @adate = GetDate()

DECLARE @idchargehandling_default  int
DECLARE @handlingbankcode_default  varchar(50)
DECLARE @motive_default  varchar(100)
DECLARE @payment_kind_default varchar(100)
SELECT  @idchargehandling_default = idchargehandling,@handlingbankcode_default = handlingbankcode,
		@motive_default = motive, @payment_kind_default = payment_kind
FROM    chargehandling WHERE   ((chargehandling.flag & 2) <> 0)

DECLARE @len_desc_dept int
SET @len_desc_dept = 30

DECLARE @len_address_dept int
SET @len_address_dept = 30

DECLARE @len_location_dept int
SET @len_location_dept = 35

DECLARE @cf_dept varchar(16)
DECLARE @desc_dept varchar(150)
DECLARE @address_dept varchar(30)
DECLARE @location_dept varchar(35)

SELECT  @cf_dept = ISNULL(cf,p_iva),
@desc_dept =  ISNULL(agencyname,''),
@address_dept = ISNULL(address1,''),
@location_dept = ISNULL(location,'') 
FROM license

--Il Tipo operazione Può assumere i valori 
--INSERIMENTO– Inserimento  Ordinativo 
--VARIAZIONE- Variazione Ordinativo
--ANNNULLO- Annullo Ordinativo
--SOSTITUZIONE- Sostituzione Ordinativo
--(vedere specifiche tracciato ma non la gestiamo)

DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 7

DECLARE @cc_vincolato varchar(7)

DECLARE @len_agencycode int
SET @len_agencycode = 8

DECLARE @CodiceStruttura varchar(16)

/*
-------------------------------------------------------
------- MAPPATURA MODALITA' DI PAGAMENTO --------------
-------------------------------------------------------

1 “CASSA”
2 “BONIFICO BANCARIO E POSTALE”
3 “SEPA CREDIT TRANSFER”
4 “ASSEGNO BANCARIO E POSTALE”
5 “ASSEGNO CIRCOLARE”
6 “ACCREDITO CONTO CORRENTE POSTALE”
7 “ACCREDITO TESORERIA PROVINCIALE STATO PER TAB A”   GIROFONDO + VALORIZZAZ CODICE CONTABILITA SPECIALE
8 “ACCREDITO TESORERIA PROVINCIALE STATO PER TAB B”   GIROFONDO + VALORIZZAZ CODICE CONTABILITA SPECIALE
9 “F24EP” (7)										  GIROFONDO + VALORIZZAZ CODICE CONTABILITA SPECIALE 1777
10 “VAGLIA POSTALE”
11 “VAGLIA TESORO”

“REGOLARIZZAZIONE”
“REGOLARIZZAZIONE ACCREDITO TESORERIA PROVINCIALE STATO PER TAB A”
“REGOLARIZZAZIONE ACCREDITO TESORERIA PROVINCIALE STATO PER TAB B”

12 “ADDEBITO PREAUTORIZZATO”
13 “DISPOSIZIONE DOCUMENTO ESTERNO”
*/

/*
-------------------------------------------------------
----- MODALITA' DI TRATTAMENTO BOLLO --------
-------------------------------------------------------

può assumere i valori
1 “ESENTE BOLLO”
2 “ASSOGGETTATO BOLLO A CARICO ENTE”
3 “ASSOGGETTATO BOLLO A CARICO BENEFICIARIO”
*/
/*
-------------------------------------------------------
----- MODALITA' DI TRATTAMENTO SPESE --------
-------------------------------------------------------

può assumere i valori
1 "A CARICO ENTE"
2 "A CARICO BENEFICIARIO"
3 "ESENTE"

*/
DECLARE @cod_department varchar(9) -- Codice dell'ente da esportare
DECLARE @ABI_code varchar(5)
SELECT  @cod_department = ISNULL(RTRIM(agencycodefortransmission),''),
	@ABI_code = SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(idbank,'')))+ ISNULL(idbank,''),
	@cc_vincolato = SUBSTRING(REPLICATE('0',@lenCC_vincolato),1,@lenCC_vincolato - 
					DATALENGTH(CONVERT(varchar(8),ISNULL(trasmcode,'0')))) + CONVERT(varchar(8),ISNULL(trasmcode,'0'))	,
	@CodiceStruttura = ISNULL(billcode,'')  		
FROM treasurer WHERE idtreasurer = @idtreasurer

CREATE TABLE #error (message varchar(400))

-- Inizio Sezione Controlli
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
IF(
(SELECT COUNT(*) FROM expensevar
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


-- CONTROLLO N. 2. Movimento di Spesa senza Modalità di Pagamento
INSERT INTO #error (message)
(SELECT 'Per il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' non è stata scelta una modalità di pagamento'
FROM paymentcommunicated
JOIN expensevar 
	ON expensevar.idexp = paymentcommunicated.idexp
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission 
	AND idpaymethod IS NULL
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
	AND NOT EXISTS (SELECT * FROM expenseview WHERE expenseview.idexp =paymentcommunicated.idexp AND  netamount = 0)
	)


-- CONTROLLO N. 3. Movimento di Spesa con Modalità di Pagamento non configurata

INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' la modalità di pagamento scelta non è configurata, Andare in Configurazione - Anagrafica - Modalità di Pagamento'
FROM paymentcommunicated
JOIN expensevar
	ON paymentcommunicated.idexp = expensevar.idexp
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND (paymethod.methodbankcode IS NULL OR REPLACE(paymethod.methodbankcode,' ','') = '')
)

-- CONTROLLO N. 4. Codice IBAN o ABI o CAB devono essere valorizzati nel caso di modalità di pagamento '02'
--- ABI, CAB, CIN, NUMERO CONTO obbligatori in caso di BONIFICI
--- NUMERO CONTO obbligatorio in caso di BOLLETTINO CCP
INSERT INTO #error (message)
(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento scelta non è stato assegnato il codice ABI / CAB.'
FROM paymentcommunicated
	JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
JOIN expensevar
	ON paymentcommunicated.idexp = expensevar.idexp
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode IN ('02')
	AND (
		(paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
		OR (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
		))

-- CONTROLLO N. 5. Il codice ABI, CAB e il CIN non devono eccedere la lunghezza massima nel caso di modalità di pagamento 53 e 63
INSERT INTO #error (message)
(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento il codice ABI eccede la lunghezza di '
+ CONVERT(varchar(3),@len_ABI) + ' caratteri e/o il codice CAB eccede la lunghezza di '
+ CONVERT(varchar(3),@len_CAB) + ' caratteri e/o il CIN eccede la lunghezza di '
+ CONVERT(varchar(3),@len_cin) + ' caratteri'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
JOIN expensevar
	ON paymentcommunicated.idexp = expensevar.idexp
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode IN ('02')
	AND (
	(DATALENGTH(paymentcommunicated.idcab) > @len_CAB)
	OR (DATALENGTH(paymentcommunicated.idbank) > @len_ABI)
	OR (DATALENGTH(paymentcommunicated.cin) > @len_cin)
		)
	)
	
-- CONTROLLO N. 6. Conto Corrente valorizzato e di lunghezza massima 12 caratteri nel caso di modalità di pagamento 2
-- BONIFICO BANCARIO E POSTALE
IF EXISTS
(SELECT * FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
JOIN expensevar
	ON paymentcommunicated.idexp = expensevar.idexp
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode IN ('02','06') 
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
	JOIN expensevar
		ON paymentcommunicated.idexp = expensevar.idexp
	WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode IN ('02','06')
	AND (paymentcommunicated.cc IS NULL
		OR REPLACE(paymentcommunicated.cc,' ','') = ''
		OR DATALENGTH(ISNULL(paymentcommunicated.cc,'')) > @len_cc)
	)
END


-- CONTROLLO N. 7. Presenza tipologia dei beneficiari
DECLARE @denomcred_err varchar(200)
INSERT INTO #error (message)
SELECT 'Il beneficiario ' + ISNULL(R.title,'XXX') + ' con codice ' + CONVERT(varchar(6),R.idreg) + ' non ha una tipologia associata. E'' necessario inserirla'
FROM expense E
JOIN expenselast EL
	ON E.idexp = EL.idexp
JOIN expensevar EV
	ON EV.idexp = EL.idexp
JOIN payment P
	ON P.kpay = EL.kpay
JOIN registry R
	ON R.idreg = E.idreg
WHERE R.idregistryclass IS NULL
	AND EV.kpaymenttransmission = @kpaymenttransmission


-- CONTROLLO N. 8. Uso di modalità di pagamento NON ammesse dalla banca-  vedi Specifiche tracciato
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata una modalità di pagamento non prevista dalla banca.'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
JOIN expensevar
	ON paymentcommunicated.idexp = expensevar.idexp
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND paymethod.methodbankcode NOT IN ('01','02', '03','04','05','06','07','08','09','10','11','12','13')
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

-- CONTROLLO N. 12. Bollettino postale (cod. pag. 02)i codici ABI e CAB non devono essere valorizzati, lo deve essere solo il numero del C/C-- 
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata la modalità di pagamento Bollettino Postale  ma il codice ABI  e CAB non devono essere valorizzati'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode  = '06'
	AND 
	(
		paymentcommunicated.idbank  IS NOT NULL OR
		paymentcommunicated.idcab  IS NOT NULL 
	)	 
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
)

-- CONTROLLO N. 13. Presenza trattamento bollo
INSERT INTO #error (message)
SELECT 'Il trattamento bollo deve essere obbligatoriamente impostato per il mandato n° ' + CONVERT(varchar(6),P.npay) 
FROM payment P
WHERE P.idstamphandling IS NULL
	  AND P.kpaymenttransmission = @kpaymenttransmission


-- CONTROLLO N. 14. codice contabilita speciale errato o mancante, controllare regole su codice contabilità speciale girofondi
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
		JOIN expensevar 
			ON expensevar.idexp = expenselast.idexp
WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
	AND 
	  (
	   ((expenselast.paymethod_flag & 64) <> 0) OR
	   ((expenselast.paymethod_flag & 256) <> 0) OR
	   ((expenselast.paymethod_flag & 512) <> 0)  OR 
	   ((expenselast.paymethod_flag & 1024) <> 0) OR 
	   ((expenselast.paymethod_flag & 2048) <> 0) 
	   )  
	AND paymethod.methodbankcode  <> '09' -- In caso di girofondo F24EP il codice contabilità speciale  è fisso e non va segnalatato l'errore
	AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
		OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),' ','') = ''
		OR DATALENGTH(ISNULL(
		REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
		REPLACE(REPLACE(REPLACE(REPLACE(registrypaymethod.extracode,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
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
		JOIN expensevar 
			ON expensevar.idexp = expenselast.idexp
		WHERE expensevar.kpaymenttransmission = @kpaymenttransmission
		AND paymethod.methodbankcode  <> '09' -- In caso di girofondo F24EP il codice contabilità speciale è fisso e non va segnalatato l'errore
				 AND (
		   ((expenselast.paymethod_flag & 64) <> 0) OR
		   ((expenselast.paymethod_flag & 256) <> 0) OR
		   ((expenselast.paymethod_flag & 512) <> 0)  OR 
		   ((expenselast.paymethod_flag & 1024) <> 0) OR 
		   ((expenselast.paymethod_flag & 2048) <> 0) 
		   )  
			AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
				OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),' ','') = ''
				OR DATALENGTH(ISNULL(ISNULL(expenselast.extracode,registrypaymethod.extracode),'')) > @lencodicecontabilitaspeciale)
		)
END


-- CONTROLLO N. 15  Presenza di variazioni dati non trasmesse sullo stesso incasso
INSERT INTO #error (message)
SELECT 'Il movimento di spesa ' + CONVERT(varchar(6),E.nmov) + '/' + CONVERT(varchar(4),E.ymov) +
' ha altre variazioni dati non trasmesse'
FROM expense E
JOIN expenselast EL
	ON E.idexp = EL.idexp
JOIN expensevar V
	ON EL.idexp = V.idexp
WHERE V.autokind = 22 
AND EXISTS (SELECT * FROM expensevar 
			 WHERE expensevar.idexp = V.idexp 
			   AND expensevar.nvar <> V.nvar 
			   AND expensevar.autokind = 22
			   AND expensevar.kpaymenttransmission is null)
AND V.kpaymenttransmission = @kpaymenttransmission

-- CONTROLLO N. 16  per BPS non sono ammessi annullamenti parziali
INSERT INTO #error (message)
SELECT ' Il mandato di pagamento n°' + CONVERT(varchar(6),EL.npay) + '/' + CONVERT(varchar(4),EL.ypay) +
' deve essere annullato totalmente '
FROM expense E
JOIN expenselastview EL
	ON E.idexp = EL.idexp
JOIN expensevar V
	ON EL.idexp = V.idexp
WHERE V.autokind IN (10,11) 
AND EXISTS (SELECT * FROM expenselastview  EL1
			 WHERE EL1.kpay = EL.kpay 
			   AND EL1.idexp <> EL.idexp 
			   AND ISNULL(EL1.curramount,0) >0 )
AND V.kpaymenttransmission = @kpaymenttransmission


IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
-- Attenzione! Altri controlli sono presenti nel testo della SP in quanto non era possibile calcolarli a priori
-- I controlli vengono riconosciuti in quanto il prefisso adoperato come linea di commento sarà CONTROLLO N. x.
-- Fine Sezione Controlli

DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

-- Tabella delle variazioni pagamenti annullati o variati
CREATE TABLE #paymentvar
(
	idexp int,
	idpay int,
	amount decimal(19,2),
	autokind int,
	kpay int,
	totalann char(1),
	opkind varchar(20)
)

--- 10 VARIAZIONI DI ANNULLAMENTO PARZIALE - NON CONSENTITO 
--- 11 VARIAZIONI DI ANNULLAMENTO TOTALE
--- 22 VARIAZIONI DATI
INSERT INTO #paymentvar
(
	idexp, idpay, amount, autokind, kpay, totalann
)
SELECT
	s.idexp, el.idpay, v.amount, v.autokind, d.kpay,
	CASE v.autokind WHEN 11 THEN 'S' ELSE 'N' END
FROM expensevar v
JOIN expense s
	ON v.idexp = s.idexp
JOIN expenselast el
	ON S.idexp = el.idexp
JOIN payment d
	ON d.kpay = el.kpay
JOIN paymenttransmission t
	ON t.kpaymenttransmission = d.kpaymenttransmission
JOIN paymenttransmission tv
	ON tv.kpaymenttransmission = v.kpaymenttransmission
WHERE v.kpaymenttransmission = @kpaymenttransmission


-- Tabella dei pagamenti
CREATE TABLE #payment
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	kpay int,
	idexp int,
	ymov int, 
	nmov int, 
	nphase tinyint, 
	phase varchar(50),
	curramount decimal(19,2),
	saldo decimal(19,2),
	exp_curramount decimal(19,2),
	originalamount decimal(19,2),
	flagcr char(1),
	idreg int,
	expense_adate datetime,
	payment_adate datetime,
	transmissiondate datetime,
	idpay int,
	idpaydisposition int,
	iddetail int,
	idpaymethodTRS varchar(10),
	ABI varchar(5),
	CAB varchar(5),
	cc varchar(25), -- Viene impostato a 25 in quanto gli utenti possono adoperare un C/C che eccede tale lunghezza
	cin_iban varchar(2),
	cin char(1),
	codice_paese varchar(2),
	bank varchar(150),
	iban varchar(50),
	biccode varchar(20), 
	id_end_to_end varchar(35),
	code varchar(4),
	proprietary varchar(35),
	title_ben varchar(100),
	address_ben varchar(100),
	cap_ben varchar(16),
	location_ben varchar(116),
	province_ben varchar(2),
	iso_code_ben varchar(2),
	pi_ben varchar(35),
	cf_ben varchar(16),
	stamphandling varchar(50),
	stamp_charge char(1),
	exemption_stamp_motive varchar(20),
	destinazione varchar(20),
	tipo_contabilita_ente_ricevente varchar(20),
	girofondo char(1),
	deny_bank_details char(1),
	extracode varchar(7),
	paymentdescr varchar(370),
	txt varchar(200), 
	expenselast_paymentdescr varchar(150),
	fulfilled char(1),
	chargehandling varchar(50),
	exemption_charge_payment_kind varchar(100),
	exemption_charge_motive varchar(100),
	uncharged char(1),
	iddeputy int,
	refexternaldoc varchar(50), -- S/N
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
	cigcodemandate varchar(10),
	autokind int,
	totalann char(1),
	opkind varchar(20)
)

-- Tabella per il delegato
CREATE TABLE #deputy
(
	iddeputy int,
	title_deputy varchar(150),
	address_deputy varchar(100),
	cap_deputy varchar(16),
	location_deputy varchar(116),
	province_deputy varchar(2),
	nation_deputy varchar(2), -- sigla ISO IT/FR/....
	p_iva_deputy varchar(35), 
	cf_deputy varchar(35)
)

-- Tabella delle trattenute
CREATE TABLE #tax
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
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
	autokind varchar(5),
	flagtotannullment char(1)
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
	idpay int,
	idexp int,
	idinc int,
	ymov_income int,
	nmov_income int,
	ypro int,
	npro int,
	nproformatted varchar(7),
	yproceedstransmission int,
	amount decimal(19,2),
	idpro int,
	idreg int,
	autokind varchar(5),
	flagtotannullment char(1)
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


-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	idpay int,
	progressive int,
	sortcode varchar(30),
	sorting varchar(200),
	amount decimal(19,2),
	idexp int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15), 
	cupcodeexpense varchar(15),
	opkind varchar(20)
)


-- Tabella delle informazioni aggiuntive richieste dall'Ente
CREATE TABLE #note
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	idpay int,
	progressive int,
	testo varchar(500)
)


-- Inserimento dei movimenti di spesa presenti nella distinta di trasmissione
INSERT INTO #payment
(
	ypaymenttransmission, npaymenttransmission,kpay, ydoc, ndoc, idexp, 
	ymov, nmov, nphase, phase,
	flagcr, curramount,  
    idreg, expense_adate, payment_adate, transmissiondate, 	
    stamphandling,stamp_charge, exemption_stamp_motive, 
    destinazione, tipo_contabilita_ente_ricevente,
	idpaymethodTRS, ABI, CAB, cc, cin_iban, cin, codice_paese, bank, iban, biccode, id_end_to_end , 
	code, proprietary,
	title_ben, cf_ben, pi_ben , 
	paymentdescr, expenselast_paymentdescr, fulfilled, uncharged,girofondo,deny_bank_details,
	extracode, iddeputy, refexternaldoc, nbill, idpay, 
    idpaydisposition, iddetail,codeupb, upbtitle,
	codefin, fintitle, 
	nlevel,finlevel,
    cupcodefin,cupcodeupb,cupcodeexpense, cigcodeexpense, txt ,
	chargehandling,
	exemption_charge_payment_kind,
	exemption_charge_motive
)
SELECT t.ypaymenttransmission, t.npaymenttransmission,d.kpay, d.ypay, d.npay, s.idexp,  
	s.ymov, s.nmov, s.nphase, eph.description, 
	CASE
		WHEN ((i.flag&1)=0) THEN 'C'
		WHEN ((i.flag&1)=1) THEN 'R'
	END, 
	i.curramount,
	s.idreg, s.adate, d.adate, t.transmissiondate, 
	tb.description, 
	CASE 
		WHEN (tb.flag&0) <> 0 THEN 'N'
		ELSE 'S'
	END, --esenzione bollo
	ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
	CASE
		WHEN ((el.paymethod_flag & 256) <> 0) THEN 'LIBERA' -- (girofondi ordinari TABELLA A)
		WHEN ((el.paymethod_flag & 512) <> 0) THEN 'VINCOLATA' --(girofondi vincolati TABELLA A)
		WHEN ((el.paymethod_flag & 1024) <> 0) THEN 'LIBERA' --(girofondi ordinari TABELLA B) 
		WHEN ((el.paymethod_flag & 2048) <> 0) THEN 'VINCOLATA' --(girofondi vincolati TABELLA B) 
		ELSE 'LIBERA'
	END, -- informazione destinazione (LIBERA/VINCOLATA) obbligatoria perchè l'Ente è in regime TU
	--CASE
	--	WHEN (((el.paymethod_flag & 64) = 0) AND ((el.paymethod_flag & 256) = 0) AND ((el.paymethod_flag & 512) = 0)  AND ((el.paymethod_flag & 1024) = 0) AND ((el.paymethod_flag & 2048) = 0)) THEN NULL
	--	WHEN (((el.paymethod_flag & 64) <> 0) OR ((el.paymethod_flag & 256) <> 0) OR ((el.paymethod_flag & 512) <> 0)  OR ((el.paymethod_flag & 1024) <> 0) OR ((el.paymethod_flag & 2048) <> 0)) 
	--		 AND ((el.paymethod_flag & 4096) = 0) THEN 'INFRUTTIFERA'  
	--	WHEN (((el.paymethod_flag & 64) <> 0) OR ((el.paymethod_flag & 256) <> 0) OR ((el.paymethod_flag & 512) <> 0)  OR ((el.paymethod_flag & 1024) <> 0) OR ((el.paymethod_flag & 2048) <> 0)) 
	--		 AND ((el.paymethod_flag & 4096)  <> 0) THEN 'FRUTTIFERA'  
	--END, -- informazioni obbligatorie solo per i girofondi in BI
	CASE
		WHEN ((el.paymethod_flag & 4096) = 0) THEN 'INFRUTTIFERA'  
		WHEN ((el.paymethod_flag & 4096)  <> 0) THEN 'FRUTTIFERA'  
		ELSE NULL
	END, -- informazioni obbligatorie solo per i girofondi in BI
	LTRIM(RTRIM(m.methodbankcode)),
	CASE
		WHEN DATALENGTH(ISNULL(el.idbank,'')) <= @len_ABI
		THEN  ISNULL(el.idbank,'')
		ELSE SUBSTRING(el.idbank,1,@len_ABI)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(el.idcab,'')) <= @len_CAB
		THEN   ISNULL(el.idcab,'')
		ELSE SUBSTRING(el.idcab,1,@len_CAB)
	END,
	ISNULL(el.cc,''),
	substring(el.iban,3,2),
	CASE
		WHEN DATALENGTH(ISNULL(el.cin,'')) <= @len_cin
		THEN ISNULL(el.cin,'')  
		ELSE SUBSTRING(el.cin,1,@len_cin)
	END,
	substring(el.iban,1,2),
	substring(bank.description,1,@len_bank),
	ISNULL(el.iban,''),
	ISNULL(el.biccode,''),
	null,
	null,
	null,
	ISNULL(c.title,''), 
	CASE
		WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL
		THEN c.cf 
		WHEN ctc.flaghuman = 'S' AND c.cf IS NULL
		THEN SPACE(@len_cf)
		ELSE SPACE(@len_cf)
	END,
	CASE
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
			AND DATALENGTH(c.p_iva) <= @len_pi
		THEN ISNULL(c.p_iva,'')  
		WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
			AND DATALENGTH(c.p_iva) > @len_pi
		THEN SUBSTRING(c.p_iva, 1, @len_pi)
		ELSE SPACE(@len_pi)
	END ,
	---- paymentdescr:
	ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,''),
	el.paymentdescr,
	CASE
		WHEN (( el.flag & 1)<>0) then 'S' --fulfilled
		ELSE 'N'
	END, 
	CASE
		WHEN (( el.flag & 8)<>0) then 'S' --uncharged
		ELSE 'N'
	END, 
	CASE
		WHEN
		(
		   ((el.paymethod_flag & 64) <> 0) OR
		   ((el.paymethod_flag & 256) <> 0) OR
		   ((el.paymethod_flag & 512) <> 0)  OR 
		   ((el.paymethod_flag & 1024) <> 0) OR 
		   ((el.paymethod_flag & 2048) <> 0) 
		   )   THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN (( el.paymethod_flag & 8)<>0) then 'S' --deny_bank_details
		ELSE 'N'
	END,
	CASE
	WHEN DATALENGTH(ISNULL(el.extracode,ISNULL(mcd.extracode,''))) <= @lencodicecontabilitaspeciale
	THEN SUBSTRING(REPLICATE('0',@lencodicecontabilitaspeciale),1,@lencodicecontabilitaspeciale - DATALENGTH(ISNULL(el.extracode,ISNULL(mcd.extracode,'')))) + ISNULL(el.extracode,ISNULL(mcd.extracode,''))
	ELSE SUBSTRING(ISNULL(el.extracode,ISNULL(mcd.extracode,'')),1,@lencodicecontabilitaspeciale)
	END	,
	CASE
		WHEN m.allowdeputy = 'S' THEN el.iddeputy 
		ELSE NULL
	END,
	ISNULL(el.refexternaldoc,''),
	CONVERT(varchar(7),el.nbill),
	el.idpay, --6 
	null,0,
	upb.codeupb, upb.title,
	fin.codefin, fin.title, 
	fin.nlevel,finlevel.description,
	ltrim(rtrim(finlast.cupcode))  ,
	ltrim(rtrim(u.cupcode)),
	ltrim(rtrim(RegPhase.cupcode)),
	ltrim(rtrim(RegPhase.cigcode)), 
	ltrim(rtrim(substring(s.txt, 1, 200))),
	ISNULL(chargehandling.handlingbankcode,@handlingbankcode_default),
	ISNULL(chargehandling.payment_kind, @payment_kind_default),
	ISNULL(chargehandling.motive,@motive_default)
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
LEFT OUTER JOIN paymethod m
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
LEFT OUTER JOIN chargehandling 
	ON el.idchargehandling = chargehandling.idchargehandling
LEFT OUTER JOIN fin f
	ON d.idfin = f.idfin
JOIN upb u
	ON u.idupb = y.idupb
JOIN fin f1
	ON f1.idfin = y.idfin
JOIN finlast 
	ON finlast.idfin = f1.idfin
WHERE d.kpay IN (SELECT kpay FROM #paymentvar) -- prendo i mandati variati considerati nella presente distinta


declare @fasecontrattopassivo int
declare @csa_flagtransmissionlinking char(1)
select  @fasecontrattopassivo = expensephase, 
		@csa_flagtransmissionlinking = ISNULL(csa_flagtransmissionlinking,'S')  
from config where ayear=@y

-- Valorizza codice cup da eventuali -----
-- contabilizzazioni di dettagli ordine --
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX(ltrim(rtrim(cupcode )))
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
	   (SELECT MAX (ltrim(rtrim(mandate.cigcode )))
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

UPDATE #payment SET  paymentdescr = (SELECT
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

UPDATE #payment SET  idpaymethodTRS = '13' WHERE idpaydisposition IS NOT NULL

----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
-- I mandati a singola posta annullati (consideriamo i raggruppamenti dei movimenti bancari) si considerano annullati totalmente
UPDATE #paymentvar SET totalann = 'S' 
WHERE #paymentvar.autokind = 10
	AND ((SELECT COUNT(idpay) FROM payment_bank WHERE payment_bank.kpay = #paymentvar.kpay) = 1)
	AND ((SELECT COUNT(DISTINCT idexp) FROM #payment
						 WHERE  #payment.idexp = #paymentvar.idexp
						 AND ISNULL(#payment.curramount,0) = 0 
						 AND #payment.idpaydisposition IS NULL) = 1
	OR (SELECT COUNT(DISTINCT idexp) FROM #payment
						 WHERE  #payment.idexp = #paymentvar.idexp
						 AND ISNULL(#payment.exp_curramount,0) = 0 
						 AND #payment.idpaydisposition IS NOT NULL) = 1
						 )

UPDATE #payment 
SET autokind = #paymentvar.autokind,
	totalann = #paymentvar.totalann,
	opkind   = CASE
					#paymentvar.totalann
					WHEN 'S' THEN 'ANNULLO'
					ELSE 'VARIAZIONE'
			   END 
FROM #paymentvar
WHERE #payment.kpay = #paymentvar.kpay

-- Calcoliamo l'importo originale dei sub annullati come : curramount + le var inserite nella distinta in oggetto.				
UPDATE #payment SET originalamount = isnull(curramount,0) 
									- ISNULL((select sum(expensevar.amount)  -- Le var. sono negative, quindi col meno d'avanti, cambio il segno.
									FROM expensevar
									join paymenttransmission 
										ON expensevar.kpaymenttransmission = paymenttransmission.kpaymenttransmission
									Where paymenttransmission.ypaymenttransmission = @y
										and paymenttransmission.npaymenttransmission = @n
										and expensevar.idexp = #payment.idexp
										and #payment.opkind = 'ANNULLO'),0)
 
--select * from #paymentvar
--select * from #payment
-- Inizio Formattazione del C/C	
UPDATE #payment
SET cc = 
	UPPER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ',''))

UPDATE #payment SET cc = REPLICATE('0',@len_cc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
WHERE LTRIM(RTRIM(ISNULL(cc,''))) <> ''
-- Fine Formattazione del C/C


-- Valorizzo l'identificativo End to End per i Bonifici SEPA
UPDATE #payment SET id_end_to_end =SUBSTRING(CONVERT(VARCHAR(4),ydoc) + '_'+ CONVERT(VARCHAR(4),ndoc) +'_'+ CONVERT(VARCHAR(4),idpay),1,35)
WHERE ((idpaymethodTRS = '03') AND (fulfilled = 'N')) 


DECLARE @maxincomephase char(1)
SELECT @maxincomephase = MAX(nphase) FROM incomephase

-- CONTROLLO N. 13 Controllo che i movimenti di entrata associati ai movimenti di spesa che stiamo trasmettendo siano stati inseriti
-- in una distinta di trasmissione, prendendo solo quelli che non devono essere annullati
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
	AND ((I.autokind = 6) /* <--Recupero*/	OR (I.autokind = 14) /*<--automatismo generico*/OR (I.autokind = 4 AND I.idreg = P.idreg)/*<--Ritenuta*/
	OR (I.autokind in (20,21,30,31) AND I.idreg = P.idreg AND @csa_flagtransmissionlinking = 'S'))
	AND IT.ayear = @y
	AND T.yproceedstransmission IS NULL
	AND NOT EXISTS (SELECT * FROM #paymentvar PV WHERE PV.idexp = P.idexp AND (PV.totalann = 'S') )


IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
 

-- Inserimento delle trattenute (vengono inseriti recuperi e ritenute, quest'ultime solo dipendenti)
INSERT INTO #tax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, idreg, autokind,
	ymov_income, nmov_income, idpro, 
	flagtotannullment  
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ey.amount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro,
	CASE 
		WHEN EXISTS (SELECT * FROM #paymentvar PV WHERE PV.idexp = P.idexp AND (PV.totalann = 'S')  ) 
		THEN 'S'
		ELSE 'N'
	END 
FROM #payment p
JOIN income e
	ON e.idpayment = p.idexp	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN incomeyear ey
	ON ie.idinc = ey.idinc
	AND  ie.ayear = ey.ayear
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN proceedstransmission
	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
AND (p.idpaydisposition IS   NULL AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 (p.girofondo <> 'S')
	 )
	AND ((e.autokind = 6) -- Recupero
	OR (e.autokind = 14) --automatismo generico
	OR (e.autokind = 4 AND e.idreg = p.idreg) -- Ritenuta
	OR (e.autokind in (20,21,30,31) AND e.idreg = p.idreg AND @csa_flagtransmissionlinking = 'S')) -- AUTOMATISMI DA CSA
	AND ie.ayear = @y
UPDATE #tax SET curramount = curramount + ISNULL((select SUM(amount) FROM incomevar WHERE incomevar.idinc = #tax.idinc AND incomevar.autokind NOT IN (10,11) ),0)


-- L'incasso reale sarà suddiviso in due tranches, uno di importo parti al sospeso e non collegato alla spesa
-- l'altro sarà un incasso virtuale  collegato alla spesa (in modo da ottenere complessivamente saldo zero ) e con idpro
-- fittizio pari a 2 (obblighiamo a fare le reversali singole in tali casi)
INSERT INTO #pendingincome
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, curramount_expense, idreg, autokind,
	ymov_income, nmov_income, idpro
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, p.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro
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
AND (p.idpaydisposition IS  NULL AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 (p.girofondo <> 'S') 
	 ) 	
AND (e.autokind = 28 AND e.idreg = p.idreg) -- Incasso da regolarizzare con spesa accessoria e sospeso pari al netto
AND ie.ayear = @y
AND (il.flag&32 <> 0)
AND NOT EXISTS (SELECT * FROM #paymentvar PV WHERE PV.idexp = P.idexp AND 
	(PV.totalann = 'S')  )

-- Leggo configurazione dell'applicazione dei contributi 
DECLARE @admintaxkind int
SELECT  @admintaxkind = (automanagekind & 0xf) FROM config WHERE ayear = @y
 
-- Inserimento delle trattenute (vengono inseriti i contributi c/amministrazione)
INSERT INTO #admintax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,   idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, amount, idreg, autokind,
	ymov_income, nmov_income, idpro,
	flagtotannullment  
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	iy.amount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro,
	CASE 
		WHEN EXISTS (SELECT * FROM #paymentvar PV WHERE PV.idexp = P.idexp AND (PV.totalann = 'S')  ) 
		THEN 'S'
		ELSE 'N'
	END 
FROM #payment p
JOIN expense s
	ON s.idexp = p.idexp
JOIN income e
	ON e.idpayment = s.idpayment	
JOIN incomelast il
	ON e.idinc = il.idinc
JOIN incometotal ie
	ON e.idinc = ie.idinc
JOIN incomeyear iy
	ON iy.idinc = ie.idinc
	AND iy.ayear = ie.ayear
JOIN proceeds di
	ON di.kpro = il.kpro
JOIN proceedstransmission
	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
AND (p.idpaydisposition IS   NULL AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 (p.girofondo <> 'S')  
	 )
	AND e.autokind = 4 -- Contributo
	AND s.autokind = 4 
	AND s.autocode  = e.autocode
	AND p.idreg = e.idreg
	AND ie.ayear = @y
	AND @admintaxkind = 2 -- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro

update #payment set saldo = originalamount - isnull((select sum(amount) from #admintax where #admintax.idexp = #payment.idexp),0) WHERE #payment.opkind = 'ANNULLO'
update #payment set saldo = curramount - isnull((select sum(amount) from #admintax where #admintax.idexp = #payment.idexp),0) WHERE #payment.opkind = 'VARIAZIONE'
update #payment set saldo = saldo - isnull((select sum(curramount)  from #tax where #tax.idexp = #payment.idexp),0)
update #payment set idpaymethodTRS = '14' /*compensazione*/ where saldo = 0 -- pagamenti di pari importo con incassi

-- Riempimento della tabella del delegato
INSERT INTO #deputy (iddeputy, title_deputy, cf_deputy)
SELECT
	DISTINCT P.iddeputy,
	ISNULL(registry.title,''),
	ISNULL(registry.cf,SPACE(@len_cf))
FROM #payment P
JOIN registry
	ON P.iddeputy = registry.idreg
	

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
	cap varchar(16),
	province varchar(2),
	idnation int,
	nation varchar(65),
	iso_code varchar(10),
	idpaydisposition int,
	iddetail int
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
		AND 
		 (	(idreg IN (SELECT  idreg FROM #payment))
			OR
			(idreg IN (SELECT  iddeputy FROM #payment))
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

-- Legge i dati dell'indirizzo dalla tabella paydisposition
INSERT INTO #address
(
	idaddresskind,
	address,
	location,
	cap,
	province,
	nation,
	idpaydisposition,
	iddetail,
	iso_code
)
SELECT
	@stand,
	address,
	ISNULL(paydispositiondetail.location,''),
	paydispositiondetail.cap,
	paydispositiondetail.province,
	'Italia',
	paydisposition.idpaydisposition,
	paydispositiondetail.iddetail,
	'IT'
FROM paydisposition 
JOIN paydispositiondetail
	ON paydisposition.idpaydisposition = paydispositiondetail.idpaydisposition
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = paydispositiondetail.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = paydispositiondetail.idnation
WHERE  paydisposition.idpaydisposition in (select  idpaydisposition from #payment
				WHERE  idpaydisposition is not null)
				
-- CONTROLLO N. 10 Ogni beneficiario deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #payment WHERE idreg NOT IN
		(SELECT  idreg FROM #address ind)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il beneficiario ' + #payment.title_ben +
	+ ' non ha un indirizzo valido associato '
	FROM #payment
	WHERE idreg NOT IN
		(SELECT  idreg FROM #address ind)
	)
END



-- CONTROLLO N. 11 Ogni delegato deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #deputy WHERE iddeputy NOT IN
		(SELECT  idreg FROM #address ind)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il delegato ' + #deputy.title_deputy +
	+ ' non ha un indirizzo valido associato '
	FROM #deputy
	WHERE iddeputy NOT IN
		(SELECT  idreg FROM #address ind)
	)
END

-- CONTROLLO N. 12 Ogni beneficiario di una disposizione di pagamento deve avere un indirizzo associato
IF EXISTS(
	(SELECT * FROM #payment WHERE idpaydisposition is not null AND 
		NOT EXISTS 
			(SELECT  * FROM #address ind
			  WHERE  ind.idpaydisposition = #payment.idpaydisposition AND
				 ind.iddetail = #payment.iddetail) ))
BEGIN
	INSERT INTO #error (message)
		(SELECT 'Il beneficiario ' + #payment.reg_title +
		+ ' non ha un indirizzo valido associato '
		FROM #payment
		WHERE idpaydisposition is not null AND NOT EXISTS 
			(SELECT  * FROM #address ind
			  WHERE  ind.idpaydisposition = #payment.idpaydisposition AND
				 ind.iddetail = #payment.iddetail 
				  )
		)
END

-- CONTROLLO N. 13 Ogni delegato estero deve avere una nazione associata
IF EXISTS(
	(SELECT * FROM #deputy WHERE iddeputy IN
		(SELECT  idreg FROM #address ind WHERE idnation IS NULL)))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il delegato ' + #deputy.title_deputy +
	+ ' non ha una nazione estera valida associata '
	FROM #deputy
	WHERE iddeputy IN
		(SELECT  idreg FROM #address ind WHERE idnation IS NULL)
	)
END
--select * from #address where idreg in (select iddeputy from #deputy)
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Aggiornamento dei dati inerenti l'indirizzo del beneficiario	
-- Unificazione descrizioni di pagamento per movimenti di spesa che sono stati accorpati
-- L'unificazione della descrizione è necessaria in quanto nella group by finale viene inserita anche la descrizione
UPDATE #payment
SET paymentdescr = 'ACCORPAMENTO PAGAMENTI' -- + SPACE(348) La formattazione l'ho postata alla fine, perchè deve scrivere anche il CUP e CIG, ponendoli come prima info del campo 'casuale pagamento'
WHERE
	(SELECT COUNT(*)
	FROM #payment p2
	WHERE p2.ypaymenttransmission = #payment.ypaymenttransmission
		AND p2.npaymenttransmission = #payment.npaymenttransmission
		AND p2.ydoc = #payment.ydoc
		AND p2.ndoc = #payment.ndoc
		AND p2.idpay = #payment.idpay) > 1
	AND 
		(SELECT COUNT(*)
		FROM #payment p2
		WHERE p2.ypaymenttransmission = #payment.ypaymenttransmission
			AND p2.npaymenttransmission = #payment.npaymenttransmission
			AND p2.ydoc = #payment.ydoc
			AND p2.ndoc = #payment.ndoc
			AND p2.idpay = #payment.idpay) <>
		(SELECT COUNT(*)
		FROM #payment p2
		WHERE p2.ypaymenttransmission = #payment.ypaymenttransmission
			AND p2.npaymenttransmission = #payment.npaymenttransmission
			AND p2.ydoc = #payment.ydoc
			AND p2.ndoc = #payment.ndoc
			AND p2.idpay = #payment.idpay
			AND p2.paymentdescr = #payment.paymentdescr)
UPDATE #payment
SET address_ben =
	(SELECT ISNULL(address,'')
	FROM #address
	WHERE #payment.idreg = #address.idreg),
cap_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @len_cap
		THEN ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #payment.idreg = #address.idreg),
location_ben =
	(SELECT  ISNULL(location,'')
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
	WHERE #payment.idreg = #address.idreg),
iso_code_ben = 
	(SELECT iso_code
	FROM #address
	WHERE #payment.idreg = #address.idreg
	)
 where #payment.idpaydisposition is null

-- Aggiornamento dati indirizzo delegato
UPDATE #deputy
SET address_deputy =
	(SELECT ISNULL(address,'')
	FROM #address
	WHERE #deputy.iddeputy = #address.idreg),
cap_deputy =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @len_cap
		THEN ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #deputy.iddeputy = #address.idreg),
location_deputy =
	(SELECT  ISNULL(location,'')
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
		

--- disposizioni di pagamento
UPDATE #payment
SET address_ben =
	(SELECT
		ISNULL(address,'')
	FROM #address
	WHERE #payment.idpaydisposition = #address.idpaydisposition AND
	      #payment.iddetail = #address.iddetail
		  ),
cap_ben =
	(SELECT
	CASE
		WHEN DATALENGTH(ISNULL(cap,'')) <= @len_cap
		THEN ISNULL(cap,'')
		ELSE SUBSTRING(cap,1,@len_cap)
	END
	FROM #address
	WHERE #payment.idpaydisposition = #address.idpaydisposition AND
	      #payment.iddetail = #address.iddetail
		 ),
location_ben =
	(SELECT
		ISNULL(location,'')
	FROM #address
	WHERE #payment.idpaydisposition = #address.idpaydisposition AND
	      #payment.iddetail = #address.iddetail
		  ),
province_ben = 
	(SELECT
		CASE
			WHEN DATALENGTH(ISNULL(province,'')) <= @len_province
			THEN ISNULL(province,'') + SUBSTRING(SPACE(@len_province),1,@len_province - DATALENGTH(ISNULL(province,'')))
			ELSE SUBSTRING(province,1,@len_province)
		END
	FROM #address
	WHERE #payment.idpaydisposition = #address.idpaydisposition AND
	      #payment.iddetail = #address.iddetail
		  ),
iso_code_ben = 
	(SELECT iso_code
	FROM #address
	WHERE #payment.idpaydisposition = #address.idpaydisposition AND
	      #payment.iddetail = #address.iddetail
	)
WHERE  #payment.idpaydisposition  is not null

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
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,
	idpay, sortcode, sorting, amount,idexp, cupcodefin, cupcodeupb, cupcodedetail, cupcodeexpense, progressive,opkind
)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc,
	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description,
	CASE
		WHEN #payment.iddetail = 0 THEN SUM(expensesorted.amount)
		ELSE SUM(expensesorted.amount) * (#payment.curramount/#payment.exp_curramount)
	END, 
	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1,#payment.opkind
FROM #payment
JOIN expensesorted
	ON #payment.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @classSIOPE  AND 
	NOT EXISTS (SELECT * FROM #paymentvar PV WHERE PV.idexp = #payment.idexp AND
	PV.totalann = 'S' ) 
GROUP BY #payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.ydoc,
	#payment.ndoc,
	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)),sorting.description,
	#payment.idexp, #payment.iddetail,#payment.originalamount,#payment.exp_curramount,
	#payment.cupcodeexpense, #payment.cupcodedetail,#payment.curramount,
	#payment.cupcodeupb, #payment.cupcodefin,#payment.opkind
	HAVING SUM(expensesorted.amount) <> 0

	--select * from #siope
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

--select * from #siope
INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay, testo)
SELECT  
ypaymenttransmission, 
npaymenttransmission, 
ydoc, 
ndoc,
idpay,
[dbo].getstringformatted_r(finlevel + ': ' + codefin + ' - ' + fintitle + ' ,UPB: ' + codeupb + ' - ' + upbtitle, 300)
FROM #payment
WHERE opkind <> 'ANNULLO'
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, 
		 ydoc, finlevel, codefin, fintitle, codeupb, upbtitle,opkind


-- RECORD FASE + MOVIMENTO
INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay, testo)
SELECT  
ypaymenttransmission, 
npaymenttransmission, 
ydoc, 
ndoc,
idpay,
--Informazione Ente ZINFENT
	[dbo].getstringformatted_r(phase + ' n.' + convert(varchar(10),nmov) + ' / ' + + convert(varchar(4),ymov) + ', Competenza/Residui: ' + flagcr , 300) 
FROM #payment
WHERE opkind <> 'ANNULLO'
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, 
		 ydoc,phase, ymov, nmov,flagcr,opkind

-- RECORD DESCRIZIONE CLASSIFICAZIONE SIOPE 
INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay, testo)
SELECT  
ypaymenttransmission, 
npaymenttransmission, 
ydoc, 
ndoc,
idpay,
--Informazione Ente ZINFENT
[dbo].getstringformatted_r('SIOPE: ' + sortcode + ' - ' + sorting + ', Importo: ' + convert(varchar(30), amount), 300) 
FROM #siope
GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, sortcode, sorting, amount,
		 ydoc,opkind
		 
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
	
DECLARE @total_payment decimal(19,2)	


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
INSERT INTO  #expensebill
(	ypaymenttransmission, npaymenttransmission, idexp,
	ydoc, ndoc, idpay, ybill,nbill, amount)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.idexp, 
	#payment.ydoc, #payment.ndoc,
	#payment.idpay, #payment.ydoc, expenselast.nbill,     
	CASE 
  		WHEN (#payment.opkind = 'VARIAZIONE') THEN  #payment.curramount
  		WHEN (#payment.opkind = 'ANNULLO') THEN  #payment.originalamount 				 
	END			 
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
DECLARE @codice_ente_BT  varchar(9)
SET @codice_ente_BT = @cod_department
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
	kind char(30), 
	-------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------INIZIO TIPO RIGA TESTATA--------------------------------------------------------
	--- contiene le informazioni relative all'intera distinta, come l'identificativo, l'esercizio ecc..----------------------------------
    --- KIND : TESTATA ------------------------------------------------------------------------------------------------------------------
    -------------------------------------------------------------------------------------------------------------------------------------

	codice_ABI_BT varchar(5),
	identificativo_flusso varchar(20),
	data_ora_creazione_flusso varchar(20),
	codice_ente varchar(16), -- partita iva o codice fiscale
	descrizione_ente varchar(150),
	codice_ente_BT varchar(20),
	riferimento_ente varchar(20),
	esercizio int,
	-------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA TESTATA-----------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA MANDATO----------------------------------------------------------
    --- contiene le informazioni relative all'intero mandato. L'identificativo è dato da ndoc (corrisponde a npay nella tabella payment)-- 
	--- KIND : MANDATO, TIPO RIGA PADRE: TESTATA, CHIAVE: ndoc----------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------

	ndoc int,
	tipo_operazione varchar(20),
	numero_mandato int,
	data_mandato varchar(20),
	importo_mandato decimal(19,2), -- attenzione deve essere al netto delle ritenute
	conto_evidenza varchar(10), -- mettere 1
	estremi_provvedimento_autorizzativo varchar(50),
	responsabile_provvedimento varchar(50),
	ufficio_responsabile varchar(50) ,
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA MANDATO------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA INFO_BENEFICIARIO------------------------------------------------ 
    --- contiene le informazioni relative alla riga di mandato (sub del mandato), che nella terminologia del tracciato BPS si chiama -----
    --  beneficiario. In questo tipo riga  ho inserito non solo le informazioni relative alla sezione info_beneficiario del tracciato XML
    --  ma ho aggiunto anche altre sezioni in corrispondenza uno a uno con la riga di mandato, come bollo, spese, delegato, ecc. ----------
	--  KIND : INFO_BENEFICIARIO,   TIPO RIGA PADRE: MANDATO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato), CHIAVE: idpay -------
	---------------------------------------------------------------------------------------------------------------------------------------

	----------------------------------------------------
	-----------------info beneficiario -----------------
	----------------------------------------------------
	idpay int,
	progressivo_beneficiario int,
	importo_beneficiario decimal(19,2),
	tipo_pagamento varchar(100),
	impignorabili char(1),
	frazionabile char(1),
	gestione_provvisoria char(1),
	data_esecuzione_pagamento datetime, 
	data_scadenza_pagamento datetime,
	destinazione varchar(20),
	numero_conto_banca_italia_ente_ricevente varchar(10),
	tipo_contabilita_ente_ricevente varchar(20),

	---------------------------------------------
	----------------- bollo ---------------------
	---------------------------------------------
	assoggettamento_bollo varchar(50),
	causale_esenzione_bollo varchar(20),
	---------------------------------------------
	----------------- spese ---------------------
	---------------------------------------------
	soggetto_destinatario_delle_spese varchar(30),
	natura_pagamento varchar(100),	
	causale_esenzione_spese varchar(100),
	---------------------------------------------
	----------------- beneficiario --------------
	---------------------------------------------
	anagrafica_beneficiario varchar(100),
	indirizzo_beneficiario varchar(100),
	cap_beneficiario varchar(16),
	localita_beneficiario varchar(116),
	provincia_beneficiario varchar(2),
	stato_beneficiario varchar(2),
	partita_iva_beneficiario varchar(20),
	codice_fiscale_beneficiario varchar(35),
	---------------------------------------------
	----------------- delegato ------------------
	---------------------------------------------
	anagrafica_delegato varchar(100),
	indirizzo_delegato varchar(100),
	cap_delegato varchar(16),
	localita_delegato varchar(116),
	provincia_delegato varchar(2),
	stato_delegato varchar(2),
	codice_fiscale_delegato varchar(35),
	---------------------------------------------
	----------------- creditore effettivo -------
	---------------------------------------------
	anagrafica_creditore_effettivo varchar(100),
	indirizzo_creditore_effettivo varchar(100),
	cap_creditore_effettivo varchar(16),
	localita_creditore_effettivo varchar(116),
	provincia_creditore_effettivo varchar(2),
	stato_creditore_effettivo varchar(2),
	partita_iva_creditore_effettivo varchar(35),
	codice_fiscale_creditore_effettivo varchar(35),
	---------------------------------------------
	----------------- piazzatura  ---------------
	---------------------------------------------
	abi_beneficiario varchar(5),
	cab_beneficiario varchar(5),
	numero_conto_corrente_beneficiario varchar(20),
	caratteri_controllo varchar(2),
	codice_cin char(1),
	codice_paese varchar(2),
	denominazione_banca_destinataria varchar(150),
	codice_swift varchar(20),
	----------------------------------------------
	----------------- sepa credit transfer -------
	----------------------------------------------
	iban varchar(50),
	bic varchar(20),
	identificativo_end_to_end varchar(35),
	----------------------------------------------- 
	------- identificativo_category_purpose ------- 
	----------------------------------------------- 
	code varchar(4),
	proprietary varchar(35),
	-----------------------------------------------
	-- codice versante per versamenti INPS ecc.. --
	-----------------------------------------------
	codice_versante varchar(20),
	causale varchar(400),
	-----------------------------------------------
	------------------ sospeso --------------------
	-----------------------------------------------
	numero_provvisorio int, 
	importo_provvisorio decimal(19,2),
	-----------------------------------------------
	---------- informazioni aggiuntive-------------
	-----------------------------------------------
	lingua varchar(10),
	riferimento_documento_esterno varchar(50),
	note varchar(400),

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA INFO_BENEFICIARIO--------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	----------------------------------------------------INIZIO TIPO RIGA CLASSIFICAZIONI ------------------------------------------------- 
    --- contiene le informazioni relative alle classificazioni SIOPE associate alla riga di mandato (sub del mandato), che nella ---------
    --  terminologia del tracciato BPS si chiama beneficiario. Infatti possono esserci delle righe di mandato multiclassificate ----------- 
    --  In questo tipo riga  ho inserito anche il codice CUP
	--  KIND : CLASSIFICAZIONI,   TIPO RIGA PADRE: INFO_BENEFICIARIO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato) e idpay ------
	--- CHIAVE: codice_cgu (codice SIOPE USCITE)-------------------------------------------------------------------------------------------
	---------------------------------------------------------------------------------------------------------------------------------------

	---------------------------------------------
	----------------- classificazioni -----------
	---------------------------------------------
	codice_cgu varchar(10),
	codice_cup  varchar(20),
	codice_cpv varchar(20),
	importo_siope decimal(19,2),
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA CLASSIFICAZIONI----------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	----------------------------------------------------INIZIO TIPO RIGA RITENUTE -------------------------------------------------------- 
    -- contiene le informazioni relative alle ritenute associate alla riga di mandato (sub del mandato), che nella -----------------------
    -- terminologia del tracciato BPS si chiama beneficiario. Infatti ogni riga di mandato può essere associata a più righe di reversale -
    -- (versanti di reversali nella terminologia BPS). Il progressivo_versante  è valorizzato con idpro della riga di reversale-----------
	-- KIND : RITENUTE,   TIPO RIGA PADRE: INFO_BENEFICIARIO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato) e idpay --------------
	-- CHIAVE: numero_reversale, progressivo_reversale -------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------------------------

	-----------------------------------------------
	------------------ ritenute--------------------
	-----------------------------------------------
	importo_ritenute decimal(19,2),
	numero_reversale int,
	progressivo_versante int,
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA RITENUTE-----------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	--------------------------------------------------------------------------------------------------------------------------------------
	--SEZIONI CHE AL MOMENTO DECIDIAMO DI NON COMPILARE E CHE ALL'OCCORRENZA POTRANNO ESSERE STRUTTURATE IN MODO PERSONALIZZATO ----------
	--------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------
	---- dati_a_disposizione_ente_beneficiario ----
	-----------------------------------------------
	dati_a_disposizione_ente_beneficiario varchar(400),
	-----------------------------------------------
	---- dati_a_disposizione_ente_mandato ---------
	-----------------------------------------------
	-----------------------------------------------
	---- dati_ente_testata ------------------------
	-----------------------------------------------
	ufficio varchar(400)
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
				   'mandati_'+ convert(varchar(4),@y) + '_' +convert(varchar(4),@n),
				   @data_ora_creazione_flusso,
				   @codice_ente,
				   @descrizione_ente,
				   @codice_ente_BT,
				   @riferimento_ente,
				   @y

INSERT INTO #trace(kind,
				   ndoc,
				   tipo_operazione,
				   numero_mandato,
				   data_mandato,
				   importo_mandato, -- attenzione deve essere al netto delle ritenute
				   conto_evidenza,  -- mettere 1
				   estremi_provvedimento_autorizzativo,
				   responsabile_provvedimento,
				   ufficio_responsabile,
				   ufficio)
SELECT 
				   'MANDATO',
				   ndoc, 
				   opkind,
				   ndoc,
				   CONVERT(VARCHAR(10),payment_adate,20),
				   CASE 
						WHEN (#payment.opkind = 'VARIAZIONE') THEN SUM(curramount)
						WHEN (#payment.opkind = 'ANNULLO' AND #payment.idpaydisposition IS NULL) THEN SUM(originalamount)
						WHEN (#payment.opkind = 'ANNULLO' AND #payment.idpaydisposition IS NOT NULL) THEN SUM(curramount)
				   END, 
				   ISNULL(@cc_vincolato,'0000001'),
				   null,
				   null,
				   null,
				   @CodiceStruttura
FROM #payment
GROUP BY #payment.ndoc,payment_adate,opkind, idpaydisposition 
ORDER BY  #payment.ndoc 

INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   progressivo_beneficiario,
				   importo_beneficiario,
				   tipo_pagamento,
				   impignorabili,
				   frazionabile,
				   gestione_provvisoria,
				   data_esecuzione_pagamento, 
				   data_scadenza_pagamento,
				   destinazione, -- libera vincolata
				   numero_conto_banca_italia_ente_ricevente,
				   tipo_contabilita_ente_ricevente,   -- fruttifera infruttifera
				   ---------------------------------------------
				   ----------------- beneficiario --------------
				   ---------------------------------------------
				   anagrafica_beneficiario,
				   indirizzo_beneficiario,
				   cap_beneficiario,
				   localita_beneficiario,
				   provincia_beneficiario,
				   stato_beneficiario,
				   partita_iva_beneficiario,
				   codice_fiscale_beneficiario,
				   ---------------------------------------------
				   ----------------- delegato ------------------
				   ---------------------------------------------
				   anagrafica_delegato,
				   indirizzo_delegato,
				   cap_delegato,
				   localita_delegato,
				   provincia_delegato,
				   stato_delegato,
				   codice_fiscale_delegato,
				   ---------------------------------------------
				   ----------------- creditore effettivo -------
				   ---------------------------------------------
				   anagrafica_creditore_effettivo,
				   indirizzo_creditore_effettivo,
				   cap_creditore_effettivo,
				   localita_creditore_effettivo,
				   provincia_creditore_effettivo,
				   stato_creditore_effettivo,
				   partita_iva_creditore_effettivo,
				   codice_fiscale_creditore_effettivo,
				   ---------------------------------------------
				   -------------------- bollo ------------------
				   ---------------------------------------------
				   assoggettamento_bollo,
				   causale_esenzione_bollo,
				   ---------------------------------------------
				   -------------------- spese ------------------
				   ---------------------------------------------
				   soggetto_destinatario_delle_spese,
				   natura_pagamento,
				   causale_esenzione_spese,
				   ---------------------------------------------
				   ----------------- piazzatura  ---------------
				   ---------------------------------------------
				   abi_beneficiario,
				   cab_beneficiario,
				   numero_conto_corrente_beneficiario,
				   caratteri_controllo,
				   codice_cin,
				   codice_paese,
				   denominazione_banca_destinataria,
				   ----------------------------------------------
				   ----------------- sepa credit transfer -------
				   ----------------------------------------------
				   iban,
				   bic,
				   identificativo_end_to_end,
								----------------------------------------------- 
								------- identificativo_category_purpose ------- 
								----------------------------------------------- 
								code,
								proprietary,
				   -----------------------------------------------
				   -- codice versante per versamenti INPS ecc.. --
				   -----------------------------------------------
				   codice_versante,
				   causale,
				   -----------------------------------------------
				   ------------------ sospeso --------------------
				   -----------------------------------------------
				   numero_provvisorio, 
				   importo_provvisorio,
				   -----------------------------------------------
				   ---------- informazioni aggiuntive-------------
				   -----------------------------------------------
				   lingua,
				   riferimento_documento_esterno,
				   note,
				   dati_a_disposizione_ente_beneficiario
				   )
SELECT 
				   'INFO_BENEFICIARIO',
				   ndoc,
				   idpay, 
				   idpay,
				   CASE 
  						WHEN  #payment.opkind  = 'VARIAZIONE' THEN SUM(#payment.curramount)
  						WHEN  (#payment.opkind = 'ANNULLO' AND #payment.idpaydisposition IS NULL)  THEN SUM(#payment.originalamount)
						WHEN  (#payment.opkind = 'ANNULLO' AND #payment.idpaydisposition IS NOT NULL)   THEN SUM(#payment.curramount)
  						ELSE NULL
  				   END,
				   CASE   
					   WHEN ((idpaymethodTRS = '01') AND (fulfilled = 'N')) THEN 'CASSA'
					   WHEN ((idpaymethodTRS = '02') AND (fulfilled = 'N')) THEN 'BONIFICO BANCARIO E POSTALE'
					   WHEN ((idpaymethodTRS = '03') AND (fulfilled = 'N')) THEN 'SEPA CREDIT TRANSFER'
					   WHEN ((idpaymethodTRS = '04') AND (fulfilled = 'N')) THEN 'ASSEGNO BANCARIO E POSTALE'
					   WHEN ((idpaymethodTRS = '05') AND (fulfilled = 'N')) THEN 'ASSEGNO CIRCOLARE'
					   WHEN ((idpaymethodTRS = '06') AND (fulfilled = 'N')) THEN 'ACCREDITO CONTO CORRENTE POSTALE'
					   WHEN ((idpaymethodTRS = '07') AND (fulfilled = 'N')) THEN 'ACCREDITO TESORERIA PROVINCIALE STATO PER TAB A' --   GIROFONDO + VALORIZZAZ CODICE CONTABILITA SPECIALE
					   WHEN ((idpaymethodTRS = '08') AND (fulfilled = 'N')) THEN 'ACCREDITO TESORERIA PROVINCIALE STATO PER TAB B' --   GIROFONDO + VALORIZZAZ CODICE CONTABILITA SPECIALE
					   WHEN (idpaymethodTRS = '09')  THEN 'F24EP' --(7)	 GIROFONDO + VALORIZZAZ CODICE CONTABILITA SPECIALE FISSO CON VALORE 1777
					   WHEN ((idpaymethodTRS = '10') AND (fulfilled = 'N')) THEN 'VAGLIA POSTALE'
					   WHEN ((idpaymethodTRS = '11') AND (fulfilled = 'N')) THEN 'VAGLIA TESORO'
					   WHEN ((idpaymethodTRS not in ('07','08') ) AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONE'
					   WHEN ((idpaymethodTRS = '07') AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONE ACCREDITO TESORERIA PROVINCIALE STATO PER TAB A'
					   WHEN ((idpaymethodTRS = '08') AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONE ACCREDITO TESORERIA PROVINCIALE STATO PER TAB B'
					   WHEN ((idpaymethodTRS = '12') AND (fulfilled = 'N')) THEN 'ADDEBITO PREAUTORIZZATO'
					   WHEN ((idpaymethodTRS = '13') AND (fulfilled = 'N')) THEN 'DISPOSIZIONE DOCUMENTO ESTERNO'
					   WHEN ((idpaymethodTRS = '14') AND (fulfilled = 'N')) THEN 'COMPENSAZIONE'
					   WHEN ((idpaymethodTRS IS NULL) AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONE'
				   END,
				   null,
				   null,
				   null,
				   null,
				   null,
				   destinazione, -- destinazione
				   CASE 
						WHEN (idpaymethodTRS = '09') THEN 1777 
						WHEN (idpaymethodTRS IN ('07','08')) THEN extracode
						ELSE null
				   END,
				   tipo_contabilita_ente_ricevente,   
				   SUBSTRING(title_ben,1,60), 
				   --Indirizzo Beneficiario
				   SUBSTRING(address_ben,1,30),
				   -- C.A.P. Beneficiario
				   cap_ben,
				   -- Località Beneficiario
				   SUBSTRING(location_ben,1,30),
				   -- Provincia Beneficiario
				   province_ben,
				   -- Stato_beneficiario
				   iso_code_ben,
				   pi_ben,
				   cf_ben, 
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03')  THEN  SUBSTRING(#deputy.title_deputy,1,60)
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03')   THEN SUBSTRING(#deputy.address_deputy,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03')   THEN #deputy.cap_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03') THEN  SUBSTRING(#deputy.location_deputy,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03') THEN  #deputy.province_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03') THEN  #deputy.nation_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(idpaymethodTRS, '01') <> '03') THEN  #deputy.cf_deputy
						ELSE NULL
				   END,
				   -----------------------------------------------------------
				   ---------------- CREDITORE EFFETTIVO ---------------------- 
				   -----------------------------------------------------------
				   CASE 
						WHEN (idpaymethodTRS = '03')	THEN SUBSTRING(#deputy.title_deputy,1,60)
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03')    THEN SUBSTRING(#deputy.address_deputy,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03')    THEN #deputy.cap_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03')	THEN   SUBSTRING(#deputy.location_deputy,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03')	THEN  #deputy.province_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03') THEN  #deputy.nation_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03') THEN  #deputy.p_iva_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (idpaymethodTRS = '03') THEN  #deputy.cf_deputy
						ELSE NULL
				   END,
				   stamphandling,
				   CASE   
					   WHEN (stamp_charge = 'S' ) THEN exemption_stamp_motive
					   ELSE null
  				   END,
  				   chargehandling,
				   exemption_charge_payment_kind,
				   exemption_charge_motive,
  				   -- PIAZZATURA --
  				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))   THEN  ABI
						ELSE NULL
				   END,
  				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))   THEN  CAB
						ELSE NULL
				   END,
  				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))  THEN  cc
						ELSE NULL
				   END, 
				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))  THEN  cin_iban
						ELSE NULL
				   END,
				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))   THEN  cin
						ELSE NULL
				   END,
				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))   THEN  codice_paese
						ELSE NULL
				   END,
  				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(idpaymethodTRS, '01') <> '03') AND (fulfilled = 'N'))   THEN  SUBSTRING(bank,1,50)
						ELSE NULL
				   END,
  				   -- SEPA CREDIT TRANSFER --
  				   CASE 
						WHEN ((idpaymethodTRS = '03') AND (fulfilled = 'N')) THEN  iban
						ELSE NULL
				   END,
				   CASE 
						WHEN ((idpaymethodTRS = '03') AND (fulfilled = 'N'))  THEN  biccode
						ELSE NULL
				   END,
				   CASE 
						WHEN ((idpaymethodTRS = '03') AND (fulfilled = 'N'))  THEN  id_end_to_end
						ELSE NULL
				   END,
				     CASE 
						WHEN ((idpaymethodTRS = '03') AND (fulfilled = 'N')) THEN  code
						ELSE NULL
				   END,
				   CASE 
						WHEN ((idpaymethodTRS = '03') AND (fulfilled = 'N')) THEN  proprietary
						ELSE NULL
				   END,
  				   -- CODICE INPS -- 
  				   null,
  				  SUBSTRING(paymentdescr,1,160), -- CAUSALE PAGAMENTO
  				   -- SOSPESO -- 
  				   nbill,
  				   CASE 
  						WHEN (nbill is not null AND #payment.opkind = 'VARIAZIONE') THEN SUM(#payment.curramount)
  						WHEN (nbill is not null AND #payment.opkind = 'ANNULLO') THEN SUM(#payment.originalamount)
  						ELSE NULL
  				   END,
  				   null,
				   -- Riferimento Documento Esterno  
				   RTRIM(refexternaldoc),
				   -- Informazioni Tesoriere
				   isnull(expenselast_paymentdescr,'') + ' '+ isnull(#payment.txt,''),
				   null 
FROM #payment
LEFT JOIN #deputy
	ON #payment.iddeputy = #deputy.iddeputy
	--WHERE opkind <> 'ANNULLO'
	GROUP BY
		#payment.ndoc, #payment.idpay,#payment.opkind, idpaymethodTRS, deny_bank_details,fulfilled, destinazione, tipo_contabilita_ente_ricevente,extracode,
		title_ben, address_ben, cap_ben, location_ben, province_ben,iso_code_ben,
		pi_ben, cf_ben,  #payment.idpaydisposition,   #payment.iddetail,
		#deputy.title_deputy,  #deputy.address_deputy,  #deputy.cap_deputy,#deputy.location_deputy,
		#deputy.province_deputy,#deputy.nation_deputy,  #deputy.cf_deputy,#deputy.p_iva_deputy,
		ABI, CAB, cc, cin_iban, cin,codice_paese, bank, iban,biccode,id_end_to_end,code, proprietary,
		paymentdescr,nbill, stamphandling, stamp_charge, exemption_stamp_motive, 
		refexternaldoc,expenselast_paymentdescr, #payment.txt, chargehandling,exemption_charge_payment_kind,
		exemption_charge_motive
	ORDER BY  #payment.ndoc, #payment.idpay	


INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   codice_cgu,
				   codice_cup,
				   codice_cpv,
				   importo_siope
				   )
SELECT 
				   'CLASSIFICAZIONI',
				   ndoc,
				   idpay, 
				   sortcode,
				   ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, cupcodefin))),
				   null,
				   SUM(#siope.amount)
FROM #siope
WHERE opkind <> 'ANNULLO'
GROUP BY  ndoc, idpay, sortcode, 
		 ydoc,  cupcodeexpense,  cupcodedetail, cupcodeupb,cupcodefin, progressive
ORDER BY  ndoc, idpay, sortcode	

-- RECORD FITTIZIO CLASSIFICAZIONI PER DOCUMENTI ANNULLATI
INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   codice_cgu,
				   codice_cup,
				   codice_cpv,
				   importo_siope
				   )
SELECT 
				   'CLASSIFICAZIONI',
				   #payment.ndoc,
				   #payment.idpay, 
				   '9999',
				   null,
				   null,
				   CASE 
					   WHEN #payment.idpaydisposition IS  NULL THEN SUM(#payment.originalamount) 
					   ELSE SUM(#payment.curramount) 
				   END
FROM #payment
WHERE #payment.opkind =  'ANNULLO'
GROUP BY  ndoc, idpay, #payment.opkind ,#payment.idpaydisposition
ORDER BY  #payment.ndoc, #payment.idpay	

INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   importo_ritenute,
				   numero_reversale,
				   progressivo_versante
				   )
SELECT 
				   'RITENUTE',
				   ndoc,
				   idpay, 
				   SUM(curramount),
				   npro,
				   idpro	   	
FROM #tax WHERE flagtotannullment = 'N'
GROUP BY  #tax.ndoc,#tax.idpay, #tax.npro, #tax.idpro		 
ORDER BY  #tax.ndoc,#tax.idpay, #tax.npro, #tax.idpro		 

-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI RELATIVI ALL'APPLICAZIONE DEI CONTRIBUTI (ES. IRAP)
-- CON CORRISPONDENTE MOVIMENTO DI ENTRATA SU PARTITA DI GIRO
INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   importo_ritenute,
				   numero_reversale,
				   progressivo_versante
				   )
SELECT 
				   'RITENUTE',
				   ndoc,
				   idpay, 
				   sum(amount),
				   npro,
				   idpro	   	
FROM #admintax WHERE flagtotannullment = 'N'
GROUP BY  #admintax.ndoc,#admintax.idpay, #admintax.npro, #admintax.idpro		 
ORDER BY  #admintax.ndoc,#admintax.idpay, #admintax.npro, #admintax.idpro

-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI ACCESSORI RELATIVI A INCASSI DA REGOLARIZZARE CON SOSPESO PARI ALLA DIFFERENZA TRA INCASSO REALE E SPESA
-- INSERISCO NEL RECORD RITENUTE IL CORRISPONDENTE MOVIMENTO DI ENTRATA VIRTUALE DI IMPORTO PARI ALLA SPESA
-- E IDPRO FITTIZIO PARI A 2 (SE L'ORIGINALE E' 1)
INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   importo_ritenute,
				   numero_reversale,
				   progressivo_versante
				   )
SELECT 
				   'RITENUTE',
				   ndoc,
				   idpay, 
				   sum(curramount_expense),
				   npro,
				   idpro + 1    	
FROM #pendingincome
GROUP BY  #pendingincome.ndoc,#pendingincome.idpay, #pendingincome.npro, #pendingincome.idpro		 
ORDER BY  #pendingincome.ndoc,#pendingincome.idpay, #pendingincome.npro, #pendingincome.idpro

INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,
				   importo_provvisorio,
				   numero_provvisorio
				   )
SELECT 
				   'SOSPESI',
				   ndoc,
				   idpay, 
				   amount,
				   nbill    	
FROM #expensebill
ORDER BY  #expensebill.ndoc, #expensebill.idpay, #expensebill.nbill

IF YEAR(@adate) <=2016
SELECT
	kind, 
	-------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------------INIZIO TIPO RIGA TESTATA--------------------------------------------------------
	--- contiene le informazioni relative all'intera distinta, come l'identificativo, l'esercizio ecc..----------------------------------
    --- KIND : TESTATA ------------------------------------------------------------------------------------------------------------------
    -------------------------------------------------------------------------------------------------------------------------------------

	codice_ABI_BT,
	identificativo_flusso,
	data_ora_creazione_flusso,
	codice_ente, -- partita iva o codice fiscale
	descrizione_ente,
	codice_ente_BT,
	riferimento_ente,
	esercizio,
	-------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA TESTATA-----------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA MANDATO----------------------------------------------------------
    --- contiene le informazioni relative all'intero mandato. L'identificativo è dato da ndoc (corrisponde a npay nella tabella payment)-- 
	--- KIND : MANDATO, TIPO RIGA PADRE: TESTATA, CHIAVE: ndoc----------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	ndoc,
	tipo_operazione,
	numero_mandato,
	data_mandato,
	importo_mandato, -- attenzione deve essere al netto delle ritenute
	conto_evidenza, -- mettere 1
	estremi_provvedimento_autorizzativo,
	responsabile_provvedimento,
	ufficio_responsabile,
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA MANDATO------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA INFO_BENEFICIARIO------------------------------------------------ 
    --- contiene le informazioni relative alla riga di mandato (sub del mandato), che nella terminologia del tracciato BPS si chiama -----
    --  beneficiario. In questo tipo riga  ho inserito non solo le informazioni relative alla sezione info_beneficiario del tracciato XML
    --  ma ho aggiunto anche altre sezioni in corrispondenza uno a uno con la riga di mandato, come bollo, spese, delegato, ecc. ----------
	--  KIND : INFO_BENEFICIARIO,   TIPO RIGA PADRE: MANDATO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato), CHIAVE: idpay -------
	---------------------------------------------------------------------------------------------------------------------------------------

	----------------------------------------------------
	-----------------info beneficiario -----------------
	----------------------------------------------------
	idpay,
	progressivo_beneficiario,
	importo_beneficiario,
	tipo_pagamento,
	impignorabili,
	frazionabile,
	gestione_provvisoria,
	data_esecuzione_pagamento, 
	data_scadenza_pagamento,
	destinazione,
	numero_conto_banca_italia_ente_ricevente,
	tipo_contabilita_ente_ricevente,

	---------------------------------------------
	----------------- bollo ---------------------
	---------------------------------------------
	assoggettamento_bollo,
	causale_esenzione_bollo,
	---------------------------------------------
	----------------- spese ---------------------
	---------------------------------------------
	soggetto_destinatario_delle_spese,
	natura_pagamento,	
	causale_esenzione_spese,
	---------------------------------------------
	----------------- beneficiario --------------
	---------------------------------------------
	anagrafica_beneficiario,
	indirizzo_beneficiario,
	cap_beneficiario,
	localita_beneficiario,
	provincia_beneficiario,
	stato_beneficiario,
	partita_iva_beneficiario,
	codice_fiscale_beneficiario,
	---------------------------------------------
	----------------- delegato ------------------
	---------------------------------------------
	anagrafica_delegato,
	indirizzo_delegato,
	cap_delegato,
	localita_delegato,
	provincia_delegato,
	stato_delegato,
	codice_fiscale_delegato,
	---------------------------------------------
	----------------- creditore effettivo -------
	---------------------------------------------
	anagrafica_creditore_effettivo,
	indirizzo_creditore_effettivo,
	cap_creditore_effettivo,
	localita_creditore_effettivo,
	provincia_creditore_effettivo,
	stato_creditore_effettivo,
	partita_iva_creditore_effettivo,
	codice_fiscale_creditore_effettivo,
	---------------------------------------------
	----------------- piazzatura  ---------------
	---------------------------------------------
	abi_beneficiario,
	cab_beneficiario,
	numero_conto_corrente_beneficiario,
	caratteri_controllo,
	codice_cin,
	codice_paese,
	denominazione_banca_destinataria,
	codice_swift,
	----------------------------------------------
	----------------- sepa credit transfer -------
	----------------------------------------------
	iban,
	bic,
	identificativo_end_to_end,
	----------------------------------------------- 
	------- identificativo_category_purpose ------- 
	----------------------------------------------- 
	code,
	proprietary,
	-----------------------------------------------
	-- codice versante per versamenti INPS ecc.. --
	-----------------------------------------------
	codice_versante,
	causale,
	-----------------------------------------------
	------------------ sospeso --------------------
	-----------------------------------------------
	numero_provvisorio, 
	importo_provvisorio,
	-----------------------------------------------
	---------- informazioni aggiuntive-------------
	-----------------------------------------------
	lingua,
	riferimento_documento_esterno,
	note,

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA INFO_BENEFICIARIO--------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	----------------------------------------------------INIZIO TIPO RIGA CLASSIFICAZIONI ------------------------------------------------- 
    --- contiene le informazioni relative alle classificazioni SIOPE associate alla riga di mandato (sub del mandato), che nella ---------
    --  terminologia del tracciato BPS si chiama beneficiario. Infatti possono esserci delle righe di mandato multiclassificate ----------- 
    --  In questo tipo riga  ho inserito anche il codice CUP
	--  KIND : CLASSIFICAZIONI,   TIPO RIGA PADRE: INFO_BENEFICIARIO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato) e idpay ------
	--- CHIAVE: codice_cgu (codice SIOPE USCITE)-------------------------------------------------------------------------------------------
	---------------------------------------------------------------------------------------------------------------------------------------

	---------------------------------------------
	----------------- classificazioni -----------
	---------------------------------------------
	codice_cgu,
	codice_cup,
	codice_cpv,
	importo_siope,
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA CLASSIFICAZIONI----------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	----------------------------------------------------INIZIO TIPO RIGA RITENUTE -------------------------------------------------------- 
    -- contiene le informazioni relative alle ritenute associate alla riga di mandato (sub del mandato), che nella -----------------------
    -- terminologia del tracciato BPS si chiama beneficiario. Infatti ogni riga di mandato può essere associata a più righe di reversale -
    -- (versanti di reversali nella terminologia BPS). Il progressivo_versante  è valorizzato con idpro della riga di reversale-----------
	-- KIND : RITENUTE,   TIPO RIGA PADRE: INFO_BENEFICIARIO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato) e idpay --------------
	-- CHIAVE: numero_reversale, progressivo_reversale -------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------------------------

	-----------------------------------------------
	------------------ ritenute--------------------
	-----------------------------------------------
	importo_ritenute,
	numero_reversale,
	progressivo_versante,
	
	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA RITENUTE-----------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------
	
	--------------------------------------------------------------------------------------------------------------------------------------
	--SEZIONI CHE AL MOMENTO DECIDIAMO DI NON COMPILARE E CHE ALL'OCCORRENZA POTRANNO ESSERE STRUTTURATE IN MODO PERSONALIZZATO ----------
	--------------------------------------------------------------------------------------------------------------------------------------
	-----------------------------------------------
	---- dati_a_disposizione_ente_beneficiario ----
	-----------------------------------------------
	dati_a_disposizione_ente_beneficiario,
	-----------------------------------------------
	---- dati_a_disposizione_ente_mandato ---------
	-----------------------------------------------
	-----------------------------------------------
	---- dati_ente_testata ------------------------
	-----------------------------------------------
	ufficio as struttura  
	FROM #trace 
ELSE
SELECT * FROM #trace 
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

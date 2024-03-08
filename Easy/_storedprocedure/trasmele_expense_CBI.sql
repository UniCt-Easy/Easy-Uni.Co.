
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


 --setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_cbi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_cbi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE        PROCEDURE [trasmele_expense_cbi]
(
	@y int,
	@n int
)
AS BEGIN
-- setuser'amministrazione'
--[trasmele_expense_cbi] 2023, 305
-------------------------------------------------------------------------------
---  STORED PROCEDURE PER LA TRASMISSIONE DEI MANDATI SECONDO TRACCIATO CBI ---
-------------------------------------------------------------------------------
DECLARE @maxincomephase char(1)
SELECT @maxincomephase = MAX(nphase) FROM incomephase


declare @fasecontrattopassivo int
select @fasecontrattopassivo = expensephase from config where ayear=@y

DECLARE @len_numericdata int
SET @len_numericdata = 7

DECLARE @len_codentebt INT
SET @len_codentebt = 12

DECLARE @lencodicecontabilitaspeciale int
SET @lencodicecontabilitaspeciale = 7	

DECLARE @len_cap int
SET @len_cap = 16

DECLARE @len_province int
SET @len_province = 2

DECLARE @len_cf int
SET @len_cf = 35

DECLARE @len_pi int
SET @len_pi = 35

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

SELECT @idtreasurer = idtreasurer, @kpaymenttransmission = kpaymenttransmission FROM paymenttransmission
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n

DECLARE @len_desc_dept int
SET @len_desc_dept = 30

DECLARE @len_address_dept int
SET @len_address_dept = 30

DECLARE @len_location_dept int
SET @len_location_dept = 35

DECLARE @cf_dept varchar(16)
DECLARE @desc_dept varchar(150)
DECLARE @address_dept varchar(30)
DECLARE @cap_dept varchar(30)
DECLARE @location_dept varchar(35)

SELECT  @cf_dept = ISNULL(cf,p_iva),
@desc_dept =  ISNULL(agencyname,''),
@address_dept = ISNULL(address1,''),
@location_dept = ISNULL(location,'') ,
@cap_dept = ISNULL(cap, '')
FROM license


DECLARE @lenCC_vincolato int
SET @lenCC_vincolato = 7

DECLARE @cc_vincolato varchar(7)

 


/*
-------------------------------------------------------
------- MAPPATURA MODALITA' DI PAGAMENTO --------------

Metodo di pagamento. Deve essere verificato che assuma solo i valori:
"TRF"
"CHK"
"TRA"

Service Level		Payment Method		Tipologia distinta

SEPA 			TRF				Disposizioni di Bonifico SEPA senza Esito all’Ordinante
SEPA 			TRA				Disposizioni di Bonifico SEPA con Esito all’Ordinante
- assente –		CHK				Disposizioni di Emissione assegni con Esito all’Ordinante
URGP			TRA				Disposizioni di Bonifico Urgente con Esito all’Ordinante
FAST 			TRF				Disposizioni di Bonifico FAST senza Esito all’Ordinante
FAST 			TRA				Disposizioni di Bonifico FAST con Esito all’Ordinante
PGPA			TRA				Disposizioni di pagamento pagoPA con Esito all’Ordinante
PGSP			TRA				Disposizione di pagamento spontaneo pagoPA con Esito all’Ordinante

*/

 

DECLARE @cod_department varchar(12) -- Codice dell'ente da esportare
DECLARE @ABI_department varchar(5)
DECLARE @IBAN_department varchar(50)
SELECT  @cod_department = ISNULL(RTRIM(agencycodefortransmission),''),
	@ABI_department = SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(idbank,'')))+ ISNULL(idbank,''),
	@cc_vincolato = SUBSTRING(REPLICATE('0',@lenCC_vincolato),1,@lenCC_vincolato - 
					DATALENGTH(CONVERT(varchar(7),ISNULL(trasmcode,'0')))) + CONVERT(varchar(7),ISNULL(trasmcode,'0')),
	@IBAN_department = iban
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
--IF (@cod_department IS NULL OR @cod_department = '')
--BEGIN
--	SET @message = @message + ' Il Codice Ente'
--	SET @error = 'S'
--END
IF (@ABI_department IS NULL OR @ABI_department = '')
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
WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n
	AND idpaymethod IS NULL
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
	AND NOT EXISTS (SELECT * FROM expenseview WHERE expenseview.idexp =paymentcommunicated.idexp AND  netamount = 0)
	)


-- CONTROLLO N. 3. Movimento di Spesa con Modalità di Pagamento non configurata
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

-- CONTROLLO N. 4. Codice IBAN o ABI o CAB devono essere valorizzati nel caso di modalità di pagamento '02'
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
	AND paymethod.methodbankcode  = ('02')
	AND (
		(paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
		OR (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
	)
	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
)


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


-- CONTROLLO N. 10. Uso di modlaità di pagamento NON ammesse dalla banca-  vedi Specifiche tracciato
INSERT INTO #error (message)
(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata una modalità di pagamento non prevista dalla banca.'
FROM paymentcommunicated
JOIN paymethod
	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
WHERE paymentcommunicated.ypaymenttransmission = @y
	AND paymentcommunicated.npaymenttransmission = @n
	AND paymethod.methodbankcode NOT IN ('02','SEPA','PGPA','PGSP','BONIFICOESTERO') ------------------------------DA RIMUOVERE LO 02 ---------------------------------------*****************************************************************************************************************************************************************************
)

----------------------------		COMMENTO PER CBI		---------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
-- CONTROLLO N. 12. Bollettino postale (cod. pag. 02)i codici ABI e CAB non devono essere valorizzati, lo deve essere solo il numero del C/C-- 
--INSERT INTO #error (message)
--(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
--+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata la modalità di pagamento Bollettino Postale  ma il codice ABI  e CAB non devono essere valorizzati'
--FROM paymentcommunicated
--JOIN paymethod
--	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
--WHERE paymentcommunicated.ypaymenttransmission = @y
--	AND paymentcommunicated.npaymenttransmission = @n
--	AND paymethod.methodbankcode  = '06'
--	AND 
--	(
--		paymentcommunicated.idbank  IS NOT NULL OR
--		paymentcommunicated.idcab  IS NOT NULL 
--	)	 
--	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
--)

----------------------------		COMMENTO PER CBI		---------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------

-- CONTROLLO N. 14. Presenza trattamento bollo
--INSERT INTO #error (message)
--SELECT 'Il trattamento bollo deve essere obbligatoriamente impostato per il mandato n° ' + CONVERT(varchar(6),P.npay) 
--FROM payment P
--WHERE P.idstamphandling IS NULL
--	  AND P.kpaymenttransmission = @kpaymenttransmission

----------------------------		COMMENTO PER CBI		---------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------

-- CONTROLLO N. 14. codice contabilita speciale errato o mancante, controllare regole su codice contabilità speciale girofondi
--IF EXISTS
--(SELECT * FROM paymentcommunicated
--        join expenselast
--        	ON paymentcommunicated.idexp = expenselast.idexp
--        join expense
--              on expenselast.idexp = expense.idexp 
--        join registrypaymethod
--                on registrypaymethod.idreg = expense.idreg
--                and registrypaymethod.idpaymethod = expenselast.idpaymethod
--				and registrypaymethod.idregistrypaymethod = expenselast.idregistrypaymethod
--        JOIN paymethod
--        	ON expenselast.idpaymethod = paymethod.idpaymethod
--WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
--	-- modalità di pagamento girofondo, valutare il girofondo F24EP
--	AND ((expenselast.paymethod_flag&256)<>0 OR (expenselast.paymethod_flag&512)<> 0 OR (expenselast.paymethod_flag&1024)<> 0 OR -- modalità di pagamento girofondo
--		   (expenselast.paymethod_flag) & 2048 <> 0) 
--	AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
--		OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),' ','') = ''
--		OR DATALENGTH(ISNULL(
--		REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
--		REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
--		'/',''),':',''),';','')
--		,'')) > @lencodicecontabilitaspeciale)
--)
--BEGIN
--	INSERT INTO #error (message)
--		(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
--		+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov)
--		+ ' nella modalità di pagamento non è stato inserito il Codice contabilità speciale o la sua lunghezza supera i '
--		+ CONVERT(varchar(7),@lencodicecontabilitaspeciale) + ' caratteri'
--		FROM paymentcommunicated
--        join expenselast
--        	ON paymentcommunicated.idexp = expenselast.idexp
--        join expense
--              on expenselast.idexp = expense.idexp 
--        join registrypaymethod
--                on registrypaymethod.idreg = expense.idreg
--                and registrypaymethod.idpaymethod = expenselast.idpaymethod
--				and registrypaymethod.idregistrypaymethod = expenselast.idregistrypaymethod
--        JOIN paymethod
--        	ON expenselast.idpaymethod = paymethod.idpaymethod
--		WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
--				AND ((expenselast.paymethod_flag&256)<>0 OR (expenselast.paymethod_flag&512)<> 0 OR (expenselast.paymethod_flag&1024)<> 0 OR -- modalità di pagamento girofondo
--		   (expenselast.paymethod_flag) & 2048 <> 0) 
--			AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL 
--				OR REPLACE(ISNULL(expenselast.extracode,registrypaymethod.extracode),' ','') = ''
--				OR DATALENGTH(ISNULL(ISNULL(expenselast.extracode,registrypaymethod.extracode),'')) > @lencodicecontabilitaspeciale)
--		)
--END

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
 
DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

-- Tabella dei pagamenti
CREATE TABLE #payment
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	idexp int,
	ymov int, 
	nmov int, 
	nphase tinyint, 
	phase varchar(50),
	curramount decimal(19,2),
	saldo decimal(19,2),
	exp_curramount decimal(19,2),
	flagcr char(1),
	idreg int,
	expense_adate datetime,
	payment_adate datetime,
	transmissiondate datetime,
	idpay int,
	idpaydisposition int,
	iddetail int,
	idpaymethodTRS varchar(20),
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
	location_ben varchar(150),
	province_ben varchar(2),
	iso_code_ben varchar(2),
	pi_ben varchar(35),
	cf_ben varchar(35),
	stamphandling varchar(50),
	stamp_charge char(1),
	exemption_stamp_motive varchar(150),
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
	exemption_charge_motive varchar(150),
	uncharged char(1),
	iddeputy int,
	refexternaldoc varchar(50), 
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
	title_deputy varchar(150),
	address_deputy varchar(100),
	cap_deputy varchar(16),
	location_deputy varchar(116),
	province_deputy varchar(2),
	nation_deputy varchar(2), -- sigla ISO IT/FR/....
	p_iva_deputy varchar(35), 
	cf_deputy varchar(35)
)

-- Tabella delle trattenute a carico del beneficiario
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

-- Inserimento dei movimenti di spesa presenti nella distinta di trasmissione
INSERT INTO #payment
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idexp, 
	ymov, nmov, nphase, phase,
	flagcr, curramount,  
    idreg, expense_adate, payment_adate, transmissiondate, 	
	idpaymethodTRS, 
	ABI, CAB, cc, cin_iban, cin, codice_paese, bank, iban, biccode, id_end_to_end , 
	code, proprietary,
	title_ben, cf_ben, pi_ben , 
	paymentdescr, expenselast_paymentdescr, 
	extracode, iddeputy, refexternaldoc, nbill, idpay, 
    idpaydisposition,iddetail,  txt
)
SELECT
	t.ypaymenttransmission, t.npaymenttransmission, d.ypay, d.npay, s.idexp,  
	s.ymov, s.nmov, s.nphase, eph.description, 
	CASE
		WHEN ((i.flag&1)=0) THEN 'C'
		WHEN ((i.flag&1)=1) THEN 'R'
	END, 
	i.curramount,
	s.idreg, s.adate, d.adate, t.transmissiondate, 
	LTRIM(RTRIM(m.methodbankcode)),
	CASE
		WHEN DATALENGTH(ISNULL(el.idbank,'')) <= @len_ABI
		THEN ISNULL(el.idbank,'')
		ELSE SUBSTRING(el.idbank,1,@len_ABI)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(el.idcab,'')) <= @len_CAB
		THEN ISNULL(el.idcab,'')
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
	el.biccode,
	null,
	null,
	null,
	CASE
		  WHEN ( pd.idpaydisposition is not null)  
		  THEN ISNULL(pd.title,ISNULL(pd.surname,'') + ' ' +  ISNULL(pd.forename,'') ) 
		  ELSE ISNULL(c.title,'')
	END,
	CASE
		  WHEN ( pd.idpaydisposition is not null)  
		  THEN ISNULL(pd.cf,'')   
		  ELSE c.cf
	END,
	CASE
	WHEN (pd.idpaydisposition is not null )
			  THEN ISNULL(pd.p_iva,'')  
		ELSE CASE
				WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
					AND DATALENGTH(c.p_iva) <= @len_pi
				THEN c.p_iva
				WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
					AND DATALENGTH(c.p_iva) > @len_pi
				THEN SUBSTRING(c.p_iva, 1, @len_pi)
				ELSE null-- REPLICATE('',@len_pi)
		END
	END ,
	---- paymentdescr:
	'Doc. ' + ISNULL(s.doc,'') + ' del ' +  ISNULL(CONVERT(varchar(12),s.docdate,105),'') + ' ' + ISNULL(s.description,''),
	el.paymentdescr,
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
	CASE WHEN (pd.idpaydisposition is not null )
			  THEN pd.idpaydisposition 
	ELSE NULL
	END,
	CASE WHEN ( pd.idpaydisposition is not null )
			  THEN pd.iddetail 
	ELSE 0
	END,
	ltrim(rtrim(substring(s.txt, 1, 200)))
FROM expense s
JOIN expenselast el
	ON S.idexp = el.idexp
JOIN expensetotal i
	ON i.idexp = s.idexp
JOIN expenseyear y
	ON y.idexp = s.idexp 
JOIN expensephase eph
	ON eph.nphase = s.nphase
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
LEFT OUTER JOIN paydispositiondetail pd
	ON pd.idexp = el.idexp
JOIN registry c
	ON c.idreg = s.idreg
JOIN registryclass ctc 
	ON ctc.idregistryclass = c.idregistryclass
LEFT OUTER JOIN bank
	ON bank.idbank = el.idbank
WHERE t.ypaymenttransmission = @y
	AND t.npaymenttransmission = @n
	



-- Inserimento delle trattenute (vengono inseriti ritenute, quest'ultime solo dipendenti). Non inserisce i recuperi
INSERT INTO #tax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, idreg, autokind,
	ymov_income, nmov_income, idpro
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro
FROM #payment p
JOIN income e		ON e.idpayment = p.idexp	
JOIN incomelast il	ON e.idinc = il.idinc
JOIN incometotal ie	ON e.idinc = ie.idinc
JOIN proceeds di	ON di.kpro = il.kpro
left outer JOIN proceedstransmission	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
AND (p.idpaydisposition IS  NULL --AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 --(p.girofondo <> 'S') 
	 ) 
	
AND  --((e.autokind = 14) --automatismo generico
		--OR (e.autokind = 4 AND e.idreg = p.idreg)) -- Ritenuta
		 (e.autokind in (4,7,14,20,21,30,31) ) -- AUTOMATISMI DA CSA
	AND ((e.idreg = p.idreg) or (e.autokind = 14) /*automatismo generico, non è richiesta la stessa anagrafica*/) 
	AND ie.ayear = @y

AND (@n is null OR di.kproceedstransmission is not null)--Se @n è null prende tutto, altrimenti prende solo le rit. inserte in una distinta

-- Inserisce solo i recuperi
INSERT INTO #tax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, idreg, autokind,
	ymov_income, nmov_income, idpro
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro
FROM #payment p
JOIN income e		ON e.idpayment = p.idexp	
JOIN incomelast il	ON e.idinc = il.idinc
JOIN incometotal ie	ON e.idinc = ie.idinc
JOIN proceeds di	ON di.kpro = il.kpro
left outer JOIN proceedstransmission	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
 AND (e.autokind = 6) -- Recupero
 AND ie.ayear = @y

AND (@n is null OR di.kproceedstransmission is not null)--Se @n è null prende tutto, altrimenti prende solo le rit. inserte in una distinta


-- Leggo configurazione dell'applicazione dei contributi 
DECLARE @admintaxkind int
SELECT  @admintaxkind = (automanagekind & 0xf) FROM config WHERE ayear = @y
 
-- Inserimento delle trattenute (vengono inseriti i contributi c/amministrazione)
INSERT INTO #admintax
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,   idpay,
	idexp, idinc, ypro, npro, yproceedstransmission, curramount, idreg, autokind,
	ymov_income, nmov_income, idpro
)
SELECT
	p.ypaymenttransmission, p.npaymenttransmission, p.ydoc, p.ndoc, p.idpay,
	p.idexp, e.idinc, di.ypro, di.npro, proceedstransmission.yproceedstransmission,
	ie.curramount, e.idreg, e.autokind, e.ymov, e.nmov, il.idpro
FROM #payment p
JOIN expense s			ON s.idexp = p.idexp
JOIN income e			ON e.idpayment = s.idpayment	
JOIN incomelast il		ON e.idinc = il.idinc
JOIN incometotal ie		ON e.idinc = ie.idinc
JOIN proceeds di		ON di.kpro = il.kpro
left outer JOIN proceedstransmission	ON di.kproceedstransmission = proceedstransmission.kproceedstransmission
WHERE e.nphase = @maxincomephase
AND (p.idpaydisposition IS  NULL --AND -- i mandati stipendi ad anagrafiche cumulative non devono essere associati a ritenute
	 -- i girofondi in B.I. non possono essere associati a ritenute
	 --(p.girofondo <> 'S')  
	 )
	AND e.autokind = 4 -- Contributo
	AND s.autokind = 4 
	AND s.autocode  = e.autocode
	AND p.idreg = e.idreg
	AND ie.ayear = @y
	AND @admintaxkind = 2 -- movimento di spesa sul capitolo di spesa o sul capitolo di liquidazione del contributo
	-- e movimento di entrata su partita di giro
AND (@n is null OR di.kproceedstransmission is not null)--Se @n è null prende tutto, altrimenti prende solo le rit. inserte in una distinta


update #payment set saldo = curramount - isnull((select sum(curramount) from #admintax where #admintax.idexp = #payment.idexp),0)
update #payment set saldo = saldo - isnull((select sum(curramount)  from #tax where #tax.idexp = #payment.idexp),0)


---------------------------------------------------------------------------------------------
-- Inserimento dei pagamenti presenti nella distinta di trasmissione che si vuole trasmettere
--					che siano collegati alle disposizioni di pagamento                     --
---------------------------------------------------------------------------------------------


-- Valorizzo l'identificativo End to End per i Bonifici SEPA
UPDATE #payment SET id_end_to_end =SUBSTRING(CONVERT(VARCHAR(4),ydoc) + '_'+ CONVERT(VARCHAR(4),ndoc) +'_'+ CONVERT(VARCHAR(4),idpay),1,35)
WHERE ((idpaymethodTRS = '03') AND (fulfilled = 'N')) 
--- valorizzo 'DISPOSIZIONI DOCUMENTO ESTERNO' SOLO SE  MOVIMENTI DI SPESA ASSOCIATI A DISPOSIZIONI NOMINATIVE  (nuova gestione)
UPDATE #payment SET  idpaymethodTRS = '13' WHERE idpaydisposition IS NOT NULL AND iddetail = 0 
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

-- Inizio Formattazione del C/C	
UPDATE #payment
SET cc = 
	UPPER(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(cc,',',''),'.',''),'_',''),'-',''),'*',''),'+',''),
	'/',''),':',''),';',''),' ',''))

UPDATE #payment SET cc = REPLICATE('0',@len_cc - DATALENGTH(ISNULL(cc,''))) + ISNULL(cc,'')
WHERE LTRIM(RTRIM(ISNULL(cc,''))) <> ''
-- Fine Formattazione del C/C



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
	AND ((I.autokind = 6) /* <--Recupero*/	OR (I.autokind = 14) /*<--automatismo generico*/OR (I.autokind = 4 AND I.idreg = P.idreg)/*<--Ritenuta*/
	OR (I.autokind in (20,21,30,31) AND I.idreg = P.idreg ))
	AND IT.ayear = @y
	AND T.yproceedstransmission IS NULL

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

update #payment set idpaymethodTRS = '14' /*compensazione*/ where saldo = 0 -- pagamenti di pari importo con incassi


-- Riempimento della tabella del delegato
INSERT INTO #deputy (iddeputy, title_deputy, p_iva_deputy, cf_deputy)
SELECT
	DISTINCT #payment.iddeputy,
	ISNULL(registry.title,''),
	ISNULL(registry.p_iva,SPACE(@len_pi)),
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

--Legge i dati dell'indirizzo dalla tabella paydisposition
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
WHERE  paydispositiondetail.idexp in (select idexp from #payment)



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
--select * from #address


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
SET 
address_ben =
	(SELECT
		ISNULL(address,'')
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
	(SELECT ISNULL(location,'')
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
	WHERE #payment.idreg  IS NOT NULL


-- Aggiornamento dati indirizzo delegato
UPDATE #deputy
SET address_deputy =
	(SELECT
	ISNULL(address,'')
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
	(SELECT ISNULL(location,'') 
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
WHERE  #payment.idpaydisposition is not null

 

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END
	
DECLARE @total_payment decimal(19,2)	



-------------------------------------------------------------------------------------------------------------------
------------------------------------------------inizio tracciato---------------------------------------------------
-------------------------------------------------------------------------------------------------------------------

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
DECLARE @codice_ente_BT  varchar(12)
SET @codice_ente_BT = @cod_department
DECLARE @riferimento_ente varchar(30)
DECLARE @esercizio int
SET @esercizio = @y -- esercizio finanziario
SET @codice_ABI_BT = @ABI_department 
---------------------------------------------
----- fine testata flusso -------------------
---------------------------------------------
-- Tabella di output

CREATE TABLE #trace
(
	kind char(100), 
	-------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------- Group Header--------------------------------------------------------
    -------------------------------------------------------------------------------------------------------------------------------------
	GroupHeader_MessageIdentification	varchar(35),	--	<MsgId> Identificativo univoco messaggio
	GroupHeader_CreationDateTime	datetime,			--	<CreDtTm> Data e Ora di Creazione 
	GroupHeader_NumberofTransactions varchar(15),		-- <NbOfTxs>	Numero Transazioni
	GroupHeader_ControlSum	decimal(19,2),				--	<CtrlSum>	Somma di controllo

	InitiatingParty_Name varchar(70) ,					--	<Nm>	Nome del Mittente della richiesta di bonifico  
	InitiatingParty_Identification varchar(35),			--	<Id>	Nome o numero assegnato da un'entità per il riconoscimento di quell'entità
	InitiatingParty_Issuer varchar(35),					--	<Issr>	Entità che assegna l'identificativo. La prima occorrenza deve essere valorizzata con il valore “CBI”
	-------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------- Payment Information ------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	PaymentInformation varchar(35),						-- <PmtInfId>  Identificativo informazioni di addebito
	PaymentMethod	varchar(20) ,						-- <PmtMtd>	\Metodo di pagamento 

	-- PaymentTypeInformation	<PmtTpInf> Informazioni tipo di pagamento
	PaymentTypeInformation_InstructionPriority varchar(4),			-- <InstrPrty> Indicazione di priorità di esecuzione
 	PaymentTypeInformation_Code	varchar(4),				-- <Cd> Codifica di servizio
	Debtor_ReqdExctnDt datetime,
	Debtor_Name varchar(70),							-- <Nm> Nome
	Debtor_AddressType varchar(4),						-- <AdrTp>	Tipo indirizzo 
	Debtor_StreetName  varchar(70),						-- <StrtNm>	Via/Piazza
	Debtor_PostalCode  varchar(16),						-- <PstCd>	Codice postale
	Debtor_IBAN varchar(27),							-- <IBAN>  IBAN
	Debtor_abi varchar(5),								-- <MmbId>	Member Id => Codice ABI
	Debtor_ChargeBearer	varchar(4),						-- <ChrgBr>	Tipologia Commissioni: assume il solo valore SLEV

	-------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------- Credit Transfer Transaction Information ------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------

	----------------------------------------------------- Titolare c/c accredito / Beneficiario -------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	Credit_InstructionIdentification varchar(35),	-- <InstrId> :Identificativo univoco assegnato all'istruzione dal Mittente nei confronti della sua Banca.
																-- Può rappresentare un progressivo oppure un altro identificativo ad uso interno del Mittente.
																-- Utilizzato ai fini della riconciliazione
													--> POTREMMO USARE L'idpay
	Credit_EndToEndIdentification	varchar(35), -- <EndToEndId> 
	-- Elementi che specificano ulteriormente il tipo di transazione
	-- Regola: Obbligatorio se IBAN c/c di accredito valorizzato e riferito ad IT
	Credit_Code varchar(4), -- <Cd> LE CAUSALI SONO TANTE, MA DOVENDO (per il momento) GESTIRE SOLO BON.SEPA E PAGOPA SCRIVIAMO :SALA	( SalaryPayment	Transaction is the payment of salaries.)
	Creditor_InstructedAmount decimal(19,2), -- <InstdAmt>
	Creditor_Nome  varchar(70),-- <Nm> Nome
	Creditor_kind char(1), -- indica se Persona fisica o giuridica
	-- <PstlAdr> Indirizzo Postale
	Creditor_StreetName	varchar(70), --<StrtNm> Via/Piazza
	Creditor_PostalCode	varchar(16), --<PstCd> Codice postale
	Creditor_TownName	varchar(35), --<TwnNm> Città
	Creditor_Country varchar(2),	--<Ctry> Stato
	--BICOrBEI OR OrganisationIdentification
	Creditor_OrganisationIdentification_BICOrBEI varchar(15), -- <BICOrBEI> BIC
	Creditor_OrganisationIdentification_Id varchar(35), -- <Id>
	Creditor_OrganisationIdentification_Issuer varchar(35), -- <Issuer>
	
	Creditor_PrivateIdentification_Id varchar(35), -- <Id>
	Creditor_PrivateIdentification_Issuer varchar(35), -- <Issuer>Creditor_
	Creditor_IBAN varchar(27),
	----------------------------------------------------- Creditore effettivo -----------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	UltimateCreditor_Nome  varchar(70),-- <Nm> Nome
	UltimateCreditor_kind char(1), -- indica se Persona fisica o giuridica
	-- <PstlAdr> Indirizzo Postale
	UltimateCreditor_StreetName	varchar(70), --<StrtNm> Via/Piazza
	UltimateCreditor_PostalCode	varchar(16), --<PstCd> Codice postale
	UltimateCreditor_TownName	varchar(35), --<TwnNm> Città
	UltimateCreditor_Country varchar(2),	--<Ctry> Stato

	UltimateCreditor_OrganisationIdentification_BICOrBEI varchar(15), -- <BICOrBEI> BIC
	UltimateCreditor_OrganisationIdentification_Id varchar(35), -- <Id>
	UltimateCreditor_OrganisationIdentification_Issuer varchar(35), -- <Issuer>
	
	UltimateCreditor_PrivateIdentification_Id varchar(35), -- <Id>
	UltimateCreditor_PrivateIdentification_Issuer varchar(35), -- <Issuer>
	-------------------------------------------------------------------------------------------------------------------------------------
	Unstructured	varchar(140) -- <Ustrd> Dettagli in modalità non strutturata : descrizione pagamento
)

---------------------------------------------
---------- testata flusso -------------------
---------------------------------------------
-- Questa tabella serve solo per conteggiare i pagamenti a parità di modalità di pagamento
create table #GroupPaymetInformation(
	methodbankcode varchar(20),
	count_pagamenti int,
	importo_pagamenti decimal(19,2)
	)
	
INSERT INTO #GroupPaymetInformation(
					methodbankcode,
					count_pagamenti,
					importo_pagamenti
				   )
SELECT 
				   idpaymethodTRS,
				   count(idpay), 
				   SUM(saldo)--SUM(curramount) 
FROM #payment
GROUP BY idpaymethodTRS
ORDER BY #payment.idpaymethodTRS


INSERT INTO #trace(kind,
		GroupHeader_MessageIdentification,		--	<MsgId> Identificativo univoco messaggio
		GroupHeader_CreationDateTime	,		--	<CreDtTm> Data e Ora di Creazione 
		GroupHeader_NumberofTransactions ,		-- <NbOfTxs>	Numero Transazioni
		GroupHeader_ControlSum	,				--	<CtrlSum>	Somma di controllo

		InitiatingParty_Name  ,					--	<Nm>	Nome del Mittente della richiesta di bonifico  
		InitiatingParty_Identification ,		--	<Id>	Nome o numero assegnato da un'entità per il riconoscimento di quell'entità
		InitiatingParty_Issuer					--	<Issr>	Entità che assegna l'identificativo. La prima occorrenza deve essere valorizzata con il valore “CBI”
		   )
SELECT 
		'GroupHeader',
		'mandati_'+ convert(varchar(4),@y) + '_' +convert(varchar(4),@n)+ '_' + methodbankcode,
		@data_ora_creazione_flusso,
		count_pagamenti,
		importo_pagamenti,

		substring(@descrizione_ente,1,70),
		@codice_ente,
		'CBI'
from #GroupPaymetInformation

	
INSERT INTO #trace(	
					kind,
					PaymentInformation,
					PaymentMethod,
					PaymentTypeInformation_InstructionPriority,
					PaymentTypeInformation_Code,
					Debtor_Name,
					Debtor_ReqdExctnDt,
					Debtor_AddressType,
					Debtor_StreetName,
					Debtor_PostalCode,
					Debtor_IBAN,
					Debtor_abi,
					Debtor_ChargeBearer
					)
SELECT  distinct 
				   'PaymentInformation',
				   'mandati_'+ convert(varchar(4),@y) + '_' +convert(varchar(4),@n)+ '_' + #GroupPaymetInformation.methodbankcode,
					case when #GroupPaymetInformation.methodbankcode IN ('02','SEPA','BONIFICOESTERO') then 'TRF'--********************************************************************************************************************************************************************************************************************************************
						when #GroupPaymetInformation.methodbankcode in ('PGPA','PGSP') then 'TRA'
						else #GroupPaymetInformation.methodbankcode
					end,
				   'NORM',
				   --#GroupPaymetInformation.methodbankcode, --SEPA , PGPA-pagoPA secondo il modello 3 , PGSP-pagoPA secondo il modello 4
				   case WHEN #GroupPaymetInformation.methodbankcode='BONIFICOESTERO' then 'TRF' else  #GroupPaymetInformation.methodbankcode end,
				   substring(@descrizione_ente,1,70),
				   @data_ora_creazione_flusso,
				   'ADDR',
				   @address_dept,
				   @cap_dept,
				   @IBAN_department,
				   @ABI_department,
				   'SLEV'
FROM #payment
join #GroupPaymetInformation
on #payment.idpaymethodTRS = #GroupPaymetInformation.methodbankcode



INSERT INTO #trace(
					kind,
					PaymentMethod,
					------------------- Titolare c/c accredito / Beneficiario -------------------------------------------
					Credit_InstructionIdentification,
					Credit_EndToEndIdentification,
					Credit_Code, 
					Creditor_InstructedAmount,
					----------------- beneficiario --------------
					Creditor_Nome,
					Creditor_kind,
					Creditor_StreetName,
					Creditor_PostalCode,
					Creditor_TownName,
					Creditor_Country,
					Creditor_OrganisationIdentification_BICOrBEI,
					Creditor_OrganisationIdentification_Id,
					Creditor_OrganisationIdentification_Issuer,
					Creditor_PrivateIdentification_Id,  -- DA RIVEDERE
					Creditor_PrivateIdentification_Issuer,
					Creditor_IBAN,
				   ----------------- creditore effettivo -------
					UltimateCreditor_Nome  ,-- <Nm> Nome
					UltimateCreditor_kind,
					UltimateCreditor_StreetName	, --<StrtNm> Via/Piazza
					UltimateCreditor_PostalCode	, --<PstCd> Codice postale
					UltimateCreditor_TownName	, --<TwnNm> Città
					UltimateCreditor_Country ,
					UltimateCreditor_OrganisationIdentification_Id , -- <Id>
					UltimateCreditor_OrganisationIdentification_Issuer , -- <Issuer>
	
					UltimateCreditor_PrivateIdentification_Id , -- <Id>
					UltimateCreditor_PrivateIdentification_Issuer , -- <Issuer>
					-------------------------------------------------------------------------------------------------------------------------------------
					Unstructured

				   )
SELECT 
				   'CreditTransferTransactionInformation',
				   --idpaymethodTRS
				    case WHEN idpaymethodTRS='BONIFICOESTERO' then 'TRF' else idpaymethodTRS end,

				   CONVERT(varchar(10), ndoc) +'_' + CONVERT(varchar(10), idpay),
				   CONVERT(varchar(10), ndoc) +'_' + CONVERT(varchar(10), idpay),
				   'SUPP',
				   sum(saldo),--SUM(curramount),
				   ----------------- beneficiario --------------
				   SUBSTRING(title_ben,1,60), 
				   	CASE
						WHEN  LEN(LTRIM(RTRIM(cf_ben))) = 16 THEN 'F'
						ELSE 'G' 
					END,
				   --Indirizzo Beneficiario
				   SUBSTRING(address_ben,1,30),
				   -- C.A.P. Beneficiario
				   cap_ben,
				   -- Località Beneficiario
				   SUBSTRING(location_ben,1,30),
				   -- Stato_beneficiario
				   iso_code_ben,
				   biccode,
				   isnull(pi_ben,  cf_ben),
				   'ADE',
					isnull(pi_ben,  cf_ben),
				   'ADE',
				   iban,
				   ---------------- CREDITORE EFFETTIVO ---------------------- 
				    SUBSTRING(#deputy.title_deputy,1,60),
				   	CASE
						WHEN  LEN(LTRIM(RTRIM(#deputy.cf_deputy))) = 16 THEN 'F'
						ELSE 'G' 
					END,
				   SUBSTRING(#deputy.address_deputy,1,30),
				   #deputy.cap_deputy,
				   SUBSTRING(#deputy.location_deputy,1,30),
					#deputy.nation_deputy,
				    #deputy.p_iva_deputy,
					'ADE',
					#deputy.cf_deputy,
					'ADE',
  				   SUBSTRING(paymentdescr,1,140) -- CAUSALE PAGAMENTO
  		
FROM #payment
LEFT JOIN #deputy
	ON #payment.iddeputy = #deputy.iddeputy
	GROUP BY
		#payment.ndoc, #payment.idpay,idpaymethodTRS, fulfilled,deny_bank_details, destinazione, tipo_contabilita_ente_ricevente,extracode,
		title_ben, address_ben, cap_ben, location_ben, province_ben,iso_code_ben,
		pi_ben, cf_ben,
		#deputy.title_deputy,  #deputy.address_deputy,  #deputy.cap_deputy,#deputy.location_deputy,
		#deputy.province_deputy,#deputy.nation_deputy,  #deputy.cf_deputy,#deputy.p_iva_deputy,
		ABI, CAB, cc, cin_iban, cin,codice_paese, bank, iban,biccode,id_end_to_end,code, proprietary,
		paymentdescr, stamphandling, stamp_charge, exemption_stamp_motive, 
		refexternaldoc,expenselast_paymentdescr,  chargehandling,exemption_charge_payment_kind,
		exemption_charge_motive
ORDER BY #payment.ndoc, #payment.idpay





--SELECT * FROM #trace 
SELECT kind , 
	-------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------- Group Header--------------------------------------------------------
    -------------------------------------------------------------------------------------------------------------------------------------
	GroupHeader_MessageIdentification	AS MsgId,	--	<MsgId> Identificativo univoco messaggio
	GroupHeader_CreationDateTime	AS CreDtTm,			--	<CreDtTm> Data e Ora di Creazione 
	GroupHeader_NumberofTransactions as NbOfTxs,		-- <NbOfTxs>	Numero Transazioni
	GroupHeader_ControlSum	as GroupHeader_CtrlSum,				--	<CtrlSum>	Somma di controllo

	InitiatingParty_Name as InitiatingParty_Nm ,					--	<Nm>	Nome del Mittente della richiesta di bonifico  
	@cod_department as InitgPty_Id,			--	<Id>	Nome o numero assegnato da un'entità per il riconoscimento di quell'entità
	InitiatingParty_Issuer ,					--	<Issr>	Entità che assegna l'identificativo. La prima occorrenza deve essere valorizzata con il valore “CBI”
	-------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------- Payment Information ------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	PaymentInformation as PmtInfId,						-- <PmtInfId>  Identificativo informazioni di addebito
	PaymentMethod	as PmtMtd ,						-- <PmtMtd>	\Metodo di pagamento 

	-- PaymentTypeInformation	<PmtTpInf> Informazioni tipo di pagamento
	PaymentTypeInformation_InstructionPriority as InstrPrty,			-- <InstrPrty> Indicazione di priorità di esecuzione
 	PaymentTypeInformation_Code	as PaymentTypeInformation_Cd,				-- <Cd> Codifica di servizio
	--@data_ora_creazione_flusso
	Debtor_ReqdExctnDt,
	Debtor_Name as Debtor_Nm,							-- <Nm> Nome
	Debtor_AddressType as Debtor_AdrTp,						-- <AdrTp>	Tipo indirizzo 
	Debtor_StreetName  as Debtor_StrtNm,						-- <StrtNm>	Via/Piazza
	Debtor_PostalCode  as Debtor_PstCd,						-- <PstCd>	Codice postale
	Debtor_IBAN ,							-- <IBAN>  IBAN
	Debtor_abi as Debtor_MmbId,								-- <MmbId>	Member Id => Codice ABI
	Debtor_ChargeBearer	as Debtor_ChrgBr,						-- <ChrgBr>	Tipologia Commissioni: assume il solo valore SLEV

	-------------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------------------- Credit Transfer Transaction Information ------------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------

	----------------------------------------------------- Titolare c/c accredito / Beneficiario -------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	Credit_InstructionIdentification as InstrId,	-- <InstrId> :Identificativo univoco assegnato all'istruzione dal Mittente nei confronti della sua Banca.
																-- Può rappresentare un progressivo oppure un altro identificativo ad uso interno del Mittente.
																-- Utilizzato ai fini della riconciliazione
													--> POTREMMO USARE L'idpay
	Credit_EndToEndIdentification as Credit_EndToEndId	, -- <EndToEndId> 
	-- Elementi che specificano ulteriormente il tipo di transazione
	-- Regola: Obbligatorio se IBAN c/c di accredito valorizzato e riferito ad IT
	Credit_Code as Credit_Cd, -- <Cd> LE CAUSALI SONO TANTE, MA DOVENDO (per il momento) GESTIRE SOLO BON.SEPA E PAGOPA SCRIVIAMO :SALA	( SalaryPayment	Transaction is the payment of salaries.)
	Creditor_InstructedAmount as Creditor_InstdAmt, -- <InstdAmt>
	Creditor_Nome  as Creditor_Nm,-- <Nm> Nome
	Creditor_kind,
	-- <PstlAdr> Indirizzo Postale
	Creditor_StreetName	as Creditor_StrtNm ,	 --<StrtNm> Via/Piazza
	Creditor_PostalCode	as Creditor_PstCd ,	 --<PstCd> Codice postale
	Creditor_TownName	as Creditor_TwnNm ,	--<TwnNm> Città
	Creditor_Country as Creditor_Ctry ,		--<Ctry> Stato
	--BICOrBEI OR OrganisationIdentification
	Creditor_OrganisationIdentification_BICOrBEI as Creditor_BICOrBEI , -- <BICOrBEI> BIC
	Creditor_OrganisationIdentification_Id  , -- <Id>
	Creditor_OrganisationIdentification_Issuer, -- <Issuer>
	
	Creditor_PrivateIdentification_Id  ,		-- <Id>
	Creditor_PrivateIdentification_Issuer  ,		-- <Issuer>Creditor_
	Creditor_IBAN ,
	----------------------------------------------------- Creditore effettivo -----------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------------------------
	UltimateCreditor_Nome  as UltimateCreditor_Nm, -- <Nm> Nome
	UltimateCreditor_kind,
	-- <PstlAdr> Indirizzo Postale
	UltimateCreditor_StreetName	as UltimateCreditor_StrtNm,		--	<StrtNm> Via/Piazza
	UltimateCreditor_PostalCode	as UltimateCreditor_PstCd, --	<PstCd> Codice postale
	UltimateCreditor_TownName as UltimateCreditor_TwnNm	,		--	<TwnNm> Città
	UltimateCreditor_Country as UltimateCreditor_Ctry ,			--	<Ctry> Stato

	UltimateCreditor_OrganisationIdentification_BICOrBEI as UltimateCreditor_BICOrBEI,	--	<BICOrBEI> BIC
	UltimateCreditor_OrganisationIdentification_Id as Ultimate_OrganisationIdentification_Id,			--	<Id>
	UltimateCreditor_OrganisationIdentification_Issuer as Ultimate_OrganisationIdentification_Issuer,		--	<Issuer>
	
	UltimateCreditor_PrivateIdentification_Id as Ultimate_PrivateIdentification_Id,			--	<Id>
	UltimateCreditor_PrivateIdentification_Issuer as Ultimate_PrivateIdentification_Issuer,		--	<Issuer>
	-------------------------------------------------------------------------------------------------------------------------------------
	Unstructured	 -- <Ustrd> Dettagli in modalità no

FROM #trace

END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




 
 

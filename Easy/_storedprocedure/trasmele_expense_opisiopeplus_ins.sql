
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_expense_opisiopeplus_ins]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_expense_opisiopeplus_ins]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 --setuser 'amministrazione'
-- exec trasmele_expense_opisiopeplus_ins 2021, 176
if not exists (select * from systypes where name = 'int_list') begin 
	CREATE TYPE dbo.int_list AS TABLE      ( n int)  
end
GO
 
CREATE        PROCEDURE [trasmele_expense_opisiopeplus_ins]
(
	@y int,
	@n int,
	@ischeck char(1)='N',
	@lista_id dbo.int_list  READONLY 
)
AS BEGIN

DECLARE @codeclassSIOPE varchar(20)

SELECT  @codeclassSIOPE  =  
CASE  
	WHEN  (@y<= 2006) THEN  'SIOPE'
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  '07U_SIOPE'
	ELSE   'SIOPE_U_18'
END


DECLARE @classSIOPE int
SELECT @classSIOPE = idsorkind FROM sortingkind WHERE codesorkind = @codeclassSIOPE

--setuser 'amministrazione'
--setuser 'amm'
--select * from payment where kpay = 188935

-- exec  trasmele_expense_opisiopeplus_ins 2019, 79, 'N'

-- select * from config
--------------------------------------------------------------
---  STORED PROCEDURE PER LA TRASMISSIONE DEI MANDATI PER  ---
----------------- BANCA BANCA CREDITO SICILIANO --------------
--------------------------------------------------------------
/*
(*1) 
tipo_debito_siope :  per le Fatture di tipo FE, scriviamo COMMERCIALE
per i pagamenti liquidazione iva, scriviamo IVA,
per le altre fature scriviamo NON COMMERCIALE perchè 
visto che le fatture cartacee di regola non esistono più, tranne le estere
e le estere non le abbiamo mai inviate in PCC (e non sappiamo nemmeno se si possono trasmettere )
quindi dicemo per evitare incongruenze, non le trasmettiamo come commerciali

*/

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

if (@n is not null)
Begin
	SELECT @idtreasurer = idtreasurer, @kpaymenttransmission = kpaymenttransmission 
	FROM paymenttransmission
	WHERE ypaymenttransmission = @y
	AND npaymenttransmission = @n
End
Else
Begin
	SELECT @idtreasurer =  idtreasurer
	FROM treasurer
	where flagdefault='S'	 ---Se sta lavorando col movimento, prendiamo il cassiere predefinito come riferimento perchè ci serve valorizzare alcune info al fine della misurazione del file, che altrimenti sarebbero null
End

DECLARE @len_desc_dept int
SET @len_desc_dept = 30

DECLARE @len_address_dept int
SET @len_address_dept = 30

DECLARE @len_location_dept int
SET @len_location_dept = 35

DECLARE @cf_dept varchar(16)
DECLARE @piva_dept varchar(16)
DECLARE @desc_dept varchar(150)
DECLARE @address_dept varchar(50)
DECLARE @location_dept varchar(50)

SELECT  @cf_dept = ISNULL(cf,p_iva),
@piva_dept = p_iva,
@desc_dept =  ISNULL(agencyname,''),
@address_dept = ISNULL(address1,''),
@location_dept = ISNULL(location,'') 
FROM license

DECLARE @idchargehandling_default  int
DECLARE @handlingbankcode_default  varchar(50)
DECLARE @motive_default  varchar(100)
DECLARE @payment_kind_default varchar(100)
SELECT  @idchargehandling_default = idchargehandling,@handlingbankcode_default = handlingbankcode,
		@motive_default = motive, @payment_kind_default = payment_kind
FROM    chargehandling WHERE   ((chargehandling.flag & 2) <> 0)


DECLARE @opkind varchar(20) 
--Può assumere i valori 
--INSERIMENTO– Inserimento  Ordinativo 
--VARIAZIONE- Variazione Ordinativo
--ANNNULLO- Annullo Ordinativo
--SOSTITUZIONE- Sostituzione Ordinativo
--(vedere specifiche tracciato ma non la gestiamo)

SET @opkind = 'INSERIMENTO' 

DECLARE @cc_vincolato varchar(8)

DECLARE @len_agencycode int
SET @len_agencycode = 7


/*
				  
-------------------------------------------------------
------- MAPPATURA MODALITA' DI PAGAMENTO --------------
-------------------------------------------------------

1 “CASSA”
2 “SEPA CREDIT TRANSFER” - EX “BONIFICO BANCARIO E POSTALE”
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
14 “COMPENSAZIONE”
15 “BONIFICO ESTERO EURO”
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

DECLARE @cod_department varchar(12) -- Codice dell'ente da esportare
DECLARE @ABI_code varchar(5)
DECLARE @destinazione varchar(20)
SELECT  @cod_department = ISNULL(RTRIM(agencycodefortransmission),''),
	@ABI_code = SUBSTRING(REPLICATE('0',@len_ABI),1,@len_ABI - DATALENGTH(ISNULL(idbank,'')))+ ISNULL(idbank,''),
	@cc_vincolato = trasmcode,
	@destinazione = (case when (flag&4)=0 then'LIBERA' else 'VINCOLATA' end)
FROM treasurer WHERE idtreasurer = @idtreasurer

DECLARE @Codice_ipa_struttura varchar(10)
SET @Codice_ipa_struttura = ( select ipa_fe from ipa where useforopi ='S')

DECLARE @CodiceStruttura varchar(16)

DECLARE @codice_tramite_BT VARCHAR(20) --(NEW) -- TODO: aggiungere alla tabella treasurer FATTO
declare @codice_tramite_ente  VARCHAR(20) --(NEW) -- TODO: aggiungere alla tabella treasurer FATTO
DECLARE @codice_istat_ente	varchar(20)--(new)-- Codice ISTAT dell'ente.contiene il codice ente SIOPE in corso di validità.  TODO: aggiungere alla tabella treasurer. FATTO
SELECT  @codice_tramite_BT = ISNULL(RTRIM(tramite_bt_code),''),
	@codice_tramite_ente =  ISNULL(RTRIM(tramite_agency_code),''),
	@codice_istat_ente = ISNULL(RTRIM(agency_istat_code),''),
	@CodiceStruttura = ISNULL(billcode,'')  
FROM treasurer WHERE idtreasurer = @idtreasurer

-- anagrafica cumulativa stipendi
declare @idreg_csa int
select  @idreg_csa = idreg_csa from config where ayear=@y
CREATE TABLE #error (message varchar(400))

-- Inizio Sezione Controlli
-- CONTROLLO N. 0 -- Distinta di Trasmissione vuota
if (@n is NOT null)
Begin
				IF(
				(SELECT COUNT(*) FROM payment
				WHERE kpaymenttransmission = @kpaymenttransmission) = 0)
				BEGIN
					INSERT INTO #error
					VALUES('La distinta di trasmissione ' + CONVERT(varchar(4),@y) + '/'
					+ CONVERT(varchar(6),@n) + ' è vuota')
				END

				IF(
				(SELECT COUNT(*) FROM ipa
				WHERE useforopi ='S') = 0)
				BEGIN
					INSERT INTO #error
					VALUES('Scegliere il codice IPA da usare nella trasmissione. Andare nella maschera CONFIGURAZIONE - CODICE IPA')
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
				IF (@codice_istat_ente IS NULL OR @codice_istat_ente = '')
				BEGIN
					SET @message = @message + ' Il codice ISTAT'
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
					AND NOT EXISTS (SELECT * FROM paydispositiondetail WHERE paymentcommunicated.idexp =paydispositiondetail.idexp  ) 
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
					AND (paymethod.abi_label IS NULL OR REPLACE(paymethod.abi_label,' ','') = '')
				)

				-- CONTROLLO N. 4. Codice IBAN o ABI o CAB devono essere valorizzati nel caso di modalità di pagamento '02'
				--- ABI, CAB, CIN, NUMERO CONTO obbligatori in caso di BONIFICI
				--- NUMERO CONTO obbligatorio in caso di BOLLETTINO CCP
				--INSERT INTO #error (message)
				--(SELECT 'Al movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
				--+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' nella modalità di pagamento scelta non è stato assegnato il codice ABI / CAB.'
				--FROM paymentcommunicated
				--	JOIN paymethod
				--	ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
				--WHERE paymentcommunicated.ypaymenttransmission = @y
				--	AND paymentcommunicated.npaymenttransmission = @n
				--	AND paymethod.abi_label  in ('SEPACREDITTRANSFER')
				--	AND (
				--		(paymentcommunicated.idcab IS NULL OR REPLACE(paymentcommunicated.idcab,' ','') = '')
				--		OR (paymentcommunicated.idbank IS NULL OR REPLACE(paymentcommunicated.idbank,' ','') = '')
				--	)
				--	AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
				--)

				-- CONTROLLO N. 7. Conto Corrente valorizzato e di lunghezza massima 12 caratteri nel caso di modalità di pagamento 2
				-- BONIFICO BANCARIO E POSTALE
				IF EXISTS
				(SELECT * FROM paymentcommunicated
				JOIN paymethod
					ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
				WHERE paymentcommunicated.ypaymenttransmission = @y
					AND paymentcommunicated.npaymenttransmission = @n
					AND paymethod.abi_label  IN ('ACCREDITOCONTOCORRENTEPOSTALE')
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
					AND paymethod.abi_label IN ('ACCREDITOCONTOCORRENTEPOSTALE')
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


				-- CONTROLLO N. 10. Uso di modlaità di pagamento NON ammesse dalla banca-  vedi Specifiche tracciato
				INSERT INTO #error (message)
				(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
				+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' non è stata specificato il tipo pagamento SIOPE+.'
				FROM paymentcommunicated
				JOIN paymethod
					ON paymentcommunicated.idpaymethod = paymethod.idpaymethod
				WHERE paymentcommunicated.ypaymenttransmission = @y
					AND paymentcommunicated.npaymenttransmission = @n
					AND paymethod.abi_label IS NULL
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
					AND paymethod.abi_label  = 'ACCREDITOCONTOCORRENTEPOSTALE'
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


				-- CONTROLLO N. 14. codice contabilita speciale errato o mancante, controllare regole su codice contabilità speciale girofondi
				IF EXISTS
				(SELECT * FROM paymentcommunicated
						join expenselast			        ON paymentcommunicated.idexp = expenselast.idexp
						join expense						on expenselast.idexp = expense.idexp 
						join registrypaymethod				on registrypaymethod.idreg = expense.idreg
								and registrypaymethod.idpaymethod = expenselast.idpaymethod
								and registrypaymethod.idregistrypaymethod = expenselast.idregistrypaymethod
						JOIN paymethod	     				ON expenselast.idpaymethod = paymethod.idpaymethod
				WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission					
					AND ((expenselast.paymethod_flag & (256+512) )<>0 )  -- modalità di pagamento girofondo, valutare il girofondo A F24EP
					AND (ISNULL(expenselast.extracode,registrypaymethod.extracode) IS NULL
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
						join expenselast		ON paymentcommunicated.idexp = expenselast.idexp
						join expense			on expenselast.idexp = expense.idexp 
						join registrypaymethod	on registrypaymethod.idreg = expense.idreg
													and registrypaymethod.idpaymethod = expenselast.idpaymethod
													and registrypaymethod.idregistrypaymethod = expenselast.idregistrypaymethod
						JOIN paymethod			ON expenselast.idpaymethod = paymethod.idpaymethod
						WHERE paymentcommunicated.kpaymenttransmission = @kpaymenttransmission
							AND	(expenselast.paymethod_flag & (256+512) )<>0     -- modalità di pagamento girofondo, valutare il girofondo A F24EP
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
	

				-- CONTROLLO  Submovimenti bancari non generati, manca il progressivo beneficiario
				INSERT INTO #error (message)
				(SELECT 'Il movimento n.' + CONVERT(varchar(6),E.nmov) 
				+ '/' + CONVERT(varchar(4),E.ymov) + ' non ha un progressivo beneficiario associato. E'' necessario risalvare il mandato '  + CONVERT(varchar(6),P.npay) 
				+ '/' + CONVERT(varchar(4),P.ypay)
				FROM expense E
				JOIN expenselast EL	(NOLOCK)					ON E.idexp = EL.idexp
				JOIN payment P		 (NOLOCK)					ON P.kpay = EL.kpay
				JOIN paymenttransmission PT	(NOLOCK)			ON PT.kpaymenttransmission = P.kpaymenttransmission
				WHERE   PT.kpaymenttransmission = @kpaymenttransmission AND EL.idpay IS NULL
				)

				-- CONTROLLO N. 16. Avviso PagoPa con Creditore senza CF  
				INSERT INTO #error (message)
				(SELECT 'Nel movimento n.' + CONVERT(varchar(6),paymentcommunicated.nmov) 
				+ '/' + CONVERT(varchar(4),paymentcommunicated.ymov) + ' è stata usata la modalità di pagamento Avviso PagoPA ma l''anagrafica non ha codice fiscale '
				FROM paymentcommunicated
				join expenselast		ON paymentcommunicated.idexp = expenselast.idexp
				join expense			on expenselast.idexp = expense.idexp 
				JOIN paymethod			ON expenselast.idpaymethod = paymethod.idpaymethod
				join registry on expense.idreg = registry.idreg
				WHERE paymentcommunicated.ypaymenttransmission = @y
					AND paymentcommunicated.npaymenttransmission = @n
					AND paymethod.abi_label  = 'AVVISOPAGOPA'
					and registry.cf is null
					--AND ((paymentcommunicated.flag & 1) = 0)   -- non a copertura
				)

				IF (SELECT COUNT(*) FROM #error) > 0
				BEGIN
					SELECT * FROM #error
					return  
				END
End
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
	autokind int,
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
	abi_label varchar(100),
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
	exemption_stamp_motive varchar(20),
	destinazione varchar(20),
	tipo_contabilita_ente_ricevente varchar(20),
	girofondo char(1),
	deny_bank_details char(1),
	extracode varchar(7),
	paymentdescr varchar(370),
	--txt varchar(200), 
	expenselast_paymentdescr varchar(150),
	fulfilled char(1),
	chargehandling varchar(50),
	exemption_charge_payment_kind varchar(100),
	exemption_charge_motive varchar(100),
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
	cigcodemandate varchar(10),
	expiration datetime,
	bank_charges_exempt char(1),
	pagopanoticenum varchar(30),
	nClassSiope int
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

-- Tabella della classificazione SIOPE
CREATE TABLE #siope
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	idpay int,
	progressive int,
	sortcode varchar(50),
	sorting varchar(200),
	importoclassificazionemov decimal(19,2),
	idexp int,
	cupcodefin varchar(15),
	cupcodeupb varchar(15),
	cupcodedetail varchar(15), 
	cupcodeexpense varchar(15),

	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE (*1)
	codice_cig_siope varchar(10),
	motivo_esclusione_cig_siope varchar(50),
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	importo_siope decimal(19,2),
	natura_spesa_siope varchar(10), -- CORRENTE o CAPITALE,
	utilizzo_nota_di_credito varchar(30),
	data_scadenza_pagam_siope datetime,
	motivo_scadenza_siope varchar(50),
	flagnc char(1)
)


-- Tabella delle informazioni aggiuntive richieste dall'Ente
CREATE TABLE #note
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	idpay int,
	idexp int,
	progressive int,
	testo varchar(500)
)


-- Inserimento dei movimenti di spesa presenti nella distinta di trasmissione
if(@n is not null)
Begin
		INSERT INTO #payment
		(
			ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idexp, autokind,
			ymov, nmov, nphase, phase,
			flagcr, curramount,  
			idreg, expense_adate, payment_adate, transmissiondate, 	
			stamphandling,stamp_charge, exemption_stamp_motive, 
			destinazione, tipo_contabilita_ente_ricevente,
			abi_label,  ABI, CAB, cc, cin_iban, cin, codice_paese, bank, iban, biccode, id_end_to_end , 
			code, proprietary,
			title_ben, cf_ben, pi_ben , 
			paymentdescr, expenselast_paymentdescr, fulfilled, uncharged, girofondo,deny_bank_details,
			extracode, iddeputy, refexternaldoc, nbill, idpay, 
			idpaydisposition,iddetail,codeupb, upbtitle,
			codefin, fintitle, 
			nlevel,finlevel,
			cupcodefin,cupcodeupb,cupcodeexpense, cigcodeexpense, --txt,
			cupcodedetail, cigcodemandate,
			chargehandling,
			exemption_charge_payment_kind,
			exemption_charge_motive,
			expiration,
			pagopanoticenum,
			nClassSiope
		)
		SELECT
			t.ypaymenttransmission, t.npaymenttransmission, d.ypay, d.npay, s.idexp,  s.autokind,
			s.ymov, s.nmov, s.nphase, eph.description, 
			CASE
				WHEN ((i.flag&1)=0) THEN 'C'
				WHEN ((i.flag&1)=1) THEN 'R'
			END, 
			i.curramount,
			s.idreg, s.adate, 
			case when @n is not null then d.adate else s.adate end,
			 t.transmissiondate, 
			tb.description, 
			CASE 
				WHEN (tb.flag&0) <> 0 THEN 'N'
				ELSE 'S'
			END, --esenzione bollo
			ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
		 
			@destinazione, -- informazione destinazione (LIBERA/VINCOLATA) obbligatoria perchè l'Ente è in regime TU
			CASE
				WHEN (m.abi_label   not in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP'))  THEN NULL
				WHEN (m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  AND ((el.paymethod_flag & 4096) = 0)) THEN 'INFRUTTIFERA'  
				WHEN (m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  AND ((el.paymethod_flag & 4096)  <> 0)) THEN 'FRUTTIFERA'  
			END, -- informazioni obbligatorie solo per i girofondi in BI
			LTRIM(RTRIM(m.abi_label)),
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
			substring(ISNULL(el.cc,''),1,25),
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
				WHEN /*ctc.flaghuman = 'S' AND*/ c.cf IS NOT NULL THEN c.cf  
				--WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN SPACE(@len_cf)
				--ELSE SPACE(@len_cf)
				else null
			END,
			CASE
				WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
					AND DATALENGTH(c.p_iva) <= @len_pi
				THEN  ISNULL(c.p_iva,'') 
				WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
					AND DATALENGTH(c.p_iva) > @len_pi
				THEN SUBSTRING(c.p_iva, 1, @len_pi)
				ELSE null--REPLICATE('',@len_pi)
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
						m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP') 
				   )   THEN 'S'		--girofondo
				ELSE 'N'
			END,
			CASE
				WHEN ((el.paymethod_flag & 8)<>0) and ((el.paymethod_flag & 2)=0) then  'S'
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
			el.nbill,
			el.idpay,
			null,0,
			upb.codeupb, upb.title,
			fin.codefin, fin.title, 
			fin.nlevel,finlevel.description,
			ltrim(rtrim(finlast.cupcode))  ,
			ltrim(rtrim(u.cupcode)),
			ltrim(rtrim(RegPhase.cupcode)),
			ltrim(rtrim(RegPhase.cigcode)), 
			--ltrim(rtrim(substring(s.txt, 1, 200))),
			null,null,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @handlingbankcode_default ELSE  chargehandling.handlingbankcode END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @payment_kind_default ELSE chargehandling.payment_kind END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @motive_default ELSE chargehandling.motive END,
			s.expiration,
			el.pagopanoticenum,
			(select count(distinct sorting.idsor) from expensesorted 
					join sorting  on expensesorted.idsor= sorting.idsor
					where expensesorted.idexp= s.idexp and sorting.idsorkind=@classSIOPE)
		FROM expense s
		JOIN expenselast el						ON S.idexp = el.idexp
		JOIN expensetotal i						ON i.idexp = s.idexp
		JOIN expenseyear y						ON y.idexp = s.idexp 
		JOIN expensephase eph					ON eph.nphase = s.nphase
		JOIN upb								ON upb.idupb = y.idupb
		JOIN fin								ON fin.idfin = y.idfin
		JOIN finlevel							ON fin.nlevel = finlevel.nlevel	AND finlevel.ayear = y.ayear
		JOIN registry c							ON c.idreg = s.idreg
		JOIN registryclass ctc					ON ctc.idregistryclass = c.idregistryclass
		JOIN upb u								ON u.idupb = y.idupb
		JOIN fin f1								ON f1.idfin = y.idfin
		JOIN finlast							ON finlast.idfin = f1.idfin
		JOIN fin f								ON y.idfin = f.idfin
		JOIN expenselink as RegPhaseELK			ON RegPhaseELK.idchild = el.idexp	AND RegPhaseELK.nlevel = @expenseregphase -- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
		JOIN expense RegPhase					ON RegPhase.idexp = RegPhaseELK.idparent  -- fase del Creditore
		JOIN payment d							ON d.kpay = el.kpay
		JOIN paymenttransmission t				ON t.kpaymenttransmission = d.kpaymenttransmission
		left outer JOIN paymethod m				ON el.idpaymethod = m.idpaymethod
		LEFT OUTER JOIN registrypaymethod mcd	ON mcd.idregistrypaymethod = el.idregistrypaymethod	AND mcd.idreg = s.idreg
		LEFT OUTER JOIN paydispositiondetail p	ON p.idexp = el.idexp 
		LEFT OUTER JOIN bank					ON bank.idbank = el.idbank
		LEFT OUTER JOIN stamphandling tb		ON d.idstamphandling = tb.idstamphandling
		LEFT OUTER JOIN chargehandling 			ON el.idchargehandling = chargehandling.idchargehandling
		WHERE  t.ypaymenttransmission = @y and t.npaymenttransmission = @n
		AND p.iddetail is null ---- righe mandato non associate a dettagli di disposizioni di pagamento in corrispondenza uno a uno

		---------------------------------------------------------------------------------------------
		-- Inserimento dei pagamenti presenti nella distinta di trasmissione che si vuole trasmettere
		--					che siano collegati ai dettagli disposizioni di pagamento              --
		---------------------------------------------------------------------------------------------
		INSERT INTO #payment
		(
			ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idexp, autokind,
			ymov, nmov, nphase, phase,
			flagcr, curramount,  
			idreg, expense_adate, payment_adate, transmissiondate, 	
			stamphandling,stamp_charge, exemption_stamp_motive, 
			destinazione, tipo_contabilita_ente_ricevente,
			abi_label,  ABI, CAB, cc, cin_iban, cin, codice_paese, bank, iban, biccode, id_end_to_end , 
			code, proprietary,
			title_ben, cf_ben, pi_ben , 
			paymentdescr, expenselast_paymentdescr, fulfilled, uncharged, girofondo,deny_bank_details,
			extracode, iddeputy, refexternaldoc, nbill, idpay, 
			idpaydisposition,iddetail,codeupb, upbtitle,
			codefin, fintitle, 
			nlevel,finlevel,
			cupcodefin,cupcodeupb,cupcodeexpense, cigcodeexpense, --txt,
			cupcodedetail, cigcodemandate,
			chargehandling,
			exemption_charge_payment_kind,
			exemption_charge_motive,
			expiration,
			nClassSiope
		)
		select t.ypaymenttransmission, t.npaymenttransmission, d.ypay, d.npay, s.idexp,  s.autokind,
			s.ymov, s.nmov, s.nphase, eph.description, 
			CASE
				WHEN ((i.flag&1)=0) THEN 'C'
				WHEN ((i.flag&1)=1) THEN 'R'
			END, 
			i.curramount,
			null, s.adate, 
			case when @n is not null then d.adate else s.adate end,
			 t.transmissiondate, 
			tb.description, 
			CASE 
				WHEN (tb.flag&0) <> 0 THEN 'N'
				ELSE 'S'
			END, --esenzione bollo
			ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
			@destinazione, -- informazione destinazione (LIBERA/VINCOLATA) obbligatoria perchè l'Ente è in regime TU
			CASE
				WHEN (m.abi_label   not in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP'))  THEN NULL
				WHEN (m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  AND ((el.paymethod_flag & 4096) = 0)) THEN 'INFRUTTIFERA'  
				WHEN (m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  AND ((el.paymethod_flag & 4096)  <> 0)) THEN 'FRUTTIFERA'  
			END, -- informazioni obbligatorie solo per i girofondi in BI
			--- Considero la seguente mappatura tra la modalità di pagamento della disposizione
			--  e la modalità di pagamento ABI 
			CASE
				WHEN (pd.iban IS NOT NULL) THEN 'SEPACREDITTRANSFER' -- bonifico  -- paymethodcode = 1
				WHEN ((pd.paymethodcode = 2) AND (pd.iban IS NULL)) THEN  'CASSA' -- cassa
				WHEN pd.paymethodcode = 3 THEN  'ASSEGNOCIRCOLARE' -- assegno circolare
				WHEN pd.paymethodcode = 4 THEN  'ASSEGNOCIRCOLARE' -- assegno circolare non trasferibile
				WHEN pd.paymethodcode = 5 THEN  'ASSEGNOBANCARIOEPOSTALE' -- assegno quietanza
				WHEN pd.paymethodcode = 6 THEN  'ACCREDITOTESORERIAPROVINCIALESTATOPERTABA' -- girofondo Tab A
				WHEN pd.paymethodcode = 7 THEN  'ACCREDITOTESORERIAPROVINCIALESTATOPERTABB' -- girofondo Tab B
				ELSE 'CASSA' --cassa 
			END, --@len_ABI--LTRIM(RTRIM(m.abi_label)),
			CASE
				WHEN DATALENGTH(ISNULL(pd.abi,'')) <= @len_ABI
				THEN ISNULL(pd.abi,'')
				ELSE SUBSTRING(pd.abi,1,@len_ABI)
			END,
			CASE
				WHEN DATALENGTH(ISNULL(pd.cab,'')) <= @len_CAB
				THEN ISNULL(pd.cab,'')
				ELSE SUBSTRING(pd.cab,1,@len_CAB)
			END,
			substring(ISNULL(pd.cc,''),1,25),
			substring(pd.iban,3,2),
			CASE
				WHEN DATALENGTH(ISNULL(pd.cin,'')) <= @len_cin
				THEN ISNULL(pd.cin,'') 
				ELSE SUBSTRING(pd.cin,1,@len_cin)
			END,
			substring(pd.iban,1,2),
			substring(bancadisposition.description,1,@len_bank),
			ISNULL(pd.iban,''),
			null,-- al momento non abbiamo la possibilità di indicare il bic /swift sulle disposizioni di pagamento-ISNULL(el.biccode,''),
			null,
			null,
			null,
			ISNULL(pd.title,ISNULL(pd.surname,'') + ' ' +  ISNULL(pd.forename,'') ),
			CASE
				WHEN pd.flaghuman = 'S' AND pd.cf IS NOT NULL
				THEN pd.cf  
				WHEN pd.flaghuman = 'S' AND pd.cf IS NULL
				THEN SPACE(@len_cf)
				ELSE SPACE(@len_cf)
			END,
			CASE
				WHEN pd.flaghuman = 'N' AND pd.p_iva IS NOT NULL AND DATALENGTH(pd.p_iva) <= @len_pi
				THEN ISNULL(pd.p_iva,'') 
				WHEN pd.flaghuman = 'N' AND pd.p_iva IS NOT NULL AND DATALENGTH(pd.p_iva) > @len_pi
				THEN SUBSTRING(pd.p_iva, 1, @len_pi)
				ELSE SPACE(@len_pi)
			END,
			---- paymentdescr:
			COALESCE(pd.motive, p.motive,ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'')),
			el.paymentdescr,
			'N', -- non può essere a regolarizzazione  
			CASE
				WHEN (( el.flag & 8)<>0) then 'S' --uncharged
				ELSE 'N'
			END, 
			CASE
				WHEN
				   (
						m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB') 
				   )   THEN 'S'		--girofondo
				ELSE 'N'
			END, -- può essere girofondo 
			CASE
				WHEN ((el.paymethod_flag & 8)<>0) and ((el.paymethod_flag & 2)=0) then  'S'
				ELSE 'N'
			END, --deny_bank_details -- vieta  coordinate bancarie
			CASE
				WHEN DATALENGTH (ISNULL(el.extracode,'')) <= @lencodicecontabilitaspeciale
				THEN SUBSTRING(REPLICATE('0',@lencodicecontabilitaspeciale),1,@lencodicecontabilitaspeciale - DATALENGTH(ISNULL(el.extracode,''))) + ISNULL(el.extracode,'')
				ELSE SUBSTRING(ISNULL(el.extracode,''),1,@lencodicecontabilitaspeciale)
			END	, -- codice contabilità speciale, vale solo per i girofondi
			CASE
				WHEN m.allowdeputy = 'S' THEN el.iddeputy 
				ELSE NULL
			END, -- non ammette delegato
			ISNULL(el.refexternaldoc,''),
			null, -- numero bolletta, non può essere a regolarizzazione
			el.idpay,
			pd.idpaydisposition,pd.iddetail,
			upb.codeupb, upb.title,
			fin.codefin, fin.title, 
			fin.nlevel,finlevel.description,
			ltrim(rtrim(finlast.cupcode))  ,
			ltrim(rtrim(u.cupcode)),
			ltrim(rtrim(RegPhase.cupcode)),
			ltrim(rtrim(RegPhase.cigcode)), 
			--ltrim(rtrim(substring(s.txt, 1, 200))),
			null,null,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @handlingbankcode_default ELSE  chargehandling.handlingbankcode END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @payment_kind_default ELSE chargehandling.payment_kind END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @motive_default ELSE chargehandling.motive END,
			s.expiration,
			(select count(distinct sorting.idsor) from expensesorted 
					join sorting  on expensesorted.idsor= sorting.idsor
					where expensesorted.idexp= s.idexp and sorting.idsorkind=@classSIOPE)
		FROM expense s
		JOIN expenselast el						ON S.idexp = el.idexp
		JOIN expensetotal i						ON i.idexp = s.idexp
		JOIN expenseyear y						ON y.idexp = s.idexp 
		JOIN expensephase eph					ON eph.nphase = s.nphase
		LEFT OUTER JOIN paymethod m				ON el.idpaymethod = m.idpaymethod
		JOIN upb								ON upb.idupb = y.idupb
		JOIN fin								ON fin.idfin = y.idfin
		JOIN finlevel							ON fin.nlevel = finlevel.nlevel	AND finlevel.ayear = y.ayear
		JOIN registry c							ON c.idreg = s.idreg
		JOIN registryclass ctc					ON ctc.idregistryclass = c.idregistryclass
		JOIN upb u								ON u.idupb = y.idupb
		JOIN fin f1								ON f1.idfin = y.idfin
		JOIN finlast							ON finlast.idfin = f1.idfin
		JOIN fin f								ON y.idfin = f.idfin
		JOIN expenselink as RegPhaseELK			ON RegPhaseELK.idchild = el.idexp	AND RegPhaseELK.nlevel = @expenseregphase -- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
		JOIN expense RegPhase					ON RegPhase.idexp = RegPhaseELK.idparent  -- fase del Creditore
		JOIN payment d							ON d.kpay = el.kpay
		JOIN paymenttransmission t				ON t.kpaymenttransmission = d.kpaymenttransmission
		JOIN paydispositiondetail pd			ON pd.idexp = el.idexp
		JOIN paydisposition p					ON pd.idpaydisposition = p.idpaydisposition
		LEFT OUTER JOIN bank bancadisposition   ON bancadisposition.idbank = pd.abi
		LEFT OUTER JOIN cab sportellodisposition ON sportellodisposition.idbank = pd.abi AND sportellodisposition.idcab = pd.cab
		LEFT OUTER JOIN stamphandling tb		ON d.idstamphandling = tb.idstamphandling
		LEFT OUTER JOIN chargehandling 			ON el.idchargehandling = chargehandling.idchargehandling
		
		WHERE  t.ypaymenttransmission = @y and t.npaymenttransmission = @n
		AND pd.idexp is not null ---- righe mandato associate a dettagli di disposizioni di pagamento in corrispondenza uno a uno
End
Else
Begin
		INSERT INTO #payment
		(
			ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idexp, autokind,
			ymov, nmov, nphase, phase,
			flagcr, curramount,  
			idreg, expense_adate, payment_adate, transmissiondate, 	
			stamphandling,stamp_charge, exemption_stamp_motive, 
			destinazione, tipo_contabilita_ente_ricevente,
			abi_label, ABI, CAB, cc, cin_iban, cin, codice_paese, bank, iban, biccode, id_end_to_end , 
			code, proprietary,
			title_ben, cf_ben, pi_ben , 
			paymentdescr, expenselast_paymentdescr, fulfilled, uncharged, girofondo,deny_bank_details,
			extracode, iddeputy, refexternaldoc, nbill, idpay, 
			idpaydisposition,iddetail,codeupb, upbtitle,
			codefin, fintitle, 
			nlevel,finlevel,
			cupcodefin,cupcodeupb,cupcodeexpense, cigcodeexpense,-- txt,
			cupcodedetail, cigcodemandate,
			chargehandling,
			exemption_charge_payment_kind,
			exemption_charge_motive,
			expiration,
			pagopanoticenum,
			nClassSiope
		)

		SELECT
			@y,--t.ypaymenttransmission,
			9999,-- t.npaymenttransmission, 
			@y, 9999, --d.ypay, d.npay,
			 s.idexp,  s.autokind,
			s.ymov, s.nmov, s.nphase, eph.description, 
			CASE
				WHEN ((i.flag&1)=0) THEN 'C'
				WHEN ((i.flag&1)=1) THEN 'R'
			END, 
			i.curramount,
			s.idreg, s.adate, 
		--	case when @idexp is null then d.adate else s.adate end,
			s.adate,
			s.adate,--t.transmissiondate, 
			'ASSOGGETTATOBOLLOACARICOBENEFICIARIO',--tb.description, 
			--esenzione bollo
			'N',
			/*CASE 
				WHEN (tb.flag&0) <> 0 THEN 'N'
				ELSE 'S'
			END,*/ 
			'12345678901234567890', --ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
			 
			@destinazione, -- informazione destinazione (LIBERA/VINCOLATA) obbligatoria perchè l'Ente è in regime TU
			CASE
				WHEN (m.abi_label not  in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  ) THEN 'INFRUTTIFERA'  
				WHEN (m.abi_label  in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  
					 AND ((el.paymethod_flag & 4096) = 0)) THEN 'INFRUTTIFERA'  
				WHEN (m.abi_label  in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  
					 AND ((el.paymethod_flag & 4096)  <> 0)) THEN 'FRUTTIFERA'  
			END, -- informazioni obbligatorie solo per i girofondi in BI
			LTRIM(RTRIM(m.abi_label)),
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
			substring(ISNULL(el.cc,''),1,25),
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
				WHEN /*ctc.flaghuman = 'S' AND*/ c.cf IS NOT NULL THEN c.cf  
				--WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN SPACE(@len_cf)
				--ELSE SPACE(@len_cf)
				else null
			END,
			CASE
				WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
					AND DATALENGTH(c.p_iva) <= @len_pi
				THEN  ISNULL(c.p_iva,'') 
				WHEN ctc.flaghuman = 'N' AND c.p_iva IS NOT NULL
					AND DATALENGTH(c.p_iva) > @len_pi
				THEN SUBSTRING(c.p_iva, 1, @len_pi)
				ELSE null--REPLICATE('',@len_pi)
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
					m.abi_label in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP') 
			    )   THEN 'S'
				ELSE 'N'
			END,
			CASE
				WHEN ((el.paymethod_flag & 8)<>0) and ((el.paymethod_flag & 2)=0) then  'S'--deny_bank_details 
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
			ROW_NUMBER() over (order by s.ymov asc)+1000, --6 
			null,0,
			upb.codeupb, upb.title,
			fin.codefin, fin.title, 
			fin.nlevel,finlevel.description,
			ltrim(rtrim(finlast.cupcode))  ,
			ltrim(rtrim(u.cupcode)),
			ltrim(rtrim(RegPhase.cupcode)),
			ltrim(rtrim(RegPhase.cigcode)), 
			--ltrim(rtrim(substring(s.txt, 1, 200))),
			null,null,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @handlingbankcode_default ELSE  chargehandling.handlingbankcode END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @payment_kind_default ELSE chargehandling.payment_kind END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @motive_default ELSE chargehandling.motive END,
			s.expiration,
			el.pagopanoticenum,
			(select count(distinct sorting.idsor) from expensesorted 
					join sorting  on expensesorted.idsor= sorting.idsor
					where expensesorted.idexp= s.idexp and sorting.idsorkind=@classSIOPE)
		FROM expense s
		JOIN @lista_id on [@lista_id].n=s.idexp
		JOIN expenselast el				ON S.idexp = el.idexp
		JOIN expensetotal i				ON i.idexp = s.idexp
		JOIN expenseyear y				ON y.idexp = s.idexp 
		JOIN expensephase eph			ON eph.nphase = s.nphase
		JOIN upb						ON upb.idupb = y.idupb
		JOIN fin						ON fin.idfin = y.idfin
		JOIN finlevel					ON fin.nlevel = finlevel.nlevel		AND finlevel.ayear = y.ayear
		JOIN expenselink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
			ON RegPhaseELK.idchild = el.idexp	AND RegPhaseELK.nlevel = @expenseregphase
		JOIN expense RegPhase			ON RegPhase.idexp = RegPhaseELK.idparent -- fase del Creditore
		JOIN registry c					ON c.idreg = s.idreg
		JOIN registryclass ctc 			ON ctc.idregistryclass = c.idregistryclass
		JOIN fin f						ON y.idfin = f.idfin
		JOIN upb u						ON u.idupb = y.idupb
		JOIN fin f1						ON f1.idfin = y.idfin
		JOIN finlast					ON finlast.idfin = f1.idfin
		LEFT OUTER JOIN paydispositiondetail p	ON p.idexp = el.idexp	
		LEFT OUTER JOIN bank			ON bank.idbank = el.idbank
		LEFT OUTER JOIN chargehandling 	ON el.idchargehandling = chargehandling.idchargehandling
		LEFT OUTER JOIN registrypaymethod mcd			ON mcd.idregistrypaymethod = el.idregistrypaymethod		AND mcd.idreg = s.idreg
		left outer JOIN paymethod m		ON el.idpaymethod = m.idpaymethod
		where p.iddetail is null	 
 
		---------------------------------------------------------------------------------------------
		-- Inserimento dei pagamenti presenti nella distinta di trasmissione che si vuole trasmettere
		-- che siano collegati alle disposizioni di pagamento							           --
		---------------------------------------------------------------------------------------------

		INSERT INTO #payment
		(
			ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idexp, autokind,
			ymov, nmov, nphase, phase,
			flagcr, curramount,  
			idreg, expense_adate, payment_adate, transmissiondate, 	
			stamphandling,stamp_charge, exemption_stamp_motive, 
			destinazione, tipo_contabilita_ente_ricevente,
			abi_label, ABI, CAB, cc, cin_iban, cin, codice_paese, bank, iban, biccode, id_end_to_end , 
			code, proprietary,
			title_ben, cf_ben, pi_ben , 
			paymentdescr, expenselast_paymentdescr, fulfilled, uncharged, girofondo,deny_bank_details,
			extracode, iddeputy, refexternaldoc, nbill, idpay, 
			idpaydisposition,iddetail,codeupb, upbtitle,
			codefin, fintitle, 
			nlevel,finlevel,
			cupcodefin,cupcodeupb,cupcodeexpense, cigcodeexpense, --txt,
			cupcodedetail, cigcodemandate,
			chargehandling,
			exemption_charge_payment_kind,
			exemption_charge_motive,
			expiration,
			nClassSiope
		)

		SELECT
			@y,--t.ypaymenttransmission,
			9999,-- t.npaymenttransmission, 
			@y, 9999, --d.ypay, d.npay,
			 s.idexp,  s.autokind,
			s.ymov, s.nmov, s.nphase, eph.description, 
			CASE
				WHEN ((i.flag&1)=0) THEN 'C'
				WHEN ((i.flag&1)=1) THEN 'R'
			END, 
			i.curramount,
			null, s.adate, 
		--	case when @idexp is null then d.adate else s.adate end,
			s.adate,
			s.adate,--t.transmissiondate, 
			'ASSOGGETTATOBOLLOACARICOBENEFICIARIO',--tb.description, 
			--esenzione bollo
			'N',
			'12345678901234567890', --ISNULL(tb.handlingbankcode,''), -- causale esenzione bollo
			@destinazione, -- informazione destinazione (LIBERA/VINCOLATA) obbligatoria perchè l'Ente è in regime TU
			CASE
				WHEN (m.abi_label   not in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP'))  THEN NULL
				WHEN (m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  AND ((el.paymethod_flag & 4096) = 0)) THEN 'INFRUTTIFERA'  
				WHEN (m.abi_label   in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB','FE4EP')  AND ((el.paymethod_flag & 4096)  <> 0)) THEN 'FRUTTIFERA'  
			END, -- informazioni obbligatorie solo per i girofondi in BI
			--- Considero la seguente mappatura tra la modalità di pagamento della disposizione
			--  e la modalità di pagamento ABI 
			CASE
				WHEN (pd.iban IS NOT NULL) THEN 'SEPACREDITTRANSFER' -- bonifico  -- paymethodcode = 1
				WHEN ((pd.paymethodcode = 2) AND (pd.iban IS NULL)) THEN  'CASSA' -- cassa
				WHEN pd.paymethodcode = 3 THEN  'ASSEGNOCIRCOLARE' -- assegno circolare
				WHEN pd.paymethodcode = 4 THEN  'ASSEGNOCIRCOLARE' -- assegno circolare non trasferibile
				WHEN pd.paymethodcode = 5 THEN  'ASSEGNOBANCARIOEPOSTALE' -- assegno quietanza
				WHEN pd.paymethodcode = 6 THEN  'ACCREDITOTESORERIAPROVINCIALESTATOPERTABA' -- girofondo Tab A
				WHEN pd.paymethodcode = 7 THEN  'ACCREDITOTESORERIAPROVINCIALESTATOPERTABB' -- girofondo Tab B
				ELSE 'CASSA' --cassa 
			END, --@len_ABI--LTRIM(RTRIM(m.abi_label)),

			CASE
				WHEN DATALENGTH(ISNULL(pd.abi,'')) <= @len_ABI
				THEN ISNULL(pd.abi,'')
				ELSE SUBSTRING(pd.abi,1,@len_ABI)
			END,
			CASE
				WHEN DATALENGTH(ISNULL(pd.cab,'')) <= @len_CAB
				THEN ISNULL(pd.cab,'')
				ELSE SUBSTRING(pd.cab,1,@len_CAB)
			END,
			substring(ISNULL(pd.cc,''),1,25),
			substring(pd.iban,3,2),
			CASE
				WHEN DATALENGTH(ISNULL(pd.cin,'')) <= @len_cin
				THEN ISNULL(pd.cin,'') 
				ELSE SUBSTRING(pd.cin,1,@len_cin)
			END,
			substring(pd.iban,1,2),
			substring(bancadisposition.description,1,@len_bank),
			ISNULL(pd.iban,''), ---LTRIM(RTRIM(m.abi_label)),
			null,
			null,
			null,
			null,
			ISNULL(pd.title,ISNULL(pd.surname,'') + ' ' +  ISNULL(pd.forename,'') ),
			CASE
				WHEN pd.flaghuman = 'S' AND pd.cf IS NOT NULL
				THEN pd.cf  
				WHEN pd.flaghuman = 'S' AND pd.cf IS NULL
				THEN SPACE(@len_cf)
				ELSE SPACE(@len_cf)
			END,
			CASE
				WHEN pd.flaghuman = 'N' AND pd.p_iva IS NOT NULL AND DATALENGTH(pd.p_iva) <= @len_pi
				THEN ISNULL(pd.p_iva,'') 
				WHEN pd.flaghuman = 'N' AND pd.p_iva IS NOT NULL AND DATALENGTH(pd.p_iva) > @len_pi
				THEN SUBSTRING(pd.p_iva, 1, @len_pi)
				ELSE SPACE(@len_pi)
			END,
			---- paymentdescr:
			ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,''),
			el.paymentdescr,
			'N', -- non può essere a regolarizzazione 
			CASE
				WHEN (( el.flag & 8)<>0) then 'S' --uncharged
				ELSE 'N'
			END, 
			'N', -- non può essere girofondo 
			'N', --deny_bank_details -- vieta  coordinate bancarie
			SPACE(@lencodicecontabilitaspeciale), -- codice contabilità speciale, vale solo per i girofondi
			null, -- non ammette delegato
			null, -- riferimento documento esterno
			null, -- numero bolletta, non può essere a regolarizzazione
			ROW_NUMBER() over (order by s.ymov asc)+1000, --6 
			pd.idpaydisposition,pd.iddetail,
			upb.codeupb, upb.title,
			fin.codefin, fin.title, 
			fin.nlevel,finlevel.description,
			ltrim(rtrim(finlast.cupcode))  ,
			ltrim(rtrim(u.cupcode)),
			ltrim(rtrim(RegPhase.cupcode)),
			ltrim(rtrim(RegPhase.cigcode)), 
			--ltrim(rtrim(substring(s.txt, 1, 200))),
			null,null,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @handlingbankcode_default ELSE  chargehandling.handlingbankcode END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @payment_kind_default ELSE chargehandling.payment_kind END,
			CASE WHEN chargehandling.idchargehandling IS NULL THEN @motive_default ELSE chargehandling.motive END,
			s.expiration,
			(select count(distinct sorting.idsor) from expensesorted 
					join sorting  on expensesorted.idsor= sorting.idsor
					where expensesorted.idexp= s.idexp and sorting.idsorkind=@classSIOPE)
		FROM expense s
		JOIN @lista_id on [@lista_id].n=s.idexp
		JOIN expenselast el				ON S.idexp = el.idexp
		JOIN expensetotal i				ON i.idexp = s.idexp
		JOIN expenseyear y				ON y.idexp = s.idexp 
		JOIN expensephase eph			ON eph.nphase = s.nphase
		JOIN upb						ON upb.idupb = y.idupb
		JOIN fin						ON fin.idfin = y.idfin
		JOIN finlevel					ON fin.nlevel = finlevel.nlevel		AND finlevel.ayear = y.ayear
		JOIN expenselink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore per recuperare CUP e CIG
			ON RegPhaseELK.idchild = el.idexp	AND RegPhaseELK.nlevel = @expenseregphase
		JOIN expense RegPhase			ON RegPhase.idexp = RegPhaseELK.idparent -- fase del Creditore
		JOIN fin f						ON y.idfin = f.idfin
		JOIN upb u						ON u.idupb = y.idupb
		JOIN fin f1						ON f1.idfin = y.idfin
		JOIN finlast					ON finlast.idfin = f1.idfin
	
		JOIN paydispositiondetail pd	ON pd.idexp = el.idexp	 
		JOIN paydisposition p			on p.idpaydisposition = pd.idpaydisposition   
		LEFT OUTER JOIN bank bancadisposition	ON bancadisposition.idbank = pd.abi
		LEFT OUTER JOIN cab sportellodisposition	ON sportellodisposition.idbank = pd.abi	AND sportellodisposition.idcab = pd.cab
		LEFT OUTER JOIN chargehandling 	ON el.idchargehandling = chargehandling.idchargehandling
		LEFT OUTER JOIN registrypaymethod mcd			ON mcd.idregistrypaymethod = el.idregistrypaymethod		AND mcd.idreg = s.idreg
		left outer JOIN paymethod m		ON el.idpaymethod = m.idpaymethod
		where pd.iddetail is not null
End	

-- Valorizza codice cup da eventuali -----
-- contabilizzazioni di dettagli ordine --
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX( ltrim(rtrim(cupcode)) )
		  FROM mandatedetail
		 WHERE (idexp_taxable IN (SELECT EL1.idparent 
									FROM expenselink EL1
								   WHERE EL1.idchild = #payment.idexp and EL1.nlevel=@fasecontrattopassivo) 
			OR idexp_iva IN (SELECT EL2.idparent 
							   FROM expenselink EL2
							  WHERE EL2.idchild = #payment.idexp and EL2.nlevel=@fasecontrattopassivo))
		   AND cupcode IS NOT NULL)
	where cupcodeexpense is null

-- Valorizza il codice CGI eventualmente presente del contratto passivo
UPDATE #payment SET cigcodemandate = 
	   (SELECT ltrim(rtrim(mandate.cigcode))
			FROM mandate 
				JOIN expensemandate ON expensemandate.idmankind = mandate.idmankind AND 
					 expensemandate.yman = mandate.yman AND
					expensemandate.nman = mandate.nman
		 WHERE (expensemandate.idexp  = (SELECT idparent 
									       FROM expenselink 
								          WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo) 
		 ))
		where cigcodeexpense is null

-- Valorizza il codice CIG eventualmente presente nella fattura
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX( invoicedetail.cigcode )
			FROM invoicedetail 
		WHERE invoicedetail.cigcode<>replicate('0',10) --a volte scrivono i dieci 0
			and (invoicedetail.idexp_taxable = #payment.idexp
				OR invoicedetail.idexp_iva = #payment.idexp)

		)
where cigcodeexpense is null and cigcodemandate is null		 

-- Valorizza il codice CUP eventualmente presente nella fattura
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX( ltrim(rtrim(invoicedetail.cupcode)) )
			FROM invoicedetail 
		 WHERE (invoicedetail.idexp_taxable = #payment.idexp
				OR invoicedetail.idexp_iva =#payment.idexp)
		)	
where cupcodeexpense is null and cupcodedetail is null		

UPDATE #payment SET CIG = ISNULL(cigcodeexpense,ISNULL(cigcodemandate,''))  --Codice CIG
UPDATE #payment SET CUP = ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, ISNULL(cupcodefin,'')))) --Codice CUP

UPDATE #payment SET paymentdescr = (SELECT
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
	
-- Valorizzo l'identificativo End to End per i Bonifici SEPA
UPDATE #payment SET id_end_to_end =SUBSTRING(CONVERT(VARCHAR(4),ydoc) + '_'+ CONVERT(VARCHAR(8),ndoc) +'_'+ CONVERT(VARCHAR(6),idpay),1,35)
WHERE (abi_label in('SEPACREDITTRANSFER') AND (fulfilled = 'N')) 

UPDATE #payment SET  abi_label = 'DISPOSIZIONEDOCUMENTOESTERNO' WHERE idpaydisposition IS NOT NULL  and iddetail is null



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


DECLARE @maxincomephase char(1)
SELECT @maxincomephase = MAX(nphase) FROM incomephase

if(@n is not null )
Begin
			-- CONTROLLO N. 13 Controllo che i movimenti di entrata associati ai movimenti di spesa che stiamo trasmettendo siano stati inseriti
			-- in una distinta di trasmissione
			INSERT INTO #error (message)
			SELECT 'Il movimento di entrata ' + CONVERT(varchar(6),I.nmov) + '/' + CONVERT(varchar(4),I.ymov)
			+ ' associato al movimento di spesa ' + CONVERT(varchar(6),E.nmov) + '/' + CONVERT(varchar(4),E.nmov)
			+ ' non è stato inserito in una distinta di trasmissione'
			FROM #payment P
			JOIN income I					ON I.idpayment = P.idexp	
			JOIN expense E					ON P.idexp = E.idexp
			JOIN incomelast IL				ON I.idinc = il.idinc
			JOIN incometotal IT				ON I.idinc = IT.idinc
			LEFT OUTER JOIN proceeds S		ON S.kpro = IL.kpro
			LEFT OUTER JOIN proceedstransmission T				ON S.kproceedstransmission = T.kproceedstransmission
			WHERE I.nphase = @maxincomephase
				AND ( -- (I.autokind = 6) /* <--Recupero*/	
						--OR (I.autokind = 14) /*<--automatismo generico*/
						--OR (I.autokind = 4 AND I.idreg = P.idreg)/*<--Ritenuta*/
					    (I.autokind in (4,6,7,14,20,21,30,31)) )
				AND I.idreg = P.idreg
				AND IT.ayear = @y
				AND T.yproceedstransmission IS NULL

			IF (SELECT COUNT(*) FROM #error) > 0
			BEGIN
				SELECT * FROM #error 
				RETURN	
			END
End

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
update #payment set abi_label = 'COMPENSAZIONE' /*compensazione*/ where saldo = 0 -- pagamenti di pari importo con incassi


UPDATE #payment SET  code = 'SALA' WHERE abi_label <> 'COMPENSAZIONE' and autokind  = 30  /*lordi stipendi*/ /*and idreg = @idreg_csa*/

UPDATE #payment SET  code = 'SALA' WHERE abi_label <> 'COMPENSAZIONE' and autokind = 31   /*recuperi e ritenute negative stipendi generati nella fase lordi*/ /*and idreg = @idreg_csa*/
AND EXISTS (SELECT * FROM csa_importver_partition_expense where csa_importver_partition_expense.idexp =  #payment.idexp and csa_importver_partition_expense.movkind in (8,16))

-- fare in modo che nell'OPI dei pagamenti degli stipendi generati dalla fase Lordi ad anagrafica DIVERSI e che 
-- hanno come modalità di pagamento COMPENSAZIONE (e quindi hanno Importo Netto = zero), gli elementi <importo_mandato> e <importo_beneficiario> coincidano,
-- equivale a chiedere che siano mandati singoli.


-- CONTROLLO   In caso di pagamenti a compensazione intestati ad anagrafiche cumulative, 
-- essi dovranno essere inseriti in mandati singoli
--IF (@n is not null)
--begin
--	INSERT INTO #error (message)
--	(SELECT 'Il movimento n.' + CONVERT(varchar(6),P.nmov) 
--	+ '/' + CONVERT(varchar(4),P.ymov) + ' a compensazione intestato ad anagrafica cumulativa (ad es. DIVERSI/STIPENDI), deve essere inserito in un mandato singolo'
--	FROM expenselast EL 
--	JOIN #payment P					ON P.idexp = EL.idexp
--	WHERE /* P.kpaymenttransmission = @kpaymenttransmission
--	and*/ P.idreg = @idreg_csa and P.abi_label = 'COMPENSAZIONE'
--	and  (select count(*) from expenselast EL1 where EL.kpay = EL1.kpay)>1
--)
--end
--select * from #address where idreg in (select iddeputy from #deputy)
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	return -- TODO rimuovere il commento
END


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
IF (@n is not null)
Begin
	SET @dateindi = (SELECT transmissiondate FROM paymenttransmission WHERE ypaymenttransmission = @y AND npaymenttransmission = @n)
End
Else
Begin
	SET @dateindi = (SELECT max(adate) FROM expense WHERE idexp in (select n from @lista_id))
End

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
LEFT OUTER JOIN geo_city		ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country		ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation		ON geo_nation.idnation = registryaddress.idnation
LEFT OUTER JOIN geo_nation_agency	ON geo_nation_agency.idnation = registryaddress.idnation 
								AND geo_nation_agency.idagency = 6 -- ente ISO			
								AND geo_nation_agency.idcode = 1 -- codifica nazioni ISO
								AND geo_nation_agency.version = 1	AND geo_nation_agency.stop IS NULL
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
JOIN expenselast
	ON expenselast.idexp = paydispositiondetail.idexp
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = paydispositiondetail.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = paydispositiondetail.idnation
WHERE  expenselast.idexp in (select  idexp from #payment
 )

 

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
			and iddetail is null
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

-- CONTROLLO N. 13 Ogni delegato estero deve avere una nazione associata
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

-- CONTROLLO N.15. Numero di bollette associati ad un pagamento maggiore di 1000
INSERT INTO #error (message)
(SELECT 'Il movimento n.' + CONVERT(varchar(6),nmov) 
+ '/' + CONVERT(varchar(4),ymov) + ' ha più di 1000 bollette collegate'
FROM expense I
JOIN expenselast IL				ON I.idexp = IL.idexp
JOIN payment P					ON P.kpay = IL.kpay
WHERE P.kpaymenttransmission = @kpaymenttransmission
and (select count(*) from expensebill B where B.idexp = I.idexp)	>1000
)

--select * from #address where idreg in (select iddeputy from #deputy)
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	return -- TODO rimuovere il commento
END


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
		
 
---- Riempimento della tabella con i dati della classificazione SIOPE
DECLARE @npos int


SELECT  @npos  =  
CASE  
	WHEN  (@y<= 2006) THEN  2
	WHEN  (@y BETWEEN 2007 AND 2017) THEN  1
	ELSE   1
END

-- Tabella delle Fatture pagate coi movimenti di spesa incorporati nel flusso 
CREATE TABLE #DocContabilizzato(
	ydoc int,
	ndoc int,
	idpay int,
	idsor_siope int,
	sortcode varchar(30),
	sorting varchar(200),
	--amount decimal(19,2),
	idexp int,
	
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope varchar(10),
	motivo_esclusione_cig_siope varchar(50),
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	flagnc char(1),
	importo_siope decimal(19,2),
	natura_spesa_siope varchar(10),-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito varchar(30), --Contiene il tipo di utilizzo della nota di credito. Può  assumere i seguenti valori: “INCASSO/COMPENSAZIONE” - “SPLIT PAYMENT”
	data_scadenza_pagam_siope datetime,
	motivo_scadenza_siope varchar(50),
	var_present char(1),
	contarigheDettaglioDistinte int
)



 
		INSERT INTO #DocContabilizzato(
			ydoc, ndoc,	idpay, idexp, 

			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
	
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			idsor_siope,
			importo_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present
		)

		SELECT   
			#payment.ydoc, #payment.ndoc, #payment.idpay, #payment.idexp,
			case when (invoicekind.enable_fe='S' or invoicekind.enable_fe_estera='S') THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end, -- (*1)
			#payment.CIG,
			nocigmotive.codenocigmotive,
			coalesce(I.ipa_acq, ipa_ven_emittente, replicate('0',7)),
			case when (invoicekind.enable_fe='S' or invoicekind.enable_fe_estera='S') then 'ELETTRONICO' else 'ANALOGICO' end,
			convert(varchar(20), isnull(sdi_acquisto.identificativo_sdi, sdi_acquistoestere.identificativo_sdi)),
			case when (invoicekind.enable_fe='N' and invoicekind.enable_fe_estera='N') then 'FATT_ANALOGICA' else null end,
			#payment.cf_ben,
			year(I.docdate),
			case when (invoicekind.enable_fe='S') then isnull(sdi_acquisto.ninvoice,substring(I.doc,1,20)) 
			else substring(I.doc,1,20) /*anche per le FE estere va bene I.doc*/
			end,  
			case when ((invoicekind.flag&4)<>0) then 'S' else 'N' end,
			-- idsor_siope
			D.idsor_siope,
			--importo_siope = Contabilizzazione TOTALE,
			 CASE when ((invoicekind.flag&4)<>0) THEN 
				 - (CONVERT(decimal(19,2), ROUND(D.taxable * ISNULL(D.npackage,D.number) * 
					  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
					  (1 - CONVERT(DECIMAL(19,6),ISNULL(D.discount, 0.0))),2
						))+
					CONVERT(decimal(19,2),ROUND(ISNULL(D.tax,0),2))
					)
			else 	CONVERT(decimal(19,2), ROUND(D.taxable * ISNULL(D.npackage,D.number) * 
					  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
					  (1 - CONVERT(DECIMAL(19,6),ISNULL(D.discount, 0.0))),2
						))+
					CONVERT(decimal(19,2),ROUND(ISNULL(D.tax,0),2))
			end,

			case when	isnull((select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO'),0)>
						isnull((select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA'),0)
						then 'CORRENTE'
						else 'CAPITALE'
			end,
			--utilizzo_nota_di_credito
			case when ((invoicekind.flag&4)<>0) 
						then 'INCASSO/COMPENSAZIONE'
						else null
			end,
			-- Data Scadenza Pagamento
			case 
			-- Data contabile(data registrazione)  = Numero gg D.R.F.
			when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
			when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
			-- Data documento = Numero gg  D.F.
			when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
			when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
			-- Fine mese data documento = Numero gg F.M.D.F.
			when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
			when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
			-- Fine mese data contabile = Numero gg F.M.D.R.F.
			when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
			when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
			--	Pagamento Immediato  = data registrazione
			when I.idexpirationkind = 5 then I.adate
			-- Data ricezione
			when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
			when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
			else null
			end,
			-- motivo scadenza siope
			case when  exists (select * from invoicedetail D2 where D2.idinvkind = D.idinvkind and D2.yinv = D.yinv and D2.ninv = D.ninv and D2.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL')) then 'SOSP_DECORRENZA_TERMINI'
				when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
			else null
			end,
			null --case where exists(select * from expensevar where expensevar.idexp = #payment.idexp) then 'S' else 'N'  end
		FROM #payment
		JOIN invoicedetail D			ON #payment.idexp = D.idexp_taxable
		join invoice I					on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
		join invoicekind				on I.idinvkind = invoicekind.idinvkind
		left outer join sdi_acquisto	on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
		left outer join sdi_acquistoestere	on I.idsdi_acquistoestere = sdi_acquistoestere.idsdi_acquistoestere
		left outer join nocigmotive		 on nocigmotive.idnocigmotive = I.idnocigmotive
		where D.idexp_taxable = D.idexp_iva -- Contabilizzazione totale
				--select '1 #DocContabilizzato', * from 	#DocContabilizzato 
			INSERT INTO #DocContabilizzato(
			ydoc, ndoc,	idpay, idexp, 

			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
	
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			idsor_siope,
			importo_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present
		)
		SELECT   
			#payment.ydoc, #payment.ndoc, #payment.idpay, #payment.idexp,
			case when (invoicekind.enable_fe='S' or invoicekind.enable_fe_estera='S' )THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end, 
			#payment.CIG,
			nocigmotive.codenocigmotive,
			coalesce(I.ipa_acq, ipa_ven_emittente, replicate('0',7)),
			case when (invoicekind.enable_fe='S'or invoicekind.enable_fe_estera='S') then 'ELETTRONICO' else 'ANALOGICO' end,
			convert(varchar(20), isnull(sdi_acquisto.identificativo_sdi, sdi_acquistoestere.identificativo_sdi)),
			case when (invoicekind.enable_fe='N' and invoicekind.enable_fe_estera='N') then 'FATT_ANALOGICA' else null end,
			#payment.cf_ben,
			year(I.docdate),
			case when invoicekind.enable_fe='S'  then isnull(sdi_acquisto.ninvoice,substring(I.doc,1,20)) else substring(I.doc,1,20) end,  
			case when ((invoicekind.flag&4)<>0) then 'S' else 'N' end,
			-- idsor_siope
			D.idsor_siope,
			--importo_siope = Contabilizzazione IMPON,
			 CASE when ((invoicekind.flag&4)<>0) THEN 
				 - (CONVERT(decimal(19,2), ROUND(D.taxable * ISNULL(D.npackage,D.number) * 
					  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
					  (1 - CONVERT(DECIMAL(19,6),ISNULL(D.discount, 0.0))),2
						))
					)
			else 	CONVERT(decimal(19,2), ROUND(D.taxable * ISNULL(D.npackage,D.number) * 
					  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
					  (1 - CONVERT(DECIMAL(19,6),ISNULL(D.discount, 0.0))),2
						))
			end,

			case when	isnull((select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO'),0)>
						isnull((select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA'),0)
						then 'CORRENTE'
						else 'CAPITALE'
			end,
				--utilizzo_nota_di_credito
				case when ((invoicekind.flag&4)<>0) 
							then 'INCASSO/COMPENSAZIONE'
							else null
				end,
				-- Data Scadenza Pagamento
				case 
				-- Data contabile(data registrazione)  = Numero gg D.R.F.
				when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
				when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
				-- Data documento = Numero gg  D.F.
				when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
				when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
				-- Fine mese data documento = Numero gg F.M.D.F.
				when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
				when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
				-- Fine mese data contabile = Numero gg F.M.D.R.F.
				when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
				when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
				--	Pagamento Immediato  = data registrazione
				when I.idexpirationkind = 5 then I.adate
				-- Data ricezione
				when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
				when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
			else null
			end,
			case when  exists (select * from invoicedetail D2 where D2.idinvkind = D.idinvkind and D2.yinv = D.yinv and D2.ninv = D.ninv and D2.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL')) then 'SOSP_DECORRENZA_TERMINI'
				when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
			else null
			end,
			null --	case where exists(select * from expensevar where expensevar.idexp = #payment.idexp) then 'S' else 'N'  end
		FROM #payment
		JOIN invoicedetail D			ON #payment.idexp = D.idexp_taxable
		join invoice I					on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
		join invoicekind				on I.idinvkind = invoicekind.idinvkind
		left outer join sdi_acquisto	on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
		left outer join sdi_acquistoestere	on I.idsdi_acquistoestere = sdi_acquistoestere.idsdi_acquistoestere
		left outer join nocigmotive		 on nocigmotive.idnocigmotive = I.idnocigmotive
		where D.idexp_taxable is not null and (D.idexp_iva is null or D.idexp_taxable <> D.idexp_iva ) -- Contabilizzazione SOLO IMPON
					--select '1 #DocContabilizzato', * from 	#DocContabilizzato 
			INSERT INTO #DocContabilizzato(
			ydoc, ndoc,	idpay, idexp, 

			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
	
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			idsor_siope,
			importo_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present
		)
		SELECT   
			#payment.ydoc, #payment.ndoc, #payment.idpay, #payment.idexp,
			case when (invoicekind.enable_fe='S' or invoicekind.enable_fe_estera='S' ) THEN 'COMMERCIALE' ELSE 'NON COMMERCIALE' end, 
			#payment.CIG,
			nocigmotive.codenocigmotive,
			coalesce(I.ipa_acq, ipa_ven_emittente, replicate('0',7)),
			case when (invoicekind.enable_fe='S' or invoicekind.enable_fe_estera='S') then 'ELETTRONICO' else 'ANALOGICO' end,
			convert(varchar(20), isnull(sdi_acquisto.identificativo_sdi, sdi_acquistoestere.identificativo_sdi)),
			case when (invoicekind.enable_fe='N' and invoicekind.enable_fe_estera='N') then 'FATT_ANALOGICA' else null end,
			#payment.cf_ben,
			year(I.docdate),
			case when invoicekind.enable_fe='S'  then isnull(sdi_acquisto.ninvoice,substring(I.doc,1,20)) else substring(I.doc,1,20) end,  
			case when ((invoicekind.flag&4)<>0) then 'S' else 'N' end,
			-- idsor_siope
			D.idsor_siope,
			--importo_siope = totale = Contabilizzazione solo IVA,
			 CASE when ((invoicekind.flag&4)<>0) THEN 
				 - (
					CONVERT(decimal(19,2),ROUND(ISNULL(D.tax,0),2))
					)
			else 	CONVERT(decimal(19,2),ROUND(ISNULL(D.tax,0),2))
			end,

			case when	isnull((select sum(d2.taxable * ISNULL(d2.npackage,d2.number)) from invoicedetail as d2 where d2.idinvkind = d.idinvkind and d2.yinv=d.yinv and d2.ninv = d.ninv and d2.expensekind = 'CO'),0)>
						isnull((select sum(d3.taxable * ISNULL(d3.npackage,d3.number))  from invoicedetail as d3 where d3.idinvkind = d.idinvkind and d3.yinv=d.yinv and d3.ninv = d.ninv and d3.expensekind = 'CA'),0)
						then 'CORRENTE'
						else 'CAPITALE'
			end,
			--utilizzo_nota_di_credito
			case when ((invoicekind.flag&4)<>0) 
						then 'INCASSO/COMPENSAZIONE'
						else null
			end,
				-- Data Scadenza Pagamento
				case 
				-- Data contabile(data registrazione)  = Numero gg D.R.F.
				when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
				when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
				-- Data documento = Numero gg  D.F.
				when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
				when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
				-- Fine mese data documento = Numero gg F.M.D.F.
				when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
				when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
				-- Fine mese data contabile = Numero gg F.M.D.R.F.
				when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
				when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
				--	Pagamento Immediato  = data registrazione
				when I.idexpirationkind = 5 then I.adate
				-- Data ricezione
				when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
				when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
			else null
			end,
			case when  exists (select * from invoicedetail D2 where D2.idinvkind = D.idinvkind and D2.yinv = D.yinv and D2.ninv = D.ninv and D2.idpccdebitstatus in ('LIQdaSOSP','LIQdaNL')) then 'SOSP_DECORRENZA_TERMINI'
				when I.idexpirationkind is not null then 'CORRETTA_SCAD_FATTURA'
			else null
			end,
			null --	case where exists(select * from expensevar where expensevar.idexp = #payment.idexp) then 'S' else 'N'  end
		FROM #payment
		JOIN invoicedetail D			ON #payment.idexp = D.idexp_iva
		join invoice I					on I.idinvkind = D.idinvkind and I.yinv = D.yinv and I.ninv = D.ninv
		join invoicekind				on I.idinvkind = invoicekind.idinvkind
		left outer join sdi_acquisto	on I.idsdi_acquisto = sdi_acquisto.idsdi_acquisto
		left outer join sdi_acquistoestere	on I.idsdi_acquistoestere = sdi_acquistoestere.idsdi_acquistoestere
		left outer join nocigmotive		on nocigmotive.idnocigmotive = I.idnocigmotive
		where D.idexp_iva is not null and (D.idexp_taxable is null or D.idexp_taxable <> D.idexp_iva ) -- Contabilizzazione SOLO IVA
		

	 
	 --select '1 #DocContabilizzato', * from 	#DocContabilizzato 
update  #DocContabilizzato set contarigheDettaglioDistinte = (select count(*) /*AS distinct_count */
from (SELECT DISTINCT numero_fattura_siope, motivo_scadenza_siope FROM #DocContabilizzato d where d.idexp= #DocContabilizzato.idexp ) as t
)



CREATE TABLE #expensesorted_sum(
	idsor int,
	idexp int,
	amount decimal(19,2)
	)
insert into #expensesorted_sum(idsor,idexp,amount)
select es.idsor,es.idexp,sum(amount)
	from expensesorted es 
		join sorting s on es.idsor=s.idsor
		join #payment  on #payment.idexp=es.idexp
		where s.idsorkind=@classSIOPE
		group by  es.idsor,es.idexp


CREATE TABLE #DocContabilizzatoRigheDiverse(
	ydoc int,
	ndoc int,
	idpay int,
	--idsor_siope int,
	--amount decimal(19,2),
	idexp int,
	
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope varchar(10),
	motivo_esclusione_cig_siope varchar(50),
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	flagnc char(1),
	importo_siope decimal(19,2),
	natura_spesa_siope varchar(10),-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito varchar(30), --Contiene il tipo di utilizzo della nota di credito. Può  assumere i seguenti valori: “INCASSO/COMPENSAZIONE” - “SPLIT PAYMENT”
	data_scadenza_pagam_siope datetime,
	motivo_scadenza_siope varchar(50),
	var_present char(1),
	contarigheDettaglioDistinte int
)
	insert into #DocContabilizzatoRigheDiverse(
			ydoc, ndoc,	idpay, idexp, 
			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			--idsor_siope,
			importo_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present,contarigheDettaglioDistinte)

			select 
			ydoc, ndoc,	idpay, idexp, 
			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			--idsor_siope,
			sum(importo_siope),
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present,contarigheDettaglioDistinte
			from  #DocContabilizzato

			group by
			ydoc, ndoc,	idpay, idexp, 
			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			--idsor_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present,contarigheDettaglioDistinte
			having sum(importo_siope)<>0


--update  #DocContabilizzato set contarigheDettaglioDistinte = (select count( distinct motivo_scadenza_siope)
--		 from #DocContabilizzato d where d.idexp= #DocContabilizzato.idexp and d.numero_fattura_siope = #DocContabilizzato.numero_fattura_siope)


 
CREATE TABLE #DocContabilizzatoSommaSiope(
	ydoc int,
	ndoc int,
	idpay int,
	idsor_siope int,
	--amount decimal(19,2),
	idexp int,
	
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope varchar(10),
	motivo_esclusione_cig_siope varchar(50),
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	flagnc char(1),
	importo_siope decimal(19,2),
	natura_spesa_siope varchar(10),-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito varchar(30), --Contiene il tipo di utilizzo della nota di credito. Può  assumere i seguenti valori: “INCASSO/COMPENSAZIONE” - “SPLIT PAYMENT”
	data_scadenza_pagam_siope datetime,
	motivo_scadenza_siope varchar(50),
	var_present char(1),
	contarigheDettaglioDistinte int
)
	insert into #DocContabilizzatoSommaSiope(
			ydoc, ndoc,	idpay, idexp, 
			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			idsor_siope,
			importo_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present,contarigheDettaglioDistinte)

			select 
			ydoc, ndoc,	idpay, idexp, 
			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			idsor_siope,
			sum(importo_siope),
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present,contarigheDettaglioDistinte
			from  #DocContabilizzato

			group by
			ydoc, ndoc,	idpay, idexp, 
			tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
			codice_cig_siope,
			motivo_esclusione_cig_siope,
			codice_ipa_ente_siope,
			tipo_documento_siope, -- ELETTRONICO o ANALOGICO
			identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
			tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
			/*Se cartacea*/
			codice_fiscale_emittente_siope,
			anno_emissione_fattura_siope ,
	
			/*ctDati_fattura_siope*/
			numero_fattura_siope, 
			flagnc,
			idsor_siope,
			natura_spesa_siope, -- CORRENTE o CAPITALE
			utilizzo_nota_di_credito,
			data_scadenza_pagam_siope,
			motivo_scadenza_siope,
			var_present,contarigheDettaglioDistinte


--update #DocContabilizzato set	identificativo_lotto_sdi_siope='999999' where identificativo_lotto_sdi_siope is null -- SARA da RIMUOVERE!!!

---update #DocContabilizzato set motivo_esclusione_cig_siope='ANALOGICO' where codice_cig_siope is null or codice_cig_siope=''-- UPDATE USATA PER I TEST. E' stata creata una regola per controllarne la valorizzazione

IF EXISTS(
	(SELECT * FROM #DocContabilizzato
	where tipo_debito_siope = 'COMMERCIALE' AND	codice_cig_siope is null and motivo_esclusione_cig_siope is null))
BEGIN
	INSERT INTO #error (message)
	(SELECT 'Il movimento n.' + CONVERT(varchar(6),nmov) 
	+ '/' + CONVERT(varchar(4),ymov) + ' non ha ne un CIG, ne un motivo di esclusione CIG specificato. '
	FROM #DocContabilizzato JOIN expense  ON #DocContabilizzato.idexp = expense.idexp
	where tipo_debito_siope = 'COMMERCIALE' AND	codice_cig_siope is null and motivo_esclusione_cig_siope is null
	)
END
 
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	return 
END


-- Inserimento delle classificazioni SIOPE dei movimenti di spesa o anche delle disposizioni di pagamento
-- incorporate nel flusso
INSERT INTO #siope
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,	idpay,
	sortcode, sorting, importoclassificazionemov, --> CLASSIIFCAZIONE SIOPE
	importo_siope,
	idexp, cupcodefin, cupcodeupb, cupcodedetail, cupcodeexpense, progressive,
	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope,
	motivo_esclusione_cig_siope,
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope, 
	natura_spesa_siope,-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito,
	data_scadenza_pagam_siope,
	motivo_scadenza_siope,
	flagnc
)
-- Vale sia per le fatt. normali che per le fatture con n.c., CASO UNA SOLA CLASSIFICAZIONE SUL MOVIMENTO DI SPESA
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc, #payment.idpay,
	SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description,	/*CLASSIFICAZIONE SIOPE */
	#expensesorted_sum.amount,					--importo netto sul siope (somma fattura e note di credito) su tutto il movimento di spesa
	DOC.importo_siope,					/*IMPORTO SIOPE raggruppato per documento, alcune somme sono positive e altre (per le NC) negative */
	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1,
	-- COMMERCIALE o IVA o NON COMMERCIALE
	DOC.tipo_debito_siope,
	DOC.codice_cig_siope,
	DOC.motivo_esclusione_cig_siope,
	DOC.codice_ipa_ente_siope,
	
	DOC.tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	DOC.identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	DOC.tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	DOC.codice_fiscale_emittente_siope,
	DOC.anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	DOC.numero_fattura_siope, 
	DOC.natura_spesa_siope,-- CORRENTE o CAPITALE
	DOC.utilizzo_nota_di_credito,
	DOC.data_scadenza_pagam_siope,
	DOC.motivo_scadenza_siope,
	DOC.flagnc
FROM #payment
--join #DocContabilizzato DOC					on DOC.idexp = #payment.idexp
join #DocContabilizzatoRigheDiverse doc		on DOC.idexp = #payment.idexp
JOIN #expensesorted_sum							ON #payment.idexp = #expensesorted_sum.idexp 
JOIN sorting								ON sorting.idsor = #expensesorted_sum.idsor
WHERE #payment.nClassSiope=1			--vale sia con 1 o più gruppi di dettagli siope

--select 1, * from #siope

INSERT INTO #siope
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,	idpay,
	sortcode, sorting, importoclassificazionemov, --> CLASSIIFCAZIONE SIOPE
	importo_siope,
	idexp, cupcodefin, cupcodeupb, cupcodedetail, cupcodeexpense, progressive,
	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope,
	motivo_esclusione_cig_siope,
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope, 
	natura_spesa_siope,-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito,
	data_scadenza_pagam_siope,
	motivo_scadenza_siope,
	flagnc
)
-- Vale sia per le fatt. normali che per le fatture con n.c.  CASO PIU' CLASSIFICAZIONI SUL MOVIMENTO DI SPESA
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc, #payment.idpay,
	SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description,	/*CLASSIFICAZIONE SIOPE */
	#expensesorted_sum.amount,					--importo netto sul siope (somma fattura e note di credito) su tutto il movimento di spesa
	#expensesorted_sum.amount,					/*IMPORTO SIOPE raggruppato per documento, alcune somme sono positive e altre (per le NC) negative */
	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1,
	-- COMMERCIALE o IVA o NON COMMERCIALE
	DOC.tipo_debito_siope,
	DOC.codice_cig_siope,
	DOC.motivo_esclusione_cig_siope,
	DOC.codice_ipa_ente_siope,
	
	DOC.tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	DOC.identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	DOC.tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	DOC.codice_fiscale_emittente_siope,
	DOC.anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	DOC.numero_fattura_siope, 
	DOC.natura_spesa_siope,-- CORRENTE o CAPITALE
	DOC.utilizzo_nota_di_credito,
	DOC.data_scadenza_pagam_siope,
	DOC.motivo_scadenza_siope,
	DOC.flagnc
FROM #payment
--join #DocContabilizzato DOC					on DOC.idexp = #payment.idexp
join #DocContabilizzatoRigheDiverse doc		on DOC.idexp = #payment.idexp
JOIN #expensesorted_sum							ON #payment.idexp = #expensesorted_sum.idexp 
JOIN sorting								ON sorting.idsor = #expensesorted_sum.idsor
WHERE #payment.nClassSiope>1 and doc.contarigheDettaglioDistinte=1	

--select 2, * from #siope

--select * from #payment

--select * from #DocContabilizzatoRigheDiverse


INSERT INTO #siope
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,	idpay,
	sortcode, sorting, importoclassificazionemov, --> CLASSIIFCAZIONE SIOPE
	importo_siope,
	idexp, cupcodefin, cupcodeupb, cupcodedetail, cupcodeexpense, progressive,
	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope,
	motivo_esclusione_cig_siope,
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope, 
	natura_spesa_siope,-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito,
	data_scadenza_pagam_siope,
	motivo_scadenza_siope,
	flagnc
)


-- Vale sia per le fatt. normali che per le fatture con n.c.  CASO PIU' CLASSIFICAZIONI SUL MOVIMENTO DI SPESA
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc, #payment.idpay,
	SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description,	/*CLASSIFICAZIONE SIOPE */
	(select sum(d.importo_siope) from #DocContabilizzatoSommaSiope d where d.idexp = doc.idexp and d.idsor_siope = doc.idsor_siope ),
										--importo netto sul siope (somma fattura e note di credito) su tutto il movimento di spesa
	doc.importo_siope,					/*IMPORTO SIOPE raggruppato per documento, alcune somme sono positive e altre (per le NC) negative */
	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1,
	-- COMMERCIALE o IVA o NON COMMERCIALE
	DOC.tipo_debito_siope,
	DOC.codice_cig_siope,
	DOC.motivo_esclusione_cig_siope,
	DOC.codice_ipa_ente_siope,
	
	DOC.tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	DOC.identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	DOC.tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	DOC.codice_fiscale_emittente_siope,
	DOC.anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	DOC.numero_fattura_siope, 
	DOC.natura_spesa_siope,-- CORRENTE o CAPITALE
	DOC.utilizzo_nota_di_credito,
	DOC.data_scadenza_pagam_siope,
	DOC.motivo_scadenza_siope,
	DOC.flagnc
FROM #payment
--join #DocContabilizzato DOC					on DOC.idexp = #payment.idexp
join #DocContabilizzatoSommaSiope doc		on DOC.idexp = #payment.idexp
JOIN sorting								ON sorting.idsor = doc.idsor_siope
WHERE sorting.idsorkind = @classSIOPE and #payment.nClassSiope>1 and doc.contarigheDettaglioDistinte>1	

delete from #siope where importoclassificazionemov = 0

 -- Pagamenti non associati a fatture
INSERT INTO #siope
(
	ypaymenttransmission, npaymenttransmission, ydoc, ndoc,	idpay,
	sortcode, sorting, importoclassificazionemov, --> CLASSIIFCAZIONE SIOPE
	importo_siope,
	idexp, cupcodefin, cupcodeupb, cupcodedetail, cupcodeexpense, progressive,
	tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope,
	motivo_esclusione_cig_siope,
	codice_ipa_ente_siope,
	
	tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope,
	anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope, 
	natura_spesa_siope,-- CORRENTE o CAPITALE
	utilizzo_nota_di_credito,
	data_scadenza_pagam_siope,
	motivo_scadenza_siope,
	flagnc
)
 SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc, 
	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description, /*CLASSIFICAZIONE SIOPE */
	#expensesorted_sum.amount,																			/*IMPORTO SIOPE */
	null,--SUM(DOC.importo_siope),		
	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1,
	--DOC.tipo_debito_siope, --COMMERCIALE o IVA o NON COMMERCIALE
	case when #payment.autokind = 23 /*LPIVASPLIT*/  then 'IVA'
		else 'NON COMMERCIALE'
	end,
	null,--DOC.codice_cig_siope,
	null,--DOC.motivo_esclusione_cig_siope,
	null,--DOC.codice_ipa_ente_siope,
	
	null,--DOC.tipo_documento_siope, -- ELETTRONICO o ANALOGICO
	null,--DOC.identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
	null,--DOC.tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	null,--DOC.codice_fiscale_emittente_siope,
	null,--DOC.anno_emissione_fattura_siope ,
	
	/*ctDati_fattura_siope*/
	null,--DOC.numero_fattura_siope, 
	null,--DOC.natura_spesa_siope,-- CORRENTE o CAPITALE
	null,--DOC.utilizzo_nota_di_credito,
	null,--DOC.data_scadenza_pagam_siope,
	null,--DOC.motivo_scadenza_siope,
	'N'
FROM #payment
JOIN #expensesorted_sum
	ON #payment.idexp = #expensesorted_sum.idexp
JOIN sorting
	ON sorting.idsor = #expensesorted_sum.idsor
WHERE #expensesorted_sum.amount <>0
and not exists (select * from expenseinvoice where idexp = #payment.idexp )

 

--SELECT YDOC,NDOC, IDPAY, IDEXP, IDSOR_SIOPE, IMPORTO_SIOPE, MOTIVO_SCADENZA_SIOPE,* FROM #DocContabilizzato
----UNION
------ Pagamenti senza fattura
----SELECT
----	#payment.ypaymenttransmission, #payment.npaymenttransmission,
----	#payment.ydoc, #payment.ndoc, 
----	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)), sorting.description, /*CLASSIFICAZIONE SIOPE */
----	SUM(expensesorted.amount),																			/*IMPORTO SIOPE */
----	#payment.idexp,#payment.cupcodefin,#payment.cupcodeupb, #payment.cupcodedetail, #payment.cupcodeexpense,1,
----	null,	null,	null,	null,	null,	null,	null,	null,	null,	null,	null,	null,	null
----FROM #payment
----JOIN expensesorted
----	ON #payment.idexp = expensesorted.idexp
----JOIN sorting
----	ON sorting.idsor = expensesorted.idsor
----WHERE sorting.idsorkind = @classSIOPE
----GROUP BY #payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.ydoc,
----	#payment.ndoc, 
----	#payment.idpay, SUBSTRING(sorting.sortcode,@npos,DATALENGTH(sorting.sortcode)),sorting.description,
----	#payment.idexp,  #payment.autokind ,
----	#payment.exp_curramount, #payment.curramount,
----	#payment.cupcodeexpense, #payment.cupcodedetail,#payment.cupcodeupb, #payment.cupcodefin
----HAVING SUM(expensesorted.amount) <> 0

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

-- Tabella dei dati ARCONET
CREATE TABLE #dati_arconet
(
	ypaymenttransmission int,
	npaymenttransmission int,
	ydoc int,
	ndoc int,
	idpay int,
	idsor int,
	idexp int,

	codice_missione_siope varchar(50),
	codice_programma_siope varchar(50),
	codice_economico_siope  varchar(50),
	importo_codice_economico_siope  decimal(19,2),
	codice_UE_siope varchar(50), 
	--cofog_siope  varchar(50),
	codice_cofog_siope  varchar(50),
	importo_cofog_siope decimal(19,2)
)
-- Tabella dei dati ARCONET
insert into #dati_arconet(
	ypaymenttransmission, npaymenttransmission,
	ydoc, 	ndoc,
	idpay,
	idsor,	--importoclassificazionemov,
	idexp,

	codice_missione_siope,
	codice_programma_siope,
	codice_economico_siope,
	importo_codice_economico_siope,
	codice_UE_siope, 
	codice_cofog_siope,
	importo_cofog_siope)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,
	#payment.ydoc, #payment.ndoc, 
	#payment.idpay, 
	expensesorted.idsor, 
	#payment.idexp,

	'01',	--codice missione
	--codice programma
	case	when expensesorted.valueS2='04.8' then'02'
			when expensesorted.valueS2='01.4' then'01'
			when expensesorted.valueS2='07.5' then'02'
			else null
	end,							
	sorting.sortcode,				--codice economico
	SUM(expensesorted.amount),		--importo_codice_economico_siope
	expensesorted.valueS1,			--codice_UE_siope
	expensesorted.valueS2,							--codice_cofog_siope
	SUM(expensesorted.amount)			--	importo_cofog_siope		04.8
FROM #payment
JOIN expensesorted
	ON #payment.idexp = expensesorted.idexp
JOIN sorting
	ON sorting.idsor = expensesorted.idsor
WHERE sorting.idsorkind = @classSIOPE
	and isnull(expensesorted.valueS2,'') <>''--Solo se il COFOG è stato indicato
GROUP BY #payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.ydoc,	#payment.ndoc, 
	#payment.idpay,expensesorted.idsor,  sorting.sortcode,
	#payment.idexp ,expensesorted.valueS1,expensesorted.values2



if(@n is not null)
Begin
	if exists(SELECT * FROM #siope S WHERE (isnull(codice_cig_siope,'') = '') and (isnull(motivo_esclusione_cig_siope,'')='')  )
	Begin
				-- CONTROLLO N. 18 Controllo che sia valorizzato il CIG
				INSERT INTO #error (message)
				SELECT 'Il movimento di spesa Es.' + CONVERT(varchar(6),E.ymov) + ' N.' + CONVERT(varchar(10), E.nmov)
				+ ' non ha un CIG, e non è presente un motivo di esclusione CIG nella fattura contabilizzata.'
				FROM #siope S
				join expense E
				on S.idexp = E.idexp
				WHERE isnull(codice_cig_siope,'') = '' and isnull(motivo_esclusione_cig_siope,'')=''
				and S.tipo_debito_siope='COMMERCIALE'
				group by E.ymov, E.nmov
		IF (SELECT COUNT(*) FROM #error) > 0
		BEGIN
			SELECT * FROM #error
			return -- TODO rimuovere il commento
		END

	End
End

if(@n is not null)
Begin
			INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay,idexp, testo)
			SELECT  
			ypaymenttransmission, 
			npaymenttransmission, 
			ydoc, 
			ndoc,
			idpay,idexp,
			[dbo].getstringformatted_r(finlevel + ': ' + codefin + ' - ' + fintitle + ' ,UPB: ' + codeupb + ' - ' + upbtitle, 300)
			FROM #payment
			GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, idexp,
					 ydoc, finlevel, codefin, fintitle, codeupb, upbtitle


			-- RECORD FASE + MOVIMENTO
			INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay, idexp,testo)
			SELECT  
			ypaymenttransmission, 
			npaymenttransmission, 
			ydoc, 
			ndoc,
			idpay,idexp,
			--Informazione Ente ZINFENT
				[dbo].getstringformatted_r(phase + ' n.' + convert(varchar(10),nmov) + ' / ' + + convert(varchar(4),ymov) + ', Competenza/Residui: ' + flagcr , 300) 
			FROM #payment
			GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, idexp,
					 ydoc,phase, ymov, nmov,flagcr

			-- RECORD DESCRIZIONE CLASSIFICAZIONE SIOPE 
			INSERT INTO #note (ypaymenttransmission, npaymenttransmission, ydoc, ndoc, idpay, idexp, testo)
			SELECT  
			ypaymenttransmission, 
			npaymenttransmission, 
			ydoc, 
			ndoc,
			idpay,idexp,
			--Informazione Ente ZINFENT
			[dbo].getstringformatted_r('SIOPE: ' + sortcode + ' - ' + sorting + ', Importo: ' + convert(varchar(30), importoclassificazionemov), 300) 
			FROM #siope
			GROUP BY ypaymenttransmission, npaymenttransmission, ndoc, idpay, idexp, sortcode, sorting, importoclassificazionemov,
					 ydoc
		 

	
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
end

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	return 
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

--  Bollette singole
INSERT INTO  #expensebill
(	ypaymenttransmission, npaymenttransmission, idexp,
	ydoc, ndoc, idpay,  ybill,nbill, amount)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission, #payment.idexp, 
	#payment.ydoc, #payment.ndoc,
	#payment.idpay,  #payment.ydoc, expenselast.nbill,     
	#payment.curramount			 
FROM  #payment JOIN expenselast ON #payment.idexp = expenselast.idexp
WHERE   expenselast.nbill IS NOT NULL
 
	
 -- Bollette multiple
INSERT INTO  #expensebill
(	ypaymenttransmission, npaymenttransmission, idexp,
	ydoc, ndoc, idpay,  ybill,nbill, amount)
SELECT
	#payment.ypaymenttransmission, #payment.npaymenttransmission,  #payment.idexp,  #payment.ydoc, #payment.ndoc,
	#payment.idpay, expensebill.ybill, expensebill.nbill, expensebill.amount
FROM #payment
JOIN expensebill ON #payment.idexp = expensebill.idexp

-------------------------------------------------------------------------------------------------------------------
------------------------------------------------inizio tracciato---------------------------------------------------
-------------------------------------------------------------------------------------------------------------------

---------------------------------------------
---------- testata flusso -------------------
---------------------------------------------
DECLARE @codice_ABI_BT varchar(5)

--DECLARE @data_ora_creazione_flusso  varchar(20)
--SET   @data_ora_creazione_flusso = CONVERT(varchar(19),CONVERT(smalldatetime, GETDATE(), 126),126) 
DECLARE @data_ora_creazione_flusso  datetime
SET   @data_ora_creazione_flusso =  GETDATE()


DECLARE @codice_ente  varchar(16) -- (PRIMA : da valorizzare con partita iva ente oppure codice fiscale) NEW : Codice IPA dell'ente (cod_uni_ou). Si potrebbe prendere dalla tabella IPA
set @codice_ente = ( select ipa_fe from ipa where useforopi ='S')
 

--DECLARE @codice_fiscale_ente varchar(16)	--(new)Prima veniva valorizzato @codice_ente col CF, adesso valorizziamo @codice_fiscale_ente
--SET @codice_fiscale_ente = @cf_dept



DECLARE @descrizione_ente varchar(150)
set @descrizione_ente = @desc_dept

DECLARE @codice_ente_BT  varchar(12) -- Codice univoco interno, attribuito dalla banca, per mezzo del quale l'ente è riconosciuto dalla banca medesima
SET @codice_ente_BT = @cod_department


DECLARE @riferimento_ente varchar(30)
DECLARE @esercizio int
SET @esercizio = @y -- esercizio finanziario
SET @codice_ABI_BT = @ABI_code

 
--select tramite_bt_code,
--	tramite_agency_code
--FROM treasurer WHERE idtreasurer = 1

---------------------------------------------
----- fine testata flusso -------------------
---------------------------------------------
-- Tabella di output
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
	identificativo_flusso varchar(50),
	data_ora_creazione_flusso datetime,--varchar(20),
	codice_ente varchar(16), -- Prima : partita iva o codice fiscale, Ora:ipa
	descrizione_ente varchar(150),
	codice_istat_ente varchar(20),
	codice_fiscale_ente varchar(16), --new
	codice_tramite_ente varchar(20),
	codice_tramite_BT VARCHAR(20), --new
	codice_ente_BT varchar(20),
	riferimento_ente varchar(30),
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
	conto_evidenza varchar(20), -- mettere 1
	estremi_provvedimento_autorizzativo varchar(50),
	responsabile_provvedimento varchar(50),
	ufficio_responsabile varchar(50),
	dati_codice_struttura varchar(20),
	dati_codice_ipa_struttura varchar(20),

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------FINE TIPO RIGA MANDATO------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------------------------------

	--------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------INIZIO TIPO RIGA INFO_BENEFICIARIO------------------------------------------------ 
    --- contiene le informazioni relative alla riga di mandato (sub del mandato), che nella terminologia del tracciato XML si chiama -----
    --  beneficiario. In questo tipo riga  ho inserito non solo le informazioni relative alla sezione info_beneficiario del tracciato XML
    --  ma ho aggiunto anche altre sezioni in corrispondenza uno a uno con la riga di mandato, come bollo, spese, delegato, ecc. ----------
	--  KIND : INFO_BENEFICIARIO,   TIPO RIGA PADRE: MANDATO, SELETTORI: ndoc (sarebbe npay, riferimento al mandato), CHIAVE: idpay -------
	---------------------------------------------------------------------------------------------------------------------------------------

	----------------------------------------------------
	-----------------info beneficiario -----------------
	----------------------------------------------------
	idpay int, idexp int,
	progressivo_beneficiario int,
	importo_beneficiario decimal(19,2),
	tipo_pagamento varchar(100),
	impignorabili char(1),
	frazionabile char(1),
	gestione_provvisoria char(1),
	data_esecuzione_pagamento varchar(20), 
	data_scadenza_pagamento varchar(20),
	destinazione varchar(20),
	numero_conto_banca_italia_ente_ricevente varchar(10),
	tipo_contabilita_ente_ricevente varchar(20),
	tipo_postalizzazione VARCHAR(20),
	---------------------------------------------
	----------------- bollo ---------------------
	---------------------------------------------
	assoggettamento_bollo varchar(50),
	causale_esenzione_bollo varchar(50),
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
	partita_iva_beneficiario varchar(35),
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
	riferimento_documento_esterno varchar(400),
	numero_avviso_pagopa varchar(30),
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
	importoclassificazionemov decimal(19,2),

	--classificazione_dati_siope_uscite
	tipo_debito_siope varchar(15), --COMMERCIALE o IVA o NON COMMERCIALE
	codice_cig_siope varchar(10),
	motivo_esclusione_cig_siope varchar(50),
	codice_ipa_ente_siope varchar(7),
	
	tipo_documento_siope varchar(20), -- ELETTRONICO o ANALOGICO
	identificativo_lotto_sdi_siope varchar(20), -- E' un INT!!!!!! /*Se FE*/
	tipo_documento_analogico_siope varchar(20), -- FATT_ANALOGICA o DOC_EQUIVALENTE
	/*Se cartacea*/
	codice_fiscale_emittente_siope varchar(16),
	anno_emissione_fattura_siope varchar(4) ,
	
	/*ctDati_fattura_siope*/
	numero_fattura_siope varchar(20), 
	importo_siope  decimal(19,2),
	natura_spesa_siope varchar(10), -- CORRENTE o CAPITALE
	utilizzo_nota_di_credito varchar(20), --Contiene il tipo di utilizzo della nota di credito. Può  assumere i seguenti valori: “INCASSO/COMPENSAZIONE” - “SPLIT PAYMENT”
	data_scadenza_pagam_siope varchar(20),
	motivo_scadenza_siope varchar(50),
	codice_missione_siope	varchar(50),
	codice_programma_siope  varchar(50),
	codice_economico_siope	varchar(50),
	importo_codice_economico_siope  decimal(19,2), 
	codice_UE_siope			varchar(50),
	codice_cofog_siope		varchar(50),
	importo_cofog_siope  decimal(19,2),

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
	dati_a_disposizione_ente_mandato varchar(400)
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
				   codice_istat_ente,
					codice_fiscale_ente,
					codice_tramite_ente,
					codice_tramite_BT,
				   codice_ente_BT,
				   riferimento_ente,
				   esercizio)
-- SONO INFO PER L'AMBIENTE DI TEST
/*SELECT 
			  'TESTATA',
				   '05262',--BANCA POPOLARE PUGLIESE
				   'mandati_'+ convert(varchar(4),@y) + '_' +convert(varchar(4),@n),
				   @data_ora_creazione_flusso,
				   'UFAUDA',
				   'Università del Salento - Amministrazione Centrale',
				   '000705784',
					'00646640755',
					'A2A-80647560',
					'A2A-80647560',
				   '0001100',
				   @riferimento_ente,
				   @y*/
SELECT 
				   'TESTATA',
				   @codice_ABI_BT,
				   'mandati_'+ convert(varchar(4),@y) + '_' +convert(varchar(10),@n),
				   @data_ora_creazione_flusso,
				   @codice_ente,
				   @descrizione_ente,
				   @codice_istat_ente,
					@cf_dept,--@piva_dept, 
					@codice_tramite_ente,
					@codice_tramite_BT,
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
				   dati_codice_struttura,
				   dati_codice_ipa_struttura
				   )
SELECT 
				   'MANDATO',
				   ndoc, 
				   @opkind,
				   ndoc,
				   CONVERT(VARCHAR(10),payment_adate,20),
				   SUM(curramount), -- deve essere importo al lordo delle ritenute
				   @cc_vincolato,
				   --null,
				   null,
				   null,
				   null,
				   @CodiceStruttura,
				   @Codice_ipa_struttura
FROM #payment
GROUP BY #payment.ndoc,payment_adate
ORDER BY #payment.ndoc

update #payment set paymentdescr = dbo.f_removespecialchar(paymentdescr) where paymentdescr is not null
update #payment set address_ben = dbo.f_removespecialchar(address_ben) where address_ben is not null


INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,idexp,
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
				   tipo_postalizzazione,
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
				  -- abi_beneficiario,
				   --cab_beneficiario,
				   numero_conto_corrente_beneficiario,
				   --caratteri_controllo,
				   --codice_cin,
				   --codice_paese,
				   --denominazione_banca_destinataria,
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
				   ---------- informazioni aggiuntive-------------
				   -----------------------------------------------
				   lingua,
				   riferimento_documento_esterno,
				   numero_avviso_pagopa,
				   note,
			       -----------------------------------------------
				   ---- dati_a_disposizione_ente_beneficiario ----
				   -----------------------------------------------
				   dati_a_disposizione_ente_beneficiario
				   )
SELECT 
				   'INFO_BENEFICIARIO',
				   ndoc,
				   idpay, #payment.idexp,
				   idpay,
				   SUM(curramount),
				   CASE   
				    WHEN ((abi_label  IS NULL) AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONE'
					WHEN (abi_label = 'ACCREDITOTESORERIAPROVINCIALESTATOPERTABA' AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONEACCREDITOTESORERIAPROVINCIALESTATOPERTABA'
					WHEN (abi_label = 'ACCREDITOTESORERIAPROVINCIALESTATOPERTABB' AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONEACCREDITOTESORERIAPROVINCIALESTATOPERTABB'
				    WHEN ((abi_label IS NOT NULL and abi_label not in ('ACCREDITOTESORERIAPROVINCIALESTATOPERTABA','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB') ) AND (fulfilled = 'S')) THEN 'REGOLARIZZAZIONE'
					ELSE abi_label
				   END,
				   null,
				   null,
				   null,
				   CONVERT(VARCHAR(10),expiration,20),--case when (autokind in (20,21,30,31)) then CONVERT(VARCHAR(10),expiration,20) else null end,   ---data esecuzione pagamento,
				   null,--case when (isnull(autokind,0) not in (20,21,30,31)) then CONVERT(VARCHAR(10),expiration,20) else null end,   ---data scadenza pagamento,
				   destinazione, -- destinazione
				   CASE 
						WHEN (abi_label = 'F24EP') THEN 1777 
						WHEN (abi_label = 'ACCREDITOTESORERIAPROVINCIALESTATOPERTABA')  THEN extracode
						ELSE null
				   END,
				   tipo_contabilita_ente_ricevente,   
				   NULL,
				   -----------------------------------------------------------
				   ----------------- beneficiario --------------
				   -----------------------------------------------------------
				   CASE 
						WHEN ( #payment.iddeputy is not null ) and (abi_label = 'SEPACREDITTRANSFER') THEN  SUBSTRING(#deputy.title_deputy,1,60)
						ELSE SUBSTRING(title_ben,1,60)
					END, 
				   --Indirizzo Beneficiario
				    CASE 
						WHEN ( #payment.iddeputy is not null )  and (abi_label = 'SEPACREDITTRANSFER')THEN  SUBSTRING(#deputy.address_deputy,1,30)
						ELSE SUBSTRING(address_ben,1,30)
					END	,
				   -- C.A.P. Beneficiario
				   	CASE 
						WHEN ( #payment.iddeputy is not null ) THEN  #deputy.cap_deputy
						ELSE cap_ben
					END	,
				   -- Località Beneficiario
				    CASE 
						WHEN ( #payment.iddeputy is not null )  and (abi_label = 'SEPACREDITTRANSFER')THEN  SUBSTRING(#deputy.location_deputy,1,30)
						ELSE  SUBSTRING(location_ben,1,30)
					END	,
				   -- Provincia Beneficiario
				    CASE 
						WHEN ( #payment.iddeputy is not null )  and (abi_label = 'SEPACREDITTRANSFER')THEN #deputy.province_deputy
						ELSE province_ben
					END	,
				   -- Stato_beneficiario
				    CASE 
						WHEN ( #payment.iddeputy is not null )  and (abi_label = 'SEPACREDITTRANSFER')THEN #deputy.nation_deputy
						ELSE  iso_code_ben
					END	,
				    CASE 
						WHEN ( #payment.iddeputy is not null )  and (abi_label = 'SEPACREDITTRANSFER')THEN null
						ELSE  pi_ben
					END	,
				    CASE 
						WHEN ( #payment.iddeputy is not null )  and (abi_label = 'SEPACREDITTRANSFER')THEN #deputy.cf_deputy
						ELSE cf_ben
					END	, 
				   -----------------------------------------------------------
				   ----------------- delegato --------------
				   -----------------------------------------------------------
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN  SUBSTRING(#deputy.title_deputy,1,60)
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN SUBSTRING(#deputy.address_deputy,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN #deputy.cap_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN SUBSTRING(#deputy.location_deputy,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN #deputy.province_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN  #deputy.nation_deputy
						ELSE NULL
				   END,
				   CASE 
						WHEN (ISNULL(abi_label, 'CASSA') <> 'SEPACREDITTRANSFER') THEN  #deputy.cf_deputy
						ELSE NULL
				   END,
				   -----------------------------------------------------------
				   ---------------- CREDITORE EFFETTIVO ---------------------- 
				   -----------------------------------------------------------
				   CASE 
						WHEN ( #payment.iddeputy is not null) and (abi_label = 'SEPACREDITTRANSFER')  THEN  SUBSTRING(title_ben,1,60)
						ELSE NULL
				   END,
				   CASE 
						WHEN ( #payment.iddeputy is not null)   and (abi_label = 'SEPACREDITTRANSFER')THEN SUBSTRING(address_ben,1,30)
						ELSE NULL				   
					END,
				   CASE 
						WHEN  ( #payment.iddeputy is not null)  and (abi_label = 'SEPACREDITTRANSFER')  THEN cap_ben
						ELSE NULL
				   END,
				   CASE 
						WHEN  ( #payment.iddeputy is not null)   and (abi_label = 'SEPACREDITTRANSFER') THEN   SUBSTRING(location_ben,1,30)
						ELSE NULL
				   END,
				   CASE 
						WHEN  ( #payment.iddeputy is not null)  and (abi_label = 'SEPACREDITTRANSFER') THEN  province_ben
						ELSE NULL
				   END,
				   CASE 
						WHEN  ( #payment.iddeputy is not null)  and (abi_label = 'SEPACREDITTRANSFER')THEN  iso_code_ben
						ELSE NULL
				   END,
				    CASE 
						WHEN  ( #payment.iddeputy is not null) and (abi_label = 'SEPACREDITTRANSFER') THEN  pi_ben
						ELSE NULL
				   END,
				   CASE 
						WHEN  ( #payment.iddeputy is not null)  and (abi_label = 'SEPACREDITTRANSFER') THEN  cf_ben
						ELSE NULL
				   END,
				   --- Bollo
				   replace(stamphandling, ' ','') ,
				   -- causale esenzione bollo
				   case
				     WHEN (fulfilled = 'S') THEN 'DOCUMENTO A REGOLARIZZAZIONE DI PROVVISORI/SOSPESI'
					 WHEN (stamp_charge = 'S' ) THEN exemption_stamp_motive
					  ELSE null
  				   END,
				   -- Carico spese
  				    replace(chargehandling, ' ',''),
				   exemption_charge_payment_kind,
				   exemption_charge_motive,
  				   CASE 
						WHEN ((deny_bank_details <> 'S')  AND (ISNULL(abi_label, 'CASSA') = 'ACCREDITOCONTOCORRENTEPOSTALE') AND (fulfilled = 'N')) THEN  cc
						ELSE NULL
				   END, 
  				   -- SEPA CREDIT TRANSFER ACCREDITO / TESORERIA PROVINCIALE STATO PER TAB B--
  				   CASE 
						WHEN ((abi_label IN ('SEPACREDITTRANSFER','ACCREDITOTESORERIAPROVINCIALESTATOPERTABB')) AND (fulfilled = 'N')) THEN  iban
						ELSE NULL
				   END,
				   CASE 
						WHEN ((abi_label = 'SEPACREDITTRANSFER') AND (fulfilled = 'N')) THEN  biccode
						ELSE NULL
				   END,
				   CASE 
						WHEN ((abi_label = 'SEPACREDITTRANSFER') AND (fulfilled = 'N')) THEN  id_end_to_end
						ELSE NULL
				   END,
				   code,
				   CASE 
						WHEN ((abi_label = 'SEPACREDITTRANSFER') AND (fulfilled = 'N')) THEN  proprietary
						ELSE NULL
				   END,
  				   -- CODICE INPS -- 
  				   null,
  				   SUBSTRING(paymentdescr,1,160), -- CAUSALE PAGAMENTO
  				   -- SOSPESO -- 
  				   null,
				   -- Riferimento Documento Esterno  
				   case when ((abi_label IN ('DISPOSIZIONEDOCUMENTOESTERNO','BONIFICOESTEROEURO'))   AND (fulfilled = 'N') AND autokind IN (20,21,30,31) AND (code <> 'SALA') ) 
						then 'STIPENDI TX' 
						when abi_label='SEPACREDITTRANSFER' then null /* si Tipo pagamento SEPACREDITTRANSFER, non devono essere compilate le note al tesoriere perchè altrimenti il mandato viene scartato.*/
						else  SUBSTRING(isnull(expenselast_paymentdescr,''),1,400)  end,	 --+ ' '+ isnull(#payment.txt,'')
				   --avviso_pagopa
				   pagopanoticenum,
				   -- Informazioni Tesoriere
				   null,
				   null
FROM #payment
LEFT JOIN #deputy
	ON #payment.iddeputy = #deputy.iddeputy
	GROUP BY
		#payment.ndoc, #payment.idpay,#payment.idexp, abi_label, fulfilled,deny_bank_details, destinazione, tipo_contabilita_ente_ricevente,extracode,#payment.autokind,
		title_ben, address_ben, cap_ben, location_ben, province_ben,iso_code_ben,
		pi_ben, cf_ben,
		#deputy.title_deputy,  #deputy.address_deputy,  #deputy.cap_deputy,#deputy.location_deputy,
		#deputy.province_deputy,#deputy.nation_deputy,  #deputy.cf_deputy,#deputy.p_iva_deputy,
		ABI, CAB, cc, cin_iban, cin,codice_paese, bank, iban,biccode,id_end_to_end,code, proprietary,
		paymentdescr, stamphandling, stamp_charge, exemption_stamp_motive, 
		refexternaldoc,expenselast_paymentdescr, chargehandling,exemption_charge_payment_kind,
		exemption_charge_motive, expiration, bank_charges_exempt,#payment.iddeputy,pagopanoticenum
		 --,#payment.autokind
ORDER BY #payment.ndoc, #payment.idpay,#payment.idexp

INSERT INTO #trace(
					kind,
					ndoc,
					idpay,idexp,
					codice_cgu,
					codice_cup,
					codice_cpv,
					--importoclassificazionemov,
					importo_siope,
					tipo_debito_siope,
					codice_cig_siope,
					motivo_esclusione_cig_siope,
					codice_ipa_ente_siope,
	
					tipo_documento_siope, -- ELETTRONICO o ANALOGICO
					identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
					tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
					/*Se cartacea*/
					codice_fiscale_emittente_siope,
					anno_emissione_fattura_siope ,
	
					/*ctDati_fattura_siope*/
					numero_fattura_siope, 
					natura_spesa_siope,
					--utilizzo_nota_di_credito, DOPO IL 1 LUGLIO 2019
					data_scadenza_pagam_siope,
					motivo_scadenza_siope
				   )
SELECT 
				   'CLASSIFICAZIONI_FATTURASIOPE',
				   ndoc,
				   idpay, idexp, 
				   sortcode,
				   ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, cupcodefin))),
				   null,
				   --SUM(#siope.amount),
				   	--SUM(importoclassificazionemov), 
					importo_siope,
					tipo_debito_siope,
					CASE WHEN (ISNULL(replace(motivo_esclusione_cig_siope, ' ','') ,'') = '') THEN UPPER(codice_cig_siope) ELSE NULL END ,
					replace(motivo_esclusione_cig_siope, ' ','') ,
					codice_ipa_ente_siope,
	
					tipo_documento_siope,
					identificativo_lotto_sdi_siope,
					tipo_documento_analogico_siope,
					/*Se cartacea*/
					codice_fiscale_emittente_siope,
					anno_emissione_fattura_siope,
	
					/*ctDati_fattura_siope*/
					numero_fattura_siope,
					natura_spesa_siope,
					--utilizzo_nota_di_credito,DOPO IL 1 LUGLIO 2019
					CONVERT(VARCHAR(10),data_scadenza_pagam_siope,20),
					motivo_scadenza_siope
FROM #siope
ORDER BY  ndoc, idpay, sortcode

INSERT INTO #trace(kind,ndoc,idpay,idexp,
	codice_cgu, codice_missione_siope,
	codice_programma_siope,
	codice_economico_siope,
	importo_codice_economico_siope,
	codice_UE_siope, 
	codice_cofog_siope,
	importo_cofog_siope)
SELECT 
	'ARCONET',
	ndoc,	idpay,	idexp,
	codice_economico_siope, codice_missione_siope,
	codice_programma_siope,
	codice_economico_siope,
	importo_codice_economico_siope,
	codice_UE_siope, 
	codice_cofog_siope,
	importo_cofog_siope
FROM #dati_arconet

INSERT INTO #trace(
					kind,
					ndoc,
					idpay,idexp,
					codice_cgu,
					codice_cup,
					codice_cpv,
					importoclassificazionemov,
					--importo_siope,
					tipo_debito_siope,
					codice_cig_siope,
					motivo_esclusione_cig_siope
					--codice_ipa_ente_siope,
	
					--tipo_documento_siope, -- ELETTRONICO o ANALOGICO
					--identificativo_lotto_sdi_siope, -- E' un INT!!!!!! /*Se FE*/
					--tipo_documento_analogico_siope , -- FATT_ANALOGICA o DOC_EQUIVALENTE
					--/*Se cartacea*/
					--codice_fiscale_emittente_siope,
					--anno_emissione_fattura_siope ,
	
					--/*ctDati_fattura_siope*/
					--numero_fattura_siope, 
					--natura_spesa_siope,
					--data_scadenza_pagam_siope,
					--motivo_scadenza_siope
				   )
SELECT		       'CLASSIFICAZIONI',
				   ndoc,
				   idpay, idexp, 
				   sortcode,
				   ISNULL(cupcodeexpense,ISNULL(cupcodedetail, ISNULL(cupcodeupb, cupcodefin))),
				   null,
				   	importoclassificazionemov, 
					--SUM(importo_siope),
					tipo_debito_siope,
					CASE WHEN (ISNULL(replace(motivo_esclusione_cig_siope, ' ','') ,'') = '') THEN UPPER(codice_cig_siope) ELSE NULL END ,
					replace(motivo_esclusione_cig_siope, ' ','') 
					--codice_ipa_ente_siope,
	
					--tipo_documento_siope,
					--identificativo_lotto_sdi_siope,
					--tipo_documento_analogico_siope,
					--/*Se cartacea*/
					--codice_fiscale_emittente_siope,
					--anno_emissione_fattura_siope,
	
					--/*ctDati_fattura_siope*/
					--numero_fattura_siope,
					----importo_siope ,
					--natura_spesa_siope,
					--CONVERT(VARCHAR(10),data_scadenza_pagam_siope,20),
					--motivo_scadenza_siope
FROM #siope
where flagnc='N' -- Prende le righe della classificazione Fattura o mov principale. 
ORDER BY  ndoc, idpay, sortcode


-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI CON RITENUTE CHE DEVONO ESSERE
-- A CARICO DEL BENEFICIARIO

INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,idexp,
				   importo_ritenute,
				   numero_reversale,
				   progressivo_versante
				   )
SELECT 
				   'RITENUTE',
				   ndoc,
				   idpay, idexp,
				   sum(curramount),
				   npro,
				   idpro	   	
FROM #tax 
GROUP BY  #tax.ndoc,#tax.idpay, #tax.idexp,#tax.npro, #tax.idpro		 
ORDER BY  #tax.ndoc,#tax.idpay, #tax.idexp,#tax.npro, #tax.idpro

-- RECORD CHE DEVE ESSERE GESTITO PER QUEI 
-- PAGAMENTI RELATIVI ALL'APPLICAZIONE DEI CONTRIBUTI (ES. IRAP)
-- CON CORRISPONDENTE MOVIMENTO DI ENTRATA SU PARTITA DI GIRO
INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay,idexp,
				   importo_ritenute,
				   numero_reversale,
				   progressivo_versante
				   )
SELECT 
				   'RITENUTE',
				   ndoc,
				   idpay, idexp,
				   sum(curramount),
				   npro,
				   idpro	   	
FROM #admintax 
GROUP BY  #admintax.ndoc,#admintax.idpay, #admintax.idexp, #admintax.npro, #admintax.idpro		 
ORDER BY  #admintax.ndoc,#admintax.idpay, #admintax.idexp, #admintax.npro, #admintax.idpro

  


INSERT INTO #trace(
				   kind,
				   ndoc,
				   idpay, idexp,
				   importo_provvisorio,
				   numero_provvisorio
				   )
SELECT 
				   'SOSPESI',
				   ndoc,
				   idpay,  idexp,
				   amount,
				   nbill    	
FROM #expensebill
ORDER BY  #expensebill.ndoc, #expensebill.idpay, #expensebill.nbill

if(@ischeck='N')
Begin
	SELECT * FROM #trace 
	--where ndoc = 21416
End
Else
Begin
	select kind, ndoc, importo_mandato, idexp, 
	anagrafica_beneficiario,importo_beneficiario, 
	codice_cgu,	 importoclassificazionemov,
	 tipo_debito_siope, importo_siope,
	importo_codice_economico_siope,
	importo_cofog_siope,tipo_operazione,tipo_documento_siope,identificativo_lotto_sdi_siope
	FROM #trace 
	where kind <>'TESTATA'
End



END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

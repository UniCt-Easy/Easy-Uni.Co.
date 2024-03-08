
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



--setuser'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_liquidazioneperiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_liquidazioneperiva]
GO
 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_liquidazioneperiva] (
	@esercizio int,   --- anno solare
	@trimestre int    --- varia da 1 a 4
)
AS
BEGIN

--	exec exp_mod_liquidazioneperiva 2022, 4
 
CREATE TABLE #ivapay 
(
	kind varchar(2), -- F Frontespizio, VP Modulo VP
	yivapay int,
	nivapay int,
	CodiceFornitura varchar(5),
	CodiceFiscaleDichiarante varchar(16),
	CodiceCarica varchar(2),
	IdSistema varchar(10),
	CodiceFiscale varchar(16),
	PartitaIVA varchar(16),
	AnnoImposta int ,
	modulo int, -- @mese -  @meseinizio  + 1 as '@modulo',
	mese int ,  
	meseinizio int,
	mesefine int,
	saldo_iniziale decimal(19,2),
	metodoacconto varchar(10),
	TotalCreditAcconto decimal(19,2), 

	start datetime,
	stop datetime,
	TotaleOperazioniAttive decimal(19,2),
	TotaleOperazioniPassive decimal(19,2),

	IvaEsigibile decimal(19,2),
	IvaDetratta decimal(19,2),
	IvaDovuta decimal(19,2),
	IvaCredito decimal(19,2),
	DebitoPrecedente decimal(19,2),
	TotalCreditoResiduoLiqPrecedenti decimal(19,2),
	CreditoPeriodoPrecedente decimal(19,2),
	CreditoAnnoPrecedente decimal(19,2),

	Acconto decimal(19,2),
	ImportoDaVersare decimal(19,2),
	ImportoACredito decimal(19,2),
	ivapayexpense decimal(19,2),
	ivapayincome decimal(19,2)
)

--	and month(start) between @startmounth and @stopmounth
DECLARE @idtrasmissiondocument varchar(10)
SET @idtrasmissiondocument = 'LIQUIVA'

CREATE TABLE #error (message varchar(400))
 
IF(
(SELECT COUNT(*) FROM trasmissionmanager
WHERE idtrasmissiondocument = @idtrasmissiondocument and ayear = @esercizio ) = 0)
BEGIN
	INSERT INTO #error
	VALUES('Inserire il Responsabile della trasmissione del modello COMUNICAZIONE LIQUIDAZIONI PERIODICHE IVA. Andare in Opzioni\Configurazione\Responsabile della trasmissione...')
END 

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

/*
1   <Fornitura>											<1.1>	
	1.1   <Intestazione>								Blocco obbligatorio		<1.1>	
		1.1.1   <CodiceFornitura>						xs:string	L'elemento è obbligatorio e contiene il codice della fornitura	"Valori ammessi:[ IVP17]"	<1.1>	5
		1.1.2   <CodiceFiscaleDichiarante>				xs:string	"Codice fiscale del soggetto obbligato alla trasmissione della comunicazione IVA quando non coincide con il soggetto passivo al quale i dati si riferiscono (p.e. tutore, curatore fallimentare etc.). Deve essere valorizzato tranne nei casi in cui il soggetto che appone la firma elettronica sul file:
														- coincide  con il soggetto IVA al quale i dati si riferiscono;
														- è un incaricato del soggetto IVA registrato presso i servizi telematici dell’Agenzia delle Entrate ed autorizzato attraverso le specifiche funzionalità di profilazione riservate ai “gestori incaricati”;
														- è un intermediario (art. 3, commi 2 bis e 3 del DPR 322/1978)"	formato alfanumerico	<0.1>	16
		1.1.3   <CodiceCarica>							xs:string	Codice riferibile al soggetto che invia la comunicazione IVA in relazione alla carica rivestita	"Valori ammessi: vedi tabella generale dei codici di carica disponibile nelle istruzioni del modello IVA annuale"	<0.1>	1 … 2
		1.1.4   <IdSistema>						        xs:string	Campo riservato al Sistema: da NON valorizzare	formato alfanumerico	<0.1>	11 _16
*/
DECLARE @CodiceFornitura varchar(5)
DECLARE @CodiceFiscaleDichiarante varchar(16)
DECLARE @CodiceCarica varchar(2)
DECLARE @IdSistema varchar(10) 

--SET @CodiceFornitura = 'IVP'+ SUBSTRING(convert(varchar(4), @esercizio), 3,2)
SET @CodiceFornitura = 'IVP18' -- sw agenzia non ancora aggiornato
SELECT
	@CodiceFiscaleDichiarante = cf
	FROM trasmissionmanagerview
	WHERE idtrasmissiondocument = @idtrasmissiondocument AND ayear = @esercizio

if (@CodiceFiscaleDichiarante IS NULL)
BEGIN
	INSERT INTO #error
	VALUES('Inserire il Codice Fiscale dell''Anagrafica del Responsabile della trasmissione. Andare in Opzioni\Configurazione\Responsabile della trasmissione e cercare l''Anagrafica relativa...')
END 

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

SET @CodiceCarica = '1'  -- "1 Rappresentante legale, negoziale o di fatto, socio amministratore"

INSERT INTO #ivapay
(
	kind, -- I Intestazione F Frontespizio, VP Modulo VP
	CodiceFornitura,
	CodiceFiscaleDichiarante,
	CodiceCarica,
	IdSistema
)
SELECT 
	'I',
	@CodiceFornitura AS '@CodiceFornitura',
	@CodiceFiscaleDichiarante AS '@CodiceFiscaleDichiarante',
	@CodiceCarica AS '@CodiceCarica',
	@IdSistema AS '@IdSistema'


/*	1.2   <Comunicazione>								Blocco contenente i dati della comunicazione trimestrale IVA		<1.1>	
		1.2.1   <Frontespizio>							Blocco contenente i dati del fronterspizio della comunicazione trimestrale IVA		<1.1>	
			1.2.1.1   <CodiceFiscale>					xs:string	Codice fiscale del soggetto cui si riferisce la comunicazione trimestrale IVA	formato alfanumerico	<1.1>	11 … 16
			1.2.1.2   <AnnoImposta>					    xs:string	Anno di imposta  cui si riferisce la comunicazione	formato numerico	<1.1>	4
			1.2.1.3   <PartitaIVA>					    xs:string	Partita IVA del soggetto cui si riferisce la comunicazione trimestrale IVA	formato alfanumerico	<1.1>	11
			1.2.1.4   <PIVAControllante>			    xs:string	Partita IVA dell'ente o società controllante  nel caso di liquidazione di gruppo ultimo comma dell’art. 73,	formato alfanumerico	<0.1>	11
			1.2.1.5   <UltimoMese>					    xs:string	Ultime mese di controllo nel caso di interruzione della liquidazione di gruppo ultimo comma dell’art.73.	"Valori ammessi: [1] [2] [3] [4] [5] [6] [7] [8] [9] [10] [11] [13] [99]"	<0.1>	1 … 2
			1.2.1.6   <LiquidazioneGruppo>			    xs:string	Indica se la comunicazione si riferisce alla liquidazione di gruppo dell’ultimo comma dell’art. 73,	"Valori ammessi:[0] [1]"	<0.1>	1
			1.2.1.7   <CFDichiarante>					xs:string	Codice fiscale del dichiarante persona fisica che sottoscrive la Comunicazione	formato alfanumerico	<0.1>	16
			1.2.1.8   <CodiceCaricaDichiarante>			xs:string	Codice di carica del dichiarante	formato numerico	<0.1>	1 … 2
			1.2.1.9   <CodiceFiscaleSocieta>			xs:string	Codice fiscale della società dichiarante 	formato alfanumerico	<0.1>	11
			1.2.1.10  <FirmaDichiarazione>			    xs:string	Indica la presenza della firma del contribuente o di chi ne ha la rappresentanza legale o negoziale	"Valori ammessi:[0] [1]"	<1.1>	1
			1.2.1.11  <CFIntermediario>					xs:string	Codice fiscale dell'incaricato alla trasmissione	formato alfanumerico	<0.1>	16
			1.2.1.12  <ImpegnoPresentazione>			xs:string	Tipo di impegno a trasmettere; vale 1 se la comunicazione è stata predisposta dal contribuente, o   2  se è stata predisposta da chi effettua l'invio	"Valori ammessi:[1] [2]"	<0.1>	1
			1.2.1.13   <DataImpegno>					xs:string	Data (giorno, mese e anno) di assunzione dell’impegno a trasmettere	formato ggmmaaaa	<0.1>	8
			1.2.1.14   <FirmaIntermediario>				xs:string	Indica la presenza della firma da parte dell'intermediario	"Valori ammessi:[0] [1]"	<0.1>	1
			1.2.1.15   <FlagConferma>					xs:string	Flag , la cui  valorizzazione a 1 indica presenza di anomalie nella comunicazione	"Valori ammessi:[0] [1]"	<0.1>	1
			1.2.1.16   <IdentificativoProdSoftware>		xs:string	Elemento a disposizione dei produttori di software	formato alfanumerico	<0.1>	1 … *
*/



DECLARE @CodiceFiscale varchar(16)
DECLARE @PartitaIVA varchar(11)
SELECT
	@CodiceFiscale = license.cf,
	@PartitaIVA = license.p_iva
FROM license

DECLARE @esercizioImposta int
SET @esercizioImposta =@esercizio


INSERT INTO #ivapay
(
	kind, -- I Intestazione, F Frontespizio, VP Modulo VP
	CodiceFiscale,
	PartitaIVA,
	AnnoImposta
)
SELECT 
	'F',
	@CodiceFiscale AS '@CodiceFiscale',
	@PartitaIVA AS '@PartitaIVA',
	@esercizioImposta AS '@esercizioImposta'

/*
		1.2.2   <DatiContabili>							Blocco relativo ai dati contabili della comunicazione IVA		<1.1>	
				1.2.2.1   <Modulo>						Blocco contenente i dati dei moduli della comunicazione trimestrale IVA. E' obbligatoria la presenza di almeno un modulo fino ad un massimo di cinque 		<1.5>	
				1.2.2.1.1   <Mese>				xs:string	Mese di riferimento della liquidazione IVA	"Valori ammessi:[1] [2] [3] [4] [5] [6] [7] [8] [9] [10] [11] [12]"	<0.1>	1 … 2
				1.2.2.1.2   <Trimestre>				xs:string	Trimestre di riferimento della liquidazione IVA	"Valori ammessi:[1] [2] [3] [4] [5]"	<0.1>	1
				1.2.2.1.3   <Subfornitura>				xs:string	Indica se il contribuente si è avvalso delle agevolazioni previste dall’art. 74, comma 5	"Valori ammessi:[0] [1]"	<0.1>	1
				1.2.2.1.4   <EventiEccezionali>				xs:string	Riservato ai soggetti chehanno fruito per il periodo di riferimento, agli effetti dell’IVA,delle agevolazioni fiscali	"Valori ammessi:[1] [9]"	<0.1>	1
				1.2.2.1.5   <TotaleOperazioniAttive>				xs:decimal	Ammontare complessivo delle cessioni/prestazioni al netto dell'IVA effettuate nel periodo di riferimento	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.6   <TotaleOperazioniPassive>				xs:decimal	Ammontare complessivo degli acquisti al netto dell'IVA effettuati nel periodo di riferimento	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.7   <IvaEsigibile>				xs:decimal	Ammontare IVA a debito relativo alle operazioni attive del periodo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.8   <IvaDetratta>				xs:decimal	Ammontare IVA da portare in detrazione del periodo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.9   <IvaDovuta>				xs:decimal	Vale  (IvaEsigibile - IvaDetratta) se positiva 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.10  <IvaCredito>				xs:decimal	Vale  (IvaDetratta - IvaEsigibile) se positiva 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.11  <DebitoPrecedente>				xs:decimal	Importo a debito non versato nel periodo precedente in quanto non superiore a 25,82 euro	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.12  <CreditoPeriodoPrecedente>				xs:decimal	Ammontare IVA a credito computata in detrazione, risultante dalle liquidazioni precedenti	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.13  <CreditoAnnoPrecedente>				xs:decimal	Ammontare IVA a credito compensabile che viene portato in detrazione e risultante dalla dichiarazione annuale dell'anno precedente	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.14  <VersamentiAutoUE>				xs:decimal	Ammontare complessivo dei versamenti relativi all'imposta dovuta per la prima cessione interna di autoveicoli	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.15  <CreditiImposta>				xs:decimal	Ammontare dei particolari crediti di imposta utilizzati nel periodo di riferimento a scomputo del versamento	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.16  <InteressiDovuti>				xs:decimal	Ammontare degli interessi dovuti relativamente alla liquidazione del trimestre	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.17  <Acconto>						xs:decimal	Amontare dell'acconto dovuto anche se non effettivamente versato 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.18  <ImportoDaVersare>				xs:decimal	Vale (IvaDovuta - IvaCredito +  DebitoPrecedente + InteressiDovuti – CreditiImposta – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - VersamentiAutoUE - Acconto)  se positivo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				1.2.2.1.19  <ImportoACredito>				xs:decimal	Vale  (IvaDovuta - IvaCredito +  DebitoPrecedente + InteressiDovuti – CreditiImposta – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - VersamentiAautoUE - Acconto) se negativo senza segno	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
				*/


DECLARE @meseinizio int
DECLARE @mesefine int
 
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7 
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9 
			when @trimestre = 4 then 12
			End
 
DECLARE @mese int
CREATE TABLE #mesi (mese int)

INSERT INTO #mesi
SELECT @meseinizio
  
INSERT INTO #mesi
SELECT @meseinizio +1

INSERT INTO #mesi
SELECT @mesefine

DECLARE @saldo_iniziale decimal (19,2)
SELECT  @saldo_iniziale = ISNULL(-startivabalance,0) from config where ayear = @esercizio

DECLARE @TotalDebitLiqPrecedenti DECIMAL(19,2)
DECLARE @TotalCreditiLiqPrecedenti DECIMAL(19,2)
SET @TotalDebitLiqPrecedenti = 0
SET @TotalCreditiLiqPrecedenti = 0
DECLARE @TotalCreditoResiduoLiqPrecedenti DECIMAL(19,2)
SET @TotalCreditoResiduoLiqPrecedenti = 0

-- DETERMINAZIONE EVENTUALE ACCONTO IVA VERSATO NEL MESE DI DICEMBRE
DECLARE @TotalCreditAcconto DECIMAL(19,2)
SELECT @TotalCreditAcconto = ISNULL(sum(creditamount) ,0)
FROM ivapay
WHERE paymentkind = 'A'
	AND yivapay = @esercizio
	AND ((ivapay.flag&1) <> 0 )   --- iva commerciale e promiscua


-- LETTURA DELLE LIQUIDAZIONI IVA DEL RANGE CONSIDERATO
-- FATTURE DI TIPO COMMERCIALE O PROMISCUO, NO ISTITUZIONALI O SPLIT PAYMENT

DECLARE @yivapay INT
DECLARE @nivapay INT
DECLARE @paymentkind CHAR
DECLARE @start DATETIME
DECLARE @stop DATETIME
DECLARE @month INT
DECLARE @totaldebit decimal(19,2)
DECLARE @totalcredit decimal(19,2)
DECLARE @prev_debit  decimal(19,2)
DECLARE @startcredit_applied decimal(19,2)
DECLARE @crs cursor
SET @crs = CURSOR FOR
SELECT 
	   yivapay, 
	   nivapay,
	   ISNULL(paymentkind,'C'), -- A Acconto, C Saldo
	   start,
	   stop,
	   isnull(month(start),#mesi.mese), 
	   ISNULL(totaldebit,0),
	   ISNULL(totalcredit,0),
	   ISNULL(prev_debit,0), -- saldo periodo precedente (positivo o negativo)
	   ISNULL(startcredit_applied, 0)  -- credito iniziale applicatyo
FROM #mesi
LEFT OUTER JOIN  ivapay ON month(start) = #mesi.mese
    AND paymentkind = 'C'
	AND yivapay = @esercizio
	and year(start) = @esercizio
	AND month(start) BETWEEN @meseinizio AND @mesefine
	AND ((ivapay.flag&1) <> 0)   --- iva commerciale e promiscua
ORDER BY    ISNULL(paymentkind,'C'),  #mesi.mese

OPEN @crs
FETCH NEXT FROM @crs INTO @yivapay, @nivapay,@paymentkind,@start,@stop,@month, @totaldebit, @totalcredit, @prev_debit,@startcredit_applied
WHILE (@@FETCH_STATUS = 0)
BEGIN
	
DECLARE @TotaleOperazioniAttive decimal(19,2)  --- imponibile
/*
   VP2 "Totale operazioni attive"   va indicato l'ammontare al netto dell'iva delle operazioni:
   imponibili sia ad iva immediata che ad iva differita (indipendentemente se incassate o no) incluse le operazioni in split payment.
   non imponibili/esenti/non soggette
   INFO: Visto che vanno ricomprese solo ed esclusivamente le operazioni 
   COMMERCIALI (ad esclusione di quelle istituzionali. le operazioni promiscue non le utilizza più nessuno) 
   e in Easy i tipi documento iva non hanno indicazione del tipo attività, 
   ci si dovrebbe basare sui registri iva (sui quali è definito il tipo attività).
   Quindi va ricompreso nel quadro VP2 l'ammontare delle operazioni attive (imponibile della fattura di vendita) 
   relative ai tipi documento con flag contabilizzazione "movimenti di entrata"* associati ai registri iva (opzioni > iva > registri iva) 
   con flag su tipo di attività COMMERCIALE e tipo di protocollo VENDITE
*/

DECLARE @TotaleOperazioniPassive decimal(19,2)
/*
- VP3 "Totale operazioni passive"   va indicato l'ammontare al netto dell'iva delle operazioni:
   imponibili sia ad iva immediata che ad iva differita (indipendentemente se pagate o no) 
   incluse le operazioni in split payment.
   non imponibili/esenti/non soggette
   INFO: Visto che vanno ricomprese solo ed esclusivamente le operazioni COMMERCIALI 
   (ad esclusione di quelle istituzionali. le operazioni promiscue non le utilizza più nessuno) 
   e in Easy i tipi documento iva non hanno indicazione del tipo attività, 
   ci si dovrebbe basare sui registri iva (sui quali è definito il tipo attività)
   Quindi va ricompreso nel quadro VP3 l'ammontare delle operazioni passive (imponibile della fattura di acquisto) 
   relative ai tipi documento con flag contabilizzazione "movimenti di spesa"*  
   associati ai registri iva (opzioni > iva > registri iva) con flag su tipo di attività COMMERCIALE e tipo di protocollo ACQUISTO
   Escludiamo talune tipologie di aliquote iva esenti che corrispondono ai seguenti tipi imposizione
   -/*Fuori campo*/
   - /*Escluse Articolo 15*/ 
*/
SELECT @TotaleOperazioniPassive = ISNULL(sum(CASE WHEN (flagvariation = 'S' OR  flagbuysell ='V') /*anche le fatture contabilizzate come vendita*/
																								  /*ma con doppia registrazione, sono identificate come note di credito*/
											THEN - taxable_euro ELSE taxable_euro END),0) 
FROM  invoicedetailview 
 JOIN ivaregister 
	ON ivaregister.idinvkind = invoicedetailview.idinvkind
	AND ivaregister.yinv = invoicedetailview.yinv
	AND ivaregister.ninv = invoicedetailview.ninv
JOIN ivaregisterkind 
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
WHERE registerclass = 'A' AND  (flagactivity = 2 /*commerciale*/ OR  flagactivity = 3 /*promiscua*/) 
AND (flagbuysell ='A' OR (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = invoicedetailview.idinvkind
					and RK.registerclass<>'P'
				) = 2 ) 
AND month(adate) = @month and year(adate)= @esercizio
AND Idivataxablekind NOT IN (5, /*Fuori campo*/ 6  /*Escluse Articolo 15*/ )


SELECT @TotaleOperazioniAttive = 
ISNULL(sum(CASE WHEN (flagvariation = 'S' OR flagbuysell ='A')  THEN - taxable_euro ELSE taxable_euro END),0) FROM  invoicedetailview 
 JOIN ivaregister 
	ON ivaregister.idinvkind = invoicedetailview.idinvkind
	AND ivaregister.yinv = invoicedetailview.yinv
	AND ivaregister.ninv = invoicedetailview.ninv
JOIN ivaregisterkind 
	ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind
WHERE registerclass = 'V' 
AND (flagactivity = 2 /*commerciale*/ OR  flagactivity = 3 /*promiscua*/)
AND (flagbuysell ='V' OR  (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = invoicedetailview.idinvkind
					and RK.registerclass<>'P'
				) = 1 )

AND month(adate) = @month and year(adate)= @esercizio
AND Idivataxablekind NOT IN (5, /*Fuori campo*/ 6  /*Escluse Articolo 15*/ )



DECLARE @IvaEsigibile decimal(19,2) -- Ammontare IVA a debito relativo alle operazioni attive del periodo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
/*
- VP4 "Iva esigibile" indicare l'ammontare dell'iva a debito (da versare) quindi immediata + divenuta esigibile(*) per operazioni annotate in precedenza
va inclusa anche l'iva derivante dalla doppia annotazione per gli acquisti intracomunitari.  
Il dato deve corrispondere al valore nel campo "Totale iva a debito" della liquidazione iva mensile MA solo relativa ai registri Commerciali, 
protocollo Vendite, associati ai tipi documento con contabilizzazione "movimento di entrata". 
Questo perchè non tutti i clienti calcolano le liquidazioni iva in forma singola con flag su Commerciale 
ma molti calcolano la liquidazione includendo tutte le opzioni (Commerciale, Iva Istituzionale Intra 12 e Iva Split Istituzionale)   
(*) SOLO IVA, in quanto il relativo imponibile è stato indicato nel VP2 del relativo periodo
*/
--- totaldebit di ivapay
SET @IvaEsigibile = @totaldebit
DECLARE @IvaDetratta  decimal(19,2) -- Ammontare IVA da portare in detrazione del periodo	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
/*
- VP5 "Iva detratta" indicare l'ammontare dell'iva detraibile quindi immediata + divenuta detraibile(*) per operazioni annotate in precedenza.  
 Il dato deve corrispondere al valore nel campo "Totale iva a credito" della liquidazione iva mensile MA solo relativa ai registri Commerciali, protocollo Acquisti, associati a tipi documento con contabilizzazione "movimento di spesa". Questo perchè non tutti i clienti calcolano le liquidazioni iva in forma singola con flag su Commerciale ma molti calcolano la liquidazione includendo tutte le opzioni (Commerciale, Iva Istituzionale Intra 12 e Iva Split Istituzionale) 
(*) SOLO IVA, in quanto il relativo imponibile è stato indicato nel VP2 del relativo periodo
*/
---totalcredit di ivapay
SET @IvaDetratta = @totalcredit

DECLARE @IvaDovuta 	  decimal(19,2) -- Vale  (IvaEsigibile - IvaDetratta) se positiva 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
if (@totaldebit - @totalcredit) > 0 SET @IvaDovuta =  (@totaldebit - @totalcredit) else SET @IvaDovuta = 0

DECLARE @IvaCredito   decimal(19,2) -- Vale  (IvaDetratta - IvaEsigibile) se positiva 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
/*
- VP6 "Iva dovuta"  se VP4 > VP5 riportare l'importo nel campo VP6.1     
                    se VP4 < VP5 riportare l'importo in valore assoluto nel campo VP6.2  (iva a credito)
*/
--if (totalcredit - totaldebit) > 0 then (totalcredit - totaldebit) else 0
if (@totalcredit - @totaldebit ) > 0 SET @IvaCredito =  (@totalcredit - @totaldebit ) else SET @IvaCredito = 0
DECLARE @DebitoPrecedente decimal(19,2) -- Importo a debito non versato nel periodo precedente in quanto non superiore a 25,82 euro	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
/*
- VP7 "Debito periodo precendente non superiore a 25,82 euro" riportare l'importo a debito non versato se nella precedente comunicazione il campo VP6.1 è < 25,82 euro
Nota di Commento: In questo caso la norma dice che per una liquidazione IVA non si supera una soglia (attualmente di 25,82) il versamento può non essere effettuato e riportato a debito nella liquidazione periodica successiva.
Il caso è abbastanza raro nelle università però deve essere comunque contemplato.
In Easy abbiamo la conifgurazione del limite minimo del versamento per l'VA. Per un importo inferiore il programma non genera movimentazione finanziaria e riporta il debito nel periodo precedente. Petanto il riporto viene gestito in EASY deve essere verificato come possiamo individuare questo riporto nella liquidazione periodica. 
L'importo del debito del periodo precedente riportato in questo campo deve essere solo quello non pagato perchè superiore a 25,82 euro e non quello a debito non pagato per inadempimento.
*/
-- saldo precedente al netto del credito iva anno precedente. Se negativo va nel "debito precedente", se positivo va a finire nel "credito periodo precedente"
if (@prev_debit) > 0  SET @DebitoPrecedente = @prev_debit  ELSE SET @DebitoPrecedente = 0

declare @advancecomputemethod varchar(10) -- Metodo usato per il calcolo dell'Acconto
DECLARE @Acconto		  decimal(19,2)	-- Ammontare dell'acconto dovuto anche se non effettivamente versato 	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
IF ( @month = 12 )   
Begin
	SET @Acconto = @TotalCreditAcconto 
	SET @advancecomputemethod = (select top 1 advancecomputemethod
	from ivapay
	WHERE paymentkind = 'A'
	AND yivapay = @esercizio
	and month(stop) = @month
	AND advancecomputemethod is not null
	AND (ivapay.flag&1) <> 0 )   --- iva commerciale e promiscua
End
else
Begin
	  SET @Acconto = 0
End
/*
- VP13 "Acconto dovuto" A CURA DELL'UTENTE (prevedere un campo nel form di generazione della comunicazione)
il valore è inseribile nel solo modulo relativo al mese di dicembre e deve essere preso dalla liquidazione iva "acconto" (da test software SOGEI)
In Easy corrisponde al campo "nuovo saldo" della liquidazione iva di tipo "Acconto"
*/

DECLARE @CreditoPeriodoPrecedente decimal(19,2) --Ammontare IVA a credito computata in detrazione, risultante dalle liquidazioni precedenti	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16CreditoAnnoPrecedente>	decimal(19,2) --Ammontare IVA a credito compensabile che viene portato in detrazione e risultante dalla dichiarazione annuale dell'anno precedente	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
-- solitamente si usa non a gennaio ,a febbraio

if (-@prev_debit - @startcredit_applied -@Acconto) >= 0 --- credito periodo precedente, al netto del credito anno precedente
    SET @CreditoPeriodoPrecedente = (-@prev_debit - @startcredit_applied -@Acconto)  ELSE SET @CreditoPeriodoPrecedente = 0
/*
- VP8 "Credito periodo precedente" riportare il valore del campo VP14.2 del periodo precedente (mese)  In Easy corrisponde al campo "Saldo precedente" nel form della liquidazione iva.
*/	

DECLARE @CreditoAnnoPrecedente decimal(19,2) --Ammontare IVA a credito compensabile che viene portato in detrazione e risultante dalla dichiarazione annuale dell'anno precedente
SET @CreditoAnnoPrecedente = @startcredit_applied
/*
- VP9 "Credito anno precedente" A CURA DELL'UTENTE (prevedere un campo nel form della liquidazione iva) in quanto il credito da dichiarazione precedente potrebbe essere stato utilizzato per la compensazione di altri tributi
*/
 



DECLARE @ImportoDaVersare decimal(19,2)	-- Vale (IvaDovuta - IvaCredito +  DebitoPrecedente + InteressiDovuti – CreditiImposta – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - VersamentiAutoUE - Acconto)  se positivo formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
DECLARE @ImportoACredito  decimal(19,2)	-- Vale (IvaDovuta - IvaCredito +  DebitoPrecedente + InteressiDovuti – CreditiImposta – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - VersamentiAautoUE - Acconto) se negativo senza segno	formato numerico; i decimali vanno separati dall'intero con il carattere  ',' (virgola)	<0.1>	4 … 16
DECLARE @ImportoFinale decimal (19,2)

SET @ImportoFinale = ISNULL(@IvaDovuta ,0)- ISNULL(@IvaCredito,0) + ISNULL(@DebitoPrecedente,0) - ISNULL(@CreditoPeriodoPrecedente,0) - ISNULL(@CreditoAnnoPrecedente,0) - ISNULL(@Acconto,0)

IF (@ImportoFinale) > 0 
BEGIN
SET @ImportoDaVersare = @ImportoFinale
SET @ImportoACredito  = 0
END
ELSE
BEGIN
SET @ImportoACredito  = - @ImportoFinale
SET @ImportoDaVersare = 0
END

/*
- VP14 "Iva da versare o a credito"  indicare nel VP14.1 il saldo se > 0  di:   (VP6.1 +VP7 + VP12) - (VP6.2 + VP8 + VP9 + VP10 + VP11 + VP13)
                                              nel VP14.2 il saldo se > 0  di:   (VP6.2 + VP8 + VP9 + VP10 + VP11 + VP13) - (VP6.1 +VP7 + VP12)
IvaDovuta - IvaCredito +  DebitoPrecedente  – CreditoPeriodoPrecedente – CreditoAnnoPrecedente - Acconto se > 0
-IvaDovuta + IvaCredito -  DebitoPrecedente  + CreditoPeriodoPrecedente + CreditoAnnoPrecedente + Acconto  se > 0
*/


--- in questo caso vado a sommare gli automatismi di spesa e di entrata per l'iva commerciale (filtrando cioè autokind 12)


DECLARE @ivapayexpense decimal(19,2)
DECLARE @ivapayincome decimal(19,2)

SELECT @ivapayexpense = ISNULL(sum(curramount),0)
					    FROM ivapayexpenseview 
						WHERE nphase = 3 and autokind = 12
						AND yivapay = @yivapay
						AND nivapay = @nivapay


SELECT @ivapayincome = ISNULL(sum(curramount),0)
					    FROM ivapayincomeview 
						WHERE nphase = 3 and autokind = 12
						AND yivapay = @yivapay
						AND nivapay = @nivapay


INSERT INTO #ivapay
(
	kind, -- I Intestazione F Frontespizio, VP Modulo VP
	yivapay,
	nivapay,
	modulo, -- @mese -  @meseinizio  + 1 as '@modulo',
	mese,  
	meseinizio,
	mesefine,
	saldo_iniziale,
	TotalCreditAcconto, 
	start,
	stop,
	TotaleOperazioniAttive,
	TotaleOperazioniPassive,

	IvaEsigibile,
	IvaDetratta,
	IvaDovuta,
	IvaCredito,
	DebitoPrecedente,
	TotalCreditoResiduoLiqPrecedenti,
	CreditoPeriodoPrecedente,
	CreditoAnnoPrecedente,

	metodoacconto,
	Acconto,
	ImportoDaVersare,
	ImportoACredito,
	ivapayexpense,
	ivapayincome

)
SELECT 
	'VP',
	@yivapay as '@yivapay',
	@nivapay as '@nivapay',
	@month - @meseinizio +  1 as '@modulo',
	@month as '@mese',
	@meseinizio as '@meseinizio',
	@mesefine as '@mesefine',
	@saldo_iniziale as '@saldo_iniziale(Credito IVA)',
	@TotalCreditAcconto as 'Totale Acconto', 

	@start as '@start',
	@stop as '@stop',
	@TotaleOperazioniAttive as '@TotaleOperazioniAttive',
	@TotaleOperazioniPassive as '@TotaleOperazioniPassive',

	@IvaEsigibile as '@IvaEsigibile',
	@IvaDetratta as '@IvaDetratta',
	@IvaDovuta as '@IvaDovuta',
	@IvaCredito as '@IvaCredito',
	@DebitoPrecedente as '@DebitoPrecedente',
	@TotalCreditoResiduoLiqPrecedenti as '@TotalCreditoResiduoLiqPrecedenti',
	@CreditoPeriodoPrecedente as '@CreditoPeriodoPrecedente',
	@CreditoAnnoPrecedente as '@CreditoAnnoPrecedente',
	@advancecomputemethod as '@MetodoCalcoloAcconto',
	@Acconto as '@Acconto',
	@ImportoDaVersare as '@ImportoDaVersare',
	@ImportoACredito as '@ImportoACredito',
	@ivapayexpense as '@ivapayexpense',
	@ivapayincome as '@ivapayincome'

	FETCH NEXT FROM @crs into @yivapay, @nivapay,@paymentkind,@start,@stop,@month,@totaldebit, @totalcredit, @prev_debit,@startcredit_applied
END


SELECT 	kind, -- I Intestazione F Frontespizio, VP Modulo VP
	CodiceFornitura ,
	CodiceFiscaleDichiarante,
	CodiceCarica,
	IdSistema,
	CodiceFiscale,
	PartitaIVA,
	AnnoImposta,
	yivapay as 'Es. Liquidazione IVA',
	nivapay as 'Num. Liquidazione IVA',
	modulo, -- @mese -  @meseinizio  + 1 as '@modulo',
	mese,  
	meseinizio,
	mesefine,
	saldo_iniziale,
	TotalCreditAcconto, 
	start as 'Inizio',
	stop as 'Fine',
	TotaleOperazioniAttive,
	TotaleOperazioniPassive,

	IvaEsigibile,
	IvaDetratta,
	IvaDovuta,
	IvaCredito,
	DebitoPrecedente,
	TotalCreditoResiduoLiqPrecedenti,
	CreditoPeriodoPrecedente,
	CreditoAnnoPrecedente,
	MetodoAcconto,
	Acconto,
	ImportoDaVersare,
	ImportoACredito,
	ivapayexpense as 'Totale Mov. Fin. Spesa',
	ivapayincome as 'Totale Mov. Fin. Entrata' FROM #ivapay
END

 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

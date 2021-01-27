
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


if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_bancapopbari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_bancapopbari]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE             PROCEDURE [trasmele_income_bancapopbari]
	@y smallint,
	@n int
AS BEGIN
/* Versione 2.0.0 del 03/09/2008 ultima modifica: GIUSEPPE */

CREATE TABLE #error (message varchar(400))

DECLARE @maxincomephase tinyint -- Ultima fase di spesa (fase di cassa)
SELECT @maxincomephase = MAX(nphase) FROM incomephase

DECLARE @lastincomephase varchar(50)
SELECT @lastincomephase = description FROM incomephase WHERE nphase = @maxincomephase

DECLARE @message varchar(250)
DECLARE @dipendenza varchar(5) -- Variabile di dipendenza comunicabile dalla Banca che richiede l'esportazione
DECLARE @codicefiliale varchar(3) -- Codice della filiale
DECLARE @codiceente varchar(9) -- Codice dell'ente da esportare

SELECT @dipendenza = depcodefortransmission,
@codicefiliale = cabcodefortransmission,
@codiceente = agencycodefortransmission
FROM treasurer WHERE flagdefault = 'S'

DECLARE @errore char(1)
SET @errore = 'N'
SET @message = 'Mancano i seguenti dati: '
IF (@dipendenza IS NULL OR @dipendenza = '')
BEGIN
	SET @message = @message + ' Il Codice Istituto'
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

DECLARE @npos int
IF (@y <= 2006)
BEGIN
	SET @codeclassSIOPE = 'SIOPE'
	SET @npos = 2
END
ELSE
BEGIN
	SET @codeclassSIOPE = '07E_SIOPE'
	SET @npos = 1
END

-- Controllo che il movimento sia classificato entro i limiti dei 12 codici
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
	incomesorted.idsor AS idsor,
	income.idreg AS idreg,
	income.ymov AS ydoc,
	proceeds.npro AS ndoc
	FROM income
	JOIN incomelast
		ON income.idinc = incomelast.idinc
	JOIN incomesorted
		ON income.idinc = incomesorted.idinc
	JOIN sorting
		ON sorting.idsor = incomesorted.idsor
	JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	JOIN proceedstransmission
		ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
	WHERE proceedstransmission.yproceedstransmission = @y
	AND proceedstransmission.nproceedstransmission = @n
	AND sorting.idsorkind = @classSIOPE
	GROUP BY income.idreg, income.ymov, proceeds.npro,
	incomesorted.idsor) AS tabella
GROUP BY idreg,ydoc,ndoc
	
DECLARE @limite int
SET @limite = 12
IF EXISTS(SELECT * FROM #nclass_SIOPE WHERE nsorting > @limite)
BEGIN
	INSERT INTO #error (message)
		SELECT 'Nella reversale ' + CONVERT(varchar(6),ndoc) + '/' + CONVERT(varchar(4),ydoc)
		+ ' i movimenti di entrata associati al versante ' + registry.title
		+ ' hanno un numero di classificazioni SIOPE superiore al limite di ' + CONVERT(varchar(3),@limite)
		FROM #nclass_SIOPE
		JOIN registry
			ON #nclass_SIOPE.idreg = registry.idreg
		WHERE nsorting > @limite
		ORDER BY nsorting
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Sezione dichiarativa
DECLARE @tipodocumento char(1) --
DECLARE @numeroconto varchar(28) -- Numero del Conto dell'ente presso l'istituto cassiere
DECLARE @cino char(2) -- Codice CIN
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
SET @lendipendenza = 3
SET @lencodicefiliale = 3
SET @lencodiceente = 9
SET @tipodoc = 'R'
SET @lennumdoc = 7
SET @lennumsubmov = 7
SET @lenritenute = 14
SET @causaleente = '5R'
SET @lenCC = 8
SET @lenCIN = 2
SET @lendescrizione = 60
SET @lencreditore = 50
SET @lenindirizzo = 30
SET @lenlocalita = 25
SET @lencodicepostale = 5
SET @lenprovincia = 2
SET @lencodeSIOPE = 10

-- J.T.R. Su richiesta della Banca Pop. di Bari il CIN del cassiere deve sempre essere 00

SET @cino = '00'
SELECT @numeroconto = ISNULL(cc, ' ')--, @cino = ISNULL(cin, '00') 
FROM treasurer WHERE flagdefault ='S'

IF PATINDEX('%-%',@numeroconto) > 0
	SELECT @numeroconto = SUBSTRING(@numeroconto,1,PATINDEX('%-%',@numeroconto)-1)
IF PATINDEX('%.%',  @numeroconto) > 0
	SELECT @numeroconto = SUBSTRING(@numeroconto,1,PATINDEX('%.%', @numeroconto)-1)
IF PATINDEX('%/%',  @numeroconto) > 0
	SELECT @numeroconto = SUBSTRING(@numeroconto,1,PATINDEX('%/%', @numeroconto)-1)

-- Se il cc è di 12 cifre ed inizia con 4 zeri vengono tolti i 4 zeri
IF (LEN(@numeroconto) = 12) AND (SUBSTRING(@numeroconto,1,4) = '0000')
BEGIN
	SET @numeroconto = SUBSTRING(@numeroconto, 5,LEN(@numeroconto))
END
IF LEN(@numeroconto) > @lenCC
BEGIN
	INSERT INTO #error 
	VALUES ('Il c/c del cassiere eccede la lunghezza di ' + CONVERT(varchar(4),@lenCC) + ' caratteri')
	
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

SET @numeroconto = SUBSTRING(REPLICATE('0',@lenCC),1,@lenCC - LEN(@numeroconto)) + @numeroconto
IF @cino ='' SET @cino ='00'
-- Formattazione dei codici per il riconoscimento della banca, in tal modo risparmio gli N controlli nella UNION
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
-- Fine Formattazione

-- Definizione delle tabelle
CREATE TABLE #reversaleSIOPE
(
	ndoc int,
	kdoc int,
	nsub int,
	codeSIOPE varchar(10),
	amountSIOPE decimal(19,2)
)

CREATE TABLE #stringaSIOPE
(
	ndoc int,
	nsub int,
	stringa varchar(300) -- La banca popolare di Bari accetta fino a 12 classificazioni di cui ogni classificazione occupa 25 posizioni
)

CREATE TABLE  #temp
(
	stri varchar(400) COLLATE SQL_Latin1_General_CP1_CI_AS
)

CREATE TABLE #totale
(
	ndoc int,
	ndocformatted varchar(7),
	kdoc int,
	nsub int,
	amount_proceeds decimal(19,2),
	idreg int,
	description varchar(100)
)
CREATE TABLE #incasso
(
	idinc int,
	agencycode varchar(9),
	kdoc int,
	ydoc int,
	kind varchar(1),
	ndoc int,
	ndocformatted varchar(7),
	fulfilled char(1),
	nmov int,
	amount_submov decimal(19,2),
	idreg int,
	registry varchar(100),
	birthdate smalldatetime,
	cf varchar(16),
	p_iva varchar(15),
	address varchar(100),
	location varchar(30),
	cap varchar(15),
	province varchar(2),
	description varchar(150),
	abi varchar(10),
	cab varchar(10),
	cc varchar(25),
	idpaymethod varchar(9),
	adate smalldatetime,
	accountkind char(1),
	transmissiondate smalldatetime
)

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
	
DECLARE @dateindi datetime
SET @dateindi =
	(SELECT MAX(transmissiondate) FROM proceedstransmission WHERE yproceedstransmission = @y
	AND nproceedstransmission = @n)

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
	when flagforeign = 'N' THEN 'ITALIA'
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
and cdi.idreg = registryaddress.idreg))
AND idreg IN
	(SELECT DISTINCT idreg FROM proceedscommunicated
	where yproceedstransmission = @y AND nproceedstransmission = @n)

DELETE #rptindirizzoavpag
	where #rptindirizzoavpag.idaddresskind <> @nostand
	and exists (
		select * from #rptindirizzoavpag r2 
		where #rptindirizzoavpag.idreg = r2.idreg
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
-- Fine gestione degli indirizzi

SELECT @tipodocumento = 'A'

-- La tabella viene riempita con tutti i movimenti di entrata che rientrano nella distinta di trasmissione.
-- Durante il riempimento si cerca di formattare i dati secondo le specifiche tecniche fornite dalla banca.
INSERT INTO #incasso
(	
	idinc,
	agencycode,
	kdoc,
	ydoc,
	kind,
	ndoc,
	ndocformatted, 
	nmov,
	fulfilled,
	amount_submov,
	idreg,
	registry,
	birthdate,
	cf,
	p_iva,
	address,
	location,
	cap,
	province,
	description,
	abi,
	cab,
	cc,
	idpaymethod,
	adate,
	accountkind,
	transmissiondate
)
SELECT
	income.idinc,
	@codiceente,
	incomelast.kpro,
	income.ymov,
	@tipodocumento,
	proceeds.npro,
	CASE
		WHEN LEN(proceeds.npro)<= @lennumdoc THEN 
			REPLICATE('0', @lennumdoc - LEN(CONVERT(varchar(7), proceeds.npro))) + 
			CONVERT(varchar(7),proceeds.npro)
		ELSE SUBSTRING(CONVERT(varchar(7),proceeds.npro), 1, @lennumdoc)
	END,
	income.nmov,
	CASE
		WHEN (( incomelast.flag & 1)=1) then 'S'
		ELSE 'N'
	END,
	incometotal.curramount,
	registry.idreg,
	CASE
		WHEN LEN(RTRIM(ISNULL(registry.title,''))) <= @lencreditore THEN
			RTRIM(registry.title) + SPACE(@lencreditore - LEN(RTRIM(ISNULL(registry.title, ''))))
		ELSE SUBSTRING(registry.title, 1, @lencreditore)
	END,
	registry.birthdate,
	registry.cf,
	registry.p_iva,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.address,'')) <= @lenindirizzo
		THEN SPACE(@lenindirizzo - DATALENGTH(ISNULL(#rptindirizzoavpag.address,''))) +
		ISNULL(#rptindirizzoavpag.address, '')
		ELSE SUBSTRING(#rptindirizzoavpag.address,1,@lenindirizzo)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.location,'')) <= @lenlocalita
		THEN SPACE(@lenlocalita - DATALENGTH(ISNULL(#rptindirizzoavpag.location,''))) +
		ISNULL(#rptindirizzoavpag.location, '')
		ELSE SUBSTRING(#rptindirizzoavpag.location,1,@lenlocalita)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.cap,'')) <= @lencodicepostale
		THEN REPLICATE('0', @lencodicepostale - DATALENGTH(ISNULL(#rptindirizzoavpag.cap,''))) +
		ISNULL(#rptindirizzoavpag.cap, '')
		ELSE SUBSTRING(#rptindirizzoavpag.cap,1,@lencodicepostale)
	END,
	CASE
		WHEN DATALENGTH(ISNULL(#rptindirizzoavpag.province,'')) <= @lenprovincia
		THEN REPLICATE('0', @lenprovincia - DATALENGTH(ISNULL(#rptindirizzoavpag.province,''))) +
		ISNULL(#rptindirizzoavpag.province, '')
		ELSE SUBSTRING(#rptindirizzoavpag.province,1,@lenprovincia)
	END,
	income.description,
	'0',
	'0',
	'0',
	'0',
	proceeds.adate,
	CASE
		WHEN ((proceeds.flag & 8) = 0) THEN 'I'
		ELSE 'F'
	END,
	proceedstransmission.transmissiondate
FROM income
JOIN incomelast
	ON incomelast.idinc = income.idinc
JOIN incometotal
	ON incometotal.idinc = income.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN proceedstransmission
	ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission
JOIN registry 
	ON registry.idreg = income.idreg
LEFT OUTER JOIN #rptindirizzoavpag
	ON #rptindirizzoavpag.idreg = registry.idreg
WHERE proceedstransmission.yproceedstransmission = @y
	AND proceedstransmission.nproceedstransmission = @n
	AND incometotal.ayear = @y
ORDER BY income.ymov, proceeds.npro

-- Riempimento della tabella #totale con gli incassi raggruppati per reversale e versante
INSERT INTO #totale
(
	ndoc, ndocformatted, kdoc,
	nsub,
	amount_proceeds,
	idreg
)
SELECT 
	ndoc, ndocformatted, kdoc,
	0,
	ISNULL(SUM(amount_submov),0),
	idreg
FROM #incasso
GROUP BY idreg, ndoc, kdoc, ndocformatted

-- Sezione per l'assegnazione del submovimento
/*
  Il submovimento viene calcolato alla stregua dell'uguaglianza dei seguenti campi:
  ID del versante appartenenti alla stessa reversale
*/
DECLARE @codicecreddeb int
DECLARE @numdoc int
DECLARE @numsubmov int
DECLARE @numdoc1 int
DECLARE @numdocold int
DECLARE @codicecreddebold int
SELECT @numsubmov = 0
DECLARE #esercizio_cursor1 INSENSITIVE CURSOR FOR
-- Si definisce il cursore sulla tabella totale (dove i pagamenti sono stati già raggruppati)
SELECT ndoc, idreg FROM #totale

OPEN #esercizio_cursor1
FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @codicecreddeb	
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
			AND idreg = @codicecreddeb

		SELECT @numdocold =  @numdoc
		SELECT @codicecreddebold = @codicecreddeb

		FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @codicecreddeb	
	END 

	-- Se il submovimento è pari a 1 viene reimpostato a zero (sono disposizioni della banca)
	IF @numsubmov = 1 
	BEGIN
		UPDATE #totale SET nsub = 0
		WHERE ndoc = @numdocold AND idreg = @codicecreddebold	
	END
	SELECT @numsubmov = 0
	SELECT @numdoc1 = @numdoc 
END
	
DEALLOCATE #esercizio_cursor1
		
DECLARE @descrizione varchar(100)

-- Si definisce un nuovo cursore per impostare descrizione identici per tutti i sub
DECLARE #esercizio_cursor1 INSENSITIVE CURSOR FOR
SELECT ndoc,idreg,description FROM #incasso
OPEN #esercizio_cursor1
FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @codicecreddeb, @descrizione	
WHILE (@@FETCH_STATUS = 0)
BEGIN
	UPDATE #totale SET description = @descrizione
	WHERE #totale.ndoc = @numdoc 
	AND #totale.idreg = @codicecreddeb	
	FETCH NEXT FROM #esercizio_cursor1 INTO @numdoc, @codicecreddeb, @descrizione
END 
	
DEALLOCATE #esercizio_cursor1

-- Gestione della classificazione SIOPE
-- Riempimento della tabella #reversaleSIOPE, dove vengono inserite tutte le classificazioni dei movimenti di entrata
INSERT INTO #reversaleSIOPE
SELECT #totale.ndoc, #totale.kdoc, #totale.nsub,
SUBSTRING(sorting.sortcode,@npos,LEN(sorting.sortcode)),
SUM(incomesorted.amount)
FROM income
JOIN incomelast
	ON incomelast.idinc = income.idinc
JOIN #totale
	ON incomelast.kpro = #totale.kdoc
	AND income.idreg = #totale.idreg
JOIN incomesorted
	ON income.idinc = incomesorted.idinc
JOIN sorting
	ON incomesorted.idsor = sorting.idsor
WHERE sorting.idsorkind = @classSIOPE
	AND income.ymov = @y
	AND incomesorted.ayear = @y
GROUP BY incomesorted.idsor,
SUBSTRING(sorting.sortcode,@npos,LEN(sorting.sortcode)),
#totale.ndoc, #totale.kdoc, #totale.nsub
	
-- Sezione che trasla i dati presenti in #reversaleSIOPE in #stringaSIOPE
-- In pratica le righe di #reversaleSIOPE di uno stesso sub diventano un'unica riga di #stringaSIOPE
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
SET @numdocSIOPEcurr = 0
SET @numsubmovSIOPEcurr = 0
SET @stringa = ''
SET @lenClassificazione = @lencodeSIOPE + 15 -- 15 = Lunghezza Max Importo

DECLARE siope INSENSITIVE CURSOR FOR
SELECT ndoc, nsub, codeSIOPE, amountSIOPE FROM #reversaleSIOPE
ORDER BY ndoc, nsub
FOR READ ONLY
OPEN siope
FETCH NEXT FROM siope INTO @numdocSIOPE, @numsubmovSIOPE, @codeSIOPE, @amountSIOPE
SET @numdocSIOPEcurr = @numdocSIOPE
SET @numsubmovSIOPEcurr = @numsubmovSIOPE
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

	FETCH NEXT FROM siope INTO @numdocSIOPE, @numsubmovSIOPE, @codeSIOPE, @amountSIOPE

	IF (@numdocSIOPEcurr <> @numdocSIOPE) OR (@numsubmovSIOPEcurr <> @numsubmovSIOPE)
	BEGIN
		SET @numClassificazioniInseriteInRiga = LEN(@stringa) / @lenClassificazione
		SET @counter = @numClassificazioniInseriteInRiga
		WHILE (@counter < @limite)
		BEGIN
			SET @stringa = @stringa + SPACE(@lencodeSIOPE) + REPLICATE('0',15)
			SET @counter = @counter + 1
		END
		INSERT INTO #stringaSIOPE VALUES(@numdocSIOPEcurr,@numsubmovSIOPEcurr,@stringa)
	END
END
SET @numClassificazioniInseriteInRiga = LEN(@stringa) / @lenClassificazione
SET @counter = @numClassificazioniInseriteInRiga
WHILE (@counter < @limite)
BEGIN
	SET @stringa = @stringa + SPACE(@lencodeSIOPE) + REPLICATE('0',15)
	SET @counter = @counter + 1
END
INSERT INTO #stringaSIOPE VALUES(@numdocSIOPEcurr,@numsubmovSIOPEcurr,@stringa)

DEALLOCATE siope

DECLARE @codicebollo varchar(3)
SELECT @codicebollo = 'N'

-- Riempimento della tabella di output
INSERT INTO #temp
SELECT	DISTINCT
-- Codice Istituto
	@dipendenza + 
-- Codice Filiale
	@codicefiliale +
-- Codice Ente
	@codiceente +
-- Esercizio di Riferimento
	convert(varchar(4),ydoc) +
-- Tipo Documento
	@tipodoc +
-- Numero Reversale
	#totale.ndocformatted +
-- Progressivo Sub
	CASE 
		WHEN len(#totale.nsub)<= @lennumsubmov THEN
			substring('0000000', 1, @lennumsubmov - LEN(#totale.nsub))+ convert(VARCHAR(7),#totale.nsub)
		ELSE convert(varchar(7),#totale.nsub)
	END +
-- Tipo Record
	'01' +
-- da Capitolo  a Codice Meccanografico Bilancio
	REPLICATE('0',25) +
-- Causale conto dell'ente
	CASE
		WHEN accountkind = 'F' THEN '6R'
		ELSE '5R'
	END +
-- Filiale del conto corrente ente
---- Codice Filiale
	'000' + 
-- Conto Corrente
	@numeroconto +
-- CIN
	@cino +
-- Contabilità Ordinaria
	'O' +
-- Infruttifero
	#incasso.accountkind +		
-- Accredito
	'+' +
-- Importo della Reversale (o Sub)
--- Importo EURO 12900000.00           11  
	CASE 
		WHEN LEN(#totale.amount_proceeds) <  14  THEN 
			substring('0000000000000000', 1, 15 -LEN(#totale.amount_proceeds) +1)+ 
			SUBSTRING (CONVERT (VARCHAR(15),#totale.amount_proceeds),1,LEN(#totale.amount_proceeds)-3)
		ELSE
			SUBSTRING (CONVERT (VARCHAR(15),#totale.amount_proceeds),1,LEN(#totale.amount_proceeds)-3)
	END +
	SUBSTRING (CONVERT (VARCHAR(15),#totale.amount_proceeds),LEN(#totale.amount_proceeds)-1,
	LEN(#totale.amount_proceeds)) +
-------------------------------------------- 
-------- 	Codice pagamento Sempre 01
-------------------------------------------- 
	'01' +
-- ESENZIONE BOLLO mls 10-04-04
	'S' +
-- Indicativo di bollo a carico
	SPACE(1) +
-- Importo Commissioni
	REPLICATE('0',7) +
	SPACE(1) +
-- data contabile anno/mese/giorno
	CONVERT (varchar(4), DATEPART(YEAR, adate)) +
	SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(MONTH,adate)))) +
	CONVERT(varchar(2),DATEPART(MONTH,adate)) +
	SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(DAY,adate)))) +
	CONVERT(varchar(2),DATEPART(DAY,adate)) +
	SPACE(240)
	FROM  #totale
	JOIN #incasso
		ON #totale.idreg = #incasso.idreg
		AND #totale.ndoc = #incasso.ndoc
		AND #totale.amount_proceeds >0
UNION SELECT
-- Codice Istituto
	@dipendenza	+ 
-- Codice Filiale
	@codicefiliale +
-- Codice Ente
	@codiceente +
-- Esercizio di Riferimento
	CONVERT(varchar(4),ydoc) +
-- Tipo Documento
	@tipodoc +
-- Numero Reversale
	#totale.ndocformatted +
-- Progressivo Sub
	CASE 
		WHEN LEN(#totale.nsub)<= @lennumsubmov THEN
			SUBSTRING('0000000', 1, @lennumsubmov - LEN(#totale.nsub))+ CONVERT(VARCHAR(7),#totale.nsub)
		ELSE CONVERT(varchar(7),#totale.nsub)
	END +
-- Tipo Record
	'05' +
-- Causale Incasso
	CASE 
		WHEN DATALENGTH(#totale.description) <= @lendescrizione THEN
			RTRIM(#totale.description) + SUBSTRING(REPLICATE(' ',@lendescrizione),1,@lendescrizione - DATALENGTH(#totale.description))
		ELSE SUBSTRING(#totale.description,1, @lendescrizione)
	END	+
-- 30 'Ragione sociale' = intestazione versante
	#incasso.registry +
	CASE
		WHEN #incasso.birthdate IS NULL THEN REPLICATE('0',8)
		ELSE
-- 8 data nascita 
			CONVERT (varchar(4), DATEPART(YEAR, birthdate)) +
			SUBSTRING('00',1,2 - LEN( CONVERT(VARCHAR(2),DATEPART(MONTH,birthdate)))) +
			CONVERT(varchar(2),DATEPART(MONTH,birthdate)) +
			SUBSTRING('00',1,2 - LEN( CONVERT(VARCHAR(2),DATEPART(DAY,birthdate)))) +
			CONVERT(varchar(2),DATEPART(DAY,birthdate))
	END +
	SPACE(2) +
-- 16 'Codice fiscale o p.iva del versante' 
	CASE 
		WHEN #incasso.cf IS NOT NULL THEN #incasso.cf
		ELSE
			CASE	
				WHEN #incasso.p_iva IS NOT NULL THEN #incasso.p_iva
				ELSE SPACE(16)
			END
	END
	+ SPACE(200) + SPACE(8)
	FROM  #totale
	JOIN #incasso
		ON #totale.idreg = #incasso.idreg
		AND #totale.ndoc = #incasso.ndoc
		AND #totale.amount_proceeds >0
------------------------------ Fine Dati BAse (T.Record A.002)-----------------------------
-------------------------------------------------------------------------------------------
---------     DAti BAse (T.Record A.003)
-------------------------------------------------------------------------------------------
UNION SELECT
-- Codice Istituto
	@dipendenza + 
-- Codice Filiale
	@codicefiliale +
-- Codice Ente
	@codiceente +
-- Esercizio di Riferimento
	convert(varchar(4),ydoc) +
-- Tipo Documento
	@tipodoc +
-- Numero Reversale
	#totale.ndocformatted +
-- Progressivo Sub
	CASE 
		WHEN LEN(#totale.nsub)<= @lennumsubmov THEN
			SUBSTRING('0000000', 1, @lennumsubmov - LEN(#totale.nsub))+ convert(VARCHAR(7),#totale.nsub)
		ELSE CONVERT(varchar(7),#totale.nsub)
	END +
-- Tipo Record
	'10' +
-- da Note operazioni di tesoreria a Codici generici per ente
	SPACE(80) +
-- Indirizzo versante
-- "Diversi" o "Diversi su c/c postale" o "Beneficiari diversi"
	address +
-- Localita versante
	location +
-- CAP
	cap +
-- Provincia
	province +
-- Campo Filler
	SPACE (174)
FROM #totale
JOIN #incasso
	ON #totale.idreg = #incasso.idreg
	AND #totale.ndoc = #incasso.ndoc
	AND #totale.amount_proceeds >0

IF EXISTS(SELECT * FROM #stringaSIOPE)
BEGIN
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
	-- Numero Reversale
		CASE 
			WHEN LEN(ndoc)<= @lennumdoc THEN 
				SUBSTRING('0000000', 1, @lennumdoc - LEN(ndoc))+ CONVERT(VARCHAR(7),ndoc)
			ELSE CONVERT(varchar(7),ndoc)
		END + 
	-- Progressivo Sub Movimento
		SUBSTRING('0000000',1,@lennumsubmov - LEN(CONVERT(varchar(7),nsub))) + CONVERT(varchar(7),nsub) +
	-- Tipo Record
		'02' + 
		stringa +
		SPACE(14) -- Filler
	FROM #stringaSIOPE
END
-------------------- Pulizia dai caratteri non consentiti ---------------------------
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
	
SELECT SUBSTRING(stri , 1, 350)  as out_str FROM #temp
ORDER BY SUBSTRING(stri , 1, 28), SUBSTRING(stri , 1, 37)

END









GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


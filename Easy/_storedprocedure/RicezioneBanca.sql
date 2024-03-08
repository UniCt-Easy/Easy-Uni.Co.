
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


if exists (select * from dbo.sysobjects where id = object_id(N'[RicezioneBanca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [RicezioneBanca]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE RicezioneBanca
(
	@eserc smallint,
	@nomefileinp varchar(100)
)
AS BEGIN
DECLARE @Tiporecord varchar(2)
DECLARE @CodIstituto varchar(3) 
DECLARE @Dipendenza varchar(5)    
DECLARE @CodEnte varchar(7) 
DECLARE @DataContabile varchar(8) 
DECLARE @DataCarico varchar(8) 
DECLARE @AnnoResiduo varchar(2)
DECLARE @Importo varchar(15) 
DECLARE @Causale1 varchar(30) 
DECLARE @Causale2 varchar(30) 
DECLARE @Causale3 varchar(27) 
DECLARE @ImportoBolli varchar(15) 
DECLARE @ImportoSpese varchar(15) 
DECLARE @Anagrafica1 varchar(7) 
DECLARE @DataValutaEnte varchar(8) 
DECLARE @NumQuietanza varchar(8) 
DECLARE @Divisa varchar(3) 
DECLARE @ImportoEuro varchar(15) 
DECLARE @Implordoconvertito decimal(19,2)
DECLARE @NumContoTeso varchar(7) 
DECLARE @ImportoLordo varchar(15) 
DECLARE @col001 varchar(422)
		
CREATE TABLE #TipoRecord01
(
	col001 varchar(422) NULL,
	TipoRecord varchar(2) NULL,
	CodIstituto varchar(3) NULL,
	Dipendenza varchar(5) NULL,
	CodEnte varchar(7) NULL,
	Esercizio varchar(4) NULL,
	DataContabile varchar(8) NULL,
	CodCausaleMov varchar(3) NULL,
	NumMandRev varchar(7) NULL,
	NumProgrSub varchar(7) NULL,
	Capitolo varchar(7) NULL,
	Articolo varchar(7) NULL,
	AnnoResiduo varchar(2) NULL,
	CodVoceEconomica varchar(3) NULL,
	Importo varchar(15) NULL,
	CodEsecPagamento varchar(3) NULL,
	DestTesoUnica varchar(3) NULL,
	Causale1 varchar(30) NULL,
	ImportoBolli varchar(7) NULL,
	ImportoSpese varchar(7) NULL,
	Anagrafica1 varchar(30) NULL,
	Anagrafica2 varchar(7) NULL,
	ABI varchar(5) NULL,
	CAB varchar(5) NULL,
	NumeroCC varchar(12) NULL,
	DataValutaEnte varchar(8) NULL,
	DataValutaCliente varchar(8) NULL,
	NumeroProgressivo varchar(7) NULL,
	DipOrigine varchar(5) NULL,
	DataCarico varchar(8) NULL,
	Causale2 varchar(30) NULL,
	Causale3 varchar(27) NULL,
	NumQuietanza varchar(7) NULL,
	Divisa varchar(3) NULL,
	ImportoEuro varchar(15) NULL,
	NumContoTeso varchar(7) NULL,
	Cin varchar(1) NULL,
	CodFunzDele varchar(3) NULL,
	DipCaricoFunzDele varchar(5) NULL,
	ImportoLordo varchar(15) NULL,
	Adisposizione varchar(82) NULL
)

CREATE TABLE #TipoRecord02
(
	TipoRecord varchar(2) NULL,
	CodIstituto varchar(3) NULL,
	Dipendenza varchar(5) NULL,
	CodEnte varchar(7) NULL,
	Esercizio varchar(4) NULL,
	DescrFiliale varchar(30) NULL,
	DescrEnte varchar(30) NULL,
	TipologiaEnte varchar(1) NULL,
	Importo1 varchar(15) NULL,
	Importo2 varchar(15) NULL,
	NumReveEmesse varchar(7) NULL,
	Importo3 varchar(15) NULL,
	NumReveIncassate varchar(7) NULL,
	Importo4 varchar(15) NULL,
	NumOperazionisuReve varchar(7) NULL,
	Importo5 varchar(15) NULL,
	NumProvvisoriEntrata varchar(7) NULL,
	Importo5Bis varchar(15) NULL,
	NumProvvisoriUscita varchar(7) NULL,
	Importo6 varchar(15) NULL,
	NumMandatiEmessi varchar(7) NULL,
	Importo7 varchar(15) NULL,
	NumMandatiPagati varchar(7) NULL,
	Importo8 varchar(15) NULL,
	NumOperazionisuMandati varchar(7) NULL,
	Importo9 varchar(15) NULL,
	Importo10 varchar(15) NULL,
	Importo11 varchar(15) NULL,
	Importo12 varchar(15) NULL,
	Importo13 varchar(15) NULL,
	Importo14 varchar(15) NULL,
	DataElaborazione varchar(8) NULL,
	ContabSpeciale1 varchar(15) NULL,
	ContabSpeciale2 varchar(15) NULL,
	GestioneImporti varchar(3) NULL,
	ADisposizione varchar(16) NULL
)

CREATE TABLE #banktransaction
(
	yban int,
	nban int IDENTITY(1,1),
	amount decimal(19,2),
	bankreference varchar(50),
	kind char(1),
	npay int,
	npro int, 
	transactiondate datetime,
	valuedate datetime,
	ypay int,
	ypro int,
	idpay int,
	idpro int,
	idexp varchar(72),
	idinc varchar(72)
)

DECLARE @par1 char(1)
DECLARE @par2 char(1)
DECLARE @CodCausaleMov  varchar(3)
-- BancaRxUscite
-- è una table dove scarico il file della banca temporaneamente con il bulk insert

-- BancaRxUsciteDef
-- è la table dove tengo traccia dei dati che mi arrivano dalla banca e aggiorno i campi
-- DataLoad	data in cui carico il file, e qsta data è valorizzata a prescindere 
-- dal fatto che elaboro la riga

-- DataElab	data elaborazione del file e qsta data è valorizzata solo se 
-- ho elaboro la riga

-- ParCheck è il flag che metto a 1 se l'elaborazione della riga è 
-- risultata ok (controlli sintattici)

DECLARE @CodIstituto2  varchar(9) 
DECLARE @Dipendenza2  varchar(9) 
DECLARE @CodEnte2  varchar(7) 
DECLARE @Esercizio smallint
DECLARE @CodIstituto1  varchar(9) 
DECLARE @Dipendenza1  varchar(9) 
DECLARE @CodEnte1  varchar(7) 
DECLARE @nomedb varchar(200)
DECLARE @nomefile varchar(200)
DECLARE @test char(1)

SELECT @nomedb = db_name()
SELECT @test ='N'
/**
insert into po_tabfilerx
values ('RettoratoEasy',"c:\RicezioneBanca\6821.txt")
**/
-- SELECT @nomefile = "c:\RicezioneBanca\6821.txt"
IF @nomefileinp IS NOT NULL AND RTRIM(LTRIM(@nomefileinp)) <> ''
BEGIN
	SELECT @nomefile = @nomefileinp
END
ELSE
BEGIN
	SELECT @nomefile = nomefile FROM po_tabfilerx where nomedb = @nomedb 
END

IF @nomefile IS NULL OR LEN(@nomefile)<1
BEGIN
	SELECT 'ERRORE: Non esiste il file nella tabella po_tabfilerx'
	RETURN
END
-- SELECT @nomefile 
DECLARE @str varchar(1000)
SELECT @str = 'BULK INSERT [BancaRxUscite] FROM '
+ '"' + @nomefile + '"' -- c:\RicezioneBanca\6821.txt" '
+ ' WITH (  DATAFILETYPE =  ''char'',   FIELDTERMINATOR = '','',  KEEPNULLS)'
-- SELECT  @str 
-- DECLARE and initialize a variable to hold @@ERROR.
EXEC ( @str )

-- Do a SELECT using the input parameter.
-- Save any non-zero @@ERROR value.

/*
BULK INSERT [BancaRxUscite] 
-- FROM "C:\RicezioneBanca\RNTES-7I050-UnivPieOrientale.txt"
-- FROM "C:\RicezioneBanca\RNTES-7I050-UnivPieOrientale-1.txt"
FROM "c:\RicezioneBanca\6821.txt"
WITH (
   DATAFILETYPE = 'char',
   FIELDTERMINATOR = ',',
   KEEPNULLS
)
*/

insert into BancaRxUsciteDef
SELECT 	Col001	, GETDATE(), '',0 	,'' FROM BancaRxUscite
where Col001	not in (SELECT Col001	from BancaRxUsciteDef)

IF @test ='S' 
	SELECT * FROM BancaRxUsciteDef
DELETE BancaRxUscite

SELECT @Tiporecord = SUBSTRING(Col001,1,2)  FROM BancaRxUsciteDef
INSERT INTO #TipoRecord01
SELECT 
	Col001
	,SUBSTRING(Col001,1,2)
	,SUBSTRING(Col001,3,3)
	,SUBSTRING(Col001,6,5)
	,SUBSTRING(Col001,11,7)
	,SUBSTRING(Col001,18,4)
	,SUBSTRING(Col001,22,8)
	,SUBSTRING(Col001,30,3)-- label nota 5 rev o man
	,SUBSTRING(Col001,33,7)
	,SUBSTRING(Col001,40,7)
	,SUBSTRING(Col001,47,7)
	,SUBSTRING(Col001,54,7)
	,SUBSTRING(Col001,61,2)
	,SUBSTRING(Col001,63,3)
	,SUBSTRING(Col001,66,15)
	,SUBSTRING(Col001,81,3)
	,SUBSTRING(Col001,84,3)
	,SUBSTRING(Col001,87,30)
	,SUBSTRING(Col001,117,7)
	,SUBSTRING(Col001,124,7)
	,SUBSTRING(Col001,131,30)
	,SUBSTRING(Col001,161,7)
	,SUBSTRING(Col001,168,5)
	,SUBSTRING(Col001,173,5)
	,SUBSTRING(Col001,178,12)
	,SUBSTRING(Col001,190,8)
	,SUBSTRING(Col001,198,8)
	,SUBSTRING(Col001,206,7)
	,SUBSTRING(Col001,213,5)
	,SUBSTRING(Col001,218,8)
	,SUBSTRING(Col001,226,30)
	,SUBSTRING(Col001,256,27)
	,SUBSTRING(Col001,283,7)
	,SUBSTRING(Col001,290,3)
	,SUBSTRING(Col001,293,15)
	,SUBSTRING(Col001,308,7)
	,SUBSTRING(Col001,315,1)
	,SUBSTRING(Col001,316,3)
	,SUBSTRING(Col001,319,5)
	,SUBSTRING(Col001,324,15)
	,SUBSTRING(Col001,339,82)
FROM BancaRxUsciteDef
WHERE (DataElab is null or DataElab ='')

DELETE #TipoRecord01 WHERE Tiporecord  ='02' 
IF @test ='S' 
	SELECT '#TipoRecord01',* FROM #TipoRecord01

INSERT INTO #TipoRecord02
SELECT 
	-- 01001005780004592
	-- 02001005780004592
	SUBSTRING(Col001,1,2)
	,SUBSTRING(Col001,3,3)
	,SUBSTRING(Col001,6,5)
	,SUBSTRING(Col001,11,7)
	,SUBSTRING(Col001,18,4)
	,SUBSTRING(Col001,22,30)
	,SUBSTRING(Col001,52,30)
	,SUBSTRING(Col001,82,1)
	,SUBSTRING(Col001,83,15)
	,SUBSTRING(Col001,98,15)
	,SUBSTRING(Col001,113,7)
	,SUBSTRING(Col001,120,15)
	,SUBSTRING(Col001,135,7)
	,SUBSTRING(Col001,142,15)
	,SUBSTRING(Col001,157,7)
	,SUBSTRING(Col001,164,15)
	,SUBSTRING(Col001,179,7)
	,SUBSTRING(Col001,186,15)
	,SUBSTRING(Col001,201,7)
	,SUBSTRING(Col001,208,15)
	,SUBSTRING(Col001,223,7)
	,SUBSTRING(Col001,230,15)
	,SUBSTRING(Col001,245,7)
	,SUBSTRING(Col001,252,15)
	,SUBSTRING(Col001,267,7)
	,SUBSTRING(Col001,274,15)
	,SUBSTRING(Col001,289,15)
	,SUBSTRING(Col001,304,15)
	,SUBSTRING(Col001,319,15)
	,SUBSTRING(Col001,334,15)
	,SUBSTRING(Col001,349,15)
	,SUBSTRING(Col001,364,8)
	,SUBSTRING(Col001,372,15)
	,SUBSTRING(Col001,387,15)
	,SUBSTRING(Col001,402,3)
	,SUBSTRING(Col001,405,16)
FROM BancaRxUsciteDef
WHERE (DataElab is null or DataElab ='')

DELETE #TipoRecord02 WHERE Tiporecord  = '01'

IF @test ='S' 
	SELECT 
		TipoRecord 
		,CodIstituto 
		,Dipendenza 
		,CodEnte 
		,Esercizio 
		,DescrFiliale 
		,DescrEnte 
		,TipologiaEnte 
		,NumReveEmesse 
		,NumReveIncassate 
		,NumOperazionisuReve 
		,NumProvvisoriEntrata 
		,NumProvvisoriUscita 
		,NumMandatiEmessi 
		,NumMandatiPagati 
		,NumOperazionisuMandati 
		,'Fondo di cassa anno precedente' = importo1
		,'Deficit di cassa anno precedente' =  importo2
		,'Reversali emesse' = importo3
		,'Reversali incassate' = importo4
		,'Operazioni su reversali' = importo5
		,'Provvisori entrata' = importo5bis
		,'Provvisori uscita' = importo6
		,'Mandati emessi' = importo7
		,'Mandati pagati' = importo8
		,'Operazioni su mandati' = importo9
		,'Saldo di diritto' = importo10
		,'Saldo di fatto' = importo11
		,'Anticipazione accordata' = importo12
		,'Anticipazione utilizzata' = importo13
		,'Disponibilita effettiva' = importo14
		,DataElaborazione 
		,ContabSpeciale1 
		,ContabSpeciale2 
		,GestioneImporti 
		,ADisposizione 
	 FROM #TipoRecord02

-- Prima di procedere verifico se: 
-- il totale dei movimenti già esitati sul db
-- +
-- il totale dei movimenti da esitare e presenti in record1
-- = totali che ho in record02
-- se è cosi procedo, se no segnalo l'errore e non faccio nulla
-----------------------------------------------------------------
--SELECT * FROM #TipoRecord01
--SELECT * FROM #TipoRecord02
DECLARE @IMPeuroCONVERTITO  decimal(19,2)
DECLARE @esercdocumentomb smallint
DECLARE @numdocumentomb int
DECLARE @importomb decimal(19,2)
DECLARE @importoesitatomb decimal(19,2)
DECLARE @flagesitomb char(1)
DECLARE @tipomovbancariomb  char(1)
DECLARE @esercmovbancariomb smallint
DECLARE @nummovbancariomb int
DECLARE @par3 char(1)
DECLARE @maxnumoper int
DECLARE @numero_cred  smallint
DECLARE @creddeb smallint

DECLARE @idreg_contr int

SELECT @idreg_contr = idregauto
FROM expensesetup
WHERE ayear = @eserc

IF @test = 'S'
BEGIN
	SELECT cod_ente = idregauto
	FROM expensesetup 
	WHERE ayear = @eserc

	SELECT codenteDB = agencycodefortransmission , 
	DipendenzaDB = cabcodefortransmission,
	CodIstitutoDB = depcodefortransmission
	FROM treasurer 
	WHERE flagdefault = 'S'
END

SELECT
	@codente = agencycodefortransmission , 
	@Dipendenza = cabcodefortransmission,
	@CodIstituto = depcodefortransmission
FROM treasurer 
WHERE flagdefault = 'S'

DECLARE @NumMandRev varchar(7) 
DECLARE @NumProgrSub varchar(7) 
DECLARE @Label_mandato varchar(3)
DECLARE @Label_reversale varchar(3)

DECLARE @totbancario decimal(19,2)
DECLARE @totdoc decimal(19,2)

-- SELECT @Label_mandato ='MAN'
-- SELECT @Label_reversale ='REV'
--------------------- INIZIO FETCH --------------------- 
DECLARE mandato_cursor INSENSITIVE CURSOR FOR
SELECT DISTINCT NumMandRev, NumProgrSub,CodCausaleMov FROM #TipoRecord01
-- WHERE CodCausaleMov = @Label_mandato 
ORDER BY CodCausaleMov, NumMandRev, NumProgrSub
OPEN mandato_cursor
IF @test = 'S'
SELECT DISTINCT CodCausaleMov, NumMandRev, NumProgrSub FROM #TipoRecord01
--	WHERE CodCausaleMov = @Label_mandato 
	ORDER BY CodCausaleMov, NumMandRev, NumProgrSub

FETCH NEXT FROM mandato_cursor INTO @NumMandRev, @NumProgrSub , @CodCausaleMov
WHILE (@@FETCH_STATUS = 0)
BEGIN
	SELECT
		@TipoRecord = TipoRecord, 
		@CodIstituto1 = CONVERT(int, CodIstituto),
		@Dipendenza1 = CONVERT(int, Dipendenza),
		@CodEnte1 = CONVERT(int, CodEnte),
		@Esercizio = Esercizio,
		@DataContabile= DataContabile, 
		@NumMandRev = NumMandRev, 
		@NumProgrSub = NumProgrSub,
		@AnnoResiduo = AnnoResiduo, 
		@Importo = Importo,
		@Causale1 = Causale1,
		@ImportoBolli = ImportoBolli,
		@ImportoSpese = ImportoSpese,
		@Anagrafica1 = Anagrafica1,
		@DataValutaEnte = DataValutaEnte,
		@DataCarico = DataCarico,
		@Causale2 = Causale2,
		@Causale3 = Causale3,
		@NumQuietanza = NumQuietanza,
		@Divisa = Divisa,
		@ImportoEuro = ImportoEuro,
		@NumContoTeso = NumContoTeso,
		@ImportoLordo = ImportoLordo,
		@col001= col001
	FROM #TipoRecord01
	WHERE NumProgrSub = @NumProgrSub
		AND  NumMandRev = @NumMandRev
		AND CodCausaleMov = @CodCausaleMov

	-- errore
	IF  	CONVERT(int, @CodIstituto1)<> CONVERT(int, @CodIstituto) OR  
		--CONVERT(int, @Dipendenza ) <> CONVERT(int, @Dipendenza1 ) OR 
		CONVERT(int, @CodEnte) <> CONVERT(int, @CodEnte1)
	BEGIN
		UPDATE BancaRxUsciteDef set 
		ParCheck = 1, 
		DataElab	='' , 
		notes ='E1 : errore in dip o istit o codente'
		WHERE SUBSTRING(Col001 ,1, 2) =  '01' AND 
		Col001 = @col001
	END

	IF @test ='S'
	BEGIN
		SELECT 'fetch',
		'@NumMandRev'=@NumMandRev, 
		'@NumProgrSub' = @NumProgrSub, 
		'@Importo' = @Importo, 
		'@ANAGRAFICA1' = @ANAGRAFICA1,
		'@ImportoEuro' = @ImportoEuro, 
		'@ImportolORDO' = @ImportolORDO,
		'@CodIstituto'= @CodIstituto1 ,
		'@Dipendenza '= @Dipendenza1 ,
		'@CodEnte '= @CodEnte1
	END

	SELECT @IMPlordoCONVERTITO = 
		SUBSTRING(@Importolordo,1,LEN(@Importolordo)-2)+'.'+
		SUBSTRING(@Importolordo, LEN(@Importolordo)-1, LEN(@Importolordo))

	SELECT @IMPeuroCONVERTITO = 
		SUBSTRING(@ImportoEuro,1,LEN(@ImportoEuro)-2)+'.'+
		SUBSTRING(@ImportoEuro, LEN(@ImportoEuro)-1, LEN(@ImportoEuro))
	
	DECLARE @kind char(1)
	DECLARE @ypay smallint
	DECLARE @npay int
	DECLARE @ypro smallint
	DECLARE @npro int
	DECLARE @idpay int
	DECLARE @idpro int

	IF @CodCausaleMov IN ('MAN', 'DSU','RMA')
	BEGIN
		SET @kind = 'D'
		SET @ypay = @esercizio
		SET @npay = @NumMandRev 
		SET @idpay = @NumProgrSub
		SET @ypro = NULL
		SET @npro = NULL
		SET @idpro = NULL
		
	END

	IF @CodCausaleMov IN ('REV', 'RRE')
	BEGIN
		SET @kind = 'C'
		SET @ypay = NULL
		SET @npay = NULL
		SET @idpay = NULL
		SET @ypro = @esercizio
		SET @npro = @NumMandRev
		SET @idpro = @NumProgrSub
	END
	-- ci sono due casi: 
	-- esiste già un record in banktransaction, con un di cui.
	-- non esiste 
	
	SELECT @totbancario = 0
	SELECT @totdoc = 0
	
	DECLARE @NEWNBAN int
	SELECT @NEWNBAN = ISNULL(MAX(nban),0) FROM banktransaction WHERE (yban = @ESERCIZIO)
	SELECT @NEWNBAN = ISNULL(@NEWNBAN ,0)
	
	/* JTR -- Commentato codice ML sostituito dal seguente
	if @CodCausaleMov IN ('MAN', 'DSU','RMA')
		SELECT @totbancario = SUM(amount) FROM banktransaction 
		where (yban = @ESERCIZIO) and (npay = @NumMandRev) and (ypay = @esercizio)
	if @CodCausaleMov IN ('REV', 'RRE')
		SELECT @totbancario = SUM(amount) FROM banktransaction 
		where (yban = @ESERCIZIO) and (npro = @NumMandRev) and (ypro = @esercizio)
	*/
	-- JTR Prendo l'importo degli esiti associati ad uno specifico movimento bancario
	IF @CodCausaleMov IN ('MAN', 'DSU','RMA')
	BEGIN
		SELECT @totbancario = SUM(amount) FROM banktransaction 
		WHERE (yban = @ESERCIZIO) and (npay = @NumMandRev) and (ypay = @esercizio)
		AND idpay = @NumProgrSub
	END
	IF @CodCausaleMov IN ('REV', 'RRE')
	BEGIN
		SELECT @totbancario = SUM(amount) FROM banktransaction 
		WHERE (yban = @ESERCIZIO) and (npro = @NumMandRev) and (ypro = @esercizio)
		AND idpro = @NumProgrSub
	END
	SELECT @totbancario = ISNULL(@totbancario ,0)
	
	IF @CodCausaleMov IN ('MAN', 'DSU','RMA')
	BEGIN
		SELECT @numero_cred = COUNT(idreg) FROM expense 
		WHERE ypay = @ypay and npay= @npay
	
		SELECT @creddeb = idreg FROM expense 
		WHERE ypay = @ypay and npay= @npay
	/* JTR Commentata l'assegnazione di ML alla var. @totdoc
		SELECT @totdoc =  SUM(ET.curramount) FROM expensetotal ET
		 join expense E on E.idexp = ET.idexp
		 WHERE E.ypay = @esercizio
			and E.npay = @npay
		SELECT @totdoc =ISNULL(@totdoc ,0)
	*/
		SET @totdoc =
		ISNULL(
			(SELECT amount
			FROM payment_bank PB
			WHERE PB.ypay = @esercizio
				AND PB.npay = @npay
				AND PB.idpay = @idpay)
		,0)
	END

	IF @CodCausaleMov IN ('REV', 'RRE')
	BEGIN
		SELECT @numero_cred = COUNT(idreg) FROM income 
		WHERE ypro = @ypro and npro = @npro
	
		SELECT @creddeb = idreg FROM income 
		WHERE ypro= @ypro and npro= @npro
	
	/* JTR Commentata l'assegnazione di ML alla var. @totdoc
		SELECT @totdoc = 0
		SELECT @totdoc = SUM(ET.curramount) FROM incometotal ET
		JOIN income E ON ET.idinc = E.idinc
		WHERE E.ypro = @ypro and E.npro = @npro
		SELECT @totdoc= ISNULL(@totdoc ,0)
	*/
		SET @totdoc =
		ISNULL(
			(SELECT amount
			FROM proceeds_bank PB
			WHERE PB.ypro = @esercizio
				AND PB.npro = @npro
				AND PB.idpro = @idpro)
		,0)
	END

	-- CHECK
	IF @totbancario + @IMPeuroCONVERTITO > @totdoc -- impporto tot mandato 
	BEGIN
		UPDATE BancaRxUsciteDef set ParCheck = 1, 
		DataElab = '',
		notes='importo NON corretto N. '+ 
			CONVERT(varchar(10),@NumMandRev)+'-'+
			CONVERT(varchar(10),@totbancario )+ '-' +
			CONVERT(varchar(10),@IMPeuroCONVERTITO )+ '-' +
			CONVERT(varchar(10),@totdoc)
		WHERE SUBSTRING(Col001 ,1, 2) =  '01'
			AND Col001 = @col001
	END
	ELSE
	BEGIN
		UPDATE BancaRxUsciteDef set ParCheck = 0, 
		DataElab = GETDATE() ,
		notes = 'importo corretto N. '+ 
			CONVERT(varchar(10),@NumMandRev)+'-'+
			CONVERT(varchar(10),@totbancario )+ '-' +
			CONVERT(varchar(10),@IMPeuroCONVERTITO )+ '-' +
			CONVERT(varchar(10),@totdoc)
		WHERE SUBSTRING(Col001 ,1, 2) =  '01'
			AND Col001 = @col001
	END

	-- qua inserisco i controlli di coerenza
	-- importo lordo = importo tot mandato
	-- beneficiario
	-- numero mandato
	IF @test ='S'
	BEGIN
		SELECT	@CodCausaleMov, 'r'=@ypro, 'r'=@npro, 'm'=@ypay, 'm'=@npay,
		'@ImplORDOconvertito '=@ImplORDOconvertito, ' @totdoc '=@totdoc, 
		'@ImpEuroconvertito '=@ImpEuroconvertito, '@totbancario'=@totbancario 
	END

	IF -- CONVERT(varchar(10),@creddeb ) <> @ANAGRAFICA1 OR 
	@ImplORDOconvertito <> @totdoc OR --ok
	@ImpEuroconvertito > @ImplORDOconvertito  -- ok
	BEGIN
		UPDATE BancaRxUsciteDef set ParCheck = 1, 
		DataElab	= '' ,
		notes='E1:' -- + CONVERT(varchar(10),@creddeb )+'-'+
				-- + @ANAGRAFICA1 +'-'+
				+'imp.lordo '+ CONVERT(varchar(10), @ImportolORDO )+'-'+
				+'totdoc '+ CONVERT(varchar(10),@totdoc )
		WHERE SUBSTRING(Col001 ,1, 2) =  '01' AND 
		Col001 = @col001
	END

	-- @ImportoEuro  è un di cui dell'importo complessivo = @ImportolORDO, quindi devo sommare
	IF @test ='S'
	BEGIN
		SELECT @CodIstituto1 
		SELECT @CodIstituto
		SELECT @Dipendenza 
		SELECT @Dipendenza1 
		SELECT @CodEnte 
		SELECT @CodEnte1 
	END

	IF
	CONVERT(int, @CodIstituto1) = CONVERT(int, @CodIstituto)
	AND CONVERT(int, @CodEnte) = CONVERT(int, @CodEnte1)
-- JTR	AND (@totbancario + @IMPeuroCONVERTITO <= @totdoc)-- impporto tot mandato 
-- JTR	AND  @ImplORDOconvertito = @totdoc 
-- JTR	AND  @ImpEuroconvertito <= @ImplORDOconvertito  
	BEGIN
		IF (@kind = 'D')
		BEGIN
			DECLARE @performed_exp char(1)
			SET @performed_exp = 'N'
			IF (@totbancario + @impeuroconvertito = @totdoc) AND (@performed_exp = 'N')
			BEGIN
				INSERT INTO #banktransaction
				(
					yban, kind, bankreference, transactiondate,
					valuedate, amount, ypay, npay, idpay, idexp
				)
				SELECT
					@esercizio,
					@kind,
					SUBSTRING(ISNULL(@causale1,'') +'-'+
					ISNULL(@causale2,'')  +'-'+
					ISNULL(@causale3,''), 1, 50), 
					@DataCarico, 
					@DataValutaEnte,
					expensetotal.curramount - ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idexp = expense.idexp),0),
					@ypay, 
					@npay, 
					@idpay, 
					expense.idexp
				FROM expense
					JOIN expensetotal
					ON expense.idexp = expensetotal.idexp
				WHERE expense.ypay = @ypay
					AND expense.npay = @npay
					AND expense.idpay = @idpay
					AND expensetotal.curramount > ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idexp = expense.idexp),0)

				SET @performed_exp = 'S'
			END -- IF (A = B)
			IF (@totbancario + @impeuroconvertito < @totdoc) AND (@performed_exp = 'N')
			BEGIN
				-- Caso 2: Esiste un movimento di spesa con importo corrente pari a quello dell'esito
				IF (SELECT COUNT(*)
				FROM expense
					JOIN expensetotal
					ON expense.idexp = expensetotal.idexp
				WHERE expense.ypay = @ypay
					AND expense.npay = @npay
					AND expense.idpay = @idpay
					AND expensetotal.curramount = @impeuroconvertito) > 0
				AND (@performed_exp = 'N')
				BEGIN
					INSERT INTO #banktransaction
					(
						yban, kind, bankreference, transactiondate,
						valuedate, amount,
						ypay, npay, idpay, idexp
					)
					SELECT TOP 1
						@esercizio,
						@kind,
						SUBSTRING(ISNULL(@causale1,'') +'-'+
						ISNULL(@causale2,'')  +'-'+
						ISNULL(@causale3,''), 1, 50), 
						@DataCarico, 
						@DataValutaEnte,
						expensetotal.curramount - ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idexp = expense.idexp),0),
						@ypay, 
						@npay, 
						@idpay,
						expense.idexp
					FROM expense
						JOIN expensetotal
						ON expense.idexp = expensetotal.idexp
					WHERE expense.ypay = @ypay
						AND expense.npay = @npay
						AND expense.idpay = @idpay
						AND expensetotal.curramount = @impeuroconvertito

					SET @performed_exp = 'S'
				END -- Caso 2
				-- Caso 3: Esiste un movimento di spesa con importo netto pari a quello dell'esito
				IF (SELECT COUNT(*)
				FROM expense
				WHERE expense.ypay = @ypay
					AND expense.npay = @npay
					AND expense.idpay = @idpay
					AND (expense.amount - /*ISNULL(expense.employtaxamount,0)*/
							ISNULL((SELECT SUM(employtax)
								FROM expensetax
								WHERE idexp = expense.idexp), 0) 

						) = @impeuroconvertito) > 0
				AND (@performed_exp = 'N')
				BEGIN
					INSERT INTO #banktransaction
					(
						yban, kind, bankreference, transactiondate,
						valuedate, amount,
						ypay, npay, idpay, idexp
					)
					SELECT TOP 1
						@esercizio,
						@kind,
						SUBSTRING(ISNULL(@causale1,'') +'-'+
						ISNULL(@causale2,'') +'-'+
						ISNULL(@causale3,''), 1, 50),
						@DataCarico, 
						@DataValutaEnte,
						expense.amount - /*ISNULL(expense.employtaxamount,0)*/
								ISNULL((SELECT SUM(employtax)
									FROM expensetax
									WHERE idexp = expense.idexp), 0) 
						- ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idexp = expense.idexp),0),
						@ypay, 
						@npay,
						@idpay,
						expense.idexp
					FROM expense
					WHERE expense.ypay = @ypay
						AND expense.npay = @npay
						AND expense.idpay = @idpay
						AND (expense.amount - /*ISNULL(expense.employtaxamount,0)*/
									ISNULL((SELECT SUM(employtax)
										FROM expensetax
										WHERE idexp = expense.idexp), 0) 
						) = @impeuroconvertito

					SET @performed_exp = 'S'
				END -- Caso 3
				-- Caso 4: Esiste un movimento di spesa con importo delle ritenute c/dip pari a quello dell'esito
				IF (SELECT COUNT(*)
				FROM expense	
				WHERE expense.ypay = @ypay
					AND expense.npay = @npay
					AND expense.idpay = @idpay
					AND /*ISNULL(expense.employtaxamount,0)*/ 
					ISNULL((SELECT SUM(employtax)
						FROM expensetax
						WHERE idexp = expense.idexp), 0) = @impeuroconvertito) > 0
				AND (@performed_exp = 'N')
				BEGIN
					INSERT INTO #banktransaction
					(
						yban, kind, bankreference, transactiondate,
						valuedate, amount,
						ypay, npay, idpay, idexp
					)
					SELECT TOP 1
						@esercizio,
						@kind,
						SUBSTRING(ISNULL(@causale1,'') +'-'+
						ISNULL(@causale2,'')  +'-'+
						ISNULL(@causale3,''), 1, 50), 
						@DataCarico,
						@DataValutaEnte,
						/*ISNULL(expense.employtaxamount,0)*/
						ISNULL((SELECT SUM(employtax)
							FROM expensetax
							WHERE idexp = expense.idexp), 0) 
						- ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idexp = expense.idexp),0),
						@ypay,
						@npay,
						@idpay,
						expense.idexp
					FROM expense
					WHERE expense.ypay = @ypay
						AND expense.npay = @npay
						AND expense.idpay = @idpay
						AND /*ISNULL(expense.employtaxamount,0)*/
						ISNULL((SELECT SUM(employtax)
							FROM expensetax
							WHERE idexp = expense.idexp), 0)  = @impeuroconvertito

					SET @performed_exp = 'S'
				END -- Caso 4
				-- Caso 5: Falliti tutti i casi precedenti si va a copertura progressiva
				DECLARE @perf_residual_exp decimal(19,2)
				DECLARE @idexp varchar(72)
				DECLARE @curramount_exp decimal(19,2)
				DECLARE @totperformed_exp decimal(19,2)
				DECLARE @toperform_exp decimal(19,2)

				SET @perf_residual_exp = @impeuroconvertito
				IF (@performed_exp = 'N')
				BEGIN
					DECLARE perf_crs INSENSITIVE CURSOR FOR
					SELECT expense.idexp, curramount,
					ISNULL(
						(SELECT SUM(amount) FROM banktransaction
						WHERE idexp = expense.idexp)
					,0)
					FROM expense
						JOIN expensetotal
						ON expense.idexp = expensetotal.idexp
					WHERE expense.ypay = @ypay
						AND expense.npay = @npay
						AND expense.idpay = @idpay
						AND curramount >
						ISNULL(
							(SELECT SUM(amount) FROM banktransaction
							WHERE idexp = expense.idexp)
						,0)
					FOR READ ONLY
			
					OPEN perf_crs
					FETCH NEXT FROM perf_crs INTO @idexp, @curramount_exp, @totperformed_exp
					WHILE(@@FETCH_STATUS = 0)
					BEGIN
						IF (@perf_residual_exp > 0)
						BEGIN
							SET @toperform_exp = @curramount_exp - @totperformed_exp

							INSERT INTO #banktransaction (yban, kind, bankreference, transactiondate,
							valuedate, amount,
							ypay, npay, idpay, idexp)
							SELECT 
								@esercizio,
								@kind,
								SUBSTRING(ISNULL(@causale1,'') +'-'+
								ISNULL(@causale2,'')  +'-'+
								ISNULL(@causale3,''), 1, 50), 
								@DataCarico, 
								@DataValutaEnte,
								CASE
									WHEN @toperform_exp >= @perf_residual_exp
									THEN @perf_residual_exp
									ELSE @toperform_exp
								END,
								@ypay, 
								@npay,
								@idpay,
								@idexp
							FROM expense
							WHERE expense.ypay = @ypay
								AND expense.npay = @npay
								AND expense.idpay = @idpay

							SET @perf_residual_exp = @perf_residual_exp - @toperform_exp
							IF (@perf_residual_exp < 0) SET @perf_residual_exp = 0
						END
						FETCH NEXT FROM perf_crs INTO @idexp, @curramount_exp, @totperformed_exp
					END
					CLOSE perf_crs
					DEALLOCATE perf_crs
				END -- Caso 5
			END -- IF (A < B)
		END -- (kind = 'D')
		IF (@kind = 'C')
		BEGIN
			DECLARE @performed_inc char(1)
			SET @performed_inc = 'N'
			IF (@totbancario + @impeuroconvertito = @totdoc)
			BEGIN
				INSERT INTO #banktransaction (yban, kind, bankreference, transactiondate, valuedate, amount,
				ypro, npro, idpro, idinc) 
				SELECT
				@esercizio,
				@kind,
				SUBSTRING(ISNULL(@causale1,'') +'-'+
				ISNULL(@causale2,'')  +'-'+
				ISNULL(@causale3,''), 1, 50), 
				@DataCarico, 
				@DataValutaEnte, 
				incometotal.curramount - ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idinc = income.idinc),0),
				@ypro,
				@npro,
				@idpro,
				income.idinc
				FROM income
					JOIN incometotal
					ON income.idinc = incometotal.idinc
				WHERE income.ypro = @ypro
					AND income.npro = @npro
					AND income.idpro = @idpro
					AND incometotal.curramount > ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idinc = income.idinc),0)

				SET @performed_inc = 'S'
			END -- IF (A = B)
			IF (@totbancario + @impeuroconvertito < @totdoc) AND (@performed_inc = 'N')
			BEGIN
				-- Caso 2: Esiste un movimento di entrata con importo corrente pari a quello dell'esito
				IF (SELECT COUNT(*)
				FROM income
					JOIN incometotal
					ON income.idinc = incometotal.idinc
				WHERE income.ypro = @ypro
					AND income.npro = @npro
					AND income.idpro = @idpro
					AND incometotal.curramount = @impeuroconvertito) > 0
				AND (@performed_inc = 'N')
				BEGIN
					INSERT INTO #banktransaction (yban, kind, bankreference, transactiondate,
					valuedate, amount,
					ypro, npro, idpro, idinc)
					SELECT TOP 1
						@esercizio,
						@kind,
						SUBSTRING(ISNULL(@causale1,'') +'-'+
						ISNULL(@causale2,'')  +'-'+
						ISNULL(@causale3,''), 1, 50), 
						@DataCarico, 
						@DataValutaEnte,
						incometotal.curramount - ISNULL((SELECT SUM(amount) FROM banktransaction WHERE idinc = income.idinc),0),
						@ypro, 
						@npro, 
						@idpro, 
						income.idinc
					FROM income
						JOIN incometotal
						ON income.idinc = incometotal.idinc
					WHERE income.ypro = @ypro
						AND income.npro = @npro
						AND income.idpro = @idpro
						AND incometotal.curramount = @impeuroconvertito

					SET @performed_inc = 'S'
				END -- Caso 2
				-- Caso 5: Falliti tutti i casi precedenti si va a copertura progressiva
				DECLARE @perf_residual_inc decimal(19,2)
				DECLARE @idinc varchar(72)
				DECLARE @curramount_inc decimal(19,2)
				DECLARE @totperformed_inc decimal(19,2)
				DECLARE @toperform_inc decimal(19,2)
				SET @perf_residual_inc = @impeuroconvertito

				IF (@performed_inc = 'N')
				BEGIN
					DECLARE perf_crs INSENSITIVE CURSOR FOR
					SELECT income.idinc, curramount,
					ISNULL(
						(SELECT SUM(amount) FROM banktransaction
						WHERE idinc = income.idinc)
					,0)
					FROM income
						JOIN incometotal
						ON income.idinc = incometotal.idinc
					WHERE income.ypro = @ypro
						AND income.npro = @npro
						AND income.idpro = @idpro
					FOR READ ONLY
				
					OPEN perf_crs
					FETCH NEXT FROM perf_crs INTO @idinc, @curramount_inc, @totperformed_inc
					WHILE(@@FETCH_STATUS = 0)
					BEGIN
						IF (@perf_residual_inc > 0)
						BEGIN
							SET @toperform_inc = @curramount_inc - @totperformed_inc

							INSERT INTO #banktransaction (yban, kind, bankreference, transactiondate,
							valuedate, amount,
							ypro, npro, idpro, idinc)
							SELECT 
								@esercizio,
								@kind,
								SUBSTRING(ISNULL(@causale1,'') +'-'+
								ISNULL(@causale2,'')  +'-'+
								ISNULL(@causale3,''), 1, 50), 
								@DataCarico, 
								@DataValutaEnte, 
								CASE
									WHEN @toperform_inc >= @perf_residual_inc
									THEN @perf_residual_inc
									ELSE @toperform_inc
								END,
								@ypro, 
								@npro, 
								@idpro,
								@idinc
							FROM income
							WHERE income.ypro = @ypro
								AND income.npro = @npro
								AND income.idpro = @idpro

							SET @perf_residual_inc = @perf_residual_inc - @toperform_inc
							IF (@perf_residual_inc < 0) SET @perf_residual_inc = 0
						END
						FETCH NEXT FROM perf_crs INTO @idinc, @curramount_inc, @totperformed_inc
					END -- While
					CLOSE perf_crs
					DEALLOCATE perf_crs
				END -- Caso 5
			END -- IF (A > B)
		END -- (kind = 'C')
	END -- IF su codente e codistituto

	IF @test ='S'
	BEGIN
		SELECT 
		@ESERCIZIO,  -- yban
		@NEWNBAN + 1, -- nba
		@kind,
		-- kind = 'D' per i mandati e npay che è il numero del mandato
		-- kind = 'C' per le reve  e npro che è il numero della reve
		SUBSTRING(ISNULL(@causale1,'') +'-'+
		 ISNULL(@causale2,'')  +'-'+
		 ISNULL(@causale3,''), 1, 50), --rif-banca = bankreference
		@DataCarico, --transactiondate = dataoperazione
		@DataValutaEnte, -- valuedate = data valuta
		@IMPeuroCONVERTITO, -- amount
		@ypay, -- nel caso sia un mandato  
		@npay, -- nel caso sia un mandato
		@idpay, -- nel caso sia un mandato
		@ypro, -- nel caso sia una reve
		@npro, -- nel caso sia una reve
		@idpro, -- nel caso sia una reve
		'''RX_BANCA''',
		GETDATE(),
		'''RX_BANCA''',
		GETDATE()
	
	END
	FETCH NEXT FROM mandato_cursor INTO @NumMandRev, @NumProgrSub ,@CodCausaleMov 
END
CLOSE mandato_cursor 
DEALLOCATE mandato_cursor

DECLARE @maxnban int
SET @maxnban = ISNULL((SELECT MAX(nban) FROM banktransaction WHERE yban = @eserc),0)

INSERT INTO banktransaction
(
	yban,
	nban,
	amount,
	bankreference,
	kind,
	npay,
	npro,
	transactiondate,
	valuedate,
	ypay,
	ypro,
	idpay,
	idpro,
	idexp,
	idinc,
	ct,
	cu,
	lt,
	lu
)
SELECT
	yban,
	nban + @maxnban,
	amount,
	bankreference,
	kind,
	npay,
	npro,
	transactiondate,
	valuedate,
	ypay,
	ypro,
	idpay,
	idpro,
	idexp,
	idinc,
	GETDATE(),
	'''RX_BANCA''',
	GETDATE(),
	'''RX_BANCA'''
FROM #banktransaction

-------- FINE FETCH

SELECT @CodIstituto2 = CodIstituto,
@Dipendenza2 = Dipendenza,
@CodEnte2 = CodEnte
from #TipoRecord02

IF @test ='S'
	SELECT 'CodIstitutobanca' = @CodIstituto2 
	, 'DipendenzaBanca' = @Dipendenza2 
	, 'EnteBanca' = @CodEnte2 
	, 'CodIstitutoEasy' = @CodIstituto
	, 'DipendenzaEasy' = @Dipendenza
	, 'EnteEasy' = @CodEnte 
	

IF CONVERT(int,@CodIstituto) <> CONVERT(int, @CodIstituto2)
--OR CONVERT(int,@Dipendenza) <> CONVERT(int, @Dipendenza2)
OR CONVERT(int,@CodEnte) <> CONVERT(int, @CodEnte2)
BEGIN
	UPDATE BancaRxUsciteDef set ParCheck = 1, DataElab = '',
	notes ='E2 : errore in dip o istit o codente'
	WHERE SUBSTRING(Col001 ,1, 2) =  '02'
END
-- qua verifico i totali e nel caso segnalo.

UPDATE BancaRxUsciteDef set
DataElab	=GETDATE()
where DataElab	='' 

INSERT INTO PO_BANCA_LOG01
SELECT 
	@nomefile,
	GETDATE(),
	TipoRecord, CodIstituto, Dipendenza ,CodEnte, 
	Esercizio, DataContabile, CodCausaleMov,
	NumMandRev ,NumProgrSub ,Capitolo, 
	Articolo ,AnnoResiduo ,CodVoceEconomica, 
	Importo ,CodEsecPagamento ,DestTesoUnica, 
	Causale1 ,ImportoBolli,ImportoSpese,
	Anagrafica1 ,Anagrafica2 ,ABI ,CAB ,NumeroCC ,DataValutaEnte,
	DataValutaCliente ,NumeroProgressivo ,DipOrigine ,DataCarico, 
	Causale2 ,Causale3 ,NumQuietanza ,Divisa ,ImportoEuro, 
	NumContoTeso ,Cin ,CodFunzDele ,DipCaricoFunzDele, 
	ImportoLordo ,Adisposizione 
FROM #TipoRecord01

INSERT INTO PO_BANCA_LOG02
SELECT 
	@nomefile,
	GETDATE(),
	TipoRecord,
	CodIstituto, 
	Dipendenza, 
	CodEnte, 
	Esercizio,
	DescrFiliale, 
	DescrEnte, 
	TipologiaEnte,
	Importo1, 
	Importo2, 
	NumReveEmesse, 
	Importo3, 
	NumReveIncassate,
	Importo4, 
	NumOperazionisuReve, 
	Importo5, 
	NumProvvisoriEntrata, 
	Importo5Bis, 
	NumProvvisoriUscita,
	Importo6, 
	NumMandatiEmessi,
	Importo7, 
	NumMandatiPagati, 
	Importo8, 
	NumOperazionisuMandati,
	Importo9, 
	Importo10, 
	Importo11, 
	Importo12, 
	Importo13, 
	Importo14, 
	DataElaborazione,
	ContabSpeciale1, 
	ContabSpeciale2, 
	GestioneImporti, 
	ADisposizione 
FROM #TipoRecord02

IF
(SELECT COUNT(*)
FROM banktransaction
WHERE cu = '''RX_BANCA'''
	AND (npay in (SELECT CONVERT(int, NumMandRev ) FROM #TipoRecord01)
	OR npro in (SELECT CONVERT(int, NumMandRev ) FROM #TipoRecord01))) =0
BEGIN
	SELECT 'NON E STATO AGGIORNATO ALCUN MOVIMENTO'
END
ELSE
BEGIN
	SELECT *
	FROM banktransaction WHERE
	cu = '''RX_BANCA''' AND (npay in (SELECT CONVERT(int, NumMandRev ) FROM #TipoRecord01)
	OR npro IN (SELECT CONVERT(int, NumMandRev ) FROM #TipoRecord01))
	order by nban, npro,npay
END
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


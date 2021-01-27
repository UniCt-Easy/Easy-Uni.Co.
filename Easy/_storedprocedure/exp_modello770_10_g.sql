
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


if exists (SELECT * from dbo.sysobjects where id = object_id(N'[exp_modello770_10_g]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_10_g]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE [exp_modello770_10_g] (@modello varchar(10))
AS BEGIN
-- exec exp_modello770_10_g '770'
-- exec exp_modello770_10_g 'CUD'
	-- Inizio Sezione dichiarativa
	declare @SS002001 dec(19,2)
	declare @SS002002 dec(19,2)
	declare @SS002009 dec(19,2)

	declare @annodichiarazione int
	set @annodichiarazione = 2010

	declare @annoredditi int
	set @annoredditi = 2009
	-- Ricordarsi di cambiare ogni anno l'anno delle date
	declare @1gen09 datetime
	set @1gen09 = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @13gen09 datetime
	set @13gen09 = dateadd(yy, @annoredditi-2000, {d '2000-01-13'})

	declare @31dic09 datetime
	set @31dic09 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen10 datetime
	set @1gen10 = dateadd(yy, @annodichiarazione-2000, {d '2000-01-01'})

	declare @12gen10 datetime
	set @12gen10 = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

	-- Tabella dei giorni lavorati
	create table #workdays 	(giorno smalldatetime, worked char(1) )

	DECLARE @1gen00 datetime
	SET @1gen00 = DATEADD(yy, @annoredditi-2009, {d '2000-01-01'})

	declare @giorno smalldatetime
	set @giorno=@1gen00
	WHILE (datepart(year,@giorno)<=@annoredditi)
	BEGIN
		insert into #workdays(giorno) values (@giorno)
		set @giorno=DATEADD(dd,1,@giorno)
	END

	-- Fine Sezione dichiarativa

	-- ipotesi fondamentale: Gestione del solo modulo PARASUBORDINATI poichè è l'unica tipologia di reddito a cui si riferisce il CUD
	-- La tabella #modulocococo ha dentro di se solamente il riferimento al percipiente, perché la certificazione deve essere prodotta a livello
	-- di percipiente.
	CREATE TABLE #modulocococo (idreg int) -- Codice del percipiente


/*
	Inserisco per il momento solo i dati relativi alle rit. fiscali dei soli CEDOLINI di CONGUAGLIO
	perchè ho bisogno di prendere i dati conguagliati. C'è un problema derivante dal conguaglio in presenza
	di un cud presentato: Non c'è modo di capire se il cud presentato è un precedente contratto o altro
	Questo implica che gli imponibili (LE RITENUTE SONO OK) non possono essere tenuti in considerazione
	per la sommatoria che si farà in seguito per calcolare i redditi
*/

	-- Riempimento della tabella dei percipienti coinvolti nella certificazione.
	-- per Modello 770
	-- Vengono presi tutti i percipienti associati a cedolini di conguaglio con anno di competenza quello della dichiarazione
	-- e trasmessi, inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- al quadro G del 770 (rec770kind = 'G') e di cui almeno un cedolino dell'anno corrente sia stato trasmesso
	-- per CUD
	-- Vengono presi tutti i percipienti associati a cedolini di conguaglio con anno di competenza quello della dichiarazione
	-- e trasmessi, inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- alla certificazione CUD (certificatekind = 'U') e di cui almeno un cedolino dell'anno corrente sia stato trasmesso
	INSERT INTO #modulocococo (idreg) 
	SELECT DISTINCT co.idreg         
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service on service.idser = co.idser
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND (@modello='cud' and service.certificatekind='U' or @modello='770' and service.rec770kind='G')

	-- Inizio Seconda Sezione dichiarativa
	-- Convenzione adottata nella dichiarazione delle variabili:
	-- Tutte le variabili che hanno prefisso "w" sono variabili usate
	-- nella sezione che calcola il 770 (o CUD) di prestazioni inserite e pagate dal modulo di spesa
	-- mentre le variabili che hanno prefisso "z" sono variabili usate
	-- nella sezione che calcola il 770 (o CUD) di prestazioni inserite dal modulo parasubordinati.
	-- Mentre la combinazione lettera + numeri che precede la parte descrittiva della variabile
	-- indica la sezione ed il campo del quadro G dove verranno inseriti i valori di tali variabili
	-- Esempi:
	-- @wb1RedditoDedArt11 significa che questa variabile è valorizzata nel ramo delle prestazioni inserite
	-- dal modulo di spesa e il valore della stessa andrà nella sezione B campo 1 del quadro G
	-- @zb3workingdays significa che questa variabile è valorizzata nel ramo delle prestazioni inserite
	-- dal modulo parasubordinati e il valore della stessa andrà nella sezione B campo 3 del quadro G

	declare
		@codeser varchar(20),
		@idreg int,
		@denominazione varchar(50),
		@p_iva varchar(15),
		@idcitynascita int,
		@idnationnascita int,
		@flagcfestero char,

		@a1cf varchar(20),
		@a2cognome varchar(50),
		@a3nome varchar(50),
		@a4gender char,
		@a5birthdate datetime,
		@a6comuneostatonascita varchar(50),
		@a7provNascita varchar(2),
		@a12comune01gen09  varchar(50),
		@a13prov01gen09  varchar(2),
		@a14codicecomune01gen09  varchar(10),
		@a15comune31dic09  varchar(50),
		@a16prov31dic09  varchar(2),
		@a17comune01gen10  varchar(50),
		@a18prov01gen10  varchar(2),
		@a19codiceComune01gen10  varchar(10),

		@wb1RedditoDedArt11 decimal(19,2),		--Redditi per i quali è possibile fruire della detrazione di cui all’art. 13, commi 1, 2, 3 e 4 del Tuir
		@wb3workingdays int,					--Lavoro dipendente
		@wb5ritIRPEF decimal(19,2),				--Pensione
		@wb6add_reg decimal(19,2),				--Addizionale regionale all’Irpef
		@wb10addcomacconto09  decimal(19,2),		--Addizionale regionale @annoredditi trattenuta nel @annodichiarazione
		@wb11addcomsaldo09  decimal(19,2),		--Saldo @annodichiarazione
		@wb13addcomacconto10  decimal(19,2),		--Acconto 2010
		@wb33impostalorda  decimal(19,2),		--Imposta lorda
		@wb40detrazioniperoneri  decimal(19,2),	--b21 Detrazioni per oneri

		@wb45totaledetrazioni  decimal(19,2),	--b Totale Detrazioni

		@wb58deductionart10  decimal(19,2),		--b58 Totale oneri sostenuti esclusi dai redditi indicati nei punti 1 e 2
		@wb59oneridetraibili  decimal(19,2),		--b59 Totale oneri per i quali è prevista la detrazione d’imposta
		@wb63maggioreritenuta  varchar(10),		--Applicazione maggiore ritenuta
		-- @wb56totaleredditiconguagliato decimal(19,2),--b45 Totale redditi conguagliato già compreso nel punto 1 >>>> NON LO USA, sara
		-- @wb61cudimpfisclordo decimal(19,2),			--b50 Reddito conguagliato								>>>> NON LO USA, sara
		-- @wb62cudirpef decimal(19,2),					--b51 Ritenute											>>>> NON LO USA, sara
		-- @wb63cudirpefsosp decimal(19,2),			--b52 Ritenute sospese										>>>>> NON LO USA, sara
		-- @wb64cudaddreg decimal(19,2),				--b53 Addizionale regionale								>>>> NON LO USA, sara
		-- @wb65cudaddregsosp decimal(19,2),			--b54 Addizionale regionale sospesa						>>>> NON LO USA, sara
		-- @wb66cudaddcomacconto decimal(19,2),		--b55 Addizionale comunale acconto @annodichiarazione		>>>> NON LO USA, sara
		-- @wb67cudaddcomsaldo decimal(19,2),			--b55 Addizionale comunale saldo @annodichiarazione		>>>> NON LO USA, sara
		-- @wb68cudaddcomsosp decimal(19,2),			--b56 Addizionale comunale sospesa						>>>> NON LO USA, sara
		@wb245_ai varchar(100),						-- Variabile che contiene la nota AI
		@wb246_aj varchar(100),						-- Variabile che contiene la nota AJ
		@wc12compensoprev decimal(19,2),			--c12 Compensi corrisposti al collaboratore
		@wc13ritprevdovuta decimal(19,2),			--c13 Contributi dovuti
		@wc14ritprevtrattenuta decimal(19,2),		--c14 Contributi a carico del collaboratore trattenuti
		@wc15ritprevpagata decimal(19,2),			--c15 Contributi versati
		@wc16emensTuttiIMesi int,					--c16 Tutti con l’esclusione di
		@wc17mesiSenzaEmens varchar(12),			--c17 Tutti
		@wc81patcode varchar(10),					--c80 Posizione assicurativa territoriale
		@wc84start_XXX datetime,						--c81 Data inizio
		@wc85stop_XXX datetime,							--c82 Data fine

		@zb1RedditoDedArt11 decimal(19,2),			--b1 Redditi per i quali è possibile fruire della detrazione di cui all’art. 13, commi 1, 2, 3 e 4 del Tuir
		@zb3workingdays int,						--b3 Lavoro dipendente
		@zb5ritIRPEF decimal(19,2),					--b5 Ritenute Irpef
		@zb6add_reg decimal(19,2),					--b6 Addizionale regionale all’Irpef
		@zb10addcomacconto09 decimal(19,2),			--b10 Acconto @annodichiarazione
		@zb11addcomsaldo09 decimal(19,2),			--b11 Saldo @annodichiarazione
		@zb13addcomacconto10 decimal(19,2),			--b13 Acconto 2010
		@zb21primaratairpef_caf decimal(19,2),		-- Prima Rata IRPEF da C.A.F.
		@zb22secondaratairpef_caf decimal(19,2),	-- Seconda Rata IRPEF da C.A.F.
		@zb33ImpostaLorda  decimal(19,2),		--b33 Imposta lorda
		@zb34detrazionipercarichifamiliari  decimal(19,2),	--b34 Detrazioni per oneri
		@zb39detrazioniperreddito  decimal(19,2),			--b39 Detrazioni per oneri
		@zb40detrazioniperoneri  decimal(19,2),				--b40 Detrazioni per oneri
		@zb45totaledetrazioni  decimal(19,2),				--b45 Totale Detrazioni 
		@zb58deductionart10  decimal(19,2),					--b58 Totale oneri sostenuti esclusi dai redditi indicati nei punti 1 e 2
		@zb59oneridetraibili  decimal(19,2),					--b59 Totale oneri per i quali è prevista la detrazione d’imposta
		@zb63maggioreritenuta  varchar(10),					--b63 Applicazione maggiore ritenuta
		@zb50altriredditi decimal(19,2),					--b40 Altri redditi				>>>> NON LO USA, sara
		@zb73totaleredditiconguagliato  decimal(19,2),	--b73 Totale redditi conguagliato già compreso nel punto 1
		@zb75cudcodfisc_XXX varchar(16),						--b47 Codice fiscale			
		@zb78cudimpfisclordo_XXX decimal(19,2),					--b50 Reddito conguagliato		
		@zb80cudirpef_XXX decimal(19,2),						--b51 Ritenute					
		@zb81cudirpefsosp_XXX decimal(19,2),					--b52 Ritenute sospese			
		@zb84cudaddreg_XXX decimal(19,2),						--b53 Addizionale regionale		
		@zb85cudaddregsosp_XXX decimal(19,2),					--b54 Addizionale regionale sospesa						
		@zb86cudaddcomacconto_XXX decimal(19,2),				--b55 Addizionale comunale acconto @annodichiarazione	
		@zb87cudaddcomsaldo_XXX decimal(19,2),					--b55 Addizionale comunale saldo @annodichiarazione		
		@zb88cudaddcomsosp_XXX decimal(19,2),					--b56 Addizionale comunale sospesa						
		@zb245_ai varchar(100),			-- Variabile che contiene la nota AI
		@zb246_aj varchar(100),			-- Variabile che contiene la nota AJ
		@zb249_am varchar(100),			-- Variabile che contiene la nota AM
		@zb254_ar varchar(100),			-- Variabile che contiene la nota AR
		@zb256_at varchar(100),			-- Variabile che contiene la nota AT
		@zb260_ax varchar(100),			-- Variabile che contiene la nota AX
		@zb262_az varchar(100),			-- Variabile che contiene la nota AZ
		@zc12compensoprev decimal(19,2),		--c12 Compensi corrisposti al collaboratore
		@zc13ritprevdovuta decimal(19,2),		--c13 Contributi dovuti
		@zc14ritprevtrattenuta decimal(19,2),	--c14 Contributi a carico del collaboratore trattenuti
		@zc15ritprevpagata decimal(19,2),		--c15 Contributi versati
		@zc16emensTuttiIMesi int,				--c16 Tutti
		@zc17mesiSenzaEmens varchar(12),		--c17 Tutti con l’esclusione di
		@zc83patcode_XXX varchar(10),				--c80 Posizione assicurativa territoriale		
		@zc82start datetime,					--c81 Data inizio								>>>> NON LO USA, sara
		@zc83stop datetime,						--c82 Data fine									>>>> NON LO USA, sara
		@zc86codiceComuneEnte_XXX varchar(4)		--c83 Codice comune							

	DECLARE @codfiscEnte varchar(16)
	declare @idcityEnte int
	SELECT @codfiscEnte = cf, @idcityEnte = idcity FROM license

	-- Fine Seconda Sezione dichiarativa

	-- Tabella di output che contiene le informazioni del record G (che successivamente verranno elaborate dal form del 770)
	CREATE TABLE #recordg
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		decimale dec(19,2),
		intero int,
		data datetime
	)


	--INIZIO PRELIEVO DATI DA expensetax
	-- Tabella che contiene i movimenti finanziari di prestazioni pagate mediante il modulo di spesa
	-- e non mediante l'uso del modulo parasubordinati
	CREATE TABLE #wizard
	(
		idexp int,
		idreg int,
		idser int,
		importocorrente decimal(19,2),
		servicestart datetime,
		servicestop datetime,
		adate datetime,
		imponibile decimal(19,2),
		taxcode int,
		importoritenuta decimal(19,2),
		deduzione decimal(19,2),
		detrazione decimal(19,2),
		taxkind smallint,
		geoappliance char,
		--ytaxpay int, NON SONO MAI USATI
		--ntaxpay int, NON SONO MAI USATI
		idmot varchar(10),
		admintax decimal(19,2),
		taxref varchar(20)
	)

	-- Fase massima di spesa
	DECLARE @maxexpensephase tinyint
	SELECT @maxexpensephase = MAX(nphase) FROM expensephase

	-- Tabella delle prestazioni adoperate nei contratti
	CREATE TABLE #ser (idser int, codeser varchar(20))

	-- Vengono considerate solo le prestazioni NON presenti nel modulo PARASUBORDINATI
	-- Riempimento della tabella dei percipienti coinvolti nella certificazione.
	-- per Modello 770
	-- Vengono presi tutti i movimenti di spesa il cui percipiente ha una tipologia differente da quella "per mandati"
	-- con importo netto maggiore di zero e con data di trasmissione avvenuta tra il 13 gennaio dell'anno precedente ed il 12 gennaio
	-- dell'anno corrente, che il movimento di spesa non derivi dalla contabilizzazione di un cedolino e che la prestazione
	-- associata al movimento di spesa ricada nel quadro G del 770

	-- per CUD
	-- Vengono presi tutti i movimenti di spesa il cui percipiente ha una tipologia differente da quella "per mandati"
	-- con importo netto maggiore di zero e con data di trasmissione avvenuta tra il 13 gennaio dell'anno precedente ed il 12 gennaio
	-- dell'anno corrente, che il movimento di spesa non derivi dalla contabilizzazione di un cedolino e che la prestazione
	-- associata al movimento di spesa abbia associata come certificazione il CUD

	INSERT INTO #wizard
	(
		idexp,--1
		idreg,--2
		idser,--3
		importocorrente,--4
		servicestart,--5
		servicestop,--6
		adate,--7
		imponibile,--8
		taxcode,--9
		importoritenuta,--10
		deduzione,--11
		detrazione,--12
		taxkind,--13
		geoappliance,--14
		-- ytaxpay,--15 NON SONO MAI USATI
		-- ntaxpay,--16 NON SONO MAI USATI
		idmot,--17
		admintax,
		taxref
	)
	SELECT
		expense.idexp,--1
		expense.idreg,--2
		expenselast.idser,--3
		expenseyear.amount
		+ ISNULL(
			(SELECT SUM(amount) FROM expensevar
			WHERE expensevar.idexp = expense.idexp
			AND expensevar.yvar <= @annoredditi
			AND ISNULL(autokind,0) <> 4)
		,0),--4
		expenselast.servicestart,--5
		expenselast.servicestop,--6
		expense.adate,--7
		expensetaxofficial.taxablegross,--8
		expensetaxofficial.taxcode,--9
		expensetaxofficial.employtax,--10
		expensetaxofficial.exemptionquota,--11
		expensetaxofficial.abatements,--12
		tax.taxkind,--13
		tax.geoappliance,--14
		-- expensetax.ytaxpay,--15 NON SONO MAI USATI
		-- expensetax.ntaxpay,--16 NON SONO MAI USATI
		motive770service.idmot,--17
		expensetaxofficial.admintax,--18
		tax.taxref
	FROM expense
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN expensetaxofficial 
		ON expense.idexp = expensetaxofficial.idexp
	JOIN service
		ON service.idser=expenselast.idser
	JOIN tax
		ON expensetaxofficial.taxcode = tax.taxcode
	JOIN registry
		ON expense.idreg = registry.idreg
	join payment 
		on payment.kpay=expenselast.kpay
	join paymenttransmission 
		on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
	LEFT OUTER JOIN motive770service
		ON motive770service.idser = service.idser
		AND motive770service.ayear = @annodichiarazione
	where transmissiondate between @13gen09 and @12gen10
		AND registry.idregistryclass <> '10'
		AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg)
		AND (@modello='cud' and service.certificatekind = 'U' or @modello='770' and service.rec770kind='G')
		AND (expenseyear.amount
			+ ISNULL(
				(SELECT SUM(amount) FROM expensevar
				WHERE expensevar.idexp = expense.idexp
				AND expensevar.yvar <= @annoredditi
				AND ISNULL(autokind,0) <> 4)
			,0)) > 0
		and not exists (SELECT * from expensepayroll
		join expenselink
			on expenselink.idparent = expensepayroll.idexp
		where expensetaxofficial.idexp = expenselink.idchild)
                and expensetaxofficial.stop is null

-- FINE PRELIEVO DATI DA expensetax

	-- Tabella dei contratti parasubordinati coinvolti nel 770
	create table #contratti
	(
		idcon varchar(8),
		padre varchar(8),
		taxablepension decimal(19,2),
		fiscaltaxablegross decimal(19,2),
		inpsinail decimal(19,2),
		deduction decimal(19,2),
		idpayroll int, -- Cedolino di conguaglio
		stop datetime, -- Data fine del cedolino di conguaglio
		capofila char(1),
		certificatekind char(1),
		idser int
	)

	-- Tabella dei cedolini
	create table #cedolini (
		idcedolino int, 
		idexp int,
		idcon varchar(8),
		datacompetenza datetime, 
		startpayroll datetime,
		stoppayroll datetime,
		compensoprev decimal(19,2),
		ritprevtrattenuta decimal(19,2),
		inpsamm decimal(19,2),
		inail decimal(19,2),
	)
	
	-- Tabella del coniuge (per le detrazioni su familiari)
	create table #coniuge (
		idconiuge int,
		b278codiceFiscaleConiuge varchar(16),
		b279numeroMesiACarico int,
		bXXXanno int
	)

	-- Tabella dove vengono inseriti i primi figli (per le detrazioni su familiari)
	create table #primoFiglio (
		idPrimoFiglio int,
		b280casellaPrimoFiglio int,
		b281casellaDisabile int, 
		b282codiceFiscalePrimoFiglio varchar(16),
		b283numeroMesiACarico int, 
		b284minoreDiTreAnni int,
		bc85percentualeDiDetrazioneSpettante dec(19,6),
		bd85detrazionePerConiugeACarico char,
		bYYYanno int
	)

	-- Tabella dove vengono inseriti i figli diversi dal primo (per le detrazioni su familiari)
	create table #altroFiglio (
		idAltroFiglio int,
		b286casellaFiglio int,
		b287casellaAltroFamiliare int,
		b288casellaDisabile int,
		b289codiceFiscaleFamiliare varchar(16),
		b290numeroMesiACarico int,
		b291minoreDiTreAnni int, 
		bc92percentualeDiDetrazioneSpettante dec(19,6),
		bd92detrazionePerConiugeACarico char,
		bZZZAnno int
	)

	-- Progressivo comunicazione
	declare @progrComunic int
	set @progrComunic = 1

	declare @chiave int
	declare @tipo char
	declare @cognome varchar(60)

	declare @cursorecomunicazione cursor 

	-- Si definisce un cursore per ciclare sulla movimentazione finanziaria (nel caso di prestazioni inserite
	-- dal modulo di spesa) e sui percipienti (nel caso di prestazioni inserite da modulo parasubordinati).
	-- Per distinguere all'interno del cursore le informazioni derivanti da moduli differenti si è scelto di 
	-- adoperare la lettera W per spesa e C per il parasubordinato
	set @cursorecomunicazione = cursor for
		SELECT DISTINCT idexp, tipo='W', surname from #wizard
			join registry on #wizard.idreg=registry.idreg
		UNION ALL
		SELECT DISTINCT #modulocococo.idreg, tipo = 'C', surname
		FROM #modulocococo
		JOIN registry
			ON #modulocococo.idreg = registry.idreg
		ORDER BY tipo, surname
/*		SELECT distinct idcon, tipo='C', surname from #modulocococo
			join registry on #modulocococo.idreg=registry.idreg
		order by tipo, surname*/

	open @cursorecomunicazione
	fetch next from @cursorecomunicazione into @chiave, @tipo, @cognome

	WHILE @@fetch_status=0 
	begin
		-- Inizio Sezione azzeramento variabili
		set @a1cf = null
		set @a2cognome = null
		set @a3nome = null
		set @a4gender = null
		set @a5birthdate = null
		set @a6comuneostatonascita = null
		set @a7provNascita = null
		set @a12comune01gen09  = null
		set @a13prov01gen09  = null
		set @a14codicecomune01gen09  = null
		set @a15comune31dic09  = null
		set @a16prov31dic09  = null
		set @a17comune01gen10  = null
		set @a18prov01gen10  = null
		set @a19codiceComune01gen10  = null

		set @wb1RedditoDedArt11 = null
		set @wb3workingdays = null
		set @wb5ritIRPEF = null
		set @wb6add_reg = null
		set @wb10addcomacconto09  = null
		set @wb11addcomsaldo09  = null
		set @wb13addcomacconto10  = null
		set @wb33impostalorda  = null
		set @wb40detrazioniperoneri  = null
        set @wb45totaledetrazioni  = null
		set @wb58deductionart10  = null
		set @wb59oneridetraibili  = null
		set @wb63maggioreritenuta  = null
		--set @wb56totaleredditiconguagliato = null
		--set @wb61cudimpfisclordo = null
		--set @wb62cudirpef = null
		--set @wb63cudirpefsosp = null
		--set @wb64cudaddreg = null
		--set @wb65cudaddregsosp = null
		--set @wb66cudaddcomacconto = null
		--set @wb67cudaddcomsaldo = null
		--set @wb68cudaddcomsosp = null
		SET @wb245_ai = NULL
		SET @wb246_aj = NULL
		set @wc12compensoprev = null
		set @wc13ritprevdovuta = null
		set @wc14ritprevtrattenuta = null
		set @wc15ritprevpagata = null
		set @wc16emensTuttiIMesi = null
		set @wc17mesiSenzaEmens = null
		set @wc81patcode = null
		set @wc84start_XXX = null
		set @wc85stop_XXX = null

		set @zb1RedditoDedArt11 = null
		set @zb3workingdays = null
		set @zb5ritIRPEF = null
		set @zb6add_reg = null
		set @zb10addcomacconto09 = null
		set @zb11addcomsaldo09 = null
		set @zb13addcomacconto10 = null

		SET @zb21primaratairpef_caf = NULL
		SET @zb22secondaratairpef_caf = NULL

		set @zb33ImpostaLorda  = null
		set @zb34detrazionipercarichifamiliari  = null
		set @zb39detrazioniperreddito  = null
		set @zb40detrazioniperoneri  = null
		set @zb45totaledetrazioni  = null
		set @zb58deductionart10  = null
		set @zb59oneridetraibili  = null
		set @zb63maggioreritenuta  = null
		set @zb50altriredditi = null
		set @zb73totaleredditiconguagliato  = null
		set @zb75cudcodfisc_XXX = null
		set @zb78cudimpfisclordo_XXX = null
		set @zb80cudirpef_XXX = null
		set @zb81cudirpefsosp_XXX = null
		set @zb84cudaddreg_XXX = null
		set @zb85cudaddregsosp_XXX = null
		set @zb86cudaddcomacconto_XXX = null
		set @zb87cudaddcomsaldo_XXX = null
		set @zb88cudaddcomsosp_XXX = null
		SET @zb245_ai = NULL
		SET @zb246_aj = NULL
		SET @zb249_am = NULL
		SET @zb254_ar = NULL
		SET @zb256_at = NULL
		SET @zb260_ax = NULL
		SET @zb262_az = NULL
		set @zc12compensoprev = null
		set @zc13ritprevdovuta = null
		set @zc14ritprevtrattenuta = null
		set @zc15ritprevpagata = null
		set @zc16emensTuttiIMesi = null
		set @zc17mesiSenzaEmens = null
		set @zc83patcode_XXX = null
		set @zc82start = null
		set @zc83stop = null
		set @zc86codiceComuneEnte_XXX = null
	
		-- Inizio Sezione azzeramento variabili

		SELECT @zc86codiceComuneEnte_XXX = value from geo_city_agency 
			where idcode=1 and idcity=@idcityente and idagency=1
	
		--4 Spazio a disposizione dell'utente
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '04', @tipo)
		--8 Spazio a disposizione dell'utente per l'identificazione della dichiarazione
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '08', @chiave)
			
		-- Si imposta la variabile il percipiente che nel caso di spesa viene estratta in base al movimento di spesa
		-- nel caso di parasubordinato è direttamente il valore della variabile @chiave
		if @tipo <> 'C'
		BEGIN
			SELECT @idreg = idreg FROM #wizard WHERE idexp = @chiave
		END
		ELSE
		BEGIN
			SET @idreg = @chiave
		END

		-- Modulo Parasubordinati
		IF (@tipo = 'C')
		BEGIN
			-- Si svuota la tabella dei contratti legata al percipiente
			DELETE #contratti
			-- insert into #contratti (idcon, padre) values (@chiave, null)
	
			-- Si inseriscono i contratti del percipiente corrente.
			-- La query eseguita ricalca quella adottata per la selezione dei percipienti (riempimento della tabella #modulocococo)
			-- Più precisamente:
			-- per Modello 770
			-- Vengono presi tutti i contratti di un fissato percipiente per i quali esiste almeno un cedolino che sia stato trasmesso
			-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
			-- al quadro G del 770 (rec770kind = 'G'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
			-- le deduzioni, l'imponibile fiscale lordo del contratto e l'id e la data di fine del cedolino di conguaglio.

			-- per Modello CUD
			-- Vengono presi tutti i contratti di un fissato percipiente per i quali esiste almeno un cedolino che sia stato trasmesso
			-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
			-- alla certificazione CUD (certificatekind = 'U'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
			-- le deduzioni, l'imponibile fiscale lordo del contratto e l'id e la data di fine del cedolino di conguaglio.
			
			INSERT INTO #contratti
				(idcon, taxablepension, inpsinail, deduction,
				fiscaltaxablegross, idpayroll, stop, certificatekind, idser)
			SELECT
				co.idcon,
				s.taxablepension,
				s.inpsinail,
				s.deduction,
				s.fiscaltaxablegross,
				ce.idpayroll,
				ce.stop,
				service.certificatekind,
				co.idser
			FROM payroll ce 
			JOIN parasubcontract co
				ON co.idcon = ce.idcon
	                JOIN parasubcontractyear im
				ON co.idcon = im.idcon
				AND im.ayear = @annoredditi
	                JOIN parasubcontractsummaryview s
				ON s.idcon = im.idcon
				AND s.ayear = im.ayear
			JOIN service
				ON service.idser = co.idser
			WHERE ce.flagbalance = 'S'
				AND ce.fiscalyear=@annoredditi
				-- AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
				AND EXISTS (SELECT payroll.idpayroll from payroll 
						join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
						join expenselink ON expenselink.idparent = expensepayroll.idexp
						join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
						join payment on payment.kpay=expenselast.kpay
						where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
					AND payroll.fiscalyear = @annoredditi)
				AND (@modello='cud' and service.certificatekind='U' or @modello='770' and service.rec770kind='G')
				AND co.idreg = @chiave

			-- Si aggiorna la catena tra contratti scaturita dall'uso dei CUD.
			-- La catena si aggiorna impostando il campo PADRE della tabella #contratti, dove nel campo PADRE si inserisce 
			-- sul contratto puntato dal CUD il contratto contenitore del CUD
			-- Esempio:
			-- Contratto 10
			-- Contratto 11
			-- CUD inserito nel contratto 11 riferito al contratto 10
			-- Il contratto 10 avrà come padre il contratto 11
			UPDATE #contratti
			SET padre = exhibitedcud.idcon
			FROM exhibitedcud
			WHERE exhibitedcud.idlinkedcon = #contratti.idcon
				AND exhibitedcud.fiscalyear = @annoredditi

			-- Si definisce un contratto capofila per il percipiente
			-- Un contratto capofila è da considerarsi come radice dell'albero dei contratti
			-- Se esiste un solo contratto con il campo PADRE non valorizzato sarà questo contratto
			-- ad essere individuato come capofila
			-- altrimenti si sceglie come capofila un contratto tra tutti quelli senza padre.
			-- N.B. Per le prestazioni Co.Co.Co. per cui la certificazione associata è il CUD
			-- ove ci siano più contratti c'è sempre un capofila, mentre per prestazioni tipo
			-- assegnisti di ricerca accade che ci siano più contratti non legati tra loro in quanto
			-- non esiste il concetto di trasformare un contratto pregresso in CUD per uno nuovo
			-- in quanto non vi è l'esigenza di effettuare un conguaglio fiscale.
			IF (SELECT COUNT(*) FROM #contratti WHERE padre IS NULL) = 1
			BEGIN
				UPDATE #contratti
				SET capofila = 'S'
				WHERE #contratti.padre IS NULL
			END
			ELSE
			BEGIN
				UPDATE #contratti
				SET capofila = 'S'
				WHERE idcon = (SELECT TOP 1 idcon FROM #contratti WHERE padre IS NULL)
			END
		END -- Fine IF (tipo = 'C')

		-- Sezione comune a entrambe i moduli
		-- Valorizzazione delle informazioni relative al percipiente
		SELECT
			@denominazione = registry.title,
			@a1cf =  registry.cf,
			@p_iva = registry.p_iva,
			@a2cognome = registry.surname,
			@a3nome = registry.forename,
			@a5birthdate = registry.birthdate,
			@a4gender = registry.gender,
			@idcitynascita = registry.idcity,
			@idnationnascita = registry.idnation,
			@flagcfestero = CASE 
				WHEN registry.cf IS NULL THEN 'S'
				WHEN registry.cf IS NOT NULL THEN 'N'
			END
			FROM registry
			WHERE registry.idreg = @idreg
	
		-- Attualizzazione del comune di nascita
		WHILE (SELECT newcity from geo_city where idcity=@idcitynascita) is not null
		BEGIN
			SELECT @idcitynascita=newcity from geo_city where idcity=@idcitynascita 
		END
	
		-- Eccezione sulla attualizzazione della provincia di nascita nel caso i comuni ricadano nella nuova provincia BT 
		-- (Barletta Andria Trani). Il sw del Ministero per il 2010 non riconosce tale provincia e quindi 
		-- si selezionano le "vecchie province" di Bari o Foggia a seconda del comune. In sede di realizzazione del 
		-- 770 e CUD per il 2010 valutare se la nuova provincia è riconosciuta.
		SELECT
			@a6comuneostatonascita = geo_city.title,
			@a7provNascita = 
			case 
			WHEN @idcitynascita in (13935, 13936, 13937, 13938, 13940, 13942, 13943) THEN 'BA'
			WHEN @idcitynascita in (13939, 13941, 13944) THEN 'FG'
			ELSE geo_country.province 
			end
		from geo_city 
		join geo_country 
			on geo_city.idcountry = geo_country.idcountry
		where geo_city.idcity = @idcitynascita
	
		-- Se il comune non risulta valorizzato vuol dire che il percipiente è nato all'estero
		-- e quindi si cerca il nome dello stato estero di nascita
		if (@a6comuneostatonascita is null) 
		begin
			SELECT @a6comuneostatonascita = geo_nation.title
				from geo_nation where geo_nation.idnation = @idnationnascita
		end
	
		declare @idresidence01gen09  int
		set @idresidence01gen09  = null
	
		declare @ayear int
		-- J.T.R. Commentiamo in quanto non lavoriamo più per contratto ma per percipiente.
		-- L'IF di sotto sarà sempre vero, in effetti si potrebbe togliere l'if a questo punto.
--		SELECT  @idresidence01gen09  = idresidence, @ayear = ayear from parasubcontractyear where idcon = @chiave and ayear = @annoredditi
		
		-- Sezione per determinare la residenza di un percipiente all'1 gennaio dell'anno dei redditi ai fini dell'addizionale comunale.
		-- Viene sempre chiamata la SP trovaIndirizzo per selezionare l'indirizzo valido del percipiente.
		-- La SP riceve in input il codice del percipiente e una data di riferimento e ritorna un tipo indirizzo e una data di validità
		-- dell'indirizzo.
		-- A questo punto si può interrogare la tabella REGISTRYADDRESS filtrando per idreg, idaddresskind e start (la chiave!)
		if ((@idresidence01gen09 ) is null OR (ISNULL(@ayear, @annoredditi) > 2009))
		begin
			DECLARE @idaddresskind01gen09  int
			DECLARE @start01gen09  datetime
			exec trovaIndirizzo770 @idreg, @1gen09, @idaddresskind01gen09  OUTPUT, @start01gen09  OUTPUT
	
			SELECT @idresidence01gen09  = idcity 
				FROM registryaddress
				where registryaddress.idreg = @idreg
				AND registryaddress.idaddresskind = @idaddresskind01gen09 
				AND registryaddress.start = @start01gen09 
		end

		-- Si attualizza il comune di residenza all'1 gennaio
		WHILE (SELECT newcity from geo_city where idcity=@idresidence01gen09 ) is not null
		BEGIN
			SELECT @idresidence01gen09 =newcity from geo_city where idcity=@idresidence01gen09  
		END
	
		-- Si determinano il nome del comune e della provincia di residenza, tenendo sempre conto dell'eccezione
		-- inerente la costituenda provincia BT (come per la provincia di nascita).
		SELECT
			@a12comune01gen09  = geo_city.title,
			@a13prov01gen09  = 
			CASE 
				WHEN @idresidence01gen09  in (13935, 13936, 13937, 13938, 13940, 13942, 13943) THEN 'BA'
				WHEN @idresidence01gen09  in (13939, 13941, 13944) THEN 'FG'
				ELSE geo_country.province 
			END,
			@a14codicecomune01gen09  = geo_city_agency.value
		FROM geo_city
		LEFT OUTER JOIN geo_country
			on geo_city.idcountry = geo_country.idcountry
		LEFT OUTER JOIN geo_city_agency 
			on geo_city.idcity=geo_city_agency.idcity and geo_city_agency.idagency = 1 and geo_city_agency.idcode = 1
		where geo_city.idcity = @idresidence01gen09 
	
			
		-- J.T.R. 10.09.2009 COMMENTO A QUANTO DETTO VERSO MAGGIO 2009
		-- * E' CAMBIATA LA LOGICA, RESTA QUESTO COMMENTO PER VALUTARE NEGLI ANNI SUCCESSIVI 
		-- * SE L'IDRESIDENCE DEL CONTRATTO PUO' RITENERSI VALIDO MA SE COSI' FOSSE
		-- * PER OTTENERE L'IDRESIDENCE BISOGNA CAMBIARE SEZIONE CREANDONE DELLE DISTINTE PER COCOCO
		-- * E MODULO SPESA.
		-- Ai fini dell'applicazione delle addizionali regionali deve essere considerato 
		-- il domicilio al 31 dicembre dell'anno in cui si sono percepiti redditi
		-- oppure alla data di fine contratto se precedente.
		-- Per le dichiarazioni del 2009 relative ai redditi del 2008 ho ipotizzato 
		-- che idresidence di parasubcontracyear potesse essere calcolato in modo errato, 
		-- non tenendo in conto della data di fine contratto se precedente. 
		-- Infatti le nostre modifiche sono avvenute in corso d'anno. 
		-- Quindi lo ricalcolo. Per gli anni successivi idresidence potrà essere ritenuto corretto 
		-- senza condizioni
	
	
		declare @idresidence31dic09  int
		set 	@idresidence31dic09  = null
		-- J.T.R. Commentiamo in quanto non lavoriamo più per contratto ma per percipiente.
		-- L'IF di sotto sarà sempre vero, in effetti si potrebbe togliere l'if a questo punto.
--		SELECT  @idresidence31dic09  = idresidence from parasubcontractyear where idcon = @chiave and ayear = @annoredditi
		
		-- Sezione per determinare la residenza di un percipiente all'31 dicembre dell'anno dei redditi ai fini dell'addizionale regionale.
		-- Viene sempre chiamata la SP trovaIndirizzo per selezionare l'indirizzo valido del percipiente.
		-- La SP riceve in input il codice del percipiente e una data di riferimento e ritorna un tipo indirizzo e una data di validità
		-- dell'indirizzo.
		-- A questo punto si può interrogare la tabella REGISTRYADDRESS filtrando per idreg, idaddresskind e start (la chiave!)
		-- All'interno dell'IF vi è una distinzione sulle date scelte, nel caso di modulo parasubordinati si seleziona la data di fine massima
		-- tra tutti i contratti del percipiente mentre per il modulo spesa si seleziona la data di fine prestazione in alternativa la data
		-- contabile del movimento di spesa
		if ((@idresidence31dic09  is null) OR (ISNULL(@ayear, @annoredditi) > 2009))
		begin
			DECLARE @idaddresskind31dic09  int
			DECLARE @start31dic09  datetime
			
			declare @stop datetime
			IF (@tipo = 'C')
			BEGIN
				SELECT @stop = MAX(stop) FROM #contratti
			END
			ELSE
			BEGIN
				SELECT @stop = ISNULL(expenselast.servicestop, expense.adate)
				FROM expenselast
				JOIN expense
					ON expense.idexp = expenselast.idexp
				WHERE expense.idexp = @chiave
			END

			if (ISNULL(@stop,@31dic09) < @31dic09)
			begin
				exec trovaIndirizzo770 @idreg, @stop, @idaddresskind31dic09  OUTPUT, @start31dic09  OUTPUT
			end 
			else
			begin
				exec trovaIndirizzo770 @idreg, @31dic09, @idaddresskind31dic09  OUTPUT, @start31dic09  OUTPUT
			end
	
			SELECT @idresidence31dic09  = idcity 
				FROM registryaddress
				where registryaddress.idreg = @idreg
				AND registryaddress.idaddresskind = @idaddresskind31dic09 
				AND registryaddress.start = @start31dic09 
		end
	
		-- Si attualizza il comune di residenza all'31 dicembre (o data di cessazione del rapporto)
		WHILE (SELECT newcity from geo_city where idcity=@idresidence31dic09 ) is not null
		BEGIN
			SELECT @idresidence31dic09 =newcity from geo_city where idcity=@idresidence31dic09  
		END
	
		-- Si determinano il nome del comune e della provincia di residenza, tenendo sempre conto dell'eccezione
		-- inerente la costituenda provincia BT (come per la provincia di nascita).
		SELECT
			@a15comune31dic09  = geo_city.title,
			@a16prov31dic09  = 
			case 
				WHEN @idresidence31dic09  in (13935, 13936, 13937, 13938, 13940, 13942, 13943) THEN 'BA'
				WHEN @idresidence31dic09  in (13939, 13941, 13944) THEN 'FG'
				ELSE geo_country.province 
			end
		FROM geo_city
		LEFT OUTER JOIN geo_country
			on geo_city.idcountry = geo_country.idcountry
		where geo_city.idcity = @idresidence31dic09 
	
		declare @idresidence01gen10  int
		set  	@idresidence01gen10  = null
		set  	@ayear = null
		-- J.T.R. Commentiamo in quanto non lavoriamo più per contratto ma per percipiente.
		-- L'IF di sotto sarà sempre vero, in effetti si potrebbe togliere l'if a questo punto.
--		SELECT @idresidence01gen10  = idresidence, @ayear = ayear from parasubcontractyear where idcon = @chiave and ayear = @annodichiarazione
	
		-- Sezione per determinare la residenza di un percipiente all'1 gennaio dell'anno della dichiarazione ai fini dell'addizionale comunale (acconto).
		-- Viene sempre chiamata la SP trovaIndirizzo per selezionare l'indirizzo valido del percipiente.
		-- La SP riceve in input il codice del percipiente e una data di riferimento e ritorna un tipo indirizzo e una data di validità
		-- dell'indirizzo.
		-- A questo punto si può interrogare la tabella REGISTRYADDRESS filtrando per idreg, idaddresskind e start (la chiave!)
		if ((@idresidence01gen10  is null) OR (ISNULL(@ayear,@annodichiarazione) > 2009))
		begin
			DECLARE @idaddresskind01gen10  int
			DECLARE @start01gen10 datetime
			exec trovaIndirizzo770 @idreg, @1gen10, @idaddresskind01gen10  OUTPUT, @start01gen10 OUTPUT
	
			SELECT @idresidence01gen10  = idcity 
				FROM registryaddress
				where registryaddress.idreg = @idreg
				AND registryaddress.idaddresskind = @idaddresskind01gen10 
				AND registryaddress.start = @start01gen10
		end

		-- Si attualizza il comune di residenza all'1 gennaio dell'anno della dichiarazione (o data di cessazione del rapporto)	
		WHILE (SELECT newcity from geo_city where idcity=@idresidence01gen10 ) is not null
		BEGIN
			SELECT @idresidence01gen10 =newcity from geo_city where idcity=@idresidence01gen10  
		END

		-- Si determinano il nome del comune e della provincia di residenza, tenendo sempre conto dell'eccezione
		-- inerente la costituenda provincia BT (come per la provincia di nascita).	
		if (@idresidence01gen10  != @idresidence31dic09 )
		begin
			SELECT
				@a17comune01gen10  = geo_city.title,
				@a18prov01gen10  = 
				case 
					WHEN @idresidence01gen10  in (13935, 13936, 13937, 13938, 13940, 13942, 13943) THEN 'BA'
					WHEN @idresidence01gen10  in (13939, 13941, 13944) THEN 'FG'
					ELSE geo_country.province 
				end,
				@a19codiceComune01gen10  = geo_city_agency.value
				FROM geo_city
				LEFT OUTER JOIN geo_country
					on geo_city.idcountry = geo_country.idcountry
				LEFT OUTER JOIN geo_city_agency 
					on geo_city.idcity=geo_city_agency.idcity and geo_city_agency.idagency = 1 and geo_city_agency.idcode = 1
				where geo_city.idcity = @idresidence01gen10 
		end
	
		-- Inizio Sezione di inserimento nella tabella di output delle righe inerenti la testata del quadro G
		--1 Tipo record
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '01', 'G')
		--2 Codice fiscale del soggetto dichiarante
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '02', @codfiscEnte)
		--3 Progressivo comunicazione
		INSERT INTO #recordg (progr, quadro, riga, colonna, intero)  VALUES(@progrComunic, 'HRG', 1, '03', @progrComunic)
		--6 Codice fiscale del percipiente
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'HRG', 1, '06', @a1cf)
		-- Fine Sezione di inserimento nella tabella di output delle righe inerenti la testata del quadro G

		-- Inizio Sezione di inserimento nella tabella di output delle righe inerenti alla sezione A del quadro G
	--PARTE A
	--Dati relativi al dipendente, pensionato o altro percettore delle somme
		--DA001001 Codice fiscale
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '001', @a1cf)
		--DA001002 Cognome
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '002', @a2cognome)
		--DA001003 Nome
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '003', @a3nome)
		--DA001004 Sesso
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '004', @a4gender)
		--DA001005 Data di nascita
		INSERT INTO #recordg (progr, quadro, riga, colonna, data)    VALUES(@progrComunic, 'DA', 1, '005', @a5birthdate)
		--DA001006 Comune (o Stato estero) di nascita
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '006', @a6comuneostatonascita)
		--DA001007 Provincia di nascita (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '007', @a7provNascita)
		--DA001012 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '012', @a12comune01gen09 )
		--DA001013 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '013', @a13prov01gen09 )
		--DA001014 Codice comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '014', @a14codicecomune01gen09 )
		--DA001015 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '015', @a15comune31dic09 )
		--DA001016 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '016', @a16prov31dic09 )
		--DA001017 Comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '017', @a17comune01gen10 )
		--DA001018 Provincia (sigla)
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '018', @a18prov01gen10 )
		--DA001019 Codice comune
		INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DA', 1, '019', @a19codiceComune01gen10 )
		-- Fine Sezione di inserimento nella tabella di output delle righe inerenti alla sezione A del quadro G
	
	--PARTE B - Dati fiscali
	--Dati per la eventuale compilazione della dichiarazione dei redditi
	-----------------------------------------
	-- Riempimento Quadro B - Dati Fiscali --
	-----------------------------------------
		if @tipo='C'
		begin
	--inizio modulo cococo
			delete #cedolini
			-- Riempimento della tabella dei cedolini.
			-- Vengono inseriti tutti i cedolini trasmessi associati ai contratti del percipiente dell'anno dei redditi.
			-- Di questi cedolini si seleziona il movimento di spesa che li contabilizza, la data di trasmissione,
			-- la data di inizio e fine ed il contratto di appartenenza.
			insert into #cedolini
			(idcedolino, idexp, idcon, datacompetenza, startpayroll, stoppayroll)
			SELECT
				expensepayroll.idpayroll, expensepayroll.idexp, payroll.idcon,
				transmissiondate, payroll.start, payroll.stop
			from expensepayroll
			join payroll on payroll.idpayroll=expensepayroll.idpayroll
			join expenselink ON expenselink.idparent = expensepayroll.idexp
			join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
			join payment on payment.kpay=expenselast.kpay
			join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
			join #contratti on payroll.idcon=#contratti.idcon
			where fiscalyear=@annoredditi
			order by payroll.stop
	
			-- Calcolo dei giorni lavorati
			-- Si settano tutti i giorni a NON LAVORATI
			update #workdays set worked='N'
			-- Si settano tutti i giorni rientranti nella durata dei cedolini a LAVORATI
			update #workdays set worked='S' where exists
				(SELECT * from #cedolini
				JOIN #contratti
					ON #contratti.idcon = #cedolini.idcon
				WHERE #workdays.giorno BETWEEN #cedolini.startpayroll AND #cedolini.stoppayroll
					AND #contratti.certificatekind = 'U'
					AND NOT EXISTS
						(SELECT * FROM servicetaxview
						WHERE servicetaxview.idser = #contratti.idser
							AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
				)

			-- Si settano tutti i giorni rientranti nella durata di CUD cartacei a LAVORATI
			update #workdays set worked='S' where exists
				(SELECT * from exhibitedcud 
					join #contratti on exhibitedcud.idcon=#contratti.idcon
					where exhibitedcud.idlinkedcon is null and --controllo preciso ma superfluo
						 #workdays.giorno between exhibitedcud.start and exhibitedcud.stop
						AND exhibitedcud.fiscalyear = @annoredditi
				)
	
	
	--fine riempimento dei contratti e dei cedolini

-- J.T.R. variabile commentata, non serve più, viene sostituita da dei JOIN con la tabella #contratti
--			declare @idpayroll int
--			SELECT  @idpayroll=idpayroll from #modulocococo where idcon=@chiave
			
			-- Calcolo degli oneri sostenuti in altri contratti
			-- Essi sono dati dalla somma della differenza tra l'imponibile previdenziale e l'imponibile fiscale lordo
			-- dei CUD associati ai contratti non divenuti CUD per altri
			declare @onerisostenutiinaltricontratti dec(19,2)
			SET @onerisostenutiinaltricontratti =
			ISNULL(
				(SELECT 
					ISNULL(SUM(exhibitedcud.taxablepension),0) -
					ISNULL(SUM(exhibitedcud.taxablegross),0)
				FROM exhibitedcud 
				JOIN #contratti
					ON #contratti.idcon = exhibitedcud.idcon
				WHERE #contratti.padre IS NULL
					AND #contratti.certificatekind = 'U'
					AND exhibitedcud.fiscalyear = @annoredditi)
			,0)

			-- Calcolo dei redditi ai quali si possono applicare le deduzioni art. 11 e imposta lorda
			-- Esso è pari alla somma degli imponibili lordi delle ritenute fiscali nazionali associate ai
			-- contratti del percipiente. I contratti da considerare sono solo quelli associati alla certificazione
			-- CUD che non sono diventati a loro volta CUD per altri contratti. Si scartano le ritenute con codice
			-- 08_IRPEF_FOC e 07_IRPEF_FO in quanto sono ritenute applicate a stranieri che non rientrano in questo calcolo
			-- L'imposta lorda è pari alla somma delle ritenute (il filtro è quello descritto precedentemente), tant'è che la
			-- query è la medesima
			SELECT @zb1RedditoDedArt11 = ISNULL(SUM(taxablegross),0),
				@zb33ImpostaLorda  = ISNULL(SUM(employtaxgross),0)
			FROM payrolltax cr
			JOIN #contratti
				ON #contratti.idpayroll = cr.idpayroll
			JOIN tax
				ON cr.taxcode = tax.taxcode
			WHERE taxkind = 1
				AND geoappliance IS NULL
				AND #contratti.padre IS NULL
				AND #contratti.certificatekind = 'U'
				AND tax.taxref NOT IN ('08_IRPEF_FOC','07_IRPEF_FO')

			-- Calcolo della detrazione per familiari a carico
			-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
			-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
			-- Si considera ovviamente la sola detrazione con codice 28 che si riferisce ai familiari
			SET @zb34detrazionipercarichifamiliari  =
			ISNULL(
				(SELECT SUM(payrollabatement.curramount)
				FROM payrollabatement
				JOIN #contratti
					ON #contratti.idpayroll = payrollabatement.idpayroll
				WHERE idabatement = 28
					AND #contratti.padre IS NULL
					AND #contratti.certificatekind = 'U')
			,0)

			-- Calcolo della detrazione per reddito
			-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
			-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
			-- Si considera ovviamente la sola detrazione con codice 29 che si riferisce al reddito
			SET @zb39detrazioniperreddito  =
			ISNULL(
				(SELECT SUM(payrollabatement.curramount)
				FROM payrollabatement
				JOIN #contratti
					ON #contratti.idpayroll = payrollabatement.idpayroll
				WHERE idabatement = 29
					AND #contratti.padre IS NULL
					AND #contratti.certificatekind = 'U')
			,0)

			-- Calcolo della detrazione per oneri
			-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
			-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
			-- Si considerano tutte le detrazioni che sono marcate come oneri detraibili (flagabatableexpense = 'S')
			SET @zb40detrazioniperoneri  =
			ISNULL(
				(SELECT SUM(payrollabatement.curramount)
				FROM payrollabatement
				JOIN #contratti
					ON #contratti.idpayroll = payrollabatement.idpayroll
				JOIN abatement
					ON abatement.idabatement = payrollabatement.idabatement
				WHERE abatement.flagabatableexpense = 'S'
					AND #contratti.padre IS NULL
					AND #contratti.certificatekind = 'U')
			,0)
                        
                        -- Totale detrazioni = 30 + 34 + 35 + 36 = 30 + 34 + 35 + 0. 
			SET @zb45totaledetrazioni  = @zb34detrazionipercarichifamiliari  + @zb39detrazioniperreddito  + @zb40detrazioniperoneri 
			-- Calcolo della deduzione art. 10
			-- Essa è pari alla somma tra gli oneri sostenuti in altri contratti  e la somma delle deduzioni
			-- applicate sui cedolini associati ai contratti non divenuti CUD per altri e la cui prestazione
			-- ricade nella cetificazione CUD e che non abbiamo come ritenute fiscali nazionali quelle con codice
			-- 08_IRPEF_FOC o 07_IRPEF_FO
			-- Si considerano tutte le deduzioni associate alle ritenute fiscali locali
			SET @zb58deductionart10  =
			@onerisostenutiinaltricontratti +
			ISNULL(
				(SELECT SUM(cr.deduction)
				FROM payrolltax cr 
				JOIN #contratti
					ON #contratti.idpayroll = cr.idpayroll
				JOIN tax
					ON cr.taxcode=tax.taxcode
				WHERE taxkind = 1
					AND geoappliance = 'R'
				AND #contratti.padre IS NULL
				AND #contratti.certificatekind = 'U'
				AND NOT EXISTS
					(SELECT * FROM servicetaxview
					WHERE servicetaxview.idser = #contratti.idser
						AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
				)
			,0) -- Vengono prese le deduzioni associate alla sola ritenuta fiscale con applicazione regionale
			-- si poteva anche scegliere quella comunale ma ce ne sono due (acconto e saldo) e sarebbe stato + oneroso scegliere
	
			-- Calcolo della ritenute IRPEF
			-- Si considera la somma delle ritenute nette fiscali nazionali con codice differente
			-- da 08_IRPEF_FOC e 07_IRPEF_FO
			-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
			-- non pagano IRPEF e quindi il loro contributo è nullo
			SET @zb5ritIRPEF =
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				JOIN tax ON expensetaxofficial.taxcode = tax.taxcode
				WHERE taxkind = 1 AND geoappliance IS NULL
                                        and expensetaxofficial.stop is null
					AND tax.taxref NOT IN ('08_IRPEF_FOC','07_IRPEF_FO'))
			,0)
	
			-- Al primo calcolo parziale, si somma anche la ritenuta IRPEF applicata nei CUD cartacei associati ai contratti
			SET @zb5ritIRPEF =
			@zb5ritIRPEF +
			ISNULL(
				(SELECT SUM(exhibitedcud.irpefapplied)
				FROM exhibitedcud
				JOIN #contratti
					ON #contratti.idcon = exhibitedcud.idcon
				WHERE fiscalyear = @annoredditi
					AND exhibitedcud.idlinkedcon IS NULL)
				--and not exists (SELECT * from license where ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy)
			,0)
	
			-- Calcolo inutile, si lascia se si dovesse in futuro produrre il record SS
			set @SS002001 = isnull(@SS002001,0) + isnull(@zb5ritIRPEF,0)

			-- Calcolo della addizionale regionale all'IRPEF
			-- Si considera la somma delle ritenute nette fiscali regionali dei cedolini associati a contratti
			-- che non hanno ritenute con codice uguale a 08_IRPEF_FOC e 07_IRPEF_FO
			-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
			-- non pagano le addizionali regionali e quindi il loro contributo è nullo
			SET @zb6add_reg =
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN #contratti
					ON #contratti.idcon = #cedolini.idcon
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				JOIN tax
					ON expensetaxofficial.taxcode=tax.taxcode
				WHERE taxkind = 1 AND geoappliance = 'R'
                                        and expensetaxofficial.stop is null
					AND NOT EXISTS
					(SELECT * FROM servicetaxview
					WHERE servicetaxview.idser = #contratti.idser
						AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
				)
			,0) 

			-- Al primo calcolo parziale, si somma anche l'addizionale regionale applicata nei CUD cartacei associati ai contratti
			SET @zb6add_reg =
			@zb6add_reg +
			ISNULL(
				(SELECT SUM(exhibitedcud.regionaltaxapplied)
				FROM exhibitedcud
				JOIN #contratti
					ON #contratti.idcon = exhibitedcud.idcon
				WHERE fiscalyear = @annoredditi
					AND exhibitedcud.idlinkedcon IS NULL)
			,0)

			-- Calcolo dell'acconto all'addizionale comunale all'IRPEF
			-- Si considera la somma degli acconti specificati all'interno dei contratti
			SET @zb10addcomacconto09 =
			ISNULL(
				(SELECT SUM(citytax_account)
				FROM parasubcontractyear
				WHERE idcon IN (SELECT DISTINCT idcon FROM #contratti)
					AND ayear = @annoredditi)
			,0)

			-- Al primo calcolo parziale, si somma anche l'acconto all'addizionale comunale applicata nei CUD
			-- cartacei associati ai contratti
			SET @zb10addcomacconto09 =
			@zb10addcomacconto09 +
			ISNULL(
				(SELECT SUM(exhibitedcud.citytax_account)
				FROM exhibitedcud
				JOIN #contratti
					ON #contratti.idcon = exhibitedcud.idcon
				WHERE fiscalyear = @annoredditi
				AND exhibitedcud.idlinkedcon IS NULL)
			,0)

			-- Calcolo della addizionale comunale all'IRPEF
			-- Si considera la somma delle ritenute nette fiscali comunali con codice pari a 05_ADDCOMU
			-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
			-- non pagano le addizionali regionali e quindi il loro contributo è nullo
			SET @zb11addcomsaldo09 =
			ISNULL(
				(SELECT SUM(employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				JOIN tax
					ON expensetaxofficial.taxcode=tax.taxcode
				WHERE tax.taxref = '05_ADDCOMU' and expensetaxofficial.stop is null)
			,0)

			-- Al primo calcolo parziale, si somma anche l'addizionale comunale applicata nei CUD cartacei associati ai contratti
			SET @zb11addcomsaldo09 =
			@zb11addcomsaldo09 +
			ISNULL(
				(SELECT SUM(exhibitedcud.citytaxapplied)
				FROM exhibitedcud
				JOIN #contratti
					ON #contratti.idcon = exhibitedcud.idcon
				WHERE fiscalyear = @annoredditi
					AND exhibitedcud.idlinkedcon IS NULL)
			,0)

			-- Il saldo dell'addizionale comunale è pari alla differenza tra addizionale comunale e acconto alla stessa
			SELECT @zb11addcomsaldo09  = @zb11addcomsaldo09 - @zb10addcomacconto09   
	
			-- Se il saldo è negativo si valorizza il solo campo inerente all'acconto impostando a NULL il campo del saldo
			-- altrimenti si valorizza il campo del saldo impostando a NULL il campo dell'acconto
			if @zb11addcomsaldo09 < 0
			begin
				set @zb10addcomacconto09 = @zb10addcomacconto09 + @zb11addcomsaldo09
				set @zb11addcomsaldo09 = null
			end
			else
			begin
				if @zb10addcomacconto09 < 0
				begin
					set @zb11addcomsaldo09 = @zb11addcomsaldo09 + @zb10addcomacconto09
					set @zb10addcomacconto09 = null
				end
			end
	
			-- Calcolo inutile, si lascia se si dovesse in futuro produrre il record SS
			set @SS002009 = isnull(@SS002009,0) + isnull(@zb10addcomacconto09, 0)
	
			-- Calcolo dell'acconto per l'anno della dichiarazione (quello in corso)
			-- Si considera in tale calcolo i soli contratti presenti sia nell'anno dei redditi che in quello della dichiarazione
			SET @zb13addcomacconto10 =
			ISNULL(
				(SELECT SUM(citytax_account)
				FROM parasubcontractyear
				WHERE idcon IN (SELECT DISTINCT idcon FROM #contratti)
					AND ayear = @annodichiarazione)
			,0)
	
			-- Calcolo della prima rata IRPEF da CAF
			DECLARE @tr_primaratacaf int
			SELECT @tr_primaratacaf = taxcode FROM tax WHERE taxref = '07_IRPEF_R1'
	
			-- La prima rata è data dalla somma della ritenute netta associata ai cedolini con codice 07_IRPEF_R1
			SET @zb21primaratairpef_caf = 
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE taxcode = @tr_primaratacaf and expensetaxofficial.stop is null )
			,0)

			-- Calcolo della seconda rata IRPEF da CAF
			DECLARE @tr_secondaratacaf int
			SELECT @tr_secondaratacaf = taxcode FROM tax WHERE taxref = '07_IRPEF_R2'
	
			-- La seconda rata è data dalla somma della ritenute netta associata ai cedolini con codice 07_IRPEF_R2
			SET @zb22secondaratairpef_caf = 
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE taxcode = @tr_secondaratacaf and expensetaxofficial.stop is null)
			,0)
	
			-- Calcolo della maggiore ritenuta (sempre impostato a zero)
			SELECT @zb63maggioreritenuta  = 0
					--CASE WHEN applybrackets = 'N' THEN 0 ELSE null end 
	--					from parasubcontractyear where idcon=@chiave and ayear=@annoredditi
	
			-- Conteggio dei giorni lavorati
			SELECT @zb3workingdays = count(*) from #workdays where worked='S'

			-- Se i giorni lavorati superano l'anno si pongono pari al numero di giorni dell'anno
			-- non è contemplato, a quanto pare, l'anno bisestile
			IF @zb3workingdays>365 
			BEGIN
				SET @zb3workingdays=365
			END

			-- Calcolo delle detrazioni derivanti da oneri detraibili
			-- Si considerano gli oneri associati ai contratti non divenuti CUD per altri e che sono associati 
			-- alla certificazione CUD
			SET @zb59oneridetraibili  =
			ISNULL(
				(SELECT
					SUM(
						CASE
							WHEN ISNULL(abatableexpense.totalamount,0) <=
							ISNULL(abatementcode.maximal, ISNULL(abatableexpense.totalamount,0))
							THEN ISNULL(abatableexpense.totalamount,0)
							ELSE abatementcode.maximal
						END - ISNULL(abatementcode.exemption,0)
					)
				FROM abatableexpense 
				JOIN #contratti
					ON #contratti.idcon = abatableexpense.idcon
				JOIN abatementcode
					ON abatableexpense.idabatement = abatementcode.idabatement
				WHERE abatableexpense.ayear = @annoredditi
					AND abatementcode.ayear=@annoredditi
					AND #contratti.padre IS NULL
					AND #contratti.certificatekind = 'U')
			,0)

			-- Azzeramento delle prestazioni
			DELETE FROM #ser

			-- Inserimento delle prestazioni associate ai contratti che non sono divenuti CUD per altri
			INSERT INTO #ser (idser, codeser)
			SELECT DISTINCT parasubcontract.idser, service.codeser
			FROM service
			JOIN parasubcontract
				ON service.idser = parasubcontract.idser
			JOIN #contratti
				ON #contratti.idcon = parasubcontract.idcon
			WHERE #contratti.padre IS NULL
	
			-- Codice ritenute per stranieri in convenzione
			DECLARE @tax_convenzione int
			SET @tax_convenzione = NULL
	
			SELECT @tax_convenzione = taxcode FROM tax WHERE taxref = '07_IRPEF_FC'

			-- Calcolo del flag straniero_conv	
			DECLARE @straniero_conv char(1)
			-- Si considera uno straniero in convenzione se esiste almeno una prestazione legata al percipiente
			-- che ha associata la ritenuta con codice 07_IRPEF_FC
			SET @straniero_conv =
			CASE
				WHEN
				(SELECT COUNT(*)
				FROM #ser
				JOIN servicetax
					ON servicetax.idser = #ser.idser
				WHERE servicetax.taxcode = @tax_convenzione) = 0
				THEN 'N'
				ELSE 'S'
			END

			-- Questa parte di codice viene eseguita solamente se il percipiente ha sostenuto 
			-- prestazioni legate alla cerficazione CUD
			IF
			(SELECT COUNT(*)
			FROM #ser
			JOIN service
				ON service.idser = #ser.idser
			WHERE service.certificatekind = 'U') > 0
			BEGIN
				-- Questa parte di codice viene eseguita solamente se il percipiente NON è uno straniero in convenzione
				IF (@straniero_conv = 'N')
				BEGIN
					-- Riempimento dei dati fiscali (sezione B del quadro G)
					--DB001001 Redditi per i quali è possibile fruire della deduzione di cui all'art. 11 del TUIR
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '001', @zb1RedditoDedArt11)
					--DB001002 Redditi per i quali è possibile fruire della sola deduzione di cui all'art.11, c. 1 del TUIR
					-- Il campo seguente viene posto a zero in quanto non riusciamo a distinguere tali prestazioni e, quindi a valorizzarlo correttamente
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '002', 0)
					--DB001003 Numero di giorni per i quali spettano le deduzioni di cui all'art. 11 commi 2 e 3 del TUIR - LAVORO DIPENDENTE
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '003', @zb3workingdays)
					--DB001005 Ritenute Irpef
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '005', @zb5ritIRPEF)
					--DB001006 Addizionale regionale all'Irpef
					--	if isnull(@codeser,'') not in ('05_COOSTRA', '07_BRS_STN')
					--ho commentato in quanto quelle due prestazioni non hanno addizionali regionali e quindi l'if è inutile.
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '006', @zb6add_reg)
					--DB001010 Addizionale comunale all'Irpef - Acconto @annodichiarazione
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '010', @zb10addcomacconto09)
					--DB001011 Addizionale comunale all'Irpef - Saldo @annodichiarazione
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '011', @zb11addcomsaldo09)
					--DB001013 Addizionale comunale all'Irpef - Acconto 2010
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '013', @zb13addcomacconto10)
					--DB001021 Prima Rata IRPEF da C.A.F.
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '021', @zb21primaratairpef_caf)
					--DB001022 Seconda Rata IRPEF  da C.A.F.
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '022', @zb22secondaratairpef_caf)
					--DB001033 Imposta lorda
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '033', @zb33ImpostaLorda )
					--DB001034 Detrazioni per carichi familiari
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '034', @zb34detrazionipercarichifamiliari )
					--DB001039 Detrazioni per reddito
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '039', @zb39detrazioniperreddito )
					--DB001040 Detrazioni per oneri
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '040', @zb40detrazioniperoneri )
					--DB001045 Totale Detrazioni 
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '045', @zb45totaledetrazioni )
					--DB001058 Totale oneri sostenuti esclusi dai redditi indicati nei punti 1 e 2
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '058', @zb58deductionart10 )
					--DB001059 Totale oneri per i quali è prevista la detrazione d'imposta
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '059', @zb59oneridetraibili )
					--DB001063 Applicazione maggiore ritenuta
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '063', @zb63maggioreritenuta )

					-- Nota AL: Tale nota viene valorizzata solo se sono state pagate addizionali (regionali o comunali)
					IF (@zb6add_reg <> 0) OR (@zb10addcomacconto09 <> 0) OR (@zb11addcomsaldo09 <> 0)
					BEGIN
						--DBXXX248 Questa annotazione è una costante infatti riteniamo sempre le addizionali a fine anno in fase di conguaglio.
						--DB001248 Nota AL
						INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '248', 'AL')
						--DB002248 Testo Nota AL
						INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 2, '248',
							'Le addizionali comunali e regionali sono state totalmente trattenute')
					END
	
					SELECT @zb50altriredditi=0

					-- Calcolo del reddito conguagliato
					-- Esso è pari alla somma degli imponibili fiscali dei CUD cartacei associati ai contratti
					SET @zb73totaleredditiconguagliato  =
					ISNULL(
						(SELECT SUM(taxablegross)
						FROM exhibitedcud
						JOIN #contratti
							ON #contratti.idcon = exhibitedcud.idcon
						WHERE fiscalyear = @annoredditi 
							AND NOT EXISTS (SELECT * FROM license where ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy))
					,0)
	
					--DB001073 Totale redditi conguagliato già compreso nel punto 1
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale)
					VALUES(@progrComunic, 'DB', 1, '073', @zb73totaleredditiconguagliato )--Totale redditi conguagliato già compreso nel punto 1
				END
			END

			DECLARE @tax_irpefcaf int
			SELECT @tax_irpefcaf = taxcode FROM tax WHERE taxref = '07_IRPEF_CAF'

			DECLARE @refund_irpefcaf decimal(19,2)

			-- Calcolo dell'IRPEF restituita al percipiente dalla dichiarazione del CAF
			-- Essa è pari alla somma delle ritenute nette con codice 07_IRPEF_CAF
			-- ed importo negativo
			SET @refund_irpefcaf = 
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE expensetaxofficial.taxcode = @tax_irpefcaf and expensetaxofficial.stop is null
				HAVING SUM(expensetaxofficial.employtax) < 0 )
			,0)

			DECLARE @tax_addregcaf int
			SELECT @tax_addregcaf = taxcode FROM tax WHERE taxref = '07_ADDREGCAF'

			DECLARE @refund_addregcaf decimal(19,2)

			-- Calcolo dell'addizionale regionale all'IRPEF restituita al percipiente dalla dichiarazione del CAF
			-- Essa è pari alla somma delle ritenute nette con codice 07_ADDREGCAF
			-- ed importo negativo

			SET @refund_addregcaf =
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE expensetaxofficial.taxcode = @tax_addregcaf and expensetaxofficial.stop is null
				HAVING SUM(expensetaxofficial.employtax) < 0 )
			,0)

			DECLARE @tax_addcomcaf int
			SELECT @tax_addcomcaf = taxcode FROM tax WHERE taxref = '07_ADDCOMCAF'

			DECLARE @refund_addcomcaf decimal(19,2)

			-- Calcolo dell'addizionale regionale all'IRPEF restituita al percipiente dalla dichiarazione del CAF
			-- Essa è pari alla somma delle ritenute nette con codice 07_ADDCOMCAF
			-- ed importo negativo
			SET @refund_addcomcaf =
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM #cedolini
				JOIN expenselink
					ON #cedolini.idexp = expenselink.idparent
				JOIN expensetaxofficial
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE expensetaxofficial.taxcode = @tax_addcomcaf and expensetaxofficial.stop is null
				HAVING SUM(expensetaxofficial.employtax) < 0 )
			,0)

			-- DBXXX249 [Nota AM] (Nota inerente i rimborsi da C.A.F.)
			IF ((@refund_irpefcaf < 0) OR (@refund_addregcaf < 0) OR (@refund_addcomcaf < 0))
			BEGIN
				-- DB001249
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '249', 'AM')
				DECLARE @j int
				SET @j = 2

				IF (@refund_irpefcaf < 0)
				BEGIN
					-- DB002249
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @j, '249',
						'Credito IRPEF rimborsato ' + CONVERT(varchar(16), -@refund_irpefcaf))
					SET @j = @j + 1
				END

				IF (@refund_addregcaf < 0)
				BEGIN
					-- DB002249
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @j, '249',
						'Credito Addizionale Regionale rimborsato ' + CONVERT(varchar(16), -@refund_addregcaf))
					SET @j = @j + 1
				END

				IF (@refund_addcomcaf < 0)
				BEGIN
					-- DB002249
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @j, '249',
						'Credito Addizionale Comunale rimborsato ' + CONVERT(varchar(16), -@refund_addcomcaf))
					SET @j = @j + 1
				END
			END

			DECLARE @contratticondetrazioniapplicate int

			-- Variabile che conta i contratti con delle detrazioni per reddito applicate
			-- Si contano tutti i contratti che hanno il flag nottaxappliance (applica detrazioni per reddito) valorizzato a I (ossia applica)
			SET @contratticondetrazioniapplicate =
			(SELECT COUNT(*) 
			FROM parasubcontractyear
			JOIN #contratti
				ON #contratti.idcon = parasubcontractyear.idcon
			WHERE ayear = @annoredditi
				AND ISNULL(notaxappliance, 'I') = 'I')

			-- Blocco eseguito solo se il percipiente ha effettuato prestazioni assocaite alla certificazione CUD
			IF
			(SELECT COUNT(*)
			FROM #ser
			JOIN service
				ON service.idser = #ser.idser
			WHERE service.certificatekind = 'U') > 0
			BEGIN
				-- DBXXX250 [Nota AN] (Questa nota se presente lo è solo una volta)
				IF ((@zb3workingdays < 365) AND (@contratticondetrazioniapplicate > 0)) AND (@straniero_conv = 'N')
				BEGIN
					-- vengono create più righe in quanto il limite del campo è 100
					-- DB001250
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '250', 'AN')
					-- DB002250
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 2, '250',
						'La detrazione minima è stata ragguagliata al periodo di lavoro, il percipiente può fruire della')
					-- DB003250
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 3, '250',
						' detrazione per l''intero anno in sede di dichiarazione dei redditi, sempreché non sia stata già')
					-- DB004250
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 4, '250',
						' attribuita da un altro datore di lavoro e risulti effettivamente spettante')
				END

				-- Calcolo dell'INPS e INAIL applicate sui contratti che non sono divenuti CUD per altri contratti
				-- e di cui la prestazione associata rientra nella certificazione CUD
				DECLARE @inps_inail decimal(19,2)
				SET @inps_inail = 
				ISNULL(
					(SELECT SUM(inpsinail)
					FROM #contratti
					WHERE padre IS NULL
						AND certificatekind = 'U')
				,0)

				-- DBXXX254 [Nota AR] (Nota inerente gli oneri deducibili)
				-- Calcolo della deduzione INPS - INAIL
				DECLARE @inpsinail_altri decimal(19,2)
	
				-- Calcolo dell'INPS e dell'INAIL presenti in altri contratti
				-- è dato dalla somma delle differenze tra imponibile previdenziale e imponibile fiscale lordo
				-- dei CUD associati a contratti che non sono divenuti CUD per altri contratti meno
				-- la somma delle deduzioni derivanti da oneri deducibili presenti nei CUD associati ai contratti
				-- non divenuti CUD per altri.
				-- Attenzione sino al 2008 si procede ad una mera somma delle deduzioni derivanti da oneri deducibili
				-- dal 2009 invece si sommano gli oneri deducibili dei quali si confronta l'importo
				-- con il massimale, si sottrae la franchigia e si applica l'aliquota.
				-- Questa differenza di comportamento tra il 2008 ed il 2009 si determina perché prima
				-- nei CUD venivano inserite le deduzioni derivanti dagli oneri deducibili mentre nel corso del 2009
				-- abbiamo corretto questa gestione scrivendo tra le deduzioni del CUD l'importo dell'onere deducibile
				-- sul quale si applicherà la deduzione.
				-- N.B. Si sottraggono queste deduzioni per determinare l'INPS e l'INAIL applicate in quanto nella differenza
				-- tra i due imponibili si calcolano anche le deduzioni derivanti dagli oneri deducibili
				SET @inpsinail_altri =
				ISNULL(
					(SELECT ISNULL(SUM(E.taxablepension),0) - ISNULL(SUM(E.taxablegross),0)
					FROM exhibitedcud E
					JOIN #contratti
						ON #contratti.idcon = E.idcon
					WHERE #contratti.padre IS NULL
						AND fiscalyear = @annoredditi)
				,0) -
				CASE
					WHEN @annoredditi <= 2009 THEN
					ISNULL(
						(SELECT SUM(ED.amount)
						FROM exhibitedcuddeduction ED
						JOIN exhibitedcud E
							ON E.idexhibitedcud = ED.idexhibitedcud
							AND E.idcon = ED.idcon
						JOIN #contratti
							ON #contratti.idcon = E.idcon
						JOIN deduction D
							ON D.iddeduction = ED.iddeduction
						WHERE #contratti.padre IS NULL
							AND D.flagdeductibleexpense = 'S'
							AND E.fiscalyear = @annoredditi)
					,0)
					ELSE
					ISNULL(
						(SELECT SUM(
							(CASE
								WHEN ED.amount > ISNULL(DC.maximal, ED.amount) THEN DC.maximal
								ELSE ED.amount
							END -
							ISNULL(DC.exemption,0)) * ISNULL(DC.rate,1))
						FROM exhibitedcuddeduction ED
						JOIN exhibitedcud E
							ON E.idexhibitedcud = ED.idexhibitedcud
							AND E.idcon = ED.idcon
						JOIN #contratti
							ON #contratti.idcon = E.idcon
						JOIN deduction D
							ON D.iddeduction = ED.iddeduction
						JOIN deductioncode DC
							ON D.iddeduction = DC.iddeduction
							AND DC.ayear = E.fiscalyear
						WHERE #contratti.padre IS NULL
							AND D.flagdeductibleexpense = 'S'
							AND E.fiscalyear = @annoredditi)
					,0)
				END
	
				DECLARE @onere_inpsinail decimal(19,2)
				-- La var. @inps_inail è calcolata sopra e rappresenta il totale INPS e INAIL versati
				-- a questo importo bisogna sommare le INPS e INAIL calcolate nei CUD associati al contratto
				SET @onere_inpsinail = @inps_inail + @inpsinail_altri
	
				-- Inserimento della nota AR, essa si inserisce se ci sono delle deduzioni derivanti da oneri deducibili
				-- sui contratti del percipiente oppure se è stata applicata la deduzione di INPS e INAIL e in ogni caso
				-- vale solo per i percipienti che non sono stranieri in convenzione
				-- La nota AR quindi deve dare un analitico di tutte le deduzioni applicate.
				IF ((
					(SELECT COUNT(*)
					FROM payrolldeduction
					JOIN payroll
						ON payroll.idpayroll = payrolldeduction.idpayroll
					JOIN #contratti
						ON #contratti.idcon = payroll.idcon
					JOIN deduction
						ON deduction.iddeduction = payrolldeduction.iddeduction
					WHERE #contratti.padre IS NULL
						AND payroll.fiscalyear = @annoredditi
						AND payroll.flagbalance = 'S'
						AND deduction.flagdeductibleexpense = 'S') > 0
				)
				OR
				(@onere_inpsinail > 0))
				AND (@straniero_conv = 'N')
				BEGIN
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
					VALUES(@progrComunic, 'DB', 1, '254', 'AR')
	
					SET @zb254_ar = 
					(SELECT ISNULL(deductioncode.code,'__') + ' ' + deduction.description
					FROM deductioncode
					JOIN deduction
						ON deduction.iddeduction = deductioncode.iddeduction
					WHERE deduction.iddeduction = 6
						AND deductioncode.ayear = @annoredditi) + ' ' +
					CONVERT(varchar(16), @onere_inpsinail)
	
					DECLARE @offset_ar int
					SET @offset_ar = 1
	
					IF (@onere_inpsinail > 0)
					BEGIN
						INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
						VALUES(@progrComunic, 'DB', 2, '254', @zb254_ar)
						SET @offset_ar = @offset_ar + 1
					END
	
					DECLARE @iddeduction int
					DECLARE @descdeduction varchar(200) -- Variabile di lunghezza pari al campo della tabella deduction
					DECLARE @ded_amount decimal(19,2)
	
					DECLARE @k int
					SET @k = 1
					DECLARE #deduction_crs INSENSITIVE CURSOR FOR
					SELECT
						deduction.iddeduction, deduction.description,
						SUM(payrolldeduction.curramount)
					FROM payrolldeduction
					JOIN payroll
						ON payroll.idpayroll = payrolldeduction.idpayroll
					JOIN #contratti
						ON #contratti.idcon = payroll.idcon
					JOIN deduction
						ON deduction.iddeduction = payrolldeduction.iddeduction
					JOIN deductioncode
						ON deduction.iddeduction = deductioncode.iddeduction
						AND payroll.fiscalyear = deductioncode.ayear
					WHERE #contratti.padre IS NULL
						AND payroll.fiscalyear = @annoredditi
						AND payroll.flagbalance = 'S'
						AND deduction.flagdeductibleexpense = 'S'
					GROUP BY deduction.iddeduction, deduction.description

					FOR READ ONLY
					OPEN #deduction_crs
					
					FETCH NEXT FROM #deduction_crs INTO @iddeduction, @descdeduction, @ded_amount
		
					WHILE (@@FETCH_STATUS = 0)
					BEGIN
						DECLARE @currded varchar(100)

						WHILE LEN(@descdeduction) > 90
						BEGIN
							SET @currded = SUBSTRING(@descdeduction, 1, 90)

							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', @offset_ar + @k, '254', @currded)
	
							SET @k = @k + 1
							SET @descdeduction = SUBSTRING(@descdeduction, 91, 570)
						END

						IF LEN(@descdeduction) > 74
						BEGIN
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', @offset_ar + @k, '254', @descdeduction)
							SET @k = @k + 1
							SET @descdeduction=''
						END
	
						SET @zb254_ar = @descdeduction + ' ' + CONVERT(varchar(16), @ded_amount)

						INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
						VALUES(@progrComunic, 'DB', @offset_ar + @k, '254', @zb254_ar)

						SET @k = @k + 1

						FETCH NEXT FROM #deduction_crs INTO @iddeduction, @descdeduction, @ded_amount
					END
	
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
					VALUES(@progrComunic, 'DB', @offset_ar + @k, '254', 'Tali importi non vanno riportati nella dichiarazione dei redditi')
	
					CLOSE #deduction_crs
					DEALLOCATE #deduction_crs
				END
			END

			-- Gestione delle detrazioni e note associate
			DECLARE @idabatement int
			DECLARE @codeabatement varchar(20)
			DECLARE @descrabatement varchar(50)
			DECLARE @gross_amount decimal(19,2)
			DECLARE @applied_amount decimal(19,2)
			DECLARE @abatementrate decimal(19,6)
			DECLARE @epsilon decimal(19,2)
			SET @epsilon = 0.01

			DECLARE @atcount int
			DECLARE @azcount int
			SET @atcount = 0
			SET @azcount = 0

			-- Si entra nel blocco solo se ci sono oneri detraibili presenti nel contratto e il percipiente
			-- non è uno straniero in convenzione
			-- DBXXX222 [Nota AT] e DBXXX248 [Nota AZ] (entrambe le note riguardano gli oneri detraibili)
			IF (SELECT COUNT(*) FROM abatableexpense WHERE idcon IN (SELECT idcon FROM #contratti WHERE padre IS NULL)) > 0
			AND (@straniero_conv = 'N')
			BEGIN
				-- Si definisce un cursore su tutte le detrazioni derivanti da oneri presenti nei contratti
				-- che non sono divenuti CUD per altri
				DECLARE #abatable_crs INSENSITIVE CURSOR FOR
				SELECT
					abatableexpense.idabatement, ISNULL(abatementcode.code, 'ND'), abatement.description,
					SUM(abatableexpense.totalamount) +
					ISNULL(
						(SELECT SUM(ECA.amount)
						FROM exhibitedcudabatement ECA
						JOIN exhibitedcud EC
							ON EC.idexhibitedcud = ECA.idexhibitedcud
							AND EC.idcon = ECA.idcon
						JOIN #contratti
							ON #contratti.idcon = EC.idcon
						WHERE ECA.idabatement = abatableexpense.idabatement
							AND #contratti.padre IS NULL
							AND EC.fiscalyear = @annoredditi)
					,0),
					ISNULL(
						(SELECT SUM(payrollabatement.curramount)
						FROM payrollabatement
						JOIN payroll
							ON payroll.idpayroll = payrollabatement.idpayroll
						JOIN #contratti
							ON #contratti.idcon = payroll.idcon
						WHERE payrollabatement.idabatement = abatableexpense.idabatement
							AND payroll.fiscalyear = @annoredditi
							AND payroll.flagbalance = 'S'
							AND #contratti.padre IS NULL)
					,0),
					abatementcode.rate
				FROM abatableexpense
				JOIN #contratti
					ON #contratti.idcon = abatableexpense.idcon
				JOIN abatementcode
					ON abatableexpense.idabatement = abatementcode.idabatement
					AND abatableexpense.ayear = abatementcode.ayear
				JOIN abatement
					ON abatement.idabatement = abatableexpense.idabatement
				WHERE abatableexpense.ayear = @annoredditi
					AND abatement.flagabatableexpense = 'S'
					AND #contratti.padre IS NULL
				GROUP BY abatableexpense.idabatement, ISNULL(abatementcode.code, 'ND'),
					abatement.description, abatementcode.rate

				FOR READ ONLY
				OPEN #abatable_crs

				FETCH NEXT FROM #abatable_crs INTO @idabatement, @codeabatement, @descrabatement,
				@gross_amount, @applied_amount, @abatementrate

				-- Per ogni detrazione si verifica a quanto ammonta l'aliquota applicata e se è del 19% confluirà
				-- nella nota AT se è al 20% nella nota AZ
				WHILE (@@FETCH_STATUS = 0)
				BEGIN
					IF (@abatementrate BETWEEN (0.19 - @epsilon) AND (0.19 + @epsilon))
					BEGIN
						IF (@atcount = 0)
						BEGIN
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', 1, '256', 'AT')
							SET @atcount = @atcount + 1
						END

						-- Vengono inseriti gli oneri detraibili solo se hanno portato ad una effettiva detrazione
						-- l'unica eccezione si verifica nel caso delle spese sanitarie ove anche se non viene applicata
						-- una detrazione bisogna comunque comunicarle con una descrizione apposita
						IF ((@applied_amount > 0) OR (@idabatement = 1))
						BEGIN

							SET @zb256_at = @codeabatement + ' ' +
							@descrabatement + ' ' + CONVERT(varchar(16), @gross_amount) +
							CASE
								WHEN ((@idabatement = 1) AND (@applied_amount = 0))
								THEN ' importo inferiore alla franchigia'
								ELSE ''
							END

                            SET @atcount = @atcount + 1
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', @atcount, '256', @zb256_at)

							
						END
					END
					ELSE
					BEGIN
						IF (@azcount = 0)
						BEGIN
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', 1, '262', 'AZ')
							SET @azcount = @azcount + 1
						END

						IF (@applied_amount > 0)
						BEGIN
							SET @zb262_az = @codeabatement + ' ' + @descrabatement + ' ' + CONVERT(varchar(16), @gross_amount)

                                                        SET @azcount = @azcount + 1
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', @atcount, '262', @zb262_az)

							
						END
					END

					FETCH NEXT FROM #abatable_crs INTO @idabatement, @codeabatement, @descrabatement,
					@gross_amount, @applied_amount, @abatementrate
				END

				CLOSE #abatable_crs
				DEALLOCATE #abatable_crs

			END

			-- Gestione delle note AI e AJ
			-- Queste note per ogni contratto o CUD cartaceo presentato devono annotare il periodo di lavoro e la tipologia
			-- di lavoro intrapresa tra il percipiente ed il datore di lavoro
			-- La nota AI vale per i soli percipienti che non sono stranieri in convenzione
			-- mentre la nota AJ deve essere specificata per gli stranieri, dove sis specifica che il reddito è risultato 
			-- esente in Italia
			DECLARE @contacud int
			SET @contacud = 1
			DECLARE @contacudconvenzione int
			SET @contacudconvenzione = 1
			DECLARE @offset_ai int
			SET @offset_ai = 2

			DECLARE @ai_inserted char(1)
			SET @ai_inserted = 'N'

			DECLARE @aj_inserted char(1)
			SET @aj_inserted = 'N'

			DECLARE @ec_taxablegross decimal(19,2)
			DECLARE @ec_start datetime
			DECLARE @ec_stop datetime
			DECLARE @ec_idlinkedcon varchar(8)

			-- Il cursore seleziona tutti i contratti la cui prestazione ricade nella certificazione CUD
			-- e tutti i CUD cartacei associati ai contratti.
			DECLARE #cud_crs INSENSITIVE CURSOR FOR
			SELECT
				#contratti.fiscaltaxablegross,
				payroll.start, payroll.stop, #contratti.idcon
			FROM #contratti
			JOIN payroll
				ON #contratti.idcon = payroll.idcon
			WHERE payroll.flagbalance = 'S'
				AND payroll.fiscalyear = @annoredditi
				AND #contratti.certificatekind = 'U'
			UNION ALL
			SELECT exhibitedcud.taxablegross, 
				exhibitedcud.start, exhibitedcud.stop, NULL
			FROM exhibitedcud
			JOIN #contratti
				ON #contratti.idcon = exhibitedcud.idcon
			WHERE exhibitedcud.idlinkedcon IS NULL
				AND exhibitedcud.fiscalyear = @annoredditi
			FOR READ ONLY

			OPEN #cud_crs
			FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon

			WHILE(@@FETCH_STATUS = 0)
			BEGIN
				DECLARE @offset_aj int
				SET @offset_aj = 0

				IF (@ec_idlinkedcon IS NOT NULL)
				AND
				(SELECT COUNT(*)
				FROM #ser
				JOIN service
					ON #ser.idser = service.idser
				WHERE service.certificatekind = 'U') > 0
				BEGIN
					IF (@straniero_conv = 'N')
					BEGIN
						-- Note dipendenti dai CUD
						SET @zb245_ai =
							'Assimilato a lavoro dipendente - Tempo det. - da ' +
							CONVERT(varchar(16), @ec_start, 105) + ' a ' +
							CONVERT(varchar(16), @ec_stop, 105) + ' Importo ' +
							CONVERT(varchar(16), @ec_taxablegross)
		
						-- DBXXX245 [Nota AI] (Questa nota è sicuramente presente almeno per il contratto principale)
						-- DB001245
						IF (@ai_inserted = 'N')
						BEGIN
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '245', 'AI')
							SET @ai_inserted = 'S'
						END
	
						INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
							VALUES(@progrComunic, 'DB', @offset_ai + @contacud, '245', @zb245_ai)
					END
				END

				-- [Nota AJ]
				IF (@ec_idlinkedcon IS NOT NULL) AND
				(@straniero_conv = 'S')
				BEGIN
					DECLARE @previdenza decimal(19,2)
					SET @previdenza =
					ISNULL(
						(SELECT taxablepension
						FROM parasubcontractsummaryview
						WHERE idcon = @ec_idlinkedcon
							AND ayear = @annoredditi)
					,0)

					SET @zb246_aj = 'Importo ' + CONVERT(varchar(16), @previdenza)

					IF (@offset_aj = 0)
					BEGIN
						-- DB001246
						IF (@aj_inserted = 'N')
						BEGIN
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '246', 'AJ')
							-- DB002246
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 2, '246',
							'Redditi totalmente o parzialmente esentati da imposizione in Italia in quanto il percipiente risiede')
							-- DB003246
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 3, '246',
							'in uno Stato Estero con cui è in vigore una convenzione per evitare le doppie imposizioni in materia')
							-- DB004246
							INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 4, '246',
							'di imposte dirette: ' + @zb246_aj)

							SET @aj_inserted = 'S'

							SET @offset_aj = 4
						END
					END

					-- DB005246
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa)
					VALUES(@progrComunic, 'DB', @offset_aj + @contacudconvenzione, '246', @zb246_aj)

					SET @contacudconvenzione = @contacudconvenzione + 1
				END

				FETCH NEXT FROM #cud_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedcon

				SET @contacud = @contacud + 1
			END
			CLOSE #cud_crs
			DEALLOCATE #cud_crs

			SET @contacud = 1

			-- Cursore che estrae tutti i CUD cartacei di un contratto
			declare @cursorecud cursor
			set @cursorecud = cursor for 
				SELECT exhibitedcud.cfotherdeputy, exhibitedcud.taxablegross, irpefapplied, 
					irpefsuspended, regionaltaxapplied, suspendedregionaltax, citytaxapplied, suspendedcitytax
				from exhibitedcud
				join #contratti on exhibitedcud.idcon = #contratti.idcon
				where exhibitedcud.fiscalyear = @annoredditi /*and idexhibitedcud not in
					(SELECT idexhibitedcud from exhibitedcud where idcon=@chiave)*/
					and not exists (SELECT * from license where ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy)
			open @cursorecud
			
			fetch next from @cursorecud 
				into @zb75cudcodfisc_XXX, @zb78cudimpfisclordo_XXX, @zb80cudirpef_XXX, 
				@zb81cudirpefsosp_XXX, @zb84cudaddreg_XXX, @zb85cudaddregsosp_XXX, @zb86cudaddcomacconto_XXX, @zb88cudaddcomsosp_XXX
			
			WHILE @@fetch_status=0 
			begin
				-- Inizio Parte inutile
	--			set @SS002001 = isnull(@SS002001,0) - isnull(@zb80cudirpef_XXX, 0)
				set @SS002002 = isnull(@SS002002,0) - isnull(@zb81cudirpefsosp_XXX, 0)
				set @SS002009 = isnull(@SS002009,0) - isnull(@zb86cudaddcomacconto_XXX, 0)
				-- Fine Parte inutile

				-- Blocco eseguito per i percipienti che non sono stranieri in convenzione
				-- e che hanno effettuato prestazioni collegate alla certificazione CUD
				IF (@straniero_conv = 'N')
				AND
				(SELECT COUNT(*)
				FROM #ser
				JOIN service
					ON service.idser = #ser.idser
				WHERE service.certificatekind = 'U') > 0
				BEGIN
					-- Riempimento di ulteriori dati fiscali
					--DBXXX075 Codice fiscale
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @contacud, '075', @zb75cudcodfisc_XXX)
					--DBXXX076 Causa - Casella 66
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '076', 6)
					--DBXXX077 Causa - Casella 67
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', @contacud, '077', 1)
					--DBXXX078 Reddito conguagliato
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '078', @zb78cudimpfisclordo_XXX)
					--DBXXX080 Ritenute
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '080', @zb80cudirpef_XXX)
					--DBXXX081 Ritenute sospese
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '081', @zb81cudirpefsosp_XXX)
					--DBXXX084 Addizionale regionale
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '084', @zb84cudaddreg_XXX)
					--DBXXX085 Addizionale regionale sospesa
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '085', @zb85cudaddregsosp_XXX)
					--DBXXX086 Addizionale comunale acconto @annodichiarazione
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '086', @zb86cudaddcomacconto_XXX)
					--DBXXX104 Addizionale comunale saldo @annodichiarazione
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '087', @zb87cudaddcomsaldo_XXX)
					--DBXXX088 Addizionale comunale sospesa
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', @contacud, '088', @zb88cudaddcomsosp_XXX)
					
					SET @contacud = @contacud + 1
				END

				FETCH NEXT FROM @cursorecud 
					INTO @zb75cudcodfisc_XXX, @zb78cudimpfisclordo_XXX, @zb80cudirpef_XXX, 
					@zb81cudirpefsosp_XXX, @zb84cudaddreg_XXX, @zb85cudaddregsosp_XXX, @zb86cudaddcomacconto_XXX, @zb88cudaddcomsosp_XXX
			end
					
			-- Gestione dei redditi assoggettati a titolo di imposta
			IF
			(SELECT COUNT(*)
			FROM #ser
			JOIN servicetax
				ON #ser.idser = servicetax.idser
			JOIN tax
				ON tax.taxcode = servicetax.taxcode
			WHERE tax.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')) > 0
			BEGIN
				DECLARE @zb99RedditoDedArt11  decimal(19,2)
				DECLARE @zb100ritIRPEF  decimal(19,2)
				DECLARE @zb101add_reg  decimal(19,2)

				-- Calcolo dei redditi ai quali si possono applicare le deduzioni art. 11
				-- Esso è pari alla somma degli imponibili lordi delle ritenute fiscali con codice 08_IRPEF_FOC o 07_IRPEF_FO
				-- associate ai contratti del percipiente. I contratti da considerare sono solo quelli associati alla certificazione
				-- CUD che non sono diventati a loro volta CUD per altri contratti. 
				SET @zb99RedditoDedArt11  = 
				ISNULL(
					(SELECT ISNULL(SUM(taxablegross),0)
					FROM payrolltax cr
					JOIN #contratti
						ON #contratti.idpayroll = cr.idpayroll
					JOIN tax
						ON cr.taxcode = tax.taxcode
					WHERE taxkind = 1
						AND geoappliance IS NULL
						AND #contratti.padre IS NULL
						AND EXISTS
							(SELECT * FROM servicetaxview
							WHERE servicetaxview.idser = #contratti.idser
							AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
				,0)

				-- Calcolo della ritenute IRPEF
				-- Si considera la somma delle ritenute nette fiscali nazionali con codice uguale
				-- a 08_IRPEF_FOC o 07_IRPEF_FO
				-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
				-- non pagano IRPEF e quindi il loro contributo è nullo più le ritenute applicate
				-- nei CUD cartacei associati a contratti
				SET @zb100ritIRPEF  =
				ISNULL(
					(SELECT SUM(expensetaxofficial.employtax)
					FROM #cedolini
					JOIN #contratti
						ON #contratti.idcon = #cedolini.idcon
					JOIN expenselink
						ON #cedolini.idexp = expenselink.idparent
					JOIN expensetaxofficial
						ON expensetaxofficial.idexp = expenselink.idchild
					JOIN tax
						ON expensetaxofficial.taxcode = tax.taxcode
					WHERE taxkind = 1 AND geoappliance IS NULL
                                                and expensetaxofficial.stop is null
						AND EXISTS
							(SELECT * FROM servicetaxview
							WHERE servicetaxview.idser = #contratti.idser
							AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
				,0) +
				ISNULL(
					(SELECT SUM(exhibitedcud.irpefapplied)
					FROM exhibitedcud
					JOIN #contratti
						ON #contratti.idcon = exhibitedcud.idcon
					WHERE fiscalyear = @annoredditi
						AND exhibitedcud.idlinkedcon IS NULL
						AND EXISTS
							(SELECT * FROM servicetaxview
							WHERE servicetaxview.idser = #contratti.idser
							AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
				,0)

				-- Calcolo della addizionale regionale all'IRPEF
				-- Si considera la somma delle ritenute nette fiscali regionali dei cedolini associati a contratti
				-- che hanno ritenute con codice uguale a 08_IRPEF_FOC e 07_IRPEF_FO
				-- Non si filtra sulla certificazione in quanto le prestazioni che non rientrano nel CUD
				-- non pagano le addizionali regionali e quindi il loro contributo è nullo più le ritenute applicate
				-- nei CUD cartacei associati a contratti
				SET @zb101add_reg  = 
				ISNULL(
					(SELECT SUM(expensetaxofficial.employtax)
					FROM #cedolini
					JOIN #contratti
						ON #contratti.idcon = #cedolini.idcon
					JOIN expenselink
						ON #cedolini.idexp = expenselink.idparent
					JOIN expensetaxofficial
						ON expensetaxofficial.idexp = expenselink.idchild
					JOIN tax
						ON expensetaxofficial.taxcode=tax.taxcode
					WHERE taxkind = 1 AND geoappliance='R'
                                                and expensetaxofficial.stop is null
						AND EXISTS
							(SELECT * FROM servicetaxview
							WHERE servicetaxview.idser = #contratti.idser
							AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
				,0) +
				ISNULL(
					(SELECT SUM(exhibitedcud.regionaltaxapplied)
					FROM exhibitedcud
					JOIN #contratti
						ON #contratti.idcon = exhibitedcud.idcon
					WHERE fiscalyear = @annoredditi
						AND exhibitedcud.idlinkedcon IS NULL
						AND EXISTS
							(SELECT * FROM servicetaxview
							WHERE servicetaxview.idser = #contratti.idser
							AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO')))
				,0)

				-- Inserimento dei dati fiscali inerenti ai valori calcolati poc'anzi
				--DB001099 Totale Redditi
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '099', @zb99RedditoDedArt11 )
				--DB001100 Ritenute Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '100', @zb100ritIRPEF )
				--DB001101 Addizionale regionale all'Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '101', @zb101add_reg )
	
				-- Solo per il modello 770 si dettagliano in altri campi i valori calcolati precedentemente
				IF (@modello = '770')
				BEGIN
					DECLARE @zb104causale_XXX int
					DECLARE @zb105dettaglio82_XXX decimal(19,2)
					DECLARE @zb106dettaglio83_XXX decimal(19,2)
					DECLARE @zb107dettaglio84_XXX decimal(19,2)

					SET @zb104causale_XXX = 2 -- Per noi vale sempre 2: La popoliamo solo x i redditi a stranieri
					SET @zb105dettaglio82_XXX = @zb99RedditoDedArt11 
					SET @zb106dettaglio83_XXX = @zb100ritIRPEF 
					SET @zb107dettaglio84_XXX = @zb101add_reg 

					--DB001104 Causale
					INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '104', @zb104causale_XXX)
					--DB001105 Totale Redditi
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '105', @zb105dettaglio82_XXX)
					--DB001106 Ritenute Irpef
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '106', @zb106dettaglio83_XXX)
					--DB001107 Addizionale regionale all'Irpef
					INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '107', @zb107dettaglio84_XXX)
				END

				SET @zb260_ax = 'Reddito ' + CONVERT(varchar(16), @zb99RedditoDedArt11 )
	
				-- DB001226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '260', 'AX')
				-- DB002226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 2, '260',
					'Assimilato a lavoro dipendente - Tempo det.')
				-- DB003226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 3, '260', @zb260_ax)
				IF (@zb100ritIRPEF  > 0)
				BEGIN
					SET @zb260_ax = 'Ritenuta IRPEF applicata ' + CONVERT(varchar(16), @zb5ritIRPEF)
					-- DB004226
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 4, '260', @zb260_ax)
				END

				IF (@zb101add_reg  > 0)
				BEGIN
					SET @zb260_ax = 'Addizionale Regionale applicata ' + CONVERT(varchar(16), @zb6add_reg)
					-- DB004226
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 5, '260', @zb260_ax)
				END

				--DBXXX104 Causale
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '104', 2)
				--DBXXX099 Redditi
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '099', @zb99RedditoDedArt11 )
				--DBXXX100 Ritenute Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '100', @zb100ritIRPEF )
				--DBXXX101 Addizionale regionale all'Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '101', @zb101add_reg )
			END
						
			-- Gestione dei familiari
			declare @birthdate smalldatetime
			declare @startapplication smalldatetime
			declare @stopapplication smalldatetime
			declare @starthandicap smalldatetime
			declare @idaffinity char
			declare @meseinizio int
			declare @mesefine int
			declare @mese int
			declare @cfFamigliare varchar(16)
			declare @detrazionePerConiugeACarico char
			declare @appliancePercentage dec(19,6)
	
			-- Svuotamento delle tabelle dei familiari
			truncate table #coniuge
			truncate table #primofiglio
			truncate table #altrofiglio
	
			declare @idfamily int
	
			-- Definizione del cursore che cicla su tutti i familiari presenti solamente sul contratto CAPOFILA,
			-- i familairi devono risultare a carico e devono avere una applicazione ricadente nel periodo dell'anno
			-- in cui sono maturati i redditi
			declare @cursFamigliare cursor
			set @cursFamigliare = cursor for 
				SELECT
					F.idfamily, F.birthdate, F.idaffinity,
					ISNULL(F.startapplication, @1gen09),
					ISNULL(F.stopapplication, @31dic09),
					ISNULL(F.starthandicap, @1gen10),
					ISNULL(F.cf, ''),
					ISNULL(F.appliancepercentage, 1)
				FROM parasubcontractfamily F
				JOIN #contratti
					ON #contratti.idcon = F.idcon
				WHERE ayear = @annoredditi
				AND #contratti.capofila = 'S'
				AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
				AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
				AND (F.flagdependent is null or F.flagdependent = 'S')
				order by idaffinity, birthdate
	
			open @cursFamigliare
			fetch next from @cursfamigliare into @idfamily, @birthdate, @idaffinity, @startapplication,
			@stopapplication, @starthandicap, @cfFamigliare, @appliancePercentage
			-- Ciclo sui familiari
			WHILE (@@fetch_status=0) 
			begin
				-- Si contano i figli maggiori dalla tabella #primofiglio
				declare @figlimaggiori int
				SELECT @figlimaggiori = count(*) from #primofiglio
				set @figlimaggiori = isnull(@figlimaggiori, 0)
	
				set @meseinizio = 1
				set @mesefine = 12

				-- Si definiscono i mesi di inizio e fine pari ai mesi delle date di inizio e fine applicazione	
				if year(@startapplication) = @annoredditi
					set @meseinizio = month(@startapplication)
		
				if year(@stopapplication) = @annoredditi
					set @mesefine = month(@stopapplication)
		
				set @mese = @meseinizio
	
				-- Si cicla partendo dal mese inizio arrivando al mese di fine
				WHILE @mese <= @mesefine
				begin
					set @detrazionePerConiugeACarico = ''
					if @figlimaggiori = 0 and not exists (SELECT * from #coniuge)
					begin
						set @detrazionePerConiugeACarico = 'C'
					end
		
					declare @diffhand int
					set @diffhand = datediff(m, @starthandicap, dateadd(m, @mese-1, @1gen09))
		
					declare @casellaparentela int
					set @casellaParentela = 287
		
					if @idaffinity = 'C' set @casellaParentela = 277--C
		
					if @idaffinity = 'F' and @figlimaggiori = 0 and @diffhand < 0
						set @casellaParentela = 280--'F1'
		
					if @idaffinity = 'F' and @figlimaggiori = 0 and @diffhand >= 0
						set @casellaParentela = 281--'D1'
		
					if @idaffinity = 'F' and @figlimaggiori > 0 and @diffhand < 0
						set @casellaParentela = 286--'F'
		
					if @idaffinity = 'A' and @diffhand < 0
						set @casellaParentela = 287--'A'
		
					if @diffhand >= 0 and (@idaffinity = 'A' or @idaffinity = 'F' and @figlimaggiori > 0)
						set @casellaParentela = 288--'D'
		
					-- Gestione del coniuge
					if @casellaParentela = 277
					begin
						declare @idconiuge int
						set @idconiuge = null
		
						SELECT @idconiuge = idconiuge from #coniuge
							where b278codiceFiscaleConiuge = @cfFamigliare
							and bXXXanno = @annoredditi
		
						if @idconiuge is not null
						begin
							update #coniuge set
								b279numeroMesiACarico = b279numeroMesiACarico + 1 
								where idconiuge = @idconiuge
						end ELSE begin
							SELECT @idconiuge = 1 + count(*) from #coniuge
		
							insert into #coniuge values (
								@idconiuge,
								@cfFamigliare,
								1,
								@annoredditi)
						end
					end

					-- Gestione della detrazione per priomo figlio
					if @casellaParentela in (280, 281)
					begin
						declare @idPrimoFiglio int
						set @idPrimoFiglio = null
		
						SELECT @idPrimoFiglio = idPrimoFiglio
							from #primofiglio
							where (b280casellaPrimoFiglio=1 and @casellaParentela=280 
								or b281casellaDisabile=1 and @casellaParentela=281)
							and b282codiceFiscalePrimoFiglio = @cfFamigliare
							and bd85detrazionePerConiugeACarico = @detrazionePerConiugeACarico
							and bYYYanno = @annoredditi
		
						if @idPrimoFiglio is not null
						begin
							update #PrimoFiglio set
								b283numeroMesiACarico = isnull(b283numeroMesiACarico,0) + 1,
								b284minoreDiTreAnni = isnull(b284minoreDiTreAnni,0) + case WHEN datediff(m, dateadd(m, @mese-1, @1gen09), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 ELSE 0 end,
								bc85percentualeDiDetrazioneSpettante = isnull(bc85percentualeDiDetrazioneSpettante,0) 
													+ isnull(@appliancepercentage,1)
								where idPrimoFiglio = @idPrimoFiglio
						end ELSE begin
							SELECT @idPrimoFiglio = 1 + count(*) from #primofiglio
		
							insert into #PrimoFiglio values (
								@idprimofiglio,
								case @casellaParentela WHEN 280 THEN '1' end,
								case @casellaParentela WHEN 281 THEN '1' end,
								@cfFamigliare,
								1,
								case WHEN datediff(m, dateadd(m, @mese-1, @1gen09), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 end,
								case @detrazionePerConiugeACarico WHEN '' THEN isnull(@appliancepercentage,1) end,
								@detrazionePerConiugeACarico,
								@annoredditi)
						end
					end
		
					-- Gestione detrazione per altri figli
					if @casellaParentela between 286 and 288
					begin
						declare @idAltroFiglio int
						set @idAltroFiglio = null
						SELECT @idAltroFiglio = idAltroFiglio
							from #altrofiglio
							where (b286casellaFiglio=1 and @casellaParentela=286 
								or b287casellaAltroFamiliare=1 and @casellaParentela=287
								or b288casellaDisabile=1 and @casellaParentela=288)
							and b289codiceFiscaleFamiliare = @cfFamigliare
							and bd92detrazionePerConiugeACarico = @detrazionePerConiugeACarico
							and bZZZAnno = @annoredditi
		
						if @idAltroFiglio is not null
						begin
							update #AltroFiglio set
								b290numeroMesiACarico = isnull(b290numeroMesiACarico,0) + 1,
								b291minoreDiTreAnni = isnull(b291minoreDiTreAnni,0) + 
										case WHEN datediff(m, dateadd(m, @mese-1, @1gen09), 
											dateadd(yy, 3, @birthdate)) >= 0 THEN 1 
											ELSE 0 
										end,
								bc92percentualeDiDetrazioneSpettante = isnull(bc92percentualeDiDetrazioneSpettante,0)
													 + isnull(@appliancepercentage,1)
								where idAltroFiglio = @idAltroFiglio
						end ELSE begin
							SELECT @idAltroFiglio = 1 + count(*) from #altrofiglio
							insert into #AltroFiglio values (
								@idaltrofiglio,
								case @casellaParentela WHEN 286 THEN '1' end,
								case @casellaParentela WHEN 287 THEN '1' end,
								case @casellaParentela WHEN 288 THEN '1' end,
								@cfFamigliare,
								1,
								case WHEN datediff(m, dateadd(m, @mese-1, @1gen09), dateadd(yy, 3, @birthdate)) >= 0 THEN 1 end,
								case @detrazionePerConiugeACarico WHEN '' THEN isnull(@appliancepercentage,1) end,
								@detrazionePerConiugeACarico,
								@annoredditi
							)
						end
					end
					set @mese = @mese + 1
				end
	
				fetch next from @cursfamigliare into @idfamily, @birthdate, @idaffinity, @startapplication,
				@stopapplication, @starthandicap, @cfFamigliare, @appliancePercentage
			end
	
			-- Si procede all'inserimento dei dati inerenti i familiari all'interno della tabella di output
			-- estraendoli dalle tabelle definite per i familiari a carico
			--DBXXX277 casella coniuge
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
				SELECT @progrComunic, 'DB', idconiuge, '277', 1 from #coniuge
		
			--DBXXX278 codice fiscale coniuge
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
				SELECT @progrComunic, 'DB', idconiuge, '278', b278codiceFiscaleConiuge from #coniuge where b278codiceFiscaleConiuge <> ''
		
			--DBXXX279 numero mesi a carico
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
				SELECT @progrComunic, 'DB', idconiuge, '279', b279numeroMesiACarico from #coniuge

			--DBXXX259 anno
--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
--				SELECT @progrComunic, 'DB', idconiuge, '259', bXXXanno from #coniuge
		
			--DBXXX280 casella primo figlio
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idprimofiglio, '280', b280casellaPrimoFiglio from #primofiglio
		
			--DBXXX281 casella disabile
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) 
				SELECT @progrComunic, 'DB', idprimofiglio, '281', b281casellaDisabile from #primofiglio
		
			--DBXXX282 codice fiscale primo figlio
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
				SELECT @progrComunic, 'DB', idprimofiglio, '282', b282codiceFiscalePrimoFiglio from #primofiglio where b282codiceFiscalePrimoFiglio <> ''
		
			--DBXXX283 numero mesi a carico
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idprimofiglio, '283', b283numeroMesiACarico from #primofiglio
		
			--DBXXX284 minore di tre anni
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idprimofiglio, '284', b284minoreDiTreAnni from #primofiglio
		
			--DBXXXc85 percentuale di detrazione spettante
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idprimofiglio, 'c85', 100 * bc85percentualeDiDetrazioneSpettante / b283numeroMesiACarico from #primofiglio
		
			--DBXXXd85 percentuale di detrazione spettante
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
				SELECT @progrComunic, 'DB', idprimofiglio, 'd85', 'C' from #primofiglio where bd85detrazionePerConiugeACarico = 'C'
		
			--DBXXX266 anno
--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
--				SELECT @progrComunic, 'DB', idprimofiglio, '285', bYYYanno from #primofiglio
		
			--DBXXX286 casella figlio
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idaltrofiglio, '286', b286casellaFiglio from #altrofiglio
		
			--DBXXX287 casella altro familiare
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idaltrofiglio, '287', b287casellaAltroFamiliare from #altrofiglio
		
			--DBXXX288 casella disabile
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idaltrofiglio, '288', b288casellaDisabile from #altrofiglio
		
			--DBXXX289 codice fiscale familiare
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
				SELECT @progrComunic, 'DB', idaltrofiglio, '289', b289codiceFiscaleFamiliare from #altrofiglio where b289codiceFiscaleFamiliare <> ''
		
			--DBXXX290 numero mesi a carico
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idaltrofiglio, '290', b290numeroMesiACarico from #altrofiglio
		
			--DBXXX291 minore di tre anni
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idaltrofiglio, '291', b291minoreDiTreAnni from #altrofiglio
		
			--DBXXXc92 percentuale di detrazione spettante
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
				SELECT @progrComunic, 'DB', idaltrofiglio, 'c92', 100 * bc92percentualeDiDetrazioneSpettante / b290numeroMesiACarico from #altrofiglio
		
			--DBXXXd92 percentuale di detrazione spettante
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) 
				SELECT @progrComunic, 'DB', idaltrofiglio, 'd92', 'C' from #altrofiglio where bd92detrazionePerConiugeACarico = 'C'
		
			--DBXXX274 anno
	--		INSERT INTO #recordg (progr, quadro, riga, colonna, intero)
	--			SELECT @progrComunic, 'DB', idaltrofiglio, '274', bZZZAnno from #altrofiglio
	
					--DBXXX275 Percentuale di detrazione per famiglie numerose
	--				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', idaltrofiglio, '275', @b275percentualeDiDetrazionePerFamiglieNumerose)
							
		--fine modulo cococo
	--			end
		end
	
		if @tipo='W'
		begin
	--inizio wizard
			-- Si seleziona la prestazione associata al movimento di spesa
			SELECT @codeser = codeser from service 
				join #wizard on #wizard.idser = service.idser
				where #wizard.idexp = @chiave
	
			DECLARE @imponibilelordoirpef decimal(19,2)
			-- Calcolo dati fiscali:
	
			declare @imponibileaddreg decimal(19,2)
			declare @imponibileaddcom decimal(19,2)
			declare @deduzioneirpef decimal(19,2)
	
			-- Si calcolano imponibili e ritenute che sono presi dalla
			-- tabella #wizard precedentemente riempita con i dati delle prestazioni
			-- trasmesse nell'anno dei redditi
			SELECT
				@imponibilelordoirpef = ISNULL(SUM(imponibile),0), 
				@wb5ritIRPEF = ISNULL(SUM(importoritenuta),0),
				@deduzioneirpef = ISNULL(SUM(deduzione),0),
				@wb40detrazioniperoneri  = ISNULL(SUM(detrazione),0)
				FROM #wizard 
				WHERE taxkind = 1
				AND geoappliance IS NULL
				and idexp=@chiave

                        -- Totale Detrazioni = @wb30 + @wb34 + @wb35 + @wb36  = 0 + 0 + @wb35 + 0
                        set @wb45totaledetrazioni  = @wb40detrazioniperoneri 

			-- Inizio Codice Inutile
			set @SS002001 = isnull(@SS002001,0) + isnull(@wb5ritIRPEF,0)
			-- Fine Codice Inutile
	
			-- Si calcola l'addizionale regionale come somma delle ritenute fiscali regionali presenti nella tabella #wizard
			-- Si calcola l'imponibile dell'addizionale regionale come somma degli imponibili lordi
			-- delle ritenute fiscali regionali presenti nella tabella #wizard
			SELECT @wb6add_reg = ISNULL(SUM(importoritenuta),0), @imponibileaddreg=isnull(SUM(imponibile),0)
				FROM #wizard
				WHERE taxkind = 1
				AND geoappliance = 'R'
				and idexp=@chiave

			-- Si calcola l'acconto all'addizionale comunale come somma delle ritenute con codice 07_ACC_ADDCOM presenti
			-- nella tabella #wizard
			-- Si calcola l'imponibile dell'acconto all'addizionale regionale come somma degli imponibili lordi
			-- delle ritenute con codice 07_ACC_ADDCOM presenti nella tabella #wizard
			SELECT @wb10addcomacconto09  = ISNULL(SUM(importoritenuta),0), @imponibileaddcom=isnull(SUM(imponibile),0)
				FROM #wizard
				WHERE taxref = '07_ACC_ADDCOM'
				and idexp=@chiave
	
			-- Si calcola l'acconto all'addizionale comunale come somma delle ritenute con codice 05_ADDCOMU presenti
			-- nella tabella #wizard
			-- Si calcola l'imponibile dell'acconto all'addizionale regionale come somma degli imponibili lordi
			-- delle ritenute con codice 05_ADDCOMU presenti nella tabella #wizard
			SELECT @wb11addcomsaldo09  = ISNULL(SUM(importoritenuta),0), 
				@imponibileaddcom=isnull(@imponibileaddcom,0)+isnull(SUM(imponibile),0)
				FROM #wizard
				WHERE taxref = '05_ADDCOMU'
				and idexp=@chiave
		
			-- Calcolo del reddito al quale si possono applicare le deduzioni dell'art. 11
			-- pari all'imponibile lordo IRPEF calcolato sopra.
			-- Se il reddito dovesse essere inferiore all'imponibile delle addizionali allora
			-- sarà posto uguale
			set @wb1RedditoDedArt11 = isnull(@imponibilelordoirpef, 0)
			if @wb1RedditoDedArt11 < @imponibileaddcom set @wb1RedditoDedArt11 = @imponibileaddcom
			if @wb1RedditoDedArt11 < @imponibileaddreg set @wb1RedditoDedArt11 = @imponibileaddreg

			-- Calcolo dei giorni lavorati
			-- Questo dato è MOLTO fittizio in quanto non viene gestito nelle vecchie tabelle, potrà essere valorizzato
			-- seriamente a partire dal prossimo anno quando sarà utilizzato il modulo COCOCO
			SELECT @wb3workingdays = SUM(ISNULL(1+DATEDIFF(DAY, expenselast.servicestart,expenselast.servicestop),1))
				FROM expenselast
				WHERE idexp=@chiave
	
			if @wb3workingdays>365 
				set @wb3workingdays=365
	
			SELECT @wb58deductionart10  = ISNULL(SUM(importoritenuta),0) 
				FROM #wizard WHERE taxkind<>1
				and exists (SELECT * from #wizard s2 where s2.idexp=#wizard.idexp and taxkind=1)
				and idexp=@chiave
	
			set @wb33impostalorda  = @wb5ritIRPEF + @wb40detrazioniperoneri 

		-- Inserimento dei dati fiscali
		--DB001001 Redditi per i quali è possibile fruire della deduzione di cui all'art. 11 del TUIR
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '001', @wb1RedditoDedArt11)
		--DB001002 Redditi per i quali è possibile fruire della sola deduzione di cui all'art.11, c. 1 del TUIR
			-- Il campo seguente viene posto a zero in quanto non riusciamo a distinguere tali prestazioni e, quindi a valorizzarlo correttamente
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '002', 0)
		--DB001003 Numero di giorni per i quali spettano le deduzioni di cui all'art. 11 commi 2 e 3 del TUIR - LAVORO DIPENDENTE
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '003', @wb3workingdays)
		--DB001005 Ritenute Irpef
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '005', @wb5ritIRPEF)
		--DB001006 Addizionale regionale all'Irpef
	--				if isnull(@codeser,'') not in ('05_COOSTRA', '07_BRS_STN')
	--ho commentato in quanto quelle due prestazioni non hanno addizionali regionali e quindi l'if è inutile.
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '006', @wb6add_reg)
		--DB001010 Addizionale comunale all'Irpef - Acconto @annodichiarazione
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '010', @wb10addcomacconto09 )
		--DB001011 Addizionale comunale all'Irpef - Saldo @annodichiarazione
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '011', @wb11addcomsaldo09 )
		--DB001013 Addizionale comunale all'Irpef - Acconto 2010
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '013', @wb13addcomacconto10 )
		--DB001040 Detrazioni per oneri
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '040', @wb40detrazioniperoneri )
		--DB001045 Totale Detrazioni 
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '045', @wb45totaledetrazioni )
		--DB001058 Totale oneri sostenuti esclusi dai redditi indicati nei punti 1 e 2
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '058', @wb58deductionart10 )
		--DB001059 Totale oneri per i quali è prevista la detrazione d'imposta
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '059', @wb59oneridetraibili )
		--DB001063 Applicazione maggiore ritenuta
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '063', @wb63maggioreritenuta )
	
			-- Gestione dei redditi assoggettati a titolo di imposta
			-- Si considerano le sole prestazioni che hanno come ritenute fiscali quelle con codice
			-- 08_IRPEF_FOC o 07_IRPEF_FO
			if @codeser in (SELECT  codeser from service join servicetax ON servicetax.idser=service.idser
						join tax on servicetax.taxcode=tax.taxcode
						where  tax.taxref in ('08_IRPEF_FOC','07_IRPEF_FO') 
					) --'05_COOSTRA', '07_BRS_STN')			
			begin
				--DB001099 Totale Redditi
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '099', @wb1RedditoDedArt11)
				--DB001100 Ritenute Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '100', @wb5ritIRPEF)
				--DB001101 Addizionale regionale all'Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '101', @wb6add_reg)
	
				--DBXXX104 Causale
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DB', 1, '104', 2)
				--DBXXX105 Redditi
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '105', @wb1RedditoDedArt11)
				--DBXXX106 Ritenute Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '106', @wb5ritIRPEF) 
				--DBXXX107 Addizionale regionale all'Irpef
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DB', 1, '107', @wb6add_reg) 
			end

			-- Gestione delle Note
			-- DBXXX245 [Nota AI]
			DECLARE @wfiscalelordo decimal(19,2)
			SET @wfiscalelordo = 
			ISNULL(
				(SELECT MAX(expensetaxofficial.taxablegross)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE tax.taxkind = 1
					AND tax.geoappliance IS NULL
					AND expensetaxofficial.idexp = @chiave and expensetaxofficial.stop is null)
			,0)

			IF (@wfiscalelordo <> 0)
			BEGIN
				DECLARE @wstartcompetency datetime
				DECLARE @wstopcompetency datetime

				SELECT
					@wstartcompetency = ISNULL(expenselast.servicestart,expense.adate),
					@wstopcompetency = ISNULL(expenselast.servicestop, expense.adate)
				FROM expenselast
				JOIN expense
					ON expense.idexp = expenselast.idexp
				WHERE expense.idexp = @chiave

				SET @wb245_ai =
					'Assimilato a lavoro dipendente - Tempo det. - da ' +
					CONVERT(varchar(16), @wstartcompetency, 105) + ' a ' +
					CONVERT(varchar(16), @wstopcompetency, 105) + ' Importo ' +
					CONVERT(varchar(16), @wfiscalelordo)
	
				-- Note riferite al contratto principale
				-- DBXXX245 [Nota AI] (Questa nota è sicuramente presente almeno per il contratto principale)
				-- DB001245
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '245', 'AI')
				-- DB002245
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 2, '245', @wb245_ai)
			END

			-- DBXXX246 [Nota AJ]
			DECLARE @wtax_convenzione int
			SET @wtax_convenzione = NULL

			SELECT @wtax_convenzione = taxcode FROM tax WHERE taxref = '07_IRPEF_FC'

			DECLARE @impon decimal(19,2)
			SET @impon = 
			ISNULL(
				(SELECT taxablegross
				FROM expensetaxofficial
				WHERE taxcode = @wtax_convenzione
					AND idexp = @chiave and expensetaxofficial.stop is null)
			,0)

			IF (@wtax_convenzione IS NOT NULL)
				AND (@impon <> 0)
				AND (SELECT COUNT(*) FROM expensetaxofficial WHERE idexp = @chiave and stop is null) > 0
			BEGIN
				SET @wb246_aj = 'Importo ' + CONVERT(varchar(16), @impon)

				-- DB001226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '246', 'AJ')
				-- DB002226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 2, '246',
				'Redditi totalmente o parzialmente esentati da imposizione in Italia in quanto il percipiente risiede')
				-- DB003226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 3, '246',
				'in uno Stato Estero con cui è in vigore una convenzione per evitare le doppie imposizioni in materia')
				-- DB004226
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 4, '246',
				'di imposte dirette: ' + @wb246_aj)
			END


			-- DBXXX249 [Nota AM]
			DECLARE @wtax_irpefcaf int
			SELECT @wtax_irpefcaf = taxcode FROM tax WHERE taxref = '07_IRPEF_CAF'

			DECLARE @wrefund_irpefcaf decimal(19,2)

			SET @wrefund_irpefcaf = 
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM expensetaxofficial
				WHERE expensetaxofficial.taxcode = @wtax_irpefcaf
					AND expensetaxofficial.idexp = @chiave and expensetaxofficial.stop is null
				HAVING SUM(expensetaxofficial.employtax) < 0 )
			,0)

			DECLARE @wtax_addregcaf int
			SELECT @wtax_addregcaf = taxcode FROM tax WHERE taxref = '07_ADDREGCAF'

			DECLARE @wrefund_addregcaf decimal(19,2)

			SET @wrefund_addregcaf =
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM expensetaxofficial
				WHERE expensetaxofficial.taxcode = @wtax_addregcaf
					AND expensetaxofficial.idexp = @chiave and expensetaxofficial.stop is null
				HAVING SUM(expensetaxofficial.employtax) < 0 )
			,0)

			DECLARE @wtax_addcomcaf int
			SELECT @wtax_addcomcaf = taxcode FROM tax WHERE taxref = '07_ADDCOMCAF'

			DECLARE @wrefund_addcomcaf decimal(19,2)

			SET @wrefund_addcomcaf =
			ISNULL(
				(SELECT SUM(expensetaxofficial.employtax)
				FROM expensetaxofficial
				WHERE expensetaxofficial.taxcode = @wtax_addcomcaf
					AND expensetaxofficial.idexp = @chiave and expensetaxofficial.stop is null
				HAVING SUM(expensetaxofficial.employtax) < 0 )
			,0)

			-- DBXXX249 [Nota AM] (Nota inerente i rimborsi da C.A.F.)
			IF ((@wrefund_irpefcaf < 0) OR (@wrefund_addregcaf < 0) OR (@wrefund_addcomcaf < 0))
			BEGIN
				-- DB001249
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', 1, '249', 'AM')
				DECLARE @jj int
				SET @jj = 2

				IF (@refund_irpefcaf < 0)
				BEGIN
					-- DB002249
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @jj, '249',
						'Credito IRPEF rimborsato ' + CONVERT(varchar(16), -@wrefund_irpefcaf))
					SET @jj = @jj + 1
				END

				IF (@refund_addregcaf < 0)
				BEGIN
					-- DB002249
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @jj, '249',
						'Credito Addizionale Regionale rimborsato ' + CONVERT(varchar(16), -@wrefund_addregcaf))
					SET @jj = @jj + 1
				END

				IF (@refund_addcomcaf < 0)
				BEGIN
					-- DB002249
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DB', @jj, '249',
						'Credito Addizionale Comunale rimborsato ' + CONVERT(varchar(16), -@wrefund_addcomcaf))
					SET @jj = @jj + 1
				END
			END
		end
	
		-- Gestione dei Dati previdenziali ed assistenziali INPS
		if @tipo='W'
		begin
	--inizio wizard
			DECLARE @importocorrente decimal(19,2)
			declare @servicestart datetime
			declare @servicestop datetime
			declare @adate datetime
			declare @wdatacompetenza datetime
	
			SELECT DISTINCT
				@wdatacompetenza=paymenttransmission.transmissiondate,
				@servicestart=#wizard.servicestart,
				@servicestop=#wizard.servicestop,
				@adate=#wizard.adate,
				@importocorrente=#wizard.importocorrente
				FROM #wizard
				join expense on expense.idexp=#wizard.idexp
				join expenselast on expense.idexp = expenselast.idexp
				join payment on payment.kpay=expenselast.kpay
				join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
				WHERE #wizard.idexp=@chiave
		
			-- Calcolo Imponibile previdenziale
			-- il massimo imponibile associato alla ritenuta previdenziale
			SELECT @wc12compensoprev = isnull(max(imponibile), 0),
				@wc14ritprevtrattenuta = ISNULL(SUM(importoritenuta),0) 
				FROM #wizard 
				WHERE idexp = @chiave and taxkind=3
	
			-- Calcolo della ritenuta previdenziale dovuta
			-- pari alla somma tra la ritenuta previdenziale trattenuta e la ritenuta previdenziale c/amministrazione
			SELECT @wc13ritprevdovuta = @wc14ritprevtrattenuta + ISNULL(SUM(admintax),0) 
				FROM #wizard 
				WHERE idexp = @chiave and taxkind=3
	
			SET @wc15ritprevpagata = @wc13ritprevdovuta
				
	--todo: eliminare i mesi con inps=0
			if year(@wdatacompetenza)=@annoredditi 
				set @wc17mesiSenzaEmens = replicate('1',month(@wdatacompetenza)-1)+'0'+replicate('1',12-month(@wdatacompetenza))
			ELSE set @wc17mesiSenzaEmens = '111111111111'
	
	--Dati previdenziali ed assistenziali INPS - Sezione 2 - Collab. Coordinate e continuative
		--DCXXX012 Compensi corrisposti al collaboratore
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '012', round(@wc12compensoprev,0))
		--DCXXX013 Contributi dovuti
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '013', round(@wc13ritprevdovuta,0))
		--DCXXX014 Contributi a carico del collaboratore trattenuti
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '014', @wc14ritprevtrattenuta)
		--DCXXX015 Contributi versati
			INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '015', round(@wc15ritprevpagata,0))
		--DCXXX016 Mesi per i quasi è stata presentata la denuncia EMens - Tutti
			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '016', @wc16emensTuttiIMesi)
		--DCXXX017 Mesi per i quasi è stata presentata la denuncia EMens - Tutti con esclusione di
			INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '017', @wc17mesiSenzaEmens)
	
	
			-- Inserimento dei dati assicurativi solo se esiste una ritenuta assicurativa nella tabella #wizard
			if exists (SELECT * FROM #wizard WHERE idexp = @chiave and taxkind=4)
			begin
				--Dati assicurativi INAIL
	--			INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '079', round(@wc15ritprevpagata))
	--declare @patcode varchar(12)
	--set @patcode='9034567665'
	--				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '080', @patcode)
				set @wc84start_XXX=ISNULL(@servicestart,@adate)
		--DCXXX084 Data inizio
				INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', 1, '084', @wc84start_XXX)
				set @wc85stop_XXX=ISNULL(@servicestop,@adate)
		--DCXXX085 Data fine
				INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', 1, '085', @wc85stop_XXX)
		--DCXXX086 Codice comune
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '086', @zc86codiceComuneEnte_XXX)
			end
	--fine wizard
		end
			
		-- Gestione dei dati previdenziali e assicurativi
		IF @tipo='C'
		BEGIN
			-- Calcolo della P.A.T.
			-- Si prende una P.A.T. associata a contratti non divenuti CUD per altri e per i quali la P.A.T. è stata specificata
			-- ricordiamo anche in questa sede che la P.A.T. non è obbligatoria se non è contemplata una ritenuta assicurativa
			-- in una prestazione, diversamente è obbligatoria.
			SET @zc83patcode_XXX =
			(SELECT TOP 1 patcode
			FROM pat
			JOIN parasubcontract
				ON parasubcontract.idpat=pat.idpat
			JOIN #contratti
				ON #contratti.idcon = parasubcontract.idcon
			WHERE #contratti.padre IS NULL
				AND parasubcontract.idpat IS NOT NULL)

			-- Calcolo dell'imponibile previdenziale dei cedolini
			-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
			-- alla ritenuta previdenziale
			update #cedolini set compensoprev = (SELECT max(taxablegross)
				from expensetaxofficial
				join tax on expensetaxofficial.taxcode=tax.taxcode
				join expenselink
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 3 and expensetaxofficial.stop is null)

			-- Calcolo della ritenuta previdenziale c/dipendente dei cedolini
			-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
			-- alla ritenuta previdenziale
			update #cedolini set ritprevtrattenuta = (SELECT isnull(sum(employtax),0)
				from expensetaxofficial
				join tax on expensetaxofficial.taxcode=tax.taxcode
				join expenselink
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 3 and expensetaxofficial.stop is null)

			-- Calcolo della ritenuta previdenziale c/amministrazione dei cedolini
			-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
			-- alla ritenuta previdenziale
			update #cedolini set inpsamm = (SELECT isnull(sum(admintax),0) 
				from expensetaxofficial
				join tax on expensetaxofficial.taxcode=tax.taxcode
				join expenselink
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 3 and expensetaxofficial.stop is null)

			-- Calcolo della ritenuta assicurativa sia c/dipendente sia c/amministrazione dei cedolini
			-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
			-- alla ritenuta assicurativa
			update #cedolini set inail = (SELECT isnull(sum(employtax+admintax),0) 
				from expensetaxofficial
				join tax on expensetaxofficial.taxcode=tax.taxcode
				join expenselink
					ON expensetaxofficial.idexp = expenselink.idchild
				WHERE #cedolini.idexp = expenselink.idparent
					and taxkind = 4 and expensetaxofficial.stop is null)
	
			-- Calcolo dei mesi dove non è stato prodotto l'E-Mense
			set @zc17mesiSenzaEmens = --todo: eliminare i mesi in cui inps=0
				  case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 1 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 2 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 3 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 4 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 5 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 6 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 7 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 8 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)= 9 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)=10 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)=11 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
				+ case WHEN exists (SELECT * from #cedolini where month(datacompetenza)=12 and year(datacompetenza)=@annoredditi) THEN '0' ELSE '1' end
	
			SET @zc16emensTuttiIMesi = 0
			IF (@zc17mesiSenzaEmens = REPLICATE('0',12))
			BEGIN
				SET @zc16emensTuttiIMesi = 1
			END
				
			SELECT	@zc12compensoprev = sum(compensoprev),
				@zc13ritprevdovuta = sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0)),
				@zc14ritprevtrattenuta = sum(ritprevtrattenuta),
				@zc15ritprevpagata = sum(ISNULL(ritprevtrattenuta,0)+ISNULL(inpsamm,0))
				from #cedolini
	
			SELECT @zc12compensoprev = isnull(@zc12compensoprev, 0) + isnull(sum(exhibitedcud.taxablepension),0),
				@zc13ritprevdovuta = isnull(@zc13ritprevdovuta, 0) + isnull(sum(exhibitedcud.inpsowed),0),
				@zc14ritprevtrattenuta = isnull(@zc14ritprevtrattenuta, 0) + isnull(sum(exhibitedcud.inpsretained),0),
				@zc15ritprevpagata = isnull(@zc15ritprevpagata, 0) + isnull(sum(exhibitedcud.inpsowed),0)
				from exhibitedcud
				join #contratti on #contratti.idcon = exhibitedcud.idcon
			WHERE exhibitedcud.fiscalyear = @annoredditi
				AND NOT EXISTS(SELECT * FROM license WHERE ISNULL(cf, p_iva) = exhibitedcud.cfotherdeputy)

			-- Inserimento dei dati previdenziali nella tabella di output
			IF (@zc13ritprevdovuta > 0)
			BEGIN
			--DCXXX012 Compensi corrisposti al collaboratore
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '012', round(@zc12compensoprev,0))
			--DCXXX013 Contributi dovuti
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '013', round(@zc13ritprevdovuta,0))
			--DCXXX014 Contributi a carico del collaboratore trattenuti
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '014', @zc14ritprevtrattenuta)--Contributi a carico del collaboratore trattenuti
			--DCXXX015 Contributi versati
				INSERT INTO #recordg (progr, quadro, riga, colonna, decimale) VALUES(@progrComunic, 'DC', 1, '015', round(@zc15ritprevpagata,0))--Contributi versati
			--DCXXX016 Mesi per i quasi è stata presentata la denuncia EMens - Tutti
				INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', 1, '016', @zc16emensTuttiIMesi)
			--DCXXX017 Mesi per i quasi è stata presentata la denuncia EMens - Tutti con esclusione di
				INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', 1, '017', @zc17mesiSenzaEmens)
			END

			declare @startpayroll smalldatetime
			declare @stoppayroll smalldatetime
	
			declare @contaprestazioni int
			set @contaprestazioni = 1
	
			declare @oldstop smalldatetime
			set @oldstop = null

--			DECLARE @idpayroll int
			DECLARE @patcode varchar(20)

			-- Cursore sui cedolini per determinare la P.A.T. associata ai contratti e per determinare le date
			-- di inizio e fine rispettivamente minime e massime
			declare @cursorecedolini cursor
			set @cursorecedolini = cursor for
				SELECT pat.patcode, MIN(startpayroll) AS startpayroll, MAX(stoppayroll) AS stoppayroll
				FROM #cedolini
				JOIN parasubcontract
					ON parasubcontract.idcon = #cedolini.idcon
				JOIN pat
					ON pat.idpat = parasubcontract.idpat
				WHERE (inail > 0)
					AND (year(stoppayroll) >= @annoredditi)
				GROUP BY pat.patcode
				UNION ALL
				SELECT null, {d '2079-06-06'}, null
				ORDER BY startpayroll
	
			open @cursorecedolini
			fetch next from @cursorecedolini into @patcode, @startpayroll, @stoppayroll
	
			declare @oldstart smalldatetime
			if @startpayroll < @1gen09 set @oldstart = @1gen09 ELSE set @oldstart = @startpayroll
	
			-- Inserimento dei dati assicurativi distinti per mese
			WHILE @@fetch_status = 0
			begin
				--Dati assicurativi INAIL
				if @startpayroll < @1gen09 set @startpayroll = @1gen09
				if @stoppayroll > @31dic09 set @stoppayroll = @31dic09
	
				if datediff(d, @oldstop, @startpayroll) > 1
				begin
		--DCXXX079 Qualifica
			--		INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(@progrComunic, 'DC', @contaPrestazioni, '079', round(@c15ritprevpagata))
		--DCXXX083 Posizione assicurativa territoriale
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', @contaPrestazioni, '083', @zc83patcode_XXX)
		--DCXXX084 Data inizio
					INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', @contaPrestazioni, '084', @oldstart)
		--DCXXX085 Data fine
					INSERT INTO #recordg (progr, quadro, riga, colonna, data) VALUES(@progrComunic, 'DC', @contaPrestazioni, '085', @oldstop)
		--DCXXX086 Codice comune
					INSERT INTO #recordg (progr, quadro, riga, colonna, stringa) VALUES(@progrComunic, 'DC', @contaPrestazioni, '086', @zc86codiceComuneEnte_XXX)
	
					set @oldstart = @startpayroll
					set @contaprestazioni = @contaprestazioni + 1
				end
					
				set @oldstop = @stoppayroll
		
				fetch next from @cursorecedolini into @patcode, @startpayroll, @stoppayroll
		
			end
	--fine modulo cococo
		end
		set @progrComunic = @progrComunic + 1
		fetch next from @cursorecomunicazione into @chiave, @tipo, @cognome
	end
	CLOSE @cursorecomunicazione
	DEALLOCATE @cursorecomunicazione

-- SS002001  	 Ritenute Irpef  
--	set @SS002001 = isnull(@SS002001,0) + isnull(@wb5ritIRPEF, 0)
--	set @SS002001 = isnull(@SS002001,0) + isnull(@zb5ritIRPEF, 0)
--	set @SS002001 = isnull(@SS002001,0) - isnull(@zb80cudirpef_XXX, 0)
-- J.T.R. Commentate per il 2008, nel 2009 si valuterà se riempire il prospetto SS
-- Questo perchè, dato che i dati devono totalizzare "tutto" inclusi gli stipendi..
-- non ha senso una tot. parziale...e pertanto non è stato fatto.
--	INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(1, 'SS', 2, '001', @SS002001)

-- SS002002  	 Ritenute Irpef sospese  
--	set @SS002002 = isnull(@SS002002,0) - isnull(@zb81cudirpefsosp_XXX, 0)
--	INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(1, 'SS', 2, '002', @SS002002)


-- SS002009  	 Addizionale comunale acconto 2009  
--	set @SS002009 = isnull(@SS002009,0) + isnull(@zb10addcomacconto09, 0)
--	set @SS002009 = isnull(@SS002009,0) - isnull(@zb86cudaddcomacconto_XXX, 0)
--	INSERT INTO #recordg (progr, quadro, riga, colonna, intero) VALUES(1, 'SS', 2, '008', @SS002009)

	if @modello = 'cud'
	begin
		SELECT * from #recordg where (intero is not null or stringa is not null or data is not null or decimale is not null)
	end
	if @modello = '770'
	begin
		SELECT 
			progr, quadro, riga, colonna, stringa, 
			intero =
			CASE
				WHEN (decimale IS NOT NULL) AND (quadro = 'DB') AND (decimale >= 0)
				THEN FLOOR(decimale)
				WHEN (decimale IS NOT NULL) AND (quadro = 'DB') AND (decimale < 0)
				THEN CEILING(decimale)
				WHEN (decimale IS NOT NULL) AND (quadro <> 'DB')
				THEN ROUND(decimale, 0)
				ELSE intero
			END,
			data
		FROM #recordg
		where (intero is not null or stringa is not null or data is not null or decimale is not null)
	end

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


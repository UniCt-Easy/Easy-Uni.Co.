/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_g_missioni_26]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_g_missioni_26]
GO
--setuser 'amministrazione' 
CREATE PROCEDURE [exp_certificazioneunica_g_missioni_26]
 -- estraggo il record G relativo ad un determinato percipiente, il progressivo comunicazione
 -- indica l'ordine all'interno dei percipienti del sostituto d'imposta
(
	 @idreg int,
	 @progrCom int,
	 @print char(1)  -- vale S per la stampa N altrimenti
	 --@newprogrCom int out
) 
--setuser 'amm'
-- setuser 'amministrazione'
-- exec exp_certificazioneunica_g_missioni_26  81856,1,'S'  --55750

AS BEGIN 
	declare @annodichiarazione int
	set @annodichiarazione = 2026

	declare @annoredditi int
	set @annoredditi = 2025

	declare @31dic2025 datetime
	set @31dic2025 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1
 
-- Sezione dichiarativa	
	DECLARE @progrModulo int -- normalmente costante pari a uno
	DECLARE @codfiscEnte varchar(16)
	DECLARE @idcityente varchar(16)
	DECLARE @au1cf varchar(16) -- codice fiscale del percipiente

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	SET @progrModulo = 1
 
	SELECT @au1cf =  isnull(cf,p_iva) FROM registry
	WHERE registry.idreg = @idreg
	
	
	DECLARE @agencynumber VARCHAR(10)
		
	SELECT @agencynumber =  agencynumber FROM config
	WHERE  ayear = @annodichiarazione
	
	SELECT  @codfiscEnte = cf, @idcityEnte = idcity FROM license
	
	DECLARE @codiceComuneEnte VARCHAR(4)
	SET @codiceComuneEnte = null
	
	SELECT @codiceComuneEnte = value from geo_city_agency   -- CODICE CATASTALE COMUNE ENTE 
	WHERE  idcode=1 and idcity=@idcityente and idagency=1
			
	-- Il quadro G  per i Dati relativi alla comunicazione dati certificazioni lavoro dipendente, assimilati ed assistenza fiscale
	CREATE TABLE #recordG 
	(
		progr int,
		modulo int,
		quadro varchar(6),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		decimale decimal(19,2),
		data datetime,
		intero int
	)
		
	----------------------------------------------------
	---- Intestazione Record G, parte posizionale ------
	----------------------------------------------------
	--- COMMENTO QUESTE ISTRUZIONI PER EVITARE EXEC ANNIDATE
	--insert into #recordG (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
	--exec exp_certificazioneunica_d_26  @idreg, @progrCom, 'G',NULL, @print
	
	--1 Tipo record
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom, 1, 'HRG', 1, '01', 'G')
	--2 Codice fiscale del sostituto d'imposta
	INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, stringa)  VALUES(@progrCom, 1, 'HRG', 1, '02', @codfiscEnte)
	--3 Progressivo modulo
	INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, intero)   VALUES(@progrCom, 1, 'HRG', 1, '03', @progrModulo)
	--4 Codice fiscale del percipiente
	INSERT INTO #recordG (progr, modulo,quadro, riga, colonna, stringa)  VALUES(@progrCom, 1, 'HRG', 1, '04', @au1cf)
	--5 Progressivo certificazione
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)  VALUES(@progrCom, 1, 'HRG', 1, '05', @progrCom)
 
	----------------------------------------------------
    --- Estrazione dati relativi alle somme erogate ----
    ----------------------------------------------------
    
	-- Ricordarsi di cambiare ogni anno l'anno delle date
	declare @1gen2025_XXX datetime
	set @1gen2025_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @13gen2025_XXX datetime
	set @13gen2025_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-13'})

	declare @31dic2025_XXX datetime
	set @31dic2025_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @1gen2026_XXX datetime
	set @1gen2026_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-01'})

	declare @12gen2026_XXX datetime
	set @12gen2026_XXX = dateadd(yy, @annodichiarazione-2000, {d '2000-01-12'})

	-- Tabella dei giorni lavorati
	create table #workdays 	(giorno smalldatetime, worked char(1) )

	DECLARE @1gen00 datetime
	SET @1gen00 = DATEADD(yy, @annoredditi-2000, {d '2000-01-01'})

	declare @30giu2025 datetime
	set @30giu2025 = dateadd(yy, @annoredditi-2000, {d '2000-06-30'})
	
	declare @01lug2025 datetime
	set @01lug2025 = dateadd(yy, @annoredditi-2000, {d '2000-07-01'})


	declare @giorno smalldatetime
	set @giorno=@1gen00
	WHILE (datepart(year,@giorno)<=@annoredditi)
	BEGIN
		insert into #workdays(giorno) values (@giorno)
		set @giorno=DATEADD(dd,1,@giorno)
	END
	
	-- Tabella delle missioni coinvolte nella certificazione unica
	create table #missioni
	(
		iditineration varchar(8),
		taxablepension decimal(19,2),
		fiscaltaxablegross decimal(19,2),
		inpsinail decimal(19,2),
		deduction decimal(19,2),
		start datetime, -- Data inizio della missione
		stop datetime,  -- Data fine della missione
		stopitineration datetime, -- Data Fine della missione
		certificatekind char(1),
		idser int,
		servicecode770 varchar(20),
		highertax decimal(19,2),
		applicaritprevidenziali char(1),
		exemptioncode int,
		competencydate datetime,
		compensoprev decimal(19,2),
		ritprevtrattenuta decimal(19,2),
		inpsamm decimal(19,2),
		inail decimal(19,2)
	)

	-- Tabella delle ritenute applicate alle missioni
	create table #expensetaxofficial (
		iditineration int, 
		idser int,
		idexp int,
		competencydate datetime,
		taxcode int,
		taxref varchar(50),
		tax varchar(200),
		taxkind varchar(50),
		geoappliance char(1),
		abatements decimal(19,2),
		taxablegross decimal(19,2),
		taxablenet decimal(19,2),
		employtax decimal(19,2),
		admintax decimal(19,2),
		start datetime,
		stop datetime
	);

	-- Si inseriscono le missioni del percipiente corrente.
	-- per la Certificazione Unica
	-- Vengono presi tutte le missioni non esenti fiscalmente di un fissato percipiente per i quali esiste almeno pagamento con ritenute che sia stato trasmesso
	-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino  associato deve essere associata
	-- al quadro G del 770 (rec770kind = 'G'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
	-- le deduzioni, l'imponibile fiscale lordo della missione e l'id e la data di fine missione.
 
 WITH Ritenute AS (
		SELECT	
				EI.iditineration as iditineration ,
				EL.idser as idser,
				ETO.taxcode as taxcode,
				ETO.taxref as taxref,
				ETO.description as tax,
				CASE ETO.taxkind 
					 WHEN 1 THEN 'Fiscale'
					 WHEN 2 THEN 'Assistenziale'
					 WHEN 3 THEN 'Previdenziale'
					 WHEN 4 THEN 'Assicurativa'  --- INAIL 
					 WHEN 5 THEN 'Arretrati'
					 WHEN 6 THEN 'Altro'
				END as taxkind,
				ETO.abatements as abatements,
				ETO.taxablegross as taxablegross,
				ETO.taxablenet as taxablenet,
				ETO.employtax as employtax,
				ETO.admintax as admintax, 
				paymenttransmission.transmissiondate as transmissiondate
		FROM expenseitineration EI
			join expenselink LK ON LK.idparent = EI.idexp
			join expenselast EL ON EL.idexp = LK.idchild 
			join expensetaxofficialview ETO ON  EL.idexp = ETO.idexp /*alla missione sono state applicate le ritenute*/
			join payment ON payment.kpay=EL.kpay
			join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
			WHERE payment.kpaymenttransmission is not null --and ETO.taxkind = 1 /*FISCALE*/
			AND payment.ypay = @annoredditi
	) 
	INSERT INTO #missioni
		(iditineration, taxablepension, fiscaltaxablegross, inpsinail, deduction,
		 start, /*Data inizio della missione*/ stop, /*Data fine della missione*/ stopitineration, /*Data Fine della missione*/
		 certificatekind, idser, servicecode770, applicaritprevidenziali )
	SELECT
		it.iditineration,
		itd.imponibile,
		(SELECT  MAX(ISNULL(taxablegross,0))  FROM Ritenute RT  
			            WHERE RT.iditineration = it.iditineration
						AND RT.taxkind = 'Fiscale'
						),
		(SELECT  SUM(ISNULL(employtax,0) + ISNULL(admintax,0))  FROM Ritenute RT  
			              WHERE RT.iditineration = it.iditineration
						    AND RT.taxkind = 'Assicurativa'
							),
		null,
		it.start,
		it.stop,
		it.stop,
		service.certificatekind,
		it.idser,
		ISNULL(service.servicecode770,service.codeser),
		CASE
			WHEN EXISTS (SELECT * FROM Ritenute RT  
			              WHERE RT.taxkind = 'Previdenziale' AND 
								RT.iditineration = it.iditineration) THEN 'S'
			ELSE 'N'
		END 
	FROM itineration it 
		JOIN service ON service.idser = it.idser
		JOIN registry ON registry.idreg = it.idreg
		JOIN itinerationamountdetail itd ON it.iditineration = itd.iditineration
	WHERE  
		EXISTS (SELECT * from  Ritenute RT WHERE RT.iditineration = it.iditineration AND RT.taxkind = 'Fiscale' /*FISCALE*/ )
		AND service.rec770kind='G'
		AND service.flagcsausability = 0  -- non sono estratti nel Record 8000
		AND it.idreg = @idreg
		 


	DECLARE @start datetime 
	DECLARE @stop  datetime 
	DECLARE @stopitineration datetime
	SELECT 	@start = MIN(start) FROM #missioni	
	SELECT 	@stop  = MAX(stop)  FROM #missioni	
	SELECT 	@stopitineration  = MAX(stopitineration)  FROM #missioni	;
 
	--SELECT * FROM #missioni
	-- Riempimento della tabella delle ritenute
	-- Vengono inserite tutti pagamenti con ritenute trasmesse associati alle missioni del percipiente dell'anno dei redditi.
	-- Di queste missioni si seleziona il movimento di spesa che li contabilizza(ultima fase), la data di trasmissione,
	-- la data di inizio e fine.
 
 	WITH Ritenute AS (
		SELECT	
				EI.iditineration as iditineration,
				EL.idser as idser,
				ETO.idexp as idexp,
				paymenttransmission.transmissiondate as competencydate, 
				ETO.taxcode as taxcode,
				ETO.taxref as taxref,
				ETO.description as tax,
				CASE ETO.taxkind 
					 WHEN 1 THEN 'Fiscale'
					 WHEN 2 THEN 'Assistenziale'
					 WHEN 3 THEN 'Previdenziale'
					 WHEN 4 THEN 'Assicurativa'  --- INAIL 
					 WHEN 5 THEN 'Arretrati'
					 WHEN 6 THEN 'Altro'
				END as taxkind,
				CASE WHEN(ETO.idcity IS NOT NULL 
						 OR ETO.fiscaltaxregion IS NOT NULL) 
					 THEN 'S' 
					 ELSE 'N' 
				END as geoappliance,
				ETO.abatements as abatements,
				ETO.taxablegross as taxablegross,
				ETO.taxablenet as taxablenet,
				ETO.employtax as employtax,
				ETO.admintax as admintax,
				ETO.start as start,
				ETO.stop as stop
		FROM expenseitineration EI
			join expenselink LK ON LK.idparent = EI.idexp
			join expenselast EL ON EL.idexp = LK.idchild 
			join expensetaxofficialview ETO ON  EL.idexp = ETO.idexp /*alla missione sono state applicate le ritenute*/
			join payment ON payment.kpay=EL.kpay
			join paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
			WHERE payment.kpaymenttransmission is not null
			AND payment.ypay = @annoredditi
	) 
	INSERT INTO #expensetaxofficial (
		iditineration, 
		idser, 
		idexp,
		competencydate,
		taxcode,
		taxref,
		tax,
		taxkind,
		geoappliance, 
		abatements,
		taxablegross,
		taxablenet,
		employtax,
		admintax
	)
	SELECT 
		R.iditineration, 
		R.idser,
		R.idexp,
		R.competencydate, 
		R.taxcode,
		R.taxref,
		R.tax,
		R.taxkind,
		R.geoappliance,
		R.abatements,
		R.taxablegross,
		R.taxablenet,
		R.employtax,
		R.admintax 
	FROM #missioni M
	JOIN Ritenute  R ON M.iditineration = R.iditineration
	--SELECT * FROM #missioni
	--SELECT * FROM #expensetaxofficial

	-- Calcolo dei giorni lavorati
	-- Si settano tutti i giorni a NON LAVORATI
	update #workdays set worked='N'
	-- Si settano tutti i giorni rientranti nella durata delle missioni a LAVORATI
	update #workdays set worked='S' where exists
		(SELECT * from #missioni
		WHERE #workdays.giorno BETWEEN #missioni.start AND #missioni.stop 
			AND NOT EXISTS
				(SELECT * FROM servicetaxview
				WHERE servicetaxview.idser = #missioni.idser
					AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))
		)

 --	SELECT * FROM #missioni
	--select * from #expensetaxofficial
	-- Calcolo dei redditi ai quali si possono applicare le deduzioni art. 11 e imposta lorda
	-- Si scartano le ritenute con codice
	-- 08_IRPEF_FOC e 07_IRPEF_FO in quanto sono ritenute applicate a stranieri che non rientrano in questo calcolo
	-- L'imposta lorda  pari alla somma delle ritenute (il filtro  quello descritto precedentemente), tant'è che la
	-- query  è la medesima
	DECLARE @taxablegross	DECIMAL(19,2) = 0
	DECLARE @employtaxgross DECIMAL(19,2) = 0
	DECLARE @bonus_fiscale DECIMAL(19,2) = 0
	DECLARE @bonus_fiscale_integrativo DECIMAL(19,2) = 0
	--- Assumiamo di non applicare detrazioni dato che non abbiamo i dati per calcolarle
	DECLARE @detrazioni_familiari_a_carico	DECIMAL(19,2) = 0
	DECLARE @detrazioni_per_reddito DECIMAL(19,2) = 0
	DECLARE @totale_detrazioni DECIMAL(19,2) = 0

	-- Calcolo della ritenute IRPEF
	-- Si considera la somma delle ritenute nette fiscali nazionali con codice differente
	-- da 08_IRPEF_FOC e 07_IRPEF_FO (che sono riservate a stranieri) 

	DECLARE @ritenuta_irpef DECIMAL(19,2)
	SET @ritenuta_irpef =
	ISNULL(
		(SELECT SUM(ETO.employtax)
		FROM #expensetaxofficial ETO
		WHERE ETO.taxkind = 'Fiscale' AND ETO.geoappliance = 'N'
            AND ETO.stop is null
			AND ETO.taxref NOT IN ('08_IRPEF_FOC','07_IRPEF_FO'))
	,0)

	SET @taxablegross =
	ISNULL(
		(SELECT MAX(ETO.taxablegross)
		FROM #expensetaxofficial ETO
		WHERE ETO.taxkind = 'Fiscale' AND ETO.geoappliance = 'N'
            AND ETO.stop is null
			AND ETO.taxref NOT IN ('08_IRPEF_FOC','07_IRPEF_FO'))
	,0)

	DECLARE @ritenuta_addreg_irpef DECIMAL(19,2) = 0
	DECLARE @ritenuta_addcom_irpef_saldo_2025 DECIMAL(19,2) = 0
 

	-- Conteggio dei giorni lavorati
	DECLARE @workingdays INT
	--DECLARE @workingdays_1_semestre INT
	--DECLARE @workingdays_2_semestre INT
	-- Se i giorni lavorati superano l'anno si pongono pari al numero di giorni dell'anno
	-- non  contemplato, a quanto pare, l'anno bisestile
	SELECT  @workingdays = count(*) from #workdays where worked='S'
	
	IF @workingdays>365 
	BEGIN
		SET @workingdays = 365 
	END


	print '@1gen00'
	print @1gen00
	print '@01lug2025'
	print @01lug2025
	print '@30giu2025'
	print @30giu2025

	print '@01lug2025'
	print @01lug2025
	print '@30giu2025'
	print @30giu2025
	
	--setuser 'amm'
	---------------------------------------------------------
	-- Tabella delle prestazioni adoperate nei contratti ----
	---------------------------------------------------------
	CREATE TABLE #ser (idser int, servicecode770 varchar(20), description varchar(200) )
	
	-- Inserimento delle prestazioni associate alle missioni
	INSERT INTO #ser (idser, servicecode770, description )
	SELECT DISTINCT #missioni.idser, ISNULL(service.servicecode770,service.codeser),servprincipale.description 
	FROM service
	JOIN #missioni ON service.idser = #missioni.idser
	JOIN  service servprincipale ON service.servicecode770 = servprincipale.codeser
	 

	--------------------------------------------------------------------------------------------
	------------- CALCOLI SEZIONE 3 INPS GESTIONE DIPENDENTI PUBBLICI (EX INPDAP) --------------
	--------------------------------------------------------------------------------------------
	--	PRESTAZIONE CONSIDERATA 14_DIPENDPUBBLICI
	--  RITENUTE CONSIDERATE '07_INPDAP_CAMM','07_INPDAP_CDIP', '14_Rit. L.438/9','07_FDOCRE' 
 
	IF
	(SELECT COUNT(*)
		FROM #ser
		WHERE 	#ser.servicecode770 = '14_DIPENDPUBBLICI'
	) 
	> 0
	BEGIN
		
	DECLARE @taxablegross_dipendentipubblici				decimal(19,2)
	DECLARE @ritenuta_previdenziale_dipendentipubblici		decimal(19,2)
	DECLARE @ritenuta_previdenziale_dipendentipubblici_dip	decimal(19,2)
	DECLARE @ritenuta_previdenziale_dipendentipubblici_amm	decimal(19,2)
	DECLARE @taxablegross_fondocredito_dipendentipubblici	decimal(19,2)
	DECLARE @ritenuta_fondocredito_dipendentipubblici		decimal(19,2)
	DECLARE @ritenuta_fondocredito_dipendentipubblici_dip	decimal(19,2)
	
	-- Esso  pari alla somma degli imponibili lordi delle ritenute previdenziali con codice 07_INPDAP_CAMM o 07_INPDAP_CDIP o 14_Rit. L.438/9
	-- associate alle missioni del percipiente.  
									         
	SET  @taxablegross_dipendentipubblici = ISNULL(( SELECT SUM(ETO.taxablegross)
		FROM	#expensetaxofficial ETO		 
				WHERE ETO.taxkind = 'Previdenziale'	 
				AND   EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = ETO.idser
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  ETO.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM'))	),0)
										 
								         	
	-- Si considera la somma delle ritenute   previdenziali nazionali con codice uguale
	-- a '07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/9'
	SET @ritenuta_previdenziale_dipendentipubblici_dip  =
	ISNULL(
		(SELECT SUM(ETO.employtax)
		FROM  #expensetaxofficial ETO
		WHERE ETO.taxkind = 'Previdenziale'	  
            AND  ETO.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = ETO.idser
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  ETO.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/92' ))
	),0)	
	
	SET @ritenuta_previdenziale_dipendentipubblici_amm  =
	ISNULL(
		(SELECT SUM(ETO.admintax)
		FROM #expensetaxofficial ETO
		WHERE ETO.taxkind = 'Previdenziale'	  
            AND  ETO.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = ETO.idser
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
										 AND servicetaxview.taxcode =  ETO.taxcode
								         AND servicetaxview.taxref IN ('07_INPDAP_CAMM','07_INPDAP_CDIP','14_Rit. L.438/92' ))
	),0)	
	
	SET @ritenuta_previdenziale_dipendentipubblici = @ritenuta_previdenziale_dipendentipubblici_dip + @ritenuta_previdenziale_dipendentipubblici_amm

	
	SELECT  @taxablegross_fondocredito_dipendentipubblici =  SUM (ETO.taxablegross)
	FROM	#expensetaxofficial	ETO 			 
			WHERE ETO.taxkind = 'Previdenziale'	AND ETO.taxref = '07_FDOCRE'  
			AND EXISTS (SELECT * FROM servicetaxview
						       WHERE servicetaxview.idser = ETO.idser
									 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI')	
	
	
	--	Calcolo della ritenute PREVIDENZIALI CON CODICE FONDO CREDITO
	-- Si considera la somma delle ritenute   previdenziali nazionali con codice uguale
	-- a '07_FDOCRE'
	SET @ritenuta_fondocredito_dipendentipubblici_dip   =
	ISNULL(
		(SELECT SUM(ETO.employtax)
		FROM    #expensetaxofficial 	ETO 	
		WHERE   ETO.taxkind = 'Previdenziale'  
            AND  ETO.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = ETO.idser
							       	 AND servicetaxview.taxcode =  ETO.taxcode
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
								         AND servicetaxview.taxref = '07_FDOCRE')
	),0)	

	SET @ritenuta_fondocredito_dipendentipubblici  =   @ritenuta_fondocredito_dipendentipubblici_dip 	
	+
	ISNULL(
		(SELECT SUM(ETO.admintax)
		FROM    #expensetaxofficial 	ETO 	
		WHERE   ETO.taxkind = 'Previdenziale'  
            AND  ETO.stop is null
			AND  EXISTS (SELECT * FROM servicetaxview
							       WHERE servicetaxview.idser = ETO.idser
							       	 AND servicetaxview.taxcode =  ETO.taxcode
										 AND servicetaxview.servicecode770 = '14_DIPENDPUBBLICI'
								         AND servicetaxview.taxref = '07_FDOCRE')
	),0)	
	
	declare @mesiConEmensdipendentipubblici VARCHAR(12)
	declare @emensTuttiIMesidipendentipubblici int
	declare @periodiretributivisoggettodenuncia varchar(12)
	-- Calcolo dei mesi dove non  stato prodotto l'E-Mense
	set @mesiConEmensdipendentipubblici = --todo: eliminare i mesi in cui inps=0
		  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 1 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 2 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+ 	  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 3 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 4 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+ case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 5 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 6 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 7 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 8 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 9 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 10 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 11 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end
		+  case WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
			where month(ETO.competencydate)= 12 and year(ETO.competencydate)=@annoredditi 
			AND M.servicecode770 = '14_DIPENDPUBBLICI'
			AND M.applicaritprevidenziali = 'S'
			) THEN '1' ELSE '0' end

	SET @periodiretributivisoggettodenuncia = REPLACE(REPLACE(@mesiConEmensdipendentipubblici,'0','X'), '1', 'Z')
	
	SET @periodiretributivisoggettodenuncia = REPLACE(REPLACE(@mesiConEmensdipendentipubblici,'X','1'), 'Z', '0')

	SET @emensTuttiIMesidipendentipubblici = 0
	IF (@mesiConEmensdipendentipubblici = REPLICATE('1',12))
	BEGIN
		SET @emensTuttiIMesidipendentipubblici = 1
	END
							
	END		         
 
	----------------------------------------------------------------------------------------------------------------
	-------- Dati previdenziali ed assistenziali INPS - Sezione 2 - Collab. Coordinate e continuative 47 -----------
	----------------------------------------------------------------------------------------------------------------
	IF
	(SELECT COUNT(*)
	FROM #ser
	WHERE 	#ser.servicecode770 <> '14_DIPENDPUBBLICI'
	) 
	> 0
	BEGIN
		-- Calcolo dell'imponibile previdenziale dei cedolini
		-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
		-- alla ritenuta previdenziale
		update #missioni set compensoprev = (SELECT max(ETO.taxablegross)
			from #expensetaxofficial ETO
			JOIN #missioni M
				ON M.iditineration = ETO.iditineration
			WHERE  ETO.taxkind = 'Previdenziale' and ETO.stop is null 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI')

		-- Calcolo della ritenuta previdenziale c/dipendente dei cedolini
		-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
		-- alla ritenuta previdenziale
		update #missioni set ritprevtrattenuta = (SELECT isnull(sum(ETO.employtax),0)
				from #expensetaxofficial ETO
					JOIN #missioni M
				ON	M.iditineration = ETO.iditineration
				WHERE ETO.taxkind = 'Previdenziale' and ETO.stop is null 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI')

		-- Calcolo della ritenuta previdenziale c/amministrazione dei cedolini
		-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
		-- alla ritenuta previdenziale
		update #missioni set inpsamm = (SELECT isnull(sum(admintax),0) 
			from #expensetaxofficial ETO
					JOIN #missioni M
				ON	M.iditineration = ETO.iditineration
				WHERE ETO.taxkind = 'Previdenziale' and ETO.stop is null 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI')
				
			-- Calcolo della ritenuta assicurativa sia c/dipendente sia c/amministrazione dei cedolini
			-- Viene impostato per i cedolini pari al massimo tra gli imponibili associati
			-- alla ritenuta assicurativa
			update #missioni set inail = (SELECT isnull(sum(employtax+admintax),0) 
				from #expensetaxofficial ETO
					JOIN #missioni M
				ON	M.iditineration = ETO.iditineration
				WHERE ETO.taxkind = 'Assicurativa' and ETO.stop is null 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI')
					
					
		declare @mesiSenzaEmens VARCHAR(12)
		declare @emensTuttiIMesi int
		-- Calcolo dei mesi dove non  stato prodotto l'E-Mense
		set @mesiSenzaEmens = --todo: eliminare i mesi in cui inps=0
			 CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 1 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
			) THEN '0' ELSE '1' end
			+  CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 2 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' end
			+   CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 3 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 4 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)=5 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 6 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 7 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 8 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 9 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 10 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 11 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
			+ CASE WHEN exists (SELECT * from #expensetaxofficial ETO 
							JOIN #missioni M ON  ETO.iditineration = M.iditineration
				where month(ETO.competencydate)= 12 and year(ETO.competencydate)=@annoredditi 
				AND M.servicecode770 <> '14_DIPENDPUBBLICI'
				AND M.applicaritprevidenziali = 'S'
				) THEN '0' ELSE '1' END
		--SELECT '@mesiSenzaEmens', @mesiSenzaEmens
		SET @emensTuttiIMesi = 0
		IF (@mesiSenzaEmens = REPLICATE('0',12))
		BEGIN
			SET @emensTuttiIMesi = 1
		END

		DECLARE @compensoprev DECIMAL(19,2)
		DECLARE @ritprevdovuta DECIMAL(19,2)
		DECLARE @ritprevtrattenuta DECIMAL(19,2)
		DECLARE @ritprevpagata DECIMAL(19,2)
		DECLARE @ritprevamministrazione DECIMAL(19,2)
		DECLARE @idemenscontractkind varchar(2)

		SELECT  @idemenscontractkind = 11 --Collaborazioni coordinate e continuative presso la Pubblica Amministrazione

		SELECT	@compensoprev = sum(M.compensoprev),
				@ritprevdovuta = sum(ISNULL(M.ritprevtrattenuta,0)+ISNULL(M.inpsamm,0)),
				@ritprevtrattenuta = sum(M.ritprevtrattenuta),
				@ritprevpagata = sum(ISNULL(M.ritprevtrattenuta,0)+ISNULL(M.inpsamm,0)),
				@ritprevamministrazione = sum(ISNULL(M.inpsamm,0))
		FROM #missioni  M
		WHERE M.servicecode770 <> '14_DIPENDPUBBLICI'
	END

	

    --------------------------------------------- 
	---- Record G, parte non  posizionale -------
	--------------------------------------------- 
	--------------------------------------------------------------------------------------------
	---------- Dati fiscali  Dati per la eventuale compilazione della dichiarazione ------------
	---------------------------------- SEZIONE REDDITI -----------------------------------------
	--------------------------------------------------------------------------------------------
	---- NB. questa sezione va compilata solo per i redditi imponibili ai fini fiscali, --------
	-------------------------------- no assegnisti ---------------------------------------------
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001002 DECIMAL(19,2) -- Redditi di lavoro dipendente e assimilati con contratto a tempo determinato  

	DECLARE	@DB001006 INT			-- Numero di giorni per i quali spettano le detrazioni di lavoro dipendente
 
	DECLARE @DB001008 DATETIME		-- Data inizio Rapporto di Lavoro
	DECLARE @DB001009 DATETIME		-- Data fine Rapporto di Lavoro
	DECLARE @DB001010 INT			-- Casella Barrata "In forza al 31/12"
 	DECLARE @DB001011 INT           -- Periodi Particolari
 
 	-- IL CAMPO SUCCESSIVO RIENTRA NEL RECORD D (HRD, OVVERO NELLA PARTE POSIZIONALE, TUTTAVIA LO VALORIZZIAMO QUI PERCHE'
 	-- ABBIAMO DATI SUFFICIENTI A DETERMINARLO)
 	DECLARE @HRD001011 INT			-- Flag conferma Singola Certificazione per i controlli di rispondenza CB
	SET @DB001002= isnull(@taxablegross,0) 

	-- Conteggio dei giorni lavorati
	-- select * from #workdays 
	-- select * from #contratti
	IF isnull(@taxablegross,0) <> 0
	BEGIN
		SET @DB001006= @workingdays  --GIORNI PER I QUALI SPETTANO LE DETRAZIONI 

		SET @DB001008= @start -- Data inizio Rapporto di Lavoro DEVE INCLUDERE ANCHE I CUD INTERNI DELLA STESSA UNIVERSITA' INSERITI NEL CONTRATTO
		SET @DB001009= @stop  -- Data fine Rapporto di Lavoro Non deve essere valorizzato in caso di continuazione del rapporto di lavoro oltre il 31/12/2021 ricavabile dalla data fine del contratto inserito. N.B.: il campo 9  alternativo al campo 10.
		

		--SET @DB001013= @workingdays_1_semestre --GIORNI - 1 SEMESTRE
		--SET @DB001014= @workingdays_2_semestre --GIORNI - 2 SEMESTRE

		-- "In forza al 31/12"
		IF (@stopitineration > @31dic2025)
			BEGIN
			SET @DB001010	= 1  
			END
		ELSE 
			SET @DB001010	= 0

		IF ((Year(@start) < @annoredditi) and Year(@stop) = @annoredditi and (@workingdays = (datediff(d,@1gen2025_XXX, @stop) + 1)))
			SET @DB001011 = NULL
		ELSE
		BEGIN
			IF (
				(
				-- Rimuovo perch con questa condizione valorizza periodi particolari a 4 e manda in errore la CU. 
				-- ove il codice 4 nelle altre ipotesi in cui non vi sia coincidenza tra il numero dei giorni per i quali spettano le detrazioni e la durata del rapporto di lavoro (vedi task 18245)
				((Year(@start) < @annoredditi) AND (@workingdays < 365)     ) 
				OR
				((Year(@start) < @annoredditi) AND (@workingdays = 365) AND (@stop < @31dic2025)  ) 

				OR (Year(@stop) < @annoredditi   ) 
				OR
					(	-- IN FORZA AL 31 12, con data ultimo cedolino dell'anno inferiore 
						(@stopitineration > @31dic2025)  AND (@stop < @31dic2025) 
					) 
				)	
				)
				AND (@workingdays >0)		
				SET @DB001011 = 4  
			 ELSE 
				BEGIN
					IF   (@workingdays >0) AND	(@workingdays < 365) AND (  (@workingdays <> (datediff(d,@start, @stop) + 1)) )					
						SET @DB001011 = 1 -- PERIODI PARTICOLARI, OVVERO INTERRUZIONI DEL PERIODO DI LAVORO
					ELSE 
						SET @DB001011 = NULL
				END
		END
			
			--Se il Numero totale dei
			--Giorni di detrazione [col.6 + col.7] coincide con il Numero totale dei Giorni
			--di Lavoro non  possibile compilare il campo Periodi Particolari [col.11]
			
			if (	(@workingdays = 365) AND (@stopitineration > @31dic2025) /*IN FORZA AL 31 12*/ )  SET @DB001011 = NULL --- IN TAL CASO NON COMPILIAMO PERIODI PARTICOLARI

			
		-- DICHIARAZIONE DA CONFERMARE: indica anomalie che riguardano il conteggio dei giorni lavorati  @workingdays (@DB001006)
		--- ed eventualmente i giorni lavorati dei due semestri a partire dal 2022
		--- Se data inizio cedolino di conguaglio < anno redditi --> Dichiarazione da confermare
		--- Se lavoratore in forza al 31/12 e, pur non essendovi interruzioni (rappresentato dal flag periodi particolari), il numero dei giorni
		--- lavorati  inferiore al periodo data inizio -- 31/12 --> Dichiarazione da confermare
		--  In caso di periodi particolari non c' bisogno del flag di conferma della dichiarazione
		IF 
		(
			-- NON CI SONO PERIODI PARTICOLARI, OVVERO INTERRUZIONI DEL PERIODO DI LAVORO. 
			(
				(isnull(@DB001011,0) = 0)	
				AND
			(	(year(@start)<@annoredditi)
				OR
				(	-- IN FORZA AL 31 12
					(@stopitineration > @31dic2025)  AND (@stop < @31dic2025)	
				) 
				OR
				(
				   (@stopitineration <= @31dic2025)  AND (@stop < @stopitineration) 
				)
			) 
		)
		OR
			--- la cessazione del rapporto di lavoro prima del 1 luglio 2021 non  compatibile con la 
			--- compilazione giorni lavorati del secondo semestre
			(
				/*(@workingdays_2_semestre) >0 AND*/ (@stop < @01lug2025)
			)
		)	
		 				 					
		SET @HRD001011 = 1 -- richiede conferma della dichiarazione
		ELSE
		SET @HRD001011 = NULL -- non richiede conferma della dichiarazione
 
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '002', @DB001002)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero) VALUES(@progrCom,1,  'DB001', 1, '718', '2')
		-- Redditi dei punti da 1 a 5 al netto dei compensi di campione d'Italia
		--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '772', @DB001002)
		-- PARTICOLARI TIPOLOGIE REDDITUALI 751 e 752
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)	  VALUES(@progrCom,1,  'DB001', 1, '751', '4') 
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1,  'DB001', 1, '752', @DB001002)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '006', @DB001006)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data)	  VALUES(@progrCom,1,  'DB001', 1, '008', @DB001008)
		IF (@stopitineration <= @31dic2025)
		BEGIN
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, data)     VALUES(@progrCom,1,  'DB001', 1, '009', @DB001009)
		END
		ELSE
		BEGIN
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '010', @DB001010)
		END
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '011', @DB001011)
		--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '013', @DB001013)
		--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'DB001', 1, '014', @DB001014)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)   VALUES(@progrCom,1,  'HRD', 1, '11', @HRD001011)
	END

 
	--select * from #recordG  
   	--------------------------------------------------------------------------------------------
   	---------------------------------- SEZIONE RITENUTE ----------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001021 DECIMAL(19,2) -- Ritenute IRPEF
	DECLARE @DB001022 DECIMAL(19,2)	-- Addizionale regionale all'Irpef
	DECLARE	@DB001027 DECIMAL(19,2)	-- Addizionale comunale all'Irpef - Saldo 2021
	-- Si intendono i rapporti cessati entro il 31 12 dell'anno redditi
	DECLARE @DB001024 DECIMAL(19,2)	--  DB001024 Addizionale regionale 2021 rapporti cessati
	DECLARE @DB001028 DECIMAL(19,2)	--  DB001028 Addizionale comunale all'Irpef - Rapporti cessati 2021
	
	SET @DB001021= isnull(@ritenuta_irpef,0)
	SET @DB001022= isnull(@ritenuta_addreg_irpef,0)
	SET @DB001027= isnull(@ritenuta_addcom_irpef_saldo_2025,0)
	
	IF ((year(@stopitineration) = @annoredditi) AND (@stopitineration <= @31dic2025))
	BEGIN
		SET @DB001024= 0 -- isnull(@ritenuta_addreg_irpef,0) per le missioni non gestiamo le addizionali 
		SET @DB001028= 0 -- isnull(@ritenuta_addcom_irpef_saldo_2025,0) per le missioni non gestiamo le addizionali 
	END

	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '021', @DB001021)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '022', @DB001022)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '027', @DB001027)
	IF ((year(@stopitineration) = @annoredditi) AND (@stopitineration <= @31dic2025))
		BEGIN
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '024', @DB001024)
			INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale) VALUES(@progrCom,1, 'DB001', 1, '028', @DB001028)
		END
	
	
	--------------------------------------------------------------------------------------------
	-------------------------------- DETRAZIONI E CREDITI --------------------------------------
	--------------------------------------------------------------------------------------------
	DECLARE @DB001361 DECIMAL (19,2)	-- Imposta Lorda
	DECLARE @DB001362 DECIMAL (19,2)	-- Detrazioni per carichi di famiglia
	--DECLARE @DB001363 DECIMAL (19,2)	-- Detrazioni per famiglie numerose
	DECLARE @DB001367 DECIMAL (19,2)	-- Detrazione per lavoro dipendente, pensioni e redditi assimilati
	DECLARE @DB001369 DECIMAL (19,2)	-- Totale Detrazioni per oneri
	DECLARE @DB001374 DECIMAL (19,2)	-- Totale detrazioni
	DECLARE @DB001375 DECIMAL (19,2)	-- Imposta netta

	SET @DB001361= isnull(@employtaxgross,0)
	SET @DB001362= isnull(@detrazioni_familiari_a_carico,0)
	SET @DB001367= isnull(@detrazioni_per_reddito,0)
	SET @DB001369= 0 -- Totale Detrazioni per oneri non le calcoliamo per le missioni
	SET @DB001374= isnull(@totale_detrazioni,0)
	SET @DB001375= isnull(@employtaxgross,0) - isnull(@totale_detrazioni,0)

	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '361', @DB001361)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '362', @DB001362)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '367', @DB001367)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '369', @DB001369)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '374', @DB001374)
	INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '375', @DB001375)
	--select * from #recordG  
		--------------------------------------------------------------------------------------------
	---------------- SEZIONI CREDITO BONUS IRPEF E TRATTAMENTO INTEGRATIVO---------------------- 
	--------------------------------------------------------------------------------------------
	---------- NB. Questa sezione va compilata solo per redditi imponibili ai fini IRPEF -------
	---  non per assegnisti e prestazioni esenti , dove mettiamo solo dati previdenziali -------
	--------------------------------------------------------------------------------------------
	------------ I CAMPI RELATIVI AD ALTRI SOSTITUTI DI IMPOSTA VANNO OMESSI -------------------
	---------------------- PER QUEST'ANNO IN QUANTO NON VE NE SONO -----------------------------
	--------------------------------------------------------------------------------------------
	
	DECLARE @DB001391disuso INT				-- CREDITO BONUS IRPEF - Codice Bonus Vale 1 o 2
	DECLARE @DB001392disuso DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus erogato
	DECLARE @DB001393disuso DECIMAL (19,2)	-- CREDITO BONUS IRPEF - Bonus non erogato
 
	DECLARE @DB001390 INT				-- TRATTAMENTO INTEGRATIVO - Codice Bonus Vale 1 o 2
	DECLARE @DB001391 DECIMAL (19,2)	-- TRATTAMENTO INTEGRATIVO - Trattamento erogato
	DECLARE @DB001392 DECIMAL (19,2)	-- TRATTAMENTO INTEGRATIVO - Trattamento non erogato

	IF ISNULL(@taxablegross,0) <> 0   
	BEGIN
		IF ISNULL(@bonus_fiscale,0)  = 0 
		BEGIN
			SET @DB001391disuso= 2 -- non riconosciuto
			SET @DB001392disuso= 0
			SET @DB001393disuso= 0
		END
		ELSE
		BEGIN
			SET @DB001391disuso= 1 --  riconosciuto
			SET @DB001392disuso= @bonus_fiscale
			SET @DB001393disuso= 0
		END

		 --Per la compilazione del punto 400  necessario utilizzare uno dei seguenti codici:
		 --			1. se il sostituto dimposta ha riconosciuto al dipendente il trattamento integrativo e lo ha erogato tutto o in parte;
		 --			2. se il sostituto dimposta non ha riconosciuto al dipendente il trattamento integrativo ovvero lo ha riconosciuto, ma non lo ha erogato
		IF ISNULL(@bonus_fiscale_integrativo,0)  = 0 
		BEGIN
			SET @DB001390= 2 -- non riconosciuto
			SET @DB001391= 0
			SET @DB001392= 0
		END
		ELSE
		BEGIN
			SET @DB001390= 1 --  riconosciuto
			SET @DB001391= @bonus_fiscale_integrativo
			SET @DB001392= 0
		END
	 

		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DB001', 1, '390', @DB001390)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '391', @DB001391)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DB001', 1, '392', @DB001392)
	END
	--select * from #recordG  

	----------------------------------------------------------------------------------------------------------------
	----------- Dati previdenziali ed assistenziali  SEZIONE 3 "INPS GESTIONE SEPARATA PARASUBORDINATI" ------------
	----------------------------------------------------------------------------------------------------------------
	--	SEZIONE 3 "INPS GESTIONE SEPARATA PARASUBORDINATI"

	IF
	((SELECT	COUNT(*)
		FROM	#ser
		WHERE 	#ser.servicecode770 <> '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@compensoprev,0) > 0))
	BEGIN
		--DECLARE @DC001001	VARCHAR(10)		-- Matricola azienda N10
		DECLARE @DC001045	DECIMAL (19,2)	-- Compensi corrisposti sul parasubordinatoVP
		DECLARE @DC001046	DECIMAL (19,2)	-- Contributi Dovuti VP
		DECLARE @DC001047	DECIMAL (19,2)	-- Contributi a carico del lavoratore VP
		DECLARE @DC001048	DECIMAL (19,2)	-- Contributi versati VP
		DECLARE @DC001049	INT				-- Mesi per i quali  stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DC001050	VARCHAR(12)		-- singoli mesi
		DECLARE @DC001051	VARCHAR(2)		-- Tipo rapporto Emens
		
		--SET @DC001001 = @agencynumber 
		SET @DC001045= isnull(@compensoprev,0)
		SET @DC001046= isnull(@ritprevdovuta,0)
		SET @DC001047= isnull(@ritprevtrattenuta,0)
		SET @DC001048= isnull(@ritprevpagata,0)
		SET @DC001049= isnull(@emensTuttiIMesi,0)
		SET @DC001050= @mesiSenzaEmens
		SET @DC001051= @idemenscontractkind
		--exec exp_certificazioneunica_g_17 21,1
		--INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '001', @DC001001)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '045', @DC001045)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '046', @DC001046)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '047', @DC001047)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '048', @DC001048)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '049', @DC001049)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '050', @DC001050)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '051', @DC001051)
	END
	------------------------------------------------------------------------------------------------------------------------------
	---------------------------------------- Sezione 2 - INPS GESTIONE DIPENDENTI PUBBLICI ---------------------------------------
	------------------------------------------------------------------------------------------------------------------------------
	IF
	((SELECT COUNT(*)
		FROM #ser
		WHERE 	#ser.servicecode770 = '14_DIPENDPUBBLICI'
	) 
	> 0 
	AND
	(isnull(@taxablegross_dipendentipubblici,0) > 0))
	BEGIN

		
		--DC001	017	2018-01-11 14:43:42.773	assistenza	Anno di riferimento
		--DC001	018	2018-01-11 14:43:42.773	assistenza	Imponibile pensionistico
		--DC001	019	2018-01-11 14:43:42.773	assistenza	Contributi pensionistici dovuti
		--DC001	020	2018-01-11 14:43:42.773	assistenza	Contributi pensionistici a carico lavoratore trattenuti
		--DC001	021	2018-01-11 14:43:42.773	assistenza	Imponibili TFS
		--DC001	022	2018-01-11 14:43:42.773	assistenza	Contributi TFS
		--DC001	023	2018-01-11 14:43:42.773	assistenza	Contributi TFS a carico lavoratore trattenuti
		--DC001	024	2018-01-11 14:43:42.773	assistenza	Imponibile TFR
		--DC001	025	2018-01-11 14:43:42.773	assistenza	Contributi TFR dovuti 
		--DC001	026	2018-01-11 14:43:42.773	assistenza	Imponibile Gestione Credito
		--DC001	027	2018-01-11 14:43:42.773	assistenza	Contributo Gestione Credito dovuti
		--DC001	028	2018-01-11 14:43:42.773	assistenza	Contributo Gestione Credito trattenuti a carico del lavoratore

		--DC001037 Codice fiscale soggetto denuncia CF
		--DC001038 Periodi retributivi soggetto denuncia CB12 prendo dal 36 oppure spuntarli tutti se barrato il 35
		--DC001039 Codice fiscale conguaglio CF
		--DC001040 Imponibile conguaglio V

		DECLARE @DC001009	VARCHAR(16)	    -- Codice fiscale Amministrazione	  
		DECLARE @DC001010	VARCHAR(10)		-- Progressivo azienda
		DECLARE @DC001012	INT				-- Gestione Pensionistica
		DECLARE @DC001014	INT				-- Gestione Credito
		DECLARE @DC001017	INT				-- Anno di riferimento	
		DECLARE @DC001018	DECIMAL (19,2)	-- Imponibile pensionistico	
		DECLARE @DC001019	DECIMAL (19,2)	-- Contributi pensionistici dovuti
		DECLARE @DC001020	DECIMAL (19,2)	-- Contributi pensionistici a carico lavoratore trattenuti
		DECLARE @DC001026	DECIMAL (19,2)	-- Imponibile TFR ulteriori elementi  (NON GESTITO)
		DECLARE @DC001027	DECIMAL (19,2)  -- Contributo TFR ulteriori elementi  (NON GESTITO)

		DECLARE @DC001028	DECIMAL (19,2)	-- Imponibile Gestione Credito
		DECLARE @DC001029	DECIMAL (19,2)	-- Contributo Gestione Credito dovuti
		DECLARE @DC001030	DECIMAL (19,2)	-- Contributo Gestione Credito trattenuti a carico del lavoratore
		DECLARE @DC001037	INT				-- Mesi per i quali  stata presentata la denuncia UniEmens - Tutti CB
		DECLARE @DC001038	VARCHAR(12)		-- Mesi per i quasi  stata presentata la denuncia UniEmens - Tutti con esclusione di
		DECLARE @DC001039	VARCHAR(16)	    -- Codice fiscale soggetto denuncia
		DECLARE @DC001040	VARCHAR(12)		-- Periodi retributivi soggetto denuncia CB12, opposto di @mesiConEmensdipendentipubblici
		
		SET @DC001009 =	@codfiscEnte -- Codice fiscale Amministrazione	  
		SET @DC001010 = '00000'   -- Progressivo azienda
		SET @DC001012 = 1		  -- Gestione Pensionistica
		SET @DC001014 = 9         -- Gestione Credito
		SET @DC001017 = @annoredditi   -- Anno di riferimento	
		SET @DC001018 = @taxablegross_dipendentipubblici			  -- Imponibile pensionistico		
		SET @DC001019 = @ritenuta_previdenziale_dipendentipubblici	  -- Contributi pensionistici dovuti
		SET @DC001020 = @ritenuta_previdenziale_dipendentipubblici_dip	  -- Contributi pensionistici a carico lavoratore trattenuti
		SET @DC001028 = @taxablegross_fondocredito_dipendentipubblici -- Totale imponibile Gestione Credito
		SET @DC001029 = @ritenuta_fondocredito_dipendentipubblici     -- Contributo Gestione Credito dovuti
		SET @DC001030 = @ritenuta_fondocredito_dipendentipubblici_dip -- Contributo Gestione Credito trattenuti a carico del lavoratore (fondo credito carico dipendente)
		
		SET @DC001037 = isnull(@emensTuttiIMesidipendentipubblici,0)  -- Mesi per i quali  stata presentata la denuncia UniEmens - Tutti CB
		SET @DC001038 = @mesiConEmensdipendentipubblici			  -- Mesi per i quasi  stata presentata la denuncia UniEmens - non  pi quelli esclusi, ma i mesi inclusi
		SET @DC001039 =	@codfiscEnte --  Codice fiscale soggetto denuncia
		SET @DC001040 = @periodiretributivisoggettodenuncia
	
 		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '009', @DC001009)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '010', @DC001010)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '012', @DC001012)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '014', @DC001014)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '017', @DC001017)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '018', @DC001018)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '019', @DC001019)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '020', @DC001020)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '028', @DC001028)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '029', @DC001029)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, decimale)	VALUES(@progrCom, 1, 'DC001', 1, '030', @DC001030)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, intero)		VALUES(@progrCom, 1, 'DC001', 1, '037', @DC001037)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '038', @DC001038)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '039', @DC001039)
		INSERT INTO #recordG (progr, modulo, quadro, riga, colonna, stringa)	VALUES(@progrCom, 1, 'DC001', 1, '040', @DC001040)
	END 
 	 
	
------------------------------------------------------------------------------------------------------------------
------------------------------------ INSERIMENTO DELLE ANNOTAZIONI -----------------------------------------------
------------------------------------------------------------------------------------------------------------------
	--AC  La detrazione per carichi di famiglia  stata calcolata in relazione alla durata del rapporto di lavoro.
	--Nel caso di rapporto di lavoro inferiore allanno solare, il sostituto calcola la detrazione 
	--per carichi di famiglia in relazione al periodo di lavoro, salvo che il sostituito non abbia richiesto 
	--espressamente di poterne fruire per lintero periodo di imposta (qualora ne ricorrano i presupposti). 
	--Nel caso in cui le suddette detrazioni siano state determinate in relazione al periodo di lavoro, 
	--il sostituto ne deve dare comunicazione al percipiente nelle annotazioni (cod. AC).
	--------------- NOI LE APPLICHIAMO SEMPRE PER INTERO PERCIO' QUESTE ANNOTAZIONI NON VANNO SCRITTE ----------------- 
	-------------------------------------------------------------------------------------------------------------------

	--AI - Informazioni relative al reddito/i certificato/i: tipologia (), data inizio e data fine per ciascun periodo di lavoro o pensione (), importo ( ).
	--Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, rapporto a tempo determinato, data inizio e data fine per ciascun periodo di lavoro dal . Al .  importo euro ..
	--(Da valorizzare ogni volta che  valorizzato il campo 1 Redditi di lavoro dipendente e assimilati....)

	--BW Redditi esentati da imposizione in Italia in quanto il percipiente risiede in uno Stato estero: importo del reddito esente percepito ()
	--in questa confluiscono le vecchie AJ nel caso in cui il codice di esenzione indicato nel campo 468 sia pari a 3.

	--"AL - Le addizionali regionali e comunali sono state interamente trattenute. "
	--(Costante quando i campi relativi alle addizionali comunali e regionali sono stati valorizzati)

	--"AN - La detrazione minima  stata ragguagliata al periodi di lavoro. Il percipiente pu fruire della detrazione per l'intero anno in sede di dichiarazione dei redditi, semprech non sia stata gi attribuita da un altro datore di lavoro e risulti effettivamente spettante."
	--(Nel caso di rapporti di lavoro a tempo determinato o a tempo indeterminato di durata inferiore allanno (inizio o cessazione del rapporto di lavoro nel corso dellanno), limitatamente ai contratti in cui  stato scelto di applicare la detrazione)

	--"AR - Dettaglio oneri deducibili: descrizione onere, importo. Tali importi non vanno riportati nella dichiarazione dei redditi"
	--(Nel contratto abbiamo la possibilit di inserire gli oneri deducibili)

	--"AX - Reddito assimilato assoggettato a ritenuta a titolo d'imposta, indicare importo, indicare ritenuta a titolo d'imposta operata."
	--(Valorizzare quando il compenso  un parasubordinato ed  associata ad una ritenuta IRPEF del 30%. La stessa condizione che abbiamo quando valorizziamo il campi del modello 221 e 222)

	--"BB - Saldo dell'addizionale comunale all'IRPEF non operata in quanto in possesso dei requisiti reddituali per usufruire interamente della fascia di esenzione deliberata"
	--(Da indicare quando non si calcola l'addizionale comunale all'IRPEF perch il reddito rientra nei limiti di esenzione. Ad esempio se il comune prevede una fascia di esenzione dell'addizionale comunale all'IRPEF)

	--"ZZ - Redditi totalmente esentati da imposizione in Italia: indicare Importo del reddito."
	--(Qundo si usa una prestazione che non abbia il falg in tipo prestazione sull'opzione "Per residenti all'estero" e la prestazione non ha ritenute fiscali associate)

	--ZZ - Il percipiente dovr procedere ad effettuare le operazioni di conguaglio in sede di dichiarazione dei redditi in quanto i redditi certificati non sono stati oggetto di conguaglio da parte del sostituto.
	-- (Quanto  stato erogato un cedolino di conguaglio riepilogativo fittizio)
	
	DECLARE @NN VARCHAR(400)
	DECLARE @contamissioni int
	SET @contamissioni = 1
	DECLARE @contamissioniconvenzione int
	SET @contamissioniconvenzione = 1
	DECLARE @offset_ai int
	SET @offset_ai = 2

	DECLARE @ai_inserted char(1)
	SET @ai_inserted = 'N'

	DECLARE @aj_inserted char(1)
	SET @aj_inserted = 'N'

	DECLARE @ec_taxablegross decimal(19,2)
	DECLARE @ec_start datetime
	DECLARE @ec_stop datetime
	DECLARE @ec_idlinkedit varchar(8)
 
	--- Cosimo dice di non compiare le annotazioni AI
	--  Il cursore seleziona tutti le missioni rientranti nella certificazione
	/*
	DECLARE #it_crs INSENSITIVE CURSOR FOR
	SELECT
		#missioni.fiscaltaxablegross,
		#missioni.start, #missioni.stop, #missioni.iditineration,
		#missioni.servicecode770
	FROM #missioni
	FOR READ ONLY
	
	--select * from #missioni
	 
	OPEN #it_crs
	FETCH NEXT FROM #it_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedit,@servicecode770

	WHILE(@@FETCH_STATUS = 0)
	BEGIN
		IF (@ec_idlinkedit IS NOT NULL) 
		AND
		(SELECT COUNT(*)
		FROM #ser
		JOIN service
			ON #ser.idser = service.idser)> 0
		AND ISNULL(@taxablegross,0) > 0
		BEGIN
			---------------------------------------------------------
			------------------- NOTE AI -----------------------------
			---------------------------------------------------------
			
			-- Note 
			SELECT @NN = 
				CASE 
					WHEN  @servicecode770 = '07_BRS_GEN' 
					THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c) D.P.R. 917/86, '
					WHEN  @servicecode770 IN ('07_COPENOINPS', '05_COORDM', '16_COORDM_DS','16_COORDM_AS',
									   '05_COORDN', '16_COORDN_DS','16_COORDN_AS',
					                   '05_COORDP', '05_COSTCON', '05_CORNOINPS', '05_COORDN_L.326/03', 
					                   '08_COSTCON_NOINPS', '10_COSTCONMUT', 
					                   'N_VISITINGPROFESSOR', 'M_VISITINGPROFESSOR', '14_COORNM10%IRPEF')
					THEN 'AI - Reddito assimilato al lavoro dipendente art. 50 lettera c-bis) D.P.R. 917/86, '
					ELSE 'AI - Reddito assimilato al lavoro dipendente art. 50 D.P.R. 917/86, ' 
				END
				 +
				'Rapporto a tempo determinato,  da ' + CONVERT(varchar(16), @ec_start, 105) + ' a ' + CONVERT(varchar(16), @ec_stop, 105) + 
			 +  ' Importo:  ' + CONVERT(varchar(16), @ec_taxablegross)  
			-- [Nota AI] (Questa nota  sicuramente presente almeno per il contratto principale)
			-- 
			INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
				VALUES(@progrCom, 'NN', 1, @contamissioni, '001', @NN)
		END
	
 
		FETCH NEXT FROM #it_crs INTO @ec_taxablegross, @ec_start, @ec_stop, @ec_idlinkedit,@servicecode770
		SET @contamissioni = @contamissioni + 1
		END
		
		CLOSE #it_crs
		DEALLOCATE #it_crs
		*/


	--------------------------------------------------------------------------------------------
	-- AM - "Rimborsi effettuati dal sostituto a seguito di assistenza fiscale"  NON APPLICABILE 
	-- (verificare la presenza nel contratto dei rimborsi IRPEF da CAF) ------------------------
    --------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------
	-- "AN - La detrazione minima  stata ragguagliata al periodi di lavoro. NON APPLICABILE ---- 
	 
	IF 
	(( @ritprevtrattenuta <> 0)  -- @ritprevtrattenuta
	 OR 
     (@ritprevpagata <> 0)) --@ritprevpagata
	BEGIN
		SET @NN =
		'ZZ - Le ritenute INPS trattenute ai sensi della Legge 335/95 art.2/c.26 e Legge 449/97 art.59/c.16' +
		' sono state regolarmente versate all''INPS: ' +
		' ritenute a carico percipiente: ' + char(128) + CONVERT(varchar(16), @ritprevtrattenuta)  +
		--' ritenute a carico percipiente: ' + Format(@ritprevtrattenuta,'C','it-it')  collate Latin1_General_CS_AS +
		' e ritenute a carico ente: ' + char(128) +  + CONVERT(varchar(16), @ritprevamministrazione)
 		--' e ritenute a carico ente: ' +  FORMAT( @ritprevamministrazione,'C','it-it') collate Latin1_General_CS_AS
		INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
			 VALUES(@progrCom, 'NN', 1, 1, '009', @NN)
	END
	ELSE
	BEGIN
		SET @NN = (SELECT 'ZZ - Il percipiente dovra procedere ad effettuare le operazioni di conguaglio in sede di dichiarazione dei redditi in quanto i redditi certificati non sono stati oggetto di conguaglio da parte del sostituto.')
		INSERT INTO #recordg (progr, quadro,modulo, riga, colonna, stringa)
							VALUES(@progrCom, 'NN', 1,1 ,'009', @NN collate  SQL_Latin1_General_CP1_CI_AS  )
	END 
 
	
	SET @NN = 'ZZ - Si consiglia di presentare la dichiarazione dei redditi (mod. 730 o RedditiPF) per effettuare eventuali operazioni di conguaglio non effettuate dal sostituto d''imposta. '
	INSERT INTO #recordg (progr, quadro, modulo, riga, colonna, stringa)
		VALUES(@progrCom, 'NN', 1, 1, '011', @NN)

--	SELECT * FROM #recordG 

IF (@print = 'S')
BEGIN
	SELECT * FROM #recordG 
	WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL OR decimale<>0
END
ELSE
BEGIN
	SELECT * FROM #recordG 
	WHERE (stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL OR decimale<>0)
	AND ltrim(rtrim(quadro)) <> 'NN'
END
END
GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 
 

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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_detrazioni_reddito]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_detrazioni_reddito]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser 'amministrazione'


CREATE   procedure check_detrazioni_reddito (
@idreg int,
@annoredditi smallint,
@applicamassimalesuigglavorati char(1) = 'S',  -- S --> Applica il massimale detrazione spettante per fascia reddito ridotto in base ai giorni effettivi lavorati (base nn. giorni lavorati)
								         -- N --> Applica il massimale detrazione assoluto per fascia reddito (base 365/366 giorni se bisestile)
@res int out
) as
BEGIN
	set @res=0
	SET NOCOUNT ON;

	declare @1gen15_XXX datetime
	set @1gen15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})
	declare @31dic15_XXX datetime
	set @31dic15_XXX = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	create table #service ( idser int)
	insert into #service
	select distinct idser from service
	where  (service.rec770kind='G') 
	AND NOT EXISTS (SELECT * FROM servicetaxview
				       WHERE servicetaxview.idser = service.idser  AND servicetaxview.taxref IN ('08_IRPEF_FOC','07_IRPEF_FO'))

	-- Tabella dei cedolini
	create table #cedolini (
		idpayroll int, 
		idcon varchar(8),
		startpayroll datetime,
		stoppayroll datetime,
		islastpayroll char(1)-- S/N: indica se trattasi di ultimo cedolino. Le detrazioni da CUD verranno sommate solo se non è ultimo cedolino
	)

	-- Riempimento della tabella dei cedolini.
	-- Vengono inseriti tutti i cedolini trasmessi associati ai contratti del percipiente dell'anno dei redditi.
	-- Di questi cedolini si seleziona il movimento di spesa che li contabilizza, la data di trasmissione,
	-- la data di inizio e fine ed il contratto di appartenenza.
	insert into #cedolini 	(idpayroll, idcon, startpayroll, stoppayroll, islastpayroll)
	SELECT
		payroll.idpayroll,  payroll.idcon, payroll.start, payroll.stop,
		-- Se il cedolino ha lo stesso npayroll del cedolino di conguaglio, vuol dire che è l'ultimo cedolino rata
		case when payroll.npayroll = (	SELECT P.npayroll FROM payroll P
									WHERE P.idcon =parasubcontract.idcon
									AND P.fiscalyear = @annoredditi AND P.flagbalance = 'S')
									then 'S'
			else 'N'
		end
	from payroll					
	join parasubcontract			on payroll.idcon= parasubcontract.idcon
	JOIN parasubcontractyear im		ON parasubcontract.idcon = im.idcon AND im.ayear = @annoredditi
	JOIN service					ON service.idser = parasubcontract.idser
	JOIN #service   ON #service.idser = service.idser
	where	fiscalyear=@annoredditi 
			and parasubcontract.idreg = @idreg
			and payroll.flagcomputed='S'
			AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
			AND (service.rec770kind='G')
			AND payroll.flagsummarybalance='N'
			AND payroll.flagbalance='N'


	-- Tabella dei contratti parasubordinati coinvolti
	create table #contratti
	(
		idcon varchar(8),
		padre varchar(8),
		start datetime, -- Data inizio del cedolino di conguaglio
		stop datetime, -- Data fine del cedolino di conguaglio
		stopcontract datetime, -- Data Fine del Contratto
		capofila char(1),
		idser int
	)

	-- Si inseriscono i contratti del percipiente corrente.
	-- per la Certificazione Unica
	-- Vengono presi tutti i contratti di un fissato percipiente per i quali esiste almeno un cedolino che sia stato trasmesso
	-- nell'anno dei redditi. Inoltre la prestazione del contratto al quale il cedolino è associato deve essere associata
	-- al quadro G del 770 (rec770kind = 'G'). Altri dati ricavati sono l'imponibile previdenziale, l'INPS e INAIL trattenuti
	-- le deduzioni, l'imponibile fiscale lordo del contratto e l'id e la data di fine del cedolino di conguaglio.
 
	INSERT INTO #contratti
				(idcon,  stopcontract, 
				idser)
	SELECT
		co.idcon,
		co.stop,	 co.idser
	FROM  parasubcontract co						
   	JOIN parasubcontractyear im		ON co.idcon = im.idcon AND im.ayear = @annoredditi
    
	JOIN service								ON service.idser = co.idser
	LEFT OUTER JOIN motive770service			ON service.idser = motive770service.idser
													AND motive770service.ayear = @annoredditi
	JOIN (SELECT DISTINCT #cedolini.idcon FROM #cedolini) AS c on c.idcon = co.idcon
 
	
	DECLARE @stopcontract datetime
	SELECT 	@stopcontract  = MAX(stopcontract)  FROM #contratti	

	
	-- Si aggiorna la catena tra contratti scaturita dall'uso dei CUD.
	-- La catena si aggiorna impostando il campo PADRE della tabella #contratti, dove nel campo PADRE si inserisce 
	-- sul contratto puntato dal CUD il contratto contenitore del CUD
	-- Esempio:
	-- Contratto 10
	-- Contratto 11
	-- CUD inserito nel contratto 11 riferito al contratto 10
	-- Il contratto 10 avrà come padre il contratto 11
	UPDATE #contratti	SET padre = exhibitedcud.idcon
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
 
	UPDATE #contratti		SET capofila = 'S'		WHERE #contratti.padre IS NULL

	UPDATE #cedolini	SET islastpayroll = 'N'		WHERE idcon in (select idcon from #contratti where isnull(#contratti.capofila,'N') = 'N')
	--select * from #contratti
	-- Tabella dei giorni lavorati
	create table #workdays 	(giorno smalldatetime, worked char(1)) 
	DECLARE @1gen00 datetime
	SET @1gen00 = DATEADD(yy, @annoredditi-2009, {d '2000-01-01'})

	declare @giorno smalldatetime
	set @giorno=@1gen00
	WHILE (datepart(year,@giorno)<=@annoredditi)
	BEGIN
		insert into #workdays(giorno) values (@giorno)
		set @giorno=DATEADD(dd,1,@giorno)
	END


	-- Calcolo dei giorni lavorati
	-- Si settano tutti i giorni a NON LAVORATI
	update #workdays set worked='N'
	-- Si settano tutti i giorni rientranti nella durata dei cedolini a LAVORATI
	update #workdays set worked='S' where exists
		(SELECT * from #cedolini
		JOIN #contratti				ON #contratti.idcon = #cedolini.idcon
		WHERE #workdays.giorno BETWEEN #cedolini.startpayroll AND #cedolini.stoppayroll
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

--SELECT '#cedolini',* FROM #cedolini
--SELECT '#contratti',* FROM #contratti
--SELECT '#workdays', year(giorno) , count(*) as  giornilavorati FROM #workdays 
--group by worked,year(giorno) 
--having worked='S' 
	declare @onerisostenutiinaltricontratti dec(19,2)
	SET @onerisostenutiinaltricontratti =
	ISNULL(
		(SELECT 
			ISNULL(SUM(exhibitedcud.taxablepension),0) -
			ISNULL(SUM(exhibitedcud.taxablegross),0)
		FROM exhibitedcud 
		JOIN #contratti  ON #contratti.idcon = exhibitedcud.idcon
		WHERE #contratti.padre IS NULL
					AND exhibitedcud.fiscalyear = @annoredditi)
	,0)



	-- Calcolo dei redditi ai quali si possono applicare le deduzioni art. 11 e imposta lorda
	-- Esso è pari alla somma degli imponibili lordi delle ritenute fiscali nazionali associate ai
	-- contratti del percipiente. I contratti da considerare sono solo quelli associati alla certificazione
	-- CUD che non sono diventati a loro volta CUD per altri contratti. Si scartano le ritenute con codice
	-- 08_IRPEF_FOC e 07_IRPEF_FO in quanto sono ritenute applicate a stranieri che non rientrano in questo calcolo
	-- L'imposta lorda è pari alla somma delle ritenute (il filtro è quello descritto precedentemente), tant'è che la
	-- query è la medesima
 


	DECLARE @taxablegross	DECIMAL(19,2)
	DECLARE @employtaxgross DECIMAL(19,2)
	DECLARE @deduzioni		DECIMAL(19,2)
	SELECT  @employtaxgross = SUM(cr.employtaxgross),	
			@deduzioni = SUM(cr.deduction),	
			@taxablegross   = SUM (cr.taxablegross)
	FROM	#cedolini P
	JOIN #contratti 		ON #contratti.idcon = P.idcon
	JOIN 	payrolltax cr on cr.idpayroll= P.idpayroll
	JOIN	tax ON cr.taxcode = tax.taxcode  AND taxkind = 1	AND geoappliance IS NULL
	WHERE   tax.taxref <> '14_BONUS_FISCALE'  AND #contratti.padre IS NULL
 
	set @deduzioni = isnull(@deduzioni,0)
	set @taxablegross = isnull(@taxablegross,0)

	-- Calcolo della detrazione per reddito
	-- Essa è pari alla somma delle detrazioni applicate sui cedolini associati ai contratti
	-- non divenuti CUD per altri e la cui prestazione ricade nella cetificazione CUD
	-- Si considera ovviamente la sola detrazione con codice 29 che si riferisce al reddito
	DECLARE @detrazioni_per_reddito DECIMAL(19,2)
	DECLARE @detrazioni_per_reddito_cud DECIMAL(19,2)

--select payrollabatement.curramount as 'detrazioni_per_reddito',payrollabatement.idpayroll,#cedolini.idcon, annualamount,  curramount
--		FROM payrollabatement
--		join abatement A on payrollabatement.idabatement = A.idabatement
--		JOIN #cedolini					ON #cedolini.idpayroll = payrollabatement.idpayroll
--		JOIN #contratti 		ON #contratti.idcon = #cedolini.idcon
--		WHERE A.evaluatesp ='calcola_detrazione_reddito'
--		AND #contratti.padre IS NULL

	SELECT @detrazioni_per_reddito = SUM(payrollabatement.curramount)
		FROM payrollabatement
		join abatement A on payrollabatement.idabatement = A.idabatement
		JOIN #cedolini					ON #cedolini.idpayroll = payrollabatement.idpayroll
		JOIN #contratti 		ON #contratti.idcon = #cedolini.idcon
		WHERE A.evaluatesp ='calcola_detrazione_reddito'
		AND #contratti.padre IS NULL


	 -- calcolo le detrazioni per reddito da CUD escludendo le ritenute Bonus
	 SELECT @detrazioni_per_reddito_cud = ISNULL(SUM(exhibitedcud.earnings_based_abatements),0) 
		FROM exhibitedcud 
		JOIN #contratti  ON #contratti.idcon = exhibitedcud.idcon
		WHERE #contratti.padre IS NULL
					AND exhibitedcud.fiscalyear = @annoredditi
-- le detrazioni da CUD verranno considerate solo se per il contratto non è stato calcolato anche l'ultimo cedolino
			and not exists (select * from #cedolini CD 
							where CD.idcon =  #contratti.idcon
							and	islastpayroll = 'S')


        SET @detrazioni_per_reddito = ISNULL(@detrazioni_per_reddito,0) + ISNULL(@detrazioni_per_reddito_cud,0)

--select ISNULL(@detrazioni_per_reddito,0) as '@detrazioni_per_reddito(comprensivo di CUD)' 

	declare @giorni_anno int
	set @giorni_anno = 365
	if  ((@annoredditi % 4 = 0) and (@annoredditi % 100 != 0)) or (@annoredditi % 400 = 0) begin
		set @giorni_anno = 366
	end

	-- Conteggio dei giorni lavorati
	DECLARE @workingdays INT
	SELECT @workingdays = count(*) from #workdays where worked='S'

	-- Se i giorni lavorati superano l'anno si pongono pari al numero di giorni dell'anno
	-- non è contemplato, a quanto pare, l'anno bisestile
	IF @workingdays>@giorni_anno 
	BEGIN
		SET @workingdays=@giorni_anno
	END

	--select @workingdays as 'giorni lavorati @workingdays', @giorni_anno as 'giorni dell''anno   ' 

	-- Sono i redditi CUD da ALTRI soggetti, sono qui CUD inseriti 'a mano'
	DECLARE @totale_redditi_da_cud DECIMAL(19,2)
	SET @totale_redditi_da_cud  = --@DB001301
					ISNULL(
						(SELECT SUM(taxablegross)
						FROM exhibitedcud
						JOIN #contratti 		ON #contratti.idcon = exhibitedcud.idcon
						WHERE			fiscalyear = @annoredditi 
							AND idlinkedcon is null

							)
					,0)

	set @totale_redditi_da_cud = isnull(@totale_redditi_da_cud,0)

	declare @massimale decimal(19,2)

	declare @totale_reddito decimal (19,2)
	set @totale_reddito = @taxablegross - @deduzioni + @totale_redditi_da_cud

	--SELECT @taxablegross as '@taxablegross', @totale_redditi_da_cud as '@totale_redditi_da_cud',  @totale_reddito as '@totale_reddito=@taxablegross-@deduzioni+@totale_redditi_da_cud'	


	declare @maxdetrazione decimal(19,2)
	set @maxdetrazione = 0

	-- Per la prima fascia la minima detrazione non è 690 ma 1380 perché sono lavoratori a tempo determinato
    declare @min_detrazione decimal
	set @min_detrazione = 1380 

	declare @max_fascia1 decimal(19,2) -- reddito
	set @max_fascia1= 15000

	declare @max_fascia2 decimal(19,2)
	set @max_fascia2= 28000

	declare @max_fascia3 decimal(19,2)
	set @max_fascia3= 50000

	if (@totale_reddito <=@max_fascia1) 
	begin
	--1880 massimale detrazione
	   	 set @maxdetrazione =  1880 --- assoluto su 365 / 366 giorni lavorati
		 --- riproporziona il massimale sui giorni effettivi lavorati
		 if (@applicamassimalesuigglavorati = 'S') 
			begin
				 set @maxdetrazione = 1880 * @workingdays/ @giorni_anno ;
			 End	
		--SELECT 'fascia 1', 	@maxdetrazione	 as '@maxdetrazione', @workingdays as  'giorni lavorati',@giorni_anno as 'giorni nell''anno'
	 
		 --minima detrazione per la prima fascia
		 if (@maxdetrazione <= 1380) BEGIN
                SET @maxdetrazione = 1380;
         end

	end

    if (@totale_reddito >@max_fascia1 and @totale_reddito <=@max_fascia2) 
	begin
		 set @maxdetrazione =  1910    +   (1190 * (28000 - @totale_reddito)) / 13000;

		 --- riproporziona il massimale sui giorni effettivi lavorati
		if (@applicamassimalesuigglavorati = 'S') 
			Begin
			set  @maxdetrazione = @maxdetrazione * @workingdays   / @giorni_anno
			End
		-- SELECT 'fascia 2', 	@maxdetrazione	 as '@maxdetrazione', @workingdays as  'giorni lavorati'
	end
 
	if (@totale_reddito >=@max_fascia2 and @totale_reddito <=@max_fascia3) 
	begin	 
	
		set @maxdetrazione= (1910 * (50000 - @totale_reddito)) / 22000;
		-- riproporziona il massimale sui giorni effettivi lavorati
		if (@applicamassimalesuigglavorati = 'S') 
		Begin
			set  @maxdetrazione =  @maxdetrazione * @workingdays   / @giorni_anno
		End
		--SELECT 'fascia 3', 	@maxdetrazione	 as '@maxdetrazione', @workingdays as  'giorni lavorati'
	end
--select @detrazioni_per_reddito as '@detrazioni_per_reddito', @maxdetrazione as '@maxdetrazione'	
	if (@detrazioni_per_reddito> @maxdetrazione + 1 /*gestiamo tolleranza di un euro*/)BEGIN
		set @res=1

	END
	else
	BEGIN
		set @res=0
	END

	--select @res
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
-- declare @res int

--exec check_detrazioni_reddito  81670  ,2022, 'S', @res out
 

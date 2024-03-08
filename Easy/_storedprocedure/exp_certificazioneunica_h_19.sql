
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_h_19]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_h_19]
GO
 
 --setuser 'amministrazione'
 --declare @newProg int
 --exec exp_certificazioneunica_h_19 148558,1, 'N', @newProg out
 --select @newProg
CREATE PROCEDURE [exp_certificazioneunica_h_19]
 -- estraggo il record H relativo ad un determinato percipiente, il progressivo comunicazione
 -- indica l'ordine all'interno dei percipienti del sostituto d'imposta
(
	 @idreg int,
	 @progrCom int,
	 @print char(1),  -- vale S per la stampa N altrimenti
	 @newprogrCom int out
) 

AS BEGIN
	declare @annodichiarazione int
	set @annodichiarazione = 2019

	declare @annoredditi int
	set @annoredditi = 2018

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	CREATE TABLE #annualpayedrefundH
	(
		payed_lastyear decimal(19,2),
		payed_lastyear_P decimal(19,2),
		payed_total decimal(19,2),
		payed_total_P decimal(19,2),
		payed_prevyears decimal(19,2),
		F_refund_lastyear decimal(19,2),
		P_refund_lastyear decimal(19,2),
		F_refund_total decimal(19,2),
		P_refund_total decimal(19,2),
		F_refund_residual decimal(19,2),
		P_refund_residual decimal(19,2),
		exemptionquota_applied decimal(19,2)
	)

-- Il quadro H è per il lavoro autonomo
	CREATE TABLE #recHNonArrot
	(
		progr int,
		modulo int,
		quadro varchar(6),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		decimfisc decimal(19,2),
		decimprev decimal(19,2),
		intero int,
		data datetime,
		causale varchar(10),
		socialseccode varchar(10) 
	)
	
 
-- Sezione dichiarativa	
	DECLARE @progrModulo int  
	DECLARE @codfiscEnte varchar(16)
	 
	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase
	SELECT @codfiscEnte = cf FROM license
	SET @progrModulo = 1
	CREATE TABLE #expense2018
	(
		idexp int,
		idreg int,
		idser int,
		employtaxamount decimal(19,2),
		motive770 varchar(10),
		socialseccode varchar(10),
		cfagency varchar(16),
		titleagency varchar(512)
	)

	INSERT INTO #expense2018
		(
			idexp,--1
			idreg,--2
			idser,--3
			employtaxamount--6
		)
		SELECT
			expense.idexp,--1
			expense.idreg,--2
			expenselast.idser,--3
			ISNULL((SELECT SUM(employtax) FROM expensetaxofficial 
				WHERE expensetaxofficial.idexp = expense.idexp 
				AND expensetaxofficial.stop IS NULL),0)
		FROM expense
		join expenselast on expense.idexp = expenselast.idexp
		join payment 
			on payment.kpay = expenselast.kpay
		join paymenttransmission
			on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		JOIN service on service.idser=expenselast.idser
		JOIN registry ON expense.idreg = registry.idreg
		WHERE 	registry.idregistryclass <> '10' and registry.idregistryclass <> '24'
			AND year(paymenttransmission.transmissiondate)=@annoredditi
			AND service.rec770kind = 'H'
			AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp)
			+ ISNULL(
				(SELECT SUM(amount) FROM expensevar
				WHERE expensevar.idexp = expense.idexp
				-- AND expensevar.yvar <= @annoredditi  superfluo poiché expense di ultima fase
				AND ISNULL(autokind,0) <> 4)
			,0)) > 0
			and (select count(*) from expensetaxofficial 
			      where expensetaxofficial.idexp=expense.idexp
			      AND   expensetaxofficial.stop IS NULL) > 0
			and expense.idreg = @idreg


	declare @fattoprestazioni char(1)
	set @fattoprestazioni='N'

	update #expense2018 set motive770 = motive770service.idmot,
		socialseccode = motive770service.socialseccode,
		cfagency = mod770_socialsecuritycode.cfagency,
		titleagency=mod770_socialsecuritycode.titleagency
		from motive770service 
		left outer join  mod770_socialsecuritycode 
		ON mod770_socialsecuritycode.socialseccode = motive770service.socialseccode and 
		mod770_socialsecuritycode.ayear = motive770service.ayear 
		where motive770service.idser = #expense2018.idser
		AND motive770service.ayear = @annodichiarazione-1
		
		DECLARE @au1cf varchar(16)
		SELECT  @au1cf =  isnull(cf,p_iva) FROM registry   -- codice fiscale italia  
		WHERE registry.idreg = @idreg

		----------------------------------------------------
		--- Estrazione dati relativi alle somme erogate ----
		----------------------------------------------------
    
		DECLARE @employtaxamount decimal(19,2)
		DECLARE @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale decimal(19,2)
		DECLARE @au07_AltreSommeNonSoggetteARitenuta decimal(19,2)
		DECLARE @au04_ammontarelordocorrisposto decimal(19,2)
		DECLARE @au08_imponibile decimal(19,2)
		DECLARE @idexp int
		DECLARE @idser int
		DECLARE @taxcodefiscale int
		DECLARE @au09_10ritIRPEF decimal(19,2)
		DECLARE @au34_ritprevidenzialeamm decimal(19,2)
		DECLARE @au35_ritprevidenzialedip decimal(19,2)
		DECLARE @au01_causale varchar(10)
		DECLARE @au33_socialseccode varchar(10)
		DECLARE @au29_cfagency varchar(16)
		DECLARE @au30_titleagency varchar(512)

		DECLARE @cfenteprev varchar(16)
		DECLARE @denomenteprev varchar(512)

		DECLARE cursoreexpense CURSOR FOR 
		SELECT 
			#expense2018.employtaxamount,
			#expense2018.idexp,
			#expense2018.idser,
			#expense2018.motive770,
			#expense2018.socialseccode,
			#expense2018.cfagency,
			#expense2018.titleagency 
		FROM #expense2018
		left outer join expenseinvoice 			on #expense2018.idexp = expenseinvoice.idexp
		WHERE isnull(movkind,0) <> 2 --Serve ad escludere le contab. professionali con causale 2 - Contabilizzazione iva documento
									-- per cui possiamo interrogare anche solo expenseinvoice

-- Dobbiamo escludere i pagamenti di 						
		OPEN cursoreexpense
		FETCH NEXT FROM cursoreexpense
			INTO @employtaxamount, @idexp, @idser, @au01_causale, @au33_socialseccode, @cfenteprev,@denomenteprev
	
		DECLARE @contaPrestazioni int
		SET @contaPrestazioni = 1

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SELECT @taxcodefiscale = expensetax.taxcode
				FROM expensetax
				JOIN tax
					ON tax.taxcode = expensetax.taxcode
				WHERE expensetax.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')= 'N'--IS NULL
					

			SELECT @au09_10ritIRPEF = ISNULL(SUM(expensetaxofficial.employtax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
					AND tax.taxkind = 1
					AND isnull(tax.geoappliance,'N')='N'-- IS NULL
					AND expensetaxofficial.stop IS NULL

			SELECT  @au35_ritprevidenzialedip = isnull(SUM(expensetaxofficial.employtax),0),
				@au34_ritprevidenzialeamm = isnull(SUM(expensetaxofficial.admintax),0)
				FROM expensetaxofficial
				JOIN tax
					ON tax.taxcode = expensetaxofficial.taxcode
				WHERE expensetaxofficial.idexp = @idexp
				AND tax.taxkind = 3
				AND expensetaxofficial.stop IS NULL


			
		----------------------------------------------------
		---- Intestazione Record H, parte posizionale ------
		----------------------------------------------------
			

	
		-- AU001004 Ammontare lordo corrisposto = Imponibile Lordo SUM (feegross) di quel percipiente.
		set @au04_ammontarelordocorrisposto=0
	
		DECLARE @spesededucibilifis decimal(19,2)
		DECLARE @imponibilereale decimal(19,2)	
		DECLARE @impon_spesa decimal(19,2)
		DECLARE @impon_contratto decimal(19,2)
		DECLARE @quota_contratto float
		SET @quota_contratto=1

		DECLARE @ycon int
		DECLARE @ncon int
		SET @ycon = null
		SET @ncon = null

		DECLARE @ypro int
		DECLARE @npro int
		SET @ypro = null
		SET @npro = null

	-- calcola @au04_ammontarelordocorrisposto

		SELECT @ycon = ycon, @ncon = ncon
			FROM casualcontract C
			WHERE EXISTS(select * from expensecasualcontract EC
					join expenselink EL on EC.idexp=EL.idparent						
					where EL.idchild=@idexp
						AND C.ycon=EC.ycon and C.ncon=EC.ncon
				)

		IF (@ycon is not null)  -- si tratta di un contratto occasionale
		BEGIN
			DELETE FROM #annualpayedrefundH
			INSERT INTO #annualpayedrefundH (		
				payed_lastyear,
				payed_lastyear_P,
				payed_total,
				payed_total_P,
				payed_prevyears ,
				F_refund_lastyear,
				P_refund_lastyear,
				F_refund_total,
				P_refund_total,
				F_refund_residual,
				P_refund_residual,
				exemptionquota_applied 
			)
			EXEC compute_casualcontract @annoredditi,@ycon,@ncon
			SET @imponibilereale = 
					ISNULL( (SELECT payed_lastyear  from #annualpayedrefundH),0)
				
			SELECT @au04_ammontarelordocorrisposto = 

			ISNULL(
				(SELECT amount 
					FROM expenseyear where idexp=@idexp)				
				,0) +
			ISNULL(
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expensevar v
				WHERE idexp=@idexp					
					AND (ISNULL(v.autokind,0)<>4)					
				)
				,0)
			
			IF EXISTS (SELECT * 
				FROM pettycashoperationcasualcontract 
					WHERE pettycashoperationcasualcontract.ycon = @ycon
					AND pettycashoperationcasualcontract.ncon = @ncon )
			BEGIN
				SET @au04_ammontarelordocorrisposto = @imponibilereale
				
			END
			
			set @quota_contratto =  @au04_ammontarelordocorrisposto/@imponibilereale 

	END
		
	ELSE
	BEGIN
		SELECT @ypro = ycon, @npro = ncon
		FROM profservice  C
		WHERE EXISTS(select * from expenseinvoice EC
		--		expenseprofservice EC
				--join expenselink EL on EC.idexp=EL.idparent						
				join invoice I
					on EC.idinvkind = I.idinvkind and EC.yinv = I.yinv and EC.ninv = I.ninv
				join profservice P
						on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
				where EC.idexp=@idexp
					AND C.ycon=P.ycon and C.ncon=P.ncon)
					
		IF (@ypro is not null)  -- si tratta di un contratto professionale
		BEGIN
		print  @idexp
			SELECT @spesededucibilifis= SUM(amount) from profservicerefund PR
				join profrefund P on PR.idlinkedrefund=P.idlinkedrefund
				WHERE P.flagfiscaldeduction='S' AND
					PR.ycon=@ypro and PR.ncon=@npro
					
				SELECT @imponibilereale =	  
					ISNULL( (SELECT SUM(convert(decimal(19,2),ROUND(taxablenet*isnull(taxabledenominator,1)/isnull(taxablenumerator,1),2)))
					from profservicetax	 
					JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1
				 AND ISNULL(taxablenumerator,0) <> 0),0)
				 +   
				   ISNULL((SELECT SUM(convert(decimal(19,2),taxablenet ))
					from profservicetax	 
					JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1
				AND  ISNULL(taxablenumerator,0) = 0),0)
			-----------------------------------------------------------------------	
			-- IMPONIBILE DELLA SPESA ---------------------------------------------
			-----------------------------------------------------------------------
			select  @impon_spesa = SUM(ET.taxablegross) from expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 	
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
			-----------------------------------------------------------------------
			-----------------------------------------------------------------------
			select  @impon_contratto = taxablegross from profservicetax	
				JOIN tax T ON profservicetax.taxcode=T.taxcode 
				WHERE profservicetax.ycon=@ypro and profservicetax.ncon=@npro and T.taxkind=1		
			SET     @quota_contratto=isnull(@impon_spesa,0)/isnull(@impon_contratto,0)
			
			SELECT  @au04_ammontarelordocorrisposto = 
				ROUND(@quota_contratto*(isnull(@spesededucibilifis,0)+isnull(@imponibilereale,0) ),2)

		END
		ELSE
		BEGIN --MOV. DI SPESA
			SELECT @au04_ammontarelordocorrisposto = 
				MAX(ET.taxablegross)
				FROM expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
		END
	END
		
	--AU001001 Causale
	INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, stringa,causale, socialseccode) VALUES(@progrCom,1, 'AU', 1, '001', @au01_causale,@au01_causale,@au33_socialseccode)

	set @au04_ammontarelordocorrisposto= isnull(@au04_ammontarelordocorrisposto,0)
		
	INSERT INTO  #recHNonArrot(progr,  modulo, quadro, riga, colonna, decimfisc,causale,socialseccode) VALUES(@progrCom,@contaPrestazioni,'AU',1 , '004', 
																											  @au04_ammontarelordocorrisposto,@au01_causale,@au33_socialseccode)

-- AU001005 Somme non soggette a ritenuta per regime convenzionale
-- leggere il feegross delle prestazioni che hanno la ritenuta IRPEF STRANIERI con convenzione. Tali prestazioni hanno ritenuta a zero
	SET @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale=0
	SELECT @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale = ISNULL(SUM(taxablenet),0)
		FROM expensetaxofficial 
		JOIN tax 
			ON tax.taxcode = expensetaxofficial.taxcode
		WHERE expensetaxofficial.idexp = @idexp 
			AND tax.taxkind = 1
			AND taxref ='07_IRPEF_FC'
			AND expensetaxofficial.stop IS NULL
	
	if (@au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale <> 0) 
	BEGIN
		INSERT INTO #recHNonArrot (progr,  modulo, quadro, riga, colonna, decimfisc,causale, socialseccode) 
		VALUES(@progrCom,@contaPrestazioni, 'AU',1 , '005', @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale,@au01_causale,@au33_socialseccode)
	END
---AUX0025 = Imponibile Lordo SUM (feegross) - Imponibile Netto (SUM(taxablenet) da expensetax where (taxkind=1 ossia fiscali)
	set @au07_AltreSommeNonSoggetteARitenuta=0
	SET @au07_AltreSommeNonSoggetteARitenuta = 
					@au04_ammontarelordocorrisposto
					- ISNULL((SELECT SUM(taxablenet) --somma imponibili netti ove la rit fiscale non è zero esclusi stranieri conv.
							FROM expensetaxofficial
				              		join tax
								ON tax.taxcode = expensetaxofficial.taxcode
							where expensetaxofficial.idexp = @idexp
							AND taxkind = 1
							AND employtax<>0
							-- considero le ritenute diverse dalla IRPEF STRANIERI IN CONVENZIONE
							AND taxref <>'07_IRPEF_FC'
							AND expensetaxofficial.stop is null
					),0)
					-- RITENUTA IPREF STRANIERI IN CONVENZIONE, è necessario prenderle a parte poiché per esse la ritenuta è zero
					- @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale
					
	-- 7 - nel caso di erogazione di altri redditi non soggetti a ritenuta ovvero esenti.
	if (@au07_AltreSommeNonSoggetteARitenuta <> 0) 
	BEGIN
		--- AU001006 Codice NP Vale sempre 7 
		--- AU001007 Altre Somme Non Soggette a Ritenuta
		INSERT INTO #recHNonArrot (progr, modulo, quadro, riga, colonna, intero,causale,socialseccode) VALUES(@progrCom,@contaPrestazioni, 'AU', 1, '006', 7,@au01_causale,@au33_socialseccode)
		INSERT INTO #recHNonArrot (progr,  modulo, quadro, riga, colonna, decimfisc,causale, socialseccode) 
		VALUES(@progrCom,@contaPrestazioni, 'AU', 1, '007', @au07_AltreSommeNonSoggetteARitenuta,@au01_causale,@au33_socialseccode)
	END
	

--	AUXXX026 Imponibile
--	AUX026 = AU001004 - AU0010005 - AU001007
	SET @au08_imponibile = @au04_ammontarelordocorrisposto - @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale-@au07_AltreSommeNonSoggetteARitenuta

	INSERT INTO #recHNonArrot (progr, modulo, quadro, riga, colonna, decimfisc,causale,socialseccode) 
	VALUES(@progrCom,@contaPrestazioni, 'AU', 1, '008', @au08_imponibile,@au01_causale,@au33_socialseccode)
	DECLARE @certificatekind char
	SET 	@certificatekind = null
	SELECT 	@certificatekind = certificatekind from service where idser = @idser

	DECLARE @colonna varchar(3)
	IF (@idser in (select  service.idser from service join servicetax ON servicetax.idser=service.idser
				join tax on servicetax.taxcode=tax.taxcode
				where  tax.taxref in ('08_IRPEF_FOC','07_IRPEF_FO') 
			) 
	    )
	BEGIN
		SET @colonna = '010' --AU001010 Ritenute a titolo di imposta
	END
	ELSE
	BEGIN
		SET @colonna = '009' --AU001009 Ritenute a titolo di acconto
	END
	
	--AU001009 Ritenute a titolo di acconto
	--AU001010 Ritenute a titolo di imposta
	INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimfisc,causale, socialseccode) 
	VALUES(@progrCom,@contaPrestazioni,'AU', 1, @colonna, @au09_10ritIRPEF,@au01_causale,@au33_socialseccode)
	
	--CAMPO 29 (Codice fiscale Ente Previdenziale) CAMPO NUOVO “indicare il codice fiscale dell’Ente previdenziale”. Pertanto deve essere inserito un valore costante pari a "80078750587” quando la certificazione prevede l'applicazione delle ritenute previdenziali.
	--CAMPO 30 (Denominazione Ente Previdenziale) CAMPO NUOVO. Pertanto deve essere inserito un valore costante pari a “Istituto Nazionale Previdenza Sociale” quando la certificazione prevede l'applicazione delle ritenute previdenziali.
	--CAMPO 31 Ente Previdenziale CAMPO NUOVO (l’unica casistica che verrà gestita, è la lettera “A” (ALTRO) quando la certificazione prevede l'applicazione delle ritenute previdenziali.
	--CAMPO 32 (Codice Azienda)- NON VALORIZZARLO
	--CAMPO 33 (Categoria) - NON VALORIZZARLO

	--CAMPO 34 (Contributi previdenziali a carico del soggetto erogante)  è il vecchio CAMPO 20 del precedente modello fiscale (CU 2017)
	--CAMPO 35 (Contributi previdenziali a carico del percipiente) è il vecchio CAMPO 21 del precedente modello fiscale (CU 2017)
	--CAMPO 38 (Contributi dovuti) CAMPO NUOVO (che sarà dato dalla somma dei campi 34 e 35)
	--CAMPO 39 (Contributi versati) CAMPO NUOVO (il campo 39 prenderà valore uguale al campo 38)
	print @au34_ritprevidenzialeamm
	print @au35_ritprevidenzialedip
	IF ((ISNULL(@au34_ritprevidenzialeamm,0) <> 0) OR (ISNULL(@au35_ritprevidenzialedip,0) <> 0) )
	BEGIN
		----- la causale M2, indica le prestazioni ENPAPI che è un istituto previdenziale diverso da INPS
		--	  @cfenteprev = '97151870587'/*ENPAPI*/ ELSE SET @cfenteprev = '80078750587' -- INPS
		--    IF  (@au01_causale = 'M2') SET @denomenteprev = 'E.N.P.A.P.I.' 
		--	  ELSE SET @denomenteprev = 'Istituto Nazionale Previdenza Sociale'
		
		IF (@cfenteprev IS NULL) SET @cfenteprev =  '80078750587' -- INPS
		IF (@denomenteprev IS NULL) SET @denomenteprev = 'Istituto Nazionale Previdenza Sociale'
		INSERT INTO #recHNonArrot (progr,  modulo, quadro, riga, colonna, stringa,causale,socialseccode)
		  		 
		select @progrCom,1,'AU',1, '029', @cfenteprev,@au01_causale,@au33_socialseccode
		where ( select count(*) from  #recHNonArrot R 
			where R.progr=@progrCom and  R.modulo=1 and R.quadro='AU' and R.riga=1
			and  R.colonna='029' and  R.stringa =@cfenteprev and R.causale=@au01_causale AND R.socialseccode = @au33_socialseccode ) =0

		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, stringa,causale, socialseccode) 
		select @progrCom,1,'AU',1, '030', @denomenteprev ,@au01_causale, @au33_socialseccode
		where ( select count(*) from  #recHNonArrot R 
			where R.progr=@progrCom and  R.modulo=1 and R.quadro='AU' and R.riga=1
			and  R.colonna='030' and  R.stringa = @denomenteprev and R.causale=@au01_causale AND R.socialseccode = @au33_socialseccode ) =0

		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, stringa,causale, socialseccode) 
		select @progrCom,1,'AU',1, '033', @au33_socialseccode,@au01_causale, @au33_socialseccode 
		where ( select count(*) from  #recHNonArrot R 
			where R.progr=@progrCom and  R.modulo=1 and R.quadro='AU' and R.riga=1
			and  R.colonna='033' and  R.stringa = @au33_socialseccode and R.causale=@au01_causale AND R.socialseccode = @au33_socialseccode ) =0

		--AU001034 Contributi previdenziali a carico del soggetto erogante
		IF (ISNULL(@au34_ritprevidenzialeamm,0) <> 0)
		BEGIN
			INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode)  
			VALUES(@progrCom,1,'AU',1, '034', @au34_ritprevidenzialeamm,@au01_causale,@au33_socialseccode )
		END
		--AU001035 Contributi previdenziali a carico del percipiente
		IF (ISNULL(@au35_ritprevidenzialedip,0) <> 0)
		BEGIN
			INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode)  
			VALUES(@progrCom,1, 'AU', 1, '035', @au35_ritprevidenzialedip,@au01_causale,@au33_socialseccode )
		END
		DECLARE @au38_contributidovuti DECIMAL(19,2)
		SET @au38_contributidovuti = ISNULL(@au34_ritprevidenzialeamm,0) + ISNULL(@au35_ritprevidenzialedip,0)
		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode)  
		VALUES(@progrCom,1,'AU',1, '038', @au38_contributidovuti,@au01_causale, @au33_socialseccode )
		-- I CONTRIBUTI VERSATI AU001039 LI PONIAMO PARI AI CONTRIBUTI DOVUTI AU001038, SOMMA DEI CONTRIBUTI C/ENTE E C/PERCIPIENTE
		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode)  
		VALUES(@progrCom,1,'AU',1, '039', @au38_contributidovuti,@au01_causale, @au33_socialseccode )
	END
	
	declare @au20_speseRimborsate dec(19,2)
	set @au20_speseRimborsate=0
	IF (@ycon is not null)  -- si tratta di un contratto occasionale
		select  @au20_speseRimborsate =  ISNULL( (SELECT P_refund_lastyear  from #annualpayedrefundH),0)

	set  @au20_speseRimborsate = @au20_speseRimborsate * @quota_contratto

		--AU001020 Spese rimborsate
		IF (@au20_speseRimborsate <> 0)
		BEGIN
			INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode)  VALUES(@progrCom,1,'AU', 1 , '020', @au20_speseRimborsate,@au01_causale, @au33_socialseccode )
		END

		--SET @contaPrestazioni = @contaPrestazioni + 1
		FETCH NEXT FROM cursoreexpense 		INTO @employtaxamount, @idexp, @idser, @au01_causale, @au33_socialseccode, @cfenteprev,@denomenteprev
	
	END

 
CLOSE cursoreexpense
DEALLOCATE cursoreexpense
	 
 --SELECT * FROM #recHNonArrot
	CREATE TABLE #recordH
	(
		progr int,
		modulo int,
		quadro varchar(6),
		riga int,
		colonna varchar(3),
		stringa varchar(400),
		decimale decimal(19,2),
		intero int,
		data datetime
	)

	declare @progr int
	declare @incr int
	declare @causale varchar(10)
	declare @socialseccode varchar(10)
	set @newprogrCom = @progrCom
	
	declare @ultimoinserito int
	set @ultimoinserito =@progrCom
	
	declare @cursore cursor
		set @incr = 0
		
		declare @modulo int
		set @modulo = 1
		-- Cicla su tutte le distinte causali e categorie previdenziali delle prestazioni effettuate da quel percipiente
		set @cursore = cursor for 
			select distinct  
			ltrim(rtrim(motive770)),
			ltrim(rtrim(socialseccode))
			from #expense2018  
		open @cursore
	 
		fetch next from @cursore into @causale, @socialseccode
		while @@fetch_status = 0 
		begin
			--set @modulo = @modulo +1
			set @fattoprestazioni='S'
			set @ultimoinserito = @newprogrCom
			insert into #recordH (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
			exec exp_certificazioneunica_d_19  @idreg, @newprogrCom, 'H',NULL, @print
	
			insert into #recordH (progr, modulo, quadro, riga, colonna, stringa, data, intero)
			select @newprogrCom,1, quadro, riga, colonna, stringa, data, intero
			from #recHNonArrot 
			where (stringa is not null or data is not null or intero is not null)
			and (quadro<>'AU' or colonna <> '001')
			and (colonna <> '006') and (colonna <> '029') and (colonna <> '030') and (colonna <> '031')  and (colonna <> '033')
			and  modulo = 1
	 
			--1 Tipo record
			INSERT INTO #recordH (progr, modulo, quadro, riga, colonna, stringa) VALUES(@newprogrCom,@modulo,'HRH', 1, '01', 'H')
			--2 Codice fiscale del sostituto d'imposta
			INSERT INTO #recordH (progr, modulo, quadro, riga, colonna, stringa) VALUES(@newprogrCom,@modulo,'HRH', 1, '02', @codfiscEnte)
			--3 Progressivo modulo
			INSERT INTO #recordH (progr, modulo,quadro, riga, colonna, intero)  VALUES(@newprogrCom,@modulo,'HRH', 1, '03', @modulo)
			--4 Codice fiscale del percipiente
			INSERT INTO #recordH (progr, modulo, quadro, riga, colonna, stringa) VALUES(@newprogrCom,@modulo, 'HRH', 1, '04', @au1cf)
			--5 Progressivo certificazione
			INSERT INTO #recordH (progr,  modulo, quadro, riga, colonna, intero)  VALUES(@newprogrCom,@modulo,'HRH', 1, '05', @newprogrCom)
			
 

			insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				values (@newprogrCom,@modulo, 'AU', 1, '001', @causale)
			
			insert into #recordH (progr, modulo, quadro, riga, colonna, intero)
				select max( @newprogrCom), @modulo, 'AU', 1, '006',  max(#recHNonArrot.intero)
				from #recHNonArrot 
				WHERE #recHNonArrot.intero is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna = '006'
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
			
				insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				select max( @newprogrCom), @modulo, 'AU', 1, '029' ,  max(#recHNonArrot.stringa)
				from #recHNonArrot 
				WHERE #recHNonArrot.stringa is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna  = '029'
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				
				insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				select max( @newprogrCom), @modulo, 'AU', 1,  '030' , max(#recHNonArrot.stringa)
				from #recHNonArrot 
				WHERE #recHNonArrot.stringa is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna  = '030' 
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')

				insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				select max( @newprogrCom), @modulo, 'AU', 1,  '033' , max(#recHNonArrot.stringa)
				from #recHNonArrot 
				WHERE #recHNonArrot.stringa is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna  = '033' 
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				
			insert into #recordH (progr, modulo, quadro, riga, colonna, decimale)
				select @newprogrCom,@modulo, #recHNonArrot.quadro, 1, #recHNonArrot.colonna, sum(#recHNonArrot.decimfisc) 
				from #recHNonArrot 
				where isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and #recHNonArrot.decimfisc is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna
				having ( sum(#recHNonArrot.decimfisc)) <> 0
					
			insert into #recordH (progr, modulo, quadro, riga, colonna, decimale)
				select @newprogrCom,@modulo, #recHNonArrot.quadro, 1, #recHNonArrot.colonna, sum(#recHNonArrot.decimprev)
				from #recHNonArrot 
				where isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and #recHNonArrot.decimprev is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna 
				having ( sum(#recHNonArrot.decimprev)) <> 0
				
			set @incr= @incr + 1
			set @newprogrCom = @progrCom + @incr

			fetch next from @cursore into @causale, @socialseccode
		end
	UPDATE #recordH SET intero = progr  WHERE quadro = 'HRH' and colonna = '05'  
--SELECT * FROM #recHNonArrot

------------------------------------------------------
----------- Parte relativa ai Pignoramenti -----------
------------------------------------------------------
declare @inseritopignoramenti char(1)

IF (@fattoprestazioni='N') set @modulo = 1
DECLARE @newmodulo int
insert into #recordH (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
			exec exp_certificazioneunica_h_pign_19  @idreg, @newprogrCom, @modulo, @fattoprestazioni,  @inseritopignoramenti out, @newmodulo out
 
--- inserisco i dati anagrafrici alla fine

if (@fattoprestazioni='N' and @inseritopignoramenti='S') begin

	insert into #recordH (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
	exec exp_certificazioneunica_d_19  @idreg, @newprogrCom, 'H',NULL, @print
	set @newprogrCom = @progrCom + 1   	
end
----------------------------------------------------
-------- Fine Parte relativa ai Pignoramenti -------
----------------------------------------------------
SELECT  progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data FROM #recordh 
WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL OR decimale IS NOT NULL
--select * from #recHNonArrot
--SELECT * FROM #infoPignoramenti

DROP TABLE #annualpayedrefundH
DROP TABLE #recordh
DROP TABLE #recHNonArrot
DROP TABLE #expense2018
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

---  
 
 
 
 
 --declare @newProg int
 --exec exp_certificazioneunica_h_19 1126,3, 'N', @newProg out


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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_h_22]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_h_22]
GO
 
 --setuser 'amministrazione'
 /*
 declare @newProg int
 exec exp_certificazioneunica_h_22 9434,1, 'N', @newProg out
 */
 --select @newProg
CREATE PROCEDURE [exp_certificazioneunica_h_22]
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
	set @annodichiarazione = 2022

	declare @annoredditi int
	set @annoredditi = 2021

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
		idexp int,
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
		socialseccode varchar(10),
		notsubjecttaxcode int -- forse non serve
	)
	
 
-- Sezione dichiarativa	
	DECLARE @progrModulo int  
	DECLARE @codfiscEnte varchar(16)
	 
	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase
	SELECT @codfiscEnte = cf FROM license
	SET @progrModulo = 1
	CREATE TABLE #expense2021
	(
		idexp int,
		idreg int,
		idser int,
		employtaxamount decimal(19,2),
		motive770 varchar(10),
		socialseccode varchar(10),
		cfagency varchar(16),
		titleagency varchar(512),
		notsubjecttaxcode int
	)

	INSERT INTO #expense2021
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

--rimuovo i pagamenti dei contratti occasionali da non trasmettere
--cioè con flagexcludefromcertificate = S
delete from #expense2021 where idexp in( 
SELECT #expense2021.idexp FROM #expense2021
join expenselink el on el.idchild = #expense2021.idexp 
join expensecasualcontract ec on el.idparent = ec.idexp
join casualcontract c on c.ycon = ec.ycon and c.ncon = ec.ncon
where (ISNULL(c.flagexcludefromcertificate,'N') = 'S')) 

--rimuovo i pagamenti dei contratti professionali da non trasmettere
--cioè con flagexcludefromcertificate = S
delete from #expense2021 where idexp in( 
SELECT #expense2021.idexp FROM #expense2021
join expenselink el on el.idchild = #expense2021.idexp 
join expenseprofservice ep on el.idparent = ep.idexp
join profservice p on p.ycon = ep.ycon and p.ncon = ep.ncon
where (ISNULL(p.flagexcludefromcertificate,'N') = 'S')) 


	declare @fattoprestazioni char(1)
	set @fattoprestazioni='N'

	update #expense2021 set motive770 = motive770service.idmot,
		socialseccode = motive770service.socialseccode,
		cfagency = mod770_socialsecuritycode.cfagency,
		titleagency=mod770_socialsecuritycode.titleagency
		from motive770service 
		left outer join  mod770_socialsecuritycode 
		ON mod770_socialsecuritycode.socialseccode = motive770service.socialseccode and 
		mod770_socialsecuritycode.ayear = motive770service.ayear 
		where motive770service.idser = #expense2021.idser
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
			#expense2021.employtaxamount,
			#expense2021.idexp,
			#expense2021.idser,
			#expense2021.motive770,
			#expense2021.socialseccode,
			#expense2021.cfagency,
			#expense2021.titleagency 
		FROM #expense2021
		join expenselink  			on expenselink.idchild = #expense2021.idexp			and nlevel = @expensephase
		left outer join expenseprofservice 			on expenselink.idparent = expenseprofservice.idexp
		WHERE isnull(movkind,0) <> 2 
		--- esclusa tipo contabilizzazione solo IVA (quindi solo 1 -> TOTALE o 2 --> IMPONIBILE)

		OPEN cursoreexpense
		FETCH NEXT FROM cursoreexpense
			INTO @employtaxamount, @idexp,  @idser, @au01_causale, @au33_socialseccode, @cfenteprev,@denomenteprev
	
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
	
		DECLARE @speseimponibilifis decimal(19,2)
		DECLARE @imponibilereale decimal(19,2)	
		DECLARE @impon_spesa decimal(19,2)
		DECLARE @impon_contratto decimal(19,2)
		DECLARE @quota_contratto float		
		DECLARE @sortcodeivakind varchar(10)
		SET @quota_contratto=1

		DECLARE @ycon int
		DECLARE @ncon int
		SET @ycon = null
		SET @ncon = null

		DECLARE @ypro int
		DECLARE @npro int
		SET @ypro = null
		SET @npro = null
		declare @speseRimborsateProf_nonimp decimal(19,2)
	-- calcola @au04_ammontarelordocorrisposto

		SELECT @ycon = ycon, @ncon = ncon
			FROM casualcontract C
			WHERE EXISTS(select * from expensecasualcontract EC
					join expenselink EL on EC.idexp=EL.idparent						
					where EL.idchild=@idexp
						AND C.ycon=EC.ycon and C.ncon=EC.ncon
				)
			AND (ISNULL(C.flagexcludefromcertificate,'N') = 'N')

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
		WHERE EXISTS(select * from expenseprofservice EC
				join expenselink EL on EC.idexp=EL.idparent						
				where EL.idchild=@idexp
					AND C.ycon=EC.ycon and C.ncon=EC.ncon)
		AND (ISNULL(C.flagexcludefromcertificate,'N') = 'N')
		IF (@ypro is not null)  -- si tratta di un contratto professionale
		BEGIN
		print  @idexp

		select @speseRimborsateProf_nonimp = (
									select isnull(sum(ps.amount),0) from profservicerefund ps 
									join profrefund p on p.idlinkedrefund = ps.idlinkedrefund 
									where ps.ycon = @ypro and ps.ncon = @npro and p.flagfiscaldeduction = 'S'
									) 
					
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
				ROUND(@quota_contratto*(isnull(@imponibilereale,0) ),2)
			
			-- abbiamo dovuto utilizzare, per i contratti professionali,
			-- il criterio della mappatura dell'aliquota iva utilizzata nel contratto
			-- allo scopo di distinguere, per i professionisti, il tipo di regime 
			-- in cui rientrano le somme non soggette a ritenuta (dei minimi / forfettario)
			SELECT @sortcodeivakind= S.sortcode  FROM profservice P 
				JOIN ivakind IK ON P.idivakind = IK.idivakind
				JOIN ivakindsorting IKS ON IKS.idivakind = IK.idivakind
				JOIN sorting S ON S.idsor = IKS.idsor AND S.sortcode in ('013','014')
				JOIN sortingkind SK ON SK.idsorkind = S.idsorkind AND SK.codesorkind = '016_CLASSIVAKIND'
			WHERE  P.ycon = @ypro and P.ncon = @npro

		END
		ELSE
		BEGIN --MOV. DI SPESA
			SELECT @au04_ammontarelordocorrisposto = 
				MAX(ET.taxablegross)
				FROM expensetaxofficial ET
				JOIN tax T ON ET.taxcode=T.taxcode 
				WHERE ET.idexp=@idexp and  T.taxkind=1
				AND ET.stop IS NULL
				set @au04_ammontarelordocorrisposto = @au04_ammontarelordocorrisposto - isnull(	@speseRimborsateProf_nonimp,0)	
		END
	END
		
	--AU001001 Causale
	INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, stringa,causale, socialseccode,idexp) 
	VALUES(@progrCom,1, 'AU', 1, '001', @au01_causale,@au01_causale,@au33_socialseccode,@idexp)

	set @au04_ammontarelordocorrisposto= isnull(@au04_ammontarelordocorrisposto,0)

	INSERT INTO  #recHNonArrot(progr,  modulo, quadro, riga, colonna, decimfisc,causale,socialseccode,idexp) 
	VALUES(@progrCom,@contaPrestazioni,'AU',1 , '004', @au04_ammontarelordocorrisposto,@au01_causale,@au33_socialseccode,@idexp)

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
		INSERT INTO #recHNonArrot (progr,  modulo, quadro, riga, colonna, decimfisc,causale, socialseccode,idexp) 
		VALUES(@progrCom,@contaPrestazioni, 'AU',1 , '005', @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale,@au01_causale,@au33_socialseccode,@idexp)
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


					

	-- Nel caso di erogazione di altri redditi non soggetti a ritenuta ovvero esenti.
	-- NEL 2022 DISTINGUIAMO I SEGUENTI CASI CHE L'ANNO SCORSO NON DISTINGUEVAMO (task 15738)
	-- A) Per i professionisti che hanno effettuato solo prestazioni senza ritenuta, mettiamo codice 7
	-- ad eccezione del caso in cui sulla parcella sia stata utilizzata un'aliquota iva 
	-- classificata con classivakind =  014
	-- (CertUnica12 regime forfettario). In quest'ultimo caso andrà messo il codice 12.
	-- B) Per i professionisti che hanno effettuato sia  prestazioni senza ritenuta che con ritenuta
	-- dobbiamo compilare un solo modulo separando opportunamente 
	-- l'importo degli altri redditi non soggetti a ritenuta ovvero esenti
	-- C) per i professionisti che hanno effettuato solo prestazioni senza ritenuta 
	-- ma rientranti in regimi differenti (con codice punto 6 differente) 
	-- dobbiamo compilare moduli separati   
	DECLARE @notsubjecttaxcode int
	DECLARE @au06_CodiceAltreSommeNonSoggetteARitenuta   int
	SET @notsubjecttaxcode = null
	if (@au07_AltreSommeNonSoggetteARitenuta <> 0) 
	BEGIN
		SET @notsubjecttaxcode = 21
		
		IF  ISNULL(@sortcodeivakind,'') = '014' 
			SET @notsubjecttaxcode = 24 /*voce di class. convenzionale per regime forfettario*/
		
	 

		SET @au06_CodiceAltreSommeNonSoggetteARitenuta = @notsubjecttaxcode
		--- AU001006 Codice NP Vale   7 oppure 12 
		--- AU001007 Altre Somme Non Soggette a Ritenuta
		INSERT INTO #recHNonArrot (progr, modulo, quadro, riga, colonna, intero,causale,socialseccode,idexp) 
		VALUES(@progrCom,@contaPrestazioni, 'AU', 1, '006', @au06_CodiceAltreSommeNonSoggetteARitenuta,@au01_causale,@au33_socialseccode,@idexp)
		INSERT INTO #recHNonArrot (progr,  modulo, quadro, riga, colonna, decimfisc,causale, socialseccode,idexp) 
		VALUES(@progrCom,@contaPrestazioni, 'AU', 1, '007', @au07_AltreSommeNonSoggetteARitenuta,@au01_causale,@au33_socialseccode,@idexp)
		
		UPDATE  #expense2021 set notsubjecttaxcode = @notsubjecttaxcode  
		WHERE #expense2021.idexp= @idexp
	END
	

--	AUXXX026 Imponibile
--	AUX026 = AU001004 - AU0010005 - AU001007
	SET @au08_imponibile = @au04_ammontarelordocorrisposto - @au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale-@au07_AltreSommeNonSoggetteARitenuta
	--SELECT '@au04_ammontarelordocorrisposto',@au04_ammontarelordocorrisposto
	--SELECT '@au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale',@au05_SommeNonSoggetteARitenutaPerRegimeConvenzionale
	--SELECT '@au07_AltreSommeNonSoggetteARitenuta',@au07_AltreSommeNonSoggetteARitenuta
	INSERT INTO #recHNonArrot (progr, modulo, quadro, riga, colonna, decimfisc,causale,socialseccode,idexp) 
	VALUES(@progrCom,@contaPrestazioni, 'AU', 1, '008', @au08_imponibile,@au01_causale,@au33_socialseccode,@idexp)
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
	INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimfisc,causale, socialseccode,idexp) 
	VALUES(@progrCom,@contaPrestazioni,'AU', 1, @colonna, @au09_10ritIRPEF,@au01_causale,@au33_socialseccode,@idexp)
	
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
		INSERT INTO #recHNonArrot (progr,  modulo, quadro, riga, colonna, stringa,causale,socialseccode,idexp)
		  		 
		select @progrCom,1,'AU',1, '029', @cfenteprev,@au01_causale,@au33_socialseccode,@idexp
		where ( select count(*) from  #recHNonArrot R 
			where R.progr=@progrCom and  R.modulo=1 and R.quadro='AU' and R.riga=1
			and  R.colonna='029' and  R.stringa =@cfenteprev and R.causale=@au01_causale AND R.socialseccode = @au33_socialseccode ) =0

		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, stringa,causale, socialseccode,idexp) 
		select @progrCom,1,'AU',1, '030', @denomenteprev ,@au01_causale, @au33_socialseccode,@idexp
		where ( select count(*) from  #recHNonArrot R 
			where R.progr=@progrCom and  R.modulo=1 and R.quadro='AU' and R.riga=1
			and  R.colonna='030' and  R.stringa = @denomenteprev and R.causale=@au01_causale AND R.socialseccode = @au33_socialseccode ) =0

		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, stringa,causale, socialseccode,idexp) 
		select @progrCom,1,'AU',1, '033', @au33_socialseccode,@au01_causale, @au33_socialseccode ,@idexp
		where ( select count(*) from  #recHNonArrot R 
			where R.progr=@progrCom and  R.modulo=1 and R.quadro='AU' and R.riga=1
			and  R.colonna='033' and  R.stringa = @au33_socialseccode and R.causale=@au01_causale AND R.socialseccode = @au33_socialseccode ) =0

		--AU001034 Contributi previdenziali a carico del soggetto erogante
		IF (ISNULL(@au34_ritprevidenzialeamm,0) <> 0)
		BEGIN
			INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode,idexp)  
			VALUES(@progrCom,1,'AU',1, '034', @au34_ritprevidenzialeamm,@au01_causale,@au33_socialseccode,@idexp )
		END
		--AU001035 Contributi previdenziali a carico del percipiente
		IF (ISNULL(@au35_ritprevidenzialedip,0) <> 0)
		BEGIN
			INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode,idexp)  
			VALUES(@progrCom,1, 'AU', 1, '035', @au35_ritprevidenzialedip,@au01_causale,@au33_socialseccode,@idexp )
		END
		DECLARE @au38_contributidovuti DECIMAL(19,2)
		SET @au38_contributidovuti = ISNULL(@au34_ritprevidenzialeamm,0) + ISNULL(@au35_ritprevidenzialedip,0)
		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode,idexp)  
		VALUES(@progrCom,1,'AU',1, '038', @au38_contributidovuti,@au01_causale, @au33_socialseccode ,@idexp)
		-- I CONTRIBUTI VERSATI AU001039 LI PONIAMO PARI AI CONTRIBUTI DOVUTI AU001038, SOMMA DEI CONTRIBUTI C/ENTE E C/PERCIPIENTE
		INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode,idexp)  
		VALUES(@progrCom,1,'AU',1, '039', @au38_contributidovuti,@au01_causale, @au33_socialseccode ,@idexp)
	END
	
	declare @au20_speseRimborsate dec(19,2)
	set @au20_speseRimborsate=0

	IF (@ycon is not null)  -- si tratta di un contratto occasionale
		select  @au20_speseRimborsate =  ISNULL( (SELECT P_refund_lastyear  from #annualpayedrefundH),0)
	--IF (@ypro is not null) -- si tratta di un contratto professionale: andranno usati quando nella CU andremo a creare un secondo modulo per dichiarare solo le spese.
	--	select @au20_speseRimborsate = (
	--								select isnull(sum(ps.amount),0) from profservicerefund ps 
	--								join profrefund p on p.idlinkedrefund = ps.idlinkedrefund 
	--								where ps.ycon = @ypro and ps.ncon = @npro and p.flagfiscaldeduction = 'S'
	--								) 
		set @au20_speseRimborsate = @au20_speseRimborsate * @quota_contratto

		--AU001020 Spese rimborsate
		IF (@au20_speseRimborsate <> 0)
		BEGIN
			INSERT INTO #recHNonArrot (progr,  modulo,quadro, riga, colonna, decimprev,causale,socialseccode,idexp)  
			VALUES(@progrCom,1,'AU', 1 , '020', @au20_speseRimborsate,@au01_causale, @au33_socialseccode,@idexp )
		END


		--- allineo tutti i dati inseriti per il pagamento in oggetto  sull'eventuale codice @notsubjecttaxcode per poter paginare in più moduli
		--- anche su questo dato
		UPDATE #recHNonArrot SET notsubjecttaxcode = @notsubjecttaxcode 
		WHERE  (idexp = @idexp)  
	 	
		--SET @contaPrestazioni = @contaPrestazioni + 1
		FETCH NEXT FROM cursoreexpense 		INTO @employtaxamount, @idexp, @idser, @au01_causale, @au33_socialseccode, @cfenteprev,@denomenteprev
	
	END
	
 
CLOSE cursoreexpense
DEALLOCATE cursoreexpense
	
 -- Se ci sono prestazioni con e senza  Altre Somme Non Soggette A Ritenuta
 -- allineo tutti i dati inseriti per gli altri pagamenti del percipiente sull'eventuale codice @notsubjecttaxcode 
-- laddove esso non sia valorizzato per poter paginare nello stesso modulo
		UPDATE #recHNonArrot SET notsubjecttaxcode = ( select top 1 notsubjecttaxcode FROM #recHNonArrot A WHERE 
		#recHNonArrot.causale = A.causale 
		AND isnull(#recHNonArrot.socialseccode,'') = isnull(A.socialseccode,'') 
		AND #recHNonArrot.idexp <> A.idexp AND A.notsubjecttaxcode IS NOT NULL )
		WHERE #recHNonArrot.notsubjecttaxcode IS NULL 
		AND (SELECT COUNT(DISTINCT B.notsubjecttaxcode) FROM #recHNonArrot B WHERE 
		#recHNonArrot.causale = B.causale 
		AND isnull(#recHNonArrot.socialseccode,'') = isnull(B.socialseccode,'') 
		AND #recHNonArrot.idexp <> B.idexp AND B.notsubjecttaxcode IS NOT NULL
		) = 1 

	UPDATE #expense2021 SET notsubjecttaxcode = ( select top 1 A.notsubjecttaxcode 
	FROM #recHNonArrot A WHERE 
	A.idexp =  #expense2021.idexp AND isnull(A.notsubjecttaxcode,'') <> 0)
	WHERE isnull(#expense2021.notsubjecttaxcode,'') = 0


  -- SELECT * FROM #recHNonArrot
 -- select '@progrCom',@progrCom
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
	declare @incrmodulo int
	declare @incrprogrcom int
	declare @causale varchar(10)
	declare @socialseccode varchar(10)
	declare @notsubjecttax  int
	set @newprogrCom = @progrCom -1
	
	declare @ultimoinserito int
	set @ultimoinserito =@progrCom
	
	DECLARE @oldcausale varchar(10)
	DECLARE @oldnotsubjecttax int

	declare @cursore cursor
		set @incrmodulo = 0
		SET @incrprogrcom = 0
		declare @modulo int
		set @modulo = 1
		-- Cicla su tutte le distinte causali e categorie previdenziali 
		-- altre somme non soggette a ritenuta, e codici delle prestazioni  effettuate da quel percipiente
		set @cursore = cursor for 
			select distinct  
			ltrim(rtrim(motive770)),
			ltrim(rtrim(socialseccode)),
			isnull(notsubjecttaxcode,0)
			from #expense2021  
		open @cursore
 --select distinct  
	--		ltrim(rtrim(motive770)),
	--		ltrim(rtrim(socialseccode)),
	--		isnull(notsubjecttaxcode,0)
	--		from #expense2021  
	fetch next from @cursore into @causale, @socialseccode, @notsubjecttax
		while @@fetch_status = 0 
		begin
			--set @modulo = @modulo +1
	 
			SET @fattoprestazioni='S'
			
			--- incremento il modulo nell'ambito della stessa certificazione
			IF (@oldcausale = @causale) BEGIN  
				SET @incrmodulo= @incrmodulo + 1
				SET @modulo = @modulo + @incrmodulo
			END
			ELSE
				BEGIN  --- creo una nuova certificazione
					SET @incrprogrcom = @incrprogrcom + 1  
					SET @newprogrCom  = @progrCom -1 + @incrprogrcom 
					SET @modulo = 1
					--- dati anagrafici, una sola volta per ogni certificazione
					insert into #recordH (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
					exec exp_certificazioneunica_d_22  @idreg, @newprogrCom, 'H',NULL, @print
				END

  
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
				and isnull(#recHNonArrot.notsubjecttaxcode,'') = isnull(@notsubjecttax,'')

				insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				select max( @newprogrCom), @modulo, 'AU', 1, '029' ,  max(#recHNonArrot.stringa)
				from #recHNonArrot 
				WHERE #recHNonArrot.stringa is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna  = '029'
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and isnull(#recHNonArrot.notsubjecttaxcode,'') = isnull(@notsubjecttax,'')

				insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				select max( @newprogrCom), @modulo, 'AU', 1,  '030' , max(#recHNonArrot.stringa)
				from #recHNonArrot 
				WHERE #recHNonArrot.stringa is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna  = '030' 
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and isnull(#recHNonArrot.notsubjecttaxcode,'') = isnull(@notsubjecttax,'')

				insert into #recordH (progr, modulo, quadro, riga, colonna, stringa)
				select max( @newprogrCom), @modulo, 'AU', 1,  '033' , max(#recHNonArrot.stringa)
				from #recHNonArrot 
				WHERE #recHNonArrot.stringa is not null
				and #recHNonArrot.quadro = 'AU'
				and #recHNonArrot.colonna  = '033' 
				and isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and isnull(#recHNonArrot.notsubjecttaxcode,'') = isnull(@notsubjecttax,'')
				
			insert into #recordH (progr, modulo, quadro, riga, colonna, decimale)
				select @newprogrCom,@modulo, #recHNonArrot.quadro, 1, #recHNonArrot.colonna, sum(#recHNonArrot.decimfisc) 
				from #recHNonArrot 
				where isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and isnull(#recHNonArrot.notsubjecttaxcode,'') = isnull(@notsubjecttax,'')
				and #recHNonArrot.decimfisc is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna
				having ( sum(#recHNonArrot.decimfisc)) <> 0
					
			insert into #recordH (progr, modulo, quadro, riga, colonna, decimale)
				select @newprogrCom,@modulo, #recHNonArrot.quadro, 1, #recHNonArrot.colonna, sum(#recHNonArrot.decimprev)
				from #recHNonArrot 
				where isnull(#recHNonArrot.causale,'') = isnull(@causale,'')
				and isnull(#recHNonArrot.socialseccode,'') = isnull(@socialseccode,'')
				and isnull(#recHNonArrot.notsubjecttaxcode,'') = isnull(@notsubjecttax,'')
				and #recHNonArrot.decimprev is not null
				group by #recHNonArrot.quadro, #recHNonArrot.colonna 
				having ( sum(#recHNonArrot.decimprev)) <> 0
		 

			SET @oldcausale = @causale

			fetch next from @cursore into @causale, @socialseccode,@notsubjecttax
		end
	UPDATE #recordH SET intero = progr  WHERE quadro = 'HRH' and colonna = '05'  
--SELECT * FROM #recHNonArrot
IF (@fattoprestazioni='S') 
BEGIN
    -- lo incremento per la prossima certificazione in caso di elaborazione massiva 
	SET @newprogrCom = @newprogrCom +1
END
------------------------------------------------------
----------- Parte relativa ai Pignoramenti -----------
------------------------------------------------------
declare @inseritopignoramenti char(1)

IF (@fattoprestazioni='N') 
BEGIN 
	  SET @newprogrCom  = @progrCom 
	  SET @modulo = 1 
END
DECLARE @newmodulo int
insert into #recordH (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
			exec exp_certificazioneunica_h_pign_22  @idreg, @newprogrCom, @modulo, @fattoprestazioni,  @inseritopignoramenti out, @newmodulo out
 
--- inserisco i dati anagrafici alla fine

if (@fattoprestazioni='N' and @inseritopignoramenti='S') begin

	insert into #recordH (progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data)
	exec exp_certificazioneunica_d_22  @idreg, @newprogrCom, 'H',NULL, @print	
	SET @newprogrCom = @newprogrCom +1
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
DROP TABLE #expense2021
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

 

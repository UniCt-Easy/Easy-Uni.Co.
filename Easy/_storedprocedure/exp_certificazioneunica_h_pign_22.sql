
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_h_pign_22]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_h_pign_22]
GO  
--setuser 'amministrazione'
CREATE PROCEDURE [exp_certificazioneunica_h_pign_22]
  -- estraggo il record H relativo ad un determinato percipiente (creditore pignoratizio), il progressivo comunicazione
 -- indica l'ordine all'interno dei percipienti del sostituto d'imposta
(
	 @idreg int,
	 @progrCom int,
	 @modulo int,
	 @fattoqualcosa char(1),
	 @inserito char(1) out	, 
	 @newProgrModulo int out
) 

AS BEGIN
-------------------------------------------------------------------------------------------------------
----------------------------------------- RECORD DI TIPO "I": Dati relativi ---------------------------
----------------------------------al prospetto SY del mod. 770/2022 semplificato ----------------------
-------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------
----------------------------------------- PARTE  POSIZIONALE ------------------------------------------
-------------------------------------------------------------------------------------------------------
	set @inserito='N'

-- RECORD DI TIPO "H": Casi particolari operazioni straordinarie
	--AU001072 Casi particolari operazioni straordinarie - Codice Fiscale sezione 
	--pignoramento presso terzi CF

	--Può essere presente solo è compilata la sezione Somme
	--liquidate a seguito di pignoramento presso terzi (campi da AU001101 a AU001108).
	
	--Somme liquidate a seguito di pignoramento verso terzi - Riservato al soggetto erogante delle somme
	--2022	AU	101	Codice Fiscale debitore   principale
	--2022	AU	102	Somme erogate
	--2022	AU	103	Ritenute operate
	--2022	AU	104	Somme erogate non tassate
	--2022	AU	105 Codice Fiscale debitore   principale
	--2022	AU	106	Somme erogate
	--2022	AU	107	Ritenute operate
	--2022	AU	108	Somme erogate non tassate

	DECLARE @codfiscEnte varchar(16)
	declare @idcityEnte int
	SELECT @codfiscEnte = cf, @idcityEnte = idcity FROM license

	-- Fine Seconda Sezione dichiarativa

	-- Tabella di output che contiene le informazioni del record I (che successivamente verranno elaborate dal form del 770)
	CREATE TABLE #recordPignoramenti
	(
		progr int,
		modulo int,
		quadro varchar(5),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		decimale decimal(19,2),
		data datetime
	)


	--INIZIO PRELIEVO DATI DA expensetax
	-- Tabella che contiene i movimenti finanziari di prestazioni pagate mediante il modulo dipendenti
	CREATE TABLE #expense
	(
		idexp int,
		idreg int,
		idreg_distrained int,
		cf_reg varchar(16),
		cf_reg_distrained varchar(16),
		taxdescription varchar(50),
		expensedescription varchar(150),	
		commondetail char(1),
		taxablenet decimal(19,2),
		employtax decimal(19,2),
		admintax decimal(19,2),
		grossamount decimal (19,2),
		transmissiondate datetime,
		service varchar(50),
		module varchar(15),
		servicecode770 varchar(20),
		npay int
	)

	-- Fase massima di spesa
	declare @annodichiarazione int
	set @annodichiarazione = 2022

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1


	-- PIGNORAMENTI CON APPLICAZIONE DELLA RITENUTA
	INSERT INTO #expense
	(
		idexp,		idreg,		idreg_distrained,		cf_reg,		cf_reg_distrained,		taxablenet,
		employtax, 		admintax, 
		grossamount,--Importo Lordo del Pagamento
		transmissiondate,		service,		servicecode770,		module,		npay
	)
	SELECT
		T.idexp,		T.idreg,	T.idreg_distrained,	isnull(R.cf,R.p_iva),	isnull(R_DISTR.cf,R_DISTR.p_iva),	SUM(T.taxablenet),
		SUM(T.employtax),		SUM(T.admintax), 
		CASE 
			WHEN service.module in ('DIPENDENTE') THEN
			(ISNULL(expenseyear.amount,0) + 
			 ISNULL(
				(SELECT ISNULL(SUM(v.amount), 0.0)
				FROM expensevar v
				WHERE idexp=T.idexp					
					AND (ISNULL(v.autokind,0)<>4)					
				),0)		
			)
			ELSE NULL
		END,
		paymenttransmission.transmissiondate,	service.description,	ISNULL(service.servicecode770,service.codeser),service.module,		payment.npay
	FROM
		(SELECT
			SUM(ISNULL(E.taxablenet,0)) AS taxablenet,
			SUM(ISNULL(E.employtax,0)) AS employtax,
			SUM(ISNULL(E.admintax,0)) AS admintax,
			E.idexp as idexp,
			expense.idreg AS idreg,
			W.idreg_distrained AS idreg_distrained ,
			E.description as taxdescription,
			expense.description as expensedescription,
			expenselast.idser,
			expenselast.kpay
		FROM expensetaxofficialview AS E
		JOIN expense					ON expense.idexp = E.idexp
		JOIN expenselast				ON expenselast.idexp = expense.idexp 
		JOIN service					ON service.idser = expenselast.idser
		JOIN wageaddition W				ON W.idser =  service.idser
		JOIN expensewageaddition EW		ON EW.ycon = W.ycon AND EW.ncon = W.ncon
		JOIN expenselink EL				ON EL.idparent = EW.idexp AND EL.idchild =  E.idexp
		WHERE expense.ymov = @annoredditi AND E.stop IS NULL AND (@idreg=expense.idreg or @idreg is null) AND (ISNULL(W.flagexcludefromcertificate,'N') = 'N')
		GROUP BY expense.idreg, E.idexp, expenselast.idser, W.idreg_distrained, E.description, expense.description, expenselast.kpay) AS T
	JOIN expensetotal			ON T.idexp = expensetotal.idexp  
	JOIN expenseyear			ON T.idexp = expenseyear.idexp
	JOIN service				ON T.idser = service.idser  
	JOIN payment				ON T.kpay = payment.kpay  
	JOIN paymenttransmission	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
	JOIN registry R				ON R.idreg = T.idreg 
	JOIN registry R_DISTR		ON R_DISTR.idreg = T.idreg_distrained
	WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
		AND service.rec770kind = 'I'  and ISNULL(service.servicecode770,service.codeser) = '11_PIGNORA'
		AND expensetotal.ayear = @annoredditi
		AND expenseyear.ayear = @annoredditi
		AND (@idreg=T.idreg or @idreg is null)
	GROUP BY T.idreg, T.idreg_distrained, T.idexp,
		expenseyear.amount, service.description, service.module,
		service.idser,payment.npay, paymenttransmission.transmissiondate,	
		isnull(R.cf,R.p_iva),isnull(R_DISTR.cf,R_DISTR.p_iva), ISNULL(service.servicecode770,service.codeser)	
-- FINE PRELIEVO DATI DA expensetax

--rimuovo i pagamenti dei contratti dipendenti da non trasmettere
--cioè con flagexcludefromcertificate = S
delete from #expense2021 where idexp in( 
SELECT #expense2021.idexp FROM #expense2021
join expenselink el on el.idchild = #expense2021.idexp 
join expensewageaddition ew on el.idparent = ew.idexp
join wageaddition w on w.ycon = ew.ycon and w.ncon = ew.ncon
where (ISNULL(w.flagexcludefromcertificate,'N') = 'S')) 


-- PIGNORAMENTI ESENTI DA RITENUTA
INSERT INTO #expense
	(
		idexp,		idreg,		idreg_distrained,		cf_reg,		cf_reg_distrained,		taxablenet,
		employtax, 		admintax, 		grossamount,--Importo Lordo del Pagamento
		transmissiondate,		service,		servicecode770,		module,		npay
	)
	SELECT
		T.idexp,		T.idreg,		T.idreg_distrained,		isnull(R.cf,R.p_iva),		isnull(R_DISTR.cf,R_DISTR.p_iva),
		0,		0,		0, 		CASE 
		WHEN service.module in ('DIPENDENTE') THEN
		(ISNULL(expenseyear.amount,0) + 
		 ISNULL(
			(SELECT ISNULL(SUM(v.amount), 0.0)
			FROM expensevar v
			WHERE idexp=T.idexp					
				AND (ISNULL(v.autokind,0)<>4)					
			),0)		
		)
		ELSE NULL
		END,
		paymenttransmission.transmissiondate,	service.description,		ISNULL(service.servicecode770,service.codeser),		service.module,		payment.npay
	FROM
		(SELECT
			E.idexp as idexp,
			E.idreg as idreg,
			W.idreg_distrained as idreg_distrained,
			expenselast.idser as idser,
			expenselast.kpay as kpay
		FROM expense  E			
		JOIN expenselast				ON expenselast.idexp = E.idexp 
		JOIN service					ON service.idser = expenselast.idser
		JOIN wageaddition W				ON W.idser =  service.idser
		JOIN expensewageaddition EW		ON EW.ycon = W.ycon AND EW.ncon = W.ncon
		JOIN expenselink EL				ON EL.idparent = EW.idexp AND EL.idchild =  E.idexp
		WHERE E.ymov = @annoredditi AND (ISNULL(W.flagexcludefromcertificate,'N') = 'N') 
		GROUP BY E.idreg, E.idexp, expenselast.idser, W.idreg_distrained, expenselast.kpay) AS T
	JOIN expensetotal			ON T.idexp = expensetotal.idexp  
	JOIN expenseyear			ON T.idexp = expenseyear.idexp
	JOIN service				ON T.idser = service.idser  
	JOIN payment				ON T.kpay = payment.kpay  
	JOIN paymenttransmission	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
	JOIN registry R				ON R.idreg = T.idreg 
	JOIN registry R_DISTR		ON R_DISTR.idreg = T.idreg_distrained
	WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and ISNULL(service.servicecode770,service.codeser) = '11_PIGNORA_ESE'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
	AND (T.idreg=@idreg or @idreg is null)
	GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay,paymenttransmission.transmissiondate,
	isnull(R.cf,R.p_iva),	isnull(R_DISTR.cf,R_DISTR.p_iva), ISNULL(service.servicecode770,service.codeser)		

-- Ciclo con valorizzazione del progressivo modulo, ogni cinque pagamenti bisogna incrementare il progressivo modulo
-- il primo modulo utilizzato coincide con l'ultimo della prestazione 
DECLARE @contaPagamenti int
SET @contaPagamenti = 0

DECLARE @progrModulo int
SET @progrModulo = @modulo

DECLARE @cf_reg varchar(16)
DECLARE @cf_reg_distrained varchar(16)
DECLARE @taxablenet decimal(19,2)
DECLARE @employtax decimal(19,2)
DECLARE @admintax decimal(19,2)
DECLARE @grossamount decimal(19,2)
DECLARE @servicecode770 varchar(20)

DECLARE cursoreexpense CURSOR FOR 
SELECT 
		#expense.cf_reg,
		#expense.cf_reg_distrained,
		isnull(sum(#expense.taxablenet),0),
		isnull(sum(#expense.employtax),0), 
		isnull(sum(#expense.admintax),0),
		isnull(sum(#expense.grossamount),0),--Importo Lordo del Pagamento
		#expense.servicecode770 
FROM #expense
GROUP BY #expense.cf_reg,
		#expense.cf_reg_distrained,#expense.servicecode770

--DECLARE @progrCom int

--SELECT @codfiscEnte = cf FROM license
--	DECLARE @cfsoftwarehouse varchar(16)
--	SET @cfsoftwarehouse = '02890460781' --- TEMPO SRL
	
OPEN cursoreexpense
FETCH NEXT FROM cursoreexpense
INTO @cf_reg, @cf_reg_distrained, @taxablenet, @employtax,@admintax,@grossamount,@servicecode770


	
	--Somme liquidate a seguito di pignoramento verso terzi - Riservato al soggetto erogante delle somme
	--2022	AU	101	Codice Fiscale debitore   principale
	--2022	AU	102	Somme erogate
	--2022	AU	103	Ritenute operate
	--2018	AU	104	Somme erogate non tassate
	--2018	AU	105 Codice Fiscale debitore   principale
	--2018	AU	106	Somme erogate
	--2018	AU	107	Ritenute operate
	--2018	AU	108	Somme erogate non tassate
	WHILE @@FETCH_STATUS = 0
		BEGIN
			IF ((@contaPagamenti%2) = 0)  
			BEGIN								
				if (@contaPagamenti>0)begin
					SET  @progrModulo = @progrModulo + 1
				end

				if (@fattoqualcosa='N' OR @contaPagamenti>0)BEGIN  --deve inserire l'Header		
												
						--1 Tipo record
						INSERT INTO #recordPignoramenti (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom,@progrModulo,'HRH', 1, '01', 'H')
						--2 Codice fiscale del sostituto d'imposta
						INSERT INTO #recordPignoramenti (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom,@progrModulo,'HRH', 1, '02', @codfiscEnte)
						--3 Progressivo modulo
						INSERT INTO #recordPignoramenti (progr, modulo,quadro, riga, colonna, intero)  VALUES(@progrCom,@progrModulo,'HRH', 1, '03', @progrModulo)
						--4 Codice fiscale del percipiente
						INSERT INTO #recordPignoramenti (progr, modulo, quadro, riga, colonna, stringa) VALUES(@progrCom,@progrModulo, 'HRH', 1, '04', @cf_reg)
						--5 Progressivo certificazione
						INSERT INTO #recordPignoramenti (progr,  modulo, quadro, riga, colonna, intero)  VALUES(@progrCom,@progrModulo,'HRH', 1, '05', @progrCom)
				END
				-- task 8058
				--INSERT INTO #recordPignoramenti(progr,modulo, quadro, riga, colonna,stringa ) VALUES (@progrCom,@progrModulo, 'AU',1 ,'072' ,@cf_reg)					
			END

		

		set @inserito='S'
	 
		--- attenzione! per i seguenti importi deve essere effettuato il troncamento della parte decimale e non l'arrotondamento
		INSERT INTO #recordPignoramenti(progr,modulo, quadro, riga, colonna,stringa ) VALUES (@progrCom,@progrModulo, 'AU', 1, convert(varchar(3),101 + 4*(@contaPagamenti%2)), @cf_reg_distrained)

		IF @servicecode770 = '11_PIGNORA_ESE' 
			BEGIN
				INSERT INTO #recordPignoramenti(progr,modulo, quadro, riga, colonna,decimale ) VALUES (@progrCom,@progrModulo, 'AU', 1,  convert(varchar(3),104 + 4*(@contaPagamenti%2)), @grossamount)
			END
		ELSE
			BEGIN
				INSERT INTO #recordPignoramenti(progr,modulo, quadro, riga, colonna,decimale ) VALUES (@progrCom,@progrModulo, 'AU', 1,  convert(varchar(3),102 + 4*(@contaPagamenti%2)), @taxablenet)
				INSERT INTO #recordPignoramenti(progr,modulo, quadro, riga, colonna,decimale ) VALUES (@progrCom,@progrModulo, 'AU', 1,  convert(varchar(3),103 + 4*(@contaPagamenti%2)), @employtax)
			END
		SET @contaPagamenti = @contaPagamenti + 1
		FETCH NEXT FROM cursoreexpense
		INTO @cf_reg, @cf_reg_distrained, @taxablenet, @employtax,@admintax,@grossamount,@servicecode770
	END
CLOSE cursoreexpense
DEALLOCATE cursoreexpense

SET @newProgrModulo = @progrModulo
SELECT  progr,modulo, quadro, riga, colonna, stringa,decimale, intero, data  FROM #recordPignoramenti
WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL OR decimale IS NOT NULL
DROP TABLE #recordPignoramenti
DROP TABLE #expense

END

 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 

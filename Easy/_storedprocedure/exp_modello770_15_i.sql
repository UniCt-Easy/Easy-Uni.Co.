
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_15_i]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_15_i]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exec exp_modello770_15_i
CREATE PROCEDURE [exp_modello770_15_i]
AS BEGIN

-------------------------------------------------------------------------------------------------------
----------------------------------------- RECORD DI TIPO "I": Dati relativi ---------------------------
----------------------------------al prospetto SY del mod. 770/2015 semplificato ----------------------
-------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------
----------------------------------------- PARTE  POSIZIONALE ------------------------------------------
-------------------------------------------------------------------------------------------------------


-- RECORD DI TIPO "I": Dati relativi al prospetto SY del mod. 770/2015 semplificato

-- codice fiscale soggetto dichiarante (codice fiscale ente)
-- progressivo modulo SY, parte da 1 e viene incrementato ogni volta di 1
-- Tipo operazione, dovrebbe essere fisso 'I'
-- Spazio a disposizione dell'utente per l'identificazione della dichiarazione
-- codice fiscale produttore software
-- Nella parte non posizionale del record “D”, “E”, “F”, “G”, “H”, “I” e “J” devono
-- essere riportati esclusivamente i dati della dichiarazione il cui contenuto sia un valore
-- diverso da zero e da spazi.
-- Tutti i caratteri alfabetici devono essere impostati in maiuscolo.
-------------------------------------------------------------------------------------------------------
----------------------------------------- PARTE NON POSIZIONALE ---------------------------------------
-------------------------------------------------------------------------------------------------------
-- Prospetto SY - Somme liquidate a seguito di procedure di pignoramento presso terzi e ritenute da ---
----------------------------------------- art.25 del D.L.n.78/2010 ------------------------------------
-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------
-- Sezione I - Riservata al soggetto erogatore delle somme --
-------------------------------------------------------------

---------------------------------------------------
-- Sezione II - Riservata al debitore principale --
---------------------------------------------------

---------------------------------------------------------
-- Sezione III - Ritenute da art.25, del D.L n.78/2010 --
---------------------------------------------------------

-----------------------------------------------------------
-- CAMPI POSIZIONALI (da carattere 1890 a carattere 1900)--
-----------------------------------------------------------

	DECLARE @codfiscEnte varchar(16)
	declare @idcityEnte int
	SELECT @codfiscEnte = cf, @idcityEnte = idcity FROM license

	-- Fine Seconda Sezione dichiarativa

	-- Tabella di output che contiene le informazioni del record I (che successivamente verranno elaborate dal form del 770)
	CREATE TABLE #recordI
	(
		progr int,
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
		codeser varchar(20),
		npay int
	)

	-- Fase massima di spesa
	declare @annodichiarazione int
	set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})
	
	-- PIGNORAMENTI CON APPLICAZIONE DELLA RITENUTA
	INSERT INTO #expense
	(
		idexp,
		idreg,
		idreg_distrained,
		cf_reg,
		cf_reg_distrained,
		taxablenet,
		employtax, 
		admintax, 
		grossamount,--Importo Lordo del Pagamento
		transmissiondate,
		service,
		codeser,
		module,
		npay
	)
	SELECT
		T.idexp,
		T.idreg,
		T.idreg_distrained,
		isnull(R.cf,R.p_iva),
		isnull(R_DISTR.cf,R_DISTR.p_iva),
		SUM(T.taxablenet),
		SUM(T.employtax),
		SUM(T.admintax), 
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
		paymenttransmission.transmissiondate,
		service.description,
		service.codeser,
		service.module,
		payment.npay
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
	JOIN expense 
		ON expense.idexp = E.idexp
	JOIN expenselast
		ON expenselast.idexp = expense.idexp 
	JOIN service
		ON service.idser = expenselast.idser
	JOIN wageaddition W
		ON W.idser =  service.idser
	JOIN expensewageaddition EW
		ON EW.ycon = W.ycon
		AND EW.ncon = W.ncon
	JOIN expenselink EL
		ON EL.idparent = EW.idexp 
		AND EL.idchild =  E.idexp
	WHERE expense.ymov = @annoredditi  
		AND E.stop IS NULL
	GROUP BY expense.idreg,E.idexp,expenselast.idser,W.idreg_distrained,
		E.description ,expense.description,
        expenselast.kpay
                ) AS T
JOIN expensetotal
	ON T.idexp = expensetotal.idexp  
JOIN expenseyear
	ON T.idexp = expenseyear.idexp
JOIN service
	ON T.idser = service.idser  
JOIN payment 
	ON T.kpay = payment.kpay  
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
	JOIN registry R
		ON R.idreg = T.idreg 
	JOIN registry R_DISTR
		ON R_DISTR.idreg = T.idreg_distrained
WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and service.codeser = '11_PIGNORA'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay, paymenttransmission.transmissiondate,	
	isnull(R.cf,R.p_iva),isnull(R_DISTR.cf,R_DISTR.p_iva), service.codeser	
-- FINE PRELIEVO DATI DA expensetax

-- PIGNORAMENTI ESENTI DA RITENUTA
INSERT INTO #expense
	(
		idexp,
		idreg,
		idreg_distrained,
		cf_reg,
		cf_reg_distrained,
		taxablenet,
		employtax, 
		admintax, 
		grossamount,--Importo Lordo del Pagamento
		transmissiondate,
		service,
		codeser,
		module,
		npay
	)
	SELECT
		T.idexp,
		T.idreg,
		T.idreg_distrained,
		isnull(R.cf,R.p_iva),
		isnull(R_DISTR.cf,R_DISTR.p_iva),
		0,
		0,
		0, 
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
		paymenttransmission.transmissiondate,
		service.description,
		service.codeser,
		service.module,
		payment.npay
FROM
	(SELECT
		E.idexp as idexp,
		E.idreg as idreg,
		W.idreg_distrained as idreg_distrained,
		expenselast.idser as idser,
		expenselast.kpay as kpay
	FROM expense  E
	JOIN expenselast
		ON expenselast.idexp = E.idexp 
	JOIN service
		ON service.idser = expenselast.idser
	JOIN wageaddition W
		ON W.idser =  service.idser
	JOIN expensewageaddition EW
		ON EW.ycon = W.ycon
		AND EW.ncon = W.ncon
	JOIN expenselink EL
		ON EL.idparent = EW.idexp 
		AND EL.idchild =  E.idexp
	WHERE E.ymov = @annoredditi  
	GROUP BY E.idreg,E.idexp,expenselast.idser,W.idreg_distrained,
                expenselast.kpay) AS T
JOIN expensetotal
	ON T.idexp = expensetotal.idexp  
JOIN expenseyear
	ON T.idexp = expenseyear.idexp
JOIN service
	ON T.idser = service.idser  
JOIN payment 
	ON T.kpay = payment.kpay  
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission  
JOIN registry R
		ON R.idreg = T.idreg 
	JOIN registry R_DISTR
		ON R_DISTR.idreg = T.idreg_distrained

WHERE  YEAR(paymenttransmission.transmissiondate)=@annoredditi
	AND service.rec770kind = 'I'  and service.codeser = '11_PIGNORA_ESE'
	AND expensetotal.ayear = @annoredditi
	AND expenseyear.ayear = @annoredditi
GROUP BY T.idreg, T.idreg_distrained, T.idexp,
	expenseyear.amount, service.description, service.module,
	service.idser,payment.npay,paymenttransmission.transmissiondate,
	isnull(R.cf,R.p_iva),	isnull(R_DISTR.cf,R_DISTR.p_iva), service.codeser		

-- Ciclo con valorizzazione del progressivo modulo, ogni cinque pagamenti bisogna incrementare il progressivo modulo

DECLARE @contaPagamenti int
SET @contaPagamenti = 0

DECLARE @progrModulo int
SET @progrModulo = 0

DECLARE @cf_reg varchar(16)
DECLARE @cf_reg_distrained varchar(16)
DECLARE @taxablenet decimal(19,2)
DECLARE @employtax decimal(19,2)
DECLARE @admintax decimal(19,2)
DECLARE @grossamount decimal(19,2)
DECLARE @codeser varchar(20)

DECLARE cursoreexpense CURSOR FOR 
SELECT 
		#expense.cf_reg,
		#expense.cf_reg_distrained,
		isnull(sum(#expense.taxablenet),0),
		isnull(sum(#expense.employtax),0), 
		isnull(sum(#expense.admintax),0),
		isnull(sum(#expense.grossamount),0),--Importo Lordo del Pagamento
		#expense.codeser 
FROM #expense
GROUP BY #expense.cf_reg,
		#expense.cf_reg_distrained,#expense.codeser

DECLARE @progrCom int
SET @progrCom = 1

SELECT @codfiscEnte = cf FROM license
	DECLARE @cfsoftwarehouse varchar(16)
	SET @cfsoftwarehouse = '02890460781' --- TEMPO SRL
	
OPEN cursoreexpense
FETCH NEXT FROM cursoreexpense
INTO @cf_reg, @cf_reg_distrained, @taxablenet, @employtax,@admintax,@grossamount,@codeser
	WHILE @@FETCH_STATUS = 0
		BEGIN
		IF ((@contaPagamenti%5) = 0)  
			BEGIN
					SET  @progrModulo = @progrModulo + 1
					--1 Tipo record
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '01', 'I')
					--2 Codice fiscale del soggetto dichiarante
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '02', @codfiscEnte)
					--3 Progressivo modulo
						INSERT INTO #recordI (progr, quadro, riga, colonna, intero)  VALUES(@progrModulo, 'HRI', 1, '03', @progrModulo)
					--8 Identificativo del produttore del software (codice fiscale)
						INSERT INTO #recordI (progr, quadro, riga, colonna, stringa) VALUES(@progrModulo, 'HRI', 1, '08', @cfsoftwarehouse)
		    END
		
		/*
		SY002	001	2012-05-22 11:04:33.337	assistenza	Codice fiscale debitore principale 
		SY002	002	2012-05-22 11:04:33.337	assistenza	Codice fiscale creditore pignoratizio 
		SY002	003	2012-05-22 11:04:33.337	assistenza	Somme erogate 
		SY002	004	2012-05-22 11:04:33.337	assistenza	Ritenute operate 
		SY002	005	2012-05-22 11:04:33.337	assistenza	Ritenute non operate 
		*/
		--- attenzione! per i seguenti importi deve essere effettuato il troncamento della parte decimale e non l'arrotondamento
		INSERT INTO #recordI(progr,quadro, riga, colonna,stringa ) VALUES (@progrModulo, 'SY' +'00' + convert(varchar(1),@contaPagamenti%5 + 2),1, '001',@cf_reg_distrained)
		INSERT INTO #recordI(progr,quadro, riga, colonna,stringa ) VALUES (@progrModulo, 'SY' +'00' + convert(varchar(1),@contaPagamenti%5 + 2),1, '002',@cf_reg)
		IF @codeser = '11_PIGNORA_ESE' 
			BEGIN
				INSERT INTO #recordI(progr,quadro, riga, colonna,decimale ) VALUES (@progrModulo, 'SY' + '00' + convert(varchar(1),@contaPagamenti%5 + 2),1, '003',@grossamount)
				INSERT INTO #recordI(progr,quadro, riga, colonna,intero ) VALUES (@progrModulo, 'SY' + '00' + convert(varchar(1),@contaPagamenti%5 + 2),1, '005',1)
			END
		ELSE
			BEGIN
				INSERT INTO #recordI(progr,quadro, riga, colonna,decimale ) VALUES (@progrModulo, 'SY' + '00' + convert(varchar(1),@contaPagamenti%5 + 2),1, '003',@taxablenet)
				INSERT INTO #recordI(progr,quadro, riga, colonna,decimale ) VALUES (@progrModulo, 'SY' + '00' + convert(varchar(1),@contaPagamenti%5 + 2),1,'004',@employtax)
			END
		SET @contaPagamenti = @contaPagamenti + 1
		FETCH NEXT FROM cursoreexpense
		INTO @cf_reg, @cf_reg_distrained, @taxablenet, @employtax,@admintax,@grossamount,@codeser
	END
CLOSE cursoreexpense
DEALLOCATE cursoreexpense


SELECT * FROM #recordI

DROP TABLE #recordI
DROP TABLE #expense

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

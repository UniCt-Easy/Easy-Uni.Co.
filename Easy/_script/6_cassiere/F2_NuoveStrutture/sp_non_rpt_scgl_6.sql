/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿
--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\esportazione_transazione_bancaria.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[esportazione_transazione_bancaria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esportazione_transazione_bancaria]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--esportazione_transazione_bancaria 2007 ,'D'

CREATE        PROCEDURE [esportazione_transazione_bancaria]
@year smallint,
@kind char


AS BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
IF @kind='C'  --Movimenti a credito


SELECT  a.nban as 'Progressivo' ,
	a.transactiondate as 'Data transazione',
	a.valuedate as 'Data Valuta',
	p.npro as 'Numero Reversale',
	p.ypro as 'Esercizio Reversale',
	r.title 'Creditore',
	a.amount 'Importo Esitato'
FROM banktransaction a           
JOIN proceeds p
	on a.kpro = p.kpro
JOIN incomelast b
	on isnull(a.idpro,0)=isnull( b.idpro ,0) 
LEFT OUTER JOIN income i 
	on isnull(a.idinc,'')=isnull(i.idinc,'') 
join registry r
	on isnull(i.idreg,'')=isnull(r.idreg,'')
WHERE a.kind = @kind and p.ypro=@year
ELSE   --Movimenti a debito
SELECT  a.nban as 'Progressivo' ,
	a.transactiondate as 'Data transazione' ,
	a.valuedate as 'Data Valuta',
	p.npay as 'Numero Mandato' ,
	p.ypay as 'Esercizio Mandato' ,
	c.title 'Creditore', 	
	a.amount 'Importo Esitato'
FROM banktransaction a 
JOIN payment p
	on a.kpay = p.kpay
JOIN expenselast b 
	on isnull(a.idpay,0)=isnull( b.idpay,0) 
LEFT OUTER JOIN expense e
	on isnull(e.idexp,0)=isnull(b.idexp,0) 
join registry c 
	on isnull(e.idreg,0)=isnull(c.idreg,0)
WHERE a.kind=@kind and p.ypay=@year
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_check_financialprevision.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_financialprevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_financialprevision]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- exp_check_financialprevision 2007, {ts '2007-12-31 00:00:00'}

CREATE    PROCEDURE [exp_check_financialprevision]
(
@ayear int,
@competencydate datetime
)
AS
BEGIN

/* Versione 1.0.1 del 27/11/2007 ultima modifica: MARIA */

DECLARE @assessmentphase tinyint
SELECT @assessmentphase = assessmentphasecode FROM config WHERE ayear = @ayear

DECLARE @maxincomephase tinyint
SELECT @maxincomephase = MAX(nphase) FROM incomephase

DECLARE @jan01 datetime
SET @jan01 = CONVERT(datetime, '01-01-' + CONVERT(char(4), @ayear), 105)

DECLARE @fin_kind  tinyint
SELECT @fin_kind = fin_kind 
FROM config 
WHERE ayear = @ayear  

CREATE TABLE #errors (error varchar(1255))
-- Controllo che la gestione sia di competenza altrimenti non importa l'assegnazione dei crediti
IF (@fin_kind in (1,3))
BEGIN
	-- Controllo che ci siano le variazioni crediti di ripartizione
	IF (NOT EXISTS(SELECT * FROM finvar WHERE yvar = @ayear AND variationkind = 2 AND flagcredit = 'S') AND 
		EXISTS (SELECT * FROM finvar WHERE yvar = @ayear AND flagcredit = 'S'))
	BEGIN
		INSERT INTO #errors
		VALUES('Non sono state inserite variazioni crediti di Ripartizione')
		INSERT INTO #errors VALUES('')
	END
END
-- Controllo che ci siano le variazioni di cassa di ripartizione
IF NOT EXISTS(SELECT * FROM finvar WHERE yvar = @ayear AND variationkind = 2 and flagproceeds ='S')
BEGIN
	INSERT INTO #errors
	VALUES('Non sono state inserite variazioni di cassa di Ripartizione')
	INSERT INTO #errors VALUES('')
END
-- Controllo che gli accertamenti di competenza siano stati del tutto assegnati
IF (
	(SELECT SUM(ISNULL(amount,0))
	FROM creditpart
	WHERE ycreditpart = @ayear) 
	<>
	(SELECT SUM(ISNULL(incometotal.curramount,0))
	FROM incometotal
	JOIN income
		ON incometotal.idinc = income.idinc
	JOIN incomeyear
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	WHERE income.nphase = @assessmentphase
		AND incomeyear.ayear = @ayear
		AND ( (incometotal.flag & 1) =0)
		)
)
BEGIN
	INSERT INTO #errors
	VALUES('I crediti degli accertamenti di competenza non sono stati del tutto assegnati')
	INSERT INTO #errors
	SELECT '- Il credito dell''accertamento n. ' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov) +
	' non è stato assegnato per ' + CONVERT(varchar(22),(ISNULL(incometotal.curramount,0) - SUM(ISNULL(creditpart.amount,0))))
	FROM incometotal
	JOIN creditpart
		ON incometotal.idinc = creditpart.idinc
	JOIN income
		ON incometotal.idinc = income.idinc
		AND incometotal.ayear = creditpart.ycreditpart
	WHERE ycreditpart = @ayear 
	GROUP BY income.nmov,income.ymov,incometotal.curramount
	HAVING (ISNULL(incometotal.curramount,0) <> SUM(ISNULL(creditpart.amount,0)))

	INSERT INTO #errors
	SELECT '- All''accertamento n. ' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov) +
	' non è associata alcuna assegnazione crediti'
	FROM incometotal I
	JOIN income 
		ON I.idinc = income.idinc
	WHERE NOT EXISTS (SELECT C.idinc
			FROM creditpart C 
			WHERE I.idinc= C.idinc 	AND ycreditpart = @ayear)
		AND income.nphase =  @assessmentphase --AND LEN(I.idinc) = @assessmentphase*8
		AND ayear = @ayear
		AND income.ymov = @ayear --AND SUBSTRING(i.idinc,(@assessmentphase*8)-(8-1),2) = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)
		AND I.curramount>0

	INSERT INTO #errors VALUES('')
END
-- Controllo se gli incassi trasmessi prima della data di redazione del bilancio di previsione siano stati assegnati
IF (
	(SELECT SUM(ISNULL(amount,0))
	FROM proceedspart
	WHERE yproceedspart = @ayear
	AND idinc IN 
		(SELECT idinc
		FROM proceedscommunicated
		WHERE competencydate < @competencydate AND competencydate >=@jan01)) 
	<>
	(SELECT SUM(ISNULL(proceedscommunicated.curramount,0))
	FROM proceedscommunicated
	WHERE competencydate < @competencydate AND competencydate >=@jan01)
)
BEGIN
	INSERT INTO #errors
	VALUES('Gli incassi trasmessi prima della data di redazione del bilancio di previsione non sono stati del tutto assegnati')
	INSERT INTO #errors
	SELECT '- L''incasso dell''incasso n. ' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov) +
	' non è stato assegnato per ' + CONVERT(varchar(22),(ISNULL(proceedscommunicated.curramount,0) - SUM(ISNULL(proceedspart.amount,0))))
	FROM proceedscommunicated
	JOIN proceedspart
		ON proceedscommunicated.idinc = proceedspart.idinc
	JOIN income
		ON proceedscommunicated.idinc = income.idinc
		AND proceedscommunicated.ymov = proceedspart.yproceedspart
	WHERE yproceedspart = @ayear 
		AND (competencydate < @competencydate AND competencydate >=@jan01)
	GROUP BY income.nmov,income.ymov,proceedscommunicated.curramount
	HAVING (ISNULL(proceedscommunicated.curramount,0) <> SUM(ISNULL(proceedspart.amount,0)))

-- Controllo che agli incassi trasmessi sia associata una assegnazione incassi
	INSERT INTO #errors
	SELECT '- All''incasso trasmesso n. ' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov) +
	' non è associata alcuna assegnazione incassi'
	FROM proceedscommunicated I
	JOIN income
		ON I.idinc = income.idinc
	WHERE NOT EXISTS (SELECT P.idinc
			FROM proceedspart P 
			WHERE I.idinc = P.idinc
			AND yproceedspart = @ayear)
		AND I.ymov = @ayear
		--AND SUBSTRING(I.idinc,(@maxincomephaseint*8)-(8-1),2) = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)
		AND I.curramount>0
	INSERT INTO #errors VALUES('')
END
-- Controllo se gli incassi trasmessi prima della data di redazione del bilancio di previsione siano stati assegnati
IF (
	(SELECT SUM(ISNULL(amount,0))
	FROM proceedspart 
	WHERE yproceedspart = @ayear
	AND idinc NOT IN (SELECT idinc
		FROM proceedscommunicated
		WHERE competencydate < @competencydate AND competencydate >=@jan01)) 
	<>
	(SELECT ISNULL(SUM(imp.curramount),0)
	FROM incometotal imp
	JOIN income I
		ON I.idinc = imp.idinc
	WHERE imp.idinc NOT IN (SELECT idinc
			FROM proceedscommunicated
			WHERE competencydate < @competencydate AND competencydate >=@jan01)
		AND imp.ayear = @ayear
		--AND LEN(imp.idinc) = @maxincomephaseint * 8
		AND I.nphase = @maxincomephase)
	)
BEGIN
	INSERT INTO #errors
	VALUES('Gli incassi trasmessi dopo la data di redazione del bilancio di previsione o non ancora trasmessi non sono stati del tutto assegnati')
	INSERT INTO #errors
	SELECT '- L''incasso dell''incasso n. ' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov) +
	' non è stato assegnato per ' + CONVERT(varchar(22),(ISNULL(incometotal.curramount,0) - SUM(ISNULL(proceedspart.amount,0))))
	FROM incometotal
	JOIN proceedspart
		ON incometotal.idinc = proceedspart.idinc
		AND incometotal.ayear = proceedspart.yproceedspart
	JOIN income
		ON income.idinc = incometotal.idinc
	WHERE proceedspart.yproceedspart = @ayear 
		AND incometotal.idinc NOT IN
			(SELECT idinc
			FROM proceedscommunicated
			WHERE competencydate < @competencydate AND competencydate >=@jan01
			AND incometotal.idinc = idinc)
	GROUP BY income.nmov,income.ymov,incometotal.curramount
	HAVING (ISNULL(incometotal.curramount,0) <> SUM(ISNULL(proceedspart.amount,0)))

-- Controllo che agli incassi che non rientrano tra i trasmessi sia assegnata una assegnazione incassi
	INSERT INTO #errors
	SELECT '- All''incasso n. ' + CONVERT(varchar(6),I.nmov) + ' del ' + CONVERT(varchar(4),I.ymov) +
	' non è associata alcuna assegnazione incassi'
	FROM income I
	JOIN incometotal IT 
		on I.idinc = IT.idinc
	WHERE I.nphase = @maxincomephase AND I.ymov = @ayear	
	AND NOT EXISTS (SELECT P.idinc
		FROM proceedspart P
		WHERE I.idinc= P.idinc
			AND yproceedspart = @ayear)
			AND nphase = @maxincomephase
			AND IT.curramount>0
			AND IT.ayear=@ayear	
			--AND SUBSTRING(I.idinc,(@maxincomephaseint*8)-(8-1),2) = SUBSTRING(CONVERT(varchar(4),@ayear),3,2)
			AND I.idinc NOT IN (SELECT idinc FROM proceedscommunicated II
						WHERE II.idinc = I.idinc 
						AND (competencydate < @competencydate AND competencydate >=@jan01)
						)
	INSERT INTO #errors VALUES('')
END
-- ATTENZIONE: Questo controllo ha senso solo nel caso in cui si gestiscano i crediti
-- Infatti può accadere che nonostante un bilancio di competenza non venga effettuata l'assegnazione al credito
CREATE TABLE #creditpart (ayear int, idinc varchar(40), idupb varchar(36), idfin varchar(31), amount decimal(19,2))
CREATE TABLE #proceedspart (ayear int,idinc varchar(40), idupb varchar(36), idfin varchar(31), amount decimal(19,2))

IF EXISTS(SELECT * FROM creditpart WHERE ycreditpart = @ayear)	
	OR EXISTS (select * from upb where assured='S')
BEGIN
	INSERT INTO #creditpart
	(ayear, idinc,
	idupb, idfin, amount)
	SELECT ycreditpart, creditpart.idinc,
		idupb, creditpart.idfin, ISNULL(SUM(creditpart.amount),0)
	FROM creditpart
	JOIN incomeyear
		ON creditpart.idinc = incomeyear.idinc
		AND creditpart.ycreditpart = incomeyear.ayear
	WHERE ycreditpart = @ayear
	GROUP BY ycreditpart,creditpart.idinc,idupb,creditpart.idfin

	INSERT INTO #proceedspart
	(ayear, idinc,idupb, idfin, amount)
	SELECT yproceedspart, 
		incomelink.idparent, --SUBSTRING(proceedspart.idinc,1,@assessmentphaseint*8),
		idupb, proceedspart.idfin, ISNULL(SUM(proceedspart.amount),0)
	FROM proceedspart
	JOIN incomeyear
		ON proceedspart.idinc = incomeyear.idinc
		AND proceedspart.yproceedspart = incomeyear.ayear
	JOIN incomelink
		ON incomelink.idchild = incomeyear.idinc and incomelink.nlevel = @assessmentphase
	WHERE yproceedspart = @ayear
	GROUP BY yproceedspart,incomelink.idparent, --SUBSTRING(proceedspart.idinc,1,@assessmentphaseint*8),
		idupb,proceedspart.idfin

-- Controllo che l'assegnazione crediti degli accertamenti di competenza sia congrua con l'assegnazione incassi
	INSERT INTO #errors
	SELECT DISTINCT 'Gli incassi dipendenti dall''accertamento n.' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov)
	+ ' presentano assegnazioni incassi non congrue'
	FROM income
	JOIN #proceedspart inc		
		ON income.idinc = inc.idinc
	FULL OUTER JOIN #creditpart acc		
		ON acc.idinc = inc.idinc
		AND acc.idfin = inc.idfin
		AND acc.idupb = inc.idupb
	WHERE ISNULL(acc.amount,0) < ISNULL(inc.amount,0)
END
	SELECT error AS 'Elenco Errori' FROM #errors
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_consolidamento.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consolidamento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consolidamento]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_consolidamento
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint
)
AS BEGIN

/* Versione 1.0.1 del 16/11/2007 ultima modifica: Pino */

-- exec exp_consolidamento 2007,{ts '2007-08-30 00:00:00'},'E',3
CREATE TABLE #balance
(
	idfin int,
	code1 varchar(50),
	order1 varchar(50),
	fintitle varchar(150),
	code2 varchar(50),
	order2 varchar(50),
	code3 varchar(50),
	order3 varchar(50),
	code4 varchar(50),
	order4 varchar(50),
	-- flagincomesurplus char(1), NON LO USA MAI	
	mov_finphase_C_univ decimal(19,2),mov_finphase_C_direct decimal(19,2),mov_finphase_C_internal decimal(19,2),
	var_finphase_C_univ decimal(19,2),var_finphase_C_direct decimal(19,2),var_finphase_C_internal decimal(19,2),
	mov_maxphase_C_univ decimal(19,2),mov_maxphase_C_direct decimal(19,2),mov_maxphase_C_internal decimal(19,2),
	var_maxphase_C_univ decimal(19,2),var_maxphase_C_direct decimal(19,2),var_maxphase_C_internal decimal(19,2),
	mov_finphase_R_univ decimal(19,2),mov_finphase_R_direct decimal(19,2),mov_finphase_R_internal decimal(19,2),
	var_finphase_R_univ decimal(19,2),var_finphase_R_direct decimal(19,2),var_finphase_R_internal decimal(19,2),
	mov_maxphase_R_univ decimal(19,2),mov_maxphase_R_direct decimal(19,2),mov_maxphase_R_internal decimal(19,2),
	var_maxphase_R_univ decimal(19,2),var_maxphase_R_direct decimal(19,2),var_maxphase_R_internal decimal(19,2)
)


DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue FROM generalreportparameter WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @finphase tinyint
DECLARE @maxphase tinyint
DECLARE @registryphase varchar(20)


IF (@finpart = 'E')
BEGIN
	-- ricerca la fase equivalente all'accertamento
	-- se è stata inserita nella tabella di configurazione del bilancio
	SELECT @finphase = assessmentphasecode FROM config WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase = incomefinphase FROM uniconfig
	END
	
	SELECT @registryphase = incomeregphase FROM uniconfig
	-- la fase di cassa è sempre l'ultima fase della procedura
	-- di entrata
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
IF (@finpart = 'S')
BEGIN
	-- ricerca la fase equivalente all'impegno
	-- se è stata inserita nella tabella di configurazione
	-- del bilancio
	SELECT @finphase = appropriationphasecode FROM config WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase = expensefinphase FROM uniconfig
	END
	SELECT @registryphase = expenseregphase FROM uniconfig
	-- la fase di cassa è sempre l'ultima fase della procedura di spesa
	SELECT @maxphase = MAX(nphase) FROM expensephase
END
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)
IF (@finpart = 'E')
BEGIN
	-- Fondo cassa e avanzo di amministrazione presunti ed effettivi al 01/01
	-- dell'ayear per il quale si effettua il consuntivo.
	SELECT	@supposed_ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
		ISNULL(paymentstilldate, 0) -
		ISNULL(paymentstoendofyear, 0),
	@supposed_aa_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
		ISNULL(paymentstilldate, 0) -
		ISNULL(paymentstoendofyear, 0) +
		ISNULL(supposedpreviousrevenue, 0) +
		ISNULL(supposedcurrentrevenue , 0) -
		ISNULL(supposedpreviousexpenditure, 0) -
		ISNULL(supposedcurrentexpenditure, 0),
	@ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds, 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments, 0),
	@aa_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds , 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments  , 0) +
		ISNULL(previousrevenue, 0) +
		ISNULL(currentrevenue , 0) -
		ISNULL(previousexpenditure, 0) -
		ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1
END


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

INSERT INTO #balance
(
	idfin,
	code1, order1,
	code2, order2,
	code3, order3,
	code4, order4/*,
	flagincomesurplus*/

)
SELECT 
	f4.idfin, 
	f1.codefin, f1.printingorder,
	f2.codefin, f2.printingorder,
	f3.codefin, f3.printingorder,
	f4.codefin, f4.printingorder/*,
	f4.flagincomesurplus*/
FROM fin f4
JOIN finlevel fl
	ON f4.nlevel = fl.nlevel AND  f4.ayear = fl.ayear
LEFT OUTER JOIN fin f3
	ON f3.idfin = f4.paridfin
LEFT OUTER JOIN fin f2
	ON f2.idfin = f3.paridfin
LEFT OUTER JOIN fin f1
	ON f1.idfin = f2.paridfin
WHERE f4.ayear = @ayear
	AND ((f4.flag & 1)= @finpart_bit) -- AND f4.finpart = @finpart
	AND f4.nlevel = @levelusable

DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4

UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = code2, code2 = code3, code3 = code4, code4 = NULL WHERE code1 IS NULL
UPDATE #balance SET code1 = SUBSTRING(code1, @startpos1, @lencod_lev1)
UPDATE #balance SET code2 = SUBSTRING(code2, @startpos2, @lencod_lev2)
UPDATE #balance SET code3 = SUBSTRING(code3, @startpos3, @lencod_lev3)
UPDATE #balance SET code4 = SUBSTRING(code4, @startpos4, @lencod_lev4)
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = order2, order2 = order3, order3 = order4, order4 = NULL WHERE order1 IS NULL
UPDATE #balance SET order1 = SUBSTRING(order1, @startpos1, @lencod_lev1)
UPDATE #balance SET order2 = SUBSTRING(order2, @startpos2, @lencod_lev2)
UPDATE #balance SET order3 = SUBSTRING(order3, @startpos3, @lencod_lev3)
UPDATE #balance SET order4 = SUBSTRING(order4, @startpos4, @lencod_lev4)

CREATE TABLE #mov_finphase_C (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_finphase_C (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #mov_finphase_R (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_finphase_R (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #mov_maxphase_C (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_maxphase_C (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #mov_maxphase_R (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_maxphase_R (idfin varchar(31),totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))

IF @finpart = 'E'
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (IY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (IY.amount)
				else 0	
			end),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN registry R 
		ON I.idreg = R.idreg
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- 'C'
		AND I.nphase = @registryphase
	GROUP BY ISNULL(FLK.idparent,IY.idfin)--SUBSTRING(IY.idfin, 1, @lengthidfinop)

	INSERT INTO #var_finphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (IV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (IV.amount)
				else 0	
			end),0)	
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON  I.idinc = IY.idinc
	JOIN registry R 
		ON I.idreg = R.idreg
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- 'C'
		AND I.nphase = @registryphase
		AND IV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,IY.idfin)--SUBSTRING(IY.idfin, 1, @lengthidfinop)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti

	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (IY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (IY.amount)
				else 0	
			end),0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN registry R 
		ON I.idreg = R.idreg
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- 'R'
		AND I.nphase = @finphase
		AND I.adate <= @date
	GROUP BY ISNULL(FLK.idparent,IY.idfin)--SUBSTRING(IY.idfin, 1, @lengthidfinop)

	INSERT INTO #var_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (IV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (IV.amount)
				else 0	
			end),0)	
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN registry R 
		ON I.idreg = R.idreg
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- 'R'
		AND I.nphase = @finphase
		AND IV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,IY.idfin)--SUBSTRING(IY.idfin, 1, @lengthidfinop)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (HPV.amount)
				else 0	
			end),0)	
	FROM historyproceedsview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 0)--'C'
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin)--SUBSTRING(IY.idfin, 1, @lengthidfinop)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin), --SUBSTRING(IY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (HPV.amount)
				else 0	
			end),0)	
	FROM historyproceedsview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 1)-- 'R'
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin) --SUBSTRING(IY.idfin, 1, @lengthidfinop)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			totuniv,
			totinterni,
			totdiretti
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (IV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory = 'U' then (IV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (IV.amount)
					else 0	
				end),0)	
		FROM incomevar IV
		JOIN income I
			ON I.idinc = IV.idinc
		JOIN registry R 
			ON I.idreg = R.idreg
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)-- 'C'
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY ISNULL(FLK.idparent,HPV.idfin) --SUBSTRING(IY.idfin, 1, @lengthidfinop)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			totuniv,
			totinterni,
			totdiretti
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(IY.idfin, 1, @lengthidfinop),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (IV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory = 'U' then (IV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (IV.amount)
					else 0	
				end),0)	
		FROM incomevar IV
		JOIN income I
			ON I.idinc = IV.idinc
		JOIN registry R 
			ON I.idreg = R.idreg
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND ( (HPV.totflag & 1) = 1)
			AND IV.adate <= @date
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY ISNULL(FLK.idparent,HPV.idfin)--SUBSTRING(IY.idfin, 1, @lengthidfinop)
	END
END
IF @finpart = 'S'
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (EY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (EY.amount)
				else 0	
			end),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN registry R
		ON E.idreg = R.idreg
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- 'C'
		AND E.nphase = @registryphase
	GROUP BY ISNULL(FLK.idparent,EY.idfin)--SUBSTRING(EY.idfin, 1, @lengthidfinop)

	INSERT INTO #var_finphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (EV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (EV.amount)
				else 0	
			end),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN registry R
		ON E.idreg = R.idreg
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- 'C'
		AND E.nphase = @registryphase
		AND EV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,EY.idfin) -- SUBSTRING(EY.idfin, 1, @lengthidfinop)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin), --SUBSTRING(EY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (EY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (EY.amount)
				else 0	
			end),0)
	FROM expenseyear EY
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN registry R
		ON E.idreg = R.idreg
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- 'R'
		AND E.nphase = @finphase
		AND E.adate <= @date
	GROUP BY ISNULL(FLK.idparent,EY.idfin) --SUBSTRING(EY.idfin, 1, @lengthidfinop)

	INSERT INTO #var_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (EV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (EV.amount)
				else 0	
			end),0)	
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN registry R 
		ON E.idreg = R.idreg
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- 'R'
		AND E.nphase = @finphase
		AND EV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,EY.idfin)--SUBSTRING(EY.idfin, 1, @lengthidfinop)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin), --SUBSTRING(EY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (HPV.amount)
				else 0	
			end),0)	
	FROM historypaymentview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 0)-- 'C'
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin) -- ISNULL(FLK.idparent,EY.idfin)--SUBSTRING(EY.idfin, 1, @lengthidfinop)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory = 'U' then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (HPV.amount)
				else 0	
			end),0)	
	FROM historypaymentview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 1)-- 'R'
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin)--SUBSTRING(EY.idfin, 1, @lengthidfinop)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			totuniv,
			totinterni,
			totdiretti
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (EV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory = 'U' then (EV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (EV.amount)
					else 0	
				end),0)	
		FROM expensevar EV
		JOIN expense E
			ON E.idexp = EV.idexp
		JOIN registry R 
			ON E.idreg = R.idreg
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND ( (HPV.totflag & 1) = 0)--'C'
		GROUP BY ISNULL(FLK.idparent,HPV.idfin)--SUBSTRING(EY.idfin, 1, @lengthidfinop)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			totuniv,
			totinterni,
			totdiretti

		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (EV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory = 'U' then (EV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when isnull(R.idcentralizedcategory,'X') NOT IN ('A','U') then (EV.amount)
					else 0	
				end),0)	
		FROM expensevar EV
		JOIN expense E
			ON E.idexp = EV.idexp
		JOIN registry R 
			ON E.idreg = R.idreg
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND ( (HPV.totflag & 1) = 1)-- 'R'
			AND EV.adate <= @date
		GROUP BY ISNULL(FLK.idparent,HPV.idfin)--SUBSTRING(EY.idfin, 1, @lengthidfinop)
	END
END


UPDATE #balance
SET 
	/*varprev_m =
	ISNULL(
		(SELECT  SUM(ISNULL(#tot_varprev_M.total,0))  FROM #tot_varprev_M
		WHERE #tot_varprev_M.idfin = #balance.idfin)
	, 0),*/
	mov_finphase_C_univ =
	ISNULL(
		(SELECT  SUM(ISNULL(#mov_finphase_C.totuniv,0))  FROM #mov_finphase_C
		WHERE #mov_finphase_C.idfin = #balance.idfin)
	, 0),
	mov_finphase_C_direct =
	ISNULL(
		(SELECT  SUM(ISNULL(#mov_finphase_C.totdiretti,0))  FROM #mov_finphase_C
		WHERE #mov_finphase_C.idfin = #balance.idfin)
	, 0),
	mov_finphase_C_internal =
	ISNULL(
		(SELECT  SUM(ISNULL(#mov_finphase_C.totinterni,0))  FROM #mov_finphase_C
		WHERE #mov_finphase_C.idfin = #balance.idfin)
	, 0),

	var_finphase_C_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#var_finphase_C.totuniv,0)) FROM #var_finphase_C
		WHERE  #var_finphase_C.idfin = #balance.idfin)
	, 0),
	var_finphase_C_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#var_finphase_C.totdiretti,0)) FROM #var_finphase_C
		WHERE  #var_finphase_C.idfin = #balance.idfin)
	, 0),
	var_finphase_C_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#var_finphase_C.totinterni,0)) FROM #var_finphase_C
		WHERE  #var_finphase_C.idfin = #balance.idfin)
	, 0),

	mov_maxphase_C_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_maxphase_C.totuniv,0)) FROM #mov_maxphase_C
		WHERE  #mov_maxphase_C.idfin = #balance.idfin)
	, 0),
	mov_maxphase_C_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_maxphase_C.totdiretti,0)) FROM #mov_maxphase_C
		WHERE  #mov_maxphase_C.idfin = #balance.idfin)
	, 0),
	mov_maxphase_C_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_maxphase_C.totinterni,0)) FROM #mov_maxphase_C
		WHERE  #mov_maxphase_C.idfin = #balance.idfin)
	, 0),

	var_maxphase_C_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#var_maxphase_C.totuniv,0)) FROM #var_maxphase_C
		WHERE #var_maxphase_C.idfin = #balance.idfin)
	, 0),
	var_maxphase_C_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#var_maxphase_C.totdiretti,0)) FROM #var_maxphase_C
		WHERE #var_maxphase_C.idfin = #balance.idfin)
	, 0),
	var_maxphase_C_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#var_maxphase_C.totinterni,0)) FROM #var_maxphase_C
		WHERE #var_maxphase_C.idfin = #balance.idfin)
	, 0),
	mov_finphase_R_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_finphase_R.totuniv,0)) FROM #mov_finphase_R
		WHERE  #mov_finphase_R.idfin = #balance.idfin)
	, 0),
	mov_finphase_R_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_finphase_R.totdiretti,0)) FROM #mov_finphase_R
		WHERE  #mov_finphase_R.idfin = #balance.idfin)
	, 0),
	mov_finphase_R_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_finphase_R.totinterni,0)) FROM #mov_finphase_R
		WHERE  #mov_finphase_R.idfin = #balance.idfin)
	, 0),
	var_finphase_R_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#var_finphase_R.totuniv,0)) FROM #var_finphase_R
		WHERE #var_finphase_R.idfin = #balance.idfin)
	, 0),
	var_finphase_R_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#var_finphase_R.totdiretti,0)) FROM #var_finphase_R
		WHERE #var_finphase_R.idfin = #balance.idfin)
	, 0),

	var_finphase_R_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#var_finphase_R.totinterni,0)) FROM #var_finphase_R
		WHERE #var_finphase_R.idfin = #balance.idfin)
	, 0),

	mov_maxphase_R_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_maxphase_R.totuniv,0)) FROM #mov_maxphase_R
	        WHERE  #mov_maxphase_R.idfin = #balance.idfin)
	, 0),
	mov_maxphase_R_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_maxphase_R.totdiretti,0)) FROM #mov_maxphase_R
	        WHERE  #mov_maxphase_R.idfin = #balance.idfin)
	, 0),
	mov_maxphase_R_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#mov_maxphase_R.totinterni,0)) FROM #mov_maxphase_R
	        WHERE  #mov_maxphase_R.idfin = #balance.idfin)
	, 0),
	var_maxphase_R_univ =
	ISNULL(
		(SELECT SUM(ISNULL(#var_maxphase_R.totuniv,0)) FROM #var_maxphase_R
		WHERE  #var_maxphase_R.idfin = #balance.idfin)
	, 0),
	var_maxphase_R_direct =
	ISNULL(
		(SELECT SUM(ISNULL(#var_maxphase_R.totdiretti,0)) FROM #var_maxphase_R
		WHERE  #var_maxphase_R.idfin = #balance.idfin)
	, 0),
	var_maxphase_R_internal =
	ISNULL(
		(SELECT SUM(ISNULL(#var_maxphase_R.totinterni,0)) FROM #var_maxphase_R
		WHERE  #var_maxphase_R.idfin = #balance.idfin)
	, 0)

INSERT INTO #balance (
	order1,fintitle,
	mov_finphase_C_univ,
	mov_finphase_C_direct,
	mov_finphase_C_internal ,
	var_finphase_C_univ ,
	var_finphase_C_direct ,
	var_finphase_C_internal ,
	mov_maxphase_C_univ,
	mov_maxphase_C_direct,
	mov_maxphase_C_internal,
	var_maxphase_C_univ,
	var_maxphase_C_direct,
	var_maxphase_C_internal,
	mov_finphase_R_univ,
	mov_finphase_R_direct,
	mov_finphase_R_internal,
	var_finphase_R_univ,
	var_finphase_R_direct,
	var_finphase_R_internal,
	mov_maxphase_R_univ,
	mov_maxphase_R_direct,
	mov_maxphase_R_internal,
	var_maxphase_R_univ,
	var_maxphase_R_direct,
	var_maxphase_R_internal 
	)
SELECT 
	'97','T O T A L E ',
	ISNULL(SUM(mov_finphase_C_univ),0),
	ISNULL(SUM(mov_finphase_C_direct),0),
	ISNULL(SUM(mov_finphase_C_internal),0),
	ISNULL(SUM(var_finphase_C_univ),0),
	ISNULL(SUM(var_finphase_C_direct),0),
	ISNULL(SUM(var_finphase_C_internal),0) ,
	ISNULL(SUM(mov_maxphase_C_univ),0),
	ISNULL(SUM(mov_maxphase_C_direct),0),
	ISNULL(SUM(mov_maxphase_C_internal),0),
	ISNULL(SUM(var_maxphase_C_univ),0),
	ISNULL(SUM(var_maxphase_C_direct),0),
	ISNULL(SUM(var_maxphase_C_internal),0),
	ISNULL(SUM(mov_finphase_R_univ),0),
	ISNULL(SUM(mov_finphase_R_direct),0),
	ISNULL(SUM(mov_finphase_R_internal),0),
	ISNULL(SUM(var_finphase_R_univ),0),
	ISNULL(SUM(var_finphase_R_direct),0),
	ISNULL(SUM(var_finphase_R_internal),0),
	ISNULL(SUM(mov_maxphase_R_univ),0),
	ISNULL(SUM(mov_maxphase_R_direct),0),
	ISNULL(SUM(mov_maxphase_R_internal),0),
	ISNULL(SUM(var_maxphase_R_univ),0),
	ISNULL(SUM(var_maxphase_R_direct),0),
	ISNULL(SUM(var_maxphase_R_internal),0) 
FROM #balance



DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 1
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 2
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 3
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 4
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 5

SELECT 
	order1,
	ISNULL(code1,'')+ISNULL(code2,'')+ISNULL(code3,'')+ISNULL(code4,''),	
	ISNULL(f4.title,ISNULL(f3.title,ISNULL(f2.title,ISNULL(f1.title,'T O T A L E  G E N E R A L E')))),
	ISNULL(SUM(mov_finphase_C_univ),0),
	ISNULL(SUM(mov_finphase_C_direct),0),
	ISNULL(SUM(mov_finphase_C_internal),0),
	ISNULL(SUM(var_finphase_C_univ),0),
	ISNULL(SUM(var_finphase_C_direct),0),
	ISNULL(SUM(var_finphase_C_internal),0) ,
	ISNULL(SUM(mov_maxphase_C_univ),0),
	ISNULL(SUM(mov_maxphase_C_direct),0),
	ISNULL(SUM(mov_maxphase_C_internal),0),
	ISNULL(SUM(var_maxphase_C_univ),0),
	ISNULL(SUM(var_maxphase_C_direct),0),
	ISNULL(SUM(var_maxphase_C_internal),0),
	ISNULL(SUM(mov_finphase_R_univ),0),
	ISNULL(SUM(mov_finphase_R_direct),0),
	ISNULL(SUM(mov_finphase_R_internal),0),
	ISNULL(SUM(var_finphase_R_univ),0),
	ISNULL(SUM(var_finphase_R_direct),0),
	ISNULL(SUM(var_finphase_R_internal),0),
	ISNULL(SUM(mov_maxphase_R_univ),0),
	ISNULL(SUM(mov_maxphase_R_direct),0),
	ISNULL(SUM(mov_maxphase_R_internal),0),
	ISNULL(SUM(var_maxphase_R_univ),0),
	ISNULL(SUM(var_maxphase_R_direct),0),
	ISNULL(SUM(var_maxphase_R_internal),0),
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01
FROM #balance
	/*LEFT OUTER JOIN fin f1
		ON f1.idfin = LEFT(#balance.idfin, 7)
		AND f1.nlevel = '1'*/
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #balance.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 

	/*LEFT OUTER JOIN fin f2
		ON f2.idfin = LEFT(#balance.idfin,11)
		AND f2.nlevel = '2'*/
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #balance.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 

	/*LEFT OUTER JOIN fin f3
		ON f3.idfin = LEFT(#balance.idfin,15)
		AND f3.nlevel = '3'*/
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #balance.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 

	/*LEFT OUTER JOIN fin f4
		ON f4.idfin = LEFT(#balance.idfin,19)
		AND f4.nlevel = '4'*/
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = #balance.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 

GROUP BY #balance.idfin,code1,f1.title,order1,code2,f2.title,order2,code3,
	f3.title,order3,code4,f4.title,order4	
ORDER BY order1 ASC, order2 ASC, order3 ASC, order4 ASC

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_consuntivo.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consuntivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consuntivo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE   PROCEDURE [exp_consuntivo]
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showchildupb char(1)
)
AS BEGIN
/* Versione 1.0.1 del 16/11/2007 ultima modifica: Pino */

CREATE TABLE #balance
(
	idfin int,
	codefin varchar(50),
	description varchar(150),
	printingorder varchar(31),
	initialprevision decimal(19,2),
	var_prev_M_acc decimal(19,2),
	var_prev_M_red decimal(19,2),
	secondaryprev decimal(19,2),
	var_prev_S_acc decimal(19,2),
	var_prev_S_red decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_acc_R decimal(19,2),
	var_finphase_red_R decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2)
)

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @infoadvance char(1)
SELECT  @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @finphase tinyint
DECLARE @maxphase tinyint


DECLARE @idavanzocassa  int
DECLARE @idavanzoamm int

SET @idavanzocassa  = -1
SET @idavanzoamm = -2


IF (@finpart = 'E')
BEGIN
	-- ricerca la fase equivalente all'accertamento
	-- se è stata inserita nella tabella di configurazione del bilancio
	SELECT @finphase = assessmentphasecode FROM config WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase = incomefinphase FROM uniconfig
	END
	-- la fase di cassa è sempre l'ultima fase della procedura
	-- di entrata
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
IF (@finpart = 'S')
BEGIN
	-- ricerca la fase equivalente all'impegno
	-- se è stata inserita nella tabella di configurazione
	-- del bilancio
	SELECT @finphase = appropriationphasecode FROM config WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase = expensefinphase FROM uniconfig
	END
	-- la fase di cassa è sempre l'ultima fase della procedura di spesa
	SELECT @maxphase = MAX(nphase) FROM expensephase
END
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)

DECLARE @idfinincomesurplus int -- Flag indicante se l'avanzo di amministrazione è attribuito in previsione ad un capitolo di entrata o no
SELECT  @idfinincomesurplus = isnull(idfinincomesurplus,0) 
	FROM config
	WHERE ayear = @ayear

IF (@finpart = 'E')
BEGIN
	-- Fondo cassa e avanzo di amministrazione presunti ed effettivi al 01/01
	-- dell'ayear per il quale si effettua il consuntivo.
	SELECT	@supposed_ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
		ISNULL(paymentstilldate, 0) -
		ISNULL(paymentstoendofyear, 0),
	@supposed_aa_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
		ISNULL(paymentstilldate, 0) -
		ISNULL(paymentstoendofyear, 0) +
		ISNULL(supposedpreviousrevenue, 0) +
		ISNULL(supposedcurrentrevenue , 0) -
		ISNULL(supposedpreviousexpenditure, 0) -
		ISNULL(supposedcurrentexpenditure, 0),
	@ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds, 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments, 0),
	@aa_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(competencyproceeds, 0) +
		ISNULL(residualproceeds , 0) -
		ISNULL(competencypayments, 0) -
		ISNULL(residualpayments  , 0) +
		ISNULL(previousrevenue, 0) +
		ISNULL(currentrevenue , 0) -
		ISNULL(previousexpenditure, 0) -
		ISNULL(currentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1
END
INSERT INTO #balance
(
	idfin,
	codefin, printingorder,
	initialprevision,
	secondaryprev
)
SELECT 
	f.idfin, 
	f.codefin, f.printingorder,
	ISNULL(SUM(fy.prevision),0), 
	ISNULL(SUM(fy.secondaryprev),0)
FROM fin f
CROSS JOIN upb 
JOIN finlevel fl
	ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
LEFT OUTER JOIN finyear fy
	ON fy.idfin = f.idfin
	AND fy.idupb = upb.idupb
WHERE f.ayear = @ayear
	AND (upb.idupb LIKE @idupb)
	AND ((f.flag & 1)= @finpart_bit)
	AND (f.nlevel = @levelusable
		OR (f.nlevel < @levelusable
			AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
			AND (fl.flag&2)<>0
			)
		)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR f.idfin <> @idfinincomesurplus )
GROUP BY f.idfin, f.codefin, f.printingorder, f.nlevel

CREATE TABLE #tot_varprev_acc_M (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_acc_M
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #tot_varprev_red_M (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_red_M
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)
	
CREATE TABLE #tot_varprev_acc_S (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_acc_S
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #tot_varprev_red_S (idfin int, total decimal(19,2))
INSERT INTO #tot_varprev_red_S
(
	idfin,
	total
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	-ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)


CREATE TABLE #mov_finphase_C (idfin int, total decimal(19,2))
CREATE TABLE #var_finphase_C (idfin int, total decimal(19,2))
CREATE TABLE #mov_finphase_R (idfin int, total decimal(19,2))
CREATE TABLE #var_finphase_acc_R (idfin int, total decimal(19,2))
CREATE TABLE #var_finphase_red_R (idfin int, total decimal(19,2))
CREATE TABLE #mov_maxphase_C (idfin int, total decimal(19,2))
CREATE TABLE #var_maxphase_C (idfin int, total decimal(19,2))
CREATE TABLE #mov_maxphase_R (idfin int, total decimal(19,2))
CREATE TABLE #var_maxphase_R (idfin int, total decimal(19,2))
IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IY.amount),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE I.adate <= @date
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- 'C'
		AND I.nphase = @finphase
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- 'C'
		AND I.nphase = @finphase
		AND IV.adate <= @date 
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IY.amount),0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IY.ayear = @ayear
		AND IY.idupb LIKE @idupb
		AND ( (IT.flag & 1) = 1)-- 'R'
		AND I.nphase = @finphase
		AND I.adate <= @date
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_acc_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- 'R'
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount > 0
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_red_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
	WHERE IV.yvar = @ayear
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- 'R'
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount < 0
	GROUP BY IY.idupb,ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb
		AND HPV.flagarrear = 'C'
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb
		AND HPV.flagarrear = 'R'
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND HPV.idupb LIKE @idupb
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)-- 'C'
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND HPV.idupb LIKE @idupb
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 1)-- 'R'
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	END
END
IF @finpart = 'S'
BEGIN

	INSERT INTO #mov_finphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- 'C'
		AND E.nphase = @finphase
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- 'C'
		AND E.nphase = @finphase
		AND EV.adate <= @date 
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE E.adate <= @date
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1)
		AND E.nphase = @finphase
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_acc_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- 'R'
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount > 0
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #var_finphase_red_R
	(
		idfin,
		total
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- 'R'
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount < 0
	GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb
		AND ( (HPV.totflag & 1) = 0)-- 'C'
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		total
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND HPV.idupb LIKE @idupb	
		AND ( (HPV.totflag & 1) = 1) -- R 
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND  HPV.idupb LIKE @idupb
			AND EV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)--'C'
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY  HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			total
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND  HPV.idupb LIKE @idupb
			AND EV.adate <= @date
			AND ( (HPV.totflag & 1) = 1)--'R'
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY  HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)
	END
END

UPDATE #balance
SET var_prev_m_acc =
ISNULL(
	(SELECT SUM(#tot_varprev_acc_M.total) FROM #tot_varprev_acc_M
	WHERE #tot_varprev_acc_M.idfin = #balance.idfin)
, 0),
var_prev_m_red = 
ISNULL(
	(SELECT SUM(#tot_varprev_red_M.total) FROM #tot_varprev_red_M
	WHERE #tot_varprev_red_M.idfin = #balance.idfin),
0),
var_prev_s_acc =
ISNULL(
	(SELECT SUM(#tot_varprev_acc_S.total) FROM #tot_varprev_acc_S
	WHERE #tot_varprev_acc_S.idfin = #balance.idfin),
0),
var_prev_s_red =
ISNULL(
	(SELECT SUM(#tot_varprev_red_S.total) FROM #tot_varprev_red_S
	WHERE #tot_varprev_red_S.idfin = #balance.idfin), 0),
mov_finphase_C =
ISNULL(
	(SELECT SUM(#mov_finphase_C.total) FROM #mov_finphase_C
	WHERE #mov_finphase_C.idfin = #balance.idfin)
, 0),
var_finphase_C =
ISNULL(
	(SELECT SUM(#var_finphase_C.total) FROM #var_finphase_C
	WHERE #var_finphase_C.idfin = #balance.idfin)
, 0),
mov_maxphase_C =
ISNULL(
	(SELECT SUM(#mov_maxphase_C.total) FROM #mov_maxphase_C
	WHERE #mov_maxphase_C.idfin = #balance.idfin)
, 0),
var_maxphase_C =
ISNULL(
	(SELECT SUM(#var_maxphase_C.total) FROM #var_maxphase_C
	WHERE #var_maxphase_C.idfin = #balance.idfin)
, 0),
mov_finphase_R =
ISNULL(
	(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
	WHERE #mov_finphase_R.idfin = #balance.idfin)
, 0),
var_finphase_acc_R =
ISNULL(
	(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
	WHERE #var_finphase_acc_R.idfin = #balance.idfin)
, 0),
var_finphase_red_R =
ISNULL(
	(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
	WHERE #var_finphase_red_R.idfin = #balance.idfin)
, 0),
mov_maxphase_R =
ISNULL(
	(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
        WHERE #mov_maxphase_R.idfin = #balance.idfin)
, 0),
var_maxphase_R =
ISNULL(
	(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
	WHERE #var_maxphase_R.idfin = #balance.idfin)
, 0)

DECLARE @supposed_cash_jan01 decimal(19,2)
DECLARE @cash_jan01 decimal(19,2)
DECLARE @supposed_amm_jan01 decimal(19,2)
DECLARE @var_ff_acc decimal(19,2)
DECLARE @var_ff_red decimal(19,2)
DECLARE @var_aa_acc decimal(19,2)
DECLARE @var_aa_red decimal(19,2)
--DECLARE @previsionkind_M char(1)
--DECLARE @previsionkind_S char(1)
--SELECT  @previsionkind_M = previsionkind, @previsionkind_S = secprevisionkind
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind
FROM    config
WHERE   ayear = @ayear
print   @fin_kind
-- Competenza Pura
IF (@fin_kind = 1)
BEGIN 
	IF (@finpart = 'E')
	BEGIN   
		IF (@infoadvance <> 'N')
		BEGIN
			IF (@aa_jan01 > 0)
			BEGIN
				SET @supposed_amm_jan01 = @supposed_aa_jan01
				IF (@aa_jan01 - @supposed_aa_jan01) >0 
				BEGIN
					SET @var_aa_acc = (@aa_jan01 - @supposed_aa_jan01)
					SET @var_aa_red = 0
				END
				ELSE
				BEGIN
					SET @var_aa_acc = 0
					SET @var_aa_red = (@aa_jan01 - @supposed_aa_jan01)
				END
			END
		ELSE
		BEGIN
			SET @supposed_amm_jan01 = 0
			SET @var_aa_acc = 0
			SET @var_aa_red = 0
		END
		-- Inserisce la riga relativa all'avanzo di amministrazione
		INSERT INTO #balance
		(
			idfin, codefin, description, 
			initialprevision,
			var_prev_M_acc,
			var_prev_M_red
		)
		VALUES
		(
			@idavanzoamm , ' ', 'Avanzo di Amministrazione', ---avanzo amministrazione 0
			@supposed_amm_jan01,
			@var_aa_acc,
			@var_aa_red)
	END
	
	SELECT
		CASE
			WHEN #balance.idfin = @idavanzoamm   ---avanzo amministrazione 0
			THEN #balance.codefin
			ELSE fin.codefin
		END AS 'Codice Bilancio',
		CASE
			WHEN #balance.idfin = @idavanzoamm   ---avanzo amministrazione 0
			THEN #balance.description
			ELSE fin.title
		END AS 'Denominazione',
		initialprevision AS 'Prev. di competenza iniziale', 
		var_prev_M_acc AS 'Var. aumento prev. Competenza',
		- var_prev_M_red AS 'Var. dimin. prev. Competenza',
		(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. Competenza Definitiva',
		(mov_maxphase_C + var_maxphase_C) AS 'Accertamenti riscossi',
		(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C) AS 'Accertamenti da riscuotere',
		(mov_finphase_C + var_finphase_C) AS 'Totale somme accertate',
		CASE #balance.idfin
			WHEN @idavanzoamm  THEN NULL
			ELSE (initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C - var_finphase_C)
		END AS 'Differenza rispetto alle previsioni',
		mov_finphase_R AS 'Residui Attivi Iniziali' ,
		(mov_maxphase_R + var_maxphase_R) AS 'Residui Attivi Riscossi',
		(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Attivi da riscuotere',
		(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale Residui Attivi',
		var_finphase_acc_R AS 'Var. aumento residui attivi',
		- var_finphase_red_R AS 'Var. diminuzione residui attivi' ,
		(var_finphase_acc_R + var_finphase_red_R) AS 'Totale Variazioni Residui Attivi',
		(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R  - mov_maxphase_R - var_maxphase_R) AS 'Tot. res. attivi a fine esercizio'
	FROM #balance
	LEFT OUTER JOIN fin
		ON fin.idfin = #balance.idfin
	ORDER BY #balance.codefin ASC
END
	IF (@finpart = 'S')
	BEGIN
		SELECT
			fin.codefin AS 'Codice Bilancio',
			fin.title AS 'Denominazione',
			initialprevision AS 'Prev. di competenza iniziale', 
			var_prev_M_acc  AS 'Var. aumento prev. competenza',
			- var_prev_M_red  AS 'Var. dimin. prev. competenza',
			(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. competenza definitiva',
			(mov_maxphase_C + var_maxphase_C) AS 'Somme impegnate pagate',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C) AS 'Somme impegnate da pagare',
			(mov_finphase_C + var_finphase_C) AS 'Totale somme impegnate',
			(initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C-var_finphase_C) AS 'Differenza rispetto alle previsioni',
			mov_finphase_R AS 'Residui passivi iniziali' ,
			(mov_maxphase_R + var_maxphase_R) AS 'Residui passivi riscossi',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Passivi da riscuotere',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale residui passivi',
			var_finphase_acc_R  AS 'Var. residui passivi in aumento',
			-var_finphase_red_R  AS 'Var. residui passivi in diminuzione',
			(var_finphase_acc_R + var_finphase_red_R) AS 'Totale variazioni residui passivi',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Tot. res. passivi a fine esercizio'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
END 
-- Cassa Pura
IF @fin_kind = 2
BEGIN 
	IF @finpart = 'E'
	BEGIN 
		IF @infoadvance <> 'N'
		BEGIN
			IF @ff_jan01 > 0
			BEGIN
				SET @supposed_cash_jan01 =@supposed_ff_jan01
				SET @cash_jan01 =@ff_jan01
				IF (@ff_jan01 - @supposed_ff_jan01) >0 
					BEGIN
					SET @var_ff_acc = (@ff_jan01 - @supposed_ff_jan01)
					SET @var_ff_red = 0
	      		 	END
				ELSE
				BEGIN
					SET @var_ff_acc = 0
					SET @var_ff_red = (@ff_jan01 - @supposed_ff_jan01)
				END
			END
			ELSE
			BEGIN
			  	SET @supposed_cash_jan01 =0
				SET @cash_jan01 =0
			  	SET @var_ff_acc =0
	  		 	SET @var_ff_red =0
			END
			INSERT INTO #balance
			(
				idfin, codefin, description,
				initialprevision, var_prev_M_acc, var_prev_M_red, mov_maxphase_C) -- Fondo cassa effettivo nella colonna  Totale Riscossioni  
			VALUES
			(
				@idavanzocassa , ' ', 'Avanzo di Cassa',
				@supposed_cash_jan01, @var_ff_acc, @var_ff_red, @cash_jan01
			)
		END
		SELECT  
			CASE
				WHEN #balance.idfin = @idavanzocassa
				THEN #balance.codefin
				ELSE fin.codefin
			END AS 'Codice Bilancio',
			CASE
				WHEN #balance.idfin = @idavanzocassa
				THEN #balance.description
				ELSE fin.title
			END AS 'Denominazione',
			initialprevision AS 'Prev. di cassa iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. cassa',
			-var_prev_M_red AS 'Var. dimin. prev. cassa',
			(initialprevision + var_prev_M_acc + var_prev_M_red) AS 'Prev. cassa definitiva',
			(mov_finphase_C + var_finphase_C) AS 'Totale Somme Accertate',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN mov_maxphase_C
				ELSE (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Totale Riscossioni',
			CASE #balance.idfin 
				WHEN @idavanzocassa   THEN NULL
				ELSE (initialprevision + var_prev_M_acc + var_prev_M_red) -  (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Differenza rispetto alle previsioni'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
	IF (@finpart = 'S')
	BEGIN
		SELECT
			fin.codefin AS 'Codice Bilancio',
			fin.title AS 'Denominazione',
			initialprevision AS 'Prev. di cassa iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. cassa',
			-var_prev_M_red AS 'Var. dimin. prev. cassa',
			(initialprevision + var_prev_M_acc + var_prev_M_red) AS 'Prev. cassa definitiva',
			(mov_finphase_C + var_finphase_C) AS 'Totale Somme Impegnate',
			(mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Totale Pagamenti',
			(initialprevision + var_prev_M_acc + var_prev_M_red) - (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Differ. rispetto alle previsioni'	 
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
END
-- Compentenza e Cassa
IF (@fin_kind = 3)
BEGIN 
	IF (@finpart = 'E')
	BEGIN
		IF @infoadvance <> 'N'
		BEGIN
			IF (@aa_jan01 > 0)
			BEGIN
				SET @supposed_amm_jan01 =@supposed_aa_jan01
				IF (@aa_jan01 - @supposed_aa_jan01) >0 
				BEGIN
					SET @var_aa_acc = (@aa_jan01 - @supposed_aa_jan01)
					SET @var_aa_red = 0
				END
				ELSE
				BEGIN
					SET @var_aa_acc = 0
					SET @var_aa_red = (@aa_jan01 - @supposed_aa_jan01)
				END
			END
			ELSE
			BEGIN
				SET @supposed_amm_jan01 = 0
				SET @var_aa_acc = 0
				SET @var_aa_red = 0
			END
			INSERT INTO #balance
			(
				idfin, codefin, description,
				initialprevision, var_prev_M_acc, var_prev_M_red
			)
			VALUES
			(
				@idavanzoamm , ' ', 'Avanzo di Amministrazione',   ---avanzo amministrazione 0
				@supposed_amm_jan01, @var_aa_acc, @var_aa_red
			)
			IF (@ff_jan01 > 0)
			BEGIN
				SET @supposed_cash_jan01 =@supposed_ff_jan01
				SET @cash_jan01 =@ff_jan01
				IF (@ff_jan01 - @supposed_ff_jan01) >0 
				BEGIN
					SET @var_ff_acc = (@ff_jan01 - @supposed_ff_jan01)
					SET @var_ff_red = 0
				END
				ELSE
				BEGIN
					SET @var_ff_acc = 0
					SET @var_ff_red = (@ff_jan01 - @supposed_ff_jan01)
				END
			END
			ELSE
			BEGIN
				SET @supposed_cash_jan01 = 0
				SET @cash_jan01 = 0
				SET @var_ff_acc = 0
				SET @var_ff_red = 0
			END
			INSERT INTO #balance
			(
				idfin, codefin, description,
				secondaryprev, var_prev_S_acc, var_prev_S_red, mov_maxphase_C
			) --Fondo cassa effettivo nella colonna  Totale Riscossioni
			VALUES
			(
				@idavanzocassa  , ' ', 'Avanzo di Cassa',  ---Avanzo di cassa null
				@supposed_cash_jan01, @var_ff_acc, @var_ff_red, @cash_jan01
			)
		END
		SELECT
			CASE
				WHEN #balance.idfin = @idavanzoamm  THEN #balance.codefin
				WHEN #balance.idfin = @idavanzocassa   THEN #balance.codefin
				ELSE fin.codefin
			END AS 'Codice Bilancio',
			CASE
				WHEN #balance.idfin = @idavanzoamm  THEN #balance.description
				WHEN #balance.idfin = @idavanzocassa   THEN #balance.description
				ELSE fin.title
			END AS 'Denominazione',
			initialprevision AS 'Prev. competenza iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. competenza',
			-var_prev_M_red AS 'Var. dimin. prev. competenza',
			(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. competenza definitiva',
			CASE #balance.idfin
				WHEN @idavanzocassa  THEN NULL
				ELSE (mov_maxphase_C+var_maxphase_C)
			END AS 'Accertamenti riscossi',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN NULL
				ELSE (mov_finphase_C+var_finphase_C - mov_maxphase_C - var_maxphase_C)
			END AS 'Accertamenti da riscuotere',
			(mov_finphase_C + var_finphase_C) AS 'Totale somme accertate',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN NULL
				ELSE (initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C-var_finphase_C)
			END AS 'Differenza rispetto alle previsioni (comp.)',
			secondaryprev AS 'Prev. cassa iniziale', 
			var_prev_S_acc AS 'Var. aumento prev. cassa',
			-var_prev_S_red AS 'Var. dimin. prev. cassa',
			(secondaryprev + var_prev_S_acc + var_prev_S_red) AS 'Prev. cassa definitiva' ,
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN mov_maxphase_C
				ELSE (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Totale Riscossioni',
			CASE #balance.idfin
				WHEN @idavanzocassa   THEN NULL
				ELSE (secondaryprev + var_prev_S_acc + var_prev_S_red)- (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R)
			END AS 'Differenza rispetto alle previsioni (cassa)',
			mov_finphase_R AS 'Residui Attivi Iniziali' ,
			(mov_maxphase_R + var_maxphase_R) AS 'Residui Attivi Riscossi',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Attivi da riscuotere',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale Residui Attivi',
			var_finphase_acc_R  AS 'Var. residui attivi in aumento',
			-var_finphase_red_R  AS 'Var. residui attivi in diminuzione',
			(var_finphase_acc_R + var_finphase_red_R) AS 'Totale Variazioni Residui Attivi',
			CASE #balance.idfin
				WHEN @idavanzocassa  THEN NULL
				ELSE (mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R)
			END AS 'Tot. res. attivi a fine esercizio'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
	IF(@finpart = 'S')
	BEGIN
		SELECT
			fin.codefin AS 'Codice Bilancio',
			fin.title AS 'Denominazione',
			initialprevision AS 'Prev. competenza iniziale', 
			var_prev_M_acc AS 'Var. aumento prev. competenza',
			-var_prev_M_red AS 'Var. dimin. prev. competenza',
			(initialprevision + var_prev_M_acc + var_prev_M_red)  AS 'Prev. competenza definitiva',
			(mov_maxphase_C + var_maxphase_C) AS 'Somme impegnate pagate',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C) AS 'Somme impegnate da pagare',
			(mov_finphase_C + var_finphase_C) AS 'Totale somme impegnate',
			(initialprevision + var_prev_M_acc + var_prev_M_red - mov_finphase_C-var_finphase_C) AS 'Differenza rispetto alle previsioni (comp.)',	 
			secondaryprev AS 'Prev. cassa iniziale', 
			var_prev_S_acc AS 'Var. aumento prev. cassa',
			-var_prev_S_red AS 'Var. dimin. prev. cassa',
			(secondaryprev + var_prev_S_acc + var_prev_S_red)  AS 'Prev. cassa definitiva',
			(mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Totale Pagamenti',
			(secondaryprev + var_prev_S_acc + var_prev_S_red)- (mov_maxphase_C + var_maxphase_C + mov_maxphase_R + var_maxphase_R) AS 'Differenza rispetto alle previsioni (cassa)',   	
			mov_finphase_R AS 'Residui Passivi Iniziali' ,
			(mov_maxphase_R + var_maxphase_R) AS 'Residui Passivi Pagati',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Residui Passivi da pagare',
			(mov_finphase_R + var_finphase_acc_R + var_finphase_red_R) AS 'Totale Residui Passivi',
			var_finphase_acc_R AS 'Var. residui passivi in aumento',
			-var_finphase_red_R AS 'Var. residui passivi in diminuzione',
			(var_finphase_acc_R + var_finphase_red_R) AS 'Totale Variazioni Residui Passivi',
			(mov_finphase_C + var_finphase_C - mov_maxphase_C - var_maxphase_C + mov_finphase_R + var_finphase_acc_R + var_finphase_red_R - mov_maxphase_R - var_maxphase_R) AS 'Tot. res. passivi a fine esercizio'
		FROM #balance
		LEFT OUTER JOIN fin
			ON fin.idfin = #balance.idfin
		ORDER BY #balance.codefin ASC
	END
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_cracked_fin.sql

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cracked_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cracked_fin]
GO

CREATE PROCEDURE exp_cracked_fin
(
	@ayear int,
	@finpart char(1)
)
AS BEGIN
DECLARE @fasebil tinyint
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind FROM config WHERE ayear = @ayear

IF (@finpart = 'S')
BEGIN
	SELECT @fasebil = expensefinphase FROM uniconfig

	SELECT
	--	FY.idfin, FY.idupb, 
		'Spesa' AS 'Parte Bil.',
		U.codeupb AS 'Cod. U.P.B.',
		U.title AS 'U.P.B.',
		F.codefin AS 'Cod. Bilancio',
		F.title AS 'Bilancio',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) AS 'Previsione Corrente', 
		ISNULL(UET.totalcompetency,0) +
		CASE
			WHEN @fin_kind in (1,3) THEN 0
			ELSE ISNULL(UET.totalarrears, 0)
		END AS 'Tot. Impegnato',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) - ISNULL(UET.totalcompetency,0) 
		-
		CASE
			WHEN @fin_kind in (1,3) THEN 0
			ELSE ISNULL(UET.totalarrears, 0)
		END AS 'Previsione Disponibile'
	FROM finyear FY
	JOIN finlast FL 
		ON FL.idfin = FY.idfin 
	LEFT OUTER JOIN upbtotal UT 
		ON UT.idfin = FY.idfin
		AND UT.idupb = FY.idupb
	LEFT OUTER JOIN upbexpensetotal UET 
		ON UET.idfin = FY.idfin
		AND UET.idupb = FY.idupb
		AND UET.nphase = @fasebil
	JOIN fin F
		ON F.idfin = FY.idfin 
	JOIN upb U
		ON U.idupb = FY.idupb
	WHERE (ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) 
	- ISNULL(UET.totalcompetency,0) )  - 
	CASE
		WHEN @fin_kind in (1,3) THEN 0
		ELSE ISNULL(UET.totalarrears, 0)
	END
	< 0
	AND FY.ayear = @ayear
	AND (F.flag & 1) <> 0
END
ELSE -- @finpart = 'E'
BEGIN 
	SELECT @fasebil = incomefinphase FROM uniconfig

	SELECT
	--	FY.idfin, FY.idupb, 
		'Entrata' AS 'Parte Bil.',
		U.codeupb AS 'Cod. U.P.B.',
		U.title AS 'U.P.B.',
		F.codefin AS 'Cod. Bilancio',
		F.title AS 'Bilancio',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) AS 'Previsione Corrente', 
		ISNULL(UIT.totalcompetency,0) + 
		CASE
			WHEN @fin_kind in (1,3) THEN 0
			ELSE ISNULL(UIT.totalarrears, 0)
		END AS 'Tot. Accertato',
		ISNULL(UT.currentprev,0) + ISNULL(UT.previsionvariation,0) - ISNULL(UIT.totalcompetency,0) -
		CASE
			WHEN @fin_kind  in (1,3) THEN 0
			ELSE ISNULL(UIT.totalarrears, 0)
		END AS 'Previsione Disponibile'
	FROM finyear FY 
	JOIN finlast FL 
		ON FL.idfin = FY.idfin 
	LEFT OUTER JOIN upbtotal UT 
		ON UT.idfin = FY.idfin
		AND UT.idupb = FY.idupb
	LEFT OUTER JOIN upbincometotal UIT 
		ON UIT.idfin = FY.idfin
		AND UIT.idupb = FY.idupb
		AND UIT.nphase = @fasebil
	JOIN fin F
		ON F.idfin = FY.idfin 
	JOIN upb U
		ON U.idupb = FY.idupb
	WHERE (ISNULL(UT.currentprev,0)+ISNULL(UT.previsionvariation,0) 
	- ISNULL(UIT.totalcompetency,0) ) -
	CASE
		WHEN @fin_kind  in (1,3) THEN 0
		ELSE ISNULL(UIT.totalarrears, 0)
	END < 0
	AND FY.ayear = @ayear
	AND (F.flag & 1) = 0
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_credit_surplus.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_credit_surplus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_credit_surplus]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



--	Calcolo ripartizione avanzo di amministrazione
CREATE  PROCEDURE [exp_credit_surplus]
	@ayear int,
	@adate	smalldatetime,
	@levelusable tinyint,
	@showupb char(1),
	@idupb varchar(36),
	@showchildupb char(1),
	@suppressifblank char(1)
AS
BEGIN

/* Versione 1.0.1 del 05/11/2007 ultima modifica: SARA */

SET @showupb = upper(@showupb)
SET @showchildupb = upper(@showchildupb)
SET @suppressifblank = upper (@suppressifblank)

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END
		
/*DECLARE @idfinincomesurplus int -- Flag indicante se l'avanzo di amministrazione è attribuito in previsione ad un capitolo di entrata o no 
SELECT @idfinincomesurplus = isnull(idfinincomesurplus,0) 
	FROM config
	WHERE ayear = @ayear
*/
CREATE TABLE #credit_surplus
(
	idfin int,
	codefin varchar(50),
	fin varchar(200),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),

	prevision decimal(19,2),
	var_prevision_A decimal(19,2),
	var_prevision_D decimal(19,2),

	secondaryprev decimal(19,2),
	var_secondaryprev_A decimal(19,2),
	var_secondaryprev_D decimal(19,2),

	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),

	mov_maxphase_C	decimal(19,2),
	var_maxphase_C decimal(19,2),

	mov_finphase_R decimal(19,2),
	var_finphase_R decimal(19,2),

	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),

	creditpart decimal(19,2),
	creditvariation decimal(19,2),

	proceedspart decimal(19,2),
	proceedsvariation decimal(19,2),

	proceeds_maxphase_C decimal(19,2),
	proceeds_maxphase_R decimal(19,2)
)

/*
DECLARE @lengthidfinop int
SET @lengthidfinop = (CONVERT(int,@levelusable) * 4 + 3 )
*/

DECLARE @data varchar(13)
SET @data = CONVERT(varchar(10),@adate,5)

DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM reportadditionalparam
WHERE reportname = 'consentr' AND paramname = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
-- ricerca la fase equivalente all'impegno
-- se è stata inserita nella tabella di configurazione
-- del bilancio

DECLARE @finphase tinyint
SELECT  @finphase = appropriationphasecode
FROM 	config
WHERE 	ayear = @ayear

-- Se non è stata inserita nella tabella di configurazione ipotizza che si tratti della fase dove viene identificata
-- la voce di bilancio
IF @finphase IS NULL
BEGIN
	SELECT @finphase = expensefinphase
	FROM uniconfig
END

-- La fase di cassa è sempre l'ultima fase della procedura  di spesa
DECLARE @maxexpensephase tinyint
SELECT 	@maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @maxincomephase  tinyint
SELECT 	@maxincomephase = MAX(nphase) FROM incomephase

-- Se @cassa_competenza = 'C' ==> è stata personalizzata una  previsione principale di tipo "competenza", se @cassa_competenza = 'S'
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @cassa_competenza = 'A' ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 
DECLARE @fin_kind tinyint
SELECT  @fin_kind = fin_kind  FROM config WHERE ayear = @ayear

DECLARE @lencod_lev1 int
SELECT  @lencod_lev1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1

DECLARE @startpos1 int
SET @startpos1 = 1

DECLARE @startpos2 int
SET @startpos2 = @startpos1 + @lencod_lev1

DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2

DECLARE @startpos3 int
SET @startpos3 = @startpos2 + @lencod_lev2

DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3

DECLARE @startpos4 int
SET @startpos4 = @startpos3 + @lencod_lev3

DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag /256  FROM finlevel  WHERE ayear = @ayear AND nlevel = 4
	

INSERT INTO #credit_surplus
	(
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	--flagincomesurplus,
	prevision,
	secondaryprev,
	currentarrears
	)
SELECT  f.idfin, 
	f.codefin, 
	f.title,
	upb.idupb,
	upb.codeupb,
	upb.title,
	ISNULL(finyear.prevision,0), 
	ISNULL(finyear.secondaryprev,0) ,
	ISNULL(finyear.currentarrears,0)
FROM fin f
CROSS JOIN upb 
JOIN finlevel fl
	ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
LEFT OUTER JOIN finyear
	ON finyear.idfin = f.idfin
	AND finyear.idupb = upb.idupb
WHERE f.ayear = @ayear
	AND (upb.idupb LIKE @idupb)	
	AND ((f.flag & 1)= 1)--AND f.finpart = 'S'
	AND (f.nlevel = @levelusable
		OR (f.nlevel < @levelusable
		AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
			AND (fl.flag&2)<>0
			)	
		)
	--AND (@infoadvance = 'N' OR @infoadvance = 'B' OR f.idfin <> @idfinincomesurplus )
UPDATE #credit_surplus
SET  	creditpart = (SELECT ISNULL(SUM(totcreditpart),0)
	FROM upbtotal UT	
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
	WHERE UT.idupb = #credit_surplus.idupb
		AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin
		
	),
	proceedspart	 = (SELECT ISNULL(SUM(totproceedspart),0)  
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin
		)

DECLARE @minoplevel tinyint
SELECT  @minoplevel = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND (flag&2) <> 0


IF @levelusable > @minoplevel
BEGIN 
-- articolo 4>3
UPDATE #credit_surplus
SET  		
	creditvariation = (SELECT ISNULL(SUM(creditvariation),0) 
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin
		),
	proceedsvariation =
		(SELECT ISNULL(SUM(proceedsvariation),0) 
		FROM upbtotal UT	
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND ISNULL(FLK.idparent,UT.idfin) = #credit_surplus.idfin 
		)
END
ELSE 
BEGIN 
-- capitolo
UPDATE #credit_surplus
SET  		
	creditvariation = (SELECT ISNULL(SUM(creditvariation),0) 
		FROM upbtotal UT	
		JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND FLK.idchild = #credit_surplus.idfin
		),
	proceedsvariation =
		(SELECT ISNULL(SUM(proceedsvariation),0) 
		FROM upbtotal UT	
		JOIN finlink FLK
			ON FLK.idchild = UT.idfin AND FLK.nlevel = @levelusable
		WHERE UT.idupb = #credit_surplus.idupb
			AND FLK.idchild = #credit_surplus.idfin 
		)
END

-- calcolo del totale delle variazioni della  previsione principale
CREATE TABLE #var_prevision_A(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_prevision_A
(
idupb,
idfin,
totale
)
SELECT FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	SUM(ISNULL(FVD.amount, 0)) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagprevision = 'S'
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear--AND SUBSTRING(FVD.idfin, 3, 1) = 'S'
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

CREATE TABLE #var_prevision_D(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_prevision_D
(
idupb,
idfin,
totale
)
SELECT	FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	-(SUM(ISNULL(FVD.amount, 0))) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagprevision = 'S'
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

-- calcolo del totale delle variazioni della  previsione secondaria
CREATE TABLE #var_secondaryprev_A(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_secondaryprev_A
(
idupb,
idfin,
totale
)
SELECT
	FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	ABS(SUM(ISNULL(FVD.amount, 0))) 
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagsecondaryprev = 'S'
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)

-- calcolo del totale delle variazioni della  previsione secondaria
CREATE TABLE #var_secondaryprev_D(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_secondaryprev_D
(
	idupb,
	idfin,
	totale
)
SELECT
	FVD.idupb,
	ISNULL(FLK.idparent,FVD.idfin),
	ABS(SUM(ISNULL(FVD.amount, 0)))
FROM finvardetail FVD
JOIN finvar FV 
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @adate
	AND FV.flagsecondaryprev = 'S'
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = 1) AND F.ayear = @ayear
	AND (FVD.idupb like @idupb )
GROUP BY FVD.idupb,ISNULL(FLK.idparent,FVD.idfin)
	
CREATE TABLE #mov_finphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_finphase_C
(
	idupb,
	idfin,
	totale
)
SELECT	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EY.amount, 0))
FROM expense E
JOIN expenseyear EY 
	ON EY.idexp = E.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE E.adate <= @adate
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0) -- 'C'
	AND E.nphase = @finphase
	AND (EY.idupb like @idupb )
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #var_finphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_finphase_C
(
	idupb,
	idfin,
	totale
)
SELECT 
	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EV.amount, 0))
FROM expensevar EV
JOIN expense E
	ON EV.idexp = E.idexp
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EV.adate <= @adate 
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 0) -- 'C'
	AND E.nphase = @finphase
	AND (EY.idupb like @idupb )
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #mov_finphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_finphase_R
(
	idupb,
	idfin,
	totale
)
SELECT
	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EY.amount, 0))
FROM expenseyear EY
JOIN expense E
	ON E.idexp = EY.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EY.ayear = @ayear
	AND ( (ET.flag & 1) = 1) -- 'R'
	AND E.nphase = @finphase
	AND E.adate <= @adate
	AND (EY.idupb like @idupb )
GROUP BY  EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #var_finphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #var_finphase_R
(
	idupb,
	idfin,
	totale
)
SELECT 
	EY.idupb,
	ISNULL(FLK.idparent,EY.idfin),
	SUM(ISNULL(EV.amount, 0))
FROM expensevar EV
JOIN expense E
	ON EV.idexp = E.idexp
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EV.adate <= @adate 
	AND EY.ayear = @ayear
	AND ( (ET.flag & 1) = 1) -- 'R'
	AND E.nphase = @finphase
	AND (EY.idupb like @idupb )
GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

CREATE TABLE #proceeds_maxphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #proceeds_maxphase_C
(
	idupb,
	idfin,
	totale
)
SELECT 
	IY.idupb,
	ISNULL(FLK.idparent,PP.idfin),--SUBSTRING(PP.idfin, 1, @lengthidfinop),
	SUM(ISNULL(PP.amount, 0))
FROM proceedspart PP 
JOIN incomeyear IY 
	ON IY .idinc = PP.idinc
JOIN incometotal IT
	ON IT.idinc = IY.idinc
	AND IT.ayear = IY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = PP.idfin AND FLK.nlevel = @levelusable
WHERE PP.yproceedspart = @ayear
	AND PP.adate <= @adate 
	AND IY.ayear = @ayear
	AND ( (IT.flag & 1) = 0)-- 'C'
	-- AND IY.nphase = @maxincomephase
	AND (IY.idupb like @idupb )
GROUP BY IY.idupb,ISNULL(FLK.idparent,PP.idfin)

CREATE TABLE #proceeds_maxphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #proceeds_maxphase_R
(
	idupb,
	idfin,
	totale
)
SELECT 
	IY.idupb,
	ISNULL(FLK.idparent,PP.idfin),--SUBSTRING(PP.idfin, 1, @lengthidfinop),
	SUM(ISNULL(PP.amount, 0))
FROM proceedspart PP 
JOIN incomeyear IY 
	ON IY .idinc = PP.idinc
JOIN incometotal IT
	ON IT.idinc = IY.idinc
	AND IT.ayear = IY.ayear
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = PP.idfin AND FLK.nlevel = @levelusable
WHERE PP.yproceedspart = @ayear
	AND PP.adate <= @adate 
	AND IY.ayear = @ayear
	AND ( (IT.flag & 1) = 1)-- 'R'
	-- AND IY.nphase = @maxincomephase
	AND (IY.idupb like @idupb )
GROUP BY IY.idupb,ISNULL(FLK.idparent,PP.idfin)

CREATE TABLE #mov_maxphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_maxphase_C
(
	idupb,
	idfin,
	totale
)
SELECT
	HPV.idupb,	
	ISNULL(FLK.idparent,HPV.idfin),--SUBSTRING(EY.idfin, 1, @lengthidfinop),
	SUM(HPV.amount)
FROM historypaymentview HPV
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable	
WHERE HPV.competencydate <= @adate
	AND HPV.ymov = @ayear
	AND HPV.flagarrear = 'C'
GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

CREATE TABLE #mov_maxphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
INSERT INTO #mov_maxphase_R
	(
	idupb,
	idfin,
	totale
	)
SELECT
	HPV.idupb,	
	ISNULL(FLK.idparent,HPV.idfin),
	SUM(HPV.amount)
FROM historypaymentview HPV		
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable	
WHERE HPV.competencydate <= @adate
	AND HPV.ymov = @ayear
	AND HPV.flagarrear = 'R'
GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

IF (@cashvaliditykind <> 4)
BEGIN
	CREATE TABLE #var_maxphase_C(idupb varchar(36),idfin int,totale decimal(19,2))
	INSERT INTO #var_maxphase_C
		(
		idupb,
		idfin,
		totale
		)
	SELECT 	HPV.idupb,
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(ISNULL(EV.amount, 0))
	FROM expensevar EV 
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @adate
		AND ( (HPV.totflag & 1) = 0)--'C'
		AND HPV.competencydate <= @adate
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

	CREATE TABLE #var_maxphase_R(idupb varchar(36),idfin int,totale decimal(19,2))
	INSERT INTO #var_maxphase_R
	(
		idupb,
		idfin,
		totale
	)
	SELECT 	HPV.idupb,
		ISNULL(FLK.idparent,HPV.idfin),
		SUM(ISNULL(EV.amount, 0))
	FROM expensevar EV 
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE EV.yvar = @ayear
		AND EV.adate <= @adate
		AND ( (HPV.totflag & 1) = 1 )
		AND HPV.competencydate <= @adate
		AND HPV.ymov = @ayear
	GROUP BY HPV.idupb,ISNULL(FLK.idparent,HPV.idfin)

END


UPDATE #credit_surplus
SET 
	var_prevision_A = ISNULL((SELECT #var_prevision_A.totale FROM #var_prevision_A
				WHERE #var_prevision_A.idfin = #credit_surplus.idfin
				and #var_prevision_A.idupb = #credit_surplus.idupb), 0),

	var_prevision_D = ISNULL((SELECT #var_prevision_D.totale FROM #var_prevision_D
				WHERE #var_prevision_D.idfin = #credit_surplus.idfin 
				and #var_prevision_D.idupb = #credit_surplus.idupb), 0),

	var_secondaryprev_A = ISNULL((SELECT #var_secondaryprev_A.totale FROM #var_secondaryprev_A
				WHERE #var_secondaryprev_A.idfin = #credit_surplus.idfin
				and #var_secondaryprev_A.idupb = #credit_surplus.idupb), 0),

	var_secondaryprev_D = ISNULL((SELECT #var_secondaryprev_D.totale FROM #var_secondaryprev_D
				WHERE #var_secondaryprev_D.idfin = #credit_surplus.idfin 
				AND #var_secondaryprev_D.idupb = #credit_surplus.idupb), 0),

	mov_finphase_C = ISNULL((SELECT #mov_finphase_C.totale FROM #mov_finphase_C
				WHERE #mov_finphase_C.idfin = #credit_surplus.idfin
				and #mov_finphase_C.idupb = #credit_surplus.idupb),0),

	var_finphase_C = ISNULL((SELECT #var_finphase_C.totale FROM #var_finphase_C
				WHERE #var_finphase_C.idfin = #credit_surplus.idfin 
				and #var_finphase_C.idupb = #credit_surplus.idupb),0),

	mov_maxphase_C = ISNULL((SELECT #mov_maxphase_C.totale FROM #mov_maxphase_C
				WHERE #mov_maxphase_C.idfin = #credit_surplus.idfin
				and #mov_maxphase_C.idupb = #credit_surplus.idupb),0),

	var_maxphase_C = ISNULL((SELECT #var_maxphase_C.totale FROM #var_maxphase_C
				WHERE #var_maxphase_C.idfin = #credit_surplus.idfin
				and #var_maxphase_C.idupb = #credit_surplus.idupb),0),

	mov_finphase_R = ISNULL((SELECT #mov_finphase_R.totale FROM #mov_finphase_R
				WHERE #mov_finphase_R.idfin = #credit_surplus.idfin
				and  #mov_finphase_R.idupb = #credit_surplus.idupb),0),

	var_finphase_R = ISNULL((SELECT #var_finphase_R.totale FROM #var_finphase_R
				WHERE #var_finphase_R.idfin = #credit_surplus.idfin
				and #var_finphase_R.idupb = #credit_surplus.idupb),0),

	mov_maxphase_R = ISNULL((SELECT #mov_maxphase_R.totale FROM #mov_maxphase_R
				WHERE #mov_maxphase_R.idfin = #credit_surplus.idfin
				and #mov_maxphase_R.idupb = #credit_surplus.idupb),0),

	var_maxphase_R = ISNULL((SELECT #var_maxphase_R.totale FROM #var_maxphase_R
				WHERE #var_maxphase_R.idfin = #credit_surplus.idfin
				and #var_maxphase_R.idupb = #credit_surplus.idupb),0),

	proceeds_maxphase_R = ISNULL((SELECT #proceeds_maxphase_R.totale FROM #proceeds_maxphase_R
				WHERE #proceeds_maxphase_R.idfin = #credit_surplus.idfin
				and  #proceeds_maxphase_R.idupb = #credit_surplus.idupb),0),

	proceeds_maxphase_C = ISNULL((SELECT #proceeds_maxphase_C.totale FROM #proceeds_maxphase_C
				WHERE #proceeds_maxphase_C.idfin = #credit_surplus.idfin
				and #proceeds_maxphase_C.idupb = #credit_surplus.idupb), 0)

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
BEGIN
	UPDATE #credit_surplus
	SET upb =
		(SELECT TOP 1 upb
		FROM #credit_surplus
		WHERE idupb = @idupboriginal),
	idupb =	@idupboriginal,
	codeupb =
		(SELECT TOP 1 codeupb
		FROM #credit_surplus	
		WHERE idupb = @idupboriginal)
END
IF (@showupb <>'S') and (@idupboriginal = '%')
BEGIN
	UPDATE #credit_surplus
	SET upb =  NULL,
	idupb = NULL,
	codeupb = NULL
END

IF (@suppressifblank = 'S')
BEGIN
	DELETE FROM #credit_surplus 
	WHERE (ISNULL(prevision,0)= 0
		AND ISNULL(secondaryprev,0)= 0
		AND ISNULL(var_prevision_A,0)= 0
		AND ISNULL(var_prevision_D,0) = 0
		AND ISNULL(var_secondaryprev_A,0)= 0
		AND ISNULL(var_secondaryprev_D,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0
		AND ISNULL(var_finphase_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0
		AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(mov_finphase_R,0)= 0
		AND ISNULL(var_finphase_R,0)= 0
		AND ISNULL(mov_maxphase_R,0)= 0
		AND ISNULL(var_maxphase_R,0)= 0
		AND ISNULL(proceeds_maxphase_R,0)= 0
		AND ISNULL(proceeds_maxphase_C,0)= 0

		AND ISNULL(currentarrears,0)= 0
		AND ISNULL(creditpart,0)= 0 
		AND ISNULL(creditvariation,0)= 0 
		AND ISNULL(proceedspart,0)= 0 
		AND ISNULL(proceedsvariation,0)= 0
		)
END


IF (@showupb <>'S') 
BEGIN
SELECT 
	codeupb as 'codice UPB',
	upb as 'UPB',
	codefin as 'Codice Bilancio'  ,
	fin as 'Bilancio',
	SUM( (ISNULL(prevision,0) + ISNULL(var_prevision_A,0) - ISNULL(var_prevision_D,0))) as 'previsione totale competenza',
	SUM( (ISNULL(secondaryprev,0) + ISNULL(var_secondaryprev_A,0) - ISNULL(var_secondaryprev_D,0))) as 'previsione totale cassa',
	SUM( ISNULL(proceedsvariation,0)) as 'Cassa al 01/01 [1]',
	SUM( ISNULL(proceeds_maxphase_R,0) ) as 'Incassato in conto residui [2]',
	SUM( ISNULL(proceeds_maxphase_C,0) ) as 'Incassato in conto competenza [3]',
	SUM( (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) ) as 'pagamenti di competenza [4]',			
	SUM( (ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) ) as 'pagamenti residui [5]',
	SUM( ISNULL(proceedspart,0)	
	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)+ ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)
	) ) as 'Avanzo di cassa [AC]=(1+2+3-4-5)',
	SUM(ISNULL(creditvariation,0)) as 'Crediti riportati al 01/01 [6]',
	SUM(ISNULL(creditpart,0)) as 'Crediti accertati in corso d''anno  [7]',
	SUM(ISNULL(creditpart,0) + ISNULL(creditvariation,0) ) as 'Crediti totali [CT]=(6+7)',
	SUM(ISNULL(creditpart,0)  - ISNULL(proceeds_maxphase_C,0) ) as 'Residui Attivi dell''esercizio in corso [8]' ,
	SUM( ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) + ISNULL(var_finphase_R,0) 
	- ISNULL(proceedsvariation,0) - ISNULL(proceeds_maxphase_R,0) ) as 'Residui Attivi degli esercizi precedenti [9]',
--			'Residui Attivi [Ra]' = ISNULL(creditpart,0) + ISNULL(creditvariation,0) + ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) - ISNULL(proceedspart,0) - ISNULL(proceedsvariation,0)  ,
	SUM( (ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) ) as 'impegni di competenza [10]',
	SUM( (ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) ) as 'impegni residui [11]',
	SUM( ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0) - ( ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) )as 'Residui Passivi dell''esercizio in corso [Rpc]=()',
	SUM( ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0) -  ( ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) )
	as 'Residui Passivi [Rpr] degli esercizi precedenti',

--Avanzo di cassa
	SUM( ISNULL(proceedspart,0)	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)+ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
-- Residui Attivi	
	+ ISNULL(creditpart,0) + ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) 
	- ISNULL(proceeds_maxphase_R,0) - ISNULL(proceeds_maxphase_C,0)-- - ISNULL(proceedspart,0) 
	- ISNULL(proceedsvariation,0) 
-- Residui Passivi 
	- (ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) 
	+ (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) 
	- (ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) 
	+ (ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
	)
AS 'Avanzo di amministrazione (AC+Ra-Rp))'
FROM #credit_surplus
GROUP BY codeupb,upb,codefin,fin
ORDER BY codeupb,codefin ASC

END

ELSE

BEGIN
SELECT 
	codeupb as 'codice UPB',
	upb as 'UPB',
	codefin as 'Codice Bilancio'  ,
	fin as 'Bilancio',
	(  ISNULL(prevision,0) + ISNULL(var_prevision_A,0) - ISNULL(var_prevision_D,0)) as 'previsione totale competenza',
	(  ISNULL(secondaryprev,0) + ISNULL(var_secondaryprev_A,0) - ISNULL(var_secondaryprev_D,0)) as 'previsione totale cassa',
	ISNULL(proceedsvariation,0) as 'Cassa al 01/01 [1]',
	 proceeds_maxphase_R as 'Incassato in conto residui [2]',
	proceeds_maxphase_C as 'Incassato in conto competenza [3]',
	 ( ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) as 'pagamenti di competenza [4]',			
	 ( ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) as 'pagamenti residui [5]',
	ISNULL(proceedspart,0)	
	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)+ ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)
	) as 'Avanzo di cassa [AC]=(1+2+3-4-5)',
	 ISNULL(creditvariation,0) as 'Crediti riportati al 01/01 [6]',
	ISNULL(creditpart,0) as 'Crediti accertati in corso d''anno  [7]',
	ISNULL(creditpart,0) + ISNULL(creditvariation,0) as 'Crediti totali [CT]=(6+7)',
	ISNULL(creditpart,0)  - ISNULL(proceeds_maxphase_C,0)   as 'Residui Attivi dell''esercizio in corso [8]' ,
	ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) + ISNULL(var_finphase_R,0) 
	- ISNULL(proceedsvariation,0) - ISNULL(proceeds_maxphase_R,0)  as 'Residui Attivi degli esercizi precedenti [9]',
--			'Residui Attivi [Ra]' = ISNULL(creditpart,0) + ISNULL(creditvariation,0) + ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) - ISNULL(proceedspart,0) - ISNULL(proceedsvariation,0)  ,
	( ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) as 'impegni di competenza [10]',
	(ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) as 'impegni residui [11]',
	ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0) - ( ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0) ) as 'Residui Passivi dell''esercizio in corso [Rpc]=()',
	ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0) -  ( ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0) ) 
	as 'Residui Passivi [Rpr] degli esercizi precedenti',

--Avanzo di cassa
	ISNULL(proceedspart,0)	+ ISNULL(proceedsvariation,0) 
	- (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)
	+ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
-- Residui Attivi
	+ ISNULL(creditpart,0) + ISNULL(creditvariation,0) 
	+ ISNULL(mov_finphase_R,0) +ISNULL(var_finphase_R,0) 
	- ISNULL(proceeds_maxphase_R,0) - ISNULL(proceeds_maxphase_C,0)-- - ISNULL(proceedspart,0) 
	- ISNULL(proceedsvariation,0) 
-- Residui Passivi 
	- (ISNULL(mov_finphase_C,0)+ISNULL(var_finphase_C,0)) 
	+ (ISNULL(mov_maxphase_C,0)+ISNULL(var_maxphase_C,0)) 
	- (ISNULL(mov_finphase_R,0)+ISNULL(var_finphase_R,0)) 
	+ (ISNULL(mov_maxphase_R,0)+ISNULL(var_maxphase_R,0)) 
AS 'Avanzo di amministrazione (AC+Ra-Rp))'

FROM #credit_surplus
ORDER BY codeupb,codefin ASC
END


 END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_currentfloatfund.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_currentfloatfund]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_currentfloatfund]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exp_currentfloatfund 2007

CREATE    PROCEDURE [exp_currentfloatfund]
(
	@ayear int = NULL
)
AS BEGIN

DECLARE @startfloatfund decimal(19,2)
DECLARE @proceedstransmission decimal(19,2)
DECLARE @payment decimal(19,2)
DECLARE @fin_kind tinyint
DECLARE @idfinincomesurplus int

DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase

CREATE TABLE #currentfloatfund(description varchar(100), import decimal(19,2))


IF (@ayear IS NOT NULL)
BEGIN
	SELECT @fin_kind = fin_kind
	FROM config
	WHERE ayear = @ayear

	SELECT @idfinincomesurplus = idfinincomesurplus FROM config WHERE ayear = @ayear
	IF (@idfinincomesurplus IS NOT NULL AND @idfinincomesurplus <> '')
	BEGIN
		IF (@fin_kind = 3)
		BEGIN
			SELECT @startfloatfund = ISNULL(SUM(finyear.secondaryprev),0) --previsione
			FROM finyear
			WHERE finyear.idfin = @idfinincomesurplus

			SELECT @startfloatfund = 
			@startfloatfund +
			ISNULL(
				(SELECT SUM(d.amount) 
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				WHERE v.flagsecondaryprev = 'S' AND d.idfin = @idfinincomesurplus)
			,0)
		END

		IF (@fin_kind = 2)
		BEGIN
			SELECT @startfloatfund = ISNULL(SUM(finyear.prevision),0)  --- previsione
			FROM finyear
			WHERE finyear.idfin = @idfinincomesurplus
	
			SELECT @startfloatfund = 
			@startfloatfund +
			ISNULL(
				(SELECT SUM(d.amount) 
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				WHERE v.flagprevision = 'S'  AND d.idfin = @idfinincomesurplus)
			,0)
		END
	END

	IF (SELECT COUNT(*) FROM fin WHERE ayear = @ayear AND idfin = @idfinincomesurplus) = 0
	OR (@fin_kind = 1)
	BEGIN
		SELECT @startfloatfund = 
			ISNULL(startfloatfund,0) +
			ISNULL(competencyproceeds,0) +
			ISNULL(residualproceeds,0) - 
			ISNULL(competencypayments,0) -
			ISNULL(residualpayments,0)
		FROM surplus WHERE ayear = (@ayear - 1)
	END
	
	INSERT INTO #currentfloatfund values
	('FONDO CASSA INIZIALE',@startfloatfund)

	
	SET @proceedstransmission =
		
		ISNULL(
			(SELECT SUM(ISNULL(i.curramount,0))
			FROM incometotal i 
			JOIN income e
				ON e.idinc=i.idinc
			JOIN incomelast IL
				ON IL.idinc = e.idinc
			JOIN proceeds p
				ON  p.kpro=IL.kpro
			JOIN proceedstransmission pt
				ON p.kproceedstransmission=pt.kproceedstransmission 
			WHERE i.ayear = @ayear)
		,0)


	INSERT INTO #currentfloatfund values
	('Reversali Trasmesse',@proceedstransmission)


	SET @payment = 
	ISNULL(
		(SELECT ISNULL(SUM(i.curramount), 0)
		FROM expense s
		JOIN expensetotal i
			ON s.idexp = i.idexp
			AND s.ymov = i.ayear
		JOIN expenselast EL
			ON EL.idexp = s.idexp
		WHERE i.ayear = @ayear)
	,0)
	--WHERE ayear = @ayear

	declare @ultima_fase varchar(50)
	select  @ultima_fase=description  from expensephase where nphase=(select max(nphase) from expensephase) 



	INSERT INTO #currentfloatfund values
	(@ultima_fase,@payment)
	
	INSERT INTO #currentfloatfund values
	('Residuo disponibile per ' +@ultima_fase+' (Regola MOVIM021)',@startfloatfund+@proceedstransmission-@payment)

	INSERT INTO #currentfloatfund values
	('',null)

	INSERT INTO #currentfloatfund values
	('Dettaglio Entrata:',null)

--- calcoli entrata

	INSERT INTO #currentfloatfund 
	select 'Reversali Trasmesse',sum(ET.curramount) from income E 
	JOIN incomelast EL 
		ON E.idinc=EL.idinc
	join incometotal ET 
		ON EL.idinc=ET.idinc 
	JOIN proceeds P	
		ON P.kpro=EL.kpro
	where 
	ET.ayear=@ayear
	AND EL.kpro is not null
	AND P.kproceedstransmission is not null

	INSERT INTO #currentfloatfund 
	SELECT 'Reversali non Trasmesse', sum(ET.curramount) from income E 
	JOIN incomelast EL 
		ON E.idinc=EL.idinc
	JOIN incometotal ET 
		ON EL.idinc=ET.idinc 
	JOIN proceeds P	
		ON P.kpro=EL.kpro
	where 
	ET.ayear=@ayear 
	AND EL.kpro is not null
	AND P.kproceedstransmission is null


	INSERT INTO #currentfloatfund 
	select 'Incassi non inseriri in reversali',sum(ET.curramount) from income E 
	JOIN incomelast EL 
		ON E.idinc=EL.idinc
	JOIN incometotal ET 
		ON EL.idinc=ET.idinc 
	AND NOT EXISTS (select * from proceeds P where P.kpro=EL.kpro)
	WHERE 
	ET.ayear=@ayear 

	INSERT INTO #currentfloatfund values
	('',null)

	INSERT INTO #currentfloatfund values
	('Dettaglio Spesa:',null)

	
--calcoli spesa

	INSERT INTO #currentfloatfund 
	select 'Mandati Trasmessi',sum(ET.curramount) from expense E 
	JOIN expenselast EL 
		ON E.idexp=EL.idexp
	join expensetotal ET 
		ON EL.idexp=ET.idexp 
	JOIN payment P	
		ON P.kpay=EL.kpay
	where 
	ET.ayear=@ayear 
	AND EL.kpay is not null
	AND P.kpaymenttransmission is not null

	INSERT INTO #currentfloatfund 
	SELECT 'Mandati non Trasmessi', sum(ET.curramount) from expense E 
	JOIN expenselast EL 
		ON E.idexp=EL.idexp
	JOIN expensetotal ET 
		ON EL.idexp=ET.idexp 
	JOIN payment P	
		ON P.kpay=EL.kpay
	where 
	ET.ayear=@ayear
	AND EL.kpay is not null
	AND P.kpaymenttransmission is null


	INSERT INTO #currentfloatfund 
	select @ultima_fase+' non inserite in mandati',sum(ET.curramount) from expense E 
	JOIN expenselast EL 
		ON E.idexp=EL.idexp
	JOIN expensetotal ET 
		ON EL.idexp=ET.idexp 
	AND NOT EXISTS (select * from payment P where P.kpay=EL.kpay)
	WHERE 
	ET.ayear=@ayear 


--impegnato da liquidare


	declare @expensephase int
	set @expensephase = (select expensephase from config where ayear=@ayear)

	
	INSERT INTO #currentfloatfund 
	SELECT 'Impegnato da Liquidare',sum(available) FROM expense E 
	JOIN expensetotal ET 
		ON E.idexp=ET.idexp
	WHERE e.nphase=@expensephase
	AND E.ymov=@ayear

END
ELSE 	
	INSERT INTO #currentfloatfund values
	('Inserire Esercizio',null)

	SELECT description as 'Descrizione', import as 'Importo' from  #currentfloatfund
END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_expensegerarchico.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_expensegerarchico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_expensegerarchico]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  PROCEDURE  exp_expensegerarchico (
	@ymin int,
	@ymax int,
	@registry varchar(100),
	@adatemin datetime,
	@adatemax datetime,
	@codefin varchar(50),
	@nphaseparent tinyint,
	@ymovparent  int,
	@nmovparent  int,
	@idupb varchar(36)
) 
as begin
-- exp_expensegerarchico '2007', '2007', '%', {ts '2007-01-01 00:00:00.000'}, {ts '2007-12-31 00:00:00.000'}, '%','%' ,1, 2007, 198
declare @idexp int
IF (@nphaseparent IS NULL OR @ymovparent IS NULL OR @nmovparent IS NULL)
	BEGIN
		SET @idexp = null	
	END
Else
	BEGIN
	   	SET @idexp = (select idexp 
				from expense 
				where ymov = @ymovparent 
				and nmov   = @nmovparent 
				and nphase = @nphaseparent) 
	END

declare @descrphase1 varchar(20)
declare @descrphase2 varchar(20)
declare @descrphase3 varchar(20)
declare @descrphase4 varchar(20)

select @descrphase1 = description from  expensephase where nphase = 1
select @descrphase2 = description from  expensephase where nphase = 2
select @descrphase3 = description from  expensephase where nphase = 3
select @descrphase4 = description from  expensephase where nphase = 4

SELECT  expense.idexp, 
	expenseyear.ayear, 
	expense.idreg, 
	expenseyear.idfin, 
	expenseyear.idupb
INTO #prova
	FROM expense
	join expenseyear 
		on expenseyear.idexp=expense.idexp 
		and (@ymin is null or expenseyear.ayear >= @ymin)
		and (@ymax is null or expenseyear.ayear <= @ymax)
	left outer join registry 
		on expense.idreg=registry.idreg and (@registry is null or registry.title like @registry)
	left outer join fin 
		on fin.idfin=expenseyear.idfin  and (@codefin is null or codefin like @codefin)
	left outer join upb 
		on upb.idupb = expenseyear.idupb  AND upb.idupb LIKE @idupb
	JOIN expenselink 
		ON expenselink.idchild = expense.idexp  
		AND expenselink.idparent = ISNULL(@idexp,expense.idexp) 

	WHERE (@adatemin is null or adate >= @adatemin) and (@adatemax is null or adate <= @adatemax)

declare @sqlcmd nvarchar(3000)

SET @sqlcmd= 
'	SELECT 	
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 1
			where elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase1+''','
if (@descrphase2 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 2
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase2+''','
if (@descrphase3 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 3
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase3+''','
if (@descrphase4 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),E1.ymov) + ''/'' + convert(varchar(6),E1.nmov))
		FROM  expense E1					 
			JOIN expenselink elk1
				ON elk1.idparent = E1.idexp AND elk1.nlevel = 4
			where  elk1.idchild = #prova.idexp
	) 		
	AS '''+@descrphase4+''','

SET @sqlcmd=@sqlcmd+'
	(convert(varchar(4),payment.ypay) + ''/'' + convert(varchar(6),payment.npay)) as Mandato,
	codefin as ''Codice bilancio'',
	fin.title as ''Voce di bilancio'',
	codeupb as ''Codice UPB'',
	upb.title as ''UPB'',
	registry.title as ''Beneficiario'',
	expense.description as ''Descrizione'',
	expensetotal.curramount as ''Importo corrente'',
	service.description as Prestazione,
	expenselast.servicestart as Inizio,
	expenselast.servicestop as Fine,
	(select sum(employtax) from expensetax where expensetax.idexp=#prova.idexp) as ''Importo ritenute associate'',
	(select sum(amount) from expenseclawback where expenseclawback.idexp=#prova.idexp) as ''Importo recuperi associati'',
	expensetotal.curramount
		-(select isnull(sum(employtax),0) from expensetax where expensetax.idexp=#prova.idexp)
		-(select isnull(sum(amount),0) from expenseclawback where expenseclawback.idexp=#prova.idexp) as ''Netto'',
	expense.adate as ''Data contabile''
FROM #prova
LEFT OUTER JOIN fin 
	on fin.idfin=#prova.idfin
LEFT OUTER JOIN upb 
	on upb.idupb=#prova.idupb
LEFT OUTER JOIN registry 
	on registry.idreg=#prova.idreg
LEFT OUTER JOIN expense 
	on expense.idexp=#prova.idexp
LEFT OUTER JOIN expenselast 
	on expenselast.idexp = #prova.idexp
LEFT OUTER JOIN payment 
	on payment.kpay = expenselast.kpay
LEFT OUTER JOIN service
	on service.idser = expenselast.idser  
LEFT OUTER JOIN expensetotal 
	ON expensetotal.idexp = #prova.idexp AND expensetotal.ayear = #prova.ayear 
order by 1,2,3,4

'
print @sqlcmd

EXECUTE sp_executesql  @sqlcmd

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO






--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_incomegerarchico.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_incomegerarchico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_incomegerarchico]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE  PROCEDURE  exp_incomegerarchico (
	@ymin int,
	@ymax int,
	@registry varchar(100),
	@adatemin datetime,
	@adatemax datetime,
	@codefin varchar(50),
	@nphaseparent tinyint,
	@ymovparent  int,
	@nmovparent  int,
	@idupb varchar(36)
) 
as begin

-- exp_incomegerarchico '2007', '2007', '%', {ts '2007-01-01 00:00:00.000'}, {ts '2007-12-31 00:00:00.000'}, '%','%' ,null, null, null

declare @idinc int
IF (@nphaseparent IS NULL OR @ymovparent IS NULL OR @nmovparent IS NULL)
	BEGIN
		SET @idinc = null	
	END
Else
	BEGIN
	   	SET @idinc = (select idinc 
				from income 
				where ymov = @ymovparent 
				and nmov   = @nmovparent 
				and nphase = @nphaseparent) 
	END


declare @descrphase1 varchar(20)
declare @descrphase2 varchar(20)
declare @descrphase3 varchar(20)
declare @descrphase4 varchar(20)

select @descrphase1 = description from  incomephase where nphase = 1
select @descrphase2 = description from  incomephase where nphase = 2
select @descrphase3 = description from  incomephase where nphase = 3
select @descrphase4 = description from  incomephase where nphase = 4

SELECT  income.idinc, 
	incomeyear.ayear, 
	income.idreg, 
	incomeyear.idfin, 
	incomeyear.idupb 
INTO #prova
	FROM income
	join incomeyear 
		on incomeyear.idinc=income.idinc 
		and (@ymin is null or incomeyear.ayear >= @ymin)
		and (@ymax is null or incomeyear.ayear <= @ymax)
	left outer join registry 
		on income.idreg=registry.idreg and (@registry is null or registry.title like @registry)
	left outer join fin 
		on fin.idfin=incomeyear.idfin  and (@codefin is null or codefin like @codefin)
	left outer join upb 
		on upb.idupb = incomeyear.idupb  AND upb.idupb LIKE @idupb
	JOIN incomelink 
		ON incomelink.idchild = income.idinc  
		AND incomelink.idparent = ISNULL(@idinc,income.idinc) 

	WHERE (@adatemin is null or adate >= @adatemin) and (@adatemax is null or adate <= @adatemax)

declare @sqlcmd nvarchar(3000)

SET @sqlcmd= 
'	SELECT 	
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(6),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 1
			where ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase1+''','
if (@descrphase2 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(6),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 2
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase2+''','
if (@descrphase3 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(6),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 3
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase3+''','
if (@descrphase4 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(6),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 4
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase4+''','

SET @sqlcmd=@sqlcmd+'
	(convert(varchar(4),proceeds.ypro) + ''/'' + convert(varchar(6),proceeds.npro)) as Reversale,
	codefin as ''Codice bilancio'',
	fin.title as ''Voce di bilancio'',
	codeupb as ''Codice UPB'',
	upb.title as ''UPB'',
	registry.title as ''Beneficiario'',
	income.description as ''Descrizione'',
	incometotal.curramount as ''Importo corrente'',
	income.adate as ''Data contabile''
FROM #prova
LEFT OUTER JOIN fin 
	on fin.idfin=#prova.idfin
LEFT OUTER JOIN upb 
	on upb.idupb=#prova.idupb
LEFT OUTER JOIN registry 
	on registry.idreg=#prova.idreg
LEFT OUTER JOIN income 
	on income.idinc=#prova.idinc
LEFT OUTER JOIN incomelast 
	on incomelast.idinc = #prova.idinc
LEFT OUTER JOIN proceeds 
	on incomelast.kpro = proceeds.kpro
LEFT OUTER JOIN incometotal 
	ON incometotal.idinc = #prova.idinc AND incometotal.ayear = #prova.ayear 
order by 1,2,3,4

'
print @sqlcmd

EXECUTE sp_executesql  @sqlcmd

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_listing_payment.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_listing_payment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_listing_payment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [exp_listing_payment]
(
	@ayear int,
	@unified varchar(1)
)
AS BEGIN

/* Versione 1.0.1 del 12/09/2007 ultima modifica: PINO */

CREATE TABLE #payment
(
	npay int,
	nmov int,
	kind varchar(20),
	adate datetime,
	printdate datetime,
	transmissiondate datetime,
	amount decimal(23,6),
	description varchar(150),
	codefin varchar(31),
	registry varchar(100)
)
IF @unified = 'N'
BEGIN
	INSERT INTO #payment
	(
		npay, adate, printdate, transmissiondate,
		kind, amount, codefin,
		description, registry, nmov
	)
	SELECT 
		P.npay, P.adate, P.printdate, PT.transmissiondate,
		CASE
			when (( ET.flag & 1)=0) then 'C'
			when (( ET.flag & 1)=1) then 'R'
		End,
		EY.amount,-- E.amount, 
		F.codefin,
		E.description, R.title, E.nmov
	FROM expenselast EL
	JOIN expense E
		ON E.idexp = EL.idexp
	JOIN expenseyear EY
		ON EY.idexp = EL.idexp
	JOIN expensetotal ET
		ON ET.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin 
	JOIN registry R
		ON R.idreg = E.idreg
	JOIN payment P
		ON EL.kpay = P.kpay
	LEFT OUTER JOIN paymenttransmission PT
		ON PT.kpaymenttransmission = P.kpaymenttransmission
	WHERE E.ymov = @ayear
END
ELSE
BEGIN
	INSERT INTO #payment
	(
		npay, adate, printdate, transmissiondate,
		kind, amount, codefin, registry
	)
	SELECT 
		P.npay, P.adate, P.printdate, PT.transmissiondate,
		case p.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		ISNULL(SUM(EY.amount),0),-- ISNULL(SUM(E.amount),0),
		F.codefin, R.title
	FROM expenselast EL
	JOIN expense E
		ON E.idexp = EL.idexp
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN registry R
		ON R.idreg = E.idreg
	JOIN expensetotal ET
		ON ET.idexp = E.idexp
	JOIN payment P
		ON EL.kpay = P.kpay
	LEFT OUTER JOIN paymenttransmission PT
		ON PT.kpaymenttransmission = P.kpaymenttransmission
	WHERE E.ymov = @ayear
	GROUP BY P.npay,P.adate,P.printdate,PT.transmissiondate,p.flag&7,F.codefin,R.title

END

UPDATE #payment SET kind = 'RESIDUO' WHERE kind = 'R'
UPDATE #payment SET kind = 'COMPETENZA' WHERE kind = 'C'              	
SELECT 
	npay as 'Numero Mandato',
	adate as 'Data Contabile',
	printdate as 'Data Stampa',
    	transmissiondate as 'Data Trasmissione',
	kind as 'Tipo Pagamento',
	amount as 'Importo Lordo',
	codefin as 'Capitolo',
    	description as 'Descrizione',
	registry as 'Percipiente',
	nmov as 'Numero Movimento'
FROM #payment
ORDER BY npay
	       	
END    


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_listing_proceed.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_listing_proceed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_listing_proceed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_listing_proceed]
(
	@ayear int,
	@unified varchar(1)
)
AS BEGIN
/* Versione 1.0.1 del 12/09/2007 ultima modifica: PINO */

CREATE TABLE #proceeds
(
	npro int,
	adate datetime,
	printdate datetime,
	transmissiondate datetime,
	kind varchar(20),
	amount decimal(23,6),
	codefin varchar(50),
	description varchar(150),
  	registry varchar(100),
	nmov int
)

IF @unified = 'N'
BEGIN
	INSERT INTO #proceeds
	(
		npro, adate, printdate, transmissiondate,
		kind, amount, codefin,
		description, registry, nmov
	)
	SELECT 
		P.npro, P.adate, P.printdate, PT.transmissiondate,
		CASE
			when (( IT.flag & 1)=0) then 'C'
			when (( IT.flag & 1)=1) then 'R'
		End,
		IY.amount,-- I.amount, 
		F.codefin,
		I.description, R.title, I.nmov
	FROM incomelast IL
	JOIN income I
		ON I.idinc = IL.idinc
	JOIN incomeyear IY
		ON IY.idinc = IL.idinc
	JOIN incometotal IT
		ON IT.idinc = I.idinc
	JOIN fin F
		ON F.idfin = IY.idfin 
	JOIN registry R
		ON R.idreg = I.idreg
	JOIN proceeds P
		ON IL.kpro = P.kpro
	LEFT OUTER JOIN proceedstransmission PT
		ON PT.kproceedstransmission = P.kproceedstransmission
	WHERE I.ymov = @ayear
END
ELSE
BEGIN
	INSERT INTO #proceeds
	(
		npro, adate, printdate, transmissiondate,
		kind, amount, codefin, registry
	)
	SELECT 
		P.npro, P.adate, P.printdate, PT.transmissiondate,
		case P.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		ISNULL(SUM(IY.amount),0),-- ISNULL(SUM(E.amount),0),
		F.codefin, R.title
	FROM incomelast IL
	JOIN income I
		ON I.idinc = IL.idinc
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN registry R
		ON R.idreg = I.idreg
	JOIN incometotal IT
		ON IT.idinc = I.idinc
	JOIN proceeds P
		ON IL.kpro = P.kpro
	LEFT OUTER JOIN proceedstransmission PT
		ON PT.kproceedstransmission = P.kproceedstransmission
	WHERE I.ymov = @ayear
	GROUP BY P.npro,P.adate,P.printdate,PT.transmissiondate,P.flag&7,F.codefin,R.title

END
UPDATE #proceeds SET kind = 'RESIDUO' WHERE kind = 'R'
UPDATE #proceeds SET kind = 'COMPETENZA' WHERE kind = 'C'
SELECT 
	npro AS 'Numero Reversale',	 	
	adate AS 'Data Contabile',		
	printdate AS 'Data Stampa',        	
    	transmissiondate AS 'Data Trasmissione', 	
	kind AS 'Tipo Incasso',		
	amount AS 'Importo Lordo',	        
	codefin AS 'Capitolo',		
    	description AS 'Descrizione',             
	registry AS 'Versante',
	nmov AS 'Numero Movimento'
FROM #proceeds
ORDER BY npro
       	
END    


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_mov_without_data.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mov_without_data]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mov_without_data]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE              PROCEDURE [exp_mov_without_data]
(@ayear int
)
AS 
BEGIN
IF (@ayear IS NULL)
BEGIN
	SELECT 	ypay AS Esercizio,
		npay AS Numero,
		yban AS 'Esercizio Transazione',
		nban AS 'N.Transazione',
		amount AS 'Importo Esitato',
		'Mandato' AS 'Tipo Documento'
	FROM banktransaction 
	JOIN payment
		ON banktransaction.kpay = banktransaction.kpay
	WHERE (transactiondate IS NULL) AND (banktransaction.kpay IS NOT NULL)
	UNION
	SELECT 	ypro AS Esercizio,
		npro AS Numero,
		yban AS 'Esercizio Transazione',
		nban AS 'N.Transazione',
		amount AS 'Importo Esitato',
		'Reversale' AS 'Tipo Documento'
	FROM banktransaction
	JOIN proceeds
		ON banktransaction.kpro = banktransaction.kpro 
	WHERE (transactiondate IS NULL) AND (banktransaction.kpro IS NOT NULL)
	ORDER BY 'Tipo Documento', 'Esercizio','Numero'
 END
ELSE
BEGIN
	SELECT  ypay as Esercizio,
		npay as Numero,
		yban as 'Esercizio Transazione',
		nban as 'N.Transazione',
		amount as 'Importo Esitato',
		'Mandato' as 'Tipo Documento'
	FROM banktransaction 
	JOIN payment
		ON banktransaction.kpay = banktransaction.kpay
	WHERE (transactiondate IS NULL) AND (ypay = @ayear)
	
	UNION
	
	SELECT  ypro as Esercizio,
		npro as Numero,
		yban as 'Esercizio Transazione',
		nban as 'N.Transazione',
		amount as 'Importo Esitato',
		'Reversale' as 'Tipo Documento'
	FROM banktransaction 
	JOIN proceeds
		ON banktransaction.kpro = banktransaction.kpro 
	WHERE (transactiondate IS NULL) AND (ypro = @ayear)
	ORDER  BY 'Tipo Documento', 'Esercizio','Numero'
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_not_spread_prevision.sql

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_not_spread_prevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_not_spread_prevision]
GO

CREATE PROCEDURE exp_not_spread_prevision
(
	@ayear int
)
AS BEGIN
DECLARE @fin_kind tinyint

CREATE TABLE #fin
(
	codeupb varchar(50),
	upb varchar(150),
	codefin varchar(50),
	fin varchar(150),
	prevision decimal(19,2),
	son_prevision decimal(19,2),
	secprevision decimal(19,2),
	son_secprevision decimal(19,2),
	finpart char(1)
)

SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

DECLARE @min tinyint
DECLARE @max tinyint


SELECT @min = MIN(nlevel) FROM finlevel WHERE ayear = @ayear AND (flag&2)<>0 --usable = 'S'
SELECT @max = MAX(nlevel) FROM finlevel WHERE ayear = @ayear

IF (@min = @max) RETURN

IF (@fin_kind = 3)
BEGIN
	INSERT INTO #fin
	(
		codeupb, upb, codefin, fin, finpart, 
		prevision, son_prevision, secprevision, son_secprevision
	)
	SELECT
		codeupb, upb, codefin, title, finpart,
		ISNULL(prevision,0),
		ISNULL((SELECT SUM(prevision) FROM finview f2 WHERE f2.paridfin = finview.idfin),0),
		ISNULL(secondaryprev, 0),
		ISNULL((SELECT SUM(secondaryprev) FROM finview f2 WHERE f2.paridfin = finview.idfin),0)
	FROM finview
	WHERE ayear = @ayear
		AND nlevel BETWEEN @min AND (@max - 1)
		AND NOT EXISTS
			(SELECT idfin FROM finlast WHERE finview.idfin = finlast.idfin)
		AND (
			ISNULL(prevision,0) >
			ISNULL(
				(SELECT SUM(prevision) FROM finview f2 WHERE f2.paridfin = finview.idfin)
			,0)
			OR
			ISNULL(secondaryprev,0) >
			ISNULL(
				(SELECT SUM(secondaryprev) FROM finview f2 WHERE f2.paridfin = finview.idfin)
			,0)
		)
END

IF (@fin_kind = 1) OR (@fin_kind = 3)
BEGIN
	INSERT INTO #fin
	(
		codeupb, upb, codefin, fin, finpart,
		prevision, son_prevision
	)
	SELECT
		codeupb, upb, codefin, title, finpart, 
		ISNULL(prevision,0),
		ISNULL((SELECT SUM(prevision) FROM finview f2 WHERE f2.paridfin = finview.idfin),0)
	FROM finview
	WHERE ayear = @ayear
		AND nlevel BETWEEN @min AND (@max - 1)
		AND NOT EXISTS
			(SELECT idfin FROM finlast WHERE finview.idfin = finlast.idfin)
		AND ISNULL(prevision,0) >
			ISNULL(
				(SELECT SUM(prevision) FROM finview f2 WHERE f2.paridfin = finview.idfin)
			,0)
END

IF (@fin_kind = 1) OR (@fin_kind = 2)
BEGIN
	SELECT
		codeupb AS 'Cod. U.P.B.',
		upb AS 'Denominazione U.P.B.',
		codefin AS 'Cod. Bilancio',
		fin AS 'Denominazione Bilancio',
		CASE
			WHEN finpart = 'E' THEN 'Entrata'
			ELSE 'Spesa'
		END AS 'Parte Bil.',
		prevision AS 'Prev. Iniziale Princ.',
		son_prevision AS 'Prev. Iniziale Princ. dei figli'
	FROM #fin
END
ELSE
BEGIN
	SELECT
		codeupb AS 'Cod. U.P.B.',
		upb AS 'Denominazione U.P.B.',
		codefin AS 'Cod. Bilancio',
		fin AS 'Denominazione Bilancio',
		CASE
			WHEN finpart = 'E' THEN 'Entrata'
			ELSE 'Spesa'
		END AS 'Parte Bil.',
		prevision AS 'Prev. Iniziale Princ.',
		son_prevision AS 'Prev. Iniziale Princ. dei figli',
		secprevision AS 'Prev. Iniziale Sec.',
		son_secprevision AS 'Prev. Iniziale Sec. dei figli'
	FROM #fin
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_payment.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
/*
 exec exp_payment 2007,{ts '2007-01-20 00:00:00'},{ts '2007-08-20 00:00:00'},'%',null 
*/

CREATE            PROCEDURE [exp_payment]
@ayear int,
@start datetime,
@stop  datetime,
@codefin varchar(50),
@idman int
AS BEGIN 
/* Versione 1.0.1 del 05/09/2007 ultima modifica: PINO */
SET @codefin = ISNULL(@codefin,'')+'%'

DECLARE @maxphase tinyint
SELECT @maxphase =  MAX(nphase) FROM expensephase
SELECT 
        MAN.title AS Responsabile,
	F.codefin AS 'Codice Bilancio',
	F.title AS 'Denom. Bilancio' ,
	PHASE.description AS Fase,
	EX.ymov  AS 'Eserc. Movimento',
	EX.nmov AS 'Num. Movimento',
	EX.description AS Descrizione,
	EXY.amount AS 'Importo Originale',
	EXT.curramount AS 'Importo Corrente',
	EX.doc AS 'Documento collegato',
	EX.docdate AS 'Data Documento collegato',
	EX.adate AS 'Data Contabile Movimento',
	EX.expiration AS 'Data Scadenza',
	REG.title AS Percipiente,	
	U.codeupb AS 'Codice UPB',
	U.title AS UPB,
	SER.description AS Prestazione,
	EXL.servicestart AS 'Data Inizio Prest.',
	EXL.servicestop AS 'Data Fine Prest.',
   	CASE
		when (( EXT.flag & 1)=0) then 'C/Residui'
		when (( EXT.flag & 1)=1) then 'C/Competenza' 
	End AS Competenza,
	PAY.ypay AS 'Eserc. Mandato',
	PAY.npay AS 'Num. Mandato',
	PAY.adate AS 'Data Contabile Mandato',
        PAY.printdate AS 'Data Stampa Mandato',
        TX.transmissiondate AS 'Data Trasm. Mandato',
	TX.ypaymenttransmission AS 'Eserc. Elenco Trasm.',
	TX.npaymenttransmission AS 'Num. Elenco Trasm.'
FROM expense EX (NOLOCK)
JOIN expensephase PHASE (NOLOCK)
	ON PHASE.nphase = EX.nphase
JOIN expenseyear EXY(NOLOCK)
	ON EXY.idexp = EX.idexp
JOIN expensetotal EXT(NOLOCK)
	ON EXT.idexp = EX.idexp
	AND EXT.ayear = EXY.ayear
JOIN expenselast EXL(NOLOCK)
	ON EXL.idexp = EX.idexp
LEFT OUTER JOIN fin F (NOLOCK)
	ON F.idfin = EXY.idfin
LEFT OUTER JOIN upb U(NOLOCK)
	ON U.idupb = EXY.idupb
LEFT OUTER JOIN registry REG(NOLOCK)
	ON REG.idreg = EX.idreg
LEFT OUTER JOIN manager MAN(NOLOCK) 
	ON MAN.idman = EX.idman
LEFT OUTER JOIN service SER(NOLOCK)
	ON SER.idser = EXL.idser
LEFT OUTER JOIN payment PAY(NOLOCK)
	ON EXL.kpay = PAY.kpay 
LEFT OUTER JOIN paymenttransmission TX(NOLOCK)
	ON PAY.kpaymenttransmission = TX.kpaymenttransmission 
WHERE EX.adate BETWEEN @start AND @stop 
	AND EX.nphase = @maxphase	
	AND EXY.ayear = @ayear 
	AND F.codefin LIKE @codefin 
	AND (EX.idman = @idman or @idman is null)
ORDER BY EX.idman, F.codefin, EX.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_payment_not_performed.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_not_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_not_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- ELENCO MANDATI NON ESITATI
CREATE                          PROCEDURE [exp_payment_not_performed]
@date datetime,  -- data in cui si effettua l'interrogazione
@ayear  int 	 -- anno dei mandati da controllare
AS 
BEGIN
SELECT  P.ypay AS 'Esercizio Mandato',
	P.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	E.nmov AS 'Num. Movimento',
	E.description AS Descrizione,
	E.registry AS Percipiente,
	E.curramount AS Importo
FROM expenseview E
JOIN payment P
	ON E.ypay = P.ypay
	AND E.npay = P.npay
JOIN paymenttransmission PT
	ON PT.kpaymenttransmission = P.kpaymenttransmission
WHERE (E.ayear IS NULL OR p.ypay = @ayear)
	AND PT.transmissiondate <= @date
	AND (	SELECT COUNT(*) FROM banktransaction PD
		WHERE PD.kpay=P.kpay 
			AND PD.transactiondate <= @date) = 0
ORDER BY E.ypay,E.npay,E.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_payment_partially_performed.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_partially_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_partially_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [exp_payment_partially_performed]
@date smalldatetime,
@ayear  smallint
AS BEGIN

/* Versione 1.0.0 del 14/09/2007 ultima modifica: PIERO */

	SELECT p.ypay AS 'Esercizio Mandato',
	p.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	SUM(ET.curramount) AS 'Importo totale' ,
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(ET.curramount) -
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato'
	FROM expensetotal et 
	JOIN expense e
		ON et.idexp=e.idexp
	JOIN expenselast el
		ON el.idexp=e.idexp
	JOIN payment p
		ON  p.kpay = el.kpay
	JOIN paymenttransmission pt
		ON pt.kpaymenttransmission = p.kpaymenttransmission
	WHERE pt.transmissiondate <= @date
		AND p.ypay = @ayear
	GROUP BY P.ypay,P.npay,P.adate,el.kpay 
	HAVING ISNULL(SUM(ET.curramount),0)>0
		AND ISNULL(SUM(ET.curramount),0) - 
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpay = el.kpay
		AND pd.transactiondate <= @date)
	,0) > 0

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_payment_proceeds_without_date.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_proceeds_without_date]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_proceeds_without_date]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE       PROCEDURE [exp_payment_proceeds_without_date]
@date datetime,
@ayear int
AS 
BEGIN
-- Attenzione! le transazioni bancarie considerate sono tutte quelle legate a documenti trasmessi entro la data @date
-- se invece si vuole vedere tutte le transazioni senza transactiondate bisogna eliminare tale filtro e, contestualmente
-- anche il parametro @date che non servirebbe più
SELECT
	B.yban AS 'Esercizio Transazione',
	B.nban AS 'Numero Transazione',
	P.ypay AS 'Esercizio Documento',
	P.npay AS 'Numero Documento',
	ISNULL(B.amount,0) AS 'Importo',
	'Mandato' AS 'Tipo Movimento'
FROM banktransaction B
JOIN payment P
	ON P.kpay = B.kpay
JOIN paymenttransmission PT
	ON PT.kpaymenttransmission = P.kpaymenttransmission
WHERE B.yban = @ayear 
	AND PT.transmissiondate <= @date
	AND B.transactiondate IS NULL
UNION
SELECT
	B.yban AS 'Esercizio Transazione',
	B.nban AS 'Numero Transazione',
	P.ypro AS 'Esercizio Documento',
	P.npro AS 'Numero Documento',
	ISNULL(B.amount,0) AS 'Importo',
	'Reversale' AS 'Tipo Movimento'
FROM banktransaction B
JOIN proceeds P
	ON P.kpro = B.kpro
JOIN proceedstransmission PT
	ON PT.kproceedstransmission = P.kproceedstransmission	
WHERE B.yban = @ayear 
	AND PT.transmissiondate <= @date
	AND B.transactiondate IS NULL
ORDER BY 'Tipo Movimento', 'Esercizio Documento','Numero Documento'
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_payment_trasmitted.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_trasmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_trasmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                     PROCEDURE [exp_payment_trasmitted]
@date datetime,
@ayear int
AS 
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
SELECT  P.ypay  AS 'Esercizio Mandato',
	P.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	SUM(ET.curramount) AS 'Importo totale',
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(ET.curramount) -
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction B
		WHERE B.kpay = EL.kpay
		AND B.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato'
FROM expensetotal ET 
JOIN expense E 
	ON ET.idexp = E.idexp  	AND ET.ayear = @ayear
JOIN expenselast EL 
	ON EL.idexp = E.idexp  
JOIN payment P 
	ON P.kpay = EL.kpay
JOIN paymenttransmission pt
	ON PT.kpaymenttransmission = P.kpaymenttransmission
WHERE P.ypay = @ayear
	AND PT.transmissiondate <= @date
	AND PT.ypaymenttransmission = @ayear
GROUP BY P.ypay,P.npay,P.adate,EL.kpay 
HAVING ISNULL(SUM(ET.curramount),0)>0 
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_payment_without_expense.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment_without_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment_without_expense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE [exp_payment_without_expense]
@ayear smallint,
@date smalldatetime

AS BEGIN
--	mov. bancari a debito non collegati a mandati o collegati a mandati  trasmessi dopo la data
SELECT  			
	PD.yban as 'Esercizio Transazione', 
	PD.nban as 'Numero Transazione' ,
	P.ypay as 'Esercizio del Mandato' ,       
	P.npay as 'Numero Mandato',                
	isnull( ET.curramount,0) as 'Importo',
	isnull(PD.amount,0) as 'Importo Esitato',
	PD.transactiondate as 'Data Operazione' 
FROM    banktransaction PD 
JOIN    payment P
	ON P.kpay = PD.kpay
JOIN expensetotal ET 
	ON ET.idexp = PD.idexp 
WHERE PD.transactiondate <= @date 
	AND ET.ayear=@ayear 
	AND kind = 'D'
	AND (pd.kpay is null 
		OR NOT EXISTS
			(SELECT *	--PT.transmissiondate 
			FROM paymenttransmission PT  
				
			WHERE PD.kpay = P.kpay 
			AND PT.kpaymenttransmission = P.kpaymenttransmission 
			AND PT.transmissiondate <=@date
			)
		)
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_prev_performed_payment.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prev_performed_payment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prev_performed_payment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE                    procedure [exp_prev_performed_payment]
@date datetime,
@ayear int 
AS 
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
DECLARE @DEC_31_ayearprevious datetime
SET @DEC_31_ayearprevious = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),(@ayear-1)), 105)
	
SELECT 
	P.ypay AS 'Esercizio Mandato',
	P.npay AS 'Numero Mandato',
	P.adate AS 'Data Mandato',
	SUM(ET.curramount) AS 'Importo totale',
	ISNULL(
		(SELECT SUM(PD.amount)
		FROM banktransaction PD 
		WHERE PD.kpay = EL.kpay
		AND PD.transactiondate > @DEC_31_ayearprevious
		AND PD.transactiondate <= @date)
	,0) AS 'Importo esitato nell''esercizio corrente, alla data'
FROM expensetotal ET 
JOIN expense E 
	ON ET.idexp = E.idexp
JOIN expenselast EL 
	ON ET.idexp = E.idexp
JOIN payment P 
	ON  P.kpay = EL.kpay 
JOIN paymenttransmission PT
	ON PT.kpaymenttransmission = P.kpaymenttransmission
WHERE PT.transmissiondate <= @date
	AND P.ypay = (@ayear - 1)
GROUP BY P.ypay, P.npay, P.adate, EL.kpay 
HAVING ISNULL(SUM(ET.curramount),0)>0
	AND ISNULL(
		(SELECT SUM(PD.amount)
		FROM banktransaction PD 
		WHERE PD.kpay = EL.kpay
		AND PD.transactiondate > @DEC_31_ayearprevious
		AND PD.transactiondate <= @date)
	,0) >0
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_prev_performed_proceeds.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prev_performed_proceeds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prev_performed_proceeds]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                          PROCEDURE [exp_prev_performed_proceeds]
@date datetime,
@ayear int 
AS 
BEGIN
/* Versione 1.0.0 del 05/09/2007 ultima modifica: SARA */
DECLARE @DEC_31_ayearprevious datetime
SET @DEC_31_ayearprevious = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),(@ayear-1)), 105)
	
SELECT 
	P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	P.adate AS 'Data Reversale',
	SUM(IT.curramount) AS 'Importo totale',
	ISNULL(
		(SELECT SUM(PD.amount)
		FROM banktransaction PD 
		WHERE PD.kpro = IL.kpro
		AND PD.transactiondate > @DEC_31_ayearprevious
		AND PD.transactiondate <= @date)
	,0) AS 'Importo esitato nell''esercizio corrente, alla data'
FROM incometotal IT 
JOIN income I 
	on IT.idinc = I.idinc
JOIN incomelast IL 
	on IL.idinc = I.idinc
JOIN proceeds P 	
	on P.kpro = IL.kpro
JOIN proceedstransmission PT
	ON PT.kproceedstransmission = P.kproceedstransmission
WHERE PT.transmissiondate <= @date
	AND P.ypro = (@ayear - 1)
GROUP BY P.ypro,P.npro,P.adate, IL.kpro 
HAVING ISNULL(SUM(IT.curramount),0)>0
	AND ISNULL(
		(SELECT SUM(PD.amount)
		FROM banktransaction PD 
		WHERE PD.kpro = IL.kpro
		AND PD.transactiondate > @DEC_31_ayearprevious
		AND PD.transactiondate <= @date)
	,0) >0
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_proceeds_not_performed.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_not_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_not_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE                               PROCEDURE [exp_proceeds_not_performed]
@date datetime,
@ayear int
AS 
BEGIN
SELECT  P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	P.adate AS 'Data Reversale',
	I.nmov AS 'Num.Movimento',
	I.description AS Descrizione,
	I.registry AS Versante,
	I.curramount AS Importo
FROM incomeview I
JOIN proceeds P
	ON I.ypro = P.ypro
	AND I.npro = P.npro
JOIN proceedstransmission pt
	ON pt.kproceedstransmission = p.kproceedstransmission
WHERE (I.ayear IS NULL OR p.ypro=@ayear)
	AND pt.transmissiondate <= @date
	AND
		(SELECT COUNT(*) FROM banktransaction PD
		WHERE PD.kpro=P.kpro AND 
		PD.transactiondate <= @date) = 0
ORDER BY P.ypro,P.npro,I.nmov
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_proceeds_partially_performed.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_partially_performed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_partially_performed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                           PROCEDURE [exp_proceeds_partially_performed]
@date smalldatetime,
@ayear smallint
AS BEGIN

/* Versione 1.0.0 del 14/09/2007 ultima modifica: PIERO */

	SELECT P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	p.adate AS 'Data Reversale',
	SUM(it.curramount) AS 'Importo Totale' ,
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpro = il.kpro
		AND pd.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(it.curramount) -
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpro = il.kpro
		AND pd.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato'
	FROM incometotal it 
	JOIN income i
		ON it.idinc = i.idinc
	JOIN incomelast il
		ON il.idinc = i.idinc
	JOIN proceeds p
		ON p.kpro = il.kpro
	JOIN proceedstransmission pt
		ON pt.kproceedstransmission = p.kproceedstransmission
	WHERE pt.transmissiondate <= @date
		AND p.ypro = @ayear
	GROUP BY P.ypro,P.npro,p.adate,il.kpro 
	HAVING ISNULL(SUM(it.curramount),0) > 0
		AND ISNULL(SUM(it.curramount),0) - 
	ISNULL(
		(SELECT SUM(pd.amount)
		FROM banktransaction pd
		WHERE pd.kpro = il.kpro
		AND pd.transactiondate <= @date)
	,0) > 0
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_proceeds_trasmitted.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_trasmitted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_trasmitted]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec exp_proceeds_trasmitted {ts '2006-10-07 00:00:00'},2006


CREATE  PROCEDURE [exp_proceeds_trasmitted]
@date smalldatetime,
@ayear smallint
AS BEGIN

/* Versione 1.0.0 del 14/09/2007 ultima modifica: PIERO */

SELECT
	P.ypro AS 'Esercizio Reversale',
	P.npro AS 'Numero Reversale',
	p.adate AS 'Data Reversale',
	SUM(it.curramount) AS 'Importo Totale',
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction b
		WHERE b.kpro = il.kpro
			AND b.transactiondate <= @date)
	,0) AS 'Importo Esitato',
	(SUM(it.curramount) - 
	ISNULL(
		(SELECT SUM(amount)
		FROM banktransaction b
		WHERE b.kpro = il.kpro
			AND b.transactiondate <= @date)
	,0)) AS 'Importo Non Esitato'	
	FROM incometotal it 
	JOIN income i 
		ON it.idinc=i.idinc
	JOIN incomelast il 
		ON il.idinc = i.idinc
	JOIN proceeds p 
		ON p.kpro = il.kpro
	JOIN proceedstransmission pt
		ON pt.kproceedstransmission = p.kproceedstransmission
	WHERE p.ypro = @ayear
		AND pt.transmissiondate <= @date
	group by P.ypro, P.npro, p.adate, il.kpro
	HAVING ISNULL(SUM(it.curramount),0)>0 
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\exp_proceeds_without_income.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_proceeds_without_income]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_proceeds_without_income]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE [exp_proceeds_without_income]
@ayear smallint,
@date smalldatetime

AS BEGIN
--	mov. bancari a credito non collegati a reversali o collegati a reversali trasmesse dopo la data
SELECT 		
	PD.yban as 'Esercizio Transazione' ,
	PD.nban as 'Numero Transazione',
	P.ypro as 'Esercizio Reversale',       
	P.npro as 'Numero Reversale',                
	isnull( IT.curramount,0) as 'Importo',
	isnull(PD.amount,0) as 'Importo Esitato',
	PD.transactiondate as 'Data Operazione' 
FROM  banktransaction PD 
JOIN  proceeds P
	ON P.kpro = PD.kpro
JOIN incometotal IT 
	ON IT.idinc = PD.idinc 
WHERE PD.transactiondate <= @date 
	AND IT.ayear=@ayear
	--AND ISNULL(PD.amount,0) = ISNULL( IT.curramount,0) 
	AND kind = 'C'
	AND (PD.kpro is null 
		OR NOT EXISTS
			(SELECT *	--PT.transmissiondate 
			FROM proceedstransmission PT  
				
			WHERE PD.kpro = P.kpro
			AND PT.kproceedstransmission = P.kproceedstransmission 
				AND PT.transmissiondate <=@date
			)
		)

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_fin.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_fin]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [show_fin]
(
	@date datetime,
	@idfin int ,
	@finpart char(1)
)
AS BEGIN
--DECLARE @prevision char(1)
--DECLARE @secondaryprev char(1)
DECLARE @fin_kind tinyint
DECLARE @ayear int
SELECT @ayear = YEAR(@date)
SELECT @fin_kind = fin_kind
FROM config
WHERE ayear = @ayear
IF (@fin_kind = 1)
BEGIN
	EXEC show_fin_comp @date,@idfin,@finpart
END
IF (@fin_kind = 3)
BEGIN
	EXEC show_fin_compcash @date,@idfin,@finpart
END
IF (@fin_kind = 2)
BEGIN
	EXEC show_fin_onlycash @date,@idfin,@finpart
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_finyear.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_finyear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_finyear]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [show_finyear]
(
	@date datetime,
	@idupb varchar(36),
	@idfin int,
	@finpart char(1)
)
AS BEGIN
DECLARE @fin_kind tinyint
DECLARE @ayear int
SELECT @ayear = YEAR(@date)
SELECT @fin_kind
FROM config
WHERE ayear = @ayear
IF (@fin_kind = 1)
BEGIN
	EXEC show_finyear_comp @date,@idupb,@idfin,@finpart
END
IF (@fin_kind = 3)
BEGIN
	EXEC show_finyear_compcash @date,@idupb,@idfin,@finpart
END
IF (@fin_kind = 2)
BEGIN
	EXEC show_finyear_onlycash @date,@idupb,@idfin,@finpart
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_finyear_onlycash.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_finyear_onlycash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_finyear_onlycash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE          PROCEDURE [show_finyear_onlycash]
	@date  datetime,
	@idupb varchar(36),
	@idfin int,
	@finpart char(1)
AS BEGIN
/* Versione 1.0.1 del 27/11/2007 ultima modifica: MARIA */
	DECLARE	@ayear int -- Esercizio
	SELECT @ayear = YEAR(@date)

	DECLARE @lbl_dispacc varchar(150) -- Etichetta sulla disponibilità ad accertate
	DECLARE @lbl_dispcash_e varchar(150) -- Etichetta sulla prev. disponibile di cassa
	DECLARE @lbl_dispimp varchar(150) -- Etichetta sulla disponibilità ad impegnare che varia in base alla presenza delle operazioni del fondo economale
	DECLARE @lbl_dispcash_s varchar(150) -- Etichetta sulla prev. disponibile di cassa che varia in base alla presenza delle operazioni del fondo economale
	DECLARE @lbl_disp_firstphase varchar(150) -- Etichetta sulla disponibilità calcolata sulla prima fase di entrata

	DECLARE	@mainprev_var_AUM decimal(19,2) -- Totale delle variazioni di previsione principale in aumento
	DECLARE	@mainprev_var_DIM decimal(19,2) -- Totale delle variazioni di previsione principale in diminuzione

-- Variabili utilizzate nella sezione RIEPILOGO FASI FINANZIARIE
	DECLARE @nextphasecomp decimal(19,2) -- Calcolo della fase successiva in c/competenza
	DECLARE @nextphaseres decimal(19,2) -- Calcolo della fase successiva in c/residui

-- Tabella della situazione della voce di bilancio
	CREATE TABLE #situation (value varchar(200), amount decimal(19,2), kind char(1))
-- Tabella dei movimenti di competenza
	CREATE TABLE #tot_mov_c	(nphase tinyint, amount decimal(19,2))

-- Tabella delle variazioni sui movimenti di competenza
	CREATE TABLE #tot_var_c	(nphase tinyint, amount decimal(19,2))

	
	--------------------------------------------------------------------------------------------------------
        -- Verifica se l'avanzo di amministrazione non è totalizzato e viene attribuito in previsione ad una voce  
	-- di bilancio in entrata
	/*DECLARE @flagincomesurplus char(1)      -- Flag indicante se l'avanzo di amministrazione è attribuito in previsione ad un capitolo di entrata o no
	SELECT @flagincomesurplus = 
	CASE 
		when ( idfinincomesurplus is null) then 'N'
		when ( idfinincomesurplus is not null) then 'S'
	End
	FROM config
	where ayear = @ayear*/
	---------------------------------------------------------------------------------------------------------
	
	DECLARE @floatfund decimal(19,2) -- Avanzo di Cassa
	DECLARE	@departmentname varchar(150) -- Nome del Dipartimento
	SELECT @floatfund = ISNULL(floatfund,0) FROM finsurplusview WHERE ayear = @ayear
	SELECT 	@departmentname = isnull(paramvalue,'Manca Cfg. Parametri Tutte le stampe') from
				generalreportparameter where idparam='DenominazioneDipartimento'

	/*DECLARE	@finpart char(1) -- Parte del bilancio (E = Entrata S = Spesa)
	--SELECT @finpart = SUBSTRING(@idfin, 3, 1)
	SELECT @finpart = 
	CASE 
		WHEN ( (flag & 1)=0) then 'E'
		WHEN ( (flag & 1)=1) then 'S'
	END
	FROM fin
	WHERE idfin = @idfin
*/
DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

	DECLARE	@levelusable tinyint --varchar(20) -- Livello operativo per le voci di bilancio
	DECLARE	@arrearsphase int

	--DECLARE @lengthidfin int -- Lunghezza dell'id della voce di bilancio
	--SELECT @lengthidfin = DATALENGTH(@idfin)
	SELECT @arrearsphase = 1
	SELECT @levelusable = MIN(nlevel) FROM finlevel
		WHERE (flag & 2)<>0 and  ayear = @ayear

	DECLARE	@fincode varchar(50) -- Codice di bilancio
	DECLARE	@fintitle varchar(150) -- Descrizione della voce di bilancio
	DECLARE	@nlevel tinyint--varchar(20) -- Livello della voce di bilancio
	SELECT @nlevel = nlevel, @fincode = codefin, @fintitle = title FROM fin WHERE idfin = @idfin

	DECLARE	@leveldesc varchar(50)
	SELECT @leveldesc = description FROM finlevel WHERE ayear = @ayear AND @nlevel = nlevel

	DECLARE	@finphase tinyint  --char(1) -- Fase in cui viene inserita la voce di bilancio
	DECLARE	@lastphase tinyint  --char(1) -- Fase di cassa

	DECLARE @competencyphase tinyint  --char(1) -- Fase paragonabile all'accertamento o all'impegno

	IF @finpart = 'E'
		BEGIN
			SELECT @competencyphase = assessmentphasecode FROM config
				WHERE ayear = @ayear
			SELECT @arrearsphase = incomefinphase from uniconfig
			SELECT @finphase = incomefinphase from uniconfig
			SELECT @lastphase = MAX(nphase) FROM incomephase
		END
	ELSE
		BEGIN
			SELECT @competencyphase = appropriationphasecode FROM config
				WHERE ayear = @ayear
			SELECT @arrearsphase = expensefinphase from uniconfig
			SELECT @finphase = expensefinphase from uniconfig
			SELECT @lastphase = MAX(nphase) FROM expensephase

		END

	DECLARE @descupb varchar(150)
	DECLARE @codeupb varchar(50)
	SELECT @descupb = title,
	@codeupb = codeupb
	FROM upb
	WHERE idupb = @idupb

	DECLARE	@mainprev decimal(19,2) -- Previsione Principale

	IF @nlevel < @levelusable OR @nlevel IS NULL
		BEGIN
		SELECT @mainprev = SUM(ISNULL(prevision,0)) 
			FROM finyearview
			JOIN finlink
				ON finlink.idchild = finyearview.idfin
			join fin
				ON finyearview.idfin = fin.idfin
		WHERE finyearview.nlevel  = @levelusable
		AND idupb = @idupb
		and fin.ayear = @ayear
		AND (
			(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
			OR 
			( @nlevel is null AND finlink.nlevel = @levelusable)
		    )
		and ((fin.flag & 1 ) = @finpart_bit)
			--WHERE SUBSTRING(idfin, 1, @lengthidfin) = @idfin
			--AND nlevel = @levelusable
			--AND idupb = @idupb
		END
	ELSE
		BEGIN
		SELECT @mainprev = prevision
			FROM finyear
			WHERE idfin = @idfin
			AND idupb = @idupb
		END		


	SELECT @mainprev_var_AUM = SUM(finvardetail.amount)
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN finlink 
		ON finlink.idchild = finvardetail.idfin
	join fin 
		ON finvardetail.idfin = fin.idfin
	WHERE 	(	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )--SUBSTRING(finvardetail.idfin, 1, @lengthidfin) = @idfin
		AND finvar.adate <=	@date
		AND finvar.flagprevision = 'S'
		and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
		AND idupb = @idupb
		AND amount > 0

	SELECT @mainprev_var_DIM = SUM(finvardetail.amount)
	FROM finvardetail
	JOIN finvar
		ON finvar.yvar = finvardetail.yvar
		AND finvar.nvar = finvardetail.nvar
	JOIN finlink 
		ON finlink.idchild = finvardetail.idfin
	join fin 
		ON finvardetail.idfin = fin.idfin
	WHERE 	(	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )--SUBSTRING(finvardetail.idfin, 1, @lengthidfin) = @idfin
		AND finvar.adate <= @date
		and fin.ayear = @ayear
		and ((fin.flag & 1 ) = @finpart_bit) and fin.ayear = @ayear
		AND finvar.flagprevision = 'S'
		AND idupb = @idupb
		AND amount < 0

	DECLARE @currmainprev decimal(19,2) -- Previsione Attuale Principale
	DECLARE @tot_mainprev_var decimal(19,2) -- Totale delle variazioni di previsione principale

-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
	SET @tot_mainprev_var = ISNULL(@mainprev_var_AUM,0) + ISNULL(@mainprev_var_DIM,0)
-- Calcolo della previsione principale attuale
	SET @currmainprev = ISNULL(@mainprev,0) + ISNULL(@tot_mainprev_var,0)

	DECLARE @totpayment decimal(19,2) -- Totale Mandati (secondo la configurazione di bilancio)
	DECLARE @totproceeds decimal(19,2) -- Totale Reversali (secondo la configurazione di bilancio)

	IF @finpart = 'E'
		BEGIN
			INSERT INTO #tot_mov_c
			SELECT I.nphase, 
				SUM(IY.amount) --incometotal
			FROM incomeyear IY
			/*JOIN incometotal
				ON incometotal.idinc = incomeyear.idinc
				AND incometotal.ayear = incomeyear.ayear*/
			JOIN income I
				ON I.idinc = IY.idinc
			JOIN finlink FLK
				ON FLK.idchild = IY.idfin
			WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				AND IY.ayear = @ayear
				AND IY.idupb = @idupb
				AND I.nphase >= @finphase
				AND I.adate <= @date
			GROUP BY I.nphase

			INSERT INTO #tot_var_c
			SELECT income.nphase, 
				SUM(incomevar.amount)
			FROM incomevar
			JOIN incomeyear
				ON incomeyear.idinc = incomevar.idinc
			JOIN income 
				ON income.idinc = incomeyear.idinc
			JOIN finlink FLK
				ON FLK.idchild = incomeyear.idfin
			WHERE incomevar.yvar = @ayear
				AND incomevar.adate <= @date
				AND incomeyear.idupb = @idupb
				and (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )--AND SUBSTRING(incomeyear.idfin, 1,	@lengthidfin) = @idfin
				AND incomeyear.ayear = @ayear
				AND income.nphase >= @finphase
			GROUP BY income.nphase

			SET @totproceeds = 
			ISNULL(
				(SELECT SUM(curramount)
				FROM historyproceedsview HPV
				JOIN finlink FLK
					ON FLK.idchild = HPV.idfin
				WHERE HPV.ymov = @ayear
					and (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )--AND SUBSTRING(idfin,1,@lengthidfin) = @idfin 
					AND idupb = @idupb
					AND competencydate <= @date)
			,0)
		END
	ELSE
-- --------------> Parte spese
		BEGIN
			DECLARE @assured char(1)
			SELECT @assured = assured FROM upb WHERE idupb = @idupb

			INSERT INTO #tot_mov_c
			SELECT expense.nphase, 
				SUM(expenseyear.amount)
			FROM expenseyear
			JOIN expense
				ON expense.idexp = expenseyear.idexp
			JOIN finlink 
				ON finlink.idchild = expenseyear.idfin
			WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )--SUBSTRING(expenseyear.idfin, 1,@lengthidfin) = @idfin
				AND expenseyear.ayear = @ayear
				AND expenseyear.idupb = @idupb
				AND expense.adate <= @date
				AND expense.nphase >= @finphase
			GROUP BY expense.nphase

			INSERT INTO #tot_var_c
			SELECT expense.nphase, 
				SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
			JOIN expense
				ON expense.idexp = expenseyear.idexp
			JOIN finlink 
				ON finlink.idchild = expenseyear.idfin
			WHERE expensevar.yvar =	@ayear
				AND expenseyear.idupb = @idupb
				AND expensevar.adate <= @date
				and (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
				AND expenseyear.ayear = @ayear
				AND expense.nphase >= @finphase
			GROUP BY expense.nphase


	DECLARE	@tot_creditpart decimal(19,2) -- Totale assegnazione dei crediti
	DECLARE	@totcreditvar decimal(19,2) -- Totale variazione assegnazione dei crediti
	DECLARE	@totproceedspart decimal(19,2) -- Totale assegnazioni di cassa
	DECLARE	@totproceedsvar decimal(19,2) -- Totale variazioni assegnazioni di cassa
	DECLARE @totcashsurplus decimal(19,2) -- Totale ripartizione dell'avanzo di cassa

			IF (@assured <> 'S')
			BEGIN
				SELECT @tot_creditpart = SUM(creditpart.amount)
				FROM creditpart
				JOIN incomeyear
					ON creditpart.idinc = incomeyear.idinc
				JOIN finlink 
					ON finlink.idchild = incomeyear.idfin
				join fin 
					on creditpart.idfin = fin.idfin
				WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
					AND creditpart.adate <= @date
					AND incomeyear.idupb = @idupb
					AND ( (fin.flag & 1)=1)--solo per le spese
					AND fin.ayear = @ayear
					AND incomeyear.ayear = @ayear

				SELECT @totcreditvar = SUM(D.amount)
				FROM finvardetail D
				JOIN finvar V
					ON V.yvar = D.yvar
					AND V.nvar = D.nvar
				JOIN finlink FLK
					ON FLK.idchild = D.idfin
				join fin F
					on D.idfin = F.idfin
				WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					--SUBSTRING(D.idfin, 1, @lengthidfin) = @idfin
					AND V.adate <= @date
					AND V.flagcredit = 'S'
					AND D.idupb = @idupb
					AND ( (F.flag & 1)=1)--solo per le spese
					AND F.ayear = @ayear

				SELECT @totproceedspart = SUM(proceedspart.amount)
				FROM proceedspart
				JOIN incomeyear
					ON proceedspart.idinc = incomeyear.idinc
				JOIN finlink 
					ON finlink.idchild = proceedspart.idfin
				join fin 
					on proceedspart.idfin = fin.idfin
				WHERE (	(finlink.nlevel = @nlevel AND finlink.idparent = @idfin) OR (@idfin is null AND finlink.nlevel = @levelusable)   )
					AND ( (fin.flag & 1)=1)--solo per le spese
					AND fin.ayear = @ayear
					--SUBSTRING(proceedspart.idfin, 1, @lengthidfin) = @idfin
					AND proceedspart.adate <= @date
					AND incomeyear.idupb = @idupb
	
				SELECT @totcashsurplus = SUM(D.amount)
				FROM finvardetail D
				JOIN finvar V
					ON V.yvar = D.yvar
					AND V.nvar = D.nvar
				JOIN finlink FLK
					ON FLK.idchild = D.idfin
				join fin F
					on D.idfin = F.idfin
				WHERE --SUBSTRING(D.idfin, 1, @lengthidfin) = @idfin
					(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND V.adate <= @date
					AND V.flagproceeds = 'S'
					AND V.variationkind IN (2,3)
					AND D.idupb = @idupb
					AND ( (F.flag & 1)=1)--solo per le spese
					AND F.ayear = @ayear

				SELECT @totproceedsvar = SUM(D.amount)
				FROM finvardetail D
				JOIN finvar V
					ON V.yvar = D.yvar
					AND V.nvar = D.nvar
				JOIN finlink FLK
					ON FLK.idchild = D.idfin
				join fin F
					on D.idfin = F.idfin
				WHERE --SUBSTRING(d.idfin, 1, @lengthidfin) = @idfin
					(	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND ( (F.flag & 1)=1)--solo per le spese
					AND F.ayear = @ayear
					AND V.adate <= @date
					AND V.flagproceeds = 'S'
					AND V.variationkind IN (1,4)
					AND D.idupb = @idupb
			END
			ELSE
			BEGIN
				SET @tot_creditpart = 0
				SET @totcreditvar = 0
				SET @totproceedspart = 0
				SET @totcashsurplus = 0
				SET @totproceedsvar = 0
			END

			SET @totpayment = 
			ISNULL(
				(SELECT SUM(HPV.curramount)
				FROM historypaymentview HPV
				JOIN finlink FLK
					ON FLK.idchild = HPV.idfin
				WHERE HPV.ymov = @ayear
					--AND SUBSTRING(idfin,1,@lengthidfin) = @idfin 
					and (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
					AND HPV.idupb = @idupb
					AND competencydate <= @date)
			,0)
		END

	DECLARE	@totpettycashop decimal(19,2) -- Totale operazioni fondo economale

	SELECT @totpettycashop = SUM(operation.amount)
		FROM pettycashoperation operation
		JOIN finlink FLK
			ON FLK.idchild = operation.idfin 
		join fin F
			on operation.idfin = F.idfin
		WHERE (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )--SUBSTRING(operation.idfin, 1, @lengthidfin) = @idfin
			AND operation.idupb = @idupb
			AND operation.adate	<= @date
			AND F.ayear = @ayear
			AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
			WHERE restoreop.yrestore = operation.yrestore
				AND restoreop.nrestore = operation.nrestore
				AND restoreop.idpettycash = operation.idpettycash
				AND restoreop.adate <= @date)
	INSERT INTO #situation
		VALUES (@departmentname, NULL, 'H')
	INSERT INTO #situation
		VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
	INSERT INTO #situation
		VALUES (@codeupb + ' - ' + @descupb, NULL, 'H')
	INSERT INTO #situation
		VALUES (@leveldesc + ' ' + @fincode, NULL, 'H')
	INSERT INTO #situation	
		VALUES (@fintitle,	NULL, 'H')
	INSERT INTO #situation	
		VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
	INSERT INTO #situation	
		VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES('C A S S A',NULL,'N')

	DECLARE	@totcompetency decimal(19,2)
	DECLARE	@totcompetencyvar decimal(19,2)
	DECLARE	@totarrears decimal(19,2)
	DECLARE	@totarrearsvar decimal(19,2)
	DECLARE	@nphase tinyint
	DECLARE	@phasetitle varchar(50)
	DECLARE @totincome decimal(19,2)
	DECLARE @totexpense decimal(19,2)

-----------------------
-- GESTIONE DI CASSA --
-----------------------
	INSERT INTO #situation	
		VALUES ('Previsione iniziale di cassa', @mainprev, '')
	INSERT INTO #situation	
		VALUES ('Variazioni di bilancio e Storni di previsione', @tot_mainprev_var, '')
	INSERT INTO #situation	
		VALUES ('Previsione attuale di cassa', ISNULL(@currmainprev, 0), 'S')
	IF @finpart = 'S' AND 
			(EXISTS	(SELECT	* FROM creditpart 
			WHERE ycreditpart = @ayear
			AND adate <= @date) OR
			EXISTS (SELECT * FROM finvar
			WHERE yvar = @ayear
			AND flagcredit = 'S'
			AND adate <= @date))
			AND @assured <> 'S'
		BEGIN
			INSERT INTO #situation	VALUES ('Assegnazione crediti',	@tot_creditpart, '')
			INSERT INTO #situation	VALUES ('Variazioni e Storni di Crediti', @totcreditvar, '')
			INSERT INTO #situation	VALUES ('Previsione da accreditare', 
				ISNULL(@currmainprev, 0) - 
				ISNULL(@tot_creditpart, 0) - 
				ISNULL(@totcreditvar, 0),	'S')
		END
	IF @finpart = 'S' AND 
			(EXISTS	(SELECT	* FROM proceedspart
			WHERE yproceedspart	= @ayear
			AND adate <= @date) OR
			EXISTS (SELECT * FROM finvar
			WHERE yvar = @ayear
			AND flagproceeds = 'S'
			AND adate <= @date))
			AND @assured <> 'S'
		BEGIN
			INSERT INTO #situation VALUES ('Avanzo di cassa',@totcashsurplus,'')
			INSERT INTO #situation	VALUES ('Assegnazione incassi',	@totproceedspart, '')
			INSERT INTO #situation	VALUES ('Variazioni e Storni di Incassi', @totproceedsvar, '')
			INSERT INTO #situation	VALUES ('Previsione da incassare', 
				ISNULL(@currmainprev, 0) -
				ISNULL(@totcashsurplus,0) -
				ISNULL(@totproceedspart,	0) -
				ISNULL(@totproceedsvar,	0), 'S')
		END
	
	IF @finpart = 'E'
		BEGIN
			DECLARE	crs_phase1 INSENSITIVE CURSOR FOR
				SELECT nphase, description FROM incomephase
				WHERE nphase >= @finphase AND nphase IN (@finphase,@competencyphase,@lastphase) --M. Smaldino
				FOR READ ONLY
			OPEN crs_phase1
			FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
			WHILE (@@FETCH_STATUS =	0)
				BEGIN
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
---------------------------------------------------------------------------------------------------------------------------------------------
-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
-- la voce di bilancio  prendere in considerazione anche la previsione disponibile calcolata su questa fase 
---------------------------------------------------------------------------------------------------------------------------------------------
					IF (@nphase = @finphase and @finphase < @competencyphase )
					    BEGIN
						SELECT @lbl_disp_firstphase = '   Disponibilità per ulteriore ' + '"' + @phasetitle + '"'
						INSERT INTO #situation VALUES(@lbl_disp_firstphase,
							ISNULL(@currmainprev, 0) -
							ISNULL(@totcompetency, 0) -
							ISNULL(@totcompetencyvar, 0), 'S')
					    END
					ELSE
					    BEGIN
						INSERT INTO #situation VALUES('1) Movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetency,0), '')
						INSERT INTO #situation VALUES('2) Variazioni movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetencyvar,0), '')
						INSERT INTO #situation VALUES('3) Totale Movimenti ('
						+@phasetitle	+ ')',
						ISNULL(@totcompetency,0) +
						ISNULL(@totcompetencyvar,0),'')
						SELECT @lbl_dispacc = 'Disponibilità per ' + '"' + @phasetitle + '"' + ' (Prev. Attuale - 3';
				  		
						IF (@nphase = @competencyphase)
							BEGIN
								SELECT @lbl_dispacc = @lbl_dispacc + ')'
								INSERT INTO #situation	VALUES(@lbl_dispacc, 
								ISNULL(@currmainprev, 0) -
								ISNULL(@totcompetency, 0) -
								ISNULL(@totcompetencyvar, 0), 'S')
							END
						IF (@nphase = @lastphase)
							BEGIN
								SET @totincome = 
								ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @competencyphase),0) +
								ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @competencyphase),0)
								INSERT INTO #situation VALUES('Accertato da incassare',
								ISNULL(@totincome,0) -
								ISNULL(@totcompetency,0) -
								ISNULL(@totcompetencyvar,0),'S')
								INSERT INTO #situation	VALUES('Disponibilità ad incassare (Reversali)', 
								ISNULL(@currmainprev, 0) -
								ISNULL(@totcompetency, 0) -
								ISNULL(@totcompetencyvar, 0), 'S')
							END
						END
					FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
				END
			DEALLOCATE crs_phase1
			INSERT INTO #situation VALUES('',NULL,'H')

			INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
			DECLARE	crs_phase1 INSENSITIVE CURSOR FOR
				SELECT nphase, description FROM incomephase
				WHERE nphase >= @finphase
				FOR READ ONLY
			OPEN crs_phase1
			FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
			WHILE (@@FETCH_STATUS =	0)
				BEGIN
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @nextphasecomp = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
-- Calcolo della fase successiva per sottrarla a quella attuale
					IF @nphase < @lastphase
					BEGIN
						SELECT @nextphasecomp = ISNULL(amount, 0)
							FROM #tot_mov_c
							WHERE nphase = (@nphase + 1)
						SET @nextphasecomp = ISNULL(@nextphasecomp, 0) + 
							ISNULL((SELECT ISNULL(amount, 0) FROM #tot_var_c WHERE nphase = (@nphase + 1)),0)
					END
					ELSE
					BEGIN
						SET @nextphasecomp = ISNULL(@totproceeds,0)
					END
					INSERT INTO #situation VALUES('1. Totale Movimenti (' + @phasetitle +')',
						ISNULL(@totcompetency,0),'')
					INSERT INTO #situation VALUES('2. Totale Variazioni (' + @phasetitle +')',
						ISNULL(@totcompetencyvar,0),'')
					SELECT @lbl_dispcash_e = 'Previsione Disponibile di Cassa (Prev Attuale - 1 - 2)'
					
					INSERT INTO #situation VALUES(@lbl_dispcash_e,
						ISNULL(@currmainprev,0) -
						ISNULL(@totcompetency,0) -
						ISNULL(@totcompetencyvar,0)
						,'S')
					INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva in c/competenza',
						ISNULL(@totcompetency,0) + 
						ISNULL(@totcompetencyvar,0) -
						ISNULL(@nextphasecomp,0),'S')
					FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
				END
			DEALLOCATE crs_phase1
		INSERT INTO #situation	VALUES('Totale Reversali', ISNULL(@totproceeds,0), 'S')
		 END
	ELSE 
-- -------> Gestione spese CASSA
		BEGIN
			DECLARE	crs_phase1 INSENSITIVE CURSOR FOR
				SELECT nphase, description FROM expensephase
				WHERE nphase >= @finphase AND nphase IN (@finphase,@competencyphase,@lastphase)
				FOR READ ONLY
			OPEN crs_phase1
			FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
			WHILE (@@FETCH_STATUS =	0)
				BEGIN
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @totcompetency = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
---------------------------------------------------------------------------------------------------------------------------------------------
-- Se la fase corrispondente all'accertamento o impegno non coincide con la prima fase di entrata o spesa in cui è imputata
-- la voce di bilancio occorre prendere in considerazione la previsione disponibile calcolata su questa fase 
---------------------------------------------------------------------------------------------------------------------------------------------
					IF (@nphase = @finphase and @finphase < @competencyphase )
					    BEGIN
						SELECT @lbl_disp_firstphase = '   Disponibilità per ulteriore ' + '"' + @phasetitle + '"'
						INSERT INTO #situation VALUES(@lbl_disp_firstphase,
							ISNULL(@currmainprev, 0) -
							ISNULL(@totcompetency,0) -
							ISNULL(@totcompetencyvar,0) -
							ISNULL(@totpettycashop,0)
							,'S')
					    END
					ELSE
					    BEGIN
						INSERT INTO #situation VALUES('1) Movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetency,0), '')
						INSERT INTO #situation VALUES('2) Variazioni movimenti ('
						+ @phasetitle	+ ')', ISNULL(@totcompetencyvar,0), '')
						INSERT INTO #situation VALUES('3) Totale Movimenti ('
						+ @phasetitle	+ ')',
						ISNULL(@totcompetency,0) +
						ISNULL(@totcompetencyvar,0),'')
						SELECT @lbl_dispimp = 'Disponibilità per ' + '"' + @phasetitle + '"' +' (Prev. Attuale - 3'
						IF (@totpettycashop > 0)
							BEGIN
								INSERT INTO #situation	VALUES(
								'4) Totale op. fondo economale attribuite non reintegrate',@totpettycashop, '')
								SELECT @lbl_dispimp = @lbl_dispimp + ' - 4'
							END
						IF (@nphase = @competencyphase)
							BEGIN
								SELECT @lbl_dispimp = @lbl_dispimp + ')'
								INSERT INTO #situation VALUES(@lbl_dispimp,
								ISNULL(@currmainprev, 0) -
								ISNULL(@totcompetency,0) -
								ISNULL(@totcompetencyvar,0) -
								ISNULL(@totpettycashop,0)
								,'S')
								----------------------------------------------------------------------------------------------
								-- Visualizzare i crediti residui solo se le assegnazioni dei crediti E le variazioni o storni
								-- di crediti sono entrambi diversi da 0, trattandosi di un bilancio di sola cassa
								----------------------------------------------------------------------------------------------
										IF ((ISNULL(@tot_creditpart,0) + ISNULL(@totcreditvar,0)) <> 0)
										AND (@assured <> 'S')
										BEGIN
												INSERT INTO #situation VALUES('Crediti Residui',
												ISNULL(@tot_creditpart,0) +
												ISNULL(@totcreditvar,0) -
												ISNULL(@totcompetency,0) -
												ISNULL(@totcompetencyvar,0)
												,'S')
										END									

							END
						IF (@nphase = @lastphase)
							BEGIN
								SET @totexpense = 
								ISNULL((SELECT SUM(amount) FROM #tot_mov_c WHERE nphase = @competencyphase),0) +
								ISNULL((SELECT SUM(amount) FROM #tot_var_c WHERE nphase = @competencyphase),0)							
								INSERT INTO #situation VALUES('Impegnato da pagare',
								ISNULL(@totexpense,0) -
								ISNULL(@totcompetency,0) -
								ISNULL(@totcompetencyvar,0),'S')
								-----------------------------------------------------------------------------------------
								-- Visualizzare la Cassa residua a livello di impegni
								-----------------------------------------------------------------------------------------
								IF (@assured <> 'S')
								Begin
									INSERT INTO #situation	VALUES('Cassa Residua (Impegni)', 
									ISNULL(@totproceedspart,	0) + 
									ISNULL(@totcashsurplus, 0) +
									ISNULL(@totproceedsvar,	0) - 
									ISNULL(@totexpense, 0) -
									ISNULL(@totpettycashop,	0),'S')		
								End	
								-----------------------------------------------------------------------------------------
								INSERT INTO #situation VALUES('Disponibilità a pagare (Mandati)',
								ISNULL(@currmainprev, 0) -
								ISNULL(@totpayment,0) -
								ISNULL(@totpettycashop,0)
								,'S')
								IF (@assured <> 'S')
								Begin
									INSERT INTO #situation	VALUES('Cassa Residua (Mandati)', 
									ISNULL(@totproceedspart,	0) + 
									ISNULL(@totcashsurplus, 0) +
									ISNULL(@totproceedsvar,	0) - 
									ISNULL(@totpayment, 0) -
									ISNULL(@totpettycashop,	0),'S')
								End
							END
						END
					FETCH NEXT FROM	crs_phase1 INTO @nphase, @phasetitle
				END
			DEALLOCATE crs_phase1
			INSERT INTO #situation VALUES('',NULL,'H')
			INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
			DECLARE	crsphase INSENSITIVE	CURSOR FOR
				SELECT nphase, description FROM expensephase
				WHERE nphase >= @finphase
				FOR READ ONLY
			OPEN crsphase
			FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
			WHILE (@@FETCH_STATUS =	0)
				BEGIN
					SELECT @totcompetency = 0
					SELECT @totcompetencyvar = 0
					SELECT @totarrears =	0
					SELECT @totarrearsvar = 0
					SELECT @nextphasecomp = 0
					SELECT @totcompetency = ISNULL(amount, 0)
						FROM #tot_mov_c
						WHERE nphase = @nphase
					SELECT @totcompetencyvar = ISNULL(amount, 0)
						FROM #tot_var_c
						WHERE nphase = @nphase
-- Calcolo della fase successiva per sottrarla a quella attuale
					IF @nphase < @lastphase
					BEGIN
						SELECT @nextphasecomp = ISNULL(amount,0)
							FROM #tot_mov_c
							WHERE nphase = (@nphase + 1)
						SET @nextphasecomp = ISNULL(@nextphasecomp,0) + 
							ISNULL((SELECT ISNULL(amount,0) FROM #tot_var_c WHERE nphase = (@nphase + 1)),0)
					END
					ELSE
					BEGIN
						SET @nextphasecomp = ISNULL(@totpayment,0)
					END
					INSERT INTO #situation VALUES('1. Totale Movimenti (' + @phasetitle +')',
						ISNULL(@totcompetency,0),'')
					INSERT INTO #situation VALUES('2. Totale Variazioni (' + @phasetitle +')',
						ISNULL(@totcompetencyvar,0),'')
					SELECT @lbl_dispcash_s = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2'
					IF (@totpettycashop > 0)
					BEGIN
						INSERT INTO #situation VALUES('5. Totale Operazioni Fondo Economale',ISNULL(@totpettycashop,0),'')
						SELECT @lbl_dispcash_s = @lbl_dispcash_s + ' - 5'
					END
					SELECT @lbl_dispcash_s = @lbl_dispcash_s + ')'
					INSERT INTO #situation VALUES(@lbl_dispcash_s,
						ISNULL(@currmainprev,0) -
						ISNULL(@totcompetency,0) -
						ISNULL(@totcompetencyvar,0)
						,'S')
					INSERT INTO #situation VALUES('('+@phasetitle+') restanti rispetto alla fase successiva',
						ISNULL(@totcompetency,0) + 
						ISNULL(@totcompetencyvar,0) -
						ISNULL(@nextphasecomp,0),'S')
					FETCH NEXT FROM	crsphase INTO @nphase, @phasetitle
				END
			DEALLOCATE crsphase
			INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@totpayment,0),'S')
		END			

	SELECT value, amount, kind FROM #situation	
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_fin_onlycash.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_fin_onlycash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_fin_onlycash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [show_fin_onlycash]
(
	@date datetime,
	@idfin int,--varchar(31)
	@finpart char(1)
)
AS
BEGIN
/* Versione 1.0.1 del 27/11/2007 ultima modifica: MARIA */
DECLARE	@ayear int
SELECT @ayear = YEAR(@date)
-- Verifica se l'avanzo di amministrazione non è totalizzato e viene attribuito in previsione ad una voce  
-- di bilancio in entrata -- M. Smaldino
DECLARE @flagincomesurplus char(1) -- Flag indicante se l'avanzo di amministrazione Ã Â¨ attribuito in previsione ad un capitolo di entrata o no --M. Smaldino
SELECT @flagincomesurplus = 
	CASE 
		when ( idfinincomesurplus is null) then 'N'
		when ( idfinincomesurplus is not null) then 'S'
	End
	FROM config
	where ayear = @ayear

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

--DECLARE @lengthidfin int
--SELECT @lengthidfin = DATALENGTH(@idfin)

--DECLARE	@finpart char(1) -- Parte del bilancio (E = Entrata S = Spesa)
--SELECT @finpart = SUBSTRING(@idfin, 3, 1)
DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (E = Entrata S = Spesa)

if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1
/*
SELECT @finpart = 
	CASE 
		when ( (flag & 1 )=0) then 'E'
		when ( (flag & 1 )=1)then 'S'
	End
	FROM fin
	WHERE idfin = @idfin*/

DECLARE	@nphase_fin_int int
SELECT @nphase_fin_int = 1

DECLARE @levelusable tinyint --varchar(20) -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2) <>0  AND ayear = @ayear

DECLARE @nphase_ass_app char(1) -- Fase paragonabile all'accertamento o all'impegno
DECLARE	@nphase_fin char(1) -- Fase in cui viene inserita la voce di bilancio
DECLARE	@maxphase char(1) -- Fase di cassa
IF @finpart = 'E'
BEGIN
	SELECT @nphase_ass_app = assessmentphasecode FROM config WHERE ayear = @ayear
	SELECT @nphase_fin = incomefinphase FROM uniconfig
	SELECT @maxphase = MAX(nphase) FROM incomephase
	SET @nphase_fin_int = CONVERT(int, @nphase_fin)
END
ELSE
BEGIN
	SELECT @nphase_ass_app = appropriationphasecode FROM config WHERE ayear = @ayear
	SELECT @nphase_fin = expensefinphase FROM uniconfig
	SELECT @maxphase = MAX(nphase) FROM expensephase
	SET @nphase_fin_int = CONVERT(int, @nphase_fin) 
END
DECLARE	@nlevel tinyint--varchar(20) -- Livello della voce di bilancio
DECLARE	@fincode varchar(50) -- Codice di bilancio
DECLARE	@title varchar(150) -- Descrizione della voce di bilancio
SELECT  @nlevel = nlevel, 
	@fincode = codefin, 
	@title = title 
FROM fin WHERE idfin = @idfin

DECLARE	@prevision_M decimal(19,2)
IF (@nlevel < @levelusable) OR (@nlevel IS NULL)
BEGIN
-- ho scelto x es la categoria
	SELECT @prevision_M = ISNULL(SUM(prevision),0)
	FROM finyearview
	JOIN finlink
		ON finlink.idchild = finyearview.idfin
	join fin
		ON finyearview.idfin = fin.idfin
	WHERE finyearview.nlevel  = @levelusable
	and fin.ayear = @ayear
	AND (
	    (finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
		OR 
	     ( @nlevel is null AND finlink.nlevel = @levelusable)
	)
	AND finyearview.nlevel = @levelusable
	and ((fin.flag & 1 ) = @finpart_bit)

END
ELSE
BEGIN
-- ho scleto la voce operativa
	SELECT @prevision_M = SUM(prevision)
	FROM finyear
	WHERE idfin = @idfin
END
DECLARE	@var_prev_acc_M decimal(19,2)
SELECT @var_prev_acc_M = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE --SUBSTRING(FVD.idfin, 1, @lengthidfin) = @idfin
	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable))
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FVD.amount > 0

DECLARE	@var_prev_red_M decimal(19,2)
SELECT @var_prev_red_M = SUM(FVD.amount)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN finlink FLK
	ON FLK.idchild = FVD.idfin
join fin F
	ON FVD.idfin = F.idfin
WHERE --SUBSTRING(FVD.idfin, 1, @lengthidfin) = @idfin
	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable))
	and ((F.flag & 1 ) = @finpart_bit) and F.ayear = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND amount < 0

-- Calcolo delle variazioni totali sulla previsione principale date dalla somma algebrica di quelle in aumento e quelle in diminuzione
DECLARE @var_prev_M decimal(19,2)
SET @var_prev_M = ISNULL(@var_prev_acc_M,0) + ISNULL(@var_prev_red_M,0)
-- Calcolo della previsione principale attuale
DECLARE @prev_curr_M decimal(19,2)
SET @prev_curr_M = ISNULL(@prevision_M,0) + ISNULL(@var_prev_M,0)
-- Tabella dei movimenti
CREATE TABLE #mov (nphase tinyint, amount decimal(19,2))
-- Tabella delle variazioni sui movimenti
CREATE TABLE #var (nphase tinyint, amount decimal(19,2))
IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov (nphase, amount)
	SELECT M.nphase, SUM(MY.amount)--SUM(MT.amount)
	FROM incomeyear MY
	/*JOIN incometotal MT
		ON MT.idinc = MY.idinc
		AND MT.ayear = MY.ayear*/
	JOIN income M
		ON M.idinc = MY.idinc
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE --SUBSTRING(MY.idfin, 1, @lengthidfin) = @idfin
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND M.adate <= @date
		AND MY.ayear = @ayear
		AND M.nphase >= @nphase_fin
	GROUP BY M.nphase

	INSERT INTO #var (nphase, amount)
	SELECT M.nphase, SUM(MV.amount)
	FROM incomevar MV
	JOIN incomeyear MY
		ON MY.idinc = MV.idinc
	JOIN income M
		ON M.idinc = MY.idinc
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE MV.yvar = @ayear
		--AND SUBSTRING(MY.idfin, 1, @lengthidfin) = @idfin
		AND((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND MY.ayear = @ayear
		AND M.nphase >= @nphase_fin
		AND MV.adate <= @date
	GROUP BY M.nphase

	DECLARE @tot_proceeds decimal(19,2)
	SET @tot_proceeds =
	ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historyproceedsview HPV
		JOIN finlink FLK
			ON FLK.idchild = HPV.idfin
		WHERE HPV.ymov = @ayear
			--AND SUBSTRING(HPV.idfin,1,@lengthidfin) = @idfin
			AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
			AND HPV.competencydate <= @date)
	,0)
END
IF (@finpart = 'S')
BEGIN
	INSERT INTO #mov (nphase, amount)
	SELECT M.nphase, SUM(MY.amount)
	FROM expenseyear MY

	JOIN expense M
		ON M.idexp = MY.idexp
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	WHERE 	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND M.adate <= @date
		AND MY.ayear = @ayear
		AND M.nphase >= @nphase_fin
	GROUP BY M.nphase

	INSERT INTO #var (nphase, amount)
	SELECT M.nphase, SUM(MV.amount)
	FROM expensevar MV
	JOIN expenseyear MY
		ON MY.idexp = MV.idexp
	JOIN finlink FLK
		ON FLK.idchild = MY.idfin
	JOIN expense M
		ON M.idexp = MY.idexp
	WHERE MV.yvar = @ayear
		AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND MY.ayear = @ayear
		AND M.nphase >= @nphase_fin
		AND MV.adate <= @date
	GROUP BY M.nphase

	DECLARE	@tot_creditpart decimal(19,2)
	SELECT @tot_creditpart = SUM(CP.amount)
	FROM creditpart CP 
	JOIN finlink FLK	
		ON FLK.idchild = CP.idfin
	WHERE 	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND CP.adate <= @date
		AND CP.ycreditpart = @ayear

	DECLARE	@tot_var_credit decimal(19,2) -- Totale variazione assegnazione dei crediti
	SELECT @tot_var_credit = SUM(D.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK	
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE 
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND V.adate <= @date
		AND V.yvar = @ayear
		AND V.flagcredit = 'S'
		AND V.variationkind IN (1,4)
		AND ( (F.flag & 1)=1)--solo per le spese

	DECLARE @tot_proceedspart decimal(19,2) -- Totale assegnazioni di cassa
	SELECT @tot_proceedspart = SUM(P.amount)
	FROM proceedspart P  
	JOIN finlink FLK
		ON FLK.idchild = P.idfin
	WHERE --SUBSTRING(P.idfin, 1, @lengthidfin) = @idfin
		((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND P.adate <= @date
		AND P.yproceedspart = @ayear

	DECLARE @tot_ff decimal(19,2) -- Totale ripartizione dell'avanzo di cassa
	SELECT @tot_ff = SUM(d.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE 	((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND V.yvar = @ayear
		AND V.adate <= @date
		AND V.flagproceeds = 'S'
		AND V.variationkind IN (2,3)
		AND ( (F.flag & 1)=1)--solo per le spese

	DECLARE	@tot_var_proceeds decimal(19,2) -- Totale variazioni assegnazioni di cassa
	SELECT @tot_var_proceeds = SUM(D.amount)
	FROM finvardetail D
	JOIN finvar V
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar
	JOIN finlink FLK
		ON FLK.idchild = D.idfin
	join fin F
		on D.idfin = F.idfin
	WHERE  ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
		AND V.yvar = @ayear
		AND V.adate <= @date
		AND V.flagproceeds = 'S'
		AND V.variationkind IN (1,4)
		AND ( (F.flag & 1)=1)--solo per le spese


	DECLARE @tot_payment decimal(19,2)
	SET @tot_payment = 
	ISNULL(
		(SELECT SUM(HPV.curramount)
		FROM historypaymentview HPV
		JOIN finlink FLK
			ON FLK.idchild = HPV.idfin
		WHERE HPV.ymov = @ayear
			--AND SUBSTRING(HPV.idfin,1,@lengthidfin) = @idfin
			AND ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))
			AND HPV.competencydate <= @date)
	,0)
END
DECLARE	@tot_pettycashop decimal(19,2)
SELECT @tot_pettycashop = SUM(exp_op.amount)
FROM pettycashoperation exp_op  
JOIN finlink FLK
	ON FLK.idchild = exp_op.idfin
WHERE ((FLK.nlevel = @nlevel AND FLK.idparent = @idfin ) or (@idfin is null AND FLK.nlevel = @levelusable))	 --SUBSTRING(exp_op.idfin, 1, @lengthidfin) = @idfin
	AND exp_op.adate <= @date    
	AND exp_op.yoperation = @ayear
	AND NOT	EXISTS
		(SELECT * FROM pettycashoperation restore_op
		WHERE restore_op.yoperation = exp_op.yrestore
			AND restore_op.noperation = exp_op.nrestore
			AND restore_op.idpettycash = exp_op.idpettycash
			AND restore_op.adate <= @date)

DECLARE	@departmentname varchar(150)
SELECT  @departmentname = isnull(paramvalue,'Manca Cfg. Parametri Tutte le stampe') from
	generalreportparameter where idparam='DenominazioneDipartimento'

INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
DECLARE	@desc_level varchar(50)
SELECT @desc_level = description 
FROM finlevel 
WHERE ayear = @ayear
	AND nlevel = @nlevel
INSERT INTO #situation VALUES (@desc_level + ' ' + @fincode, NULL, 'H')
INSERT INTO #situation VALUES (@title,	NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES('C A S S A',NULL,'N')
INSERT INTO #situation VALUES ('Previsione iniziale di cassa', @prevision_M, '')
INSERT INTO #situation VALUES ('Variazioni di bilancio e Storni di previsione', @var_prev_M, '')
--IF @finpart = 'E' AND @lengthidfin = 3 AND @flagincomesurplus = 'N' 
IF (@finpart = 'E' AND @nlevel = 1 AND @flagincomesurplus = 'N')-- Significa che stiamo sul titolo
-- Se l'avanzo di cassa viene attribuito in previsione ad una voce  
-- di bilancio in entrata non deve essere totalizzato M. Smaldino
BEGIN
	DECLARE @floatfund decimal(19,2) -- Avanzo di Cassa
	SELECT @floatfund = ISNULL(floatfund,0) FROM finsurplusview WHERE ayear = @ayear
	INSERT INTO #situation VALUES ('Avanzo di Cassa Totale',@floatfund,'')
	-- Ricalcolo della previsione attuale dove sommo anche l'avanzo di cassa
	SET @prev_curr_M = ISNULL(@prev_curr_M, 0) + ISNULL(@floatfund,0)
END
INSERT INTO #situation VALUES ('Previsione attuale di cassa', ISNULL(@prev_curr_M, 0), 'S')
IF @finpart = 'S'
	AND (EXISTS
		(SELECT * FROM creditpart 
		WHERE ycreditpart = @ayear
		AND adate <= @date)
	OR EXISTS
		(SELECT * FROM finvar
		WHERE yvar = @ayear
		AND flagcredit = 'S'
		AND adate <= @date))
BEGIN
	INSERT INTO #situation	VALUES ('Assegnazione crediti',	@tot_creditpart, '')
	INSERT INTO #situation	VALUES ('Variazioni e Storni di Crediti', @tot_var_credit, '')
	DECLARE @prev_to_credit decimal(19,2)
	SET @prev_to_credit = 
		ISNULL(@prev_curr_M, 0) -
		ISNULL(@tot_creditpart, 0) - 
		ISNULL(@tot_var_credit, 0)
	INSERT INTO #situation	VALUES ('Previsione da accreditare', @prev_to_credit,'S')
END
IF @finpart = 'S'
	AND (EXISTS
		(SELECT	* FROM proceedspart
		WHERE yproceedspart = @ayear
			AND adate <= @date)
	OR EXISTS
		(SELECT * FROM finvar
		WHERE yvar = @ayear
		AND flagproceeds = 'S'
		AND adate <= @date))
BEGIN
	INSERT INTO #situation VALUES ('Avanzo di cassa', @tot_ff,'')
	INSERT INTO #situation VALUES ('Assegnazione incassi',	@tot_proceedspart, '')
	INSERT INTO #situation VALUES ('Variazioni e Storni di Incassi', @tot_var_proceeds, '')
	DECLARE @prev_to_proceed decimal(19,2)
	SET @prev_to_proceed = 
		ISNULL(@prev_curr_M, 0) -
		ISNULL(@tot_ff, 0) -
		ISNULL(@tot_proceedspart, 0) -
		ISNULL(@tot_var_proceeds, 0)
	INSERT INTO #situation VALUES ('Previsione da incassare', @prev_to_proceed, 'S')
END
DECLARE @tot_mov decimal(19,2)
DECLARE @tot_var decimal(19,2)
DECLARE	@nphase tinyint
DECLARE	@desc_phase varchar(50)
DECLARE @lbl_avail_ass varchar(150) -- Etichetta sulla disponibilità ad accertate
DECLARE @lbl_avail_app varchar(150) -- Etichetta sulla disponibilità ad impegnare
DECLARE @next_phase decimal(19,2) -- Calcolo della fase successiva in c/competenza
IF @finpart = 'E'
BEGIN
	DECLARE	phase_crs1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs1
	FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov = 0
		SET @tot_var = 0
		SET @tot_mov = ISNULL((SELECT amount FROM #mov WHERE nphase = @nphase),0)
		INSERT INTO #situation	VALUES('1) Movimenti (' + @desc_phase + ')', @tot_mov, '')
		SET @tot_var = ISNULL((SELECT amount FROM #var WHERE nphase = @nphase),0)
		INSERT INTO #situation	VALUES('2) Variazioni movimenti ('+ @desc_phase	+ ')', @tot_var, '')
		INSERT INTO #situation VALUES('3) Totale Movimenti (' + @desc_phase + ')',
			ISNULL(@tot_mov,0) + ISNULL(@tot_var,0),'')
		SELECT @lbl_avail_ass = 'Disponibilità per ' + '"' + @desc_phase + '"'+' (Prev. Attuale - 3'
		IF (@nphase = @nphase_ass_app)
		BEGIN
			SELECT @lbl_avail_ass = @lbl_avail_ass + ')'
			INSERT INTO #situation	VALUES(@lbl_avail_ass, 
				ISNULL(@prev_curr_M, 0) -
				ISNULL(@tot_mov, 0) -
				ISNULL(@tot_var, 0), 'S')
		END
		IF (@nphase = @maxphase)
		BEGIN
			DECLARE @tot_assessment decimal(19,2)
			SET @tot_assessment = 
				ISNULL((SELECT SUM(amount) FROM #mov WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #var WHERE nphase = @nphase_ass_app),0) 
			INSERT INTO #situation VALUES('Accertato da incassare',
				ISNULL(@tot_assessment,0) -
				ISNULL(@tot_mov,0) - ISNULL(@tot_var,0),'S')
			INSERT INTO #situation	VALUES('Disponibilità ad incassare (Reversali)', 
			ISNULL(@prev_curr_M, 0) - ISNULL(@tot_proceeds,0), 'S')
		END
		FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	END
	CLOSE phase_crs1
	DEALLOCATE phase_crs1
	INSERT INTO #situation VALUES('',NULL,'H')
	
	INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
	DECLARE	phase_crs1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM incomephase
	WHERE nphase >= @nphase_fin
	FOR READ ONLY
	OPEN phase_crs1
	FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov = ISNULL((SELECT amount FROM #mov WHERE nphase = @nphase),0)
		SET @tot_var = ISNULL((SELECT amount FROM #var WHERE nphase = @nphase),0)
		-- Calcolo della fase successiva per sottrarla a quella attuale
		IF @nphase < @maxphase
		BEGIN
			SELECT @next_phase = ISNULL(amount,0) FROM #mov WHERE nphase = (@nphase + 1)
			SET @next_phase = ISNULL(@next_phase,0) + 
				ISNULL((SELECT ISNULL(amount,0) FROM #var WHERE nphase = (@nphase + 1)),0)
			END
		ELSE
		BEGIN
			SET @next_phase = ISNULL(@tot_proceeds,0)
		END
		INSERT INTO #situation VALUES('1. Totale Movimenti (' + @desc_phase +')', ISNULL(@tot_mov,0),'')
		INSERT INTO #situation VALUES('2. Totale Variazioni (' + @desc_phase +')', ISNULL(@tot_var,0),'')
		DECLARE @lbl_avail_S_inc varchar(150) -- Etichetta sulla prev. disponibile di cassa
		SELECT @lbl_avail_S_inc = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2)'
		INSERT INTO #situation VALUES(@lbl_avail_S_inc,
			ISNULL(@prev_curr_M,0) -
			ISNULL(@tot_mov,0) -
			ISNULL(@tot_var,0) ,'S')
		INSERT INTO #situation VALUES('('+@desc_phase+') restanti rispetto alla fase successiva in c/competenza',
			ISNULL(@tot_mov,0) + ISNULL(@tot_var,0) - ISNULL(@next_phase,0),'S')
	
		FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	END
	CLOSE phase_crs1
	DEALLOCATE phase_crs1
	INSERT INTO #situation	VALUES('Totale Reversali', ISNULL(@tot_proceeds,0), 'S')
END
IF (@finpart = 'S')
BEGIN
	DECLARE	phase_crs1 INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase
	WHERE nphase >= @nphase_fin
		AND nphase IN (@nphase_ass_app,@maxphase)
	FOR READ ONLY
	OPEN phase_crs1
	FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov = ISNULL((SELECT amount FROM #mov WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('1) Movimenti (' + @desc_phase + ')', @tot_mov, '')
		SET @tot_var = ISNULL((SELECT amount FROM #var WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('2) Variazioni movimenti (' + @desc_phase + ')', @tot_var, '')
		INSERT INTO #situation VALUES('3) Totale Movimenti (' + @desc_phase + ')',
			ISNULL(@tot_mov,0) + ISNULL(@tot_var,0),'')
		SELECT @lbl_avail_app = 'Disponibilità per ' + '"' + @desc_phase + '"' + ' (Prev. Attuale - 3'
		IF (@tot_pettycashop > 0)
		BEGIN
			INSERT INTO #situation	VALUES(
			'4) Totale op. fondo economale attribuite non reintegrate',@tot_pettycashop, '')
			SELECT @lbl_avail_app = @lbl_avail_app + ' - 4'
		END
		IF (@nphase = @nphase_ass_app)
		BEGIN
			SELECT @lbl_avail_app = @lbl_avail_app + ')'
			INSERT INTO #situation VALUES(@lbl_avail_app,
				ISNULL(@prev_curr_M, 0) -
				ISNULL(@tot_mov,0) -
				ISNULL(@tot_var,0) -
				ISNULL(@tot_pettycashop,0) ,'S')
			--IF (ISNULL(@tot_proceedspart,0) + ISNULL(@tot_var_proceeds,0)) <> 0
			IF (EXISTS
				(SELECT * FROM creditpart 
				WHERE ycreditpart = @ayear
				AND adate <= @date)
			OR EXISTS
				(SELECT * FROM finvar
				WHERE yvar = @ayear
				AND flagcredit = 'S'
				AND adate <= @date))
			BEGIN
			INSERT INTO #situation VALUES('Crediti Residui',
				ISNULL(@tot_proceedspart,0) +
				ISNULL(@tot_var_proceeds,0) -
				ISNULL(@tot_mov,0) -
				ISNULL(@tot_var,0) ,'S')
			END
		END
		IF (@nphase = @maxphase)
		BEGIN
			INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@tot_payment,0),'S')
			
			DECLARE @tot_appropriation decimal(19,2)
			SET @tot_appropriation = 
				ISNULL((SELECT SUM(amount) FROM #mov WHERE nphase = @nphase_ass_app),0) +
				ISNULL((SELECT SUM(amount) FROM #var WHERE nphase = @nphase_ass_app),0)
		
			INSERT INTO #situation VALUES('Impegnato da pagare',
				ISNULL(@tot_appropriation,0) -
				ISNULL(@tot_mov,0) -
				ISNULL(@tot_var,0),'S')
	
			/*INSERT INTO #situation	VALUES('Cassa Residua (Impegni)', 
				ISNULL(@tot_proceedspart, 0) + 
				ISNULL(@tot_ff, 0) +
				ISNULL(@tot_var_proceeds, 0) - 
				ISNULL(@tot_appropriation, 0) -
				ISNULL(@tot_pettycashop, 0),'S')*/
			
			IF ISNULL(@tot_pettycashop,0)>0 
			BEGIN
				INSERT INTO #situation VALUES('Disponibilità a pagare (Prev. Attuale - Mandati - Tot. op. fondo economale attribuite non reintegrate)',
				ISNULL(@prev_curr_M, 0) - ISNULL(@tot_payment,0) - ISNULL(@tot_pettycashop,0) ,'S')
			END
			ELSE
			BEGIN
				INSERT INTO #situation VALUES('Disponibilità a pagare (Prev. Attuale - Mandati)',
				ISNULL(@prev_curr_M, 0) - ISNULL(@tot_payment,0) ,'S')
			END
			
			INSERT INTO #situation VALUES('Cassa Residua (Mandati)', 
				ISNULL(@tot_proceedspart, 0) + 
				ISNULL(@tot_ff, 0) +
				ISNULL(@tot_var_proceeds, 0) - 
				ISNULL(@tot_payment, 0) -
				ISNULL(@tot_pettycashop, 0) ,'S')
		END
		FETCH NEXT FROM	phase_crs1 INTO @nphase, @desc_phase
	END
	CLOSE phase_crs1
	DEALLOCATE phase_crs1
	INSERT INTO #situation VALUES('',NULL,'H')
	INSERT INTO #situation VALUES('R I E P I L O G O  F A S I  F I N A N Z I A R I E',NULL,'N')
	DECLARE	phase_crs INSENSITIVE CURSOR FOR
	SELECT nphase, description FROM expensephase WHERE nphase >= @nphase_fin
	FOR READ ONLY
	OPEN phase_crs
	FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	WHILE (@@FETCH_STATUS =	0)
	BEGIN
		SET @tot_mov = ISNULL((SELECT amount FROM #mov WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('1. Totale Movimenti (' + @desc_phase +')',
			ISNULL(@tot_mov,0),'')
		SET @tot_var = ISNULL((SELECT amount FROM #var WHERE nphase = @nphase),0)
		INSERT INTO #situation VALUES('2. Totale Variazioni (' + @desc_phase +')',
			ISNULL(@tot_var,0),'')
		-- Calcolo della fase successiva per sottrarla a quella attuale
		IF @nphase < @maxphase
		BEGIN
			SELECT @next_phase = ISNULL(amount,0)
				FROM #mov
				WHERE nphase = (@nphase + 1)
			SET @next_phase = ISNULL(@next_phase,0) + 
				ISNULL((SELECT ISNULL(amount,0) FROM #var WHERE nphase = (@nphase + 1)),0)
	
		END
		ELSE
		BEGIN
			SET @next_phase = ISNULL(@tot_payment,0)
		END
		DECLARE @lbl_avail_S_exp varchar(150) -- Etichetta sulla prev. disponibile di cassa
		SELECT @lbl_avail_S_exp = 'Previsione Disponibile di Cassa (Prev. Attuale - 1 - 2'
		IF (@tot_pettycashop > 0)
		BEGIN
			INSERT INTO #situation VALUES('3. Totale Op. Fondo Economale',ISNULL(@tot_pettycashop,0),'')
			SELECT @lbl_avail_S_exp = @lbl_avail_S_exp + ' - 3'
		END
		SELECT @lbl_avail_S_exp = @lbl_avail_S_exp + ')'
		INSERT INTO #situation VALUES(@lbl_avail_S_exp,
			ISNULL(@prev_curr_M,0) -
			ISNULL(@tot_mov,0) -
			ISNULL(@tot_var,0) -
			ISNULL(@tot_pettycashop,0) ,'S')
		INSERT INTO #situation VALUES('('+@desc_phase+') restanti rispetto alla fase successiva',
			ISNULL(@tot_mov,0) + 
			ISNULL(@tot_var,0) -
			ISNULL(@next_phase,0),'S')
		FETCH NEXT FROM	phase_crs INTO @nphase, @desc_phase
	END
	CLOSE phase_crs
	DEALLOCATE phase_crs
	--INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@tot_payment,0),'S')
END
SELECT value, amount, kind FROM #situation	
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_itineration.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_itineration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_itineration]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE         PROCEDURE [show_itineration]
@nitineration int,
@yitineration int,
@date datetime,
@ayear int

AS
BEGIN
DECLARE	@departmentname varchar(150)
SELECT  @departmentname = isnull(paramvalue,'Manca Cfg. Parametri Tutte le stampe') from
	generalreportparameter where idparam='DenominazioneDipartimento'

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation VALUES ('Missione ' + CONVERT(char(4), @yitineration) + 
	' ' + CONVERT(char(6), @nitineration), NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')

DECLARE @amount decimal(19,2)
DECLARE @totadvance decimal(19,2)

SELECT  @amount = totalgross,
	@totadvance = totadvance 
FROM itineration
WHERE yitineration = @yitineration
	AND nitineration = @nitineration

DECLARE @employtax decimal(19,2)
DECLARE @admintax decimal(19,2)

DECLARE @iditineration int
SELECT @iditineration  = iditineration 
FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration
SELECT @employtax = SUM(employtax),
	@admintax = SUM(admintax)
FROM itinerationtax
WHERE iditineration = @iditineration

INSERT INTO #situation VALUES ('Importo lordo missione', @amount, '')
INSERT INTO #situation VALUES ('Ritenute a carico del percipiente', @employtax, '')
INSERT INTO #situation VALUES ('Importo netto missione', 
	ISNULL(@amount, 0) - ISNULL(@employtax, 0), 'S')
INSERT INTO #situation VALUES ('Importo lordo missione', @amount, '')
INSERT INTO #situation VALUES ('Contributi a carico dell''ente', @admintax, '')
INSERT INTO #situation VALUES ('Importo globale missione', 
	ISNULL(@amount, 0) + ISNULL(@admintax, 0), 'S')
		
DECLARE @expensephase tinyint
SELECT @expensephase = (SELECT expensephase FROM config WHERE ayear = @ayear)


CREATE TABLE #mov_itinerationphase
(
	yitineration int,	
	nitineration int,			
	idexp int,
	nphase tinyint,
	phase varchar(50),
	movkind	char(5),
	ayear int
)

INSERT INTO #mov_itinerationphase
(	
	yitineration,
	nitineration,
	idexp,
	nphase,
	phase,
	movkind,
	ayear
)
SELECT 	
	yitineration,
	nitineration,
	idexp,
	nphase,
	phase,
	movkind,
	ayear
FROM  expenseitinerationview
WHERE iditineration = @iditineration and nphase = @expensephase


DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM expensephase

DELETE FROM #mov_itinerationphase
WHERE ayear > (SELECT min(ayear) FROM #mov_itinerationphase m2 WHERE #mov_itinerationphase.idexp = m2.idexp)

DECLARE @phase_int int
SELECT @phase_int = 0
DECLARE @mov_exp_previous decimal(19,2)
	
WHILE (@expensephase + @phase_int) <= @maxphase 
BEGIN
			
	SELECT @mov_exp_previous = SUM(EY_starting.amount) 
	FROM expense E 
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov < @ayear
		AND E.adate <= @date
		AND E.nphase = @expensephase + @phase_int
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)

	DECLARE @mov_exp decimal(19,2)		
	SELECT @mov_exp = SUM(EY_starting.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND E.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)
	DECLARE @var_exp_previous decimal(19,2)
	SELECT @var_exp_previous = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov < @ayear
		AND EV.adate <= @date
		AND E.nphase = @expensephase + @phase_int
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)
	DECLARE @var_exp decimal(19,2)			
	SELECT @var_exp = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND EV.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)

	DECLARE @phase_int1 int
	SELECT @phase_int1 = (@expensephase+ @phase_int)

	DECLARE @phase varchar(50)
	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = @phase_int1

	INSERT INTO #situation VALUES ('Importo lordo missione', @amount, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. precedenti', @mov_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. corrente', @mov_exp, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. precedenti', @var_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. corrente', @var_exp, '')
	INSERT INTO #situation VALUES ('Importo lordo missione disponibile (' + @phase + ') ', 
		ISNULL(@amount, 0) - 
		    	ISNULL(@mov_exp, 0) - 
		ISNULL(@mov_exp_previous, 0) -
		ISNULL(@var_exp_previous, 0) - 
		ISNULL(@var_exp, 0), 'S')
	SELECT @phase_int = @phase_int + 1
END
		
INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES ('Importo anticipo missione', @totadvance, 'S')
		
SELECT @phase_int = 0
WHILE (CONVERT(int,@expensephase) + @phase_int) <= @maxphase
BEGIN
	SELECT @mov_exp_previous = SUM(EY_starting.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov < @ayear
		AND E.nphase = @expensephase + @phase_int
		AND E.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6,5)

	SELECT @mov_exp = SUM(EY_starting.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND E.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6,5)
	
	SELECT @var_exp_previous = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov < @ayear
		AND E.nphase = @expensephase + @phase_int
		AND EV.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 5)
	
	SELECT @var_exp = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase 
		ON #mov_itinerationphase.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND EV.adate <= @date
		AND #mov_itinerationphase.yitineration = @yitineration
		AND #mov_itinerationphase.nitineration = @nitineration
		AND #mov_itinerationphase.movkind IN (6,5)

	SELECT @phase_int1 = (CONVERT(int,@expensephase) + @phase_int)

	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = CONVERT(char(1), @phase_int1)

	INSERT INTO #situation VALUES ('Importo anticipo missione', @totadvance, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. precedenti', @mov_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. corrente', @mov_exp, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. precedenti', @var_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. corrente', @var_exp, '')
	INSERT INTO #situation VALUES ('Importo anticipo missione disponibile (' + @phase + ') ', 
		ISNULL(@totadvance, 0) - 
		ISNULL(@mov_exp, 0) - 
		ISNULL(@mov_exp_previous, 0) -
		ISNULL(@var_exp_previous, 0) - 
		ISNULL(@var_exp, 0), 'S')
	SELECT @phase_int = @phase_int + 1
END
		
SELECT value, amount, kind FROM #situation
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_upbannual.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_upbannual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_upbannual]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE            PROCEDURE [show_upbannual]
	@date datetime,
	@idupb varchar(36)
	AS
	BEGIN
		DECLARE @fin_kind tinyint
		DECLARE @ayear int
		SELECT  @ayear = YEAR(@date)
		SELECT  @fin_kind = fin_kind
		FROM config
		WHERE ayear = @ayear
		IF (@fin_kind = 1)
			EXEC show_upbannual_comp @date,@idupb
		IF (@fin_kind = 3)
			EXEC show_upbannual_compcash @date,@idupb
		IF (@fin_kind = 2)
			EXEC show_upbannual_onlycash @date,@idupb
	END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




--File C:\Documents and Settings\m.smaldino\Desktop\sp scaglione 6\show_upbannual_onlycash.sql

if exists (select * from dbo.sysobjects where id = object_id(N'[show_upbannual_onlycash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_upbannual_onlycash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE    PROCEDURE [show_upbannual_onlycash]
	@date datetime,
	@idupb varchar(36)
AS BEGIN


	DECLARE @ayear int
	SELECT @ayear = YEAR(@date)

	CREATE TABLE #situation (value varchar(250), amount decimal(19,2),kind char(1))
	
	DECLARE @revenuephase int
	SELECT @revenuephase = 1
	DECLARE @finincomephase tinyint
	SELECT @revenuephase = incomefinphase, @finincomephase = incomefinphase FROM uniconfig

	DECLARE @arrearphase int
	SELECT @arrearphase = 1

	DECLARE @finexpensephase tinyint
	SELECT @arrearphase = expensefinphase, @finexpensephase = expensefinphase FROM uniconfig

	DECLARE @departmentname	varchar(150)
	SELECT 	@departmentname = isnull(paramvalue,'Manca Cfg. Parametri Tutte le stampe') from
					generalreportparameter where idparam='DenominazioneDipartimento'
	
	DECLARE @usablelevel tinyint --varchar(20)
	SELECT @usablelevel = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear
	
	DECLARE @codeupb varchar(50)
	DECLARE @assured char(1)
	DECLARE @fintitle varchar(150)
	SELECT  @codeupb = codeupb, @fintitle = title, @assured = assured FROM upb WHERE idupb = @idupb
	
	DECLARE @maxincomephase tinyint
	SELECT  @maxincomephase = MAX(nphase) FROM incomephase

	DECLARE @maxexpensephase tinyint
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase
		
	DECLARE @totalincomeprevision decimal(19,2)
	SELECT  @totalincomeprevision = SUM(prevision) FROM finyearview
		WHERE idupb = @idupb AND finpart='E' AND nlevel = @usablelevel AND ayear = @ayear
	
	DECLARE @totalexpenseprevision decimal(19,2)
	SELECT @totalexpenseprevision = SUM(prevision)	FROM finyearview
		WHERE idupb = @idupb AND finpart='S' AND nlevel = @usablelevel AND ayear = @ayear
	
	DECLARE @totalincomeprevisionvar decimal(19,2)
	SELECT @totalincomeprevisionvar = SUM(d.amount)
	FROM finvar v
	JOIN finvardetail d	
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN fin f
		ON f.idfin = d.idfin 
	WHERE d.idupb = @idupb
		AND v.adate <= @date
		AND v.flagprevision = 'S'
		AND ((f.flag & 1) = 0 )--AND SUBSTRING(d.idfin,3,1) = 'E'
		AND v.yvar = @ayear

	DECLARE @totalexpenseprevisionvar decimal(19,2)	
	SELECT @totalexpenseprevisionvar = SUM(d.amount)
	FROM finvar v
	JOIN finvardetail d
		ON v.yvar = d.yvar
		AND v.nvar = d.nvar
	JOIN fin f
		ON f.idfin = d.idfin 
	WHERE d.idupb = @idupb
		AND v.adate <= @date
		AND v.flagprevision = 'S'
		AND ((f.flag & 1) = 1 )--AND SUBSTRING(d.idfin,3,1) = 'S'
		AND v.yvar = @ayear
	
	DECLARE @totalproceedsvar decimal(19,2)
	DECLARE @totalproceedspart decimal(19,2)
	IF (@assured <> 'S')
	BEGIN
		SELECT @totalproceedsvar = SUM(d.amount)
		FROM finvar v
		JOIN finvardetail d
			ON v.yvar = d.yvar
			AND v.nvar = d.nvar
		WHERE d.idupb = @idupb
			AND v.adate <= @date
			AND v.flagproceeds = 'S'
			AND d.yvar = @ayear
		
		SELECT @totalproceedspart = SUM(p.amount)
		FROM proceedspart p
		JOIN incomeyear i
			ON p.idinc = i.idinc
			AND p.yproceedspart = i.ayear
		WHERE i.idupb = @idupb
			AND p.adate <= @date
			AND p.yproceedspart = @ayear
	END
	ELSE
	BEGIN
		SET @totalproceedsvar = 0
		SET @totalproceedspart = 0
	END


	CREATE TABLE #competency_income	(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_income
		SELECT income.nphase, 
			SUM(incomeyear.amount)
		FROM incomeyear
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 0) -->'C'
			AND income.nphase >= @finincomephase
			AND income.adate <= @date
		GROUP BY income.nphase
	
	CREATE TABLE #competency_expense(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_expense
		SELECT expense.nphase, 
			SUM(expenseyear.amount)
		FROM expenseyear
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 0) -->'C'
			AND expense.nphase >= @finexpensephase
			AND expense.adate <= @date
		GROUP BY expense.nphase
				
	-- Totale mandati in c/competenza
	DECLARE @totpayment_c decimal(19,2)
	SET @totpayment_c =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historypaymentview HPV
		WHERE ((HPV.totflag & 1) = 0) -->'C'
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	-- Totale mandati in c/residuo
	DECLARE @totpayment_r decimal(19,2)
	SET @totpayment_r =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historypaymentview HPV
		WHERE ((HPV.totflag & 1) = 1) -->'R'
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	-- Totale reversali emesse in c/competenza
	DECLARE @totproceeds_c decimal(19,2)
	SET @totproceeds_c =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historyproceedsview HPV
		WHERE ((HPV.totflag & 1) = 0) -->'C'
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	-- Totale reversali emesse in c/residuo
	DECLARE @totproceeds_r decimal(19,2)
	SET @totproceeds_r =
	ISNULL(
		(SELECT SUM(curramount)
		FROM historyproceedsview HPV
		WHERE ((HPV.totflag & 1) = 1) -->'R'
			AND idupb = @idupb
			AND competencydate <= @date
			AND ymov = @ayear)
	,0)

	CREATE TABLE #arrear_income(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_income
		SELECT income.nphase, 
		SUM(incomeyear.amount)
		FROM incomeyear
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 1) -->'R'
			AND income.nphase >= @finincomephase
			AND income.adate <= @date
		GROUP BY income.nphase
	
	CREATE TABLE #arrear_expense(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_expense
		SELECT expense.nphase, 
		SUM(expenseyear.amount)
		FROM expenseyear
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 1) -->'R'
			AND expense.nphase >= @finexpensephase
			AND expense.adate <= @date
		GROUP BY expense.nphase
	
	CREATE TABLE #competency_incomevar(	nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_incomevar
		SELECT income.nphase, 
			SUM(incomevar.amount)
		FROM incomevar
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomevar.yvar = @ayear
			AND incomevar.adate <= @date
			AND incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 0) -->'c'
			AND income.nphase >= @finincomephase
		GROUP BY income.nphase
	
	CREATE TABLE #competency_expensevar(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #competency_expensevar
		SELECT expense.nphase, 
			SUM(expensevar.amount)
		FROM expensevar
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expensevar.yvar = @ayear
			AND expensevar.adate <= @date
			AND expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 0) -->'c'
			AND expense.nphase >= @finexpensephase
		GROUP BY expense.nphase
	
	CREATE TABLE #arrear_incomevar(	nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_incomevar
		SELECT income.nphase, 
			SUM(incomevar.amount)
		FROM incomevar
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
		JOIN incometotal
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN income
			ON income.idinc = incomeyear.idinc
		WHERE incomevar.yvar = @ayear
			AND incomevar.adate <= @date
			AND incomeyear.idupb = @idupb
			AND incomeyear.ayear = @ayear
			AND ((incometotal.flag & 1) = 1) -->'r'
			AND income.nphase >= @finincomephase
		GROUP BY income.nphase
	
	CREATE TABLE #arrear_expensevar(nphase tinyint NULL,total decimal(19,2) NULL)
	INSERT INTO #arrear_expensevar
		SELECT expense.nphase, 
			SUM(expensevar.amount)
		FROM expensevar
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN expense
			ON expense.idexp = expenseyear.idexp
		WHERE expensevar.yvar = @ayear
			AND expensevar.adate <= @date
			AND expenseyear.idupb = @idupb
			AND expenseyear.ayear = @ayear
			AND ((expensetotal.flag & 1) = 1) -->'r'
			AND expense.nphase >= @finexpensephase
		GROUP BY expense.nphase


	DECLARE @totpettycashop decimal(19,2)
	SELECT @totpettycashop = SUM(operation.amount)
		FROM pettycashoperation operation
		WHERE operation.idupb = @idupb
		and operation.yoperation = @ayear
		AND operation.adate <= @date
		AND NOT EXISTS
			(SELECT * FROM pettycashoperation restoreop
			WHERE restoreop.yrestore = operation.yrestore
				AND restoreop.nrestore = operation.nrestore
				AND restoreop.idpettycash = operation.idpettycash
				AND restoreop.adate <= @date)

	DECLARE @competency_tot decimal(19,2)
	DECLARE @competency_totvar decimal(19,2)
	DECLARE @arrears_tot decimal(19,2)
	DECLARE @arrears_totvar decimal(19,2)
	DECLARE @nphase tinyint
	DECLARE @phasedescription varchar(50)
	
	INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
	INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
	INSERT INTO #situation VALUES (@codeupb + ' - ' + @fintitle, NULL, 'H')
	INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
	INSERT INTO #situation VALUES ('', NULL, 'N')
	INSERT INTO #situation VALUES('E N T R A T A  ',NULL,'N')
--Movimenti entrata
	INSERT INTO #situation VALUES ('Previsione iniziale', @totalincomeprevision, '')
	INSERT INTO #situation VALUES ('Variazioni', @totalincomeprevisionvar, '')
	INSERT INTO #situation VALUES ('Previsione Attuale',
		ISNULL(@totalincomeprevision,0) +
		ISNULL(@totalincomeprevisionvar,0)
		,'S')
	DECLARE crs_income INSENSITIVE CURSOR FOR
		SELECT nphase, description FROM incomephase
		WHERE nphase >= @finincomephase
		FOR READ ONLY
	OPEN crs_income
	FETCH NEXT FROM crs_income INTO @nphase, @phasedescription
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT @competency_tot = 0
		SELECT @arrears_tot = 0
		SELECT @competency_totvar = 0
		SELECT @arrears_totvar = 0
		SELECT @competency_tot = ISNULL(total, 0)
			FROM #competency_income
			WHERE nphase = @nphase
		SELECT @competency_totvar = ISNULL(total, 0)
			FROM #competency_incomevar
			WHERE nphase = @nphase
		SELECT @arrears_tot = ISNULL(total, 0)
			FROM #arrear_income
			WHERE nphase = @nphase
		SELECT @arrears_totvar = ISNULL(total, 0)
			FROM #arrear_incomevar
			WHERE nphase = @nphase
		INSERT INTO #situation VALUES(@phasedescription + ' ',
			ISNULL(@competency_tot, 0) +
			ISNULL(@arrears_tot, 0), '')
		INSERT INTO #situation VALUES('Variazioni ' + @phasedescription + ' ',
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_totvar, 0), '')
		INSERT INTO #situation VALUES('Totale ' + @phasedescription + ' ', 
			ISNULL(@competency_tot, 0) +
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_tot, 0) +
			ISNULL(@arrears_totvar, 0), 'S')

		INSERT INTO #situation VALUES('Previsione Disponibile per ' + '"' + @phasedescription + '"',--'Previsione disponibile', 
			ISNULL(@totalincomeprevision, 0) +
			ISNULL(@totalincomeprevisionvar, 0) - 
			ISNULL(@competency_tot, 0) -
			ISNULL(@competency_totvar, 0) -
			ISNULL(@arrears_tot, 0) -
			ISNULL(@arrears_totvar, 0), 'S')
		FETCH NEXT FROM crs_income INTO @nphase, @phasedescription
	END
	DEALLOCATE crs_income
	INSERT INTO #situation VALUES ('Reversali emesse ',
		ISNULL(@totproceeds_c,0) +
		ISNULL(@totproceeds_r, 0), 'S')
		
	INSERT INTO #situation VALUES('',NULL,'H')
	INSERT INTO #situation VALUES('S P E S A ',NULL,'N')
-- Movimenti Spesa
	INSERT INTO #situation VALUES ('Previsione Iniziale', @totalexpenseprevision, '')
	INSERT INTO #situation VALUES ('Variazioni', @totalexpenseprevisionvar, '')
	INSERT INTO #situation VALUES ('Previsione Attuale',
		ISNULL(@totalexpenseprevision, 0) +
		ISNULL(@totalexpenseprevisionvar, 0), 'S')
	
	DECLARE crs_expense INSENSITIVE CURSOR FOR
		SELECT nphase, description FROM expensephase
		WHERE nphase >= @finexpensephase
		FOR READ ONLY
	OPEN crs_expense
	FETCH NEXT FROM crs_expense INTO @nphase, @phasedescription
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT @competency_tot = 0
		SELECT @arrears_tot = 0
		SELECT @competency_totvar = 0
		SELECT @arrears_totvar = 0
		SELECT @competency_tot = ISNULL(total, 0)
			FROM #competency_expense
			WHERE nphase = @nphase
		SELECT @competency_totvar = ISNULL(total, 0)
			FROM #competency_expensevar
			WHERE nphase = @nphase
		SELECT @arrears_tot = ISNULL(total, 0)
			FROM #arrear_expense
			WHERE nphase = @nphase
		SELECT @arrears_totvar = ISNULL(total, 0)
			FROM #arrear_expensevar
			WHERE nphase = @nphase
		INSERT INTO #situation VALUES(@phasedescription+' ', 
			ISNULL(@competency_tot, 0) +
			ISNULL(@arrears_tot, 0), '')
		INSERT INTO #situation VALUES('Variazioni ' + @phasedescription + ' ',
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_totvar, 0), '')
		IF @totpettycashop > 0
			BEGIN
				INSERT INTO #situation VALUES(
					'Totale piccole spese attribuite non reintegrate',
					@totpettycashop, '')
			END
		INSERT INTO #situation VALUES('Totale ' + @phasedescription + ' ',
			ISNULL(@competency_tot, 0) +
			ISNULL(@competency_totvar, 0) +
			ISNULL(@arrears_tot, 0) +
			ISNULL(@arrears_totvar, 0) +
			ISNULL(@totpettycashop, 0), 'S')

		INSERT INTO #situation VALUES('Previsione Disponibile per ' + '"' + @phasedescription + '"',--'Previsione disponibile', 
			ISNULL(@totalexpenseprevision, 0) +
			ISNULL(@totalexpenseprevisionvar, 0) - 
			ISNULL(@competency_tot, 0) -
			ISNULL(@competency_totvar, 0) -
			ISNULL(@arrears_tot, 0) -
			ISNULL(@arrears_totvar, 0) -
			ISNULL(@totpettycashop, 0), 'S')

		FETCH NEXT FROM crs_expense INTO @nphase, @phasedescription
	END
	DEALLOCATE crs_expense
	
	INSERT INTO #situation VALUES ('Mandati emessi ',
		ISNULL(@totpayment_c, 0) +
		ISNULL(@totpayment_r, 0) , 'S')
-- Incassi
	IF (@assured <> 'S')
	BEGIN
		IF 	(EXISTS(SELECT * FROM proceedspart 
			WHERE yproceedspart = @ayear
			AND adate <= @date) 
		OR
			EXISTS (SELECT * FROM finvar
			JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
			WHERE finvar.yvar = @ayear
			AND finvar.flagproceeds = 'S'
			AND finvar.adate <= @date))	
		BEGIN
			INSERT INTO #situation  VALUES ('', NULL, 'N')
			INSERT INTO #situation VALUES('I N C A S S I',NULL,'N')
			INSERT INTO #situation VALUES ('Variazioni dotazione cassa', @totalproceedsvar, '')
			INSERT INTO #situation VALUES ('Assegnazioni di cassa', @totalproceedspart, '')
			INSERT INTO #situation VALUES ('Totale',
				ISNULL(@totalproceedsvar, 0) +
				ISNULL(@totalproceedspart, 0), 'S')
			INSERT INTO #situation VALUES('Incassi disponibili', 
				ISNULL(@totalproceedsvar, 0) +
				ISNULL(@totalproceedspart, 0) -
				--Mandati emessi 
				ISNULL(@totpayment_c, 0) -
				ISNULL(@totpayment_r, 0) , '')
				--ISNULL(@competency_tot, 0) -
				--ISNULL(@competency_totvar, 0) -
				--ISNULL(@totpettycashop, 0), '')
			INSERT INTO #situation VALUES ('Previsione da incassare', 
				ISNULL(@totalexpenseprevision, 0) +
				ISNULL(@totalexpenseprevisionvar, 0) - 
				ISNULL(@totalproceedsvar, 0) -
				ISNULL(@totalproceedspart, 0) , 'S')
		END
	END
	SELECT value, amount, kind FROM #situation
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



	
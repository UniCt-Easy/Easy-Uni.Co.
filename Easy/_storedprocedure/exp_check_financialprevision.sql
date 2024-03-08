
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

/* Versione 1.0.2 del 07/10/2007 ultima modifica: SARA */

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
		AND income.nphase =  @assessmentphase 
		AND ayear = @ayear
		AND income.ymov = @ayear 
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
			AND I.idinc NOT IN (SELECT idinc FROM proceedscommunicated II
						WHERE II.idinc = I.idinc 
						AND (competencydate < @competencydate AND competencydate >=@jan01)
						)
	INSERT INTO #errors VALUES('')
END
-- ATTENZIONE: Questo controllo ha senso solo nel caso in cui si gestiscano i crediti
-- Infatti può accadere che nonostante un bilancio di competenza non venga effettuata l'assegnazione al credito
CREATE TABLE #proceedspart (ayear int,  idinc_credit int ,  idfin_proceeds int, amount_proceeds decimal(19,2), amount_credit decimal(19,2)  )

IF EXISTS(SELECT * FROM creditpart WHERE ycreditpart = @ayear)	
	OR EXISTS (select * from upb where assured='S')
BEGIN
	INSERT INTO #proceedspart( idinc_credit, idfin_proceeds,  amount_proceeds)

	SELECT 	IL1.idparent, 
		proceedspart.idfin, ISNULL(SUM(proceedspart.amount),0)
	FROM proceedspart 
	JOIN incomelink IL1 
		on IL1.idchild=proceedspart.idinc
		and IL1.nlevel = @assessmentphase
	WHERE yproceedspart = @ayear
	GROUP BY  IL1.idparent, proceedspart.idfin

	UPDATE #proceedspart set amount_credit =
		(SELECT SUM(CR.amount)	
		   FROM creditpart CR
		   WHERE CR.idinc= #proceedspart.idinc_credit
		   AND CR.idfin IN (SELECT oldidfin FROM allfinlookup
				WHERE newidfin=#proceedspart.idfin_proceeds)
		)
	
	
-- Controllo che l'assegnazione crediti degli accertamenti di competenza sia congrua con l'assegnazione incassi
	INSERT INTO #errors
	SELECT DISTINCT 'Gli incassi dipendenti dall''accertamento n.' + CONVERT(varchar(6),income.nmov) + ' del ' + CONVERT(varchar(4),income.ymov)
	+ ' presentano assegnazioni incassi non congrue'
	FROM income
	JOIN #proceedspart inc		
		ON income.idinc = inc.idinc_credit
	WHERE ISNULL(inc.amount_credit,0) < ISNULL(inc.amount_proceeds,0)
END
	SELECT error AS 'Elenco Errori' FROM #errors
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


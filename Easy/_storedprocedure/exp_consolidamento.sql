
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


DECLARE @idregauto  int
SELECT 
	@idregauto = isnull(idregauto,0)
FROM config
WHERE ayear = @ayear

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
		ISNULL(supposedcurrentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1

-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	SELECT	@ff_jan01 = ISNULL(startfloatfund, 0) 
	FROM surplus
	WHERE ayear = @ayear
	
	SELECT
	@aa_jan01 = @ff_jan01 +
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

CREATE TABLE #mov_finphase_C (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_finphase_C (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #mov_finphase_R (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_finphase_R (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #mov_maxphase_C (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_maxphase_C (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #mov_maxphase_R (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #var_maxphase_R (idfin int, totuniv decimal(19,2),totinterni decimal(19,2),totdiretti decimal(19,2))
CREATE TABLE #ava_finphase_C (idfin int, amount decimal(19,2))
CREATE TABLE #ava_finphase_R (idfin int, amount decimal(19,2))

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
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (IY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
				then (IY.amount)
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
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @registryphase
	GROUP BY ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #var_finphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (IV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
			    then (IV.amount)
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
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @registryphase
		AND IV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,IY.idfin)

	INSERT INTO #mov_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti

	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when  (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (IY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 ) 
				then (IY.amount)
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
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @registryphase
		AND I.adate <= @date
	GROUP BY ISNULL(FLK.idparent,IY.idfin)
	
	INSERT INTO #var_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (IV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (IV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
				then (IV.amount)
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
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @registryphase
		AND IV.adate <= @date
	GROUP BY ISNULL(FLK.idparent,IY.idfin)

	-- Caso in cui la fase bilancio e la fase anagrafica sono differenti
	IF (@finphase <> @registryphase)
	BEGIN
		INSERT INTO #ava_finphase_C (idfin, amount)
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
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) = 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			ISNULL(SUM(IV.amount), 0)
		FROM income I
		JOIN incomevar IV
			ON IV.idinc = I.idinc
		JOIN incomeyear IY
			ON IY.idinc = I.idinc
		JOIN incometotal IT
			ON IT.idinc = IY.idinc
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.adate <= @date
			AND IY.ayear = @ayear
			AND IV.yvar = @ayear
			AND ( (IT.flag & 1) = 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IY.amount), 0)
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
			AND ( (IT.flag & 1) = 0)-- Competenza
			AND I.nphase = @registryphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IV.amount), 0)
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
			AND ( (IT.flag & 1) = 0)-- Competenza
			AND I.nphase = @registryphase
			AND IV.adate <= @date 
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
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
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) <> 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			ISNULL(SUM(IV.amount), 0)
		FROM income I
		JOIN incomevar IV
			ON IV.idinc = I.idinc
		JOIN incomeyear IY
			ON IY.idinc = I.idinc
		JOIN incometotal IT
			ON IT.idinc = IY.idinc
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.adate <= @date
			AND IY.ayear = @ayear
			AND IV.yvar = @ayear
			AND ( (IT.flag & 1) <> 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IY.amount), 0)
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
			AND ( (IT.flag & 1) <> 0)-- Residuo
			AND I.nphase = @registryphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IV.amount), 0)
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
		WHERE IV.adate <= @date
			AND IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) <> 0)-- Residuo
			AND I.nphase = @registryphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)
	END

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 ) 
				then (HPV.amount)
				else 0	
			end),0)	
	FROM historyproceedsview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin)

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin), 
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
				then (HPV.amount)
				else 0	
			end),0)	
	FROM historyproceedsview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin) 

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
			ISNULL(FLK.idparent,HPV.idfin),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (IV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (IV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
					then (IV.amount)
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
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY ISNULL(FLK.idparent,HPV.idfin) 
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			totuniv,
			totinterni,
			totdiretti
		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (IV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (IV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
					then (IV.amount)
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
		GROUP BY ISNULL(FLK.idparent,HPV.idfin)
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
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (EY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 ) 
				then (EY.amount)
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
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @registryphase
	GROUP BY ISNULL(FLK.idparent,EY.idfin)
	
	INSERT INTO #var_finphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (EV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
				then (EV.amount)
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
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @registryphase
		AND EV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,EY.idfin) 

	INSERT INTO #mov_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EY.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (EY.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 ) 
				then (EY.amount)
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
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @registryphase
		AND E.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,EY.idfin)
	
	INSERT INTO #var_finphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (EV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (EV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 ) 
				then (EV.amount)
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
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @registryphase
		AND EV.adate <= @date 
	GROUP BY ISNULL(FLK.idparent,EY.idfin)

	-- Caso in cui la fase bilancio e la fase anagrafica sono differenti
	IF (@finphase <> @registryphase)
	BEGIN
		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			ISNULL(SUM(IY.amount),0)
		FROM expense I
		JOIN expenseyear IY
			ON IY.idexp = I.idexp
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE I.adate <= @date
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) = 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			ISNULL(SUM(IV.amount), 0)
		FROM expense I
		JOIN expensevar IV
			ON IV.idexp = I.idexp
		JOIN expenseyear IY
			ON IY.idexp = I.idexp
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.adate <= @date
			AND IY.ayear = @ayear
			AND IV.yvar = @ayear
			AND ( (IT.flag & 1) = 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IY.amount), 0)
		FROM expense I
		JOIN expenseyear IY
			ON IY.idexp = I.idexp
		JOIN registry R 
			ON I.idreg = R.idreg
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE I.adate <= @date
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) = 0)-- Competenza
			AND I.nphase = @registryphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_C (idfin, amount)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IV.amount), 0)
		FROM expensevar IV
		JOIN expenseyear IY
			ON IY.idexp = IV.idexp
		JOIN expense I
			ON  I.idexp = IY.idexp
		JOIN registry R 
			ON I.idreg = R.idreg
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) = 0)-- Competenza
			AND I.nphase = @registryphase
			AND IV.adate <= @date 
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			ISNULL(SUM(IY.amount),0)
		FROM expense I
		JOIN expenseyear IY
			ON IY.idexp = I.idexp
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE I.adate <= @date
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) <> 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			ISNULL(SUM(IV.amount), 0)
		FROM expense I
		JOIN expensevar IV
			ON IV.idexp = I.idexp
		JOIN expenseyear IY
			ON IY.idexp = I.idexp
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.adate <= @date
			AND IY.ayear = @ayear
			AND IV.yvar = @ayear
			AND ( (IT.flag & 1) <> 0)
			AND I.nphase = @finphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IY.amount), 0)
		FROM expense I
		JOIN expenseyear IY
			ON IY.idexp = I.idexp
		JOIN registry R 
			ON I.idreg = R.idreg
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE I.adate <= @date
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) <> 0)-- Residuo
			AND I.nphase = @registryphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)

		INSERT INTO #ava_finphase_R (idfin, amount)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			- ISNULL(SUM(IV.amount), 0)
		FROM expensevar IV
		JOIN expenseyear IY
			ON IY.idexp = IV.idexp
		JOIN expense I
			ON  I.idexp = IY.idexp
		JOIN registry R 
			ON I.idreg = R.idreg
		JOIN expensetotal IT
			ON IT.idexp = IY.idexp
			AND IT.ayear = IY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable
		WHERE IV.adate <= @date
			AND IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) <> 0)-- Residuo
			AND I.nphase = @registryphase
		GROUP BY ISNULL(FLK.idparent,IY.idfin)
	END

	INSERT INTO #mov_maxphase_C
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin), 
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
				then (HPV.amount)
				else 0	
			end),0)	
	FROM historypaymentview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin) 

	INSERT INTO #mov_maxphase_R
	(
		idfin,
		totuniv,
		totinterni,
		totdiretti
	)
	SELECT
		ISNULL(FLK.idparent,HPV.idfin),
		ISNULL(SUM(
			case 
				when R.idcentralizedcategory ='A' then (HPV.amount)  
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto)  then (HPV.amount)
				else 0	
			end),0),
		ISNULL(SUM(
			case 
				when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
				then (HPV.amount)
				else 0	
			end),0)	
	FROM historypaymentview HPV
	JOIN registry R 
		ON HPV.idreg = R.idreg
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
	GROUP BY ISNULL(FLK.idparent,HPV.idfin)

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
			ISNULL(FLK.idparent,HPV.idfin),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (EV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (EV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
					then (EV.amount)
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
			AND ( (HPV.totflag & 1) = 0)--Competenza
		GROUP BY ISNULL(FLK.idparent,HPV.idfin)
	
		INSERT INTO #var_maxphase_R
		(
			idfin,
			totuniv,
			totinterni,
			totdiretti

		)
		SELECT 
			ISNULL(FLK.idparent,HPV.idfin),
			ISNULL(SUM(
				case 
					when R.idcentralizedcategory ='A' then (EV.amount)  
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when (R.idcentralizedcategory = 'U' and R.idreg <> @idregauto) then (EV.amount)
					else 0	
				end),0),
			ISNULL(SUM(
				case 
					when ((isnull(R.idcentralizedcategory,'X') NOT IN ('A','U')) 
					  or
					  (R.idcentralizedcategory = 'U' and R.idreg = @idregauto)
					 )
					then (EV.amount)
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
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND EV.adate <= @date
		GROUP BY ISNULL(FLK.idparent,HPV.idfin)
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
	, 0) +
	ISNULL(
		(SELECT SUM(ISNULL(#ava_finphase_C.amount,0)) FROM #ava_finphase_C
		WHERE #ava_finphase_C.idfin = #balance.idfin)
	,0),
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
	, 0) +
	ISNULL(
		(SELECT SUM(ISNULL(#ava_finphase_R.amount,0)) FROM #ava_finphase_R
		WHERE #ava_finphase_R.idfin = #balance.idfin)
	,0),
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

	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = #balance.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 

	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = #balance.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 

	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = #balance.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 

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


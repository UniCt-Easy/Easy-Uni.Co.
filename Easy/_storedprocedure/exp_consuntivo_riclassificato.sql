
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_consuntivo_riclassificato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_consuntivo_riclassificato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
--setuser 'amm'
-- exec exp_consuntivo_riclassificato 2022, {ts '2023-03-08 00:00:00'}, 'S', 13, '%', 'N', 'N'
CREATE   PROCEDURE [exp_consuntivo_riclassificato]
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@idsorkindfin int,
	@idupb varchar(36),
	@showchildupb char(1),
	@officialvar varchar(1)
)
AS BEGIN

CREATE TABLE #balance
(
	idsor int,
	--codefin varchar(50),
	description varchar(150),
	--printingorder varchar(31),
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

DECLARE @levelusable tinyint
DECLARE @MAXSorOpLevel tinyint
SELECT @MAXSorOpLevel = MAX(nlevel)
FROM sortinglevel
WHERE idsorkind = @idsorkindfin

-- SE non è stato selezionato il livello, prende l'ultimo livello operativo
if(isnull(@levelusable,0)=0 )
Begin
	set @levelusable = @MAXSorOpLevel
End
	
DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @MAXSorOpLevel)-- se decidi di fare la stampa per categoria
begin
	SET @levelusable = @MAXSorOpLevel
end

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
INSERT INTO #balance
(
	idsor,
	initialprevision,
	secondaryprev
)
SELECT 
	isnull(SLK.idparent, sorFin.idsor),
	ISNULL(SUM(fy.prevision),0), 
	ISNULL(SUM(fy.secondaryprev),0)
FROM fin f
CROSS JOIN upb 
JOIN finlevel fl
	ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
LEFT OUTER JOIN finyear fy
	ON fy.idfin = f.idfin
	AND fy.idupb = upb.idupb
LEFT OUTER JOIN finsorting fs on fs.idfin = f.idfin
LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
LEFT OUTER JOIN sortinglevel sl on sorFin.nlevel = sl.nlevel
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE f.ayear = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND (upb.idupb LIKE @idupb)
	AND ((f.flag & 1)= @finpart_bit)
	AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			AND (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
GROUP BY isnull(SLK.idparent, sorFin.idsor)

CREATE TABLE #tot_varprev_acc_M (idsor int, total decimal(19,2))
INSERT INTO #tot_varprev_acc_M
(
	idsor,
	total
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finsorting fs on fs.idfin = F.idfin
LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
GROUP BY isnull(SLK.idparent, sorFin.idsor)

CREATE TABLE #tot_varprev_red_M (idsor int, total decimal(19,2))
INSERT INTO #tot_varprev_red_M
(
	idsor,
	total
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finsorting fs on fs.idfin = F.idfin
LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
GROUP BY isnull(SLK.idparent, sorFin.idsor)
	
CREATE TABLE #tot_varprev_acc_S (idsor int, total decimal(19,2))
INSERT INTO #tot_varprev_acc_S
(
	idsor,
	total
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finsorting fs on fs.idfin = F.idfin
LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND ((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount > 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
GROUP BY isnull(SLK.idparent, sorFin.idsor)

CREATE TABLE #tot_varprev_red_S (idsor int, total decimal(19,2))
INSERT INTO #tot_varprev_red_S
(
	idsor,
	total
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
join fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finsorting fs on fs.idfin = F.idfin
LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND FVD.idupb LIKE @idupb
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND ((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND FVD.amount < 0
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
GROUP BY isnull(SLK.idparent, sorFin.idsor)


CREATE TABLE #mov_finphase_C (idsor int, total decimal(19,2))
CREATE TABLE #var_finphase_C (idsor int, total decimal(19,2))
CREATE TABLE #mov_finphase_R (idsor int, total decimal(19,2))
CREATE TABLE #var_finphase_acc_R (idsor int, total decimal(19,2))
CREATE TABLE #var_finphase_red_R (idsor int, total decimal(19,2))
CREATE TABLE #mov_maxphase_C (idsor int, total decimal(19,2))
CREATE TABLE #var_maxphase_C (idsor int, total decimal(19,2))
CREATE TABLE #mov_maxphase_R (idsor int, total decimal(19,2))
CREATE TABLE #var_maxphase_R (idsor int, total decimal(19,2))
IF (@finpart = 'E')
BEGIN
	INSERT INTO #mov_finphase_C
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(IY.amount),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = IY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE I.adate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #var_finphase_C
	(
		idsor,
		total
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = IY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #mov_finphase_R
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(IY.amount),0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = IY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IY.ayear = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND IY.idupb LIKE @idupb
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #var_finphase_acc_R
	(
		idsor,
		total
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = IY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount > 0
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #var_finphase_red_R
	(
		idsor,
		total
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = IY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND IY.idupb LIKE @idupb
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount < 0
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #mov_maxphase_C
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable
	LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND HPV.idupb LIKE @idupb
		AND HPV.flagarrear = 'C'
		AND HPV.ymov = @ayear
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #mov_maxphase_R
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND HPV.idupb LIKE @idupb
		AND HPV.flagarrear = 'R'
		AND HPV.ymov = @ayear
		AND (sorFin.nlevel = @levelusable
		OR (sorFin.nlevel < @levelusable
			and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
			AND (sl.flag&2)<>0
			)
		)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idsor,
			total
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
		LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
		LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND HPV.idupb LIKE @idupb
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
		GROUP BY isnull(SLK.idparent, sorFin.idsor)
	
		INSERT INTO #var_maxphase_R
		(
			idsor,
			total
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
		LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
		LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND HPV.idupb LIKE @idupb
			AND IV.adate <= @date
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
		GROUP BY isnull(SLK.idparent, sorFin.idsor)
	END
END
IF @finpart = 'S'
BEGIN

	INSERT INTO #mov_finphase_C
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = EY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #var_finphase_C
	(
		idsor,
		total
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = EY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND EV.adate <= @date
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #mov_finphase_R
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = EY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1)
		AND E.nphase = @finphase
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #var_finphase_acc_R
	(
		idsor,
		total
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = EY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount > 0
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #var_finphase_red_R
	(
		idsor,
		total
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON EY.idexp = E.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finsorting fs on fs.idfin = EY.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND EY.idupb LIKE @idupb
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount < 0
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #mov_maxphase_C
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND HPV.idupb LIKE @idupb
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #mov_maxphase_R
	(
		idsor,
		total
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
	LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
	LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND HPV.idupb LIKE @idupb	
		AND ( (HPV.totflag & 1) = 1) -- Residuo
		AND HPV.ymov = @ayear
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
	GROUP BY isnull(SLK.idparent, sorFin.idsor)

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #var_maxphase_C
		(
			idsor,
			total
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
		LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
		LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND  HPV.idupb LIKE @idupb
			AND EV.adate <= @date
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
					)
				)
		GROUP BY  isnull(SLK.idparent, sorFin.idsor)
	
		INSERT INTO #var_maxphase_R
		(
			idsor,
			total
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finsorting fs on fs.idfin = HPV.idfin
		LEFT OUTER JOIN sorting sorFin on sorFin.idsor = fs.idsor
		LEFT OUTER JOIN sortinglevel sl on sl.nlevel = sorFin.nlevel
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND  HPV.idupb LIKE @idupb
			AND EV.adate <= @date
			AND ( (HPV.totflag & 1) = 1)--Residuo
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
			AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
					)
				)
		GROUP BY  isnull(SLK.idparent, sorFin.idsor)
	END
END

UPDATE #balance
SET var_prev_m_acc =
ISNULL(
	(SELECT SUM(#tot_varprev_acc_M.total) FROM #tot_varprev_acc_M
	WHERE #tot_varprev_acc_M.idsor = #balance.idsor)
, 0),
var_prev_m_red = 
ISNULL(
	(SELECT SUM(#tot_varprev_red_M.total) FROM #tot_varprev_red_M
	WHERE #tot_varprev_red_M.idsor = #balance.idsor),
0),
var_prev_s_acc =
ISNULL(
	(SELECT SUM(#tot_varprev_acc_S.total) FROM #tot_varprev_acc_S
	WHERE #tot_varprev_acc_S.idsor = #balance.idsor),
0),
var_prev_s_red =
ISNULL(
	(SELECT SUM(#tot_varprev_red_S.total) FROM #tot_varprev_red_S
	WHERE #tot_varprev_red_S.idsor = #balance.idsor), 0),
mov_finphase_C =
ISNULL(
	(SELECT SUM(#mov_finphase_C.total) FROM #mov_finphase_C
	WHERE #mov_finphase_C.idsor = #balance.idsor)
, 0),
var_finphase_C =
ISNULL(
	(SELECT SUM(#var_finphase_C.total) FROM #var_finphase_C
	WHERE #var_finphase_C.idsor = #balance.idsor)
, 0),
mov_maxphase_C =
ISNULL(
	(SELECT SUM(#mov_maxphase_C.total) FROM #mov_maxphase_C
	WHERE #mov_maxphase_C.idsor = #balance.idsor)
, 0),
var_maxphase_C =
ISNULL(
	(SELECT SUM(#var_maxphase_C.total) FROM #var_maxphase_C
	WHERE #var_maxphase_C.idsor = #balance.idsor)
, 0),
mov_finphase_R =
ISNULL(
	(SELECT SUM(#mov_finphase_R.total) FROM #mov_finphase_R
	WHERE #mov_finphase_R.idsor = #balance.idsor)
, 0),
var_finphase_acc_R =
ISNULL(
	(SELECT SUM(#var_finphase_acc_R.total) FROM #var_finphase_acc_R
	WHERE #var_finphase_acc_R.idsor = #balance.idsor)
, 0),
var_finphase_red_R =
ISNULL(
	(SELECT SUM(#var_finphase_red_R.total) FROM #var_finphase_red_R
	WHERE #var_finphase_red_R.idsor = #balance.idsor)
, 0),
mov_maxphase_R =
ISNULL(
	(SELECT SUM(#mov_maxphase_R.total) FROM #mov_maxphase_R
        WHERE #mov_maxphase_R.idsor = #balance.idsor)
, 0),
var_maxphase_R =
ISNULL(
	(SELECT SUM(#var_maxphase_R.total) FROM #var_maxphase_R
	WHERE #var_maxphase_R.idsor = #balance.idsor)
, 0)

DECLARE @supposed_cash_jan01 decimal(19,2)
DECLARE @cash_jan01 decimal(19,2)
DECLARE @supposed_amm_jan01 decimal(19,2)
DECLARE @var_ff_acc decimal(19,2)
DECLARE @var_ff_red decimal(19,2)
DECLARE @var_aa_acc decimal(19,2)
DECLARE @var_aa_red decimal(19,2)

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
			idsor,
			description, 
			initialprevision,
			var_prev_M_acc,
			var_prev_M_red
		)
		VALUES
		(
			@idavanzoamm , 
			'Avanzo di Amministrazione', ---avanzo amministrazione 0
			@supposed_amm_jan01,
			@var_aa_acc,
			@var_aa_red)
	END
	
	SELECT
		SorFin.sortcode as 'Codice Classificazione',
		SorFin.description as 'Descrizione Classificazione',
		--fin.codefin AS 'Codice Bilancio',
		--fin.title AS 'Denominazione',
		ISNULL(SUM(initialprevision),0) AS 'Prev. di competenza iniziale', 
		ISNULL(SUM(var_prev_M_acc),0) AS 'Var. aumento prev. Competenza',
		- ISNULL(SUM(var_prev_M_red),0) AS 'Var. dimin. prev. Competenza',
		sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0))  AS 'Prev. Competenza Definitiva',
		sum(isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0)) AS 'Accertamenti riscossi',
		sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0)) AS 'Accertamenti da riscuotere',
		sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)) AS 'Totale somme accertate',
		sum(CASE #balance.idsor
			WHEN @idavanzoamm  THEN 0
			ELSE (isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0) - isnull(mov_finphase_C,0) - isnull(var_finphase_C,0))
		END) AS 'Differenza rispetto alle previsioni',
		ISNULL(SUM(mov_finphase_R),0) AS 'Residui Attivi Iniziali' ,
		sum(isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)) AS 'Residui Attivi Riscossi',
		sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Residui Attivi da riscuotere',
		sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale Residui Attivi',
		ISNULL(SUM(var_finphase_acc_R),0) AS 'Var. aumento residui attivi',
		- ISNULL(SUM(var_finphase_red_R),0) AS 'Var. diminuzione residui attivi' ,
		sum(isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale Variazioni Residui Attivi',
		sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0) + isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)  - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Tot. res. attivi a fine esercizio'
	FROM #balance
	--LEFT OUTER JOIN fin
	--	ON fin.idfin = fs.idfin
	LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
	GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder--, fin.codefin, fin.title
	ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
END
	IF (@finpart = 'S')
	BEGIN
		SELECT
			SorFin.sortcode as 'Codice Classificazione',
			SorFin.description as 'Descrizione Classificazione',
			--fin.codefin AS 'Codice Bilancio',
			--fin.title AS 'Denominazione',
			ISNULL(SUM(initialprevision),0) AS 'Prev. di competenza iniziale', 
			ISNULL(SUM(var_prev_M_acc),0)  AS 'Var. aumento prev. competenza',
			- ISNULL(SUM(var_prev_M_red),0)  AS 'Var. dimin. prev. competenza',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0))  AS 'Prev. competenza definitiva',
			sum(isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0)) AS 'Somme impegnate pagate',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0)) AS 'Somme impegnate da pagare',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)) AS 'Totale somme impegnate',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0) - isnull(mov_finphase_C,0) - isnull(var_finphase_C,0)) AS 'Differenza rispetto alle previsioni',
			ISNULL(SUM(mov_finphase_R),0) AS 'Residui passivi iniziali' ,
			sum(isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)) AS 'Residui passivi riscossi',
			sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Residui Passivi da riscuotere',
			sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale residui passivi',
			ISNULL(SUM(var_finphase_acc_R),0)  AS 'Var. residui passivi in aumento',
			-ISNULL(SUM(var_finphase_red_R),0)  AS 'Var. residui passivi in diminuzione',
			sum(isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale variazioni residui passivi',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0) + isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Tot. res. passivi a fine esercizio'
		FROM #balance
		--LEFT OUTER JOIN fin
		--	ON fin.idfin = fs.idfin		
		LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
		GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder--, fin.codefin, fin.title
		ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
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
				idsor,
				description,
				initialprevision, var_prev_M_acc, var_prev_M_red, mov_maxphase_C) -- Fondo cassa effettivo nella colonna  Totale Riscossioni  
			VALUES
			(
				@idavanzocassa , 
				'Avanzo di Cassa',
				@supposed_cash_jan01, @var_ff_acc, @var_ff_red, @cash_jan01
			)
		END
		SELECT 
			SorFin.sortcode as 'Codice Classificazione',
			SorFin.description as 'Descrizione Classificazione',
			--fin.codefin AS 'Codice Bilancio',
			--fin.title AS 'Denominazione',
			ISNULL(SUM(initialprevision),0) AS 'Prev. di cassa iniziale', 
			ISNULL(SUM(var_prev_M_acc),0) AS 'Var. aumento prev. cassa',
			-ISNULL(SUM(var_prev_M_red),0) AS 'Var. dimin. prev. cassa',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0)) AS 'Prev. cassa definitiva',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)) AS 'Totale Somme Accertate',
			sum(CASE #balance.idsor
				WHEN @idavanzocassa   THEN isnull(mov_maxphase_C,0)
				ELSE (isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0))
			END) AS 'Totale Riscossioni',
			sum(CASE #balance.idsor 
				WHEN @idavanzocassa   THEN 0
				ELSE (isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0)) -  (isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0))
			END) AS 'Differenza rispetto alle previsioni'
		FROM #balance
		--LEFT OUTER JOIN fin
		--	ON fin.idfin = fs.idfin		
		LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
		GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder--, fin.codefin, fin.title
		ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
	END
	IF (@finpart = 'S')
	BEGIN
		SELECT
			SorFin.sortcode as 'Codice Classificazione',
			SorFin.description as 'Descrizione Classificazione',
			--fin.codefin AS 'Codice Bilancio',
			--fin.title AS 'Denominazione',
			ISNULL(SUM(initialprevision),0) AS 'Prev. di cassa iniziale', 
			ISNULL(SUM(var_prev_M_acc),0) AS 'Var. aumento prev. cassa',
			-ISNULL(SUM(var_prev_M_red),0) AS 'Var. dimin. prev. cassa',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0)) AS 'Prev. cassa definitiva',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)) AS 'Totale Somme Impegnate',
			sum(isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)) AS 'Totale Pagamenti',
			sum((isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0)) - (isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0))) AS 'Differ. rispetto alle previsioni'	 
		FROM #balance
		--LEFT OUTER JOIN fin
		--	ON fin.idfin = fs.idfin
		LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
		GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder--, fin.codefin, fin.title
		ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
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
				idsor, description,
				initialprevision, var_prev_M_acc, var_prev_M_red
			)
			VALUES
			(
				@idavanzoamm , 'Avanzo di Amministrazione',   ---avanzo amministrazione 0
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
				idsor, description,
				secondaryprev, var_prev_S_acc, var_prev_S_red, mov_maxphase_C
			) --Fondo cassa effettivo nella colonna  Totale Riscossioni
			VALUES
			(
				@idavanzocassa , 'Avanzo di Cassa',  ---Avanzo di cassa null
				@supposed_cash_jan01, @var_ff_acc, @var_ff_red, @cash_jan01
			)
		END
		SELECT
			SorFin.sortcode as 'Codice Classificazione',
			SorFin.description as 'Descrizione Classificazione',
			--fin.codefin AS 'Codice Bilancio',
			--fin.title AS 'Denominazione',
			ISNULL(SUM(initialprevision),0) AS 'Prev. competenza iniziale', 
			ISNULL(SUM(var_prev_M_acc),0) AS 'Var. aumento prev. competenza',
			-ISNULL(SUM(var_prev_M_red),0) AS 'Var. dimin. prev. competenza',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0))  AS 'Prev. competenza definitiva',
			sum(CASE #balance.idsor
				WHEN @idavanzocassa  THEN 0
				ELSE (isnull(mov_maxphase_C,0)+isnull(var_maxphase_C,0))
			END) AS 'Accertamenti riscossi',
			sum(CASE #balance.idsor
				WHEN @idavanzocassa   THEN 0
				ELSE (isnull(mov_finphase_C,0)+isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0))
			END) AS 'Accertamenti da riscuotere',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)) AS 'Totale somme accertate',
			sum(CASE #balance.idsor
				WHEN @idavanzocassa   THEN 0
				ELSE (isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0) - isnull(mov_finphase_C,0)-isnull(var_finphase_C,0))
			END) AS 'Differenza rispetto alle previsioni (comp.)',
			ISNULL(SUM(secondaryprev),0) AS 'Prev. cassa iniziale', 
			ISNULL(SUM(var_prev_S_acc),0) AS 'Var. aumento prev. cassa',
			-ISNULL(SUM(var_prev_S_red),0) AS 'Var. dimin. prev. cassa',
			sum(isnull(secondaryprev,0) + isnull(var_prev_S_acc,0) + isnull(var_prev_S_red,0)) AS 'Prev. cassa definitiva' ,
			sum(CASE #balance.idsor
				WHEN @idavanzocassa   THEN isnull(mov_maxphase_C,0)
				ELSE (isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0))
			END) AS 'Totale Riscossioni',
			sum(CASE #balance.idsor
				WHEN @idavanzocassa   THEN 0
				ELSE (isnull(secondaryprev,0) + isnull(var_prev_S_acc,0) + isnull(var_prev_S_red,0))- (isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0))
			END) AS 'Differenza rispetto alle previsioni (cassa)',
			ISNULL(SUM(mov_finphase_R),0) AS 'Residui Attivi Iniziali' ,
			sum(isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)) AS 'Residui Attivi Riscossi',
			sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Residui Attivi da riscuotere',
			sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale Residui Attivi',
			ISNULL(SUM(var_finphase_acc_R),0)  AS 'Var. residui attivi in aumento',
			-ISNULL(SUM(var_finphase_red_R),0)  AS 'Var. residui attivi in diminuzione',
			sum(isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale Variazioni Residui Attivi',
			sum(CASE #balance.idsor
				WHEN @idavanzocassa  THEN 0
				ELSE (isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0) + isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0))
			END) AS 'Tot. res. attivi a fine esercizio'
		FROM #balance
		--LEFT OUTER JOIN fin
		--	ON fin.idfin = fs.idfin
		LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
		GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder--, fin.codefin, fin.title
		ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
	END
	IF(@finpart = 'S')
	BEGIN
		SELECT
			SorFin.sortcode as 'Codice Classificazione',
			SorFin.description as 'Descrizione Classificazione',
			--fin.codefin AS 'Codice Bilancio',
			--fin.title AS 'Denominazione',
			ISNULL(SUM(initialprevision),0) AS 'Prev. competenza iniziale', 
			ISNULL(SUM(var_prev_M_acc),0) AS 'Var. aumento prev. competenza',
			-ISNULL(SUM(var_prev_M_red),0) AS 'Var. dimin. prev. competenza',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0))  AS 'Prev. competenza definitiva',
			sum(isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0)) AS 'Somme impegnate pagate',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0)) AS 'Somme impegnate da pagare',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)) AS 'Totale somme impegnate',
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0) - isnull(mov_finphase_C,0)-isnull(var_finphase_C,0)) AS 'Differenza rispetto alle previsioni (comp.)',	 
			ISNULL(SUM(secondaryprev),0) AS 'Prev. cassa iniziale', 
			ISNULL(SUM(var_prev_S_acc),0) AS 'Var. aumento prev. cassa',
			-ISNULL(SUM(var_prev_S_red),0) AS 'Var. dimin. prev. cassa',
			sum(isnull(secondaryprev,0) + isnull(var_prev_S_acc,0) + isnull(var_prev_S_red,0))  AS 'Prev. cassa definitiva',
			sum(isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)) AS 'Totale Pagamenti',
			sum((isnull(secondaryprev,0) + isnull(var_prev_S_acc,0) + isnull(var_prev_S_red,0))- (isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0) + isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0))) AS 'Differenza rispetto alle previsioni (cassa)',   	
			ISNULL(SUM(mov_finphase_R),0) AS 'Residui Passivi Iniziali' ,
			sum(isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)) AS 'Residui Passivi Pagati',
			sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Residui Passivi da pagare',
			sum(isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale Residui Passivi',
			ISNULL(SUM(var_finphase_acc_R),0) AS 'Var. residui passivi in aumento',
			-ISNULL(SUM(var_finphase_red_R),0) AS 'Var. residui passivi in diminuzione',
			sum(isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)) AS 'Totale Variazioni Residui Passivi',
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0) + isnull(mov_finphase_R,0) + isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0) - isnull(mov_maxphase_R,0) - isnull(var_maxphase_R,0)) AS 'Tot. res. passivi a fine esercizio'
		FROM #balance
		--LEFT OUTER JOIN fin
		--	ON fin.idfin = fs.idfin		
		LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
		GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder--, fin.codefin, fin.title
		ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
	END
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

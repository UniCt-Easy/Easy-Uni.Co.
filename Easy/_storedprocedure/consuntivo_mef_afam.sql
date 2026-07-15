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

if exists (select * from dbo.sysobjects where id = object_id(N'[consuntivo_mef_afam]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [consuntivo_mef_afam]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
--consuntivo_mef_afam '2022', '13'
CREATE   PROCEDURE [consuntivo_mef_afam]
(
	@ayear int,
	@idsorkindfin int
)
AS BEGIN

	CREATE TABLE #mef_sheet
	(
		classificazione varchar(200),
		colonna char(1),
		valore decimal(19,2),
		movkind char(1),
		foglio varchar(100)
	)

	CREATE TABLE #balance
	(
		idsor int,
		--codefin varchar(50),
		description varchar(200),
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

	CREATE TABLE #consuntivo
	(
		description varchar(200),
		movkind char(1),
		b decimal(19,2),
		c decimal(19,2),
		d decimal(19,2),
		e decimal(19,2),
		f decimal(19,2),
		g decimal(19,2),
		h decimal(19,2),
		j decimal(19,2)
	)

	declare @date datetime
	set @date = CONVERT(DATETIME, concat(convert(varchar(4), @ayear),'-12-31'), 121)

	declare @idupb varchar(36)
	set @idupb = '%'

	DECLARE @cashvaliditykind tinyint
	SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
	DECLARE @finphase_E tinyint
	DECLARE @maxphase_E tinyint
	DECLARE @finphase_S tinyint
	DECLARE @maxphase_S tinyint

	DECLARE @levelusable tinyint
	SELECT @levelusable = MAX(nlevel)
	FROM sortinglevel
	WHERE idsorkind = @idsorkindfin

	DECLARE @idavanzocassa  int
	DECLARE @idavanzoamm int

	SET @idavanzocassa  = -1
	SET @idavanzoamm = -2

	-- Entrate
	-- ricerca la fase equivalente all'accertamento
	-- se è stata inserita nella tabella di configurazione del bilancio
	SELECT @finphase_E = assessmentphasecode FROM config WHERE ayear = @ayear
	IF @finphase_E IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase_E = incomefinphase FROM uniconfig
	END
	-- la fase di cassa è sempre l'ultima fase della procedura
	-- di entrata
	SELECT @maxphase_E = MAX(nphase) FROM incomephase

	--Spesa
	-- ricerca la fase equivalente all'impegno
	-- se è stata inserita nella tabella di configurazione
	-- del bilancio
	SELECT @finphase_S = appropriationphasecode FROM config WHERE ayear = @ayear
	IF @finphase_S IS NULL
	BEGIN
		-- se non è stata inserita nella tabella di configurazione
		-- ipotizza che si tratti della fase dove viene identificata
		-- la voce di bilancio
		SELECT @finphase_S = expensefinphase FROM uniconfig
	END
	-- la fase di cassa è sempre l'ultima fase della procedura di spesa
	SELECT @maxphase_S = MAX(nphase) FROM expensephase

	DECLARE @supposed_ff_jan01 decimal(19,2)
	DECLARE @supposed_aa_jan01 decimal(19,2)
	DECLARE @ff_jan01 decimal(19,2)
	DECLARE @aa_jan01 decimal(19,2)

	-- Entrate
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
	---

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
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
	WHERE f.ayear = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (upb.idupb LIKE @idupb)
		--AND ((f.flag & 1)= @finpart_bit)
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				AND (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
				)
			)
		AND (F.flag & 16 =0)
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
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
	WHERE FV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND FVD.idupb LIKE @idupb
		AND FV.adate <= @date
		AND FV.flagprevision = 'S'
		AND((ISNULL(FV.official,'N') = 'S') -- consideriamo solo le variazioni ufficiali
		  )
		AND FV.idfinvarstatus = 5
		AND FV.variationkind <> 5
		AND FVD.amount > 0
		--AND ((F.flag & 1 ) = @finpart_bit) 
		AND F.ayear = @ayear
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
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
	WHERE FV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND FVD.idupb LIKE @idupb
		AND FV.adate <= @date
		AND FV.flagprevision = 'S'
		AND((ISNULL(FV.official,'N') = 'S') -- consideriamo solo le variazioni ufficiali
		  )
		AND FV.idfinvarstatus = 5
		AND FV.variationkind <> 5
		AND FVD.amount < 0
		--AND ((F.flag & 1 ) = @finpart_bit) 
		AND F.ayear = @ayear
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
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
	WHERE FV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND FVD.idupb LIKE @idupb
		AND FV.adate <= @date
		AND FV.flagsecondaryprev = 'S'
		AND ((ISNULL(FV.official,'N') = 'S' ) -- consideriamo solo le variazioni ufficiali
		  )
		AND FV.idfinvarstatus = 5
		AND FV.variationkind <> 5
		AND FVD.amount > 0
		--AND ((F.flag & 1 ) = @finpart_bit) 
		AND F.ayear = @ayear
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
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
	WHERE FV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND FVD.idupb LIKE @idupb
		AND FV.adate <= @date
		AND FV.flagsecondaryprev = 'S'
		AND ((ISNULL(FV.official,'N') = 'S' ) -- consideriamo solo le variazioni ufficiali
		  )
		AND FV.idfinvarstatus = 5
		AND FV.variationkind <> 5
		AND FVD.amount < 0
		--AND ((F.flag & 1 ) = @finpart_bit) 
		AND F.ayear = @ayear
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

	--Entrate
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE I.adate <= @date
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND IY.idupb LIKE @idupb
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) =0)-- Competenza
			AND I.nphase = @finphase_E
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND IY.idupb LIKE @idupb
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) =0)-- Competenza
			AND I.nphase = @finphase_E
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE IY.ayear = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND IY.idupb LIKE @idupb
			AND ( (IT.flag & 1) = 1)-- Residuo
			AND I.nphase = @finphase_E
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND IY.idupb LIKE @idupb
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) = 1)-- Residuo
			AND I.nphase = @finphase_E
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND IY.idupb LIKE @idupb
			AND IY.ayear = @ayear
			AND ( (IT.flag & 1) = 1)-- Residuo
			AND I.nphase = @finphase_E
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
			LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
			LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
	-- fine entrate


	--Spese
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE E.adate <= @date
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND EY.idupb LIKE @idupb
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND E.nphase = @finphase_S
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND EY.idupb LIKE @idupb
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) = 0) -- Competenza
			AND E.nphase = @finphase_S
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE E.adate <= @date
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND EY.idupb LIKE @idupb
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) = 1)
			AND E.nphase = @finphase_S
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND EY.idupb LIKE @idupb
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) = 1) -- Residuo
			AND E.nphase = @finphase_S
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
		WHERE EV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND EY.idupb LIKE @idupb
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) = 1) -- Residuo
			AND E.nphase = @finphase_S
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
			LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
			LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable
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
	--fine spese

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

	-- Competenza Pura
	IF (@fin_kind = 1)
	BEGIN 
		--Entrate  
		SET @supposed_amm_jan01 = 0
		SET @var_aa_acc = 0
		SET @var_aa_red = 0
		
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
			@var_aa_red
		)
		
		INSERT INTO #consuntivo
		(
			description,
			movkind,
			b,
			c,
			d,
			e,
			f,
			g,
			h
		)
		SELECT
			SorFin.description,
			SorFin.movkind,
			sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0)),
			sum(isnull(mov_maxphase_C,0) + isnull(var_maxphase_C,0)),
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0)),
			sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)),
			ISNULL(SUM(mov_finphase_R),0),
			sum(isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)),
			sum(isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0))
		FROM #balance
		LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
		GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder, SorFin.movkind
		ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
				
	END 

	-- Cassa Pura	-------------------------------------------------
	IF @fin_kind = 2
	BEGIN 
					
			INSERT INTO #consuntivo
			(
				description,
				movkind,
				e,
				j
			)
			SELECT
				SorFin.description,
				SorFin.movkind,
				sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)),
				sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0))
			FROM #balance
			LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
			GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder, SorFin.movkind
			ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
			
	END


	-- Compentenza e Cassa
	IF (@fin_kind = 3)
	BEGIN 
		
			INSERT INTO #consuntivo
			(
				description,
				movkind,
				b,
				c,
				d,
				e,
				f,
				g,
				h,
				j
			)
			SELECT
				SorFin.description,
				SorFin.movkind,
				sum(isnull(initialprevision,0) + isnull(var_prev_M_acc,0) + isnull(var_prev_M_red,0)),--b
				sum(CASE #balance.idsor
						WHEN @idavanzocassa  THEN 0
						ELSE (isnull(mov_maxphase_C,0)+isnull(var_maxphase_C,0))
					END),--c
				sum(CASE #balance.idsor
							WHEN @idavanzocassa   THEN 0
							ELSE (isnull(mov_finphase_C,0)+isnull(var_finphase_C,0) - isnull(mov_maxphase_C,0) - isnull(var_maxphase_C,0))
						END),--d
				sum(isnull(mov_finphase_C,0) + isnull(var_finphase_C,0)),--e
				ISNULL(SUM(mov_finphase_R),0), --f
				sum(isnull(mov_maxphase_R,0) + isnull(var_maxphase_R,0)), --g
				sum(isnull(var_finphase_acc_R,0) + isnull(var_finphase_red_R,0)), --h
				sum(isnull(secondaryprev,0) + isnull(var_prev_S_acc,0) + isnull(var_prev_S_red,0))--j
			FROM #balance
			LEFT OUTER JOIN sorting SorFin on SorFin.idsor = #balance.idsor
			GROUP BY SorFin.sortcode, SorFin.description, #balance.idsor, SorFin.printingorder, SorFin.movkind
			ORDER BY len(SorFin.printingorder), SorFin.printingorder ASC
	
	END

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'B',
		b,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'C',
		c,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'D',
		d,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'E',
		e,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'F',
		f,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'G',
		g,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'H',
		h,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT
		description,
		'J',
		j,
		movkind,
		'Bilancio finanziario'
	FROM #consuntivo

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'CONSISTENZA DELLA CASSA ALL''INIZIO DELL''ESERCIZIO',
		'B',
		startfloatfund,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'RISCOSSIONI IN C/COMPETENZA',
		'B',
		competencyproceeds,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'RISCOSSIONI IN C/RESIDUI',
		'B',
		residualproceeds,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'PAGAMENTI IN C/COMPETENZA',
		'B',
		competencypayments,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'PAGAMENTI IN C/RESIDUI',
		'B',
		residualpayments,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'RESIDUI ATTIVI DEGLI ESERCIZI PRECEDENTI',
		'B',
		previousrevenue,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'RESIDUI ATTIVI DELL''ESERCIZIO',
		'B',
		currentrevenue,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'RESIDUI PASSIVI DEGLI ESERCIZI PRECEDENTI',
		'B',
		previousexpenditure,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'RESIDUI PASSIVI DELL''ESERCIZIO',
		'B',
		currentexpenditure,
		null,
		'Situazione Amministrativa 31 12'
	FROM surplus
	where ayear = @ayear

	INSERT INTO #mef_sheet
	(
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	)
	SELECT		
		'Depositi bancari e postali',
		'C',
		startfloatfund + competencyproceeds + residualproceeds - competencypayments - residualpayments,
		null,
		'Stato Patrimoniale'
	FROM surplus
	where ayear = @ayear

	SELECT
		classificazione,
		colonna,
		valore,
		movkind,
		foglio
	FROM #mef_sheet
	ORDER BY foglio, classificazione, movkind, colonna

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

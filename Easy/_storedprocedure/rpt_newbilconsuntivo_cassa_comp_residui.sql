
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_newbilconsuntivo_cassa_comp_residui]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_newbilconsuntivo_cassa_comp_residui]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
-- exec rpt_newbilconsuntivo_cassa_comp_residui 2005,{ts '2005-12-31 00:00:00'},'S',3,'%','S','S','N','N','C'
--    exec rpt_bilconsuntivo_cassa_comp_residui 2005,{ts '2005-12-31 00:00:00'},'S',3,'%','S','S','N','N','C'


CREATE        PROCEDURE [rpt_newbilconsuntivo_cassa_comp_residui]
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@suppressifblank char(1),
	@officialvar  char(1),
	@kind char (1)  --C/S/R
)
AS BEGIN


CREATE TABLE #data
(
	idfin int,
	idupb varchar(36),
	initialprevision decimal(19,2),
	varprev_m_acc decimal(19,2),
	varprev_m_red decimal(19,2),
	secondaryprev decimal(19,2),
	varprev_s_acc decimal(19,2),
	varprev_s_red decimal(19,2),
	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_acc_C decimal(19,2),
	var_finphase_red_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_acc_R decimal(19,2),
	var_finphase_red_R decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),
	previsionkind char(1),
	showincomesurplus char(1),
	tosuppress char(1)
)



DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S' and @idupb<>'%')
BEGIN
	SET @idupb=@idupb+'%' 
END


declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'



DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

DECLARE @finphase tinyint
DECLARE @maxphase tinyint

declare @fin_kind tinyint
select @fin_kind = fin_kind
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
-- Se @fin_kin = 1 ==> è stata personalizzata una
-- previsione principale di tipo "competenza", se @fin_kin = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se
-- @fin_kin = 3 ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)

DECLARE @floatfund_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_01_jan_used decimal(19,2) 
DECLARE @aa_01_jan_used decimal(19,2) 
DECLARE @supposed_ff_01_jan_used decimal(19,2) 

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

	SELECT @floatfund_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='ff_jan01'
	
	SELECT @aa_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='aa_jan01'

	SELECT @supposed_ff_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_ff_jan01'
	
	SELECT @supposed_aa_01_jan_used = isnull(paramvalue,0) 
	FROM generalreportparameter 
	WHERE idparam='supposed_aa_jan01'
END


DECLARE @minlevelusable tinyint
SELECT  @minlevelusable = min(nlevel) FROM finlevel WHERE ayear = @ayear and (flag&2) <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minlevelusable)
begin
	SET @levelusable = @minlevelusable
end

if (@kind='C')
begin
insert into #data (
	idfin,	idupb,
	initialprevision
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision),0)
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)
end


if (@kind='S')
begin
insert into #data (
	idfin,	idupb,
	secondaryprev
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		case
			when @fin_kind = 2
				then ISNULL(SUM(finyear.prevision),0) 
				else ISNULL(SUM(finyear.secondaryprev),0)			
		end
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)

end



if (@kind='R')
begin
insert into #data (
	idfin,	idupb,
	currentarrears
)
select finyear.idfin,isnull(@fixedidupb,finyear.idupb),		
		ISNULL(SUM(finyear.currentarrears),0)
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb)
end






DECLARE @length1 int
DECLARE @pos1 int
DECLARE @length2 int
DECLARE @pos2 int
DECLARE @length3 int
DECLARE @pos3 int
DECLARE @length4 int
DECLARE @pos4 int
DECLARE @length5 int
DECLARE @pos5 int
SELECT @length1 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 1
SELECT @length2 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 2
SELECT @length3 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 3 
SELECT @length4 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 4
SELECT @length5 = flag / 256 FROM finlevel WHERE ayear = @ayear AND nlevel = 5
SELECT @pos1 = 1
SELECT @pos2 = @pos1 + @length1
SELECT @pos3 = @pos2 + @length2
SELECT @pos4 = @pos3 + @length3
SELECT @pos5 = @pos4 + @length4

-- calcolo del totale delle variazioni della
-- previsione principale
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



if (@kind='C')
begin
INSERT INTO #data
(
	idfin,
	idupb,
	varprev_m_acc
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin), 
	isnull(@fixedidupb,FVD.idupb),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND FVD.amount > 0
	AND FVD.idupb like @idupb
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)
end


if (@kind='C')
begin
INSERT INTO #data
(
	idfin,
	idupb,
	varprev_m_red
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	-ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F 
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND ((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FVD.amount < 0
	AND FVD.idupb like @idupb
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin) 
end


if (@kind='S')
begin
INSERT INTO #data
(
	idfin,
	idupb,
	varprev_s_acc
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original	
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.idfinvarstatus = 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	-- vogliamo le variazioni prev. di cassa
	AND (FV.flagsecondaryprev = 'S' and @fin_kind=3
		OR FV.flagprevision = 'S' and @fin_kind=2)
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND FVD.amount > 0
	AND FVD.idupb like @idupb
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)
end


if (@kind='S')
begin
INSERT INTO #data
(
	idfin,
	idupb,
	varprev_s_red
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	-ISNULL(SUM(FVD.amount),0)
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON FVD.idfin = F.idfin
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.idfinvarstatus = 5
	AND FV.adate <= @date
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
-- vogliamo le variazioni prev. di cassa
	AND ((FV.flagsecondaryprev = 'S' and @fin_kind = 3)
		OR (FV.flagprevision = 'S' and @fin_kind = 2))
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND FVD.amount < 0
	AND FVD.idupb like @idupb
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)
end


IF @finpart = 'E'
BEGIN


	if (@kind in ('C','R'))
	begin		
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_C
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		ISNULL(SUM(IY.amount),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
	AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	end

	if (@kind in ('C','R'))
	begin	
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_acc_C
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN income I
		ON I.idinc = IV.idinc
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND I.adate <= @date 
		AND IV.amount > 0
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	end


	if (@kind in ('C','R'))
	begin		
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_red_C
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN income I
		ON I.idinc = IV.idinc
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount < 0
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	end

	if (@kind ='R')
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_R
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		ISNULL(SUM(IY.amount),0)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--  Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb), ISNULL(FLK.idparent,IY.idfin)
	end


	if (@kind ='R')
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_acc_R
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--  Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount > 0
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	end


	if (@kind ='R')
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_red_R
	)
	SELECT 
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		ISNULL(SUM(IV.amount),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN income I
		ON I.idinc = IV.idinc
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--  Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount < 0
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	end



	INSERT INTO #data
	(
		idfin,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)--  Competenza
		AND HPV.ymov = @ayear
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)


	if (@kind in('S','R'))
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_R
	)
	SELECT
		ISNULL(FLK.idparent,IY.idfin),
		isnull(@fixedidupb,IY.idupb),
		SUM(HPV.amount)
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND IY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	end

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_C
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			--AND IY.nphase = @maxphase
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			/*AND EXISTS
				(SELECT * FROM historyproceedsview HPV
				WHERE HPV.idinc = IV.idinc
				AND HPV.competencydate <= @date
				AND HPV.ymov = @ayear)*/
			AND IY.idupb like @idupb
		GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	
		if (@kind in('S','R'))
		begin
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_R
		)
		SELECT 
			ISNULL(FLK.idparent,IY.idfin),
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount)
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc		
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = IY.idfin
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)--Residuo
			--AND IY.nphase = @maxphase
			AND FLK.nlevel = @levelusable_original
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND IV.adate <= @date
		AND IY.idupb like @idupb
		GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
		end
	END
END


IF @finpart = 'S'
BEGIN
	if (@kind in ('C','R'))
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_C
	)
	SELECT
		isnull(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		ISNULL(SUM(EY.amount),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp	
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	left outer JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0)-- Competenza
		AND E.nphase = @finphase
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(FLK.idparent,EY.idfin)
	end
---------------------------------------------------------------------------------------------------------------

	if (@kind in ('C','R'))
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_acc_C
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN expense E
		ON EV.idexp = E.idexp	
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original 
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount > 0
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	end


	if (@kind in ('C','R'))
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_red_C
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN expense E
		ON EV.idexp = E.idexp	
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND E.nphase = @finphase
		AND ( (ET.flag & 1) = 0) --Competenza
		AND EV.adate <= @date 
		AND EV.amount < 0
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 
	end


	if (@kind ='R')
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_finphase_R
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		ISNULL(SUM(EY.amount),0)
	FROM expenseyear EY
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original	
	WHERE EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND E.adate <= @date
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	end

	if (@kind ='R')
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_acc_R
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN expense E
		ON EV.idexp = E.idexp	
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount > 0
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	end

	if (@kind ='R')
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		var_finphase_red_R
	)
	SELECT 
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		ISNULL(SUM(EV.amount),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN expense E
		ON EV.idexp = E.idexp	
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
		AND EV.amount < 0
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	end


	INSERT INTO #data
	(
		idfin,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb), ISNULL(FLK.idparent,EY.idfin)

	if (@kind in ('R','S'))
	begin
	INSERT INTO #data
	(
		idfin,
		idupb,
		mov_maxphase_R
	)
	SELECT
		ISNULL(FLK.idparent,EY.idfin),
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount)
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)--  Residuo
		AND HPV.ymov = @ayear
		AND EY.idupb like @idupb
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	end

	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_C
		)
		SELECT 
			ISNULL(FLK.idparent,EY.idfin),
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			--AND EY.nphase = @maxphase
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear			
			AND EY.idupb like @idupb
		GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 
	

		if (@kind in ('R','S'))
		BEGIN		
		INSERT INTO #data
		(
			idfin,
			idupb,
			var_maxphase_R
		)
		SELECT 
			ISNULL(FLK.idparent,EY.idfin),
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND EV.adate <= @date
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND EY.idupb like @idupb
		GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 
		END
	END
END



IF @fin_kind = 2 and exists(select * from fin where ayear=@ayear and (flag&16 <>0) )
BEGIN

if exists(select * from fin F 
    left outer join #data D on D.idfin=F.idfin
     where F.ayear=@ayear and (F.flag&16 <>0)  and D.idfin is null)
 BEGIN 
  insert into #data (idfin,idupb,mov_maxphase_C)
   select F.idfin, '0001',0 
   from 
    fin F 
    left outer join #data D on D.idfin=F.idfin
     where F.ayear=@ayear and (F.flag&16 <>0)  and D.idfin is null
    
 END

 UPDATE #data SET mov_maxphase_C = ISNULL(initialprevision, 0) + ISNULL(varprev_m_acc, 0) - ISNULL(varprev_m_red, 0)
  where (select F.flag&16 from fin F where #data.idfin=F.idfin) <> 0

END


UPDATE #data SET tosuppress = 'N'


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



if (@levelusable_original<5) 
	set @lev_desc5='liv5'

if (@levelusable_original<4) 
	set @lev_desc4='liv4'

if (@levelusable_original<3) 
	set @lev_desc3='liv3'


if (@levelusable_original<2) 
	set @lev_desc2='liv2'



IF (@showupb ='S')
BEGIN

SELECT 
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1) as code1,
	f1.title AS desc1,
	@lev_desc1 AS lev_desc1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2) as code2,
	f2.title AS desc2,
	@lev_desc2 AS lev_desc2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3) as code3,
	f3.title as desc3,
	@lev_desc3 as lev_desc3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4)as code4,
	f4.title AS desc4,
	@lev_desc4 AS lev_desc4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5) as code5,
	f5.title AS desc5,
	@lev_desc5 AS lev_desc5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
		upb.codeupb,
	upb.idupb as idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
		ISNULL(SUM(initialprevision),0) AS initialprevision,
		ISNULL(SUM(varprev_m_acc),0) AS varprev_m_acc,
		ISNULL(SUM(varprev_m_red),0) AS varprev_m_red,
		ISNULL(SUM(secondaryprev),0) AS secondaryprev,
		ISNULL(SUM(varprev_s_acc),0) AS varprev_s_acc,
		ISNULL(SUM(varprev_s_red),0) AS varprev_s_red,
		ISNULL(SUM(currentarrears),0) AS currentarrears,
		ISNULL(SUM(mov_finphase_C),0) AS mov_finphase_C,
		ISNULL(SUM(var_finphase_acc_C),0) AS var_finphase_acc_C,
		ISNULL(SUM(var_finphase_red_C),0) AS var_finphase_red_C,
		ISNULL(SUM(mov_maxphase_C),0) AS mov_maxphase_C,
		ISNULL(SUM(var_maxphase_C),0) AS var_maxphase_C,
		ISNULL(SUM(mov_finphase_R),0) AS mov_finphase_R,
		ISNULL(SUM(var_finphase_acc_R),0) AS var_finphase_acc_R,
		ISNULL(SUM(var_finphase_red_R),0) AS var_finphase_red_R,
		ISNULL(SUM(mov_maxphase_R),0) AS mov_maxphase_R,
		ISNULL(SUM(var_maxphase_R),0) AS var_maxphase_R,
		case @fin_kind when 2 then 'S' else 'C' end AS previsionkind,
		showincomesurplus,
		@supposed_ff_jan01 AS supposed_ff_jan01,
		@supposed_aa_jan01 AS supposed_aa_jan01,
		@ff_jan01 AS ff_jan01,
		@aa_jan01 AS aa_jan01,
		isnull(#data.tosuppress, @suppressifblank) AS tosuppress,
		f.nlevel,
		isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
		isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
		isnull(@aa_01_jan_used,0) as aa_01_jan_used,
		isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used
	FROM fin f
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
	cross join  upb 
		left outer join #data on #data.idfin=f.idfin and #data.idupb=upb.idupb
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = f.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = f.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = f.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = f.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = f.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
		
	where  ( (@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (upb.idupb='0001' or isnull(#data.tosuppress, 'S')='N')) AND
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original 
			OR (f.nlevel < @levelusable_original
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
				AND (fl.flag&2)<>0
			   )
			 )
		and upb.idupb like @idupb
GROUP BY 
	upb.printingorder,#data.idupb,upb.idupb,upb.title,codeupb,
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1),
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2),
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3),
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4),
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5),
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	f1.title,f2.title,f3.title,f4.title,f5.title,
	showincomesurplus,f.nlevel,isnull(#data.tosuppress, @suppressifblank)	

	ORDER BY upb.printingorder ASC,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) ASC,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) ASC,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) ASC,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) ASC,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) ASC

END


IF (@showupb ='N')
BEGIN
declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)

if (@idupboriginal='%')
begin
	set @codeupb= null
	set @upb= null
	set @upbprintingorder= null
	set @ext_idupb= null
end
else
begin
	SET @upbprintingorder =
		(SELECT TOP 1 printingorder
		FROM upb
		WHERE idupb = @idupboriginal)
	SET  @upb =
		(SELECT TOP 1 title
		FROM upb
		WHERE idupb = @idupboriginal)
	SET  @ext_idupb =	@idupboriginal
	SET  @codeupb =
		(SELECT TOP 1 codeupb
		FROM upb	
		WHERE idupb = @idupboriginal)
end



SELECT 
	SUBSTRING(f.codefin, @startpos1, @lencod_lev1) as code1,
	f1.title AS desc1,
	@lev_desc1 AS lev_desc1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2) as code2,
	f2.title AS desc2,
	@lev_desc2 AS lev_desc2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3) as code3,
	f3.title as desc3,
	@lev_desc3 as lev_desc3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4)as code4,
	f4.title AS desc4,
	@lev_desc4 AS lev_desc4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5) as code5,
	f5.title AS desc5,
	@lev_desc5 AS lev_desc5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
		ISNULL(SUM(initialprevision),0) AS initialprevision,
		ISNULL(SUM(varprev_m_acc),0) AS varprev_m_acc,
		ISNULL(SUM(varprev_m_red),0) AS varprev_m_red,
		ISNULL(SUM(secondaryprev),0) AS secondaryprev,
		ISNULL(SUM(varprev_s_acc),0) AS varprev_s_acc,
		ISNULL(SUM(varprev_s_red),0) AS varprev_s_red,
		ISNULL(SUM(currentarrears),0) AS currentarrears,
		ISNULL(SUM(mov_finphase_C),0) AS mov_finphase_C,
		ISNULL(SUM(var_finphase_acc_C),0) AS var_finphase_acc_C,
		ISNULL(SUM(var_finphase_red_C),0) AS var_finphase_red_C,
		ISNULL(SUM(mov_maxphase_C),0) AS mov_maxphase_C,
		ISNULL(SUM(var_maxphase_C),0) AS var_maxphase_C,
		ISNULL(SUM(mov_finphase_R),0) AS mov_finphase_R,
		ISNULL(SUM(var_finphase_acc_R),0) AS var_finphase_acc_R,
		ISNULL(SUM(var_finphase_red_R),0) AS var_finphase_red_R,
		ISNULL(SUM(mov_maxphase_R),0) AS mov_maxphase_R,
		ISNULL(SUM(var_maxphase_R),0) AS var_maxphase_R,
		case @fin_kind when 2 then 'S' else 'C' end AS previsionkind,
		showincomesurplus,
		@supposed_ff_jan01 AS supposed_ff_jan01,
		@supposed_aa_jan01 AS supposed_aa_jan01,
		@ff_jan01 AS ff_jan01,
		@aa_jan01 AS aa_jan01,
		isnull(#data.tosuppress, @suppressifblank) AS tosuppress,
		f.nlevel,
		isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
		isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
		isnull(@aa_01_jan_used,0) as aa_01_jan_used,
		isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used
	FROM fin f
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
	left outer join #data on #data.idfin=f.idfin 
	LEFT OUTER JOIN finlink flk1
		ON flk1.idchild = f.idfin AND flk1.nlevel = 1
	LEFT OUTER JOIN fin f1
		ON flk1.idparent = f1.idfin 
	LEFT OUTER JOIN finlink flk2
		ON flk2.idchild = f.idfin AND flk2.nlevel = 2
	LEFT OUTER JOIN fin f2
		ON flk2.idparent = f2.idfin 
	LEFT OUTER JOIN finlink flk3
		ON flk3.idchild = f.idfin AND flk3.nlevel = 3
	LEFT OUTER JOIN fin f3
		ON flk3.idparent = f3.idfin 
	LEFT OUTER JOIN finlink flk4
		ON flk4.idchild = f.idfin AND flk4.nlevel = 4
	LEFT OUTER JOIN fin f4
		ON flk4.idparent = f4.idfin 
	LEFT OUTER JOIN finlink flk5
		ON flk5.idchild = f.idfin AND flk5.nlevel = 5
	LEFT OUTER JOIN fin f5
		ON flk5.idparent = f5.idfin 
where  ((@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (#data.idupb='0001' or isnull(#data.tosuppress, 'S')='N'))AND
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = @levelusable_original 
			OR (f.nlevel < @levelusable_original
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
				AND (fl.flag&2)<>0
			   )
			 )
	GROUP BY 
			SUBSTRING(f.codefin, @startpos1, @lencod_lev1),
	SUBSTRING(f.codefin, @startpos2, @lencod_lev2),
	SUBSTRING(f.codefin, @startpos3, @lencod_lev3),
	SUBSTRING(f.codefin, @startpos4, @lencod_lev4),
	SUBSTRING(f.codefin, @startpos5, @lencod_lev5),
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	f1.title,f2.title,f3.title,f4.title,f5.title,
	showincomesurplus,f.nlevel,
	isnull(#data.tosuppress, @suppressifblank)		

	ORDER BY 
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) ASC,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) ASC,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) ASC,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) ASC,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) ASC


END











END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


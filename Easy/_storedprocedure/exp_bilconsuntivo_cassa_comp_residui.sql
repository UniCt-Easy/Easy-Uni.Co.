
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_bilconsuntivo_cassa_comp_residui]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_bilconsuntivo_cassa_comp_residui]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- [exp_bilconsuntivo_cassa_comp_residui]  2017, {ts '2017-12-31 00:00:00'},'E',1,'%','N','N','S','N','C' 

CREATE  PROCEDURE [exp_bilconsuntivo_cassa_comp_residui]
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
	@kind char (1),  --C/S/R
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int  = null
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
		ISNULL(supposedcurrentexpenditure, 0)
	FROM surplus
	WHERE ayear = @ayear - 1
	--select @supposed_aa_jan01
	
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
		select isnull(FLK.idparent,finyear.idfin) ,isnull(@fixedidupb,finyear.idupb),
				ISNULL(SUM(finyear.prevision),0)
		from finyear 
		join fin f5 on finyear.idfin=f5.idfin
		JOIN upb U
			ON finyear.idupb = U.idupb
		JOIN finlevel fl
				ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
		left outer JOIN finlink FLK
			ON FLK.idchild = finyear.idfin AND FLK.nlevel = @levelusable_original
		where f5.ayear = @ayear
				AND (finyear.idupb LIKE @idupb)	
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
				AND (f5.nlevel = @levelusable
					OR (f5.nlevel < @levelusable
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
						AND (fl.flag&2)<>0
					   )
					)
				--AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )
		group by isnull(FLK.idparent,finyear.idfin) ,isnull(@fixedidupb,finyear.idupb),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
end


if (@kind='S')
begin
insert into #data (
	idfin,	idupb,
	secondaryprev
)
select  isnull(FLK.idparent,finyear.idfin),isnull(@fixedidupb,finyear.idupb),
		case
			when @fin_kind = 2
				then ISNULL(SUM(finyear.prevision),0) 
				else ISNULL(SUM(finyear.secondaryprev),0)			
		end
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN upb U
	ON finyear.idupb = U.idupb
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
left outer JOIN finlink FLK
	ON FLK.idchild = finyear.idfin AND FLK.nlevel = @levelusable_original
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		--AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by  isnull(FLK.idparent,finyear.idfin),isnull(@fixedidupb,finyear.idupb),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
end



if (@kind='R')
begin
insert into #data (
	idfin,	idupb,
	currentarrears
)
select  isnull(FLK.idparent,finyear.idfin),isnull(@fixedidupb,finyear.idupb),		
		ISNULL(SUM(finyear.currentarrears),0)
from finyear 
	join fin f5 on finyear.idfin=f5.idfin
JOIN upb U
	ON finyear.idupb = U.idupb
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
left outer JOIN finlink FLK
	ON FLK.idchild = finyear.idfin AND FLK.nlevel = @levelusable_original
where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (f5.nlevel = @levelusable
			OR (f5.nlevel < @levelusable
				AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
				AND (fl.flag&2)<>0
			   )
			)
		--AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by  isnull(FLK.idparent,finyear.idfin),isnull(@fixedidupb,finyear.idupb),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
end

-- calcolo del totale delle variazioni della
-- previsione principale

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
JOIN upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND FVD.amount > 0
	AND FVD.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
FROM finvardetail 
FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F 
	ON FVD.idfin = F.idfin
JOIN upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND ((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND FVD.amount < 0
	AND FVD.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin) 
,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
JOIN upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original	
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	-- vogliamo le variazioni prev. di cassa
	AND (FV.flagsecondaryprev = 'S' and @fin_kind=3
		OR FV.flagprevision = 'S' and @fin_kind=2)
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND FVD.amount > 0
	AND FVD.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)
,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
JOIN upb U
	ON FVD.idupb = U.idupb
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = FVD.idfin AND FLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
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
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin)
,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
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
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--  Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
		AND IY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb), ISNULL(FLK.idparent,IY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--  Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount > 0
		AND IY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--  Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND IV.amount < 0
		AND IY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON IY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)--  Competenza
		AND HPV.ymov = @ayear
		AND IY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

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
	JOIN upb U
		ON IY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = IY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND IY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
		JOIN upb U
			ON IY.idupb = U.idupb
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
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin) 
		,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
		
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
		JOIN upb U
			ON IY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb,IY.idupb),ISNULL(FLK.idparent,IY.idfin)
		,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original	
	WHERE EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND E.adate <= @date
		AND EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
	JOIN upb U
		ON EY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
		AND EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb), ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	
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
	JOIN upb U
		ON EY.idupb = U.idupb
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)--  Residuo
		AND HPV.ymov = @ayear
		AND EY.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
		JOIN upb U
			ON EY.idupb = U.idupb
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
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 
		,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

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
		JOIN upb U
			ON EY.idupb = U.idupb
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
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin) 
		,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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

 UPDATE #data SET mov_maxphase_C = ISNULL(initialprevision, 0) + ISNULL(varprev_m_acc, 0)- ISNULL(varprev_m_red, 0)
  where (select F.flag&16 from fin F where #data.idfin=F.idfin) <> 0

   

END


--UPDATE #data SET tosuppress = 'N'


if  (@suppressifblank='S' AND @kind ='C' )
begin 
	delete from #data where 
		ISNULL(initialprevision,0)+ISNULL(varprev_m_acc,0)-ISNULL(varprev_m_red,0)= 0 
		AND 
		ISNULL(mov_finphase_C,0) + ISNULL(var_finphase_acc_C,0) - ISNULL(var_finphase_red_C,0)=0 
		and ISNULL(mov_maxphase_C,0)  + ISNULL(var_maxphase_C,0) = 0
end 

if  (@suppressifblank='S' AND @kind ='S' )
begin 
	delete from #data where 
		ISNULL(secondaryprev,0)+ISNULL(varprev_s_acc,0)-ISNULL(varprev_s_red,0)= 0 
		AND 
		ISNULL(mov_maxphase_C,0) + ISNULL(var_maxphase_C,0) =0 
		AND
		ISNULL(mov_maxphase_R,0) +ISNULL(var_maxphase_R,0) =0
end 

if  (@suppressifblank='S' AND @kind ='R ' )
begin 
	delete from #data where 
		ISNULL(initialprevision,0)+ISNULL(varprev_m_acc,0)-ISNULL(varprev_m_red,0)= 0 
		AND 
		ISNULL(mov_finphase_C,0) + ISNULL(var_finphase_acc_C,0) - ISNULL(var_finphase_red_C,0)=0 
		AND 
		ISNULL(mov_maxphase_C,0) + ISNULL(var_maxphase_C,0) =0 
		AND
		ISNULL(mov_finphase_R,0) + ISNULL(var_finphase_acc_R,0) - ISNULL(var_finphase_red_R,0)=0 
		AND
		ISNULL(mov_maxphase_R,0) +ISNULL(var_maxphase_R,0) =0
end 

declare 	@codeupb varchar(50)
declare		@upb varchar(150)
declare		@upbprintingorder varchar(50)
declare		@ext_idupb varchar(50)

IF ((@showupb ='S') and @kind='C')
BEGIN
	SELECT 
			upb.idupb as idupb,	
			f.codefin as 'Codice Bilancio',
			f.title AS 'Denominazione Bilancio',
			upb.codeupb as 'Codice UPB',
			upb.title as 'Denominazione UPB',
			ISNULL(SUM(initialprevision),0) AS 'Previsione iniziale',
			ISNULL(SUM(varprev_m_acc),0) AS 'Variazioni in aumento',
			-ISNULL(SUM(varprev_m_red),0) AS 'Variazioni in diminuzione',-- Le visualizziamo col segno meno
			ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) 
				AS 'Previsione attuale',--i
			--ISNULL(SUM(secondaryprev),0) AS 'Previsione secondaria',
			--ISNULL(SUM(varprev_s_acc),0) AS 'Variazioni in aumento prev. sec.',
			--ISNULL(SUM(varprev_s_red),0) AS 'Variazioni in diminuzione prev. sec',
			ISNULL(SUM(mov_finphase_C),0) AS 'Impegni/Accertamenti',
			ISNULL(SUM(var_finphase_acc_C),0) AS 'Variazioni in aumento su impegni/accertamenti',
			ISNULL(SUM(var_finphase_red_C),0) AS 'Variazioni in diminuzione su impegni/accertamenti',
			ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) 
			- ISNULL(SUM(mov_finphase_C),0) 
			- ISNULL(SUM(var_finphase_acc_C),0) 
			- ISNULL(SUM(var_finphase_red_C),0)
					AS 'Previsione disponibile',
			ISNULL(SUM(mov_maxphase_C),0) AS 'Pagamenti/Incassi in Conto competenza',
			ISNULL(SUM(var_maxphase_C),0) AS 'Variazioni su pagamenti/incassi in C/Competenza'--,
			--ISNULL(SUM(mov_finphase_R),0) AS 'Residui al 01 gennaio',
			--ISNULL(SUM(var_finphase_acc_R),0) AS 'Variazioni in aumento su residui',
			--ISNULL(SUM(var_finphase_red_R),0) AS 'Variazioni in diminuzione su residui',
			--ISNULL(SUM(mov_maxphase_R),0) AS 'Pagamenti/Incassi in C/Residui',
			--ISNULL(SUM(var_maxphase_R),0) AS 'Variazioni su pagamenti in C/Residui'
			FROM fin f
			JOIN finlevel fl
				ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear	
			cross join  upb 
				left outer join #data 
			on #data.idfin=f.idfin and #data.idupb=upb.idupb
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
				ON 	flk4.idchild = f.idfin AND flk4.nlevel = 4
			LEFT OUTER JOIN fin f4
				ON flk4.idparent = f4.idfin 
			LEFT OUTER JOIN finlink flk5
				ON flk5.idchild = f.idfin AND flk5.nlevel = 5
			LEFT OUTER JOIN fin f5
				ON flk5.idparent = f5.idfin 
			where   ( @suppressifblank='N'  
						or ( @suppressifblank='S' and   #data.idfin is not null)
						OR  upb.idupb='0001' /*or isnull(#data.tosuppress, 'S')='N'*/
						)  
				AND	f.ayear=@ayear 
				AND ((f.flag & 1)= @finpart_bit) 
				AND (f.nlevel = @levelusable_original 
					OR (f.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						AND (fl.flag&2)<>0
					   )
					 )
				and upb.idupb like @idupb
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))
		GROUP BY  f.codefin,	f.title , upb.codeupb , upb.idupb ,	upb.title 
		ORDER BY upb.idupb ASC, f.codefin ASC
END

IF ((@showupb ='S') and @kind='R')
BEGIN

		SELECT 
			upb.idupb as idupb,	f.codefin as 'Codice Bilancio',
			f.title AS 'Denominazione Bilancio',
			upb.codeupb as 'Codice UPB',
			upb.title as 'Denominazione UPB',
				--ISNULL(SUM(initialprevision),0) AS 'Previsione iniziale',
				--ISNULL(SUM(varprev_m_acc),0) AS 'Variazioni in aumento',
				--ISNULL(SUM(varprev_m_red),0) AS 'Variazioni in diminuzione',
				--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) AS 'Previsione attuale',
				--ISNULL(SUM(secondaryprev),0) AS 'Previsione secondaria',
				--ISNULL(SUM(varprev_s_acc),0) AS 'Variazioni in aumento prev. sec.',
				--ISNULL(SUM(varprev_s_red),0) AS 'Variazioni in diminuzione prev. sec',
				--ISNULL(SUM(mov_finphase_C),0) AS 'Impegni/Accertamenti',
				--ISNULL(SUM(var_finphase_acc_C),0) AS 'Variazioni in aumento su impegni',
				--ISNULL(SUM(var_finphase_red_C),0) AS 'Variazioni in diminuzione su impegni',
				--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) -
				--ISNULL(SUM(mov_finphase_C),0) - ISNULL(SUM(var_finphase_acc_C),0) - ISNULL(SUM(var_finphase_red_C),0) AS 'Previsione disponibile',
				--ISNULL(SUM(mov_maxphase_C),0) AS 'Pagamenti/Incassi in Conto competenza',
				--ISNULL(SUM(var_maxphase_C),0) AS 'Variazioni su pagamenti in C/Competenza',
				ISNULL(SUM(mov_finphase_R),0) AS 'Residui al 01 gennaio',
				ISNULL(SUM(var_finphase_acc_R),0) AS 'Variazioni in aumento su residui',
				ISNULL(SUM(var_finphase_red_R),0) AS 'Variazioni in diminuzione su residui',
				ISNULL(SUM(mov_maxphase_R),0) AS 'Pagamenti/Incassi in C/Residui',
				ISNULL(SUM(var_maxphase_R),0) AS 'Variazioni su pagamenti/incassi in C/Residui'
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
				ON 	flk4.idchild = f.idfin AND flk4.nlevel = 4
			LEFT OUTER JOIN fin f4
				ON flk4.idparent = f4.idfin 
			LEFT OUTER JOIN finlink flk5
				ON flk5.idchild = f.idfin AND flk5.nlevel = 5
			LEFT OUTER JOIN fin f5
				ON flk5.idparent = f5.idfin 
			where    ( @suppressifblank='N'  or ( @suppressifblank='S' and   #data.idfin is not null) OR  upb.idupb='0001' 			)  
				and f.ayear=@ayear 
				AND ((f.flag & 1)= @finpart_bit) 
				AND (f.nlevel = @levelusable_original 
					OR (f.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						AND (fl.flag&2)<>0
					   )
					 )
				and upb.idupb like @idupb
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))
		GROUP BY f.codefin,	f.title , upb.codeupb , upb.idupb ,	upb.title 
		ORDER BY upb.idupb ASC, f.codefin ASC
END
IF ((@showupb ='S') and @kind='S')
BEGIN

		SELECT 
			upb.idupb as idupb,	f.codefin as 'Codice Bilancio',
			f.title AS 'Denominazione Bilancio',
			upb.codeupb as 'Codice UPB',
			upb.title as 'Denominazione UPB',
			--ISNULL(SUM(initialprevision),0) AS 'Previsione iniziale',
			--ISNULL(SUM(varprev_m_acc),0) AS 'Variazioni in aumento',
			--ISNULL(SUM(varprev_m_red),0) AS 'Variazioni in diminuzione',
			--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) AS 'Previsione attuale',
			ISNULL(SUM(secondaryprev),0) AS 'Previsione secondaria',
			ISNULL(SUM(varprev_s_acc),0) AS 'Variazioni in aumento prev. sec.',
			- ISNULL(SUM(varprev_s_red),0) AS 'Variazioni in diminuzione prev. sec',-- Le visualizziamo col segno meno
			--ISNULL(SUM(mov_finphase_C),0) AS 'Impegni/Accertamenti',
			--ISNULL(SUM(var_finphase_acc_C),0) AS 'Variazioni in aumento su impegni',
			--ISNULL(SUM(var_finphase_red_C),0) AS 'Variazioni in diminuzione su impegni',
			--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) -
			--ISNULL(SUM(mov_finphase_C),0) - ISNULL(SUM(var_finphase_acc_C),0) - ISNULL(SUM(var_finphase_red_C),0) AS 'Previsione disponibile',
			ISNULL(SUM(mov_maxphase_C),0) AS 'Pagamenti/Incassi in Conto competenza',
			ISNULL(SUM(var_maxphase_C),0) AS 'Variazioni su pagamenti/incassi in C/Competenza',
			--ISNULL(SUM(mov_finphase_R),0) AS 'Residui al 01 gennaio',
			--ISNULL(SUM(var_finphase_acc_R),0) AS 'Variazioni in aumento su residui',
			--ISNULL(SUM(var_finphase_red_R),0) AS 'Variazioni in diminuzione su residui',
			ISNULL(SUM(mov_maxphase_R),0) AS 'Pagamenti/Incassi in C/Residui',
			ISNULL(SUM(var_maxphase_R),0) AS 'Variazioni su pagamenti/incassi in C/Residui'
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
				ON 	flk4.idchild = f.idfin AND flk4.nlevel = 4
			LEFT OUTER JOIN fin f4
				ON flk4.idparent = f4.idfin 
			LEFT OUTER JOIN finlink flk5
				ON flk5.idchild = f.idfin AND flk5.nlevel = 5
			LEFT OUTER JOIN fin f5
				ON flk5.idparent = f5.idfin 
			where    ( @suppressifblank='N'  or ( @suppressifblank='S' and   #data.idfin is not null) OR  upb.idupb='0001' 			)  AND
				f.ayear=@ayear 
				AND ((f.flag & 1)= @finpart_bit) 
				AND (f.nlevel = @levelusable_original 
					OR (f.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						AND (fl.flag&2)<>0
					   )
					 )
				and upb.idupb like @idupb
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))
		GROUP BY f.codefin,	f.title , upb.codeupb , upb.idupb ,	upb.title 
		ORDER BY upb.idupb ASC, f.codefin ASC
END

IF ((@showupb ='N') and @kind='C')
BEGIN

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
			f.codefin,
			f.title AS desc1,
			@codeupb as 'Codice UPB',
			@upb as upb,
			ISNULL(SUM(initialprevision),0) AS 'Previsione iniziale',
			ISNULL(SUM(varprev_m_acc),0) AS 'Variazioni in aumento',
			- ISNULL(SUM(varprev_m_red),0) AS 'Variazioni in diminuzione',-- Le visualizziamo col segno meno
			ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) AS 'Previsione attuale',---h
			--ISNULL(SUM(secondaryprev),0) AS 'Previsione secondaria',
			--ISNULL(SUM(varprev_s_acc),0) AS 'Variazioni in aumento prev. sec.',
			--ISNULL(SUM(varprev_s_red),0) AS 'Variazioni in diminuzione prev. sec',
			ISNULL(SUM(mov_finphase_C),0) AS 'Impegni/Accertamenti',--i
			ISNULL(SUM(var_finphase_acc_C),0) AS 'Variazioni in aumento su impegni/accertamenti',
			ISNULL(SUM(var_finphase_red_C),0) AS 'Variazioni in diminuzione su impegni/accertamenti',
			ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) 
			- ISNULL(SUM(mov_finphase_C),0)
			- ISNULL(SUM(var_finphase_acc_C),0)
			- ISNULL(SUM(var_finphase_red_C),0)  AS 'Previsione disponibile',
			ISNULL(SUM(mov_maxphase_C),0) AS 'Pagamenti/Incassi in Conto competenza',
			ISNULL(SUM(var_maxphase_C),0) AS 'Variazioni su pagamenti/incassi in C/Competenza'--,
			--ISNULL(SUM(mov_finphase_R),0) AS 'Residui al 01 gennaio',
			--ISNULL(SUM(var_finphase_acc_R),0) AS 'Variazioni in aumento su residui',
			--ISNULL(SUM(var_finphase_red_R),0) AS 'Variazioni in diminuzione su residui',
			--ISNULL(SUM(mov_maxphase_R),0) AS 'Pagamenti/Incassi in C/Residui',
			--(SUM(var_maxphase_R),0) AS 'Variazioni su pagamenti in C/Residui'
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
		where    ( @suppressifblank='N'  or ( @suppressifblank='S' and   #data.idfin is not null) OR  #data.idupb='0001'	)  
				AND f.ayear=@ayear 
				AND ((f.flag & 1)= @finpart_bit) 
				AND (f.nlevel = @levelusable_original 
					 OR (f.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						AND (fl.flag&2)<>0
					    )
					 )
				and @suppressifblank='S'
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) )) 
			GROUP BY 
					f.codefin, 	f.title	
			ORDER BY f.codefin ASC

END

IF ((@showupb ='N') and @kind='R')
BEGIN
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
			f.codefin,
			f.title AS desc1,
			@codeupb as 'Codice UPB',
			@upb as upb,
				--ISNULL(SUM(initialprevision),0) AS 'Previsione iniziale',
				--ISNULL(SUM(varprev_m_acc),0) AS 'Variazioni in aumento',
				--ISNULL(SUM(varprev_m_red),0) AS 'Variazioni in diminuzione',
				--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) AS 'Previsione attuale',
				--ISNULL(SUM(secondaryprev),0) AS 'Previsione secondaria',
				--ISNULL(SUM(varprev_s_acc),0) AS 'Variazioni in aumento prev. sec.',
				--ISNULL(SUM(varprev_s_red),0) AS 'Variazioni in diminuzione prev. sec',
				--ISNULL(SUM(mov_finphase_C),0) AS 'Impegni/Accertamenti',
				--ISNULL(SUM(var_finphase_acc_C),0) AS 'Variazioni in aumento su impegni',
				--ISNULL(SUM(var_finphase_red_C),0) AS 'Variazioni in diminuzione su impegni',
				--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) -
				--ISNULL(SUM(mov_finphase_C),0) + ISNULL(SUM(var_finphase_acc_C),0) - ISNULL(SUM(var_finphase_red_C),0) AS 'Previsione disponibile',
				--ISNULL(SUM(mov_maxphase_C),0) AS 'Pagamenti/Incassi in Conto competenza',
				--ISNULL(SUM(var_maxphase_C),0) AS 'Variazioni su pagamenti in C/Competenza',
				ISNULL(SUM(mov_finphase_R),0) AS 'Residui al 01 gennaio',
				ISNULL(SUM(var_finphase_acc_R),0) AS 'Variazioni in aumento su residui',
				ISNULL(SUM(var_finphase_red_R),0) AS 'Variazioni in diminuzione su residui',
				ISNULL(SUM(mov_maxphase_R),0) AS 'Pagamenti/Incassi in C/Residui',
				ISNULL(SUM(var_maxphase_R),0) AS 'Variazioni su pagamenti/incassi in C/Residui'
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
		where    ( @suppressifblank='N'  or ( @suppressifblank='S' and   #data.idfin is not null) OR  #data.idupb='0001'	)  
				AND f.ayear=@ayear 
				AND ((f.flag & 1)= @finpart_bit) 
				AND (f.nlevel = @levelusable_original 
					 OR (f.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						AND (fl.flag&2)<>0
					    )
					 )
				and @suppressifblank='S'
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))
			GROUP BY 
					f.codefin, 	f.title	
			ORDER BY f.codefin ASC

END


IF ((@showupb ='N') and @kind='S')
BEGIN
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
			f.codefin,
			f.title AS desc1,
			@codeupb as 'Codice UPB',
			@upb as upb,
				--ISNULL(SUM(initialprevision),0) AS 'Previsione iniziale',
				--ISNULL(SUM(varprev_m_acc),0) AS 'Variazioni in aumento',
				--ISNULL(SUM(varprev_m_red),0) AS 'Variazioni in diminuzione',
				--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) AS 'Previsione attuale',
				ISNULL(SUM(secondaryprev),0) AS 'Previsione secondaria',
				ISNULL(SUM(varprev_s_acc),0) AS 'Variazioni in aumento prev. sec.',
				ISNULL(SUM(varprev_s_red),0) AS 'Variazioni in diminuzione prev. sec',
				--ISNULL(SUM(mov_finphase_C),0) AS 'Impegni/Accertamenti',
				--ISNULL(SUM(var_finphase_acc_C),0) AS 'Variazioni in aumento su impegni',
				--ISNULL(SUM(var_finphase_red_C),0) AS 'Variazioni in diminuzione su impegni',
				--ISNULL(SUM(initialprevision),0)+ISNULL(SUM(varprev_m_acc),0)-ISNULL(SUM(varprev_m_red),0) -
				--ISNULL(SUM(mov_finphase_C),0) + ISNULL(SUM(var_finphase_acc_C),0) - ISNULL(SUM(var_finphase_red_C),0) AS 'Previsione disponibile',
				ISNULL(SUM(mov_maxphase_C),0) AS 'Pagamenti/Incassi in Conto competenza',
				ISNULL(SUM(var_maxphase_C),0) AS 'Variazioni su pagamenti/Incassi in C/Competenza',
				--ISNULL(SUM(mov_finphase_R),0) AS 'Residui al 01 gennaio',
				--ISNULL(SUM(var_finphase_acc_R),0) AS 'Variazioni in aumento su residui',
				--ISNULL(SUM(var_finphase_red_R),0) AS 'Variazioni in diminuzione su residui',
				ISNULL(SUM(mov_maxphase_R),0) AS 'Pagamenti/Incassi in C/Residui',
				ISNULL(SUM(var_maxphase_R),0) AS 'Variazioni su pagamenti/Incassi in C/Residui'
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
		where    ( @suppressifblank='N'  or ( @suppressifblank='S' and   #data.idfin is not null) OR  #data.idupb='0001' 			)  
				AND f.ayear=@ayear 
				AND ((f.flag & 1)= @finpart_bit) 
				AND (f.nlevel = @levelusable_original 
					 OR (f.nlevel < @levelusable_original
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						AND (fl.flag&2)<>0
					    )
					 )
				and @suppressifblank='S'
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))
			GROUP BY 
					f.codefin, 	f.title	
			ORDER BY f.codefin ASC

END





END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

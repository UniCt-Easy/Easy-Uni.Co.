
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilconsuntivosorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilconsuntivosorting]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
-- update generalreportparameter set paramvalue='S' WHERE idparam = 'MostraTutteVoci'
-- exec rpt_bilconsuntivosorting 2013,{ts '2013-12-31 00:00:00'},'E',1,'%','N','N','S','S', null, null, null, null, null,50
-- exec rpt_bilconsuntivosorting  2016, {ts '2015-12-31 00:00:00'}, 'E', 3, '0001', 'N', 'N', 'N', 'N', NULL, NULL, NULL, NULL, NULL, 20
-- select * from 
CREATE       PROCEDURE [rpt_bilconsuntivosorting]
(
	@ayear int,
	@date datetime,
	@finpart char(1)='S',
	@levelusable tinyint=3,
	@idupb varchar(36)='%',
	@showupb char(1)='N',
	@showchildupb char(1)='S',
	@suppressifblank char(1)='S',
	@officialvar  char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@idsorkindfin int
)
AS BEGIN

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'


DECLARE	@finpart_bit  tinyint  -- Parte del bilancio ( Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear


DECLARE @MostraTutteVoci char(1)
SELECT  @MostraTutteVoci = isnull(paramvalue,'N') 
FROM    generalreportparameter WHERE idparam = 'MostraTutteVoci'


DECLARE @MAXoplevel tinyint
SELECT @MAXoplevel = MAX(nlevel)
FROM sortinglevel
WHERE idsorkind = @idsorkindfin

-- SE non è stato selezionato il livello, prende l'ultimo livello operativo
if(isnull(@levelusable,0)=0 )
Begin
	set @levelusable = @MAXoplevel
End
	
DECLARE @minoplevel tinyint

SELECT @minoplevel = MIN(nlevel) FROM sortinglevel 
WHERE idsorkind = @idsorkindfin AND (flag&2)<>0


DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minoplevel)-- se decidi di fare la stampa per categoria
begin
	SET @levelusable = @minoplevel
end

CREATE TABLE #data
(
	idsor int,
	idupb varchar(36),
	initialprevision decimal(19,2),
	variation decimal(19,2),
	secondaryprevision decimal(19,2),
	secondaryvariation decimal(19,2),
	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_R decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),
	showincomesurplus char(1),
	flagadvance char(1),
	tosuppress char(1)
)


DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @finphase tinyint
DECLARE @maxphase tinyint
IF @finpart = 'E'
BEGIN
	SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = incomefinphase FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
ELSE
BEGIN
	SELECT @finphase = appropriationphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM expensephase
END
DECLARE @cashvaliditykind int
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @supposed_ff_jan01 decimal(19,2)
DECLARE @supposed_aa_jan01 decimal(19,2)
DECLARE @ff_jan01 decimal(19,2)
DECLARE @aa_jan01 decimal(19,2)

DECLARE @floatfund_01_jan_used decimal(19,2) 
DECLARE @supposed_aa_01_jan_used decimal(19,2) 
DECLARE @aa_01_jan_used decimal(19,2) 
DECLARE @supposed_ff_01_jan_used decimal(19,2) 

IF @finpart = 'E'
BEGIN
	SELECT
	@supposed_ff_jan01 =
		ISNULL(startfloatfund, 0) +
		ISNULL(proceedstilldate, 0) -
		ISNULL(paymentstilldate, 0) +
		ISNULL(proceedstoendofyear, 0) -
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

insert into #data (
	idsor,
	idupb,
	initialprevision,
	secondaryprevision
)
select isnull(SLK.idparent, sorFin.idsor) ,
	isnull(@fixedidupb,finyear.idupb),
		ISNULL(SUM(finyear.prevision*ISNULL(FS.quota,0)),0),ISNULL(SUM(finyear.secondaryprev*ISNULL(FS.quota,0)),0)
from finyear 
	join fin f5			on finyear.idfin=f5.idfin
JOIN upb U				ON finyear.idupb = U.idupb
JOIN finsorting FS		ON FS.idfin = f5.idfin	
JOIN sorting sorFin		ON sorFin.idsor = FS.idsor				
JOIN sortinglevel sl 	ON sorFin.nlevel = sl.nlevel 
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original

where f5.ayear = @ayear
		AND (finyear.idupb LIKE @idupb)	
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin

		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )-- f5.flagincomesurplus = 'N')
group by  isnull(SLK.idparent, sorFin.idsor),isnull(@fixedidupb,finyear.idupb)



--select SUBSTRING('123456789', 12, 5)
--tutti gli inserimenti avvengono a livello di @levelusable o inferiore se per quel ramo non esiste un livello così basso
INSERT INTO #data
(
	idsor,
	idupb,
	variation
)
SELECT
	isnull(SLK.idparent, sorFin.idsor) ,
	isnull(@fixedidupb,FVD.idupb),
	SUM(FVD.amount*ISNULL(FS.quota,0))
FROM finvardetail FVD
JOIN finvar FV			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
JOIN fin F				ON FVD.idfin = F.idfin
JOIN upb U				ON FVD.idupb = U.idupb
JOIN finsorting FS		ON FS.idfin = F.idfin	
JOIN sorting sorFin		ON sorFin.idsor = FS.idsor				
JOIN sortinglevel sl	ON sorFin.nlevel = sl.nlevel 
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(SLK.idparent, sorFin.idsor),isnull(@fixedidupb,FVD.idupb)


INSERT INTO #data
(
	idsor,
	idupb,
	secondaryvariation
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	isnull(@fixedidupb,FVD.idupb),
	SUM(FVD.amount*ISNULL(FS.quota,0)) 
FROM finvardetail FVD
JOIN finvar FV			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
JOIN  fin F				ON FVD.idfin = F.idfin
JOIN upb U				ON FVD.idupb = U.idupb
JOIN finsorting FS		ON FS.idfin = F.idfin	
JOIN sorting sorFin		ON sorFin.idsor = FS.idsor				
JOIN sortinglevel sl	ON sorFin.nlevel = sl.nlevel 
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
	AND (FVD.idupb LIKE @idupb)
	AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
	AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb,FVD.idupb),isnull(SLK.idparent, sorFin.idsor)


IF (@finpart = 'E')
BEGIN
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_finphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,IY.idupb),
		SUM(IY.amount*ISNULL(FS.quota,0))
	FROM income I
	JOIN incomeyear IY				ON IY.idinc = I.idinc
	JOIN upb U						ON IY.idupb = U.idupb
	JOIN fin F						ON IY.idfin = F.idfin
	JOIN incometotal IT				ON IT.idinc = IY.idinc	AND IT.ayear = IY.ayear
	JOIN finsorting FS				ON FS.idfin = IY.idfin	
	JOIN sorting sorFin				ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE I.adate <= @date
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND (IY.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),isnull(SLK.idparent, sorFin.idsor)

	INSERT INTO #data
	(
		idsor,
		idupb,
		var_finphase_C
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,IY.idupb),
		SUM(IV.amount*ISNULL(FS.quota,0))
	FROM incomevar IV
	JOIN income I				ON IV.idinc = I.idinc
	JOIN incomeyear IY			ON IY.idinc = IV.idinc
	JOIN upb U					ON IY.idupb = U.idupb
	JOIN fin F					ON IY.idfin = F.idfin
	JOIN incometotal IT			ON IT.idinc = IY.idinc	AND IT.ayear = IY.ayear
	JOIN finsorting FS			ON FS.idfin = IY.idfin	
	JOIN sorting sorFin			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND (IY.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),isnull(SLK.idparent, sorFin.idsor) 
	
IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_finphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,IY.idupb),
		SUM(IY.amount*ISNULL(FS.quota,0))
	FROM incomeyear IY
	JOIN income I				ON I.idinc = IY.idinc
	JOIN incometotal IT			ON IT.idinc = IY.idinc	AND IT.ayear = IY.ayear
	JOIN upb U					ON IY.idupb = U.idupb
	JOIN fin F					ON IY.idfin = F.idfin
	JOIN finsorting FS			ON FS.idfin = IY.idfin	
	JOIN sorting sorFin			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND I.adate <= @date
		AND (IY.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),isnull(SLK.idparent, sorFin.idsor) 
end

IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idsor,
		idupb,
		var_finphase_R
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,IY.idupb),
		SUM(IV.amount*ISNULL(FS.quota,0))
	FROM incomevar IV
	JOIN income I				ON I.idinc = IV.idinc
	JOIN incomeyear IY			ON IY.idinc = IV.idinc
	JOIN upb U					ON IY.idupb = U.idupb
	JOIN fin F					ON IY.idfin = F.idfin
	JOIN incometotal IT			ON IT.idinc = IY.idinc	AND IT.ayear = IY.ayear
	JOIN finsorting FS			ON FS.idfin = IY.idfin	
	JOIN sorting sorFin			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE IV.yvar = @ayear
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
		AND (IY.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,IY.idupb),isnull(SLK.idparent, sorFin.idsor)

end

	INSERT INTO #data
	(
		idsor,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,HPV.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historyproceedsview HPV
	JOIN upb U						ON HPV.idupb = U.idupb
	JOIN fin F						ON HPV.idfin = F.idfin		
	LEFT OUTER JOIN finlink FLK		ON FLK.idchild = HPV.idfin AND FLK.nlevel = @levelusable_original
	JOIN finsorting FS				ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin				ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 0)--Competenza
		AND HPV.ymov = @ayear
		AND (HPV.idupb LIKE @idupb)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,HPV.idupb), isnull(SLK.idparent, sorFin.idsor) --
	
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_maxphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,HPV.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historyproceedsview HPV
	JOIN upb U						ON HPV.idupb = U.idupb
	JOIN fin F						ON HPV.idfin = F.idfin	
	JOIN finsorting FS				ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin				ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND (HPV.idupb LIKE @idupb)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,HPV.idupb),isnull(SLK.idparent, sorFin.idsor)
	
	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idsor,
			idupb,
			var_maxphase_C
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount*ISNULL(FS.quota,0))
		FROM incomevar IV
		JOIN incomeyear IY				ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV	ON HPV.idinc = IV.idinc
		JOIN upb U						ON HPV.idupb = U.idupb
		JOIN fin F						ON HPV.idfin = F.idfin
		JOIN finsorting FS				ON FS.idfin = HPV.idfin	
		JOIN sorting sorFin				ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND (HPV.competencydate <= @date AND HPV.ymov = @ayear)
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
			AND (IY.idupb LIKE @idupb)	
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
		GROUP BY isnull(@fixedidupb,IY.idupb),isnull(SLK.idparent, sorFin.idsor)
		
		INSERT INTO #data
		(
			idsor,
			idupb,
			var_maxphase_R
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,IY.idupb),
			SUM(IV.amount*ISNULL(FS.quota,0))
		FROM incomevar IV
		JOIN incomeyear IY					ON IY.idinc = IV.idinc
		JOIN historyproceedsview HPV		ON HPV.idinc = IV.idinc
		JOIN upb U							ON HPV.idupb = U.idupb
		JOIN fin F							ON HPV.idfin = F.idfin
		JOIN finsorting FS					ON FS.idfin = HPV.idfin	
		JOIN sorting sorFin					ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl				ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE IV.yvar = @ayear
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND IV.adate <= @date
			AND (HPV.competencydate <= @date AND HPV.ymov = @ayear)
			AND (IY.idupb LIKE @idupb)	
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
				   )
				)
			
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
		GROUP BY isnull(@fixedidupb,IY.idupb),isnull(SLK.idparent, sorFin.idsor) 
	END
END
IF (@finpart = 'S')
BEGIN
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_finphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,EY.idupb),
		SUM(EY.amount*ISNULL(FS.quota,0))
	FROM expense E
	JOIN expenseyear EY					ON EY.idexp = E.idexp
	JOIN upb U							ON EY.idupb = U.idupb
	JOIN fin F							ON EY.idfin = F.idfin
	JOIN expensetotal ET				ON ET.idexp = EY.idexp	AND ET.ayear = EY.ayear		
	JOIN finsorting FS					ON FS.idfin = EY.idfin	
	JOIN sorting sorFin					ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl				ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(SLK.idparent, sorFin.idsor)
	
	INSERT INTO #data
	(
		idsor,
		idupb,
		var_finphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,EY.idupb),
		SUM(EV.amount*ISNULL(FS.quota,0))
	FROM expensevar EV
	JOIN expense E					ON EV.idexp = E.idexp
	JOIN expenseyear EY				ON EY.idexp = EV.idexp
	JOIN upb U						ON EY.idupb = U.idupb
	JOIN fin F						ON EY.idfin = F.idfin
	JOIN expensetotal ET			ON ET.idexp = EY.idexp	AND ET.ayear = EY.ayear
	JOIN finsorting FS				ON FS.idfin = EY.idfin	
	JOIN sorting sorFin				ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date 
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)	
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(SLK.idparent, sorFin.idsor)

IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idsor,
		idupb,	
		mov_finphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,EY.idupb),
		SUM(EY.amount*ISNULL(FS.quota,0))
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN fin F
			ON EY.idfin = F.idfin
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finsorting FS
			ON FS.idfin = EY.idfin	
	JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)	
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
	GROUP BY isnull(@fixedidupb,EY.idupb), isnull(SLK.idparent, sorFin.idsor)

end

IF(	@fin_kind IN ('1','3'))
Begin
	INSERT INTO #data
	(
		idsor,
		idupb,	
		var_finphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,EY.idupb),
		SUM(EV.amount*ISNULL(FS.quota,0))
	FROM expensevar EV
	JOIN expense E
		ON EV.idexp = E.idexp
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN fin F
			ON EY.idfin = F.idfin
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finsorting FS
			ON FS.idfin = EY.idfin	
	JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE EV.yvar = @ayear
		AND EV.adate <= @date 
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND (EY.idupb LIKE @idupb)
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(SLK.idparent, sorFin.idsor)

end

	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_maxphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN fin F
			ON EY.idfin = F.idfin
	JOIN finsorting FS
			ON FS.idfin = EY.idfin	
	JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
		AND (EY.idupb LIKE @idupb)	
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)	
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(SLK.idparent, sorFin.idsor)

	
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_maxphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,EY.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN fin F
			ON EY.idfin = F.idfin
	JOIN finsorting FS
			ON FS.idfin = EY.idfin	
	JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
	WHERE HPV.competencydate <= @date
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
		AND (EY.idupb LIKE @idupb)	
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
	GROUP BY isnull(@fixedidupb,EY.idupb),isnull(SLK.idparent, sorFin.idsor)

	
	IF (@cashvaliditykind <> 4)
	BEGIN
		INSERT INTO #data
		(
			idsor,
			idupb,
			var_maxphase_C
		)
		SELECT
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount*ISNULL(FS.quota,0))
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN fin F
			ON EY.idfin = F.idfin
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		JOIN finsorting FS
			ON FS.idfin = HPV.idfin	
		JOIN sorting sorFin
				ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
				ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)--Competenza
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND (EY.idupb LIKE @idupb)
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)	
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )	
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
		GROUP BY isnull(@fixedidupb,EY.idupb),isnull(SLK.idparent, sorFin.idsor)

		INSERT INTO #data
		(
			idsor,
			idupb,
			var_maxphase_R
		)
		SELECT
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,EY.idupb),
			SUM(EV.amount*ISNULL(FS.quota,0))
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN fin F
			ON EY.idfin = F.idfin
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		JOIN finsorting FS
			ON FS.idfin = HPV.idfin	
		JOIN sorting sorFin
				ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
				ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
			AND (EY.idupb LIKE @idupb)	
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
				   )
				)
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
		GROUP BY isnull(@fixedidupb,EY.idupb), 	isnull(SLK.idparent, sorFin.idsor)
END
END

UPDATE #data SET flagadvance = 'N'

IF @fin_kind = 2 and  exists(select * from fin F
				JOIN finsorting FS
					ON FS.idfin = F.idfin	
				JOIN sorting sorFin
					ON sorFin.idsor = FS.idsor				
				JOIN sortinglevel sl
					ON sorFin.nlevel = sl.nlevel 
				LEFT OUTER JOIN sortinglink SLK 
					ON SLK.idchild = sorFin.idsor 
					and SLK.nlevel = @levelusable_original
				where F.ayear=@ayear and (F.flag&16 <>0) 
				AND sl.idsorkind = @idsorkindfin
					AND sorFin.idsorkind = @idsorkindfin
					AND (sorFin.nlevel = @levelusable
						OR (sorFin.nlevel < @levelusable
							and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
							AND (sl.flag&2)<>0)
						)
)
BEGIN

   if exists(select * from fin F 
				JOIN finsorting FS
					ON FS.idfin = F.idfin	
				JOIN sorting sorFin
					ON sorFin.idsor = FS.idsor				
				JOIN sortinglevel sl
					ON sorFin.nlevel = sl.nlevel 
				LEFT OUTER JOIN sortinglink SLK 
					ON SLK.idchild = sorFin.idsor 
					and SLK.nlevel = @levelusable_original
				left outer join #data D on D.idsor=FS.idsor
					where F.ayear=@ayear and (F.flag&16 <>0)   
					AND sl.idsorkind = @idsorkindfin
					AND sorFin.idsorkind = @idsorkindfin
					AND (sorFin.nlevel = @levelusable
						OR (sorFin.nlevel < @levelusable
							and (select count(*) from sorting S 
								 where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
							AND (sl.flag&2)<>0)
						)
					and D.idsor is null
				)
	BEGIN	
		insert into #data (idfin,idupb,mov_maxphase_C,flagadvance)
			select 	isnull(SLK.idparent, sorFin.idsor), '0001',0 , 'S'
			from 
				fin F 
				JOIN finsorting FS
					ON FS.idfin = F.idfin	
				JOIN sorting sorFin
					ON sorFin.idsor = FS.idsor				
				JOIN sortinglevel sl
					ON sorFin.nlevel = sl.nlevel 
				LEFT OUTER JOIN sortinglink SLK 
					ON SLK.idchild = sorFin.idsor 
					and SLK.nlevel = @levelusable_original
				left outer join #data D on D.idsor=FS.idsor
					where F.ayear=@ayear and (F.flag&16 <>0)   
					AND sl.idsorkind = @idsorkindfin
					AND sorFin.idsorkind = @idsorkindfin
					AND (sorFin.nlevel = @levelusable
						OR (sorFin.nlevel < @levelusable
							and (select count(*) from sorting S 
								 where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
							AND (sl.flag&2)<>0)
						)
					and D.idsor is null
	END

	UPDATE #data	SET mov_maxphase_C = ISNULL(initialprevision, 0) + ISNULL(variation, 0)
		where  flagadvance = 'S'
		

END

/*
 Se N qualora per un capitolo non esistano sott-capitoli con legami con l'upb fondo
 NON verrà visualizzata l'indicazione del Titolo/Categoria/Capitolo
 select * from sortinglevel where idsorkind = 20
 select * from sortingkind where idsorkind = 20
*/

UPDATE #data SET tosuppress = 'S'

UPDATE #data SET tosuppress = 'N'
where isnull(variation ,0)<>0 or isnull(initialprevision ,0)<>0 or isnull(currentarrears ,0)<>0 
		or isnull(secondaryprevision  ,0)<>0 or isnull(secondaryvariation  ,0)<>0 
		or isnull(mov_finphase_C ,0)<>0  or isnull(var_finphase_C ,0)<>0  or isnull(mov_maxphase_C  ,0)<>0 or isnull(var_maxphase_C,0)<>0  
		or isnull(mov_finphase_R  ,0)<>0 or isnull(var_finphase_R  ,0)<>0 or isnull(mov_maxphase_R  ,0)<>0 or isnull(var_maxphase_R  ,0)<>0 


print '@idsorkindfin'
print @idsorkindfin

DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4
 
DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 1
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 2
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 3
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 4
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 5
 
 
 
if (@levelusable_original<5) 
	set @lev_desc5='liv5'

if (@levelusable_original<4) 
	set @lev_desc4='liv4'

if (@levelusable_original<3) 
	set @lev_desc3='liv3'

if (@levelusable_original<2) 
	set @lev_desc2='liv2'

declare @sortingkind varchar(50)
select @sortingkind = description from sortingkind where idsorkind = @idsorkindfin

-------------------------------- Controlla che vi siano solo 2 nodi di livello 1 ---------------------

declare @CountRoot int 
select @CountRoot = count(distinct s.sortcode) from sorting s
	JOIN sortinglink flk1
			ON flk1.idparent = s.idsor AND flk1.nlevel = 1 
	join #data
		on flk1.idchild = #data.idsor
	where s.idsorkind = @idsorkindfin 

declare @Root varchar(50)

if (@CountRoot=1)
begin
	SET @Root = (select top 1 s.sortcode from sorting s
	JOIN sortinglink flk1
			ON flk1.idparent = s.idsor AND flk1.nlevel = 1 
	join #data
		on flk1.idchild = #data.idsor
	where s.idsorkind = @idsorkindfin )

	SET @Root = @Root + '%'
end
else
begin
	SET @Root = '%'
End
------------------------------------------------------------------------------------------------------


IF (@showupb ='S')
BEGIN


SELECT
	@sortingkind as 'sortingkind',
	--#balance.idfin,
	SUBSTRING(f.sortcode, @startpos1, @lencod_lev1) as code1,
	f1.description AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	
	CASE when (f2.sortcode is null) then null
		else SUBSTRING(f.sortcode, @startpos2, @lencod_lev2) 
	end	as code2,
	f2.description AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	
	case when (f3.sortcode is null) then null
		else SUBSTRING(f.sortcode, @startpos3, @lencod_lev3)
	end	 as code3,
	f3.description as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	
	case when (f4.sortcode is null) then null
		else	SUBSTRING(f.sortcode, @startpos4, @lencod_lev4)
	end	as code4,
	f4.description AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	
	case when (f5.sortcode is null) then null
		else SUBSTRING(f.sortcode, @startpos5, @lencod_lev5) 
	end	as code5,
	f5.description AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	
	upb.codeupb,
	upb.idupb as idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
	ISNULL(SUM(initialprevision),0) AS initialprevision,
	ISNULL(SUM(variation),0) AS variation,
	ISNULL(SUM(secondaryprevision),0) AS secondaryprevision,
	ISNULL(SUM(secondaryvariation),0) AS secondaryvariation,
	ISNULL(SUM(currentarrears),0) AS currentarrears,
	ISNULL(SUM(mov_finphase_C),0) AS mov_finphase_C,
	ISNULL(SUM(var_finphase_C),0) AS var_finphase_C,
	ISNULL(SUM(mov_maxphase_C),0) AS mov_maxphase_C,
	ISNULL(SUM(var_maxphase_C),0) AS var_maxphase_C,
	ISNULL(SUM(mov_finphase_R),0) AS mov_finphase_R,
	ISNULL(SUM(var_finphase_R),0) AS var_finphase_R,
	ISNULL(SUM(mov_maxphase_R),0) AS mov_maxphase_R,
	ISNULL(SUM(var_maxphase_R),0) AS var_maxphase_R,
	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
	showincomesurplus,
	/*CASE WHEN 
		((f.flag&16 <>0)OR(f1.flag&16 <>0)  OR (f2.flag&16 <>0)  OR (f3.flag&16 <>0)  OR (f4.flag&16 <>0) OR (f5.flag&16 <>0))
		   THEN 'S'
			ELSE 'N'
		END  as flagadvance,*/
	isnull(flagadvance,'N') as flagadvance,
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
FROM sorting f
	JOIN sortinglevel fl
				ON f.nlevel = fl.nlevel AND fl.idsorkind = @idsorkindfin
cross join  upb 
left outer join #data on #data.idsor=f.idsor and #data.idupb=upb.idupb
		LEFT OUTER JOIN sortinglink flk1
			ON flk1.idchild = f.idsor AND flk1.nlevel = 1
		LEFT OUTER JOIN sorting f1
			ON flk1.idparent = f1.idsor  and f1.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk2
			ON flk2.idchild = f.idsor AND flk2.nlevel = 2
		LEFT OUTER JOIN sorting f2
			ON flk2.idparent = f2.idsor  and f2.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk3
			ON flk3.idchild = f.idsor AND flk3.nlevel = 3
		LEFT OUTER JOIN sorting f3
			ON flk3.idparent = f3.idsor  and f3.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk4
			ON flk4.idchild = f.idsor AND flk4.nlevel = 4
		LEFT OUTER JOIN sorting f4
			ON flk4.idparent = f4.idsor  and f4.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk5
			ON flk5.idchild = f.idsor AND flk5.nlevel = 5
		LEFT OUTER JOIN sorting f5
			ON flk5.idparent = f5.idsor  and f5.idsorkind = @idsorkindfin	
where  ( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (upb.idupb='0001' or isnull(#data.tosuppress, 'S')='N')) and
		 f.idsorkind = @idsorkindfin
		and f.sortcode like @Root
		AND (f.nlevel = @levelusable_original
					OR (f.nlevel < @levelusable_original
						and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = f.idsor)=0
						AND (fl.flag&2)<>0
					   )
					)
	   and upb.idupb like @idupb
	   --AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f.flag & 16 =0) ) 
	   AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
GROUP BY upb.printingorder,upb.idupb,upb.title,upb.codeupb,
	upb.idsor01,  upb.idsor02,  upb.idsor03, upb.idsor04, upb.idsor05,
	SUBSTRING(f.sortcode, @startpos1, @lencod_lev1),
	SUBSTRING(f.sortcode, @startpos2, @lencod_lev2),f2.sortcode,
	SUBSTRING(f.sortcode, @startpos3, @lencod_lev3),f3.sortcode,
	SUBSTRING(f.sortcode, @startpos4, @lencod_lev4),f4.sortcode,
	SUBSTRING(f.sortcode, @startpos5, @lencod_lev5),f5.sortcode,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	f1.description,f2.description,f3.description,f4.description,f5.description,
	f.printingorder,#data.flagadvance,
	showincomesurplus,f.nlevel,isnull(#data.tosuppress, @suppressifblank)
ORDER BY upb.printingorder ASC,
	f.printingorder ASC



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
	@sortingkind as 'sortingkind',
	SUBSTRING(f.sortcode, @startpos1, @lencod_lev1) as code1,
	f1.description AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	
	CASE when (f2.sortcode is null) then null
		else SUBSTRING(f.sortcode, @startpos2, @lencod_lev2) 
	end	as code2,
	f2.description AS desc2,
	@lev_desc2 AS descliv2,
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	
	case when (f3.sortcode is null) then null
		else SUBSTRING(f.sortcode, @startpos3, @lencod_lev3)
	end	 as code3,
	f3.description as desc3,
	@lev_desc3 as descliv3,
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	
	case when (f4.sortcode is null) then null
		else	SUBSTRING(f.sortcode, @startpos4, @lencod_lev4)
	end	as code4,
	f4.description AS desc4,
	@lev_desc4 AS descliv4,
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	
	case when (f5.sortcode is null) then null
		else SUBSTRING(f.sortcode, @startpos5, @lencod_lev5) 
	end	as code5,
	f5.description AS desc5,
	@lev_desc5 AS descliv5,
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	
	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
	ISNULL(SUM(initialprevision),0) AS initialprevision,
	ISNULL(SUM(variation),0) AS variation,
	ISNULL(SUM(secondaryprevision),0) AS secondaryprevision,
	ISNULL(SUM(secondaryvariation),0) AS secondaryvariation,
	ISNULL(SUM(currentarrears),0) AS currentarrears,
	ISNULL(SUM(mov_finphase_C),0) AS mov_finphase_C,
	ISNULL(SUM(var_finphase_C),0) AS var_finphase_C,
	ISNULL(SUM(mov_maxphase_C),0) AS mov_maxphase_C,
	ISNULL(SUM(var_maxphase_C),0) AS var_maxphase_C,
	ISNULL(SUM(mov_finphase_R),0) AS mov_finphase_R,
	ISNULL(SUM(var_finphase_R),0) AS var_finphase_R,
	ISNULL(SUM(mov_maxphase_R),0) AS mov_maxphase_R,
	ISNULL(SUM(var_maxphase_R),0) AS var_maxphase_R,
	case @fin_kind when 1 then 'C' else 'S' end AS previsionkind,
	showincomesurplus,
	isnull(flagadvance,'N') as flagadvance,
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
FROM  sorting f
		JOIN sortinglevel fl			ON f.nlevel = fl.nlevel AND  fl.idsorkind = @idsorkindfin
	left outer join #data				on #data.idsor=f.idsor 
	LEFT OUTER JOIN sortinglink flk1	ON flk1.idchild = f.idsor AND flk1.nlevel = 1
	LEFT OUTER JOIN sorting f1			ON flk1.idparent = f1.idsor and f1.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk2	ON flk2.idchild = f.idsor AND flk2.nlevel = 2
	LEFT OUTER JOIN sorting f2			ON flk2.idparent = f2.idsor and f2.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk3	ON flk3.idchild = f.idsor AND flk3.nlevel = 3
	LEFT OUTER JOIN sorting f3			ON flk3.idparent = f3.idsor  and f3.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk4	ON flk4.idchild = f.idsor AND flk4.nlevel = 4
	LEFT OUTER JOIN sorting f4			ON flk4.idparent = f4.idsor  and f4.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk5	ON flk5.idchild = f.idsor AND flk5.nlevel = 5
	LEFT OUTER JOIN sorting f5			ON flk5.idparent = f5.idsor  and f5.idsorkind = @idsorkindfin
where ((@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (#data.idupb='0001' or isnull(#data.tosuppress, 'S')='N')) AND
		f.idsorkind = @idsorkindfin
			and f.sortcode like @Root
			--AND ((f.flag & 1)= @finpart_bit) 
			AND (f.nlevel = @levelusable_original
				OR (f.nlevel < @levelusable_original
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = f.idsor)=0
					AND (fl.flag&2)<>0
				   )
				)
   --AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f.flag & 16 =0) ) 
GROUP BY F.idsor,f.sortcode,#data.flagadvance,
	SUBSTRING(f.sortcode, @startpos1, @lencod_lev1),
	SUBSTRING(f.sortcode, @startpos2, @lencod_lev2),f2.sortcode,
	SUBSTRING(f.sortcode, @startpos3, @lencod_lev3),f3.sortcode,
	SUBSTRING(f.sortcode, @startpos4, @lencod_lev4),f4.sortcode,
	SUBSTRING(f.sortcode, @startpos5, @lencod_lev5),f5.sortcode,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
	f1.description,f2.description,f3.description,f4.description,f5.description,f.printingorder,
	showincomesurplus,f.nlevel,isnull(#data.tosuppress, @suppressifblank) 
ORDER BY 
	f.printingorder ASC
END

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 


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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilconsuntivosorting_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilconsuntivosorting_riep]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_bilconsuntivosorting_riep 2015,{ts '2015-12-31 00:00:00'},'S',4,'%','S','N','S','S', null, null, null, null, null,3
 
CREATE   PROCEDURE [rpt_bilconsuntivosorting_riep] 
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@officialvar  char(1),
	@suppressifblank char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@idsorkindfin int
)
AS BEGIN


DECLARE @idupboriginal 	varchar(36)
	
SET @idupboriginal= @idupb
		
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%'
END

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

CREATE TABLE #data
(
	idsor int,
	flagavanzo char(1),
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
	prevision_advance decimal(19,2)
)
/*
prevision_advance:
Nelle colonne della previsione, var di previsione, verranno visualizzati gli importi completi, siano essi capitoli normali i rappresentanti l'avanzo.
Mentre, nel calcolo del disponiible, nel calcolo della differenza tra l'accertato e la previsione, e tutto ciò che incrocia il finanziario, 
verrà considerata solo la previsione dei capitoli normali. 
Questa variabile è appunto la prev. del capitolo avanzo. Nei calcoli che incrociano il finanziario, la prev. verrà depurata da questo importo.
Prevision_advance è la previsione al netto delle variazioni.
*/

DECLARE @infoadvance char(1)
SELECT @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @MAXoplevel tinyint
SELECT @MAXoplevel = MAX(nlevel)
FROM sortinglevel
WHERE idsorkind = @idsorkindfin


DECLARE @minoplevel tinyint

SELECT @minoplevel = MIN(nlevel) FROM sortinglevel 
WHERE idsorkind = @idsorkindfin AND (flag&2)<>0


-- SE non è stato selezionato il livello, prende l'ultimo livello operativo
if(isnull(@levelusable,0)=0 )
Begin
	set @levelusable = @MAXoplevel
End
	
DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable


IF(@levelusable < @minoplevel)
begin
	SET @levelusable = @minoplevel
end


DECLARE @cashvaliditykind tinyint

SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @fin_kind tinyint

SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

	
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

DECLARE @finphase tinyint
DECLARE @maxphase tinyint
IF (@finpart = 'E')
BEGIN
	SELECT @finphase = assessmentphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = incomefinphase
		FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM incomephase
END
IF (@finpart = 'S')
BEGIN
	SELECT @finphase =  appropriationphasecode
	FROM config
	WHERE ayear = @ayear
	IF @finphase IS NULL
	BEGIN
		SELECT @finphase = expensefinphase
		FROM uniconfig
	END
	SELECT @maxphase = MAX(nphase) FROM expensephase
END


IF @levelusable > @minoplevel
BEGIN
print 'then'
-- se la stampa è per articolo : 4 > 3 : legge le prev dalle foglie e somma sino al livello desiderato
--   [ex: finusable degli articoli, laddove non esiste l'articolo -- legge il capitolo]
	INSERT INTO #data
	(
		idsor,
		idupb,
		initialprevision
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),	
		isnull(@fixedidupb,fy2.idupb),
		ISNULL(SUM(fy2.prevision*ISNULL(FS.quota,0)),0)
	FROM  finyear fy2
		JOIN finlast
			ON finlast.idfin = fy2.idfin
		JOIN fin F
			ON finlast.idfin = F.idfin
		JOIN upb U
			ON fy2.idupb = U.idupb		
		JOIN finsorting FS
			ON FS.idfin = F.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1

	WHERE (fy2.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND fy2.ayear = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND ((F.flag & 1)= @finpart_bit) -- AND fin.finpart = @finpart
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
	GROUP BY isnull(@fixedidupb,fy2.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05


	--select * from #data

	IF (/*@fin_kind in(1, 3) AND */@finpart = 'E' AND (@infoadvance IN ('N','B')) AND
					 exists(select * from fin where ayear=@ayear and (flag&16 <>0) ))
	Begin
		INSERT INTO #data(
			idsor,
			idupb,
			prevision_advance
		)
		SELECT
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,fy2.idupb),
			ISNULL(SUM(fy2.prevision*ISNULL(FS.quota,0)),0)
		FROM  finyear fy2
			JOIN finlast
				ON finlast.idfin = fy2.idfin
			join fin as FinAdvance
				on FinAdvance.idfin = finlast.idfin
			JOIN upb U
				ON fy2.idupb = U.idupb		
			JOIN finsorting FS
				ON FS.idfin = finlast.idfin	
			JOIN sorting sorFin
				ON sorFin.idsor = FS.idsor				
			JOIN sortinglevel sl
				ON sorFin.nlevel = sl.nlevel 
			LEFT OUTER JOIN sortinglink SLK 
				on SLK.idchild = sorFin.idsor and SLK.nlevel = 1
		WHERE (fy2.idupb LIKE @idupb)
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND fy2.ayear = @ayear
			AND ((FinAdvance.flag & 1)= @finpart_bit) -- AND fin.finpart = @finpart
			and (FinAdvance.flag&16 <>0)
			AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
				   )
				)
		GROUP BY isnull(@fixedidupb,fy2.idupb),
		isnull(SLK.idparent, sorFin.idsor),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	End			
END
ELSE
BEGIN
print'Else'
	INSERT INTO #data
	(
		idsor,
		idupb,
		initialprevision
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,fy2.idupb),
		ISNULL(SUM(fy2.prevision*ISNULL(FS.quota,0)),0)
	FROM finyear fy2
	JOIN fin f2
		ON f2.idfin = fy2.idfin 	
	JOIN upb U
		ON fy2.idupb = U.idupb		
	JOIN finsorting FS
		ON FS.idfin = f2.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		on SLK.idchild = sorFin.idsor and SLK.nlevel = 1	
	WHERE f2.nlevel=@levelusable
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (fy2.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND fy2.ayear = @ayear
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND ((f2.flag & 1)= @finpart_bit)
		GROUP BY isnull(@fixedidupb,fy2.idupb),isnull(SLK.idparent, sorFin.idsor),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	IF (/*@fin_kind in(1, 3) AND */@finpart = 'E' AND (@infoadvance IN ('N','B')) AND
					 exists(select * from fin where ayear=@ayear and (flag&16 <>0) ))
	Begin
		INSERT INTO #data
		(
			idsor,
			idupb,
			prevision_advance
		)
		SELECT
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,fy2.idupb),
			ISNULL(SUM(fy2.prevision*ISNULL(FS.quota,0)),0)
		FROM finyear fy2
		JOIN fin f2
			ON f2.idfin = fy2.idfin 
		join fin as FinAdvance
			on FinAdvance.idfin = f2.idfin
		JOIN upb U
			ON fy2.idupb = U.idupb		
		JOIN finsorting FS
			ON FS.idfin = f2.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			on SLK.idchild = sorFin.idsor and SLK.nlevel = 1	
		WHERE f2.nlevel=@levelusable
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (fy2.idupb LIKE @idupb)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND fy2.ayear = @ayear
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
-- Stiamo facendo la stampa per capitolo, quindi le previsioni vengono lette dal capitolo. Se il capitolo non è flaggato come avanzo, controlliamo che vi sia un figlio flaggato
			and ((FinAdvance.flag&16 <>0) or exists (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f2.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0)  ))
			AND ((f2.flag & 1)= @finpart_bit)
			GROUP BY isnull(@fixedidupb,fy2.idupb),isnull(SLK.idparent, sorFin.idsor),
			U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	End
END


print 'fin_kind:'
print @fin_kind

--------------------------- previsione secondaria --------------------------------------
IF @levelusable > @minoplevel
BEGIN
print 'then'
-- se la stampa è per articolo : 4 > 3 : legge le prev dalle foglie e somma sino al livello desiderato
--   [ex: finusable degli articoli, laddove non esiste l'articolo -- legge il capitolo]
	INSERT INTO #data
	(
		idsor,
		idupb,
		secondaryprevision
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),	isnull(@fixedidupb,fy2.idupb),
		ISNULL(SUM(fy2.secondaryprev*ISNULL(FS.quota,0)),0)
	FROM  finyear fy2
		JOIN finlast
			ON finlast.idfin = fy2.idfin
		JOIN upb U
			ON fy2.idupb = U.idupb	
		JOIN fin F
			ON fy2.idfin = F.idfin	
		JOIN finsorting FS
			ON FS.idfin = finlast.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1	
	WHERE (fy2.idupb LIKE @idupb)
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
		AND fy2.ayear = @ayear
		AND ((F.flag & 1)= @finpart_bit) -- AND fin.finpart = @finpart
	GROUP BY isnull(@fixedidupb,fy2.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
				
END
ELSE
BEGIN
print'Else'
	INSERT INTO #data
	(
		idsor,
		idupb,
		secondaryprevision
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,fy2.idupb),
		ISNULL(SUM(fy2.secondaryprev*ISNULL(FS.quota,0)),0)
	FROM finyear fy2
	JOIN fin f2
		ON f2.idfin = fy2.idfin 
	JOIN upb U
		ON fy2.idupb = U.idupb	
	JOIN finsorting FS
		ON FS.idfin = f2.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1		
	WHERE f2.nlevel=@levelusable
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (fy2.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND fy2.ayear = @ayear
		AND ((f2.flag & 1)= @finpart_bit)
		GROUP BY isnull(@fixedidupb,fy2.idupb),isnull(SLK.idparent, sorFin.idsor),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
END


--------------------------- fine previsione secondaria --------------------------------------

INSERT INTO #data
(
	idsor,
	idupb,
	variation
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	isnull(@fixedidupb,fvd.idupb),
	SUM(FVD.amount*ISNULL(FS.quota,0))
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON F.idfin = FVD.idfin
JOIN upb U
	ON FVD.idupb = U.idupb
JOIN finsorting FS
	ON FS.idfin = F.idfin	
JOIN sorting sorFin
	ON sorFin.idsor = FS.idsor				
JOIN sortinglevel sl
	ON sorFin.nlevel = sl.nlevel 
LEFT OUTER JOIN sortinglink SLK 
	ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1	
WHERE FV.yvar = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
	AND (FVD.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY isnull(@fixedidupb,fvd.idupb),isnull(SLK.idparent, sorFin.idsor),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	IF (/*@fin_kind in(1, 3) AND */@finpart = 'E' AND (@infoadvance IN ('N','B')) AND
					 exists(select * from fin where ayear=@ayear and (flag&16 <>0) ))
	Begin						
		INSERT INTO #data
		(
			idsor,
			idupb,
			prevision_advance
		)
		SELECT
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,fvd.idupb),
			SUM(FVD.amount*ISNULL(FS.quota,0))
		FROM finvardetail FVD
		JOIN finvar FV
			ON FV.yvar = FVD.yvar
			AND FV.nvar = FVD.nvar
		JOIN fin F
			ON F.idfin = FVD.idfin
		JOIN upb U
			ON FVD.idupb = U.idupb
		JOIN finsorting FS
			ON FS.idfin = F.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
		WHERE FV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
			AND (FVD.idupb LIKE @idupb)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND FV.adate <= @date
			and (F.flag&16 <>0)
			AND FV.flagprevision = 'S'
			AND FV.idfinvarstatus = 5
			AND FV.variationkind <> 5
			AND
			((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
			  OR ISNULL(@officialvar,'N') = 'N')
			AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
		GROUP BY isnull(@fixedidupb,FVD.idupb),isnull(SLK.idparent, sorFin.idsor),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	End

INSERT INTO #data
(
	idsor,
	idupb,
	secondaryvariation
)
SELECT
	isnull(SLK.idparent, sorFin.idsor),
	isnull(@fixedidupb,fvd.idupb),
	SUM(FVD.amount*ISNULL(FS.quota,0))
FROM finvardetail FVD
JOIN finvar FV
	ON FV.yvar = FVD.yvar
	AND FV.nvar = FVD.nvar
JOIN fin F
	ON F.idfin = FVD.idfin
JOIN upb U
	ON FVD.idupb = U.idupb
JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
WHERE FV.yvar = @ayear
	AND sl.idsorkind = @idsorkindfin
	AND sorFin.idsorkind = @idsorkindfin
	AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
	AND (FVD.idupb LIKE @idupb)
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5
	AND FV.variationkind <> 5
	AND
	((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
	  OR ISNULL(@officialvar,'N') = 'N')
	AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
GROUP BY isnull(@fixedidupb,fvd.idupb),isnull(SLK.idparent, sorFin.idsor),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	

IF @finpart = 'E'
BEGIN
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_finphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(@fixedidupb,iy.idupb),
		ISNULL(SUM(IY.amount*ISNULL(FS.quota,0)),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN fin F
		ON IY.idfin = F.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE (IY.idupb LIKE @idupb)
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
		AND I.adate <= @date
		AND IY.ayear = @ayear
		AND ((IT.flag & 1) =0)-- Competenza
		AND I.nphase = @finphase
	GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	
	INSERT INTO #data
	(
		idsor,
		idupb,
		var_finphase_C
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor),
		ISNULL(@fixedidupb,iy.idupb),
		ISNULL(SUM(IV.amount*ISNULL(FS.quota,0)),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE IV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (IY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05) 
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) =0)--Competenza
		AND I.nphase = @finphase
		AND IV.adate <= @date 
	GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
		
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
		isnull(@fixedidupb,iy.idupb),
		ISNULL(SUM(IY.amount*ISNULL(FS.quota,0)),0)
	FROM income I
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN fin F
		ON IY.idfin = F.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE I.adate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (IY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05) 
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)--Residuo
		AND I.nphase = @finphase
	GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
End

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
		isnull(@fixedidupb,iy.idupb),
		ISNULL(SUM(IV.amount*ISNULL(FS.quota,0)),0)
	FROM incomevar IV
	JOIN incomeyear IY
		ON IY.idinc = IV.idinc
	JOIN income I
		ON I.idinc = IV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE IV.yvar = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (IY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND IY.ayear = @ayear
		AND ( (IT.flag & 1) = 1)-- Residuo
		AND I.nphase = @finphase
		AND IV.adate <= @date 
	GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
End
	
	INSERT INTO #data
	(
		idsor,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,iy.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE HPV.competencydate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (IY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
	GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_maxphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,iy.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN upb U
		ON IY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE HPV.competencydate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (IY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND IY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
	GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	
	
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
			isnull(@fixedidupb,iy.idupb),
			SUM(IV.amount*ISNULL(FS.quota,0))
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN fin F
			ON F.idfin = IY.idfin
		JOIN upb U
			ON IY.idupb = U.idupb
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		JOIN finsorting FS
			ON FS.idfin = HPV.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1	
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
			AND (IY.idupb LIKE @idupb)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 0)-- Competenza
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
		GROUP BY isnull(@fixedidupb,iy.idupb), isnull(SLK.idparent, sorFin.idsor),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
		
		INSERT INTO #data
		(
			idsor,
			idupb,
			var_maxphase_R
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor), 
			isnull(@fixedidupb,iy.idupb),
			SUM(IV.amount*ISNULL(FS.quota,0))
		FROM incomevar IV
		JOIN incomeyear IY
			ON IY.idinc = IV.idinc
		JOIN fin F
			ON F.idfin = IY.idfin
		JOIN upb U
			ON IY.idupb = U.idupb
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
		JOIN finsorting FS
			ON FS.idfin = HPV.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1	
		WHERE IV.yvar = @ayear
			AND sl.idsorkind = @idsorkindfin
			AND sorFin.idsorkind = @idsorkindfin
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
			AND (IY.idupb LIKE @idupb)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND IV.adate <= @date
			AND IY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			AND HPV.competencydate <= @date	AND HPV.ymov = @ayear
		GROUP BY isnull(@fixedidupb,iy.idupb),isnull(SLK.idparent, sorFin.idsor),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EY.amount*ISNULL(FS.quota,0)),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON EY.idfin = F.idfin
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE E.adate <= @date
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (EY.idupb LIKE @idupb)
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
	GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	
	INSERT INTO #data
	(
		idsor,
		idupb,
		var_finphase_C
	)
	SELECT 
		isnull(SLK.idparent, sorFin.idsor), 
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EV.amount*ISNULL(FS.quota,0)),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON E.idexp = EV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND (EY.idupb LIKE @idupb)
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
		AND ( (ET.flag & 1) = 0) -- Competenza
		AND E.nphase = @finphase
		AND EV.adate <= @date 
	GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

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
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EY.amount*ISNULL(FS.quota,0)),0)
	FROM expense E
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON EY.idfin = F.idfin
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE E.adate <= @date
		AND EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND (EY.idupb LIKE @idupb)
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
		AND E.nphase = @finphase
	GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
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
		isnull(@fixedidupb,ey.idupb),
		ISNULL(SUM(EV.amount*ISNULL(FS.quota,0)),0)
	FROM expensevar EV
	JOIN expenseyear EY
		ON EY.idexp = EV.idexp
	JOIN expense E
		ON E.idexp = EV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN upb U
		ON EY.idupb = U.idupb	
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE EV.yvar = @ayear
		AND EY.ayear = @ayear
		AND (EY.idupb LIKE @idupb)
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
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase
		AND EV.adate <= @date 
	GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
end

	INSERT INTO #data
	(
		idsor,
		idupb,	
		mov_maxphase_C
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,ey.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE HPV.competencydate <= @date
		AND (EY.idupb LIKE @idupb)
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
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 0)-- Competenza
		AND HPV.ymov = @ayear
	GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	
	
	INSERT INTO #data
	(
		idsor,
		idupb,
		mov_maxphase_R
	)
	SELECT
		isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,ey.idupb),
		SUM(HPV.amount*ISNULL(FS.quota,0))
	FROM historypaymentview HPV
	JOIN expenseyear EY
		ON EY.idexp = HPV.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN upb U
		ON EY.idupb = U.idupb
	JOIN finsorting FS
		ON FS.idfin = F.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN sortinglink SLK 
		ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
	WHERE HPV.competencydate <= @date
		AND (EY.idupb LIKE @idupb)
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
		AND EY.ayear = @ayear
		AND ( (HPV.totflag & 1) = 1)-- Residuo
		AND HPV.ymov = @ayear
	GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
		
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
			isnull(@fixedidupb,ey.idupb),
			SUM(EV.amount*ISNULL(FS.quota,0))
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN fin F
			ON F.idfin = EY.idfin
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		JOIN finsorting FS
			ON FS.idfin = F.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
		WHERE EV.yvar = @ayear
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND (EY.idupb LIKE @idupb)
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
			AND ( (HPV.totflag & 1) = 0)--Competenza
			--AND EY.nphase = @maxphase
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
		,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
			
		INSERT INTO #data
		(
			idsor,
			idupb,
			var_maxphase_R
		)
		SELECT 
			isnull(SLK.idparent, sorFin.idsor),
			isnull(@fixedidupb,ey.idupb),
			SUM(EV.amount*ISNULL(FS.quota,0))
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN fin F
			ON F.idfin = EY.idfin
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		JOIN finsorting FS
			ON FS.idfin = F.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN sortinglink SLK 
			ON SLK.idchild = sorFin.idsor and SLK.nlevel = 1
		WHERE EV.yvar = @ayear
			AND (EY.idupb LIKE @idupb)
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
			AND EV.adate <= @date
			AND EY.ayear = @ayear
			AND ( (HPV.totflag & 1) = 1)-- Residuo
			--AND EY.nphase = @maxphase
			AND HPV.competencydate <= @date AND HPV.ymov = @ayear
		GROUP BY isnull(@fixedidupb,ey.idupb),isnull(SLK.idparent, sorFin.idsor)
		,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	END
END

DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'


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
	#data.idsor,
	SUBSTRING(f.sortcode, @startpos1, @lencod_lev1) as code1,
	f.description AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,

	codeupb,
	#data.idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
	isnull(sum(initialprevision),0) as initialprevision,
	isnull(sum(variation),0) as variation,
	isnull(sum(secondaryprevision),0) as secondaryprevision,
	isnull(sum(secondaryvariation),0) as secondaryvariation,
	isnull(sum(currentarrears),0) as currentarrears,
	isnull(sum(mov_finphase_C),0) as mov_finphase_C,
	isnull(sum(var_finphase_C),0) as var_finphase_C,
	isnull(sum(mov_maxphase_C),0) as mov_maxphase_C,
	isnull(sum(var_maxphase_C),0) as var_maxphase_C,
	isnull(sum(mov_finphase_R),0) as mov_finphase_R,
	isnull(sum(var_finphase_R),0) as var_finphase_R,
	isnull(sum(mov_maxphase_R),0) as mov_maxphase_R,
	isnull(sum(var_maxphase_R),0) as var_maxphase_R,
	isnull(sum(prevision_advance),0) as prevision_advance,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
	 CASE
			WHEN EXISTS 
				(SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finsorting FS
						ON FS.idfin = fin.idfin	
					JOIN sorting sorFin
						ON sorFin.idsor = FS.idsor				
					JOIN sortinglevel sl
						ON sorFin.nlevel = sl.nlevel 
					LEFT OUTER JOIN sortinglink SLK 
						ON SLK.idchild = sorFin.idsor 
						and SLK.nlevel = 1
				 
					WHERE (fin.flag&16 <>0) AND fin.ayear=@ayear 
							AND #data.idsor=FS.idsor
						AND sl.idsorkind = @idsorkindfin
						AND sorFin.idsorkind = @idsorkindfin
						AND (sorFin.nlevel = @levelusable
							OR (sorFin.nlevel < @levelusable
								and (select count(*) from sorting S 
									 where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
								AND (sl.flag&2)<>0)
							)
					) THEN 'S'
					ELSE 'N'
			END  AS flagadvance
FROM sorting f
cross join  upb 
left outer join #data on #data.idsor=f.idsor and #data.idupb=upb.idupb
where f.nlevel=1
		and ( (@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (upb.idupb='0001' or #data.idsor is not null)) 
		and upb.idupb like @idupb 	and f.sortcode like @Root and f.idsorkind = @idsorkindfin
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR   NOT EXISTS
				(SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finsorting FS
						ON FS.idfin = fin.idfin	
					JOIN sorting sorFin
						ON sorFin.idsor = FS.idsor				
					JOIN sortinglevel sl
						ON sorFin.nlevel = sl.nlevel 
					LEFT OUTER JOIN sortinglink SLK 
						ON SLK.idchild = sorFin.idsor 
						and SLK.nlevel = 1
 
					WHERE (fin.flag&16 <>0)  AND fin.ayear=@ayear 
					 AND #data.idsor=FS.idsor
						AND sl.idsorkind = @idsorkindfin
						AND sorFin.idsorkind = @idsorkindfin
						AND (sorFin.nlevel = @levelusable
							OR (sorFin.nlevel < @levelusable
								and (select count(*) from sorting S 
									 where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
								AND (sl.flag&2)<>0)
							)
					) 
					
		)  
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
     	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	 	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
group by #data.idsor,f.sortcode ,	f.description ,	f.printingorder ,
codeupb,#data.idupb,upb.title ,	upb.printingorder 
,upb.idsor01, upb.idsor02, upb.idsor03, upb.idsor04,upb.idsor05, f.idsor

ORDER BY f.printingorder ASC,#data.idupb ASC
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

--select * from #data

SELECT
	@sortingkind as 'sortingkind',
	#data.idsor,
	SUBSTRING(f.sortcode, @startpos1, @lencod_lev1) as code1,
	f.description AS desc1,
	@lev_desc1 AS descliv1,
	SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,

	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
	isnull(sum(initialprevision),0) as initialprevision,
	isnull(sum(variation),0) as variation,
	isnull(sum(secondaryprevision),0) as secondaryprevision,
	isnull(sum(secondaryvariation),0) as secondaryvariation,
	isnull(sum(currentarrears),0) as currentarrears,
	isnull(sum(mov_finphase_C),0) as mov_finphase_C,
	isnull(sum(var_finphase_C),0) as var_finphase_C,
	isnull(sum(mov_maxphase_C),0) as mov_maxphase_C,
	isnull(sum(var_maxphase_C),0) as var_maxphase_C,
	isnull(sum(mov_finphase_R),0) as mov_finphase_R,
	isnull(sum(var_finphase_R),0) as var_finphase_R,
	isnull(sum(mov_maxphase_R),0) as mov_maxphase_R,
	isnull(sum(var_maxphase_R),0) as var_maxphase_R,
	isnull(sum(prevision_advance),0) as prevision_advance,
	@supposed_ff_jan01 AS supposed_ff_jan01,
	@supposed_aa_jan01 AS supposed_aa_jan01,
	@ff_jan01 AS ff_jan01,
	@aa_jan01 AS aa_jan01,
	isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
	isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
	isnull(@aa_01_jan_used,0) as aa_01_jan_used,
	isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used,
	CASE
			WHEN EXISTS 
				(SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finsorting FS
						ON FS.idfin = fin.idfin	
					JOIN sorting sorFin
						ON sorFin.idsor = FS.idsor				
					JOIN sortinglevel sl
						ON sorFin.nlevel = sl.nlevel 
					LEFT OUTER JOIN sortinglink SLK 
						ON SLK.idchild = sorFin.idsor 
						and SLK.nlevel = 1
					WHERE (fin.flag&16 <>0)  AND fin.ayear=@ayear 
						AND #data.idsor=FS.idsor
						AND sl.idsorkind = @idsorkindfin
						AND sorFin.idsorkind = @idsorkindfin
						AND (sorFin.nlevel = @levelusable
							OR (sorFin.nlevel < @levelusable
								and (select count(*) from sorting S 
									 where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
								AND (sl.flag&2)<>0)
							)
					) THEN 'S'
					ELSE 'N'
			END  AS flagadvance
FROM sorting f
LEFT OUTER  join #data on #data.idsor=f.idsor 
where 
		f.nlevel=1 	and f.sortcode like @Root  and   f.idsorkind = @idsorkindfin
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS
		(SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finsorting FS
						ON FS.idfin = fin.idfin	
					JOIN sorting sorFin
						ON sorFin.idsor = FS.idsor				
					JOIN sortinglevel sl
						ON sorFin.nlevel = sl.nlevel 
					LEFT OUTER JOIN sortinglink SLK 
						ON SLK.idchild = sorFin.idsor 
						and SLK.nlevel = 1
					WHERE (fin.flag&16 <>0)  AND fin.ayear=@ayear 
						AND #data.idsor=FS.idsor  
						AND sl.idsorkind = @idsorkindfin
						AND sorFin.idsorkind = @idsorkindfin
						AND (sorFin.nlevel = @levelusable
							OR (sorFin.nlevel < @levelusable
								and (select count(*) from sorting S 
									 where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
								AND (sl.flag&2)<>0)
							)
					) 
					
					)  	 
group by #data.idsor,f.sortcode ,	f.description ,	f.printingorder, f.idsor  


ORDER BY f.printingorder ASC


END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


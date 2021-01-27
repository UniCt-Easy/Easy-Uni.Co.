
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilconsuntivo_cassa_comp_residui_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilconsuntivo_cassa_comp_residui_riep]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        PROCEDURE [rpt_bilconsuntivo_cassa_comp_residui_riep]
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
	@kind char(1),		-- C R S
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int  = null
)
AS BEGIN
-- [rpt_bilconsuntivo_cassa_comp_residui_riep]  2013, {ts '2013-12-31 00:00:00'},'E',3,'0001','N','S','S','S','S' 
/*
prevision_advance:
Nelle colonne della previsione, var di previsione, verranno visualizzati gli importi completi, siano essi capitoli normali i rappresentanti l'avanzo.
Mentre, nel calcolo del disponiible, nel calcolo della differenza tra l'accertato e la previsione, e tutto ciò che incrocia il finanziario, 
verrà considerata solo la previsione dei capitoli normali. 
Questa variabile è appunto la prev. del capitolo avanzo. Nei calcoli che incrociano il finanziario, la prev. verrà depurata da questo importo.
Prevision_advance è la previsione al netto delle variazioni.
*/

CREATE TABLE #data
(
	idfin int,	--su levelusable
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
	showupb char(1),
	nlevel tinyint,
	prevision_diff_acc_comp decimal(19,2),
	prevision_diff_red_comp decimal(19,2),
	prevision_diff_acc_cassa decimal(19,2),
	prevision_diff_red_cassa decimal(19,2),
	flagadvance char(1),
	prevision_advance decimal(19,2),
	secondary_prevision_advance decimal(19,2),
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
SELECT  @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @cashvaliditykind tinyint
SELECT  @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear

DECLARE @finphase tinyint
DECLARE @maxphase tinyint

declare @fin_kind tinyint
select  @fin_kind = fin_kind
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
-- Se @fin_kind = 1 ==> è stata personalizzata una
-- previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se
-- @fin_kind = 3 ==> è stata personalizzata una
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


DECLARE @minlevelusable		tinyint
SELECT  @minlevelusable = min(nlevel) FROM finlevel WHERE ayear = @ayear and (flag&2) <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minlevelusable)
begin
	SET @levelusable = @minlevelusable
end


----------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------- SE SI è DECISO DI NON VEDERE L'UPB ---------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------

print 'insert prevision'
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
	JOIN upb U
		ON finyear.idupb = U.idupb
	JOIN finlevel fl
			ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
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
 
	group by finyear.idfin,isnull(@fixedidupb,finyear.idupb),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	if((@infoadvance IN ('N','B')) AND  exists(select * from fin where ayear=@ayear and (flag&16 <>0) ))
	Begin
		insert into #data (
			idfin,	idupb,
			prevision_advance
		)
		select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
				ISNULL(SUM(finyear.prevision),0)
		from finyear 
			join fin f5 on finyear.idfin=f5.idfin
		JOIN upb U
			ON finyear.idupb = U.idupb
		JOIN finlevel fl
				ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
		where f5.ayear = @ayear
				AND (finyear.idupb LIKE @idupb)	
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				and (f5.flag&16 <>0)
				AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
				AND (f5.nlevel = @levelusable
					OR (f5.nlevel < @levelusable
						AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
						AND (fl.flag&2)<>0
					   )
					)
 
		group by finyear.idfin,isnull(@fixedidupb,finyear.idupb),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
		
		INSERT INTO #data
		(
			idfin,
			idupb,
			prevision_advance
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
			and (f.flag&16 <>0)
			AND FVD.idupb like @idupb
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin),
		U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	End
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
	JOIN upb U
		ON finyear.idupb = U.idupb
	JOIN finlevel fl
			ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
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
 
	group by finyear.idfin,isnull(@fixedidupb,finyear.idupb),
	U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	if((@infoadvance IN ('N','B')) AND  exists(select * from fin where ayear=@ayear and (flag&16 <>0) ))
	Begin
			insert into #data (
				idfin,	idupb,
				secondary_prevision_advance
			)
			select finyear.idfin,isnull(@fixedidupb,finyear.idupb),
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
			where f5.ayear = @ayear
					AND (finyear.idupb LIKE @idupb)	
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
					and (f5.flag&16 <>0)
					AND ((f5.flag & 1)= @finpart_bit) --AND f5.finpart = @finpart
					AND (f5.nlevel = @levelusable
						OR (f5.nlevel < @levelusable
							AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f5.idfin)
							AND (fl.flag&2)<>0
						   )
						)
 			group by finyear.idfin,isnull(@fixedidupb,finyear.idupb),
			U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

			INSERT INTO #data
			(
				idfin,
				idupb,
				secondary_prevision_advance
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
				and (f.flag&16 <>0)
				AND FV.idfinvarstatus = 5 
				AND FV.variationkind <> 5
				AND
				((ISNULL(FV.official,'N') = 'S' AND ISNULL(@officialvar,'N') = 'S') -- consideriamo solo le variazioni ufficiali
				  OR ISNULL(@officialvar,'N') = 'N')
				-- vogliamo le variazioni prev. di cassa
				AND (FV.flagsecondaryprev = 'S' and @fin_kind=3
					OR FV.flagprevision = 'S' and @fin_kind=2)
				AND ((F.flag & 1 ) = @finpart_bit) AND F.ayear = @ayear
				AND FVD.idupb like @idupb
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin),
			U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

	End
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
JOIN upb U
	ON finyear.idupb = U.idupb
JOIN finlevel fl
		ON f5.nlevel = fl.nlevel AND  f5.ayear = fl.ayear
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
 
group by finyear.idfin,isnull(@fixedidupb,finyear.idupb),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
end





if (@kind='C')
begin
print 'insert varprev_m_acc'
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
print 'insert varprev_m_red'
INSERT INTO #data
(
	idfin,
	idupb,
	varprev_m_red
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	ABS(ISNULL(SUM(FVD.amount),0))
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
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

end

if (@kind='S')
begin
print 'insert varprev_s_acc'
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
GROUP BY isnull(@fixedidupb,FVD.idupb),ISNULL(FLK.idparent,FVD.idfin),
U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05

END


if (@kind='S')
begin
print 'insert varprev_s_red'
INSERT INTO #data
(
	idfin,
	idupb,
	varprev_s_red
)
SELECT
	ISNULL(FLK.idparent,FVD.idfin),
	isnull(@fixedidupb,FVD.idupb),
	ABS(ISNULL(SUM(FVD.amount),0))
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
END

IF @finpart = 'E'
BEGIN
	
	if (@kind in ('C','R'))
	begin
	print 'insert mov_finphase_C'
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
	print 'insert var_finphase_acc_C'
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
	print 'insert var_finphase_red_C'
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
	print 'insert mov_finphase_R'
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
	JOIN upb U
		ON IY.idupb = U.idupb
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
	print 'insert var_finphase_acc_R'
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
	JOIN upb U
		ON IY.idupb = U.idupb
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
	print 'insert var_finphase_red_R'
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

	print 'insert mov_maxphase_C'
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
	print 'insert mov_maxphase_R'
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
		print 'insert var_maxphase_C'
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
	if (@kind in ('S','R'))
	begin
		print 'insert var_maxphase_R'
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
	end

	END
END

IF @finpart = 'S'
BEGIN
	if (@kind in ('C','R'))
	begin
	print 'insert mov_finphase_C'
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
	print 'insert var_finphase_acc_C'
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
	print 'insert var_finphase_red_C'
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
	END

	if (@kind ='R')
	begin
	print 'insert mov_finphase_R'
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
	JOIN upb U
		ON EY.idupb = U.idupb
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
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb,EY.idupb),ISNULL(FLK.idparent,EY.idfin)
	,U.idsor01,  U.idsor02,  U.idsor03,  U.idsor04, U.idsor05
	END

	if (@kind ='R')
	begin
	print 'insert var_finphase_acc_R'
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
	print 'insert var_finphase_red_R'
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

	print 'insert mov_maxphase_C'
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
	print 'insert mov_maxphase_R'
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
		AND ( (HPV.totflag & 1) = 1)-- Residuo
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
		print 'insert var_maxphase_C'
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
		print 'insert var_maxphase_R'
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

/*
print 'delete CRS'
print @kind

if (@kind='C')
	DELETE FROM #data 
	WHERE ISNULL(initialprevision,0)= 0 AND ISNULL(varprev_m_acc,0)= 0 AND ISNULL(varprev_m_red,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0 AND ISNULL(var_finphase_acc_C,0)= 0 AND ISNULL(var_finphase_red_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0 AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(prevision_diff_acc_comp,0)= 0 AND ISNULL(prevision_diff_red_comp,0)= 0

if (@kind='S')
	DELETE FROM #data 
	WHERE ISNULL(secondaryprev,0)= 0 AND ISNULL(varprev_s_acc,0) = 0 AND ISNULL(varprev_s_red,0) = 0
		AND ISNULL(mov_maxphase_C,0)= 0 AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(mov_maxphase_R,0)= 0 AND ISNULL(var_maxphase_R,0)= 0
		AND ISNULL(prevision_diff_acc_cassa,0)= 0 AND ISNULL(prevision_diff_red_cassa,0)= 0

if (@kind='R')
	DELETE FROM #data 
	WHERE ISNULL(currentarrears,0)= 0
		AND ISNULL(mov_finphase_C,0)= 0 AND ISNULL(var_finphase_acc_C,0)= 0 AND ISNULL(var_finphase_red_C,0)= 0
		AND ISNULL(mov_maxphase_C,0)= 0 AND ISNULL(var_maxphase_C,0)= 0
		AND ISNULL(mov_finphase_R,0)= 0 AND ISNULL(var_finphase_acc_R,0)= 0 AND ISNULL(var_finphase_red_R,0)= 0
		AND ISNULL(mov_maxphase_R,0)= 0 AND ISNULL(var_maxphase_R,0)= 0
*/


----------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------- SE SI è DECISO DI NON VEDERE  UPB ---------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Se la stampa è eseguita a livello inferiore del minimo livello operativo
-- le differenze rispetto alle previsioni devono essere calcolate a tale lvello
	



DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM finlevel WHERE ayear = @ayear AND nlevel = 1
	


DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'

		
IF (@showupb ='S')
BEGIN
	print 'with S';

	with raggruppa_capitoli	
		(idfin, idupb ,
			initialprevision ,	varprev_m_acc ,	varprev_m_red ,	
			secondaryprev,	varprev_s_acc ,	varprev_s_red ,
			currentarrears ,
			mov_finphase_C ,	var_finphase_acc_C ,	var_finphase_red_C ,
			mov_maxphase_C ,	var_maxphase_C ,
			mov_finphase_R ,	var_finphase_acc_R ,var_finphase_red_R ,
			mov_maxphase_R ,	var_maxphase_R ,
			prevision_advance,
			secondary_prevision_advance,
		prevision_diff_comp,	
		prevision_diff_cassa )
	AS
	(
		select 					
			idfin, idupb,  
			sum(initialprevision) ,	sum(varprev_m_acc) ,	sum(varprev_m_red) ,	
			sum(secondaryprev),	sum(varprev_s_acc),	sum(varprev_s_red) ,
			sum(currentarrears ),
			sum(mov_finphase_C) ,	sum(var_finphase_acc_C ),	sum(var_finphase_red_C ),
			sum(mov_maxphase_C ),	sum(var_maxphase_C ),
			sum(mov_finphase_R ),	sum(var_finphase_acc_R ), sum(var_finphase_red_R ),
			sum(mov_maxphase_R) ,	sum(var_maxphase_R), 
			sum(prevision_advance),
			sum(secondary_prevision_advance),
			--prevision_diff_comp,	
			ISNULL(SUM(initialprevision),0) +	ISNULL(SUM(varprev_m_acc),0) -isnull(sum(prevision_advance),0)  - 	ISNULL(SUM(varprev_m_red),0) -
	 	 	ISNULL(SUM(mov_finphase_C),0) - ISNULL(SUM(var_finphase_acc_C),0) -ISNULL(SUM(var_finphase_red_C),0),

			---prevision_diff_cassa =  
			ISNULL(SUM(secondaryprev),0) + 	 	ISNULL(SUM(varprev_s_acc),0)  - isnull(sum(secondary_prevision_advance),0) - 	ISNULL(SUM(varprev_s_red),0) -
	 	 			ISNULL(SUM(mov_maxphase_C),0) -  	ISNULL(SUM(var_maxphase_C),0) -
		 			ISNULL(SUM(mov_maxphase_R),0) -	 	ISNULL(SUM(var_maxphase_R),0)
		from #data
		
		
		group by idfin,idupb 
	)
 
 

	 SELECT  f.codefin  as code1,
			f.title AS description1, 
			@lev_desc1 AS lev_desc1,
			f.printingorder as order1,
			upb.codeupb,
			upb.idupb as idupb,
			upb.title as upb,
			upb.printingorder as upbprintingorder,
			isnull(sum(initialprevision),0) as initialprevision,	
			ISNULL(sum(varprev_m_acc),0)  as varprev_m_acc,	
			ISNULL(sum(varprev_m_red),0)  as varprev_m_red,	
			ISNULL(sum(secondaryprev),0)  as secondaryprev,
			ISNULL(sum(varprev_s_acc),0)  as varprev_s_acc,	
			ISNULL(sum(varprev_s_red),0)  as varprev_s_red,
			ISNULL(sum(currentarrears),0)  as currentarrears,
			ISNULL(sum(mov_finphase_C),0)  as mov_finphase_C,	
			ISNULL(sum(var_finphase_acc_C),0)  as var_finphase_acc_C,	
			ISNULL(sum(var_finphase_red_C),0)  as var_finphase_red_C,
			ISNULL(sum(mov_maxphase_C),0)  as mov_maxphase_C ,	
			ISNULL(sum(var_maxphase_C),0)  as var_maxphase_C,
			ISNULL(sum(mov_finphase_R),0)  as mov_finphase_R ,	
			ISNULL(sum(var_finphase_acc_R ),0)  as var_finphase_acc_R , 
			ISNULL(sum(var_finphase_red_R),0)  as var_finphase_red_R,
			ISNULL(sum(mov_maxphase_R),0) as mov_maxphase_R,	
			ISNULL(sum(var_maxphase_R),0) as var_maxphase_R,
			--isnull(sum(prevision_advance),0) as prevision_advance,
			case @fin_kind when 2 then 'S' else 'C' end  as previsionkind,
			@supposed_ff_jan01 as supposed_ff_jan01,
			@supposed_aa_jan01 as supposed_aa_jan01,
			@ff_jan01 as ff_jan01,
			@aa_jan01 as aa_jan01,
			@showupb as showupb,
			ISNULL(sum(case when prevision_diff_comp<0 then -prevision_diff_comp else 0 end),0)  as prevision_diff_acc_comp  ,
			ISNULL(sum(case when prevision_diff_comp>=0 then prevision_diff_comp else 0 end),0)  as prevision_diff_red_comp ,
			ISNULL(sum(case when prevision_diff_cassa<0 then -prevision_diff_cassa else 0 end),0) as prevision_diff_acc_cassa  ,
			ISNULL(sum(case when prevision_diff_cassa>=0 then prevision_diff_cassa else 0 end),0)  as prevision_diff_red_cassa ,
			isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
			isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
			isnull(@aa_01_jan_used,0) as aa_01_jan_used,
			isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used ,
			CASE
			WHEN EXISTS 
				(SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0)) THEN 'S'
					ELSE 'N'
			END  AS flagadvance
		FROM fin f				
		cross join  upb 
			left outer join finlink 
				on finlink.idparent=f.idfin 
			left outer join raggruppa_capitoli 
				on raggruppa_capitoli.idfin=finlink.idchild and raggruppa_capitoli.idupb=upb.idupb
		where 
			( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (upb.idupb='0001' or raggruppa_capitoli.idfin is not null)) and
			f.ayear=@ayear 
			AND ((f.flag & 1)= @finpart_bit) 
			AND (f.nlevel = 1)
			and upb.idupb like @idupb
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
			group by f.codefin, f.title , f.printingorder,
			upb.codeupb,upb.idupb,upb.title ,upb.printingorder, 
			upb.idsor01,  upb.idsor02,  upb.idsor03, upb.idsor04, upb.idsor05 ,
			f.idfin  

		ORDER BY upbprintingorder ASC, order1 ASC

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

	print 'with N';

	with raggruppa_capitoli	(
			idfin, idupb,
			initialprevision ,	varprev_m_acc ,	varprev_m_red ,	
			secondaryprev,	varprev_s_acc ,	varprev_s_red ,
			currentarrears ,
			mov_finphase_C ,	var_finphase_acc_C ,	var_finphase_red_C ,
			mov_maxphase_C ,	var_maxphase_C ,
			mov_finphase_R ,	var_finphase_acc_R ,var_finphase_red_R ,
			mov_maxphase_R ,	var_maxphase_R ,prevision_advance, secondary_prevision_advance,
		prevision_diff_comp,	
		prevision_diff_cassa )
	AS
	(
		select 					
			idfin, idupb,
			sum(initialprevision) ,	sum(varprev_m_acc) ,	sum(varprev_m_red) ,	
			sum(secondaryprev),	sum(varprev_s_acc),	sum(varprev_s_red) ,
			sum(currentarrears ),
			sum(mov_finphase_C) ,	sum(var_finphase_acc_C ),	sum(var_finphase_red_C ),
			sum(mov_maxphase_C ),	sum(var_maxphase_C ),
			sum(mov_finphase_R ),	sum(var_finphase_acc_R ), sum(var_finphase_red_R ),
			sum(mov_maxphase_R) ,	sum(var_maxphase_R), 
			sum(prevision_advance),sum(secondary_prevision_advance),

			--prevision_diff_comp,	
			ISNULL(SUM(initialprevision),0) -isnull(sum(prevision_advance),0)  +	ISNULL(SUM(varprev_m_acc),0) - 	ISNULL(SUM(varprev_m_red),0) -
	 	 	ISNULL(SUM(mov_finphase_C),0) - ISNULL(SUM(var_finphase_acc_C),0) -ISNULL(SUM(var_finphase_red_C),0),
			
			---prevision_diff_cassa =  
			ISNULL(SUM(secondaryprev),0) + 	 	ISNULL(SUM(varprev_s_acc),0) - isnull(sum(secondary_prevision_advance),0) - 	ISNULL(SUM(varprev_s_red),0) -
	 	 			ISNULL(SUM(mov_maxphase_C),0) -  	ISNULL(SUM(var_maxphase_C),0) -
		 			ISNULL(SUM(mov_maxphase_R),0) -	 	ISNULL(SUM(var_maxphase_R),0)
		from #data
		
		
		group by idfin,idupb
		
	)

	 SELECT  f.codefin  as code1,
			f.title AS description1, 
			@lev_desc1 AS lev_desc1,
			f.printingorder as order1,
			@codeupb as codeupb,
			@ext_idupb as idupb,
			@upb as upb,
			@upbprintingorder as upbprintingorder,
			ISNULL(sum(initialprevision),0) as initialprevision,	
			ISNULL(sum(varprev_m_acc),0)  as varprev_m_acc,	
			ISNULL(sum(varprev_m_red),0)  as varprev_m_red,	
			ISNULL(sum(secondaryprev),0)  as secondaryprev,
			ISNULL(sum(varprev_s_acc),0)  as varprev_s_acc,	
			ISNULL(sum(varprev_s_red),0)  as varprev_s_red,
			ISNULL(sum(currentarrears),0)  as currentarrears,
			ISNULL(sum(mov_finphase_C),0)  as mov_finphase_C,	
			ISNULL(sum(var_finphase_acc_C),0)  as var_finphase_acc_C,	
			ISNULL(sum(var_finphase_red_C),0)  as var_finphase_red_C,
			ISNULL(sum(mov_maxphase_C),0)  as mov_maxphase_C ,	
			ISNULL(sum(var_maxphase_C),0)  as var_maxphase_C,
			ISNULL(sum(mov_finphase_R),0)  as mov_finphase_R ,	
			ISNULL(sum(var_finphase_acc_R ),0)  as var_finphase_acc_R , 
			ISNULL(sum(var_finphase_red_R),0)  as var_finphase_red_R,
			ISNULL(sum(mov_maxphase_R),0)  as mov_maxphase_R,	
			ISNULL(sum(var_maxphase_R),0)  as var_maxphase_R,
			--isnull(sum(prevision_advance),0) as prevision_advance,
			case @fin_kind when 2 then 'S' else 'C' end  as previsionkind,
			@supposed_ff_jan01 as supposed_ff_jan01,
			@supposed_aa_jan01 as supposed_aa_jan01,
			@ff_jan01 as ff_jan01,
			@aa_jan01 as aa_jan01,
			@showupb as showupb,
			ISNULL(sum(case when prevision_diff_comp<0 then -prevision_diff_comp else 0 end),0)  as prevision_diff_acc_comp  ,
			ISNULL(sum(case when prevision_diff_comp>=0 then prevision_diff_comp else 0 end),0)  as prevision_diff_red_comp ,
			ISNULL(sum(case when prevision_diff_cassa<0 then -prevision_diff_cassa else 0 end),0) as prevision_diff_acc_cassa  ,
			ISNULL(sum(case when prevision_diff_cassa>=0 then prevision_diff_cassa else 0 end),0)  as prevision_diff_red_cassa ,
			isnull(@floatfund_01_jan_used,0) as floatfund_01_jan_used,
			isnull(@supposed_aa_01_jan_used,0) as supposed_aa_01_jan_used,
			isnull(@aa_01_jan_used,0) as aa_01_jan_used,
			isnull(@supposed_ff_01_jan_used,0) as supposed_ff_01_jan_used 			,
			 CASE
			WHEN EXISTS 
				(SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0)) THEN 'S'
					ELSE 'N'
			END  AS flagadvance
		FROM fin f				
			left outer join finlink 
				on finlink.idparent=f.idfin 
			left outer join raggruppa_capitoli 
				on raggruppa_capitoli.idfin=finlink.idchild 

					
		where 
			 ( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (/*upb.idupb='0001' or */raggruppa_capitoli.idfin is not null)) and
		f.ayear=@ayear 
		AND ((f.flag & 1)= @finpart_bit) 
		AND (f.nlevel = 1)		
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR NOT EXISTS (SELECT * FROM fin 
					JOIN  finlast
							ON finlast.idfin = fin.idfin
					JOIN finlink 
							ON finlink.idparent = f.idfin  
							AND finlink.idchild = finlast.idfin  
					WHERE (fin.flag&16 <>0) ))

		group by f.codefin, f.title , f.printingorder, 	f.idfin  
		ORDER BY upbprintingorder ASC, order1 ASC


END




END

go


 

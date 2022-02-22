
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazioneupbbilancio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazioneupbbilancio]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- exec exp_situazioneupbbilancio '2018', {ts '2018-04-26 00:00:00.000'}, 'S', '00010030', 'N', null, null, null, null, null, null
CREATE    PROCEDURE [exp_situazioneupbbilancio]
(
	@ayear smallint,
	@date datetime,
	@finpart char(1),
	@idupb varchar(36) = null,
	@showchildupb char(1),
	@idfin int = null,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS
BEGIN

set @idupb = isnull(@idupb,'%')
-- SE vogliamo vedere anche i figli, @idupb diventa '0001%'
-- altrimenti resta '0001' o '%', se non c'è stata alcuna selezione
if (@showchildupb = 'S') 
begin
	set @idupb = @idupb+'%'
end 

DECLARE @levelusable tinyint -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear

DECLARE	@nlevel tinyint -- Livello della voce di bilancio
SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin
if(@nlevel is null)
begin
	select @nlevel =  max(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear--> lavora con l'ultimo livello
End

print @nlevel
DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

DECLARE @finphaseexpense tinyint
DECLARE @maxphaseexpense tinyint

SELECT @finphaseexpense = appropriationphasecode FROM config WHERE ayear = @ayear
IF @finphaseexpense IS NULL
BEGIN
	SELECT @finphaseexpense = expensefinphase FROM uniconfig
END
SELECT @maxphaseexpense = MAX(nphase) FROM expensephase


DECLARE @finphaseincome tinyint
DECLARE @maxphaseincome tinyint

SELECT @finphaseincome = assessmentphasecode FROM config WHERE ayear = @ayear
IF @finphaseincome IS NULL
BEGIN
	SELECT @finphaseincome  = incomefinphase FROM uniconfig
END
SELECT @maxphaseincome= MAX(nphase) FROM incomephase

DECLARE @firstday datetime
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)

CREATE TABLE #PREVISIONE_PRINCIPALE_INIZIALE(
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  
	
INSERT INTO #PREVISIONE_PRINCIPALE_INIZIALE( idupb, idfin, amount)  
select U.idupb, isnull(FLK.idparent,U.idfin), isnull(U.currentprev,0)
	from upbtotal U --> Lasciamo il totalizzatore, perchè totalizza i figli. Altrimenti dobbiamo distinguere tra capitoli e articoli
	join upb 
		on upb.idupb = U.idupb	
	join fin f
		on U.idfin = f.idfin	
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
	left outer JOIN finlink FLK
		ON FLK.idchild = f.idfin AND FLK.nlevel = @nlevel
where (U.idupb like @idupb)		
	and ((@idfin IS not NULL and isnull(FLK.idparent,U.idfin) = @idfin
	OR  (@idfin IS  NULL))
	AND (f.nlevel = @nlevel
		OR (f.nlevel < @nlevel
		 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
		 AND (fl.flag&2)<>0
		 )
	   )
	 )
	and f.ayear = @ayear
	AND 
	(
		((f.flag & 1)<>0  AND @finpart = 'S')--Parte spesa
		OR
		((f.flag & 1)= 0  AND @finpart = 'E')--Parte entrata
	)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

--SELECT * FROM #PREVISIONE_PRINCIPALE_INIZIALE
CREATE TABLE #VAR_PREVISIONE_PRINCIPALE(
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)

INSERT INTO #VAR_PREVISIONE_PRINCIPALE( idupb, idfin, amount)  
select D.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)
	from finvar V
	JOIN finvardetail D 	
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar	
	join upb 
		on upb.idupb = D.idupb	
	join fin
		on D.idfin = fin.idfin	
	left outer JOIN finlink FLK
		ON FLK.idchild = D.idfin  AND FLK.nlevel = @nlevel
where (D.idupb like @idupb)
	--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	and (@idfin is null or  FLK.idparent = @idfin)
	and V.yvar = @ayear
	AND V.adate <= @date
	AND V.flagprevision = 'S'
	AND 
	(
		((fin.flag & 1)<>0  AND @finpart = 'S')--Parte spesa
		OR
		((fin.flag & 1)= 0  AND @finpart = 'E')--Parte entrata
	)
	AND V.idfinvarstatus = 5 
	AND V.variationkind <> 5
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY D.idupb, isnull(FLK.idparent,D.idfin)

 
CREATE TABLE #PREVISIONE_SECONDARIA_INIZIALE(
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)
INSERT INTO #PREVISIONE_SECONDARIA_INIZIALE( idupb, idfin, amount)  
select U.idupb, isnull(FLK.idparent,U.idfin), isnull(U.currentsecondaryprev,0)
	from upbtotal U --> Lasciamo il totalizzatore, perchè totalizza i figli. Altrimenti dobbiamo distinguere tra capitoli e articoli
	join upb 
		on upb.idupb = U.idupb	
	join fin f
		on U.idfin = f.idfin	
	JOIN finlevel fl
		ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
	left JOIN finlink FLK
		ON FLK.idchild = f.idfin AND FLK.nlevel = @nlevel
where (U.idupb like @idupb)
	and ((@idfin IS not NULL and isnull(FLK.idparent,U.idfin) = @idfin
	OR  (@idfin IS  NULL))
	AND (f.nlevel = @nlevel
		OR (f.nlevel < @nlevel
		 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
		 AND (fl.flag&2)<>0
		 )
	   )
	 )
	and f.ayear = @ayear
	AND 
	(
		((f.flag & 1)<>0 AND @finpart = 'S')--Parte spesa
		OR
		((f.flag & 1)= 0 AND @finpart = 'E')--Parte entrata
	)
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


CREATE TABLE #VAR_PREVISIONE_SECONDARIA(
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)

INSERT INTO #VAR_PREVISIONE_SECONDARIA( idupb, idfin, amount)  
select D.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)
	from finvar V
	JOIN finvardetail D 	
		ON V.yvar = D.yvar
		AND V.nvar = D.nvar	
	join upb 
		on upb.idupb = D.idupb	
	join fin
		on D.idfin = fin.idfin	
	left outer JOIN finlink FLK
		ON FLK.idchild = D.idfin AND FLK.nlevel = @nlevel
where (D.idupb like @idupb)
--	AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
	and (@idfin is null or  FLK.idparent = @idfin)
	and V.yvar = @ayear
	AND V.adate <= @date
	AND (V.flagsecondaryprev = 'S')
	AND 
	(
		((fin.flag & 1)<>0  AND @finpart = 'S')--Parte spesa
		OR
		((fin.flag & 1)= 0  AND @finpart = 'E')--Parte entrata
	)
	AND V.idfinvarstatus = 5 -- Approvate
	AND V.variationkind <> 5 
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY D.idupb, isnull(FLK.idparent,D.idfin)

IF (@finpart = 'S')
BEGIN
	
	CREATE TABLE #PICCOLE_SPESE(
		idunderwriting int, 
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  

	INSERT INTO #PICCOLE_SPESE( idupb, idfin, amount)  
	select  operation.idupb, isnull(FLK.idparent,operation.idfin), SUM(operation.amount)
		from  pettycashoperation operation
		join upb 
			on upb.idupb = operation.idupb	
		join fin
			on fin.idfin = operation.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = operation.idfin AND FLK.nlevel = @nlevel
	where (operation.idupb like @idupb)
			--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			and (@idfin is null or  FLK.idparent = @idfin)
			and fin.ayear = @ayear  AND @finpart = 'S'
			AND operation.adate	<= @date
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
			AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
								WHERE restoreop.yrestore = operation.yrestore
									AND restoreop.nrestore = operation.nrestore
									AND restoreop.idpettycash = operation.idpettycash)
	group by  operation.idupb,  isnull(FLK.idparent,operation.idfin)

	CREATE TABLE #IMPEGNI_COMP(
		idunderwriting int, 
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  

	INSERT INTO #IMPEGNI_COMP( idupb, idfin, amount) 
	SELECT idupb, idfin, SUM(amount) 
	FROM
		(select EY.idupb, isnull(FLK.idparent,EY.idfin) as idfin, ISNULL(EY.amount,0) AS amount
			FROM expense E
			JOIN expenseyear EY
				ON EY.idexp = E.idexp
			JOIN expensetotal ET
				ON ET.idexp = EY.idexp
				AND ET.ayear = EY.ayear
			join upb 
				on upb.idupb = EY.idupb	
			left outer JOIN finlink FLK
				ON FLK.idchild = EY.idfin AND FLK.nlevel = @nlevel
		where (EY.idupb like @idupb)
				--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				and (@idfin is null or  FLK.idparent = @idfin)
				and E.adate <= @date
				and EY.ayear = @ayear
				and E.nphase = @finphaseexpense	
				AND ( (ET.flag & 1) = 0) -- Competenza
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		UNION ALL
			select EY.idupb, isnull(FLK.idparent,EY.idfin) as idfin, ISNULL(EV.amount,0) as amount
			FROM expensevar EV
			JOIN expenseyear EY
				ON EY.idexp = EV.idexp
			JOIN expense E
				ON EY.idexp = E.idexp
			JOIN expensetotal ET
				ON ET.idexp = EY.idexp
				AND ET.ayear = EY.ayear
			join upb 
				on upb.idupb = EY.idupb	
			LEFT OUTER JOIN finlink FLK
				ON FLK.idchild = EY.idfin AND FLK.nlevel = @nlevel
		where (EY.idupb like @idupb)
				--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				and (@idfin is null or  FLK.idparent = @idfin)
				and EV.adate <= @date
				and EV.yvar = @ayear
				and E.nphase = @finphaseexpense	
				AND ( (ET.flag & 1) = 0) -- Competenza
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		) as Impegni
	group by idupb, idfin


	CREATE TABLE #IMPEGNI_RESIDUI_01_01(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  
	
	INSERT INTO #IMPEGNI_RESIDUI_01_01(idupb, idfin, amount)
		SELECT
			EY.idupb,
			ISNULL(FLK.idparent,EY.idfin), 
			SUM(EY.amount)
		FROM expense E
		JOIN expenseyear EY
			ON EY.idexp = E.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		left outer JOIN finlink FLK
			ON FLK.idchild = EY.idfin  AND FLK.nlevel = @nlevel
		WHERE  E.adate <= @firstday
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) <> 0) -- Residuo
			AND E.nphase = @finphaseexpense
			AND (EY.idupb  like @idupb)	
			--AND (( @idfin is null AND FLK.nlevel = @levelusable) OR (FLK.idparent = @idfin AND FLK.nlevel = @nlevel) )
			and (@idfin is null or  FLK.idparent = @idfin)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
		GROUP BY EY.idupb, ISNULL(FLK.idparent,EY.idfin) 
	
	CREATE TABLE #VAR_IMPEGNI_RESIDUI(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  

	INSERT INTO #VAR_IMPEGNI_RESIDUI(idupb, idfin, amount)
		SELECT
			EY.idupb,
			ISNULL(FLK.idparent,EY.idfin),
			SUM(EV.amount)
		FROM expensevar EV
		JOIN expense E
			ON EV.idexp = E.idexp
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp
			AND ET.ayear = EY.ayear
		left outer JOIN finlink FLK
			ON FLK.idchild = EY.idfin  AND FLK.nlevel = @nlevel
		WHERE EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND EV.adate <= @date 
			AND ( (ET.flag & 1) <> 0) -- Residuo
			AND E.nphase = @finphaseexpense
			AND (EY.idupb LIKE @idupb)		
			--AND (( @idfin is null AND FLK.nlevel = @levelusable)OR 	(FLK.idparent = @idfin AND FLK.nlevel = @nlevel) )
			and (@idfin is null or  FLK.idparent = @idfin)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)

	CREATE TABLE #DOT_CREDITI(
		idunderwriting int, 
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		) 
		
	INSERT INTO #DOT_CREDITI( idupb, idfin, amount) --> Variazioni Crediti
	select D.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)
		from finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join upb 
			on upb.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin   AND FLK.nlevel = @nlevel
	where (D.idupb like @idupb )
		--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		and (@idfin is null or  FLK.idparent = @idfin)
		and V.yvar = @ayear
		AND V.adate <= @date
		AND V.flagcredit = 'S'
		AND ( (fin.flag & 1)<>0 )--Parte spesa
		AND V.idfinvarstatus = 5 
		AND V.variationkind <> 5
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY D.idupb, isnull(FLK.idparent,D.idfin)
			
	CREATE TABLE #ASSEGNAZIONI_CREDITI(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		) 


	INSERT INTO #ASSEGNAZIONI_CREDITI( idupb, idfin, amount) 
		select D.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)
		from creditpart D 	
		join upb 
			on upb.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin  AND FLK.nlevel = @nlevel
	where (D.idupb like @idupb )
		--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		and (@idfin is null or  FLK.idparent = @idfin)
		and D.ycreditpart = @ayear
		AND D.adate <= @date
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY D.idupb, isnull(FLK.idparent,D.idfin)

	CREATE TABLE #DOT_INCASSI(
		idunderwriting int, 
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		) 

	INSERT INTO	#DOT_INCASSI( idupb, idfin, amount)  
	select D.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)
		from finvar V
		JOIN finvardetail D 	
			ON V.yvar = D.yvar
			AND V.nvar = D.nvar	
		join upb 
			on upb.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin  AND FLK.nlevel = @nlevel
	where (D.idupb like @idupb )
		--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		and (@idfin is null or  FLK.idparent = @idfin)
		and V.yvar = @ayear
		AND V.adate <= @date
		AND V.flagproceeds = 'S'
		AND ( (fin.flag & 1)<>0 )--Parte spesa
		AND V.idfinvarstatus = 5 
		AND V.variationkind <> 5
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY D.idupb, isnull(FLK.idparent,D.idfin)

	CREATE TABLE #ASSEGNAZIONI_INCASSI(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		) 

	INSERT INTO	#ASSEGNAZIONI_INCASSI( idupb, idfin, amount)  
		select D.idupb, isnull(FLK.idparent,D.idfin), sum(D.amount)
		from proceedspart D 	
		join upb 
			on upb.idupb = D.idupb	
		join fin
			on D.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = D.idfin  AND FLK.nlevel = @nlevel
	where (D.idupb like @idupb )
		--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
		and (@idfin is null or  FLK.idparent = @idfin)
		and D.yproceedspart = @ayear
		AND D.adate <= @date
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY D.idupb, isnull(FLK.idparent,D.idfin)


	CREATE TABLE #PAGAMENTI(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2),
		flagarrear char(1)
		)  
		
	INSERT INTO #PAGAMENTI( idupb, idfin, amount, flagarrear)  
	select idupb, idfin, sum(amount), flagarrear FROM
	(
	select  HPV.idupb, isnull(FLK.idparent, HPV.idfin) as idfin, ISNULL(HPV.amount,0) as amount, HPV.flagarrear
		from historypaymentview HPV
		join upb 
			on upb.idupb = HPV.idupb	
		join fin
			on HPV.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = HPV.idfin  AND FLK.nlevel = @nlevel
	where  (HPV.idupb like @idupb )
			--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			and (@idfin is null or  FLK.idparent = @idfin)
			and HPV.ymov = @ayear
			AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	UNION ALL
		SELECT HPV.idupb,
				ISNULL(FLK.idparent,HPV.idfin) as idfin,
				ISNULL(EV.amount,0) as amount,HPV.flagarrear
			FROM expensevar EV
			JOIN historypaymentview HPV
				ON HPV.idexp = EV.idexp
			join upb 
				on upb.idupb = HPV.idupb
			LEFT OUTER JOIN finlink FLK
				ON FLK.idchild = HPV.idfin  AND FLK.nlevel = @nlevel
			WHERE (HPV.idupb like @idupb )
				--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				and (@idfin is null or  FLK.idparent = @idfin)
				AND HPV.ymov = @ayear
				 AND EV.yvar = @ayear
				AND EV.adate <= @date
				AND HPV.competencydate <= @date 
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

	) as Pagamenti
	GROUP BY idupb, idfin, flagarrear


	--> COMPETENZA E CASSA 
	IF (@fin_kind = 3) 
	BEGIN
		;with UWT(idfin,idupb) 
		 as 
		(select isnull(finlink.idparent,myUWT.idfin), myUWT.idupb
				from 	upbtotal myUWT 
					join fin F		on myUWT.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U	on myUWT.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
			  where  (myUWT.idupb like @idupb )
					and  ((F.flag & 1)<>0 )--Parte spesa
					and ((@idfin IS not NULL and isnull(finlink.idparent,myUWT.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
		union all
			select isnull(finlink.idparent, UET.idfin), UET.idupb
				from 	upbexpensetotal UET 
					join fin F		on UET.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on UET.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
					left outer join upbtotal UT on  UT.idfin= UET.idfin and UT.idupb=UET.idupb
			  where  (UET.idupb like @idupb )
					and  ((F.flag & 1)<>0 )--Parte spesa
					and ((@idfin IS not NULL and isnull(finlink.idparent,UET.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
					AND UT.idfin is null
					and UET.nphase = @finphaseexpense
	)	
			select  
				U.codeupb as 'UPB',
				F.codefin as 'Bilancio',
				isnull(PPI.amount,0) as 'Prev.Competenza iniziale',
				isnull(VPI.amount,0) as 'Var. Prev. Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0) as 'Prev.Competenza attuale',
				isnull(Cred.amount,0) as 'Dotacione Crediti',
				isnull(AssCred.amount,0) as 'Assegnazione Crediti',
				isnull(Cred.amount,0) + isnull(AssCred.amount,0) as 'Crediti totali attribuiti',
				isnull(ImpComp.amount,0) + isnull(OPS.amount,0) as 'Impegni di Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(ImpComp.amount,0) - isnull(OPS.amount,0)  as 'Previsione disponibile Comp.',
				isnull(Cred.amount,0) +isnull(AssCred.amount,0) - isnull(ImpComp.amount,0) -isnull(OPS.amount,0) as 'Crediti Residui',
				isnull(PSI.amount,0) as 'Prev.Cassa iniziale',
				isnull(VPS.amount,0) as 'Var. Prev. Cassa',
				isnull(PSI.amount,0) + isnull(VPS.amount,0) as 'Prev.Cassa attuale',
				isnull(Incas.amount,0) as 'Dotazione Cassa',
				isnull(AssIncas.amount,0) as 'Assegnazione Incassi',
				isnull(Incas.amount,0) + isnull(AssIncas.amount,0) as 'Cassa totale attribuita',
				isnull(ImpRes_01_01.amount,0)   as 'Impegni Residui all'' 01/01',
				isnull(VarImpRes.amount,0) as 'Var. Impegni residui',
				isnull(PagComp.amount,0) as 'Totale Pagamenti di Competenza',
				isnull(PagRes.amount,0) as 'Totale Pagamenti residui',
				isnull(PSI.amount,0) + isnull(VPS.amount,0)  - isnull(PagComp.amount,0) - isnull(PagRes.amount,0) -isnull(OPS.amount,0)  as 'Previsione disponibile Cassa',
				--Residui al 31/12 (che è valorizzata come "Impegni di Competenza"-"Pagato di competenza"+
				--"Impegni Residui al 01/01"+"Var. Impegni residui"-"Pagato in conto residui")
				isnull(ImpComp.amount,0) - isnull(PagComp.amount,0) + isnull(ImpRes_01_01.amount,0) + 
				isnull(VarImpRes.amount,0) - isnull(PagRes.amount,0) as 'Residui al 31/12',
				isnull(Incas.amount,0)+isnull(AssIncas.amount,0)-isnull(PagComp.amount,0) -isnull(PagRes.amount,0) as 'Cassa Residua'
				
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON  PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_PRINCIPALE VPI
   				ON  VPI.idupb = UWT.idupb and VPI.idfin = UWT.idfin 
			left outer join #PREVISIONE_SECONDARIA_INIZIALE PSI
   				ON  PSI.idupb = UWT.idupb and PSI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_SECONDARIA VPS
   				ON  VPS.idupb = UWT.idupb and VPS.idfin = UWT.idfin 
			left outer join #PICCOLE_SPESE OPS	
   				ON  OPS.idupb = UWT.idupb and OPS.idfin = UWT.idfin 
			left outer join #IMPEGNI_COMP ImpComp
   				ON  ImpComp.idupb = UWT.idupb and ImpComp.idfin = UWT.idfin 
			left outer join	#VAR_IMPEGNI_RESIDUI VarImpRes
				ON  VarImpRes.idupb = UWT.idupb and VarImpRes.idfin = UWT.idfin 
			left outer join #IMPEGNI_RESIDUI_01_01 ImpRes_01_01
   				ON  ImpRes_01_01.idupb = UWT.idupb and ImpRes_01_01.idfin = UWT.idfin 
			left outer join #DOT_CREDITI Cred
   				ON  Cred.idupb = UWT.idupb and Cred.idfin = UWT.idfin 		
			left outer join #ASSEGNAZIONI_CREDITI AssCred	 
				ON  AssCred.idupb = UWT.idupb and AssCred.idfin = UWT.idfin 		
			left outer join #PAGAMENTI PagComp 
   				ON  PagComp.idupb = UWT.idupb and PagComp.idfin = UWT.idfin AND PagComp.flagarrear = 'C'
   			left outer join #PAGAMENTI PagRes
   				ON  PagRes.idupb = UWT.idupb and PagRes.idfin = UWT.idfin AND PagRes.flagarrear = 'R'
			left outer join #DOT_INCASSI Incas
   				ON  incas.idupb = UWT.idupb and incas.idfin = UWT.idfin
			left outer join #ASSEGNAZIONI_INCASSI AssIncas
				ON  AssIncas.idupb = UWT.idupb and AssIncas.idfin = UWT.idfin 	
			where ((F.flag & 1)<>0 )--Parte spesa
			order by  U.codeupb,F.codefin

	END   


	--> SOLO COMPETENZA 
	IF (@fin_kind = 1) 
	BEGIN
		;with UWT(idfin,idupb) 
		 as 
		(select myUWT.idfin,myUWT.idupb
				from 	upbtotal myUWT 
					join fin F		on myUWT.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on myUWT.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
			  where  (myUWT.idupb like @idupb )
					and  ((F.flag & 1)<>0 )--Parte spesa
				 
					and ((@idfin IS not NULL and isnull(finlink.idparent,myUWT.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
	
	
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
		union all
			select UET.idfin,UET.idupb
				from 	upbexpensetotal UET 
					join fin F		on UET.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on UET.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
					left outer join upbtotal UT on  UT.idfin= UET.idfin and UT.idupb=UET.idupb
			  where  (UET.idupb like @idupb )
					and  ((F.flag & 1)<>0 )--Parte spesa
					and ((@idfin IS not NULL and isnull(finlink.idparent,UET.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
					AND UT.idfin is null
					and UET.nphase = @finphaseexpense
	)	
			select  
				U.codeupb as 'UPB',
				F.codefin as 'Bilancio',
				isnull(PPI.amount,0) as 'Prev.Competenza iniziale',
				isnull(VPI.amount,0) as 'Var. Prev. Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0) as 'Prev.Competenza attuale',
				isnull(Cred.amount,0) as 'Dotazione Crediti',
				isnull(AssCred.amount,0) as 'Assegnazione Crediti',
				isnull(Cred.amount,0) + isnull(AssCred.amount,0) as 'Crediti totali attribuiti',
				isnull(ImpComp.amount,0) + isnull(OPS.amount,0) as 'Impegni di Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(ImpComp.amount,0) - isnull(OPS.amount,0)   as 'Previsione disponibile',
				isnull(Cred.amount,0) +isnull(AssCred.amount,0) - isnull(ImpComp.amount,0) -isnull(OPS.amount,0) as 'Crediti Residui',
				isnull(ImpRes_01_01.amount,0) as 'Impegni Residui all'' 01/01',
				isnull(VarImpRes.amount,0) as 'Var. Impegni residui'
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON  PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_PRINCIPALE VPI
   				ON  VPI.idupb = UWT.idupb and VPI.idfin = UWT.idfin 
			left outer join #PICCOLE_SPESE OPS	
   				ON  OPS.idupb = UWT.idupb and OPS.idfin = UWT.idfin 
			left outer join #IMPEGNI_COMP ImpComp
   				ON  ImpComp.idupb = UWT.idupb and ImpComp.idfin = UWT.idfin 
			left outer join	#VAR_IMPEGNI_RESIDUI VarImpRes
				ON  VarImpRes.idupb = UWT.idupb and VarImpRes.idfin = UWT.idfin 
			left outer join #IMPEGNI_RESIDUI_01_01 ImpRes_01_01
   				ON  ImpRes_01_01.idupb = UWT.idupb and ImpRes_01_01.idfin = UWT.idfin 
			left outer join #DOT_CREDITI Cred
   				ON  Cred.idupb = UWT.idupb and Cred.idfin = UWT.idfin 		
			left outer join #ASSEGNAZIONI_CREDITI AssCred	 
				ON  AssCred.idupb = UWT.idupb and AssCred.idfin = UWT.idfin 	
			where ((F.flag & 1)<>0 )--Parte spesa	
			order by  U.codeupb,F.codefin

	END   


	--> SOLO CASSA 
	IF (@fin_kind = 2) 
	BEGIN
		;with UWT(idfin,idupb) 
		 as 
		(select myUWT.idfin,myUWT.idupb
				from 	upbtotal myUWT 
					join fin F		on myUWT.idfin = F.idfin
					JOIN finlevel fl ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on myUWT.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin AND finlink.nlevel = @nlevel
			  where  (myUWT.idupb like @idupb )
					 
					and ((@idfin IS not NULL and isnull(finlink.idparent,myUWT.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					
					and  ((F.flag & 1)<>0 )--Parte spesa
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
		union all
			select UET.idfin,UET.idupb
				from 	upbexpensetotal UET 
					join fin F		on UET.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on UET.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
					left outer join upbtotal UT on  UT.idfin= UET.idfin and UT.idupb=UET.idupb
			  where  (UET.idupb like @idupb )
					and  ((F.flag & 1)<>0 )--Parte spesa
					and ((@idfin IS not NULL and isnull(finlink.idparent,UET.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
					AND UT.idfin is null
					and UET.nphase = @finphaseexpense
	)	
			select  
				U.codeupb as 'UPB',
				F.codefin as 'Bilancio',
				isnull(PPI.amount,0) as 'Prev.Cassa iniziale',
				isnull(VPI.amount,0) as 'Var. Prev. Cassa',
				isnull(PPI.amount,0) + isnull(VPI.amount,0) as 'Prev.Cassa attuale',
				isnull(Incas.amount,0) as 'Dotazione Cassa',
				isnull(AssIncas.amount,0) as 'Assegnazione Incassi',
				isnull(Incas.amount,0) + isnull(AssIncas.amount,0) as 'Cassa totale attribuita',
				isnull(PagComp.amount,0) as 'Totale Pagamenti Competenza',
				isnull(PagRes.amount,0) as 'Totale Pagamenti Residui',
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(PagComp.amount,0) - isnull(PagRes.amount,0)   as 'Previsione disponibile',
				isnull(Incas.amount,0)+isnull(AssIncas.amount,0)-isnull(PagComp.amount,0) - isnull(PagRes.amount,0)  as 'Cassa Residua'
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON  PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_PRINCIPALE VPI
   				ON  VPI.idupb = UWT.idupb and VPI.idfin = UWT.idfin 
			left outer join #PAGAMENTI PagComp 
   				ON  PagComp.idupb = UWT.idupb and PagComp.idfin = UWT.idfin AND PagComp.flagarrear = 'C'
   			left outer join #PAGAMENTI PagRes
   				ON  PagRes.idupb = UWT.idupb and PagRes.idfin = UWT.idfin AND PagRes.flagarrear = 'R'
			left outer join #DOT_INCASSI Incas
   				ON  incas.idupb = UWT.idupb and incas.idfin = UWT.idfin
			left outer join #ASSEGNAZIONI_INCASSI AssIncas
				ON  AssIncas.idupb = UWT.idupb and AssIncas.idfin = UWT.idfin 		
			where ((F.flag & 1)<>0 )--Parte spesa
			order by  U.codeupb,F.codefin
			 
	END   
END
ELSE
BEGIN
	----------------------------------------
	--------- PARTE ENTRATE  ---------------
	----------------------------------------
	CREATE TABLE #ACCERTAMENTI_COMP(
		idunderwriting int, 
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  

	INSERT INTO #ACCERTAMENTI_COMP( idupb, idfin, amount) 
	SELECT idupb, idfin, SUM(amount) 
	FROM
		(select EY.idupb, isnull(FLK.idparent,EY.idfin) as idfin, ISNULL(EY.amount,0) AS amount
			FROM income E
			JOIN incomeyear EY
				ON EY.idinc = E.idinc
			JOIN incometotal ET
				ON ET.idinc = EY.idinc
				AND ET.ayear = EY.ayear
			join upb 
				on upb.idupb = EY.idupb	
			left outer JOIN finlink FLK
				ON FLK.idchild = EY.idfin AND FLK.nlevel = @nlevel
		where (EY.idupb like @idupb)
				and (@idfin is null or  FLK.idparent = @idfin)
				and E.adate <= @date
				and EY.ayear = @ayear
				and E.nphase = @finphaseincome
				AND ( (ET.flag & 1) = 0) -- Competenza
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		UNION ALL
			select EY.idupb, isnull(FLK.idparent,EY.idfin) as idfin, ISNULL(EV.amount,0) as amount
			FROM incomevar EV
			JOIN incomeyear EY
				ON EY.idinc = EV.idinc
			JOIN income E
				ON EY.idinc = E.idinc
			JOIN incometotal ET
				ON ET.idinc = EY.idinc
				AND ET.ayear = EY.ayear
			join upb 
				on upb.idupb = EY.idupb	
			LEFT OUTER JOIN finlink FLK
				ON FLK.idchild = EY.idfin AND FLK.nlevel = @nlevel
		where (EY.idupb like @idupb)
				--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
				and (@idfin is null or  FLK.idparent = @idfin)
				and EV.adate <= @date
				and EV.yvar = @ayear
				and E.nphase = @finphaseincome
				AND ( (ET.flag & 1) = 0) -- Competenza
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		) as Accertamenti
	group by idupb, idfin

	
	CREATE TABLE #ACCERTAMENTI_RESIDUI_01_01(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  

	INSERT INTO #ACCERTAMENTI_RESIDUI_01_01(idupb, idfin, amount)
		SELECT
			EY.idupb,
			ISNULL(FLK.idparent,EY.idfin), 
			SUM(EY.amount)
		FROM income E
		JOIN incomeyear EY
			ON EY.idinc = E.idinc
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN incometotal ET
			ON ET.idinc = EY.idinc
			AND ET.ayear = EY.ayear
		left outer JOIN finlink FLK
			ON FLK.idchild = EY.idfin  AND FLK.nlevel = @nlevel
		WHERE  E.adate <= @firstday
			AND EY.ayear = @ayear
			AND ( (ET.flag & 1) <> 0) -- Residuo
			AND E.nphase = @finphaseincome
			AND (EY.idupb  like @idupb)	
			and (@idfin is null or  FLK.idparent = @idfin)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		
		GROUP BY EY.idupb, ISNULL(FLK.idparent,EY.idfin) 
		
	CREATE TABLE #VAR_ACCERTAMENTI_RESIDUI(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2)
		)  

	INSERT INTO #VAR_ACCERTAMENTI_RESIDUI(idupb, idfin, amount)
		SELECT
			EY.idupb,
			ISNULL(FLK.idparent,EY.idfin),
			SUM(EV.amount)
		FROM incomevar EV
		JOIN income E
			ON EV.idinc = E.idinc
		JOIN incomeyear EY
			ON EY.idinc = EV.idinc
		JOIN upb U
			ON EY.idupb = U.idupb
		JOIN incometotal ET
			ON ET.idinc = EY.idinc
			AND ET.ayear = EY.ayear
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin  AND FLK.nlevel = @nlevel
		WHERE EV.yvar = @ayear
			AND EY.ayear = @ayear
			AND EV.adate <= @date 
			AND ( (ET.flag & 1) <> 0) -- Residuo
			AND E.nphase = @finphaseincome
			AND (EY.idupb LIKE @idupb)		
			AND (@idfin is null or  FLK.idparent = @idfin)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY EY.idupb,ISNULL(FLK.idparent,EY.idfin)
	
	
	
	CREATE TABLE #INCASSI(
		idupb varchar(36),	
		idfin int, 
		amount decimal(19,2),
		flagarrear char(1)
		)  
		
	INSERT INTO #INCASSI( idupb, idfin, amount,flagarrear)  
	select idupb, idfin, sum(amount) , flagarrear FROM
	(
	select  HPV.idupb, isnull(FLK.idparent, HPV.idfin) as idfin, ISNULL(HPV.amount,0) as amount, HPV.flagarrear
		from historyproceedsview HPV
		join upb 
			on upb.idupb = HPV.idupb	
		join fin
			on HPV.idfin = fin.idfin	
		left outer JOIN finlink FLK
			ON FLK.idchild = HPV.idfin  AND FLK.nlevel = @nlevel
	where  (HPV.idupb like @idupb )
			--AND (	(FLK.nlevel = @nlevel AND FLK.idparent = @idfin) OR (@idfin is null AND FLK.nlevel = @levelusable)   )
			and (@idfin is null or  FLK.idparent = @idfin)
			and HPV.ymov = @ayear
			AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	UNION ALL
		SELECT HPV.idupb,
				ISNULL(FLK.idparent,HPV.idfin) as idfin,
				ISNULL(EV.amount,0) as amount, HPV.flagarrear
			FROM incomevar EV
			JOIN historyproceedsview HPV
				ON HPV.idinc = EV.idinc
			join upb 
				on upb.idupb = HPV.idupb
			LEFT OUTER JOIN finlink FLK
				ON FLK.idchild = HPV.idfin  AND FLK.nlevel = @nlevel
			WHERE (HPV.idupb like @idupb )
				and (@idfin is null or  FLK.idparent = @idfin)
				AND HPV.ymov = @ayear
				AND EV.yvar = @ayear
				AND EV.adate <= @date
				AND HPV.competencydate <= @date 
				AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

	) as Incassi
	GROUP BY idupb, idfin, flagarrear


	--> COMPETENZA E CASSA 
	IF (@fin_kind = 3) 
	BEGIN
		;with UWT(idfin,idupb) 
		 as 
		(select isnull(finlink.idparent,myUWT.idfin), myUWT.idupb
				from 	upbtotal myUWT 
					join fin F		on myUWT.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U	on myUWT.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
			  where  (myUWT.idupb like @idupb )
					and  ((F.flag & 1) = 0 )--Parte entrata
				 	and ((@idfin IS not NULL and isnull(finlink.idparent,myUWT.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
		union all
			select isnull(finlink.idparent, UET.idfin), UET.idupb
				from 	upbincometotal UET 
					join fin F		on UET.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on UET.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
					left outer join upbtotal UT on  UT.idfin= UET.idfin and UT.idupb=UET.idupb
			  where  (UET.idupb like @idupb )
					and  ((F.flag & 1) = 0 )--Parte entrata
				    and ((@idfin IS not NULL and isnull(finlink.idparent,UET.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
					AND UT.idfin is null
					and UET.nphase = @finphaseincome
	)	
			select  
				U.codeupb as 'UPB',
				F.codefin as 'Bilancio',
				isnull(PPI.amount,0) as 'Prev.Competenza iniziale',
				isnull(VPI.amount,0) as 'Var. Prev. Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0) as 'Prev.Competenza attuale',
				isnull(AccComp.amount,0)  as 'Accertamenti di Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(AccComp.amount,0)   as 'Previsione disponibile comp.',
				isnull(PSI.amount,0) as 'Prev.Cassa iniziale',
				isnull(VPS.amount,0) as 'Var. Prev. Cassa',
				isnull(PSI.amount,0) + isnull(VPS.amount,0) as 'Prev.Cassa attuale',
				isnull(AccRes_01_01.amount,0) as 'Accertamenti Residui all'' 01/01',
				isnull(VarAccRes.amount,0) as 'Var. Accertamenti residui',
				isnull(IncComp.amount,0) as 'Totale Incassi di Competenza',
				isnull(IncRes.amount,0) as 'Totale Incassi Residui',
				isnull(PSI.amount,0) + isnull(VPS.amount,0)  - isnull(IncComp.amount,0) - isnull(IncRes.amount,0)  as 'Previsione disponibile Cassa',
				--Residui al 31/12 (che è valorizzata come "Accertamenti di Competenza"-"Incassato di competenza"+
				--"Accertamenti Residui al 01/01"+"Var. Accertamenti residui"-"Incassato in conto residui")
				isnull(AccComp.amount,0) - isnull(IncComp.amount,0) + isnull(AccRes_01_01.amount,0) + 
				isnull(VarAccRes.amount,0) - isnull(IncRes.amount,0) as 'Residui al 31/12'
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON  PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_PRINCIPALE VPI
   				ON  VPI.idupb = UWT.idupb and VPI.idfin = UWT.idfin 
			left outer join #PREVISIONE_SECONDARIA_INIZIALE PSI
   				ON  PSI.idupb = UWT.idupb and PSI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_SECONDARIA VPS
   				ON  VPS.idupb = UWT.idupb and VPS.idfin = UWT.idfin 
			left outer join #ACCERTAMENTI_COMP AccComp
   				ON  AccComp.idupb = UWT.idupb and AccComp.idfin = UWT.idfin 
			left outer join	#VAR_ACCERTAMENTI_RESIDUI VarAccRes
				ON  VarAccRes.idupb = UWT.idupb and VarAccRes.idfin = UWT.idfin  		
			left outer join #ACCERTAMENTI_RESIDUI_01_01 AccRes_01_01
   				ON  AccRes_01_01.idupb = UWT.idupb and AccRes_01_01.idfin = UWT.idfin  		
			left outer join #INCASSI IncComp
   				ON  IncComp.idupb = UWT.idupb and IncComp.idfin = UWT.idfin AND IncComp.flagarrear = 'C'
   			left outer join #INCASSI IncRes
   				ON  IncRes.idupb = UWT.idupb and IncRes.idfin = UWT.idfin AND IncRes.flagarrear = 'R'
			where ((F.flag & 1) = 0 )--Parte entrata
			order by  U.codeupb,F.codefin

	END   


	--> SOLO COMPETENZA 
	IF (@fin_kind = 1) 
	BEGIN
		;with UWT(idfin,idupb) 
		 as 
		(select myUWT.idfin,myUWT.idupb
				from 	upbtotal myUWT 
					join fin F		on myUWT.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on myUWT.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
			  where  (myUWT.idupb like @idupb )
					and  ((F.flag & 1)= 0 )--Parte entrata
					and ((@idfin IS not NULL and isnull(finlink.idparent,myUWT.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
		union all
			select UET.idfin,UET.idupb
				from 	upbincometotal UET 
					join fin F		on UET.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on UET.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
					left outer join upbtotal UT on  UT.idfin= UET.idfin and UT.idupb=UET.idupb
			  where  (UET.idupb like @idupb )
					and  ((F.flag & 1)=0 )--Parte entrata
					and ((@idfin IS not NULL and isnull(finlink.idparent,UET.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
					AND UT.idfin is null
					and UET.nphase = @finphaseincome
	)	
			select  
				U.codeupb as 'UPB',
				F.codefin as 'Bilancio',
				isnull(PPI.amount,0) as 'Prev.Competenza iniziale',
				isnull(VPI.amount,0) as 'Var. Prev. Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0) as 'Prev.Competenza attuale',
				isnull(AccComp.amount,0)   as 'Accertamenti di Competenza',
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(AccComp.amount,0)   as 'Previsione disponibile',
				isnull(AccRes_01_01.amount,0) as 'Accertamenti Residui all'' 01/01',
				isnull(VarAccRes.amount,0) as 'Var. Accertamenti residui' 
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON  PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_PRINCIPALE VPI
   				ON  VPI.idupb = UWT.idupb and VPI.idfin = UWT.idfin 
			left outer join #ACCERTAMENTI_COMP AccComp
   				ON  AccComp.idupb = UWT.idupb and AccComp.idfin = UWT.idfin 
			left outer join	#VAR_ACCERTAMENTI_RESIDUI VarAccRes
				ON  VarAccRes.idupb = UWT.idupb and VarAccRes.idfin = UWT.idfin 
			left outer join #ACCERTAMENTI_RESIDUI_01_01 AccRes_01_01
   				ON  AccRes_01_01.idupb = UWT.idupb and AccRes_01_01.idfin = UWT.idfin 	
			where ((F.flag & 1)=0 )--Parte entrata	
			order by  U.codeupb,F.codefin

	END   


	--> SOLO CASSA 
	IF (@fin_kind = 2) 
	BEGIN
		;with UWT(idfin,idupb) 
		 as 
		(select myUWT.idfin,myUWT.idupb
				from 	upbtotal myUWT 
					join fin F		on myUWT.idfin = F.idfin
					JOIN finlevel fl ON f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on myUWT.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin AND finlink.nlevel = @nlevel
			  where  (myUWT.idupb like @idupb )
			 	and ((@idfin IS not NULL and isnull(finlink.idparent,myUWT.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and  ((F.flag & 1)=0 )--Parte entrata
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
		union all
			select UET.idfin,UET.idupb
				from 	upbincometotal UET 
					join fin F		on UET.idfin = F.idfin
					join finlevel fl on f.nlevel = fl.nlevel AND  f.ayear = fl.ayear
					join upb U		on UET.idupb = U.idupb
					left outer JOIN finlink	ON finlink.idchild = F.idfin and finlink.nlevel = @nlevel
					left outer join upbtotal UT on  UT.idfin= UET.idfin and UT.idupb=UET.idupb
			  where  (UET.idupb like @idupb )
					and  ((F.flag & 1)= 0 )--Parte entrata
						and ((@idfin IS not NULL and isnull(finlink.idparent,UET.idfin) = @idfin
					OR  (@idfin IS  NULL))
					AND (f.nlevel = @nlevel
						OR (f.nlevel < @nlevel
						 AND EXISTS (SELECT * FROM finlast WHERE finlast.idfin = f.idfin)
						 AND (fl.flag&2)<>0
						 )
					   )
					 )
					and F.ayear = @ayear
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
					AND UT.idfin is null
					and UET.nphase = @finphaseincome
	)	
			select  
				U.codeupb as 'UPB',
				F.codefin as 'Bilancio',
				isnull(PPI.amount,0) as 'Prev.Cassa iniziale',
				isnull(VPI.amount,0) as 'Var. Prev. Cassa',
				isnull(PPI.amount,0) + isnull(VPI.amount,0) as 'Prev.Cassa attuale',
				isnull(IncComp.amount,0) as 'Totale Incassi Competenza' ,
				isnull(IncRes.amount,0) as 'Totale Incassi Residui' ,
				isnull(PPI.amount,0) + isnull(VPI.amount,0)  - isnull(IncComp.amount,0) - isnull(IncRes.amount,0)   as 'Previsione disponibile'
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON  PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
			left outer join #VAR_PREVISIONE_PRINCIPALE VPI
   				ON  VPI.idupb = UWT.idupb and VPI.idfin = UWT.idfin 
			left outer join #INCASSI IncComp
   				ON  IncComp.idupb = UWT.idupb and IncComp.idfin = UWT.idfin AND IncComp.flagarrear = 'C'
   			left outer join #INCASSI IncRes
   				ON  IncRes.idupb = UWT.idupb and IncRes.idfin = UWT.idfin AND IncRes.flagarrear = 'R'
			where ((F.flag & 1)=0 )--Parte entrata
			order by  U.codeupb,F.codefin
END

END

--drop table #PREVISIONE_PRINCIPALE_INIZIALE
--drop table #PREVISIONE_SECONDARIA_INIZIALE
--drop table #VAR_PREVISIONE_PRINCIPALE
--drop table #VAR_PREVISIONE_SECONDARIA
--drop table #ASSEGNAZIONI_CREDITI
--drop table #ASSEGNAZIONI_INCASSI
--drop table #PICCOLE_SPESE 
--drop table #IMPEGNI_COMP 
--drop table #IMPEGNI_RESIDUI 
--drop table #PAGAMENTI 
--drop table #DOT_CREDITI 
--drop table #DOT_INCASSI 


END

GO

 
 





SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

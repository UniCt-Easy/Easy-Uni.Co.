
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_respons]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_respons]
GO
 
CREATE   PROCEDURE rpt_sitbilancio_respons
	@ayear				int,
	@nlevel				tinyint,
	@hierarchy			char(1),
	@idman				int,
	@idupb				varchar(36),
	@showupb 			char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@codefin			varchar(50),
	@start				datetime,
	@stop				datetime,
	@idsor01			int ,
	@idsor02			int ,
	@idsor03			int ,
	@idsor04			int ,
	@idsor05			int 
	AS
	BEGIN
/* Versione 1.0.3 del 17/10/2007 ultima modifica: SARA */

-- exec rpt_sitbilancio_respons 2017, 3, 'S', null, '%', 'S', 'S', 'N', '%',{ts '1900-12-31 00:00:00'},{ts '2017-12-31 00:00:00'}, null,null,null,null,null	
-- exec rpt_sitbilancio_respons 2018, 4, 'S', 1591, '%', 'S', 'S', 'N', '1020701',{ts '1900-12-31 00:00:00'},{ts '2018-12-31 00:00:00'}, null,null,null,null,null	

DECLARE @idfin int
IF (@codefin IS NULL OR @codefin = '' OR @codefin = '%')
	BEGIN
		SET @idfin = null	
	END
Else
	BEGIN
	   	SET @idfin = (select idfin 
				from fin 
				where codefin = @codefin 
				and ayear=@ayear 
				and (fin.flag&1)=0) -- Entrata
	END
	declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'
DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0
	CREATE TABLE #fin_situation
	(
		idupb 			 varchar(36),  
		--assured char(1), 
		codeupb			 varchar(50),
		upb   			 varchar(150),
		upbprintingorder varchar(50),
		idfin			 int,
		codefin			 varchar(50),
		title			 varchar(150),
		finprintingorder varchar(50),
		nlevel			 varchar(20),
		idman			 int,
		manager			 varchar(150),
		initialprevision decimal(19,2),
		var_prevision	 decimal(19,2),

		--main_initial_prevision	decimal(19,2),
		--var_main_prevision		decimal(19,2),

		assessments		decimal(19,2),
		var_assessments	decimal(19,2),

		proceeds        decimal(19,2),
		var_proceeds    decimal(19,2),
	
		flagconsider char(1)
	)
		
	
	DECLARE @idupboriginal 		varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S') set @idupb=@idupb+'%' 
	
	DECLARE @assessmentphase	tinyint
	SELECT  @assessmentphase = assessmentphasecode
	FROM    config
	WHERE   ayear = @ayear
	DECLARE @phasemax		tinyint
	SELECT  @phasemax = MAX(nphase)
	FROM    incomephase
	DECLARE @flag_cs		char(1)
	SELECT 	@flag_cs =  
	CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	END
	FROM 	config
	WHERE 	ayear = @ayear
	DECLARE @cashvaliditykind	int
	SELECT 	@cashvaliditykind = cashvaliditykind
	FROM 	config
	WHERE 	ayear = @ayear

	declare @levelidfin int
	select  @levelidfin = nlevel from fin where idfin=@idfin

	INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	idman,
	initialprevision,
	flagconsider
)
	SELECT 
		F.idfin, F.nlevel,
		isnull(@fixedidupb, U.idupb),
		U.idman,
		SUM(finyear.prevision),
		CASE 
			 WHEN (@hierarchy ='N') Then 'S' 
			 WHEN ( @hierarchy='S' 
					and F.nlevel >= @levelusable 
					and F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
			 ELSE 'N'
		END
	FROM finyear
	JOIN upb U
		ON  finyear.idupb = U.idupb
	JOIN fin F
		ON finyear.idfin = F.idfin
	--JOIN finlast
	--	ON  F.idfin = finlast.idfin
	JOIN finlink FLK
		ON FLK.idchild = F.idfin and FLK.nlevel=@level_input
	WHERE ((F.flag&1) = 0) -- Entrata
		AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
		AND (finyear.ayear = @ayear)
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb like @idupb)
		AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY U.idman,isnull(@fixedidupb, U.idupb), F.idfin, F.nlevel


INSERT INTO #fin_situation(
	idfin,nlevel,
	idupb,
	idman,
	var_prevision ,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	U.idman,
	SUM(finvardetail.amount),
		CASE 
			 WHEN (@hierarchy ='N') Then 'S' 
			 WHEN ( @hierarchy='S' 
					and F.nlevel >= @levelusable 
					and F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
			 ELSE 'N'
		END
FROM fin F
JOIN finlink FLK
	ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2
	ON FLK2.idparent = F.idfin 
JOIN finvardetail
	ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin
JOIN finvar
  	ON finvar.yvar = finvardetail.yvar  
  	AND finvar.nvar = finvardetail.nvar 
JOIN upb U 
	ON finvardetail.idupb = U.idupb	
WHERE ((F.flag&1)= 0) -- Entrata
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (U.idupb like @idupb)
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND finvar.yvar = @ayear		
	AND finvar.flagprevision ='S'	
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND finvar.adate between @start and @stop
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel

	IF (@suppressifblank = 'S')
	BEGIN
		INSERT INTO #fin_situation
	    	  (	idfin, 
			codeupb,	
			idupb,
			upb,
			upbprintingorder,
			codefin,
			title,
			finprintingorder,
			nlevel,
			idman,
			manager )
		  SELECT 
			fin.idfin,
			codeupb,	
			upb.idupb,
			upb.title ,
			upb.printingorder,
			fin.codefin,
			fin.title, 
			fin.printingorder,
			fin.nlevel,
			manager.idman,
			manager.title
		FROM upbtotal
		join upb 
			on  upbtotal.idupb = upb.idupb
		JOIN fin
			ON  upbtotal.idfin = fin.idfin
		JOIN finlast
			ON  fin.idfin = finlast.idfin
		JOIN finlevel
			ON finlevel.nlevel = fin.nlevel
			AND finlevel.ayear = fin.ayear
			AND (finlevel.flag&2)<>0
		LEFT OUTER JOIN finlink
			ON  finlink.idchild = fin.idfin and finlink.nlevel>=@levelidfin
		JOIN manager
			ON upb.idman = manager.idman
		WHERE ((fin.flag&1)=0) --  'E'
			AND ((upb.idman = @idman) OR  (@idman is null and upb.idman is not null))	
			AND (fin.ayear = @ayear)
			AND (@idfin IS NULL OR ISNULL(finlink.idparent,fin.idfin) = @idfin)
	    		AND (upb.idupb like @idupb )
			AND ((@hierarchy ='N' AND fin.nlevel = @nlevel)OR (@hierarchy ='S' and fin.nlevel >=  @nlevel))

END	
	ELSE
	BEGIN
		INSERT INTO #fin_situation
	    	  (	idfin, 
			codeupb,	
			idupb,
			upb,
			upbprintingorder,
			codefin,
			title,
			finprintingorder,
			nlevel,
			idman,
			manager)
		  SELECT 
			fin.idfin,
			upb.codeupb,	
			upb.idupb,
			upb.title ,
			upb.printingorder,
			fin.codefin,
			fin.title, 
			fin.printingorder,
			fin.nlevel,
			manager.idman,
			manager.title
		FROM fin 
		CROSS JOIN upb
		JOIN finlast
			ON  fin.idfin = finlast.idfin
		JOIN finlevel
			ON  finlevel.nlevel = fin.nlevel
			AND finlevel.ayear = fin.ayear
			AND (finlevel.flag&2)<>0
		LEFT OUTER JOIN finlink
			ON  finlink.idchild = fin.idfin and finlink.nlevel=@levelidfin
		JOIN manager 
			ON upb.idman = manager.idman
		LEFT OUTER JOIN finyear
			ON finyear.idfin = fin.idfin
			AND finyear.idupb = upb.idupb and finyear.ayear = @ayear	
		WHERE ((fin.flag&1)=0) -- Entrata
			AND ((upb.idman = @idman) OR (@idman is null and upb.idman is not null))	
			AND (fin.ayear = @ayear)
			AND (@idfin IS NULL OR ISNULL(finlink.idparent,fin.idfin) = @idfin)
			AND (upb.idupb like @idupb)
			AND ((@hierarchy ='N' and fin.nlevel = @nlevel)OR (@hierarchy ='S' and fin.nlevel >=  @nlevel))
		END

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	idman,
	assessments,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	U.idman,
	SUM(incomeyear.amount),
		CASE 
			 WHEN (@hierarchy ='N') Then 'S' 
			 WHEN ( @hierarchy='S' 
					and F.nlevel >= @levelusable 
					and F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
			 ELSE 'N'
		END
FROM fin F
JOIN finlink FLK
	ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2
	ON FLK2.idparent = F.idfin 
JOIN incomeyear
	ON ISNULL(FLK2.idchild,F.idfin) = incomeyear.idfin
	AND incomeyear.ayear = @ayear
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN incometotal
	ON  incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN upb U 
	ON incomeyear.idupb = U.idupb	
WHERE income.adate between @start and @stop 
	AND income.nphase = @assessmentphase
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (((incometotal.flag&1)= 0) -- Competenza
	OR @flag_cs = 'S')
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR 
		 (@hierarchy ='S' AND F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	idman,
	var_assessments,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	U.idman,
	SUM(incomevar.amount) ,
		CASE 
			 WHEN (@hierarchy ='N') Then 'S' 
			 WHEN ( @hierarchy='S' 
					and F.nlevel >= @levelusable 
					and F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
			 ELSE 'N'
		END
FROM fin F
JOIN finlink FLK
	ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2
	ON FLK2.idparent = F.idfin 
JOIN incomeyear
	ON ISNULL(FLK2.idchild,F.idfin) = incomeyear.idfin
	AND incomeyear.ayear = @ayear
JOIN incomevar
	ON incomeyear.idinc = incomevar.idinc
JOIN income
	ON incomeyear.idinc = income.idinc
JOIN incometotal
	ON  incomeyear.idinc = incometotal.idinc
	AND incomeyear.ayear = incometotal.ayear
JOIN upb U 
	ON incomeyear.idupb = U.idupb	
WHERE incomevar.adate between @start and @stop 
	AND income.nphase = @assessmentphase
	AND incomevar.yvar = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (((incometotal.flag&1)= 0) -- Competenza
	OR @flag_cs = 'S')
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel 
	

	
INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	idman,
	proceeds,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	U.idman,
	SUM(HPV.amount),
		CASE 
			 WHEN (@hierarchy ='N') Then 'S' 
			 WHEN ( @hierarchy='S' 
					and F.nlevel >= @levelusable 
					and F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
			 ELSE 'N'
		END
FROM fin F
JOIN finlink FLK
	ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2
	ON FLK2.idparent = F.idfin 
JOIN historyproceedsview HPV
	ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
JOIN upb U 
	ON HPV.idupb = U.idupb
WHERE  HPV.ymov = @ayear
	AND HPV.competencydate between @start and @stop
	AND (((HPV.totflag&1)= 0) -- Competenza
	OR  @flag_cs = 'S')
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (U.idupb like @idupb)
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel


IF @cashvaliditykind <> 4
BEGIN	
	INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			idman,
			var_proceeds,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			U.idman,
			SUM(incomevar.amount) ,
			CASE 
					WHEN (@hierarchy ='N') Then 'S' 
					WHEN ( @hierarchy='S' 
						and F.nlevel >= @levelusable 
						and F.idfin IN (SELECT idfin FROM finlast))
					THEN 'S'
					ELSE 'N'
			END
			FROM fin F
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			JOIN historyproceedsview HPV
				ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
			JOIN incomevar
				ON HPV.idinc = incomevar.idinc
			JOIN upb U 
				ON HPV.idupb = U.idupb
			WHERE incomevar.yvar = @ayear
				AND HPV.ymov = @ayear
				AND HPV.competencydate between @start and @stop
				AND (((HPV.totflag&1)= 0) -- Competenza
					OR @flag_cs = 'S')
				AND incomevar.adate between @start and @stop
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb)
				AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel


	END
--	--	--	--	--	-- Aggiunge le voci inutilizzate se @suppressifblank = N --	--	--	--	--	--	

IF (@suppressifblank = 'N') 
BEGIN
IF ( (@showupb <>'S') and (@idupboriginal = '%'))
Begin
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #fin_situation(idfin, nlevel,idman)
			SELECT 
				F.idfin, F.nlevel,U.idman
			FROM fin F 
			cross join upb U
			JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
			WHERE ((F.flag & 1) = 1) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel >=  @nlevel)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			GROUP BY F.idfin, F.nlevel, U.idman, F.ayear,F.flag
		END
	ELSE
		BEGIN
			INSERT INTO #fin_situation(idfin,nlevel, idman)
			SELECT F.idfin, F.nlevel,U.idman
			FROM fin F
			cross join upb U
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			WHERE  	((F.flag & 1 ) <>0) AND F.ayear =@ayear	
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel = @nlevel)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			GROUP BY F.idfin, F.nlevel, U.idman		
		END
end
else

--> @showupb ='S'
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,idman,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				U.idupb,U.idman,
			CASE 
				 WHEN (@hierarchy ='N') Then 'S' 
				 WHEN ( @hierarchy='S' 
						and F.nlevel >= @levelusable 
						and F.idfin IN (SELECT idfin FROM finlast))
					THEN 'S'
				 ELSE 'N'
			END
			FROM fin F cross join upb U
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
			WHERE  ((F.flag & 1) = 1) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
				AND (F.nlevel >=  @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idman,U.idupb,F.idfin,F.nlevel,F.ayear,F.flag
		END
	ELSE
		BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,idman,
				flagconsider
				)
			SELECT 
				F.idfin, F.nlevel,
				U.idupb,U.idman,
				'S'
			FROM upb U
			CROSS JOIN fin F
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			WHERE  	((F.flag & 1 ) <> 0) AND F.ayear =@ayear	
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
				AND (F.nlevel = @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idman,U.idupb, F.idfin,F.nlevel 
		END
end
END

DELETE FROM #fin_situation WHERE flagconsider='N'
IF (@suppressifblank = 'S') 	--> cancella le righe  sottostante la categoria
BEGIN
	DELETE FROM #fin_situation WHERE 
			(isnull(initialprevision,0.0) =0 AND 
			isnull(var_prevision,0.0) =0 AND 
			isnull(assessments,0.0) =0 AND 
			isnull(var_assessments,0.0) =0 AND 
			isnull(proceeds,0.0) =0 AND 
			isnull(var_proceeds,0.0) =0 
			AND nlevel >=2)
END
			
IF (@showupb = 'N') 
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
		#fin_situation.idfin,
		upb.codeupb,
		#fin_situation.idupb,
		upb.title as upb,
		upb.printingorder as upbprintingorder,
		fin.codefin,
		fin.title as title,
		fin.printingorder as finprintingorder,
		fin.nlevel as nlevel,
		manager.idman,
		manager.title as manager,
		isnull(sum(initialprevision),0) as 'initialprevision',
		isnull(sum(var_prevision),0) as 'var_prevision',
		isnull(sum(assessments),0) as 'assessments',
		isnull(sum(var_assessments),0) as 'var_assessments',		
		isnull(sum(proceeds),0) as 'proceeds',
		isnull(sum(var_proceeds),0) as 'var_proceeds'
	FROM #fin_situation 
		JOIN fin 
			ON #fin_situation.idfin = fin.idfin	
		JOIN manager
			ON	#fin_situation.idman = manager.idman
		group by upb.printingorder,fin.printingorder,
		#fin_situation.idfin,
		upb.codeupb,
		#fin_situation.idupb,
		upb.title,
		fin.codefin,
		fin.title,
		fin.nlevel,
		manager.idman,
		manager.title		
	ORDER BY manager.title
	END
ELSE
BEGIN
SELECT 
		#fin_situation.idfin,
		upb.codeupb,
		#fin_situation.idupb,
		upb.title as upb,
		upb.printingorder as upbprintingorder,
		fin.codefin,
		fin.title as title,
		fin.printingorder as finprintingorder,
		fin.nlevel as nlevel,
		manager.idman,
		manager.title as manager,
		sum(isnull(initialprevision,0.0)) as 'initialprevision',
		sum(isnull(var_prevision,0.0)) as 'var_prevision',
		sum(isnull(assessments,0.0)) as 'assessments',
		sum(isnull(var_assessments,0.0)) as 'var_assessments',		
		sum(isnull(proceeds,0.0)) as 'proceeds',
		sum(isnull(var_proceeds,0.0)) as 'var_proceeds'
	FROM #fin_situation
	JOIN fin 
	ON #fin_situation.idfin = fin.idfin	
	JOIN upb 
	ON #fin_situation.idupb = upb.idupb
	JOIN manager 
	ON upb.idman = manager.idman
	group by #fin_situation.idfin,
		upb.codeupb,
		#fin_situation.idupb,
		upb.title,
		upb.printingorder,
		fin.codefin,
		fin.title,
		fin.printingorder,
		fin.nlevel,
		manager.idman,		manager.title
	ORDER BY manager.title 
	END

 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

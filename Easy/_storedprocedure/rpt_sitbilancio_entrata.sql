
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_entrata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_entrata]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_sitbilancio_entrata]
	@ayear			int,
	@date			datetime,
	@nlevel			tinyint,
	@hierarchy		char(1),
	@idupb			varchar(36),
	@showupb 		char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@idfin			int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
AS
BEGIN
/* Versione 1.0.3 del 30/06/2008 ultima modifica: PIERO */
-- exec rpt_sitbilancio_entrata 2013, {ts '2013-12-05 00:00:00'}, 3, 'S', '%', 'N', 'N', 'N', NULL
DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3

IF (@nlevel < @level_input) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END



CREATE TABLE #fin_residual
	(
	idupb 			varchar(36),
	codeupb			varchar(50),
	upb   			varchar(150),
	upbprintingorder	varchar(50),
	idfin			int,
	codefin			varchar(50),
	title			varchar(150),
	finprintingorder	varchar(50),
	flagadvance		char(1),
	nlevel			tinyint,
	initialprevision	decimal(19,2),
	var_prevision		decimal(19,2),
	sec_initial_prevision	decimal(19,2),
	varprevsec		decimal(19,2),
	assessments		decimal(19,2),
	var_assessments		decimal(19,2),
	proceeds         	decimal(19,2),
	var_proceeds          	decimal(19,2),
	flagconsider 		char(1), 	
	fin_ph_comp		decimal(19,2), 
	var_fin_ph_comp		decimal(19,2), 
	fin_ph_resid		decimal(19,2), 
	var_fin_ph_resid	decimal(19,2), 
	registry_ph_comp	decimal(19,2), 
	var_registry_ph_comp	decimal(19,2), 
	registry_ph_resid	decimal(19,2), 
	var_registry_ph_resid	decimal(19,2),
	max_ph_comp		decimal(19,2),
	max_ph_resid		decimal(19,2),
	var_max_ph_comp		decimal(19,2),
	var_max_ph_resid	decimal(19,2)
	)
IF (@ayear IS NULL) 
BEGIN
	SELECT * FROM  #fin_residual 
	RETURN
END
	

	
DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) FROM finlevel
WHERE 	ayear =@ayear and (flag&2)<>0
DECLARE @idupboriginal 	varchar(36)
SET 	@idupboriginal= @idupb
IF 	(@showchildupb = 'S') SET @idupb=@idupb+'%' 
	
DECLARE @assessmentphase     	tinyint
SELECT  @assessmentphase = assessmentphasecode
FROM 	config
WHERE 	ayear = @ayear
IF 	@assessmentphase IS NULL
BEGIN
	SELECT @assessmentphase = incomefinphase FROM uniconfig
END
DECLARE @phasemax         	tinyint
SELECT  @phasemax = MAX(nphase)
FROM 	incomephase
DECLARE @cashvaliditykind	int
SELECT 	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear
DECLARE @flag_cs     		char(1)
SELECT 	@flag_cs =  CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM 	config
WHERE 	ayear = @ayear

DECLARE @previsionkind char(1) 
SELECT  @previsionkind =  
	 CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM  config 
WHERE config.ayear = @ayear

DECLARE @secprevisionkind    char(1) 
SELECT  @secprevisionkind  = 
	 CASE 
		WHEN fin_kind = 3 THEN 'S'
		ELSE 'N'
	END
FROM config 
WHERE config.ayear = @ayear

DECLARE @fin_phase  tinyint 
SELECT 	@fin_phase = incomefinphase FROM uniconfig

DECLARE @registry_phase tinyint
SELECT  @registry_phase = incomeregphase FROM uniconfig



IF (@hierarchy='N')
BEGIN
	IF (@suppressifblank = 'S')
	BEGIN
		INSERT INTO #fin_residual
      		(
			idfin, 
			idupb,
			flagadvance,
			var_prevision,
			varprevsec,  
			flagconsider,
			nlevel
		)
		SELECT
			F.idfin, 
			U.idupb,
			case when (F.flag&16 <>0) then 'S' else 'N' end,
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) ELSE 0 END),
			'S',
			@nlevel
		--FROM fin F cross join upb U
		FROM upbtotal
		JOIN upb U
			ON upbtotal.idupb = U.idupb
		JOIN fin F
			ON upbtotal.idfin = F.idfin
		JOIN finlink FLK1
			ON FLK1.idchild = F.idfin AND FLK1.nlevel = @level_input
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin AND FLK2.nlevel = @nlevel
		LEFT OUTER JOIN finvardetail
		  	ON finvardetail.idfin = FLK2.idchild  
		  	AND finvardetail.idupb=U.idupb 	
		LEFT OUTER JOIN finvar
		  	ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		WHERE  	((F.flag & 1 ) = 0)  and F.ayear =@ayear	
			AND (@idfin IS NULL OR FLK1.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S') 
			AND (F.nlevel = @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb, F.idfin, case when (F.flag&16 <>0) then 'S' else 'N' end
		
		
		-- Inserisco le coppie che hanno solo i RESIDUI
		INSERT INTO #fin_residual
	      	(
			idfin, 
			idupb,
			flagadvance,
			var_prevision,
			varprevsec,
			flagconsider,
			nlevel
		)
		SELECT DISTINCT
			F.idfin, 
			U.idupb,
			case when (F.flag&16 <>0) then 'S' else 'N' end,
			0,
			0,
			'S',
			@nlevel
		FROM incomeyear
		JOIN upb U
			ON  incomeyear.idupb = U.idupb 
		JOIN fin F
			ON  incomeyear.idfin = F.idfin 
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink 
			ON finlink.idparent = F.idfin AND finlink.nlevel = @level_input
		WHERE  	((F.flag & 1 ) = 0) and F.ayear =@ayear	
			AND (@idfin IS NULL OR finlink.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S')
			AND (F.nlevel = @nlevel)
			AND NOT EXISTS (SELECT *
					  FROM #fin_residual
					  LEFT OUTER JOIN finlink FLK1 ON FLK1.idchild = incomeyear.idfin
					 WHERE incomeyear.idupb = #fin_residual.idupb 
					   AND ISNULL(FLK1.idparent,F.idfin) =  #fin_residual.idfin)
			AND incomeyear.ayear=@ayear
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			--AND ((incometotal.flag & 1) = 1) -- Residuo --Task.5063: in entrata è consentito sforare la prev. quindi 
			-- dobbiamo includere anche i mov. di comp. la cui coppia upb/bilancio non ha previsione.


	END
	ELSE
	BEGIN
		INSERT INTO #fin_residual
      		(
			idfin, 
			idupb,
			flagadvance,
			var_prevision,
			varprevsec,  
			flagconsider,
			nlevel
		)
		SELECT distinct
			F.idfin,
			U.idupb,
			case when (F.flag&16 <>0)then 'S' else 'N' end,
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) ELSE 0 END),
			'S',
			@nlevel
		FROM fin F
		CROSS JOIN upb U
		JOIN finlink  FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin AND FLK.nlevel = @nlevel
		LEFT OUTER JOIN finvardetail
		  	ON finvardetail.idfin = FLK2.idchild
			AND finvardetail.idupb=U.idupb 	
		LEFT OUTER JOIN finvar
		  	ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		WHERE 	((F.flag & 1 ) = 0)  and F.ayear =@ayear	
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S' )
			AND (F.nlevel = @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

		GROUP BY U.idupb, F.idfin, case when (F.flag&16 <>0) then 'S' else 'N' end
		--select 'maria',* from #fin_residual
	END
END 
ELSE 
BEGIN
	IF (@suppressifblank = 'S')
	BEGIN
		INSERT INTO #fin_residual
		(
			idfin, 
			idupb,
			flagadvance,
			var_prevision,
			varprevsec,
			flagconsider,
			nlevel
		)
		SELECT
			F.idfin,
			U.idupb,
			case when (F.flag&16 <>0)then 'S' else 'N' end,
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' THEN isnull(finvardetail.amount,0) ELSE 0 END),
			CASE WHEN F.nlevel >= @levelusable and finlast.idfin is not null then 'S' else 'N' END,
			F.nlevel
		--FROM fin F cross join upb U
		FROM upbtotal
		JOIN upb U
			ON upbtotal.idupb = U.idupb
		JOIN fin F
			ON upbtotal.idfin = F.idfin
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		LEFT OUTER JOIN finvardetail
	   		ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin
			AND finvardetail.idupb=U.idupb 
		LEFT OUTER JOIN finvar
		  	ON finvar.yvar = finvardetail.yvar  AND finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar AND finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5	
		LEFT OUTER JOIN finlast
				on F.idfin = finlast.idfin
		WHERE  ((F.flag & 1 ) = 0) AND F.ayear = @ayear
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (U.idupb LIKE @idupb and U.active = 'S')
			AND (F.nlevel >=  @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,finlast.idfin, case when(F.flag&16 <>0) then 'S' else 'N' end
		
		-- Inserisco le coppie che hanno solo i RESIDUI
		INSERT INTO #fin_residual
      		(
			idfin, 
			idupb,
			flagadvance,
			var_prevision,
			varprevsec,
			flagconsider,
			nlevel
		)
		SELECT distinct
			F.idfin,
			U.idupb,
			case when (F.flag&16 <>0) then 'S' else 'N' end,
			0,
			0,
			CASE WHEN F.nlevel >= @levelusable and finlast.idfin is not null then 'S' else 'N' END,
			F.nlevel
		FROM incomeyear
		join upb U
			on  incomeyear.idupb = U.idupb 
		join fin F
			on  incomeyear.idfin = F.idfin 
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = F.idfin AND finlink.nlevel = @level_input
		LEFT OUTER JOIN finlast
			ON F.idfin = finlast.idfin
		WHERE  (F.flag & 1) = 0  AND F.ayear = @ayear
			AND (@idfin IS NULL OR finlink.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S')
			AND (F.nlevel >=  @nlevel)
			AND NOT EXISTS (SELECT *
					  FROM #fin_residual
					   LEFT OUTER JOIN finlink FLK1 ON FLK1.idchild = incomeyear.idfin
					 WHERE incomeyear.idupb = #fin_residual.idupb 
					   AND ISNULL(FLK1.idparent,f.idfin) =  #fin_residual.idfin)			
			AND incomeyear.ayear = @ayear
			--AND ((incometotal.flag & 1) = 1)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear, finlast.idfin, case when (F.flag&16 <>0) then 'S' else 'N' end

	END
	ELSE
	BEGIN
		INSERT INTO #fin_residual
		(
			idfin, 
			idupb,
			flagadvance,
			var_prevision,
			varprevsec,
			flagconsider,
			nlevel
		)
		SELECT
			F.idfin,
			U.idupb,
			case when (F.flag&16 <>0) then 'S' else 'N' end,
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' THEN isnull(finvardetail.amount,0) ELSE 0 END),
			CASE WHEN F.nlevel >= @levelusable and finlast.idfin is not null then 'S' else 'N' END,
			F.nlevel
		FROM fin F cross join upb U
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		LEFT OUTER JOIN finlast
			on F.idfin = finlast.idfin
		LEFT OUTER JOIN finvardetail
			ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin 
   		  	AND finvardetail.idupb=U.idupb 
		LEFT OUTER JOIN finvar
		  	ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5	
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		WHERE  ((F.flag & 1) = 0) and F.ayear = @ayear
			AND (@idfin IS NULL OR isnull(FLK.idparent, F.idfin) = @idfin)
			AND (U.idupb LIKE @idupb and U.active = 'S')
			AND (F.nlevel >=  @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear, finlast.idfin, case when (F.flag&16 <>0) then 'S' else 'N' end

	END
END
	UPDATE #fin_residual
		SET initialprevision = 
			ISNULL((SELECT SUM(finyear.prevision)
			FROM finyear 
			JOIN fin 
				on finyear.idfin = fin.idfin  				
			JOIN finlevel 
				ON finlevel.ayear = fin.ayear
				AND finlevel.nlevel = fin.nlevel
				AND (finlevel.flag&2)<>0
			JOIN finlast 
				ON finlast.idfin = fin.idfin
			JOIN finlink
				ON finlink.idchild = fin.idfin
			WHERE finlink.idparent= #fin_residual.idfin
				AND finyear.idupb = #fin_residual.idupb 
				AND fin.ayear = @ayear
				AND finyear.ayear = @ayear), 0.0),

		 sec_initial_prevision= 
			ISNULL((
			SELECT SUM(finyear.secondaryprev)
			FROM finyear 
			JOIN fin 
				ON finyear.idfin = fin.idfin 
			JOIN finlevel 
				ON finlevel.ayear = fin.ayear
				AND finlevel.nlevel = fin.nlevel
				AND (finlevel.flag&2)<>0
			JOIN finlast 
				ON finlast.idfin = fin.idfin
			JOIN finlink
				ON finlink.idchild = fin.idfin
			WHERE finlink.idparent = #fin_residual.idfin
				AND finyear.idupb =  #fin_residual.idupb 
				AND finyear.ayear = @ayear
				), 0.0),
		assessments = 
			ISNULL((SELECT SUM(incomeyear.amount)
				FROM incomeyear
				JOIN income
					ON  income.idinc = incomeyear.idinc
					AND incomeyear.ayear = @ayear
				JOIN incometotal
					ON  incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
				JOIN finlink
					ON  finlink.idchild  = incomeyear.idfin 
				WHERE 	income.adate <= @date 
					AND income.nphase = @assessmentphase
					AND ((incometotal.flag&1)= 0 OR @flag_cs = 'S') --Competenza
					AND finlink.idparent = #fin_residual.idfin
					AND incomeyear.idupb = #fin_residual.idupb), 0.0),
		var_assessments =
			ISNULL((SELECT SUM(incomevar.amount)
				FROM incomevar
				JOIN incomeyear
					ON  incomeyear.idinc = incomevar.idinc
					AND incomeyear.ayear = @ayear
				JOIN income
					ON income.idinc = incomeyear.idinc
				JOIN finlink
					ON  finlink.idchild = incomeyear.idfin 
				JOIN incometotal
					ON incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
				WHERE incomevar.yvar = @ayear
    				AND incomevar.adate <= @date
    				AND income.nphase = @assessmentphase
				AND ((incometotal.flag&1)= 0 OR @flag_cs = 'S') -- Competenza
				AND finlink.idparent = #fin_residual.idfin
				AND incomeyear.idupb = #fin_residual.idupb), 0.0)
	UPDATE #fin_residual
		SET proceeds = 
			ISNULL((SELECT SUM(IY.amount)
				FROM incomeyear IY
				JOIN historyproceedsview HPV
					ON  HPV.idinc = IY.idinc
					AND HPV.ymov = @ayear
					AND HPV.competencydate <= @date
				JOIN finlink
					ON  finlink.idchild = IY.idfin 
				JOIN incometotal 
					ON IY.idinc = incometotal.idinc
					AND IY.ayear = incometotal.ayear
				WHERE 	IY.ayear = @ayear
					AND HPV.competencydate <= @date
					AND ((incometotal.flag&1)= 0 OR @flag_cs = 'S') 
					AND finlink.idparent = #fin_residual.idfin
					AND IY.idupb = #fin_residual.idupb), 0.0)


UPDATE #fin_residual 
	SET fin_ph_comp =                                                
		ISNULL((
		SELECT SUM(incomeyear.amount)
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE finlink.idparent = #fin_residual.idfin 
			AND ((incometotal.flag&1)=0) -- Competenza
			AND incomeyear.idupb = #fin_residual.idupb
			AND income.adate <= @date 
			AND income.nphase = @fin_phase), 0.0),
	 var_fin_ph_comp=					
		ISNULL((
		SELECT SUM(incomevar.amount)
		FROM incomevar
		JOIN income
			ON incomevar.idinc = income.idinc
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE incomevar.adate <= @date 
			AND incomeyear.ayear = @ayear
			AND income.nphase= @fin_phase
			AND ((incometotal.flag&1)=0) -- Competenza
			AND finlink.idparent = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND incomevar.yvar = @ayear), 0.0),
	fin_ph_resid = 
		ISNULL((
		SELECT SUM(incomeyear.amount)
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE income.adate <= @date 
			AND ((incometotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND income.nphase = @fin_phase), 0.0),
 	var_fin_ph_resid=					
		ISNULL((
		SELECT SUM(incomevar.amount)
		FROM incomevar
		JOIN income
			ON incomevar.idinc = income.idinc
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE incomevar.adate <= @date 
			AND income.nphase= @fin_phase
			AND ((incometotal.flag&1)=1) -- Residuo
			AND finlink.idparent = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND incomevar.yvar = @ayear), 0.0),
 	registry_ph_comp = 
		ISNULL((
		SELECT SUM(incomeyear.amount)
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE income.adate <= @date 
			AND ((incometotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND income.nphase = @registry_phase), 0.0),
	var_registry_ph_comp =
		ISNULL((
		SELECT SUM(incomevar.amount)
		FROM incomevar
		JOIN income
			ON incomevar.idinc = income.idinc
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE incomevar.adate <= @date 
			AND income.nphase= @registry_phase
			AND ((incometotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND incomevar.yvar = @ayear), 0.0),
	registry_ph_resid = 
		ISNULL((
		SELECT SUM(incomeyear.amount)
		FROM income
		JOIN incomeyear
			ON incomeyear.idinc = income.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE income.adate <= @date 
			AND ((incometotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND income.nphase = @registry_phase), 0.0),
	var_registry_ph_resid =
		ISNULL((
		SELECT SUM(incomevar.amount)
		FROM incomevar
		JOIN income
			ON incomevar.idinc = income.idinc
		JOIN incomeyear
			ON incomeyear.idinc = incomevar.idinc
			AND incomeyear.ayear = @ayear
		JOIN incometotal 
			ON incometotal.idinc = incomeyear.idinc
			AND incometotal.ayear = incomeyear.ayear
		JOIN finlink
			ON finlink.idchild = incomeyear.idfin
		WHERE incomevar.adate <= @date 
			AND income.nphase= @registry_phase
			AND ((incometotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #fin_residual.idfin 
			AND incomeyear.idupb = #fin_residual.idupb
			AND incomevar.yvar = @ayear), 0.0)


UPDATE #fin_residual
	SET	
	max_ph_comp =	 
		ISNULL((SELECT SUM(HPV.amount)	
		FROM historyproceedsview HPV
		JOIN finlink
			ON finlink.idchild = HPV.idfin	 
		WHERE  HPV.ymov = @ayear
			AND HPV.competencydate <= @date
			AND ((HPV.totflag&1)=0) -- Competenza
			AND finlink.idparent  = #fin_residual.idfin
			AND HPV.idupb = #fin_residual.idupb), 0.0),
	max_ph_resid =	 
		ISNULL((SELECT SUM(HPV.amount)
		FROM historyproceedsview HPV
		JOIN finlink
			ON finlink.idchild = HPV.idfin	 
		WHERE  HPV.ymov = @ayear
			AND HPV.competencydate <= @date
			AND ((HPV.totflag&1)=1) -- Residuo
			AND finlink.idparent  = #fin_residual.idfin
			AND HPV.idupb = #fin_residual.idupb), 0.0)




IF @cashvaliditykind <> 4
BEGIN
	UPDATE #fin_residual	
	SET var_proceeds =
		ISNULL((SELECT SUM(incomevar.amount)
				FROM incomevar
				join income on income.idinc = incomevar.idinc
				JOIN incomeyear
					ON incomeyear.idinc = incomevar.idinc
					AND incomeyear.ayear = @ayear
				JOIN historyproceedsview HPV 						
					ON HPV.idinc = incomeyear.idinc
					AND HPV.ymov = @ayear
				JOIN finlink
					ON  finlink.idchild = incomeyear.idfin 
				JOIN incometotal
					ON incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
			WHERE 	incomevar.yvar = @ayear
				AND incomevar.adate <= @date
				AND HPV.competencydate <= @date
				AND income.nphase = @phasemax
				AND ((incometotal.flag&1)= 0 OR @flag_cs = 'S') -- Residuo
				AND finlink.idparent = #fin_residual.idfin
				AND incomeyear.idupb = #fin_residual.idupb), 0.0)
	UPDATE #fin_residual
		SET	
		var_max_ph_comp = 
			ISNULL((
			SELECT SUM(incomevar.amount)
			FROM incomevar
			JOIN historyproceedsview HPV
				ON HPV.idinc = incomevar.idinc
			JOIN finlink
				ON finlink.idchild = HPV.idfin	 
			WHERE incomevar.yvar = @ayear
				AND incomevar.adate <= @date
				AND HPV.ymov = @ayear AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=0) -- Competenza
				AND finlink.idparent  = #fin_residual.idfin
				AND HPV.idupb = #fin_residual.idupb), 0.0),

		var_max_ph_resid = 
			ISNULL((
			SELECT SUM(incomevar.amount)
			FROM incomevar
			JOIN historyproceedsview HPV
				ON HPV.idinc = incomevar.idinc
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
			WHERE incomevar.yvar = @ayear
				AND HPV.ymov = @ayear AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=1) --residuo   
				AND incomevar.adate <= @date
				AND finlink.idparent  = #fin_residual.idfin
				AND HPV.idupb = #fin_residual.idupb), 0.0)
END
ELSE
	BEGIN
		UPDATE #fin_residual	
		SET var_proceeds = 0,
			var_max_ph_comp = 0,
			var_max_ph_resid = 0
	END
IF @flag_cs = 'S'
BEGIN
	UPDATE #fin_residual
		SET proceeds = ISNULL(initialprevision, 0.0) + ISNULL(var_prevision, 0.0),
		assessments = ISNULL(initialprevision, 0.0) + ISNULL(var_prevision, 0.0)
		WHERE flagadvance='S'
-- Aggiorna le voci non operative di conseguenza-- qualora ci siano...quindi questa agisce solo se stiamo espandendo la gerarchia
	UPDATE #fin_residual
		SET proceeds= ISNULL(proceeds,0.0) + 
			ISNULL(( SELECT SUM(rp.proceeds) 
				   FROM #fin_residual rp  
				   LEFT OUTER JOIN finlink 
				     ON finlink.idchild = rp.idfin 
				  WHERE 
				(	(ISNULL(finlink.idparent,rp.idfin)= #fin_residual.idfin) AND
					(rp.idupb like #fin_residual.idupb + '%') AND
					(rp.nlevel > #fin_residual.nlevel) AND
					 flagadvance = 'S'   )
				),0.0)
				
	UPDATE #fin_residual
		SET assessments=  ISNULL(assessments,0.0) +
			ISNULL(( SELECT SUM(rp.assessments) 
				   FROM #fin_residual rp 
				   LEFT OUTER JOIN finlink 
				     ON finlink.idchild = rp.idfin 
				 WHERE 
			    (	(ISNULL(finlink.idparent,rp.idfin)= #fin_residual.idfin) AND
				(rp.idupb like #fin_residual.idupb + '%') AND
				(rp.nlevel > #fin_residual.nlevel) AND
				 flagadvance = 'S'  
                                                            )
			),0.0)
END
-- VALORIZZA CAMPI upb
IF (@showupb = 'S')	
	UPDATE 	#fin_residual 
	SET  	upbprintingorder = upb.printingorder,
		upb = upb.title,
		codeupb = upb.codeupb
	FROM upb
	WHERE upb.idupb = #fin_residual.idupb
IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
	UPDATE 	#fin_residual 
	SET  	idupb = @idupboriginal,
		upbprintingorder = (SELECT TOP 1 printingorder FROM upb
					WHERE idupb = @idupboriginal),
		upb = (SELECT TOP 1 title FROM upb
				WHERE idupb = @idupboriginal),
		codeupb =(SELECT TOP 1 codeupb FROM upb
				WHERE idupb = @idupboriginal)
	
IF (@showupb <>'S') and (@idupboriginal = '%') 
	UPDATE #fin_residual 
		SET  
		idupb = null,
		upbprintingorder = null,
		upb =  null,
		codeupb = null
IF (@suppressifblank = 'S') AND @nlevel>=2	--> se la stampa è x un livello uguale o sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #fin_residual 
	WHERE 
		(isnull(initialprevision,0) =0 AND isnull(var_prevision,0) =0 AND 
		isnull(sec_initial_prevision,0) =0 AND isnull(varprevsec,0)= 0 AND
		isnull(assessments,0) =0 AND isnull(var_assessments,0) =0 AND 
		isnull(proceeds,0) =0 AND isnull(var_proceeds,0) =0 AND
		isnull(registry_ph_comp,0) =0 AND isnull(var_registry_ph_comp,0) =0 AND 
		isnull(registry_ph_resid,0) =0 AND isnull(var_registry_ph_resid,0) =0 AND 
		isnull(max_ph_comp,0) =0 AND isnull(var_max_ph_comp,0) =0 AND 
		isnull(max_ph_resid,0) =0 AND isnull(var_max_ph_resid,0) =0 AND 
		nlevel >=2)
		--LEN(idfin)>=11)
END
IF (@showupb <>'S') 
BEGIN
	SELECT 
		#fin_residual.idfin,
		codeupb	,
		idupb,
		upb,
		upbprintingorder,
		fin.codefin,	
		fin.title,	
		fin.printingorder			as 'finprintingorder',	
		#fin_residual.flagadvance,
		#fin_residual.nlevel,	
		sum(isnull(initialprevision,0.0)) 	as 'initialprevision',	
		sum(isnull(var_prevision,0.0)) 		as 'var_prevision',
		sum(isnull(assessments,0.0)) 		as 'assessments',
		sum(isnull(var_assessments,0.0)) 	as 'var_assessments',
		sum(isnull(proceeds,0.0)) 		as 'proceeds',
		sum(isnull(var_proceeds,0.0)) 		as 'var_proceeds',
		sum(isnull(varprevsec,0.0))		as 'varprevsec',
		sum(isnull(sec_initial_prevision,0.0)) 	as 'sec_initial_prevision',
		sum(isnull(fin_ph_comp,0.0))		as 'fin_ph_comp', 
		sum(isnull(var_fin_ph_comp,0.0))	as 'var_fin_ph_comp', 
		sum(isnull(fin_ph_resid,0.0))		as 'fin_ph_resid', 
		sum(isnull(var_fin_ph_resid,0.0))	as 'var_fin_ph_resid', 
		sum(isnull(registry_ph_comp,0.0))	as 'registry_ph_comp', 
		sum(isnull(var_registry_ph_comp,0.0))	as 'var_registry_ph_comp', 
		sum(isnull(registry_ph_resid,0.0))	as 'registry_ph_resid', 
		sum(isnull(var_registry_ph_resid,0.0))	as 'var_registry_ph_resid',	
		sum(isnull(max_ph_comp,0.0))		as 'max_ph_comp',
		sum(isnull(max_ph_resid,0.0))		as 'max_ph_resid',	
		sum(isnull(var_max_ph_comp,0.0))	as 'var_max_ph_comp',
		sum(isnull(var_max_ph_resid,0.0))	as 'var_max_ph_resid',
		flagconsider,
		@previsionkind 				as 'previsionkind',
		@secprevisionkind 			as 'secprevisionkind'        
		FROM #fin_residual  JOIN fin 
		ON #fin_residual.idfin = fin.idfin		
		GROUP BY upbprintingorder,
			#fin_residual.idfin,
			codeupb,
			idupb,
			upb,
			fin.codefin,
			fin.title,
			fin.printingorder,
			#fin_residual.nlevel,
			#fin_residual.flagadvance,
			flagconsider
		ORDER BY upbprintingorder,finprintingorder
END
ELSE 
		SELECT 
			#fin_residual.idfin,	
			codeupb,
			idupb,
			upb,
			upbprintingorder,
			fin.codefin,	
			fin.title,	
			fin.printingorder	as 'finprintingorder',	
			#fin_residual.flagadvance,	
			#fin_residual.nlevel,	
			initialprevision,	
			var_prevision,
			assessments,
			var_assessments,
			proceeds,
			var_proceeds,
			varprevsec,
			sec_initial_prevision,
			fin_ph_comp, 
			var_fin_ph_comp, 
			fin_ph_resid, 
			var_fin_ph_resid, 
			registry_ph_comp, 
			var_registry_ph_comp, 
			registry_ph_resid, 
			var_registry_ph_resid,
			max_ph_comp,
			max_ph_resid,
			var_max_ph_comp,
			var_max_ph_resid,
			flagconsider,
			@previsionkind 		as 'previsionkind',
			@secprevisionkind 	as 'secprevisionkind'
      
		 FROM #fin_residual JOIN fin 
		 ON #fin_residual.idfin = fin.idfin		
		 ORDER BY upbprintingorder,finprintingorder
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


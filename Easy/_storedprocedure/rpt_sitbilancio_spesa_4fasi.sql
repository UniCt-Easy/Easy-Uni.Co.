
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_spesa_4fasi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_spesa_4fasi]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec rpt_sitbilancio_spesa_4fasi 2007, {ts '2008-07-13 00:00:00'}, 3, 'N', '000100010013', 'S', 'N', 'S',null

CREATE  PROCEDURE [rpt_sitbilancio_spesa_4fasi]
	@ayear			int,
	@date			datetime,
	@nlevel			tinyint,
	@hierarchy		char(1),
	@idupb			varchar(36),
	@showupb 		char(1),
	@showchildupb 		char(1), 
	@suppressifblank 	char(1),
	@idfin			int , --prima era @codefin
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
AS
BEGIN
CREATE TABLE #situation_fin
(
	idupb 			varchar(36),
	codeupb			varchar(50),
	upb   			varchar(150),
	upbprintingorder	varchar(50),
	assured			char(1),
	idfin			int,
	codefin			varchar(50),
	title			varchar(150),
	finprintingorder	varchar(50),
	nlevel			tinyint,
	main_initial_prevision	decimal(19,2),
	var_main_prevision	decimal(19,2),

	sec_initial_prevision	decimal(19,2),
	varprevsec		decimal(19,2),

	fin_ph_comp		decimal(19,2),
	var_fin_ph_comp		decimal(19,2), 
	fin_ph_resid		decimal(19,2), 
	var_fin_ph_resid	decimal(19,2),
	desc_fin_ph 		varchar(50),					

	second_ph_comp	decimal(19,2),
	var_second_ph_comp	decimal(19,2),
	second_ph_resid	decimal(19,2),
	var_second_ph_resid	decimal(19,2),
	desc_second_ph 	varchar(50),					

	third_ph_comp	decimal(19,2),
	var_third_ph_comp	decimal(19,2),
	third_ph_resid	decimal(19,2),
	var_third_ph_resid	decimal(19,2),
	desc_third_ph 	varchar(50),		

	max_ph_comp         	decimal(19,2),
	var_max_ph_comp       	decimal(19,2),
	max_ph_resid         	decimal(19,2),
	var_max_ph_resid      	decimal(19,2),
	desc_max_ph 		varchar(50),					

	assign_credit 		decimal(19,2),
	var_assign_credit	decimal(19,2),
	assign_cash		decimal(19,2), 
	var_assign_cash		decimal(19,2),
	previsionkind 		char(1),
	secprevisionkind 	char(1),
	flag_assign_credit 	char(1),
	flag_assign_cash 	char(1),
	flagconsider 		char(1)		
)
IF @ayear IS NULL 
BEGIN
	SELECT * FROM  #situation_fin 
	RETURN
END

DECLARE @idupboriginal 		varchar(36)
SET 	@idupboriginal= @idupb
IF 	(@showchildupb = 'S') set @idupb=@idupb+'%' 

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0

-- L'ipotesi di questa stampa a 4 fasi è che 
-- ( @residualphase < @secondphase) AND (@secondphase<@thirdphase)AND (@thirdphase<@maxphase)
-- 
-- dove fase 1 = @nfinphase, fase 4 = maxphase, fase 2 = @nfinphase+1,  fase 3 = @maxexpensephase-1

DECLARE @nfinphase  tinyint
SELECT 	@nfinphase = expensefinphase FROM uniconfig

DECLARE @nmaxphase tinyint
SELECT  @nmaxphase = MAX(nphase) FROM expensephase

DECLARE @nsecondphase tinyint
SELECT  @nsecondphase = nphase FROM expensephase  WHERE nphase = @nfinphase + 1

DECLARE @nthirdphase INT
SELECT  @nthirdphase = nphase FROM expensephase  WHERE nphase = @nmaxphase - 1 


DECLARE @finphase varchar(50)
SELECT  @finphase=description FROM expensephase WHERE nphase=@nfinphase 

DECLARE @secondphase varchar(50)
SELECT  @secondphase=description FROM  expensephase WHERE nphase=@nsecondphase 

DECLARE @thirdphase varchar(50)
SELECT @thirdphase = description from  expensephase where nphase = @nthirdphase

DECLARE @max_phase varchar(50)
SELECT  @max_phase=description  FROM expensephase WHERE nphase=@nmaxphase 



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
DECLARE @flag_cs     		char(1)
SELECT 	@flag_cs =  CASE 
		WHEN fin_kind IN (1,3) THEN 'C'
		WHEN fin_kind = 2 THEN 'S'
	 END
FROM 	config
WHERE 	ayear = @ayear
DECLARE @cashvaliditykind	int
SELECT 	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

IF (@hierarchy='N')
BEGIN
	IF (@suppressifblank = 'S')
	BEGIN
		INSERT INTO #situation_fin
			(idfin, 
			idupb,
			assured,
			var_main_prevision,
			varprevsec,  
			flagconsider
			)
		SELECT 
			F.idfin, 
			U.idupb,
			ISNULL(U.assured,'N'),
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) ELSE 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) ELSE 0 END),
			'S'
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
			ON finvar.yvar = finvardetail.yvar  AND finvar.yvar = @ayear	
		  	AND finvar.nvar = finvardetail.nvar AND finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		WHERE  	((F.flag & 1 ) = 1) AND F.ayear =@ayear	
			AND (@idfin IS NULL OR  FLK1.idparent = @idfin)
			AND (U.idupb LIKE @idupb and U.active = 'S')
			AND (F.nlevel = @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb, F.idfin, ISNULL(U.assured,'N')

	--- Inserisco le coppie che hanno solo i RESIDUI
		INSERT INTO #situation_fin
			(	
			idfin, 
			idupb,
			assured,
			var_main_prevision,
			varprevsec,
			flagconsider
			)
		SELECT DISTINCT
			F.idfin,	
			U.idupb,
			ISNULL(U.assured,'N'),
			0,
			0,
			'S'
		FROM expenseyear
		JOIN upb U
			ON  expenseyear.idupb = U.idupb 
		JOIN fin F
			ON  expenseyear.idfin = F.idfin 
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idparent = F.idfin AND finlink.nlevel = @level_input
		WHERE  ((F.flag & 1 ) = 1) AND F.ayear =@ayear	
			AND (@idfin IS NULL OR  finlink.idparent = @idfin)
			AND (U.idupb LIKE @idupb  and U.active = 'S')
			AND (F.nlevel = @nlevel)
			AND NOT EXISTS (SELECT *
					  FROM #situation_fin
					  LEFT OUTER JOIN finlink FLK1 
					    ON FLK1.idchild = expenseyear.idfin 
					 WHERE expenseyear.idupb = #situation_fin.idupb 
					   AND ISNULL(FLK1.idparent,F.idfin)=  #situation_fin.idfin)
			AND expenseyear.ayear=@ayear
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND ((expensetotal.flag & 1) = 1) --Residuo
		--GROUP BY U.idupb, ISNULL(finlink.idparent,F.idfin) 
	END
	ELSE
	BEGIN
		INSERT INTO #situation_fin
			(idfin, 
			idupb,
			assured,
			var_main_prevision,
			varprevsec,  
			flagconsider
			)
		SELECT 
			F.idfin, 
			U.idupb,
			ISNULL(U.assured,'N'),
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) ELSE 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) ELSE 0 END),
			'S'
		FROM upb U
		CROSS JOIN fin F
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		LEFT OUTER JOIN finvardetail
			ON finvardetail.idfin = FLK2.idchild
			AND finvardetail.idupb=U.idupb 	
		LEFT OUTER JOIN finvar
			ON finvar.yvar = finvardetail.yvar  AND finvar.yvar = @ayear	
		  	AND finvar.nvar = finvardetail.nvar AND finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		WHERE  	((F.flag & 1 ) = 1) AND F.ayear =@ayear	
			AND (@idfin IS NULL 
		        OR  FLK.idparent = @idfin)
			AND (U.idupb LIKE @idupb and U.active = 'S')
			AND (F.nlevel = @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb, F.idfin,ISNULL(U.assured,'N')
	END
END 
ELSE -- @hierarchy ='S'
BEGIN 
	IF (@suppressifblank = 'S')
	BEGIN
		INSERT INTO #situation_fin
	      		(
				idfin, 
				idupb,
				assured,
				var_main_prevision,
				varprevsec,
				flagconsider
			)
			SELECT 
				F.idfin,
				U.idupb,
				ISNULL(U.assured,'N'),
				SUM(CASE WHEN finvar.flagprevision = 'S' THEN isnull(finvardetail.amount,0) ELSE 0 END),
				SUM(CASE WHEN finvar.flagsecondaryprev = 'S' THEN isnull(finvardetail.amount,0) ELSE 0 END),
				CASE 
					WHEN (F.nlevel >= @levelusable and 
					F.idfin IN (SELECT idfin FROM finlast))
					THEN 'S'
					ELSE 'N'
				END
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
				AND finvardetail.idupb = U.idupb 
			LEFT OUTER JOIN finvar
			  	ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
		  	  	AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
				AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
			WHERE  ((F.flag & 1 ) = 1) AND F.ayear = @ayear
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb and U.active = 'S')
				AND (F.nlevel >=  @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)				
			GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag,ISNULL(U.assured,'N')

		-- Inserisco le coppie che hanno solo i RESIDUI
		INSERT INTO #situation_fin
			(idfin, 
			idupb,
			assured,
			var_main_prevision,
			varprevsec,
			flagconsider
			)
		SELECT DISTINCT
			F.idfin,
			U.idupb,
			ISNULL(U.assured,'N'),
			0,
			0,
			CASE 
				WHEN (F.nlevel >= @levelusable and 
				F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
				ELSE 'N'
			END
		FROM expenseyear
		JOIN upb U
			ON  expenseyear.idupb = U.idupb 
		JOIN fin F
			ON  expenseyear.idfin = F.idfin 
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink 
			ON finlink.idchild = F.idfin AND finlink.nlevel = @level_input 
		WHERE  (F.flag & 1 ) = 1 and F.ayear = @ayear
			AND (@idfin IS NULL OR finlink.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S')
			AND (F.nlevel >=  @nlevel)
			AND NOT EXISTS (SELECT *
					  FROM #situation_fin
					  LEFT OUTER JOIN finlink FLK1 ON FLK1.idchild = expenseyear.idfin
					 WHERE expenseyear.idupb = #situation_fin.idupb 
					   AND ISNULL(FLK1.idparent,F.idfin) =  #situation_fin.idfin)			
			AND expenseyear.ayear = @ayear
			AND (F.nlevel >=  @nlevel)
			AND ((expensetotal.flag & 1) = 1)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,(F.flag & 1) 

	END
	ELSE
	BEGIN
		INSERT INTO #situation_fin
      		(
			idfin, 
			idupb,
			assured,
			var_main_prevision,
			varprevsec,
			flagconsider
		)
		SELECT 
			F.idfin,
			U.idupb,
			ISNULL(U.assured,'N'),
			SUM(CASE WHEN finvar.flagprevision = 'S' THEN isnull(finvardetail.amount,0) ELSE 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' THEN isnull(finvardetail.amount,0) ELSE 0 END),
			CASE 
				 WHEN (F.nlevel >= @levelusable and 
				 F.idfin IN (SELECT idfin FROM finlast))
				 THEN 'S'
				 ELSE 'N'
			END
		FROM fin F cross join upb U
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		LEFT OUTER JOIN finvardetail
		  	ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin
			AND finvardetail.idupb = U.idupb 
		LEFT OUTER JOIN finvar
		  	ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
		WHERE  ((F.flag & 1) = 1) and F.ayear = @ayear
			AND (@idfin IS NULL OR  FLK.idparent = @idfin)
			AND (U.idupb LIKE @idupb and U.active = 'S')
			AND (F.nlevel >=  @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag, ISNULL(U.assured,'N')
	END
END

UPDATE #situation_fin 
	SET main_initial_prevision = 
		ISNULL((
		SELECT SUM(finyear.prevision)
		from finyear 
		JOIN fin 
			ON finyear.idfin = fin.idfin  				
		JOIN upb
			ON finyear.idupb = upb.idupb 
		JOIN finlevel 
			ON finlevel.ayear = fin.ayear
			AND finlevel.nlevel = fin.nlevel
			AND (finlevel.flag&2)<>0
		JOIN finlast 
			ON finlast.idfin = fin.idfin
		JOIN finlink
			ON finlink.idchild = fin.idfin
		WHERE finlink.idparent 	  = #situation_fin.idfin
			AND finyear.idupb =  #situation_fin.idupb 
			AND fin.ayear = @ayear
			AND finyear.ayear = @ayear), 0.0)
UPDATE #situation_fin 
	SET sec_initial_prevision= 
		ISNULL((
		SELECT SUM(finyear.secondaryprev)
		FROM finyear 
		JOIN fin 
			ON finyear.idfin = fin.idfin 
		JOIN upb
			ON finyear.idupb = upb.idupb  
		JOIN finlevel 
			ON finlevel.ayear = fin.ayear
			AND finlevel.nlevel = fin.nlevel
			AND (finlevel.flag&2)<>0
		JOIN finlast 
			ON finlast.idfin = fin.idfin
		JOIN finlink
			ON finlink.idchild = fin.idfin
		WHERE finlink.idparent = #situation_fin.idfin
			AND finyear.idupb =  #situation_fin.idupb 
			AND finyear.ayear = @ayear
			), 0.0)
UPDATE #situation_fin 
	SET fin_ph_comp =                                                
		ISNULL((
		SELECT SUM(expenseyear.amount)
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE finlink.idparent = #situation_fin.idfin 
			AND ((expensetotal.flag&1)=0) -- Competenza
			AND expenseyear.idupb = #situation_fin.idupb
			AND expense.adate <= @date 
			AND expense.nphase = @nfinphase), 0.0),
	 var_fin_ph_comp=					
		ISNULL((
		SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN expense
			ON expensevar.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expensevar.adate <= @date 
			AND expenseyear.ayear = @ayear
			AND expense.nphase= @nfinphase
			AND ((expensetotal.flag&1)=0) -- Compenza
			AND finlink.idparent = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
	fin_ph_resid = 
		ISNULL((
		SELECT SUM(expenseyear.amount)
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expense.adate <= @date 
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expense.nphase = @nfinphase), 0.0),
 	var_fin_ph_resid=					
		ISNULL((
		SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN expense
			ON expensevar.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expensevar.adate <= @date 
			AND expense.nphase= @nfinphase
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
 	second_ph_comp = 
		ISNULL((
		SELECT SUM(expenseyear.amount)
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expense.adate <= @date 
			AND ((expensetotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expense.nphase = @nsecondphase), 0.0),
	var_second_ph_comp =
		ISNULL((
		SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN expense
			ON expensevar.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expensevar.adate <= @date 
			AND expense.nphase= @nsecondphase
			AND ((expensetotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
	second_ph_resid = 
		ISNULL((
		SELECT SUM(expenseyear.amount)
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expense.adate <= @date 
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expense.nphase = @nsecondphase), 0.0),
	var_second_ph_resid =
		ISNULL((
		SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN expense
			ON expensevar.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expensevar.adate <= @date 
			AND expense.nphase= @nsecondphase
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
				
 	third_ph_comp = 
		ISNULL((
		SELECT SUM(expenseyear.amount)
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expense.adate <= @date 
			AND ((expensetotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expense.nphase = @nthirdphase), 0.0),
	var_third_ph_comp =
		ISNULL((
		SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN expense
			ON expensevar.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expensevar.adate <= @date 
			AND expense.nphase= @nthirdphase
			AND ((expensetotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
	third_ph_resid = 
		ISNULL((
		SELECT SUM(expenseyear.amount)
		FROM expense
		JOIN expenseyear
			ON expenseyear.idexp = expense.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expense.adate <= @date 
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expense.nphase = @nthirdphase), 0.0),
	var_third_ph_resid =
		ISNULL((
		SELECT SUM(expensevar.amount)
		FROM expensevar
		JOIN expense
			ON expensevar.idexp = expense.idexp
		JOIN expenseyear
			ON expenseyear.idexp = expensevar.idexp
			AND expenseyear.ayear = @ayear
		JOIN expensetotal 
			ON expensetotal.idexp = expenseyear.idexp
			AND expensetotal.ayear = expenseyear.ayear
		JOIN finlink
			ON finlink.idchild = expenseyear.idfin
		WHERE expensevar.adate <= @date 
			AND expense.nphase= @nthirdphase
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0)

UPDATE #situation_fin
--  GESTIONE DEL FONDO ECONOMALE
	SET fin_ph_comp=   
		ISNULL(fin_ph_comp, 0.0) +
		ISNULL((SELECT SUM(operation.amount)
			FROM pettycashoperation operation
			JOIN finlink 
				ON finlink.idchild = operation.idfin
			WHERE finlink.idparent = #situation_fin.idfin	
				AND operation.idupb = #situation_fin.idupb
				AND operation.adate <= @date
				AND operation.yoperation = @ayear
				AND NOT EXISTS 
					(SELECT * FROM pettycashoperation oprestore
						WHERE oprestore.idpettycash = operation.idpettycash
						AND oprestore.yoperation = operation.yrestore
						AND oprestore.noperation = operation.nrestore
						AND oprestore.adate <= @date
						AND oprestore.yoperation = @ayear)), 0.0),
     second_ph_comp = ISNULL(second_ph_comp, 0.0) +
			ISNULL((SELECT SUM(operation.amount)
				FROM pettycashoperation operation
				JOIN finlink 
					ON finlink.idchild = operation.idfin
				WHERE finlink.idparent = #situation_fin.idfin	
					AND operation.idupb = #situation_fin.idupb
					AND operation.adate <= @date 
					AND operation.yoperation = @ayear
				AND NOT EXISTS 
					(SELECT * FROM pettycashoperation oprestore
						WHERE oprestore.idpettycash = operation.idpettycash
						AND oprestore.yoperation = operation.yrestore
						AND oprestore.noperation = operation.nrestore
						AND oprestore.adate <= @date
						AND oprestore.yoperation = @ayear)), 0.0),

     third_ph_comp = ISNULL(third_ph_comp, 0.0) +
			ISNULL((SELECT SUM(operation.amount)
				FROM pettycashoperation operation
				JOIN finlink 
					ON finlink.idchild = operation.idfin
				WHERE finlink.idparent = #situation_fin.idfin	
					AND operation.idupb = #situation_fin.idupb
					AND operation.adate <= @date 
					AND operation.yoperation = @ayear
				AND NOT EXISTS 
					(SELECT * FROM pettycashoperation oprestore
						WHERE oprestore.idpettycash = operation.idpettycash
						AND oprestore.yoperation = operation.yrestore
						AND oprestore.noperation = operation.nrestore
						AND oprestore.adate <= @date
						AND oprestore.yoperation = @ayear)), 0.0)

UPDATE #situation_fin
	SET	
	max_ph_comp =	 
		ISNULL((SELECT SUM(HPV.amount)	
		FROM historypaymentview HPV
		JOIN finlink
			ON finlink.idchild = HPV.idfin	 
		WHERE  HPV.ymov = @ayear
			AND HPV.competencydate <= @date
			AND ((HPV.totflag&1)=0) -- Competenza 
			AND finlink.idparent  = #situation_fin.idfin
			AND HPV.idupb = #situation_fin.idupb), 0.0),
	max_ph_resid =	 
		ISNULL((SELECT SUM(HPV.amount)
		FROM historypaymentview HPV
		JOIN finlink
			ON finlink.idchild = HPV.idfin	 
		WHERE  HPV.ymov = @ayear
			AND HPV.competencydate <= @date
			AND ((HPV.totflag&1)=1) -- Residuo
			AND finlink.idparent  = #situation_fin.idfin
			AND HPV.idupb = #situation_fin.idupb), 0.0)
IF @cashvaliditykind <> 4
BEGIN
	UPDATE #situation_fin
		SET	
		var_max_ph_comp = 
			ISNULL((
			SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN historypaymentview HPV
				ON HPV.idexp = expensevar.idexp
			JOIN finlink
				ON finlink.idchild = HPV.idfin	 
			WHERE expensevar.yvar = @ayear
				AND expensevar.adate <= @date
				AND HPV.ymov = @ayear AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=0) -- Competenza
				AND finlink.idparent  = #situation_fin.idfin
				AND HPV.idupb = #situation_fin.idupb), 0.0),

		var_max_ph_resid = 
			ISNULL((
			SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN historypaymentview HPV
				ON HPV.idexp = expensevar.idexp
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
			WHERE expensevar.yvar = @ayear
				AND HPV.ymov = @ayear AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=1) --Residuo  
				AND expensevar.adate <= @date
				AND finlink.idparent  = #situation_fin.idfin
				AND HPV.idupb = #situation_fin.idupb), 0.0)
END		
-- Controlla che i CREDITI  siano gestiti
IF 	
	(EXISTS(SELECT* FROM creditpart
		WHERE ycreditpart = @ayear AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagcredit ='S' and yvar = @ayear
		AND adate <= @date
		AND finvar.idfinvarstatus = 5)
	--OR  
	--EXISTS (select * from upb where assured='S')
	)
		BEGIN
			UPDATE #situation_fin
			SET var_assign_credit = isnull((
				SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v 
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
					AND v.flagcredit ='S'
				JOIN finlink
					ON finlink.idchild = d.idfin
				WHERE finlink.idparent  = #situation_fin.idfin
					AND v.idfinvarstatus = 5
					AND d.idupb = #situation_fin.idupb
					AND #situation_fin.assured <> 'S' -- solo upb non a finanziamento certo
					AND v.adate <= @date
					AND v.variationkind IN (2)),0.0),
			     assign_credit = isnull((
				SELECT SUM(creditpart.amount)
				FROM creditpart 
				JOIN incomeyear
					ON creditpart.idinc = incomeyear.idinc
					AND creditpart.ycreditpart = incomeyear.ayear
				JOIN finlink
					ON finlink.idchild = creditpart.idfin
				WHERE finlink.idparent = #situation_fin.idfin
					AND creditpart.idupb = #situation_fin.idupb
					AND #situation_fin.assured <> 'S'
					AND adate <= @date),0.0)
				+	
				ISNULL((
				SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
					AND v.flagcredit ='S'
				JOIN finlink
					ON finlink.idchild = d.idfin
				WHERE finlink.idparent  = #situation_fin.idfin
					AND v.idfinvarstatus = 5
					AND d.idupb = #situation_fin.idupb
					AND #situation_fin.assured <> 'S'
					AND v.adate <= @date
					AND v.variationkind IN (1,3,4)),0.0),
			flag_assign_credit='S'
			
			UPDATE #situation_fin
			SET flag_assign_credit='N' 
			WHERE #situation_fin.assured  = 'S' -- se upb a finanziamento certo, non considero i crediti
		END
ELSE
	BEGIN
		
		UPDATE #situation_fin
		SET 	var_assign_credit = 0,
			assign_credit =0,
			flag_assign_credit='N'
	END
IF 	(EXISTS(SELECT* FROM proceedspart 
		WHERE yproceedspart	= @ayear
		AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagproceeds='S' and 
		yvar = @ayear AND adate <= @date
		AND finvar.idfinvarstatus = 5)
	--OR
	--EXISTS (select * from upb where assured='S')
	)
	BEGIN
		UPDATE #situation_fin
		SET var_assign_cash = ISNULL(( 
			SELECT SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagproceeds='S'
			JOIN finlink
				ON finlink.idchild = d.idfin
			WHERE finlink.idparent = #situation_fin.idfin
				AND v.idfinvarstatus = 5
				AND d.idupb = #situation_fin.idupb
				AND v.adate <= @date
				AND #situation_fin.assured <> 'S'
				AND v.variationkind IN (2)),0.0),
		 	assign_cash = isnull (( 
			SELECT SUM(proceedspart.amount)
				FROM proceedspart
			JOIN incomeyear
				ON proceedspart.idinc = incomeyear.idinc
				AND proceedspart.yproceedspart = incomeyear.ayear
			JOIN finlink
				ON finlink.idchild = proceedspart.idfin
			WHERE 	finlink.idparent  = #situation_fin.idfin
				AND #situation_fin.assured <> 'S'
				AND proceedspart.idupb = #situation_fin.idupb
				AND adate <= @date),0.0)
				+
			ISNULL((
			SELECT  SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagproceeds='S'
			JOIN finlink
				ON finlink.idchild = d.idfin
			WHERE finlink.idparent = #situation_fin.idfin
				AND v.idfinvarstatus = 5
				AND #situation_fin.assured <> 'S'
				AND v.adate <= @date
				AND d.idupb = #situation_fin.idupb
				AND v.variationkind IN (1,3,4)),0.0),
			flag_assign_cash='S' 

			UPDATE #situation_fin
			SET flag_assign_cash='N' 
			WHERE #situation_fin.assured = 'S'
	END
ELSE
	BEGIN 
	UPDATE #situation_fin
	SET	var_assign_cash = 0,
		assign_cash = 0,
		flag_assign_cash='N'
	END
-- VALORIZZA CAMPI upb
	IF (@showupb = 'S')	
		UPDATE #situation_fin SET  upbprintingorder = upb.printingorder,
					upb = upb.title,
					codeupb = upb.codeupb
					FROM upb
					WHERE upb.idupb = #situation_fin.idupb

	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		BEGIN
		UPDATE #situation_fin SET  
		idupb = @idupboriginal,
		upbprintingorder = (SELECT TOP 1 printingorder
					FROM upb
					WHERE idupb = @idupboriginal),
		upb = (SELECT TOP 1 title
					FROM upb
					WHERE idupb = @idupboriginal),
		codeupb =(SELECT TOP 1 codeupb
					FROM upb
					WHERE idupb = @idupboriginal)
	
		IF  (EXISTS(SELECT* FROM creditpart 
		     WHERE ycreditpart = @ayear AND adate <= @date) 
		OR
		EXISTS (SELECT * FROM finvar
			WHERE flagcredit='S' and 
			yvar = @ayear AND adate <= @date
			AND finvar.idfinvarstatus = 5)
		)
			BEGIN 
				UPDATE #situation_fin
				SET    flag_assign_credit='S'  -- ho aggiornato l'upb devo rivalutare flag_assign_credit
				FROM   upb
				WHERE  upb.idupb = #situation_fin.idupb 
				  AND ISNULL(upb.assured, 'N') <> 'S'
				
				UPDATE #situation_fin
				SET    flag_assign_credit='N'
				FROM   upb 
				WHERE  upb.idupb = #situation_fin.idupb 
				  AND  ISNULL(upb.assured, 'N') <> 'N'
			END
			ELSE   
			UPDATE #situation_fin
			SET    flag_assign_credit='N'
	
			IF  (EXISTS(SELECT* FROM proceedspart 
				WHERE yproceedspart = @ayear AND adate <= @date) 
			OR
			EXISTS (SELECT * FROM finvar
				WHERE flagproceeds='S' and 
				yvar = @ayear AND adate <= @date
				AND finvar.idfinvarstatus = 5)
			)	
			BEGIN
				UPDATE #situation_fin
				SET    flag_assign_cash='S' -- ho aggiornato l'upb devo rivalutare flag_assign_credit
				FROM   upb 
				WHERE  upb.idupb = #situation_fin.idupb 
				  AND ISNULL(upb.assured, 'N') <> 'S'
				
				UPDATE #situation_fin
				SET    flag_assign_cash='N'
				FROM   upb 
				WHERE  upb.idupb = #situation_fin.idupb 
				  AND  ISNULL(upb.assured, 'N') = 'S'
			END
			ELSE   
			UPDATE #situation_fin
			SET    flag_assign_cash='N'
		END
	
	IF (@showupb <>'S') and (@idupboriginal = '%') 
		BEGIN
		UPDATE #situation_fin SET  
			idupb = null,
			upbprintingorder = null,
			upb =  null,
			codeupb = null
		-- considero solo se sono gestiti crediti e cassa, non gli upb
		IF  (EXISTS(SELECT* FROM creditpart 
		     WHERE ycreditpart = @ayear AND adate <= @date) 
		OR
		EXISTS (SELECT * FROM finvar
			WHERE flagcredit='S' and 
			yvar = @ayear AND adate <= @date
			AND finvar.idfinvarstatus = 5))
			UPDATE #situation_fin
			SET    flag_assign_credit='S'
			ELSE   
			UPDATE #situation_fin
			SET    flag_assign_credit='N'
	
		IF  (EXISTS(SELECT* FROM proceedspart 
			WHERE yproceedspart = @ayear AND adate <= @date) 
		OR
		EXISTS (SELECT * FROM finvar
			WHERE flagproceeds='S' and 
			yvar = @ayear AND adate <= @date
			AND finvar.idfinvarstatus = 5))
			UPDATE #situation_fin
			SET    flag_assign_cash='S'
			ELSE   
			UPDATE #situation_fin
			SET    flag_assign_cash='N'
		END
IF (@suppressifblank = 'S') AND @nlevel>=2	--> se la stampa è x categoria o x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #situation_fin WHERE 
			(isnull(main_initial_prevision,0.0) =0 AND 
			isnull(var_main_prevision,0.0) =0 AND 
			isnull(sec_initial_prevision,0.0) =0 AND 
        		isnull(varprevsec,0.0) =0 AND 

			isnull(fin_ph_comp,0.0) =0 AND  
			isnull(var_fin_ph_comp,0.0) =0 AND 
			isnull(fin_ph_resid,0.0) =0 AND 
			isnull(var_fin_ph_resid,0.0) =0 AND 			

			isnull(second_ph_comp,0.0) =0 AND 
			isnull(var_second_ph_comp,0.0) =0 AND 
			isnull(second_ph_resid,0.0) =0 AND 
			isnull(var_second_ph_resid,0.0) =0 AND 

			isnull(third_ph_comp,0.0) =0 AND 
			isnull(var_third_ph_comp,0.0) =0 AND 
			isnull(third_ph_resid,0.0) =0 AND 
			isnull(var_third_ph_resid,0.0) =0 AND 

			isnull(max_ph_comp,0.0) =0 AND 
			isnull(var_max_ph_comp,0.0) =0 AND 
			isnull(max_ph_resid,0.0) =0 AND 
			isnull(var_max_ph_resid,0.0) =0 AND 

			isnull(assign_credit,0.0) =0 AND 
        		isnull(var_assign_credit,0.0) =0 AND 
			isnull(assign_cash,0.0) =0 AND 
			isnull(var_assign_cash,0.0) =0 AND

			(select nlevel from fin FFF where FFF.idfin= #situation_fin.idfin)>=2)
END
IF (@showupb <>'S') 
BEGIN
	
	SELECT 
		#situation_fin.idfin,	
		fin.printingorder 			as 'finprintingorder',
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		fin.codefin,	
		fin.title,	
		fin.nlevel,	
		sum(isnull(main_initial_prevision,0.0)) as 'main_initial_prevision',
		sum(isnull(var_main_prevision,0.0)) 	as 'var_main_prevision',
		sum(isnull(sec_initial_prevision,0.0)) 	as 'sec_initial_prevision',
		sum(isnull(varprevsec,0.0)) 		as 'varprevsec',

		sum(isnull(fin_ph_comp,0.0)) 		as 'fin_ph_comp',
		sum(isnull(var_fin_ph_comp,0.0)) 	as 'var_fin_ph_comp', 
		sum(isnull(fin_ph_resid,0.0)) 		as 'fin_ph_resid', 
		sum(isnull(var_fin_ph_resid,0.0)) 	as 'var_fin_ph_resid',
		@finphase 			        as 'desc_fin_ph',					

		sum(isnull(second_ph_comp,0.0)) 	as 'second_ph_comp',
		sum(isnull(var_second_ph_comp,0.0)) 	as 'var_second_ph_comp',
		sum(isnull(second_ph_resid,0.0)) 	as 'second_ph_resid',
		sum(isnull(var_second_ph_resid,0.0))    as 'var_second_ph_resid',
		@secondphase 			        as 'desc_second_ph',					

		sum(isnull(third_ph_comp,0.0)) 	        as 'third_ph_comp',
		sum(isnull(var_third_ph_comp,0.0)) 	as 'var_third_ph_comp',
		sum(isnull(third_ph_resid,0.0)) 	as 'third_ph_resid',
		sum(isnull(var_third_ph_resid,0.0))     as 'var_third_ph_resid',
		@thirdphase 			        as 'desc_third_ph',					

		sum(isnull(max_ph_comp,0.0)) 		as 'max_ph_comp',
		sum(isnull(var_max_ph_comp,0.0)) 	as 'var_max_ph_comp',
		sum(isnull(max_ph_resid,0.0)) 		as 'max_ph_resid',
		sum(isnull(var_max_ph_resid,0.0)) 	as 'var_max_ph_resid',
		@max_phase 			        as 'desc_max_ph' 	,					

		sum(isnull(assign_credit,0.0)) 		as 'assign_credit',
		sum(isnull(var_assign_credit,0.0)) 	as 'var_assign_credit',
		sum(isnull(assign_cash,0.0)) 		as 'assign_cash',
		sum(isnull(var_assign_cash,0.0)) 	as 'var_assign_cash',
		@previsionkind 				as 'previsionkind',
		@secprevisionkind 			as 'secprevisionkind',
		flag_assign_credit,
		flag_assign_cash,
		flagconsider	
	 	FROM #situation_fin JOIN fin 
		ON #situation_fin.idfin = fin.idfin			
		GROUP BY idupb,
			#situation_fin.idfin,
			codeupb,
			upb,
			upbprintingorder,
			fin.printingorder,
			fin.codefin,	
			fin.title,
			fin.nlevel,
			flag_assign_credit,
			flag_assign_cash,
			flagconsider			
		ORDER BY upbprintingorder,
			finprintingorder
END 
	ELSE
		SELECT 
			#situation_fin.idfin,	
			codeupb,
			idupb,
			upb,
			upbprintingorder,
			fin.codefin,	
			fin.title,	
			fin.printingorder 	as 'finprintingorder',	
			fin.nlevel,	

			main_initial_prevision,
			var_main_prevision,
			sec_initial_prevision,
			varprevsec,

			fin_ph_comp,
			var_fin_ph_comp, 
			fin_ph_resid, 
			var_fin_ph_resid,
			@finphase 	as 'desc_fin_ph',					

			second_ph_comp,
			var_second_ph_comp,
			second_ph_resid,
			var_second_ph_resid,
			@secondphase 	as 'desc_second_ph',	

			third_ph_comp,
			var_third_ph_comp,
			third_ph_resid,
			var_third_ph_resid,
			@thirdphase 	as 'desc_third_ph',					

			max_ph_comp,
			var_max_ph_comp,
			max_ph_resid,
			var_max_ph_resid,
			@max_phase 	as 'desc_max_ph',					

			assign_credit,
			var_assign_credit,
			assign_cash,
        		var_assign_cash,

			@previsionkind 		as 'previsionkind',
			@secprevisionkind 	as 'secprevisionkind',
			flag_assign_credit,
			flag_assign_cash,
			flagconsider	
		 	FROM #situation_fin 
			JOIN fin on #situation_fin.idfin = fin.idfin
			ORDER BY upbprintingorder,finprintingorder
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




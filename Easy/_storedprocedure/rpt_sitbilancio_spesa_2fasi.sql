
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_spesa_2fasi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_spesa_2fasi]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE  [rpt_sitbilancio_spesa_2fasi] 
	@ayear				int,
	@date				datetime,
	@nlevel				tinyint,
	@hierarchy			char(1),
	@idupb				varchar(36),
	@showupb 			char(1),
	@showchildupb 			char(1),
	@suppressifblank 		char(1),
	@idfin			        int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
AS
BEGIN
---exec rpt_sitbilancio_spesa_2fasi 2008, {ts '2008-05-13 00:00:00'}, 1, 'S', '%', 'N', 'S', 'S',null
/* Versione 1.0.5 del 27/11/2007 ultima modifica: MARIA */
CREATE TABLE #fin_situation
(
	idfin				int,
	codeupb				varchar(50),
	idupb 				varchar(36),
	upb   				varchar(150),
	upbprintingorder		varchar(50),
	assured				char(1),
	codefin				varchar(50),
	title				varchar(150),
	finprintingorder		varchar(50),
	nlevel				tinyint,
	main_initial_prevision		decimal(19,2),
	varprevprinc			decimal(19,2),
	appropriation_phase_comp 	decimal(19,2),
	var_appropriation_phase_comp	decimal(19,2),
	desc_appropriation_phase 	varchar(50),					
	max_phase_comp         		decimal(19,2),
	var_max_phase_comp      	decimal(19,2),
	desc_max_phase 			varchar(50),					
	sec_initial_prevision		decimal(19,2),
	varprevsec			decimal(19,2),
	appropriation_phase_resid 	decimal(19,2),
	var_appropriation_phase_resid	decimal(19,2),
	max_phase_resid        		decimal(19,2),
	var_max_phase_resid    		decimal(19,2),
	assign_credit 			decimal(19,2),
	var_assign_credit		decimal(19,2),
	assign_cash			decimal(19,2),
	var_assign_cash			decimal(19,2),
	previsionkind 			char(1),
	secprevisionkind 		char(1),
	flag_assign_credit 		char(1),
	flag_assign_cash 		char(1),
	flagconsider 			char(1) 			
)
IF (@ayear IS NULL) BEGIN
	SELECT * FROM  #fin_situation 
	RETURN
END
DECLARE @idupboriginal 			varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S') set @idupb=@idupb+'%' 

DECLARE @appropriation_phase     	tinyint
SELECT  @appropriation_phase = appropriationphasecode
FROM    config WHERE ayear = @ayear

IF @appropriation_phase IS NULL
BEGIN
	SELECT @appropriation_phase = expensefinphase FROM uniconfig
END
DECLARE @desc_appropriation_phase    	varchar(50)
SELECT 	@desc_appropriation_phase=description
FROM 	expensephase WHERE nphase=@appropriation_phase 
DECLARE @max_phase         		tinyint
SELECT  @max_phase = MAX(nphase)
FROM 	expensephase
DECLARE @desc_max_phase    		varchar(50)
SELECT  @desc_max_phase=description 
FROM 	expensephase WHERE nphase=@max_phase 
DECLARE @cashvaliditykind       	int
SELECT  @cashvaliditykind = cashvaliditykind
FROM    config
WHERE   ayear = @ayear
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

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

DECLARE @levelusable 			tinyint
SELECT  @levelusable = MIN(nlevel) FROM finlevel
WHERE 	ayear =@ayear and (flag&2)<>0

IF (@hierarchy='N')
BEGIN
	IF (@suppressifblank = 'S')
	BEGIN
		INSERT INTO #fin_situation
	      	(
			idfin, 
			idupb,
			assured,
			varprevprinc,
			varprevsec,
			flagconsider
		)
		SELECT 
			F.idfin,  	
			U.idupb,
			ISNULL(U.assured,'N'),
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) else 0 END),
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
		WHERE  	((F.flag & 1 ) = 1) and F.ayear =@ayear	
			AND (@idfin IS NULL OR FLK1.idparent = @idfin)
			AND (F.nlevel = @nlevel)
			AND (U.idupb like @idupb  and U.active = 'S')
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb, F.idfin, ISNULL(U.assured,'N') 
		
		-- Inserisco le voci di bilancio che hanno solo RESIDUI
		INSERT INTO #fin_situation
	      			(idfin, 
				idupb,
				assured,
				varprevprinc,
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
		JOIN expensetotal ET
			ON ET.idexp = expenseyear.idexp
			AND ET.ayear = expenseyear.ayear
		JOIN finlink FLK
			ON FLK.idparent = expenseyear.idfin AND FLK.nlevel = @level_input 
		WHERE  ((F.flag & 1 ) = 1) and F.ayear = @ayear	
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (U.idupb like @idupb  and U.active = 'S')
			AND (F.nlevel   = @nlevel)
			AND NOT EXISTS 
				(SELECT *
				 FROM #fin_situation
				 JOIN finlink FLK1 
					ON FLK1.idchild = expenseyear.idfin 
				WHERE expenseyear.idupb = #fin_situation.idupb 
				   AND FLK1.idparent =  #fin_situation.idfin)
			AND expenseyear.ayear=@ayear
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND ((ET.flag & 1) = 1) -- Residuo
	END
	ELSE
	BEGIN
		INSERT INTO #fin_situation
	      	(
			idfin, 
			idupb,
			assured, 
			varprevprinc,
			varprevsec,
			flagconsider
		)
		SELECT 
			F.idfin, 	
			U.idupb,
			ISNULL(U.assured,'N'),
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) else 0 END),
			'S'
		FROM upb U
		CROSS JOIN fin F
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		LEFT OUTER JOIN finvardetail
		  	ON finvardetail.idfin  = FLK2.idchild 
		  	AND finvardetail.idupb = U.idupb 	
		LEFT OUTER JOIN finvar
		 	ON finvar.yvar  = finvardetail.yvar  AND finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar AND finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		WHERE   ((F.flag & 1 ) = 1) and F.ayear =@ayear	
			AND (@idfin IS NULL OR FLK2.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S')
			AND (F.nlevel = @nlevel)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb, F.idfin,ISNULL(U.assured,'N') 
	END
END 
ELSE --> @hierarchy = 'S'
BEGIN
	IF (@suppressifblank = 'S')
	BEGIN
		-----------------------------------
		-----------------------------------
		INSERT INTO #fin_situation
	      			(idfin, 
				idupb,
				assured,
				varprevprinc,
				varprevsec,
				flagconsider
				)
		SELECT 
				F.idfin,
				U.idupb,
				ISNULL(U.assured,'N'),
				SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
				SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) else 0 END),
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
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		LEFT OUTER JOIN finvardetail
		  	ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin
			AND finvardetail.idupb = U.idupb 
		LEFT OUTER JOIN finvar
		  	ON finvar.yvar = finvardetail.yvar  AND finvar.yvar = @ayear	
	  	  	AND finvar.nvar = finvardetail.nvar AND finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		WHERE  ((F.flag & 1 ) = 1) AND F.ayear = @ayear
			AND (U.idupb like @idupb and U.active = 'S')
			AND F.nlevel >=  @nlevel
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear, F.flag, ISNULL(U.assured,'N') --(F.flag & 1) 


		-- Inserisco le coppie che hanno solo RESIDUI
		INSERT INTO #fin_situation
		(
			idfin, 
			idupb,
			assured,
			varprevprinc,
			varprevsec,
			flagconsider
		)
		SELECT distinct
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
			ON expenseyear.idupb = U.idupb 
		JOIN fin F
			ON expenseyear.idfin = F.idfin 
		JOIN expensetotal ET
			ON ET.idexp = expenseyear.idexp
			AND ET.ayear = expenseyear.ayear
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		WHERE  ((F.flag & 1 ) = 1) and F.ayear = @ayear
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S')
			AND (F.nlevel >=  @nlevel)
			AND NOT EXISTS (SELECT *
					  FROM #fin_situation
					  jOIN finlink FLK1 
						ON FLK1.idchild = expenseyear.idfin
					 WHERE expenseyear.idupb = #fin_situation.idupb 
					   AND FLK1.idparent  =  #fin_situation.idfin)			
			AND expenseyear.ayear=@ayear
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND ((ET.flag&1) = 1) -- Residuo
		
		--GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,(F.flag & 1) 
	END
	ELSE
	BEGIN
		INSERT INTO #fin_situation
	      	(
			idfin, 
			idupb,
			assured, 
			varprevprinc,
			varprevsec,
			flagconsider
		)
		SELECT 
			F.idfin,
			U.idupb,
			ISNULL(U.assured,'N'),
			SUM(CASE WHEN finvar.flagprevision = 'S' then isnull(finvardetail.amount,0) else 0 END),
			SUM(CASE WHEN finvar.flagsecondaryprev = 'S' then isnull(finvardetail.amount,0) else 0 END),
			CASE 
				WHEN (F.nlevel >= @levelusable and 
				F.idfin IN (SELECT idfin FROM finlast))
				THEN 'S'
				ELSE 'N'
			END
	        FROM upb U
		CROSS JOIN fin F
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin
		LEFT OUTER JOIN finvardetail
                        ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin
			AND finvardetail.idupb=U.idupb 
		LEFT OUTER JOIN finvar
			ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear
			AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
			AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		WHERE   ((F.flag & 1 ) = 1) and F.ayear = @ayear
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (U.idupb like @idupb  and U.active = 'S')
			AND (F.nlevel >=  @nlevel) 
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag, ISNULL(U.assured,'N')
		
	END
END

	UPDATE #fin_situation
		set main_initial_prevision = 
			ISNULL((
			SELECT SUM(finyear.prevision)
			FROM finyear 
			JOIN fin 
				ON finyear.idfin = fin.idfin  		
			JOIN finlevel 
				ON finlevel.ayear = fin.ayear
				AND finlevel.nlevel = fin.nlevel
			JOIN finlast 
				ON finlast.idfin = fin.idfin
			JOIN finlink
				ON finlink.idchild = fin.idfin
			WHERE finlink.idparent = #fin_situation.idfin
				 AND (finlevel.flag&2)<>0
				 AND finyear.idupb =  #fin_situation.idupb 
				 AND finyear.ayear = @ayear), 0.0),

		sec_initial_prevision = 	
				ISNULL((
				SELECT SUM(finyear.secondaryprev)
				FROM finyear 
				JOIN fin 
					ON finyear.idfin = fin.idfin 
				JOIN finlevel 
					ON finlevel.ayear = fin.ayear
					AND finlevel.nlevel = fin.nlevel
				JOIN finlast 
					ON finlast.idfin = fin.idfin
				JOIN finlink
					ON finlink.idchild = fin.idfin
				WHERE finlink.idparent = #fin_situation.idfin
					AND (finlevel.flag&2)<>0
					AND finyear.idupb =  #fin_situation.idupb 
					AND finyear.ayear = @ayear
					), 0.0)
	UPDATE #fin_situation
		SET
		 appropriation_phase_comp = 
			ISNULL((SELECT SUM(expenseyear.amount)
			FROM expense
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp
			JOIN expensetotal 
				ON expensetotal.idexp = expenseyear.idexp
				AND expensetotal.ayear = expenseyear.ayear
			JOIN finlink
				ON finlink.idchild = expenseyear.idfin
			WHERE expense.adate <= @date 
				AND expenseyear.ayear = @ayear
				AND ((expensetotal.flag&1)=0) -- Competenza
				AND finlink.idparent= #fin_situation.idfin 
				AND expenseyear.idupb = #fin_situation.idupb
				AND expense.nphase = @appropriation_phase), 0.0),
		var_appropriation_phase_comp =
			ISNULL((SELECT SUM(expensevar.amount)
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
				AND expense.nphase= @appropriation_phase
				AND ((expensetotal.flag&1)=0) -- Competenza
				AND finlink.idparent = #fin_situation.idfin 
				AND expenseyear.idupb = #fin_situation.idupb
				AND expensevar.yvar = @ayear), 0.0),
		 appropriation_phase_resid = 
			ISNULL((SELECT SUM(expenseyear.amount)
				FROM expense
				JOIN expenseyear
					ON expenseyear.idexp = expense.idexp
				JOIN expensetotal 
					ON expensetotal.idexp = expenseyear.idexp
					AND expensetotal.ayear = expenseyear.ayear
				JOIN finlink
					ON finlink.idchild = expenseyear.idfin
			WHERE expense.adate <= @date 
				AND expenseyear.ayear = @ayear
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND finlink.idparent = #fin_situation.idfin 
				AND expenseyear.idupb = #fin_situation.idupb 
				AND expense.nphase = @appropriation_phase), 0.0),

		var_appropriation_phase_resid =
			ISNULL((SELECT SUM(expensevar.amount)
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
				AND expense.nphase= @appropriation_phase
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND finlink.idparent = #fin_situation.idfin 
				AND expenseyear.idupb = #fin_situation.idupb
				AND expensevar.yvar   = @ayear), 0.0)
    UPDATE #fin_situation
--  GESTIONE DEL FONDO ECONOMALE
    SET 
		appropriation_phase_comp = 
			ISNULL(appropriation_phase_comp, 0.0) +
			ISNULL((SELECT SUM(operation.amount)
			FROM pettycashoperation operation
			JOIN finlink 
				ON finlink.idchild = operation.idfin
			WHERE finlink.idparent = #fin_situation.idfin
				AND operation.idupb = #fin_situation.idupb
				AND operation.yoperation = @ayear
				AND operation.adate <= @date 
				AND NOT EXISTS (SELECT * FROM pettycashoperation oprestore
						WHERE oprestore.idpettycash = operation.idpettycash
						AND oprestore.yoperation = operation.yrestore
						AND oprestore.noperation = operation.nrestore
						AND oprestore.adate <= @date
						AND oprestore.yoperation = @ayear)), 0.0)
UPDATE #fin_situation
	SET	max_phase_comp=	 
			ISNULL((SELECT SUM(HPV.amount)
			FROM historypaymentview HPV
			JOIN finlink
				ON finlink.idchild = HPV.idfin	 
			WHERE ((HPV.totflag&1)=0) -- Competenza
				AND HPV.ymov = @ayear
				AND HPV.competencydate <= @date
				AND finlink.idparent = #fin_situation.idfin
				AND HPV.idupb = #fin_situation.idupb), 0.0),
		max_phase_resid=	 
				ISNULL((SELECT SUM(HPV.amount)
				FROM historypaymentview HPV
				JOIN finlink
					ON finlink.idchild = HPV.idfin	 
				WHERE ((HPV.totflag&1)=1) -- Residuo
					AND HPV.ymov = @ayear
					AND HPV.competencydate <= @date
					AND finlink.idparent = #fin_situation.idfin
					AND HPV.idupb = #fin_situation.idupb), 0.0)	
	
IF @cashvaliditykind <> 4
BEGIN
	UPDATE #fin_situation
		SET var_max_phase_comp= 
			ISNULL((SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN historypaymentview HPV
				ON HPV.idexp = expensevar.idexp
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
			WHERE  finlink.idparent = #fin_situation.idfin
				AND HPV.ymov = @ayear AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=0) -- Copetenza
				AND HPV.idupb = #fin_situation.idupb
				AND expensevar.yvar = @ayear
				AND expensevar.adate <= @date), 0.0),

		var_max_phase_resid= 
			ISNULL((SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN  historypaymentview HPV
				ON HPV.idexp = expensevar.idexp
			JOIN finlink
				ON finlink.idchild = HPV.idfin	
			WHERE expensevar.yvar = @ayear
				AND HPV.ymov = @ayear AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=1) -- Residuo
				AND finlink.idparent  = #fin_situation.idfin
				AND HPV.idupb = #fin_situation.idupb 
				AND expensevar.adate <= @date), 0.0)
END
	
-- Controlla che i CREDITI  siano gestiti
IF 	(EXISTS(SELECT* FROM creditpart
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
		UPDATE #fin_situation
		SET var_assign_credit = ISNULL((SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v 
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN finlink
					ON finlink.idchild = d.idfin
				WHERE finlink.idparent = #fin_situation.idfin
					AND v.idfinvarstatus = 5
					AND d.idupb = #fin_situation.idupb
					AND #fin_situation.assured <> 'S' -- solo upb non a finanziamento certo
					AND v.flagcredit ='S'
					AND v.adate <= @date
					AND v.variationkind IN (2)),0.0),
		 assign_credit = ISNULL((SELECT SUM(creditpart.amount)
				FROM creditpart 
				JOIN incomeyear
					ON creditpart.idinc = incomeyear.idinc
					AND creditpart.ycreditpart = incomeyear.ayear
				JOIN finlink
					ON finlink.idchild = creditpart.idfin
				WHERE finlink.idparent = #fin_situation.idfin
					AND creditpart.idupb = #fin_situation.idupb
					AND #fin_situation.assured <> 'S'
					AND adate <= @date),0.0)
				+	
				ISNULL((SELECT SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
					AND v.flagcredit ='S'
				JOIN finlink
					ON finlink.idchild = d.idfin
				WHERE finlink.idparent = #fin_situation.idfin
					AND v.idfinvarstatus = 5
					AND d.idupb = #fin_situation.idupb
					AND #fin_situation.assured <> 'S'
					AND v.adate <= @date
					AND v.variationkind IN (1,3,4)),0.0),
		flag_assign_credit='S'
		UPDATE #fin_situation
			SET flag_assign_credit='N'    -- se upb a finanziamento certo, non considero i crediti
			WHERE #fin_situation.assured  = 'S'
	END
ELSE
	UPDATE  #fin_situation
	SET 	var_assign_credit = 0,
		assign_credit =0,
		flag_assign_credit='N'
-- Controlla che gli INCASSI siano gestiti
IF 	(EXISTS(SELECT* FROM proceedspart 
		WHERE yproceedspart	= @ayear
		AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagproceeds='S' and 
		yvar = @ayear AND 
		adate <= @date
		AND finvar.idfinvarstatus = 5)
	--OR
	--EXISTS (select * from upb where assured='S')
	)
	BEGIN
	UPDATE #fin_situation
		SET var_assign_cash = 
			ISNULL(( SELECT SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagproceeds='S'
			JOIN finlink
				ON finlink.idchild = d.idfin
			WHERE finlink.idparent = #fin_situation.idfin
				AND v.idfinvarstatus = 5
				AND d.idupb = #fin_situation.idupb
				AND #fin_situation.assured <> 'S'
				AND v.adate <= @date
				AND v.variationkind IN (2)),0.0),
		 
		assign_cash = ISNULL(( select SUM(proceedspart.amount)
			FROM proceedspart
			JOIN incomeyear
				ON proceedspart.idinc = incomeyear.idinc
				AND proceedspart.yproceedspart = incomeyear.ayear
			JOIN finlink
				ON finlink.idchild = proceedspart.idfin
			WHERE finlink.idparent = #fin_situation.idfin
				AND proceedspart.idupb = #fin_situation.idupb
				AND #fin_situation.assured <> 'S'
				AND adate <= @date),0.0)
			+
			ISNULL((SELECT  SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagproceeds='S'
			JOIN finlink
				ON finlink.idchild = d.idfin
			WHERE finlink.idparent = #fin_situation.idfin
				AND v.idfinvarstatus = 5
				AND v.adate <= @date
				AND d.idupb = #fin_situation.idupb
				AND #fin_situation.assured <> 'S'
				AND v.variationkind IN (1,3,4)),0.0),
		flag_assign_cash='S'
		UPDATE #fin_situation
		SET flag_assign_cash='N' 
		WHERE #fin_situation.assured = 'S'
	END
ELSE
	BEGIN 
	UPDATE #fin_situation
	SET	var_assign_cash = 0,
		assign_cash = 0,
		flag_assign_cash='N'
	END
-- VALORIZZA CAMPI upb
IF (@showupb = 'S')	
	UPDATE #fin_situation 
	SET  upbprintingorder = upb.printingorder,
	upb = upb.title,
	codeupb = upb.codeupb
	FROM upb
	WHERE upb.idupb = #fin_situation.idupb
IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
	BEGIN
	UPDATE #fin_situation SET  
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
				UPDATE #fin_situation
				SET    flag_assign_credit='S'
				FROM   upb
				WHERE  upb.idupb = #fin_situation.idupb    -- ho aggiornato l'upb devo rivalutare flag_assign_credit
				  AND ISNULL(upb.assured, 'N') <> 'S'
				
				UPDATE #fin_situation
				SET    flag_assign_credit='N'
				FROM   upb 
				WHERE  upb.idupb = #fin_situation.idupb 
				  AND  ISNULL(upb.assured, 'N') = 'S'
			END
			ELSE   
			UPDATE #fin_situation
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
				UPDATE #fin_situation
				SET    flag_assign_cash='S'
				FROM   upb 
				WHERE  upb.idupb = #fin_situation.idupb  -- ho aggiornato l'upb devo rivalutare flag_assign_cash
				  AND ISNULL(upb.assured, 'N') <> 'S'
				
				UPDATE #fin_situation
				SET    flag_assign_cash='N'
				FROM   upb 
				WHERE  upb.idupb = #fin_situation.idupb 
				  AND  ISNULL(upb.assured, 'N') = 'S'
			END
			ELSE   
			UPDATE #fin_situation
			SET    flag_assign_cash='N'
		END
IF (@showupb <>'S') and (@idupboriginal = '%') 
	BEGIN
		UPDATE #fin_situation SET  
		idupb = 		null,
		upbprintingorder = 	null,
		upb =  			null,
		codeupb = 		null
		-- considero solo se sono gestiti crediti e cassa, non gli upb
		IF  (EXISTS(SELECT* FROM creditpart 
		     WHERE ycreditpart = @ayear AND adate <= @date) 
		OR
		EXISTS (SELECT * FROM finvar
			WHERE flagcredit='S' and yvar = @ayear AND adate <= @date))
			UPDATE #fin_situation
			SET    flag_assign_credit='S'
			ELSE   
			UPDATE #fin_situation
			SET    flag_assign_credit='N'
	
		IF  (EXISTS(SELECT* FROM proceedspart 
			WHERE yproceedspart = @ayear AND adate <= @date) 
		OR
		EXISTS (SELECT * FROM finvar
			WHERE flagproceeds='S' and 
			yvar = @ayear AND adate <= @date
			AND finvar.idfinvarstatus = 5))
			UPDATE #fin_situation
			SET    flag_assign_cash='S'
			ELSE   
			UPDATE #fin_situation
			SET    flag_assign_cash='N'
	END
IF (@suppressifblank = 'S') AND @nlevel>=2 --> se la stampa è x un livello uguale o sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #fin_situation WHERE 
		(isnull(main_initial_prevision,0.0) =0 AND 
		isnull(varprevprinc,0.0) =0 AND 
		isnull(appropriation_phase_comp,0.0) =0 AND 
		isnull(var_appropriation_phase_comp,0.0) =0 AND 
		isnull(max_phase_comp,0.0) =0 AND 
		isnull(var_max_phase_comp,0.0) =0 AND 
		isnull(sec_initial_prevision,0.0) =0 AND 
		isnull(varprevsec,0.0) =0 AND 
		isnull(appropriation_phase_resid,0.0) =0 AND 
		isnull(var_appropriation_phase_resid,0.0) =0 AND 
		isnull(max_phase_resid,0.0) =0 AND 
		isnull(var_max_phase_resid,0.0) =0 AND 
		isnull(assign_credit,0.0) =0 AND 
		isnull(var_assign_credit,0.0) =0 AND 
		isnull(assign_cash,0.0) =0 AND 
		isnull(var_assign_cash,0.0) =0 AND
		(select nlevel from fin FFF where FFF.idfin= #fin_situation.idfin)>=2
)	--AND nlevel >=2)
END
IF (@showupb <>'S') 
BEGIN
	SELECT 	#fin_situation.idfin,	
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		fin.codefin,	
		fin.title,	
		fin.printingorder as 'finprintingorder',	
		fin.nlevel,	
		sum(isnull(main_initial_prevision,0.0)) as 'main_initial_prevision',
		sum(isnull(varprevprinc,0.0)) 		as 'varprevprinc'	,
		sum(isnull(appropriation_phase_comp,0.0)) 	as 'appropriation_phase_comp',
		sum(isnull(var_appropriation_phase_comp,0.0)) 	as 'var_appropriation_phase_comp' ,
		@desc_appropriation_phase  			as 'desc_appropriation_phase',									
		sum(isnull(max_phase_comp,0.0)) 	as 'max_phase_comp',
		sum(isnull(var_max_phase_comp,0.0)) 	as 'var_max_phase_comp',
		@desc_max_phase 			as 'desc_max_phase',										
		sum(isnull(sec_initial_prevision,0.0)) 	as 'sec_initial_prevision',
		sum(isnull(varprevsec,0.0)) 		as 'varprevsec',
		sum(isnull(appropriation_phase_resid,0.0)) 	as 'appropriation_phase_resid',
		sum(isnull(var_appropriation_phase_resid,0.0)) 	as 'var_appropriation_phase_resid',
		sum(isnull(max_phase_resid,0.0)) 	as 'max_phase_resid' ,
		sum(isnull(var_max_phase_resid,0.0)) 	as 'var_max_phase_resid',
		sum(isnull(assign_credit,0.0)) 		as 'assign_credit',
		sum(isnull(var_assign_credit,0.0)) 	as 'var_assign_credit',
		sum(isnull(assign_cash,0.0)) 		as 'assign_cash' ,
		sum(isnull(var_assign_cash,0.0)) 	as 'var_assign_cash',
		@previsionkind 				as 'previsionkind',
		@secprevisionkind 			as 'secprevisionkind',
		flag_assign_credit,
		flag_assign_cash,
		flagconsider			
		FROM #fin_situation 
		JOIN fin 
			ON #fin_situation.idfin = fin.idfin		
		GROUP BY idupb,
			#fin_situation.idfin,
			codeupb,
			upb,
			upbprintingorder,
			fin.codefin,	
			fin.title,
			fin.printingorder,
			fin.nlevel,
			flag_assign_credit,
			flag_assign_cash,
			flagconsider			
		ORDER BY upbprintingorder,finprintingorder
END
ELSE
	SELECT 
		#fin_situation.idfin,	
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		fin.codefin,	
		fin.title,	
		fin.printingorder as 'finprintingorder',	
		fin.nlevel,	
		main_initial_prevision,
		varprevprinc,
		appropriation_phase_comp,
		var_appropriation_phase_comp,
		@desc_appropriation_phase as 'desc_appropriation_phase',					
		max_phase_comp,
		var_max_phase_comp,
		@desc_max_phase as 'desc_max_phase',					
		sec_initial_prevision,
		varprevsec,
		appropriation_phase_resid,
		var_appropriation_phase_resid,
		max_phase_resid,
		var_max_phase_resid,
		assign_credit,
		var_assign_credit,
		assign_cash,
		var_assign_cash,
		@previsionkind as 'previsionkind',
		@secprevisionkind as 'secprevisionkind',
		flag_assign_credit,
		flag_assign_cash,
		flagconsider			
		FROM #fin_situation JOIN fin 
			ON #fin_situation.idfin = fin.idfin		
		ORDER BY upbprintingorder,finprintingorder
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


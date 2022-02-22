
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_newsitbilancio_spesa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_newsitbilancio_spesa]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_newsitbilancio_spesa 2013, {ts '2013-12-31 00:00:00'}, 1, 'S', '%', 'S', 'N', 'N',null, null,null,null,null,null

CREATE  PROCEDURE [rpt_newsitbilancio_spesa]
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

CREATE TABLE #situation_fin
(
	idupb 			varchar(36),
	assured			char(1),
	idfin			int,
	nlevel			tinyint,
	main_initial_prevision	decimal(19,2),
	var_main_prevision	decimal(19,2),
	fin_ph_comp		decimal(19,2),
	var_fin_ph_comp		decimal(19,2), 
	desc_fin_ph 		varchar(50),					
	registry_ph_comp	decimal(19,2),
	var_registry_ph_comp	decimal(19,2),
	desc_registry_ph 	varchar(50),					
	max_ph_comp         	decimal(19,2),
	var_max_ph_comp       	decimal(19,2),
	desc_max_ph 		varchar(50),					
	sec_initial_prevision	decimal(19,2),
	varprevsec		decimal(19,2),
	fin_ph_resid		decimal(19,2), 
	var_fin_ph_resid	decimal(19,2),
	registry_ph_resid	decimal(19,2),
	var_registry_ph_resid	decimal(19,2),
	max_ph_resid         	decimal(19,2),
	var_max_ph_resid      	decimal(19,2),
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

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0

DECLARE @fin_phase  tinyint -- fase accantonamento precedente alla fase di impegno, Modifica Sara
SELECT 	@fin_phase = expensefinphase FROM uniconfig

DECLARE @desc_fin_phase varchar(50)
SELECT  @desc_fin_phase=description
FROM 	expensephase WHERE nphase=@fin_phase 

DECLARE @registry_phase tinyint
SELECT  @registry_phase = expenseregphase FROM uniconfig

DECLARE @desc_registry_phase varchar(50)
SELECT  @desc_registry_phase=description
FROM    expensephase WHERE nphase=@registry_phase 

DECLARE @max_phase          	tinyint
SELECT  @max_phase = MAX(nphase) FROM expensephase
DECLARE @desc_max_phase    	varchar(50)
SELECT  @desc_max_phase=description 
FROM 	expensephase WHERE nphase=@max_phase 
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
			isnull(@fixedidupb,U.idupb),
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
		GROUP BY isnull(@fixedidupb,U.idupb), F.idfin, ISNULL(U.assured,'N')

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
			isnull(@fixedidupb,U.idupb),
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
			AND ((expensetotal.flag & 1) = 1) -- Residuo
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
END 
ELSE -- Caso : @hierarchy = 'N'
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
				AND expense.nphase = @fin_phase), 0.0),
			
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
			AND expense.nphase= @fin_phase
			AND ((expensetotal.flag&1)=0) -- Competenza
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
			AND expense.nphase = @fin_phase), 0.0),
			
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
			AND expense.nphase= @fin_phase
			AND ((expensetotal.flag&1)=1) -- Residuo
			AND finlink.idparent = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
			
 	registry_ph_comp = 
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
			AND expense.nphase = @registry_phase), 0.0),
	var_registry_ph_comp =
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
			AND expense.nphase= @registry_phase
			AND ((expensetotal.flag&1)=0) -- Competenza
			AND finlink.idparent  = #situation_fin.idfin 
			AND expenseyear.idupb = #situation_fin.idupb
			AND expensevar.yvar = @ayear), 0.0),
	registry_ph_resid = 
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
			AND expenseyear.idupb = #situation_fin.idupb), 0.0),
	var_registry_ph_resid =
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
			AND expense.nphase= @registry_phase
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
     registry_ph_comp = ISNULL(registry_ph_comp, 0.0) +
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
DECLARE @Crediti char(1)
SET @Crediti = 'N'

IF 	
	(EXISTS(SELECT* FROM creditpart
		WHERE ycreditpart = @ayear AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagcredit ='S' and yvar = @ayear
		AND adate <= @date
		AND finvar.idfinvarstatus = 5)
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
					AND v.variationkind IN (2,3)),0.0),
				
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
					AND v.variationkind IN (1,4)),0.0),
			flag_assign_credit='S'
			
			UPDATE #situation_fin
			SET flag_assign_credit='N' 
			WHERE #situation_fin.assured  = 'S' -- se upb a finanziamento certo, non considero i crediti
			
			SET @Crediti = 'S'
		END
ELSE
BEGIN
		UPDATE #situation_fin SET var_assign_credit = 0,
								assign_credit =0,
								flag_assign_credit='N'
		SET @Crediti = 'N' 						
			
END

DECLARE @Incassi char(1)
SET @Incassi = 'N'

IF 	(EXISTS(SELECT* FROM proceedspart 
		WHERE yproceedspart	= @ayear
		AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagproceeds='S' and 
		yvar = @ayear AND 
		adate <= @date AND 
		finvar.idfinvarstatus = 5)
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
				AND v.variationkind IN (2,3)),0.0),
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
				AND v.variationkind IN (1,4)),0.0),
			flag_assign_cash='S' 

			UPDATE #situation_fin
			SET flag_assign_cash='N' 
			WHERE #situation_fin.assured = 'S'

			SET @Incassi = 'S'
	END
ELSE
BEGIN 
	UPDATE #situation_fin
	SET	var_assign_cash = 0,
		assign_cash = 0,
		flag_assign_cash='N'
		
	SET @Incassi = 'N'		
END
	


IF(@showupb='S')	
Begin
		IF  (EXISTS(SELECT* FROM creditpart WHERE ycreditpart = @ayear AND adate <= @date) 
		OR
		EXISTS (SELECT * FROM finvar WHERE flagcredit='S' and yvar = @ayear AND adate <= @date AND finvar.idfinvarstatus = 5))
		BEGIN 
			UPDATE #situation_fin
			SET    flag_assign_credit='S'  -- ho aggiornato l'upb devo rivalutare flag_assign_credit
			FROM   upb
			WHERE  upb.idupb = #situation_fin.idupb AND ISNULL(upb.assured, 'N') <> 'S'
			
			UPDATE #situation_fin
			SET    flag_assign_credit='N'
			FROM   upb 
			WHERE  upb.idupb = #situation_fin.idupb AND  ISNULL(upb.assured, 'N') <> 'N'
		END
		ELSE   
			UPDATE #situation_fin SET    flag_assign_credit='N'
	
		IF  (EXISTS(SELECT* FROM proceedspart WHERE yproceedspart = @ayear AND adate <= @date) 
			OR
			EXISTS (SELECT * FROM finvar WHERE flagproceeds='S' and yvar = @ayear AND adate <= @date AND finvar.idfinvarstatus = 5))	
		BEGIN
				UPDATE #situation_fin
				SET    flag_assign_cash='S' -- ho aggiornato l'upb devo rivalutare flag_assign_credit
				FROM   upb 
				WHERE  upb.idupb = #situation_fin.idupb  AND ISNULL(upb.assured, 'N') <> 'S'
				
				UPDATE #situation_fin
				SET    flag_assign_cash='N'
				FROM   upb 
				WHERE  upb.idupb = #situation_fin.idupb AND  ISNULL(upb.assured, 'N') = 'S'
		END
		ELSE   
			UPDATE #situation_fin SET    flag_assign_cash='N'
End	
Else
BEGIN
		-- considero solo se sono gestiti crediti e cassa, non gli upb
		IF  (EXISTS(SELECT* FROM creditpart WHERE ycreditpart = @ayear AND adate <= @date) 
			OR
			EXISTS (SELECT * FROM finvar WHERE flagcredit='S' and yvar = @ayear AND adate <= @date AND finvar.idfinvarstatus = 5))
		Begin	
			UPDATE #situation_fin SET flag_assign_credit='S'
		End	
		else
		Begin
			UPDATE #situation_fin SET flag_assign_credit='N'
		End
		
		IF  (EXISTS(SELECT* FROM proceedspart WHERE yproceedspart = @ayear AND adate <= @date) 
			OR
			EXISTS (SELECT * FROM finvar WHERE flagproceeds='S' and yvar = @ayear AND adate <= @date AND finvar.idfinvarstatus = 5))
		Begin
			UPDATE #situation_fin SET flag_assign_cash='S'
		End	
		Else
		Begin
			UPDATE #situation_fin SET flag_assign_cash='N'
		End	
END

--	--	--	--	--	-- Aggiunge le voci inutilizzate se @suppressifblank = N --	--	--	--	--	--	

IF (@suppressifblank = 'N') 
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
IF ( (@showupb <>'S') and (@idupboriginal = '%'))
Begin
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #situation_fin(idfin, flagconsider)
			SELECT 
				F.idfin,
				CASE 
					 WHEN (F.nlevel >= @levelusable and 
					 F.idfin IN (SELECT idfin FROM finlast))
					 THEN 'S'
					 ELSE 'N'
				END
			FROM fin F 
			JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
			WHERE ((F.flag & 1) = 1) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel >=  @nlevel)
			GROUP BY F.idfin,F.ayear,F.flag, F.nlevel
		END
	ELSE
		BEGIN
			INSERT INTO #situation_fin(idfin, flagconsider)
			SELECT F.idfin, 'S'
			FROM fin F
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			WHERE  	((F.flag & 1 ) <>0) AND F.ayear =@ayear	
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel = @nlevel)
			GROUP BY F.idfin		
		END
end
else
begin
	--> @showupb ='S'
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #situation_fin(
				idfin, 
				idupb,
				assured,
				flagconsider
			)
			SELECT 
				F.idfin,
				U.idupb,
				ISNULL(U.assured,'N'),
				CASE 
					 WHEN (F.nlevel >= @levelusable and 
					 F.idfin IN (SELECT idfin FROM finlast))
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
				AND (F.nlevel >=  @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag, ISNULL(U.assured,'N')
		END
	ELSE
		BEGIN
			INSERT INTO #situation_fin(
				idfin, 
				idupb,
				assured,
				flagconsider
				)
			SELECT 
				F.idfin, 
				U.idupb,
				ISNULL(U.assured,'N'),
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
				AND (F.nlevel = @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idupb, F.idfin,ISNULL(U.assured,'N')
		END
end
END
IF (@suppressifblank = 'N')
Begin
	IF (@Crediti = 'S')
		Begin
			UPDATE #situation_fin SET flag_assign_credit='S'
		End	
		Else
		Begin
			UPDATE #situation_fin SET flag_assign_credit='N'
		End	

	IF (@Incassi = 'S')
		Begin
			UPDATE #situation_fin SET flag_assign_cash='S'
		End	
		Else
		Begin
			UPDATE #situation_fin SET flag_assign_cash='N'
		End	
		
End
--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--	--				
		
		
IF (@suppressifblank = 'S') AND @nlevel>=2	--> se la stampa è x categoria o x un livello sottostante la categoria cancella le righe
BEGIN
	DELETE FROM #situation_fin WHERE 
			(isnull(main_initial_prevision,0.0) =0 AND 
			isnull(var_main_prevision,0.0) =0 AND 
			isnull(registry_ph_comp,0.0) =0 AND 
			isnull(var_registry_ph_comp,0.0) =0 AND 
			isnull(max_ph_comp,0.0) =0 AND 
			isnull(var_max_ph_comp,0.0) =0 AND 
			isnull(sec_initial_prevision,0.0) =0 AND 
			isnull(varprevsec,0.0) =0 AND 
			isnull(registry_ph_resid,0.0) =0 AND 
			isnull(var_registry_ph_resid,0.0) =0 AND 
			isnull(max_ph_resid,0.0) =0 AND 
			isnull(var_max_ph_resid,0.0) =0 AND 
			isnull(assign_credit,0.0) =0 AND 
			isnull(var_assign_credit,0.0) =0 AND 
			isnull(assign_cash,0.0) =0 AND 
			isnull(var_assign_cash,0.0) =0 AND
			isnull(fin_ph_comp,0.0) =0 AND  
			isnull(var_fin_ph_comp,0.0) =0 AND 
			isnull(fin_ph_resid,0.0) =0 AND 
			isnull(var_fin_ph_resid,0.0) =0 AND 			
			(select nlevel from fin FFF where FFF.idfin= #situation_fin.idfin)>=2)
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
		#situation_fin.idfin,	
		fin.printingorder 			as 'finprintingorder',
		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,	
		fin.codefin,	
		fin.title,	
		fin.nlevel,	
		sum(isnull(main_initial_prevision,0.0)) as 'main_initial_prevision',
		sum(isnull(var_main_prevision,0.0)) 	as 'var_main_prevision',
		sum(isnull(fin_ph_comp,0.0)) 		as 'fin_ph_comp',
		sum(isnull(var_fin_ph_comp,0.0)) 	as 'var_fin_ph_comp', 
		@desc_fin_phase 			as 'desc_fin_ph',					
		sum(isnull(registry_ph_comp,0.0)) 	as 'registry_ph_comp',
		sum(isnull(var_registry_ph_comp,0.0)) 	as 'var_registry_ph_comp',
		@desc_registry_phase 			as 'desc_registry_ph',					
		sum(isnull(max_ph_comp,0.0)) 		as 'max_ph_comp',
		sum(isnull(var_max_ph_comp,0.0)) 	as 'var_max_ph_comp',
		@desc_max_phase 			as 'desc_max_ph' 	,					
		sum(isnull(sec_initial_prevision,0.0)) 	as 'sec_initial_prevision',
		sum(isnull(varprevsec,0.0)) 		as 'varprevsec',
		sum(isnull(fin_ph_resid,0.0)) 		as 'fin_ph_resid', 
		sum(isnull(var_fin_ph_resid,0.0)) 	as 'var_fin_ph_resid',
		sum(isnull(registry_ph_resid,0.0)) 	as 'registry_ph_resid',
		sum(isnull(var_registry_ph_resid,0.0))  as 'var_registry_ph_resid',
		sum(isnull(max_ph_resid,0.0)) 		as 'max_ph_resid',
		sum(isnull(var_max_ph_resid,0.0)) 	as 'var_max_ph_resid',
		sum(isnull(assign_credit,0.0)) 		as 'assign_credit',
		sum(isnull(var_assign_credit,0.0)) 	as 'var_assign_credit',
		sum(isnull(assign_cash,0.0)) 		as 'assign_cash',
		sum(isnull(var_assign_cash,0.0)) 	as 'var_assign_cash',
		@previsionkind 				as 'previsionkind',
		@secprevisionkind 			as 'secprevisionkind',
		flag_assign_credit,
		flag_assign_cash,
		flagconsider	
 	FROM #situation_fin 
 	JOIN fin 
		ON #situation_fin.idfin = fin.idfin			
	GROUP BY #situation_fin.idfin,
		fin.printingorder,
		fin.codefin,	
		fin.title,
		fin.nlevel,
		flag_assign_credit,
		flag_assign_cash,
		flagconsider			
	ORDER BY finprintingorder
END 
	ELSE
		SELECT 
			#situation_fin.idfin,	
			codeupb,
			#situation_fin.idupb,
			upb.title as 'upb',
			upb.printingorder as 'printingorder',
			fin.codefin,	
			fin.title,	
			fin.printingorder 	as 'finprintingorder',	
			fin.nlevel,	
			sum(isnull(main_initial_prevision,0.0)) as 'main_initial_prevision',
			sum(isnull(var_main_prevision,0.0)) 	as 'var_main_prevision',
			sum(isnull(fin_ph_comp,0.0)) 		as 'fin_ph_comp',
			sum(isnull(var_fin_ph_comp,0.0)) 	as 'var_fin_ph_comp', 
			@desc_fin_phase 	as 'desc_fin_ph',					
			sum(isnull(registry_ph_comp,0.0)) 	as 'registry_ph_comp',
			sum(isnull(var_registry_ph_comp,0.0)) 	as 'var_registry_ph_comp',
			@desc_registry_phase 	as 'desc_registry_ph',					
			sum(isnull(max_ph_comp,0.0)) 		as 'max_ph_comp',
			sum(isnull(var_max_ph_comp,0.0)) 	as 'var_max_ph_comp',
			@desc_max_phase 	as 'desc_max_ph',		
			sum(isnull(sec_initial_prevision,0.0)) 	as 'sec_initial_prevision',
			sum(isnull(varprevsec,0.0)) 		as 'varprevsec',
			sum(isnull(fin_ph_resid,0.0)) 		as 'fin_ph_resid', 
			sum(isnull(var_fin_ph_resid,0.0)) 	as 'var_fin_ph_resid',
			sum(isnull(registry_ph_resid,0.0)) 	as 'registry_ph_resid',
			sum(isnull(var_registry_ph_resid,0.0))  as 'var_registry_ph_resid',
			sum(isnull(max_ph_resid,0.0)) 		as 'max_ph_resid',
			sum(isnull(var_max_ph_resid,0.0)) 	as 'var_max_ph_resid',
			sum(isnull(assign_credit,0.0)) 		as 'assign_credit',
			sum(isnull(var_assign_credit,0.0)) 	as 'var_assign_credit',
			sum(isnull(assign_cash,0.0)) 		as 'assign_cash',
			sum(isnull(var_assign_cash,0.0)) 	as 'var_assign_cash',
			@previsionkind 		as 'previsionkind',
			@secprevisionkind 	as 'secprevisionkind',
			flag_assign_credit,
			flag_assign_cash,
			flagconsider	
	 	FROM #situation_fin 
		JOIN fin 
			on #situation_fin.idfin = fin.idfin
		JOIN upb
			on #situation_fin.idupb = upb.idupb
		GROUP BY upb.printingorder, codeupb, #situation_fin.idupb,upb.title,
			fin.printingorder, fin.codefin, fin.title, #situation_fin.idfin,
			fin.nlevel,
			flag_assign_credit,
			flag_assign_cash,
			flagconsider			
		ORDER BY upb.printingorder,fin.printingorder
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitbilancio_spesa_4fasi_UniCt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitbilancio_spesa_4fasi_UniCt]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- setuser 'amministrazione'
-- exec [exp_sitbilancio_spesa_4fasi_UniCt]		 2024, {ts '2024-12-31 00:00:00'},'S', '00010023004800890001',   'S','S',null,null,null,null,null
-- go
-- exec [exp_sitbilancio_spesa_4fasi_UniCt]   2024, {ts '2024-12-31 00:00:00'},'E', '00010023001300110007',   'S','N',null,null,null,null,null
-- go
-- exec [exp_sitbilancio_spesa_4fasi_UniCt]   2025, {ts '2024-05-29 00:00:00'},'E', '00010023001300110007',   'S','N',null,null,null,null,null
-- go
-- exec [exp_sitbilancio_spesa_4fasi_UniCt]   2024, {ts '2024-12-31 00:00:00'},'S', '00010023001300110007',   'S','N',null,null,null,null,null
-- go
-- exec [exp_sitbilancio_spesa_4fasi_UniCt]   2025, {ts '2024-05-29 00:00:00'},'S', '00010023001300110007',   'S','N',null,null,null,null,null
CREATE  PROCEDURE [exp_sitbilancio_spesa_4fasi_UniCt]
	@ayear			int,
	@date			datetime,
	@finpart		char(1),
	@idupb			varchar(36),
	@suppressifblank 	char(1),
	@VociCosto 	char(1),
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
		tot_max_ph         	decimal(19,2),


		flagconsider 		char(1)		
	)
	DECLARE @nfinphase  tinyint
	DECLARE @nmaxphase tinyint
	DECLARE @nsecondphase tinyint
	DECLARE @nthirdphase INT
	DECLARE @finphase varchar(50)
	DECLARE @secondphase varchar(50)
	DECLARE @thirdphase varchar(50)
	DECLARE @max_phase varchar(50)

IF @ayear IS NULL 
BEGIN
	SELECT * FROM #situation_fin
	RETURN
END
DECLARE	@idfin	int 
SET @idfin = NULL -- Per usi futuri

DECLARE @idupboriginal 		varchar(36)
SET 	@idupboriginal= @idupb
set @idupb=@idupb+'%' 

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0

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

DECLARE @nlevel	 tinyint
SELECT  @nlevel =   MAX(nlevel) from finlevel where ayear = @ayear
DECLARE @level_input tinyint
SET  @level_input = @level_input

IF @finpart = 'S'
	BEGIN
	--------------------------- inizio spese
	SELECT 	@nfinphase = expensefinphase FROM uniconfig
	SELECT  @nmaxphase = MAX(nphase) FROM expensephase
	SELECT  @nsecondphase = nphase FROM expensephase  WHERE nphase = @nfinphase + 1
	SELECT  @nthirdphase = nphase FROM expensephase  WHERE nphase = @nmaxphase - 1 
	SELECT  @finphase=description FROM expensephase WHERE nphase = @nfinphase 
	SELECT  @secondphase=description FROM  expensephase WHERE nphase=@nsecondphase 
	SELECT @thirdphase = description from  expensephase where nphase = @nthirdphase
	SELECT  @max_phase=description  FROM expensephase WHERE nphase=@nmaxphase 


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
				LEFT OUTER JOIN finvardetail
		  			ON F.idfin = finvardetail.idfin
					AND finvardetail.idupb = U.idupb 
				LEFT OUTER JOIN finvar
			  		ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
		  	  		AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
					AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
				WHERE  ((F.flag & 1 ) = 1) AND F.ayear = @ayear
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
			WHERE  (F.flag & 1 ) = 1 and F.ayear = @ayear
				AND (U.idupb like @idupb and U.active = 'S')
				AND (F.nlevel >=  @nlevel)
				AND NOT EXISTS (SELECT *
						  FROM #situation_fin
						  WHERE expenseyear.idupb = #situation_fin.idupb 
						   AND expenseyear.idfin =  #situation_fin.idfin)			
				AND expenseyear.ayear = @ayear
				AND ((expensetotal.flag & 1) = 1)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

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
			LEFT OUTER JOIN finvardetail
		  		ON F.idfin  = finvardetail.idfin
				AND finvardetail.idupb = U.idupb 
			LEFT OUTER JOIN finvar
		  		ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
	  	  		AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
				AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
			WHERE  ((F.flag & 1) = 1) and F.ayear = @ayear
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND (F.nlevel >=  @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag, ISNULL(U.assured,'N')
		END
	--END


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
			WHERE fin.idfin = #situation_fin.idfin
				AND finyear.idupb = #situation_fin.idupb 
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
			WHERE fin.idfin = #situation_fin.idfin
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
			WHERE expenseyear.idfin = #situation_fin.idfin 
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
			WHERE expensevar.adate <= @date 
				AND expenseyear.ayear = @ayear
				AND expense.nphase= @nfinphase
				AND ((expensetotal.flag&1)=0) -- Compenza
				AND expenseyear.idfin = #situation_fin.idfin 
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
			WHERE expense.adate <= @date 
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expensevar.adate <= @date 
				AND expense.nphase= @nfinphase
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND expenseyear.idfin = #situation_fin.idfin 
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
			WHERE expense.adate <= @date 
				AND ((expensetotal.flag&1)=0) -- Competenza
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expensevar.adate <= @date 
				AND expense.nphase= @nsecondphase
				AND ((expensetotal.flag&1)=0) -- Competenza
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expense.adate <= @date 
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expensevar.adate <= @date 
				AND expense.nphase= @nsecondphase
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expense.adate <= @date 
				AND ((expensetotal.flag&1)=0) -- Competenza
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expensevar.adate <= @date 
				AND expense.nphase= @nthirdphase
				AND ((expensetotal.flag&1)=0) -- Competenza
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expense.adate <= @date 
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND expenseyear.idfin  = #situation_fin.idfin 
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
			WHERE expensevar.adate <= @date 
				AND expense.nphase= @nthirdphase
				AND ((expensetotal.flag&1)=1) -- Residuo
				AND expenseyear.idfin  = #situation_fin.idfin 
				AND expenseyear.idupb = #situation_fin.idupb
				AND expensevar.yvar = @ayear), 0.0)

	UPDATE #situation_fin
	--  GESTIONE DEL FONDO ECONOMALE
		SET fin_ph_comp=   
			ISNULL(fin_ph_comp, 0.0) +
			ISNULL((SELECT SUM(operation.amount)
				FROM pettycashoperation operation
				WHERE operation.idfin = #situation_fin.idfin	
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
					WHERE operation.idfin = #situation_fin.idfin	
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
					WHERE operation.idfin = #situation_fin.idfin	
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
			WHERE  HPV.ymov = @ayear
				AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=0) -- Competenza 
				AND HPV.idfin  = #situation_fin.idfin
				AND HPV.idupb = #situation_fin.idupb), 0.0),
		max_ph_resid =	 
			ISNULL((SELECT SUM(HPV.amount)
			FROM historypaymentview HPV
			WHERE  HPV.ymov = @ayear
				AND HPV.competencydate <= @date
				AND ((HPV.totflag&1)=1) -- Residuo
				AND HPV.idfin  = #situation_fin.idfin
				AND HPV.idupb = #situation_fin.idupb), 0.0)
 
	SELECT  DISTINCT HPV.idexp, ISNULL(HPV.curramount,0) as curramount, fl1.newidfin as idfin , HPV.idupb
	INTO #tot_max_phase 
			FROM finlookup fl1 
				LEFT JOIN finlookup fl2 ON fl2.newidfin = fl1.oldidfin
				LEFT JOIN finlookup fl3 ON fl3.newidfin = fl2.oldidfin
				LEFT JOIN finlookup fl4 ON fl4.newidfin = fl3.oldidfin
				LEFT JOIN finlookup fl5 ON fl5.newidfin = fl4.oldidfin
				LEFT JOIN finlookup fl6 ON fl6.newidfin = fl5.oldidfin
				LEFT JOIN finlookup fl7 ON fl7.newidfin = fl6.oldidfin
				LEFT JOIN finlookup fl8 ON fl8.newidfin = fl7.oldidfin
				LEFT JOIN finlookup fl9 ON fl9.newidfin = fl8.oldidfin
				LEFT JOIN finlookup fl10 ON fl10.newidfin = fl9.oldidfin
				LEFT JOIN finlookup fl11 ON fl11.newidfin = fl10.oldidfin
				LEFT JOIN finlookup fl12 ON fl12.newidfin = fl11.oldidfin
				LEFT JOIN historypaymentview HPV ON HPV.idfin IN (fl1.newidfin,fl2.newidfin,fl3.newidfin,fl4.newidfin,fl5.newidfin,fl6.newidfin,fl7.newidfin,
				fl8.newidfin,fl9.newidfin,fl10.newidfin,fl11.newidfin,fl12.newidfin
				)
				WHERE  fl1.newidfin IN (select FU.idfin from finusable FU where FU.ayear = @ayear and ((FU.flag & 1 ) = 1)) and 
			HPV.ymov < @ayear 
				AND HPV.idexp is not null
				---AND HPV.idfin = #situation_fin.idfin
				AND  HPV.idupb like @idupb

				INSERT INTO #situation_fin (idfin,idupb)
				SELECT distinct idfin,idupb FROM #tot_max_phase WHERE idfin not in (SELECT idfin FROM #situation_fin) 
				-- provare a fare una select distinct per idfin e idupb e quadrare con l'esportazione da easy per trovare l'errore

	UPDATE #situation_fin
		SET		tot_max_ph =  ISNULL((SELECT SUM(curramount) FROM #tot_max_phase 
			WHERE #tot_max_phase.idfin = #situation_fin.idfin
			AND   #tot_max_phase.idupb = #situation_fin.idupb), 0.0)
	


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
				WHERE expensevar.yvar = @ayear
					AND expensevar.adate <= @date
					AND HPV.ymov = @ayear AND HPV.competencydate <= @date
					AND ((HPV.totflag&1)=0) -- Competenza
					AND HPV.idfin	  = #situation_fin.idfin
					AND HPV.idupb = #situation_fin.idupb), 0.0),

			var_max_ph_resid = 
				ISNULL((
				SELECT SUM(expensevar.amount)
				FROM expensevar
				JOIN historypaymentview HPV
					ON HPV.idexp = expensevar.idexp
				WHERE expensevar.yvar = @ayear
					AND HPV.ymov = @ayear AND HPV.competencydate <= @date
					AND ((HPV.totflag&1)=1) --Residuo  
					AND expensevar.adate <= @date
					AND HPV.idfin	  = #situation_fin.idfin
					AND HPV.idupb = #situation_fin.idupb), 0.0)
	END		



			UPDATE #situation_fin SET  upbprintingorder = upb.printingorder,
						upb = upb.title,
						codeupb = upb.codeupb
						FROM upb
						WHERE upb.idupb = #situation_fin.idupb


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
				isnull(var_max_ph_resid,0.0) =0 --AND (select nlevel from fin FFF where FFF.idfin= #situation_fin.idfin)>=2
				AND ISNULL(tot_max_ph,0) = 0)
	END

	SELECT DISTINCT  PB.idprogettotipocosto ,PB.idworkpackage,  PB.idprogetto ,PT.title, F.idfin, WU.idupb
	INTO #WorkBudget 
	FROM workpackageupb WU 
		LEFT JOIN progettotipocosto PT ON WU.idprogetto = PT.idprogetto 
		LEFT JOIN progettotipocostoaccmotive PTA ON WU.idprogetto = PTA.idprogetto  AND PTA.idprogettotipocosto = PT.idprogettotipocosto
		LEFT JOIN progettobudget PB ON PB.idprogetto = PT.idprogetto AND PB.idprogettotipocosto = PT.idprogettotipocosto AND PB.idworkpackage = WU.idworkpackage 
		LEFT JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  
		LEFT JOIN accmotivedetail ACD ON PTA.idaccmotive = ACD.idaccmotive 
		LEFT JOIN accountsorting ACS ON ACD.idacc = ACS.idacc  AND SUBSTRING(ACD.idacc,1,2) = SUBSTRING(CONVERT(varchar(4), @ayear),3,2)
		LEFT JOIN sorting S ON  ACS.idsor = S.idsor AND S.idsorkind = 27 -- Forse non serve
		LEFT JOIN finsorting FS ON S.idsor = FS.idsor 
		LEFT JOIN Fin F on F.idfin = FS.idfin and F.ayear = @ayear
		WHERE WU.idupb like  @idupb
			
 
	IF @VociCosto = 'N'
		SELECT 
			fin.codefin as 'Voce di Bilancio',
			fin.title as 'Descrizione Voce di Bilancio',
			#situation_fin.codeupb as 'Codice UPB',
			#situation_fin.upb as 'Descrizione UPB',
			SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
			SUM((ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0))-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0))) as 'Disp. Comp. provvisorio (fase1)' , --
			SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - (ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)))  as  'Disp. Comp. prenotazioni (fase2)',
			SUM((ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)) - (ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0))) as  'Disp. Comp. prenotazioni (fase3)',
			SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Pagato Competenza (fase4)',

			SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
			SUM((ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) - (ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0))) as  'Disp. ordine residui (fase3)',
			SUM(ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0)) as  'Pagato residui (fase4)',
			SUM(ISNULL(tot_max_ph,0)) as 'Totale pagato anni precedenti',
			SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato',
			ISNULL(W.title , 'Non mappato') as 'Voce di Budget'
			FROM #situation_fin 
			JOIN fin on #situation_fin.idfin = fin.idfin
			LEFT JOIN #WorkBudget W ON #situation_fin.idfin = W.idfin 
		
			GROUP BY  fin.codefin, #situation_fin.codeupb,#situation_fin.upb,fin.title,ISNULL(W.title , 'Non mappato') 
			UNION
			SELECT 
			'999999999',
			'Totale Uscite',
			#situation_fin.codeupb,
			#situation_fin.upb,
			SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
			SUM((ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0))-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0))) as 'Disp. Comp. provvisorio (fase1)' , --
			SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - (ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)))  as  'Disp. Comp. prenotazioni (fase2)',
			SUM((ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)) - (ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0))) as  'Disp. Comp. prenotazioni (fase3)',
			SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Pagato Competenza (fase4)',

			SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
			SUM((ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) - (ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0))) as  'Disp. ordine residui (fase3)',
			SUM(ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0)) as  'Pagato residui (fase4)',
			SUM(ISNULL(tot_max_ph,0)) as 'Totale pagato anni precedenti',
			SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato',
			''
			FROM #situation_fin 
			JOIN fin on #situation_fin.idfin = fin.idfin
			LEFT JOIN #WorkBudget W ON #situation_fin.idfin = W.idfin 
			GROUP BY   #situation_fin.codeupb,#situation_fin.upb
		ELSE
			BEGIN
				SELECT
				ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
				codeupb as 'Codice UPB',
				upb as 'Descrizione UPB',
				(SELECT ISNULL(budget,0) FROM progettobudget PB 
						WHERE PB.idprogetto = W.idprogetto 
						AND PB.idprogettotipocosto = W.idprogettotipocosto 
						AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
				ISNULL((SELECT SUM(ISNULL(PBV.amount,0)) FROM progettobudget PB 
						JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
						WHERE PB.idprogetto = W.idprogetto 
						AND PB.idprogettotipocosto = W.idprogettotipocosto 
						AND PB.idworkpackage = W.idworkpackage),0)	
						+
				ISNULL((SELECT SUM(ISNULL(budget,0)) FROM progettobudget PB 
						WHERE PB.idprogetto = W.idprogetto 
						AND PB.idprogettotipocosto = W.idprogettotipocosto
						AND PB.idworkpackage = W.idworkpackage),0)
						AS 'Budget  Corrente',
						SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
						SUM((ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0))-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0))) as 'Disp. Comp. provvisorio (fase1)' , --
						SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - (ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)))  as  'Disp. Comp. prenotazioni (fase2)',
						SUM((ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)) - (ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0))) as  'Disp. Comp. prenotazioni (fase3)',
						SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Pagato Competenza (fase4)',
						SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
						SUM((ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) - (ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0))) as  'Disp. ordine residui (fase3)',
						SUM(ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0)) as  'Pagato residui (fase4)',
						SUM(ISNULL(tot_max_ph,0)) as 'Totale pagato anni precedenti',
						SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato'
				FROM #situation_fin 
				LEFT JOIN  #WorkBudget W  ON #situation_fin.idfin = W.idfin 
				GROUP BY ISNULL(W.title , 'Non mappato') , codeupb, upb ,W.idprogetto, W.idprogettotipocosto, W.idworkpackage
				UNION 
				SELECT -- Visualizzo anche le voci di costo che non hanno relazione con il finanziario
					ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
					(SELECT upb.codeupb FROM upb 
							JOIN workpackageupb WU ON WU.idupb = upb.idupb 
					WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage) ,
					(SELECT upb.title FROM upb 
							JOIN workpackageupb WU ON WU.idupb = upb.idupb 
					WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage),
					(SELECT ISNULL(budget,0) FROM progettobudget PB 
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
					ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage),0) +
					ISNULL((SELECT SUM(ISNULL(PBV.amount,0)) FROM progettobudget PB 
							JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage),0)	
							AS 'Budget Corrente',
					0,0,0,0,0,0,0,0,0,0
					FROM  #WorkBudget W WHERE idfin is null and idprogettotipocosto NOT IN (SELECT idprogettotipocosto FROM #WorkBudget  W2
																									JOIN #situation_fin ON #situation_fin.idfin = W2.idfin WHERE W2.idfin is not null) 
					UNION
					SELECT 'Totale Uscite ','','', SUM(ISNULL([Budget Iniziale],0)) , SUM(ISNULL([Budget Corrente],0)) , SUM(ISNULL([Assegnazione competenza],0)) , 
						SUM(ISNULL([Disp. Comp. provvisorio (fase1)],0)) , SUM(ISNULL([Disp. Comp. prenotazioni (fase2)],0)) , SUM(ISNULL([Disp. Comp. prenotazioni (fase3)],0)) , 
						SUM(ISNULL([Pagato Competenza (fase4)],0)) , SUM(ISNULL([Totale residui],0)), SUM(ISNULL([Disp. ordine residui (fase3)],0)), SUM(ISNULL([Pagato residui (fase4)],0)) , 
						SUM(ISNULL([Totale pagato anni precedenti],0)) , SUM(ISNULL([Totale utilizzato],0))

						FROM (SELECT   -- ) A
								ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
								codeupb as 'Codice UPB',
								upb as 'Descrizione UPB',
								(SELECT ISNULL(budget,0) FROM progettobudget PB 
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
								ISNULL((SELECT SUM(ISNULL(PBV.amount,0)) FROM progettobudget PB 
										JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage),0)	
										+
								ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage),0)
										AS 'Budget Corrente',
										SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
										SUM((ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0))-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0))) as 'Disp. Comp. provvisorio (fase1)' , --
										SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - (ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)))  as  'Disp. Comp. prenotazioni (fase2)',
										SUM((ISNULL(third_ph_comp,0) + ISNULL(var_third_ph_comp,0)) - (ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0))) as  'Disp. Comp. prenotazioni (fase3)',
										SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Pagato Competenza (fase4)',
										SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
										SUM((ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) - (ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0))) as  'Disp. ordine residui (fase3)',
										SUM(ISNULL(max_ph_resid,0) + ISNULL(var_max_ph_resid,0)) as  'Pagato residui (fase4)',
										SUM(ISNULL(tot_max_ph,0)) as 'Totale pagato anni precedenti',
										SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(third_ph_resid,0) + ISNULL(var_third_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato'
								FROM #situation_fin 
								LEFT JOIN #WorkBudget W ON #situation_fin.idfin = W.idfin 
								GROUP BY ISNULL(W.title , 'Non mappato') , codeupb, upb ,W.idprogetto, W.idprogettotipocosto, W.idworkpackage
								UNION 
								SELECT -- Visualizzo anche le voci di costo che non hanno relazione con il finanziario
									ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
									(SELECT upb.codeupb FROM upb 
											JOIN workpackageupb WU ON WU.idupb = upb.idupb 
									WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage) ,
									(SELECT upb.title FROM upb 
											JOIN workpackageupb WU ON WU.idupb = upb.idupb 
									WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage),
									(SELECT ISNULL(budget,0) FROM progettobudget PB 
											WHERE PB.idprogetto = W.idprogetto 
											AND PB.idprogettotipocosto = W.idprogettotipocosto 
											AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
											ISNULL((SELECT SUM(ISNULL(PBV.amount,0)) FROM progettobudget PB 
													JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
													WHERE PB.idprogetto = W.idprogetto 
													AND PB.idprogettotipocosto = W.idprogettotipocosto 
													AND PB.idworkpackage = W.idworkpackage),0)	
													+
											ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
													WHERE PB.idprogetto = W.idprogetto 
													AND PB.idprogettotipocosto = W.idprogettotipocosto 
													AND PB.idworkpackage = W.idworkpackage),0)
													AS 'Budget Corrente',
									0,0,0,0,0,0,0,0,0,0
									FROM  #WorkBudget W WHERE idfin is null and idprogettotipocosto NOT IN (SELECT idprogettotipocosto FROM #WorkBudget  W2
																									JOIN #situation_fin ON #situation_fin.idfin = W2.idfin WHERE W2.idfin is not null)  
								) A
					
					ORDER BY 1
			END
	END
	--------------------------- FINE spese
ELSE
	BEGIN
		SELECT 	@nfinphase = incomefinphase FROM uniconfig
		SELECT  @nmaxphase = MAX(nphase) FROM incomephase
		SELECT  @nsecondphase = nphase FROM incomephase  WHERE nphase = @nfinphase + 1
		SELECT  @finphase=description FROM incomephase WHERE nphase = @nfinphase 
		SELECT  @secondphase=description FROM  incomephase WHERE nphase=@nsecondphase 
		SELECT  @max_phase=description  FROM incomephase WHERE nphase=@nmaxphase 

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
					LEFT OUTER JOIN finvardetail
		  				ON F.idfin = finvardetail.idfin
						AND finvardetail.idupb = U.idupb 
					LEFT OUTER JOIN finvar
			  			ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
		  	  			AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
						AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
					WHERE  ((F.flag & 1 ) = 0) AND F.ayear = @ayear
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
				FROM incomeyear
				JOIN upb U
					ON  incomeyear.idupb = U.idupb 
				JOIN fin F
					ON  incomeyear.idfin = F.idfin 
				JOIN incometotal 
					ON incometotal.idinc = incomeyear.idinc
					AND incometotal.ayear = incomeyear.ayear
				WHERE  (F.flag & 1 ) = 0 and F.ayear = @ayear
					AND (U.idupb like @idupb and U.active = 'S')
					AND (F.nlevel >=  @nlevel)
					AND NOT EXISTS (SELECT *
							  FROM #situation_fin
							  WHERE incomeyear.idupb = #situation_fin.idupb 
							   AND incomeyear.idfin =  #situation_fin.idfin)			
					AND incomeyear.ayear = @ayear
					AND ((incometotal.flag & 1) = 1)
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

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
				LEFT OUTER JOIN finvardetail
		  			ON F.idfin  = finvardetail.idfin
					AND finvardetail.idupb = U.idupb 
				LEFT OUTER JOIN finvar
		  			ON finvar.yvar = finvardetail.yvar  and finvar.yvar = @ayear	
	  	  			AND finvar.nvar = finvardetail.nvar and finvar.adate <= @date
					AND finvar.idfinvarstatus = 5 AND finvar.variationkind <> 5
				WHERE  ((F.flag & 1) = 0) and F.ayear = @ayear
					AND (U.idupb LIKE @idupb and U.active = 'S')
					AND (F.nlevel >=  @nlevel)
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag, ISNULL(U.assured,'N')
			END
		--END


		--UPDATE #situation_fin 
		--	SET main_initial_prevision = 
		--		ISNULL((
		--		SELECT SUM(finyear.prevision)
		--		from finyear 
		--		JOIN fin 
		--			ON finyear.idfin = fin.idfin  				
		--		JOIN upb
		--			ON finyear.idupb = upb.idupb 
		--		JOIN finlevel 
		--			ON finlevel.ayear = fin.ayear
		--			AND finlevel.nlevel = fin.nlevel
		--			AND (finlevel.flag&2)<>0
		--		JOIN finlast 
		--			ON finlast.idfin = fin.idfin
		--		WHERE fin.idfin = #situation_fin.idfin
		--			AND finyear.idupb = #situation_fin.idupb 
		--			AND fin.ayear = @ayear
		--			AND finyear.ayear = @ayear), 0.0)
		--UPDATE #situation_fin 
		--	SET sec_initial_prevision= 
		--		ISNULL((
		--		SELECT SUM(finyear.secondaryprev)
		--		FROM finyear 
		--		JOIN fin 
		--			ON finyear.idfin = fin.idfin 
		--		JOIN upb
		--			ON finyear.idupb = upb.idupb  
		--		JOIN finlevel 
		--			ON finlevel.ayear = fin.ayear
		--			AND finlevel.nlevel = fin.nlevel
		--			AND (finlevel.flag&2)<>0
		--		JOIN finlast 
		--			ON finlast.idfin = fin.idfin
		--		WHERE fin.idfin = #situation_fin.idfin
		--			AND finyear.idupb =  #situation_fin.idupb 
		--			AND finyear.ayear = @ayear
		--			), 0.0)
		UPDATE #situation_fin 
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
				WHERE incomeyear.idfin = #situation_fin.idfin 
					AND ((incometotal.flag&1)=0) -- Competenza
					AND incomeyear.idupb = #situation_fin.idupb
					AND income.adate <= @date 
					AND income.nphase = @nfinphase), 0.0),
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
				WHERE incomevar.adate <= @date 
					AND incomeyear.ayear = @ayear
					AND income.nphase= @nfinphase
					AND ((incometotal.flag&1)=0) -- Compenza
					AND incomeyear.idfin = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
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
				WHERE income.adate <= @date 
					AND ((incometotal.flag&1)=1) -- Residuo
					AND incomeyear.idfin  = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
					AND income.nphase = @nfinphase), 0.0),
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
				WHERE incomevar.adate <= @date 
					AND income.nphase= @nfinphase
					AND ((incometotal.flag&1)=1) -- Residuo
					AND incomeyear.idfin = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
					AND incomevar.yvar = @ayear), 0.0),
 			second_ph_comp = 
				ISNULL((
				SELECT SUM(incomeyear.amount)
				FROM income
				JOIN incomeyear
					ON incomeyear.idinc = income.idinc
					AND incomeyear.ayear = @ayear
				JOIN incometotal 
					ON incometotal.idinc = incomeyear.idinc
					AND incometotal.ayear = incomeyear.ayear
				WHERE income.adate <= @date 
					AND ((incometotal.flag&1)=0) -- Competenza
					AND incomeyear.idfin  = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
					AND income.nphase = @nsecondphase), 0.0),
			var_second_ph_comp =
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
				WHERE incomevar.adate <= @date 
					AND income.nphase= @nsecondphase
					AND ((incometotal.flag&1)=0) -- Competenza
					AND incomeyear.idfin  = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
					AND incomevar.yvar = @ayear), 0.0),
			second_ph_resid = 
				ISNULL((
				SELECT SUM(incomeyear.amount)
				FROM income
				JOIN incomeyear
					ON incomeyear.idinc = income.idinc
					AND incomeyear.ayear = @ayear
				JOIN incometotal 
					ON incometotal.idinc = incomeyear.idinc
					AND incometotal.ayear = incomeyear.ayear
				WHERE income.adate <= @date 
					AND ((incometotal.flag&1)=1) -- Residuo
					AND incomeyear.idfin  = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
					AND income.nphase = @nsecondphase), 0.0),
			var_second_ph_resid =
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
				WHERE incomevar.adate <= @date 
					AND income.nphase= @nsecondphase
					AND ((incometotal.flag&1)=1) -- Residuo
					AND incomeyear.idfin  = #situation_fin.idfin 
					AND incomeyear.idupb = #situation_fin.idupb
					AND incomevar.yvar = @ayear), 0.0)
				

		UPDATE #situation_fin
		--  GESTIONE DEL FONDO ECONOMALE
			SET fin_ph_comp=   
				ISNULL(fin_ph_comp, 0.0) +
				ISNULL((SELECT SUM(operation.amount)
					FROM pettycashoperation operation
					WHERE operation.idfin = #situation_fin.idfin	
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
						WHERE operation.idfin = #situation_fin.idfin	
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
				FROM historyproceedsview HPV
				WHERE  HPV.ymov = @ayear
					AND HPV.competencydate <= @date
					AND ((HPV.totflag&1)=0) -- Competenza 
					AND HPV.idfin  = #situation_fin.idfin
					AND HPV.idupb = #situation_fin.idupb), 0.0),
			max_ph_resid =	 
				ISNULL((SELECT SUM(HPV.amount)
				FROM historyproceedsview HPV
				WHERE  HPV.ymov = @ayear
					AND HPV.competencydate <= @date
					AND ((HPV.totflag&1)=1) -- Residuo
					AND HPV.idfin  = #situation_fin.idfin
					AND HPV.idupb = #situation_fin.idupb), 0.0)


	SELECT  DISTINCT HPV.idinc, ISNULL(HPV.curramount,0) as curramount, fl1.newidfin as idfin , HPV.idupb 
	INTO #tot_max_phaseE 
				FROM finlookup fl1 
				LEFT JOIN finlookup fl2 ON fl2.newidfin = fl1.oldidfin
				LEFT JOIN finlookup fl3 ON fl3.newidfin = fl2.oldidfin
				LEFT JOIN finlookup fl4 ON fl4.newidfin = fl3.oldidfin
				LEFT JOIN finlookup fl5 ON fl5.newidfin = fl4.oldidfin
				LEFT JOIN finlookup fl6 ON fl6.newidfin = fl5.oldidfin
				LEFT JOIN finlookup fl7 ON fl7.newidfin = fl6.oldidfin
				LEFT JOIN finlookup fl8 ON fl8.newidfin = fl7.oldidfin
				LEFT JOIN finlookup fl9 ON fl9.newidfin = fl8.oldidfin
				LEFT JOIN finlookup fl10 ON fl10.newidfin = fl9.oldidfin
				LEFT JOIN finlookup fl11 ON fl11.newidfin = fl10.oldidfin
				LEFT JOIN finlookup fl12 ON fl12.newidfin = fl11.oldidfin
				LEFT JOIN historyproceedsview HPV ON HPV.idfin IN (fl1.newidfin,fl2.newidfin,fl3.newidfin,fl4.newidfin,fl5.newidfin,fl6.newidfin,fl7.newidfin,
				fl8.newidfin,fl9.newidfin,fl10.newidfin,fl11.newidfin,fl12.newidfin
				)
 				WHERE  fl1.newidfin IN (select FU.idfin from finusable FU where FU.ayear = @ayear and ((FU.flag & 1 ) = 0)) and 
				HPV.ymov < @ayear 
					AND HPV.idinc is not null
					---AND HPV.idfin = #situation_fin.idfin
					AND  HPV.idupb like @idupb

					INSERT INTO #situation_fin (idfin,idupb)
					SELECT distinct idfin,idupb FROM #tot_max_phaseE WHERE idfin not in (SELECT idfin FROM #situation_fin) 
					-- provare a fare una select distinct per idfin e idupb e quadrare con l'esportazione da easy per trovare l'errore

		UPDATE #situation_fin
			SET		tot_max_ph =  ISNULL((SELECT SUM(curramount) FROM #tot_max_phaseE 
				WHERE #tot_max_phaseE.idfin = #situation_fin.idfin
				AND   #tot_max_phaseE.idupb = #situation_fin.idupb), 0.0)
	


		IF @cashvaliditykind <> 4
		BEGIN
			UPDATE #situation_fin
				SET	
				var_max_ph_comp = 
					ISNULL((
					SELECT SUM(incomevar.amount)
					FROM incomevar
					JOIN historyproceedsview HPV
						ON HPV.idinc = incomevar.idinc
					WHERE incomevar.yvar = @ayear
						AND incomevar.adate <= @date
						AND HPV.ymov = @ayear AND HPV.competencydate <= @date
						AND ((HPV.totflag&1)=0) -- Competenza
						AND HPV.idfin	  = #situation_fin.idfin
						AND HPV.idupb = #situation_fin.idupb), 0.0),

				var_max_ph_resid = 
					ISNULL((
					SELECT SUM(incomevar.amount)
					FROM incomevar
					JOIN historyproceedsview HPV
						ON HPV.idinc = incomevar.idinc
					WHERE incomevar.yvar = @ayear
						AND HPV.ymov = @ayear AND HPV.competencydate <= @date
						AND ((HPV.totflag&1)=1) --Residuo  
						AND incomevar.adate <= @date
						AND HPV.idfin	  = #situation_fin.idfin
						AND HPV.idupb = #situation_fin.idupb), 0.0)
		END		



				UPDATE #situation_fin SET  upbprintingorder = upb.printingorder,
							upb = upb.title,
							codeupb = upb.codeupb
							FROM upb
							WHERE upb.idupb = #situation_fin.idupb


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

		IF (@suppressifblank = 'S') AND @nlevel>=2	--> se la stampa è x categoria o x un livello sottostante la categoria cancella le righe
		BEGIN
			DELETE FROM #situation_fin WHERE 
					(
					--isnull(main_initial_prevision,0.0) =0 AND 
					--isnull(var_main_prevision,0.0) =0 AND 
					--isnull(sec_initial_prevision,0.0) =0 AND 
     --   				isnull(varprevsec,0.0) =0 AND 

					isnull(fin_ph_comp,0.0) =0 AND  
					isnull(var_fin_ph_comp,0.0) =0 AND 
					isnull(fin_ph_resid,0.0) =0 AND 
					isnull(var_fin_ph_resid,0.0) =0 AND 			

					isnull(second_ph_comp,0.0) =0 AND 
					isnull(var_second_ph_comp,0.0) =0 AND 
					isnull(second_ph_resid,0.0) =0 AND 
					isnull(var_second_ph_resid,0.0) =0 AND 

					isnull(max_ph_comp,0.0) =0 AND 
					isnull(var_max_ph_comp,0.0) =0 AND 
					isnull(max_ph_resid,0.0) =0 AND 
					isnull(var_max_ph_resid,0.0) =0 --AND (select nlevel from fin FFF where FFF.idfin= #situation_fin.idfin)>=2
					AND ISNULL(tot_max_ph,0) = 0)
		END
		-- select * from #situation_fin
		SELECT DISTINCT  PB.idprogettotipocosto ,PB.idworkpackage,  PB.idprogetto ,PT.title, F.idfin
		INTO #WorkBudgetE 
		FROM workpackageupb WU 
			LEFT JOIN progettotipocosto PT ON WU.idprogetto = PT.idprogetto 
			LEFT JOIN progettotipocostoaccmotive PTA ON WU.idprogetto = PTA.idprogetto  AND PTA.idprogettotipocosto = PT.idprogettotipocosto
			LEFT JOIN progettobudget PB ON PB.idprogetto = PT.idprogetto AND PB.idprogettotipocosto = PT.idprogettotipocosto AND PB.idworkpackage = WU.idworkpackage 
			LEFT JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  
			LEFT JOIN accmotivedetail ACD ON PTA.idaccmotive = ACD.idaccmotive 
			LEFT JOIN accountsorting ACS ON ACD.idacc = ACS.idacc  AND SUBSTRING(ACD.idacc,1,2) = SUBSTRING(CONVERT(varchar(4), @ayear),3,2)
			LEFT JOIN sorting S ON  ACS.idsor = S.idsor AND S.idsorkind = 27 -- Forse non serve
			LEFT JOIN finsorting FS ON S.idsor = FS.idsor 
			LEFT JOIN Fin F on F.idfin = FS.idfin and F.ayear = @ayear
			WHERE WU.idupb like  @idupb
			
		--select * from #tot_max_phaseE 
		IF @VociCosto = 'N'
			SELECT 
				fin.codefin,
				fin.title,
				#situation_fin.codeupb as 'Codice UPB',
				#situation_fin.upb,
				SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
				SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0) )) as 'Disp. Comp. provvisorio (fase1)' , --
				SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - ( ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0) ))  as  'Disp. Comp. definitivo (fase2)',
				SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Incassato Competenza (fase3)',

				SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
				SUM((ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) - (ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0))) as  'Disp. definitivo residui (fase2)',
				SUM(ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0)) as  'Incassato residui (fase3)',
				SUM(ISNULL(tot_max_ph,0)) as 'Totale incassato anni precedenti',
				SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato',
				ISNULL(W.title , 'Non mappato') as 'Voce di Budget'
				FROM #situation_fin 
				JOIN fin on #situation_fin.idfin = fin.idfin
				LEFT JOIN #WorkBudgetE W ON #situation_fin.idfin = W.idfin 
				GROUP BY  fin.codefin, #situation_fin.codeupb,#situation_fin.upb,fin.title,ISNULL(W.title , 'Non mappato') 

				UNION
			SELECT 
				'999999999',
				'Totale Entrate',
				#situation_fin.codeupb,
				#situation_fin.upb,
				SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
				SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0) )) as 'Disp. Comp. provvisorio (fase1)' , --
				SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - ( ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0) ))  as  'Disp. Comp. definitivo (fase2)',
				SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Incassato Competenza (fase3)',

				SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
				SUM((ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) - (ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0))) as  'Disp. definitivo residui (fase2)',
				SUM(ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0)) as  'Incassato residui (fase3)',
				SUM(ISNULL(tot_max_ph,0)) as 'Totale incassato anni precedenti',
				SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato',
				''
				FROM #situation_fin 
				JOIN fin on #situation_fin.idfin = fin.idfin
				LEFT JOIN #WorkBudgetE W ON #situation_fin.idfin = W.idfin 
				GROUP BY #situation_fin.codeupb,#situation_fin.upb 
				ORDER BY fin.codefin, fin.title, #situation_fin.codeupb
			ELSE
				BEGIN
					SELECT
					ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
					codeupb as 'Codice UPB',
					upb as 'Descrizione UPB',
					(SELECT ISNULL(budget,0) FROM progettobudget PB 
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
					ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage),0) +
					ISNULL((SELECT ISNULL(PBV.amount,0) FROM progettobudget PB 
							JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage),0)	
							AS 'Budget Corrente',
							SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
							SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0) )) as 'Disp. Comp. provvisorio (fase1)' , --
							SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - ( ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0) ))  as  'Disp. Comp. definitivo (fase2)',
							SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Incassato Competenza (fase3)',

							SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
							SUM((ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) - (ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0))) as  'Disp. definitivo residui (fase2)',
							SUM(ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0)) as  'Incassato residui (fase3)',
							SUM(ISNULL(tot_max_ph,0)) as 'Totale incassato anni precedenti',
							SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato'
					FROM #situation_fin 
					LEFT JOIN #WorkBudgetE W ON #situation_fin.idfin = W.idfin 
					GROUP BY ISNULL(W.title , 'Non mappato') , codeupb, upb ,W.idprogetto, W.idprogettotipocosto, W.idworkpackage

				UNION 
				SELECT -- Visualizzo anche le voci di costo che non hanno relazione con il finanziario
					ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
					(SELECT upb.codeupb FROM upb 
							JOIN workpackageupb WU ON WU.idupb = upb.idupb 
					WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage) ,
					(SELECT upb.title FROM upb 
							JOIN workpackageupb WU ON WU.idupb = upb.idupb 
					WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage),
					(SELECT ISNULL(budget,0) FROM progettobudget PB 
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
					ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage),0) +
					ISNULL((SELECT ISNULL(PBV.amount,0) FROM progettobudget PB 
							JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
							WHERE PB.idprogetto = W.idprogetto 
							AND PB.idprogettotipocosto = W.idprogettotipocosto 
							AND PB.idworkpackage = W.idworkpackage),0)	
							AS 'Budget Corrente',
					0,0,0,0,0,0,0,0,0
					FROM  #WorkBudgetE W WHERE W.idfin is null and idprogettotipocosto NOT IN (SELECT idprogettotipocosto FROM #WorkBudgetE  W2
																									JOIN #situation_fin ON #situation_fin.idfin = W2.idfin WHERE W2.idfin is not null) 

					UNION
					SELECT 'Totale Entrate ','','', SUM(ISNULL([Budget Iniziale],0)) , SUM(ISNULL([Budget Corrente],0)) , SUM(ISNULL([Assegnazione competenza],0)) , 
						SUM(ISNULL([Disp. Comp. provvisorio (fase1)],0)) , SUM(ISNULL([Disp. Comp. definitivo (fase2)],0)) , SUM(ISNULL([Incassato Competenza (fase3)],0)) , 
						SUM(ISNULL([Totale residui],0)) , SUM(ISNULL([Disp. definitivo residui (fase2)],0)), SUM(ISNULL([Incassato residui (fase3)],0)), SUM(ISNULL([Totale incassato anni precedenti],0)) , 
						SUM(ISNULL([Totale utilizzato],0))

						FROM (
								SELECT
								ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
								codeupb as 'Codice UPB',
								upb as 'Descrizione UPB',
								(SELECT ISNULL(budget,0) FROM progettobudget PB 
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
								ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage),0) +
								ISNULL((SELECT ISNULL(PBV.amount,0) FROM progettobudget PB 
										JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage),0)	
										AS 'Budget Corrente',
										SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) as 'Assegnazione competenza', -- Questo è vero se non c'è previsione ancora da portare in fase 1
										SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)-(ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0) )) as 'Disp. Comp. provvisorio (fase1)' , --
										SUM((ISNULL(second_ph_comp,0) + ISNULL(var_second_ph_comp,0)) - ( ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0) ))  as  'Disp. Comp. definitivo (fase2)',
										SUM(ISNULL(max_ph_comp,0) + ISNULL(var_max_ph_comp,0)) as  'Incassato Competenza (fase3)',

										SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) as 'Totale residui', -- Questo è vero se tutti i residui sono in fase 3
										SUM((ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) - (ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0))) as  'Disp. definitivo residui (fase2)',
										SUM(ISNULL(max_ph_resid,0) - ISNULL(var_max_ph_resid,0)) as  'Incassato residui (fase3)',
										SUM(ISNULL(tot_max_ph,0)) as 'Totale incassato anni precedenti',
										SUM(ISNULL(fin_ph_comp,0)+ISNULL(var_fin_ph_comp,0)) + SUM(ISNULL(second_ph_resid,0) + ISNULL(var_second_ph_resid,0)) + SUM(ISNULL(tot_max_ph,0)) as 'Totale utilizzato'
								FROM #situation_fin 
								LEFT JOIN #WorkBudgetE W ON #situation_fin.idfin = W.idfin 
								GROUP BY ISNULL(W.title , 'Non mappato') , codeupb, upb ,W.idprogetto, W.idprogettotipocosto, W.idworkpackage

							UNION 
							SELECT -- Visualizzo anche le voci di costo che non hanno relazione con il finanziario
								ISNULL(W.title , 'Non mappato') as 'Voce di Budget',
								(SELECT upb.codeupb FROM upb 
										JOIN workpackageupb WU ON WU.idupb = upb.idupb 
								WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage) ,
								(SELECT upb.title FROM upb 
										JOIN workpackageupb WU ON WU.idupb = upb.idupb 
								WHERE WU.idprogetto = W.idprogetto AND WU.idworkpackage = W.idworkpackage),
								(SELECT ISNULL(budget,0) FROM progettobudget PB 
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage) as 'Budget Iniziale',
								ISNULL((SELECT ISNULL(budget,0) FROM progettobudget PB 
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage),0) +
								ISNULL((SELECT ISNULL(PBV.amount,0) FROM progettobudget PB 
										JOIN progettobudgetvariazione PBV ON PB.idprogetto = PBV.idprogetto AND PB.idprogettobudget = PBV.idprogettobudget  -- Attenzione non sto considerando PBV.idupb
										WHERE PB.idprogetto = W.idprogetto 
										AND PB.idprogettotipocosto = W.idprogettotipocosto 
										AND PB.idworkpackage = W.idworkpackage),0)	
										AS 'Budget Corrente',
								0,0,0,0,0,0,0,0,0
								FROM  #WorkBudgetE W WHERE idfin is null and idprogettotipocosto NOT IN (SELECT idprogettotipocosto FROM #WorkBudgetE  W2
																									JOIN #situation_fin ON #situation_fin.idfin = W2.idfin WHERE W2.idfin is not null) 

							 ) A
					
					ORDER BY 1
				END
	END
END

	GO

	SET QUOTED_IDENTIFIER OFF 
	GO
	SET ANSI_NULLS ON 
	GO

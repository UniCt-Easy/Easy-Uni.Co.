
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancioarticoli_respons_operation_2fasi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancioarticoli_respons_operation_2fasi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_sitbilancioarticoli_respons_operation_2fasi]
	@ayear			int,
	@nlevel			tinyint,
	@hierarchy		char(1),
	@idman			int,
	@suppressifblank 	char(1),
	@codefin		varchar(50),
	@start 			datetime,
	@stop 			datetime

AS
BEGIN
/* Versione 1.0.6 del 27/11/2007 ultima modifica: MARIA */
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
				and (fin.flag&1)=1) --Spesa
	END
CREATE TABLE #fin_situation
(
	idfin			int,
	codefin			varchar(50),
	title			varchar(150),
	finprintingorder	varchar(50),
	nlevel			tinyint,
	main_initial_prevision	decimal(19,2),
	var_main_prevision	decimal(19,2),
	fin_phase_comp		decimal(19,2),
	var_fin_phase_comp	decimal(19,2),
	desc_fin_phase 		varchar(50),					
	max_phase_comp         	decimal(19,2),
	var_max_phase_comp     	decimal(19,2),
	desc_max_phase 		varchar(50),					
	sec_initial_prevision	decimal(19,2),
	varprevsec		decimal(19,2),
	fin_phase_resid		decimal(19,2),
	var_fin_phase_resid	decimal(19,2),
	max_phase_resid         decimal(19,2),
	var_max_phase_resid     decimal(19,2),
	assign_credit 		decimal(19,2),
	var_assign_credit	decimal(19,2),
	assign_cash		decimal(19,2),
	var_assign_cash		decimal(19,2),
	previsionkind 		char(1),
	secprevisionkind 	char(1),
	flag_assign_credit 	char(1),
	flag_assign_cash 	char(1),
	idman			int,
	manager			varchar(150)						
)
IF @ayear IS NULL 
BEGIN
	SELECT 		
		idfin, 
		NULL as idfinlevel0, NULL as idfinlevel1, NULL as idfinlevel2,
		NULL as idfinlevel3, NULL as idfinlevel4, NULL as idfinlevel5,
		NULL as idfinlevel6, NULL as idfinlevel7, NULL as idfinlevel8,
		NULL as idfinlevel9, codefin, title, finprintingorder,	
		nlevel, main_initial_prevision, var_main_prevision,
		fin_phase_comp, var_fin_phase_comp, desc_fin_phase,
		max_phase_comp, var_max_phase_comp,
		desc_max_phase,	sec_initial_prevision, varprevsec,
		fin_phase_resid, var_fin_phase_resid, max_phase_resid,
		var_max_phase_resid,assign_credit, var_assign_credit, assign_cash,
		var_assign_cash, previsionkind, secprevisionkind,
		flag_assign_credit, flag_assign_cash, idman, manager	 
	FROM    #fin_situation 
	RETURN
END

DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
IF (@nlevel < @level_input ) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

DECLARE @fin_phase     tinyint
SELECT  @fin_phase = appropriationphasecode
FROM    config
WHERE   ayear = @ayear

IF 	@fin_phase IS NULL
BEGIN
	SELECT @fin_phase = expensefinphase FROM uniconfig
END

DECLARE @desc_fin_phase    	varchar(50)
SELECT 	@desc_fin_phase=description
FROM 	expensephase WHERE nphase=@fin_phase 

DECLARE @max_phase          	tinyint
SELECT  @max_phase = MAX(nphase)
FROM 	expensephase

DECLARE @desc_max_phase    	varchar(50)
SELECT  @desc_max_phase=description 
FROM 	expensephase WHERE nphase=@max_phase 

DECLARE @cashvaliditykind       int
SELECT 	@cashvaliditykind = cashvaliditykind
FROM 	config WHERE ayear = @ayear

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
		
IF(@suppressifblank = 'S')
BEGIN
	INSERT INTO #fin_situation
		(
		idfin, 
		idman
		)
	SELECT  DISTINCT
		fin.idfin,
		finlast.idman
		FROM fin
		JOIN finlink
			ON  finlink.idparent = fin.idfin
		JOIN finlink FL
			ON  FL.idchild = fin.idfin AND FL.nlevel = fin.nlevel
		JOIN finlast
			ON finlink.idchild = finlast.idfin
		WHERE  ((fin.flag&1)=1) -- Spesa
			AND ((finlast.idman = @idman) OR (@idman is null and finlast.idman is not null))	
			AND fin.ayear = @ayear 
			AND (@idfin IS NULL OR FL.idparent = @idfin)
			AND ((@hierarchy ='N' and fin.nlevel = @nlevel) OR (@hierarchy ='S' and fin.nlevel >=  @nlevel))
			AND EXISTS (select idfin from upbtotal where idfin = fin.idfin) 	
			
	-- prende le voci di bilancio che hanno solo i residui
	INSERT INTO #fin_situation
		(
		idfin, 
		idman
		)
	SELECT  DISTINCT
		fin.idfin,
		finlast.idman
	FROM    fin	
		JOIN finlink
			ON  finlink.idparent = fin.idfin
		JOIN finlink FL
			ON  FL.idchild = fin.idfin
		JOIN finlast
			ON  finlink.idchild = finlast.idfin 
		JOIN expenseyear
			ON expenseyear.idfin = fin.idfin
		JOIN expensetotal
			ON  expenseyear.idexp = expensetotal.idexp
			AND expenseyear.ayear = expensetotal.ayear
	WHERE ((fin.flag&1)=1) -- Spesa
		AND ((finlast.idman = @idman) OR  (@idman is null and finlast.idman is not null))	
		AND fin.ayear = @ayear
		AND (@idfin IS NULL 
		OR  (FL.idparent = @idfin and @idfin is not null))
		AND ((@hierarchy ='N' and fin.nlevel = @nlevel) OR (@hierarchy ='S' and fin.nlevel >=  @nlevel))
		AND   expenseyear.ayear = @ayear 
		AND ((expensetotal.flag&1)=1)
		AND NOT EXISTS (SELECT *
				FROM  #fin_situation
				WHERE finlink.idparent = #fin_situation.idfin)
END
ELSE
BEGIN
	INSERT INTO #fin_situation
	(
		idfin, 
		idman
	)
	SELECT DISTINCT
		fin.idfin,
		finlast.idman
	FROM fin 
	JOIN finlink
		ON  finlink.idparent = fin.idfin
	JOIN finlink FL
		ON  FL.idchild = fin.idfin and FL.nlevel = fin.nlevel
	JOIN finlast
		ON  finlink.idchild = finlast.idfin 
	WHERE  ((fin.flag&1)=1) -- Spesa
		AND ((finlast.idman = @idman) OR  (@idman is null and finlast.idman is not null))	
		AND fin.ayear = @ayear 
		AND (@idfin IS NULL 
		OR  (FL.idparent = @idfin and @idfin is not null))
		AND ((@hierarchy ='N' and fin.nlevel = @nlevel) OR (@hierarchy ='S' and fin.nlevel >=  @nlevel))
END
-------------------------------------------------------------------------------		

UPDATE #fin_situation
	SET  main_initial_prevision =
		ISNULL((SELECT SUM(finyear.prevision)
			FROM finyear
			JOIN fin 
				ON finyear.idfin = fin.idfin
			JOIN finlast
				ON  finlast.idfin  = fin.idfin 
			JOIN finlink
				ON  finlink.idchild = fin.idfin   
				AND finlink.idparent = #fin_situation.idfin
			WHERE finlast.idman = #fin_situation.idman
			      AND fin.ayear = @ayear
			      AND finyear.ayear = @ayear), 0.0),
	var_main_prevision  =   
		ISNULL((SELECT SUM(finvardetail.amount) 
			FROM finvardetail
			JOIN finvar
				ON finvardetail.yvar = finvar.yvar 
				AND finvardetail.nvar = finvar.nvar
			JOIN finlast
				ON  finlast.idfin  = finvardetail.idfin 
			JOIN finlink
				ON  finlink.idchild = finvardetail.idfin   
				AND finlink.idparent = #fin_situation.idfin
			WHERE finlast.idman = #fin_situation.idman
			      AND finvar.idfinvarstatus = 5
			      AND finvar.yvar = @ayear		
			      AND finvar.flagprevision ='S'	
			      AND finvar.variationkind <> 5
			      AND finvar.adate between @start and @stop), 0.0),
	sec_initial_prevision = 	
		ISNULL((SELECT SUM(finyear.secondaryprev)
			FROM finyear
			JOIN finlast
				ON  finlast.idfin  = finyear.idfin 
			JOIN finlink
				ON  finlink.idchild = finyear.idfin   
				AND finlink.idparent = #fin_situation.idfin
			WHERE  finlast.idman = #fin_situation.idman
				AND finyear.ayear = @ayear), 0.0),
	varprevsec =
		ISNULL((SELECT SUM(finvardetail.amount) 
			FROM finvardetail
			JOIN finvar
				ON finvardetail.yvar = finvar.yvar 
				AND finvardetail.nvar = finvar.nvar
			JOIN finlast
				ON  finlast.idfin  = finvardetail.idfin 
			JOIN finlink
				ON  finlink.idchild = finvardetail.idfin
				AND finlink.idparent = #fin_situation.idfin
			WHERE finlast.idman = #fin_situation.idman	
			      AND finvar.idfinvarstatus = 5
			      AND finvar.yvar = @ayear 
			      AND finvar.flagsecondaryprev = 'S'
			      AND finvar.variationkind <> 5
			      AND finvar.adate between @start and @stop), 0.0)
UPDATE #fin_situation
	SET 
	fin_phase_comp = 
				ISNULL((SELECT SUM(expenseyear.amount)
			FROM expense
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp
			JOIN expensetotal
				ON expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear
			JOIN finlast
				ON finlast.idfin = expenseyear.idfin 
			JOIN finlink
				ON finlink.idchild = expenseyear.idfin   
				AND finlink.idparent  = #fin_situation.idfin
			WHERE expense.adate between @start and @stop 
				AND expense.nphase = @fin_phase
				AND finlast.idman = #fin_situation.idman
				AND expenseyear.ayear = @ayear
				AND ((expensetotal.flag&1) = 0) -- Competenza
				), 0.0),
	var_fin_phase_comp =
				ISNULL((SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
			JOIN expense
				ON expenseyear.idexp = expense.idexp
			JOIN expensetotal
				ON  expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear
			JOIN finlast
				ON  finlast.idfin  = expenseyear.idfin 
			JOIN finlink
				ON  finlink.idchild = expenseyear.idfin   
				AND finlink.idparent = #fin_situation.idfin
			WHERE expensevar.adate between @start and @stop 
				AND expenseyear.ayear = @ayear
				AND expense.nphase= @fin_phase
				AND ((expensetotal.flag&1) = 0) -- Competenza
				AND finlast.idman = #fin_situation.idman
				AND expensevar.yvar = @ayear), 0.0),
	 fin_phase_resid = 
				ISNULL((SELECT SUM(expenseyear.amount)
			FROM expense
			JOIN expenseyear
				ON expenseyear.idexp = expense.idexp
			JOIN expensetotal
				ON  expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear
			JOIN finlast
				ON  finlast.idfin  = expenseyear.idfin 
			JOIN finlink
				ON  finlink.idchild = expenseyear.idfin   
				AND finlink.idparent = #fin_situation.idfin
			WHERE expense.adate between @start and @stop
				AND expenseyear.ayear = @ayear
				AND finlast.idman = #fin_situation.idman
				AND ((expensetotal.flag&1) = 1) -- Residuo
				AND expense.nphase = @fin_phase), 0.0),
	var_fin_phase_resid =
		ISNULL((SELECT SUM(expensevar.amount)
			FROM expensevar
			JOIN expenseyear
				ON expenseyear.idexp = expensevar.idexp
			JOIN expense
				ON expenseyear.idexp = expense.idexp
			JOIN expensetotal
				ON  expenseyear.idexp = expensetotal.idexp
				AND expenseyear.ayear = expensetotal.ayear
			JOIN finlast
				ON  finlast.idfin  = expenseyear.idfin 
			JOIN finlink
				ON  finlink.idchild = expenseyear.idfin   
			WHERE expensevar.adate between @start and @stop 
			     	AND expenseyear.ayear = @ayear
				AND expense.nphase= @fin_phase
				AND ((expensetotal.flag&1) = 1) -- Residuo
				AND finlink.idparent = #fin_situation.idfin
				AND finlast.idman = #fin_situation.idman
				AND expensevar.yvar = @ayear), 0.0)

--  GESTIONE DEL FONDO ECONOMALE 
UPDATE #fin_situation
	SET fin_phase_comp = 
		ISNULL(fin_phase_comp, 0.0) +
		ISNULL((SELECT SUM(operation.amount)
			FROM pettycashoperation operation
			JOIN finlast
				ON  finlast.idfin  = operation.idfin 
			JOIN finlink
				ON  finlink.idchild = operation.idfin   
			WHERE 	finlink.idparent = #fin_situation.idfin
				AND finlast.idman = #fin_situation.idman
				AND operation.adate between @start and @stop 
				AND operation.yoperation = @ayear
				AND NOT EXISTS (SELECT * FROM pettycashoperation  
						WHERE pettycashoperation.idpettycash = operation.idpettycash
						AND pettycashoperation.yoperation = operation.yrestore
						AND pettycashoperation.noperation = operation.nrestore
						AND pettycashoperation.adate between @start and @stop
						AND pettycashoperation.yoperation = @ayear)), 0.0)
UPDATE #fin_situation
	SET max_phase_comp=	 
		ISNULL((SELECT SUM(HPV.amount)
			FROM historypaymentview HPV
			JOIN finlast
				ON  finlast.idfin  = HPV.idfin 
			JOIN finlink
				ON  finlink.idchild = HPV.idfin   
				AND finlink.idparent = #fin_situation.idfin
			WHERE HPV.ymov = @ayear
				AND HPV.competencydate between @start and @stop
				AND ((HPV.totflag&1) = 0) -- Competenza
				AND finlast.idman = #fin_situation.idman
				), 0.0),
	   max_phase_resid=	 
			ISNULL((SELECT SUM(HPV.amount)
				FROM historypaymentview HPV
				JOIN finlast
					ON  finlast.idfin  = HPV.idfin 
				JOIN finlink
					ON  finlink.idchild = HPV.idfin   
					AND finlink.idparent = #fin_situation.idfin
				WHERE  HPV.ymov = @ayear
					AND finlast.idman = #fin_situation.idman
					AND HPV.competencydate between @start and @stop
					AND ((HPV.totflag&1) = 1) -- Residuo
					), 0.0)

IF @cashvaliditykind <> 4
BEGIN
	UPDATE #fin_situation
		SET  var_max_phase_comp= 
			ISNULL((SELECT SUM(expensevar.amount)
				FROM expensevar
				JOIN historypaymentview HPV
					ON HPV.idexp = expensevar.idexp
					AND HPV.ymov = @ayear 
				JOIN finlast
					ON  finlast.idfin  = HPV.idfin 
				JOIN finlink
					ON  finlink.idchild = HPV.idfin   
					AND finlink.idparent    = #fin_situation.idfin
				WHERE 	 finlast.idman = #fin_situation.idman
					AND expensevar.yvar = @ayear
					AND ((HPV.totflag&1) = 0) -- Competenza
					AND HPV.ymov = @ayear
					AND HPV.competencydate between @start and @stop
					AND expensevar.adate between @start and @stop), 0.0),
		var_max_phase_resid= 
			ISNULL((SELECT SUM(expensevar.amount)
				FROM expensevar
				JOIN historypaymentview HPV
					ON HPV.idexp = expensevar.idexp 
				JOIN finlast
					ON  finlast.idfin  = HPV.idfin 
				JOIN finlink
					ON  finlink.idchild = HPV.idfin  
					AND finlink.idparent = #fin_situation.idfin
				WHERE expensevar.yvar = @ayear
				    	AND finlast.idman = #fin_situation.idman
					AND finlink.idparent = #fin_situation.idfin
					AND ((HPV.totflag&1) = 1) -- Residuo
					AND HPV.ymov = @ayear
					AND HPV.competencydate between @start and @stop
					AND expensevar.adate between @start and @stop), 0.0)
END
-- Controlla che i CREDITI  siano gestiti
IF 	(EXISTS(SELECT* FROM creditpart
		WHERE ycreditpart = @ayear AND adate between @start and @stop) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagcredit ='S' and yvar = @ayear
		AND adate between @start and @stop
		AND finvar.idfinvarstatus = 5)
	)
BEGIN
	UPDATE #fin_situation
	SET var_assign_credit = 
		isnull((select SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v 
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagcredit ='S'
			JOIN finlast
				ON  finlast.idfin  = d.idfin 
			JOIN finlink
				ON  finlink.idchild = d.idfin   
			where 	finlink.idparent = #fin_situation.idfin
				AND finvar.idfinvarstatus = 5
				AND finlast.idman = #fin_situation.idman	
				AND v.adate between @start and @stop
				AND v.variationkind IN (2)),0.0),
	  assign_credit = 	
		isnull((select SUM(creditpart.amount)
			FROM creditpart 
			JOIN incomeyear
				on creditpart.idinc = incomeyear.idinc
				and creditpart.ycreditpart = incomeyear.ayear
			JOIN finlast
				ON  finlast.idfin  = creditpart.idfin 
			JOIN finlink
				ON  finlink.idchild = creditpart.idfin   
			where 	finlink.idparent = #fin_situation.idfin
				AND finlast.idman = #fin_situation.idman
				AND adate between @start and @stop),0.0)
		+	
		isnull((select SUM(d.amount)
			FROM finvardetail d
			JOIN finvar v
				ON v.yvar = d.yvar
				AND v.nvar = d.nvar
				AND v.flagcredit ='S'
			JOIN finlast
				ON  finlast.idfin  = d.idfin 
			JOIN finlink
				ON  finlink.idchild = d.idfin   
			where 	finlink.idparent = #fin_situation.idfin
				AND finvar.idfinvarstatus = 5
				AND finlast.idman = #fin_situation.idman
				AND v.adate between @start and @stop
				AND v.variationkind IN (1,3,4)),0.0),
	flag_assign_credit='S'
END
ELSE
	UPDATE #fin_situation SET flag_assign_credit='N'
-- Controlla che gli max_phase siano gestiti
IF 	(EXISTS(SELECT* FROM proceedspart 
		WHERE yproceedspart	= @ayear
		AND adate between @start and @stop) 
	OR
	EXISTS (SELECT * FROM finvar
		WHERE flagproceeds='S' and 
		yvar = @ayear AND 
		adate between @start and @stop
		AND finvar.idfinvarstatus = 5)
	)
	BEGIN
	UPDATE #fin_situation
		SET var_assign_cash = 
			isnull(( select SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN finlast
					ON  finlast.idfin  = d.idfin 
				JOIN finlink
					ON  finlink.idchild = d.idfin   
				where finlink.idparent = #fin_situation.idfin
					AND v.idfinvarstatus = 5
					AND finlast.idman = #fin_situation.idman
					AND v.flagproceeds='S'
					AND v.adate between @start and @stop
					AND v.variationkind IN (2)),0.0),
		assign_cash = 
			isnull(( select SUM(proceedspart.amount)
				FROM proceedspart
				JOIN incomeyear
					on proceedspart.idinc = incomeyear.idinc
					and proceedspart.yproceedspart = incomeyear.ayear
				JOIN finlast
					ON  finlast.idfin  = proceedspart.idfin 
				JOIN finlink
					ON  finlink.idchild = proceedspart.idfin  
				where finlink.idparent = #fin_situation.idfin
					AND finlast.idman = #fin_situation.idman
					AND adate between @start and @stop),0.0)
			+
			isnull((SELECT  SUM(d.amount)
				FROM finvardetail d
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				JOIN finlast
					ON  finlast.idfin  = d.idfin 
				JOIN finlink
					ON  finlink.idchild = d.idfin  
				where finlink.idparent = #fin_situation.idfin
					AND v.idfinvarstatus = 5
					AND finlast.idman = #fin_situation.idman
					AND v.flagproceeds='S'
					AND v.adate between @start and @stop
					AND v.variationkind IN (1,3,4)),0.0),
		flag_assign_cash='S'
	END
ELSE
	UPDATE #fin_situation SET flag_assign_cash='N'


--> cancella le righe sottostanti la categoria 
IF (@suppressifblank = 'S') 	
BEGIN
	DELETE FROM #fin_situation 
	WHERE 
		(isnull(main_initial_prevision,0.0) =0 AND 
		isnull(var_main_prevision,0.0) =0 AND 
		isnull(fin_phase_comp,0.0) =0 AND 
		isnull(var_fin_phase_comp,0.0) =0 AND 
		isnull(max_phase_comp,0.0) =0 AND 
		isnull(var_max_phase_comp,0.0) =0 AND 
		isnull(sec_initial_prevision,0.0) =0 AND 
		isnull(varprevsec,0.0) =0 AND 
		isnull(fin_phase_resid,0.0) =0 AND 
		isnull(var_fin_phase_resid,0.0) =0 AND 
		isnull(max_phase_resid,0.0) =0 AND 
		isnull(var_max_phase_resid,0.0) =0 AND 
		isnull(assign_credit,0.0) =0 AND 
		isnull(var_assign_credit,0.0) =0 AND 
		isnull(assign_cash,0.0) =0 AND 
		isnull(var_assign_cash,0.0) =0 
		AND nlevel >=2)
END


SELECT 
	#fin_situation.idfin,	
	fin.codefin,	
	fin.title,	
	fin.printingorder as finprintingorder,	
	fin.nlevel,		
	sum(isnull(main_initial_prevision,0.0)) as 'main_initial_prevision',
	sum(isnull(var_main_prevision,0.0)) 	as 'var_main_prevision'	,
	sum(isnull(fin_phase_comp,0.0)) 	as 'fin_phase_comp',
	sum(isnull(var_fin_phase_comp,0.0)) 	as 'var_fin_phase_comp',
	@desc_fin_phase 			as'desc_fin_phase',					
	sum(isnull(max_phase_comp,0.0)) 	as 'max_phase_comp',
	sum(isnull(var_max_phase_comp,0.0)) 	as 'var_max_phase_comp',
	@desc_max_phase 			as 'desc_max_phase',					
	sum(isnull(sec_initial_prevision,0.0)) 	as 'sec_initial_prevision',
	sum(isnull(varprevsec,0.0)) 		as 'varprevsec',
	sum(isnull(fin_phase_resid,0.0)) 	as 'fin_phase_resid',
	sum(isnull(var_fin_phase_resid,0.0)) 	as 'var_fin_phase_resid',
	sum(isnull(max_phase_resid,0.0)) 	as 'max_phase_resid' ,
	sum(isnull(var_max_phase_resid,0.0)) 	as 'var_max_phase_resid' ,
	sum(isnull(assign_credit,0.0)) 		as 'assign_credit',
	sum(isnull(var_assign_credit,0.0)) 	as 'var_assign_credit' ,
	sum(isnull(assign_cash,0.0)) 		as 'assign_cash'	 ,
	sum(isnull(var_assign_cash,0.0)) 	as 'var_assign_cash'	 ,
	@previsionkind 				as 'previsionkind',
	@secprevisionkind 			as 'secprevisionkind',
	flag_assign_credit,
	flag_assign_cash,
	#fin_situation.idman,
	manager.title as manager	
 	FROM #fin_situation
	JOIN fin ON fin.idfin = #fin_situation.idfin
	JOIN manager ON manager.idman = #fin_situation.idman
	GROUP BY #fin_situation.idfin,fin.codefin,	
	fin.title,fin.printingorder,fin.nlevel,flag_assign_credit,flag_assign_cash,#fin_situation.idman,manager.title		
	ORDER BY #fin_situation.idman,fin.printingorder

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


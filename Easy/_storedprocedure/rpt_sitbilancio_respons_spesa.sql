
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_respons_spesa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_respons_spesa]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*	
exec rpt_sitbilancio_respons_spesa 2013, 3, 'S', null, '0001005300010008', 'S', 'N', 'S', null,{ts '1900-12-31 00:00:00'},{ts '2013-12-31 00:00:00'}, null,null,null,null,null	

exec rpt_sitbilancio_respons_spesa 2013, 3, 'S', 35, '0001005300010012', 'S', 'N', 'S', null,{ts '1900-12-31 00:00:00'},{ts '2013-12-31 00:00:00'}, null,null,null,null,null	
*/





CREATE  PROCEDURE [rpt_sitbilancio_respons_spesa]
	@ayear			int,
	@nlevel			tinyint,
	@hierarchy		char(1),
	@idman			int,
	@idupb			varchar(36),
	@showupb 		char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@codefin		varchar(50),
	@start 			datetime,
	@stop 			datetime,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 

AS
BEGIN

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
				and (flag&1)=1) -- Spesa
	END
CREATE TABLE #fin_situation
(
	idupb 				varchar(36),
	assured				char(1),
	idfin				int,
	nlevel				tinyint,
	main_initial_prevision		decimal(19,2),
	var_main_prevision		decimal(19,2),
	fin_phase_comp			decimal(19,2),
	var_fin_phase_comp		decimal(19,2), 
	desc_fin_phase 			varchar(50),					
	registry_phase_comp		decimal(19,2),
	var_registry_phase_comp		decimal(19,2),
	desc_registry_phase 		varchar(50),					
	max_phase_comp       		decimal(19,2),
	var_max_phase_comp     	 	decimal(19,2),
	desc_max_phase 			varchar(50),					
	sec_initial_prevision		decimal(19,2),
	varprevsec			decimal(19,2),
	fin_phase_resid			decimal(19,2), 
	var_fin_phase_resid		decimal(19,2),
	registry_phase_resid		decimal(19,2),
	var_registry_phase_resid	decimal(19,2),
	max_phase_resid         	decimal(19,2),
	var_max_phase_resid          	decimal(19,2),
	assign_credit 			decimal(19,2),
	var_assign_credit		decimal(19,2),
	assign_cash			decimal(19,2),
	var_assign_cash			decimal(19,2),
	previsionkind 			char(1),
	secprevisionkind 		char(1),
	flag_assign_credit 		char(1),
	flag_assign_cash 		char(1),
	idman				int,
	flagconsider char(1)
)


DECLARE @idupboriginal 		varchar(36)
SET 	@idupboriginal= @idupb
IF 	@showchildupb = 'S' set @idupb=@idupb+'%' 

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

DECLARE @fin_phase   		tinyint -- accantonamento precedente alla fase di impegno
SELECT  @fin_phase = expensefinphase FROM uniconfig

DECLARE @desc_fin_phase     	varchar(50)
SELECT  @desc_fin_phase=description
	FROM 	expensephase WHERE nphase=@fin_phase 

DECLARE @registry_phase   tinyint
SELECT  @registry_phase = expenseregphase FROM uniconfig

DECLARE @desc_registry_phase    varchar(50)
SELECT 	@desc_registry_phase=description
FROM 	expensephase WHERE nphase=@registry_phase 

DECLARE @max_phase          	tinyint
SELECT  @max_phase = MAX(nphase) FROM expensephase

DECLARE @desc_max_phase    	varchar(50)
SELECT  @desc_max_phase=description 
FROM 	expensephase WHERE nphase=@max_phase 

DECLARE @flag_cs     		char(1)
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
IF (@nlevel < @level_input) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	main_initial_prevision,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE ((F.flag&1)<>0) -- Spesa
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
GROUP BY U.idman,isnull(@fixedidupb, U.idupb), F.idfin, F.nlevel, ISNULL(U.assured,'N')
	


INSERT INTO #fin_situation(
	idfin,nlevel,
	idupb,
	assured,
	idman,
	var_main_prevision,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE ((F.flag&1)=1) -- Spesa
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
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	sec_initial_prevision,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(finyear.secondaryprev),
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
	ON finyear.idupb = U.idupb
JOIN fin F
	ON finyear.idfin = F.idfin
--JOIN finlast
--	ON  F.idfin = finlast.idfin
JOIN finlink FLK
	ON FLK.idchild = F.idfin and FLK.nlevel=@level_input
WHERE ((F.flag&1)=1) -- Spesa
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
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.nlevel,  F.idfin,ISNULL(U.assured,'N')
	
INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	varprevsec,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE ((F.flag&1)=1) -- Spesa
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
	AND finvar.flagsecondaryprev ='S'	
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND finvar.adate between @start and @stop	
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.nlevel,  F.idfin,ISNULL(U.assured,'N')


INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	fin_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expenseyear.amount),
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expense.adate between @start and @stop 
	AND expense.nphase = @fin_phase
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (U.idupb like @idupb)
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	var_fin_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expensevar.amount),
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expensevar
	ON expenseyear.idexp = expensevar.idexp
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb	
WHERE expensevar.adate between @start and @stop 
	AND expense.nphase = @fin_phase
	AND expensevar.yvar = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')
	



INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	fin_phase_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expenseyear.amount) ,
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expense.adate between @start and @stop 
	AND expense.nphase = @fin_phase
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	var_fin_phase_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expensevar.amount),
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expensevar
	ON expenseyear.idexp = expensevar.idexp
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expensevar.adate between @start and @stop 
	AND expense.nphase = @fin_phase
	AND expensevar.yvar = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')
	

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	registry_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expenseyear.amount),
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expense.adate between @start and @stop 
	AND expense.nphase = @registry_phase
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')


INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	var_registry_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expensevar.amount) ,
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expensevar
	ON expenseyear.idexp = expensevar.idexp
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expensevar.adate between @start and @stop 
	AND expense.nphase = @registry_phase
	AND expensevar.yvar = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	registry_phase_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expenseyear.amount) ,
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expense.adate between @start and @stop 
	AND expense.nphase = @registry_phase
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	var_registry_phase_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(expensevar.amount) ,
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
JOIN expenseyear
	ON ISNULL(FLK2.idchild,F.idfin) = expenseyear.idfin
	AND expenseyear.ayear = @ayear
JOIN expensevar
	ON expenseyear.idexp = expensevar.idexp
JOIN expense
	ON expenseyear.idexp = expense.idexp
JOIN expensetotal
	ON  expenseyear.idexp = expensetotal.idexp
	AND expenseyear.ayear = expensetotal.ayear
JOIN upb U 
	ON expenseyear.idupb = U.idupb
WHERE expensevar.adate between @start and @stop 
	AND expense.nphase = @registry_phase
	AND expensevar.yvar = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
	GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')


-- GESTIONE FONDO ECONOMALE	
INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	fin_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(operation.amount) ,
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
JOIN pettycashoperation operation
	ON ISNULL(FLK2.idchild,F.idfin) = operation.idfin
JOIN upb U 
	ON operation.idupb = U.idupb
WHERE  operation.adate between @start and @stop 
	AND operation.yoperation = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND NOT EXISTS (SELECT * FROM pettycashoperation  
		WHERE pettycashoperation.idpettycash = operation.idpettycash
		AND pettycashoperation.yoperation = operation.yrestore
		AND pettycashoperation.noperation = operation.nrestore
		AND pettycashoperation.adate between @start and @stop
		AND pettycashoperation.yoperation = @ayear)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')
		
INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	registry_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(operation.amount) ,
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
JOIN pettycashoperation operation
	ON ISNULL(FLK2.idchild,F.idfin) = operation.idfin
JOIN upb U 
	ON operation.idupb = U.idupb
WHERE  operation.adate between @start and @stop 
	AND operation.yoperation = @ayear
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND NOT EXISTS (SELECT * FROM pettycashoperation  
		WHERE pettycashoperation.idpettycash = operation.idpettycash
		AND pettycashoperation.yoperation = operation.yrestore
		AND pettycashoperation.noperation = operation.nrestore
		AND pettycashoperation.adate between @start and @stop
		AND pettycashoperation.yoperation = @ayear)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	max_phase_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	U.idman,
	SUM(HPV.amount) ,
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
JOIN historypaymentview HPV
	ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
JOIN upb U 
	ON HPV.idupb = U.idupb
WHERE  HPV.ymov = @ayear
	AND HPV.competencydate between @start and @stop
	AND ((HPV.totflag&1) = 0) -- Competenza
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (U.idupb like @idupb) 
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assured,
	idman,
	max_phase_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
JOIN historypaymentview HPV
	ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
JOIN upb U 
	ON HPV.idupb = U.idupb
WHERE  HPV.ymov = @ayear
	AND HPV.competencydate between @start and @stop
	AND ((HPV.totflag&1) <> 0) -- R
	AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
	AND (U.idupb like @idupb)
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

IF @cashvaliditykind <> 4
BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,
				assured,
				idman,
				var_max_phase_comp,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				isnull(@fixedidupb, U.idupb),
				ISNULL(U.assured,'N'),
				U.idman,
				SUM(expensevar.amount) ,
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
			JOIN historypaymentview HPV
				ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
			JOIN expensevar
				ON HPV.idexp = expensevar.idexp
			JOIN upb U 
				ON HPV.idupb = U.idupb
			WHERE expensevar.yvar = @ayear
				AND HPV.ymov = @ayear
				AND ((HPV.totflag&1) = 0) -- Competenza
				AND HPV.competencydate between @start and @stop
				AND expensevar.adate between @start and @stop
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb)
				AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')
			
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,
				assured,
				idman,
				var_max_phase_resid,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				isnull(@fixedidupb, U.idupb),
				ISNULL(U.assured,'N'),
				U.idman,
				SUM(expensevar.amount),
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
			JOIN historypaymentview HPV
				ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
			JOIN expensevar
				ON HPV.idexp = expensevar.idexp
			JOIN upb U 
				ON HPV.idupb = U.idupb
			WHERE expensevar.yvar = @ayear
				AND HPV.ymov = @ayear
				AND ((HPV.totflag&1) <> 0) -- R
				AND HPV.competencydate between @start and @stop
				AND expensevar.adate between @start and @stop
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb)
				AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')				
					
					
END
		
-- Controlla che i CREDITI  siano gestiti
DECLARE @Crediti char(1)
SET @Crediti = 'N'
IF 	(EXISTS(SELECT* FROM creditpart WHERE ycreditpart = @ayear AND adate between @start and @stop) 
	OR
	EXISTS (SELECT * FROM finvar WHERE flagcredit ='S' and yvar = @ayear AND adate between @start and @stop AND finvar.idfinvarstatus = 5)
	)
BEGIN
		INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			assured,
			idman,
			var_assign_credit,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE ((F.flag&1)=1) -- Spesa
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			AND (U.idupb like @idupb)
			AND finvar.yvar = @ayear
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND finvar.yvar = @ayear		
			AND finvar.flagcredit ='S'	
			AND finvar.idfinvarstatus = 5
			AND finvar.variationkind IN (2)
			AND finvar.adate between @start and @stop
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')	
		
		INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			assured,
			idman,
			assign_credit,
				flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
			U.idman,
			SUM(creditpart.amount),
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
		JOIN creditpart
			ON ISNULL(FLK2.idchild,F.idfin) = creditpart.idfin
		JOIN incomeyear
			ON creditpart.idinc = incomeyear.idinc
			AND creditpart.ycreditpart = incomeyear.ayear
		JOIN upb U 
			ON creditpart.idupb = U.idupb
		WHERE creditpart.adate between @start and @stop 
			AND incomeyear.ayear = @ayear
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((F.flag&1) <>0)
			AND (U.idupb like @idupb)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')	
	
		INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			assured,
			idman,
			assign_credit,
				flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
			U.idman,
			SUM(d.amount),
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
		JOIN finvardetail d
			ON ISNULL(FLK2.idchild,F.idfin) = d.idfin
		JOIN finvar v
  			ON v.yvar = d.yvar  
  			AND v.nvar = d.nvar 
		JOIN upb U 
			ON d.idupb = U.idupb
		WHERE v.adate between @start and @stop 
			AND v.yvar = @ayear
			AND ((F.flag&1)<>0)
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			AND (U.idupb like @idupb)
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND v.idfinvarstatus = 5
			AND v.flagcredit ='S'
			AND v.variationkind IN (1,3,4)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')

	SET @Crediti = 'S'
	
END
ELSE
Begin
   
	 SET @Crediti = 'N' 		
End	       

-- Controlla che gli INCASSI siano gestiti

DECLARE @Incassi char(1)
SET @Incassi = 'N'

IF 	(EXISTS(SELECT* FROM proceedspart WHERE yproceedspart = @ayear AND adate between @start and @stop) 
	OR
	EXISTS (SELECT * FROM finvar WHERE flagproceeds='S' and yvar = @ayear AND adate between @start and @stop AND finvar.idfinvarstatus = 5)
	)
	BEGIN
		INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			assured,
			idman,
			var_assign_cash,
				flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE ((F.flag&1)=1) -- Spesa
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
			AND finvar.flagproceeds ='S'	
			AND finvar.idfinvarstatus = 5
			AND finvar.variationkind IN (2)
			AND finvar.adate between @start and @stop
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')	
		
		INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			assured,
			idman,
			assign_cash,
				flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
			U.idman,
			SUM(proceedspart.amount),
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
		JOIN proceedspart
			ON ISNULL(FLK2.idchild,F.idfin) = proceedspart.idfin
		JOIN incomeyear
			ON proceedspart.idinc = incomeyear.idinc
			AND proceedspart.yproceedspart = incomeyear.ayear
		JOIN upb U 
			ON proceedspart.idupb = U.idupb
		WHERE proceedspart.adate between @start and @stop 
			AND incomeyear.ayear = @ayear
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			AND (U.idupb like @idupb)
			AND ((F.flag&1)<>0 )
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')
		
		INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			assured,
			idman,
			assign_cash,
				flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
			U.idman,
			SUM(d.amount),
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
		JOIN finvardetail d
			ON ISNULL(FLK2.idchild,F.idfin) = d.idfin
		JOIN finvar v
  			ON v.yvar = d.yvar  
  			AND v.nvar = d.nvar 
		JOIN upb U 
			ON d.idupb = U.idupb
		WHERE v.adate between @start and @stop 
			AND v.yvar = @ayear
			AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((F.flag&1)<>0)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (U.idupb like @idupb)
			AND v.idfinvarstatus = 5
			AND v.flagproceeds ='S'
			AND v.variationkind IN (1,3,4)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY U.idman,isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')
				
		SET @Incassi = 'S'
	END
ELSE
Begin
  
	SET @Incassi = 'N'		
End       

--	--	--	--	--	-- Aggiunge le voci inutilizzate se @suppressifblank = N --	--	--	--	--	--	



--> Se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
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
begin
	--> @showupb ='S'
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,idman,
				assured,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				U.idupb,U.idman,
				ISNULL(U.assured,'N'),
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
			GROUP BY U.idman,U.idupb,F.idfin,F.nlevel,F.ayear,F.flag, ISNULL(U.assured,'N')
		END
	ELSE
		BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,idman,
				assured,
				flagconsider
				)
			SELECT 
				F.idfin, F.nlevel,
				U.idupb,U.idman,
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
				AND ((U.idman = @idman) OR (@idman is null and U.idman is not null))	
				AND (F.nlevel = @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idman,U.idupb, F.idfin,F.nlevel,ISNULL(U.assured,'N')
		END
end
END

 DELETE FROM #fin_situation WHERE flagconsider='N'



IF (@suppressifblank = 'S') --> cancella le righe sottostanti la categoria 
BEGIN
	DELETE FROM #fin_situation 
	WHERE 
		(isnull(main_initial_prevision,0.0) =0 AND 
		isnull(var_main_prevision,0.0) =0 AND 
		isnull(registry_phase_comp,0.0) =0 AND 
		isnull(var_registry_phase_comp,0.0) =0 AND 
		isnull(max_phase_comp,0.0) =0 AND 
		isnull(var_max_phase_comp,0.0) =0 AND 
		isnull(sec_initial_prevision,0.0) =0 AND 
		isnull(varprevsec,0.0) =0 AND 
		isnull(registry_phase_resid,0.0) =0 AND 
		isnull(var_registry_phase_resid,0.0) =0 AND 
		isnull(max_phase_resid,0.0) =0 AND 
		isnull(var_max_phase_resid,0.0) =0 AND 
		isnull(assign_credit,0.0) =0 AND 
		isnull(var_assign_credit,0.0) =0 AND 
		isnull(assign_cash,0.0) =0 AND 
		isnull(var_assign_cash,0.0) =0 AND
		isnull(fin_phase_comp,0.0) =0 AND  
		isnull(var_fin_phase_comp,0.0) =0 AND 
		isnull(fin_phase_resid,0.0) =0 AND 
		isnull(var_fin_phase_resid,0.0) =0 AND 			
		nlevel >=2)--nlevel <>0
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
		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,	
		null AS 'idfinlevel0',
		fl1.idparent AS 'idfinlevel1',
		fl2.idparent AS 'idfinlevel2',
		fl3.idparent AS 'idfinlevel3',
		fl4.idparent AS 'idfinlevel4',
		fl5.idparent AS 'idfinlevel5',
		NULL AS 'idfinlevel6',
		NULL AS 'idfinlevel7',
		NULL AS 'idfinlevel8',
		NULL AS 'idfinlevel9',
		fin.codefin,	
		fin.title,	
		fin.printingorder as finprintingorder,	
		#fin_situation.nlevel,	
		sum(isnull(main_initial_prevision,0.0)) 	 'main_initial_prevision',
		sum(isnull(var_main_prevision,0.0)) 		 'var_main_prevision',
		sum(isnull(fin_phase_comp,0.0)) 		 'fin_phase_comp',
		sum(isnull(var_fin_phase_comp,0.0)) 		 'var_fin_phase_comp', 
		@desc_fin_phase 				 'desc_fin_phase',	
		sum(isnull(registry_phase_comp,0.0)) 		 'registry_phase_comp',
		sum(isnull(var_registry_phase_comp,0.0)) 	 'var_registry_phase_comp',
		@desc_registry_phase 				 'desc_registry_phase',		
		sum(isnull(max_phase_comp,0.0)) 		 'max_phase_comp',
		sum(isnull(var_max_phase_comp,0.0)) 		 'var_max_phase_comp',
		@desc_max_phase 				 'desc_max_phase' 	,					
		sum(isnull(sec_initial_prevision,0.0)) 		 'sec_initial_prevision',
		sum(isnull(varprevsec,0.0)) 			 'varprevsec',
		sum(isnull(fin_phase_resid,0.0)) 		 'fin_phase_resid', 
		sum(isnull(var_fin_phase_resid,0.0)) 		 'var_fin_phase_resid',
		sum(isnull(registry_phase_resid,0.0)) 		 'registry_phase_resid'   ,
		sum(isnull(var_registry_phase_resid,0.0)) 	 'var_registry_phase_resid',
		sum(isnull(max_phase_resid,0.0)) 		 'max_phase_resid',
		sum(isnull(var_max_phase_resid,0.0)) 		 'var_max_phase_resid',
		sum(isnull(assign_credit,0.0)) 			 'assign_credit',
		sum(isnull(var_assign_credit,0.0)) 		 'var_assign_credit',
		sum(isnull(assign_cash,0.0)) 			 'assign_cash' ,
		sum(isnull(var_assign_cash,0.0)) 		 'var_assign_cash' ,
		@previsionkind 					 'previsionkind',
		@secprevisionkind 				 'secprevisionkind',
		@Crediti as flag_assign_credit,
		@Incassi as	flag_assign_cash,
		#fin_situation.idman,
		manager.title as manager	
		FROM #fin_situation
		JOIN fin 
			ON #fin_situation.idfin = fin.idfin	
		JOIN manager
			ON	#fin_situation.idman = manager.idman
		left outer join finlink fl1 on fl1.idchild=#fin_situation.idfin and fl1.nlevel=1
		left outer join finlink fl2 on fl2.idchild=#fin_situation.idfin and fl2.nlevel=2
		left outer join finlink fl3 on fl3.idchild=#fin_situation.idfin and fl3.nlevel=3
		left outer join finlink fl4 on fl4.idchild=#fin_situation.idfin and fl4.nlevel=4
		left outer join finlink fl5 on fl5.idchild=#fin_situation.idfin and fl5.nlevel=5
		GROUP BY #fin_situation.idfin, fin.codefin,	
		fin.title,fin.printingorder,#fin_situation.nlevel,flag_assign_credit,flag_assign_cash,#fin_situation.idman,manager.title,
		fl1.idparent, fl2.idparent, fl3.idparent, fl4.idparent, fl5.idparent 
		ORDER BY #fin_situation.idman,finprintingorder
END
ELSE
BEGIN
	SELECT 
		#fin_situation.idfin,	
		upb.codeupb,
		#fin_situation.idupb,
		upb.title as upb,
		upb.printingorder as upbprintingorder,
		null AS 'idfinlevel0',
		fl1.idparent AS 'idfinlevel1',
		fl2.idparent AS 'idfinlevel2',
		fl3.idparent AS 'idfinlevel3',
		fl4.idparent AS 'idfinlevel4',
		fl5.idparent AS 'idfinlevel5',
		NULL AS 'idfinlevel6',
		NULL AS 'idfinlevel7',
		NULL AS 'idfinlevel8',
		NULL AS 'idfinlevel9',
		fin.codefin,	
		fin.title,	
		fin.printingorder as finprintingorder,	
		#fin_situation.nlevel,	
		sum(isnull(main_initial_prevision,0.0)) 	 'main_initial_prevision',
		sum(isnull(var_main_prevision,0.0)) 		 'var_main_prevision',
		sum(isnull(fin_phase_comp,0.0)) 		 'fin_phase_comp',
		sum(isnull(var_fin_phase_comp,0.0)) 		 'var_fin_phase_comp', 
		@desc_fin_phase 				 'desc_fin_phase',	
		sum(isnull(registry_phase_comp,0.0)) 		 'registry_phase_comp',
		sum(isnull(var_registry_phase_comp,0.0)) 	 'var_registry_phase_comp',
		@desc_registry_phase 				 'desc_registry_phase',		
		sum(isnull(max_phase_comp,0.0)) 		 'max_phase_comp',
		sum(isnull(var_max_phase_comp,0.0)) 		 'var_max_phase_comp',
		@desc_max_phase 				 'desc_max_phase' 	,					
		sum(isnull(sec_initial_prevision,0.0)) 		 'sec_initial_prevision',
		sum(isnull(varprevsec,0.0)) 			 'varprevsec',
		sum(isnull(fin_phase_resid,0.0)) 		 'fin_phase_resid', 
		sum(isnull(var_fin_phase_resid,0.0)) 		 'var_fin_phase_resid',
		sum(isnull(registry_phase_resid,0.0)) 		 'registry_phase_resid'   ,
		sum(isnull(var_registry_phase_resid,0.0)) 	 'var_registry_phase_resid',
		sum(isnull(max_phase_resid,0.0)) 		 'max_phase_resid',
		sum(isnull(var_max_phase_resid,0.0)) 		 'var_max_phase_resid',
		sum(isnull(assign_credit,0.0)) 			 'assign_credit',
		sum(isnull(var_assign_credit,0.0)) 		 'var_assign_credit',
		sum(isnull(assign_cash,0.0)) 			 'assign_cash' ,
		sum(isnull(var_assign_cash,0.0)) 		 'var_assign_cash' ,
		@previsionkind 			 'previsionkind',
		@secprevisionkind 		 'secprevisionkind',
		case when ((upb.assured is not null) and upb.assured ='S') then 'N'
				else @Crediti
		End as flag_assign_credit,
		case when ((upb.assured is not null) and upb.assured ='S')  then 'N'
				else @Incassi
		End as	flag_assign_cash,
		upb.idman,
		manager.title as manager
FROM #fin_situation 
JOIN fin 
	ON #fin_situation.idfin = fin.idfin	
JOIN upb 
	ON #fin_situation.idupb = upb.idupb
JOIN manager 
	ON upb.idman = manager.idman
left outer join finlink fl1 on fl1.idchild=#fin_situation.idfin and fl1.nlevel=1
left outer join finlink fl2 on fl2.idchild=#fin_situation.idfin and fl2.nlevel=2
left outer join finlink fl3 on fl3.idchild=#fin_situation.idfin and fl3.nlevel=3
left outer join finlink fl4 on fl4.idchild=#fin_situation.idfin and fl4.nlevel=4
left outer join finlink fl5 on fl5.idchild=#fin_situation.idfin and fl5.nlevel=5
GROUP BY upb.idman,#fin_situation.idupb,upb.codeupb, 
		upb.title,upb.printingorder,
		#fin_situation.idfin, fin.codefin,	
			fin.title,fin.printingorder,#fin_situation.nlevel,flag_assign_credit,flag_assign_cash, manager.title,
			fl1.idparent, fl2.idparent, fl3.idparent, fl4.idparent, fl5.idparent, upb.assured

ORDER BY upb.idman, upb.printingorder,fin.printingorder
END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO









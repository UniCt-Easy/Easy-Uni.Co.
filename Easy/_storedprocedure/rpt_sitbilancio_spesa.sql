if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_spesa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_spesa]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/* 

exec rpt_sitbilancio_spesa 2013, {ts '2013-12-31 00:00:00'}, 3, 'S', '%', 'N', 'N', 'S',2007, null,null,null,null,null
*/

CREATE  PROCEDURE [rpt_sitbilancio_spesa]
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

INSERT INTO #situation_fin(
	idfin,
	nlevel,
	idupb,
	assured,
	main_initial_prevision,
	flagconsider
)
SELECT 
	F.idfin, 
	F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
JOIN upb  U
	ON  finyear.idupb = U.idupb
JOIN fin F
	ON finyear.idfin = F.idfin
--JOIN finlast
--	ON  F.idfin = finlast.idfin
JOIN finlink FLK
	ON FLK.idchild = F.idfin and FLK.nlevel=@level_input
WHERE ((F.flag&1)<>0) -- Spesa
	AND (finyear.ayear = @ayear)
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb LIKE @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb), F.idfin, F.nlevel,ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin,
	nlevel,
	idupb,
	assured,
	var_main_prevision,
	flagconsider
)

SELECT 
	F.idfin, 
	F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE ((F.flag&1)<>0 ) -- Spesa
	AND finvar.yvar = @ayear		
	AND (U.idupb like @idupb and U.active = 'S')
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND (@idfin IS NULL OR isnull(FLK.idparent, F.idfin) = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND finvar.flagprevision ='S'	
	AND finvar.idfinvarstatus = 5
	AND finvar.variationkind <> 5
	AND finvar.adate <= @date
GROUP BY isnull(@fixedidupb, U.idupb), F.idfin,F.nlevel, ISNULL(U.assured,'N')


INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	sec_initial_prevision,
	flagconsider
)
SELECT 
	fin.idfin, fin.nlevel,
	isnull(@fixedidupb, upb.idupb),
	ISNULL(upb.assured,'N'),
	SUM(finyear.secondaryprev),
	CASE 
		 WHEN (@hierarchy ='N') Then 'S' 
		 WHEN ( @hierarchy='S' 
				and fin.nlevel >= @levelusable 
				and fin.idfin IN (SELECT idfin FROM finlast))
			THEN 'S'
		 ELSE 'N'
	END
FROM finyear
JOIN upb 
	ON finyear.idupb = upb.idupb
JOIN fin
	ON finyear.idfin = fin.idfin
--JOIN finlast
--	ON  fin.idfin = finlast.idfin
JOIN finlink
	ON finlink.idchild = fin.idfin and finlink.nlevel=@level_input
WHERE ((fin.flag&1)<>0) -- Spesa
	AND (finyear.ayear = @ayear)
	AND (@idfin IS NULL OR finlink.idparent = @idfin)
    AND (upb.idupb like @idupb and upb.active = 'S')
	AND ((@hierarchy ='N' AND fin.nlevel = @nlevel) OR (@hierarchy ='S' and fin.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, upb.idupb),fin.idfin,  fin.nlevel,ISNULL(upb.assured,'N')
				

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	varprevsec,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	SUM(finvardetail.amount) ,
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
	AND (U.idupb like @idupb and U.active = 'S')
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
	AND finvar.adate <= @date
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')


INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	fin_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expense.adate <= @date
	AND expense.nphase = @fin_phase
	AND (U.idupb like @idupb and U.active = 'S')
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	var_fin_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expensevar.adate <= @date
	AND expense.nphase = @fin_phase
	AND expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')
	

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	fin_ph_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expense.adate <= @date
	AND expense.nphase = @fin_phase
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	var_fin_ph_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expensevar.adate<= @date
	AND expense.nphase = @fin_phase
	AND expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')
	

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	registry_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expense.adate <= @date
	AND expense.nphase = @registry_phase
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')


INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	var_registry_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expensevar.adate <= @date
	AND expense.nphase = @registry_phase
	AND expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)= 0) -- Competenza
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	registry_ph_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expense.adate <= @date
	AND expense.nphase = @registry_phase
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	var_registry_ph_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
WHERE expensevar.adate <= @date
	AND expense.nphase = @registry_phase
	AND expensevar.yvar = @ayear
	AND ((expensetotal.flag&1)<> 0) -- R
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
	GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')


-- GESTIONE FONDO ECONOMALE	
INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	fin_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	SUM(operation.amount),
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
WHERE  operation.adate <= @date
	AND operation.yoperation = @ayear
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
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
		AND pettycashoperation.adate <= @date
		AND pettycashoperation.yoperation = @ayear)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')
		
INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	registry_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
	SUM(operation.amount),
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
WHERE  operation.adate <= @date
	AND operation.yoperation = @ayear
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb and U.active = 'S')
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
		AND pettycashoperation.adate <= @date
		AND pettycashoperation.yoperation = @ayear)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	max_ph_comp,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
	AND HPV.competencydate <= @date
	AND ((HPV.totflag&1) = 0) -- Competenza
	AND (U.idupb like @idupb and U.active = 'S') 
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

INSERT INTO #situation_fin(
	idfin, nlevel,
	idupb,
	assured,
	max_ph_resid,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
	ISNULL(U.assured,'N'),
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
	AND HPV.competencydate <= @date
	AND ((HPV.totflag&1) <> 0) -- R
	AND (U.idupb like @idupb and U.active = 'S')
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')

IF @cashvaliditykind <> 4
BEGIN
			INSERT INTO #situation_fin(
				idfin, nlevel,
				idupb,
				assured,
				var_max_ph_comp,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				isnull(@fixedidupb, U.idupb),
				ISNULL(U.assured,'N'),
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
				AND HPV.competencydate <= @date
				AND expensevar.adate <= @date
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb and U.active = 'S')
				AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')
			
			INSERT INTO #situation_fin(
				idfin, nlevel,
				idupb,
				assured,
				var_max_ph_resid,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				isnull(@fixedidupb, U.idupb),
				ISNULL(U.assured,'N'),
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
				AND HPV.competencydate <= @date
				AND expensevar.adate <= @date
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb and U.active = 'S')
				AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')				
					
					
END
		
-- Controlla che i CREDITI  siano gestiti
DECLARE @Crediti char(1)
SET @Crediti = 'N'
IF 	(EXISTS(SELECT* FROM creditpart WHERE ycreditpart = @ayear AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar WHERE flagcredit ='S' and yvar = @ayear AND adate <= @date AND finvar.idfinvarstatus = 5)
	)
BEGIN
		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			assured,
			var_assign_credit,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE ((F.flag&1)<>0) -- Spesa
			AND (U.idupb like @idupb and U.active = 'S')
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
			AND finvar.adate <= @date
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')	

		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			assured,
			assign_credit,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE creditpart.adate <= @date 
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND (U.idupb like @idupb and U.active = 'S')
			AND incomeyear.ayear = @ayear
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')	
	
		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			assured,
			assign_credit,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE v.adate <= @date
			AND ((F.flag&1)<>0) -- Spesa
			AND (U.idupb like @idupb and U.active = 'S')
			AND v.yvar = @ayear
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND v.idfinvarstatus = 5
			AND v.flagcredit ='S'
			AND v.variationkind IN (1,3,4)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')

	SET @Crediti = 'S'
	
END
ELSE
Begin
   
	 SET @Crediti = 'N' 		
End	       

-- Controlla che gli INCASSI siano gestiti

DECLARE @Incassi char(1)
SET @Incassi = 'N'

IF 	(EXISTS(SELECT* FROM proceedspart WHERE yproceedspart = @ayear AND adate <= @date) 
	OR
	EXISTS (SELECT * FROM finvar WHERE flagproceeds='S' and yvar = @ayear AND adate <= @date AND finvar.idfinvarstatus = 5)
	)
	BEGIN
		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			assured,
			var_assign_cash,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE ((F.flag&1)<>0) -- Spesa
			AND (U.idupb like @idupb and U.active = 'S')
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
			AND finvar.adate <= @date
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')	
		
		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			assured,
			assign_cash,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE proceedspart.adate <= @date
			AND (U.idupb like @idupb and U.active = 'S')
			AND incomeyear.ayear = @ayear
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel,ISNULL(U.assured,'N')
		
		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			assured,
			assign_cash,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
			ISNULL(U.assured,'N'),
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
		WHERE v.adate <= @date
			AND ((F.flag&1)<>0) -- Spesa
			AND (@idfin IS NULL OR FLK.idparent = @idfin)
			AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
			AND (U.idupb like @idupb and U.active = 'S')
			AND v.yvar = @ayear
			AND v.idfinvarstatus = 5
			AND v.flagproceeds ='S'
			AND v.variationkind IN (1,3,4)
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel, ISNULL(U.assured,'N')
				
		SET @Incassi = 'S'
	END
ELSE
Begin
  
	SET @Incassi = 'N'		
End       

--	--	--	--	--	-- Aggiunge le voci inutilizzate se @suppressifblank = N --	--	--	--	--	--	

IF (@suppressifblank = 'N') 
BEGIN
--se ho scelto di vedere l'upb inserisco le coppie upb/bilancio altrimenti inserisco solo il bilanico non utilizzato
IF ( (@showupb <>'S') and (@idupboriginal = '%'))
Begin
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #situation_fin(idfin, nlevel,flagconsider)
			SELECT 
				F.idfin,F.nlevel,
			CASE 
				 WHEN (F.nlevel >= @levelusable and 
				 F.idfin IN (SELECT idfin FROM finlast))
				 THEN 'S'
				 ELSE 'N'
			END
			FROM fin F 
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			WHERE ((F.flag & 1) <> 0) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel >=  @nlevel)
			GROUP BY F.idfin, F.nlevel
		END
	ELSE
		BEGIN
			INSERT INTO #situation_fin(idfin, nlevel, flagconsider)
			SELECT F.idfin, F.nlevel,'S'
			FROM fin F
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 
			WHERE  	((F.flag & 1 ) <>0) AND F.ayear =@ayear	
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel = @nlevel)
			GROUP BY F.idfin,F.nlevel		
		END
end
else
begin
	--> @showupb ='S'
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #situation_fin(
				idfin, nlevel	,	
				idupb,
				assured,
				flagconsider
			)
			SELECT 
				F.idfin,F.nlevel		,
				U.idupb,
				ISNULL(U.assured,'N'),
				CASE 
					 WHEN (F.nlevel >= @levelusable and 
					 F.idfin IN (SELECT idfin FROM finlast))
					 THEN 'S'
					 ELSE 'N'
				END
			FROM fin F cross join upb U
			JOIN finlink FLK
				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2
				ON FLK2.idparent = F.idfin 				
			WHERE  ((F.flag & 1) <>0 ) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND (F.nlevel >=  @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idupb,F.idfin,ISNULL(U.assured,'N'),F.nlevel
		END
	ELSE
		BEGIN
			INSERT INTO #situation_fin(
				idfin, nlevel,
				idupb,
				assured,
				flagconsider
				)
			SELECT 
				F.idfin, F.nlevel		,
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
			GROUP BY U.idupb, F.idfin,ISNULL(U.assured,'N'), F.nlevel		
		END
end
END

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
			nlevel >=2)
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
		@Crediti as flag_assign_credit,
		@Incassi as	flag_assign_cash,
		flagconsider	
 	FROM #situation_fin 
 	JOIN fin 
		ON #situation_fin.idfin = fin.idfin			
	GROUP BY #situation_fin.idfin,
		fin.printingorder,
		fin.codefin,	
		fin.title,
		fin.nlevel,
		flagconsider			
	ORDER BY finprintingorder
END 
	ELSE
		SELECT 
			#situation_fin.idfin,	
			codeupb,
			#situation_fin.idupb,
			upb.title as 'upb',
			upb.printingorder as 'upbprintingorder',
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
			case when ((upb.assured is not null) and upb.assured ='S') then 'N'
					else @Crediti
			End as flag_assign_credit,
			case when ((upb.assured is not null) and upb.assured ='S')  then 'N'
					else @Incassi
			End as	flag_assign_cash,
			flagconsider	
	 	FROM #situation_fin 
		JOIN fin 
			on #situation_fin.idfin = fin.idfin
		JOIN upb
			on #situation_fin.idupb = upb.idupb
		GROUP BY upb.printingorder, codeupb, #situation_fin.idupb,upb.title,upb.assured,
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitclassificazioneupb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitclassificazioneupb]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/* 
exec rpt_sitclassificazioneupb 2013, {ts '2013-12-31 00:00:00'}, 6, 47, 3, '%', 'S', 'S', null, null,null,null,null,null,'A','N'
exec rpt_sitclassificazioneupb 2013, {ts '2013-12-31 00:00:00'}, 6,47,3, '00010007', 'S', 'S', 14862, null,null,null,null,null
exec rpt_sitclassificazioneupb 2013, {ts '2013-12-31 00:00:00'}, 6, 47, 3, '%', 'S', 'S', null, null,null,null,null,null,'A','N'
*/
--exec rpt_sitclassificazioneupb 2017, {ts '2017-12-31 00:00:00'}, 20, 13, null, '%', 'N',  'S', null, null,null,null,null,null,'A','S'

CREATE  PROCEDURE [rpt_sitclassificazioneupb]
	@ayear			int,
	@date			datetime,
	@idsorkind_cdr	int, --> Classificazione Centro di Responsabilità
	@idsorkind	int, --> Classificazione Missioni Programmi
	@nlevel			tinyint,
	@idupb			varchar(36),
	@showchildupb char(1),
	@suppressifblank 	char(1),
	@idfin			int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int ,
	@printkind char(1),-- Indica il tipo di importi da visualizzare P = preventivo, C = consuntivo, A = all
	@compatta char(1) -- Sono le stampe 4/prev e 4/cons. mostrano solo i totali su Missioni e Programmi
AS
BEGIN

CREATE TABLE #situation_fin
(
	idupb 			varchar(36),
	idsor int,
	idsor_cdr int,
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
	previsionkind 		char(1),
	secprevisionkind 	char(1)
)
IF @ayear IS NULL 
BEGIN
	SELECT * FROM  #situation_fin 
	RETURN
END

IF( @nlevel is null)
Begin
	SELECT  @nlevel = min(nlevel)
	FROM 	finlevel
	WHERE 	ayear = @ayear and flag&2 <> 0
End

IF 	(@showchildupb = 'S') set @idupb=@idupb+'%' 

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
	idsor,
	idsor_cdr,
	assured,
	main_initial_prevision
)
SELECT 
	F.idfin, 
	F.nlevel,
	U.idupb,
	US.idsor,
	US_CdR.idsor,
	ISNULL(U.assured,'N'),
	SUM(isnull(finyear.prevision,0)*isnull(US.quota,0))
FROM finyear
JOIN upb  U
	ON  finyear.idupb = U.idupb
JOIN upbsorting US
	ON U.idupb = US.idupb	
join sorting S
	ON S.idsor = US.idsor	
JOIN upbsorting US_CdR
	ON U.idupb = US_CdR.idupb	
join sorting S_CdR
	ON US_CdR.idsor = S_CdR.idsor	
JOIN fin F
	ON finyear.idfin = F.idfin
JOIN finlink FLK
	ON FLK.idchild = F.idfin and FLK.nlevel=@level_input
WHERE ((F.flag&1)<>0) -- Spesa
	AND (finyear.ayear = @ayear)
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb LIKE @idupb)-- and U.active = 'S')
	AND  F.nlevel = @nlevel
	and S.idsorkind = @idsorkind
	AND S_CdR.idsorkind = @idsorkind_cdr
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin, F.nlevel,ISNULL(U.assured,'N')


IF(@printkind in ('A','C'))
Begin

	INSERT INTO #situation_fin(
		idfin,
		nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		var_main_prevision
	)

	SELECT 
		F.idfin, 
		F.nlevel,
		 U.idupb,
		US.idsor,
		US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(finvardetail.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor	
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	

	WHERE ((F.flag&1)<>0 ) -- Spesa
		AND finvar.yvar = @ayear		
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND (@idfin IS NULL OR isnull(FLK.idparent, F.idfin) = @idfin)
		AND  F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND finvar.flagprevision ='S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate <= @date
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin,F.nlevel, ISNULL(U.assured,'N')


	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		fin_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expenseyear.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
	WHERE expense.adate <= @date
		AND expense.nphase = @fin_phase
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND ((expensetotal.flag&1)= 0) -- Competenza
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND  F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin, F.nlevel, ISNULL(U.assured,'N')

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		var_fin_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expensevar.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
	WHERE expensevar.adate <= @date
		AND expense.nphase = @fin_phase
		AND expensevar.yvar = @ayear
		AND ((expensetotal.flag&1)= 0) -- Competenza
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND  F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin,  F.nlevel,ISNULL(U.assured,'N')
		

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		fin_ph_resid
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expenseyear.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
	WHERE expense.adate <= @date
		AND expense.nphase = @fin_phase
		AND ((expensetotal.flag&1)<> 0) -- R
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND  F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin, F.nlevel, ISNULL(U.assured,'N')

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		var_fin_ph_resid
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expensevar.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor	
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
	WHERE expensevar.adate<= @date
		AND expense.nphase = @fin_phase
		AND expensevar.yvar = @ayear
		AND ((expensetotal.flag&1)<> 0) -- R
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
	GROUP BY  U.idupb, US.idsor,US_CdR.idsor,  F.idfin, F.nlevel, ISNULL(U.assured,'N')
		


	-- GESTIONE FONDO ECONOMALE	
	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		fin_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		U.idupb,
		US.idsor,
		US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(operation.amount,0)*isnull(US.quota,0))
	FROM fin F
	JOIN finlink FLK
		ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
	JOIN finlink FLK2
		ON FLK2.idparent = F.idfin 
	JOIN pettycashoperation operation
		ON ISNULL(FLK2.idchild,F.idfin) = operation.idfin
	JOIN upb U 
		ON operation.idupb = U.idupb
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
		
	WHERE  operation.adate <= @date
		AND operation.yoperation = @ayear
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
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
	GROUP BY  U.idupb, US.idsor,US_CdR.idsor,  F.idfin, F.nlevel, ISNULL(U.assured,'N')
			
	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		max_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(HPV.amount,0)*isnull(US.quota,0))
	FROM fin F
	JOIN finlink FLK
		ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
	JOIN finlink FLK2
		ON FLK2.idparent = F.idfin 
	JOIN historypaymentview HPV
		ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
	JOIN upb U 
		ON HPV.idupb = U.idupb
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor	
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
			
	WHERE  HPV.ymov = @ayear
		AND HPV.competencydate <= @date
		AND ((HPV.totflag&1) = 0) -- Competenza
		AND (U.idupb LIKE @idupb)-- and U.active = 'S') 
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor,US_CdR.idsor,  F.idfin, F.nlevel, ISNULL(U.assured,'N')

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		max_ph_resid
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(HPV.amount,0)*isnull(US.quota,0))
	FROM fin F
	JOIN finlink FLK
		ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
	JOIN finlink FLK2
		ON FLK2.idparent = F.idfin 
	JOIN historypaymentview HPV
		ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
	JOIN upb U 
		ON HPV.idupb = U.idupb
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
		
	WHERE  HPV.ymov = @ayear
		AND HPV.competencydate <= @date
		AND ((HPV.totflag&1) <> 0) -- R
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin, F.nlevel, ISNULL(U.assured,'N')

	IF @cashvaliditykind <>4
	BEGIN
				INSERT INTO #situation_fin(
					idfin, nlevel,
					idupb,
					idsor,
					idsor_cdr,
					assured,
					var_max_ph_comp
				)
				SELECT 
					F.idfin, F.nlevel,
					 U.idupb,
					 US.idsor,
					 US_CdR.idsor,
					ISNULL(U.assured,'N'),
					SUM(isnull(expensevar.amount,0)*isnull(US.quota,0))
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
				JOIN upbsorting US
					ON U.idupb = US.idupb	
				join sorting S
					ON S.idsor = US.idsor	
				JOIN upbsorting US_CdR
					ON U.idupb = US_CdR.idupb	
				join sorting S_CdR
					ON US_CdR.idsor = S_CdR.idsor	
				WHERE expensevar.yvar = @ayear
					AND HPV.ymov = @ayear
					AND ((HPV.totflag&1) = 0) -- Competenza
					AND HPV.competencydate <= @date
					AND expensevar.adate <= @date
					AND (@idfin IS NULL OR FLK.idparent = @idfin)
					AND (U.idupb LIKE @idupb)-- and U.active = 'S')
					AND F.nlevel = @nlevel
					and S.idsorkind = @idsorkind
					AND S_CdR.idsorkind = @idsorkind_cdr	
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				GROUP BY  U.idupb, US.idsor,US_CdR.idsor,  F.idfin,  F.nlevel,ISNULL(U.assured,'N')
				
				INSERT INTO #situation_fin(
					idfin, nlevel,
					idupb,
					idsor,
					idsor_cdr,
					assured,
					var_max_ph_resid
				)
				SELECT 
					F.idfin, F.nlevel,
					 U.idupb,
					 US.idsor,
					 US_CdR.idsor,
					ISNULL(U.assured,'N'),
					SUM(isnull(expensevar.amount,0)*isnull(US.quota,0))
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
				JOIN upbsorting US
					ON U.idupb = US.idupb	
				join sorting S
					ON S.idsor = US.idsor		
				JOIN upbsorting US_CdR
					ON U.idupb = US_CdR.idupb	
				join sorting S_CdR
					ON US_CdR.idsor = S_CdR.idsor	
				WHERE expensevar.yvar = @ayear
					AND HPV.ymov = @ayear
					AND ((HPV.totflag&1) <> 0) -- R
					AND HPV.competencydate <= @date
					AND expensevar.adate <= @date
					AND (@idfin IS NULL OR FLK.idparent = @idfin)
					AND (U.idupb LIKE @idupb)-- and U.active = 'S')
					AND F.nlevel = @nlevel
					and S.idsorkind = @idsorkind
					AND S_CdR.idsorkind = @idsorkind_cdr	
					AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
					AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
					AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
					AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY  U.idupb, US.idsor,US_CdR.idsor,  F.idfin, F.nlevel, ISNULL(U.assured,'N')				
						
						
	END
END -- Fine @printkind in ('A', 'C')	

if(@printkind = 'A') -- Se è la 1° o 2° stampa, quelle che mostrano le tre fasi, calcola anche la seconda fase
Begin
	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		sec_initial_prevision
	)
	SELECT 
		fin.idfin, fin.nlevel,
		U.idupb,
		US.idsor,
		US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(finyear.secondaryprev,0)*isnull(US.quota,0))
	FROM finyear
	JOIN upb U
		ON finyear.idupb = U.idupb
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN fin
		ON finyear.idfin = fin.idfin
	JOIN finlink
		ON finlink.idchild = fin.idfin and finlink.nlevel=@level_input
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
	WHERE ((fin.flag&1)<>0) -- Spesa
		AND (finyear.ayear = @ayear)
		AND (@idfin IS NULL OR finlink.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND  fin.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY U.idupb, US.idsor,US_CdR.idsor,  fin.idfin,  fin.nlevel,ISNULL(U.assured,'N')


	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		varprevsec
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(finvardetail.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	

	WHERE ((F.flag&1)=1) -- Spesa
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND  F.nlevel = @nlevel
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND finvar.yvar = @ayear		
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr
		AND finvar.flagsecondaryprev ='S'	
		AND finvar.idfinvarstatus = 5
		AND finvar.variationkind <> 5
		AND finvar.adate <= @date
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin,  F.nlevel,ISNULL(U.assured,'N')


	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		registry_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expenseyear.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor	
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
			
	WHERE expense.adate <= @date
		AND expense.nphase = @registry_phase
		AND ((expensetotal.flag&1)= 0) -- Competenza
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin,  F.nlevel,ISNULL(U.assured,'N')


	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		var_registry_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expensevar.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
	WHERE expensevar.adate <= @date
		AND expense.nphase = @registry_phase
		AND expensevar.yvar = @ayear
		AND ((expensetotal.flag&1)= 0) -- Competenza
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin, F.nlevel, ISNULL(U.assured,'N')

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		registry_ph_resid
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expenseyear.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
		
	WHERE expense.adate <= @date
		AND expense.nphase = @registry_phase
		AND ((expensetotal.flag&1)<> 0) -- R
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin,  F.nlevel,ISNULL(U.assured,'N')

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		var_registry_ph_resid
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(expensevar.amount,0)*isnull(US.quota,0))
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
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
		
	WHERE expensevar.adate <= @date
		AND expense.nphase = @registry_phase
		AND expensevar.yvar = @ayear
		AND ((expensetotal.flag&1)<> 0) -- R
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
		GROUP BY  U.idupb, US.idsor, US_CdR.idsor, F.idfin, F.nlevel, ISNULL(U.assured,'N')

	INSERT INTO #situation_fin(
		idfin, nlevel,
		idupb,
		idsor,
		idsor_cdr,
		assured,
		registry_ph_comp
	)
	SELECT 
		F.idfin, F.nlevel,
		 U.idupb,
		 US.idsor,
		 US_CdR.idsor,
		ISNULL(U.assured,'N'),
		SUM(isnull(operation.amount,0)*isnull(US.quota,0))
	FROM fin F
	JOIN finlink FLK
		ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
	JOIN finlink FLK2
		ON FLK2.idparent = F.idfin 
	JOIN pettycashoperation operation
		ON ISNULL(FLK2.idchild,F.idfin) = operation.idfin
	JOIN upb U 
		ON operation.idupb = U.idupb
	JOIN upbsorting US
		ON U.idupb = US.idupb	
	join sorting S
		ON S.idsor = US.idsor		
	JOIN upbsorting US_CdR
		ON U.idupb = US_CdR.idupb	
	join sorting S_CdR
		ON US_CdR.idsor = S_CdR.idsor	
		
	WHERE  operation.adate <= @date
		AND operation.yoperation = @ayear
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb LIKE @idupb)-- and U.active = 'S')
		AND F.nlevel = @nlevel
		and S.idsorkind = @idsorkind
		AND S_CdR.idsorkind = @idsorkind_cdr	
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
	GROUP BY  U.idupb, US.idsor,US_CdR.idsor,  F.idfin, F.nlevel, ISNULL(U.assured,'N')


End

--	--	--	--	--	-- Aggiunge le voci inutilizzate se @suppressifblank = N --	--	--	--	--	--	

IF (@suppressifblank = 'N') 
BEGIN
		INSERT INTO #situation_fin(
			idfin, nlevel,
			idupb,
			idsor,
			idsor_cdr,
			assured
			)
		SELECT 
			F.idfin, F.nlevel		,
			U.idupb,
			US.idsor,
			US_CdR.idsor,
			ISNULL(U.assured,'N')
		FROM upb U
		CROSS JOIN fin F
		JOIN finlink FLK
			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
		JOIN upbsorting US
			ON U.idupb = US.idupb	
		join sorting S
			ON S.idsor = US.idsor	
		JOIN upbsorting US_CdR
			ON U.idupb = US_CdR.idupb	
		join sorting S_CdR
			ON US_CdR.idsor = S_CdR.idsor	
		LEFT OUTER JOIN finlink FLK2
			ON FLK2.idparent = F.idfin 
		WHERE  	((F.flag & 1 ) <> 0) AND F.ayear =@ayear	
			AND (@idfin IS NULL OR  FLK.idparent = @idfin)
			AND (U.idupb LIKE @idupb)-- and U.active = 'S')
			AND (F.nlevel = @nlevel)
			and S.idsorkind = @idsorkind
			AND S_CdR.idsorkind = @idsorkind_cdr	
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
		GROUP BY U.idupb, US.idsor,US_CdR.idsor,  F.idfin,ISNULL(U.assured,'N'), F.nlevel		
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
			isnull(fin_ph_comp,0.0) =0 AND  
			isnull(var_fin_ph_comp,0.0) =0 AND 
			isnull(fin_ph_resid,0.0) =0 AND 
			isnull(var_fin_ph_resid,0.0) =0 AND 			
			nlevel >=2)
END

declare	@Sorkind_cdr	varchar(50) --> Classificazione Centro di Responsabilità
select @Sorkind_cdr = description from sortingkind where idsorkind = @idsorkind_cdr

declare	@Sorkind	varchar(50)--> Classificazione Missioni Programmi
select @Sorkind = description from sortingkind where idsorkind = @idsorkind

declare @levelparent varchar(50) --> Nome del 1° livello della classificazione Missioni/Programmi
declare @levelchild varchar(50)--> Nome del 2° livello della classificazione Missioni/Programmi
select @levelparent = description from sortinglevel where idsorkind = @idsorkind and nlevel = 1
select @levelchild = description from sortinglevel where idsorkind = @idsorkind and nlevel = 2

DECLARE @totmain_initial_prevision decimal(19,2)
DECLARE @totvar_main_prevision decimal(19,2)
DECLARE @totprevision decimal(19,2)
DECLARE @totfinphase decimal(19,2)
DECLARE @totmaxphase decimal(19,2)
if(@compatta = 'S')	--> questi totali sono calcolati solo per le stampa compatte e servono per il calcolo del valore in %
Begin
	SET @totmain_initial_prevision = (select sum(main_initial_prevision) from #situation_fin)
	SET @totvar_main_prevision = (select sum(var_main_prevision)from #situation_fin)
	--if (@previsionkind='C' )
	--Begin
		set @totfinphase= (select sum(isnull(fin_ph_comp,0) + isnull(var_fin_ph_comp,0)  +   isnull(fin_ph_resid,0) + isnull(var_fin_ph_resid,0))  from #situation_fin)
		set @totmaxphase = (select sum(isnull(max_ph_comp,0)  +  isnull(var_max_ph_comp,0)  +   isnull(max_ph_resid,0)  +   isnull(var_max_ph_resid,0))  from #situation_fin)
	--End
	--ELSE 
	--Begin
	--  set @totfinphase = (select sum(isnull(fin_ph_comp,0) + isnull(var_fin_ph_comp,0))  from #situation_fin)
	--  set @totmaxphase = (select sum(isnull(max_ph_comp,0)  +  isnull(var_max_ph_comp,0))  from #situation_fin)
	--End

	SET @totprevision = @totmain_initial_prevision + @totvar_main_prevision
End

if ( @printkind in ('P','C') and (@compatta='N'))
Begin
	SELECT 
		@levelparent as levelparent,
		@levelchild as levelchild,
		null as idfin,	
		U.codeupb,
		#situation_fin.idupb,
		U.title as 'upb',
		U.printingorder as 'upbprintingorder',
		@Sorkind as 'sortingkind',
		S.sortcode,
		SortPar.description as sortingparent,
		S.description as sortingchild,
		SortPar.description + ' - ' + S.description as sorting,
		S.nlevel as 'sortlevel',
		@Sorkind_cdr as Sorkind_cdr,
		S_CdR.sortcode as sortcode_cdr,
		S_CdR.description as sorting_cdr,
		null as codefin,	
		null as title,	
		null 	as 'finprintingorder',	
		null as nlevel,	
		isnull(sum(main_initial_prevision),0) as 'main_initial_prevision',
		isnull(sum(var_main_prevision),0) 	as 'var_main_prevision',
		isnull(sum(fin_ph_comp),0) 		as 'fin_ph_comp',
		isnull(sum(var_fin_ph_comp),0) 	as 'var_fin_ph_comp', 
		@desc_fin_phase 	as 'desc_fin_ph',					
		isnull(sum(registry_ph_comp),0) 	as 'registry_ph_comp',
		isnull(sum(var_registry_ph_comp),0)	as 'var_registry_ph_comp',
		@desc_registry_phase 	as 'desc_registry_ph',					
		isnull(sum(max_ph_comp),0) 		as 'max_ph_comp',
		isnull(sum(var_max_ph_comp),0) 	as 'var_max_ph_comp',
		@desc_max_phase 	as 'desc_max_ph',		
		isnull(sum(sec_initial_prevision),0)	as 'sec_initial_prevision',
		isnull(sum(varprevsec),0) 		as 'varprevsec',
		isnull(sum(fin_ph_resid),0) 		as 'fin_ph_resid', 
		isnull(sum(var_fin_ph_resid),0) 	as 'var_fin_ph_resid',
		isnull(sum(registry_ph_resid),0) 	as 'registry_ph_resid',
		isnull(sum(var_registry_ph_resid),0)  as 'var_registry_ph_resid',
		isnull(sum(max_ph_resid),0) 		as 'max_ph_resid',
		isnull(sum(var_max_ph_resid),0) 	as 'var_max_ph_resid',
		@previsionkind 		as 'previsionkind',
		@secprevisionkind 	as 'secprevisionkind',
		@totmain_initial_prevision as 'totmain_initial_prevision',
		@totvar_main_prevision as 'totvar_main_prevision',
		@totprevision as 'totprevision',
		@totfinphase as 'totfinphase',
		@totmaxphase as 'totmaxphase'
 	FROM #situation_fin 
	JOIN upb U
		on #situation_fin.idupb = U.idupb
	join sorting S
		ON S.idsor = #situation_fin.idsor	
	join sorting SortPar
		on S.paridsor = SortPar.idsor	
	join sorting S_CdR
		ON #situation_fin.idsor_cdr = S_CdR.idsor	
	where S.idsorkind = @idsorkind		
		and S_CdR.idsorkind = @idsorkind_cdr
	GROUP BY S_CdR.sortcode, S_CdR.description,
		S.idsor, S.sortcode,
		S.nlevel, SortPar.description, S.description,		
		U.printingorder, U.codeupb, 
		#situation_fin.idupb, U.title,U.assured
	ORDER BY S_CdR.sortcode, S_CdR.description,S.sortcode, U.printingorder
End

if ( @printkind in ('P','C') and (@compatta='S'))
Begin
	SELECT 
		@levelparent as levelparent,
		@levelchild as levelchild,
		null as idfin,	
		null as codeupb,
		null as idupb,
		null as upb,
		null as 'upbprintingorder',
		@Sorkind as 'sortingkind',
		S.sortcode,
		SortPar.description as sortingparent,
		S.description as sortingchild,
		SortPar.description + ' - ' + S.description as sorting,
		S.nlevel as 'sortlevel',
		null as Sorkind_cdr,
		null as sortcode_cdr,
		null as sorting_cdr,
		null as codefin,	
		null as title,	
		null 	as 'finprintingorder',	
		null as nlevel,	
		isnull(sum(main_initial_prevision),0) as 'main_initial_prevision',
		isnull(sum(var_main_prevision),0) 	as 'var_main_prevision',
		isnull(sum(fin_ph_comp),0) 		as 'fin_ph_comp',
		isnull(sum(var_fin_ph_comp),0) 	as 'var_fin_ph_comp', 
		@desc_fin_phase 	as 'desc_fin_ph',					
		isnull(sum(registry_ph_comp),0)	as 'registry_ph_comp',
		isnull(sum(var_registry_ph_comp),0)	as 'var_registry_ph_comp',
		@desc_registry_phase 	as 'desc_registry_ph',					
		isnull(sum(max_ph_com),0) 		as 'max_ph_comp',
		isnull(sum(var_max_ph_comp),0) 	as 'var_max_ph_comp',
		@desc_max_phase 	as 'desc_max_ph',		
		isnull(sum(sec_initial_prevision),0) 	as 'sec_initial_prevision',
		isnull(sum(varprevsec),0) 		as 'varprevsec',
		isnull(sum(fin_ph_resid),0) 		as 'fin_ph_resid', 
		isnull(sum(var_fin_ph_resid),0) 	as 'var_fin_ph_resid',
		isnull(sum(registry_ph_resid),0) 	as 'registry_ph_resid',
		isnull(sum(var_registry_ph_resid),0) as 'var_registry_ph_resid',
		isnull(sum(max_ph_resid),0)		as 'max_ph_resid',
		isnull(sum(var_max_ph_resid),0) 	as 'var_max_ph_resid',
		@previsionkind 		as 'previsionkind',
		@secprevisionkind 	as 'secprevisionkind',
		@totmain_initial_prevision as 'totmain_initial_prevision',
		@totvar_main_prevision as 'totvar_main_prevision',
		@totprevision as 'totprevision',
		@totfinphase as 'totfinphase',
		@totmaxphase as 'totmaxphase'
 	FROM #situation_fin 
	join sorting S
		ON S.idsor = #situation_fin.idsor	
	join sorting SortPar
		on S.paridsor = SortPar.idsor	
	where S.idsorkind = @idsorkind		
	GROUP BY 
		S.idsor, S.sortcode,
		S.nlevel, SortPar.description, S.description		
	ORDER BY S.sortcode 
End

if ( @printkind ='A')
Begin
	SELECT 
		@levelparent as levelparent,
		@levelchild as levelchild,
		#situation_fin.idfin,	
		U.codeupb,
		#situation_fin.idupb,
		U.title as 'upb',
		U.printingorder as 'upbprintingorder',
		@Sorkind as 'sortingkind',
		S.sortcode,
		SortPar.description as sortingparent,
		S.description as sortingchild,
		SortPar.description + ' - ' + S.description as sorting,
		S.nlevel as 'sortlevel',
		@Sorkind_cdr as Sorkind_cdr,
		S_CdR.sortcode as sortcode_cdr,
		S_CdR.description as sorting_cdr,
		F.codefin,	
		F.title,	
		F.printingorder 	as 'finprintingorder',	
		F.nlevel,	
		isnull(sum(main_initial_prevision),0) as 'main_initial_prevision',
		isnull(sum(var_main_prevision),0)	as 'var_main_prevision',
		isnull(sum(fin_ph_comp),0)		as 'fin_ph_comp',
		isnull(sum(var_fin_ph_comp),0) 	as 'var_fin_ph_comp', 
		@desc_fin_phase 	as 'desc_fin_ph',					
		isnull(sum(registry_ph_comp),0) 	as 'registry_ph_comp',
		isnull(sum(var_registry_ph_comp),0) 	as 'var_registry_ph_comp',
		@desc_registry_phase 	as 'desc_registry_ph',					
		isnull(sum(max_ph_comp),0) 		as 'max_ph_comp',
		isnull(sum(var_max_ph_comp),0)	as 'var_max_ph_comp',
		@desc_max_phase 	as 'desc_max_ph',		
		isnull(sum(sec_initial_prevision),0)	as 'sec_initial_prevision',
		isnull(sum(varprevsec),0) 		as 'varprevsec',
		isnull(sum(fin_ph_resid),0) 		as 'fin_ph_resid', 
		isnull(sum(var_fin_ph_resid),0) 	as 'var_fin_ph_resid',
		isnull(sum(registry_ph_resid),0) 	as 'registry_ph_resid',
		isnull(sum(var_registry_ph_resid),0) as 'var_registry_ph_resid',
		isnull(sum(max_ph_resid),0) 		as 'max_ph_resid',
		isnull(sum(var_max_ph_resid),0) 	as 'var_max_ph_resid',
		@previsionkind 		as 'previsionkind',
		@secprevisionkind 	as 'secprevisionkind',
		@totmain_initial_prevision as 'totmain_initial_prevision',
		@totvar_main_prevision as 'totvar_main_prevision',
		@totprevision as 'totprevision',
		@totfinphase as 'totfinphase',
		@totmaxphase as 'totmaxphase'
 	FROM #situation_fin 
	JOIN fin F 
		on #situation_fin.idfin = F.idfin
	JOIN upb U
		on #situation_fin.idupb = U.idupb
	join sorting S
		ON S.idsor = #situation_fin.idsor	
	join sorting SortPar
		on S.paridsor = SortPar.idsor	
	join sorting S_CdR
		ON #situation_fin.idsor_cdr = S_CdR.idsor	
	where S.idsorkind = @idsorkind		
		and S_CdR.idsorkind = @idsorkind_cdr
	GROUP BY S_CdR.sortcode, S_CdR.description,
		S.idsor, S.sortcode,
		S.nlevel, SortPar.description, S.description,		
		U.printingorder, U.codeupb, 
		#situation_fin.idupb, U.title,U.assured,
		F.printingorder, F.codefin, F.title, #situation_fin.idfin,
		F.nlevel
	ORDER BY S_CdR.sortcode, S_CdR.description,S.sortcode, U.printingorder, F.printingorder
End


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



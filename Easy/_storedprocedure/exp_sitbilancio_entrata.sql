
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitbilancio_entrata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitbilancio_entrata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE   PROCEDURE  [exp_sitbilancio_entrata]
	@ayear				int,
	@date				datetime,
	@nlevel				tinyint,
	@hierarchy			char(1),
	@idupb				varchar(36),
	@showupb 			char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@idfin				int,
	@idsor01			int ,
	@idsor02			int ,
	@idsor03			int ,
	@idsor04			int ,
	@idsor05			int 
	AS
	BEGIN/* Versione 1.0.3 del 30/06/2008 ultima modifica: PIERO */
-- exec [exp_sitbilancio_entrata] 2013, {ts '2013-12-31 00:00:00'}, 3, 'S', '%', 'S', 'N', 'S',null

/*
Per le entrate
identificazione del bilancio (tit. cat. cap. art. denominazione e responsabile)
previsione iniziale
variazioni di bilancio
previsione attuale 
disponibile in previsione
Accertamenti (non incassati)
disponibile di previsione  per accertamento

*/


DECLARE @level_input tinyint
SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @idfin) ,@nlevel)
-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3

IF (@nlevel < @level_input) AND (@idfin is not null)
	BEGIN
	SET  @nlevel = @level_input
	END


declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'
 

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM 	finlevel
WHERE 	ayear =@ayear and (flag&2)<>0


	CREATE TABLE #fin_situation
	(
		idupb 				varchar(36),
		codeupb				varchar(50),
		upb   				varchar(150),
		upbprintingorder	varchar(50),
		idfin				int,
		codefin				varchar(50),
		title				varchar(150),
		finprintingorder	varchar(50),
		flagadvance			char(1),
		nlevel				tinyint,
		initialprevision	decimal(19,2),
		var_prevision		decimal(19,2),
		sec_initial_prevision	decimal(19,2),
		varprevsec			decimal(19,2),
		assessments			decimal(19,2),
		var_assessments		decimal(19,2),
		proceeds         	decimal(19,2),
		var_proceeds        decimal(19,2),
		flagconsider 		char(1), 	
		fin_ph_comp			decimal(19,2), 
		var_fin_ph_comp		decimal(19,2), 
		fin_ph_resid		decimal(19,2), 
		var_fin_ph_resid	decimal(19,2), 
		registry_ph_comp	decimal(19,2), 
		var_registry_ph_comp	decimal(19,2), 
		registry_ph_resid	decimal(19,2), 
		var_registry_ph_resid	decimal(19,2),
		max_ph_comp			decimal(19,2),
		max_ph_resid		decimal(19,2),
		var_max_ph_comp		decimal(19,2),
		var_max_ph_resid	decimal(19,2)
	)
		
	IF (@ayear IS NULL) 
	BEGIN
		SELECT * FROM  #fin_situation
		RETURN
	END
	
	
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


	DECLARE @fin_phase  tinyint -- fase accantonamento precedente alla fase di impegno, Modifica Sara
SELECT 	@fin_phase = incomefinphase FROM uniconfig

DECLARE @desc_fin_phase varchar(50)
SELECT  @desc_fin_phase=description
FROM 	incomephase WHERE nphase=@fin_phase 

DECLARE @registry_phase tinyint
SELECT  @registry_phase = incomeregphase FROM uniconfig

DECLARE @desc_registry_phase varchar(50)
SELECT  @desc_registry_phase=description
FROM    incomephase WHERE nphase=@registry_phase 

 
DECLARE @desc_max_phase    	varchar(50)
SELECT  @desc_max_phase=description 
FROM 	incomephase WHERE nphase=@phasemax 

 

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

 

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	initialprevision,
	flagconsider
)
	SELECT 
		F.idfin, F.nlevel,
		isnull(@fixedidupb, U.idupb),
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
	JOIN upb U 		ON  finyear.idupb = U.idupb
	JOIN fin F		ON finyear.idfin = F.idfin
	JOIN finlink FLK		ON FLK.idchild = F.idfin and FLK.nlevel=@level_input
	WHERE ((F.flag&1) = 0) -- Entrata
		AND (finyear.ayear = @ayear)
		AND (@idfin IS NULL OR FLK.idparent = @idfin)
		AND (U.idupb like @idupb)
		AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	GROUP BY isnull(@fixedidupb, U.idupb), F.idfin, F.nlevel

INSERT INTO #fin_situation(
	idfin,nlevel,
	idupb,
	var_prevision ,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
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
JOIN finlink FLK			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2			ON FLK2.idparent = F.idfin 
JOIN finvardetail			ON ISNULL(FLK2.idchild,F.idfin) = finvardetail.idfin
JOIN finvar				  	ON finvar.yvar = finvardetail.yvar    	AND finvar.nvar = finvardetail.nvar 
JOIN upb U					ON finvardetail.idupb = U.idupb	
WHERE ((F.flag&1)= 0) -- Entrata
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
	AND finvar.adate <= @date
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel


INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	assessments,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
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
JOIN finlink FLK		ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2		ON FLK2.idparent = F.idfin 
JOIN incomeyear			ON ISNULL(FLK2.idchild,F.idfin) = incomeyear.idfin	AND incomeyear.ayear = @ayear
JOIN income				ON incomeyear.idinc = income.idinc
JOIN incometotal		ON  incomeyear.idinc = incometotal.idinc	AND incomeyear.ayear = incometotal.ayear
JOIN upb U				ON incomeyear.idupb = U.idupb	
WHERE income.adate  <= @date
	AND income.nphase = @assessmentphase
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
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel

INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	var_assessments,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
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
JOIN finlink FLK			ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2			ON FLK2.idparent = F.idfin 
JOIN incomeyear				ON ISNULL(FLK2.idchild,F.idfin) = incomeyear.idfin	AND incomeyear.ayear = @ayear
JOIN incomevar				ON incomeyear.idinc = incomevar.idinc
JOIN income					ON incomeyear.idinc = income.idinc
JOIN incometotal			ON  incomeyear.idinc = incometotal.idinc	AND incomeyear.ayear = incometotal.ayear
JOIN upb U					ON incomeyear.idupb = U.idupb	
WHERE incomevar.adate  <= @date
	AND income.nphase = @assessmentphase
	AND incomevar.yvar = @ayear
	AND (((incometotal.flag&1)= 0) -- Competenza
	OR @flag_cs = 'S')
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
    AND (U.idupb like @idupb)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR 
		 (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		 		
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel 

		--SET fin_ph_comp =      income.nphase = @fin_phase  	AND ((incometotal.flag&1)=0) -- Competenza
		-- var_fin_ph_comp
		--fin_ph_resid = 		vAND ((incometotal.flag&1)=1) -- Residuo
		--var_fin_ph_resid AND income.nphase= @fin_phase
		--	AND ((incometotal.flag&1)=1) -- Residuo

	
INSERT INTO #fin_situation(
	idfin, nlevel,
	idupb,
	proceeds,
	flagconsider
)
SELECT 
	F.idfin, F.nlevel,
	isnull(@fixedidupb, U.idupb),
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
JOIN finlink FLK				ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
JOIN finlink FLK2				ON FLK2.idparent = F.idfin 
JOIN historyproceedsview HPV	ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
JOIN upb U						ON HPV.idupb = U.idupb
WHERE  HPV.ymov = @ayear
	AND HPV.competencydate  <= @date
	AND (((HPV.totflag&1)= 0) -- Competenza
	OR  @flag_cs = 'S')
	AND (U.idupb like @idupb)
	AND (@idfin IS NULL OR FLK.idparent = @idfin)
	AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
GROUP BY isnull(@fixedidupb, U.idupb),F.idfin, F.nlevel



IF @cashvaliditykind <> 4
BEGIN	
	INSERT INTO #fin_situation(
			idfin, nlevel,
			idupb,
			var_proceeds,
			flagconsider
		)
		SELECT 
			F.idfin, F.nlevel,
			isnull(@fixedidupb, U.idupb),
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
			JOIN finlink FLK					ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			JOIN finlink FLK2					ON FLK2.idparent = F.idfin 
			JOIN historyproceedsview HPV		ON ISNULL(FLK2.idchild,F.idfin) = HPV.idfin
			JOIN incomevar						ON HPV.idinc = incomevar.idinc
			JOIN upb U							ON HPV.idupb = U.idupb
			WHERE incomevar.yvar = @ayear
				AND HPV.ymov = @ayear
				AND HPV.competencydate  <= @date
				AND (((HPV.totflag&1)= 0) -- Competenza
					OR @flag_cs = 'S')
				AND incomevar.adate <=@date
				AND (@idfin IS NULL OR FLK.idparent = @idfin)
				AND (U.idupb like @idupb)
				AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >= @nlevel))
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			GROUP BY isnull(@fixedidupb, U.idupb),F.idfin,  F.nlevel
	END

--	--	--	--	--	-- Aggiunge le voci inutilizzate se @suppressifblank = N --	--	--	--	--	--	

IF (@suppressifblank = 'N') 
BEGIN
IF ( (@showupb <>'S') and (@idupboriginal = '%'))
Begin
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #fin_situation(idfin, nlevel)
			SELECT 
				F.idfin, F.nlevel 
			FROM fin F 
			cross join upb U
			JOIN finlink FLK2					ON FLK2.idparent = F.idfin 
			JOIN finlink FLK					ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
											AND (@idfin IS NULL OR FLK.idparent = @idfin)
			WHERE ((F.flag & 1) = 1) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel >=  @nlevel)
				AND (U.idupb LIKE @idupb and U.active = 'S')
			GROUP BY F.idfin, F.nlevel,   F.ayear,F.flag
		END
	ELSE
		BEGIN
			INSERT INTO #fin_situation(idfin,nlevel)
			SELECT F.idfin, F.nlevel
			FROM fin F
			cross join upb U
			JOIN finlink FLK					ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2		ON FLK2.idparent = F.idfin 
			WHERE  	((F.flag & 1 ) <>0) AND F.ayear =@ayear	
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (F.nlevel = @nlevel)
				AND (U.idupb LIKE @idupb and U.active = 'S')
			GROUP BY F.idfin, F.nlevel 	
		END
end
else

--> @showupb ='S'
	if(@hierarchy='S')	
		BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,
				flagconsider
			)
			SELECT 
				F.idfin, F.nlevel,
				U.idupb, 
			CASE 
				 WHEN (@hierarchy ='N') Then 'S' 
				 WHEN ( @hierarchy='S' 
						and F.nlevel >= @levelusable 
						and F.idfin IN (SELECT idfin FROM finlast))
					THEN 'S'
				 ELSE 'N'
			END
			FROM fin F cross join upb U
			LEFT OUTER JOIN finlink FLK2			ON FLK2.idparent = F.idfin 
			JOIN finlink FLK						ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input		AND (@idfin IS NULL OR FLK.idparent = @idfin)
			WHERE  ((F.flag & 1) = 1) and F.ayear = @ayear
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND (F.nlevel >=  @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idupb,F.idfin,F.nlevel,F.ayear,F.flag
		END
	ELSE
		BEGIN
			INSERT INTO #fin_situation(
				idfin, nlevel,
				idupb,
				flagconsider
				)
			SELECT 
				F.idfin, F.nlevel,
				U.idupb,
				'S'
			FROM upb U
			CROSS JOIN fin F
			JOIN finlink FLK					ON FLK.idchild = F.idfin AND FLK.nlevel = @level_input
			LEFT OUTER JOIN finlink FLK2		ON FLK2.idparent = F.idfin 
			WHERE  	((F.flag & 1 ) <> 0) AND F.ayear =@ayear	
				AND (@idfin IS NULL OR  FLK.idparent = @idfin)
				AND (U.idupb LIKE @idupb and U.active = 'S')
				AND (F.nlevel = @nlevel)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
			GROUP BY U.idupb, F.idfin,F.nlevel 
		END
end
END

DELETE FROM #fin_situation WHERE flagconsider='N'
IF (@suppressifblank = 'S') 	--> cancella le righe  sottostante la categoria
BEGIN
	DELETE FROM #fin_situation WHERE 
			(
				isnull(initialprevision,0) =0 AND isnull(var_prevision,0) =0 AND 
				isnull(sec_initial_prevision,0) =0 AND isnull(varprevsec,0)= 0 AND
				isnull(assessments,0) =0 AND isnull(var_assessments,0) =0 AND 
				isnull(proceeds,0) =0 AND isnull(var_proceeds,0) =0 AND
				isnull(fin_ph_comp,0) =0 AND isnull(var_fin_ph_comp,0) =0 AND
				isnull(fin_ph_resid,0) =0 AND isnull(var_fin_ph_resid,0) =0 AND
				isnull(registry_ph_comp,0) =0 AND isnull(var_registry_ph_comp,0) =0 AND 
				isnull(registry_ph_resid,0) =0 AND isnull(var_registry_ph_resid,0) =0 AND 
				isnull(max_ph_comp,0) =0 AND isnull(var_max_ph_comp,0) =0 AND 
				isnull(max_ph_resid,0) =0 AND isnull(var_max_ph_resid,0) =0   
			AND nlevel >=2)
END
		
--SELECT * FROM #fin_situation ORDER BY idupb, idfin	
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
		finlevel.description					as 'Livello',
		fin.codefin								as 'Cod. Bilancio',	
		fin.title								as 'Bilancio',	
		manager.title							as 'Responsabile',
		sum(isnull(initialprevision,0.0)) 		as 'Previsione iniziale principale',	
		sum(isnull(var_prevision,0.0)) 			as 'Variazioni previsione principale',
		sum(isnull(initialprevision,0.0)) + sum(isnull(var_prevision,0.0)) as 'Previsione principale definitiva',
		sum(isnull(assessments,0.0)) + sum(isnull(var_assessments,0.0))	   as 'Accertamenti',
		sum(isnull(proceeds,0.0))  + sum(isnull(var_proceeds,0.0)) 		   as 'Incassi',
		sum(isnull(initialprevision,0.0)) + sum(isnull(var_prevision,0.0)) -
		(sum(isnull(proceeds,0.0))   +  sum(isnull(var_proceeds,0.0)) ) as 'Previsione Disponibile ad Incassare'
	FROM #fin_situation 
		JOIN fin ON #fin_situation.idfin = fin.idfin	
		LEFT OUTER JOIN finlast on #fin_situation.idfin = finlast.idfin  
		LEFT OUTER JOIN  manager on manager.idman = finlast.idman  
		JOIN finlevel on fin.nlevel = finlevel.nlevel and finlevel.ayear = @ayear
		group by upbprintingorder,fin.printingorder,
		#fin_situation.idfin,finlevel.description,manager.title,
		fin.codefin,
		fin.title,
		fin.nlevel,
		flagconsider,
		finprintingorder
		ORDER BY  
		finprintingorder,fin.printingorder
	END
ELSE
BEGIN
SELECT 
			finlevel.description					as 'Livello',
			fin.codefin								as 'Cod. Bilancio',	
			fin.title								as 'Bilancio',	
			manager.title							as 'Responsabile',
			upb.codeupb								as 'Cod. UPB',
			upb.title								as 'UPB',
			sum(isnull(initialprevision,0.0)) 		as 'Previsione iniziale principale',	
			sum(isnull(var_prevision,0.0)) 			as 'Variazioni previsione principale',
			sum(isnull(initialprevision,0.0)) + sum(isnull(var_prevision,0.0)) as 'Previsione principale definitiva',
			sum(isnull(assessments,0.0)) + sum(isnull(var_assessments,0.0))	   as 'Accertamenti',
			sum(isnull(proceeds,0.0))  + sum(isnull(var_proceeds,0.0)) 		   as 'Incassi',
			sum(isnull(initialprevision,0.0)) + sum(isnull(var_prevision,0.0)) -
			(sum(isnull(proceeds,0.0))   +  sum(isnull(var_proceeds,0.0)) ) as 'Previsione Disponibile ad Incassare'

	FROM #fin_situation
	JOIN fin 
	ON #fin_situation.idfin = fin.idfin	
	JOIN upb 
	ON #fin_situation.idupb = upb.idupb
	left outer join finlast on #fin_situation.idfin = finlast.idfin  
	left outer join manager on manager.idman = isnull(finlast.idman , upb.idman)
	join finlevel on fin.nlevel = finlevel.nlevel and finlevel.ayear = @ayear
	group by finlevel.description, 	fin.codefin,	fin.title,
	manager.title, upb.codeupb, upb.title,upb.printingorder,fin.printingorder
	ORDER BY upb.printingorder,fin.printingorder
	END

 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

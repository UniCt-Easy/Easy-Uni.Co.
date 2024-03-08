
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_residui_respons]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_residui_respons]
GO

CREATE	PROCEDURE rpt_sitbilancio_residui_respons
	@ayear			int,
	@nlevel			tinyint,
	@hierarchy		char(1),
	@idman			int,
	@idupb			varchar(36),
	@showupb 		char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@codefin		varchar(50),
	@start datetime,
	@stop datetime

AS
BEGIN
/* Versione 1.0.5 del 17/10/2007 ultima modifica: SARA */

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
				and (fin.flag&1)=0) -- Entrata
	END
	CREATE  TABLE #fin_residual
	(
		idupb 			varchar(36),
		codeupb			varchar(50),
		upb   			varchar(150),
		upbprintingorder	varchar(50),
		idfin			int,
		codefin			varchar(50),
		title			varchar(150),
		finprintingorder	varchar(50),
		nlevel			tinyint,
		idman			int,
		manager			varchar(150),
		assessments		decimal(19,2),
		var_assessments		decimal(19,2),
		proceeds         	decimal(19,2),
		var_proceeds          	decimal(19,2)
	)
	
	IF (@ayear IS NULL) 
	BEGIN
		SELECT * FROM  #fin_residual 
		RETURN
	END
	
	DECLARE @idupboriginal 	varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S') set @idupb=@idupb+'%' 
	DECLARE @assessmentphase tinyint
	DECLARE @phasemax tinyint
	
	SELECT  @assessmentphase = assessmentphasecode
	FROM 	config
	WHERE 	ayear = @ayear
	SELECT  @phasemax = MAX(nphase)
	FROM 	incomephase
	
	DECLARE @cashvaliditykind int
	SELECT	@cashvaliditykind = cashvaliditykind
	FROM 	config
	WHERE 	ayear = @ayear

	declare @levelidfin tinyint
	select @levelidfin = nlevel from fin where idfin = @idfin

	INSERT INTO #fin_residual
		(
		idfin, 
		codefin,
		title,
		finprintingorder,
		codeupb	,	
		idupb,
		upb  ,
		upbprintingorder,
		nlevel,
		idman,
		manager)
	SELECT distinct
		fin.idfin,
		fin.codefin,
		fin.title, 
		fin.printingorder,
		upb.codeupb,	
		upb.idupb,
		upb.title ,
		upb.printingorder,
		fin.nlevel,
		manager.idman,
		manager.title
	FROM incomeyear
	join upb 
		ON  incomeyear.idupb = upb.idupb 
	JOIN fin
		ON  incomeyear.idfin = fin.idfin
	JOIN finlast
		ON  fin.idfin = finlast.idfin
	JOIN finlevel
		ON finlevel.nlevel = fin.nlevel
		AND finlevel.ayear = fin.ayear
		AND (finlevel.flag&2)<>0
	left outer JOIN finlink
		ON  finlink.idchild = fin.idfin and finlink.nlevel>=@levelidfin
	JOIN manager
		ON upb.idman = manager.idman
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	WHERE ((fin.flag&1)=0) --  Entrata
		AND ((upb.idman = @idman) OR  (@idman is null and upb.idman is not null))	
		AND fin.ayear = @ayear
		AND (@idfin IS NULL OR ISNULL(finlink.idparent,fin.idfin) = @idfin)
	    	AND (upb.idupb like @idupb )
		AND ((@hierarchy ='N' AND fin.nlevel = @nlevel) OR (@hierarchy ='S' AND fin.nlevel >=  @nlevel))
		AND ((incometotal.flag&1)= 1) --Residuo
		AND incomeyear.ayear=@ayear
	
	UPDATE #fin_residual
		SET assessments = 
			ISNULL((SELECT SUM(incomeyear.amount)
				FROM incomeyear
				JOIN income
					ON income.idinc = incomeyear.idinc
					AND incomeyear.ayear = @ayear
				JOIN incometotal
					ON  incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
				JOIN finlink
					ON  finlink.idchild = incomeyear.idfin 
				WHERE income.adate between @start and @stop 
					AND income.nphase = @assessmentphase
					AND  ((incometotal.flag&1)= 1) --Residuo
					AND finlink.idparent = #fin_residual.idfin
					AND incomeyear.idupb = #fin_residual.idupb), 0.0),
		var_assessments =
			ISNULL((SELECT SUM(incomevar.amount)
				FROM incomevar
				JOIN incomeyear
					ON incomeyear.idinc = incomevar.idinc
					AND incomeyear.ayear = @ayear
				JOIN income
					ON income.idinc = incomeyear.idinc
				JOIN finlink
					ON  finlink.idchild = incomeyear.idfin 
				JOIN incometotal
					ON incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
				WHERE 	incomevar.adate between @start and @stop 
					AND income.nphase = @assessmentphase
					AND finlink.idparent = #fin_residual.idfin
					AND incomeyear.idupb = #fin_residual.idupb
					AND ((incometotal.flag&1)= 1) --Residuo
					AND incomevar.yvar = @ayear), 0.0)
	
	UPDATE #fin_residual
		SET proceeds = 
			ISNULL((SELECT SUM(HPV.amount)
				FROM historyproceedsview HPV
				JOIN finlink
					ON  finlink.idchild = HPV.idfin 
				WHERE 	HPV.ymov = @ayear
					AND HPV.competencydate between @start and @stop
					AND ((HPV.totflag&1)= 1) --Residuo
					AND finlink.idparent = #fin_residual.idfin
					AND HPV.idupb = #fin_residual.idupb), 0.0)
	IF @cashvaliditykind <> 4
	BEGIN 
		UPDATE #fin_residual
		SET  var_proceeds =
			ISNULL((SELECT SUM(incomevar.amount)
				FROM incomevar
				JOIN historyproceedsview HPV 						
					ON HPV.idinc = incomevar.idinc
					AND HPV.ymov = @ayear
				JOIN finlink
					ON  finlink.idchild = HPV.idfin 
				WHERE incomevar.yvar = @ayear
				AND incomevar.adate between @start and @stop
				AND HPV.competencydate between @start and @stop
				AND HPV.ymov = @ayear
				AND ((HPV.totflag&1)= 1) -- Residuo
				AND finlink.idparent = #fin_residual.idfin
				AND HPV.idupb = #fin_residual.idupb), 0.0)
	END
IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
	UPDATE #fin_residual SET  
		upbprintingorder = (SELECT TOP 1 upbprintingorder
			FROM #fin_residual
			WHERE idupb = @idupboriginal),
		upb = (SELECT TOP 1 upb
			FROM #fin_residual
			WHERE idupb = @idupboriginal),
		idupb = @idupboriginal,
		codeupb =(SELECT TOP 1 codeupb
			FROM #fin_residual	
			WHERE idupb = @idupboriginal)
	IF (@showupb <>'S') and (@idupboriginal = '%') 
		UPDATE #fin_residual SET  
		upbprintingorder = null	,
		upb =  null,
		idupb = null,
		codeupb = null
	IF (@suppressifblank = 'S') 	
	BEGIN
		DELETE 
		FROM #fin_residual 
		WHERE 
			(isnull(assessments,0.0) =0 AND 
			isnull(var_assessments,0.0) =0 AND 
			isnull(proceeds,0.0) =0 AND 
			isnull(var_proceeds,0.0) =0 
			AND nlevel >=2)
	END
IF (@showupb <>'S') 
BEGIN
	SELECT 
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nlevel,
		idman,
		manager,
		sum(isnull(assessments,0.0)) 		as 'assessments'			,
		sum(isnull(var_assessments,0.0))	as 'var_assessments'				,
		sum(isnull(proceeds,0.0)) 		as 'proceeds'         			,
		sum(isnull(var_proceeds,0.0)) 		as 'var_proceeds' 
	FROM #fin_residual 
	GROUP BY upbprintingorder,
		finprintingorder,
		idfin,
		codeupb,
		idupb,
		upb,
		codefin,
		title,
		nlevel,
		idman,
		manager	
	ORDER BY finprintingorder
END
ELSE
	SELECT 
		idfin,
		codefin,
		title,
		finprintingorder,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		nlevel,
		idman,
		manager,
		assessments,
		var_assessments,
		proceeds,
		var_proceeds 
	FROM #fin_residual 
	ORDER BY manager
--EXEC rpt_sitbilancio_residui_respons @ayear=2007, @date={d '2007-09-10'}, @idfin=null, @nlevel=1, @hierarchy='S', @idman=null, @idupb=null, @showupb='S', @showchildupb='S', @suppressifblank='S'
END
go

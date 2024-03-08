
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sitbilancio_residui]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sitbilancio_residui]
GO

CREATE  PROCEDURE [rpt_sitbilancio_residui]
	@ayear			int,
	@date			datetime,
	@nlevel			tinyint,
	@hierarchy		char(1),
	@idupb			varchar(36),
	@showupb 		char(1),
	@showchildupb 		char(1),
	@suppressifblank 	char(1),
	@idfin			int
AS
BEGIN
/* Versione 1.0.4 del 15/11/2007 ultima modifica: Pino */
	CREATE TABLE #fin_residual
	(
		idupb 			varchar(36),
		codeupb			varchar(50),
		upb   			varchar(150),
		upbprintingorder	varchar(50),
		idfin			int,
		nlevel			tinyint,
		codefin			varchar(50),
		title			varchar(150),
		finprintingorder	varchar(50),
		assessments		decimal(19,2),
		var_assessments		decimal(19,2),
		proceeds         	decimal(19,2),
		var_proceeds       	decimal(19,2),
		flagconsider 		char(1) 			
	)
	IF (@ayear IS NULL) 
	BEGIN
		SELECT * FROM  #fin_residual 
		RETURN
	END

	DECLARE @level_input tinyint
	SELECT @level_input = ISNULL(nlevel ,@nlevel) from fin where idfin = @idfin
	-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3
	IF (@nlevel < @level_input ) AND (@idfin is not null)
	BEGIN
		SET  @nlevel = @level_input
	END

	DECLARE @levelusable 		tinyint
	SELECT  @levelusable = MIN(nlevel) FROM finlevel where flag&2 <> 0

	DECLARE @idupboriginal 		varchar(36)
	SET 	@idupboriginal= @idupb
	IF (@showchildupb = 'S') set @idupb=@idupb+'%' 
	DECLARE @assessmentphase     	tinyint
	DECLARE @phasemax          	tinyint
	
	SELECT 	@assessmentphase =  assessmentphasecode
	FROM 	config
	WHERE 	ayear = @ayear
	IF @assessmentphase IS NULL
	BEGIN
		SELECT 	@assessmentphase = incomefinphase
		FROM 	uniconfig
	END
	SELECT 	@phasemax = MAX(nphase)
	FROM 	incomephase
	
	DECLARE @cashvaliditykind int
	SELECT	@cashvaliditykind = cashvaliditykind
	FROM 	config
	WHERE 	ayear = @ayear
	INSERT INTO #fin_residual
		(
		idfin			, 
		codefin			,
		title			,
		finprintingorder	,
		nlevel			,
		codeupb			,
		idupb 			,
		upb   			,
		upbprintingorder	,
		flagconsider	
		)
	SELECT DISTINCT
		F.idfin			,
		F.codefin		,
		F.title			, 
		F.printingorder		,
		F.nlevel		,
		U.codeupb		,
		U.idupb 		,
		U.title  		,
		U.printingorder	,
		CASE	WHEN (@hierarchy ='N') THEN 'S' 
			WHEN (@hierarchy ='S') AND (F.nlevel >= @levelusable) 
				AND 	(finlast.idfin is not null)
				THEN 'S'	
			ELSE 'N'						
		END		
	FROM incomeyear
	JOIN upb U
		on  incomeyear.idupb = U.idupb 
	JOIN fin F
		on  incomeyear.idfin = F.idfin 
	JOIN finlink
		ON  finlink.idchild = F.idfin and finlink.nlevel = @nlevel
	JOIN incometotal
		ON  incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	LEFT OUTER JOIN finlast 
		ON F.idfin = finlast.idfin
	WHERE F.ayear =@ayear AND ((F.flag&1)=0) --  Entrata
		AND (@idfin IS NULL  OR finlink.idparent = @idfin )
	    	AND (U.idupb like @idupb and U.active='S')
		AND ((@hierarchy ='N' AND F.nlevel = @nlevel) OR (@hierarchy ='S' and F.nlevel >=  @nlevel))
		AND ((incometotal.flag&1)= 1) --Residuo
		AND incomeyear.ayear=@ayear


	UPDATE #fin_residual
		SET assessments = 
			ISNULL((SELECT SUM(incomeyear.amount)
				FROM incomeyear
				JOIN income
					ON  income.idinc = incomeyear.idinc
					AND incomeyear.ayear = @ayear
				JOIN incometotal
					ON  incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
				JOIN finlink
					ON  finlink.idchild  = incomeyear.idfin 
				WHERE 	income.adate <= @date 
					AND income.nphase = @assessmentphase
					AND ((incometotal.flag&1)= 1) --Residuo
					AND finlink.idparent = #fin_residual.idfin
					AND incomeyear.idupb = #fin_residual.idupb), 0.0),
		var_assessments =
			ISNULL((SELECT SUM(incomevar.amount)
				FROM incomevar
				JOIN incomeyear
					ON  incomeyear.idinc = incomevar.idinc
					AND incomeyear.ayear = @ayear
				JOIN income
					ON income.idinc = incomeyear.idinc
				JOIN finlink
					ON  finlink.idchild = incomeyear.idfin 
				JOIN incometotal
					ON incomeyear.idinc = incometotal.idinc
					AND incomeyear.ayear = incometotal.ayear
				WHERE 	incomevar.yvar = @ayear
				AND incomevar.adate <= @date
				AND income.nphase = @assessmentphase
				AND ((incometotal.flag&1)= 1) -- Residuo
				AND finlink.idparent = #fin_residual.idfin
				AND incomeyear.idupb = #fin_residual.idupb), 0.0)
	
	UPDATE #fin_residual
		SET proceeds = 
			ISNULL((SELECT SUM(HPV.amount)
				FROM historyproceedsview HPV
				JOIN finlink
					ON  finlink.idchild = HPV.idfin 
				WHERE 	HPV.ymov = @ayear
					AND HPV.competencydate <= @date
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
			WHERE 	incomevar.yvar = @ayear
				AND incomevar.adate <= @date
				AND HPV.competencydate <= @date
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
		UPDATE 	#fin_residual 
		SET  
			upbprintingorder = null,
			upb =  null,
			idupb = null,
			codeupb = null
	IF (@suppressifblank = 'S') -->  cancella le righe sottostanti la categoria
	BEGIN
		DELETE 
		FROM #fin_residual 
		WHERE 
			(isnull(assessments,0.0) =0 AND 
			isnull(var_assessments,0.0) =0 AND 
			isnull(proceeds,0.0) =0 AND 
			isnull(var_proceeds,0.0) =0 AND
			(select nlevel from fin FFF where FFF.idfin= #fin_residual.idfin)>=2
			) 
	END
IF (@showupb <>'S') 
	BEGIN
	SELECT 
	idfin,
	codeupb,
	idupb,
	upb,
	upbprintingorder,
	codefin,
	title,
	finprintingorder,
	nlevel,
	sum(isnull(assessments,0.0)) 		as	'assessments',
	sum(isnull(var_assessments,0.0)) 	as	'var_assessments',
	sum(isnull(proceeds,0.0)) 		as	'proceeds',
	sum(isnull(var_proceeds,0.0)) 		as	'var_proceeds',  
	flagconsider
	FROM #fin_residual 
	GROUP BY idupb,
		idfin,
		codeupb,
		upbprintingorder,
		upb,
		codefin,
		title,
		finprintingorder,
		nlevel,
		flagconsider	
	ORDER BY upbprintingorder,finprintingorder
	END
ELSE
	SELECT 
		idfin,
		codeupb,
		idupb,
		upb,
		upbprintingorder,
		codefin,
		title,
		finprintingorder,
		nlevel,
		assessments,
		var_assessments,
		proceeds,
		var_proceeds,
		flagconsider
	FROM #fin_residual 
	ORDER BY upbprintingorder,finprintingorder
END
go

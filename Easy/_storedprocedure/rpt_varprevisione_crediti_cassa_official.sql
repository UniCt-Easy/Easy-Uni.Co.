
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_varprevisione_crediti_cassa_official]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_varprevisione_crediti_cassa_official]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


-- exec rpt_varprevisione_crediti_cassa_official 2016, null,null,'PREVISIONE','N','N','N',null,3838,null,null,null,null
-- setuser 'amministrazione'
CREATE   PROCEDURE rpt_varprevisione_crediti_cassa_official
	@yvar          	int, 
	@nvarbegin   	int,
	@nvarend     	int,
	@reportkind    	varchar(20),
	@showupb 	char(1),
	@compress 	char(1),
	@showcategory 	char(1),
	@nenactment		int,   -- atto amministrativo contenente le variazioni
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
	
	
	DECLARE @yenactment   		int
	SET 	@yenactment = @yvar

	DECLARE @idenactment	int
	
	SET     @idenactment = (SELECT idenactment
			    FROM enactment 
			   WHERE enactment.yenactment = @yenactment
	   		     AND enactment.nenactment = @nenactment)	
	
	CREATE TABLE #printing
	(
		nvar int 
	)

	IF @reportkind = 'PREVISIONE'
	BEGIN
		
		INSERT INTO #printing (nvar) 
		SELECT finvar.nvar 
		FROM finvar 
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb		
		WHERE   finvar.official = 'S' 
			AND finvar.yvar = @yvar
			AND finvar.variationkind <> 5
			AND (finvar.flagprevision = 'S' OR finvar.flagsecondaryprev = 'S')
			AND (finvar.idenactment = @idenactment OR @idenactment IS NULL)	
			AND ((finvar.nofficial BETWEEN @nvarbegin AND @nvarend) OR 
			     (@nvarbegin IS NULL) OR (@nvarend IS NULL))
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01 OR upb.idsor01 IS NULL)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02 OR upb.idsor02 IS NULL)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03 OR upb.idsor03 IS NULL)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04 OR upb.idsor04 IS NULL)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05 OR upb.idsor05 IS NULL)
		GROUP BY finvar.nvar 	
	END
	
	IF @reportkind = 'CREDITI'
	BEGIN
		INSERT INTO #printing (nvar) 
		SELECT finvar.nvar 
		FROM finvar 
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb
		WHERE  finvar.official = 'S' 
			AND finvar.yvar = @yvar
			AND finvar.flagcredit = 'S'
			AND (finvar.idenactment = @idenactment OR @idenactment IS NULL)	
			AND ((finvar.nofficial BETWEEN @nvarbegin AND @nvarend) OR (@nvarbegin IS NULL) OR (@nvarend IS NULL))
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01 OR upb.idsor01 IS NULL)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02 OR upb.idsor02 IS NULL)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03 OR upb.idsor03 IS NULL)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04 OR upb.idsor04 IS NULL)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05 OR upb.idsor05 IS NULL)
	END
	
	IF @reportkind = 'CASSA'
	BEGIN
		INSERT INTO #printing (nvar) 
		SELECT finvar.nvar 
		FROM finvar 
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb
		WHERE   finvar.official = 'S' 
			AND finvar.yvar = @yvar
			AND  finvar.flagproceeds = 'S'
			AND (finvar.idenactment = @idenactment OR @idenactment IS NULL)	
			AND ((finvar.nofficial BETWEEN @nvarbegin AND @nvarend) OR (@nvarbegin IS NULL) OR (@nvarend IS NULL))
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01 OR upb.idsor01 IS NULL)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02 OR upb.idsor02 IS NULL)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03 OR upb.idsor03 IS NULL)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04 OR upb.idsor04 IS NULL)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05 OR upb.idsor05 IS NULL)		
	END

	
	DECLARE @previsionkind char(1)
	DECLARE @secprevisionkind char(1)
	
	SELECT @previsionkind =  
	 
		CASE 
			WHEN fin_kind IN (1,3) THEN 'C'
			WHEN fin_kind = 2 THEN 'S'
		END
	FROM  config 
	WHERE config.ayear = @yvar

	SELECT @secprevisionkind =  
	 
		CASE 
			WHEN fin_kind = 3 THEN 'S'
			ELSE NULL
		END
	FROM config 
	WHERE config.ayear = @yvar
	
	SELECT  --report variazioni della previsione, crediti, cassa
		SK.description as 'sortingkind01',
		S01.description as 'sorting01',
		yvar,
		nvar,
		nofficial,
		finvar.description,
		enactment,
		variationkind,
		nenactment,
		enactmentdate,
		adate,
		CASE
		   	WHEN @reportkind = 'PREVISIONE' THEN flagprevision
			ELSE null
		END as 'flagprevision',
		CASE
			WHEN @reportkind = 'PREVISIONE' THEN flagsecondaryprev
			ELSE null
		END as 'flagsecondaryprev',
		CASE
			WHEN @reportkind = 'PREVISIONE' THEN @previsionkind 
			ELSE null
		END as 'previsionkind',
		CASE
			WHEN @reportkind = 'PREVISIONE' THEN @secprevisionkind
			ELSE null
		END  as 'secprevisionkind'
	FROM finvar 
		LEFT OUTER JOIN sorting S01
				ON finvar.idsor01 = S01.idsor
		LEFT OUTER JOIN sortingkind SK
				ON SK.idsorkind = S01.idsorkind
		WHERE
			finvar.yvar = @yvar
			and finvar.nvar in (select nvar from #printing)
	ORDER BY nvar
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



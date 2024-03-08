
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_atto_previsione_crediti_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_atto_previsione_crediti_cassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	exec rpt_atto_previsione_crediti_cassa 2017, 2, 'S','S','S','previsione','P',null,null,null,null,null

CREATE   PROCEDURE rpt_atto_previsione_crediti_cassa
	@yvar          	int, 
	@nenactment		int,
	@showupb char(1),
	@layoutupb char(1),-- Code, Title,All
--	@compress char(1),
	@showcategory char(1),
	@reportkind    	varchar(20),
	@kindnumeration varchar(1),-- O Official, P Protocollo
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
	
	DECLARE @yenactment   	int
	DECLARE @idenactment	int
	DECLARE @enactmentdescription    varchar(150)
	
	SET 	@yenactment = @yvar
	SELECT  @idenactment = idenactment, @enactmentdescription = description
			    FROM enactment 
			   WHERE enactment.yenactment = @yenactment
	   		     AND enactment.nenactment = @nenactment
	
	DECLARE @nlevelcategory tinyint
	SET @nlevelcategory = 2
	
	DECLARE @fin_kind tinyint
	SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @yvar

	DECLARE @previsionkind char(1) 
	SELECT  @previsionkind =  
		 CASE 
			WHEN fin_kind IN (1,3) THEN 'C'
			WHEN fin_kind = 2 THEN 'S'
		 END
	FROM  config 
	WHERE config.ayear = @yvar

	DECLARE @secprevisionkind    char(1) 
	SELECT  @secprevisionkind  = 
		 CASE 
			WHEN fin_kind = 3 THEN 'S'
			ELSE 'N'
		END
	FROM config 
	WHERE config.ayear = @yvar

	CREATE TABLE #detail
	(
		idfin int,
		finpart char(1),
		codefin varchar(50),
		title varchar(150),
		idupb varchar(36),
		codeupb varchar(50),	
		upb varchar(150),
		descriptionvar varchar(150),
		flagprevision char(1),
		flagsecondaryprev char(1),
		description varchar(8000),
		amount decimal(19,2),
		nvar int
	)
IF @reportkind = 'PREVISIONE'
BEGIN
	insert into #detail(
		idfin,
		finpart ,
		codefin ,
		title ,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		flagprevision,
		flagsecondaryprev,
		description ,
		amount ,
		nvar
	)
	SELECT   	
		fin.idfin,
		CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
		End,
		fin.codefin,
		fin.title,
		upb.idupb,
		upb.codeupb,
		upb.title,
		finvar.description,
		finvar.flagprevision,
		finvar.flagsecondaryprev,
		finvardetail.description,
		finvardetail.amount,
		CASE
		when (@kindnumeration='P') then finvar.nvar
		when (@kindnumeration='O') then finvar.nofficial
		End
	FROM finvardetail
	JOIN finvar 
		ON finvardetail.yvar = finvar.yvar AND finvardetail.nvar = finvar.nvar
	JOIN fin
		ON fin.idfin = finvardetail.idfin
	JOIN upb
		ON upb.idupb = finvardetail.idupb 
	WHERE finvardetail.yvar = @yvar
		AND (finvar.idenactment = @idenactment)
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		and (select count(*) from finvar FV2 
				where finvar.yvar = FV2.yvar AND finvar.nvar = FV2.nvar
				and (FV2.flagprevision='S' or FV2.flagsecondaryprev='S'))>0
	ORDER BY finvardetail.nvar, fin.flag, fin.codefin,upb.codeupb
END

IF (@showupb='S') --> Rimane come prima
  Begin
	SELECT 
		finpart ,
		CASE 
			WHEN (@showcategory)='S'
			   THEN fin.codefin 
			ELSE  #detail.codefin
		END as codefin,
		CASE 
			WHEN (@showcategory)='S'
			   THEN fin.title 
			ELSE  #detail.title
		END as title,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		flagprevision,
		flagsecondaryprev,
		description ,
		amount,
		nvar,
		@previsionkind as 'previsionkind',
		@secprevisionkind as 'secprevisionkind',
		@enactmentdescription as 'enactmentdescription'
	FROM #detail
	JOIN finlink
		ON #detail.idfin = finlink.idchild and finlink.nlevel = @nlevelcategory
	JOIN fin
		ON finlink.idparent=fin.idfin
	ORDER BY nvar,finpart, #detail.codefin
  End

ELSE  --> Ora non vogliamo vedere l'upb e dobbiamo analizzare @compress

  Begin
		CREATE TABLE #detailcompact
		(
			idfin int ,
			finpart char(1),
			codefin varchar(50),
			title varchar(150),
			descriptionvar varchar(150),
			flagprevision char(1),
			flagsecondaryprev char(1),
			description varchar(8000),
			amount decimal(19,2),
			nvar int	
		)
		INSERT INTO #detailcompact(idfin,finpart,codefin,title,descriptionvar,flagprevision,
			flagsecondaryprev,amount, nvar)
		SELECT 
			idfin, 
		  	finpart,
			codefin ,
			title ,
			descriptionvar,
			flagprevision,
			flagsecondaryprev,
			isnull(sum(amount),0),
			nvar 
		FROM #detail
		GROUP BY nvar,finpart,idfin, codefin,title,descriptionvar,flagprevision,flagsecondaryprev

		DECLARE @finpart char(1)
		DECLARE @idfin int
		DECLARE @nvar int
		
		DECLARE @description varchar(200)
		DECLARE @descriptioncompact varchar(8000) 

		DECLARE rowcursor INSENSITIVE CURSOR FOR
			SELECT DISTINCT finpart,idfin,description,nvar
			FROM #detail
			FOR READ ONLY
		OPEN rowcursor FETCH  NEXT FROM rowcursor INTO @finpart,@idfin,@description, @nvar 
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #detailcompact 
			SET description = 
			CASE 
				WHEN ((len(isnull(#detailcompact.description,'')) + len(@description)) < 8000 )
				   THEN ISNULL(#detailcompact.description,'') + @description + ';'
				ELSE  ISNULL(#detailcompact.description,'') + '...;'
			END
			WHERE (idfin = @idfin and finpart = @finpart and nvar = @nvar)
		
			FETCH NEXT FROM rowcursor INTO  @finpart,@idfin,@description,@nvar 
		END 
		DEALLOCATE rowcursor
		

		SELECT 	finpart ,
			CASE 
				WHEN (@showcategory)='S'
				   THEN fin.codefin 
				ELSE  #detailcompact.codefin
			END as codefin,
			CASE 
				WHEN (@showcategory)='S'
				   THEN fin.title
				ELSE  #detailcompact.title
			END as title,
			null as idupb ,
			null as codeupb,	
			null as upb ,
			descriptionvar, 
			flagprevision,
			flagsecondaryprev,
			substring(description,1,len(description)-1) as description,    
			isnull(amount,0) as amount,
			#detailcompact.nvar,
			@previsionkind as 'previsionkind',
			@secprevisionkind as 'secprevisionkind',
			@enactmentdescription as 'enactmentdescription'
		FROM #detailcompact
		JOIN finlink
			ON #detailcompact.idfin = finlink.idchild and finlink.nlevel = @nlevelcategory
		JOIN fin
			ON finlink.idparent=fin.idfin
		ORDER BY nvar,finpart, #detailcompact.codefin
	  End	
	 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


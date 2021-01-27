
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_dettvarprevisione_crediti_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_dettvarprevisione_crediti_cassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE rpt_dettvarprevisione_crediti_cassa
	@yvar int,
	@nvar int,
	@reportkind varchar(20),
	@showupb char(1),
	@compress char(1),
	@showcategory char(1)
AS
BEGIN

-- exec rpt_dettvarprevisione_crediti_cassa 2013, 1, 'CASSA','S','S','N'
/* Versione 1.0.0 del 14/09/2007 ultima modifica: SARA */
DECLARE @nlevelcategory tinyint
set @nlevelcategory = 2

CREATE TABLE #detail
(
	nvar int,
	idfin int,
	finpart char(1),
	codefin varchar(50),
	title varchar(150),
	idupb varchar(36),
	codeupb varchar(50),	
	upb varchar(150),
	description varchar(1000),
	amount decimal(19,2),
	manager varchar(150)	
)

IF @reportkind = 'PREVISIONE'
BEGIN
	insert into #detail(
		nvar,
		idfin,
		finpart ,
		codefin ,
		title ,
		idupb ,
		codeupb,	
		upb ,
		description ,
		amount,
		manager
	)
	SELECT  
		finvardetail.nvar,	
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
		finvardetail.description,
		finvardetail.amount,
		manager.title
	FROM finvardetail
	JOIN fin
		ON fin.idfin = finvardetail.idfin
	LEFT OUTER JOIN upb
		ON upb.idupb = finvardetail.idupb
	LEFT OUTER JOIN manager
		on upb.idman = manager.idman
	WHERE finvardetail.yvar = @yvar
		AND finvardetail.nvar = @nvar
	ORDER BY fin.flag, fin.codefin
END

IF (@reportkind = 'CREDITI' OR @reportkind = 'CASSA')
BEGIN
	insert into #detail(
		nvar,
		idfin,
		finpart ,
		codefin ,
		title ,
		idupb ,
		codeupb,	
		upb ,
		description ,
		amount,
		manager 
		)
	SELECT
		finvardetail.nvar,	
		fin.idfin,
	   	CASE
			when (( fin.flag & 1)=0) then 'E'
			when (( fin.flag & 1)=1) then 'S'
		End,
		fin.codefin,
		fin.title,
		upb.idupb,
		upb.codeupb,
		upb.title ,
		finvardetail.description,
		finvardetail.amount,
		manager.title
	FROM finvardetail
	JOIN fin
		ON fin.idfin = finvardetail.idfin
		AND (( fin.flag & 1)=1) -- S
	LEFT OUTER JOIN upb
		ON upb.idupb = finvardetail.idupb
	LEFT OUTER JOIN manager
		on upb.idman = manager.idman
	WHERE finvardetail.yvar = @yvar
		AND finvardetail.nvar = @nvar
	ORDER BY fin.flag, fin.codefin
END

	
IF (@showupb='S') --> Rimane come prima
  Begin
	SELECT 
		nvar,
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
		description ,
		amount,
		manager 
	FROM #detail
	JOIN finlink
		ON #detail.idfin = finlink.idchild and finlink.nlevel = @nlevelcategory
	JOIN fin
		ON finlink.idparent=fin.idfin
	ORDER BY finpart, #detail.codefin
  End

ELSE  --> Ora non vogliamo vedere l'upb e dobbiamo analizzare @compress

  Begin
	IF (@compress='S') --> Scrive una standard
	  Begin
		IF(@showcategory='S')
		Begin
			SELECT 
			#detail.nvar,
			CASE
				when (( fin.flag & 1)=0) then 'E'
				when (( fin.flag & 1)=1) then 'S'
			End AS finpart,
			fin.codefin, 
			fin.title ,
			null as idupb ,
			null as codeupb,	
			null as upb ,
			'Dettagli diversi' as description ,
			isnull(sum(amount),0) as amount,
			null as manager
			FROM #detail
			JOIN finlink
				ON #detail.idfin = finlink.idchild 
			JOIN fin
				ON finlink.idparent = fin.idfin
			WHERE finlink.nlevel = @nlevelcategory
			GROUP BY fin.flag, fin.codefin,fin.title,#detail.nvar 
			ORDER BY fin.flag, fin.codefin
		End
		IF(@showcategory='N')
		Begin
			SELECT 
			nvar,
			finpart,
			codefin,
			title,
			null as idupb ,
			null as codeupb,	
			null as upb ,
			'Dettagli diversi' as description ,
			isnull(sum(amount),0) as amount,
			null as manager
			FROM #detail
			GROUP BY finpart, codefin, title ,nvar
			ORDER BY finpart, codefin
		End

		
	  End
	IF (@compress='N') --> Concatena le descrizioni
	  Begin

		CREATE TABLE #detailcompact
		(
			nvar int,
			idfin int ,
			finpart char(1),
			codefin varchar(50),
			title varchar(150),
			description varchar(1000),
			amount decimal(19,2)	
		)
		INSERT INTO #detailcompact(nvar, idfin,finpart,codefin,title,amount)
		SELECT 
			nvar,
			idfin, 
		  	finpart,
			codefin ,
			title ,
			isnull(sum(amount),0) 
		FROM #detail
		GROUP BY finpart,idfin, codefin,title,nvar

		DECLARE @finpart char(1)
		DECLARE @idfin int
		
		DECLARE @description varchar(200)
		DECLARE @descriptioncompact varchar(1000) 

		DECLARE rowcursor INSENSITIVE CURSOR FOR
			SELECT DISTINCT finpart,idfin,description
			FROM #detail
			FOR READ ONLY
		OPEN rowcursor FETCH  NEXT FROM rowcursor INTO @finpart,@idfin,@description 
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #detailcompact 
			SET description = 
			CASE 
				WHEN ((len(isnull(#detailcompact.description,'')) + len(@description)) < 1000 )
				   THEN ISNULL(#detailcompact.description,'') + @description + ';'
				ELSE  substring(ISNULL(#detailcompact.description,'') + '...;',1,1000)
			END
			WHERE (idfin = @idfin and finpart = @finpart)
		
			FETCH NEXT FROM rowcursor INTO  @finpart,@idfin,@description
		END 
		DEALLOCATE rowcursor
		

		SELECT 
			nvar,
			finpart ,
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
			substring(description,1,len(description)-1) as description,    
			isnull(amount,0) as amount,
			null as manager
		FROM #detailcompact
		JOIN finlink
			ON #detailcompact.idfin = finlink.idchild and finlink.nlevel = @nlevelcategory
		JOIN fin
			ON finlink.idparent=fin.idfin
		ORDER BY finpart, #detailcompact.codefin
	  End	
  End
END

 




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

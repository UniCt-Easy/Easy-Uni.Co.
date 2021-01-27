
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_attobudget_previsione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_attobudget_previsione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	exec rpt_attobudget_previsione 2017, 1, 'N','S','P',15,null,null,null,null,null

CREATE   PROCEDURE rpt_attobudget_previsione
	@yvar          	int, 
	@nenactment		int,
	@showupb char(1),
	@layoutupb char(1),-- Code, Title,All
	@kindnumeration varchar(1),-- O Official, P Protocollo
	@idsorkind_econ int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
	
		/*SELECT 	
		SPACE(50)as sortcode,
		SPACE(200)as sorting,
		'X'AS finpart ,
		SPACE(36)as idupb ,
		SPACE(50) as codeupb,	
		SPACE(150)AS upb ,
		SPACE(500) AS descriptionvar, 
		SPACE(8000)AS  description ,
		10.78 as amount, 
		2 as nvar
		return*/

	DECLARE @yenactment   	int
	DECLARE @idenactment	int
	DECLARE @enactdescription    varchar(150)
	
	SET 	@yenactment = @yvar
	SELECT    @idenactment =  idenactment, @enactdescription = description
			    FROM enactment 
			   WHERE enactment.yenactment = @yenactment
	   		     AND enactment.nenactment = @nenactment

	CREATE TABLE #detail(
		sortcode varchar(50),
		sorting varchar(200),
		finpart char(1),
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
	CREATE TABLE #detailGrp(
		sortcode varchar(50),
		sorting varchar(200),
		finpart char(1),
		idupb varchar(36),
		codeupb varchar(50),	
		upb varchar(150),
		descriptionvar varchar(150),
		description varchar(8000),
		amount decimal(19,2),
		nvar int
	)

	insert into #detail(
		sortcode ,
		sorting ,
		finpart,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		amount ,
		nvar
	)
	SELECT   	
		 (select idraggruppamento from raggruppamentobudget where patindex(raggruppamentobudget.idraggruppamento + '%', S.sortcode)>0),
		null,
		CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
		End,
		upb.idupb,
		upb.codeupb,
		upb.title,
		budgetvar.description,
		budgetvardetail.description,
		budgetvardetail.amount,
		CASE
		when (@kindnumeration='P') then budgetvar.nbudgetvar
		when (@kindnumeration='O') then budgetvar.nofficial
		End
	FROM budgetvardetail
	JOIN budgetvar			ON budgetvardetail.ybudgetvar = budgetvar.ybudgetvar AND budgetvardetail.nbudgetvar = budgetvar.nbudgetvar
	join sorting S			on budgetvardetail.idsor = S.idsor
	join finsorting 		on S.idsor = finsorting.idsor
	join fin				on fin.idfin = finsorting.idfin
	JOIN upb				ON upb.idupb = budgetvardetail.idupb 
	join finvar				on finvar.yvar = budgetvar.yvar and finvar.nvar = budgetvar.nvar
	WHERE budgetvar.yvar = @yvar
		and fin.ayear = @yvar
		AND (finvar.idenactment = @idenactment)
		and S.idsorkind = @idsorkind_econ
		AND exists (select * from raggruppamentobudget where patindex(raggruppamentobudget.idraggruppamento + '%', S.sortcode)>0)	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	ORDER BY budgetvar.nbudgetvar, S.sortcode


insert into #detailGrp(
		sortcode ,
		sorting ,
		finpart,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		amount ,
		nvar)
select 
		D.sortcode ,
		S.description,
		finpart,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		D.description ,
		sum(amount),
		nvar
from #detail D
join sorting S	 	on S.sortcode = D.sortcode and S.idsorkind  =@idsorkind_econ
group by D.sortcode ,S.description,
		finpart,idupb ,	codeupb,	upb ,		descriptionvar,
		flagprevision,		flagsecondaryprev,		d.description ,		nvar

IF (@showupb='S') --> Rimane come prima
  Begin
	
	SELECT 
		sortcode ,
		sorting ,
		finpart,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		amount ,
		nvar,
		@enactdescription as enactdescription
	FROM #detailGrp
	ORDER BY nvar,finpart,sortcode
  End

ELSE  --> Ora non vogliamo vedere l'upb e dobbiamo analizzare @compress

  Begin
		CREATE TABLE #detailcompact(
			finpart char(1),
			sortcode varchar(50),
			sorting varchar(150),
			descriptionvar varchar(150),
			description varchar(8000),
			amount decimal(19,2),
			nvar int	
		)
		INSERT INTO #detailcompact(finpart,sortcode,sorting,descriptionvar,amount, nvar)
		SELECT 
		  	finpart,
			sortcode,
			sorting,
			descriptionvar,
			isnull(sum(amount),0),
			nvar 
		FROM #detailGrp
		GROUP BY nvar,finpart, sortcode, sorting,descriptionvar

		DECLARE @sortcode varchar(50)
		DECLARE @nvar int
		
		DECLARE @description varchar(200)
		DECLARE @descriptioncompact varchar(8000) 

		DECLARE rowcursor INSENSITIVE CURSOR FOR
			SELECT DISTINCT sortcode,description,nvar
			FROM #detail
			FOR READ ONLY
		OPEN rowcursor FETCH  NEXT FROM rowcursor INTO @sortcode,@description, @nvar 
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #detailcompact 
			SET description = 
			CASE 
				WHEN ((len(isnull(#detailcompact.description,'')) + len(@description)) < 8000 )
				   THEN ISNULL(#detailcompact.description,'') + @description + ';'
				ELSE  ISNULL(#detailcompact.description,'') + '...;'
			END
			WHERE (sortcode = @sortcode and nvar = @nvar)
		
			FETCH NEXT FROM rowcursor INTO @sortcode,@description,@nvar 
		END 
		DEALLOCATE rowcursor
		
		
		SELECT 	
			sortcode,
			sorting,
			finpart ,
			null as idupb ,
			null as codeupb,	
			null AS upb ,
			null AS descriptionvar, 
			substring(description,1,len(description)-1) as description,    
			isnull(amount,0) as amount,
			nvar,
			@enactdescription as 'enactdescription'
		FROM #detailcompact
		order by nvar,finpart,sortcode

			
	  End	
	 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_attobudget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_attobudget]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	exec rpt_attobudget 2017, 4, 'S','S', null,null,null,null,null

CREATE   PROCEDURE rpt_attobudget
	@yvar          	int, 
	@nenactment		int,
	@showupb char(1),
	@layoutupb char(1),-- Code, Title,All
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
	
	DECLARE @yenactment   	int
	DECLARE @idenactment	int
	DECLARE @enactdescription    varchar(150)

	SET 	@yenactment = @yvar
	SELECT     @idenactment =  idenactment, @enactdescription = description
			    FROM accountenactment 
			   WHERE accountenactment.yenactment = @yenactment
	   		     AND accountenactment.nenactment = @nenactment
	

	CREATE TABLE #detail
	(
		idacc varchar(38),
		codeacc varchar(50),
		title varchar(150),
		idupb varchar(36),
		codeupb varchar(50),	
		upb varchar(150),
		descriptionvar varchar(150),
		description varchar(8000),
		amount decimal(19,2),amount2 decimal(19,2),amount3 decimal(19,2),amount4 decimal(19,2),amount5 decimal(19,2),
		nvar int
	)
 
	insert into #detail(
		idacc,
		codeacc ,
		title ,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		amount ,amount2 ,amount3 ,amount4 ,amount5,
		nvar
	)
	SELECT   	
		account.idacc,
		account.codeacc,
		account.title,
		upb.idupb,
		upb.codeupb,
		upb.title,
		accountvar.description,
		accountvardetail.description,
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount, 2),
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount2, 2),
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount3, 2),
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount4, 2),
		ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount5, 2),
		accountvar.nvar
	FROM accountvardetail
	JOIN accountvar 
		ON accountvardetail.yvar = accountvar.yvar AND accountvardetail.nvar = accountvar.nvar
	JOIN account
		ON account.idacc = accountvardetail.idacc
	JOIN upb
		ON upb.idupb = accountvardetail.idupb 
	left outer join costpartition
		on costpartition.idcostpartition = accountvardetail.idcostpartition
	left outer join costpartitiondetail
		on costpartition.idcostpartition = costpartitiondetail.idcostpartition
	WHERE accountvardetail.yvar = @yvar
		AND (accountvar.idenactment = @idenactment)
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	ORDER BY accountvardetail.nvar, account.flag, account.codeacc,upb.codeupb
	 

IF (@showupb='S') --> Rimane come prima
  Begin
	SELECT 
		#detail.codeacc,
		#detail.title,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		amount ,amount2 ,amount3 ,amount4 ,amount5,
		nvar,
		@enactdescription as enactdescription
	FROM #detail
	ORDER BY nvar,#detail.codeacc
  End

ELSE  --> Ora non vogliamo vedere l'upb e dobbiamo analizzare @compress

  Begin
		CREATE TABLE #detailcompact
		(
			idacc varchar(38) ,
			codeacc varchar(50),
			title varchar(150),
			descriptionvar varchar(150),
			description varchar(8000),
			amount decimal(19,2),amount2 decimal(19,2),amount3 decimal(19,2),amount4 decimal(19,2),amount5 decimal(19,2),
			nvar int	
		)
		INSERT INTO #detailcompact(idacc,codeacc,title,descriptionvar,amount ,amount2 ,amount3 ,amount4 ,amount5, nvar)
		SELECT 
			idacc, 
			codeacc ,
			title ,
			descriptionvar,
			isnull(sum(amount),0),isnull(sum(amount2),0),isnull(sum(amount3),0),isnull(sum(amount4),0),isnull(sum(amount5),0),
			nvar 
		FROM #detail
		GROUP BY nvar,idacc, codeacc,title,descriptionvar

		DECLARE @idacc varchar(38)
		DECLARE @nvar int
		DECLARE @description varchar(200)
		DECLARE @descriptioncompact varchar(8000) 

		DECLARE rowcursor INSENSITIVE CURSOR FOR
			SELECT DISTINCT idacc,description,nvar
			FROM #detail
			FOR READ ONLY
		OPEN rowcursor FETCH  NEXT FROM rowcursor INTO @idacc,@description, @nvar 
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #detailcompact 
			SET description = 
			CASE 
				WHEN ((len(isnull(#detailcompact.description,'')) + len(@description)) < 8000 )
				   THEN ISNULL(#detailcompact.description,'') + @description + ';'
				ELSE  ISNULL(#detailcompact.description,'') + '...;'
			END
			WHERE (idacc = @idacc  and nvar = @nvar)
		
			FETCH NEXT FROM rowcursor INTO  @idacc,@description,@nvar 
		END 
		DEALLOCATE rowcursor
		

		SELECT 	
			#detailcompact.codeacc,
			#detailcompact.title,
			null as idupb ,
			null as codeupb,	
			null as upb ,
			descriptionvar, 
			substring(description,1,len(description)-1) as description,    
			isnull(amount,0) as amount,
			isnull(amount2,0) as amount2,
			isnull(amount3,0) as amount3,
			isnull(amount4,0) as amount4,
			isnull(amount5,0) as amount5,
			#detailcompact.nvar,
			@enactdescription as 'enactdescription'
		FROM #detailcompact
		ORDER BY nvar, #detailcompact.codeacc
	  End	
	 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


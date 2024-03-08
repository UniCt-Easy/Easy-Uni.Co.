
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_dettvarbudget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_dettvarbudget]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE rpt_dettvarbudget
	@ybudgetvar int,
	@nbudgetvar int,
	@showupb char(1),
	@compress char(1)
AS
BEGIN

-- exec rpt_dettvarbudget 2014, 1, 'S','N'
declare @lencodeacc int
set @lencodeacc = isnull((select convert(varchar(100),paramvalue) from reportadditionalparam where paramname='LunghezzaCodiceConto' and reportname='variazioni_budget'),50)
if (@lencodeacc>50) set @lencodeacc = 50


CREATE TABLE #detail
(
	idsor int,
	sortcode varchar(50),
	title varchar(200),
	idupb varchar(36),
	codeupb varchar(50),	
	upb varchar(150),
	description varchar(1000),
	amount decimal(19,2),
	codeacc varchar(50)
)

	insert into #detail(
		idsor,
		sortcode,
		title,
		idupb,
		codeupb,	
		upb,
		description,
		amount,
		codeacc
	)
	SELECT   	
		sorting.idsor,
		sorting.sortcode,
		sorting.description,
		upb.idupb,
		upb.codeupb,
		upb.title,
		budgetvardetail.description,
		budgetvardetail.amount,
		substring(account.codeacc, 1, @lencodeacc)
	FROM budgetvardetail
	JOIN sorting
		ON sorting.idsor = budgetvardetail.idsor
	LEFT OUTER JOIN upb
		ON upb.idupb = budgetvardetail.idupb
	left outer join	accountsorting
		ON sorting.idsor = accountsorting.idsor
	left outer join account
		ON account.idacc = accountsorting.idacc and account.ayear =	@ybudgetvar
	WHERE budgetvardetail.ybudgetvar = @ybudgetvar
		AND budgetvardetail.nbudgetvar = @nbudgetvar
	ORDER BY sorting.sortcode
	
IF (@showupb='S') --> Rimane come prima
  Begin
	SELECT 
		#detail.sortcode as sortcode,
		#detail.title as title,
		idupb ,
		codeupb,	
		upb ,
		description ,
		amount,
		codeacc
	FROM #detail
	ORDER BY  #detail.sortcode
  End

ELSE  --> Ora non vogliamo vedere l'upb e dobbiamo analizzare @compress

  Begin
	IF (@compress='S') --> Scrive una standard
	  Begin
			SELECT 
			sortcode,
			title,
			null as idupb ,
			null as codeupb,	
			null as upb ,
			'Dettagli diversi' as description ,
			isnull(sum(amount),0) as amount,
			codeacc
			FROM #detail
			GROUP BY sortcode, title ,codeacc
			ORDER BY sortcode
	  End
	IF (@compress='N') --> Concatena le descrizioni
	  Begin
		CREATE TABLE #detailcompact
		(
			idsor int ,
			sortcode varchar(50),
			title varchar(200),
			description varchar(1000),
			amount decimal(19,2), 
			codeacc varchar(50)	
		)
		INSERT INTO #detailcompact(idsor,sortcode,title,amount,codeacc)
		SELECT 
			idsor, 
			sortcode ,
			title ,
			isnull(sum(amount),0),
			codeacc 
		FROM #detail
		GROUP BY idsor, sortcode,title,codeacc

		DECLARE @idsor int
		
		DECLARE @description varchar(200)
		DECLARE @descriptioncompact varchar(1000) 

		DECLARE rowcursor INSENSITIVE CURSOR FOR
			SELECT DISTINCT idsor,description
			FROM #detail
			FOR READ ONLY
		OPEN rowcursor FETCH  NEXT FROM rowcursor INTO @idsor,@description 
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #detailcompact 
			SET description = 
			CASE 
				WHEN ((len(isnull(#detailcompact.description,'')) + len(@description)) < 1000 )
				   THEN ISNULL(#detailcompact.description,'') + @description + ';'
				ELSE  ISNULL(#detailcompact.description,'') + '...;'
			END
			WHERE (idsor = @idsor )
		
			FETCH NEXT FROM rowcursor INTO  @idsor,@description
		END 
		DEALLOCATE rowcursor
		

		SELECT 	
			sortcode,
			title,
			null as idupb ,
			null as codeupb,	
			null as upb ,
			substring(description,1,len(description)-1) as description,    
			isnull(amount,0) as amount,
			codeacc as codeacc
		FROM #detailcompact
		ORDER BY  sortcode
	  End	
  End
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

  

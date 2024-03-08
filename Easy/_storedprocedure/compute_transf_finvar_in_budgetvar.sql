
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_transf_finvar_in_budgetvar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_transf_finvar_in_budgetvar]
GO

CREATE PROCEDURE [compute_transf_finvar_in_budgetvar]
(
	@ayear int,
	@idsorkind int,
	@replace char(1)
)
AS BEGIN
-- compute_transf_finvar_in_budgetvar 2015, 11, 'S'
-- setuser 'amm'

CREATE TABLE #budgetvar
(
	ybudgetvar int,
	nbudgetvar int,
	yvar int,
	nvar int,
	adate smalldatetime ,
	idstatus int,
	description varchar(150),
	official char(1),
	nofficial int,
	idsor02	int,
	idsor03	int,
	idsor04	int,
	idsor05	int,
	new char(1)
)

CREATE TABLE #budgetvardetail
(
	ybudgetvar int,
	nbudgetvar int,
	yvar int,
	nvar int,
	rownum int,
	idupb varchar(36),
	idfin int,
	amount decimal (19,2),
	idsor int,
	description varchar(150)
)


INSERT INTO #budgetvardetail
(	yvar,	nvar,	rownum,	idupb,	idfin,	amount,	idsor,	description )
SELECT 
	fd.yvar,	fd.nvar,	
--	fd.rownum,	
	DENSE_RANK() OVER(PARTITION BY   fd.nvar order by fd.rownum,fd.idupb, fd.idfin,s.idsor),
	u.idupb,	f.idfin,	fd.amount * fs.quota,	s.idsor,	fd.description
FROM finvardetail fd
JOIN finvar fv			ON fv.yvar = fd.yvar AND fv.nvar = fd.nvar
JOIN fin f		        ON f.idfin = fd.idfin 
JOIN finlast fl			ON f.idfin = fl.idfin
JOIN upb u				ON u.idupb = fd.idupb
JOIN finsorting fs		ON f.idfin = fs.idfin
JOIN sorting s			ON  s.idsor = fs.idsor
WHERE f.ayear = @ayear
  AND s.idsorkind = @idsorkind
  --AND fv.idfinvarstatus = 5    task 8209
  AND ISNULL(fv.flagprevision,'N') = 'S'
  AND fv.variationkind <> 5 -- > Esclude quelle di Tipo Iniziale. Vedi task 6651
  AND fv.yvar = @ayear

  
INSERT INTO #budgetvar
(	yvar,	nvar,	adate ,	description,	idsor02,	idsor03,	idsor04,	idsor05,	new,official, idstatus)
SELECT 
	fv.yvar,	fv.nvar,	fv.adate,	fv.description,	fv.idsor02,	fv.idsor03,	fv.idsor04,	fv.idsor05,	'N',
	fv.official, fv.idfinvarstatus
FROM finvar fv
WHERE EXISTS (SELECT * 
				FROM #budgetvardetail 
			   WHERE #budgetvardetail.yvar = fv.yvar AND
					 #budgetvardetail.nvar = fv.nvar)

UPDATE #budgetvar set new = 'S'
WHERE  NOT EXISTS (SELECT * FROM budgetvar B 
					WHERE B.yvar = #budgetvar.yvar AND
					      B.nvar = #budgetvar.nvar AND
					      B.idsorkind = @idsorkind)

UPDATE #budgetvar 
   SET 
		ybudgetvar = B.ybudgetvar,
		nbudgetvar = B.nbudgetvar
FROM budgetvar B 
WHERE B.yvar = #budgetvar.yvar AND
	  B.nvar = #budgetvar.nvar AND
      B.idsorkind = @idsorkind AND
      #budgetvar.new = 'N'


UPDATE #budgetvardetail 
   SET 
		ybudgetvar = B.ybudgetvar,
		nbudgetvar = B.nbudgetvar
FROM #budgetvar B 
WHERE B.yvar = #budgetvardetail.yvar AND
	  B.nvar = #budgetvardetail.nvar AND
      B.new = 'N'




DECLARE @yvar int
DECLARE @nvar int
DECLARE @nbudgetvar   int 
DECLARE @nofficial   int 
declare @official char(1)

DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT  yvar,nvar,official
FROM    #budgetvar 
WHERE   #budgetvar.new = 'S'
ORDER BY yvar, nvar

FOR READ ONLY
OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO @yvar, @nvar, @official
WHILE @@FETCH_STATUS = 0
BEGIN 
	
		SET 	@nbudgetvar   = ISNULL((SELECT MAX(nbudgetvar) FROM budgetvar WHERE ybudgetvar = @ayear),0) +1
		SET 	@nofficial   = ISNULL((SELECT MAX(nofficial) FROM budgetvar WHERE ybudgetvar = @ayear),0) +1
		if (@official <> 'S') set @nofficial=null
		
		INSERT INTO budgetvar 
		(
				nbudgetvar,	ybudgetvar,
				yvar,		nvar,		adate,		description,
				rtf,		txt,
				official,		nofficial,
				idbudgetvarstatus,
				idsorkind,
				ct,			cu,			lt,			lu
		)
		SELECT 
				@nbudgetvar,	@ayear,
				yvar,			nvar,	#budgetvar.adate,		#budgetvar.description,
				null,		null,
				@official ,	@nofficial,			
				idstatus,
				@idsorkind,
				GetDate(),	'finvar_trasf',		GetDate(),	'finvar_trasf'	
				FROM  #budgetvar 
				WHERE #budgetvar.yvar = @yvar 
				AND   #budgetvar.nvar = @nvar
			
		INSERT INTO budgetvardetail
			(
				nbudgetvar,	ybudgetvar,	idupb,amount,	description,idsor,	rownum,
				ct,				cu,				lt,				lu
			)
			SELECT 
				@nbudgetvar,	@ayear,	#budgetvardetail.idupb,	#budgetvardetail.amount,	#budgetvardetail.description,
				#budgetvardetail.idsor,	
				#budgetvardetail.rownum,
				GetDate(),		'finvar_trasf',			GetDate(),			'finvar_trasf'
			FROM #budgetvardetail
		   WHERE #budgetvardetail.yvar = @yvar
			 AND #budgetvardetail.nvar = @nvar	
	
	FETCH NEXT FROM rowcursor
	INTO @yvar, @nvar,@official
END 
DEALLOCATE rowcursor
 

IF (UPPER(@replace) = 'S')
BEGIN
 
	DELETE FROM budgetvar WHERE 
		ybudgetvar = @ayear 
	AND NOT EXISTS (SELECT * 
			 FROM #budgetvardetail
			WHERE #budgetvardetail.yvar = budgetvar.yvar AND  
			      #budgetvardetail.nvar = budgetvar.nvar 
			 )

	update budgetvar set idbudgetvarstatus= 
				(select idstatus from #budgetvar where 
						#budgetvar.yvar = budgetvar.yvar AND  
						#budgetvar.nvar = budgetvar.nvar 
						)
	where idsorkind= @idsorkind AND exists
					(select * from #budgetvar where 
						#budgetvar.yvar = budgetvar.yvar AND  
						#budgetvar.nvar = budgetvar.nvar 
						)

	
	DELETE FROM budgetvardetail WHERE 
		ybudgetvar = @ayear 
		AND NOT EXISTS (SELECT * 
			 FROM budgetvar
			WHERE budgetvar.ybudgetvar = budgetvardetail.ybudgetvar AND  
			      budgetvar.nbudgetvar = budgetvardetail.nbudgetvar
			 )


	DELETE FROM budgetvardetail WHERE 
	EXISTS (SELECT * 
			 FROM #budgetvardetail
			 JOIN #budgetvar on 
				#budgetvardetail.ybudgetvar = #budgetvar.ybudgetvar AND  
			      #budgetvardetail.nbudgetvar = #budgetvar.nbudgetvar 
			WHERE #budgetvardetail.ybudgetvar = budgetvardetail.ybudgetvar AND  
			      #budgetvardetail.nbudgetvar = budgetvardetail.nbudgetvar  
				   AND #budgetvar.new = 'N'
			 )
			 			      

    INSERT INTO  budgetvardetail
		(
    		nbudgetvar,	ybudgetvar,		idupb,	amount,		
			description,	idsor,	rownum,
			ct,			cu,			lt,			lu
		)
	SELECT 
			#budgetvardetail.nbudgetvar,	#budgetvardetail.ybudgetvar,	#budgetvardetail.idupb,	#budgetvardetail.amount,
			#budgetvardetail.description,	#budgetvardetail.idsor,		
			#budgetvardetail.rownum,
			GetDate(),			'finvar_trasf',			GetDate(),			'finvar_trasf'
		FROM #budgetvardetail
		JOIN #budgetvar 	  ON #budgetvar.yvar = #budgetvardetail.yvar	 AND #budgetvar.nvar = #budgetvardetail.nvar	
		WHERE #budgetvar.new = 'N'    
END
	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

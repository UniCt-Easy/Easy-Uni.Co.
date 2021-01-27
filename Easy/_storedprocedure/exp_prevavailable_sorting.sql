
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prevavailable_sorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prevavailable_sorting]
GO

CREATE  PROCEDURE exp_prevavailable_sorting
(
	@ayear int,
	@idsorkind int
)
AS BEGIN

CREATE TABLE #previsionsor
(
	ayear int,
	idsor int,
	idsorkind int,
	expenseprevision decimal(19,2),	
	incomeprevision decimal(19,2),	
	expense_var decimal(19,2),	
	income_var decimal(19,2),	
	expense decimal(19,2),	
	income decimal(19,2),	
	incomeprevavailable decimal(19,2),	
	expenseprevavailable decimal(19,2)
)

INSERT INTO #previsionsor
(
	ayear,
	idsor,
	idsorkind,
	expenseprevision,
	incomeprevision
)
SELECT 	@ayear,
       	SORT.idsor,
       	SORT.idsorkind,
   	SUM(ISNULL(PREV.expenseprevision,0)),
	SUM(ISNULL(PREV.incomeprevision,0))
FROM sortingprev PREV
JOIN sorting SORT
	ON PREV.idsor = SORT.idsor
JOIN sortinglink SORLINK 
	ON SORLINK.idchild =  PREV.idsor
WHERE SORT.idsor = PREV.idsor
	AND SORT.idsorkind = @idsorkind
	AND PREV.ayear = @ayear
	AND SORLINK.nlevel = SORT.nlevel
	AND SORT.nlevel = (SELECT  MIN(nlevel) 
			FROM    sortinglevel                 
			WHERE   idsorkind = @idsorkind 
			AND     ((flag&2)<>0))
GROUP BY SORT.idsor,SORT.idsorkind

-- inserisce quelle imputate alle var. che non hanno la previsione. Il distinct serve perchè le var possono essere + di 2
INSERT INTO #previsionsor
(
	ayear,
	idsor,
	idsorkind,
	expenseprevision,
	incomeprevision
)
SELECT DISTINCT
	@ayear,
       	SORT.idsor,
       	SORT.idsorkind,
   	0,
	0
FROM sortingprevincomevar SORVAR
JOIN    sorting SORT
	ON SORVAR.idsor = SORT.idsor
JOIN sortinglink SORLINK 
	ON SORLINK.idchild =  SORVAR.idsor
WHERE   SORT.idsor = SORVAR.idsor
	AND SORT.idsorkind = @idsorkind
	AND SORLINK.nlevel = SORT.nlevel
	AND SORT.nlevel = (SELECT  MIN(nlevel) 
			FROM sortinglevel 
	  		WHERE   idsorkind = @idsorkind 	AND ((flag&2)<>0))
	AND SORVAR.ayear = @ayear 
	AND NOT EXISTS (select * from #previsionsor where ayear = @ayear and idsor = SORVAR.idsor)

INSERT INTO #previsionsor
(
	ayear,
	idsor,
	idsorkind,
	expenseprevision,
	incomeprevision
)
SELECT 	DISTINCT
	@ayear,
       	SORT.idsor,
       	SORT.idsorkind,
   	0,
	0
FROM sortingprevexpensevar SORVAR
JOIN    sorting SORT
	ON SORVAR.idsor = SORT.idsor
JOIN sortinglink SORLINK 
	ON SORLINK.idchild =  SORVAR.idsor
WHERE   SORT.idsor = SORVAR.idsor
	AND SORT.idsorkind = @idsorkind
	AND SORLINK.nlevel = SORT.nlevel
	AND SORT.nlevel = (SELECT  MIN(nlevel) 
			FROM sortinglevel 
	  		WHERE   idsorkind = @idsorkind 	AND ((flag&2)<>0))
	AND SORVAR.ayear = @ayear 
	AND NOT EXISTS (select * from #previsionsor where ayear = @ayear and idsor = SORVAR.idsor)

UPDATE #previsionsor SET
	income_var  = ( SELECT SUM(amount)
		FROM    sortingprevincomevar SORVAR
		JOIN    sorting SORT
			ON SORVAR.idsor = SORT.idsor
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild =  SORVAR.idsor
		WHERE   SORT.idsorkind = #previsionsor.idsorkind
			AND SORLINK.idparent = #previsionsor.idsor	
			AND ayear = @ayear 
	),

	expense_var  = ( SELECT SUM(amount)
		FROM    sortingprevexpensevar SORVAR
		JOIN    sorting SORT
			ON SORVAR.idsor = SORT.idsor
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild =  SORVAR.idsor
		WHERE   SORT.idsorkind = #previsionsor.idsorkind
			AND SORLINK.idparent = #previsionsor.idsor	
			AND ayear = @ayear 
	),
	income = ( SELECT  SUM(amount) 
		FROM    incomesorted SORT
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild = SORT.idsor
		WHERE idsorkind = #previsionsor.idsorkind
		AND SORLINK.idparent = #previsionsor.idsor	
		AND SORT.ayear = @ayear 
	), 
	expense = ( SELECT SUM(amount) 
		FROM    expensesorted SORT
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild = SORT.idsor
		WHERE idsorkind = #previsionsor.idsorkind
		AND SORLINK.idparent = #previsionsor.idsor	
		AND SORT.ayear = @ayear )

UPDATE #previsionsor 
	SET expenseprevavailable = ( 
		ISNULL(expenseprevision,0) + 
		ISNULL(expense_var,0) - 
		ISNULL(expense,0) 
	),
		
	incomeprevavailable = ( 
		ISNULL(incomeprevision,0) + 
		ISNULL(income_var,0) - 
		ISNULL(income,0) 
	)

-----------------------------------------
-- Ora fa l'UPDATE o la INSERT nel DB nell'esercizio successivo
-----------------------------------------

DECLARE @nextayear int
SET @nextayear = @ayear +1

UPDATE sortingprev SET 
		expenseprevision = isnull(#previsionsor.expenseprevavailable,0),
		incomeprevision = isnull(#previsionsor.incomeprevavailable,0),
		lu = 'TRASFERIMENTO'
		FROM #previsionsor
	WHERE sortingprev.ayear = @nextayear
		AND sortingprev.idsor = #previsionsor.idsor

INSERT INTO sortingprev (ayear,idsor,expenseprevision,incomeprevision,lt,lu,ct,cu) 
SELECT  @nextayear,
	idsor,
	isnull(expenseprevavailable,0),
	isnull(incomeprevavailable,0),
	getdate(),'TRASFERIMENTO',getdate(),'TRASFERIMENTO'
FROM #previsionsor
WHERE NOT EXISTS (SELECT * FROM sortingprev 
		WHERE sortingprev.ayear = @nextayear 
		AND sortingprev.idsor = #previsionsor.idsor
		)
 AND (isnull(expenseprevavailable,0)> 0 OR isnull(incomeprevavailable,0)>0)

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO






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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_rendiconto_class_mov]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_rendiconto_class_mov]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- STAMPA PRINCIPALE
CREATE  PROCEDURE [rpt_rendiconto_class_mov]
	@ayear smallint,
	@idsorkind int,
	@date smalldatetime,
	@suppressifblank char(1)
AS
BEGIN

CREATE TABLE #sorting
(
	prevision_income decimal(19,2),	
	prevision_expense decimal(19,2),			
	idsor varchar(32),
	code_lev1 varchar(50),
	code_lev2 varchar(50),		
	code_lev3 varchar(50),
	code_lev4 varchar(50),	
	code_lev5 varchar(50), --agg
	code_lev6 varchar(50), --agg
	nlevel tinyint,
	var_income decimal(19,2),			
	income decimal(19,2),			
	var_expense decimal(19,2),			
	expense decimal(19,2)			
)

DECLARE @usablesortinglevel int

/*SELECT  @usablesortinglevel = MIN(nlevel)
	FROM sortinglevel
	WHERE idsorkind = @idsorkind
	AND (flag&2) <> 0*/

SELECT  @usablesortinglevel = MAX(nlevel)
	FROM sortinglevel
	WHERE idsorkind = @idsorkind
	AND (flag&2) <> 0

IF 	@usablesortinglevel > 6
	SELECT @usablesortinglevel = 6

print @usablesortinglevel
INSERT INTO #sorting
	(
	idsor,
	code_lev1,
	code_lev2,
	code_lev3,
	code_lev4,
	code_lev5,
	code_lev6,
	nlevel,
	prevision_income,
	prevision_expense
	)
SELECT 
	c6.idsor, 
	c1.sortcode,
	c2.sortcode,
	c3.sortcode,
	c4.sortcode,
	c5.sortcode,
	c6.sortcode,
	c6.nlevel,
	ISNULL(p6.incomeprevision, 0.0),
	ISNULL(p6.expenseprevision, 0.0)
FROM sorting c6
LEFT OUTER JOIN sorting c5
	ON c5.idsorkind = c6.idsorkind
	AND c5.idsor = c6.paridsor
LEFT OUTER JOIN sorting c4
	ON c4.idsorkind = c5.idsorkind
	AND c4.idsor = c5.paridsor
LEFT OUTER JOIN sorting c3
	ON c3.idsorkind = c4.idsorkind
	AND c3.idsor = c4.paridsor
LEFT OUTER JOIN sorting c2
	ON c2.idsorkind = c3.idsorkind
	AND c2.idsor = c3.paridsor
LEFT OUTER JOIN sorting c1
	ON c1.idsorkind = c2.idsorkind 
	AND c1.idsor = c2.paridsor 
-- considero solo le previsioni inserite al livello dei nodi foglia
-- e non invece ai livelli precedenti anche se operativi
LEFT OUTER JOIN sortingprev p6 
	ON p6.idsor = c6.idsor
	AND p6.ayear = @ayear
WHERE  c6.idsorkind = @idsorkind
	AND (c6.nlevel = @usablesortinglevel
	OR (c6.nlevel < @usablesortinglevel
	AND EXISTS
	(SELECT *
	FROM sortingusable
	WHERE sortingusable.idsorkind = c6.idsorkind
	AND sortingusable.idsor = c6.idsor)))

--select * from #sorting

DECLARE @lencode_lev1 smallint
DECLARE @lencode_lev2 smallint
DECLARE @lencode_lev3 smallint
DECLARE @lencode_lev4 smallint
DECLARE @lencode_lev5 smallint
DECLARE @lencode_lev6 smallint

SELECT @lencode_lev1 = flag/256
		FROM sortinglevel
		WHERE idsorkind = @idsorkind
		AND nlevel = '1'
SELECT @lencode_lev2 = flag/256
		FROM sortinglevel
		WHERE idsorkind = @idsorkind
		AND nlevel = '2'
SELECT @lencode_lev3 = flag/256
		FROM sortinglevel
		WHERE idsorkind = @idsorkind
		AND nlevel = '3'
SELECT @lencode_lev4 = flag/256
		FROM sortinglevel
		WHERE idsorkind = @idsorkind
		AND nlevel = '4'
SELECT @lencode_lev5 = flag/256
		FROM sortinglevel
		WHERE idsorkind = @idsorkind
		AND nlevel = '5'
SELECT @lencode_lev6 = flag/256
		FROM sortinglevel
		WHERE idsorkind = @idsorkind
		AND nlevel = '6'

/* 

Tutte le parti commentate sono dovute ad una modifica sull'output, bisogna visualizzare unicamente il codice a livello operativo
della classificazione e per questo è necessario avere nell'output la stringa contenente il codice della voce operativa 
livello = @usablesortinglevel.
Ho voluto lasciare questi commenti nel caso in cui debba essere ripristinato qualcosa in futuro.
 
DECLARE @startpos_lev1 smallint
DECLARE @startpos_lev2 smallint
DECLARE @startpos_lev3 smallint
DECLARE @startpos_lev4 smallint
DECLARE @startpos_lev5 smallint
DECLARE @startpos_lev6 smallint

SET @startpos_lev1 = 1
SET @startpos_lev2 = @startpos_lev1 + @lencode_lev1
SET @startpos_lev3 = @startpos_lev2 + @lencode_lev2
SET @startpos_lev4 = @startpos_lev3 + @lencode_lev3
SET @startpos_lev5 = @startpos_lev4 + @lencode_lev4
SET @startpos_lev6 = @startpos_lev5 + @lencode_lev5


--select @startpos_lev1, @startpos_lev2, @startpos_lev3, @startpos_lev4, @startpos_lev5, @startpos_lev6
*/

UPDATE #sorting SET code_lev1=code_lev2, code_lev2=code_lev3, code_lev3=code_lev4, code_lev4=code_lev5, code_lev5=code_lev6, code_lev6=NULL where code_lev1 is null
UPDATE #sorting SET code_lev1=code_lev2, code_lev2=code_lev3, code_lev3=code_lev4, code_lev4=code_lev5, code_lev5=code_lev6, code_lev6=NULL where code_lev1 is null
UPDATE #sorting SET code_lev1=code_lev2, code_lev2=code_lev3, code_lev3=code_lev4, code_lev4=code_lev5, code_lev5=code_lev6, code_lev6=NULL where code_lev1 is null
UPDATE #sorting SET code_lev1=code_lev2, code_lev2=code_lev3, code_lev3=code_lev4, code_lev4=code_lev5, code_lev5=code_lev6, code_lev6=NULL where code_lev1 is null
UPDATE #sorting SET code_lev1=code_lev2, code_lev2=code_lev3, code_lev3=code_lev4, code_lev4=code_lev5, code_lev5=code_lev6, code_lev6=NULL where code_lev1 is null

/*
UPDATE #sorting SET code_lev1=substring(code_lev1, @startpos_lev1,@lencode_lev1)
UPDATE #sorting SET code_lev2=substring(code_lev2, @startpos_lev2,@lencode_lev2)
UPDATE #sorting SET code_lev3=substring(code_lev3, @startpos_lev3,@lencode_lev3)
UPDATE #sorting SET code_lev4=substring(code_lev4, @startpos_lev4,@lencode_lev4)
UPDATE #sorting SET code_lev5=substring(code_lev5, @startpos_lev5,@lencode_lev5)
UPDATE #sorting SET code_lev6=substring(code_lev6, @startpos_lev6,@lencode_lev6)
*/

DECLARE @descsorkind varchar(50)
DECLARE @nphaseincome tinyint
DECLARE @nphaseexpense tinyint
SELECT 
	@descsorkind = description,
	@nphaseincome = nphaseincome,
	@nphaseexpense = nphaseexpense
FROM 	sortingkind
WHERE 	idsorkind = @idsorkind

UPDATE #sorting SET
		income = 
		ISNULL((SELECT
			SUM(incomesorted.amount)
			FROM incomesorted
			join sorting on sorting.idsor=incomesorted.idsor
			JOIN income
				ON income.idinc = incomesorted.idinc
			join sortinglink
				on sortinglink.idchild = incomesorted.idsor 
				--and sortinglink.nlevel=@usablesortinglevel
			WHERE sorting.idsorkind = @idsorkind
				AND incomesorted.ayear = @ayear
				AND income.nphase = @nphaseincome
				AND income.adate <= @date
				-- in #sorting avrò comunque i nodi foglia
				AND sortinglink.idparent = #sorting.idsor 
--			GROUP BY sortinglink.idparent
			), 0.0),
		expense = 
		ISNULL((SELECT
			SUM(expensesorted.amount)
			FROM expensesorted
			join sorting
				on expensesorted.idsor=sorting.idsor
			JOIN expense
				ON expense.idexp = expensesorted.idexp
			join sortinglink
				on sortinglink.idchild = expensesorted.idsor 
				--and sortinglink.nlevel = @usablesortinglevel
			WHERE sorting.idsorkind = @idsorkind
				AND expensesorted.ayear = @ayear
				AND expense.nphase = @nphaseexpense
				AND expense.adate <= @date
				-- in #sorting avrò comunque i nodi foglia
				AND sortinglink.idparent = #sorting.idsor
--			GROUP BY sortinglink.idparent
			), 0.0),
		var_income = 
			ISNULL((SELECT
			SUM(sortingprevincomevar.amount)
			FROM sortingprevincomevar
			join sorting on sorting.idsor = sortingprevincomevar.idsor
			join sortinglink on sortinglink.idchild = sortingprevincomevar.idsor 
			--and sortinglink.nlevel = @usablesortinglevel
			WHERE sorting.idsorkind = @idsorkind
				AND sortingprevincomevar.ayear = @ayear
				AND sortingprevincomevar.adate <= @date
				-- in #sorting avrò comunque i nodi foglia
				AND sortinglink.idparent = #sorting.idsor
--			GROUP BY sortinglink.idparent
			), 0.0),
		var_expense =
			ISNULL((SELECT
			SUM(sortingprevexpensevar.amount)
			FROM sortingprevexpensevar
			join sorting on sorting.idsor = sortingprevexpensevar.idsor
			join sortinglink on sortinglink.idchild = sortingprevexpensevar.idsor 
			--and sortinglink.nlevel = @usablesortinglevel
			WHERE sorting.idsorkind = @idsorkind
				AND sortingprevexpensevar.ayear = @ayear
				AND sortingprevexpensevar.adate <= @date
				-- in #sorting avrò comunque i nodi foglia
				AND sortinglink.idparent = #sorting.idsor
--			GROUP BY sortinglink.idparent
			), 0.0)


--select * from #sorting
DECLARE @description_lev1  varchar(50)
DECLARE @description_lev2  varchar(50)
DECLARE @description_lev3  varchar(50)
DECLARE @description_lev4  varchar(50)
DECLARE @description_lev5  varchar(50)
DECLARE @description_lev6  varchar(50)

SET  	@description_lev1 = (SELECT description 
		FROM sortinglevel 
		WHERE idsorkind = @idsorkind
			AND nlevel = 1)
SET  	@description_lev2 = (SELECT description 
		FROM sortinglevel 
		WHERE idsorkind = @idsorkind
			AND nlevel = 2)
SET  	@description_lev3 = (SELECT description 
		FROM sortinglevel 
		WHERE idsorkind = @idsorkind
			AND nlevel = 3)
SET  	@description_lev4 = (SELECT description 
		FROM sortinglevel 
		WHERE idsorkind = @idsorkind
			AND nlevel = 4)
SET  	@description_lev5 = (SELECT description 
		FROM sortinglevel 
		WHERE idsorkind = @idsorkind
			AND nlevel = 5)
SET  	@description_lev6 = (SELECT description 
		FROM sortinglevel 
		WHERE idsorkind = @idsorkind
			AND nlevel = 6)

SELECT 
	RC.idsor ,
	@idsorkind  		 'idsorkind',
	@descsorkind 		 'descsorkind',
	@usablesortinglevel 	 'usablelevel',
	RC.nlevel		 'nlevel',
	RC.code_lev1 		 'code_lev1',
	c1.description 		 'description1' ,	
	@description_lev1 	 'description_lev1' ,
	RC.code_lev2 		 'code_lev2',	
	c2.description 		 'description2',
	@description_lev2 	 'description_lev2' ,
	RC.code_lev3 		 'code_lev3',
	c3.description 		 'description3' ,
	@description_lev3 	 'description_lev3' ,
	RC.code_lev4 		 'code_lev4',
	c4.description 		 'description4' ,	
	@description_lev4 	 'description_lev4' ,	
	RC.code_lev5 		 'code_lev5',
	c5.description 		 'description5' ,	
	@description_lev5 	 'description_lev5' ,	
	RC.code_lev6 		 'code_lev6',
	c6.description 		 'description6' ,	
	@description_lev6 	 'description_lev6' ,	
	RC.prevision_income 	 'incomeprevision',		
	RC.var_income		 'incomevar',		
	RC.income 		 'incomemov',		
	RC.prevision_expense 	 'expenseprevision',	
	RC.var_expense		 'expensevar',		
	RC.expense 		 'expensemov'
FROM #sorting RC
LEFT OUTER JOIN sortinglink slk1
	ON slk1.idchild = RC.idsor AND slk1.nlevel = 1
LEFT OUTER JOIN sortinglink slk2
	ON slk2.idchild = RC.idsor AND slk2.nlevel = 2
LEFT OUTER JOIN sortinglink slk3
	ON slk3.idchild = RC.idsor AND slk3.nlevel = 3
LEFT OUTER JOIN sortinglink slk4
	ON slk4.idchild = RC.idsor AND slk4.nlevel = 4
LEFT OUTER JOIN sortinglink slk5
	ON slk5.idchild = RC.idsor AND slk5.nlevel = 5
LEFT OUTER JOIN sortinglink slk6
	ON slk6.idchild = RC.idsor AND slk6.nlevel = 6
LEFT OUTER JOIN sorting c6
	ON c6.idsorkind = @idsorkind
	AND c6.idsor = slk6.idparent
LEFT OUTER JOIN sorting c5
	ON c5.idsorkind = @idsorkind
	AND c5.idsor = slk5.idparent
LEFT OUTER JOIN sorting c4
	ON c4.idsorkind = @idsorkind
	AND c4.idsor = slk4.idparent
LEFT OUTER JOIN sorting c3
	ON c3.idsorkind = @idsorkind
	AND c3.idsor = slk3.idparent
LEFT OUTER JOIN sorting c2
	ON c2.idsorkind = @idsorkind
	AND c2.idsor = slk2.idparent
LEFT OUTER JOIN sorting c1
	ON c1.idsorkind = @idsorkind
	AND c1.idsor = slk1.idparent
WHERE ( @suppressifblank = 'N' )
OR 
( @suppressifblank = 'S' 
AND
	(isnull(RC.var_income,0) <> 0 OR isnull(RC.income,0)<> 0  
	OR isnull(RC.var_expense,0) <> 0 OR isnull(RC.expense,0)<> 0 
	OR isnull(RC.prevision_income,0)<>0 OR isnull(RC.prevision_expense,0)<>0)
)
ORDER BY RC.code_lev1 ASC,RC.code_lev2 ASC,RC.code_lev3 ASC,RC.code_lev4 ASC, code_lev5 ASC, code_lev6 ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

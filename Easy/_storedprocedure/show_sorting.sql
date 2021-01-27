
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_sorting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_sorting]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--  exec show_sorting {d '2008-02-07'}, 18, 2977, 2008
CREATE PROCEDURE show_sorting
	@date datetime,
	@idsorkind int,
	@idsor int,
	@ayear smallint
AS
BEGIN 
CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

DECLARE @nlevel tinyint
DECLARE @sortcode varchar(50)
SELECT  @nlevel = nlevel, 
	@sortcode = sortcode 
FROM    sorting
WHERE   idsorkind = @idsorkind    
	AND idsor = @idsor

print @sortcode
print @nlevel

DECLARE @levelusable tinyint
SELECT  @levelusable = MIN(nlevel) 
FROM    sortinglevel                  --sp_help sortinglevel
WHERE   idsorkind = @idsorkind 
AND     ((flag&2)<>0)

print @levelusable

DECLARE @incomeprevision decimal(19,2)
DECLARE @expenseprevision decimal(19,2)
IF (@nlevel < @levelusable)
BEGIN 
	SELECT  @incomeprevision = SUM(ISNULL(PREV.incomeprevision,0)),
		@expenseprevision = SUM(ISNULL(PREV.expenseprevision,0))
	FROM sortingprev PREV
	JOIN sorting SORT
		ON PREV.idsor = SORT.idsor
	JOIN sortinglink SORLINK 
		ON SORLINK.idchild =  PREV.idsor
	WHERE SORT.idsor = PREV.idsor
		AND SORT.idsorkind = @idsorkind
		AND PREV.ayear = @ayear
		AND SORT.nlevel = @levelusable
		AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)	
END
ELSE
BEGIN
	SELECT @incomeprevision = ISNULL(PREV.incomeprevision,0),
		@expenseprevision = ISNULL(PREV.expenseprevision,0)
	FROM sortingprev PREV
	JOIN sorting SORT
		ON PREV.idsor = SORT.idsor
	JOIN sortinglink SORLINK 
		ON SORLINK.idchild =  PREV.idsor
	WHERE SORT.idsor = PREV.idsor
		AND SORT.idsorkind = @idsorkind
		AND PREV.ayear = @ayear
		AND SORT.nlevel = @levelusable
		AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)	
END
print @incomeprevision
print @expenseprevision

DECLARE	@departmentname varchar(150)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')

DECLARE @sortingkind varchar(50)
SELECT  @sortingkind = description 
FROM    sortingkind
WHERE   idsorkind = @idsorkind

INSERT INTO #situation VALUES (@sortingkind, NULL, 'H')
DECLARE @sortinglevel varchar(50)
SELECT @sortinglevel = description 
FROM sortinglevel
WHERE idsorkind = @idsorkind AND nlevel = @nlevel

INSERT INTO #situation VALUES (@sortinglevel + ' ' + @sortcode, NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES ('E N T R A T E',NULL,'N')
INSERT INTO #situation VALUES ('Previsione entrate', @incomeprevision, '')

DECLARE @income_var decimal(19,2)
SELECT  @income_var = SUM(amount)
FROM    sortingprevincomevar SORVAR
JOIN    sorting SORT
	ON SORVAR.idsor = SORT.idsor
JOIN sortinglink SORLINK 
	ON SORLINK.idchild =  SORVAR.idsor
WHERE   SORT.idsorkind = @idsorkind
	AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)
	AND ayear = @ayear
	AND adate <= @date

DECLARE @actualprev_i decimal(19,2)
SET @actualprev_i = ISNULL(@incomeprevision, 0) + ISNULL(@income_var,0)

INSERT INTO #situation VALUES ('Variazioni entrate', @income_var, '')
INSERT INTO #situation VALUES ('Previsione attuale entrate', @actualprev_i, 'S')

DECLARE @i_phase tinyint
DECLARE @e_phase tinyint
SELECT @i_phase = nphaseincome, @e_phase = nphaseexpense
FROM sortingkind WHERE idsorkind = @idsorkind

IF (@i_phase IS NOT NULL)
BEGIN
	DECLARE @i_phasedescr varchar(50)
	SELECT @i_phasedescr = description FROM incomephase WHERE nphase = @i_phase

	DECLARE @incomeold decimal(19,2)
	SET @incomeold =
	ISNULL(
		(SELECT SUM(amount) 
		FROM incomesortedview INCSORT
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild =  INCSORT.idsor
		WHERE idsorkind = @idsorkind
			AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)
			AND INCSORT.ayear = @ayear
			AND INCSORT.ymov < @ayear
			AND adate <= @date)
	,0)

	INSERT INTO #situation VALUES('1. Movimenti (anni prec.) - (' + @i_phasedescr + ')', @incomeold, NULL)

	DECLARE @incomenew decimal(19,2)
	SET @incomenew =
	ISNULL(
		(SELECT SUM(amount) 
		FROM incomesortedview INCSORT
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild =  INCSORT.idsor
		WHERE idsorkind = @idsorkind
			AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)	
			AND INCSORT.ayear = @ayear
			AND INCSORT.ymov = @ayear
			AND adate <= @date)
	,0)

	INSERT INTO #situation VALUES('2. Movimenti (anno corrente) - (' + @i_phasedescr + ')', @incomenew, NULL)

	DECLARE @income decimal(19,2)
	SET @income = @incomeold + @incomenew

	INSERT INTO #situation VALUES('Prev. disponibile entrate su (' + @i_phasedescr + ')  [Prev. Att. - 1 - 2]', @actualprev_i - @income, 'S')

	DECLARE @i_lastphase tinyint
	SELECT @i_lastphase = MAX(nphase) FROM incomephase

       	DECLARE @tot_proceeded decimal(19,2)

	IF (@i_phase = @i_lastphase)
         BEGIN
        	SET @tot_proceeded =
        	ISNULL(
        		(SELECT SUM(curramount) 
        		FROM incomesortedview INCSORT
                        JOIN historyproceedsview HPV
                                ON HPV.idinc = INCSORT.idinc
                                AND HPV.ymov = INCSORT.ayear    
        		JOIN sortinglink SORLINK 
        			ON SORLINK.idchild =  INCSORT.idsor
        		WHERE idsorkind = @idsorkind
        			AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)	
        			AND INCSORT.ayear = @ayear
        			AND INCSORT.ymov = @ayear
                                AND competencydate <= @date)
        	,0)
         END
         ELSE --	 (@i_phase <> @i_lastphase)
	 BEGIN
		DECLARE @totlastincome decimal(19,2)
		SET @totlastincome =
		ISNULL(
		(SELECT SUM(proceeded)
		FROM
			(SELECT 
				CASE
					WHEN EV.curramount = 0 THEN 0
					ELSE
						(
							ISNULL(
								(SELECT SUM(curramount)
								FROM incomeview CHILD
								JOIN incomelink
									ON incomelink.idchild = CHILD.idinc
								WHERE ayear = @ayear
									AND incomelink.idparent = EV.idinc
									AND CHILD.nphase = @i_lastphase
									AND CHILD.adate <= @date)
							,0) /
							EV.curramount
						)
						* EXPSORT.amount
				END AS proceeded
			FROM incomesortedview EXPSORT
			JOIN incomeview EV
				ON EV.idinc = EXPSORT.idinc
			JOIN sortinglink SORLINK
				ON SORLINK.idchild = EXPSORT.idsor
			WHERE idsorkind = @idsorkind
				AND (@idsor IS NULL OR SORLINK.idparent = @idsor)	
				AND EXPSORT.ayear = @ayear
				AND EV.ayear = @ayear
				AND EXPSORT.adate <= @date) AS T)
		,0)

		DECLARE @i_lastphasedescr varchar(50)
		SELECT @i_lastphasedescr = description FROM incomephase WHERE nphase = @i_lastphase

		INSERT INTO #situation VALUES('Totale Movimenti su (' + @i_lastphasedescr + ')', @totlastincome, NULL)

		INSERT INTO #situation VALUES('Previsione disponibile entrate su (' + @i_lastphasedescr + ')',
		@actualprev_i - @totlastincome, 'S')
	
        	SET @tot_proceeded =
        	(SELECT SUM(proceeded)
        	FROM
        		(SELECT 
        			CASE
        				WHEN IV.curramount = 0 THEN 0
        				ELSE
        					(
        						ISNULL(
        							(SELECT SUM(curramount)
        							FROM historyproceedsview CHILD
        							JOIN incomelink
        								ON incomelink.idchild = CHILD.idinc
        							WHERE ymov = @ayear
        								AND incomelink.idparent = IV.idinc
        								AND CHILD.adate <= @date)
        						,0) /
        						IV.curramount
        					)
        					* INCSORT.amount
        			END AS proceeded
        		FROM incomesortedview INCSORT
        		JOIN incomeview IV
        			ON IV.idinc = INCSORT.idinc
        		JOIN sortinglink SORLINK
        			ON SORLINK.idchild = INCSORT.idsor
        		WHERE idsorkind = @idsorkind
        			AND (@idsor IS NULL OR SORLINK.idparent = @idsor)	
        			AND INCSORT.ayear = @ayear
        			AND IV.ymov = @ayear
        			AND INCSORT.adate <= @date) AS T)
        END

	INSERT INTO #situation VALUES('Totale Reversali', ISNULL(@tot_proceeded,0),'S')

END

INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES ('S P E S E',NULL,'N')

INSERT INTO #situation VALUES ('Previsione spese', @expenseprevision, '')
DECLARE @expense_var decimal(19,2)
SELECT @expense_var = SUM(amount)
FROM sortingprevexpensevar SORVAR
JOIN    sorting SORT
	ON SORVAR.idsor = SORT.idsor
JOIN sortinglink SORLINK 
	ON SORLINK.idchild =  SORVAR.idsor
WHERE SORT.idsorkind = @idsorkind
	AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)	
	AND ayear = @ayear
	AND adate <= @date
INSERT INTO #situation VALUES ('Variazioni spese', @expense_var, '')

DECLARE @actualprev_e decimal(19,2)
SET @actualprev_e = ISNULL(@expenseprevision, 0) + ISNULL(@expense_var, 0)

INSERT INTO #situation VALUES ('Previsione attuale spese', @actualprev_e, 'S')

IF (@e_phase IS NOT NULL)
BEGIN
	DECLARE @e_phasedescr varchar(50)
	SELECT @e_phasedescr = description FROM expensephase WHERE nphase = @e_phase

	DECLARE @expenseold decimal(19,2)
	SET @expenseold = 
	ISNULL(
		(SELECT SUM(amount)
		FROM expensesortedview EXPSORT
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild =  EXPSORT.idsor
		WHERE idsorkind = @idsorkind
			AND (@idsor IS NULL OR SORLINK.idparent = @idsor)	
			AND EXPSORT.ayear = @ayear
			AND EXPSORT.ymov < @ayear
			AND adate <= @date)
	,0)

	INSERT INTO #situation VALUES('1. Movimenti (anni prec.) - (' + @e_phasedescr + ')', @expenseold, NULL)

	DECLARE @expensenew decimal(19,2)
	SET @expensenew = 
	ISNULL(
		(SELECT SUM(amount)
		FROM expensesortedview EXPSORT
		JOIN sortinglink SORLINK 
			ON SORLINK.idchild =  EXPSORT.idsor
		WHERE idsorkind = @idsorkind
			AND (@idsor IS NULL OR SORLINK.idparent = @idsor)	
			AND EXPSORT.ayear = @ayear
			AND EXPSORT.ymov = @ayear
			AND adate <= @date)
	,0)

	INSERT INTO #situation VALUES('2. Movimenti (anno corrente) - (' + @e_phasedescr + ')', @expensenew, NULL)

	DECLARE @expense decimal(19,2)
	SET @expense = @expenseold + @expensenew

	INSERT INTO #situation VALUES('Prev. disponibile spese su (' + @e_phasedescr + ') [Prev. Att. - 1 - 2]',
	@actualprev_e - @expense, 'S')

	DECLARE @e_lastphase tinyint
	SELECT @e_lastphase = MAX(nphase) FROM expensephase

        DECLARE @tot_payment decimal(19,2)

        IF (@i_phase = @i_lastphase)
         BEGIN
        	SET @tot_payment =
        	ISNULL(
        		(SELECT SUM(curramount) 
        		FROM expensesortedview EXPSORT
                        JOIN historypaymentview HPV
                                ON HPV.idexp = EXPSORT.idexp
                                AND HPV.ymov = EXPSORT.ayear    
        		JOIN sortinglink SORLINK 
        			ON SORLINK.idchild =  EXPSORT.idsor
        		WHERE idsorkind = @idsorkind
        			AND (@idsor IS NULL OR  SORLINK.idparent = @idsor)	
        			AND EXPSORT.ayear = @ayear
        			AND EXPSORT.ymov = @ayear
                                AND competencydate <= @date)
        	,0)
         END
	ELSE --IF (@e_phase <> @e_lastphase)
	BEGIN	

		DECLARE @totlastexpense decimal(19,2)
		SET @totlastexpense =
		(SELECT SUM(payed)
		FROM
			(SELECT 
				CASE
					WHEN EV.curramount = 0 THEN 0
					ELSE
						(
							ISNULL(
								(SELECT SUM(curramount)
								FROM expenseview CHILD
								JOIN expenselink
									ON expenselink.idchild = CHILD.idexp
								WHERE ayear = @ayear
									AND expenselink.idparent = EV.idexp
									AND CHILD.nphase = @e_lastphase
									AND CHILD.adate <= @date)
							,0) /
							EV.curramount
						)
						* EXPSORT.amount
				END AS payed
			FROM expensesortedview EXPSORT
			JOIN expenseview EV
				ON EV.idexp = EXPSORT.idexp
			JOIN sortinglink SORLINK
				ON SORLINK.idchild = EXPSORT.idsor
			WHERE idsorkind = @idsorkind
				AND (@idsor IS NULL OR SORLINK.idparent = @idsor)	
				AND EXPSORT.ayear = @ayear
				AND EV.ayear = @ayear
				AND EXPSORT.adate <= @date) AS T)

		DECLARE @e_lastphasedescr varchar(50)
		SELECT @e_lastphasedescr = description FROM expensephase WHERE nphase = @e_lastphase

		INSERT INTO #situation VALUES('Totale Movimenti su (' + @e_lastphasedescr + ')', @totlastexpense, NULL)

		INSERT INTO #situation VALUES('Previsione disponibile spese su (' + @e_lastphasedescr + ')',
		@actualprev_e - @totlastexpense, 'S')	

        	SET @tot_payment =
        	(SELECT SUM(payed)
        	FROM
        		(SELECT 
        			CASE
        				WHEN EV.curramount = 0 THEN 0
        				ELSE
        					(
        						ISNULL(
        							(SELECT SUM(curramount)
        							FROM historypaymentview CHILD
        							JOIN expenselink
        								ON expenselink.idchild = CHILD.idexp
        							WHERE ymov = @ayear
        								AND expenselink.idparent = EV.idexp
        								AND CHILD.adate <= @date)
        						,0) /
        						EV.curramount
        					)
        					* EXPSORT.amount
        			END AS payed
        		FROM expensesortedview EXPSORT
        		JOIN expenseview EV
        			ON EV.idexp = EXPSORT.idexp
        		JOIN sortinglink SORLINK
        			ON SORLINK.idchild = EXPSORT.idsor
        		WHERE idsorkind = @idsorkind
        			AND (@idsor IS NULL OR SORLINK.idparent = @idsor)	
        			AND EXPSORT.ayear = @ayear
        			AND EV.ymov = @ayear
        			AND EXPSORT.adate <= @date) AS T)
        END

	INSERT INTO #situation VALUES('Totale Mandati', ISNULL(@tot_payment,0),'S')

END

SELECT value, amount, kind FROM #situation
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

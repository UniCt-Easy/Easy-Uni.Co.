
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_itineration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_itineration]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE         PROCEDURE [show_itineration]
@nitineration int,
@yitineration int,
@date datetime,
@ayear int

AS
BEGIN
DECLARE	@departmentname varchar(150)

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation VALUES ('Missione ' + CONVERT(char(4), @yitineration) + 
	' ' + CONVERT(char(6), @nitineration), NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')

DECLARE @amount decimal(19,2)
DECLARE @totadvance decimal(19,2)

SELECT  @amount = totalgross,
	@totadvance = totadvance 
FROM itineration
WHERE yitineration = @yitineration
	AND nitineration = @nitineration

DECLARE @employtax decimal(19,2)
DECLARE @admintax decimal(19,2)

DECLARE @iditineration int
SELECT @iditineration  = iditineration 
FROM itineration 
	WHERE yitineration = @yitineration AND nitineration = @nitineration
SELECT @employtax = SUM(employtax),
	@admintax = SUM(admintax)
FROM itinerationtax
WHERE iditineration = @iditineration

INSERT INTO #situation VALUES ('Importo lordo missione', @amount, '')
INSERT INTO #situation VALUES ('Ritenute a carico del percipiente', @employtax, '')
INSERT INTO #situation VALUES ('Importo netto missione', 
	ISNULL(@amount, 0) - ISNULL(@employtax, 0), 'S')
INSERT INTO #situation VALUES ('Importo lordo missione', @amount, '')
INSERT INTO #situation VALUES ('Contributi a carico dell''ente', @admintax, '')
INSERT INTO #situation VALUES ('Importo globale missione', 
	ISNULL(@amount, 0) + ISNULL(@admintax, 0), 'S')
		
DECLARE @expensephase tinyint
SELECT @expensephase = (SELECT expensephase FROM config WHERE ayear = @ayear)


CREATE TABLE #mov_itinerationphase
(
	yitineration int,	
	nitineration int,			
	idexp int,
	nphase tinyint,
	phase varchar(50),
	movkind	char(5),
	ayear int
)

INSERT INTO #mov_itinerationphase
(	
	yitineration,
	nitineration,
	idexp,
	nphase,
	phase,
	movkind,
	ayear
)
SELECT 	
	yitineration,
	nitineration,
	idexp,
	nphase,
	phase,
	movkind,
	ayear
FROM  expenseitinerationview
WHERE iditineration = @iditineration and nphase = @expensephase


DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM expensephase

DELETE FROM #mov_itinerationphase
WHERE ayear > (SELECT min(ayear) FROM #mov_itinerationphase m2 WHERE #mov_itinerationphase.idexp = m2.idexp)

DECLARE @phase_int int
SELECT @phase_int = 0
DECLARE @mov_exp_previous decimal(19,2)
	
WHILE (@expensephase + @phase_int) <= @maxphase 
BEGIN
			
	SELECT @mov_exp_previous = SUM(EY_starting.amount) 
	FROM expense E 
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov < @ayear
		AND E.adate <= @date
		AND E.nphase = @expensephase + @phase_int
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)

	DECLARE @mov_exp decimal(19,2)		
	SELECT @mov_exp = SUM(EY_starting.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND E.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)
	DECLARE @var_exp_previous decimal(19,2)
	SELECT @var_exp_previous = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov < @ayear
		AND EV.adate <= @date
		AND E.nphase = @expensephase + @phase_int
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)
	DECLARE @var_exp decimal(19,2)			
	SELECT @var_exp = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND EV.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 4)

	DECLARE @phase_int1 int
	SELECT @phase_int1 = (@expensephase+ @phase_int)

	DECLARE @phase varchar(50)
	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = @phase_int1

	INSERT INTO #situation VALUES ('Importo lordo missione', @amount, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. precedenti', @mov_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. corrente', @mov_exp, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. precedenti', @var_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. corrente', @var_exp, '')
	INSERT INTO #situation VALUES ('Importo lordo missione disponibile (' + @phase + ') ', 
		ISNULL(@amount, 0) - 
		    	ISNULL(@mov_exp, 0) - 
		ISNULL(@mov_exp_previous, 0) -
		ISNULL(@var_exp_previous, 0) - 
		ISNULL(@var_exp, 0), 'S')
	SELECT @phase_int = @phase_int + 1
END
		
INSERT INTO #situation VALUES ('', NULL, 'N')
INSERT INTO #situation VALUES ('Importo anticipo missione', @totadvance, 'S')
		
SELECT @phase_int = 0
WHILE (CONVERT(int,@expensephase) + @phase_int) <= @maxphase
BEGIN
	SELECT @mov_exp_previous = SUM(EY_starting.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov < @ayear
		AND E.nphase = @expensephase + @phase_int
		AND E.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6,5)

	SELECT @mov_exp = SUM(EY_starting.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND E.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6,5)
	
	SELECT @var_exp_previous = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase MOV
		ON MOV.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov < @ayear
		AND E.nphase = @expensephase + @phase_int
		AND EV.adate <= @date
		AND MOV.yitineration = @yitineration
		AND MOV.nitineration = @nitineration
		AND MOV.movkind IN (6, 5)
	
	SELECT @var_exp = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_itinerationphase 
		ON #mov_itinerationphase.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @phase_int
		AND EV.adate <= @date
		AND #mov_itinerationphase.yitineration = @yitineration
		AND #mov_itinerationphase.nitineration = @nitineration
		AND #mov_itinerationphase.movkind IN (6,5)

	SELECT @phase_int1 = (CONVERT(int,@expensephase) + @phase_int)

	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = CONVERT(char(1), @phase_int1)

	INSERT INTO #situation VALUES ('Importo anticipo missione', @totadvance, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. precedenti', @mov_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. corrente', @mov_exp, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. precedenti', @var_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. corrente', @var_exp, '')
	INSERT INTO #situation VALUES ('Importo anticipo missione disponibile (' + @phase + ') ', 
		ISNULL(@totadvance, 0) - 
		ISNULL(@mov_exp, 0) - 
		ISNULL(@mov_exp_previous, 0) -
		ISNULL(@var_exp_previous, 0) - 
		ISNULL(@var_exp, 0), 'S')
	SELECT @phase_int = @phase_int + 1
END
		
SELECT value, amount, kind FROM #situation
END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


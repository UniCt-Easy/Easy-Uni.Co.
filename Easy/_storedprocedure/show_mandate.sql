
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_mandate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_mandate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE        PROCEDURE [show_mandate]
@idmankind varchar(20),
@nman int,
@yman int,
@date datetime,
@ayear int
AS BEGIN

DECLARE	@departmentname varchar(150)

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation 
VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation 
VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation 
VALUES ('Contratto Passivo ' + CONVERT(char(4), @yman) + ' ' + CONVERT(char(6), @nman), NULL, 'H')
INSERT INTO #situation 
VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')
DECLARE @expensephase tinyint
SELECT @expensephase =(SELECT expensephase FROM config WHERE ayear = @ayear)  

CREATE TABLE #mov_mandatephase
(
	idmankind varchar(20),
	yman int,
	nman int,
	idexp int,
	nphase tinyint,
	phase varchar(50),
	movkind char(5) ,
	ayear int
)

INSERT INTO  #mov_mandatephase
(
	idmankind,
	yman,		
	nman,			
	idexp,
	nphase,
	phase,
	movkind,
	ayear
)
SELECT 	
	idmankind,
	yman,
	nman,
	idexp,
	nphase,
	phase,
	movkind, 
	ayear
FROM expensemandateview 
WHERE idmankind = @idmankind 
	AND yman=@yman
	AND nman = @nman 
	AND nphase = @expensephase

DECLARE @maxphase tinyint
SELECT @maxphase = MAX(nphase) FROM expensephase
		
-- Cancellazione dei duplicati presenti nella tabella #mov_mandatephase
DELETE FROM #mov_mandatephase
WHERE ayear > (SELECT MIN(ayear) FROM #mov_mandatephase o2 WHERE #mov_mandatephase.idexp = o2.idexp)

DECLARE @nphase tinyint
SET @nphase = 0
WHILE (@expensephase + @nphase) <= @maxphase
BEGIN
	DECLARE @mov_exp_previous decimal(19,2)
	SELECT @mov_exp_previous = SUM(EY_starting.amount)--SUM(E.amount) 
	FROM expense E 
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_mandatephase MOV
		ON MOV.idexp = ELK.idparent
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov < @ayear
		AND E.adate <= @date
		AND E.nphase = @expensephase + @nphase 
		AND MOV.idmankind = @idmankind
		AND MOV.yman = @yman
		AND MOV.nman = @nman
	
	DECLARE @mov_exp decimal(19,2)
	SELECT @mov_exp = SUM(EY_starting.amount)--SUM(E.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_mandatephase MOV
		ON MOV.idexp = ELK.idparent
	LEFT OUTER JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.ymov = @ayear
		AND E.adate <= @date
		AND E.nphase = @expensephase + @nphase
		AND MOV.idmankind = @idmankind
		AND MOV.yman = @yman
		AND MOV.nman = @nman
	
	DECLARE @var_exp_previous decimal(19,2)
	SELECT @var_exp_previous = SUM(EV.amount) 
	FROM expensevar EV 
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_mandatephase MOV
		ON MOV.idexp = ELK.idparent 
	JOIN expense E
		ON E.idexp like EV.idexp
	WHERE E.ymov < @ayear
		AND EV.adate <= @date
		AND E.nphase = @expensephase + @nphase
		AND MOV.idmankind = @idmankind
		AND MOV.yman = @yman
		AND MOV.nman = @nman
	
	DECLARE @var_exp decimal(19,2)
	SELECT @var_exp = SUM(EV.amount) 
	FROM expensevar EV
	JOIN expenselink ELK
		ON EV.idexp = ELK.idchild  AND ELK.nlevel = @expensephase 
	JOIN #mov_mandatephase MOV
		ON MOV.idexp = ELK.idparent
	JOIN expense E
		ON E.idexp = EV.idexp
	WHERE E.ymov = @ayear
		AND E.nphase = @expensephase + @nphase
		AND EV.adate <= @date
		AND MOV.idmankind = @idmankind
		AND MOV.yman = @yman
		AND MOV.nman = @nman
	DECLARE @nphase1 tinyint
	SELECT  @nphase1 = (CONVERT(tinyint,@expensephase) + @nphase)

	DECLARE @phase varchar(50)
	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = CONVERT(char(1), @nphase1)

	DECLARE @amount decimal(19,2)
	SELECT @amount = ISNULL(taxabletotal, 0) + ISNULL(ivatotal, 0)
	FROM totmandateview
	WHERE idmankind = @idmankind
		AND yman = @yman
		AND nman = @nman
	INSERT INTO #situation VALUES ('Importo totale contratto passivo', @amount, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. precedenti', @mov_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo movimenti (' + @phase +
		') eserc. corrente', @mov_exp, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. precedenti', @var_exp_previous, '')
	INSERT INTO #situation VALUES ('Importo variazioni (' + @phase +
		') eserc. corrente', @var_exp, '')
	INSERT INTO #situation VALUES ('Importo totale contratto disponibile (' + @phase + ') ', 
		ISNULL(@amount, 0) - 
		ISNULL(@mov_exp, 0) - 
  		ISNULL(@mov_exp_previous, 0) -
		ISNULL(@var_exp_previous, 0) - 
		ISNULL(@var_exp, 0), 'S')
	SELECT @nphase = @nphase + 1
END
SELECT value, amount, kind FROM #situation
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_expense]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- select * from expense where ymov=2016
-- show_expense 87593,2016, '31-12-2016'
-- show_expense 1313131,2016, '08-07-2016'

CREATE           PROCEDURE show_expense
(
	@idexp int,
	@ayear int,
	@date datetime
)
AS BEGIN

DECLARE @ymov int
DECLARE @nmov int
DECLARE @amount decimal(19,2)
DECLARE @nphase tinyint
DECLARE @codeupb varchar(50)
DECLARE @upb  varchar(150)
DECLARE @codefin varchar(50)
DECLARE @fin varchar(150)
DECLARE @finphase varchar(50)
DECLARE @description varchar(150)


SELECT  @ymov 	 = E.ymov, 
	@nmov 	 = E.nmov, 
	@amount  = EY_starting.amount, 
	@nphase  = E.nphase,
	@codeupb = upb.codeupb,
	@upb 	 = upb.title,
	@codefin = fin.codefin,
	@fin 	 = fin.title,
	@finphase = finlevel.description,
	@description = E.description
FROM expense E
JOIN expensetotal ET_firstyear
  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
JOIN expenseyear EY_starting
	ON EY_starting.idexp = ET_firstyear.idexp
  	AND EY_starting.ayear = ET_firstyear.ayear
JOIN upb 
	ON upb.idupb = EY_starting.idupb
JOIN fin
	ON fin.idfin = EY_starting.idfin
JOIN finlevel 
	ON fin.nlevel = finlevel.nlevel
	AND finlevel.ayear = EY_starting.ayear
WHERE E.idexp = @idexp

DECLARE @sortingkind01 varchar(150)
DECLARE @sorting01 varchar(150)

SELECT   
			@sortingkind01 = SK.description,
			@sorting01 = S01.description  
			FROM upb
LEFT OUTER JOIN sorting S01
				ON upb.idsor01 = S01.idsor
		LEFT OUTER JOIN sortingkind SK
				ON SK.idsorkind = S01.idsorkind
				where codeupb = @codeupb
				

 
DECLARE @phase varchar(50)
SELECT  @phase = description FROM expensephase WHERE nphase = @nphase

DECLARE	@departmentname varchar(150)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')


CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation VALUES (@phase + ' ' + CONVERT(char(4), @ymov) + ' ' +
	CONVERT(char(6), @nmov), NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')

INSERT INTO #situation VALUES ('Descrizione: '+ @description, NULL, 'N')
INSERT INTO #situation VALUES ('UPB: ' +  @codeupb + space(1) + '(' + @upb + ')', NULL, 'N')
IF @sorting01 IS NOT NULL 
BEGIN
	INSERT INTO #situation VALUES (@sorting01, NULL, 'N')
END
INSERT INTO #situation VALUES ('Bilancio: ' + @finphase + space(1) + @codefin + space(1) + '(' + @fin + ')', NULL, 'N')
INSERT INTO #situation VALUES ('', NULL, 'N')

INSERT INTO #situation VALUES ('1. Importo originale', @amount, '')

DECLARE @tot_var_prev_ayear decimal(19,2)
SELECT @tot_var_prev_ayear = SUM(amount) 
FROM expensevar
WHERE idexp = @idexp 
AND yvar < @ayear
	AND adate <= @date

INSERT INTO #situation VALUES ('2. Variazioni Esercizi Prec.', @tot_var_prev_ayear, '')
DECLARE @tot_var_curr_ayear decimal(19,2)
SELECT @tot_var_curr_ayear = SUM(amount)
FROM expensevar
WHERE idexp = @idexp 
	AND yvar = @ayear
	AND adate <= @date

INSERT INTO #situation VALUES ('3. Variazioni Esercizio Corr.', @tot_var_curr_ayear, '')
DECLARE @tot_amount decimal(19,2)
SELECT @tot_amount = ISNULL(@amount, 0) + ISNULL(@tot_var_prev_ayear, 0) + ISNULL(@tot_var_curr_ayear, 0)
INSERT INTO #situation VALUES ('4. Importo comprensivo delle variazioni (1 + 2 + 3)', @tot_amount, 'S')

DECLARE @maxphase int
SELECT @maxphase = MAX(nphase) FROM expensephase

DECLARE @tot_pettycashop decimal(19,2)
SET @tot_pettycashop = 
ISNULL(
	(SELECT SUM(exp_op.amount)
	FROM pettycashoperation exp_op
	WHERE yoperation = @ayear
	AND idexp = @idexp
	AND (flag&8)<>0
	AND adate <= @date
	AND NOT EXISTS(
		SELECT * FROM pettycashoperation restore_op
		WHERE restore_op.yrestore = exp_op.yrestore
		AND restore_op.nrestore = exp_op.nrestore
		AND restore_op.idpettycash = exp_op.idpettycash
		AND restore_op.adate <= @date)
	)
,0)
DECLARE @availableText varchar(150)
SET @availableText = '10. Importo Disponibile (4 - '
IF (@tot_pettycashop <> 0)
BEGIN
	INSERT INTO #situation VALUES('5. Totale Op. Fondo Economale non reintegrate', @tot_pettycashop, '')
	SET @availableText = @availableText + '5 - '
END
SET @availableText = @availableText + '6 - 7 - 8 - 9)'
INSERT INTO #situation VALUES ('', NULL, 'N')
WHILE @nphase < @maxphase
BEGIN
	SELECT @nphase = @nphase + 1
	
	SELECT @phase = description 
	FROM expensephase
	WHERE nphase = @nphase
	
	DECLARE @tot_mov_prev_ayear decimal(19,2)
	SELECT @tot_mov_prev_ayear =  SUM(EY_starting.amount)--SUM(E.amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild  
	JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.nphase = @nphase 
		AND ELK.idparent = @idexp 
		-- AND ELK.nlevel = @nphase
		AND E.ymov < @ayear
		AND E.adate <= @date

	INSERT INTO #situation VALUES ('6. Totale movimenti (' + @phase + ') eserc. precedenti', @tot_mov_prev_ayear, '')

	DECLARE @tot_mov_curr_ayear decimal(19,2)
	SELECT @tot_mov_curr_ayear = SUM(EY_starting.amount)--SUM(amount) 
	FROM expense E
	JOIN expenselink ELK
		ON E.idexp = ELK.idchild 
	JOIN expensetotal ET_firstyear
	  	ON ET_firstyear.idexp = E.idexp AND ((ET_firstyear.flag & 2) <> 0 )
	JOIN expenseyear EY_starting
		ON EY_starting.idexp = ET_firstyear.idexp
	  	AND EY_starting.ayear = ET_firstyear.ayear
	WHERE E.nphase = @nphase --AND ELK.nlevel = @nphase 
		AND ELK.idparent = @idexp 
		AND E.ymov = @ayear
		AND E.adate <= @date
	
	INSERT INTO #situation VALUES ('7. Totale movimenti (' + @phase + ') eserc. corrente', @tot_mov_curr_ayear, '')
	
	SELECT @tot_var_prev_ayear = SUM(expensevar.amount) 
	FROM expensevar 
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenselink 
		ON expense.idexp = expenselink.idchild  
	WHERE expenselink.idparent = @idexp  
		--AND expenselink.nlevel = @nphase 
		AND expense.nphase = @nphase
		AND expensevar.yvar < @ayear
		AND expensevar.adate <= @date
	
	INSERT INTO #situation VALUES ('8. Totale variazioni (' + @phase + ') eserc. precedenti', @tot_var_prev_ayear, '')

	SELECT @tot_var_curr_ayear = SUM(expensevar.amount)
	FROM expensevar
	JOIN expense
		ON expense.idexp = expensevar.idexp
	JOIN expenselink 
		ON expense.idexp = expenselink.idchild  
	WHERE expenselink.idparent = @idexp  
		--AND expenselink.nlevel = @nphase 
		AND expense.nphase = @nphase
		AND expensevar.yvar = @ayear
		AND expensevar.adate <= @date

	INSERT INTO #situation VALUES ('9. Totale variazioni (' + @phase + ') eserc. corrente', @tot_var_curr_ayear, '')
	DECLARE @available decimal(19,2)
	SET @available = 
		ISNULL(@tot_amount, 0) - 
		ISNULL(@tot_mov_curr_ayear, 0) - 
		ISNULL(@tot_mov_prev_ayear, 0) -
		ISNULL(@tot_var_prev_ayear, 0) - 
		ISNULL(@tot_var_curr_ayear, 0) -
		ISNULL(@tot_pettycashop, 0)
	INSERT INTO #situation VALUES (@availableText, @available, 'S')
	INSERT INTO #situation VALUES ('', NULL, 'N')
END 
SELECT value, amount, kind FROM #situation
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

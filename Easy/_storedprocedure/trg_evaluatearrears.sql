
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_evaluatearrears]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_evaluatearrears]
GO


CREATE  PROCEDURE [trg_evaluatearrears]
(
	@movkind char(1),
	@idmov int,
	@ayear int,
	@nphase tinyint
)
AS BEGIN

DECLARE @oldidfin int
DECLARE @newidfin int
DECLARE @idupb varchar(36)
DECLARE @existyear int
DECLARE @newarrear decimal(19,2)
DECLARE @oldarrear decimal(19,2)
DECLARE @currentamount decimal(19,2)
DECLARE @lastphase tinyint
DECLARE @newayear int
SELECT @newayear = @ayear + 1

IF @movkind = 'I'
BEGIN
	SELECT @lastphase = MAX(nphase) FROM incomephase

	SELECT @existyear = COUNT(*)
	FROM incomeyear
	WHERE idinc = @idmov	AND ayear = @newayear

	SELECT @oldarrear = ISNULL(amount, 0)
	FROM incomeyear
	WHERE idinc = @idmov	AND ayear = @newayear

	SELECT
		@oldidfin = idfin,
		@idupb = idupb
	FROM incomeyear
	WHERE idinc = @idmov	AND ayear = @ayear

	SELECT @currentamount = ISNULL(curramount, 0)
	FROM incometotal
	WHERE idinc = @idmov	AND ayear = @ayear	

	DECLARE @proceeded decimal(19,2)
	SELECT @proceeded = ISNULL(SUM(curramount), 0)
	FROM incometotal
	WHERE ayear = @ayear
		AND idinc IN
			(SELECT incomelink.idchild
			FROM incomelink
			JOIN income		ON income.idinc = incomelink.idchild
			WHERE incomelink.idparent = @idmov	AND income.nphase = @lastphase)

	SELECT @newarrear = ISNULL(@currentamount, 0) - ISNULL(@proceeded, 0)
END
ELSE
BEGIN
	SELECT @lastphase = MAX(nphase) FROM expensephase

	SELECT @existyear = COUNT(*)	FROM expenseyear	
			WHERE idexp = @idmov	AND ayear = @newayear

	SELECT @oldarrear = ISNULL(amount, 0)	FROM expenseyear
			WHERE idexp = @idmov		AND ayear = @newayear

	SELECT 		@oldidfin = idfin,		@idupb = idupb
	FROM expenseyear
	WHERE idexp = @idmov			AND ayear = @ayear

	SELECT @currentamount = ISNULL(curramount, 0)
	FROM expensetotal
	WHERE idexp = @idmov	AND ayear = @ayear

	DECLARE @payed decimal(19,2)	
	SELECT @payed = ISNULL(SUM(curramount), 0)
	FROM expensetotal
	WHERE ayear = @ayear
		AND idexp IN
			(SELECT expenselink.idchild
			FROM expenselink
			JOIN expense 		ON expense.idexp = expenselink.idchild
			WHERE expenselink.idparent = @idmov		AND expense.nphase = @lastphase)

	SELECT @newarrear = ISNULL(@currentamount, 0) - ISNULL(@payed, 0)
END
IF (@existyear > 0)
BEGIN
	IF (@newarrear = 0)
	BEGIN
		IF @movkind = 'I'
		BEGIN
			DELETE FROM incomeyear
			WHERE idinc = @idmov	AND ayear = @newayear
			AND NOT EXISTS
				(SELECT incomeyear.idinc
				FROM incomeyear
				JOIN incomelink			ON incomelink.idchild = incomeyear.idinc
				WHERE incomelink.idparent = @idmov
					AND incomelink.idchild <> incomelink.idparent
					--AND incomelink.nlevel > @nphase
					AND incomeyear.ayear > @ayear)
			
			UPDATE incomeyear
			SET amount = @newarrear, lu = '''TRIGGER''', lt = GETDATE()
			WHERE idinc = @idmov	AND ayear = @newayear
			AND EXISTS
				(SELECT incomeyear.idinc
				FROM incomeyear
				JOIN incomelink		ON incomelink.idchild = incomeyear.idinc
				WHERE incomelink.idparent = @idmov
					AND incomelink.idchild <> incomelink.idparent
					--AND incomelink.nlevel > @nphase
					AND incomeyear.ayear > @ayear)
		END
		ELSE
		BEGIN
			DELETE FROM expenseyear
			WHERE idexp = @idmov 	AND ayear = @newayear
			AND NOT EXISTS
				(SELECT expenseyear.idexp
				FROM expenseyear
				JOIN expenselink		ON expenselink.idchild = expenseyear.idexp
				WHERE expenselink.idparent = @idmov
					AND expenselink.idchild <> expenselink.idparent
					--AND expenselink.nlevel > @nphase
					AND expenseyear.ayear > @ayear)
			
			UPDATE expenseyear
			SET amount = @newarrear, lu = '''TRIGGER''', lt = GETDATE()
			WHERE idexp = @idmov
			AND ayear = @newayear
			AND EXISTS
				(SELECT expenseyear.idexp
				FROM expenseyear
				JOIN expenselink		ON expenselink.idchild = expenseyear.idexp
				WHERE expenselink.idparent = @idmov
					AND expenselink.idchild <> expenselink.idparent
					--AND expenselink.nlevel > @nphase
					AND expenseyear.ayear > @ayear)
		END
	END
	ELSE
	BEGIN
		IF @movkind = 'I'
		BEGIN
			UPDATE incomeyear
			SET amount = @newarrear, lu = '''TRIGGER''', lt = GETDATE()
			WHERE idinc = @idmov
			AND ayear = @newayear
		END
		ELSE
		BEGIN
			UPDATE expenseyear
			SET amount = @newarrear, lu = '''TRIGGER''', lt = GETDATE()
			WHERE idexp = @idmov
			AND ayear = @newayear
		END
	END
END
ELSE
BEGIN
	SELECT @newidfin = NULL

	SELECT @newidfin = newidfin	FROM finlookup	WHERE oldidfin = @oldidfin

	IF @movkind = 'I'
	BEGIN
		INSERT INTO incomeyear		(idinc,ayear,idfin,idupb,amount,	cu,ct,lu,lt)
		VALUES(@idmov,@newayear,@newidfin,@idupb,@newarrear,	'TRIGGER',GETDATE(),'''TRIGGER_trg_eval''',GETDATE())
	END
	ELSE
	BEGIN
		INSERT INTO expenseyear	(idexp,ayear,idfin,idupb,amount,	cu,ct,lu,lt)
		VALUES(@idmov,@newayear,@newidfin,@idupb,@newarrear,	'TRIGGER',GETDATE(),'''TRIGGER''',GETDATE())
	END
END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


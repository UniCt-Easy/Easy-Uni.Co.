
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
--setuser 'amm'
if exists (select * from dbo.sysobjects where id = object_id(N'[trg_ins_amount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_ins_amount]
GO

CREATE    PROCEDURE [trg_ins_amount]
(
	@ayear int,
	@movkind char(1),
	@idmov int,
	@paridmov int,
	@amount decimal(19,2),
	@flagarrear tinyint,
	@firstyear tinyint
)
AS BEGIN
DECLARE @flag tinyint
SET @flag = @flagarrear + @firstyear

DECLARE @sumofson decimal(19,2)
DECLARE @available decimal(19,2)

IF @movkind = 'I'	
BEGIN
	-- Questo pezzo di codice è stato aggiunto in quanto avendo cambiato l'ordine della creazione / rimozione della tabella di imputazione
	-- capita nell'esercizio successivo che venga creato prima il figlio del padre e, che quindi il padre non abbia il disponibile correttamente
	-- aggiornato.
	SET @sumofson =
	ISNULL(
		(SELECT SUM(curramount)
		FROM incometotal
		JOIN income
			ON incometotal.idinc = income.idinc
		WHERE income.parentidinc = @idmov
			AND incometotal.ayear = @ayear)
	,0)

	SET @available = @amount - @sumofson

	INSERT INTO incometotal
	(idinc, ayear, curramount, available, flag)
	VALUES (@idmov, @ayear, @amount, @available, @flag)
	IF @paridmov IS NOT NULL
	BEGIN
		UPDATE incometotal
		SET available = ISNULL(available,0) - @amount
		WHERE idinc = @paridmov
		AND ayear = @ayear
	END
END
ELSE
BEGIN
	DECLARE @maxexpensephase tinyint
	SELECT @maxexpensephase = MAX(nphase) FROM expensephase

	DECLARE @nphase tinyint
	SELECT @nphase = nphase FROM expense WHERE idexp = @idmov

	IF (@nphase = @maxexpensephase)
	BEGIN
		EXEC trg_ins_curr_floatfund
		@ayear,
		'E',
		@idmov,
		@amount
	END

	-- Questo pezzo di codice è stato aggiunto in quanto avendo cambiato l'ordine della creazione / rimozione della tabella di imputazione
	-- capita nell'esercizio successivo che venga creato prima il figlio del padre e, che quindi il padre non abbia il disponibile correttamente
	-- aggiornato.
	SET @sumofson =
	ISNULL(
		(SELECT SUM(curramount)
		FROM expensetotal
		JOIN expense
			ON expensetotal.idexp = expense.idexp
		WHERE expense.parentidexp = @idmov
			AND expensetotal.ayear = @ayear)
	,0)

	SET @available = @amount - @sumofson

	INSERT INTO expensetotal (idexp,ayear,curramount,available, flag)
	VALUES (@idmov, @ayear, @amount, @available, @flag)

	IF @paridmov IS NOT NULL
	BEGIN
		UPDATE expensetotal
		SET available = ISNULL(available,0) - @amount
		WHERE idexp = @paridmov
		AND ayear = @ayear
	END
END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


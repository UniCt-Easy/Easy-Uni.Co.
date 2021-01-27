
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_underwritingappropriation]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_underwritingappropriation]
GO

CREATE      TRIGGER [trigger_d_underwritingappropriation] ON [underwritingappropriation] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN

	DECLARE @idexp int
	DECLARE @ayear int
	DECLARE @amount decimal(19,2)
	DECLARE @idfin int
	DECLARE @idupb varchar(36)
	DECLARE @flagarrear char(1)
	DECLARE @nphase tinyint
	DECLARE @idunderwriting int 
-- Questo codice funziona se cancelliamo la riga di underwritingappropriation
-- se invece cancelliamo direttamente l'impegno agisce il trigger in D/expenseyear
	SELECT
		@idunderwriting = idunderwriting	,
		@amount = -amount,
		@idexp = idexp
	FROM deleted
	
	SELECT
		@ayear = EY.ayear, 
		@idfin = EY.idfin, 
		@idupb = EY.idupb,
		@nphase = E.nphase
	FROM expenseyear EY
	JOIN expense E
		ON EY.idexp = E.idexp
		AND EY.ayear = E.ymov
	WHERE E.idexp = @idexp
		
	DECLARE @finphase tinyint
	SELECT @finphase = expensefinphase FROM uniconfig
			
	DECLARE @ymovpar int
	SELECT @ymovpar = expense.ymov 
	FROM expenselink
	JOIN expense
		ON expenselink.idparent = expense.idexp
	WHERE idchild = @idexp
		AND nlevel = @finphase

		IF (@ymovpar = @ayear)
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@idunderwriting,
			@idupb,
			@idfin,
			'C', 
			@nphase, 
			@amount
		END
		ELSE
		BEGIN
			EXECUTE trg_upd_underwritingmovtotal 
			'E', 
			@idunderwriting,
			@idupb,
			@idfin,
			'R', 
			@nphase, 
			@amount
		END


END
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


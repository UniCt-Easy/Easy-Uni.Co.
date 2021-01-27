
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_doc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_doc]
GO


CREATE   PROCEDURE [trg_upd_doc]
(
	@finpart char(1),
	@idmov int,
	@ayear int,
	@idfin int
)
AS BEGIN

DECLARE @flagfinance char(1)

IF @finpart = 'S'
BEGIN
	DECLARE @paymentfinlevel tinyint

	SELECT
		@flagfinance =
		CASE
			WHEN ((config.payment_flag&2) = 0) THEN 'N'
			ELSE 'S'
		END,
		@paymentfinlevel = payment_finlevel
	FROM config WHERE ayear = @ayear

	IF(NOT EXISTS
		(SELECT MAIN.idexp
		FROM expense MAIN
		JOIN expenselink
			ON expenselink.idparent = MAIN.idexp
		JOIN expenselast
			ON expenselast.idexp = expenselink.idchild
		JOIN payment D1
			ON expenselast.kpay = D1.kpay
		WHERE (
			(MAIN.idexp = @idmov)
			AND
				(SELECT COUNT(*)
				FROM expenselast
				WHERE expenselast.kpay=D1.kpay)>1
		)
	) AND (@flagfinance = 'S'))
	BEGIN
		IF (@paymentfinlevel IS NULL)
		BEGIN
			SELECT @paymentfinlevel = nlevel FROM fin WHERE idfin = @idfin
		END
		
		SELECT @idfin = idparent FROM finlink WHERE (idchild = @idfin) AND (nlevel = @paymentfinlevel)

		UPDATE payment SET idfin = @idfin
		FROM expense MAIN
		JOIN expenselink
			ON MAIN.idexp = expenselink.idparent
		JOIN expenselast
			ON expenselast.idexp = expenselink.idchild
		JOIN payment P1 
			ON expenselast.kpay = P1.kpay
		WHERE MAIN.idexp = @idmov
	END
END
ELSE
BEGIN
	DECLARE @proceedsfinlevel tinyint

	SELECT
		@flagfinance =
		CASE
			WHEN ((config.proceeds_flag&2) = 0) THEN 'N'
			ELSE 'S'
		END,
		@proceedsfinlevel = proceeds_finlevel
	FROM config WHERE ayear = @ayear

	IF(NOT EXISTS
		(SELECT MAIN.idinc
		FROM income MAIN
		JOIN incomelink
			ON incomelink.idparent = MAIN.idinc
		JOIN incomelast
			ON incomelast.idinc = incomelink.idchild
		JOIN proceeds D1
			ON incomelast.kpro = D1.kpro
		WHERE (
			(MAIN.idinc = @idmov)
			AND
				(SELECT COUNT(*)
				FROM incomelast
				WHERE incomelast.kpro=D1.kpro)>1
		)
	) AND (@flagfinance = 'S'))
	BEGIN
		IF (@proceedsfinlevel IS NULL)
		BEGIN
			SELECT @proceedsfinlevel = nlevel FROM fin WHERE idfin = @idfin
		END

		SELECT @idfin = idparent FROM finlink WHERE (idchild = @idfin) AND (nlevel = @proceedsfinlevel)

		UPDATE proceeds SET idfin = @idfin
		FROM income MAIN
		JOIN incomelink
			ON MAIN.idinc = incomelink.idparent
		JOIN incomelast
			ON incomelast.idinc = incomelink.idchild
		JOIN proceeds P1 
			ON incomelast.kpro = P1.kpro
		WHERE MAIN.idinc = @idmov
	END
END
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


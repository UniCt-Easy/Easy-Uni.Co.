
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_ins_epexpamount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_ins_epexpamount]
GO

CREATE    PROCEDURE [trg_ins_epexpamount]
(
	@ayear int,	
	@idmov int,
	@paridmov int,
	@amount decimal(19,2),
	@amount2 decimal(19,2),
	@amount3 decimal(19,2),
	@amount4 decimal(19,2),
	@amount5 decimal(19,2)
)
AS BEGIN

DECLARE @sumofson decimal(19,2)
DECLARE @sumofson2 decimal(19,2)
DECLARE @sumofson3 decimal(19,2)
DECLARE @sumofson4 decimal(19,2)
DECLARE @sumofson5 decimal(19,2)

DECLARE @available decimal(19,2)
DECLARE @available2 decimal(19,2)
DECLARE @available3 decimal(19,2)
DECLARE @available4 decimal(19,2)
DECLARE @available5 decimal(19,2)

--DECLARE @maxexpensephase char(1)  = 2

DECLARE @nphase tinyint
SELECT @nphase = nphase FROM epexp WHERE idepexp = @idmov


-- Questo pezzo di codice è stato aggiunto in quanto avendo cambiato l'ordine della creazione / rimozione della tabella di imputazione
-- capita nell'esercizio successivo che venga creato prima il figlio del padre e, che quindi il padre non abbia il disponibile correttamente
-- aggiornato.
SELECT @sumofson=SUM(curramount), @sumofson2=SUM(curramount2), @sumofson3=SUM(curramount3),
				 @sumofson4=SUM(curramount4), @sumofson5=SUM(curramount5)
FROM epexptotal
JOIN epexp				ON epexptotal.idepexp = epexp.idepexp
WHERE epexp.paridepexp = @idmov
			AND epexptotal.ayear = @ayear
	

SET		@available = isnull(@amount,0) - isnull(@sumofson,0)
SET 	@available2 = isnull(@amount2,0) - isnull(@sumofson2,0)
SET 	@available3 = isnull(@amount3,0) - isnull(@sumofson3,0)
SET 	@available4 = isnull(@amount4,0) - isnull(@sumofson4,0)
SET 	@available5 = isnull(@amount5,0) - isnull(@sumofson5,0)

	INSERT INTO epexptotal (idepexp,ayear,curramount,curramount2,curramount3,curramount4,curramount5,
			available, available2,available3,available4,available5)
	VALUES (@idmov, @ayear, @amount,@amount2,@amount3,@amount4,@amount5,
					 @available, @available2,@available3,@available4,@available5)

	IF @paridmov IS NOT NULL
	BEGIN
		UPDATE epexptotal
		SET available = ISNULL(available,0) - isnull(@amount,0),
			available2 = ISNULL(available2,0) - isnull(@amount2,0),
			available3 = ISNULL(available3,0) - isnull(@amount3,0),
			available4 = ISNULL(available4,0) - isnull(@amount4,0),
			available5 = ISNULL(available5,0) - isnull(@amount5,0)
		WHERE idepexp = @paridmov
		AND ayear = @ayear
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


 
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_payment_bank]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_payment_bank]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE compute_payment_bank
(
	@kpay int
)
AS BEGIN

-- Mandato già esitato (anche parzialmente)
IF (SELECT COUNT(*)
	FROM banktransaction
	WHERE kpay = @kpay) > 0
BEGIN
	
	UPDATE payment_bank
	SET amount =
		(SELECT SUM(e.curramount) 
		FROM expensetotal e
		JOIN expenselast l
			ON e.idexp = l.idexp
		WHERE l.kpay = payment_bank.kpay
			AND l.idpay = payment_bank.idpay)
	WHERE payment_bank.kpay = @kpay
		and exists (select *	FROM expensetotal e
						JOIN expenselast l		ON e.idexp = l.idexp
			WHERE l.kpay = payment_bank.kpay	AND l.idpay = payment_bank.idpay)

	RETURN
END

-- Mandato non esitato
-- Ripristino situazione iniziale
-- Cancellazione dei movimenti bancari associati al mandato
DELETE FROM payment_bank WHERE kpay = @kpay
-- Scollegamento dei movimenti bancari dai movimenti finanziari associati al mandato
--UPDATE expenselast SET idpay = NULL WHERE ypay = @ypay AND npay = @npay
UPDATE expenselast SET idpay = NULL WHERE kpay = @kpay

	
	
--  Mi creo una tabella temporanea in cui inserisco il codice CUP e il codice CIG dopo averli calcolati.
--  Il calcolo del CUP e CIG, ossia la loro lettura, non è immediata perchè vanno letti nel modo seguente:
--  Cup : Spesa -> Contratto passivo -> UPB -> Bilancio
--  Cig : Spesa -> Contratto passivo

DECLARE @idpay_free int
DECLARE @idexp int
DECLARE @idreg int
DECLARE @description varchar(200)
DECLARE @curramount float
DECLARE @doc varchar(35)
DECLARE @docdate datetime
DECLARE @nbill int
	
DECLARE pay_crs INSENSITIVE CURSOR FOR
	
	SELECT EV.idexp, EV.idreg, EV.description, EV.doc, EV.docdate, EV.curramount, EV.nbill
	FROM expenseview EV
	JOIN expenselast EL 
		ON EV.idexp = EL.idexp
	WHERE EL.kpay = @kpay
	FOR READ ONLY
	
	OPEN pay_crs
	FETCH NEXT FROM pay_crs INTO @idexp, @idreg, @description, @doc, @docdate, @curramount, @nbill
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF (@doc IS NOT NULL)
		BEGIN
			SET @description = @description + ' Doc. ' + @doc
			IF (@docdate IS NOT NULL)
			BEGIN
				SET @description = @description + ' del ' + CONVERT(varchar(20), @docdate, 105)
			END
		END
		SET @idpay_free = ISNULL((SELECT MAX(idpay) FROM payment_bank WHERE kpay = @kpay),0) + 1
	
		INSERT INTO payment_bank (kpay, idpay, idreg, description, amount, ct, cu, lt, lu) 
		VALUES(@kpay, @idpay_free, @idreg, @description, @curramount,  GETDATE(), 'SP', GETDATE(), '''SP''')
	
		UPDATE expenselast
		SET idpay = @idpay_free
		WHERE idexp = @idexp
	
		FETCH NEXT FROM pay_crs INTO @idexp, @idreg, @description, @doc, @docdate, @curramount, @nbill 
	END
	CLOSE pay_crs
	DEALLOCATE pay_crs
	

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



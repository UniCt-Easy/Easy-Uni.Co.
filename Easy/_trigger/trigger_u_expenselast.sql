
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_expenselast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_expenselast]
GO

CREATE TRIGGER [trigger_u_expenselast] ON [expenselast] FOR UPDATE
AS BEGIN
IF UPDATE(kpay)
BEGIN
	
	DECLARE @idexp int
	DECLARE @newkpay int
	DECLARE @oldkpay int
	
	DECLARE @newamount decimal(19,2)
	SELECT  @idexp = idexp, @newkpay = kpay FROM inserted
	SELECT  @oldkpay = kpay FROM deleted
	
	DECLARE @idtreasurer int
	DECLARE @ypay int
	SELECT @idtreasurer = idtreasurer, @ypay = ypay
	FROM payment WHERE kpay = ISNULL(@newkpay,@oldkpay)
	
	-- Considero l'importo corrente del movimento di spesa inserito nel mandato di pagamento 
	-- vado così a considerare tutte le variazioni eventualmente inserite fino a quel momento
	SELECT @newamount = ISNULL(SUM(curramount),0)
	FROM expensetotal
	JOIN expenselast
		ON expensetotal.idexp = expenselast.idexp
	WHERE expensetotal.ayear = @ypay
		AND expenselast.idexp = @idexp
	
	-- caso inserimento nella reversale 
	if ((@newkpay is not null) and (@idtreasurer is not null))
	-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ypay,
		@idtreasurer,
		'E',
		0,
		@newamount
	END
	
	if ((@oldkpay is not null) and (@idtreasurer is not null))
	-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
	BEGIN
		EXEC trg_upd_treasurercashtotal
		@ypay,
		@idtreasurer,
		'E',
		@newamount,
		0	
	END

END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




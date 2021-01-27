
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_incomelast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_incomelast]
GO

CREATE TRIGGER [trigger_i_incomelast] ON [incomelast] FOR INSERT
AS BEGIN 

	DECLARE @idinc int
	DECLARE @kpro int
	SELECT	@idinc = idinc,
			@kpro = kpro
	FROM inserted

	DECLARE @idtreasurer int
	DECLARE @ypro int
	SELECT 
		@idtreasurer = idtreasurer, 
		@ypro = ypro
	FROM proceeds 
	WHERE kpro = @kpro
	
	-- Considero l'importo corrente del movimento di spesa inserito nel mandato di pagamento 
	-- vado così a considerare tutte le variazioni eventualmente inserite fino a quel momento
	DECLARE @amount decimal(19,2)
	--SELECT @amount = ISNULL(amount,0)	FROM incomeyear	WHERE incomeyear.ayear = @ypro		AND incomeyear.idinc = @idinc

	if (@idtreasurer is not null)
	BEGIN
		SELECT @amount = ISNULL(curramount,0)	FROM incometotal	WHERE incometotal.ayear = @ypro	AND incometotal.idinc = @idinc

		if (isnull(@amount,0) <>0) begin
			EXEC trg_upd_treasurercashtotal		@ypro,		@idtreasurer,		'I',		0,		@amount
		end
	END







END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



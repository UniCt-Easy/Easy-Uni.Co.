
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_incomelast]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_incomelast]
GO

CREATE TRIGGER [trigger_u_incomelast] ON [incomelast] FOR UPDATE
AS BEGIN
IF UPDATE(kpro)
BEGIN
	DECLARE @idinc int
	DECLARE @newkpro int
	DECLARE @oldkpro int
	
	SELECT  @idinc = idinc, @newkpro = kpro FROM inserted
	SELECT  @oldkpro = kpro FROM deleted
	
	DECLARE @newamount decimal(19,2)
	
	DECLARE @idtreasurer int
	DECLARE @ypro int
	
	SELECT @idtreasurer = idtreasurer, @ypro = ypro
	FROM proceeds WHERE kpro = ISNULL(@newkpro,@oldkpro)
	
	-- Considero l'importo corrente dei movimenti di entrata inserito nella reversale di incasso 
	-- vado così a considerare tutte le variazioni eventualmente inserite fino a quel momento
	SELECT @newamount = ISNULL(SUM(curramount),0)
	FROM incometotal
	JOIN incomelast
		ON incometotal.idinc = incomelast.idinc
	WHERE incometotal.ayear = @ypro
	AND incomelast.idinc = @idinc
	
	-- caso inserimento nella reversale 
	if ((@newkpro is not null)and(@idtreasurer is not null))
	BEGIN
		-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
		EXEC trg_upd_treasurercashtotal
		@ypro,
		@idtreasurer,
		'I',
		0,
		@newamount
	END
	
	if ((@oldkpro is not null) and (@idtreasurer is not null))
	BEGIN
		-- Ricalcolo del Fondo di Cassa del Tesoriere corrispondente
		EXEC trg_upd_treasurercashtotal
		@ypro,
		@idtreasurer,
		'I',
		@newamount,
		0
	END

END
END




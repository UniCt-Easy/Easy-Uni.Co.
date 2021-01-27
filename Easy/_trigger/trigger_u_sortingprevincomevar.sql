
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_sortingprevincomevar]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_sortingprevincomevar]
GO

CREATE TRIGGER [trigger_u_sortingprevincomevar] ON [sortingprevincomevar] FOR UPDATE
AS BEGIN
	IF UPDATE(idsor) OR
	UPDATE(amount)
	BEGIN
		DECLARE @ayear int
		DECLARE @newidsor varchar(32)
		DECLARE @newamount decimal(19,2)
		DECLARE @oldidsor varchar(32)
		DECLARE @oldamount decimal(19,2)
	
		SELECT 
			@newidsor = idsor, 
			@ayear = ayear, 
			@newamount = amount
		FROM inserted
	
		SELECT
			@oldidsor = idsor,
			@oldamount = -amount
		FROM deleted
	
		EXECUTE trg_upd_sorttotal 
		@newidsor, 
		@ayear, 
		'totincomevariation',
		@newamount
	
		EXECUTE trg_upd_sorttotal 
		@oldidsor, 
		@ayear, 
		'totincomevariation',
		@oldamount
	END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


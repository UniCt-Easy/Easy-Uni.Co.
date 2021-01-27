
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_incomesorted]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_incomesorted]
GO

CREATE TRIGGER [trigger_i_incomesorted] ON [incomesorted] FOR INSERT
AS BEGIN
	DECLARE @idinc int
	DECLARE @idsor int
	DECLARE @ayear int
 	DECLARE @amount decimal(19,2)
	
	SELECT 
		@idinc = idinc, 
		@idsor = idsor, 
		@ayear= ayear,
		@amount = amount 
	FROM inserted
	
	IF (@ayear IS NULL)
	BEGIN
		SELECT @ayear = ymov FROM income WHERE idinc = @idinc
	END
	
	EXECUTE trg_upd_sorttotal 
	@idsor, 
	@ayear, 
	'totalincome', 
	@amount
	END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


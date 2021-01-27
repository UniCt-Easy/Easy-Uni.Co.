
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_surplus]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_surplus]
GO

CREATE TRIGGER [trigger_i_surplus] ON [surplus] FOR INSERT
AS BEGIN
	DECLARE @ayear int
	DECLARE @newayear int
	
	SELECT @ayear = ayear FROM inserted
	SET @newayear = @ayear + 1

	DECLARE @idfinincomesurplus int
	SELECT @idfinincomesurplus = idfinincomesurplus FROM config WHERE ayear = @newayear
	IF EXISTS(SELECT * FROM accountingyear WHERE ayear = @newayear) AND (@idfinincomesurplus IS NULL)
	BEGIN
		EXEC rebuild_currentfloatfund @newayear
	END
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

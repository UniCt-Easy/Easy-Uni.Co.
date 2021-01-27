
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_epexp]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_epexp]
GO


CREATE                   TRIGGER [trigger_d_epexp] ON [epexp] FOR DELETE
AS BEGIN

	DECLARE @idepexp int

	SELECT	@idepexp = idepexp
                
	FROM deleted
	
	DELETE FROM  epexptotal WHERE idepexp = @idepexp

	-- copiato da trigger_delete_expenseyear
	
	CREATE TABLE #epexp (idepexp int,  nphase tinyint)
	INSERT INTO #epexp (idepexp, nphase)
	SELECT idepexp,  nphase FROM deleted

    DELETE FROM epexpyear WHERE idepexp IN 
	(SELECT idepexp FROM #epexp) AND amount = 0

END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


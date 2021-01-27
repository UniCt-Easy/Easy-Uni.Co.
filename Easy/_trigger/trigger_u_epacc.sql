
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_epacc]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_epacc]
GO


CREATE                   TRIGGER [trigger_u_epacc] ON [epacc] FOR UPDATE
AS BEGIN
	DECLARE @idepacc int
	DECLARE @nphase tinyint
	DECLARE @newidaccmotive varchar(36)

	SELECT
		@idepacc = INS.idepacc,
		@nphase = INS.nphase,
		@newidaccmotive = INS.idaccmotive
	FROM inserted INS
	

	DECLARE @oldidaccmotive varchar(36)

	SELECT @oldidaccmotive = idaccmotive		
	FROM deleted


	IF	(isnull(@newidaccmotive,'') <> isnull( @oldidaccmotive,'') and @nphase=1)
	BEGIN
		update epacc set idaccmotive=@newidaccmotive where paridepacc=@idepacc
	END

END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


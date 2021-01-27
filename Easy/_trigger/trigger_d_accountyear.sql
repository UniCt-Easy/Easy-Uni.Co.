
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_accountyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_accountyear]
GO

CREATE    TRIGGER [trigger_d_accountyear] ON [accountyear] FOR DELETE
AS BEGIN
	DECLARE @idacc varchar(38)
	DECLARE @idupb varchar(36)
	DECLARE	@prevision decimal(19, 2)
	DECLARE	@prevision2 decimal(19, 2)
	DECLARE	@prevision3 decimal(19, 2)
	DECLARE	@prevision4 decimal(19, 2)
	DECLARE	@prevision5 decimal(19, 2)
	DECLARE @ayear int

	SELECT	@idacc = idacc, @idupb = idupb,
	@prevision=-prevision, @prevision2=-prevision2, @prevision3=-prevision3, @prevision4=-prevision4, @prevision5=-prevision5, 
	@ayear = ayear
	FROM deleted

	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM account WHERE idacc = @idacc

	DECLARE @minlevelop tinyint
	SELECT @minlevelop = MIN(nlevel) FROM accountlevel WHERE flagusable='S' AND ayear = @ayear

	IF (@nlevel <= @minlevelop)
	BEGIN
		EXEC trg_upd_upbaccountextended @idacc,@idupb,@prevision,@prevision2,@prevision3,@prevision4,@prevision5
	END
		

	DELETE FROM upbaccounttotal WHERE idacc = @idacc and idupb = @idupb
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


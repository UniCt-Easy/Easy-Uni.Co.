
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_parasubcontract]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_parasubcontract]
GO

CREATE  TRIGGER [trigger_u_parasubcontract] ON [parasubcontract] FOR UPDATE
AS BEGIN

	declare @idcon varchar(20) 	
	declare @iddbdepartment varchar(50) 	
	declare @new_idreg int
	set @iddbdepartment = USER

	select @idcon= idcon,
			@new_idreg= idreg 
			from inserted


	declare @certkind char(1)
	select @certkind = ISNULL(S.certificatekind, '') from service S
			join  inserted I on I.idser=S.idser

	if (@certkind<>'U')begin
		delete from parasubcontractlist where idcon = @idcon and iddbdepartment=@iddbdepartment and balanced='N'
		return
	end
				
		
	if exists (	SELECT *	FROM parasubcontractyear P
					WHERE P.idcon= @idcon 
					AND NOT EXISTS		(SELECT * FROM parasubcontractlist L
							WHERE L.ayear = P.ayear	AND L.idcon =P.idcon	AND L.iddbdepartment = @iddbdepartment)
			)
	BEGIN
		INSERT INTO parasubcontractlist	(	ayear,idcon,iddbdepartment,idreg,balanced,linked)
		SELECT P.ayear, @idcon, @iddbdepartment, @new_idreg, 'N', 'N'
			FROM parasubcontractyear P
			WHERE P.idcon= @idcon 
				AND NOT EXISTS		(SELECT * FROM parasubcontractlist L
						WHERE L.ayear = P.ayear	AND L.idcon =P.idcon	AND L.iddbdepartment = @iddbdepartment)
	END

	declare @old_idreg int
	select @old_idreg= idreg from deleted

	if (@new_idreg <> @old_idreg) BEGIN
		UPDATE parasubcontractlist set idreg = @new_idreg where
				idcon=@idcon and iddbdepartment = @iddbdepartment
	END
	
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


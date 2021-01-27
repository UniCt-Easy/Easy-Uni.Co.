
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_pettycashoperation]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_pettycashoperation]
GO

CREATE TRIGGER [trigger_d_pettycashoperation] ON [pettycashoperation] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	DECLARE @yoperation smallint
	DECLARE @noperation int
	DECLARE @idpettycash int
	DECLARE @kind tinyint

	SELECT
		@yoperation = yoperation,
		@noperation = noperation,
		@idpettycash = idpettycash,
		@kind = flag
	FROM deleted

	IF (@kind & 2) <> 0
	BEGIN
		UPDATE pettycashoperation
		SET yrestore = NULL,
		nrestore = NULL
		WHERE yoperation = @yoperation
		AND idpettycash = @idpettycash
		AND ((flag & 8) <> 0)
		AND yrestore = @yoperation
		AND nrestore = @noperation
	END
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_sortingextended]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_sortingextended]
GO

CREATE PROCEDURE [trg_upd_sortingextended]
(
	@idsor int,
	@idacc varchar(38),
	@previousprev decimal(19,2),
	@currentprev decimal(19,2)
)
AS BEGIN
IF (@idacc IS NOT NULL)
BEGIN
	WHILE (LEN(@idacc)>=6)
	BEGIN
		IF NOT EXISTS (SELECT * FROM sortingtotal
		WHERE idsor = @idsor
		AND idacc = @idacc)
		BEGIN
			INSERT INTO sortingtotal
			(
				idsor,
				idacc,
				previousprev,
				currentprev
			)
			VALUES
			(
				@idsor,
				@idacc,
				ISNULL(@previousprev,0),
				ISNULL(@currentprev,0)
			)
		END
		ELSE
		BEGIN
			UPDATE sortingtotal SET
			previousprev = ISNULL(previousprev,0) + ISNULL(@previousprev,0),
			currentprev = ISNULL(currentprev,0) + ISNULL(@currentprev,0)
			WHERE idsor = @idsor
			AND idacc = @idacc
		END
		SET @idacc = SUBSTRING(@idacc,1,LEN(@idacc)-4)
	END
END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


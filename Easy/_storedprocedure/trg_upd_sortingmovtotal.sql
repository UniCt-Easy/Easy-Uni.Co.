
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_sortingmovtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_sortingmovtotal]
GO

CREATE  PROCEDURE trg_upd_sortingmovtotal
(
	@movementkind char(1),
	@idsor int,
	@idacc varchar(38),
	@amount decimal(19,2)
)
AS BEGIN
	-- Per il momento @movementkind non � utilizzato - da decidere se usarlo e quali valori passarli
	IF (@idacc IS NOT NULL AND @idsor IS NOT NULL)
	BEGIN
		WHILE (LEN(@idacc) >= 4)
		BEGIN
			IF NOT EXISTS(
				(SELECT * FROM sortingexpensetotal
				WHERE idsor = @idsor
				AND idacc = @idacc)
			)
			BEGIN
				INSERT INTO sortingexpensetotal
				(
					idsor,
					idacc,
					total
				)
				VALUES
				(
					@idsor,
					@idacc,
					@amount
				)
			END
			ELSE
			BEGIN
				UPDATE sortingexpensetotal
				SET total = ISNULL(total,0) + ISNULL(@amount,0)
				WHERE idsor = @idsor
				AND idacc = @idacc
			END
			SET @idacc = SUBSTRING(@idacc,1,LEN(@idacc) - 4)
		END
	END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


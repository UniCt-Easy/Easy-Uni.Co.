
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_upbepexptotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure trg_upd_upbepexptotal
GO
--setuser 'amm'
CREATE    PROCEDURE [trg_upd_upbepexptotal]
(
	@idacc varchar(38),
	@idupb varchar(36),
	@nphase tinyint,
	@amount decimal(19,2),
	@amount2 decimal(19,2),
	@amount3 decimal(19,2),
	@amount4 decimal(19,2),
	@amount5 decimal(19,2)
)
AS BEGIN
-- Gli importi di input, in caso di impegno nota di variazione, hanno l'importo cambiato di segno.
DECLARE @countyear int

DECLARE @nlevel tinyint
SELECT @nlevel = nlevel FROM account WHERE idacc = @idacc

WHILE (@nlevel >= 1)
BEGIN
	SELECT @countyear = COUNT(*) 	FROM upbepexptotal
				WHERE idacc = @idacc	AND idupb = @idupb 		AND nphase = @nphase

	IF (@countyear = 0)
	BEGIN
		INSERT INTO upbepexptotal (idacc, idupb, nphase, total,total2,total3,total4,total5)
			VALUES (@idacc, @idupb, @nphase, isnull(@amount,0),isnull(@amount2,0),isnull(@amount3,0),isnull(@amount4,0),isnull(@amount5,0))				
	END
	ELSE
	BEGIN
		UPDATE upbepexptotal SET
			total = ISNULL(total, 0) + isnull(@amount,0),
			total2 = ISNULL(total2, 0) + isnull(@amount2,0),
			total3 = ISNULL(total3, 0) +  isnull(@amount3,0),
			total4 = ISNULL(total4, 0) +  isnull(@amount4,0),
			total5 = ISNULL(total5, 0) + isnull(@amount5,0)

			WHERE idacc = @idacc
				AND idupb = @idupb
				AND nphase = @nphase
				
	END
		
	SET @nlevel = @nlevel - 1
	SELECT @idacc = SUBSTRING(@idacc,1,len(@idacc)-4)
END


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


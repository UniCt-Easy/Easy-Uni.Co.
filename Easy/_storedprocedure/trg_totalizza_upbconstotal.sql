
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_totalizza_upbconstotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_totalizza_upbconstotal]
GO

CREATE  PROCEDURE [trg_totalizza_upbconstotal]
(
	@idfin int,
	@idupb varchar(36),
	@amount decimal(19,2),
	@A_I char(1) ='A' --A per approvata, I per inserita
)
AS BEGIN
		if (@A_I = 'A') 
		BEGIN
			WHILE (LEN(@idupb) >0)
			BEGIN 
					IF (EXISTS (SELECT * FROM upbconstotal 	WHERE idupb = @idupb 	AND	  idfin = @idfin) )
					BEGIN
						UPDATE upbconstotal SET	totprev = ISNULL(totprev, 0) + ISNULL(@amount,0)
						WHERE   idupb = @idupb
						AND idfin = @idfin
					END
					ELSE
					BEGIN
						INSERT INTO upbconstotal (idupb, idfin, totprev)
						VALUES ( @idupb, @idfin, ISNULL(@amount,0))
					END
					SET @idupb = SUBSTRING(@idupb,1,LEN(@idupb)-4)
			END
		END
		ELSE
		BEGIN
			WHILE (LEN(@idupb) >0)
			BEGIN 
					IF (EXISTS (SELECT * FROM upbconstotal 	WHERE idupb = @idupb 	AND	  idfin = @idfin) )
					BEGIN
						UPDATE upbconstotal SET	totprev_inserted = ISNULL(totprev_inserted, 0) + ISNULL(@amount,0)
						WHERE   idupb = @idupb
						AND idfin = @idfin
					END
					ELSE
					BEGIN
						INSERT INTO upbconstotal (idupb, idfin, totprev_inserted)
						VALUES ( @idupb, @idfin, ISNULL(@amount,0))
					END
					SET @idupb = SUBSTRING(@idupb,1,LEN(@idupb)-4)
			END
		END
	END
 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


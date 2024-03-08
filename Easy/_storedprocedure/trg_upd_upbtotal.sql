
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_upbtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_upbtotal]
GO


CREATE  PROCEDURE [trg_upd_upbtotal]
(
	@idfin int,
	@idupb varchar(36),
	@updatefield varchar(255),
	@amount decimal(19,2)
)
AS BEGIN
	DECLARE @cmd1 varchar(255)
	DECLARE @cmd2 varchar(255)
	DECLARE @cmd3 varchar(255)
	declare @originalidfin int
	set @originalidfin=@idfin

	IF @idfin IS NOT NULL
	BEGIN
		DECLARE @nlevel tinyint
		SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin
		WHILE(@nlevel > 0)
		BEGIN
		IF NOT EXISTS (SELECT * FROM upbtotal WHERE idfin = @idfin AND idupb = @idupb)
		   BEGIN
			SET @cmd1 = 'INSERT INTO upbtotal(idfin, idupb, ' + @updatefield +
			  ')VALUES (' +
			   CONVERT(varchar(10),@idfin) + ', ''' + @idupb + ''',' + STR(@amount, 20, 4) + ')'
		   END
		   ELSE
		   BEGIN
			SET @cmd1 = 'UPDATE upbtotal SET '+
			  @updatefield + ' = ISNULL(' + @updatefield + ', 0) + ' + STR(@amount, 20, 4)+
			   ' WHERE idfin = ' + CONVERT(varchar(10),@idfin)+
					   ' AND idupb = ''' + @idupb + ''''
		   END
			EXEC (@cmd1)
			-- Se modifico i campi delle variazioni di bilancio
			-- DEVO PROPAGARE LE MODIFICHE FINO AL TITOLO!
			-- Diversamente la modifica viene effettuata SOLO sul livello di pertinenza!
			IF (@updatefield = 'previsionvariation' OR @updatefield = 'secondaryvariation')
			BEGIN
				SET @nlevel = @nlevel - 1
				SELECT @idfin = idparent FROM finlink WHERE idchild = @idfin AND nlevel = @nlevel
			END
			ELSE
			BEGIN
				SET @nlevel = 0
			END
		END
	END

	IF ((@updatefield = 'prevision') OR  (@updatefield = 'previsionvariation')  OR  (@updatefield = 'previsionvariation_inserted')) 
	-- totalizza sugli UPB la previsione principale nel campo totprev di upbconstotal
	EXEC trg_totalizza_upbconstotal @originalidfin,@idupb, @amount,'A'

	IF (@updatefield = 'previsionvariation_inserted') 
	-- totalizza sugli UPB la previsione principale nel campo totprev di upbconstotal
	EXEC trg_totalizza_upbconstotal @originalidfin,@idupb, @amount,'I'

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


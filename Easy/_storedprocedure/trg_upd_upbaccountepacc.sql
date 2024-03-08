
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
 
if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_upbaccountepacc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_upbaccountepacc]
GO


CREATE  PROCEDURE [trg_upd_upbaccountepacc]
(
	@idmov int,
	@ayear int,
	@nphase tinyint,
	@idacc varchar(38),
	@idupb varchar(36)
)
AS BEGIN
DECLARE @currentphase tinyint
DECLARE @maxphase tinyint
-- Viene implementato un cursore che cambia le coppie idupb/idfin solo x i figli diretti

	-- IF usato altrimenti nel caso non ci sono righe il cursore può andare in errore
	-- N.B. Quando viene adoperato un cursore in una SP che può essere chiamata in modo ciclico
	-- bisogna adoperare la dichiarazione del cursore come se fosse una var. locale e non con
	-- INSENSITIVE CURSOR FOR

	IF (SELECT COUNT(*) FROM epacc WHERE paridepacc = @idmov) = 0 
	RETURN

	DECLARE @idepacc int
	DECLARE @crs_acc CURSOR

	SET @crs_acc = CURSOR FOR
	SELECT idepacc FROM epacc WHERE paridepacc = @idmov
	FOR READ ONLY

	OPEN @crs_acc
	
	FETCH NEXT FROM @crs_acc INTO @idepacc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		UPDATE epaccyear SET idacc = @idacc, idupb = @idupb --, lu = '''TRIGGER''', lt = GETDATE()
		WHERE idepacc = @idepacc
			AND ayear = @ayear

		FETCH NEXT FROM @crs_acc INTO @idepacc
	END
	CLOSE @crs_acc
	DEALLOCATE @crs_acc


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


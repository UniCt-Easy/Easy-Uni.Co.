
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_upb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_upb]
GO


CREATE  PROCEDURE [trg_upd_upb]
(
	@movkind char(1),
	@idmov int,
	@ayear int,
	@nphase tinyint,
	@idfin int,
	@idupb varchar(36)
)
AS BEGIN
DECLARE @currentphase tinyint
DECLARE @maxphase tinyint
-- Viene implementato un cursore che cambia le coppie idupb/idfin solo x i figli diretti
IF @movkind = 'I'
BEGIN
	-- IF usato altrimenti nel caso non ci sono righe il cursore può andare in errore
	IF (SELECT COUNT(*) FROM income WHERE parentidinc = @idmov) = 0 RETURN
	DECLARE @idinc int
	DECLARE @crs_inc CURSOR
	
	SET @crs_inc = CURSOR FOR
	SELECT idinc FROM income WHERE parentidinc = @idmov
	FOR READ ONLY

	OPEN @crs_inc
	
	FETCH NEXT FROM @crs_inc INTO @idinc
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		UPDATE incomeyear SET idfin = @idfin, idupb = @idupb,
		lu = '''TRIGGER''', lt = GETDATE()
		WHERE idinc = @idinc
			AND ayear = @ayear

		FETCH NEXT FROM @crs_inc INTO @idinc
	END
	CLOSE @crs_inc
	DEALLOCATE @crs_inc

/*	UPDATE incomeyear SET
	idfin = @idfin, idupb = @idupb,
	lu = '''TRIGGER''', lt = GETDATE()
	FROM incomelink
	WHERE idparent = @idmov
	AND nlevel = @nphase
	AND incomeyear.ayear = @ayear
	AND incomeyear.idinc = incomelink.idchild
	AND incomelink.idchild <> incomelink.idparent*/
END
ELSE
BEGIN
	-- IF usato altrimenti nel caso non ci sono righe il cursore può andare in errore
	-- N.B. Quando viene adoperato un cursore in una SP che può essere chiamata in modo ciclico
	-- bisogna adoperare la dichiarazione del cursore come se fosse una var. locale e non con
	-- INSENSITIVE CURSOR FOR
	IF (SELECT COUNT(*) FROM expense WHERE parentidexp = @idmov) = 0 RETURN
	DECLARE @idexp int
	DECLARE @crs_exp CURSOR

	SET @crs_exp = CURSOR FOR
	SELECT idexp FROM expense WHERE parentidexp = @idmov
	FOR READ ONLY

	OPEN @crs_exp
	
	FETCH NEXT FROM @crs_exp INTO @idexp
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		UPDATE expenseyear SET idfin = @idfin, idupb = @idupb,
		lu = '''TRIGGER''', lt = GETDATE()
		WHERE idexp = @idexp
			AND ayear = @ayear

		FETCH NEXT FROM @crs_exp INTO @idexp
	END
	CLOSE @crs_exp
	DEALLOCATE @crs_exp

/*	UPDATE expenseyear SET
	idfin = @idfin, idupb = @idupb,
	lu = '''TRIGGER''', lt = GETDATE()
	FROM expenselink
	WHERE idparent = @idmov
	AND nlevel = @nphase
	AND expenseyear.ayear = @ayear
	AND expenseyear.idexp = expenselink.idchild
	AND expenselink.idchild <> expenselink.idparent*/
END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_fin]
GO

CREATE PROCEDURE [trg_upd_fin]
(
	@movementkind char(1),
	@idmovement int,
	@ayear int,
	@nphase tinyint,
	@idfin int
)
AS BEGIN
	CREATE TABLE #tempmov (idmov int)

	IF @movementkind = 'I'
	BEGIN
		INSERT INTO #tempmov SELECT idchild FROM incomelink WHERE idparent = @idmovement AND nlevel > @nphase
	
		UPDATE incomeyear SET idfin = @idfin 
		FROM #tempmov WHERE incomeyear.idinc = #tempmov.idmov
	END
	ELSE
	BEGIN
		INSERT INTO #tempmov SELECT idchild FROM expenselink WHERE idparent = @idmovement AND nlevel > @nphase
	
		UPDATE expenseyear SET idfin = @idfin 
		FROM #tempmov WHERE expenseyear.idexp = #tempmov.idmov
	END

	DROP TABLE #tempmov
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


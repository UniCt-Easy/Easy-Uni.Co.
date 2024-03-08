
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_sorttotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_sorttotal]
GO

CREATE  PROCEDURE [trg_upd_sorttotal]
(
	@idsor varchar(36),
	@ayear smallint,
	@updatefield varchar(100),
	@amount decimal(19,2)
)
AS BEGIN
DECLARE @stringaSQL nvarchar(2000)

IF NOT EXISTS
	(SELECT * FROM sortedmovementtotal 
	WHERE idsor = @idsor
		AND ayear = @ayear)
BEGIN
	SELECT @stringaSQL = N'INSERT INTO sortedmovementtotal (idsor, ayear, ' + @updatefield + ')'
	+ 'VALUES (''' + @idsor + ''', '
	+ CONVERT(char(4), @ayear) + ', ' + STR(@amount, 20, 4) + ')'
END
	ELSE
BEGIN
	SELECT @stringaSQL = N'UPDATE sortedmovementtotal SET ' + @updatefield
	+ ' = ISNULL(' + @updatefield + ', 0) + ' + STR(@amount, 20, 4)
	+ 'WHERE idsor = '''+ @idsor
	+ ''' AND ayear = ' + CONVERT(char(4), @ayear)
END
EXEC sp_executesql @stringaSQL
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


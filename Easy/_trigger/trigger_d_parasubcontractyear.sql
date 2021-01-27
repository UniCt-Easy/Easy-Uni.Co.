
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_parasubcontractyear]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_parasubcontractyear]
GO

CREATE  TRIGGER [trigger_d_parasubcontractyear] ON [parasubcontractyear] FOR DELETE
AS BEGIN
	CREATE TABLE #paras
	(
		idcon varchar(8),
		ayear int,
		iddbdepartment varchar(50)
	)

	INSERT INTO #paras (idcon, ayear, iddbdepartment)
	SELECT D.idcon, D.ayear, USER
	FROM deleted D

	DELETE FROM parasubcontractlist
	WHERE EXISTS
		(SELECT * FROM #paras
		WHERE #paras.ayear = parasubcontractlist.ayear
			AND #paras.idcon = parasubcontractlist.idcon
			AND #paras.iddbdepartment = parasubcontractlist.iddbdepartment)

	DROP TABLE #paras
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


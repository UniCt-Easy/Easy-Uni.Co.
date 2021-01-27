
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_exhibitedcud]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_exhibitedcud]
GO

CREATE  TRIGGER [trigger_i_exhibitedcud] ON [exhibitedcud] FOR INSERT
AS BEGIN
	CREATE TABLE #cud
	(
		idlinkedcon varchar(8),
		idlinkeddbdepartment varchar(50),
		ayear int
	)

	
	INSERT INTO #cud (idlinkedcon, idlinkeddbdepartment, ayear)
	SELECT I.idlinkedcon, I.idlinkeddbdepartment, I.fiscalyear
	FROM inserted I
	WHERE I.idlinkedcon IS NOT NULL

	UPDATE parasubcontractlist
	SET linked = 'S'
	FROM #cud
	WHERE #cud.idlinkedcon = parasubcontractlist.idcon
		AND #cud.idlinkeddbdepartment = parasubcontractlist.iddbdepartment
		AND #cud.ayear = parasubcontractlist.ayear

	DROP TABLE #cud
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


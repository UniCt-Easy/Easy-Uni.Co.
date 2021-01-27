
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_exhibitedcud]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_exhibitedcud]
GO

CREATE  TRIGGER [trigger_u_exhibitedcud] ON [exhibitedcud] FOR UPDATE
AS BEGIN
	CREATE TABLE #cud
	(
		oldidlinkedcon varchar(8),
		oldidlinkeddbdepartment varchar(50),
		newidlinkedcon varchar(8),
		newidlinkeddbdepartment varchar(50),
		ayear int
	)
	
	INSERT INTO #cud (oldidlinkedcon, oldidlinkeddbdepartment, newidlinkedcon, newidlinkeddbdepartment, ayear)
	SELECT D.idlinkedcon, D.idlinkeddbdepartment, I.idlinkedcon, I.idlinkeddbdepartment, I.fiscalyear
	FROM deleted D
	JOIN inserted I
		ON D.idexhibitedcud = I.idexhibitedcud
		AND D.idcon = I.idcon
	WHERE (D.idlinkedcon IS NULL AND I.idlinkedcon IS NOT NULL)
		OR (D.idlinkedcon IS NOT NULL AND I.idlinkedcon IS NULL)

	UPDATE parasubcontractlist
	SET linked = 'S'
	FROM #cud
	WHERE #cud.newidlinkedcon = parasubcontractlist.idcon
		AND #cud.newidlinkeddbdepartment = parasubcontractlist.iddbdepartment
		AND #cud.ayear = parasubcontractlist.ayear
		AND newidlinkedcon IS NOT NULL

	UPDATE parasubcontractlist
	SET linked = 'N'
	FROM #cud
	WHERE #cud.oldidlinkedcon = parasubcontractlist.idcon
		AND #cud.oldidlinkeddbdepartment = parasubcontractlist.iddbdepartment
		AND #cud.ayear = parasubcontractlist.ayear
		AND newidlinkedcon IS NULL

	DROP TABLE #cud
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


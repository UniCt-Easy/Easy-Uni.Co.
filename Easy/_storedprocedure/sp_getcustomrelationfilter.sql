
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sp_getcustomrelationfilter]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_getcustomrelationfilter]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                                      PROCEDURE [sp_getcustomrelationfilter]  @fromtable varchar(50), @totable varchar(50), @edittype varchar(50), @operation char(1)  AS
BEGIN
	CREATE TABLE #tabfiltro
			(
			filtro            varchar(200) NULL
			)
		
	
		IF ((@fromtable='fin')  and  (@totable='creditvardetail')  and  (@edittype='default')  and  (@operation='I'))
			INSERT INTO #tabfiltro VALUES ('(finpart=''S'')')	
			
		IF ((@fromtable='fin')  and  (@totable='creditvardetail')  and  (@edittype='default')  and  (@operation='S'))
			INSERT INTO #tabfiltro VALUES ('(finpart=''S'')')	
		
		IF ((@fromtable='mandate')  and  (@totable='expense')  and  (@edittype='default') and  (@operation='I'))
			INSERT INTO #tabfiltro 
			VALUES ('(nphase=''<%sys[mandatephase]%>'')')	
		SELECT * FROM #tabfiltro 
			ORDER BY filtro
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


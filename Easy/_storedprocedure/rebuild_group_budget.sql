
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_group_budget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_group_budget]
GO

CREATE  PROCEDURE [rebuild_group_budget]
(@ayear int = NULL)
AS BEGIN

	PRINT 'Ricostruzione di EPEXPTOTAL...'
	EXEC rebuild_epexptotal @ayear
	
	PRINT 'Ricostruzione di EPACCTOTAL...'
	EXEC rebuild_epacctotal @ayear
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

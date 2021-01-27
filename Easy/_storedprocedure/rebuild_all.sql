
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_all]
GO

CREATE  PROCEDURE [rebuild_all]
(@ayear int = null, @r varchar(10)=null)
AS BEGIN
PRINT 'Ricostruzione Totali Tabelle LINK dei movimenti ...'
if (@r='H')
	EXEC rebuild_group_link @ayear
else 
	WAITFOR DELAY '00:00:30'

PRINT 'Ricostruzione Totali Movimenti Finanziari...'
if (@r='H')
EXEC rebuild_group_financial @ayear
else 
	WAITFOR DELAY '00:00:30'

PRINT 'Ricostruzione degli UPB...'
if (@r='H')
EXEC rebuild_group_upb @ayear
else 
	WAITFOR DELAY '00:00:30'

PRINT 'Ricostruzione del Fondo di Cassa Corrente...'
if (@r='H')
EXEC rebuild_currentfloatfund @ayear 
else 
	WAITFOR DELAY '00:01'

PRINT 'Ricostruzione dei Totali delle Classificazioni...'
if (@r='H')
EXEC rebuild_sortedmovementtotal @ayear 
else 
	WAITFOR DELAY '00:01'

PRINT 'Ricostruzione dei Totali del Budget'
if (@r='H')
EXEC rebuild_group_budget @ayear
else 
	WAITFOR DELAY '00:01'

PRINT 'Ricostruzione LINK patrimoniali ...'
if (@r='H')
EXEC rebuild_group_cespiti @ayear
else 
	WAITFOR DELAY '00:01'

PRINT 'Ricostruzione LINK classificazioni ...'
if (@r='H')
EXEC rebuild_sortinglink
else 
	WAITFOR DELAY '00:01'

PRINT 'Ricostruzione totali ep...'
if (@r='H')
EXEC rebuild_group_upbaccount @ayear
else 
	WAITFOR DELAY '00:01'

PRINT 'Ricostruzione Totali Scritture EP...'
if (@r='H')
EXEC rebuild_entrytotal @ayear
else 
	WAITFOR DELAY '00:01'

	



END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


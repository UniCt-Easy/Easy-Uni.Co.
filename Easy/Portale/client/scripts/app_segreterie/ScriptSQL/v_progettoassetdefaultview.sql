
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA progettoassetdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[progettoassetdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [progettoassetdefaultview]
GO


GO

-- VERIFICA DI progettoassetdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoassetdefaultview'
-- VERIFICA DI progettoassetdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoassetdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'progettoassetdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoassetdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



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


-- CREAZIONE VISTA saldefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[saldefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [saldefaultview]
GO

CREATE VIEW [saldefaultview] AS 
SELECT  sal.budget AS sal_budget, sal.datablocco AS sal_datablocco, sal.idprogetto, sal.idsal, sal.start, sal.stop AS sal_stop,
 isnull('dal ' + CONVERT(VARCHAR, sal.start, 103),'') + ' ' + isnull('al ' + CONVERT(VARCHAR, sal.stop, 103),'') as dropdown_title
FROM sal WITH (NOLOCK) 
WHERE  sal.idprogetto IS NOT NULL  AND sal.idsal IS NOT NULL 
GO


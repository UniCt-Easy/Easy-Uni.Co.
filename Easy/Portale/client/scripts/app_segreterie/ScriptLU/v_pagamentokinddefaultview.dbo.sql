
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA pagamentokinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pagamentokinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pagamentokinddefaultview]
GO

CREATE VIEW [dbo].[pagamentokinddefaultview] AS 
SELECT CASE WHEN pagamentokind.active = 'S' THEN 'Si' WHEN pagamentokind.active = 'N' THEN 'No' END AS pagamentokind_active, pagamentokind.ct AS pagamentokind_ct, pagamentokind.cu AS pagamentokind_cu, pagamentokind.idpagamentokind, pagamentokind.lt AS pagamentokind_lt, pagamentokind.lu AS pagamentokind_lu, pagamentokind.sortcode AS pagamentokind_sortcode, pagamentokind.title,
 isnull('Tipologia: ' + pagamentokind.title + '; ','') as dropdown_title
FROM [dbo].pagamentokind WITH (NOLOCK) 
WHERE  pagamentokind.idpagamentokind IS NOT NULL 
GO


-- GENERAZIONE DATI PER pagamentokinddefaultview --

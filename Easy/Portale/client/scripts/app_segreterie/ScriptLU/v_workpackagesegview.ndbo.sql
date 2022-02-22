
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


-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [workpackagesegview]
GO

CREATE VIEW [workpackagesegview] AS 
SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, workpackage.idstruttura AS workpackage_idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.start AS workpackage_start, workpackage.stop AS workpackage_stop, workpackage.title AS workpackage_title,
 isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') as dropdown_title
FROM workpackage WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON workpackage.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 
GO


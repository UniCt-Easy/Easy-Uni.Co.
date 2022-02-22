
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


-- CREAZIONE VISTA diderogdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[diderogdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[diderogdefaultview]
GO

CREATE VIEW [dbo].[diderogdefaultview] AS 
SELECT  diderog.aa,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, diderog.idcorsostudio,
 [dbo].sede.title AS sede_title, diderog.idsede,CASE WHEN diderog.inesaurimento = 'S' THEN 'Si' WHEN diderog.inesaurimento = 'N' THEN 'No' END AS diderog_inesaurimento,
 isnull('Corso di studio: ' + [dbo].corsostudio.title + '; ','') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Anno accademico di istituzione: ' +CAST( annoistituz AS NVARCHAR(64)) from corsostudio x where x.idcorsostudio = diderog.idcorsostudio) + '; ','') + ' ' + isnull('Anno Accademico: ' + diderog.aa + '; ','') + ' ' + isnull('Identificativo: ' + [dbo].sede.title + '; ','') as dropdown_title
FROM [dbo].diderog WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON diderog.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON diderog.idsede = [dbo].sede.idsede
WHERE  diderog.aa IS NOT NULL  AND diderog.idcorsostudio IS NOT NULL  AND diderog.idsede IS NOT NULL 
GO


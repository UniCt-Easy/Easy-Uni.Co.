
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


-- CREAZIONE VISTA istanzaseganagstusonpreview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[istanzaseganagstusonpreview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[istanzaseganagstusonpreview]
GO

CREATE VIEW [dbo].[istanzaseganagstusonpreview] AS 
SELECT  istanza.aa, istanza.ct AS istanza_ct, istanza.cu AS istanza_cu, istanza.data AS istanza_data, istanza.extension AS istanza_extension, istanza.idcorsostudio, istanza.iddidprog, istanza.idiscrizione AS istanza_idiscrizione, istanza.idistanza,
 [dbo].istanzakind.title AS istanzakind_title, istanza.idistanzakind, istanza.idreg_studenti,
 [dbo].statuskind.title AS statuskind_title, istanza.idstatuskind AS istanza_idstatuskind, istanza.lt AS istanza_lt, istanza.lu AS istanza_lu, istanza.paridistanza, istanza.protanno AS istanza_protanno, istanza.protnumero AS istanza_protnumero,
 isnull('Tipologia: ' + [dbo].istanzakind.title + '; ','') + ' ' + isnull('Anno accademico: ' + istanza.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, istanza.data, 103),'') + ' ' + isnull('Iscrizione: ' + CAST( istanza.idiscrizione AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].istanza WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].istanzakind WITH (NOLOCK) ON istanza.idistanzakind = [dbo].istanzakind.idistanzakind
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON istanza.idstatuskind = [dbo].statuskind.idstatuskind
WHERE  istanza.idcorsostudio IS NOT NULL  AND istanza.iddidprog IS NOT NULL  AND istanza.idistanza IS NOT NULL  AND istanza.idistanzakind IS NOT NULL  AND istanza.idreg_studenti IS NOT NULL  AND istanza.paridistanza IS NOT NULL 
GO


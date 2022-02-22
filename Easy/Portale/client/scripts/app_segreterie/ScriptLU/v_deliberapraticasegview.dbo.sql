
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


-- CREAZIONE VISTA deliberapraticasegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[deliberapraticasegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[deliberapraticasegview]
GO

CREATE VIEW [dbo].[deliberapraticasegview] AS 
SELECT  deliberapratica.ct AS deliberapratica_ct, deliberapratica.cu AS deliberapratica_cu, deliberapratica.idcorsostudio, deliberapratica.iddelibera, deliberapratica.iddidprog, deliberapratica.idiscrizione, deliberapratica.idistanza, deliberapratica.idistanzakind,
 [dbo].pratica.ct AS pratica_ct, [dbo].pratica.cu AS pratica_cu, [dbo].pratica.idcorsostudio AS pratica_idcorsostudio, [dbo].pratica.iddichiar AS pratica_iddichiar, [dbo].pratica.iddidprog AS pratica_iddidprog, [dbo].pratica.idiscrizione AS pratica_idiscrizione, [dbo].pratica.idiscrizione_from AS pratica_idiscrizione_from, [dbo].pratica.idistanza AS pratica_idistanza, [dbo].pratica.idistanzakind AS pratica_idistanzakind, [dbo].pratica.idpratica AS pratica_idpratica, [dbo].pratica.idreg AS pratica_idreg, [dbo].pratica.idstatuskind AS pratica_idstatuskind, [dbo].pratica.idtitolostudio AS pratica_idtitolostudio, [dbo].pratica.lt AS pratica_lt, [dbo].pratica.lu AS pratica_lu, [dbo].pratica.protanno AS pratica_protanno, [dbo].pratica.protnumero AS pratica_protnumero, deliberapratica.idpratica, deliberapratica.idreg, deliberapratica.lt AS deliberapratica_lt, deliberapratica.lu AS deliberapratica_lu,
 isnull('Studente: ' + CAST( deliberapratica.idreg AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Studente: ' + CAST( [dbo].pratica.idreg AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata: ' + CAST( [dbo].pratica.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Istanza: ' + CAST( deliberapratica.idistanza AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( deliberapratica.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione: ' + CAST( deliberapratica.idiscrizione AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( deliberapratica.idistanzakind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( deliberapratica.idcorsostudio AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].deliberapratica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].pratica WITH (NOLOCK) ON deliberapratica.idpratica = [dbo].pratica.idpratica
WHERE  deliberapratica.idcorsostudio IS NOT NULL  AND deliberapratica.iddelibera IS NOT NULL  AND deliberapratica.iddidprog IS NOT NULL  AND deliberapratica.idiscrizione IS NOT NULL  AND deliberapratica.idistanza IS NOT NULL  AND deliberapratica.idistanzakind <> 9 AND deliberapratica.idistanzakind IS NOT NULL  AND deliberapratica.idpratica IS NOT NULL  AND deliberapratica.idreg IS NOT NULL 
GO


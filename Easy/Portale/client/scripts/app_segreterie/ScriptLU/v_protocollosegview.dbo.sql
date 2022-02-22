
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


-- CREAZIONE VISTA protocollosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[protocollosegview]
GO

CREATE VIEW [dbo].[protocollosegview] AS 
SELECT CASE WHEN protocollo.annullato = 'S' THEN 'Si' WHEN protocollo.annullato = 'N' THEN 'No' END AS protocollo_annullato, protocollo.codiceammipa AS protocollo_codiceammipa, protocollo.codiceregistro AS protocollo_codiceregistro, protocollo.ct AS protocollo_ct, protocollo.cu AS protocollo_cu, protocollo.dataannullamento AS protocollo_dataannullamento,
 [dbo].aoo.title AS aoo_title, protocollo.idaoo,
 registryorigine.title AS registryorigine_title, protocollo.idreg_origine, protocollo.lt AS protocollo_lt, protocollo.lu AS protocollo_lu, protocollo.oggetto AS protocollo_oggetto, protocollo.originecodiceaoo AS protocollo_originecodiceaoo, protocollo.origineidamm AS protocollo_origineidamm, protocollo.originemail AS protocollo_originemail, protocollo.protanno, protocollo.protdata AS protocollo_protdata, protocollo.protnumero, protocollo.testo AS protocollo_testo,
 isnull('Numero di protocollo: ' + CAST( protocollo.protnumero AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno di protocollo: ' + CAST( protocollo.protanno AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Codice Registro (univoco nell''Istituto): ' + protocollo.codiceregistro + '; ','') as dropdown_title
FROM [dbo].protocollo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].aoo WITH (NOLOCK) ON protocollo.idaoo = [dbo].aoo.idaoo
LEFT OUTER JOIN [dbo].registry AS registryorigine WITH (NOLOCK) ON protocollo.idreg_origine = registryorigine.idreg
WHERE  protocollo.protanno IS NOT NULL  AND protocollo.protnumero IS NOT NULL 
GO


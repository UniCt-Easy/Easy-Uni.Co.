
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


-- CREAZIONE VISTA getdocentiperssdsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[getdocentiperssdsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getdocentiperssdsegview]
GO

CREATE VIEW [getdocentiperssdsegview] AS 
SELECT  getdocentiperssd.aa, getdocentiperssd.cognome, getdocentiperssd.contratto AS getdocentiperssd_contratto, getdocentiperssd.costoorario AS getdocentiperssd_costoorario, getdocentiperssd.idreg,
 [dbo].sasd.codice AS sasd_codice, [dbo].sasd.title AS sasd_title, getdocentiperssd.idsasd, getdocentiperssd.iniziocontratto AS getdocentiperssd_iniziocontratto, getdocentiperssd.matricola AS getdocentiperssd_matricola, getdocentiperssd.nome AS getdocentiperssd_nome, getdocentiperssd.oremaxdida AS getdocentiperssd_oremaxdida, getdocentiperssd.oremindida AS getdocentiperssd_oremindida, getdocentiperssd.oreperaaaffidamento AS getdocentiperssd_oreperaaaffidamento, getdocentiperssd.oreperaacontratto AS getdocentiperssd_oreperaacontratto, getdocentiperssd.parttime AS getdocentiperssd_parttime, getdocentiperssd.ssd AS getdocentiperssd_ssd, getdocentiperssd.struttura AS getdocentiperssd_struttura,CASE WHEN getdocentiperssd.tempodefinito = 'S' THEN 'Si' WHEN getdocentiperssd.tempodefinito = 'N' THEN 'No' END AS getdocentiperssd_tempodefinito, getdocentiperssd.terminecontratto AS getdocentiperssd_terminecontratto,
 isnull('Cognome: ' + getdocentiperssd.cognome + '; ','') + ' ' + isnull('Nome: ' + getdocentiperssd.nome + '; ','') as dropdown_title
FROM getdocentiperssd WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].sasd WITH (NOLOCK) ON getdocentiperssd.idsasd = [dbo].sasd.idsasd
WHERE  getdocentiperssd.aa IS NOT NULL  AND getdocentiperssd.idreg IS NOT NULL 
GO


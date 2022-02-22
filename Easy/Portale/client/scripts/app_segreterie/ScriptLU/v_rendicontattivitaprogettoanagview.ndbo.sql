
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


-- CREAZIONE VISTA rendicontattivitaprogettoanagview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoanagview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoanagview]
GO

CREATE VIEW [rendicontattivitaprogettoanagview] AS 
SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration,
 progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto,
 workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, rendicontattivitaprogetto.stop AS rendicontattivitaprogetto_stop,
 isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title
FROM rendicontattivitaprogetto WITH (NOLOCK) 
LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto
LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage
WHERE  rendicontattivitaprogetto.idprogetto IS NOT NULL  AND rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO


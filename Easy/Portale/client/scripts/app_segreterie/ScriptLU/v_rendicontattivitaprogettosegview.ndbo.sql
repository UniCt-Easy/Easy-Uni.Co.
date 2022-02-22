
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


-- CREAZIONE VISTA rendicontattivitaprogettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettosegview]
GO

CREATE VIEW [rendicontattivitaprogettosegview] AS 
SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, rendicontattivitaprogetto.idprogetto,
 [dbo].registry.title AS registry_title, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, rendicontattivitaprogetto.idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, rendicontattivitaprogetto.stop AS rendicontattivitaprogetto_stop,
 isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title
FROM rendicontattivitaprogetto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON rendicontattivitaprogetto.idreg = [dbo].registry.idreg
WHERE  rendicontattivitaprogetto.idprogetto IS NOT NULL  AND rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL  AND rendicontattivitaprogetto.idworkpackage IS NOT NULL 
GO


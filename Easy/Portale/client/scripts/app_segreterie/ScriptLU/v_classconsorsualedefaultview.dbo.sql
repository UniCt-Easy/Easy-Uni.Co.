
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


-- CREAZIONE VISTA classconsorsualedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classconsorsualedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[classconsorsualedefaultview]
GO

CREATE VIEW [dbo].[classconsorsualedefaultview] AS 
SELECT CASE WHEN classconsorsuale.active = 'S' THEN 'Si' WHEN classconsorsuale.active = 'N' THEN 'No' END AS classconsorsuale_active, classconsorsuale.ambitodisci AS classconsorsuale_ambitodisci, classconsorsuale.corr2592017 AS classconsorsuale_corr2592017, classconsorsuale.description AS classconsorsuale_description, classconsorsuale.idclassconsorsuale, classconsorsuale.lt AS classconsorsuale_lt, classconsorsuale.lu AS classconsorsuale_lu, classconsorsuale.normativa AS classconsorsuale_normativa, classconsorsuale.title,
 isnull('Denominazione: ' + classconsorsuale.title + '; ','') as dropdown_title
FROM [dbo].classconsorsuale WITH (NOLOCK) 
WHERE  classconsorsuale.idclassconsorsuale IS NOT NULL 
GO


-- GENERAZIONE DATI PER classconsorsualedefaultview --

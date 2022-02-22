
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


-- CREAZIONE VISTA classescuoladefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuoladefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[classescuoladefaultview]
GO

CREATE VIEW [dbo].[classescuoladefaultview] AS 
SELECT  classescuola.idclassescuola,
 [dbo].classescuolaarea.title AS classescuolaarea_title, classescuola.idclassescuolaarea,
 [dbo].classescuolakind.title AS classescuolakind_title, classescuola.idclassescuolakind AS classescuola_idclassescuolakind,
 [dbo].corsostudionorma.title AS corsostudionorma_title, classescuola.idcorsostudionorma, classescuola.indicecineca AS classescuola_indicecineca, classescuola.lt AS classescuola_lt, classescuola.lu AS classescuola_lu, classescuola.obbform AS classescuola_obbform, classescuola.prospocc AS classescuola_prospocc, classescuola.sigla, classescuola.title AS classescuola_title,
 isnull('Sigla: ' + classescuola.sigla + '; ','') + ' ' + isnull('Denominazione: ' + classescuola.title + '; ','') as dropdown_title
FROM [dbo].classescuola WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].classescuolaarea WITH (NOLOCK) ON classescuola.idclassescuolaarea = [dbo].classescuolaarea.idclassescuolaarea
LEFT OUTER JOIN [dbo].classescuolakind WITH (NOLOCK) ON classescuola.idclassescuolakind = [dbo].classescuolakind.idclassescuolakind
LEFT OUTER JOIN [dbo].corsostudionorma WITH (NOLOCK) ON classescuola.idcorsostudionorma = [dbo].corsostudionorma.idcorsostudionorma
WHERE  classescuola.idclassescuola IS NOT NULL 
GO


-- GENERAZIONE DATI PER classescuoladefaultview --

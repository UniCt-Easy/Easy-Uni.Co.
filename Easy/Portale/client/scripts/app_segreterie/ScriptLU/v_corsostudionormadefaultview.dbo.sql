
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


-- CREAZIONE VISTA corsostudionormadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudionormadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudionormadefaultview]
GO

CREATE VIEW [dbo].[corsostudionormadefaultview] AS 
SELECT  corsostudionorma.idcorsostudionorma,
 [dbo].istitutokind.tipoistituto AS istitutokind_tipoistituto, corsostudionorma.idistitutokind AS corsostudionorma_idistitutokind, corsostudionorma.lt AS corsostudionorma_lt, corsostudionorma.lu AS corsostudionorma_lu, corsostudionorma.title,
 isnull('Denominazione: ' + corsostudionorma.title + '; ','') as dropdown_title
FROM [dbo].corsostudionorma WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].istitutokind WITH (NOLOCK) ON corsostudionorma.idistitutokind = [dbo].istitutokind.idistitutokind
WHERE  corsostudionorma.idcorsostudionorma IS NOT NULL 
GO


-- GENERAZIONE DATI PER corsostudionormadefaultview --

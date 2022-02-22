
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


-- CREAZIONE VISTA naturagiurdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[naturagiurdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[naturagiurdefaultview]
GO

CREATE VIEW [dbo].[naturagiurdefaultview] AS 
SELECT CASE WHEN naturagiur.active = 'S' THEN 'Si' WHEN naturagiur.active = 'N' THEN 'No' END AS naturagiur_active,CASE WHEN naturagiur.flagforeign = 'S' THEN 'Si' WHEN naturagiur.flagforeign = 'N' THEN 'No' END AS naturagiur_flagforeign, naturagiur.idnaturagiur, naturagiur.lt AS naturagiur_lt, naturagiur.lu AS naturagiur_lu, naturagiur.sortcode AS naturagiur_sortcode, naturagiur.title,
 isnull('Titolo: ' + naturagiur.title + '; ','') as dropdown_title
FROM [dbo].naturagiur WITH (NOLOCK) 
WHERE  naturagiur.idnaturagiur IS NOT NULL 
GO


-- GENERAZIONE DATI PER naturagiurdefaultview --

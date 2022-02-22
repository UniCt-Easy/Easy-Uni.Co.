
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


-- CREAZIONE VISTA perfrequestobbindividualedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfrequestobbindividualedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfrequestobbindividualedefaultview]
GO

CREATE VIEW [dbo].[perfrequestobbindividualedefaultview] AS 
SELECT  perfrequestobbindividuale.ct AS perfrequestobbindividuale_ct, perfrequestobbindividuale.cu AS perfrequestobbindividuale_cu, perfrequestobbindividuale.description AS perfrequestobbindividuale_description, perfrequestobbindividuale.idperfrequestobbindividuale,
 [dbo].registry.title AS registry_title, perfrequestobbindividuale.idreg,CASE WHEN perfrequestobbindividuale.inserito = 'S' THEN 'Si' WHEN perfrequestobbindividuale.inserito = 'N' THEN 'No' END AS perfrequestobbindividuale_inserito, perfrequestobbindividuale.lt AS perfrequestobbindividuale_lt, perfrequestobbindividuale.lu AS perfrequestobbindividuale_lu, perfrequestobbindividuale.peso AS perfrequestobbindividuale_peso, perfrequestobbindividuale.title,
 [dbo].year.year AS year_year, perfrequestobbindividuale.year AS perfrequestobbindividuale_year,
 isnull('Titolo obiettivo: ' + perfrequestobbindividuale.title + '; ','') as dropdown_title
FROM [dbo].perfrequestobbindividuale WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON perfrequestobbindividuale.idreg = [dbo].registry.idreg
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfrequestobbindividuale.year = [dbo].year.year
WHERE  perfrequestobbindividuale.idperfrequestobbindividuale IS NOT NULL  AND perfrequestobbindividuale.idreg IS NOT NULL 
GO


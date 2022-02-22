
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


-- CREAZIONE VISTA perfrequestobbunatantumdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfrequestobbunatantumdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfrequestobbunatantumdefaultview]
GO

CREATE VIEW [dbo].[perfrequestobbunatantumdefaultview] AS 
SELECT  perfrequestobbunatantum.ct AS perfrequestobbunatantum_ct, perfrequestobbunatantum.cu AS perfrequestobbunatantum_cu, perfrequestobbunatantum.description AS perfrequestobbunatantum_description, perfrequestobbunatantum.idperfrequestobbunatantum,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, perfrequestobbunatantum.idstruttura,CASE WHEN perfrequestobbunatantum.inserito = 'S' THEN 'Si' WHEN perfrequestobbunatantum.inserito = 'N' THEN 'No' END AS perfrequestobbunatantum_inserito, perfrequestobbunatantum.lt AS perfrequestobbunatantum_lt, perfrequestobbunatantum.lu AS perfrequestobbunatantum_lu, perfrequestobbunatantum.peso AS perfrequestobbunatantum_peso, perfrequestobbunatantum.title,
 [dbo].year.year AS year_year, perfrequestobbunatantum.year AS perfrequestobbunatantum_year,
 isnull('Titolo obiettivo: ' + perfrequestobbunatantum.title + '; ','') as dropdown_title
FROM [dbo].perfrequestobbunatantum WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON perfrequestobbunatantum.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfrequestobbunatantum.year = [dbo].year.year
WHERE  perfrequestobbunatantum.idperfrequestobbunatantum IS NOT NULL  AND perfrequestobbunatantum.idstruttura IS NOT NULL 
GO


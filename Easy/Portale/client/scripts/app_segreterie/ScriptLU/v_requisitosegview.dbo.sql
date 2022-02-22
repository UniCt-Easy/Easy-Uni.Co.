
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


-- CREAZIONE VISTA requisitosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[requisitosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[requisitosegview]
GO

CREATE VIEW [dbo].[requisitosegview] AS 
SELECT CASE WHEN requisito.active = 'S' THEN 'Si' WHEN requisito.active = 'N' THEN 'No' END AS requisito_active, requisito.ct AS requisito_ct, requisito.cu AS requisito_cu, requisito.idrequisito, requisito.lt AS requisito_lt, requisito.lu AS requisito_lu, requisito.sortcode AS requisito_sortcode, requisito.title,
 isnull('Titolo: ' + requisito.title + '; ','') as dropdown_title
FROM [dbo].requisito WITH (NOLOCK) 
WHERE  requisito.idrequisito IS NOT NULL 
GO


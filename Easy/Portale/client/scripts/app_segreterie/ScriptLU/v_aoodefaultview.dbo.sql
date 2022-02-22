
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


-- CREAZIONE VISTA aoodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[aoodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[aoodefaultview]
GO

CREATE VIEW [dbo].[aoodefaultview] AS 
SELECT  aoo.codiceaooipa AS aoo_codiceaooipa, aoo.ct AS aoo_ct, aoo.cu AS aoo_cu, aoo.idaoo, aoo.idreg AS aoo_idreg,
 [dbo].sede.title AS sede_title, aoo.idsede, aoo.lt AS aoo_lt, aoo.lu AS aoo_lu, aoo.title,
 isnull('Denominazione: ' + aoo.title + '; ','') as dropdown_title
FROM [dbo].aoo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON aoo.idsede = [dbo].sede.idsede
WHERE  aoo.idaoo IS NOT NULL 
GO


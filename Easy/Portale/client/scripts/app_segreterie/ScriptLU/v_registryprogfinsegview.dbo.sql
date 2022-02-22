
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


-- CREAZIONE VISTA registryprogfinsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryprogfinsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryprogfinsegview]
GO

CREATE VIEW [dbo].[registryprogfinsegview] AS 
SELECT  registryprogfin.code AS registryprogfin_code, registryprogfin.ct AS registryprogfin_ct, registryprogfin.cu AS registryprogfin_cu, registryprogfin.description AS registryprogfin_description, registryprogfin.idreg, registryprogfin.idregistryprogfin, registryprogfin.lt AS registryprogfin_lt, registryprogfin.lu AS registryprogfin_lu, registryprogfin.title,
 isnull('Titolo: ' + registryprogfin.title + '; ','') + ' ' + isnull('Codice identificativo: ' + registryprogfin.code + '; ','') as dropdown_title
FROM [dbo].registryprogfin WITH (NOLOCK) 
WHERE  registryprogfin.idreg IS NOT NULL  AND registryprogfin.idregistryprogfin IS NOT NULL 
GO


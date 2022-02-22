
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


-- CREAZIONE VISTA registryprogfinbandosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryprogfinbandosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryprogfinbandosegview]
GO

CREATE VIEW [dbo].[registryprogfinbandosegview] AS 
SELECT  registryprogfinbando.ct AS registryprogfinbando_ct, registryprogfinbando.cu AS registryprogfinbando_cu, registryprogfinbando.description AS registryprogfinbando_description, registryprogfinbando.idreg, registryprogfinbando.idregistryprogfin, registryprogfinbando.idregistryprogfinbando, registryprogfinbando.lt AS registryprogfinbando_lt, registryprogfinbando.lu AS registryprogfinbando_lu, registryprogfinbando.number AS registryprogfinbando_number, registryprogfinbando.scadenza AS registryprogfinbando_scadenza, registryprogfinbando.title,
 isnull('Titolo: ' + registryprogfinbando.title + '; ','') + ' ' + isnull('Numero: ' + registryprogfinbando.number + '; ','') + ' ' + isnull('Deadline of submission ' + CONVERT(VARCHAR, registryprogfinbando.scadenza, 103),'') as dropdown_title
FROM [dbo].registryprogfinbando WITH (NOLOCK) 
WHERE  registryprogfinbando.idreg IS NOT NULL  AND registryprogfinbando.idregistryprogfin IS NOT NULL  AND registryprogfinbando.idregistryprogfinbando IS NOT NULL 
GO


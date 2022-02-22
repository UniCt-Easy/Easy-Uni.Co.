
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


-- CREAZIONE VISTA accordoscambiomisegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accordoscambiomisegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accordoscambiomisegview]
GO

CREATE VIEW [dbo].[accordoscambiomisegview] AS 
SELECT  accordoscambiomi.aa_start, accordoscambiomi.aa_stop, accordoscambiomi.ct AS accordoscambiomi_ct, accordoscambiomi.cu AS accordoscambiomi_cu, accordoscambiomi.description AS accordoscambiomi_description, accordoscambiomi.idaccordoscambiomi,
 [dbo].programmami.acronimo AS programmami_acronimo, accordoscambiomi.idprogrammami, accordoscambiomi.lt AS accordoscambiomi_lt, accordoscambiomi.lu AS accordoscambiomi_lu, accordoscambiomi.title,
 isnull('Titolo: ' + accordoscambiomi.title + '; ','') as dropdown_title
FROM [dbo].accordoscambiomi WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].programmami WITH (NOLOCK) ON accordoscambiomi.idprogrammami = [dbo].programmami.idprogrammami
WHERE  accordoscambiomi.idaccordoscambiomi IS NOT NULL 
GO


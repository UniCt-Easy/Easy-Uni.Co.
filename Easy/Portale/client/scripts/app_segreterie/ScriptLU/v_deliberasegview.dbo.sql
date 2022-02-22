
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


-- CREAZIONE VISTA deliberasegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[deliberasegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[deliberasegview]
GO

CREATE VIEW [dbo].[deliberasegview] AS 
SELECT  delibera.ct AS delibera_ct, delibera.cu AS delibera_cu, delibera.data AS delibera_data, delibera.iddelibera,
 [dbo].statuskind.title AS statuskind_title, delibera.idstatuskind AS delibera_idstatuskind,
 [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, [dbo].struttura.idstrutturakind AS struttura_idstrutturakind, delibera.idstruttura, delibera.lt AS delibera_lt, delibera.lu AS delibera_lu, delibera.oggetto, delibera.protanno AS delibera_protanno, delibera.protnumero AS delibera_protnumero, delibera.testo AS delibera_testo
FROM [dbo].delibera WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].statuskind WITH (NOLOCK) ON delibera.idstatuskind = [dbo].statuskind.idstatuskind
LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON delibera.idstruttura = [dbo].struttura.idstruttura
LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON [dbo].struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind
WHERE  delibera.iddelibera IS NOT NULL 
GO


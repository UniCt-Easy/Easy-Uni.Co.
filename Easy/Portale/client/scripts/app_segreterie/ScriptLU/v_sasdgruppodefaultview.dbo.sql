
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


-- CREAZIONE VISTA sasdgruppodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sasdgruppodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[sasdgruppodefaultview]
GO

CREATE VIEW [dbo].[sasdgruppodefaultview] AS 
SELECT  sasdgruppo.ct AS sasdgruppo_ct, sasdgruppo.cu AS sasdgruppo_cu, sasdgruppo.idsasdgruppo,
 [dbo].tipoattform.title AS tipoattform_title, [dbo].tipoattform.description AS tipoattform_description, sasdgruppo.idtipoattform, sasdgruppo.lt AS sasdgruppo_lt, sasdgruppo.lu AS sasdgruppo_lu, sasdgruppo.title,
 isnull('Gruppo: ' + sasdgruppo.title + '; ','') as dropdown_title
FROM [dbo].sasdgruppo WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].tipoattform WITH (NOLOCK) ON sasdgruppo.idtipoattform = [dbo].tipoattform.idtipoattform
WHERE  sasdgruppo.idsasdgruppo IS NOT NULL  AND sasdgruppo.idtipoattform IS NOT NULL 
GO


-- GENERAZIONE DATI PER sasdgruppodefaultview --

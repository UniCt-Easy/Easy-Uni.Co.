
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


-- CREAZIONE VISTA iscrizioneseganagstuview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizioneseganagstuview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizioneseganagstuview]
GO

CREATE VIEW [dbo].[iscrizioneseganagstuview] AS 
SELECT  iscrizione.aa, iscrizione.anno AS iscrizione_anno, iscrizione.ct AS iscrizione_ct, iscrizione.cu AS iscrizione_cu, iscrizione.data AS iscrizione_data, iscrizione.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].sede.idsede AS sede_idsede, iscrizione.iddidprog, iscrizione.idiscrizione, iscrizione.idreg, iscrizione.lt AS iscrizione_lt, iscrizione.lu AS iscrizione_lu, iscrizione.matricola AS iscrizione_matricola,
 isnull('Didattica programmata: ' + [dbo].didprog.title + '; ','') + ' ' + isnull('Didattica programmata: ' + [dbo].didprog.aa + '; ','') + ' ' + isnull('Anno accademico: ' + iscrizione.aa + '; ','') + ' ' + isnull('Denominazione Sede: ' + [dbo].sede.title + '; ','') + ' ' + isnull('Sede Sede: ' + CAST( [dbo].sede.idsede AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].iscrizione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON iscrizione.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON didprog.idsede = [dbo].sede.idsede
WHERE  iscrizione.idcorsostudio  in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind not in (12, 13, 2)  /*Corsi di studio*/) AND iscrizione.idcorsostudio IS NOT NULL  AND iscrizione.iddidprog IS NOT NULL  AND iscrizione.idiscrizione IS NOT NULL  AND iscrizione.idreg IS NOT NULL 
GO


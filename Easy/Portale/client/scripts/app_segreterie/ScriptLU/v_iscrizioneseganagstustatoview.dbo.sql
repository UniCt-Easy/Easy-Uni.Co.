
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


-- CREAZIONE VISTA iscrizioneseganagstustatoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[iscrizioneseganagstustatoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[iscrizioneseganagstustatoview]
GO

CREATE VIEW [dbo].[iscrizioneseganagstustatoview] AS 
SELECT  iscrizione.aa, iscrizione.anno AS iscrizione_anno, iscrizione.ct AS iscrizione_ct, iscrizione.cu AS iscrizione_cu, iscrizione.data AS iscrizione_data, iscrizione.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, iscrizione.iddidprog, iscrizione.idiscrizione, iscrizione.idreg, iscrizione.lt AS iscrizione_lt, iscrizione.lu AS iscrizione_lu, iscrizione.matricola AS iscrizione_matricola,
 isnull('Esame di stato: ' + [dbo].didprog.title + '; ','') + ' ' + isnull('Esame di stato: ' + [dbo].didprog.aa + '; ','') + ' ' + isnull('Anno accademico: ' + iscrizione.aa + '; ','') as dropdown_title
FROM [dbo].iscrizione WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON iscrizione.iddidprog = [dbo].didprog.iddidprog
WHERE  iscrizione.idcorsostudio  in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13 /*esami di stato*/) AND iscrizione.idcorsostudio IS NOT NULL  AND iscrizione.iddidprog IS NOT NULL  AND iscrizione.idiscrizione IS NOT NULL  AND iscrizione.idreg IS NOT NULL 
GO


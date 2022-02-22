
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


-- CREAZIONE VISTA perfruolodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfruolodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfruolodefaultview]
GO

CREATE VIEW [dbo].[perfruolodefaultview] AS 
SELECT  perfruolo.idperfruolo,CASE WHEN perfruolo.oper = 'C' THEN 'Solo nodo corrente' WHEN perfruolo.oper = 'S' THEN 'Solo nodi sottostanti' WHEN perfruolo.oper = 'A' THEN 'Nodo corrente e sottostanti' END AS perfruolo_oper, perfruolo.ct AS perfruolo_ct, perfruolo.cu AS perfruolo_cu, perfruolo.lt AS perfruolo_lt, perfruolo.lu AS perfruolo_lu,CASE WHEN perfruolo.aggiorna = 'S' THEN 'Si' WHEN perfruolo.aggiorna = 'N' THEN 'No' END AS perfruolo_aggiorna,CASE WHEN perfruolo.crea = 'S' THEN 'Si' WHEN perfruolo.crea = 'N' THEN 'No' END AS perfruolo_crea,CASE WHEN perfruolo.leggi = 'S' THEN 'Si' WHEN perfruolo.leggi = 'N' THEN 'No' END AS perfruolo_leggi,CASE WHEN perfruolo.valuta = 'S' THEN 'Si' WHEN perfruolo.valuta = 'N' THEN 'No' END AS perfruolo_valuta,
 isnull('Ruolo: ' + perfruolo.idperfruolo + '; ','') as dropdown_title
FROM [dbo].perfruolo WITH (NOLOCK) 
WHERE  perfruolo.idperfruolo IS NOT NULL 
GO


-- GENERAZIONE DATI PER perfruolodefaultview --

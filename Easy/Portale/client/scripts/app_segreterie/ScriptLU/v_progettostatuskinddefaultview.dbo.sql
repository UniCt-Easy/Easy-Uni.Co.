
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


-- CREAZIONE VISTA progettostatuskinddefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettostatuskinddefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettostatuskinddefaultview]
GO

CREATE VIEW [dbo].[progettostatuskinddefaultview] AS 
SELECT  progettostatuskind.idprogettostatuskind, progettostatuskind.title, progettostatuskind.sortcode AS progettostatuskind_sortcode, progettostatuskind.ct AS progettostatuskind_ct, progettostatuskind.cu AS progettostatuskind_cu, progettostatuskind.lt AS progettostatuskind_lt, progettostatuskind.lu AS progettostatuskind_lu,CASE WHEN progettostatuskind.contributo = 'S' THEN 'Si' WHEN progettostatuskind.contributo = 'N' THEN 'No' END AS progettostatuskind_contributo,CASE WHEN progettostatuskind.contributoente = 'S' THEN 'Si' WHEN progettostatuskind.contributoente = 'N' THEN 'No' END AS progettostatuskind_contributoente,CASE WHEN progettostatuskind.contributoenterichiesto = 'S' THEN 'Si' WHEN progettostatuskind.contributoenterichiesto = 'N' THEN 'No' END AS progettostatuskind_contributoenterichiesto,CASE WHEN progettostatuskind.contributorichiesto = 'S' THEN 'Si' WHEN progettostatuskind.contributorichiesto = 'N' THEN 'No' END AS progettostatuskind_contributorichiesto,
 isnull('Stato: ' + progettostatuskind.title + '; ','') as dropdown_title
FROM [dbo].progettostatuskind WITH (NOLOCK) 
WHERE  progettostatuskind.idprogettostatuskind IS NOT NULL 
GO


-- GENERAZIONE DATI PER progettostatuskinddefaultview --

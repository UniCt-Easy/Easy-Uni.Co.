
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


-- CREAZIONE VISTA progettokindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettokindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettokindsegview]
GO

CREATE VIEW [dbo].[progettokindsegview] AS 
SELECT  progettokind.ct AS progettokind_ct, progettokind.cu AS progettokind_cu, progettokind.description AS progettokind_description,CASE WHEN progettokind.idcorsostudio = 'S' THEN 'Si' WHEN progettokind.idcorsostudio = 'N' THEN 'No' END AS progettokind_idcorsostudio,
 [dbo].progettoactivitykind.title AS progettoactivitykind_title, progettokind.idprogettoactivitykind AS progettokind_idprogettoactivitykind, progettokind.idprogettokind, progettokind.lt AS progettokind_lt, progettokind.lu AS progettokind_lu, progettokind.oredivisionecostostipendio AS progettokind_oredivisionecostostipendio,CASE WHEN progettokind.stipendioannoprec = 'S' THEN 'Si' WHEN progettokind.stipendioannoprec = 'N' THEN 'No' END AS progettokind_stipendioannoprec,CASE WHEN progettokind.stipendiocomericavo = 'S' THEN 'Si' WHEN progettokind.stipendiocomericavo = 'N' THEN 'No' END AS progettokind_stipendiocomericavo, progettokind.title,
 isnull('Titolo: ' + progettokind.title + '; ','') as dropdown_title
FROM [dbo].progettokind WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].progettoactivitykind WITH (NOLOCK) ON progettokind.idprogettoactivitykind = [dbo].progettoactivitykind.idprogettoactivitykind
WHERE  progettokind.idprogettokind IS NOT NULL 
GO


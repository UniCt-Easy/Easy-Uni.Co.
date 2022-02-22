
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


-- CREAZIONE VISTA relatoredefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[relatoredefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[relatoredefaultview]
GO

CREATE VIEW [dbo].[relatoredefaultview] AS 
SELECT  relatore.ct AS relatore_ct, relatore.cu AS relatore_cu, relatore.idistanza, relatore.idreg,
 registry_registry_docentidocenti.title AS registrydocenti_title, relatore.idreg_docenti, relatore.idrelatore,
 [dbo].relatorekind.title AS relatorekind_title, relatore.idrelatorekind AS relatore_idrelatorekind, relatore.idrichitesi, relatore.lt AS relatore_lt, relatore.lu AS relatore_lu,
 isnull('Docente: ' + registry_registry_docentidocenti.title + '; ','') + ' ' + isnull('Tipologia: ' + [dbo].relatorekind.title + '; ','') as dropdown_title
FROM [dbo].relatore WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON relatore.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registry_registry_docentidocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registry_registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].relatorekind WITH (NOLOCK) ON relatore.idrelatorekind = [dbo].relatorekind.idrelatorekind
WHERE  relatore.idistanza IS NOT NULL  AND relatore.idreg IS NOT NULL  AND relatore.idrelatore IS NOT NULL  AND relatore.idrichitesi IS NOT NULL 
GO


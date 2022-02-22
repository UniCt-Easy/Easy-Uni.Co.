
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


-- CREAZIONE VISTA accmotivedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotivedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotivedefaultview]
GO



CREATE VIEW [dbo].[accmotivedefaultview] AS SELECT CASE WHEN accmotive.active = 'S' THEN 'Si' WHEN accmotive.active = 'N' THEN 'No' END AS accmotive_active, accmotive.codemotive, accmotive.ct AS accmotive_ct, accmotive.cu AS accmotive_cu, accmotive.expensekind AS accmotive_expensekind, accmotive.flag AS accmotive_flag,CASE WHEN accmotive.flagamm = 'S' THEN 'Si' WHEN accmotive.flagamm = 'N' THEN 'No' END AS accmotive_flagamm,CASE WHEN accmotive.flagdep = 'S' THEN 'Si' WHEN accmotive.flagdep = 'N' THEN 'No' END AS accmotive_flagdep, accmotive.idaccmotive, accmotive.lt AS accmotive_lt, accmotive.lu AS accmotive_lu, accmotiveparent.codemotive AS accmotiveparent_codemotive, accmotiveparent.title AS accmotiveparent_title, accmotive.paridaccmotive, accmotive.title AS accmotive_title, isnull('Codice: ' + accmotive.codemotive + '; ','') + ' ' + isnull('Denominazione: ' + accmotive.title + '; ','') as dropdown_title FROM [dbo].accmotive WITH (NOLOCK)  LEFT OUTER JOIN [dbo].accmotive AS accmotiveparent WITH (NOLOCK) ON accmotive.paridaccmotive = accmotiveparent.idaccmotive WHERE  accmotive.idaccmotive IS NOT NULL 

GO


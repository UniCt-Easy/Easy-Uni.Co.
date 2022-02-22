
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


-- CREAZIONE VISTA questionariodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[questionariodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[questionariodefaultview]
GO

CREATE VIEW [dbo].[questionariodefaultview] AS 
SELECT CASE WHEN questionario.anonimo = 'S' THEN 'Si' WHEN questionario.anonimo = 'N' THEN 'No' END AS questionario_anonimo, questionario.ct AS questionario_ct, questionario.cu AS questionario_cu, questionario.description AS questionario_description, questionario.idquestionario,
 [dbo].questionariokind.title AS questionariokind_title, questionario.idquestionariokind AS questionario_idquestionariokind, questionario.lt AS questionario_lt, questionario.lu AS questionario_lu, questionario.title,
 isnull('Titolo: ' + questionario.title + '; ','') as dropdown_title
FROM [dbo].questionario WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].questionariokind WITH (NOLOCK) ON questionario.idquestionariokind = [dbo].questionariokind.idquestionariokind
WHERE  questionario.idquestionario IS NOT NULL 
GO


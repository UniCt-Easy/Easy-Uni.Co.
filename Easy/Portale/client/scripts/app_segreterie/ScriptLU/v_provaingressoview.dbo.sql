
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


-- CREAZIONE VISTA provaingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[provaingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[provaingressoview]
GO

CREATE VIEW [dbo].[provaingressoview] AS 
SELECT  prova.ct AS prova_ct, prova.cu AS prova_cu, prova.idappello AS prova_idappello, prova.idattivform AS prova_idattivform, prova.idcorsostudio, prova.iddidprog, prova.idprova,
 [dbo].questionario.title AS questionario_title, prova.idquestionario,
 [dbo].valutazionekind.title AS valutazionekind_title, prova.idvalutazionekind AS prova_idvalutazionekind, prova.lt AS prova_lt, prova.lu AS prova_lu, prova.programma AS prova_programma, prova.start AS prova_start, prova.stop AS prova_stop, prova.title,(select top 1 idreg_docenti 
						from dbo.commiss 
						where dbo.commiss.idprova = prova.idprova
						 order by commiss.idcommiss asc ) as idreg_docenti,
 isnull('Denominazione: ' + prova.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, prova.start, 103),'') as dropdown_title
FROM [dbo].prova WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].questionario WITH (NOLOCK) ON prova.idquestionario = [dbo].questionario.idquestionario
LEFT OUTER JOIN [dbo].valutazionekind WITH (NOLOCK) ON prova.idvalutazionekind = [dbo].valutazionekind.idvalutazionekind
WHERE  prova.idcorsostudio IS NOT NULL  AND prova.iddidprog IS NOT NULL  AND prova.idprova IS NOT NULL 
GO


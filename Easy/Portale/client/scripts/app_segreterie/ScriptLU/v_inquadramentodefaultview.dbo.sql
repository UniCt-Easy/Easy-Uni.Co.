
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


-- CREAZIONE VISTA inquadramentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[inquadramentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[inquadramentodefaultview]
GO

CREATE VIEW [dbo].[inquadramentodefaultview] AS 
SELECT  inquadramento.costolordoannuo AS inquadramento_costolordoannuo, inquadramento.costolordoannuooneri AS inquadramento_costolordoannuooneri, inquadramento.ct AS inquadramento_ct, inquadramento.cu AS inquadramento_cu, inquadramento.idcontrattokind, inquadramento.idinquadramento, inquadramento.lt AS inquadramento_lt, inquadramento.lu AS inquadramento_lu, inquadramento.siglaimportazione AS inquadramento_siglaimportazione, inquadramento.start AS inquadramento_start, inquadramento.stop AS inquadramento_stop,CASE WHEN inquadramento.tempdef = 'S' THEN 'Si' WHEN inquadramento.tempdef = 'N' THEN 'No' END AS inquadramento_tempdef, inquadramento.title,
 isnull('Denominazione: ' + inquadramento.title + '; ','') + ' ' + isnull('' + CASE WHEN inquadramento.tempdef = 'S' THEN 'Tempo definito' ELSE 'non Tempo definito' END,'') as dropdown_title
FROM [dbo].inquadramento WITH (NOLOCK) 
WHERE  inquadramento.idcontrattokind IS NOT NULL  AND inquadramento.idinquadramento IS NOT NULL 
GO


-- GENERAZIONE DATI PER inquadramentodefaultview --

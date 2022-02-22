
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


-- CREAZIONE VISTA contrattodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[contrattodefaultview]
GO

CREATE VIEW [dbo].[contrattodefaultview] AS 
SELECT  contratto.classe AS contratto_classe, contratto.ct AS contratto_ct, contratto.cu AS contratto_cu, contratto.datarivalutazione AS contratto_datarivalutazione, contratto.estremibando AS contratto_estremibando, contratto.idcontratto,
 [dbo].contrattokind.title AS contrattokind_title, contratto.idcontrattokind,
 [dbo].inquadramento.idcontrattokind AS inquadramento_idcontrattokind, [dbo].inquadramento.title AS inquadramento_title, [dbo].inquadramento.tempdef AS inquadramento_tempdef, contratto.idinquadramento AS contratto_idinquadramento, contratto.idreg, contratto.lt AS contratto_lt, contratto.lu AS contratto_lu, contratto.parttime AS contratto_parttime, contratto.percentualesufondiateneo AS contratto_percentualesufondiateneo, contratto.scatto AS contratto_scatto, contratto.start AS contratto_start, contratto.stop AS contratto_stop,CASE WHEN contratto.tempdef = 'S' THEN 'Si' WHEN contratto.tempdef = 'N' THEN 'No' END AS contratto_tempdef,CASE WHEN contratto.tempindet = 'S' THEN 'Si' WHEN contratto.tempindet = 'N' THEN 'No' END AS contratto_tempindet,
 isnull('Tipologia di contratto: ' + [dbo].contrattokind.title + '; ','') + ' ' + isnull('dal ' + CONVERT(VARCHAR, contratto.start, 103),'') + ' ' + isnull((Select top 1 'Denominazione: ' +title + '; ' + 'Identificativo: ' +CAST( idcontrattokind AS NVARCHAR(64)) + '; ' + 'Tempo definito: ' +tempdef from inquadramento x where x.idinquadramento = contratto.idinquadramento) + '; ','') + ' ' + isnull('Inquadramento: ' + [dbo].inquadramento.title + '; ','') + ' ' + isnull('Inquadramento: ' + [dbo].inquadramento.tempdef + '; ','') + ' ' + isnull('al ' + CONVERT(VARCHAR, contratto.stop, 103),'') as dropdown_title
FROM [dbo].contratto WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON contratto.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].inquadramento WITH (NOLOCK) ON contratto.idinquadramento = [dbo].inquadramento.idinquadramento
WHERE  contratto.idcontratto IS NOT NULL  AND contratto.idreg IS NOT NULL 
GO


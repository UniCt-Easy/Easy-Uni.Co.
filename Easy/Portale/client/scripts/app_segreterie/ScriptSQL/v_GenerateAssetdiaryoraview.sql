
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


/****** Object:  View [dbo].[assetsegview]    Script Date: 23/06/2020 16:23:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetdiaryoraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[assetdiaryoraview]
GO

CREATE VIEW [dbo].[assetdiaryoraview] AS 
SELECT  assetdiary.idreg, assetdiary.idasset, assetdiary.idpiece, assetdiary.idassetdiary,assetdiaryora.start, assetdiaryora.stop, 
'<b>Progetto:</b> ' + isnull(dbo.progetto.titolobreve,'') + 
'; <b>Workpackage:</b> ' + isnull(dbo.workpackage.title,'') + 
'; <b>Operatore:</b> ' + isnull(dbo.registrydefaultview.dropdown_title,'') + 
'; <b>Bene:</b> ' + isnull('' + CAST( amministrazione.inventory.description AS NVARCHAR(64)) + ' Inventario' ,'') + ' ' + isnull('' + CAST( asset.idasset AS NVARCHAR(64)) + ' Identificativo' ,'') + ' ' + 
isnull('' + CAST( asset.idpiece AS NVARCHAR(64)) + ' Numero parte' ,'') + ' ' + isnull('' + CAST( amministrazione.assetacquire.description AS NVARCHAR(64)) + ' Descrizione' ,'') + ' ' + 
isnull('' + CAST( asset.ninventory AS NVARCHAR(64)) + ' Numero inventario' ,'') + ' ' + isnull('' + asset.rfid,'')
as title
FROM  assetdiaryora WITH (NOLOCK) 
LEFT OUTER JOIN assetdiary WITH (NOLOCK) ON assetdiary.idassetdiary = assetdiaryora.idassetdiary
LEFT OUTER JOIN amministrazione.asset WITH (NOLOCK) ON amministrazione.asset.idasset = assetdiary.idasset and asset.idpiece = assetdiary.idpiece
LEFT OUTER JOIN amministrazione.inventory WITH (NOLOCK) ON asset.idinventory = amministrazione.inventory.idinventory 
LEFT OUTER JOIN amministrazione.assetacquire WITH (NOLOCK) ON asset.nassetacquire = amministrazione.assetacquire.nassetacquire 
LEFT OUTER JOIN dbo.progetto WITH (NOLOCK) ON dbo.progetto.idprogetto = dbo.assetdiary.idprogetto 
LEFT OUTER JOIN dbo.workpackage WITH (NOLOCK) ON dbo.workpackage.idworkpackage = dbo.assetdiary.idworkpackage
LEFT OUTER JOIN dbo.registrydefaultview WITH (NOLOCK) ON dbo.registrydefaultview.idreg = dbo.assetdiary.idreg
WHERE  asset.idasset IS NOT NULL  AND asset.idpiece IS NOT NULL 
GO



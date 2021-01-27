
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_cespiti_note]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_cespiti_note]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE                PROCEDURE [esporta_cespiti_note]
@idinventory	int,
@fromninv		int,
@toninv			int
AS BEGIN
SELECT 
	asset.idasset AS 'Idasset',
	lifestart AS 'Data Creazione', 
	asset.cu AS 'Creato da' , 
	inventory.description as 'Inventario',
	ninventory AS 'Num. inventario',
	asset.nassetacquire AS 'Carico Bene', 
	assetloadkind.codeassetloadkind as 'Tipo Buono Carico',
	assetload.yassetload as 'Eserc. Buono Carico',
	assetload.nassetload as 'Num. Buono Carico',
	assetunloadkind.codeassetunloadkind as 'Tipo Buono Scarico',
	assetunload.yassetunload as 'Eserc. Buono Scarico',
	assetunload.nassetunload as 'Num. Buono Scarico',
	asset.txt as 'Annotazioni'
FROM asset  
join assetacquire on assetacquire.nassetacquire = asset.nassetacquire
join inventory on assetacquire.idinventory = inventory.idinventory
left outer join manager R ON R.idman = (select top 1 idman from assetmanager where idasset=asset.idasset and start is null)
LEFT OUTER JOIN location U ON U.idlocation = (select top 1 idlocation from assetlocation where idasset = asset.idasset and start is null)
left outer join assetload on assetload.idassetload = assetacquire.idassetload
left outer join assetloadkind on assetloadkind.idassetloadkind = assetload.idassetloadkind
left outer join assetunload on assetunload.idassetunload = asset.idassetunload
left outer join assetunloadkind on assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
WHERE idpiece = 1 
AND (assetacquire.idinventory = @idinventory or @idinventory is null)
AND (asset.ninventory >= @fromninv OR @fromninv is null)
AND (asset.ninventory <= @toninv OR @toninv is null)
ORDER BY idasset
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



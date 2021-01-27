
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_cespiti_non_caricati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_cespiti_non_caricati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	exec esporta_cespiti_non_caricati

CREATE         PROCEDURE [esporta_cespiti_non_caricati]

AS BEGIN

DECLARE @temp TABLE
(
    idasset int
 )

insert into @temp(idasset)
select idasset 
from asset 
where asset.idpiece = 1 
and (asset.nassetacquire is NULL OR 
	(select count(*) from assetacquire where assetacquire.nassetacquire= asset.nassetacquire)=0
)

SELECT 
	A.idasset AS 'Idasset',
	lifestart AS 'Data Creazione', 
	A.cu AS 'Creato da' , 
	ninventory AS 'Num. inventario',
	R.title AS 'Responsabile',
	U.locationcode  AS 'Cod. Ubicazione',
	U.description  AS 'Ubicazione',
	nassetacquire AS 'Carico Bene', 
	assetunloadkind.codeassetunloadkind as 'Tipo Buono Scarico',
	assetunload.yassetunload as 'Eserc. Buono Scarico',
	assetunload.nassetunload as 'Num. Buono Scarico'
FROM asset  A
join @temp T
	on A.idasset = T.idasset
left outer join assetmanager AM
	on AM.idasset = A.idasset and AM.start is null
left outer join manager R 
	ON R.idman = AM.idman
left outer join assetlocation AL
	on AL.idasset = A.idasset and AL.start is null
LEFT OUTER JOIN location U 
	ON U.idlocation = AL.idlocation 
left outer join assetunload 
	on assetunload.idassetunload = A.idassetunload
left outer join assetunloadkind 
	on assetunloadkind.idassetunloadkind = assetunload.idassetunloadkind
ORDER BY A.idasset
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



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


if exists (select * from dbo.sysobjects where id = object_id(N'[asset_amortized]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [asset_amortized]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE asset_amortized
(
	@ayear int
)
AS 
BEGIN

create table #asset (
idasset int,
idpiece int,
cost decimal(19,2),
last decimal(19,2),
unload decimal(19,2),
codeinv varchar(50),
inventorytree varchar(150),
yassetunload int,
flagunload char
)
insert into #asset (idasset,idpiece,cost,last,codeinv,inventorytree,yassetunload,flagunload)
SELECT idasset AS 'Num. Bene',
idpiece AS 'Num. Parte',
cost AS 'Costo',
cost +
CONVERT(decimal(19,2),
ISNULL(
	(SELECT SUM(ROUND(ISNULL(AM.assetvalue,0) * 
	                  ISNULL(AM.amortizationquota,0),2))
	FROM assetamortization AM
	JOIN inventoryamortization IA
	ON AM.idinventoryamortization = IA.idinventoryamortization
	WHERE A.idasset = AM.idasset
	AND A.idpiece = AM.idpiece
	AND IA.flag&2 <> 0
	--
	AND ((ISNULL(AM.amortizationquota,0)>0) OR 
            (
	     (ISNULL(AM.amortizationquota,0)<0) AND 
             ((AM.flag&1=0) OR 
	      (AM.idassetunload is not null))
	     )
	    )
	--
	AND YEAR(AM.adate) <= @ayear)
,0)) AS 'Valore al netto degli ammortamenti',
codeinv, inventorytree,
yassetunload,flagunload
FROM assetview A
WHERE yassetload <= @ayear

--select * from #asset

update #asset set last=last -
 ISNULL((SELECT SUM(cost) 
	from assetview A 
	join assetacquire ACQ
	on A.nassetacquire = ACQ.nassetacquire 
	where
	A.idasset=#asset.idasset and
	(A.yassetunload is not null or
	ISNULL(A.flagunload,'S')='N') and
	ACQ.idassetload is null and
	ACQ.flag&1 = 0 and
	A.idpiece > 1 		
),0)
WHERE #asset.idpiece=1

--select * from #asset
		
update #asset set unload = last
where  (yassetunload is not null or
	ISNULL(flagunload,'S')='N') 

select 
idasset AS 'Num. Bene',
idpiece AS 'Num. Parte',
cost AS 'Costo',
last AS 'Valore attuale',
unload AS 'Valore scaricato',
codeinv AS 'Codice class.',
inventorytree AS 'Classificazione'
from #asset

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

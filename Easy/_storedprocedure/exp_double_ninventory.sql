
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_double_ninventory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_double_ninventory]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [exp_double_ninventory]
	@idinventory int
AS BEGIN
		 
SELECT 
	A.idasset as 'Id Cespite',
	A.nassetacquire as 'Numero Carico Cespite',
	AA.adate as 'Data acquisizione carico',
	AA.description as 'Descrizione',
	AA.idinventory as 'Codice Inventario', 
	A.ninventory as 'Numero inventario',
	AA.startnumber as 'Numero iniziale',
	AA.number as 'Quantità',
	assetloadkind.codeassetloadkind as 'Codice Buono Carico', 
	assetload.yassetload as 'Eserc. Buono Carico',  
	assetload.nassetload as 'Num. Buono Carico',  
	A.cu as 'Creato da'
FROM asset A
JOIN assetacquire AA 
	on AA.nassetacquire= A.nassetacquire
left outer join assetload
	on assetload.idassetload = AA.idassetload
left outer join assetloadkind
	on assetloadkind.idassetloadkind = assetload.idassetloadkind
JOIN inventory i 
		ON i.idinventory = AA.idinventory
WHERE A.idpiece = 1 AND
	exists (select * from asset B 
	 join assetacquire BB on BB.nassetacquire= B.nassetacquire
	 where  B.idpiece = 1 AND
		B.ninventory= A.ninventory and
		BB.idinventory= AA.idinventory and
		A.idasset <> B.idasset
	 )
	AND  AA.idinventory = @idinventory
ORDER BY
	AA.idinventory,assetload.yassetload, AA.startnumber, AA.nassetacquire	
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

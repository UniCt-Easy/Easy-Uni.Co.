
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_jump_ninventory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_jump_ninventory]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [exp_jump_ninventory]
	@idinventory int 
AS BEGIN
		 
	SELECT  		
		a.idasset as 'Id Cespite',
		a.nassetacquire as 'Numero Carico Cespite',
		b.adate	as 'Data acquisizione carico',
		b.description as 'Descrizione',
		ti.codeinventory as 'Codice Inventario', 
		ti.description as 'Tipo Inventario',
		a.ninventory as 'Numero inventario',
		b.startnumber as 'Numero iniziale',
		b.number as 'Quantità',
		tb.codeassetloadkind as 'Codice Buono Carico', 
		tb.description as 'Tipo Buono Carico',   
		assetload.yassetload as 'Eserc. Buono Carico',  
		assetload.nassetload as 'Num. Buono Carico',  
		a.cu as 'Creato da'		
	FROM  asset a 
	JOIN  assetacquire b 
		ON a.nassetacquire=b.nassetacquire
	left outer join assetload
		on assetload.idassetload = b.idassetload
	LEFT  OUTER JOIN inventory ti 
		ON ti.idinventory = b.idinventory
	LEFT  OUTER JOIN assetloadkind tb 
		ON tb.idassetloadkind = assetload.idassetloadkind
	WHERE a.idpiece= 1 and
		NOT EXISTS 
		(SELECT * FROM asset c 
		 JOIN  assetacquire d ON  c.nassetacquire=d.nassetacquire 
		 WHERE c.idpiece = 1 AND d.idinventory = b.idinventory
			AND c.ninventory = a.ninventory+1)
	AND   a.ninventory <
		( SELECT MAX(f.startnumber+isnull(f.number,1)-1) FROM assetacquire f 
		  WHERE f.idinventory=b.idinventory ) 
	AND   b.idinventory = @idinventory
	ORDER BY
	b.idinventory,assetload.yassetload, b.startnumber, b.nassetacquire	
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

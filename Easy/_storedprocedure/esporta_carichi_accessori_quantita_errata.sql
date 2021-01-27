
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_carichi_accessori_quantita_errata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_carichi_accessori_quantita_errata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [esporta_carichi_accessori_quantita_errata]  
AS BEGIN
SELECT 
	assetacquire.nassetacquire AS 'Num. Carico Accessorio',
	yman   	      		   AS 'Esercizio Ordine',
	nman          		   AS 'Numero Ordine',
	rownum	      		   AS 'Riga Ordine',
	description   		   AS 'Descrizione',
	number        		   AS 'Quantita',
	(select count(*) 
	   from asset 
	  where nassetacquire= assetacquire.nassetacquire
	  and asset.idpiece>1)  AS 'Accessori',
	adate AS 'Data Contabile'
FROM    assetacquire  
JOIN    asset 
	ON asset.nassetacquire = assetacquire.nassetacquire
	AND asset.idpiece > 1
WHERE   (number is null or number<1 OR 
	(select count(*) from asset accessorio 
	 where accessorio.nassetacquire=assetacquire.nassetacquire
	 AND   idpiece >1) not in (0,number))
ORDER BY assetacquire.nassetacquire
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


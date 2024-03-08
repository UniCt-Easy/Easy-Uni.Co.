
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_carichi_senza_beni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_carichi_senza_beni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE         PROCEDURE [esporta_carichi_senza_beni]  
AS BEGIN
SELECT 
	nassetacquire AS 'Num. Carico Bene',
	yman   	      AS 'Esercizio Ordine',
	nman          AS 'Numero Ordine',
	rownum	      AS 'Riga Ordine',
	description   AS 'Descrizione',
	adate AS 'Data Contabile',
	CASE flag&2
		WHEN 0 THEN 'Nuova acquisizione'
		else 'Posseduto'
	END 	      AS 'Tipo Carico'
FROM    assetacquire  
WHERE   (select count(*) from asset where asset.nassetacquire =assetacquire.nassetacquire) = 0
ORDER BY nassetacquire
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

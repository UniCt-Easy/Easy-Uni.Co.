
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_carichi_amortizzati_senza_buono_flaggati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_carichi_amortizzati_senza_buono_flaggati]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




create         procedure esporta_carichi_amortizzati_senza_buono_flaggati

AS BEGIN

-- carichi bene senza assetload faggati con 'includi in buono di carico' che posseggono ammortamenti

SELECT AQ.nassetacquire AS 'Num. Carico',AQ.description AS 'DESCRIZIONE' , AE.ninventory as 'Num. Inventario',
	I.codeinventory AS 'Tipo Inventario', AM.namortization AS 'Num. Op. Ammortamento' 
	FROM assetacquire AQ 
	JOIN inventory I
		ON AQ.idinventory=I.idinventory
	JOIN asset AE
		ON AQ.nassetacquire = AE.nassetacquire
	JOIN assetamortization AM
		ON AE.idasset=AM.idasset
WHERE
	AQ.idassetload IS NULL
	AND AQ.flag & 1 != 0

END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



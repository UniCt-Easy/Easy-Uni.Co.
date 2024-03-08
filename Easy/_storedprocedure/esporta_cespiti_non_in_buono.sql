
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_cespiti_non_in_buono]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_cespiti_non_in_buono]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






create  PROCEDURE esporta_cespiti_non_in_buono

AS BEGIN

SELECT AQ.nassetacquire as 'Num. carico cespite', AQ.description as 'Descrizione', 
	AQ.startnumber as 'Num. Inv. Iniziale',AQ.number as 'Quantità', I.codeinventory as 'Codice Inventario'
	FROM assetacquire AQ 
	JOIN inventory I
		ON I.idinventory = AQ.idinventory
WHERE 	AQ.idassetload IS NULL
	AND AQ.flag & 1 !=0

ORDER BY AQ.nassetacquire

END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



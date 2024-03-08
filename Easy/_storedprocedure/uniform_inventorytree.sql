
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


if exists (select * from dbo.sysobjects where id = object_id(N'[uniform_inventorytree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [uniform_inventorytree]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE   PROCEDURE uniform_inventorytree
(
	@idsorkind int
)
AS BEGIN
	-- Tabelle da modificare
	-- 1. ASSETVARDETAIL
	-- 2. MANDATEDETAIL
	-- 3. ASSETACQUIRE
	-- 4. INVENTORYSORTINGAMORTIZATIONYEAR
	-- 5. INVENTORYTREESORTING (per IDSORKIND <> @IDSORKIND)

	UPDATE assetvardetail
	SET idinv = inventorytreesorting.idsor
	FROM inventorytreesorting
	JOIN sorting
		ON sorting.idsor = inventorytreesorting.idsor
	WHERE assetvardetail.idinv = inventorytreesorting.idinv
	AND sorting.idsorkind = @idsorkind

	UPDATE mandatedetail
	SET idinv = inventorytreesorting.idsor
	FROM inventorytreesorting
	JOIN sorting
		ON sorting.idsor = inventorytreesorting.idsor
	WHERE mandatedetail.idinv = inventorytreesorting.idinv
	AND sorting.idsorkind = @idsorkind

	UPDATE assetacquire
	SET idinv = inventorytreesorting.idsor
	FROM inventorytreesorting
	JOIN sorting
		ON sorting.idsor = inventorytreesorting.idsor
	WHERE assetacquire.idinv = inventorytreesorting.idinv
	AND sorting.idsorkind = @idsorkind

	UPDATE inventorysortingamortizationyear
	SET idinv = inventorytreesorting.idsor
	FROM inventorytreesorting
	JOIN sorting
		ON sorting.idsor = inventorytreesorting.idsor
	WHERE inventorysortingamortizationyear.idinv = inventorytreesorting.idinv
	AND sorting.idsorkind = @idsorkind

	UPDATE inventorytreesorting
	SET idinv =
		(SELECT ITS.idsor
		FROM inventorytreesorting ITS
		JOIN sorting
			ON sorting.idsor = ITS.idsor
		JOIN sorting EXT
			ON EXT.idsor = inventorytreesorting.idsor
		WHERE inventorytreesorting.idinv = ITS.idinv
		AND sorting.idsorkind = @idsorkind
		AND EXT.idsorkind <> @idsorkind)
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


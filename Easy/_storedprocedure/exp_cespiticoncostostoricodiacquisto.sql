
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_cespiticoncostostoricodiacquisto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_cespiticoncostostoricodiacquisto]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_cespiticoncostostoricodiacquisto]
	@year int,
	@idinventoryagency	int =null,		-- Ente inventariale
	@codeinv	varchar(50)	 			-- codice classificazione inventario

AS BEGIN
-- exec exp_cespiticoncostostoricodiacquisto 2016, 23, '4'
DECLARE @lastdate_firstyear datetime														
SET @lastdate_firstyear = CONVERT(datetime, '31-12-' + CONVERT(char(4),@year-1), 105)

CREATE TABLE #tempdata(idasset int, idpiece int, idinventoryagency int, idinv int, valore decimal(19,2), submanager varchar(150))

-------------------------------------------------------------------------------------
-------------------------- Carichi cespite E accessori  -------------------------------
-------------------------------------------------------------------------------------
INSERT INTO #tempdata(idasset, idpiece, idinventoryagency, idinv, valore, submanager)
SELECT
	asset.idasset, 
	asset.idpiece, 
	inventory.idinventoryagency,
	inventorytree.idinv, 
	SUM(AC.start),
	manager.title 
FROM assetacquire 
JOIN asset					ON assetacquire.nassetacquire = asset.nassetacquire
JOIN assetview_current AC	on AC.idasset=asset.idasset and AC.idpiece=asset.idpiece	
JOIN assetload				ON assetload.idassetload = assetacquire.idassetload
JOIN inventory				ON assetacquire.idinventory = inventory.idinventory
JOIN inventorykind			ON inventory.idinventorykind= inventorykind.idinventorykind
LEFT OUTER JOIN inventorytree ON inventorytree.idinv = assetacquire.idinv
LEFT OUTER JOIN assetunload ON assetunload.idassetunload = asset.idassetunload
LEFT OUTER JOIN manager
		ON manager.idman = 
			(SELECT TOP 1 idman
				FROM assetsubmanager
				WHERE assetsubmanager.idasset = asset.idasset
				ORDER BY start desc)
WHERE 
	assetload.yassetload < @year  
	AND assetload.ratificationdate<=@lastdate_firstyear
	AND (inventory.idinventoryagency = @idinventoryagency OR @idinventoryagency IS NULL)	
	AND ( (inventorykind.flag&2)=0)
	AND (inventorytree.codeinv LIKE @codeinv +'%' OR @codeinv IS NULL)	
	AND (assetunload.adate is null or year(assetunload.adate) >=@year)  ---cespite non ancora scaricato quest'anno
GROUP BY asset.idasset,asset.idpiece, inventory.idinventoryagency, inventorytree.idinv, manager.title 

	SELECT 
		#tempdata.idasset as 'N.Cespite',
		#tempdata.idpiece as 'N. Parte',
		ENTE.codeinventoryagency AS 'Codice Ente',
		ENTE.description as 'Ente inventariale',
		inventory.description as 'Inventario',
		isnull(asset.ninventory, assetmain.ninventory) as 'Num.Inventario',
		assetacquire.description as 'Descr.Carico',
		CLASS.nlevel as 'Liv.classifiazione',
		CLASS.codeinv as 'Codice Classificazione',
		CLASS.description as 'Classificazione',
		ISNULL(#tempdata.valore,0) as 'Costo storico di acquisto',
		#tempdata.submanager as 'Subconsegnatario'
	FROM #tempdata
	JOIN inventoryagency ENTE
		ON ENTE.idinventoryagency = #tempdata.idinventoryagency
	JOIN asset 
		ON asset.idasset = #tempdata.idasset  AND  #tempdata.idpiece = asset.idpiece
	JOIN asset  as assetmain
		ON assetmain.idasset = #tempdata.idasset  AND  assetmain.idpiece = 1
	JOIN assetacquire 
		ON assetacquire.nassetacquire = asset.nassetacquire
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory 
	LEFT OUTER JOIN inventorytree CLASS 
		ON CLASS.idinv = #tempdata.idinv
	ORDER BY ENTE.description, inventory.description, asset.ninventory, CLASS.codeinv

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


